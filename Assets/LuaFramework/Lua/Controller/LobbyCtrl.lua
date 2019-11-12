require 'Common/define'
local json = require 'cjson'
LobbyCtrl = {}
local this = LobbyCtrl

local Lobby
local transform
local gameObject
local itmeList

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
    Lobby:AddClick(LobbyPanel.btnFantasy, this.OnClickBtnFantasy)
    Lobby:AddClick(LobbyPanel.btnTask, this.OnClickBtnTask)
    Lobby:AddClick(LobbyPanel.btnChat, this.OnClickBtnChat)
    Lobby:AddClick(LobbyPanel.btnRank, this.OnClickBtnRank)
    this.scrollPageTool = LobbyPanel.scrollView:GetComponent('ScrollPageTool')
    --默认选择
    local gameList = {
        {name = 'WorldScene_DaShanGu', imgId = '2',describe="绿野仙踪"},
        {name = 'WorldScene_PingYuan', imgId = '3',describe="幽林冥都"}
    }
    this.ReLoadItem(gameList)
end

function LobbyCtrl.ReLoadItem(list)
    if (not list) or #list == 0 then
        return
    end
    if not itmeList then
        itmeList = {}
    end
    local count = #list --总数
    local hasCount = #itmeList --已经存在的item
    local newCount = 0 --新增加的item
    local hidCount = 0 --需要隐藏的item
    if count > hasCount then
        newCount = count - hasCount
    else
        hidCount = hasCount - count
    end

    local firstLoadCount = hasCount
    if hidCount > 0 then
        firstLoadCount = count
    end

    local index = 0
    --重新赋值
    for j = 1, firstLoadCount do
        local go = itmeList[j]
        go.name = list[j].name .. '_' .. list[j].imgId
        go:SetActive(true)
        index = j
    end
    --将多余的item隐藏
    if hidCount > 0 then
        for j = index + 1, hasCount do
            local go = itmeList[j]
            go:SetActive(false)
        end
    end
    --新建
    for i = index + 1, index + newCount do
        local go = newObject(LobbyPanel.gameSceneItem)
        go.name = list[i].name .. '_' .. list[i].imgId
        go.transform:SetParent(LobbyPanel.gameSceneItemParent.transform)
        go.transform.localScale = Vector3.one
        go.transform.localPosition = Vector3.zero
        go:SetActive(true)
        Lobby:AddClick(go, this.OnClickItem)
        table.insert(itmeList, go)
    end
    this.ResetScrollViewName(list)
end
--初始化ScrollView
function LobbyCtrl.ResetScrollViewName(list)
    for i=1,#list do
        this.scrollPageTool:ResetPageName(i,list[i].describe)
    end
    this.scrollPageTool:ResetPageCount(#list)
end
--点击进入场景
function LobbyCtrl.OnClickItem(go)
    local name = go.name
    local s = Split(name, '_')
    local sceneName = s[1] .. '_' .. s[2]
    scenceMgr:LoadSence(sceneName)
end
--养成类型
function LobbyCtrl.OnClickbtnGameType1(go)
    local gameList = {
        {name = 'WorldScene_DaShanGu', imgId = '2',describe="绿野仙踪"},
        {name = 'WorldScene_PingYuan', imgId = '3',describe="幽林冥都"}
    }
    this.ReLoadItem(gameList)
end
--对战类型
function LobbyCtrl.OnClickbtnGameType2(go)
    local gameList = {
        {name = 'WorldScene_XueDi', imgId = '4',describe="银雪幻境"}
    }
    this.ReLoadItem(gameList)
end
--休闲类型
function LobbyCtrl.OnClickbtnGameType3(go)
    local gameList = {
        {name = 'Scene_Piece', imgId = '1',describe="菜鸡工厂"},
    }
    this.ReLoadItem(gameList)
end
--进入幻境
function LobbyCtrl.OnClickBtnFantasy(go)
    scenceMgr:LoadSence(ScenceName.PingYuan)
end
--任务
function LobbyCtrl.OnClickBtnTask(go)
end
--聊天
function LobbyCtrl.OnClickBtnChat(go)
end
--排行
function LobbyCtrl.OnClickBtnRank(go)
end
--关闭事件
function LobbyCtrl.Close()
    itmeList = nil
    panelMgr:ClosePanel('Lobby')
end
