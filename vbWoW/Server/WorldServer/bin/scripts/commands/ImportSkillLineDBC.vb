'********************************************************************
'*			Use DBCTool to export CSV						        *
'*			and then use this command to import it					*
'*				- SkillLine.dbc										*
'********************************************************************
'* Sample line:														*
'* 6,"Class Skills",0,"Frost",0,0,0,0,0,0,0,"000111110000000000111110","",0,0,0,0,0,0,0,2031676,188
'********************************************************************


Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim lineNum as Integer = 0
		Dim SkillLines as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing SkillLine.csv.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} SkillLines.",Format(TimeOfDay, "hh:mm:ss"),SkillLines)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("SkillLine.csv")
				Dim wr as StreamWriter = New StreamWriter("SkillLine.vb")
				wr.WriteLine("' Auto generated from SkillLine.dbc")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParseSkillLine(line,wr)
                Loop Until line Is Nothing
                sr.Close()
				wr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing SkillLine.csv.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParseSkillLine(ByVal Line As String, wr as StreamWriter)
			try
				Dim tmp() as String
				tmp = Split(line,",")

				Dim SkillID as Integer=tmp(0)
				Dim SkillLineCategory as String=tmp(1)
				SkillLineCategory=Right(SkillLineCategory,SkillLineCategory.Length-1)
				SkillLineCategory=Left(SkillLineCategory,SkillLineCategory.Length-1)
				Dim SkillName as String=tmp(3)
				SkillName=Right(SkillName,SkillName.Length-1)
				SkillName=Left(SkillName,SkillName.Length-1)

				SkillLines+=1
				Select Case SkillLineCategory
					Case "Attributes"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,5,SkillName)
					Case "Weapon Skills"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,6,SkillName)
					Case "Class Skills"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,7,SkillName)
					Case "Armor Proficiencies"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,8,SkillName)
					Case "Secondary Skills"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,9,SkillName)
					Case "Languages"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,10,SkillName)
					Case "Professions"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,11,SkillName)
					Case "Not Displayed"
						wr.WriteLine("SkillLines({0}) = {1} '{2}",SkillID,12,SkillName)
				Case Else
					wr.WriteLine("'Unknow SkillLineCategory:")
					wr.WriteLine("'SkillLines({1}) = {0} '{2}",SkillID,0,SkillName,"! Unknow SkillLineCategory")
				End Select

				exit sub

			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
