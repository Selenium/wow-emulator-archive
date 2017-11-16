Attribute VB_Name = "WORLDPackets"
Option Explicit
Option Base 1

Public Sub WORLD_ParsePacket(ReceivedPacket As String, link As Long)
    Dim msgOpcode As Long
    Dim msgByteLength As Long
    Dim bArray() As Byte, tmpArray() As Byte

    tmpArray = StrConv(ReceivedPacket, vbFromUnicode)
    ReDim bArray(Len(ReceivedPacket))
    CopyMemory bArray(1), tmpArray(0), UBound(bArray)

    msgByteLength = WORLD_GetPacketLength(bArray)
    msgOpcode = WORLD_GetPacketOpcode(bArray, msgByteLength)

    Select Case msgOpcode
        Case &H36                                          '54 - Create new character
            WORLD_CreateCharacter bArray, msgByteLength, link
        Case &H37                                          '55 - Request Character Enum
            WORLD_SendAuth link
            WORLD_EnumerateCharacters link
        Case &H38
            WORLD_DeleteCharacter bArray, msgByteLength, link
        Case &H3D
            WORLD_CharacterLogIn bArray, msgByteLength, link
        Case &H4A
            WORLD_LogOutCharacterNow link
        Case &H4B
            WORLD_LogOut link
        Case &HE9
            WORLD_ReceiveHeartbeatMove bArray, msgByteLength, link
        Case &H50
            WORLD_NameQueryResponse bArray, msgByteLength, link
        Case &H95
            WORLD_ReceiveChat bArray, msgByteLength, link
        Case &HB5 To &HBE
            WORLD_ReceiveMovement msgOpcode, bArray, msgByteLength, link
        Case &HD9
            WORLD_WorldPortAck link
        Case &H1CD
            WORLD_PingPong bArray, msgByteLength, link
        Case &HF4
            WORLD_ReceiveStanceChange bArray, msgByteLength, link
        Case &H1DF                                         '479 - Client Response to Authorization Request
            WORLD_CMSG_AUTH_SESSION bArray, msgByteLength, link
        Case Else
            frmMain.PrintOut "Unknown OPCODE: 0x" & Hex(msgOpcode)
    End Select

End Sub

