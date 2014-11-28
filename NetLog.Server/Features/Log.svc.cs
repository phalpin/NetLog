using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NetLog.Server.DTOs;

namespace NetLog.Server.Features
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Log" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Log.svc or Log.svc.cs at the Solution Explorer and start debugging.
    public class Log : ILog
    {
        public void AddLog(AddLogDTO logDetails)
        {
            var logSvc = new Services.LogService();
            logSvc.AddLog(logDetails.Message, logDetails.Details);
        }
    }
}
