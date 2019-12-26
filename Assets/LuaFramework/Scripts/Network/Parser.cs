using System;
using Pb;
using Protobuf = Google.Protobuf;
using LuaFramework;

public class Parser
{

    public static byte[] EncodeMassage(int id, byte[] data)
    {

        byte[] newBuffer = null; //id + data

        using (AppMemoryStream ms = new AppMemoryStream())
        {
            ms.WriteUShort((ushort)id);

            ms.Write(data, 0, data.Length);

            newBuffer = ms.ToArray();
        }

        byte[] newData = null; //newBuffer.length + id + data

        using (AppMemoryStream ms = new AppMemoryStream())
        {
            ms.WriteUShort((ushort)(newBuffer.Length));

            ms.Write(newBuffer, 0, newBuffer.Length);

            newData = ms.ToArray();
        }

        return newData;
    }

    public static void DecodeMessage(byte[] data)
    {
        //解析收到的数据messge
        byte[] body = new byte[data.Length - 2];

        ushort protoCode = 0;

        using (AppMemoryStream ms = new AppMemoryStream(data))
        {
            protoCode = ms.ReadUShort();

            ms.Read(body, 0, body.Length);
        }

        Type protoType = MessageDefine.GetProtoTypeByProtoId(protoCode);

        Protobuf.MessageParser messageParser = MessageDefine.GetMessageParser(protoType.TypeHandle);

        object toc = messageParser.ParseFrom(body);

        Pb.Message msg = toc as Pb.Message;

        byte[] msgBody = msg.Body.ToByteArray();

        //解析messgeBody
        ushort msgId = 0;

        byte[] msgData = new byte[msgBody.Length - 2];

        using (AppMemoryStream ms1 = new AppMemoryStream(msgBody))
        {
            msgId = ms1.ReadUShort();

            ms1.Read(msgData, 0, msgData.Length);
        }

        ByteBuffer writer = new ByteBuffer();

        writer.WriteInt(msgId);

        writer.WriteInt(msgData.Length);

        writer.WriteBytes(msgData);

        ByteBuffer buffer = new ByteBuffer(writer.ToBytes());

        NetworkManager.AddEvent(Protocal.Message, buffer);

    }
}
