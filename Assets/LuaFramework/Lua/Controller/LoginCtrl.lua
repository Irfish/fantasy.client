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
    local UserId = PlayerPrefs.GetInt("UserId")
    if UserId then
        local acc = LoginPanel.PhoneNumber:GetComponent('InputField')
        acc.text = UserId
    end
end

--单击事件
function LoginCtrl.OnClickLogin(go)
    local pwd = LoginPanel.Password:GetComponent('InputField')
    local acc = LoginPanel.PhoneNumber:GetComponent('InputField')
    local f = Util.GetWwwFrom()
    f:AddField('accountId', acc.text)
    f:AddField('password', pwd.text)
    Util.HttpPost('/post/login', f, 'LoginCtrl', 'HttpLoginCallBack')
    --scenceMgr:LoadSence(ScenceName.Lobby)
end

function LoginCtrl.HttpLoginCallBack(data)
    local res = json.decode(data)
    if res.status then
        PlayerPrefs.SetInt("SessionId",0);
        PlayerPrefs.SetInt("UserId",res.userId);
        PlayerPrefs.SetString("Token",res.token);
        PlayerPrefs.SetInt("TokenExpireTime",res.expireTime);
        AppConst.SocketPort = res.gw[2]
        AppConst.SocketAddress = res.gw[1]
        networkMgr:SendConnect()
    else
        logError('Http_Login_CallBack:' .. res.err)
    end
    --scenceMgr:LoadSence(ScenceName.Lobby)
end

function LoginCtrl.OnClickRegister(go)
    local f = Util.GetWwwFrom()
    f:AddField('userName', "小小")
    f:AddField('pwd', "123456")
    Util.HttpPost('/post/user_register', f, 'LoginCtrl', 'HttpLoginCallBack')
end

--关闭事件
function LoginCtrl.Close()
    panelMgr:ClosePanel('Login')
end
