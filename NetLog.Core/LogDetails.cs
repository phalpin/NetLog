using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    public class LogDetails
    {
        public string Class { get; set; }
        public string Namespace { get; set; }
        public string Method { get; set; }
        public string File { get; set; }
        public int LineNumber { get; set; }
        public DateTime TimeLogged { get; private set; }
        public LogType LogType { get; set; }
        
        public LogDetails()
        {
            TimeLogged = DateTime.Now;
        }
    }
}
