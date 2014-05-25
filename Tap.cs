using System;
using System.Collections.Generic;

using UnityEngine;

namespace KspDataLink
{
    public class Tap
    {
        private PartReactor partReactor;
        private List<ITap>  tapList;

        public Tap(PartReactor partReactor)
        {
            this.partReactor = partReactor;
        }

        private void RegisterTaps()
        {
            if (this.partReactor.vessel)
            {
                tapList.Add(new VesselTap(this.partReactor.vessel));
            }
        }
    }
}
