//===================================================
//Author:      宋宋
//CreateTime:  2018-08-25 23:20:02
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoleType
{
    /// <summary>
    /// 未设置
    /// </summary>
    None = 0,
    /// <summary>
    /// 当前玩家
    /// </summary>
    MainPlayer = 1,
    /// <summary>
    /// 怪
    /// </summary>
    Monster = 2
}

/// <summary>
/// 角色状态
/// </summary>
public enum RoleState
{
    /// <summary>
    /// 未设置
    /// </summary>
    None = 0,
    /// <summary>
    /// 待机
    /// </summary>
    Idle = 1,
    /// <summary>
    /// 跑了
    /// </summary>
    Run = 2,
    /// <summary>
    /// 攻击
    /// </summary>
    Attack = 3,
    /// <summary>
    /// 受伤
    /// </summary>
    Hurt = 4,
    /// <summary>
    /// 死亡
    /// </summary>
    Die = 5,

    Skill = 5,
}

/// <summary>
/// 角色动画状态名称
/// </summary>
public enum RoleAnimatorName
{
    Idle_Normal,
    Idle_Fight,
    Run,
    Hurt,
    Die,
    PhyAttack1,
    PhyAttack2,
    PhyAttack3,
    Skill1,
    Skill2,
    Skill3,
    Skill4,
    Skill5,
}

public enum ToAnimatorCondition
{
    ToIdleNormal,
    ToIdleFight,
    ToRun,
    ToPhyAttack,
    ToHurt,
    ToDie,
    ToSkill,
    CurrState
}
