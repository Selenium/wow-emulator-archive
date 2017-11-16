' Spell database initialization script.
'
'Last  update: 08.03.2007
'Version support: 2.0.8



Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports vbWoW.Filebase
Imports vbWoW.Logbase.BaseWriter
Imports vbWoW.WorldServer

Namespace Scripts
    Public Module Initializators

        Public Sub Initialize()
            InitializeSpellRadius()
            InitializeSpellDuration()
            InitializeSpellCastTime()
            InitializeSpellRange()
            InitializeSpellFocusObject()


            InitializeSpells()
        End Sub

        Public Sub InitializeSpellRadius()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SpellRadius.dbc")

            Dim radiusID As Integer
            Dim radiusValue As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                radiusID = tmpDBC.Item(i, 0)
                radiusValue = tmpDBC.Item(i, 1, DBC.DBCValueType.DBC_FLOAT)

                SpellRadius(radiusID) = radiusValue
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SpellRadius initialized.", i)
        End Sub
        Public Sub InitializeSpellCastTime()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SpellCastTimes.dbc")

            Dim spellCastID As Integer
            Dim spellCastTimeS As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                spellCastID = tmpDBC.Item(i, 0)
                spellCastTimeS = tmpDBC.Item(i, 1)

                SpellCastTime(spellCastID) = spellCastTimeS
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SpellCastTimes initialized.", i)
        End Sub
        Public Sub InitializeSpellRange()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SpellRange.dbc")

            Dim spellRangeIndex As Integer
            Dim spellRangeMax As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                spellRangeIndex = tmpDBC.Item(i, 0)
                'spellRangeMin = tmpDBC.Item(i, 1, DBC.DBCValueType.DBC_FLOAT)
                spellRangeMax = tmpDBC.Item(i, 2, DBC.DBCValueType.DBC_FLOAT)

                SpellRange(spellRangeIndex) = spellRangeMax
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SpellRange initialized.", i)
        End Sub
        Public Sub InitializeSpellFocusObject()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SpellFocusObject.dbc")

            Dim spellFocusIndex As Integer
            Dim spellFocusObjectName As String

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                spellFocusIndex = tmpDBC.Item(i, 0)
                spellFocusObjectName = tmpDBC.Item(i, 1, DBC.DBCValueType.DBC_STRING)

                SpellFocusObject(spellFocusIndex) = spellFocusObjectName
            Next i

            tmpDBC.Dispose()
           Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SpellFocusObject initialized.", i)
        End Sub
        Public Sub InitializeSpellDuration()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SpellDuration.dbc")

            Dim SpellDurationIndex As Integer
            Dim SpellDurationValue As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                SpellDurationIndex = tmpDBC.Item(i, 0)
                SpellDurationValue = tmpDBC.Item(i, 1)

                SpellDuration(SpellDurationIndex) = SpellDurationValue
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SpellDuration initialized.", i)
        End Sub

        Public Sub InitializeSpells()
            Dim SpellDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\Spell.dbc")
            'Console.WriteLine("[" & Format(TimeOfDay, "hh:mm:ss") & "] " & SpellDBC.GetFileInformation)

            Dim i As Integer
            For i = 0 To SpellDBC.Rows - 1
                Try
                    Dim ID As Integer = SpellDBC.Item(i, 0)
                    SPELLs(id) = New SpellInfo
                    SPELLs(id).ID = ID
                    SPELLs(id).school = SpellDBC.Item(i, 1)
                    SPELLs(id).category = SpellDBC.Item(i, 2)
                    SPELLs(id).dispellType = SpellDBC.Item(i, 4)
                    'mechanic = 5
                    SPELLs(id).attributes = SpellDBC.Item(i, 6)
                    SPELLs(id).attributesEx = SpellDBC.Item(i, 7)
                    SPELLs(id).requredCasterStance = SpellDBC.Item(i, 11)
                    SPELLs(id).target = SpellDBC.Item(i, 13)
                    SPELLs(id).targetCreatureType = SpellDBC.Item(i, 14)
                    SPELLs(id).FocusObjectIndex = SpellDBC.Item(i, 13)
                    SPELLs(id).spellCastTimeIndex = SpellDBC.Item(i, 21)
                    SPELLs(id).categoryCooldown = SpellDBC.Item(i, 22)
                    SPELLs(id).spellCooldown = SpellDBC.Item(i, 23)
                    SPELLs(id).interruptFlags = SpellDBC.Item(i, 24)
                    SPELLs(id).auraInterruptFlags = SpellDBC.Item(i, 25)
                    SPELLs(id).channelInterruptFlags = SpellDBC.Item(i, 26)
                    SPELLs(id).procFlags = SpellDBC.Item(i, 27)
                    SPELLs(id).procChance = SpellDBC.Item(i, 28)
                    SPELLs(id).procCharges = SpellDBC.Item(i, 29)
                    SPELLs(id).maxLevel = SpellDBC.Item(i, 30)
                    SPELLs(id).baseLevel = SpellDBC.Item(i, 31)
                    SPELLs(id).spellLevel = SpellDBC.Item(i, 32)
                    SPELLs(id).DurationIndex = SpellDBC.Item(i, 33)
                    SPELLs(id).powerType = SpellDBC.Item(i, 34)
                    SPELLs(id).manaCost = SpellDBC.Item(i, 35)
                    SPELLs(id).manaCostPerlevel = SpellDBC.Item(i, 36)
                    SPELLs(id).manaPerSecond = SpellDBC.Item(i, 37)
                    'SPELLs(id).manaPerSecondPerLevel =	SpellDBC.Item(i,38)
                    SPELLs(id).rangeIndex = SpellDBC.Item(i, 39)
                    SPELLs(id).speed = SpellDBC.Item(i, 40, DBC.DBCValueType.DBC_FLOAT)
                    SPELLs(id).modalNextSpell = SpellDBC.Item(i, 41)
                    SPELLs(id).totem(0) = SpellDBC.Item(i, 43)
                    SPELLs(id).totem(1) = SpellDBC.Item(i, 44)

                    SPELLs(id).reagents(0) = SpellDBC.Item(i, 45)
                    SPELLs(id).reagents(1) = SpellDBC.Item(i, 46)
                    SPELLs(id).reagents(2) = SpellDBC.Item(i, 47)
                    SPELLs(id).reagents(3) = SpellDBC.Item(i, 48)
                    SPELLs(id).reagents(4) = SpellDBC.Item(i, 49)
                    SPELLs(id).reagents(5) = SpellDBC.Item(i, 50)
                    SPELLs(id).reagents(6) = SpellDBC.Item(i, 51)
                    SPELLs(id).reagents(7) = SpellDBC.Item(i, 52)

                    SPELLs(id).reagentsCount(0) = SpellDBC.Item(i, 53)
                    SPELLs(id).reagentsCount(1) = SpellDBC.Item(i, 54)
                    SPELLs(id).reagentsCount(2) = SpellDBC.Item(i, 55)
                    SPELLs(id).reagentsCount(3) = SpellDBC.Item(i, 56)
                    SPELLs(id).reagentsCount(4) = SpellDBC.Item(i, 57)
                    SPELLs(id).reagentsCount(5) = SpellDBC.Item(i, 58)
                    SPELLs(id).reagentsCount(6) = SpellDBC.Item(i, 59)
                    SPELLs(id).reagentsCount(7) = SpellDBC.Item(i, 60)

                    SPELLs(id).equippedItemClass = SpellDBC.Item(i, 61)
                    SPELLs(id).equippedItemSubClass = SpellDBC.Item(i, 62)
                    SPELLs(id).spellVisual = SpellDBC.Item(i, 115)
                    'SPELLs(id).name =					SpellDBC.Item(i,120,DBC.DBCValueType.DBC_STRING)
                    'Console.Writeline("Spellloaded={0}",SPELLs(i).name)


                    If Int(SpellDBC.Item(i, 64)) <> 0 Then
                        SPELLs(id).SpellEffects(0) = New SpellEffect

                        SPELLs(id).SpellEffects(0).ID = SpellDBC.Item(i, 64)
                        SPELLs(id).SpellEffects(0).diceBase = SpellDBC.Item(i, 70)
                        SPELLs(id).SpellEffects(0).dicePerLevel = SpellDBC.Item(i, 73)
                        SPELLs(id).SpellEffects(0).valueBase = SpellDBC.Item(i, 79)
                        SPELLs(id).SpellEffects(0).valuePerLevel = SpellDBC.Item(i, 76, DBC.DBCValueType.DBC_FLOAT)
                        SPELLs(id).SpellEffects(0).valuePerComboPoint = SpellDBC.Item(i, 115)
                        SPELLs(id).SpellEffects(0).valueDie = SpellDBC.Item(i, 67)
                        SPELLs(id).SpellEffects(0).implicitTargetA = SpellDBC.Item(i, 85)
                        SPELLs(id).SpellEffects(0).implicitTargetB = SpellDBC.Item(i, 88)
                        SPELLs(id).SpellEffects(0).RadiusIndex = SpellDBC.Item(i, 91)
                        SPELLs(id).SpellEffects(0).ApplyAuraIndex = SpellDBC.Item(i, 94)
                        SPELLs(id).SpellEffects(0).Amplitude = SpellDBC.Item(i, 97)
                        SPELLs(id).SpellEffects(0).ChainTarget = SpellDBC.Item(i, 100)
                        SPELLs(id).SpellEffects(0).ItemType = SpellDBC.Item(i, 106)
                        SPELLs(id).SpellEffects(0).MiscValue = SpellDBC.Item(i, 109)
                        SPELLs(id).SpellEffects(0).TriggerSpell = SpellDBC.Item(i, 112)
                    Else
                        SPELLs(id).SpellEffects(0) = Nothing
                    End If



                    If Int(SpellDBC.Item(i, 65)) <> 0 Then
                        SPELLs(id).SpellEffects(1) = New SpellEffect

                        SPELLs(id).SpellEffects(1).ID = SpellDBC.Item(i, 65)
                        SPELLs(id).SpellEffects(1).diceBase = SpellDBC.Item(i, 71)
                        SPELLs(id).SpellEffects(1).dicePerLevel = SpellDBC.Item(i, 74)
                        SPELLs(id).SpellEffects(1).valueBase = SpellDBC.Item(i, 80)
                        SPELLs(id).SpellEffects(1).valuePerLevel = SpellDBC.Item(i, 77, DBC.DBCValueType.DBC_FLOAT)
                        SPELLs(id).SpellEffects(1).valuePerComboPoint = SpellDBC.Item(i, 116)
                        SPELLs(id).SpellEffects(1).valueDie = SpellDBC.Item(i, 68)
                        SPELLs(id).SpellEffects(1).implicitTargetA = SpellDBC.Item(i, 86)
                        SPELLs(id).SpellEffects(1).implicitTargetB = SpellDBC.Item(i, 89)
                        SPELLs(id).SpellEffects(1).RadiusIndex = SpellDBC.Item(i, 92)
                        SPELLs(id).SpellEffects(1).ApplyAuraIndex = SpellDBC.Item(i, 95)
                        SPELLs(id).SpellEffects(1).Amplitude = SpellDBC.Item(i, 98)
                        SPELLs(id).SpellEffects(1).ChainTarget = SpellDBC.Item(i, 101)
                        SPELLs(id).SpellEffects(1).ItemType = SpellDBC.Item(i, 107)
                        SPELLs(id).SpellEffects(1).MiscValue = SpellDBC.Item(i, 110)
                        SPELLs(id).SpellEffects(1).TriggerSpell = SpellDBC.Item(i, 113)
                    Else
                        SPELLs(id).SpellEffects(1) = Nothing
                    End If



                    If Int(SpellDBC.Item(i, 66)) <> 0 Then
                        SPELLs(id).SpellEffects(2) = New SpellEffect

                        SPELLs(id).SpellEffects(2).ID = SpellDBC.Item(i, 66)
                        SPELLs(id).SpellEffects(2).diceBase = SpellDBC.Item(i, 72)
                        SPELLs(id).SpellEffects(2).dicePerLevel = SpellDBC.Item(i, 75)
                        SPELLs(id).SpellEffects(2).valueBase = SpellDBC.Item(i, 81)
                        SPELLs(id).SpellEffects(2).valuePerLevel = SpellDBC.Item(i, 78, DBC.DBCValueType.DBC_FLOAT)
                        SPELLs(id).SpellEffects(2).valuePerComboPoint = SpellDBC.Item(i, 117)
                        SPELLs(id).SpellEffects(2).valueDie = SpellDBC.Item(i, 69)
                        SPELLs(id).SpellEffects(2).implicitTargetA = SpellDBC.Item(i, 87)
                        SPELLs(id).SpellEffects(2).implicitTargetB = SpellDBC.Item(i, 90)
                        SPELLs(id).SpellEffects(2).RadiusIndex = SpellDBC.Item(i, 93)
                        SPELLs(id).SpellEffects(2).ApplyAuraIndex = SpellDBC.Item(i, 96)
                        SPELLs(id).SpellEffects(2).Amplitude = SpellDBC.Item(i, 99)
                        SPELLs(id).SpellEffects(2).ChainTarget = SpellDBC.Item(i, 102)
                        SPELLs(id).SpellEffects(2).ItemType = SpellDBC.Item(i, 108)
                        SPELLs(id).SpellEffects(2).MiscValue = SpellDBC.Item(i, 111)
                        SPELLs(id).SpellEffects(2).TriggerSpell = SpellDBC.Item(i, 114)
                    Else
                        SPELLs(id).SpellEffects(2) = Nothing
                    End If

                    If ID > 133 Then Exit For

                Catch e As exception
                    Log.WriteLine(LogType.FAILED, "Line {0} caused error: {1}", i, e.toString)
                End Try


            Next i

            SpellDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Spells initialized.", i)
        End Sub

    End Module
End Namespace