VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmLink 
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Visible         =   0   'False
   Begin MSWinsockLib.Winsock link 
      Index           =   0
      Left            =   225
      Top             =   180
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin MSWinsockLib.Winsock tcpClient 
      Left            =   780
      Top             =   180
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
   Begin MSWinsockLib.Winsock tcpServer 
      Left            =   1320
      Top             =   180
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
   End
End
Attribute VB_Name = "frmLink"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'----------------------------------------------------------------------
' Visual Basic Game Programming With DirectX
' Chapter 16 : Multiplayer Programming With Windows Sockets
' frmLink Source Code File
'----------------------------------------------------------------------

Option Explicit
Option Base 0

'public events passed on by the Winsock controls
Public Event SocketError(ByVal lIndex As Long, ByVal lNumber As Long, _
    ByVal sDescription As String)
Public Event ConnectionClosed(ByVal lIndex As Long)
Public Event ServerConnectionRequest(ByVal lRequestID As Long)
Public Event ClientDataArrival(ByVal lTotalBytes As Long, _
    ByVal sData As String)
Public Event DataArrival(ByVal lIndex As Long, _
    ByVal lTotalBytes As Long, ByVal sData As String)

'the sole tcpClient event
Private Sub tcpClient_DataArrival(ByVal lTotalBytes As Long)
    Dim sIncoming As String
    tcpClient.GetData sIncoming, vbString
    RaiseEvent ClientDataArrival(lTotalBytes, sIncoming)
End Sub

'the sole tcpServer event
Private Sub tcpServer_ConnectionRequest(ByVal lRequestID As Long)
    RaiseEvent ServerConnectionRequest(lRequestID)
End Sub

'remaining events are for the control array
Private Sub link_DataArrival(lIndex As Integer, ByVal lTotalBytes As Long)
    Dim sIncoming$
    link(lIndex).GetData sIncoming, vbString
    RaiseEvent DataArrival(lIndex, lTotalBytes, sIncoming)
End Sub

Private Sub link_Close(lIndex As Integer)
    RaiseEvent ConnectionClosed(lIndex)
End Sub

Private Sub link_Error(Index As Integer, ByVal Number As Integer, _
    Description As String, ByVal Scode As Long, ByVal Source As String, _
    ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
    RaiseEvent SocketError(Index, Number, Description)
End Sub