Public Sub WORLD_ReceiveStanceChange(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpStance As Long, tmpGUID As tGUID
    Dim tmpUpdates As tUpdateFields, tmpRecordNumber As Long
    
    tmpGUID = ACCOUNT_GetGUID(LinkNumber)
    tmpRecordNumber = GetPlayerObject_RecordNumber(tmpGUID)
    
    tmpStance = GetLongFromArray(bArray, msgByteLength)
    
    If Object_Unit_Player_Collection.Objects(tmpRecordNumber).Unit.f178_ANIMSTATE = 1 Then
    Object_Unit_Player_Collection.Objects(tmpRecordNumber).Unit.f178_ANIMSTATE = 0
    Else
    Object_Unit_Player_Collection.Objects(tmpRecordNumber).Unit.f178_ANIMSTATE = 1
    End If
    
    AddUpdateFieldToTemporaryUpdateList tmpUpdates, 178, False
    AddUpdateFields tmpGUID, tmpUpdates
End Sub

Public Sub WORLD_ReceiveMovement(msgOpcode As Long, bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpGUID As tGUID, tmpRecordNumber As Long, msgArray() As Byte
    Dim Flags As Long
    Dim i As Long

    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    tmpGUID = Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID

    For i = 1 To Object_Movements_Collection.Count
        If CompareGUIDs(tmpGUID, Object_Movements_Collection.GUIDs(i)) Then
            Object_Movements_Collection.Movements(i).Flags = Object_Movements_DecodeFlags(GetLongFromArray(bArray, msgByteLength))
            Object_Movements_Collection.Movements(i).X_Position = GetFloatFromArray(bArray, msgByteLength)
            Object_Movements_Collection.Movements(i).Y_Position = GetFloatFromArray(bArray, msgByteLength)
            Object_Movements_Collection.Movements(i).Z_Position = GetFloatFromArray(bArray, msgByteLength)
            Object_Movements_Collection.Movements(i).Facing = GetFloatFromArray(bArray, msgByteLength)
            Exit For
        End If
    Next i

    AddLongToArray msgArray, CLng(&HA9)                    'SMSG_UPDATE_OBJECT
    AddLongToArray msgArray, CLng(&H1)
    ObjectManagement_UpdatePosition msgArray, tmpGUID

    For i = 1 To Accounts_LoggedIn.Count
        'If Not CompareGUIDs(Accounts_LoggedIn.AccountsLoggedIn(i).CurrentCharacterGUID, tmpGUID) Then
        WORLD_SendMessage Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber, msgArray, True
        'End If
    Next i

End Sub

Public Sub WORLD_PingPong(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpGUID As tGUID, msgArray() As Byte, tmpLong As Long

    'tmpGUID = GetGUIDFromArray(bArray, msgByteLength)
    tmpLong = GetLongFromArray(bArray, msgByteLength)


    AddLongToArray msgArray, &H1CE
    AddLongToArray msgArray, tmpLong
    'AddGUIDToArray msgArray, tmpGUID

    'WORLD_SendMessage LinkNumber, msgArray
End Sub

Public Sub WORLD_WorldPortAck(LinkNumber As Long)
    Dim tmpGUID As tGUID

    tmpGUID = ACCOUNT_GetGUID(LinkNumber)

    ObjectManagement_AddPlayerToCollection tmpGUID
    WORLD_SendAllPlayerObject LinkNumber, tmpGUID
    WORLD_BroadcastPlayerObject tmpGUID
    
End Sub

Public Sub WORLD_ReceiveHeartbeatMove(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim Transport As tGUID
    Dim transRelPositionX As Single, transRelPositionY As Single, transRelPositionZ As Single, transRelFacing As Single
    Dim WorldPositionX As Single, WorldPositionY As Single, WorldPositionZ As Single, WorldFacing As Single
    Dim Pitch As Single
    Dim MovementFlags As Long                              '(See the enums page)

    WorldPositionX = GetFloatFromArray(bArray, msgByteLength)
    WorldPositionY = GetFloatFromArray(bArray, msgByteLength)
    WorldPositionZ = GetFloatFromArray(bArray, msgByteLength)
    WorldFacing = GetFloatFromArray(bArray, msgByteLength)

    MovementFlags = GetLongFromArray(bArray, msgByteLength)
End Sub

Public Sub WORLD_LogOutCharacterNow(LinkNumber As Long)
    Dim msgArray() As Byte
    Dim tmpLogoutList As tLogoutList
    Dim tmpGUID As tGUID, tmpRecordNumber As Long
    Dim i As Long

    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    tmpGUID = Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID

    AddLongToArray msgArray, &H4D
    WORLD_SendMessage LinkNumber, msgArray
    ObjectManagement_RemovePlayerFromCollection tmpGUID

    For i = 1 To LogoutList.Count
        If CompareGUIDs(LogoutList.Players(i).GUID, tmpGUID) Then
            'do nothing.
        Else
            tmpLogoutList.Count = tmpLogoutList.Count + 1
            ReDim Preserve tmpLogoutList.Players(tmpLogoutList.Count)
            tmpLogoutList.Players(tmpLogoutList.Count).GUID = LogoutList.Players(i).GUID
            tmpLogoutList.Players(tmpLogoutList.Count).LogoutTimeLeft = LogoutList.Players(i).LogoutTimeLeft
        End If
    Next i

    bChangingLogoutList = True
    LogoutList = tmpLogoutList
    bChangingLogoutList = False

End Sub

Public Sub WORLD_LogOut(LinkNumber As Long)
    Dim tmpRecordNumber As Long, tmpGUID As tGUID
    Dim msgArray() As Byte

    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    tmpGUID = Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID
    bChangingLogoutList = True
    LogoutList.Count = LogoutList.Count + 1
    ReDim LogoutList.Players(LogoutList.Count)
    LogoutList.Players(LogoutList.Count).GUID = tmpGUID
    LogoutList.Players(LogoutList.Count).LogoutTimeLeft = 20
    bChangingLogoutList = False

    AddLongToArray msgArray, &H4C
    AddByteToArray msgArray, &HC

    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_ReceiveChat(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpLong1 As Long, tmpLong2 As Long
    Dim ChatString As String

    Dim tmpRecordNumber As Long, tmpGUID As tGUID
    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    tmpGUID = Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID

    tmpLong1 = GetLongFromArray(bArray, msgByteLength)
    tmpLong2 = GetLongFromArray(bArray, msgByteLength)
    ChatString = GetStringFromArray(bArray, msgByteLength)

    If Left(ChatString, 1) = "!" Then
        WORLD_ParseGMCommand ChatString, tmpGUID, LinkNumber
    Else
        WORLD_SendChat ChatString, tmpGUID
    End If

End Sub

Public Sub WORLD_SendChat(ChatString As String, GUID As tGUID)
    Dim msgArray() As Byte, i As Long, tmpName As String

    AddLongToArray msgArray, CLng(&H96)
    AddByteToArray msgArray, CByte(&H0)
    AddLongToArray msgArray, 0
    AddGUIDToArray msgArray, GUID

    tmpName = CHARACTERS_GetName(GUID)

    AddStringToArray msgArray, "|cFFFFFFFF" & ChatString
    AddByteToArray msgArray, 0

    WORLD_BroadcastMessage msgArray
End Sub

Public Sub WORLD_NameQueryResponse(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpGUID As tGUID, ObjectType As enumObjectTypes
    Dim cName As String, cClass As Long, cGender As Long, cRace As Long
    Dim msgArray() As Byte

    tmpGUID = GetGUIDFromArray(bArray, msgByteLength)
    WORLD_SendName LinkNumber, tmpGUID

End Sub

Public Sub WORLD_SendName(LinkNumber As Long, tmpGUID As tGUID)
    Dim ObjectType As enumObjectTypes
    Dim cName As String, cClass As Long, cGender As Long, cRace As Long
    Dim msgArray() As Byte

    ObjectType = GetObjectTypeFromGUID(tmpGUID)

    Select Case ObjectType
        Case Object_Unit_Player
            CHARACTERS_GetNameInfo tmpGUID, cName, cClass, cGender, cRace
            AddLongToArray msgArray, CLng(&H51)            'SMSG_UPDATE_OBJECT
            AddGUIDToArray msgArray, tmpGUID
            AddStringToArray msgArray, cName
            AddLongToArray msgArray, cClass
            AddLongToArray msgArray, cGender
            AddLongToArray msgArray, cRace
            WORLD_SendMessage LinkNumber, msgArray
    End Select
End Sub

Public Sub WORLD_CharacterLogIn(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpGUID As tGUID
    Dim tmpRecordNumber As Long

    tmpGUID = GetGUIDFromArray(bArray, msgByteLength)
    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID = tmpGUID

    ObjectManagement_AddPlayerToCollection tmpGUID


    Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).LoggedIn = True
    WORLD_BroadcastPlayerObject tmpGUID


    WORLD_SendTutorialFlags LinkNumber
    WORLD_UpdateGameTime LinkNumber
    WORLD_SendInitialSpells LinkNumber
    WORLD_SendFriendsList LinkNumber
    WORLD_SendMystery_ONE LinkNumber

    WORLD_SendAllPlayerObject LinkNumber, tmpGUID
    WORLD_SendName LinkNumber, tmpGUID

    WORLD_SendActionButtons LinkNumber
    WORLD_SendSystemMessage "Welcome to GhostCraft v" & App.Major & "." & App.Minor & "." & App.Revision & ".", LinkNumber
    WORLD_SendSystemMessage "Say !God to see the GM commands.", LinkNumber
    WORLD_LogXPGain LinkNumber
End Sub

Public Sub WORLD_UpdateInRangeObjects()
    Dim msgArray() As Byte, i As Long

    ObjectManagement_UpdateInRangeObjects msgArray

    For i = 1 To Accounts_LoggedIn.Count
        WORLD_SendMessage Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber, msgArray, True
    Next i
End Sub

Public Sub WORLD_SendActionButtons(LinkNumber As Long)
    Dim msgArray() As Byte, i As Long

    AddLongToArray msgArray, CLng(&H11C)                   'SMSG_UPDATE_OBJECT

    AddLongToArray msgArray, &H19CB
    AddLongToArray msgArray, &H24F

    For i = 1 To 118
        AddLongToArray msgArray, 0
    Next i
    WORLD_SendMessage LinkNumber, msgArray
End Sub

Public Sub WORLD_SendSystemMessage(Message As String, Optional LinkNumber As Long = -1)
    Dim msgArray() As Byte, i As Long

    AddLongToArray msgArray, CLng(&H96)                    'SMSG_UPDATE_OBJECT
    AddByteToArray msgArray, CByte(&H9)
    AddLongToArray msgArray, 0
    AddU64ToArray msgArray, 0, 0

    AddStringToArray msgArray, "|cFFCCFFCC" & Message
    AddByteToArray msgArray, 0

    WORLD_BroadcastMessage msgArray, LinkNumber
End Sub

Public Sub WORLD_BroadcastPlayerObject(GUID As tGUID)
    Dim msgArray() As Byte, i As Long

    AddLongToArray msgArray, CLng(&HA9)                    'SMSG_UPDATE_OBJECT
    AddLongToArray msgArray, CLng(&H1)                     'number of update operations - update this last

    ObjectManagement_CreateObject msgArray, GUID, False, True

    For i = 1 To Accounts_LoggedIn.Count
        If Not CompareGUIDs(Accounts_LoggedIn.AccountsLoggedIn(i).CurrentCharacterGUID, GUID) Then
            WORLD_SendMessage Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber, msgArray, True
        End If
    Next i
End Sub


Public Sub WORLD_SendAllPlayerObject(LinkNumber As Long, tmpGUID As tGUID)
    Dim msgArray() As Byte, i As Long
    Dim tmpRecordNumber As Long

    AddLongToArray msgArray, CLng(&HA9)                    'SMSG_UPDATE_OBJECT
    AddLongToArray msgArray, CLng(&H0)                     'number of update operations - update this last

    For i = 1 To Object_Unit_Player_Collection.Count
        If CompareGUIDs(Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, tmpGUID) Then    'Is this the own player?
            ObjectManagement_CreateObject msgArray, Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, True, True
        Else
            ObjectManagement_CreateObject msgArray, Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, False, True
        End If
    Next i

    CopyMemory msgArray(5), Object_Unit_Player_Collection.Count, 4

    WORLD_SendMessage LinkNumber, msgArray
End Sub

Public Sub WORLD_SendUpdates()
    Dim msgArray() As Byte, i As Long
    Dim tmpRecordNumber As Long, tmpGUID As tGUID

    'tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    'tmpGUID = Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID

    If Object_UpdateFields_Collection.Count = 0 Then Exit Sub

    AddLongToArray msgArray, CLng(&HA9)                    'SMSG_UPDATE_OBJECT
    AddLongToArray msgArray, CLng(&H0)                     'number of update operations - update this last

    For i = 1 To Object_UpdateFields_Collection.Count
        ObjectManagement_UpdateObject msgArray, Object_UpdateFields_Collection.GUIDs(i)
    Next i

    CopyMemory msgArray(5), Object_UpdateFields_Collection.Count, 4
    For i = 1 To Accounts_LoggedIn.Count
        WORLD_SendMessage Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber, msgArray
    Next i

    Object_UpdateFields_Collection.Count = 0
    Erase Object_UpdateFields_Collection.GUIDs
    Erase Object_UpdateFields_Collection.Updates
End Sub

Public Sub WORLD_LogXPGain(LinkNumber As Long)
    Dim msgArray() As Byte
    'Dim tmpRecordNumber As Long, tmpCharacterRecordNumber As Long

    AddLongToArray msgArray, CLng(&H1C1)                   'send XP gain
    AddLongToArray msgArray, &H10

    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_SendMystery_ONE(LinkNumber As Long)
    Dim msgArray() As Byte, i As Long
    Dim tmpRecordNumber As Long, tmpCharacterRecordNumber As Long

    AddLongToArray msgArray, CLng(&H1FB)                   'no idea what this packet does. =(
    For i = 1 To 20
        AddLongToArray msgArray, CLng(&H0)
    Next i
    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_SendInitialSpells(LinkNumber As Long)
    Dim msgArray() As Byte, i As Long

    AddLongToArray msgArray, CLng(&H11D)                   'OPCODE: SMSG_INITIAL_SPELLS

    AddByteToArray msgArray, &H0                           '?
    AddIntegerToArray msgArray, &H2                        'spell/ability count

    AddIntegerToArray msgArray, &H7E
    AddIntegerToArray msgArray, &H1

    AddIntegerToArray msgArray, &H29C
    AddIntegerToArray msgArray, &H0

    AddIntegerToArray msgArray, &H0                        'not sure what this second count is for

    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_UpdateGameTime(LinkNumber As Long)
    Dim msgArray() As Byte

    AddLongToArray msgArray, CLng(&H43)                    'quelle heure est il?
    AddLongToArray msgArray, WorldTime

    WORLD_SendMessage LinkNumber, msgArray, True

End Sub

Public Sub WORLD_SendTutorialFlags(LinkNumber As Long)
    Dim msgArray() As Byte
    Dim tmpRecordNumber As Long, tmpCharacterRecordNumber As Long

    tmpRecordNumber = ACCOUNT_GetPosition(LinkNumber)
    tmpCharacterRecordNumber = CHARACTERS_GetRecordNumber(Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).CurrentCharacterGUID)

    AddLongToArray msgArray, CLng(&HF0)                    'tutorial flags!
    AddByteToArray msgArray, &HFF                          'Characters_Record.Characters(tmpCharacterRecordNumber).TutorialFlags(1)
    AddByteToArray msgArray, &HFF                          'Characters_Record.Characters(tmpCharacterRecordNumber).TutorialFlags(2)
    AddByteToArray msgArray, &HFF                          'Characters_Record.Characters(tmpCharacterRecordNumber).TutorialFlags(3)
    AddByteToArray msgArray, &HFF                          'Characters_Record.Characters(tmpCharacterRecordNumber).TutorialFlags(4)
    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_SendFriendsList(LinkNumber As Long)
    Dim msgArray() As Byte

    AddLongToArray msgArray, CLng(&H67)                    'friends enum
    AddByteToArray msgArray, &H0                           'you have no friends!
    WORLD_SendMessage LinkNumber, msgArray

    Erase msgArray
    AddLongToArray msgArray, CLng(&H6B)                    'friends list not working
    AddByteToArray msgArray, &H0
    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_DeleteCharacter(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim tmpGUID As tGUID
    Dim tmpRecordNumber As Long, i As Long
    Dim tmpCharacterGUIDList() As tGUID
    Dim tmpCharacterGUIDListCount As Long
    Dim tmpCharacterRecordNumber As Long

    tmpGUID = GetGUIDFromArray(bArray, msgByteLength)

    tmpRecordNumber = ACCOUNT_GetRecordNumber(LinkNumber)
    tmpCharacterRecordNumber = CHARACTERS_GetRecordNumber(tmpGUID)
    Characters_Record.Characters(tmpCharacterRecordNumber).DeleteFlag = True

    If Accounts_Record.Accounts(tmpRecordNumber).CharactersCount > 1 Then
        ReDim tmpCharacterGUIDList(Accounts_Record.Accounts(tmpRecordNumber).CharactersCount - 1)
        For i = 1 To Accounts_Record.Accounts(tmpRecordNumber).CharactersCount
            If CompareGUIDs(Accounts_Record.Accounts(tmpRecordNumber).CharacterGUIDs(i), tmpGUID) = False Then
                tmpCharacterGUIDListCount = tmpCharacterGUIDListCount + 1
                tmpCharacterGUIDList(tmpCharacterGUIDListCount) = Accounts_Record.Accounts(tmpRecordNumber).CharacterGUIDs(i)
            End If
        Next i
        Accounts_Record.Accounts(tmpRecordNumber).CharactersCount = Accounts_Record.Accounts(tmpRecordNumber).CharactersCount - 1
        Accounts_Record.Accounts(tmpRecordNumber).CharacterGUIDs = tmpCharacterGUIDList
    Else
        Erase Accounts_Record.Accounts(tmpRecordNumber).CharacterGUIDs
        Accounts_Record.Accounts(tmpRecordNumber).CharactersCount = 0
    End If

    WORLD_EnumerateCharacters LinkNumber

End Sub

Public Sub WORLD_CreateCharacter(bArray() As Byte, msgByteLength As Long, LinkNumber As Long)
    Dim msgArray() As Byte
    Dim tmpRecordNumber As Long
    Dim i As Long
    Dim tmpNewCharacterGUID As tGUID
    Dim NewCharacter As tNewCharacter

    NewCharacter.Name = GetStringFromArray(bArray, msgByteLength)
    NewCharacter.Race = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.Class = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.Gender = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.Skin = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.Face = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.hairStyle = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.hairColour = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.FacialHair = GetByteFromArray(bArray, msgByteLength)
    NewCharacter.OutfitID = GetByteFromArray(bArray, msgByteLength)

    tmpNewCharacterGUID = CHARACTERS_CreateNewCharacter(NewCharacter)
    tmpRecordNumber = ACCOUNT_GetRecordNumber(LinkNumber)

    With Accounts_Record.Accounts(tmpRecordNumber)
        .CharactersCount = .CharactersCount + 1
        ReDim Preserve .CharacterGUIDs(.CharactersCount)
        .CharacterGUIDs(.CharactersCount) = tmpNewCharacterGUID
    End With

    AddLongToArray msgArray, CLng(&H3A)
    AddByteToArray msgArray, &H28
    AddByteToArray msgArray, &H0
    AddNetCodeIntegerToArray msgArray, &H0

    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_EnumerateCharacters(LinkNumber As Long)
    Dim msgArray() As Byte
    Dim tmpRecordNumber As Long, tmpCharacterRecordNumber As Long
    Dim i As Long, j As Long

    AddLongToArray msgArray, CLng(&H3B)

    tmpRecordNumber = ACCOUNT_GetRecordNumber(LinkNumber)
    If tmpRecordNumber = -1 Then Exit Sub

    If Accounts_Record.Accounts(tmpRecordNumber).CharactersCount = 0 Then
        AddByteToArray msgArray, &H0
    Else
        AddByteToArray msgArray, CByte(Hex(Accounts_Record.Accounts(tmpRecordNumber).CharactersCount))

        For i = 1 To Accounts_Record.Accounts(tmpRecordNumber).CharactersCount
            tmpCharacterRecordNumber = CHARACTERS_GetRecordNumber(Accounts_Record.Accounts(tmpRecordNumber).CharacterGUIDs(i))

            AddGUIDToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).GUID
            AddStringToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Name

            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Race
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Class
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Gender
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Skin
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Face
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).hairStyle
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).hairColour
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).FacialHair
            AddByteToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).Level

            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).ZoneID
            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).MapID

            AddFloatToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PositionX
            AddFloatToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PositionY
            AddFloatToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PositionZ

            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).GuildID
            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PetDisplayInfoID
            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PetLevel
            AddLongToArray msgArray, Characters_Record.Characters(tmpCharacterRecordNumber).PetCreatureFamilyID

            'INDEX_HEAD_TYPE
            AddLongToArray msgArray, 0                     '6146
            AddByteToArray msgArray, &H1
            'INDEX_NECK_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H2
            'INDEX_SHOULDER_TYPE
            AddLongToArray msgArray, 0                     '6141
            AddByteToArray msgArray, &H3
            'INDEX_BODY_TYPE
            AddLongToArray msgArray, &H26A3                '6147
            AddByteToArray msgArray, &H4
            'INDEX_CHEST_TYPE
            AddLongToArray msgArray, 0                     '9431
            AddByteToArray msgArray, &H5
            'INDEX_WAIST_TYPE
            AddLongToArray msgArray, 0                     '5319
            AddByteToArray msgArray, &H6
            'INDEX_LEGS_TYPE
            AddLongToArray msgArray, &H26A4
            AddByteToArray msgArray, &H7
            'INDEX_FEET_TYPE
            AddLongToArray msgArray, &H279D                '5620
            AddByteToArray msgArray, &H8
            'INDEX_WRIST_TYPE
            AddLongToArray msgArray, 0                     '6144
            AddByteToArray msgArray, &H9
            'INDEX_HAND_TYPE
            AddLongToArray msgArray, 0                     '5323
            AddByteToArray msgArray, &HA
            'INDEX_FINGER_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &HB
            'INDEX_TRINKET_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &HC
            'INDEX_WEAPON_TYPE
            AddLongToArray msgArray, &H606                 '13455
            AddByteToArray msgArray, &HD
            'INDEX_SHIELD_TYPE
            AddLongToArray msgArray, &H86E
            AddByteToArray msgArray, &HE
            'INDEX_RANGED_TYPE
            AddLongToArray msgArray, 0                     '13455
            AddByteToArray msgArray, &HF
            'INDEX_CLOAK_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H10
            'INDEX_2HWEAPON_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H11
            'INDEX_BAG_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H12
            'INDEX_TABARD_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H13
            'INDEX_ROBE_TYPE
            AddLongToArray msgArray, 0
            AddByteToArray msgArray, &H14
        Next i
    End If

    WORLD_SendMessage LinkNumber, msgArray

