'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- AreaTable.dbc										*
'********************************************************************
'* Sample line:														*
'* 1,0,0,119,0x41,0,11,42,8,0,0,"Dun Morogh",,,,,,,,0x1F003E,0x2,	*
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim Areas as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing AreaTable.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} areas.",Format(TimeOfDay, "hh:mm:ss"),Areas)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("AreaTable.csv")
				Dim wr as StreamWriter = New StreamWriter("AreaTable.vb")
				wr.WriteLine("' Auto generated from AreaTable.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseArea(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing AreaTable.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseArea(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim AreaID as Integer = tmp(0)
				Dim AreaZone as Integer = tmp(2)
					if AreaZone=0 then AreaZone=AreaID
				Dim AreaFlag as Integer = tmp(3)
				Dim AreaLevel as Integer = tmp(10)
					if AreaLevel<0 then AreaLevel=0
				Dim AreaName as String = tmp(11)
					AreaName=Right(AreaName,AreaName.Length-1)
					AreaName=Left(AreaName,AreaName.Length-1)
					Areas+=1

				wr.WriteLine("WS_DBCDatabase.AreaTable({0}) = New WS_DBCDatabase.TArea({1},{2},{3}) '{4}",AreaFlag,AreaID,AreaLevel,AreaZone,AreaName)
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
