Attribute VB_Name = "modSystem"
'Core hearth will be here ;)
Option Explicit

'realmlist vars
    Type TRealmInfo
        address As String
        Name As String
        Players As String
        Status As Byte
    End Type
    
Global AccountFileNo As Integer
Global CharFileNo As Integer
Global ItemFileNo As Integer
Global MAX_CHARACTERS_PER_USER As Byte

Sub LoadCore()
'We begin the Sockets index and an array for used sockets
ReDim Preserve sckRSUsed(1)
ReDim Preserve sckWSUsed(1)
ReDim Preserve sckHTUsed(1)
ReDim Preserve Account(1)
Load frmCore.sckRS(1)
Load frmCore.sckWS(1)
Load frmCore.sckHT(1)
'This are indexes for SRP6 calculations
ReDim F(20, 4095), sg(20), l(20)
'RealmServer default values
frmCore.txtRSIp.Text = frmCore.sckRS(0).LocalIP
frmCore.txtWSIp.Text = frmCore.sckWS(0).LocalIP
frmCore.txtWSList.Text = frmCore.txtWSIp.Text & ":" & frmCore.txtWSPort.Text
frmCore.txtHTTPIp.Text = frmCore.sckHT(0).LocalIP
'We log current version and set caption & version ;)
Log "vWoW Emu v" & App.Major & "." & App.Minor & "." & App.Revision & " based on Fusion by UniX"
Log "----"
frmCore.Caption = "vWoW v" & App.Major & "." & App.Minor & "." & App.Revision
'We begin reading Account data
AccountFileNo = FreeFile
ReDim Preserve Account(0)
ReDim Preserve Items(0)
Log "Loading Accounts and Characters..."
LoadAccounts False
DoEvents
Log "Done."
    MAX_CHARACTERS_PER_USER = 10
    ReDim PlayerCharacters(1)
End Sub
