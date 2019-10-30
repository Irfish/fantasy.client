local transform;
local gameObject;

LoginPanel = {};
local this = LoginPanel;
local Login

--启动事件
function LoginPanel.Awake(obj)
	gameObject = obj;
    transform = obj.transform;
    Login = gameObject:GetComponent('LuaBehaviour')
    this.InitPanel();
end

--初始化面板
function LoginPanel.InitPanel()
    this.btnLogin = transform:Find('Account/BtnLogin').gameObject;
    this.btnRegister = transform:Find("Account/BtnRegister").gameObject;
    this.BtnGetCode = transform:Find("Account/BtnGetCode").gameObject;
    this.Password = transform:Find("Account/Password").gameObject;
    this.Code = transform:Find("Account/Code").gameObject;
    this.PhoneNumber = transform:Find("Account/PhoneNumber").gameObject;
    --控制显示
    this.toggleLogin = transform:Find("Account/ToggleGroup/Login").gameObject;
    Login:AddToggle(this.toggleLogin, this.OnToggleLogin)
end

function LoginPanel.ShowLogin(status)
    this.btnLogin:SetActive(status)
    this.Password:SetActive(status)
end

function LoginPanel.ShowRegister(status)
    this.Code:SetActive(status)
    this.BtnGetCode:SetActive(status)
    this.btnRegister:SetActive(status)
end

function LoginPanel.OnToggleLogin(go, select)
    if select then
        this.ShowLogin(true)
        this.ShowRegister(false)
    else
        this.ShowRegister(true)
        this.ShowLogin(false)
    end
end

--单击事件
function LoginPanel.OnDestroy()
	logWarn("OnDestroy---->>>");
end

