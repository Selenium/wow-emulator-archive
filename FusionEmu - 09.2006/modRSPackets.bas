Attribute VB_Name = "modRSPackets"
Option Explicit

Global Realms_count As Byte
Global Realms(10) As TRealmInfo

Function AnalyzeRS(RealmData() As Byte, sckIndex As Integer)
'We are going to Analyze all the realm packets one by one
'We first need to know what's the Opcode
Dim msgArray() As Byte, msgLength() As Byte
Dim T       As String
Dim E       As Integer

Select Case RealmData(0)
    'Both packets have the same function and answer
    Case RS_LOGON_CHALLENGE, RS_RECONNECT_CHALLENGE
    
        'Needed data
        Dim i As Integer
        Dim Build As Integer
        Dim intLoginAccountID As Integer
        Dim Version As String
        Dim LoginName As String
        Dim RemoteIp As String
        Dim Answer_data() As Byte
        
        'Packet Analysis
        Version = Val(RealmData(8)) & "." & Val(RealmData(9)) & "." & Val(RealmData(10))
        Build = Val("&H" & hex(RealmData(12)) & hex(RealmData(11)))
        RemoteIp = Format(RealmData(29), "0") & "." & Format(RealmData(30), "0") & "." & Format(RealmData(31), "0") & "." & Format(RealmData(32), "0")
        
        'We get Account name
        For i = 34 To UBound(RealmData)
            LoginName = LoginName & Chr(RealmData(i))
        Next i
        
        '####################################################################
        'DEBUG Info
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Opcode:" & RealmData(0) & vbCrLf
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Packet Size:" & RealmData(2) & vbCrLf
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Version:" & Version & vbCrLf
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Build:" & Build & vbCrLf
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Adress:" & RemoteIp & vbCrLf
        'frmCore.txtDEBUG.Text = frmCore.txtDEBUG.Text & "Account:" & LoginName & vbCrLf
        'DEBUG Info
        '####################################################################
        
        'Console Log
        Log "sckRS(" & sckIndex & "):Client connection from " & RemoteIp & " with version " & Version & " build " & Build & " account [" & LoginName & "]"
        Account(intAccountID(LoginName)).AccIp = frmCore.sckRS(sckIndex).RemoteHostIP
        
        'Time to identify user Account, check if exists and if it does, check Account Status
        intLoginAccountID = intAccountID(LoginName)
        If intLoginAccountID <> -1 Then
            Select Case intAccountStatus(intLoginAccountID)
                Case 0
                 Log "Account found [" & LoginName & "]"
                 Answer_CLIENT_AUTH_LOGON_CHALLENGE sckIndex, intLoginAccountID
                 Account(intAccountID(LoginName)).AccStatus = 1
                 frmCore.sckRS(sckIndex).Tag = intAccountID(LoginName)
                Case 1
                 Log "Account already logged in [" & LoginName & "]"
                 ReDim Answer_data(1)
                 Answer_data(0) = RS_LOGON_PROOF
                 Answer_data(1) = login_account_already_logged
                 frmCore.sckRS(sckIndex).SendData Answer_data
                Case 2
                 Log "Account banned [" & LoginName & "]"
                 ReDim Answer_data(1)
                 Answer_data(0) = RS_LOGON_PROOF
                 Answer_data(1) = login_account_closed
                 frmCore.sckRS(sckIndex).SendData Answer_data
                Case 3
                 Log "Account has not payed [" & LoginName & "]"
                 ReDim Answer_data(1)
                 Answer_data(0) = RS_LOGON_PROOF
                 Answer_data(1) = login_prepaid_time_used_up
                 frmCore.sckRS(sckIndex).SendData Answer_data
            End Select
        Else
        
            ReDim Answer_data(1)
            Log "Account not found [" & LoginName & "]"
            Answer_data(0) = RS_LOGON_PROOF
            Answer_data(1) = login_bad_user
            frmCore.sckRS(sckIndex).SendData Answer_data
            
        End If

    
    Case RS_LOGON_PROOF, RS_RECONNECT_PROOF
    'In this packet, client sends us Public_A and M1
        Dim a As String
        Dim M1 As String
            'Dim CRC_Hash As String
            a = ""
            M1 = ""
            'CRC_Hash = ""
            For i = 1 To 32
                If Len(hex(RealmData(i))) < 2 Then
                    a = a + "0" + hex(RealmData(i))
                Else
                    a = a + hex(RealmData(i))
                End If
            Next i
            For i = 33 To 33 + 19
                If Len(hex(RealmData(i))) < 2 Then
                    M1 = M1 + "0" + hex(RealmData(i))
                Else
                    M1 = M1 + hex(RealmData(i))
                End If
            Next i
            'For i = 53 To 53 + 19
            '    If Len(hex(Data(i))) < 2 Then
            '        CRC_Hash = CRC_Hash + "0" + hex(Data(i))
            '    Else
            '        CRC_Hash = CRC_Hash + hex(Data(i))
            '    End If
            'Next i
            Log "Logon proof [" & Account(frmCore.sckRS(sckIndex).Tag).AccName & "]"
            Answer_CLIENT_LOGON_PROOF a, M1, sckIndex, frmCore.sckRS(sckIndex).Tag
    
    Case RS_REALMLIST
    ' Client asks for Realmlist
    
            Log "Request Realmlist [" & Account(frmCore.sckRS(sckIndex).Tag).AccIp & "]"
            Dim packet_len As Integer
            packet_len = 0
            For i = 0 To Realms_count - 1
                packet_len = packet_len + Len(Realms(i).address) + Len(Realms(i).Name) + 5 + 7 + 2
            Next i
            ReDim data_response(packet_len + 1 + 2 + 4 + 1 + 2 - 1) As Byte
            data_response(0) = RS_REALMLIST
            'len=uint16
            data_response(2) = (packet_len + 7) \ 256
            data_response(1) = (packet_len + 7) Mod 256
            'request=uint32
            data_response(3) = RealmData(1)
            data_response(4) = RealmData(2)
            data_response(5) = RealmData(3)
            data_response(6) = RealmData(4)
            data_response(7) = Realms_count
            Dim Tmp As Integer
            Dim j As Integer
            Tmp = 8
            For i = 0 To Realms_count - 1
                data_response(Tmp) = 1 '0=Normal 1=PvP 2=PvE
                data_response(Tmp + 1) = 0
                data_response(Tmp + 2) = 0
                data_response(Tmp + 3) = 0
                data_response(Tmp + 4) = Realms(i).Status 'color -> 0=green 1=red 2+=offline
                Tmp = Tmp + 5
                For j = 0 To Len(Realms(i).Name) - 1
                    data_response(Tmp) = Asc(Mid(Realms(i).Name, j + 1, 1))
                    Tmp = Tmp + 1
                Next j
                data_response(Tmp) = 0 '\0
                Tmp = Tmp + 1
                For j = 0 To Len(Realms(i).address) - 1
                    data_response(Tmp) = Asc(Mid(Realms(i).address, j + 1, 1))
                    Tmp = Tmp + 1
                Next j
                data_response(Tmp) = 0 '\0
                Tmp = Tmp + 1
                data_response(Tmp) = 0
                Tmp = Tmp + 1
                data_response(Tmp) = 0
                Tmp = Tmp + 1
                data_response(Tmp) = 0
                Tmp = Tmp + 1
                data_response(Tmp) = 0 'population 99+=hight
                Tmp = Tmp + 1
                data_response(Tmp) = Account(frmCore.sckRS(sckIndex).Tag).AccChars 'players
                Tmp = Tmp + 1
                data_response(Tmp) = 0  'population 1+=medium ?? 0=in list 2+=not displayed
                Tmp = Tmp + 1
                data_response(Tmp) = 0 '?? 0=list of realms 2=wizard
                Tmp = Tmp + 1
            Next i
            data_response(Tmp) = 2  '2=list of realms 0=wizard
            Tmp = Tmp + 1
            data_response(Tmp) = 0
            Tmp = Tmp + 1
            'Log_Packet data_response, "", 1
            frmCore.sckRS(sckIndex).SendData data_response
            
        E = FreeFile
        T = Chr$(34)

        Open App.Path & "\realmlist.txt" For Output As #E
            For i = 0 To UBound(data_response)
                Print #E, data_response(i)
            Next i
        Close #E
    Case Else
        Log "Unknown packet received from Realm Server"
    End Select
End Function

Sub UpdateRealms()
    Dim i As Integer
    'Realms_count = 0
    'For i = 0 To frmMain.lstWSs.ListCount - 1
            Realms(Realms_count).Status = 0
            Realms(Realms_count).address = frmCore.txtWSList.Text
            Realms(Realms_count).Name = frmCore.txtWSName.Text
            Realms(Realms_count).Players = "99"
            Realms_count = Realms_count + 1
    'Next i
    Log Format(Realms_count) & " World Servers loaded"
    frmCore.lblWSonline.Caption = Format(Realms_count)
    frmCore.txtWSList.Text = frmCore.txtWSIp.Text & ":" & frmCore.txtWSPort.Text
    frmCore.txtWSName.Text = "Fusion EMU Server"
End Sub
