'********************************************************************
'*			Generate CSV from Spell.dbc                             *
'********************************************************************

Imports System
Imports System.IO
Imports Microsoft.VisualBasic
Imports vbWoW.Filebase
Imports vbWoW.WorldServer

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
			"18:CastingTimeIndex", _
			"19:RecoveryTime", _
			"20:CategoryRecoveryTime", _
			"21:InterruptFlags", _
			"22:AuraInterruptFlags", _
			"23:ChannelInterruptFlags", _
			"24:procFlags", _
			"25:procChance", _
			"26:procCharges", _
			"27:maxLevel", _
			"28:baseLevel", _
			"29:spellLevel", _
			"30:DurationIndex", _
			"31:powerType", _
			"32:manaCost", _
			"33:manaCostPerlevel", _
			"34:manaPerSecond", _
			"35:manaPerSecondPerLevel", _
			"36:rangeIndex", _
			"37:speed", _
			"38:modalNextSpell", _
			"39:StackAmount", _
			"40:Totem[0]", _
			"41:Totem[1]", _
			"42:Reagent[0]", _
			"43:Reagent[1]", _
			"44:Reagent[2]", _
			"45:Reagent[3]", _
			"46:Reagent[4]", _
			"47:Reagent[5]", _
			"48:Reagent[6]", _
			"49:Reagent[7]", _
			"50:ReagentCount[0]", _
			"51:ReagentCount[1]", _
			"52:ReagentCount[2]", _
			"53:ReagentCount[3]", _
			"54:ReagentCount[4]", _
			"55:ReagentCount[5]", _
			"56:ReagentCount[6]", _
			"57:ReagentCount[7]", _
			"58:EquippedItemClass", _
			"59:EquippedItemSubClass", _
			"60:", _
			"61:Effect[0]", _
			"62:Effect[1]", _
			"63:Effect[2]", _
			"64:EffectDieSides[0]", _
			"65:EffectDieSides[1]", _
			"66:EffectDieSides[2]", _
			"67:EffectBaseDice[0]", _
			"68:EffectBaseDice[1]", _
			"69:EffectBaseDice[2]", _
			"70:EffectDicePerLevel[0]", _
			"71:EffectDicePerLevel[1]", _
			"72:EffectDicePerLevel[2]", _
			"73:EffectRealPointsPerLevel[0]", _
			"74:EffectRealPointsPerLevel[1]", _
			"75:EffectRealPointsPerLevel[2]", _
			"76:EffectBasePoints[0]", _
			"77:EffectBasePoints[1]", _
			"78:EffectBasePoints[2]", _
			"79:", _
			"80:", _
			"81:", _
			"82:EffectImplicitTargetA[0]", _
			"83:EffectImplicitTargetA[1]", _
			"84:EffectImplicitTargetA[2]", _
			"85:EffectImplicitTargetB[0]", _
			"86:EffectImplicitTargetB[1]", _
			"87:EffectImplicitTargetB[2]", _
			"88:EffectRadiusIndex[0]", _
			"89:EffectRadiusIndex[1]", _
			"90:EffectRadiusIndex[2]", _
			"91:EffectApplyAuraName[0]", _
			"92:EffectApplyAuraName[1]", _
			"93:EffectApplyAuraName[2]", _
			"94:EffectAmplitude[0]", _
			"95:EffectAmplitude[1]", _
			"96:EffectAmplitude[2]", _
			"97:EffectMultipleValue[0]", _
			"98:EffectMultipleValue[1]", _
			"99:EffectMultipleValue[2]", _
			"100:EffectChainTarget[0]", _
			"101:EffectChainTarget[1]", _
			"102:EffectChainTarget[2]", _
			"103:EffectItemType[0]", _
			"104:EffectItemType[1]", _
			"105:EffectItemType[2]", _
			"106:EffectMiscValue[0]", _
			"107:EffectMiscValue[1]", _
			"108:EffectMiscValue[2]", _
			"109:EffectTriggerSpell[0]", _
			"100:EffectTriggerSpell[1]", _
			"111:EffectTriggerSpell[2]", _
			"112:EffectPointsPerComboPoint[0]", _
			"113:EffectPointsPerComboPoint[1]", _
			"114:EffectPointsPerComboPoint[2]", _
			"115:SpellVisual", _
			"116:", _
			"117:SpellIconID", _
			"118:activeIconID", _
			"119:spellPriority", _
			"120:SpellName", _
			"121:SpellName1", _
			"122:SpellName2", _
			"123:SpellName3", _
			"124:SpellName4", _
			"125:SpellName5", _
			"126:SpellName6", _
			"127:SpellName7", _
			"128:SpellNameFlag", _
			"129:Rank", _
			"130:Rank1", _
			"131:Rank2", _
			"132:Rank3", _
			"133:Rank4", _
			"134:Rank5", _
			"135:Rank6", _
			"136:Rank7", _
			"137:RankFlags", _
			"138:Description", _
			"139:Description1", _
			"140:Description2", _
			"141:Description3", _
			"142:Description4", _
			"143:Description5", _
			"144:Description6", _
			"145:Description7", _
			"146:DescriptionFlags", _
			"147:Aura", _
			"148:Aura1", _
			"149:Aura2", _
			"140:Aura3", _
			"151:Aura4", _
			"152:Aura5", _
			"153:Aura6", _
			"154:Aura7", _
			"155:AuraFlags", _
			"156:ManaCostPercentage", _
			"157:StartRecoveryCategory", _
			"158:StartRecoveryTime", _
			"159:", _
			"160:SpellFamilyName", _
			"161:SpellFamilyFlags", _
			"162:MaxAffectedTargets", _
			"163:", _
			"164:", _
			"165:", _
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
			"200:Unk" }

		Public Sub OnExecute()
			Dim SpellDBC As DBC.BaseDBC = New DBC.BaseDBC("dbc\Spell.dbc")
			Dim file As TextWriter
			file = New StreamWriter(New FileStream("Spells.csv", FileMode.Create))

            Dim i As Integer
			Dim j as Integer
			For j = 0 To SpellDBC.Columns - 1
				file.Write("{0} |",FieldNames(j))
			Next j


			

			file.WriteLine
			For i = 0 To SpellDBC.Rows - 1
				For j = 0 To SpellDBC.Columns - 1
					Select Case J
						Case 37,70,71,72,73,74,75,97,98,99,112,113,114
							file.Write("{0} |",SpellDBC.Item(i, j,DBC.DBCValueType.DBC_FLOAT))
						Case 120,121,122,123,124,125,126,127,129,130,131,132,133,134,135,136,138,139,140,141,142,143,144,145,147,148,149,150,151,152,153,154
							file.Write("{0} |",Replace(Replace(Replace(Replace(SpellDBC.Item(i, j,DBC.DBCValueType.DBC_STRING), vbTab," "),vbCr," "),vbLf," "),";",","))
						Case 6,7,8,9,11,12,21,22,23,24,128,137,146,155
							file.Write("0x{0:X} |",SpellDBC.Item(i, j))
						Case Else
							file.Write("{0} |",SpellDBC.Item(i, j))
					End Select
				Next j
				file.WriteLine()
			Next i
		End Sub

	End Module
End Namespace
