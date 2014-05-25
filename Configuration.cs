using System;

namespace KspDataLink
{
    public class Configuration
    {
        private ushort port = 9090;

        public ushort Port
        {
            get
            {
                return port;
            }
            set
            {
                if (port != value)
                {
                    Logger.debug("Changing port from {0} to {1}.",
                                 port, value);
                    port = value;
                }
            }
        }
    }
}