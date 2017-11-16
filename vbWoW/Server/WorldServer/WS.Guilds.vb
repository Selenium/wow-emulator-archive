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


Public Module WS_Guilds



    'UMSG_UPDATE_GUILD = 148
    'UMSG_DELETE_GUILD_CHARTER = 704



#Region "WS.Guilds.Constants"


    Public Const PETITION_PRICE As Integer = 1000
    Public Const PETITION_ITEM As Integer = 5863       'Guild Charter, ItemFlags = &H2000
    Public Const TABARD_ITEM As Integer = 5976
    Public Const GUILD_RANK_MAX As Integer = 9
    Public Const GUILD_RANK_MIN As Integer = 0


#End Region
#Region "WS.Guilds.Petition"

    'ERR_PETITION_FULL
    'ERR_PETITION_NOT_SAME_SERVER
    'ERR_PETITION_NOT_ENOUGH_SIGNATURES
    'ERR_PETITION_CREATOR
    'ERR_PETITION_IN_GUILD
    'ERR_PETITION_ALREADY_SIGNED
    'ERR_PETITION_DECLINED_S
    'ERR_PETITION_SIGNED_S
    'ERR_PETITION_SIGNED
    'ERR_PETITION_OFFERED_S
    Public Enum PetitionSignError As Integer
        PETITIONSIGN_OK = 0                     ':Closes the window
        PETITIONSIGN_ALREADY_SIGNED = 1         'You have already signed that guild charter
        PETITIONSIGN_ALREADY_IN_GUILD = 2       'You are already in a guild
        PETITIONSIGN_CANT_SIGN_OWN = 3          'You can's sign own guild charter
        PETITIONSIGN_NOT_SERVER = 4             'That player is not from your server
    End Enum
    Public Enum PetitionTurnInError As Integer
        PETITIONTURNIN_OK = 0                   ':Closes the window
        PETITIONTURNIN_ALREADY_IN_GUILD = 2     'You are already in a guild
        PETITIONTURNIN_NEED_MORE_SIGNATURES = 4 'You need more signatures
    End Enum

    Public Sub SendPetitionActivate(ByRef c As CharacterObject, ByVal cGUID As Long)
        Dim packet As New PacketClass(OPCODES.SMSG_PETITION_SHOWLIST)
        packet.AddInt64(cGUID)

        Dim buffer As Byte() = {&H1, &H1, &H0, &H0, &H0, &HE7, &H16, &H0, &H0, &HEF, &H23, &H0, &H0, &HE8, &H3, &H0, &H0, &H1, &H0, &H0, &H0}
        packet.AddByteArray(buffer)

        c.Client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub On_CMSG_PETITION_SHOWLIST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PETITION_SHOWLIST [GUID={2:X}]", Client.IP, Client.Port, GUID)

        SendPetitionActivate(Client.Character, GUID)
    End Sub
    Public Sub On_CMSG_PETITION_BUY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        packet.GetInt32()
        packet.GetInt32()
        packet.GetInt32()
        Dim GuildName As String = packet.GetString
        '3x16 bytes
        'packet.GetInt32() 'MembersCount

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PETITION_BUY [GuildName={2}]", Client.IP, Client.Port, GuildName)

        If Client.Character.Copper < PETITION_PRICE Then Exit Sub

        Client.Character.Copper -= PETITION_PRICE
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, CType(Client.Character.Copper, Integer))

        'Client.Character.AddItem(PETITION_ITEM)
        Dim tmpItem As New ItemObject(PETITION_ITEM, Client.Character.GUID)
        tmpItem.StackCount = 1
        tmpItem.AddEnchantment(tmpItem.GUID - GUID_ITEM, 0, 0, 0)
        If Client.Character.ItemADD(tmpItem) Then
            'Save petition into database
            Database.Update(String.Format("INSERT INTO adb_guilds_petition (petition_id, petition_itemGuid, petition_owner, petition_name, petition_signedMembers) VALUES ({0}, {0}, {1}, '{2}', 0);", tmpItem.GUID - GUID_ITEM, Client.Character.GUID - GUID_PLAYER, GuildName))
        Else
            'No free inventory slot
            tmpItem.Delete()
        End If
    End Sub

    Public Sub SendPetitionSignatures(ByRef c As CharacterObject, ByVal iGUID As Long)
        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds_petition WHERE petition_itemGuid = " & iGUID - GUID_ITEM & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Exit Sub



        Dim response As New PacketClass(OPCODES.SMSG_PETITION_SHOW_SIGNATURES)
        response.AddInt64(iGUID)                                                        'ItemGUID
        response.AddInt64(MySQLQuery.Rows(0).Item("petition_owner"))                    'GuildOwner
        response.AddInt32(MySQLQuery.Rows(0).Item("petition_id"))                       'PetitionGUID
        response.AddInt8(MySQLQuery.Rows(0).Item("petition_signedMembers"))             'PlayersSigned

        For i As Byte = 1 To MySQLQuery.Rows(0).Item("petition_signedMembers")
            response.AddInt64(MySQLQuery.Rows(0).Item("petition_signedMember" & i))                     'SignedGUID
            response.AddInt32(i)                                                                        'Unk
        Next

        c.Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_PETITION_SHOW_SIGNATURES(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PETITION_SHOW_SIGNATURES [GUID={2:X}]", Client.IP, Client.Port, GUID)

        SendPetitionSignatures(Client.Character, GUID)
    End Sub
    Public Sub On_CMSG_PETITION_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim PetitionGUID As Integer = packet.GetInt32
        Dim ItemGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PETITION_QUERY [pGUID={3} iGUID={2:X}]", Client.IP, Client.Port, ItemGUID, PetitionGUID)


        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds_petition WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Exit Sub




        Dim response As New PacketClass(OPCODES.SMSG_PETITION_QUERY_RESPONSE)
        response.AddInt32(MySQLQuery.Rows(0).Item("petition_id"))               'PetitionGUID
        response.AddInt64(MySQLQuery.Rows(0).Item("petition_owner"))            'GuildOwner
        response.AddString(MySQLQuery.Rows(0).Item("petition_name"))            'GuildName
        response.AddInt8(0)         'Unk1
        response.AddInt32(1)        'Unk2
        response.AddInt32(0)        'Unk3
        response.AddInt32(9)        'PlayersLeft
        '9x int32
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        response.AddInt32(0)
        '1x int16
        response.AddInt16(0)
        Client.Send(response)
        response.Dispose()
    End Sub


    Public Sub On_MSG_PETITION_RENAME(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim ItemGUID As Long = packet.GetInt64
        Dim NewName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_PETITION_RENAME [NewName={3} GUID={2:X}]", Client.IP, Client.Port, ItemGUID, NewName)

        Database.Update("UPDATE adb_guilds_petition SET petition_name = '" & NewName & "' WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & ";")


        'DONE: Update client-side name information
        Dim response As New PacketClass(OPCODES.MSG_PETITION_RENAME)
        response.AddInt64(ItemGUID)
        response.AddString(NewName)
        response.AddInt32(ItemGUID - GUID_ITEM)
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_TURN_IN_PETITION(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim ItemGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TURN_IN_PETITION [GUID={2:X}]", Client.IP, Client.Port, ItemGUID)


        'DONE: Check if already in guild
        If Client.Character.IsInGuild Then
            Dim response As New PacketClass(OPCODES.SMSG_TURN_IN_PETITION_RESULTS)
            response.AddInt32(PetitionTurnInError.PETITIONTURNIN_ALREADY_IN_GUILD)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        'DONE: Get info
        Dim q As New DataTable
        Database.Query("SELECT * FROM adb_guilds_petition WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & " LIMIT 1;", q)
        If q.Rows.Count = 0 Then Exit Sub

        'DONE: Check required signs
        If q.Rows(0).Item("petition_signedMembers") < 1 Then
            Dim response As New PacketClass(OPCODES.SMSG_TURN_IN_PETITION_RESULTS)
            response.AddInt32(PetitionTurnInError.PETITIONTURNIN_NEED_MORE_SIGNATURES)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If


        'DONE: Create guild and add members
        Dim q2 As New DataTable
        Database.Query(String.Format("INSERT INTO adb_guilds (guild_name, guild_leader, guild_cYear, guild_cMonth, guild_cDay) VALUES (""{0}"", {1}, {2}, {3}, {4}); SELECT guild_id FROM adb_guilds WHERE guild_name = ""{0}"";", q.Rows(0).Item("petition_name"), Client.Character.GUID, Now.Year - 2006, Now.Month, Now.Day), q2)

        AddCharacterToGuild(Client.Character, q2.Rows(0).Item("guild_id"), 0)

        'DONE: Adding 9 more signed characters
        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember1"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember1"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember1"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember2"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember2"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember2"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember3"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember3"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember3"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember4"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember4"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember4"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember5"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember5"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember5"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember6"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember6"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember6"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember7"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember7"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember7"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember8"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember8"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember8"), Long), q2.Rows(0).Item("guild_id"))
        End If

        If CHARACTERS.ContainsKey(CType(q.Rows(0).Item("petition_signedMember9"), Long)) Then
            AddCharacterToGuild(CType(CHARACTERS(CType(q.Rows(0).Item("petition_signedMember9"), Long)), CharacterObject), q2.Rows(0).Item("guild_id"))
        Else
            AddCharacterToGuild(CType(q.Rows(0).Item("petition_signedMember9"), Long), q2.Rows(0).Item("guild_id"))
        End If

        'DONE: Delete guild charter item
        Client.Character.ItemREMOVE(ItemGUID, True, True)
    End Sub
    Public Sub On_CMSG_OFFER_PETITION(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim ItemGUID As Long = packet.GetInt64
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_OFFER_PETITION [GUID={2:X} Petition={3}]", Client.IP, Client.Port, GUID, ItemGUID)

        SendPetitionSignatures(CHARACTERS(GUID), ItemGUID)
    End Sub
    Public Sub On_CMSG_PETITION_SIGN(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim ItemGUID As Long = packet.GetInt64
        Dim Unk As Integer = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PETITION_SIGN [GUID={2:X} Unk={3}]", Client.IP, Client.Port, ItemGUID, Unk)





        Dim MySQLQuery As New DataTable
        Database.Query("SELECT petition_signedMembers, petition_owner FROM adb_guilds_petition WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Exit Sub

        Database.Update("UPDATE adb_guilds_petition SET petition_signedMembers = petition_signedMembers + 1, petition_signedMember" & (MySQLQuery.Rows(0).Item("petition_signedMembers") + 1) & " = " & Client.Character.GUID & " WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & ";")




        'DONE: Send result to both players
        Dim response As New PacketClass(OPCODES.SMSG_PETITION_SIGN_RESULTS)
        response.AddInt64(ItemGUID)
        response.AddInt64(Client.Character.GUID)
        response.AddInt32(PetitionSignError.PETITIONSIGN_OK)
        Client.SendMultiplyPackets(response)
        CHARACTERS(CType(MySQLQuery.Rows(0).Item("petition_owner"), Long)).Client.SendMultiplyPackets(response)
        response.Dispose()
    End Sub
    Public Sub On_MSG_PETITION_DECLINE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim ItemGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_PETITION_DECLINE [GUID={2:X}]", Client.IP, Client.Port, ItemGUID)

        'DONE: Get petition owner
        Dim q As New DataTable
        Database.Query("SELECT petition_owner FROM adb_guilds_petition WHERE petition_itemGuid = " & ItemGUID - GUID_ITEM & " LIMIT 1;", q)


        'DONE: Send message to players
        Dim response As New PacketClass(OPCODES.MSG_PETITION_DECLINE)
        response.AddInt64(ItemGUID)
        response.AddInt64(Client.Character.GUID)
        Client.SendMultiplyPackets(response)
        If q.Rows.Count > 0 Then CHARACTERS(CType(q.Rows(0).Item("petition_owner"), Long)).Client.SendMultiplyPackets(response)
        response.Dispose()
    End Sub



#End Region
#Region "WS.Guilds.Handlers"

    'Basic Tabard Framework
    Public Sub SendTabardActivate(ByRef c As CharacterObject, ByVal cGUID As Long)
        Dim packet As New PacketClass(OPCODES.MSG_TABARDVENDOR_ACTIVATE)
        packet.AddInt64(cGUID)
        c.Client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub On_MSG_TABARDVENDOR_ACTIVATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_TABARDVENDOR_ACTIVATE [GUID={2}]", Client.IP, Client.Port, GUID)

        SendTabardActivate(Client.Character, GUID)
    End Sub

    'Basic Guild Framework
    Public Sub AddCharacterToGuild(ByRef c As CharacterObject, ByVal GuildID As Integer, Optional ByVal GuildRank As Integer = 4)
        Database.Update(String.Format("UPDATE adb_characters SET char_guildId = {0}, char_guildRank = {2}, char_guildOffNote = '', char_guildPNote = '' WHERE char_guid = {1};", GuildID, c.GUID, GuildRank))

        c.GuildID = GuildID
        c.GuildRank = GuildRank
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDID, c.GuildID)
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDRANK, c.GuildRank)
        c.SendCharacterUpdate(True)
    End Sub
    Public Sub AddCharacterToGuild(ByVal GUID As Long, ByVal GuildID As Integer, Optional ByVal GuildRank As Integer = 4)
        Database.Update(String.Format("UPDATE adb_characters SET char_guildId = {0}, char_guildRank = {2}, char_guildOffNote = '', char_guildPNote = '' WHERE char_guid = {1};", GuildID, GUID, GuildRank))
    End Sub
    Public Sub RemoveCharacterFromGuild(ByRef c As CharacterObject)
        Database.Update(String.Format("UPDATE adb_characters SET char_guildId = {0}, char_guildRank = 0, char_guildOffNote = '', char_guildPNote = '' WHERE char_guid = {1};", 0, c.GUID))

        c.GuildID = 0
        c.GuildRank = 0
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDID, 0)
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDRANK, 0)
        c.SendCharacterUpdate(True)
    End Sub
    Public Sub RemoveCharacterFromGuild(ByVal GUID As Long)
        Database.Update(String.Format("UPDATE adb_characters SET char_guildId = {0}, char_guildRank = 0, char_guildOffNote = '', char_guildPNote = '' WHERE char_guid = {1};", 0, GUID))
    End Sub
    Public Sub BroadcastToGuild(ByRef packet As PacketClass, ByVal GuildID As Integer)
        Dim q As New DataTable
        Database.Query(String.Format("SELECT char_guid FROM adb_characters WHERE char_guildID = {0} AND char_online = 1;", GuildID), q)

        For Each r As DataRow In q.Rows
            If CHARACTERS.ContainsKey(CType(r.Item("char_guid"), Long)) Then
                CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).Client.SendMultiplyPackets(packet)
            End If
        Next
    End Sub
    Public Sub BroadcastChatMessageGuild(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES, ByVal GuildID As Integer)
        'DONE: Check for guild member
        If Sender.GuildID = 0 Then
            SendGuildResult(Sender.Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        End If


        'DONE: Check for rights to speak
        If Not Sender.IsGuildRightSet(GuildRankRights.GR_RIGHT_GCHATSPEAK) Then
            SendGuildResult(Sender.Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If




        'DONE: Build packet
        Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_GUILD, Language, GetChatFlag(Sender))

        'DONE: Send message to everyone
        Dim q As New DataTable
        Database.Query(String.Format("SELECT char_guid FROM adb_characters WHERE char_guildID = {0} AND char_online = 1;", GuildID), q)

        For Each r As DataRow In q.Rows
            If CHARACTERS.ContainsKey(CType(r.Item("char_guid"), Long)) Then
                If CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).IsGuildRightSet(GuildRankRights.GR_RIGHT_GCHATLISTEN) Then
                    CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).Client.SendMultiplyPackets(packet)
                End If
            End If
        Next

        packet.Dispose()
    End Sub
    Public Sub BroadcastChatMessageOfficer(ByRef Sender As CharacterObject, ByVal Message As String, ByVal Language As LANGUAGES, ByVal GuildID As Integer)
        'DONE: Check for guild member
        If Sender.GuildID = 0 Then
            SendGuildResult(Sender.Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        End If

        'DONE: Check for rights to speak
        If Not Sender.IsGuildRightSet(GuildRankRights.GR_RIGHT_OFFCHATSPEAK) Then
            SendGuildResult(Sender.Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If




        'DONE: Build packet
        Dim packet As PacketClass = BuildChatMessage(Sender.GUID, Message, ChatMsg.CHAT_MSG_OFFICER, Language, GetChatFlag(Sender))

        'DONE: Send message to everyone
        Dim q As New DataTable
        Database.Query(String.Format("SELECT char_guid FROM adb_characters WHERE char_guildID = {0} AND char_online = 1;", GuildID), q)

        For Each r As DataRow In q.Rows
            If CHARACTERS.ContainsKey(CType(r.Item("char_guid"), Long)) Then
                If CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).IsGuildRightSet(GuildRankRights.GR_RIGHT_OFFCHATLISTEN) Then
                    CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).Client.SendMultiplyPackets(packet)
                End If
            End If
        Next

        packet.Dispose()
    End Sub
    Public Sub SendGuildQuery(ByRef Client As ClientClass, ByVal GuildID As Integer)
        'WARNING: This opcode is used also in character enum, so there must not be used any references to CharacterObject, only ClientClass

        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds WHERE guild_id = " & GuildID & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("GuildID " & GuildID & " not found in database.")

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_QUERY_RESPONSE)
        response.AddInt32(GuildID)
        response.AddString(MySQLQuery.Rows(0).Item("guild_name"))
        'If MySQLQuery.Rows(0).Item("guild_rank0") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank0"))
        'If MySQLQuery.Rows(0).Item("guild_rank1") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank1"))
        'If MySQLQuery.Rows(0).Item("guild_rank2") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank2"))
        'If MySQLQuery.Rows(0).Item("guild_rank3") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank3"))
        'If MySQLQuery.Rows(0).Item("guild_rank4") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank4"))
        'If MySQLQuery.Rows(0).Item("guild_rank5") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank5"))
        'If MySQLQuery.Rows(0).Item("guild_rank6") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank6"))
        'If MySQLQuery.Rows(0).Item("guild_rank7") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank7"))
        'If MySQLQuery.Rows(0).Item("guild_rank8") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank8"))
        'If MySQLQuery.Rows(0).Item("guild_rank9") <> "" Then response.AddString(MySQLQuery.Rows(0).Item("guild_rank9"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank0"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank1"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank2"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank3"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank4"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank5"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank6"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank7"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank8"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_rank9"))
        response.AddInt32(CType(MySQLQuery.Rows(0).Item("guild_tEmblemStyle"), Integer))
        response.AddInt32(CType(MySQLQuery.Rows(0).Item("guild_tEmblemColor"), Integer))
        response.AddInt32(CType(MySQLQuery.Rows(0).Item("guild_tBorderStyle"), Integer))
        response.AddInt32(CType(MySQLQuery.Rows(0).Item("guild_tBorderColor"), Integer))
        response.AddInt32(CType(MySQLQuery.Rows(0).Item("guild_tBackgroundColor"), Integer))
        response.AddInt32(0)
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub SendGuildRoster(ByRef c As CharacterObject)
        If c.GuildID = 0 Then Exit Sub


        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds WHERE guild_id = " & c.GuildID & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("GuildID " & c.GuildID & " not found in database.")

        'DONE: Count the ranks
        Dim guildRanksCount As Byte = 0
        If MySQLQuery.Rows(0).Item("guild_rank0") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank1") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank2") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank3") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank4") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank5") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank6") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank7") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank8") <> "" Then guildRanksCount += 1
        If MySQLQuery.Rows(0).Item("guild_rank9") <> "" Then guildRanksCount += 1

        'DONE: Count the members
        Dim Members As New DataTable
        Database.Query("SELECT char_online, char_guid, char_name, char_class, char_level, char_zone_id, char_guildRank, char_guildPNote, char_guildOffNote FROM adb_characters WHERE char_guildId = " & c.GuildID & ";", Members)

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_ROSTER)
        response.AddInt32(Members.Rows.Count)
        response.AddString(MySQLQuery.Rows(0).Item("guild_MOTD"))
        response.AddString(MySQLQuery.Rows(0).Item("guild_info"))
        response.AddInt32(guildRanksCount)
        If MySQLQuery.Rows(0).Item("guild_rank0") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank0_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank1") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank1_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank2") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank2_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank3") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank3_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank4") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank4_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank5") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank5_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank6") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank6_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank7") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank7_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank8") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank8_Rights"))
        If MySQLQuery.Rows(0).Item("guild_rank9") <> "" Then response.AddInt32(MySQLQuery.Rows(0).Item("guild_rank9_Rights"))

        Dim i As Integer
        For i = 0 To Members.Rows.Count - 1
            If Members.Rows(i).Item("char_online") = 1 Then
                response.AddInt64(Members.Rows(i).Item("char_guid"))
                response.AddInt8(1)                         'OnlineFlag
                response.AddString(Members.Rows(i).Item("char_name"))
                response.AddInt32(Members.Rows(i).Item("char_guildRank"))
                response.AddInt8(Members.Rows(i).Item("char_level"))
                response.AddInt8(Members.Rows(i).Item("char_class"))
                response.AddInt32(Members.Rows(i).Item("char_zone_id"))
                response.AddString(Members.Rows(i).Item("char_guildPNote"))
                response.AddString(Members.Rows(i).Item("char_guildOffNote"))
            Else
                response.AddInt64(Members.Rows(i).Item("char_guid"))
                response.AddInt8(0)                         'OfflineFlag
                response.AddString(Members.Rows(i).Item("char_name"))
                response.AddInt32(Members.Rows(i).Item("char_guildRank"))
                response.AddInt8(Members.Rows(i).Item("char_level"))
                response.AddInt8(Members.Rows(i).Item("char_class"))
                response.AddInt32(Members.Rows(i).Item("char_zone_id"))
                response.AddInt32(9000)
                response.AddString(Members.Rows(i).Item("char_guildPNote"))
                response.AddString(Members.Rows(i).Item("char_guildOffNote"))
            End If
        Next


        c.Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_GUILD_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GuildID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_QUERY [{2}]", Client.IP, Client.Port, GuildID)

        SendGuildQuery(Client, GuildID)
    End Sub
    Public Sub On_CMSG_GUILD_ROSTER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        'packet.GetInt16()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_ROSTER", Client.IP, Client.Port)

        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_GUILD_CREATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim guildName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_CREATE [{2}]", Client.IP, Client.Port, guildName)

        If Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_ALREADY_IN_GUILD)
            Exit Sub
        End If

        'DONE: Create guild data
        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("INSERT INTO adb_guilds (guild_name, guild_leader, guild_cYear, guild_cMonth, guild_cDay) VALUES (""{0}"", {1}, {2}, {3}, {4}); SELECT guild_id FROM adb_guilds WHERE guild_name = ""{0}"";", guildName, Client.Character.GUID, Now.Year - 2006, Now.Month, Now.Day), MySQLQuery)

        AddCharacterToGuild(Client.Character, MySQLQuery.Rows(0).Item("guild_id"), 0)
    End Sub
    Public Sub On_CMSG_GUILD_INFO(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_INFO", Client.IP, Client.Port)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        End If

        'DONE: Get guild data
        Dim q As New DataTable
        Database.Query(String.Format("SELECT guild_name, guild_cYear, guild_cMonth, guild_cDay FROM adb_guilds WHERE guild_id = " & Client.Character.GuildID & ";"), q)
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_INFO)
        response.AddString(q.Rows(0).Item("guild_name"))
        response.AddInt32(q.Rows(0).Item("guild_cDay"))
        response.AddInt32(q.Rows(0).Item("guild_cMonth"))
        response.AddInt32(q.Rows(0).Item("guild_cYear"))
        response.AddInt32(0)
        response.AddInt32(0)
        Client.Send(response)
        response.Dispose()
    End Sub



    'Guild Leader Options
    Public Enum GuildRankRights
        GR_RIGHT_EMPTY = &H40
        GR_RIGHT_GCHATLISTEN = &H41
        GR_RIGHT_GCHATSPEAK = &H42
        GR_RIGHT_OFFCHATLISTEN = &H44
        GR_RIGHT_OFFCHATSPEAK = &H48
        GR_RIGHT_PROMOTE = &HC0
        GR_RIGHT_DEMOTE = &H140
        GR_RIGHT_INVITE = &H50
        GR_RIGHT_REMOVE = &H60
        GR_RIGHT_SETMOTD = &H1040
        GR_RIGHT_EPNOTE = &H2040
        GR_RIGHT_VIEWOFFNOTE = &H4040
        GR_RIGHT_EOFFNOTE = &H8040
        GR_RIGHT_ALL = &HF1FF
    End Enum
    Public Sub On_CMSG_GUILD_RANK(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim rankID As Integer = packet.GetInt32
        Dim rankRights As Integer = packet.GetInt32
        Dim rankName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_RANK [{2}:{3}:{4}]", Client.IP, Client.Port, rankID, rankRights, rankName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_rank{1} = ""{2}"", guild_rank{1}_Rights = {3} WHERE guild_id = {0};", Client.Character.GuildID, rankID, rankName.Replace("""", "_").Replace("'", "_"), rankRights))

        SendGuildQuery(Client, Client.Character.GuildID)
        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_GUILD_ADD_RANK(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim NewRankName As String = packet.GetString()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_ADD_RANK [{2}]", Client.IP, Client.Port, NewRankName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If



        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds WHERE guild_id = " & Client.Character.GuildID & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("GuildID " & Client.Character.GuildID & " not found in database.")

        Dim GuildPos As Integer
        If MySQLQuery.Rows(0).Item("guild_rank0") = "" Then
            GuildPos = 0
        ElseIf MySQLQuery.Rows(0).Item("guild_rank1") = "" Then
            GuildPos = 1
        ElseIf MySQLQuery.Rows(0).Item("guild_rank2") = "" Then
            GuildPos = 2
        ElseIf MySQLQuery.Rows(0).Item("guild_rank3") = "" Then
            GuildPos = 3
        ElseIf MySQLQuery.Rows(0).Item("guild_rank4") = "" Then
            GuildPos = 4
        ElseIf MySQLQuery.Rows(0).Item("guild_rank5") = "" Then
            GuildPos = 5
        ElseIf MySQLQuery.Rows(0).Item("guild_rank6") = "" Then
            GuildPos = 6
        ElseIf MySQLQuery.Rows(0).Item("guild_rank7") = "" Then
            GuildPos = 7
        ElseIf MySQLQuery.Rows(0).Item("guild_rank8") = "" Then
            GuildPos = 8
        ElseIf MySQLQuery.Rows(0).Item("guild_rank9") = "" Then
            GuildPos = 9
        Else
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_rank{1} = ""{2}"", guild_rank{1}_Rights = {3} WHERE guild_id = {0};", Client.Character.GuildID, GuildPos, NewRankName.Replace("""", "_").Replace("'", "_"), GuildRankRights.GR_RIGHT_GCHATLISTEN Or GuildRankRights.GR_RIGHT_GCHATSPEAK))

        SendGuildQuery(Client, Client.Character.GuildID)
        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_GUILD_DEL_RANK(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_DEL_RANK", Client.IP, Client.Port)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If


        Dim MySQLQuery As New DataTable
        Database.Query("SELECT * FROM adb_guilds WHERE guild_id = " & Client.Character.GuildID & ";", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("GuildID " & Client.Character.GuildID & " not found in database.")

        Dim GuildPos As Integer
        If MySQLQuery.Rows(0).Item("guild_rank9") <> "" Then
            GuildPos = 9
        ElseIf MySQLQuery.Rows(0).Item("guild_rank8") <> "" Then
            GuildPos = 8
        ElseIf MySQLQuery.Rows(0).Item("guild_rank7") <> "" Then
            GuildPos = 7
        ElseIf MySQLQuery.Rows(0).Item("guild_rank6") <> "" Then
            GuildPos = 6
        ElseIf MySQLQuery.Rows(0).Item("guild_rank5") <> "" Then
            GuildPos = 5
        ElseIf MySQLQuery.Rows(0).Item("guild_rank4") <> "" Then
            GuildPos = 4
        ElseIf MySQLQuery.Rows(0).Item("guild_rank3") <> "" Then
            GuildPos = 3
        ElseIf MySQLQuery.Rows(0).Item("guild_rank2") <> "" Then
            GuildPos = 2
        ElseIf MySQLQuery.Rows(0).Item("guild_rank1") <> "" Then
            GuildPos = 1
        ElseIf MySQLQuery.Rows(0).Item("guild_rank0") <> "" Then
            GuildPos = 0
        Else
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_rank{1} = ""{2}"", guild_rank{1}_Rights = {3} WHERE guild_id = {0};", Client.Character.GuildID, GuildPos, "", 0))

        SendGuildQuery(Client, Client.Character.GuildID)
        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_SET_GUILD_INFORMATION(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim guildInfo As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SET_GUILD_INFORMATION", Client.IP, Client.Port)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_info = ""{1}"" WHERE guild_id = {0};", Client.Character.GuildID, guildInfo.Replace("""", "_").Replace("'", "_")))
    End Sub
    Public Sub On_CMSG_GUILD_LEADER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_LEADER [{2}]", Client.IP, Client.Port, playerName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        'DONE: Find new leader's GUID
        Dim MySQLQuery As New DataTable
        Database.Query("SELECT char_guid, char_guildId FROM adb_characters WHERE char_name = '" & playerName & "';", MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        ElseIf MySQLQuery.Rows(0).Item("char_guildId") <> Client.Character.GuildID Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD_S, playerName)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_leader = ""{1}"" WHERE guild_id = {0};", Client.Character.GuildID, MySQLQuery.Rows(0).Item("char_guid")))

        'DONE: Send notify message
        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.LEADER_CHANGED)
        response.AddInt8(2)
        response.AddString(Client.Character.Name)
        response.AddString(playerName)
        BroadcastToGuild(response, Client.Character.GuildID)
        response.Dispose()
    End Sub
    Public Sub On_MSG_SAVE_GUILD_EMBLEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim unk0 As Integer = packet.GetInt32
        Dim unk1 As Integer = packet.GetInt32
        Dim tEmblemStyle As Integer = packet.GetInt32
        Dim tEmblemColor As Integer = packet.GetInt32
        Dim tBorderStyle As Integer = packet.GetInt32
        Dim tBorderColor As Integer = packet.GetInt32
        Dim tBackgroundColor As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_SAVE_GUILD_EMBLEM [{2},{3}] [{4}:{5}:{6}:{7}:{8}]", Client.IP, Client.Port, unk0, unk1, tEmblemStyle, tEmblemColor, tBorderStyle, tBorderColor, tBackgroundColor)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_tEmblemStyle = {1}, guild_tEmblemColor = {2}, guild_tBorderStyle = {3}, guild_tBorderColor = {4}, guild_tBackgroundColor = {5} WHERE guild_id = {0};", Client.Character.GuildID, tEmblemStyle, tEmblemColor, tBorderStyle, tBorderColor, tBackgroundColor))

        SendGuildQuery(Client, Client.Character.GuildID)

        Dim packet_event As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        packet_event.AddInt8(GuildEvent.TABARDCHANGE)
        packet_event.AddInt32(Client.Character.GuildID)
        Client.Send(packet_event)
        packet_event.Dispose()

        'TODO: This tabard design costs 10g!
    End Sub
    Public Sub On_CMSG_GUILD_DISBAND(ByRef packet As PacketClass, ByRef Client As ClientClass)
        'packet.GetInt16()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_DISBAND", Client.IP, Client.Port)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If


        'DONE: Clear all members
        Dim q As New DataTable
        Database.Query(String.Format("SELECT char_guid FROM adb_characters WHERE char_guildID = {0};", Client.Character.GuildID), q)

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.DISBANDED)
        response.AddInt8(0)

        Dim GuildID As Integer = Client.Character.GuildID

        For Each r As DataRow In q.Rows
            If CHARACTERS.ContainsKey(CType(r.Item("char_guid"), Long)) Then
                RemoveCharacterFromGuild(CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject))
                CType(CHARACTERS(CType(r.Item("char_guid"), Long)), CharacterObject).Client.SendMultiplyPackets(response)
            Else
                RemoveCharacterFromGuild(CType(r.Item("char_guid"), Long))
            End If
        Next

        response.Dispose()

        'DONE: Delete guild information
        Database.Update("DELETE FROM adb_guilds WHERE guild_id = " & GuildID & ";")
    End Sub

    'Members Options
    Public Sub SendGuildMOTD(ByRef c As CharacterObject)
        If c.IsInGuild Then
            Dim MySQLQuery As New DataTable
            Database.Query("SELECT guild_MOTD FROM adb_guilds WHERE guild_id = " & c.GuildID & ";", MySQLQuery)
            If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("GuildID " & c.GuildID & " not found in database.")

            If MySQLQuery.Rows(0).Item("guild_MOTD") <> "" Then
                Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
                response.AddInt8(GuildEvent.MOTD)
                response.AddInt8(1)
                response.AddString(MySQLQuery.Rows(0).Item("guild_MOTD"))
                c.Client.Send(response)
                response.Dispose()
            End If
        End If
    End Sub
    Public Sub On_CMSG_GUILD_MOTD(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim motd As String = ""
        If packet.Length <> 4 Then motd = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_MOTD", Client.IP, Client.Port)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_SETMOTD) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_guilds SET guild_MOTD = ""{1}"" WHERE guild_id = ""{0}"";", Client.Character.GuildID, motd.Replace("""", "_").Replace("'", "_")))

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.MOTD)
        response.AddInt8(1)
        response.AddString(motd)
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_GUILD_SET_OFFICER_NOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString
        Dim Note As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_SET_OFFICER_NOTE [{2}]", Client.IP, Client.Port, playerName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_EOFFNOTE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_characters SET char_guildOffNote = ""{1}"" WHERE char_name = ""{0}"";", playerName, Note.Replace("""", "_").Replace("'", "_")))

        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_GUILD_SET_PUBLIC_NOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString
        Dim Note As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_SET_PUBLIC_NOTE [{2}]", Client.IP, Client.Port, playerName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_EPNOTE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        Database.Update(String.Format("UPDATE adb_characters SET char_guildPNote = ""{1}"" WHERE char_name = ""{0}"";", playerName, Note.Replace("""", "_").Replace("'", "_")))

        SendGuildRoster(Client.Character)
    End Sub
    Public Sub On_CMSG_GUILD_REMOVE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_REMOVE [{2}]", Client.IP, Client.Port, playerName)

        'DONE: Player1 checks
        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_REMOVE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        'DONE: Find player2's guid
        Dim q As New DataTable
        Database.Query("SELECT char_guid FROM adb_characters WHERE char_name = '" & playerName.Replace("'", "_") & "';", q)

        'DONE: Removed checks
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        ElseIf Not CHARACTERS.ContainsKey(CType(q.Rows(0).Item("char_guid"), Long)) Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        End If

        Dim c As CharacterObject = CType(CHARACTERS(CType(q.Rows(0).Item("char_guid"), Long)), CharacterObject)

        If c.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_QUIT_S, GuildError.GUILD_LEADER_LEAVE)
            Exit Sub
        End If

        RemoveCharacterFromGuild(c)

        'DONE: Send guild event
        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.REMOVED)
        response.AddInt8(2)
        response.AddString(playerName)
        response.AddString(c.Name)
        BroadcastToGuild(response, c.GuildID)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_GUILD_PROMOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_PROMOTE [{2}]", Client.IP, Client.Port, playerName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_PROMOTE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        'DONE: Find promoted player's guid
        Dim q As New DataTable
        Database.Query("SELECT char_guid FROM adb_characters WHERE char_name = '" & playerName.Replace("'", "_") & "';", q)

        'DONE: Promoted checks
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_NAME_INVALID)
            Exit Sub
        ElseIf Not CHARACTERS.ContainsKey(CType(q.Rows(0).Item("char_guid"), Long)) Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        End If
        Dim c As CharacterObject = CType(CHARACTERS(CType(q.Rows(0).Item("char_guid"), Long)), CharacterObject)
        If c.GuildID <> Client.Character.GuildID Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD_S, playerName)
            Exit Sub
        ElseIf c.GuildRank = GUILD_RANK_MIN Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If



        'DONE: Do the real update            
        c.GuildRank -= 1
        Database.Update(String.Format("UPDATE adb_characters SET char_guildRank = {0} WHERE char_guid = {1};", c.GuildRank, c.GUID))
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDRANK, c.GuildRank)
        c.SendCharacterUpdate(True)

        'DONE: Get rank name
        'q.Clear()
        'Database.Query(String.Format("SELECT guild_rank{0} FROM adb_guilds WHERE guild_id = {1} LIMIT 1;", c.GuildRank, c.GuildID), q)
        'If q.Rows.Count = 0 Then Throw New ApplicationException("Guild rank " & c.GuildRank & " for guild " & c.GuildID & " not found!")

        'TODO: Send event to guild
        'Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        'response.AddInt8(GuildEvent.PROMOTION)
        'response.AddInt8(2)
        'response.AddString(c.Name)
        'response.AddString(q.Rows(0).Item("guild_rank" & c.GuildRank))
        'BroadcastToGuild(response, c.GuildID)
        'response.Dispose()
    End Sub
    Public Sub On_CMSG_GUILD_DEMOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_DEMOTE [{2}]", Client.IP, Client.Port, playerName)

        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_PROMOTE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        'DONE: Find promoted player's guid
        Dim q As New DataTable
        Database.Query("SELECT char_guid FROM adb_characters WHERE char_name = '" & playerName.Replace("'", "_") & "';", q)

        'DONE: Promoted checks
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_NAME_INVALID)
            Exit Sub
        ElseIf Not CHARACTERS.ContainsKey(CType(q.Rows(0).Item("char_guid"), Long)) Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        End If
        Dim c As CharacterObject = CType(CHARACTERS(CType(q.Rows(0).Item("char_guid"), Long)), CharacterObject)
        If c.GuildID <> Client.Character.GuildID Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD_S, playerName)
            Exit Sub
        ElseIf c.GuildRank = GUILD_RANK_MAX Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If


        'DONE: Max defined rank check
        q.Clear()
        Database.Query(String.Format("SELECT guild_rank{0} FROM adb_guilds WHERE guild_id = {1} LIMIT 1;", c.GuildRank + 1, c.GuildID), q)
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        ElseIf Trim(q.Rows(0).Item("guild_rank" & c.GuildRank + 1)) = "" Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If




        'DONE: Do the real update            
        c.GuildRank += 1
        Database.Update(String.Format("UPDATE adb_characters SET char_guildRank = {0} WHERE char_guid = {1};", c.GuildRank, c.GUID))
        c.SetUpdateFlag(EPlayerFields.PLAYER_GUILDRANK, c.GuildRank)
        c.SendCharacterUpdate(True)

        'DONE: Get rank name
        'q.Clear()
        'Database.Query(String.Format("SELECT guild_rank{0} FROM adb_guilds WHERE guild_id = {1} LIMIT 1;", c.GuildRank, c.GuildID), q)
        'If q.Rows.Count = 0 Then Throw New ApplicationException("Guild rank " & c.GuildRank & " for guild " & c.GuildID & " not found!")

        'TODO: Send event to guild
        'Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        'response.AddInt8(GuildEvent.DEMOTION)
        'response.AddInt8(2)
        'response.AddString(c.Name)
        'response.AddString(q.Rows(0).Item(0))
        'BroadcastToGuild(response, c.GuildID)
        'response.Dispose()
    End Sub

    'User Options
    Public Sub On_CMSG_GUILD_INVITE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim playerName As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_INVITE [{2}]", Client.IP, Client.Port, playerName)

        'DONE: Inviter checks
        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Not Client.Character.IsGuildRightSet(GuildRankRights.GR_RIGHT_INVITE) Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PERMISSIONS)
            Exit Sub
        End If

        'DONE: Find invited player's guid
        Dim q As New DataTable
        Database.Query("SELECT char_guid FROM adb_characters WHERE char_name = '" & playerName.Replace("'", "_") & "';", q)

        'DONE: Invited checks
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_NAME_INVALID)
            Exit Sub
        ElseIf Not CHARACTERS.ContainsKey(CType(q.Rows(0).Item("char_guid"), Long)) Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_PLAYER_NOT_FOUND, playerName)
            Exit Sub
        End If

        Dim c As CharacterObject = CType(CHARACTERS(CType(q.Rows(0).Item("char_guid"), Long)), CharacterObject)
        If c.GuildID <> 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.ALREADY_IN_GUILD, playerName)
            Exit Sub
        ElseIf c.Side <> Client.Character.Side Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.GUILD_NOT_ALLIED, playerName)
            Exit Sub
        ElseIf c.GuildInvited <> 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_INVITE_S, GuildError.ALREADY_INVITED_TO_GUILD, playerName)
            Exit Sub
        End If


        'DONE: Get guild info and send invitation
        q.Clear()
        Database.Query("SELECT guild_name FROM adb_guilds WHERE guild_id = " & Client.Character.GuildID & ";", q)
        If q.Rows.Count = 0 Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_INTERNAL)
            Exit Sub
        End If

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_INVITE)
        response.AddString(Client.Character.Name)
        response.AddString(q.Rows(0).Item("guild_name"))
        c.Client.Send(response)
        response.Dispose()

        c.GuildInvited = Client.Character.GuildID
        c.GuildInvitedBy = Client.Character.GUID
    End Sub
    Public Sub On_CMSG_GUILD_ACCEPT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        If Client.Character.GuildInvited = 0 Then Throw New ApplicationException("Character accepting guild invitation whihtout being invited.")

        AddCharacterToGuild(Client.Character, Client.Character.GuildInvited)
        Client.Character.GuildInvited = 0

        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.JOINED)
        response.AddInt8(1)
        response.AddString(Client.Character.Name)
        BroadcastToGuild(response, Client.Character.GuildID)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_GUILD_DECLINE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Client.Character.GuildInvited = 0

        If CHARACTERS.ContainsKey(CType(Client.Character.GuildInvitedBy, Long)) Then
            Dim response As New PacketClass(OPCODES.SMSG_GUILD_DECLINE)
            response.AddString(Client.Character.Name)
            CHARACTERS(CType(Client.Character.GuildInvitedBy, Long)).Client.Send(response)
            response.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_GUILD_LEAVE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        'packet.GetInt16()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GUILD_LEAVE", Client.IP, Client.Port)

        'DONE: Checks
        If Not Client.Character.IsInGuild Then
            SendGuildResult(Client, GuildCommand.GUILD_CREATE_S, GuildError.GUILD_PLAYER_NOT_IN_GUILD)
            Exit Sub
        ElseIf Client.Character.IsGuildLeader Then
            SendGuildResult(Client, GuildCommand.GUILD_QUIT_S, GuildError.GUILD_LEADER_LEAVE)
            Exit Sub
        End If

        Dim GuildID As Integer = Client.Character.GuildID

        RemoveCharacterFromGuild(Client.Character)
        SendGuildResult(Client, GuildCommand.GUILD_QUIT_S, GuildError.GUILD_PLAYER_NO_MORE_IN_GUILD, Client.Character.Name)



        Dim response As New PacketClass(OPCODES.SMSG_GUILD_EVENT)
        response.AddInt8(GuildEvent.LEFT)
        response.AddInt8(1)
        response.AddString(Client.Character.Name)
        BroadcastToGuild(response, GuildID)
        response.Dispose()
    End Sub




    'Helping Subs
    Public Enum GuildCommand As Byte
        GUILD_CREATE_S = 0
        GUILD_INVITE_S = 1
        GUILD_QUIT_S = 2
        GUILD_FOUNDER_S = 12
    End Enum
    Public Enum GuildError As Byte
        GUILD_PLAYER_NO_MORE_IN_GUILD = 0
        GUILD_INTERNAL = 1
        GUILD_ALREADY_IN_GUILD = 2
        ALREADY_IN_GUILD = 3
        INVITED_TO_GUILD = 4
        ALREADY_INVITED_TO_GUILD = 5
        GUILD_NAME_INVALID = 6
        GUILD_NAME_EXISTS = 7
        GUILD_LEADER_LEAVE = 8
        GUILD_PERMISSIONS = 8
        GUILD_PLAYER_NOT_IN_GUILD = 9
        GUILD_PLAYER_NOT_IN_GUILD_S = 10
        GUILD_PLAYER_NOT_FOUND = 11
        GUILD_NOT_ALLIED = 12
    End Enum
    Public Sub SendGuildResult(ByRef Client As ClientClass, ByVal Command As GuildCommand, ByVal Result As GuildError, Optional ByVal Text As String = "")
        Dim response As New PacketClass(OPCODES.SMSG_GUILD_COMMAND_RESULT)
        response.AddInt32(Command)
        response.AddString(Text)
        response.AddInt32(Result)
        Client.Send(response)
        response.Dispose()
    End Sub

    Public Enum GuildEvent As Byte
        PROMOTION = 0           'uint8(2), string(name), string(rankName)
        DEMOTION = 1            'uint8(2), string(name), string(rankName)
        MOTD = 2                'uint8(1), string(text)                                             'Guild message of the day: <text>
        JOINED = 3              'uint8(1), string(name)                                             '<name> has joined the guild.
        LEFT = 4                'uint8(1), string(name)                                             '<name> has left the guild.
        REMOVED = 5             '??
        LEADER_IS = 6           'uint8(1), string(name                                              '<name> is the leader of your guild.
        LEADER_CHANGED = 7      'uint8(2), string(oldLeaderName), string(newLeaderName) 
        DISBANDED = 8           'uint8(0)                                                           'Your guild has been disbanded.
        TABARDCHANGE = 9        '??
    End Enum


#End Region

End Module
