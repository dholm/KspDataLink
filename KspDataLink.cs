using System;
using System.IO;
using System.Reflection;

using UnityEngine;

namespace KspDataLink
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class KspDataLinkFlight : KspDataLink
    {
    }

    public partial class KspDataLink : MonoBehaviour
    {
        private IButton toolbarButton = null;

        public static String Name
        {
            get
            {
                return MethodBase.GetCurrentMethod().DeclaringType.Name;
            }
        }

        public KspDataLink()
        {
        }

        public void ToolbarInstall()
        {
            if (ToolbarManager.ToolbarAvailable)
            {
                Logger.debug("Installing toolbar..");

                toolbarButton = ToolbarManager.Instance.add(Name, Name);
                string buttonOff = String.Format("{0}/Textures/{0}_off", Name);
                toolbarButton.TexturePath = buttonOff;
                toolbarButton.ToolTip = String.Format("Open {0}", Name);
            }
        }

#region Events
        public void Start()
        {
            Logger.debug("Starting up..");

            DontDestroyOnLoad(this);
            ToolbarInstall();
        }

        public void Awake()
        {
            Logger.debug("Waking up..");

            DontDestroyOnLoad(this);
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
