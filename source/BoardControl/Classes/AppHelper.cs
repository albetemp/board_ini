using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AlbeFly.BoardControl
{
    /// <summary>
    /// Static class with common methods for every application
    /// </summary>
    public static class AppHelper
    {
        private static readonly Assembly _assembly;
        private static readonly string _directorySeparatorChar;

        /// <summary>
        /// 
        /// </summary>
        static AppHelper()
        {
            _assembly = Assembly.GetEntryAssembly();
            _directorySeparatorChar = Path.DirectorySeparatorChar.ToString();
        }

        /// <summary>
        /// Returns Application Name
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationName()
        {
            return Path.GetFileNameWithoutExtension(_assembly.GetName().Name);
        }

        /// <summary>
        /// Get Application Path with trailing backslash
        /// </summary>
        /// <returns></returns>
        public static string GetApplicationPath()
        {
            return IncludeTrailingBackslash(System.IO.Path.GetDirectoryName(_assembly.Location) ?? "");
        }

        /// <summary>
        /// Get structure with Application (Assembly) info
        /// </summary>
        /// <returns></returns>
        public static FileVersionInfo GetApplicationVersionInfo()
        {
            return _assembly.Location != null ? FileVersionInfo.GetVersionInfo(_assembly.Location) : null;
        }

        /// <summary>
        /// Add backslash to the path if needed
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string IncludeTrailingBackslash(string path)
        {

            return path?.TrimEnd(Path.DirectorySeparatorChar) + _directorySeparatorChar;
        }

        /// <summary>
        /// Remove backslash from the path if needed
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ExcludeTrailingBackslash(string path)
        {
            return path?.TrimEnd(Path.DirectorySeparatorChar);
        }

        /// <summary>
        /// Combine two string in path
        /// Do it better than Path.Combine     
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns>resulted combined string</returns>
        public static string CombinePath(string path1, string path2)
        {
            path1 = IncludeTrailingBackslash(path1);
            path2 = path2?.TrimStart(Path.DirectorySeparatorChar);
            return IncludeTrailingBackslash(path1 + path2);
        }

        /// <summary>
        /// Convert exception to detailed string with available stack trace
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string ExceptionToString(Exception exception)
        {
            string stackTracePart = exception.InnerException != null ?
            exception.InnerException.StackTrace + "\r\n\r\n" + exception.StackTrace :
            exception.StackTrace;

            string messagePart = exception.Message + (exception.InnerException != null ? "\r\n" + exception.InnerException.Message : "");

            string text = messagePart + "\r\n\r\n" + stackTracePart;
            return text;
        }

    }
}
