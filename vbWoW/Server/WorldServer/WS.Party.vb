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
Imports vbWoW.Logbase.BaseWriter

Public Module WS_Party


    'TODO: Save in DB while character transfer
    'TODO: CMSG_REQUEST_PARTY_MEMBER_STATS


#Region "WS.Party.Constants"


    Public Const GROUP_SUBGROUPSIZE As Integer = 5
    Public Const GROUP_SIZE As Integer = 4
    Public Const GROUP_RAIDSIZE As Integer = 39


#End Region
#Region "WS.Party.DataType"


    Public Class BaseParty
        Implements IDisposable

        Public Sub Dispose() Implements IDisposable.Dispose
            Dim packet As PacketClass

            If Me.IsRaid Then
                packet = New PacketClass(OPCODES.SMSG_GROUP_LIST)
                packet.AddInt16(0)          'GroupType 0:Party 1:Raid
                packet.AddInt32(0)          'GroupCount

                'raidDelete.AddInt64(0)
                'raidDelete.AddInt8(0)
                'raidDelete.AddInt64(0)
                'raidDelete.AddInt8(0)
                'raidDelete.Dispose()
            Else
                packet = New PacketClass(OPCODES.SMSG_GROUP_DESTROYED)
            End If


            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then
                    GroupMembers(i).Party = Nothing
                    GroupMembers(i).Client.SendMultiplyPackets(packet)
                End If
            Next
            packet.Dispose()
        End Sub
        Public Sub New(ByRef Character As CharacterObject)
            GroupMembers(0) = Character
            GroupMembers(1) = Nothing
            GroupMembers(2) = Nothing
            GroupMembers(3) = Nothing
            GroupMembers(4) = Nothing

            Character.Party = Me
            Character.PartyJustInvited = False
            Character.PartyRaidAssistant = False
            GroupLeader = 0
            GroupLootMaster = 0
        End Sub
        Public Sub AddCharacter(ByRef Character As CharacterObject)
            For i As Byte = 0 To GroupMembers.Length - 1
                If GroupMembers(i) Is Nothing Then
                    GroupMembers(i) = Character
                    Character.Party = Me
                    Character.PartyJustInvited = False
                    Character.PartyRaidAssistant = False
                    Exit For
                End If
            Next

            GroupUpdate()
        End Sub
        Public Sub RemoveCharacter(ByRef Character As CharacterObject)

            For i As Byte = 0 To GroupMembers.Length - 1
                If GroupMembers(i) Is Character Then

                    Character.Party = Nothing
                    GroupMembers(i) = Nothing

                    Dim packet As New PacketClass(OPCODES.SMSG_GROUP_UNINVITE)
                    Character.Client.Send(packet)
                    packet.Dispose()

                    'DONE: If current is leader then choose new
                    If i = GroupLeader Then
                        For j As Byte = 0 To GroupMembers.Length - 1
                            If Not GroupMembers(j) Is Nothing Then
                                GroupLeader = j

                                Dim response As New PacketClass(OPCODES.SMSG_GROUP_SET_LEADER)
                                response.AddString(Character.Name)
                                Broadcast(response)
                                response.Dispose()
                                Exit For
                            End If
                        Next
                    End If

                    'DONE: If current is lootMaster then choose new
                    If Character.GUID = GroupLootMaster Then GroupLootMaster = 0

                    Exit For
                End If
            Next

            CharactersUpdate()
        End Sub
        Public Sub CharactersUpdate()
            Dim groupCount As Byte = 0
            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then groupCount += 1
            Next

            If groupCount < 2 Then Dispose() Else GroupUpdate()
        End Sub

        Public Sub GroupUpdate()
            Dim GroupCount As Byte = 0
            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then GroupCount += 1
            Next



            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then

                    Dim packet As New PacketClass(OPCODES.SMSG_GROUP_LIST)
                    packet.AddInt8(Convert.ToInt32(IsRaid))                                                         'GroupType 0:Party 1:Raid
                    packet.AddInt8(0)
                    packet.AddInt8(i \ GROUP_SUBGROUPSIZE + (GroupMembers(i).PartyRaidAssistant << 7))              'CharFlags [SubGroupID + (RaidAssistant=&H80)]
                    packet.AddInt32(GroupCount - 1)
                    For j As Byte = 0 To GroupMembers.Length - 1
                        If (Not GroupMembers(j) Is Nothing) AndAlso (Not GroupMembers(j) Is GroupMembers(i)) Then
                            packet.AddString(GroupMembers(j).Name)
                            packet.AddInt64(GroupMembers(j).GUID)
                            packet.AddInt8(1)                                                                       'CharOnline?
                            packet.AddInt8((j \ GROUP_SUBGROUPSIZE) + (GroupMembers(j).PartyRaidAssistant << 7))    'CharFlags [SubGroupID + (RaidAssistant=&H80)]
                        End If
                    Next
                    packet.AddInt64(GroupMembers(GroupLeader).GUID)
                    packet.AddInt8(GroupLootType)
                    packet.AddInt64(GroupLootMaster)
                    packet.AddInt8(GroupLootThreshold)
                    packet.AddInt8(GroupDungeonDifficulty)                  'DungeonDifficulty
                    packet.AddInt64(GroupMainTank)
                    packet.AddInt64(GroupMainAssist)

                    GroupMembers(i).Client.Send(packet)
                    packet.Dispose()
                End If
            Next
        End Sub
        Public Function SetLeader(ByRef Character As CharacterObject) As Boolean
            For i As Byte = 0 To GroupMembers.Length
                If i = GroupMembers.Length Then Return False
                If GroupMembers(i) Is Character Then
                    GroupLeader = i
                    Exit For
                End If
            Next

            Dim packet As New PacketClass(OPCODES.SMSG_GROUP_SET_LEADER)
            packet.AddString(Character.Name)
            Broadcast(packet)
            packet.Dispose()

            GroupUpdate()

            Return True
        End Function
        Public Function SetLootMaster(ByRef Character As CharacterObject) As Boolean
            GroupLootMaster = Character.GUID
            GroupUpdate()
            Return True
        End Function
        Public Sub ConvertToRaid()
            ReDim Preserve GroupMembers(GROUP_RAIDSIZE)
            For i As Byte = GROUP_SIZE + 1 To GROUP_RAIDSIZE
                GroupMembers(i) = Nothing
            Next
        End Sub

        Public Sub Broadcast(ByRef packet As PacketClass)
            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then GroupMembers(i).Client.SendMultiplyPackets(packet)
            Next
        End Sub
        Public Sub BroadcastToOther(ByRef packet As PacketClass, ByRef c As CharacterObject)
            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing AndAlso (Not GroupMembers(i) Is c) Then GroupMembers(i).Client.SendMultiplyPackets(packet)
            Next
        End Sub
        Public Sub SendChatMessage(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES)
            Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_PARTY, Language, GetChatFlag(Sender))

            Broadcast(packet)
            packet.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_MESSAGECHAT", Sender.Client.IP, Sender.Client.Port)
        End Sub
        Public Sub SendChatMessageRaid(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES)
            Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_RAID, Language, GetChatFlag(Sender))

            Broadcast(packet)
            packet.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_MESSAGECHAT", Sender.Client.IP, Sender.Client.Port)
        End Sub
        Public Sub SendChatMessageRaidLeader(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES)
            Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_RAID_LEADER, Language, GetChatFlag(Sender))

            Broadcast(packet)
            packet.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_MESSAGECHAT", Sender.Client.IP, Sender.Client.Port)
        End Sub
        Public Sub SendChatMessageRaidWarning(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES)
            Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_RAID_WARNING, Language, 0)

            Broadcast(packet)
            packet.Dispose()
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_MESSAGECHAT", Sender.Client.IP, Sender.Client.Port)
        End Sub

        Public ReadOnly Property IsFull() As Boolean
            Get
                For i As Byte = 0 To GroupMembers.Length - 1
                    If GroupMembers(i) Is Nothing Then Return False
                Next
                Return True
            End Get
        End Property
        Public ReadOnly Property IsRaid() As Boolean
            Get
                Return (GroupMembers.Length > GROUP_SIZE + 1)
            End Get
        End Property
        Public Function GetMembersCount() As Integer
            Dim count As Byte = 0
            For i As Byte = 0 To GroupMembers.Length - 1
                If Not GroupMembers(i) Is Nothing Then count += 1
            Next i
            Return count
        End Function
        Public Function GetNextLooter(ByRef Character As CharacterObject) As CharacterObject
            For i As Byte = 0 To GroupMembers.Length
                If i = GroupMembers.Length Then
                    NextLooter = 0
                    Return GetNextLooter(Character)
                End If

                If (Not GroupMembers(i) Is Nothing) AndAlso (i >= NextLooter) Then
                    Log.WriteLine(LogType.DEBUG, "Current looter = {0}", NextLooter)
                    NextLooter = i + 1
                    Return GroupMembers(i)
                End If
            Next
            Return Character
        End Function
        Public Function GetGroupLeader() As CharacterObject
            Return GroupMembers(GroupLeader)
        End Function

        Public GroupLeader As Byte = 0
        Public GroupDungeonDifficulty As DungeonDifficulty = DungeonDifficulty.DIFFICULTY_NORMAL
        Public GroupLootType As LootMethod = LootMethod.LOOT_GROUP
        Public GroupLootThreshold As LootThreshold = LootThreshold.Uncommon
        Public GroupLootMaster As Long = 0
        Public GroupMainTank As Long = 0
        Public GroupMainAssist As Long = 0
        Public GroupMembers(GROUP_SIZE) As CharacterObject

        Public NextLooter As Byte = 0

        Public Enum LootMethod As Byte
            LOOT_FREE_FOR_ALL = 0
            LOOT_ROUND_ROBIN = 1
            LOOT_MASTER = 2
            LOOT_GROUP = 3
            LOOT_NEED_BEFORE_GREED = 4
        End Enum
        Public Enum LootThreshold As Byte
            Uncommon = 2
            Rare = 3
            Epic = 4
        End Enum
        Public Enum DungeonDifficulty As Byte
            DIFFICULTY_NORMAL = 0
            DIFFICULTY_HEROIC = 1
        End Enum
    End Class


