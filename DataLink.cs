using System;

namespace KspDataLink
{
    public class DataLink
    {
        public static String Name = "KspDataLink";

        private Gui           gui;
        private VesselMonitor vesselMonitor;

        public DataLink()
        {
            Logger.debug("Creating DataLink..");

            gui           = new Gui();
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