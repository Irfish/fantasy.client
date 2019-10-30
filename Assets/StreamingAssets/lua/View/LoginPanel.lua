local transform;
local gameObject;

LoginPanel = {};
local this = LoginPanel;

--启动事件--
function LoginPanel.Awake(obj)
	gameObject = obj;
    transform = obj.transform;
    logWarn("Awake lua--->>"..gameObject.name);
    this.InitPanel();
end

--初始化面板--
function LoginPanel.InitPanel()
    this.btnLogin = transform:Find('Account/BtnLogin').gameObject;
    this.btnRegister = transform:Find("Account/BtnRegister").gameObject;
    this.BtnGetCode = transform:Find("Account/BtnGetCode").gameObject;
    this.Password = transform:Find("Account/Password").gameObject;
    this.Code = transform:Find("Account/Code").gameObject;
    this.PhoneNumber = transform:Find("Account/PhoneNumber").gameObject;
    this.toggleLogin = transform:Find("Account/ToggleGroup/Login").gameObject;
   
end



--单击事件--
function LoginPanel.OnDestroy()
	logWarn("OnDestroy---->>>");
end

