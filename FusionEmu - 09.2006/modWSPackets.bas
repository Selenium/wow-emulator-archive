Attribute VB_Name = "modWSPackets"
Option Explicit

Sub Analyze(Index As Integer, Data() As Byte)
On Error GoTo Error
    Dim i As Integer
    Dim j As Integer
    Dim l As Integer
    Dim data_response() As Byte
    Dim packet_len As Long
    Dim opcode As Long
    Dim templong As Long
    Dim result As Byte
        
    If frmCore.sckWS(Index).Tag <> -1 Then
        'decode it!
        modWSFunctions.Decode Data, frmCore.sckWS(Index).Tag
        opcode = Data(2) + Data(3) * (2 ^ 8)
    Else
        packet_len = Data(1) + Data(0) * (2 ^ 8)
        opcode = Data(2) + Data(3) * (2 ^ 8)
    End If

    Debug.Print opcode
    
    Select Case opcode
        ' Client Auth
        Case CMSG_AUTH_SESSION
                    Log "Client Authing [" & frmCore.sckWS(Index).RemoteHostIP & "]"
                    
                    Dim tempusername As String
                    tempusername = ""
                    
                    For i = 14 To packet_len + 2 - 25 - 1
                        If Chr(Data(i)) = Chr(0) Then
                            Exit For
                        End If
                        tempusername = tempusername + Chr(Data(i))
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
                    data_response(4) = &HC '&HC - no error &HD - auth failed

                    Log "Authed WS [" & frmCore.sckWS(Index).RemoteHostIP & "]"
                    On Error Resume Next
                        Call modWSFunctions.Encode(data_response, Index)
                        frmCore.sckWS(Index).SendData data_response
                    DoEvents
                    send_more Index

        'Pings - these packets must be decoded and endcoded!
        Case CMSG_PING
                    Log "CMSG_PING [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
                    Data(2) = &HDD
                    modWSFunctions.Encode Data, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData Data
                    Log "SMSG_PONG [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"

        ' Character List
        Case CMSG_CHAR_ENUM
                    ' -----------------------------------------
                    ' ----------- NEED HELP HERE :) -----------
                    ' -----------------------------------------
                    
                    'Log "CMSG_CHAR_ENUM [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
                    'ReDim data_response(1) As Byte
                    'i = -1
                    'If Account(frmCore.sckWS(Index).Tag).AccChars <= 0 Then
                    '    Account(frmCore.sckWS(Index).Tag).AccChars = 0
                    '    i = i + 1
                    '    data_response(i) = 0        'uint16 length
                    '    Log "No Characters"
                    'Else

                    'i = i + 1
                    'data_response(i) = 3
                    'i = i + 1
                    'data_response(i) = &H3B   'uint16 opcode = 0x003B
                    'i = i + 1
                    'data_response(i) = 0
                    'i = i + 1
                    'data_response(i) = 0 'Account(frmCore.sckWS(Index).Tag).AccChars        'uint8 numcharacters
                    
                    
                    'modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    'Log "SMSG_CHAR_ENUM [" & frmCore.sckWS(Index).RemoteHostIP & "]"
                    'On Error Resume Next
                    '    frmCore.sckWS(Index).SendData data_response
                    
        ' Character Created
        Case CMSG_CHAR_CREATE
                    Log "CMSG_CHAR_CREATE [" & Account(frmCore.sckWS(Index).Tag).AccIp & "]"
                    templong = modWSFunctions.GetFreeChar
                    If templong = -1 Then Log "Error with Chars": Exit Sub
                    'data(4) uint8 unknown1
                    i = 6
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name = ""
                    While Data(i) <> 0
                        Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name = Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name + Chr(Data(i))
                        i = i + 1
                    Wend
                    If Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name = "" Then Log "Failed to create Character: No name found": Exit Sub
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).GUID = FormatHEX(Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name, 8)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Race = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Class = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Gender = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Skin = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Face = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).HairStyle = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).HairColor = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).FacialHair = Data(i)
                    i = i + 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).OutfitID = Data(i)
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).Level = 1
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).MapID = 451
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionX = 16391.8
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionY = 16341.2
                    Account(frmCore.sckWS(Index).Tag).AccChar(templong).positionZ = 69.5
                    Account(frmCore.sckWS(Index).Tag).AccChars = Account(frmCore.sckWS(Index).Tag).AccChars + 1
                    
                    modAccountSystem.LoadAccounts True
                    modAccountSystem.LoadAccounts False
                    
                    result = CHAR_CREATE_OK
                    If Account(frmCore.sckWS(Index).Tag).AccChars = MAX_CHARACTERS_PER_USER Then result = CHAR_CREATE_MAX_CHARACTERS_ON_THIS_ACCOUNT
                    If FindCharName(Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name) <> -1 Then result = CHAR_CREATE_NAME_IN_USE
                    
                    
                    ReDim data_response(4) As Byte
                    data_response(0) = SMSG_CHAR_CREATE                    'uint16 length
                    data_response(1) = &H28
                    data_response(2) = &H0     'uint16 opcode = 0x003A
                    data_response(3) = &H0
                    data_response(4) = result               'uint8 result
                    Log "Character Created  [" & Account(frmCore.sckWS(Index).Tag).AccIp & "] SMSG_CHAR_CREATE [" & Account(frmCore.sckWS(Index).Tag).AccChar(templong).Name & "]"
                    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
                    On Error Resume Next
                        frmCore.sckWS(Index).SendData data_response
                    
                    
                    
                    
            'debug!
        Case Else
            'modWSFunctions.Decode data, frmCore.sckWS(Index).Tag
            'System.Log_Packet data, "Decoded unknown packet", Index
            Log "Unknown packet: " & opcode
    End Select
    Exit Sub
    
Error:
    Log "Error (" & Err.Number & "): " & Err.Description
End Sub
