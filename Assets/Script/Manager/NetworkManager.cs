using Google.Protobuf;
using Pb;


public class NetworkManager : Singleton<NetworkManager>
{
    public void SendToGw(IMessage obj)
    {
        if (!MessageDefine.ContainProtoType(obj.GetType()))
        {
            AppDebug.Log("协议不存在：" + obj.GetType().ToString());

            return;
        }

        Header h = new Header();

        h.ServiceId0 = (int)SERVICE.Gw;

        SendToService(h, obj);

    }

    public void SendToGame(IMessage obj)
    {
        if (!MessageDefine.ContainProtoType(obj.GetType()))
        {
            AppDebug.Log("协议不存在：" + obj.GetType().ToString());

            return;
        }
        Header h = new Header();

        h.ServiceId0 = (int)SERVICE.G001;

        SendToService(h, obj);

    }

    private void SendToService(Header header, IMessage obj)
    {
        Player p = UserManager.Instance.GetPlayer();

        if (p.UserId == 0)
        {
            AppDebug.Log("无法获取玩家信息，请重新登陆!");

            return;
        }

        header.UserId = p.UserId;

        header.Token = p.Token;

        header.TokenExpiredTime = p.TokenExpireTime;

        Message msg = new Message();

        msg.Header = header;

        {//set body
            byte[] bodyData = obj.ToByteArray();

            byte[] body = new byte[2 + bodyData.Length];

            using (AppMemoryStream ms = new AppMemoryStream())
            {
                int id = MessageDefine.GetProtoIdByProtoType(obj.GetType());

                ms.WriteUShort((ushort)(id));

                ms.Write(bodyData, 0, bodyData.Length);

                body = ms.ToArray();
            }

            msg.Body = ByteString.CopyFrom(body);
        }

        //发送消息
        int protoId = MessageDefine.GetProtoIdByProtoType(msg.GetType());

        SocketClient.Instance.SendMessage(protoId, msg.ToByteArray());

    }




}

