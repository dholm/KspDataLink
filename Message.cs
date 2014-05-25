using System;
using System.Runtime.InteropServices;

using UnityEngine;

namespace KspDataLink
{
    enum MessageType
    {
        CreateSession = 1,
        DeleteSession
    }

    public class Header<T>
    {
        public static T FromData(byte[] data)
        {
            GCHandle handle  = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr   address = handle.AddrOfPinnedObject();
            T        header  = (T)Marshal.PtrToStructure(address, typeof(T));

            handle.Free();
            return header;
        }
    }

    public class MessageHeader : Header<MessageHeader>
    {
        byte   version;
        byte   type;
        ushort length;
        uint   sessionId;
        uint   sequenceNumber;
    }
}
