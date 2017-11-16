Attribute VB_Name = "modAccountSystem"
Option Explicit

'Basic Account system by MakinaX, SRP6 data temporary by aWoWe

Type TItemsEquiped
    ItemID As Long
    DisplayID As Byte
End Type
Type TChar
    GUID As String
    Name As String
    Race As Byte
    Class As Byte
    Gender As Byte
    Skin As Byte
    Face As Byte
    HairStyle As Byte
    HairColor As Byte
    FacialHair As Byte
    OutfitID As Byte    'not used!!
    Level As Byte
    ZoneID As Long
    MapID As Long
    positionX As Single
    positionY As Single
    positionZ As Single
    GuildID As Long
    Rest As Byte
    Online As Boolean
    PetInfo As Long
    PetLevel As Long
    PetFamilyID As Long
    ItemsEquiped(1 To 20) As TItemsEquiped
End Type

Type TOnline
    GUID As String
    Name As String
End Type

Type TAccount
'Account Vars
AccID As String
AccName As String
AccPassword As String
AccPlevel As Byte
AccChar(1 To 10) As TChar
AccChars As Byte
AccStatus As Integer
AccIp As String
'Temporal data for SPR6 (temporary taken from aWoWe)
V As String
PublicB As String
'Connexion vars
SS_Hash As String
bSS_Hash(40) As Byte
'Encode/Decode
Key(3) As Byte
K(39) As Byte
End Type

Global Users_Count As Byte
Public Account() As TAccount
Public OnlinePlayers() As TOnline

'Function that will read/save all the account information
Sub LoadAccounts(Save As Boolean)
'Vars
Dim intLine As Integer
Dim intAccountID As Integer
Dim intCharID As Integer
Dim intCharGUID As String
Dim intChar As Integer
Dim strLine As String
Dim varTemp As Variant

If Save = False Then
    intChar = 1
    AccountFileNo = FreeFile
    Open App.Path & "\saves\accounts.save" For Input As AccountFileNo
    Do While Not EOF(AccountFileNo)
    Line Input #AccountFileNo, strLine
    intLine = intLine + 1
    If ContainStr(strLine, "=") Then
        varTemp = Split(Trim(strLine), "=")
        Select Case varTemp(0)
            Case "[ID"
            If UBound(Account) < Mid(varTemp(1), 1, Len(varTemp(1)) - 1) Then ReDim Preserve Account(Mid(varTemp(1), 1, Len(varTemp(1)) - 1))
            intAccountID = Mid(varTemp(1), 1, Len(varTemp(1)) - 1)
            Account(intAccountID).AccID = intAccountID
            Case "NAME"
            Account(intAccountID).AccName = varTemp(1)
            Log "Loading account [" & Account(intAccountID).AccName & "]"
            Case "PASSWORD"
            Account(intAccountID).AccPassword = varTemp(1)
            Case "PLEVEL"
            Account(intAccountID).AccPlevel = varTemp(1)
            Case "CHARS"
            Account(intAccountID).AccChars = varTemp(1)
            'MakinaX:WTF is this my best solution? I need a new brain
            Case ("CHAR" & intChar)
            If varTemp(1) <> "" Then
            Account(intAccountID).AccChar(intChar).GUID = varTemp(1)
            End If
            intChar = intChar + 1
            Case "STATUS"
            If varTemp(1) = 1 Then varTemp(1) = 0
            Account(intAccountID).AccStatus = varTemp(1)
            Case "IP"
            Account(intAccountID).AccIp = varTemp(1)
        End Select
    End If
    Loop
    Close AccountFileNo
    
    CharFileNo = FreeFile
    Open App.Path & "\saves\characters.save" For Input As CharFileNo
    Do While Not EOF(CharFileNo)
    Line Input #CharFileNo, strLine
    intLine = intLine + 1
    If ContainStr(strLine, "=") Then
        varTemp = Split(Trim(strLine), "=")
        Select Case varTemp(0)
            Case "[ID"
            intCharGUID = Mid(varTemp(1), 1, Len(varTemp(1)) - 1)
            Case "CHARID"
            intCharID = varTemp(1)
            Case "ACCOUNT"
            intAccountID = varTemp(1)
            Case "NAME"
            Account(intAccountID).AccChar(intCharID).GUID = intCharGUID
            Account(intAccountID).AccChar(intCharID).Name = varTemp(1)
            Log "Loading Character [" & Account(intAccountID).AccChar(intCharID).Name & "]"
            Case "CLASS"
            Account(intAccountID).AccChar(intCharID).Class = varTemp(1)
            Case "RACE"
            Account(intAccountID).AccChar(intCharID).Race = varTemp(1)
            Case "GENDER"
            Account(intAccountID).AccChar(intCharID).Gender = varTemp(1)
            Case "SKIN"
            Account(intAccountID).AccChar(intCharID).Skin = varTemp(1)
            Case "FACE"
            Account(intAccountID).AccChar(intCharID).Face = varTemp(1)
            Case "HAIRSTYLE"
            Account(intAccountID).AccChar(intCharID).HairStyle = varTemp(1)
            Case "HAIRCOLOR"
            Account(intAccountID).AccChar(intCharID).HairColor = varTemp(1)
            Case "FACIALHAIR"
            Account(intAccountID).AccChar(intCharID).FacialHair = varTemp(1)
            Case "OUTFITID"
            Account(intAccountID).AccChar(intCharID).OutfitID = varTemp(1)
            Case "GUILDID"
            Account(intAccountID).AccChar(intCharID).GuildID = varTemp(1)
            Case "LEVEL"
            Account(intAccountID).AccChar(intCharID).Level = varTemp(1)
            Case "MAPID"
            Account(intAccountID).AccChar(intCharID).MapID = varTemp(1)
            Case "POSITIONX"
            Account(intAccountID).AccChar(intCharID).positionX = varTemp(1)
            Case "POSITIONY"
            Account(intAccountID).AccChar(intCharID).positionY = varTemp(1)
            Case "POSITIONZ"
            Account(intAccountID).AccChar(intCharID).positionZ = varTemp(1)
            Case "ZONEID"
            Account(intAccountID).AccChar(intCharID).ZoneID = varTemp(1)
            Case "REST"
            Account(intAccountID).AccChar(intCharID).Rest = varTemp(1)
            Case "PETFAMILYID"
            Account(intAccountID).AccChar(intCharID).PetFamilyID = varTemp(1)
            Case "PETINFO"
            Account(intAccountID).AccChar(intCharID).PetInfo = varTemp(1)
            Case "PETLEVEL"
            Account(intAccountID).AccChar(intCharID).PetLevel = varTemp(1)
        End Select
    End If
    Loop
    Close CharFileNo
    
    Log "Loaded in " & (frmCore.TimeUsed) & " ms"
    frmCore.timSaveTime.Enabled = False
    frmCore.TimeUsed = 0
