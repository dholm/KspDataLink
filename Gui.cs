using System;

namespace KspDataLink
{
    class Gui
    {
        private IButton toolbarButton = null;

        private void ToolbarInstall()
        {
            if (ToolbarManager.ToolbarAvailable)
            {
                Logger.debug("Installing toolbar..");

                toolbarButton = ToolbarManager.Instance.add(DataLink.Name,
                                                            DataLink.Name);
                string buttonOff = String.Format("{0}/Textures/{0}_off",
                                                 DataLink.Name);
                toolbarButton.TexturePath = buttonOff;
                toolbarButton.ToolTip = String.Format("Open {0}",
                                                      DataLink.Name);
            }
        }

        public Gui()
        {
            ToolbarInstall();
        }
    }
}