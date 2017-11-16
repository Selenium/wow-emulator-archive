' Database initialization script.
'
'Last  update: 08.03.2007
'Version support: 2.0.8



Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.Filebase
Imports vbWoW.Logbase.BaseWriter
Imports vbWoW.WorldServer

Namespace Scripts
    Public Module Initializators

        Public Sub Initialize()
            InitializeXPTable()
            InitializeEmotesText()
            InitializeAreaTable()
            InitializeFactions()
            InitializeFactionTemplates()
            InitializeSkillLines()
            InitializeGraveyards()
            InitializeTaxiNodes()
            InitializeDurabilityCosts()
			InitializeBankBagSlotPrices()

            InitializeAreaTriggers()
            InitializeAI()
			InitializeCharacterCreation()
        End Sub

        Public Sub InitializeTaxiNodes()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\TaxiNodes.dbc")

            Dim taxiPosX As Single
            Dim taxiPosY As Single
            Dim taxiPosZ As Single
            Dim taxiMapID As Integer
            Dim taxiNode As Integer
            Dim taxiMountType_Horde As Integer
            Dim taxiMountType_Alliance As Integer

            Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                taxiNode = tmpDBC.Item(i, 0)
                taxiMapID = tmpDBC.Item(i, 1)
                taxiPosX = tmpDBC.Item(i, 2, DBC.DBCValueType.DBC_FLOAT)
                taxiPosY = tmpDBC.Item(i, 3, DBC.DBCValueType.DBC_FLOAT)
                taxiPosZ = tmpDBC.Item(i, 4, DBC.DBCValueType.DBC_FLOAT)
                taxiMountType_Horde = tmpDBC.Item(i, 14)
                taxiMountType_Alliance = tmpDBC.Item(i, 15)

                If HANDLED_MAP_ID = taxiMapID Then
                    TaxiNodes.Add(New TTaxiNode(taxiPosX, taxiPosY, taxiPosZ, taxiNode, taxiMapID))
                End If
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} TaxiNodes initialized.", i)
        End Sub

        Public Sub InitializeGraveyards()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\WorldSafeLocs.dbc")

            Dim locationPosX As Single
            Dim locationPosY As Single
            Dim locationPosZ As Single
            Dim locationMapID As Integer
            Dim locationIndex As Integer

            Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                locationIndex = tmpDBC.Item(i, 0)
                locationMapID = tmpDBC.Item(i, 1)
                locationPosX = tmpDBC.Item(i, 2, DBC.DBCValueType.DBC_FLOAT)
                locationPosY = tmpDBC.Item(i, 3, DBC.DBCValueType.DBC_FLOAT)
                locationPosZ = tmpDBC.Item(i, 4, DBC.DBCValueType.DBC_FLOAT)

                If HANDLED_MAP_ID = locationMapID Then
                    Graveyards.Add(New TGraveyard(locationPosX, locationPosY, locationPosZ, locationMapID))
                End If
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Graveyards initialized.", i)
        End Sub

        Public Sub InitializeSkillLines()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\SkillLine.dbc")

            Dim skillID As Integer
            Dim skillLine As Integer

            Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                skillID = tmpDBC.Item(i, 0)
                skillLine = tmpDBC.Item(i, 1)

                SkillLines(skillID) = skillLine
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} SkillLines initialized.", i)
        End Sub

        Public Sub InitializeXPTable()
            WS_CharManagment.XPTable(0) = 0
            WS_CharManagment.XPTable(1) = 400
            WS_CharManagment.XPTable(2) = 900
            WS_CharManagment.XPTable(3) = 1400
            WS_CharManagment.XPTable(4) = 2100
            WS_CharManagment.XPTable(5) = 2800
            WS_CharManagment.XPTable(6) = 3600
            WS_CharManagment.XPTable(7) = 4500
            WS_CharManagment.XPTable(8) = 5400
            WS_CharManagment.XPTable(9) = 6500
            WS_CharManagment.XPTable(10) = 7600
            WS_CharManagment.XPTable(11) = 8800
            WS_CharManagment.XPTable(12) = 10100
            WS_CharManagment.XPTable(13) = 11400
            WS_CharManagment.XPTable(14) = 12900
            WS_CharManagment.XPTable(15) = 14400
            WS_CharManagment.XPTable(16) = 16000
            WS_CharManagment.XPTable(17) = 17700
            WS_CharManagment.XPTable(18) = 19400
            WS_CharManagment.XPTable(19) = 21300
            WS_CharManagment.XPTable(20) = 23200
            WS_CharManagment.XPTable(21) = 25200
            WS_CharManagment.XPTable(22) = 27300
            WS_CharManagment.XPTable(23) = 29400
            WS_CharManagment.XPTable(24) = 31700
            WS_CharManagment.XPTable(25) = 34000
            WS_CharManagment.XPTable(26) = 36400
            WS_CharManagment.XPTable(27) = 38900
            WS_CharManagment.XPTable(28) = 41400
            WS_CharManagment.XPTable(29) = 44300
            WS_CharManagment.XPTable(30) = 47400
            WS_CharManagment.XPTable(31) = 50800
            WS_CharManagment.XPTable(32) = 54500
            WS_CharManagment.XPTable(33) = 58600
            WS_CharManagment.XPTable(34) = 62800
            WS_CharManagment.XPTable(35) = 67100
            WS_CharManagment.XPTable(36) = 71600
            WS_CharManagment.XPTable(37) = 76100
            WS_CharManagment.XPTable(38) = 80800
            WS_CharManagment.XPTable(39) = 85700
            WS_CharManagment.XPTable(40) = 90700
            WS_CharManagment.XPTable(41) = 95800
            WS_CharManagment.XPTable(42) = 101000
            WS_CharManagment.XPTable(43) = 106300
            WS_CharManagment.XPTable(44) = 111800
            WS_CharManagment.XPTable(45) = 117500
            WS_CharManagment.XPTable(46) = 123200
            WS_CharManagment.XPTable(47) = 129100
            WS_CharManagment.XPTable(48) = 135100
            WS_CharManagment.XPTable(49) = 141200
            WS_CharManagment.XPTable(50) = 147500
            WS_CharManagment.XPTable(51) = 153900
            WS_CharManagment.XPTable(52) = 160400
            WS_CharManagment.XPTable(53) = 167100
            WS_CharManagment.XPTable(54) = 173900
            WS_CharManagment.XPTable(55) = 180800
            WS_CharManagment.XPTable(56) = 187900
            WS_CharManagment.XPTable(57) = 195000
            WS_CharManagment.XPTable(58) = 202300
            WS_CharManagment.XPTable(59) = 209800
            WS_CharManagment.XPTable(60) = 484000
            WS_CharManagment.XPTable(61) = 574700
            WS_CharManagment.XPTable(62) = 614400
            WS_CharManagment.XPTable(63) = 650300
            WS_CharManagment.XPTable(64) = 682300
            WS_CharManagment.XPTable(65) = 710200
            WS_CharManagment.XPTable(66) = 734100
            WS_CharManagment.XPTable(67) = 753700
            WS_CharManagment.XPTable(68) = 768900
            WS_CharManagment.XPTable(69) = 779700
            WS_CharManagment.XPTable(70) = 800000
            Log.WriteLine(LogType.INFORMATION, "Scripting: XPTable initialized.")
        End Sub

        Public Sub InitializeAreaTable()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\AreaTable.dbc")

            Dim areaID As Integer
            Dim areaExploreFlag As Integer
            Dim areaLevel As Integer
            Dim areaZone As Integer
            Dim areaZoneType As Integer
            Dim areaTeam As Integer

            Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                areaID = tmpDBC.Item(i, 0)
                areaZone = tmpDBC.Item(i, 2)
                areaExploreFlag = tmpDBC.Item(i, 3)
                areaZoneType = tmpDBC.Item(i, 4)
                areaLevel = tmpDBC.Item(i, 10)
                areaTeam = tmpDBC.Item(i, 20)

                If areaLevel > 255 Then areaLevel = 255
                If areaLevel < 0 Then areaLevel = 0

                AreaTable(areaExploreFlag) = New TArea
                AreaTable(areaExploreFlag).ID = areaID
                AreaTable(areaExploreFlag).Level = areaLevel
                AreaTable(areaExploreFlag).Zone = areaZone
                AreaTable(areaExploreFlag).ZoneType = areaZoneType
                AreaTable(areaExploreFlag).Team = areaTeam
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Areas initialized.", i)
        End Sub

        Public Sub InitializeEmotesText()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\EmotesText.dbc")

            Dim textEmoteID As Integer
            Dim EmoteID As Integer

            Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                textEmoteID = tmpDBC.Item(i, 0)
                EmoteID = tmpDBC.Item(i, 2)

                If EmoteID <> 0 Then EmotesText(textEmoteID) = EmoteID
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} EmotesText initialized.", i)
        End Sub

        Public Sub InitializeAreaTriggers()
            AreaTriggers = New ScriptedObject("scripts\AreaTriggers.vb", "vbWoW.AreaTriggers.dll", False)
            Log.WriteLine(LogType.INFORMATION, "Scripting: AreaTriggers initialized.")
        End Sub

        Public Sub InitializeAI()
            AI = New ScriptedObject("scripts\AI.vb", "vbWoW.AI.dll", False)
            Log.WriteLine(LogType.INFORMATION, "Scripting: AI initialized.")
        End Sub

		Public Sub InitializeCharacterCreation()
            CharacterCreation = New ScriptedObject("scripts\CharacterCreation.vb", "vbWoW.CharacterCreation.dll", False)
            Log.WriteLine(LogType.INFORMATION, "Scripting: CharacterCreation initialized.")
        End Sub

        Public Sub InitializeFactions()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\Faction.dbc")

            Dim factionID As Integer
            Dim factionFlag As Integer
            Dim Flags(3) As Integer
            Dim ReputationStats(3) As Integer
            Dim ReputationFlags(3) As Integer
            Dim factionTeam As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                factionID = tmpDBC.Item(i, 0)
                factionFlag = tmpDBC.Item(i, 1)
                Flags(0) = tmpDBC.Item(i, 2)
                Flags(1) = tmpDBC.Item(i, 3)
                Flags(2) = tmpDBC.Item(i, 4)
                Flags(3) = tmpDBC.Item(i, 5)
                ReputationStats(0) = tmpDBC.Item(i, 10)
                ReputationStats(1) = tmpDBC.Item(i, 11)
                ReputationStats(2) = tmpDBC.Item(i, 12)
                ReputationStats(3) = tmpDBC.Item(i, 13)
                ReputationFlags(0) = tmpDBC.Item(i, 14)
                ReputationFlags(1) = tmpDBC.Item(i, 15)
                ReputationFlags(2) = tmpDBC.Item(i, 16)
                ReputationFlags(3) = tmpDBC.Item(i, 17)
                factionTeam = tmpDBC.Item(i, 18)

                FactionInfo(factionID) = New WS_DBCDatabase.TFaction(factionID, factionFlag, _
                   Flags(0), Flags(1), Flags(2), Flags(3), _
                   ReputationStats(0), ReputationStats(1), ReputationStats(2), ReputationStats(3), _
                   ReputationFlags(0), ReputationFlags(1), ReputationFlags(2), ReputationFlags(3))
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} Factions initialized.", i)
        End Sub


        Public Sub InitializeDurabilityCosts()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\DurabilityCosts.dbc")

            Dim itemBroken As Integer
            Dim itemType As Integer
            Dim itemPrice As Integer

            Dim i As Integer
            For i = 0 To tmpDBC.Rows - 1
                itemBroken = tmpDBC.Item(i, 0)

                For itemType = 1 To tmpDBC.Columns - 1
                    itemPrice = tmpDBC.Item(i, itemType)
                    DurabilityCosts(itemBroken, itemType - 1) = itemPrice
                Next itemType

            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} DurabilityCosts initialized.", i)
        End Sub

        Public Sub InitializeFactionTemplates()
            Dim i As Integer

            'Initializing defaults
            For i = 0 To FACTION_TEMPLATES_COUNT
                For j As Integer = 0 To FACTION_TEMPLATES_COUNT
                    ReactionTable(i, j) = TReaction.NEUTRAL
                Next j
            Next i

            For i = 0 To FACTION_TEMPLATES_COUNT
                ReactionTable(i, i) = TReaction.FRIENDLY
            Next i


            'Loading from DBC
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\FactionTemplate.dbc")

            Dim templateID As Integer
            Dim factionID As Integer
            Dim maskFightSupport As Integer
            Dim maskFrendly As Integer
            Dim maskHostile As Integer

            'From FactionGroup.dbc
            Const GROUP_PLAYER As Integer = 0
            Const GROUP_ALLIANCE As Integer = 1
            Const GROUP_HORDE As Integer = 2
            Const GROUP_MONSTER As Integer = 3

            For i = 0 To tmpDBC.Rows - 1
                templateID = tmpDBC.Item(i, 0)
                factionID = tmpDBC.Item(i, 1)
                maskFightSupport = tmpDBC.Item(i, 3)
                maskFrendly = tmpDBC.Item(i, 4)
                maskHostile = tmpDBC.Item(i, 5)

                FactionTemplatesInfo(templateID) = factionID
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} FactionsTemplates initialized.", i)
        End Sub
		
		Public Sub InitializeBankBagSlotPrices()
            Dim tmpDBC As DBC.BufferedDBC = New DBC.BufferedDBC("dbc\BankBagSlotPrices.dbc")

            Dim slot As Integer
            Dim price As Integer

			Dim i As Integer = 0
            For i = 0 To tmpDBC.Rows - 1
                slot = tmpDBC.Item(i, 0)
                price = tmpDBC.Item(i, 1)
          
                dbcBankBagSlotPrices(slot-1) = price
            Next i

            tmpDBC.Dispose()
            Log.WriteLine(LogType.INFORMATION, "Scripting: {0} BankBagSlotPrices initialized.", i)
        End Sub

    End Module
End namespace