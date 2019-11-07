using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleStateSkill : RoleStateAbstract
{

    private string[] skillList = new string[] {
        RoleAnimatorName.Skill1.ToString(),
        RoleAnimatorName.Skill2.ToString(),
        RoleAnimatorName.Skill3.ToString(),
        RoleAnimatorName.Skill4.ToString(),
        RoleAnimatorName.Skill5.ToString(),
        RoleAnimatorName.Skill6.ToString()
    };

    public RoleStateSkill(RoleFSMManager roleFSMMgr) : base(roleFSMMgr)
    {
        EffectName = "Role_MainPlayer_Cike_Effect_Skill_";
    }

    // Start is called before the first frame update
    public override void OnEnter()
    {
        base.OnEnter();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.ToSkill.ToString(), ActionType);

        CurrRoleFSMMgr.CurrRoleCtrl.PlayEffect(EffectName + ActionType);

    }

    /// <summary>
    /// 执行状态
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);

        if (CurrRoleAnimatorStateInfo.IsName(skillList[ActionType-1]))
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Skill);

            //如果动画执行了一遍 就切换待机
            if (CurrRoleAnimatorStateInfo.normalizedTime > 1)
            {
                CurrRoleFSMMgr.CurrRoleCtrl.ToIdle();
            }
        }
        else
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }

    }

    /// <summary>
    /// 离开状态
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.ToSkill.ToString(), 0);

        CurrRoleFSMMgr.CurrRoleCtrl.StopEffect(EffectName + ActionType);
    }
}
