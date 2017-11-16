Attribute VB_Name = "System"
Option Explicit




Function Reverse(temp As String) As String
    Dim i As Integer
    Dim output As String
    output = ""
    For i = Len(temp) - 1 To 1 Step -2
        output = output + Mid(temp, i, 2)
    Next i
    Reverse = output
End Function

Function HexToStr(hex As String) As String
    Dim i As Integer
    Dim temp1 As String
    temp1 = ""
    For i = 1 To Len(hex) Step 2
        temp1 = temp1 + Chr(Val("&H" & Mid(hex, i, 2)))
    Next i
    HexToStr = temp1
End Function

Sub LOG(text As String)
    frmLog.Text2.text = frmLog.Text2.text + vbNewLine + "[" & Format(Time, "hh:mm:ss") & "] " & text
    frmLog.Text2.SelStart = Len(frmLog.Text2.text)
    Print #109, text
End Sub

Sub Log_Packet(data() As Byte, who As String, Index As Integer)
    Dim LOG As String
    Dim i As Integer
    frmLog.Text2.text = frmLog.Text2.text + vbNewLine + who & "," & Index & ",rsvData as Byte ="
    LOG = who & "," & Index & ",rsvData as Byte ="
    For i = 0 To UBound(data)
        If i Mod 2 = 1 Then
            If Len(hex(data(i))) = 1 Then
                frmLog.Text2.text = frmLog.Text2.text + "0" + hex(data(i))
                LOG = LOG + "0" + hex(data(i))
            Else
                frmLog.Text2.text = frmLog.Text2.text + "" + hex(data(i))
                LOG = LOG + hex(data(i))
            End If
        Else
            If Len(hex(data(i))) = 1 Then
                frmLog.Text2.text = frmLog.Text2.text + " 0" + hex(data(i))
                LOG = LOG + " 0" + hex(data(i))
            Else
                frmLog.Text2.text = frmLog.Text2.text + " " + hex(data(i))
                LOG = LOG + " " + hex(data(i))
            End If
        End If
    Next i
    frmLog.Text2.text = frmLog.Text2.text + vbNewLine + who & "," & Index & ",rsvData as Char = "
    LOG = LOG + vbNewLine + who & "," & Index & ",rsvData as Char = "
    For i = 0 To UBound(data)
        frmLog.Text2.text = frmLog.Text2.text + Chr(data(i))
        LOG = LOG + Chr(data(i))
        If i Mod 2 = 1 Then frmLog.Text2.text = frmLog.Text2.text + " "
    Next i
    frmLog.Text2.SelStart = Len(frmLog.Text2.text)
    Print #109, LOG
End Sub


Sub Initialize()
    ReDim Preserve OpenSockets(1)
    ReDim Preserve OpenSocketsWS(1)
    ReDim Preserve Users(1)
    Users_Count = 0
    Load frmMain.RS(1)
    Load frmWSSetup.WS(1)
    OpenSockets(0) = True
    OpenSockets(1) = False
    OpenSocketsWS(0) = True
    OpenSocketsWS(1) = False
    'rq_build = 4222    '1.2.4 enUS
    'rq_build = 4297    '1.3.1 enUS
    rq_build = 4375     '1.4.2 enUS
    RSFunctions.LOGON_CHALLENGE_Working = False
    RSFunctions.LOGON_PROOF_Working = False
    
    MAX_CHARACTERS_PER_USER = 10
    ReDim PlayerCharacters(1)
    
    Open App.Path & "\Logs\" & App.EXEName & Format(Date, " dd-mm-yyyy") & Format(Time, " hh-mm") & ".log" For Output As #109
End Sub

Sub Terminate()
    Close #109
End Sub

Function FormatHEX(hex As String, length As Byte) As String
    If Len(hex) < length Then
        FormatHEX = String(length - Len(hex), "0") & hex
    End If
End Function

