VERSION 5.00
Begin VB.Form frmMain 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "((title))"
   ClientHeight    =   4455
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8100
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   297
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   540
   StartUpPosition =   2  'CenterScreen
   Begin VB.Timer tmrUpdatesSeconds 
      Enabled         =   0   'False
      Left            =   7080
      Top             =   3960
   End
   Begin VB.Timer tmrWorldTime 
      Enabled         =   0   'False
      Left            =   120
      Top             =   3960
   End
   Begin VB.TextBox txtOutput 
      BeginProperty Font 
         Name            =   "Courier New"
         Size            =   8.25
         Charset         =   177
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3855
      Left            =   0
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   0
      TabStop         =   0   'False
      Top             =   0
      Width           =   8085
   End
   Begin VB.Timer tmrLogoutSeconds 
      Enabled         =   0   'False
      Left            =   7560
      Top             =   3960
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Option Base 0

Public WithEvents serverREALM As clsServerSocket
Attribute serverREALM.VB_VarHelpID = -1
Public WithEvents serverLOGIN As clsServerSocket
Attribute serverLOGIN.VB_VarHelpID = -1
Public WithEvents serverWORLD As clsServerSocket
Attribute serverWORLD.VB_VarHelpID = -1

Private Sub Form_Load()

    Me.Caption = "GhostCraft WoW Server <" & App.Major & "." & App.Minor & "." & App.Revision & ">"
    Set serverREALM = New clsServerSocket
    Set serverLOGIN = New clsServerSocket
    Set serverWORLD = New clsServerSocket

    serverREALM.OpenServer 3724
    serverLOGIN.OpenServer 9090
    serverWORLD.OpenServer 8086

    PrintOut "Servers set up and ready to go!"
    tmrLogoutSeconds.Interval = 1000
    tmrLogoutSeconds.Enabled = True

    tmrUpdatesSeconds.Interval = 1000
    tmrUpdatesSeconds.Enabled = True

    WorldTime = 0
    tmrWorldTime.Interval = 60000
    tmrWorldTime.Enabled = True
End Sub

Private Sub serverLOGIN_ServerConnectionRequest(ByVal requestID As Long)
    Dim lCount As Long
    Dim msgArray() As Byte

    lCount = serverLOGIN.OpenConnection(requestID, serverLOGIN.LocalPort)

    PrintOut "LOGIN #" & lCount & " at " & _
            serverLOGIN.RemoteHostIP & " on port " & _
            serverLOGIN.RemotePort

    AddStringToArray msgArray, "127.0.0.1:8086"

    frmMain.serverLOGIN.Send lCount, msgArray

    frmMain.serverLOGIN.Delay 10

    frmMain.serverLOGIN.CloseConnection lCount

End Sub

Private Sub serverWORLD_ConnectedClosed(ByVal LinkNumber As Long)
    ACCOUNT_LogOut LinkNumber
    serverWORLD.CloseConnection LinkNumber
End Sub

Private Sub serverWORLD_ServerConnectionRequest(ByVal requestID As Long)
    Dim lCount As Long
    Dim msgArray() As Byte, msgLength() As Byte

    lCount = serverWORLD.OpenConnection(requestID, serverWORLD.LocalPort)

    PrintOut "WORLD #" & lCount & " at " & _
            serverWORLD.RemoteHostIP & " on port " & _
            serverWORLD.RemotePort

    AddNetCodeIntegerToArray msgArray, &HDE01
    AddNetCodeIntegerToArray msgArray, &H0
    AddLongToArray msgArray, &H0

    AddNetCodeIntegerToArray msgLength, UBound(msgArray)

    frmMain.serverWORLD.Send lCount, msgLength
    frmMain.serverWORLD.Send lCount, msgArray

End Sub

Private Sub serverWORLD_DataArrival(ByVal link As Long, _
    ByVal bytesTotal As Long, ByVal ReceiveString As String)

    WORLD_ParsePacket ReceiveString, link

End Sub

Private Sub serverREALM_ServerConnectionRequest(ByVal requestID As Long)
    Dim lCount As Long

    lCount = serverREALM.OpenConnection(requestID, serverREALM.LocalPort)

    PrintOut "REALM client #" & lCount & " at " & _
            serverREALM.RemoteHostIP & " on port " & _
            serverREALM.RemotePort

End Sub

Private Sub serverREALM_DataArrival(ByVal link As Long, _
    ByVal bytesTotal As Long, ByVal ReceiveString As String)

    REALM_ParsePacket ReceiveString, link

End Sub

Public Sub PrintOut(ByVal msg$)
    txtOutput.Text = "[" & Time & "] " & msg$ & vbCrLf & _
            txtOutput.Text
End Sub

Public Sub PrintChar(ByVal char$)
    txtOutput.Text = txtOutput.Text & char$
End Sub

Private Sub Form_Unload(Cancel As Integer)
    serverREALM.CloseServer
    End
End Sub

Private Sub tmrLogoutSeconds_Timer()
    Dim i As Long, msgArray() As Byte
    Dim tmpLogoutList As tLogoutList
    Static MissedCount As Long

    MissedCount = MissedCount + 1
    If bChangingLogoutList = True Then Exit Sub

    For i = 1 To LogoutList.Count
        LogoutList.Players(i).LogoutTimeLeft = LogoutList.Players(i).LogoutTimeLeft - 1
        If LogoutList.Players(i).LogoutTimeLeft = 0 Then
            AddLongToArray msgArray, &H4D
            WORLD_SendMessage ACCOUNT_GetLinkNumber(LogoutList.Players(i).GUID), msgArray
            ObjectManagement_RemovePlayerFromCollection LogoutList.Players(i).GUID
        Else
            tmpLogoutList.Count = tmpLogoutList.Count + 1
            ReDim Preserve tmpLogoutList.Players(tmpLogoutList.Count)
            tmpLogoutList.Players(tmpLogoutList.Count).GUID = LogoutList.Players(i).GUID
            tmpLogoutList.Players(tmpLogoutList.Count).LogoutTimeLeft = LogoutList.Players(i).LogoutTimeLeft
        End If
    Next i

    MissedCount = 0

    LogoutList = tmpLogoutList
End Sub

Private Sub tmrUpdatesSeconds_Timer()
    WORLD_SendUpdates
End Sub

Private Sub tmrWorldTime_Timer()
    Dim i As Long
    WorldTime = WorldTime + 1
    If WorldTime > 1532 Then WorldTime = 0

    For i = 1 To Accounts_LoggedIn.Count
        WORLD_UpdateGameTime Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber
    Next i

End Sub
