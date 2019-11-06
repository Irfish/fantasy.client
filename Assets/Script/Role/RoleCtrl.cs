using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoleCtrl : MonoBehaviour
{
    //[HideInInspector]
    public Animator Animator;

    //[HideInInspector]
    public RoleCtrl LockEnemy;

    //[HideInInspector]
    public Action<RoleCtrl> OnRoleDie;

    //[HideInInspector]
    public CharacterController CharacterController;

    //[HideInInspector]
    public RoleFSMManager CurrRoleFSMMgr = null;


    public float MoveSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrRoleFSMMgr != null)
            CurrRoleFSMMgr.OnUpdate();
    }

    public void ToIdle()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);
        MoveSpeed = 0;
    }


    public void OnMoveStart()
    {
        AppDebug.Log("MoveStart");
        CurrRoleFSMMgr.ChangeState(RoleState.Run);
        MoveSpeed = 1f;
    }

    public void OnMove(Vector2 move)
    {
        AppDebug.Log("Move --> x" + move.x + " y:" + move.y);
        CurrRoleFSMMgr.ChangeState(RoleState.Run);
        MoveSpeed = 1f;
    }

    public void OnMoveSpeed(Vector2 move)
    {
        AppDebug.Log("MoveSpeed --> x" + move.x + " y:" + move.y);
        CurrRoleFSMMgr.ChangeState(RoleState.Run);
        if (move.x>0|| move.y>0) {
            MoveSpeed = 1f;
        }
    }

    public void OnMoveEnd()
    {
        AppDebug.Log("MoveEnd");
        MoveSpeed = 0f;
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);
    }

}
