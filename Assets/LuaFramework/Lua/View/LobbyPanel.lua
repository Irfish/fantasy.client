local transform
local gameObject

LobbyPanel = {}
local this = LobbyPanel
local Lobby

--启动事件
function LobbyPanel.Awake(obj)
    gameObject = obj
    transform = obj.transform
    Lobby = gameObject:GetComponent('LuaBehaviour')
    this.InitPanel()
end

--初始化面板
function LobbyPanel.InitPanel()
    this.btnGameType1 = transform:Find('Bottom/BtnGameType1').gameObject
    this.btnGameType2 = transform:Find('Bottom/BtnGameType2').gameObject
    this.btnGameType3 = transform:Find('Bottom/BtnGameType3').gameObject
    this.btnFantasy = transform:Find('Right/Fantasy/BtnFantasy').gameObject
    this.btnTask = transform:Find('Left/BtnTask').gameObject
    this.btnChat = transform:Find('Left/BtnChat').gameObject
    this.btnRank = transform:Find('Left/BtnRank').gameObject
    this.gameSceneItem = transform:Find('PanelCenter/ScrollView/Viewport/Item').gameObject
    this.gameSceneItemParent = transform:Find('PanelCenter/ScrollView/Viewport/Content').gameObject
    this.scrollView = transform:Find('PanelCenter/ScrollView').gameObject
end
--显示玩家信息
function LobbyPanel.ShowPlayerInfo(player)

end

--单击事件
function LobbyPanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
