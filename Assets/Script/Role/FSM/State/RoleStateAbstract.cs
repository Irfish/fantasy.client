//===================================================
//Author:      宋宋
//CreateTime:  2018-08-27 20:33:05
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleStateAbstract  {
	/// <summary>
    /// 当前角色有限状态机管理器
    /// </summary>
	public RoleFSMManager CurrRoleFSMMgr { get; private set; }

    public int ActionType { get; set; }

    public string EffectName { get; set; }
    /// <summary>
    /// 当前动画状态信息
    /// </summary>
    public AnimatorStateInfo CurrRoleAnimatorStateInfo { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleFSMMgr"></param>
	public RoleStateAbstract(RoleFSMManager roleFSMMgr)
    {
        CurrRoleFSMMgr = roleFSMMgr;
    }

    /// <summary>
    /// 进入状态
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// 执行状态
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// 离开状态
    /// </summary>
    public virtual void OnLeave() { }
}
