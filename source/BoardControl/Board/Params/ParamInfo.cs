using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class ParamInfo
    {
        public string Description { get; }
        public int BytePosition { get; }
        public int BytesUsed { get; }
        public bool Visible { get; }
        public int DefaultValue { get; }

        private ParamInfo()
        {

        }

        public ParamInfo(string description, int bytePosition, int bytesUsed, bool visible, int defaultValue)
        {
            Description = description;
            BytePosition = bytePosition;
            BytesUsed = bytesUsed;
            Visible = visible;
            DefaultValue = defaultValue;
        }

        public ParamInfo Clone()
        {
            return new ParamInfo(this.Description, this.BytePosition, this.BytesUsed, this.Visible, this.DefaultValue);
        }
    }
}
