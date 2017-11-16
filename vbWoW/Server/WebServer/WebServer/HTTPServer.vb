Imports System
Imports System.Collections
Imports System.Net
Imports System.Net.Sockets
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Xml.Serialization
'Imports MySQL.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Reflection

Namespace WebServer
    Module WebServer

        Public Class HTTPServer
            Private RootFolder As String
            Private MyHTTPSocket As Socket
            Private DefaultPort As Integer = 81
            Private uName As String = ""
            Private uPass As String = ""
            Private uEmail As String = ""
            Private LastHTMFile As String = "index.html"
            Private LastPHPFile As String = "index.php" ' Added index.php. Most webservers will use index.php.

            Public Sub New()
                Dim IPAddress As IPAddress = Dns.GetHostEntry("0.0.0.0").AddressList(0)
                Dim EndPoint As IPEndPoint = New IPEndPoint(IPAddress, Int32.Parse(DefaultPort))
            End Sub

            Public Sub New(ByVal port As Integer)
                Dim IPAddress As IPAddress = Dns.GetHostEntry("0.0.0.0").AddressList(0)
                Dim EndPoint As IPEndPoint = New IPEndPoint(IPAddress, Int32.Parse(port))
            End Sub

            Public Sub New(ByVal s As Socket, ByVal Location As String)
                MyHTTPSocket = s
                RootFolder = Location
            End Sub

            'TODO: Needs time checking want to wait a sec or 2 befor letting on another connection.
            Public Sub HandleConnection()
                Try
                    Dim iStartPos As Integer = 0

                    Dim bRecieve(MyHTTPSocket.ReceiveBufferSize) As Byte
                    Dim i As Integer = MyHTTPSocket.Receive(bRecieve, bRecieve.Length, 0)

                    Dim sBuffer As String = Encoding.ASCII.GetString(bRecieve)
                    Dim sCase As String = ""
                    Dim x As Integer

                    For x = 0 To bRecieve.Length
                        If sBuffer.Substring(x, 1) <> " " Then
                            sCase += sBuffer.Substring(x, 1)
                        Else
                            x = bRecieve.Length
                        End If
                    Next

                    Select Case sCase
                        Case "GET"
                            HandleGET(bRecieve)
                        Case "POST"
                            HandlePOST(bRecieve)
                        Case Else
                            Debug.WriteLine(sBuffer)
                            Console.WriteLine(sCase + " method is not supported..")
                    End Select
                Catch e As Exception
                    MyHTTPSocket.Close()
                Finally
                    MyHTTPSocket.Close()
                End Try
            End Sub

            Private Sub HandlePOST(ByVal bReceive() As Byte)
                Dim sBuffer As String = Encoding.ASCII.GetString(bReceive)
                Dim sRequest, sDirName, sRequestedFile, sLocalDir As String
                Dim iStartPos As Integer = 0
                Dim sPhysicalFilePath As String = RootFolder

                '// Look for HTTP request
                iStartPos = sBuffer.IndexOf("HTTP", 1)
                '// Get the HTTP text and version e.g. it will return "HTTP/1.1"
                Dim sHttpVersion As String = sBuffer.Substring(iStartPos, 8)
                '// Extract the Requested Type and Requested file/directory
                sRequest = sBuffer.Substring(0, iStartPos - 1)
                '//Replace backslash with Forward Slash, if Any
                sRequest.Replace("\\", "/")
                '//If file name is not supplied add forward slash to indicate 
                '//that it is a directory and then we will look for the 
                '//default file name..
                If ((sRequest.IndexOf(".") < 1) And (Not sRequest.EndsWith("/"))) Then
                    sRequest = sRequest + "/"
                End If
                '//Extract the requested file name
                iStartPos = sRequest.LastIndexOf("/") + 1
                sRequestedFile = sRequest.Substring(iStartPos)
                '//Extract The directory Name
                sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3)
                sLocalDir = RootFolder


                iStartPos = sBuffer.IndexOf("action", 1)
                Dim sActionCommand As String = sBuffer.Substring(iStartPos, bReceive.Length - iStartPos)
                Dim aMain As String = ""
                Dim aCommands() As String
                Dim SearchIndex As Integer

                aCommands = sActionCommand.Split("&")

                Dim tmp As String, cmd2 As String = ""
                For SearchIndex = 0 To (aCommands.Length - 1)
                    tmp = aCommands(SearchIndex)
                    If tmp.IndexOf("=") > 0 Then
                        cmd2 = tmp.Substring(tmp.IndexOf("=") + 1)
                        tmp = tmp.Substring(0, tmp.IndexOf("="))
                    End If
                    Select Case tmp
                        Case "action"
                            aMain = cmd2
                        Case "user"
                            uName = cmd2
                        Case "pass"
                            uPass = cmd2
                        Case "email"
                            uEmail = cmd2
                            'Case "passphrase" 'Not in the accounts SQL DB.
                            '    uAnswer = cmd2
                        Case Else
                            'do nothing
                    End Select
                Next
                'check if any of the values are empty

                'action=create&user=asdf&pass=asdf&email=dragonkings@gmail.com&passphrase=asdf
                'action=login&user=as&pass=as&lt=LT-69548-sfPwgSTuLdaE7eczl6ke&x=42&y=12
                Select Case aMain
                    Case "login"
                        DoLogin(sRequestedFile, uName, uPass)
                    Case "create"
                        DoCreate(sRequestedFile, uName, uPass, uEmail)
                End Select
            End Sub

