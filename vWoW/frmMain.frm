VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "MSWINSCK.OCX"
Begin VB.Form frmCore 
   Caption         =   "vWoW"
   ClientHeight    =   6600
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   10815
   LinkTopic       =   "Form1"
   ScaleHeight     =   6600
   ScaleWidth      =   10815
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame frmHTTP 
      Caption         =   "HTTP Server"
      Height          =   2055
      Left            =   7560
      TabIndex        =   31
      Top             =   4440
      Width           =   3135
      Begin VB.Timer tmrSendData 
         Index           =   0
         Left            =   480
         Top             =   1560
      End
      Begin MSWinsockLib.Winsock sckHT 
         Index           =   0
         Left            =   120
         Top             =   1560
         _ExtentX        =   741
         _ExtentY        =   741
         _Version        =   393216
      End
      Begin VB.CheckBox chkEnableWM 
         Caption         =   "Enable World Map"
         Height          =   255
         Left            =   120
         TabIndex        =   38
         Top             =   1320
         Value           =   1  'Checked
         Width           =   2895
      End
      Begin VB.CommandButton cmdHT 
         Caption         =   "Enable"
         Height          =   375
         Left            =   1080
         TabIndex        =   37
         Top             =   1560
         Width           =   1935
      End
      Begin VB.CheckBox chkLogRequests 
         Caption         =   "Log HTTP requests"
         Height          =   195
         Left            =   120
         TabIndex        =   36
         Top             =   1080
         Value           =   1  'Checked
         Width           =   2895
      End
      Begin VB.TextBox txtHTTPPort 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   33
         Text            =   "8080"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox txtHTTPIp 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1080
         TabIndex        =   32
         Top             =   360
         Width           =   1935
      End
      Begin VB.Label lblHTTPIp 
         Caption         =   "HTTP IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   35
         Top             =   360
         Width           =   855
      End
      Begin VB.Label lblHTTPPort 
         Caption         =   "HTTP Port:"
         Height          =   255
         Left            =   120
         TabIndex        =   34
         Top             =   720
         Width           =   855
      End
   End
   Begin VB.Frame frmWSList 
      Caption         =   "WorldServer List"
      Height          =   2055
      Left            =   3840
      TabIndex        =   19
      Top             =   4440
      Width           =   3615
      Begin VB.TextBox txtWSName 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   26
         Text            =   "vWoW EMU Server"
         Top             =   720
         Width           =   1935
      End
      Begin VB.CommandButton cmdAddWS 
         Caption         =   "Add Server"
         Height          =   375
         Left            =   1560
         TabIndex        =   24
         Top             =   1080
         Width           =   1935
      End
      Begin VB.TextBox txtWSList 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   23
         Top             =   360
         Width           =   1935
      End
      Begin VB.Label lblWSName 
         Caption         =   "Server Name:"
         Height          =   255
         Left            =   120
         TabIndex        =   25
         Top             =   720
         Width           =   1335
      End
      Begin VB.Label lblWSList 
         Caption         =   "World Server IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   22
         Top             =   360
         Width           =   1335
      End
      Begin VB.Label lblWSonline 
         Alignment       =   2  'Center
         Caption         =   "0"
         Height          =   255
         Left            =   1680
         TabIndex        =   21
         Top             =   1680
         Width           =   495
      End
      Begin VB.Label lblWServers 
         Caption         =   "World Servers loaded:"
         Height          =   255
         Left            =   120
         TabIndex        =   20
         Top             =   1680
         Width           =   1575
      End
   End
   Begin VB.Frame frmOptions 
      Caption         =   "Options and Server information"
      Height          =   2055
      Left            =   120
      TabIndex        =   11
      Top             =   4440
      Width           =   3615
      Begin VB.CheckBox chkLogSave 
         Caption         =   "Log Saving / Loading"
         Height          =   255
         Left            =   1560
         TabIndex        =   39
         Top             =   1200
         Value           =   1  'Checked
         Width           =   1935
      End
      Begin VB.CommandButton cmdLoad 
         Caption         =   "Load"
         Height          =   375
         Left            =   1920
         TabIndex        =   30
         Top             =   720
         Width           =   1575
      End
      Begin VB.Timer timSaver 
         Interval        =   1000
         Left            =   480
         Top             =   960
      End
      Begin VB.TextBox txtSaver 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1800
         TabIndex        =   29
         Text            =   "30"
         Top             =   1560
         Width           =   1695
      End
      Begin VB.CommandButton cmdCharacterManager 
         Caption         =   "Character Manager"
         Height          =   375
         Left            =   1920
         TabIndex        =   27
         Top             =   240
         Width           =   1575
      End
      Begin VB.Timer timSaveTime 
         Enabled         =   0   'False
         Interval        =   1
         Left            =   0
         Top             =   960
      End
      Begin VB.CommandButton cmdSave 
         Caption         =   "Save"
         Height          =   375
         Left            =   120
         TabIndex        =   13
         Top             =   720
         Width           =   1455
      End
      Begin VB.CommandButton cmdAccountsManager 
         Caption         =   "Account Manager"
         Height          =   375
         Left            =   120
         TabIndex        =   12
         Top             =   240
         Width           =   1455
      End
      Begin VB.Label lblSaver 
         Caption         =   "Save every (seconds):"
         Height          =   375
         Left            =   120
         TabIndex        =   28
         Top             =   1560
         Width           =   1695
      End
   End
   Begin VB.Frame frmWorldServer 
      Caption         =   "WorldServer"
      Height          =   1575
      Left            =   3840
      TabIndex        =   10
      Top             =   2760
      Width           =   3615
      Begin MSWinsockLib.Winsock sckWS 
         Index           =   0
         Left            =   120
         Top             =   960
         _ExtentX        =   741
         _ExtentY        =   741
         _Version        =   393216
      End
      Begin VB.CommandButton cmdWS 
         Caption         =   "Enable"
         Height          =   375
         Left            =   1560
         TabIndex        =   18
         Top             =   1080
         Width           =   1935
      End
      Begin VB.TextBox txtWSIp 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   17
         Top             =   360
         Width           =   1935
      End
      Begin VB.TextBox txtWSPort 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   16
         Text            =   "3725"
         Top             =   720
         Width           =   1935
      End
      Begin VB.Label lblWSPort 
         Caption         =   "World Server Port:"
         Height          =   255
         Left            =   120
         TabIndex        =   15
         Top             =   720
         Width           =   1335
      End
      Begin VB.Label lblWSIp 
         Caption         =   "World Server IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   14
         Top             =   360
         Width           =   1335
      End
   End
   Begin VB.Frame frmDEBUG 
      Caption         =   "Packet DEBUG"
      Height          =   4215
      Left            =   7560
      TabIndex        =   8
      Top             =   120
      Width           =   3135
      Begin VB.TextBox txtDEBUG 
         Height          =   3855
         Left            =   120
         MultiLine       =   -1  'True
         TabIndex        =   9
         Top             =   240
         Width           =   2895
      End
   End
   Begin VB.Frame frmConsole 
      Caption         =   "Console"
      Height          =   2535
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   7335
      Begin VB.TextBox txtConsole 
         BackColor       =   &H00000000&
         BeginProperty Font 
            Name            =   "Lucida Console"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   2175
         Left            =   120
         Locked          =   -1  'True
         MultiLine       =   -1  'True
         TabIndex        =   4
         Top             =   240
         Width           =   7095
      End
   End
   Begin VB.Frame frmRealmServer 
      Caption         =   "RealmServer"
      Height          =   1575
      Left            =   120
      TabIndex        =   0
      Top             =   2760
      Width           =   3615
      Begin VB.CommandButton cmdRS 
         Caption         =   "Enable"
         Height          =   375
         Left            =   1560
         TabIndex        =   7
         Top             =   1080
         Width           =   1935
      End
      Begin MSWinsockLib.Winsock sckRS 
         Index           =   0
         Left            =   120
         Top             =   960
         _ExtentX        =   741
         _ExtentY        =   741
         _Version        =   393216
      End
      Begin VB.TextBox txtRSPort 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   2
         Text            =   "3724"
         Top             =   720
         Width           =   1935
      End
      Begin VB.TextBox txtRSIp 
         Appearance      =   0  'Flat
         Height          =   285
         Left            =   1560
         TabIndex        =   1
         Top             =   360
         Width           =   1935
      End
      Begin VB.Label lblRSPort 
         Caption         =   "Realm Server Port:"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   720
         Width           =   1455
      End
      Begin VB.Label lblRSIp 
         Caption         =   "Realm Server IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   5
         Top             =   360
         Width           =   1455
      End
   End
