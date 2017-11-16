Attribute VB_Name = "modHotFixs"
'Highest value the port number can go
Public Const MAX_PORT = 65535
Public Const LOW_PORT = 0

'For sections of the interface that use numeric values only
Public Function MakeNumeric(ByVal AsciiCode As Integer)
    If IsNumeric(Chr(AsciiCode)) Then
        MakeNumeric = AsciiCode
    Else
        MakeNumeric = vbKeyReturn
    End If
End Function

'Enforce integer port rules
Public Function IntegerCheck(ByVal ValueInteger As Long, ByVal MAX As Long, ByVal LOW As Long)
    If ValueInteger < LOW Then
        IntegerCheck = LOW
        Exit Function
    End If
    If ValueInteger > MAX Then
        IntegerCheck = MAX
        Exit Function
    End If
    IntegerCheck = ValueInteger
End Function
