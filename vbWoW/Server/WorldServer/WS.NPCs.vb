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

Public Module WS_NPCs

#Region "Constants"
    Enum SELL_ERROR As Byte
        SELL_ERR_CANT_FIND_ITEM = 1
        SELL_ERR_CANT_SELL_ITEM = 2
        SELL_ERR_CANT_FIND_VENDOR = 3
    End Enum
    Enum BUY_ERROR As Byte
        'SMSG_BUY_FAILED error
        '0: cant find item
        '1: item already selled
        '2: not enought money
        '4: seller(dont Like u)
        '5: distance too far
        '8: cant carry more
        '11: level(require)
        '12: reputation(require)

        BUY_ERR_CANT_FIND_ITEM = 0
        BUY_ERR_ITEM_ALREADY_SOLD = 1
        BUY_ERR_NOT_ENOUGHT_MONEY = 2
        BUY_ERR_SELLER_DONT_LIKE_YOU = 4
        BUY_ERR_DISTANCE_TOO_FAR = 5
        BUY_ERR_CANT_CARRY_MORE = 8
        BUY_ERR_LEVEL_REQUIRE = 11
        BUY_ERR_REPUTATION_REQUIRE = 12
    End Enum
#End Region


    'TODO: MSG_LIST_STABLED_PETS

#Region "Trainers"


    Public Sub On_CMSG_TRAINER_LIST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TRAINER_LIST [GUID={2}]", Client.IP, Client.Port, GUID)

        SendTrainerList(Client.Character, GUID)
    End Sub
    Public Sub On_CMSG_TRAINER_BUY_SPELL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim cGUID As Long = packet.GetInt64
        Dim SpellID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TRAINER_BUY_SPELL [GUID={2} Spell={3}]", Client.IP, Client.Port, cGUID, SpellID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_trainer_spells WHERE trainerId = {0} AND spellId = {1};", WORLD_CREATUREs(cGUID).ID, SpellID), MySQLQuery)

        If MySQLQuery.Rows.Count = 0 Then Exit Sub


        'DONE: Check requirements
        If Client.Character.Copper < MySQLQuery.Rows(0).Item("spellCost") Then Exit Sub
        If Client.Character.Level < CType(SPELLs(SpellID), SpellInfo).spellLevel Then Exit Sub
        If Not Client.Character.HaveSpell(MySQLQuery.Rows(0).Item("requiredSpell")) Then Exit Sub
        If Not Client.Character.HaveSkill(MySQLQuery.Rows(0).Item("requiredSkill"), MySQLQuery.Rows(0).Item("requiredSkill_Value")) Then Exit Sub

        'TODO: Check proffessions - only alowed to learn 2!


        Try
            'DONE: Get the money
            Client.Character.Copper -= MySQLQuery.Rows(0).Item("spellCost")
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

            'DONE: Just cast the spell
            Dim tmpTargets As New SpellTargets
            tmpTargets.unitTarget = Client.Character
            CType(SPELLs(SpellID), SpellInfo).Cast(CType(WORLD_CREATUREs(cGUID), CreatureObject), tmpTargets)
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Training Spell Error: Unable to cast spell. [{0}:{1}]", vbNewLine, e.ToString)

            'TODO: Fix this opcode
            'Dim errorPacket As New PacketClass(OPCODES.SMSG_TRAINER_BUY_FAILED)
            'errorPacket.AddInt64(cGUID)
            'errorPacket.AddInt32(SpellID)
            'Client.Send(errorPacket)
            'errorPacket.Dispose()
        End Try

        'DONE: Send response
        Dim response As New PacketClass(OPCODES.SMSG_TRAINER_BUY_SUCCEEDED)
        response.AddInt64(cGUID)
        response.AddInt32(SpellID)
        Client.Send(response)
        response.Dispose()

    End Sub

    Public Sub SendTrainerList(ByRef c As CharacterObject, ByVal cGUID As Long)

        'DONE: Query the database and sort spells
        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_trainer_spells WHERE trainerId = {0};", WORLD_CREATUREs(cGUID).ID), MySQLQuery)

        Dim SpellsList As New ArrayList
        For Each SellRow As DataRow In MySQLQuery.Rows
            If (CType(SellRow.Item("requiredRace"), Integer) And (1 << (c.Race - 1)) <> 0) _
            AndAlso (CType(SellRow.Item("requiredClass"), Integer) And (1 << (c.Classe - 1)) <> 0) Then
                SpellsList.Add(SellRow)
            End If
        Next



        'DONE: No spells avaible -> wrong trainer type.
        If SPELLs.Count = 0 Then
            Dim npcText As New NPCText
            npcText.Count = 1
            npcText.TextID = Integer.MaxValue
            npcText.TextLine1(0) = "Do i look like $C trainer?"
            SendNPCText(c.Client, npcText)

            c.SendGossip(cGUID, Integer.MaxValue)
            Exit Sub
        End If



        'DONE: Build the packet
        Dim packet As New PacketClass(OPCODES.SMSG_TRAINER_LIST)

        packet.AddInt64(cGUID)
        packet.AddInt32(0)
        packet.AddInt32(SpellsList.Count)              'Trains Length

        For Each SellRow As DataRow In SpellsList
            packet.AddInt32(SellRow.Item("spellId")) 'SpellID

            'CanLearn (0):Green (1):Red (2):Gray
            If c.HaveSpell(CType(SPELLs(CType(SellRow.Item("spellId"), Integer)), SpellInfo).SpellEffects(0).TriggerSpell) Then
                'NOTE: Already have that spell
                packet.AddInt8(2)
            ElseIf _
            c.Level >= CType(SPELLs(CType(SellRow.Item("spellId"), Integer)), SpellInfo).spellLevel AndAlso _
            c.HaveSpell(SellRow.Item("requiredSpell")) AndAlso _
            c.HaveSkill(SellRow.Item("requiredSkill"), SellRow.Item("requiredSkill_Value")) Then
                'NOTE: Can learn that spell
                packet.AddInt8(0)
            Else
                'NOTE: Doesn't meet requirements, cannot learn that spell
                packet.AddInt8(1)
            End If
            packet.AddInt8(0)

            packet.AddInt32(SellRow.Item("spellCost"))              'SpellCost
            packet.AddInt32(0)
            packet.AddInt32(0)
            packet.AddInt8(CType(SPELLs(CType(SellRow.Item("spellId"), Integer)), SpellInfo).spellLevel)   'SpellLevel
            packet.AddInt32(SellRow.Item("requiredSkill"))          'Required Skill
            packet.AddInt32(SellRow.Item("requiredSkill_Value"))    'Required Skill Value
            packet.AddInt32(SellRow.Item("requiredSpell"))          'Required Spell
            packet.AddInt32(0)
            packet.AddInt32(0)
        Next

        packet.AddString("Ready for some training?")

        c.Client.Send(packet)
        packet.Dispose()
    End Sub


