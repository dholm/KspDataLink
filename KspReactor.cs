using System;
using System.IO;

using UnityEngine;

namespace KspDataLink
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    public class SpaceCenterReactor : KspReactor
    {
    }

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

        private static void Destroy()
        {
            if (instance != null)
            {
                Logger.debug("Destroying reactor instance..");

                GameObject.Destroy(instance);
                instance = null;
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

        public void OnDestroy()
        {
            Destroy();
        }

        public void Start()
        {
            Logger.debug("Starting {0}..", GetType().Name);
        }

        public void Update()
        {
            if (FlightGlobals.fetch != null)
            {
                var flightGlobalsMonitor = dataLink.FlightGlobalsMonitor;

                flightGlobalsMonitor.Update(FlightGlobals.ActiveVessel,
                                            FlightGlobals.fetch);
            }
        }

        public void OnGUI()
        {
            dataLink.Gui.OnGui();
        }
#endregion
    }
}
