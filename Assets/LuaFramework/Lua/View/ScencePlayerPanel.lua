ScencePlayerPanel = {}
local this = ScencePlayerPanel
local ScencePlayer
local transform
local gameObject
--启动事件
function ScencePlayerPanel.Awake(obj)
    gameObject = obj
    transform = obj.transform
    ScencePlayer = gameObject:GetComponent('LuaBehaviour')
    this.InitPanel()
end

function ScencePlayerPanel.GetRoleCtrl()
    if this.RoleCtrl then
        return this.RoleCtrl
    else
        local obj = GameObject.Find("Role_MainPlayer_Cike");--RoleBornPoint
        if obj then
            this.RoleCtrl = obj:GetComponent('RoleCtrl');--obj:GetComponentInChildren('RoleCtrl');
        else
            logWarn("ScencePlayerPanel RoleBornPoint not found")
        end
        return this.RoleCtrl
    end
end

--初始化面板
function ScencePlayerPanel.InitPanel()
    this.btnLobby = transform:Find('Left/BtnLobby').gameObject
    this.btnRoleFight = transform:Find('EasyTouch/Right/Fight').gameObject
    this.btnRoleSkill = transform:Find("EasyTouch/Right/Skill1").gameObject
    this.btnRoleSkil2 = transform:Find("EasyTouch/Right/Skill2").gameObject
    this.btnRoleSkil3 = transform:Find("EasyTouch/Right/Skill3").gameObject
    this.btnRoleSkil4 = transform:Find("EasyTouch/Right/Skill4").gameObject
end

--单击事件
function ScencePlayerPanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
