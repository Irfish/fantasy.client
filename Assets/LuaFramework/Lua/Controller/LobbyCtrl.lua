require 'Common/define'
local json = require 'cjson'
LobbyCtrl = {}
local this = LobbyCtrl

local Lobby
local transform
local gameObject

--构建函数
function LobbyCtrl.New()
    return this
end

function LobbyCtrl.Awake()
    panelMgr:CreatePanel('Lobby', this.OnCreate)
end

--启动事件
function LobbyCtrl.OnCreate(obj)
    gameObject = obj
    Lobby = gameObject:GetComponent('LuaBehaviour')
    Lobby:AddClick(LobbyPanel.btnGameType1, this.OnClickbtnGameType1)
    Lobby:AddClick(LobbyPanel.btnGameType2, this.OnClickbtnGameType2)
    Lobby:AddClick(LobbyPanel.btnGameType3, this.OnClickbtnGameType3)
end

function LobbyCtrl.OnClickbtnGameType1(go)
    scenceMgr:LoadSence(ScenceName.Main)
end

function LobbyCtrl.OnClickbtnGameType2(go)
    scenceMgr:LoadSence(ScenceName.Main)
end

function LobbyCtrl.OnClickbtnGameType3(go)
    scenceMgr:LoadSence(ScenceName.Piece)
end

--关闭事件
function LobbyCtrl.Close()
    panelMgr:ClosePanel('Lobby')
end
