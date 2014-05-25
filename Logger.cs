using System;

using UnityEngine;

namespace KspDataLink
{
    public class Logger
    {
        private static void log(String level, String format,
                                params object[] args)
        {
            String message = String.Format(format, args);
            String logStr = String.Format("[{0} {1}] {2}", DataLink.Name, level,
                                          message);
            Console.WriteLine(logStr);
            UnityEngine.Debug.Log(logStr);
        }

        public static void debug(String format, params object[] args)
        {
#if (DEBUG)
            Logger.log("Debug", format, args);
#endif
        }

        public static void info(String format, params object[] args)
        {
            Logger.log("Info", format, args);
        }

        public static void warning(String format, params object[] args)
        {
            Logger.log("Warning", format, args);
        }

        public static void error(String format, params object[] args)
        {
            Logger.log("Error", format, args);
        }
    }
}