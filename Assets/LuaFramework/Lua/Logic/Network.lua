
require "Common/define"
require "Common/protocal"
require "Common/functions"
Event = require 'events'

require "3rd/pblua/login_pb"
require "3rd/pbc/protobuf"
require "3rd/pblua/user_authentication_pb"
require "3rd/pblua/error_notice_pb"


local sproto = require "3rd/sproto/sproto"
local core = require "sproto.core"
local print_r = require "3rd/sproto/print_r"

Network = {};
local this = Network;

local transform;
local gameObject;
local islogging = false;

function Network.Start() 
    logWarn("Network.Start!!");
    Event.AddListener(Protocal.Connect, this.OnConnect); 
    Event.AddListener(Protocal.Message, this.OnMessage); 
    Event.AddListener(Protocal.Exception, this.OnException); 
    Event.AddListener(Protocal.Disconnect, this.OnDisconnect); 
end

--Socket消息--
function Network.OnSocket(key, data)
    Event.Brocast(tostring(key), data);
end

--当连接建立时--
function Network.OnConnect() 
    logWarn("Game Server connected!!");
    scenceMgr:LoadSence(ScenceName.Lobby)
end

--异常断线--
function Network.OnException() 
    islogging = false; 
    NetManager:SendConnect();
   	logError("OnException------->>>>");
end

--连接中断，或者被踢掉--
function Network.OnDisconnect() 
    islogging = false; 
    logError("OnDisconnect------->>>>");
end

--socket消息返回--
function Network.OnMessage(buffer) 
    local protocal = buffer:ReadInt();
    local data = buffer:ReadBuffer();
    logWarn('OnMessage-------->>>'..protocal);
    if protocal==1 then
        local msg = error_notice_pb.StcErrorNotice();
        msg:ParseFromString(data);
        logWarn('error_notice_pb: protocal:>'..protocal..' msg:>'..msg.info);
    else
        local msg = user_authentication_pb.StcUserAuthentication();
        msg:ParseFromString(data);
        PlayerPrefs.SetString("SessionId",msg.sessionId);
        logWarn('user_authentication_pb: protocal:>'..protocal..' msg:>'..msg.result.." sessionId:"..msg.sessionId);
    end
	-- ----------------------------------------------------
    local ctrl = CtrlManager.GetCtrl(CtrlNames.Message);
    if ctrl ~= nil then
        ctrl:Awake();
    end
    
end

--卸载网络监听--
function Network.Unload()
    Event.RemoveListener(Protocal.Connect);
    Event.RemoveListener(Protocal.Message);
    Event.RemoveListener(Protocal.Exception);
    Event.RemoveListener(Protocal.Disconnect);
    logWarn('Unload Network...');
end