End
Attribute VB_Name = "frmCore"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'----------------------------------------
'---                                  ---
'--- This code is based on the Fusion ---
'--- Now called vWoW made by UniX :)  ---
'---                                  ---
'----------------------------------------



'Lets keep everything clear
Option Explicit
'EXTRA:Time used for saving
Public TimeUsed As Long
Public TimeTicked As Long

Public Enum IfStringNotFound
    ReturnOriginalStr = 0
    ReturnEmptyStr = 1
End Enum

' change this to your http server name
Private Const ServerName As String = "vWoW HTTP Server"

' this project was designed for only one share
' change the path to the directory you want to share
Public PathShared As String

Private Type ConnectionInfo
    FileNum As Integer  ' file number of the file opened on the current connection
    TotalLength As Long ' total length of data to send (including the header)
    TotalSent As Long   ' total data sent
    FileName As String  ' file name of the file to send
    
    DataStr As String
End Type

Private CInfo() As ConnectionInfo ' HTTP stuff

Private Sub cmdAccountsManager_Click()
frmAccountManager.Show ' Open Account Manager
End Sub

Private Sub cmdAddWS_Click()
    modRSPackets.UpdateRealms ' Add a World Server to the realm list
End Sub

Private Sub cmdCharacterManager_Click()
frmCharacterManager.Show ' Open the Character Manager
End Sub

