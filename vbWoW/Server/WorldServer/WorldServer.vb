' 
' Copyright (C) 2005-2007 vbWoW <http://www.vbwow.org/>
'
' This program is free software; you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation; either version 2 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
'

Imports System.Threading
Imports System.Net.Sockets
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices

Imports vbWoW.Database
Imports vbWoW.Filebase
Imports vbWoW.Logbase.BaseWriter


'WARNING: Must compile with set HANDLED_MAP_ID
Public Module WS_Main

#Region "Global.Variables"
    'Players' containers
    Public CLIENTs As New ArrayList
    Public CHARACTERS As New Hashtable
    Public charactersLock_ As ReaderWriterLock = New ReaderWriterLock

    'Worlds containers    
    Public WORLD_CREATUREs_NOTSYNC As New Hashtable
    Public WORLD_CREATUREs As Hashtable = Hashtable.Synchronized(WORLD_CREATUREs_NOTSYNC)
    Public WORLD_GAMEOBJECTs As New Hashtable
    Public WORLD_ITEMs As New Hashtable

    'Database's containers - READONLY
    Public ITEMDatabase As New Hashtable
    Public CREATURESDatabase As New Hashtable
    Public GAMEOBJECTSDatabase As New Hashtable

    'Other
    Public CHAT_CHANNELs As New Hashtable
    Public CHARACTER_NAMEs As New Hashtable
    Public ItemGUIDCounter As Long = GUID_ITEM
    Public CreatureGUIDCounter As Long = GUID_UNIT
    Public GameObjectsGUIDCounter As Long = GUID_GAMEOBJECT
    Public CorpseGUIDCounter As Long = GUID_CORPSE


    'System Things...
    Public ConsoleColor As New ConsoleColorClass
    Public Log As New vbWoW.Logbase.BaseWriter
    Public PacketHandlers As New Hashtable
    Public PacketThreadPool As ThreadPool
    Public Rnd As New Random
    Public StartedTime As Long = DateTime.Now.Ticks
    Delegate Sub HandlePacket(ByRef Packet As PacketClass, ByRef Client As ClientClass)

    'Scripting Support
    Public AreaTriggers As ScriptedObject
    Public AI As ScriptedObject
    Public CharacterCreation As ScriptedObject


#End Region
#Region "Global.Config"
    Public Config As XMLConfigFile
    <XmlRoot(ElementName:="WorldServer")> _
    Public Class XMLConfigFile
        <XmlElement(ElementName:="WSPort")> Public WSPort As Integer = 4720
        <XmlElement(ElementName:="WSHost")> Public WSHost As String = "127.0.0.1"

        <XmlElement(ElementName:="ServerLimit")> Public ServerLimit As Integer = 10
        <XmlElement(ElementName:="XPRate")> Public XPRate As Single = 1.0
        <XmlElement(ElementName:="ManaRegenerationRate")> Public ManaRegenerationRate As Single = 1.0
        <XmlElement(ElementName:="HealthRegenerationRate")> Public HealthRegenerationRate As Single = 1.0
        <XmlElement(ElementName:="GlobalAuction")> Public GlobalAuction As Boolean = False

        <XmlElement(ElementName:="LogType")> Public LogType As String = "COLORCONSOLE"
        <XmlElement(ElementName:="LogLevel")> Public LogLevel As LogType = vbWoW.Logbase.BaseWriter.LogType.NETWORK
        <XmlElement(ElementName:="LogConfig")> Public LogConfig As String = ""

        <XmlElement(ElementName:="SQLUser")> Public SQLUser As String = "awowe"
        <XmlElement(ElementName:="SQLPass")> Public SQLPass As String = "12345"
        <XmlElement(ElementName:="SQLHost")> Public SQLHost As String = "localhost"
        <XmlElement(ElementName:="SQLPort")> Public SQLPort As String = "3306"
        <XmlElement(ElementName:="SQLDBName")> Public SQLDBName As String = "awowedb"
        <XmlElement(ElementName:="SQLDBType")> Public SQLDBType As SQL.DB_Type = SQL.DB_Type.MySQL

        <XmlArray(ElementName:="ScriptsCompiler"), XmlArrayItem(GetType(String), ElementName:="Include")> Public CompilerInclude As New ArrayList
    End Class

    Public Sub LoadConfig()
        Try
            Console.Write("[{0}] Loading Configuration..", Format(TimeOfDay, "hh:mm:ss"))

            Config = New XMLConfigFile
            Console.Write("....")

            Dim oXS As XmlSerializer = New XmlSerializer(GetType(XMLConfigFile))

            Console.Write("...")
            Dim oStmR As StreamReader
            oStmR = New StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location()) + "\\vbWoW.WorldServer.xml")
            Config = oXS.Deserialize(oStmR)
            oStmR.Close()


            Console.WriteLine(".[done]")


            'DONE: Setting SQL Connection
            Database.SQLDBName = Config.SQLDBName
            Database.SQLHost = Config.SQLHost
            Database.SQLPort = Config.SQLPort
            Database.SQLUser = Config.SQLUser
            Database.SQLPass = Config.SQLPass
            Database.SQLTypeServer = Config.SQLDBType

            'DONE: Creating logger
            Log.CreateLog(Config.LogType, Config.LogConfig, Log)
            Log.LogLevel = Config.LogLevel

        Catch e As Exception
            Console.WriteLine(e.ToString)
        End Try
    End Sub
#End Region

#Region "WS.DataAccess"
    Public Database As New SQL
    Public Sub SLQEventHandler(ByVal MessageID As SQL.EMessages, ByVal OutBuf As String)
        Select Case MessageID
            Case SQL.EMessages.ID_Error
                Log.WriteLine(LogType.FAILED, OutBuf)
            Case SQL.EMessages.ID_Message
                Log.WriteLine(LogType.SUCCESS, OutBuf)
        End Select
    End Sub
#End Region
#Region "WS.Sockets"
    Public WS As WorldServerClass
    Class WorldServerClass
        <CLSCompliant(False)> _
        Public _flagStopListen As Boolean = False
        Private lstHost As Net.IPAddress = Net.IPAddress.Parse(Config.WSHost)
        Private lstConnection As TcpListener
        Private lstThreadPool As ThreadPool

        Public Sub New()
            Try
                lstConnection = New TcpListener(lstHost, Config.WSPort)
                lstConnection.Start()
                Dim RSListenThread As Thread
                RSListenThread = New Thread(AddressOf AcceptConnection)
                RSListenThread.Name = "World Server, Listening"
                RSListenThread.Start()
                Log.WriteLine(LogType.SUCCESS, "Listening on {0} on port {1}", lstHost, Config.WSPort)
            Catch e As Exception
                Console.WriteLine()
                Log.WriteLine(LogType.FAILED, "Error in {1}: {0}.", e.Message, e.Source)
            End Try
        End Sub
        Protected Sub AcceptConnection()
            Do While Not _flagStopListen
                Thread.Sleep(CONNETION_SLEEP_TIME)
                If lstConnection.Pending() Then
                    Dim Client As New ClientClass
                    Client.Index = CLIENTs.Add(Client)
                    Client.Socket = lstConnection.AcceptSocket
                    lstThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf Client.Process))
                End If
            Loop
        End Sub
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            _flagStopListen = True
            lstConnection.Stop()
        End Sub
    End Class
