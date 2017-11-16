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


Public Module WS_Loot

    Public LootTable As New Hashtable
    Public Enum LootType As Byte
        LOOTTYPE_CORPSE = 1
        LOOTTYPE_SKINNNING = 2
        LOOTTYPE_FISHING = 3
    End Enum


    Public Class LootItem
        Implements IDisposable

        Public ItemID As Integer = 0
        Public ItemCount As Byte = 0
        Public ReadOnly Property ItemModel() As Integer
            Get
                Try
                    Return ITEMDatabase(ItemID).Model
                Catch
                    If Not ITEMDatabase.ContainsKey(ItemID) Then
                        Dim tmpItem As New ItemInfo(ItemID)
                    End If
                    Return ITEMDatabase(ItemID).Model
                End Try
            End Get
        End Property

        Public Sub New(ByVal ID As Integer, ByVal Count As Byte)
            ItemID = ID
            ItemCount = Count
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose

        End Sub
    End Class
    Public Class LootObject
        Implements IDisposable
        Public GUID As Long = 0
        Public Items As New ArrayList
        Public Money As Integer = 0
        Public LootType As LootType = LootType.LOOTTYPE_CORPSE
        Public LootOwner As Long = 0

        Public GroupLootInfo As New Hashtable(0)

        Public Sub New(ByVal GUID_ As Long, ByVal LootType_ As LootType)
            LootTable(GUID_) = Me
            LootType = LootType_
            GUID = GUID_
        End Sub
        Public Sub SendLoot(ByRef Client As ClientClass)
            If Items.Count = 0 Then
                SendEmptyLoot(GUID, LootType, Client)
                Exit Sub
            End If
            If LootOwner <> 0 AndAlso Client.Character.GUID <> LootOwner Then
                'DONE: Loot owning!
                Dim notMy As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                notMy.AddInt8(InventoryChangeFailure.EQUIP_ERR_OBJECT_IS_BUSY)
                notMy.AddInt64(0)
                notMy.AddInt64(0)
                notMy.AddInt8(0)
                Client.Send(notMy)
                notMy.Dispose()
                Exit Sub
            End If


            Dim response As New PacketClass(OPCODES.SMSG_LOOT_RESPONSE)
            response.AddInt64(GUID)
            response.AddInt8(LootType)
            response.AddInt32(Money)
            response.AddInt8(Items.Count)

            Dim i As Byte
            For i = 0 To Items.Count - 1
                If Items(i) Is Nothing Then
                    response.AddInt8(i)
                    response.AddInt32(0)
                    response.AddInt32(0)
                    response.AddInt32(0)
                    response.AddInt64(0)
                    response.AddInt8(0)
                Else
                    response.AddInt8(i)
                    response.AddInt32(CType(Items(i), LootItem).ItemID)
                    response.AddInt32(CType(Items(i), LootItem).ItemCount)
                    response.AddInt32(CType(Items(i), LootItem).ItemModel)
                    response.AddInt64(0)
                    response.AddInt8(0)         '1: Message "Still rolled for.";  2: Unlootable;
                End If
            Next

            Client.Send(response)
            response.Dispose()

            Client.Character.lootGUID = GUID







            If Client.Character.IsInGroup Then
                If Client.Character.Party.GroupLootType = BaseParty.LootMethod.LOOT_NEED_BEFORE_GREED Or Client.Character.Party.GroupLootType = BaseParty.LootMethod.LOOT_GROUP Then

                    'DONE: Check threshold if in group
                    For i = 0 To Items.Count - 1
                        If Not Items(i) Is Nothing Then
                            If CType(ITEMDatabase(CType(Items(i), LootItem).ItemID), ItemInfo).Quality >= Client.Character.Party.GroupLootThreshold Then
                                GroupLootInfo(i) = New GroupLootInfo
                                CType(GroupLootInfo(i), GroupLootInfo).LootObject = Me
                                CType(GroupLootInfo(i), GroupLootInfo).LootSlot = i

                                CType(GroupLootInfo(i), GroupLootInfo).Item = Items(i)

                                StartRoll(GUID, i, Client.Character)
                                Exit Sub
                            End If
                        End If
                    Next

                End If
            End If
        End Sub
        Public Sub GetLoot(ByRef Client As ClientClass, ByVal Slot As Byte)
            If Client.Character.ItemFREESLOTS = 0 Then
                Dim response As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                response.AddInt8(InventoryChangeFailure.EQUIP_ERR_INVENTORY_FULL)
                response.AddInt64(0)
                response.AddInt64(0)
                response.AddInt8(0)
                Client.Send(response)
                response.Dispose()
                Exit Sub
            End If
            If Items(Slot) Is Nothing Then
                Dim response As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                response.AddInt8(InventoryChangeFailure.EQUIP_ERR_ALREADY_LOOTED)
                response.AddInt64(0)
                response.AddInt64(0)
                response.AddInt8(0)
                Client.Send(response)
                response.Dispose()
                Exit Sub
            End If
            If GroupLootInfo.ContainsKey(Slot) Then
                Dim response As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                response.AddInt8(InventoryChangeFailure.EQUIP_ERR_OBJECT_IS_BUSY)
                response.AddInt64(0)
                response.AddInt64(0)
                response.AddInt8(0)
                Client.Send(response)
                response.Dispose()
                Exit Sub
            End If




            Dim tmpItem As New ItemObject(CType(Items(Slot), LootItem).ItemID, Client.Character.GUID)
            tmpItem.StackCount = CType(Items(Slot), LootItem).ItemCount

            'DONE: Bind item to player
            If tmpItem.ItemInfo.Bonding = ITEM_BONDING_TYPE.BIND_WHEN_PICKED_UP Then tmpItem.SoulbindItem()


            If Client.Character.ItemADD(tmpItem) Then
                Dim response As New PacketClass(OPCODES.SMSG_LOOT_REMOVED)
                response.AddInt8(Slot)
                Client.Send(response)
                response.Dispose()

                Client.Character.LogLootItem(tmpItem.ItemEntry)

                Items(Slot).Dispose()
                'Items.RemoveAt(Slot)
                Items(Slot) = Nothing

                'DONE: Fire quest event to check for if this item is required for quest
                If CType(ITEMDatabase(tmpItem.ItemEntry), ItemInfo).ObjectClass = ITEM_CLASS.ITEM_CLASS_QUEST Then OnQuestItemAdd(Client.Character, tmpItem.ItemEntry, tmpItem.StackCount)
            Else
                tmpItem.Delete()
            End If
        End Sub

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                If Money <> 0 Then Return False
                For i As Integer = 0 To Items.Count - 1
                    If Not Items(i) Is Nothing Then Return False
                Next
                Return True
                'Return ((Items.Count = 0) And (Money = 0))
            End Get
        End Property
        Public Sub Dispose() Implements System.IDisposable.Dispose
            LootTable.Remove(GUID)
            Log.WriteLine(LogType.DEBUG, "Loot destroyed.")
        End Sub
    End Class

    Public Class GroupLootInfo
        Public LootObject As LootObject
        Public LootSlot As Byte

        Public Item As LootItem
        Public Rolls As New ArrayList
        Public Looters As New Hashtable(5)

        Public RollTimeoutTimer As Timer = Nothing

        Public Sub Check()
            If Looters.Count = Rolls.Count Then
                'DONE: End loot
                Dim maxRollType As Byte = 0
                For Each looter As DictionaryEntry In Looters
                    If looter.Value = 1 Then maxRollType = 1
                    If looter.Value = 2 AndAlso maxRollType <> 1 Then maxRollType = 2
                Next
                If maxRollType = 0 Then
                    LootObject.GroupLootInfo.Remove(LootSlot)
                    Dim response As New PacketClass(OPCODES.SMSG_LOOT_ALL_PASSED)
                    response.AddInt64(LootObject.GUID)
                    response.AddInt32(LootSlot)
                    response.AddInt32(Item.ItemID)
                    response.AddInt32(0)
                    response.AddInt32(0)
                    Broadcast(response)
                    response.Dispose()
                    Exit Sub
                End If



                Dim maxRoll As Integer = -1
                Dim looterCharacter As CharacterObject = Nothing
                For Each looter As DictionaryEntry In Looters
                    If looter.Value = maxRollType Then
                        Dim rollValue As Byte = Rnd.Next(0, 100)

                        If rollValue > maxRoll Then
                            maxRoll = rollValue
                            looterCharacter = looter.Key
                        End If

                        Dim response As New PacketClass(OPCODES.SMSG_LOOT_ROLL)
                        response.AddInt64(LootObject.GUID)
                        response.AddInt32(LootSlot)
                        response.AddInt64(looter.Key.Guid)
                        response.AddInt32(Item.ItemID)
                        response.AddInt32(0)
                        response.AddInt32(0)
                        response.AddInt8(rollValue)
                        response.AddInt8(looter.Value)
                        Broadcast(response)
                        response.Dispose()
                    End If
                Next



                Dim tmpItem As New ItemObject(CType(Item, LootItem).ItemID, looterCharacter.GUID)
                tmpItem.StackCount = CType(Item, LootItem).ItemCount


                Dim wonItem As New PacketClass(OPCODES.SMSG_LOOT_ROLL_WON)
                wonItem.AddInt64(LootObject.GUID)
                wonItem.AddInt32(LootSlot)
                wonItem.AddInt32(Item.ItemID)
                wonItem.AddInt32(0)
                wonItem.AddInt32(0)
                wonItem.AddInt64(looterCharacter.GUID)
                wonItem.AddInt8(maxRoll)
                wonItem.AddInt8(maxRollType)
                Broadcast(wonItem)


                If looterCharacter.ItemADD(tmpItem) Then
                    looterCharacter.LogLootItem(tmpItem.ItemEntry)

                    LootObject.GroupLootInfo.Remove(LootSlot)
                    LootObject.Items(LootSlot) = Nothing
                Else
                    tmpItem.Delete()
                    LootObject.GroupLootInfo.Remove(LootSlot)
                End If
            End If
        End Sub
        Public Sub Broadcast(ByRef packet As PacketClass)
            For Each c As CharacterObject In Rolls
                c.Client.SendMultiplyPackets(packet)
            Next
        End Sub
        Public Sub EndRoll(ByVal state As Object)
            For Each c As CharacterObject In Rolls
                If Not Looters.ContainsKey(c) Then
                    Looters(c) = 0

                    'DONE: Send roll info
                    Dim response As New PacketClass(OPCODES.SMSG_LOOT_ROLL)
                    response.AddInt64(LootObject.GUID)
                    response.AddInt32(LootSlot)
                    response.AddInt64(c.GUID)
                    response.AddInt32(Item.ItemID)
                    response.AddInt32(0)
                    response.AddInt32(0)
                    response.AddInt8(249)
                    response.AddInt8(0)
                    Broadcast(response)
                End If

            Next
            RollTimeoutTimer.Dispose()
            RollTimeoutTimer = Nothing
            Check()
        End Sub
    End Class


    Public Sub On_CMSG_AUTOSTORE_LOOT_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim slot As Byte = packet.GetInt8
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_AUTOSTORE_LOOT_ITEM [slot={2}]", Client.IP, Client.Port, slot)

        If LootTable.ContainsKey(Client.Character.lootGUID) Then
            CType(LootTable(Client.Character.lootGUID), LootObject).GetLoot(Client, slot)
        Else
            Dim response As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
            response.AddInt8(InventoryChangeFailure.EQUIP_ERR_ALREADY_LOOTED)
            response.AddInt64(0)
            response.AddInt64(0)
            response.AddInt8(0)
            Client.Send(response)
            response.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_LOOT_MONEY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LOOT_MONEY", Client.IP, Client.Port)

        If Not LootTable.ContainsKey(Client.Character.lootGUID) Then Exit Sub

        If Client.Character.IsInGroup Then
            'DONE: Party share
            Dim members As ArrayList = GetPartyMembersAroundMe(Client.Character, 100)
            Dim copper As Integer = (CType(LootTable(Client.Character.lootGUID), LootObject).Money \ members.Count) + 1
            CType(LootTable(Client.Character.lootGUID), LootObject).Money = 0

            Dim sharePcket As New PacketClass(OPCODES.SMSG_LOOT_MONEY_NOTIFY)
            sharePcket.AddInt32(copper)
            For Each character As CharacterObject In members
                character.Client.SendMultiplyPackets(sharePcket)

                character.Copper += copper
                character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, character.Copper)
                character.SaveCharacter()
            Next

            Client.SendMultiplyPackets(sharePcket)
            Client.Character.Copper += copper
            sharePcket.Dispose()
        Else
            'DONE: Not in party
            Client.Character.Copper += CType(LootTable(Client.Character.lootGUID), LootObject).Money
            CType(LootTable(Client.Character.lootGUID), LootObject).Money = 0
        End If
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
        Client.Character.SendCharacterUpdate(False)
        Client.Character.SaveCharacter()



        'TODO: Send to party loooters
        Dim response2 As New PacketClass(OPCODES.SMSG_LOOT_CLEAR_MONEY)
        Client.SendMultiplyPackets(response2)
        'Client.Character.SendToNearPlayers(response2)
        response2.Dispose()
    End Sub
    Public Sub On_CMSG_LOOT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LOOT [GUID={2:X}]", Client.IP, Client.Port, GUID)

        If LootTable.ContainsKey(GUID) Then
            CType(LootTable(GUID), LootObject).SendLoot(Client)
        Else
            SendEmptyLoot(GUID, LootType.LOOTTYPE_CORPSE, Client)
        End If
        'GenerateLoot(Client, GUID, LootType.LOOTTYPE_CORPSE)
    End Sub
    Public Sub On_CMSG_LOOT_RELEASE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LOOT_RELEASE [lootGUID={2:X}]", Client.IP, Client.Port, GUID)

        If LootTable.ContainsKey(GUID) Then
            'DONE: Remove loot owner
            CType(LootTable(GUID), LootObject).LootOwner = 0



            If CType(LootTable(GUID), LootObject).IsEmpty Then
                'DONE: Delete loot
                CType(LootTable(GUID), LootObject).Dispose()

                'DONE: Remove loot sing for player
                If GuidIsCreature(GUID) Then
                    'DONE: Set skinnable
                    If CType(CREATURESDatabase(WORLD_CREATUREs(GUID).ID), CreatureInfo).Loot_Skinning <> 0 Then
                        WORLD_CREATUREs(GUID).cUnitFlags = UnitFlags.UNIT_FLAG_DEAD + UnitFlags.UNIT_FLAG_SKINNABLE
                    End If

                    WORLD_CREATUREs(GUID).cDynamicFlags = 0

                    'Dim response2 As New PacketClass(OPCODES.SMSG_LOOT_RELEASE_RESPONSE)
                    'response2.AddInt64(GUID)
                    'response2.AddInt8(1)
                    'Client.Send(response2)
                    'response2.Dispose()

                    Dim response As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                    response.AddInt32(1)
                    response.AddInt8(0)
                    Dim UpdateData As New UpdateClass
                    UpdateData.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, WORLD_CREATUREs(GUID).cDynamicFlags)
                    UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, WORLD_CREATUREs(GUID).cUnitFlags)
                    UpdateData.AddToPacket(response, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
                    WORLD_CREATUREs(GUID).SendToNearPlayers(response)
                    response.Dispose()
                    UpdateData.Dispose()

                ElseIf GuidIsGameObject(GUID) Then
                    WORLD_GAMEOBJECTs(GUID).State = GameObjectLootState.LOOT_LOOTED

                    Dim response As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                    response.AddInt32(1)
                    response.AddInt8(0)
                    Dim UpdateData As New UpdateClass
                    UpdateData.SetUpdateFlag(EGameObjectFields.GAMEOBJECT_STATE, WORLD_GAMEOBJECTs(GUID).State)
                    UpdateData.AddToPacket(response, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_GAMEOBJECTs(GUID), GameObjectObject), 0)

                    WORLD_GAMEOBJECTs(GUID).SendToNearPlayers(response)
                    response.Dispose()
                    UpdateData.Dispose()

                ElseIf GuidIsItem(GUID) Then

                    Client.Character.ItemREMOVE(GUID, True, True)
                End If

            Else

                'DONE: Send loot for other players
                If GuidIsCreature(GUID) Then
                    WORLD_CREATUREs(GUID).cDynamicFlags = DynamicFlags.UNIT_DYNFLAG_LOOTABLE

                    Dim response As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
                    response.AddInt32(1)
                    response.AddInt8(0)
                    Dim UpdateData As New UpdateClass
                    UpdateData.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, WORLD_CREATUREs(GUID).cDynamicFlags)
                    UpdateData.AddToPacket(response, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
                    WORLD_CREATUREs(GUID).SendToNearPlayers(response)
                    response.Dispose()
                    UpdateData.Dispose()
                ElseIf GuidIsItem(GUID) Then
                    CType(LootTable(GUID), LootObject).Dispose()
                    Client.Character.ItemREMOVE(GUID, True, True)
                Else
                    'DONE: In all other cases - delete the loot
                    CType(LootTable(GUID), LootObject).Dispose()
                End If

            End If
        End If

        Client.Character.lootGUID = 0
    End Sub

    Public Function GenerateLoot(ByRef Character As CharacterObject, ByVal GUID As Long, ByVal LootType As LootType) As Boolean
#If DEBUG Then
        Log.WriteLine(LogType.DEBUG, "Generating loot for: {0:X}.", GUID)
#End If


        If GuidIsCreature(GUID) Then
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If Not WORLD_CREATUREs.ContainsKey(GUID) Then Return False

            Dim lootGroup As Integer = 0
            If LootType = LootType.LOOTTYPE_CORPSE Then lootGroup = CREATURESDatabase(WORLD_CREATUREs(GUID).ID).Loot
            If LootType = LootType.LOOTTYPE_SKINNNING Then lootGroup = CREATURESDatabase(WORLD_CREATUREs(GUID).ID).Loot_Skinning
            If lootGroup = 0 Then Return False

            'DONE: Loot generation
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_loots WHERE loot_group = {0};", lootGroup), MySQLQuery)
            'If MySQLQuery.Rows.Count = 0 Then Return False

            Dim Loot As New LootObject(GUID, LootType)
            For Each LootRow As DataRow In MySQLQuery.Rows
                If CType(LootRow.Item("loot_chance"), Single) * 10000 > (Rnd.Next(1, 2000001) Mod 1000000) Then
                    Loot.Items.Add(New LootItem(CType(LootRow.Item("loot_item"), Integer), 1))
                End If
            Next

            'DONE: Money loot
            If LootType = LootType.LOOTTYPE_CORPSE Then
                If CType(CREATURESDatabase(WORLD_CREATUREs(GUID).ID), CreatureInfo).Elite = 0 Then
                    If CType(CREATURESDatabase(WORLD_CREATUREs(GUID).ID), CreatureInfo).CreatureType = UNIT_TYPE.HUMANOID Then
                        Loot.Money = Fix(WORLD_CREATUREs(GUID).Level * Rnd.Next(0, WORLD_CREATUREs(GUID).Level))
                    ElseIf Rnd.NextDouble < 0.2 Then
                        Loot.Money = Fix(WORLD_CREATUREs(GUID).Level * Rnd.Next(0, WORLD_CREATUREs(GUID).Level))
                    End If
                Else
                    Loot.Money = Fix(WORLD_CREATUREs(GUID).Level * Rnd.Next(0, WORLD_CREATUREs(GUID).Level) * CType(CREATURESDatabase(WORLD_CREATUREs(GUID).ID), CreatureInfo).Elite)
                End If
            End If

            Loot.LootOwner = Character.GUID



        ElseIf GuidIsGameObject(GUID) Then
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If Not WORLD_GAMEOBJECTs.ContainsKey(GUID) Then Return False

            Dim lootGroup As Integer = GAMEOBJECTSDatabase(WORLD_GAMEOBJECTs(GUID).ID).Loot
            If lootGroup = 0 Then Return False

            'DONE: Loot generation
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_loots WHERE loot_group = {0};", lootGroup), MySQLQuery)
            If MySQLQuery.Rows.Count = 0 Then Return False
            Dim Loot As New LootObject(GUID, LootType)
            For Each LootRow As DataRow In MySQLQuery.Rows
                If CType(LootRow.Item("loot_chance"), Single) * 10000 > (Rnd.Next(1, 2000001) Mod 1000000) Then
                    Loot.Items.Add(New LootItem(CType(LootRow.Item("loot_item"), Integer), 1))
                End If
            Next

            Loot.LootOwner = Character.GUID



        ElseIf GuidIsItem(GUID) Then
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            If Not WORLD_ITEMs.ContainsKey(GUID) Then Return False
            Dim q As New DataTable
            Database.Query(String.Format("SELECT item_loot FROM adb_items WHERE item_id = {0} LIMIT 1;", CType(WORLD_ITEMs(GUID), ItemObject).ItemEntry), q)
            If q.Rows.Count = 0 Then Return False
            If q.Rows(0).Item("item_loot") = 0 Then Return False

            'DONE: Loot generation
            Dim loot_group As Integer = q.Rows(0).Item("item_loot")
            q.Clear()
            Database.Query(String.Format("SELECT * FROM adb_loots WHERE loot_group = {0};", loot_group), q)
            If q.Rows.Count = 0 Then Return False
            Dim Loot As New LootObject(GUID, LootType)
            For Each LootRow As DataRow In q.Rows
                If CType(LootRow.Item("loot_chance"), Single) * 10000 > (Rnd.Next(1, 2000001) Mod 1000000) Then
                    Loot.Items.Add(New LootItem(CType(LootRow.Item("loot_item"), Integer), 1))
                End If
            Next





        Else
            Log.WriteLine(LogType.WARNING, "Looting Unknown GUID type: {0:X}.", GUID)
            Return False
        End If
        Return True
    End Function

    Public Sub SendEmptyLoot(ByVal GUID As Long, ByVal LootType As LootType, ByRef Client As ClientClass)
        Dim response As New PacketClass(OPCODES.SMSG_LOOT_RESPONSE)
        response.AddInt64(GUID)
        response.AddInt8(LootType)
        response.AddInt32(0)
        response.AddInt8(0)
        Client.Send(response)
        response.Dispose()
#If DEBUG Then
        Log.WriteLine(LogType.WARNING, "[{0}:{1}] Empty loot for GUID [{2:X}].", Client.IP, Client.Port, GUID)
#End If
    End Sub

    Public Sub StartRoll(ByVal LootGUID As Long, ByVal Slot As Byte, ByRef Character As CharacterObject)
        Dim rollCharacters As New ArrayList
        For i As Byte = 0 To Character.Party.GroupMembers.Length - 1
            If (Not Character.Party.GroupMembers(i) Is Nothing) Then
                If (Character.playersNear.Contains(Character.Party.GroupMembers(i).GUID)) Then rollCharacters.Add(Character.Party.GroupMembers(i))
                If Character.Party.GroupMembers(i) Is Character Then rollCharacters.Add(Character.Party.GroupMembers(i))
            End If
        Next


        Dim startRoll As New PacketClass(OPCODES.SMSG_LOOT_START_ROLL)
        startRoll.AddInt64(LootGUID)
        startRoll.AddInt32(Slot)

        startRoll.AddInt32(CType(CType(CType(LootTable(LootGUID), LootObject).GroupLootInfo(Slot), GroupLootInfo).Item, LootItem).ItemID)
        startRoll.AddInt32(0)
        startRoll.AddInt32(0)
        startRoll.AddInt32(60000)

        For Each c As CharacterObject In rollCharacters
            c.Client.SendMultiplyPackets(startRoll)
        Next
        startRoll.Dispose()

        CType(CType(LootTable(LootGUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).Rolls = rollCharacters
        CType(CType(LootTable(LootGUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).RollTimeoutTimer = New Timer(New TimerCallback(AddressOf CType(CType(LootTable(LootGUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).EndRoll), 0, 60000, Timeout.Infinite)
    End Sub



    Public Sub On_CMSG_LOOT_ROLL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim Slot As Byte = packet.GetInt32
        Dim rollType As Byte = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LOOT_ROLL [loot={2} roll={3}]", Client.IP, Client.Port, GUID, rollType)


        '0 - Pass
        '1 - Need
        '2 - Greed

        'DONE: Send roll info
        Dim response As New PacketClass(OPCODES.SMSG_LOOT_ROLL)
        response.AddInt64(GUID)
        response.AddInt32(Slot)
        response.AddInt64(Client.Character.GUID)
        response.AddInt32(CType(CType(CType(LootTable(GUID), LootObject).GroupLootInfo(Slot), GroupLootInfo).Item, LootItem).ItemID)
        response.AddInt32(0)
        response.AddInt32(0)

        'FIRST:  0: "Need for: [item name]" > 127: "you passed on: [item name]"
        'SECOND: 0: "Need for: [item name]" 0: "You have selected need for [item name] 1: need roll 2: greed roll
        Select Case rollType
            Case 0
                response.AddInt8(249)
                response.AddInt8(0)
            Case 1
                response.AddInt8(0)
                response.AddInt8(0)
            Case 2
                response.AddInt8(249)
                response.AddInt8(2)
        End Select



        CType(CType(LootTable(GUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).Broadcast(response)
        response.Dispose()

        CType(CType(LootTable(GUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).Looters(Client.Character) = rollType
        CType(CType(LootTable(GUID), LootObject).GroupLootInfo(CType(Slot, Byte)), GroupLootInfo).Check()
    End Sub
End Module
