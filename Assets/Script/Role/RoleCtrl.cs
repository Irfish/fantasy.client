using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoleCtrl : MonoBehaviour
{
    public string roleName= "Role_MainPlayer_Cike";//默认
    [HideInInspector]
    public Animator Animator; //角色动画状态机
    [HideInInspector]
    public RoleCtrl LockEnemy;//敌人
    [HideInInspector]
    public Action<RoleCtrl> OnRoleDie;
    [HideInInspector]
    public EasyTouchMove easyTouchMove;//控制角色的摇杆
    [HideInInspector]
    public RoleFSMManager CurrRoleFSMMgr = null;//状态机控制器
    [HideInInspector]
    public bool isMoveing = false;//角色是否处于移动中
    //角色对应的特效
    private Dictionary<string, GameObject> effectList = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("EasyTouchMove");

        if (obj)
        {
            easyTouchMove = GameObject.Find("EasyTouchMove").GetComponent<EasyTouchMove>();
        }
        else
        {
            AppDebug.Log("GameObject EasyTouchMove not found");
        }

        if (Animator==null)
        {
            Transform t = transform.Find("Aanimation");

            if (t != null)
            {
                Animator a = t.GetComponent<Animator>();

                if (a != null)
                {
                    Animator = a;
                }
            }
            else
            {
                AppDebug.Log("GameObject Aanimation not found");
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrRoleFSMMgr != null)
        {
            CurrRoleFSMMgr.OnUpdate();
        }
        else
        {
            AppDebug.Log("CurrRoleFSMMgr not set-------------------------->");
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

    //保持站立状态
    public void ToIdle()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);

        isMoveing = false;
    }

    //攻击动作
    public void Fight(int fight)
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Attack,fight);
    }

    //释放技能
    public void Skill(int skill)
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Skill, skill);
    }

    //激活特效
    public void PlayEffect(string name)
    {
        if (!effectList.ContainsKey(name))
        {
            GameObject o = transform.Find(name).gameObject;

            effectList[name] = o;
        }

        GameObject obj = effectList[name];

        obj.SetActive(true);
    }
    //禁用特效
    public void StopEffect(string name)
    {
        if (!effectList.ContainsKey(name))
        {
            GameObject o = transform.Find(name).gameObject;

            effectList[name] = o;
        }

        GameObject obj = effectList[name];

        obj.SetActive(false);
    }

}

