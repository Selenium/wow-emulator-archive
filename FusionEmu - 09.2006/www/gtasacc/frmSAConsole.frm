VERSION 5.00
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MsComCtl.ocx"
Begin VB.Form frmSAConsole 
   Caption         =   "GTA San Andreas Control Center"
   ClientHeight    =   8595
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11880
   Icon            =   "frmSAConsole.frx":0000
   LinkTopic       =   "GTASAAdminConsole"
   LockControls    =   -1  'True
   ScaleHeight     =   8595
   ScaleWidth      =   11880
   StartUpPosition =   2  'CenterScreen
   Begin TabDlg.SSTab sstMain 
      Height          =   8520
      Left            =   45
      TabIndex        =   1
      TabStop         =   0   'False
      Top             =   30
      Width           =   11805
      _ExtentX        =   20823
      _ExtentY        =   15028
      _Version        =   393216
      Style           =   1
      Tabs            =   6
      TabsPerRow      =   7
      TabHeight       =   520
      TabCaption(0)   =   "Vehicle and Game Data"
      TabPicture(0)   =   "frmSAConsole.frx":014A
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "lblConsole(61)"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "lblConsole(60)"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "lblConsole(59)"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "lblCurrentCar"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "lblConsole(20)"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "lblConsole(19)"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "lblConsole(18)"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "lblConsole(17)"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "lblConsole(16)"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "lblConsole(15)"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "lblConsole(30)"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "lblConsole(56)"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "lblConsole(58)"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "lblConsole(13)"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "cShapes(0)"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "cShapes(2)"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "cShapes(3)"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "lblConsole(14)"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).Control(18)=   "cShapes(1)"
      Tab(0).Control(18).Enabled=   0   'False
      Tab(0).Control(19)=   "cShapes(10)"
      Tab(0).Control(19).Enabled=   0   'False
      Tab(0).Control(20)=   "chkCarDynamics(4)"
      Tab(0).Control(20).Enabled=   0   'False
      Tab(0).Control(21)=   "cmdGameSpeed(1)"
      Tab(0).Control(21).Enabled=   0   'False
      Tab(0).Control(22)=   "cmd50Ton"
      Tab(0).Control(22).Enabled=   0   'False
      Tab(0).Control(23)=   "scrCarDynamics(1)"
      Tab(0).Control(23).Enabled=   0   'False
      Tab(0).Control(24)=   "chkCarDynamics(8)"
      Tab(0).Control(24).Enabled=   0   'False
      Tab(0).Control(25)=   "chkCarDynamics(6)"
      Tab(0).Control(25).Enabled=   0   'False
      Tab(0).Control(26)=   "cmdStopCar(5)"
      Tab(0).Control(26).Enabled=   0   'False
      Tab(0).Control(27)=   "cmdStopCar(4)"
      Tab(0).Control(27).Enabled=   0   'False
      Tab(0).Control(28)=   "cmdStopCar(3)"
      Tab(0).Control(28).Enabled=   0   'False
      Tab(0).Control(29)=   "cmdStopCar(2)"
      Tab(0).Control(29).Enabled=   0   'False
      Tab(0).Control(30)=   "cmdStopCar(1)"
      Tab(0).Control(30).Enabled=   0   'False
      Tab(0).Control(31)=   "optCarDoors(1)"
      Tab(0).Control(31).Enabled=   0   'False
      Tab(0).Control(32)=   "chkCarSpecs(0)"
      Tab(0).Control(32).Enabled=   0   'False
      Tab(0).Control(33)=   "chkCarDynamics(0)"
      Tab(0).Control(33).Enabled=   0   'False
      Tab(0).Control(34)=   "chkCarSpecs(1)"
      Tab(0).Control(34).Enabled=   0   'False
      Tab(0).Control(35)=   "chkCarSpecs(2)"
      Tab(0).Control(35).Enabled=   0   'False
      Tab(0).Control(36)=   "chkCarSpecs(3)"
      Tab(0).Control(36).Enabled=   0   'False
      Tab(0).Control(37)=   "chkCarDynamics(1)"
      Tab(0).Control(37).Enabled=   0   'False
      Tab(0).Control(38)=   "optCarDoors(0)"
      Tab(0).Control(38).Enabled=   0   'False
      Tab(0).Control(39)=   "picMinor"
      Tab(0).Control(39).Enabled=   0   'False
      Tab(0).Control(40)=   "chkCarDynamics(5)"
      Tab(0).Control(40).Enabled=   0   'False
      Tab(0).Control(41)=   "picMajor"
      Tab(0).Control(41).Enabled=   0   'False
      Tab(0).Control(42)=   "scrCarDynamics(0)"
      Tab(0).Control(42).Enabled=   0   'False
      Tab(0).Control(43)=   "chkCarDynamics(3)"
      Tab(0).Control(43).Enabled=   0   'False
      Tab(0).Control(44)=   "scrCarDynamics(8)"
      Tab(0).Control(44).Enabled=   0   'False
      Tab(0).Control(45)=   "chkCarDynamics(2)"
      Tab(0).Control(45).Enabled=   0   'False
      Tab(0).Control(46)=   "oCarDirection"
      Tab(0).Control(46).Enabled=   0   'False
      Tab(0).Control(47)=   "oCarStart"
      Tab(0).Control(47).Enabled=   0   'False
      Tab(0).Control(48)=   "cmdFlipCar"
      Tab(0).Control(48).Enabled=   0   'False
      Tab(0).Control(49)=   "cmdStopCar(8)"
      Tab(0).Control(49).Enabled=   0   'False
      Tab(0).Control(50)=   "cmdStopCar(6)"
      Tab(0).Control(50).Enabled=   0   'False
      Tab(0).Control(51)=   "cmdStopCar(7)"
      Tab(0).Control(51).Enabled=   0   'False
      Tab(0).Control(52)=   "chkDontBurn(0)"
      Tab(0).Control(52).Enabled=   0   'False
      Tab(0).Control(53)=   "chkDontBurn(1)"
      Tab(0).Control(53).Enabled=   0   'False
      Tab(0).Control(54)=   "cmdStopCar(0)"
      Tab(0).Control(54).Enabled=   0   'False
      Tab(0).Control(55)=   "cmdMain(0)"
      Tab(0).Control(55).Enabled=   0   'False
      Tab(0).Control(56)=   "cmdMain(1)"
      Tab(0).Control(56).Enabled=   0   'False
      Tab(0).Control(57)=   "cmdMain(2)"
      Tab(0).Control(57).Enabled=   0   'False
      Tab(0).Control(58)=   "scrCarDynamics(2)"
      Tab(0).Control(58).Enabled=   0   'False
      Tab(0).Control(59)=   "scrGameSpeed(1)"
      Tab(0).Control(59).Enabled=   0   'False
      Tab(0).Control(60)=   "cboSpawnCar"
      Tab(0).Control(60).Enabled=   0   'False
      Tab(0).Control(61)=   "cmdSpawnCar(1)"
      Tab(0).Control(61).Enabled=   0   'False
      Tab(0).Control(62)=   "scrCarDynamics(3)"
      Tab(0).Control(62).Enabled=   0   'False
      Tab(0).Control(63)=   "scrCarDynamics(4)"
      Tab(0).Control(63).Enabled=   0   'False
      Tab(0).Control(64)=   "scrCarDynamics(5)"
      Tab(0).Control(64).Enabled=   0   'False
      Tab(0).Control(65)=   "scrCarDynamics(6)"
      Tab(0).Control(65).Enabled=   0   'False
      Tab(0).Control(66)=   "scrCarDynamics(7)"
      Tab(0).Control(66).Enabled=   0   'False
      Tab(0).Control(67)=   "cboWeather"
      Tab(0).Control(67).Enabled=   0   'False
      Tab(0).Control(68)=   "chkCarDynamics(7)"
      Tab(0).Control(68).Enabled=   0   'False
      Tab(0).Control(69)=   "cmdGameSpeed(2)"
      Tab(0).Control(69).Enabled=   0   'False
      Tab(0).Control(70)=   "scrDateTime"
      Tab(0).Control(70).Enabled=   0   'False
      Tab(0).Control(71)=   "cmdGameSpeed(3)"
      Tab(0).Control(71).Enabled=   0   'False
      Tab(0).Control(72)=   "cmdGameSpeed(0)"
      Tab(0).Control(72).Enabled=   0   'False
      Tab(0).Control(73)=   "scrGameSpeed(0)"
      Tab(0).Control(73).Enabled=   0   'False
      Tab(0).Control(74)=   "oGFStats(5)"
      Tab(0).Control(74).Enabled=   0   'False
      Tab(0).Control(75)=   "oGFStats(4)"
      Tab(0).Control(75).Enabled=   0   'False
      Tab(0).Control(76)=   "oGFStats(3)"
      Tab(0).Control(76).Enabled=   0   'False
      Tab(0).Control(77)=   "oGFStats(2)"
      Tab(0).Control(77).Enabled=   0   'False
      Tab(0).Control(78)=   "oGFStats(1)"
      Tab(0).Control(78).Enabled=   0   'False
      Tab(0).Control(79)=   "oGFStats(0)"
      Tab(0).Control(79).Enabled=   0   'False
      Tab(0).Control(80)=   "chkCarDynamics(9)"
      Tab(0).Control(80).Enabled=   0   'False
      Tab(0).Control(81)=   "chkAutoInjectCode"
      Tab(0).Control(81).Enabled=   0   'False
      Tab(0).Control(82)=   "chkSpawnVehicle"
      Tab(0).Control(82).Enabled=   0   'False
      Tab(0).Control(83)=   "cmdSpawnCar(0)"
      Tab(0).Control(83).Enabled=   0   'False
      Tab(0).Control(84)=   "chkCarDynamics(10)"
      Tab(0).Control(84).Enabled=   0   'False
      Tab(0).Control(85)=   "txtLicensePlate"
      Tab(0).Control(85).Enabled=   0   'False
      Tab(0).Control(86)=   "cmdSetPlate"
      Tab(0).Control(86).Enabled=   0   'False
      Tab(0).Control(87)=   "chkWeatherLock"
      Tab(0).Control(87).Enabled=   0   'False
      Tab(0).ControlCount=   88
      TabCaption(1)   =   "Player Data"
      TabPicture(1)   =   "frmSAConsole.frx":0166
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "cmdSetWeapon(10)"
      Tab(1).Control(0).Enabled=   0   'False
      Tab(1).Control(1)=   "cmdSetWeapon(9)"
      Tab(1).Control(1).Enabled=   0   'False
      Tab(1).Control(2)=   "cmdSetWeapon(8)"
      Tab(1).Control(2).Enabled=   0   'False
      Tab(1).Control(3)=   "cmdSetWeapon(7)"
      Tab(1).Control(3).Enabled=   0   'False
      Tab(1).Control(4)=   "cmdSetWeapon(6)"
      Tab(1).Control(4).Enabled=   0   'False
      Tab(1).Control(5)=   "cmdSetWeapon(5)"
      Tab(1).Control(5).Enabled=   0   'False
      Tab(1).Control(6)=   "cmdSetWeapon(4)"
      Tab(1).Control(6).Enabled=   0   'False
      Tab(1).Control(7)=   "cmdSetWeapon(3)"
      Tab(1).Control(7).Enabled=   0   'False
      Tab(1).Control(8)=   "cmdSetWeapon(2)"
      Tab(1).Control(8).Enabled=   0   'False
      Tab(1).Control(9)=   "cmdSetWeapon(1)"
      Tab(1).Control(9).Enabled=   0   'False
      Tab(1).Control(10)=   "cmdSetWeapon(0)"
      Tab(1).Control(10).Enabled=   0   'False
      Tab(1).Control(11)=   "chkWeapons(11)"
      Tab(1).Control(11).Enabled=   0   'False
      Tab(1).Control(12)=   "txtAmmo(10)"
      Tab(1).Control(12).Enabled=   0   'False
      Tab(1).Control(13)=   "txtAmmo(9)"
      Tab(1).Control(13).Enabled=   0   'False
      Tab(1).Control(14)=   "txtAmmo(8)"
      Tab(1).Control(14).Enabled=   0   'False
      Tab(1).Control(15)=   "txtAmmo(7)"
      Tab(1).Control(15).Enabled=   0   'False
      Tab(1).Control(16)=   "txtAmmo(6)"
      Tab(1).Control(16).Enabled=   0   'False
      Tab(1).Control(17)=   "txtAmmo(5)"
      Tab(1).Control(17).Enabled=   0   'False
      Tab(1).Control(18)=   "txtAmmo(4)"
      Tab(1).Control(18).Enabled=   0   'False
      Tab(1).Control(19)=   "txtAmmo(3)"
      Tab(1).Control(19).Enabled=   0   'False
      Tab(1).Control(20)=   "txtAmmo(2)"
      Tab(1).Control(20).Enabled=   0   'False
      Tab(1).Control(21)=   "txtAmmo(1)"
      Tab(1).Control(21).Enabled=   0   'False
      Tab(1).Control(22)=   "txtAmmo(0)"
      Tab(1).Control(22).Enabled=   0   'False
      Tab(1).Control(23)=   "chkWeapons(10)"
      Tab(1).Control(23).Enabled=   0   'False
      Tab(1).Control(24)=   "chkWeapons(9)"
      Tab(1).Control(24).Enabled=   0   'False
      Tab(1).Control(25)=   "chkWeapons(8)"
      Tab(1).Control(25).Enabled=   0   'False
      Tab(1).Control(26)=   "chkWeapons(7)"
      Tab(1).Control(26).Enabled=   0   'False
      Tab(1).Control(27)=   "chkWeapons(6)"
      Tab(1).Control(27).Enabled=   0   'False
      Tab(1).Control(28)=   "chkWeapons(5)"
      Tab(1).Control(28).Enabled=   0   'False
      Tab(1).Control(29)=   "chkWeapons(4)"
      Tab(1).Control(29).Enabled=   0   'False
      Tab(1).Control(30)=   "chkWeapons(3)"
      Tab(1).Control(30).Enabled=   0   'False
      Tab(1).Control(31)=   "chkWeapons(2)"
      Tab(1).Control(31).Enabled=   0   'False
      Tab(1).Control(32)=   "chkWeapons(1)"
      Tab(1).Control(32).Enabled=   0   'False
      Tab(1).Control(33)=   "chkWeapons(0)"
      Tab(1).Control(33).Enabled=   0   'False
      Tab(1).Control(34)=   "cboWeapons(10)"
      Tab(1).Control(34).Enabled=   0   'False
      Tab(1).Control(35)=   "cboWeapons(9)"
      Tab(1).Control(35).Enabled=   0   'False
      Tab(1).Control(36)=   "cboWeapons(8)"
      Tab(1).Control(36).Enabled=   0   'False
      Tab(1).Control(37)=   "cboWeapons(0)"
      Tab(1).Control(37).Enabled=   0   'False
      Tab(1).Control(38)=   "cboWeapons(1)"
      Tab(1).Control(38).Enabled=   0   'False
      Tab(1).Control(39)=   "cboWeapons(2)"
      Tab(1).Control(39).Enabled=   0   'False
      Tab(1).Control(40)=   "cboWeapons(3)"
      Tab(1).Control(40).Enabled=   0   'False
      Tab(1).Control(41)=   "cboWeapons(4)"
      Tab(1).Control(41).Enabled=   0   'False
      Tab(1).Control(42)=   "cboWeapons(5)"
      Tab(1).Control(42).Enabled=   0   'False
      Tab(1).Control(43)=   "cboWeapons(6)"
      Tab(1).Control(43).Enabled=   0   'False
      Tab(1).Control(44)=   "cboWeapons(7)"
      Tab(1).Control(44).Enabled=   0   'False
      Tab(1).Control(45)=   "oCheatStates(13)"
      Tab(1).Control(46)=   "oCheatStates(12)"
      Tab(1).Control(47)=   "oCheatStates(11)"
      Tab(1).Control(48)=   "oCheatStates(10)"
      Tab(1).Control(49)=   "oCheatStates(9)"
      Tab(1).Control(50)=   "oCheatStates(8)"
      Tab(1).Control(51)=   "oCheatStates(7)"
      Tab(1).Control(52)=   "oCheatStates(6)"
      Tab(1).Control(53)=   "oCheatStates(5)"
      Tab(1).Control(54)=   "oCheatStates(4)"
      Tab(1).Control(55)=   "oCheatStates(3)"
      Tab(1).Control(56)=   "oCheatStates(2)"
      Tab(1).Control(57)=   "oCheatStates(1)"
      Tab(1).Control(58)=   "oCheatStates(0)"
      Tab(1).Control(59)=   "chkSafeCheats"
      Tab(1).Control(59).Enabled=   0   'False
      Tab(1).Control(60)=   "cmdWeaponStat"
      Tab(1).Control(60).Enabled=   0   'False
      Tab(1).Control(61)=   "oPedStats(2)"
      Tab(1).Control(62)=   "oPedStats(1)"
      Tab(1).Control(63)=   "oPedStats(0)"
      Tab(1).Control(64)=   "cmdStopPed(3)"
      Tab(1).Control(64).Enabled=   0   'False
      Tab(1).Control(65)=   "scrPedSpeed(0)"
      Tab(1).Control(65).Enabled=   0   'False
      Tab(1).Control(66)=   "scrPedSpeed(1)"
      Tab(1).Control(66).Enabled=   0   'False
      Tab(1).Control(67)=   "scrPedSpeed(2)"
      Tab(1).Control(67).Enabled=   0   'False
      Tab(1).Control(68)=   "cmdStopPed(2)"
      Tab(1).Control(68).Enabled=   0   'False
      Tab(1).Control(69)=   "cmdStopPed(1)"
      Tab(1).Control(69).Enabled=   0   'False
      Tab(1).Control(70)=   "cmdStopPed(0)"
      Tab(1).Control(70).Enabled=   0   'False
      Tab(1).Control(71)=   "chkPedSpecs(0)"
      Tab(1).Control(71).Enabled=   0   'False
      Tab(1).Control(72)=   "chkFixPedSpecs"
      Tab(1).Control(72).Enabled=   0   'False
      Tab(1).Control(73)=   "chkPedSpecs(1)"
      Tab(1).Control(73).Enabled=   0   'False
      Tab(1).Control(74)=   "chkPedSpecs(2)"
      Tab(1).Control(74).Enabled=   0   'False
      Tab(1).Control(75)=   "chkPedSpecs(3)"
      Tab(1).Control(75).Enabled=   0   'False
      Tab(1).Control(76)=   "cmdPedMaxStat(5)"
      Tab(1).Control(76).Enabled=   0   'False
      Tab(1).Control(77)=   "oPedStart"
      Tab(1).Control(78)=   "oPedDirection"
      Tab(1).Control(79)=   "oPedStats(3)"
      Tab(1).Control(80)=   "oPedStats(4)"
      Tab(1).Control(81)=   "oPedStats(5)"
      Tab(1).Control(82)=   "oPedStats(6)"
      Tab(1).Control(83)=   "oPedStats(7)"
      Tab(1).Control(84)=   "oPedStats(8)"
      Tab(1).Control(85)=   "oPedStats(9)"
      Tab(1).Control(86)=   "oPedStats(10)"
      Tab(1).Control(87)=   "oPedStats(20)"
      Tab(1).Control(88)=   "oCheatStates(14)"
      Tab(1).Control(89)=   "oCheatStates(15)"
      Tab(1).Control(90)=   "oCheatStates(16)"
      Tab(1).Control(91)=   "oCheatStates(17)"
      Tab(1).Control(92)=   "oCheatStates(18)"
      Tab(1).Control(93)=   "oCheatStates(19)"
      Tab(1).Control(94)=   "oCheatStates(20)"
      Tab(1).Control(95)=   "oCheatStates(21)"
      Tab(1).Control(96)=   "oCheatStates(22)"
      Tab(1).Control(97)=   "oCheatStates(23)"
      Tab(1).Control(98)=   "oCheatStates(24)"
      Tab(1).Control(99)=   "oCheatStates(25)"
      Tab(1).Control(100)=   "oCheatStates(26)"
      Tab(1).Control(101)=   "oCheatStates(27)"
      Tab(1).Control(102)=   "oCheatStates(28)"
      Tab(1).Control(103)=   "oCheatStates(29)"
      Tab(1).Control(104)=   "oCheatStates(30)"
      Tab(1).Control(105)=   "oCheatStates(31)"
      Tab(1).Control(106)=   "lblConsole(66)"
      Tab(1).Control(107)=   "lblConsole(65)"
      Tab(1).Control(108)=   "lblConsole(63)"
      Tab(1).Control(109)=   "lblConsole(62)"
      Tab(1).Control(110)=   "cShapes(11)"
      Tab(1).Control(111)=   "cShapes(9)"
      Tab(1).Control(112)=   "cShapes(8)"
      Tab(1).Control(113)=   "cShapes(7)"
      Tab(1).Control(114)=   "lblPedSpeed(2)"
      Tab(1).Control(115)=   "lblPedSpeed(1)"
      Tab(1).Control(116)=   "lblPedSpeed(0)"
      Tab(1).Control(117)=   "lblCurrentPlayer"
      Tab(1).Control(118)=   "lblConsole(57)"
      Tab(1).ControlCount=   119
      TabCaption(2)   =   "Garages"
      TabPicture(2)   =   "frmSAConsole.frx":0182
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "cmdGarages(3)"
      Tab(2).Control(1)=   "cmdGarages(2)"
      Tab(2).Control(2)=   "cmdGarages(1)"
      Tab(2).Control(3)=   "cmdGarages(0)"
      Tab(2).Control(4)=   "sstGarages"
      Tab(2).ControlCount=   5
      TabCaption(3)   =   "GTA SA Cheats"
      TabPicture(3)   =   "frmSAConsole.frx":019E
      Tab(3).ControlEnabled=   0   'False
      Tab(3).Control(0)=   "cmdCheats(0)"
      Tab(3).Control(0).Enabled=   0   'False
      Tab(3).Control(1)=   "txtCheatString"
      Tab(3).Control(1).Enabled=   0   'False
      Tab(3).Control(2)=   "cmdCheats(1)"
      Tab(3).Control(2).Enabled=   0   'False
      Tab(3).Control(3)=   "cmdCheats(2)"
      Tab(3).Control(3).Enabled=   0   'False
      Tab(3).Control(4)=   "cmdCheats(3)"
      Tab(3).Control(4).Enabled=   0   'False
      Tab(3).Control(5)=   "cmdCheats(4)"
      Tab(3).Control(5).Enabled=   0   'False
      Tab(3).Control(6)=   "cmdCheats(5)"
      Tab(3).Control(6).Enabled=   0   'False
      Tab(3).Control(7)=   "tvCheats"
      Tab(3).Control(8)=   "lblConsole(21)"
      Tab(3).ControlCount=   9
      TabCaption(4)   =   "Locations"
      TabPicture(4)   =   "frmSAConsole.frx":01BA
      Tab(4).ControlEnabled=   0   'False
      Tab(4).Control(0)=   "scrLeftRight"
      Tab(4).Control(1)=   "cmdCenterMap"
      Tab(4).Control(2)=   "scrTopBottom"
      Tab(4).Control(3)=   "picLocationControls"
      Tab(4).Control(4)=   "picMapHolder"
      Tab(4).ControlCount=   5
      TabCaption(5)   =   "Keyboard Shortcuts"
      TabPicture(5)   =   "frmSAConsole.frx":01D6
      Tab(5).ControlEnabled=   0   'False
      Tab(5).Control(0)=   "lblConsole(28)"
      Tab(5).Control(1)=   "lblConsole(27)"
      Tab(5).Control(2)=   "lblConsole(29)"
      Tab(5).Control(3)=   "lblIntervall"
      Tab(5).Control(4)=   "lblConsole(0)"
      Tab(5).Control(5)=   "lblConsole(1)"
      Tab(5).Control(6)=   "tvShotcuts"
      Tab(5).Control(7)=   "cmdShortcuts(5)"
      Tab(5).Control(7).Enabled=   0   'False
      Tab(5).Control(8)=   "cmdShortcuts(4)"
      Tab(5).Control(8).Enabled=   0   'False
      Tab(5).Control(9)=   "cmdShortcuts(3)"
      Tab(5).Control(9).Enabled=   0   'False
      Tab(5).Control(10)=   "cmdShortcuts(2)"
      Tab(5).Control(10).Enabled=   0   'False
      Tab(5).Control(11)=   "cmdShortcuts(1)"
      Tab(5).Control(11).Enabled=   0   'False
      Tab(5).Control(12)=   "cmdShortcuts(0)"
      Tab(5).Control(12).Enabled=   0   'False
      Tab(5).Control(13)=   "cboShortcut"
      Tab(5).Control(13).Enabled=   0   'False
      Tab(5).Control(14)=   "cboCommands(0)"
      Tab(5).Control(14).Enabled=   0   'False
      Tab(5).Control(15)=   "scrIntervall"
      Tab(5).Control(15).Enabled=   0   'False
      Tab(5).Control(16)=   "chkShortcut(0)"
      Tab(5).Control(16).Enabled=   0   'False
      Tab(5).Control(17)=   "chkShortcut(1)"
      Tab(5).Control(17).Enabled=   0   'False
      Tab(5).Control(18)=   "cboCommands(1)"
      Tab(5).Control(18).Enabled=   0   'False
      Tab(5).Control(19)=   "cboCommands(2)"
      Tab(5).Control(19).Enabled=   0   'False
      Tab(5).Control(20)=   "chkFeedback"
      Tab(5).Control(20).Enabled=   0   'False
      Tab(5).Control(21)=   "picCommandData"
      Tab(5).Control(22)=   "cboGTAVersion"
      Tab(5).Control(23)=   "chkOrgSCM"
      Tab(5).ControlCount=   24
      Begin VB.CheckBox chkWeatherLock 
         Height          =   195
         Left            =   7980
         TabIndex        =   370
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock weather"
         Top             =   4095
         Width           =   195
      End
      Begin VB.CommandButton cmdSetPlate 
         Height          =   315
         Left            =   3495
         Picture         =   "frmSAConsole.frx":01F2
         Style           =   1  'Graphical
         TabIndex        =   369
         TabStop         =   0   'False
         ToolTipText     =   "Click to apply selected License Plate"
         Top             =   5610
         Width           =   315
      End
      Begin VB.TextBox txtLicensePlate 
         Height          =   315
         Left            =   2250
         Locked          =   -1  'True
         MaxLength       =   8
         TabIndex        =   368
         Text            =   "GTASA CC"
         ToolTipText     =   "License Plate (Upper Case, 8 Characters)"
         Top             =   5610
         Width           =   1215
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Set License Plate to:"
         Enabled         =   0   'False
         Height          =   195
         Index           =   10
         Left            =   300
         TabIndex        =   367
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock License Plate for yout cars to the given value"
         Top             =   5640
         Width           =   3300
      End
      Begin VB.CommandButton cmdSpawnCar 
         Caption         =   "Spawn selected Vehicle (© Jacob)"
         Enabled         =   0   'False
         Height          =   480
         Index           =   0
         Left            =   285
         TabIndex        =   268
         ToolTipText     =   "Spawn selected Vehicle (by Jacob)"
         Top             =   7140
         Width           =   3465
      End
      Begin VB.CheckBox chkSpawnVehicle 
         Caption         =   "Spawner Code-Injection Status: (unknown)"
         Enabled         =   0   'False
         Height          =   480
         Left            =   285
         Style           =   1  'Graphical
         TabIndex        =   276
         TabStop         =   0   'False
         ToolTipText     =   "Injection ASM Code © Jacob"
         Top             =   6675
         Width           =   3465
      End
      Begin VB.CheckBox chkAutoInjectCode 
         Caption         =   "Auto-inject Spawner Code if possible"
         Height          =   480
         Left            =   285
         Style           =   1  'Graphical
         TabIndex        =   366
         TabStop         =   0   'False
         ToolTipText     =   "Auto-inject ASM Code if Code-injection is possible"
         Top             =   6210
         Width           =   3465
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Control also RC Vehicles"
         Height          =   195
         Index           =   9
         Left            =   300
         TabIndex        =   365
         TabStop         =   0   'False
         ToolTipText     =   "Check to treat Radio Controlled Vehicles as normal vehicles."
         Top             =   5280
         Width           =   3300
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   10
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":033C
         Style           =   1  'Graphical
         TabIndex        =   364
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   7935
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   9
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0486
         Style           =   1  'Graphical
         TabIndex        =   363
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   7620
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   8
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":05D0
         Style           =   1  'Graphical
         TabIndex        =   362
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   7305
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   7
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":071A
         Style           =   1  'Graphical
         TabIndex        =   361
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   6990
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   6
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0864
         Style           =   1  'Graphical
         TabIndex        =   360
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   6675
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   5
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":09AE
         Style           =   1  'Graphical
         TabIndex        =   359
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   6360
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   4
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0AF8
         Style           =   1  'Graphical
         TabIndex        =   358
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   6045
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   3
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0C42
         Style           =   1  'Graphical
         TabIndex        =   357
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   5730
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   2
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0D8C
         Style           =   1  'Graphical
         TabIndex        =   356
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   5415
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   1
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":0ED6
         Style           =   1  'Graphical
         TabIndex        =   355
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   5100
         Width           =   315
      End
      Begin VB.CommandButton cmdSetWeapon 
         Height          =   315
         Index           =   0
         Left            =   -67815
         Picture         =   "frmSAConsole.frx":1020
         Style           =   1  'Graphical
         TabIndex        =   354
         TabStop         =   0   'False
         ToolTipText     =   "Click to Accept Weapon Changes"
         Top             =   4785
         Width           =   315
      End
      Begin VB.CheckBox chkWeapons 
         Caption         =   "Brass Knuckles"
         Height          =   315
         Index           =   11
         Left            =   -70935
         TabIndex        =   349
         TabStop         =   0   'False
         ToolTipText     =   "Check to give Player Brass Knuckles, and Lock"
         Top             =   4455
         Width           =   1560
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   10
         Left            =   -68685
         TabIndex        =   348
         TabStop         =   0   'False
         Text            =   "0"
         Top             =   7935
         Visible         =   0   'False
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   9
         Left            =   -68685
         TabIndex        =   347
         TabStop         =   0   'False
         Text            =   "0"
         Top             =   7620
         Visible         =   0   'False
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   8
         Left            =   -68685
         TabIndex        =   346
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Select Special Item Amount"
         Top             =   7305
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   7
         Left            =   -68685
         TabIndex        =   345
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Amount for Projectile"
         Top             =   6990
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   6
         Left            =   -68685
         TabIndex        =   344
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Heavy Weapon"
         Top             =   6675
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   5
         Left            =   -68685
         TabIndex        =   343
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Rifle"
         Top             =   6360
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   4
         Left            =   -68685
         TabIndex        =   342
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Machinegun"
         Top             =   6045
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   3
         Left            =   -68685
         TabIndex        =   341
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Sub-Machinegun"
         Top             =   5730
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   2
         Left            =   -68685
         TabIndex        =   340
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Shotgun"
         Top             =   5415
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Height          =   300
         Index           =   1
         Left            =   -68685
         TabIndex        =   339
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Enter Ammo Amount for Handgun"
         Top             =   5100
         Width           =   840
      End
      Begin VB.TextBox txtAmmo 
         Enabled         =   0   'False
         Height          =   300
         Index           =   0
         Left            =   -68685
         Locked          =   -1  'True
         TabIndex        =   338
         TabStop         =   0   'False
         Text            =   "0"
         ToolTipText     =   "Melee Weapons do not have Ammo"
         Top             =   4785
         Visible         =   0   'False
         Width           =   840
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   10
         Left            =   -70935
         TabIndex        =   337
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Special Item2"
         Top             =   7920
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   9
         Left            =   -70935
         TabIndex        =   336
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Gift"
         Top             =   7605
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   8
         Left            =   -70935
         TabIndex        =   335
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Special Item"
         Top             =   7290
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   7
         Left            =   -70935
         TabIndex        =   334
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Projectile"
         Top             =   6975
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   6
         Left            =   -70935
         TabIndex        =   333
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Heavy Weapon"
         Top             =   6660
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   5
         Left            =   -70935
         TabIndex        =   332
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Rifle"
         Top             =   6345
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   4
         Left            =   -70935
         TabIndex        =   331
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Machinegun"
         Top             =   6030
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   3
         Left            =   -70935
         TabIndex        =   330
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Sub-Machinegun"
         Top             =   5715
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   2
         Left            =   -70935
         TabIndex        =   329
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Shotgun"
         Top             =   5400
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   1
         Left            =   -70935
         TabIndex        =   328
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Handgun"
         Top             =   5085
         Width           =   270
      End
      Begin VB.CheckBox chkWeapons 
         Height          =   315
         Index           =   0
         Left            =   -70935
         TabIndex        =   327
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock selected Melee Weapon"
         Top             =   4770
         Width           =   270
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   10
         ItemData        =   "frmSAConsole.frx":116A
         Left            =   -70635
         List            =   "frmSAConsole.frx":117D
         Style           =   2  'Dropdown List
         TabIndex        =   326
         TabStop         =   0   'False
         ToolTipText     =   "Select Special Item2"
         Top             =   7920
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   9
         ItemData        =   "frmSAConsole.frx":11B6
         Left            =   -70635
         List            =   "frmSAConsole.frx":11D5
         Style           =   2  'Dropdown List
         TabIndex        =   325
         TabStop         =   0   'False
         ToolTipText     =   "Select Gift"
         Top             =   7605
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   8
         ItemData        =   "frmSAConsole.frx":1212
         Left            =   -70635
         List            =   "frmSAConsole.frx":1225
         Style           =   2  'Dropdown List
         TabIndex        =   324
         TabStop         =   0   'False
         ToolTipText     =   "Select Special Item"
         Top             =   7290
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         BackColor       =   &H00FFFFFF&
         Height          =   315
         Index           =   0
         ItemData        =   "frmSAConsole.frx":1257
         Left            =   -70635
         List            =   "frmSAConsole.frx":1276
         Style           =   2  'Dropdown List
         TabIndex        =   323
         TabStop         =   0   'False
         ToolTipText     =   "Select Melee Weapon"
         Top             =   4770
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   1
         ItemData        =   "frmSAConsole.frx":12D1
         Left            =   -70635
         List            =   "frmSAConsole.frx":12E4
         Style           =   2  'Dropdown List
         TabIndex        =   322
         TabStop         =   0   'False
         ToolTipText     =   "Select Handgun"
         Top             =   5085
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   2
         ItemData        =   "frmSAConsole.frx":1317
         Left            =   -70635
         List            =   "frmSAConsole.frx":132A
         Style           =   2  'Dropdown List
         TabIndex        =   321
         TabStop         =   0   'False
         ToolTipText     =   "Select Shotgun"
         Top             =   5400
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   3
         ItemData        =   "frmSAConsole.frx":1359
         Left            =   -70635
         List            =   "frmSAConsole.frx":136C
         Style           =   2  'Dropdown List
         TabIndex        =   320
         TabStop         =   0   'False
         ToolTipText     =   "Select Sub-Machinegun"
         Top             =   5715
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   4
         ItemData        =   "frmSAConsole.frx":138F
         Left            =   -70635
         List            =   "frmSAConsole.frx":139E
         Style           =   2  'Dropdown List
         TabIndex        =   319
         TabStop         =   0   'False
         ToolTipText     =   "Select Machinegun"
         Top             =   6030
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   5
         ItemData        =   "frmSAConsole.frx":13B4
         Left            =   -70635
         List            =   "frmSAConsole.frx":13C3
         Style           =   2  'Dropdown List
         TabIndex        =   318
         TabStop         =   0   'False
         ToolTipText     =   "Select Rifle"
         Top             =   6345
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   6
         ItemData        =   "frmSAConsole.frx":13EC
         Left            =   -70635
         List            =   "frmSAConsole.frx":1403
         Style           =   2  'Dropdown List
         TabIndex        =   317
         TabStop         =   0   'False
         ToolTipText     =   "Select Heavy Weapon"
         Top             =   6660
         Width           =   1920
      End
      Begin VB.ComboBox cboWeapons 
         Height          =   315
         Index           =   7
         ItemData        =   "frmSAConsole.frx":144A
         Left            =   -70635
         List            =   "frmSAConsole.frx":1461
         Style           =   2  'Dropdown List
         TabIndex        =   316
         TabStop         =   0   'False
         ToolTipText     =   "Select Projectile"
         Top             =   6975
         Width           =   1920
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   0
         Left            =   7980
         TabIndex        =   306
         Tag             =   "Denise"
         Top             =   4605
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Denise Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   1
         Left            =   7980
         TabIndex        =   307
         Tag             =   "Michelle"
         Top             =   5220
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Michelle Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   2
         Left            =   7980
         TabIndex        =   308
         Tag             =   "Helena"
         Top             =   5835
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Helena Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   3
         Left            =   7980
         TabIndex        =   309
         Tag             =   "Katie"
         Top             =   6450
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Katie Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   4
         Left            =   7980
         TabIndex        =   310
         Tag             =   "Barbara"
         Top             =   7065
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Barbara Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin GTASAControlCenter.GTASAStat oGFStats 
         Height          =   555
         Index           =   5
         Left            =   7980
         TabIndex        =   311
         Tag             =   "Millie"
         Top             =   7680
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "Teleport"
         ButtonTip       =   "Click to Set Relevant Stats and Teleport to GF Location"
         ButtonVal       =   0
         ScrollMax       =   100
         CaptionFormat   =   "Millie Progress ([N]%):"
         CheckboxTip     =   "Check to Lock Progress"
      End
      Begin VB.HScrollBar scrGameSpeed 
         Height          =   240
         Index           =   0
         LargeChange     =   10
         Left            =   8460
         Max             =   90
         Min             =   -92
         TabIndex        =   109
         Top             =   2905
         Width           =   3015
      End
      Begin VB.CommandButton cmdGameSpeed 
         Caption         =   "100%"
         Height          =   270
         Index           =   0
         Left            =   10875
         TabIndex        =   312
         ToolTipText     =   "Set Clock to Normal Speed"
         Top             =   2660
         Width           =   600
      End
      Begin VB.CommandButton cmdGameSpeed 
         Caption         =   "6%"
         Height          =   270
         Index           =   3
         Left            =   10440
         TabIndex        =   313
         ToolTipText     =   "Real-time Clock"
         Top             =   2660
         Width           =   450
      End
      Begin VB.HScrollBar scrDateTime 
         Height          =   240
         LargeChange     =   60
         Left            =   8460
         Max             =   1439
         Min             =   -1439
         TabIndex        =   315
         Top             =   2325
         Width           =   3015
      End
      Begin VB.CommandButton cmdGameSpeed 
         Caption         =   "0%"
         Height          =   270
         Index           =   2
         Left            =   10005
         TabIndex        =   314
         ToolTipText     =   "Stop Clock"
         Top             =   2660
         Width           =   450
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Automatically restart car when stalled"
         Height          =   195
         Index           =   7
         Left            =   300
         TabIndex        =   305
         TabStop         =   0   'False
         ToolTipText     =   "Check to automatically restart car when it is stalled"
         Top             =   4890
         Width           =   3300
      End
      Begin VB.ComboBox cboWeather 
         Height          =   315
         ItemData        =   "frmSAConsole.frx":14A4
         Left            =   8235
         List            =   "frmSAConsole.frx":1556
         Style           =   2  'Dropdown List
         TabIndex        =   303
         ToolTipText     =   "Pick a weather so set game weather"
         Top             =   4020
         Width           =   3240
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   7
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   113
         TabStop         =   0   'False
         Top             =   7380
         Width           =   3195
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   6
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   107
         TabStop         =   0   'False
         Top             =   6765
         Width           =   3195
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   5
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   108
         TabStop         =   0   'False
         Top             =   6150
         Width           =   3195
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   4
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   112
         TabStop         =   0   'False
         Top             =   5535
         Width           =   3195
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   3
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   111
         TabStop         =   0   'False
         Top             =   4920
         Width           =   3195
      End
      Begin VB.CommandButton cmdSpawnCar 
         Caption         =   "Pick"
         Height          =   315
         Index           =   1
         Left            =   2760
         TabIndex        =   267
         ToolTipText     =   "Pick a Vehicle to Spawn"
         Top             =   7950
         Width           =   975
      End
      Begin VB.ComboBox cboSpawnCar 
         Height          =   315
         Left            =   285
         Style           =   2  'Dropdown List
         TabIndex        =   266
         ToolTipText     =   "Select a Vehicle to Spawn"
         Top             =   7950
         Width           =   2445
      End
      Begin VB.HScrollBar scrGameSpeed 
         Height          =   240
         Index           =   1
         LargeChange     =   10
         Left            =   8460
         Max             =   90
         Min             =   -90
         TabIndex        =   106
         Top             =   3487
         Width           =   3015
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   2
         LargeChange     =   10
         Left            =   4305
         Max             =   2000
         Min             =   -2000
         TabIndex        =   110
         TabStop         =   0   'False
         Top             =   4305
         Width           =   3195
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   13
         Left            =   -65310
         TabIndex        =   265
         Tag             =   "Fireproof"
         Top             =   3195
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   661
         Caption         =   "Fireproof"
         CheatTip        =   "Click to toggle 'Fireproof Player' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   12
         Left            =   -67080
         TabIndex        =   264
         Tag             =   "InfiniteRun"
         Top             =   3195
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   661
         Caption         =   "Infinite Run"
         CheatTip        =   "Click to toggle 'Infinite Run' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   11
         Left            =   -65310
         TabIndex        =   263
         Tag             =   "CheapCars"
         Top             =   2835
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Cheap Cars"
         CheatTip        =   "Click to toggle 'Traffic is Cheap Cars' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   10
         Left            =   -67080
         TabIndex        =   262
         Tag             =   "FastCars"
         Top             =   2835
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Fast Cars"
         CheatTip        =   "Click to toggle 'Traffic is Fast Cars' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   9
         Left            =   -65310
         TabIndex        =   261
         Tag             =   "MaxSexAppeal"
         Top             =   2475
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Max Sex Appeal"
         CheatTip        =   "Click to toggle 'Max Sex Appeal' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   8
         Left            =   -67080
         TabIndex        =   260
         Tag             =   "MaxRespect"
         Top             =   2475
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Max Respect"
         CheatTip        =   "Click to toggle 'Max Respect' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   7
         Left            =   -65310
         TabIndex        =   259
         Tag             =   "MegaJump"
         Top             =   2115
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Mega Jump"
         CheatTip        =   "Click to toggle 'Mega Jump' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   6
         Left            =   -67080
         TabIndex        =   258
         Tag             =   "MegaPunch"
         Top             =   2115
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Mega Punch"
         CheatTip        =   "Click to toggle 'Mega Punch' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   5
         Left            =   -65310
         TabIndex        =   257
         Tag             =   "TankCheat"
         Top             =   1755
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Tank Mode"
         CheatTip        =   "Click to toggle 'Tank Mode' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   4
         Left            =   -67080
         TabIndex        =   256
         Tag             =   "InfAmmo"
         Top             =   1755
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Infinite Ammo"
         CheatTip        =   "Click to toggle 'Infinite Ammo + No Reload' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   3
         Left            =   -65310
         TabIndex        =   255
         Tag             =   "InfOxygen"
         Top             =   1395
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Infinite Oxygen"
         CheatTip        =   "Click to toggle 'Infinte Oxygen' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   2
         Left            =   -67080
         TabIndex        =   254
         Tag             =   "InfHealth"
         Top             =   1395
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Infinite Health"
         CheatTip        =   "Click to toggle 'Infinite Health' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   1
         Left            =   -65310
         TabIndex        =   253
         Tag             =   "NeverHungry"
         Top             =   1035
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Never get Hungry"
         CheatTip        =   "Click to toggle 'Never Get Hungry' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   0
         Left            =   -67080
         TabIndex        =   252
         Tag             =   "NeverWanted"
         Top             =   1035
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Never Wanted"
         CheatTip        =   "Click to toggle 'Never Wanted' On and Off"
      End
      Begin VB.CheckBox chkSafeCheats 
         Caption         =   "Auto-Clear Status after inserting cheats"
         Height          =   405
         Left            =   -67080
         Style           =   1  'Graphical
         TabIndex        =   221
         TabStop         =   0   'False
         ToolTipText     =   "Click to toggle 'Safe Cheats' On and Off (ie. clear 'cheated' status of game after inserting cheats)"
         Top             =   645
         Width           =   3555
      End
      Begin VB.CommandButton cmdMain 
         Caption         =   "Clear Cheated ""Status"" and ""Count"""
         Height          =   480
         Index           =   2
         Left            =   7920
         TabIndex        =   248
         Top             =   1485
         Width           =   3555
      End
      Begin VB.CommandButton cmdMain 
         Caption         =   "Set Money"
         Height          =   480
         Index           =   1
         Left            =   7920
         TabIndex        =   249
         ToolTipText     =   "Click to enter an amount of money to be set as current money."
         Top             =   1020
         Width           =   3555
      End
      Begin VB.CommandButton cmdWeaponStat 
         Caption         =   "Show Detailed Weapon Proficiency Stats"
         Height          =   420
         Left            =   -67080
         TabIndex        =   212
         TabStop         =   0   'False
         Top             =   7207
         Width           =   3555
      End
      Begin VB.CommandButton cmdMain 
         Caption         =   "Re-sync to GTA SA"
         Height          =   480
         Index           =   0
         Left            =   7920
         TabIndex        =   250
         Top             =   555
         Width           =   3555
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   2
         Left            =   -74700
         TabIndex        =   238
         Tag             =   "FixFat"
         Top             =   2835
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "0"
         ButtonTip       =   "Click to Set Fat to 0"
         ButtonVal       =   0
         CaptionFormat   =   "Current Fat Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   1
         Left            =   -74700
         TabIndex        =   237
         Tag             =   "FixHealth"
         Top             =   2220
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "400"
         ButtonTip       =   "Click to Set Health to 400"
         CaptionFormat   =   "Current Health Level ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   0
         Left            =   -74700
         TabIndex        =   236
         Tag             =   "FixArmor"
         Top             =   1605
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonCaption   =   "400"
         ButtonTip       =   "Click to Set Armot to 400"
         CaptionFormat   =   "Current Armor Level ([N]):"
      End
      Begin VB.CommandButton cmdStopPed 
         Caption         =   "Stop All Speed (Freeze Player)"
         Height          =   375
         Index           =   3
         Left            =   -70935
         TabIndex        =   235
         TabStop         =   0   'False
         ToolTipText     =   "Stop All Ped Speed"
         Top             =   2355
         Width           =   3435
      End
      Begin VB.HScrollBar scrPedSpeed 
         Height          =   240
         Index           =   0
         LargeChange     =   10
         Left            =   -70695
         Max             =   2000
         Min             =   -2000
         TabIndex        =   231
         TabStop         =   0   'False
         Top             =   3060
         Width           =   3195
      End
      Begin VB.HScrollBar scrPedSpeed 
         Height          =   240
         Index           =   1
         LargeChange     =   10
         Left            =   -70695
         Max             =   2000
         Min             =   -2000
         TabIndex        =   230
         TabStop         =   0   'False
         Top             =   3555
         Width           =   3195
      End
      Begin VB.HScrollBar scrPedSpeed 
         Height          =   240
         Index           =   2
         LargeChange     =   10
         Left            =   -70695
         Max             =   2000
         Min             =   -2000
         TabIndex        =   229
         TabStop         =   0   'False
         Top             =   4050
         Width           =   3195
      End
      Begin VB.CommandButton cmdStopPed 
         Caption         =   "Stop"
         Height          =   255
         Index           =   2
         Left            =   -68370
         TabIndex        =   228
         TabStop         =   0   'False
         ToolTipText     =   "Stop Z Speed (Up-Down Dimension)"
         Top             =   3810
         Width           =   870
      End
      Begin VB.CommandButton cmdStopPed 
         Caption         =   "Stop"
         Height          =   255
         Index           =   1
         Left            =   -68370
         TabIndex        =   227
         TabStop         =   0   'False
         ToolTipText     =   "Stop Y Speed (East-West Dimension)"
         Top             =   3315
         Width           =   870
      End
      Begin VB.CommandButton cmdStopPed 
         Caption         =   "Stop"
         Height          =   255
         Index           =   0
         Left            =   -68370
         TabIndex        =   226
         TabStop         =   0   'False
         ToolTipText     =   "Stop X Speed (North-South Dimension)"
         Top             =   2820
         Width           =   870
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   0
         Left            =   6630
         TabIndex        =   129
         TabStop         =   0   'False
         ToolTipText     =   "Stop X Speed (North-South Dimension)"
         Top             =   4065
         Width           =   870
      End
      Begin VB.CheckBox chkDontBurn 
         Caption         =   "do not Explode"
         Height          =   480
         Index           =   1
         Left            =   5700
         Style           =   1  'Graphical
         TabIndex        =   114
         TabStop         =   0   'False
         ToolTipText     =   "Lock Burn Timer to 0, so that car can burn, but not explode"
         Top             =   3345
         Width           =   1800
      End
      Begin VB.CheckBox chkDontBurn 
         Caption         =   "do not Burn"
         Height          =   480
         Index           =   0
         Left            =   4080
         Style           =   1  'Graphical
         TabIndex        =   115
         TabStop         =   0   'False
         ToolTipText     =   "Auto-Repair Damage if car is burning"
         Top             =   3345
         Width           =   1635
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop All Spin"
         Height          =   480
         Index           =   7
         Left            =   5700
         TabIndex        =   116
         TabStop         =   0   'False
         ToolTipText     =   "Stop All Spins"
         Top             =   2880
         Width           =   1800
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop All Speed"
         Height          =   480
         Index           =   6
         Left            =   4080
         TabIndex        =   117
         TabStop         =   0   'False
         ToolTipText     =   "Stop All Speeds"
         Top             =   2880
         Width           =   1635
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Freeze Car"
         Height          =   480
         Index           =   8
         Left            =   5700
         TabIndex        =   118
         TabStop         =   0   'False
         ToolTipText     =   "Stop All movement of the car"
         Top             =   2415
         Width           =   1800
      End
      Begin VB.CommandButton cmdFlipCar 
         Caption         =   "Flip over"
         Height          =   480
         Left            =   4080
         TabIndex        =   119
         TabStop         =   0   'False
         ToolTipText     =   "Flip car over (on to 4 wheels and back)"
         Top             =   2415
         Width           =   1635
      End
      Begin GTASAControlCenter.GTASADirection oCarStart 
         Height          =   1815
         Left            =   5685
         TabIndex        =   223
         ToolTipText     =   "Set Car direction and kickstart with selected speed."
         Top             =   555
         Width           =   1815
         _ExtentX        =   3201
         _ExtentY        =   3201
         ButtonCaption   =   "Kickstart"
         HasScroller     =   -1  'True
         Caption         =   "Kick Start:"
      End
      Begin GTASAControlCenter.GTASADirection oCarDirection 
         Height          =   1785
         Left            =   4065
         TabIndex        =   222
         ToolTipText     =   "Place Car to selected Direction"
         Top             =   555
         Width           =   1575
         _ExtentX        =   2778
         _ExtentY        =   3149
      End
      Begin VB.CheckBox chkPedSpecs 
         Caption         =   "Explosion"
         Height          =   195
         Index           =   0
         Left            =   -74580
         TabIndex        =   218
         TabStop         =   0   'False
         ToolTipText     =   "Explosion-proof"
         Top             =   1215
         Width           =   990
      End
      Begin VB.CheckBox chkFixPedSpecs 
         Caption         =   "Prevent Player taking damage from:"
         Height          =   195
         Left            =   -74700
         TabIndex        =   217
         TabStop         =   0   'False
         ToolTipText     =   "Check to Lock selected Ped Specialities"
         Top             =   870
         Width           =   3345
      End
      Begin VB.CheckBox chkPedSpecs 
         Caption         =   "Collision"
         Height          =   195
         Index           =   1
         Left            =   -73590
         TabIndex        =   216
         TabStop         =   0   'False
         ToolTipText     =   "Damage-proof"
         Top             =   1215
         Width           =   945
      End
      Begin VB.CheckBox chkPedSpecs 
         Caption         =   "Bullet"
         Height          =   195
         Index           =   2
         Left            =   -72615
         TabIndex        =   215
         TabStop         =   0   'False
         ToolTipText     =   "Bullet-proof"
         Top             =   1215
         Width           =   705
      End
      Begin VB.CheckBox chkPedSpecs 
         Caption         =   "Fire"
         Height          =   195
         Index           =   3
         Left            =   -71850
         TabIndex        =   214
         TabStop         =   0   'False
         ToolTipText     =   "Flame-proof"
         Top             =   1215
         Width           =   705
      End
      Begin VB.CommandButton cmdPedMaxStat 
         Caption         =   "Max"
         Height          =   270
         Index           =   5
         Left            =   -64230
         TabIndex        =   213
         TabStop         =   0   'False
         Top             =   6945
         Width           =   705
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Prevent Wheel Damage (Car and Trailer)"
         Height          =   195
         Index           =   2
         Left            =   300
         TabIndex        =   147
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock Radio Station"
         Top             =   4140
         Width           =   3225
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   8
         LargeChange     =   100
         Left            =   555
         Max             =   1000
         TabIndex        =   146
         TabStop         =   0   'False
         Top             =   3030
         Width           =   3120
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Engine health (100%):"
         Height          =   195
         Index           =   3
         Left            =   300
         TabIndex        =   144
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock Engine Damage"
         Top             =   1605
         Width           =   2685
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   0
         LargeChange     =   10
         Left            =   555
         Max             =   4000
         TabIndex        =   143
         TabStop         =   0   'False
         Top             =   1860
         Value           =   1000
         Width           =   3120
      End
      Begin VB.PictureBox picMajor 
         Height          =   285
         Left            =   1650
         ScaleHeight     =   225
         ScaleWidth      =   660
         TabIndex        =   141
         TabStop         =   0   'False
         ToolTipText     =   "Doubleclick to change"
         Top             =   3720
         Width           =   720
         Begin VB.CheckBox chkMajorLock 
            Height          =   195
            Left            =   420
            TabIndex        =   142
            TabStop         =   0   'False
            ToolTipText     =   "Lock Major color"
            Top             =   15
            Width           =   195
         End
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Car Color:"
         Height          =   195
         Index           =   5
         Left            =   300
         TabIndex        =   140
         TabStop         =   0   'False
         Top             =   3765
         Width           =   1290
      End
      Begin VB.PictureBox picMinor 
         Height          =   285
         Left            =   2505
         ScaleHeight     =   225
         ScaleWidth      =   660
         TabIndex        =   138
         TabStop         =   0   'False
         ToolTipText     =   "Doubleclick to change"
         Top             =   3720
         Width           =   720
         Begin VB.CheckBox chkMinorLock 
            Height          =   195
            Left            =   435
            TabIndex        =   139
            TabStop         =   0   'False
            ToolTipText     =   "Lock Minor color"
            Top             =   15
            Width           =   195
         End
      End
      Begin VB.OptionButton optCarDoors 
         Caption         =   "open"
         Height          =   195
         Index           =   0
         Left            =   1635
         TabIndex        =   137
         TabStop         =   0   'False
         ToolTipText     =   "Select to unlock car doors"
         Top             =   3390
         Value           =   -1  'True
         Width           =   750
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Car Doors:"
         Height          =   195
         Index           =   1
         Left            =   300
         TabIndex        =   136
         TabStop         =   0   'False
         ToolTipText     =   "Check to Auto-lock/unlock car doors"
         Top             =   3390
         Width           =   1290
      End
      Begin VB.CheckBox chkCarSpecs 
         Caption         =   "Fire"
         Height          =   195
         Index           =   3
         Left            =   3150
         TabIndex        =   135
         TabStop         =   0   'False
         ToolTipText     =   "Flame-proof"
         Top             =   1215
         Width           =   705
      End
      Begin VB.CheckBox chkCarSpecs 
         Caption         =   "Bullet"
         Height          =   195
         Index           =   2
         Left            =   2385
         TabIndex        =   134
         TabStop         =   0   'False
         ToolTipText     =   "Bullet-proof"
         Top             =   1215
         Width           =   705
      End
      Begin VB.CheckBox chkCarSpecs 
         Caption         =   "Collision"
         Height          =   195
         Index           =   1
         Left            =   1410
         TabIndex        =   133
         TabStop         =   0   'False
         ToolTipText     =   "Damage-proof"
         Top             =   1215
         Width           =   945
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Prevent Car taking damage from:"
         Height          =   195
         Index           =   0
         Left            =   300
         TabIndex        =   132
         TabStop         =   0   'False
         ToolTipText     =   "Check to Lock selected Car Specialities"
         Top             =   870
         Width           =   3345
      End
      Begin VB.CheckBox chkCarSpecs 
         Caption         =   "Explosion"
         Height          =   195
         Index           =   0
         Left            =   420
         TabIndex        =   131
         TabStop         =   0   'False
         ToolTipText     =   "Explosion-proof"
         Top             =   1215
         Width           =   990
      End
      Begin VB.OptionButton optCarDoors 
         Caption         =   "locked"
         Height          =   195
         Index           =   1
         Left            =   2490
         TabIndex        =   130
         TabStop         =   0   'False
         ToolTipText     =   "Select to lock car doors"
         Top             =   3390
         Width           =   810
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   1
         Left            =   6630
         TabIndex        =   128
         TabStop         =   0   'False
         ToolTipText     =   "Stop Y Speed (East-West Dimension)"
         Top             =   4680
         Width           =   870
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   2
         Left            =   6630
         TabIndex        =   127
         TabStop         =   0   'False
         ToolTipText     =   "Stop Z Speed (Up-Down Dimension)"
         Top             =   5295
         Width           =   870
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   3
         Left            =   6630
         TabIndex        =   126
         TabStop         =   0   'False
         ToolTipText     =   "Stop X Spin (North-South Dimension)"
         Top             =   5910
         Width           =   870
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   4
         Left            =   6630
         TabIndex        =   125
         TabStop         =   0   'False
         ToolTipText     =   "Stop Y Spin (East-West Dimension)"
         Top             =   6525
         Width           =   870
      End
      Begin VB.CommandButton cmdStopCar 
         Caption         =   "Stop"
         Height          =   255
         Index           =   5
         Left            =   6630
         TabIndex        =   124
         TabStop         =   0   'False
         ToolTipText     =   "Stop Z Spin (Clock-Counterclock Dimension)"
         Top             =   7140
         Width           =   870
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Automatically stop car-alarms"
         Height          =   195
         Index           =   6
         Left            =   300
         TabIndex        =   123
         TabStop         =   0   'False
         Top             =   4515
         Width           =   3300
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Flight Assistance (0%)"
         Height          =   225
         Index           =   8
         Left            =   300
         TabIndex        =   122
         TabStop         =   0   'False
         ToolTipText     =   "Autoincrease Z Speed (100% = 0.01 g)"
         Top             =   2775
         Width           =   2685
      End
      Begin VB.HScrollBar scrCarDynamics 
         Height          =   240
         Index           =   1
         LargeChange     =   100
         Left            =   555
         Max             =   4000
         Min             =   1
         SmallChange     =   10
         TabIndex        =   121
         TabStop         =   0   'False
         Top             =   2415
         Value           =   500
         Width           =   3120
      End
      Begin VB.CommandButton cmd50Ton 
         Caption         =   "Max"
         Height          =   285
         Left            =   2805
         TabIndex        =   120
         Top             =   2145
         Width           =   870
      End
      Begin VB.CommandButton cmdGameSpeed 
         Caption         =   "100%"
         Height          =   270
         Index           =   1
         Left            =   10875
         TabIndex        =   105
         Top             =   3225
         Width           =   600
      End
      Begin VB.CheckBox chkOrgSCM 
         Caption         =   "SCM is NOT modded"
         Height          =   270
         Left            =   -66510
         TabIndex        =   104
         ToolTipText     =   "This is confirmation that Console can write to SCM Memory block"
         Top             =   7650
         Value           =   1  'Checked
         Width           =   3135
      End
      Begin VB.ComboBox cboGTAVersion 
         Height          =   315
         ItemData        =   "frmSAConsole.frx":1A05
         Left            =   -64140
         List            =   "frmSAConsole.frx":1A0F
         TabIndex        =   103
         Text            =   "v1.0"
         ToolTipText     =   "GTA SA Version"
         Top             =   8025
         Width           =   795
      End
      Begin VB.PictureBox picCommandData 
         BackColor       =   &H80000009&
         BorderStyle     =   0  'None
         Height          =   300
         Left            =   -66465
         ScaleHeight     =   300
         ScaleWidth      =   3135
         TabIndex        =   57
         Top             =   2745
         Width           =   3135
         Begin TabDlg.SSTab sstCommandData 
            Height          =   690
            Left            =   -15
            TabIndex        =   58
            TabStop         =   0   'False
            Top             =   -15
            Width           =   4635
            _ExtentX        =   8176
            _ExtentY        =   1217
            _Version        =   393216
            TabOrientation  =   1
            Style           =   1
            Tabs            =   20
            Tab             =   17
            TabsPerRow      =   7
            TabHeight       =   2
            WordWrap        =   0   'False
            ShowFocusRect   =   0   'False
            TabCaption(0)   =   "Armor"
            TabPicture(0)   =   "frmSAConsole.frx":1A1F
            Tab(0).ControlEnabled=   0   'False
            Tab(0).Control(0)=   "lblCommandData(0)"
            Tab(0).Control(1)=   "scrCommandData(0)"
            Tab(0).Control(1).Enabled=   0   'False
            Tab(0).ControlCount=   2
            TabCaption(1)   =   "Health"
            TabPicture(1)   =   "frmSAConsole.frx":1A3B
            Tab(1).ControlEnabled=   0   'False
            Tab(1).Control(0)=   "lblCommandData(1)"
            Tab(1).Control(1)=   "scrCommandData(1)"
            Tab(1).Control(1).Enabled=   0   'False
            Tab(1).ControlCount=   2
            TabCaption(2)   =   "Wanted"
            TabPicture(2)   =   "frmSAConsole.frx":1A57
            Tab(2).ControlEnabled=   0   'False
            Tab(2).Control(0)=   "scrCommandData(2)"
            Tab(2).Control(1)=   "lblCommandData(2)"
            Tab(2).ControlCount=   2
            TabCaption(3)   =   "Weapons"
            TabPicture(3)   =   "frmSAConsole.frx":1A73
            Tab(3).ControlEnabled=   0   'False
            Tab(3).Control(0)=   "txtCommandWeaponAmmo"
            Tab(3).Control(1)=   "cboCommandWeapon"
            Tab(3).Control(1).Enabled=   0   'False
            Tab(3).Control(2)=   "lblCommandWeapon(1)"
            Tab(3).Control(3)=   "lblCommandWeapon(0)"
            Tab(3).ControlCount=   4
            TabCaption(4)   =   "WeaponSpecs"
            TabPicture(4)   =   "frmSAConsole.frx":1A8F
            Tab(4).ControlEnabled=   0   'False
            Tab(4).Control(0)=   "chkWeaponSpecs(2)"
            Tab(4).Control(0).Enabled=   0   'False
            Tab(4).Control(1)=   "chkWeaponSpecs(1)"
            Tab(4).Control(1).Enabled=   0   'False
            Tab(4).Control(2)=   "txtWeaponSpecs(1)"
            Tab(4).Control(2).Enabled=   0   'False
            Tab(4).Control(3)=   "chkWeaponSpecs(0)"
            Tab(4).Control(3).Enabled=   0   'False
            Tab(4).Control(4)=   "txtWeaponSpecs(0)"
            Tab(4).Control(4).Enabled=   0   'False
            Tab(4).ControlCount=   5
            TabCaption(5)   =   "EP/DP/BP/FP"
            TabPicture(5)   =   "frmSAConsole.frx":1AAB
            Tab(5).ControlEnabled=   0   'False
            Tab(5).Control(0)=   "chkCarSpecsCommand(3)"
            Tab(5).Control(0).Enabled=   0   'False
            Tab(5).Control(1)=   "chkCarSpecsCommand(2)"
            Tab(5).Control(1).Enabled=   0   'False
            Tab(5).Control(2)=   "chkCarSpecsCommand(1)"
            Tab(5).Control(2).Enabled=   0   'False
            Tab(5).Control(3)=   "chkCarSpecsCommand(0)"
            Tab(5).Control(3).Enabled=   0   'False
            Tab(5).ControlCount=   4
            TabCaption(6)   =   "open/locked"
            TabPicture(6)   =   "frmSAConsole.frx":1AC7
            Tab(6).ControlEnabled=   0   'False
            Tab(6).Control(0)=   "optCarDoorsCommand(0)"
            Tab(6).Control(0).Enabled=   0   'False
            Tab(6).Control(1)=   "optCarDoorsCommand(1)"
            Tab(6).Control(1).Enabled=   0   'False
            Tab(6).ControlCount=   2
            TabCaption(7)   =   "Weather"
            TabPicture(7)   =   "frmSAConsole.frx":1AE3
            Tab(7).ControlEnabled=   0   'False
            Tab(7).Control(0)=   "cboCommandWeather"
            Tab(7).Control(0).Enabled=   0   'False
            Tab(7).ControlCount=   1
            TabCaption(8)   =   "EngineDamage"
            TabPicture(8)   =   "frmSAConsole.frx":1AFF
            Tab(8).ControlEnabled=   0   'False
            Tab(8).Control(0)=   "scrCommandData(8)"
            Tab(8).Control(0).Enabled=   0   'False
            Tab(8).Control(1)=   "lblCommandData(8)"
            Tab(8).ControlCount=   2
            TabCaption(9)   =   "CarWeight"
            TabPicture(9)   =   "frmSAConsole.frx":1B1B
            Tab(9).ControlEnabled=   0   'False
            Tab(9).Control(0)=   "scrCommandData(9)"
            Tab(9).Control(0).Enabled=   0   'False
            Tab(9).Control(1)=   "lblCommandData(9)"
            Tab(9).ControlCount=   2
            TabCaption(10)  =   "Colors"
            TabPicture(10)  =   "frmSAConsole.frx":1B37
            Tab(10).ControlEnabled=   0   'False
            Tab(10).Control(0)=   "picColorCommand(0)"
            Tab(10).Control(1)=   "picColorCommand(1)"
            Tab(10).Control(2)=   "lblCommandData(4)"
            Tab(10).Control(3)=   "lblCommandData(3)"
            Tab(10).ControlCount=   4
            TabCaption(11)  =   "Directions"
            TabPicture(11)  =   "frmSAConsole.frx":1B53
            Tab(11).ControlEnabled=   0   'False
            Tab(11).Control(0)=   "cboCommandDirection"
            Tab(11).Control(0).Enabled=   0   'False
            Tab(11).Control(1)=   "scrCommandData(11)"
            Tab(11).Control(1).Enabled=   0   'False
            Tab(11).Control(2)=   "lblCommandData(11)"
            Tab(11).ControlCount=   3
            TabCaption(12)  =   "CarList"
            TabPicture(12)  =   "frmSAConsole.frx":1B6F
            Tab(12).ControlEnabled=   0   'False
            Tab(12).Control(0)=   "cboCommandParkedCar"
            Tab(12).Control(0).Enabled=   0   'False
            Tab(12).Control(1)=   "lblCommandData(5)"
            Tab(12).ControlCount=   2
            TabCaption(13)  =   "CarDynamics"
            TabPicture(13)  =   "frmSAConsole.frx":1B8B
            Tab(13).ControlEnabled=   0   'False
            Tab(13).Control(0)=   "scrCommandData(13)"
            Tab(13).Control(0).Enabled=   0   'False
            Tab(13).Control(1)=   "lblCommandData(13)"
            Tab(13).ControlCount=   2
            TabCaption(14)  =   "MissionTime"
            TabPicture(14)  =   "frmSAConsole.frx":1BA7
            Tab(14).ControlEnabled=   0   'False
            Tab(14).Control(0)=   "scrCommandData(14)"
            Tab(14).Control(0).Enabled=   0   'False
            Tab(14).Control(1)=   "lblCommandData(14)"
            Tab(14).ControlCount=   2
            TabCaption(15)  =   "CriminalsKilled"
            TabPicture(15)  =   "frmSAConsole.frx":1BC3
            Tab(15).ControlEnabled=   0   'False
            Tab(15).Control(0)=   "scrCommandData(15)"
            Tab(15).Control(0).Enabled=   0   'False
            Tab(15).Control(1)=   "lblCommandData(15)"
            Tab(15).ControlCount=   2
            TabCaption(16)  =   "ON/OFF"
            TabPicture(16)  =   "frmSAConsole.frx":1BDF
            Tab(16).ControlEnabled=   0   'False
            Tab(16).Control(0)=   "optCommandOnOff(1)"
            Tab(16).Control(0).Enabled=   0   'False
            Tab(16).Control(1)=   "optCommandOnOff(0)"
            Tab(16).Control(1).Enabled=   0   'False
            Tab(16).ControlCount=   2
            TabCaption(17)  =   "NONE"
            TabPicture(17)  =   "frmSAConsole.frx":1BFB
            Tab(17).ControlEnabled=   -1  'True
            Tab(17).Control(0)=   "lblCommandData(17)"
            Tab(17).Control(0).Enabled=   0   'False
            Tab(17).ControlCount=   1
            TabCaption(18)  =   "MarkLocations"
            TabPicture(18)  =   "frmSAConsole.frx":1C17
            Tab(18).ControlEnabled=   0   'False
            Tab(18).Control(0)=   "cboCommandMarkupLocs"
            Tab(18).ControlCount=   1
            TabCaption(19)  =   "TurnCar"
            TabPicture(19)  =   "frmSAConsole.frx":1C33
            Tab(19).ControlEnabled=   0   'False
            Tab(19).Control(0)=   "lblCommandData(19)"
            Tab(19).Control(1)=   "scrCommandData(19)"
            Tab(19).Control(1).Enabled=   0   'False
            Tab(19).ControlCount=   2
            Begin VB.TextBox txtCommandWeaponAmmo 
               Height          =   285
               Left            =   -72480
               MaxLength       =   5
               TabIndex        =   373
               Text            =   "0"
               Top             =   30
               Width           =   615
            End
            Begin VB.ComboBox cboCommandMarkupLocs 
               Height          =   315
               ItemData        =   "frmSAConsole.frx":1C4F
               Left            =   -74730
               List            =   "frmSAConsole.frx":1C72
               Style           =   2  'Dropdown List
               TabIndex        =   275
               Top             =   0
               Width           =   2640
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   19
               LargeChange     =   10
               Left            =   -73830
               Max             =   180
               TabIndex        =   89
               TabStop         =   0   'False
               Top             =   30
               Width           =   1905
            End
            Begin VB.OptionButton optCommandOnOff 
               Caption         =   "OFF"
               Height          =   240
               Index           =   1
               Left            =   -73875
               TabIndex        =   88
               TabStop         =   0   'False
               Top             =   45
               Width           =   600
            End
            Begin VB.OptionButton optCommandOnOff 
               Caption         =   "ON"
               Height          =   240
               Index           =   0
               Left            =   -74940
               TabIndex        =   87
               TabStop         =   0   'False
               Top             =   45
               Value           =   -1  'True
               Width           =   600
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   15
               LargeChange     =   10
               Left            =   -74325
               Max             =   100
               TabIndex        =   86
               TabStop         =   0   'False
               Top             =   30
               Width           =   2400
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   14
               LargeChange     =   10
               Left            =   -74325
               Max             =   90
               Min             =   -92
               TabIndex        =   85
               TabStop         =   0   'False
               Top             =   30
               Width           =   2400
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   13
               LargeChange     =   10
               Left            =   -74325
               Max             =   2000
               Min             =   -2000
               TabIndex        =   84
               TabStop         =   0   'False
               Top             =   45
               Width           =   2400
            End
            Begin VB.ComboBox cboCommandParkedCar 
               Height          =   315
               ItemData        =   "frmSAConsole.frx":1D48
               Left            =   -73785
               List            =   "frmSAConsole.frx":1D4A
               TabIndex        =   83
               TabStop         =   0   'False
               ToolTipText     =   "(Note that not all cars are avaliable for all Parking locations)"
               Top             =   0
               Width           =   1890
            End
            Begin VB.ComboBox cboCommandDirection 
               BeginProperty Font 
                  Name            =   "Small Fonts"
                  Size            =   6.75
                  Charset         =   0
                  Weight          =   400
                  Underline       =   0   'False
                  Italic          =   0   'False
                  Strikethrough   =   0   'False
               EndProperty
               Height          =   285
               ItemData        =   "frmSAConsole.frx":1D4C
               Left            =   -74940
               List            =   "frmSAConsole.frx":1D68
               TabIndex        =   82
               TabStop         =   0   'False
               Top             =   30
               Width           =   1155
            End
            Begin VB.PictureBox picColorCommand 
               BackColor       =   &H00000000&
               Height          =   285
               Index           =   0
               Left            =   -74460
               ScaleHeight     =   225
               ScaleWidth      =   870
               TabIndex        =   80
               Tag             =   "0"
               ToolTipText     =   "Doubleclick to change"
               Top             =   30
               Width           =   930
               Begin VB.CheckBox chkCommandColorLock 
                  Height          =   195
                  Index           =   0
                  Left            =   630
                  TabIndex        =   81
                  TabStop         =   0   'False
                  ToolTipText     =   "Lock Major color"
                  Top             =   15
                  Width           =   195
               End
            End
            Begin VB.PictureBox picColorCommand 
               BackColor       =   &H00000000&
               Height          =   285
               Index           =   1
               Left            =   -72870
               ScaleHeight     =   225
               ScaleWidth      =   870
               TabIndex        =   78
               Tag             =   "0"
               ToolTipText     =   "Doubleclick to change"
               Top             =   30
               Width           =   930
               Begin VB.CheckBox chkCommandColorLock 
                  Height          =   195
                  Index           =   1
                  Left            =   630
                  TabIndex        =   79
                  TabStop         =   0   'False
                  ToolTipText     =   "Lock Minor color"
                  Top             =   15
                  Width           =   195
               End
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   9
               LargeChange     =   100
               Left            =   -74085
               Max             =   4000
               Min             =   1
               SmallChange     =   10
               TabIndex        =   77
               TabStop         =   0   'False
               Top             =   45
               Value           =   255
               Width           =   2160
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   8
               LargeChange     =   10
               Left            =   -74325
               Max             =   1000
               TabIndex        =   76
               TabStop         =   0   'False
               Top             =   45
               Value           =   1000
               Width           =   2400
            End
            Begin VB.ComboBox cboCommandWeather 
               Height          =   315
               ItemData        =   "frmSAConsole.frx":1DB6
               Left            =   -74940
               List            =   "frmSAConsole.frx":1E68
               Style           =   2  'Dropdown List
               TabIndex        =   75
               TabStop         =   0   'False
               Top             =   0
               Width           =   3045
            End
            Begin VB.OptionButton optCarDoorsCommand 
               Caption         =   "open"
               Height          =   285
               Index           =   0
               Left            =   -74955
               TabIndex        =   74
               TabStop         =   0   'False
               Top             =   30
               Width           =   930
            End
            Begin VB.OptionButton optCarDoorsCommand 
               Caption         =   "locked"
               Height          =   285
               Index           =   1
               Left            =   -73890
               TabIndex        =   73
               TabStop         =   0   'False
               Top             =   30
               Width           =   825
            End
            Begin VB.CheckBox chkCarSpecsCommand 
               Caption         =   "FP"
               Height          =   285
               Index           =   3
               Left            =   -73095
               TabIndex        =   72
               TabStop         =   0   'False
               ToolTipText     =   "Flame-proof"
               Top             =   30
               Width           =   525
            End
            Begin VB.CheckBox chkCarSpecsCommand 
               Caption         =   "BP"
               Height          =   285
               Index           =   2
               Left            =   -73710
               TabIndex        =   71
               TabStop         =   0   'False
               ToolTipText     =   "Bullet-proof"
               Top             =   30
               Width           =   525
            End
            Begin VB.CheckBox chkCarSpecsCommand 
               Caption         =   "DP"
               Height          =   285
               Index           =   1
               Left            =   -74325
               TabIndex        =   70
               TabStop         =   0   'False
               ToolTipText     =   "Damage-proof"
               Top             =   30
               Width           =   525
            End
            Begin VB.CheckBox chkCarSpecsCommand 
               Caption         =   "EP"
               Height          =   285
               Index           =   0
               Left            =   -74940
               TabIndex        =   69
               TabStop         =   0   'False
               ToolTipText     =   "Explosion-proof"
               Top             =   30
               Width           =   525
            End
            Begin VB.CheckBox chkWeaponSpecs 
               Height          =   285
               Index           =   2
               Left            =   -72105
               TabIndex        =   68
               TabStop         =   0   'False
               ToolTipText     =   "Check to Lock Loaded Ammo (avoid reload sequences)"
               Top             =   30
               Width           =   195
            End
            Begin VB.CheckBox chkWeaponSpecs 
               Height          =   285
               Index           =   1
               Left            =   -73275
               TabIndex        =   67
               TabStop         =   0   'False
               ToolTipText     =   "Check to Lock Total Ammo"
               Top             =   30
               Width           =   195
            End
            Begin VB.TextBox txtWeaponSpecs 
               Height          =   285
               Index           =   1
               Left            =   -73005
               TabIndex        =   66
               TabStop         =   0   'False
               ToolTipText     =   "Ammo: Amount Loaded to Weapon"
               Top             =   30
               Width           =   810
            End
            Begin VB.CheckBox chkWeaponSpecs 
               Caption         =   "Carry"
               Height          =   285
               Index           =   0
               Left            =   -74940
               TabIndex        =   65
               TabStop         =   0   'False
               ToolTipText     =   "Check to carry this weapon"
               Top             =   30
               Width           =   735
            End
            Begin VB.TextBox txtWeaponSpecs 
               Height          =   285
               Index           =   0
               Left            =   -74160
               TabIndex        =   64
               TabStop         =   0   'False
               ToolTipText     =   "Ammo: Total amount carried"
               Top             =   30
               Width           =   810
            End
            Begin VB.ComboBox cboCommandWeapon 
               Height          =   315
               ItemData        =   "frmSAConsole.frx":2317
               Left            =   -74595
               List            =   "frmSAConsole.frx":23ED
               Style           =   2  'Dropdown List
               TabIndex        =   63
               TabStop         =   0   'False
               Top             =   0
               Width           =   1620
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   0
               LargeChange     =   10
               Left            =   -74325
               Max             =   999
               TabIndex        =   62
               TabStop         =   0   'False
               Top             =   45
               Value           =   100
               Width           =   2400
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   1
               LargeChange     =   10
               Left            =   -74325
               Max             =   999
               TabIndex        =   61
               TabStop         =   0   'False
               Top             =   45
               Value           =   100
               Width           =   2400
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   2
               Left            =   -74325
               Max             =   6
               TabIndex        =   60
               Top             =   45
               Width           =   2400
            End
            Begin VB.HScrollBar scrCommandData 
               Height          =   225
               Index           =   11
               LargeChange     =   10
               Left            =   -73035
               Max             =   2000
               TabIndex        =   59
               TabStop         =   0   'False
               Top             =   60
               Width           =   1110
            End
            Begin VB.Label lblCommandWeapon 
               Caption         =   "Ammo:"
               Height          =   180
               Index           =   1
               Left            =   -72960
               TabIndex        =   372
               Top             =   60
               Width           =   510
            End
            Begin VB.Label lblCommandWeapon 
               Caption         =   "Give:"
               Height          =   180
               Index           =   0
               Left            =   -74985
               TabIndex        =   371
               Top             =   60
               Width           =   465
            End
            Begin VB.Label lblCommandData 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Select Vehicle:"
               Height          =   195
               Index           =   5
               Left            =   -74895
               TabIndex        =   277
               Top             =   75
               Width           =   1065
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0 Degrees)"
               Height          =   195
               Index           =   19
               Left            =   -74940
               TabIndex        =   102
               Top             =   30
               Width           =   1065
            End
            Begin VB.Label lblCommandData 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "No Additional Data is needed."
               Height          =   195
               Index           =   17
               Left            =   60
               TabIndex        =   101
               Top             =   30
               Width           =   2115
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0)"
               Height          =   195
               Index           =   15
               Left            =   -74940
               TabIndex        =   100
               Top             =   30
               Width           =   630
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(100 %)"
               Height          =   195
               Index           =   14
               Left            =   -74940
               TabIndex        =   99
               Top             =   30
               Width           =   630
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0%)"
               Height          =   195
               Index           =   13
               Left            =   -74940
               TabIndex        =   98
               Top             =   45
               Width           =   615
            End
            Begin VB.Label lblCommandData 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Minor:"
               Height          =   195
               Index           =   4
               Left            =   -73365
               TabIndex        =   97
               Top             =   60
               Width           =   435
            End
            Begin VB.Label lblCommandData 
               AutoSize        =   -1  'True
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "Major:"
               Height          =   195
               Index           =   3
               Left            =   -74940
               TabIndex        =   96
               Top             =   60
               Width           =   435
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(25,5 Tons)"
               Height          =   195
               Index           =   9
               Left            =   -74940
               TabIndex        =   95
               Top             =   45
               Width           =   825
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0%)"
               Height          =   195
               Index           =   8
               Left            =   -74940
               TabIndex        =   94
               Top             =   45
               Width           =   555
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(100)"
               Height          =   195
               Index           =   0
               Left            =   -74940
               TabIndex        =   93
               Top             =   45
               Width           =   555
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(100)"
               Height          =   195
               Index           =   1
               Left            =   -74940
               TabIndex        =   92
               Top             =   45
               Width           =   555
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0)"
               Height          =   195
               Index           =   2
               Left            =   -74940
               TabIndex        =   91
               Top             =   45
               Width           =   555
            End
            Begin VB.Label lblCommandData 
               Alignment       =   2  'Center
               BackColor       =   &H00FFFFFF&
               BackStyle       =   0  'Transparent
               Caption         =   "(0%)"
               Height          =   195
               Index           =   11
               Left            =   -73725
               TabIndex        =   90
               Top             =   60
               Width           =   645
            End
         End
      End
      Begin VB.CheckBox chkFeedback 
         Caption         =   "In-Game Feedback Messages"
         Height          =   270
         Left            =   -66510
         TabIndex        =   56
         TabStop         =   0   'False
         ToolTipText     =   "Check this to receive On-Screen Feedback Messages from Admin-Console"
         Top             =   7320
         Width           =   3135
      End
      Begin VB.ComboBox cboCommands 
         Height          =   315
         Index           =   2
         ItemData        =   "frmSAConsole.frx":25CE
         Left            =   -66465
         List            =   "frmSAConsole.frx":25D0
         TabIndex        =   55
         TabStop         =   0   'False
         Text            =   "cboCommands"
         ToolTipText     =   "Selection of Warp Locations, as in Page ""Locations"""
         Top             =   2280
         Width           =   3135
      End
      Begin VB.ComboBox cboCommands 
         Height          =   315
         Index           =   1
         ItemData        =   "frmSAConsole.frx":25D2
         Left            =   -66465
         List            =   "frmSAConsole.frx":25D4
         TabIndex        =   54
         TabStop         =   0   'False
         Text            =   "cboCommands"
         ToolTipText     =   "Selection list of GTASA cheats, as in Page ""GTASA Cheats"""
         Top             =   1500
         Width           =   3135
      End
      Begin VB.CheckBox chkShortcut 
         Caption         =   "ALT"
         BeginProperty Font 
            Name            =   "Small Fonts"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Index           =   1
         Left            =   -65010
         TabIndex        =   53
         TabStop         =   0   'False
         ToolTipText     =   "ALT+"
         Top             =   3135
         Width           =   585
      End
      Begin VB.CheckBox chkShortcut 
         Caption         =   "CTRL"
         BeginProperty Font 
            Name            =   "Small Fonts"
            Size            =   6.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   210
         Index           =   0
         Left            =   -65730
         TabIndex        =   52
         TabStop         =   0   'False
         ToolTipText     =   "CTRL+"
         Top             =   3135
         Width           =   690
      End
      Begin VB.HScrollBar scrIntervall 
         Height          =   270
         LargeChange     =   100
         Left            =   -66510
         Max             =   500
         Min             =   10
         SmallChange     =   10
         TabIndex        =   51
         TabStop         =   0   'False
         Top             =   6900
         Value           =   10
         Width           =   3135
      End
      Begin VB.ComboBox cboCommands 
         Height          =   315
         Index           =   0
         ItemData        =   "frmSAConsole.frx":25D6
         Left            =   -66465
         List            =   "frmSAConsole.frx":25D8
         TabIndex        =   50
         TabStop         =   0   'False
         Text            =   "cboCommands"
         ToolTipText     =   "GTASA Admin-Console internal commands. (Wait for new version for additional commands)"
         Top             =   750
         Width           =   3135
      End
      Begin VB.ComboBox cboShortcut 
         Height          =   315
         ItemData        =   "frmSAConsole.frx":25DA
         Left            =   -64410
         List            =   "frmSAConsole.frx":25DC
         Style           =   2  'Dropdown List
         TabIndex        =   49
         TabStop         =   0   'False
         ToolTipText     =   "Available Keys as Shortcut"
         Top             =   3060
         Width           =   1080
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Apply changes"
         Height          =   495
         Index           =   0
         Left            =   -66480
         TabIndex        =   48
         TabStop         =   0   'False
         ToolTipText     =   "Apply changes to the selected Shortcut"
         Top             =   3495
         Width           =   3135
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Insert as new Shortcut"
         Height          =   495
         Index           =   1
         Left            =   -66480
         TabIndex        =   47
         TabStop         =   0   'False
         ToolTipText     =   "Insert your Shortcut settings as a new entry to the list"
         Top             =   3990
         Width           =   3135
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Delete selected"
         Height          =   495
         Index           =   2
         Left            =   -66480
         TabIndex        =   46
         TabStop         =   0   'False
         ToolTipText     =   "Delete selected entry from Shortcut list"
         Top             =   4485
         Width           =   3135
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Insert New Group"
         Height          =   495
         Index           =   3
         Left            =   -66480
         TabIndex        =   45
         TabStop         =   0   'False
         ToolTipText     =   "Delete selected entry from Shortcut list"
         Top             =   4980
         Width           =   3135
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Read Shortcuts from Config File"
         Height          =   495
         Index           =   4
         Left            =   -66480
         TabIndex        =   44
         TabStop         =   0   'False
         ToolTipText     =   "Read from config file and re-initialise Treeview"
         Top             =   5475
         Width           =   3135
      End
      Begin VB.CommandButton cmdShortcuts 
         Caption         =   "Save Shortcuts to Config File"
         Height          =   495
         Index           =   5
         Left            =   -66480
         TabIndex        =   43
         TabStop         =   0   'False
         ToolTipText     =   "Save changes on treeview to config file"
         Top             =   5970
         Width           =   3135
      End
      Begin VB.HScrollBar scrLeftRight 
         Height          =   240
         LargeChange     =   100
         Left            =   -74730
         Max             =   3200
         Min             =   -3200
         TabIndex        =   42
         Top             =   8160
         Width           =   7875
      End
      Begin VB.CommandButton cmdCenterMap 
         Caption         =   "#"
         Height          =   240
         Left            =   -74955
         TabIndex        =   41
         ToolTipText     =   "Center Map"
         Top             =   8160
         Width           =   240
      End
      Begin VB.VScrollBar scrTopBottom 
         Height          =   7740
         LargeChange     =   100
         Left            =   -74955
         Max             =   -3200
         Min             =   3200
         TabIndex        =   40
         Top             =   435
         Width           =   240
      End
      Begin VB.PictureBox picLocationControls 
         BorderStyle     =   0  'None
         Height          =   8010
         Left            =   -66795
         ScaleHeight     =   8010
         ScaleWidth      =   3540
         TabIndex        =   18
         Top             =   375
         Width           =   3540
         Begin VB.TextBox txtCoords 
            Height          =   285
            Index           =   3
            Left            =   795
            TabIndex        =   32
            TabStop         =   0   'False
            ToolTipText     =   "Angle (0 to 359)"
            Top             =   870
            Width           =   2700
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Save to Config"
            Height          =   360
            Index           =   7
            Left            =   1740
            TabIndex        =   31
            TabStop         =   0   'False
            ToolTipText     =   "Save changes on treeview to config file"
            Top             =   2565
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Read from Config"
            Height          =   360
            Index           =   6
            Left            =   0
            TabIndex        =   30
            TabStop         =   0   'False
            ToolTipText     =   "Read from config file and re-initialise Treeview"
            Top             =   2565
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "New Group"
            Height          =   360
            Index           =   4
            Left            =   1740
            TabIndex        =   29
            TabStop         =   0   'False
            ToolTipText     =   "Insert New Location Group as Sibling to Selected Group"
            Top             =   2220
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Delete Selected"
            Height          =   360
            Index           =   5
            Left            =   0
            TabIndex        =   28
            TabStop         =   0   'False
            ToolTipText     =   "Delete a Location Group (all Locations within group will be assigned to parent group)"
            Top             =   2220
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Insert as new"
            Height          =   360
            Index           =   2
            Left            =   1740
            TabIndex        =   27
            TabStop         =   0   'False
            ToolTipText     =   "Click to insert this location data as a new entry to treeview"
            Top             =   1875
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Apply changes"
            Height          =   360
            Index           =   1
            Left            =   0
            TabIndex        =   26
            TabStop         =   0   'False
            ToolTipText     =   "Click to assign new Location Data for selected Teleport-Location"
            Top             =   1875
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Teleport"
            Height          =   360
            Index           =   3
            Left            =   1740
            TabIndex        =   25
            TabStop         =   0   'False
            ToolTipText     =   "Teleport to the selected Location"
            Top             =   1530
            Width           =   1755
         End
         Begin VB.CommandButton cmdLocations 
            Caption         =   "Read from GTASA"
            Height          =   360
            Index           =   0
            Left            =   0
            TabIndex        =   24
            TabStop         =   0   'False
            ToolTipText     =   "Click to read position data from GTASA"
            Top             =   1530
            Width           =   1755
         End
         Begin VB.CommandButton cmdMapLoc 
            Caption         =   "Show on Map"
            Height          =   360
            Index           =   0
            Left            =   1740
            TabIndex        =   23
            ToolTipText     =   "Show Manual Location on Map"
            Top             =   1185
            Width           =   1755
         End
         Begin VB.CommandButton cmdMapLoc 
            Caption         =   "Read from Map"
            Height          =   360
            Index           =   1
            Left            =   0
            TabIndex        =   22
            ToolTipText     =   "Read from Manual Location on Map"
            Top             =   1185
            Width           =   1755
         End
         Begin VB.TextBox txtCoords 
            Height          =   285
            Index           =   0
            Left            =   795
            TabIndex        =   21
            TabStop         =   0   'False
            ToolTipText     =   "Placement of Player in North-South Dimension"
            Top             =   15
            Width           =   2700
         End
         Begin VB.TextBox txtCoords 
            Height          =   285
            Index           =   1
            Left            =   795
            TabIndex        =   20
            TabStop         =   0   'False
            ToolTipText     =   "Placement of Player in East-West Dimension"
            Top             =   300
            Width           =   2700
         End
         Begin VB.TextBox txtCoords 
            Height          =   285
            Index           =   2
            Left            =   795
            TabIndex        =   19
            TabStop         =   0   'False
            ToolTipText     =   "Height Placement of Player in relevance to zero point"
            Top             =   585
            Width           =   2700
         End
         Begin MSComctlLib.TreeView tvLocations 
            Height          =   4635
            Left            =   0
            TabIndex        =   33
            Top             =   3345
            Width           =   3495
            _ExtentX        =   6165
            _ExtentY        =   8176
            _Version        =   393217
            HideSelection   =   0   'False
            Indentation     =   353
            LabelEdit       =   1
            Sorted          =   -1  'True
            Style           =   7
            ImageList       =   "iListTvIcons"
            Appearance      =   1
         End
         Begin MSComctlLib.Slider sldZoom 
            Height          =   285
            Left            =   1005
            TabIndex        =   34
            Top             =   2985
            Width           =   2550
            _ExtentX        =   4498
            _ExtentY        =   503
            _Version        =   393216
            LargeChange     =   50
            SmallChange     =   10
            Min             =   50
            Max             =   400
            SelStart        =   100
            TickFrequency   =   10
            Value           =   100
         End
         Begin VB.Label lblConsole 
            Caption         =   "Angle:"
            Height          =   195
            Index           =   23
            Left            =   45
            TabIndex        =   39
            Top             =   915
            Width           =   810
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Zoom (100%):"
            Height          =   195
            Index           =   22
            Left            =   45
            TabIndex        =   38
            Top             =   3030
            Width           =   975
         End
         Begin VB.Label lblConsole 
            Caption         =   "X Coord:"
            Height          =   195
            Index           =   24
            Left            =   45
            TabIndex        =   37
            Top             =   60
            Width           =   810
         End
         Begin VB.Label lblConsole 
            Caption         =   "Y Coord:"
            Height          =   195
            Index           =   25
            Left            =   45
            TabIndex        =   36
            Top             =   345
            Width           =   810
         End
         Begin VB.Label lblConsole 
            Caption         =   "Z Coord:"
            Height          =   195
            Index           =   26
            Left            =   45
            TabIndex        =   35
            Top             =   630
            Width           =   810
         End
      End
      Begin VB.PictureBox picMapHolder 
         BorderStyle     =   0  'None
         Height          =   7725
         Left            =   -74715
         ScaleHeight     =   515
         ScaleMode       =   3  'Pixel
         ScaleWidth      =   524
         TabIndex        =   13
         Top             =   435
         Width           =   7860
         Begin VB.PictureBox picMap 
            Appearance      =   0  'Flat
            BorderStyle     =   0  'None
            ForeColor       =   &H80000008&
            Height          =   54000
            Left            =   0
            ScaleHeight     =   3600
            ScaleMode       =   3  'Pixel
            ScaleWidth      =   3600
            TabIndex        =   14
            Top             =   0
            Width           =   54000
            Begin VB.Label cLocLabel 
               Appearance      =   0  'Flat
               BackColor       =   &H0000FFFF&
               BorderStyle     =   1  'Fixed Single
               ForeColor       =   &H80000008&
               Height          =   120
               Index           =   0
               Left            =   240
               TabIndex        =   17
               Tag             =   "master"
               ToolTipText     =   "Location"
               Top             =   0
               Visible         =   0   'False
               Width           =   120
            End
            Begin VB.Label cPlayerLoc 
               Appearance      =   0  'Flat
               BackColor       =   &H000000FF&
               BorderStyle     =   1  'Fixed Single
               ForeColor       =   &H80000008&
               Height          =   120
               Left            =   135
               TabIndex        =   16
               Tag             =   "player"
               ToolTipText     =   "You are here"
               Top             =   0
               Visible         =   0   'False
               Width           =   120
            End
            Begin VB.Label cManualLoc 
               Appearance      =   0  'Flat
               BackColor       =   &H00FF0000&
               BorderStyle     =   1  'Fixed Single
               ForeColor       =   &H80000008&
               Height          =   120
               Left            =   0
               TabIndex        =   15
               Tag             =   "manual"
               ToolTipText     =   "Manually selected Location"
               Top             =   0
               Visible         =   0   'False
               Width           =   120
            End
            Begin VB.Image imgMap 
               Height          =   13500
               Left            =   0
               Picture         =   "frmSAConsole.frx":25DE
               Stretch         =   -1  'True
               Top             =   0
               Width           =   13500
            End
         End
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Apply changes"
         Height          =   555
         Index           =   0
         Left            =   -66525
         TabIndex        =   12
         TabStop         =   0   'False
         ToolTipText     =   "Apply changes to the selected GTA3 cheat"
         Top             =   1260
         Width           =   3120
      End
      Begin VB.TextBox txtCheatString 
         Height          =   360
         Left            =   -66525
         TabIndex        =   11
         TabStop         =   0   'False
         ToolTipText     =   "GTASA cheat-string to auto-insert"
         Top             =   765
         Width           =   3120
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Insert as a new Cheat"
         Height          =   555
         Index           =   1
         Left            =   -66525
         TabIndex        =   10
         TabStop         =   0   'False
         ToolTipText     =   "Insert this cheat string as a new GTA SA cheat (you can combine cheats as well)"
         Top             =   1845
         Width           =   3120
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Delete selected (cheat or folder)"
         Height          =   555
         Index           =   2
         Left            =   -66525
         TabIndex        =   9
         TabStop         =   0   'False
         ToolTipText     =   "Delete the selected cheat from list"
         Top             =   2430
         Width           =   3120
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Insert new Folder"
         Height          =   555
         Index           =   3
         Left            =   -66525
         TabIndex        =   8
         TabStop         =   0   'False
         ToolTipText     =   "Insert a new group under the selected group"
         Top             =   3015
         Width           =   3120
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Read Cheats from Config File"
         Height          =   555
         Index           =   4
         Left            =   -66525
         TabIndex        =   7
         TabStop         =   0   'False
         ToolTipText     =   "Read from config file and re-initialise Treeview"
         Top             =   3600
         Width           =   3120
      End
      Begin VB.CommandButton cmdCheats 
         Caption         =   "Save Cheats to Config File"
         Height          =   555
         Index           =   5
         Left            =   -66525
         TabIndex        =   6
         TabStop         =   0   'False
         ToolTipText     =   "Save changes on treeview to config file"
         Top             =   4185
         Width           =   3120
      End
      Begin VB.CommandButton cmdGarages 
         Caption         =   "Write Garages to INI"
         Height          =   375
         Index           =   3
         Left            =   -66315
         TabIndex        =   5
         Top             =   450
         Width           =   2865
      End
      Begin VB.CommandButton cmdGarages 
         Caption         =   "Read Garages from INI"
         Height          =   375
         Index           =   2
         Left            =   -69180
         TabIndex        =   4
         Top             =   450
         Width           =   2865
      End
      Begin VB.CommandButton cmdGarages 
         Caption         =   "Write Garages to GTA SA"
         Height          =   375
         Index           =   1
         Left            =   -72045
         TabIndex        =   3
         Top             =   450
         Width           =   2865
      End
      Begin VB.CommandButton cmdGarages 
         Caption         =   "Read Garages from GTA SA"
         Height          =   375
         Index           =   0
         Left            =   -74910
         TabIndex        =   2
         Top             =   450
         Width           =   2865
      End
      Begin MSComctlLib.TreeView tvShotcuts 
         Height          =   7845
         Left            =   -74865
         TabIndex        =   148
         Top             =   495
         Width           =   8220
         _ExtentX        =   14499
         _ExtentY        =   13838
         _Version        =   393217
         HideSelection   =   0   'False
         Indentation     =   353
         LabelEdit       =   1
         Sorted          =   -1  'True
         Style           =   7
         ImageList       =   "iListTvIcons"
         Appearance      =   1
      End
      Begin MSComctlLib.TreeView tvCheats 
         Height          =   7845
         Left            =   -74895
         TabIndex        =   149
         Top             =   510
         Width           =   8220
         _ExtentX        =   14499
         _ExtentY        =   13838
         _Version        =   393217
         HideSelection   =   0   'False
         Indentation     =   353
         LabelEdit       =   1
         Sorted          =   -1  'True
         Style           =   7
         ImageList       =   "iListTvIcons"
         Appearance      =   1
      End
      Begin TabDlg.SSTab sstGarages 
         Height          =   7455
         Left            =   -74910
         TabIndex        =   150
         Top             =   930
         Width           =   11490
         _ExtentX        =   20267
         _ExtentY        =   13150
         _Version        =   393216
         Style           =   1
         Tabs            =   4
         TabsPerRow      =   4
         TabHeight       =   520
         TabCaption(0)   =   "Los Santos"
         TabPicture(0)   =   "frmSAConsole.frx":C8630
         Tab(0).ControlEnabled=   -1  'True
         Tab(0).Control(0)=   "lblConsole(3)"
         Tab(0).Control(0).Enabled=   0   'False
         Tab(0).Control(1)=   "lblConsole(7)"
         Tab(0).Control(1).Enabled=   0   'False
         Tab(0).Control(2)=   "lblConsole(8)"
         Tab(0).Control(2).Enabled=   0   'False
         Tab(0).Control(3)=   "lblConsole(9)"
         Tab(0).Control(3).Enabled=   0   'False
         Tab(0).Control(4)=   "lblConsole(10)"
         Tab(0).Control(4).Enabled=   0   'False
         Tab(0).Control(5)=   "lblConsole(5)"
         Tab(0).Control(5).Enabled=   0   'False
         Tab(0).Control(6)=   "lblConsole(6)"
         Tab(0).Control(6).Enabled=   0   'False
         Tab(0).Control(7)=   "lblConsole(11)"
         Tab(0).Control(7).Enabled=   0   'False
         Tab(0).Control(8)=   "lblConsole(12)"
         Tab(0).Control(8).Enabled=   0   'False
         Tab(0).Control(9)=   "cParking(4)"
         Tab(0).Control(9).Enabled=   0   'False
         Tab(0).Control(10)=   "cParking(3)"
         Tab(0).Control(10).Enabled=   0   'False
         Tab(0).Control(11)=   "cParking(2)"
         Tab(0).Control(11).Enabled=   0   'False
         Tab(0).Control(12)=   "cParking(1)"
         Tab(0).Control(12).Enabled=   0   'False
         Tab(0).Control(13)=   "cParking(0)"
         Tab(0).Control(13).Enabled=   0   'False
         Tab(0).ControlCount=   14
         TabCaption(1)   =   "San Fierro"
         TabPicture(1)   =   "frmSAConsole.frx":C864C
         Tab(1).ControlEnabled=   0   'False
         Tab(1).Control(0)=   "cParking(13)"
         Tab(1).Control(1)=   "cParking(14)"
         Tab(1).Control(2)=   "cParking(15)"
         Tab(1).Control(3)=   "cParking(16)"
         Tab(1).Control(4)=   "cShapes(6)"
         Tab(1).Control(5)=   "lblConsole(37)"
         Tab(1).Control(6)=   "lblConsole(36)"
         Tab(1).Control(7)=   "lblConsole(35)"
         Tab(1).Control(8)=   "lblConsole(34)"
         Tab(1).Control(9)=   "lblConsole(33)"
         Tab(1).Control(10)=   "lblConsole(32)"
         Tab(1).Control(11)=   "lblConsole(31)"
         Tab(1).Control(12)=   "lblConsole(4)"
         Tab(1).Control(13)=   "lblConsole(2)"
         Tab(1).ControlCount=   14
         TabCaption(2)   =   "Las Venturas"
         TabPicture(2)   =   "frmSAConsole.frx":C8668
         Tab(2).ControlEnabled=   0   'False
         Tab(2).Control(0)=   "cParking(5)"
         Tab(2).Control(1)=   "cParking(6)"
         Tab(2).Control(2)=   "cParking(7)"
         Tab(2).Control(3)=   "cParking(8)"
         Tab(2).Control(4)=   "cShapes(4)"
         Tab(2).Control(5)=   "lblConsole(46)"
         Tab(2).Control(6)=   "lblConsole(45)"
         Tab(2).Control(7)=   "lblConsole(44)"
         Tab(2).Control(8)=   "lblConsole(43)"
         Tab(2).Control(9)=   "lblConsole(42)"
         Tab(2).Control(10)=   "lblConsole(41)"
         Tab(2).Control(11)=   "lblConsole(40)"
         Tab(2).Control(12)=   "lblConsole(39)"
         Tab(2).Control(13)=   "lblConsole(38)"
         Tab(2).ControlCount=   14
         TabCaption(3)   =   "Bone County"
         TabPicture(3)   =   "frmSAConsole.frx":C8684
         Tab(3).ControlEnabled=   0   'False
         Tab(3).Control(0)=   "cParking(9)"
         Tab(3).Control(1)=   "cParking(10)"
         Tab(3).Control(2)=   "cParking(11)"
         Tab(3).Control(3)=   "cParking(12)"
         Tab(3).Control(4)=   "cShapes(5)"
         Tab(3).Control(5)=   "lblConsole(55)"
         Tab(3).Control(6)=   "lblConsole(54)"
         Tab(3).Control(7)=   "lblConsole(53)"
         Tab(3).Control(8)=   "lblConsole(52)"
         Tab(3).Control(9)=   "lblConsole(51)"
         Tab(3).Control(10)=   "lblConsole(50)"
         Tab(3).Control(11)=   "lblConsole(49)"
         Tab(3).Control(12)=   "lblConsole(48)"
         Tab(3).Control(13)=   "lblConsole(47)"
         Tab(3).ControlCount=   14
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   0
            Left            =   150
            TabIndex        =   151
            Top             =   570
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Johnson House:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   1
            Left            =   150
            TabIndex        =   152
            Top             =   1920
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "El Corona:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   2
            Left            =   150
            TabIndex        =   153
            Top             =   3270
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Santa Maria Beach:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   3
            Left            =   150
            TabIndex        =   154
            Top             =   4620
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Mulholland:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   4
            Left            =   150
            TabIndex        =   155
            Top             =   5970
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Palomino Creek:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   9
            Left            =   -74850
            TabIndex        =   291
            Top             =   570
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Dillimore:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   10
            Left            =   -74850
            TabIndex        =   292
            Top             =   1920
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Fort Carson:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   11
            Left            =   -74850
            TabIndex        =   293
            Top             =   3270
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Verdant Meadows:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   12
            Left            =   -74850
            TabIndex        =   294
            Top             =   4620
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Verdant M. Hangar:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   5
            Left            =   -74850
            TabIndex        =   295
            Top             =   570
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Prickle Pine:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   6
            Left            =   -74850
            TabIndex        =   296
            Top             =   1920
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Whitewood Estates:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   7
            Left            =   -74850
            TabIndex        =   297
            Top             =   3270
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Redsands West:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   8
            Left            =   -74850
            TabIndex        =   298
            Top             =   4620
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Rockshore West:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   13
            Left            =   -74850
            TabIndex        =   299
            Top             =   570
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Calton Heights:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   14
            Left            =   -74850
            TabIndex        =   300
            Top             =   1920
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Paradiso:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   15
            Left            =   -74850
            TabIndex        =   301
            Top             =   3270
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Doherty:"
         End
         Begin GTASAControlCenter.GTASAGarageOcx cParking 
            Height          =   1365
            Index           =   16
            Left            =   -74850
            TabIndex        =   302
            Top             =   4620
            Width           =   11190
            _ExtentX        =   19738
            _ExtentY        =   2408
            GarageName      =   "Hashbury:"
         End
         Begin VB.Shape cShapes 
            Height          =   1365
            Index           =   6
            Left            =   -74850
            Top             =   5970
            Width           =   11190
         End
         Begin VB.Shape cShapes 
            Height          =   1365
            Index           =   4
            Left            =   -74850
            Top             =   5970
            Width           =   11190
         End
         Begin VB.Shape cShapes 
            Height          =   1365
            Index           =   5
            Left            =   -74850
            Top             =   5970
            Width           =   11190
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Minor:"
            Height          =   195
            Index           =   55
            Left            =   -67980
            TabIndex        =   191
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Major:"
            Height          =   195
            Index           =   54
            Left            =   -68865
            TabIndex        =   190
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Parked Car:"
            Height          =   195
            Index           =   53
            Left            =   -72690
            TabIndex        =   189
            Top             =   345
            Width           =   840
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Garage:"
            Height          =   195
            Index           =   52
            Left            =   -74835
            TabIndex        =   188
            Top             =   345
            Width           =   915
         End
         Begin VB.Label lblConsole 
            Caption         =   "FP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   51
            Left            =   -69135
            TabIndex        =   187
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "BP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   50
            Left            =   -69375
            TabIndex        =   186
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "DP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   49
            Left            =   -69615
            TabIndex        =   185
            Top             =   375
            Width           =   225
         End
         Begin VB.Label lblConsole 
            Caption         =   "EP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   48
            Left            =   -69840
            TabIndex        =   184
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Mods:"
            Height          =   195
            Index           =   47
            Left            =   -67080
            TabIndex        =   183
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Minor:"
            Height          =   195
            Index           =   46
            Left            =   -67980
            TabIndex        =   182
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Major:"
            Height          =   195
            Index           =   45
            Left            =   -68865
            TabIndex        =   181
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Parked Car:"
            Height          =   195
            Index           =   44
            Left            =   -72690
            TabIndex        =   180
            Top             =   345
            Width           =   840
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Garage:"
            Height          =   195
            Index           =   43
            Left            =   -74835
            TabIndex        =   179
            Top             =   345
            Width           =   915
         End
         Begin VB.Label lblConsole 
            Caption         =   "FP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   42
            Left            =   -69135
            TabIndex        =   178
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "BP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   41
            Left            =   -69375
            TabIndex        =   177
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "DP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   40
            Left            =   -69615
            TabIndex        =   176
            Top             =   375
            Width           =   225
         End
         Begin VB.Label lblConsole 
            Caption         =   "EP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   39
            Left            =   -69840
            TabIndex        =   175
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Mods:"
            Height          =   195
            Index           =   38
            Left            =   -67080
            TabIndex        =   174
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Minor:"
            Height          =   195
            Index           =   37
            Left            =   -67980
            TabIndex        =   173
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Major:"
            Height          =   195
            Index           =   36
            Left            =   -68865
            TabIndex        =   172
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Parked Car:"
            Height          =   195
            Index           =   35
            Left            =   -72690
            TabIndex        =   171
            Top             =   345
            Width           =   840
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Garage:"
            Height          =   195
            Index           =   34
            Left            =   -74835
            TabIndex        =   170
            Top             =   345
            Width           =   915
         End
         Begin VB.Label lblConsole 
            Caption         =   "FP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   33
            Left            =   -69135
            TabIndex        =   169
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "BP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   32
            Left            =   -69375
            TabIndex        =   168
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "DP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   31
            Left            =   -69615
            TabIndex        =   167
            Top             =   375
            Width           =   225
         End
         Begin VB.Label lblConsole 
            Caption         =   "EP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   4
            Left            =   -69840
            TabIndex        =   166
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Mods:"
            Height          =   195
            Index           =   2
            Left            =   -67080
            TabIndex        =   165
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Minor:"
            Height          =   195
            Index           =   12
            Left            =   7020
            TabIndex        =   164
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Major:"
            Height          =   195
            Index           =   11
            Left            =   6135
            TabIndex        =   163
            Top             =   345
            Width           =   435
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Parked Car:"
            Height          =   195
            Index           =   6
            Left            =   2310
            TabIndex        =   162
            Top             =   345
            Width           =   840
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Garage:"
            Height          =   195
            Index           =   5
            Left            =   165
            TabIndex        =   161
            Top             =   345
            Width           =   915
         End
         Begin VB.Label lblConsole 
            Caption         =   "FP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   10
            Left            =   5865
            TabIndex        =   160
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "BP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   9
            Left            =   5625
            TabIndex        =   159
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            Caption         =   "DP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   8
            Left            =   5385
            TabIndex        =   158
            Top             =   375
            Width           =   225
         End
         Begin VB.Label lblConsole 
            Caption         =   "EP"
            BeginProperty Font 
               Name            =   "Small Fonts"
               Size            =   6.75
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   195
            Index           =   7
            Left            =   5160
            TabIndex        =   157
            Top             =   375
            Width           =   210
         End
         Begin VB.Label lblConsole 
            AutoSize        =   -1  'True
            Caption         =   "Mods:"
            Height          =   195
            Index           =   3
            Left            =   7920
            TabIndex        =   156
            Top             =   345
            Width           =   435
         End
      End
      Begin GTASAControlCenter.GTASADirection oPedStart 
         Height          =   1815
         Left            =   -69315
         TabIndex        =   224
         ToolTipText     =   "Set Ped direction and kickstart with selected speed."
         Top             =   555
         Width           =   1815
         _ExtentX        =   3201
         _ExtentY        =   3201
         ButtonCaption   =   "Kickstart"
         HasScroller     =   -1  'True
         Caption         =   "Kick Start:"
      End
      Begin GTASAControlCenter.GTASADirection oPedDirection 
         Height          =   1785
         Left            =   -70935
         TabIndex        =   225
         ToolTipText     =   "Place Ped to selected Direction"
         Top             =   555
         Width           =   1575
         _ExtentX        =   2778
         _ExtentY        =   3149
         Caption         =   "Ped Direction:"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   3
         Left            =   -74700
         TabIndex        =   239
         Tag             =   "FixStamina"
         Top             =   3450
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Stamina Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Stamina Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   4
         Left            =   -74700
         TabIndex        =   240
         Tag             =   "FixMuscle"
         Top             =   4065
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Muscle Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Muscle Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   5
         Left            =   -74700
         TabIndex        =   241
         Tag             =   "FixLungStat"
         Top             =   4680
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Lung Capacity to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Lung Capacity ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   6
         Left            =   -74700
         TabIndex        =   242
         Tag             =   "FixGamblingStat"
         Top             =   5295
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Gambling Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Gambling Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   7
         Left            =   -74700
         TabIndex        =   243
         Tag             =   "FixDrivingProf"
         Top             =   5910
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Driving Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Driving Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   8
         Left            =   -74700
         TabIndex        =   244
         Tag             =   "FixBikingProf"
         Top             =   6525
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Biking Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Biking Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   9
         Left            =   -74700
         TabIndex        =   245
         Tag             =   "FixCyclingProf"
         Top             =   7140
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Cycling Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Cycling Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   10
         Left            =   -74700
         TabIndex        =   246
         Tag             =   "FixPilotProf"
         Top             =   7755
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         ButtonTip       =   "Click to Set Pilot Stat to 1000"
         ButtonVal       =   1000
         CaptionFormat   =   "Current Pilot Stat ([N]):"
      End
      Begin GTASAControlCenter.GTASAStat oPedStats 
         Height          =   555
         Index           =   20
         Left            =   -67080
         TabIndex        =   247
         TabStop         =   0   'False
         Tag             =   "PedFlightAssist"
         Top             =   7755
         Width           =   3435
         _ExtentX        =   6059
         _ExtentY        =   979
         HasButton       =   0   'False
         ButtonTip       =   "Click to Lock Stat"
         ButtonVal       =   1000
         ScrollVal       =   10
         CaptionFormat   =   "Ped Flight Assistance ([N] %):"
         ValToCapMultiplier=   0,1
         ValToCapDecimals=   1
      End
      Begin VB.CheckBox chkCarDynamics 
         Caption         =   "Car Weight: (50 Tons)"
         Height          =   195
         Index           =   4
         Left            =   300
         TabIndex        =   145
         TabStop         =   0   'False
         ToolTipText     =   "Check to lock Car-weight"
         Top             =   2190
         Width           =   2685
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   14
         Left            =   -67080
         TabIndex        =   269
         Tag             =   "PerfectHandling"
         Top             =   3555
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   661
         Caption         =   "Perfect Handling"
         CheatTip        =   "Click to toggle 'Perfect Handling' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   15
         Left            =   -65310
         TabIndex        =   270
         Tag             =   "DecTraffic"
         Top             =   3555
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Decreased Traffic"
         CheatTip        =   "Click to toggle 'Decreased Traffic' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   16
         Left            =   -67080
         TabIndex        =   271
         Tag             =   "BunnyHop"
         Top             =   3915
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Huge Bunny Hop"
         CheatTip        =   "Click to toggle 'Huge Bunny Hop' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   17
         Left            =   -65310
         TabIndex        =   272
         Tag             =   "AllNitros"
         Top             =   3915
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Cars have Nitro"
         CheatTip        =   "Click to toggle 'All Cars have Nitro' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   18
         Left            =   -67080
         TabIndex        =   273
         Tag             =   "BoatsFly"
         Top             =   4275
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "Boats can Fly"
         CheatTip        =   "Click to toggle 'Boats can Fly' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   19
         Left            =   -65310
         TabIndex        =   274
         Tag             =   "CarsFly"
         Top             =   4275
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Cars can Fly"
         CheatTip        =   "Click to toggle 'Cars can Fly' On and Off"
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   20
         Left            =   -67080
         TabIndex        =   279
         Tag             =   "OneHitKill"
         ToolTipText     =   "Click to toggle 'One Hit Kill' On and Off (uses code injection)"
         Top             =   4635
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "One Hit Kill"
         CheatTip        =   ""
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   21
         Left            =   -65310
         TabIndex        =   280
         Tag             =   "FreezeTimers"
         ToolTipText     =   "Click to toggle 'Freeze All Mission Timers' On and Off (uses code injection)"
         Top             =   4635
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "Freeze Timers"
         CheatTip        =   ""
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   22
         Left            =   -67080
         TabIndex        =   281
         Tag             =   "Reserved"
         Top             =   4995
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   23
         Left            =   -65310
         TabIndex        =   282
         Tag             =   "Reserved"
         Top             =   4995
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   24
         Left            =   -67080
         TabIndex        =   283
         Tag             =   "Reserved"
         Top             =   5355
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   25
         Left            =   -65310
         TabIndex        =   284
         Tag             =   "Reserved"
         Top             =   5355
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   26
         Left            =   -67080
         TabIndex        =   285
         Tag             =   "Reserved"
         Top             =   5715
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   27
         Left            =   -65310
         TabIndex        =   286
         Tag             =   "Reserved"
         Top             =   5715
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   28
         Left            =   -67080
         TabIndex        =   287
         Tag             =   "Reserved"
         Top             =   6075
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   360
         Index           =   29
         Left            =   -65310
         TabIndex        =   288
         Tag             =   "Reserved"
         Top             =   6075
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   635
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   375
         Index           =   30
         Left            =   -67080
         TabIndex        =   289
         Tag             =   "Reserved"
         Top             =   6435
         Width           =   1770
         _ExtentX        =   3122
         _ExtentY        =   661
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin GTASAControlCenter.GTASACheat oCheatStates 
         Height          =   375
         Index           =   31
         Left            =   -65310
         TabIndex        =   290
         Tag             =   "Reserved"
         Top             =   6435
         Width           =   1785
         _ExtentX        =   3149
         _ExtentY        =   661
         Caption         =   "(reserved)"
         CheatTip        =   ""
         Enabled         =   0   'False
      End
      Begin VB.Label lblConsole 
         Alignment       =   2  'Center
         BorderStyle     =   1  'Fixed Single
         Caption         =   "N/A"
         Height          =   300
         Index           =   66
         Left            =   -68685
         TabIndex        =   353
         Top             =   7935
         Width           =   840
      End
      Begin VB.Label lblConsole 
         Alignment       =   2  'Center
         BorderStyle     =   1  'Fixed Single
         Caption         =   "N/A"
         Height          =   300
         Index           =   65
         Left            =   -68685
         TabIndex        =   352
         Top             =   7620
         Width           =   840
      End
      Begin VB.Label lblConsole 
         Alignment       =   2  'Center
         BorderStyle     =   1  'Fixed Single
         Caption         =   "N/A"
         Height          =   300
         Index           =   63
         Left            =   -68685
         TabIndex        =   351
         Top             =   4785
         Width           =   840
      End
      Begin VB.Label lblConsole 
         AutoSize        =   -1  'True
         Caption         =   "Ammo"
         Height          =   195
         Index           =   62
         Left            =   -68655
         TabIndex        =   350
         Top             =   4515
         Width           =   435
      End
      Begin VB.Shape cShapes 
         Height          =   4005
         Index           =   11
         Left            =   -71115
         Top             =   4395
         Width           =   3840
      End
      Begin VB.Shape cShapes 
         Height          =   2400
         Index           =   10
         Left            =   135
         Top             =   6000
         Width           =   3765
      End
      Begin VB.Shape cShapes 
         Height          =   3960
         Index           =   1
         Left            =   7710
         Top             =   4440
         Width           =   3960
      End
      Begin VB.Label lblConsole 
         Caption         =   "Current Weather:"
         Height          =   195
         Index           =   14
         Left            =   7920
         TabIndex        =   304
         Top             =   3795
         Width           =   3555
      End
      Begin VB.Shape cShapes 
         Height          =   7935
         Index           =   9
         Left            =   -67290
         Top             =   465
         Width           =   3960
      End
      Begin VB.Shape cShapes 
         Height          =   3945
         Index           =   8
         Left            =   -71115
         Top             =   465
         Width           =   3840
      End
      Begin VB.Shape cShapes 
         Height          =   7935
         Index           =   7
         Left            =   -74865
         Top             =   465
         Width           =   3765
      End
      Begin VB.Shape cShapes 
         Height          =   3990
         Index           =   3
         Left            =   7710
         Top             =   465
         Width           =   3960
      End
      Begin VB.Shape cShapes 
         Height          =   7935
         Index           =   2
         Left            =   3885
         Top             =   465
         Width           =   3840
      End
      Begin VB.Shape cShapes 
         Height          =   5550
         Index           =   0
         Left            =   135
         Top             =   465
         Width           =   3765
      End
      Begin VB.Label lblConsole 
         Caption         =   "Vehicle Selection:"
         Height          =   255
         Index           =   13
         Left            =   285
         TabIndex        =   278
         Top             =   7725
         Width           =   2460
      End
      Begin VB.Label lblPedSpeed 
         Caption         =   "Z Speed (0%):"
         Height          =   255
         Index           =   2
         Left            =   -70935
         TabIndex        =   234
         Top             =   3825
         Width           =   2535
      End
      Begin VB.Label lblPedSpeed 
         Caption         =   "Y Speed (0%):"
         Height          =   255
         Index           =   1
         Left            =   -70935
         TabIndex        =   233
         Top             =   3330
         Width           =   2535
      End
      Begin VB.Label lblPedSpeed 
         Caption         =   "X Speed (0%):"
         Height          =   255
         Index           =   0
         Left            =   -70935
         TabIndex        =   232
         Top             =   2820
         Width           =   2535
      End
      Begin VB.Label lblCurrentPlayer 
         Caption         =   "Current Player: "
         ForeColor       =   &H00FF0000&
         Height          =   240
         Left            =   -74700
         TabIndex        =   220
         Top             =   555
         Width           =   3240
      End
      Begin VB.Label lblConsole 
         AutoSize        =   -1  'True
         Caption         =   "Average Weapon Proficiency: 0%"
         Height          =   195
         Index           =   57
         Left            =   -67020
         TabIndex        =   219
         Top             =   6960
         Width           =   2385
      End
      Begin VB.Label lblConsole 
         Caption         =   "Clock Speed: (unknown yet)"
         Height          =   195
         Index           =   58
         Left            =   7920
         TabIndex        =   211
         Top             =   2670
         Width           =   3555
      End
      Begin VB.Label lblConsole 
         Caption         =   "Adjust:"
         Height          =   195
         Index           =   56
         Left            =   7920
         TabIndex        =   210
         Top             =   2340
         Width           =   810
      End
      Begin VB.Label lblConsole 
         Caption         =   "Game Time: (unknown yet)"
         Height          =   195
         Index           =   30
         Left            =   7920
         TabIndex        =   209
         Top             =   2085
         Width           =   3555
      End
      Begin VB.Label lblConsole 
         Caption         =   "X Speed (0%):"
         Height          =   255
         Index           =   15
         Left            =   4065
         TabIndex        =   208
         Top             =   4065
         Width           =   1380
      End
      Begin VB.Label lblConsole 
         Caption         =   "Y Speed (0%):"
         Height          =   255
         Index           =   16
         Left            =   4065
         TabIndex        =   207
         Top             =   4680
         Width           =   1380
      End
      Begin VB.Label lblConsole 
         Caption         =   "Z Speed (0%):"
         Height          =   255
         Index           =   17
         Left            =   4065
         TabIndex        =   206
         Top             =   5295
         Width           =   1380
      End
      Begin VB.Label lblConsole 
         Caption         =   "X Spin (0%):"
         Height          =   255
         Index           =   18
         Left            =   4065
         TabIndex        =   205
         Top             =   5910
         Width           =   1380
      End
      Begin VB.Label lblConsole 
         Caption         =   "Y Spin (0%):"
         Height          =   255
         Index           =   19
         Left            =   4065
         TabIndex        =   204
         Top             =   6525
         Width           =   1380
      End
      Begin VB.Label lblConsole 
         Caption         =   "Z Spin (0%):"
         Height          =   255
         Index           =   20
         Left            =   4065
         TabIndex        =   203
         Top             =   7140
         Width           =   1380
      End
      Begin VB.Label lblCurrentCar 
         Caption         =   "Current Car: "
         ForeColor       =   &H00FF0000&
         Height          =   240
         Left            =   300
         TabIndex        =   202
         Top             =   555
         Width           =   3240
      End
      Begin VB.Label lblConsole 
         Caption         =   "Adjust:"
         Height          =   195
         Index           =   59
         Left            =   7920
         TabIndex        =   201
         Top             =   2940
         Width           =   810
      End
      Begin VB.Label lblConsole 
         Caption         =   "Adjust:"
         Height          =   195
         Index           =   60
         Left            =   7920
         TabIndex        =   200
         Top             =   3510
         Width           =   810
      End
      Begin VB.Label lblConsole 
         Caption         =   "Game Speed: (unknown yet)"
         Height          =   195
         Index           =   61
         Left            =   7920
         TabIndex        =   199
         Top             =   3255
         Width           =   3555
      End
      Begin VB.Label lblConsole 
         Alignment       =   1  'Right Justify
         AutoSize        =   -1  'True
         Caption         =   "GTASA Version:"
         Height          =   195
         Index           =   1
         Left            =   -65685
         TabIndex        =   198
         Top             =   8085
         Width           =   1335
      End
      Begin VB.Label lblConsole 
         AutoSize        =   -1  'True
         Caption         =   "Teleport Locations:"
         Height          =   195
         Index           =   0
         Left            =   -66465
         TabIndex        =   197
         Top             =   1995
         Width           =   1365
      End
      Begin VB.Label lblIntervall 
         Caption         =   "Keyboard Control Intervall: (500 ms)."
         Height          =   195
         Left            =   -66510
         TabIndex        =   196
         ToolTipText     =   "interval in which the GTASA Admin Console checks for keys during gameplay"
         Top             =   6645
         Width           =   3135
      End
      Begin VB.Label lblConsole 
         Caption         =   "Shortcut:"
         Height          =   195
         Index           =   29
         Left            =   -66465
         TabIndex        =   195
         Top             =   3120
         Width           =   645
      End
      Begin VB.Label lblConsole 
         AutoSize        =   -1  'True
         Caption         =   "Control Center Commands:"
         Height          =   195
         Index           =   27
         Left            =   -66465
         TabIndex        =   194
         Top             =   495
         Width           =   1875
      End
      Begin VB.Label lblConsole 
         AutoSize        =   -1  'True
         Caption         =   "GTASA internal Cheats:"
         Height          =   195
         Index           =   28
         Left            =   -66465
         TabIndex        =   193
         Top             =   1245
         Width           =   1680
      End
      Begin VB.Label lblConsole 
         Caption         =   "Cheat string:"
         Height          =   195
         Index           =   21
         Left            =   -66525
         TabIndex        =   192
         Top             =   510
         Width           =   1320
      End
   End
   Begin VB.Timer tmrHook 
      Enabled         =   0   'False
      Interval        =   1000
      Left            =   525
      Top             =   300
   End
   Begin VB.Timer tmrConsole 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   105
      Top             =   300
   End
   Begin VB.TextBox txtFocus 
      Height          =   285
      Left            =   60
      Locked          =   -1  'True
      TabIndex        =   0
      Top             =   30
      Width           =   510
   End
   Begin VB.Timer tmrFindCar 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   885
      Top             =   135
   End
   Begin MSComctlLib.ImageList iListTvIcons 
      Left            =   60
      Top             =   8550
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   6
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C86A0
            Key             =   "closedfolder"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C87FA
            Key             =   "openfolder"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C8954
            Key             =   "location"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C8AAE
            Key             =   "cheat"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C8C08
            Key             =   "shortcut_inactive"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmSAConsole.frx":C8D62
            Key             =   "shortcut_active"
         EndProperty
      EndProperty
   End
   Begin VB.CheckBox chkCoffee 
      Caption         =   "Coffee: Censored"
      Height          =   375
      Left            =   0
      Style           =   1  'Graphical
      TabIndex        =   251
      TabStop         =   0   'False
      ToolTipText     =   "Click to toggle 'HotCoffee' On and Off (ie. Censored and Uncensored)"
      Top             =   0
      Visible         =   0   'False
      Width           =   1590
   End
   Begin VB.Menu mCheatContext 
      Caption         =   "mCheatContext"
      Visible         =   0   'False
      Begin VB.Menu umnuCheat 
         Caption         =   "Edit Label"
         Index           =   0
      End
      Begin VB.Menu umnuCheat 
         Caption         =   "Move to Folder"
         Index           =   1
      End
   End
   Begin VB.Menu mLocationContext 
      Caption         =   "mLocationContext"
      Visible         =   0   'False
      Begin VB.Menu umnuLocation 
         Caption         =   "Edit Label"
         Index           =   0
      End
      Begin VB.Menu umnuLocation 
         Caption         =   "Move to Folder"
         Index           =   1
      End
      Begin VB.Menu umnuLocation 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu umnuLocation 
         Caption         =   "Show on Map"
         Index           =   3
      End
   End
   Begin VB.Menu mShortcutContext 
      Caption         =   "mShortcutContext"
      Visible         =   0   'False
      Begin VB.Menu umnuShortcut 
         Caption         =   "Edit Label"
         Index           =   0
      End
      Begin VB.Menu umnuShortcut 
         Caption         =   "Move to Folder"
         Index           =   1
      End
      Begin VB.Menu umnuShortcut 
         Caption         =   "-"
         Index           =   2
      End
      Begin VB.Menu umnuShortcut 
         Caption         =   "Activate"
         Index           =   3
      End
      Begin VB.Menu umnuShortcut 
         Caption         =   "Deactivate"
         Index           =   4
      End
   End
   Begin VB.Menu mLocLabel 
      Caption         =   "mLocLabel"
      Visible         =   0   'False
      Begin VB.Menu uLocLabel 
         Caption         =   "Read Coordinates"
         Index           =   0
      End
      Begin VB.Menu uLocLabel 
         Caption         =   "-"
         Index           =   1
      End
      Begin VB.Menu uLocLabel 
         Caption         =   "Teleport"
         Index           =   2
      End
   End
   Begin VB.Menu mManualLoc 
      Caption         =   "mManualLoc"
      Visible         =   0   'False
      Begin VB.Menu uManualLoc 
         Caption         =   "Read Coordinates"
         Index           =   0
      End
      Begin VB.Menu uManualLoc 
         Caption         =   "-"
         Index           =   1
      End
      Begin VB.Menu uManualLoc 
         Caption         =   "Teleport"
         Index           =   2
      End
   End
   Begin VB.Menu mPlayerLoc 
      Caption         =   "mPlayerLoc"
      Visible         =   0   'False
      Begin VB.Menu uPlayerLoc 
         Caption         =   "Read Online Coordinates"
         Index           =   0
      End
   End
   Begin VB.Menu mZoomContext 
      Caption         =   "mZoomContext"
      Visible         =   0   'False
      Begin VB.Menu umnuZoom 
         Caption         =   "Hide Locations"
         Index           =   0
      End
      Begin VB.Menu umnuZoom 
         Caption         =   "-"
         Index           =   1
      End
      Begin VB.Menu umnuZoom 
         Caption         =   "Map Zoom"
         Index           =   2
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to  50 %"
            Index           =   0
         End
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to 100%"
            Index           =   1
         End
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to 150%"
            Index           =   2
         End
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to 200%"
            Index           =   3
         End
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to 300%"
            Index           =   4
         End
         Begin VB.Menu umnuZoomMap 
            Caption         =   "Set to 400%"
            Index           =   5
         End
      End
      Begin VB.Menu umnuZoom 
         Caption         =   "Location Boxes"
         Index           =   3
         Begin VB.Menu umnuLocBox 
            Caption         =   " 8 x 8"
            Checked         =   -1  'True
            Index           =   0
         End
         Begin VB.Menu umnuLocBox 
            Caption         =   "12 x 12"
            Index           =   1
         End
         Begin VB.Menu umnuLocBox 
            Caption         =   "16 x 16"
            Index           =   2
         End
      End
   End
End
Attribute VB_Name = "frmSAConsole"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private lngExecBuffer As Long
Private isWeatherLock As Boolean
Private lngLockWeatherTo As Long
Private sLicensePlate As String
Private isFixLicensePlate As Boolean
Private isFixBrassKnuckle As Boolean
Private isFixWeaponSlots(10) As Boolean
Private iFixWeaponID(10) As Long
Private iFixWeaponAmmo(10) As Long
Private isControlRCCars As Boolean
Private iMsgShowCtr As Integer          'how many times to show run gta msg
Private isAutoInject As Boolean         'if car spawner code should be auto-injected or not
Private iInjectMsgCtr As Integer        'counter to show injection messages
Private bNotInjectedJump(4) As Byte   'has the original asm code of gta_sa, version dependant
Private bNotInjectedCode(503) As Byte 'used to write &H0 on code inject location
Private bInjectedJump(4) As Byte      'has the jump asm statement, gta sa version dependant
Private bInjectedCode(503) As Byte    'has the asm code, gta sa version dependant
Private bInjectCheck(4) As Byte       'used as buffer to check if code is injected or not
Private bNotInjectedJump_OneHitKill(5) As Byte
Private bNotInjectedCode_OneHitKill(46) As Byte
Private bInjectedJump_OneHitKill(5) As Byte
Private bInjectedCode_OneHitKill(46) As Byte
Private bInjectCheck_OneHitKill(5) As Byte       'used as buffer to check if code is injected or not
Private iOrg_FreezeTimerUp As Integer
Private iOrg_FreezeTimerDown As Integer
Private isInternInjectCheck As Boolean
Private isRestartCar As Boolean         'restart car if stalled
Private isInjected As Boolean           'if spawner code is injected or not
Private isOrgSCM As Boolean             'if it is original scm or not
Private isTimerClick As Boolean         'if is hook timer refresh click or not
Private dtGameDateTime As Date          'mirror of game date time
Private dtBaseDateTime As Date          'mirror to clng(DateSerial(1991,5,1))-1
Private sWeekdays(7) As String          'Sunday to Saturday 1 to 7
Private isMsgShown As Boolean           'if info msg on gta sa syncronization has been shown or not
Private isDirty(2) As Boolean           'dirty status of Cheats/Locations/Shortcuts
Private iLocBoxSize As Integer          'Location Box Size (8/12/16)
Private sZoomLevel As Single            'Location Map Zoom Level (0.5 to 2.0)
Private sngXOffset As Single            'Location Map X Offset
Private sngYOffset As Single            'Location Map Y Offset
Private sngMinOffsetX As Single         'Location Map Minimum X Offset
Private sngMinOffsetY As Single         'Location Map Minimum Y Offset
Private sngMaxOffsetX As Single         'Location Map Maximum X Offset
Private sngMaxOffsetY As Single         'Location Map Maximum Y Offset
Private sngGTAtoPix As Single           'Location Map GTA Coord to Pixels multiplier
Private sngPixToGTA As Single           'Location Map Pixels to GTA Coord multiplier (1/sngGTAtoPix)
Private sCheatUID() As String           'Cheats to CheatCombo Listindex Array
Private sLocUID() As String             'Locations to LocationCombo Listindex Array
Private strCarType As String            'Current Car Type (car, bike, mtruck, plane etc)
Private isInternalClick As Boolean      'to enable internally click checkboxes etc.
Private intConsoleCounter As Integer    'for..next loops in console timer
Private isHasNewCar As Boolean          'if Player has changed car or not
Private isHasCar As Boolean             'if Player is in Car or not
Private isHadCar As Boolean             'if player has got off car, but not got in a new car
Private lngHookBuffer As Long           'Buffer for Read/Write by hook timer
Private sngHookBuffer As Single         'Buffer for Read/Write by hook timer
Private bytHookBuffer As Byte           'Buffer for Read/Write by hook timer
Private lngLastPid As Long              'Last Found Process-Id of GTASA (to compare)
Private fCarHealth As Single            'CarHealth Buffer for tmrConsole
Private intPressedExtKey As Integer     'Keyboard mirror for PressedExtKey
Private intPressedKey As Integer        'Keyboard mirror for PressedKey
Private intShorcutCount As Integer      'Count of Shortcuts to check in tmrConsole
Private sngExecWriteBuffer As Single    'Buffers for ExecuteConsoleCommand
Private intExecCounter As Integer       'Buffers for ExecuteConsoleCommand
Private intSpinSeconds As Integer       'Seconds/Timerticks to lock Spin in Heli-Mode
Private intHookCounter As Integer       'allg. Counter for tmrHook
Private isLockHealth As Boolean         'mirror of chkPlayerStats(0).value
Private isLockArmor As Boolean          'mirror of chkPlayerStats(1).value
Private isLockFat As Boolean            'mirror of chkPlayerStats(3).value
Private isLockStamina As Boolean        'mirror of chkPlayerStats(4).value
Private isLockMuscle As Boolean         'mirror of chkPlayerStats(5).value
Private isLockDrivingProf As Boolean
Private isLockBikingProf  As Boolean
Private isLockCyclingProf As Boolean
Private isLockPilotProf   As Boolean
Private isLockLungStat As Boolean
Private isLockGamblingStat As Boolean
Private isFixPed As Boolean             'mirror of chkPlayerStats(10).value
Private sngLockHealthTo As Single       'mirror of scrPlayerStats(0).value
Private sngLockArmorTo As Single        'mirror of scrPlayerStats(1).value
Private sngLockFatTo As Single          'mirror of scrPlayerStats(1).value
Private sngLockStaminaTo As Single      'mirror of scrPlayerStats(1).value
Private sngLockMuscleTo As Single       'mirror of scrPlayerStats(1).value
Private lngLockDrivingProfTo As Long
Private lngLockBikingProfTo  As Long
Private lngLockCyclingProfTo As Long
Private lngLockPilotProfTo   As Long
Private lngLockLungStatTo As Long
Private sngLockGamblingStatTo As Single
Private isFlightAssistance As Boolean   'mirror of chkCarDynamics(8).Value
Private isPedFlightAssistance As Boolean
Private isAutoLockCarDoors As Boolean   'mirror of chkCarDynamics(1).value AND optCardoors(1).value
Private isLockEngineHealth As Boolean   'mirror of chkCarDynamics(3).value
Private sngLockEngineHealthTo As Single   'mirror of scrCarDynamics(1).value
Private intFallSeconds As Integer       'For Downwards flight
Private isGTASAiconic As Boolean         'If GTASA is minimized or not
Private lngLastGTASAHwnd As Long         'To enable a delay timer for GTA to start fully
Private sngAssistFlightBy As Single     'Flight Assistance level
Private sngPedAssistFlightBy As Single
Private isDontExplode As Boolean        'mirror of chkDontBurn(1).value
Private isDontBurn As Boolean           'mirror of chkDontBurn(0).value
Private intPlayerDrivesCar As Integer   'ordinal of current car
Private dblMassNormalizer As Double     'Normalization of Mass to Grip and Suspension values by changing Mass of Car
Private isHasFeedback As Boolean        'If Signal Feedback or not
Private intWaitBeforeHook As Integer    'Seconds to wait for GTASA to start
Private intRefreshFormValues As Integer 'integer to refresh form values 2 times if GTASA is minimized
Private strMarkLocations(10) As String  'Mark Location and WarpToLocation string Array for LocData, 0 to 3
Private sngAbsoluteDegrees As Single    'What is my placement in absolute degrees
Private lngReadReturn As Long            'If the ReadMemory successful was or not
Private strOnScreenText As String        'On-Screen Display Text
Private isPreventWheelDamage As Boolean    ' Mirror to prevent wheel damage
Private intWarpNextHitDelayCount As Integer 'delay counter for warp next location console command
Private intGameTimeChangeCount As Integer   'delay counter for game time advance/revert
Private isSafeCheats As Boolean
Private isLockGF(5) As Boolean
Private lngLockGFto(5) As Long

Private Sub txtCommandWeaponAmmo_Validate(Cancel As Boolean)
On Error GoTo errValidation
    txtCommandWeaponAmmo.Text = CLng(txtCommandWeaponAmmo.Text)
    If CLng(txtCommandWeaponAmmo.Text) < 0 Then txtCommandWeaponAmmo.Text = "0"
Exit Sub
errValidation:
    Err.Clear
    txtCommandWeaponAmmo.Text = "0"
End Sub

Private Sub chkWeatherLock_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    isWeatherLock = (chkWeatherLock.Value = vbChecked)
    lngLockWeatherTo = cboWeather.ListIndex
    If lngLockWeatherTo < 0 Then lngLockWeatherTo = 1
    If isHasHandle And isHasPlayer Then
        'set weather:
        If isWeatherLock Then
            SetMemLong GTASABaseAdr.WeatherLockAdr, lngLockWeatherTo
        Else
            SetMemLong GTASABaseAdr.WeatherLockAdr, &HFFFF 'release weather lock
        End If
        SetMemLong GTASABaseAdr.WeatherToGoAdr, lngLockWeatherTo
        SetMemLong GTASABaseAdr.WeatherCurrentAdr, lngLockWeatherTo
    End If
    WritePrivateProfileString "Main", "Weather", Format$(chkWeatherLock.Value) & "," & Format$(lngLockWeatherTo), strIniFileName
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
End Sub

Private Sub cmdSetPlate_Click()
On Error Resume Next
    MsgBox "Coming soon..."
    Exit Sub
    If isHasHandle And isHasCar Then
        'apply license plate change:
        sLicensePlate = txtLicensePlate.Text
        SetMemString tCurrCarAdr.lngLicensePlateAdr, sLicensePlate, 8
    End If
    txtLicensePlate.BackColor = &HFFFFFF
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
End Sub

Private Sub txtLicensePlate_Change()
On Error Resume Next
    If isInternalClick Then Exit Sub
    txtLicensePlate.BackColor = &H80FF80
End Sub

Private Sub txtLicensePlate_Validate(Cancel As Boolean)
On Error Resume Next
    If isInternalClick Then Exit Sub
    txtLicensePlate.Text = UCase(txtLicensePlate.Text)
    If Trim(txtLicensePlate.Text) = "" Then txtLicensePlate.Text = "GTASA CC"
    If Len(txtLicensePlate.Text) < 8 Then txtLicensePlate.Text = Left$(txtLicensePlate.Text & "        ", 8)
    sLicensePlate = txtLicensePlate.Text
    WritePrivateProfileString "CarTracking", "LicensePlate", Format$(chkCarDynamics(10).Value) & "," & txtLicensePlate.Text, strIniFileName
End Sub

Private Sub ReFillPlayerWeapons(ByVal iWeaponSlotIndex As Long, Optional ByVal isManual As Boolean = False)
On Error Resume Next
    If isManual Then
        If Not ReFillPlayerAdr Then Exit Sub
    End If
    'set selected weapon slot:
    ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponsAdr(iWeaponSlotIndex), GTASAPlayerWeapon, 16&, 0&
    'initialise weapon:
    If isInjected And (GTASAPlayerWeapon.lngWeaponID <> iFixWeaponID(iWeaponSlotIndex)) And iFixWeaponID(iWeaponSlotIndex) > 0 Then
        'if code is injected, and player has currently another weapon in this slot, initialise this new weapon
        WriteProcessMemory lngPHandle, GTASABaseAdr.WeaponSpawnAdr(iWeaponSlotIndex), WeaponIDtoDatID(iFixWeaponID(iWeaponSlotIndex)), 4&, 4&
    End If
    'fill-in the details:
    GTASAPlayerWeapon.lngWeaponID = iFixWeaponID(iWeaponSlotIndex)
    Select Case iWeaponSlotIndex
        Case 0, 2, 5, 7, 9, 10
            GTASAPlayerWeapon.lngLoadedAmmo = 1 'melee, projectiles, and specials
        Case 6
            If cboWeapons(iWeaponSlotIndex).ListIndex > 2 Then
                GTASAPlayerWeapon.lngLoadedAmmo = 500 'flame thrower, minigun
            Else
                GTASAPlayerWeapon.lngLoadedAmmo = 1 'rocket launchers
            End If
        Case 8
            If cboWeapons(iWeaponSlotIndex).ListIndex = 3 Then
                GTASAPlayerWeapon.lngLoadedAmmo = 50 'camera
            Else
                GTASAPlayerWeapon.lngLoadedAmmo = 500 'sprays
            End If
        Case Else
            GTASAPlayerWeapon.lngLoadedAmmo = 50 'other weapons
    End Select
    GTASAPlayerWeapon.lngTotalAmmo = iFixWeaponAmmo(iWeaponSlotIndex)
    If cboWeapons(iWeaponSlotIndex).ListIndex < 1 Then GTASAPlayerWeapon.lngTotalAmmo = 0
    If GTASAPlayerWeapon.lngLoadedAmmo > GTASAPlayerWeapon.lngTotalAmmo Then GTASAPlayerWeapon.lngLoadedAmmo = GTASAPlayerWeapon.lngTotalAmmo
    GTASAPlayerWeapon.lngWas1 = 0
    'set weapon and ammo:
    WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponsAdr(iWeaponSlotIndex), GTASAPlayerWeapon, 16&, 16&
End Sub

Private Sub chkAutoInjectCode_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    isAutoInject = (chkAutoInjectCode.Value = vbChecked)
    If isAutoInject Then
        If CheckIfInjectable Then
            If Not CheckIfInjected Then
                'inject code and jump:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCodeAdr, bInjectedCode(0), 504&, 504&
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectedJump(0), 5&, 5&
                chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
                cmdSpawnCar(0).Enabled = True
                isInjected = True
            End If
        End If
    End If
    WritePrivateProfileString "CarTracking", "AutoInject", Format$(chkAutoInjectCode.Value), strIniFileName
    If isGTASAiconic Then txtFocus.SetFocus
End Sub

Private Sub txtAmmo_Change(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    txtAmmo(Index).BackColor = &H80FF80
End Sub

Private Sub cboWeapons_Click(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    If cboWeapons(Index).ListIndex < 1 Then
        txtAmmo(Index).Text = "0"
    Else
        Select Case Index
            Case 0, 9, 10
                txtAmmo(Index).Text = "1"
        End Select
    End If
    cboWeapons(Index).BackColor = &H80FF80
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
End Sub

Private Sub cmdSetWeapon_Click(Index As Integer)
On Error GoTo errSetWeapon
    'check integrity of selected weapons, and entered ammo amount:
    If cboWeapons(Index).ListIndex < 1 Then
        txtAmmo(Index).Text = "0"
    Else
        Select Case Index
            Case 0, 9, 10
                txtAmmo(Index).Text = "1"
            Case Else
                txtAmmo(Index).Text = CLng(txtAmmo(Index).Text)
        End Select
    End If
    If txtAmmo(Index).Text = "0" Then cboWeapons(Index).ListIndex = 0
    iFixWeaponID(Index) = WeaponSlotMatrix(Index, cboWeapons(Index).ListIndex)
    iFixWeaponAmmo(Index) = CLng(txtAmmo(Index).Text)
    ReFillPlayerWeapons Index, True
    If Index = 10 Then SetMemLong GTASAPlayerAddresse.lngWeaponsAdr(10) + 20, 0
    WritePrivateProfileString "PlayerTracking", "Weapon" & Format$(Index, "00"), Format$(chkWeapons(Index).Value) & "," & Format$(iFixWeaponID(Index)) & "," & Format$(iFixWeaponAmmo(Index)), strIniFileName
    If isGTASAiconic Then txtFocus.SetFocus
    cboWeapons(Index).BackColor = &HFFFFFF
    txtAmmo(Index).BackColor = &HFFFFFF
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
Exit Sub
errSetWeapon:
    Err.Clear
    MsgBox "Weapon Validation failed. Please check your entry", vbCritical
    If chkWeapons(Index).Value = vbChecked Then chkWeapons(Index).Value = vbUnchecked
    isFixWeaponSlots(Index) = False
End Sub

Private Sub chkWeapons_Click(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    If Index = 11 Then
        isFixBrassKnuckle = (chkWeapons(11).Value = vbChecked)
        If isInjected And isFixBrassKnuckle Then 'initialiase weapon if needed:
            WriteProcessMemory lngPHandle, GTASABaseAdr.WeaponSpawnAdr(11), 331&, 4&, 4&
        End If
        SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr, IIf(isFixBrassKnuckle, 1, 0)
        SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr + 12, IIf(isFixBrassKnuckle, 1, 0)
        WritePrivateProfileString "PlayerTracking", "WeaponBr", Format$(chkWeapons(Index).Value), strIniFileName
    Else
        isFixWeaponSlots(Index) = (chkWeapons(Index).Value = vbChecked)
        If isFixWeaponSlots(Index) Then Call cmdSetWeapon_Click(Index)
    End If
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

'**********************************************************
'                       Start / Stop Procedures
'**********************************************************
Private Sub Form_Load()
On Error GoTo errFormLoad
    isGTASAiconic = False
    'Location Boxes Size (pixels)
    iLocBoxSize = 8
    sZoomLevel = 1
    CalcMapOffsets
    Me.Enabled = False
    Me.Caption = "GTA SA Control Center [Initializing, please wait...]"
    Me.Show
    DoEvents
    'read data file:
    ParseCarIDs     'get available car ID's, and their types, parkability, sizes etc.
    ParseLocations  'get location values
    ParseCheats     'get cheat details
    ParseShortcuts  'get shortcut details
    FillInTreeviews 'fill locations, cheats and shortcuts into treeviews
    FillInCombos
    ParseIniValues
    FillInCommandCombo
    dtBaseDateTime = DateSerial(1991, 5, 1)
    sWeekdays(0) = "N/A"
    sWeekdays(1) = "Sunday"
    sWeekdays(2) = "Monday"
    sWeekdays(3) = "Tuesday"
    sWeekdays(4) = "Wednesday"
    sWeekdays(5) = "Thursday"
    sWeekdays(6) = "Friday"
    sWeekdays(7) = "Saturday"
    DoEvents
    lngLastPid = -1
    lngLastGTASAHwnd = 0
    intWaitBeforeHook = 2
    intRefreshFormValues = 1
    Me.Enabled = True
    isGTASAiconic = True
    tmrHook.Enabled = True
Exit Sub
Resume_errFormLoad:
    CollectGarbage False
    Exit Sub

errFormLoad:
    MsgBox Err.Description, , "Initialisation Failed"
    Err.Clear
    Resume Resume_errFormLoad
    
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
On Error Resume Next
    If UnloadMode = vbFormControlMenu Then
        If isDirty(2) Or isDirty(1) Or isDirty(0) Then
            If MsgBox("Save Configuration changes?", vbQuestion + vbYesNo, "Save current Configuration?") = vbYes Then DumpChangesToCFG isDirty(0), isDirty(1), isDirty(2)
        End If
    End If
End Sub

Private Sub Form_Resize()
On Error Resume Next
    'No resize please:
    If (Me.WindowState <> vbMinimized) And Me.Visible Then
        If Me.Width < 12000 Then Me.Width = 12000: Exit Sub
        If Me.Height < 9000 Then Me.Height = 9000: Exit Sub
        ReplaceControls
    End If
End Sub

Private Sub ReplaceControls()
On Error Resume Next
    'let user maximize form, and we replace/resize relevant controls:
    sstMain.Move sstMain.Left, sstMain.Top, Me.Width - 195, Me.Height - 465
    Select Case sstMain.Tab
        Case 0 'Vehicle data
            cShapes(10).Height = sstMain.Height - 6120
            cShapes(2).Height = sstMain.Height - 585
            cShapes(1).Height = sstMain.Height - 4560
            cShapes(1).Width = sstMain.Width - 7845
            cShapes(3).Width = sstMain.Width - 7845
        Case 1 'Player Data
            cShapes(7).Height = sstMain.Height - 585
            cShapes(11).Height = sstMain.Height - 4515
            cShapes(9).Height = sstMain.Height - 585
            cShapes(9).Width = sstMain.Width - 7845
        Case 2 'garages
            sstGarages.Width = sstMain.Width - 315
            sstGarages.Height = sstMain.Height - 1065
        Case 3 'cheats
            tvCheats.Width = sstMain.Width - 3585
            tvCheats.Height = sstMain.Height - 675
            lblConsole(21).Left = sstMain.Width - 3285
            txtCheatString.Left = lblConsole(21).Left
            cmdCheats(0).Left = lblConsole(21).Left
            cmdCheats(1).Left = lblConsole(21).Left
            cmdCheats(2).Left = lblConsole(21).Left
            cmdCheats(3).Left = lblConsole(21).Left
            cmdCheats(4).Left = lblConsole(21).Left
            cmdCheats(5).Left = lblConsole(21).Left
        Case 4 'GTA SA Map & Locations
            picMapHolder.Width = sstMain.Width - 3945
            picMapHolder.Height = sstMain.Height - 795
            scrLeftRight.Width = picMapHolder.Width
            scrTopBottom.Height = picMapHolder.Height
            cmdCenterMap.Top = sstMain.Height - 360
            scrLeftRight.Top = cmdCenterMap.Top
            picLocationControls.Height = sstMain.Height - 450
            picLocationControls.Left = sstMain.Width - 3600
            tvLocations.Height = sstMain.Height - 3885
            ReplaceMap
        Case 5 'shortcuts
            tvShotcuts.Width = sstMain.Width - 3585
            tvShotcuts.Height = sstMain.Height - 675
            lblConsole(27).Left = sstMain.Width - 3270
            lblConsole(28).Left = lblConsole(27).Left
            lblConsole(0).Left = lblConsole(27).Left
            cboCommands(0).Left = lblConsole(27).Left
            cboCommands(1).Left = lblConsole(27).Left
            cboCommands(2).Left = lblConsole(27).Left
            picCommandData.Left = lblConsole(27).Left
            lblConsole(29).Left = lblConsole(27).Left
            chkShortcut(0).Left = sstMain.Width - 2535
            chkShortcut(1).Left = sstMain.Width - 1815
            cboShortcut.Left = sstMain.Width - 1215
            cmdShortcuts(0).Left = lblConsole(27).Left
            cmdShortcuts(1).Left = lblConsole(27).Left
            cmdShortcuts(2).Left = lblConsole(27).Left
            cmdShortcuts(3).Left = lblConsole(27).Left
            cmdShortcuts(4).Left = lblConsole(27).Left
            cmdShortcuts(5).Left = lblConsole(27).Left
            lblIntervall.Left = lblConsole(27).Left
            scrIntervall.Left = lblConsole(27).Left
            chkFeedback.Left = lblConsole(27).Left
            chkOrgSCM.Left = lblConsole(27).Left
            lblConsole(1).Left = sstMain.Width - 2490
            cboGTAVersion.Left = sstMain.Width - 945
    End Select
End Sub

Private Sub Form_Unload(Cancel As Integer)
On Error Resume Next
    isGTASAiconic = False
    If Not isCollectingGarbage Then
        'Stop Main Timer:
        tmrConsole.Enabled = False
        tmrFindCar.Enabled = False
        tmrHook.Enabled = False
        'Erase Private Arrays:
        CloseHandle lngPHandle
        'Collect Garbage
        CollectGarbage False
    End If
    
End Sub

Private Sub scrDateTime_Change()
On Error Resume Next
    Static isInternDateScroll As Boolean
    If isInternDateScroll Then Exit Sub
    isInternDateScroll = True
    If isHasHandle And isHasPlayer Then
        'read datetime first:
        dtGameDateTime = DateSerial(1991, 5, 1 + GetMemInt(GTASABaseAdr.DaysInGameAdr)) + TimeSerial(GetMemByte(GTASABaseAdr.CurrHourAdr), GetMemByte(GTASABaseAdr.CurrMinuteAdr), 0)
        'set from scroll:
        dtGameDateTime = DateAdd("n", scrDateTime.Value, dtGameDateTime)
        'write to memory:
        If DateDiff("d", dtBaseDateTime, dtGameDateTime) > -1 Then
            SetMemLong GTASABaseAdr.DaysInGameAdr, DateDiff("d", dtBaseDateTime, dtGameDateTime)
            SetMemByte GTASABaseAdr.CurrHourAdr, Hour(dtGameDateTime)
            SetMemByte GTASABaseAdr.CurrMinuteAdr, Minute(dtGameDateTime)
            SetMemByte GTASABaseAdr.CurrWeekdayAdr, CByte(Format(dtGameDateTime, "w", vbSunday))
            'visualise the change:
            'Game Time: 18:22 / Weekday: Wednesday / Day: 58
            lblConsole(30).Caption = "Game Time: " & Format(dtGameDateTime, "HH:nn") & " / Wd: " & sWeekdays(CInt(Format(dtGameDateTime, "w", vbSunday))) & " / Day: " & GetMemInt(GTASABaseAdr.DaysInGameAdr)
        End If
    End If
    scrDateTime.Value = 0
    isInternDateScroll = False
End Sub

Private Sub scrGameSpeed_Change(Index As Integer)
On Error Resume Next
    Dim lngNewMsToSecs As Long
    If isInternalClick Then Exit Sub
    'this scroll has values from -92 to 90, where - values are 1/ values
    'this edits the game speed by changing the ms to seconds converter (org: 1000 ms = 1 sn)
    If isHasPlayer And isHasHandle Then
        Select Case Index
            Case 0
                If scrGameSpeed(0).Value = 0 Then
                    lngNewMsToSecs = 1000
                ElseIf scrGameSpeed(0).Value < -91 Then
                    lngNewMsToSecs = 3600000 'stopped
                ElseIf scrGameSpeed(0).Value = -91 Then
                    lngNewMsToSecs = 60000 'real-time
                ElseIf scrGameSpeed(0).Value < 0 Then
                    lngNewMsToSecs = CLng(100000 / (100& + scrGameSpeed(0).Value))
                Else
                    lngNewMsToSecs = CLng(100000 / (100& + (10& * scrGameSpeed(0).Value)))
                End If
                SetMemLong GTASABaseAdr.GameSpeedMsAdr, lngNewMsToSecs
                If scrGameSpeed(0).Value = -92 Then
                    lblConsole(58).Caption = "Clock Speed : Stopped" 'stopped
                ElseIf scrGameSpeed(0).Value = -91 Then
                    lblConsole(58).Caption = "Clock Speed : Real-Time" 'real time
                ElseIf scrGameSpeed(0).Value < 0 Then
                    lblConsole(58).Caption = "Clock Speed : " & (100 + scrGameSpeed(0).Value) & " %"
                Else
                    lblConsole(58).Caption = "Clock Speed : " & (100 + (scrGameSpeed(0).Value * 10)) & " %"
                End If
            Case 1
                If scrGameSpeed(1).Value = 0 Then
                    lngNewMsToSecs = 1000
                ElseIf scrGameSpeed(1).Value < 0 Then
                    lngNewMsToSecs = CLng(10& * (100& + scrGameSpeed(1).Value))
                Else
                    lngNewMsToSecs = CLng(100& * (10& + scrGameSpeed(1).Value))
                End If
                SetMemFloat GTASABaseAdr.GameSpeedPctAdr, CSng(lngNewMsToSecs) / 1000
                If scrGameSpeed(1).Value < 0 Then
                    lblConsole(61).Caption = "Game Speed : " & (100 + scrGameSpeed(1).Value) & " %"
                Else
                    lblConsole(61).Caption = "Game Speed : " & (100 + (scrGameSpeed(1).Value * 10)) & " %"
                End If
        End Select
    End If
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub cmdGameSpeed_Click(Index As Integer)
On Error Resume Next    'set scroll value to 0
    If Index = 3 Then
        scrGameSpeed(0).Value = -91
    ElseIf Index = 2 Then
        scrGameSpeed(0).Value = -92
    Else
        scrGameSpeed(Index).Value = 0
    End If
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub scrPedSpeed_Change(Index As Integer)
On Error GoTo errscrPedSpeed_Change
    If isInternalClick Then Exit Sub
    Select Case Index
        Case 0 'X Speed     'If online, change MemValues as well:
            lblPedSpeed(0).Caption = "X Speed (" & scrPedSpeed(0).Value / 10 & "%)"
            If ReFillPlayerAdr Then SetMemFloat GTASAPlayerAddresse.lngPedSpeedAdr, scrPedSpeed(0).Value / 500
        Case 1 'Y Speed     'If online, change MemValues as well:
            lblPedSpeed(1).Caption = "Y Speed (" & scrPedSpeed(1).Value / 10 & "%)"
            If ReFillPlayerAdr Then SetMemFloat GTASAPlayerAddresse.lngPedSpeedAdr + 4, scrPedSpeed(1).Value / 500
        Case 2 'Z Speed     'If online, change MemValues as well:
            lblPedSpeed(2).Caption = "Z Speed (" & scrPedSpeed(2).Value / 10 & "%)"
            If ReFillPlayerAdr Then SetMemFloat GTASAPlayerAddresse.lngPedSpeedAdr + 8, scrPedSpeed(2).Value / 500
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errscrPedSpeed_Change:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmdStopPed_Click(Index As Integer)
On Error Resume Next
    If Index = 3 Then
        scrPedSpeed(0).Value = 0
        scrPedSpeed(1).Value = 0
        scrPedSpeed(2).Value = 0
    Else
        scrPedSpeed(Index).Value = 0
    End If
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oPedDirection_ButtonClick()
On Error GoTo erroPedDirection_ButtonClick
    Dim fBuffer As Single
    If ReFillPlayerAdr Then
        'Raise Ped about 50 cm:
        SetMemFloat GTASAPlayerAddresse.lngZposAdr, GetMemFloat(GTASAPlayerAddresse.lngZposAdr) + 0.05
        'Set Ped Position:
        carFlipPlacement = GTASACarPlacements(oPedDirection.Direction)
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, carFlipPlacement, 28&, 28&
        SetMemFloat GTASAPlayerAddresse.lngAngleAdr, GetGrad(oPedDirection.Direction * 45)
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
erroPedDirection_ButtonClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub oPedStart_ButtonClick()
On Error GoTo erroPedStart_ButtonClick
    If ReFillPlayerAdr Then
        'Raise Ped about 50 cm:
        SetMemFloat GTASAPlayerAddresse.lngZposAdr, GetMemFloat(GTASAPlayerAddresse.lngZposAdr) + 0.05
        'Set Ped Position:
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, GTASACarPlacements(oPedStart.Direction), 28&, 28&
        SetMemFloat GTASAPlayerAddresse.lngAngleAdr, GetGrad(oPedStart.Direction * 45)
        'KickStart (Set Speed Data):
        speedWriteBuffer.sngXSpeed = KickStartSpeeds(oPedStart.Direction).sngXSpeed * oPedStart.ScrollerVal / 500
        speedWriteBuffer.sngYSpeed = KickStartSpeeds(oPedStart.Direction).sngYSpeed * oPedStart.ScrollerVal / 500
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedWriteBuffer, 12&, 12&
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
erroPedStart_ButtonClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

'**********************************************************
'                       User Interaction
'**********************************************************

Private Sub sstMain_Click(PreviousTab As Integer)
On Error Resume Next
    Static iTvCtr As Integer
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
    ReplaceControls
End Sub

Private Sub sstMain_DblClick()
On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
    ReplaceControls
End Sub

'-----------------------------------------------------------------------------------------------------------------------
'               Dynamic Data Page
'-----------------------------------------------------------------------------------------------------------------------
Private Sub chkCarDynamics_Click(Index As Integer)
On Error GoTo errchkCarDynamics_Click
    If isInternalClick Then Exit Sub
    isAutoLockCarDoors = (chkCarDynamics(1).Value = 1) And optCarDoors(1).Value
    isPreventWheelDamage = (chkCarDynamics(2).Value = 1)
    isLockEngineHealth = (chkCarDynamics(3).Value = 1)
    isRestartCar = (chkCarDynamics(7).Value = 1)
    isFlightAssistance = (chkCarDynamics(8).Value = 1)
    sngAssistFlightBy = CSng(scrCarDynamics(8).Value) * 0.002
    sngLockEngineHealthTo = scrCarDynamics(0).Value
    isControlRCCars = (chkCarDynamics(9).Value = vbChecked)
    isFixLicensePlate = (chkCarDynamics(10).Value = vbChecked)
    sLicensePlate = txtLicensePlate.Text
    Select Case Index
        Case 0: WritePrivateProfileString "CarTracking", "SetCarSpecs", Format$(chkCarDynamics(0).Value) & "," & Format$(chkCarSpecs(0).Value) & "," & Format$(chkCarSpecs(1).Value) & "," & Format$(chkCarSpecs(2).Value) & "," & Format$(chkCarSpecs(3).Value), strIniFileName 'Set Car Specialities
        Case 1: WritePrivateProfileString "CarTracking", "CarDoors", Format$(chkCarDynamics(1).Value) & "," & Format$(Abs(CInt(optCarDoors(0).Value))), strIniFileName 'My car doors are
        Case 2: WritePrivateProfileString "CarTracking", "WheelDamage", Format$(chkCarDynamics(2).Value), strIniFileName 'Prevent Wheel Damage
        Case 3
            If chkCarDynamics(3).Value = vbChecked Then MsgBox "Locking Engine health has side effects in some missions (like car exploding during mission)." & vbCrLf & "Please use Damage-Proof switch instead of locking the health.", vbInformation
            WritePrivateProfileString "CarTracking", "EngineDamage", Format$(chkCarDynamics(3).Value) & "," & Format$(CInt(scrCarDynamics(0).Value)), strIniFileName 'Engine damage (0%)
        Case 4: WritePrivateProfileString "CarTracking", "CarWeight", Format$(chkCarDynamics(4).Value) & "," & Format$(scrCarDynamics(1).Value), strIniFileName 'Car Weight: (45,5 Tons)
        Case 5: WritePrivateProfileString "CarTracking", "PaintCar", Format$(chkCarDynamics(5).Value) & "," & picMajor.Tag & "," & Format$(chkMajorLock.Value) & "," & picMinor.Tag & "," & Format$(chkMinorLock.Value), strIniFileName 'Paint my car to:
        Case 8: WritePrivateProfileString "CarTracking", "FlightAssist", Format$(chkCarDynamics(8).Value) & "," & Format$(scrCarDynamics(8).Value), strIniFileName 'Flight Assistance
        Case 9: WritePrivateProfileString "CarTracking", "RCCars", Format$(chkCarDynamics(9).Value), strIniFileName 'Treat RC Cars as normal cars
        Case 6 'Stop car-alarm when I get in.
                WritePrivateProfileString "CarTracking", "CarAlarm", Format$(chkCarDynamics(6).Value), strIniFileName
                If (chkCarDynamics(6).Value = 1) And isHasHandle And tCurrCarAdr.isUsable Then SetMemLong tCurrCarAdr.lngSirenTimeAdr, 0 'Stop CarAlarm (set siren time left to 0)
        Case 7 'restart car if stalled
            WritePrivateProfileString "CarTracking", "RestartCar", Format$(chkCarDynamics(7).Value), strIniFileName 'Flight Assistance
            If (chkCarDynamics(7).Value = 1) And isHasHandle And tCurrCarAdr.isUsable Then
                If (GetMemByte(tCurrCarAdr.lngStalledAdr) And &H10) = 0 Then SetMemByte tCurrCarAdr.lngStalledAdr, GetMemByte(tCurrCarAdr.lngStalledAdr) Or &H10
            End If
        Case 10: WritePrivateProfileString "CarTracking", "LicensePlate", Format$(chkCarDynamics(10).Value) & "," & txtLicensePlate.Text, strIniFileName
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkCarDynamics_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkCarSpecs_Click(Index As Integer)
On Error GoTo errchkCarSpecs_Click
    If isInternalClick Then Exit Sub
    '01111111 Del EP 127    '11101111 Del DP 239    '11110111 Del FP 247    '11111011 Del BP 251
    '10000000 Set EP 128    '00010000 Set DP  16    '00001000 Set FP   8    '00000100 Set BP   4
    'If online, change MemValues:
    If isHasHandle And tCurrCarAdr.isUsable Then
        Select Case Index
            Case 0 'EP
                SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked)
                If tCurrTrailer.isUsable Then SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked)
            Case 1 'DP
                SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked)
                If tCurrTrailer.isUsable Then SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked)
            Case 2 'BP
                SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked)
                If tCurrTrailer.isUsable Then SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked)
            Case 3 'FP
                SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked)
                If tCurrTrailer.isUsable Then SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked)
        End Select
    End If
    'Write to ini:
    WritePrivateProfileString "CarTracking", "SetCarSpecs", Format$(chkCarDynamics(0).Value) & "," & Format$(chkCarSpecs(0).Value) & "," & Format$(chkCarSpecs(1).Value) & "," & Format$(chkCarSpecs(2).Value) & "," & Format$(chkCarSpecs(3).Value), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkCarSpecs_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub optCarDoors_Click(Index As Integer)
On Error GoTo erroptCarDoors_Click
    If isInternalClick Then Exit Sub
    isAutoLockCarDoors = (chkCarDynamics(1).Value = 1) And optCarDoors(1).Value
    'If online, change MemValues:
    If isHasHandle And tCurrCarAdr.isUsable Then SetMemByte tCurrCarAdr.lngCarDoorAdr, 2 + CInt(optCarDoors(0).Value)         'locked: Byte=2 / 'open:Byte=1
    'Write to ini:
    WritePrivateProfileString "CarTracking", "CarDoors", Format$(chkCarDynamics(1).Value) & "," & Format$(Abs(CInt(optCarDoors(0).Value))), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
erroptCarDoors_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmd50Ton_Click()
On Error Resume Next
    scrCarDynamics(1).Value = 4000 'let the change event handle rest...
End Sub

Private Sub scrCarDynamics_Change(Index As Integer)
On Error GoTo errscrCarDynamics_Change
    If isInternalClick Then Exit Sub
    sngLockEngineHealthTo = scrCarDynamics(0).Value
    sngAssistFlightBy = CSng(scrCarDynamics(8).Value) * 0.002
    Select Case Index
        Case 0 'Engine Damage
            chkCarDynamics(3).Caption = "Engine health (" & scrCarDynamics(0).Value \ 10 & "%):"
            'Write to ini:
            WritePrivateProfileString "CarTracking", "EngineHealth", Format$(chkCarDynamics(3).Value) & "," & Format$(CInt(scrCarDynamics(0).Value)), strIniFileName
            If isHasHandle And tCurrCarAdr.isUsable Then
                'Car Damage Tolerance left
                SetMemFloat tCurrCarAdr.lngCarDamageAdr, sngLockEngineHealthTo
                If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarDamageAdr, sngLockEngineHealthTo
            End If
        Case 1 'Car Weight
            chkCarDynamics(4).Caption = "Car Weight: (" & Format(scrCarDynamics(1).Value / 10, "0.0") & " Tons)"
            'Write to ini:
            WritePrivateProfileString "CarTracking", "CarWeight", Format$(chkCarDynamics(4).Value) & "," & Format$(scrCarDynamics(1).Value), strIniFileName
            If isHasHandle And tCurrCarAdr.isUsable Then SetCarWeight 'Change Car weight as needed
        Case 2 'X Speed     'If online, change MemValues as well:
            lblConsole(15).Caption = "X Speed (" & scrCarDynamics(2).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then
                SetMemFloat tCurrCarAdr.lngCarSpeedAdr, scrCarDynamics(2).Value / 500
                If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarSpeedAdr, scrCarDynamics(2).Value / 500
            End If
        Case 3 'Y Speed     'If online, change MemValues as well:
            lblConsole(16).Caption = "Y Speed (" & scrCarDynamics(3).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then 'Change values online
                SetMemFloat tCurrCarAdr.lngCarSpeedAdr + 4, scrCarDynamics(3).Value / 500
                If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarSpeedAdr + 4, scrCarDynamics(3).Value / 500
            End If
        Case 4 'Z Speed     'If online, change MemValues as well:
            lblConsole(17).Caption = "Z Speed (" & scrCarDynamics(4).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then 'Change values online
                SetMemFloat tCurrCarAdr.lngCarSpeedAdr + 8, scrCarDynamics(4).Value / 500
                If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarSpeedAdr + 8, scrCarDynamics(4).Value / 500
            End If
        Case 5 'X Spin      'If online, change MemValues as well:
            lblConsole(18).Caption = "X Spin (" & scrCarDynamics(5).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then SetMemFloat tCurrCarAdr.lngCarSpinAdr, scrCarDynamics(5).Value / 500
        Case 6 'Y Spin      'If online, change MemValues as well:
            lblConsole(19).Caption = "Y Spin (" & scrCarDynamics(6).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then SetMemFloat tCurrCarAdr.lngCarSpinAdr + 4, scrCarDynamics(6).Value / 500
        Case 7 'Z Spin      'If online, change MemValues as well:
            lblConsole(20).Caption = "Z Spin (" & scrCarDynamics(7).Value / 10 & "%)"
            If isHasHandle And tCurrCarAdr.isUsable Then SetMemFloat tCurrCarAdr.lngCarSpinAdr + 8, scrCarDynamics(7).Value / 500
        Case 8 'Flight Assistance Level:
            chkCarDynamics(8).Caption = "Flight Assistance (" & scrCarDynamics(8).Value / 10 & "%)"
            WritePrivateProfileString "CarTracking", "FlightAssist", Format$(chkCarDynamics(8).Value) & "," & Format$(scrCarDynamics(8).Value), strIniFileName
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errscrCarDynamics_Change:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkDontBurn_Click(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    isDontExplode = (chkDontBurn(1).Value = 1)
    isDontBurn = (chkDontBurn(0).Value = 1)
    If isDontBurn And (Not isDontExplode) Then
        isInternalClick = True
        chkDontBurn(1).Value = 1
        isDontExplode = True
        isInternalClick = False
    End If
    'Write to ini:
    WritePrivateProfileString "CarTracking", "DontBurn", Format$(chkDontBurn(0).Value) & "," & Format$(chkDontBurn(1).Value), strIniFileName
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub picMajor_DblClick()
On Error GoTo errpicMajor_DblClick
    'If Online, change Garage Cars:
    intLastPickedColor = CInt(picMajor.Tag)
    Load frmPickColor
    frmPickColor.iPickColor = intLastPickedColor
    frmPickColor.Show vbModal, Me
    intLastPickedColor = frmPickColor.iPickColor
    Unload frmPickColor
    picMajor.Tag = intLastPickedColor
    picMajor.BackColor = GTASAColors(intLastPickedColor).lngRGB
    If isHasHandle And tCurrCarAdr.isUsable Then SetMemByte tCurrCarAdr.lngCarColorAdr, CInt(picMajor.Tag)
    WritePrivateProfileString "CarTracking", "PaintCar", Format$(chkCarDynamics(5).Value) & "," & picMajor.Tag & "," & Format$(chkMajorLock.Value) & "," & picMinor.Tag & "," & Format$(chkMinorLock.Value), strIniFileName
Exit Sub
errpicMajor_DblClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkMajorLock_Click()
On Error GoTo errchkMajorLock_Click
    If isInternalClick Then Exit Sub
    If isHasHandle And tCurrCarAdr.isUsable And (chkMajorLock.Value = 1) Then SetMemByte tCurrCarAdr.lngCarColorAdr, CInt(picMajor.Tag)
    WritePrivateProfileString "CarTracking", "PaintCar", Format$(chkCarDynamics(5).Value) & "," & picMajor.Tag & "," & Format$(chkMajorLock.Value) & "," & picMinor.Tag & "," & Format$(chkMinorLock.Value), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkMajorLock_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub picMinor_DblClick()
On Error GoTo errpicMinor_DblClick
    intLastPickedColor = CInt(picMinor.Tag)
    Load frmPickColor
    frmPickColor.iPickColor = intLastPickedColor
    frmPickColor.Show vbModal, Me
    intLastPickedColor = frmPickColor.iPickColor
    Unload frmPickColor
    picMinor.Tag = intLastPickedColor
    picMinor.BackColor = GTASAColors(intLastPickedColor).lngRGB
    If isHasHandle And tCurrCarAdr.isUsable Then SetMemByte tCurrCarAdr.lngCarColorAdr + 1, CInt(picMinor.Tag)
    WritePrivateProfileString "CarTracking", "PaintCar", Format$(chkCarDynamics(5).Value) & "," & picMajor.Tag & "," & Format$(chkMajorLock.Value) & "," & picMinor.Tag & "," & Format$(chkMinorLock.Value), strIniFileName
Exit Sub
errpicMinor_DblClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkMinorLock_Click()
On Error GoTo errchkMinorLock_Click
    If isInternalClick Then Exit Sub
    If isHasHandle And tCurrCarAdr.isUsable And (chkMinorLock.Value = 1) Then SetMemByte tCurrCarAdr.lngCarColorAdr + 1, CInt(picMinor.Tag)
    WritePrivateProfileString "CarTracking", "PaintCar", Format$(chkCarDynamics(5).Value) & "," & picMajor.Tag & "," & Format$(chkMajorLock.Value) & "," & picMinor.Tag & "," & Format$(chkMinorLock.Value), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkMinorLock_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmdStopCar_Click(Index As Integer)
On Error GoTo errcmdStopCar_Click
    isInternalClick = False
    Select Case Index
        Case 0, 1, 2, 3, 4, 5 'Stop X Speed'Stop Y Speed'Stop Z Speed'Stop X Spin'Stop Y Spin'Stop Z Spin
            scrCarDynamics(Index + 2).Value = 0
        Case 6 'Stop All Speed
            scrCarDynamics(2).Value = 0
            scrCarDynamics(3).Value = 0
            scrCarDynamics(4).Value = 0
        Case 7 'Stop All Spin
            scrCarDynamics(5).Value = 0
            scrCarDynamics(6).Value = 0
            scrCarDynamics(7).Value = 0
        Case 8 'Stop Everything (Freeze Car)
            scrCarDynamics(2).Value = 0
            scrCarDynamics(3).Value = 0
            scrCarDynamics(4).Value = 0
            scrCarDynamics(5).Value = 0
            scrCarDynamics(6).Value = 0
            scrCarDynamics(7).Value = 0
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdStopCar_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub oCarDirection_ButtonClick()
On Error GoTo erroCarDirection_ButtonClick
    Dim fBuffer As Single
    If isHasHandle And tCurrCarAdr.isUsable Then
        'Raise Car about 50 cm:
        SetMemFloat tCurrCarAdr.lngCarLocAdr + 8, GetMemFloat(tCurrCarAdr.lngCarLocAdr + 8) + 0.05
        'Set Car Position:
        carFlipPlacement = GTASACarPlacements(oCarDirection.Direction)
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 28&
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
erroCarDirection_ButtonClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub oCarStart_ButtonClick()
On Error GoTo erroCarStart_ButtonClick
    If isHasHandle And tCurrCarAdr.isUsable Then
        'Raise Car about 50 cm:
        SetMemFloat tCurrCarAdr.lngCarLocAdr + 8, GetMemFloat(tCurrCarAdr.lngCarLocAdr + 8) + 0.05
        'Set Car Position:
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, GTASACarPlacements(oCarStart.Direction), 28&, 28&
        'KickStart (Set Speed Data):
        speedWriteBuffer.sngXSpeed = KickStartSpeeds(oCarStart.Direction).sngXSpeed * oCarStart.ScrollerVal / 500
        speedWriteBuffer.sngYSpeed = KickStartSpeeds(oCarStart.Direction).sngYSpeed * oCarStart.ScrollerVal / 500
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedWriteBuffer, 12&, 12&
        If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedWriteBuffer, 12&, 12&
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
erroCarStart_ButtonClick:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmdFlipCar_Click()
On Error GoTo errcmdFlipCar_Click
    If isHasHandle And tCurrCarAdr.isUsable Then
'      1North  2NNE     2NE    2NEE    3East   4EES    4ES     4ESS
'       -0..    -+..    -+..    -+..    0+..    ++..    ++..    ++..
'       +0..    +-..    +-.     +-..    0-..    --..    --..    --..
'      5South  6SSW    6SW     6SWW    7West   8WWN    8WN     8WNN
'       +0..    +-..    +-..    +-..    0-..    --..    --..    --..
'       -0..    -+..    -+..    -+..    0+..    ++..    ++..    ++..
'       X°/Y°/./.
        'Read Car Placement:
        ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 0&
        If carFlipPlacement.sngXGrad < 0 And carFlipPlacement.sngYGrad = 0 Then
            carFlipPlacement.sngXGrad = Abs(carFlipPlacement.sngXGrad)
        ElseIf carFlipPlacement.sngXGrad < 0 And carFlipPlacement.sngYGrad > 0 Then
            carFlipPlacement.sngXGrad = Abs(carFlipPlacement.sngXGrad)
            carFlipPlacement.sngYGrad = 0 - carFlipPlacement.sngYGrad
        ElseIf carFlipPlacement.sngXGrad = 0 And carFlipPlacement.sngYGrad > 0 Then
            carFlipPlacement.sngYGrad = 0 - carFlipPlacement.sngYGrad
        ElseIf carFlipPlacement.sngXGrad > 0 And carFlipPlacement.sngYGrad > 0 Then
            carFlipPlacement.sngXGrad = 0 - carFlipPlacement.sngXGrad
            carFlipPlacement.sngYGrad = 0 - carFlipPlacement.sngYGrad
        ElseIf carFlipPlacement.sngXGrad > 0 And carFlipPlacement.sngYGrad = 0 Then
            carFlipPlacement.sngXGrad = 0 - carFlipPlacement.sngXGrad
        ElseIf carFlipPlacement.sngXGrad > 0 And carFlipPlacement.sngYGrad < 0 Then
            carFlipPlacement.sngXGrad = 0 - carFlipPlacement.sngXGrad
            carFlipPlacement.sngYGrad = Abs(carFlipPlacement.sngYGrad)
        ElseIf carFlipPlacement.sngXGrad = 0 And carFlipPlacement.sngYGrad < 0 Then
            carFlipPlacement.sngYGrad = Abs(carFlipPlacement.sngYGrad)
        ElseIf carFlipPlacement.sngXGrad < 0 And carFlipPlacement.sngYGrad < 0 Then
            carFlipPlacement.sngXGrad = Abs(carFlipPlacement.sngXGrad)
            carFlipPlacement.sngYGrad = Abs(carFlipPlacement.sngYGrad)
        End If
        'Raise Car about 100 cm:
        SetMemFloat tCurrCarAdr.lngCarLocAdr + 8, GetMemFloat(tCurrCarAdr.lngCarLocAdr + 8) + 0.1
        'Write Car Positioning back:
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 28&
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdFlipCar_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmdMain_Click(Index As Integer)
On Error Resume Next
GoTo alper

    Open "e:\was.dmp" For Binary As #1
    Put #1, , bInjectedCode
    Close #1
    Exit Sub
alper:
    Static sNewVal As String
    Select Case Index
        Case 0 'Resync
            tmrHook.Enabled = False
            lngLastGTASAHwnd = 0
            isHasPlayer = False
            'not injected, check and set captions and availability:
            isInjected = False
            isInternInjectCheck = True
            If chkSpawnVehicle.Value <> vbUnchecked Then chkSpawnVehicle.Value = vbUnchecked
            If chkSpawnVehicle.Caption <> "Spawner Code-Injection Status: (unknown)" Then chkSpawnVehicle.Caption = "Spawner Code-Injection Status: (unknown)"
            If chkSpawnVehicle.Enabled Then chkSpawnVehicle.Enabled = False
            If cmdSpawnCar(0).Enabled Then cmdSpawnCar(0).Enabled = False
            isInternInjectCheck = False
            strCarType = ""
            tmrConsole.Enabled = False
            tmrFindCar.Enabled = False
            intWaitBeforeHook = 3
            intRefreshFormValues = 1
            isHasHandle = False
            isHasPlayer = False
            isHadCar = False
            isHasCar = False
            lngPHandle = 0
            lngPid = 0
            tCurrCarAdr.isUsable = False
            tCurrTrailer.isUsable = False
            isGTASAiconic = True
            lngLastPid = -1
            If Me.Caption <> "GTASA Control Center" Then Me.Caption = "GTASA Control Center"
            tmrHook.Enabled = True
        Case 1 'set current money
            If isHasHandle And isHasPlayer Then
                'read current money:
                On Error GoTo errMoneyValErr
                sNewVal = InputBox("Enter new Money value", "Enter a value to set Money", GetMemLong(GTASABaseAdr.MoneyAdr))
                If Len(sNewVal) > 0 Then
                    If IsNumeric(sNewVal) Then SetMemLong GTASABaseAdr.MoneyAdr, CLng(sNewVal)
                End If
            Else
                MsgBox "Start GTA SA and load/start a game first.", vbInformation
            End If
        Case 2 'Clear Cheated Status and Count
            If isHasHandle And isHasPlayer Then
                SetMemLong GTASABaseAdr.CheatCountAdr, 0
                SetMemLong GTASABaseAdr.CheatStatAdr, 0
            Else
                MsgBox "Start GTA SA and load/start a game first.", vbInformation
            End If
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errMoneyValErr:
    Err.Clear
End Sub

Private Sub cboWeather_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    If cboWeather.ListIndex < 0 Then Exit Sub
    lngLockWeatherTo = cboWeather.ListIndex
    If isHasHandle And isHasPlayer Then
        'set weather:
        If isWeatherLock Then SetMemLong GTASABaseAdr.WeatherLockAdr, lngLockWeatherTo
        SetMemLong GTASABaseAdr.WeatherToGoAdr, lngLockWeatherTo
        SetMemLong GTASABaseAdr.WeatherCurrentAdr, lngLockWeatherTo
    End If
    WritePrivateProfileString "Main", "Weather", Format$(chkWeatherLock.Value) & "," & Format$(lngLockWeatherTo), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub chkSpawnVehicle_Click()
On Error Resume Next
    If isInternInjectCheck Then Exit Sub
    If Not isHasHandle Then
        MsgBox "Please start GTA SA and retry again.", vbInformation
        isInternInjectCheck = True
        chkSpawnVehicle.Value = vbUnchecked
        chkSpawnVehicle.Caption = "Spawner Code-Injection Status: (unknown)"
        chkSpawnVehicle.Enabled = False
        cmdSpawnCar(0).Enabled = False
        isInjected = False
        isInternInjectCheck = False
        Exit Sub
    End If
    If chkSpawnVehicle.Value = vbChecked Then 'inject required
        If CheckIfInjectable Then
            If CheckIfInjected Then
                'already injected
                chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
                cmdSpawnCar(0).Enabled = True
                isInjected = True
            Else
                If iInjectMsgCtr < 1 Then
                    'shown 3 times
                    'inject code:
                    WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCodeAdr, bInjectedCode(0), 504&, 504&
                    WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectedJump(0), 5&, 5&
                    chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
                    cmdSpawnCar(0).Enabled = True
                    isInjected = True
                ElseIf MsgBox("GTA SA Control Center will now inject Car-Spawner ASM Code to your GTASA Executable." & vbCrLf & _
                              "Please make a backup of your gta_sa.exe before proceeding." & _
                              "This message will be shown " & iInjectMsgCtr - 1 & " more time(s)." & _
                              vbCrLf & vbCrLf & "Proceed Code Injection?", vbQuestion + vbDefaultButton2 + vbYesNoCancel) = vbYes Then
                    iInjectMsgCtr = iInjectMsgCtr - 1
                    WritePrivateProfileString "CarTracking", "InjectMsg", Format$(iInjectMsgCtr), strIniFileName
                    'inject code:
                    WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCodeAdr, bInjectedCode(0), 504&, 504&
                    WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectedJump(0), 5&, 5&
                    chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
                    cmdSpawnCar(0).Enabled = True
                    isInjected = True
                Else 'user aborted injection.
                    isInternInjectCheck = True
                    chkSpawnVehicle.Value = vbUnchecked
                    chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injected"
                    cmdSpawnCar(0).Enabled = False
                    isInternInjectCheck = False
                    isInjected = False
                End If
            End If
        Else 'asm code is not injectable.
            MsgBox "The Car Spawn ASM Code cannot be injected!!" & vbCrLf & "Your GTASA Executable is not original." & vbCrLf & "Please restore original exe and try again.", vbExclamation
            isInternInjectCheck = True
            chkSpawnVehicle.Value = vbUnchecked
            chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injectable"
            chkSpawnVehicle.Enabled = False
            cmdSpawnCar(0).Enabled = False
            isInternInjectCheck = False
            isInjected = False
        End If
    Else 'restore required
        If CheckIfInjected Then
            'revert code-injection:
            WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bNotInjectedJump(0), 5&, 5&
            WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCodeAdr, bNotInjectedCode(0), 504&, 504&
            MsgBox "CarSpawn Code-Injection has been reverted to Original." & vbCrLf & "CarSpawn related functions will not be available" & vbCrLf & "until you re-inject the code.", vbInformation
            chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injected"
            cmdSpawnCar(0).Enabled = False
        ElseIf CheckIfInjectable Then
            chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injected"
            cmdSpawnCar(0).Enabled = False
        Else
            MsgBox "The Car Spawn ASM Code-Injection cannot be reverted!!" & vbCrLf & vbCrLf & "Please restore original gta_sa.exe.", vbExclamation
            chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injectable"
            chkSpawnVehicle.Enabled = False
            cmdSpawnCar(0).Enabled = False
        End If
        isInjected = False
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Function CheckIfInjectable(Optional ByVal isSilentCheck As Boolean = True) As Boolean
On Error GoTo errCheckIfInjectable
    If isHasHandle Then
        'read injection status:
        ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectCheck(0), 5&, 0&
        If ((bInjectCheck(0) = bInjectedJump(0)) And (bInjectCheck(1) = bInjectedJump(1)) And _
            (bInjectCheck(2) = bInjectedJump(2)) And (bInjectCheck(3) = bInjectedJump(3)) And _
            (bInjectCheck(4) = bInjectedJump(4))) Then
            'already injected, return true for isInjectable
            CheckIfInjectable = True
        ElseIf ((bInjectCheck(0) = bNotInjectedJump(0)) And (bInjectCheck(1) = bNotInjectedJump(1)) And _
                (bInjectCheck(2) = bNotInjectedJump(2)) And (bInjectCheck(3) = bNotInjectedJump(3)) And _
                (bInjectCheck(4) = bNotInjectedJump(4))) Then
           'original, return true for isInjectable
           CheckIfInjectable = True
        Else
            'inject region is unknown. return false:
            CheckIfInjectable = False
        End If
    Else
        'no handle, no injection. return false
        CheckIfInjectable = False
    End If

Exit Function
errCheckIfInjectable:
    If (Not isGTASAiconic) And (Not isSilentCheck) Then MsgBox "Error during Code-Injection Check!!" & vbCrLf & Err.Description, vbCritical
    CheckIfInjectable = False
    Err.Clear
End Function

Private Function CheckIfInjected(Optional ByVal isSilentCheck As Boolean = True) As Boolean
On Error GoTo errCheckIfInjected
    If isHasHandle Then
        'read injection status:
        ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectCheck(0), 5&, 0&
        If ((bInjectCheck(0) = bInjectedJump(0)) And (bInjectCheck(1) = bInjectedJump(1)) And _
            (bInjectCheck(2) = bInjectedJump(2)) And (bInjectCheck(3) = bInjectedJump(3)) And _
            (bInjectCheck(4) = bInjectedJump(4))) Then
            'already injected, return true for isInjectable
            CheckIfInjected = True
        Else
            'inject region is unknown. return false:
            CheckIfInjected = False
        End If
    Else
        'no handle, no injection. return false
        CheckIfInjected = False
    End If
Exit Function
errCheckIfInjected:
    If (Not isGTASAiconic) And (Not isSilentCheck) Then MsgBox "Error during Code-Injection Check!!" & vbCrLf & Err.Description, vbCritical
    CheckIfInjected = False
    Err.Clear
End Function

Private Sub cmdSpawnCar_Click(Index As Integer)
On Error GoTo errSpawnCar
    Dim iNewCarID As Integer
    Select Case Index
        Case 0 'Spawn
            If isInjected Then
                If cboSpawnCar.ListIndex > -1 Then
                    SetMemLong GTASABaseAdr.CarSpawnAdr, SpawnCarMatrix(cboSpawnCar.ListIndex)
                End If
            End If
        Case 1 'Select
            iNewCarID = -1
            If Not isCarPicsReady Then
                Load frmCarSelect 'if not already loaded. This form does not get unloaded until gtasa Control Center exits.
                Do Until isCarPicsReady
                    DoEvents
                Loop
                frmCarSelect.Hide
            End If
            If cboSpawnCar.ListIndex > 0 Then
                frmCarSelect.PreSelectCarID SpawnCarMatrix(cboSpawnCar.ListIndex)
            Else
                frmCarSelect.PreSelectCarID -1
            End If
            frmCarSelect.Show vbModal, Me
            DoEvents
            If frmCarSelect.isOKClicked Then iNewCarID = frmCarSelect.iSelectedID
            If iNewCarID > 0 Then cboSpawnCar.ListIndex = SpawnListMatrix(iNewCarID)
    End Select
    On Error Resume Next
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
Exit Sub
errSpawnCar:
    MsgBox Err.Description
End Sub

Private Sub chkSafeCheats_Click()
On Error Resume Next
    isSafeCheats = (chkSafeCheats.Value = vbChecked) 'Safe Cheats
    WritePrivateProfileString "Main", "SafeCheats", Format$(chkSafeCheats.Value), strIniFileName
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oCheatStates_CheatClicked(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    If Index = 10 Then 'Fast Cars, toggling cheats
        If oCheatStates(10).CheatState = vbChecked And oCheatStates(11).CheatState = vbChecked Then oCheatStates(11).CheatState = vbUnchecked
        If ReFillPlayerAdr Then SetMemByte GTASABaseAdr.cFastCarsAdr, oCheatStates(10).CheatState
    ElseIf Index = 11 Then 'Cheap Cars, toggling cheats
        If oCheatStates(10).CheatState = vbChecked And oCheatStates(11).CheatState = vbChecked Then oCheatStates(10).CheatState = vbUnchecked
        If ReFillPlayerAdr Then SetMemByte GTASABaseAdr.cCheapCarsAdr, oCheatStates(11).CheatState
    ElseIf Index = 20 Then 'one hit kill
        'check the mem status:
        ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectCheck_OneHitKill(0), 5&, 0&
        If oCheatStates(20).CheatState = vbChecked Then
            'inject if injectable:
            If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                'jump code is already injected!!
            ElseIf ((bInjectCheck_OneHitKill(0) = bNotInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bNotInjectedJump_OneHitKill(1)) And _
                   (bInjectCheck_OneHitKill(2) = bNotInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bNotInjectedJump_OneHitKill(3)) And _
                   (bInjectCheck_OneHitKill(4) = bNotInjectedJump_OneHitKill(4))) Then
                'jump code is injectable:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCode_OneHitKillAdr, bInjectedCode_OneHitKill(0), 47&, 47&
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectedJump_OneHitKill(0), 5&, 5&
            Else
                If isGTASAiconic And Not isTimerClick Then
                    MsgBox "One-Hit-Kill code can not be injected!!"
                End If
            End If
        Else
            'remove injection:
            'inject if injectable:
            If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                'jump code is injected, remove injection:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bNotInjectedJump_OneHitKill(0), 5&, 5&
            End If
        End If
    ElseIf Index = 21 Then 'freeze timers
        If oCheatStates(21).CheatState = vbChecked Then
            'inject if injectable:
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = iOrg_FreezeTimerUp Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, &H9090
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = iOrg_FreezeTimerDown Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, &H9090
        Else
            'remove injection if it was injected/injectable:
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = &H9090 Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, iOrg_FreezeTimerUp
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = &H9090 Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, iOrg_FreezeTimerDown
        End If
    Else
        'Never Wanted=0'Never Get Hungry=1'Infinite Health=2'Infinite Oxygen=3'Infinite Ammo=4'Tank Mode=5
        'Mega Punch=6'Mega Jump=7'Max Respect=8'Max Sex Appeal=9'Fast Cars=10'Cheap Cars=11'Infinite Run=12'Fireproof=13
        'Perfect Handling=14'Decreased Traffic=15'Huge Bunny Hop=16'Cars Have Nitro=17'Boats can Fly=18'Cars can Fly=19
        If ReFillPlayerAdr Then SetMemByte GTASABaseAdr.cCheatsAdr(Index), oCheatStates(Index).CheatState
    End If
    WritePrivateProfileString "Main", oCheatStates(Index).Tag, Format$(oCheatStates(Index).CheatLock) & "," & Format$(oCheatStates(Index).CheatState), strIniFileName
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oCheatStates_LockedClicked(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    WritePrivateProfileString "Main", oCheatStates(Index).Tag, Format$(oCheatStates(Index).CheatLock) & "," & Format$(oCheatStates(Index).CheatState), strIniFileName
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub chkFixPedSpecs_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    isFixPed = (chkFixPedSpecs.Value = 1)
    WritePrivateProfileString "PlayerTracking", "FixPed", Format$(chkFixPedSpecs.Value) & "," & Format$(chkPedSpecs(0).Value) & "," & Format$(chkPedSpecs(1).Value) & "," & Format$(chkPedSpecs(2).Value) & "," & Format$(chkPedSpecs(3).Value), strIniFileName 'Lock Ped EPDPFPBP
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oPedStats_ButtonClick(Index As Integer)
On Error Resume Next
    oPedStats(Index).ScrollVal = oPedStats(Index).ButtonVal
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oPedStats_LockedClick(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    isLockArmor = (oPedStats(0).Locked = 1)
    isLockHealth = (oPedStats(1).Locked = 1)
    isLockFat = (oPedStats(2).Locked = 1)
    isLockStamina = (oPedStats(3).Locked = 1)
    isLockMuscle = (oPedStats(4).Locked = 1)
    isLockLungStat = (oPedStats(5).Locked = 1)
    isLockGamblingStat = (oPedStats(6).Locked = 1)
    isLockDrivingProf = (oPedStats(7).Locked = 1)
    isLockBikingProf = (oPedStats(8).Locked = 1)
    isLockCyclingProf = (oPedStats(9).Locked = 1)
    isLockPilotProf = (oPedStats(10).Locked = 1)
    isPedFlightAssistance = (oPedStats(20).Locked = 1)
    WritePrivateProfileString "PlayerTracking", oPedStats(Index).Tag, Format$(oPedStats(Index).Locked) & "," & Format$(oPedStats(Index).ScrollVal), strIniFileName
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oPedStats_ScrollChange(Index As Integer)
On Error GoTo errPedStats_Change
    Static iStatCtr As Integer
    If isInternalClick Then Exit Sub
    sngLockArmorTo = oPedStats(0).ScrollVal
    sngLockHealthTo = oPedStats(1).ScrollVal
    sngLockFatTo = oPedStats(2).ScrollVal
    sngLockStaminaTo = oPedStats(3).ScrollVal
    sngLockMuscleTo = oPedStats(4).ScrollVal
    lngLockLungStatTo = oPedStats(5).ScrollVal
    sngLockGamblingStatTo = oPedStats(6).ScrollVal
    lngLockDrivingProfTo = oPedStats(7).ScrollVal
    lngLockBikingProfTo = oPedStats(8).ScrollVal
    lngLockCyclingProfTo = oPedStats(9).ScrollVal
    lngLockPilotProfTo = oPedStats(10).ScrollVal
    sngPedAssistFlightBy = CSng(oPedStats(20).ScrollVal) * 0.002
    If ReFillPlayerAdr Then
        Select Case Index
            Case 0: SetMemFloat GTASAPlayerAddresse.lngArmorAdr, oPedStats(0).ScrollVal 'Write Player Armor
            Case 1 'Health Level
                    SetMemFloat GTASAPlayerAddresse.lngMaxHealthAdr, oPedStats(1).ScrollVal 'max health
                    SetMemFloat GTASAPlayerAddresse.lngHealthAdr, oPedStats(1).ScrollVal  'current health
                    SetMemFloat GTASABaseAdr.MaxHealthStatAdr, 1000 'max health stat to 1000
            Case 2: SetMemFloat GTASABaseAdr.FatStatAdr, oPedStats(2).ScrollVal 'Write Player Armor
            Case 3: SetMemFloat GTASABaseAdr.StaminaStatAdr, oPedStats(3).ScrollVal 'Write Player Stamina
            Case 4: SetMemFloat GTASABaseAdr.MuscleStatAdr, oPedStats(4).ScrollVal 'Write Player Muscle
            Case 5: SetMemLong GTASABaseAdr.LungCapacityAdr, oPedStats(5).ScrollVal 'Write Player Lung Stat
            Case 6: SetMemFloat GTASABaseAdr.GamblingStatAdr, oPedStats(6).ScrollVal 'Write Gambling Stat
            Case 7: SetMemLong GTASABaseAdr.VehicleProfAdr(0), oPedStats(7).ScrollVal 'Driving Stat
            Case 8: SetMemLong GTASABaseAdr.VehicleProfAdr(1), oPedStats(8).ScrollVal 'Biking Stat
            Case 9: SetMemLong GTASABaseAdr.VehicleProfAdr(2), oPedStats(9).ScrollVal 'Cycling Stat
            Case 10: SetMemLong GTASABaseAdr.VehicleProfAdr(3), oPedStats(10).ScrollVal 'Pilot Stat
        End Select
    End If
    WritePrivateProfileString "PlayerTracking", oPedStats(Index).Tag, Format$(oPedStats(Index).Locked) & "," & Format$(oPedStats(Index).ScrollVal), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errPedStats_Change:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cmdWeaponStat_Click()
On Error Resume Next
    Dim sngWeaponProfTotal As Single
    Dim iStatCtr As Integer
    'show the weapon stats:
    frmWeaponStats.Show vbModal, Me
    DoEvents
    Unload frmWeaponStats
    'refresh averages:
    sngWeaponProfTotal = 0
    For iStatCtr = 0 To 9
        sngWeaponProfTotal = sngWeaponProfTotal + GetMemFloat(GTASABaseAdr.WeaponProfStatAdr(iStatCtr))
    Next iStatCtr
    lblConsole(57).Caption = "Average Weapon Proficiency: " & Format(sngWeaponProfTotal / 100, "#0") & " %"
End Sub

Private Sub chkPedSpecs_Click(Index As Integer)
On Error GoTo errchkPedSpecs_Click
    If isInternalClick Then Exit Sub
    'If online, change MemValues:
    If ReFillPlayerAdr Then
        '01111111 Del EP 127    '10111111 Del DP 191    '11110111 Del FP 247    '11111011 Del BP 251
        '10000000 Set EP 128    '01000000 Set DP  64    '00001000 Set FP   8    '00000100 Set BP   4
        'Integer at Offset 66:   1..111.. EP/NA/NA/DP/FP/BP/NA/NA
        Select Case Index
            Case 0: SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 7, (chkPedSpecs(0).Value = vbChecked) 'EP
            Case 1: SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 6, (chkPedSpecs(1).Value = vbChecked) 'DP
            Case 2: SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 2, (chkPedSpecs(2).Value = vbChecked) 'BP
            Case 3: SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 3, (chkPedSpecs(3).Value = vbChecked) 'FP
        End Select
        'Show Ped Specialities:
        lblCurrentPlayer.Caption = "Current Player: " & IIf(chkPedSpecs(0).Value = vbChecked, "EP", "") & IIf(chkPedSpecs(1).Value = vbChecked, "+DP", "") & IIf(chkPedSpecs(2).Value = vbChecked, "+BP", "") & IIf(chkPedSpecs(3).Value = vbChecked, "+FP", "")
        If lblCurrentPlayer.Caption = "Current Player: " Then lblCurrentPlayer.Caption = "Current Player: No Specialities"
    End If
    'Write to ini:
    WritePrivateProfileString "PlayerTracking", "FixPed", Format$(chkFixPedSpecs.Value) & "," & Format$(chkPedSpecs(0).Value) & "," & Format$(chkPedSpecs(1).Value) & "," & Format$(chkPedSpecs(2).Value) & "," & Format$(chkPedSpecs(3).Value), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkPedSpecs_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub oGFStats_ButtonClick(Index As Integer)
On Error Resume Next
    If Not (isHasHandle And isHasPlayer) Then MsgBox "Please start GTA SA and load/start a game first!", vbInformation: Exit Sub
    Select Case Index
        Case 0 'Denise, Req: None, 00:00 to 6:00 / 16:00 to 00:00
            PasteWarpLoc 0, "2402.54;-1727.254;12.874;90"
            If isHasFeedback Then OnScreenText "Get to next bar, or drive-by around"
        Case 1 'Michelle, Req: High fat (at least 50%) High sex appeal, 00:00 and 12:00
            If isLockFat Then
                oPedStats(2).Locked = vbUnchecked 'clear forced writeover
                isLockFat = False
            End If
            SetMemFloat GTASABaseAdr.FatStatAdr, 750
            PasteWarpLoc 0, "-1791.83;1193.698;24.561;90"
            If isHasFeedback Then OnScreenText "Get to next bar, or drive fast"
        Case 2 'Helena, Req: Low muscle (less than 25%) Low fat High sex appeal, 00:00 to 2:00 / 08:00 to 12:00 / 14:00 to 00:00
            If isLockFat Then
                oPedStats(2).Locked = vbUnchecked 'clear forced writeover
                isLockFat = False
            End If
            If isLockMuscle Then
                oPedStats(4).Locked = vbUnchecked 'clear forced writeover
                isLockMuscle = False
            End If
            SetMemFloat GTASABaseAdr.FatStatAdr, 0
            SetMemFloat GTASABaseAdr.MuscleStatAdr, 200
            PasteWarpLoc 0, "-373.616;-1441.395;25.927;90"
            If isHasFeedback Then OnScreenText "Get to restaurant in Rodeo district, or drive slowly around her house"
        Case 3 'Katie, Req: high muscle (around 75%) high sex appeal, 12:00 to 00:00
            If isLockMuscle Then
                oPedStats(4).Locked = vbUnchecked 'clear forced writeover
                isLockMuscle = False
            End If
            SetMemFloat GTASABaseAdr.MuscleStatAdr, 1000
            PasteWarpLoc 0, "-2575.641;1142.277;55.382;90"
            If isHasFeedback Then OnScreenText "Get to closest diner, or drive slowly in chinatown"
        Case 4 'Barbara, Req: high fat (at least 50%) high sex appeal, 00:00 to 6:00 / 16:00 to 00:00
            If isLockFat Then
                oPedStats(2).Locked = vbUnchecked 'clear forced writeover
                isLockFat = False
            End If
            SetMemFloat GTASABaseAdr.FatStatAdr, 750
            PasteWarpLoc 0, "-1404.344;2640.061;55.887;90"
            If isHasFeedback Then OnScreenText "Get to next diner, or drive slowly around el quebrados"
        Case 5 'Millie, Req: - none, 12:00 to 22:00
            PasteWarpLoc 0, "2037.287;2734.815;10.415;90"
            If isHasFeedback Then OnScreenText "Go to next restaurant, Camel's Toe Dance Club, or drive around her house, avg. speed"
    End Select
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub oGFStats_LockedClick(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    isLockGF(Index) = (oGFStats(Index).Locked = vbChecked)
    WritePrivateProfileString "PlayerTracking", oGFStats(Index).Tag, Format$(oGFStats(Index).Locked) & "," & Format$(CInt(oGFStats(Index).ScrollVal)), strIniFileName
End Sub

Private Sub oGFStats_ScrollChange(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    If ReFillPlayerAdr Then
        SetMemLong GTASABaseAdr.GFStatAdr(Index), oGFStats(Index).ScrollVal 'Denise/Michelle/Helena/Katie/Barbara/Millie
        If isOrgSCM Then SetMemLong GTASABaseAdr.GFProgressAdr(Index), oGFStats(Index).ScrollVal 'Denise/Michelle/Helena/Katie/Barbara/Millie
    End If
    lngLockGFto(Index) = oGFStats(Index).ScrollVal
    WritePrivateProfileString "PlayerTracking", oGFStats(Index).Tag, Format$(oGFStats(Index).Locked) & "," & Format$(CInt(oGFStats(Index).ScrollVal)), strIniFileName
End Sub


'-----------------------------------------------------------------------------------------------------------------
'                               Garages Page
'-----------------------------------------------------------------------------------------------------------------

Private Sub cmdGarages_Click(Index As Integer)
On Error GoTo errcmdGarages_Click
    Dim iGarageCtr As Integer
    Dim iCarCtr As Integer
    Dim iCarCount As Integer
    Dim iNrOfBikes As Integer
    Dim iParkedCount As Integer
    Dim iParkedBikeCount As Integer
    Dim strBuffer As String
    Dim sngWidthOffset As Single
    Dim sngDepthOffset As Single
    Dim sngDepthDivider As Single
    Dim tGarageNow As GTASAFullGarage
    Dim bGarage(255) As Byte 'all 4 cars in 256 bytes
    Select Case Index
        Case 0 'Read from GTA SA
            If Not (isHasHandle And isHasPlayer) Then Exit Sub
            'go thru all garages and read from gta:
            For iGarageCtr = iJohnson To iHashbury
                'if garage is not locked,
                If cParking(iGarageCtr).Locked = vbUnchecked Then
                    'read from garage:
                    ReadProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 0&
                    'assign to ocx:
                    cParking(iGarageCtr).SetValuesFromOnlineGarageByteArray bGarage
                End If
            Next iGarageCtr
        Case 1 'Write to GTA SA
            If Not (isHasHandle And isHasPlayer) Then Exit Sub
            'go thru all garages and write to gta:
            For iGarageCtr = iJohnson To iHashbury
                'if user has changed carID's, so that we need to repark cars:
                If cParking(iGarageCtr).isReparkNeeded Then
                    'we have to recalculate parking coordinates of the cars, and repark them with the selected
                    'options from ocx:
                    'read from garage to pre-fill the parking information:
                    ReadProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 0&
                    'read updated values from ocx:
                    cParking(iGarageCtr).UpdateValuesOfGarageStructByteArray bGarage
                    'also copy the user selection byte array to a readable format:
                    CopyMemory tGarageNow, bGarage(0), Len(tGarageNow)
                    'first, check how many cars we have:
                    'for all 4 slots:
                    iCarCount = Abs(CInt(tGarageNow.ParkingSlots(0).intCarCode <> 0) + CInt(tGarageNow.ParkingSlots(1).intCarCode <> 0) + CInt(tGarageNow.ParkingSlots(2).intCarCode <> 0) + CInt(tGarageNow.ParkingSlots(3).intCarCode <> 0))
                    'check the number of bikes within parked car count:
                    iNrOfBikes = 0
                    For iCarCtr = 0 To iCarCount - 1
                        If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then iNrOfBikes = iNrOfBikes + 1
                    Next iCarCtr
                    Select Case iCarCount
                        Case 0 'no cars should be parked. car id's will be set to 0
                        'clean
                            tGarageNow.ParkingSlots(0).intCarCode = 0
                            tGarageNow.ParkingSlots(1).intCarCode = 0
                            tGarageNow.ParkingSlots(2).intCarCode = 0
                            tGarageNow.ParkingSlots(3).intCarCode = 0
                        Case 1 '1 car will be parked with the relevant information (from Parking Slot 0)
                        'clean
                            'the difference is with garage sizes and car sizes:
                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 2
                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(0).intCarCode).isLong, 3, 2))
                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(0), iGarageCtr, sngWidthOffset, sngDepthOffset
                            'normalization is:
                            'tGarageNow.ParkingSlots(0).sngXcoord = GTASAGarageDim(iGarageCtr).sngXpos + (((sngWidthOffset ^ 2) + (sngDepthOffset ^ 2)) ^ 0.5) * Cos(((Atn(sngDepthOffset / sngWidthOffset) * 180 / mathPI) + GTASAGarageDim(iGarageCtr).sngAbsDegrees) * mathPI / 180)
                            'tGarageNow.ParkingSlots(0).sngYcoord = GTASAGarageDim(iGarageCtr).sngYpos + (((sngWidthOffset ^ 2) + (sngDepthOffset ^ 2)) ^ 0.5) * Sin(((Atn(sngDepthOffset / sngWidthOffset) * 180 / mathPI) + GTASAGarageDim(iGarageCtr).sngAbsDegrees) * mathPI / 180)
                            'tGarageNow.ParkingSlots(0).sngZcoord = GTASAGarageDim(iGarageCtr).sngZpos + (ParkedCars(tGarageNow.ParkingSlots(0).intCarCode).sngCarHeight * 1 / 3)
                            tGarageNow.ParkingSlots(0).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                            tGarageNow.ParkingSlots(1).intCarCode = 0
                            tGarageNow.ParkingSlots(2).intCarCode = 0
                            tGarageNow.ParkingSlots(3).intCarCode = 0
                        Case 2 '2 cars will be parked
                            If iNrOfBikes = 1 Then
                            'clean
                                'special case. if garage is too small, park bike at front, if not, near the car:
                                If Abs(GTASAGarageDim(iGarageCtr).sngWidth) < 4.5 Then
                                    'garage is too small.
                                    For iCarCtr = 0 To 1
                                        If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 2 'front
                                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / 8
                                            tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookLeft
                                        Else
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 4 'back
                                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 2, 1.6))
                                            tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                        End If
                                        'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                        NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                    Next iCarCtr
                                Else
                                    'one of them is bike. Park car at right 1/4, and bike at very right 6/7 both looking front
                                    For iCarCtr = 0 To 1
                                        If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * 6 / 7
                                        Else
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 4
                                        End If
                                        sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                        'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                        NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                        tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                    Next iCarCtr
                                End If
                            Else 'otherwise, just park as usual (if they do not fit, user will later learn to park)
                            'clean
                                'cars/bikes are at 0 and 1
                                For iCarCtr = 0 To 1
                                    sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + (iCarCtr * 2)) / 4 '1/4 : 3/4
                                    sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                    'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                    NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                    tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                Next iCarCtr
                            End If
                            tGarageNow.ParkingSlots(2).intCarCode = 0
                            tGarageNow.ParkingSlots(3).intCarCode = 0
                        Case 3 '3 cars ...
                            'now it gets a bit tricky:
                            'let user park at will, but they will be parked as:
                            'wide garages: normal placement, use 1/6 for bike, 3/8 for cars
                            'deep garages:
                            '              one car 3/7 and two bikes 1/7:1/7 with different X offsets:
                            '              two cars 1/4:3/4 back, one bike 1/2 front
                            '              three cars: 1/4:3/4 back 1/2 front (user wanted this)
                            If GTASAGarageDim(iGarageCtr).isWide Then
                            'clean
                                'normal operation, cars/bikes are at 0 to 2
                                For iCarCtr = 0 To 2
                                    sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + iCarCtr) / 4 '1/4 : 2/4 : 3/4
                                    sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                    'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                    NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                    tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                Next iCarCtr
                            Else
                                Select Case iNrOfBikes
                                    Case 0 'all three cars, parked in deep garage!!
                                    'clean
                                        For iCarCtr = 0 To 2
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + iCarCtr) / 4 '1/4 : 2/4 : 3/4
                                            '0 and 2 back, 1 front:
                                            sngDepthDivider = CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 2, 1.6))
                                            If iCarCtr = 1 Then sngDepthDivider = 4 'front
                                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / sngDepthDivider
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                            tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                        Next iCarCtr
                                    Case 1 'two cars and a bike parked in deep garage
                                    'clean
                                        'two cars at back, one bike at very front looking left:
                                        iParkedCount = 0
                                        For iCarCtr = 0 To 2
                                            If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 2 'middle because at the front
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / 8  'at very front
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookLeft
                                            Else
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + (iParkedCount * 2)) / 4 '1/4 : 3/4
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 2, 1.6))
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                                iParkedCount = iParkedCount + 1
                                            End If
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                        Next iCarCtr
                                    Case 2 'one car and two bikes
                                    'clean
                                        'one car at the left, three bikes on the right 1/4 2/4 3/4 looking front left
                                        iParkedBikeCount = 0
                                        For iCarCtr = 0 To 2
                                            If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * 5 / 6 'both bikes are on the right side
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength * CSng(1 + iParkedBikeCount) / 3 'depth offsets of bikes are 1/3 and 2/3
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFrontLeft
                                                iParkedBikeCount = iParkedBikeCount + 1
                                            Else
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 4 'car at 1/4
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                            End If
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                        Next iCarCtr
                                    Case 3 'all three are bikes
                                    'clean
                                        For iCarCtr = 0 To 2
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 2 'park them all in the middle
                                            'bikes are at 1/4 and 2/4 and 3/4 depth:
                                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength * CSng(iCarCtr + 1) / 4 'with 1/4 : 2/4 : 3/4 depth offsets
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                            tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFrontLeft
                                         Next iCarCtr
                                End Select
                            End If
                            tGarageNow.ParkingSlots(3).intCarCode = 0
                        Case 4 '4 cars ...
                            'wide garages, normal placement, 1/5, 2/5, 3/5, 4/5
                            'deep garages: one car 3/7 and three bikes at 1/7 with 1/4:2/4:3/4 Y offsets
                            '              two cars 1/4:3/4 back, two bikes 1/4:3/4 front
                            '              three/four cars 1/4:3/4 front and back
                            If GTASAGarageDim(iGarageCtr).isWide Then
                            'clean
                                'normal operation, cars/bikes are at 0 to 3
                                For iCarCtr = 0 To 3
                                    sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + iCarCtr) / 5 '1/5 : 2/5 : 3/5 : 4/5
                                    sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                    'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                    NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                    tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                Next iCarCtr
                            Else
                                Select Case iNrOfBikes
                                    Case 0, 1, 4 '0,4: all cars/bikes, parked in deep garage!! / 1:three cars and a bike parked in deep garage
                                    'clean
                                        For iCarCtr = 0 To 3
                                            '1 and 2 left, 3 and 4 at right:
                                            sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * IIf(iCarCtr < 2, 0.25, 0.75) '1/4 and 3/4
                                            '0 and 2 front, 1 and 3 back:
                                            sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength * IIf(iCarCtr = 0 Or iCarCtr = 2, 0.25, 0.75) '1/4 and 3/4
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                            tGarageNow.ParkingSlots(iCarCtr).lngAngle = IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike, GTASAGarageDim(iGarageCtr).lngLookFrontLeft, GTASAGarageDim(iGarageCtr).lngLookFront)
                                        Next iCarCtr
                                    Case 2 'two cars and two bikes
                                    'clean
                                        'two cars back, two bikes front, looking left
                                        iParkedBikeCount = 0
                                        iParkedCount = 0
                                        For iCarCtr = 0 To 3
                                            If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + (iParkedBikeCount * 2)) / 4 '1/4 : 3/4
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / 8  'bikes are at front
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookLeft
                                                iParkedBikeCount = iParkedBikeCount + 1
                                            Else
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * CSng(1 + (iParkedCount * 2)) / 4 '1/4 : 3/4
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 2, 1.6)) 'long is more front than short car
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                                iParkedCount = iParkedCount + 1
                                            End If
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                        Next iCarCtr
                                    Case 3 'one car and three bikes
                                    'clean
                                        'one car at the left, three bikes on the right 1/4 2/4 3/4 looking front left
                                        iParkedBikeCount = 0
                                        For iCarCtr = 0 To 3
                                            If ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isBike Then
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth * 5 / 6 'all three bikes are on the right side
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFrontLeft
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength * CSng(1 + iParkedBikeCount) / 4
                                                iParkedBikeCount = iParkedBikeCount + 1
                                            Else
                                                sngWidthOffset = GTASAGarageDim(iGarageCtr).sngWidth / 4 'car at 1/4
                                                sngDepthOffset = GTASAGarageDim(iGarageCtr).sngLength / CSng(IIf(ParkedCars(tGarageNow.ParkingSlots(iCarCtr).intCarCode).isLong, 3, 2))
                                                tGarageNow.ParkingSlots(iCarCtr).lngAngle = GTASAGarageDim(iGarageCtr).lngLookFront
                                            End If
                                            'normalize X and Y offsets, and add to garage X and Y coordinates to find new coordinates.
                                            NormalizeParkingSlotCarPlacement tGarageNow.ParkingSlots(iCarCtr), iGarageCtr, sngWidthOffset, sngDepthOffset
                                        Next iCarCtr
                                End Select
                            End If
                    End Select
                    WriteProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, tGarageNow, 256&, 256&
                    cParking(iGarageCtr).isDirty = False
                    cParking(iGarageCtr).isReparkNeeded = False
                ElseIf cParking(iGarageCtr).isDirty Then
                    'if user has changed anything else:
                    'read from garage to pre-fill the parking information:
                    ReadProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 0&
                    'read updated values from ocx:
                    cParking(iGarageCtr).UpdateValuesOfGarageStructByteArray bGarage
                    'write back to GTA SA:
                    WriteProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 256&
                    cParking(iGarageCtr).isDirty = False
                    cParking(iGarageCtr).isReparkNeeded = False
                End If
            Next iGarageCtr
        Case 2 'Read From INI
            'reads all 68 parking slots (0 to 67) and assigns to the ocx:
            For iGarageCtr = 0 To 67
                strBuffer = Space(255)
                GetPrivateProfileString "CarTracking", "Garage" & iGarageCtr, "0,1,1,1,1,1,0,0,0,FF,FF080000,FF0004,FE9D06,FFFFFFFF,FFFFFFFF,FFFFFFFF,FFFFFFFF,FFFFFFFF,FFFFFFFF,FFFFFFFF", strBuffer, 255, strIniFileName
                strBuffer = TrimChr0(strBuffer)
                cParking(iGarageCtr \ 4).SetIniVals (iGarageCtr Mod 4), strBuffer
            Next iGarageCtr
        Case 3 'Write to INI
            'reads all 68 parking slots (0 to 67) from ocx's and assigns back to ini:
            For iGarageCtr = 0 To 67
                strBuffer = cParking(iGarageCtr \ 4).GetIniVals(iGarageCtr Mod 4)
                WritePrivateProfileString "CarTracking", "Garage" & iGarageCtr, strBuffer, strIniFileName
            Next iGarageCtr
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdGarages_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

'--------------------------------------------------------------------------------------------------------------------
'                                   GTA SA Cheats
'--------------------------------------------------------------------------------------------------------------------

Private Sub cmdCheats_Click(Index As Integer)
On Error GoTo errcmdCheats_Click
    Dim oNode As Node
    Select Case Index
        Case 0 'Apply
            txtCheatString.Text = Trim(txtCheatString.Text)
            If tvCheats.SelectedItem Is Nothing Then
                MsgBox "Please select a cheat to apply changes", vbInformation
            ElseIf tvCheats.SelectedItem.Tag = "folder" Then
                MsgBox "Please select a cheat to apply changes", vbInformation
            ElseIf Len(txtCheatString.Text) = 0 Then
                MsgBox "Please insert a cheat string to apply changes", vbInformation
            Else
                GTASACheats.GetItemByUID(tvCheats.SelectedItem.Tag).sCheatString = txtCheatString.Text
                isDirty(0) = True
            End If
        Case 1 'insert as new cheat
            txtCheatString.Text = Trim(txtCheatString.Text)
            If tvCheats.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to add this cheat", vbInformation
            ElseIf tvCheats.SelectedItem.Tag <> "folder" Then
                MsgBox "Please select a folder to add this cheat", vbInformation
            ElseIf Len(txtCheatString.Text) = 0 Then
                MsgBox "Please insert a cheat string to add", vbInformation
            Else
                Set GTASANewCheat = New cCheats
                With GTASANewCheat
                    .sUID = CreateGUID
                    .sFolder = tvCheats.SelectedItem.FullPath
                    .sCheatString = txtCheatString.Text
                    .sDescription = "New Cheat: " & txtCheatString.Text & " (please edit this description)"
                End With
                GTASACheats.AddCheatClass GTASANewCheat
                Set oNode = tvCheats.Nodes.Add(tvCheats.SelectedItem.Key, tvwChild, tvCheats.SelectedItem.Key & "\" & GTASANewCheat.sUID & CLng(Rnd * 10000), GTASANewCheat.sDescription, 4)
                oNode.Tag = GTASANewCheat.sUID
                tvCheats.SelectedItem.Sorted = True
                tvCheats.SelectedItem = oNode
                oNode.EnsureVisible
                tvCheats.SetFocus
                tvCheats.StartLabelEdit
                isDirty(0) = True
            End If
        Case 2 'Delete selected
            If tvCheats.SelectedItem Is Nothing Then
                MsgBox "Please select a folder or a cheat to delete", vbInformation
            ElseIf tvCheats.SelectedItem.Parent Is Nothing Then
                MsgBox "You cannot delete the root folder", vbInformation
            Else
                Set oNode = tvCheats.SelectedItem.Parent
                If tvCheats.SelectedItem.Tag = "folder" Then
                    'move all siblings to one level up, and delete this folder:
                    Do Until tvCheats.SelectedItem.Children = 0
                        Set oNode = tvCheats.SelectedItem.Child
                        Set oNode.Parent = tvCheats.SelectedItem.Parent
                    Loop
                    tvCheats.SelectedItem.Parent.Sorted = True
                    tvCheats.Nodes.Remove tvCheats.SelectedItem.Key
                Else
                    'remove this cheat from treeview, and from collection
                    GTASACheats.RemoveByUID tvCheats.SelectedItem.Tag
                    tvCheats.Nodes.Remove tvCheats.SelectedItem.Key
                End If
                tvCheats.SelectedItem = oNode
                oNode.EnsureVisible
                isDirty(0) = True
            End If
        Case 3 'Insert New Folder
            If tvCheats.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            ElseIf tvCheats.SelectedItem.Tag <> "folder" Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            Else
                Set oNode = tvCheats.Nodes.Add(tvCheats.SelectedItem.Key, tvwChild, tvCheats.SelectedItem.Key & "\NewFolder" & CreateGUID, "New Folder: " & Format(Now, "yyyy-mm-dd hh:nn:ss") & " (please edit this)", 1)
                oNode.Tag = "folder"
                oNode.Sorted = True
                tvCheats.SelectedItem.Sorted = True
                tvCheats.SelectedItem = oNode
                oNode.EnsureVisible
                tvCheats.SetFocus
                tvCheats.StartLabelEdit
                isDirty(0) = True
            End If
        Case 4 'Read
            ParseCheats
            FillInTreeviews True, False, False
        Case 5 'Write
            DumpChangesToCFG True, False, False
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdCheats_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub tvCheats_NodeClick(ByVal Node As MSComctlLib.Node)
On Error Resume Next
    If Node.Tag = "folder" Then
        txtCheatString.Text = ""
    Else
        txtCheatString.Text = GTASACheats.GetItemByUID(Node.Tag).sCheatString
    End If
    tvCheats.SetFocus
End Sub

Private Sub tvCheats_AfterLabelEdit(Cancel As Integer, NewString As String)
On Error Resume Next
    NewString = Left$(Trim(Replace(Replace(Replace(Replace(NewString, "\", ""), "|", ""), vbCr, ""), vbLf, "")), 128)
    If NewString = "" Then NewString = "Cheat " & Format(Now, "yyyy-mm-ss hh:nn:ss")
    If Not tvCheats.SelectedItem Is Nothing Then
        If tvCheats.SelectedItem.Tag <> "folder" Then GTASACheats.GetItemByUID(tvCheats.SelectedItem.Tag).sDescription = NewString
        If Not tvCheats.SelectedItem.Parent Is Nothing Then tvCheats.SelectedItem.Parent.Sorted = True
    End If
    isDirty(0) = True
End Sub

Private Sub tvCheats_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Not tvCheats.HitTest(x, y) Is Nothing Then
        If TypeOf tvCheats.HitTest(x, y) Is Node Then
            tvCheats.SelectedItem = tvCheats.HitTest(x, y)
            If tvCheats.SelectedItem.Tag = "folder" Then
                txtCheatString.Text = ""
            Else
                txtCheatString.Text = GTASACheats.GetItemByUID(tvCheats.SelectedItem.Tag).sCheatString
            End If
            If Button = vbRightButton Then Me.PopupMenu mCheatContext
        End If
    End If
End Sub

'--------------------------------------------------------------------------------------------------------------------
'                                   GTA SA Locations
'--------------------------------------------------------------------------------------------------------------------

Private Sub tvLocations_AfterLabelEdit(Cancel As Integer, NewString As String)
On Error Resume Next
    NewString = Left$(Trim(Replace(Replace(Replace(Replace(NewString, "\", ""), "|", ""), vbCr, ""), vbLf, "")), 128)
    If NewString = "" Then NewString = "Location " & Format(Now, "yyyy-mm-ss hh:nn:ss")
    If Not tvLocations.SelectedItem Is Nothing Then
        If tvLocations.SelectedItem.Tag <> "folder" Then GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).sDescription = NewString
        If Not tvLocations.SelectedItem.Parent Is Nothing Then tvLocations.SelectedItem.Parent.Sorted = True
    End If
    FillInCommandCombo False, False, True
    FillInTreeviews False, False, True
    DoEvents
    isDirty(1) = True
    tvLocations.SetFocus
End Sub

Private Sub tvLocations_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Not tvLocations.HitTest(x, y) Is Nothing Then
        If TypeOf tvLocations.HitTest(x, y) Is Node Then
            Set tvLocations.SelectedItem = tvLocations.HitTest(x, y)
            If Button = vbRightButton Then Me.PopupMenu mLocationContext
        End If
    End If
End Sub

Private Sub tvLocations_NodeClick(ByVal Node As MSComctlLib.Node)
On Error Resume Next
    Set tvLocations.SelectedItem = Node
    If tvLocations.SelectedItem.Tag <> "folder" Then
        With GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag)
            If .iLocationCount > 2 Then
                txtCoords(0).Text = .GetLocation(0)
                txtCoords(1).Text = .GetLocation(1)
                txtCoords(2).Text = .GetLocation(2)
                txtCoords(3).Text = .GetLocation(3)
                tvLocations.SetFocus
            End If
        End With
    End If
End Sub

Private Sub cmdLocations_Click(Index As Integer)
On Error GoTo errcmdLocations_Click
    Dim oNode As Node
    Select Case Index
        Case 0 'read from gta
            ReadLocData
            cPlayerLoc.Left = ((sZoomLevel * (MakeSingle(txtCoords(0).Text) + 3000&)) / sngPixToGTA) - (iLocBoxSize / 2)
            cPlayerLoc.Top = ((sZoomLevel * (3000& - MakeSingle(txtCoords(1).Text))) / sngPixToGTA) - (iLocBoxSize / 2)
            cPlayerLoc.Visible = True
        Case 1 'apply changes
            If tvLocations.SelectedItem Is Nothing Then
                MsgBox "Please select a Location to apply changes", vbInformation
            ElseIf tvLocations.SelectedItem.Tag = "folder" Then
                MsgBox "Please select a Location to apply changes", vbInformation
            ElseIf Len(txtCoords(0).Text) = 0 Or txtCoords(0).Text = "#ERROR#" Then
                MsgBox "Please read location from GTA San Andreas to apply changes", vbInformation
            Else
                GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).sLocData = txtCoords(0).Text & ";" & txtCoords(1).Text & ";" & txtCoords(2).Text & ";" & txtCoords(3).Text
                FillInCommandCombo False, False, True
                FillInTreeviews False, False, True
                DoEvents
                isDirty(1) = True
            End If
        Case 2 'insert as new location
            If tvLocations.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to add this Location", vbInformation
            ElseIf Len(txtCoords(0).Text) = 0 Or txtCoords(0).Text = "#ERROR#" Then
                MsgBox "Please read location from GTA San Andreas to add", vbInformation
            Else
                If tvLocations.SelectedItem.Tag <> "folder" Then tvLocations.SelectedItem = tvLocations.SelectedItem.Parent
                Set GTASANewWarpLoc = New cWarpLocs
                With GTASANewWarpLoc
                    .sUID = CreateGUID
                    .sFolder = tvCheats.SelectedItem.FullPath
                    .sDescription = "New Location (please edit this description)"
                    .sLocData = txtCoords(0).Text & ";" & txtCoords(1).Text & ";" & txtCoords(2).Text & ";" & txtCoords(3).Text
                End With
                GTASAWarpLocs.AddWarpLocsClass GTASANewWarpLoc
                Set oNode = tvLocations.Nodes.Add(tvLocations.SelectedItem.Key, tvwChild, tvLocations.SelectedItem.Key & "\" & GTASANewWarpLoc.sUID & CLng(Rnd * 10000), GTASANewWarpLoc.sDescription, 3)
                oNode.Tag = GTASANewWarpLoc.sUID
                oNode.Sorted = True
                tvLocations.SelectedItem.Sorted = True
                Set tvLocations.SelectedItem = oNode
                oNode.EnsureVisible
                tvLocations.SetFocus
                tvLocations.StartLabelEdit
                isDirty(1) = True
                FillInCommandCombo False, False, True
            End If
        Case 3 'teleport to this location
            If Len(txtCoords(0).Text) = 0 Or txtCoords(0).Text = "#ERROR#" Then
                MsgBox "Please select a valid Location to teleport", vbInformation
            Else
                PasteWarpLoc 0, txtCoords(0).Text & ";" & txtCoords(1).Text & ";" & txtCoords(2).Text & ";" & txtCoords(3).Text
            End If
        Case 4 'insert folder
            If tvLocations.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            ElseIf tvLocations.SelectedItem.Tag <> "folder" Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            Else
                Set oNode = tvLocations.Nodes.Add(tvLocations.SelectedItem.Key, tvwChild, tvLocations.SelectedItem.Key & "\NewFolder" & CreateGUID, "New Folder: " & Format(Now, "yyyy-mm-dd hh:nn:ss") & " (please edit this)", 1)
                oNode.Tag = "folder"
                oNode.Sorted = True
                tvLocations.SelectedItem.Sorted = True
                Set tvLocations.SelectedItem = oNode
                oNode.EnsureVisible
                tvLocations.SetFocus
                tvLocations.StartLabelEdit
                isDirty(1) = True
            End If
            
        Case 5 'delete selected
            If tvLocations.SelectedItem Is Nothing Then
                MsgBox "Please select a folder or a location to delete", vbInformation
            ElseIf tvLocations.SelectedItem.Parent Is Nothing Then
                MsgBox "You cannot delete the root folder", vbInformation
            Else
                Set oNode = tvLocations.SelectedItem.Parent
                If tvLocations.SelectedItem.Tag = "folder" Then
                    'move all siblings to one level up, and delete this folder:
                    Do Until tvLocations.SelectedItem.Children = 0
                        Set oNode = tvLocations.SelectedItem.Child
                        Set oNode.Parent = tvLocations.SelectedItem.Parent
                    Loop
                    tvLocations.SelectedItem.Parent.Sorted = True
                    tvLocations.Nodes.Remove tvLocations.SelectedItem.Key
                Else
                    'remove this cheat from treeview, and from collection
                    GTASAWarpLocs.RemoveByUID tvLocations.SelectedItem.Tag
                    tvLocations.Nodes.Remove tvLocations.SelectedItem.Key
                End If
                Set tvLocations.SelectedItem = oNode
                oNode.EnsureVisible
                FillInCommandCombo False, False, True
                FillInTreeviews False, False, True
                DoEvents
                isDirty(1) = True
            End If
        Case 6 'read
            ParseLocations
            FillInTreeviews False, True, False
            FillInCommandCombo False, False, True
        Case 7 'write
            DumpChangesToCFG False, True, False
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdLocations_Click:
    MsgBox Err.Description, vbCritical
    Err.Clear
End Sub

'--------------------------------------------------------------------------------------------------------------------
'                                   GTA SA Shortcuts
'--------------------------------------------------------------------------------------------------------------------
Private Sub tvShotcuts_AfterLabelEdit(Cancel As Integer, NewString As String)
On Error Resume Next
    NewString = Left$(Trim(Replace(Replace(Replace(Replace(NewString, "\", ""), "|", ""), vbCr, ""), vbLf, "")), 128)
    If NewString = "" Then NewString = "Shortcut " & Format(Now, "yyyy-mm-ss hh:nn:ss")
    If Not tvShotcuts.SelectedItem Is Nothing Then
        If tvShotcuts.SelectedItem.Tag <> "folder" Then GTASAShortcuts.GetItemByUID(tvShotcuts.SelectedItem.Tag).sDescription = NewString
        If Not tvShotcuts.SelectedItem.Parent Is Nothing Then tvShotcuts.SelectedItem.Parent.Sorted = True
    End If
    isDirty(2) = True
End Sub

Private Sub tvShotcuts_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Not tvShotcuts.HitTest(x, y) Is Nothing Then
        If TypeOf tvShotcuts.HitTest(x, y) Is Node Then
            tvShotcuts.SelectedItem = tvShotcuts.HitTest(x, y)
            If tvShotcuts.SelectedItem.Tag <> "folder" Then
                FillInShortcutDetails
                tvShotcuts.SetFocus
            End If
            If Button = vbRightButton Then Me.PopupMenu mShortcutContext
        End If
    End If
End Sub

Private Sub tvShotcuts_NodeClick(ByVal Node As MSComctlLib.Node)
On Error Resume Next
    If Node.Tag <> "folder" Then
        FillInShortcutDetails
        tvShotcuts.SetFocus
    End If
End Sub

Private Sub cmdShortcuts_Click(Index As Integer) 'CheckThis
On Error GoTo errcmdShortcuts_Click
    Dim cNewShortcut As cShortcuts
    Dim oNode As Node
    If (Index = 0) Or (Index = 1) Then 'prepare to apply/insert as new
        Set cNewShortcut = New cShortcuts
        If cboCommands(0).ListIndex > -1 Then 'internal commands
            cNewShortcut.sCommand = cboCommands(0).ListIndex
            cNewShortcut.iDataPage = GTASAConsoleCommands(cboCommands(0).ListIndex).DataPage
            cNewShortcut.iCategory = 0
        ElseIf cboCommands(1).ListIndex > -1 Then 'cheats
            cNewShortcut.sCommand = sCheatUID(cboCommands(1).ListIndex)
            cNewShortcut.iDataPage = 17
            cNewShortcut.iCategory = 1
        ElseIf cboCommands(2).ListIndex > -1 Then 'locations
            cNewShortcut.sCommand = sLocUID(cboCommands(2).ListIndex)
            cNewShortcut.iDataPage = 17
            cNewShortcut.iCategory = 2
        Else 'anomaly!!
            cNewShortcut.sCommand = "0"
            cNewShortcut.iDataPage = 17
            cNewShortcut.iCategory = 0
        End If
        cNewShortcut.iExtKeyCode = Format$(17 * chkShortcut(0).Value + 18 * chkShortcut(1).Value)
        cNewShortcut.sComboText = cboShortcut.Text
        Select Case sstCommandData.Tab
            Case 0, 1, 2, 8, 9, 13, 14, 15, 19 'Armor/Health/EngineHealth/CarWeight/CarDynamics/GameSpeed/Criminals Killed/TurnCar
                cNewShortcut.sData = Format$(scrCommandData(sstCommandData.Tab).Value)
                cNewShortcut.sDataDesc = lblCommandData(sstCommandData.Tab).Caption
            Case 3 'Weapon Combo
                If cboCommandWeapon.ListIndex < 0 Then
                    cboCommandWeapon.ListIndex = 0
                    txtCommandWeaponAmmo.Text = "0"
                End If
                cNewShortcut.sData = Format$(cboCommandWeapon.ItemData(cboCommandWeapon.ListIndex)) & ";" & Trim$(txtCommandWeaponAmmo.Text)
                cNewShortcut.sDataDesc = "(" & cboCommandWeapon.list(cboCommandWeapon.ListIndex) & ", Ammo: " & Trim$(txtCommandWeaponAmmo.Text) & ")"
            Case 5 'EP/DP/BP/FP
                cNewShortcut.sData = Format$(chkCarSpecsCommand(0).Value) & ";" & Format$(chkCarSpecsCommand(1).Value) & ";" & Format$(chkCarSpecsCommand(2).Value) & ";" & Format$(chkCarSpecsCommand(3).Value)
                cNewShortcut.sDataDesc = "(" & IIf(chkCarSpecsCommand(0).Value = 1, "EP/", "     /") & IIf(chkCarSpecsCommand(1).Value = 1, "DP/", "     /") & IIf(chkCarSpecsCommand(2).Value = 1, "BP/", "     /") & IIf(chkCarSpecsCommand(3).Value = 1, "FP)", "     )")
            Case 6 'open/locked
                cNewShortcut.sData = Format$(Abs(CInt(optCarDoorsCommand(0).Value)))
                cNewShortcut.sDataDesc = IIf(optCarDoorsCommand(0).Value, "(open)", "(locked)")
            Case 7 'weather selection
                If cboCommandWeather.ListIndex < 0 Then cboCommandWeather.ListIndex = 0
                cNewShortcut.sData = Format$(cboCommandWeather.ListIndex)
                cNewShortcut.sDataDesc = cboCommandWeather.list(cboCommandWeather.ListIndex)
            Case 10 'Colors
                cNewShortcut.sData = picColorCommand(0).Tag & ";" & Format$(chkCommandColorLock(0).Value) & ";" & picColorCommand(1).Tag & ";" & Format$(chkCommandColorLock(1).Value)
                cNewShortcut.sDataDesc = "(Major:" & GTASAColors(CInt(picColorCommand(0).Tag)).strDescription & IIf(chkCommandColorLock(0).Value = 1, " (Locked) / Minor: ", " / Minor:") & GTASAColors(CInt(picColorCommand(1).Tag)).strDescription & IIf(chkCommandColorLock(1).Value = 1, " (Locked))", ")")
            Case 11 'Directions
                cNewShortcut.sData = Format$(cboCommandDirection.ListIndex) & ";" & Format$(scrCommandData(11).Value)
                cNewShortcut.sDataDesc = "(" & cboCommandDirection.list(cboCommandDirection.ListIndex) & " - " & Format$(scrCommandData(11).Value / 10) & "% for Kickstart)"
            Case 12 'CarList
                cNewShortcut.sData = Format$(SpawnCarMatrix(cboCommandParkedCar.ListIndex))
                cNewShortcut.sDataDesc = "(" & cboCommandParkedCar.list(cboCommandParkedCar.ListIndex) & ")"
            Case 16 'ON/OFF
                cNewShortcut.sData = Format$(Abs(CInt(optCommandOnOff(0).Value)))
                cNewShortcut.sDataDesc = IIf(optCommandOnOff(0).Value, "(ON)", "(OFF)")
            Case 17 'NONE
                cNewShortcut.sData = "0"
                cNewShortcut.sDataDesc = "(N/A)"
            Case 18 'Markup Locations:
                cNewShortcut.sData = cboCommandMarkupLocs.ListIndex + 1
                cNewShortcut.sDataDesc = "(Loc: " & cNewShortcut.sData & ")"
        End Select
        cNewShortcut.sDataDesc = Replace(cNewShortcut.sDataDesc, ",", ".")
        Select Case cboShortcut.Text
            Case "(None)":     cNewShortcut.iKeyCode = 0
            Case "SHIFT ":     cNewShortcut.iKeyCode = 16
            Case "INSERT":     cNewShortcut.iKeyCode = 45
            Case "DELETE":     cNewShortcut.iKeyCode = 46
            Case "HOME ":      cNewShortcut.iKeyCode = 36
            Case "END":        cNewShortcut.iKeyCode = 35
            Case "PgUP":       cNewShortcut.iKeyCode = 33
            Case "PgDOWN":     cNewShortcut.iKeyCode = 34
            Case "NUM COMMA":  cNewShortcut.iKeyCode = 110
            Case "ENTER":      cNewShortcut.iKeyCode = 13
            Case "NUM +":      cNewShortcut.iKeyCode = 107
            Case "NUM - ":     cNewShortcut.iKeyCode = 109
            Case "NUM *":      cNewShortcut.iKeyCode = 106
            Case "NUM /":      cNewShortcut.iKeyCode = 111
            Case "NUM 0", "NUM 1", "NUM 2", "NUM 3", "NUM 4", "NUM 5", "NUM 6", "NUM 7", "NUM 8", "NUM 9" '96->105
                 cNewShortcut.iKeyCode = Asc(Right$(cboShortcut.Text, 1)) + 48
            Case "F2", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" '113, 115->123
                 cNewShortcut.iKeyCode = CInt(Mid$(cboShortcut.Text, 2)) + 111
            Case Else 'Ascii
                If Len(cboShortcut.Text) = 0 Then
                    cNewShortcut.iKeyCode = 0
                Else
                    cNewShortcut.iKeyCode = Asc(cboShortcut.Text)
                End If
                'Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" '48-57 (Ascii)
                'Case "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" '65-90 (Ascii)
        End Select
        If cNewShortcut.iExtKeyCode = 17 Then
            cNewShortcut.sDescription = "CTRL+" & cNewShortcut.sComboText
        ElseIf cNewShortcut.iExtKeyCode = 18 Then
            cNewShortcut.sDescription = "ALT+" & cNewShortcut.sComboText
        Else
            cNewShortcut.sDescription = cNewShortcut.sComboText
        End If
        Select Case cNewShortcut.iCategory
            Case 0 'Internal Commands
                cNewShortcut.sDescription = cNewShortcut.sDescription & " " & GTASAConsoleCommands(cNewShortcut.sCommand).Description & " " & IIf(cNewShortcut.sDataDesc <> "(N/A)", cNewShortcut.sDataDesc, "")
            Case 1 'Cheat Strings
                cNewShortcut.sDescription = cNewShortcut.sDescription & " " & GTASACheats.GetItemByUID(cNewShortcut.sCommand).sDescription
            Case 2 'Warp Locations
                cNewShortcut.sDescription = cNewShortcut.sDescription & " " & "Teleport to: " & GTASAWarpLocs.GetItemByUID(cNewShortcut.sCommand).sDescription
        End Select
    End If
    Select Case Index
        Case 0 'apply
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "Please select a shortcut to apply changes", vbInformation
            ElseIf tvShotcuts.SelectedItem.Tag = "folder" Then
                MsgBox "Please select a shortcut to apply changes", vbInformation
            Else
                'Apply changes:
                With GTASAShortcuts.GetItemByUID(tvShotcuts.SelectedItem.Tag)
                    .sComboText = cNewShortcut.sComboText
                    .sCommand = cNewShortcut.sCommand
                    .iCategory = cNewShortcut.iCategory
                    .iDataPage = cNewShortcut.iDataPage
                    .sDescription = cNewShortcut.sDescription
                    .sData = cNewShortcut.sData
                    .sDataDesc = cNewShortcut.sDataDesc
                    .iExtKeyCode = cNewShortcut.iExtKeyCode
                    .isActive = .isActive And (cNewShortcut.sComboText <> "(None)")
                    .iKeyCode = cNewShortcut.iKeyCode
                End With
                tvShotcuts.SelectedItem.Text = cNewShortcut.sDescription
                isDirty(2) = True
            End If
        Case 1 'insert as new
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to insert this new shortcut", vbInformation
            Else
                If tvShotcuts.SelectedItem.Tag <> "folder" Then Set tvShotcuts.SelectedItem = tvShotcuts.SelectedItem.Parent
                'insert as new
                cNewShortcut.sUID = CreateGUID
                cNewShortcut.isActive = False
                cNewShortcut.sFolder = tvShotcuts.SelectedItem.FullPath
                GTASAShortcuts.AddShortcutClass cNewShortcut
                Set oNode = tvShotcuts.Nodes.Add(tvShotcuts.SelectedItem, tvwChild, tvShotcuts.SelectedItem.Key & "\NewShortcut" & cNewShortcut.sUID & CLng(Rnd * 10000), cNewShortcut.sDescription, 5)
                oNode.Tag = cNewShortcut.sUID
                isDirty(2) = True
            End If
        Case 2 'delete selected
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "Please select a folder or a shortcut to delete", vbInformation
            ElseIf tvShotcuts.SelectedItem.Parent Is Nothing Then
                MsgBox "You cannot delete the root folder", vbInformation
            Else
                Set oNode = tvShotcuts.SelectedItem.Parent
                If tvShotcuts.SelectedItem.Tag = "folder" Then
                    'move all siblings to one level up, and delete this folder:
                    Do Until tvShotcuts.SelectedItem.Children = 0
                        Set oNode = tvShotcuts.SelectedItem.Child
                        Set oNode.Parent = tvShotcuts.SelectedItem.Parent
                    Loop
                    tvShotcuts.SelectedItem.Parent.Sorted = True
                    tvShotcuts.Nodes.Remove tvShotcuts.SelectedItem.Key
                Else
                    'remove this cheat from treeview, and from collection
                    GTASAShortcuts.RemoveByUID tvShotcuts.SelectedItem.Tag
                    tvShotcuts.Nodes.Remove tvShotcuts.SelectedItem.Key
                End If
                Set tvShotcuts.SelectedItem = oNode
                oNode.EnsureVisible
                isDirty(2) = True
            End If
        Case 3 'insert folder
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            ElseIf tvShotcuts.SelectedItem.Tag <> "folder" Then
                MsgBox "Please select a folder to insert the new folder as subfolder.", vbInformation
            Else
                Set oNode = tvShotcuts.Nodes.Add(tvShotcuts.SelectedItem.Key, tvwChild, tvShotcuts.SelectedItem.Key & "\NewFolder" & CreateGUID, "New Folder: " & Format(Now, "yyyy-mm-dd hh:nn:ss") & " (please edit this)", 1)
                oNode.Tag = "folder"
                tvShotcuts.SelectedItem.Sorted = True
                Set tvShotcuts.SelectedItem = oNode
                oNode.EnsureVisible
                tvShotcuts.SetFocus
                tvShotcuts.StartLabelEdit
                isDirty(2) = True
            End If
        Case 4 'read
            ParseShortcuts
            FillInTreeviews False, False, True
            DoEvents
        Case 5 'write
            DumpChangesToCFG False, False, True
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errcmdShortcuts_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub cboCommands_Click(Index As Integer)
On Error GoTo errcboCommands_Click
    If isInternalClick Then Exit Sub
    isInternalClick = True
    cboCommands((Index + 1) Mod 3).ListIndex = -1
    cboCommands((Index + 1) Mod 3).Text = ""
    cboCommands((Index + 2) Mod 3).ListIndex = -1
    cboCommands((Index + 2) Mod 3).Text = ""
    isInternalClick = False
    Select Case Index
        Case 0 'Commands 'console commands indexes are hard coded
            sstCommandData.Tab = GTASAConsoleCommands(cboCommands(Index).ListIndex).DataPage
        Case 1 'Cheats
            sstCommandData.Tab = 17
        Case 2 'WarpLocs
            sstCommandData.Tab = 17
    End Select

Exit Sub
errcboCommands_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
    isInternalClick = False
End Sub

Private Sub optCarDoorsCommand_Click(Index As Integer)
On Error Resume Next 'this is only for selecting for in-game-commands
    If isInternalClick Then Exit Sub
    isInternalClick = True
    optCarDoorsCommand((Index + 1) Mod 2).Value = Not optCarDoorsCommand(Index).Value
    isInternalClick = False
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub optCommandOnOff_Click(Index As Integer)
On Error Resume Next
    If isInternalClick Then Exit Sub
    isInternalClick = True
    optCommandOnOff((Index + 1) Mod 2).Value = Not optCommandOnOff(Index).Value
    isInternalClick = False
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub scrCommandData_Change(Index As Integer)
On Error GoTo errscrCommandData_Change
    If isInternalClick Then Exit Sub
    Select Case Index
        Case 0, 1, 2, 15: lblCommandData(Index).Caption = "(" & scrCommandData(Index).Value & ")" 'Armor/Health/Wanted/Criminals Killed
        Case 8:  lblCommandData(Index).Caption = "(" & scrCommandData(Index).Value / 10 & "%)" 'Engine Health, Flight Assistance etc.
        Case 13: lblCommandData(Index).Caption = "(" & scrCommandData(Index).Value / 10 & "%)" 'CarDynamics
        Case 9:  lblCommandData(Index).Caption = Format$(scrCommandData(Index).Value / 10, "0.0") & " Tons"  'CarWeight
        Case 11: lblCommandData(Index).Caption = "(" & scrCommandData(Index).Value / 10 & "%)" 'KickStart:
        Case 19: lblCommandData(Index).Caption = "(" & scrCommandData(Index).Value & " Degrees)" 'Degrees
        Case 14 'Clock Speed
            If scrCommandData(Index).Value = -92 Then
                lblCommandData(Index).Caption = "(0 %)"
            ElseIf scrCommandData(Index).Value = -91 Then
                lblCommandData(Index).Caption = "(6 %)"
            ElseIf scrCommandData(Index).Value < 0 Then
                lblCommandData(Index).Caption = "(" & (100 + scrCommandData(Index).Value) & " %)"
            Else
                lblCommandData(Index).Caption = "(" & (100 + (scrCommandData(Index).Value * 10)) & " %)"
            End If
    End Select
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errscrCommandData_Change:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkShortcut_Click(Index As Integer)
On Error GoTo errchkShortcut_Click
    If isInternalClick Then Exit Sub
    If cboShortcut.ListIndex = 0 Then
        isInternalClick = True
        chkShortcut(0).Value = 0
        chkShortcut(1).Value = 0
        isInternalClick = False
    End If
    If chkShortcut(Index).Value = 1 And chkShortcut(Index).Value = chkShortcut((Index + 1) Mod 2).Value Then
        'CTRL + ALT not available
        isInternalClick = True
        chkShortcut((Index + 1) Mod 2).Value = 0
        isInternalClick = False
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errchkShortcut_Click:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
    isInternalClick = False
End Sub

Private Sub picColorCommand_DblClick(Index As Integer)
On Error Resume Next
    intLastPickedColor = CInt(picColorCommand(Index).Tag)
    Load frmPickColor
    frmPickColor.iPickColor = intLastPickedColor
    frmPickColor.Show vbModal, Me
    intLastPickedColor = frmPickColor.iPickColor
    Unload frmPickColor
    picColorCommand(Index).Tag = intLastPickedColor
    picColorCommand(Index).BackColor = GTASAColors(intLastPickedColor).lngRGB
    Err.Clear
End Sub

Private Sub cboShortcut_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    If cboShortcut.ListIndex = 0 Then
        isInternalClick = True
        chkShortcut(0).Value = 0
        chkShortcut(1).Value = 0
        isInternalClick = False
    End If
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub chkCommandColorLock_Click(Index As Integer)
On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub chkCarSpecsCommand_Click(Index As Integer)
On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
End Sub

Private Sub cboGTAVersion_Click()
On Error Resume Next
    Dim iCtr As Long
    Dim sHEX As String
    If Not isInternalClick Then
        MsgBox "Please wait a few seconds. Control Center will now resyncronize."
        tmrConsole.Enabled = False
        tmrFindCar.Enabled = False
        tmrHook.Enabled = False
    End If
    Select Case cboGTAVersion.ListIndex
        Case 0 'V1.0
            GTASABaseAdr.PlayerAdr = &HB6F5F0       'player addres start will be read from this location
            GTASABaseAdr.PlayerAdr2 = &HB7CD98      'player addres start, as confirmation will be read from this location
            GTASABaseAdr.CurrCarAdr = &HB6F3B8      'current car addres start will be read from this location
            GTASABaseAdr.Msg1Adr = &HBAA7A0     'location to get the in-game message shown
            GTASABaseAdr.MoneyAdr = &HB7CE50
            GTASABaseAdr.FatStatAdr = &HB793D4
            GTASABaseAdr.StaminaStatAdr = &HB793D8
            GTASABaseAdr.MuscleStatAdr = &HB793DC
            GTASABaseAdr.MaxHealthStatAdr = &HB793E0
            GTASABaseAdr.EnergyStatAdr = &HB790B4
            GTASABaseAdr.WeaponProfStatAdr(0) = &HB79494
            GTASABaseAdr.WeaponProfStatAdr(1) = &HB79498
            GTASABaseAdr.WeaponProfStatAdr(2) = &HB7949C
            GTASABaseAdr.WeaponProfStatAdr(3) = &HB794A0
            GTASABaseAdr.WeaponProfStatAdr(4) = &HB794A4
            GTASABaseAdr.WeaponProfStatAdr(5) = &HB794A8
            GTASABaseAdr.WeaponProfStatAdr(6) = &HB794AC
            GTASABaseAdr.WeaponProfStatAdr(7) = &HB794B0
            GTASABaseAdr.WeaponProfStatAdr(8) = &HB794B4
            GTASABaseAdr.WeaponProfStatAdr(9) = &HB794B8
            GTASABaseAdr.HotCoffeeAdr = &HA4AC6C
            GTASABaseAdr.VehicleProfAdr(0) = &HB790A0 'car
            GTASABaseAdr.VehicleProfAdr(1) = &HB791B4 'bike
            GTASABaseAdr.VehicleProfAdr(2) = &HB791B8 'cycle
            GTASABaseAdr.VehicleProfAdr(3) = &HB7919C 'flying
            GTASABaseAdr.LungCapacityAdr = &HB791A4
            GTASABaseAdr.GamblingStatAdr = &HB794C4
            'Denise/Michelle/Helena/Katie/Barbara/Millie
            GTASABaseAdr.GFStatAdr(0) = &HB79210
            GTASABaseAdr.GFStatAdr(1) = &HB79214
            GTASABaseAdr.GFStatAdr(2) = &HB79218
            GTASABaseAdr.GFStatAdr(3) = &HB79220
            GTASABaseAdr.GFStatAdr(4) = &HB7921C
            GTASABaseAdr.GFStatAdr(5) = &HB79224
            GTASABaseAdr.GFStatAdr(0) = &HA49EFC   'Denise Progress
            GTASABaseAdr.GFStatAdr(1) = &HA49F00   'Michelle Progress
            GTASABaseAdr.GFStatAdr(2) = &HA49F04   'Helena Progress
            GTASABaseAdr.GFStatAdr(3) = &HA49F0C   'Katie Progress
            GTASABaseAdr.GFStatAdr(4) = &HA49F08   'Barbara Progress
            GTASABaseAdr.GFStatAdr(5) = &HA49F10   'Millie Progress
            GTASABaseAdr.CheatCountAdr = &HB79044
            GTASABaseAdr.CheatStatAdr = &H96918C
            GTASABaseAdr.OpenedIslandsAdr = &HB790F4
            'Never Wanted=2'Never Get Hungry=3'Infinite Health=4'Infinite Oxygen=5'Infinite Ammo=6'Tank Mode=7
            'Mega Punch=8'Mega Jump=9'Max Respect=10'Max Sex Appeal=11'Fast Cars=12'Cheap Cars=13'Infinite Run=14'Fireproof=15
            GTASABaseAdr.cNeverWantedAdr = &H969171
            GTASABaseAdr.cCheatsAdr(0) = &H969171
            GTASABaseAdr.cNeverGetHungryAdr = &H969174
            GTASABaseAdr.cCheatsAdr(1) = &H969174
            GTASABaseAdr.cInfHealthAdr = &H96916D
            GTASABaseAdr.cCheatsAdr(2) = &H96916D
            GTASABaseAdr.cInfOxygenAdr = &H96916E
            GTASABaseAdr.cCheatsAdr(3) = &H96916E
            GTASABaseAdr.cInfAmmoAdr = &H969178
            GTASABaseAdr.cCheatsAdr(4) = &H969178
            GTASABaseAdr.cTankModeAdr = &H969164
            GTASABaseAdr.cCheatsAdr(5) = &H969164
            GTASABaseAdr.cMegaPunchAdr = &H969173
            GTASABaseAdr.cCheatsAdr(6) = &H969173
            GTASABaseAdr.cMegaJumpAdr = &H96916C
            GTASABaseAdr.cCheatsAdr(7) = &H96916C
            GTASABaseAdr.cMaxRespectAdr = &H96917F
            GTASABaseAdr.cCheatsAdr(8) = &H96917F
            GTASABaseAdr.cMaxSexAppealAdr = &H969180
            GTASABaseAdr.cCheatsAdr(9) = &H969180
            GTASABaseAdr.cFastCarsAdr = &H96915F
            GTASABaseAdr.cCheatsAdr(10) = &H96915F
            GTASABaseAdr.cCheapCarsAdr = &H96915E
            GTASABaseAdr.cCheatsAdr(11) = &H96915E
            GTASABaseAdr.cInfRunAdr = &HB7CEE4
            GTASABaseAdr.cCheatsAdr(12) = &HB7CEE4
            GTASABaseAdr.cFireproofAdr = &HB7CEE6
            GTASABaseAdr.cCheatsAdr(13) = &HB7CEE6
            GTASABaseAdr.cCheatsAdr(14) = &H96914C          'Perfect Handling
            GTASABaseAdr.cCheatsAdr(15) = &H96917A          'Decreased Traffic
            GTASABaseAdr.cCheatsAdr(16) = &H969161          'Huge Bunny Hop
            GTASABaseAdr.cCheatsAdr(17) = &H969165          'All cars have Nitro
            GTASABaseAdr.cCheatsAdr(18) = &H969153          'Boats can Fly
            GTASABaseAdr.cCheatsAdr(19) = &H969160          'Cars can Fly
            GTASABaseAdr.DaysInGameAdr = &HB79038
            GTASABaseAdr.CurrHourAdr = &HB70153
            GTASABaseAdr.CurrMinuteAdr = &HB70152
            GTASABaseAdr.CurrWeekdayAdr = &HB7014E '1 to 7
            GTASABaseAdr.GameSpeedMsAdr = &HB7015C 'Defines how many ms = 1 second... default 1000, set to 1 for a headache
            GTASABaseAdr.GameSpeedPctAdr = &HB7CB64 'defines the speed of the game, 1 = 100%, float
            GTASABaseAdr.WeatherLockAdr = &HC81318
            GTASABaseAdr.WeatherToGoAdr = &HC8131C
            GTASABaseAdr.WeatherCurrentAdr = &HC81320
            'car spawn and weapon initialisation code injection:
            GTASABaseAdr.CodeInjectJumpAdr = &H53BF9C      'to inject jump code
            GTASABaseAdr.CodeInjectCodeAdr = &H856CE0      'to inject asm functions
            GTASABaseAdr.CarSpawnAdr = &H1301000           'Car Spawn Injected Code reads this Adr.
            For iCtr = 0 To 11
                GTASABaseAdr.WeaponSpawnAdr(iCtr) = &H1301004 + CLng(iCtr * 4) 'Weapon Spawn Injected Code for slot iCtr+1 reads this Adr.
            Next iCtr
            'the following is for code injection
            isInjected = False
            'original gta_sa code:
            sHEX = "A048CBB700"
            For iCtr = 0 To 4
                bNotInjectedJump(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'jump code:
            sHEX = "E93FAD3100"
            For iCtr = 0 To 4
                bInjectedJump(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'function code:
            sHEX = "5650A10010300183F800587418FF3500103001E8B833BEFF83C404C7050010300100000000"
            sHEX = sHEX & "50A10410300183F80058741A6A02FF3504103001E8C21ABBFF83C408C7050410300100000000"
            sHEX = sHEX & "50A10810300183F80058741A6A02FF3508103001E89C1ABBFF83C408C7050810300100000000"
            sHEX = sHEX & "50A10C10300183F80058741A6A02FF350C103001E8761ABBFF83C408C7050C10300100000000"
            sHEX = sHEX & "50A11010300183F80058741A6A02FF3510103001E8501ABBFF83C408C7051010300100000000"
            sHEX = sHEX & "50A11410300183F80058741A6A02FF3514103001E82A1ABBFF83C408C7051410300100000000"
            sHEX = sHEX & "50A11810300183F80058741A6A02FF3518103001E8041ABBFF83C408C7051810300100000000"
            sHEX = sHEX & "50A11C10300183F80058741A6A02FF351C103001E8DE19BBFF83C408C7051C10300100000000"
            sHEX = sHEX & "50A12010300183F80058741A6A02FF3520103001E8B819BBFF83C408C7052010300100000000"
            sHEX = sHEX & "50A12410300183F80058741A6A02FF3524103001E89219BBFF83C408C7052410300100000000"
            sHEX = sHEX & "50A12810300183F80058741A6A02FF3528103001E86C19BBFF83C408C7052810300100000000"
            sHEX = sHEX & "50A12C10300183F80058741A6A02FF352C103001E84619BBFF83C408C7052C10300100000000"
            sHEX = sHEX & "50A13010300183F80058741A6A02FF3530103001E82019BBFF83C408C7053010300100000000"
            sHEX = sHEX & "5EA048CBB700E9C950CEFF"
            For iCtr = 0 To 503
                bInjectedCode(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'the following is for Code Injection for One Hit Kill:
            GTASABaseAdr.CodeInjectJump_OneHitKillAdr = &H4B331F
            GTASABaseAdr.CodeInjectCode_OneHitKillAdr = &H856F68
            'original gta_sa code:
            sHEX = "899640050000"
            For iCtr = 0 To 5 '6 bytes in total
                bNotInjectedJump_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'jump code:
            sHEX = "E94A3C3A0090"
            For iCtr = 0 To 5
                bInjectedJump_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'function code:
            sHEX = "A827480E000060A1686F85008D8E400500003BC8750961899640050000EB0B61C7864005000000000000E98EC3C5FF"
            For iCtr = 0 To 46 '47 bytes in total
                bInjectedCode_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'the following is for NOOP'ing the mission timers:
            GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr = &H44CB54
            GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr = &H44CBAB
            iOrg_FreezeTimerDown = &HCD2B  'this is original code (sub         ecx,ebp)
            iOrg_FreezeTimerUp = &HCD03    'this is original code (add         ecx,ebp)
            'Static Mem. Locations for garages:
            GTASAGarageAddresses(iJohnson).lngXCoordAdr = &H96ABD8   'Johnson House Car 1
            GTASAGarageAddresses(iJohnson).lngDoorStateAdr = &H96C82D 'Johnson Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iElCorona).lngXCoordAdr = &H96B5D8  'El Corona Car 1
            GTASAGarageAddresses(iElCorona).lngDoorStateAdr = &H96C4CD  'El Corona Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iSantaBeach).lngXCoordAdr = &H96ACD8  'Santa Maria Beach Car 1
            GTASAGarageAddresses(iSantaBeach).lngDoorStateAdr = &H96CB8D  'Santa Maria Beach Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iMulHolland).lngXCoordAdr = &H96B6D8  'MulHolland Car 1
            GTASAGarageAddresses(iMulHolland).lngDoorStateAdr = &H96CC65  'MulHolland Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iPalomino).lngXCoordAdr = &H96B3D8  'Palomino Creek Car 1
            GTASAGarageAddresses(iPalomino).lngDoorStateAdr = &H96E915  'Palomino Creek Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iPrickle).lngXCoordAdr = &H96B1D8  'Prickle Pine Car 1
            GTASAGarageAddresses(iPrickle).lngDoorStateAdr = &H96E0A5  'Prickle Prine Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iWhitewood).lngXCoordAdr = &H96B2D8  'Whitewood Estates Car 1
            GTASAGarageAddresses(iWhitewood).lngDoorStateAdr = &H96E17D  'Whitewood Estates Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iRedsands).lngXCoordAdr = &H96B4D8  'Redsands West Car 1
            GTASAGarageAddresses(iRedsands).lngDoorStateAdr = &H96DFCD  'Redsands West Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iRockshore).lngXCoordAdr = &H96ADD8  'Rockshore West Car 1
            GTASAGarageAddresses(iRockshore).lngDoorStateAdr = &H96DD45  'Rockshore West Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iDillimore).lngXCoordAdr = &H96B0D8  'Dillimore Car 1
            GTASAGarageAddresses(iDillimore).lngDoorStateAdr = &H96E9ED  'Dillimore Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iFortCarson).lngXCoordAdr = &H96AED8  'Fort Carson Car 1
            GTASAGarageAddresses(iFortCarson).lngDoorStateAdr = &H96E405  'Fort Carson Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iVerdant).lngXCoordAdr = &H96AFD8  'Verdant Meadows Car 1
            GTASAGarageAddresses(iVerdant).lngDoorStateAdr = &H96E4DD  'Verdant Meadows Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iVerdantAir).lngXCoordAdr = &H96BED8  'Derdant Meadows Airport Car 1
            GTASAGarageAddresses(iVerdantAir).lngDoorStateAdr = &H96E68D  'Airport Garage Door, Derdant Meadows
            GTASAGarageAddresses(iCalton).lngXCoordAdr = &H96BAD8  'Calton Heights Car 1
            GTASAGarageAddresses(iCalton).lngDoorStateAdr = &H96D5AD  'Calton Heights Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iParadiso).lngXCoordAdr = &H96BBD8  'Paradiso Car 1
            GTASAGarageAddresses(iParadiso).lngDoorStateAdr = &H96D835  'Paradiso Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iDoherty).lngXCoordAdr = &H96BCD8  'Doherty Car 1
            GTASAGarageAddresses(iDoherty).lngDoorStateAdr = &H96D24D  'Doherty Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iHashbury).lngXCoordAdr = &H96BDD8  'Hashbury Car 1
            GTASAGarageAddresses(iHashbury).lngDoorStateAdr = &H96CEED  'Hashbury Garage Door State (0:closed 1:open 2:closing 3:opening)

        Case 1 'v1.1
            GTASABaseAdr.PlayerAdr = &HB6F5F0 + &H2680       'player addres start will be read from this location
            GTASABaseAdr.PlayerAdr2 = &HB7CD98 + &H2680      'player addres start, as confirmation will be read from this location
            GTASABaseAdr.CurrCarAdr = &HB6F3B8 + &H2680      'current car addres start will be read from this location
            GTASABaseAdr.Msg1Adr = &HBAA7A0 + &H2680     'location to get the in-game message shown
            GTASABaseAdr.MoneyAdr = &HB7CE50 + &H2680
            GTASABaseAdr.FatStatAdr = &HB793D4 + &H2680
            GTASABaseAdr.StaminaStatAdr = &HB793D8 + &H2680
            GTASABaseAdr.MuscleStatAdr = &HB793DC + &H2680
            GTASABaseAdr.MaxHealthStatAdr = &HB793E0 + &H2680
            GTASABaseAdr.EnergyStatAdr = &HB790B4 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(0) = &HB79494 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(1) = &HB79498 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(2) = &HB7949C + &H2680
            GTASABaseAdr.WeaponProfStatAdr(3) = &HB794A0 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(4) = &HB794A4 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(5) = &HB794A8 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(6) = &HB794AC + &H2680
            GTASABaseAdr.WeaponProfStatAdr(7) = &HB794B0 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(8) = &HB794B4 + &H2680
            GTASABaseAdr.WeaponProfStatAdr(9) = &HB794B8 + &H2680
            GTASABaseAdr.HotCoffeeAdr = &HA4AC6C + &H2680
            GTASABaseAdr.VehicleProfAdr(0) = &HB790A0 + &H2680 'car
            GTASABaseAdr.VehicleProfAdr(1) = &HB791B4 + &H2680 'bike
            GTASABaseAdr.VehicleProfAdr(2) = &HB791B8 + &H2680 'cycle
            GTASABaseAdr.VehicleProfAdr(3) = &HB7919C + &H2680 'flying
            GTASABaseAdr.LungCapacityAdr = &HB791A4 + &H2680
            GTASABaseAdr.GamblingStatAdr = &HB794C4 + &H2680
            'Denise/Michelle/Helena/Katie/Barbara/Millie
            GTASABaseAdr.GFStatAdr(0) = &HB79210 + &H2680
            GTASABaseAdr.GFStatAdr(1) = &HB79214 + &H2680
            GTASABaseAdr.GFStatAdr(2) = &HB79218 + &H2680
            GTASABaseAdr.GFStatAdr(3) = &HB79220 + &H2680
            GTASABaseAdr.GFStatAdr(4) = &HB7921C + &H2680
            GTASABaseAdr.GFStatAdr(5) = &HB79224 + &H2680
            GTASABaseAdr.GFStatAdr(0) = &HA49EFC + &H2680   'Denise Progress
            GTASABaseAdr.GFStatAdr(1) = &HA49F00 + &H2680   'Michelle Progress
            GTASABaseAdr.GFStatAdr(2) = &HA49F04 + &H2680   'Helena Progress
            GTASABaseAdr.GFStatAdr(3) = &HA49F0C + &H2680   'Katie Progress
            GTASABaseAdr.GFStatAdr(4) = &HA49F08 + &H2680   'Barbara Progress
            GTASABaseAdr.GFStatAdr(5) = &HA49F10 + &H2680   'Millie Progress
            GTASABaseAdr.CheatCountAdr = &HB79044 + &H2680
            GTASABaseAdr.CheatStatAdr = &H96918C + &H2680
            GTASABaseAdr.OpenedIslandsAdr = &HB790F4 + &H2680
            'Never Wanted=2'Never Get Hungry=3'Infinite Health=4'Infinite Oxygen=5'Infinite Ammo=6'Tank Mode=7
            'Mega Punch=8'Mega Jump=9'Max Respect=10'Max Sex Appeal=11'Fast Cars=12'Cheap Cars=13'Infinite Run=14'Fireproof=15
            GTASABaseAdr.cNeverWantedAdr = &H969171 + &H2680
            GTASABaseAdr.cCheatsAdr(0) = &H969171 + &H2680
            GTASABaseAdr.cNeverGetHungryAdr = &H969174 + &H2680
            GTASABaseAdr.cCheatsAdr(1) = &H969174 + &H2680
            GTASABaseAdr.cInfHealthAdr = &H96916D + &H2680
            GTASABaseAdr.cCheatsAdr(2) = &H96916D + &H2680
            GTASABaseAdr.cInfOxygenAdr = &H96916E + &H2680
            GTASABaseAdr.cCheatsAdr(3) = &H96916E + &H2680
            GTASABaseAdr.cInfAmmoAdr = &H969178 + &H2680
            GTASABaseAdr.cCheatsAdr(4) = &H969178 + &H2680
            GTASABaseAdr.cTankModeAdr = &H969164 + &H2680
            GTASABaseAdr.cCheatsAdr(5) = &H969164 + &H2680
            GTASABaseAdr.cMegaPunchAdr = &H969173 + &H2680
            GTASABaseAdr.cCheatsAdr(6) = &H969173 + &H2680
            GTASABaseAdr.cMegaJumpAdr = &H96916C + &H2680
            GTASABaseAdr.cCheatsAdr(7) = &H96916C + &H2680
            GTASABaseAdr.cMaxRespectAdr = &H96917F + &H2680
            GTASABaseAdr.cCheatsAdr(8) = &H96917F + &H2680
            GTASABaseAdr.cMaxSexAppealAdr = &H969180 + &H2680
            GTASABaseAdr.cCheatsAdr(9) = &H969180 + &H2680
            GTASABaseAdr.cFastCarsAdr = &H96915F + &H2680
            GTASABaseAdr.cCheatsAdr(10) = &H96915F + &H2680
            GTASABaseAdr.cCheapCarsAdr = &H96915E + &H2680
            GTASABaseAdr.cCheatsAdr(11) = &H96915E + &H2680
            GTASABaseAdr.cInfRunAdr = &HB7CEE4 + &H2680
            GTASABaseAdr.cCheatsAdr(12) = &HB7CEE4 + &H2680
            GTASABaseAdr.cFireproofAdr = &HB7CEE6 + &H2680
            GTASABaseAdr.cCheatsAdr(13) = &HB7CEE6 + &H2680
            GTASABaseAdr.cCheatsAdr(14) = &H96914C + &H2680          'Perfect Handling
            GTASABaseAdr.cCheatsAdr(15) = &H96917A + &H2680          'Decreased Traffic
            GTASABaseAdr.cCheatsAdr(16) = &H969161 + &H2680          'Huge Bunny Hop
            GTASABaseAdr.cCheatsAdr(17) = &H969165 + &H2680          'All cars have Nitro
            GTASABaseAdr.cCheatsAdr(18) = &H969153 + &H2680          'Boats can Fly
            GTASABaseAdr.cCheatsAdr(19) = &H969160 + &H2680          'Cars can Fly
            GTASABaseAdr.DaysInGameAdr = &HB79038 + &H2680
            GTASABaseAdr.CurrHourAdr = &HB70153 + &H2680
            GTASABaseAdr.CurrMinuteAdr = &HB70152 + &H2680
            GTASABaseAdr.CurrWeekdayAdr = &HB7014E + &H2680 '1 to 7
            GTASABaseAdr.GameSpeedMsAdr = &HB7015C + &H2680 'Defines how many ms = 1 second... default 1000, set to 1 for a headache
            GTASABaseAdr.GameSpeedPctAdr = &HB7CB64 + &H2680 'defines the speed of the game, 1 = 100%, float
            GTASABaseAdr.WeatherLockAdr = &HC81318 + &H2680
            GTASABaseAdr.WeatherToGoAdr = &HC8131C + &H2680
            GTASABaseAdr.WeatherCurrentAdr = &HC81320 + &H2680
            'car spawn and weapon initialisation code injection:
            GTASABaseAdr.CodeInjectJumpAdr = &H53C3D6      'to inject jump code
            GTASABaseAdr.CodeInjectCodeAdr = &H857CE0      'to inject asm functions
            GTASABaseAdr.CarSpawnAdr = &H1301000           'Car Spawn Injected Code reads this Adr.
            For iCtr = 0 To 11
                GTASABaseAdr.WeaponSpawnAdr(iCtr) = &H1301004 + CLng(iCtr * 4) 'Weapon Spawn Injected Code for slot iCtr+1 reads this Adr.
            Next iCtr
            'the following is for code injection
            isInjected = False
            'original gta_sa code:
            sHEX = "A0C8F1B700"
            For iCtr = 0 To 4
                bNotInjectedJump(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'jump code:
            sHEX = "E905B93100"
            For iCtr = 0 To 4
                bInjectedJump(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'function code:
            sHEX = "5650A10010300183F800587418FF3500103001E83824BEFF83C404C7050010300100000000"
            sHEX = sHEX & "50A10410300183F80058741A6A02FF3504103001E8F20ABBFF83C408C7050410300100000000"
            sHEX = sHEX & "50A10810300183F80058741A6A02FF3508103001E8CC0ABBFF83C408C7050810300100000000"
            sHEX = sHEX & "50A10C10300183F80058741A6A02FF350C103001E8A60ABBFF83C408C7050C10300100000000"
            sHEX = sHEX & "50A11010300183F80058741A6A02FF3510103001E8800ABBFF83C408C7051010300100000000"
            sHEX = sHEX & "50A11410300183F80058741A6A02FF3514103001E85A0ABBFF83C408C7051410300100000000"
            sHEX = sHEX & "50A11810300183F80058741A6A02FF3518103001E8340ABBFF83C408C7051810300100000000"
            sHEX = sHEX & "50A11C10300183F80058741A6A02FF351C103001E80E0ABBFF83C408C7051C10300100000000"
            sHEX = sHEX & "50A12010300183F80058741A6A02FF3520103001E8E809BBFF83C408C7052010300100000000"
            sHEX = sHEX & "50A12410300183F80058741A6A02FF3524103001E8C209BBFF83C408C7052410300100000000"
            sHEX = sHEX & "50A12810300183F80058741A6A02FF3528103001E89C09BBFF83C408C7052810300100000000"
            sHEX = sHEX & "50A12C10300183F80058741A6A02FF352C103001E87609BBFF83C408C7052C10300100000000"
            sHEX = sHEX & "50A13010300183F80058741A6A02FF3530103001E85009BBFF83C408C7053010300100000000"
            sHEX = sHEX & "5EA0C8F1B700E90345CEFF"
            For iCtr = 0 To 503
                bInjectedCode(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'the following is for Code Injection for One Hit Kill:
            GTASABaseAdr.CodeInjectJump_OneHitKillAdr = &H4B339F
            GTASABaseAdr.CodeInjectCode_OneHitKillAdr = &H857F68
            'original gta_sa code:
            sHEX = "899640050000"
            For iCtr = 0 To 5
                bNotInjectedJump_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'jump code:
            sHEX = "E9CA4B3A0090"
            For iCtr = 0 To 5
                bInjectedJump_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'function code:
            sHEX = "A827480E000060A1687F85008D8E400500003BC8750961899640050000EB0B61C7864005000000000000E90EB4C5FF"
            For iCtr = 0 To 46 '47 bytes in total
                bInjectedCode_OneHitKill(iCtr) = CByte("&H" & Mid(sHEX, (iCtr * 2) + 1, 2))
            Next iCtr
            'the following is for NOOP'ing the mission timers:
            GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr = &H44CBD6
            GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr = &H44CC2B
            iOrg_FreezeTimerDown = &HCD2B  'this is original code (sub         ecx,ebp)
            iOrg_FreezeTimerUp = &HCD03    'this is original code (add         ecx,ebp)
            'Static Mem. Locations for garages:
            GTASAGarageAddresses(iJohnson).lngXCoordAdr = &H96ABD8 + &H2680   'Johnson House Car 1
            GTASAGarageAddresses(iJohnson).lngDoorStateAdr = &H96C82D + &H2680 'Johnson Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iElCorona).lngXCoordAdr = &H96B5D8 + &H2680  'El Corona Car 1
            GTASAGarageAddresses(iElCorona).lngDoorStateAdr = &H96C4CD + &H2680  'El Corona Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iSantaBeach).lngXCoordAdr = &H96ACD8 + &H2680  'Santa Maria Beach Car 1
            GTASAGarageAddresses(iSantaBeach).lngDoorStateAdr = &H96CB8D + &H2680  'Santa Maria Beach Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iMulHolland).lngXCoordAdr = &H96B6D8 + &H2680  'MulHolland Car 1
            GTASAGarageAddresses(iMulHolland).lngDoorStateAdr = &H96CC65 + &H2680  'MulHolland Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iPalomino).lngXCoordAdr = &H96B3D8 + &H2680  'Palomino Creek Car 1
            GTASAGarageAddresses(iPalomino).lngDoorStateAdr = &H96E915 + &H2680  'Palomino Creek Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iPrickle).lngXCoordAdr = &H96B1D8 + &H2680  'Prickle Pine Car 1
            GTASAGarageAddresses(iPrickle).lngDoorStateAdr = &H96E0A5 + &H2680  'Prickle Prine Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iWhitewood).lngXCoordAdr = &H96B2D8 + &H2680  'Whitewood Estates Car 1
            GTASAGarageAddresses(iWhitewood).lngDoorStateAdr = &H96E17D + &H2680  'Whitewood Estates Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iRedsands).lngXCoordAdr = &H96B4D8 + &H2680  'Redsands West Car 1
            GTASAGarageAddresses(iRedsands).lngDoorStateAdr = &H96DFCD + &H2680  'Redsands West Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iRockshore).lngXCoordAdr = &H96ADD8 + &H2680  'Rockshore West Car 1
            GTASAGarageAddresses(iRockshore).lngDoorStateAdr = &H96DD45 + &H2680  'Rockshore West Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iDillimore).lngXCoordAdr = &H96B0D8 + &H2680  'Dillimore Car 1
            GTASAGarageAddresses(iDillimore).lngDoorStateAdr = &H96E9ED + &H2680  'Dillimore Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iFortCarson).lngXCoordAdr = &H96AED8 + &H2680  'Fort Carson Car 1
            GTASAGarageAddresses(iFortCarson).lngDoorStateAdr = &H96E405 + &H2680  'Fort Carson Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iVerdant).lngXCoordAdr = &H96AFD8 + &H2680  'Verdant Meadows Car 1
            GTASAGarageAddresses(iVerdant).lngDoorStateAdr = &H96E4DD + &H2680  'Verdant Meadows Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iVerdantAir).lngXCoordAdr = &H96BED8 + &H2680  'Derdant Meadows Airport Car 1
            GTASAGarageAddresses(iVerdantAir).lngDoorStateAdr = &H96E68D + &H2680  'Airport Garage Door, Derdant Meadows
            GTASAGarageAddresses(iCalton).lngXCoordAdr = &H96BAD8 + &H2680  'Calton Heights Car 1
            GTASAGarageAddresses(iCalton).lngDoorStateAdr = &H96D5AD + &H2680  'Calton Heights Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iParadiso).lngXCoordAdr = &H96BBD8 + &H2680  'Paradiso Car 1
            GTASAGarageAddresses(iParadiso).lngDoorStateAdr = &H96D835 + &H2680  'Paradiso Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iDoherty).lngXCoordAdr = &H96BCD8 + &H2680  'Doherty Car 1
            GTASAGarageAddresses(iDoherty).lngDoorStateAdr = &H96D24D + &H2680  'Doherty Garage Door State (0:closed 1:open 2:closing 3:opening)
            GTASAGarageAddresses(iHashbury).lngXCoordAdr = &H96BDD8 + &H2680  'Hashbury Car 1
            GTASAGarageAddresses(iHashbury).lngDoorStateAdr = &H96CEED + &H2680  'Hashbury Garage Door State (0:closed 1:open 2:closing 3:opening)

    End Select
    'Fill-in Garage Detail Adresses using Offsets:
    For iCtr = 0 To 16
        GTASAGarageAddresses(iCtr).lngYcoordAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 4
        GTASAGarageAddresses(iCtr).lngZcoordAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 8
        GTASAGarageAddresses(iCtr).lngSpecialsAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 14
        GTASAGarageAddresses(iCtr).lngCarCodeAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 16
        GTASAGarageAddresses(iCtr).lngMajorColorAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 47
        GTASAGarageAddresses(iCtr).lngMinorColorAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 48
        GTASAGarageAddresses(iCtr).lngAngleAdr = GTASAGarageAddresses(iCtr).lngXCoordAdr + 60
    Next iCtr
    If Not isInternalClick Then WritePrivateProfileString "Main", "GTASAVersion", cboGTAVersion.list(cboGTAVersion.ListIndex), strIniFileName
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then
        txtFocus.SetFocus: Err.Clear
        Call cmdMain_Click(0)
    End If
    
End Sub
'--------------------------------------------------------------------------------------------------------------------
'                                   General Settings
'--------------------------------------------------------------------------------------------------------------------
Private Sub scrIntervall_Change()
On Error GoTo errscrIntervall_Change
    If isInternalClick Then Exit Sub
    lblIntervall.Caption = "Keyboard Control Intervall: (" & scrIntervall.Value & " ms)."
    WritePrivateProfileString "Main", "Interval", Format$(scrIntervall.Value), strIniFileName
    tmrConsole.Interval = scrIntervall.Value
    On Error Resume Next
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
Exit Sub
errscrIntervall_Change:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub chkFeedback_Click()
On Error Resume Next
    If isInternalClick Then Exit Sub
    isHasFeedback = (chkFeedback.Value = 1)
    WritePrivateProfileString "Main", "Feedback", Format$(chkFeedback.Value), strIniFileName
    If Me.Visible Then
        If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus: Err.Clear
    End If
End Sub

Private Sub chkOrgSCM_Click()
On Error Resume Next
    Dim iGFCtr As Integer
    If isInternalClick Then Exit Sub
    If chkOrgSCM.Value = vbChecked Then
        If MsgBox("You hereby confirm that you are using the original SCM" & vbCrLf & _
                   "The console will write and change Memory Values within the SCM block," & vbCrLf & _
                   "for example for GF Progress." & vbCrLf & _
                   "If you are using a modded SCM, this will damage your game within GTA SA." & vbCrLf & vbCrLf & _
                   "Are you sure you want to continue?" & vbCrLf, vbQuestion + vbDefaultButton2 + vbYesNoCancel, _
                   "Are you sure you are using the original SCM?") = vbYes Then
            isOrgSCM = True
        Else
            isInternalClick = True
            isOrgSCM = False
            chkOrgSCM.Value = vbUnchecked
            isInternalClick = False
        End If
    Else
        If MsgBox("You hereby confirm that you are using a Modded SCM" & vbCrLf & _
                   "The console will NOT write and change Memory Values within the SCM block." & vbCrLf & _
                   "So some Console functions, for example for GF Progress will not be available." & vbCrLf & vbCrLf & _
                   "Are you sure you want to continue?" & vbCrLf, vbQuestion + vbDefaultButton2 + vbYesNoCancel, _
                   "Are you sure you are using a Modded SCM?") = vbYes Then
            isOrgSCM = False
        Else
            isInternalClick = True
            isOrgSCM = True
            chkOrgSCM.Value = vbChecked
            isInternalClick = False
        End If
    End If
    WritePrivateProfileString "Main", "OrgSCM", Format$(chkOrgSCM.Value), strIniFileName
    For iGFCtr = 0 To 5
        oGFStats(iGFCtr).Enabled = isOrgSCM
    Next iGFCtr
    If isGTASAiconic Then txtFocus.SetFocus: Err.Clear
End Sub

'--------------------------------------------------------------------------------------------------------------------
'                                     Timer Events
'--------------------------------------------------------------------------------------------------------------------

Private Sub tmrHook_Timer() ' 'Hook GTASA / Check Hook status (1000 ms)
On Error GoTo errtmrHook_Timer
    Static iStatCtr As Long
    Static sngWeaponProfTotal As Single
    Static lngVehicleProfTotal As Long
    Static intSpecShowBuffer As Integer
    'Hook GTASA
    'Find window handle:
    lngHWnd = FindWindow(vbNullString, "GTA: San Andreas")
    If (lngHWnd = 0) Then
        lngLastGTASAHwnd = 0
        isHasPlayer = False
        'not injected, check and set captions and availability:
        isInjected = False
        isInternInjectCheck = True
        If chkSpawnVehicle.Value <> vbUnchecked Then chkSpawnVehicle.Value = vbUnchecked
        If chkSpawnVehicle.Caption <> "Spawner Code-Injection Status: (unknown)" Then chkSpawnVehicle.Caption = "Spawner Code-Injection Status: (unknown)"
        If chkSpawnVehicle.Enabled Then chkSpawnVehicle.Enabled = False
        If cmdSpawnCar(0).Enabled Then cmdSpawnCar(0).Enabled = False
        isInternInjectCheck = False
        strCarType = ""
        tmrConsole.Enabled = False
        tmrFindCar.Enabled = False
        intWaitBeforeHook = 3
        intRefreshFormValues = 1
        isHasHandle = False
        isHasPlayer = False
        isGTASAiconic = True
        lngLastPid = -1
        If Me.Caption <> "GTASA Control Center" Then Me.Caption = "GTASA Control Center"
        If Not isMsgShown And (iMsgShowCtr > 0) Then
            iMsgShowCtr = iMsgShowCtr - 1
            WritePrivateProfileString "Main", "InfoMsg", Format$(iMsgShowCtr), strIniFileName
            isMsgShown = True
            MsgBox "GTA SA is not running." & vbCrLf & _
                   "Please start GTA SA, load/start a game," & vbCrLf & _
                   "and then start the console" & vbCrLf & _
                   "for proper syncronization!" & vbCrLf & _
                   "This Message will be shown " & iMsgShowCtr & " more times.", vbInformation
        End If
        Exit Sub
    ElseIf lngLastGTASAHwnd <> lngHWnd Then 'GTASA is just starting. Give some time:
        lngLastGTASAHwnd = lngHWnd
        isMsgShown = True
        intRefreshFormValues = 1
    End If
    'Get Thread Process ID:
    GetWindowThreadProcessId lngHWnd, lngPid
    If lngPid <> lngLastPid Then
        isGTASAiconic = True
        If lngPHandle <> 0 Then CloseHandle lngPHandle
        lngLastPid = lngPid
        'Open process:
        lngPHandle = OpenProcess(PROCESS_ALL_ACCESS, False, lngPid)
        If (lngPHandle = 0) Then
            If isHasHandle Then
                tmrConsole.Enabled = False
                tmrFindCar.Enabled = False
                If Me.Caption <> "GTASA Control Center" Then Me.Caption = "GTASA Control Center"
            End If
            isHasHandle = False
            intWaitBeforeHook = 5
            intRefreshFormValues = 1
            isHasPlayer = False
            Exit Sub
        Else
            isHasHandle = True
            tmrFindCar.Enabled = True
        End If
    End If
    
    'Set isGTASAiconic or not according to TOPMOST window:
    GetWindowPlacement lngHWnd, gtaSAWindow
    isGTASAiconic = (gtaSAWindow.showCmd = 2) '2:NotShowing(minimized) / 1:Showing
    'Player Information:
    lngHookBuffer = GetMemLong(GTASABaseAdr.PlayerAdr)
    If lngHookBuffer <> 0 Then
        'We have a player
        isHasPlayer = True
        If GTASAPlayerAddresse.lngObjectStart <> lngHookBuffer Then
            'We have a new player:
            GTASAPlayerAddresse.lngObjectStart = lngHookBuffer
            GTASAPlayerAddresse.lngPositionPtr = lngHookBuffer + 20
            GTASAPlayerAddresse.lngSpecialsAdr = lngHookBuffer + 66 'byte, bit coded for BPDPEPFP
            GTASAPlayerAddresse.lngPedSpeedAdr = lngHookBuffer + 68
            GTASAPlayerAddresse.lngHealthAdr = lngHookBuffer + 1344
            GTASAPlayerAddresse.lngMaxHealthAdr = lngHookBuffer + 1348
            GTASAPlayerAddresse.lngArmorAdr = lngHookBuffer + 1352
            GTASAPlayerAddresse.lngLastCarAdr = lngHookBuffer + 1420
            GTASAPlayerAddresse.lngBrassKnucklesAdr = lngHookBuffer + 1440
            For iStatCtr = 0 To 10
                GTASAPlayerAddresse.lngWeaponsAdr(iStatCtr) = lngHookBuffer + 1468 + (iStatCtr * 28)
            Next iStatCtr
            GTASAPlayerAddresse.lngDetonatorAdr = lngHookBuffer + 1776
            GTASAPlayerAddresse.lngWeaponSlotAdr = lngHookBuffer + 1816
            GTASAPlayerAddresse.lngWeaponIDAdr = lngHookBuffer + 1856
        End If
        'read the [new] position data:
        lngHookBuffer = GetMemLong(GTASAPlayerAddresse.lngPositionPtr)
        If lngHookBuffer <> 0 Then
            GTASAPlayerAddresse.lngPlayerPosAdr = lngHookBuffer
            GTASAPlayerAddresse.lngXposAdr = lngHookBuffer + 48
            GTASAPlayerAddresse.lngYposAdr = lngHookBuffer + 52
            GTASAPlayerAddresse.lngZposAdr = lngHookBuffer + 56
        End If
        If isAutoInject And Not isInjected Then
            If CheckIfInjectable Then
                'inject code:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCodeAdr, bInjectedCode(0), 504&, 504&
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJumpAdr, bInjectedJump(0), 5&, 5&
                chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
                cmdSpawnCar(0).Enabled = True
                isInjected = True
            End If
        End If
    Else
        'Either GTA is not running anymore, or no Game is running.
        isHasPlayer = False
        If Me.Caption <> "GTASA Control Center [Online - No Game in Progress]" Then Me.Caption = "GTASA Control Center [Online - No Game in Progress]"
        Exit Sub
    End If
    'Enable Console Timer:
    If isGTASAiconic Then
        tmrConsole.Enabled = False 'Don't listen to keystrokes if GTASA is minimized
    Else
        tmrConsole.Enabled = True 'Listen to keystrokes if GTASA is showing
    End If
    'Read Values from GTASA to refresh non-locked items:
    If Not isGTASAiconic Then
        intRefreshFormValues = 1
        'by Every timer event, check Car Leveling:
        If isFlightAssistance And tCurrCarAdr.isUsable Then
            'Stop Spin:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr, zeroSpin, 12&, 12&
            'Level Z Grad:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 8, 0&, 4&, 4&
            'Level Z Looking:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 24, 0&, 4&, 4&
            'Level X/Y/Z Relational Positioning
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 32, 0&, 4&, 4&
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 36, 0&, 4&, 4&
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 40, 1&, 4&, 4&
        End If
        'Refresh Garages (needed for proper reparking):
        CheckAndRefreshGarages
    Else
        'GTASA minimized, so refresh form values:
        'Set Internal Click OFF:
        If intGameTimeChangeCount > 0 Then intGameTimeChangeCount = 0
        If intRefreshFormValues < 0 Then Exit Sub 'do not refresh more than 3 times
        isInjected = CheckIfInjected
        isInternInjectCheck = True
        If isInjected Then
            'already injected, check and set captions and availability:
            If chkSpawnVehicle.Value <> vbChecked Then chkSpawnVehicle.Value = vbChecked
            If chkSpawnVehicle.Caption <> "Spawner Code-Injection Status: Injected" Then chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Injected"
            If Not chkSpawnVehicle.Enabled Then chkSpawnVehicle.Enabled = True
            If Not cmdSpawnCar(0).Enabled Then cmdSpawnCar(0).Enabled = True
        ElseIf Not CheckIfInjectable Then
            'not injectable, check and set captions and availability:
            If chkSpawnVehicle.Value <> vbUnchecked Then chkSpawnVehicle.Value = vbUnchecked
            If chkSpawnVehicle.Caption <> "Spawner Code-Injection Status: Not Injectable" Then chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injectable"
            If chkSpawnVehicle.Enabled Then chkSpawnVehicle.Enabled = False
            If cmdSpawnCar(0).Enabled Then cmdSpawnCar(0).Enabled = False
        Else
            'not injected, check and set captions and availability:
            If chkSpawnVehicle.Value <> vbUnchecked Then chkSpawnVehicle.Value = vbUnchecked
            If chkSpawnVehicle.Caption <> "Spawner Code-Injection Status: Not Injected" Then chkSpawnVehicle.Caption = "Spawner Code-Injection Status: Not Injected"
            If Not chkSpawnVehicle.Enabled Then chkSpawnVehicle.Enabled = True
            If cmdSpawnCar(0).Enabled Then cmdSpawnCar(0).Enabled = False
        End If
        isInternInjectCheck = False
        If Not isHasPlayer Then Exit Sub
        intRefreshFormValues = intRefreshFormValues - 1
        isInternalClick = False
        isTimerClick = True
        'Form Caption:
        'check if player is in car or not, if in new car, set cat status as desired:
        CheckPlayerCarStatus
        'read parked car information from game:
        Call cmdGarages_Click(0)
        'Player Tracking:
        sngWeaponProfTotal = 0
        For iStatCtr = 0 To 9
            sngWeaponProfTotal = sngWeaponProfTotal + GetMemFloat(GTASABaseAdr.WeaponProfStatAdr(iStatCtr))
        Next iStatCtr
        lblConsole(57).Caption = "Average Weapon Proficiency: " & Format(sngWeaponProfTotal / 100, "#0") & " %"
        If Not isLockArmor Then oPedStats(0).ScrollVal = GetMemFloat(GTASAPlayerAddresse.lngArmorAdr)       'Read Armor
        If Not isLockHealth Then oPedStats(1).ScrollVal = GetMemFloat(GTASAPlayerAddresse.lngHealthAdr)     'Read Health
        If Not isLockFat Then oPedStats(2).ScrollVal = GetMemFloat(GTASABaseAdr.FatStatAdr)                 'Read Fat
        If Not isLockStamina Then oPedStats(3).ScrollVal = GetMemFloat(GTASABaseAdr.StaminaStatAdr)         'Read Stamina
        If Not isLockMuscle Then oPedStats(4).ScrollVal = GetMemFloat(GTASABaseAdr.MuscleStatAdr)           'Read Muscle
        If Not isLockLungStat Then oPedStats(5).ScrollVal = GetMemLong(GTASABaseAdr.LungCapacityAdr)        'Read Lung
        If Not isLockGamblingStat Then oPedStats(6).ScrollVal = GetMemFloat(GTASABaseAdr.GamblingStatAdr)   'Read Gambling
        If Not isLockDrivingProf Then oPedStats(7).ScrollVal = GetMemLong(GTASABaseAdr.VehicleProfAdr(0))   'Read Driving Proficiency
        If Not isLockBikingProf Then oPedStats(8).ScrollVal = GetMemLong(GTASABaseAdr.VehicleProfAdr(1))    'Read Biking Proficiency
        If Not isLockCyclingProf Then oPedStats(9).ScrollVal = GetMemLong(GTASABaseAdr.VehicleProfAdr(2))   'Read Cycling Proficiency
        If Not isLockPilotProf Then oPedStats(10).ScrollVal = GetMemLong(GTASABaseAdr.VehicleProfAdr(3))    'Read Pilot Proficiency
        'set internal click ON:
        isInternalClick = True
        'Weapons:
        If Not isFixBrassKnuckle Then chkWeapons(11).Value = IIf(GetMemLong(GTASAPlayerAddresse.lngBrassKnucklesAdr) = 1, vbChecked, vbUnchecked)
        For iStatCtr = 0 To 10
            If Not isFixWeaponSlots(iStatCtr) Then
                ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponsAdr(iStatCtr), HookPlayerWeapon, 16&, 0&
                If HookPlayerWeapon.lngTotalAmmo = 0 And HookPlayerWeapon.lngWeaponID <> 9 Then
                    cboWeapons(iStatCtr).ListIndex = 0 'no ammo, no weapon
                    iFixWeaponID(iStatCtr) = 0
                ElseIf HookPlayerWeapon.lngWeaponID > 46 Then
                    cboWeapons(iStatCtr).ListIndex = 0 'unknown weapon
                    iFixWeaponID(iStatCtr) = 0
                Else
                    cboWeapons(iStatCtr).ListIndex = WeaponSlotCombo(HookPlayerWeapon.lngWeaponID, 1)
                    iFixWeaponID(iStatCtr) = HookPlayerWeapon.lngWeaponID
                End If
                txtAmmo(iStatCtr).Text = HookPlayerWeapon.lngTotalAmmo
                iFixWeaponAmmo(iStatCtr) = HookPlayerWeapon.lngTotalAmmo
                cboWeapons(iStatCtr).BackColor = &HFFFFFF
                txtAmmo(iStatCtr).BackColor = &HFFFFFF
            End If
        Next iStatCtr
        'Weather:
        If Not isWeatherLock Then
            lngHookBuffer = GetMemLong(GTASABaseAdr.WeatherCurrentAdr)
            If lngHookBuffer > -1 And lngHookBuffer < 46 Then cboWeather.ListIndex = lngHookBuffer
        End If
        'Girlfriends:
        bytHookBuffer = GetMemByte(GTASABaseAdr.HotCoffeeAdr)
        If bytHookBuffer = 1 Then
            chkCoffee.Value = vbUnchecked
            chkCoffee.Caption = "Coffee: Censored"
            chkCoffee.Enabled = True
        ElseIf bytHookBuffer = 0 Then
            chkCoffee.Value = vbChecked
            chkCoffee.Caption = "Coffee: Uncensored"
            chkCoffee.Enabled = True
        Else
            chkCoffee.Value = vbUnchecked
            chkCoffee.Caption = "SCM Modded..."
            chkCoffee.Enabled = False
        End If
        For iStatCtr = 0 To 5
            oGFStats(iStatCtr).ScrollVal = GetMemLong(GTASABaseAdr.GFStatAdr(iStatCtr))
        Next iStatCtr
        'Cheats:
        For iStatCtr = 0 To 19
            If oCheatStates(iStatCtr).CheatLock = vbUnchecked Then
                oCheatStates(iStatCtr).CheatState = IIf(GetMemByte(GTASABaseAdr.cCheatsAdr(iStatCtr)) = 1, vbChecked, vbUnchecked)
            End If
        Next iStatCtr
        'code-inject cheats:
        If oCheatStates(20).CheatLock = vbUnchecked Then
            'check the mem status:
            ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectCheck_OneHitKill(0), 5&, 0&
            If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                'jump code is injected!!
                oCheatStates(21).CheatState = vbChecked
            Else
                oCheatStates(21).CheatState = vbUnchecked
            End If
        End If
        If oCheatStates(21).CheatLock = vbUnchecked Then
            oCheatStates(21).CheatState = IIf(GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = &H9090, vbChecked, vbUnchecked)
        End If
        'Ped Speed:
        lngReadReturn = ReadProcessMemory(lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedHookBuffer, 12&, 0&)
        If lngReadReturn <> 0 Then
            If speedHookBuffer.sngXSpeed > 4 Then speedHookBuffer.sngXSpeed = 4
            If speedHookBuffer.sngXSpeed < -4 Then speedHookBuffer.sngXSpeed = -4
            scrPedSpeed(0).Value = speedHookBuffer.sngXSpeed * 500 'X Speed
            If speedHookBuffer.sngYSpeed > 4 Then speedHookBuffer.sngYSpeed = 4
            If speedHookBuffer.sngYSpeed < -4 Then speedHookBuffer.sngYSpeed = -4
            scrPedSpeed(1).Value = speedHookBuffer.sngYSpeed * 500  'Y Speed
            If speedHookBuffer.sngZSpeed > 4 Then speedHookBuffer.sngZSpeed = 4
            If speedHookBuffer.sngZSpeed < -4 Then speedHookBuffer.sngZSpeed = -4
            scrPedSpeed(2).Value = speedHookBuffer.sngZSpeed * 500  'Z Speed
        End If
        'assign current X/Y/Z Speed and spin to captions:
        lblPedSpeed(0).Caption = "X Speed (" & scrPedSpeed(0).Value / 10 & "%)"
        lblPedSpeed(1).Caption = "Y Speed (" & scrPedSpeed(1).Value / 10 & "%)"
        lblPedSpeed(2).Caption = "Z Speed (" & scrPedSpeed(2).Value / 10 & "%)"
        'Read Ped Specialities to show:
        '01111111 Del EP 127    '10111111 Del DP 191    '11110111 Del FP 247    '11111011 Del BP 251
        '10000000 Set EP 128    '01000000 Set DP  64    '00001000 Set FP   8    '00000100 Set BP   4
        intSpecShowBuffer = GetMemInt(GTASAPlayerAddresse.lngSpecialsAdr)
        lblCurrentPlayer.Caption = "Current Player: " & IIf((intSpecShowBuffer And 128&) = 128&, "EP", "")
        lblCurrentPlayer.Caption = lblCurrentPlayer.Caption & IIf((intSpecShowBuffer And 64&) = 64&, "+DP", "")
        lblCurrentPlayer.Caption = lblCurrentPlayer.Caption & IIf((intSpecShowBuffer And 4&) = 4&, "+BP", "")
        lblCurrentPlayer.Caption = lblCurrentPlayer.Caption & IIf((intSpecShowBuffer And 8&) = 8&, "+FP", "")
        If lblCurrentPlayer.Caption = "Current Player: " Then lblCurrentPlayer.Caption = "Current Player: No Specialities"
        'Car Tracking:
        If isHasCar Then 'Read Car Details:
            '01111111 Del EP 127    '11101111 Del DP 239    '11110111 Del FP 247    '11111011 Del BP 251
            '10000000 Set EP 128    '00010000 Set DP  16    '00001000 Set FP   8    '00000100 Set BP   4
            'Integer at Offset 66:   1..111.. EP/NA/NA/DP/FP/BP/NA/NA
            'Read Car Specialities to show:
            intSpecShowBuffer = GetMemInt(tCurrCarAdr.lngSpecialsAdr)
            lblCurrentCar.Caption = "Current Car: " & IIf((intSpecShowBuffer And 128&) = 128&, "EP", "")
            lblCurrentCar.Caption = lblCurrentCar.Caption & IIf((intSpecShowBuffer And 16&) = 16&, "+DP", "")
            lblCurrentCar.Caption = lblCurrentCar.Caption & IIf((intSpecShowBuffer And 4&) = 4&, "+BP", "")
            lblCurrentCar.Caption = lblCurrentCar.Caption & IIf((intSpecShowBuffer And 8&) = 8&, "+FP", "")
            If lblCurrentCar.Caption = "Current Car: " Then lblCurrentCar.Caption = "Current Car: No Specialities"
            If chkCarDynamics(1).Value = 0 Then 'Read Car Doors:
                bytHookBuffer = GetMemByte(tCurrCarAdr.lngCarDoorAdr)
                'locked: Byte=2 / 'open:Byte=1
                optCarDoors(1).Value = (CInt((bytHookBuffer And 2)) = 2)
                optCarDoors(0).Value = Not optCarDoors(1).Value
            End If
            If chkCarDynamics(3).Value = 0 Then 'Read Engine Damage: (float, car damage tolerance left, 0 to 1000)
                sngHookBuffer = GetMemFloat(tCurrCarAdr.lngCarDamageAdr)
                If (sngHookBuffer >= 0) And (sngHookBuffer <= 4000) Then scrCarDynamics(0).Value = CInt(sngHookBuffer)
                chkCarDynamics(3).Caption = "Engine health (" & scrCarDynamics(0).Value \ 10 & "%):"
            End If
            If chkCarDynamics(4).Value = 0 Then 'Read Car Weight:
                sngHookBuffer = GetMemFloat(tCurrCarAdr.lngCarWeightAdr)
                If (sngHookBuffer >= 100) And (sngHookBuffer <= 400000) Then
                    scrCarDynamics(1).Value = sngHookBuffer / 100
                    chkCarDynamics(4).Caption = "Car Weight: (" & Format$(scrCarDynamics(1).Value / 10, "0.0") & " Tons)"
                End If
            End If
            'Read Car Colors:
            'lngCarColorAdr Major Color / lngCarColorAdr+1 Minor Color
            If chkMajorLock.Value = 0 Then
                bytHookBuffer = GetMemByte(tCurrCarAdr.lngCarColorAdr)
                picMajor.BackColor = GTASAColors(bytHookBuffer).lngRGB
                picMajor.Tag = bytHookBuffer
            End If
            If chkMinorLock.Value = 0 Then
                bytHookBuffer = GetMemByte(tCurrCarAdr.lngCarColorAdr + 1)
                picMinor.BackColor = GTASAColors(bytHookBuffer).lngRGB
                picMinor.Tag = bytHookBuffer
            End If
            'Read Car Dynamics:
            lngReadReturn = ReadProcessMemory(lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedHookBuffer, 12&, 0&)
            If lngReadReturn <> 0 Then
                If speedHookBuffer.sngXSpeed > 4 Then speedHookBuffer.sngXSpeed = 4
                If speedHookBuffer.sngXSpeed < -4 Then speedHookBuffer.sngXSpeed = -4
                scrCarDynamics(2).Value = speedHookBuffer.sngXSpeed * 500 'X Speed
                If speedHookBuffer.sngYSpeed > 4 Then speedHookBuffer.sngYSpeed = 4
                If speedHookBuffer.sngYSpeed < -4 Then speedHookBuffer.sngYSpeed = -4
                scrCarDynamics(3).Value = speedHookBuffer.sngYSpeed * 500 'Y Speed
                If speedHookBuffer.sngZSpeed > 4 Then speedHookBuffer.sngZSpeed = 4
                If speedHookBuffer.sngZSpeed < -4 Then speedHookBuffer.sngZSpeed = -4
                scrCarDynamics(4).Value = speedHookBuffer.sngZSpeed * 500 'Z Speed
            End If
            lngReadReturn = ReadProcessMemory(lngPHandle, tCurrCarAdr.lngCarSpinAdr, spinHookBuffer, 12&, 0&)
            If lngReadReturn <> 0 Then
                If spinHookBuffer.sngXSpin > 4 Then spinHookBuffer.sngXSpin = 4
                If spinHookBuffer.sngXSpin < -4 Then spinHookBuffer.sngXSpin = -4
                scrCarDynamics(5).Value = spinHookBuffer.sngXSpin * 500 'X Spin
                If spinHookBuffer.sngYSpin > 4 Then spinHookBuffer.sngYSpin = 4
                If spinHookBuffer.sngYSpin < -4 Then spinHookBuffer.sngYSpin = -4
                scrCarDynamics(6).Value = spinHookBuffer.sngYSpin * 500 'Y Spin
                If spinHookBuffer.sngZSpin > 4 Then spinHookBuffer.sngZSpin = 4
                If spinHookBuffer.sngZSpin < -4 Then spinHookBuffer.sngZSpin = -4
                scrCarDynamics(7).Value = spinHookBuffer.sngZSpin * 500 'Z Spin
            End If
            'assign current X/Y/Z Speed and spin to captions:
            lblConsole(15).Caption = "X Speed (" & scrCarDynamics(2).Value / 10 & "%)"
            lblConsole(16).Caption = "Y Speed (" & scrCarDynamics(3).Value / 10 & "%)"
            lblConsole(17).Caption = "Z Speed (" & scrCarDynamics(4).Value / 10 & "%)"
            lblConsole(18).Caption = "X Spin (" & scrCarDynamics(5).Value / 10 & "%)"
            lblConsole(19).Caption = "Y Spin (" & scrCarDynamics(6).Value / 10 & "%)"
            lblConsole(20).Caption = "Z Spin (" & scrCarDynamics(7).Value / 10 & "%)"
            If (chkCarDynamics(10).Value = 0) And isHasCar Then 'Get License Plate if not locaked, and if has car:
                txtLicensePlate.Text = GetMemString(tCurrCarAdr.lngLicensePlateAdr, 8)
            End If
        End If
        'Read Garages:
        CheckAndRefreshGarages
        'place red marker on map:
        cPlayerLoc.Left = ((sZoomLevel * (GetMemFloat(GTASAPlayerAddresse.lngXposAdr) + 3000&)) / sngPixToGTA) - (iLocBoxSize / 2)
        cPlayerLoc.Top = ((sZoomLevel * (3000& - GetMemFloat(GTASAPlayerAddresse.lngYposAdr))) / sngPixToGTA) - (iLocBoxSize / 2)
        cPlayerLoc.Visible = True
        'read and refresh game date/time:
        dtGameDateTime = DateSerial(1991, 5, 1 + GetMemInt(GTASABaseAdr.DaysInGameAdr)) + TimeSerial(GetMemByte(GTASABaseAdr.CurrHourAdr), GetMemByte(GTASABaseAdr.CurrMinuteAdr), 0)
        'Game Time: 18:22 / Weekday: Wednesday / Day: 58
        lblConsole(30).Caption = "Game Time: " & Format(dtGameDateTime, "HH:nn") & " / Wd: " & sWeekdays(CInt(Format(dtGameDateTime, "w", vbSunday))) & " / Day: " & GetMemLong(GTASABaseAdr.DaysInGameAdr)
        'show clock speed (1/semi-linear):
        lngHookBuffer = GetMemLong(GTASABaseAdr.GameSpeedMsAdr)
        If (lngHookBuffer > 99) And (lngHookBuffer < 1000) Then
            'clock is fast, scr is plus:
            scrGameSpeed(0).Value = CLng(((100000 / lngHookBuffer) - 100&) / 10&)
            lblConsole(58).Caption = "Clock Speed : " & (100 + (scrGameSpeed(0).Value * 10)) & " %"
        ElseIf lngHookBuffer = 60000 Then
            'clock is real-time:
            scrGameSpeed(0).Value = -91
            lblConsole(58).Caption = "Clock Speed : Real-time"
        ElseIf lngHookBuffer = 3600000 Then
            'clock is frozen:
            scrGameSpeed(0).Value = -92
            lblConsole(58).Caption = "Clock Speed : Stopped"
        ElseIf lngHookBuffer < 10001 Then
            'clock is slow, scr is minus (or zero):
            scrGameSpeed(0).Value = CLng((100000 / lngHookBuffer) - 100&)
            lblConsole(58).Caption = "Clock Speed : " & (100 + scrGameSpeed(0).Value) & " %"
        End If
        'show game speed (semi-linear):
        lngHookBuffer = CLng(GetMemFloat(GTASABaseAdr.GameSpeedPctAdr) * 1000)
        If (lngHookBuffer > 99) And (lngHookBuffer < 1000) Then
            'game is slow, scr is minus:
            scrGameSpeed(1).Value = CLng(lngHookBuffer / 10) - 100
            lblConsole(61).Caption = "Game Speed : " & (100 + scrGameSpeed(1).Value) & " %"
        ElseIf lngHookBuffer < 10001 Then
            'game is fast, scr is plus (or zero):
            scrGameSpeed(1).Value = CLng(lngHookBuffer / 100) - 10
            lblConsole(61).Caption = "Game Speed : " & (100 + (scrGameSpeed(1).Value * 10)) & " %"
        End If
        'Set InternalClick OFF:
        isInternalClick = False
        isTimerClick = False
    End If
Exit Sub
TerminateAll:
    CollectGarbage False
errtmrHook_Timer:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
    isInternalClick = False
    isTimerClick = False
End Sub

Private Sub tmrFindCar_Timer() ' 'Find Car, 5xConsoleTimer=500ms
On Error GoTo errtmrFindCar_Timer
    If GetMemLong(GTASABaseAdr.PlayerAdr) = 0 Then 'Exit if no player
        If Me.Caption <> "GTASA Control Center [Online - No Game in Progress]" Then Me.Caption = "GTASA Control Center [Online - No Game in Progress]"
        Exit Sub
    End If
    'check if player is in car or not, if new car, set car status as desired:
    CheckPlayerCarStatus
Exit Sub
errtmrFindCar_Timer:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Sub tmrConsole_Timer() 'CheckThis 'Main Loop Timer / 10-1000ms
On Error GoTo errtmrConsole_Timer
    Static iStatCtr As Integer
'Lock, as needed the Player properties:
    If isGTASAiconic Or (Not ReFillPlayerAdr) Then Exit Sub
    'Exit if in Menu Mode (doublecheck)
    'read the player information:
    If isLockHealth Then
        If GetMemFloat(GTASAPlayerAddresse.lngHealthAdr) < sngLockHealthTo Then
            SetMemFloat GTASAPlayerAddresse.lngMaxHealthAdr, sngLockHealthTo
            SetMemFloat GTASAPlayerAddresse.lngHealthAdr, sngLockHealthTo
            SetMemFloat GTASABaseAdr.MaxHealthStatAdr, 1000
        End If
    End If
    If isLockArmor Then
        If CLng(GetMemFloat(GTASAPlayerAddresse.lngArmorAdr)) <> CLng(sngLockArmorTo) Then SetMemFloat GTASAPlayerAddresse.lngArmorAdr, sngLockArmorTo
    End If
    If isLockFat Then
        If CLng(GetMemFloat(GTASABaseAdr.FatStatAdr)) <> CLng(sngLockFatTo) Then SetMemFloat GTASABaseAdr.FatStatAdr, sngLockFatTo
    End If
    If isLockStamina Then
        If CLng(GetMemFloat(GTASABaseAdr.StaminaStatAdr)) <> CLng(sngLockStaminaTo) Then SetMemFloat GTASABaseAdr.StaminaStatAdr, sngLockStaminaTo
    End If
    If isLockMuscle Then
        If CLng(GetMemFloat(GTASABaseAdr.MuscleStatAdr)) <> CLng(sngLockMuscleTo) Then SetMemFloat GTASABaseAdr.MuscleStatAdr, sngLockMuscleTo
    End If
    If isLockDrivingProf Then '0
        If GetMemLong(GTASABaseAdr.VehicleProfAdr(0)) <> lngLockDrivingProfTo Then SetMemLong GTASABaseAdr.VehicleProfAdr(0), lngLockDrivingProfTo
    End If
    If isLockBikingProf Then '1
        If GetMemLong(GTASABaseAdr.VehicleProfAdr(1)) <> lngLockBikingProfTo Then SetMemLong GTASABaseAdr.VehicleProfAdr(1), lngLockBikingProfTo
    End If
    If isLockCyclingProf Then '2
        If GetMemLong(GTASABaseAdr.VehicleProfAdr(2)) <> lngLockCyclingProfTo Then SetMemLong GTASABaseAdr.VehicleProfAdr(2), lngLockCyclingProfTo
    End If
    If isLockPilotProf Then '3
        If GetMemLong(GTASABaseAdr.VehicleProfAdr(3)) <> lngLockPilotProfTo Then SetMemLong GTASABaseAdr.VehicleProfAdr(3), lngLockPilotProfTo
    End If
    If isLockLungStat Then
        If GetMemLong(GTASABaseAdr.LungCapacityAdr) <> lngLockLungStatTo Then SetMemLong GTASABaseAdr.LungCapacityAdr, lngLockLungStatTo
    End If
    If isLockGamblingStat Then
        If CLng(GTASABaseAdr.GamblingStatAdr) <> CLng(sngLockGamblingStatTo) Then SetMemFloat GTASABaseAdr.GamblingStatAdr, sngLockGamblingStatTo
    End If
    If isFixPed Then
        SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 7, (chkPedSpecs(0).Value = vbChecked)
        SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 6, (chkPedSpecs(1).Value = vbChecked)
        SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 2, (chkPedSpecs(2).Value = vbChecked)
        SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 3, (chkPedSpecs(3).Value = vbChecked)
    End If
    For iStatCtr = 0 To 5
        If isLockGF(iStatCtr) Then
            If GetMemLong(GTASABaseAdr.GFStatAdr(iStatCtr)) <> lngLockGFto(iStatCtr) Then
                SetMemLong GTASABaseAdr.GFStatAdr(iStatCtr), lngLockGFto(iStatCtr)     'Denise/Michelle/Helena/Katie/Barbara/Millie
                If isOrgSCM Then SetMemLong GTASABaseAdr.GFProgressAdr(iStatCtr), lngLockGFto(iStatCtr) 'Denise/Michelle/Helena/Katie/Barbara/Millie
            End If
        End If
    Next iStatCtr
    'cheats status:
    For iStatCtr = 0 To 19
        If oCheatStates(iStatCtr).CheatLock = vbChecked Then
            If GetMemByte(GTASABaseAdr.cCheatsAdr(iStatCtr)) <> oCheatStates(iStatCtr).CheatState Then SetMemByte GTASABaseAdr.cCheatsAdr(iStatCtr), oCheatStates(iStatCtr).CheatState
        End If
    Next iStatCtr
    'injectable cheats status:
    If oCheatStates(20).CheatLock = vbChecked Then
        'check the mem status:
        ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectCheck_OneHitKill(0), 5&, 0&
        If oCheatStates(20).CheatState = vbChecked Then
            'inject if injectable:
            If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                'jump code is already injected!!
            ElseIf ((bInjectCheck_OneHitKill(0) = bNotInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bNotInjectedJump_OneHitKill(1)) And _
                   (bInjectCheck_OneHitKill(2) = bNotInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bNotInjectedJump_OneHitKill(3)) And _
                   (bInjectCheck_OneHitKill(4) = bNotInjectedJump_OneHitKill(4))) Then
                'jump code is injectable:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCode_OneHitKillAdr, bInjectedCode_OneHitKill(0), 47&, 47&
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectedJump_OneHitKill(0), 5&, 5&
            End If
        Else
            'remove injection:
            If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                'jump code is injected, remove injection:
                WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bNotInjectedJump_OneHitKill(0), 5&, 5&
            End If
        End If
    End If
    If oCheatStates(21).CheatLock = vbChecked Then
        If oCheatStates(21).CheatState = vbChecked Then
            'inject if injectable:
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = iOrg_FreezeTimerUp Then
                SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, &H9090
                If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = iOrg_FreezeTimerDown Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, &H9090
            End If
        Else
            'remove injection if it was injected/injectable:
            If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = &H9090 Then
                SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, iOrg_FreezeTimerUp
                If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = &H9090 Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, iOrg_FreezeTimerDown
            End If
        End If
    End If
    If isRestartCar And tCurrCarAdr.isUsable Then 'restart car if needed
        If (GetMemByte(tCurrCarAdr.lngStalledAdr) And &H10) = 0 Then SetMemByte tCurrCarAdr.lngStalledAdr, GetMemByte(tCurrCarAdr.lngStalledAdr) Or &H10
    End If
    'weapons:
    If isFixBrassKnuckle Then
        If GetMemLong(GTASAPlayerAddresse.lngBrassKnucklesAdr) = 0 Then
            SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr, 1
            SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr + 12, 1
        End If
    End If
    For iStatCtr = 0 To 10
        If isFixWeaponSlots(iStatCtr) Then
            'get current weapon at this slot:
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponsAdr(iStatCtr), HookPlayerWeapon, 16&, 0&
            'compare this against iFixWeaponID and iFixWeaponAmmo:
            If isInjected And (HookPlayerWeapon.lngWeaponID <> iFixWeaponID(iStatCtr)) And iFixWeaponID(iStatCtr) > 0 Then
                'if code is injected, and player has currently another weapon in this slot, initialise this new weapon
                WriteProcessMemory lngPHandle, GTASABaseAdr.WeaponSpawnAdr(iStatCtr), WeaponIDtoDatID(iFixWeaponID(iStatCtr)), 4&, 4&
            End If
            If ((HookPlayerWeapon.lngWeaponID <> iFixWeaponID(iStatCtr)) Or _
                (HookPlayerWeapon.lngTotalAmmo = iFixWeaponAmmo(iStatCtr))) Then
                HookPlayerWeapon.lngWeaponID = iFixWeaponID(iStatCtr)
                HookPlayerWeapon.lngTotalAmmo = iFixWeaponAmmo(iStatCtr)
                WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponsAdr(iStatCtr), HookPlayerWeapon, 16&, 16&
            End If
        End If
    Next iStatCtr
    strOnScreenText = ""
    'special case for Warp to next/previous location:
    If intWarpNextHitDelayCount > 0 Then intWarpNextHitDelayCount = intWarpNextHitDelayCount - 1
    If intGameTimeChangeCount > 0 Then intGameTimeChangeCount = intGameTimeChangeCount - 1
    'Listen to keyboard:
    intShorcutCount = GTASAShortcuts.ShortcutCount
    For intConsoleCounter = 1 To intShorcutCount
        With GTASAShortcuts(intConsoleCounter)
            If .isActive Then
                If .iExtKeyCode > 0 Then
                    If GetAsyncKeyState(.iExtKeyCode) < 0 Then
                        'ExtKey Pressed
                        If GetAsyncKeyState(.iKeyCode) < 0 Then
                            'All needed Keys are pressed, execute command:
                            Select Case .iCategory
                                Case 0 'Commands
                                    ExecuteConsoleCommand .sCommand, .sData
                                Case 1 'Cheats
                                    SendCheatCode GTASACheats.GetItemByUID(.sCommand).sCheatString
                                    If isSafeCheats Then
                                        SetMemLong GTASABaseAdr.CheatCountAdr, 0&
                                        SetMemLong GTASABaseAdr.CheatStatAdr, 0&
                                    End If
                                Case 2 'WarpLocs
                                    PasteWarpLoc 0, GTASAWarpLocs.GetItemByUID(.sCommand).sLocData
                            End Select
                        End If
                    End If
                Else
                    If Not ((GetAsyncKeyState(vbKeyControl) < 0) Or (GetAsyncKeyState(vbKeyMenu) < 0)) Then
                        'No ExtKeys Pressed
                        If GetAsyncKeyState(.iKeyCode) < 0 Then
                            'All needed Keys are pressed, execute command:
                            Select Case .iCategory
                                Case 0 'Commands
                                    ExecuteConsoleCommand .sCommand, .sData
                                Case 1 'Cheats
                                    SendCheatCode GTASACheats.GetItemByUID(.sCommand).sCheatString
                                    If isSafeCheats Then
                                        SetMemLong GTASABaseAdr.CheatCountAdr, 0&
                                        SetMemLong GTASABaseAdr.CheatStatAdr, 0&
                                    End If
                                Case 2 'WarpLocs
                                    PasteWarpLoc 0, GTASAWarpLocs.GetItemByUID(.sCommand).sLocData
                            End Select
                        End If
                    End If
                End If
            End If
        End With
CheckNextShortcut:
    Next intConsoleCounter
    If isHasFeedback Then
        If Len(strOnScreenText) > 2 Then '"; "
            strOnScreenText = Mid$(strOnScreenText, 3) & "."
            OnScreenText strOnScreenText
            strOnScreenText = ""
        End If
    End If
    If isFlightAssistance And isHasCar Then
        If intSpinSeconds > 0 Then
            intSpinSeconds = intSpinSeconds - 1
        ElseIf intSpinSeconds = 0 Then
            'Just for once, Stop Spin:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr, zeroSpin, 12&, 12&
            'Level Z Grad:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 8, 0&, 4&, 4&
            'Level Z Looking:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 24, 0&, 4&, 4&
            'Level X/Y/Z Relational Positioning
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 32, 0&, 4&, 4&
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 36, 0&, 4&, 4&
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr + 40, 1&, 4&, 4&
            intSpinSeconds = -1
        End If
        'Stop Flight Assistance for intFallSeconds:
        If intFallSeconds > 0 Then
            intFallSeconds = intFallSeconds - 1
        ElseIf intFallSeconds = 0 Then
            'Normalize and Set Speed always:
            'Read Speed
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedConsoleBuffer, 12&, 0&
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipConsoleBuffer, 28&, 0&
            'Normalize Speed:
            speedConsoleBuffer.sngXSpeed = (Abs(speedConsoleBuffer.sngXSpeed) + Abs(speedConsoleBuffer.sngYSpeed)) * (carFlipConsoleBuffer.sngXlooking / (Abs(carFlipConsoleBuffer.sngXlooking) + Abs(carFlipConsoleBuffer.sngYlooking)))
            speedConsoleBuffer.sngYSpeed = (Abs(speedConsoleBuffer.sngXSpeed) + Abs(speedConsoleBuffer.sngYSpeed)) * (carFlipConsoleBuffer.sngYlooking / (Abs(carFlipConsoleBuffer.sngXlooking) + Abs(carFlipConsoleBuffer.sngYlooking)))
            If speedConsoleBuffer.sngZSpeed < 0 Then speedConsoleBuffer.sngZSpeed = 0.03 + sngAssistFlightBy
            'Write speed:
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedConsoleBuffer, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedConsoleBuffer, 12&, 12&
        End If
    End If
    If isPedFlightAssistance Then
        'Stop Flight Assistance for intFallSeconds:
        If intFallSeconds > 0 Then
            intFallSeconds = intFallSeconds - 1
        ElseIf intFallSeconds = 0 Then
            'Normalize and Set Speed always:
            'Read Speed
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedConsoleBuffer, 12&, 0&
            'Normalize Speed:
            If speedConsoleBuffer.sngZSpeed < 0 Then speedConsoleBuffer.sngZSpeed = 0.03 + sngPedAssistFlightBy
            'Write speed:
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedConsoleBuffer, 12&, 12&
        End If
    End If
    'Lock Car properties:
    CheckPlayerCarStatus
    If isHasCar Or isHadCar Then
        'Lock Engine Damage:
        If isLockEngineHealth Then
            SetMemFloat tCurrCarAdr.lngCarDamageAdr, sngLockEngineHealthTo   '(if set to 255, also tyres explode)
            If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarDamageAdr, sngLockEngineHealthTo  '(if set to 255, also tyres explode)
        End If
        If isDontBurn Or isDontExplode Then
            '+676    Engine Damage (byte) 0:No damage 225:burning 255:explodes (can be fixed to 0 to repair engine)
            'Car Damage Tolerance left
            fCarHealth = 0
            lngReadReturn = ReadProcessMemory(lngPHandle, tCurrCarAdr.lngCarDamageAdr, fCarHealth, 4&, 0&)
            If lngReadReturn <> 0 Then
                'Check Left Car Tolerance:
                If fCarHealth < 500 Then
                    'Car is burning to explode
                    If isDontBurn Then
                        SetMemFloat tCurrCarAdr.lngCarDamageAdr, 1000
                    ElseIf isDontExplode And (fCarHealth < 250) Then  'Dont Explode, just set ExplodeTimer to 0, so let it burn:
                        SetMemFloat tCurrCarAdr.lngBurnTimerAdr, 0
                    End If
                End If
            End If
            If tCurrTrailer.isUsable Then
                fCarHealth = 0
                lngReadReturn = ReadProcessMemory(lngPHandle, tCurrTrailer.lngCarDamageAdr, fCarHealth, 4&, 0&)
                If lngReadReturn <> 0 Then
                    'Check Left Car Tolerance:
                    If fCarHealth < 500 Then
                        'Car is burning to explode
                        If isDontBurn Then
                            SetMemFloat tCurrTrailer.lngCarDamageAdr, 1000
                        ElseIf isDontExplode And (fCarHealth < 250) Then 'Dont Explode, just set ExplodeTimer to 0, so let it burn:
                            SetMemFloat tCurrTrailer.lngBurnTimerAdr, 0
                        End If
                    End If
                End If
            End If
        End If
        If isPreventWheelDamage Then
            If LCase(strCarType) = "bike" Then
                'bike wheel damage is on offset 1630 as integer
                SetMemInt tCurrCarAdr.lngBikeWheelAdr, 0
            Else
                'Prevent wheel damage:
                'Byte: (.1.1.1..=NA/RF/NA/LB/NA/LF/NA/NA) RF:RightFrontWheel 1:shot, 0:OK
                SetMemByte tCurrCarAdr.lngCarWheelAdr, 0
                SetMemByte tCurrCarAdr.lngCarWheelAdr + 1, 0
                If tCurrTrailer.isUsable Then
                    SetMemByte tCurrTrailer.lngCarWheelAdr, 0
                    SetMemByte tCurrTrailer.lngCarWheelAdr + 1, 0
                End If
            End If
        End If
    End If

Exit Sub
errtmrConsole_Timer:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

'--------------------------------------------------------------------------------------------------------------------
'                                   Private Functions
'--------------------------------------------------------------------------------------------------------------------

Private Sub NormalizeParkingSlotCarPlacement(ByRef tSlot As GTASAGarage, ByVal iGarageCtr As Integer, _
                                             ByVal sngXoff As Single, ByVal sngYoff As Single)                                              '
On Error Resume Next
    tSlot.sngXcoord = GTASAGarageDim(iGarageCtr).sngXpos + (((sngXoff ^ 2) + (sngYoff ^ 2)) ^ 0.5) * Cos(((Atn(sngYoff / sngXoff) * 180 / mathPI) + GTASAGarageDim(iGarageCtr).sngAbsDegrees) * mathPI / 180)
    tSlot.sngYcoord = GTASAGarageDim(iGarageCtr).sngYpos + (((sngXoff ^ 2) + (sngYoff ^ 2)) ^ 0.5) * Sin(((Atn(sngYoff / sngXoff) * 180 / mathPI) + GTASAGarageDim(iGarageCtr).sngAbsDegrees) * mathPI / 180)
    tSlot.sngZcoord = GTASAGarageDim(iGarageCtr).sngZpos + (ParkedCars(tSlot.intCarCode).sngCarHeight * 1 / 3)
End Sub

Private Function FillInCombos() As Boolean '
On Error GoTo errFillInCombos
    FillInCombos = False
    'Shortcut Combo:
    cboShortcut.Clear
    cboShortcut.AddItem "(None)"
    'Special Keys:
    cboShortcut.AddItem "SHIFT "
    cboShortcut.AddItem "INSERT"
    cboShortcut.AddItem "DELETE"
    cboShortcut.AddItem "HOME "
    cboShortcut.AddItem "END"
    cboShortcut.AddItem "PgUP"
    cboShortcut.AddItem "PgDOWN"
    For intCounter = 0 To 9
        cboShortcut.AddItem "NUM " & intCounter
    Next intCounter
    cboShortcut.AddItem "NUM COMMA"
    cboShortcut.AddItem "ENTER"
    cboShortcut.AddItem "NUM +"
    cboShortcut.AddItem "NUM - "
    cboShortcut.AddItem "NUM *"
    cboShortcut.AddItem "NUM /"
    cboShortcut.AddItem "F2"
    cboShortcut.AddItem "F4"
    'F5 to F12
    For intCounter = 5 To 12
        cboShortcut.AddItem "F" & intCounter
    Next intCounter
    '0 to 9
    For intCounter = 0 To 9
        cboShortcut.AddItem Format$(intCounter)
    Next intCounter
    'A to Z
    For intCounter = 65 To 90
        cboShortcut.AddItem Chr(intCounter)
    Next intCounter

    FillInCombos = True
Exit Function
errFillInCombos:
    MsgBox Err.Description, vbCritical, "Internal error in FillInCombo's"
    Err.Clear
End Function

Private Function ParseIniValues() As Boolean '
On Error GoTo errParseIniValues
    Dim intParseBuffer As Integer
    Dim sngParseBuffer As Single
    Dim isMsgBoxShown As Boolean
    isMsgBoxShown = False
    ParseIniValues = False
    isInternalClick = True
    
    strBuffer = Space(50) 'Info Msg
    GetPrivateProfileString "Main", "InfoMsg", "0", strBuffer, 50, strIniFileName
    iMsgShowCtr = CInt(TrimChr0(strBuffer))
    isMsgShown = (iMsgShowCtr < 1)
    strBuffer = Space(5) 'Interval
    GetPrivateProfileString "Main", "Interval", "100", strBuffer, 5, strIniFileName
    tmrConsole.Interval = CInt("0" & TrimChr0(strBuffer))
    If tmrConsole.Interval = 0 Then tmrConsole.Interval = 10
    scrIntervall.Value = tmrConsole.Interval
    lblIntervall.Caption = "Keyboard Control Intervall: (" & tmrConsole.Interval & " ms)."
    strBuffer = Space(2) 'Feedback
    GetPrivateProfileString "Main", "Feedback", "1", strBuffer, 2, strIniFileName
    chkFeedback.Value = CInt(TrimChr0(strBuffer))
    isHasFeedback = (chkFeedback.Value = 1)
    strBuffer = Space(2) 'SCM Modded
    GetPrivateProfileString "Main", "OrgSCM", "1", strBuffer, 2, strIniFileName
    chkOrgSCM.Value = CInt(TrimChr0(strBuffer))
    isOrgSCM = (chkOrgSCM.Value = 1)
    For intParseBuffer = 0 To 5
        oGFStats(intParseBuffer).Enabled = isOrgSCM
    Next intParseBuffer
    For intCounter = 0 To 21
        strBuffer = Space(4) 'Injectable cheats 22 pieces
        GetPrivateProfileString "Main", oCheatStates(intCounter).Tag, "0,0", strBuffer, 4, strIniFileName
        oCheatStates(intCounter).CheatLock = CInt(GetToken(strBuffer, 1))
        If oCheatStates(intCounter).CheatLock = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oCheatStates(intCounter).CheatState = CInt(GetToken(strBuffer, 2))
    Next intCounter
    strBuffer = Space(10) 'GTASAVersion
    GetPrivateProfileString "Main", "GTASAVersion", "v1.0", strBuffer, 10, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    Select Case strBuffer
        Case "v1.0"
            cboGTAVersion.ListIndex = 0
        Case "v1.1"
            cboGTAVersion.ListIndex = 1
'        Case Else
'            cboGTAVersion.ListIndex = 2
    End Select
    strBuffer = Space(10) 'Weather
    GetPrivateProfileString "Main", "Weather", "0,17", strBuffer, 10, strIniFileName
    chkWeatherLock.Value = GetToken(strBuffer, 1)
    If chkWeatherLock.Value = vbChecked Then
        cboWeather.ListIndex = GetToken(strBuffer, 2)
        isWeatherLock = True
        lngLockWeatherTo = cboWeather.ListIndex
        If lngLockWeatherTo < 0 Then lngLockWeatherTo = 1
    End If
'Markup Locations:
    For intCounter = 1 To 10
        strBuffer = Space(255)
        GetPrivateProfileString "PlayerTracking", "MarkupLoc" & intCounter, "", strBuffer, 255, strIniFileName
        strBuffer = TrimChr0(strBuffer)
        strMarkLocations(intCounter) = strBuffer
    Next intCounter
'PlayerTracking
    strBuffer = Space(10) 'Armor Level
    GetPrivateProfileString "PlayerTracking", "FixArmor", "0,400", strBuffer, 10, strIniFileName
    oPedStats(0).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(0).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(0).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockArmor = (oPedStats(0).Locked = 1)
    sngLockArmorTo = oPedStats(0).ScrollVal
    strBuffer = Space(10) 'Health Level
    GetPrivateProfileString "PlayerTracking", "FixHealth", "0,400", strBuffer, 10, strIniFileName
    oPedStats(1).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(1).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(1).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockHealth = (oPedStats(1).Locked = 1)
    sngLockHealthTo = oPedStats(1).ScrollVal
    strBuffer = Space(20) 'Fat Level
    GetPrivateProfileString "PlayerTracking", "FixFat", "0,0", strBuffer, 20, strIniFileName
    oPedStats(2).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(2).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(2).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockFat = (oPedStats(2).Locked = 1)
    sngLockFatTo = oPedStats(2).ScrollVal
    strBuffer = Space(20) 'Stamina Level
    GetPrivateProfileString "PlayerTracking", "FixStamina", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(3).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(3).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(3).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockStamina = (oPedStats(3).Locked = 1)
    sngLockStaminaTo = oPedStats(3).ScrollVal
    strBuffer = Space(20) 'Muscle Level
    GetPrivateProfileString "PlayerTracking", "FixMuscle", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(4).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(4).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(4).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockMuscle = (oPedStats(4).Locked = 1)
    sngLockMuscleTo = oPedStats(4).ScrollVal
    strBuffer = Space(20) 'Lung Capacity
    GetPrivateProfileString "PlayerTracking", "FixLungStat", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(5).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(5).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(5).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockLungStat = (oPedStats(5).Locked = 1)
    lngLockLungStatTo = oPedStats(5).ScrollVal
    strBuffer = Space(20) 'Gambling Stat
    GetPrivateProfileString "PlayerTracking", "FixGamblingStat", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(6).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(6).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(6).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockGamblingStat = (oPedStats(6).Locked = 1)
    sngLockGamblingStatTo = oPedStats(6).ScrollVal
    strBuffer = Space(20) 'Driving Stat
    GetPrivateProfileString "PlayerTracking", "FixDrivingProf", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(7).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(7).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(7).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockDrivingProf = (oPedStats(7).Locked = 1)
    lngLockDrivingProfTo = oPedStats(7).ScrollVal
    strBuffer = Space(20) 'Biking Stat
    GetPrivateProfileString "PlayerTracking", "FixBikingProf", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(8).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(8).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(8).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockBikingProf = (oPedStats(8).Locked = 1)
    lngLockBikingProfTo = oPedStats(8).ScrollVal
    strBuffer = Space(20) 'Cycling Stat
    GetPrivateProfileString "PlayerTracking", "FixCyclingProf", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(9).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(9).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(9).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockCyclingProf = (oPedStats(9).Locked = 1)
    lngLockCyclingProfTo = oPedStats(9).ScrollVal
    strBuffer = Space(20) 'Pilot Stat
    GetPrivateProfileString "PlayerTracking", "FixPilotProf", "0,1000", strBuffer, 20, strIniFileName
    oPedStats(10).Locked = CInt(GetToken(strBuffer, 1))
    If oPedStats(10).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oPedStats(10).ScrollVal = CInt(GetToken(strBuffer, 2))
    isLockPilotProf = (oPedStats(10).Locked = 1)
    lngLockPilotProfTo = oPedStats(10).ScrollVal
    strBuffer = Space(10) 'FlightAssist
    GetPrivateProfileString "PlayerTracking", "PedFlightAssist", "0,2", strBuffer, 10, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    oPedStats(20).Locked = CInt(GetToken(strBuffer, 1))
    oPedStats(20).ScrollVal = CInt(GetToken(strBuffer, 2))
    isPedFlightAssistance = (oPedStats(20).Locked = 1)
    sngPedAssistFlightBy = CSng(oPedStats(20).ScrollVal) * 0.002
    strBuffer = Space(10) 'Set Ped Specs
    GetPrivateProfileString "PlayerTracking", "FixPed", "0,0,0,0,0", strBuffer, 10, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkFixPedSpecs.Value = CInt(GetToken(strBuffer, 1))
    isFixPed = (chkFixPedSpecs.Value = 1)
    For intCounter = 0 To 3
        chkPedSpecs(intCounter).Value = CInt(GetToken(strBuffer, intCounter + 2))
    Next intCounter
    'Player Weapon and Ammo Values:
    strBuffer = Space(2) 'Brass Knuckle locked or not
    GetPrivateProfileString "PlayerTracking", "WeaponBr", "0", strBuffer, 2, strIniFileName
    chkWeapons(11).Value = IIf(Left$(strBuffer, 1) = "1", vbChecked, vbUnchecked)
    isFixBrassKnuckle = (chkWeapons(11).Value = vbChecked)
    For intCounter = 0 To 10
        strBuffer = Space(100) 'Weapons
        GetPrivateProfileString "PlayerTracking", "Weapon" & Format$(intCounter, "00"), "0,0,0", strBuffer, 100, strIniFileName
        chkWeapons(intCounter).Value = CInt(GetToken(strBuffer, 1))
        If chkWeapons(intCounter).Value = vbChecked Then
            isFixWeaponSlots(intCounter) = True
            iFixWeaponID(intCounter) = CLng(GetToken(strBuffer, 2))
            iFixWeaponAmmo(intCounter) = CLng(GetToken(strBuffer, 3))
            cboWeapons(intCounter).ListIndex = WeaponSlotCombo(iFixWeaponID(intCounter), 1)
            txtAmmo(intCounter).Text = iFixWeaponAmmo(intCounter)
        Else
            cboWeapons(intCounter).ListIndex = 0
        End If
    Next intCounter
    strBuffer = Space(2) 'Safe Cheats
    GetPrivateProfileString "Main", "SafeCheats", "1", strBuffer, 2, strIniFileName
    chkSafeCheats.Value = CInt(TrimChr0(strBuffer))
    isSafeCheats = (chkSafeCheats.Value = 1)
    'Girlfriends:
    For intCounter = 0 To 5
        strBuffer = Space(20)
        GetPrivateProfileString "PlayerTracking", oGFStats(intCounter).Tag, "0,100", strBuffer, 20, strIniFileName
        oGFStats(intCounter).Locked = CInt(GetToken(strBuffer, 1))
        If oGFStats(intCounter).Locked = 1 And CInt(GetToken(strBuffer, 2)) > 0 Then oGFStats(intCounter).ScrollVal = CInt(GetToken(strBuffer, 2))
        isLockGF(intCounter) = (oGFStats(intCounter).Locked = 1)
        lngLockGFto(intCounter) = oGFStats(intCounter).ScrollVal
    Next intCounter
    'CarTracking:
    strBuffer = Space(10) 'Set Car Specs
    GetPrivateProfileString "CarTracking", "SetCarSpecs", "0,0,0,0,0", strBuffer, 10, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkCarDynamics(0).Value = CInt("0" & GetToken(strBuffer, 1))
    For intCounter = 0 To 3
        chkCarSpecs(intCounter).Value = CInt("0" & GetToken(strBuffer, intCounter + 2))
    Next intCounter
    strBuffer = Space(4) 'CarDoors
    GetPrivateProfileString "CarTracking", "CarDoors", "0,0", strBuffer, 4, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkCarDynamics(1).Value = CInt("0" & GetToken(strBuffer, 1))
    optCarDoors(0).Value = CInt("0" & GetToken(strBuffer, 2))
    optCarDoors(1).Value = Not optCarDoors(0).Value
    isAutoLockCarDoors = (chkCarDynamics(1).Value = 1) And optCarDoors(1).Value
    strBuffer = Space(10) 'EngineDamage
    GetPrivateProfileString "CarTracking", "EngineHealth", "0,1000", strBuffer, 10, strIniFileName
    chkCarDynamics(3).Value = GetToken(strBuffer, 1)
    If chkCarDynamics(3).Value = 1 Then
        intParseBuffer = GetToken(strBuffer, 2)
        If intParseBuffer < 0 Then intParseBuffer = 0
        If intParseBuffer > 1000 Then intParseBuffer = 1000
        scrCarDynamics(0).Value = intParseBuffer
        chkCarDynamics(3).Caption = "Engine health (" & intParseBuffer \ 10 & "%):"
    End If
    isLockEngineHealth = (chkCarDynamics(3).Value = 1)
    sngLockEngineHealthTo = scrCarDynamics(0).Value
    strBuffer = Space(10) 'CarWeight
    GetPrivateProfileString "CarTracking", "CarWeight", "0,500", strBuffer, 10, strIniFileName
    chkCarDynamics(4).Value = GetToken(strBuffer, 1)
    If chkCarDynamics(4).Value = 1 Then
        intParseBuffer = GetToken(strBuffer, 2)
        scrCarDynamics(1).Value = intParseBuffer
        chkCarDynamics(4).Caption = "Car Weight: (" & Format$(intParseBuffer / 10, "0.0") & " Tons)"
    End If
    strBuffer = Space(14) 'PaintCar
    GetPrivateProfileString "CarTracking", "PaintCar", "0,1,0,1,0", strBuffer, 14, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkCarDynamics(5).Value = CInt("0" & GetToken(strBuffer, 1))
    picMajor.BackColor = GTASAColors(CInt("0" & GetToken(strBuffer, 2))).lngRGB
    picMajor.Tag = CInt("0" & GetToken(strBuffer, 2))
    chkMajorLock.Value = CInt("0" & GetToken(strBuffer, 3))
    picMinor.BackColor = GTASAColors(CInt("0" & GetToken(strBuffer, 4))).lngRGB
    picMinor.Tag = CInt("0" & GetToken(strBuffer, 4))
    chkMinorLock.Value = CInt("0" & GetToken(strBuffer, 5))
    strBuffer = Space(2) 'CarAlarm
    GetPrivateProfileString "CarTracking", "CarAlarm", "0", strBuffer, 2, strIniFileName
    chkCarDynamics(6).Value = CInt("0" & TrimChr0(strBuffer))
    strBuffer = Space(2) 'PreventWheelDamage
    GetPrivateProfileString "CarTracking", "WheelDamage", "0", strBuffer, 2, strIniFileName
    chkCarDynamics(2).Value = CInt("0" & TrimChr0(strBuffer))
    isPreventWheelDamage = (chkCarDynamics(2).Value = 1)
    strBuffer = Space(2) 'RCCars
    GetPrivateProfileString "CarTracking", "RCCars", "0", strBuffer, 2, strIniFileName
    chkCarDynamics(9).Value = IIf(Left$(strBuffer, 1) = "1", vbChecked, vbUnchecked)
    isControlRCCars = (chkCarDynamics(9).Value = 1)
    strBuffer = Space(10) 'FlightAssist
    GetPrivateProfileString "CarTracking", "FlightAssist", "0,2", strBuffer, 10, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkCarDynamics(8).Value = CInt(GetToken(strBuffer, 1))
    scrCarDynamics(8).Value = CInt(GetToken(strBuffer, 2))
    chkCarDynamics(8).Caption = "Flight Assistance (" & scrCarDynamics(8).Value / 10 & "%)"
    isFlightAssistance = (chkCarDynamics(8).Value = 1)
    sngAssistFlightBy = CSng(scrCarDynamics(8).Value) * 0.002
    strBuffer = Space(4) 'DontBurn
    GetPrivateProfileString "CarTracking", "DontBurn", "0,0", strBuffer, 4, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkDontBurn(0).Value = CInt("0" & GetToken(strBuffer, 1))
    chkDontBurn(1).Value = CInt("0" & GetToken(strBuffer, 2))
    isDontExplode = (chkDontBurn(1).Value = 1)
    isDontBurn = (chkDontBurn(0).Value = 1)
    strBuffer = Space(2) 'RestartCar if stalled
    GetPrivateProfileString "CarTracking", "RestartCar", "0", strBuffer, 2, strIniFileName
    chkCarDynamics(7).Value = CInt("0" & TrimChr0(strBuffer))
    isRestartCar = (chkCarDynamics(7).Value = 1)
    strBuffer = Space(2) 'Auto-Inject Code if possible
    GetPrivateProfileString "CarTracking", "AutoInject", "0", strBuffer, 2, strIniFileName
    chkAutoInjectCode.Value = CInt("0" & TrimChr0(strBuffer))
    isAutoInject = (chkAutoInjectCode.Value = 1)
    strBuffer = Space(2) 'Inject Code Msg Counter
    GetPrivateProfileString "CarTracking", "InjectMsg", "0", strBuffer, 2, strIniFileName
    iInjectMsgCtr = CInt("0" & TrimChr0(strBuffer))
    strBuffer = Space(11) '"1,GTASA CC"
    GetPrivateProfileString "CarTracking", "LicensePlate", "0,GTASA CC", strBuffer, 11, strIniFileName
    strBuffer = TrimChr0(strBuffer)
    chkCarDynamics(10).Value = CInt(GetToken(strBuffer, 1))
    txtLicensePlate.Text = GetToken(strBuffer, 2)
    txtLicensePlate.Text = UCase(txtLicensePlate.Text)
    If Trim(txtLicensePlate.Text) = "" Then txtLicensePlate.Text = "GTASA CC"
    If Len(txtLicensePlate.Text) < 8 Then txtLicensePlate.Text = Left$(txtLicensePlate.Text & "        ", 8)
    sLicensePlate = txtLicensePlate.Text
    isFixLicensePlate = (chkCarDynamics(10).Value = vbChecked)
    'garages
    For intCounter = 0 To 67
        strBuffer = Space(255)
        GetPrivateProfileString "CarTracking", "Garage" & intCounter, "0,1,1,1,1,1,1,1", strBuffer, 255, strIniFileName
        strBuffer = TrimChr0(strBuffer)
        cParking(intCounter \ 4).SetIniVals (intCounter Mod 4), strBuffer
    Next intCounter
    isInternalClick = False
    ParseIniValues = True
Exit Function
errParseIniValues:
    If isMsgBoxShown Then
        Err.Clear
        Resume Next
    Else
        MsgBox "Initialisation Failed." & vbCrLf & "Don't mess with ini file."
        isMsgBoxShown = True
        Err.Clear
        Resume Next
    End If
    
End Function

Private Sub FillInShortcutDetails()
On Error GoTo errFillInShortcutDetails
    Dim iCboCtr As Integer
    Dim iWeaponID As Integer
    If isInternalClick Then Exit Sub
    If tvShotcuts.SelectedItem Is Nothing Then Exit Sub 'doublecheck
    If tvShotcuts.SelectedItem.Tag = "folder" Then Exit Sub 'doublecheck
    With GTASAShortcuts.GetItemByUID(tvShotcuts.SelectedItem.Tag)
        Select Case .iCategory
            Case 0 'Internal Commands
                cboCommands(0).ListIndex = CInt(.sCommand)
                sstCommandData.Tab = .iDataPage
                Select Case .iDataPage
                    Case 0, 1, 2, 8, 9, 13, 14, 15, 19 'Armor/Health/Wanted/EngineHealth/CarWeight/CarDynamics/MissionTime/Criminals Killed
                        If Len(.sData) > 0 Then
                            scrCommandData(sstCommandData.Tab).Value = CInt(.sData)
                            Call scrCommandData_Change(.iDataPage)
                        End If
                    Case 3 'Weapon / Ammo Select
                        iWeaponID = CInt(GetToken(.sData, 1, ";"))
                        For iCboCtr = 0 To cboCommandWeapon.ListCount - 1
                            If cboCommandWeapon.ItemData(iCboCtr) = iWeaponID Then
                                cboCommandWeapon.ListIndex = iCboCtr
                                Exit For
                            End If
                        Next iCboCtr
                        txtCommandWeaponAmmo.Text = GetToken(.sData, 2, ";")
                    Case 5 'DP/EP/BP/FP
                        chkCarSpecsCommand(0).Value = CInt(GetToken(.sData, 1, ";"))
                        chkCarSpecsCommand(1).Value = CInt(GetToken(.sData, 2, ";"))
                        chkCarSpecsCommand(2).Value = CInt(GetToken(.sData, 3, ";"))
                        chkCarSpecsCommand(3).Value = CInt(GetToken(.sData, 4, ";"))
                    Case 6 'open/locked
                        optCarDoorsCommand(0).Value = (.sData = "1")
                        optCarDoorsCommand(1).Value = Not optCarDoorsCommand(0).Value
                    Case 7 'weather selection
                        cboCommandWeather.ListIndex = CInt(.sData)
                    Case 10 'Colors
                        picColorCommand(0).BackColor = GTASAColors(CInt(GetToken(.sData, 1, ";"))).lngRGB
                        picColorCommand(0).Tag = GetToken(.sData, 1, ";")
                        chkCommandColorLock(0).Value = CInt(GetToken(.sData, 2, ";"))
                        picColorCommand(1).BackColor = GTASAColors(CInt(GetToken(.sData, 3, ";"))).lngRGB
                        picColorCommand(1).Tag = GetToken(.sData, 3, ";")
                        chkCommandColorLock(1).Value = CInt(GetToken(.sData, 4, ";"))
                    Case 11 'Directions
                        cboCommandDirection.ListIndex = CInt(GetToken(.sData, 1, ";"))
                        scrCommandData(11).Value = CInt(GetToken(.sData, 2, ";"))
                        lblCommandData(11).Caption = "(" & scrCommandData(11).Value & "%)"
                    Case 12 'CarList
                        cboCommandParkedCar.ListIndex = SpawnListMatrix(CInt(.sData))
                    Case 16 'ON/OFF
                        optCommandOnOff(0).Value = (.sData = "1")
                        optCommandOnOff(1).Value = Not optCommandOnOff(0).Value
                    'Case 17 'NONE
                    Case 18 'Markup Locations: Loc.1 to Loc.10
                        cboCommandMarkupLocs.ListIndex = CInt(.sData) - 1
                End Select
            Case 1 'Cheat Strings
                For iCboCtr = 0 To cboCommands(1).ListCount - 1
                    If sCheatUID(iCboCtr) = .sCommand Then
                        cboCommands(1).ListIndex = iCboCtr
                        Exit For
                    End If
                Next iCboCtr
                sstCommandData.Tab = 17
            Case 2 'Warp Locations
                For iCboCtr = 0 To cboCommands(2).ListCount - 1
                    If sLocUID(iCboCtr) = .sCommand Then
                        cboCommands(2).ListIndex = iCboCtr
                        Exit For
                    End If
                Next iCboCtr
                sstCommandData.Tab = 17
        End Select
        cboShortcut.Text = .sComboText
        chkShortcut(0).Value = Abs(CInt(.iExtKeyCode = vbKeyControl))
        chkShortcut(1).Value = Abs(CInt(.iExtKeyCode = vbKeyMenu))
    End With
Exit Sub
errFillInShortcutDetails:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Sub

Private Function FillInCommandCombo(Optional ByVal isCommands As Boolean = True, _
                                    Optional ByVal isCheats As Boolean = True, _
                                    Optional ByVal isWarpLocs As Boolean = True) As Boolean '
On Error GoTo errFillInCommandCombo
    FillInCommandCombo = False
    If isCommands Then
        'Internal Commands:
        cboCommands(0).Clear
        For intCounter = 0 To 150
            If Len(GTASAConsoleCommands(intCounter).Description) > 0 Then
                cboCommands(0).AddItem GTASAConsoleCommands(intCounter).Description
            End If
        Next intCounter
    End If
    If isCheats Then
        'CheatStrings:
        cboCommands(1).Clear
        ReDim sCheatUID(GTASACheats.CheatCount)
        For intCounter = 1 To GTASACheats.CheatCount
            With GTASACheats(intCounter)
                cboCommands(1).AddItem .sDescription
                sCheatUID(intCounter - 1) = .sUID
            End With
        Next intCounter
    End If
    If isWarpLocs Then
        'WarpLocations:
        cboCommands(2).Clear
        ReDim sLocUID(GTASAWarpLocs.WarpLocCount)
        For intCounter = 1 To GTASAWarpLocs.WarpLocCount
            With GTASAWarpLocs(intCounter)
                cboCommands(2).AddItem .sDescription
                sLocUID(intCounter - 1) = .sUID
            End With
        Next intCounter
    End If
    FillInCommandCombo = True
Exit Function
errFillInCommandCombo:
    MsgBox Err.Description, , "Initialisation failed"
    Err.Clear
End Function

Private Function ReadLocData(Optional ByVal intMarkLocOrdinal As Integer = -1) As Boolean '
On Error GoTo errReadLocData
    Dim strLocDataBuffer As String
    Dim sngAngleGrad As Single
    ReadLocData = False
    If Not ReFillPlayerAdr Then Exit Function
    If intMarkLocOrdinal > -1 Then strMarkLocations(intMarkLocOrdinal) = ""
    'Read Player Locations:
    ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngXposAdr, GTASAWarpPlayerLoc, 12&, 0&
    ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr, sngAngleGrad, 4&, 0&
    'convert grad to angle:
    sngAngleGrad = (sngAngleGrad * 180) / mathPI
    'normalize angle x 2:
    If sngAngleGrad < 0 Then sngAngleGrad = sngAngleGrad + 360
    If sngAngleGrad < 0 Then sngAngleGrad = sngAngleGrad + 360
    If sngAngleGrad > 360 Then sngAngleGrad = sngAngleGrad - 360
    If sngAngleGrad > 360 Then sngAngleGrad = sngAngleGrad - 360
    strLocDataBuffer = Replace(Format$(GTASAWarpPlayerLoc.sngXcoord, "#0.00000000"), ",", ".") & ";" & _
                       Replace(Format$(GTASAWarpPlayerLoc.sngYcoord, "#0.00000000"), ",", ".") & ";" & _
                       Replace(Format$(GTASAWarpPlayerLoc.sngZcoord, "#0.00000000"), ",", ".") & ";" & _
                       Replace(Format$(sngAngleGrad, "#0.00000000"), ",", ".")
    If intMarkLocOrdinal = -1 Then
        'show on form,
        txtCoords(0).Text = Replace(Format$(GTASAWarpPlayerLoc.sngXcoord, "#0.000000"), ",", ".")
        txtCoords(1).Text = Replace(Format$(GTASAWarpPlayerLoc.sngYcoord, "#0.000000"), ",", ".")
        txtCoords(2).Text = Replace(Format$(GTASAWarpPlayerLoc.sngZcoord, "#0.000000"), ",", ".")
        txtCoords(3).Text = Replace(Format$(sngAngleGrad, "#0.000000"), ",", ".")
    Else
        'remember only:
        strMarkLocations(intMarkLocOrdinal) = strLocDataBuffer
        WritePrivateProfileString "PlayerTracking", "MarkupLoc" & intMarkLocOrdinal, strLocDataBuffer, strIniFileName
    End If
    ReadLocData = True
    
Exit Function
errReadLocData:
    txtCoords(0).Text = "#ERROR#"
    txtCoords(1).Text = "#ERROR#"
    txtCoords(2).Text = "#ERROR#"
    txtCoords(3).Text = "#ERROR#"
    Err.Clear
End Function

Private Function SendCheatCode(ByVal sCheatString As String) As Boolean '
On Error Resume Next
    For intCharCounter = 1 To Len(sCheatString)
        'keybd_event &H10, 0, 0, 0  ' press shift key
        keybd_event Asc(UCase(Mid$(sCheatString, intCharCounter, 1))), 0, 0, 0  ' press key
        Sleep 80
        keybd_event Asc(UCase(Mid$(sCheatString, intCharCounter, 1))), 0, KEYEVENTF_KEYUP, 0 ' release key
        'keybd_event &H10, 0, KEYEVENTF_KEYUP, 0  ' release shift key
        Sleep 60
    Next intCharCounter
    Err.Clear
    
End Function

Private Function MakeSingle(ByVal sValue As String) As Single
On Error Resume Next
    Static sValueC As String
    Static sValueS() As String
    If InStr(sValue, "#") > 0 Then
        MakeSingle = 0
    Else
        sValue = Replace(sValue, ",", ".")
        sValueS = Split(sValue, ".")
        If UBound(sValueS) = 0 Then
            MakeSingle = CSng(sValueS(0))
        Else
            MakeSingle = CSng(sValueS(0)) + (CSng(sValueS(1)) / 10 ^ Len(sValueS(1)))
        End If
    End If
    Err.Clear
End Function

Private Function PasteWarpLoc(ByVal intWapLocOrdinal As Integer, _
                              ByVal strLocDataBuffer As String) As Boolean  '
On Error Resume Next
    Dim lngWarpWriteBuffer As Long
    Dim intWarpWriteBuffer As Integer
    Dim sLocDataArray() As String
    Dim fPlayerAngle As Single
    Dim intOffsetCounter As Integer
    
    If Not ReFillPlayerAdr Then
        If isHasFeedback Then OnScreenText "Cannot Teleport to Location. Current Player location is yet unknown."
        Exit Function
    End If
    PasteWarpLoc = False
    'make player damage-proof prior to teleport:
    SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 6, True
    SetMemFloat GTASAPlayerAddresse.lngMaxHealthAdr, 400
    SetMemFloat GTASAPlayerAddresse.lngHealthAdr, 400
    SetMemFloat GTASABaseAdr.MaxHealthStatAdr, 1000
    'Fill in WarpLoc Values:
    If Len(strLocDataBuffer) = 0 Then strLocDataBuffer = strMarkLocations(intWapLocOrdinal) 'Online
    sLocDataArray = Split(strLocDataBuffer, ";")
    'then, fill with location information:
    If UBound(sLocDataArray) <> 3 Then Exit Function
    GTASAWarpPlayerLoc.sngXcoord = MakeSingle(sLocDataArray(0))
    GTASAWarpPlayerLoc.sngYcoord = MakeSingle(sLocDataArray(1))
    GTASAWarpPlayerLoc.sngZcoord = MakeSingle(sLocDataArray(2))
    fPlayerAngle = MakeSingle(sLocDataArray(3))
    'Check if Player is in Car or not:
    CheckPlayerCarStatus
    If Not isHasCar Then
        'Paste only Player Values and exit:
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngXposAdr, GTASAWarpPlayerLoc, 12, 12&
        SetMemFloat GTASAPlayerAddresse.lngAngleAdr - 4, (fPlayerAngle * mathPI) / 180
        SetMemFloat GTASAPlayerAddresse.lngAngleAdr, (fPlayerAngle * mathPI) / 180
        'Set player Speed to zero:
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, zeroSpeed, 12, 12&
    Else
        'Read Memory to generate Offsets:
        ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, GTASAWarpCarPos, 60&, 0& 'pre-initialise write array
        ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, GTASAWarpCarPosBefore, 60&, 0&
        GTASAWarpCarPosBefore.ZPos = GTASAWarpCarPosBefore.ZPos + 0.5
        'Read also Player positioning to generate offsets:
        ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngXposAdr, GTASAWarpPlayerLocBefore, 12, 12&
        'Fill in Values and write to memory:
        'Normalize Grad values for car:
        fPlayerAngle = fPlayerAngle + 90
        GTASAWarpCarPos.XGrad = GetGrad(fPlayerAngle)
        GTASAWarpCarPos.YGrad = GetGrad(fPlayerAngle - 90) 'Y is immer X-90
        GTASAWarpCarPos.ZGrad = 0
        GTASAWarpCarPos.Reserve1 = GTASAWarpCarPosBefore.Reserve1
        'Normalize Look values for car:
        If ((360 + (fPlayerAngle)) Mod 360) >= 270 Then
            'Normalization of Look to Grad values: Look=Grad-270
            GTASAWarpCarPos.XLook = GetGrad(fPlayerAngle - 270)
            GTASAWarpCarPos.YLook = GetGrad(fPlayerAngle - 270 - 90) ' Y ist immer X-90
        Else
            'Normalization of Look to Grad values: Look=Grad+90
            GTASAWarpCarPos.XLook = GetGrad(fPlayerAngle + 90)
            GTASAWarpCarPos.YLook = GetGrad(fPlayerAngle + 90 - 90) 'Y ist immer X - 90
        End If
        GTASAWarpCarPos.ZLook = 0
        GTASAWarpCarPos.Reserve2 = GTASAWarpCarPosBefore.Reserve2
        GTASAWarpCarPos.XWhat = GTASAWarpCarPosBefore.XWhat
        GTASAWarpCarPos.YWhat = GTASAWarpCarPosBefore.YWhat
        GTASAWarpCarPos.ZWhat = GTASAWarpCarPosBefore.ZWhat
        GTASAWarpCarPos.Reserve3 = GTASAWarpCarPosBefore.Reserve3
        GTASAWarpCarPos.XPos = GTASAWarpCarPosBefore.XPos - GTASAWarpPlayerLocBefore.sngXcoord + GTASAWarpPlayerLoc.sngXcoord
        GTASAWarpCarPos.YPos = GTASAWarpCarPosBefore.YPos - GTASAWarpPlayerLocBefore.sngYcoord + GTASAWarpPlayerLoc.sngYcoord
        GTASAWarpCarPos.ZPos = GTASAWarpCarPosBefore.ZPos - GTASAWarpPlayerLocBefore.sngZcoord + GTASAWarpPlayerLoc.sngZcoord
        GTASAWarpCarPos.ZPos = GTASAWarpCarPos.ZPos + 0.5
        '(use just the differences)
        'get the car type to check which detachables we will warp:
        ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarIDAdr, intCarIDforWarp, 2&, 0&
        'read detachables:
        For intOffsetCounter = 0 To 4 'for bikes
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngBikeDetachPosAdr(intOffsetCounter), GTASAWarpBikeOffset(intOffsetCounter).sngXcoord, 12&, 0& 'bike detachables loc1
        Next intOffsetCounter
        For intOffsetCounter = 0 To 3 'for cars
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarDetachPosAdr(intOffsetCounter), GTASAWarpCarOffset(intOffsetCounter).sngXcoord, 12&, 0& 'car detachables loc1
        Next intOffsetCounter
        'if we will need to warp the trailer as well, read the current car and trailer positions
        'to calculate differences that will be used when teleporting the trailer:
        If tCurrTrailer.isUsable Then
            ReadProcessMemory lngPHandle, tCurrTrailer.lngCarPosAdr, GTASAWarpTrailerPosBefore, 60&, 0&
            GTASAWarpTrailerPosBefore.ZPos = GTASAWarpTrailerPosBefore.ZPos + 0.5
            'calculate differences of GTASAWarpTrailerPosBefore and GTASAWarpCarPosBefore to
            'generate offsets to GTASAWarpCarPos and calculate GTASAWarpTrailerPos:
            'first, copy the GTASAWarpCarPos onto GTASAWarpTrailerPos:
            CopyMemory GTASAWarpTrailerPos, GTASAWarpCarPos, Len(GTASAWarpCarPos)
            'then, assign the new positioning:
            GTASAWarpTrailerPos.XPos = GTASAWarpCarPos.XPos + (GTASAWarpTrailerPosBefore.XPos - GTASAWarpCarPosBefore.XPos)
            GTASAWarpTrailerPos.YPos = GTASAWarpCarPos.YPos + (GTASAWarpTrailerPosBefore.YPos - GTASAWarpCarPosBefore.YPos)
            'also read detachables of the trailer:
            For intOffsetCounter = 0 To 3 'for trailers
                ReadProcessMemory lngPHandle, tCurrTrailer.lngCarDetachPosAdr(intOffsetCounter), GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord, 12&, 0& 'trailer detachables loc1 to locN
            Next intOffsetCounter
        End If
        'now check and compare read offsets (convert offsets to actual offsets, using XLook values and some trigonometry)
        'sorry, no arrays. There is a problem with array read...
        'also decide if this car is a bike or not (bikes have a different set of detachables, ie. Offset0 to Offset3)
        If ParkedCars(intCarIDforWarp).isBike Then
            'normalize bike offsets:
            For intOffsetCounter = 0 To 4
                'find differences:
                GTASAWarpBikeOffset(intOffsetCounter).sngXcoord = GTASAWarpCarPosBefore.XPos - GTASAWarpBikeOffset(intOffsetCounter).sngXcoord
                GTASAWarpBikeOffset(intOffsetCounter).sngYcoord = GTASAWarpCarPosBefore.YPos - GTASAWarpBikeOffset(intOffsetCounter).sngYcoord
                GTASAWarpBikeOffset(intOffsetCounter).sngZcoord = GTASAWarpCarPosBefore.ZPos - GTASAWarpBikeOffset(intOffsetCounter).sngZcoord
                'normalize differences:
                '! to be coded if needed. Normalisation is needed if we are also turning the bike (ie. recalculate new positions with new coords after turning)
                'write back as absolute:
                GTASAWarpBikeOffset(intOffsetCounter).sngXcoord = GTASAWarpBikeOffset(intOffsetCounter).sngXcoord + GTASAWarpCarPos.XPos
                GTASAWarpBikeOffset(intOffsetCounter).sngYcoord = GTASAWarpBikeOffset(intOffsetCounter).sngYcoord + GTASAWarpCarPos.YPos
                GTASAWarpBikeOffset(intOffsetCounter).sngZcoord = GTASAWarpBikeOffset(intOffsetCounter).sngZcoord + GTASAWarpCarPos.ZPos
            Next intOffsetCounter
        Else
            'normalize car offsets:
            For intOffsetCounter = 0 To 3
                'find differences:
                GTASAWarpCarOffset(intOffsetCounter).sngXcoord = GTASAWarpCarPosBefore.XPos - GTASAWarpCarOffset(intOffsetCounter).sngXcoord
                GTASAWarpCarOffset(intOffsetCounter).sngYcoord = GTASAWarpCarPosBefore.YPos - GTASAWarpCarOffset(intOffsetCounter).sngYcoord
                GTASAWarpCarOffset(intOffsetCounter).sngZcoord = GTASAWarpCarPosBefore.ZPos - GTASAWarpCarOffset(intOffsetCounter).sngZcoord
                'normalize differences:
                '! to be coded if needed. Normalisation is needed if we are also turning the car (ie. recalculate new positions with new coords after turning)
                'write back as absolute:
                GTASAWarpCarOffset(intOffsetCounter).sngXcoord = GTASAWarpCarOffset(intOffsetCounter).sngXcoord + GTASAWarpCarPos.XPos
                GTASAWarpCarOffset(intOffsetCounter).sngYcoord = GTASAWarpCarOffset(intOffsetCounter).sngYcoord + GTASAWarpCarPos.YPos
                GTASAWarpCarOffset(intOffsetCounter).sngZcoord = GTASAWarpCarOffset(intOffsetCounter).sngZcoord + GTASAWarpCarPos.ZPos
                'also normalize trailer if car has trailer:
                If tCurrTrailer.isUsable Then
                    'find differences:
                    GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord = GTASAWarpTrailerPosBefore.XPos - GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord
                    GTASAWarpTrailerOffset(intOffsetCounter).sngYcoord = GTASAWarpTrailerPosBefore.YPos - GTASAWarpTrailerOffset(intOffsetCounter).sngYcoord
                    GTASAWarpTrailerOffset(intOffsetCounter).sngZcoord = GTASAWarpTrailerPosBefore.ZPos - GTASAWarpTrailerOffset(intOffsetCounter).sngZcoord
                    'normalize differences:
                    '! to be coded if needed. Normalisation is needed if we are also turning the Trailer (ie. recalculate new positions with new coords after turning)
                    'write back as absolute:
                    GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord = GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord + GTASAWarpTrailerPos.XPos
                    GTASAWarpTrailerOffset(intOffsetCounter).sngYcoord = GTASAWarpTrailerOffset(intOffsetCounter).sngYcoord + GTASAWarpTrailerPos.YPos
                    GTASAWarpTrailerOffset(intOffsetCounter).sngZcoord = GTASAWarpTrailerOffset(intOffsetCounter).sngZcoord + GTASAWarpTrailerPos.ZPos
                End If
            Next intOffsetCounter
        End If
        'Write Player Locations, if not warping a rc car:
        If tCurrCarAdr.isUsable And tCurrCarAdr.isRCCar Then
            'no player warping for rc cars...
        Else
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngXposAdr, GTASAWarpPlayerLoc, 12, 12&
            fPlayerAngle = fPlayerAngle - 90
            SetMemFloat GTASAPlayerAddresse.lngAngleAdr - 4, (fPlayerAngle * mathPI) / 180
            SetMemFloat GTASAPlayerAddresse.lngAngleAdr, (fPlayerAngle * mathPI) / 180
        End If
        'Car Pos Data:
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, GTASAWarpCarPos, 60, 60&
        '!Speed/Spin values will not be saved, they will be set to zero during paste
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, zeroSpeed, 12&, 12&
        WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, zeroSpin, 12&, 12&
        'write trailer pos data if needed:
        If tCurrTrailer.isUsable Then
            WriteProcessMemory lngPHandle, tCurrTrailer.lngCarPosAdr, GTASAWarpTrailerPos, 60, 60&
            '!Speed/Spin values will not be saved, they will be set to zero during paste
            WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, zeroSpeed, 12&, 12&
            WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, zeroSpin, 12&, 12&
        End If
        'Detachables:
        If ParkedCars(intCarIDforWarp).isBike Then
            'write bike detachables (bikes have no trailers):
            For intOffsetCounter = 0 To 4
                WriteProcessMemory lngPHandle, tCurrCarAdr.lngBikeDetachPosAdr(intOffsetCounter), GTASAWarpBikeOffset(intOffsetCounter).sngXcoord, 12&, 4&
            Next intOffsetCounter
        Else
            'write car offsets:
            For intOffsetCounter = 0 To 3
                WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarDetachPosAdr(intOffsetCounter), GTASAWarpCarOffset(intOffsetCounter).sngXcoord, 12&, 12&
                If tCurrTrailer.isUsable Then
                    WriteProcessMemory lngPHandle, tCurrTrailer.lngCarDetachPosAdr(intOffsetCounter), GTASAWarpTrailerOffset(intOffsetCounter).sngXcoord, 12&, 12&
                End If
            Next intOffsetCounter
        End If
    End If
    PasteWarpLoc = True
    Err.Clear
    
End Function

Private Function BringCar(ByRef tCarToBring As GTASACarAdr, ByVal isMeToCar As Boolean) As Boolean '
On Error Resume Next
    Dim lngTrailerPtr As Long
    Dim iCarTypeToBring As Integer
    Dim tTrailerToBring As GTASACarAdr
    If Not ReFillPlayerAdr Then Exit Function
    'Get Player WarpPosData:
    ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, WarpPlayerExecBuffer, 60, 0&
    'Get Car WarpPosData
    ReadProcessMemory lngPHandle, tCarToBring.lngCarPosAdr, WarpCarExecBuffer, 60, 0&
    If isMeToCar Then
        'Case 111 'Page: 17    Take me to my last car (only if on Foot)
        'Level Player Positioning Data to Car Pos Data:
        WarpPlayerExecBuffer.XGrad = WarpCarExecBuffer.XGrad
        WarpPlayerExecBuffer.YGrad = WarpCarExecBuffer.YGrad
        'No Normalization of player to car, because you cant easily turn player
        WarpPlayerExecBuffer.ZGrad = 0
        'Warp me to car + 1:
        WarpPlayerExecBuffer.XPos = WarpCarExecBuffer.XPos - (2 * (WarpCarExecBuffer.YLook))
        WarpPlayerExecBuffer.YPos = WarpCarExecBuffer.YPos + (2 * (WarpCarExecBuffer.XLook))
        WarpPlayerExecBuffer.ZPos = WarpCarExecBuffer.ZPos ' + 0.15
        'Write new pos data:
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, WarpPlayerExecBuffer, 60, 60&
        'Set player Speed to zero:
        WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, zeroSpeed, 12, 12&
    Else
        'check if car has a trailer:
        ReadProcessMemory lngPHandle, tCarToBring.lngCarTrailerAdr, lngTrailerPtr, 4, 0&
        If lngTrailerPtr <> 0 Then
            If SetCarAdrEx(tTrailerToBring, lngTrailerPtr) Then
                tTrailerToBring.isUsable = True
                'Get trailer WarpPosData:
                ReadProcessMemory lngPHandle, tTrailerToBring.lngCarPosAdr, WarpTrailerExecBuffer, 60, 0&
                'find differences of car pos and trailer pos:
                GTASAWarpTrailerPosOffset.sngXcoord = WarpCarExecBuffer.XPos - WarpTrailerExecBuffer.XPos
                GTASAWarpTrailerPosOffset.sngYcoord = WarpCarExecBuffer.YPos - WarpTrailerExecBuffer.YPos
                GTASAWarpTrailerPosOffset.sngZcoord = WarpCarExecBuffer.ZPos - WarpTrailerExecBuffer.ZPos
            Else
                tTrailerToBring.isUsable = False
            End If
        End If
        'Case 112 'Page: 17    Bring my last/previous car to me (only if on Foot)
        'Level Car Positioning Data to Player Pos Data:
        WarpCarExecBuffer.XGrad = WarpPlayerExecBuffer.XGrad
        WarpCarExecBuffer.YGrad = WarpPlayerExecBuffer.YGrad
        'Normalize car to player:
        sngAbsoluteDegrees = GetAbsoluteDegrees(WarpCarExecBuffer.XGrad, WarpCarExecBuffer.YGrad)
        sngAbsoluteDegrees = sngAbsoluteDegrees + 90 'turn 90°
        'Normalize Grad values:
        WarpCarExecBuffer.XGrad = GetGrad(sngAbsoluteDegrees)
        WarpCarExecBuffer.YGrad = GetGrad(sngAbsoluteDegrees - 90) 'Y is immer X-90
        WarpCarExecBuffer.ZGrad = 0
        'Normalize Look values:
        If ((360 + (sngAbsoluteDegrees)) Mod 360) >= 270 Then
            'Normalization of Look to Grad values: Look=Grad-270
            WarpCarExecBuffer.XLook = GetGrad(sngAbsoluteDegrees - 270)
            WarpCarExecBuffer.YLook = GetGrad(sngAbsoluteDegrees - 270 - 90) ' Y ist immer X-90
        Else
            'Normalization of Look to Grad values: Look=Grad+90
            WarpCarExecBuffer.XLook = GetGrad(sngAbsoluteDegrees + 90)
            WarpCarExecBuffer.YLook = GetGrad(sngAbsoluteDegrees + 90 - 90) 'Y ist immer X - 90
        End If
'        WarpCarExecBuffer.ZLook = 0
'        WarpCarExecBuffer.XWhat = 0
'        WarpCarExecBuffer.YWhat = 0
'        WarpCarExecBuffer.ZWhat = 1
        'Warp Car to Me + 1:
        WarpCarExecBuffer.XPos = WarpPlayerExecBuffer.XPos + (2 * (WarpCarExecBuffer.YLook))
        WarpCarExecBuffer.YPos = WarpPlayerExecBuffer.YPos - (2 * (WarpCarExecBuffer.XLook))
        'check the height of the vehicle, and normalize ZPos, also add 0.15 for smooth placing:
        ReadProcessMemory lngPHandle, tCarToBring.lngCarIDAdr, iCarTypeToBring, 2&, 0&
        If ParkedCars(iCarTypeToBring).strCarType = "plane" Or ParkedCars(iCarTypeToBring).strCarType = "mtruck" Then
            WarpCarExecBuffer.ZPos = WarpPlayerExecBuffer.ZPos + 0.35
        Else
            WarpCarExecBuffer.ZPos = WarpPlayerExecBuffer.ZPos + 0.15
        End If
        If tTrailerToBring.isUsable Then
            'warp trailer to Me+1 (using the offsets that we have already saved):
            CopyMemory WarpTrailerExecBuffer, WarpCarExecBuffer, Len(WarpCarExecBuffer)
            WarpTrailerExecBuffer.XPos = WarpCarExecBuffer.XPos - GTASAWarpTrailerPosOffset.sngXcoord
            WarpTrailerExecBuffer.YPos = WarpCarExecBuffer.YPos - GTASAWarpTrailerPosOffset.sngYcoord
            WarpTrailerExecBuffer.ZPos = WarpCarExecBuffer.ZPos - GTASAWarpTrailerPosOffset.sngZcoord
        End If
        'Stop X and Y speeds, and Give some Z speed to the car:
        speedExecWriteBuffer.sngXSpeed = 0
        speedExecWriteBuffer.sngYSpeed = 0
        speedExecWriteBuffer.sngZSpeed = -0.05
        'Write new pos data for car:
        WriteProcessMemory lngPHandle, tCarToBring.lngCarPosAdr, WarpCarExecBuffer, 60&, 60&
        If tTrailerToBring.isUsable Then WriteProcessMemory lngPHandle, tTrailerToBring.lngCarPosAdr, WarpTrailerExecBuffer, 60&, 60&            'Write new pos data for trailer
        'Stop spin of the car:
        WriteProcessMemory lngPHandle, tCarToBring.lngCarSpinAdr, zeroSpin, 12&, 12&
        If tTrailerToBring.isUsable Then WriteProcessMemory lngPHandle, tTrailerToBring.lngCarSpinAdr, zeroSpin, 12&, 12&  'Stop spin of the trailer
        'write speed of the car:
        WriteProcessMemory lngPHandle, tCarToBring.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
        If tTrailerToBring.isUsable Then WriteProcessMemory lngPHandle, tTrailerToBring.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&  'write speed of the trailer
    End If
    Err.Clear
End Function

Private Function ExecuteConsoleCommand(ByVal intCommandOrdinal As Integer, ByVal strExecData As String) As Boolean                                        '
On Error Resume Next
    Static iTvCtr As Long
    isInternalClick = True
    Select Case intCommandOrdinal
        Case 0  'Page:  0     Set Armor Level to:
            sngLockArmorTo = CSng(strExecData)
            If ReFillPlayerAdr Then SetMemFloat GTASAPlayerAddresse.lngArmorAdr, sngLockArmorTo
        Case 1  'Page:  0     Auto-Fix Armor Level to:
            isLockArmor = True
            sngLockArmorTo = CSng(strExecData)
            If ReFillPlayerAdr Then
                SetMemFloat GTASAPlayerAddresse.lngArmorAdr, sngLockArmorTo
                strOnScreenText = strOnScreenText & "; " & IIf(isLockArmor, "Armor level locked to: " & Format$(sngLockArmorTo), "Armor Level Lock released")
            Else
                strOnScreenText = strOnScreenText & "; Player N/A"
            End If
        Case 2  'Page:  16    Auto-Fix Armor:
            isLockArmor = (strExecData = "1")
            strOnScreenText = strOnScreenText & "; " & IIf(isLockArmor, "Armor level locked to: " & Format$(sngLockArmorTo), "Armor Level Lock released")
        
        Case 3  'Page:  1     Set Health Level to:
            sngLockHealthTo = CSng(strExecData)
            If ReFillPlayerAdr Then
                SetMemFloat GTASAPlayerAddresse.lngMaxHealthAdr, sngLockHealthTo
                SetMemFloat GTASAPlayerAddresse.lngHealthAdr, sngLockHealthTo
                SetMemFloat GTASABaseAdr.MaxHealthStatAdr, 1000
            Else
                strOnScreenText = strOnScreenText & "; Player N/A"
            End If
        Case 4  'Page:  1     Auto-Fix Health Level to:
            isLockHealth = True
            sngLockHealthTo = CSng(strExecData)
            If ReFillPlayerAdr Then
                SetMemFloat GTASAPlayerAddresse.lngMaxHealthAdr, sngLockHealthTo
                SetMemFloat GTASAPlayerAddresse.lngHealthAdr, sngLockHealthTo
                SetMemFloat GTASABaseAdr.MaxHealthStatAdr, 1000
                strOnScreenText = strOnScreenText & "; " & IIf(isLockHealth, "Health level locked to: " & Format$(sngLockHealthTo), "Health Level Lock released")
            Else
                strOnScreenText = strOnScreenText & "; Player N/A"
            End If
        Case 5  'Page:  16    Auto-Fix Health:
            isLockHealth = (strExecData = "1")
            strOnScreenText = strOnScreenText & "; " & IIf(isLockHealth, "Health level locked to: " & Format$(sngLockHealthTo), "Health Level Lock released")
       
        Case 6 'Page:  5     Set Car Specialities to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then
                    strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                End If
                GoTo FunctionExit
            End If
            'ExecData: EP;DP;BP;FP
            For intExecCounter = 0 To 3
                chkCarSpecs(intExecCounter).Value = CInt(GetToken(strExecData, intExecCounter + 1, ";"))
            Next intExecCounter
            strBuffer = ""
            If chkCarSpecs(0).Value = 1 Then strBuffer = strBuffer & "+EP"
            If chkCarSpecs(1).Value = 1 Then strBuffer = strBuffer & "+DP"
            If chkCarSpecs(2).Value = 1 Then strBuffer = strBuffer & "+BP"
            If chkCarSpecs(3).Value = 1 Then strBuffer = strBuffer & "+FP"
            If Len(strBuffer) = 0 Then
                strBuffer = "None"
            Else
                strBuffer = Mid$(strBuffer, 2)
            End If
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked) 'EP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked) 'DP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked) 'BP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked) 'FP
            If tCurrTrailer.isUsable Then
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked)
            End If
            strOnScreenText = strOnScreenText & "; " & "Car Specs. set to: " & strBuffer
        Case 7 'Page:  16    Auto-Fix Car Specialities:
            chkCarDynamics(0).Value = CInt(strExecData)
        Case 8 'Page:  6     Set Car Doors to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            'ExecData: 1:Open 0:Locked
            If strExecData = "0" Then
                optCarDoors(0).Value = False ' Open
                optCarDoors(1).Value = True ' Open
                isAutoLockCarDoors = False
            Else
                optCarDoors(0).Value = True ' locked
                optCarDoors(1).Value = False ' locked
                If (chkCarDynamics(1).Value = 1) Then
                    isAutoLockCarDoors = True
                Else
                    isAutoLockCarDoors = False
                End If
            End If
            SetMemByte tCurrCarAdr.lngCarDoorAdr, 2 - CInt(strExecData)
            strOnScreenText = strOnScreenText & "; " & "Car Doors are " & IIf(strExecData = "1", "open", "locked")
        Case 9 'Page:  16    Auto-Lock Car Doors:
            If strExecData = "1" Then
                'autolock car doors:
                chkCarDynamics(1).Value = 1
                optCarDoors(0).Value = True ' locked
                optCarDoors(1).Value = False ' locked
                isAutoLockCarDoors = True
            Else
                'release autolock:
                chkCarDynamics(1).Value = 0
                isAutoLockCarDoors = False
            End If
            strOnScreenText = strOnScreenText & "; " & IIf(isAutoLockCarDoors, "Cardoors Autolock activated", "Cardoors Autolock deactivated")
        
        Case 10 'Page:  16     Prevent Wheel Damage:
            chkCarDynamics(2).Value = vbChecked
        
        Case 11 'Page:  8     Set Engine Health To:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then
                    strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                End If
                GoTo FunctionExit
            End If
            'Car Damage Tolerance left
            SetMemFloat tCurrCarAdr.lngCarDamageAdr, strExecData   '(if set to 255, also tyres explode)
            If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarDamageAdr, strExecData  '(if set to 255, also tyres explode)
            strOnScreenText = strOnScreenText & "; " & "Engine Health Set to: " & Format$(CInt(strExecData) \ 10) & "%"
        Case 12 'Page:  16    Auto-Fix Engine Damage:
            isLockEngineHealth = (strExecData = "1")
            strOnScreenText = strOnScreenText & "; " & IIf(isLockEngineHealth, "Engine health Locked to: " & Format$(sngLockEngineHealthTo \ 10) & "%", "Engine health Lock released")
        
        Case 13 'Page:  9     Set Car Weight to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            scrCarDynamics(1).Value = CInt(strExecData)
            SetCarWeight 'Change Car weight as needed
            strOnScreenText = strOnScreenText & "; " & "Car Weight Set to: " & Format$(scrCarDynamics(1).Value / 10, "0.0") & " Tons"
        Case 14 'Page:  16    Auto-Fix Car Weight:
            chkCarDynamics(4).Value = CInt(strExecData)
            strOnScreenText = strOnScreenText & "; " & IIf(chkCarDynamics(4).Value, "Car Weight Locked to: " & Format$(scrCarDynamics(1).Value / 10, "0.0") & " Tons", "Car Weight Lock released")
        Case 15 'Page:  10    Paint My Car To:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            picMajor.Tag = GetToken(strExecData, 1, ";")
            picMajor.BackColor = GTASAColors(CInt(picMajor.Tag)).lngRGB
            chkMajorLock.Value = CInt(GetToken(strExecData, 2, ";"))
            picMinor.Tag = GetToken(strExecData, 3, ";")
            picMinor.BackColor = GTASAColors(CInt(picMinor.Tag)).lngRGB
            chkMajorLock.Value = CInt(GetToken(strExecData, 4, ";"))
            SetMemByte tCurrCarAdr.lngCarColorAdr, picMajor.Tag
            SetMemByte tCurrCarAdr.lngCarColorAdr + 1, picMinor.Tag
        Case 16 'Page:  16    Auto-Paint My Car:
            chkCarDynamics(5).Value = CInt(strExecData)
        Case 17 'Page:  16    Stop Car Alarm:
            chkCarDynamics(6).Value = CInt(strExecData)
        Case 18 'Page:  11    Set Car Direction to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then
                    strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                End If
                GoTo FunctionExit
            End If
            oCarDirection.Direction = CInt(GetToken(strExecData, 1, ";"))
            'Raise Car about 50 cm:
            SetMemFloat tCurrCarAdr.lngCarLocAdr + 8, GetMemFloat(tCurrCarAdr.lngCarLocAdr + 8) + 0.05
            'Set Car Position:
            carFlipPlacement = GTASACarPlacements(oCarDirection.Direction)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 28&
        Case 19 'Page:  11    KickStart Car to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            oCarStart.Direction = CInt(GetToken(strExecData, 1, ";"))
            oCarStart.ScrollerVal = 0 - CInt(GetToken(strExecData, 2, ";"))
            'Raise Car about 50 cm:
            SetMemFloat tCurrCarAdr.lngCarLocAdr + 8, GetMemFloat(tCurrCarAdr.lngCarLocAdr + 8) + 0.05
            'Set Car Position:
            carFlipPlacement = GTASACarPlacements(oCarStart.Direction)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 28&
            'KickStart (Set Speed/Spin Data):
            speedExecWriteBuffer.sngXSpeed = KickStartSpeeds(oCarStart.Direction).sngXSpeed * Abs(oCarStart.ScrollerVal) / 500
            speedExecWriteBuffer.sngYSpeed = KickStartSpeeds(oCarStart.Direction).sngYSpeed * Abs(oCarStart.ScrollerVal) / 500
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
        
        Case 20 'Page:  17    Flip Car Back on 4 Wheels
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            Call cmdFlipCar_Click
        Case 21, 22, 23 '21 'Page:  17    Stop X Speed'22 'Page:  17    Stop Y Speed'23 'Page:  17    Stop Z Speed
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr + ((intCommandOrdinal - 21) * 4), 0, 4&, 4&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr + ((intCommandOrdinal - 21) * 4), 0, 4&, 4&
        Case 24 'Page:  17    Stop All Speed
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, zeroSpeed, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, zeroSpeed, 12&, 12&
        Case 25, 26, 27 '25 'Page:  17    Stop X Spin'26 'Page:  17    Stop Y Spin'27 'Page:  17    Stop Z Spin
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 25) * 4), 0, 4&, 4&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpinAdr + ((intCommandOrdinal - 25) * 4), 0, 4&, 4&
        Case 28 'Page:  17    Stop All Spin
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr, zeroSpin, 12&, 12&
        Case 29 'Page:  17    Stop All (Freeze Car)
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, zeroSpeed, 12&, 12&
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr, zeroSpin, 12&, 12&
            If tCurrTrailer.isUsable Then
                WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, zeroSpeed, 12&, 12&
                WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpinAdr, zeroSpin, 12&, 12&
            End If
        Case 30, 31, 32 '30 'Page:  13    Set X Speed to:'31 'Page:  13    Set Y Speed to:'32 'Page:  13    Set Z Speed to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            'read car speed
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 0&
            If intCommandOrdinal = 30 Then
                'set X speed
                speedExecWriteBuffer.sngXSpeed = CInt(strExecData) / 500
                'write car speed
                WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
                If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
            ElseIf intCommandOrdinal = 31 Then
                'set y speed:
                speedExecWriteBuffer.sngYSpeed = CInt(strExecData) / 500
                'write car speed
                WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
                If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
            Else 'intCommandOrdinal = 32 Then
                'set Z speed
                speedExecWriteBuffer.sngZSpeed = CInt(strExecData) / 500
                'write car speed
                WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
                If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
                intFallSeconds = 2
            End If
        Case 33, 34, 35 '33 'Page:  13    Set X Spin to: '34 'Page:  13    Set Y Spin to: '35 'Page:  13    Set Z Spin to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            SetMemFloat tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 33) * 4), CSng(strExecData) / 500
            intSpinSeconds = 2
        Case 36, 37, 38 '36 'Page:  13    Increase X Speed by: '37 'Page:  13    Increase Y Speed by: '38 'Page:  13    Increase Z Speed by:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            sngExecWriteBuffer = GetMemFloat(tCurrCarAdr.lngCarSpeedAdr + ((intCommandOrdinal - 36) * 4)) + (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr + ((intCommandOrdinal - 36) * 4), sngExecWriteBuffer, 4&, 4&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr + ((intCommandOrdinal - 36) * 4), sngExecWriteBuffer, 4&, 4&
        Case 39, 40, 41 '39 'Page:  13    Decrease X Speed by: '40 'Page:  13    Decrease Y Speed by: '41 'Page:  13    Decrease Z Speed by:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            sngExecWriteBuffer = GetMemFloat(tCurrCarAdr.lngCarSpeedAdr + ((intCommandOrdinal - 39) * 4)) - (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr + ((intCommandOrdinal - 39) * 4), sngExecWriteBuffer, 4&, 4&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr + ((intCommandOrdinal - 39) * 4), sngExecWriteBuffer, 4&, 4&
            intFallSeconds = 2
        Case 42, 43, 44 '42 'Page:  13    Increase X Spin by: '43 'Page:  13    Increase Y Spin by: '44 'Page:  13    Increase Z Spin by:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            sngExecWriteBuffer = GetMemFloat(tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 42) * 4)) + (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 42) * 4), sngExecWriteBuffer, 4&, 4&
            intSpinSeconds = 2
        Case 45, 46, 47 '45 'Page:  13    Decrease X Spin by: '46 'Page:  13    Decrease Y Spin by: '47 'Page:  13    Decrease Z Spin by:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            sngExecWriteBuffer = GetMemFloat(tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 45) * 4)) - (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr + ((intCommandOrdinal - 45) * 4), sngExecWriteBuffer, 4&, 4&
            intSpinSeconds = 2
        Case 48, 49, 50 'Set Clock Speed to:, Page 14: / 'Increase Clock Speed / 'Decrease Clock Speed
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If intCommandOrdinal = 48 Then
                    scrGameSpeed(0).Value = CInt(strExecData) 'for 48, strExecData is new scrGameSpeedMsToSecs
                ElseIf (intCommandOrdinal = 49) And (scrGameSpeed(0).Value < scrGameSpeed(0).max) Then
                    scrGameSpeed(0).Value = scrGameSpeed(0).Value + 1 'increase
                ElseIf (intCommandOrdinal = 50) And (scrGameSpeed(0).Value > scrGameSpeed(0).min) Then
                    scrGameSpeed(0).Value = scrGameSpeed(0).Value - 1 'decrease
                End If
                If scrGameSpeed(0).Value = 0 Then
                    SetMemLong GTASABaseAdr.GameSpeedMsAdr, 1000
                ElseIf scrGameSpeed(0).Value = -92 Then 'clock is frozen
                    SetMemLong GTASABaseAdr.GameSpeedMsAdr, 3600000
                ElseIf scrGameSpeed(0).Value = -91 Then 'clock is real-time
                    SetMemLong GTASABaseAdr.GameSpeedMsAdr, 60000
                ElseIf scrGameSpeed(0).Value < 0 Then
                    SetMemLong GTASABaseAdr.GameSpeedMsAdr, CLng(100000 / (100& + scrGameSpeed(0).Value))
                Else
                    SetMemLong GTASABaseAdr.GameSpeedMsAdr, CLng(100000 / (100& + (10& * scrGameSpeed(0).Value)))
                End If
                If scrGameSpeed(0).Value = -92 Then
                    strOnScreenText = strOnScreenText & "; Game Clock is frozen"
                ElseIf scrGameSpeed(0).Value = -91 Then
                    strOnScreenText = strOnScreenText & "; Game Clock is real-time"
                ElseIf scrGameSpeed(0).Value < 0 Then
                    strOnScreenText = strOnScreenText & "; " & "Clock Speed set to: " & (100 + scrGameSpeed(0).Value) & " %"
                Else
                    strOnScreenText = strOnScreenText & "; " & "Clock Speed set to: " & (100 + (scrGameSpeed(0).Value * 10)) & " %"
                End If
            End If
        Case 51 'Clear cheated status and count
            SetMemLong GTASABaseAdr.CheatCountAdr, 0&
            SetMemLong GTASABaseAdr.CheatStatAdr, 0&
            strOnScreenText = strOnScreenText & "; " & "Cheated Status and Count cleared."
        Case 52 'Set Clock Speed to Real Time
            scrGameSpeed(0).Value = -91
            SetMemLong GTASABaseAdr.GameSpeedMsAdr, 60000
            strOnScreenText = strOnScreenText & "; Game Clock is Real-time"
        Case 53 'Set Clock Speed to Normal Game Time
            scrGameSpeed(0).Value = 0
            SetMemLong GTASABaseAdr.GameSpeedMsAdr, 1000
            strOnScreenText = strOnScreenText & "; Game Clock is Normal Game-time"
        Case 54 'Page:  13   Set Car Speed to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            sngExecWriteBuffer = CSng(strExecData) / 500
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 0&
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 0&
            speedExecWriteBuffer.sngXSpeed = carFlipPlacement.sngXlooking * sngExecWriteBuffer
            speedExecWriteBuffer.sngYSpeed = carFlipPlacement.sngYlooking * sngExecWriteBuffer
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
        Case 55 'Page:  13   Increase Car Speed by:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpinAdr, zeroSpin, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpinAdr, zeroSpin, 12&, 12&
            sngExecWriteBuffer = CSng(strExecData) / 500
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarPosAdr, carFlipPlacement, 28&, 0&
            ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 0&
            'Normalize Speed:
            speedExecWriteBuffer.sngXSpeed = (Abs(speedExecWriteBuffer.sngXSpeed) + Abs(speedExecWriteBuffer.sngYSpeed)) * (carFlipPlacement.sngXlooking / (Abs(carFlipPlacement.sngXlooking) + Abs(carFlipPlacement.sngYlooking)))
            speedExecWriteBuffer.sngYSpeed = (Abs(speedExecWriteBuffer.sngXSpeed) + Abs(speedExecWriteBuffer.sngYSpeed)) * (carFlipPlacement.sngYlooking / (Abs(carFlipPlacement.sngXlooking) + Abs(carFlipPlacement.sngYlooking)))
            'Increase speed:
            speedExecWriteBuffer.sngXSpeed = speedExecWriteBuffer.sngXSpeed + (carFlipPlacement.sngXlooking * sngExecWriteBuffer)
            speedExecWriteBuffer.sngYSpeed = speedExecWriteBuffer.sngYSpeed + (carFlipPlacement.sngYlooking * sngExecWriteBuffer)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
            If tCurrTrailer.isUsable Then WriteProcessMemory lngPHandle, tCurrTrailer.lngCarSpeedAdr, speedExecWriteBuffer, 12&, 12&
        Case 56 'Page:  16   Flight Asistance: (ON/OFF)
            isFlightAssistance = (strExecData = "1")
            chkCarDynamics(8).Value = CInt(strExecData)
            WritePrivateProfileString "CarTracking", "FlightAssist", Format$(chkCarDynamics(8).Value) & "," & Format$(scrCarDynamics(8).Value), strIniFileName
            strOnScreenText = strOnScreenText & "; " & "Flight Assistance " & IIf(isFlightAssistance, "activated", "deactivated")
        Case 57 'Page: 8    Flight Assistance Level: (0-100%)
            sngAssistFlightBy = CSng(strExecData) * 0.002
            scrCarDynamics(8).Value = CInt(strExecData)
            chkCarDynamics(8).Caption = "Flight Assistance (" & scrCarDynamics(8).Value / 10 & "%)"
            WritePrivateProfileString "CarTracking", "FlightAssist", Format$(chkCarDynamics(8).Value) & "," & Format$(scrCarDynamics(8).Value), strIniFileName
            strOnScreenText = strOnScreenText & "; " & "Flight Assistance Level set to: " & Format$(scrCarDynamics(8).Value / 10) & " %"
        Case 59 'Page:  16   Silent Mode: (ON/OFF)
            isHasFeedback = (strExecData = "1")
            chkFeedback.Value = CInt(strExecData)
            strOnScreenText = strOnScreenText & "; " & "On Screen Feedback " & IIf(isHasFeedback, "activated", "deactivated")
        Case 60 'Page: 17    Stop Car Alarm
            If Not isHasCar Then
                If InStr(strOnScreenText, "You are not in a car") = 0 Then strOnScreenText = strOnScreenText & "; You are not in a car"
                GoTo FunctionExit
            End If
            'Stop CarAlarm (set siren time left to 0)
            WriteProcessMemory lngPHandle, tCurrCarAdr.lngSirenTimeAdr, 0&, 4&, 4&
        Case 61 'Page: 17    Take me to my last car (only if on Foot)
            If isHasCar Then
                If InStr(strOnScreenText, "This function is available only when player is on foot") = 0 Then strOnScreenText = strOnScreenText & "; This function is available only when player is on foot"
                GoTo FunctionExit
            End If
            If CheckCarIsUsable(tCurrCarAdr) Then
                BringCar tCurrCarAdr, True
            Else
                strOnScreenText = strOnScreenText & "; Last car is not available any more."
            End If
        Case 62 'Page: 17    Bring my last car to me (only if on Foot)
            If isHasCar Then
                If InStr(strOnScreenText, "This function is available only when player is on foot") = 0 Then strOnScreenText = strOnScreenText & "; This function is available only when player is on foot"
                GoTo FunctionExit
            End If
            If CheckCarIsUsable(tCurrCarAdr) Then
                BringCar tCurrCarAdr, False
            Else
                strOnScreenText = strOnScreenText & "; Last car is not available any more."
            End If
        Case 63 'Page: 18    Remember my location as Markup Location
            ReadLocData CInt(strExecData)
            strOnScreenText = strOnScreenText & "; " & "Markup Location: " & strExecData & " set"
        Case 64 'Page: 18    Take me to Markup Location
            If Not PasteWarpLoc(CInt(strExecData), "") Then
                'Do it twice for better results
                If Not PasteWarpLoc(CInt(strExecData), "") Then
                    strOnScreenText = strOnScreenText & "; " & "Cannot teleport to Markup Location: " & strExecData
                End If
            End If
        Case 65 'Page: 17    Take me to my previous car (only if on Foot)
            If isHasCar Then
                If InStr(strOnScreenText, "This function is available only when player is on foot") = 0 Then strOnScreenText = strOnScreenText & "; This function is available only when player is on foot"
                GoTo FunctionExit
            End If
            If CheckCarIsUsable(tOldCarAdr) Then
                BringCar tOldCarAdr, True
            Else
                strOnScreenText = strOnScreenText & "; Previous car is not available any more."
            End If
        Case 66 'Page: 17    Bring my previous car to me (only if on Foot)
            If isHasCar Then
                If InStr(strOnScreenText, "This function is available only when player is on foot") = 0 Then strOnScreenText = strOnScreenText & "; This function is available only when player is on foot"
                GoTo FunctionExit
            End If
            If CheckCarIsUsable(tOldCarAdr) Then
                BringCar tOldCarAdr, False
            Else
                strOnScreenText = strOnScreenText & "; Previous car is not available any more."
            End If
        Case 67 'Page: 6    Set Doors of my Preivous Car to:
            If Not (isHasCar Or isHadCar) Then
                If InStr(strOnScreenText, "No cars have been synchronized") = 0 Then strOnScreenText = strOnScreenText & "; No cars have been synchronized"
                GoTo FunctionExit
            End If
            'ExecData: 1:Open 0:Locked
            SetMemByte tOldCarAdr.lngCarDoorAdr, 2 - CInt(strExecData)
            strOnScreenText = strOnScreenText & "; " & "Doors of previous car are " & IIf(strExecData = "1", "open", "locked")
        Case 68 'Page: 19   Turn My Car in Clock Direction by:"  ' 0-180 Degrees
            TurnCar tCurrCarAdr, CInt(strExecData), 2 '0:X /1:Y /2:Z
        Case 69 'Page: 19   Turn My Car in Counterclock Direction by:"  ' 0-180 Degrees
            TurnCar tCurrCarAdr, 0 - CInt(strExecData), 2 '0:X /1:Y /2:Z
        Case 70 'Page: 17   Torch my (last) car
            If CheckCarIsUsable(tCurrCarAdr) Then
                'Set Car Left Damage Tolerance to 5: (Max is 1000)
                SetMemFloat tCurrCarAdr.lngCarDamageAdr, 5
                If tCurrTrailer.isUsable Then SetMemFloat tCurrTrailer.lngCarDamageAdr, 5
                strOnScreenText = strOnScreenText & "; " & "Last car is torched"
            Else
                strOnScreenText = strOnScreenText & "; " & "Last car is not available any more."
            End If
        Case 71 'Page: 17   Torch my previous car
            'Set Car Left Damage Tolerance to 5:  (Max is 1000)
            If CheckCarIsUsable(tOldCarAdr) Then
                SetMemFloat tOldCarAdr.lngCarDamageAdr, 5
                strOnScreenText = strOnScreenText & "; " & "Previous car is torched"
            Else
                strOnScreenText = strOnScreenText & "; " & "Previous car is not available any more."
            End If
        Case 72, 73, 74 'Set Game Speed to:, Page 14: / 'Increase Game Speed / 'Decrease Game Speed
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If intCommandOrdinal = 72 Then
                    scrGameSpeed(1).Value = CInt(strExecData)  'for 72, strExecData is new scrGameSpeedPct
                ElseIf (intCommandOrdinal = 73) And (scrGameSpeed(1).Value < scrGameSpeed(1).max) Then
                    scrGameSpeed(1).Value = scrGameSpeed(1).Value + 1   'increase
                ElseIf (intCommandOrdinal = 74) And (scrGameSpeed(1).Value > scrGameSpeed(1).min) Then
                    scrGameSpeed(1).Value = scrGameSpeed(1).Value - 1   'decrease
                End If
                If scrGameSpeed(1).Value = 0 Then
                    SetMemFloat GTASABaseAdr.GameSpeedPctAdr, 1
                ElseIf scrGameSpeed(1).Value < 0 Then
                    SetMemFloat GTASABaseAdr.GameSpeedPctAdr, CSng(10& * (100& + scrGameSpeed(1).Value)) / 1000
                Else
                    SetMemFloat GTASABaseAdr.GameSpeedPctAdr, CSng(100& * (10& + scrGameSpeed(1).Value)) / 1000
                End If
                If scrGameSpeed(1).Value < 0 Then
                    strOnScreenText = strOnScreenText & "; " & "Game Speed set to: " & (100 + scrGameSpeed(1).Value) & " %"
                Else
                    strOnScreenText = strOnScreenText & "; " & "Game Speed set to: " & (100 + (scrGameSpeed(1).Value * 10)) & " %"
                End If
            End If
        Case 75 'Freeze Game Clock
            scrGameSpeed(0).Value = -92
            SetMemLong GTASABaseAdr.GameSpeedMsAdr, 3600000
            strOnScreenText = strOnScreenText & "; Game Clock is frozen"
        Case 76 'Thaw Game Clock
            scrGameSpeed(0).Value = 0
            SetMemLong GTASABaseAdr.GameSpeedMsAdr, 1000
            strOnScreenText = strOnScreenText & "; Game Clock is thawn"
        Case 77, 78 'Warp to next(77)/previous(78) location
            If GTASAWarpLocs.WarpLocCount > 0 And intWarpNextHitDelayCount = 0 Then
                intWarpNextHitDelayCount = 5
                If intCommandOrdinal = 77 Then 'next
                    If tvLocations.SelectedItem Is Nothing Then 'no item is previously selected
                        For iTvCtr = 1 To tvLocations.Nodes.Count
                            If tvLocations.Nodes(iTvCtr).Tag <> "folder" Then
                                Set tvLocations.SelectedItem = tvLocations.Nodes(iTvCtr)
                                Exit For
                            End If
                        Next iTvCtr
                    Else
                        For iTvCtr = tvLocations.SelectedItem.Index + 1 To tvLocations.Nodes.Count
                            If tvLocations.Nodes(iTvCtr).Tag <> "folder" Then
                                Set tvLocations.SelectedItem = tvLocations.Nodes(iTvCtr)
                                Exit For
                            End If
                        Next iTvCtr
                    End If
                Else 'previous
                    If tvLocations.SelectedItem Is Nothing Then 'no item is previously selected
                        For iTvCtr = tvLocations.Nodes.Count To 1 Step -1
                            If tvLocations.Nodes(iTvCtr).Tag <> "folder" Then
                                Set tvLocations.SelectedItem = tvLocations.Nodes(iTvCtr)
                                Exit For
                            End If
                        Next iTvCtr
                    Else
                        For iTvCtr = tvLocations.SelectedItem.Index - 1 To 1 Step -1
                            If tvLocations.Nodes(iTvCtr).Tag <> "folder" Then
                                Set tvLocations.SelectedItem = tvLocations.Nodes(iTvCtr)
                                Exit For
                            End If
                        Next iTvCtr
                    End If
                End If
                If Not tvLocations.SelectedItem Is Nothing Then
                    If PasteWarpLoc(0, GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).sLocData) Then
                        strOnScreenText = strOnScreenText & "; " & tvLocations.SelectedItem.Index & " - " & GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).sDescription
                    End If
                Else
                    strOnScreenText = strOnScreenText & "; Teleport not available"
                End If
            End If
        Case 79, 80, 81, 82, 83, 84
            Call oGFStats_ButtonClick(intCommandOrdinal - 79)
        Case 85, 86, 87, 88, 89, 90, 91, 92, 93, 94 'Toggle: Never Wanted / Never Get Hungry / Infinite Health / Infinite Oxygen / Infinite Ammo / Full Aim / Mega Punch / Mega Jump / Infinite Run / Fireproof
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If oCheatStates(intCommandOrdinal - 85).CheatState = vbChecked Then
                    oCheatStates(intCommandOrdinal - 85).CheatState = vbUnchecked
                Else
                    oCheatStates(intCommandOrdinal - 85).CheatState = vbChecked
                End If
                SetMemByte GTASABaseAdr.cCheatsAdr(intCommandOrdinal - 85), oCheatStates(intCommandOrdinal - 85).CheatState
                strOnScreenText = strOnScreenText & "; " & Replace(GTASAConsoleCommands(intCommandOrdinal).Description, "Toggle ", "") & IIf(oCheatStates(intCommandOrdinal - 85).CheatState = vbChecked, " ON", " OFF")
            End If
        Case 95, 96 'Advance Game Time by 1 Hour / Revert Game Time by 1 Hour
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                dtGameDateTime = DateSerial(1991, 5, 1 + GetMemInt(GTASABaseAdr.DaysInGameAdr)) + TimeSerial(GetMemByte(GTASABaseAdr.CurrHourAdr), GetMemByte(GTASABaseAdr.CurrMinuteAdr), 0)
                'set from command:
                If intCommandOrdinal = 95 Then 'increase
                    dtGameDateTime = DateAdd("h", 1, dtGameDateTime)
                Else
                    dtGameDateTime = DateAdd("h", -1, dtGameDateTime)
                End If
                'write to memory:
                If DateDiff("d", dtBaseDateTime, dtGameDateTime) > -1 Then
                    SetMemLong GTASABaseAdr.DaysInGameAdr, DateDiff("d", dtBaseDateTime, dtGameDateTime)
                    SetMemByte GTASABaseAdr.CurrHourAdr, Hour(dtGameDateTime)
                    SetMemByte GTASABaseAdr.CurrMinuteAdr, Minute(dtGameDateTime)
                    SetMemByte GTASABaseAdr.CurrWeekdayAdr, CByte(Format(dtGameDateTime, "w", vbSunday))
                End If
            End If
        
        Case 97, 98, 99 'Stop X Speed / Stop Y Speed / Stop Z Speed (Data Page: 17)
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 97)), 0, 4&, 4&
        Case 100 'Stop All Ped Speed (Data Page 17)
            'Set player Speed to zero:
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, zeroSpeed, 12, 12&
        Case 101, 102, 103 'Set Ped X / Y / Z Speed to: (DataPage 13)
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 101)), (CSng(strExecData) / 500), 4&, 4&
        Case 104, 105, 106 'Increase X / Y / Z Speed By: (DataPage: 13)
            sngExecWriteBuffer = GetMemFloat(GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 104))) + (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 104)), sngExecWriteBuffer, 4&, 4&
        Case 107, 108, 109 'Decrease X / Y / Z Speed By: (DataPage: 13)
            sngExecWriteBuffer = GetMemFloat(GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 107))) - (CSng(strExecData) / 500)
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr + (4 * (intCommandOrdinal - 107)), sngExecWriteBuffer, 4&, 4&
        Case 110 'Page:  13   Set Ped Speed to:
            sngExecWriteBuffer = CSng(strExecData) / 500
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, carFlipPlacement, 28&, 0&
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedExecWriteBuffer, 12&, 0&
            speedExecWriteBuffer.sngXSpeed = carFlipPlacement.sngXlooking * sngExecWriteBuffer
            speedExecWriteBuffer.sngYSpeed = carFlipPlacement.sngYlooking * sngExecWriteBuffer
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedExecWriteBuffer, 12&, 12&
        Case 111 'Page:  13   Increase Ped Speed by:
            sngExecWriteBuffer = CSng(strExecData) / 500
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPlayerPosAdr, carFlipPlacement, 28&, 0&
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedExecWriteBuffer, 12&, 0&
            'Normalize Speed:
            speedExecWriteBuffer.sngXSpeed = (Abs(speedExecWriteBuffer.sngXSpeed) + Abs(speedExecWriteBuffer.sngYSpeed)) * (carFlipPlacement.sngXlooking / (Abs(carFlipPlacement.sngXlooking) + Abs(carFlipPlacement.sngYlooking)))
            speedExecWriteBuffer.sngYSpeed = (Abs(speedExecWriteBuffer.sngXSpeed) + Abs(speedExecWriteBuffer.sngYSpeed)) * (carFlipPlacement.sngYlooking / (Abs(carFlipPlacement.sngXlooking) + Abs(carFlipPlacement.sngYlooking)))
            'Increase speed:
            speedExecWriteBuffer.sngXSpeed = speedExecWriteBuffer.sngXSpeed + (carFlipPlacement.sngXlooking * sngExecWriteBuffer)
            speedExecWriteBuffer.sngYSpeed = speedExecWriteBuffer.sngYSpeed + (carFlipPlacement.sngYlooking * sngExecWriteBuffer)
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngPedSpeedAdr, speedExecWriteBuffer, 12&, 12&
        Case 112 'DataPage: 16 'Ped Flight Assistance (ON/OFF)
            isPedFlightAssistance = (strExecData = "1")
            oPedStats(20).Locked = CInt(strExecData)
            WritePrivateProfileString "PlayerTracking", "PedFlightAssist", Format$(oPedStats(20).Locked) & "," & Format$(oPedStats(20).ScrollVal), strIniFileName
            strOnScreenText = strOnScreenText & "; " & "Flight Assistance " & IIf(isPedFlightAssistance, "activated", "deactivated")
        Case 113 'DataPage: 8  'Ped Flight Assistance Level (0-100%)
            sngPedAssistFlightBy = CSng(strExecData) * 0.002
            oPedStats(20).ScrollVal = CInt(strExecData)
            WritePrivateProfileString "PlayerTracking", "PedFlightAssist", Format$(oPedStats(20).Locked) & "," & Format$(oPedStats(20).ScrollVal), strIniFileName
            strOnScreenText = strOnScreenText & "; " & "Flight Assistance Level set to: " & Format$(oPedStats(20).ScrollVal / 10) & " %"
        Case 114 'DataPage: 19 'Turn Ped in Clock Direction by:"  ' 0-180 Degrees
            TurnPed GTASAPlayerAddresse, CSng(strExecData), 2
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr, sngExecWriteBuffer, 4&, 0&
            sngExecWriteBuffer = sngExecWriteBuffer + GetGrad(CSng(strExecData))
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr - 4, sngExecWriteBuffer, 4&, 4&
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr, sngExecWriteBuffer, 4&, 4&
        Case 115 'DataPage: 19 'Turn Ped in Counterclock Direction by:"  ' 0-180 Degrees
            TurnPed GTASAPlayerAddresse, 0 - CSng(strExecData), 2 '0:X /1:Y /2:Z
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr, sngExecWriteBuffer, 4&, 0&
            sngExecWriteBuffer = sngExecWriteBuffer - GetGrad(CSng(strExecData))
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr - 4, sngExecWriteBuffer, 4&, 4&
            WriteProcessMemory lngPHandle, GTASAPlayerAddresse.lngAngleAdr, sngExecWriteBuffer, 4&, 4&
        Case 116, 117, 118, 119, 120, 121
            'Perfect Handling=14'Decreased Traffic=15'Huge Bunny Hop=16'Cars Have Nitro=17'Boats can Fly=18'Cars can Fly=19
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If oCheatStates(intCommandOrdinal - 102).CheatState = vbChecked Then
                    oCheatStates(intCommandOrdinal - 102).CheatState = vbUnchecked
                Else
                    oCheatStates(intCommandOrdinal - 102).CheatState = vbChecked
                End If
                SetMemByte GTASABaseAdr.cCheatsAdr(intCommandOrdinal - 102), oCheatStates(intCommandOrdinal - 102).CheatState
                strOnScreenText = strOnScreenText & "; " & Replace(GTASAConsoleCommands(intCommandOrdinal).Description, "Toggle ", "") & IIf(oCheatStates(intCommandOrdinal - 102).CheatState = vbChecked, " ON", " OFF")
            End If
        Case 122 'Spawn Car (DataPage:12, strExecData has the CarID to spawn)
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If isInjected Then
                    If CInt(strExecData) > 399 And CInt(strExecData) < 612 Then
                        SetMemLong GTASABaseAdr.CarSpawnAdr, CInt(strExecData)
                    Else
                        strOnScreenText = strOnScreenText & "; Unknown Car ID. Spawn not possible."
                    End If
                Else
                    strOnScreenText = strOnScreenText & "; Spawn-Code not injected. Please inject code first."
                End If
            End If
        Case 123 'DataPage: 7 Set Weather to:
            If isWeatherLock Then
                lngLockWeatherTo = CLng(strExecData)
                cboWeather.ListIndex = lngLockWeatherTo
                SetMemLong GTASABaseAdr.WeatherLockAdr, lngLockWeatherTo
            End If
            SetMemLong GTASABaseAdr.WeatherToGoAdr, CLng(strExecData)
            SetMemLong GTASABaseAdr.WeatherCurrentAdr, CLng(strExecData)
            strOnScreenText = strOnScreenText & "; Weather set to: " & cboWeather.list(CLng(strExecData))
            
        Case 124 'Toggle Weather Lock:
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If chkWeatherLock.Value = vbChecked Then
                    chkWeatherLock.Value = vbUnchecked
                Else
                    chkWeatherLock.Value = vbChecked
                End If
                isWeatherLock = (chkWeatherLock.Value = vbChecked)
                If isWeatherLock Then
                    SetMemLong GTASABaseAdr.WeatherLockAdr, lngLockWeatherTo
                Else
                    SetMemLong GTASABaseAdr.WeatherLockAdr, &HFFFF
                End If
                strOnScreenText = strOnScreenText & "; " & Replace(GTASAConsoleCommands(intCommandOrdinal).Description, "Toggle ", "") & IIf(chkWeatherLock.Value = vbChecked, " ON", " OFF")
            End If
        Case 125 'Toggle One Hit Kill
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If oCheatStates(20).CheatState = vbChecked Then
                    oCheatStates(20).CheatState = vbUnchecked
                Else
                    oCheatStates(20).CheatState = vbChecked
                End If
                'check the mem status:
                ReadProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectCheck_OneHitKill(0), 5&, 0&
                If oCheatStates(20).CheatState = vbChecked Then
                    'inject if injectable:
                    If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                        (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                        (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                        'jump code is already injected!!
                    ElseIf ((bInjectCheck_OneHitKill(0) = bNotInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bNotInjectedJump_OneHitKill(1)) And _
                           (bInjectCheck_OneHitKill(2) = bNotInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bNotInjectedJump_OneHitKill(3)) And _
                           (bInjectCheck_OneHitKill(4) = bNotInjectedJump_OneHitKill(4))) Then
                        'jump code is injectable:
                        WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectCode_OneHitKillAdr, bInjectedCode_OneHitKill(0), 47&, 47&
                        WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bInjectedJump_OneHitKill(0), 5&, 5&
                    Else
                        strOnScreenText = strOnScreenText & "; One-Hit-Kill code can not be injected."
                        GoTo FunctionExit
                    End If
                Else
                    'remove injection:
                    If ((bInjectCheck_OneHitKill(0) = bInjectedJump_OneHitKill(0)) And (bInjectCheck_OneHitKill(1) = bInjectedJump_OneHitKill(1)) And _
                        (bInjectCheck_OneHitKill(2) = bInjectedJump_OneHitKill(2)) And (bInjectCheck_OneHitKill(3) = bInjectedJump_OneHitKill(3)) And _
                        (bInjectCheck_OneHitKill(4) = bInjectedJump_OneHitKill(4))) Then
                        'jump code is injected, remove injection:
                        WriteProcessMemory lngPHandle, GTASABaseAdr.CodeInjectJump_OneHitKillAdr, bNotInjectedJump_OneHitKill(0), 5&, 5&
                    End If
                End If
                strOnScreenText = strOnScreenText & "; One Hit Kill " & IIf(oCheatStates(20).CheatState = vbChecked, "Enabled", "Disabled")
            End If
        Case 126 'Toggle Freeze Mission Timers
            If intGameTimeChangeCount = 0 Then
                intGameTimeChangeCount = 3
                If oCheatStates(21).CheatState = vbChecked Then
                    oCheatStates(21).CheatState = vbUnchecked
                Else
                    oCheatStates(21).CheatState = vbChecked
                End If
                If oCheatStates(21).CheatState = vbChecked Then
                    'inject if injectable:
                    If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = iOrg_FreezeTimerUp Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, &H9090
                    If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = iOrg_FreezeTimerDown Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, &H9090
                Else
                    'remove injection if it was injected/injectable:
                    If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr) = &H9090 Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerUpAdr, iOrg_FreezeTimerUp
                    If GetMemInt(GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr) = &H9090 Then SetMemInt GTASABaseAdr.CodeInjectNOP_FreezeTimerDownAdr, iOrg_FreezeTimerDown
                End If
                strOnScreenText = strOnScreenText & "; Mission Timers " & IIf(oCheatStates(21).CheatState = vbChecked, "Frozen", "Thawn")
            End If
        Case 127 'Give Weapon and Ammo (Data Page: 3)
            'strExecData is:  WeaponID;AmmoAmount
            'we will feed these values to weapon control, and call the set weapon function (ReFillPlayerWeapons)
            lngExecBuffer = GetToken(strExecData, 1, ";")     'this is now weapon id
            If lngExecBuffer < 321 Then GoTo FunctionExit
            If lngExecBuffer = 331 Then
                'special case for brass knuckles
                chkWeapons(11).Value = vbChecked
                isFixBrassKnuckle = True
                If isInjected Then 'initialiase weapon, just for the case
                    WriteProcessMemory lngPHandle, GTASABaseAdr.WeaponSpawnAdr(11), 331&, 4&, 4&
                End If
                'give player brass knuckles:
                SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr, 1
                SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr + 12, 1
            Else
                lngExecBuffer = DatIDtoWeaponID(lngExecBuffer)    'this is now DatID
                'also select weapon in combo:
                cboWeapons(WeaponSlotCombo(lngExecBuffer, 0)).ListIndex = WeaponSlotCombo(lngExecBuffer, 1)
                lngExecBuffer = WeaponSlotCombo(lngExecBuffer, 0) 'this is now Weapon Slot
                'feed weapon id and ammo to relevant arrays:
                iFixWeaponID(lngExecBuffer) = DatIDtoWeaponID(GetToken(strExecData, 1, ";"))
                iFixWeaponAmmo(lngExecBuffer) = GetToken(strExecData, 2, ";")
                'also set ammo value in textbox:
                txtAmmo(lngExecBuffer).Text = iFixWeaponAmmo(lngExecBuffer)
                'call function to refill weapon:
                ReFillPlayerWeapons lngExecBuffer
            End If
        Case 128 'Remove Current Weapon
            'find which weapon player is carrying, feed (None) into the slot,
            'then call the set weapon function
            lngExecBuffer = 0
            ReadProcessMemory lngPHandle, GTASAPlayerAddresse.lngWeaponIDAdr, lngExecBuffer, 4&, 0&
            If lngExecBuffer = 331 Then
                'special case for brass knuckles
                chkWeapons(11).Value = vbUnchecked
                isFixBrassKnuckle = False
                SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr, 0
                SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr + 12, 0
            ElseIf lngExecBuffer > 320 And lngExecBuffer < 373 Then
                'player has a valid weapon, we need to remove:
                lngExecBuffer = DatIDtoWeaponID(lngExecBuffer)    'this is now DatID
                'also select weapon in combo:
                cboWeapons(WeaponSlotCombo(lngExecBuffer, 0)).ListIndex = 0 'select "(None)"
                lngExecBuffer = WeaponSlotCombo(lngExecBuffer, 0) 'this is now Weapon Slot
                'feed zero to relevant arrays, to remove weapons:
                iFixWeaponID(lngExecBuffer) = 0
                iFixWeaponAmmo(lngExecBuffer) = 0
                'also set ammo value in textbox:
                txtAmmo(lngExecBuffer).Text = "0"
                'call function to refill weapon:
                ReFillPlayerWeapons lngExecBuffer
            'Else 'player has either no weapon, or the value is invalid, do nothing...
            End If
            
        Case 129 'Clear All Weapons
            'feed (None) to all weapon slots, then call the set weapon function
            'special case for brass knuckles:
            chkWeapons(11).Value = vbUnchecked
            isFixBrassKnuckle = False
            SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr, 0
            SetMemLong GTASAPlayerAddresse.lngBrassKnucklesAdr + 12, 0
            For lngExecBuffer = 0 To 10
                cboWeapons(lngExecBuffer).ListIndex = 0 'select "(None)"
                'feed zero to relevant arrays, to remove weapons:
                iFixWeaponID(lngExecBuffer) = 0
                iFixWeaponAmmo(lngExecBuffer) = 0
                'also set ammo value in textbox:
                txtAmmo(lngExecBuffer).Text = "0"
                'call function to refill weapon:
                ReFillPlayerWeapons lngExecBuffer
            Next lngExecBuffer
    End Select
FunctionExit:
    isInternalClick = False
    Err.Clear
End Function

Private Function TurnCar(ByRef tCarAdrToTurn As GTASACarAdr, ByVal sngDegrees As Single, ByVal intTurnType As Integer) As Boolean '
On Error Resume Next
    'Page: 19   Turn My Car in Clock Direction by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, CInt(strExecData), 2
    'Page: 19   Turn My Car in Counterclock Direction by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, 0 - CInt(strExecData), 2
    'Page: 19   Turn My Car Nose Up by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, CInt(strExecData), 1
    'Page: 19   Turn My Car Nose Down by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, 0 - CInt(strExecData), 1
    'Page: 19   Turn My Car Sideways to right by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, CInt(strExecData), 0
    'Page: 19   Turn My Car Sideways to left by:"  ' 0-180 Degrees
    '    TurnCar tCurrCarAdr, 0 - CInt(strExecData), 0
    
    'Get Car WarpPosData
    ReadProcessMemory lngPHandle, tCarAdrToTurn.lngCarPosAdr, turnCarExecBuffer, 44&, 0&
    Select Case intTurnType
        Case 0 'Sideways
        
        Case 1 'Nose Up/Down
        
        Case 2 'Clock/Counterclock direction
            'Car XGrad in degrees:
            sngAbsoluteDegrees = GetAbsoluteDegrees(turnCarExecBuffer.XGrad, turnCarExecBuffer.YGrad)
            sngAbsoluteDegrees = sngAbsoluteDegrees + sngDegrees 'turn by: sngDegrees°
            'Normalize Grade values:
            turnCarExecBuffer.XGrad = GetGrad(sngAbsoluteDegrees)
            turnCarExecBuffer.YGrad = GetGrad(sngAbsoluteDegrees - 90) 'Y is always X-90°
        '    turnCarExecBuffer.ZGrad = 0
            'Normalize Look values:
            If ((360 + (sngAbsoluteDegrees)) Mod 360) >= 270 Then
                'Normalization of Look to Grade values: Look=Degrees-270°
                turnCarExecBuffer.XLook = GetGrad(sngAbsoluteDegrees - 270)
                turnCarExecBuffer.YLook = GetGrad(sngAbsoluteDegrees - 270 - 90) ' Y ist always X-90°
            Else
                'Normalization of Look to Grade values: Look=Degrees+90°
                turnCarExecBuffer.XLook = GetGrad(sngAbsoluteDegrees + 90)
                turnCarExecBuffer.YLook = GetGrad(sngAbsoluteDegrees + 90 - 90) 'Y ist always X - 90°
            End If
        '    turnCarExecBuffer.ZLook = 0
        '    turnCarExecBuffer.XWhat = 0
        '    turnCarExecBuffer.YWhat = 0
        '    turnCarExecBuffer.ZWhat = 1
    End Select
    'Write new pos data:
    WriteProcessMemory lngPHandle, tCarAdrToTurn.lngCarPosAdr, turnCarExecBuffer, 44&, 44&
    Err.Clear
End Function

Private Function TurnPed(ByRef tPedAdrToTurn As GTASAPlayerAdr, ByVal sngDegrees As Single, ByVal intTurnType As Integer) As Boolean '
On Error Resume Next
    'Get Car WarpPosData
    ReadProcessMemory lngPHandle, tPedAdrToTurn.lngPlayerPosAdr, turnPedExecBuffer, 44&, 0&
    Select Case intTurnType
        Case 0 'Sideways
        
        Case 1 'Nose Up/Down
        
        Case 2 'Clock/Counterclock direction
            'Car XGrad in degrees:
            sngAbsoluteDegrees = GetAbsoluteDegrees(turnPedExecBuffer.XGrad, turnPedExecBuffer.YGrad)
            sngAbsoluteDegrees = sngAbsoluteDegrees + sngDegrees 'turn by: sngDegrees°
            'Normalize Grade values:
            turnPedExecBuffer.XGrad = GetGrad(sngAbsoluteDegrees)
            turnPedExecBuffer.YGrad = GetGrad(sngAbsoluteDegrees - 90) 'Y is always X-90°
        '    turnPedExecBuffer.ZGrad = 0
            'Normalize Look values:
            If ((360 + (sngAbsoluteDegrees)) Mod 360) >= 270 Then
                'Normalization of Look to Grade values: Look=Degrees-270°
                turnPedExecBuffer.XLook = GetGrad(sngAbsoluteDegrees - 270)
                turnPedExecBuffer.YLook = GetGrad(sngAbsoluteDegrees - 270 - 90) ' Y ist always X-90°
            Else
                'Normalization of Look to Grade values: Look=Degrees+90°
                turnPedExecBuffer.XLook = GetGrad(sngAbsoluteDegrees + 90)
                turnPedExecBuffer.YLook = GetGrad(sngAbsoluteDegrees + 90 - 90) 'Y ist always X - 90°
            End If
        '    turnPedExecBuffer.ZLook = 0
        '    turnPedExecBuffer.XWhat = 0
        '    turnPedExecBuffer.YWhat = 0
        '    turnPedExecBuffer.ZWhat = 1
    End Select
    'Write new pos data:
    WriteProcessMemory lngPHandle, tPedAdrToTurn.lngPlayerPosAdr, turnPedExecBuffer, 44&, 44&
    Err.Clear
End Function

Private Function OnScreenText(ByVal strTextToScreen As String) As Boolean '
On Error Resume Next
    Static intWCounter As Integer
    'first, delete current text:
    GTASAText.CharValue(0) = 32
    GTASAText.CharValue(1) = 0
    WriteProcessMemory lngPHandle, GTASABaseAdr.Msg1Adr, GTASAText, 64&, 64&
    'then, generate non-unicode text:
    strTextToScreen = " " & Trim(strTextToScreen)
    If Len(strTextToScreen) > 63 Then strTextToScreen = Left$(strTextToScreen, 63)
    'Prepare Unicode Text:
    For intWCounter = 0 To Len(strTextToScreen) - 1
        GTASAText.CharValue(intWCounter) = Asc(Mid$(strTextToScreen, intWCounter + 1, 1))
    Next intWCounter
    If intWCounter < 64 Then
        GTASAText.CharValue(intWCounter) = 0
    End If
    WriteProcessMemory lngPHandle, GTASABaseAdr.Msg1Adr, GTASAText, 64&, 64&
'    WriteProcessMemory lngPHandle, GTASABaseAdr.Msg2Adr, GTASAText, 64&, 64&
'    WriteProcessMemory lngPHandle, GTASABaseAdr.Msg3Adr, GTASAText, 64&, 64&
    Err.Clear
End Function

Private Function CheckAndRefreshGarages() As Boolean '
On Error Resume Next
    Dim iGarageCtr As Integer
    Dim bGarage(255) As Byte 'all 4 cars in 256 bytes
    'Write to GTA SA
    If Not (isHasHandle And isHasPlayer) Then Exit Function
    'go thru all garages and force-write to gta if garage is locked:
    For iGarageCtr = iJohnson To iHashbury
        If cParking(iGarageCtr).Locked = vbChecked Then
            'read from garage to pre-fill the parking information:
            ReadProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 0&
            'read updated values from ocx:
            cParking(iGarageCtr).UpdateValuesOfGarageStructByteArray bGarage
            'write back to GTA SA:
            WriteProcessMemory lngPHandle, GTASAGarageAddresses(iGarageCtr).lngXCoordAdr, bGarage(0), 256&, 256&
        End If
    Next iGarageCtr
    CheckAndRefreshGarages = True
    Err.Clear
End Function

Private Function DumpChangesToCFG(ByVal isCheats As Boolean, ByVal isLocs As Boolean, ByVal isShortcuts As Boolean) As Boolean '
On Error Resume Next
    Dim oNode As Node
    Dim iArrayCtr As Long
    Dim sPathArray() As String
    Screen.MousePointer = 11
    If isCheats Then
        Open strCheatFileName For Output As #1
            'Dump klartext:
            Print #1, "# Edit at your own risk. Consists of Cheat Data for GTASA Control Center"
            Print #1, "# This file gets regenerated when you click on Save Changes to Config File button."
            Print #1, "# If you delete this file, it will be regenerated by the next time you run GTASA Control Center"
            Print #1, "GTASACheats"
            Print #1, "#UID | Folder | Cheat String | Description"
            'Dump Cheats:
            ReDim sPathArray(tvCheats.Nodes.Count + 1)
            iArrayCtr = 0
            For Each oNode In tvCheats.Nodes
                If oNode.Tag <> "folder" Then
                    sPathArray(iArrayCtr) = oNode.FullPath & oNode.Tag
                    iArrayCtr = iArrayCtr + 1
                    DoEvents
                End If
            Next
            ReDim Preserve sPathArray(iArrayCtr - 1)
            QuicksortString sPathArray, LBound(sPathArray), UBound(sPathArray)
            DoEvents
            For iArrayCtr = 0 To UBound(sPathArray)
                For Each oNode In tvCheats.Nodes
                    If oNode.Tag <> "folder" Then
                        If oNode.FullPath & oNode.Tag = sPathArray(iArrayCtr) Then
                            GTASACheats.GetItemByUID(oNode.Tag).sFolder = oNode.Parent.FullPath
                            Print #1, GTASACheats.GetDumpStringByUID(oNode.Tag)
                            DoEvents
                            Exit For
                        End If
                    End If
                Next
            Next iArrayCtr
            Print #1, "END_GTASACheats"
            Print #1, ""
            isDirty(0) = False
        Close #1
    End If
    If isLocs Then
        Open strLocsFileName For Output As #1
            'Dump klartext:
            Print #1, "# Edit at your own risk. Consists of Location Data for GTASA Control Center"
            Print #1, "# This file gets regenerated when you click on Save Changes to Config File button."
            Print #1, "# If you delete this file, it will be regenerated by the next time you run GTASA Control Center"
            Print #1, "GTASAWarpLocations"
            Print #1, "#GTA San Andreas Warp Locations:"
            Print #1, "#UID | Folder | Description | LocationData(X;Y;Z;Angle)"
            'Dump Locations:
            ReDim sPathArray(tvLocations.Nodes.Count + 1)
            iArrayCtr = 0
            For Each oNode In tvLocations.Nodes
                If oNode.Tag <> "folder" Then
                    sPathArray(iArrayCtr) = oNode.FullPath & oNode.Tag
                    iArrayCtr = iArrayCtr + 1
                    DoEvents
                End If
            Next
            ReDim Preserve sPathArray(iArrayCtr - 1)
            QuicksortString sPathArray, LBound(sPathArray), UBound(sPathArray)
            DoEvents
            For iArrayCtr = 0 To UBound(sPathArray)
                For Each oNode In tvLocations.Nodes
                    If oNode.Tag <> "folder" Then
                        If oNode.FullPath & oNode.Tag = sPathArray(iArrayCtr) Then
                            GTASAWarpLocs.GetItemByUID(oNode.Tag).sFolder = oNode.Parent.FullPath
                            Print #1, GTASAWarpLocs.GetDumpStringByUID(oNode.Tag)
                            DoEvents
                            Exit For
                        End If
                    End If
                Next
            Next iArrayCtr
            Print #1, "END_GTASAWarpLocations"
            Print #1, ""
            isDirty(1) = False
        Close #1
    End If
    If isShortcuts Then
        Open strCfgFileName For Output As #1
            'Dump klartext:
            Print #1, "# This file gets regenerated when you click on Save Changes to Config File button."
            Print #1, "# If you delete this file, it will be regenerated by the next time you run GTASA_Console"
            Print #1, "GTASAShortcuts"
            Print #1, "#GTA San Andreas Keyboard Shortcuts:"
            Print #1, "#UID | Folder | Description | Active | ComboText | ExtKeyCode | KeyCode | Category | Command | DataPage | AdditionalData | Additional Data Explanation"
            'Dump Shortcuts:
            ReDim sPathArray(tvShotcuts.Nodes.Count + 1)
            iArrayCtr = 0
            For Each oNode In tvShotcuts.Nodes
                If oNode.Tag <> "folder" Then
                    sPathArray(iArrayCtr) = oNode.FullPath & oNode.Tag
                    iArrayCtr = iArrayCtr + 1
                    DoEvents
                End If
            Next
            ReDim Preserve sPathArray(iArrayCtr - 1)
            QuicksortString sPathArray, LBound(sPathArray), UBound(sPathArray)
            DoEvents
            For iArrayCtr = 0 To UBound(sPathArray)
                For Each oNode In tvShotcuts.Nodes
                    If oNode.Tag <> "folder" Then
                        If oNode.FullPath & oNode.Tag = sPathArray(iArrayCtr) Then
                            GTASAShortcuts.GetItemByUID(oNode.Tag).sFolder = oNode.Parent.FullPath
                            Print #1, GTASAShortcuts.GetDumpStringByUID(oNode.Tag)
                            DoEvents
                            Exit For
                        End If
                    End If
                Next
            Next iArrayCtr
            Print #1, "END_GTASAShortcuts"
            Print #1, ""
            isDirty(2) = False
        Close #1
    End If
    Screen.MousePointer = 0
    Err.Clear
End Function

Private Function ParseShortcuts() As Boolean '
On Error GoTo errParseShortcuts
    Dim strLineInput As String
    Dim sShortcutArray() As String
    'WarpLocations:
    GTASAShortcuts.RemoveAll
    Open strCfgFileName For Input As #1
    Do Until EOF(1) 'find start of warp locs:
        Line Input #1, strLineInput
        If Left$(strLineInput, 18) = "GTASAShortcuts" Then Exit Do
    Loop
    Do Until EOF(1) 'read warp locs:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) = "#" Then GoTo ReadNextLoc
        If Left$(strLineInput, 22) = "END_GTASAShortcuts" Then Exit Do
        'if we can come to this line, we have found a warp loc:
        If InStr(strLineInput, "|") > 0 Then 'new dat
            strLineInput = Replace(strLineInput, vbTab, "")
            strLineInput = Replace(Replace(Replace(Replace(strLineInput, "  ", " "), "  ", " "), "  ", " "), "  ", " ")
            sShortcutArray = Split(strLineInput, "|")
            Set GTASANewShortcut = New cShortcuts
            With GTASANewShortcut
                .sUID = Trim$(sShortcutArray(0))
                If .sUID = "" Then .sUID = CreateGUID
                .sFolder = Trim$(sShortcutArray(1))
                If .sFolder = "" Then .sFolder = "root"
                .sDescription = Trim$(sShortcutArray(2))
                .isActive = (Trim$(sShortcutArray(3)) = "1")
                .sComboText = sShortcutArray(4)
                .iExtKeyCode = Trim$(sShortcutArray(5))
                .iKeyCode = Trim$(sShortcutArray(6))
                .iCategory = Trim$(sShortcutArray(7))
                .sCommand = Trim$(sShortcutArray(8))
                .iDataPage = Trim$(sShortcutArray(9))
                .sData = Trim$(sShortcutArray(10))
                .sDataDesc = Trim$(sShortcutArray(11))
            End With
            GTASAShortcuts.AddShortcutClass GTASANewShortcut
        End If
ReadNextLoc:
    Loop
    Close #1
Exit Function
errParseShortcuts:
    MsgBox Err.Description, vbCritical, "Error parsing Keyboard Shortcuts"
    Err.Clear
    Close #1
End Function

Private Function ParseCheats() As Boolean '
On Error GoTo errParseCheats
    Dim strLineInput As String
    Dim sCheatArray() As String
    
    'Cheats
    GTASACheats.RemoveAll
    Open strCheatFileName For Input As #1
    Do Until EOF(1) 'find start of cheats:
        Line Input #1, strLineInput
        If Left$(strLineInput, 11) = "GTASACheats" Then Exit Do
    Loop
    Do Until EOF(1) 'read cheats:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) = "#" Then GoTo ReadNextCheat
        If Left$(strLineInput, 15) = "END_GTASACheats" Then Exit Do
        'if we can come to this line, we have found a cheat:
        If InStr(strLineInput, "|") > 0 Then
            strLineInput = Replace(strLineInput, vbTab, "")
            strLineInput = Replace(Replace(Replace(Replace(strLineInput, "  ", " "), "  ", " "), "  ", " "), "  ", " ")
            sCheatArray = Split(strLineInput, "|")
            Set GTASANewCheat = New cCheats
            With GTASANewCheat
                .sUID = Trim$(sCheatArray(0))
                .sFolder = Trim$(sCheatArray(1))
                If .sFolder = "" Then .sFolder = "root"
                .sCheatString = Trim$(sCheatArray(2))
                .sDescription = Trim$(sCheatArray(3))
            End With
            GTASACheats.AddCheatClass GTASANewCheat
        End If
ReadNextCheat:
    Loop
    Close #1
Exit Function
errParseCheats:
    MsgBox Err.Description, vbCritical, "Error parsing cheat configuration."
    Close #1
    Err.Clear
End Function

Private Function ParseLocations() As Boolean '
On Error GoTo errParseLocations
    Dim strLineInput As String
    Dim sLocArray() As String
    'WarpLocations:
    GTASAWarpLocs.RemoveAll
    Open strLocsFileName For Input As #1
    Do Until EOF(1) 'find start of warp locs:
        Line Input #1, strLineInput
        If Left$(strLineInput, 18) = "GTASAWarpLocations" Then Exit Do
    Loop
    Do Until EOF(1) 'read warp locs:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) = "#" Then GoTo ReadNextLoc
        If Left$(strLineInput, 22) = "END_GTASAWarpLocations" Then Exit Do
        'if we can come to this line, we have found a warp loc:
        If InStr(strLineInput, "|") > 0 Then 'new dat
            strLineInput = Replace(strLineInput, vbTab, "")
            strLineInput = Replace(Replace(Replace(Replace(strLineInput, "  ", " "), "  ", " "), "  ", " "), "  ", " ")
            sLocArray = Split(strLineInput, "|")
            Set GTASANewWarpLoc = New cWarpLocs
            With GTASANewWarpLoc
                .sUID = Trim$(sLocArray(0))
                If .sUID = "" Then .sUID = CreateGUID
                .sFolder = Trim$(sLocArray(1))
                If .sFolder = "" Then .sFolder = "root"
                .sDescription = Trim$(sLocArray(2))
                .sLocData = Trim$(sLocArray(3))
            End With
            GTASAWarpLocs.AddWarpLocsClass GTASANewWarpLoc
        End If
ReadNextLoc:
    Loop
    Close #1
Exit Function
errParseLocations:
    MsgBox Err.Description, vbCritical, "Error parsing Warp Locations"
    Err.Clear
    Close #1
End Function

Private Function ParseCarIDs() As Boolean '
On Error GoTo errParseCarIDs
    Dim intCarCount As Integer
    Dim intSpawnIndex As Integer
    Dim intGarageCounter As Integer
    Dim intCarID As Integer
    Dim intDumpCounter As Integer
    Dim sngXoff As Single
    Dim sngYoff As Single
    Dim strLineInput As String
    Dim sSplitArr() As String
    'Car Information (Information/Reference Arrays are static)
    cboSpawnCar.Clear
    cboCommandParkedCar.Clear
    Open strDatFileName For Input As #1
    Do Until EOF(1) 'find start of Cat ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 9) = "GTASACars" Then Exit Do
    Loop
    intCarCount = 0
    For intCounter = 0 To 16
        cParking(intCounter).AddCar "(None)" '0
    Next intCounter
    For intCounter = 0 To 3
        GarageListMatrix(intCounter, 399) = 0  'CarID 0
        ParkedCarMatrix(intCounter, 0) = 0
    Next intCounter
    intSpawnIndex = 0
    intCarCount = 1 'starts from 1, because 0:(none) 1:(Ignored) , also it will be increased by one when a parkable car is found
    Do Until EOF(1) 'read Car ID's:
        Line Input #1, strLineInput
        If Left$(strLineInput, 1) = "#" Then GoTo ReadNextCarID
        If Left$(strLineInput, 13) = "END_GTASACars" Then Exit Do
        'if we can come to this line, we have found a Car ID:
        strLineInput = Replace(strLineInput, vbTab, "")
        sSplitArr = Split(strLineInput, ",")
        If UBound(sSplitArr) > 0 Then
            intCarID = CInt(sSplitArr(0))
            '441 Rc Bandit '464 Rc Baron '594 Rc Cam '501 Rc Goblin
            '465 Rc Raider '564 Rc Tiger
            If (intCarID = 441) Or (intCarID = 464) Or (intCarID = 594) Or (intCarID = 501) Or _
               (intCarID = 465) Or (intCarID = 564) Then
                ParkedCars(intCarID).isRCCar = True
            End If
            ParkedCars(intCarID).strCarName = Trim$(sSplitArr(1))
            ParkedCars(intCarID).strCarType = Trim$(sSplitArr(2))
            ParkedCars(intCarID).sngCarWidth = CSng(CInt(sSplitArr(3))) / 100
            ParkedCars(intCarID).sngCarLength = CSng(CInt(sSplitArr(4))) / 100
            ParkedCars(intCarID).sngCarHeight = CSng(CInt(sSplitArr(5))) / 100
            ParkedCars(intCarID).iHandling = CLng("&H" & sSplitArr(6))
            ParkedCars(intCarID).isParkable = (Trim(sSplitArr(7)) = "1")
            If UBound(sSplitArr) > 7 Then
                ParkedCars(intCarID).MajorColor = CByte(sSplitArr(8))
                ParkedCars(intCarID).MinorColor = CByte(sSplitArr(9))
            Else
                ParkedCars(intCarID).MajorColor = 1
                ParkedCars(intCarID).MinorColor = 1
            End If
            If UBound(sSplitArr) > 9 Then
                ParkedCars(intCarID).sModsArr = "401;431;432;433;434;435;436;437;438;439;43A;43B;43C;43D;448;449;44A;" & Trim(sSplitArr(10))
                ParkedCars(intCarID).isHasMods = Len(ParkedCars(intCarID).sModsArr) > 0
            Else
                ParkedCars(intCarID).isHasMods = False
                ParkedCars(intCarID).sModsArr = ""
            End If
        End If
        'now decide if isBike, isLong etc:
        ParkedCars(intCarID).isBike = (LCase(ParkedCars(intCarID).strCarType) = "bike")
        ParkedCars(intCarID).isLong = (ParkedCars(intCarID).sngCarLength > 550)
        'Parked/Parkable Cars:
        If ParkedCars(intCarID).isParkable Then
            'Garage 0 to 16 with 4 cars in each:
            For intGarageCounter = 0 To 16
                cParking(intGarageCounter).AddCar ParkedCars(intCarID).strCarName
            Next
            For intGarageCounter = 0 To 3
                'create cross reference:
                GarageListMatrix(intGarageCounter, intCarID) = intCarCount
                ParkedCarMatrix(intGarageCounter, intCarCount) = intCarID
            Next
            intCarCount = intCarCount + 1
        End If
        cboSpawnCar.AddItem ParkedCars(intCarID).strCarName
        cboCommandParkedCar.AddItem ParkedCars(intCarID).strCarName
        SpawnListMatrix(intCarID) = intSpawnIndex
        SpawnCarMatrix(intSpawnIndex) = intCarID
        intSpawnIndex = intSpawnIndex + 1
ReadNextCarID:
    Loop
    Close #1
Exit Function
errParseCarIDs:
    MsgBox Err.Description, vbCritical, "Error parsing Car ID's"
    Close #1
    Err.Clear
End Function

Private Function CheckPlayerCarStatus() As Boolean '
On Error GoTo errCheckPlayerCarStatus
    'this function checks if player is in a car or not
    'if in car, checks if still in the same car or not
    'if still in the same car, checks if car adr structure is populated or not
    Static lngTrailerPtr As Long
    Static isHasNewTrailerOnly As Boolean
    Static isCheckingStatus As Boolean
    If isCheckingStatus Then Exit Function
    isCheckingStatus = True
    
    Static lngPtrToPedAdrVal As Long
    Static lngPtrToCarAdrVal As Long
    Static lngPlayerCarPtr As Long
    Static lngRetVal1 As Long
    Static lngRetVal2 As Long
    Static lngRetVal3 As Long
    Static lngRetVal4 As Long
    Static intCarIDHitTest As Integer
    Static isHasRCCarNow As Boolean
    Static fRBuffer As Single
    Static fWBuffer As Single
    Static dBuffer As Double
    
    lngPtrToPedAdrVal = 0
    lngPtrToCarAdrVal = 0
    lngPlayerCarPtr = 0
    lngRetVal1 = 0
    lngRetVal2 = 0
    lngRetVal3 = 0
    lngRetVal4 = 0
    intCarIDHitTest = 0
    isHasRCCarNow = False
    
    'first, check if player is in car or not:
    lngRetVal1 = ReadProcessMemory(lngPHandle, GTASABaseAdr.PlayerAdr, lngPtrToPedAdrVal, 4&, 0&)
    lngRetVal2 = ReadProcessMemory(lngPHandle, GTASABaseAdr.CurrCarAdr, lngPtrToCarAdrVal, 4&, 0&)
    If lngRetVal1 = 0 Or lngRetVal2 = 0 Then
        If Me.Caption <> "GTASA Control Center [Error on retrieving Car Adresse]" Then Me.Caption = "GTASA Control Center [Error on retrieving Car Adresse]"
    ElseIf lngPtrToPedAdrVal = 0 Then
        'no game in progress...
        isHasCar = False
        isHadCar = False
        isHasPlayer = False
    ElseIf (lngPtrToPedAdrVal <> lngPtrToCarAdrVal) And (lngPtrToCarAdrVal <> 0) Then
        'the camera has a different pointer than the player. check if the player has actually the same pointer or not:
        'lngLastCarAdr
        lngRetVal3 = ReadProcessMemory(lngPHandle, GTASAPlayerAddresse.lngLastCarAdr, lngPlayerCarPtr, 4&, 0&)
        'also get ready for the Hit Test for RC Cars:
        If isControlRCCars Then
            lngRetVal4 = ReadProcessMemory(lngPHandle, lngPtrToCarAdrVal + 34, intCarIDHitTest, 2&, 0&)
            If lngRetVal4 <> 0 Then
                '441 Rc Bandit '464 Rc Baron '594 Rc Cam '501 Rc Goblin
                '465 Rc Raider '564 Rc Tiger
                If (intCarIDHitTest = 441) Or (intCarIDHitTest = 464) Or (intCarIDHitTest = 594) Or (intCarIDHitTest = 501) Or _
                   (intCarIDHitTest = 465) Or (intCarIDHitTest = 564) Then
                    isHasRCCarNow = True
                End If
            End If
        End If
        If isHasRCCarNow Or ((lngRetVal3 <> 0) And (lngPlayerCarPtr <> 0) And (lngPlayerCarPtr = lngPtrToCarAdrVal)) Then
            isHasCar = True
            'player has now a car. check if this is still the same car or not:
            If lngPtrToCarAdrVal = tCurrCarAdr.lngObjectStart Then
                'still in the same car
                If Not tCurrCarAdr.isUsable Then tCurrCarAdr.isUsable = True
                'check the trailer status:
                lngTrailerPtr = 0: ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarTrailerAdr, lngTrailerPtr, 4&, 0&
                If lngTrailerPtr = 0 Then
                    tCurrTrailer.isUsable = False
                ElseIf lngTrailerPtr = tCurrTrailer.lngObjectStart Then
                    If Not tCurrTrailer.isUsable Then tCurrTrailer.isUsable = True
                Else
                    SetCarAdrEx tCurrTrailer, lngTrailerPtr
                    tCurrTrailer.isUsable = True
                    isHasNewCar = True
                    isHasNewTrailerOnly = True
                End If
                If chkCarDynamics(0).Value = 1 Then 'Lock Car DP/EP/BP/FP
                    '01111111 Del EP 127    '11101111 Del DP 239    '11110111 Del FP 247    '11111011 Del BP 251
                    '10000000 Set EP 128    '00010000 Set DP  16    '00001000 Set FP   8    '00000100 Set BP   4
                    'Integer at Offset 66:   1..111.. EP/NA/NA/DP/FP/BP/NA/NA
                    SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked) 'EP
                    SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked) 'DP
                    SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked) 'BP
                    SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked) 'FP
                    If tCurrTrailer.isUsable Then
                        SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked)
                        SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked)
                        SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked)
                        SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked)
                    End If
                    If chkCarSpecs(0).Value = vbChecked Then strBuffer = strBuffer & "+EP"
                    If chkCarSpecs(1).Value = vbChecked Then strBuffer = strBuffer & "+DP"
                    If chkCarSpecs(2).Value = vbChecked Then strBuffer = strBuffer & "+BP"
                    If chkCarSpecs(3).Value = vbChecked Then strBuffer = strBuffer & "+FP"
                    If Len(strBuffer) > 0 Then strBuffer = Mid$(strBuffer, 2) & ", "
                End If
                'Set PlayerDrivesWhichCar
                ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarIDAdr, intPlayerDrivesCar, 2&, 0&
                If (intPlayerDrivesCar >= 400) And (intPlayerDrivesCar <= 611) Then
                    If isHasRCCarNow Then
                        If Me.Caption <> "GTASA Control Center [Player Controls " & ParkedCars(intPlayerDrivesCar).strCarName & "]" Then Me.Caption = "GTASA Control Center [Player Controls " & ParkedCars(intPlayerDrivesCar).strCarName & "]"
                    Else
                        If Me.Caption <> "GTASA Control Center [Player in " & ParkedCars(intPlayerDrivesCar).strCarName & "]" Then Me.Caption = "GTASA Control Center [Player in " & ParkedCars(intPlayerDrivesCar).strCarName & "]"
                    End If
                    strCarType = ParkedCars(intPlayerDrivesCar).strCarType
                Else
                    'car not recognized
                    If Me.Caption <> "GTASA Control Center [Player in NonRecognized Car]" Then Me.Caption = "GTASA Control Center [Player in NonRecognized Car]"
                    strCarType = ""
                End If
            Else
                'player has a new car. go populate tCurrCarAdr:
                isHadCar = True
                PopulateCarAdrStructure lngPtrToCarAdrVal
                'Set PlayerDrivesWhichCar
                ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarIDAdr, intPlayerDrivesCar, 2&, 0&
                If (intPlayerDrivesCar >= 400) And (intPlayerDrivesCar <= 611) Then
                    If isHasRCCarNow Then
                        If Me.Caption <> "GTASA Control Center [Player Controls " & ParkedCars(intPlayerDrivesCar).strCarName & "]" Then Me.Caption = "GTASA Control Center [Player Controls " & ParkedCars(intPlayerDrivesCar).strCarName & "]"
                    Else
                        If Me.Caption <> "GTASA Control Center [Player in " & ParkedCars(intPlayerDrivesCar).strCarName & "]" Then Me.Caption = "GTASA Control Center [Player in " & ParkedCars(intPlayerDrivesCar).strCarName & "]"
                    End If
                    strCarType = ParkedCars(intPlayerDrivesCar).strCarType
                    If isHasFeedback Then OnScreenText ParkedCars(intPlayerDrivesCar).strCarName & " syncronized."
                Else
                    'car not recognized
                    If Me.Caption <> "GTASA Control Center [Player in NonRecognized Car]" Then Me.Caption = "GTASA Control Center [Player in NonRecognized Car]"
                    strCarType = ""
                End If
                isHasNewCar = True
            End If
        Else
            isHasCar = False
            If Me.Caption <> "GTASA Control Center [Player on Foot]" Then Me.Caption = "GTASA Control Center [Player on Foot]"
        End If
    ElseIf lngPtrToPedAdrVal = lngPtrToCarAdrVal Then
        isHasCar = False 'player is not in a car anymore.
        If isHadCar And isAutoLockCarDoors Then SetMemByte tCurrCarAdr.lngCarDoorAdr, 2 'Auto-lock CarDoors if wanted
        'set form caption as player is on Foot:
        If Me.Caption <> "GTASA Control Center [Player on Foot]" Then Me.Caption = "GTASA Control Center [Player on Foot]"
    End If
    If isHasNewCar Then
        isHasNewCar = False
        isHasNewTrailerOnly = False
        strBuffer = ""
        If chkCarDynamics(0).Value = 1 Then 'Lock Car DP/EP/BP/FP
            '01111111 Del EP 127    '11101111 Del DP 239    '11110111 Del FP 247    '11111011 Del BP 251
            '10000000 Set EP 128    '00010000 Set DP  16    '00001000 Set FP   8    '00000100 Set BP   4
            'Integer at Offset 66:   1..111.. EP/NA/NA/DP/FP/BP/NA/NA
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked) 'EP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked) 'DP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked) 'BP
            SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked) 'FP
            If tCurrTrailer.isUsable Then
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 7, (chkCarSpecs(0).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 4, (chkCarSpecs(1).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 2, (chkCarSpecs(2).Value = vbChecked)
                SetBitOnInteger tCurrTrailer.lngSpecialsAdr, 3, (chkCarSpecs(3).Value = vbChecked)
            End If
            If chkCarSpecs(0).Value = vbChecked Then strBuffer = strBuffer & "+EP"
            If chkCarSpecs(1).Value = vbChecked Then strBuffer = strBuffer & "+DP"
            If chkCarSpecs(2).Value = vbChecked Then strBuffer = strBuffer & "+BP"
            If chkCarSpecs(3).Value = vbChecked Then strBuffer = strBuffer & "+FP"
            If Len(strBuffer) > 0 Then strBuffer = Mid$(strBuffer, 2) & ", "
        End If
        If chkCarDynamics(4).Value = 1 Then
            'Change Car weight as needed:
            If Not (isHasNewTrailerOnly Or (strCarType = "boat")) Then SetCarWeight 'forget about it if this is a boat.
        End If
        If chkCarDynamics(5).Value = 1 Then
            'Paint Car
            If chkMajorLock.Value = 1 Then
                If Not isHasNewTrailerOnly Then SetMemByte tCurrCarAdr.lngCarColorAdr, CInt(picMajor.Tag)
                If tCurrTrailer.isUsable Then SetMemByte tCurrTrailer.lngCarColorAdr, CInt(picMajor.Tag)
            End If
            If chkMinorLock.Value = 1 Then
                If Not isHasNewTrailerOnly Then SetMemByte tCurrCarAdr.lngCarColorAdr + 1, CInt(picMinor.Tag)
                If tCurrTrailer.isUsable Then SetMemByte tCurrTrailer.lngCarColorAdr + 1, CInt(picMinor.Tag)
            End If
            strBuffer = strBuffer & "Painted, "
        End If
        If chkCarDynamics(6).Value = 1 Then 'Stop CarAlarm
            SetMemLong tCurrCarAdr.lngSirenTimeAdr, 0&
        End If
        If chkCarDynamics(10).Value = 1 Then 'Set License Plate:
            SetMemString tCurrCarAdr.lngLicensePlateAdr, sLicensePlate, 8
        End If
        If (Len(strBuffer) > 2) And (intPlayerDrivesCar >= 400) And (intPlayerDrivesCar <= 611) Then
            strBuffer = Left$(strBuffer, Len(strBuffer) - 2) & "."
            If isHasNewTrailerOnly Then
                strBuffer = "Trailer is now: " & strBuffer
            Else
                strBuffer = ParkedCars(intPlayerDrivesCar).strCarName & " is now: " & strBuffer
            End If
        Else
            strBuffer = ParkedCars(intPlayerDrivesCar).strCarName & " is synchronized."
        End If
        If isHasFeedback Then OnScreenText strBuffer
    End If
    isCheckingStatus = False
Exit Function
errCheckPlayerCarStatus:
    Err.Clear
    isCheckingStatus = False

End Function

Private Function PopulateCarAdrStructure(ByVal lngObjStart As Long) As Boolean '
On Error GoTo errPopulateCarAdrStructure
    PopulateCarAdrStructure = True
    'copy the tCurrCarAdr to tOldCarAdr:
    CopyMemory tOldCarAdr, tCurrCarAdr, Len(tCurrCarAdr)
    tOldCarAdr.isUsable = False
    'populate tCurrCarAdr:
    SetCarAdrEx tCurrCarAdr, lngObjStart
    'check if car has a trailer:
    ReadProcessMemory lngPHandle, tCurrCarAdr.lngCarTrailerAdr, lngReadBuffer, 4&, 0&
    If lngReadBuffer = 0 Then
        tCurrTrailer.isUsable = False
    Else
        SetCarAdrEx tCurrTrailer, lngReadBuffer
    End If
Exit Function
errPopulateCarAdrStructure:
    PopulateCarAdrStructure = False
    Err.Clear
    Resume Next
End Function

Private Function CheckCarIsUsable(ByRef tCarToCheck As GTASACarAdr) As Boolean
On Error GoTo errCheckCarIsUsable
    Static lngCarPosPtr As Long
    lngCarPosPtr = 0
    ReadProcessMemory lngPHandle, tCarToCheck.lngPositionPtr, lngCarPosPtr, 4&, 0& 'lngCarPosAdr is the value that is read from lngPositionPtr
    If lngCarPosPtr = tCarToCheck.lngCarPosAdr Then
        tCarToCheck.isUsable = True
        CheckCarIsUsable = True
    Else
        tCarToCheck.isUsable = False
        CheckCarIsUsable = False
    End If
Exit Function
errCheckCarIsUsable:
    Err.Clear
    CheckCarIsUsable = False
End Function

Private Function SetCarAdrEx(ByRef tAdrPtr As GTASACarAdr, ByVal lngObjStart As Long) As Boolean '
On Error GoTo errSetCarAdrEx
    Static intCarID As Integer
    Static lngPlateAdr As Long
    SetCarAdrEx = True
    With tAdrPtr
        .isUsable = True    'if this adr block actually and still belongs to a car or not (gtasa addresses cars and peds in the same manner!!)
        .lngObjectStart = lngObjStart   'this object start is equal to player object start if player is not in car !!!!
        .lngPositionPtr = lngObjStart + 20 'this is actually objectstart + 20 offset
        ReadProcessMemory lngPHandle, .lngPositionPtr, .lngCarPosAdr, 4&, 0& 'lngCarPosAdr is the value that is read from lngPositionPtr
        .lngCarLocAdr = .lngCarPosAdr + 48  'these values are calculated from lngPositionPtr with offsets
        .lngCarIDAdr = lngObjStart + 34 'integer, car type ID (400 to 611)
        .lngSpecialsAdr = lngObjStart + 66    'bit coded specials as integer will be read from this location (obj start + 66 offset)
        .lngCarSpeedAdr = lngObjStart + 68 'objstart + 68
        .lngCarSpinAdr = lngObjStart + 80     'objstart + 80
        .lngCarWeightAdr = lngObjStart + 140   'objstart + 140
        .lngBikeWheelAdr = lngObjStart + 1630   'objstart + vc:812???
        .lngStalledAdr = lngObjStart + 1064   'objstart + 1064
        .lngCarColorAdr = lngObjStart + 1076    'objstart + 1076
        .lngSirenTimeAdr = lngObjStart + 1116   'objstart + 1116
        .lngCarDamageAdr = lngObjStart + 1216   'objstart + 1216
        .lngCarTrailerAdr = lngObjStart + 1224  'objstart + 1224
        .lngCarDoorAdr = lngObjStart + 1272     'objstart + 1272
        .lngCarWheelAdr = lngObjStart + 1444    'objstart + 1444
        .lngBurnTimerAdr = lngObjStart + 2276   'float in ms that counts up until car explodes
        .lngCarDetachPosAdr(0) = lngObjStart + 1828
        .lngCarDetachPosAdr(1) = lngObjStart + 1872
        .lngCarDetachPosAdr(2) = lngObjStart + 1916
        .lngCarDetachPosAdr(3) = lngObjStart + 1960
        .lngBikeDetachPosAdr(0) = lngObjStart + 1532
        .lngBikeDetachPosAdr(1) = lngObjStart + 1632
        .lngBikeDetachPosAdr(2) = lngObjStart + 1676
        .lngBikeDetachPosAdr(3) = lngObjStart + 1720
        .lngBikeDetachPosAdr(4) = lngObjStart + 1764
        'get license plate adr:
        .lngLicensePlateAdr = lngObjStart + 1416 'objstart + 1416 -> read value + 16
        ReadProcessMemory lngPHandle, .lngLicensePlateAdr, lngPlateAdr, 4&, 0&
         .lngLicensePlateAdr = lngPlateAdr + 16
        'read car id to compare for isRCCar:
        ReadProcessMemory lngPHandle, .lngCarIDAdr, intCarID, 2&, 0&
        If (intCarID = 441) Or (intCarID = 464) Or (intCarID = 594) Or (intCarID = 501) Or _
           (intCarID = 465) Or (intCarID = 564) Then
            .isRCCar = True
        Else
            .isRCCar = False
        End If
    End With

Exit Function
errSetCarAdrEx:
    Err.Clear
    SetCarAdrEx = False
    Resume Next
End Function

Private Function GetNode(ByVal sKey As String, _
                         Optional ByVal isTVLocation As Boolean = False, _
                         Optional ByVal isTVCheat As Boolean = False, _
                         Optional ByVal isTVShortcut As Boolean = False) As Node
On Error GoTo errGetNode
Static iNodeCtr As Long
    If isTVLocation Then
        If tvLocations.Nodes.Count = 0 Then Exit Function
        For iNodeCtr = 1 To tvLocations.Nodes.Count
            If tvLocations.Nodes(iNodeCtr).Key = sKey Then
                Set GetNode = tvLocations.Nodes(iNodeCtr)
                Exit For
            End If
        Next iNodeCtr
    ElseIf isTVCheat Then
        If tvCheats.Nodes.Count = 0 Then Exit Function
        For iNodeCtr = 1 To tvCheats.Nodes.Count
            If tvCheats.Nodes(iNodeCtr).Key = sKey Then
                Set GetNode = tvCheats.Nodes(iNodeCtr)
                Exit For
            End If
        Next iNodeCtr
    ElseIf isTVShortcut Then
        If tvShotcuts.Nodes.Count = 0 Then Exit Function
        For iNodeCtr = 1 To tvShotcuts.Nodes.Count
            If tvShotcuts.Nodes(iNodeCtr).Key = sKey Then
                Set GetNode = tvShotcuts.Nodes(iNodeCtr)
                Exit For
            End If
        Next iNodeCtr
    Else
    End If

Exit Function
errGetNode:
    If isGTASAiconic Then MsgBox Err.Description
    Err.Clear
End Function

Private Function FillInTreeviews(Optional ByVal isCheats As Boolean = True, _
                                 Optional ByVal isLocations As Boolean = True, _
                                 Optional ByVal isShortcuts As Boolean = True) As Boolean '
On Error GoTo errTreeViews
    Dim iTvCtr As Long
    Dim iKeyCtr As Long
    Dim oParent As Node
    Dim oRoot As Node
    Dim oNode As Node
    Dim sKeys() As String
    Dim sKey As String
    'cheats:
    If isCheats Then
        tvCheats.Nodes.Clear
        For iTvCtr = 1 To GTASACheats.CheatCount
            With GTASACheats(iTvCtr)
                sKeys = Split(.sFolder, "\")
                If UBound(sKeys) > -1 Then
                    Set oNode = Nothing
                    Set oParent = Nothing
                    sKey = ""
                    For iKeyCtr = 0 To UBound(sKeys)
                        sKey = sKey & IIf(Len(sKey) > 0, "\", "") & Replace(sKeys(iKeyCtr), " ", "_")
                        Err.Clear
                        Set oNode = GetNode(sKey, False, True, False) ' tvCheats.Nodes(sKey)
                        If Not oNode Is Nothing Then 'folder exists
                            Set oParent = oNode
                        Else 'add folder:
                            If oParent Is Nothing Then 'add as root:
                                Set oNode = tvCheats.Nodes.Add(, , sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                Set oParent = oNode
                            Else 'add as folder under node
                                Set oNode = tvCheats.Nodes.Add(oParent.Key, tvwChild, sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                oNode.ExpandedImage = 2
                                Set oParent = oNode
                            End If
                        End If
                    Next iKeyCtr
                    If Not oParent Is Nothing Then
                        Set oNode = tvCheats.Nodes.Add(oParent.Key, tvwChild, Replace(.sFolder, " ", "_") & "\" & .sUID & CLng(Rnd * 10000), .sDescription, 4)
                        oNode.Tag = .sUID
                    End If
                End If
            End With
        Next iTvCtr
        If tvCheats.Nodes.Count = 0 Then tvCheats.Nodes.Add(, , "root", "GTA San Andreas Cheats", 1).Tag = "folder"        'root node does not exist
        With tvCheats
            .Nodes(1).Expanded = True
            .Nodes(1).EnsureVisible
            .SelectedItem = .Nodes(1)
        End With
    End If
    'Locations:
    If isLocations Then
        tvLocations.Nodes.Clear
        For iTvCtr = 1 To GTASAWarpLocs.WarpLocCount
            With GTASAWarpLocs(iTvCtr)
                sKeys = Split(.sFolder, "\")
                If UBound(sKeys) > -1 Then
                    Set oNode = Nothing
                    Set oParent = Nothing
                    sKey = ""
                    For iKeyCtr = 0 To UBound(sKeys)
                        sKey = sKey & IIf(Len(sKey) > 0, "\", "") & Replace(sKeys(iKeyCtr), " ", "_")
                        Err.Clear
                        Set oNode = GetNode(sKey, True, False, False) ' tvLocations.Nodes(sKey)
                        If Not oNode Is Nothing Then 'folder exists
                            Set oParent = oNode
                        Else 'add folder:
                            If oParent Is Nothing Then 'add as root:
                                Set oNode = tvLocations.Nodes.Add(, , sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                Set oParent = oNode
                            Else 'add as folder under node
                                Set oNode = tvLocations.Nodes.Add(oParent.Key, tvwChild, sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                oNode.ExpandedImage = 2
                                Set oParent = oNode
                            End If
                        End If
                    Next iKeyCtr
                    If Not oParent Is Nothing Then
                        Set oNode = tvLocations.Nodes.Add(oParent.Key, tvwChild, Replace(.sFolder, " ", "_") & "\" & .sUID & CLng(Rnd * 10000), .sDescription, 3)
                        oNode.Tag = .sUID
                    End If
                End If
            End With
        Next iTvCtr
        If tvLocations.Nodes.Count = 0 Then tvLocations.Nodes.Add(, , "root", "GTA San Andreas Teleport Locations", 1).Tag = "folder"        'root node does not exist
        With tvLocations
            .Nodes(1).Expanded = True
            .Nodes(1).EnsureVisible
            .SelectedItem = .Nodes(1)
        End With
    End If
    'Shortcuts:
    If isShortcuts Then
        tvShotcuts.Nodes.Clear
        For iTvCtr = 1 To GTASAShortcuts.ShortcutCount
            With GTASAShortcuts(iTvCtr)
                sKeys = Split(.sFolder, "\")
                If UBound(sKeys) > -1 Then
                    Set oNode = Nothing
                    Set oParent = Nothing
                    sKey = ""
                    For iKeyCtr = 0 To UBound(sKeys)
                        sKey = sKey & IIf(Len(sKey) > 0, "\", "") & Replace(sKeys(iKeyCtr), " ", "_")
                        Err.Clear
                        Set oNode = GetNode(sKey, False, False, True) ' tvShotcuts.Nodes(sKey)
                        If Not oNode Is Nothing Then 'folder exists
                            Set oParent = oNode
                        Else 'add folder:
                            If oParent Is Nothing Then 'add as root:
                                Set oNode = tvShotcuts.Nodes.Add(, , sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                Set oParent = oNode
                            Else 'add as folder under node
                                Set oNode = tvShotcuts.Nodes.Add(oParent.Key, tvwChild, sKey, sKeys(iKeyCtr), 1)
                                oNode.Tag = "folder"
                                oNode.Sorted = True
                                oNode.ExpandedImage = 2
                                Set oParent = oNode
                            End If
                        End If
                    Next iKeyCtr
                    If Not oParent Is Nothing Then
                        Set oNode = tvShotcuts.Nodes.Add(oParent.Key, tvwChild, Replace(.sFolder, " ", "_") & "\" & .sUID & CLng(Rnd * 10000), .sDescription, IIf(.isActive, 6, 5))
                        oNode.Tag = .sUID
                    End If
                End If
            End With
        Next iTvCtr
        If tvShotcuts.Nodes.Count = 0 Then tvShotcuts.Nodes.Add(, , "root", "GTA SA Control Center Keyboard Shortcuts", 1).Tag = "folder"                   'root node does not exist
        With tvShotcuts
            .Nodes(1).Expanded = True
            .Nodes(1).EnsureVisible
            .SelectedItem = .Nodes(1)
        End With
    End If
Exit Function
errTreeViews:
    If Err.Number = 35601 Then
        Err.Clear
        Set oNode = Nothing
        Resume Next
    Else
        If isGTASAiconic Then MsgBox Err.Description
        Err.Clear
    End If
End Function

Private Function ReFillPlayerAdr() As Boolean
On Error GoTo errReFillPlayerAdr
    Static lngPlayerRead As Long
    Static lngPosRead As Long
    Static lngPlayerReadSuccess As Long
    Static sPlayerSpecsCap As String
    Static iStatCtr As Long
    ReFillPlayerAdr = False
    If (Not isHasHandle) Or (lngPHandle = 0) Then Exit Function 'thereby return false
    lngPlayerReadSuccess = ReadProcessMemory(lngPHandle, GTASABaseAdr.PlayerAdr, lngPlayerRead, 4, 0&)
    If lngPlayerReadSuccess = 0 Or lngPlayerRead = 0 Then
        'let the function return false
    Else
        'We have a player
        isHasPlayer = True
        'assign player information:
        GTASAPlayerAddresse.lngObjectStart = lngPlayerRead
        GTASAPlayerAddresse.lngPositionPtr = lngPlayerRead + 20
        GTASAPlayerAddresse.lngSpecialsAdr = lngPlayerRead + 66 'byte, bit coded for BPDPEPFP
        GTASAPlayerAddresse.lngPedSpeedAdr = lngPlayerRead + 68
        GTASAPlayerAddresse.lngHealthAdr = lngPlayerRead + 1344
        GTASAPlayerAddresse.lngMaxHealthAdr = lngPlayerRead + 1348
        GTASAPlayerAddresse.lngArmorAdr = lngPlayerRead + 1352
        GTASAPlayerAddresse.lngAngleAdr = lngPlayerRead + 1372
        GTASAPlayerAddresse.lngLastCarAdr = lngPlayerRead + 1420
        GTASAPlayerAddresse.lngBrassKnucklesAdr = lngPlayerRead + 1440
        For iStatCtr = 0 To 10
            GTASAPlayerAddresse.lngWeaponsAdr(iStatCtr) = lngPlayerRead + 1468 + (iStatCtr * 28)
        Next iStatCtr
        GTASAPlayerAddresse.lngDetonatorAdr = lngPlayerRead + 1776
        GTASAPlayerAddresse.lngWeaponSlotAdr = lngPlayerRead + 1816
        GTASAPlayerAddresse.lngWeaponIDAdr = lngPlayerRead + 1856
        'read and assign position information:
        lngPlayerReadSuccess = ReadProcessMemory(lngPHandle, GTASAPlayerAddresse.lngPositionPtr, lngPosRead, 4, 0&)
        If lngPlayerReadSuccess = 0 Or lngPosRead = 0 Then
            'let the function return false
            isHasPlayer = False
        Else
            GTASAPlayerAddresse.lngPlayerPosAdr = lngPosRead
            GTASAPlayerAddresse.lngXposAdr = lngPosRead + 48
            GTASAPlayerAddresse.lngYposAdr = lngPosRead + 52
            GTASAPlayerAddresse.lngZposAdr = lngPosRead + 56
            ReFillPlayerAdr = True
        End If
        If isFixPed Then
            SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 7, (chkPedSpecs(0).Value = vbChecked)
            SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 6, (chkPedSpecs(1).Value = vbChecked)
            SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 2, (chkPedSpecs(2).Value = vbChecked)
            SetBitOnInteger GTASAPlayerAddresse.lngSpecialsAdr, 3, (chkPedSpecs(3).Value = vbChecked)
            'Show Ped Specialities:
            sPlayerSpecsCap = "Current Player: " & IIf(chkPedSpecs(0).Value = vbChecked, "EP", "") & IIf(chkPedSpecs(1).Value = vbChecked, "+DP", "") & IIf(chkPedSpecs(2).Value = vbChecked, "+BP", "") & IIf(chkPedSpecs(3).Value = vbChecked, "+FP", "")
            If sPlayerSpecsCap = "Current Player: " Then sPlayerSpecsCap = "Current Player: No Specialities"
            If lblCurrentPlayer.Caption <> sPlayerSpecsCap Then lblCurrentPlayer.Caption = sPlayerSpecsCap
        End If
    End If
Exit Function
errReFillPlayerAdr:
    ReFillPlayerAdr = False
    Err.Clear
End Function

'**********************************************************************************************************
'                                   Location Map Related
'**********************************************************************************************************

Private Sub cLocLabel_MouseUp(Index As Integer, Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    Dim iNodeCtr As Integer
    For iNodeCtr = 1 To tvLocations.Nodes.Count
        If tvLocations.Nodes(iNodeCtr).Tag = cLocLabel(Index).Tag Then
            Set tvLocations.SelectedItem = tvLocations.Nodes(iNodeCtr)
            tvLocations.SelectedItem.EnsureVisible
            If tvLocations.SelectedItem.Tag <> "folder" Then
                txtCoords(0).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(0)
                txtCoords(1).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(1)
                txtCoords(2).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(2)
                txtCoords(3).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(3)
            End If
        End If
    Next iNodeCtr
    If Button = vbRightButton Then
        Me.PopupMenu mLocLabel
    End If
End Sub

Private Sub cPlayerLoc_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Button = vbRightButton Then
        Me.PopupMenu mPlayerLoc
    End If
End Sub

Private Sub cManualLoc_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Button = vbRightButton Then
        Me.PopupMenu mManualLoc
    End If
End Sub

Private Sub imgMap_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Button = vbRightButton Then
        Me.PopupMenu mZoomContext
    ElseIf Button = vbLeftButton Then
        'bring bluebox to here
        cManualLoc.Move (x / Screen.TwipsPerPixelX) - (cManualLoc.Width / 2), (y / Screen.TwipsPerPixelY) - (cManualLoc.Height / 2)
        cManualLoc.Visible = True
    End If
End Sub

Private Sub sldZoom_Change()
On Error Resume Next
    'change map zoom level, and replace controls
    sZoomLevel = sldZoom.Value / 100
    lblConsole(22).Caption = "Zoom (" & sldZoom.Value & "%)"
    ReplaceMap
End Sub

Private Sub txtCoords_Validate(Index As Integer, Cancel As Boolean)
On Error Resume Next
    txtCoords(Index).Text = Replace(txtCoords(Index).Text, ",", ".")
End Sub

Private Sub umnuLocBox_Click(Index As Integer)
On Error Resume Next
    Static iBoxCtr As Integer
    Select Case Index
        Case 0: iLocBoxSize = 8
        Case 1: iLocBoxSize = 12
        Case 2: iLocBoxSize = 16
    End Select
    For iBoxCtr = 0 To 2
        umnuLocBox(iBoxCtr).Checked = (iBoxCtr = Index)
    Next iBoxCtr
    'resize all location boxes:
    For iBoxCtr = 0 To cLocLabel.UBound
        cLocLabel(iBoxCtr).Width = iLocBoxSize
        cLocLabel(iBoxCtr).Height = iLocBoxSize
    Next iBoxCtr
    'resize manual loc and player loc boxes:
    cManualLoc.Width = iLocBoxSize
    cManualLoc.Height = iLocBoxSize
    cPlayerLoc.Width = iLocBoxSize
    cPlayerLoc.Height = iLocBoxSize
End Sub

Private Sub uPlayerLoc_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0
            ReadLocData
    End Select
End Sub

Private Sub uLocLabel_Click(Index As Integer)
On Error Resume Next 'as this menu opens, we have already one selected cLocLabel (or at least we should :)
    Select Case Index
        Case 0 'read object coordinates:
            If tvLocations.SelectedItem Is Nothing Then
            Else
                If tvLocations.SelectedItem.Tag <> "folder" Then
                    txtCoords(0).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(0)
                    txtCoords(1).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(1)
                    txtCoords(2).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(2)
                    txtCoords(3).Text = GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).GetLocation(3)
                End If
            End If
        Case 2
            PasteWarpLoc 0, GTASAWarpLocs.GetItemByUID(tvLocations.SelectedItem.Tag).sLocData
    End Select
End Sub

Private Sub uManualLoc_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0
            Call cmdMapLoc_Click(1)
        Case 2
            Call cmdMapLoc_Click(1)
            PasteWarpLoc 0, txtCoords(0).Text & ";" & txtCoords(1).Text & ";" & txtCoords(2).Text & ";" & txtCoords(3).Text
    End Select

End Sub

Private Sub umnuZoom_Click(Index As Integer)
On Error Resume Next
    If Index = 0 Then
        'hide all locations:
        RemoveLocBoxes
    End If
End Sub

Private Sub umnuZoomMap_Click(Index As Integer)
On Error Resume Next 'change map zoom slider level (%)
    Select Case Index
        Case 0: sldZoom.Value = 50
        Case 1: sldZoom.Value = 100
        Case 2: sldZoom.Value = 150
        Case 3: sldZoom.Value = 200
        Case 4: sldZoom.Value = 300
        Case 5: sldZoom.Value = 400
    End Select
End Sub

Private Sub scrLeftRight_Change()
On Error Resume Next
    Static isInternalScroll As Boolean
    If isInternalScroll Then Exit Sub
    sngXOffset = sngXOffset + scrLeftRight.Value
    If sngXOffset > sngMaxOffsetX Then sngXOffset = sngMaxOffsetX
    If sngXOffset < sngMinOffsetX Then sngXOffset = sngMinOffsetX
    isInternalScroll = True
    scrLeftRight.Value = 0
    isInternalScroll = False
    If picMapHolder.ScaleWidth >= imgMap.Width Then sngXOffset = 0
    MoveMap
End Sub

Private Sub scrTopBottom_Change()
On Error Resume Next
    Static isInternalScroll As Boolean
    If isInternalScroll Then Exit Sub
    sngYOffset = sngYOffset + scrTopBottom.Value
    If sngYOffset > sngMaxOffsetY Then sngYOffset = sngMaxOffsetY
    If sngYOffset < sngMinOffsetY Then sngYOffset = sngMinOffsetY
    isInternalScroll = True
    scrTopBottom.Value = 0
    isInternalScroll = False
    If picMapHolder.ScaleHeight >= imgMap.Height Then sngYOffset = 0
    MoveMap
End Sub

Private Sub cmdMapLoc_Click(Index As Integer)
On Error Resume Next
    Select Case Index
        Case 0 'set bluebox on map
            cManualLoc.Left = ((sZoomLevel * (MakeSingle(txtCoords(0).Text) + 3000&)) / sngPixToGTA) - (iLocBoxSize / 2)
            cManualLoc.Top = ((sZoomLevel * (3000& - MakeSingle(txtCoords(1).Text))) / sngPixToGTA) - (iLocBoxSize / 2)
            cManualLoc.Visible = True
        Case 1 'get bluebox from map
            txtCoords(0).Text = Replace(Format(-3000& + sngPixToGTA * (cManualLoc.Left + (iLocBoxSize / 2)) / sZoomLevel, "#0.00"), ",", ".") 'X Coord
            txtCoords(1).Text = Replace(Format(3000& - sngPixToGTA * (cManualLoc.Top + (iLocBoxSize / 2)) / sZoomLevel, "#0.00"), ",", ".") 'Y Coord
            If txtCoords(2).Text = "" Then txtCoords(2).Text = 100 'Z Coord
            If txtCoords(3).Text = "" Then txtCoords(3).Text = 90  'Angle
    End Select
    cManualLoc.Visible = True
End Sub

Private Sub picMap_MouseUp(Button As Integer, Shift As Integer, x As Single, y As Single)
On Error Resume Next
    If Button = vbRightButton Then
        Me.PopupMenu mZoomContext
    End If
End Sub

Private Sub cmdCenterMap_Click()
On Error Resume Next
    sngXOffset = 0
    sngYOffset = 0
    MoveMap
    If isGTASAiconic And Not isTimerClick Then txtFocus.SetFocus
End Sub

Private Function AddLocBox(ByVal sUID As String, ByVal sText As String, Optional ByVal isShowOnMap As Boolean = True) As Boolean
On Error GoTo errAddLocBox
    Static iCtlCount As Integer
    Static sngXcoord As Single
    Static sngYcoord As Single
    AddLocBox = False
    iCtlCount = cLocLabel.UBound + 1
    Load cLocLabel(iCtlCount)
    cLocLabel(iCtlCount).Container = cLocLabel(0).Container
    cLocLabel(iCtlCount).Tag = sUID
    cLocLabel(iCtlCount).ToolTipText = sText
    sngXcoord = (3000 + GTASAWarpLocs.GetItemByUID(sUID).fXCoord) / 6000
    sngYcoord = (3000 + GTASAWarpLocs.GetItemByUID(sUID).fYCoord) / 6000
    'calculate and assign X (-3000 to 3000 is 0 to imgMap.width):
    'x+3000 is 0 to 6000, is 0 to imgMap.width
    cLocLabel(iCtlCount).Left = (sngXcoord * imgMap.Width) - (iLocBoxSize / 2)
    'calculate and assign Y (3000 to -3000 is 0 to imgMap.height):
    'y+3000 is 6000 to 0, is 0 to imgMap.height
    cLocLabel(iCtlCount).Top = (imgMap.Height - (sngYcoord * imgMap.Height)) - (iLocBoxSize / 2)
    cLocLabel(iCtlCount).ZOrder 0
    cLocLabel(iCtlCount).Visible = True
    If isShowOnMap Then
        'prepare offsets to show on map
        sngXOffset = GTASAWarpLocs.GetItemByUID(sUID).fXCoord
        sngYOffset = GTASAWarpLocs.GetItemByUID(sUID).fYCoord
        CalcMapOffsets False
        MoveMap
        For sngXcoord = 1 To 2
            cLocLabel(iCtlCount).Width = iLocBoxSize * 2
            cLocLabel(iCtlCount).Height = iLocBoxSize * 2
            For sngYcoord = 1 To 20: Sleep 10: DoEvents: Next sngYcoord
            cLocLabel(iCtlCount).Width = iLocBoxSize
            cLocLabel(iCtlCount).Height = iLocBoxSize
            For sngYcoord = 1 To 20: Sleep 10: DoEvents: Next sngYcoord
        Next sngXcoord
        DoEvents
    End If
    AddLocBox = True
Exit Function
errAddLocBox:
    MsgBox Err.Description, vbCritical
    Err.Clear
End Function

Private Function RemoveLocBoxes() As Boolean
On Error Resume Next
    Static iCtlCount As Integer
    Static iCtlCtr As Integer
    iCtlCount = cLocLabel.UBound
    For iCtlCtr = iCtlCount To 1 Step -1
        Unload cLocLabel(iCtlCtr)
    Next iCtlCtr
End Function

Private Function ReplaceMap() As Boolean
On Error Resume Next
    Static iCtlCount As Integer
    Static sngXcoord As Single
    Static sngYcoord As Single
    'replaces map and all belonging objects
    'sZoomLevel
    imgMap.Width = 900 * sZoomLevel
    imgMap.Height = 900 * sZoomLevel
    CalcMapOffsets
    MoveMap
    For iCtlCount = 1 To cLocLabel.UBound
        If cLocLabel(iCtlCount).Tag <> "" Then
            sngXcoord = (3000 + GTASAWarpLocs.GetItemByUID(cLocLabel(iCtlCount).Tag).fXCoord) / 6000
            sngYcoord = (3000 + GTASAWarpLocs.GetItemByUID(cLocLabel(iCtlCount).Tag).fYCoord) / 6000
            'calculate and assign X (-3000 to 3000 is 0 to imgMap.width):
            'x+3000 is 0 to 6000, is 0 to imgMap.width
            cLocLabel(iCtlCount).Left = (sngXcoord * imgMap.Width) - (iLocBoxSize / 2)
            'calculate and assign Y (3000 to -3000 is 0 to imgMap.height):
            'y+3000 is 6000 to 0, is 0 to imgMap.height
            cLocLabel(iCtlCount).Top = (imgMap.Height - (sngYcoord * imgMap.Height)) - (iLocBoxSize / 2)
        End If
    Next iCtlCount
    If isHasHandle And isHasPlayer Then
        cPlayerLoc.Left = ((sZoomLevel * (GetMemFloat(GTASAPlayerAddresse.lngXposAdr) + 3000&)) / sngPixToGTA) - (iLocBoxSize / 2)
        cPlayerLoc.Top = ((sZoomLevel * (3000& - GetMemFloat(GTASAPlayerAddresse.lngYposAdr))) / sngPixToGTA) - (iLocBoxSize / 2)
        cPlayerLoc.Visible = True
    End If
    cManualLoc.Visible = False
End Function

Private Function MoveMap() As Boolean
On Error Resume Next
    'we will move picMap, so that sngXOffset and  sngYOffset
    'will center the showing / showable map
    picMap.Left = -(sngXOffset * sngGTAtoPix) - ((imgMap.Width - picMapHolder.ScaleWidth) / 2)
    picMap.Top = (sngYOffset * sngGTAtoPix) - ((imgMap.Height - picMapHolder.ScaleHeight) / 2)
End Function

Private Function CalcMapOffsets(Optional ByVal isReCalcAll As Boolean = True) As Boolean
On Error Resume Next
    If isReCalcAll Then
        sngPixToGTA = (sZoomLevel * 6000) / imgMap.Width
        sngGTAtoPix = imgMap.Height / (sZoomLevel * 6000)
        sngMinOffsetX = sngPixToGTA * ((picMapHolder.ScaleWidth - imgMap.Width) / 2)
        sngMaxOffsetY = sngPixToGTA * ((imgMap.Height - picMapHolder.ScaleHeight) / 2)
        sngMaxOffsetX = -sngMinOffsetX
        sngMinOffsetY = -sngMaxOffsetY
    End If
    If sngYOffset > sngMaxOffsetY Then sngYOffset = sngMaxOffsetY
    If sngYOffset < sngMinOffsetY Then sngYOffset = sngMinOffsetY
    If sngXOffset > sngMaxOffsetX Then sngXOffset = sngMaxOffsetX
    If sngXOffset < sngMinOffsetX Then sngXOffset = sngMinOffsetX
    If picMapHolder.ScaleWidth >= imgMap.Width Then sngXOffset = 0
    If picMapHolder.ScaleHeight >= imgMap.Height Then sngYOffset = 0
End Function

Private Sub umnuCheat_Click(Index As Integer)
On Error Resume Next
    Static sSelectedPath As String
    Static iKeyCtr As Integer
    Select Case Index
        Case 0
            tvCheats.StartLabelEdit
        Case 1
            If tvCheats.SelectedItem Is Nothing Then
                MsgBox "No Cheat has been selected to move", vbInformation
            Else
                If tvCheats.SelectedItem.Parent Is Nothing Then
                    MsgBox "You cannot move Root Folder", vbInformation
                Else
                    Load frmSelectFolder
                    frmSelectFolder.FillInFolders tvCheats
                    frmSelectFolder.Show vbModal, Me
                    DoEvents
                    If frmSelectFolder.isOKClicked Then
                        'find the key of selected full-path:
                        sSelectedPath = frmSelectFolder.lstFolders.list(frmSelectFolder.lstFolders.ListIndex)
                        For iKeyCtr = 1 To tvCheats.Nodes.Count
                            If tvCheats.Nodes(iKeyCtr).FullPath = sSelectedPath Then
                                Set tvCheats.SelectedItem.Parent = tvCheats.Nodes(iKeyCtr)
                                tvCheats.Nodes(iKeyCtr).Sorted = True
                                Exit For
                            End If
                        Next iKeyCtr
                        isDirty(0) = True
                    End If
                    Unload frmSelectFolder
                End If
            End If
    End Select
End Sub

Private Sub umnuShortcut_Click(Index As Integer)
On Error Resume Next
    Static sSelectedPath As String
    Static iKeyCtr As Integer
    Select Case Index
        Case 0
            tvShotcuts.StartLabelEdit
        Case 1
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "No Shortcut has been selected to move", vbInformation
            Else
                If tvShotcuts.SelectedItem.Parent Is Nothing Then
                    MsgBox "You cannot move Root Folder", vbInformation
                Else
                    Load frmSelectFolder
                    frmSelectFolder.FillInFolders tvShotcuts
                    frmSelectFolder.Show vbModal, Me
                    DoEvents
                    If frmSelectFolder.isOKClicked Then
                        'find the key of selected full-path:
                        sSelectedPath = frmSelectFolder.lstFolders.list(frmSelectFolder.lstFolders.ListIndex)
                        For iKeyCtr = 1 To tvShotcuts.Nodes.Count
                            If tvShotcuts.Nodes(iKeyCtr).FullPath = sSelectedPath Then
                                Set tvShotcuts.SelectedItem.Parent = tvShotcuts.Nodes(iKeyCtr)
                                tvShotcuts.Nodes(iKeyCtr).Sorted = True
                                Exit For
                            End If
                        Next iKeyCtr
                        isDirty(2) = True
                    End If
                    Unload frmSelectFolder
                End If
            End If
        Case 2 '-----
        Case 3, 4 'Activate / Deactivate
            If tvShotcuts.SelectedItem Is Nothing Then
                MsgBox "No Shortcut has been selected to " & IIf(Index = 3, "activate", "deactivate"), vbInformation
            Else
                If tvShotcuts.SelectedItem.Tag = "folder" Then
                    If MsgBox(IIf(Index = 3, "Activate", "Deactivate") & " all Items in this folder?", vbQuestion + vbYesNoCancel + vbDefaultButton2) = vbYes Then
                        For iKeyCtr = 1 To tvShotcuts.Nodes.Count
                            If tvShotcuts.Nodes(iKeyCtr).Parent Is Nothing Then
                            ElseIf tvShotcuts.Nodes(iKeyCtr).Parent = tvShotcuts.SelectedItem Then
                                If tvShotcuts.Nodes(iKeyCtr).Tag <> "folder" Then
                                    GTASAShortcuts.GetItemByUID(tvShotcuts.Nodes(iKeyCtr).Tag).isActive = (Index = 3)
                                    tvShotcuts.Nodes(iKeyCtr).Image = IIf(Index = 3, 6, 5) '6:active / 5:inactive
                                End If
                            End If
                        Next iKeyCtr
                        isDirty(2) = True
                    End If
                Else
                    GTASAShortcuts.GetItemByUID(tvShotcuts.SelectedItem.Tag).isActive = (Index = 3)
                    tvShotcuts.SelectedItem.Image = IIf(Index = 3, 6, 5) '6:active / 5:inactive
                    isDirty(2) = True
                End If
            End If
    End Select
End Sub

Private Sub umnuLocation_Click(Index As Integer)
On Error Resume Next
    Static sSelectedPath As String
    Static iKeyCtr As Integer
    Select Case Index
        Case 0 'edit label
            tvLocations.StartLabelEdit
        Case 1 'move to folder
            If tvLocations.SelectedItem Is Nothing Then
                MsgBox "No Location has been selected to move", vbInformation
            Else
                If tvLocations.SelectedItem.Parent Is Nothing Then
                    MsgBox "You cannot move Root Folder", vbInformation
                Else
                    Load frmSelectFolder
                    frmSelectFolder.FillInFolders tvLocations
                    frmSelectFolder.Show vbModal, Me
                    DoEvents
                    If frmSelectFolder.isOKClicked Then
                        'find the key of selected full-path:
                        sSelectedPath = frmSelectFolder.lstFolders.list(frmSelectFolder.lstFolders.ListIndex)
                        For iKeyCtr = 1 To tvLocations.Nodes.Count
                            If tvLocations.Nodes(iKeyCtr).FullPath = sSelectedPath Then
                                Set tvLocations.SelectedItem.Parent = tvLocations.Nodes(iKeyCtr)
                                tvLocations.Nodes(iKeyCtr).Sorted = True
                                Exit For
                            End If
                        Next iKeyCtr
                        isDirty(1) = True
                    End If
                    Unload frmSelectFolder
                End If
            End If
        'case 2 '-----
        Case 3
            'show location(s) on map
            If Not tvLocations.SelectedItem Is Nothing Then
                If tvLocations.SelectedItem.Tag = "folder" Then
                    For iKeyCtr = 1 To tvLocations.Nodes.Count
                        If tvLocations.Nodes(iKeyCtr).Parent Is Nothing Then
                        ElseIf tvLocations.Nodes(iKeyCtr).Parent = tvLocations.SelectedItem Then
                            If tvLocations.Nodes(iKeyCtr).Tag <> "folder" Then
                                AddLocBox tvLocations.Nodes(iKeyCtr).Tag, tvLocations.Nodes(iKeyCtr).Text, False
                            End If
                        End If
                    Next iKeyCtr
                Else
                    AddLocBox tvLocations.SelectedItem.Tag, tvLocations.SelectedItem.Text
                End If
            End If
    End Select
End Sub

Private Sub SetBitOnInteger(ByVal iAdr As Long, ByVal iBitOffset As Long, ByVal isSetON As Boolean)
On Error Resume Next
    Static intBitOPBuffer As Integer
    'read the value as integer:
    ReadProcessMemory lngPHandle, iAdr, intBitOPBuffer, 2&, 0&
    If isSetON Then
        intBitOPBuffer = intBitOPBuffer Or CLng(2 ^ iBitOffset)
    Else
        intBitOPBuffer = intBitOPBuffer And CLng(255 - (2 ^ iBitOffset))
    End If
    WriteProcessMemory lngPHandle, iAdr, intBitOPBuffer, 2&, 2&
    
End Sub

Private Sub SetMemByte(ByVal iAdr As Long, ByVal bVal As Byte)
On Error Resume Next
    WriteProcessMemory lngPHandle, iAdr, bVal, 1&, 1&
End Sub

Private Sub SetMemLong(ByVal iAdr As Long, ByVal lVal As Long)
On Error Resume Next
    WriteProcessMemory lngPHandle, iAdr, lVal, 4&, 4&
End Sub

Private Sub SetMemInt(ByVal iAdr As Long, ByVal iVal As Integer)
On Error Resume Next
    WriteProcessMemory lngPHandle, iAdr, iVal, 2&, 2&
End Sub

Private Sub SetMemFloat(ByVal iAdr As Long, ByVal fVal As Single)
On Error Resume Next
    WriteProcessMemory lngPHandle, iAdr, fVal, 4&, 4&
End Sub

Private Sub SetMemString(ByVal iAdr As Long, ByVal sVal As String, ByVal iLenght As Integer)
On Error Resume Next
    Dim iByteCtr As Long
    Dim bChunk As Byte
    For iByteCtr = 0 To iLenght - 1
        bChunk = CByte(Asc(Mid$(sVal, iByteCtr + 1, 1)))
        WriteProcessMemory lngPHandle, iAdr + iByteCtr, bChunk, 1&, 1&
    Next iByteCtr
End Sub

Private Function GetMemByte(ByVal iAdr As Long) As Byte
On Error Resume Next
    Static bVal As Byte
    If ReadProcessMemory(lngPHandle, iAdr, bVal, 1&, 0&) <> 0 Then GetMemByte = bVal
End Function

Private Function GetMemLong(ByVal iAdr As Long) As Long
On Error Resume Next
    Static lVal As Long
    If ReadProcessMemory(lngPHandle, iAdr, lVal, 4&, 0&) <> 0 Then GetMemLong = lVal
End Function

Private Function GetMemInt(ByVal iAdr As Long) As Integer
On Error Resume Next
    Static iVal As Integer
    If ReadProcessMemory(lngPHandle, iAdr, iVal, 2&, 0&) <> 0 Then GetMemInt = iVal
End Function

Private Function GetMemFloat(ByVal iAdr As Long) As Single
On Error Resume Next
    Static fVal As Single
    If ReadProcessMemory(lngPHandle, iAdr, fVal, 4&, 0&) <> 0 Then GetMemFloat = fVal
End Function

Private Function GetMemString(ByVal iAdr As Long, ByVal iLenght As Integer) As String
On Error Resume Next
    Dim sVal As String
    Dim iByteCtr As Long
    Dim bChunk As Byte
    For iByteCtr = 0 To iLenght - 1
        ReadProcessMemory lngPHandle, iAdr + iByteCtr, bChunk, 1&, 1&
        sVal = sVal & Chr(bChunk)
    Next iByteCtr
    GetMemString = sVal
End Function

Private Function SetCarWeight() As Boolean
On Error Resume Next
    Static fRBuffer As Single
    Static fWBuffer As Single
    Static dBuffer As Double
    'First of all, Make car DP (so that it does not explode during mass change)
    SetBitOnInteger tCurrCarAdr.lngSpecialsAdr, 4, True
    'Read current Mass:
    fRBuffer = GetMemFloat(tCurrCarAdr.lngCarWeightAdr)
    fWBuffer = CSng(scrCarDynamics(1).Value) * 100
    'Normalize Mass:
    dBuffer = fWBuffer / fRBuffer
    'Write Mass:
    SetMemFloat tCurrCarAdr.lngCarWeightAdr, fWBuffer
    'Read / Normalize / Write Suspension Level:
    fRBuffer = GetMemFloat(tCurrCarAdr.lngCarWeightAdr + 4)
    fWBuffer = dBuffer * fRBuffer
    SetMemFloat tCurrCarAdr.lngCarWeightAdr + 4, fWBuffer
End Function
'
'Private Sub InsertHexString()
''asm injection test helper code. normally not used by the control center
'Dim sHEX As String
'Dim iCtr As Long
'Dim iAdr As Long
'
'GoTo test1
'
'GoTo version_one_one
'
'version_one_zero: 'one hit kill inject v1.0
'iAdr = &H4B331F
'sHEX = "E94A3C3A0090"
'
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'
'iAdr = &H856F68
'sHEX = "A827480E000060A1686F85008D8E400500003BC8750961899640050000EB0B61C7864005000000000000E98EC3C5FF"
'
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'Exit Sub
'
'version_one_one: 'one hit kill inject v1.1
'
'iAdr = &H4B339F
'sHEX = "E9CA4B3A0090"
'
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'
'iAdr = &H857F68
'sHEX = "A827480E000060A1687F85008D8E400500003BC8750961899640050000EB0B61C7864005000000000000E90EB4C5FF"
'
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'Exit Sub
'
'test1: 'select weapon test
'iAdr = &H53BF9C
'sHEX = "E93FAD3100"
'
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'
'iAdr = &H856CE0
'sHEX = "5650A10010300183F800587418FF3500103001E8B833BEFF83C404C7050010300100000000"
'sHEX = sHEX & "50A10410300183F80058741A6A02FF3504103001E8C21ABBFF83C408C7050410300100000000"
'sHEX = sHEX & "50A10810300183F80058741A6A02FF3508103001E89C1ABBFF83C408C7050810300100000000"
'sHEX = sHEX & "50A10C10300183F80058741A6A02FF350C103001E8761ABBFF83C408C7050C10300100000000"
'sHEX = sHEX & "50A11010300183F80058741A6A02FF3510103001E8501ABBFF83C408C7051010300100000000"
'sHEX = sHEX & "50A11410300183F80058741A6A02FF3514103001E82A1ABBFF83C408C7051410300100000000"
'sHEX = sHEX & "50A11810300183F80058741A6A02FF3518103001E8041ABBFF83C408C7051810300100000000"
'sHEX = sHEX & "50A11C10300183F80058741A6A02FF351C103001E8DE19BBFF83C408C7051C10300100000000"
'sHEX = sHEX & "50A12010300183F80058741A6A02FF3520103001E8B819BBFF83C408C7052010300100000000"
'sHEX = sHEX & "50A12410300183F80058741A6A02FF3524103001E89219BBFF83C408C7052410300100000000"
'sHEX = sHEX & "50A12810300183F80058741A6A02FF3528103001E86C19BBFF83C408C7052810300100000000"
'sHEX = sHEX & "50A12C10300183F80058741A6A02FF352C103001E84619BBFF83C408C7052C10300100000000"
'sHEX = sHEX & "50A13010300183F80058741A6A02FF3530103001E82019BBFF83C408C7053010300100000000"
'sHEX = sHEX & "50A13410300183F8005874146A00E82C7BBBFF83C404C70534103001000000005EA048CBB700E9A950CEFF"
'For iCtr = 1 To Len(sHEX) - 1 Step 2
'    SetMemByte iAdr, CByte("&H" & Mid$(sHEX, iCtr, 2))
'    iAdr = iAdr + 1
'Next iCtr
'Exit Sub
'
'End Sub
'
