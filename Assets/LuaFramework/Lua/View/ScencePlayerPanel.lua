local transform
local gameObject

ScencePlayerPanel = {}
local this = ScencePlayerPanel
local ScencePlayer


--启动事件
function ScencePlayerPanel.Awake(obj)
    gameObject = obj
    transform = obj.transform
    ScencePlayer = gameObject:GetComponent('LuaBehaviour')
    local obj= GameObject.Find("MainRole");
    if obj then
        this.RoleCtrl = obj:GetComponent("RoleCtrl");
    else
        logWarn("ScencePlayerPanel MainRole not found")
    end
    this.InitPanel()
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
