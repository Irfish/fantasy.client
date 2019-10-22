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
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserEnter)), OnStcUserEnter);

        UserManager.Instance.LoginByAccount("1003","123456");
    }

    private void OnStcUserEnter(object data)
    {
        StcUserEnter stc = data as StcUserEnter;

        AppDebug.Log(stc.Result);

    }

    public void ClickButtonTest()
    {
        CtsUserEnter u = new CtsUserEnter();

        u.UserId = 10021;

        u.Token = ByteString.CopyFromUtf8("unity client");

        NetworkManager.Instance.SendToGame(u);

    }

    void Update()
    {

    }

}

