Option Strict Off
Option Explicit On
Module WSFunctions
	
	Sub Send_SMSG_AUTH_CHALLENGE(ByRef Index As Short)
		Dim data_response(7) As Byte
		data_response(0) = &H0s
		data_response(1) = &H6s
		data_response(3) = SMSG_AUTH_CHALLENGE \ 256
		data_response(2) = SMSG_AUTH_CHALLENGE Mod 256
		
		data_response(4) = &H71s
		data_response(5) = &H2Cs
		data_response(6) = &H73s
		data_response(7) = &H88s
		
		LOG("    WS," & Index & " [" & frmWSSetup.WS(Index).RemoteHostIP & "] - SMSG_AUTH_CHALLENGE")
		On Error Resume Next
		frmWSSetup.WS(Index).SendData(data_response)
	End Sub
	
	Function FindRSUser(ByRef user As String) As Short
		FindRSUser = -1
		Dim i As Short
		For i = 0 To Users_Count
			If Users(i).Acc = user Then
				FindRSUser = i
				'Log Str(i) & ":" & user
				Exit Function
			End If
		Next i
	End Function
	
	
	Sub Decode(ByRef data() As Byte, ByRef user As Short)
		'Dim i As Integer
		'Log "DEBUG: Decoding..."
		'Log "DEBUG: SS_Hash=" & Users(user).SS_Hash
		
		'Dim a As Integer
		'Dim B As Integer
		'Dim D As Integer
		'For i = 0 To 5
		'    a = Users(user).Key(0)
		'    Users(user).Key(0) = data(i)
		'    B = data(i)
		'
		'    'B = (B - a)
		'    If (B - a) < 0 Then
		'        B = (B - a) + 256
		'    Else
		'        B = B - a
		'    End If
		'    D = Users(user).Key(1)
		'    a = Users(user).K(D)
		'    a = a Xor B
		'    data(i) = a
		'    a = Users(user).Key(1)
		'    a = a + 1
		'    Users(user).Key(1) = a Mod 40
		'Next i
	End Sub
	
	Sub EncodeOld(ByRef data() As Byte, ByRef user As Short)
		Dim i As Short
		Dim a As Short
		Dim D As Short
		'Log "DEBUG: Encoding..."
		'Log "DEBUG: SS_Hash=" & Users(user).SS_Hash
		
		For i = 0 To 3
			a = Users(user).Key(3)
			a = Users(user).K(a) Xor data(i)
			D = Users(user).Key(2)
			a = a + D
			a = a Mod 256
			data(i) = a
			Users(user).Key(2) = a
			a = Users(user).Key(3)
			a = a + 1
			Users(user).Key(3) = a Mod 40
		Next i
	End Sub
	
	Sub Encode(ByRef data() As Byte, ByRef user As Short)
		'Dim i As Integer
		'Dim a As Integer
		'Log "DEBUG: Encoding..."
		'Log "DEBUG: SS_Hash=" & Users(user).SS_Hash
		
		'For i = 0 To 3
		'    a = (data(i) Xor Users(user).K(Users(user).Key(3)))
		'    a = a + Users(user).Key(2)
		'    data(i) = a Mod 256
		'    Users(user).Key(2) = data(i)
		'    Users(user).Key(3) = (Users(user).Key(3) + 1) Mod 40
		'Next i
	End Sub
	
	Function GetFreeChar() As Integer
		'generate guid and initialize it!
		GetFreeChar = -1
		Dim i As Short
		For i = 0 To UBound(PlayerCharacters)
			If PlayerCharacters(i).Name = "" Then
				GetFreeChar = i
				PlayerCharacters(i).Guid = CInt(FormatHEX(CStr(Val("&H" & VB6.Format(i))), 8))
				Exit Function
			End If
		Next i
	End Function
	
	Function FindCharName(ByRef FindName As String) As Integer
		FindCharName = -1
		Dim i As Short
		For i = 0 To UBound(PlayerCharacters)
			If PlayerCharacters(i).Name = FindName Then
				FindCharName = i
				Exit Function
			End If
		Next i
	End Function
End Module