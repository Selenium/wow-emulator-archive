Attribute VB_Name = "PlayerManagement"
Option Explicit
Option Base 1

Public Function GetPlayerObject_RecordNumber(GUID As tGUID) As Long
    Dim i As Long
    
    GetPlayerObject_RecordNumber = -1

    For i = 1 To Object_Unit_Player_Collection.Count
        If CompareGUIDs(Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, GUID) Then
            GetPlayerObject_RecordNumber = i
            Exit For
        End If
    Next i

End Function

Public Sub ObjectManagement_LoadPlayerUpdateValues_All(GUID As tGUID, msgArray() As Byte, UpdateList() As Integer)
    Dim tmpArray() As Byte
    Dim i As Long

    For i = 1 To Object_Unit_Player_Collection.Count
        If CompareGUIDs(Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, GUID) = True Then
            ReDim tmpArray(LenB(Object_Unit_Player_Collection.Objects(i)))
            CopyMemory tmpArray(1), Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, LenB(Object_Unit_Player_Collection.Objects(i))
            Exit For
        End If
    Next i

    For i = 1 To UBound(UpdateList)
        ReDim Preserve msgArray(UBound(msgArray) + 4)
        CopyMemory msgArray(UBound(msgArray) - 3), tmpArray(UpdateList(i) * 4 + 1), 4
    Next i

End Sub

Public Sub ObjectManagement_LoadPlayerUpdateValues(GUID As tGUID, msgArray() As Byte)
    Dim UpdateRecordNumber As Long
    Dim tmpArray() As Byte
    Dim i As Long

    For i = 1 To Object_UpdateFields_Collection.Count
        If CompareGUIDs(Object_UpdateFields_Collection.GUIDs(i), GUID) = True Then
            UpdateRecordNumber = i
            Exit For
        End If
    Next i

    For i = 1 To Object_Unit_Player_Collection.Count
        If CompareGUIDs(Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, GUID) = True Then
            ReDim tmpArray(LenB(Object_Unit_Player_Collection.Objects(i)))
            CopyMemory tmpArray(1), Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, LenB(Object_Unit_Player_Collection.Objects(i))
            Exit For
        End If
    Next i

    For i = 1 To Object_UpdateFields_Collection.Updates(UpdateRecordNumber).Count
        ReDim Preserve msgArray(UBound(msgArray) + 4)
        CopyMemory msgArray(UBound(msgArray) - 3), tmpArray(Object_UpdateFields_Collection.Updates(UpdateRecordNumber).UpdateFields(i) * 4 + 1), 4
    Next i

End Sub

Public Sub ObjectManagement_RemovePlayerFromCollection(GUID As tGUID)
    Dim i As Long                                          ', tmpRecordNumber As Long
    Dim tmpObject_Unit_Player_Collection As tObject_Unit_Player_Collection
    Dim tmpObject_Movements_Collection As tObjectMovements_Collection

    For i = 1 To Object_Unit_Player_Collection.Count
        If CompareGUIDs(Object_Unit_Player_Collection.Objects(i).Base.f000_GUID, GUID) Then
            'do nothing - this player is GONE! I'm an idiot. -_-*
        Else
            tmpObject_Unit_Player_Collection.Count = tmpObject_Unit_Player_Collection.Count + 1
            ReDim Preserve tmpObject_Unit_Player_Collection.Objects(tmpObject_Unit_Player_Collection.Count)
            tmpObject_Unit_Player_Collection.Objects(tmpObject_Unit_Player_Collection.Count) = Object_Unit_Player_Collection.Objects(i)
        End If
    Next i
    Object_Unit_Player_Collection = tmpObject_Unit_Player_Collection

    For i = 1 To Object_Movements_Collection.Count
        If CompareGUIDs(Object_Movements_Collection.GUIDs(i), GUID) Then
            'affirmative on that idiot bit, btw. =|
        Else
            tmpObject_Movements_Collection.Count = tmpObject_Movements_Collection.Count + 1
            ReDim Preserve tmpObject_Movements_Collection.GUIDs(tmpObject_Movements_Collection.Count)
            tmpObject_Movements_Collection.GUIDs(tmpObject_Movements_Collection.Count) = Object_Movements_Collection.GUIDs(i)
            ReDim Preserve tmpObject_Movements_Collection.Movements(tmpObject_Movements_Collection.Count)
            tmpObject_Movements_Collection.Movements(tmpObject_Movements_Collection.Count) = Object_Movements_Collection.Movements(i)
        End If
    Next i
    Object_Movements_Collection = tmpObject_Movements_Collection

