require 'Common/define'
require "3rd/pblua/login_pb"
require "3rd/pblua/message_pb"
require "3rd/pblua/user_authentication_pb"
require "3rd/pblua/create_room_pb"



local json = require 'cjson'
ScencePieceCtrl = {}
local this = ScencePieceCtrl

local ScencePiece
local transform
local gameObject

--构建函数
function ScencePieceCtrl.New()
    return this
end

function ScencePieceCtrl.Awake()
    panelMgr:CreatePanel('ScencePiece', this.OnCreate)
end

--启动事件
function ScencePieceCtrl.OnCreate(obj)
    gameObject = obj
    ScencePiece = gameObject:GetComponent('LuaBehaviour')
    ScencePiece:AddClick(ScencePiecePanel.btnLobby, this.OnClickBtnLobby)
    ScencePiece:AddClick(ScencePiecePanel.board, this.OnClickBoard)
    ScencePiece:AddClick(ScencePiecePanel.btnReady, this.OnClickBtnReady)
end

function ScencePieceCtrl.OnClickBtnLobby(go)
    scenceMgr:LoadSence(ScenceName.Lobby)
end

function ScencePieceCtrl.OnClickBtnReady(go)
    local cts = create_room_pb.CtsCreateRoom()
    cts.userId = PlayerPrefs.GetInt("UserId")
    local msg = ByteBuffer.New();
    msg:WriteBuffer(cts:SerializeToString());
    networkMgr:SendToGame(msg,8);
end

--校验坐标
function ScencePieceCtrl.checkP(p)
    --应为UI的中心点与board的中心点一致
    local board_x = 708 / 2 --board 宽 的一半
    local board_y = 710 / 2 --board 高 的一半
    local step_x = 37 --item 宽
    local step_y = 36 --item 高
    --如果网格有程序生成则不需要 offset
    local offset_x = 6
    local offset_y = 15

    local x = p.x + board_x

    local y = p.y + board_y

    local cx = math.modf(x / step_x)
    --鼠标点击到两个点中间，则采用四色五入的方式处理
    local lx = math.fmod(x, 36)
    if lx > step_x / 2 then
        cx = cx + 1
    end

    local cy = math.modf(y / step_y)

    local ly = math.fmod(y, 36)
    if ly > step_y / 2 then
        cy = cy + 1
    end

    local real_X = cx * step_x - board_x + offset_x
    local real_y = cy * step_y - board_y + offset_y
    return real_X, real_y
end

function ScencePieceCtrl.OnClickBoard(go)
    local v = ScencePiece:CurrMousePosition(go)
    log('CurrMousePosition x:' .. v.x .. ' y:' .. v.y)
    local x, y = this.checkP(v)
    v.x = x
    v.y = y
    local piece = GameObject.Instantiate(ScencePiecePanel.pieceItem)
    piece.transform:SetParent(ScencePiecePanel.board.transform)
    piece:GetComponent('RectTransform').anchoredPosition = v --需要校准坐标
    --piece:GetComponent('Image'):
    piece:SetActive(true)
    piece.transform.localScale = Vector3.one

    local cts = user_authentication_pb.CtsUserAuthentication();
    cts.userId =PlayerPrefs.GetInt("UserId")
    cts.token=PlayerPrefs.GetString("Token")
    cts.tokenExpireTime=PlayerPrefs.GetInt("TokenExpireTime")
    local msg = ByteBuffer.New();
    msg:WriteBuffer(cts:SerializeToString());
    networkMgr:SendToGw(msg,2);
end

--关闭事件
function ScencePieceCtrl.Close()
    panelMgr:ClosePanel('ScencePiece')
end
