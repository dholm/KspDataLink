using System;
using System.Collections.Generic;

using UnityEngine;

namespace KspDataLink
{
    interface IVesselObserver
    {
        void OnActiveVesselChange(Vessel activeVessel);
    }

    interface ITargetObserver
    {
        void OnActiveTargetChange(ITargetable activeTarget);
    }

    public class FlightGlobalsMonitor
    {
        private List<IVesselObserver> vesselObserverList;
        private List<ITargetObserver> targetObserverList;
        private ITargetable           activeTarget;
        private Vessel                activeVessel;

        public FlightGlobalsMonitor()
        {
            vesselObserverList = new List<IVesselObserver>();
            targetObserverList = new List<ITargetObserver>();
        }

        private void OnActiveVesselChange(Vessel activeVessel)
        {
            Logger.debug("Active vessel changed from {0} to {1}..",
                         this.activeVessel ? this.activeVessel.GetName() : "None",
                         activeVessel.GetName());

            foreach (IVesselObserver observer in vesselObserverList)
            {
                observer.OnActiveVesselChange(activeVessel);
            }

            this.activeVessel = activeVessel;
        }

        private void OnActiveTargetChange(ITargetable activeTarget)
        {
            Logger.debug("Active target changed from {0} to {1}..",
                         this.activeTarget != null ? this.activeTarget.GetName() : "None",
                         activeTarget.GetName());

            foreach (ITargetObserver observer in targetObserverList)
            {
                observer.OnActiveTargetChange(activeTarget);
            }

            this.activeTarget = activeTarget;
        }

        public void Update(Vessel activeVessel, FlightGlobals flightGlobals)
        {
            ITargetable activeTarget = flightGlobals.VesselTarget;

            if (this.activeVessel != activeVessel)
            {
                this.OnActiveVesselChange(activeVessel);
            }

            if (this.activeTarget != activeTarget)
            {
                this.OnActiveTargetChange(activeTarget);
            }
        }
    }
}
