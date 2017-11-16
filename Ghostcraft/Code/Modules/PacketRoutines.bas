Attribute VB_Name = "REALMPackets"
Option Explicit
Option Base 1

Public Sub REALM_ParsePacket(ReceivedPacket As String, link As Long)
    Dim msgOpcode As Long
    Dim msgByteLength As Long
    Dim StringLength As Long
    Dim tmpAccountAndPassword As String
    Dim AccountNAme As String
    Dim Password As String
    Dim tmpSplit() As String
    Dim retVal As enumLoginReturnValues

    msgByteLength = GetPacketLength(ReceivedPacket)
    msgOpcode = REALM_GetPacketOpcode(ReceivedPacket)

    Select Case msgOpcode
        Case 2
            StringLength = Asc(Mid(ReceivedPacket, 2, 1)) - 1
            tmpAccountAndPassword = Right(ReceivedPacket, StringLength)
            tmpSplit = Split(tmpAccountAndPassword, Chr(13) & Chr(10), , vbTextCompare)
            AccountNAme = tmpSplit(0)
            Password = tmpSplit(1)
            frmMain.PrintOut "REALM:" & AccountNAme & ", " & Password
            retVal = ACCOUNT_CheckPassword(AccountNAme, Password)
            Select Case retVal
                Case Success
                    REALM_SendPasswordHash link
                Case AccountCreated
                    REALM_SendPasswordHash link
                Case WrongPassword
                    REALM_SendErrorCode link, 22
            End Select
        Case 3
            REALM_SendErrorCode link, 0
        Case 16
            REALM_SendListOfServers link
        Case Else
            frmMain.PrintOut "Unknown Message: " & ReceivedPacket
    End Select

End Sub

Public Sub REALM_SendPasswordHash(link As Long)
    Dim msgArray() As Byte, msgLength() As Byte

    AddByteToArray msgArray, &H2
    AddByteToArray msgArray, &H0

    AddLongToArray msgArray, &H0
    AddLongToArray msgArray, &H0
    AddLongToArray msgArray, &H0
    AddLongToArray msgArray, &H0

    AddNetCodeIntegerToArray msgLength, CInt(UBound(msgArray))

    frmMain.serverREALM.Send link, msgLength
    frmMain.serverREALM.Send link, msgArray
End Sub

Public Sub REALM_SendListOfServers(link As Long)
    Dim msgArray() As Byte, msgLength() As Byte

    AddByteToArray msgArray, &H10
    AddByteToArray msgArray, &H1
    AddStringToArray msgArray, "<Ghostcraft> by <And\or>"
    AddStringToArray msgArray, "127.0.0.1:9090"
    AddLongToArray msgArray, &H539

    AddNetCodeIntegerToArray msgLength, CInt(UBound(msgArray))

    frmMain.serverREALM.Send link, msgLength
    frmMain.serverREALM.Send link, msgArray
End Sub

Public Sub REALM_SendErrorCode(link As Long, ErrorCode As Byte)
    Dim msgArray() As Byte, msgLength() As Byte

    AddByteToArray msgLength, &H0
    AddByteToArray msgLength, &H2

    AddByteToArray msgArray, &H3
    AddByteToArray msgArray, CByte(ErrorCode)

    frmMain.serverREALM.Send link, msgLength
    frmMain.serverREALM.Send link, msgArray
End Sub

Public Function GetPacketLength(ByRef ReceivedPacket As String) As Long
    Dim tmpBytes As Long
    Dim tmpSize As Long

    tmpBytes = Asc(Mid(ReceivedPacket, 1, 1)) * 256 + Asc(Mid(ReceivedPacket, 2, 1))
    ReceivedPacket = Right(ReceivedPacket, tmpBytes)
    GetPacketLength = tmpBytes
End Function

Public Function REALM_GetPacketOpcode(ByRef ReceivedPacket As String) As Long
    Dim tmpBytes As Long
    Dim tmpSize As Long

    tmpBytes = Asc(Mid(ReceivedPacket, 1, 1))
    ReceivedPacket = Right(ReceivedPacket, Len(ReceivedPacket) - 1)
    REALM_GetPacketOpcode = tmpBytes
End Function
