VERSION 5.00
Object = "{248DD890-BB45-11CF-9ABC-0080C7E7B78D}#1.0#0"; "mswinsck.ocx"
Begin VB.Form frmMisc 
   BorderStyle     =   4  'Fixed ToolWindow
   Caption         =   "Settings"
   ClientHeight    =   2235
   ClientLeft      =   5655
   ClientTop       =   4410
   ClientWidth     =   4005
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   2235
   ScaleWidth      =   4005
   ShowInTaskbar   =   0   'False
   Begin VB.Frame Frame1 
      Caption         =   "Integrated simple HTTP"
      Height          =   1935
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3735
      Begin VB.Timer tmrSendData 
         Index           =   0
         Left            =   3240
         Top             =   240
      End
      Begin MSWinsockLib.Winsock Sck 
         Index           =   0
         Left            =   3240
         Top             =   720
         _ExtentX        =   741
         _ExtentY        =   741
         _Version        =   393216
         LocalPort       =   8080
      End
      Begin VB.CheckBox chkLogConnections 
         Caption         =   "Log opened and closed connections"
         Height          =   255
         Left            =   120
         TabIndex        =   7
         Top             =   1560
         Value           =   1  'Checked
         Width           =   3495
      End
      Begin VB.CheckBox chkLogRequests 
         Caption         =   "Log http requests"
         Height          =   255
         Left            =   120
         TabIndex        =   6
         Top             =   1320
         Value           =   1  'Checked
         Width           =   3495
      End
      Begin VB.TextBox txtHTTPIP 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   1080
         TabIndex        =   5
         Text            =   "autoselect"
         Top             =   600
         Width           =   2535
      End
      Begin VB.TextBox txtHTTPPort 
         Alignment       =   2  'Center
         Appearance      =   0  'Flat
         BackColor       =   &H00C0FFFF&
         Height          =   285
         Left            =   1080
         TabIndex        =   4
         Text            =   "8080"
         Top             =   960
         Width           =   2535
      End
      Begin VB.CheckBox chkHTTP 
         Caption         =   "Enable integrated HTTP server"
         Height          =   255
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   2655
      End
      Begin VB.Label Label2 
         Caption         =   "HTTP Port:"
         Height          =   255
         Left            =   120
         TabIndex        =   3
         Top             =   960
         Width           =   975
      End
      Begin VB.Label Label1 
         Caption         =   "HTTP IP:"
         Height          =   255
         Left            =   120
         TabIndex        =   2
         Top             =   600
         Width           =   975
      End
   End
End
Attribute VB_Name = "frmMisc"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public Enum IfStringNotFound
    ReturnOriginalStr = 0
    ReturnEmptyStr = 1
End Enum

' change this to your server name
Private Const ServerName As String = "HTTP Server Version 1.0.0"

' this project was designed for only one share
' change the path to the directory you want to share
Private Const PathShared As String = "C:\Documents and Settings\user\Desktop\x\aWoWe 0.2\www\"


Private Type ConnectionInfo
    FileNum As Integer  ' file number of the file opened on the current connection
    TotalLength As Long ' total length of data to send (including the header)
    TotalSent As Long   ' total data sent
    FileName As String  ' file name of the file to send
    
    DataStr As String
End Type

Private CInfo() As ConnectionInfo



Private Sub chkHTTP_Click()
    If chkHTTP.value = vbChecked Then
        Sck(0).LocalPort = txtHTTPPort.text ' set this to the port you want the server to listen on...
        Sck(0).Listen
        If Sck(0).State = sckListening Then LOG "aWoWe HTTP Listening on " & Sck(0).LocalIP & ":" & Sck(0).LocalPort
        txtHTTPIP = Sck(0).LocalIP
    Else
        Sck(0).Close
        If Sck(0).State = sckClosing Then LOG "aWoWe HTTP Stopping..."
        If Sck(0).State = sckClosed Then LOG "aWoWe HTTP Stopped"
    End If
End Sub

Private Sub Form_Load()
    frmMisc.Left = frmLog.Left
    frmMisc.Top = frmLog.Height
    'Sck(0).LocalPort = 8080 ' set this to the port you want the server to listen on...
    'Sck(0).Listen
    
    'DoEvents
    
    If Sck(0).State = sckListening Then LOG "aWoWe HTTP Listening on " & Sck(0).LocalIP & ":" & Sck(0).LocalPort
End Sub

Private Sub Sck_Close(Index As Integer)
    ' disable the timer (so it does not send more data than neccessary)
    tmrSendData(Index).Enabled = False
    
    ' make sure the connection is closed
    Do
        Sck(Index).Close
        DoEvents
    Loop Until Sck(Index).State = sckClosed
    
    ' clear the info structure
    CInfo(Index).FileNum = 0
    CInfo(Index).FileName = ""
    CInfo(Index).TotalLength = 0
    CInfo(Index).TotalSent = 0
    
    If chkLogConnections.value Then LOG "  HTTP Connection closed [" & Sck(Index).RemoteHostIP & ":" & Sck(Index).RemotePort & "]"
End Sub

