Attribute VB_Name = "modArray"
Option Explicit
Option Base 1

Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (pDst As Any, pSrc As Any, ByVal ByteLen As Long)

' Some functions from here is taken from the GhostCraft source

Public Sub AddByteToArray(ByRef bArray() As Byte, newByte As Byte)
    On Error GoTo errNewArray
    ReDim Preserve bArray(UBound(bArray) + 1)
    bArray(UBound(bArray)) = newByte
    Exit Sub
errNewArray:
    ReDim bArray(1)
    bArray(UBound(bArray)) = newByte
End Sub

Public Sub AddGUIDToArray(ByRef bArray() As Byte, GUID As String)
    AddLongToArray bArray, Mid(GUID, 1, 1)
    AddLongToArray bArray, Mid(GUID, 2, 1)
    AddLongToArray bArray, Mid(GUID, 3, 1)
    AddLongToArray bArray, Mid(GUID, 4, 1)
    AddLongToArray bArray, Mid(GUID, 5, 1)
    AddLongToArray bArray, Mid(GUID, 6, 1)
    AddLongToArray bArray, Mid(GUID, 7, 1)
    AddLongToArray bArray, Mid(GUID, 8, 1)
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

Public Sub AddIntegerToArray(ByRef bArray() As Byte, newInteger As Long)
    On Error GoTo errNewArray

    ReDim Preserve bArray(UBound(bArray) + 2)
    CopyMemory bArray(UBound(bArray) - 1), newInteger, 2
    Exit Sub
errNewArray:
    ReDim bArray(2)
    CopyMemory bArray(1), newInteger, 2
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