End Sub

Public Sub ObjectManagement_AddPlayerToCollection(GUID As tGUID)
    Dim tmpRecordNumber As Long, i As Long

    tmpRecordNumber = CHARACTERS_GetRecordNumber(GUID)

    Object_Movements_Collection.Count = Object_Movements_Collection.Count + 1

    ReDim Preserve Object_Movements_Collection.Movements(Object_Movements_Collection.Count)
    ReDim Preserve Object_Movements_Collection.GUIDs(Object_Movements_Collection.Count)
    Object_Movements_Collection.GUIDs(Object_Movements_Collection.Count) = GUID

    With Object_Movements_Collection.Movements(Object_Movements_Collection.Count)
        .Facing = Characters_Record.Characters(tmpRecordNumber).PositionFacing
        .X_Position = Characters_Record.Characters(tmpRecordNumber).PositionX
        .Y_Position = Characters_Record.Characters(tmpRecordNumber).PositionY
        .Z_Position = Characters_Record.Characters(tmpRecordNumber).PositionZ
        .WalkSpeed = 2.5
        .RunSpeed = 7
        .SwimSpeed = 4.72222
        .TurnRate = 3.1415
    End With

    Object_Unit_Player_Collection.Count = Object_Unit_Player_Collection.Count + 1
    ReDim Preserve Object_Unit_Player_Collection.Objects(Object_Unit_Player_Collection.Count)

    With Object_Unit_Player_Collection.Objects(Object_Unit_Player_Collection.Count)
        With .Base
            .f000_GUID = GUID
            .f002_TYPE = Object_Unit_Player
            .f004_SCALE_X = 1
        End With

        With .Unit
            .f022_HEALTH = 100
            .f027_MAX_HEALTH = 100
            .f032_LEVEL = 1
            .f033_FACTIONTEMPLATE = 1
            .f034_CLASSINFO(1) = Characters_Record.Characters(tmpRecordNumber).Race
            .f034_CLASSINFO(2) = Characters_Record.Characters(tmpRecordNumber).Class
            .f034_CLASSINFO(3) = Characters_Record.Characters(tmpRecordNumber).Gender
            .f034_CLASSINFO(4) = 0
            '.f055_COINAGE = 100
            Select Case Characters_Record.Characters(tmpRecordNumber).Race
                Case 1                                     'human
                    .f151_DISPLAYID = 49
                Case 2                                     'orc
                    .f151_DISPLAYID = 51
                Case 3                                     'dwarf
                    .f151_DISPLAYID = 53
                Case 4                                     'nightelf
                    .f151_DISPLAYID = 55
                Case 5                                     'undead
                    .f151_DISPLAYID = 57
                Case 6                                     'tauren
                    .f151_DISPLAYID = 59
                Case 7                                     'gnome
                    .f151_DISPLAYID = 1563
                Case 8                                     'troll
                    .f151_DISPLAYID = 1478
            End Select
            .f151_DISPLAYID = .f151_DISPLAYID + Characters_Record.Characters(tmpRecordNumber).Gender
        End With

        With .Player
            For i = 1 To 16
                .f238_PACK_SLOTS_GUID_16(i) = Characters_Record.Characters(tmpRecordNumber).PackSlots(i)
                ItemManagement_AddItemToCollection Characters_Record.Characters(tmpRecordNumber).PackSlots(i)
            Next i
            '.f336_NUM_INV_SLOTS = &H54
            .f339_SKIN_FACE_HAIRSTYLE_HAIRCOLOR(1) = Characters_Record.Characters(tmpRecordNumber).Skin
            .f339_SKIN_FACE_HAIRSTYLE_HAIRCOLOR(2) = Characters_Record.Characters(tmpRecordNumber).Face
            .f339_SKIN_FACE_HAIRSTYLE_HAIRCOLOR(3) = Characters_Record.Characters(tmpRecordNumber).hairStyle
            .f339_SKIN_FACE_HAIRSTYLE_HAIRCOLOR(4) = Characters_Record.Characters(tmpRecordNumber).hairColour
            .f341_NEXT_LEVEL_XP = 1000
            .f534_FACIALHAIR(1) = Characters_Record.Characters(tmpRecordNumber).FacialHair
            .f615_TALENTPOINTS = &H32
            .f616_SKILLPOINTS = &H64
        End With
    End With
End Sub