#Region "HTTP Login scripts 100%"
            Private Sub DoLogin(ByVal FileSend As String, ByVal uName As String, ByVal uPass As String)
                Dim sErrorMessage1 As String = "<table cellspacing = ""5"" cellpadding = ""0"" border = ""0"" width = ""400""><tr><td><img src = ""images/error.gif"" width = ""54"" height = ""51"" alt = ""error""></td><td><span class=""error"">"
                Dim sErrorMessage2 As String = "</span></td></table>"

                If uName.Length <= 0 Then
                    LoginCreateError(LastHTMFile, sErrorMessage1 + "Sorry, you entered an invalid username or password. Please try again." + sErrorMessage2)
                    Exit Sub
                End If
                If uPass.Length <= 0 Then
                    LoginCreateError(LastHTMFile, sErrorMessage1 + "Sorry, you entered an invalid username or password. Please try again." + sErrorMessage2)
                    Exit Sub
                End If

                If SQL.QuerySQL([String].Format("SELECT * FROM adb_accounts WHERE account = '{0}'", uName.ToUpper)) Then
                    If SQL.GetSQL("banned") = 1 Then
                        'banned
                        LoginCreateError(LastHTMFile, sErrorMessage1 + "Sorry, that account I currently under a ban. Please try again later." + sErrorMessage2)
                    Else
                        Dim PassString As String = SQL.GetSQL("password")
                        If uPass.ToUpper = PassString.ToUpper Then
                            'good password
                            Dim sHttpVersion As String = "HTTP/1.1"
                            Dim sMimeType As String = GetMimeType(FileSend)

                            If FileSend.EndsWith(".htm") Then LastHTMFile = FileSend
                            If FileSend.EndsWith(".html") Then LastHTMFile = FileSend

                            Dim bytes() As Byte = GetFileData(RootFolder + "/" + FileSend, uName, uPass, uEmail, "")
                            Dim myIp() As String = MyHTTPSocket.RemoteEndPoint.ToString.Split(":")
                            SQL.Update([String].Format("UPDATE adb_accounts SET last_ip='{1}', last_login='{2}' WHERE account = '{0}'", uName, myIp(0), Format(Now, "yyyy-MM-dd")))

                            SendHeader(sHttpVersion, sMimeType, bytes.Length, " 200 OK")
                            SendToBrowser(bytes)
                        Else
                            'bad password
                            LoginCreateError(LastHTMFile, sErrorMessage1 + "Sorry, that password is incorrect." + sErrorMessage2)
                        End If
                    End If
                Else
                    'account dosent exist
                    LoginCreateError(LastHTMFile, sErrorMessage1 + "Sorry, that account dosen't exist. Please try another name." + sErrorMessage2)
                End If
            End Sub
