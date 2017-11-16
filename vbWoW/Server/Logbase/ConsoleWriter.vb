
'Using this logging type, all logs are displayed in console.
'Writting commands is done trought console.
Public Class ConsoleWriter
    Inherits BaseWriter

    Public Overrides Sub Write(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return

        Console.Write(formatStr, arg)
    End Sub
    Public Overrides Sub WriteLine(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return

        Console.WriteLine(L(type) & ":" & "[" & Format(TimeOfDay, "hh:mm:ss") & "] " & formatStr, arg)
    End Sub


End Class
