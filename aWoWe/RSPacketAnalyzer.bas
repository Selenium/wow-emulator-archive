Attribute VB_Name = "RSPacketAnalyzer"
Option Explicit

Sub Analyze(Index As Integer, data() As Byte)
    System.Log_Packet data, "RS Packet: ", Index
    
    'On Error GoTo ending
    Dim i As Integer
    Dim data_response() As Byte

    Select Case data(0)
    
    Case RS_LOGON_CHALLENGE, RS_RECONNECT_CHALLENGE
    
            Dim packet_size As Integer
            Dim user As Integer
            user = GetFreeUser()
            packet_size = Val("&H" & hex(data(3)) & hex(data(2)))
            'If data(8) = version1 And data(9) = version2 And data(10) = version3 Then
            If (Val("&H" & hex(data(12)) & hex(data(11)))) = rq_build Then
                Users(user).IP = Format(data(29), "0") & "." & Format(data(30), "0") & "." & Format(data(31), "0") & "." & Format(data(32), "0")
                Users(user).Acc = ""
                For i = 0 To data(33) - 1
                    Users(user).Acc = Users(user).Acc + Chr(data(34 + i))
                Next i
                Users(user).Sock = Index
                LOG "    RS," & Index & " [" & Users(user).IP & "] - CMD_AUTH_LOGON_CHALLENGE [" & Users(user).Acc & "]"
                Dim tmpint As Integer
                tmpint = Get_Acc_Data(user)
                frmMain.RS(Index).Tag = (user)
                Select Case tmpint
                    Case 1
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account found [" & Users(user).Acc & "]"
                        Send_Client_LOGON_CHALLENGE Index, user
                    Case 0
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account not found [" & Users(user).Acc & "]"
                        ReDim data_response(1) As Byte
                        data_response(0) = RS_LOGON_PROOF
                        data_response(1) = rserr_bad_user
                        frmMain.RS(Index).SendData data_response
                    Case 2
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account banned [" & Users(user).Acc & "]"
                        ReDim data_response(1) As Byte
                        data_response(0) = RS_LOGON_PROOF
                        data_response(1) = rserr_account_closed
                        frmMain.RS(Index).SendData data_response
                    Case 3
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account prepaid time used [" & Users(user).Acc & "]"
                        ReDim data_response(1) As Byte
                        data_response(0) = RS_LOGON_PROOF
                        data_response(1) = rserr_prepaid_time_used_up
                        frmMain.RS(Index).SendData data_response
                    Case 4
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account already logged in the game [" & Users(user).Acc & "]"
                        ReDim data_response(1) As Byte
                        data_response(0) = RS_LOGON_PROOF
                        data_response(1) = rserr_account_already_logged
                        frmMain.RS(Index).SendData data_response
                    Case Else
                        LOG "    RS," & Index & " [" & Users(user).IP & "] - Account error [" & Users(user).Acc & "]"
                        ReDim data_response(1) As Byte
                        data_response(0) = RS_LOGON_PROOF
                        data_response(1) = rserr_could_not_log_in_try_again_later
                        frmMain.RS(Index).SendData data_response
                    End Select
            
            Else
                'Send BAD_VERSION
                LOG "    RS," & Index & " [" & frmMain.RS(Index).RemoteHostIP & "] - WRONG_VERSION [" & Chr(data(6)) & Chr(data(5)) & Chr(data(4)) & " " & data(8) & "." & data(9) & "." & data(10) & "." & (Val("&H" & hex(data(12)) & hex(data(11)))) & " " _
                                    & Chr(data(15)) & Chr(data(14)) & Chr(data(13)) & " " & Chr(data(19)) & Chr(data(18)) & Chr(data(17)) & " " & Chr(data(24)) & Chr(data(23)) & Chr(data(22)) & Chr(data(21)) & "]"
                ReDim data_response(1) As Byte
                data_response(0) = RS_LOGON_PROOF
                data_response(1) = rserr_bad_client_version
                frmMain.RS(Index).SendData data_response
            End If
            
    Case RS_LOGON_PROOF, RS_RECONNECT_PROOF
            Dim a As String
            Dim M1 As String
            'Dim CRC_Hash As String
            a = ""
            M1 = ""
            'CRC_Hash = ""
            For i = 1 To 32
                If Len(hex(data(i))) < 2 Then
                    a = a + "0" + hex(data(i))
                Else
                    a = a + hex(data(i))
                End If
            Next i
            For i = 33 To 33 + 19
                If Len(hex(data(i))) < 2 Then
                    M1 = M1 + "0" + hex(data(i))
                Else
                    M1 = M1 + hex(data(i))
                End If
            Next i
            'For i = 53 To 53 + 19
            '    If Len(hex(Data(i))) < 2 Then
            '        CRC_Hash = CRC_Hash + "0" + hex(Data(i))
            '    Else
            '        CRC_Hash = CRC_Hash + hex(Data(i))
            '    End If
            'Next i
            LOG "    RS," & Index & " [" & Users(frmMain.RS(Index).Tag).IP & "] - CMD_AUTH_LOGON_PROOF [" & Users(frmMain.RS(Index).Tag).Acc & "]"
            Send_Client_LOGON_PROOF a, M1, Index, frmMain.RS(Index).Tag
            
            
    Case RS_UPDATESRV
            LOG "    RS," & Index & " [" & Users(frmMain.RS(Index).Tag).IP & "] - UPDATESRV"
            System.Log_Packet data, "Unknown packet received from Realm Server", Index
            
    Case RS_REALMLIST
            LOG "    RS," & Index & " [" & Users(frmMain.RS(Index).Tag).IP & "] - CMD_REALM_LIST"
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
            data_response(3) = data(1)
            data_response(4) = data(2)
            data_response(5) = data(3)
            data_response(6) = data(4)
            data_response(7) = Realms_count
            Dim tmp As Integer
            Dim j As Integer
            tmp = 8
            For i = 0 To Realms_count - 1
                data_response(tmp) = 1 '0=Normal 1=PvP 2=PvE
                data_response(tmp + 1) = 0
                data_response(tmp + 2) = 0
                data_response(tmp + 3) = 0
                data_response(tmp + 4) = Realms(i).Status 'color -> 0=green 1=red 2+=offline
                tmp = tmp + 5
                For j = 0 To Len(Realms(i).Name) - 1
                    data_response(tmp) = Asc(Mid(Realms(i).Name, j + 1, 1))
                    tmp = tmp + 1
                Next j
                data_response(tmp) = 0 '\0
                tmp = tmp + 1
                For j = 0 To Len(Realms(i).address) - 1
                    data_response(tmp) = Asc(Mid(Realms(i).address, j + 1, 1))
                    tmp = tmp + 1
                Next j
                data_response(tmp) = 0 '\0
                tmp = tmp + 1
                data_response(tmp) = 0
                tmp = tmp + 1
                data_response(tmp) = 0
                tmp = tmp + 1
                data_response(tmp) = 0
                tmp = tmp + 1
                data_response(tmp) = 0 'population 99+=hight
                tmp = tmp + 1
                data_response(tmp) = 3 'players
                tmp = tmp + 1
                data_response(tmp) = 0  'population 1+=medium ?? 0=in list 2+=not displayed
                tmp = tmp + 1
                data_response(tmp) = 0 '?? 0=list of realms 2=wizard
                tmp = tmp + 1
            Next i
            data_response(tmp) = 2  '2=list of realms 0=wizard
            tmp = tmp + 1
            data_response(tmp) = 0
            tmp = tmp + 1
            'Log_Packet data_response, "", 1
            frmMain.RS(Index).SendData data_response
    Case Else
    
        System.Log_Packet data, "Unknown packet received from Realm Server", Index
    End Select
    Exit Sub
