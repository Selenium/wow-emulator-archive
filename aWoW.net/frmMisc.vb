Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmMisc
	Inherits System.Windows.Forms.Form
	
	Public Enum IfStringNotFound
		ReturnOriginalStr = 0
		ReturnEmptyStr = 1
	End Enum
	
	' change this to your server name
	Private Const ServerName As String = "HTTP Server Version 1.0.0"
	
	' this project was designed for only one share
	' change the path to the directory you want to share
	Private Const PathShared As String = "C:\Documents and Settings\user\Desktop\x\aWoWe 0.2\www\"
	
	
	Private Structure ConnectionInfo
		Dim FileNum As Short ' file number of the file opened on the current connection
		Dim TotalLength As Integer ' total length of data to send (including the header)
		Dim TotalSent As Integer ' total data sent
		Dim FileName As String ' file name of the file to send
		Dim DataStr As String
	End Structure
	
	Private CInfo() As ConnectionInfo
	
	
	
	'UPGRADE_WARNING: Event chkHTTP.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkHTTP_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkHTTP.CheckStateChanged
		If chkHTTP.CheckState = System.Windows.Forms.CheckState.Checked Then
			Sck(0).LocalPort = CInt(txtHTTPPort.Text) ' set this to the port you want the server to listen on...
			Sck(0).Listen()
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			If Sck(0).CtlState = MSWinsockLib.StateConstants.sckListening Then LOG("aWoWe HTTP Listening on " & Sck(0).LocalIP & ":" & Sck(0).LocalPort)
			txtHTTPIP.Text = Sck(0).LocalIP
		Else
			Sck(0).Close()
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			If Sck(0).CtlState = MSWinsockLib.StateConstants.sckClosing Then LOG("aWoWe HTTP Stopping...")
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			If Sck(0).CtlState = MSWinsockLib.StateConstants.sckClosed Then LOG("aWoWe HTTP Stopped")
		End If
	End Sub
	
	Private Sub frmMisc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Left = frmLog.Left
		Me.Top = frmLog.Height
		'Sck(0).LocalPort = 8080 ' set this to the port you want the server to listen on...
		'Sck(0).Listen
		
		'DoEvents
		
		'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		If Sck(0).CtlState = MSWinsockLib.StateConstants.sckListening Then LOG("aWoWe HTTP Listening on " & Sck(0).LocalIP & ":" & Sck(0).LocalPort)
	End Sub
	
	Private Sub Sck_CloseEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Sck.CloseEvent
		Dim Index As Short = Sck.GetIndex(eventSender)
		' disable the timer (so it does not send more data than neccessary)
		tmrSendData(Index).Enabled = False
		
		' make sure the connection is closed
		Do 
			Sck(Index).Close()
			System.Windows.Forms.Application.DoEvents()
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Loop Until Sck(Index).CtlState = MSWinsockLib.StateConstants.sckClosed
		
		' clear the info structure
		CInfo(Index).FileNum = 0
		CInfo(Index).FileName = ""
		CInfo(Index).TotalLength = 0
		CInfo(Index).TotalSent = 0
		
		If chkLogConnections.CheckState Then LOG("  HTTP Connection closed [" & Sck(Index).RemoteHostIP & ":" & Sck(Index).RemotePort & "]")
	End Sub
	
	Private Sub Sck_ConnectionRequest(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_ConnectionRequestEvent) Handles Sck.ConnectionRequest
		Dim Index As Short = Sck.GetIndex(eventSender)
		Dim K As Short
		
		' look in the control array for a closed connection
		' note that it's starting to search at index 1 (not index 0)
		' since index 0 is the one listening on port 80
		For K = 1 To Sck.UBound
			'UPGRADE_NOTE: State was upgraded to CtlState. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			If Sck(K).CtlState = MSWinsockLib.StateConstants.sckClosed Then Exit For
		Next K
		
		' if all controls are connected, then create a new one
		If K > Sck.UBound Then
			K = Sck.UBound + 1
			Sck.Load(K) ' create a new winsock object
			
			'Load lblFileProgress(K) ' load the label to display the progress on each conection
			'lblFileProgress(K).Top = (lblFileProgress(0).Height + 5) * K
			'lblFileProgress(K).Visible = True
			
			ReDim Preserve CInfo(K) ' create new info structure
			
			tmrSendData.Load(K) ' load a new timer for the control
			tmrSendData(K).Enabled = False
			tmrSendData(K).Interval = 1
		End If
		
		' make sure the info structure contains default values (ie: 0's and "")
		CInfo(K).FileName = ""
		CInfo(0).FileNum = 0
		CInfo(K).TotalLength = 0
		CInfo(K).TotalSent = 0
		
		' accept the connection on the closed control or the new control
		Sck(K).Accept(eventArgs.requestID)
		If chkLogConnections.CheckState Then LOG("  HTTP Incoming connection [" & Sck(K).RemoteHostIP & ":" & Sck(K).RemotePort & "]")
	End Sub
	
	Private Sub Sck_DataArrival(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_DataArrivalEvent) Handles Sck.DataArrival
		Dim Index As Short = Sck.GetIndex(eventSender)
		Dim RequestedFile, rData, sHeader, ContentType As String
		Dim CompletePath As String
		
		Sck(Index).GetData(rData, VariantType.String)
		
		If rData Like "GET * HTTP/1.?*" Then
			' get requested file name
			RequestedFile = LeftRange(rData, "GET ", " HTTP/1.",  , IfStringNotFound.ReturnEmptyStr)
			
			' check if request contains "/../" or "/./" or "*" or "?"
			' (probably someone trying to get a file that is outside of the share)
			If InStr(1, RequestedFile, "/../") > 0 Or InStr(1, RequestedFile, "/./") > 0 Or InStr(1, RequestedFile, "*") > 0 Or InStr(1, RequestedFile, "?") > 0 Or RequestedFile = "" Then
				
				' send "Not Found" error ...
				sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
				CInfo(Index).TotalLength = Len(sHeader)
				Sck(Index).SendData(sHeader)
			Else
				CompletePath = Replace(PathShared & Replace(RequestedFile, "/", "\"), "\\", "\")
				CompletePath = Replace(CompletePath, "%20", " ")
				If chkLogRequests.CheckState Then LOG("  HTTP Request [" & Sck(Index).RemoteHostIP & ":" & Sck(Index).RemotePort & "] " & CompletePath)
				
				'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				If Dir(CompletePath, FileAttribute.Archive + FileAttribute.ReadOnly + FileAttribute.Directory) <> "" Then
					If (GetAttr(CompletePath) And FileAttribute.Directory) = FileAttribute.Directory Then
						' the request if for a directory listing...
						
						'UPGRADE_WARNING: Couldn't resolve default property of object BuildHTMLDirList(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						CInfo(Index).DataStr = BuildHTMLDirList(PathShared, RequestedFile)
						CInfo(Index).FileNum = -1
						
						' build the header
						sHeader = "HTTP/1.0 200 OK" & vbNewLine & "Server: " & ServerName & vbNewLine & "Content-Type: text/html" & vbNewLine & "Content-Length: " & Len(CInfo(Index).DataStr) & vbNewLine & vbNewLine
						
						' total data send is the header length + the length of the file requested
						CInfo(Index).TotalLength = Len(sHeader) + Len(CInfo(Index).DataStr)
					Else
						' requested file exists, open the file, send header, and start the transfer
						
						' display on the label the file name of currect transfer
						'lblFileProgress(Index).Caption = Right("00" & Index, 2) & " Transfering: " & RequestedFile
						CInfo(Index).FileName = RequestedFile
						
						' since one or more files may be opened at the same time, have to get the free file number
						CInfo(Index).FileNum = FreeFile
						FileOpen(CInfo(Index).FileNum, CompletePath, OpenMode.Binary, OpenAccess.Read)
						
						' get content-type depending on the file extension
						Select Case LCase(LeftRight(RequestedFile, ".",  , IfStringNotFound.ReturnEmptyStr))
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
						sHeader = "HTTP/1.0 200 OK" & vbNewLine & "Server: " & ServerName & vbNewLine & ContentType & vbNewLine & "Content-Length: " & LOF(CInfo(Index).FileNum) & vbNewLine & vbNewLine
						
						' total data send is the header length + the length of the file requested
						CInfo(Index).TotalLength = Len(sHeader) + LOF(CInfo(Index).FileNum)
					End If
					
					' send the header, the Sck_SendComplete event is gonna send the file...
					Sck(Index).SendData(sHeader)
				Else
					' send "Not Found" if file does not exsist on the share
					sHeader = "HTTP/1.0 404 Not Found" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
					CInfo(Index).TotalLength = Len(sHeader)
					Sck(Index).SendData(sHeader)
				End If
			End If
		Else
			' sometimes the browser makes "HEAD" requests (but it's not inplemented in this project)
			sHeader = "HTTP/1.0 501 Not Implemented" & vbNewLine & "Server: " & ServerName & vbNewLine & vbNewLine
			CInfo(Index).TotalLength = Len(sHeader)
			Sck(Index).SendData(sHeader)
		End If
	End Sub
	
	Private Function BuildHTMLDirList(ByVal Root As String, ByVal DirToList As String) As Object
		Dim Dirs As New Collection
		Dim Files As New Collection
		Dim Path, sDir, HTML As String
		Dim K As Integer
		
		Root = Replace(Root, "/", "\")
		DirToList = Replace(DirToList, "/", "\")
		
		If VB.Right(Root, 1) <> "\" Then Root = Root & "\"
		If VB.Left(DirToList, 1) = "\" Then DirToList = Mid(DirToList, 2)
		If VB.Right(DirToList, 1) <> "\" Then DirToList = DirToList & "\"
		
		DirToList = Replace(DirToList, "%20", " ")
		
		'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		sDir = Dir(Replace(Root & DirToList, "\\", "\") & "*.*", FileAttribute.Archive + FileAttribute.Directory + FileAttribute.ReadOnly)
		
		Do Until Len(sDir) = 0
			If sDir <> ".." And sDir <> "." Then
				Path = Replace(Root & DirToList, "\\", "\") & sDir
				
				
				If (GetAttr(Path) And FileAttribute.Directory) = FileAttribute.Directory Then
					Dirs.Add(sDir)
				Else
					Files.Add(sDir)
				End If
			End If
			
			'UPGRADE_WARNING: Dir has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			sDir = Dir()
		Loop 
		
		HTML = "<html><body>"
		
		If Dirs.Count() > 0 Then
			HTML = HTML & "<b>Directories:</b><br>"
			
			For K = 1 To Dirs.Count()
				'UPGRADE_WARNING: Couldn't resolve default property of object Dirs(K). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Dirs(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HTML = HTML & "<a href=""" & Replace(Replace("/" & DirToList & Dirs.Item(K), "\", "/"), "//", "/") & """>" & Dirs.Item(K) & "</a><br>" & vbNewLine
			Next K
		End If
		
		If Files.Count() > 0 Then
			HTML = HTML & "<P align=""center"" style=""font-style: bold; font-size: 48px;"">aWoWe Integrated HTTP server</p><br><b>Files:</b><br><table width=""100%"" border=""1"" cellpadding=""3"" cellspacing=""2"">" & vbNewLine
			
			For K = 1 To Files.Count()
				HTML = HTML & "<tr>" & vbNewLine
				'UPGRADE_WARNING: Couldn't resolve default property of object Files(K). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: Couldn't resolve default property of object Files(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HTML = HTML & "<td width=""100%""><a href=""" & Replace(Replace("/" & DirToList & Files.Item(K), "\", "/"), "//", "/") & """>" & Files.Item(K) & "</a></td>" & vbNewLine
				
				'UPGRADE_WARNING: Couldn't resolve default property of object Files(K). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				HTML = HTML & "<td nowrap>" & VB6.Format(FileLen(Replace(Root & DirToList, "\\", "\") & Files.Item(K)) / 1024#, "###,###,###,##0") & " KBytes</td>" & vbNewLine
				HTML = HTML & "</tr>" & vbNewLine
			Next K
			
			HTML = HTML & "</table>" & vbNewLine
		End If
		
		If Dirs.Count() = 0 And Files.Count() = 0 Then
			HTML = HTML & "This folder is empty."
		End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object BuildHTMLDirList. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BuildHTMLDirList = HTML & "</body></html>"
	End Function
	
	Private Sub Sck_SendComplete(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Sck.SendComplete
		Dim Index As Short = Sck.GetIndex(eventSender)
		If CInfo(Index).TotalSent >= CInfo(Index).TotalLength Then
			' if all data was sent, then close the connection
			Sck_CloseEvent(Sck.Item(Index), New System.EventArgs())
		Else
			' still have data to send, let the timer do that...
			
			' if you want to slow down the connection set the interval to a higher values
			' right now it's as fast as it can be
			tmrSendData(Index).Interval = 1
			tmrSendData(Index).Enabled = True ' start the timer
		End If
	End Sub
	
	Private Sub Sck_SendProgress(ByVal eventSender As System.Object, ByVal eventArgs As AxMSWinsockLib.DMSWinsockControlEvents_SendProgressEvent) Handles Sck.SendProgress
		Dim Index As Short = Sck.GetIndex(eventSender)
		' keep track of how much data was sent
		CInfo(Index).TotalSent = CInfo(Index).TotalSent + eventArgs.bytesSent
		
		' display file progress
		If CInfo(Index).FileNum > 0 Then
			On Error Resume Next
			
			'lblFileProgress(Index).Caption = Right("00" & Index, 2) & " Transfering: " & CInfo(Index).FileName & "   - " & _
			'CInfo(Index).TotalSent & " of " & LOF(CInfo(Index).FileNum) & " bytes sent, " & _
			'Format(CInfo(Index).TotalSent / LOF(CInfo(Index).FileNum) * 100#, "00.00") & " %Done."
			
			' if file size if 0 length, it gives a "division by 0" error, so just clear it
			If Err.Number <> 0 Then Err.Clear()
		End If
	End Sub
	
	Private Sub tmrSendData_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tmrSendData.Tick
		Dim Index As Short = tmrSendData.GetIndex(eventSender)
		' send 2KBytes at one time, then wait until it's sent, then send the other 2KBytes and so on
		Const BufferLength As Integer = 1024 * 2
		Dim Buffer As String
		
		If CInfo(Index).FileNum = -1 Then ' send data from a string instead of a file on the hard drive
			Buffer = VB.Left(CInfo(Index).DataStr, BufferLength)
			CInfo(Index).DataStr = Mid(CInfo(Index).DataStr, BufferLength + 1)
			
			Sck(Index).SendData(Buffer) ' send the data on the current connection
			
			If Len(CInfo(Index).DataStr) = 0 Then CInfo(Index).FileNum = 0
			
		ElseIf CInfo(Index).FileNum > 0 Then  ' do this code ONLY if a file was opened
			If Loc(CInfo(Index).FileNum) + BufferLength > LOF(CInfo(Index).FileNum) Then
				' the remaining data is less than the buffer length, so load only the remaining data
				
				Buffer = New String(Chr(0), LOF(CInfo(Index).FileNum) - Loc(CInfo(Index).FileNum))
			Else
				Buffer = New String(Chr(0), BufferLength)
			End If
			
			'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			FileGet(CInfo(Index).FileNum, Buffer) ' get data from file
			Sck(Index).SendData(Buffer) ' send the data on the current connection
			
			If Loc(CInfo(Index).FileNum) >= LOF(CInfo(Index).FileNum) Then
				' no data remaining to send
				FileClose(CInfo(Index).FileNum)
				
				' if file is closed, set filenumber to 0, in case the timer get's called again don't send any more data
				CInfo(Index).FileNum = 0
			End If
		End If
		
		' Sck_SendComplete event will enable the time back when current data is sent
		tmrSendData(Index).Enabled = False
	End Sub
	
	
	
	
	
	
	' Search from the beginning to end and return from StrFrom string to StrTo string
	' both strings (StrFrom and StrTo) must be found in order to be successfull
	'UPGRADE_NOTE: Str was upgraded to Str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Function LeftRange(ByRef Str_Renamed As String, ByRef StrFrom As String, ByRef StrTo As String, Optional ByRef Compare As CompareMethod = CompareMethod.Binary, Optional ByRef RetError As IfStringNotFound = IfStringNotFound.ReturnOriginalStr) As String
		Dim K, Q As Integer
		
		K = InStr(1, Str_Renamed, StrFrom, Compare)
		If K > 0 Then
			Q = InStr(K + Len(StrFrom), Str_Renamed, StrTo, Compare)
			
			If Q > K Then
				LeftRange = Mid(Str_Renamed, K + Len(StrFrom), (Q - K) - Len(StrFrom))
			Else
				LeftRange = IIf(RetError = IfStringNotFound.ReturnOriginalStr, Str_Renamed, "")
			End If
		Else
			LeftRange = IIf(RetError = IfStringNotFound.ReturnOriginalStr, Str_Renamed, "")
		End If
	End Function
	' Search from the beginning to end and return the right size of the string
	'UPGRADE_NOTE: Str was upgraded to Str_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Function LeftRight(ByRef Str_Renamed As String, ByRef LFind As String, Optional ByRef Compare As CompareMethod = CompareMethod.Binary, Optional ByRef RetError As IfStringNotFound = IfStringNotFound.ReturnOriginalStr) As String
		Dim K As Integer
		
		K = InStr(1, Str_Renamed, LFind, Compare)
		If K = 0 Then
			LeftRight = IIf(RetError = IfStringNotFound.ReturnOriginalStr, Str_Renamed, "")
		Else
			LeftRight = VB.Right(Str_Renamed, (Len(Str_Renamed) - Len(LFind)) - K + 1)
		End If
	End Function
End Class