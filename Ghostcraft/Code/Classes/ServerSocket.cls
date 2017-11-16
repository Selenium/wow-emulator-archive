VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsServerSocket"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
'----------------------------------------------------------------------
' Visual Basic Game Programming With DirectX
' Chapter 16 : Multiplayer Programming With Windows Sockets
' ServerSocket Class Source Code File
'----------------------------------------------------------------------

Option Explicit
Option Base 0

'socket server events
Public Event DataArrival(ByVal lIndex As Long, _
    ByVal lTotalBytes As Long, ByVal sIncoming As String)
Public Event ServerConnectionRequest(ByVal lRequestID As Long)

Const MAXSOCKETS As Long = 255

'define the winsock control form
Dim WithEvents frm As frmLink
Attribute frm.VB_VarHelpID = -1

Dim sIncoming As String
Dim lCurrentLink As Long

'initialize the form
Private Sub Class_Initialize()
    Dim n As Long
    
    Set frm = New frmLink
    
    For n = 1 To MAXSOCKETS
        Load frm.link(n)
    Next n
End Sub

Private Sub Class_Terminate()
    Set frm = Nothing
End Sub

Public Function UserCount()
    Dim n As Long
    Dim total As Long
    
    For n = 0 To MAXSOCKETS - 1
        If Connected(n) Then total = total + 1
    Next n
    
    UserCount = total
End Function

Public Function OpenConnection(ByVal lRequestID As Long, _
    ByVal lPort As Long) As Long
    Dim lSocket As Long
    Dim n As Long
    
    On Error GoTo error1
    
    'look for an available socket
    lSocket = -1
    For n = 0 To MAXSOCKETS - 1
        If Not Connected(n) Then
            lSocket = n
            Exit For
        End If
    Next n
    
    'make sure it worked
    If lSocket = -1 Then
        OpenConnection = -1
        Exit Function
    End If
    
    'set up the socket
    Debug.Print "Connecting socket " & lSocket
    frm.link(lSocket).Close
    frm.link(lSocket).LocalPort = lPort
    frm.link(lSocket).Accept lRequestID
    CurrentLink = lSocket
    OpenConnection = lSocket
    Exit Function
    
error1:
    MsgBox Err.Number & ": " & Err.Description
End Function

Public Sub CloseConnection(ByVal Index&)
    frm.link(Index).Close
End Sub

Public Property Get RemoteHostIP() As String
    RemoteHostIP = frm.link(CurrentLink).RemoteHostIP
End Property

Public Property Get RemotePort() As String
    RemotePort = frm.link(CurrentLink).RemotePort
End Property

Public Property Get LocalIP() As String
    LocalIP = frm.link(CurrentLink).LocalIP
End Property

Public Property Get LocalPort() As Long
    LocalPort = frm.tcpServer.LocalPort
End Property

Public Property Get State() As Long
    State = frm.link(CurrentLink).State
End Property

Public Function Connected(ByVal Index As Long) As Boolean
    Connected = (frm.link(Index).State = sckConnected)
End Function

Public Sub Send(ByVal Index As Long, ByRef msg() As Byte)
    If Connected(Index) Then
        frm.link(Index).SendData msg
    End If
End Sub

Public Sub OpenServer(ByVal Port As Long)
    frm.tcpServer.LocalPort = Port
    frm.tcpServer.Listen
End Sub

Public Sub CloseServer()
    frm.tcpServer.Close
End Sub

Private Sub frm_DataArrival(ByVal Index&, ByVal bytesTotal As Long, _
    ByVal sData$)
    CurrentLink = Index
    RaiseEvent DataArrival(Index, bytesTotal, sData)
End Sub

Private Sub frm_ServerConnectionRequest(ByVal requestID As Long)
    RaiseEvent ServerConnectionRequest(requestID)
End Sub

Private Sub frm_SocketError(ByVal Index&, ByVal Number As Long, _
    ByVal Description As String)
    Debug.Print "SocketError: " & Number & " " & Description
End Sub

Public Property Get CurrentLink() As Long
    CurrentLink = lCurrentLink
End Property

Public Property Let CurrentLink(ByVal vNewValue As Long)
    lCurrentLink = vNewValue
End Property

Public Sub Delay(ByVal ms As Long)
    Dim lStart As Long
    lStart = GetTickCount
    Do Until GetTickCount > lStart + ms
        DoEvents
    Loop
End Sub


