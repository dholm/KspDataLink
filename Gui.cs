using System;

using UnityEngine;

namespace KspDataLink
{
    public class Gui
    {
        private IButton toolbarButton = null;
        private bool    active        = false;
        private int     windowId      = 756876;
        private Vector2 windowSize    = new Vector2(280, 400);
        private Rect    windowPos     = new Rect(0, 60, 280, 400);

        private Configuration config = null;

        private void ToolbarInstall()
        {
            if (ToolbarManager.ToolbarAvailable)
            {
                Logger.debug("Installing toolbar..");

                toolbarButton = ToolbarManager.Instance.add(DataLink.Name,
                                                            DataLink.Name);
                string buttonOff = String.Format("{0}/Textures/{0}-off",
                                                 DataLink.Name);
                toolbarButton.TexturePath = buttonOff;
                toolbarButton.ToolTip     = String.Format("Open {0}",
                                                          DataLink.Name);

                toolbarButton.OnClick += (e) => Active = !Active;
            }
        }

        public Gui(Configuration config)
        {
            this.config = config;

            ToolbarInstall();
        }

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        public void OnGui()
        {
            if (Active)
            {
                GUI.skin = HighLogic.Skin;

                windowPos = GUILayout.Window(windowId, windowPos, LinkGui,
                                             "KSP Data Link Configuration");
            }
        }

        private GUIStyle CreateBackgroundStyle()
        {
            GUIStyle backgroundStyle = new GUIStyle(GUI.skin.box);

            backgroundStyle.hover  = backgroundStyle.normal;
            backgroundStyle.active = backgroundStyle.normal;

            return backgroundStyle;
        }

        private GUIStyle CreateButtonStyle()
        {
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

            buttonStyle.normal.textColor    = Color.white;
            buttonStyle.focused.textColor   = Color.white;
            buttonStyle.hover.textColor     = Color.yellow;
            buttonStyle.active.textColor    = Color.yellow;
            buttonStyle.onNormal.textColor  = Color.green;
            buttonStyle.onFocused.textColor = Color.green;
            buttonStyle.onHover.textColor   = Color.green;
            buttonStyle.onActive.textColor  = Color.green;
            buttonStyle.padding             = new RectOffset(4, 4, 4, 4);

            return buttonStyle;
        }

        private void LinkGui(int windowId)
        {
            GUIStyle backgroundStyle = CreateBackgroundStyle();
            GUIStyle buttonStyle     = CreateButtonStyle();

            GUILayout.BeginVertical(backgroundStyle);

            GUILayout.BeginHorizontal();
            GUILayout.Box("Data link connection settings..", backgroundStyle);
            GUILayout.EndHorizontal();
            GUILayout.Space(20);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Port: ");
            String port = GUILayout.TextField(String.Format("{0}", config.Port),
                                              GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Apply", buttonStyle, GUILayout.Width(150.0F),
                                 GUILayout.Height(25.0F)))
            {
                config.Port = Convert.ToUInt16(port);
            }
            GUILayout.EndVertical();

            GUI.DragWindow();
        }
    }
}