Private Sub Sck_ConnectionRequest(Index As Integer, ByVal requestID As Long)
    Dim K As Integer
    
    ' look in the control array for a closed connection
    ' note that it's starting to search at index 1 (not index 0)
    ' since index 0 is the one listening on port 80
    For K = 1 To Sck.UBound
        If Sck(K).State = sckClosed Then Exit For
    Next K
    
    ' if all controls are connected, then create a new one
    If K > Sck.UBound Then
        K = Sck.UBound + 1
        Load Sck(K) ' create a new winsock object
        
        'Load lblFileProgress(K) ' load the label to display the progress on each conection
        'lblFileProgress(K).Top = (lblFileProgress(0).Height + 5) * K
        'lblFileProgress(K).Visible = True
        
        ReDim Preserve CInfo(K) ' create new info structure
        
        Load tmrSendData(K) ' load a new timer for the control
        tmrSendData(K).Enabled = False
        tmrSendData(K).Interval = 1
    End If
    
    ' make sure the info structure contains default values (ie: 0's and "")
    CInfo(K).FileName = ""
    CInfo(0).FileNum = 0
    CInfo(K).TotalLength = 0
    CInfo(K).TotalSent = 0
    
    ' accept the connection on the closed control or the new control
    Sck(K).Accept requestID
    If chkLogConnections.value Then LOG "  HTTP Incoming connection [" & Sck(K).RemoteHostIP & ":" & Sck(K).RemotePort & "]"
End Sub

Private Sub Sck_DataArrival(Index As Integer, ByVal bytesTotal As Long)
    Dim rData As String, sHeader As String, RequestedFile As String, ContentType As String
    Dim CompletePath As String
    
    Sck(Index).GetData rData, vbString
    
    If rData Like "GET * HTTP/1.?*" Then
        ' get requested file name
        RequestedFile = LeftRange(rData, "GET ", " HTTP/1.", , ReturnEmptyStr)
        
        ' check if request contains "/../" or "/./" or "*" or "?"
        ' (probably someone trying to get a file that is outside of the share)
        If InStr(1, RequestedFile, "/../") > 0 Or InStr(1, RequestedFile, "/./") > 0 Or _
                InStr(1, RequestedFile, "*") > 0 Or InStr(1, RequestedFile, "?") > 0 Or RequestedFile = "" Then
            
            ' send "Not Found" error ...
            sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
            CInfo(Index).TotalLength = Len(sHeader)
            Sck(Index).SendData sHeader
        Else
            CompletePath = Replace(PathShared & Replace(RequestedFile, "/", "\"), "\\", "\")
            CompletePath = Replace(CompletePath, "%20", " ")
            If chkLogRequests.value Then LOG "  HTTP Request [" & Sck(Index).RemoteHostIP & ":" & Sck(Index).RemotePort & "] " & CompletePath
            
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
                Sck(Index).SendData sHeader
            Else
                ' send "Not Found" if file does not exsist on the share
                sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
                CInfo(Index).TotalLength = Len(sHeader)
                Sck(Index).SendData sHeader
            End If
        End If
    Else
        ' sometimes the browser makes "HEAD" requests (but it's not inplemented in this project)
        sHeader = "HTTP/1.0 501 Not Implemented" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
        CInfo(Index).TotalLength = Len(sHeader)
        Sck(Index).SendData sHeader
    End If
End Sub

Private Function BuildHTMLDirList(ByVal Root As String, ByVal DirToList As String)
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
        HTML = HTML & "<P align=""center"" style=""font-style: bold; font-size: 48px;"">aWoWe Integrated HTTP server</p><br><b>Files:</b><br><table width=""100%"" border=""1"" cellpadding=""3"" cellspacing=""2"">" & vbNewLine
        
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

Private Sub Sck_SendComplete(Index As Integer)
    If CInfo(Index).TotalSent >= CInfo(Index).TotalLength Then
        ' if all data was sent, then close the connection
        Sck_Close Index
    Else
        ' still have data to send, let the timer do that...
        
        ' if you want to slow down the connection set the interval to a higher values
        ' right now it's as fast as it can be
        tmrSendData(Index).Interval = 1
        tmrSendData(Index).Enabled = True ' start the timer
    End If
End Sub

Private Sub Sck_SendProgress(Index As Integer, ByVal bytesSent As Long, ByVal bytesRemaining As Long)
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
        
        Sck(Index).SendData Buffer ' send the data on the current connection
        
        If Len(CInfo(Index).DataStr) = 0 Then CInfo(Index).FileNum = 0
        
    ElseIf CInfo(Index).FileNum > 0 Then ' do this code ONLY if a file was opened
        If Loc(CInfo(Index).FileNum) + BufferLength > LOF(CInfo(Index).FileNum) Then
            ' the remaining data is less than the buffer length, so load only the remaining data
            
            Buffer = String(LOF(CInfo(Index).FileNum) - Loc(CInfo(Index).FileNum), 0)
        Else
            Buffer = String(BufferLength, 0)
        End If
        
        Get CInfo(Index).FileNum, , Buffer ' get data from file
        Sck(Index).SendData Buffer ' send the data on the current connection
        
        If Loc(CInfo(Index).FileNum) >= LOF(CInfo(Index).FileNum) Then
            ' no data remaining to send
            Close CInfo(Index).FileNum
            
            ' if file is closed, set filenumber to 0, in case the timer get's called again don't send any more data
            CInfo(Index).FileNum = 0
        End If
    End If
    
    ' Sck_SendComplete event will enable the time back when current data is sent
    tmrSendData(Index).Enabled = False
End Sub






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
