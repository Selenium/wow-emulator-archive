'********************************************************************
'*			Sample Custom Scripted Console Command                  *
'********************************************************************

Imports System
Imports Microsoft.VisualBasic

Namespace Scripts
	Public Module CustomCommands

		Public Sub OnExecute()
			Console.WriteLine("[{0}] Scripting: Command executed.",Format(TimeOfDay, "hh:mm:ss"))
			Dim tmp as string =""
			Console.Write("Please input test value:")
			tmp=Console.ReadLine()
			Console.WriteLine("You have entered value [{0}]",tmp)
		End Sub

	End Module
End Namespace