#End Region
#Region "WS.Analyzer"

    Public Enum ExpansionLevel As Byte
        NORMAL = 0          'WoW
        EXPANSION_1 = 1     'WoW: Burning Crusade
    End Enum
    Class ClientClass
        Implements IDisposable

        Public Socket As Socket = Nothing
        Public Index As Integer = 0

        Public IP As Net.IPAddress = Net.IPAddress.Parse("0.0.0.0")
        Public Port As Int32 = 0
        Public Account As String = ""
        Public Access As AccessLevel = WS_Commands.AccessLevel.Player
        Public Expansion As ExpansionLevel = ExpansionLevel.NORMAL
        Public Character As CharacterObject

        Public SS_Hash() As Byte
        Public Encryption As Boolean = False

        Public DEBUG_CONNECTION As Boolean = False
        Private Key() As Byte = {0, 0, 0, 0}
        Private Buffer() As Byte = {0}

        Public Sub OnData()
            Dim PacketBuffer As New PacketClass(Buffer)

            Try
                If Encryption Then Decode(PacketBuffer.Data, PacketBuffer.Length)
                'DumpPacket(packet.Data, Me)

                Dim packets As New Queue
                While PacketBuffer.Length < PacketBuffer.Data.Length - 2
                    '2+ in 1 packet
                    Dim tmpbuff() As Byte
                    ReDim Preserve tmpbuff(PacketBuffer.Data.Length - 1 - PacketBuffer.Length - 2)
                    Array.Copy(PacketBuffer.Data, PacketBuffer.Length + 2, tmpbuff, 0, PacketBuffer.Data.Length - PacketBuffer.Length - 2)
                    ReDim Preserve PacketBuffer.Data(PacketBuffer.Length + 1)
                    Dim packet As New PacketClass(PacketBuffer.Data)
                    packets.Enqueue(packet)
                    PacketBuffer.Data = tmpbuff
                    Decode(PacketBuffer.Data, PacketBuffer.Length)
                End While
                packets.Enqueue(PacketBuffer)



                For Each packet As PacketClass In packets
                    If PacketHandlers.ContainsKey(packet.OpCode) = True Then
                        Try
                            PacketHandlers(packet.OpCode).Invoke(packet, Me)
                        Catch e As Exception 'TargetInvocationException
                            Log.WriteLine(LogType.FAILED, "Opcode handler {2}:{3} caused an error:{1}{0}", e.Message, vbNewLine, packet.OpCode, CType(packet.OpCode, OPCODES))
                        End Try
                    Else
                        Log.WriteLine(LogType.WARNING, "[{0}:{1}] Unknown Opcode 0x{2:X} [DataLen={3} {4}]", IP, Port, CType(packet.OpCode, Integer), packet.Data.Length, CType(packet.OpCode, OPCODES))
                        DumpPacket(packet.Data, Me)
                    End If
                Next
            Catch Err As Exception
                Log.WriteLine(LogType.FAILED, "Connection from [{0}:{1}] cause error {2}{3}", IP, Port, Err.ToString, vbNewLine)
                Me.Delete()
            End Try
            PacketBuffer.Dispose()
        End Sub
        Public Sub Process(ByVal state As Object)
            IP = CType(Socket.RemoteEndPoint, IPEndPoint).Address
            Port = CType(Socket.RemoteEndPoint, IPEndPoint).Port

            Dim bytes As Integer

            Log.WriteLine(LogType.NETWORK, "Incoming connection from [{0}:{1}]", IP, Port)

            'Send SMSG_AUTH_CHALLENGE
            OnConnect(Me)

            While Not WS._flagStopListen
                While Socket.Connected AndAlso Socket.Available > 0
                    ReDim Buffer(Socket.Available - 1)
                    bytes = Socket.Receive(Buffer, Buffer.Length, 0)

                    OnData()
                End While

                Thread.Sleep(CONNETION_SLEEP_TIME)

                Try
                    If Not Socket.Connected Then Exit While
                    If (Socket.Poll(100, SelectMode.SelectRead)) And (Socket.Available = 0) Then Exit While
                Catch
                    Exit While
                End Try
            End While

            Socket.Close()
            Log.WriteLine(LogType.NETWORK, "Connection from [{0}:{1}] closed", IP, Port)
            Me.Delete()
        End Sub

        Public Sub Send(ByRef data() As Byte)
            SyncLock Me
                Try
                    If Encryption Then Encode(data)
                    Dim i As Integer = Socket.Send(data, 0, data.Length, SocketFlags.None)

#If DEBUG Then
                    Log.WriteLine(LogType.NETWORK, "[{0}:{1}] Data sent, result code={2}", IP, Port, i)
#End If

                Catch Err As Exception
                    If DEBUG_CONNECTION Then Exit Sub
                    Log.WriteLine(LogType.CRITICAL, "Connection from [{0}:{1}] cause error {3}{4}", IP, Port, Err.ToString, vbNewLine)
                    Me.Delete()
                End Try
            End SyncLock
        End Sub
        Public Sub Send(ByRef packet As PacketClass)
            If packet Is Nothing Then Throw New ApplicationException("Packet doesn't contain data!")
            SyncLock Me
                Try
                    Dim OPCODE As Integer = packet.OpCode

                    If Encryption Then Encode(packet.Data)
                    Dim i As Integer = Socket.Send(packet.Data, 0, packet.Data.Length, SocketFlags.None)

#If DEBUG Then
                    Log.WriteLine(LogType.NETWORK, "[{0}:{1}] Data sent, result code={2}, opcode={3}", IP, Port, i, OPCODE)
#End If

                    packet.Dispose()
                Catch Err As Exception
                    If DEBUG_CONNECTION Then Exit Sub
                    Log.WriteLine(LogType.CRITICAL, "Connection from [{0}:{1}] cause error {3}{4}", IP, Port, Err.ToString, vbNewLine)
                    Me.Delete()
                End Try
            End SyncLock
        End Sub
        Public Sub SendMultiplyPackets(ByRef packet As PacketClass)
            If packet Is Nothing Then Throw New ApplicationException("Packet doesn't contain data!")
            SyncLock Me
                Try
                    Dim data() As Byte
                    data = packet.Data.Clone

                    Dim OPCODE As Integer = packet.OpCode

                    If Encryption Then Encode(data)
                    Dim i As Integer = Socket.Send(data, 0, data.Length, SocketFlags.None)

#If DEBUG Then
                    Log.WriteLine(LogType.NETWORK, "[{0}:{1}] Data sent, result code={2}, opcode={3}", IP, Port, i, OPCODE)
