VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "mswinsck.ocx"
Begin VB.Form frmWSSetup 
   BackColor       =   &H00E0E0E0&
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "WSSetup"
   ClientHeight    =   2895
   ClientLeft      =   6450
   ClientTop       =   2925
   ClientWidth     =   3690
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   2895
   ScaleWidth      =   3690
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton cmdWSRun 
      Caption         =   "Run aWoWe's World Server"
      Default         =   -1  'True
      Height          =   375
      Left            =   120
      TabIndex        =   9
      Top             =   2400
      Width           =   3375
   End
   Begin VB.Frame frmWorld 
      BackColor       =   &H00E0E0E0&
      Caption         =   "World Server Setup"
      Height          =   2175
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3375
      Begin VB.TextBox txtWSName 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   120
         TabIndex        =   3
         Text            =   "aWoWe Powered Test Realm"
         Top             =   1200
         Width           =   3135
      End
      Begin VB.TextBox txtWSIP 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   720
         TabIndex        =   2
         Text            =   "autoselect"
         Top             =   240
         Width           =   2535
      End
      Begin VB.TextBox txtWSPort 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   720
         TabIndex        =   1
         Text            =   "8085"
         Top             =   600
         Width           =   2535
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Realm Name:"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   8
         Top             =   960
         Width           =   975
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "IP:"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   7
         Top             =   360
         Width           =   975
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Port:"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   6
         Top             =   600
         Width           =   975
      End
      Begin VB.Label lblStatus 
         BackStyle       =   0  'Transparent
         Caption         =   "0 players online"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   1560
         Width           =   3135
      End
      Begin VB.Label lblWSStatus 
         BackStyle       =   0  'Transparent
         Caption         =   "World Server OFFLINE"
         ForeColor       =   &H000000FF&
         Height          =   255
         Left            =   120
         TabIndex        =   4
         Top             =   1800
         Width           =   3135
      End
   End
   Begin MSWinsockLib.Winsock WS 
      Index           =   0
      Left            =   3600
      Top             =   120
      _ExtentX        =   741
      _ExtentY        =   741
      _Version        =   393216
      LocalPort       =   3725
   End
End
Attribute VB_Name = "frmWSSetup"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdWSRun_Click()
    frmWSSetup.lblWSStatus = "World Server ONLINE"
    WS(0).LocalPort = txtWSPort.text
    WS(0).Listen
    System.LOG "Server started listening on " & WS(0).LocalIP & ":" & WS(0).LocalPort
    frmWSSetup.txtWSIP.text = WS(0).LocalIP
End Sub

Private Sub Command1_Click()

End Sub

Private Sub Form_Load()
    frmWSSetup.Left = frmLog.Width
    frmWSSetup.Top = frmMain.Height
End Sub

Private Sub WS_Close(Index As Integer)
    WS(Index).Close
    OpenSocketsWS(Index) = False
    LOG "  WS," & Index & " [" & WS(Index).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Disconected [Client]"
    If WS(Index).Tag <> -1 Then
        'this handle if in realm list client try to connect 2 times
        If Users(WS(Index).Tag).WS = True Then Users(WS(Index).Tag).Acc = ""
    End If
End Sub

Private Sub WS_ConnectionRequest(Index As Integer, ByVal requestID As Long)
    Dim i As Integer
    For i = 1 To UBound(OpenSocketsWS)
        If OpenSocketsWS(i) = False Then
            WS(i).Accept requestID
            OpenSocketsWS(i) = True
            LOG "  WS," & i & " [" & WS(i).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Incoming connection"
            WS(i).Tag = -1
            WSFunctions.Send_SMSG_AUTH_CHALLENGE i
            Exit Sub
        End If
    Next i
    ReDim Preserve OpenSocketsWS(i)
    Load WS(i)
    WS(i).LocalPort = txtWSPort.text
    WS(i).Accept requestID
    OpenSocketsWS(i) = True
    LOG "  WS," & i & " [" & WS(i).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Incoming connection"
    WS(i).Tag = -1
    WSFunctions.Send_SMSG_AUTH_CHALLENGE i
End Sub

Private Sub WS_DataArrival(Index As Integer, ByVal bytesTotal As Long)
    Dim data() As Byte
    WS(Index).GetData data, vbArray + vbByte
    
    WSPacketAnalyzer.Analyze Index, data
End Sub

Private Sub WS_Error(Index As Integer, ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
    WS(Index).Close
    OpenSocketsWS(Index) = False
    LOG "  WS," & Index & " [" & WS(Index).RemoteHostIP & ":" & WS(Index).RemotePort & "] - Disconected [Error on this connection!!!]"
    If WS(Index).Tag <> -1 Then Users(WS(Index).Tag).Acc = ""
End Sub
