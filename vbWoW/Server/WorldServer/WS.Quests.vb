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


Public Module WS_Quests
    Const QUEST_OBJECTIVES_COUNT = 3
    Const QUEST_REWARD_CHOICES_COUNT = 5
    Const QUEST_REWARDS_COUNT = 3
    Const QUEST_DEPLINK_COUNT = 9

    Public Const QUEST_SLOTS = 24

    Public Enum QuestgiverStatus
        DIALOG_STATUS_NONE = 0
        DIALOG_STATUS_UNAVAILABLE = 1           '! (White)
        DIALOG_STATUS_CHAT = 2
        DIALOG_STATUS_INCOMPLETE = 3            '? (White)
        DIALOG_STATUS_REWARD_REP = 4            '? (Blue)
        DIALOG_STATUS_AVAILABLE = 5             '! (Gold)
        DIALOG_STATUS_REWARD_NODOT = 6          '? (Gold)
        DIALOG_STATUS_REWARD = 7                '? (Gold) and dot on map
    End Enum
    Public Enum QuestType
        QUEST_TYPE_NONE = 0
        QUEST_TYPE_ELITE = 1
        QUEST_TYPE_LIFE = 21
        QUEST_TYPE_PVP = 41
        QUEST_TYPE_RAID = 62
        QUEST_TYPE_DUNGEON = 81
    End Enum
    Public Enum QuestFlag
        UNK1 = 8
    End Enum

    Public Enum QuestInvalidError
        'SMSG_QUESTGIVER_QUEST_INVALID
        '   uint32 invalidReason

        INVALIDREASON_DONT_HAVE_REQ = 0                     'You don't meet the requirements for that quest
        INVALIDREASON_DONT_HAVE_LEVEL = 1                   'You are not high enough level for that quest.
        INVALIDREASON_DONT_HAVE_RACE = 6                    'That quest is not available to your race
        INVALIDREASON_HAVE_TIMED_QUEST = 12                 'You can only be on one timed quest at a time
        INVALIDREASON_HAVE_QUEST = 13                       'You are already on that quest
        INVALIDREASON_DONT_HAVE_REQ_ITEMS = 19              'You don't have the required items with you. Check storage.
        INVALIDREASON_DONT_HAVE_REQ_MONEY = 21              'You don't have enough money for that quest
    End Enum
    Public Enum QuestFailedReason
        'SMSG_QUESTGIVER_QUEST_FAILED
        '		uint32 questID
        '		uint32 failedReason

        FAILED_INVENTORY_FULL = 4       '0x04: '%s failed: Inventory is full.'
        FAILED_DUPE_ITEM = &H10         '0x10: '%s failed: Duplicate item found.'
        FAILED_INVENTORY_FULL2 = &H31   '0x31: '%s failed: Inventory is full.'
        FAILED_NOREASON = 0       '0x00: '%s failed.'
    End Enum
    Public Enum QuestPartyPushError As Byte
        QUEST_PARTY_MSG_SHARRING_QUEST = 0
        QUEST_PARTY_MSG_CANT_TAKE_QUEST = 1
        QUEST_PARTY_MSG_ACCEPT_QUEST = 2
        QUEST_PARTY_MSG_REFUSE_QUEST = 3
        QUEST_PARTY_MSG_TO_FAR = 4
        QUEST_PARTY_MSG_BUSY = 5
        QUEST_PARTY_MSG_LOG_FULL = 6
        QUEST_PARTY_MSG_HAVE_QUEST = 7
        QUEST_PARTY_MSG_FINISH_QUEST = 8
    End Enum