End Sub

Public Sub WORLD_CMSG_AUTH_SESSION(ByRef bArray() As Byte, PacketLength As Long, LinkNumber As Long)
    Dim ClientVersion As Long, SessionID As Long
    Dim Username As String, Password As String
    Dim tmpArray() As Byte, tmpNamePass() As String
    Dim retVal As enumLoginReturnValues

    ClientVersion = GetLongFromArray(bArray, PacketLength)
    SessionID = GetLongFromArray(bArray, PacketLength)

    Username = GetStringFromArray(bArray, PacketLength)
    tmpNamePass = Split(Username, Chr(13) & Chr(10), , vbTextCompare)
    Username = tmpNamePass(0)
    Password = tmpNamePass(1)

    retVal = ACCOUNT_CheckPassword(Username, Password)

    Select Case retVal
        Case Success
            ACCOUNT_LogIn Username, LinkNumber
            WORLD_SendResponseCode LinkNumber, &HC         'Auth successful
        Case WrongPassword
            WORLD_SendResponseCode LinkNumber, &H16        'Auth unsuccessful
            frmMain.serverWORLD.CloseConnection LinkNumber
        Case AccountCreated                                'normally, this would have been called when the REALMlist was contacted, but we have left it in just in case.
            ACCOUNT_LogIn Username, LinkNumber
            WORLD_SendResponseCode LinkNumber, &HC         'Auth successful
    End Select
