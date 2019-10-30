using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pb;
using fantasy.manager;
using UnityEngine.UI;

public class Test001 : MonoBehaviour
{
    void Start()
    {
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcCreateRoom)), OnStcCreateRoom);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserEnter)), OnStcUserEnter);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserLeave)), OnStcUserLeave);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcErrorNotice)), OnErrorNotice);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcPlayPiece)), OnStcPlayPiece);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcGameResult)), OnStcGameResult);
        SocketEvent.Instance.AddListener((ushort)MessageDefine.GetProtoIdByProtoType(typeof(StcUserReady)), OnStcUserReady);

        gameObject.GetComponent<InputField>();

        UserManager.Instance.LoginByAccount("1003","123456");
    }

    private void OnStcUserReady(object data)
    {
         StcUserReady stc = data as StcUserReady;

         AppDebug.Log("user ready: " + stc.ChairId.ToString());

    }

    private void OnStcGameResult(object data)
    {
        StcGameResult stc = data as StcGameResult;

        AppDebug.Log("game result: " + stc.PieceList.ToString());
    }

    private void OnStcPlayPiece(object data)
    {
        StcPlayPiece stc = data as StcPlayPiece;

        AppDebug.Log("play piece: " + stc.ToString());
    }

    private void OnErrorNotice(object data)
    {
        StcErrorNotice stc = data as StcErrorNotice;

        AppDebug.Log("error notice: " + stc.Info);
    }

    private void OnStcUserLeave(object data)
    {
        StcUserLeave stc = data as StcUserLeave;

        AppDebug.Log("user leave: "+stc.RoomId.ToString()+" "+stc.ChairId.ToString());
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

        AppDebug.Log("user enter:"+stc.RoomId.ToString()+" "+stc.ChairId.ToString());

    }

    public void ClickButtonUserEnter()
    {
        CtsUserEnter cts = new CtsUserEnter();

        cts.UserId = 1003;

        cts.RoomId = UserManager.Instance.GetPlayer().RoomId;

        NetworkManager.Instance.SendToGame(cts);
        piece_x = 0;
        piece_y = 0;
    }

    public void ClickButtonUserLeave()
    {
        CtsUserLeave cts = new CtsUserLeave();

        cts.UserId = 1003;

        cts.RoomId = UserManager.Instance.GetPlayer().RoomId;

        cts.ChairId = UserManager.Instance.GetPlayer().ChairId;

        NetworkManager.Instance.SendToGame(cts);

    }

    public void ClickButtonCreateRoom()
    {
        CtsCreateRoom cts = new CtsCreateRoom();

        cts.UserId = 1003;

        NetworkManager.Instance.SendToGame(cts);

    }
    private int piece_x=0;
    private int piece_y = 0;

    public void ClickButtonPlayPiece()
    {
        CtsPlayPiece cts = new CtsPlayPiece();

        cts.ChairId = UserManager.Instance.GetPlayer().ChairId;

        cts.RoomId= UserManager.Instance.GetPlayer().RoomId;

        cts.X = piece_x;

        cts.Y = piece_y;

        NetworkManager.Instance.SendToGame(cts);

        piece_x++;

        piece_y++;

    }

    public void ClickButtonUserReady()
    {
        CtsUserReady cts = new CtsUserReady();

        cts.ChairId = UserManager.Instance.GetPlayer().ChairId;

        cts.RoomId = UserManager.Instance.GetPlayer().RoomId;

        cts.Status = true;

        NetworkManager.Instance.SendToGame(cts);

    }

    void Update()
    {

    }

}

