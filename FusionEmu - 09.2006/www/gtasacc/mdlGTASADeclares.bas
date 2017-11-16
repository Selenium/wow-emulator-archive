Attribute VB_Name = "mdlGTASADeclares"
Option Explicit
'Types and variables for GTASA / Console Buffers:
'GTASA Base Adresses:
Type GTASABaseAdresses
    PlayerAdr As Long               'DWord Ptr
    PlayerAdr2 As Long              'DWord Ptr
    CurrCarAdr As Long              'DWord Ptr
    Msg1Adr As Long                 'AsciiA
    MoneyAdr As Long                'DWord
    FatStatAdr As Long              'Float
    StaminaStatAdr As Long          'Float
    MuscleStatAdr As Long           'Float
    MaxHealthStatAdr As Long        'Float
    EnergyStatAdr As Long           'DWord
    WeaponProfStatAdr(9) As Long    'Float
    HotCoffeeAdr As Long            'Byte (bit flip)
    VehicleProfAdr(3) As Long       'Car,Bike,Cycle,Pilot DWord
    LungCapacityAdr As Long         'Float
    GamblingStatAdr As Long         'Float
    OpenedIslandsAdr As Long        'DWord (0 to 4 islands)
    GFStatAdr(5) As Long            'DWord (0-100) 'Denise/Michelle/Helena/Katie/Barbara/Millie
    GFProgressAdr(5) As Long        'DWord (0-100) 'Denise/Michelle/Helena/Katie/Barbara/Millie
    CheatCountAdr As Long           'DWord
    CheatStatAdr As Long            'DWord
    cNeverWantedAdr  As Long        'Byte
    cNeverGetHungryAdr  As Long     'Byte
    cInfHealthAdr  As Long          'Byte
    cInfOxygenAdr  As Long          'Byte
    cInfAmmoAdr  As Long            'Byte
    cInfRunAdr As Long              'Byte
    cFireproofAdr As Long           'Byte
    cMegaPunchAdr  As Long          'Byte
    cMegaJumpAdr  As Long           'Byte
    cMaxRespectAdr  As Long         'Byte
    cMaxSexAppealAdr  As Long       'Byte
    cFastCarsAdr  As Long           'Byte
    cCheapCarsAdr  As Long          'Byte
    cTankModeAdr As Long            'Byte
    cCheatsAdr(20) As Long          'Byte'Never Wanted=0'Never Get Hungry=1'Infinite Health=2'Infinite Oxygen=3'Infinite Ammo=4'Tank Mode=5
                                         'Mega Punch=6'Mega Jump=7'Max Respect=8'Max Sex Appeal=9'Fast Cars=10'Cheap Cars=11'Infinite Run=12'Fireproof=13
                                         'Perfect Handling=14'Decreased Traffic=15'Huge Bunny Hop=16'Cars Have Nitro=17'Boats can Fly=18'Cars can Fly=19
    DaysInGameAdr  As Long          'Long
    CurrHourAdr  As Long            'Byte
    CurrMinuteAdr  As Long          'Byte
    CurrWeekdayAdr  As Long         'Byte
    GameSpeedMsAdr As Long          'Long
    GameSpeedPctAdr As Long         'Float
    CodeInjectJumpAdr As Long
    CodeInjectCodeAdr As Long
    CodeInjectJump_OneHitKillAdr As Long
    CodeInjectCode_OneHitKillAdr As Long
    CodeInjectNOP_FreezeTimerUpAdr As Long
    CodeInjectNOP_FreezeTimerDownAdr As Long
    CarSpawnAdr As Long
    WeaponSpawnAdr(11) As Long
    WeatherLockAdr As Long
    WeatherToGoAdr As Long
    WeatherCurrentAdr As Long
End Type
Global GTASABaseAdr As GTASABaseAdresses

'GTASA Location Buffer 3x4 bytes:
Type GTASALocation '12 Bytes
    sngXcoord As Single
    sngYcoord As Single
    sngZcoord As Single
End Type
Global GTASAWarpTrailerOffset(3) As GTASALocation
Global GTASAWarpBikeOffset(4) As GTASALocation
Global GTASAWarpCarOffset(3) As GTASALocation
Global GTASAWarpReadOffset As GTASALocation
Global GTASAWarpTrailerPosOffset As GTASALocation

