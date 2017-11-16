Attribute VB_Name = "modArrays"
Option Explicit
Option Base 1

Public Sub AddByteToArray(ByRef bArray() As Byte, newByte As Byte)
    On Error GoTo errNewArray
    ReDim Preserve bArray(UBound(bArray) + 1)
    bArray(UBound(bArray)) = newByte
    Exit Sub
errNewArray:
    ReDim bArray(1)
    bArray(UBound(bArray)) = newByte
End Sub

Public Sub AddFloatToArray(ByRef bArray() As Byte, newFloat As Single)
    On Error GoTo errNewArray

    ReDim Preserve bArray(UBound(bArray) + 4)
    CopyMemory bArray(UBound(bArray) - 3), newFloat, 4
    Exit Sub
errNewArray:
    ReDim bArray(4)
    CopyMemory bArray(1), newFloat, 4
End Sub

Public Sub AddGUIDToArray(ByRef bArray() As Byte, GUID As tGUID)
    AddLongToArray bArray, GUID.low
    AddLongToArray bArray, GUID.high
End Sub

Public Sub AddU64ToArray(ByRef bArray() As Byte, U64_low As Long, U64_high As Long)
    AddLongToArray bArray, U64_low
    AddLongToArray bArray, U64_high
End Sub

Public Sub AddNetCodeIntegerToArray(ByRef bArray() As Byte, newInteger As Integer)
    On Error GoTo errNewArray
    Dim tmpByte As Byte

    ReDim Preserve bArray(UBound(bArray) + 2)
    CopyMemory bArray(UBound(bArray) - 1), newInteger, 2
    tmpByte = bArray(UBound(bArray))
    bArray(UBound(bArray)) = bArray(UBound(bArray) - 1)
    bArray(UBound(bArray) - 1) = tmpByte
    Exit Sub
errNewArray:
    ReDim bArray(2)
    CopyMemory bArray(1), newInteger, 2
    tmpByte = bArray(UBound(bArray))
    bArray(UBound(bArray)) = bArray(UBound(bArray) - 1)
    bArray(UBound(bArray) - 1) = tmpByte
End Sub

Public Sub AddIntegerToArray(ByRef bArray() As Byte, newInteger As Long)
    On Error GoTo errNewArray

    ReDim Preserve bArray(UBound(bArray) + 2)
    CopyMemory bArray(UBound(bArray) - 1), newInteger, 2
    Exit Sub
errNewArray:
    ReDim bArray(2)
    CopyMemory bArray(1), newInteger, 2
End Sub

Public Sub AddLongToArray(ByRef bArray() As Byte, newLong As Long)
    On Error GoTo errNewArray

    ReDim Preserve bArray(UBound(bArray) + 4)
    CopyMemory bArray(UBound(bArray) - 3), newLong, 4
    Exit Sub
errNewArray:
    ReDim bArray(4)
    CopyMemory bArray(1), newLong, 4
End Sub

Public Function GetStringFromArray(ByRef bArray() As Byte, ByRef PacketLength As Long) As String
    Dim tmpString As String, tmpArray() As Byte
    Dim i As Long, nullPosition As Long

    For i = 1 To UBound(bArray)
        If bArray(i) = 0 Then
            nullPosition = i
            Exit For
        End If
    Next i

    tmpString = StrConv(bArray, vbUnicode)
    tmpString = Left(tmpString, nullPosition)

    If (UBound(bArray) - nullPosition) > 0 Then
        ReDim tmpArray(UBound(bArray) - nullPosition)
        CopyMemory tmpArray(1), bArray(nullPosition + 1), UBound(bArray) - nullPosition
        bArray = tmpArray
    End If

    PacketLength = PacketLength - nullPosition
    GetStringFromArray = Left(tmpString, Len(tmpString) - 1)    'trim trailing null

End Function

