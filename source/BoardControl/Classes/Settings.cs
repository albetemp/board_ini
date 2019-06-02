using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public static class Settings
    {

        public static string ApplicationPath { get; }

        public static string[] BoardVersions { get; set; }

        static Settings()
        {
            ApplicationPath = AppHelper.IncludeTrailingBackslash(AppHelper.GetApplicationPath());           
        }

    }

    

    public class ComPort
    {
        public static int PortNumber { get; set; }
        public static Defs.ComPortBaudRate BaudRate { get; set; }
        public static Defs.ComPortDataBits DataBits { get; set; }
        public static System.IO.Ports.Parity Parity { get; set; }
        public static System.IO.Ports.StopBits StopBits { get; set; }
        public static System.IO.Ports.Handshake Handshake { get; set; }
    };

}
