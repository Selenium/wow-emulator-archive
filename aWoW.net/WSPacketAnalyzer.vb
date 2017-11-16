Option Strict Off
Option Explicit On
Module WSPacketAnalyzer
	
	Sub Analyze(ByRef Index As Short, ByRef data() As Byte)
		System_Renamed.Log_Packet(data, "WS Packet:", Index)
		
		Dim i As Short
		Dim data_response() As Byte
		Dim packet_len As Integer
		Dim opcode As Integer
		Dim templong As Integer
		Dim result As Byte
		If CDbl(frmWSSetup.WS(Index).Tag) <> -1 Then
			'decode it!
			WSFunctions.Decode(data, CShort(frmWSSetup.WS(Index).Tag))
			opcode = data(2) + data(3) * 256
		Else
			packet_len = data(1) + data(0) * 256
			opcode = data(2) + data(3) * 256
		End If
		
		Dim tempusername As String
		Select Case opcode
			
			Case CMSG_AUTH_SESSION
				LOG("    WS," & Index & " [" & frmWSSetup.WS(Index).RemoteHostIP & "] - CMSG_AUTH_SESSION")
				tempusername = ""
				
				For i = 14 To packet_len + 2 - 25 - 1
					tempusername = tempusername & Chr(data(i))
				Next i
				frmWSSetup.WS(Index).Tag = WSFunctions.FindRSUser(tempusername)
				'reset encode and decode vars
				For i = 0 To Len(Users(CInt(frmWSSetup.WS(Index).Tag)).SS_Hash) \ 2 - 1
					Users(CInt(frmWSSetup.WS(Index).Tag)).K(i) = Val("&H" & Mid(Users(CInt(frmWSSetup.WS(Index).Tag)).SS_Hash, (i * 2) + 1, 2))
				Next i
				Users(CInt(frmWSSetup.WS(Index).Tag)).Key(0) = 0
				Users(CInt(frmWSSetup.WS(Index).Tag)).Key(1) = 0
				Users(CInt(frmWSSetup.WS(Index).Tag)).Key(2) = 0
				Users(CInt(frmWSSetup.WS(Index).Tag)).Key(3) = 0
				ReDim data_response(4)
				data_response(0) = &H0s
				data_response(1) = &H3s
				data_response(3) = SMSG_AUTH_RESPONSE \ 256
				data_response(2) = SMSG_AUTH_RESPONSE Mod 256
				data_response(4) = &HCs '&HC - no error &HD - auth failed
				
				LOG("    WS," & Index & " [" & frmWSSetup.WS(Index).RemoteHostIP & "] - SMSG_AUTH_RESPONSE")
				On Error Resume Next
				frmWSSetup.WS(Index).SendData(data_response)
				
				'these packets must be decoded and endcoded!
			Case CMSG_PING
				LOG("    WS," & Index & " [" & Users(CInt(frmWSSetup.WS(Index).Tag)).IP & "] - CMSG_PING")
				data(2) = &HDDs
				WSFunctions.Encode(data, CShort(frmWSSetup.WS(Index).Tag))
				On Error Resume Next
				frmWSSetup.WS(Index).SendData(data)
				LOG("    WS," & Index & " [" & Users(CInt(frmWSSetup.WS(Index).Tag)).IP & "] - SMSG_PONG")
				
			Case CMSG_CHAR_ENUM
				LOG("    WS," & Index & " [" & Users(CInt(frmWSSetup.WS(Index).Tag)).IP & "] - CMSG_CHAR_ENUM")
				ReDim data_response(159)
				data_response(0) = 0 'uint16 length
				data_response(1) = 3
				data_response(2) = &H3Bs 'uint16 opcode = 0x003B
				data_response(3) = 0
				data_response(4) = 0 'uint8 numcharacters
				
				
				System_Renamed.Log_Packet(data_response, "SMSG_CHAR_ENUM sent packet", Index)
				WSFunctions.Encode(data_response, CShort(frmWSSetup.WS(Index).Tag))
				LOG("    WS," & Index & " [" & frmWSSetup.WS(Index).RemoteHostIP & "] - SMSG_CHAR_ENUM")
				On Error Resume Next
				frmWSSetup.WS(Index).SendData(data_response)
				System_Renamed.Log_Packet(data_response, "Encoded sent packet", Index)
				
			Case CMSG_CHAR_CREATE
				LOG("    WS," & Index & " [" & Users(CInt(frmWSSetup.WS(Index).Tag)).IP & "] - CMSG_CHAR_CREATE")
				templong = WSFunctions.GetFreeChar
				'data(4) uint8 unknown1
				i = 6
				DataBase.PlayerCharacters(templong).Name = ""
				While data(i) <> 0
					DataBase.PlayerCharacters(templong).Name = DataBase.PlayerCharacters(templong).Name & Chr(data(i))
					i = i + 1
				End While
				i = i + 1
				DataBase.PlayerCharacters(templong).Race = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Class_Renamed = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Gender = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Skin = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Face = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Hairstyle = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Haircolor = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Facialhair = data(i)
				i = i + 1
				DataBase.PlayerCharacters(templong).Outfitid = data(i)
				
				result = ccerr_no_error
				If Users(CInt(frmWSSetup.WS(Index).Tag)).Chars = MAX_CHARACTERS_PER_USER Then result = ccerr_max_characters
				If FindCharName(DataBase.PlayerCharacters(templong).Name) = -1 Then result = ccerr_name_unavailable
				
				
				ReDim data_response(4)
				data_response(0) = 0 'uint16 length
				data_response(1) = 3
				data_response(2) = SMSG_CHAR_CREATE 'uint16 opcode = 0x003A
				data_response(3) = 0
				data_response(4) = result 'uint8 result
				LOG("    WS," & Index & " [" & Users(CInt(frmWSSetup.WS(Index).Tag)).IP & "] - SMSG_CHAR_CREATE [" & DataBase.PlayerCharacters(templong).Name & "]")
				System_Renamed.Log_Packet(data_response, "SMSG_CHAR_CREATE", Index)
				WSFunctions.Encode(data_response, CShort(frmWSSetup.WS(Index).Tag))
				On Error Resume Next
				frmWSSetup.WS(Index).SendData(data_response)
				System_Renamed.Log_Packet(data_response, "SMSG_CHAR_CREATE", Index)
				
				
				
				
				'debug!
			Case Else
				System_Renamed.Log_Packet(data, "Unknown packet received from WS", Index)
				'WSFunctions.Decode data, frmWSSetup.WS(Index).Tag
				'System.Log_Packet data, "Decoded unknown packet", Index
		End Select
		
		Exit Sub
ending: 
		System_Renamed.Log_Packet(data, "Bad packet received from WS", Index)
	End Sub
End Module