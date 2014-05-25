using System;
using System.IO;

using UnityEngine;

namespace KspDataLink
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class FlightReactor : KspReactor
    {
    }

    public partial class KspReactor : InternalModule
    {
        protected DataLink dataLink;

#region Events
        public void Start()
        {
            Logger.debug("Starting up..");

            DontDestroyOnLoad(this);

            dataLink = new DataLink();
        }

        public void Awake()
        {
            Logger.debug("Waking up..");
        }

        public void OnDestroy()
        {
            Logger.debug("Shutting down..");
        }

        public void Update()
        {
        }
#endregion
    }
}
