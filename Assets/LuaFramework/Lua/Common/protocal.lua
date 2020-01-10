--Buildin Table
Protocal = {
	Connect		= '101';	--连接服务器
	Exception   = '102';	--异常掉线
	Disconnect  = '103';	--正常断线   
	Message		= '104';	--接收消息
}
--socket 消息id
MessageDefine = {
	Message ="0",
	StcErrorNotice ="1",
	CtsUserAuthentication ="2",
	StcUserAuthentication ="3",
	CtsUserEnter ="4",
	StcUserEnter ="5",
	CtsUserLeave ="6",
	StcUserLeave ="7",
	CtsCreateRoom ="8",
	StcCreateRoom ="9",
	CtsPlayPiece ="10",
	StcPlayPiece ="11",
	StcGameResult ="12",
	CtsUserReady ="13",
	StcUserReady ="14"
}

--服务器id
ServiceDefine = {
    DB=1;
    LOGIN=2;
    G001=3;
    GW=4;
}



