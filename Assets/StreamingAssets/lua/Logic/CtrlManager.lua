require 'Common/define'
require 'Controller/LoginCtrl'
require 'Controller/LobbyCtrl'
require 'Controller/ScencePlayerCtrl'
require 'Controller/ScencePieceCtrl'

CtrlManager = {}
local this = CtrlManager
local ctrlList = {} --控制器列表
local ScenceUIList={}

function CtrlManager.Init()
    ctrlList[CtrlNames.Login] = LoginCtrl.New()
    ctrlList[CtrlNames.Lobby] = LobbyCtrl.New()
    ctrlList[CtrlNames.ScencePlayer] = ScencePlayerCtrl.New()
    ctrlList[CtrlNames.ScencePiece] = ScencePieceCtrl.New()
    this.BindUiToScence()
    return this
end

function CtrlManager.BindUiToScence()

    ScenceUIList[ScenceName.UI] = {
        CtrlNames.Login        
    }

    ScenceUIList[ScenceName.Lobby] = {
        CtrlNames.Lobby
    }
    
    ScenceUIList[ScenceName.Piece] = {
        CtrlNames.ScencePiece
    }
    
    ScenceUIList[ScenceName.Main] = {
        CtrlNames.ScencePlayer
    }

end

function CtrlManager.ShowScenceUI(scence)
    local list = ScenceUIList[scence]
    if #list>0 then
        for _,v in pairs(list) do
              this.OpendCtrl(v)  
        end
    end
end

function CtrlManager.CloseScenceUI(scence)
    local list = ScenceUIList[scence]
    if #list>0 then
        for _,v in pairs(list) do
              this.CloseCtrl(v)  
        end
    end
end

function CtrlManager.OpendCtrl(name)
    local ctrl = this.GetCtrl(name)
    if ctrl ~= nil then
        ctrl:Awake()
    end
end

function CtrlManager.CloseCtrl(name)
    local ctrl = this.GetCtrl(name)
    if ctrl ~= nil then
        ctrl:Close()
    end
end

--添加控制器
function CtrlManager.AddCtrl(ctrlName, ctrlObj)
    ctrlList[ctrlName] = ctrlObj
end

--获取控制器
function CtrlManager.GetCtrl(ctrlName)
    return ctrlList[ctrlName]
end

--移除控制器
function CtrlManager.RemoveCtrl(ctrlName)
    ctrlList[ctrlName] = nil
end

--关闭控制器
function CtrlManager.Close()
    logWarn('CtrlManager.Close---->>>')
end
