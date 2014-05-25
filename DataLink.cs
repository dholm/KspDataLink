using System;

namespace KspDataLink
{
    public class DataLink
    {
        public static String Name = "KspDataLink";

        private Configuration        config;
        private Gui                  gui;
        private FlightGlobalsMonitor flightGlobalsMonitor;

        public DataLink()
        {
            Logger.debug("Creating DataLink..");

            config               = new Configuration();
            gui                  = new Gui(config);
            flightGlobalsMonitor = new FlightGlobalsMonitor();
        }

        public Gui Gui
        {
            get
            {
                return gui;
            }
        }

        public FlightGlobalsMonitor FlightGlobalsMonitor
        {
            get
            {
                return flightGlobalsMonitor;
            }
        }
    }
}