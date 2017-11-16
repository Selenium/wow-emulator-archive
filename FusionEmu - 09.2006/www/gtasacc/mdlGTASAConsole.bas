Attribute VB_Name = "mdlGTASAConsole"
Option Explicit

Sub Main()
On Error Resume Next
    Dim iModCtr As Integer
    strIniFileName = App.Path & "\GTASAConsole.ini"
    strDatFileName = App.Path & "\GTASAData.dat"
    strCfgFileName = App.Path & "\GTASAConfig.dat"
    strPicFileName = App.Path & "\GTASACarPics.dat"
    strCheatFileName = App.Path & "\GTASACheats.dat"
    strLocsFileName = App.Path & "\GTASALocs.dat"
    If Len(Dir$(strIniFileName)) = 0 Then RegenerateINI 'dump ini if non-existent
    If Len(Dir$(strDatFileName)) = 0 Then RegenerateDAT 'dump dat if non-existent
    CheckAndRegenerateDAT
    If Len(Dir$(strPicFileName)) = 0 Then RegeneratePIC 'dump dat if non-existent
    If Len(Dir$(strCfgFileName)) = 0 Then RegenerateCFG 'dump dat if non-existent
    If Len(Dir$(strCheatFileName)) = 0 Then RegenerateCheats 'dump dat if non-existent
    If Len(Dir$(strLocsFileName)) = 0 Then RegenerateLocations 'dump dat if non-existent
    GetSettings     'initialise adr. variables and arrays
    ParseCarCol     'get color values
    For iModCtr = 0 To 14
        zeroTuneInt(iModCtr) = -1
    Next iModCtr
    isCarPicsReady = False
    'Show main form:
    frmSAConsole.Show
    
End Sub

Function ParseCarCol() As Boolean
On Error GoTo errParseCarCol
    Dim strLineString As String
    Dim strToken As String
    Dim strRedColor As String
    Dim strBlueColor As String
    Dim strGreenColor As String
    Dim strToolTip As String
    Dim intColorIndex As Integer
    Dim isParsing As Boolean
    
    ParseCarCol = False
    Open strDatFileName For Input As #1
        intColorIndex = 0
        Line Input #1, strLineString
        Do Until EOF(1)
            Line Input #1, strLineString
            If Left$(strLineString, 11) = "GTASAColors" Then isParsing = True 'GTASAColors.dat is lean
            strLineString = Trim(strLineString)
            If Len(strLineString) > 0 Then
                If Left$(strLineString, 1) = "#" Then GoTo ContinueLoop
                If Left$(strLineString, 11) = "GTASAColors" Then isParsing = True: GoTo ContinueLoop
                If Left$(strLineString, 15) = "END_GTASAColors" Then Exit Do
                If isParsing Then
                    'Parse RGB:
                    'Parse Blue:
                    strToken = Left$(strLineString, InStr(strLineString, ",") - 1)
                    strLineString = Mid$(strLineString, InStr(strLineString, ",") + 1)
                    strBlueColor = Right$("00" & UCase(Hex(CInt(strToken))), 2)
                    'Parse Green:
                    strToken = Left$(strLineString, InStr(strLineString, ",") - 1)
                    strLineString = Mid$(strLineString, InStr(strLineString, ",") + 1)
                    strGreenColor = Right$("00" & UCase(Hex(CInt(strToken))), 2)
                    'Parse Red:
                    If InStr(strLineString, "#") > 0 Then
                        strToken = Left$(strLineString, InStr(strLineString, "#") - 1)
                    Else 'comments have been removed from file:
                        strToken = strLineString
                    End If
                    strLineString = Trim(Mid$(strLineString, InStr(strLineString, "#") + 4))
                    strRedColor = Right$("00" & UCase(Hex(CInt(strToken))), 2)
                    'Get ToolTipText:
                    If InStr(strLineString, vbTab) > 0 Then
                        strToolTip = Left$(strLineString, InStr(strLineString, vbTab) - 1)
                    Else
                        strToolTip = strLineString
                    End If
                    'write values:
                    GTASAColors(intColorIndex).intColorCode = intColorIndex
                    GTASAColors(intColorIndex).lngRGB = CLng("&H" & strRedColor & strGreenColor & strBlueColor)
                    GTASAColors(intColorIndex).strDescription = strToolTip
                    intColorIndex = intColorIndex + 1
                End If
            End If
ContinueLoop:
        If intColorIndex > 255 Then Exit Do 'only first 255 will do
        Loop
    Close #1
    ParseCarCol = True

Exit Function
errParseCarCol:
    MsgBox Err.Description, , "Car colors not parsed."
    Err.Clear
    
End Function

Private Function RegenerateINI() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(100, "SETTINGS")
    Open App.Path & "\GTASAConsole.ini" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Private Function RegenerateDAT() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(101, "SETTINGS")
    Open App.Path & "\GTASAData.dat" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Private Function CheckAndRegenerateDAT() As Boolean
On Error GoTo errCheckAndRegenerateDAT
    Dim isDATOK As Boolean
    Dim strLineInput As String
    Dim sSplitArr() As String
    'Dat version info:
    isDATOK = False
    Open strDatFileName For Input As #1
    Do Until EOF(1) 'find start of DAT Version:
        Line Input #1, strLineInput
        If Left$(strLineInput, 10) = "DATVersion" Then Exit Do
    Loop
    Do Until EOF(1) 'read dat version:
        Line Input #1, strLineInput
        If Trim(Replace(strLineInput, vbTab, "")) = "" Then GoTo ReadNextLine
        If Left$(strLineInput, 1) = "#" Then GoTo ReadNextLine
        If Left$(strLineInput, 14) = "END_DATVersion" Then Exit Do
        'if we can come to this line, we have found the version:
        If strLineInput = App.Major & App.Minor & App.Revision Then
            isDATOK = True
            Exit Do
        End If
ReadNextLine:
    Loop
CleanExitFunction:
    On Error Resume Next
    Close #1
    If Not isDATOK Then RegenerateDAT
    
Exit Function
errCheckAndRegenerateDAT:
    Err.Clear
    isDATOK = False
    Resume CleanExitFunction
End Function

Private Function RegenerateCFG() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(102, "SETTINGS")
    Open App.Path & "\GTASAConfig.dat" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Private Function RegeneratePIC() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(103, "SETTINGS")
    Open App.Path & "\GTASACarPics.dat" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Private Function RegenerateCheats() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(104, "SETTINGS")
    Open App.Path & "\GTASACheats.dat" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Private Function RegenerateLocations() As Boolean
On Error Resume Next
    Dim arrINI() As Byte
    arrINI() = LoadResData(105, "SETTINGS")
    Open App.Path & "\GTASALocs.dat" For Binary As #1
        For lngReadBuffer = 0 To UBound(arrINI)
            Put #1, , Chr$(arrINI(lngReadBuffer))
        Next lngReadBuffer
    Close #1
    
End Function

Sub CollectGarbage(Optional ByVal isForced As Boolean = False)
On Error Resume Next
    isCollectingGarbage = True
    If isForced Then End 'sorry
    'Unload Forms:
    Unload frmPickColor
    Unload frmSAConsole
    Unload frmCarSelect
    Unload frmSelectFolder
    Unload frmMods
    'Erase Arrays:
    Erase KickStartSpeeds()
    Erase GTASACarPlacements()
    Erase GTASAGarageAddresses()
    Erase GTASAColors()
    Erase ParkedCars()
    Erase ParkedCarMatrix()
    Erase GarageListMatrix()
'    Erase GTASACheats()
'    Erase GTASAWarpLocs()
'    Erase GTASAShortcuts()
'    Erase GTASAConsoleCommands()
    Set GTASACheats = Nothing
    Set GTASANewCheat = Nothing
    Set GTASAWarpLocs = Nothing
    Set GTASANewWarpLoc = Nothing
    Set GTASAShortcuts = Nothing
    Set GTASANewShortcut = Nothing
    'Bye
    'End
    
End Sub

