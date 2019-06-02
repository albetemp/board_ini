using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AlbeFly.BoardControl
{

    public enum LogLevel
    {
        None, Debug, Info, Warning, Error, Exception
    }

    public class MemLogEventArgs : EventArgs
    {
        public string Log { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class Logger
    {

        public delegate void MemLogEventHandler(object sender, MemLogEventArgs e);

        /// <summary>
        /// Event that will be raised all time when new log is arrived if UseMemLog is true
        /// </summary>
        public event MemLogEventHandler MemLog;

        private const int MAX_LOG_LINES_BEFORE_FLUSH = 20;
        private static Logger _instance; // to implement singleton
        private readonly object _lock = new object();
        private readonly object _memListLock = new object(); // lock for the memory log list
        private string _logFilePath;
        private bool _logMethodNames;
        private bool _useMemLog;
        private LogLevel _minLogLevel;
        private int _logLines = 0; // number of lines in _logList; to increase speed
        private readonly List<MemLogEventArgs> _logList = new List<MemLogEventArgs>();
        private readonly List<MemLogEventArgs> _memLogList = new List<MemLogEventArgs>();
        private bool _logFileIsOpened = false; // true if Logger was initialized and log file is opened
        private TextWriter _logWriter;

        private Logger()
        {
        }

        /// <summary>
        /// Minimum log level that will be stored
        /// For example, if MinLogLevel = Info, None and Debug levels will not be processed
        /// </summary>
        public LogLevel MinLogLevel
        {
            get
            {
                return _minLogLevel;
            }
            set
            {
                lock (_lock)
                {
                    _minLogLevel = value;
                }
            }
        }


        /// <summary>
        /// If true, all logs also stored in internal memory and can be returned by "GetMemLog" method call
        /// </summary>
        public bool UseMemLog
        {
            get
            {
                return _useMemLog;
            }
            set
            {
                lock (_lock)
                {
                    _useMemLog = value;
                }
            }
        }

        /// <summary>
        /// If true, logger will try to get class and method names for the log entry
        /// </summary>
        public bool LogMethodNames
        {
            get
            {
                return _logMethodNames;
            }
            set
            {
                lock (_lock)
                {
                    _logMethodNames = value;
                }
            }
        }

        /// <summary>
        /// Full log path and file name
        /// </summary>
        public string LogFilePath => _logFilePath;

        /// <summary>
        /// Open Log File (Initialize Logger)
        /// </summary>
        /// <param name="logFilePath">File path with File Name</param>
        /// <returns>false is file can't be opened</returns>
        public bool OpenLogFile(string logFilePath)
        {

            lock (_lock)
            {

                if (_logFileIsOpened)
                {
                    CloseLogFile();
                }

                try
                {
                    _logWriter = new StreamWriter(logFilePath, true); // append mode                    
                }
                catch (Exception)
                {
                    return false;
                }

                _logFilePath = logFilePath;
                _logFileIsOpened = true;

                return true;

            }
        }

        /// <summary>
        /// Close Log File
        /// </summary>
        public void CloseLogFile()
        {
            if (_logFileIsOpened)
            {
                Flush();
                _logWriter.Close();
                _logFileIsOpened = false;
            }

        }

        /// <summary>
        /// Base method to get instance of logger 
        /// Do not use constructor!
        /// private Logger _logger = Logger.GetInstance();
        /// </summary>
        /// <returns></returns>
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        /// <summary>
        /// Write log entry with predefined log level as Debug
        /// </summary>
        /// <param name="text">Log entry</param>
        public void WriteDebug(string text)
        {
            WriteLine(LogLevel.Debug, text);
        }

        /// <summary>
        /// Write log entry with predefined log level as Error
        /// </summary>
        /// <param name="text">Log entry</param>
        public void WriteError(string text)
        {
            WriteLine(LogLevel.Error, text);
        }

        /// <summary>
        /// Write log entry with predefined log level as Info
        /// </summary>
        /// <param name="text">Log entry</param>
        public void WriteInfo(string text)
        {
            WriteLine(LogLevel.Info, text);
        }

        /// <summary>
        /// Write log entry with predefined log level as Warning
        /// </summary>
        /// <param name="text">Log entry</param>
        public void WriteWarning(string text)
        {
            WriteLine(LogLevel.Warning, text);
        }

        /// <summary>
        /// Write log entry with predefined log level as Exception
        /// </summary>
        /// <param name="text">Log entry</param>
        public void WriteException(string text)
        {
            WriteLine(LogLevel.Exception, text);
        }

        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="category">Log Category</param>
        /// <param name="text">Log Text</param>
        public void WriteLine(LogLevel category, string text)
        {
            if ((_minLogLevel > LogLevel.None) || (!_logFileIsOpened))
            {
                return;
            }

            lock (_lock)
            {

                DateTime dateTime = DateTime.Now;

                MemLogEventArgs memLogEventArgs = new MemLogEventArgs {TimeReached = dateTime};

                string formattedTime = String.Format("{0:yyyy/MM/dd; HH:mm:ss.fff}", dateTime);

                GetMethodName(out string className, out string methodName);

                memLogEventArgs.Log = string.Format("{0,-26}; {1,-11}; {2,-14}; {3,-17}; {4,-33}\r\n", formattedTime, category.ToString(), className, methodName, text);

                _logList.Add(memLogEventArgs);
                _logLines++;

                if (_useMemLog)
                {
                    memLogEventArgs.Log = String.Format("{0:HH:mm:ss.fff; }", dateTime) + category.ToString() + "; " + text;
                    _memLogList.Add(memLogEventArgs);

                    OnMemLog(memLogEventArgs);

                }

                if (_logLines >= MAX_LOG_LINES_BEFORE_FLUSH)
                {
                    Flush();
                }

            }

        }

        /// <summary>
        /// Write Log
        /// </summary>
        /// <param name="text">Log Text</param>
        public void WriteLine(string text)
        {
            if ((_minLogLevel > LogLevel.None) || (!_logFileIsOpened))
            {
                return;
            }


            lock (_lock)
            {


                DateTime dateTime = DateTime.Now;

                MemLogEventArgs memLogEventArgs = new MemLogEventArgs { TimeReached = dateTime };


                string formattedTime = String.Format("{0:yyyy/MM/dd; HH:mm:ss.fff}", dateTime);


                GetMethodName(out string className, out string methodName);

                memLogEventArgs.Log = string.Format("{0,-26}; {1,-11}; {2,-14}; {3,-17}; {4,-33}\r\n", formattedTime, LogLevel.None.ToString(), className, methodName, text);

                _logList.Add(memLogEventArgs);
                _logLines++;

                if (_useMemLog)
                {
                    
                    memLogEventArgs.Log = String.Format("{0:HH:mm:ss.fff; }", dateTime) + LogLevel.None.ToString() + "; " + text;
                    _memLogList.Add(memLogEventArgs);
                    OnMemLog(memLogEventArgs);
                }

                if (_logLines >= MAX_LOG_LINES_BEFORE_FLUSH)
                {
                    Flush();
                }
            }
        }

        /// <summary>
        /// Convert exception to detailed string with available stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public string ExceptionToString(Exception exception)
        {
            string stackTracePart = exception.InnerException != null ?
            exception.InnerException.StackTrace + "\r\n\r\n" + exception.StackTrace :
            exception.StackTrace;

            string messagePart = exception.Message + (exception.InnerException != null ? "\r\n" + exception.InnerException.Message : "");

            string text = messagePart + "\r\n\r\n" + stackTracePart;
            return text;
        }

        /// <summary>
        /// Convert exception to detailed string with available stack trace
        /// and write it to the log file
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>

        public void WriteException(Exception exception)
        {
            if (string.IsNullOrEmpty(LogFilePath))
            {
                return;
            }

            string text = ExceptionToString(exception);

            WriteLine(LogLevel.Exception, text);
        }

        private void GetMethodName(out string className, out string methodName)
        {
            className = "";
            methodName = "";

            if (!_logMethodNames)
            {
                return;
            }

            var stackFrame = new System.Diagnostics.StackFrame(2);
            var method = stackFrame.GetMethod();

            if (method.DeclaringType == null)
            {
                return;
            }

            className = method.DeclaringType.FullName;
            methodName = method.Name;

        }

        /// <summary>
        /// Get Log List from Memory 
        /// </summary>
        /// <param name="cleanMemLogList">Clean memory log list</param>
        /// <returns></returns>
        public List<MemLogEventArgs> GetMemLogList(bool cleanMemLogList)
        {

            lock (_memLogList)
            {
                if (!cleanMemLogList)
                {
                    return _memLogList;
                }

                List<MemLogEventArgs> clonedList = _memLogList.ToList();
                _memLogList.Clear();

                return clonedList;
            }

        }

        protected virtual void OnMemLog(MemLogEventArgs e)
        {
            MemLog?.Invoke(this, e);
        }

        private void Flush()
        {
            // should be alreade locked
            foreach (MemLogEventArgs logLine in _logList)
            {
                _logWriter.WriteLine(logLine.Log);
            }

            _logWriter.Flush();

            _logList.Clear();
            _logLines = 0;
        }

    }

}
