using NetLog.Core;
using NetLog.Server.Data;
using NetLog.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetLog.Server.Services
{
    public class LogService
    {
        private LogEntryData _logEntryData;
        private MethodData _methodData;
        private ClassData _classData;

        public LogService()
        {
            _logEntryData = new LogEntryData();
            _methodData = new MethodData();
            _classData = new ClassData();
        }

        public void AddLog(string message, LogDetails details)
        {
            var existingClass = GetExistingOrNewClass(details);
            var existingMethod = GetExistingOrNewMethod(details, existingClass);

            var newLogEnt = new Entities.Log
            {
                MethodId = existingMethod.Id,
                Message = message,
                DateCreated = details.TimeLogged,
                LogType = (short)details.LogType
            };
            _logEntryData.Save(newLogEnt);
        }

        /// <summary>
        /// Returns an existing, or a brand new class based on the details provided.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        private Entities.Class GetExistingOrNewClass(LogDetails details)
        {
            var existingClass = _classData.GetClassByNameAndNamespace(details.Class, details.Namespace);

            if (existingClass == null)
            {
                existingClass = new Entities.Class()
                {
                    Name = details.Class,
                    Namespace = details.Namespace
                };

                existingClass = _classData.Save(existingClass);
            }

            return existingClass;
        }

        /// <summary>
        /// Returns an existing, or a brand new method based on the details & parent class provided.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="targetClass"></param>
        /// <returns></returns>
        private Entities.Method GetExistingOrNewMethod(LogDetails details, Entities.Class targetClass)
        {
            var existingMethod = _methodData.GetByNameAndClassId(targetClass.Id, details.Method);

            if(existingMethod == null)
            {
                existingMethod = new Entities.Method
                {
                    ClassId = targetClass.Id,
                    Name = details.Method
                };
                existingMethod = _methodData.Save(existingMethod);
            }

            return existingMethod;
        }
    }
}