CtrlNames = {
    Login = 'LoginCtrl',
    Lobby = 'LobbyCtrl',
    ScencePlayer = 'ScencePlayerCtrl',
    ScencePiece= 'ScencePieceCtrl',
}

PanelNames = {
    'LoginPanel',
    'LobbyPanel',
    'ScencePlayerPanel',
    'ScencePiecePanel',
}

ScenceName={
    UI="Scene_UI",
    Lobby="Scene_Lobby",
    Main="Scene_Main",
    Piece="Scene_Piece",
    XueDi="WorldScene_XueDi",
    DaShanGu="WorldScene_DaShanGu"
}

--协议类型
ProtocalType = {
    BINARY = 0,
    PB_LUA = 1,
    PBC = 2,
    SPROTO = 3
}
--当前使用的协议类型
TestProtoType = ProtocalType.BINARY

GameObject = UnityEngine.GameObject
Util = LuaFramework.Util
AppConst = LuaFramework.AppConst
ByteBuffer = LuaFramework.ByteBuffer

LuaHelper = LuaFramework.LuaHelper
resMgr = LuaHelper.GetResManager()
panelMgr = LuaHelper.GetPanelManager()
soundMgr = LuaHelper.GetSoundManager()
networkMgr = LuaHelper.GetNetManager()
scenceMgr = LuaHelper.GetMScenceManager()
