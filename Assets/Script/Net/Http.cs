using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;

public class Http:SingletonMono<Http>
{
    /// <summary>
    ///相应回调
    /// </summary>
    /// <param name="buffer"></param>
    public delegate void ResponseCallBack(byte[] data);
    private UnityWebRequest m_WebRequest;

    /// <summary>
    /// 发送post请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="callBack"></param>
    public void SendPost(string url, WWWForm form, ResponseCallBack callBack)
    {
        Uri uri = new Uri(url);
        m_WebRequest = UnityWebRequest.Post(uri, form);
        StartCoroutine(DoPost(callBack));
    }
    private IEnumerator DoPost(ResponseCallBack callBack)
    {
        yield return m_WebRequest.SendWebRequest();
        if (m_WebRequest.isNetworkError)
        {
            AppDebug.Log("http do post errot:");
        }
        else
        {
            AppDebug.Log(m_WebRequest.downloadHandler.text);
            byte[] result = m_WebRequest.downloadHandler.data;
            callBack(result);
        }
    }
    /// /// <summary>
    /// 发送get请求
    /// </summary>
    /// <param name="callBack"></param>
    /// <returns></returns>
    public void SendGet(string url, ResponseCallBack callBack)
    {
        Uri uri = new Uri(url);
        m_WebRequest = UnityWebRequest.Get(uri);
        StartCoroutine(DoGet(callBack));
    }
    private IEnumerator DoGet(ResponseCallBack callBack)
    {
        yield return m_WebRequest.SendWebRequest();
        if (m_WebRequest.isNetworkError)
        {
            AppDebug.Log("http do get errot:");
        }
        else
        {
            AppDebug.Log(m_WebRequest.downloadHandler.text);
            byte[] result = m_WebRequest.downloadHandler.data;
            callBack(result);
        }
    }

}

