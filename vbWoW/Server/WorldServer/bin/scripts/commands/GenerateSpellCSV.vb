'********************************************************************
'*			Generate CSV from Spell.dbc                             *
'********************************************************************

Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports vbWoW.Filebase

Namespace Scripts
	Public Module CustomCommands

		Public FieldNames() as String = New String() { _
			"0:SpellID", _
			"1:school", _
			"2:category", _
			"3:Unk", _
			"4:dispellType", _
			"5:mechanic", _
			"6:attributes", _
			"7:attributesEx", _
			"8:AttributesEx2", _
			"9:AttributesEx3", _
			"10:", _
			"11:Stances", _
			"12:Targets", _
			"13:", _
			"14:TargetCreatureType", _
			"15:RequiresSpellFocus", _
			"16:CasterAuraState", _
			"17:", _
			"18:", _
			"19:", _
			"20:", _
			"21:CastingTimeIndex", _
			"22:RecoveryTime", _
			"23:CategoryRecoveryTime", _
			"24:InterruptFlags", _
			"25:AuraInterruptFlags", _
			"26:ChannelInterruptFlags", _
			"27:procFlags", _
			"28:procChance", _
			"29:procCharges", _
			"30:maxLevel", _
			"31:baseLevel", _
			"32:spellLevel", _
			"33:DurationIndex", _
			"34:powerType", _
			"35:manaCost", _
			"36:manaCostPerlevel", _
			"37:manaPerSecond", _
			"38:manaPerSecondPerLevel", _
			"39:rangeIndex", _
			"40:speed", _
			"41:modalNextSpell", _
			"42:StackAmount", _
			"43:Totem[0]", _
			"44:Totem[1]", _
			"45:Reagent[0]", _
			"46:Reagent[1]", _
			"47:Reagent[2]", _
			"48:Reagent[3]", _
			"49:Reagent[4]", _
			"50:Reagent[5]", _
			"51:Reagent[6]", _
			"52:Reagent[7]", _
			"53:ReagentCount[0]", _
			"54:ReagentCount[1]", _
			"55:ReagentCount[2]", _
			"56:ReagentCount[3]", _
			"57:ReagentCount[4]", _
			"58:ReagentCount[5]", _
			"59:ReagentCount[6]", _
			"60:ReagentCount[7]", _
			"61:EquippedItemClass", _
			"62:EquippedItemSubClass", _
			"63:", _
			"64:Effect[0]", _
			"65:Effect[1]", _
			"66:Effect[2]", _
			"67:EffectDieSides[0]", _
			"68:EffectDieSides[1]", _
			"69:EffectDieSides[2]", _
			"70:EffectBaseDice[0]", _
			"71:EffectBaseDice[1]", _
			"72:EffectBaseDice[2]", _
			"73:EffectDicePerLevel[0]", _
			"74:EffectDicePerLevel[1]", _
			"75:EffectDicePerLevel[2]", _
			"76:EffectRealPointsPerLevel[0]", _
			"77:EffectRealPointsPerLevel[1]", _
			"78:EffectRealPointsPerLevel[2]", _
			"79:EffectBasePoints[0]", _
			"80:EffectBasePoints[1]", _
			"81:EffectBasePoints[2]", _
			"82:", _
			"83:", _
			"84:", _
			"85:EffectImplicitTargetA[0]", _
			"86:EffectImplicitTargetA[1]", _
			"87:EffectImplicitTargetA[2]", _
			"88:EffectImplicitTargetB[0]", _
			"89:EffectImplicitTargetB[1]", _
			"90:EffectImplicitTargetB[2]", _
			"91:EffectRadiusIndex[0]", _
			"92:EffectRadiusIndex[1]", _
			"93:EffectRadiusIndex[2]", _
			"94:EffectApplyAuraName[0]", _
			"95:EffectApplyAuraName[1]", _
			"96:EffectApplyAuraName[2]", _
			"97:EffectAmplitude[0]", _
			"98:EffectAmplitude[1]", _
			"99:EffectAmplitude[2]", _
			"100:EffectMultipleValue[0]", _
			"101:EffectMultipleValue[1]", _
			"102:EffectMultipleValue[2]", _
			"103:EffectChainTarget[0]", _
			"104:EffectChainTarget[1]", _
			"105:EffectChainTarget[2]", _
			"106:EffectItemType[0]", _
			"107:EffectItemType[1]", _
			"108:EffectItemType[2]", _
			"109:EffectMiscValue[0]", _
			"110:EffectMiscValue[1]", _
			"111:EffectMiscValue[2]", _
			"112:EffectTriggerSpell[0]", _
			"113:EffectTriggerSpell[1]", _
			"114:EffectTriggerSpell[2]", _
			"115:EffectPointsPerComboPoint[0]", _
			"116:EffectPointsPerComboPoint[1]", _
			"117:EffectPointsPerComboPoint[2]", _
			"118:SpellVisual", _
			"119:", _
			"120:SpellIconID", _
			"121:activeIconID", _
			"122:spellPriority", _
			"123:SpellName", _
			"124:SpellName1", _
			"125:SpellName2", _
			"126:SpellName3", _
			"127:SpellName4", _
			"128:SpellName5", _
			"129:SpellName6", _
			"130:SpellName7", _
			"131:SpellNameFlag", _
			"132:Rank", _
			"133:Rank1", _
			"134:Rank2", _
			"135:Rank3", _
			"136:Rank4", _
			"137:Rank5", _
			"138:Rank6", _
			"139:Rank7", _
			"140:RankFlags", _
			"141:Description", _
			"142:Description1", _
			"143:Description2", _
			"144:Description3", _
			"145:Description4", _
			"146:Description5", _
			"147:Description6", _
			"148:Description7", _
			"149:DescriptionFlags", _
			"150:Aura", _
			"151:Aura1", _
			"152:Aura2", _
			"153:Aura3", _
			"154:Aura4", _
			"155:Aura5", _
			"156:Aura6", _
			"157:Aura7", _
			"158:AuraFlags", _
			"159:ManaCostPercentage", _
			"160:StartRecoveryCategory", _
			"161:StartRecoveryTime", _
			"162:", _
			"163:SpellFamilyName", _
			"164:SpellFamilyFlags", _
			"165:MaxAffectedTargets", _
			"166:", _
			"167:", _
			"168:", _
			"169:", _
			"170:", _
			"171:", _
			"172:", _
			"173:", _
			"174:", _
			"175:", _
			"176:", _
			"177:", _
			"178:", _
			"179:", _
			"180:", _
			"181:", _
			"182:", _
			"183:", _
			"184:", _
			"185:", _
			"186:", _
			"187:", _
			"188:", _
			"189:", _
			"190:", _
			"191:", _
			"192:", _
			"193:", _
			"194:", _
			"195:", _
			"196:", _
			"197:", _
			"198:", _
			"199:", _
			"200:", _
			"201:", _
			"202:", _
			"203:Unk" }

		Public Sub OnExecute()
			Dim SpellDBC As DBC.BaseDBC = New DBC.BaseDBC("dbc\Spell.dbc")
			Dim file As TextWriter
			file = New StreamWriter(New FileStream("Spells.csv", FileMode.Create))

            Dim i As Integer
			Dim j as Integer
			For j = 0 To SpellDBC.Columns - 1
				file.Write("{0} |",FieldNames(j))
			Next j


			
			try
				file.WriteLine
				For i = 0 To SpellDBC.Rows - 1
					For j = 0 To SpellDBC.Columns - 1
						Select Case J
							Case 40,73,74,75,76,77,78,100,101,102,115,116,117
								file.Write("{0} |",SpellDBC.Item(i, j,DBC.DBCValueType.DBC_FLOAT))
							Case 123,124,125,126,127,128,129,130,132,133,134,135,136,137,138,139,141,142,143,144,145,146,147,148,150,151,152,153,154,155,156,157
								file.Write("{0} |",Replace(Replace(Replace(Replace(SpellDBC.Item(i, j,DBC.DBCValueType.DBC_STRING), vbTab," "),vbCr," "),vbLf," "),";",","))
							Case 6,7,8,9,11,12,24,25,26,27,131,140,149,158
								file.Write("0x{0:X} |",SpellDBC.Item(i, j))
							Case Else
								file.Write("{0} |",SpellDBC.Item(i, j))
						End Select
					Next j
					file.WriteLine()
				Next i
			catch e as Exception
				Console.WriteLine("[{0},{1}] {2}",i,j, e.ToString)
				file.Close()
			End try
		End Sub

	End Module
End Namespace
