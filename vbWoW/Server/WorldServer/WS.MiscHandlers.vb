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

Public Module WS_MiscHandlers

    Public Enum LANGUAGES As Integer
        LANG_UNIVERSAL = &H0
        LANG_ORCISH = &H1
        LANG_DARNASSIAN = &H2
        LANG_TAURAHE = &H3
        LANG_DWARVISH = &H6
        LANG_COMMON = &H7
        LANG_DEMONIC = &H8
        LANG_TITAN = &H9
        LANG_THELASSIAN = &HA
        LANG_DRACONIC = &HB
        LANG_KALIMAG = &HC
        LANG_GNOMISH = &HD
        LANG_TROLL = &HE
        LANG_GUTTERSPEAK = 33
    End Enum

#Region "WS.HelpingSubs"
    Public Function GetGUID(ByVal Name As String) As Long
        If CHARACTER_NAMEs.ContainsKey(Name) Then
            Return CHARACTER_NAMEs(Name)
        Else
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT char_guid FROM adb_characters WHERE char_name = ""{0}"";", Name), MySQLQuery)

            If MySQLQuery.Rows.Count > 0 Then
                Return CType(MySQLQuery.Rows(0).Item("char_guid"), Long)
            Else
                Return 0
            End If
        End If
    End Function
    Public Sub SendGameTime(ByRef Client As ClientClass, ByRef Character As CharacterObject)
        Dim SMSG_LOGIN_SETTIMESPEED As New PacketClass(OPCODES.SMSG_LOGIN_SETTIMESPEED)

        Dim time As DateTime = DateTime.Now
        Dim Year As Integer = time.Year - 2000
        Dim Month As Integer = time.Month - 1
        Dim Day As Integer = time.Day - 1
        Dim DayOfWeek As Integer = CType(time.DayOfWeek, Integer)
        Dim Hour As Integer = time.Hour
        Dim Minute As Integer = time.Minute

        'SMSG_LOGIN_SETTIMESPEED.AddInt32(CType((((((Minute + (Hour << 6)) + (DayOfWeek << 11)) + (Day << 14)) + (Year << 18)) + (Month << 20)), Integer))
        SMSG_LOGIN_SETTIMESPEED.AddInt32(CType((((((Minute + (Hour << 6)) + (DayOfWeek << 11)) + (Day << 14)) + (Month << 20)) + (Year << 24)), Integer))
        SMSG_LOGIN_SETTIMESPEED.AddSingle(0.017F)

        Client.Send(SMSG_LOGIN_SETTIMESPEED)
        SMSG_LOGIN_SETTIMESPEED.Dispose()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_LOGIN_SETTIMESPEED", Client.IP, Client.Port)
    End Sub
    Public Sub SendAccountMD5(ByRef Client As ClientClass, ByRef Character As CharacterObject)
        Dim SMSG_ACCOUNT_DATA_MD5 As New PacketClass(OPCODES.SMSG_ACCOUNT_DATA_MD5)

        Dim i As Integer
        For i = 1 To 80
            SMSG_ACCOUNT_DATA_MD5.AddInt8(0)
        Next
        'For i = 1 To 5
        'SMSG_ACCOUNT_DATA_MD5.AddInt64(0)
        'SMSG_ACCOUNT_DATA_MD5.AddInt64(0)
        'Next i

        Client.Send(SMSG_ACCOUNT_DATA_MD5)
        SMSG_ACCOUNT_DATA_MD5.Dispose()

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_ACCOUNT_DATA_MD5", Client.IP, Client.Port)
    End Sub