#End Region
#Region "Merchants"


    Public Sub On_CMSG_LIST_INVENTORY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LIST_INVENTORY [GUID={2:X}]", Client.IP, Client.Port, GUID)

        SendListInventory(Client.Character, CREATURESDatabase(WORLD_CREATUREs(GUID).ID).SellTable, GUID)
    End Sub

    Public Sub On_CMSG_SELL_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim vendorGUID As Long = packet.GetInt64
        Dim itemGUID As Long = packet.GetInt64
        Dim count As Byte = packet.GetInt8
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SELL_ITEM [vendorGUID={2:X} itemGUID={3:X} Count={4}]", Client.IP, Client.Port, vendorGUID, itemGUID, count)

        If itemGUID = 0 Then
            Dim okPckt As New PacketClass(OPCODES.SMSG_SELL_ITEM)
            okPckt.AddInt64(vendorGUID)
            okPckt.AddInt64(itemGUID)
            okPckt.AddInt8(SELL_ERROR.SELL_ERR_CANT_FIND_ITEM)
            Client.Send(okPckt)
            okPckt.Dispose()
            Exit Sub
        End If
        If Not WORLD_CREATUREs.ContainsKey(vendorGUID) Then
            Dim okPckt As New PacketClass(OPCODES.SMSG_SELL_ITEM)
            okPckt.AddInt64(vendorGUID)
            okPckt.AddInt64(itemGUID)
            okPckt.AddInt8(SELL_ERROR.SELL_ERR_CANT_FIND_VENDOR)
            Client.Send(okPckt)
            okPckt.Dispose()
            Exit Sub
        End If
        'DONE: Can't sell quest items
        If (ITEMDatabase(WORLD_ITEMs(itemGUID).ItemEntry).SellPrice = 0) Or (CType(ITEMDatabase(WORLD_ITEMs(itemGUID).ItemEntry), ItemInfo).ObjectClass = ITEM_CLASS.ITEM_CLASS_QUEST) Then
            Dim okPckt As New PacketClass(OPCODES.SMSG_SELL_ITEM)
            okPckt.AddInt64(vendorGUID)
            okPckt.AddInt64(itemGUID)
            okPckt.AddInt8(SELL_ERROR.SELL_ERR_CANT_SELL_ITEM)
            Client.Send(okPckt)
            okPckt.Dispose()
            Exit Sub
        End If


        If count < 1 Then count = CType(WORLD_ITEMs(itemGUID), ItemObject).StackCount
        If CType(WORLD_ITEMs(itemGUID), ItemObject).StackCount > count Then
            CType(WORLD_ITEMs(itemGUID), ItemObject).StackCount -= count
            Client.Character.Copper += (ITEMDatabase(WORLD_ITEMs(itemGUID).ItemEntry).SellPrice * count)
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
            Client.Character.SendItemUpdate(WORLD_ITEMs(itemGUID))
            WORLD_ITEMs(itemGUID).Save(False)
        Else
            'TODO: Fix buyback

            For Each Item As DictionaryEntry In Client.Character.Items
                If Item.Value.GUID = itemGUID Then
                    Client.Character.Copper += (ITEMDatabase(Item.Value.ItemEntry).SellPrice * Item.Value.StackCount)
                    Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

                    If Item.Key < EQUIPMENT_SLOT_END Then Client.Character.UpdateRemoveItemStats(Item.Value, item.Key)
                    Client.Character.ItemREMOVE(Item.Value.GUID, True, True)

                    Dim okPckt As New PacketClass(OPCODES.SMSG_SELL_ITEM)
                    okPckt.AddInt64(vendorGUID)
                    okPckt.AddInt64(itemGUID)
                    okPckt.AddInt8(0)
                    Client.Send(okPckt)
                    okPckt.Dispose()
                    Exit Sub
                End If
            Next


            Dim i As Byte
            For i = INVENTORY_SLOT_BAG_1 To INVENTORY_SLOT_BAG_4
                For Each Item As DictionaryEntry In Client.Character.Items
                    If Item.Value.GUID = itemGUID Then
                        Client.Character.Copper += (ITEMDatabase(Item.Value.ItemEntry).SellPrice * Item.Value.StackCount)
                        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

                        Client.Character.ItemREMOVE(Item.Value.GUID, True, True)

                        Dim okPckt As New PacketClass(OPCODES.SMSG_SELL_ITEM)
                        okPckt.AddInt64(vendorGUID)
                        okPckt.AddInt64(itemGUID)
                        okPckt.AddInt8(0)
                        Client.Send(okPckt)
                        okPckt.Dispose()
                        Exit Sub
                    End If
                Next

            Next
        End If

    End Sub
    Public Sub On_CMSG_BUY_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)


        packet.GetInt16()
        Dim vendorGUID As Long = packet.GetInt64
        Dim itemID As Integer = packet.GetInt32
        Dim count As Byte = packet.GetInt8
        Dim slot As Byte = packet.GetInt8       '??
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BUY_ITEM [vendorGUID={2:X} ItemID={3} Count={4} Slot={5}]", Client.IP, Client.Port, vendorGUID, itemID, count, slot)

        'DONE: Can't buy quest items
        If CType(ITEMDatabase(itemID), ItemInfo).ObjectClass = ITEM_CLASS.ITEM_CLASS_QUEST Then
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(vendorGUID)
            errorPckt.AddInt32(itemID)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_SELLER_DONT_LIKE_YOU)
            Client.Send(errorPckt)
            errorPckt.Dispose()
            Exit Sub
        End If

        Dim itemPrice As Integer = 0
        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT sell_price, sell_count FROM adb_sells WHERE sell_group = {0} AND sell_item = {1};", CREATURESDatabase(WORLD_CREATUREs(vendorGUID).ID).SellTable, itemID), MySQLQuery)
        If MySQLQuery.Rows.Count = 0 Then
            'DONE: This is hack preventation. Used with WPE Pro packet editing of itemID value
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(vendorGUID)
            errorPckt.AddInt32(itemID)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_CANT_FIND_ITEM)
            Client.Send(errorPckt)
            errorPckt.Dispose()
            Exit Sub
        End If

        If MySQLQuery.Rows(0).Item("sell_price") > 0 Then itemPrice = MySQLQuery.Rows(0).Item("sell_price") Else itemPrice = ITEMDatabase(itemID).BuyPrice
        If Client.Character.Copper < itemPrice Then
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(vendorGUID)
            errorPckt.AddInt32(itemID)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_NOT_ENOUGHT_MONEY)
            Client.Send(errorPckt)
            errorPckt.Dispose()
            Exit Sub
        End If

        Client.Character.Copper -= itemPrice
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

        Dim tmpItem As New ItemObject(itemID, Client.Character.GUID)
        'DONE: Get real item count
        If count < 2 Then
            If MySQLQuery.Rows(0).Item("sell_count") > 0 Then
                count = MySQLQuery.Rows(0).Item("sell_count")
            Else
                count = ITEMDatabase(itemID).Stackable
            End If
        End If
        tmpItem.StackCount = count

        If Not Client.Character.ItemADD(tmpItem) Then
            tmpItem.Delete()
            Client.Character.Copper += itemPrice
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
        Else
            Dim okPckt As New PacketClass(OPCODES.SMSG_BUY_ITEM)
            okPckt.AddInt64(vendorGUID)
            okPckt.AddInt32(itemID)
            okPckt.AddInt32(count)
            Client.Send(okPckt)
            okPckt.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_BUY_ITEM_IN_SLOT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim vendorGUID As Long = packet.GetInt64
        Dim itemID As Integer = packet.GetInt32
        Dim clientGUID As Long = packet.GetInt64
        Dim slot As Byte = packet.GetInt8
        Dim count As Byte = packet.GetInt8
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BUY_ITEM_IN_SLOT [vendorGUID={2:X} ItemID={3} Count={4} Slot={5}]", Client.IP, Client.Port, vendorGUID, itemID, count, slot)


        'DONE: Can't buy quest items
        If CType(ITEMDatabase(itemID), ItemInfo).ObjectClass = ITEM_CLASS.ITEM_CLASS_QUEST Then
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(vendorGUID)
            errorPckt.AddInt32(itemID)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_SELLER_DONT_LIKE_YOU)
            Client.Send(errorPckt)
            errorPckt.Dispose()
            Exit Sub
        End If


        Dim itemPrice As Integer = 0
        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT sell_price, sell_count FROM adb_sells WHERE sell_group = {0} AND sell_item = {1};", CREATURESDatabase(WORLD_CREATUREs(vendorGUID).ID).SellTable, itemID), MySQLQuery)
        If MySQLQuery.Rows(0).Item("sell_price") > 0 Then itemPrice = MySQLQuery.Rows(0).Item("sell_price") Else itemPrice = ITEMDatabase(itemID).BuyPrice

        If Client.Character.Copper < itemPrice Then
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(vendorGUID)
            errorPckt.AddInt32(itemID)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_NOT_ENOUGHT_MONEY)
            Client.Send(errorPckt)
            errorPckt.Dispose()
            Exit Sub
        End If


        Dim errCode As Byte = 0
        Dim bag As Byte = 0

        If clientGUID = Client.Character.GUID Then
            'Store in inventory
            bag = 0
            If Client.Character.Items.Contains(slot) Then
                Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
                errorPckt.AddInt64(vendorGUID)
                errorPckt.AddInt32(itemID)
                errorPckt.AddInt8(BUY_ERROR.BUY_ERR_CANT_CARRY_MORE)
                Client.Send(errorPckt)
                errorPckt.Dispose()
                Exit Sub
            End If
        Else
            'Store in bag
            Dim i As Byte
            For i = INVENTORY_SLOT_BAG_1 To INVENTORY_SLOT_BAG_4
                If Client.Character.Items(i) = clientGUID Then
                    bag = i
                    Exit For
                End If
            Next
            If bag = 0 Then
                Dim okPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
                okPckt.AddInt64(vendorGUID)
                okPckt.AddInt32(itemID)
                okPckt.AddInt8(BUY_ERROR.BUY_ERR_CANT_FIND_ITEM)
                Client.Send(okPckt)
                okPckt.Dispose()
                Exit Sub
            End If
            If WORLD_ITEMs(Client.Character.Items(bag)).Items.Contains(slot) Then
                Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
                errorPckt.AddInt64(vendorGUID)
                errorPckt.AddInt32(itemID)
                errorPckt.AddInt8(BUY_ERROR.BUY_ERR_CANT_CARRY_MORE)
                Client.Send(errorPckt)
                errorPckt.Dispose()
                Exit Sub
            End If
        End If




        Dim tmpItem As New ItemObject(itemID, Client.Character.GUID)
        'DONE: Get real item count
        If count < 2 Then
            If MySQLQuery.Rows(0).Item("sell_count") > 0 Then
                count = MySQLQuery.Rows(0).Item("sell_count")
            Else
                count = ITEMDatabase(itemID).Stackable
            End If
        End If
        tmpItem.StackCount = count

        errCode = Client.Character.ItemCANEQUIP(tmpItem, bag, slot)
        If errCode <> InventoryChangeFailure.EQUIP_ERR_OK Then
            If errCode <> InventoryChangeFailure.EQUIP_ERR_YOU_MUST_REACH_LEVEL_N Then
                Dim errorPckt As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                errorPckt.AddInt8(errCode)
                errorPckt.AddInt64(0)
                errorPckt.AddInt64(0)
                errorPckt.AddInt8(0)
                Client.Send(errorPckt)
                errorPckt.Dispose()
            End If
            tmpItem.Delete()
            Exit Sub
        Else
            Client.Character.Copper -= itemPrice
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

            If Not Client.Character.ItemSETSLOT(tmpItem, slot, bag) Then
                tmpItem.Delete()
                Client.Character.Copper += itemPrice
                Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
            Else
                Dim okPckt As New PacketClass(OPCODES.SMSG_BUY_ITEM)
                okPckt.AddInt64(vendorGUID)
                okPckt.AddInt32(itemID)
                okPckt.AddInt32(count)
                Client.Send(okPckt)
                okPckt.Dispose()
            End If
        End If
    End Sub

    Public Sub On_CMSG_REPAIR_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim vendorGUID As Long = packet.GetInt64
        Dim itemGUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_REPAIR_ITEM [vendorGUID={2:X} itemGUID={3:X}]", Client.IP, Client.Port, vendorGUID, itemGUID)

        If itemGUID <> 0 Then
            If Client.Character.Copper >= WORLD_ITEMs(itemGUID).GetDurabulityCost Then
                Client.Character.Copper -= WORLD_ITEMs(itemGUID).GetDurabulityCost
                Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
                Client.Character.SendCharacterUpdate()

                WORLD_ITEMs(itemGUID).ModifyDurability(-100.0F, Client)
            End If
        Else
            Dim i As Byte
            For i = 0 To EQUIPMENT_SLOT_END - 1
                If Client.Character.Items.ContainsKey(i) Then
                    If Client.Character.Copper >= Client.Character.Items(i).GetDurabulityCost Then
                        Client.Character.Copper -= Client.Character.Items(i).GetDurabulityCost
                        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
                        Client.Character.SendCharacterUpdate()

                        Client.Character.Items(i).ModifyDurability(-100.0F, Client)
                    Else
                        Exit For
                    End If

                End If
            Next
        End If
    End Sub

    Public Sub SendListInventory(ByVal Character As CharacterObject, ByVal InventoryID As Integer, ByVal GUID As Long)
        Dim packet As New PacketClass(OPCODES.SMSG_LIST_INVENTORY)
        packet.AddInt64(GUID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_sells WHERE sell_group = {0};", InventoryID), MySQLQuery)
        packet.AddInt8(MySQLQuery.Rows.Count)

        Dim i As Integer = 1
        For Each SellRow As DataRow In MySQLQuery.Rows
            packet.AddInt32(i)
            packet.AddInt32(SellRow.Item("sell_item"))

            'ItemModel
            Try
                packet.AddInt32(ITEMDatabase(CType(SellRow.Item("sell_item"), Integer)).Model)
            Catch
                Dim tmpItem As New ItemInfo(CType(SellRow.Item("sell_item"), Integer))
                packet.AddInt32(ITEMDatabase(CType(SellRow.Item("sell_item"), Integer)).Model)
            End Try

            'AviableCount
            packet.AddInt32(-1)

            'SellPrice
            If SellRow.Item("sell_price") > 0 Then
                packet.AddInt32(SellRow.Item("sell_price"))
            Else
                packet.AddInt32(ITEMDatabase(CType(SellRow.Item("sell_item"), Integer)).BuyPrice)
            End If

            'Unk
            packet.AddInt32(SellRow.Item("sell_count"))

            'StackSize
            If SellRow.Item("sell_count") > 0 Then
                If SellRow.Item("sell_count") = 1 Then packet.AddInt32(0) Else packet.AddInt32(SellRow.Item("sell_count"))
            Else
                If ITEMDatabase(CType(SellRow.Item("sell_item"), Integer)).Stackable = 1 Then packet.AddInt32(0) Else packet.AddInt32(ITEMDatabase(CType(SellRow.Item("sell_item"), Integer)).Stackable)
            End If

            i += 1
        Next

        Character.Client.Send(packet)
        packet.Dispose()
    End Sub


#End Region
#Region "Taxi"


    Public Sub On_CMSG_TAXINODE_STATUS_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim currentTaxi As Integer = GetNearestTaxi(Client.Character.positionX, Client.Character.positionY)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TAXINODE_STATUS_QUERY [taxiGUID={2:X} node={3}]", Client.IP, Client.Port, GUID, currentTaxi)

        Dim SMSG_TAXINODE_STATUS As New PacketClass(OPCODES.SMSG_TAXINODE_STATUS)
        SMSG_TAXINODE_STATUS.AddInt64(GUID)
        If Client.Character.TaxiZones.Item(currentTaxi) = False Then SMSG_TAXINODE_STATUS.AddInt8(0) Else SMSG_TAXINODE_STATUS.AddInt8(1)
        Client.Send(SMSG_TAXINODE_STATUS)
        SMSG_TAXINODE_STATUS.Dispose()
    End Sub
    Public Sub On_CMSG_TAXIQUERYAVAILABLENODES(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TAXIQUERYAVAILABLENODES [taxiGUID={2:X}]", Client.IP, Client.Port, GUID)

        Dim currentTaxi As Integer = GetNearestTaxi(Client.Character.positionX, Client.Character.positionY)
        If Client.Character.TaxiZones.Item(currentTaxi) = False Then
            Client.Character.TaxiZones.Set(currentTaxi, True)

            Dim SMSG_NEW_TAXI_PATH As New PacketClass(OPCODES.SMSG_NEW_TAXI_PATH)
            Client.Send(SMSG_NEW_TAXI_PATH)
            SMSG_NEW_TAXI_PATH.Dispose()

            Dim SMSG_TAXINODE_STATUS As New PacketClass(OPCODES.SMSG_TAXINODE_STATUS)
            SMSG_TAXINODE_STATUS.AddInt64(GUID)
            SMSG_TAXINODE_STATUS.AddInt8(1)
            Client.Send(SMSG_TAXINODE_STATUS)
            SMSG_TAXINODE_STATUS.Dispose()
        End If


        Dim SMSG_SHOWTAXINODES As New PacketClass(OPCODES.SMSG_SHOWTAXINODES)
        SMSG_SHOWTAXINODES.AddInt32(1)
        SMSG_SHOWTAXINODES.AddInt64(GUID)
        SMSG_SHOWTAXINODES.AddInt32(currentTaxi)
        SMSG_SHOWTAXINODES.AddBitArray(Client.Character.TaxiZones, 8 * 4)
        Client.Send(SMSG_SHOWTAXINODES)
        SMSG_SHOWTAXINODES.Dispose()
    End Sub
    Public Sub On_CMSG_ACTIVATETAXI(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim srcNode As Integer = packet.GetInt32
        Dim dstNode As Integer = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_ACTIVATETAXI [taxiGUID={2:X} srcNode={3} dstNode={4}]", Client.IP, Client.Port, GUID, srcNode, dstNode)

        Dim SMSG_ACTIVATETAXIREPLY As New PacketClass(OPCODES.SMSG_ACTIVATETAXIREPLY)
        SMSG_ACTIVATETAXIREPLY.AddInt32(1)       'Unaviable
        'SMSG_ACTIVATETAXIREPLY.AddInt32(3)       'NoMoney
        Client.Send(SMSG_ACTIVATETAXIREPLY)
        SMSG_ACTIVATETAXIREPLY.Dispose()

        'GetPlayer( )->SetUInt32Value( UNIT_FIELD_MOUNTDISPLAYID, MountId );
        'GetPlayer( )->SetFlag( UNIT_FIELD_FLAGS ,0x000004 );
        'GetPlayer( )->SetFlag( UNIT_FIELD_FLAGS, 0x002000 );

        'uint32 traveltime = uint32(pathnodes.GetTotalLength( ) * 32);
        'data.Initialize( SMSG_MONSTER_MOVE );
        'data << uint8(0xFF);
        'data << GetPlayer( )->GetGUID();
        'data << GetPlayer( )->GetPositionX( )
        '    << GetPlayer( )->GetPositionY( )
        '    << GetPlayer( )->GetPositionZ( );
        'data << GetPlayer( )->GetOrientation( );
        'data << uint8( 0 );
        'data << uint32( 0x00000300 );
        'data << uint32( traveltime );
        'data << uint32( pathnodes.Size( ) );
        'data.append( (char*)pathnodes.GetNodes( ), pathnodes.Size( ) * 4 * 3 );
    End Sub

    Public Sub SendTaxiStatus(ByVal Character As CharacterObject, ByVal GUID As Long)

    End Sub


#End Region
#Region "Banker"


    Public Const dbcBankBagSlotsMax As Integer = 12
    Public dbcBankBagSlotPrices(dbcBankBagSlotsMax) As Integer


    Public Sub On_CMSG_AUTOBANK_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim srcBag As Byte = packet.GetInt8
        Dim srcSlot As Byte = packet.GetInt8
        If srcBag = 0 Then srcBag = 0

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_AUTOBANK_ITEM [srcSlot={2}:{3}]", Client.IP, Client.Port, srcBag, srcSlot)

        'TODO: Do real moving
    End Sub
    Public Sub On_CMSG_AUTOSTORE_BANK_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim srcBag As Byte = packet.GetInt8
        Dim srcSlot As Byte = packet.GetInt8
        If srcBag = 0 Then srcBag = 0

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_AUTOSTORE_BANK_ITEM [srcSlot={2}:{3}]", Client.IP, Client.Port, srcBag, srcSlot)

        'TODO: Do real moving
    End Sub
    Public Sub On_CMSG_BUY_BANK_SLOT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BUY_BANK_SLOT", Client.IP, Client.Port)

        If Client.Character.Items_AvailableBankSlots < dbcBankBagSlotsMax AndAlso _
           Client.Character.Copper >= dbcBankBagSlotPrices(Client.Character.Items_AvailableBankSlots) Then
            Client.Character.Copper -= dbcBankBagSlotPrices(Client.Character.Items_AvailableBankSlots)
            Client.Character.Items_AvailableBankSlots += 1

            Database.Update(String.Format("UPDATE adb_characters SET char_bankSlots = {0}, char_copper = {1};", Client.Character.Items_AvailableBankSlots, Client.Character.Copper))

            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_BYTES_2, (Client.Character.FacialHair + (&HEE << 8) + (CType(Client.Character.Items_AvailableBankSlots, Integer) << 16) + (CType(Client.Character.RestState, Integer) << 24)))
            Client.Character.SendCharacterUpdate(False)
        Else
            Dim errorPckt As New PacketClass(OPCODES.SMSG_BUY_FAILED)
            errorPckt.AddInt64(0)
            errorPckt.AddInt32(0)
            errorPckt.AddInt8(BUY_ERROR.BUY_ERR_NOT_ENOUGHT_MONEY)
            Client.Send(errorPckt)
            errorPckt.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_BANKER_ACTIVATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BANKER_ACTIVATE [GUID={2:X}]", Client.IP, Client.Port, GUID)

        SendShowBank(Client.Character, GUID)
    End Sub
    Public Sub SendShowBank(ByVal c As CharacterObject, ByVal GUID As Long)
        Dim packet As New PacketClass(OPCODES.SMSG_SHOW_BANK)
        packet.AddInt64(GUID)
        c.Client.Send(packet)
        packet.Dispose()
    End Sub


#End Region
#Region "Other"


    Public Sub SendBindPointConfirm(ByVal c As CharacterObject, ByVal GUID As Long)
        Dim packet As New PacketClass(OPCODES.SMSG_BINDER_CONFIRM)
        packet.AddInt64(GUID)
        c.Client.Send(packet)
        packet.Dispose()

        c.SendGossipComplete()
    End Sub
    Public Sub On_CMSG_BINDER_ACTIVATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BINDER_ACTIVATE [binderGUID={2:X}]", Client.IP, Client.Port, GUID)

        Dim response As New PacketClass(OPCODES.SMSG_TRAINER_BUY_SUCCEEDED)
        response.AddInt64(GUID)
        Client.Send(response)
        response.Dispose()

        Client.Character.BindPlayer(GUID)
    End Sub

    Public Sub SendTalentWipeConfirm(ByVal c As CharacterObject, ByVal Cost As Integer)
        Dim packet As New PacketClass(OPCODES.MSG_TALENT_WIPE_CONFIRM)
        packet.AddInt64(c.GUID)
        packet.AddInt32(Cost)
        c.Client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub On_MSG_TALENT_WIPE_CONFIRM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Try
            packet.GetInt16()
            Dim GUID As Long = packet.GetPackGUID
            Dim i As Integer

            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_TALENT_WIPE_CONFIRM [GUID={2:X}]", Client.IP, Client.Port, GUID)

            'DONE: Removing all talents
            For Each TalentInfo As DictionaryEntry In Talents
                For i = 0 To 4
                    If CType(TalentInfo.Value, TalentInfo).RankID(i) <> 0 Then
                        If Client.Character.HaveSpell(CType(TalentInfo.Value, TalentInfo).RankID(i)) Then
                            Client.Character.UnLearnSpell(CType(TalentInfo.Value, TalentInfo).RankID(i))
                        End If
                    End If
                Next i
            Next

            'DONE: Reset Talentpoints to Level - 9
            Client.Character.TalentPoints = Client.Character.Level - 9
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_CHARACTER_POINTS1, CType(Client.Character.TalentPoints, Integer))
            Client.Character.SendCharacterUpdate(True)

            'DONE: Use spell 14867
            Dim SMSG_SPELL_START As New PacketClass(OPCODES.SMSG_SPELL_START)
            SMSG_SPELL_START.AddPackGUID(Client.Character.GUID)
            SMSG_SPELL_START.AddPackGUID(GUID)
            SMSG_SPELL_START.AddInt16(14867)
            SMSG_SPELL_START.AddInt16(0)
            SMSG_SPELL_START.AddInt16(&HF)
            SMSG_SPELL_START.AddInt32(0)
            SMSG_SPELL_START.AddInt16(0)
            Client.Send(SMSG_SPELL_START)
            SMSG_SPELL_START.Dispose()

            Dim SMSG_SPELL_GO As New PacketClass(OPCODES.SMSG_SPELL_GO)
            SMSG_SPELL_GO.AddPackGUID(Client.Character.GUID)
            SMSG_SPELL_GO.AddPackGUID(GUID)
            SMSG_SPELL_GO.AddInt16(14867)
            SMSG_SPELL_GO.AddInt16(0)
            SMSG_SPELL_GO.AddInt8(&HD)
            SMSG_SPELL_GO.AddInt8(&H1)
            SMSG_SPELL_GO.AddInt8(&H1)
            SMSG_SPELL_GO.AddInt64(Client.Character.GUID)
            SMSG_SPELL_GO.AddInt32(0)
            SMSG_SPELL_GO.AddInt16(&H200)
            SMSG_SPELL_GO.AddInt16(0)
            Client.Send(SMSG_SPELL_GO)
            SMSG_SPELL_GO.Dispose()

        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Error unlearning talents: {0}{1}", vbNewLine, e.ToString)
        End Try
    End Sub


#End Region
#Region "Default Menu"


    Enum Gossip_Option

        GOSSIP_OPTION_NONE = 0                                 'UNIT_NPC_FLAG_NONE              = 0
        GOSSIP_OPTION_GOSSIP = 1                               'UNIT_NPC_FLAG_GOSSIP            = 1
        GOSSIP_OPTION_QUESTGIVER = 2                           'UNIT_NPC_FLAG_QUESTGIVER        = 2
        GOSSIP_OPTION_VENDOR = 3                               'UNIT_NPC_FLAG_VENDOR            = 4
        GOSSIP_OPTION_TAXIVENDOR = 4                           'UNIT_NPC_FLAG_TAXIVENDOR        = 8
        GOSSIP_OPTION_TRAINER = 5                              'UNIT_NPC_FLAG_TRAINER           = 16
        GOSSIP_OPTION_SPIRITHEALER = 6                         'UNIT_NPC_FLAG_SPIRITHEALER      = 32
        GOSSIP_OPTION_GUARD = 7                                'UNIT_NPC_FLAG_GUARD		        = 64
        GOSSIP_OPTION_INNKEEPER = 8                            'UNIT_NPC_FLAG_INNKEEPER         = 128
        GOSSIP_OPTION_BANKER = 9                               'UNIT_NPC_FLAG_BANKER            = 256
        GOSSIP_OPTION_PETITIONER = 10                          'UNIT_NPC_FLAG_PETITIONER        = 512
        GOSSIP_OPTION_TABARDVENDOR = 11                        'UNIT_NPC_FLAG_TABARDVENDOR      = 1024
        GOSSIP_OPTION_BATTLEFIELD = 12                         'UNIT_NPC_FLAG_BATTLEFIELDPERSON = 2048
        GOSSIP_OPTION_AUCTIONEER = 13                          'UNIT_NPC_FLAG_AUCTIONEER        = 4096
        GOSSIP_OPTION_STABLEPET = 14                           'UNIT_NPC_FLAG_STABLE            = 8192
        GOSSIP_OPTION_ARMORER = 15                             'UNIT_NPC_FLAG_ARMORER           = 16384
        GOSSIP_OPTION_TALENTWIPE = 16
    End Enum
    Enum Gossip_Guard
        GOSSIP_GUARD_BANK = 32
        GOSSIP_GUARD_RIDE = 33
        GOSSIP_GUARD_GUILD = 34
        GOSSIP_GUARD_INN = 35
        GOSSIP_GUARD_MAIL = 36
        GOSSIP_GUARD_AUCTION = 37
        GOSSIP_GUARD_WEAPON = 38
        GOSSIP_GUARD_STABLE = 39
        GOSSIP_GUARD_BATTLE = 40
        GOSSIP_GUARD_SPELLTRAINER = 41
        GOSSIP_GUARD_SKILLTRAINER = 42
    End Enum
    Enum Gossip_Guard_Spell
        GOSSIP_GUARD_SPELL_WARRIOR = 64
        GOSSIP_GUARD_SPELL_PALADIN = 65
        GOSSIP_GUARD_SPELL_HUNTER = 66
        GOSSIP_GUARD_SPELL_ROGUE = 67
        GOSSIP_GUARD_SPELL_PRIEST = 68
        GOSSIP_GUARD_SPELL_UNKNOWN1 = 69
        GOSSIP_GUARD_SPELL_SHAMAN = 70
        GOSSIP_GUARD_SPELL_MAGE = 71
        GOSSIP_GUARD_SPELL_WARLOCK = 72
        GOSSIP_GUARD_SPELL_UNKNOWN2 = 73
        GOSSIP_GUARD_SPELL_DRUID = 74
    End Enum
    Enum Gossip_Guard_Skill
        GOSSIP_GUARD_SKILL_ALCHEMY = 80
        GOSSIP_GUARD_SKILL_BLACKSMITH = 81
        GOSSIP_GUARD_SKILL_COOKING = 82
        GOSSIP_GUARD_SKILL_ENCHANT = 83
        GOSSIP_GUARD_SKILL_FIRSTAID = 84
        GOSSIP_GUARD_SKILL_FISHING = 85
        GOSSIP_GUARD_SKILL_HERBALISM = 86
        GOSSIP_GUARD_SKILL_LEATHER = 87
        GOSSIP_GUARD_SKILL_MINING = 88
        GOSSIP_GUARD_SKILL_SKINNING = 89
        GOSSIP_GUARD_SKILL_TAILORING = 90
        GOSSIP_GUARD_SKILL_ENGINERING = 91
    End Enum

    Public Class TDefaultTalk
        Inherits TBaseTalk

        Public Overrides Sub OnGossipHello(ByRef c As CharacterObject, ByVal cGUID As Long)
            Dim npcText As New NPCText
            npcText.Count = 1
            npcText.TextID = 99999999
            npcText.TextLine1(0) = "Greetings $N."
            SendNPCText(c.Client, npcText)

            'UNIT_NPC_FLAG_NONE = 0                          ' None
            'UNIT_NPC_FLAG_GOSSIP = 1                        ' Gossip/Talk (CMSG_GOSSIP_HELLO ?)
            'UNIT_NPC_FLAG_QUESTGIVER = 2                    ' Questgiver
            'UNIT_NPC_FLAG_VENDOR = 4                        ' Vendor (CMSG_LIST_INVENTORY SMSG_LIST_INVENTORY)
            'UNIT_NPC_FLAG_TAXIVENDOR = 8                    ' Taxi Vendor (CMSG_TAXIQUERYAVAILABLENODES SMSG_SHOWTAXINODES)
            'UNIT_NPC_FLAG_TRAINER = 16                      ' Trainer (CMSG_TRAINER_LIST SMSG_TRAINER_LIST)
            'UNIT_NPC_FLAG_SPIRITHEALER = 32                 ' Spirithealer (CMSG_BINDER_ACTIVATE ?)
            'UNIT_NPC_FLAG_GUARD = 64
            'UNIT_NPC_FLAG_INNKEEPER = 128                   ' Innkeeper
            'UNIT_NPC_FLAG_BANKER = 256                      ' Banker (CMSG_BANKER_ACTIVATE SMSG_SHOW_BANK)
            'UNIT_NPC_FLAG_PETITIONER = 512                  ' Petitioner/?Guild Charter? (CMSG_PETITION_SHOWLIST SMSG_PETITION_SHOWLIST)
            'UNIT_NPC_FLAG_TABARDVENDOR = 1024               ' Tabard Vendor (MSG_TABARDVENDOR_ACTIVATE)
            'UNIT_NPC_FLAG_BATTLEFIELDPERSON = 2048          ' Battlefield Person (CMSG_BATTLEFIELD_LIST SMSG_BATTLEFIELD_LIST)
            'UNIT_NPC_FLAG_AUCTIONEER = 4096                 ' Auctioneer (MSG_AUCTION_HELLO)
            'UNIT_NPC_FLAG_STABLE = 8192                     ' Stable Master
            'UNIT_NPC_FLAG_ARMORER = 16384                   ' ARMORER ..

            Dim npcMenu As New GossipMenu
            If CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags = NPCFlags.UNIT_NPC_FLAG_GOSSIP Then
                npcMenu.AddMenu("Merchants", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("The Bank", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("The Inn", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Class trainers", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Profession trainers", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Suppliers", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("The stable masters", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Gryphon masters", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Guild masters", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Auction House", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Mailboxes", MenuIcon.MENUICON_GOSSIP)
                npcMenu.AddMenu("Weapons Trainers", MenuIcon.MENUICON_GOSSIP)
                c.SendGossip(cGUID, 99999999, npcMenu)
                Exit Sub
            End If

            c.TalkMenuTypes.Clear()
            'TODO: List quests
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_VENDOR) = NPCFlags.UNIT_NPC_FLAG_VENDOR Then
                npcMenu.AddMenu("Let me browse your goods.", MenuIcon.MENUICON_VENDOR)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_VENDOR)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_TAXIVENDOR) = NPCFlags.UNIT_NPC_FLAG_TAXIVENDOR Then
                npcMenu.AddMenu("I want to continue my journey.", MenuIcon.MENUICON_TAXI)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_TAXIVENDOR)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_TRAINER) = NPCFlags.UNIT_NPC_FLAG_TRAINER Then
                npcMenu.AddMenu("I am interested in $C training.", MenuIcon.MENUICON_TRAINER)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_TRAINER)
                npcMenu.AddMenu("I want to unlearn all my talents.", MenuIcon.MENUICON_GOSSIP)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_TALENTWIPE)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_SPIRITHEALER) = NPCFlags.UNIT_NPC_FLAG_SPIRITHEALER Then
                npcMenu.AddMenu("Return me to life", MenuIcon.MENUICON_GOSSIP)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_SPIRITHEALER)
            End If
            'UNIT_NPC_FLAG_GUARD
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_INNKEEPER) = NPCFlags.UNIT_NPC_FLAG_INNKEEPER Then
                npcMenu.AddMenu("Make this inn your home.", MenuIcon.MENUICON_BINDER)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_INNKEEPER)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_BANKER) = NPCFlags.UNIT_NPC_FLAG_BANKER Then
                npcMenu.AddMenu("I wanna make some bank transactions.", MenuIcon.MENUICON_BANKER)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_BANKER)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_PETITIONER) = NPCFlags.UNIT_NPC_FLAG_PETITIONER Then
                npcMenu.AddMenu("I am interested in guilds.", MenuIcon.MENUICON_PETITION)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_PETITIONER)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_TABARDVENDOR) = NPCFlags.UNIT_NPC_FLAG_TABARDVENDOR Then
                npcMenu.AddMenu("I want to purchase a tabard.", MenuIcon.MENUICON_TABARD)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_TABARDVENDOR)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_BATTLEFIELDPERSON) = NPCFlags.UNIT_NPC_FLAG_BATTLEFIELDPERSON Then
                npcMenu.AddMenu("My blood hungers for battle.", MenuIcon.MENUICON_BATTLEMASTER)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_BATTLEFIELD)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_AUCTIONEER) = NPCFlags.UNIT_NPC_FLAG_AUCTIONEER Then
                npcMenu.AddMenu("Wanna auction something?", MenuIcon.MENUICON_AUCTIONER)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_AUCTIONEER)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_STABLE) = NPCFlags.UNIT_NPC_FLAG_STABLE Then
                npcMenu.AddMenu("Let me check my pet.", MenuIcon.MENUICON_VENDOR)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_STABLEPET)
            End If
            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_ARMORER) = NPCFlags.UNIT_NPC_FLAG_ARMORER Then
                npcMenu.AddMenu("I want to browse your goods", MenuIcon.MENUICON_VENDOR)
                c.TalkMenuTypes.Add(Gossip_Option.GOSSIP_OPTION_ARMORER)
            End If



            If (CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).cNpcFlags And NPCFlags.UNIT_NPC_FLAG_QUESTGIVER) = NPCFlags.UNIT_NPC_FLAG_QUESTGIVER Then
                Dim qMenu As QuestMenu = GetQuestMenu(c, cGUID)
                c.SendGossip(cGUID, 99999999, npcMenu, qMenu)
            Else
                c.SendGossip(cGUID, 99999999, npcMenu)
            End If


        End Sub
        Public Overrides Sub OnGossipSelect(ByRef c As CharacterObject, ByVal cGUID As Long, ByVal Selected As Integer)
            Select Case CType(c.TalkMenuTypes(Selected), Gossip_Option)
                Case Gossip_Option.GOSSIP_OPTION_SPIRITHEALER
                    If c.DEAD = True Then
                        Dim response As New WorldServer.PacketClass(OPCODES.SMSG_SPIRIT_HEALER_CONFIRM)
                        response.AddInt64(cGUID)
                        c.Client.Send(response)
                        response.Dispose()
                    End If


                Case Gossip_Option.GOSSIP_OPTION_VENDOR, Gossip_Option.GOSSIP_OPTION_ARMORER, Gossip_Option.GOSSIP_OPTION_STABLEPET
                    SendListInventory(c, CREATURESDatabase(WORLD_CREATUREs(cGUID).ID).SellTable, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_TRAINER
                    SendTrainerList(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_TAXIVENDOR
                    SendTaxiStatus(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_INNKEEPER
                    SendBindPointConfirm(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_BANKER
                    SendShowBank(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_PETITIONER
                    SendPetitionActivate(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_TABARDVENDOR
                    SendTabardActivate(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_AUCTIONEER
                    SendShowAuction(c, cGUID)
                Case Gossip_Option.GOSSIP_OPTION_TALENTWIPE
                    SendTalentWipeConfirm(c, 0)
                Case Gossip_Option.GOSSIP_OPTION_GUARD
                    'TODO: Unhandled gossip action
                Case Gossip_Option.GOSSIP_OPTION_GOSSIP
                    'TODO: Unhandled gossip action
                Case Gossip_Option.GOSSIP_OPTION_QUESTGIVER
                    'NOTE: This may stay unused
                    Dim qMenu As QuestMenu = GetQuestMenu(c, cGUID)
                    SendQuestMenu(c, cGUID, "I have some tasks for you, $N.", qMenu)
            End Select
            c.SendGossipComplete()
        End Sub
    End Class


#End Region

End Module