Else
    'Ok this may seem crappy but is a save function for accounts
    'that will earn us from adding much more vars
    
    'Vars
    Dim intLastID As Integer
    Dim i, j As Integer
    
    AccountFileNo = FreeFile
    Open App.Path & "\saves\accounts.save" For Output As AccountFileNo
    intLastID = 0
    For i = LBound(Account) To UBound(Account)
    intChar = 0
    If Account(i).AccID <> "" Then
        Log "Saving account [" & Account(i).AccName & "]"
        'ID's optimizations, to make For shorter
        If (intLastID <> 0) And (intLastID - Account(i).AccID <> -1) Then
            intLastID = intLastID + 1
            Account(i).AccID = intLastID
        End If
    Print #AccountFileNo, "[ID=" & (Account(i).AccID) & "]"
    intLastID = Account(i).AccID
    Print #AccountFileNo, "NAME=" & (Account(i).AccName)
    Print #AccountFileNo, "PASSWORD=" & (Account(i).AccPassword)
    Print #AccountFileNo, "PLEVEL=" & (Account(i).AccPlevel)
    For j = 1 To 10
        If Account(i).AccChar(j).GUID <> "" And Account(i).AccChar(j).GUID <> "0" Then
            Print #AccountFileNo, "CHAR" & j & "=" & (Account(i).AccChar(j).GUID)
            intChar = intChar + 1
        Else
            Print #AccountFileNo, "CHAR" & j & "="
        End If
    Next j
    Print #AccountFileNo, "CHARS=" & intChar
    If Account(i).AccStatus = 1 Then Account(i).AccStatus = 0
    Print #AccountFileNo, "STATUS=" & (Account(i).AccStatus)
    Print #AccountFileNo, "IP=" & (Account(i).AccIp)
        If i <> UBound(Account) Then
            Print #AccountFileNo,
        End If
    End If
    Next i
    Close AccountFileNo
    
    CharFileNo = FreeFile
    Open App.Path & "\saves\characters.save" For Output As CharFileNo
        For i = LBound(Account) To UBound(Account)
            If Account(i).AccChars > 0 Then
                For j = 1 To Account(i).AccChars
                  If Account(i).AccChar(j).Name <> "" Then
                    Log "Saving character [" & Account(i).AccChar(j).Name & "]"
                    Print #CharFileNo, "[ID=" & (Account(i).AccChar(j).GUID) & "]"
                    Print #CharFileNo, "CHARID=" & (j)
                    Print #CharFileNo, "ACCOUNT=" & (i)
                    Print #CharFileNo, "NAME=" & (Account(i).AccChar(j).Name)
                    Print #CharFileNo, "RACE=" & (Account(i).AccChar(j).Race)
                    Print #CharFileNo, "CLASS=" & (Account(i).AccChar(j).Class)
                    Print #CharFileNo, "GENDER=" & (Account(i).AccChar(j).Gender)
                    Print #CharFileNo, "SKIN=" & (Account(i).AccChar(j).Skin)
                    Print #CharFileNo, "FACE=" & (Account(i).AccChar(j).Face)
                    Print #CharFileNo, "HAIRSTYLE=" & (Account(i).AccChar(j).HairStyle)
                    Print #CharFileNo, "HAIRCOLOR=" & (Account(i).AccChar(j).HairColor)
                    Print #CharFileNo, "FACIALHAIR=" & (Account(i).AccChar(j).FacialHair)
                    Print #CharFileNo, "OUTFITID=" & (Account(i).AccChar(j).OutfitID)
                    Print #CharFileNo, "GUILDID=" & (Account(i).AccChar(j).GuildID)
                    Print #CharFileNo, "LEVEL=" & (Account(i).AccChar(j).Level)
                    Print #CharFileNo, "MAPID=" & (Account(i).AccChar(j).MapID)
                    Print #CharFileNo, "POSITIONX=" & (Account(i).AccChar(j).positionX)
                    Print #CharFileNo, "POSITIONY=" & (Account(i).AccChar(j).positionY)
                    Print #CharFileNo, "POSITIONZ=" & (Account(i).AccChar(j).positionZ)
                    Print #CharFileNo, "ZONEID=" & (Account(i).AccChar(j).ZoneID)
                    Print #CharFileNo, "REST=" & (Account(i).AccChar(j).Rest)
                    Print #CharFileNo, "PETFAMILYID=" & (Account(i).AccChar(j).PetFamilyID)
                    Print #CharFileNo, "PETINFO=" & (Account(i).AccChar(j).PetInfo)
                    Print #CharFileNo, "PETLEVEL=" & (Account(i).AccChar(j).PetLevel)
                    Print #CharFileNo, ""
                  End If
                Next j
            End If
        Next i
    Close CharFileNo
    
    Log "Saved in " & (frmCore.TimeUsed) & " ms"
    frmCore.timSaveTime.Enabled = False
    frmCore.TimeUsed = 0
    Exit Sub
