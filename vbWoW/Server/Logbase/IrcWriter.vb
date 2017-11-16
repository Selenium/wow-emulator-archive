Imports Meebey.SmartIrc4net
Imports System.Threading


Public Class IrcWriter
    Inherits BaseWriter

    Dim conn As IrcClient
    Dim message As String = Nothing
    Public Sub New(ByVal server As String, ByVal port As Integer, ByVal nick As String, ByVal channel As String)
        conn = New IrcClient
        conn.AutoReconnect = True
        conn.AutoRejoin = True
        conn.AutoRelogin = True
        conn.SendDelay = 200
        conn.ActiveChannelSyncing = True

        AddHandler conn.OnError, AddressOf OnErrorMessage
        AddHandler conn.OnQueryMessage, AddressOf OnQueryMessage
#If DEBUG Then
        AddHandler conn.OnRawMessage, AddressOf OnRawMessage
#End If

        conn.CtcpVersion = "aWoWe Log Bot"
        conn.Connect(server, port)
        conn.Login(nick, "aWoWe Log Bot")
        conn.RfcJoin(channel)
        conn.SendMessage(SendType.Action, channel, " starts logging")

        Dim t As New Thread(AddressOf conn.Listen)
        t.Start()
    End Sub
    Public Overrides Sub Dispose()
        conn.Disconnect()
    End Sub


    Public Overrides Sub Write(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return

        For Each Channel As String In conn.JoinedChannels
            conn.SendMessage(SendType.Message, Channel, String.Format(formatStr, arg))
        Next
    End Sub
    Public Overrides Sub WriteLine(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return

        For Each Channel As String In conn.JoinedChannels
            conn.SendMessage(SendType.Message, Channel, String.Format(formatStr, arg))
        Next
    End Sub
    Public Overrides Function ReadLine() As String
        While (message Is Nothing)
            System.Threading.Thread.Sleep(100)
        End While

        Dim msg As String = message
        message = Nothing
        Return msg
    End Function

    Public Sub OnQueryMessage(ByVal sender As Object, ByVal e As IrcEventArgs)
        Console.WriteLine(e.Data.Message)
        message = e.Data.Message
    End Sub
    Public Sub OnRawMessage(ByVal sender As Object, ByVal e As IrcEventArgs)
        Console.WriteLine(e.Data.RawMessage)
    End Sub
    Public Sub OnErrorMessage(ByVal sender As Object, ByVal e As ErrorEventArgs)
        Console.WriteLine(e.ErrorMessage)
    End Sub

End Class