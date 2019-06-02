using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbeFly.BoardControl
{

    public enum ParamSource
    {
        [Description("Source1")]
        Src1 = 0,
        [Description("Source2")]
        Src2 = 1,
        [Description("Source3")]
        Src3 = 2,
    }


    // TODO: Mutable! 
    public struct BoardParams
    {

        public int Version;
        public int ParamBits;
        public int Param1;
        public int Param2;
        public int Param3;
        public int Param4;
        public int Param5;
        public int Param6;
    }

    public class Board
    {
        private int _boardVersion;

        // Some properties might be extracted in outer class later...

        /// <summary>
        /// True if Counter Board is enabled in settings
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// True if entry was loaded from INI and deleted in settings. Can be used again when user will add new entry
        /// </summary>
        public bool IsAvailableToReuse { get; set; }

        /// <summary>
        /// Position in INI file, related to section number index 
        /// </summary>
        public byte IniPosition { get; set; }


        public string Name { get; set; }

        public int ComPortNumber { get; set; }

        public int BoardVersion
        {
            get
            {
                return _boardVersion;
            }
            set
            {
                _boardVersion = value;
                ChangeBoardVersion();
            }
        }

        public ControlBitParam ControlParam { get; private set; }
        public ParamArray Params { get; set; }

        public Board()
        {
            BoardVersion = Defs.CB_DEFAULT_BOARD_VERSION;
            ControlParam = new ControlBitParam(Settings.ApplicationPath + Defs.PARAMINFO_INI_FILE_NAME);
            Params = new ParamArray(Settings.ApplicationPath + Defs.PARAMINFO_INI_FILE_NAME);

        }

        private void ChangeBoardVersion()
        {
            // TODO: Implement something here if needed

        }

        private void InitControlParam()
        {


        }




    }
}
