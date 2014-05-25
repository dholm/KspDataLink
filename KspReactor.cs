using System;
using System.IO;

using UnityEngine;

namespace KspDataLink
{
    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    public class EditorReactor : KspReactor
    {
    }

    [KSPAddon(KSPAddon.Startup.TrackingStation, false)]
    public class TrackingStationReactor : KspReactor
    {
    }

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class FlightReactor : KspReactor
    {
    }

    public partial class KspReactor : MonoBehaviour
    {
        private static GameObject instance = null;
        private static DataLink   dataLink = null;

        private static void Create()
        {
            instance = GameObject.Find(DataLink.Name);
            if (instance == null)
            {
                Logger.debug("Creating reactor instance..");

                dataLink = new DataLink();
                instance = new GameObject(DataLink.Name, typeof(KspReactor));
            }
        }

        public static GameObject Instance
        {
            get
            {
                if (instance == null)
                {
                    Create();
                }

                return instance;
            }
        }

#region Events
        public void Awake()
        {
            DontDestroyOnLoad(this);

            Create();
        }

        public void Start()
        {
            Logger.debug("Starting {0}..", GetType().Name);
        }

        public void OnDestroy()
        {
            Logger.debug("Shutting down {0}..", GetType().Name);
        }

        public void Update()
        {
            if (FlightGlobals.fetch != null)
            {
                VesselMonitor vesselMonitor = dataLink.VesselMonitor;
                Vessel        activeVessel  = FlightGlobals.ActiveVessel;

                vesselMonitor.UpdateActiveVessel(activeVessel);
            }
        }
#endregion
    }
}
