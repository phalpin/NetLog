using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetLog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Tests
{
    [TestClass]
    public class EventViewerLoggerTests
    {
        private const string TEST_SOURCE = "NetLog Tests";
        
        [TestInitialize]
        public void Reset_Log_Methods()
        {
            NetLog.Client.Templates.EventViewerLogger.Initialize();
            NetLog.Client.Templates.EventViewerLogger.Options.Source = TEST_SOURCE;
        }

        private EventLogEntry getEventLogEntry(DateTime startTime, EventLogEntryType type, string message)
        {
            var targetLog = System.Diagnostics.EventLog.GetEventLogs().Where(d => d.LogDisplayName.Equals("Application")).FirstOrDefault();

            return (
                from EventLogEntry ele in targetLog.Entries.Cast<EventLogEntry>()
                where
                    ele.EntryType == type
                    && ele.Source == TEST_SOURCE
                    && ele.TimeWritten >= startTime.AddMilliseconds(-2 * startTime.Millisecond)
                    && ele.Message.Contains(message)
                select ele
            ).FirstOrDefault();
        }

        [TestMethod]
        public void Test_Info_Log()
        {
            DateTime startTime = DateTime.Now;
            Log.Info("Testing the {0} log", "info");
            var targetEntry = getEventLogEntry(startTime, EventLogEntryType.Information, "Testing the info log");
            Assert.IsNotNull(targetEntry, "Event Log not found!");
        }

        [TestMethod]
        public void Test_Debug_Log()
        {
            DateTime startTime = DateTime.Now;
            Log.Debug("Testing the {0} log", "debug");
            var targetEntry = getEventLogEntry(startTime, EventLogEntryType.Information, "Testing the debug log");
            Assert.IsNotNull(targetEntry, "Event Log not found!");
        }

        [TestMethod]
        public void Test_Warning_Log()
        {
            DateTime startTime = DateTime.Now;
            Log.Warn("Testing the {0} log", "warn");
            var targetEntry = getEventLogEntry(startTime, EventLogEntryType.Warning, "Testing the warn log");
            Assert.IsNotNull(targetEntry, "Event Log not found!");
        }

        [TestMethod]
        public void Test_Error_Log()
        {
            DateTime startTime = DateTime.Now;
            Log.Error("Testing the {0} log", "error");
            var targetEntry = getEventLogEntry(startTime, EventLogEntryType.Error, "Testing the error log");
            Assert.IsNotNull(targetEntry, "Event Log not found!");
        }

        [TestMethod]
        public void Test_Message_Log()
        {
            DateTime startTime = DateTime.Now;
            Log.Message("Testing the {0} log", "message");
            var targetEntry = getEventLogEntry(startTime, EventLogEntryType.Information, "Testing the message log");
            Assert.IsNotNull(targetEntry, "Event Log not found!");
        }

        [TestMethod]
        public void Test_Clearing_Logs()
        {
            var loggedEventsBefore = NetLog.Client.Templates.EventViewerLogger.LoggedEvents;
            NetLog.Client.Templates.EventViewerLogger.ClearLoggedEvents();
            var loggedEventsAfter = NetLog.Client.Templates.EventViewerLogger.LoggedEvents;
        }
    }
}
