using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    public class Statics
    {
#if DEBUG
        public static bool DEBUG { get { return true; } }
#else
        public static bool DEBUG { get { return false; } }
#endif
    }
}
