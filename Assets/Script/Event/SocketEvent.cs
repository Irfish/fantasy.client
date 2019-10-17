using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SocketEvent : Singleton<SocketEvent>
{
    //网络消息回调
    public delegate void OnMessageHandler(byte[] buffer);

    private Dictionary<ushort, List<OnMessageHandler>> dic = new Dictionary<ushort, List<OnMessageHandler>>();

    public void AddListener(ushort key, OnMessageHandler handler)
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

    public void RemoveListener(ushort key, OnMessageHandler handler)
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

    public void Dispatch(ushort key,byte[] data)
    {
        List<OnMessageHandler> listHandler = null;
        if (dic.TryGetValue(key, out listHandler))
        {
            for ( int i=0;i<listHandler.Count;i++)
            {
                if (listHandler[i] != null)
                {
                    listHandler[i](data);
                }
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
