using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using Pb;
using Google.Protobuf;

namespace LuaFramework {
    public class NetworkManager : Manager {
        private MSocketClient socket;
        static readonly object m_lockObject = new object();
        static Queue<KeyValuePair<int, ByteBuffer>> mEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

        MSocketClient SocketClient {
            get { 
                if (socket == null)
                    socket = new MSocketClient();
                return socket;                    
            }
        }

        void Awake() {
            Init();
        }

        void Init() {
            SocketClient.OnRegister();
        }

        public void OnInit() {
            CallMethod("Start");
        }

        public void Unload() {
            CallMethod("Unload");
        }

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        public object[] CallMethod(string func, params object[] args) {
            return Util.CallMethod("Network", func, args);
        }

        ///------------------------------------------------------------------------------------
        public static void AddEvent(int _event, ByteBuffer data) {
            lock (m_lockObject) {
                mEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
            }
        }

        /// <summary>
        /// 交给Command，这里不想关心发给谁。
        /// </summary>
        void Update() {
            if (mEvents.Count > 0) {
                while (mEvents.Count > 0) {
                    KeyValuePair<int, ByteBuffer> _event = mEvents.Dequeue();
                    facade.SendMessageCommand(NotiConst.DISPATCH_MESSAGE, _event);
                }
            }
        }

        /// <summary>
        /// 发送链接请求
        /// </summary>
        public void SendConnect() {
            SocketClient.SendConnect();
        }

        /// <summary>
        /// 发送SOCKET消息
        /// </summary>
        public void SendMessage(ByteBuffer buffer)
        {
            SocketClient.SendMessage(buffer);
        }


        public void SendToGw(ByteBuffer buffer,int msgId)
        {
            Header h = new Header();

            h.ServiceId0 = (int)SERVICE.Gw;

            ByteBuffer readBuffer = new ByteBuffer(buffer.ToBytes());
            
            SendToService(h, readBuffer.ReadBytes(), msgId);

            buffer.Close();

            readBuffer.Close();

        }

        public void SendToGame(ByteBuffer buffer, int msgId)
        {
            Header h = new Header();

            h.ServiceId0 = (int)SERVICE.G001;

            ByteBuffer readBuffer = new ByteBuffer(buffer.ToBytes());

            SendToService(h, readBuffer.ReadBytes(), msgId);

            buffer.Close();

            readBuffer.Close();
        }

        private void SendToService(Header header, byte[] data,int msgId)
        {
            header.SessionId = long.Parse(PlayerPrefs.GetString("SessionId","0"));

            Debug.Log("header.SessionId:"+header.SessionId);

            header.UserId = PlayerPrefs.GetInt("UserId");

            header.Token = PlayerPrefs.GetString("Token");

            header.TokenExpiredTime = PlayerPrefs.GetInt("TokenExpireTime");

            header.Id = msgId;

            Pb.Message msg = new Pb.Message();

            msg.Header = header;

            {//set body
                byte[] bodyData = data;

                byte[] body = new byte[2 + bodyData.Length];

                using (AppMemoryStream ms = new AppMemoryStream())
                {
                    ms.WriteUShort((ushort)(msgId));

                    ms.Write(bodyData, 0, bodyData.Length);

                    body = ms.ToArray();
                }

                msg.Body = ByteString.CopyFrom(body);
            }

            //发送消息
            int protoId = MessageDefine.GetProtoIdByProtoType(msg.GetType());

            SocketClient.SendMsg(protoId, msg.ToByteArray());
        }


        /// <summary>
        /// 析构函数
        /// </summary>
        new void OnDestroy() {
            SocketClient.OnRemove();
            Debug.Log("~NetworkManager was destroy");
        }
    }
}