using LitJson;
using System;
using UnityEngine;
using Pb;
using Google.Protobuf;

public class UserManager : Singleton<UserManager>
{
    private Player m_Player = new Player();

    private int m_ServerTime;

    public UserManager()
    {
        Event.Instance.AddListener("OnTcpConnected", OnTcpConnected);

        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserAuthentication)), OnStcAuthentication);

    }
    public Player GetPlayer()
    {
        return m_Player;
    }

    //获取服务器时间
    public void GetServerTime()
    {
        Http.Instance.SendGet(AppDefine.HttpURL + "/get/serverTime", GetServerTimeCallback);
    }
    struct ServerTime
    {
        public int time;
    }
    public void GetServerTimeCallback(string data)
    {
        ServerTime st = JsonMapper.ToObject<ServerTime>(data);

        m_ServerTime = st.time;

    }
    //通过账号和密码登陆游戏
    public void LoginByAccount(string userName, string password)
    {
        m_Player.Name = userName;

        WWWForm f = new WWWForm();

        f.AddField("accountId", userName);

        f.AddField("password", password);

        Http.Instance.SendPost(AppDefine.HttpURL + "/post/login", f, LoginSuccessCallback);

    }
    struct LoginResponse
    {
        public string gw;
        public bool status;
        public int userId;
        public int expireTime;
        public string token;
        public string err;
    }
    //登录成功后与gw建立长链接
    public void LoginSuccessCallback(string data)
    {

        LoginResponse r = JsonMapper.ToObject<LoginResponse>(data);

        if (!r.status)
        {
            AppDebug.Log("登陆失败:"+r.err);

            return;
        }

        AppDebug.Log("登陆成功！");

        //创建用户实体
        m_Player.UserId = r.userId;

        m_Player.Token = r.token;//System.Text.Encoding.Default.GetString();

        m_Player.TokenExpireTime = r.expireTime;
        //获取 gateway 地址(此处应该返回一个服务器列表，供玩家选择登录)
        string[] c = { ":" };

        string[] s = r.gw.Split(c, StringSplitOptions.None);

        string host = s[0];

        int port = int.Parse(s[1]);

        SocketClient.Instance.Connecte(host, port);

    }

    public void OnTcpConnected(byte[] buffer)
    {
        AppDebug.Log("TCP 连接成功");
        //连接成功之后需要到gateway中认证
        Authentication();

    }
    //玩家认证
    public void Authentication()
    {
        CtsUserAuthentication auth = new CtsUserAuthentication();

        auth.Token = ByteString.CopyFromUtf8(m_Player.Token);

        auth.UserId = m_Player.UserId;

        auth.TokenExpireTime = m_Player.TokenExpireTime;

        NetworkManager.Instance.SendToGw(auth);

    }

    public void OnStcAuthentication(object obj)
    {
        StcUserAuthentication stc = obj as StcUserAuthentication;

        AppDebug.Log("认证成功！"+"seesionId:"+stc.SessionId+" result:"+ stc.Result);

    }

    public override void Dispose()
    {
        m_Player = null;

        Event.Instance.RemoveListener("OnTcpConnected", OnTcpConnected);

        SocketEvent.Instance.RemoveListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserAuthentication)), OnStcAuthentication);

        base.Dispose();

    }

}
