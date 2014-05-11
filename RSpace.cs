using System;

using UnityEngine;
using KSP;

namespace RSpace
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class RSpaceFlight : RSpace
    {
        public override string MonoName
        {
            get
                {
                    return this.name;
                }
        }
    }

    public partial class RSpace : MonoBehaviour
    {
        public virtual String MonoName
        {
            get;
            set;
        }

        public RSpace()
        {
        }

#region Events
        public void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void OnDestroy()
        {
        }

        public void Update()
        {
        }
#endregion
    }
}
