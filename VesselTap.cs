using System;

using UnityEngine;

namespace KspDataLink
{
    public class VesselTap : ITap
    {
        private Vessel vessel;

        public VesselTap(Vessel vessel)
        {
            this.vessel = vessel;
        }
    }
}
