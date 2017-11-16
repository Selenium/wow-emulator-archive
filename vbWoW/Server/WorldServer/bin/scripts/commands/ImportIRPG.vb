'********************************************************************
'*			Use for coverting WoWEmu IRPG Quest Database     		*
'*																	*
'*				- Quests.scp										*
'********************************************************************


Imports System
Imports System.Collections
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer


Namespace Scripts
	Public Module CustomCommands

		Dim lineNum as integer = 0
		Dim currentQuest as integer = -1

		Dim questsAll as integer = 0 
		Dim questsKill as integer = 0
		Dim questsItem as integer = 0
		Dim questsTalk as integer = 0
		Dim questsUnknown as integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Quests.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} quests.",Format(TimeOfDay, "hh:mm:ss"),questsAll)
			Console.WriteLine("[{0}] Scripting: Parsed {1} quests type <kill>.",Format(TimeOfDay, "hh:mm:ss"),questsKill)
			Console.WriteLine("[{0}] Scripting: Parsed {1} quests type <deliver>/<items>.",Format(TimeOfDay, "hh:mm:ss"),questsItem)
			Console.WriteLine("[{0}] Scripting: Parsed {1} quests type <talk>.",Format(TimeOfDay, "hh:mm:ss"),questsTalk)
			Console.WriteLine("[{0}] Scripting: Skipped {1} unsupported or unknown quests.",Format(TimeOfDay, "hh:mm:ss"),questsUnknown)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("Quests.scp")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseQuest(line)
                Loop Until line Is Nothing
                sr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing Quests.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub


		Public QuestInfo as New ArrayList
		Public Sub ParseQuest(ByVal Line As String)
			try
				if line.IndexOf("[quest")>= 0 then
					ParseQuestAllInfo(line)
					QuestInfo.Clear
				else
					QuestInfo.Add(line)
				end if
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub





		Public Sub ParseQuestAllInfo(questID as String)
			questsAll+=1

			Dim ID as integer = 0
			Dim NextQuest as integer = 0
			Dim Title as String = "No Quest Title"
			Dim Zone as Integer = 0
			Dim Type as integer = 0
			Dim Flags as integer = 0
			Dim Level_Start as byte = 0
			Dim Level_Normal as byte = 0

			Dim Required_Race as integer = 0
			Dim Required_Class as integer = 0
			Dim Required_TradeSkill as integer = 0
			Dim Required_Quest as integer = 0
			Dim Required_Reputation1 as integer = 0
			Dim Required_Reputation2 as integer = 0
			Dim Required_Reputation1_Faction as integer = 0
			Dim Required_Reputation2_Faction as integer = 0

			Dim NPC_Start as integer = 0
			Dim NPC_End as integer = 0
			Dim Text_Objectives as String = ""
			Dim Text_Description as String = ""
			Dim Text_Incomplete as String = ""
			Dim Text_PreComplete as String = ""
			Dim Text_Complete as String = ""


			Dim Reward_XP as integer = 0
			Dim Reward_Gold as integer = 0
			Dim Reward_Spell as integer = 0
			Dim Reward_Reputation1 as integer = 0
			Dim Reward_Reputation2 as integer = 0
			Dim Reward_Reputation1_Faction as integer = 0
			Dim Reward_Reputation2_Faction as integer = 0

			Dim Reward_Item() as integer = {0,0,0,0,0,0}
			Dim Reward_Item_Count() as integer = {0,0,0,0,0,0}
			Dim Reward_StaticItem() as integer = {0,0,0,0}
			Dim Reward_StaticItem_Count() as integer = {0,0,0,0}

			Dim Objective_Kill() as integer = {0,0,0,0}
			Dim Objective_Kill_Count() as Integer = {0,0,0,0}
			Dim Objective_Item() as integer = {0,0,0,0}
			Dim Objective_Item_Count() as Integer = {0,0,0,0}

			Dim Objective_Deliver1 as integer = 0
			Dim Objective_Deliver1_Count as Integer = 0

			Dim Objective_Gold as Integer = 0

			Dim Objective_Text() as String = {"","","",""}


			Dim tmp() as String
			tmp = Split(questID," ")
			ID = currentQuest
			currentQuest = Replace(tmp(1),"]","")

			dim reward_item_Index as Byte = 0
			dim reward_staticitem_Index as Byte = 0	
			dim kill_Index as byte = 0
			dim deliver_Index as byte = 0
			

			for each Line as String in QuestInfo
			try
						'Console.WriteLine(line)
						if line.IndexOf("name=")= 0 then	
							tmp = Split(line,"=")
							Title = Replace(tmp(1),"'","\'")
						end if
						if line.IndexOf("next_quest=")= 0 then	
							tmp = Split(line,"=")
							NextQuest = tmp(1)
						end if
						if line.IndexOf("zone=")= 0 then	
							tmp = Split(line,"=")
							Zone = tmp(1)
						end if
						'Type
						if line.IndexOf("quest_flags=")= 0 then	
							tmp = Split(line,"=")
							Flags = "&H" & tmp(1)
						end if
						if line.IndexOf("levels=")= 0 then	
							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							Level_Normal = tmp(1)
							Level_Start = tmp(0)
						end if
						if line.IndexOf("requirements=")= 0 then
							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							'r2|5|6|8 q235 q6382 q742
							for each rq as String in tmp
								if rq.IndexOf("r") = 0 then
									dim tmp2() as string = Split(Replace(rq,"r",""),"|")
									for each race as string in tmp2
										Required_Race += 1 << (Int(race) - 1)
									next
								else if rq.IndexOf("c") = 0 then
									dim tmp2() as string = Split(Replace(rq,"c",""),"|")
									for each clas as string in tmp2
										Required_Class += 1 << (Int(clas) - 1)
									next
								else if rq.IndexOf("q") = 0 then
									'Must be array!
									Required_Quest = Replace(rq,"q","")
								end if
							next			
							
						end if
						'Required_TradeSkill 
						'Required_Reputation1 
						'Required_Reputation2 
						'Required_Reputation1_Faction 
						'Required_Reputation2_Faction 
			 
						if line.IndexOf("started_by=npc")= 0 then	
							tmp = Split(line,"=npc")
							NPC_Start = tmp(1)
						end if
						if line.IndexOf("started_by=obj")= 0 then	
							tmp = Split(line,"=obj")
							NPC_Start = - Int(tmp(1))
						end if
						if line.IndexOf("finished_by=npc")= 0 then	
							tmp = Split(line,"=npc")
							NPC_End = tmp(1)
						end if
						if line.IndexOf("finished_by=obj")= 0 then	
							tmp = Split(line,"=obj")
							NPC_End = - Int(tmp(1))
						end if		

						if line.IndexOf("desc=")= 0 then	
							tmp = Split(line,"=",2)
							Text_Objectives = Replace(tmp(1),"'","\'")
						end if	
						if line.IndexOf("details=")= 0 then	
							tmp = Split(line,"=",2)
							Text_Description = Replace(tmp(1),"'","\'")
						end if	
						if line.IndexOf("incomplete=")= 0 then	
							tmp = Split(line,"=",2)
							Text_Incomplete = Replace(tmp(1),"'","\'")
						end if	
						if line.IndexOf("precompletion=")= 0 then	
							tmp = Split(line,"=",2)
							Text_PreComplete = Replace(tmp(1),"'","\'")
						end if
						if line.IndexOf("completion=")= 0 then	
							tmp = Split(line,"=",2)
							Text_Complete = Replace(tmp(1),"'","\'")
						end if		 


						if line.IndexOf("reward_xp=")= 0 then	
							tmp = Split(line,"=")
							Reward_XP = tmp(1)
						end if	
						if line.IndexOf("reward_gold=")= 0 then	
							tmp = Split(line,"=")
							Reward_Gold = tmp(1)
						end if	
						if line.IndexOf("spell_reward=")= 0 then	
							tmp = Split(line,"=")
							Reward_Spell = tmp(1)
						end if	
						if line.IndexOf("reward_spell=")= 0 then	
							tmp = Split(line,"=")
							Reward_Spell = tmp(1)
						end if	

						if line.IndexOf("reward_spell=")= 0 then	
							tmp = Split(line,"=")
							Reward_Spell = tmp(1)
						end if 
				 
						'Reward_Reputation1 
						'Reward_Reputation2
						'Reward_Reputation1_Faction 
						'Reward_Reputation2_Faction 

						if line.IndexOf("reward_item=")= 0 then	
							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							try
								Reward_StaticItem(reward_staticitem_Index) = tmp(0)
								if tmp.Length = 1 then 
									Reward_StaticItem_Count(reward_staticitem_Index) = 1
								else
									Reward_StaticItem_Count(reward_staticitem_Index) = tmp(1)
								end if							
							catch 
								Console.WriteLine("Unsupported item rewards count (count={0}) at quest id {1}",reward_staticitem_Index+1,ID)
							end try
							reward_staticitem_Index+=1
						end if 

						if line.IndexOf("reward_choice=")= 0 then	
							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							try
								Reward_Item(reward_item_Index) = tmp(0)
								if tmp.Length = 1 then 
									Reward_Item_Count(reward_item_Index) = 1
								else
									Reward_Item_Count(reward_item_Index) = tmp(1)
								end if
							catch 
								Console.WriteLine("Unsupported item choice count (count={0}) at quest id {1}",reward_item_Index+1,ID)
							end try
							reward_item_Index+=1
						end if 

						if line.IndexOf("kill=")= 0 then	
							if kill_Index=0 then questsKill+=1

							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							try
								Objective_Kill(kill_Index) = tmp(0)
								if tmp.Length = 1 then 
									Objective_Kill_Count(kill_Index) = 1
								else
									Objective_Kill_Count(kill_Index) = tmp(1)
								end if
							catch 
								Console.WriteLine("Unsupported kill objective count (count={0}) at quest id {1}",kill_index+1,ID)
							end try
							kill_Index+=1
						end if 

						if line.IndexOf("deliver=")= 0 then	
							if deliver_Index=0 then questsItem+=1

							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							try
							Objective_Item(deliver_Index) = tmp(0)
								if tmp.Length = 1 then 
									Objective_Item_Count(deliver_Index) = 1
								else
									Objective_Item_Count(deliver_Index) = tmp(1)
								end if		
							catch 
								Console.WriteLine("Unsupported item deliver count (count={0}) at quest id {1}",deliver_Index+1,ID)
							end try
							deliver_Index+=1
						end if 

						if line.IndexOf("src_item=")= 0 then	
							tmp = Split(line,"=")
							tmp = Split(tmp(1)," ")
							Objective_Deliver1 = tmp(0)
							if tmp.Length = 1 then 
								Objective_Deliver1_Count = 1
							else
								Objective_Deliver1_Count = tmp(1)
							end if
						end if 				
								 

						'Objective_Gold 

						'Objective_Text(0) 
						'Objective_Text(1)
						'Objective_Text(2)
						'Objective_Text(3)
						catch e as exception
							Console.WriteLine(e.tostring)
							Console.WriteLine(line)
						end try
			next
			




			Dim MySQLQuery as String = "INSERT INTO adb_quests (id, NextQuest, Title, Zone, Type, Flags, Level_Start, Level_Normal, Required_Race, Required_Class, Required_TradeSkill, Required_Quest, Required_Reputation1 , Required_Reputation2, Required_Reputation1_Faction, Required_Reputation2_Faction, NPC_Start, NPC_End, Text_Objectives, Text_Description, Text_Incomplete, Text_PreComplete, Text_Complete, Reward_XP, Reward_Gold, Reward_Spell, Reward_Reputation1, Reward_Reputation2, Reward_Reputation1_Faction, Reward_Reputation2_Faction, Reward_Item1, Reward_Item2, Reward_Item3, Reward_Item4, Reward_Item5, Reward_Item6, Reward_Item1_Count, Reward_Item2_Count, Reward_Item3_Count, Reward_Item4_Count, Reward_Item5_Count, Reward_Item6_Count, Reward_StaticItem1, Reward_StaticItem2, Reward_StaticItem3, Reward_StaticItem4, Reward_StaticItem1_Count, Reward_StaticItem2_Count, Reward_StaticItem3_Count, Reward_StaticItem4_Count , Objective_Kill1, Objective_Kill2, Objective_Kill3, Objective_Kill4, Objective_Kill1_Count, Objective_Kill2_Count, Objective_Kill3_Count, Objective_Kill4_Count, Objective_Item1, Objective_Item2, Objective_Item3, Objective_Item4, Objective_Item1_Count, Objective_Item2_Count, Objective_Item3_Count, Objective_Item4_Count, Objective_Deliver1, Objective_Deliver1_Count, Objective_Gold, Objective_Text1, Objective_Text2, Objective_Text3, Objective_Text4) VALUES (" & ID

			MySQLQuery = MySQLQuery & ", " & NextQuest
			MySQLQuery = MySQLQuery & ", '" &  Title & "'"
			MySQLQuery = MySQLQuery & ", " &  Zone 
			MySQLQuery = MySQLQuery & ", " &  Type 
			MySQLQuery = MySQLQuery & ", " &  Flags
			MySQLQuery = MySQLQuery & ", " &  Level_Start 
			MySQLQuery = MySQLQuery & ", " &  Level_Normal

			MySQLQuery = MySQLQuery & ", " &  Required_Race 
			MySQLQuery = MySQLQuery & ", " &  Required_Class 
			MySQLQuery = MySQLQuery & ", " &  Required_TradeSkill 
			MySQLQuery = MySQLQuery & ", " &  Required_Quest 
			MySQLQuery = MySQLQuery & ", " &  Required_Reputation1 
			MySQLQuery = MySQLQuery & ", " &  Required_Reputation2 
			MySQLQuery = MySQLQuery & ", " &  Required_Reputation1_Faction 
			MySQLQuery = MySQLQuery & ", " &  Required_Reputation2_Faction 

			MySQLQuery = MySQLQuery & ", " &  NPC_Start 
			MySQLQuery = MySQLQuery & ", " &  NPC_End 
			MySQLQuery = MySQLQuery & ", '" &  Text_Objectives & "'"
			MySQLQuery = MySQLQuery & ", '" &  Text_Description & "'"
			MySQLQuery = MySQLQuery & ", '" &  Text_Incomplete & "'"
			MySQLQuery = MySQLQuery & ", '" &  Text_PreComplete & "'"
			MySQLQuery = MySQLQuery & ", '" &  Text_Complete & "'"


			MySQLQuery = MySQLQuery & ", " &  Reward_XP 
			MySQLQuery = MySQLQuery & ", " &  Reward_Gold 
			MySQLQuery = MySQLQuery & ", " &  Reward_Spell 
			MySQLQuery = MySQLQuery & ", " &  Reward_Reputation1 
			MySQLQuery = MySQLQuery & ", " &  Reward_Reputation2
			MySQLQuery = MySQLQuery & ", " &  Reward_Reputation1_Faction 
			MySQLQuery = MySQLQuery & ", " &  Reward_Reputation2_Faction 

			MySQLQuery = MySQLQuery & ", " &  Reward_Item(0)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item(1)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item(2)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item(3)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item(4)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item(5)

			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(0)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(1)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(2)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(3)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(4)
			MySQLQuery = MySQLQuery & ", " &  Reward_Item_Count(5)

			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem(0)
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem(1)
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem(2)
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem(3)
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem_Count(0) 
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem_Count(1) 
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem_Count(2) 
			MySQLQuery = MySQLQuery & ", " &  Reward_StaticItem_Count(3) 

			MySQLQuery = MySQLQuery & ", " &  Objective_Kill(0) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill(1) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill(2) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill(3) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill_Count(0)
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill_Count(1) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill_Count(2) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Kill_Count(3) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Item(0) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Item(1) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Item(2) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Item(3) 
			MySQLQuery = MySQLQuery & ", " &  Objective_Item_Count(0)
			MySQLQuery = MySQLQuery & ", " &  Objective_Item_Count(1)
			MySQLQuery = MySQLQuery & ", " &  Objective_Item_Count(2)
			MySQLQuery = MySQLQuery & ", " &  Objective_Item_Count(3)

			MySQLQuery = MySQLQuery & ", " &  Objective_Deliver1
			MySQLQuery = MySQLQuery & ", " &  Objective_Deliver1_Count 

			MySQLQuery = MySQLQuery & ", " &  Objective_Gold 

			MySQLQuery = MySQLQuery & ", """ &  Objective_Text(0) & """"
			MySQLQuery = MySQLQuery & ", """ &  Objective_Text(1) & """"
			MySQLQuery = MySQLQuery & ", """ &  Objective_Text(2) & """"
			MySQLQuery = MySQLQuery & ", """ &  Objective_Text(3) & """"

			MySQL.Update(MySQLQuery & ");")
		End Sub


	End Module
End Namespace