#End If

                    'packet.Dispose()
                Catch Err As Exception
                    If DEBUG_CONNECTION Then Exit Sub
                    Log.WriteLine(LogType.CRITICAL, "Connection from [{0}:{1}] cause error {3}{4}", IP, Port, Err.ToString, vbNewLine)
                    Me.Delete()
                End Try
            End SyncLock
        End Sub
        Public Sub ASyncSend(ByRef packet As PacketClass)
            SyncLock Me
                Try
                    If Encryption Then Encode(packet.Data)
                    Socket.BeginSend(packet.Data, 0, packet.Data.Length, SocketFlags.None, AddressOf ASyncComplete, Nothing)
                    packet.Dispose()
                Catch Err As Exception
                    If DEBUG_CONNECTION Then Exit Sub
                    Log.WriteLine(LogType.CRITICAL, "Connection from [{0}:{1}] cause error {3}{4}", IP, Port, Err.ToString, vbNewLine)
                    Me.Delete()
                End Try
            End SyncLock
        End Sub
        Public Sub ASyncSendMultiplyPackets(ByRef packet As PacketClass)
            SyncLock Me
                Try
                    Dim data() As Byte
                    data = packet.Data.Clone

                    If Encryption Then Encode(data)
                    Socket.BeginSend(data, 0, data.Length, SocketFlags.None, AddressOf ASyncComplete, Nothing)

                Catch Err As Exception
                    If DEBUG_CONNECTION Then Exit Sub
                    Log.WriteLine(LogType.CRITICAL, "Connection from [{0}:{1}] cause error {3}{4}", IP, Port, Err.ToString, vbNewLine)
                    Me.Delete()
                End Try
            End SyncLock
        End Sub
        Public Sub ASyncComplete(ByVal ar As IAsyncResult)
            Me.Socket.EndSend(ar)
        End Sub
        Private Sub Dispose() Implements System.IDisposable.Dispose
            Log.WriteLine(LogType.NETWORK, "Connection from [{0}:{1}] disposed", IP, Port)
            If Not Me.Character Is Nothing Then
                Me.Character.Client = Nothing
                Me.Character.Dispose()
            End If
        End Sub
        Public Sub Delete()
            On Error Resume Next
            Me.Socket.Close()
            CLIENTs.Remove(Me)
            If Not Me.Character Is Nothing Then
                Me.Character.Client = Nothing
                Me.Character.Dispose()
            End If
            Me.Dispose()
        End Sub

        Public Sub Decode_Old(ByRef data() As Byte, ByRef length As Integer)
            Dim i As Integer
            For i = 0 To 6 - 1
                Dim num2 As Byte = Me.Key(0)
                Me.Key(0) = data(i)
                Dim num3 As Byte = data(i)
                num3 = CType((num3 - num2), Byte)
                Dim num4 As Byte = Me.Key(1)
                num2 = SS_Hash(num4)
                num2 = CType((num2 Xor num3), Byte)
                data(i) = num2
                num2 = Me.Key(1)
                num2 = CType((num2 + 1), Byte)
                Me.Key(1) = CType((num2 Mod 40), Byte)
            Next i
        End Sub
        Public Sub Decode(ByRef data() As Byte, ByRef length As Integer)
            Dim i As Integer
            Dim tmp As Integer

            For i = 0 To 6 - 1
                tmp = data(i)
                data(i) = CByte((SS_Hash(Me.Key(1)) Xor CByte((data(i) - Me.Key(0)))))
                Me.Key(0) = tmp
                Me.Key(1) = CByte((CByte((Me.Key(1) + 1)) Mod 40))
            Next i
        End Sub
        Public Sub Decode_NotUsed(ByRef data() As Byte, ByRef offset As Integer, ByRef length As Integer)
            Dim buffer1 As Byte() = Me.SS_Hash
            Dim num1 As Integer
            For num1 = 0 To 6 - 1
                Dim num2 As Byte = Me.Key(0)
                Me.Key(0) = data((offset + num1))
                Dim num3 As Byte = data((offset + num1))
                num3 = CType((num3 - num2), Byte)
                Dim num4 As Byte = Me.Key(1)
                num2 = buffer1(num4)
                num2 = CType((num2 Xor num3), Byte)
                data((num1 + offset)) = num2
                num2 = Me.Key(1)
                num2 = CType((num2 + 1), Byte)
                Me.Key(1) = CType((num2 Mod 40), Byte)
            Next num1
        End Sub

        Public Sub Encode_Old(ByRef data() As Byte)
            If (Me.SS_Hash Is Nothing) Then
                Log.WriteLine(LogType.FAILED, "[{0}:{1}] SUB Encode: Missing SS_Hash for that character", IP, Port)
            Else
                Dim num1 As Integer
                For num1 = 0 To 4 - 1
                    Dim num2 As Byte = Me.Key(3)
                    num2 = CType((SS_Hash(num2) Xor data(num1)), Byte)
                    Dim num3 As Byte = Me.Key(2)
                    num2 = CType((num2 + num3), Byte)
                    data(num1) = num2
                    Me.Key(2) = num2
                    num2 = Me.Key(3)
                    num2 = CType((num2 + 1), Byte)
                    Me.Key(3) = CType((num2 Mod 40), Byte)
                Next num1
            End If
        End Sub
        Public Sub Encode(ByRef data() As Byte)
            Dim i As Integer
            For i = 0 To 4 - 1
                data(i) = CByte((CByte((SS_Hash(Me.Key(3)) Xor data(i))) + Me.Key(2)))
                Me.Key(2) = data(i)
                Me.Key(3) = CByte(CByte(Me.Key(3) + 1) Mod 40)
            Next i
        End Sub

        Public Sub EnQueue(ByVal state As Object)
            While CHARACTERS.Count > Config.ServerLimit
                If Not Me.Socket.Connected Then Exit Sub

                Dim response_full As New PacketClass(OPCODES.SMSG_AUTH_RESPONSE)
                response_full.AddInt8(AuthResponseCodes.AUTH_WAIT_QUEUE)
                response_full.AddInt32(CLIENTs.Count - CHARACTERS.Count)            'amount of players in queue
                Me.Send(response_full)

                Log.WriteLine(LogType.INFORMATION, "[{1}:{2}] AUTH_WAIT_QUEUE: Server limit reached!", Me.IP, Me.Port)
                Thread.Sleep(6000)
            End While
            SendLoginOK(Me)
        End Sub
    End Class
#End Region

