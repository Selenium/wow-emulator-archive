Attribute VB_Name = "modWSFunctions"
' Some functions used by the world server

Option Explicit

Sub Send_SMSG_AUTH_CHALLENGE(Index As Integer)
' Sending a packet at login
    Dim data_response(7) As Byte
    data_response(0) = &H0
    data_response(1) = &H6
    data_response(3) = SMSG_AUTH_CHALLENGE \ 256
    data_response(2) = SMSG_AUTH_CHALLENGE Mod 256
    
    data_response(4) = &H71
    data_response(5) = &H2C
    data_response(6) = &H73
    data_response(7) = &H88
    
    On Error Resume Next
    frmCore.sckWS(Index).SendData data_response
End Sub

Function FindRSUser(user As String) As Integer
    FindRSUser = -1
    Dim i As Integer
    For i = 0 To Users_Count
        If Account(i).AccName = user Then
            FindRSUser = i
            Exit Function
        End If
    Next i
End Function


Sub Decode(data() As Byte, user As Integer)
' Decoding messages
Dim T As Integer
Dim a As Integer
Dim B As Integer
Dim d As Integer

    For T = 0 To 5 '<6
        a = Account(user).Key(0)
        Account(user).Key(0) = data(T)
        B = data(T)
        
        B = CByte((B - a) And &HFF)
        d = Account(user).Key(1)
        a = Account(user).bSS_Hash(d)
        a = CByte((a Xor B) And &HFF)
        data(T) = a

        a = Account(user).Key(1)
        a = a + 1
        Account(user).Key(1) = a Mod &H28
    Next T
End Sub

Sub EncodeOld(data() As Byte, user As Integer)
    Dim i As Integer
    Dim a As Integer
    Dim d As Integer
        'Log "DEBUG: Encoding..."
        'Log "DEBUG: SS_Hash=" & Account(user).SS_Hash
    
    For i = 0 To 3
        a = Account(user).Key(3)
        a = Account(user).K(a) Xor data(i)
        d = Account(user).Key(2)
        a = a + d
        a = a Mod 256
        data(i) = a
        Account(user).Key(2) = a
        a = Account(user).Key(3)
        a = a + 1
        Account(user).Key(3) = a Mod 40
    Next i
End Sub

Sub Encode(data() As Byte, user As Integer)
' Encoding messages
Dim T As Integer
Dim a As Integer
Dim B As Integer
Dim d As Integer

    For T = 0 To 3
        a = Account(user).Key(3)
        a = CByte((Account(user).bSS_Hash(a) Xor data(T)) And &HFF)
        d = Account(user).Key(2)
        a = CByte((a + d) And &HFF)
        data(T) = a
        Account(user).Key(2) = a
        a = Account(user).Key(3)
        a = a + 1
        Account(user).Key(3) = a Mod &H28
    Next T
End Sub

Function GetFreeChar() As Long
' Find a free character slot for the account
    GetFreeChar = -1
    Dim i As Integer
    Dim j As Integer
    For i = 1 To UBound(Account)
      If Account(i).AccChars > 0 Then
        For j = 1 To 10
            If Account(i).AccChar(j).Name = "" Then
                GetFreeChar = j
                Exit Function
            End If
        Next j
      Else
        GetFreeChar = 1
      End If
    Next i
End Function

Function FindCharName(FindName As String) As Long
' Check if someone is using your character name
    FindCharName = -1
    Dim i As Integer
    Dim j As Integer
    For i = 0 To UBound(Account)
        For j = 1 To UBound(Account(i).AccChar)
            If Account(i).AccChar(j).Name = FindName Then
                FindCharName = i
                Exit Function
            End If
        Next j
    Next i
End Function

Function GetFreeGUID() As Long
' Generates a GUID that nobody is using
Dim i As Integer, j As Integer, Numb As Long, NewGUID As Long

DoAgain:
    Randomize
    
    Numb = 99999999
    NewGUID = Int(Rnd * Numb)
    
    If NewGUID < 10000000 Then GoTo DoAgain
    
    For i = 0 To UBound(Account)
        For j = 1 To UBound(Account(i).AccChar)
            If Account(i).AccChar(j).GUID = NewGUID Then
                GoTo DoAgain
            End If
        Next j
    Next i
    
    GetFreeGUID = NewGUID
    
