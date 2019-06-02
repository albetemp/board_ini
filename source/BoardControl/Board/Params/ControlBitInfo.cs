using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class ControlBitInfo
    {
        public string Description { get; }
        public int BitPosition { get; }
        public int BitsUsed { get;  }
        public bool Visible { get;  }
        public int DefaultValue { get; }
        public string[] ValuesInfo { get; }

        private ControlBitInfo()
        {
            
        }

        public ControlBitInfo(string description, int bitPosition, int bitsUsed,
            bool visible, int defaultValue, string[] valuesInfo)
        {
            Description = description;
            BitPosition = bitPosition;
            BitsUsed = bitsUsed;
            Visible = visible;
            DefaultValue = defaultValue;
            ValuesInfo = (string[])valuesInfo.Clone();            
        }

        public ControlBitInfo Clone()
        {
            return new ControlBitInfo(this.Description, this.BitPosition, this.BitsUsed, this.Visible, this.DefaultValue, this.ValuesInfo);
        }

    }
}
