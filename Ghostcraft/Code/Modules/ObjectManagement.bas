Attribute VB_Name = "ObjectManagement"
Option Explicit
Option Base 1

Public Object_Base_Collection As tObject_Base_Collection
Public Object_Item_Collection As tObject_Item_Collection
Public Object_Item_Container_Collection As tObject_Item_Container_Collection
Public Object_Game_Object_Collection As tObject_Game_Object_Collection
Public Object_Unit_Collection As tObject_Unit_Collection
Public Object_Unit_Player_Collection As tObject_Unit_Player_Collection
Public Object_Dynamic_Object_Collection As tObject_Dynamic_Object_Collection
Public Object_Corpse_Collection As tObject_Corpse_Collection

Public Object_Movements_Collection As tObjectMovements_Collection
Public Object_UpdateFields_Collection As tUpdateMaskList

Public Sub ObjectManagement_UpdateObject(ByRef msgArray() As Byte, GUID As tGUID)
    AddByteToArray msgArray, &H0                           'operation type
    AddGUIDToArray msgArray, GUID                          'object's guid
    ObjectManagement_AddUpdateValues msgArray, GUID, False
End Sub

Public Sub ObjectManagement_UpdatePosition(ByRef msgArray() As Byte, GUID As tGUID)
    AddByteToArray msgArray, &H1                           'operation type
    AddGUIDToArray msgArray, GUID                          'object's guid
    ObjectManagement_AddPositionUpdate msgArray, GUID
End Sub

Public Sub ObjectManagement_CreateObject(ByRef msgArray() As Byte, GUID As tGUID, Optional IsPlayer As Boolean = False, Optional AllUpdates As Boolean = False)
    AddByteToArray msgArray, &H2                           'operation type
    AddGUIDToArray msgArray, GUID                          'object's guid
    AddByteToArray msgArray, &H4
    ObjectManagement_AddPositionUpdate msgArray, GUID
    If IsPlayer = True Then
        AddLongToArray msgArray, &H1                       'flags. 1 = player, not sure what else
    Else
        AddLongToArray msgArray, &H0
    End If
    AddLongToArray msgArray, &H0                           'Attack cycle
    AddLongToArray msgArray, &H0                           'Timer ID
    AddU64ToArray msgArray, &H0, &H0                       'Victim ID
    ObjectManagement_AddUpdateValues msgArray, GUID, AllUpdates
End Sub

Public Sub ObjectManagement_UpdateInRangeObjects(ByRef msgArray() As Byte)
    Dim i As Long

    AddLongToArray msgArray, &HA9
    AddLongToArray msgArray, &H1
    AddByteToArray msgArray, &H4                           'operation type
    AddLongToArray msgArray, Accounts_LoggedIn.Count       'object's guid

    For i = 1 To Accounts_LoggedIn.Count
        AddGUIDToArray msgArray, Accounts_LoggedIn.AccountsLoggedIn(i).CurrentCharacterGUID
    Next i
End Sub

Public Sub ObjectManagement_AddUpdateValues(ByRef msgArray() As Byte, GUID As tGUID, AllUpdates As Boolean)
    Dim tmpObjectType As enumObjectTypes, tmpUpdateList() As Integer

    If AllUpdates = True Then
        ListAllUpdateFields GUID, tmpUpdateList
        tmpObjectType = GetObjectTypeFromGUID(GUID)
        Select Case tmpObjectType
            Case Object_Base
                frmMain.PrintOut "Base objects not yet implemented."
            Case Object_Item
                frmMain.PrintOut "Item objects not yet implemented."
            Case Object_Item_Container
                frmMain.PrintOut "Container objects not yet implemented."
            Case Object_Unit
                frmMain.PrintOut "Unit objects not yet implemented."
            Case Object_Unit_Player
                AddByteToArray msgArray, &H15
                ObjectManagement_CreateBitMask_All &H15, GUID, msgArray, tmpUpdateList
                ObjectManagement_LoadPlayerUpdateValues_All GUID, msgArray, tmpUpdateList
            Case Object_Game_Object
                frmMain.PrintOut "Game objects not yet implemented."
            Case Object_Dynamic_Object
                frmMain.PrintOut "Dynamic objects not yet implemented."
            Case Object_Corpse
                frmMain.PrintOut "Corpse objects not yet implemented."
        End Select
    Else
        tmpObjectType = GetObjectTypeFromGUID(GUID)
        Select Case tmpObjectType
            Case Object_Base
                frmMain.PrintOut "Base objects not yet implemented."
            Case Object_Item
                frmMain.PrintOut "Item objects not yet implemented."
            Case Object_Item_Container
                frmMain.PrintOut "Container objects not yet implemented."
            Case Object_Unit
                frmMain.PrintOut "Unit objects not yet implemented."
            Case Object_Unit_Player
                AddByteToArray msgArray, &H15
                ObjectManagement_CreateBitMask &H15, GUID, msgArray
                ObjectManagement_LoadPlayerUpdateValues GUID, msgArray
            Case Object_Game_Object
                frmMain.PrintOut "Game objects not yet implemented."
            Case Object_Dynamic_Object
                frmMain.PrintOut "Dynamic objects not yet implemented."
            Case Object_Corpse
                frmMain.PrintOut "Corpse objects not yet implemented."
        End Select
    End If