End Function

Sub EquipItem(AccountID As Long, CharacterID As Long, ItemID As Long)
' Character equips a item
Dim i As Integer, j As Integer
    If ItemID = 0 Then Exit Sub
    If ItemID > UBound(Items) Then Exit Sub
    If Items(ItemID).DisplayID = 0 Then Exit Sub
    Account(AccountID).AccChar(CharacterID).ItemsEquiped(Items(ItemID).ItemSlot).DisplayID = Items(ItemID).DisplayID
    Account(AccountID).AccChar(CharacterID).ItemsEquiped(Items(ItemID).ItemSlot).ItemID = ItemID
End Sub

Sub SendSystemMessage(Index As Integer, Message As String)
' Send a System Message, such as MOTD (NOT WORKING)
Dim data_response() As Byte
Dim i As Integer, j As Long
Dim iLong As Long

    iLong = 3 + 19 + Len(Message)
    ReDim data_response(iLong) As Byte
    data_response(0) = 0        'uint16 length
    data_response(1) = 3
    data_response(2) = SMSG_MESSAGECHAT     'uint16 opcode = 0x003B
    data_response(3) = 0
    
    i = 4
    data_response(i) = &HA
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = CByte(Len(Message))
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    
    For j = 1 To Len(Message)
        i = i + 1
        data_response(i) = Asc(Mid(Message, j, 1))
    Next j
    
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    
    i = i - 1
    
    If i > 255 Then
        data_response(0) = i \ 256
        data_response(1) = i Mod 256
    Else
        data_response(1) = i
    End If
    
    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
    DoEvents
        On Error Resume Next
            frmCore.sckWS(Index).SendData data_response
    Log "Sent MOTD: " & Message
End Sub

Sub SendFriendList(Index As Integer, CharacterID As Integer)
' Send the friendlist
Dim data_response() As Byte
Dim i As Integer, j As Long

    ReDim data_response(4) As Byte
    data_response(0) = 0        'uint16 length
    data_response(1) = 3
    data_response(2) = SMSG_FRIEND_LIST     'uint16 opcode = 0x003B
    data_response(3) = 0
    
    data_response(4) = 0
    
    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
    DoEvents
        On Error Resume Next
            frmCore.sckWS(Index).SendData data_response
End Sub

Sub SendBindpointUpdate(Index As Integer, CharacterID As Integer)
' Send the Bindpoint
Dim data_response() As Byte
Dim i As Integer, j As Long

    ReDim data_response(23) As Byte
    data_response(0) = 0        'uint16 length
    data_response(1) = 22
    data_response(2) = SMSG_BINDPOINTUPDATE Mod 256     'uint16 opcode = 0x003B
    data_response(3) = SMSG_BINDPOINTUPDATE \ 256
    
    i = 4
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H80
    i = i + 1
    data_response(i) = &HD1
    i = i + 1
    data_response(i) = &H44
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &HA0
    i = i + 1
    data_response(i) = &HD1
    i = i + 1
    data_response(i) = &H44
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &HF4
    i = i + 1
    data_response(i) = &H42
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H55
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    i = i + 1
    data_response(i) = &H0
    
    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
    DoEvents
        On Error Resume Next
            frmCore.sckWS(Index).SendData data_response
End Sub

Sub HandleMessageChat(Index As Integer, data() As Byte)
' Handle chat messages
Dim data_response() As Byte
Dim i As Integer, j As Long
Dim Message As String
Dim iLong As Long

    j = 14
    Message = ""
    While data(j) <> 0
        Message = Message + Chr(data(j))
        j = j + 1
    Wend
    
    Log "Chat: " & Message

    iLong = 10 + Len(Message)
    ReDim data_response(iLong) As Byte
    data_response(0) = 0        'uint16 length
    data_response(1) = 3
    data_response(2) = SMSG_MESSAGECHAT     'uint16 opcode = 0x003B
    data_response(3) = 0
    
    data_response(4) = data(6)
    data_response(5) = data(10)
    
    data_response(6) = 0
    data_response(7) = 0
    data_response(8) = 0
    
    i = 8
    
    For j = 1 To Len(Message)
        i = i + 1
        data_response(i) = Asc(Mid(Message, j, 1))
    Next j
    
    i = i + 1
    data_response(i) = 0
    i = i + 1
    data_response(i) = 0
    
    
    i = i - 1
    
    If i > 255 Then
        data_response(0) = i \ 256
        data_response(1) = i Mod 256
    Else
        data_response(1) = i
    End If
    
    modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
    DoEvents
        On Error Resume Next
            frmCore.sckWS(Index).SendData data_response
