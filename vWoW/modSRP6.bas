Attribute VB_Name = "modSRP6"
'OK this is SRP6 negotiation, BASED ON AWOWE
'This part may need to be improved!
Option Explicit

Global LOGON_CHALLENGE_Working As Boolean
Global LOGON_PROOF_Working As Boolean
Const G_Length = 1
Const G = 7
Const K = 3
Const Default_N = "894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7"
    
Sub Answer_CLIENT_AUTH_LOGON_CHALLENGE(sckIndex As Integer, AccID As Integer)
    
    While LOGON_CHALLENGE_Working = True
        DoEvents
    Wend
    
    LOGON_CHALLENGE_Working = True
    
    Dim bigint1 As Integer
    bigint1 = 17
    Dim bigint2 As Integer
    bigint2 = 18
    Dim bigint3 As Integer
    bigint3 = 19
    Dim bigint4 As Integer
    bigint4 = 20
    Dim bigint5 As Integer
    bigint5 = 16
    
    Dim N As String
    Dim B As String
    Dim X As String
    Dim Salt As String
    Dim PublicB As String
    'SHA1 Hash
    B = UCase("8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF")
    Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
    N = Default_N
    X = GenerateX(Account(AccID).AccName, Account(AccID).AccPassword, Salt)
    X = Reverse(X)
    N = Reverse(N)
    'SRP6 Calculation
    HexToBigInt N, bigint1
    HexToBigInt X, bigint2
    HexToBigInt G, bigint3
    ModExp bigint3, bigint2, bigint1, bigint4
    Account(AccID).V = BigIntToHex(bigint4)
    HexToBigInt K, bigint1
    Mult bigint4, bigint1, bigint2
    B = Reverse(B)
    HexToBigInt N, bigint1
    HexToBigInt B, bigint2
    ModExp bigint3, bigint2, bigint1, bigint5
    Add bigint5, bigint4
    Divd bigint5, bigint1, bigint4
    Copyf bigint5, bigint1
    PublicB = Reverse(BigIntToHex(bigint1))
    Account(AccID).PublicB = PublicB
    N = Default_N
    Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
    'Sending packet
                    Dim i As Integer
                    Dim data_response(118) As Byte
                    Dim T       As String
                    Dim E       As Integer
                    data_response(0) = RS_LOGON_CHALLENGE
                    data_response(1) = login_no_error
                    data_response(2) = Val("&H00")
                    For i = 3 To 35
                        data_response(i) = Val("&H" & Mid(PublicB, (i - 3) * 2 + 1, 2))
                    Next i
                    data_response(35) = G_Length
                    data_response(36) = Int(G)
                    data_response(37) = 32
                    For i = 38 To 69
                        data_response(i) = Val("&H" & Mid(N, (i - 38) * 2 + 1, 2))
                    Next i
                    For i = 70 To 101
                        data_response(i) = Val("&H" & Mid(Salt, (i - 70) * 2 + 1, 2))
                    Next i
                    For i = 102 To 117
                        data_response(i) = 0
                    Next i
                    data_response(118) = 0
        
                    On Error Resume Next
                    frmCore.sckRS(sckIndex).SendData data_response
                    
                    E = FreeFile
                    T = Chr$(34)
            
                    Open App.Path & "\data.txt" For Output As #E
                        For i = 2 To 117
                            Print #E, data_response(i)
                        Next i
                    Close #E
    
    LOGON_CHALLENGE_Working = False
End Sub

Function Reverse(strString As String) As String
    Dim i As Integer
    Dim output As String
    output = ""
    For i = Len(strString) - 1 To 1 Step -2
        output = output + Mid(strString, i, 2)
    Next i
    Reverse = output
End Function