Private Sub cmdHT_Click()
    'HTTP Enable/Disable
On Error GoTo Error
If cmdHT.Caption = "Enable" Then
    sckHT(0).LocalPort = txtHTTPPort.Text
    sckHT(0).Listen ' Start Listen
    Log "HTTP Server enabled:" & sckHT(0).LocalIP & ":" & sckHT(0).LocalPort
    cmdHT.Caption = "Disable"
Else
    cmdHT.Caption = "Enable"
    modSockets.CloseHTTP ' Close Listen
End If
Error:
If Err.Number = 10048 Then
'10048 = Adress already in use error code
    MsgBox "Port " & txtHTTPPort.Text & " is being used (another emu??)", vbCritical + vbOKOnly, "Error"
End If
End Sub

Private Sub cmdLoad_Click()
timSaveTime.Enabled = True
LoadAccounts (False)
End Sub

Private Sub cmdRS_Click()
'Realm Enable/Disable
On Error GoTo Error
If cmdRS.Caption = "Enable" Then
    sckRS(0).LocalPort = txtRSPort.Text
    sckRS(0).Listen ' Start Listen
    Log "Realm Server enabled:" & sckRS(0).LocalIP & ":" & sckRS(0).LocalPort
    cmdRS.Caption = "Disable"
Else
    cmdRS.Caption = "Enable"
    modSockets.CloseRealm ' Close Listen
End If
Error:
If Err.Number = 10048 Then
'10048 = Adress already in use error code
    MsgBox "Port " & txtRSPort.Text & " is being used (another emu??)", vbCritical + vbOKOnly, "Error"
End If
End Sub


Private Sub cmdSave_Click()
timSaveTime.Enabled = True
LoadAccounts (True) ' Save everything
End Sub

Private Sub cmdWS_Click()
    'World Enable/Disable
'On Error GoTo Error
If cmdWS.Caption = "Enable" Then
    sckWS(0).LocalPort = txtWSPort.Text
    sckWS(0).Listen ' Start Listen
    Log "World Server enabled:" & sckWS(0).LocalIP & ":" & sckWS(0).LocalPort
    cmdWS.Caption = "Disable"
Else
    cmdWS.Caption = "Enable"
    modSockets.CloseWorld ' Stop Listen
End If
'Error:
'If Err.Number = 10048 Then
'10048 = Adress already in use error code
'    MsgBox "Port " & txtWSPort.Text & " is being used (another emu??)", vbCritical + vbOKOnly, "Error"
'End If
End Sub

Private Sub Form_Load()
modSystem.LoadCore ' Load up everything
PathShared = App.Path & "\www\" ' Path to the www directory
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    If MsgBox("Do you want to save before you exit?", vbYesNo) = vbYes Then
        LoadAccounts (True) ' Save before quit
        DoEvents
        End
    Else
        End
    End If
End Sub

Private Sub sckHT_Close(Index As Integer)
sckHT(Index).Close
sckHTUsed(Index) = False
tmrSendData(Index).Enabled = False
Unload tmrSendData(Index)
    ' clear the info structure
    CInfo(Index).FileNum = 0
    CInfo(Index).FileName = ""
    CInfo(Index).TotalLength = 0
    CInfo(Index).TotalSent = 0
If chkLogRequests.value = 1 Then Log "sckHT(" & Index & ") has disconnected" ' If log requests is checked then log the disconnect
End Sub

Private Sub sckHT_ConnectionRequest(Index As Integer, ByVal requestID As Long)
'Ok here we accept connections. sckRS(0) will handle all conexions to another
'index, in order to have a dedicated socket just for accepting connections
'We will check first if any of the sockets is free before loading another one
Dim i As Integer
For i = 1 To UBound(sckHTUsed)
    If sckHTUsed(i) = False Then
        ReDim Preserve CInfo(i)
        CInfo(i).FileName = ""
        CInfo(0).FileNum = 0
        CInfo(i).TotalLength = 0
        CInfo(i).TotalSent = 0
        
        Load tmrSendData(i)
        tmrSendData(i).Enabled = False
        tmrSendData(i).Interval = 1
    sckHT(i).Accept requestID
    sckHTUsed(i) = True
    If chkLogRequests.value = 1 Then Log "sckHT(" & i & ") connected with " & sckHT(i).RemoteHostIP & ":" & sckHT(i).RemotePort
    Exit Sub
    End If