Global GTASAWarpCurrPos As GTASALocation
Global GTASAWarpDetachablesLoc As GTASALocation
Global GTASAWarpPlayerLoc As GTASALocation
Global GTASAWarpPlayerLocBefore As GTASALocation
Global GTASACarPosition As GTASALocation
Global GTASAPlayerPosition As GTASALocation

'GTASA Speed Buffer 3x4 Bytes:
Type GTASASpeed '12 Bytes
    sngXSpeed As Single
    sngYSpeed As Single
    sngZSpeed As Single
End Type
Global speedBuffer As GTASASpeed
Global speedHookBuffer As GTASASpeed
Global zeroSpeed As GTASASpeed
Global speedWriteBuffer As GTASASpeed
Global KickStartSpeeds(7) As GTASASpeed
Global speedExecWriteBuffer As GTASASpeed
Global speedConsoleBuffer As GTASASpeed

'GTASA Spin Buffer 3x4 Bytes
Type GTASASpin '12 Bytes
    sngXSpin As Single
    sngYSpin As Single
    sngZSpin As Single
End Type
Global spinBuffer As GTASASpin
Global spinHookBuffer As GTASASpin
Global zeroSpin As GTASASpin
Global spinWriteBuffer As GTASASpin
Global spinExecWriteBuffer As GTASASpin
Global spinDelayedWriteBuffer As GTASASpin

'GTASA Position/Placement Data
Type GTASAPosData '7x4= 28 Bytes
    sngXGrad As Single
    sngYGrad As Single
    sngZgrad As Single
    sngzReserve1 As Single
    sngXlooking As Single
    sngYlooking As Single
    sngZlooking As Single
End Type
Global GTASACarPlacements(7) As GTASAPosData '8 different car placements N NE E SE S SW W NW
Global carFlipPlacement As GTASAPosData
Private playerFlipPlacement As GTASAPosData
Global carFlipConsoleBuffer As GTASAPosData

'GTASA Garage Parking Coordinates:
Type GTASAGarage '16x4= 64 Bytes
    sngXcoord As Single
    sngYcoord As Single
    sngZcoord As Single
    lngHandling As Long
    intSpecials As Integer
    intCarCode As Integer
    intTuneArr(14) As Integer
    bytMajorColor As Byte
    bytMinorColor As Byte
    bytTuneArr(7) As Byte
    lngAngle As Long
End Type
Global zeroTuneInt(14) As Integer
Global garageHookBuffer As GTASAGarage
Global garageFullHookBuffer(3) As GTASAGarage '4xgarage info as full hook = 4x64 bytes
Public Type GTASAFullGarage
    ParkingSlots(3) As GTASAGarage
End Type

'Adr. holder for Garages:
Type GTASAGarageAdr 'Holds Detailed Address Data for GTASA Garages.
    lngXCoordAdr As Long        'Use only XCoord Adr when reading/writing
    lngYcoordAdr As Long        'complete package of 64 bytes
    lngZcoordAdr As Long
    lngSpecialsAdr As Long
    lngCarCodeAdr As Long
    lngMajorColorAdr As Long
    lngMinorColorAdr As Long
    lngDoorStateAdr As Long         'Garage Door State Reads byte: 0:closed 1:open 2:closing 3:opening
    lngAngleAdr As Long
    isDoorInMiddleState As Boolean  'true if opening and closing
End Type
Global GTASAGarageAddresses(16) As GTASAGarageAdr 'by now, 66 cars in 17 garages
Enum cParkingOrdinals
    iJohnson = 0 'Los Santos
    iElCorona = 1
    iSantaBeach = 2
    iMulHolland = 3
    iPalomino = 4
    iPrickle = 5  'Los Venturas
    iWhitewood = 6
    iRedsands = 7
    iRockshore = 8
    iDillimore = 9  'Bone County
    iFortCarson = 10
    iVerdant = 11
    iVerdantAir = 12
    iCalton = 13  'San Fierro
    iParadiso = 14
    iDoherty = 15
    iHashbury = 16
End Enum