ending:
        System.Log_Packet data, "Bad packet received from Realm Server", Index
End Sub

Function Get_Acc_Data(user As Integer) As Integer
    Dim i As Integer
    For i = 0 To Users_Count - 1
        If Users(i).Acc = Users(user).Acc And user <> i Then
            Get_Acc_Data = 4
            Exit Function
        End If
    Next i

    If Dir(App.Path & "\accounts\" & Users(user).Acc) <> "" Then
        Get_Acc_Data = 1
        Dim TextLine As String
        Dim FileNumber
        Dim temp() As String
        FileNumber = FreeFile
        Users(user).Chars = 0
        Open (App.Path & "\accounts\" & Users(user).Acc) For Input As #FileNumber
        Do While Not EOF(FileNumber)
            Line Input #FileNumber, TextLine
            temp = Split(Trim(TextLine), "=")
            If UCase(temp(0)) = "PASSWORD" Then Users(user).Pass = temp(1)
            If UCase(temp(0)) = "PLEVEL" Then Users(user).PLevel = Int(temp(1))
            If UCase(temp(0)) = "CHAR" Then
                ReDim Preserve Users(user).Char(Users(user).Chars + 1)
                Users(user).Char(Users(user).Chars) = temp(1)
                Users(user).Chars = Users(user).Chars + 1
            End If
            If UCase(temp(0)) = "STATUS" Then
                'acc banned
                If Val(temp(1)) = 2 Then
                    Get_Acc_Data = 2
                    Exit Function
                End If
                'prepaid time used
                If Val(temp(1)) = 3 Then
                    Get_Acc_Data = 3
                    Exit Function
                End If
            End If
        Loop
        Close #FileNumber
    Else
        Get_Acc_Data = 0
    End If
    '0 - not exist; 1 - valid; 2 - banned; 3 - prepaid time used; 4 - already logged
End Function

Sub UpdateRealms()
    Dim i As Integer
    Realms_count = 0
    'For i = 0 To frmMain.lstWSs.ListCount - 1
            If frmMain.chkOnline = False Then
                Realms(Realms_count).Status = 2
            Else
                Realms(Realms_count).Status = 0
            End If
            Realms(Realms_count).address = frmMain.txtWSInput
            Realms(Realms_count).Name = frmWSSetup.txtWSName
            Realms(Realms_count).Players = "99"
            Realms_count = Realms_count + 1
    'Next i
    frmMain.lblStatus = Format(Realms_count) & " World Servers selected"
End Sub


Function GetFreeUser() As Integer
    Dim i As Integer
    For i = 0 To Users_Count - 1
        If Users(i).Acc = "" Then
            GetFreeUser = i
            GoTo reset_state
        End If
    Next i
    
    Users_Count = Users_Count + 1
    ReDim Preserve Users(Users_Count + 1)
    GetFreeUser = Users_Count
    i = Users_Count
reset_state:
    Users(i).WS = False
    Users(i).Chars = 0
    Users(i).PLevel = 0
    Users(i).Pass = 0
    Users(i).Key(0) = 0
    Users(i).Key(1) = 0
    Users(i).Key(2) = 0
    Users(i).Key(3) = 0
    '...
End Function
