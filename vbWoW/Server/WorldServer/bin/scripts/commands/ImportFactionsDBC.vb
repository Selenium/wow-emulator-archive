'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- Factions.dbc										*
'********************************************************************
'* Sample line:														*
'* 532,-1,0,0,0,0,"0000000000000000","0000000000000000",0,0,0,0,0,0,0,0,0,0,"< 0 >","Dragonflight, Blue",0,0,0,0,0,0,0,2031678,0,0,0,0,0,0,0,0,2031660
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim Factions as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Faction.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} factions.",Format(TimeOfDay, "hh:mm:ss"),Factions)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("Faction.csv")
				Dim wr as StreamWriter = New StreamWriter("Faction.vb")
				wr.WriteLine("' Auto generated from Factions.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseFaction(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing Factions.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseFaction(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				Dim tmpStr as String
				tmp = Split(Replace(Line,", ","® "),",")

				Dim ID as Short = tmp(0)
				Dim VisibleID as Short = tmp(1)
				Dim Name as String = Replace(tmp(19),"® ",", ")
				Name=Right(Name,Name.Length-1)
				Name=Left(Name,Name.Length-1)

				Dim flags1 as Byte = tmp(2)
				Dim flags2 as Byte = tmp(3)
				Dim flags3 as Byte = tmp(4)
				Dim flags4 as Byte = tmp(5)

				Dim points1 as Integer = tmp(10)
				Dim points2 as Integer = tmp(11)
				Dim points3 as Integer = tmp(12)
				Dim points4 as Integer = tmp(13)

				Dim rep_flags1 as Integer = tmp(14)
				Dim rep_flags2 as Integer = tmp(15)
				Dim rep_flags3 as Integer = tmp(16)
				Dim rep_flags4 as Integer = tmp(17)

				wr.WriteLine("WS_DBCDatabase.FactionInfo({0}) = New WS_DBCDatabase.TFaction({0},  {1},  ""{10}"",  {2},{3},{4},{5},  {6},{7},{8},{9}, {11},{12},{13},{14})",id,VisibleID,flags1,flags2,flags3,flags4,points1,points2,points3,points4,name,rep_flags1,rep_flags2,rep_flags3,rep_flags4)

				Factions+=1
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
