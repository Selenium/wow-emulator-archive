Attribute VB_Name = "CharacterRoutines"
Option Explicit
Option Base 1

Public Function CHARACTERS_GetName(CharacterGUID As tGUID) As String
    Dim i As Long

    For i = 1 To Characters_Record.Count
        If CompareGUIDs(Characters_Record.Characters(i).GUID, CharacterGUID) Then
            CHARACTERS_GetName = Characters_Record.Characters(i).Name
            Exit Function
        End If
    Next i
End Function

Public Sub CHARACTERS_GetNameInfo(CharacterGUID As tGUID, ByRef CharacterName As String, ByRef CharacterClass As Long, ByRef CharacterGender As Long, ByRef CharacterRace As Long)
    Dim i As Long

    For i = 1 To Characters_Record.Count
        If CompareGUIDs(Characters_Record.Characters(i).GUID, CharacterGUID) Then
            CharacterName = Characters_Record.Characters(i).Name
            CharacterClass = Characters_Record.Characters(i).Class
            CharacterGender = Characters_Record.Characters(i).Gender
            CharacterRace = Characters_Record.Characters(i).Race
            Exit Sub
        End If
    Next i
End Sub

Public Function CHARACTERS_GetRecordNumber(CharacterGUID As tGUID) As Long
    Dim i As Long

    For i = 1 To Characters_Record.Count
        If CompareGUIDs(Characters_Record.Characters(i).GUID, CharacterGUID) Then
            CHARACTERS_GetRecordNumber = i
            Exit Function
        End If
    Next i

    CHARACTERS_GetRecordNumber = -1
End Function

Public Function CHARACTERS_CreateNewCharacter(NewCharacter As tNewCharacter) As tGUID
    Dim tmpGUID As tGUID

    Characters_Record.Count = Characters_Record.Count + 1

    tmpGUID = CreateNewGUID(Object_Unit_Player)            'GUIDList '= Characters_Record.GUIDCount
    'MsgBox tmpGUID.low
    CHARACTERS_CreateNewCharacter = tmpGUID

    ReDim Preserve Characters_Record.Characters(Characters_Record.Count)
    With Characters_Record.Characters(Characters_Record.Count)
        .Name = NewCharacter.Name
        .Race = NewCharacter.Race
        .Class = NewCharacter.Class
        .Gender = NewCharacter.Gender
        .Skin = NewCharacter.Skin
        .Face = NewCharacter.Face
        .hairStyle = NewCharacter.hairStyle
        .hairColour = NewCharacter.hairColour
        .FacialHair = NewCharacter.FacialHair
        .GUID = tmpGUID
        .TutorialFlags(1) = &H0
        .TutorialFlags(2) = &H0
        .TutorialFlags(3) = &H0
        .TutorialFlags(4) = &H0
        .PositionX = -8922.83
        .PositionY = -115.161
        .PositionZ = 82.6822
        .PositionFacing = 5.1121
        '.PackSlots(1) = CreateNewItem
        'newCharacter.OutfitID
    End With
End Function
