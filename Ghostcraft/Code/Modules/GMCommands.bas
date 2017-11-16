Attribute VB_Name = "GMCommands"
Option Explicit

Public Sub WORLD_ParseGMCommand(ChatString As String, GUID As tGUID, LinkNumber As Long)
    On Error GoTo errOut

    Dim msgArray() As Byte
    Dim tmpUpdateList As tUpdateFields
    Dim tSplit() As String

    tSplit = Split(ChatString, " ", , vbTextCompare)

    Select Case LCase(tSplit(0))
        Case "!god"
            WORLD_SendSystemMessage "GM commands follow: !model <#> to change your model; !worldport <world X Y Z> to teleport; !time <#> to change the time (buggy).", LinkNumber
        Case "!model"
            Object_Unit_Player_Collection.Objects(Object_Unit_Player_Collection.Count).Unit.f151_DISPLAYID = CInt(tSplit(1))

            AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 151, False
            AddUpdateFields GUID, tmpUpdateList

            AddLongToArray msgArray, CLng(&HA9)
            AddLongToArray msgArray, CLng(&H1)
            ObjectManagement_UpdateObject msgArray, GUID

            WORLD_SendMessage LinkNumber, msgArray
            WORLD_SendSystemMessage "Model succesfully switched.", LinkNumber
        Case "!worldport"
            ObjectManagement_RemovePlayerFromCollection GUID
            GM_TeleportPlayer CLng(tSplit(1)), CSng(tSplit(2)), CSng(tSplit(3)), CSng(tSplit(4)), LinkNumber, GUID
        Case "!time"
            GM_SetTime CLng(tSplit(1))
        Case Else
            WORLD_SendSystemMessage "Unrecognized command " & LCase(0) & ".", LinkNumber
    End Select

    Exit Sub

errOut:
    WORLD_SendSystemMessage "An error was encountered. Please try again.", LinkNumber
End Sub

Public Sub GM_SetTime(NewTime As Long)
    Dim msgArray() As Byte, i As Long
    If NewTime > 1532 Then NewTime = 1532
    WorldTime = NewTime

    For i = 1 To Accounts_LoggedIn.Count
        WORLD_UpdateGameTime Accounts_LoggedIn.AccountsLoggedIn(i).LinkNumber
    Next i

End Sub

Public Sub GM_TeleportPlayer(World As Long, X As Single, Y As Single, Z As Single, LinkNumber As Long, GUID As tGUID)
    Dim msgArray() As Byte
    Dim tmpRecordNumber As Long

    AddLongToArray msgArray, CLng(&H3E)
    AddByteToArray msgArray, CByte(World)
    AddFloatToArray msgArray, X
    AddFloatToArray msgArray, Y
    AddFloatToArray msgArray, Z
    AddFloatToArray msgArray, 0

    tmpRecordNumber = CHARACTERS_GetRecordNumber(GUID)

    With Characters_Record.Characters(tmpRecordNumber)
        .PositionX = X
        .PositionY = Y
        .PositionZ = Z
    End With

    WORLD_SendMessage LinkNumber, msgArray
End Sub