Sub Answer_CLIENT_LOGON_PROOF(ClientA As String, ClientM1 As String, Index As Integer, user As Integer)
    While LOGON_PROOF_Working = True
        DoEvents
    Wend
    LOGON_PROOF_Working = True
    Dim i As Integer
    Dim bigint1 As Integer
    bigint1 = 15
    Dim bigint2 As Integer
    bigint2 = 14
    Dim bigint3 As Integer
    bigint3 = 13
    Dim bigint4 As Integer
    bigint4 = 7
    Dim bigint5 As Integer
    bigint5 = 8
    
    Dim U As String
    Dim N As String
    Dim a As String
    Dim B As String
    Dim Salt As String
    Dim S As String
    Dim M1 As String
    Dim PublicB As String
    Dim V As String
    Dim SS_Hash As String
    
    'DEBUG Values:
    '****************************************************************************
    'N = UCase("894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7")
    B = UCase("8692E3A6BA48B5B1004CEF76825127B7EB7D1AEF")
    Salt = UCase("33f140d46cb66e631fdbbbc9f029ad8898e05ee533876118185e56dde843674f")
    'A = UCase("232fb1b88529643d95b8dce78f2750c75b2df37acba873eb31073839eda0738d")
    'M1 = UCase("eeb4adca80f4de02f9a9fe8d000d682e3ddfad6f")
    'PublicB = UCase("645d1f78973073701e12bc98aa38ea99b4bc435c32e8447c73ab077ae4d75964")
    'V = UCase("996ec7b349d5827043ecd0e6efba3daea5590f944d0184fee1b83ff4f59ecfa8")
    '****************************************************************************
    N = Default_N
    a = ClientA
    'B = Account(user).B
    PublicB = Account(user).PublicB
    V = Account(user).V
    
    Dim temp1 As String
    Dim temp2 As String
    
    U = modSHA1.sha1(HexToStr(a) + HexToStr(PublicB))
    U = Reverse(U)
    
    N = Reverse(N)
    a = Reverse(a)
    B = Reverse(B)
    
    HexToBigInt V, bigint1
        'Log "V=" & V & "=" & BigIntToHex(bigint1)
    HexToBigInt U, bigint2
        'Log "U=" & U & "=" & BigIntToHex(bigint2)
    HexToBigInt N, bigint3
        'Log "N=" & N & "=" & BigIntToHex(bigint3)
    
    ModExp bigint1, bigint2, bigint3, bigint4
        'Log "temp1=" & BigIntToHex(bigint4)
        'Data = ""
        'Printf bigint4, "", "", False
        'Log Data
        
    HexToBigInt a, bigint1
    Mult bigint4, bigint1, bigint3
        'Log "temp2=" & BigIntToHex(bigint4)
    
    HexToBigInt B, bigint1
        'Log "B=" & B & "=" & BigIntToHex(bigint1)
    HexToBigInt N, bigint3
        'Log "N=" & N & "=" & BigIntToHex(bigint3)
    ModExp bigint4, bigint1, bigint3, bigint2
        'Log "S=" & BigIntToHex(bigint2)
    S = BigIntToHex(bigint2)
    S = Reverse(S)
    temp1 = ""
    temp2 = ""
    For i = 1 To Len(S) Step 2
        If i \ 2 Mod 2 = 0 Then
            temp1 = temp1 + Mid(S, i, 2)
        Else
            temp2 = temp2 + Mid(S, i, 2)
        End If
    Next i
        'Log "S1=" & temp1
        'Log "S2=" & temp2
    temp1 = HexToStr(temp1)
    temp2 = HexToStr(temp2)
    temp1 = modSHA1.sha1(temp1)
    temp2 = modSHA1.sha1(temp2)
        'Log "S1_Hash=" & temp1
        'Log "S2_Hash=" & temp2
    SS_Hash = ""
    For i = 1 To Len(temp1) Step 2
        SS_Hash = SS_Hash + Mid(temp1, i, 2) + Mid(temp2, i, 2)
        Account(user).bSS_Hash(i - 1) = Val("&H" & Mid(temp1, i, 2)) '<-added
        Account(user).bSS_Hash(i) = Val("&H" & Mid(temp2, i, 2))    '<--added
    Next i
        'Log "SS_Hash=" & SS_Hash
    Account(user).SS_Hash = SS_Hash
        
    'Calc M1 to verify it matches the M1 supplied by the client
    Dim N_Hash As String
    Dim G_Hash As String
    Dim NG_Hash As String
    Dim User_Hash As String
    'Dim Username As String
    'Username = "TEST"
    
    User_Hash = modSHA1.sha1(UCase(Account(user).AccName))
    N = Reverse(N)
    N_Hash = modSHA1.sha1(HexToStr(N))
    G_Hash = modSHA1.sha1(Chr(7))
    NG_Hash = ""
    For i = 1 To Len(N_Hash)
        NG_Hash = NG_Hash + hex(Val("&H" & Mid(N_Hash, i, 1)) Xor Val("&H" & Mid(G_Hash, i, 1)))
    Next i
    
    temp1 = NG_Hash & User_Hash & Salt & Reverse(a) & PublicB & SS_Hash
    M1 = modSHA1.sha1(HexToStr(temp1))
    
    '!!! Verify here client M1 and calculated M1
        Dim data_response() As Byte
        If UCase(M1) = UCase(ClientM1) Then
                'pass accepted, calculate M2 and send it
                temp1 = Reverse(a) & M1 & SS_Hash
                M1 = modSHA1.sha1(HexToStr(temp1))
                ReDim data_response(25) As Byte
                data_response(0) = RS_LOGON_PROOF
                data_response(1) = login_no_error
                For i = 2 To 21
                    data_response(i) = Val("&H" & Mid(M1, (i - 2) * 2 + 1, 2))
                Next i
                data_response(22) = 0
                data_response(23) = 0
                data_response(24) = 0
                data_response(25) = 0
                On Error Resume Next
                frmCore.sckRS(Index).SendData data_response
            Else
                'wrong pass
                Log "Bad password [" & Account(user).AccName & "]"
                ReDim data_response(1) As Byte
                data_response(0) = RS_LOGON_PROOF
                data_response(1) = login_bad_pass
                On Error Resume Next
                frmCore.sckRS(Index).SendData data_response
        End If
       
        
    LOGON_PROOF_Working = False
End Sub
