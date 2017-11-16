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

Imports vbWoW.Logbase.BaseWriter

    Module WS_Channels
        Enum NOTIFY_ERR_CODES
            CHANNEL_JOINED = 0
            CHANNEL_LEFT = 1
            CHANNEL_YOU_JOINED = 2
            CHANNEL_YOU_LEFT = 3
            CHANNEL_WRONG_PASS = 4

            CHANNEL_NOT_ON = 5
            CHANNEL_NOT_MODERATOR = 6
            CHANNEL_SET_PASSWORD = 7
            CHANNEL_CHANGE_OWNER = 8
            CHANNEL_NOT_ON_FOR_NAME = 9
            CHANNEL_NOT_OWNER = &HA
            CHANNEL_WHO_OWNER = &HB
            CHANNEL_MODE_CHANGE = &HC
            CHANNEL_ENABLE_ANNOUNCE = &HD
            CHANNEL_DISABLE_ANNOUNCE = &HE
            CHANNEL_MODERATED = &HF
            CHANNEL_UNMODERATED = &H10
            CHANNEL_YOUCANTSPEAK = &H11
            CHANNEL_KICKED = &H12

            CHANNEL_YOU_ARE_BANNED = &H13
            CHANNEL_BANNED = &H14
            CHANNEL_UNBANNED = &H15

            CHANNEL_ALREADY_ON = &H17
            CHANNEL_INVITED = &H18
            CHANNEL_WRONG_ALLIANCE = &H19
            CHANNEL_YOU_INVITED = &H1D
        End Enum

        Public Class ChannelsClass
            Implements IDisposable

            Public Joined As New Hashtable
            Public Banned As New Hashtable
            Public Moderators As New Hashtable
            Public Muted As New Hashtable
            Public Owner As Long = 0
            Public ChannelName As String = ""
            Public Password As String = ""
            Public Announce As Boolean = False

            Private Sub Dispose() Implements System.IDisposable.Dispose
            End Sub
            Public Sub New(ByVal ChannelNameNew As String)
                CHAT_CHANNELs.Add(ChannelNameNew, Me)
                ChannelName = ChannelNameNew
            End Sub
            Public Sub Say(ByVal Message As String, ByVal msgLang As Integer, ByRef Character As CharacterObject)
                'TODO: Split Horde and Alliance Channels

                If Muted.ContainsKey(Character.GUID) Then
                    Dim response As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    response.AddInt8(NOTIFY_ERR_CODES.CHANNEL_YOUCANTSPEAK)
                    response.AddString(ChannelName)
                    Character.Client.Send(response)
                    response.Dispose()
                    Exit Sub
                End If

                Dim packet As PacketClass = BuildChatMessage(Character.GUID, Message, ChatMsg.CHAT_MSG_CHANNEL, msgLang, GetChatFlag(Character), ChannelName)

                For Each Player As DictionaryEntry In Joined
                    If CHARACTERS.Contains(Player.Value) Then
                        CType(CHARACTERS(Player.Value), CharacterObject).Client.SendMultiplyPackets(packet)
                    End If
                Next
                packet.Dispose()
                Log.WriteLine(LogType.USER, "[{0}:{1}] SMSG_MESSAGECHAT [{2}: <{3}> {4}]", Character.Client.IP, Character.Client.Port, ChannelName, Character.Name, Message)
            End Sub
            Public Sub Join(ByRef Character As CharacterObject, ByVal ClientPassword As String, ByVal ChannelIndex As Integer)
                'DONE: Check if Already joined
                If Joined.ContainsKey(Character.GUID) Then
                    Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_ALREADY_ON)
                    packet.AddString(ChannelName)
                    packet.AddInt64(Character.GUID)

                    Character.Client.Send(packet)
                    packet.Dispose()
                    Exit Sub
                End If

                'DONE: Check if banned
                'TODO: Save to DB
                If Banned.ContainsKey(Character.GUID) Then
                    Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_YOU_ARE_BANNED)
                    packet.AddString(ChannelName)

                    Character.Client.Send(packet)
                    packet.Dispose()
                    Exit Sub
                End If

                'DONE: Check for password
                If Password <> "" Then
                    If Password <> ClientPassword Then
                        Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                        packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_WRONG_PASS)
                        packet.AddString(ChannelName)

                        Character.Client.Send(packet)
                        packet.Dispose()
                        Exit Sub
                    End If
                End If

                'DONE: {0} Joined channel
                If Announce Then
                    Dim response As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    response.AddInt8(NOTIFY_ERR_CODES.CHANNEL_JOINED)
                    response.AddString(ChannelName)
                    response.AddInt64(Character.GUID)
                    For Each Guid As Long In Joined
                        CType(CHARACTERS(Guid), CharacterObject).Client.SendMultiplyPackets(response)
                    Next
                    response.Dispose()
                End If

                'DONE: You Joined channel
                Dim response2 As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                response2.AddInt8(NOTIFY_ERR_CODES.CHANNEL_YOU_JOINED)
                response2.AddString(ChannelName)
                'response2.AddInt64(Character.GUID)
                response2.AddInt64(ChannelIndex)
                Character.Client.Send(response2)
                response2.Dispose()

                'DONE: If new channel, set owner
                If InStr(ChannelName, "General") = 0 _
                AndAlso InStr(ChannelName, "Trade") = 0 _
                AndAlso InStr(ChannelName, "Local") = 0 _
                AndAlso InStr(ChannelName, "Looking") = 0 _
                AndAlso Joined.Count = 0 Then
                    SetOwner(Character)
                    Moderators.Add(Character.GUID, Character.GUID)
                End If

                Joined.Add(Character.GUID, Character.GUID)
                Character.JoinedChannels.Add(ChannelName)
            End Sub
            Public Sub Part(ByRef Character As CharacterObject, Optional ByVal ConnectionAviable As Boolean = True)
                'DONE: Check if not on this channel
                If Not Joined.ContainsKey(Character.GUID) Then
                    Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_NOT_ON)
                    packet.AddString(ChannelName)
                    If ConnectionAviable Then Character.Client.Send(packet)
                    packet.Dispose()
                    Exit Sub
                End If

                'DONE: You Left channel
                If ConnectionAviable Then
                    Dim response2 As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    response2.AddInt8(NOTIFY_ERR_CODES.CHANNEL_YOU_LEFT)
                    response2.AddString(ChannelName)
                    Character.Client.Send(response2)
                    response2.Dispose()
                End If

                Joined.Remove(Character.GUID)
                Character.JoinedChannels.Remove(ChannelName)

                'DONE: {0} Left channel
                If Announce Then
                    Dim response As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                    response.AddInt8(NOTIFY_ERR_CODES.CHANNEL_LEFT)
                    response.AddString(ChannelName)
                    response.AddInt64(Character.GUID)
                    For Each Guid As Long In Joined
                        CType(CHARACTERS(Guid), CharacterObject).Client.SendMultiplyPackets(response)
                    Next
                    response.Dispose()
                End If

                'DONE: Set new owner
                If Joined.Count > 0 AndAlso Owner = Character.GUID Then
                    Dim tmp As IEnumerator = Joined.GetEnumerator()
                    tmp.MoveNext()
                    SetOwner(CHARACTERS(tmp.Current))
                End If

                'DONE: If free and not global - clear channel
                If InStr(ChannelName, "General") = 0 _
                AndAlso InStr(ChannelName, "Trade") = 0 _
                AndAlso InStr(ChannelName, "Local") = 0 _
                AndAlso InStr(ChannelName, "Looking") = 0 _
                AndAlso Joined.Count = 0 Then
                    CHAT_CHANNELs.Remove(ChannelName)
                    Me.Dispose()
                End If
            End Sub
            Public Sub SetOwner(ByRef Character As CharacterObject)
                Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_CHANGE_OWNER)
                packet.AddString(ChannelName)
                packet.AddInt64(Character.GUID)
                For Each Guid As Long In Joined
                    CType(CHARACTERS(Guid), CharacterObject).Client.SendMultiplyPackets(packet)
                Next
                packet.Dispose()

                Owner = Character.GUID
            End Sub
            Public Sub GetOwner(ByRef Character As CharacterObject)
                Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_NOTIFY)
                packet.AddInt8(NOTIFY_ERR_CODES.CHANNEL_WHO_OWNER)
                packet.AddString(ChannelName)
                packet.AddString(Character.GUID)
                If Owner > 0 Then
                    packet.AddString(CType(CHARACTERS(Owner), CharacterObject).Name)
                Else
                    packet.AddString("Nobody")
                End If
                Character.Client.Send(packet)
                packet.Dispose()
            End Sub
            Public Sub List(ByRef Character As CharacterObject)
                Dim packet As New PacketClass(OPCODES.SMSG_CHANNEL_LIST)

                packet.AddInt8(3)
                packet.AddInt32(Joined.Count)

                Dim mode As Byte
                For Each GUID As Long In Joined
                    packet.AddInt64(GUID)
                    mode = 0
                    If Moderators.ContainsKey(GUID) Then
                        mode = mode Or 2
                    End If
                    If Muted.ContainsKey(GUID) Then
                        mode = mode Or 4
                    End If
                    packet.AddInt8(mode)
                Next

                Character.Client.Send(packet)
                packet.Dispose()
            End Sub
            Public Sub Invite(ByRef Character As CharacterObject, ByVal GUID As Long)
                'TODO: Channel invite
            End Sub
        End Class


        Public Sub On_CMSG_JOIN_CHANNEL(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()
            Dim ChannelIndex As Integer = packet.GetInt32
            Dim ChannelOperation As Byte = packet.GetInt8
            Dim ChannelName As String = packet.GetString

            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_JOIN_CHANNEL [{3}:{2}]", Client.IP, Client.Port, ChannelName, ChannelIndex)

            Dim Password As String = packet.GetString()
            If Not CHAT_CHANNELs.ContainsKey(ChannelName) Then
                Dim NewChannel As New ChannelsClass(ChannelName)
            End If

            CType(CHAT_CHANNELs(ChannelName), ChannelsClass).Join(Client.Character, Password, ChannelIndex)
        End Sub
        Public Sub On_CMSG_LEAVE_CHANNEL(ByRef packet As PacketClass, ByRef Client As ClientClass)
            packet.GetInt16()
            Dim ChannelIndex As String = packet.GetInt32
            Dim ChannelName As String = packet.GetString

            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LEAVE_CHANNEL [{3}:{2}]", Client.IP, Client.Port, ChannelName, ChannelIndex)
            If CHAT_CHANNELs.ContainsKey(ChannelName) Then
                CType(CHAT_CHANNELs(ChannelName), ChannelsClass).Part(Client.Character)
            End If
        End Sub
        Public Sub On_CMSG_CHANNEL_LIST(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_LIST", Client.IP, Client.Port)
            packet.GetInt16()
            Dim ChannelName As String = packet.GetString()
            If CHAT_CHANNELs.ContainsKey(ChannelName) Then
                CType(CHAT_CHANNELs(ChannelName), ChannelsClass).List(Client.Character)
            End If
        End Sub

        'TODO: Some channel packets
        Public Sub On_CMSG_CHANNEL_PASSWORD(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_PASSWORD", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_SET_OWNER(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_SET_OWNER", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_OWNER(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_OWNER", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_MODERATOR(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_MODERATOR", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_UNMODERATOR(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_UNMODERATOR", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_MUTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_MUTE", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_UNMUTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_UNMUTE", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_INVITE(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_INVITE", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_KICK(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_KICK", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_ANNOUNCEMENTS(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_ANNOUNCEMENTS", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_BAN(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_BAN", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_UNBAN(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_UNBAN", Client.IP, Client.Port)
        End Sub
        Public Sub On_CMSG_CHANNEL_MODERATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CHANNEL_MODERATE", Client.IP, Client.Port)
        End Sub


    End Module
