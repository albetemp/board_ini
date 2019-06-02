using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class ParamArray
    {

        private const int MAX_NUMBER_OF_PARAMS = 25;
        private const string PARAMINFO_INI_SECTION_PARAMS_PREFIX = "RPARAMS_VER";
        private const string PARAMINFO_INI_KEY_NUMBER_OF_AVAILABLE_PARAMS = "Number_Of_Available_Params";
        private const int INI_SECTION_NOT_AVAILABLE_VERIFIER = 65535;
        private const string PARAMINFO_INI_KEY_DESCRIPTION = "Description";
        private const string PARAMINFO_INI_KEY_BYTE_POSITION = "BytePosition";
        private const string PARAMINFO_INI_KEY_BYTES_USED = "BytesUsed";
        private const string PARAMINFO_INI_KEY_VISIBLE = "Visible";
        private const string PARAMINFO_INI_KEY_DEFAULT_VALUE = "DefaultValue";

        private readonly Param[] _paramArray;
        private readonly int[] _numberOfParams;

        private Logger _logger = Logger.GetInstance();

        private ParamArray() { } // prevent to call default constructor

        public Param this[int index]
        {
            set
            {
                if (CheckListRange(index))
                {
                    _paramArray[index] = value;
                }
            }
            get
            {
                return CheckListRange(index) ? _paramArray[index] : null;
            }
        }

        private bool CheckListRange(int index)
        {
            if ((index < 0) || (index >= _paramArray.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return true;
        }

        public int GetNumberOfParams(int boardVersion)
        {
            if ((boardVersion < 0) || (boardVersion >= Settings.BoardVersions.Length))
            {
                _logger.WriteLine(LogLevel.Error, "Board version [{boardVersion}] is out of range [{Settings.BoardVersions[0]}(0)..{Settings.BoardVersions[Settings.BoardVersions.Length]}]({Settings.BoardVersions.Length - 1})");
                return 0;
            }
            return _numberOfParams[boardVersion];
        }

        public ParamArray(string configFile)
        {
            _paramArray = new Param[MAX_NUMBER_OF_PARAMS];
            _numberOfParams = new int[Settings.BoardVersions.Length];

            using (INIFile iniFile = new INIFile(configFile, false, true))
            {
                for (int verNumber = 0; verNumber < Settings.BoardVersions.Length; verNumber++)
                // we need to load all related info from ini file

                // get the number of available params for the selected version
                {

                    string sectionNumber = PARAMINFO_INI_SECTION_PARAMS_PREFIX + (verNumber + 1);

                    int numOfAvailableParams = iniFile.GetValue(sectionNumber, PARAMINFO_INI_KEY_NUMBER_OF_AVAILABLE_PARAMS, 0);

                    if (numOfAvailableParams == 0)
                    {
                        _logger.WriteLine(LogLevel.Error,$"Can't fill Control Param Info - Section [{sectionNumber}] Key {PARAMINFO_INI_KEY_NUMBER_OF_AVAILABLE_PARAMS}");
                        return;
                    }

                    _numberOfParams[verNumber] = numOfAvailableParams;

                    for (int paramNumber = 0; paramNumber < numOfAvailableParams; paramNumber++)
                    {

                        if (verNumber == 0) // creating new param only once for the first board version
                        {
                            _paramArray[paramNumber] = new Param();    
                        }

                        string paramPrefix = "Param" + (paramNumber + 1) + "_";

                        int bytePosition = iniFile.GetValue(sectionNumber, paramPrefix + PARAMINFO_INI_KEY_BYTE_POSITION, INI_SECTION_NOT_AVAILABLE_VERIFIER);

                        if (bytePosition == INI_SECTION_NOT_AVAILABLE_VERIFIER)
                        {
                            _logger.WriteLine(LogLevel.Error, $"Can't fill Control Param Info - Section [{sectionNumber}] Key {paramPrefix}");
                            continue;
                        }

                        string description = iniFile.GetValue(sectionNumber, paramPrefix + PARAMINFO_INI_KEY_DESCRIPTION, "INI Loading Error");
                        int bytesUsed = iniFile.GetValue(sectionNumber, paramPrefix + PARAMINFO_INI_KEY_BYTES_USED, 1);
                        bool visible = iniFile.GetValue(sectionNumber, paramPrefix + PARAMINFO_INI_KEY_VISIBLE, false);
                        int defaultValue = iniFile.GetValue(sectionNumber, paramPrefix + paramPrefix + PARAMINFO_INI_KEY_DEFAULT_VALUE, 0);             

                        ParamInfo paramInfo = new ParamInfo(description, bytePosition, bytesUsed, visible, defaultValue);

                        _paramArray[paramNumber].SetParamInfo(verNumber, paramInfo);
                    }
                }
            }
        }

    }
}
