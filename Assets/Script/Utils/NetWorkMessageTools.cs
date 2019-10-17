using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkMessageTools : Singleton<NetWorkMessageTools>
{
    public byte[] EncodeMassage(int id, byte[] data)
    {
        
        byte[] newBuffer = null; //id + data
        using (AppMemoryStream ms = new AppMemoryStream())
        {
            ms.WriteUShort((ushort)id);
            ms.Write(data, 0, data.Length);
            newBuffer = ms.ToArray();
        }

        byte[] newData = null; //newBuffer.length + newBuffer
        using (AppMemoryStream ms = new AppMemoryStream())
        {
            ms.WriteUShort((ushort)(newBuffer.Length));
            ms.Write(newBuffer, 0, newBuffer.Length);
            newData = ms.ToArray();
        }
        return newData;
    }

    public void DecodeMessage(byte[] inData, out int id, out byte[] outData)
    {
        id = 0;
        outData = null;
        using (AppMemoryStream ms = new AppMemoryStream(inData))
        {
            id = ms.ReadUShort();
            ms.Read(outData, 0, outData.Length);
        }
        return;
    }
    
}
