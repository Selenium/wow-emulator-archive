Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Reflection
Imports System.Xml.Serialization
Imports vbWoW.Database

Namespace WebServer
    Public Module MainMod
#Region "Global variables"
        Private RootFolder As String
        Public ConsoleColor As New ConsoleColor
        Public WithEvents SQL As SQL

        'MySQL Needed values [default]
        Public MySQLHost As String = "127.0.0.1"
        Public MySQLUser As String = "vbwow"
        Public MySQLPass As String = "damnfoo"
        Public MySQLDBName As String = "vbwowdb"
        Public MySQLConnectionType As SQL.DB_Type = SQL.DB_Type.MySQL
#End Region

        Private Sub HandleHTTP()
            Dim DefaultPort As Integer = 81
            Dim EndPoint As IPEndPoint = New IPEndPoint(Net.IPAddress.Parse("0.0.0.0"), Int32.Parse(DefaultPort))
            Dim ss As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

            ss.Bind(EndPoint)
            ss.Listen(20)
            Try
                While True
                    ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightGreen)
                    Console.WriteLine("Server is waiting for a new connection..")
                    ConsoleColor.SetConsoleColor()
                    Dim sock As Socket = ss.Accept()
                    ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightGreen)
                    Console.WriteLine("Accepted connection from:" + sock.RemoteEndPoint.ToString)
                    ConsoleColor.SetConsoleColor()
                    Dim c As HTTPServer = New HTTPServer(sock, RootFolder + "\www")
                    Dim t As Thread = New Thread(New ThreadStart(AddressOf c.HandleConnection))
                    t.IsBackground = True
                    t.Priority = ThreadPriority.BelowNormal
                    t.Start()
                End While
            Catch e1 As Exception
                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Red)
                Console.WriteLine("An Exception Occurred while Listening :" + e1.ToString())
                ConsoleColor.SetConsoleColor()
            End Try
        End Sub

        Sub main()
            RootFolder = Application.StartupPath
            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Green)
            Console.WriteLine("*****************************************")
            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Green)
            Console.Write("*")
            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightRed)
            Console.Write("        Type help for commands.        ")
            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Green)
            Console.WriteLine("*")
            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Green)
            Console.WriteLine("*****************************************")
            ConsoleColor.SetConsoleColor()

            Dim tmp As String, CommandList() As String, cmd2() As String
            Dim varList As Integer
            While True
                tmp = Console.ReadLine()
                CommandList = tmp.Split(";")

                For varList = LBound(CommandList) To UBound(CommandList)
                    cmd2 = CommandList(varList).Split(" ")
                    If CommandList(varList).Length > 0 Then
                        Debug.Print(cmd2(0))
                        Select Case cmd2(0)
                            Case "shutdown"
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.WriteLine("HTTP Server shutting down...")
                                ConsoleColor.SetConsoleColor()
                                Thread.Sleep(1000)
                                End
                            Case "start"
                                SQL = New SQL 'MySQLClass(MySQLHost, MySQLUser, MySQLPass, MySQLDBName)
                                SQL.SQLHost = MySQLHost
                                SQL.SQLUser = MySQLUser
                                SQL.SQLPass = MySQLPass
                                SQL.SQLDBName = MySQLDBName
                                SQL.SQLTypeServer = MySQLConnectionType
                                SQL.Connect()
                                Dim th As Thread = New Thread(New ThreadStart(AddressOf HandleHTTP))
                                th.Start()
                            Case "db"
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.WriteLine("Please enter your SQL Host ip.")
                                ConsoleColor.SetConsoleColor()
                                Dim db As String, db2 As String, dbcmd As Integer
                                While True
                                    db = Console.ReadLine()
                                    dbcmd += 1
                                    If tmp.IndexOf(" ") > 0 Then
                                        db2 = tmp.Substring(tmp.IndexOf(" ") + 1)
                                        db = tmp.Substring(0, tmp.IndexOf(" "))
                                    End If

                                    Select Case dbcmd
                                        Case 1
                                            MySQLHost = db
                                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                            Console.WriteLine("Please enter your SQL Username.")
                                            ConsoleColor.SetConsoleColor()
                                        Case 2
                                            MySQLUser = db
                                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                            Console.WriteLine("Please enter your SQL Password.")
                                            ConsoleColor.SetConsoleColor()
                                        Case 3
                                            MySQLPass = db
                                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                            Console.WriteLine("Please enter your SQL connection type.")
                                            ConsoleColor.SetConsoleColor()
                                        Case 4
                                            Select Case db.ToLower
                                                Case "ms-sql"
                                                    MySQLConnectionType = SQL.DB_Type.MSSQL
                                                    Console.WriteLine("Please enter your SQL Database name.")
                                                Case "mysql"
                                                    MySQLConnectionType = SQL.DB_Type.MySQL
                                                    Console.WriteLine("Please enter your SQL Database name.")
                                                Case Else
                                                    dbcmd -= 1
                                                    Console.WriteLine("Database's currently supported are MS-SQL and MySQL please type one.")
                                            End Select
                                        Case 5
                                            MySQLDBName = db

                                            'show the sql info
                                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightRed)
                                            Console.WriteLine("HOST        Name        Pass        Database        Connection")
                                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                            Console.WriteLine(MySQLHost & "       " & MySQLUser & "       " & MySQLPass & "       " & MySQLDBName & "     " & IIf(MySQLConnectionType = SQL.DB_Type.MSSQL, "MS-SQL", "MySQL"))
                                            ConsoleColor.SetConsoleColor()
                                            Exit While
                                    End Select
                                End While

                            Case "help"
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.Write("Start        ")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightBlue)
                                Console.WriteLine("starts the server.")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.Write("Shutdown     ")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightBlue)
                                Console.WriteLine("shuts the server off and closes it.")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.Write("db           ")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightBlue)
                                Console.WriteLine("sets the SQL main values defaults are,")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightRed)
                                Console.WriteLine(" HOST        Name        Pass        Database        Connection")
                                ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                                Console.WriteLine(" " & MySQLHost & "       " & MySQLUser & "       " & MySQLPass & "       " & MySQLDBName & "     " & IIf(MySQLConnectionType = SQL.DB_Type.MSSQL, "MS-SQL", "MySQL"))

                                ConsoleColor.SetConsoleColor()
                            Case Else
                                '
                        End Select
                    End If
                Next
            End While
        End Sub

        Private Sub SQL_SQLMessage(ByVal MessageID As SQL.EMessages, ByVal OutBuf As String) Handles SQL.SQLMessage
            Debug.WriteLine(OutBuf)
        End Sub
    End Module
End Namespace