#Region "WS.HelperFunctions"
    Public Function HaveFlag(ByVal value As Integer, ByVal flagPos As Byte) As Boolean
        value = value >> flagPos
        value = value Mod 2

        If value = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function HaveFlags(ByVal value As Integer, ByVal flags As Integer) As Boolean
        Return ((value And flags) = flags)
    End Function
    Public Sub SetFlag(ByRef value As Integer, ByVal flagPos As Byte, ByVal flagValue As Boolean)
        If flagValue Then
            value = (value Or (CType(1, Integer) << flagPos))
        Else
            value = (value And ((CType(0, Integer) << flagPos) And &HFFFFFFFF))
        End If
    End Sub

    Public Function GetTimestamp(ByVal fromDateTime As DateTime) As Integer
        Dim startDate As DateTime = #1/1/1970#
        Dim timeSpan As System.TimeSpan

        timeSpan = fromDateTime.Subtract(startDate)
        Return CType(Math.Abs(timeSpan.TotalSeconds()), Integer)
    End Function
    Public Function GetDateFromTimestamp(ByVal unixTimestamp As Integer) As DateTime
        Dim timeSpan As System.TimeSpan
        Dim startDate As Date = #1/1/1970#

        If unixTimestamp = 0 Then Return startDate

        timeSpan = New System.TimeSpan(0, 0, unixTimestamp)
        Return startDate.Add(timeSpan)
    End Function

    Public Sub OnConnect(ByRef Client As ClientClass)
        Dim data As New PacketClass(OPCODES.SMSG_AUTH_CHALLENGE)
        data.AddInt8(&H71)
        data.AddInt8(&H2C)
        data.AddInt8(&H73)
        data.AddInt8(&H88)
        Client.Send(data)
    End Sub
    Public Sub IntializePacketHandlers()
        PacketHandlers(OPCODES.CMSG_MOVE_TIME_SKIPPED) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_NEXT_CINEMATIC_CAMERA) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_COMPLETE_CINEMATIC) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REQUEST_ACCOUNT_DATA) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_MOVE_ROOT_ACK) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_MOVE_UNROOT_ACK) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MOVE_WATER_WALK_ACK) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_TELEPORT_ACK) = CType(AddressOf OnUnhandledPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REQUEST_RAID_INFO) = CType(AddressOf OnUnhandledPacket, HandlePacket)

        PacketHandlers(OPCODES.CMSG_PING) = CType(AddressOf On_CMSG_PING, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUTH_SESSION) = CType(AddressOf On_CMSG_AUTH_SESSION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_EXPANSION_INFO) = CType(AddressOf On_CMSG_EXPANSION_INFO, HandlePacket)

        PacketHandlers(OPCODES.CMSG_CHAR_ENUM) = CType(AddressOf On_CMSG_CHAR_ENUM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHAR_CREATE) = CType(AddressOf On_CMSG_CHAR_CREATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHAR_DELETE) = CType(AddressOf On_CMSG_CHAR_DELETE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PLAYER_LOGIN) = CType(AddressOf On_CMSG_PLAYER_LOGIN, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHAR_RENAME) = CType(AddressOf On_CMSG_CHAR_RENAME, HandlePacket)

        PacketHandlers(OPCODES.CMSG_UPDATE_ACCOUNT_DATA) = CType(AddressOf On_CMSG_UPDATE_ACCOUNT_DATA, HandlePacket)

        PacketHandlers(OPCODES.CMSG_SET_LOOKING_FOR_GROUP_AUTOADD) = CType(AddressOf On_CMSG_SET_LOOKING_FOR_GROUP_AUTOADD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_LOOKING_FOR_GROUP_AUTOJOIN) = CType(AddressOf On_CMSG_SET_LOOKING_FOR_GROUP_AUTOJOIN, HandlePacket)

        PacketHandlers(OPCODES.CMSG_FRIEND_LIST) = CType(AddressOf On_CMSG_FRIEND_LIST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ADD_FRIEND) = CType(AddressOf On_CMSG_ADD_FRIEND, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ADD_IGNORE) = CType(AddressOf On_CMSG_ADD_IGNORE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_DEL_FRIEND) = CType(AddressOf On_CMSG_DEL_FRIEND, HandlePacket)
        PacketHandlers(OPCODES.CMSG_DEL_IGNORE) = CType(AddressOf On_CMSG_DEL_IGNORE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_NAME_QUERY) = CType(AddressOf On_CMSG_NAME_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MESSAGECHAT) = CType(AddressOf On_CMSG_MESSAGECHAT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_JOIN_CHANNEL) = CType(AddressOf On_CMSG_JOIN_CHANNEL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LEAVE_CHANNEL) = CType(AddressOf On_CMSG_LEAVE_CHANNEL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_LIST) = CType(AddressOf On_CMSG_CHANNEL_LIST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_PASSWORD) = CType(AddressOf On_CMSG_CHANNEL_PASSWORD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_SET_OWNER) = CType(AddressOf On_CMSG_CHANNEL_SET_OWNER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_OWNER) = CType(AddressOf On_CMSG_CHANNEL_OWNER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_MODERATOR) = CType(AddressOf On_CMSG_CHANNEL_MODERATOR, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_UNMODERATOR) = CType(AddressOf On_CMSG_CHANNEL_UNMODERATOR, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_MUTE) = CType(AddressOf On_CMSG_CHANNEL_MUTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_UNMUTE) = CType(AddressOf On_CMSG_CHANNEL_UNMUTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_KICK) = CType(AddressOf On_CMSG_CHANNEL_KICK, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_INVITE) = CType(AddressOf On_CMSG_CHANNEL_INVITE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_BAN) = CType(AddressOf On_CMSG_CHANNEL_BAN, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_UNBAN) = CType(AddressOf On_CMSG_CHANNEL_UNBAN, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_ANNOUNCEMENTS) = CType(AddressOf On_CMSG_CHANNEL_ANNOUNCEMENTS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CHANNEL_MODERATE) = CType(AddressOf On_CMSG_CHANNEL_MODERATE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_LOGOUT_REQUEST) = CType(AddressOf On_CMSG_LOGOUT_REQUEST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOGOUT_CANCEL) = CType(AddressOf On_CMSG_LOGOUT_CANCEL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PLAYER_LOGOUT) = CType(AddressOf On_CMSG_PLAYER_LOGOUT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CANCEL_TRADE) = CType(AddressOf On_CMSG_CANCEL_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BEGIN_TRADE) = CType(AddressOf On_CMSG_BEGIN_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_UNACCEPT_TRADE) = CType(AddressOf On_CMSG_UNACCEPT_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ACCEPT_TRADE) = CType(AddressOf On_CMSG_ACCEPT_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_INITIATE_TRADE) = CType(AddressOf On_CMSG_INITIATE_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_TRADE_GOLD) = CType(AddressOf On_CMSG_SET_TRADE_GOLD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_TRADE_ITEM) = CType(AddressOf On_CMSG_SET_TRADE_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CLEAR_TRADE_ITEM) = CType(AddressOf On_CMSG_CLEAR_TRADE_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_IGNORE_TRADE) = CType(AddressOf On_CMSG_IGNORE_TRADE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BUSY_TRADE) = CType(AddressOf On_CMSG_BUSY_TRADE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_QUERY_TIME) = CType(AddressOf On_CMSG_QUERY_TIME, HandlePacket)
        PacketHandlers(OPCODES.CMSG_WHO) = CType(AddressOf On_CMSG_WHO, HandlePacket)

        PacketHandlers(OPCODES.CMSG_GMTICKET_GETTICKET) = CType(AddressOf On_CMSG_GMTICKET_GETTICKET, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GMTICKET_CREATE) = CType(AddressOf On_CMSG_GMTICKET_CREATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GMTICKET_SYSTEMSTATUS) = CType(AddressOf On_CMSG_GMTICKET_SYSTEMSTATUS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GMTICKET_DELETETICKET) = CType(AddressOf On_CMSG_GMTICKET_DELETETICKET, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GMTICKET_UPDATETEXT) = CType(AddressOf On_CMSG_GMTICKET_UPDATETEXT, HandlePacket)

        PacketHandlers(OPCODES.MSG_MOVE_START_FORWARD) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_BACKWARD) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_STRAFE_LEFT) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_STRAFE_RIGHT) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP_STRAFE) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_JUMP) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_TURN_LEFT) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_TURN_RIGHT) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP_TURN) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_PITCH_UP) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_PITCH_DOWN) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP_PITCH) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_SET_RUN_MODE) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_SET_WALK_MODE) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_SWIM) = CType(AddressOf OnStartSwim, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP_SWIM) = CType(AddressOf OnStopSwim, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_SET_FACING) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_SET_PITCH) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_FLY_MODE) = CType(AddressOf OnStopSwim, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_START_FLY) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_STOP_FLY) = CType(AddressOf OnMovementPacket, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MOVE_FALL_RESET) = CType(AddressOf On_CMSG_MOVE_FALL_RESET, HandlePacket)

        PacketHandlers(OPCODES.MSG_MOVE_HEARTBEAT) = CType(AddressOf On_MSG_MOVE_HEARTBEAT, HandlePacket)
        PacketHandlers(OPCODES.MSG_MOVE_FALL_LAND) = CType(AddressOf OnFallLand, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AREATRIGGER) = CType(AddressOf OnAreaTrigger, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ZONEUPDATE) = CType(AddressOf OnZoneUpdate, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_RUN_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_SWIM_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_TURN_RATE_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_FLY_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)
        PacketHandlers(OPCODES.CMSG_FORCE_FLY_BACK_SPEED_CHANGE_ACK) = CType(AddressOf OnChangeSpeed, HandlePacket)

        PacketHandlers(OPCODES.CMSG_STANDSTATECHANGE) = CType(AddressOf On_CMSG_STANDSTATECHANGE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_SELECTION) = CType(AddressOf On_CMSG_SET_SELECTION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REPOP_REQUEST) = CType(AddressOf On_CMSG_REPOP_REQUEST, HandlePacket)
        PacketHandlers(OPCODES.MSG_CORPSE_QUERY) = CType(AddressOf On_MSG_CORPSE_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SPIRIT_HEALER_ACTIVATE) = CType(AddressOf On_CMSG_SPIRIT_HEALER_ACTIVATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_RECLAIM_CORPSE) = CType(AddressOf On_CMSG_RECLAIM_CORPSE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_TUTORIAL_FLAG) = CType(AddressOf On_CMSG_TUTORIAL_FLAG, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TUTORIAL_CLEAR) = CType(AddressOf On_CMSG_TUTORIAL_CLEAR, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TUTORIAL_RESET) = CType(AddressOf On_CMSG_TUTORIAL_RESET, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_ACTION_BUTTON) = CType(AddressOf On_CMSG_SET_ACTION_BUTTON, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TOGGLE_HELM) = CType(AddressOf On_CMSG_TOGGLE_HELM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TOGGLE_CLOAK) = CType(AddressOf On_CMSG_TOGGLE_CLOAK, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MOUNTSPECIAL_ANIM) = CType(AddressOf On_CMSG_MOUNTSPECIAL_ANIM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_EMOTE) = CType(AddressOf On_CMSG_EMOTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TEXT_EMOTE) = CType(AddressOf On_CMSG_TEXT_EMOTE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_ITEM_QUERY_SINGLE) = CType(AddressOf On_CMSG_ITEM_QUERY_SINGLE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ITEM_NAME_QUERY) = CType(AddressOf On_CMSG_ITEM_NAME_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SETSHEATHED) = CType(AddressOf On_CMSG_SETSHEATHED, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SWAP_INV_ITEM) = CType(AddressOf On_CMSG_SWAP_INV_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SPLIT_ITEM) = CType(AddressOf On_CMSG_SPLIT_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUTOEQUIP_ITEM) = CType(AddressOf On_CMSG_AUTOEQUIP_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUTOSTORE_BAG_ITEM) = CType(AddressOf On_CMSG_AUTOSTORE_BAG_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SWAP_ITEM) = CType(AddressOf On_CMSG_SWAP_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_DESTROYITEM) = CType(AddressOf On_CMSG_DESTROYITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_READ_ITEM) = CType(AddressOf On_CMSG_READ_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PAGE_TEXT_QUERY) = CType(AddressOf On_CMSG_PAGE_TEXT_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_USE_ITEM) = CType(AddressOf On_CMSG_USE_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_OPEN_ITEM) = CType(AddressOf On_CMSG_OPEN_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_WRAP_ITEM) = CType(AddressOf On_CMSG_WRAP_ITEM, HandlePacket)

        PacketHandlers(OPCODES.CMSG_CREATURE_QUERY) = CType(AddressOf On_CMSG_CREATURE_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GOSSIP_HELLO) = CType(AddressOf On_CMSG_GOSSIP_HELLO, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GOSSIP_SELECT_OPTION) = CType(AddressOf On_CMSG_GOSSIP_SELECT_OPTION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_NPC_TEXT_QUERY) = CType(AddressOf On_CMSG_NPC_TEXT_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LIST_INVENTORY) = CType(AddressOf On_CMSG_LIST_INVENTORY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BUY_ITEM_IN_SLOT) = CType(AddressOf On_CMSG_BUY_ITEM_IN_SLOT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BUY_ITEM) = CType(AddressOf On_CMSG_BUY_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SELL_ITEM) = CType(AddressOf On_CMSG_SELL_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REPAIR_ITEM) = CType(AddressOf On_CMSG_REPAIR_ITEM, HandlePacket)

        PacketHandlers(OPCODES.CMSG_ATTACKSWING) = CType(AddressOf On_CMSG_ATTACKSWING, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ATTACKSTOP) = CType(AddressOf On_CMSG_ATTACKSTOP, HandlePacket)

        PacketHandlers(OPCODES.CMSG_GAMEOBJECT_QUERY) = CType(AddressOf On_CMSG_GAMEOBJECT_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GAMEOBJ_USE) = CType(AddressOf On_CMSG_GAMEOBJ_USE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_BATTLEFIELD_STATUS) = CType(AddressOf On_CMSG_BATTLEFIELD_STATUS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_ACTIVE_MOVER) = CType(AddressOf On_CMSG_SET_ACTIVE_MOVER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MEETINGSTONE_INFO) = CType(AddressOf On_CMSG_MEETINGSTONE_INFO, HandlePacket)
        PacketHandlers(OPCODES.CMSG_INSPECT) = CType(AddressOf On_CMSG_INSPECT, HandlePacket)
        PacketHandlers(OPCODES.MSG_INSPECT_HONOR_STATS) = CType(AddressOf On_MSG_INSPECT_HONOR_STATS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_PLAYER_TITLE) = CType(AddressOf On_CMSG_SET_PLAYER_TITLE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_GET_MAIL_LIST) = CType(AddressOf On_CMSG_GET_MAIL_LIST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SEND_MAIL) = CType(AddressOf On_CMSG_SEND_MAIL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_CREATE_TEXT_ITEM) = CType(AddressOf On_CMSG_MAIL_CREATE_TEXT_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ITEM_TEXT_QUERY) = CType(AddressOf On_CMSG_ITEM_TEXT_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_DELETE) = CType(AddressOf On_CMSG_MAIL_DELETE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_TAKE_ITEM) = CType(AddressOf On_CMSG_MAIL_TAKE_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_TAKE_MONEY) = CType(AddressOf On_CMSG_MAIL_TAKE_MONEY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_RETURN_TO_SENDER) = CType(AddressOf On_CMSG_MAIL_RETURN_TO_SENDER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_MAIL_MARK_AS_READ) = CType(AddressOf On_CMSG_MAIL_MARK_AS_READ, HandlePacket)
        PacketHandlers(OPCODES.MSG_QUERY_NEXT_MAIL_TIME) = CType(AddressOf On_MSG_QUERY_NEXT_MAIL_TIME, HandlePacket)

        PacketHandlers(OPCODES.CMSG_AUTOSTORE_LOOT_ITEM) = CType(AddressOf On_CMSG_AUTOSTORE_LOOT_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOOT_MONEY) = CType(AddressOf On_CMSG_LOOT_MONEY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOOT) = CType(AddressOf On_CMSG_LOOT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOOT_RELEASE) = CType(AddressOf On_CMSG_LOOT_RELEASE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_TAXINODE_STATUS_QUERY) = CType(AddressOf On_CMSG_TAXINODE_STATUS_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TAXIQUERYAVAILABLENODES) = CType(AddressOf On_CMSG_TAXIQUERYAVAILABLENODES, HandlePacket)
        PacketHandlers(OPCODES.CMSG_ACTIVATETAXI) = CType(AddressOf On_CMSG_ACTIVATETAXI, HandlePacket)

        PacketHandlers(OPCODES.CMSG_CAST_SPELL) = CType(AddressOf On_CMSG_CAST_SPELL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CANCEL_CAST) = CType(AddressOf On_CMSG_CANCEL_CAST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CANCEL_AURA) = CType(AddressOf On_CMSG_CANCEL_AURA, HandlePacket)
        PacketHandlers(OPCODES.CMSG_CANCEL_AUTO_REPEAT_SPELL) = CType(AddressOf On_CMSG_CANCEL_AUTO_REPEAT_SPELL, HandlePacket)

        PacketHandlers(OPCODES.CMSG_GROUP_INVITE) = CType(AddressOf On_CMSG_GROUP_INVITE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_CANCEL) = CType(AddressOf On_CMSG_GROUP_CANCEL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_ACCEPT) = CType(AddressOf On_CMSG_GROUP_ACCEPT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_DECLINE) = CType(AddressOf On_CMSG_GROUP_DECLINE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_UNINVITE) = CType(AddressOf On_CMSG_GROUP_UNINVITE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_UNINVITE_GUID) = CType(AddressOf On_CMSG_GROUP_UNINVITE_GUID, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_DISBAND) = CType(AddressOf On_CMSG_GROUP_DISBAND, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_RAID_CONVERT) = CType(AddressOf On_CMSG_GROUP_RAID_CONVERT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_ASSISTANT_LEADER) = CType(AddressOf On_CMSG_GROUP_ASSISTANT_LEADER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_CHANGE_SUB_GROUP) = CType(AddressOf On_CMSG_GROUP_CHANGE_SUB_GROUP, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_SWAP_SUB_GROUP) = CType(AddressOf On_CMSG_GROUP_SWAP_SUB_GROUP, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOOT_METHOD) = CType(AddressOf On_CMSG_LOOT_METHOD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_SET_MAIN) = CType(AddressOf On_CMSG_GROUP_SET_MAIN, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GROUP_SET_LEADER) = CType(AddressOf On_CMSG_GROUP_SET_LEADER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REQUEST_PARTY_MEMBER_STATS) = CType(AddressOf On_CMSG_REQUEST_PARTY_MEMBER_STATS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_LOOT_ROLL) = CType(AddressOf On_CMSG_LOOT_ROLL, HandlePacket)
        PacketHandlers(OPCODES.MSG_MINIMAP_PING) = CType(AddressOf On_MSG_MINIMAP_PING, HandlePacket)
        PacketHandlers(OPCODES.MSG_GROUP_SET_PLAYER_ICON) = CType(AddressOf On_MSG_GROUP_SET_PLAYER_ICON, HandlePacket)
        PacketHandlers(OPCODES.MSG_GROUP_SET_DIFFICULTY) = CType(AddressOf On_MSG_GROUP_SET_DIFFICULTY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_REQUEST_RAID_INFO) = CType(AddressOf On_CMSG_REQUEST_RAID_INFO, HandlePacket)

        PacketHandlers(OPCODES.MSG_RANDOM_ROLL) = CType(AddressOf On_MSG_RANDOM_ROLL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PLAYED_TIME) = CType(AddressOf On_CMSG_PLAYED_TIME, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TOGGLE_PVP) = CType(AddressOf On_CMSG_TOGGLE_PVP, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_WATCHED_FACTION_INDEX) = CType(AddressOf On_CMSG_SET_WATCHED_FACTION_INDEX, HandlePacket)

        PacketHandlers(OPCODES.CMSG_QUESTGIVER_STATUS_QUERY) = CType(AddressOf On_CMSG_QUESTGIVER_STATUS_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_HELLO) = CType(AddressOf On_CMSG_QUESTGIVER_HELLO, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_QUERY_QUEST) = CType(AddressOf On_CMSG_QUESTGIVER_QUERY_QUEST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_ACCEPT_QUEST) = CType(AddressOf On_CMSG_QUESTGIVER_ACCEPT_QUEST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTLOG_REMOVE_QUEST) = CType(AddressOf On_CMSG_QUESTLOG_REMOVE_QUEST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUEST_QUERY) = CType(AddressOf On_CMSG_QUEST_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_COMPLETE_QUEST) = CType(AddressOf On_CMSG_QUESTGIVER_COMPLETE_QUEST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_REQUEST_REWARD) = CType(AddressOf On_CMSG_QUESTGIVER_REQUEST_REWARD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_QUESTGIVER_CHOOSE_REWARD) = CType(AddressOf On_CMSG_QUESTGIVER_CHOOSE_REWARD, HandlePacket)
        PacketHandlers(OPCODES.MSG_QUEST_PUSH_RESULT) = CType(AddressOf On_MSG_QUEST_PUSH_RESULT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PUSHQUESTTOPARTY) = CType(AddressOf On_CMSG_PUSHQUESTTOPARTY, HandlePacket)

        PacketHandlers(OPCODES.CMSG_BINDER_ACTIVATE) = CType(AddressOf On_CMSG_BINDER_ACTIVATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BANKER_ACTIVATE) = CType(AddressOf On_CMSG_BANKER_ACTIVATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_BUY_BANK_SLOT) = CType(AddressOf On_CMSG_BUY_BANK_SLOT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUTOBANK_ITEM) = CType(AddressOf On_CMSG_AUTOBANK_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUTOSTORE_BANK_ITEM) = CType(AddressOf On_CMSG_AUTOSTORE_BANK_ITEM, HandlePacket)
        PacketHandlers(OPCODES.MSG_TALENT_WIPE_CONFIRM) = CType(AddressOf On_MSG_TALENT_WIPE_CONFIRM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TRAINER_BUY_SPELL) = CType(AddressOf On_CMSG_TRAINER_BUY_SPELL, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TRAINER_LIST) = CType(AddressOf On_CMSG_TRAINER_LIST, HandlePacket)

        PacketHandlers(OPCODES.MSG_AUCTION_HELLO) = CType(AddressOf On_MSG_AUCTION_HELLO, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_SELL_ITEM) = CType(AddressOf On_CMSG_AUCTION_SELL_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_REMOVE_ITEM) = CType(AddressOf On_CMSG_AUCTION_REMOVE_ITEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_LIST_ITEMS) = CType(AddressOf On_CMSG_AUCTION_LIST_ITEMS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_LIST_OWNER_ITEMS) = CType(AddressOf On_CMSG_AUCTION_LIST_OWNER_ITEMS, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_PLACE_BID) = CType(AddressOf On_CMSG_AUCTION_PLACE_BID, HandlePacket)
        PacketHandlers(OPCODES.CMSG_AUCTION_LIST_BIDDER_ITEMS) = CType(AddressOf On_CMSG_AUCTION_LIST_BIDDER_ITEMS, HandlePacket)

        PacketHandlers(OPCODES.CMSG_PETITION_SHOWLIST) = CType(AddressOf On_CMSG_PETITION_SHOWLIST, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PETITION_BUY) = CType(AddressOf On_CMSG_PETITION_BUY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PETITION_SHOW_SIGNATURES) = CType(AddressOf On_CMSG_PETITION_SHOW_SIGNATURES, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PETITION_QUERY) = CType(AddressOf On_CMSG_PETITION_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_TURN_IN_PETITION) = CType(AddressOf On_CMSG_TURN_IN_PETITION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_OFFER_PETITION) = CType(AddressOf On_CMSG_OFFER_PETITION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_PETITION_SIGN) = CType(AddressOf On_CMSG_PETITION_SIGN, HandlePacket)
        PacketHandlers(OPCODES.MSG_PETITION_RENAME) = CType(AddressOf On_MSG_PETITION_RENAME, HandlePacket)
        PacketHandlers(OPCODES.MSG_PETITION_DECLINE) = CType(AddressOf On_MSG_PETITION_DECLINE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_GUILD_QUERY) = CType(AddressOf On_CMSG_GUILD_QUERY, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_CREATE) = CType(AddressOf On_CMSG_GUILD_CREATE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_DISBAND) = CType(AddressOf On_CMSG_GUILD_DISBAND, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_ROSTER) = CType(AddressOf On_CMSG_GUILD_ROSTER, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_INFO) = CType(AddressOf On_CMSG_GUILD_INFO, HandlePacket)
        PacketHandlers(OPCODES.CMSG_SET_GUILD_INFORMATION) = CType(AddressOf On_CMSG_SET_GUILD_INFORMATION, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_RANK) = CType(AddressOf On_CMSG_GUILD_RANK, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_ADD_RANK) = CType(AddressOf On_CMSG_GUILD_ADD_RANK, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_DEL_RANK) = CType(AddressOf On_CMSG_GUILD_DEL_RANK, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_PROMOTE) = CType(AddressOf On_CMSG_GUILD_PROMOTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_DEMOTE) = CType(AddressOf On_CMSG_GUILD_DEMOTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_LEADER) = CType(AddressOf On_CMSG_GUILD_LEADER, HandlePacket)
        PacketHandlers(OPCODES.MSG_SAVE_GUILD_EMBLEM) = CType(AddressOf On_MSG_SAVE_GUILD_EMBLEM, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_SET_OFFICER_NOTE) = CType(AddressOf On_CMSG_GUILD_SET_OFFICER_NOTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_SET_PUBLIC_NOTE) = CType(AddressOf On_CMSG_GUILD_SET_PUBLIC_NOTE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_MOTD) = CType(AddressOf On_CMSG_GUILD_MOTD, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_INVITE) = CType(AddressOf On_CMSG_GUILD_INVITE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_ACCEPT) = CType(AddressOf On_CMSG_GUILD_ACCEPT, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_DECLINE) = CType(AddressOf On_CMSG_GUILD_DECLINE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_REMOVE) = CType(AddressOf On_CMSG_GUILD_REMOVE, HandlePacket)
        PacketHandlers(OPCODES.CMSG_GUILD_LEAVE) = CType(AddressOf On_CMSG_GUILD_LEAVE, HandlePacket)

        PacketHandlers(OPCODES.CMSG_DUEL_CANCELLED) = CType(AddressOf On_CMSG_DUEL_CANCELLED, HandlePacket)
        PacketHandlers(OPCODES.CMSG_DUEL_ACCEPTED) = CType(AddressOf On_CMSG_DUEL_ACCEPTED, HandlePacket)

        PacketHandlers(OPCODES.CMSG_LEARN_TALENT) = CType(AddressOf On_CMSG_LEARN_TALENT, HandlePacket)
        PacketHandlers(OPCODES.MSG_RAID_READYCHECK) = CType(AddressOf On_MSG_RAID_READYCHECK, HandlePacket)
    End Sub
    Public Sub OnUnhandledPacket(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.WARNING, "[{0}:{1}] {2} [Unhandled Packet]", Client.IP, Client.Port, CType(packet.OpCode, OPCODES))
    End Sub