Function GetToken(ByVal strTokenString As String, ByVal intTokenOrdinal As Integer, Optional ByVal strSeperator As String = ",") As String
On Error GoTo errGetToken
    Static sTokens() As String
    sTokens = Split(strTokenString, strSeperator)
    If UBound(sTokens) >= intTokenOrdinal - 1 Then
        GetToken = sTokens(intTokenOrdinal - 1)
    ElseIf UBound(sTokens) = 0 Then
        GetToken = strTokenString
    Else
        GetToken = "0"
    End If
Exit Function
errGetToken:
    Err.Clear
    GetToken = "0"
End Function

Function GetAbsoluteDegrees(ByVal sngXGrad As Single, ByVal sngYGrad As Single) As Single
On Error Resume Next
    'Zero Points:                   Normalization:
    ' 0  1 180°                     + +  180 - ArcSin(X°)
    ' 1  0  90°                     + -  ArcSin(X°)
    ' 0 -1   0°                     - +  180 - ArcSin(X°)
    '-1  0 270°                     - -  360 + ArcSin(X°)
    '!!Division by Zero happens when sngXGrad=-1 (at this time sngYGrad is somewehere around zero (but not always equal to zero)
    Select Case TrueBool
        Case sngXGrad = -1 ' And sngYGrad = 0 '-0 0 270° OK (Division by Zero happens when sngXGrad=-1 )
            GetAbsoluteDegrees = 270
        Case sngXGrad = 0 And sngYGrad > 0 '0 1 180° OK
            GetAbsoluteDegrees = 180
        Case sngXGrad = 0 And sngYGrad < 0 '0 -1 0° NullPoint OK
            GetAbsoluteDegrees = 0
        Case sngXGrad = 1                  '1 0 90° OK
            GetAbsoluteDegrees = 90
        Case sngXGrad > 0 And sngYGrad > 0 '++ OK
            GetAbsoluteDegrees = 180 - Atn(sngXGrad / Sqr((0 - sngXGrad) * sngXGrad + 1)) * 180 / mathPI
        Case sngXGrad > 0 And sngYGrad < 0 '+- OK
            GetAbsoluteDegrees = Atn(sngXGrad / Sqr((0 - sngXGrad) * sngXGrad + 1)) * 180 / mathPI
        Case sngXGrad < 0 And sngYGrad > 0 '-+ OK
            GetAbsoluteDegrees = 180 - Atn(sngXGrad / Sqr((0 - sngXGrad) * sngXGrad + 1)) * 180 / mathPI
        Case sngXGrad < 0 And sngYGrad < 0 '-- OK
            GetAbsoluteDegrees = 360 + Atn(sngXGrad / Sqr((0 - sngXGrad) * sngXGrad + 1)) * 180 / mathPI
    End Select
    Err.Clear
End Function

Function GetDegrees(ByVal sngGrad As Single) As Single
On Error Resume Next
    'Zero Points:
    ' 0  0°
    ' 1  90°
    Select Case TrueBool
        Case sngGrad = 0
            GetDegrees = 0
        Case sngGrad = 1
            GetDegrees = 90
        Case sngGrad = -1
            GetDegrees = 270
        Case Else
            GetDegrees = Atn(sngGrad / Sqr((0 - sngGrad) * sngGrad + 1)) * 180 / mathPI
    End Select
    Err.Clear
End Function

Function GetGrad(ByVal sngDegrees As Single) As Single
On Error Resume Next
    GetGrad = Sin(sngDegrees * mathPI / 180)
    Err.Clear
    
End Function

Function TrimChr0(ByVal strToTrim As String) As String
On Error GoTo errTrimChr0
    strToTrim = Trim(strToTrim)
    If InStr(strToTrim, Chr(0)) > 0 Then
        TrimChr0 = Left$(strToTrim, InStr(strToTrim, Chr(0)) - 1)
    Else
        TrimChr0 = strToTrim
    End If
    
Exit Function
errTrimChr0:
    Err.Clear
    TrimChr0 = ""
End Function

