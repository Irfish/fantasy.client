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
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcCreateRoom)), OnStcCreateRoom);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserEnter)), OnStcUserEnter);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserLeave)), OnStcUserLeave);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcErrorNotice)), OnErrorNotice);

        UserManager.Instance.LoginByAccount("1003","123456");
    }

    private void OnErrorNotice(object data)
    {
        StcErrorNotice stc = data as StcErrorNotice;

        AppDebug.Log("error notice: " + stc.Info);
    }

    private void OnStcUserLeave(object data)
    {
        StcUserLeave stc = data as StcUserLeave;

        AppDebug.Log("user leave: "+stc.RoomId.ToString());
    }

    private void OnStcCreateRoom(object data)
    {
        StcCreateRoom stc = data as StcCreateRoom;

        UserManager.Instance.GetPlayer().RoomId = stc.RoomId;

        AppDebug.Log("create room:" + stc.RoomId.ToString());

    }

    private void OnStcUserEnter(object data)
    {
        StcUserEnter stc = data as StcUserEnter;

        UserManager.Instance.GetPlayer().RoomId = stc.RoomId;

        UserManager.Instance.GetPlayer().ChairId = stc.ChairId;

        AppDebug.Log("user enter:"+stc.RoomId.ToString());

    }

    public void ClickButtonUserEnter()
    {
        CtsUserEnter u = new CtsUserEnter();

        u.UserId = 1003;

        u.RoomId = UserManager.Instance.GetPlayer().RoomId;

        NetworkManager.Instance.SendToGame(u);

    }

    public void ClickButtonUserLeave()
    {
        CtsUserLeave u = new CtsUserLeave();

        u.UserId = 1003;

        u.RoomId = UserManager.Instance.GetPlayer().RoomId;

        u.ChairId = UserManager.Instance.GetPlayer().ChairId;

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

