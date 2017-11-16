Attribute VB_Name = "modBasicFunctions"
'Basic Functions should be here

Public Function Log(strToLog As String)
frmCore.txtConsole.Text = frmCore.txtConsole.Text & strToLog & vbCrLf
End Function

Public Function LogDebug(strToLog As String)
frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & strToLog & vbCrLf
End Function

'We may need a function that generates a random string...
Function SRP6_Random(intLen As Integer) As String
Dim i As Integer
Dim CharCode As Integer
Dim NumCode As Integer
Dim RndNum As Variant
SRP6_Random = ""
For i = 1 To intLen
If Len(SRP6_Random) = intLen Then
Return
Exit Function
Else
    Randomize
    RndNum = Split(2 * Rnd(10), ",")
    If RndNum(0) <> 1 Then
        RndNum = Split(8 * Rnd(8), ",")
        NumCode = 49 + RndNum(0)
        SRP6_Random = SRP6_Random & Chr(NumCode)
    Else
        RndNum = Split(25 * Rnd(25), ",")
        CharCode = 65 + RndNum(0)
        SRP6_Random = SRP6_Random & Chr(CharCode)
    End If

End If
Next i
End Function

'Easy function to check if a string contains a specefic text
'Used in account system
Public Function ContainStr(strString As String, strWhat As String) As Boolean
Dim i As Integer
For i = 1 To Len(strString)
If Mid(strString, i, Len(strWhat)) = strWhat Then
ContainStr = True
End If
Next i
End Function
