using System;

namespace KspDataLink
{
    public class DataLink
    {
        public static String Name = "KspDataLink";

        private Configuration        config;
        private Gui                  gui;
        private FlightGlobalsMonitor flightGlobalsMonitor;
        private UdpPortMonitor       udpPortMonitor;

        public DataLink()
        {
            Logger.debug("Creating DataLink..");

            config               = new Configuration();
            gui                  = new Gui(config);
            flightGlobalsMonitor = new FlightGlobalsMonitor();
            udpPortMonitor       = new UdpPortMonitor(config.Port);
        }

        public void Destroy()
        {
            udpPortMonitor.Destroy();
        }

        public Gui Gui
        {
            get
            {
                return gui;
            }
        }

        public UdpPortMonitor UdpPortMonitor
        {
            get
            {
                return udpPortMonitor;
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