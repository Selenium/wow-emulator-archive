Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		Dim creatures_Count as Integer = 0
		Dim loots_Count as Integer = 0
		Dim creatureID as Integer = 0
		Dim lootID as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing creatures.scp and loottemplates.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
		End Sub

		Public Sub Start()
            Try
				Dim line As String

				Dim sr1 As StreamReader = New StreamReader("creatures.scp")
                Do
                    line = sr1.ReadLine()
					if trim(line)<>"" then ParseCreature(line)
                Loop Until line Is Nothing
                sr1.Close()
				Console.WriteLine("[{0}] Scripting: Parsed {1} creature(s) with loot.",Format(TimeOfDay, "hh:mm:ss"),creatures_Count)


                Dim sr2 As StreamReader = New StreamReader("loottemplates.scp")
                Do
                    line = sr2.ReadLine()
					if trim(line)<>"" then ParseLoot(line)
                Loop Until line Is Nothing
                sr2.Close()
				Console.WriteLine("[{0}] Scripting: Parsed {1} loot(s).",Format(TimeOfDay, "hh:mm:ss"),loots_Count)

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing loottemplates.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

		Public Sub ParseLoot(ByVal Line As String)
			try
				If Line.Substring(0, 1) = "[" Then
					lootID = Line.Substring(14).Replace("]", "")
					Exit Sub
				End If

				If Line.Substring(0, 5) = "loot=" Then
					Dim tmp() as string
					tmp = Split(Line,"=")
					tmp = Split(tmp(1)," ")
					
					Dim lootItem as Integer = CType(tmp(0),Integer)
					Dim lootChance as Single = CType(tmp(1).Replace(".",","),Single)

					MySQL.Update(String.Format("INSERT INTO adb_loots (loot_item, loot_chance, loot_group) VALUES ({0}, {1} ,{2});",lootItem,Str(lootChance),lootID))
					loots_Count+=1
					Exit Sub
				End If
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString)
			end try
		End Sub


        Public Sub ParseCreature(ByVal Line As String)
			try
				If line.IndexOf("[") = 0 Then
					creatureID = Line.Substring(10).Replace("]", "")
					Exit Sub
				End If

				If line.IndexOf("loottemplate=") = 0 Then
					Dim lootID as Integer = CType(Line.Substring(13),integer)
					MySQL.Update(String.Format("UPDATE adb_creatures SET creature_loot = {0} WHERE creature_id = {1};",lootID,creatureID))
					Creatures_Count+=1
					Exit Sub
				End If
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString)
			end try
        End Sub

	End Module
End Namespace

				