#End Region

#Region "Create account 100%, TODO: text checking (check for valid characters)"
            Private Sub DoCreate(ByVal FileSend As String, ByVal uName As String, ByVal uPass As String, ByVal uEmail As String)
                Dim sErrorMessage1 As String = "<table cellspacing = ""5"" cellpadding = ""0"" border = ""0"" width = ""400""><tr><td><img src = ""images/error.gif"" width = ""54"" height = ""51"" alt = ""error""></td><td><span class=""error"">"
                Dim sErrorMessage2 As String = "</span></td></table>"
                If uName.Length <= 0 Then
                    LoginCreateError("newaccount.html", sErrorMessage1 + "Sorry, you must enter a Username." + sErrorMessage2)
                    Exit Sub
                End If
                If uPass.Length <= 0 Then
                    LoginCreateError("newaccount.html", sErrorMessage1 + "Sorry, you must enter a Password." + sErrorMessage2)
                    Exit Sub
                End If
                If uEmail.Length <= 0 Then
                    LoginCreateError("newaccount.html", sErrorMessage1 + "Sorry, you must enter a valid Email." + sErrorMessage2)
                    Exit Sub
                End If

                If SQL.QuerySQL([String].Format("SELECT * FROM adb_accounts WHERE account = '{0}'", uName.ToUpper)) Then
                    LoginCreateError("newaccount.html", sErrorMessage1 + "Sorry, that account allready exists." + sErrorMessage2)
                    Exit Sub
                Else
                    'createme
                    Dim myIp() As String = MyHTTPSocket.RemoteEndPoint.ToString.Split(":")
                    SQL.InsertSQL([String].Format("INSERT INTO adb_accounts (account, password, email, joindate, last_ip) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", uName.ToUpper, uPass.ToUpper, uEmail.ToUpper, Format(Now, "yyyy-MM-dd"), myIp(0)))
                    If SQL.QuerySQL([String].Format("SELECT * FROM adb_accounts WHERE account = '{0}'", uName.ToUpper)) Then
                        Dim sHttpVersion As String = "HTTP/1.1"
                        Dim sMimeType As String = GetMimeType(FileSend)

                        If FileSend.EndsWith(".htm") Then LastHTMFile = FileSend
                        If FileSend.EndsWith(".html") Then LastHTMFile = FileSend

                        Dim bytes() As Byte = GetFileData(RootFolder + "/" + FileSend, uName, uPass, uEmail, "")

                        SendHeader(sHttpVersion, sMimeType, bytes.Length, " 200 OK")
                        SendToBrowser(bytes)
                    Else
                        'unknowen error
                        LoginCreateError("newaccount.html", sErrorMessage1 + "Sorry, there has been an unknowen error with the database." + sErrorMessage2)
                        Exit Sub
                    End If
                End If
            End Sub
#End Region

#Region "HTTP Login and Create Error sending 100%"
            Private Sub LoginCreateError(ByVal PrevHTM As String, ByVal erMessage As String)
                Dim sHttpVersion As String = "HTTP/1.1"
                Dim sMimeType As String = GetMimeType(PrevHTM)
                Dim bytes() As Byte = GetFileData(RootFolder + "/" + PrevHTM, uName, uPass, uEmail, erMessage)

                SendHeader(sHttpVersion, sMimeType, bytes.Length, " 200 OK")
                SendToBrowser(bytes)
            End Sub