End Sub

Public Sub WORLD_SendAuth(LinkNumber As Long)
    Dim msgArray() As Byte

    AddLongToArray msgArray, CLng(&H1DE)
    AddLongToArray msgArray, 0

    WORLD_SendMessage LinkNumber, msgArray
End Sub

Public Sub WORLD_SendResponseCode(LinkNumber As Long, ResponseCode As Byte)
    Dim msgArray() As Byte

    AddLongToArray msgArray, CLng(&H1E0)
    AddByteToArray msgArray, ResponseCode

    WORLD_SendMessage LinkNumber, msgArray
End Sub

Public Sub WORLD_BroadcastMessage(ByRef msgArray() As Byte, Optional LinkNumber As Long = -1)
    Dim msgLength() As Byte, i As Long

    AddNetCodeIntegerToArray msgLength, CInt(UBound(msgArray))

    If LinkNumber = -1 Then
        For i = 0 To 255
            If frmMain.serverWORLD.Connected(i) = True Then
                frmMain.serverWORLD.Send i, msgLength
                frmMain.serverWORLD.Send i, msgArray
                DoEvents
            End If
        Next i
    Else
        frmMain.serverWORLD.Send LinkNumber, msgLength
        frmMain.serverWORLD.Send LinkNumber, msgArray
        DoEvents
    End If

    Erase msgArray
