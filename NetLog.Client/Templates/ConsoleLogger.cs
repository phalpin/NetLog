using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLog.Core;

namespace NetLog.Client.Templates
{

    public static class ConsoleLogger
    {

        public static class Options
        {
            public static bool UseColor { get; set; }
            public static ConsoleColor DebugColor { get; set; }
            public static ConsoleColor WarningColor { get; set; }
            public static ConsoleColor InfoColor { get; set; }
            public static ConsoleColor MessageColor { get; set; }
            public static ConsoleColor ErrorColor { get; set; }
        }

        public static void Initialize()
        {
            Options.DebugColor = ConsoleColor.Cyan;
            Options.WarningColor = ConsoleColor.Yellow;
            Options.InfoColor = ConsoleColor.Gray;
            Options.MessageColor = ConsoleColor.White;
            Options.ErrorColor = ConsoleColor.Red;

            Log.Methods.Debug.StringMethod = (message) =>
            {
                DoLog(message, LogType.Debug);
            };

            Log.Methods.Error.StringMethod = (message) =>
            {
                DoLog(message, LogType.Error);
            };

            Log.Methods.Info.StringMethod = (message) =>
            {
                DoLog(message, LogType.Info);
            };

            Log.Methods.Message.StringMethod = (message) =>
            {
                DoLog(message, LogType.Message);
            };

            Log.Methods.Warn.StringMethod = (message) =>
            {
                DoLog(message, LogType.Warn);
            };
        }

        private static void DoLog(string message, LogType type)
        {
            var oldColor = SetColor(type);
            Console.WriteLine(message);
            SetColor(oldColor);
        }

        private static ConsoleColor GetColorForType(this LogType type)
        {
            switch (type)
            {
                case LogType.Debug:
                    return Options.DebugColor;
                case LogType.Error:
                    return Options.ErrorColor;
                case LogType.Info:
                    return Options.InfoColor;
                case LogType.Message:
                    return Options.MessageColor;
                case LogType.Warn:
                    return Options.WarningColor;
            }

            return default(ConsoleColor);
        }

        private static ConsoleColor SetColor(LogType type)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            if (Options.UseColor)
            {
                Console.ForegroundColor = type.GetColorForType();
            }
            return oldColor;
        }

        private static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
