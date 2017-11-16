Imports System.Runtime.CompilerServices
Imports System.IO


'Using this logging type, all logs are saved in files numbered by date.
'Writting commands is done trought console.
Public Class FileWriter
    Inherits BaseWriter

    Protected Output As IO.StreamWriter
    Protected LastDate As Date = #1/1/2007#
    Protected Filename As String = ""

    Protected Sub CreateNewFile()
        LastDate = Now.Date
        Output = New StreamWriter(String.Format("{0}-{1}.log", Filename, Format(LastDate, "yyyy-MM-dd")), True)
        Output.AutoFlush = True

        Me.WriteLine(LogType.INFORMATION, "Log started successfully.")
    End Sub

    Public Sub New(ByVal filename_ As String)
        Filename = filename_
        CreateNewFile()
    End Sub
    Public Overrides Sub Dispose()
        Output.Close()
    End Sub

    Public Overrides Sub Write(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return
        If LastDate <> Now.Date Then CreateNewFile()

        Output.Write(formatStr, arg)
    End Sub
    Public Overrides Sub WriteLine(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return
        If LastDate <> Now.Date Then CreateNewFile()

        Output.WriteLine(L(type) & ":[" & Format(TimeOfDay, "hh:mm:ss") & "] " & formatStr, arg)
    End Sub


End Class