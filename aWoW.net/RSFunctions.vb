Option Strict Off
Option Explicit On
Module RSFunctions
	Public LOGON_CHALLENGE_Working As Boolean
	Public LOGON_PROOF_Working As Boolean
	
	Const G_Length As Short = 1
	Const G As String = "7"
	Const K As String = "3"
	Const Default_N As String = "894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7"
	
	Sub Send_Client_LOGON_CHALLENGE(ByRef Index As Short, ByRef user As Short)
		While LOGON_CHALLENGE_Working = True
			System.Windows.Forms.Application.DoEvents()
		End While
		LOGON_CHALLENGE_Working = True
		
		Dim bigint1 As Short
		bigint1 = 17
		Dim bigint2 As Short
		bigint2 = 18
		Dim bigint3 As Short
		bigint3 = 19
		Dim bigint4 As Short
		bigint4 = 20
		Dim bigint5 As Short
		bigint5 = 16
		
		Dim N As String
		Dim B As String
		Dim X As String
		Dim Salt As String
		Dim PublicB As String
		
		'DEBUG Values:
		'****************************************************************************
		'N = UCase("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7")
		B = UCase("8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF")
		Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
		'Username = "TEST"
		'Password = "TEST"
		'****************************************************************************
		N = Default_N
		
		X = GenerateX(Users(user).Acc, Users(user).Pass, Salt)
		X = Reverse(X)
		N = Reverse(N)
		
		Data = ""
		
		HexToBigInt(N, bigint1)
		'Log "N(bigint)=" & BigIntToHex(bigint1)
		'Data = ""
		'Printf bigint1, "", "", False
		'Log Data
		HexToBigInt(X, bigint2)
		'Log "X(bigint)=" & BigIntToHex(bigint2)
		'Data = ""
		'Printf bigint2, "", "", False
		'Log Data
		HexToBigInt(G, bigint3)
		'Log "G(bigint)=" & BigIntToHex(bigint3)
		'Data = ""
		'Printf bigint3, "", "", False
		'Log Data
		ModExp(bigint3, bigint2, bigint1, bigint4)
		'Log "V=" & BigIntToHex(bigint4)
		'Data = ""
		'Printf bigint4, "", "", False
		'Log Data
		Users(user).V = BigIntToHex(bigint4)
		
		HexToBigInt(K, bigint1)
		Mult(bigint4, bigint1, bigint2) 'bigint4=temp1=K*V
		'Log "V*K=" & BigIntToHex(bigint4)
		
		B = Reverse(B)
		'N = Reverse(N)
		HexToBigInt(N, bigint1)
		HexToBigInt(B, bigint2)
		
		ModExp(bigint3, bigint2, bigint1, bigint5) 'bigint5=temp2=g^b mod N
		Add(bigint5, bigint4)
		
		Divd(bigint5, bigint1, bigint4) 'bigint5=B=(temp1+temp2) mod N
		Copyf(bigint5, bigint1)
		PublicB = Reverse(BigIntToHex(bigint1))
		'Log "PublicB=" & PublicB
		
		Users(user).PublicB = PublicB
		'PublicB = Reverse(PublicB)
		N = Default_N
		Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
		
		'sending the packet
		Dim i As Short
		Dim data_response(6 + 32 + 32 + 32 + 16 - 1) As Byte
		data_response(0) = RS_LOGON_CHALLENGE
		data_response(1) = rserr_no_error
		data_response(2) = Val("&H00")
		For i = 3 To 3 + 32
			data_response(i) = Val("&H" & Mid(PublicB, (i - 3) * 2 + 1, 2))
		Next i
		data_response(35) = G_Length
		data_response(36) = Int(CDbl(G))
		data_response(37) = 32
		For i = 38 To 38 + 32 - 1
			data_response(i) = Val("&H" & Mid(N, (i - 38) * 2 + 1, 2))
		Next i
		For i = 70 To 70 + 32 - 1
			data_response(i) = Val("&H" & Mid(Salt, (i - 70) * 2 + 1, 2))
		Next i
		For i = 102 To 102 + 16 - 1
			data_response(i) = 0
		Next i
		
		On Error Resume Next
		frmMain.RS(Index).SendData(data_response)
		
		LOGON_CHALLENGE_Working = False
	End Sub
	
	
	
	'***********************************************************************************************
	
	
	Sub Send_Client_LOGON_PROOF(ByRef ClientA As String, ByRef ClientM1 As String, ByRef Index As Short, ByRef user As Short)
		While LOGON_PROOF_Working = True
			System.Windows.Forms.Application.DoEvents()
		End While
		LOGON_PROOF_Working = True
		Dim i As Short
		Dim bigint1 As Short
		bigint1 = 15
		Dim bigint2 As Short
		bigint2 = 14
		Dim bigint3 As Short
		bigint3 = 13
		Dim bigint4 As Short
		bigint4 = 7
		Dim bigint5 As Short
		bigint5 = 8
		
		Dim U As String
		Dim N As String
		Dim A As String
		Dim B As String
		Dim Salt As String
		Dim S As String
		Dim M1 As String
		Dim PublicB As String
		Dim V As String
		Dim SS_Hash As String
		
		'DEBUG Values:
		'****************************************************************************
		'N = UCase("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7")
		B = UCase("8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF")
		Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
		'A = UCase("232fb1b88529643d95b8dce78f2750c75b2df37acba873eb31073839eda0738d")
		'M1 = UCase("eeb4adca80f4de02f9a9fe8d000d682e3ddfad6f")
		'PublicB = UCase("645d1f78973073701e12bc98aa38ea99b4bc435c32e8447c73ab077ae4d75964")
		'V = UCase("996ec7b349d5827043ecd0e6efba3daea5590f944d0184fee1b83ff4f59ecfa8")
		'****************************************************************************
		N = Default_N
		A = ClientA
		'B = Users(user).B
		PublicB = Users(user).PublicB
		V = Users(user).V
		
		Dim temp1 As String
		Dim temp2 As String
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		U = sha1.sha1(HexToStr(A) & HexToStr(PublicB))
		U = Reverse(U)
		
		N = Reverse(N)
		A = Reverse(A)
		B = Reverse(B)
		
		HexToBigInt(V, bigint1)
		'Log "V=" & V & "=" & BigIntToHex(bigint1)
		HexToBigInt(U, bigint2)
		'Log "U=" & U & "=" & BigIntToHex(bigint2)
		HexToBigInt(N, bigint3)
		'Log "N=" & N & "=" & BigIntToHex(bigint3)
		
		ModExp(bigint1, bigint2, bigint3, bigint4)
		'Log "temp1=" & BigIntToHex(bigint4)
		'Data = ""
		'Printf bigint4, "", "", False
		'Log Data
		
		HexToBigInt(A, bigint1)
		Mult(bigint4, bigint1, bigint3)
		'Log "temp2=" & BigIntToHex(bigint4)
		
		HexToBigInt(B, bigint1)
		'Log "B=" & B & "=" & BigIntToHex(bigint1)
		HexToBigInt(N, bigint3)
		'Log "N=" & N & "=" & BigIntToHex(bigint3)
		ModExp(bigint4, bigint1, bigint3, bigint2)
		'Log "S=" & BigIntToHex(bigint2)
		S = BigIntToHex(bigint2)
		S = Reverse(S)
		temp1 = ""
		temp2 = ""
		For i = 1 To Len(S) Step 2
			If i \ 2 Mod 2 = 0 Then
				temp1 = temp1 & Mid(S, i, 2)
			Else
				temp2 = temp2 & Mid(S, i, 2)
			End If
		Next i
		'Log "S1=" & temp1
		'Log "S2=" & temp2
		temp1 = HexToStr(temp1)
		temp2 = HexToStr(temp2)
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		temp1 = sha1.sha1(temp1)
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		temp2 = sha1.sha1(temp2)
		'Log "S1_Hash=" & temp1
		'Log "S2_Hash=" & temp2
		SS_Hash = ""
		For i = 1 To Len(temp1) Step 2
			SS_Hash = SS_Hash & Mid(temp1, i, 2) & Mid(temp2, i, 2)
		Next i
		'Log "SS_Hash=" & SS_Hash
		Users(user).SS_Hash = SS_Hash
		
		'Calc M1 to verify it matches the M1 supplied by the client
		Dim N_Hash As String
		Dim G_Hash As String
		Dim NG_Hash As String
		Dim User_Hash As String
		'Dim Username As String
		'Username = "TEST"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		User_Hash = sha1.sha1(UCase(Users(user).Acc))
		'Log "User_Hash=" & User_Hash
		N = Reverse(N)
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		N_Hash = sha1.sha1(HexToStr(N))
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		G_Hash = sha1.sha1(Chr(7))
		NG_Hash = ""
		For i = 1 To Len(N_Hash)
			NG_Hash = NG_Hash & Hex(Val("&H" & Mid(N_Hash, i, 1)) Xor Val("&H" & Mid(G_Hash, i, 1)))
		Next i
		'Log "NG_Hash=" & NG_Hash
		
		temp1 = NG_Hash & User_Hash & Salt & Reverse(A) & PublicB & SS_Hash
		'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		M1 = sha1.sha1(HexToStr(temp1))
		'Log "       M1=      " & M1
		'Log "       ClientM1=" & ClientM1
		
		'!!! Verify here client M1 and calculated M1
		Dim data_response() As Byte
		If UCase(M1) = UCase(ClientM1) Then
			'pass accepted, calculate M2 and send it
			temp1 = Reverse(A) & M1 & SS_Hash
			'UPGRADE_WARNING: Couldn't resolve default property of object sha1.sha1. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			M1 = sha1.sha1(HexToStr(temp1))
			'Log "M2=" & M1
			ReDim data_response(25)
			data_response(0) = RS_LOGON_PROOF
			data_response(1) = rserr_no_error
			For i = 2 To 21
				data_response(i) = Val("&H" & Mid(M1, (i - 2) * 2 + 1, 2))
			Next i
			data_response(22) = 0
			data_response(23) = 0
			data_response(24) = 0
			data_response(25) = 0
			On Error Resume Next
			frmMain.RS(Index).SendData(data_response)
		Else
			'wrong pass
			Log("    RS," & Index & " [" & Users(user).IP & "] - Bad password [" & Users(user).Acc & "]")
			ReDim data_response(1)
			data_response(0) = RS_LOGON_PROOF
			data_response(1) = rserr_bad_pass
			On Error Resume Next
			frmMain.RS(Index).SendData(data_response)
		End If
		
		
		LOGON_PROOF_Working = False
	End Sub
End Module