using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

using UnityEngine;

namespace KspDataLink
{
    interface UdpPortObserver
    {
        void OnError(IPEndPoint ipEndPoint);
        void OnMessage(IPEndPoint ipEndPoint, byte[] message);
    }

    public class UdpPortMonitor
    {
        private UdpClient       listener;
        private IPEndPoint      ipEndPoint;
        private UdpPortObserver udpPortObserver;

        public UdpPortMonitor(ushort port)
        {
            listener   = new UdpClient(port);
            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public void Destroy()
        {
            listener.Close();
        }

        public void Update()
        {
            try
            {
                byte[] message = listener.Receive(ref ipEndPoint);
                udpPortObserver.OnMessage(ipEndPoint, message);
            }
            catch (Exception)
            {
                udpPortObserver.OnError(ipEndPoint);
            }
        }
    }
}
