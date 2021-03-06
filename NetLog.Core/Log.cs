﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    public static class Log
    {
        public static class Methods
        {
            #region Error Methods
            public static LogMethodGroup Error = new LogMethodGroup();
            #endregion

            #region Warn Methods
            public static LogMethodGroup Warn = new LogMethodGroup();
            #endregion

            #region Info Methods
            public static LogMethodGroup Info = new LogMethodGroup();
            #endregion

            #region Debug Methods
            public static LogMethodGroup Debug = new LogMethodGroup();
            #endregion

            #region Message Methods
            public static LogMethodGroup Message = new LogMethodGroup();
            #endregion

            internal static void Reinitialize()
            {
                Error = new LogMethodGroup();
                Warn = new LogMethodGroup();
                Info = new LogMethodGroup();
                Debug = new LogMethodGroup();
                Message = new LogMethodGroup();
            }
        }



        /// <summary>
        /// Log an error.
        /// </summary>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Error(string format, params object[] args)
        {
            Error(1, format, args);
        }

        /// <summary>
        /// Log an error.
        /// </summary>
        /// <param name="offset">Additional offset to look for class/method.</param>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Error(int offset, string format, params object[] args)
        {
            LogMessage(offset, LogType.Error, format, args);
        }



        /// <summary>
        /// Log a Warning.
        /// </summary>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Warn(string format, params object[] args)
        {
            Warn(1, format, args);
        }

        /// <summary>
        /// Log a Warning.
        /// </summary>
        /// <param name="offset">Additional offset to get class/method</param>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Warn(int offset, string format, params object[] args)
        {
            LogMessage(offset, LogType.Warn, format, args);
        }



        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Info(string format, params object[] args)
        {
            Info(1, format, args);
        }

        /// <summary>
        /// Log Information
        /// </summary>
        /// <param name="offset">Additional offset to look for class/method</param>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Info(int offset, string format, params object[] args)
        {
            LogMessage(offset, LogType.Info, format, args);
        }



        /// <summary>
        /// Log a Debug value.
        /// </summary>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Debug(string format, params object[] args)
        {
            Debug(1, format, args);
        }

        /// <summary>
        /// Log a Debug value.
        /// </summary>
        /// <param name="offset">Additional offset to look for class/method</param>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Debug(int offset, string format, params object[] args)
        {
            LogMessage(offset, LogType.Debug, format, args);
        }



        /// <summary>
        /// Log a Message.
        /// </summary>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Message(string format, params object[] args)
        {
            Message(1, format, args);
        }

        /// <summary>
        /// Log a Message.
        /// </summary>
        /// <param name="offset">Additional offset for finding class/method</param>
        /// <param name="format">Format of the message.</param>
        /// <param name="args">Additional parameters to include.</param>
        public static void Message(int offset, string format, params object[] args)
        {
            LogMessage(offset, LogType.Message, format, args);
        }



        private static void LogMessage(int offset, LogType type, string format, params object[] args)
        {
            LogDetails details = GetLogDetails(2 + offset, type);
            string message = string.Format(format, args);
            LogMethodGroup group = GetMethodGroup(type);
            group.ExecuteMethod(type, message, details);
        }

        private static LogDetails GetLogDetails(int offset, LogType type)
        {
            StackFrame sf = new StackFrame(1 + offset, true);
            LogDetails retVal = new LogDetails();

            string className = sf.GetMethod().DeclaringType.Name;
            string methodName = sf.GetMethod().Name;
            string fileName = sf.GetFileName();
            string nameSpace = sf.GetMethod().DeclaringType.Namespace;
            int lineNumber = sf.GetFileLineNumber();

            return new LogDetails
            {
                Class = className,
                Method = methodName,
                File = fileName,
                LineNumber = lineNumber,
                Namespace = nameSpace,
                LogType = type
            };
        }

        private static LogMethodGroup GetMethodGroup(this LogType type)
        {
            switch (type)
            {
                case LogType.Debug:
                    return Methods.Debug;
                case LogType.Error:
                    return Methods.Error;
                case LogType.Info:
                    return Methods.Info;
                case LogType.Message:
                    return Methods.Message;
                case LogType.Warn:
                    return Methods.Warn;
            }

            return null;
        }

        


    }
}
