Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		Dim damage_Count as Byte
		Dim spells_Count as Byte
		Dim items_Count as Integer =0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Items.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("Items.scp")
                Dim line As String
                Dim tmpItem As ItemInfo
                Do
                    line = sr.ReadLine()
					if trim(line)<>"" then ParseItem(tmpItem, line)
                Loop Until line Is Nothing
				if Not tmpItem is Nothing 
						SaveItem(tmpItem)
						tmpItem.Dispose
				end if
                sr.Close()
				Console.WriteLine("[{0}] Scripting: Parsed {1} item(s).",Format(TimeOfDay, "hh:mm:ss"),items_Count)

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing items.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseItem(ByRef Item As ItemInfo, ByVal Line As String)
			try
				If Line.Substring(0, 1) = "[" Then
					if Not Item is Nothing 
						SaveItem(Item)
						Item.Dispose
					end if
					damage_Count=0
					spells_Count=0
					items_Count=items_Count+1
					Item = New ItemInfo(Line.Substring(6).Replace("]", ""))
					Item.Id = Line.Substring(6).Replace("]", "")
					Exit Sub
				End If

				If Line.Substring(0, 3) = "set" Then
					Item.ItemSet = Line.Substring(4)
					Exit Sub
				End If
				If Line.Substring(0, 4) = "name" Then
					Item.Name = Replace(Line.Substring(5),"'","\'")
					Exit Sub
				End If
				If Line.Substring(0, 5) = "block" Then
					Item.Block = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "model" Then
					Item.Model = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "flags" Then
					Item.Flags = Line.Substring(6)
					Exit Sub
				End If			
				If Line.Substring(0, 5) = "races" Then
					Item.AvailableRaces = "&H" & Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "level" Then
					Item.Level = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "extra" Then
					Item.Extra = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "bonus" Then
					Dim tmp as string
					tmp = Line.Substring(6)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					Item.ItemBonusStatType(tmp2(0)-1)=tmp2(0)
					Item.ItemBonusStatValue(tmp2(0)-1)=tmp2(1)
					Exit Sub
				End If
				If Line.Substring(0, 5) = "delay" Then
					Item.Delay = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 6) = "class=" Then
					Item.ObjectClass = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 6) = "spell=" Then
					Dim tmp as string
					tmp = Line.Substring(6)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					Item.Spells(spells_Count).SpellID=tmp2(0)
					Item.Spells(spells_Count).SpellTrigger=tmp2(1)
					Item.Spells(spells_Count).SpellCharges=tmp2(2)
					Item.Spells(spells_Count).SpellCooldown=tmp2(3)
					Item.Spells(spells_Count).SpellCategory=tmp2(4)
					Item.Spells(spells_Count).SpellCategoryCooldown=tmp2(5)
					spells_Count=spells_Count+1
					Exit Sub
				End If
				If Line.Substring(0, 6) = "skill=" Then
					Item.ReqSkill = Line.Substring(6)
					Exit Sub
				End If
				If Line.Substring(0, 6) = "damage" Then
					Dim tmp as string
					tmp = Line.Substring(7)
					Dim tmp2() as string
					tmp2 = Split(tmp," ")
					Item.Damage(damage_Count).Minimum=tmp2(0)
					Item.Damage(damage_Count).Maximum=tmp2(1)
					Item.Damage(damage_Count).Type=tmp2(2)
					damage_Count=damage_Count+1
					Exit Sub
				End If
				If Line.Substring(0, 6) = "sheath" Then
					Item.Sheath = Line.Substring(7)
					Exit Sub
				End If
				If Line.Substring(0, 6) = "lockid" Then
					Item.LockID = Line.Substring(7)
					Exit Sub
				End If
				If Line.Substring(0, 7) = "bonding" Then
					Item.Bonding = Line.Substring(8)
					Exit Sub
				End If
				If Line.Substring(0, 7) = "quality" Then
					Item.Quality = Line.Substring(8)
					Exit Sub
				End If
				If Line.Substring(0, 7) = "classes" Then
					Item.AvailableClasses = "&H" + Line.Substring(8)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "language" Then
					Item.LanguageID = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "reqlevel" Then
					Item.ReqLevel = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "ammotype" Then
					Item.AmmoType = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "spellreq" Then
				    Item.ReqSpell = Line.Substring(9)
				    Exit Sub
				End If
				If Line.Substring(0, 8) = "pagetext" Then
					Item.PageText = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "buyprice" Then
					Item.BuyPrice = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "material" Then
					Item.Material = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "maxcount" Then
					Item.MaxCount = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 8) = "subclass" Then
					Item.SubClass = Line.Substring(9)
					Exit Sub
				End If
				If Line.Substring(0, 9) = "sellprice" Then
					Item.SellPrice = Line.Substring(10)
					Exit Sub
				End If
				If Line.Substring(0, 9) = "skillrank" Then
					Item.ReqSkillRank = Line.Substring(10)
					Exit Sub
				End If
				If Line.Substring(0, 9) = "stackable" Then
					Item.Stackable = Line.Substring(10)
					Exit Sub
				End If
				If Line.Substring(0, 10) = "durability" Then
					Item.Durability = Line.Substring(11)
					Exit Sub
				End If
				If Line.Substring(0, 10) = "startquest" Then
					Item.StartQuest = Line.Substring(11)
					Exit Sub
				End If
				If Line.Substring(0, 10) = "pvprankreq" Then
					Item.ReqHonorRank = Line.Substring(11)
					Exit Sub
				End If
				If Line.Substring(0, 11) = "description" Then
					Item.Description = Replace(Line.Substring(12),"'","\'")
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance1" Then
					Item.Resistances(0) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance2" Then
					Item.Resistances(1) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance3" Then
					Item.Resistances(2) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance4" Then
					Item.Resistances(3) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance5" Then
					Item.Resistances(4) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance6" Then
					Item.Resistances(5) = Line.Substring(12)
					Exit Sub
				End If
				If Line.Substring(0,11) = "resistance7" Then
					Item.Resistances(6) = Line.Substring(12)
					Exit Sub
				End If
				
				If Line.Substring(0, 12) = "pagematerial" Then
					Item.PageMaterial = Line.Substring(13)
					Exit Sub
				End If
				If Line.Substring(0, 13) = "inventorytype" Then
					Item.InventoryType = Line.Substring(14)
					Exit Sub
				End If
				If Line.Substring(0, 14) = "containerslots" Then
					Item.ContainerSlots = Line.Substring(15)
					Exit Sub
				End If


				'Not in Items.scp
				'If Line.Substring(0, 0) = "" Then
				'    Item.ReqFaction = Line.Substring(0)
				'    Exit Sub
				'End If
				'If Line.Substring(0, 0) = "" Then
				'    Item.ReqFactionLevel = Line.Substring(0)
				'    Exit Sub
				'End If
				'If Line.Substring(0, 7) = "questid" Then	?

				Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch err as System.ArgumentOutOfRangeException
				Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString)
			end try
        End Sub
        Public Sub SaveItem(ByRef Item As ItemInfo)
			Item.Save
        End Sub

	End Module
End Namespace
