using System;

namespace KspDataLink
{
    public class DataLink
    {
        public static String Name = "KspDataLink";

        private Configuration config;
        private Gui           gui;
        private VesselMonitor vesselMonitor;

        public DataLink()
        {
            Logger.debug("Creating DataLink..");

            config        = new Configuration();
            gui           = new Gui(config);
            vesselMonitor = new VesselMonitor();
        }

        public Gui Gui
        {
            get
            {
                return gui;
            }
        }

        public VesselMonitor VesselMonitor
        {
            get
            {
                return vesselMonitor;
            }
        }
    }
}