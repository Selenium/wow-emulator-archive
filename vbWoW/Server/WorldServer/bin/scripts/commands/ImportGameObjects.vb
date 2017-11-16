Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		Dim go_Count as Integer = 0
		Dim loot_Count as Integer = 0
		Dim loot_group as Integer = 0
		Dim currentLootGroup as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing gameobjects.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
		End Sub

		Public Sub Start()
            Try
			    Dim MySQLQuery As New DataTable
                MySQL.Query(String.Format("SELECT MAX(loot_group) FROM adb_loots;"), MySQLQuery)
                If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                    loot_group = MySQLQuery.Rows(0).Item(0)
                End If

                Dim sr As StreamReader = New StreamReader("gameobjects.scp")
                Dim line As String
                Dim tmpGameObject As GameObjectInfo
                Do
                    line = sr.ReadLine()
					if trim(line)<>"" then ParseGameObject(tmpGameObject, line)
                Loop Until line Is Nothing
				if Not tmpGameObject is Nothing 
						SaveGameObject(tmpGameObject)
						tmpGameObject.Dispose
				end if
                sr.Close()
				Console.WriteLine("[{0}] Scripting: Parsed {1} GameObject(s) and {2} loot entry(s).",Format(TimeOfDay, "hh:mm:ss"),go_Count,loot_Count)

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing gameobjects.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseGameObject(ByRef GameObject As GameObjectInfo, ByVal Line As String)
			try
				If Line.Substring(0, 1) = "[" Then
					if Not GameObject is Nothing 
						SaveGameObject(GameObject)
						GameObject.Dispose
						currentLootGroup=0
					end if
					go_Count=go_Count+1
					GameObject = New GameObjectInfo(Line.Substring(9).Replace("]", ""))
					GameObject.Id = Line.Substring(9).Replace("]", "")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "loot=" Then
					Dim tmp() as String = Split(Line.Substring(5)," ")
					Dim lootEntry as Integer = tmp(0)
					Dim lootChance as Single = tmp(1).Replace(".",",")
					loot_Count+=1

					if currentLootGroup=0 then 
						currentLootGroup=loot_group
						loot_group+=1
						GameObject.Loot=currentLootGroup
					end if
					MySQL.Update(String.Format("INSERT INTO adb_loots (loot_item, loot_chance, loot_group) VALUES ({0}, {1} ,{2});",lootEntry,Str(lootChance),currentLootGroup))
					Exit Sub
				End If

				If Line.Substring(0, 5) = "name=" Then
					GameObject.Name = Line.Substring(5).Replace("'","\'")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "type=" Then
					GameObject.Type =Line.Substring(5)
					Exit Sub
				End If		

				If Line.Substring(0, 5) = "size=" Then
					GameObject.Size = Line.Substring(5).Replace(".",",")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "sound" Then
					GameObject.Sounds(Int(Mid(Line,6,1))) = Line.Substring(7).Replace(".",",")
					Exit Sub
				End If

				If Line.Substring(0, 6) = "model="  Then
					GameObject.Model = Line.Substring(6)
					Exit Sub
				End If

				If Line.Substring(0, 6) = "flags="  Then
					Dim tmp as string = Line.Substring(6)
					if Left(tmp,1)="0" then
						GameObject.Flags = Int("&H" & tmp)
					else
						GameObject.Flags = Int(tmp)
					end if					
					Exit Sub
				End If

				If Line.Substring(0, 8) = "faction="  Then
					GameObject.Faction = Line.Substring(8)
					Exit Sub
				End If			
				

				Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch err as System.ArgumentOutOfRangeException
				'Console.WriteLine("[{0}] Scripting: Unknown line {1}.",Format(TimeOfDay, "hh:mm:ss"),line)
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString)
			end try
        End Sub
        Public Sub SaveGameObject(ByRef GameObject As GameObjectInfo)
			GameObject.Save
        End Sub

	End Module
End Namespace




'questscript
				
				

				
