using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class ControlBitParam
    {

        public const int NUMBER_OF_CONTROL_BITS = 16;

        private const int INI_SECTION_NOT_AVAILABLE_VERIFIER = 65535;

        private const string PARAMINFO_INI_KEY_DESCRIPTION = "Description";
        private const string PARAMINFO_INI_KEY_BIT_POSITION = "BitPosition";
        private const string PARAMINFO_INI_KEY_BITS_USED = "BitsUsed";
        private const string PARAMINFO_INI_KEY_VISIBLE = "Visible";
        private const string PARAMINFO_INI_KEY_DEFAULT_VALUE = "DefaultValue";
        private const string PARAMINFO_INI_KEY_VALUES_INFO = "ValuesInfo";
        private const string PARAMINFO_INI_SECTION_CONTROL_BITS_PREFIX = "CONTROL_BITS_VER";

        private readonly ControlBit[] _controlBitArray;

        private Logger _logger = Logger.GetInstance();

        private ControlBitParam() { } // prevent to call default constructor

        public ControlBitParam(string configFile)
        {
            _controlBitArray = new ControlBit[NUMBER_OF_CONTROL_BITS];

            using (INIFile iniFile = new INIFile(configFile, false, true))
            {

                // we need to load all related info from ini file
                for (int bitNumber = 0; bitNumber < NUMBER_OF_CONTROL_BITS; bitNumber++)
                {

                    _controlBitArray[bitNumber] = new ControlBit();

                    for (int verNumber = 0; verNumber < Settings.BoardVersions.Length; verNumber++)
                    {
                        string sectionNumber = PARAMINFO_INI_SECTION_CONTROL_BITS_PREFIX + (verNumber + 1);
                        string bitPrefix = "Bit" + bitNumber + "_";

                        int bitPosition = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_BIT_POSITION, INI_SECTION_NOT_AVAILABLE_VERIFIER);

                        if (bitPosition == INI_SECTION_NOT_AVAILABLE_VERIFIER)
                        {
                            _logger.WriteLine(LogLevel.Error, $"Can't fill Control RParam Info - Section [{sectionNumber}] is not available");
                            continue;
                        }

                        string description = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_DESCRIPTION, "INI Loading Error");
                        int bitsUsed = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_BITS_USED, 1);
                        bool visible = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_VISIBLE, false);
                        int defaultValue = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_DEFAULT_VALUE, 0);
                        string[] valuesInfo = iniFile.GetValue(sectionNumber, bitPrefix + PARAMINFO_INI_KEY_VALUES_INFO, "INI Loading Error").Split(',');

                        ControlBitInfo controlBitInfo = new ControlBitInfo(description, bitPosition, bitsUsed, visible, defaultValue, valuesInfo);

                        _controlBitArray[bitNumber].SetControlBitInfo(verNumber, controlBitInfo);
                    }
                }
            }
        }

        public ControlBit this[int index]
        {
            set
            {
                if (CheckListRange(index))
                {
                    _controlBitArray[index] = value;
                }
            }
            get
            {
                return CheckListRange(index) ? _controlBitArray[index] : null;
            }
        }

        private bool CheckListRange(int index)
        {
            if ((index < 0) || (index >= NUMBER_OF_CONTROL_BITS))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return true;
        }

    }
}