#End Region

#Region "WS.Opcodes.Responds"

    Public Sub SendLoginOK(ByRef Client As ClientClass)
        Dim response As New PacketClass(OPCODES.SMSG_AUTH_RESPONSE)
        response.AddInt16(AuthResponseCodes.AUTH_OK)
        response.AddInt32(GetTimestamp(Now))    'time in minutes before "?"
        response.AddInt32(0)                    'always 00
        response.AddInt8(Client.Expansion)      'ExpansionRacesEnable
        Client.Send(response)

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_AUTH_SESSION [{2}]", Client.IP, Client.Port, Client.Account)
    End Sub
    Public Sub On_CMSG_AUTH_SESSION(ByRef packet As PacketClass, ByRef Client As ClientClass)
        'DumpPacket(packet.Data, Client)
        Dim i As Integer
        'Console.WriteLine("[{0}] [{1}:{2}] CMSG_AUTH_SESSION", Format(TimeOfDay, "hh:mm:ss"), Client.IP, Client.Port)

        packet.GetInt16()
        Dim clientVersion As Integer = packet.GetInt32
        Dim clientSesionID As Integer = packet.GetInt32
        Dim clientAccount As String = packet.GetString
        Dim clientSalt As Integer = packet.GetInt32
        Dim clientEncryptedPassword(19) As Byte
        For i = 0 To 19
            clientEncryptedPassword(i) = packet.GetInt8
        Next
        Dim clientAddOnsSize As Integer = packet.GetInt32

        'DONE: Set Client.Account
        Dim tmp As String = clientAccount

        'DONE: Kick if existing
        For Each tmpClient As ClientClass In CLIENTs
            If Not tmpClient Is Nothing Then
                If tmpClient.Account = tmp Then
                    Try
                        tmpClient.Socket.Shutdown(SocketShutdown.Both)
                    Catch
                        tmpClient.Socket.Close()
                    End Try
                End If
            End If
        Next
        Client.Account = tmp


        'DONE: Set Client.SS_Hash
        Dim result As New DataTable
        Dim query As String
        query = "SELECT * FROM adb_accounts WHERE account = '" & Client.Account & "';"
        Database.Query(query, result)
        If result.Rows.Count > 0 Then
            tmp = result.Rows(0).Item("last_sshash")
            Client.Access = result.Rows(0).Item("plevel")
            Client.Expansion = result.Rows(0).Item("expansion")
        Else
            Log.WriteLine(LogType.USER, "[{0}:{1}] AUTH_UNKNOWN_ACCOUNT: Account not in DB!", Client.IP, Client.Port)
            Dim response_no_acc As New PacketClass(OPCODES.SMSG_AUTH_RESPONSE)
            response_no_acc.AddInt8(AuthResponseCodes.AUTH_UNKNOWN_ACCOUNT)
            Exit Sub
        End If
        ReDim Client.SS_Hash(39)
        For i = 0 To Len(tmp) - 1 Step 2
            Client.SS_Hash(i \ 2) = Val("&H" & Mid(tmp, i + 1, 2))
        Next
        Client.Encryption = True




        'DONE: If server full then queue, If GM/Admin let in
        If CLIENTs.Count > Config.ServerLimit And Client.Access <= WS_Commands.AccessLevel.Player Then
            PacketThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Client.EnQueue))
        Else
            SendLoginOK(Client)
        End If




        'DONE: Addons info reading
        Dim decompressBuffer(packet.Data.Length - packet.Offset) As Byte
        Array.Copy(packet.Data, packet.Offset, decompressBuffer, 0, packet.Data.Length - packet.Offset)
        packet.Data = DeCompress(decompressBuffer)
        packet.Offset = 0
        'DumpPacket(packet.Data)

        Dim AddOnsNames As New ArrayList
        Dim AddOnsHashes As New ArrayList
        Dim AddOnsConsoleWrite As String = String.Format("[{0}:{1}] Client addons loaded:", Client.IP, Client.Port)
        While packet.Offset < clientAddOnsSize
            AddOnsNames.Add(packet.GetString)
            AddOnsHashes.Add(packet.GetInt64)
            AddOnsConsoleWrite &= String.Format("{0}{1} AddOnName: [{2,-30}], AddOnHash: [{3:X}]", vbNewLine, vbTab, AddOnsNames(AddOnsNames.Count - 1), AddOnsHashes(AddOnsHashes.Count - 1))
            packet.GetInt8()
        End While
        Log.WriteLine(LogType.DEBUG, AddOnsConsoleWrite)

        'DONE: Build mysql addons query
        'Not needed already - in 1.11 addons list is removed.

        'DONE: Send packet
        Dim addOnsEnable As New PacketClass(OPCODES.SMSG_ADDON_INFO)
        '1-enabled 0-banned 2-blizzard
        For i = 0 To AddOnsNames.Count - 1
            addOnsEnable.AddInt8(2)
            addOnsEnable.AddInt8(1)
            If AddOnsHashes(i) = 0 Then
                addOnsEnable.AddInt8(1)     'Hash?  If 1 then 256 bytes of the hash
                For j As Integer = 1 To 32
                    addOnsEnable.AddInt64(&HFFFFFFFFFFFFFFFF)
                Next
            Else
                addOnsEnable.AddInt8(0)
            End If
            addOnsEnable.AddInt8(0)
            addOnsEnable.AddInt32(0)
        Next
        Client.Send(addOnsEnable)
        addOnsEnable.Dispose()
    End Sub
    Public Sub On_CMSG_PING(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Dim response As New PacketClass(OPCODES.SMSG_PONG)
        response.AddInt8(packet.Data(6))
        response.AddInt8(packet.Data(7))
        response.AddInt8(packet.Data(8))
        response.AddInt8(packet.Data(9))
        Client.Send(response)

        Log.WriteLine(LogType.NETWORK, "[{0}:{1}] SMSG_PONG", Client.IP, Client.Port)
    End Sub

#End Region


    <System.MTAThreadAttribute()> _
    Sub Main()
        ConsoleColorClass.SetConsoleTitle(String.Format("{0} v{1}", [Assembly].GetExecutingAssembly().GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False)(0).Title, [Assembly].GetExecutingAssembly().GetName().Version))
        'Console.Title = String.Format("{0} v{1}", [Assembly].GetExecutingAssembly().GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False)(0).Title, [Assembly].GetExecutingAssembly().GetName().Version)
        'Console.ForegroundColor = System.ConsoleColor.Cyan

        ConsoleColor.SetConsoleColor(ConsoleColorClass.ForegroundColors.LightYellow)
        Console.WriteLine("{0}", [Assembly].GetExecutingAssembly().GetCustomAttributes(GetType(System.Reflection.AssemblyProductAttribute), False)(0).Product)
        Console.WriteLine([Assembly].GetExecutingAssembly().GetCustomAttributes(GetType(System.Reflection.AssemblyCopyrightAttribute), False)(0).Copyright)
        Console.WriteLine()

        ConsoleColor.SetConsoleColor(ConsoleColorClass.ForegroundColors.BrightWhite)
        Console.WriteLine([Assembly].GetExecutingAssembly().GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False)(0).Title)
        Console.Write("version {0}", [Assembly].GetExecutingAssembly().GetName().Version)
