using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    
    public class Defs
    {
        public const string APP_GUID = "{77A46331-62BC-45E2-FCC9-73387B374879}";
        public const string MAIN_FORM_CAPTION = "Board Control";
        public const string INI_FILE_NAME = "BoardControl.ini";
        public const string LOG_FILE_NAME = "BoardControl.log";
        public const string PARAMINFO_INI_FILE_NAME = "BoardParams.ini";
        public const string INI_SECT_CB_PREFIX_NAME = "BOARD_";        
        public const string INI_KEY_CB_IS_AVAILABLE_FOR_REUSE = "Available_To_Reuse";
        public const string INI_KEY_CB_IS_ENABLED = "Enabled";
        public const string INI_KEY_CB_NAME = "Name";
        public const string INI_KEY_CB_FW_VERSION = "Version";
        public const string INI_KEY_CB_COMPORT_NUMBER = "COM_Port_Number";
        public const string PARAMINFO_INI_SECTION_PARAM_VERSIONS = "PARAM_VERSIONS";
        public const string PARAMINFO_INI_KEY_PARAM_VERSIONS_PREFIX = "Ver";

        public const int CB_DEFAULT_BOARD_VERSION = 0;
        public const int CB_DEFAULT_COMPORT_NUMBER = 0;

        public const int MAX_BOARDS = 10; // nuber of supported counter boards at the same time
        public const int MAX_BOARD_VERSIONS = 255; // number of supported board versions

        public const string INI_NOT_AVAILABLE_STRING = "krdsff34KLerg0)#(&%34%sdft#R@$KJ%"; // magic string for INI parser; Use it to check value is not available

        public enum ComPortBaudRate
        {            
            Baud4800,
            Baud9600,
            Baud19200,
            Baud38400,
            Baud57600,
            Baud115200,
            Baud230400
        };

        public enum ComPortDataBits
        {
            Bits7,
            Bits8
        };

        public delegate void CloseAppDelegate();

        public delegate void FormInitDelegate();
        public delegate void FormAddBoardDelegate(int index);
        public delegate void FormSelectBoardDelegate(int index);

        public delegate Board GetBoardInfoDelegate(int index);
    }
}