Next i
ReDim Preserve sckHTUsed(i)
ReDim Preserve CInfo(i)
    CInfo(i).FileName = ""
    CInfo(0).FileNum = 0
    CInfo(i).TotalLength = 0
    CInfo(i).TotalSent = 0
    
    Load tmrSendData(i) ' load a new timer for the control
    tmrSendData(i).Enabled = False
    tmrSendData(i).Interval = 1
Load sckHT(i)
If chkLogRequests.value = 1 Then Log "sckHT(" & i & ") loaded"
sckHT(i).LocalPort = txtHTTPPort.Text
sckHT(i).Accept requestID
sckHT(i).Tag = -1
If chkLogRequests.value = 1 Then Log "sckHT(" & i & ") connected with " & sckHT(i).RemoteHostIP
sckHTUsed(i) = True
End Sub

Private Sub sckHT_DataArrival(Index As Integer, ByVal bytesTotal As Long)
Dim data As String, sHeader As String, RequestedFile As String, ContentType As String
Dim CompletePath As String, UserName As String, PassWord As String
sckHT(Index).GetData data, vbString
    If data Like "GET * HTTP/1.?*" Then
        RequestedFile = LeftRange(data, "GET ", " HTTP/1.", , ReturnEmptyStr)
        
        If InStr(1, RequestedFile, "/../") > 0 Or InStr(1, RequestedFile, "/./") > 0 Or _
                InStr(1, RequestedFile, "*") > 0 Or InStr(1, RequestedFile, "?") > 0 Or RequestedFile = "" Then
            
            ' send "Not Found" error ...
            sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
            CInfo(Index).TotalLength = Len(sHeader)
            sckHT(Index).SendData sHeader
        ElseIf RequestedFile = "/map.html" Then
                ' the request if for a directory listing...
                    
                CInfo(Index).DataStr = BuildHTMLMap()
                CInfo(Index).FileNum = -1
                    
                    ' build the header
                    sHeader = "HTTP/1.0 200 OK" & vbNewLine & _
                            "Server: " & ServerName & vbNewLine & _
                            "Content-Type: text/html" & vbNewLine & _
                            "Content-Length: " & Len(CInfo(Index).DataStr) & vbNewLine & _
                            vbNewLine
                    
                ' total data send is the header length + the length of the file requested
                CInfo(Index).TotalLength = Len(sHeader) + Len(CInfo(Index).DataStr)
                
                sckHT(Index).SendData sHeader
        Else
            CompletePath = Replace(PathShared & Replace(RequestedFile, "/", "\"), "\\", "\")
            CompletePath = Replace(CompletePath, "%20", " ")
            If chkLogRequests.value = 1 Then Log "HTTP Request [" & sckHT(Index).RemoteHostIP & ":" & sckHT(Index).RemotePort & "] " & CompletePath
            
            If Dir(CompletePath, vbArchive + vbReadOnly + vbDirectory) <> "" Then
                If (GetAttr(CompletePath) And vbDirectory) = vbDirectory Then
                    ' the request if for a directory listing...
                    
                    CInfo(Index).DataStr = BuildHTMLDirList(PathShared, RequestedFile)
                    CInfo(Index).FileNum = -1
                    
                    ' build the header
                    sHeader = "HTTP/1.0 200 OK" & vbNewLine & _
                            "Server: " & ServerName & vbNewLine & _
                            "Content-Type: text/html" & vbNewLine & _
                            "Content-Length: " & Len(CInfo(Index).DataStr) & vbNewLine & _
                            vbNewLine
                    
                    ' total data send is the header length + the length of the file requested
                    CInfo(Index).TotalLength = Len(sHeader) + Len(CInfo(Index).DataStr)
                Else
                    ' requested file exists, open the file, send header, and start the transfer
                    
                    ' display on the label the file name of currect transfer
                    'lblFileProgress(Index).Caption = Right("00" & Index, 2) & " Transfering: " & RequestedFile
                    CInfo(Index).FileName = RequestedFile
                    
                    ' since one or more files may be opened at the same time, have to get the free file number
                    CInfo(Index).FileNum = FreeFile
                    Open CompletePath For Binary Access Read As CInfo(Index).FileNum
                    
                    ' get content-type depending on the file extension
                    Select Case LCase(LeftRight(RequestedFile, ".", , ReturnEmptyStr))
                    Case "jpg", "jpeg"
                        ContentType = "Content-Type: image/jpeg"
                    Case "gif"
                        ContentType = "Content-Type: image/gif"
                    Case "htm", "html"
                        ContentType = "Content-Type: text/html"
                    Case "zip"
                        ContentType = "Content-Type: application/zip"
                    Case "mp3"
                        ContentType = "Content-Type: audio/mpeg"
                    Case "m3u", "pls", "xpl"
                        ContentType = "Content-Type: audio/x-mpegurl"
                    Case Else
                        ContentType = "Content-Type: */*"
                    End Select
                    
                    ' build the header
                    sHeader = "HTTP/1.0 200 OK" & vbNewLine & _
                            "Server: " & ServerName & vbNewLine & _
                            ContentType & vbNewLine & _
                            "Content-Length: " & LOF(CInfo(Index).FileNum) & vbNewLine & _
                            vbNewLine
                    
                    ' total data send is the header length + the length of the file requested
                    CInfo(Index).TotalLength = Len(sHeader) + LOF(CInfo(Index).FileNum)
                End If
                
                ' send the header, the Sck_SendComplete event is gonna send the file...
                sckHT(Index).SendData sHeader
            Else
                ' send "Not Found" if file does not exsist on the share
                sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
                CInfo(Index).TotalLength = Len(sHeader)
                sckHT(Index).SendData sHeader
            End If
        End If
    ElseIf data Like "POST * HTTP/1.?*" Then
        RequestedFile = LeftRange(data, "POST ", " HTTP/1.", , ReturnEmptyStr)
        
        If RequestedFile = "/index.html" Then
            UserName = LeftRange(data, "user=", "&", , ReturnEmptyStr)
            PassWord = LeftRange(data, "&pass=", vbCrLf, , ReturnEmptyStr)
            
            MsgBox UserName & "  -  " & PassWord
        Else
            ' send "Not Found" error ...
            sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
            CInfo(Index).TotalLength = Len(sHeader)
            sckHT(Index).SendData sHeader
        End If
    Else
        MsgBox data
    End If
End Sub

Private Sub sckHT_SendComplete(Index As Integer)
    If CInfo(Index).TotalSent >= CInfo(Index).TotalLength Then
        ' if all data was sent, then close the connection
        sckHT_Close Index
    Else
        ' still have data to send, let the timer do that...
        
        ' if you want to slow down the connection set the interval to a higher values
        ' right now it's as fast as it can be
        tmrSendData(Index).Interval = 1
        tmrSendData(Index).Enabled = True ' start the timer
    End If
End Sub

Private Sub sckHT_SendProgress(Index As Integer, ByVal bytesSent As Long, ByVal bytesRemaining As Long)
    ' keep track of how much data was sent
    CInfo(Index).TotalSent = CInfo(Index).TotalSent + bytesSent
    
    ' display file progress
    If CInfo(Index).FileNum > 0 Then
        On Error Resume Next
        
        'lblFileProgress(Index).Caption = Right("00" & Index, 2) & " Transfering: " & CInfo(Index).FileName & "   - " & _
            CInfo(Index).TotalSent & " of " & LOF(CInfo(Index).FileNum) & " bytes sent, " & _
            Format(CInfo(Index).TotalSent / LOF(CInfo(Index).FileNum) * 100#, "00.00") & " %Done."
        
        ' if file size if 0 length, it gives a "division by 0" error, so just clear it
        If Err.Number <> 0 Then Err.Clear
    End If
End Sub

Private Sub tmrSendData_Timer(Index As Integer)
    ' send 2KBytes at one time, then wait until it's sent, then send the other 2KBytes and so on
    Const BufferLength As Long = 1024 * 2
    Dim Buffer As String
    
    If CInfo(Index).FileNum = -1 Then ' send data from a string instead of a file on the hard drive
        Buffer = Left(CInfo(Index).DataStr, BufferLength)
        CInfo(Index).DataStr = Mid(CInfo(Index).DataStr, BufferLength + 1)
        
        sckHT(Index).SendData Buffer ' send the data on the current connection
        
        If Len(CInfo(Index).DataStr) = 0 Then CInfo(Index).FileNum = 0
        
    ElseIf CInfo(Index).FileNum > 0 Then ' do this code ONLY if a file was opened
        If Loc(CInfo(Index).FileNum) + BufferLength > LOF(CInfo(Index).FileNum) Then
            ' the remaining data is less than the buffer length, so load only the remaining data
            
            Buffer = String(LOF(CInfo(Index).FileNum) - Loc(CInfo(Index).FileNum), 0)
        Else
            Buffer = String(BufferLength, 0)
        End If
        
        Get CInfo(Index).FileNum, , Buffer ' get data from file
        Buffer = DoReplacing(Buffer)
        sckHT(Index).SendData Buffer ' send the data on the current connection
        
        If Loc(CInfo(Index).FileNum) >= LOF(CInfo(Index).FileNum) Then
            ' no data remaining to send
            Close CInfo(Index).FileNum
            
            ' if file is closed, set filenumber to 0, in case the timer get's called again don't send any more data
            CInfo(Index).FileNum = 0
        End If
    End If
    
    ' sckHT_SendComplete event will enable the time back when current data is sent
    tmrSendData(Index).Enabled = False
End Sub

Private Sub sckHT_Error(Index As Integer, ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
sckHT(Index).Close
If chkLogRequests.value = 1 Then Log "sckHT(" & Index & ") error, connection closed"
End Sub

Private Sub sckWS_Close(Index As Integer)
Dim CharacterID As Integer
sckWS(Index).Close
If sckWS(Index).Tag <> -1 Then
    If Account(sckWS(Index).Tag).AccStatus = 1 Then
        Account(sckWS(Index).Tag).AccStatus = 0
    End If
End If

CharacterID = Account(sckWS(Index).Tag).PlayingChar
If CharacterID > 0 Then
    Account(sckWS(Index).Tag).AccChar(CharacterID).Online = False
End If
Account(sckWS(Index).Tag).PlayingChar = 0

sckWS(Index).Tag = ""
sckWSUsed(Index) = False
Log "sckWS(" & Index & ") has disconnected"
End Sub

Private Sub sckWS_ConnectionRequest(Index As Integer, ByVal requestID As Long)
'Ok here we accept connections. sckWS(0) will handle all connections to another
'index, in order to have a dedicated socket just for accepting connections
'We will check first if any of the sockets is free before loading another one
Dim i As Integer
For i = 1 To UBound(sckWSUsed)
    If sckWSUsed(i) = False Then
    sckWS(i).Accept requestID
    sckWSUsed(i) = True
    sckWS(i).Tag = -1
    Log "sckWS(" & i & ") connected with " & sckWS(i).RemoteHostIP & ":" & sckWS(i).RemotePort
    
    modWSFunctions.Send_SMSG_AUTH_CHALLENGE i
    Exit Sub
    End If
Next i
ReDim Preserve sckWSUsed(i)
Load sckWS(i)
Log "sckWS(" & i & ") loaded"
sckWS(i).LocalPort = txtWSPort.Text
sckWS(i).Accept requestID
sckWS(i).Tag = -1
Log "sckWS(" & i & ") connected with " & sckWS(i).RemoteHostIP
sckWSUsed(i) = True

modWSFunctions.Send_SMSG_AUTH_CHALLENGE i
End Sub

Private Sub sckWS_DataArrival(Index As Integer, ByVal bytesTotal As Long)
' We get data to the World Server
    Dim data() As Byte
    sckWS(Index).GetData data, vbArray + vbByte
    
    modWSPackets.Analyze Index, data
End Sub

Private Sub sckWS_Error(Index As Integer, ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
' Error in the World Server data
Dim CharacterID
sckWS(Index).Close
Log "sckWS(" & Index & ") error, connection closed"

If sckWS(Index).Tag <> -1 Then
    If Account(sckWS(Index).Tag).AccStatus = 1 Then
        Account(sckWS(Index).Tag).AccStatus = 0
    End If
End If

CharacterID = Account(sckWS(Index).Tag).PlayingChar
If CharacterID > 0 Then
    Account(sckWS(Index).Tag).AccChar(CharacterID).Online = False ' If the account is logged in to any character then set it as offline
End If
Account(sckWS(Index).Tag).PlayingChar = 0

sckWS(Index).Tag = ""
End Sub
Private Sub sckRS_Close(Index As Integer)
sckRS(Index).Close
If sckRS(Index).Tag <> "" Then
    If Account(sckRS(Index).Tag).AccStatus = 1 Then
        Account(sckRS(Index).Tag).AccStatus = 0
    End If
End If
sckRS(Index).Tag = ""
sckRSUsed(Index) = False
Log "sckRS(" & Index & ") has disconnected"
End Sub

Private Sub sckRS_ConnectionRequest(Index As Integer, ByVal requestID As Long)
'Ok here we accept connections. sckRS(0) will handle all connections to another
'index, in order to have a dedicated socket just for accepting connections
'We will check first if any of the sockets is free before loading another one
Dim i As Integer
For i = 1 To UBound(sckRSUsed)
    If sckRSUsed(i) = False Then
    sckRS(i).Accept requestID
    sckRSUsed(i) = True
    Log "sckRS(" & i & ") connected with " & sckRS(i).RemoteHostIP & ":" & sckRS(i).RemotePort
    Exit Sub
    End If
Next i
ReDim Preserve sckRSUsed(i)
Load sckRS(i)
Log "sckRS(" & i & ") loaded"
sckRS(i).LocalPort = txtRSPort.Text
sckRS(i).Accept requestID
Log "sckRS(" & i & ") connected with " & sckRS(i).RemoteHostIP
sckRSUsed(i) = True
End Sub

Private Sub sckRS_DataArrival(Index As Integer, ByVal bytesTotal As Long)
'OK here we accept data and we analyze it in the debug window.
Dim RealmData() As Byte
Dim newString As String
sckRS(Index).GetData RealmData, vbArray + vbByte
AnalyzeRS RealmData, Index
End Sub

Private Sub sckRS_Error(Index As Integer, ByVal Number As Integer, Description As String, ByVal Scode As Long, ByVal Source As String, ByVal HelpFile As String, ByVal HelpContext As Long, CancelDisplay As Boolean)
sckRS(Index).Close
sckRS(Index).Tag = ""
Log "sckRS(" & Index & ") error, connection closed"
End Sub

Private Sub timSaver_Timer()
' The timer that saves everything
If txtSaver.Text = "" Then Exit Sub
If IsNumeric(txtSaver.Text) = False Then Exit Sub
If TimeTicked >= txtSaver.Text Then
    Call cmdSave_Click
    TimeTicked = 0
Else
    TimeTicked = TimeTicked + 1
End If
End Sub

Private Sub timSaveTime_Timer()
TimeUsed = TimeUsed + 1
End Sub

Private Sub txtConsole_Change()
' If there's too much text in the log then clear the stuff at the top that we dont see anyway
    If Len(txtConsole.Text) > 5000 Then
        txtConsole.Text = Right(txtConsole.Text, 4950)
    End If
    
    txtConsole.SelStart = Len(txtConsole.Text)
End Sub

Private Sub txtSaver_Change()
    TimeTicked = 0
End Sub
Private Function BuildHTMLMap()
' Here it builds a HTTP Map of all players online
    Dim HTML As String, i As Integer, j As Integer
    Dim posX As Single, posY As Single
    Dim faction As String, map As Integer
    
    HTML = "<table style='position: absolute; height: 600px; width: 800px; left: 50%; margin-left: -400px; background-image: url(""world.jpg""); z-index: 2;'>"
    HTML = HTML & vbCrLf & " <tr>"
    HTML = HTML & vbCrLf & "  <td>"
    
    For i = 1 To UBound(Account)
        For j = 1 To 10
            If Account(i).AccChar(j).Online Then
                If Account(i).AccChar(j).Race = 1 Then faction = "allie"
                If Account(i).AccChar(j).Race = 2 Then faction = "horde"
                If Account(i).AccChar(j).Race = 3 Then faction = "allie"
                If Account(i).AccChar(j).Race = 4 Then faction = "allie"
                If Account(i).AccChar(j).Race = 5 Then faction = "horde"
                If Account(i).AccChar(j).Race = 6 Then faction = "horde"
                If Account(i).AccChar(j).Race = 7 Then faction = "allie"
                If Account(i).AccChar(j).Race = 8 Then faction = "horde"
                
                posX = Account(j).AccChar(i).positionX
                posY = Account(j).AccChar(i).positionY
                posX = Round((posX / 1000) * 17.7, 0)
                posY = Round((posY / 1000) * 17.7, 0)
                map = Account(j).AccChar(i).MapID
                
                If map = 1 Then
                    posX = 162 - posY
                    posY = 311 - posX
                ElseIf map = 0 Then
                    posX = 580 - posY
                    posY = 227 - posX
                Else
                    posX = 580 - posY
                    posY = 227 - posX
                End If
                
                HTML = HTML & "    <div style='position: absolute; top: " & posY & "px; left: " & posX & "px'><image src='" & faction & ".gif'><b>" & Account(j).AccChar(i).Name & "</b></div>"
            End If
        Next j
    Next i
    
                faction = "horde"
                posX = 1484.36  '243
                posY = -4417.03 '260
                posX = Round((posX / 6.10847736625514), 0)
                posY = Round((posY / -16.9885769230769), 0)
                map = 1
                
                If map = 1 Then
                    posX = posX + 0
                    posY = posY + 0
                ElseIf map = 0 Then
                    posX = posX + 0
                    posY = posY + 0
                Else
                    posX = posX + 0
                    posY = posY + 0
                End If
                
                HTML = HTML & vbCrLf & "    <div style='position: absolute; top: " & posY & "px; left: " & posX & "px'><image src='" & faction & ".gif'><b>Zaga</b></div>"
    
    HTML = HTML & vbCrLf & "  </td>"
    HTML = HTML & vbCrLf & " </tr>"
    HTML = HTML & vbCrLf & "</table>"
    
    BuildHTMLMap = HTML
End Function

Private Function BuildHTMLDirList(ByVal Root As String, ByVal DirToList As String)
' Building a list of all files in the www folder
    Dim Dirs As New Collection, Files As New Collection
    Dim sDir As String, Path As String, HTML As String, K As Long
    
    Root = Replace(Root, "/", "\")
    DirToList = Replace(DirToList, "/", "\")
    
    If Right(Root, 1) <> "\" Then Root = Root & "\"
    If Left(DirToList, 1) = "\" Then DirToList = Mid(DirToList, 2)
    If Right(DirToList, 1) <> "\" Then DirToList = DirToList & "\"
    
    DirToList = Replace(DirToList, "%20", " ")
    
    sDir = Dir(Replace(Root & DirToList, "\\", "\") & "*.*", vbArchive + vbDirectory + vbReadOnly)
    
    Do Until Len(sDir) = 0
        If sDir <> ".." And sDir <> "." Then
            Path = Replace(Root & DirToList, "\\", "\") & sDir
            
            
            If (GetAttr(Path) And vbDirectory) = vbDirectory Then
                Dirs.Add sDir
            Else
                Files.Add sDir
            End If
        End If
        
        sDir = Dir
    Loop
    
    HTML = "<html><body>"
    
    If Dirs.Count > 0 Then
        HTML = HTML & "<b>Directories:</b><br>"
        
        For K = 1 To Dirs.Count
            HTML = HTML & "<a href=""" & _
                Replace(Replace("/" & DirToList & Dirs(K), "\", "/"), "//", "/") & """>" & _
                Dirs(K) & "</a><br>" & vbNewLine
        Next K
    End If
    
    If Files.Count > 0 Then
        HTML = HTML & "<P align=""center"" style=""font-style: bold; font-size: 48px;"">Fusion HTTP server</p><br><b>Files:</b><br><table width=""100%"" border=""1"" cellpadding=""3"" cellspacing=""2"">" & vbNewLine
        
        For K = 1 To Files.Count
            HTML = HTML & "<tr>" & vbNewLine
            HTML = HTML & "<td width=""100%""><a href=""" & _
                Replace(Replace("/" & DirToList & Files(K), "\", "/"), "//", "/") & """>" & _
                Files(K) & "</a></td>" & vbNewLine
            
            HTML = HTML & "<td nowrap>" & _
                Format(FileLen(Replace(Root & DirToList, "\\", "\") & Files(K)) / 1024#, "###,###,###,##0") & _
                " KBytes</td>" & vbNewLine
            HTML = HTML & "</tr>" & vbNewLine
        Next K
        
        HTML = HTML & "</table>" & vbNewLine
    End If
    
    If Dirs.Count = 0 And Files.Count = 0 Then
        HTML = HTML & "This folder is empty."
    End If
    
    BuildHTMLDirList = HTML & "</body></html>"
End Function

' Search from the beginning to end and return from StrFrom string to StrTo string
' both strings (StrFrom and StrTo) must be found in order to be successfull
Public Function LeftRange(ByRef Str As String, StrFrom As String, StrTo As String, Optional Compare As VbCompareMethod = vbBinaryCompare, Optional RetError As IfStringNotFound = ReturnOriginalStr) As String
    Dim K As Long, Q As Long
    
    K = InStr(1, Str, StrFrom, Compare)
    If K > 0 Then
        Q = InStr(K + Len(StrFrom), Str, StrTo, Compare)
        
        If Q > K Then
            LeftRange = Mid(Str, K + Len(StrFrom), (Q - K) - Len(StrFrom))
        Else
            LeftRange = IIf(RetError = ReturnOriginalStr, Str, "")
        End If
    Else
        LeftRange = IIf(RetError = ReturnOriginalStr, Str, "")
    End If
End Function
' Search from the beginning to end and return the right size of the string
Public Function LeftRight(ByRef Str As String, LFind As String, Optional Compare As VbCompareMethod = vbBinaryCompare, Optional RetError As IfStringNotFound = ReturnOriginalStr) As String
    Dim K As Long
    
    K = InStr(1, Str, LFind, Compare)
    If K = 0 Then
        LeftRight = IIf(RetError = ReturnOriginalStr, Str, "")
    Else
        LeftRight = Right(Str, (Len(Str) - Len(LFind)) - K + 1)
    End If
End Function

Public Function DoReplacing(sData As String) As String
'Something
    sData = Replace(sData, "<*SERVER_NAME*>", "Test")
 DoReplacing = sData
End Function