#Region "Quests.DataTypes"

    'WARNING: These are used only for Quests packets
    Public Class QuestInfo
        Public ID As Integer
        Public NextQuest As Integer = 0
        Public Type As Integer
        Public Zone As Integer
        Public Flags As Integer = 0
        Public Level_Start As Byte = 0
        Public Level_Normal As Byte = 0

        Public Title As String
        Public TextObjectives As String
        Public TextDescription As String
        Public TextIncomplete As String
        Public TextPreComplete As String
        Public TextComplete As String

        Public RequiredRace As Integer
        Public RequiredClass As Integer
        Public RequiredTradeSkill As Integer
        Public RequiredReputation(1) As Integer
        Public RequiredReputation_Faction(1) As Integer

        Public RewardXP As Integer = 0
        Public RewardGold As Integer = 0
        Public RewardSpell As Integer = 0
        Public RewardItems(QUEST_REWARD_CHOICES_COUNT) As Integer
        Public RewardItems_Count(QUEST_REWARD_CHOICES_COUNT) As Integer
        Public RewardStaticItems(QUEST_REWARDS_COUNT) As Integer
        Public RewardStaticItems_Count(QUEST_REWARDS_COUNT) As Integer

        'Kill <x> of <mob_name>
        Public ObjectivesKill(3) As Integer
        Public ObjectivesKill_Count(3) As Integer
        'Gather <x> of <item_name>
        Public ObjectivesItem(3) As Integer
        Public ObjectivesItem_Count(3) As Integer
        'Deliver <item_name>
        Public ObjectivesDeliver As Integer
        Public ObjectivesDeliver_Count As Integer

        Public ObjectivesGold As Integer = 0
        Public ObjectivesText(3) As String

        Public QuestScript As String = ""

        Public NPC_End As Integer = 0

        Public Sub New(ByVal QuestID As Integer)
            ID = QuestID

            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT * FROM adb_quests WHERE id = {0};", QuestID), MySQLQuery)

            If MySQLQuery.Rows.Count = 0 Then Throw New ApplicationException("Quest " & QuestID & " not found in database.")

            NextQuest = MySQLQuery.Rows(0).Item("NextQuest")
            Level_Start = MySQLQuery.Rows(0).Item("Level_Start")
            Level_Normal = MySQLQuery.Rows(0).Item("Level_Normal")
            Type = MySQLQuery.Rows(0).Item("Type")
            Zone = MySQLQuery.Rows(0).Item("Zone")
            Flags = MySQLQuery.Rows(0).Item("Flags")

            NPC_End = MySQLQuery.Rows(0).Item("NPC_End")

            RequiredRace = MySQLQuery.Rows(0).Item("Required_Race")
            RequiredClass = MySQLQuery.Rows(0).Item("Required_Class")
            RequiredTradeSkill = MySQLQuery.Rows(0).Item("Required_TradeSkill")
            RequiredReputation(0) = MySQLQuery.Rows(0).Item("Required_Reputation1")
            RequiredReputation(1) = MySQLQuery.Rows(0).Item("Required_Reputation2")
            RequiredReputation_Faction(0) = MySQLQuery.Rows(0).Item("Required_Reputation1_Faction")
            RequiredReputation_Faction(1) = MySQLQuery.Rows(0).Item("Required_Reputation2_Faction")

            Title = MySQLQuery.Rows(0).Item("Title")
            TextObjectives = MySQLQuery.Rows(0).Item("Text_Objectives")
            TextDescription = MySQLQuery.Rows(0).Item("Text_Description")
            TextIncomplete = MySQLQuery.Rows(0).Item("Text_Incomplete")
            TextPreComplete = MySQLQuery.Rows(0).Item("Text_PreComplete")
            TextComplete = MySQLQuery.Rows(0).Item("Text_Complete")

            RewardXP = MySQLQuery.Rows(0).Item("Reward_XP")
            RewardGold = MySQLQuery.Rows(0).Item("Reward_Gold")
            RewardSpell = MySQLQuery.Rows(0).Item("Reward_Spell")

            RewardItems(0) = MySQLQuery.Rows(0).Item("Reward_Item1")
            RewardItems(1) = MySQLQuery.Rows(0).Item("Reward_Item2")
            RewardItems(2) = MySQLQuery.Rows(0).Item("Reward_Item3")
            RewardItems(3) = MySQLQuery.Rows(0).Item("Reward_Item4")
            RewardItems(4) = MySQLQuery.Rows(0).Item("Reward_Item5")
            RewardItems(5) = MySQLQuery.Rows(0).Item("Reward_Item6")
            RewardItems_Count(0) = MySQLQuery.Rows(0).Item("Reward_Item1_Count")
            RewardItems_Count(1) = MySQLQuery.Rows(0).Item("Reward_Item2_Count")
            RewardItems_Count(2) = MySQLQuery.Rows(0).Item("Reward_Item3_Count")
            RewardItems_Count(3) = MySQLQuery.Rows(0).Item("Reward_Item4_Count")
            RewardItems_Count(4) = MySQLQuery.Rows(0).Item("Reward_Item5_Count")
            RewardItems_Count(5) = MySQLQuery.Rows(0).Item("Reward_Item6_Count")

            RewardStaticItems(0) = MySQLQuery.Rows(0).Item("Reward_StaticItem1")
            RewardStaticItems(1) = MySQLQuery.Rows(0).Item("Reward_StaticItem2")
            RewardStaticItems(2) = MySQLQuery.Rows(0).Item("Reward_StaticItem3")
            RewardStaticItems(3) = MySQLQuery.Rows(0).Item("Reward_StaticItem4")
            RewardStaticItems_Count(0) = MySQLQuery.Rows(0).Item("Reward_StaticItem1_Count")
            RewardStaticItems_Count(1) = MySQLQuery.Rows(0).Item("Reward_StaticItem2_Count")
            RewardStaticItems_Count(2) = MySQLQuery.Rows(0).Item("Reward_StaticItem3_Count")
            RewardStaticItems_Count(3) = MySQLQuery.Rows(0).Item("Reward_StaticItem4_Count")

            ObjectivesKill(0) = MySQLQuery.Rows(0).Item("Objective_Kill1")
            ObjectivesKill(1) = MySQLQuery.Rows(0).Item("Objective_Kill2")
            ObjectivesKill(2) = MySQLQuery.Rows(0).Item("Objective_Kill3")
            ObjectivesKill(3) = MySQLQuery.Rows(0).Item("Objective_Kill4")
            ObjectivesKill_Count(0) = MySQLQuery.Rows(0).Item("Objective_Kill1_Count")
            ObjectivesKill_Count(1) = MySQLQuery.Rows(0).Item("Objective_Kill2_Count")
            ObjectivesKill_Count(2) = MySQLQuery.Rows(0).Item("Objective_Kill3_Count")
            ObjectivesKill_Count(3) = MySQLQuery.Rows(0).Item("Objective_Kill4_Count")

            ObjectivesItem(0) = MySQLQuery.Rows(0).Item("Objective_Item1")
            ObjectivesItem(1) = MySQLQuery.Rows(0).Item("Objective_Item2")
            ObjectivesItem(2) = MySQLQuery.Rows(0).Item("Objective_Item3")
            ObjectivesItem(3) = MySQLQuery.Rows(0).Item("Objective_Item4")
            ObjectivesItem_Count(0) = MySQLQuery.Rows(0).Item("Objective_Item1_Count")
            ObjectivesItem_Count(1) = MySQLQuery.Rows(0).Item("Objective_Item2_Count")
            ObjectivesItem_Count(2) = MySQLQuery.Rows(0).Item("Objective_Item3_Count")
            ObjectivesItem_Count(3) = MySQLQuery.Rows(0).Item("Objective_Item4_Count")

            ObjectivesDeliver = MySQLQuery.Rows(0).Item("Objective_Deliver1")
            ObjectivesDeliver_Count = MySQLQuery.Rows(0).Item("Objective_Deliver1_Count")

            ObjectivesGold = MySQLQuery.Rows(0).Item("Objective_Gold")

            ObjectivesText(0) = MySQLQuery.Rows(0).Item("Objective_Text1")
            ObjectivesText(1) = MySQLQuery.Rows(0).Item("Objective_Text2")
            ObjectivesText(2) = MySQLQuery.Rows(0).Item("Objective_Text3")
            ObjectivesText(3) = MySQLQuery.Rows(0).Item("Objective_Text4")
        End Sub
    End Class



    'WARNING: These are used only for CharManagment
    Public Class BaseQuest
        Public ID As Integer = 0
        Public Title As String = ""
        Public NPC_End As Integer = 0

        Public Slot As Byte = 0

        Public Progress() As Byte = {0, 0, 0, 0}
        Public Complete As Boolean = False
        Public Failed As Boolean = False

        Public Overridable Function IsCompleted() As Boolean
            Return True
        End Function
        Public Overridable Function GetState() As Integer
            'PLAYER_QUEST_LOG_1_2 = 1 << 0  = Quest Kills #1
            'PLAYER_QUEST_LOG_1_2 = 1 << 6  = Quest Kills #2
            'PLAYER_QUEST_LOG_1_2 = 1 << 12 = Quest Kills #3
            'PLAYER_QUEST_LOG_1_2 = 1 << 18 = Quest Kills #4
            'PLAYER_QUEST_LOG_1_2 = 1 << 24 = Quest Complete Flag
            'PLAYER_QUEST_LOG_1_2 = 1 << 25 = Quest Failed Flag
            'PLAYER_QUEST_LOG_1_3 = 1 << 0  = Quest Timer

            Dim tmpProgress As Integer = 0
            tmpProgress += CType(Progress(0), Integer)
            tmpProgress += CType(Progress(1), Integer) << 6
            tmpProgress += CType(Progress(2), Integer) << 12
            tmpProgress += CType(Progress(3), Integer) << 18
            If Complete Then tmpProgress += CType(1, Integer) << 24
            If Failed Then tmpProgress += CType(1, Integer) << 25
            Return tmpProgress
        End Function
        Public Overridable Sub LoadState(ByVal state As Integer)
            Progress(0) = state And &H3F
            Progress(1) = (state >> 6) And &H3F
            Progress(2) = (state >> 12) And &H3F
            Progress(3) = (state >> 18) And &H3F
            Complete = ((state >> 24) = 1)
            Failed = ((state >> 25) = 1)
        End Sub
    End Class
    Public Class BaseQuestScripted
        Inherits BaseQuest
        Public Overridable Sub OnQuestStart(ByRef c As CharacterObject)
        End Sub
        Public Overridable Sub OnQuestComplete(ByRef c As CharacterObject)
        End Sub
        Public Overridable Sub OnQuestCancel(ByRef c As CharacterObject)
        End Sub

        Public Overridable Sub OnQuestItem(ByRef c As CharacterObject, ByVal ItemID As Integer, ByVal ItemCount As Integer)
        End Sub
        Public Overridable Sub OnQuestKill(ByRef c As CharacterObject, ByRef Creature As CreatureObject)
        End Sub
    End Class

    Public Class QuestKill
        Inherits BaseQuest

        Public ObjectivesKill(3) As Integer
        Public ObjectivesKill_Count(3) As Integer

        Public Overrides Function IsCompleted() As Boolean
            Complete = (ObjectivesKill_Count(0) = Progress(0) AndAlso ObjectivesKill_Count(1) = Progress(1) AndAlso ObjectivesKill_Count(2) = Progress(2) AndAlso ObjectivesKill_Count(3) = Progress(3))
            Return Complete
        End Function
        Public Sub New(ByVal Quest As QuestInfo)
            ObjectivesKill(0) = Quest.ObjectivesKill(0)
            ObjectivesKill(1) = Quest.ObjectivesKill(1)
            ObjectivesKill(2) = Quest.ObjectivesKill(2)
            ObjectivesKill(3) = Quest.ObjectivesKill(3)
            ObjectivesKill_Count(0) = Quest.ObjectivesKill_Count(0)
            ObjectivesKill_Count(1) = Quest.ObjectivesKill_Count(1)
            ObjectivesKill_Count(2) = Quest.ObjectivesKill_Count(2)
            ObjectivesKill_Count(3) = Quest.ObjectivesKill_Count(3)

            NPC_End = Quest.NPC_End
            Title = Quest.Title
            ID = Quest.ID
        End Sub

        Public Sub AddKill(ByVal c As CharacterObject, ByVal index As Byte)
            Progress(index) += 1
            IsCompleted()
            c.TalkUpdateQuest(Slot)

            If Complete Then
                SendQuestMessageComplete(c.Client, ID)
            Else
                SendQuestMessageAddKill(c.Client, ID, ObjectivesKill(index), Progress(index), ObjectivesKill_Count(index))
            End If
        End Sub
    End Class
    Public Class QuestItem
        Inherits BaseQuest

        Public ObjectivesItem(3) As Integer
        Public ObjectivesItem_Count(3) As Integer

        Public Overrides Function IsCompleted() As Boolean
            Complete = (ObjectivesItem_Count(0) = Progress(0) AndAlso ObjectivesItem_Count(1) = Progress(1) AndAlso ObjectivesItem_Count(2) = Progress(2) AndAlso ObjectivesItem_Count(3) = Progress(3))
            Return Complete
        End Function
        Public Sub New(ByVal Quest As QuestInfo)
            ObjectivesItem(0) = Quest.ObjectivesItem(0)
            ObjectivesItem(1) = Quest.ObjectivesItem(1)
            ObjectivesItem(2) = Quest.ObjectivesItem(2)
            ObjectivesItem(3) = Quest.ObjectivesItem(3)
            ObjectivesItem_Count(0) = Quest.ObjectivesItem_Count(0)
            ObjectivesItem_Count(1) = Quest.ObjectivesItem_Count(1)
            ObjectivesItem_Count(2) = Quest.ObjectivesItem_Count(2)
            ObjectivesItem_Count(3) = Quest.ObjectivesItem_Count(3)

            NPC_End = Quest.NPC_End
            Title = Quest.Title
            ID = Quest.ID
        End Sub

        Public Sub AddItem(ByVal c As CharacterObject, ByVal index As Byte, ByVal Count As Byte)
            Progress(index) += Count
            IsCompleted()
            c.TalkUpdateQuest(Slot)

            If Complete Then
                SendQuestMessageComplete(c.Client, ID)
            Else
                SendQuestMessageAddItem(c.Client, ObjectivesItem(index), Count - 1)
            End If
        End Sub
        Public Sub RemoveItem(ByVal c As CharacterObject, ByVal index As Byte, ByVal Count As Byte)
            Progress(index) -= Count
            IsCompleted()
            c.TalkUpdateQuest(Slot)

            'No need for this, client knows what is doing
            'If IsCompleted() Then
            '    SendQuestMessageComplete(c.Client, ID)
            'Else
            SendQuestMessageAddItem(c.Client, ID, Progress(index))
            'End If
        End Sub
        Public Sub Initialize(ByRef c As CharacterObject)

            If ObjectivesItem(0) <> 0 Then Progress(0) = c.ItemCOUNT(ObjectivesItem(0))
            If ObjectivesItem(1) <> 0 Then Progress(1) = c.ItemCOUNT(ObjectivesItem(1))
            If ObjectivesItem(2) <> 0 Then Progress(2) = c.ItemCOUNT(ObjectivesItem(2))
            If ObjectivesItem(3) <> 0 Then Progress(3) = c.ItemCOUNT(ObjectivesItem(3))

            IsCompleted()
        End Sub
    End Class
    Public Class QuestDeliver
        Inherits BaseQuest

        Public ObjectivesDeliver As Integer
        Public ObjectivesDeliver_Count As Integer

        Public Overrides Function IsCompleted() As Boolean
            Complete = (ObjectivesDeliver_Count = Progress(0))
            Return Complete
        End Function
        Public Sub New(ByVal Quest As QuestInfo)
            ObjectivesDeliver = Quest.ObjectivesDeliver
            ObjectivesDeliver_Count = Quest.ObjectivesDeliver_Count

            NPC_End = Quest.NPC_End
            Title = Quest.Title
            ID = Quest.ID
        End Sub

        Public Sub Initialize(ByRef c As CharacterObject)
            Dim tmpItem As New ItemObject(ObjectivesDeliver, c.GUID)
            tmpItem.StackCount = ObjectivesDeliver_Count

            If Not c.ItemADD(tmpItem) Then
                'DONE: Some error, unable to add item, quest is uncompletable
                tmpItem.Delete()

                Dim response As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_FAILED)
                response.AddInt32(ID)
                response.AddInt32(QuestFailedReason.FAILED_INVENTORY_FULL)
                c.Client.Send(response)
                response.Dispose()
            Else
                Progress(0) = ObjectivesDeliver_Count
            End If

            IsCompleted()
        End Sub
        Public Sub RemoveItem(ByVal c As CharacterObject, ByVal index As Byte, ByVal Count As Byte)
            Progress(index) -= Count
            IsCompleted()
            c.TalkUpdateQuest(Slot)
        End Sub
    End Class

    Public Class QuestExplore
        Inherits BaseQuest
    End Class
    Public Class QuestEscort
        Inherits BaseQuest
        'SMSG_QUEST_CONFIRM_ACCEPT
        '		uint32 questID
        '		char[0x400] questName
        '		uint64 playerGUID
        'Output: [Confirm Dialog] playerName + 'is starting' + questName + 'Would you like to as well?'
    End Class


