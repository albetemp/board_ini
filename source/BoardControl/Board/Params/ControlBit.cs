using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class ControlBit
    {
        private readonly ControlBitInfo[] _controlBitInfo;

        public byte Value { get; set; }

        public ControlBit()
        {
            _controlBitInfo = new ControlBitInfo[Settings.BoardVersions.Length];
            Value = 0;
        }

        public void SetControlBitInfo(int boardVersion, ControlBitInfo controlBitInfo)
        {
            int index = boardVersion;
            _controlBitInfo[index] = controlBitInfo.Clone();
        }


        public ControlBitInfo this[int boardVersion] => GetControlBitInfo(boardVersion);

        public ControlBitInfo GetControlBitInfo(int boardVersion)
        {
            return _controlBitInfo[boardVersion];
        }
    }
}