Function GetSettings() As Boolean
On Error GoTo errGetSettings
    Dim iCtr As Integer
    GetSettings = False
    gtaSAWindow.Length = Len(gtaSAWindow)
    'Zero Speed/Spin:
    zeroSpin.sngXSpin = 0
    zeroSpin.sngYSpin = 0
    zeroSpin.sngZSpin = 0
    zeroSpeed.sngXSpeed = 0
    zeroSpeed.sngYSpeed = 0
    zeroSpeed.sngZSpeed = 0
    'KickStart Speeds:
    'North
    KickStartSpeeds(0).sngXSpeed = 0
    KickStartSpeeds(0).sngYSpeed = 1
    'North-East
    KickStartSpeeds(1).sngXSpeed = 0.5
    KickStartSpeeds(1).sngYSpeed = 0.5
    'East
    KickStartSpeeds(2).sngXSpeed = 1
    KickStartSpeeds(2).sngYSpeed = 0
    'South-East
    KickStartSpeeds(3).sngXSpeed = 0.5
    KickStartSpeeds(3).sngYSpeed = -0.5
    'South
    KickStartSpeeds(4).sngXSpeed = 0
    KickStartSpeeds(4).sngYSpeed = -1
    'South-West
    KickStartSpeeds(5).sngXSpeed = -0.5
    KickStartSpeeds(5).sngYSpeed = -0.5
    'West
    KickStartSpeeds(6).sngXSpeed = -1
    KickStartSpeeds(6).sngYSpeed = 0
    'NorthWest
    KickStartSpeeds(7).sngXSpeed = -0.5
    KickStartSpeeds(7).sngYSpeed = 0.5
    'Car Placements:
    'North:
    GTASACarPlacements(0).sngXGrad = 1
    GTASACarPlacements(0).sngYGrad = 0
    GTASACarPlacements(0).sngZgrad = 0
    GTASACarPlacements(0).sngXlooking = 0
    GTASACarPlacements(0).sngYlooking = 1
    GTASACarPlacements(0).sngZlooking = 0
    'NorthEast
    GTASACarPlacements(1).sngXGrad = 0.71
    GTASACarPlacements(1).sngYGrad = -0.71
    GTASACarPlacements(1).sngZgrad = 0
    GTASACarPlacements(1).sngXlooking = 0.71
    GTASACarPlacements(1).sngYlooking = 0.71
    GTASACarPlacements(1).sngZlooking = 0
    'East
    GTASACarPlacements(2).sngXGrad = 0
    GTASACarPlacements(2).sngYGrad = -1
    GTASACarPlacements(2).sngZgrad = 0
    GTASACarPlacements(2).sngXlooking = 1
    GTASACarPlacements(2).sngYlooking = 0
    GTASACarPlacements(2).sngZlooking = 0
    'South-East
    GTASACarPlacements(3).sngXGrad = -0.71
    GTASACarPlacements(3).sngYGrad = -0.71
    GTASACarPlacements(3).sngZgrad = 0
    GTASACarPlacements(3).sngXlooking = 0.71
    GTASACarPlacements(3).sngYlooking = -0.71
    GTASACarPlacements(3).sngZlooking = 0
    'South
    GTASACarPlacements(4).sngXGrad = -1
    GTASACarPlacements(4).sngYGrad = 0
    GTASACarPlacements(4).sngZgrad = 0
    GTASACarPlacements(4).sngXlooking = 0
    GTASACarPlacements(4).sngYlooking = -1
    GTASACarPlacements(4).sngZlooking = 0
    'South-West
    GTASACarPlacements(5).sngXGrad = -0.71
    GTASACarPlacements(5).sngYGrad = 0.71
    GTASACarPlacements(5).sngZgrad = 0
    GTASACarPlacements(5).sngXlooking = -0.71
    GTASACarPlacements(5).sngYlooking = -0.71
    GTASACarPlacements(5).sngZlooking = 0
    'West
    GTASACarPlacements(6).sngXGrad = 0
    GTASACarPlacements(6).sngYGrad = 1
    GTASACarPlacements(6).sngZgrad = 0
    GTASACarPlacements(6).sngXlooking = -1
    GTASACarPlacements(6).sngYlooking = 0
    GTASACarPlacements(6).sngZlooking = 0
    'North-West
    GTASACarPlacements(7).sngXGrad = 0.71
    GTASACarPlacements(7).sngYGrad = 0.71
    GTASACarPlacements(7).sngZgrad = 0
    GTASACarPlacements(7).sngXlooking = -0.71
    GTASACarPlacements(7).sngYlooking = 0.71
    GTASACarPlacements(7).sngZlooking = 0
    'Garage Details:
    'Johnson House Garage Dimensions:
    GTASAGarageDim(iJohnson).sngXpos = 2508.263
    GTASAGarageDim(iJohnson).sngYpos = -1691.133
    GTASAGarageDim(iJohnson).sngZpos = 13.555 - 0.73
    GTASAGarageDim(iJohnson).sngXGrad = 0
    GTASAGarageDim(iJohnson).sngYGrad = 1
    GTASAGarageDim(iJohnson).sngWidth = -5.447
    GTASAGarageDim(iJohnson).sngLength = -7.359
    GTASAGarageDim(iJohnson).sngAbsDegrees = 180
    GTASAGarageDim(iJohnson).lngLookFront = &HFF6300
    GTASAGarageDim(iJohnson).lngLookLeft = &HFF0063
    GTASAGarageDim(iJohnson).lngLookFrontLeft = &HFF4646
    'El Corona Garage Dimensions (4 Cars)
    GTASAGarageDim(iElCorona).sngXpos = 1695.669
    GTASAGarageDim(iElCorona).sngYpos = -2088.671
    GTASAGarageDim(iElCorona).sngZpos = 13.547 - 0.73
    GTASAGarageDim(iElCorona).sngXGrad = 0
    GTASAGarageDim(iElCorona).sngYGrad = -1
    GTASAGarageDim(iElCorona).sngWidth = 6.429
    GTASAGarageDim(iElCorona).sngLength = 9.921
    GTASAGarageDim(iElCorona).sngAbsDegrees = 0
    GTASAGarageDim(iElCorona).lngLookFront = &HFF9D00
    GTASAGarageDim(iElCorona).lngLookLeft = &HFF009D
    GTASAGarageDim(iElCorona).lngLookFrontLeft = &HFFBABA
    'Santa Maria Beach Garage Dimensions:
    GTASAGarageDim(iSantaBeach).sngXpos = 319.666
    GTASAGarageDim(iSantaBeach).sngYpos = -1768.892
    GTASAGarageDim(iSantaBeach).sngZpos = 4.654 - 0.73
    GTASAGarageDim(iSantaBeach).sngXGrad = 0
    GTASAGarageDim(iSantaBeach).sngYGrad = -1
    GTASAGarageDim(iSantaBeach).sngWidth = 5.694
    GTASAGarageDim(iSantaBeach).sngLength = 9.225
    GTASAGarageDim(iSantaBeach).sngAbsDegrees = 0
    GTASAGarageDim(iSantaBeach).lngLookFront = &H19D00
    GTASAGarageDim(iSantaBeach).lngLookLeft = &HFE009D
    GTASAGarageDim(iSantaBeach).lngLookFrontLeft = &HBABA&
    'MulHolland Garage Dimensions:
    GTASAGarageDim(iMulHolland).sngXpos = 1355.3
    GTASAGarageDim(iMulHolland).sngYpos = -626.038
    GTASAGarageDim(iMulHolland).sngZpos = 109.133 - 0.73
    GTASAGarageDim(iMulHolland).sngXGrad = -0.328
    GTASAGarageDim(iMulHolland).sngYGrad = 0.945
    GTASAGarageDim(iMulHolland).sngWidth = -3.557
    GTASAGarageDim(iMulHolland).sngLength = -7.922
    GTASAGarageDim(iMulHolland).sngAbsDegrees = 200
    GTASAGarageDim(iMulHolland).lngLookFront = &HFF5EDE
    GTASAGarageDim(iMulHolland).lngLookLeft = &HFF205E
    GTASAGarageDim(iMulHolland).lngLookFrontLeft = &HFF5B28
    'Palomino Garage Dimensions:
    GTASAGarageDim(iPalomino).sngXpos = 2228.208
    GTASAGarageDim(iPalomino).sngYpos = 168.904
    GTASAGarageDim(iPalomino).sngZpos = 27.48 - 0.73
    GTASAGarageDim(iPalomino).sngXGrad = 0
    GTASAGarageDim(iPalomino).sngYGrad = -1
    GTASAGarageDim(iPalomino).sngWidth = 6.283
    GTASAGarageDim(iPalomino).sngLength = 6.601
    GTASAGarageDim(iPalomino).sngAbsDegrees = 0
    GTASAGarageDim(iPalomino).lngLookFront = &HFF9D00
    GTASAGarageDim(iPalomino).lngLookLeft = &HFF009D
    GTASAGarageDim(iPalomino).lngLookFrontLeft = &HFFBABA
    'Prickle Pine Garage Dimensions:
    GTASAGarageDim(iPrickle).sngXpos = 1278.783
    GTASAGarageDim(iPrickle).sngYpos = 2525.771
    GTASAGarageDim(iPrickle).sngZpos = 10.82 - 0.73
    GTASAGarageDim(iPrickle).sngXGrad = 1
    GTASAGarageDim(iPrickle).sngYGrad = 0
    GTASAGarageDim(iPrickle).sngWidth = 9.548
    GTASAGarageDim(iPrickle).sngLength = 8.426
    GTASAGarageDim(iPrickle).sngAbsDegrees = 90
    GTASAGarageDim(iPrickle).isWide = True
    GTASAGarageDim(iPrickle).lngLookFront = &HFF0063
    GTASAGarageDim(iPrickle).lngLookLeft = &HFF9D00
    GTASAGarageDim(iPrickle).lngLookFrontLeft = &HFFBA46
    'Whitewood Estates Garage Dimensions:
    GTASAGarageDim(iWhitewood).sngXpos = 929.566
    GTASAGarageDim(iWhitewood).sngYpos = 2013.904
    GTASAGarageDim(iWhitewood).sngZpos = 11.461 - 0.73
    GTASAGarageDim(iWhitewood).sngXGrad = -1
    GTASAGarageDim(iWhitewood).sngYGrad = 0
    GTASAGarageDim(iWhitewood).sngWidth = 4.849
    GTASAGarageDim(iWhitewood).sngLength = 9.147
    GTASAGarageDim(iWhitewood).sngAbsDegrees = 270
    GTASAGarageDim(iWhitewood).lngLookFront = &HFF009D
    GTASAGarageDim(iWhitewood).lngLookLeft = &HFF6300
    GTASAGarageDim(iWhitewood).lngLookFrontLeft = &HFF46BA
    'Redsands West Garage Dimensions:
    GTASAGarageDim(iRedsands).sngXpos = 1408.637
    GTASAGarageDim(iRedsands).sngYpos = 1904.526
    GTASAGarageDim(iRedsands).sngZpos = 11.461 - 0.73
    GTASAGarageDim(iRedsands).sngXGrad = -1
    GTASAGarageDim(iRedsands).sngYGrad = 0
    GTASAGarageDim(iRedsands).sngWidth = 4.784
    GTASAGarageDim(iRedsands).sngLength = 8.799
    GTASAGarageDim(iRedsands).sngAbsDegrees = 270
    GTASAGarageDim(iRedsands).lngLookFront = &HFF009D
    GTASAGarageDim(iRedsands).lngLookLeft = &HFF6300
    GTASAGarageDim(iRedsands).lngLookFrontLeft = &HFF46BA
    'Rockshore West Garage Dimensions:
    GTASAGarageDim(iRockshore).sngXpos = 2449.564
    GTASAGarageDim(iRockshore).sngYpos = 699.916
    GTASAGarageDim(iRockshore).sngZpos = 11.461 - 0.73
    GTASAGarageDim(iRockshore).sngXGrad = -1
    GTASAGarageDim(iRockshore).sngYGrad = 0
    GTASAGarageDim(iRockshore).sngWidth = 4.786
    GTASAGarageDim(iRockshore).sngLength = 8.844
    GTASAGarageDim(iRockshore).sngAbsDegrees = 270
    GTASAGarageDim(iRockshore).lngLookFront = &HFF009D
    GTASAGarageDim(iRockshore).lngLookLeft = &HFF6300
    GTASAGarageDim(iRockshore).lngLookFrontLeft = &HFF46BA
    'Dillimore Garage Dimensions:
    GTASAGarageDim(iDillimore).sngXpos = 783.948
    GTASAGarageDim(iDillimore).sngYpos = -492.412
    GTASAGarageDim(iDillimore).sngZpos = 17.344 - 0.73
    GTASAGarageDim(iDillimore).sngXGrad = 0
    GTASAGarageDim(iDillimore).sngYGrad = -1
    GTASAGarageDim(iDillimore).sngWidth = 4.263
    GTASAGarageDim(iDillimore).sngLength = 7.236
    GTASAGarageDim(iDillimore).sngAbsDegrees = 0
    GTASAGarageDim(iDillimore).lngLookFront = &HFF9D00
    GTASAGarageDim(iDillimore).lngLookLeft = &HFF009D
    GTASAGarageDim(iDillimore).lngLookFrontLeft = &HFFBABA
    'Fort Carson Garage Dimensions:
    GTASAGarageDim(iFortCarson).sngXpos = -367.371
    GTASAGarageDim(iFortCarson).sngYpos = 1194.711
    GTASAGarageDim(iFortCarson).sngZpos = 19.573 - 0.73
    GTASAGarageDim(iFortCarson).sngXGrad = 0
    GTASAGarageDim(iFortCarson).sngYGrad = -1
    GTASAGarageDim(iFortCarson).sngWidth = -10.599
    GTASAGarageDim(iFortCarson).sngLength = -7.849
    GTASAGarageDim(iFortCarson).sngAbsDegrees = 0
    GTASAGarageDim(iFortCarson).isWide = True
    GTASAGarageDim(iFortCarson).lngLookFront = &HFF9D00
    GTASAGarageDim(iFortCarson).lngLookLeft = &HFF009D
    GTASAGarageDim(iFortCarson).lngLookFrontLeft = &HFFBABA
    'Verdant Meadows Garage Dimensions:
    GTASAGarageDim(iVerdant).sngXpos = 430.441
    GTASAGarageDim(iVerdant).sngYpos = 2550.134
    GTASAGarageDim(iVerdant).sngZpos = 16.188 - 0.73
    GTASAGarageDim(iVerdant).sngXGrad = -1
    GTASAGarageDim(iVerdant).sngYGrad = 0
    GTASAGarageDim(iVerdant).sngWidth = 7.445
    GTASAGarageDim(iVerdant).sngLength = 12.537
    GTASAGarageDim(iVerdant).sngAbsDegrees = 270
    GTASAGarageDim(iVerdant).isWide = True
    GTASAGarageDim(iVerdant).lngLookFront = &HFF009D
    GTASAGarageDim(iVerdant).lngLookLeft = &HFF6300
    GTASAGarageDim(iVerdant).lngLookFrontLeft = &HFF46BA
    'Verdant Meadows Airport Garage Dimensions:
    GTASAGarageDim(iVerdantAir).sngXpos = 425.726
    GTASAGarageDim(iVerdantAir).sngYpos = 2475.778
    GTASAGarageDim(iVerdantAir).sngZpos = 16.5 - 0.73
    GTASAGarageDim(iVerdantAir).sngXGrad = 0
    GTASAGarageDim(iVerdantAir).sngYGrad = 1
    GTASAGarageDim(iVerdantAir).sngWidth = -43.576
    GTASAGarageDim(iVerdantAir).sngLength = -43.575
    GTASAGarageDim(iVerdantAir).sngAbsDegrees = 180
    GTASAGarageDim(iVerdantAir).isWide = True
    GTASAGarageDim(iVerdantAir).lngLookFront = &HFF6300
    GTASAGarageDim(iVerdantAir).lngLookLeft = &HFF0063
    GTASAGarageDim(iVerdantAir).lngLookFrontLeft = &HFF4646
    'Calton Heights Garage Dimensions:
    GTASAGarageDim(iCalton).sngXpos = -2102.171
    GTASAGarageDim(iCalton).sngYpos = 896.776
    GTASAGarageDim(iCalton).sngZpos = 76.703 - 0.73
    GTASAGarageDim(iCalton).sngXGrad = 0
    GTASAGarageDim(iCalton).sngYGrad = 1
    GTASAGarageDim(iCalton).sngWidth = -6.292
    GTASAGarageDim(iCalton).sngLength = -7.258
    GTASAGarageDim(iCalton).sngAbsDegrees = 180
    GTASAGarageDim(iCalton).lngLookFront = &HFF6300
    GTASAGarageDim(iCalton).lngLookLeft = &HFF0063
    GTASAGarageDim(iCalton).lngLookFrontLeft = &HFF4646
    'Paradiso Garage Dimensions:
    GTASAGarageDim(iParadiso).sngXpos = -2698.411
    GTASAGarageDim(iParadiso).sngYpos = 821.422
    GTASAGarageDim(iParadiso).sngZpos = 49.984 - 0.73
    GTASAGarageDim(iParadiso).sngXGrad = 0
    GTASAGarageDim(iParadiso).sngYGrad = -1
    GTASAGarageDim(iParadiso).sngWidth = 4.992
    GTASAGarageDim(iParadiso).sngLength = 9.408
    GTASAGarageDim(iParadiso).sngAbsDegrees = 0
    GTASAGarageDim(iParadiso).lngLookFront = &HFF9D00
    GTASAGarageDim(iParadiso).lngLookLeft = &HFF009D
    GTASAGarageDim(iParadiso).lngLookFrontLeft = &HFFBABA
    'Dhoerty Garage Dimensions:
    GTASAGarageDim(iDoherty).sngXpos = -2022.175
    GTASAGarageDim(iDoherty).sngYpos = 129.37
    GTASAGarageDim(iDoherty).sngZpos = 28.897 - 0.73
    GTASAGarageDim(iDoherty).sngXGrad = 0
    GTASAGarageDim(iDoherty).sngYGrad = 1
    GTASAGarageDim(iDoherty).sngWidth = -9.872
    GTASAGarageDim(iDoherty).sngLength = -10.466
    GTASAGarageDim(iDoherty).sngAbsDegrees = 180
    GTASAGarageDim(iDoherty).isWide = True
    GTASAGarageDim(iDoherty).lngLookFront = &HFF6300
    GTASAGarageDim(iDoherty).lngLookLeft = &HFF0063
    GTASAGarageDim(iDoherty).lngLookFrontLeft = &HFF4646
    'Hashbury Garage Dimensions:
    GTASAGarageDim(iHashbury).sngXpos = -2454.243
    GTASAGarageDim(iHashbury).sngYpos = -117.352
    GTASAGarageDim(iHashbury).sngZpos = 26.121 - 0.73
    GTASAGarageDim(iHashbury).sngXGrad = -1
    GTASAGarageDim(iHashbury).sngYGrad = 0
    GTASAGarageDim(iHashbury).sngWidth = 14.355
    GTASAGarageDim(iHashbury).sngLength = 11.148
    GTASAGarageDim(iHashbury).sngAbsDegrees = 270
    GTASAGarageDim(iHashbury).isWide = True
    GTASAGarageDim(iHashbury).lngLookFront = &HFF009D
    GTASAGarageDim(iHashbury).lngLookLeft = &HFF6300
    GTASAGarageDim(iHashbury).lngLookFrontLeft = &HFF46BA
    
    'this section belongs to the weapon slot to weapon combo matrix.
    'the cells (n,0) is the listitem 0, and has weapon id =0 (ie. none)
    'Melee Weapons:
    WeaponSlotMatrix(0, 1) = 2 ' Golf Club
    WeaponSlotCombo(2, 0) = 0:    WeaponSlotCombo(2, 1) = 1
    WeaponSlotMatrix(0, 2) = 3 ' Nitestick
    WeaponSlotCombo(3, 0) = 0:    WeaponSlotCombo(3, 1) = 2
    WeaponSlotMatrix(0, 3) = 4 ' Knife
    WeaponSlotCombo(4, 0) = 0:    WeaponSlotCombo(4, 1) = 3
    WeaponSlotMatrix(0, 4) = 5 ' Baseball Bat
    WeaponSlotCombo(5, 0) = 0:    WeaponSlotCombo(5, 1) = 4
    WeaponSlotMatrix(0, 5) = 6 ' Shovel
    WeaponSlotCombo(6, 0) = 0:    WeaponSlotCombo(6, 1) = 5
    WeaponSlotMatrix(0, 6) = 8 ' Katana
    WeaponSlotCombo(8, 0) = 0:    WeaponSlotCombo(8, 1) = 6
    WeaponSlotMatrix(0, 7) = 7 ' Pool Cue
    WeaponSlotCombo(7, 0) = 0:    WeaponSlotCombo(7, 1) = 7
    WeaponSlotMatrix(0, 8) = 9 ' Chainsaw
    WeaponSlotCombo(9, 0) = 0:    WeaponSlotCombo(9, 1) = 8
    'Handguns:
    WeaponSlotMatrix(1, 1) = 22  ' Pistol
    WeaponSlotCombo(22, 0) = 1:    WeaponSlotCombo(22, 1) = 1
    WeaponSlotMatrix(1, 2) = 23  ' Silenced Pistol
    WeaponSlotCombo(23, 0) = 1:    WeaponSlotCombo(23, 1) = 2
    WeaponSlotMatrix(1, 3) = 24  ' Desert Eagle
    WeaponSlotCombo(24, 0) = 1:    WeaponSlotCombo(24, 1) = 3
    'Shotguns:
    WeaponSlotMatrix(2, 1) = 25  ' Shotgun
    WeaponSlotCombo(25, 0) = 2:    WeaponSlotCombo(25, 1) = 1
    WeaponSlotMatrix(2, 2) = 26  ' Sawn-Off Shotgun
    WeaponSlotCombo(26, 0) = 2:    WeaponSlotCombo(26, 1) = 2
    WeaponSlotMatrix(2, 3) = 27  ' SPAZ12
    WeaponSlotCombo(27, 0) = 2:    WeaponSlotCombo(27, 1) = 3
    'Sub-Machineguns:
    WeaponSlotMatrix(3, 1) = 28  ' Micro UZI
    WeaponSlotCombo(28, 0) = 3:    WeaponSlotCombo(28, 1) = 1
    WeaponSlotMatrix(3, 2) = 29  ' MP5
    WeaponSlotCombo(29, 0) = 3:    WeaponSlotCombo(29, 1) = 2
    WeaponSlotMatrix(3, 3) = 32  ' Tech9
    WeaponSlotCombo(32, 0) = 3:    WeaponSlotCombo(32, 1) = 3
    'Machineguns:
    WeaponSlotMatrix(4, 1) = 30  ' AK47
    WeaponSlotCombo(30, 0) = 4:    WeaponSlotCombo(30, 1) = 1
    WeaponSlotMatrix(4, 2) = 31  ' M4
    WeaponSlotCombo(31, 0) = 4:    WeaponSlotCombo(31, 1) = 2
    'Rifles:
    WeaponSlotMatrix(5, 1) = 33  ' Country Rifle
    WeaponSlotCombo(33, 0) = 5:    WeaponSlotCombo(33, 1) = 1
    WeaponSlotMatrix(5, 2) = 34  ' Sniper Rifle
    WeaponSlotCombo(34, 0) = 5:    WeaponSlotCombo(34, 1) = 2
    'Heavy Weapons:
    WeaponSlotMatrix(6, 1) = 35  ' Rocket Launcher
    WeaponSlotCombo(35, 0) = 6:    WeaponSlotCombo(35, 1) = 1
    WeaponSlotMatrix(6, 2) = 36  ' Heat Seaking RPG
    WeaponSlotCombo(36, 0) = 6:    WeaponSlotCombo(36, 1) = 2
    WeaponSlotMatrix(6, 3) = 37  ' Flame Thrower
    WeaponSlotCombo(37, 0) = 6:    WeaponSlotCombo(37, 1) = 3
    WeaponSlotMatrix(6, 4) = 38  ' Minigun
    WeaponSlotCombo(38, 0) = 6:    WeaponSlotCombo(38, 1) = 4
    'Projectiles
    WeaponSlotMatrix(7, 1) = 16  ' Grenade
    WeaponSlotCombo(16, 0) = 7:    WeaponSlotCombo(16, 1) = 1
    WeaponSlotMatrix(7, 2) = 17  ' Teargas
    WeaponSlotCombo(17, 0) = 7:    WeaponSlotCombo(17, 1) = 2
    WeaponSlotMatrix(7, 3) = 18  ' Molotov Cocktail
    WeaponSlotCombo(18, 0) = 7:    WeaponSlotCombo(18, 1) = 3
    WeaponSlotMatrix(7, 4) = 39  ' Remote Explosives
    WeaponSlotCombo(39, 0) = 7:    WeaponSlotCombo(39, 1) = 4
    'Special 1:
    WeaponSlotMatrix(8, 1) = 41  ' Spray Can
    WeaponSlotCombo(41, 0) = 8:    WeaponSlotCombo(41, 1) = 1
    WeaponSlotMatrix(8, 2) = 42  ' Fire Extinguisher
    WeaponSlotCombo(42, 0) = 8:    WeaponSlotCombo(42, 1) = 2
    WeaponSlotMatrix(8, 3) = 43  ' Camera
    WeaponSlotCombo(43, 0) = 8:    WeaponSlotCombo(43, 1) = 3
    'Gifts:
    WeaponSlotMatrix(9, 1) = 14  ' Flowers
    WeaponSlotCombo(14, 0) = 9:    WeaponSlotCombo(14, 1) = 1
    WeaponSlotMatrix(9, 2) = 10  ' Dildo 1
    WeaponSlotCombo(10, 0) = 9:    WeaponSlotCombo(10, 1) = 2
    WeaponSlotMatrix(9, 3) = 11  ' Dildo 2
    WeaponSlotCombo(11, 0) = 9:    WeaponSlotCombo(11, 1) = 3
    WeaponSlotMatrix(9, 4) = 12  ' Vibe 1
    WeaponSlotCombo(12, 0) = 9:    WeaponSlotCombo(12, 1) = 4
    WeaponSlotMatrix(9, 5) = 13  ' Vibe 2
    WeaponSlotCombo(13, 0) = 9:    WeaponSlotCombo(13, 1) = 5
    WeaponSlotMatrix(9, 6) = 15  ' Cane
    WeaponSlotCombo(15, 0) = 9:    WeaponSlotCombo(15, 1) = 6
    'Special 2:
    WeaponSlotMatrix(10, 1) = 44  ' NV Goggles
    WeaponSlotCombo(44, 0) = 10:    WeaponSlotCombo(44, 1) = 1
    WeaponSlotMatrix(10, 2) = 45  ' IR Goggles (CRASH)
    WeaponSlotCombo(45, 0) = 10:    WeaponSlotCombo(45, 1) = 2
    WeaponSlotMatrix(10, 3) = 46  ' Parachute
    WeaponSlotCombo(46, 0) = 10:    WeaponSlotCombo(46, 1) = 3
    
    WeaponIDtoDatID(1) = 331:   DatIDtoWeaponID(331) = 1    'Brass Knuckles
    WeaponIDtoDatID(2) = 333:   DatIDtoWeaponID(333) = 2    'Golf Club
    WeaponIDtoDatID(3) = 334:   DatIDtoWeaponID(334) = 3    'Nitestick
    WeaponIDtoDatID(4) = 335:   DatIDtoWeaponID(335) = 4    'Knife
    WeaponIDtoDatID(5) = 336:   DatIDtoWeaponID(336) = 5    'Baseball Bat
    WeaponIDtoDatID(6) = 337:   DatIDtoWeaponID(337) = 6    'Shovel
    WeaponIDtoDatID(7) = 338:   DatIDtoWeaponID(338) = 7    'Pool Cue
    WeaponIDtoDatID(8) = 339:   DatIDtoWeaponID(339) = 8    'Katana
    WeaponIDtoDatID(9) = 341:   DatIDtoWeaponID(341) = 9    'Chainsaw
    WeaponIDtoDatID(10) = 321:  DatIDtoWeaponID(321) = 10   'Dildo 1
    WeaponIDtoDatID(11) = 322:  DatIDtoWeaponID(322) = 11   'Dildo 2
    WeaponIDtoDatID(12) = 323:  DatIDtoWeaponID(323) = 12   'Vibe 1
    WeaponIDtoDatID(13) = 324:  DatIDtoWeaponID(324) = 13   'Vibe 2
    WeaponIDtoDatID(14) = 325:  DatIDtoWeaponID(325) = 14   'Flowers
    WeaponIDtoDatID(15) = 326:  DatIDtoWeaponID(326) = 15   'Cane
    WeaponIDtoDatID(16) = 342:  DatIDtoWeaponID(342) = 16   'Grenade
    WeaponIDtoDatID(17) = 343:  DatIDtoWeaponID(343) = 17   'Teargas
    WeaponIDtoDatID(18) = 344:  DatIDtoWeaponID(344) = 18   'Molotov Cocktail
    'was WeaponIDtoDatID(19) = 0:    DatIDtoWeaponID(0) = 19
    'was WeaponIDtoDatID(20) = 0:    DatIDtoWeaponID(0) = 20
    'was WeaponIDtoDatID(21) = 0:    DatIDtoWeaponID(0) = 21
    WeaponIDtoDatID(22) = 346:  DatIDtoWeaponID(346) = 22   'Pistol
    WeaponIDtoDatID(23) = 347:  DatIDtoWeaponID(347) = 23   'Silenced Pistol
    WeaponIDtoDatID(24) = 348:  DatIDtoWeaponID(348) = 24   'Desert Eagle
    WeaponIDtoDatID(25) = 349:  DatIDtoWeaponID(349) = 25   'Shotgun
    WeaponIDtoDatID(26) = 350:  DatIDtoWeaponID(350) = 26   'Sawn-Off Shotgun
    WeaponIDtoDatID(27) = 351:  DatIDtoWeaponID(351) = 27   'SPAZ12
    WeaponIDtoDatID(28) = 352:  DatIDtoWeaponID(352) = 28   'Micro UZI
    WeaponIDtoDatID(29) = 353:  DatIDtoWeaponID(353) = 29   'MP5
    WeaponIDtoDatID(30) = 355:  DatIDtoWeaponID(355) = 30   'AK47
    WeaponIDtoDatID(31) = 356:  DatIDtoWeaponID(356) = 31   'M4
    WeaponIDtoDatID(32) = 372:  DatIDtoWeaponID(372) = 32   'Tech9
    WeaponIDtoDatID(33) = 357:  DatIDtoWeaponID(357) = 33   'Country Rifle
    WeaponIDtoDatID(34) = 358:  DatIDtoWeaponID(358) = 34   'Sniper Rifle
    WeaponIDtoDatID(35) = 359:  DatIDtoWeaponID(359) = 35   'Rocket Launcher
    WeaponIDtoDatID(36) = 360:  DatIDtoWeaponID(360) = 36   'Heat Seaking RPG
    WeaponIDtoDatID(37) = 361:  DatIDtoWeaponID(361) = 37   'Flame Thrower
    WeaponIDtoDatID(38) = 362:  DatIDtoWeaponID(362) = 38   'Minigun
    WeaponIDtoDatID(39) = 363:  DatIDtoWeaponID(363) = 39   'Remote Explosives
    WeaponIDtoDatID(40) = 364:  DatIDtoWeaponID(364) = 40   'Detonator(for remote explosives)
    WeaponIDtoDatID(41) = 365:  DatIDtoWeaponID(365) = 41   'Spray Can
    WeaponIDtoDatID(42) = 366:  DatIDtoWeaponID(366) = 42   'Fire Extinguisher
    WeaponIDtoDatID(43) = 367:  DatIDtoWeaponID(367) = 43   'Camera
    WeaponIDtoDatID(44) = 368:  DatIDtoWeaponID(368) = 44   'NV Goggles
    WeaponIDtoDatID(45) = 369:  DatIDtoWeaponID(369) = 45   'IR Goggles (CRASH)
    WeaponIDtoDatID(46) = 371:  DatIDtoWeaponID(371) = 46   'Parachute
    GetSettings = AssignConsoleCommands
