local transform
local gameObject

ScencePiecePanel = {}
local this = ScencePiecePanel
local ScencePiece

--启动事件
function ScencePiecePanel.Awake(obj)
    gameObject = obj
    transform = obj.transform
    ScencePiece = gameObject:GetComponent('LuaBehaviour')
    this.InitPanel()
end

--初始化面板
function ScencePiecePanel.InitPanel()
end

--单击事件
function ScencePiecePanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
