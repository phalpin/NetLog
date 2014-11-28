using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    /// <summary>
    /// Log Type enum - defines the different types of logging you can do and provides a numerical representation of each type.
    /// </summary>
    public enum LogType
    {
        [Description("Error")]
        Error = 0,

        [Description("Warn")]
        Warn,

        [Description("Info")]
        Info,

        [Description("Debug")]
        Debug,

        [Description("Message")]
        Message
    }
}