End If
End Sub

'Simple function to fill fields with account data
Function AccountManagerUpdateFields(AccountID As Integer)

frmAccountManager.txtAccountManagerName.Text = Account(AccountID).AccName
frmAccountManager.txtAccountManagerPassword.Text = Account(AccountID).AccPassword
frmAccountManager.txtAccountManagerPlevel.Text = Account(AccountID).AccPlevel
frmAccountManager.txtAccountManagerIP.Text = Account(AccountID).AccIp

If Account(AccountID).AccStatus = 2 Then
        frmAccountManager.chkAccountManagerStatus.value = 1
Else
        frmAccountManager.chkAccountManagerStatus.value = 0
End If

End Function

'Simple function to fill fields with account data
Function CharacterManagerUpdateFields(AccountID As Integer, CharID As Integer)

frmCharacterManager.txtAccountManagerName.Text = Account(AccountID).AccChar(CharID).Name
frmCharacterManager.txtAccountManagerLevel.Text = Account(AccountID).AccChar(CharID).Level
frmCharacterManager.txtAccountManagerClass.Text = Account(AccountID).AccChar(CharID).Class
frmCharacterManager.txtAccountManagerRace.Text = Account(AccountID).AccChar(CharID).Race
 If Account(AccountID).AccChar(CharID).Gender = True Then
frmCharacterManager.txtAccountManagerGender.value = 1
 Else
frmCharacterManager.txtAccountManagerGender.value = 0
 End If
