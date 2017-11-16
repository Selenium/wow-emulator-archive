'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- TaxiNodes.dbc										*
'********************************************************************
'* Sample line:														*
'* 1,0,-8888.98,-0.54,94.39,"Northshire Abbey",0,0,0,0,0,0,0,"011111110000000000111110"
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim TaxiNodes as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing TaxiNodes.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} TaxiNodes.",Format(TimeOfDay, "hh:mm:ss"),TaxiNodes)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("TaxiNodes.csv")
				Dim wr as StreamWriter = New StreamWriter("TaxiNodes.vb")
				wr.WriteLine("' Auto generated from TaxiNodes.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseTaxiNodesLine(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing TaxiNodes.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseTaxiNodesLine(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim ID as Short = tmp(0)
				Dim MapID as Integer=tmp(1)
				Dim X as String=tmp(2)
				Dim Y as String=tmp(3)
				Dim Z as String=tmp(4)
				Dim Name as String=tmp(5)
				Name=Right(Name,Name.Length-1)
				Name=Left(Name,Name.Length-1)


				TaxiNodes+=1
				If MapID=1  then
					wr.WriteLine("If HANDLED_MAP_ID=1 then TaxiNodes.Add(New TTaxiNode({0},{1},{2},{4},1) ) '{3}",X,Y,Z,Name,ID)
				elseif  MapID=0  then
					wr.WriteLine("If HANDLED_MAP_ID=0 then TaxiNodes.Add(New TTaxiNode({0},{1},{2},{4},0) ) '{3}",X,Y,Z,Name,ID)
				else
					wr.WriteLine("If HANDLED_MAP_ID=-1 then TaxiNodes.Add(New TTaxiNode({0},{1},{2},{5},{4}) ) '{3}",X,Y,Z,Name,MapID,ID)
				end if
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
