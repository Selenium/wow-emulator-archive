Attribute VB_Name = "GUIDs"
Option Explicit
Option Base 1

Public Type tGUIDList
    GUIDCount As Long
    GUIDs() As tGUID
    Types() As enumObjectTypes
End Type

Public GUIDList As tGUIDList

Public Function GetObjectTypeFromGUID(GUID As tGUID) As enumObjectTypes
    Dim i As Long

    For i = 1 To GUIDList.GUIDCount
        If CompareGUIDs(GUID, GUIDList.GUIDs(i)) Then
            GetObjectTypeFromGUID = GUIDList.Types(i)
            Exit Function
        End If
    Next i
End Function

Public Function CombineToGUID(U64_low As Long, U64_high As Long) As tGUID
    CombineToGUID.low = U64_low
    CombineToGUID.high = U64_high
End Function

Public Function CreateNewGUID(ObjectType As enumObjectTypes) As tGUID
    With GUIDList
        .GUIDCount = .GUIDCount + 1
        ReDim Preserve .GUIDs(.GUIDCount)
        .GUIDs(.GUIDCount).low = .GUIDCount
        .GUIDs(.GUIDCount).high = ObjectType
        ReDim Preserve .Types(.GUIDCount)
        .Types(.GUIDCount) = ObjectType
    End With

    CreateNewGUID = GUIDList.GUIDs(GUIDList.GUIDCount)

End Function

Public Function CompareGUIDs(GUIDa As tGUID, GUIDb As tGUID) As Boolean
    CompareGUIDs = False
    If (GUIDa.low = GUIDb.low) And (GUIDa.high = GUIDb.high) Then CompareGUIDs = True
End Function

