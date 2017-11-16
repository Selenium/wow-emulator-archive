Attribute VB_Name = "modWSPackets"
Option Explicit

Sub Analyze(Index As Integer, data() As Byte)
'On Error GoTo Error
    Dim i As Integer
    Dim j As Integer
    Dim l As Integer
    Dim data_response() As Byte
    Dim packet_len As Long
    Dim packet_lenght As Long
    Dim opcode As Long
    Dim templong As Long
    Dim result As Byte
    Dim LineNR As Long
    Dim CharGUID As String
    Dim CharacterFound As Integer
    Dim iInt As Integer
    Dim CharFound As Boolean
    Dim CharName As String
    Dim CharacterID As Integer
    Dim AccountID As Integer
        
    If frmCore.sckWS(Index).Tag <> -1 Then
        'decode it!
        modWSFunctions.Decode data, frmCore.sckWS(Index).Tag
        opcode = data(2) + data(3) * (2 ^ 8)
    Else
        packet_len = data(1) + data(0) * (2 ^ 8)
        opcode = data(2) + data(3) * (2 ^ 8)
    End If

    Debug.Print opcode
    
    Select Case opcode
        ' Client Auth
        Case CMSG_AUTH_SESSION
                    Log "Client Authing [" & frmCore.sckWS(Index).RemoteHostIP & "]"

                    Dim tempusername As String
                    tempusername = ""
                    
                    For i = 14 To packet_len + 2 - 25 - 1
                        If Chr(data(i)) = Chr(0) Then
                            Exit For
                        End If
                        tempusername = tempusername + Chr(data(i))
                    Next i
                    frmCore.sckWS(Index).Tag = intAccountID(tempusername)
                        'reset encode and decode vars
                      
                        For i = 0 To Len(Account(frmCore.sckWS(Index).Tag).SS_Hash) \ 2 - 1
                            Account(frmCore.sckWS(Index).Tag).K(i) = Val("&H" & Mid(Account(frmCore.sckWS(Index).Tag).SS_Hash, (i * 2) + 1, 2))
                        Next i
                        Account(frmCore.sckWS(Index).Tag).Key(0) = 0
                        Account(frmCore.sckWS(Index).Tag).Key(1) = 0
                        Account(frmCore.sckWS(Index).Tag).Key(2) = 0
                        Account(frmCore.sckWS(Index).Tag).Key(3) = 0
                    ReDim data_response(4) As Byte
                    data_response(0) = &H0
                    data_response(1) = &H3
                    data_response(3) = SMSG_AUTH_RESPONSE \ 256
                    data_response(2) = SMSG_AUTH_RESPONSE Mod 256
                    data_response(4) = &HC  '&HC - no error &HD - auth failed

                    Log "Authed WS [" & frmCore.sckWS(Index).RemoteHostIP & "]"
                    On Error Resume Next
                        modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                        frmCore.sckWS(Index).SendData data_response


                    ' Send Addon Info
                    
                    ReDim data_response(4) As Byte
                    data_response(0) = 0
                    data_response(1) = 3
                    data_response(3) = SMSG_ADDON_INFO \ 256
                    data_response(2) = SMSG_ADDON_INFO Mod 256
                    data_response(4) = 0
                    
                    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response
        'Pings - these packets must be decoded and endcoded!
        Case CMSG_PING
                    data(2) = &HDD
                    modWSFunctions.Encode data, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data

        ' Character List
        Case CMSG_CHAR_ENUM
                    Log "CMSG_CHAR_ENUM [" & Account(frmCore.sckWS(Index).Tag).AccIp & "] [" & Account(frmCore.sckWS(Index).Tag).AccChars & "]"
                    
                    'Send_Chars Index
                    'Exit Sub
                    
                    If Account(frmCore.sckWS(Index).Tag).AccChars < 1 Then ' Account got no characters
                        ReDim data_response(159) As Byte
                        data_response(0) = 0        'uint16 length
                        data_response(1) = 3
                        data_response(2) = SMSG_CHAR_ENUM     'uint16 opcode = 0x003B
                        data_response(3) = 0
                        data_response(4) = 0        'uint8 numcharacters
                    Else ' Account do got characters
                        packet_lenght = 4 + (159 * Account(frmCore.sckWS(Index).Tag).AccChars)
                        
                        For i = 1 To Account(frmCore.sckWS(Index).Tag).AccChars
                            packet_lenght = packet_lenght + Len(Account(frmCore.sckWS(Index).Tag).AccChar(i).Name)
                        Next i
                        
                        ReDim data_response(packet_lenght) As Byte
                        data_response(0) = 0        'uint16 length
                        data_response(1) = 3
                        data_response(2) = SMSG_CHAR_ENUM     'uint16 opcode = 0x003B
                        data_response(3) = 0
                        data_response(4) = Account(frmCore.sckWS(Index).Tag).AccChars        'uint8 numcharacters
                    
                    If Account(frmCore.sckWS(Index).Tag).AccChars > 0 Then
                        If Account(frmCore.sckWS(Index).Tag).AccChar(1).Name = "" Then
                            Account(frmCore.sckWS(Index).Tag).AccChars = 0
                        End If
                    End If
                    
                    LineNR = 4
                    
                    If Account(frmCore.sckWS(Index).Tag).AccChars > 0 Then
                        For i = 1 To Account(frmCore.sckWS(Index).Tag).AccChars
                        
                            If Len(Account(frmCore.sckWS(Index).Tag).AccChar(i).GUID) < 8 Then
                                Account(frmCore.sckWS(Index).Tag).AccChar(i).GUID = GetFreeGUID
                            End If
                        
                            For j = 1 To 8
                                LineNR = LineNR + 1
                                data_response(LineNR) = CByte(Mid(Account(frmCore.sckWS(Index).Tag).AccChar(i).GUID, j, 1))
                            Next j
                            
                            For j = 1 To Len(Account(frmCore.sckWS(Index).Tag).AccChar(i).Name)
                                LineNR = LineNR + 1
                                data_response(LineNR) = Asc(Mid(Account(frmCore.sckWS(Index).Tag).AccChar(i).Name, j, 1))
                            Next j
                            
                            data_response(LineNR + 1) = 0
                            data_response(LineNR + 2) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Race
                            data_response(LineNR + 3) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Class
                            data_response(LineNR + 4) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Gender
                            data_response(LineNR + 5) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Skin
                            data_response(LineNR + 6) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Face
                            data_response(LineNR + 7) = Account(frmCore.sckWS(Index).Tag).AccChar(i).HairStyle
                            data_response(LineNR + 8) = Account(frmCore.sckWS(Index).Tag).AccChar(i).HairColor
                            data_response(LineNR + 9) = Account(frmCore.sckWS(Index).Tag).AccChar(i).FacialHair
                            data_response(LineNR + 10) = Account(frmCore.sckWS(Index).Tag).AccChar(i).Level
                            data_response(LineNR + 11) = Account(frmCore.sckWS(Index).Tag).AccChar(i).OutfitID
                            data_response(LineNR + 12) = 0 'ZoneID
                            data_response(LineNR + 13) = 0
                            data_response(LineNR + 14) = 0
                            data_response(LineNR + 15) = 0
                            data_response(LineNR + 16) = 0 'MapID
                            data_response(LineNR + 17) = 0
                            data_response(LineNR + 18) = 0
                            data_response(LineNR + 19) = 0
                            data_response(LineNR + 20) = 0 'positionX
                            data_response(LineNR + 21) = 0
                            data_response(LineNR + 22) = 0
                            data_response(LineNR + 23) = 0
                            data_response(LineNR + 24) = 0 'positionY
                            data_response(LineNR + 25) = 0
                            data_response(LineNR + 26) = 0
                            data_response(LineNR + 27) = 0
                            data_response(LineNR + 28) = 0 'positionZ
                            data_response(LineNR + 29) = 0
                            data_response(LineNR + 30) = 0
                            data_response(LineNR + 31) = 0
                            data_response(LineNR + 32) = 0 'Unknown
                            data_response(LineNR + 33) = 0 'Unknown
                            data_response(LineNR + 34) = 0 'Unknown
                            data_response(LineNR + 35) = 0 'Character Lock
                            data_response(LineNR + 36) = 0 'Rest
                            data_response(LineNR + 37) = 0
                            data_response(LineNR + 38) = 0
                            data_response(LineNR + 39) = 0
                            data_response(LineNR + 40) = 0 'PetInfoID
                            data_response(LineNR + 41) = 0
                            data_response(LineNR + 42) = 0
                            data_response(LineNR + 43) = 0
                            data_response(LineNR + 44) = 0 'PetLevel
                            data_response(LineNR + 45) = 0
                            data_response(LineNR + 46) = 0
                            data_response(LineNR + 47) = 0
                            data_response(LineNR + 48) = 0 'PetFamilyID
                            data_response(LineNR + 49) = 0
                            data_response(LineNR + 50) = 0
                            data_response(LineNR + 51) = 0
                            
                            LineNR = LineNR + 51
                            
                            For j = 0 To 19
                              If Account(frmCore.sckWS(Index).Tag).AccChar(i).ItemsEquiped(j).DisplayID > 0 Then
                                LineNR = LineNR + 1
                                CopyMemory data_response(LineNR), Account(frmCore.sckWS(Index).Tag).AccChar(i).ItemsEquiped(j).DisplayID, 4
                                LineNR = LineNR + 4
                                data_response(LineNR) = j
                              Else
                                LineNR = LineNR + 1
                                data_response(LineNR) = 0
                                LineNR = LineNR + 1
                                data_response(LineNR) = 0
                                LineNR = LineNR + 1
                                data_response(LineNR) = 0
                                LineNR = LineNR + 1
                                data_response(LineNR) = 0
                                LineNR = LineNR + 1
                                data_response(LineNR) = 0
                              End If
                            Next j
                        Next i
                    End If
                    
                    LineNR = LineNR - 1
                    
                    If LineNR > 255 Then
                        data_response(1) = LineNR Mod 256
                        data_response(0) = LineNR \ 256
                    Else
                        data_response(1) = LineNR
                    End If
                    
                    End If
                    
                    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response
        Case CMSG_CHAR_CREATE ' Client send that a character is created
                    Log "CMSG_CHAR_CREATE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
                    templong = modWSFunctions.GetFreeChar
                    If templong < 1 Then Log "Error with Chars": Exit Sub
                    
                        i = 6
                        CharName = ""
                        While data(i) <> 0
                            CharName = CharName + Chr(data(i)) ' Get the character name
                            i = i + 1
                        Wend
                        
                    result = CHAR_CREATE_OK
                    If frmCore.sckWS(Index).Tag < 1 Then result = CHAR_CREATE_ERROR
                    If Account(frmCore.sckWS(Index).Tag).AccChars >= MAX_CHARACTERS_PER_USER Then result = CHAR_CREATE_MAX_CHARACTERS_ON_THIS_ACCOUNT
                    If FindCharName(CharName) <> -1 Then result = CHAR_CREATE_NAME_IN_USE
                    
                    
                    If result = CHAR_CREATE_OK Then
                        'data(4) uint8 unknown1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name = CharName
                        If Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name = "" Then Log "Failed to create Character: No name found": Exit Sub
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).GUID = GetFreeGUID
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Class = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Skin = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Face = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).HairStyle = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).HairColor = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).FacialHair = data(i)
                        i = i + 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).OutfitID = data(i)
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Level = 1
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).MapID = 451
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionX = 16391.8
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionY = 16341.2
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionZ = 69.5
                        Account(frmCore.sckWS(Index).Tag).AccChars = Account(frmCore.sckWS(Index).Tag).AccChars + 1
                        
                        If Account(frmCore.sckWS(Index).Tag).AccChar(templong).Class = 1 Then ' Warrior (Those under aint done like the rogue stuff because i didnt have time to add them in the items.scp
                        
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_HEAD).DisplayID = 35447
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_HEAD).ItemID = 22418
                            
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_CHEST).DisplayID = 35049
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_CHEST).ItemID = 22416
                            
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_HANDS).DisplayID = 35050
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_HANDS).ItemID = 22421
                        
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_SHOULDERS).DisplayID = 35177
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_SHOULDERS).ItemID = 22419
                            
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_LEGS).DisplayID = 35051
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ItemsEquiped(EQUIPMENT_SLOT_LEGS).ItemID = 22417
                            
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Class = 4 Then ' Rogue
                        
                            EquipItem frmCore.sckWS(Index).Tag, templong, 22478 ' Equip items
                            EquipItem frmCore.sckWS(Index).Tag, templong, 22476
                            EquipItem frmCore.sckWS(Index).Tag, templong, 22481
                            EquipItem frmCore.sckWS(Index).Tag, templong, 22479
                            EquipItem frmCore.sckWS(Index).Tag, templong, 22477
                            
                        End If
                        
                        ' Give the races their correct model
                        If Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 1 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 49 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 2 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 51 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 3 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 53 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 4 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 55 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 5 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 57 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 6 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 59 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 7 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 1563 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        ElseIf Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = 8 Then
                            Account(frmCore.sckWS(Index).Tag).AccChar(templong).ModelID = 1478 + Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender
                        End If
                        
                        modAccountSystem.LoadAccounts True, False ' Save and load ;)
                        modAccountSystem.LoadAccounts False, False
                        modAccountSystem.LoadAccounts True, False
                        modAccountSystem.LoadAccounts False, False
                    End If
                    
                    If result = CHAR_CREATE_OK Then
                        Log "Created OK"
                    ElseIf result = CHAR_CREATE_MAX_CHARACTERS_ON_THIS_ACCOUNT Then
                        Log "Max Chars"
                    ElseIf result = CHAR_CREATE_NAME_IN_USE Then
                        Log "Name in Use"
                    Else
                        Log "Created Error? (" & (result) & ")"
                    End If
                    
                    ' Send back the response!
                    ReDim data_response(4) As Byte
                    data_response(0) = 0                    'uint16 length
                    data_response(1) = 3
                    data_response(2) = SMSG_CHAR_CREATE     'uint16 opcode = 0x003A
                    data_response(3) = &H0
                    data_response(4) = result               'uint8 result
                    Log "Character Created  [" & Account(frmCore.sckWS(Index).Tag).AccIp & "] SMSG_CHAR_CREATE [" & Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name & "]"
                    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response

        Case CMSG_CHAR_DELETE ' Client wants to remove a character
            Log "CMSG_CHAR_DELETE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            CharGUID = data(6) & data(7) & data(8) & data(9) & data(10) & data(11) & data(12) & data(13)
            CharacterFound = 0
            
            For i = 1 To Account(frmCore.sckWS(Index).Tag).AccChars
                If Account(frmCore.sckWS(Index).Tag).AccChar(i).GUID = CharGUID Then
                    CharacterFound = i ' Zomg the guid was found at this character, now gogo delete
                End If
            Next i
            
            If CharacterFound = 0 Then
                Log "Couldn't find Character to delete [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            Else
                Log "Deleted Character [" & Account(frmCore.sckWS(Index).Tag).AccIp & "] [" & Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Name & "]"
                
                ' Setting everything to zero
                Account(frmCore.sckWS(Index).Tag).AccChars = Account(frmCore.sckWS(Index).Tag).AccChars - 1
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Name = ""
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Class = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Race = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Face = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).FacialHair = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).HairStyle = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).HairColor = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).GuildID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).GUID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Gender = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Level = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).MapID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).ZoneID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).OutfitID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).PetFamilyID = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).PetInfo = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).PetLevel = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Rest = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).Skin = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).positionX = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).positionY = 0
                Account(frmCore.sckWS(Index).Tag).AccChar(CharacterFound).positionZ = 0
                
                modAccountSystem.LoadAccounts True ' Save and load
                modAccountSystem.LoadAccounts False
            End If
            
            ' Send back response ofc :)
            ReDim data_response(4) As Byte
            data_response(0) = 0                    'uint16 length
            data_response(1) = 3
            data_response(2) = SMSG_CHAR_DELETE     'uint16 opcode = 0x003A
            data_response(3) = &H0
            data_response(4) = &H39                 'uint8 result
            
            modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response
        Case CMSG_PLAYER_LOGIN ' OMG! the player wants to enter the world
            Log "CMSG_PLAYER_LOGIN [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            modPlayerLogin.PlayerLogin Index, data
        
            'debug!
        Case CMSG_REQUEST_ACCOUNT_DATA ' Something ;)
            Log "CMSG_REQUEST_ACCOUNT_DATA [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            ' Nothing
        Case CMSG_UPDATE_ACCOUNT_DATA ' Something ;)
            Log "CMSG_UPDATE_ACCOUNT_DATA [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            'Nothing
            
            'ReDim data_response(4) As Byte
            'data_response(0) = 0                    'uint16 length
            'data_response(1) = 2
            'data_response(2) = SMSG_UPDATE_ACCOUNT_DATA Mod 256     'uint16 opcode = 0x003A
            'data_response(3) = SMSG_UPDATE_ACCOUNT_DATA \ 256
            
            'modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
            '        On Error Resume Next
            '            frmCore.sckWS(Index).SendData data_response
        Case CMSG_NAME_QUERY ' Client found a character with nothing as name, now it requests its name by giving us the GUID
            Log "CMSG_NAME_QUERY [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            CharGUID = 0
            For i = 6 To 13
                CharGUID = CharGUID & (data(i)) ' Here's the GUID
            Next i
            
            CharFound = False
            

            For i = 0 To UBound(Account)
                For j = 1 To Account(i).AccChars
                    If Account(i).AccChar(j).GUID = CharGUID Then
                        CharFound = True
                        CharacterID = j
                        AccountID = i ' And it was found!
                        Exit For
                    End If
                Next j
            Next i
            
            If CharFound Then ' The character was found
                Log "Found the Char!"
                iInt = 3 + 8 + 13 + Len(Account(AccountID).AccChar(CharacterID).Name)
                ReDim data_response(iInt) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 2
                data_response(2) = SMSG_NAME_QUERY_RESPONSE     'uint16 opcode = 0x003A
                data_response(3) = 0
                
                j = 3
                For i = 1 To 8
                    j = j + 1
                    data_response(j) = CLng(Mid(CharGUID, i, 1))
                Next i
                
                For i = 1 To Len(Account(AccountID).AccChar(CharacterID).Name)
                    j = j + 1
                    data_response(j) = Asc(Mid(Account(AccountID).AccChar(CharacterID).Name, i, 1))
                Next i
                
                data_response(j + 1) = 0
                CopyMemory data_response(j + 2), Account(AccountID).AccChar(CharacterID).Race, 4
                CopyMemory data_response(j + 6), Account(AccountID).AccChar(CharacterID).Gender, 4
                CopyMemory data_response(j + 10), Account(AccountID).AccChar(CharacterID).Class, 4
                j = j + 13
            Else ' The character wasn't found
                Log "Didn't find the Char."
                iInt = 3 + 8 + 13 + Len("<Non-existed now character>")
                ReDim data_response(iInt) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 2
                data_response(2) = SMSG_NAME_QUERY_RESPONSE     'uint16 opcode = 0x003A
                data_response(3) = 0

                j = 3
                For i = 1 To 8
                    j = j + 1
                    data_response(j) = CLng(Mid(CharGUID, i, 1))
                Next i
                
                For i = 1 To Len("<Non-existed now character>")
                    j = j + 1
                    data_response(j) = Asc(Mid("<Non-existed now character>", i, 1)) ' Don't ask me why the name should be <Non-existed now character> but it was like that in mangos :P
                Next i

                ' Set empty data
                data_response(j + 1) = 0
                data_response(j + 2) = 0
                data_response(j + 3) = 0
                data_response(j + 4) = 0
                data_response(j + 5) = 0
                data_response(j + 6) = 0
                data_response(j + 7) = 0
                data_response(j + 8) = 0
                data_response(j + 9) = 0
                data_response(j + 10) = 0
                data_response(j + 11) = 0
                data_response(j + 12) = 0
                data_response(j + 13) = 0
                j = j + 13
            End If
            
            j = j - 1
            
            If j > 255 Then
                data_response(0) = j \ 256
                data_response(1) = j Mod 256
            Else
                data_response(1) = j
            End If
            
            Log "NAME QUERY-A" & AccountID & "-C" & CharacterID & "-   " & j & " / " & UBound(data_response)
            
            modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response ' Send it!
        Case CMSG_SET_ACTIVE_MOVER ' something :D
            Log "CMSG_SET_ACTIVE_MOVER [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            'Nothing
        Case CMSG_REQUEST_RAID_INFO ' Here it requests for raid info (disabled)
            Log "CMSG_REQUEST_RAID_INFO [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            ReDim data_response(7) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 6
                data_response(2) = SMSG_RAID_INSTANCE_INFO Mod 256     'uint16 opcode = 0x003A
                data_response(3) = SMSG_RAID_INSTANCE_INFO \ 256
                
                data_response(4) = 0
                data_response(5) = 0
                data_response(6) = 0
                data_response(7) = 0
                
                modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
               '         frmCore.sckWS(Index).SendData data_response
        Case CMSG_GMTICKET_GETTICKET ' Requests all gmtickets (disabled)
            Log "CMSG_GMTICKET_GETTICKET [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            ReDim data_response(7) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 6
                data_response(2) = SMSG_QUERY_TIME_RESPONSE Mod 256     'uint16 opcode = 0x003A
                data_response(3) = SMSG_QUERY_TIME_RESPONSE \ 256
                
                data_response(4) = 0
                data_response(5) = 0
                data_response(6) = 0
                data_response(7) = 0
                
                modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
               '         frmCore.sckWS(Index).SendData data_response
                        
            ReDim data_response(11) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 10
                data_response(2) = SMSG_GMTICKET_GETTICKET Mod 256     'uint16 opcode = 0x003A
                data_response(3) = SMSG_GMTICKET_GETTICKET \ 256
                
                data_response(4) = 6
                data_response(5) = 0
                data_response(6) = 0
                data_response(7) = 0
                
                data_response(8) = 0
                data_response(9) = 0
                data_response(10) = 0
                data_response(11) = 0
                
                modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
              '          frmCore.sckWS(Index).SendData data_response
                        
        Case CMSG_QUERY_TIME ' Hmm something i guess :P
            Log "CMSG_QUERY_TIME [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            ReDim data_response(7) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 6
                data_response(2) = SMSG_QUERY_TIME_RESPONSE Mod 256     'uint16 opcode = 0x003A
                data_response(3) = SMSG_QUERY_TIME_RESPONSE \ 256
                
                data_response(4) = 0
                data_response(5) = 0
                data_response(6) = 0
                data_response(7) = 0
                
                modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
              '          frmCore.sckWS(Index).SendData data_response
        Case MSG_QUERY_NEXT_MAIL_TIME ' Something with mail >.<
            Log "MSG_QUERY_NEXT_MAIL_TIME [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            ReDim data_response(7) As Byte
                data_response(0) = 0                    'uint16 length
                data_response(1) = 6
                data_response(2) = MSG_QUERY_NEXT_MAIL_TIME Mod 256     'uint16 opcode = 0x003A
                data_response(3) = MSG_QUERY_NEXT_MAIL_TIME \ 256
                
                data_response(4) = &H0
                data_response(5) = &HC0
                data_response(6) = &HA8
                data_response(7) = &HC7
                
                modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
               '         frmCore.sckWS(Index).SendData data_response
        Case CMSG_BATTLEFIELD_STATUS ' BG status
            Log "CMSG_BATTLEFIELD_STATUS [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            'Nothing
        Case CMSG_MEETING_STONE_INFO
            Log "CMSG_MEETING_STONE_INFO [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            'Nothing
        Case CMSG_MOVE_TIME_SKIPPED
            Log "CMSG_MOVE_TIME_SKIPPED [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            'Nothing
        Case CMSG_JOIN_CHANNEL
            Log "CMSG_JOIN_CHANNEL [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_FALL_LAND
            Log "MSG_MOVE_FALL_LAND [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case CMSG_TUTORIAL_FLAG
            Log "CMSG_TUTORIAL_FLAG [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case CMSG_TUTORIAL_CLEAR
            Log "CMSG_TUTORIAL_CLEAR [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_START_FORWARD
            Log "MSG_MOVE_START_FORWARD [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_START_BACKWARD
            Log "MSG_MOVE_START_BACKWARD [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_STOP
            Log "MSG_MOVE_STOP [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_START_TURN_RIGHT
            Log "MSG_MOVE_START_TURN_RIGHT [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_START_TURN_LEFT
            Log "MSG_MOVE_START_TURN_LEFT [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_STOP_TURN
            Log "MSG_MOVE_STOP_TURN [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case MSG_MOVE_HEARTBEAT
            Log "MSG_MOVE_HEARTBEAT [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
        
        Case MSG_MOVE_SET_FACING
            Log "MSG_MOVE_SET_FACING [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case MSG_MOVE_JUMP
            Log "MSG_MOVE_JUMP [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case CMSG_ZONEUPDATE
            Log "CMSG_ZONEUPDATE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case CMSG_NEXT_CINEMATIC_CAMERA
            Log "CMSG_NEXT_CINEMATIC_CAMERA [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case CMSG_COMPLETE_CINEMATIC
            Log "CMSG_COMPLETE_CINEMATIC [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case CMSG_STANDSTATECHANGE
            Log "CMSG_STANDSTATECHANGE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
         
        Case CMSG_MESSAGECHAT ' Handle the chats
            Log "CMSG_MESSAGECHAT [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
            HandleMessageChat Index, data
        Case CMSG_TEXT_EMOTE
            Log "CMSG_TEXT_EMOTE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
            
        Case Else
            'modWSFunctions.Decode data, frmCore.sckWS(Index).Tag
            'System.Log_Packet data, "Decoded unknown packet", Index
            Log "Unknown packet: " & opcode & "  [" & hex(opcode) & "]"
    End Select
    Exit Sub
    