End Sub

Public Sub ObjectManagement_CreateBitMask_All(CountBitMasks As Long, GUID As tGUID, msgArray() As Byte, UpdateList() As Integer)
    Dim tmpBitMask As String, i As Long, j As Long
    Dim tmpCharacter As String
    Dim tmpUpdateField As Long

    tmpBitMask = String(CountBitMasks * 4, Chr(0))

    ShellSort UpdateList

    For j = 1 To CountBitMasks
        For i = 1 To UBound(UpdateList)
            If _
                    (UpdateList(i) >= ((j - 1) * 32)) And _
                    (UpdateList(i) < (j * 32)) Then
                tmpUpdateField = UpdateList(i) - (j - 1) * 32
                Select Case Int(tmpUpdateField / 8)
                    Case 0
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 0 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 0 + 1, 1) = tmpCharacter
                    Case 1
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 1 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 1 + 1, 1) = tmpCharacter
                    Case 2
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 2 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 2 + 1, 1) = tmpCharacter
                    Case 3
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 3 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 3 + 1, 1) = tmpCharacter
                End Select
            End If
        Next i
    Next j

    AddStringToArray msgArray, tmpBitMask, True
End Sub

Public Sub ObjectManagement_CreateBitMask(CountBitMasks As Long, GUID As tGUID, msgArray() As Byte)
    Dim tmpBitMask As String, i As Long, j As Long
    Dim tmpUpdateRecordNumber As Long
    Dim tmpCharacter As String
    Dim tmpUpdateField As Long

    tmpBitMask = String(CountBitMasks * 4, Chr(0))

    For i = 1 To Object_UpdateFields_Collection.Count
        If CompareGUIDs(Object_UpdateFields_Collection.GUIDs(i), GUID) = True Then
            tmpUpdateRecordNumber = i
            Exit For
        End If
    Next i

    ShellSort Object_UpdateFields_Collection.Updates(tmpUpdateRecordNumber).UpdateFields

    For j = 1 To CountBitMasks
        For i = 1 To Object_UpdateFields_Collection.Updates(tmpUpdateRecordNumber).Count
            If _
                    (Object_UpdateFields_Collection.Updates(tmpUpdateRecordNumber).UpdateFields(i) >= ((j - 1) * 32)) And _
                    (Object_UpdateFields_Collection.Updates(tmpUpdateRecordNumber).UpdateFields(i) < (j * 32)) Then
                tmpUpdateField = Object_UpdateFields_Collection.Updates(tmpUpdateRecordNumber).UpdateFields(i) - (j - 1) * 32
                Select Case Int(tmpUpdateField / 8)
                    Case 0
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 0 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 0 + 1, 1) = tmpCharacter
                    Case 1
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 1 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 1 + 1, 1) = tmpCharacter
                    Case 2
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 2 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 2 + 1, 1) = tmpCharacter
                    Case 3
                        tmpCharacter = Mid(tmpBitMask, (j - 1) * 4 + 3 + 1, 1)
                        tmpCharacter = Chr(Asc(tmpCharacter) Or (2 ^ (tmpUpdateField Mod 8)))
                        Mid(tmpBitMask, (j - 1) * 4 + 3 + 1, 1) = tmpCharacter
                End Select
            End If
        Next i
    Next j

    AddStringToArray msgArray, tmpBitMask, True
End Sub

Public Sub ObjectManagement_AddPositionUpdate(ByRef msgArray() As Byte, GUID As tGUID)
    Dim i As Long

    For i = 1 To Object_Movements_Collection.Count
        If CompareGUIDs(Object_Movements_Collection.GUIDs(i), GUID) Then

            AddLongToArray msgArray, Object_Movements_Collection.Movements(i).Flags    'flags. Not sure what these are yet.

            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).X_Position    'x
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).Y_Position    'y
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).Z_Position    'z
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).Facing    'facing

            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).WalkSpeed    'walk speed
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).RunSpeed    'run speed
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).SwimSpeed    'swim speed
            AddFloatToArray msgArray, Object_Movements_Collection.Movements(i).TurnRate    'turn ratio
            Exit Sub
        End If
    Next i

End Sub

Public Function Object_Movements_DecodeFlags(Flags As Long) As Long
    Dim tmpFlags As Long

    tmpFlags = Flags
    'Flags = Flags - 512

    Object_Movements_DecodeFlags = Flags

