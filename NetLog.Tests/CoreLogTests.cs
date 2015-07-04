using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetLog.Core;

namespace NetLog.Tests
{
    [TestClass]
    public class CoreLogTests
    {
        [TestInitialize]
        public void Reset_Log_Methods()
        {
            Log.Methods.Reinitialize();
        }

        [TestMethod]
        public void CORE_Test_Info_Log()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Info.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Info.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            Log.Info("Testing the {0} log", "info");

            Assert.IsNotNull(fullMsg, "Log.Methods.Info.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Info.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Info.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Info_Log", logDetails.Method, "We did not receive CORE_Test_Info_Log as the method!");
        }

        [TestMethod]
        public void CORE_Test_Debug_Log()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Debug.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Debug.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            Log.Debug("Testing the {0} log", "debug");

            Assert.IsNotNull(fullMsg, "Log.Methods.Debug.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Debug.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Debug.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Debug_Log", logDetails.Method, "We did not receive the right method!");
        }

        [TestMethod]
        public void CORE_Test_Warning_Log()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Warn.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Warn.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            Log.Warn("Testing the {0} log", "warn");

            Assert.IsNotNull(fullMsg, "Log.Methods.Warn.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Warn.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Warn.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Warning_Log", logDetails.Method, "We did not receive the right method!");
        }

        [TestMethod]
        public void CORE_Test_Error_Log()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Error.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Error.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            Log.Error("Testing the {0} log", "error");

            Assert.IsNotNull(fullMsg, "Log.Methods.Error.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Error.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Error.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Error_Log", logDetails.Method, "We did not receive the right method!");
        }

        [TestMethod]
        public void CORE_Test_Message_Log()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Message.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Message.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            Log.Message("Testing the {0} log", "message");

            Assert.IsNotNull(fullMsg, "Log.Methods.Message.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Message.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Message.FullMethod did not pass a LogDetails object");
            Assert.IsTrue(fullMsg[0] == 'T', "The first character of the message log was not T from \"Testing\", seems like the message perhaps has the details prepended?");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Message_Log", logDetails.Method, "We did not receive the right method!");
        }




        [TestMethod]
        public void CORE_Test_Info_Passthrough()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Info.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Info.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            CORE_Test_Info_Supplemental();

            Assert.IsNotNull(fullMsg, "Log.Methods.Info.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Info.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Info.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Info_Passthrough", logDetails.Method, "We did not receive CORE_Test_Info_Log as the method!");
        }
        public void CORE_Test_Info_Supplemental()
        {
            Log.Info(1, "Testing the {0} log", "info");
        }


        [TestMethod]
        public void CORE_Test_Debug_Passthrough()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Debug.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Debug.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            CORE_Test_Debug_Supplemental();

            Assert.IsNotNull(fullMsg, "Log.Methods.Debug.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Debug.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Debug.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Debug_Passthrough", logDetails.Method, "We did not receive the right method!");
        }
        public void CORE_Test_Debug_Supplemental()
        {
            Log.Debug(1, "Testing the {0} log", "debug");
        }


        [TestMethod]
        public void CORE_Test_Warning_Passthrough()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Warn.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Warn.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            CORE_Test_Warning_Supplemental();

            Assert.IsNotNull(fullMsg, "Log.Methods.Warn.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Warn.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Warn.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Warning_Passthrough", logDetails.Method, "We did not receive the right method!");
        }
        private void CORE_Test_Warning_Supplemental()
        {
            Log.Warn(1, "Testing the {0} log", "warn");
        }


        [TestMethod]
        public void CORE_Test_Error_Passthrough()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Error.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Error.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            CORE_Test_Error_Supplemental();

            Assert.IsNotNull(fullMsg, "Log.Methods.Error.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Error.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Error.FullMethod did not pass a LogDetails object");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Error_Passthrough", logDetails.Method, "We did not receive the right method!");
        }
        private void CORE_Test_Error_Supplemental()
        {
            Log.Error(1, "Testing the {0}", "error");
        }


        [TestMethod]
        public void CORE_Test_Message_Passthrough()
        {
            string fullMsg = null;
            string msg = null;
            LogDetails logDetails = null;

            Log.Methods.Message.StringMethod = (message) =>
            {
                fullMsg = message;
            };

            Log.Methods.Message.FullMethod = (message, details) =>
            {
                msg = message;
                logDetails = details;
            };

            CORE_Test_Message_Supplemental();

            Assert.IsNotNull(fullMsg, "Log.Methods.Message.StringMethod did not populate");
            Assert.IsNotNull(msg, "Log.Methods.Message.FullMethod did not pass a message");
            Assert.IsNotNull(logDetails, "Log.Methods.Message.FullMethod did not pass a LogDetails object");
            Assert.IsTrue(fullMsg[0] == 'T', "The first character of the message log was not T from \"Testing\", seems like the message perhaps has the details prepended?");
            Assert.AreEqual("CoreLogTests", logDetails.Class, "We did not receive CoreLogTests as the class!");
            Assert.AreEqual("CORE_Test_Message_Passthrough", logDetails.Method, "We did not receive the right method!");
        }
        private void CORE_Test_Message_Supplemental()
        {
            Log.Message(1, "Testing the {0} log", "message");
        }
    }
}
