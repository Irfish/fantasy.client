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
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserLeave)), OnStcUserLeave);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcCreateRoom)), OnStcCreateRoom);

        UserManager.Instance.LoginByAccount("1003","123456");
    }

    private void OnStcUserLeave(object data)
    {
        StcUserLeave stc = data as StcUserLeave;

        AppDebug.Log("user leave: "+stc.RoomId.ToString());
    }

    private void OnStcCreateRoom(object data)
    {
        StcCreateRoom stc = data as StcCreateRoom;

        AppDebug.Log("create room:"+stc.RoomId.ToString());
    }

    private void OnStcUserEnter(object data)
    {
        StcUserEnter stc = data as StcUserEnter;

        AppDebug.Log("user enter:"+stc.RoomId.ToString());

    }

    public void ClickButtonUserEnter()
    {
        CtsUserEnter u = new CtsUserEnter();

        u.UserId = 1003;
        
        NetworkManager.Instance.SendToGame(u);

    }

    public void ClickButtonUserLeave()
    {
        CtsUserLeave u = new CtsUserLeave();

        u.UserId = 1003;

        NetworkManager.Instance.SendToGame(u);

    }

    public void ClickButtonCreateRoom()
    {
        CtsCreateRoom u = new CtsCreateRoom();

        u.UserId = 1003;

        NetworkManager.Instance.SendToGame(u);

    }


    void Update()
    {

    }

}

