using System.Collections.Generic;
namespace fantasy.e
{



    public class Event : Singleton<Event>
    {
        //网络消息回调
        public delegate void OnMessageHandler(byte[] buffer);

        private Dictionary<string, List<OnMessageHandler>> dic = new Dictionary<string, List<OnMessageHandler>>();

        public void AddListener(string key, OnMessageHandler handler)
        {
            List<OnMessageHandler> listHandler = null;

            if (dic.TryGetValue(key, out listHandler))
            {
                dic[key].Add(handler);
            }
            else
            {
                listHandler = new List<OnMessageHandler>();

                listHandler.Add(handler);

                dic[key] = listHandler;

            }
        }

        public void RemoveListener(string key, OnMessageHandler handler)
        {
            if (dic.ContainsKey(key))
            {
                List<OnMessageHandler> listHandler = dic[key];

                listHandler.Remove(handler);

                if (listHandler.Count == 0)
                {
                    dic.Remove(key);
                }
            }
        }

        public void Dispatch(string key, byte[] data)
        {
            List<OnMessageHandler> listHandler = null;

            if (dic.TryGetValue(key, out listHandler))
            {
                for (int i = 0; i < listHandler.Count; i++)
                {
                    listHandler[i]?.Invoke(data);
                }
            }
        }

        public override void Dispose()
        {
            dic.Clear();

            dic = null;

            base.Dispose();

        }

    }
}