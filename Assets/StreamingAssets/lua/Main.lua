require 'Common/define'
--主入口函数。从这里开始lua逻辑
Main = {}
local this = Main
function MainInit()
    print('logic start')
end

--场景切换通知
function Main.OnLevelWasLoaded(currentSenceName, lastSencenName)
    collectgarbage('collect')
    Time.timeSinceLevelLoad = 0
    logWarn('OnLevelWasLoaded ' .. lastSencenName .. '->' .. currentSenceName)
    if currentSenceName == 'Scene_main' then
        CtrlManager.OpendCtrl(CtrlNames.ScencePlayer)
        CtrlManager.CloseCtrl(CtrlNames.Login)
    end
    scenceMgr:CloseLoading()
end

function Main.OnApplicationQuit()
    logWarn('OnApplicationQuit')
end
