'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- Spell.dbc											*
'********************************************************************
'* Sample line:														*
'* 1	3	0	0	0	0	0	0	0	0	0	0	0	0	0	0	7	0	0	7	0	0	0	101	0	0	0	0	0	0	10	0	0	0	1	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	-1	0	5	0	0	6	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1	0	0	9	0	0	0	0	0	0	0	0	0	0	0	1065353216	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	0	1	0	50	Word of Recall (OLD)	0	0	0	0	0	0	0	8323134		0	0	0	0	0	0	0	8323132	0	0	0	0	0	0	0	0	8323132	0	0	0	0	0	0	0	0	2031676	0	0	0	0	0	0	0	1	1	-1	1	1	1	0	0	0	0	
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim spells as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Spell.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} spells.",Format(TimeOfDay, "hh:mm:ss"),spells)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("spell.csv")
				Dim wr as StreamWriter = New StreamWriter("spell.vb")
				wr.WriteLine("' Auto generated from Spell.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					'While Right(line,1)<>","
					'	line = line & sr.ReadLine()
					'End While
					lineNum += 1
					if trim(line)<>"" then ParseSpell(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing Spell.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseSpell(ByVal Line As String, wr as StreamWriter)
			try
			
				Dim tmp() as String
				'tmp = Split(Replace(line,", "," ") ,",")
				tmp = Split(line,vbTab)



				wr.WriteLine("SPELLs({0}	) = New SpellInfo", tmp(0) )
				wr.WriteLine("SPELLs({0}	).school = {1}", tmp(0) , tmp(1))
				wr.WriteLine("SPELLs({0}	).category = {1}", tmp(0) , tmp(2))
				wr.WriteLine("SPELLs({0}	).dispellType = {1}", tmp(0) , tmp(4))
				'mechanic = 5
				wr.WriteLine("SPELLs({0}	).attributes = {1}", tmp(0) , tmp(6))
				wr.WriteLine("SPELLs({0}	).attributesEx = {1}", tmp(0) , tmp(7))
				wr.WriteLine("SPELLs({0}	).requredCasterStance = {1}", tmp(0) , tmp(9))
				wr.WriteLine("SPELLs({0}	).target = {1}", tmp(0) , tmp(11))
				wr.WriteLine("SPELLs({0}	).targetCreatureType = {1}", tmp(0) , tmp(12))
				wr.WriteLine("SPELLs({0}	).FocusObjectIndex = {1}", tmp(0) , tmp(13))
				wr.WriteLine("SPELLs({0}	).targetWounded = {1}", tmp(0) , Int(tmp(15))=2)
				wr.WriteLine("SPELLs({0}	).spellCastTimeIndex = {1}", tmp(0) , tmp(16))
				wr.WriteLine("SPELLs({0}	).categoryCooldown = {1}", tmp(0) , tmp(17))
				wr.WriteLine("SPELLs({0}	).spellCooldown = {1}", tmp(0) , tmp(18))
				wr.WriteLine("SPELLs({0}	).interruptFlags = {1}", tmp(0) , tmp(19))
				wr.WriteLine("SPELLs({0}	).auraInterruptFlags = {1}", tmp(0) , tmp(20))
				wr.WriteLine("SPELLs({0}	).channelInterruptFlags = {1}", tmp(0) , tmp(21))
				wr.WriteLine("SPELLs({0}	).procFlags = {1}", tmp(0) , tmp(22))
				wr.WriteLine("SPELLs({0}	).procChance = {1}", tmp(0) , tmp(23))
				wr.WriteLine("SPELLs({0}	).procCharges = {1}", tmp(0) , tmp(24))
				wr.WriteLine("SPELLs({0}	).maxLevel = {1}", tmp(0) , tmp(25))
				wr.WriteLine("SPELLs({0}	).baseLevel = {1}", tmp(0) , tmp(26))
				wr.WriteLine("SPELLs({0}	).spellLevel = {1}", tmp(0) , tmp(27))
				wr.WriteLine("SPELLs({0}	).DurationIndex = {1}", tmp(0) , tmp(28))
				wr.WriteLine("SPELLs({0}	).powerType = {1}", tmp(0) , tmp(29))
				wr.WriteLine("SPELLs({0}	).manaCost = {1}", tmp(0) , tmp(30))
				wr.WriteLine("SPELLs({0}	).manaCostPerlevel = {1}", tmp(0) , tmp(31))
				wr.WriteLine("SPELLs({0}	).manaPerSecond = {1}", tmp(0) , tmp(32))
				'wr.WriteLine("SPELLs({0}	).manaPerSecondPerLevel = {1}", tmp(0) , tmp(33))
				wr.WriteLine("SPELLs({0}	).rangeIndex = {1}", tmp(0) , tmp(34))
				wr.WriteLine("SPELLs({0}	).speed = {1}", tmp(0) , tmp(35).Replace(".",","))
				wr.WriteLine("SPELLs({0}	).modalNextSpell = {1}", tmp(0) , tmp(36))
				wr.WriteLine("SPELLs({0}	).totem = {{ {1} , {2} }}", tmp(0) , tmp(38), tmp(39))
				wr.WriteLine("SPELLs({0}	).reagents = {{ {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} }}", tmp(0) , tmp(40) , tmp(41) , tmp(42) , tmp(43) , tmp(44) , tmp(45) , tmp(46) , tmp(47))
				wr.WriteLine("SPELLs({0}	).reagentsCount = {{ {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8} }}", tmp(0) , tmp(48) , tmp(49) , tmp(50) , tmp(51) , tmp(52) , tmp(53) , tmp(54) , tmp(55))
				wr.WriteLine("SPELLs({0}	).equippedItemClass = {1}", tmp(0) , tmp(56))
				wr.WriteLine("SPELLs({0}	).equippedItemSubClass = {1}", tmp(0) , tmp(57))
				wr.WriteLine("SPELLs({0}	).spellVisual = {1}", tmp(0) , tmp(112))
				wr.WriteLine("SPELLs({0}	).name = ""{1}""", tmp(0) , tmp(117))


				If Int(tmp(58)) <> 0 Then
					wr.WriteLine("SPELLs({0}	).SpellEffects(0) = New SpellEffect	", tmp(0) )

					wr.WriteLine("SPELLs({0}	).SpellEffects(0).ID = {1}",					tmp(0), tmp(58) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).diceBase = {1}",				tmp(0), tmp(64) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).dicePerLevel = {1}",			tmp(0), tmp(67) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).valueBase = {1}",				tmp(0), tmp(73) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).valuePerLevel = {1}",			tmp(0), tmp(70).Replace(".",",") )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).valuePerComboPoint = {1}",	tmp(0), tmp(109) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).valueMax = {1}",				tmp(0), tmp(61) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).implicitTargetA = {1}",		tmp(0), tmp(79) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).implicitTargetB = {1}",		tmp(0), tmp(82) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).RadiusIndex = {1}",			tmp(0), tmp(85) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).ApplyAuraIndex = {1}",		tmp(0), tmp(88) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).Amplitude = {1}",				tmp(0), tmp(91) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).ChainTarget = {1}",			tmp(0), tmp(97) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).ItemType = {1}",				tmp(0), tmp(100) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).MiscValue = {1}",				tmp(0), tmp(103) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(0).TriggerSpell = {1}",			tmp(0), tmp(106) )
				Else
					wr.WriteLine("SPELLs({0}	).SpellEffects(0) = Nothing	", tmp(0) )
				End If



				If Int(tmp(59)) <> 0 Then
					wr.WriteLine("SPELLs({0}	).SpellEffects(1) = New SpellEffect	", tmp(0) )

					wr.WriteLine("SPELLs({0}	).SpellEffects(1).ID = {1}",					tmp(0), tmp(59) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).diceBase = {1}",				tmp(0), tmp(65) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).dicePerLevel = {1}",			tmp(0), tmp(68) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).valueBase = {1}",				tmp(0), tmp(74) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).valuePerLevel = {1}",			tmp(0), tmp(71).Replace(".",",") )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).valuePerComboPoint = {1}",	tmp(0), tmp(110) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).valueMax = {1}",				tmp(0), tmp(62) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).implicitTargetA = {1}",		tmp(0), tmp(80) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).implicitTargetB = {1}",		tmp(0), tmp(83) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).RadiusIndex = {1}",			tmp(0), tmp(86) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).ApplyAuraIndex = {1}",		tmp(0), tmp(89) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).Amplitude = {1}",				tmp(0), tmp(92) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).ChainTarget = {1}",			tmp(0), tmp(98) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).ItemType = {1}",				tmp(0), tmp(101) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).MiscValue = {1}",				tmp(0), tmp(104) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(1).TriggerSpell = {1}",			tmp(0), tmp(107) )
				Else
					wr.WriteLine("SPELLs({0}	).SpellEffects(1) = Nothing	", tmp(0) )
				End If



				If Int(tmp(60)) <> 0 Then
					wr.WriteLine("SPELLs({0}	).SpellEffects(2) = New SpellEffect	", tmp(0) )

					wr.WriteLine("SPELLs({0}	).SpellEffects(2).ID = {1}",					tmp(0), tmp(60) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).diceBase = {1}",				tmp(0), tmp(66) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).dicePerLevel = {1}",			tmp(0), tmp(69) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).valueBase = {1}",				tmp(0), tmp(75) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).valuePerLevel = {1}",			tmp(0), tmp(72).Replace(".",",") )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).valuePerComboPoint = {1}",	tmp(0), tmp(111) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).valueMax = {1}",				tmp(0), tmp(63) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).implicitTargetA = {1}",		tmp(0), tmp(81) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).implicitTargetB = {1}",		tmp(0), tmp(84) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).RadiusIndex = {1}",			tmp(0), tmp(87) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).ApplyAuraIndex = {1}",		tmp(0), tmp(90) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).Amplitude = {1}",				tmp(0), tmp(93) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).ChainTarget = {1}",			tmp(0), tmp(99) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).ItemType = {1}",				tmp(0), tmp(102) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).MiscValue = {1}",				tmp(0), tmp(105) )
					wr.WriteLine("SPELLs({0}	).SpellEffects(2).TriggerSpell = {1}",			tmp(0), tmp(108) )
				Else
					wr.WriteLine("SPELLs({0}	).SpellEffects(2) = Nothing	", tmp(0) )
				End If
				wr.WriteLine
				



			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