End Function

Public Sub ListAllUpdateFields(GUID As tGUID, ByRef UpdateList() As Integer)
    Dim i As Long, tmpRecordNumber As Long, tmpArray() As Byte, NumFields As Long

    tmpRecordNumber = GetPlayerObject_RecordNumber(GUID)

    ReDim tmpArray(LenB(Object_Unit_Player_Collection.Objects(i)))
    CopyMemory tmpArray(1), Object_Unit_Player_Collection.Objects(tmpRecordNumber), LenB(Object_Unit_Player_Collection.Objects(tmpRecordNumber))

    ReDim UpdateList(1)
    UpdateList(1) = 0

    NumFields = (UBound(tmpArray) / 4)

    For i = 2 To NumFields
        If (tmpArray((i - 1) * 4 + 1)) Or (tmpArray((i - 1) * 4 + 2)) Or (tmpArray((i - 1) * 4 + 3)) Or (tmpArray((i - 1) * 4 + 4)) Then
            ReDim Preserve UpdateList(UBound(UpdateList) + 1)
            UpdateList(UBound(UpdateList)) = (i - 1)
        End If
    Next i

End Sub

Public Sub AddUpdateFieldToTemporaryUpdateList(ByRef tmpUpdateList As tUpdateFields, UpdateField As Integer, UpdateFieldIsPrivate As Boolean)
    tmpUpdateList.Count = tmpUpdateList.Count + 1
    ReDim Preserve tmpUpdateList.UpdateFields(tmpUpdateList.Count)
    ReDim Preserve tmpUpdateList.UpdateFieldIsPrivate(tmpUpdateList.Count)
    tmpUpdateList.UpdateFields(tmpUpdateList.Count) = UpdateField
    tmpUpdateList.UpdateFieldIsPrivate(tmpUpdateList.Count) = UpdateFieldIsPrivate
End Sub

Public Sub AddUpdateFields(GUID As tGUID, UpdateList As tUpdateFields)
    On Error GoTo errOut
    Dim i As Long, j As Long, tmpRecordNumber As Long

    tmpRecordNumber = -1

    For i = 1 To Object_UpdateFields_Collection.Count
        If CompareGUIDs(Object_UpdateFields_Collection.GUIDs(i), GUID) Then
            tmpRecordNumber = i
            Exit For
        End If
    Next i

    If tmpRecordNumber = -1 Then
        Object_UpdateFields_Collection.Count = Object_UpdateFields_Collection.Count + 1
        ReDim Preserve Object_UpdateFields_Collection.GUIDs(Object_UpdateFields_Collection.Count)
        Object_UpdateFields_Collection.GUIDs(Object_UpdateFields_Collection.Count) = GUID
        ReDim Preserve Object_UpdateFields_Collection.Updates(Object_UpdateFields_Collection.Count)
        Object_UpdateFields_Collection.Updates(Object_UpdateFields_Collection.Count).Count = UpdateList.Count
        Object_UpdateFields_Collection.Updates(Object_UpdateFields_Collection.Count).UpdateFields = UpdateList.UpdateFields
        Object_UpdateFields_Collection.Updates(Object_UpdateFields_Collection.Count).UpdateFieldIsPrivate = UpdateList.UpdateFieldIsPrivate
    Else
        For i = 1 To UpdateList.Count
            If UpdateFieldInListAlready(tmpRecordNumber, UpdateList.UpdateFields(i)) = False Then
                With Object_UpdateFields_Collection.Updates(tmpRecordNumber)
                    .Count = .Count + 1
                    ReDim Preserve .UpdateFields(.Count)
                    .UpdateFields(.Count) = UpdateList.UpdateFields(i)
                    .UpdateFieldIsPrivate(.Count) = UpdateList.UpdateFieldIsPrivate(i)
                End With
            End If
        Next i
    End If
    Exit Sub
errOut:
    frmMain.PrintOut "Update Fields empty"
End Sub

Public Function UpdateFieldInListAlready(UpdateListRecord As Long, UpdateValueToCheck As Integer) As Boolean
    Dim i As Long

    UpdateFieldInListAlready = False

    For i = 1 To Object_UpdateFields_Collection.Updates(UpdateListRecord).Count
        If Object_UpdateFields_Collection.Updates(UpdateListRecord).UpdateFields(i) = UpdateValueToCheck Then
            UpdateFieldInListAlready = True
            Exit Function
        End If
    Next i

End Function

Public Sub Add_ObjectUpdateOperation_ToPacket(ByRef msgArray() As Byte, OperationType As Long, GUID As tGUID, ObjectType As enumObjectTypes, FieldsCount As Long, Fields() As Integer)
    AddByteToArray msgArray, CByte(Hex(OperationType))
    AddU64ToArray msgArray, GUID.low, GUID.high
End Sub