End Sub

Sub SendCreatePlayer(Index As Integer)
' Creates a player, used for tesing (NOT WORKING)
Dim data_response() As Byte
Dim i As Integer, j As Long

    ReDim data_response(23) As Byte
    data_response(0) = 0        'uint16 length
    data_response(1) = 22
    data_response(2) = SMSG_UPDATE_OBJECT     'uint16 opcode = 0x003B
    data_response(3) = 0
    
i = i + 1
data_response(i) = &H6
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &HB
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5F
i = i + 1
data_response(i) = &H41
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HB
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H3
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HD0
i = i + 1
data_response(i) = &H17
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &HC
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5F
i = i + 1
data_response(i) = &H41
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H3
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HFC
i = i + 1
data_response(i) = &H17
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H23
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H23
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &HD
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5F
i = i + 1
data_response(i) = &H41
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HD
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H3
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H73
i = i + 1
data_response(i) = &H5
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H19
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H19
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &HE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5F
i = i + 1
data_response(i) = &H41
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H3
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H37
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &HF
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5F
i = i + 1
data_response(i) = &H41
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HF
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H3
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H23
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H19
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H19
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &HFF
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H79
i = i + 1
data_response(i) = &H71
i = i + 1
data_response(i) = &H1E
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &HD1
i = i + 1
data_response(i) = &H44
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HA0
i = i + 1
data_response(i) = &HD1
i = i + 1
data_response(i) = &H44
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HF4
i = i + 1
data_response(i) = &H42
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H20
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HE0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H90
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H71
i = i + 1
data_response(i) = &H1C
i = i + 1
data_response(i) = &H97
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HA0
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &HE0
i = i + 1
data_response(i) = &HF
i = i + 1
data_response(i) = &H49
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H29
i = i + 1
data_response(i) = &H15
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H30
i = i + 1
data_response(i) = &H1C
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H1F
i = i + 1
data_response(i) = &H84
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &HE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HF0
i = i + 1
data_response(i) = &H3C
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H30
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H4
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H19
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H80
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H3E
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H87
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H3E
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H87
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H5
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H5
i = i + 1
data_response(i) = &H8
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H8
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H54
i = i + 1
data_response(i) = &HB
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HD0
i = i + 1
data_response(i) = &H7
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HD0
i = i + 1
data_response(i) = &H7
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H2B
i = i + 1
data_response(i) = &HC7
i = i + 1
data_response(i) = &H3E
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HC0
i = i + 1
data_response(i) = &H3F
i = i + 1
data_response(i) = &H3A
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H3A
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HEE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H10
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H9
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H5
i = i + 1
data_response(i) = &H6
i = i + 1
data_response(i) = &HEE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H2
i = i + 1
data_response(i) = &H1
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HD0
i = i + 1
data_response(i) = &H17
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HFC
i = i + 1
data_response(i) = &H17
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H73
i = i + 1
data_response(i) = &H5
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H37
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H23
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &HB
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &HC
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &HD
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &HE
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40
i = i + 1
data_response(i) = &HF
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H70
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H0
i = i + 1
data_response(i) = &H40

i = i - 1

If i > 255 Then
    data_response(0) = i \ 256
    data_response(1) = i Mod 256
Else
    data_response(1) = i
End If

modWSFunctions.Encode data_response, frmCore.sckWS(Index).Tag
    DoEvents
        On Error Resume Next
            frmCore.sckWS(Index).SendData data_response
End Sub
