'********************************************************************
'*			Sample Custom Scripted Console Command                  *
'********************************************************************

Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CustomCommands

		Public Sub OnExecute()
			Dim tmp as string =""
			Dim count as Byte = 0
			Console.Write("Broadcast message: ")
			tmp=Console.ReadLine()

			For Each Character As Object In CHARACTERs
                Character.Value.SystemMessage("System Message: " & WS_MiscHandlers.SetColor(tmp, 255, 0, 0))
				count=count+1
            Next
			Console.WriteLine("Admin Broadcast [{0}] [{1}]",tmp,count)
		End Sub

	End Module
End Namespace
