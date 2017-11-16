Attribute VB_Name = "Declares"
Option Explicit
Option Base 1

Public Declare Function GetTickCount Lib "kernel32" () As Long
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (pDst As Any, pSrc As Any, ByVal ByteLen As Long)
Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

Public WorldTime As Long

Public Type tLogoutListEntry
    GUID As tGUID
    LogoutTimeLeft As Long
End Type

Public Type tLogoutList
    Count As Long
    Players() As tLogoutListEntry
End Type

Public LogoutList As tLogoutList

Public bChangingLogoutList As Boolean

Public Type tNewCharacter
    Name As String
    Race As Byte
    Class As Byte
    Gender As Byte
    Skin As Byte
    Face As Byte
    hairStyle As Byte
    hairColour As Byte
    FacialHair  As Byte
    OutfitID  As Byte
End Type

Public Type tItemRecordBonus
    BonusStat As Long
    BonusAmount As Long
End Type

Public Type tItemRecordDamage
    MinDamage As Long
    MaxDamage As Long
    DamageType As Long
End Type

Public Type tItemRecordSpell
    SpellID As Long
    SpellTrigger As Long
    SpellCharges As Long
    SpellCooldown As Long
    SpellCategory As Long
    SpellCategoryCooldown As Long
End Type

Public Type tItemRecord
    ItemID As tGUID                                        'ItemID is lower 32bits
    Class As Long
    SubClass As Long
    DisplayName(1 To 4) As String
    DisplayID As Long
    QualityID As Long
    Flags As Long
    BuyPrice As Long
    SellPrice As Long
    InventoryType As Long
    AllowableClass As Long
    AllowableRace As Long
    ItemLevel As Long
    RequiredLevel As Long
    RequiredSkill As Long
    RequiredSkillRank As Long
    MaxCount As Long
    Stackable As Long
    ContainerSlots As Long
    BonusStats(1 To 10) As tItemRecordBonus
    Damage(1 To 5) As tItemRecordDamage
    Resistances(1 To 6) As Long
    Delay As Long
    AmmunitionType As Long
    MaxDurability As Long
    Spells(1 To 5) As tItemRecordSpell
    Bonding As Long
    Description As String
    PageText As Long
    LanguageID As Long
    PageMaterial As Long
    StartQuestID As Long
    LockID As Long
    Material As Long
    SheatheType As Long
End Type

Public Type tItem_Collection
    Items() As tItemRecord
    Count As Long
End Type

Public Type t_CharacterSpell
    IsAnAbility As Boolean
    SpellID As Integer
    SpellSlot As Integer
End Type

Public Type tList_CharacterSpells
    Count As Long
    Spells() As t_CharacterSpell
End Type

Public Type tCharacterRecord
    DeleteFlag As Boolean
    GUID As tGUID
    Name As String
    Race As Byte
    Class As Byte
    Gender As Byte
    Skin As Byte
    Face As Byte
    hairStyle As Byte
    hairColour As Byte
    FacialHair As Byte
    Level As Byte
    Experience As Long
    ZoneID As Long
    MapID As Long
    PositionFacing As Single
    PositionX As Single
    PositionY As Single
    PositionZ As Single
    GuildID As Long
    PetDisplayInfoID As Long
    PetLevel As Long
    PetExperience As Long
    PetCreatureFamilyID As Long
    Inventory(1 To 23) As tGUID
    PackSlots(1 To 16) As tGUID
    BankSlots(1 To 24) As tGUID
    TutorialFlags(1 To 4) As Byte
    Spells As tList_CharacterSpells
End Type

Public Type tList_CharacterRecord
    Characters() As tCharacterRecord
    Count As Long
End Type

Public Type tAccountRecord
    AccountNAme As String
    Password As String
    CharacterGUIDs() As tGUID
    CharactersCount As Long
    DeleteFlag As Boolean
End Type

Public Type tList_AccountsRecord
    Accounts() As tAccountRecord
    Count As Long
End Type

Public Type tPositionValues
    Flags As Long                                          'AddLongToArray msgArray, &H0   'flags. Not sure what these are yet.

    PositionX As Single                                    'AddFloatToArray msgArray, 0    'x
    PositionY As Single                                    'AddFloatToArray msgArray, 0    'y
    PositionZ As Single                                    'AddFloatToArray msgArray, 100  'z
    PositionFacing As Single                               'AddFloatToArray msgArray, 0    'facing

    SpeedWalk As Single                                    'AddFloatToArray msgArray, 2.5    'walk speed
    SpeedRun As Single                                     'AddFloatToArray msgArray, 7  'run speed
    SpeedSwim As Single                                    'AddFloatToArray msgArray, 4.7222           'swim speed
    SpeedTurn As Single                                    'AddFloatToArray msgArray, 3.1514           'turn ratio

    Flags2 As Long                                         'flags. 1 = player, not sure what else

    AttackCycle As Long                                    'AddLongToArray msgArray, &H0   'Attack cycle
    TimerID As Long                                        'AddLongToArray msgArray, &H0   'Timer ID

    VictimID As tGUID                                      'AddU64ToArray msgArray, &H0, &H0           'Victim ID
End Type

Public Type tAccountLoggedIn
    AccountNAme As String
    LastCommandTime As Currency
    LinkNumber As Long
    RecordPosition As Long
    CurrentCharacterGUID As tGUID
    Position As tPositionValues
    LoggedIn As Boolean
End Type

Public Type tList_AccountLoggedIn
    AccountsLoggedIn() As tAccountLoggedIn
    Count As Long
End Type

Public Accounts_LoggedIn As tList_AccountLoggedIn
Public Accounts_Record As tList_AccountsRecord
Public Characters_Record As tList_CharacterRecord

Public Enum enumLoginReturnValues
    Success = 0
    WrongPassword = 1
    AccountCreated = 2
End Enum



Public Sub ShellSort(sort() As Integer)
    On Error GoTo errOut
    Dim numOfElements As Long
    Dim span As Long
    Dim i As Long, j As Long
    Dim temp As Long

    numOfElements = UBound(sort)
    'The ShellSort subprogram sorts the elements of sort()
    'array in descending order and returns it to the calling
    'procedure.

    span = numOfElements \ 2
    Do While span > 0
        For i = span To numOfElements - 1
            j = i - span + 1
            For j = (i - span + 1) To 1 Step -span
                If sort(j) <= sort(j + span) Then Exit For
                'swap array elements that are out of order
                temp = sort(j)
                sort(j) = sort(j + span)
                sort(j + span) = temp
                DoEvents
            Next j
        Next i
        span = span \ 2
    Loop
    Exit Sub
errOut:
    frmMain.PrintOut "Shellsort incorrect"
End Sub

Public Function CombineToLong(Byte1 As Byte, Byte2 As Byte, Byte3 As Byte, Byte4 As Byte) As Long
    CombineToLong = Byte1 + Byte2 * 256 + Byte3 * 256 ^ 2 + Byte4 * 256 ^ 3
End Function
