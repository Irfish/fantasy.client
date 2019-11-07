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

    public EasyTouchMove easyTouchMove;

    //[HideInInspector]
    public RoleFSMManager CurrRoleFSMMgr = null;

    public bool isMoveing = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("EasyTouchMove");

        if (obj)
        {
            easyTouchMove = GameObject.Find("EasyTouchMove").GetComponent<EasyTouchMove>();
        }
        else {
            AppDebug.Log("GameObject EasyTouchMove not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrRoleFSMMgr != null)
        {
            CurrRoleFSMMgr.OnUpdate();
        }
        
        if (easyTouchMove != null)
        {
            float hor = easyTouchMove.Horizontal;

            float ver = easyTouchMove.Vertical;

            Vector3 direction = new Vector3(hor, 0, ver);

            if (direction != Vector3.zero)
            {
                CurrRoleFSMMgr.ChangeState(RoleState.Run);

                isMoveing = true;
                //控制转向
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
                //向前移动
                transform.Translate(Vector3.forward * Time.deltaTime * 5);
            }
            else
            {
                isMoveing = false;
            }
        }
        else
        {
            ToIdle();
        }
    }

    public void ToIdle()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);

        isMoveing = false;
    }

    public void Fight(int fight)
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Attack,fight);
    }

    public void Skill(int skill)
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Skill, skill);
    }

}