#End Region
#Region "WS.Party.Handlers"


    Enum PartyCommandResult As Byte
        INVITE_OK = 0               'You have invited [name] to join your group.
        INVITE_NOT_FOUND = 1        'Cannot find [name].
        INVITE_UNK1 = 2             '[name] is not in your party.
        INVITE_PARTY_FULL = 3       'Your party is full.
        INVITE_ALREADY_IN_GROUP = 4 '[name] is already in group.
        INVITE_NOT_IN_PARTY = 5     'You aren't in party.
        INVITE_NOT_LEADER = 6       'You are not the party leader.
        INVITE_NOT_SAME_SIDE = 7    'gms - Target is not part of your alliance.
        INVITE_IGNORED = 8          'Test is ignoring you.
    End Enum

    Public Sub On_CMSG_GROUP_INVITE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim Name As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_INVITE [{2}]", Client.IP, Client.Port, Name)

        Dim GUID As Long = 0
        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            If UCase(Character.Value.Name) = UCase(Name) Then
                GUID = Character.Value.GUID
                Exit For
            End If
        Next
        charactersLock_.ReleaseReaderLock()


        Dim errCode As PartyCommandResult = PartyCommandResult.INVITE_OK
        If GUID = 0 Then
            errCode = PartyCommandResult.INVITE_NOT_FOUND
        ElseIf CHARACTERS(GUID).Side <> Client.Character.Side Then
            errCode = PartyCommandResult.INVITE_NOT_SAME_SIDE
        ElseIf CHARACTERS(GUID).IsInGroup Then
            errCode = PartyCommandResult.INVITE_ALREADY_IN_GROUP
        ElseIf CHARACTERS(GUID).IgnoreList.Contains(Client.Character.GUID) Then
            errCode = PartyCommandResult.INVITE_IGNORED
        Else

            If Not Client.Character.IsInGroup Then
                Dim tmpParty As New BaseParty(Client.Character)
                CHARACTERS(GUID).Party = Client.Character.Party
                CHARACTERS(GUID).PartyJustInvited = True
            Else
                If Client.Character.Party.IsFull Then
                    errCode = PartyCommandResult.INVITE_PARTY_FULL
                ElseIf Not (Client.Character.IsGroupLeader Or Client.Character.PartyRaidAssistant) Then
                    errCode = PartyCommandResult.INVITE_NOT_LEADER
                Else
                    CHARACTERS(GUID).Party = Client.Character.Party
                    CHARACTERS(GUID).PartyJustInvited = True
                End If
            End If

        End If


        Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
        response.AddInt32(0)
        response.AddString(Name)
        response.AddInt32(errCode)
        Client.Send(response)
        response.Dispose()

        If errCode = PartyCommandResult.INVITE_OK Then
            Dim invited As New PacketClass(OPCODES.SMSG_GROUP_INVITE)
            invited.AddString(Client.Character.Name)
            CHARACTERS(GUID).Client.Send(invited)
            invited.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_GROUP_CANCEL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_CANCEL", Client.IP, Client.Port)
    End Sub
    Public Sub On_CMSG_GROUP_ACCEPT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_ACCEPT", Client.IP, Client.Port)
        If Client.Character.PartyJustInvited Then
            Client.Character.Party.AddCharacter(Client.Character)
        End If
    End Sub
    Public Sub On_CMSG_GROUP_DECLINE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_DECLINE", Client.IP, Client.Port)
        If Client.Character.PartyJustInvited Then
            Client.Character.PartyJustInvited = False

            Dim response As New PacketClass(OPCODES.SMSG_GROUP_DECLINE)
            response.AddString(Client.Character.Name)
            Client.Character.Party.GetGroupLeader.Client.Send(response)
            response.Dispose()

            Client.Character.Party.CharactersUpdate()
            Client.Character.Party = Nothing
        End If
    End Sub

    Public Sub On_CMSG_GROUP_UNINVITE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim Name As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_UNINVITE [{2}]", Client.IP, Client.Port, Name)

        Dim GUID As Long = 0
        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            If UCase(Character.Value.Name) = UCase(Name) Then
                GUID = Character.Value.GUID
                Exit For
            End If
        Next
        charactersLock_.ReleaseReaderLock()


        If GUID = 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddString(Name)
            response.AddInt32(PartyCommandResult.INVITE_NOT_FOUND)
            Client.Send(response)
            response.Dispose()
        ElseIf Not Client.Character.IsGroupLeader Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddInt8(0)
            response.AddInt32(PartyCommandResult.INVITE_NOT_LEADER)
            Client.Send(response)
            response.Dispose()
        Else
            Client.Character.Party.RemoveCharacter(CHARACTERS(GUID))
        End If

    End Sub
    Public Sub On_CMSG_GROUP_UNINVITE_GUID(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_UNINVITE_GUID [{2:X}]", Client.IP, Client.Port, GUID)

        If GUID = 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddString(0)
            response.AddInt32(PartyCommandResult.INVITE_NOT_FOUND)
            Client.Send(response)
            response.Dispose()
        ElseIf Not Client.Character.IsGroupLeader Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddInt8(0)
            response.AddInt32(PartyCommandResult.INVITE_NOT_LEADER)
            Client.Send(response)
            response.Dispose()
        Else
            Client.Character.Party.RemoveCharacter(CHARACTERS(GUID))
        End If
    End Sub
    Public Sub On_CMSG_GROUP_SET_LEADER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_SET_LEADER [{2:X}]", Client.IP, Client.Port, GUID)

        If GUID = 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddString(CHARACTERS(GUID).Name)
            response.AddInt32(PartyCommandResult.INVITE_NOT_FOUND)
            Client.Send(response)
            response.Dispose()
        ElseIf Not Client.Character.IsGroupLeader Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddString(CHARACTERS(GUID).Name)
            response.AddInt32(PartyCommandResult.INVITE_NOT_LEADER)
            Client.Send(response)
            response.Dispose()
        ElseIf Not Client.Character.Party.SetLeader(CHARACTERS(GUID)) Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddString(CHARACTERS(GUID).Name)
            response.AddInt32(PartyCommandResult.INVITE_UNK1)
            Client.Send(response)
            response.Dispose()
        End If
    End Sub

    Public Enum PromoteToMain As Byte
        MainTank = 0
        MainAssist = 1
    End Enum
    Public Sub On_CMSG_GROUP_SET_MAIN(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim Role As PromoteToMain = packet.GetInt8
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_SET_MAIN [{3}:{2:X}]", Client.IP, Client.Port, GUID, Role)


        If Client.Character.IsInGroup Then
            If Not Client.Character.IsGroupLeader Then
                Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
                response.AddInt32(0)
                response.AddString(CHARACTERS(GUID).Name)
                response.AddInt32(PartyCommandResult.INVITE_NOT_LEADER)
                Client.Send(response)
                response.Dispose()
            Else
                Select Case Role
                    Case PromoteToMain.MainTank
                        Client.Character.Party.GroupMainTank = GUID
                        Client.Character.Party.GroupUpdate()
                    Case PromoteToMain.MainAssist
                        Client.Character.Party.GroupMainAssist = GUID
                        Client.Character.Party.GroupUpdate()
                End Select

            End If
        End If
    End Sub


    Public Sub On_CMSG_LOOT_METHOD(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim lootMethod As Integer = packet.GetInt32
        Dim lootMaster As Long = packet.GetInt64
        Dim lootThreshold As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LOOT_METHOD [lootMethod={2}, lootMaster={3}, lootThreshold={4}]", Client.IP, Client.Port, lootMethod, lootMaster, lootThreshold)

        If Not Client.Character.IsGroupLeader Then
            Dim response As New PacketClass(OPCODES.SMSG_PARTY_COMMAND_RESULT)
            response.AddInt32(0)
            response.AddInt8(0)
            response.AddInt32(PartyCommandResult.INVITE_NOT_LEADER)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If lootMethod <> BaseParty.LootMethod.LOOT_MASTER Then lootMaster = 0

        Client.Character.Party.GroupLootType = lootMethod
        Client.Character.Party.GroupLootMaster = lootMaster
        Client.Character.Party.GroupLootThreshold = lootThreshold
        Client.Character.Party.GroupUpdate()
    End Sub
    Public Sub On_CMSG_GROUP_DISBAND(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_DISBAND", Client.IP, Client.Port)

        If Client.Character.IsInGroup Then
            If Client.Character.Party.GetMembersCount > 2 Then
                Client.Character.Party.RemoveCharacter(Client.Character)
            Else
                Client.Character.Party.Dispose()
            End If
        End If
    End Sub


    Public Enum PartyMemberStatsStatus As Byte
        STATUS_OFFLINE = 0
        STATUS_ONLINE = 1
        STATUS_OFFLINE_PVP = 2
        STATUS_ONLINE_PVP = 3
    End Enum
    Public Enum PartyMemberStatsBits As Byte
        FIELD_STATUS = 0
        FIELD_LIFE_CURRENT = 1
        FIElD_LIFE_MAX = 2
        FIELD_MANA_TYPE = 3
        FIELD_MANA_CURRENT = 4
        FIELD_MANA_MAX = 5
        FIELD_LEVEL = 6
        FIELD_ZONEID = 7
        FIELD_POSXPOSY = 8
    End Enum
    Function BuildPartyMemberStats(ByVal GUID As Long, ByRef c As CharacterObject) As PacketClass
        Dim bitMask As New BitArray(5 * 8, False)
        Dim packet As New PacketClass(OPCODES.SMSG_PARTY_MEMBER_STATS)
        packet.AddPackGUID(GUID)

        'DONE: Building bitmask
        If c Is Nothing Then
            bitMask.Set(PartyMemberStatsBits.FIELD_STATUS, True)
        Else
            bitMask.Set(0, True) 'byte  Status
            bitMask.Set(1, True) 'int16 Life
            bitMask.Set(2, True) 'int16 LifeMax
            bitMask.Set(3, True) 'byte ManaType
            bitMask.Set(4, True) 'int16 Mana
            bitMask.Set(5, True) 'int16 ManaMax
            bitMask.Set(6, True) 'int16 Level
            bitMask.Set(7, True) 'int16 ZoneID
            bitMask.Set(8 + 0, True)   'int16 PosX, int16 PosY
            bitMask.Set(8 + 1, False)  'Spells? [uint32 Flags, int16() Spells]
            bitMask.Set(8 + 2, False)  '?
            bitMask.Set(8 + 3, False)  'string  PetName?
            bitMask.Set(8 + 4, False)  'int16 PetModel? [&H72B0]
            bitMask.Set(8 + 5, False)  '?
            bitMask.Set(8 + 6, False)  '?
            bitMask.Set(8 + 7, False)  '?
        End If

        'DONE: Adding bitmask
        packet.AddBitArray(bitMask, 4)

        'DONE: Adding values (part1)
        If bitMask.Item(PartyMemberStatsBits.FIELD_STATUS) Then
            If c Is Nothing Then
                packet.AddInt8(PartyMemberStatsStatus.STATUS_OFFLINE)
            Else
                packet.AddInt8(PartyMemberStatsStatus.STATUS_ONLINE)
            End If
        End If
        If bitMask.Item(PartyMemberStatsBits.FIELD_LIFE_CURRENT) Then packet.AddInt16(c.Life.Current)
        If bitMask.Item(PartyMemberStatsBits.FIElD_LIFE_MAX) Then packet.AddInt16(c.Life.Maximum)
        If bitMask.Item(PartyMemberStatsBits.FIELD_MANA_TYPE) Then packet.AddInt8(c.ManaType)
        If bitMask.Item(PartyMemberStatsBits.FIELD_MANA_CURRENT) Then packet.AddInt16(c.Mana.Current)
        If bitMask.Item(PartyMemberStatsBits.FIELD_MANA_MAX) Then packet.AddInt16(c.Mana.Maximum)
        If bitMask.Item(PartyMemberStatsBits.FIELD_LEVEL) Then packet.AddInt16(c.Level)
        If bitMask.Item(PartyMemberStatsBits.FIELD_ZONEID) Then packet.AddInt16(c.ZoneID)
        If bitMask.Item(PartyMemberStatsBits.FIELD_POSXPOSY) Then
            packet.AddInt16(Fix(c.positionX))
            packet.AddInt16(Fix(c.positionY))
        End If

        Return packet
    End Function
    Public Sub On_CMSG_REQUEST_PARTY_MEMBER_STATS(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_REQUEST_PARTY_MEMBER_STATS [{2:X}]", Client.IP, Client.Port, GUID)

        Dim c As CharacterObject = CHARACTERS(GUID)
        Client.Send(BuildPartyMemberStats(GUID, c))
    End Sub

    Public Sub On_CMSG_GROUP_RAID_CONVERT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_RAID_CONVERT", Client.IP, Client.Port)

        If Client.Character.IsInGroup Then
            Client.Character.Party.ConvertToRaid()
            Client.Character.Party.GroupUpdate()
        End If
    End Sub
    Public Sub On_CMSG_GROUP_ASSISTANT_LEADER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim Access As Boolean = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_ASSISTANT_LEADER [{2:X} {3}]", Client.IP, Client.Port, GUID, Access)

        'DONE: Give access to the member and update client side if needed
        If (Client.Character.Party Is CHARACTERS(GUID).Party) AndAlso Client.Character.IsGroupLeader Then
            CType(CHARACTERS(GUID), CharacterObject).PartyRaidAssistant = Access
            Client.Character.Party.GroupUpdate()
        End If
    End Sub
    Public Sub On_CMSG_GROUP_CHANGE_SUB_GROUP(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim name As String = packet.GetString
        Dim subGroup As Byte = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_CHANGE_SUB_GROUP [{2}:{3}]", Client.IP, Client.Port, name, subGroup)

        If Client.Character.IsInGroup Then
            Dim j As Integer
            Dim i As Integer

            For j = subGroup * GROUP_SUBGROUPSIZE To ((subGroup + 1) * GROUP_SUBGROUPSIZE - 1)
                If Client.Character.Party.GroupMembers(j) Is Nothing Then
                    Exit For
                End If
            Next

            For i = 0 To Client.Character.Party.GroupMembers.Length - 1
                If (Not Client.Character.Party.GroupMembers(i) Is Nothing) AndAlso Client.Character.Party.GroupMembers(i).Name = name Then
                    Client.Character.Party.GroupMembers(j) = Client.Character.Party.GroupMembers(i)
                    Client.Character.Party.GroupMembers(i) = Nothing
                    If Client.Character.Party.GroupLeader = i Then Client.Character.Party.GroupLeader = j
                    Client.Character.Party.GroupUpdate()
                    Exit For
                End If
            Next
        End If
    End Sub
    Public Sub On_CMSG_GROUP_SWAP_SUB_GROUP(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim name1 As String = packet.GetString
        Dim name2 As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GROUP_SWAP_SUB_GROUP [{2}:{3}]", Client.IP, Client.Port, name1, name2)

        If Client.Character.IsInGroup Then
            Dim j As Integer
            Dim i As Integer

            For j = 0 To Client.Character.Party.GroupMembers.Length - 1
                If (Not Client.Character.Party.GroupMembers(j) Is Nothing) AndAlso Client.Character.Party.GroupMembers(j).Name = name2 Then
                    Exit For
                End If
            Next

            For i = 0 To Client.Character.Party.GroupMembers.Length - 1
                If (Not Client.Character.Party.GroupMembers(i) Is Nothing) AndAlso Client.Character.Party.GroupMembers(i).Name = name1 Then
                    Dim tmpPlayer As CharacterObject = Client.Character.Party.GroupMembers(j)
                    Client.Character.Party.GroupMembers(j) = Client.Character.Party.GroupMembers(i)
                    Client.Character.Party.GroupMembers(i) = tmpPlayer
                    tmpPlayer = Nothing

                    If Client.Character.Party.GroupLeader = i Then
                        Client.Character.Party.GroupLeader = j
                    ElseIf Client.Character.Party.GroupLeader = j Then
                        Client.Character.Party.GroupLeader = i
                    End If

                    Client.Character.Party.GroupUpdate()
                    Exit For
                End If
            Next
        End If
    End Sub


    Public Sub On_MSG_MINIMAP_PING(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim x As Single = packet.GetFloat
        Dim y As Single = packet.GetFloat

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_MINIMAP_PING [{2}:{3}]", Client.IP, Client.Port, x, y)

        If Client.Character.IsInGroup Then
            Dim response As New PacketClass(OPCODES.MSG_MINIMAP_PING)
            response.AddInt64(Client.Character.GUID)
            response.AddSingle(x)
            response.AddSingle(y)
            Client.Character.Party.Broadcast(response)
            response.Dispose()
        End If

    End Sub
    Public Sub On_MSG_GROUP_SET_PLAYER_ICON(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim icon As Byte = packet.GetInt8
        Dim GUID As Long = 0
        If icon <> &HFF Then GUID = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_GROUP_SET_PLAYER_ICON [{2:X}:{3}]", Client.IP, Client.Port, GUID, icon)

        If Client.Character.IsInGroup Then
            Dim response As New PacketClass(OPCODES.MSG_GROUP_SET_PLAYER_ICON)
            response.AddInt8(0)         'groupType?
            response.AddInt8(icon)      'groupIcon
            response.AddInt64(GUID)     'groupMember
            Client.Character.Party.Broadcast(response)
            response.Dispose()
        End If

    End Sub
    Public Sub On_MSG_RAID_READYCHECK(ByRef packet As PacketClass, ByRef Client As ClientClass)

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_RAID_READYCHECK", Client.IP, Client.Port)

        If Client.Character.IsGroupLeader Then
            Client.Character.Party.BroadcastToOther(packet, Client.Character)
        Else
            packet.GetInt16()
            Dim result As Byte = packet.GetInt8

            If result = 0 Then
                'DONE: Not ready
                Client.Character.Party.GetGroupLeader.Client.Send(packet)
            Else
                'DONE: Ready
                Dim response As New PacketClass(OPCODES.MSG_RAID_READYCHECK)
                response.AddInt64(Client.Character.GUID)
                Client.Character.Party.GetGroupLeader.Client.Send(response)
                response.Dispose()
            End If
        End If
    End Sub
    Public Sub On_MSG_GROUP_SET_DIFFICULTY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim difficulty As BaseParty.DungeonDifficulty = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_GROUP_SET_DIFFICULTY [{2}]", Client.IP, Client.Port, difficulty)

        Dim response As New PacketClass(OPCODES.MSG_GROUP_SET_DIFFICULTY)
        response.AddInt32(difficulty)
        If Client.Character.Party Is Nothing Then
            Client.Send(response)
        Else
            Client.Character.Party.GroupDungeonDifficulty = difficulty
            Client.Character.Party.Broadcast(response)
        End If
        response.Dispose()
    End Sub
    Public Sub On_CMSG_REQUEST_RAID_INFO(ByRef packet As PacketClass, ByRef Client As ClientClass)

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_REQUEST_RAID_INFO", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_RAID_INSTANCE_INFO)
        response.AddInt32(0)        'Instances Counts

        'response.AddInt32(0)        'MapID
        'response.AddInt32(0)        'TimeLeft
        'response.AddInt32(0)        'InstanceID

        Client.Send(response)
        response.Dispose()

    End Sub


#End Region


End Module
