Option Strict Off
Option Explicit On
'UPGRADE_NOTE: System was upgraded to System_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
Module System_Renamed
	
	
	
	
	Function Reverse(ByRef temp As String) As String
		Dim i As Short
		Dim output As String
		output = ""
		For i = Len(temp) - 1 To 1 Step -2
			output = output & Mid(temp, i, 2)
		Next i
		Reverse = output
	End Function
	
	'UPGRADE_NOTE: hex was upgraded to hex_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Function HexToStr(ByRef hex_Renamed As String) As String
		Dim i As Short
		Dim temp1 As String
		temp1 = ""
		For i = 1 To Len(hex_Renamed) Step 2
			temp1 = temp1 & Chr(Val("&H" & Mid(hex_Renamed, i, 2)))
		Next i
		HexToStr = temp1
	End Function
	
	Sub LOG(ByRef text As String)
		frmLog.Text2.Text = frmLog.Text2.Text & vbNewLine & "[" & VB6.Format(TimeOfDay, "hh:mm:ss") & "] " & text
		frmLog.Text2.SelectionStart = Len(frmLog.Text2.Text)
		PrintLine(109, text)
	End Sub
	
	Sub Log_Packet(ByRef data() As Byte, ByRef who As String, ByRef Index As Short)
		Dim LOG As String
		Dim i As Short
		frmLog.Text2.Text = frmLog.Text2.Text & vbNewLine & who & "," & Index & ",rsvData as Byte ="
		LOG = who & "," & Index & ",rsvData as Byte ="
		For i = 0 To UBound(data)
			If i Mod 2 = 1 Then
				If Len(Hex(data(i))) = 1 Then
					frmLog.Text2.Text = frmLog.Text2.Text & "0" & Hex(data(i))
					LOG = LOG & "0" & Hex(data(i))
				Else
					frmLog.Text2.Text = frmLog.Text2.Text & "" & Hex(data(i))
					LOG = LOG & Hex(data(i))
				End If
			Else
				If Len(Hex(data(i))) = 1 Then
					frmLog.Text2.Text = frmLog.Text2.Text & " 0" & Hex(data(i))
					LOG = LOG & " 0" & Hex(data(i))
				Else
					frmLog.Text2.Text = frmLog.Text2.Text & " " & Hex(data(i))
					LOG = LOG & " " & Hex(data(i))
				End If
			End If
		Next i
		frmLog.Text2.Text = frmLog.Text2.Text & vbNewLine & who & "," & Index & ",rsvData as Char = "
		LOG = LOG & vbNewLine & who & "," & Index & ",rsvData as Char = "
		For i = 0 To UBound(data)
			frmLog.Text2.Text = frmLog.Text2.Text & Chr(data(i))
			LOG = LOG & Chr(data(i))
			If i Mod 2 = 1 Then frmLog.Text2.Text = frmLog.Text2.Text & " "
		Next i
		frmLog.Text2.SelectionStart = Len(frmLog.Text2.Text)
		PrintLine(109, LOG)
	End Sub
	
	
	Sub Initialize()
		ReDim Preserve OpenSockets(1)
		ReDim Preserve OpenSocketsWS(1)
		ReDim Preserve Users(1)
		Users_Count = 0
		frmMain.RS.Load(1)
		frmWSSetup.WS.Load(1)
		OpenSockets(0) = True
		OpenSockets(1) = False
		OpenSocketsWS(0) = True
		OpenSocketsWS(1) = False
		'rq_build = 4222    '1.2.4 enUS
		'rq_build = 4297    '1.3.1 enUS
		rq_build = 4375 '1.4.2 enUS
		RSFunctions.LOGON_CHALLENGE_Working = False
		RSFunctions.LOGON_PROOF_Working = False
		
		MAX_CHARACTERS_PER_USER = 10
		ReDim PlayerCharacters(1)
		
		'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		FileOpen(109, My.Application.Info.DirectoryPath & "\Logs\" & My.Application.Info.AssemblyName & VB6.Format(Today, " dd-mm-yyyy") & VB6.Format(TimeOfDay, " hh-mm") & ".log", OpenMode.Output)
	End Sub
	
	Sub Terminate()
		FileClose(109)
	End Sub
	
	'UPGRADE_NOTE: hex was upgraded to hex_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Function FormatHEX(ByRef hex_Renamed As String, ByRef length As Byte) As String
		If Len(hex_Renamed) < length Then
			FormatHEX = New String("0", length - Len(hex_Renamed)) & hex_Renamed
		End If
	End Function
End Module