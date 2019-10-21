using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Protobuf;
using Pb;

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
        AppDebug.Log("message length:"+ newBuffer.Length);
        byte[] newData = null; //newBuffer.length + id + data
        using (AppMemoryStream ms = new AppMemoryStream())
        {
            ms.WriteUShort((ushort)(newBuffer.Length));
            ms.Write(newBuffer, 0, newBuffer.Length);
            newData = ms.ToArray();
        }
        return newData;
    }

    public void SendMessage(IMessage obj)
    {

        if (!MessageDefine.ContainProtoType(obj.GetType()))
        {
            AppDebug.Log("协议不存在："+ obj.GetType().ToString());
            return;
        }
        
        Message msg = new Message();
        
        //set header
        msg.Header = new Header();

        //set body
        {
            byte[] messageBody = obj.ToByteArray();
            byte[] body = new byte[2 + messageBody.Length];
            using (AppMemoryStream ms = new AppMemoryStream())
            {
                int id = MessageDefine.GetProtoIdByProtoType(obj.GetType());
                ms.WriteUShort((ushort)(id));
                ms.Write(messageBody, 0, messageBody.Length);
                body = ms.ToArray();
            }
            msg.Body = ByteString.CopyFrom(body);
        }

        //发送消息
        int protoId = MessageDefine.GetProtoIdByProtoType(msg.GetType());
        SocketClient.Instance.SendMessage(protoId, msg.ToByteArray());
    }
    
}
