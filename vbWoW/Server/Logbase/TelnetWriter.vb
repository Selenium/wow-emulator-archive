Imports System.Threading
Imports System.Net.Sockets


'Using this logging type, you can watch logs with ordinary telnet client.
'Writting commands requires client, which don't send every key typed.
Public Class TelnetWriter
    Inherits BaseWriter

    Protected conn As TcpListener
    Protected socket As socket = Nothing
    Protected Const SLEEP_TIME As Integer = 1000

    Public Sub New(ByVal host As System.Net.IPAddress, ByVal port As Integer)
        conn = New TcpListener(host, port)
        conn.Start()
        ThreadPool.QueueUserWorkItem(AddressOf ConnWaitListen)
    End Sub
    Public Overrides Sub Dispose()
        conn.Stop()
        conn = Nothing
        socket.Close()
    End Sub


    Public Overrides Sub Write(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return
        If socket Is Nothing Then Return

        Try
            socket.Send(System.Text.Encoding.UTF8.GetBytes(String.Format(formatStr, arg).ToCharArray))
        Catch
            socket = Nothing
        End Try
    End Sub
    Public Overrides Sub WriteLine(ByVal type As LogType, ByVal formatStr As String, ByVal ParamArray arg() As Object)
        If LogLevel > type Then Return
        If socket Is Nothing Then Return

        Try
            socket.Send(System.Text.Encoding.UTF8.GetBytes(String.Format(L(type) & ":" & "[" & Format(TimeOfDay, "hh:mm:ss") & "] " & formatStr & vbNewLine, arg).ToCharArray))
        Catch
            socket = Nothing
        End Try
    End Sub
    Public Overrides Function ReadLine() As String
        While (socket Is Nothing) OrElse (socket.Available = 0)
            Thread.Sleep(SLEEP_TIME)
        End While

        Dim buffer(socket.Available) As Byte
        socket.Receive(buffer)
        Return System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length)
    End Function


    Protected Sub ConnWaitListen(ByVal state As Object)
        Do While (Not conn Is Nothing)
            Thread.Sleep(SLEEP_TIME)
            If conn.Pending() Then
                socket = conn.AcceptSocket
            End If
        Loop
    End Sub



End Class
