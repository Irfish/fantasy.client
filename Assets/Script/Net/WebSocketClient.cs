using System.Collections.Generic;
using System;
using BestHTTP.WebSocket;
namespace fantasy.net
{

    public class WebSocketClient : SingletonMono<WebSocketClient>
    {
        //返送队列
        private Queue<byte[]> m_SendQueue = new Queue<byte[]>();
        //接受队列
        private Queue<byte[]> m_ReceiveQueue = new Queue<byte[]>();

        //检查发送队列委托
        private Action m_CheckSendQueneAction;

        private WebSocket m_Ws;

        private bool m_connected;

        private int m_ReceiveCount = 0;

        protected override void OnAwake()
        {
            base.OnAwake();

            m_Ws = new WebSocket(new Uri(AppDefine.WSAddr));

            m_Ws.StartPingThread = true;

            m_Ws.OnOpen += OnOpen;

            m_Ws.OnBinary += OnBinary;

            m_Ws.OnError += OnError;

            m_Ws.OnClosed += OnClosed;
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void BeforeOnDestroy()
        {
            base.BeforeOnDestroy();

            if (m_Ws != null && m_Ws.IsOpen)
            {
                m_Ws.Close();
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (m_connected == false) return;

            while (true)
            {
                if (m_ReceiveCount <= 5)//没帧值取五条
                {
                    m_ReceiveCount++;

                    if (m_ReceiveQueue.Count > 0)
                    {
                        byte[] data = m_ReceiveQueue.Dequeue();

                        AppDebug.Log("websocket recieved a message:");

                        Parser.DecodeMessage(data);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    m_ReceiveCount = 0;

                    break;
                }
            }
        }

        public void WsConnect()
        {
            if (m_Ws != null && m_Ws.IsOpen) return;

            m_Ws.Open();

        }

        private void OnOpen(WebSocket ws)
        {
            AppDebug.Log("ws:OnOpen ");

            m_CheckSendQueneAction = CheckSendQueue;

            m_connected = true;

        }

        private void OnBinary(WebSocket ws, byte[] data)
        {
            AppDebug.Log("ws:OnBinary ");

            lock (m_ReceiveQueue)
            {
                m_ReceiveQueue.Enqueue(data);
            }
        }

        private void OnError(WebSocket ws, Exception e)
        {
            if (e == null) return;

            AppDebug.Log("ws:OnBinary " + e.ToString());

        }

        private void OnClosed(WebSocket ws, UInt16 code, string msg)
        {
            AppDebug.Log("ws:OnClosed ");

            m_connected = false;

            m_SendQueue.Clear();

            m_ReceiveQueue.Clear();

            m_SendQueue = null;

            m_ReceiveQueue = null;

            m_Ws = null;

            m_CheckSendQueneAction = null;

        }

        public void SendMessage(int messageId, byte[] data)
        {
            byte[] msg = Parser.EncodeMassage(messageId, data);

            lock (m_SendQueue)
            {
                m_SendQueue.Enqueue(msg);

                if (m_CheckSendQueneAction == null) return;

                m_CheckSendQueneAction.BeginInvoke(null, null);

            }
        }

        private void CheckSendQueue()
        {
            lock (m_SendQueue)
            {
                if (m_SendQueue.Count != 0)
                {
                    m_Ws.Send(m_SendQueue.Dequeue());
                }
            }
        }

    }
}