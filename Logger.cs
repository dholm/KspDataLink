using System;

using UnityEngine;

namespace RSpace
{
    public class Logger
    {
        private static void log(String level, String message)
        {
            String logStr = String.Format("[RSpace {0}] {1}", level, message);
            Console.WriteLine(logStr);
            UnityEngine.Debug.Log(logStr);
        }

        public static void debug(String message)
        {
#if (DEBUG)
            Logger.log("Debug", message);
#endif
        }

        public static void info(String message)
        {
            Logger.log("Info", message);
        }

        public static void warning(String message)
        {
            Logger.log("Warning", message);
        }

        public static void error(String message)
        {
            Logger.log("Error", message);
        }
    }
}