Exit Function
errGetSettings:
    MsgBox Err.Description, , "Initialisation failed"
    Err.Clear
End Function

Private Function AssignConsoleCommands() As Boolean
On Error GoTo errAssignConsoleCommands
    
    'Console Commands:
    GTASAConsoleCommands(0).Description = "Set Armor Level to:"
    GTASAConsoleCommands(0).DataPage = 0
    GTASAConsoleCommands(1).Description = "Auto-Fix Armor Level to:"
    GTASAConsoleCommands(1).DataPage = 0
    GTASAConsoleCommands(2).Description = "Auto-Fix Armor:"
    GTASAConsoleCommands(2).DataPage = 16
    GTASAConsoleCommands(3).Description = "Set Health Level to:"
    GTASAConsoleCommands(3).DataPage = 1
    GTASAConsoleCommands(4).Description = "Auto-Fix Health Level to:"
    GTASAConsoleCommands(4).DataPage = 1
    GTASAConsoleCommands(5).Description = "Auto-Fix Health:"
    GTASAConsoleCommands(5).DataPage = 16
    GTASAConsoleCommands(6).Description = "Set Car Specialities to:"
    GTASAConsoleCommands(6).DataPage = 5
    GTASAConsoleCommands(7).Description = "Auto-Fix Car Specialities:"
    GTASAConsoleCommands(7).DataPage = 16
    GTASAConsoleCommands(8).Description = "Set Car Doors to:"
    GTASAConsoleCommands(8).DataPage = 6
    GTASAConsoleCommands(9).Description = "Auto-Lock Car Doors:"
    GTASAConsoleCommands(9).DataPage = 16
    GTASAConsoleCommands(10).Description = "Prevent Wheel Damage:"
    GTASAConsoleCommands(10).DataPage = 16
    GTASAConsoleCommands(11).Description = "Set Engine Health To:"
    GTASAConsoleCommands(11).DataPage = 8
    GTASAConsoleCommands(12).Description = "Auto-Fix Engine Health:"
    GTASAConsoleCommands(12).DataPage = 16
    GTASAConsoleCommands(13).Description = "Set Car Weight to:"
    GTASAConsoleCommands(13).DataPage = 9
    GTASAConsoleCommands(14).Description = "Auto-Fix Car Weight:"
    GTASAConsoleCommands(14).DataPage = 16
    GTASAConsoleCommands(15).Description = "Paint My Car To:"
    GTASAConsoleCommands(15).DataPage = 10
    GTASAConsoleCommands(16).Description = "Auto-Paint My Car:"
    GTASAConsoleCommands(16).DataPage = 16
    GTASAConsoleCommands(17).Description = "Stop Car Alarm:"
    GTASAConsoleCommands(17).DataPage = 16
    GTASAConsoleCommands(18).Description = "Set Car Direction to:"
    GTASAConsoleCommands(18).DataPage = 11
    GTASAConsoleCommands(19).Description = "KickStart Car to:"
    GTASAConsoleCommands(19).DataPage = 11
    GTASAConsoleCommands(20).Description = "Flip Car back on 4 wheels:"
    GTASAConsoleCommands(20).DataPage = 17
    GTASAConsoleCommands(21).Description = "Stop X Speed"
    GTASAConsoleCommands(21).DataPage = 17
    GTASAConsoleCommands(22).Description = "Stop Y Speed"
    GTASAConsoleCommands(22).DataPage = 17
    GTASAConsoleCommands(23).Description = "Stop Z Speed"
    GTASAConsoleCommands(23).DataPage = 17
    GTASAConsoleCommands(24).Description = "Stop All Speed"
    GTASAConsoleCommands(24).DataPage = 17
    GTASAConsoleCommands(25).Description = "Stop X Spin"
    GTASAConsoleCommands(25).DataPage = 17
    GTASAConsoleCommands(26).Description = "Stop Y Spin"
    GTASAConsoleCommands(26).DataPage = 17
    GTASAConsoleCommands(27).Description = "Stop Z Spin"
    GTASAConsoleCommands(27).DataPage = 17
    GTASAConsoleCommands(28).Description = "Stop All Spin"
    GTASAConsoleCommands(28).DataPage = 17
    GTASAConsoleCommands(29).Description = "Stop All (Freeze Car)"
    GTASAConsoleCommands(29).DataPage = 17
    GTASAConsoleCommands(30).Description = "Set X Speed to:"
    GTASAConsoleCommands(30).DataPage = 13
    GTASAConsoleCommands(31).Description = "Set Y Speed to:"
    GTASAConsoleCommands(31).DataPage = 13
    GTASAConsoleCommands(32).Description = "Set Z Speed to:"
    GTASAConsoleCommands(32).DataPage = 13
    GTASAConsoleCommands(33).Description = "Set X Spin to:"
    GTASAConsoleCommands(33).DataPage = 13
    GTASAConsoleCommands(34).Description = "Set Y Spin to:"
    GTASAConsoleCommands(34).DataPage = 13
    GTASAConsoleCommands(35).Description = "Set Z Spin to:"
    GTASAConsoleCommands(35).DataPage = 13
    GTASAConsoleCommands(36).Description = "Increase X Speed by:"
    GTASAConsoleCommands(36).DataPage = 13
    GTASAConsoleCommands(37).Description = "Increase Y Speed by:"
    GTASAConsoleCommands(37).DataPage = 13
    GTASAConsoleCommands(38).Description = "Increase Z Speed by:"
    GTASAConsoleCommands(38).DataPage = 13
    GTASAConsoleCommands(39).Description = "Decrease X Speed by:"
    GTASAConsoleCommands(39).DataPage = 13
    GTASAConsoleCommands(40).Description = "Decrease Y Speed by:"
    GTASAConsoleCommands(40).DataPage = 13
    GTASAConsoleCommands(41).Description = "Decrease Z Speed by:"
    GTASAConsoleCommands(41).DataPage = 13
    GTASAConsoleCommands(42).Description = "Increase X Spin by:"
    GTASAConsoleCommands(42).DataPage = 13
    GTASAConsoleCommands(43).Description = "Increase Y Spin by:"
    GTASAConsoleCommands(43).DataPage = 13
    GTASAConsoleCommands(44).Description = "Increase Z Spin by:"
    GTASAConsoleCommands(44).DataPage = 13
    GTASAConsoleCommands(45).Description = "Decrease X Spin by:"
    GTASAConsoleCommands(45).DataPage = 13
    GTASAConsoleCommands(46).Description = "Decrease Y Spin by:"
    GTASAConsoleCommands(46).DataPage = 13
    GTASAConsoleCommands(47).Description = "Decrease Z Spin by:"
    GTASAConsoleCommands(47).DataPage = 13
    GTASAConsoleCommands(48).Description = "Set Clock Speed to:"
    GTASAConsoleCommands(48).DataPage = 14
    GTASAConsoleCommands(49).Description = "Increase Clock Speed"
    GTASAConsoleCommands(49).DataPage = 17
    GTASAConsoleCommands(50).Description = "Decrease Clock Speed"
    GTASAConsoleCommands(50).DataPage = 17
    GTASAConsoleCommands(51).Description = "Clear Cheated Status"
    GTASAConsoleCommands(51).DataPage = 17
    GTASAConsoleCommands(52).Description = "Set Clock Speed to Real Time"
    GTASAConsoleCommands(52).DataPage = 17
    GTASAConsoleCommands(53).Description = "Set Clock Speed to Normal Game Time"
    GTASAConsoleCommands(53).DataPage = 17
    GTASAConsoleCommands(54).Description = "Set Car Speed To:"
    GTASAConsoleCommands(54).DataPage = 13
    GTASAConsoleCommands(55).Description = "Increase Car Speed by:"
    GTASAConsoleCommands(55).DataPage = 13
    GTASAConsoleCommands(56).Description = "Flight Assistance:"
    GTASAConsoleCommands(56).DataPage = 16
    GTASAConsoleCommands(57).Description = "Flight Assistance Level:"
    GTASAConsoleCommands(57).DataPage = 8
    GTASAConsoleCommands(58).Description = "* not available any more" 'Release from Camera-Lock"
    GTASAConsoleCommands(58).DataPage = 17
    GTASAConsoleCommands(59).Description = "Silent Mode (no Feedback):"
    GTASAConsoleCommands(59).DataPage = 16
    GTASAConsoleCommands(60).Description = "Stop Alarm of my car"
    GTASAConsoleCommands(60).DataPage = 17
    GTASAConsoleCommands(61).Description = "Take me to my last car (only if on Foot)"
    GTASAConsoleCommands(61).DataPage = 17
    GTASAConsoleCommands(62).Description = "Bring my last car to me (only if on Foot)"
    GTASAConsoleCommands(62).DataPage = 17
    GTASAConsoleCommands(63).Description = "Remember my location as Markup Location "
    GTASAConsoleCommands(63).DataPage = 18
    GTASAConsoleCommands(64).Description = "Take me to Markup Location "
    GTASAConsoleCommands(64).DataPage = 18
    GTASAConsoleCommands(65).Description = "Take me to my previous car (only if on Foot)"
    GTASAConsoleCommands(65).DataPage = 17
    GTASAConsoleCommands(66).Description = "Bring my previous car to me (only if on Foot)"
    GTASAConsoleCommands(66).DataPage = 17
    GTASAConsoleCommands(67).Description = "Set Doors of my Preivous Car to:"
    GTASAConsoleCommands(67).DataPage = 6
    GTASAConsoleCommands(68).Description = "Turn My Car in Clock Direction by:"  ' 0-180 Degrees
    GTASAConsoleCommands(68).DataPage = 19
    GTASAConsoleCommands(69).Description = "Turn My Car in Counterclock Direction by:"  ' 0-180 Degrees
    GTASAConsoleCommands(69).DataPage = 19
    GTASAConsoleCommands(70).Description = "Torch my (last) car"
    GTASAConsoleCommands(70).DataPage = 17
    GTASAConsoleCommands(71).Description = "Torch my previous car"
    GTASAConsoleCommands(71).DataPage = 17
    GTASAConsoleCommands(72).Description = "Set Game Speed to:"
    GTASAConsoleCommands(72).DataPage = 14
    GTASAConsoleCommands(73).Description = "Increase Game Speed"
    GTASAConsoleCommands(73).DataPage = 17
    GTASAConsoleCommands(74).Description = "Decrease Game Speed"
    GTASAConsoleCommands(74).DataPage = 17
    GTASAConsoleCommands(75).Description = "Freeze Game Clock"
    GTASAConsoleCommands(75).DataPage = 17
    GTASAConsoleCommands(76).Description = "Thaw Game Clock"
    GTASAConsoleCommands(76).DataPage = 17
    GTASAConsoleCommands(77).Description = "Teleport to next Location"
    GTASAConsoleCommands(77).DataPage = 17
    GTASAConsoleCommands(78).Description = "Teleport to previous Location"
    GTASAConsoleCommands(78).DataPage = 17
    GTASAConsoleCommands(79).Description = "Prepare for Date with Denise"
    GTASAConsoleCommands(79).DataPage = 17
    GTASAConsoleCommands(80).Description = "Prepare for Date with Michelle"
    GTASAConsoleCommands(80).DataPage = 17
    GTASAConsoleCommands(81).Description = "Prepare for Date with Helena"
    GTASAConsoleCommands(81).DataPage = 17
    GTASAConsoleCommands(82).Description = "Prepare for Date with Katie"
    GTASAConsoleCommands(82).DataPage = 17
    GTASAConsoleCommands(83).Description = "Prepare for Date with Barbara"
    GTASAConsoleCommands(83).DataPage = 17
    GTASAConsoleCommands(84).Description = "Prepare for Date with Millie"
    GTASAConsoleCommands(84).DataPage = 17
    GTASAConsoleCommands(85).Description = "Toggle Never Wanted"
    GTASAConsoleCommands(85).DataPage = 17
    GTASAConsoleCommands(86).Description = "Toggle Never Get Hungry"
    GTASAConsoleCommands(86).DataPage = 17
    GTASAConsoleCommands(87).Description = "Toggle Infinite Health"
    GTASAConsoleCommands(87).DataPage = 17
    GTASAConsoleCommands(88).Description = "Toggle Infinite Oxygen"
    GTASAConsoleCommands(88).DataPage = 17
    GTASAConsoleCommands(89).Description = "Toggle Infinite Ammo"
    GTASAConsoleCommands(89).DataPage = 17
    GTASAConsoleCommands(90).Description = "Toggle Tank Mode"
    GTASAConsoleCommands(90).DataPage = 17
    GTASAConsoleCommands(91).Description = "Toggle Mega Punch"
    GTASAConsoleCommands(91).DataPage = 17
    GTASAConsoleCommands(92).Description = "Toggle Mega Jump"
    GTASAConsoleCommands(92).DataPage = 17
    GTASAConsoleCommands(93).Description = "Toggle Infinite Run"
    GTASAConsoleCommands(93).DataPage = 17
    GTASAConsoleCommands(94).Description = "Toggle Fireproof"
    GTASAConsoleCommands(94).DataPage = 17
    GTASAConsoleCommands(95).Description = "Advance Game Time by 1 Hour"
    GTASAConsoleCommands(95).DataPage = 17
    GTASAConsoleCommands(96).Description = "Revert Game Time by 1 Hour"
    GTASAConsoleCommands(96).DataPage = 17
    GTASAConsoleCommands(97).Description = "Stop Ped X Speed"
    GTASAConsoleCommands(97).DataPage = 17
    GTASAConsoleCommands(98).Description = "Stop Ped Y Speed"
    GTASAConsoleCommands(98).DataPage = 17
    GTASAConsoleCommands(99).Description = "Stop Ped Z Speed"
    GTASAConsoleCommands(99).DataPage = 17
    GTASAConsoleCommands(100).Description = "Stop All Ped Speed"
    GTASAConsoleCommands(100).DataPage = 17
    GTASAConsoleCommands(101).Description = "Set Ped X Speed to:"
    GTASAConsoleCommands(101).DataPage = 13
    GTASAConsoleCommands(102).Description = "Set Ped Y Speed to:"
    GTASAConsoleCommands(102).DataPage = 13
    GTASAConsoleCommands(103).Description = "Set Ped Z Speed to:"
    GTASAConsoleCommands(103).DataPage = 13
    GTASAConsoleCommands(104).Description = "Increase Ped X Speed by:"
    GTASAConsoleCommands(104).DataPage = 13
    GTASAConsoleCommands(105).Description = "Increase Ped Y Speed by:"
    GTASAConsoleCommands(105).DataPage = 13
    GTASAConsoleCommands(106).Description = "Increase Ped Z Speed by:"
    GTASAConsoleCommands(106).DataPage = 13
    GTASAConsoleCommands(107).Description = "Decrease Ped X Speed by:"
    GTASAConsoleCommands(107).DataPage = 13
    GTASAConsoleCommands(108).Description = "Decrease Ped Y Speed by:"
    GTASAConsoleCommands(108).DataPage = 13
    GTASAConsoleCommands(109).Description = "Decrease Ped Z Speed by:"
    GTASAConsoleCommands(109).DataPage = 13
    GTASAConsoleCommands(110).Description = "Set Ped Speed To:"
    GTASAConsoleCommands(110).DataPage = 13
    GTASAConsoleCommands(111).Description = "Increase Ped Speed by:"
    GTASAConsoleCommands(111).DataPage = 13
    GTASAConsoleCommands(112).Description = "Ped Flight Assistance:"
    GTASAConsoleCommands(112).DataPage = 16
    GTASAConsoleCommands(113).Description = "Ped Flight Assistance Level:"
    GTASAConsoleCommands(113).DataPage = 8
    GTASAConsoleCommands(114).Description = "Turn Ped in Clock Direction by:"  ' 0-180 Degrees
    GTASAConsoleCommands(114).DataPage = 19
    GTASAConsoleCommands(115).Description = "Turn Ped in Counterclock Direction by:"  ' 0-180 Degrees
    GTASAConsoleCommands(115).DataPage = 19
    'Perfect Handling=14'Decreased Traffic=15'Huge Bunny Hop=16'Cars Have Nitro=17'Boats can Fly=18'Cars can Fly=19
    GTASAConsoleCommands(116).Description = "Toggle Perfect Handling"
    GTASAConsoleCommands(116).DataPage = 17
    GTASAConsoleCommands(117).Description = "Toggle Decreased Traffic"
    GTASAConsoleCommands(117).DataPage = 17
    GTASAConsoleCommands(118).Description = "Toggle Huge Bunny Hop"
    GTASAConsoleCommands(118).DataPage = 17
    GTASAConsoleCommands(119).Description = "Toggle Cars have Nitro"
    GTASAConsoleCommands(119).DataPage = 17
    GTASAConsoleCommands(120).Description = "Toggle Boats can Fly"
    GTASAConsoleCommands(120).DataPage = 17
    GTASAConsoleCommands(121).Description = "Toggle Cars can Fly"
    GTASAConsoleCommands(121).DataPage = 17
    GTASAConsoleCommands(122).Description = "Spawn Car"
    GTASAConsoleCommands(122).DataPage = 12
    GTASAConsoleCommands(123).Description = "Set Weather to:"
    GTASAConsoleCommands(123).DataPage = 7
    GTASAConsoleCommands(124).Description = "Toggle Weather Lock"
    GTASAConsoleCommands(124).DataPage = 17
    
    GTASAConsoleCommands(125).Description = "Toggle One Hit Kill"
    GTASAConsoleCommands(125).DataPage = 17
    GTASAConsoleCommands(126).Description = "Toggle Freeze Mission Timers"
    GTASAConsoleCommands(126).DataPage = 17
    
    GTASAConsoleCommands(127).Description = "Give Weapon & Ammo"
    GTASAConsoleCommands(127).DataPage = 3
    GTASAConsoleCommands(128).Description = "Remove Current Weapon"
    GTASAConsoleCommands(128).DataPage = 17
    GTASAConsoleCommands(129).Description = "Clear All Weapons"
    GTASAConsoleCommands(129).DataPage = 17
    
    
    AssignConsoleCommands = True