Type GTASAGarageDimensions
    sngXpos     As Single
    sngYpos     As Single
    sngZpos     As Single
    sngWidth    As Single   'bereinigt!
    sngLength   As Single   'bereinigt!
    sngXGrad    As Single
    sngYGrad    As Single
    sngZgrad    As Single
    sngAbsDegrees      As Single   'Absolute Degrees
    isWide As Boolean
    lngLookFront As Long
    lngLookLeft As Long
    lngLookFrontLeft As Long
End Type
Global GTASAGarageDim(16) As GTASAGarageDimensions 'of all 17 garages

'GTASA Color Type
Type GTASAColor
    lngRGB As Long
    intColorCode As Integer
    strDescription As String
End Type
Global GTASAColors(255) As GTASAColor

'Car Parking Details:
Type GTASACarParking 'Array Ordinal as CarCode (from 400 to 611), and 399 as (none)
    strCarName As String
    strCarType As String
    isParkable As Boolean
    sngCarWidth As Single
    sngCarLength As Single
    sngCarHeight As Single
    isBike As Boolean
    isLong As Boolean
    MinorColor As Byte
    MajorColor As Byte
    isHasMods As Boolean
    sModsArr As String
    iHandling As Long
    isRCCar As Boolean
End Type
Global ParkedCars(399 To 611) As GTASACarParking 'ID399 is for None/Ignore
Global ParkedCarMatrix(3, 0 To 215) As Integer   'Listbox to CarOrdinal Matrix (for 4 Parkplaces in each garage), 0:None  1-213: cars
Global GarageListMatrix(3, 399 To 611) As Integer  'CarOrdinal to Listbox Matrix (for 4 Parkplaces in each garage)
Global SpawnCarMatrix(0 To 215) As Integer   'Listbox to CarOrdinal Matrix (for 4 Parkplaces in each garage), 0:None  1-213: cars
Global SpawnListMatrix(399 To 611) As Integer  'CarOrdinal to Listbox Matrix (for 4 Parkplaces in each garage)


'Adr. holder for Player information:
Type GTASAPlayerAdr
    lngObjectStart As Long
    lngPositionPtr As Long   'this is actually objectstart + 20 offset
    lngPlayerPosAdr As Long  'this is the value of lngPositionPtr
    lngXposAdr As Long       'these values are calculated from the value of lngPositionPtr with offsets
    lngYposAdr As Long
    lngZposAdr As Long
    lngAngleAdr As Long      'offset 1372, Angle in Bogenmass
    lngHealthAdr As Long
    lngMaxHealthAdr As Long
    lngArmorAdr As Long
    lngLastCarAdr As Long
    lngLastBoatAdr As Long
    lngSpecialsAdr As Long
    lngPedSpeedAdr As Long
    lngBrassKnucklesAdr As Long
    lngWeaponsAdr(10) As Long   'addresses for 0-10 combo weapons
    lngWeaponSlotAdr As Long
    lngWeaponIDAdr As Long
    lngDetonatorAdr As Long
End Type
Global GTASAPlayerAddresse As GTASAPlayerAdr

Type GTASAWeaponSlotData
    lngWeaponID As Long
    lngWas1 As Long
    lngLoadedAmmo As Long
    lngTotalAmmo As Long
End Type
Global GTASAPlayerWeapon As GTASAWeaponSlotData
Global HookPlayerWeapon As GTASAWeaponSlotData
Global ExecPlayerWeapon As GTASAWeaponSlotData
Global ConsolePlayerWeapon As GTASAWeaponSlotData

Type GTASACarAdr
    isUsable As Boolean      'if this adr block actually and still belongs to a car or not (gtasa addresses cars and peds in the same manner!!)
    isRCCar As Boolean
    lngObjectStart As Long   'this object start is equal to player object start if player is not in car !!!!
    lngPositionPtr As Long   'this is actually objectstart + 20 offset
    lngCarPosAdr As Long     'this is the value that is read from lngPositionPtr
    lngCarLocAdr As Long     'these values are calculated from lngPositionPtr with offsets
    lngCarIDAdr As Long      'saved in HiWord of a long value. We point to the integer offset: 34
    lngSpecialsAdr As Long   'bit coded specials as integer will be read from this location (obj start + 66 offset)
    lngCarSpeedAdr As Long   'objstart + 68
    lngCarSpinAdr As Long    'objstart + 80
    lngCarWeightAdr As Long  'objstart + 140
    lngBikeWheelAdr As Long  'objstart + vc:812???
    lngStalledAdr As Long    'objstart + 1064
    lngCarColorAdr As Long   'objstart + 1076
    lngSirenTimeAdr As Long  'objstart + 1116
    lngCarDamageAdr As Long  'objstart + 1216
    lngCarTrailerAdr As Long 'objstart + 1224 (dynamic. gets the pointer if car has trailer, otherwise 0)
    lngCarLastTrailerPtr As Long 'this is the mirror to the trailer, in case the trailer is temporarily not anymore attached)
    lngCarDoorAdr As Long    'objstart + 1272
    lngLicensePlateAdr As Long 'objstart + 1416 -> read value + 16
    lngCarWheelAdr As Long   'objstart + 1444
    lngBurnTimerAdr As Long  'objstart + 2276 float in ms that counts up until car explodes
    lngCarDetachPosAdr(14) As Long 'according to car or bike, different offsets...
    lngBikeDetachPosAdr(13) As Long 'according to car or bike, different offsets...
