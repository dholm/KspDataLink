using System;
using System.IO;

using UnityEngine;

namespace KspDataLink
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class EditorReactor : KspReactor
    {
    }

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class FlightReactor : KspReactor
    {
    }

    [KSPAddon(KSPAddon.Startup.TrackingStation, false)]
    public class TrackingStationReactor : KspReactor
    {
    }

    public partial class KspReactor : InternalModule
    {
        private DataLink      dataLink      = null;
        private VesselMonitor vesselMonitor = null;

#region Events
        public override void OnAwake()
        {
            Logger.debug("Waking up..");

            dataLink = new DataLink();
            vesselMonitor = new VesselMonitor();
        }

        public override void OnUpdate()
        {
            if (FlightGlobals.fetch != null)
            {
                vesselMonitor.UpdateActiveVessel(FlightGlobals.ActiveVessel);
            }
        }
#endregion
    }
}
