using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test001 : MonoBehaviour
{
    void Start()
    {

    }

    public void TestWebSocket()
    {
        WebSocketClient.Instance.WsConnect();
    }

    public void TestSocket()
    {
        SocketClient.Instance.Connecte(AppDefine.tcpAddr, AppDefine.tcpPort);
    }

    public void TestHttp()
    {
        AppDebug.Log(StringTools.Instance.Add("test ").Add("string").ToString());
        Http.Instance.SendGet("http://www.baidu.com", Callback);
    }

    public void Callback(byte[] data)
    {
        AppDebug.Log("baidu");
    }

    void Update()
    {
        
    }
}