End Sub

Public Sub WORLD_SendMessage(LinkNumber As Long, ByRef msgArray() As Byte, Optional CheckIfLoggedIn As Boolean = False)
    On Error GoTo errOut:
    Dim tmpRecordNumber As Long
    Dim msgLength() As Byte

    If CheckIfLoggedIn = True Then
        tmpRecordNumber = ACCOUNT_GetRecordNumber(LinkNumber)
        If Accounts_LoggedIn.AccountsLoggedIn(tmpRecordNumber).LoggedIn = False Then Exit Sub
    End If

    AddNetCodeIntegerToArray msgLength, CInt(UBound(msgArray))

    frmMain.serverWORLD.Send LinkNumber, msgLength
    frmMain.serverWORLD.Send LinkNumber, msgArray
    DoEvents


    frmMain.PrintOut "SendMessage Scces: <" & LinkNumber & "> 0x" & Hex(msgArray(2)) & Hex(msgArray(1))
    Exit Sub
errOut:
    frmMain.PrintOut "SendMessage Error: <" & LinkNumber & "> "
End Sub

Public Function WORLD_GetPacketLength(ByRef bArray() As Byte) As Long
    Dim tmpBytes As Long
    Dim tmpArray() As Byte
    Dim tmpString As String

    tmpString = StrConv(bArray, vbUnicode)

    tmpBytes = bArray(1) * 256 + bArray(2)
    ReDim tmpArray(tmpBytes)
    CopyMemory tmpArray(1), bArray(3), tmpBytes
    bArray = tmpArray
    WORLD_GetPacketLength = tmpBytes
End Function

Public Function WORLD_GetPacketOpcode(ByRef bArray() As Byte, ByRef PacketLength As Long) As Long
    Dim tmpBytes As Long
    Dim tmpArray() As Byte

    tmpBytes = bArray(1) + bArray(2) * 256 + bArray(3) * 256 ^ 2 + bArray(4) * 256 ^ 3

    If PacketLength > 4 Then                               'if 4, then this packet is only an opcode.
        ReDim tmpArray(PacketLength - 4)
        CopyMemory tmpArray(1), bArray(5), PacketLength - 4
        PacketLength = PacketLength - 4
        bArray = tmpArray
    End If

    WORLD_GetPacketOpcode = tmpBytes
End Function

