using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoleCtrl : MonoBehaviour
{
    public string roleName= "Role_MainPlayer_Cike";//默    
    [HideInInspector]
    public RoleCtrl LockEnemy;//敌人
    [HideInInspector]
    public EasyTouchMove easyTouchMove;//控制角色的摇杆
    [HideInInspector]
    public RoleFSMManager CurrRoleFSMMgr = null;//状态机控制器
    [HideInInspector]
    public bool isMoveing = false;//角色是否处于移动中
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public Action<RoleCtrl> OnRoleDie;
    
    //角色对应的特效
    private Dictionary<string, GameObject> effectList = new Dictionary<string, GameObject>();

    private Animator animator;
    public Animator Animator
    {   
        get
        {
            if (animator == null)
            {
                Transform t = transform.Find("Aanimation");

                if (t != null)
                {
                    Animator a = t.GetComponent<Animator>();

                    if (a != null)
                    {
                        animator = a;
                    }
                }
                else
                {
                    AppDebug.Log("GameObject Aanimation not found");
                }
            }

            return animator;
        }
    } //角色动画状态机

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("EasyTouchMove");

        if (obj)
        {
            easyTouchMove = GameObject.Find("EasyTouchMove").GetComponent<EasyTouchMove>();

            easyTouchMove.OnRoleFight = Fight;

            easyTouchMove.OnRoleSkill = Skill;
        }
        else
        {
            AppDebug.Log("GameObject EasyTouchMove not found");
        }

        characterController = transform.GetComponent<CharacterController>();
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
               
                Vector3 dir = direction.normalized;

                if (!characterController.isGrounded)//角色不在地面上，则施加垂直方向的重力，使其着地
                {
                    dir.y = dir.y - 9.8f; 
                }

                characterController.Move(dir * Time.deltaTime * 5);

                //向前移动
                //transform.Translate(Vector3.forward * Time.deltaTime * 5); //此方法无视障碍物
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
            Transform t = transform.Find(name);

            if (t == null)
            {
                AppDebug.Log("can not found gameoobject: " + name);

                return;
            }

            GameObject o = t.gameObject;

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
            Transform t = transform.Find(name);

            if (t == null)
            {
                AppDebug.Log("can not found gameoobject: "+ name);

                return;
            }

            GameObject o = t.gameObject;

            effectList[name] = o;
        }

        GameObject obj = effectList[name];

        obj.SetActive(false);
    }

}

