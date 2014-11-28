using NetLog.Server.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NetLog.Server.Features
{
    [ServiceContract]
    public interface ILog
    {
        [OperationContract]
        void AddLog(AddLogDTO logDetails);
    }
}
