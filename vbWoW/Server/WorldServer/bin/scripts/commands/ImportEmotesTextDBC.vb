'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- EmotesText.dbc									*
'********************************************************************
'* Sample line:														*
'* 1,"AGREE",0,1,2,3,,4,,5,,0,0,,,0,,,,								*
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim emotes as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing EmotesText.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} emotes.",Format(TimeOfDay, "hh:mm:ss"),emotes)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("EmotesText.csv")
				Dim wr as StreamWriter = New StreamWriter("EmotesText.vb")
				wr.WriteLine("' Auto generated from EmotesText.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseEmote(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing EmotesText.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseEmote(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim EmoteTextID as Integer = tmp(0)
				Dim EmoteTextName as String = tmp(1)
				Dim EmoteID	as Integer = tmp(2)
				EmoteTextName=Right(EmoteTextName,EmoteTextName.Length-1)
				EmoteTextName=Left(EmoteTextName,EmoteTextName.Length-1)
				emotes+=1
				Console.WriteLine("EmoteTextID={0} EmoteTextName={1} EmoteID={2}",EmoteTextID,EmoteTextName,EmoteID)

				if EmoteID>0 then wr.WriteLine("WS_DBCDatabase.EmotesText({0}) = {2} '{1}",EmoteTextId,EmoteTextName,EmoteID)
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
