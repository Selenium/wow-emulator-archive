'********************************************************************
'*			Use for coverting WoWEmu WorldSave File to vbWoW		*
'*																	*
'*				- World.save										*
'********************************************************************


Imports System
Imports System.Collections
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands

		Dim lineNum as Integer = 0
		Dim gameObjects as Integer = 0
		Dim goSpawnObjects as Integer = 0
		Dim creatureObjects as Integer = 0
		Dim creatureSpawnObjects as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing World.save.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} game objects.",Format(TimeOfDay, "hh:mm:ss"),gameObjects)
			Console.WriteLine("[{0}] Scripting: Parsed {1} creatures.",Format(TimeOfDay, "hh:mm:ss"),creatureObjects)
			Console.WriteLine("[{0}] Scripting: Parsed {1} game object spawns.",Format(TimeOfDay, "hh:mm:ss"),goSpawnObjects)
			Console.WriteLine("[{0}] Scripting: Parsed {1} creature spawns.",Format(TimeOfDay, "hh:mm:ss"),creatureSpawnObjects)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("World.save")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseWorldSave(line)
                Loop Until line Is Nothing
                sr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing World.save.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

		Public ObjectInfo as New ArrayList
        Public Sub ParseWorldSave(ByVal Line As String)
			try
				if line.IndexOf("[OBJECT]")>= 0 then
					ParseWorldObject
					ObjectInfo.Clear
				else
					ObjectInfo.Add(line)
				end if
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

		Public Sub ParseWorldObject()
				if ObjectInfo.Count=0 then Exit Sub

				Dim spawn_time as Integer=0

				Dim spawn_entry as Integer=0
				Dim spawn_count as Integer=0
				Dim spawn_range as Integer=0				
				Dim spawn_map as Integer=0
				Dim spawn_type as Integer=0
				Dim spawn_x as Single=0
				Dim spawn_y as Single=0
				Dim spawn_z as Single=0
				Dim spawn_or as Single=0
				Dim spawn_link as Integer=0

				Dim object_entry as Integer=0

				Dim go_rotation1 as Single=0
				Dim go_rotation2 as Single=0
				Dim go_rotation3 as Single=0
				Dim go_rotation4 as Single=0

				Dim tmp() as String
				for each Line as String in ObjectInfo
					'Console.Writeline(line)
					if line.IndexOf("SPAWN=")= 0 then				
						tmp = Split(line,"=")
						tmp = Split(tmp(1)," ")
						spawn_entry=tmp(0)
						spawn_count=tmp(1)
					end if
					if line.IndexOf("SPAWN_GOBJ=")= 0 then				
						tmp = Split(line,"=")
						spawn_entry=tmp(1)
					end if			

					if line.IndexOf("ENTRY=")= 0 then				
						tmp = Split(line,"=")
						object_entry=tmp(1)
					end if			

					if line.IndexOf("SPAWNDIST=")= 0 then				
						tmp = Split(line,"=")
						tmp = Split(tmp(1)," ")
						spawn_range=Fix(tmp(1).Replace(".",","))	'MaxRange
					end if

					if line.IndexOf("SPAWNTIME=")= 0 then				
						tmp = Split(line,"=")
						tmp = Split(tmp(1)," ")
						spawn_time=Fix(((Fix(tmp(1))+Fix(tmp(0))) \ 2 ) \ 60)
						if spawn_time=0 then spawn_time=1
					end if
					
					if line.IndexOf("XYZ=")= 0 then				
						tmp = Split(line,"=")
						tmp = Split(tmp(1)," ")
						spawn_x=tmp(0).Replace(".",",")
						spawn_y=tmp(1).Replace(".",",")
						spawn_z=tmp(2).Replace(".",",")
						spawn_or=tmp(3).Replace(".",",")
					end if

					if line.IndexOf("TYPE=")= 0 then				
						tmp = Split(line,"=")
						spawn_type=tmp(1)
					end if

					if line.IndexOf("MAP=")= 0 then				
						tmp = Split(line,"=")
						spawn_map=tmp(1)
					end if

					if line.IndexOf("ROTATION=")= 0 then				
						tmp = Split(line,"=")
						tmp = Split(tmp(1)," ")
						go_rotation1=tmp(0).Replace(".",",")
						go_rotation2=tmp(1).Replace(".",",")
						go_rotation3=tmp(2).Replace(".",",")
						go_rotation4=tmp(3).Replace(".",",")
					end if

					if line.IndexOf("LINK=")= 0 then				
						tmp = Split(line,"=")
						spawn_link="&H" & tmp(1)
					end if
				next

				
				'Do not save objects with spawns
				if spawn_link>0 then exit sub


				'DONE: Saving spawned gameobject
				if spawn_type=5 and spawn_time=0 and spawn_link=0 then
					gameObjects+=1
					Exit Sub

					'TODO: Save as spawned
					Dim MySQLQuery as String = "INSERT INTO tmpSpawnedGameObjects (gameObject_guid,gameObject_positionX,gameObject_positionY,gameObject_positionZ,gameObject_orientation,gameObject_map,gameObject_entry,gameObject_spawnId,gameObject_rotation1,gameObject_rotation2,gameObject_rotation3,gameObject_rotation4) VALUES ("
					Dim goGuid as Long = GameObjectsGUIDCounter - GUID_GAMEOBJECT
					GameObjectsGUIDCounter += 1

					MySQLQuery = MySQLQuery & goGuid
					MySQLQuery = MySQLQuery & "," & Str(spawn_x)
					MySQLQuery = MySQLQuery & "," & Str(spawn_y)
					MySQLQuery = MySQLQuery & "," & Str(spawn_z)
					MySQLQuery = MySQLQuery & "," & Str(spawn_or)
					MySQLQuery = MySQLQuery & "," & spawn_map
					MySQLQuery = MySQLQuery & "," & object_entry
					MySQLQuery = MySQLQuery & "," & 0
					MySQLQuery = MySQLQuery & "," & Str(go_rotation1)
					MySQLQuery = MySQLQuery & "," & Str(go_rotation2)
					MySQLQuery = MySQLQuery & "," & Str(go_rotation3)
					MySQLQuery = MySQLQuery & "," & Str(go_rotation4)
					MySQLQuery = MySQLQuery & ");"
					MySQL.Update(MySQLQuery)
				end if

				'TODO: Saving spawned creature
				if spawn_type=3 and spawn_time=0 and spawn_link=0 then
					'TODO: Save as spawned
					creatureObjects+=1
					Exit Sub
				end if







				if spawn_entry=0 then Exit Sub
				if spawn_time=0 then Exit Sub

				'DONE: Saving creature's spawn
				
				if spawn_type=3 and spawn_count>0 then
					creatureSpawnObjects+=1
					Exit Sub

					'TODO: Save equips
					Dim MySQLQuery as String = "INSERT INTO adb_spawns (spawn_entry,spawn_time,spawn_positionX,spawn_positionY,spawn_positionZ,spawn_orientation,spawn_spawned,spawn_waypoints,spawn_range,spawn_type,spawn_map,spawn_left)  VALUES ("
					MySQLQuery = MySQLQuery & spawn_entry
					MySQLQuery = MySQLQuery & "," & spawn_time
					MySQLQuery = MySQLQuery & "," & Str(spawn_x)
					MySQLQuery = MySQLQuery & "," & Str(spawn_y)
					MySQLQuery = MySQLQuery & "," & Str(spawn_z)
					MySQLQuery = MySQLQuery & "," & Str(spawn_or)
					MySQLQuery = MySQLQuery & "," & 0
					MySQLQuery = MySQLQuery & "," & 0
					MySQLQuery = MySQLQuery & "," & spawn_range
					MySQLQuery = MySQLQuery & "," & spawn_type
					MySQLQuery = MySQLQuery & "," & spawn_map
					MySQLQuery = MySQLQuery & "," & spawn_time
					MySQLQuery = MySQLQuery & ");"
					MySQL.Update(MySQLQuery)
				end if

				'DONE: Saving gameobject's spawn
				if spawn_type=3 and spawn_count=0 then
					goSpawnObjects+=1
					'Exit Sub

					spawn_type=5

					'TODO: Save as spawn
					Dim MySQLQuery as String = "INSERT INTO adb_spawns (spawn_entry,spawn_time,spawn_positionX,spawn_positionY,spawn_positionZ,spawn_orientation,spawn_spawned,spawn_waypoints,spawn_range,spawn_type,spawn_map,spawn_left)  VALUES ("
					MySQLQuery = MySQLQuery & spawn_entry
					MySQLQuery = MySQLQuery & "," & spawn_time
					MySQLQuery = MySQLQuery & "," & Str(spawn_x)
					MySQLQuery = MySQLQuery & "," & Str(spawn_y)
					MySQLQuery = MySQLQuery & "," & Str(spawn_z)
					MySQLQuery = MySQLQuery & "," & Str(spawn_or)
					MySQLQuery = MySQLQuery & "," & 0
					MySQLQuery = MySQLQuery & "," & 0
					MySQLQuery = MySQLQuery & "," & spawn_range
					MySQLQuery = MySQLQuery & "," & spawn_type
					MySQLQuery = MySQLQuery & "," & spawn_map
					MySQLQuery = MySQLQuery & "," & spawn_time
					MySQLQuery = MySQLQuery & ");"
					MySQL.Update(MySQLQuery)
				end if
		End Sub
	End Module
End Namespace
