require "3rd/pbc/protobuf"

local lpeg = require "lpeg"

local json = require "cjson"
local util = require "3rd/cjson/util"

local sproto = require "3rd/sproto/sproto"
local core = require "sproto.core"
local print_r = require "3rd/sproto/print_r"

require "Logic/LuaClass"
require "Logic/CtrlManager"
require "Common/functions"

--管理器--
Game = {};
local this = Game;

local game; 
local transform;
local gameObject;

function Game.InitViewPanels()
	for i = 1, #PanelNames do
		require ("View/"..tostring(PanelNames[i]))
	end
end

--初始化完成，发送链接服务器信息--
function Game.OnInitOK()
    --注册LuaView--
    this.InitViewPanels();
    CtrlManager.Init();
    if AppConst.UserId=="" then
        CtrlManager.OpendCtrl(CtrlNames.Login)
    end
    scenceMgr:CloseLoading()
end

--销毁--
function Game.OnDestroy()
	--logWarn('OnDestroy--->>>');
end
