require 'Common/define'
local json = require 'cjson'
ScencePieceCtrl = {}
local this = ScencePieceCtrl

local ScencePiece
local transform
local gameObject

--构建函数
function ScencePieceCtrl.New()
    return this
end

function ScencePieceCtrl.Awake()
    panelMgr:CreatePanel('ScencePiece', this.OnCreate)
end

--启动事件
function ScencePieceCtrl.OnCreate(obj)
    gameObject = obj
    ScencePiece = gameObject:GetComponent('LuaBehaviour')
end

--关闭事件
function ScencePieceCtrl.Close()
    panelMgr:ClosePanel('ScencePiece')
end
