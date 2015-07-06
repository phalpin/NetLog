using NetLog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Client.Templates
{
    /// <summary>
    /// Logs out to the Windows Event Viewer
    /// </summary>
    /// <remarks>MAKE SURE YOU'RE RUNNING IN AN ACCOUNT WITH SUFFICIENT PERMISSIONS</remarks>
    internal class EventViewerLogger
    {

        public static class Options
        {
            public static string Source { get; set; }
            public static string LogName { get; set; }
        }

        public static void Initialize()
        {
            Options.Source = string.IsNullOrEmpty(Options.Source) ? System.Reflection.Assembly.GetCallingAssembly().GetName().Name : Options.Source;
            Options.LogName = string.IsNullOrEmpty(Options.LogName) ? "NetLogEvents" : Options.LogName;
            Log.Methods.Debug.FullMethod = DoLog;
            Log.Methods.Error.FullMethod = DoLog;
            Log.Methods.Info.FullMethod = DoLog;
            Log.Methods.Message.FullMethod = DoLog;
            Log.Methods.Warn.FullMethod = DoLog;
        }

        private static EventLog GetTargetedLog()
        {
            return EventLog.GetEventLogs().Where(d => d.LogDisplayName.Equals(Options.LogName)).FirstOrDefault();
        }

        public static List<EventLogEntry> LoggedEvents
        {
            get
            {
                var targetLog = GetTargetedLog();

                if (targetLog != null)
                {
                    return (
                        from EventLogEntry ele in targetLog.Entries.Cast<EventLogEntry>()
                        where ele.Source == Options.Source
                        select ele
                    ).ToList();
                }

                return new List<EventLogEntry>();
            }
        }

        public static void ClearLoggedEvents()
        {
            if (EventLog.SourceExists(Options.Source))
                EventLog.DeleteEventSource(Options.Source);
            if (EventLog.Exists(Options.LogName))
                EventLog.Delete(Options.LogName);

            EventLog.CreateEventSource(Options.Source, Options.LogName);
        }

        private static EventLogEntryType TypeForLogType(LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    return EventLogEntryType.Error;
                case LogType.Debug:    
                case LogType.Info:
                case LogType.Message:
                    return EventLogEntryType.Information;
                case LogType.Warn:
                    return EventLogEntryType.Warning;
            }

            return EventLogEntryType.FailureAudit;
        }

        private static void DoLog(string message, LogDetails details)
        {
            var fullMessage = string.Format("Log Level: {0}\n[{1}][{2}] {3}", details.LogType, details.Class, details.Method, message);
            var logtype = TypeForLogType(details.LogType);
            //if(!EventLog.Exists(Options.LogName))

            
            if (!EventLog.SourceExists(Options.Source))
                EventLog.CreateEventSource(Options.Source, Options.LogName);
            EventLog.WriteEntry(Options.Source, fullMessage, logtype);
        }
    }
}
