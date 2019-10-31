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
end


--关闭事件     
function LobbyCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Lobby)
end