Exit Function
errAssignConsoleCommands:
    MsgBox Err.Description, , "Initialisation failed"
    Err.Clear
End Function

Public Sub QuicksortString(list() As String, ByVal min As Integer, ByVal max As Integer)
On Error Resume Next
    Dim med_value As String
    Dim hi As Integer
    Dim lo As Integer
    Dim i As Integer

    ' If the list has no more than CutOff elements,
    ' finish it off with SelectionSort.
    If max <= min Then Exit Sub

    ' Pick the dividing value.
    i = Int((max - min + 1) * Rnd + min)
    med_value = list(i)

    ' Swap it to the front.
    list(i) = list(min)

    lo = min
    hi = max
    Do
        ' Look down from hi for a value < med_value.
        Do While list(hi) >= med_value
            hi = hi - 1
            If hi <= lo Then Exit Do
        Loop
        If hi <= lo Then
            list(lo) = med_value
            Exit Do
        End If

        ' Swap the lo and hi values.
        list(lo) = list(hi)
        
        ' Look up from lo for a value >= med_value.
        lo = lo + 1
        Do While list(lo) < med_value
            lo = lo + 1
            If lo >= hi Then Exit Do
        Loop
        If lo >= hi Then
            lo = hi
            list(hi) = med_value
            Exit Do
        End If
        
        ' Swap the lo and hi values.
        list(hi) = list(lo)
    Loop
    
    ' Sort the two sublists.
    QuicksortString list(), min, lo - 1
    QuicksortString list(), lo + 1, max
End Sub

