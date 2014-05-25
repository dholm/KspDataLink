using System;
using System.Collections.Generic;

using UnityEngine;

namespace KspDataLink
{
    interface IVesselObserver
    {
        void OnActiveVesselChange(Vessel activeVessel);
    }

    public class VesselMonitor
    {
        private List<IVesselObserver> observerList = new List<IVesselObserver>();
        private Vessel                activeVessel = null;

        private void OnActiveVesselChange(Vessel activeVessel)
        {
            Logger.debug("Active vessel changed from {0} to {1}..",
                         this.activeVessel ? this.activeVessel.GetName() : "None",
                         activeVessel.GetName());

            foreach (IVesselObserver observer in observerList)
            {
                observer.OnActiveVesselChange(activeVessel);
            }

            this.activeVessel = activeVessel;
        }

        public void UpdateActiveVessel(Vessel activeVessel)
        {
            if (this.activeVessel != activeVessel)
            {
                this.OnActiveVesselChange(activeVessel);
            }
        }
    }
}
