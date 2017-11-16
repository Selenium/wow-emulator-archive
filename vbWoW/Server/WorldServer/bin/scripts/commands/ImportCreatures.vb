Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		Dim creatures_Count as Integer =0
		Dim nextSellGroup as Integer=0
		Dim currentSellGroup as Integer=0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Creatures.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
		End Sub

		Public Sub Start()
            Try
				Dim MySQLQuery As New DataTable
                MySQL.Query(String.Format("SELECT MAX(sell_group) FROM adb_sells;"), MySQLQuery)
                If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                    nextSellGroup = MySQLQuery.Rows(0).Item(0)+1
                End If

                Dim sr As StreamReader = New StreamReader("Creatures.scp")
                Dim line As String
                Dim tmpCreature As CreatureInfo
                Do
                    line = sr.ReadLine()
					if trim(line)<>"" then ParseCreature(tmpCreature, line)
                Loop Until line Is Nothing
				if Not tmpCreature is Nothing 
						SaveCreatures(tmpCreature)
						tmpCreature.Dispose
				end if
                sr.Close()
				Console.WriteLine("[{0}] Scripting: Parsed {1} creature(s).",Format(TimeOfDay, "hh:mm:ss"),creatures_Count)

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing creatures.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseCreature(ByRef Creature As CreatureInfo, ByVal Line As String)
			try
				If Line.Substring(0, 1) = "[" Then
					if Not Creature is Nothing 
						SaveCreatures(Creature)
						Creature.Dispose
					end if
					Creatures_Count=Creatures_Count+1
					currentSellGroup=0
					Creature = New CreatureInfo(Line.Substring(10).Replace("]", ""))
					Creature.Id = Line.Substring(10).Replace("]", "")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "name=" Then
					Creature.Name = Line.Substring(5).Replace("'","\'")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "sell=" Then
					Dim tmp() as string
					tmp = Split(Line.Substring(5),"/")
					Dim itemID as Integer = trim(tmp(0))

					if currentSellGroup=0 then 
						currentSellGroup=nextSellGroup
						nextSellGroup+=1
						Creature.SellTable=currentSellGroup
					end if
					MySQL.Update(String.Format("INSERT INTO adb_sells (sell_item, sell_count, sell_group) VALUES ({0}, {1} ,{2});",itemID,0,currentSellGroup))
					Exit Sub
				End If

				If Line.Substring(0, 5) = "type=" Then
					Creature.CreatureType =Line.Substring(5)
					Exit Sub
				End If				

				If Line.Substring(0, 5) = "size=" Then
					Creature.size = Line.Substring(5).Replace(".",",")
					Exit Sub
				End If
				
				If Line.Substring(0, 6) = "model="  Then
					Creature.Model = Line.Substring(6)
					Exit Sub
				End If

				If Line.Substring(0, 6) = "guild="  Then
					Creature.Guild =  Line.Substring(6).Replace("'","\'")
					Exit Sub
				End If

				If Line.Substring(0, 6) = "speed="  Then
					Creature.WalkSpeed = Line.Substring(6).Replace(".",",")
					Creature.WalkSpeed *= Constants.UNIT_NORMAL_WALK_SPEED
					Creature.RunSpeed = Line.Substring(6).Replace(".",",")
					Creature.RunSpeed *= Constants.UNIT_NORMAL_RUN_SPEED
					Exit Sub
				End If				

				If Line.Substring(0, 6) = "level="  Then
					Dim tmp as string
					tmp = Line.Substring(6)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					if tmp2.Length>1 then
						Creature.LevelMin=tmp2(0)
						Creature.LevelMax=tmp2(1)
					else
						Creature.LevelMin=tmp2(0)
						Creature.LevelMax=tmp2(0)
					end if
					Exit Sub
				End If

				If Line.Substring(0, 7) = "damage=" Then
					Dim tmp as string
					tmp = Line.Substring(7)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					Creature.Damage.Minimum=tmp2(0)
					Creature.Damage.Maximum=tmp2(1)
					Exit Sub
				End If

				If Line.Substring(0, 7) = "flags1="  Then
					Dim tmp as string = Line.Substring(7)
					if Left(tmp,1)="0" then
						Creature.cFlags = Int("&H" & tmp)
					else
						Creature.cFlags = Int(tmp)
					end if					
					Exit Sub
				End If

				If Line.Substring(0, 6) = "elite="  Then
					Creature.Elite = Line.Substring(6)
					Exit Sub
				End If				
				
				If Line.Substring(0, 7) = "family="  Then
					Creature.CreatureFamily = Line.Substring(7)
					Exit Sub
				End If

				If Line.Substring(0, 7) = "resist="  Then
					Dim tmp as string
					tmp = Line.Substring(7)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					tmp2(0)=Trim(tmp2(0))
					if tmp2(0)="#SPELL_SCHOOL_HOLY" then Creature.Resistances(1)=tmp2(1)
					if tmp2(0)="#SPELL_SCHOOL_FIRE" then Creature.Resistances(2)=tmp2(1)
					if tmp2(0)="#SPELL_SCHOOL_NATURE" then Creature.Resistances(3)=tmp2(1)
					if tmp2(0)="#SPELL_SCHOOL_FROST" then Creature.Resistances(4)=tmp2(1)
					if tmp2(0)="#SPELL_SCHOOL_SHADOW" then Creature.Resistances(5)=tmp2(1)
					if tmp2(0)="#SPELL_SCHOOL_ARCANE" then Creature.Resistances(6)=tmp2(1)
					Exit Sub
				End If				
				
				If Line.Substring(0, 8) = "faction="  Then
					Creature.Faction = Line.Substring(8)
					Exit Sub
				End If

				If Line.Substring(0, 8) = "maxmana="  Then
					Creature.Mana = Line.Substring(8)
					Creature.ManaType = 0
					Exit Sub
				End If

				If Line.Substring(0, 9) = "npcflags="  Then
					Dim tmp as string = Line.Substring(9)
					if Left(tmp,1)="0" then
						Creature.cNpcFlags = Int("&H" & tmp)
					else
						Creature.cNpcFlags = Int(tmp)
					end if					
					Exit Sub
				End If

				If Line.Substring(0, 9) = "aiscript="  Then
					Creature.AIScriptSource = Line.Substring(9)
					Exit Sub
				End If
				
				If Line.Substring(0, 10) = "maxhealth="  Then
					Creature.Life = Line.Substring(10)
					Exit Sub
				End If

				If Line.Substring(0, 13) = "combat_reach="  Then
					Creature.CombatReach = Line.Substring(13).Replace(".",",")
					Exit Sub
				End If

				If Line.Substring(0, 16) = "bounding_radius="  Then
					Creature.BoundingRadius = Line.Substring(16).Replace(".",",")
					Exit Sub
				End If

				'Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch err as System.ArgumentOutOfRangeException
				'Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString)
			end try
        End Sub
        Public Sub SaveCreatures(ByRef Creature As CreatureInfo)
			Creature.Save
        End Sub

	End Module
End Namespace




'aiscript
'attack				min, max
'equipmodel			slot (0-main hand, 1-off hand, 2-ranged), Model, Class, Sub Class, Inventory type,  25 0 0 0 0
'equip				slot, ItemID
'loottemplate
'money

'questscript
'npctext				-> this is talking info
'npctext0_0			text
'quest				!! may be 1/2/3... fields

'money
'sell
'train
'trainer_text
'trainer_type

				
				

				
