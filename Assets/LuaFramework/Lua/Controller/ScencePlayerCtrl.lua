require 'Common/define'
local json = require 'cjson'
ScencePlayerCtrl = {}
local this = ScencePlayerCtrl

local ScencePlayer
local transform
local gameObject

--构建函数
function ScencePlayerCtrl.New()
    return this
end

function ScencePlayerCtrl.Awake()
    panelMgr:CreatePanel('ScencePlayer', this.OnCreate)
end

--启动事件
function ScencePlayerCtrl.OnCreate(obj)
    gameObject = obj
    ScencePlayer = gameObject:GetComponent('LuaBehaviour')
    ScencePlayer:AddClick(ScencePlayerPanel.btnLobby, this.OnClickBtnLobby)
    ScencePlayer:AddClick(ScencePlayerPanel.btnRoleFight, this.OnClickBtnRoleFight)

    ScencePlayer:AddClick(ScencePlayerPanel.btnRoleSkill, this.OnClickBtnRoleSkill)
    ScencePlayer:AddClick(ScencePlayerPanel.btnRoleSkil2, this.OnClickBtnRoleSkil2)
    ScencePlayer:AddClick(ScencePlayerPanel.btnRoleSkil3, this.OnClickBtnRoleSkil3)
    ScencePlayer:AddClick(ScencePlayerPanel.btnRoleSkil4, this.OnClickBtnRoleSkil4)
end

function ScencePlayerCtrl.OnClickBtnLobby(go)
    scenceMgr:LoadSence(ScenceName.Lobby)
end
--普通攻击
function ScencePlayerCtrl.OnClickBtnRoleFight(go)
    ScencePlayerPanel.RoleCtrl:Fight(3)
end
--技能1
function ScencePlayerCtrl.OnClickBtnRoleSkill(go)
    ScencePlayerPanel.RoleCtrl:Skill(1)
end
--技能2
function ScencePlayerCtrl.OnClickBtnRoleSkil2(go)
    ScencePlayerPanel.RoleCtrl:Skill(2)
end
--技能3
function ScencePlayerCtrl.OnClickBtnRoleSkil3(go)
    ScencePlayerPanel.RoleCtrl:Skill(3)
end
--技能4
function ScencePlayerCtrl.OnClickBtnRoleSkil4(go)
    ScencePlayerPanel.RoleCtrl:Skill(4)
end

--关闭事件
function ScencePlayerCtrl.Close()
    panelMgr:ClosePanel('ScencePlayer')
end
