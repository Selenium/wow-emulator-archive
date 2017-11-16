'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- WorldSafeLocs.dbc									*
'********************************************************************
'* Sample line:														*
'* 1,0,-9115,423,96,"Stormwind",0,0,0,0,0,0,0,"011111110000000000111110"
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim WorldSafeLocs as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing WorldSafeLocs.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} WorldSafeLocs.",Format(TimeOfDay, "hh:mm:ss"),WorldSafeLocs)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("WorldSafeLocs.csv")
				Dim wr as StreamWriter = New StreamWriter("WorldSafeLocs.vb")
				wr.WriteLine("' Auto generated from WorldSafeLocs.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseWorldSafeLocsLine(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing WorldSafeLocs.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseWorldSafeLocsLine(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim MapID as Integer=tmp(1)
				Dim GraveyardX as String=tmp(2)
				Dim GraveyardY as String=tmp(3)
				Dim GraveyardZ as String=tmp(4)
				Dim GraveyardName as String=tmp(5)
				GraveyardName=Right(GraveyardName,GraveyardName.Length-1)
				GraveyardName=Left(GraveyardName,GraveyardName.Length-1)


				WorldSafeLocs+=1
				If MapID=1  then
					wr.WriteLine("If HANDLED_MAP_ID=1 then Graveyards.Add(New TGraveyard({0},{1},{2},1) ) '{3}",GraveyardX,GraveyardY,GraveyardZ,GraveyardName)
				elseif  MapID=0  then
					wr.WriteLine("If HANDLED_MAP_ID=0 then Graveyards.Add(New TGraveyard({0},{1},{2},0) ) '{3}",GraveyardX,GraveyardY,GraveyardZ,GraveyardName)
				else
					wr.WriteLine("If HANDLED_MAP_ID=-1 then Graveyards.Add(New TGraveyard({0},{1},{2},{4}) ) '{3}",GraveyardX,GraveyardY,GraveyardZ,GraveyardName,MapID)
				end if
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
