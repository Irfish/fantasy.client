require 'Common/define'
local json = require 'cjson'
LoginCtrl = {}
local this = LoginCtrl

local Login
local transform
local gameObject

--构建函数
function LoginCtrl.New()
    return this
end

function LoginCtrl.Awake()
    panelMgr:CreatePanel('Login', this.OnCreate)
end

--启动事件
function LoginCtrl.OnCreate(obj)
    gameObject = obj
    Login = gameObject:GetComponent('LuaBehaviour')
    Login:AddClick(LoginPanel.btnLogin, this.OnClickLogin)
    Login:AddClick(LoginPanel.btnRegister, this.OnClickRegister)
end

--单击事件
function LoginCtrl.OnClickLogin(go)
    local pwd = LoginPanel.Password:GetComponent('InputField')
    local acc = LoginPanel.PhoneNumber:GetComponent('InputField')
    local f = Util.GetWwwFrom()
    f:AddField('accountId', acc.text)
    f:AddField('password', pwd.text)
    Util.HttpPost('/post/login', f, 'LoginCtrl', 'HttpLoginCallBack')
end

function LoginCtrl.HttpLoginCallBack(data)
    -- local res = json.decode(data)
    -- if res.status then
    --     AppConst.SocketPort = res.gw[2]
    --     AppConst.SocketAddress = res.gw[1]
    --     networkMgr:SendConnect()
    -- else
    --     logError('Http_Login_CallBack:' .. res.err)
    -- end
    scenceMgr:LoadSence('Scene_main')
end

function LoginCtrl.OnClickRegister(go)
end

--关闭事件
function LoginCtrl.Close()
    panelMgr:ClosePanel('Login')
end
