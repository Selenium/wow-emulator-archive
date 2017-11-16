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
		Dim DurabilityCosts as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing DurabilityCosts.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} DurabilityCosts.",Format(TimeOfDay, "hh:mm:ss"),DurabilityCosts)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("DurabilityCosts.csv")
				Dim wr as StreamWriter = New StreamWriter("DurabilityCosts.vb")
				wr.WriteLine("' Auto generated from DurabilityCosts.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseDurabilityCosts(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing DurabilityCosts.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseDurabilityCosts(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim Percent as Integer = tmp(0)


				Dim values(28) as Byte
				dim i as byte=0
				for i=0 to 28
					values(i)=tmp(i+1)
					wr.WriteLine("WS_DBCDatabase.DurabilityCosts({0},{1}) = {2}",Percent,i,values(i))
				next i
				DurabilityCosts+=1
				
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
