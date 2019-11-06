using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;

public class EasyTouchTest : MonoBehaviour
{
    public RoleCtrl roleCtrl;

    // Start is called before the first frame update
    void Start()
    {
        roleCtrl.CurrRoleFSMMgr = new RoleFSMManager(roleCtrl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveStart()
    {
        AppDebug.Log("MoveStart");
        
    }

    public void Move(Vector2 move)
    {
        AppDebug.Log("Move --> x" + move.x + " y:" + move.y);
    }

    public void MoveSpeed(Vector2 move)
    {
        AppDebug.Log("MoveSpeed --> x" + move.x + " y:" + move.y);
    }

    public void MoveEnd()
    {
        AppDebug.Log("MoveEnd");
    }

    public void TouchStart()
    {
        AppDebug.Log("TouchStart");
    }

    public void TouchUp()
    {
        AppDebug.Log("TouchUp");
    }

    public void DownRight()
    {
        AppDebug.Log("DownRight");
    }

    public void DownDown()
    {
        AppDebug.Log("DownDown");
    }

    public void DownLeft()
    {
        AppDebug.Log("DownLeft");
    }

    public void DownUp()
    {
        AppDebug.Log("DownUp");
    }

    public void Right()
    {
        AppDebug.Log("Right");
    }

    public void Down()
    {
        AppDebug.Log("Down");
    }

    public void Left()
    {
        AppDebug.Log("Left");
    }

    public void Up()
    {
        AppDebug.Log("Up");
    }
}
