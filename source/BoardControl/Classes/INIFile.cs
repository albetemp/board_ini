using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace AlbeFly.BoardControl
{

    public class INIFile : IDisposable
    {

#region "Declarations"

        // Lock for thread-safe access to file and local cache
        private readonly object _lock = new object();

        // File name
        private string _fileName = null;
        internal string FileName => _fileName;

        // lazy loading flag
        private bool _lazy = false;

        // Automatic flushing flag
        private bool _autoFlush = false;

        // Local cache
        private readonly Dictionary<string, Dictionary<string, string>> _sections = new Dictionary<string, Dictionary<string, string>>();
        private readonly Dictionary<string, Dictionary<string, string>> _modified = new Dictionary<string, Dictionary<string, string>>(); 

        // Local cache modified flag
        private bool _cacheModified = false;

#endregion

#region "Methods"

        // Constructor
        public INIFile(string fileName)
        {
            Initialize(fileName, false, false);
        }

        public INIFile(string fileName, bool lazy, bool autoFlush)
        {
            Initialize(fileName, lazy, autoFlush);
        }

        // Initialization
        private void Initialize(string fileName, bool lazy, bool autoFlush)
        {
            _fileName = fileName;
            _lazy = lazy;
            _autoFlush = autoFlush;
            if (!_lazy) Refresh();
        }

        // Parse section name
        private string ParseSectionName(string line)
        {
            if (!line.StartsWith("[")) return null;
            if (!line.EndsWith("]")) return null;
            if (line.Length < 3) return null;
            return line.Substring(1, line.Length - 2);
        }

        // Parse key+value pair
        private bool ParseKeyValuePair(string line, ref string key, ref string value)
        {
            // Check for key+value pair
            int i;
            if ((i = line.IndexOf('=')) <= 0) return false;
            
            int j = line.Length - i - 1;
            key = line.Substring(0, i).Trim();
            if (key.Length <= 0) return false;

            value = (j > 0) ? (line.Substring(i + 1, j).Trim()) : ("");
            return true;
        }

        // Read file contents into local cache
        public void Refresh()
        {
            lock (_lock)
            {
                StreamReader sr = null;
                try
                {
                    // Clear local cache
                    _sections.Clear();
                    _modified.Clear();

                    // Open the INI file
                    try
                    {
                        sr = new StreamReader(_fileName);
                    }
                    catch (FileNotFoundException)
                    {
                        return;
                    }

                    // Read up the file content
                    Dictionary<string, string> currentSection = null;
                    string s;
                    string key = null;
                    string value = null;
                    while ((s = sr.ReadLine()) != null)
                    {
                        s = s.Trim();
                        
                        // Check for section names
                        string sectionName = ParseSectionName(s);
                        if (sectionName != null)
                        {
                            // Only first occurrence of a section is loaded
                            if (_sections.ContainsKey(sectionName))
                            {
                                currentSection = null;
                            }
                            else
                            {
                                currentSection = new Dictionary<string, string>();
                                _sections.Add(sectionName, currentSection);
                            }
                        }
                        else if (currentSection != null)
                        {
                            // Check for key+value pair
                            if (ParseKeyValuePair(s, ref key, ref value))
                            {
                                // Only first occurrence of a key is loaded
                                if (!currentSection.ContainsKey(key))
                                {
                                    currentSection.Add(key, value);
                                }
                            }
                        }
                    }
                }
                finally
                {
                    // Cleanup: close file
                    sr?.Close();
                }
            }
        }
        
        // Flush local cache content
        public void Flush()
        {
            lock (_lock)
            {
                PerformFlush();
            }
        }


        public void Clear()
        {
            if (File.Exists(_fileName))
            {
                File.WriteAllText(_fileName, String.Empty);
            }

            Refresh();
        }

        private void PerformFlush()
        {
            // If local cache was not modified, exit
            if (!_cacheModified) return;
            _cacheModified = false;

            // Check if original file exists
            bool originalFileExists = File.Exists(_fileName);

            // Get temporary file name
            string tmpFileName = Path.ChangeExtension(_fileName, "$n$");

            // Create the temporary file
            StreamWriter sw = new StreamWriter(tmpFileName);

            try
            {
                Dictionary<string, string> currentSection = null;
                if (originalFileExists)
                {
                    StreamReader sr = null;
                    try
                    {
                        // Open the original file
                        sr = new StreamReader(_fileName);

                        // Read the file original content, replace changes with local cache values
                        string key = null;
                        string value = null;
                        bool reading = true;

                        while (reading)
                        {
                            string s = sr.ReadLine();
                            reading = (s != null);

                            // Check for end of file
                            string sectionName;
                            bool unmodified;
                            if (reading)
                            {
                                unmodified = true;
                                s = s.Trim();
                                sectionName = ParseSectionName(s);
                            }
                            else
                            {
                                unmodified = false;
                                sectionName = null;
                            }

                            // Check for section names
                            if ((sectionName != null) || (!reading))
                            {
                                // Write all remaining modified values before leaving a section*
                                if (currentSection?.Count > 0)
                                {
                                    foreach (string fkey in currentSection.Keys)
                                    {
                                        if (currentSection.TryGetValue(fkey, out value))
                                        {
                                            sw.Write(fkey);
                                            sw.Write('=');
                                            sw.WriteLine(value);
                                        }
                                    }
                                    //sw.WriteLine();
                                    currentSection.Clear();
                                }

                                if (reading)
                                {
                                    // Check if current section is in local modified cache
                                    if (!_modified.TryGetValue(sectionName, out currentSection))
                                    {
                                        // ReSharper disable once RedundantAssignment
                                        currentSection = null;
                                    }
                                }
                            }
                            else if (currentSection != null)
                            {
                                // Check for key+value pair
                                if (ParseKeyValuePair(s, ref key, ref value))
                                {
                                    if (currentSection.TryGetValue(key, out value))
                                    {
                                        // Write modified value to temporary file
                                        unmodified = false;
                                        currentSection.Remove(key);

                                        sw.Write(key);
                                        sw.Write('=');
                                        sw.WriteLine(value);
                                    }
                                }
                            }

                            // Write unmodified lines from the original file
                            if (unmodified)
                            {
                                sw.WriteLine(s);
                            }
                        }

                        // Close the original file
                        sr.Close();
                        sr = null;
                    }
                    finally
                    {
                        // Cleanup: close files                  
                        // ReSharper disable once ConstantConditionalAccessQualifier
                        sr?.Close();
                    }
                }

                // Cycle on all remaining modified values
                foreach (KeyValuePair<string, Dictionary<string, string>> sectionPair in _modified)
                {
                    currentSection = sectionPair.Value;
                    if (currentSection.Count > 0)
                    {
                        sw.WriteLine();

                        // Write the section name
                        sw.Write('[');
                        sw.Write(sectionPair.Key);
                        sw.WriteLine(']');

                        // Cycle on all key+value pairs in the section
                        foreach (KeyValuePair<string, string> valuePair in currentSection)
                        {
                            // Write the key+value pair
                            sw.Write(valuePair.Key);
                            sw.Write('=');
                            sw.WriteLine(valuePair.Value);
                        }
                        currentSection.Clear();
                    }
                }
                _modified.Clear();

                // Close the temporary file
                sw.Close();
                sw = null;

                // Rename the temporary file
                File.Copy(tmpFileName, _fileName, true);

                // Delete the temporary file
                File.Delete(tmpFileName);
            }
            finally
            {
                // Cleanup: close files                  
                // ReSharper disable once ConstantConditionalAccessQualifier
                sw?.Close();
            }
        }
    
        // Read a value from local cache
        public string GetValue(string sectionName, string key, string defaultValue)
        {
            // lazy loading
            if (_lazy)
            {
                _lazy = false;
                Refresh();
            }

            lock (_lock)
            {
                // Check if the section exists
                Dictionary<string, string> section;
                if (!_sections.TryGetValue(sectionName, out section)) return defaultValue;

                // Check if the key exists
                string value;
                if (!section.TryGetValue(key, out value)) return defaultValue;
            
                // Return the found value
                return value;
            }
        }

        // Insert or modify a value in local cache
        public void SetValue(string sectionName, string key, string value)
        {
            // lazy loading
            if (_lazy)
            {
                _lazy = false;
                Refresh();
            }

            lock (_lock)
            {
                // Flag local cache modification
                _cacheModified = true;

                // Check if the section exists
                Dictionary<string, string> section;
                if (!_sections.TryGetValue(sectionName, out section))
                {
                    // If it doesn't, add it
                    section = new Dictionary<string, string>();
                    _sections.Add(sectionName,section);
                }

                // Modify the value
                if (section.ContainsKey(key)) section.Remove(key);
                section.Add(key, value);

                // Add the modified value to local modified values cache
                if (!_modified.TryGetValue(sectionName, out section))
                {
                    section = new Dictionary<string, string>();
                    _modified.Add(sectionName, section);
                }

                if (section.ContainsKey(key)) section.Remove(key);
                section.Add(key, value);

                // Automatic flushing : immediately write any modification to the file
                if (_autoFlush) PerformFlush();
            }
        }

        // Encode byte array
        private string EncodeByteArray(byte[] value)
        {
            if (value == null) return null;

            StringBuilder sb = new StringBuilder();
            foreach (byte b in value)
            {
                string hex = Convert.ToString(b, 16);
                int l = hex.Length;
                if (l > 2)
                {
                    sb.Append(hex.Substring(l - 2, 2));
                }
                else
                {
                    if (l < 2) sb.Append("0");
                    sb.Append(hex);
                }
            }
            return sb.ToString();
        }

        // Decode byte array
        private byte[] DecodeByteArray(string value)
        {
            if (value == null) return null;

            int l = value.Length;
            if (l < 2) return new byte[] { };
            
            l /= 2;
            byte[] result = new byte[l];
            for (int i = 0; i < l; i++) result[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            return result;
        }

        // Getters for various types
        public bool GetValue(string sectionName, string key, bool defaultValue)
        {
            string stringValue = GetValue(sectionName, key, defaultValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
            int value;
            if (int.TryParse(stringValue, out value)) return (value != 0);
            return defaultValue;
        }

        public int GetValue(string sectionName, string key, int defaultValue)
        {
            string stringValue = GetValue(sectionName, key, defaultValue.ToString(CultureInfo.InvariantCulture));
            int value;
            if (int.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value)) return value;
            return defaultValue;
        }

        public long GetValue(string sectionName, string key, long defaultValue)
        {
            string stringValue = GetValue(sectionName, key, defaultValue.ToString(CultureInfo.InvariantCulture));
            long value;
            if (long.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value)) return value;
            return defaultValue;
        }

        public double GetValue(string sectionName, string key, double defaultValue)
        {
            string stringValue = GetValue(sectionName, key, defaultValue.ToString(CultureInfo.InvariantCulture));
            double value;
            if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out value)) return value;
            return defaultValue;
        }

        public byte[] GetValue(string sectionName, string key, byte[] defaultValue)
        {
            string stringValue = GetValue(sectionName, key, EncodeByteArray(defaultValue));
            try
            {
                return DecodeByteArray(stringValue);
            }
            catch (FormatException)
            {
                return defaultValue;
            }
        }

        public DateTime GetValue(string sectionName, string key, DateTime defaultValue)
        {
            string stringValue = GetValue(sectionName, key, defaultValue.ToString(CultureInfo.InvariantCulture));
            DateTime value;
            if (DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.AssumeLocal, out value)) return value;
            return defaultValue;
        }

        // Setters for various types
        public void SetValue(string sectionName, string key, bool value)
        {
            SetValue(sectionName, key, (value) ? ("1") : ("0"));
        }

        public void SetValue(string sectionName, string key, int value)
        {
            SetValue(sectionName, key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetValue(string sectionName, string key, long value)
        {
            SetValue(sectionName, key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetValue(string sectionName, string key, double value)
        {
            SetValue(sectionName, key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void SetValue(string sectionName, string key, byte[] value)
        {
            SetValue(sectionName, key, EncodeByteArray(value));
        }

        public void SetValue(string sectionName, string key, DateTime value)
        {
            SetValue(sectionName, key, value.ToString(CultureInfo.InvariantCulture));
        }

#endregion

        public void Dispose()
        {
            Flush();
        }
    }

}
