using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test001 : MonoBehaviour
{
    void Start()
    {
        TestHttpPost();
    }

    public void TestWebSocket()
    {
        WebSocketClient.Instance.WsConnect();
    }

    public void TestSocket()
    {
        SocketClient.Instance.Connecte(AppDefine.tcpAddr, AppDefine.tcpPort);
    }

    public void TestHttpGet()
    {
        AppDebug.Log(StringTools.Instance.Add("test ").Add("string").ToString());
        Http.Instance.SendGet("http://www.baidu.com", Callback);
    }

    public void TestHttpPost()
    {
        WWWForm f = new WWWForm();
        f.AddField("accountId",1000);
        f.AddField("password", "123456");
        Http.Instance.SendPost("http://192.168.0.130:4000/post/login/", f, CallbackPost);
    }

    public void CallbackPost(byte[] data)
    {
        AppDebug.Log("baidu");
    }

    public void Callback(byte[] data)
    {
        AppDebug.Log("baidu");
    }

    void Update()
    {
        
    }
}
