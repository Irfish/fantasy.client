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
    this.InitPanel()
end

--初始化面板
function ScencePlayerPanel.InitPanel()
end

--单击事件
function ScencePlayerPanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
