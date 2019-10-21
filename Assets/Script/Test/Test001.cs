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
        UserManager.Instance.LoginByAccount("1003","123456");
    }

    public void ClickButtonTest()
    {
        CtsUserEnter u = new CtsUserEnter();

        u.UserId = 10021;

        NetWorkMessageTools.Instance.SendMessage(u);

    }

    void Update()
    {

    }

}