frmCharacterManager.txtAccountManagerSkin.Text = Account(AccountID).AccChar(CharID).Skin
frmCharacterManager.txtAccountManagerFace.Text = Account(AccountID).AccChar(CharID).Face
frmCharacterManager.txtAccountManagerHairStyle.Text = Account(AccountID).AccChar(CharID).HairStyle
frmCharacterManager.txtAccountManagerHairColor.Text = Account(AccountID).AccChar(CharID).HairColor
frmCharacterManager.txtAccountManagerFacialHair.Text = Account(AccountID).AccChar(CharID).FacialHair
frmCharacterManager.txtAccountManagerGuildID.Text = Account(AccountID).AccChar(CharID).GuildID
frmCharacterManager.txtAccountManagerOutfitID.Text = Account(AccountID).AccChar(CharID).OutfitID
frmCharacterManager.txtAccountManagerZoneID.Text = Account(AccountID).AccChar(CharID).ZoneID
frmCharacterManager.txtAccountManagerMapID.Text = Account(AccountID).AccChar(CharID).MapID
frmCharacterManager.txtAccountManagerPosX.Text = Account(AccountID).AccChar(CharID).positionX
frmCharacterManager.txtAccountManagerPosY.Text = Account(AccountID).AccChar(CharID).positionY
frmCharacterManager.txtAccountManagerPosZ.Text = Account(AccountID).AccChar(CharID).positionZ
frmCharacterManager.txtCharacterManagerGuid.Text = Account(AccountID).AccChar(CharID).GUID

End Function

'Another function to update account data
Function CharacterManagerSaveFields(AccountID As Integer, CharID As Integer)

If frmCharacterManager.txtAccountManagerName.Text = "" Then Exit Function

If Account(AccountID).AccChar(CharID).GUID = 0 Then
    Account(AccountID).AccChar(CharID).GUID = FormatHEX(frmCharacterManager.txtAccountManagerName.Text, 8)
End If

Account(AccountID).AccChar(CharID).Name = frmCharacterManager.txtAccountManagerName.Text
Account(AccountID).AccChar(CharID).Level = frmCharacterManager.txtAccountManagerLevel.Text
Account(AccountID).AccChar(CharID).Class = frmCharacterManager.txtAccountManagerClass.Text
Account(AccountID).AccChar(CharID).Race = frmCharacterManager.txtAccountManagerRace.Text
 If frmCharacterManager.txtAccountManagerGender.value = 1 Then
Account(AccountID).AccChar(CharID).Gender = True
 Else
Account(AccountID).AccChar(CharID).Gender = False
 End If
Account(AccountID).AccChar(CharID).Skin = frmCharacterManager.txtAccountManagerSkin.Text
Account(AccountID).AccChar(CharID).Face = frmCharacterManager.txtAccountManagerFace.Text
Account(AccountID).AccChar(CharID).HairStyle = frmCharacterManager.txtAccountManagerHairStyle.Text
Account(AccountID).AccChar(CharID).HairColor = frmCharacterManager.txtAccountManagerHairColor.Text
Account(AccountID).AccChar(CharID).FacialHair = frmCharacterManager.txtAccountManagerFacialHair.Text
Account(AccountID).AccChar(CharID).GuildID = frmCharacterManager.txtAccountManagerGuildID.Text
Account(AccountID).AccChar(CharID).OutfitID = frmCharacterManager.txtAccountManagerOutfitID.Text
Account(AccountID).AccChar(CharID).ZoneID = frmCharacterManager.txtAccountManagerZoneID.Text
Account(AccountID).AccChar(CharID).MapID = frmCharacterManager.txtAccountManagerMapID.Text
Account(AccountID).AccChar(CharID).positionX = frmCharacterManager.txtAccountManagerPosX.Text
Account(AccountID).AccChar(CharID).positionY = frmCharacterManager.txtAccountManagerPosY.Text
Account(AccountID).AccChar(CharID).positionZ = frmCharacterManager.txtAccountManagerPosZ.Text
Account(AccountID).AccChar(CharID).GUID = frmCharacterManager.txtCharacterManagerGuid.Text
Account(AccountID).AccChars = Account(AccountID).AccChars + 1

End Function

'Another function to update account data
Function AccountManagerSaveFields(AccountID As Integer)
Account(AccountID).AccName = frmAccountManager.txtAccountManagerName.Text
Account(AccountID).AccPassword = frmAccountManager.txtAccountManagerPassword.Text
Account(AccountID).AccPlevel = frmAccountManager.txtAccountManagerPlevel.Text

If frmAccountManager.chkAccountManagerStatus.value = 1 Then
    Account(AccountID).AccStatus = 2
Else
    Account(AccountID).AccStatus = 1
End If

End Function

'This function identifies an Account ID with his name, else
'returns -1
Function intAccountID(strAccountName As String) As Integer
Dim i As Integer
For i = 0 To UBound(Account)
If Account(i).AccName = strAccountName Then
    intAccountID = i
    Exit Function
End If
Next i
intAccountID = -1
End Function

'This function returns the status of an account
'Possible status are:
Function intAccountStatus(intAccountID As Integer) As Integer
intAccountStatus = Account(intAccountID).AccStatus
End Function

'
