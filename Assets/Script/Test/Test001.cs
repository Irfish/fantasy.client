using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using Google.Protobuf;
using Pb;

public class Test001 : MonoBehaviour
{
    void Start()
    {
        //TestHttpPostRegister();
        TestHttpPostLogin();
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

    public void TestHttpPostLogin()
    {
        WWWForm f = new WWWForm();
        f.AddField("accountId", 1003);
        f.AddField("password", "123456");
        Http.Instance.SendPost("http://192.168.0.130:4000/post/login", f, CallbackLoginSuccess);
    }

    public void TestHttpPostRegister()
    {
        WWWForm f = new WWWForm();
        f.AddField("userName", "fire001");
        f.AddField("pwd", "123456");
        Http.Instance.SendPost("http://192.168.0.130:4000/post/user_register", f, CallbackPost);
    }

    public void CallbackPost(string data)
    {
        AppDebug.Log("baidu");
    }

    public void Callback(string data)
    {
        AppDebug.Log("baidu");
    }

    public void CallbackLoginSuccess(string data)
    {
        AppDebug.Log("CallbackLoginSuccess:" + data);
        LoginSuccess l = JsonMapper.ToObject<LoginSuccess>(data);
        AppDebug.Log("gw addr:" + l.gw);
        string[] c = { ":" };
        string[] s = l.gw.Split(c, StringSplitOptions.None);
        string host = s[0];
        int port = int.Parse(s[1]);
        SocketClient.Instance.Connecte(host, port);
    }


    public void ClickButtonTest()
    {
        AppDebug.Log("send msg--->");
        CtsUserEnter u = new CtsUserEnter();
        u.UserId = 10021;
        NetWorkMessageTools.Instance.SendMessage(u);
    }
   
    void Update()
    {
        
    }
    struct LoginSuccess
    {
        public string gw;
        bool status;
    }
}

