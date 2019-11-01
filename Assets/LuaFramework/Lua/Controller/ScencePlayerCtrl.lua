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
end

--关闭事件
function ScencePlayerCtrl.Close()
    panelMgr:ClosePanel('ScencePlayer')
end
