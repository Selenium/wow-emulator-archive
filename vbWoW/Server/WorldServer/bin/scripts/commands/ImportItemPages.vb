Imports System
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands
		
		Dim tmpText as String = ""
		Dim tmpNext as Integer = 0
		Dim tmpPage as Integer = 0
		Dim lineNum as Integer = 0
		Dim pages as Integer = 0

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Parsing Pages.scp.......",Format(TimeOfDay, "hh:mm:ss"))
			Start
			Console.WriteLine("[{0}] Scripting: Parsed {1} pages.",Format(TimeOfDay, "hh:mm:ss"),pages)
		End Sub

		Public Sub Start()
            Try
                Dim sr As StreamReader = New StreamReader("Pages.scp")
                Dim line As String
                Do
                    line = sr.ReadLine()
					lineNum += 1
					if trim(line)<>"" then ParsePage(line)
                Loop Until line Is Nothing
					if tmpPage<>0 then
						Dim MySQLQuery As New DataTable
						MySQL.Query(String.Format("SELECT * FROM adb_item_pages WHERE pageId = ""{0}"";", tmpPage), MySQLQuery)
						if MySQLQuery.Rows.Count = 0 then
							'Console.writeline(string.Format("INSERT INTO adb_item_pages (pageId,pageNext,pageText) VALUES (""{0}"",""{1}"",""{2}"");",tmpPage,tmpNext,tmpText))
							MySQL.Update(string.Format("INSERT INTO adb_item_pages (pageId,pageNext,pageText) VALUES (""{0}"",""{1}"",'{2}');",tmpPage,tmpNext,tmpText))
						else
							'Console.writeline(string.Format("UPDATE adb_item_pages SET pageNext=""{1}"", pageText=""{2}"" WHERE pageId=""{0}"";",tmpPage,tmpNext,tmpText))
							MySQL.Update(string.Format("UPDATE adb_item_pages SET pageNext=""{1}"", pageText='{2}' WHERE pageId=""{0}"";",tmpPage,tmpNext,tmpText))
						end if
					end if
                sr.Close()

            Catch E As Exception
                Console.WriteLine("[{0}] Scripting: Error parsing pages.scp.",Format(TimeOfDay, "hh:mm:ss"))
                Console.WriteLine(E.ToString)
            End Try
        End Sub

        Public Sub ParsePage(ByVal Line As String)
			try
				If Line.Substring(0, 1) = "[" Then
					if tmpPage<>0 then
						Dim MySQLQuery As New DataTable
						MySQL.Query(String.Format("SELECT * FROM adb_item_pages WHERE pageId = ""{0}"";", tmpPage), MySQLQuery)
						if MySQLQuery.Rows.Count = 0 then
							'Console.writeline(string.Format("INSERT INTO adb_item_pages (pageId,pageNext,pageText) VALUES (""{0}"",""{1}"",""{2}"");",tmpPage,tmpNext,tmpText))
							MySQL.Update(string.Format("INSERT INTO adb_item_pages (pageId,pageNext,pageText) VALUES (""{0}"",""{1}"",'{2}');",tmpPage,tmpNext,tmpText))
						else
							'Console.writeline(string.Format("UPDATE adb_item_pages SET pageNext=""{1}"", pageText=""{2}"" WHERE pageId=""{0}"";",tmpPage,tmpNext,tmpText))
							MySQL.Update(string.Format("UPDATE adb_item_pages SET pageNext=""{1}"", pageText='{2}' WHERE pageId=""{0}"";",tmpPage,tmpNext,tmpText))
						end if
					end if
					tmpPage=Line.Substring(5,Line.Length - 6)
					tmpNext=0
					tmpText=""
					pages += 1
					exit sub
				End If

				If Line.Substring(0, 4) = "text" Then
					if tmpText="" then
						tmpText = tmpText & Replace(Line.Substring(5),"'","\'")
					else
						tmpText = tmpText & vbNewLine & Replace(Line.Substring(5),"'","\'")
					end if
					Exit Sub
				End If

				If Line.Substring(0, 4) = "next" Then
					tmpNext = Line.Substring(11)
					Exit Sub
				End If
				

				Console.WriteLine("[{0}] Scripting: Unknown line [{2}] {1}.",Format(TimeOfDay, "hh:mm:ss"),line,lineNum)
			catch err as System.ArgumentOutOfRangeException
				Console.WriteLine("[{0}] Scripting: Unknown line [{2}] {1}.",Format(TimeOfDay, "hh:mm:ss"),line,lineNum)
			catch e as exception
				Console.WriteLine("[{0}] Scripting: Line [{4}] {1} caused error. {2}{3}",Format(TimeOfDay, "hh:mm:ss"),line,vbNewLine,e.ToString,lineNum)
			end try
        End Sub

	End Module
End Namespace