#If HANDLED_MAP_ID = 0 Then
        Console.WriteLine(" [0:Eastern Kingdoms]")
#ElseIf HANDLED_MAP_ID = 1 Then
            Console.WriteLine(" [1:Kalimdor]")
#ElseIf HANDLED_MAP_ID = 530 Then
            Console.WriteLine(" [530:Outlands]")
#ElseIf HANDLED_MAP_ID = -1 Then
            Console.WriteLine(" [Instances]")
#End If
        Console.WriteLine("")
        ConsoleColor.SetConsoleColor()



        Dim dateTimeStarted As Date = Now
        Console.WriteLine("[{0}] World Server Starting...", Format(TimeOfDay, "hh:mm:ss"))

        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf GenericExceptionHandler

        LoadConfig()
        AddHandler Database.SQLMessage, AddressOf SLQEventHandler
        Database.Connect()
        Database.Update("SET NAMES 'utf8';")


#If DEBUG Then
        Log.WriteLine(LogType.DEBUG, "Setting MySQL into debug mode..[done]")
        Database.Update("SET SESSION sql_mode='STRICT_ALL_TABLES';")
#End If
        InitializeInternalDatabase()
        IntializePacketHandlers()
        WS = New WorldServerClass
        GC.Collect()

        Log.WriteLine(LogType.INFORMATION, "Load Time: {0}", Format(DateDiff(DateInterval.Second, dateTimeStarted, Now), "0 seconds"))
        Log.WriteLine(LogType.INFORMATION, "Used memory: {0}", Format(GC.GetTotalMemory(False), "### ### ##0 bytes"))







        Dim tmp As String = "", CommandList() As String, cmds() As String
        Dim varList As Integer
        While Not WS._flagStopListen
            Try
                tmp = Log.ReadLine()
                CommandList = tmp.Split(";")

                For varList = LBound(CommandList) To UBound(CommandList)
                    cmds = Split(CommandList(varList), " ", 2)
                    If CommandList(varList).Length > 0 Then
                        '<<<<<<<<<<<COMMAND STRUCTURE>>>>>>>>>>
                        Select Case cmds(0).ToLower
                            Case "quit", "shutdown", "off", "kill"
                                Log.WriteLine(LogType.WARNING, "Server shutting down...")
                                WS._flagStopListen = True
                            Case "test"
                                '?
                            Case "spawnch"
                                Dim conn As New ClientClass
                                conn.DEBUG_CONNECTION = True
                                Dim test As New CharacterObject(conn, CType(cmds(1), Long))
                                CHARACTERS(CType(cmds(1), Long)) = test
                                AddToWorld(test)
                                Log.WriteLine(LogType.DEBUG, "Spawned character " & test.Name)
                            Case "exec"
                                Dim tmpScript As New ScriptedObject("scripts\commands\" & cmds(1), "", True)
                                tmpScript.Invoke("CustomCommands", "OnExecute")
                                tmpScript.Dispose()
                            Case "gccollect"
                                GC.Collect()
                            Case "info"
                                Log.WriteLine(LogType.INFORMATION, "Used memory: {0}", Format(GC.GetTotalMemory(False), "### ### ##0 bytes"))
                            Case "db.restart"
                                Database.Restart()
                            Case "db.run"
                                Database.Update(cmds(1))
                            Case Else
                                Log.WriteLine(LogType.FAILED, "Unknown command.")
                        End Select
                        '<<<<<<<<<<</END COMMAND STRUCTURE>>>>>>>>>>>>
                    End If
                Next
            Catch e As Exception
                Log.WriteLine(LogType.FAILED, "Error executing command [{0}]. {2}{1}", Format(TimeOfDay, "hh:mm:ss"), tmp, e.ToString, vbNewLine)
            End Try
        End While

        Regenerator.Dispose()
        Spawner.Dispose()
        AreaTriggers.Dispose()
    End Sub

    Private Sub GenericExceptionHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim EX As Exception
        EX = e.ExceptionObject

        Log.WriteLine(LogType.CRITICAL, EX.ToString & vbNewLine)
        Log.WriteLine(LogType.FAILED, "Error.log file created, please send to Devs!")

        Dim tw As TextWriter
        tw = New StreamWriter(New FileStream(String.Format("Error-{0}.log", Format(Now, "yyyy-MMM-d-H-mm")), FileMode.Create))
        tw.Write(EX.ToString)
        tw.Close()
    End Sub


End Module