End Type
Global tCurrCarAdr As GTASACarAdr
Global tCurrTrailer As GTASACarAdr
Global tOldCarAdr As GTASACarAdr

Global GTASACheats As New cCheatCollection        'Holds the cheats read from ini
Global GTASANewCheat As New cCheats
Global GTASAWarpLocs As New cWarpLocCollection     'Holds the WarpLocs read from ini
Global GTASANewWarpLoc As New cWarpLocs     'Holds the WarpLoc information, read online from GTASA
Global GTASAShortcuts As New cShortcutCollection
Global GTASANewShortcut As New cShortcuts

'ConsoleCommand (internal command of GTASA Control Center)
Type GTASAConsoleCommand
    Command As Integer
    Description As String
    Data As String
    DataPage As Integer
End Type
Global GTASAConsoleCommands(150) As GTASAConsoleCommand

'Positioning Data buffer for Read/Paste Warp Locations:
Type GTASAWarpCarPosData '60 Bytes
    XGrad As Single
    YGrad As Single
    ZGrad As Single
    Reserve1 As Single
    XLook As Single
    YLook As Single
    ZLook As Single
    Reserve2 As Single
    XWhat As Single
    YWhat As Single
    ZWhat As Single
    Reserve3 As Single
    XPos As Single
    YPos As Single
    ZPos As Single
End Type
Global GTASAWarpCarPos As GTASAWarpCarPosData
Global GTASAWarpCarPosBefore As GTASAWarpCarPosData
Global GTASAWarpTrailerPos As GTASAWarpCarPosData
Global GTASAWarpTrailerPosBefore As GTASAWarpCarPosData
Global intCarIDforWarp As Integer
Global WarpTrailerExecBuffer As GTASAWarpCarPosData
Global WarpCarExecBuffer As GTASAWarpCarPosData
Global WarpPlayerExecBuffer As GTASAWarpCarPosData

Type GTASATurnCarDegreeData '44 Bytes
    XGrad As Single
    YGrad As Single
    ZGrad As Single
    Reserve1 As Single
    XLook As Single
    YLook As Single
    ZLook As Single
    Reserve2 As Single
    XWhat As Single
    YWhat As Single
    ZWhat As Single
End Type
Global turnCarExecBuffer As GTASATurnCarDegreeData
Global turnPedExecBuffer As GTASATurnCarDegreeData

Type GTASAScreenText '64 Bytes
    CharValue(63) As Byte
End Type
Global GTASAText As GTASAScreenText

Type GTASASubMissionTimes
    lngAddresse As Long
    lngTimeLeft As Long
End Type

Global SubMissionTime(20) As GTASASubMissionTimes '21 SubMission Time Adresses

Global WeaponSlotMatrix(10, 8) As Long '10 combo's, up to 8+1 items
Global WeaponSlotCombo(46, 1) As Long 'up to weapon id:46. cell2 is for 0, combo ordinal, for 1, item ordinal

Global WeaponIDtoDatID(46) As Long
Global DatIDtoWeaponID(400) As Long


'Types/API Calls for Window Placement (of GTASA, if GTASA has focus or not)
Type POINTAPI
    x As Long
    y As Long
End Type
Type RECT
    Left As Long
    Top As Long
    Right As Long
    Bottom As Long
