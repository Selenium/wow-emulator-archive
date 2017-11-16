Attribute VB_Name = "modWSFunctions"
Option Explicit

Sub Send_SMSG_AUTH_CHALLENGE(Index As Integer)
    Dim data_response(7) As Byte
    data_response(0) = &H0
    data_response(1) = &H6
    data_response(3) = SMSG_AUTH_CHALLENGE \ 256
    data_response(2) = SMSG_AUTH_CHALLENGE Mod 256
    
    data_response(4) = &H71
    data_response(5) = &H2C
    data_response(6) = &H73
    data_response(7) = &H88
    
    On Error Resume Next
    frmCore.sckWS(Index).SendData data_response
End Sub


Function FindRSUser(user As String) As Integer
    FindRSUser = -1
    Dim i As Integer
    For i = 0 To Users_Count
        If Account(i).AccName = user Then
            FindRSUser = i
            Exit Function
        End If
    Next i
End Function


Sub Decode(Data() As Byte, user As Integer)
Dim T As Integer
Dim a As Integer
Dim B As Integer
Dim d As Integer

    For T = 0 To 5 '<6
        a = Account(user).Key(0)
        Account(user).Key(0) = Data(T)
        B = Data(T)
        
        B = CByte((B - a) And &HFF)
        d = Account(user).Key(1)
        a = Account(user).bSS_Hash(d)
        a = CByte((a Xor B) And &HFF)
        Data(T) = a

        a = Account(user).Key(1)
        a = a + 1
        Account(user).Key(1) = a Mod &H28
    Next T
End Sub

Sub EncodeOld(Data() As Byte, user As Integer)
    Dim i As Integer
    Dim a As Integer
    Dim d As Integer
        'Log "DEBUG: Encoding..."
        'Log "DEBUG: SS_Hash=" & Account(user).SS_Hash
    
    For i = 0 To 3
        a = Account(user).Key(3)
        a = Account(user).K(a) Xor Data(i)
        d = Account(user).Key(2)
        a = a + d
        a = a Mod 256
        Data(i) = a
        Account(user).Key(2) = a
        a = Account(user).Key(3)
        a = a + 1
        Account(user).Key(3) = a Mod 40
    Next i
End Sub

Sub Encode(Data() As Byte, user As Integer)
Dim T As Integer
Dim a As Integer
Dim B As Integer
Dim d As Integer

    For T = 0 To 3
        a = Account(user).Key(3)
        a = CByte((Account(user).bSS_Hash(a) Xor Data(T)) And &HFF)
        d = Account(user).Key(2)
        a = CByte((a + d) And &HFF)
        Data(T) = a
        Account(user).Key(2) = a
        a = Account(user).Key(3)
        a = a + 1
        Account(user).Key(3) = a Mod &H28
    Next T
End Sub

Sub Encode2(Data() As String, user As Integer)
Dim T As Integer
Dim a As Integer
Dim B As Integer
Dim d As Integer

    For T = 0 To 3
        a = Account(user).Key(3)
        a = CByte((Account(user).bSS_Hash(a) Xor Data(T)) And &HFF)
        d = Account(user).Key(2)
        a = CByte((a + d) And &HFF)
        Data(T) = a
        Account(user).Key(2) = a
        a = Account(user).Key(3)
        a = a + 1
        Account(user).Key(3) = a Mod &H28
    Next T
End Sub

Function GetFreeChar() As Long
    'generate guid and initialize it!
    GetFreeChar = -1
    Dim i As Integer
    Dim j As Integer
    For i = 1 To UBound(Account)
      If Account(i).AccChars > 0 Then
        For j = 1 To Account(i).AccChars
            If Account(i).AccChar(j).Name = "" Then
                GetFreeChar = j
                Exit Function
            End If
        Next j
      Else
        GetFreeChar = 1
      End If
    Next i
End Function

Function FindCharName(FindName As String) As Long
    FindCharName = -1
    Dim i As Integer
    Dim j As Integer
    For i = 0 To UBound(Account)
        For j = 1 To UBound(Account(i).AccChar)
            If Account(i).AccChar(j).Name = FindName Then
                FindCharName = i
                Exit Function
            End If
        Next j
    Next i
End Function

Function FormatHEX(ByVal Data As String, length As Byte) As String
'This function will make a GUID... This needs to be fixed, for example character Testchar will have same GUID as Tester and Test (first 4 letters)
Dim Buffer As String, Tmp As Variant, i As Integer, CheckSize As Integer

    For i = 1 To Len(Data)
        Tmp = hex(Asc(Mid(Data, i, 1)))
        If Tmp < length Then
            Buffer = Buffer & "0" & Tmp
        Else
            Buffer = Buffer & Tmp
        End If
    Next i
    
    Buffer = Replace(Buffer, "A", "0")
    Buffer = Replace(Buffer, "B", "1")
    Buffer = Replace(Buffer, "C", "2")
    Buffer = Replace(Buffer, "D", "3")
    Buffer = Replace(Buffer, "E", "4")
    Buffer = Replace(Buffer, "F", "5")
    
    FormatHEX = Left(Buffer, length)
End Function
