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
        public override void OnAwake()
        {
            Logger.debug("Waking up..");

            dataLink = new DataLink();
        }

        public override void OnUpdate()
        {
        }
#endregion
    }
}
