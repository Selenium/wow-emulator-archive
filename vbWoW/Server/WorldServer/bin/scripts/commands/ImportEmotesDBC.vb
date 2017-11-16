'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- Emotes.dbc										*
'********************************************************************
'* Sample line:														*
'* 0,"ONESHOT_NONE","Stand","00000000000000000000000000000000",0,0,0*
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim emotes as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Emotes.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} emotes.",Format(TimeOfDay, "hh:mm:ss"),emotes)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("Emotes.csv")
				Dim wr as StreamWriter = New StreamWriter("Emotes.vb")
				wr.WriteLine("Public Enum Emotes")
				wr.WriteLine("' Auto generated from Emotes.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseEmote(line,wr)
                Loop Until line Is Nothing
				wr.WriteLine("End Enum")
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing Emotes.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseEmote(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim EmoteID as Integer=tmp(0)
				Dim EmoteName as String=tmp(1)
				EmoteName=Right(EmoteName,EmoteName.Length-1)
				EmoteName=Left(EmoteName,EmoteName.Length-1)
				EmoteName=Replace(EmoteName,"(DNR)","")
				emotes+=1
				Console.WriteLine("EmoteID={0} EmoteName={1}",EmoteID,EmoteName)
				wr.WriteLine("	{1} = {0}",EmoteID,EmoteName)
				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
