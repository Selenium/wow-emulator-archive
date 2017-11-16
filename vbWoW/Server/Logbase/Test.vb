Imports System.Threading

Module Test

    Sub Main()
        Dim x As New FileWriter("x")
        'While True
        '    x.PrintDiagnosticTest()
        'End While

        Dim tmp As String = ""
        While True
            tmp = x.ReadLine()
            tmp = tmp.ToUpper
            x.WriteLine(BaseWriter.LogType.CRITICAL, tmp)
        End While

        x.Dispose()
        Console.Read()
    End Sub

End Module
