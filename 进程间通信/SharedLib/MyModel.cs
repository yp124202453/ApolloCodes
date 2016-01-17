using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [Serializable]
    public struct MyModel
    {
        public IntPtr DataHandle { get; set; }

        public int CbData { get; set; }

        public string LpData { get; set; }
    }
}
