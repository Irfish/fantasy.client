local transform
local gameObject

ScencePiecePanel = {}
local this = ScencePiecePanel
local ScencePiece
--local pieceItemStartPosition = Vector2(4, 4)
--local step = 36
--启动事件
function ScencePiecePanel.Awake(obj)
    gameObject = obj
    transform = obj.transform
    ScencePiece = gameObject:GetComponent('LuaBehaviour')
    this.InitPanel()
end

--初始化面板
function ScencePiecePanel.InitPanel()
    this.btnLobby = transform:Find('BtnLobby').gameObject
    this.pieceItem = transform:Find('Piece/FireItem').gameObject
    this.board = transform:Find('Piece/Board').gameObject
end

--单击事件
function ScencePiecePanel.OnDestroy()
    logWarn('OnDestroy---->>>')
end
