require 'Common/define'
LoginCtrl = {}
local this = LoginCtrl

local Login
local transform
local gameObject

--构建函数    --
function LoginCtrl.New()
    logWarn('LoginCtrl.New--->>')
    return this
end

function LoginCtrl.Awake()
    logWarn('LoginCtrl.Awake--->>')
    panelMgr:CreatePanel('Login', this.OnCreate)
end

--启动事件    --
function LoginCtrl.OnCreate(obj)
    gameObject = obj
    Login = gameObject:GetComponent('LuaBehaviour')
    Login:AddClick(LoginPanel.btnLogin, this.OnClickLogin)
    Login:AddClick(LoginPanel.btnRegister, this.OnClickRegister)
    Login:AddToggle(LoginPanel.toggleLogin, this.OnToggleLogin)
end

--单击事件    --
function LoginCtrl.OnClickLogin(go)
    local pwd = LoginPanel.Password:GetComponent("InputField")
    local acc = LoginPanel.PhoneNumber:GetComponent("InputField")
    if pwd then
        logWarn("pwd:"..pwd.name)
        print("OnClickLogin:"..pwd)
    end
    local f = Util.GetWwwFrom()
    f:AddField('accountId', acc.text)
    f:AddField('password', pwd.text)
    Util.HttpPost('/post/login', f, 'LoginCtrl', 'HttpLoginCallBack')
end

function LoginCtrl.OnClickRegister(go)
end

function LoginCtrl.ShowLogin(status)
    LoginPanel.btnLogin:SetActive(status)
    LoginPanel.Password:SetActive(status)
end

function LoginCtrl.ShowRegister(status)
    LoginPanel.Code:SetActive(status)
    LoginPanel.BtnGetCode:SetActive(status)
    LoginPanel.btnRegister:SetActive(status)
end

function LoginCtrl.OnToggleLogin(go, select)
    if select then
        this.ShowLogin(true)
        this.ShowRegister(false)
    else
        this.ShowRegister(true)
        this.ShowLogin(false)
    end
end

function LoginCtrl.HttpLoginCallBack(data)
    logError('Http_Login_CallBack:' .. data)
    -- AppConst.SocketPort = 2012;
    -- AppConst.SocketAddress = "127.0.0.1";
    -- networkMgr:SendConnect();
end

--关闭事件    --
function LoginCtrl.Close()
    panelMgr:ClosePanel(CtrlNames.Login)
end
