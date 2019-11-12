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

--初始化面板
function ScencePlayerPanel.InitPanel()
    this.btnLobby = transform:Find('Left/BtnLobby').gameObject
    this.miniMapCamera = transform:Find('Right/MiniMapCamera')
end

function ScencePlayerPanel.Update()
   
end


--单击事件
function ScencePlayerPanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