Public Function GetGUIDFromArray(ByRef bArray() As Byte, ByRef PacketLength As Long) As tGUID
    Dim U64_GUID_low As Long, U64_GUID_high As Long

    U64_GUID_low = GetLongFromArray(bArray, PacketLength)
    U64_GUID_high = GetLongFromArray(bArray, PacketLength)

    GetGUIDFromArray.low = U64_GUID_low
    GetGUIDFromArray.high = U64_GUID_high

End Function

Public Function GetByteFromArray(ByRef bArray() As Byte, ByRef PacketLength As Long) As Byte
    Dim tmpByte As Long, tmpArray() As Byte

    'MsgBox bArray(1) * 256 ^ 3 + bArray(2) * 256 ^ 2 + bArray(3) * 256 + bArray(4)

    CopyMemory tmpByte, bArray(1), 1

    If PacketLength > 1 Then
        ReDim tmpArray(UBound(bArray) - 1)
        CopyMemory tmpArray(1), bArray(2), UBound(tmpArray)
        bArray = tmpArray
    End If

    PacketLength = PacketLength - 1
    GetByteFromArray = tmpByte
End Function

Public Function GetFloatFromArray(ByRef bArray() As Byte, ByRef PacketLength As Long) As Single
    Dim tmpSingle As Single, tmpArray() As Byte

    'MsgBox bArray(1) * 256 ^ 3 + bArray(2) * 256 ^ 2 + bArray(3) * 256 + bArray(4)
    CopyMemory tmpSingle, bArray(1), 4
    If UBound(bArray) > 4 Then
        ReDim tmpArray(UBound(bArray) - 4)
        CopyMemory tmpArray(1), bArray(5), UBound(tmpArray)
    End If

    PacketLength = PacketLength - 4

    GetFloatFromArray = tmpSingle
    bArray = tmpArray
End Function

Public Function GetLongFromArray(ByRef bArray() As Byte, ByRef PacketLength As Long) As Long

    Dim tmpLong As Long, tmpArray() As Byte

    'MsgBox bArray(1) * 256 ^ 3 + bArray(2) * 256 ^ 2 + bArray(3) * 256 + bArray(4)
    CopyMemory tmpLong, bArray(1), 4
    If UBound(bArray) > 4 Then
        ReDim tmpArray(UBound(bArray) - 4)
        CopyMemory tmpArray(1), bArray(5), UBound(tmpArray)
    End If

    PacketLength = PacketLength - 4

    GetLongFromArray = tmpLong
    bArray = tmpArray
End Function

Public Sub AddStringToArrayWithoutNull(ByRef bArray() As Byte, newString As String)
    On Error GoTo errNewArray
    Dim i As Long, OriginalUbound As Long

    OriginalUbound = UBound(bArray)
    ReDim Preserve bArray(UBound(bArray) + Len(newString))
    For i = 1 To Len(newString)
        bArray(OriginalUbound + i) = CByte(Asc(Mid(newString, i, 1)))
    Next i
    Exit Sub
errNewArray:
    OriginalUbound = 0
    ReDim bArray(Len(newString))
    For i = 1 To Len(newString)
        bArray(OriginalUbound + i) = CByte(Asc(Mid(newString, i, 1)))
    Next i
End Sub

Public Sub AddStringToArray(ByRef bArray() As Byte, newString As String, Optional OmitNull As Boolean = False)
    On Error GoTo errNewArray
    Dim i As Long, OriginalUbound As Long, tNull As Byte

    If OmitNull = True Then
        tNull = 0
    Else
        tNull = 1
    End If

    OriginalUbound = UBound(bArray)
    ReDim Preserve bArray(UBound(bArray) + Len(newString) + tNull)
    For i = 1 To Len(newString)
        bArray(OriginalUbound + i) = CByte(Asc(Mid(newString, i, 1)))
    Next i
    Exit Sub
errNewArray:
    OriginalUbound = 0
    ReDim bArray(Len(newString) + tNull)
    For i = 1 To Len(newString)
        bArray(OriginalUbound + i) = CByte(Asc(Mid(newString, i, 1)))
    Next i
End Sub