#End Region

            Private Sub HandleGET(ByVal bReceive() As Byte)
                Dim sPhysicalFilePath As String = ""
                Dim sBuffer As String = Encoding.ASCII.GetString(bReceive)
                Dim iStartPos As Integer = 0
                Dim sRequest, sDirName, sRequestedFile, sErrorMessage, sLocalDir As String

                '// Look for HTTP request
                iStartPos = sBuffer.IndexOf("HTTP", 1)

                '// Get the HTTP text and version e.g. it will return "HTTP/1.1"
                Dim sHttpVersion As String = sBuffer.Substring(iStartPos, 8)

                '// Extract the Requested Type and Requested file/directory
                sRequest = sBuffer.Substring(0, iStartPos - 1)

                Console.WriteLine("File Requested : " + sRequest)

                '//Replace backslash with Forward Slash, if Any
                sRequest.Replace("\\", "/")

                '//If file name is not supplied add forward slash to indicate 
                '//that it is a directory and then we will look for the 
                '//default file name..
                If ((sRequest.IndexOf(".") < 1) And (Not sRequest.EndsWith("/"))) Then
                    sRequest = sRequest + "/"
                End If

                '//Extract the requested file name
                iStartPos = sRequest.LastIndexOf("/") + 1
                sRequestedFile = sRequest.Substring(iStartPos)
                If sRequestedFile = "" Then
                    sRequestedFile = "index.html"
                End If
                If sRequestedFile.EndsWith(".htm") Then LastHTMFile = sRequestedFile
                If sRequestedFile.EndsWith(".html") Then LastHTMFile = sRequestedFile
                If sRequestedFile.EndsWith(".php") Then LastPHPFile = sRequestedFile

                '//Extract The directory Name
                sDirName = sRequest.Substring(sRequest.IndexOf("/"), sRequest.LastIndexOf("/") - 3)

                sLocalDir = RootFolder

                '//If The file name is not supplied then look in the default file list
                If (sRequestedFile.Length = 0) Then

                    If (sRequestedFile = "") Then
                        sErrorMessage = "<H2>Error! No Default File Name Specified was specified!</H2>"
                        SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found")
                        SendToBrowser(sErrorMessage)

                        MyHTTPSocket.Close()
                        Return
                    End If
                End If

                Dim sMimeType As String = GetMimeType(sRequestedFile)

                '//Build the physical path
                sPhysicalFilePath = sLocalDir + sDirName + sRequestedFile

                If (File.Exists(sPhysicalFilePath) = False) Then
                    sErrorMessage = "<H2>404 Error! File Does Not Exist...</H2>"
                    SendHeader(sHttpVersion, "", sErrorMessage.Length, " 404 Not Found")
                    SendToBrowser(sErrorMessage)

                    ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Red)
                    Console.WriteLine("File Not found [" & sPhysicalFilePath & "]")
                    ConsoleColor.SetConsoleColor()
                Else
                    '
                    Dim bytes() As Byte = GetFileData(sPhysicalFilePath, uName, uPass, uEmail, "..")
                    Dim totbytes As Integer = bytes.Length

                    SendHeader(sHttpVersion, sMimeType, totbytes, " 200 OK")
                    SendToBrowser(bytes)
                End If
            End Sub

            Private Function GetFileData(ByVal HTTPFile As String, ByVal uName As String, ByVal uPass As String, ByVal uEmail As String, ByVal sError As String) As Byte()
                Dim tmp() As Byte
                Dim sTmp As String
                Dim fs As FileStream = New FileStream(HTTPFile, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim reader As BinaryReader = New BinaryReader(fs)
                tmp = reader.ReadBytes(fs.Length)
                reader.Close()
                fs.Close()

                'non txt files
                If HTTPFile.EndsWith(".jpg") Then Return tmp
                If HTTPFile.EndsWith(".jpeg") Then Return tmp
                If HTTPFile.EndsWith(".gif") Then Return tmp
                If HTTPFile.EndsWith(".png") Then Return tmp

                sTmp = Encoding.ASCII.GetString(tmp)

                Dim tTim As String = ""
                Dim tNol As Integer = 0
                Dim tGen As String = ""
                Dim tBuf As String = ""
                If HTTPFile.ToLower.EndsWith("gpstracking.html") Then
                    Dim x As New GPSWorldTracking
                    x.get_player_pins(tTim, tNol, tBuf)
                End If

                sTmp = Replacer(sTmp, uName, uPass, uEmail, sError, tNol.ToString, tBuf, tTim)

                Return Encoding.ASCII.GetBytes(sTmp)
            End Function

            Private Function Replacer(ByRef inBuf As String, _
                                      ByVal uName As String, _
                                      ByVal uPass As String, _
                                      ByVal uEmail As String, _
                                      ByVal sError As String, _
                                      ByVal sCount As String, _
                                      ByVal sPeople As String, _
                                      ByVal sGenerator As String) As String
                Dim outbuf As String = inBuf
                outbuf = outbuf.Replace("%%user%%", uName)
                outbuf = outbuf.Replace("%%pass%%", uPass)
                outbuf = outbuf.Replace("%%email%%", uEmail)
                outbuf = outbuf.Replace("%%error%%", sError)
                outbuf = outbuf.Replace("%%count%%", sCount)
                outbuf = outbuf.Replace("%%people%%", sPeople)
                outbuf = outbuf.Replace("%%generator%%", sGenerator)
                '%%count%%
                '%%people%%
                '%%generator%%
                Return outbuf
            End Function

            Private Sub SendHeader(ByVal sHttpVersion As String, ByVal sMIMEHeader As String, ByVal iTotBytes As Integer, ByVal sStatusCode As String)
                Dim sBuffer As String = ""

                '// if Mime type is not provided set default to text/html
                If (sMIMEHeader.Length = 0) Then
                    sMIMEHeader = "text/html"  '// Default Mime Type is text/html
                End If

                sBuffer = sBuffer + sHttpVersion + sStatusCode + vbCrLf
                sBuffer = sBuffer + "Server: MyWebServer-b" + vbCrLf
                sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + vbCrLf
                sBuffer = sBuffer + "Accept-Ranges: bytes"
                sBuffer = sBuffer + "Content-Length: " + iTotBytes.ToString + vbCrLf + vbCrLf

                Dim bSendData() As Byte = Encoding.ASCII.GetBytes(sBuffer)
                SendToBrowser(bSendData)

            End Sub

            Private Sub SendToBrowser(ByVal sData As String)
                SendToBrowser(Encoding.ASCII.GetBytes(sData))
            End Sub

            Private Sub SendToBrowser(ByVal bSendData() As Byte)
                Dim numBytes As Integer = 0
                Try
                    If (MyHTTPSocket.Connected) Then
                        numBytes = MyHTTPSocket.Send(bSendData, bSendData.Length, 0)
                        If (numBytes = -1) Then
                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Red)
                            Console.WriteLine("Socket Error cannot Send Packet")
                            ConsoleColor.SetConsoleColor()
                        Else
                            ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                            Console.WriteLine("No. of bytes sent " + numBytes.ToString)
                            ConsoleColor.SetConsoleColor()
                        End If
                    Else
                        ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.LightYellow)
                        Console.WriteLine("Connection Dropped....")
                        ConsoleColor.SetConsoleColor()
                    End If
                Catch e As Exception
                    ConsoleColor.SetConsoleColor(ConsoleColor.ForegroundColors.Red)
                    Console.WriteLine("Error Occurred : " + e.ToString)
                    ConsoleColor.SetConsoleColor()
                End Try
            End Sub
            Private Function GetMimeType(ByVal fileName As String) As String
                If (fileName.EndsWith(".htm") Or fileName.EndsWith(".html")) Then
                    Return "text/html"
                ElseIf (fileName.EndsWith(".jpg") Or fileName.EndsWith(".jpeg")) Then
                    Return "image/jpeg"
                ElseIf (fileName.EndsWith(".gif")) Then
                    Return "image/gif"
                ElseIf (fileName.EndsWith(".txt")) Then
                    Return "text/plain"
                Else
                    Return "application/octet-stream"
                End If
            End Function
        End Class
    End Module
End Namespace