#End Region
#Region "Quests.HelpingSubs"


    Public Function GetQuestMenu(ByRef c As CharacterObject, ByVal GUID As Long) As QuestMenu
        Dim QuestMenu As New QuestMenu

        'DONE: Avaible quests
        Dim MySQLQuery As New DataTable

        'NOTE: This is query without checking requirements
        'MySQL.Query(String.Format("SELECT * FROM adb_quests q WHERE q.NPC_Start = {0} AND q.Level_Start < {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id);", _
        'WORLD_CREATUREs(GUID).ID, c.Level + 1, c.GUID), MySQLQuery)

        'NOTE: This is more complex query with checking requirements (may do some slowdowns)
        Database.Query(String.Format("SELECT * FROM adb_quests q WHERE q.NPC_Start = {0} AND q.Level_Start <= {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id) " & _
        "AND (q.Required_Quest = 0 OR EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_status = -1 AND quest_id = q.Required_Quest));", _
        WORLD_CREATUREs(GUID).ID, c.Level + 1, c.GUID), MySQLQuery)

        For Each Row As DataRow In MySQLQuery.Rows
            If Not Row.Item("Level_Start") > c.Level Then
                QuestMenu.AddMenu(Row.Item("Title"), Row.Item("id"), 0, QuestgiverStatus.DIALOG_STATUS_AVAILABLE)
            End If
        Next

        'DONE: Quests for completing
        Dim i As Integer
        For i = 0 To QUEST_SLOTS
            If Not c.TalkQuests(i) Is Nothing Then
                'If c.TalkQuests(i).Complete And (c.TalkQuests(i).NPC_End = CType(WORLD_CREATUREs(GUID), CreatureObject).ID) Then
                If c.TalkQuests(i).NPC_End = CType(WORLD_CREATUREs(GUID), CreatureObject).ID Then
                    QuestMenu.AddMenu(c.TalkQuests(i).Title, c.TalkQuests(i).ID, 0, QuestgiverStatus.DIALOG_STATUS_INCOMPLETE)
                End If
            End If
        Next

        Return QuestMenu
    End Function
    Public Function GetQuestMenuGO(ByRef c As CharacterObject, ByVal GUID As Long) As QuestMenu
        Dim QuestMenu As New QuestMenu

        'DONE: Avaible quests
        Dim MySQLQuery As New DataTable

        Database.Query(String.Format("SELECT * FROM adb_quests q WHERE q.NPC_Start = -{0} AND q.Level_Start <= {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id) " & _
        "AND (q.Required_Quest = 0 OR EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_status = -1 AND quest_id = q.Required_Quest));", _
        WORLD_GAMEOBJECTs(GUID).ID, c.Level + 1, c.GUID), MySQLQuery)

        For Each Row As DataRow In MySQLQuery.Rows
            If Not Row.Item("Level_Start") > c.Level Then
                QuestMenu.AddMenu(Row.Item("Title"), Row.Item("id"), 0, QuestgiverStatus.DIALOG_STATUS_AVAILABLE)
            End If
        Next

        'DONE: Quests for completing
        Dim i As Integer
        For i = 0 To QUEST_SLOTS
            If Not c.TalkQuests(i) Is Nothing Then
                'If c.TalkQuests(i).Complete And (c.TalkQuests(i).NPC_End = CType(WORLD_CREATUREs(GUID), CreatureObject).ID) Then
                If c.TalkQuests(i).NPC_End = -CType(WORLD_CREATUREs(GUID), CreatureObject).ID Then
                    QuestMenu.AddMenu(c.TalkQuests(i).Title, c.TalkQuests(i).ID, 0, QuestgiverStatus.DIALOG_STATUS_INCOMPLETE)
                End If
            End If
        Next

        Return QuestMenu
    End Function
    Public Sub SendQuestMenu(ByRef c As CharacterObject, ByVal GUID As Long, Optional ByVal Title As String = "Available quests", Optional ByVal QuestMenu As QuestMenu = Nothing)
        If QuestMenu Is Nothing Then
            QuestMenu = GetQuestMenu(c, GUID)
        End If

        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_LIST)
        packet.AddInt64(GUID)
        packet.AddString(Title)
        packet.AddInt32(0)              'Delay
        packet.AddInt32(0)              'Emote
        packet.AddInt8(QuestMenu.IDs.Count) 'Count
        Dim i As Integer = 0
        For i = 0 To QuestMenu.IDs.Count - 1
            packet.AddInt32(QuestMenu.IDs(i))
            packet.AddInt32(QuestMenu.Icons(i))
            packet.AddInt32(QuestMenu.Availables(i))                              'padding?
            packet.AddString(QuestMenu.Names(i))
        Next
        c.Client.Send(packet)
        packet.Dispose()
    End Sub

    Public Sub SendQuestDetails(ByRef client As ClientClass, ByRef Quest As QuestInfo, ByVal GUID As Long, ByVal AcceptActive As Boolean)
        Dim i As Integer
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_DETAILS)
        packet.AddInt64(GUID)

        'QuestDetails
        packet.AddInt32(Quest.ID)
        packet.AddString(Quest.Title)
        packet.AddString(Quest.TextDescription)
        packet.AddString(Quest.TextObjectives)
        packet.AddInt32(AcceptActive)
        packet.AddInt32(0)                                          'Suggested Players Count

        'QuestRewards (Choosable)
        Dim questRewardsCount As Integer = 0
        For i = 0 To QUEST_REWARD_CHOICES_COUNT
            If Quest.RewardItems(i) <> 0 Then questRewardsCount += 1
        Next
        packet.AddInt32(questRewardsCount)
        For i = 0 To QUEST_REWARD_CHOICES_COUNT
            If Quest.RewardItems(i) <> 0 Then
                'Add item if not loaded into server
                If Not ITEMDatabase.ContainsKey(Quest.RewardItems(i)) Then Dim tmpItem As New ItemInfo(Quest.RewardItems(i))
                packet.AddInt32(Quest.RewardItems(i))
                packet.AddInt32(Quest.RewardItems_Count(i))
                packet.AddInt32(ITEMDatabase(Quest.RewardItems(i)).Model)
            End If
        Next

        'QuestRewards (Static)
        questRewardsCount = 0
        For i = 0 To QUEST_REWARDS_COUNT
            If Quest.RewardStaticItems(i) <> 0 Then questRewardsCount += 1
        Next
        packet.AddInt32(questRewardsCount)
        For i = 0 To QUEST_REWARDS_COUNT
            If Quest.RewardStaticItems(i) <> 0 Then
                'Add item if not loaded into server
                If Not ITEMDatabase.ContainsKey(Quest.RewardStaticItems(i)) Then Dim tmpItem As New ItemInfo(Quest.RewardStaticItems(i))
                packet.AddInt32(Quest.RewardStaticItems(i))
                packet.AddInt32(Quest.RewardStaticItems_Count(i))
                packet.AddInt32(ITEMDatabase(Quest.RewardStaticItems(i)).Model)
            End If
        Next

        packet.AddInt32(Quest.RewardGold)
        packet.AddInt32(Quest.RewardSpell)

        'Emotes List
        packet.AddInt32(0)              'EmoteCount
        'packet.AddInt32(0)              'Emote
        'packet.AddInt32(0)              'Delay (ms)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt32(0)
        packet.AddInt32(0)


        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_QUESTGIVER_QUEST_DETAILS [GUID={2:X} Quest={3}]", client.IP, client.Port, GUID, Quest.ID)

        'Finishing
        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuest(ByRef client As ClientClass, ByRef Quest As QuestInfo)
        Dim packet As New PacketClass(OPCODES.SMSG_QUEST_QUERY_RESPONSE)
        packet.AddInt32(Quest.ID)

        'Basic Details
        packet.AddInt32(0)
        packet.AddInt32(Quest.Level_Start)
        packet.AddInt32(Quest.Level_Normal)
        packet.AddInt32(Quest.Zone)
        packet.AddInt32(Quest.Type)
        packet.AddInt32(Quest.RequiredReputation(0))
        packet.AddInt32(Quest.RequiredReputation_Faction(0))
        packet.AddInt32(Quest.RequiredReputation(1))
        packet.AddInt32(Quest.RequiredReputation_Faction(1))
        packet.AddInt32(Quest.NextQuest)
        packet.AddInt32(Quest.RewardGold)
        packet.AddInt32(Quest.RewardGold)   'unk
        packet.AddInt32(Quest.RewardSpell)
        packet.AddInt32(0)                  'RewardSpellCasted
        packet.AddInt32(0)                  'sourceItem
        packet.AddInt32(Quest.Flags)

        Dim i As Integer
        For i = 0 To QUEST_REWARDS_COUNT
            packet.AddInt32(Quest.RewardStaticItems(i))
            packet.AddInt32(Quest.RewardStaticItems_Count(i))
        Next
        For i = 0 To QUEST_REWARD_CHOICES_COUNT
            packet.AddInt32(Quest.RewardItems(i))
            packet.AddInt32(Quest.RewardItems_Count(i))
        Next

        'Some Coords?
        packet.AddInt32(&HFF)   'mapID
        packet.AddSingle(0)     'posX
        packet.AddSingle(0)     'posY
        packet.AddInt32(0)      'unk

        'Texts
        packet.AddString(Quest.Title)
        packet.AddString(Quest.TextObjectives)
        packet.AddString(Quest.TextDescription)
        packet.AddString("")    'Quest.TextDescription2

        'Objectives
        For i = 0 To QUEST_OBJECTIVES_COUNT
            packet.AddInt32(Quest.ObjectivesKill(i))
            packet.AddInt32(Quest.ObjectivesKill_Count(i))
            packet.AddInt32(Quest.ObjectivesItem(i))
            packet.AddInt32(Quest.ObjectivesItem_Count(i))

            'HACK: Fix for not showing "Unknown Item" (sometimes client doesn't get items on time)
            If Quest.ObjectivesItem(i) <> 0 Then SendItemInfo(client, Quest.ObjectivesItem(i))
        Next
        For i = 0 To QUEST_OBJECTIVES_COUNT
            packet.AddString(Quest.ObjectivesText(i))
        Next


        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] SMSG_QUEST_QUERY_RESPONSE [Quest={2}]", client.IP, client.Port, Quest.ID)

        'Finishing
        client.Send(packet)
        packet.Dispose()
    End Sub

    Public Sub SendQuestMessageAddItem(ByRef client As ClientClass, ByVal itemID As Integer, ByVal itemCount As Integer)
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTUPDATE_ADD_ITEM)
        packet.AddInt32(itemID)
        packet.AddInt32(itemCount)
        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestMessageAddKill(ByRef client As ClientClass, ByVal questID As Integer, ByVal killID As Integer, ByVal killCurrentCount As Integer, ByVal killCount As Integer)
        'Message: %s slain: %d/%d
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTUPDATE_ADD_KILL)
        packet.AddInt32(questID)
        packet.AddInt32(killID)
        packet.AddInt32(killCurrentCount)
        packet.AddInt32(killCount)
        packet.AddInt64(0)
        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestMessageFailed(ByRef client As ClientClass, ByVal QuestID As Integer)
        'Message: ?
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_FAILED)
        packet.AddInt32(QuestID)
        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestMessageFailedTimer(ByRef client As ClientClass, ByVal QuestID As Integer)
        'Message: ?
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTUPDATE_FAILEDTIMER)
        packet.AddInt32(QuestID)
        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestMessageComplete(ByRef client As ClientClass, ByVal QuestID As Integer)
        'Message: Objective Complete.
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTUPDATE_COMPLETE)
        packet.AddInt32(QuestID)
        client.Send(packet)
        packet.Dispose()
    End Sub

    Public Sub SendQuestComplete(ByRef client As ClientClass, ByRef Quest As QuestInfo, ByVal XP As Integer, ByVal Gold As Integer)
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_COMPLETE)

        packet.AddInt32(Quest.ID)
        packet.AddInt32(3)
        'If client.Character.Level >= MAX_LEVEL Then
        '    packet.AddInt32(0)
        '    packet.AddInt32(Quest.RewardXP + Quest.RewardGold)
        'Else
        '    packet.AddInt32(Quest.RewardXP)
        '    packet.AddInt32(Quest.RewardGold)
        'End If
        packet.AddInt32(XP)
        packet.AddInt32(Gold)

        Dim i As Integer
        packet.AddInt32(QUEST_REWARDS_COUNT + 1)
        For i = 0 To QUEST_REWARDS_COUNT
            packet.AddInt32(Quest.RewardStaticItems(i))
            packet.AddInt32(Quest.RewardStaticItems_Count(i))
        Next

        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestReward(ByRef client As ClientClass, ByRef Quest As QuestInfo, ByVal GUID As Long, ByRef q As BaseQuest)
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_OFFER_REWARD)

        packet.AddInt64(GUID)
        packet.AddInt32(q.ID)
        packet.AddString(q.Title)
        If Quest.TextComplete <> "" Then
            packet.AddString(Quest.TextComplete)
        Else
            'INFO: Why someone will not put completion text?
            packet.AddString(Quest.TextDescription)
        End If

        packet.AddInt32(CType(q.Complete, Integer))     'EnbleNext

        packet.AddInt32(0)
        packet.AddInt32(0)          'EmotesCount
        'packet.AddInt32(0)          'EmoteDelay
        'packet.AddInt32(0)          'EmoteID

        Dim i As Integer

        packet.AddInt32(QUEST_REWARD_CHOICES_COUNT + 1)
        For i = 0 To QUEST_REWARD_CHOICES_COUNT
            packet.AddInt32(Quest.RewardItems(i))
            packet.AddInt32(Quest.RewardItems_Count(i))

            'Add item if not loaded into server
            If Quest.RewardItems(i) = 0 Then
                packet.AddInt32(0)
            Else
                If Not ITEMDatabase.ContainsKey(Quest.RewardItems(i)) Then Dim tmpItem As New ItemInfo(Quest.RewardItems(i))
                packet.AddInt32(ITEMDatabase(Quest.RewardItems(i)).Model)
            End If
        Next

        packet.AddInt32(QUEST_REWARDS_COUNT + 1)
        For i = 0 To QUEST_REWARDS_COUNT
            packet.AddInt32(Quest.RewardStaticItems(i))
            packet.AddInt32(Quest.RewardStaticItems_Count(i))

            'Add item if not loaded into server
            If Quest.RewardStaticItems(i) = 0 Then
                packet.AddInt32(0)
            Else
                If Not ITEMDatabase.ContainsKey(Quest.RewardStaticItems(i)) Then Dim tmpItem As New ItemInfo(Quest.RewardStaticItems(i))
                packet.AddInt32(ITEMDatabase(Quest.RewardStaticItems(i)).Model)
            End If

        Next

        packet.AddInt32(Quest.RewardGold)
        packet.AddInt32(Quest.RewardXP)
        packet.AddInt32(Quest.RewardSpell)

        client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendQuestRequireItems(ByRef client As ClientClass, ByRef Quest As QuestInfo, ByVal GUID As Long, ByRef q As BaseQuest)
        Dim packet As New PacketClass(OPCODES.SMSG_QUESTGIVER_REQUEST_ITEMS)

        packet.AddInt64(GUID)
        packet.AddInt32(q.ID)
        packet.AddString(q.Title)

        If q.Complete Then
            If Quest.TextPreComplete <> "" Then
                packet.AddString(Quest.TextPreComplete)
            Else
                packet.AddString(Quest.TextDescription)
            End If

        Else
            If Quest.TextIncomplete <> "" Then
                packet.AddString(Quest.TextIncomplete)
            Else
                packet.AddString(Quest.TextDescription)
            End If
        End If


        packet.AddInt32(0)      'EmoteDelay
        packet.AddInt32(1)      'EmoteID


        'Close Window after cancel?
        packet.AddInt32(0)

        'Req Gold
        packet.AddInt32(Quest.ObjectivesGold)


        If TypeOf q Is QuestDeliver Then
            'DONE: Put required deliver items
            packet.AddInt32(1)
            packet.AddInt32(Quest.ObjectivesDeliver)
            packet.AddInt32(Quest.ObjectivesDeliver_Count)
            If ITEMDatabase.ContainsKey(Quest.ObjectivesDeliver) Then
                packet.AddInt32(ITEMDatabase(Quest.ObjectivesDeliver).Model)
            Else
                packet.AddInt32(0)
            End If
        ElseIf TypeOf q Is QuestItem Then
            'DONE: Count the required items
            Dim i As Integer = 0
            Dim requiredItemsCount As Byte = 0
            For i = 0 To QUEST_OBJECTIVES_COUNT
                If Quest.ObjectivesItem(i) <> 0 Then
                    requiredItemsCount = i
                    Exit For
                End If
            Next
            packet.AddInt32(requiredItemsCount + 1)

            'DONE: List items
            For i = 0 To requiredItemsCount
                packet.AddInt32(Quest.ObjectivesItem(i))
                packet.AddInt32(Quest.ObjectivesItem_Count(i))
                If ITEMDatabase.ContainsKey(Quest.ObjectivesItem(i)) Then
                    packet.AddInt32(ITEMDatabase(Quest.ObjectivesItem(i)).Model)
                Else
                    packet.AddInt32(0)
                End If
            Next i
        Else
            'DONE: No required items
            packet.AddInt32(0)
        End If



        If q.Complete Then
            packet.AddInt32(2)
            packet.AddInt32(4)
            packet.AddInt32(8)
            packet.AddInt32(10)
        Else
            packet.AddInt32(0)
            packet.AddInt32(0)
            packet.AddInt32(0)
            packet.AddInt32(0)
        End If

        client.Send(packet)
        packet.Dispose()
    End Sub


    Public Sub LoadQuests(ByRef c As CharacterObject)
        Dim cQuests As New DataTable
        Database.Query(String.Format("SELECT * FROM adb_characters_quests q WHERE q.char_guid = {0} AND q.quest_status > -1 LIMIT 20;", c.GUID), cQuests)

        Dim i As Integer = 0
        For Each cRow As DataRow In cQuests.Rows
            Dim tmpQuest As New QuestInfo(cRow.Item("quest_id"))

            'DONE: Initialize quest info
            CreateQuest(c.TalkQuests(i), tmpQuest)

            c.TalkQuests(i).LoadState(cRow.Item("quest_status"))
            c.TalkQuests(i).Slot = i

            i += 1
        Next

    End Sub
    Public Sub CreateQuest(ByRef q As BaseQuest, ByRef tmpQuest As QuestInfo)
        If tmpQuest.ObjectivesKill(0) <> 0 Then
            q = New QuestKill(tmpQuest)
        ElseIf tmpQuest.ObjectivesDeliver <> 0 Then
            q = New QuestDeliver(tmpQuest)
        ElseIf tmpQuest.ObjectivesItem(0) <> 0 Then
            q = New QuestItem(tmpQuest)
        ElseIf tmpQuest.QuestScript <> "" Then
            Dim tmpScript As New ScriptedObject("scripts\quests\" & Replace(tmpQuest.QuestScript, """", "'") & ".vb", "", True)
            q = tmpScript.Invoke("QuestScript")
            tmpScript.Dispose()
        Else
            'Initialize Talk Quest
            q = New BaseQuest
            q.NPC_End = tmpQuest.NPC_End
            q.Title = tmpQuest.Title
            q.ID = tmpQuest.ID
            q.Complete = True
        End If
    End Sub

#End Region
#Region "Quests.Events"


    'DONE: Kill quest events
    Public Sub OnQuestKill(ByRef c As CharacterObject, ByRef Creature As CreatureObject)
        'HANDLERS: Added to DealDamage sub

        'DONE: Do not count killed from guards
        If c Is Nothing Then Exit Sub
        Dim i As Integer

        'DONE: Count kills
        For i = 0 To QUEST_SLOTS
            If TypeOf c.TalkQuests(i) Is QuestKill Then

                With CType(c.TalkQuests(i), QuestKill)
                    Select Case Creature.ID
                        Case .ObjectivesKill(0)
                            If .Progress(0) < .ObjectivesKill_Count(0) Then .AddKill(c, 0)
                        Case .ObjectivesKill(1)
                            If .Progress(1) < .ObjectivesKill_Count(1) Then .AddKill(c, 1)
                        Case .ObjectivesKill(2)
                            If .Progress(2) < .ObjectivesKill_Count(2) Then .AddKill(c, 2)
                        Case .ObjectivesKill(3)
                            If .Progress(3) < .ObjectivesKill_Count(3) Then .AddKill(c, 3)
                    End Select
                End With

            ElseIf TypeOf c.TalkQuests(i) Is BaseQuestScripted Then
                CType(c.TalkQuests(i), BaseQuestScripted).OnQuestKill(c, Creature)
            End If
        Next i


        Exit Sub  'For now next is disabled

        'DONE: Check all in c's party for that quest
        For Each ch As CharacterObject In c.Party.GroupMembers
            If Not ch Is c Then
                For i = 0 To QUEST_SLOTS
                    If TypeOf ch.TalkQuests(i) Is QuestKill Then

                        With CType(ch.TalkQuests(i), QuestKill)
                            Select Case Creature.ID
                                Case .ObjectivesKill(0)
                                    .AddKill(c, 0)
                                Case .ObjectivesKill(1)
                                    .AddKill(c, 1)
                                Case .ObjectivesKill(2)
                                    .AddKill(c, 2)
                                Case .ObjectivesKill(3)
                                    .AddKill(c, 3)
                            End Select
                        End With

                    End If
                Next i
            End If
        Next
    End Sub

    'DONE: Quest's loot generation
    Public Sub OnQuestAddQuestLoot(ByRef c As CharacterObject, ByRef Creature As CreatureObject, ByRef Loot As LootObject)
        'HANDLERS: Added in loot generation sub

        'TODO: Check for quest loots for adding to looted creature
    End Sub
    Public Sub OnQuestAddQuestLoot(ByRef c As CharacterObject, ByRef GameObject As GameObjectObject, ByRef Loot As LootObject)
        'HANDLERS: None
        'TODO: Check for quest loots for adding to looted gameObject
    End Sub
    Public Sub OnQuestAddQuestLoot(ByRef c As CharacterObject, ByRef Character As CharacterObject, ByRef Loot As LootObject)
        'HANDLERS: None
        'TODO: Check for quest loots for adding to looted player (used only in battleground?)
    End Sub

    'DONE: Item quest events
    Public Sub OnQuestItemAdd(ByRef c As CharacterObject, ByVal ItemID As Integer, ByVal Count As Byte)
        'HANDLERS: Added to looting sub

        If Count = 0 Then Count = 1
        Dim i As Integer


        'DONE: Check quests needing that item
        For i = 0 To QUEST_SLOTS
            If TypeOf c.TalkQuests(i) Is QuestItem Then

                With CType(c.TalkQuests(i), QuestItem)
                    Select Case ItemID
                        Case .ObjectivesItem(0)
                            If .Progress(0) < .ObjectivesItem_Count(0) Then .AddItem(c, 0, Count)
                        Case .ObjectivesItem(1)
                            If .Progress(1) < .ObjectivesItem_Count(1) Then .AddItem(c, 1, Count)
                        Case .ObjectivesItem(2)
                            If .Progress(2) < .ObjectivesItem_Count(2) Then .AddItem(c, 2, Count)
                        Case .ObjectivesItem(3)
                            If .Progress(3) < .ObjectivesItem_Count(3) Then .AddItem(c, 3, Count)
                    End Select
                End With

            ElseIf TypeOf c.TalkQuests(i) Is BaseQuestScripted Then
                CType(c.TalkQuests(i), BaseQuestScripted).OnQuestItem(c, ItemID, Count)
            End If
        Next i
    End Sub
    Public Sub OnQuestItemRemove(ByRef c As CharacterObject, ByVal ItemID As Integer, ByVal Count As Byte)
        'HANDLERS: Added to delete sub

        If Count = 0 Then Count = 1
        Dim i As Integer


        'DONE: Check quests needing that item
        For i = 0 To QUEST_SLOTS
            If TypeOf c.TalkQuests(i) Is QuestItem Then

                With CType(c.TalkQuests(i), QuestItem)
                    Select Case ItemID
                        Case .ObjectivesItem(0)
                            If .Progress(0) > 0 Then .RemoveItem(c, 0, Count)
                        Case .ObjectivesItem(1)
                            If .Progress(1) > 0 Then .RemoveItem(c, 1, Count)
                        Case .ObjectivesItem(2)
                            If .Progress(2) > 0 Then .RemoveItem(c, 2, Count)
                        Case .ObjectivesItem(3)
                            If .Progress(3) > 0 Then .RemoveItem(c, 3, Count)
                    End Select
                End With

            ElseIf TypeOf c.TalkQuests(i) Is BaseQuestScripted Then
                CType(c.TalkQuests(i), BaseQuestScripted).OnQuestItem(c, ItemID, -Count)
            End If
        Next i
    End Sub

    'DONE: Exploration quest events
    Public Sub OnQuestExplore(ByRef c As CharacterObject, ByVal AreaID As Integer)

    End Sub


#End Region
#Region "Quests.OpcodeHandlers"


    Public Function GetQuestgiverStatus(ByVal c As CharacterObject, ByVal cGUID As Long) As QuestgiverStatus
        'DONE: Invoke scripted quest status
        Dim Status As QuestgiverStatus = CType(CREATURESDatabase(CType(WORLD_CREATUREs(cGUID), CreatureObject).ID), CreatureInfo).TalkScript.OnQuestStatus(c, cGUID)

        'DONE: Do search for comleted quests or in progress
        Dim i As Integer
        For i = 0 To QUEST_SLOTS
            If Not c.TalkQuests(i) Is Nothing Then
                If c.TalkQuests(i).NPC_End = CType(WORLD_CREATUREs(cGUID), CreatureObject).ID Then
                    If c.TalkQuests(i).Complete Then Status = QuestgiverStatus.DIALOG_STATUS_REWARD Else Status = QuestgiverStatus.DIALOG_STATUS_INCOMPLETE
                    Exit For
                End If
            End If
        Next

        'DONE: Queries are last for performance
        If Status = -1 Then
            'DONE: Do SQL query for available quests
            Dim MySQLQuery As New DataTable

            'NOTE: This is query without checking requirements
            'MySQL.Query(String.Format("SELECT q.id FROM adb_quests q WHERE q.NPC_Start = {0} AND q.Level_Start < {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id) LIMIT 1;", _
            'WORLD_CREATUREs(GUID).ID, Client.Character.Level + 1, Client.Character.GUID), MySQLQuery)

            'NOTE: This is more complex query with checking requirements (may do some slowdowns)
            Database.Query(String.Format("SELECT * FROM adb_quests q WHERE q.NPC_Start = {0} AND q.Level_Start <= {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id) " & _
            "AND (q.Required_Quest = 0 OR EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_status = -1 AND quest_id = q.Required_Quest))  LIMIT 1;", _
            WORLD_CREATUREs(cGUID).ID, c.Level + 1, c.GUID), MySQLQuery)



            If MySQLQuery.Rows.Count = 0 Then
                'DONE: Do SQL query for gray quests
                Dim MySQLQueryForGray As New DataTable
                Database.Query(String.Format("SELECT q.id FROM adb_quests q WHERE q.NPC_Start = {0} AND q.Level_Start < {1} AND NOT EXISTS(SELECT * FROM adb_characters_quests WHERE char_guid = {2} AND quest_id = q.id) LIMIT 1;", _
                WORLD_CREATUREs(cGUID).ID, c.Level + 6, c.GUID), MySQLQuery)
                If MySQLQueryForGray.Rows.Count <> 0 Then
                    Status = QuestgiverStatus.DIALOG_STATUS_UNAVAILABLE
                Else
                    'DONE: No quests
                    Status = QuestgiverStatus.DIALOG_STATUS_NONE
                End If

            Else
                Status = QuestgiverStatus.DIALOG_STATUS_AVAILABLE
            End If
        End If

        Return Status
    End Function
    Public Sub On_CMSG_QUESTGIVER_STATUS_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim status As QuestgiverStatus = GetQuestgiverStatus(Client.Character, GUID)


        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_STATUS_QUERY [GUID={2:x} Status={3}]", Client.IP, Client.Port, GUID, status)


        Dim response As New PacketClass(OPCODES.SMSG_QUESTGIVER_STATUS)
        response.AddInt64(GUID)
        response.AddInt32(status)
        Client.Send(response)
        response.Dispose()
    End Sub

    Public Sub On_CMSG_QUESTGIVER_HELLO(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_HELLO [GUID={2:X}]", Client.IP, Client.Port, GUID)

        If CType(CREATURESDatabase(CType(WORLD_CREATUREs(GUID), CreatureObject).ID), CreatureInfo).TalkScript.OnQuestHello(Client.Character, GUID) Then
            SendQuestMenu(Client.Character, GUID, "I have some tasks for you, $N.")
        End If
    End Sub
    Public Sub On_CMSG_QUESTGIVER_QUERY_QUEST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim QuestID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_QUERY_QUEST [GUID={2:X} QuestID={3}]", Client.IP, Client.Port, GUID, QuestID)

        Client.Character.TalkCurrentQuest = New QuestInfo(QuestID)
        SendQuestDetails(Client, Client.Character.TalkCurrentQuest, GUID, True)
    End Sub
    Public Sub On_CMSG_QUESTGIVER_ACCEPT_QUEST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim QuestID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_ACCEPT_QUEST [GUID={2:X} QuestID={3}]", Client.IP, Client.Port, GUID, QuestID)

        'Load quest data
        If Client.Character.TalkCurrentQuest.ID <> QuestID Then Client.Character.TalkCurrentQuest = New QuestInfo(QuestID)

        If Client.Character.TalkCanAccept(Client.Character.TalkCurrentQuest) Then
            If Client.Character.TalkAddQuest(Client.Character.TalkCurrentQuest) Then
                If GuidIsPlayer(GUID) Then
                    Dim response As New PacketClass(OPCODES.MSG_QUEST_PUSH_RESULT)
                    response.AddInt64(Client.Character.GUID)
                    response.AddInt8(QuestPartyPushError.QUEST_PARTY_MSG_ACCEPT_QUEST)
                    response.AddInt32(0)
                    CHARACTERS(GUID).Client.Send(response)
                    response.Dispose()
                End If
            Else
                Dim response As New PacketClass(OPCODES.SMSG_QUESTLOG_FULL)
                Client.Send(response)
                response.Dispose()
            End If
        End If
    End Sub
    Public Sub On_CMSG_QUESTLOG_REMOVE_QUEST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim Slot As Byte = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTLOG_REMOVE_QUEST [Slot={2}]", Client.IP, Client.Port, Slot)
        Client.Character.TalkDeleteQuest(Slot)
    End Sub

    Public Sub On_CMSG_QUEST_QUERY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim QuestID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUEST_QUERY [QuestID={2}]", Client.IP, Client.Port, QuestID)

        If Client.Character.TalkCurrentQuest Is Nothing Then
            Dim tmpQuest As New QuestInfo(QuestID)
            SendQuest(Client, tmpQuest)
            Exit Sub
        End If

        If Client.Character.TalkCurrentQuest.ID <> QuestID Then
            SendQuest(Client, Client.Character.TalkCurrentQuest)
        Else
            Dim tmpQuest As New QuestInfo(QuestID)
            SendQuest(Client, tmpQuest)
        End If
    End Sub

    Public Sub CompleteQuest(ByVal c As CharacterObject, ByVal QuestID As Integer, ByVal QuestGiverGUID As Long)
        Dim i As Integer
        For i = 0 To QUEST_SLOTS
            If Not c.TalkQuests(i) Is Nothing Then
                If c.TalkQuests(i).ID = QuestID Then

                    'Load quest data
                    If c.TalkCurrentQuest Is Nothing Then c.TalkCurrentQuest = New QuestInfo(QuestID)
                    If c.TalkCurrentQuest.ID <> QuestID Then c.TalkCurrentQuest = New QuestInfo(QuestID)


                    If c.TalkQuests(i).Complete Then
                        'DONE: Show completion dialog
                        If TypeOf c.TalkQuests(i) Is QuestItem Or TypeOf c.TalkQuests(i) Is QuestDeliver Then
                            'Request items
                            SendQuestRequireItems(c.Client, c.TalkCurrentQuest, QuestGiverGUID, c.TalkQuests(i))
                        Else
                            SendQuestReward(c.Client, c.TalkCurrentQuest, QuestGiverGUID, c.TalkQuests(i))
                        End If
                    Else
                        'DONE: Just show incomplete text with disabled complete button
                        SendQuestRequireItems(c.Client, c.TalkCurrentQuest, QuestGiverGUID, c.TalkQuests(i))
                    End If


                    Exit For
                End If
            End If
        Next
    End Sub
    Public Sub On_CMSG_QUESTGIVER_COMPLETE_QUEST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim QuestID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_COMPLETE_QUEST [GUID={2:X} Quest={3}]", Client.IP, Client.Port, GUID, QuestID)

        CompleteQuest(Client.Character, QuestID, GUID)
    End Sub
    Public Sub On_CMSG_QUESTGIVER_REQUEST_REWARD(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim QuestID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_REQUEST_REWARD [GUID={2:X} Quest={3}]", Client.IP, Client.Port, GUID, QuestID)


        Dim i As Integer
        For i = 0 To QUEST_SLOTS
            If Client.Character.TalkQuests(i).ID = QuestID AndAlso Client.Character.TalkQuests(i).Complete Then

                'Load quest data
                If Client.Character.TalkCurrentQuest.ID <> QuestID Then Client.Character.TalkCurrentQuest = New QuestInfo(QuestID)
                SendQuestReward(Client, Client.Character.TalkCurrentQuest, GUID, Client.Character.TalkQuests(i))

                Exit For
            End If
        Next

    End Sub
    Public Sub On_CMSG_QUESTGIVER_CHOOSE_REWARD(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim QuestID As Integer = packet.GetInt32
        Dim RewardIndex As Integer = packet.GetInt32
        Dim i As Integer

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_QUESTGIVER_CHOOSE_REWARD [GUID={2:X} Quest={3} Reward={4}]", Client.IP, Client.Port, GUID, QuestID, RewardIndex)


        'Load quest data
        If Client.Character.TalkCurrentQuest Is Nothing Then Client.Character.TalkCurrentQuest = New QuestInfo(QuestID)
        If Client.Character.TalkCurrentQuest.ID <> QuestID Then Client.Character.TalkCurrentQuest = New QuestInfo(QuestID)

        'DONE: Removing required gold
        If (Client.Character.Copper - Client.Character.TalkCurrentQuest.ObjectivesGold) >= 0 Then
            'NOTE: Update flag set below
            Client.Character.Copper -= Client.Character.TalkCurrentQuest.ObjectivesGold
        Else
            Dim errorPacket As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_INVALID)
            errorPacket.AddInt32(QuestInvalidError.INVALIDREASON_DONT_HAVE_REQ_MONEY)
            Client.Send(errorPacket)
            errorPacket.Dispose()
            Exit Sub
        End If

        'DONE: Removing required items
        For i = 0 To QUEST_OBJECTIVES_COUNT
            If Client.Character.TalkCurrentQuest.ObjectivesItem(i) <> 0 Then
                If Not Client.Character.ItemCONSUME(Client.Character.TalkCurrentQuest.ObjectivesItem(i), Client.Character.TalkCurrentQuest.ObjectivesItem_Count(i)) Then
                    'DONE: Restore gold
                    Client.Character.Copper += Client.Character.TalkCurrentQuest.ObjectivesGold
                    'TODO: Restore items (not needed?)
                    Dim errorPacket As New PacketClass(OPCODES.SMSG_QUESTGIVER_QUEST_INVALID)
                    errorPacket.AddInt32(QuestInvalidError.INVALIDREASON_DONT_HAVE_REQ_ITEMS)
                    Client.Send(errorPacket)
                    errorPacket.Dispose()
                    Exit Sub
                End If
            Else
                Exit For
            End If
        Next


        'DONE: Adding reward choice
        If Client.Character.TalkCurrentQuest.RewardItems(RewardIndex) <> 0 Then
            Dim tmpItem As New ItemObject(Client.Character.TalkCurrentQuest.RewardItems(RewardIndex), Client.Character.GUID)
            tmpItem.StackCount = Client.Character.TalkCurrentQuest.RewardItems_Count(RewardIndex)
            If Not Client.Character.ItemADD(tmpItem) Then
                tmpItem.Delete()
                'DONE: Inventory full sent form SetItemSlot
                Exit Sub
            End If
        End If

        'DONE: Adding gold
        Client.Character.Copper += Client.Character.TalkCurrentQuest.RewardGold
        Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_FIELD_COINAGE, Client.Character.Copper)

        'DONE: Learning reward spell
        If Client.Character.TalkCurrentQuest.RewardSpell <> 0 Then Client.Character.LearnSpell(Client.Character.TalkCurrentQuest.RewardSpell)

        'DONE: Remove quest
        For i = 0 To QUEST_SLOTS
            If Not Client.Character.TalkQuests Is Nothing Then
                If Client.Character.TalkQuests(i).ID = Client.Character.TalkCurrentQuest.ID Then
                    Client.Character.TalkCompleteQuest(i)
                    Exit For
                End If
            End If
        Next

        'DONE: XP Calculations
        Dim xp As Integer = Client.Character.TalkCurrentQuest.RewardXP
        Dim gold As Integer = Client.Character.TalkCurrentQuest.RewardGold
        If Client.Character.Level >= MAX_LEVEL Then
            gold += xp
            xp = 0
        Else
            Select Case Client.Character.Level
                Case Client.Character.TalkCurrentQuest.Level_Normal + 6
                    xp = Fix(xp * 0.8 / 5) * 5
                Case Client.Character.TalkCurrentQuest.Level_Normal + 7
                    xp = Fix(xp * 0.6 / 5) * 5
                Case Client.Character.TalkCurrentQuest.Level_Normal + 8
                    xp = Fix(xp * 0.4 / 5) * 5
                Case Client.Character.TalkCurrentQuest.Level_Normal + 9
                    xp = Fix(xp * 0.2 / 5) * 5
                Case Is > Client.Character.TalkCurrentQuest.Level_Normal + 10
                    xp = Fix(xp * 0.1 / 5) * 5
            End Select
        End If

        'DONE: Adding XP
        Client.Character.AddXP(Client.Character.TalkCurrentQuest.RewardXP)

        SendQuestComplete(Client, Client.Character.TalkCurrentQuest, xp, gold)

        'DONE: Follow-up quests (no requirements checked?)
        If Client.Character.TalkCurrentQuest.NextQuest <> 0 Then
            Client.Character.TalkCurrentQuest = New QuestInfo(Client.Character.TalkCurrentQuest.NextQuest)
            SendQuestDetails(Client, Client.Character.TalkCurrentQuest, GUID, True)
        End If


        'DONE: Remove yelow dot on map
        Dim updatePacket As New PacketClass(OPCODES.SMSG_UPDATE_OBJECT)
        updatePacket.AddInt32(1)
        updatePacket.AddInt8(0)
        Dim tmpUpdate As New UpdateClass(FIELD_MASK_SIZE_UNIT)
        tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, WORLD_CREATUREs(GUID).cDynamicFlags - DynamicFlags.UNIT_DYNFLAG_TRACK_UNIT)
        tmpUpdate.AddToPacket(updatePacket, ObjectUpdateType.UPDATETYPE_VALUES, CType(WORLD_CREATUREs(GUID), CreatureObject), 0)
        tmpUpdate.Dispose()
        Client.Send(updatePacket)
        updatePacket.Dispose()
    End Sub



    Const QUEST_SHARING_DISTANCE = 10
    Public Sub On_CMSG_PUSHQUESTTOPARTY(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim questID As Integer = packet.GetInt32

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_PUSHQUESTTOPARTY [{2}]", Client.IP, Client.Port, questID)

        If Client.Character.IsInGroup Then
            For i As Byte = 0 To Client.Character.Party.GroupMembers.Length - 1
                If (Not Client.Character.Party.GroupMembers(i) Is Nothing) AndAlso (Not Client.Character Is Client.Character.Party.GroupMembers(i)) Then
                    With Client.Character.Party.GroupMembers(i)
                        Dim response As New PacketClass(OPCODES.MSG_QUEST_PUSH_RESULT)
                        response.AddInt64(Client.Character.Party.GroupMembers(i).GUID)
                        response.AddInt8(QuestPartyPushError.QUEST_PARTY_MSG_SHARRING_QUEST)
                        response.AddInt32(0)
                        Client.Send(response)
                        response.Dispose()

                        Dim message As QuestPartyPushError = QuestPartyPushError.QUEST_PARTY_MSG_SHARRING_QUEST

                        'DONE: Check distance and ...
                        If (Math.Sqrt((.positionX - Client.Character.positionX) ^ 2 + (.positionY - Client.Character.positionY) ^ 2) > QUEST_SHARING_DISTANCE) Then
                            message = QuestPartyPushError.QUEST_PARTY_MSG_TO_FAR
                        ElseIf .IsQuestInProgress(questID) Then
                            message = QuestPartyPushError.QUEST_PARTY_MSG_HAVE_QUEST
                        ElseIf .IsQuestCompleted(questID) Then
                            message = QuestPartyPushError.QUEST_PARTY_MSG_FINISH_QUEST
                        Else
                            If (.TalkCurrentQuest Is Nothing) OrElse (.TalkCurrentQuest.ID <> questID) Then .TalkCurrentQuest = New QuestInfo(questID)
                            If .TalkCanAccept(.TalkCurrentQuest) Then
                                SendQuestDetails(.Client, .TalkCurrentQuest, Client.Character.GUID, True)
                            Else
                                message = QuestPartyPushError.QUEST_PARTY_MSG_CANT_TAKE_QUEST
                            End If
                        End If


                        'DONE: Send error if present
                        If message <> QuestPartyPushError.QUEST_PARTY_MSG_SHARRING_QUEST Then
                            Dim errorPacket As New PacketClass(OPCODES.MSG_QUEST_PUSH_RESULT)
                            errorPacket.AddInt64(.GUID)
                            errorPacket.AddInt8(message)
                            errorPacket.AddInt32(0)
                            Client.Send(errorPacket)
                            errorPacket.Dispose()
                        End If


                    End With
                End If
            Next
        End If
    End Sub
    Public Sub On_MSG_QUEST_PUSH_RESULT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim GUID As Long = packet.GetInt64
        Dim Message As QuestPartyPushError = packet.GetInt8

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] MSG_QUEST_PUSH_RESULT [{2:X} {3}]", Client.IP, Client.Port, GUID, Message)

        'Dim response As New PacketClass(OPCODES.MSG_QUEST_PUSH_RESULT)
        'response.AddInt64(GUID)
        'response.AddInt8(QuestPartyPushError.QUEST_PARTY_MSG_ACCEPT_QUEST)
        'response.AddInt32(0)
        'Client.Send(response)
        'response.Dispose()
    End Sub


#End Region



End Module
