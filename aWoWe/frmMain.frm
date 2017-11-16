VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "mswinsck.ocx"
Begin VB.Form frmMain 
   BackColor       =   &H00E0E0E0&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "RSSetup"
   ClientHeight    =   3480
   ClientLeft      =   7440
   ClientTop       =   2505
   ClientWidth     =   3645
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   3480
   ScaleWidth      =   3645
   ShowInTaskbar   =   0   'False
   Begin MSWinsockLib.Winsock RS 
      Index           =   0
      Left            =   3600
      Top             =   240
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
      LocalPort       =   3724
   End
   Begin VB.CommandButton cmdRSRun 
      Caption         =   "Run aWoWe's Realm Server"
      Default         =   -1  'True
      Height          =   375
      Left            =   120
      TabIndex        =   10
      Top             =   3000
      Width           =   3375
   End
   Begin VB.Frame frmRealm 
      BackColor       =   &H00E0E0E0&
      Caption         =   "Realm Server Setup"
      Height          =   2775
      Left            =   120
      TabIndex        =   2
      Top             =   120
      Width           =   3375
      Begin VB.CheckBox chkOnline 
         Alignment       =   1  'Right Justify
         BackColor       =   &H00E0E0E0&
         Caption         =   "Online?"
         Height          =   255
         Left            =   2160
         TabIndex        =   12
         Top             =   1080
         Width           =   1095
      End
      Begin VB.TextBox txtRSPort 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   720
         TabIndex        =   9
         Text            =   "3724"
         Top             =   600
         Width           =   2535
      End
      Begin VB.TextBox txtRSIP 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   720
         TabIndex        =   8
         Text            =   "autoselect"
         Top             =   240
         Width           =   2535
      End
      Begin VB.TextBox txtWSInput 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   120
         TabIndex        =   5
         Text            =   "192.168.0.2:8085"
         Top             =   1440
         Width           =   3135
      End
      Begin VB.Label Label2 
         BackStyle       =   0  'Transparent
         Caption         =   "World Server's IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   11
         Top             =   1080
         Width           =   2055
      End
      Begin VB.Label lblRSStatus 
         BackStyle       =   0  'Transparent
         Caption         =   "Realm Server OFFLINE"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   2040
         Width           =   3135
      End
      Begin VB.Label lblStatus 
         BackStyle       =   0  'Transparent
         Caption         =   "0 world servers selected"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   1800
         Width           =   3135
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Port:"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   4
         Top             =   600
         Width           =   975
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "IP:"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   3
         Top             =   360
         Width           =   975
      End
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Test LOGON_PROOF"
      Height          =   375
      Left            =   4200
      TabIndex        =   1
      Top             =   600
      Width           =   2175
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Test PublicB Generation"
      Height          =   375
      Left            =   4200
      TabIndex        =   0
      Top             =   120
      Width           =   2175
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub chkEnableWS_Click()

End Sub

Private Sub cmdAddWS_Click()

End Sub

Private Sub cmdRemWS_Click()

End Sub

Private Sub chkOnline_Click()
    RSPacketAnalyzer.UpdateRealms
End Sub

Private Sub cmdRSRun_Click()
    RSPacketAnalyzer.UpdateRealms
    frmMain.lblRSStatus = "Realm Server ONLINE"
    RS(0).LocalPort = txtRSPort.text
    RS(0).Listen
    System.LOG "Server started listening on " & RS(0).LocalIP & ":" & RS(0).LocalPort
    frmMain.txtRSIP.text = RS(0).LocalIP
End Sub

Private Sub Command1_Click()
    Users(Users_Count).Acc = "TEST"
    Get_Acc_Data 0
    Send_Client_LOGON_CHALLENGE 1, (0)
End Sub

Private Sub Command2_Click()
    Dim a As String
    Dim M1 As String
    a = UCase("232fb1b88529643d95b8dce78f2750c75b2df37acba873eb31073839eda0738d")
    M1 = UCase("eeb4adca80f4de02f9a9fe8d000d682e3ddfad6f")
    Send_Client_LOGON_PROOF a, M1, 1, 0
End Sub

Private Sub Command3_Click()

End Sub

Private Sub Form_Load()
    frmMain.Left = frmLog.Width
    frmMain.Top = frmLog.Top
End Sub

Private Sub lstWSs_Click()
End Sub

Private Sub RS_Close(Index As Integer)
    RS(Index).Close
    OpenSockets(Index) = False
    LOG "  RS," & Index & " [" & RS(Index).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Disconected [Client]"
    If RS(Index).Tag <> -1 Then Users(RS(Index).Tag).Acc = ""
End Sub

Private Sub RS_ConnectionRequest(Index As Integer, ByVal requestID As Long)
    Dim i As Integer
    For i = 1 To UBound(OpenSockets)
        If OpenSockets(i) = False Then
            RS(i).Accept requestID
            OpenSockets(i) = True
            LOG "  RS," & i & " [" & RS(i).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Incoming connection"
            RS(i).Tag = -1
            Exit Sub
        End If
    Next i
    ReDim Preserve OpenSockets(i)
    Load RS(i)
    RS(i).LocalPort = txtRSPort.text
    RS(i).Accept requestID
    OpenSockets(i) = True
    LOG "  RS," & i & " [" & RS(i).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Incoming connection"
    RS(i).Tag = -1
End Sub

Private Sub RS_DataArrival(Index As Integer, ByVal bytesTotal As Long)
    Dim data() As Byte
    RS(Index).GetData data, vbArray + vbByte
    
    RSPacketAnalyzer.Analyze Index, data
End Sub

Private Sub RS_Error(Index As Integer, ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
    RS(Index).Close
    OpenSockets(Index) = False
    LOG "  RS," & Index & " [" & RS(Index).RemoteHostIP & ":" & RS(Index).RemotePort & "] - Disconected [Error on this connection!!!]"
    If RS(Index).Tag <> -1 Then Users(RS(Index).Tag).Acc = ""
End Sub
