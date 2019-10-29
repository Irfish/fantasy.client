using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;

namespace fantasy.net
{
    public class Http : SingletonMono<Http>
    {
        /// <summary>
        ///相应回调
        /// </summary>
        /// <param name="buffer"></param>
        public delegate void ResponseCallBack(string data);

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
                AppDebug.Log("HTTP do post error:" + m_WebRequest.error);
            }
            else
            {
                AppDebug.Log("HTTP post return: " + m_WebRequest.downloadHandler.text);

                callBack(m_WebRequest.downloadHandler.text);

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
                AppDebug.Log("HTTP do get error:");
            }
            else
            {
                AppDebug.Log("HTTP get return: " + m_WebRequest.downloadHandler.text);

                callBack(m_WebRequest.downloadHandler.text);

            }
        }

    }
}