#End Region
#Region "WS.Trading"
    Public Class TTradeInfo
        Implements IDisposable

        Public Trader As CharacterObject = Nothing
        Public Target As CharacterObject = Nothing

        Public TraderSlots() As Integer = {-1, -1, -1, -1, -1, -1, -1}
        Public TraderGold As Integer = 0
        Public TraderAccept As Boolean = False

        Public TargetSlots() As Integer = {-1, -1, -1, -1, -1, -1, -1}
        Public TargetGold As Integer = 0
        Public TargetAccept As Boolean = False

        Public Sub New(ByRef Trader_ As CharacterObject, ByRef Target_ As CharacterObject)
            Trader = Trader_
            Target = Target_
            Trader.tradeInfo = Me
            Target.tradeInfo = Me
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Trader.tradeInfo = Nothing
            Target.tradeInfo = Nothing
            Trader = Nothing
            Target = Nothing
        End Sub

        Public Sub SendTradeUpdateToTrader()
            If Trader Is Nothing Then Exit Sub

            Dim packet As New PacketClass(OPCODES.SMSG_TRADE_STATUS_EXTENDED)
            packet.AddInt8(1)               'giving(0x00) or receiving(0x01) 
            packet.AddInt32(7)              '2?
            packet.AddInt32(0)              '2?
            packet.AddInt32(TargetGold)
            packet.AddInt32(0)

            Dim i As Integer
            For i = 0 To 6
                packet.AddInt8(i)
                If TargetSlots(i) > 0 Then
                    Dim mySlot As Byte = TargetSlots(i) And &HFF
                    Dim myBag As Byte = TargetSlots(i) >> 8
                    Dim myItem As ItemObject = Nothing

                    If myBag = 0 Then myItem = Target.Items(mySlot) Else myItem = Target.Items(myBag).Items(mySlot)

                    packet.AddInt32(myItem.ItemEntry)
                    packet.AddInt32(myItem.ItemInfo.Model)
                    packet.AddInt32(myItem.StackCount)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt64(myItem.CreatorGUID)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(myItem.RandomProperties)
                    packet.AddInt32(myItem.ItemInfo.Flags)
                    packet.AddInt32(myItem.ItemInfo.Durability)
                    packet.AddInt32(myItem.Durability)
                Else
                    packet.AddInt32(0)      'ItemID
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_STACK_COUNT
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_ENCHANTMENT
                    packet.AddInt64(0)      'ITEM_FIELD_CREATOR
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT1
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT2
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT3
                    packet.AddInt32(0)      'ITEM_FIELD_RANDOM_PROPERTIES_ID
                    packet.AddInt32(0)      'ITEM_FIELD_FLAGS
                    packet.AddInt32(0)      'ITEM_FIELD_MAXDURABILITY
                    packet.AddInt32(0)      'ITEM_FIELD_DURABILITY
                End If
            Next


            Trader.Client.Send(packet)
            packet.Dispose()
        End Sub
        Public Sub SendTradeUpdateToTarget()
            If Target Is Nothing Then Exit Sub

            Dim packet As New PacketClass(OPCODES.SMSG_TRADE_STATUS_EXTENDED)
            packet.AddInt8(1)
            packet.AddInt32(7)
            packet.AddInt32(0)
            packet.AddInt32(TraderGold)
            packet.AddInt32(0)

            Dim i As Integer
            For i = 0 To 6
                packet.AddInt8(i)
                If TraderSlots(i) > 0 Then
                    Dim mySlot As Byte = TraderSlots(i) And &HFF
                    Dim myBag As Byte = TraderSlots(i) >> 8
                    Dim myItem As ItemObject = Nothing

                    If myBag = 0 Then myItem = Trader.Items(mySlot) Else myItem = Trader.Items(myBag).Items(mySlot)

                    packet.AddInt32(myItem.ItemEntry)
                    packet.AddInt32(myItem.ItemInfo.Model)
                    packet.AddInt32(myItem.StackCount)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt64(myItem.CreatorGUID)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(myItem.RandomProperties)
                    packet.AddInt32(myItem.ItemInfo.Flags)
                    packet.AddInt32(myItem.ItemInfo.Durability)
                    packet.AddInt32(myItem.Durability)
                Else
                    packet.AddInt32(0)      'ItemID
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_STACK_COUNT
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_ENCHANTMENT
                    packet.AddInt64(0)      'ITEM_FIELD_CREATOR
                    packet.AddInt32(0)
                    packet.AddInt32(0)
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT1
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT2
                    packet.AddInt32(0)      'ITEM_FIELD_SOCKET_CONTENT3
                    packet.AddInt32(0)      'ITEM_FIELD_RANDOM_PROPERTIES_ID
                    packet.AddInt32(0)      'ITEM_FIELD_FLAGS
                    packet.AddInt32(0)      'ITEM_FIELD_MAXDURABILITY
                    packet.AddInt32(0)      'ITEM_FIELD_DURABILITY
                End If
            Next


            Target.Client.Send(packet)
            packet.Dispose()
        End Sub
        Public Sub DoTrade(ByRef Who As CharacterObject)

            If Not (TargetAccept AndAlso TraderAccept) Then
                Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
                response.AddInt32(TradeStatus.TRADE_STATUS_COMPLETE)
                If Trader Is Who Then
                    Target.Client.SendMultiplyPackets(response)
                    TraderAccept = True
                Else
                    Trader.Client.SendMultiplyPackets(response)
                    TargetAccept = True
                End If
                response.Dispose()
            End If

            If TargetAccept AndAlso TraderAccept Then DoTrade()
        End Sub

        Private Sub DoTrade()
            Dim TargetReqItems As Byte = 0
            Dim TraderReqItems As Byte = 0

            For i As Byte = 0 To 5
                If TraderSlots(i) > 0 Then TargetReqItems += 1
                If TargetSlots(i) > 0 Then TraderReqItems += 1
            Next


            'DONE: Check free slots
            If Target.ItemFREESLOTS < TargetReqItems Then
                Dim responseUnAccept As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
                responseUnAccept.AddInt32(TradeStatus.TRADE_STATUS_UNACCEPT)
                Target.Client.SendMultiplyPackets(responseUnAccept)
                TraderAccept = False
                Trader.Client.SendMultiplyPackets(responseUnAccept)
                TraderAccept = False
                responseUnAccept.Dispose()

                Dim responseNoSlot As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                responseNoSlot.AddInt8(InventoryChangeFailure.EQUIP_ERR_INVENTORY_FULL)
                responseNoSlot.AddInt64(0)
                responseNoSlot.AddInt64(0)
                responseNoSlot.AddInt8(0)
                Target.Client.Send(responseNoSlot)
                responseNoSlot.Dispose()
                Exit Sub
            End If

            If Trader.ItemFREESLOTS < TraderReqItems Then
                Dim responseUnAccept As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
                responseUnAccept.AddInt32(TradeStatus.TRADE_STATUS_UNACCEPT)
                Target.Client.SendMultiplyPackets(responseUnAccept)
                TraderAccept = False
                Trader.Client.SendMultiplyPackets(responseUnAccept)
                TargetAccept = False
                responseUnAccept.Dispose()

                Dim responseNoSlot As New PacketClass(OPCODES.SMSG_INVENTORY_CHANGE_FAILURE)
                responseNoSlot.AddInt8(InventoryChangeFailure.EQUIP_ERR_INVENTORY_FULL)
                responseNoSlot.AddInt64(0)
                responseNoSlot.AddInt64(0)
                responseNoSlot.AddInt8(0)
                Trader.Client.Send(responseNoSlot)
                responseNoSlot.Dispose()
                Exit Sub
            End If


            'DONE: Trade gold
            If TargetGold > 0 Or TraderGold > 0 Then
                Trader.Copper = Trader.Copper - TraderGold + TargetGold
                Target.Copper = Target.Copper + TraderGold - TargetGold
                Trader.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Trader.Copper)
                Target.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Target.Copper)
            End If

            'TODO: For item set ITEM_FIELD_GIFTCREATOR
            'DONE: Item trading
            If TargetReqItems > 0 Or TraderReqItems > 0 Then
                For i As Byte = 0 To 5
                    If TraderSlots(i) > 0 Then
                        Dim mySlot As Byte = TraderSlots(i) And &HFF
                        Dim myBag As Byte = TraderSlots(i) >> 8
                        Dim myItem As ItemObject = Nothing
                        If myBag = 0 Then myItem = Trader.Items(mySlot) Else myItem = Trader.Items(myBag).Items(mySlot)

                        'DONE: Disable trading of quest items
                        If myItem.ItemInfo.ObjectClass <> ITEM_CLASS.ITEM_CLASS_QUEST Then
                            'DONE: Swap items
                            myItem.OwnerGUID = Target.GUID
                            Trader.ItemREMOVE(mySlot, myBag, False, False)
                            If Target.ItemADD(myItem) Then Trader.ItemADD(myItem)
                        End If
                    End If
                    If TargetSlots(i) > 0 Then
                        Dim mySlot As Byte = TargetSlots(i) And &HFF
                        Dim myBag As Byte = TargetSlots(i) >> 8
                        Dim myItem As ItemObject = Nothing
                        If myBag = 0 Then myItem = Target.Items(mySlot) Else myItem = Target.Items(myBag).Items(mySlot)

                        'DONE: Disable trading of quest items
                        If myItem.ItemInfo.ObjectClass <> ITEM_CLASS.ITEM_CLASS_QUEST Then
                            'DONE: Swap items
                            myItem.OwnerGUID = Trader.GUID
                            Target.ItemREMOVE(mySlot, myBag, False, False)
                            If Not Trader.ItemADD(myItem) Then Target.ItemADD(myItem)
                        End If
                    End If
                Next
            End If


            Trader.SendCharacterUpdate(True)
            Target.SendCharacterUpdate(True)

            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_COMPLETE)
            Target.Client.SendMultiplyPackets(response)
            Trader.Client.SendMultiplyPackets(response)
            response.Dispose()
            Me.Dispose()
        End Sub
    End Class
    Public Enum TradeStatus
        TRADE_TARGET_UNAVIABLE = 0              '"[NAME] is busy"
        TRADE_STATUS_OK = 1                     'BEGIN TRADE
        TRADE_TRADE_WINDOW_OPEN = 2             'OPEN TRADE WINDOW
        TRADE_STATUS_CANCELED = 3               '"Trade canceled"
        TRADE_STATUS_COMPLETE = 4               'TRADE COMPLETE
        TRADE_TARGET_UNAVIABLE2 = 5             '"[NAME] is busy"
        TRADE_TARGET_MISSING = 6                'SOUND: I dont have a target
        TRADE_STATUS_UNACCEPT = 7               'BACK TRADE
        TRADE_COMPLETE = 8                      '"Trade Complete"
        TRADE_UNK2 = 9
        TRADE_TARGET_TOO_FAR = 10               '"Trade target is too far away"
        TRADE_TARGET_DIFF_FACTION = 11          '"Trade is not party of your alliance"
        TRADE_TRADE_WINDOW_CLOSE = 12           'CLOSE TRADE WINDOW
        TRADE_UNK3 = 13
        TRADE_TARGET_IGNORING = 14              '"[NAME] is ignoring you"
        TRADE_STUNNED = 15                      '"You are stunned"
        TRADE_TARGET_STUNNED = 16               '"Target is stunned"
        TRADE_DEAD = 17                         '"You cannot do that when you are dead"
        TRADE_TARGET_DEAD = 18                  '"You cannot trade with dead players"
        TRADE_LOGOUT = 19                       '"You are loging out"
        TRADE_TARGET_LOGOUT = 20                '"The player is loging out"
        TRADE_TRIAL_ACCOUNT = 21                '"Trial accounts cannot perform that action"
    End Enum
    Public Sub On_CMSG_CANCEL_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        If Client Is Nothing Then Exit Sub
        If Client.Character Is Nothing Then Exit Sub

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CANCEL_TRADE", Client.IP, Client.Port)

        If Not Client.Character.tradeInfo Is Nothing Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_STATUS_CANCELED)
            Client.Character.tradeInfo.Target.Client.SendMultiplyPackets(response)
            Client.Character.tradeInfo.Trader.Client.SendMultiplyPackets(response)
            response.Dispose()

            Client.Character.tradeInfo.Dispose()
        End If
    End Sub
    Public Sub On_CMSG_SET_TRADE_GOLD(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim gold As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SET_TRADE_GOLD [gold={2}]", Client.IP, Client.Port, gold)

        If Client.Character.tradeInfo Is Nothing Then Exit Sub
        If Client.Character.tradeInfo.Trader Is Client.Character Then
            Client.Character.tradeInfo.TraderGold = gold
            Client.Character.tradeInfo.SendTradeUpdateToTarget()
        Else
            Client.Character.tradeInfo.TargetGold = gold
            Client.Character.tradeInfo.SendTradeUpdateToTrader()
        End If
    End Sub
    Public Sub On_CMSG_SET_TRADE_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim slot As Byte = packet.GetInt8
        Dim myBag As Byte = packet.GetInt8
        Dim mySlot As Byte = packet.GetInt8
        If myBag = 255 Then myBag = 0
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SET_TRADE_ITEM [slot={2} myBag={3} mySlot={4}]", Client.IP, Client.Port, slot, myBag, mySlot)

        If Client.Character.tradeInfo Is Nothing Then Exit Sub
        If Client.Character.tradeInfo.Trader Is Client.Character Then
            Client.Character.tradeInfo.TraderSlots(slot) = (CType(myBag, Integer) << 8) + mySlot
            Client.Character.tradeInfo.SendTradeUpdateToTarget()
        Else
            Client.Character.tradeInfo.TargetSlots(slot) = (CType(myBag, Integer) << 8) + mySlot
            Client.Character.tradeInfo.SendTradeUpdateToTrader()
        End If
    End Sub
    Public Sub On_CMSG_CLEAR_TRADE_ITEM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim slot As Byte = packet.GetInt8
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CLEAR_TRADE_ITEM [slot={2}]", Client.IP, Client.Port, slot)

        If Client.Character.tradeInfo.Trader Is Client.Character Then
            Client.Character.tradeInfo.TraderSlots(slot) = -1
            Client.Character.tradeInfo.SendTradeUpdateToTarget()
        Else
            Client.Character.tradeInfo.TargetSlots(slot) = -1
            Client.Character.tradeInfo.SendTradeUpdateToTrader()
        End If

    End Sub
    Public Sub On_CMSG_INITIATE_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim targetGUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_INITIATE_TRADE [Trader={2} Target={3}]", Client.IP, Client.Port, Client.Character.GUID, targetGUID)

        If Client.Character.DEAD = True Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_DEAD)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If
        If Not Client.Character.LogoutTimer Is Nothing Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_LOGOUT)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If CHARACTERS.Contains(targetGUID) = False Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_MISSING)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If
        If CHARACTERS(targetGUID).DEAD = True Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_DEAD)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If
        If Not CHARACTERS(targetGUID).LogoutTimer Is Nothing Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_LOGOUT)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If Not Client.Character.tradeInfo Is Nothing Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_UNAVIABLE)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If Not CType(CHARACTERS(targetGUID), CharacterObject).tradeInfo Is Nothing Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_UNAVIABLE2)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If CType(CHARACTERS(targetGUID), CharacterObject).Side <> Client.Character.Side Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_DIFF_FACTION)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If GetDistance(Client.Character, CHARACTERS(targetGUID)) > 30.0F Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TARGET_TOO_FAR)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        If Client.Character.Access < 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TRIAL_ACCOUNT)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If
        If CHARACTERS(targetGUID).Access < 0 Then
            Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
            response.AddInt32(TradeStatus.TRADE_TRIAL_ACCOUNT)
            Client.Send(response)
            response.Dispose()
            Exit Sub
        End If

        Dim tmpTradeInfo As New TTradeInfo(Client.Character, CHARACTERS(targetGUID))
        Dim response_ok As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
        response_ok.AddInt32(TradeStatus.TRADE_STATUS_OK)
        response_ok.AddInt64(Client.Character.GUID)
        Client.Character.tradeInfo.Target.Client.Send(response_ok)
        response_ok.Dispose()
    End Sub

    Public Sub On_CMSG_BEGIN_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BEGIN_TRADE", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
        response.AddInt32(TradeStatus.TRADE_TRADE_WINDOW_OPEN)
        Client.Character.tradeInfo.Trader.Client.SendMultiplyPackets(response)
        Client.Character.tradeInfo.Target.Client.SendMultiplyPackets(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_UNACCEPT_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_UNACCEPT_TRADE", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_TRADE_STATUS)
        response.AddInt32(TradeStatus.TRADE_STATUS_UNACCEPT)
        If Client.Character.tradeInfo.Trader Is Client.Character Then
            Client.Character.tradeInfo.Target.Client.SendMultiplyPackets(response)
            Client.Character.tradeInfo.TraderAccept = False
        Else
            Client.Character.tradeInfo.Trader.Client.SendMultiplyPackets(response)
            Client.Character.tradeInfo.TargetAccept = False
        End If
        response.Dispose()
    End Sub
    Public Sub On_CMSG_ACCEPT_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_ACCEPT_TRADE", Client.IP, Client.Port)
        Client.Character.tradeInfo.DoTrade(Client.Character)
    End Sub

    Public Sub On_CMSG_IGNORE_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_IGNORE_TRADE", Client.IP, Client.Port)
    End Sub
    Public Sub On_CMSG_BUSY_TRADE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BUSY_TRADE", Client.IP, Client.Port)
    End Sub
#End Region
#Region "WS.MiscHandlers"
    Public Sub On_CMSG_UPDATE_ACCOUNT_DATA(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_UPDATE_ACCOUNT_DATA", Client.IP, Client.Port)
        Dim DataID As Integer = packet.GetInt32
        Dim DataLEN As Integer = packet.Length - 6     'May be used and packet.Length
        Dim Data(DataLEN - 1) As Char

        Dim i As Integer
        For i = 0 To DataLEN - 1
            Data(i) = Chr(packet.GetInt8)
        Next

        'Console.WriteLine("DEBUG: MD5Data={0}", CStr(Data))
    End Sub

    Public Function GetChatFlag(ByVal c As CharacterObject) As Byte
        If c.GM Then
            Return 3
        ElseIf c.AFK Then
            Return 1
        ElseIf c.DND Then
            Return 2
        Else
            Return 0
        End If
    End Function
    Public Function BuildChatMessage(ByVal SenderGUID As Long, ByVal Message As String, ByVal msgType As ChatMsg, ByVal msgLanguage As LANGUAGES, Optional ByVal Flag As Byte = 0, Optional ByVal msgChannel As String = "Global") As PacketClass
        Dim packet As New PacketClass(OPCODES.SMSG_MESSAGECHAT)

        packet.AddInt8(msgType)
        packet.AddInt32(msgLanguage)

        Select Case msgType
            Case ChatMsg.CHAT_MSG_SYSTEM
                packet.AddInt64(0)
            Case ChatMsg.CHAT_MSG_EMOTE, ChatMsg.CHAT_MSG_IGNORED, ChatMsg.CHAT_MSG_COMBAT_LOG, ChatMsg.CHAT_MSG_SKILL, ChatMsg.CHAT_MSG_GUILD, ChatMsg.CHAT_MSG_OFFICER, ChatMsg.CHAT_MSG_RAID, ChatMsg.CHAT_MSG_RAID_LEADER, ChatMsg.CHAT_MSG_RAID_WARNING
                packet.AddInt64(SenderGUID)
            Case ChatMsg.CHAT_MSG_CHANNEL
                packet.AddString(msgChannel)
                packet.AddInt64(SenderGUID)
            Case ChatMsg.CHAT_MSG_YELL, ChatMsg.CHAT_MSG_SAY, ChatMsg.CHAT_MSG_PARTY
                packet.AddInt64(SenderGUID)
                packet.AddInt64(SenderGUID)
            Case ChatMsg.CHAT_MSG_WHISPER_INFORM
                packet.AddInt64(SenderGUID)
            Case ChatMsg.CHAT_MSG_WHISPER
                packet.AddInt64(SenderGUID)
            Case ChatMsg.CHAT_MSG_MONSTER_EMOTE, ChatMsg.CHAT_MSG_MONSTER_SAY, ChatMsg.CHAT_MSG_MONSTER_YELL
                Log.WriteLine(LogType.WARNING, "Use Creature.SendChatMessage() for this message type - {0}!", msgType)
            Case Else
                Log.WriteLine(LogType.WARNING, "Unknown chat message type - {0}!", msgType)
        End Select

        packet.AddInt32(System.Text.Encoding.UTF8.GetByteCount(Message) + 1)
        packet.AddString(Message)

        packet.AddInt8(Flag)

        Return packet
    End Function
    Public Sub On_CMSG_MESSAGECHAT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MESSAGECHAT", Client.IP, Client.Port)
        packet.GetInt16()
        'Client.Character.AFK = False
        Dim msgType As Integer = packet.GetInt32()
        Dim msgLanguage As Integer = packet.GetInt32()
        If Client.Character.Spell_Language <> -1 Then msgLanguage = Client.Character.Spell_Language

        Select Case msgType
            Case ChatMsg.CHAT_MSG_SAY
                Dim Message As String = packet.GetString()

                'DONE: Broadcast to others
                Client.Character.SendChatMSG_Near(Client.Character, Message, msgType, msgLanguage, "", True)

                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_MESSAGECHAT [[{2}] {3}]", Client.IP.ToString, Client.Port, Client.Character.Name, Message)
                Exit Select

            Case ChatMsg.CHAT_MSG_CHANNEL
                Dim Channel As String = packet.GetString()
                Dim Message As String = packet.GetString()

                'DONE: Broadcast to all
                If CHAT_CHANNELs.ContainsKey(Channel) Then
                    CType(CHAT_CHANNELs(Channel), ChannelsClass).Say(Message, msgLanguage, Client.Character)
                End If
                Exit Select

            Case ChatMsg.CHAT_MSG_WHISPER
                Dim ToUser As String = UCase(packet.GetString())
                Dim Message As String = packet.GetString()

                'DONE: Handle admin/gm commands
                If ToUser = "WARDEN" AndAlso Client.Character.Access > 0 Then
                    Dim toWarden As PacketClass = BuildChatMessage(WardenGUID, Message, ChatMsg.CHAT_MSG_WHISPER_INFORM, LANGUAGES.LANG_UNIVERSAL)
                    Client.Send(toWarden)
                    toWarden.Dispose()

                    OnCommand(Client, Message)
                    Exit Sub
                End If

                'DONE: Send whisper MSG to receiver
                Dim GUID As Long = 0
                charactersLock_.AcquireReaderLock(Timeout.Infinite)
                For Each Character As DictionaryEntry In CHARACTERS
                    If UCase(Character.Value.Name) = ToUser Then
                        GUID = Character.Value.GUID
                        Exit For
                    End If
                Next
                charactersLock_.ReleaseReaderLock()
                If GUID > 0 Then
                    'DONE: Check if ignoring
                    If CType(CHARACTERS(GUID), CharacterObject).IgnoreList.Contains(Client.Character.GUID) Then
                        'Client.Character.SystemMessage(String.Format("{0} is ignoring you.", ToUser))
                        Client.Character.SendChatMSG(CHARACTERS(GUID), "", ChatMsg.CHAT_MSG_IGNORED, LANGUAGES.LANG_UNIVERSAL)
                    Else
                        'From [gaddas]: Hello
                        CHARACTERS(GUID).SendChatMSG(Client.Character, Message, ChatMsg.CHAT_MSG_WHISPER, msgLanguage)
                        'DONE: Echo whisper back to sender
                        'To [gaddas]: Hello
                        Client.Character.SendChatMSG(CHARACTERS(GUID), Message, ChatMsg.CHAT_MSG_WHISPER_INFORM, msgLanguage)
                    End If
                Else
                    Dim SMSG_CHAT_PLAYER_NOT_FOUND As New PacketClass(OPCODES.SMSG_CHAT_PLAYER_NOT_FOUND)
                    SMSG_CHAT_PLAYER_NOT_FOUND.AddString(ToUser)
                    Client.Send(SMSG_CHAT_PLAYER_NOT_FOUND)
                    SMSG_CHAT_PLAYER_NOT_FOUND.Dispose()

                    'Dim test As New PacketClass(OPCODES.SMSG_MESSAGECHAT)
                    'test.AddInt8(ChatMsg.CHAT_MSG_IGNORED)
                    'test.AddInt32(LANGUAGES.LANG_UNIVERSAL)
                    'test.AddInt64(WardenGUID)
                    'test.AddInt32(1)
                    'test.AddString("")
                    'test.AddInt8(0)
                    'Client.Send(test)
                    'test.Dispose()
                End If
                Exit Select

            Case ChatMsg.CHAT_MSG_YELL
                Dim Message As String = packet.GetString()
                'DONE: Loopback message
                'Client.Character.SendChatMSG(Client.Character, Message, msgType, msgLanguage)

                'DONE: Broadcast to others
                Client.Character.SendChatMSG_Near(Client.Character, Message, msgType, msgLanguage, "", True)
                Exit Select

            Case ChatMsg.CHAT_MSG_EMOTE
                Dim Message As String = packet.GetString()
                'DONE: Loopback message
                'Client.Character.SendChatMSG(Client.Character, Message, msgType, msgLanguage)

                'DONE: Broadcast to others
                Client.Character.SendChatMSG_Near(Client.Character, Message, msgType, msgLanguage, "", True)
                Exit Select

            Case ChatMsg.CHAT_MSG_PARTY
                Dim Message As String = packet.GetString()

                'DONE: Check in group
                If Not Client.Character.IsInGroup Then
                    Client.Character.SendChatMSG(Client.Character, "You are not in group.", ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
                    Exit Select
                End If

                'DONE: Broadcast to party
                Client.Character.Party.SendChatMessage(Client.Character, Message, msgLanguage)
                Exit Select
            Case ChatMsg.CHAT_MSG_RAID
                Dim Message As String = packet.GetString()

                'DONE: Check in raid
                If Not Client.Character.IsInRaid Then
                    Client.Character.SendChatMSG(Client.Character, "You are not in raid.", ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
                    Exit Select
                End If

                'DONE: Broadcast to party
                Client.Character.Party.SendChatMessageRaid(Client.Character, Message, msgLanguage)
                Exit Select
            Case ChatMsg.CHAT_MSG_RAID_LEADER
                Dim Message As String = packet.GetString()

                'DONE: Check in raid
                If Not Client.Character.IsInRaid Then
                    Client.Character.SendChatMSG(Client.Character, "You are not in raid.", ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
                    Exit Select
                End If
                'DONE: Check for raid leader
                If Not Client.Character.IsGroupLeader Then
                    Client.Character.SendChatMSG(Client.Character, "You are not raid leader.", ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
                    Exit Select
                End If

                'DONE: Broadcast to party
                Client.Character.Party.SendChatMessageRaidLeader(Client.Character, Message, msgLanguage)
                Exit Select
            Case ChatMsg.CHAT_MSG_RAID_WARNING
                Dim Message As String = packet.GetString()

                'DONE: Check in raid
                If Not Client.Character.IsInGroup Then
                    Client.Character.SendChatMSG(Client.Character, "You are not in raid.", ChatMsg.CHAT_MSG_SYSTEM, LANGUAGES.LANG_UNIVERSAL)
                    Exit Select
                End If

                'DONE: Broadcast to party
                Client.Character.Party.SendChatMessageRaidWarning(Client.Character, Message, msgLanguage)
                Exit Select

            Case ChatMsg.CHAT_MSG_GUILD
                Dim Message As String = packet.GetString()

                'DONE: Broadcast to party
                BroadcastChatMessageGuild(Client.Character, Message, msgLanguage, Client.Character.GuildID)
                Exit Select

            Case ChatMsg.CHAT_MSG_OFFICER
                Dim Message As String = packet.GetString()

                'DONE: Broadcast to party
                BroadcastChatMessageOfficer(Client.Character, Message, msgLanguage, Client.Character.GuildID)
                Exit Select

            Case ChatMsg.CHAT_MSG_AFK
                'TODO: Broadcast it!
                Dim Message As String = packet.GetString()
                If Message <> "" Then
                    Client.Character.AFK = True
                    'SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_AFK, True)
                Else
                    Client.Character.AFK = False
                    'SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_AFK, False)
                End If
                'Client.Character.SendChatMSG(Client.Character, Message, msgType, msgLanguage)
                Exit Select

            Case ChatMsg.CHAT_MSG_DND
                'TODO: Broadcast it!
                Dim Message As String = packet.GetString()
                If Message <> "" Then
                    Client.Character.DND = True
                    'SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_AFK, True)
                Else
                    Client.Character.DND = False
                    'SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_AFK, False)
                End If
                'Client.Character.SendChatMSG(Client.Character, Message, msgType, msgLanguage)
                Exit Select

            Case Else
                Log.WriteLine(LogType.FAILED, "[{0}:{1}] Unknown chat message [msgType={2}, msgLanguage={3}]", Client.IP, Client.Port, msgType, msgLanguage)
                DumpPacket(packet.Data, Client)
        End Select

    End Sub

    Public Sub On_CMSG_NAME_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64()
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_NAME_QUERY [GUID={2:X}]", Client.IP, Client.Port, GUID)
        Dim SMSG_NAME_QUERY_RESPONSE As New PacketClass(OPCODES.SMSG_NAME_QUERY_RESPONSE)

        'RESERVED For Warden Bot
        If GUID = WardenGUID Then
            SMSG_NAME_QUERY_RESPONSE.AddInt64(GUID)
            SMSG_NAME_QUERY_RESPONSE.AddString(WardenNAME)
            SMSG_NAME_QUERY_RESPONSE.AddInt8(0)
            SMSG_NAME_QUERY_RESPONSE.AddInt32(1)
            SMSG_NAME_QUERY_RESPONSE.AddInt32(1)
            SMSG_NAME_QUERY_RESPONSE.AddInt32(1)
            Client.Send(SMSG_NAME_QUERY_RESPONSE)
            SMSG_NAME_QUERY_RESPONSE.Dispose()
            Exit Sub
        End If

        'Asking for player name
        If GuidIsPlayer(GUID) Then
            If CHARACTERS.Contains(GUID) = True Then
                SMSG_NAME_QUERY_RESPONSE.AddInt64(GUID)
                SMSG_NAME_QUERY_RESPONSE.AddString(CType(CHARACTERS(GUID), CharacterObject).Name)
                SMSG_NAME_QUERY_RESPONSE.AddInt8(0)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(CHARACTERS(GUID), CharacterObject).Race)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(CHARACTERS(GUID), CharacterObject).Gender)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(CHARACTERS(GUID), CharacterObject).Classe)
                Client.Send(SMSG_NAME_QUERY_RESPONSE)
                SMSG_NAME_QUERY_RESPONSE.Dispose()
            Else
                Dim MySQLQuery As New DataTable
                Database.Query(String.Format("SELECT char_name, char_race, char_class, char_gender FROM adb_characters WHERE char_guid = ""{0}"";", GUID), MySQLQuery)

                If MySQLQuery.Rows.Count > 0 Then
                    SMSG_NAME_QUERY_RESPONSE.AddInt64(GUID)
                    SMSG_NAME_QUERY_RESPONSE.AddString(CType(MySQLQuery.Rows(0).Item("char_name"), String))
                    SMSG_NAME_QUERY_RESPONSE.AddInt8(0)
                    SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(MySQLQuery.Rows(0).Item("char_race"), Integer))
                    SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(MySQLQuery.Rows(0).Item("char_gender"), Integer))
                    SMSG_NAME_QUERY_RESPONSE.AddInt32(CType(MySQLQuery.Rows(0).Item("char_class"), Integer))
                    Client.Send(SMSG_NAME_QUERY_RESPONSE)
                    SMSG_NAME_QUERY_RESPONSE.Dispose()
                Else
                    'SMSG_NAME_QUERY_RESPONSE.AddInt64(GUID)
                    'SMSG_NAME_QUERY_RESPONSE.AddString("NAME_NOT_FOUND")
                    'SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                    'SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                    'SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                    Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_NAME_QUERY_RESPONSE [Character GUID={2:X} not found]", Client.IP, Client.Port, GUID)
                End If

                MySQLQuery.Dispose()
            End If
        End If

        'Asking for creature name (only used in quests?)
        If GuidIsCreature(GUID) Then
            If WORLD_CREATUREs.Contains(GUID) Then
                SMSG_NAME_QUERY_RESPONSE.AddInt64(GUID)

                SMSG_NAME_QUERY_RESPONSE.AddString(CType(WORLD_CREATUREs(GUID), CharacterObject).Name)
                SMSG_NAME_QUERY_RESPONSE.AddInt8(0)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                SMSG_NAME_QUERY_RESPONSE.AddInt32(0)
                Client.Send(SMSG_NAME_QUERY_RESPONSE)
                SMSG_NAME_QUERY_RESPONSE.Dispose()
            Else
                Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_NAME_QUERY_RESPONSE [Creature GUID={2:X} not found]", Client.IP, Client.Port, GUID)
            End If
        End If
    End Sub
    Public Sub On_CMSG_QUERY_TIME(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUERY_TIME", Client.IP, Client.Port)
        Dim response As New PacketClass(OPCODES.SMSG_QUERY_TIME_RESPONSE)
        response.AddInt32(GetTimestamp(Now))
        Client.Send(response)
        response.Dispose()
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_QUERY_TIME_RESPONSE", Client.IP, Client.Port)
    End Sub
    Public Sub On_CMSG_WHO(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_WHO", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_WHO)

        packet.GetInt16()
        packet.GetInt32()
        packet.GetInt16()       '100 ?
        packet.GetInt32()
        packet.GetInt64()       'FFFFFFFFFFFFFFFF
        packet.GetInt32()
        Dim searched As String = ""
        If packet.GetInt32() = 1 Then
            searched = packet.GetString()
        End If


        Dim results As New ArrayList
        charactersLock_.AcquireReaderLock(Timeout.Infinite)
        For Each Character As DictionaryEntry In CHARACTERS
            If InStr(Character.Value.Name, searched) > 0 AndAlso (Client.Character.Access > 0 OrElse (Character.Value.Access = 0 AndAlso Character.Value.Side = Client.Character.Side)) Then
                results.Add(Character.Value.GUID)
            End If
        Next
        charactersLock_.ReleaseReaderLock()

        If results.Count > 49 Then
            'DONE: List first 49 characters (like original)
            response.AddInt32(49)
            response.AddInt32(49)
        Else
            'DONE: List all characters
            response.AddInt32(results.Count)
            response.AddInt32(results.Count)
        End If

        Dim counter As Byte = 0
        For Each Guid As Long In results
            counter = counter + 1
            If counter = 50 Then Exit For
            response.AddString(CHARACTERS(Guid).Name)
            response.AddInt8(0)                         'GuildName
            response.AddInt32(CHARACTERS(Guid).Level)
            response.AddInt32(CHARACTERS(Guid).Classe)
            response.AddInt32(CHARACTERS(Guid).Race)
            response.AddInt32(CHARACTERS(Guid).ZoneID)
        Next

        Client.Send(response)
        response.Dispose()
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_WHO", Client.IP, Client.Port)
    End Sub

    Public Sub On_CMSG_TUTORIAL_FLAG(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim Flag As Integer = packet.GetInt32()
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TUTORIAL_FLAG [flag={2}]", Client.IP, Client.Port, Flag)

        Client.Character.TutorialFlags((Flag \ 8)) = Client.Character.TutorialFlags((Flag \ 8)) + (1 << 7 - (Flag Mod 8))
    End Sub
    Public Sub On_CMSG_TUTORIAL_CLEAR(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TUTORIAL_CLEAR", Client.IP, Client.Port)

        Dim i As Integer
        For i = 0 To 31
            Client.Character.TutorialFlags(i) = 255
        Next
    End Sub
    Public Sub On_CMSG_TUTORIAL_RESET(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TUTORIAL_RESET", Client.IP, Client.Port)

        Dim i As Integer
        For i = 0 To 31
            Client.Character.TutorialFlags(i) = 0
        Next
    End Sub
    Public Sub On_CMSG_TOGGLE_HELM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TOGGLE_HELM", Client.IP, Client.Port)

        SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_HIDE_HELM, Not HaveFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_HIDE_HELM))
        'TODO: Save state in database

        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, Client.Character.cPlayerFlags)
        Client.Character.SendCharacterUpdate(True)
    End Sub
    Public Sub On_CMSG_TOGGLE_CLOAK(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TOGGLE_CLOAK", Client.IP, Client.Port)

        SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_HIDE_CLOAK, Not HaveFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_HIDE_CLOAK))
        'TODO: Save state in database

        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, Client.Character.cPlayerFlags)
        Client.Character.SendCharacterUpdate(True)
    End Sub
    Public Sub On_CMSG_MOUNTSPECIAL_ANIM(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MOUNTSPECIAL_ANIM", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_MOUNTSPECIAL_ANIM)
        response.AddPackGUID(Client.Character.GUID)
        Client.Character.SendToNearPlayers(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_EMOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim emoteID As Integer = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_EMOTE [{2}]", Client.IP, Client.Port, emoteID)

        Dim response As New PacketClass(OPCODES.SMSG_EMOTE)
        response.AddInt32(emoteID)
        response.AddInt64(Client.Character.GUID)
        Client.SendMultiplyPackets(response)
        Client.Character.SendToNearPlayers(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_TEXT_EMOTE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        'DONE: Send to near players

        packet.GetInt16()
        Dim TextEmote As Integer = packet.GetInt32
        Dim Unk As Integer = packet.GetInt32
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TEXT_EMOTE [TextEmote={2} Unk={3}]", Client.IP, Client.Port, TextEmote, Unk)

        'DONE: Send Emote animation
        If EmotesText.ContainsKey(TextEmote) Then
            Dim SMSG_EMOTE As New PacketClass(OPCODES.SMSG_EMOTE)
            SMSG_EMOTE.AddInt32(EmotesText(TextEmote))
            SMSG_EMOTE.AddInt64(Client.Character.GUID)
            Client.SendMultiplyPackets(SMSG_EMOTE)
            Client.Character.SendToNearPlayers(SMSG_EMOTE)
            SMSG_EMOTE.Dispose()
        End If

        'DONE: Find Creature/Player with the recv GUID
        Dim secondName As String = ""
        If GUID > 0 Then
            If CHARACTERS.ContainsKey(GUID) Then
                secondName = CHARACTERS(GUID).Name
            ElseIf WORLD_CREATUREs.ContainsKey(GUID) Then
                secondName = WORLD_CREATUREs(GUID).Name
            End If
        End If

        Dim SMSG_TEXT_EMOTE As New PacketClass(OPCODES.SMSG_TEXT_EMOTE)
        SMSG_TEXT_EMOTE.AddInt64(Client.Character.GUID)
        SMSG_TEXT_EMOTE.AddInt32(TextEmote)
        SMSG_TEXT_EMOTE.AddInt32(&HFF)
        SMSG_TEXT_EMOTE.AddInt32(secondName.Length + 1)
        SMSG_TEXT_EMOTE.AddString(secondName)
        Client.SendMultiplyPackets(SMSG_TEXT_EMOTE)
        Client.Character.SendToNearPlayers(SMSG_TEXT_EMOTE)

        SMSG_TEXT_EMOTE.Dispose()

        'TODO: Set stand state and send updates - EMOTE.SIT, EMOTE.STAND, EMOTE.KNEEL, EMOTE.SLEEP
    End Sub

    Public Sub On_MSG_CORPSE_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        If Client.Character.corpseGUID = 0 Then Exit Sub

        'DONE: Send corpse coords
        Dim MSG_CORPSE_QUERY As New PacketClass(OPCODES.MSG_CORPSE_QUERY)
        MSG_CORPSE_QUERY.AddInt8(1)
        MSG_CORPSE_QUERY.AddInt32(Client.Character.corpseMapID)
        MSG_CORPSE_QUERY.AddSingle(Client.Character.corpsePositionX)
        MSG_CORPSE_QUERY.AddSingle(Client.Character.corpsePositionY)
        MSG_CORPSE_QUERY.AddSingle(Client.Character.corpsePositionZ)
        MSG_CORPSE_QUERY.AddInt32(Client.Character.corpseMapID)                '0-Normal 1-Corpse in instance
        Client.Send(MSG_CORPSE_QUERY)
        MSG_CORPSE_QUERY.Dispose()

        'DONE: Send ping on minimap
        Dim MSG_MINIMAP_PING As New PacketClass(OPCODES.MSG_MINIMAP_PING)
        MSG_CORPSE_QUERY.AddInt64(Client.Character.corpseGUID)
        MSG_CORPSE_QUERY.AddSingle(Client.Character.corpsePositionX)
        MSG_CORPSE_QUERY.AddSingle(Client.Character.corpsePositionY)
        Client.Send(MSG_MINIMAP_PING)
        MSG_MINIMAP_PING.Dispose()
    End Sub
    Public Sub On_CMSG_REPOP_REQUEST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_REPOP_REQUEST [GUID={2:X}]", Client.IP, Client.Port, Client.Character.GUID)
        Client.Character.repopTimer.Dispose()
        Client.Character.repopTimer = Nothing
        CharacterRepop(Client)
    End Sub
    Public Sub On_CMSG_RECLAIM_CORPSE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_RECLAIM_CORPSE [GUID={2:X}]", Client.IP, Client.Port, GUID)

        CharacterResurrect(Client.Character)
    End Sub
    Public Sub CharacterRepop(ByRef Client As ClientClass)
        Try
            'DONE: Make really dead
            Client.Character.Mana.Current = 0
            Client.Character.Rage.Current = 0
            Client.Character.Energy.Current = 0
            Client.Character.Life.Current = 1
            Client.Character.DEAD = True
            Client.Character.cUnitFlags = &H8
            Client.Character.cDynamicFlags = 0
            SetFlag(Client.Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_DEAD, True)
            SendCorpseReclaimDelay(Client, Client.Character, 30)

            'DONE: Update to see only dead
            Client.Character.Invisibility = InvisibilityLevel.DEAD
            Client.Character.CanSeeInvisibility = InvisibilityLevel.DEAD
            UpdateCell(Client.Character)

            'DONE: Clear some things like spells, flags and timers
            Client.Character.StopMirrorTimer(MirrorTimer.FATIGUE)
            Client.Character.StopMirrorTimer(MirrorTimer.DROWNING)
            If Not (Client.Character.underWaterTimer Is Nothing) Then
                Client.Character.underWaterTimer.Dispose()
                Client.Character.underWaterTimer = Nothing
            End If

            'DONE: Spawn Corpse
            Dim myCorpse As New CorpseObject(Client.Character)
            myCorpse.Save()
            myCorpse.AddToWorld()

            'DONE: Remove all auras
            For i As Integer = 0 To MAX_AURA_EFFECTs - 1
                If Not Client.Character.ActiveSpells(i) Is Nothing Then Client.Character.RemoveAura(i, Client.Character.ActiveSpells(i).SpellCaster)
            Next



            'TODO: Just cast spells 20585/8326 + 24237
            Client.Character.SetWaterWalk()
            Client.Character.SetMoveUnroot()
            If Client.Character.Race = Races.RACE_NIGHT_ELF Then
                Client.Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, 12.75F)
                Client.Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, 8.85F)
                Client.Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, 10045)
                Client.Character.Model = 10045
            Else
                Client.Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, 10.625F)
                Client.Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, 7.375F)
            End If


            Client.Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, 1)
            Client.Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + Client.Character.ManaType, 0)
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, Client.Character.cPlayerFlags)
            Client.Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Client.Character.cUnitFlags)
            Client.Character.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, Client.Character.cDynamicFlags)


            If Client.Character.Race = Races.RACE_NIGHT_ELF Then
                Client.Character.SetAura(20585, 0, 0)
            Else
                Client.Character.SetAura(8326, 0, 0)
            End If
            Client.Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, &H1000000)       'Set standing so always be standing
            Client.Character.SendCharacterUpdate()


            'DONE: Get closest graveyard
            GoToNearestGraveyard(Client.Character)
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Error on repop: {0}", e.ToString)
        End Try
    End Sub
    Public Sub CharacterResurrect(ByRef Character As CharacterObject)
        'TODO: Characters from level 1-10 are not affected by resurrection sickness.
        'TODO: Characters from level 11-19 will suffer from one minute of sickness for each level they are above 10.
        'TODO: Characters level 20 and up suffer from ten minutes of sickness.

        'DONE: Make really alive
        Character.Mana.Current = 0
        Character.Rage.Current = 0
        Character.Energy.Current = 0
        Character.Life.Current = Character.Life.Maximum / 2
        Character.DEAD = False
        SetFlag(Character.cPlayerFlags, PlayerFlag.PLAYER_FLAG_DEAD, False)

        'DONE: Update to see only alive
        Character.InvisibilityReset()
        UpdateCell(Character)
        Character.SetLandWalk()


        Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, UNIT_NORMAL_RUN_SPEED)
        Character.ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, UNIT_NORMAL_SWIM_SPEED)
        If Character.Race = Races.RACE_NIGHT_ELF Then
            Character.Model = 55 + Character.Gender
            Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, Character.Model)
        End If


        Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, Character.Life.Current)
        Character.SetUpdateFlag(EPlayerFields.PLAYER_FLAGS, Character.cPlayerFlags)
        Character.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Character.cUnitFlags)
        Character.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, Character.cDynamicFlags)


        Character.RemoveAura(0, Character)
        Character.SendCharacterUpdate()


        'DONE: Spawn Bones, Delete Corpse
        If Character.corpseGUID <> 0 Then
            CType(WORLD_GAMEOBJECTs(Character.corpseGUID), CorpseObject).ConvertToBones()
            Character.corpseGUID = 0
            Character.corpseMapID = 0
            Character.corpsePositionX = 0
            Character.corpsePositionY = 0
            Character.corpsePositionZ = 0
        End If
    End Sub

    Public Sub On_CMSG_GMTICKET_GETTICKET(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_GETTICKET", Client.IP, Client.Port)

        Dim SMSG_GMTICKET_GETTICKET As New PacketClass(OPCODES.SMSG_GMTICKET_GETTICKET)
        Dim MySQLResult As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_characters_tickets WHERE char_guid = {0};", Client.Character.GUID), MySQLResult)
        If MySQLResult.Rows.Count > 0 Then
            SMSG_GMTICKET_GETTICKET.AddInt32(6)
            SMSG_GMTICKET_GETTICKET.AddString(MySQLResult.Rows(0).Item("ticket_text"))
            SMSG_GMTICKET_GETTICKET.AddInt8(MySQLResult.Rows(0).Item("ticket_category"))
        Else
            SMSG_GMTICKET_GETTICKET.AddInt32(&HA)
        End If
        Client.Send(SMSG_GMTICKET_GETTICKET)
        SMSG_GMTICKET_GETTICKET.Dispose()

        Dim SMSG_QUERY_TIME_RESPONSE As New PacketClass(OPCODES.SMSG_QUERY_TIME_RESPONSE)
        SMSG_QUERY_TIME_RESPONSE.AddInt32(GetTimestamp(Now))
        Client.Send(SMSG_QUERY_TIME_RESPONSE)
        SMSG_QUERY_TIME_RESPONSE.Dispose()
    End Sub
    Public Sub On_CMSG_GMTICKET_CREATE(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Dim MySQLResult As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_characters_tickets WHERE char_guid = {0};", Client.Character.GUID), MySQLResult)

        '1 - GMTICKET_ALREADY_HAVE
        '2 - GMTICKET_CREATE_OK
        Dim SMSG_GMTICKET_CREATE As New PacketClass(OPCODES.SMSG_GMTICKET_CREATE)
        If MySQLResult.Rows.Count > 0 Then
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_CREATE", Client.IP, Client.Port)
            SMSG_GMTICKET_CREATE.AddInt32(1)
        Else
            packet.GetInt16()
            Dim ticket_category As Integer = packet.GetInt8
            packet.GetInt32()       'Something with time?
            packet.GetInt32()       'Something with time?
            packet.GetInt64()       'Something with time?
            Dim ticket_text As String = packet.GetString
            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_CREATE [category={2}, text={3}]", Client.IP, Client.Port, ticket_category, ticket_text)
            Database.Update(String.Format("INSERT INTO adb_characters_tickets (char_guid, ticket_text, ticket_category) VALUES ({0} , ""{1}"", {2});", Client.Character.GUID, ticket_text.Replace("""", "'"), ticket_category))

            SMSG_GMTICKET_CREATE.AddInt32(2)
        End If
        Client.Send(SMSG_GMTICKET_CREATE)
        SMSG_GMTICKET_CREATE.Dispose()
    End Sub
    Public Sub On_CMSG_GMTICKET_SYSTEMSTATUS(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_SYSTEMSTATUS", Client.IP, Client.Port)

        '1 - GMTICKET_SYSTEMSTATUS_ENABLED
        '2 - GMTICKET_SYSTEMSTATUS_DISABLED
        Dim SMSG_GMTICKET_SYSTEMSTATUS As New PacketClass(OPCODES.SMSG_GMTICKET_SYSTEMSTATUS)
        SMSG_GMTICKET_SYSTEMSTATUS.AddInt32(1)
        Client.Send(SMSG_GMTICKET_SYSTEMSTATUS)
        SMSG_GMTICKET_SYSTEMSTATUS.Dispose()
    End Sub
    Public Sub On_CMSG_GMTICKET_DELETETICKET(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_DELETETICKET", Client.IP, Client.Port)
        Database.Update(String.Format("DELETE FROM adb_characters_tickets WHERE char_guid = {0};", Client.Character.GUID))

        'Dim SMSG_GMTICKET_DELETETICKET As New PacketClass(OPCODES.SMSG_GMTICKET_DELETETICKET)
        'SMSG_GMTICKET_DELETETICKET.AddInt32(1)
        'SMSG_GMTICKET_DELETETICKET.AddInt32(0)
        'Client.Send(SMSG_GMTICKET_DELETETICKET)
        'SMSG_GMTICKET_DELETETICKET.Dispose()

        Dim SMSG_QUERY_TIME_RESPONSE As New PacketClass(OPCODES.SMSG_QUERY_TIME_RESPONSE)
        SMSG_QUERY_TIME_RESPONSE.AddInt32(1)
        Client.Send(SMSG_QUERY_TIME_RESPONSE)
        SMSG_QUERY_TIME_RESPONSE.Dispose()

        Dim SMSG_GMTICKET_GETTICKET As New PacketClass(OPCODES.SMSG_GMTICKET_GETTICKET)
        SMSG_GMTICKET_GETTICKET.AddInt32(1)
        SMSG_GMTICKET_GETTICKET.AddInt32(0)
        Client.Send(SMSG_GMTICKET_GETTICKET)
        SMSG_GMTICKET_GETTICKET.Dispose()
    End Sub
    Public Sub On_CMSG_GMTICKET_UPDATETEXT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        packet.GetInt8()
        Dim ticket_text As String = packet.GetString
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_GMTICKET_UPDATETEXT [text={2}]", Client.IP, Client.Port, ticket_text)
        Database.Update(String.Format("UPDATE adb_characters_tickets SET char_guid={0}, ticket_text=""{1}"";", Client.Character.GUID, ticket_text.Replace("""", "'")))
    End Sub

    Public Sub On_MSG_RANDOM_ROLL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim minRoll As Integer = packet.GetInt32
        Dim maxRoll As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_RANDOM_ROLL [min={2} max={3}]", Client.IP, Client.Port, minRoll, maxRoll)

        Dim response As New PacketClass(OPCODES.MSG_RANDOM_ROLL)
        response.AddInt32(minRoll)
        response.AddInt32(maxRoll)
        response.AddInt32(Rnd.Next(minRoll, maxRoll))
        response.AddInt64(Client.Character.GUID)
        If Client.Character.IsInGroup Then
            Client.Character.Party.Broadcast(response)
        Else
            Client.SendMultiplyPackets(response)
            Client.Character.SendToNearPlayers(response)
        End If
        response.Dispose()
    End Sub

    Public Sub On_CMSG_TOGGLE_PVP(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_TOGGLE_PVP", Client.IP, Client.Port)


    End Sub
    Public Sub On_MSG_INSPECT_HONOR_STATS(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_INSPECT_HONOR_STATS [{2:X}]", Client.IP, Client.Port, GUID)

        Dim response As New PacketClass(OPCODES.MSG_INSPECT_HONOR_STATS)
        response.AddInt64(GUID)

        response.AddInt8(0)  'PLAYER_FIELD_HONOR_BAR                    - Rank, filling bar, PLAYER_BYTES_3, ??
        response.AddInt32(0) 'PLAYER_FIELD_SESSION_KILLS                - Today Honorable and Dishonorable Kills
        response.AddInt32(0) 'PLAYER_FIELD_YESTERDAY_KILLS              - Yesterday Honorable Kills
        response.AddInt32(0) 'PLAYER_FIELD_LAST_WEEK_KILLS              - Last Week Honorable Kills
        response.AddInt32(0) 'PLAYER_FIELD_THIS_WEEK_KILLS              - This Week Honorable kills
        response.AddInt32(0) 'PLAYER_FIELD_LIFETIME_HONORABLE_KILLS     - Lifetime Honorable Kills
        response.AddInt32(0) 'PLAYER_FIELD_LIFETIME_DISHONORABLE_KILLS  - Lifetime Dishonorable Kills
        response.AddInt32(0) 'PLAYER_FIELD_YESTERDAY_CONTRIBUTION       - Yesterday Honor
        response.AddInt32(0) 'PLAYER_FIELD_LAST_WEEK_CONTRIBUTION       - Last Week Honor
        response.AddInt32(0) 'PLAYER_FIELD_THIS_WEEK_CONTRIBUTION       - This Week Honor
        response.AddInt32(0) 'PLAYER_FIELD_LAST_WEEK_RANK               - Last Week Standing
        response.AddInt8(0)  'Highest Rank

        Client.Send(response)
        response.Dispose()

    End Sub


    Enum SiggestionType As Integer
        TYPE_BUG_REPORT = 0
        TYPE_SUGGESTION = 1
    End Enum
    Public Sub On_CMSG_BUG(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Dim Siggestion As SiggestionType = packet.GetInt32
        Dim cLength As Integer = packet.GetInt32
        Dim cString As String = packet.GetString
        Dim tLength As Integer = packet.GetInt32
        Dim tString As String = packet.GetString

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BUG [2]", Client.IP, Client.Port, Siggestion)
        Log.WriteLine(LogType.INFORMATION, "[{0}:{1}] " & cString & vbNewLine & tString)
    End Sub


#End Region

#Region "Unhandled"
    Public Sub On_CMSG_PLAYED_TIME(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PLAYED_TIME", Client.IP, Client.Port)

        Dim response As New PacketClass(OPCODES.SMSG_PLAYED_TIME)
        response.AddInt32(1)
        response.AddInt32(1)
        Client.Send(response)
        response.Dispose()
    End Sub

    Public Sub On_CMSG_INSPECT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_INSPECT [{GUID={2:X}}]", Client.IP, Client.Port, GUID)
    End Sub
    Public Sub On_CMSG_MOVE_FALL_RESET(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MOVE_FALL_RESET", Client.IP, Client.Port)
        DumpPacket(packet.Data)
    End Sub
    Public Sub On_CMSG_BATTLEFIELD_STATUS(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_BATTLEFIELD_STATUS", Client.IP, Client.Port)
    End Sub
    Public Sub On_CMSG_SET_ACTIVE_MOVER(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_SET_ACTIVE_MOVER [GUID={2:X}]", Client.IP, Client.Port, GUID)
    End Sub
    Public Sub On_CMSG_MEETINGSTONE_INFO(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_MEETINGSTONE_INFO", Client.IP, Client.Port)
    End Sub
#End Region

    Public Function SetColor(ByVal Message As String, ByVal Red As Byte, ByVal Green As Byte, ByVal Blue As Byte) As String
        SetColor = "|cFF"
        If Red < 16 Then
            SetColor = SetColor & "0" & Hex(Red)
        Else
            SetColor = SetColor & Hex(Red)
        End If
        If Green < 16 Then
            SetColor = SetColor & "0" & Hex(Green)
        Else
            SetColor = SetColor & Hex(Green)
        End If
        If Blue < 16 Then
            SetColor = SetColor & "0" & Hex(Blue)
        Else
            SetColor = SetColor & Hex(Blue)
        End If
        SetColor = SetColor & Message & "|r"

        'SetColor = String.Format("|cff{0:x}{1:x}{2:x}{3}|r", Red, Green, Blue, Message)
    End Function

End Module