End Type
Type WINDOWPLACEMENT
    Length As Long
    flags As Long
    showCmd As Long
    ptMinPosition As POINTAPI
    ptMaxPosition As POINTAPI
    rcNormalPosition As RECT
End Type
Global gtaSAWindow As WINDOWPLACEMENT
'API CALL for Window Placement:
Declare Function GetWindowPlacement Lib "user32" (ByVal hwnd As Long, lpwndpl As WINDOWPLACEMENT) As Long
'SLEEP API:
Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
'Send Keystrokes (for Internal Cheats:
Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Global Const KEYEVENTF_KEYUP = &H2
    Global Const KEYEVENTF_EXTENDEDKEY = &H1
'GetKeystates (for Shortcuts):
Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer
'Memory Management API's
Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As Long, lpdwProcessId As Long) As Long
Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Long, ByVal bInheritHandle As Long, ByVal dwProcessId As Long) As Long
Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As Long, ByVal lpBaseAddress As Any, lpBuffer As Any, ByVal nSize As Long, lpNumberOfBytesWritten As Long) As Long
Declare Function ReadProcessMemory Lib "kernel32" (ByVal hProcess As Long, ByVal lpBaseAddress As Any, ByRef lpBuffer As Any, ByVal nSize As Long, lpNumberOfBytesWritten As Long) As Long
Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Long) As Long
Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal Classname As String, ByVal WindowName As String) As Long
    Global Const SYNCHRONIZE As Long = &H100000
    Global Const STANDARD_RIGHTS_REQUIRED As Long = &HF0000
    Global Const PROCESS_ALL_ACCESS As Long = (STANDARD_RIGHTS_REQUIRED Or SYNCHRONIZE Or &HFFF)
'Copy Memory API:
Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (pDst As Any, pSrc As Any, ByVal ByteLen As Long)
'Declare Sub CopyMemoryFromPtr Lib "kernel32" Alias "RtlMoveMemory" (pDst As Any, pSrc As Long, ByVal ByteLen As Long)
'Declare Sub CopyMemoryToPtr Lib "kernel32" Alias "RtlMoveMemory" (pDst As Long, pSrc As Any, ByVal ByteLen As Long)
'Sound Feedback:
Declare Function BeepNow Lib "kernel32" Alias "Beep" (ByVal dwFreq As Long, ByVal dwDuration As Long) As Long
'Read / Write INI File API's
Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpString As Any, ByVal lpFileName As String) As Long
'Global Variables:
Global lngHWnd As Long              'HWND variable for GotHandleToGTASA function
Global lngPid As Long               'process-id
Global lngPHandle As Long           'process handle
Global lngReadBuffer As Long        'ReadALong buffer
Global intWriteBuffer As Integer    'WriteAnInt buffer
Global intReadBuffer As Integer     'ReadAnInt buffer
Global bytReadBuffer As Byte        'ReadAByte buffer
Global sngReadBuffer As Single      'ReadAFloat buffer
Global MemAddress As Long           'Memory Address
Global isHasHandle As Boolean       'If GTASA Handle retrieved or not
Global isHasPlayer As Boolean          'If Player initialised or not
Global intCounter As Integer        'integer counter
Global lngZSpeed As Long            'Z speed temp. variable
Global strBuffer As String          'misc. temp. buffer
Global intCharCounter As Integer    'int. counter
Global intSendOrdinal As Integer    'int. counter
Global strTextLine As String        'temp string var. to read from files
Global lngCarAdr As Long            'Start Adr. of Car
Global lngPreviousCarAdr As Long    'Start Adr. of Previous Car
Global isCollectingGarbage As Boolean   'If closing the program or not
Global strIniFileName As String        'FileName of ini File
Global strPicFileName As String         'Filename of dat file
Global strDatFileName As String         'Filename of dat file
Global strCfgFileName As String         'Filename of cfg file
Global strCheatFileName As String             'Filename of cfg file
Global strLocsFileName      As String         'Filename of cfg file
Global intLastPickedColor As Integer 'Ordinal of Last Picked Color
Global Const TrueBool As Boolean = True  'For Select case on bool.
Global Const mathPI As Double = 3.14159265358979  'for Float to Degrees calculation
                               '3.1415926535897932384626433832795
Global sngMMsPerTwipX As Single
Global sngMMsPerTwipY As Single

Global isCarPicsReady As Boolean
