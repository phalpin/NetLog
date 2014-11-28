using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    public class LogMethodGroup
    {
        /// <summary>
        /// This is the method to implement if you would just like a straight string output.
        /// </summary>
        public Action<string> StringMethod { get; set; }

        /// <summary>
        /// This is the method to implement if you would like the message, as well as programmatic access to the details of the log.
        /// </summary>
        public Action<string, LogDetails> FullMethod { get; set; }

        internal void ExecuteMethod(LogType type, string message, LogDetails details)
        {
            DateTime timeStamp = DateTime.Now;

            string fullMessage = string.Format(
                "{0}[{1}][{2}][{3}]: {4}",
                /*00*/timeStamp,
                /*01*/type.ToString(),
                /*02*/details.Class,
                /*03*/details.Method,
                /*04*/message
            );

            if (StringMethod != null)
            {
                try
                {
                    StringMethod(type == LogType.Message ? message :  fullMessage);
                }
                catch(Exception ex) { }
            }

            if(FullMethod != null)
            {
                try
                {
                    FullMethod(message, details);
                }
                catch(Exception ex) { }
            }
        }
    }
}
