using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Net;
namespace fantasy.net
{
    /// <summary>
    /// tcp
    /// </summary>
    public class SocketClient : SingletonMono<SocketClient>
    {
        //返送队列
        private Queue<byte[]> m_SendQueue = new Queue<byte[]>();
        //接受队列
        private Queue<byte[]> m_ReceiveQueue = new Queue<byte[]>();

        private byte[] m_ReceiveBuffer = new byte[1024];

        //检查发送队列委托
        private Action m_CheckSendQueneAction;

        private bool m_conected;

        private Socket m_client;

        private bool m_IsConnected;

        private AppMemoryStream m_MemoryStream = new AppMemoryStream();

        public Action OnConnected;

        private int m_ReceiveCount = 0;

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (m_IsConnected)
            {
                m_IsConnected = false;

                OnConnected?.Invoke();

                AppDebug.Log("conect sucssecd !");

            }

            while (true)
            {
                if (m_ReceiveCount <= 5)//没帧值取五条
                {
                    m_ReceiveCount++;

                    if (m_ReceiveQueue.Count > 0)
                    {
                        byte[] data = m_ReceiveQueue.Dequeue();

                        AppDebug.Log("socket recieved a message:");

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

        protected override void BeforeOnDestroy()
        {
            base.BeforeOnDestroy();

            DisConnect();

            m_SendQueue.Clear();

            m_ReceiveQueue.Clear();

            m_SendQueue = null;

            m_ReceiveQueue = null;

            m_client = null;

            m_CheckSendQueneAction = null;
        }

        public void Connecte(string ip, int port)
        {
            if (m_client != null && m_client.Connected) return;

            m_client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                m_client.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), port), ConectCallBack, m_client);
            }
            catch (Exception e)
            {
                AppDebug.Log(StringTools.Instance.Add("socket conect failed e:").Add(e.ToString()).ToString());
            }
        }

        private void ConectCallBack(IAsyncResult iAs)
        {
            if (m_client.Connected)
            {
                AppDebug.Log("socket conect sucssecd ");

                m_CheckSendQueneAction = CheckSendQueue;

                ReceiveMessage();

                m_IsConnected = true;

                fantasy.e.Event.Instance.Dispatch("OnTcpConnected", null);

            }
            else
            {
                AppDebug.Log("socket conect failed ");
            }

            m_client.EndConnect(iAs);

        }

        public void DisConnect()
        {
            if (m_client != null && m_client.Connected)
            {
                m_client.Shutdown(SocketShutdown.Both);

                m_client.Close();
            }
        }

        private void Send(byte[] buffer)
        {
            m_client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, m_client);
        }

        private void SendCallBack(IAsyncResult iAs)
        {
            m_client.EndSend(iAs);

            CheckSendQueue();
        }
        //检查发送队列
        private void CheckSendQueue()
        {
            lock (m_SendQueue)
            {
                if (m_SendQueue.Count != 0)
                {
                    Send(m_SendQueue.Dequeue());
                }
            }
        }

        //发送
        public void SendMessage(int messageId, byte[] buffer)
        {

            byte[] sendBuffer = Parser.EncodeMassage(messageId, buffer);

            lock (m_SendQueue)
            {
                m_SendQueue.Enqueue(sendBuffer);

                if (m_CheckSendQueneAction == null) return;
                //执行委托
                m_CheckSendQueneAction.BeginInvoke(null, null);
            }

        }

        private void ReceiveMessage()
        {
            m_client.BeginReceive(m_ReceiveBuffer, 0, m_ReceiveBuffer.Length, SocketFlags.None, ReceiveCallBack, m_client);
        }

        private void ReceiveCallBack(IAsyncResult iAs)
        {
            try
            {
                int len = m_client.EndReceive(iAs);

                if (len > 0)
                {
                    m_MemoryStream.Position = m_MemoryStream.Length;

                    m_MemoryStream.Write(m_ReceiveBuffer, 0, len);
                    //包头长度=2
                    if (m_MemoryStream.Length > 2)
                    {
                        while (true)
                        {
                            m_MemoryStream.Position = 0;
                            //包体长度
                            int currentMessageBodyLen = m_MemoryStream.ReadUShort();
                            //总包的长度 = 包头长度 + 包体长度
                            int currentMessageLen = 2 + currentMessageBodyLen;

                            if (m_MemoryStream.Length >= currentMessageLen)
                            {
                                byte[] body = new byte[currentMessageBodyLen];

                                m_MemoryStream.Position = 2;

                                m_MemoryStream.Read(body, 0, currentMessageBodyLen);

                                lock (m_ReceiveQueue)
                                {
                                    m_ReceiveQueue.Enqueue(body);
                                }

                                int remainLen = (int)m_MemoryStream.Length - currentMessageLen;

                                if (remainLen > 0)
                                {
                                    //将指针指向第一个包的尾部 （即剩余包的头部）
                                    m_MemoryStream.Position = currentMessageLen;

                                    byte[] remainBuffer = new byte[remainLen];
                                    //读取剩余字节数组
                                    m_MemoryStream.Read(remainBuffer, 0, remainLen);
                                    //清空数据流
                                    m_MemoryStream.Position = 0;

                                    m_MemoryStream.SetLength(0);
                                    //保存剩余的数据
                                    m_MemoryStream.Write(remainBuffer, 0, remainBuffer.Length);

                                    remainBuffer = null;
                                }
                                else
                                {
                                    //清空数据流
                                    m_MemoryStream.Position = 0;

                                    m_MemoryStream.SetLength(0);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        AppDebug.Log("socket disconnecte");
                    }

                    ReceiveMessage();

                }
                else
                {
                    AppDebug.Log("socket disconnecte");
                }

            }
            catch (Exception e)
            {
                StringTools.Instance.Add("socket disconnecte e:").Add(e.ToString()).ToString();
            }
        }



    }
}