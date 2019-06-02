using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class Param
    {
        private readonly ParamInfo[] _paramInfo;
        public byte Value { get; set; }

        public Param()
        {
            _paramInfo = new ParamInfo[Settings.BoardVersions.Length];
            Value = 0;
        }

        public void SetParamInfo(int boardVersion, ParamInfo paramInfo)
        {
            int index = boardVersion;
            _paramInfo[index] = paramInfo.Clone();
        }


        public ParamInfo this[int boardVersion] => GetParamInfo(boardVersion);

        public ParamInfo GetParamInfo(int boardVersion)
        {
            return _paramInfo[boardVersion];
        }
    }
}