Error:
    Log "Error (" & Err.Number & "): " & Err.Description
End Sub

Private Sub Send_Chars(Index As Integer)
' This was used for testing, it sends a female night elf hunter ;) (nude one :D)
Dim data_response() As Byte, i As Integer, j As Integer, K As Integer, l As String

ReDim data_response(171) As Byte

    'Header
    data_response(0) = 0
    data_response(1) = 170
    data_response(2) = SMSG_CHAR_ENUM
    data_response(3) = 0
    data_response(4) = 1
    'Guid
    data_response(5) = 0
    data_response(6) = 0
    data_response(7) = 0
    data_response(8) = 0
    data_response(9) = 0
    data_response(10) = 0
    data_response(11) = 0
    data_response(12) = 1
    'Name
    data_response(13) = 84
    data_response(14) = 101
    data_response(15) = 115
    data_response(16) = 116
    data_response(17) = 99
    data_response(18) = 104
    data_response(19) = 97
    data_response(20) = 114
    data_response(21) = 0
    'Other
    data_response(22) = 4
    data_response(23) = 3
    data_response(24) = 1
    data_response(25) = 2
    data_response(26) = 2
    data_response(27) = 4
    data_response(28) = 3
    data_response(29) = 2
    data_response(30) = 60
    data_response(31) = 12
    'Zone
    data_response(32) = 0
    data_response(33) = 0
    data_response(34) = 0
    data_response(35) = 0
    'Map
    data_response(36) = 0
    data_response(37) = 0
    data_response(38) = 0
    data_response(39) = 0
    'X
    data_response(40) = 0
    data_response(41) = 0
    data_response(42) = 0
    data_response(43) = 0
    'Y
    data_response(44) = 0
    data_response(45) = 0
    data_response(46) = 0
    data_response(47) = 0
    'Z
    data_response(48) = 0
    data_response(49) = 0
    data_response(50) = 0
    data_response(51) = 0
    'Unknown
    data_response(52) = 0
    data_response(53) = 0
    data_response(54) = 0
    'Character Lock
    data_response(55) = 0
    'Rest
    data_response(56) = 0
    data_response(57) = 0
    data_response(58) = 0
    data_response(59) = 0
    'PetInfoID
    data_response(60) = 0
    data_response(61) = 0
    data_response(62) = 0
    data_response(63) = 0
    'PetLevel
    data_response(64) = 0
    data_response(65) = 0
    data_response(66) = 0
    data_response(67) = 0
    'PetFamilyID
    data_response(68) = 0
    data_response(69) = 0
    data_response(70) = 0
    data_response(71) = 0
    'Equipment
    j = 71
    For i = 1 To 20
        j = j + 1
            data_response(j) = 0
        j = j + 1
            data_response(j) = 0
        j = j + 1
            data_response(j) = 0
        j = j + 1
            data_response(j) = 0
        j = j + 1
            data_response(j) = 0
    Next i


        modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
            On Error Resume Next
                frmCore.sckWS(Index).SendData data_response

End Sub
