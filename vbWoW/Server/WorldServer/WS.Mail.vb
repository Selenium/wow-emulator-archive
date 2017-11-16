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

Public Module WS_Mail

#Region "WS.Mail.Constants"

    Public Const ITEM_MAILTEXT_ITEMID As Integer = 889

    Private Enum MailResult
        MAIL_SENT = 0
        MAIL_MONEY_REMOVED = 1
        MAIL_ITEM_REMOVED = 2
        MAIL_RETURNED = 3
        MAIL_DELETED = 4
        MAIL_MADE_PERMANENT = 5
    End Enum
    Private Enum MailSentError
        NO_ERROR = 0
        BAG_FULL = 1
        CANNOT_SEND_TO_SELF = 2
        NOT_ENOUGHT_MONEY = 3
        CHARACTER_NOT_FOUND = 4
        NOT_YOUR_ALLIANCE = 5
        INTERNAL_ERROR = 6
    End Enum

    Private Enum MailReadInfo As Byte
        Unread = 0
        Read = 1
        Auction = 4
        COD = 8
    End Enum
    Private Enum MailTypeInfo As Byte
        NORMAL = 0
        GMMAIL = 1
        AUCTION = 2
    End Enum


#End Region
#Region "WS.Mail.Hanlders"


    Public Sub On_CMSG_MAIL_RETURN_TO_SENDER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim MailID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_RETURN_TO_SENDER [MailID={2}]", Client.IP, Client.Port, MailID)

        'A = 1
        'B = 2
        'A = A + B '3
        'B = A - B '3-2=1
        'A = A - B '3-1=2

        Database.Update(String.Format("UPDATE adb_characters_mail SET mail_time = 30, mail_read = 0, mail_receiver = (mail_receiver + mail_sender), mail_sender = (mail_receiver - mail_sender), mail_receiver = (mail_receiver - mail_sender) WHERE mail_id = {0};", MailID))

        Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
        response.AddInt32(MailID)
        response.AddInt32(MailResult.MAIL_RETURNED)
        response.AddInt32(0)
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_MAIL_DELETE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim MailID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_DELETE [MailID={2}]", Client.IP, Client.Port, MailID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT mail_item_guid FROM adb_characters_mail WHERE mail_id = {0};", MailID), MySQLQuery)

        If MySQLQuery.Rows.Count > 0 Then Database.Update(String.Format("DELETE FROM adb_characters_inventory WHERE item_guid = {0};", MySQLQuery.Rows(0).Item("mail_item_guid")))
        Database.Update(String.Format("DELETE FROM adb_characters_mail WHERE mail_id = {0};", MailID))

        Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
        response.AddInt32(MailID)
        response.AddInt32(MailResult.MAIL_DELETED)
        response.AddInt32(0)
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_MAIL_MARK_AS_READ(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim MailID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_MARK_AS_READ [MailID={2}]", Client.IP, Client.Port, MailID)
        Database.Update(String.Format("UPDATE adb_characters_mail SET mail_read = 1, mail_time = 3 WHERE mail_id = {0} AND mail_read < 2;", MailID))
    End Sub
    Public Sub On_MSG_QUERY_NEXT_MAIL_TIME(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_QUERY_NEXT_MAIL_TIME", Client.IP, Client.Port)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT COUNT(*) FROM adb_characters_mail WHERE mail_read = 0 AND mail_receiver = {0};", Client.Character.GUID), MySQLQuery)
        If MySQLQuery.Rows(0).Item(0) > 0 Then
            Dim response As New PacketClass(OPCODES.MSG_QUERY_NEXT_MAIL_TIME)
            response.AddInt32(0)
            Client.Send(response)
            response.Dispose()
        Else
            Dim response As New PacketClass(OPCODES.MSG_QUERY_NEXT_MAIL_TIME)
            response.AddInt8(0)
            response.AddInt8(&HC0)
            response.AddInt8(&HA8)
            response.AddInt8(&HC7)
            Client.Send(response)
            response.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_GET_MAIL_LIST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GET_MAIL_LIST [GUID={2:X}]", Client.IP, Client.Port, GameObjectGUID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_characters_mail WHERE mail_receiver = {0};", Client.Character.GUID), MySQLQuery)

        Dim response As New PacketClass(OPCODES.SMSG_MAIL_LIST_RESULT)
        response.AddInt8(MySQLQuery.Rows.Count)

        Dim i As Byte = 0
        Dim tmpItem As ItemObject
        While i < MySQLQuery.Rows.Count
            response.AddInt32(MySQLQuery.Rows(i).Item("mail_id"))
            response.AddInt8(MySQLQuery.Rows(i).Item("mail_type"))

            Select Case CType(MySQLQuery.Rows(i).Item("mail_type"), Byte)
                Case MailTypeInfo.NORMAL 'Normal Mail
                    response.AddInt64(MySQLQuery.Rows(i).Item("mail_sender"))

                    response.AddString(MySQLQuery.Rows(i).Item("mail_subject"))

                    If MySQLQuery.Rows(i).Item("mail_body") <> "" Then
                        response.AddInt32(MySQLQuery.Rows(i).Item("mail_id"))
                    Else
                        response.AddInt32(0)
                    End If
                    response.AddInt32(0)                                            '2  = Gift
                    response.AddInt32(MySQLQuery.Rows(i).Item("mail_stationery"))   '41 = Mail Background
                Case MailTypeInfo.GMMAIL  'GM Mail ?

                Case MailTypeInfo.AUCTION  'Auction Mail
                    'NOTE: For mail body/text use this structure (first is 16 length string = guid in hex, but if 0 then use space)
                    'AuctionSuccessful -> Buyer : Sale Price : Buyout Price : Deposit : Auction House Cut
                    'AuctionWon ->        Seller: Ammount(Paid) : Buyout(Price)
                    'AuctionOutbid ->     UNKNOWN

                    response.AddInt32(AuctionHouses.AUCTION_ALLIANCE)                       'AuctionSide
                    response.AddString(MySQLQuery.Rows(i).Item("mail_subject"))             'ItemID:"of the ...":AuctionResult (0:Outbid 1:Won 2:Successful 3:Expired 4:Cancelled)

                    If MySQLQuery.Rows(i).Item("mail_body") <> "" Then
                        response.AddInt32(MySQLQuery.Rows(i).Item("mail_id"))
                    Else
                        response.AddInt32(0)
                    End If
                    response.AddInt32(0)                                            '2  = Gift
                    response.AddInt32(MySQLQuery.Rows(i).Item("mail_stationery"))   '62 = Mail Background
            End Select

            If (MySQLQuery.Rows(i).Item("mail_item_guid") > 0) Then
                tmpItem = LoadItemByGUID(CType(MySQLQuery.Rows(i).Item("mail_item_guid"), Long))
                response.AddInt32(tmpItem.ItemEntry)
                response.AddInt32(0)                                        'Enchantment information 1
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 2
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 3
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 4
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 5
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 6
                response.AddInt64(0)
                response.AddInt32(tmpItem.RandomProperties)                 'Item random property
                response.AddInt32(0)                                        'Sockets?
                response.AddInt8(tmpItem.StackCount)                        'Item cout
                response.AddInt32(tmpItem.ChargesLeft)                      'Spell Charges
                response.AddInt32(tmpItem.Durability)                       'Durability Max
                response.AddInt32(tmpItem.ItemInfo.Durability)              'Durability Min
            Else
                response.AddInt32(0)
                response.AddInt32(0)                                        'Enchantment information 1
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 2
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 3
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 4
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 5
                response.AddInt64(0)
                response.AddInt32(0)                                        'Enchantment information 6
                response.AddInt64(0)
                response.AddInt32(0)                                        'Item random property
                response.AddInt32(0)                                        'Sockets?
                response.AddInt8(0)                                         'ItemCount
                response.AddInt32(&HFFFFFFFF)                               'Spell Charges
                response.AddInt32(0)                                        'Durability Max
                response.AddInt32(0)                                        'Durability Min
            End If

            response.AddInt32(MySQLQuery.Rows(i).Item("mail_money"))    'Money on delivery
            response.AddInt32(MySQLQuery.Rows(i).Item("mail_COD"))      'Money as COD
            response.AddInt32(MySQLQuery.Rows(i).Item("mail_read"))     'Read status (0:Unread 1:Read 4:Auction 8:"COD Payment: ")
            response.AddSingle(MySQLQuery.Rows(i).Item("mail_time"))    'Mail time in days
            response.AddInt32(0)
            i += 1
        End While

        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_MAIL_TAKE_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim MailID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_TAKE_ITEM [MailID={2}]", Client.IP, Client.Port, MailID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT mail_cod, mail_sender, mail_item_guid FROM adb_characters_mail WHERE mail_id = {0};", MailID), MySQLQuery)

        'DONE: Check for COD
        If MySQLQuery.Rows(0).Item("mail_cod") <> 0 Then
            If Client.Character.Copper < MySQLQuery.Rows(0).Item("mail_cod") Then
                Dim noMoney As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
                noMoney.AddInt32(MailID)
                noMoney.AddInt32(MailResult.MAIL_SENT)
                noMoney.AddInt32(MailSentError.NOT_ENOUGHT_MONEY)
                Client.Send(noMoney)
                noMoney.Dispose()
                Exit Sub
            Else
                'DONE: Pay COD and save
                Client.Character.Copper -= MySQLQuery.Rows(0).Item("mail_cod")
                Database.Update(String.Format("UPDATE adb_characters_mail SET mail_cod = 0 WHERE mail_id = {0};", MailID))

                'DONE: Send COD to sender
                'TODO: Edit text to be more blizzlike
                Database.Update(String.Format("INSERT INTO adb_characters_mail (mail_sender, mail_receiver, mail_subject, mail_body,  mail_item_guid, mail_money, mail_COD, mail_time, mail_read, mail_type) VALUES ({0},{1},'{2}','{3}',{4},{5},{6},{7},{8},{9});", Client.Character.GUID, MySQLQuery.Rows(0).Item("mail_sender"), "", "", 0, MySQLQuery.Rows(0).Item("mail_cod"), 0, 30, MailReadInfo.COD, 0))
            End If
        End If

        'DONE: Get Item
        Dim tmpItem As ItemObject = LoadItemByGUID(CType(MySQLQuery.Rows(0).Item("mail_item_guid"), Long))
        tmpItem.OwnerGUID = Client.Character.GUID
        tmpItem.Save()

        'DONE: Send error message if no slots
        If Client.Character.ItemADD(tmpItem) Then
            Database.Update(String.Format("UPDATE adb_characters_mail SET mail_item_guid = 0 WHERE mail_id = {0};", MailID))

            Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
            response.AddInt32(MailID)
            response.AddInt32(MailResult.MAIL_ITEM_REMOVED)
            response.AddInt32(MailSentError.NO_ERROR)
            Client.Send(response)
            response.Dispose()
        Else
            tmpItem.Dispose()

            Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
            response.AddInt32(MailID)
            response.AddInt32(MailResult.MAIL_ITEM_REMOVED)
            response.AddInt32(MailSentError.BAG_FULL)
            Client.Send(response)
            response.Dispose()
        End If
        Client.Character.Save()
    End Sub
    Public Sub On_CMSG_MAIL_TAKE_MONEY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim MailID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_TAKE_MONEY [MailID={2}]", Client.IP, Client.Port, MailID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT mail_money FROM adb_characters_mail WHERE mail_id = {0}; UPDATE adb_characters_mail SET mail_money = 0 WHERE mail_id = {0};", MailID), MySQLQuery)
        Client.Character.Copper += MySQLQuery.Rows(0).Item("mail_money")
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

        Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
        response.AddInt32(MailID)
        response.AddInt32(MailResult.MAIL_MONEY_REMOVED)
        response.AddInt32(0)
        Client.Send(response)
        response.Dispose()

        Client.Character.SaveCharacter()
    End Sub
    Public Sub On_CMSG_ITEM_TEXT_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim MailID As Integer = packet.GetInt32
        'Dim GameObjectGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_ITEM_TEXT_QUERY [MailID={2}]", Client.IP, Client.Port, MailID)

        Dim MySQLQuery As New DataTable
        Database.Query(String.Format("SELECT mail_body FROM adb_characters_mail WHERE mail_id = {0};", MailID), MySQLQuery)

        Dim response As New PacketClass(OPCODES.SMSG_ITEM_TEXT_QUERY_RESPONSE)
        response.AddInt32(MailID)
        response.AddString(MySQLQuery.Rows(0).Item("mail_body"))
        Client.Send(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_MAIL_CREATE_TEXT_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim MailID As Integer = packet.GetInt32
        'Dim GameObjectGUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MAIL_CREATE_TEXT_ITEM [MailID={2}]", Client.IP, Client.Port, MailID)

        'DONE: Create Item with ITEM_FIELD_ITEM_TEXT_ID = MailID
        Dim tmpItem As New ItemObject(ITEM_MAILTEXT_ITEMID, Client.Character.GUID)
        tmpItem.ItemText = MailID
        If Not Client.Character.ItemADD(tmpItem) Then
            Dim response As New PacketClass(OPCODES.SMSG_ITEM_TEXT_QUERY_RESPONSE)
            response.AddInt32(MailID)
            response.AddInt32(0)
            response.AddInt32(1)
            Client.Send(response)
            response.Dispose()

            tmpItem.Delete()
        Else
            Client.Character.SendItemUpdate(tmpItem)
        End If
    End Sub
    Public Sub On_CMSG_SEND_MAIL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GameObjectGUID As Long = packet.GetInt64
        Dim Receiver As String = packet.GetString
        Dim Subject As String = packet.GetString
        Dim Body As String = packet.GetString
        packet.GetInt32()
        packet.GetInt32()
        Dim ItemGUID As Long = packet.GetInt64
        Dim money As Integer = packet.GetInt32
        Dim COD As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SEND_MAIL [Receiver={2} Subject={3}]", Client.IP, Client.Port, Receiver, Subject)

        If (Client.Character.Copper - money) < 30 Then
            Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
            response.AddInt32(0)
            response.AddInt32(MailResult.MAIL_SENT)
            response.AddInt32(MailSentError.NOT_ENOUGHT_MONEY)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        Dim MySQLQuery As New DataTable
        Database.Query("SELECT char_guid FROM adb_characters WHERE char_name LIKE '" & Receiver & "';", MySQLQuery)

        If MySQLQuery.Rows.Count = 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
            response.AddInt32(0)
            response.AddInt32(MailResult.MAIL_SENT)
            response.AddInt32(MailSentError.CHARACTER_NOT_FOUND)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If
        Dim ReceiverGUID As Long = MySQLQuery.Rows(0).Item("char_guid")

        Client.Character.Copper -= (30 + money)
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

        Dim ItemEntry As Integer = 0
        Dim ItemCount As Integer = 1
        If ItemGUID <> 0 Then
            Dim bag As Byte = 0
            Dim slot As Byte = Client.Character.ItemGetSLOTBAG(ItemGUID, bag)
            Client.Character.ItemREMOVE(bag, slot, False, True)
            ItemEntry = WORLD_ITEMs(ItemGUID).ItemEntry
            ItemCount = WORLD_ITEMs(ItemGUID).StackCount
        End If
        Database.Update(String.Format("INSERT INTO adb_characters_mail (mail_sender, mail_receiver, mail_subject, mail_body,  mail_item_guid, mail_money, mail_COD, mail_time, mail_read, mail_type,  mail_stationery) VALUES ({0},{1},'{2}','{3}',{4},{5},{6},{7},{8},{9},41);", Client.Character.GUID, ReceiverGUID, Subject.Replace("'", "`"), Body.Replace("'", "`"), ItemGUID, money, COD, 30, CType(MailReadInfo.Unread, Byte), 0))

        Dim sendOK As New PacketClass(OPCODES.SMSG_SEND_MAIL_RESULT)
        sendOK.AddInt32(0)
        sendOK.AddInt32(MailResult.MAIL_SENT)
        sendOK.AddInt32(MailSentError.NO_ERROR)
        Client.Send(sendOK)
        sendOK.Dispose()

        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        If CHARACTERS.ContainsKey(CType(MySQLQuery.Rows(0).Item("char_guid"), Long)) Then
            Dim response As New PacketClass(OPCODES.SMSG_RECEIVED_MAIL)
            response.AddInt32(0)
            CHARACTERS(CType(MySQLQuery.Rows(0).Item("char_guid"), Long)).CLient.Send(response)
            response.Dispose()
        End If
        charactersLock_.ReleaseReaderLock()
    End Sub


#End Region

End Module
