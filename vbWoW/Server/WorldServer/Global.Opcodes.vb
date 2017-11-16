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

Public Module Constants
    Public Function GuidIsCreature(ByVal GUID As Long) As Boolean
        If (GUID - GUID_UNIT) > 0 AndAlso (GUID - GUID_UNIT) < &H100000000000 Then Return True
        Return False
    End Function
    Public Function GuidIsItem(ByVal GUID As Long) As Boolean
        If (GUID - GUID_ITEM) > 0 AndAlso (GUID - GUID_ITEM) < &H100000000000 Then Return True
        Return False
    End Function
    Public Function GuidIsGameObject(ByVal GUID As Long) As Boolean
        If (GUID - GUID_GAMEOBJECT) > 0 AndAlso (GUID - GUID_GAMEOBJECT) < &H100000000000 Then Return True
        Return False
    End Function
    Public Function GuidIsCorpse(ByVal GUID As Long) As Boolean
        If (GUID - GUID_CORPSE) > 0 AndAlso (GUID - GUID_CORPSE) < &H100000000000 Then Return True
        Return False
    End Function
    Public Function GuidIsPlayer(ByVal GUID As Long) As Boolean
        If (GUID - GUID_PLAYER) > 0 AndAlso (GUID - GUID_PLAYER) < &H100000000000 Then Return True
        Return False
    End Function
    Public Function GuidHIGH(ByVal GUID As Long) As Integer
        Return GUID And &HFFFFFFFF
    End Function
    Public Function GuidLOW(ByVal GUID As Long) As Integer
        Return GUID And &HFFFFFFFF00000000
    End Function

    Public Const GUID_ITEM As Long = &H4000000000000000
    Public Const GUID_CONTAINER As Long = &H4000000000000000
    Public Const GUID_UNIT As Long = &HF000100000000000
    Public Const GUID_PLAYER As Long = &H0
    Public Const GUID_GAMEOBJECT As Long = &HF000700000000000
    Public Const GUID_DYNAMICOBJECT As Long = &HF000A00000000000
    Public Const GUID_CORPSE As Long = &HF100000000000000

    Public Const MAX_FRIENDS_ON_LIST As Byte = 20
    Public Const DEFAULT_DISTANCE_VISIBLE As Single = 155.8
    Public Const DEFAULT_DISTANCE_DETECTION As Single = 7

#If HANDLED_MAP_ID = 0 Then
    Public Const HANDLED_MAP_ID As Integer = 0
#ElseIf HANDLED_MAP_ID = 1 Then
        Public Const HANDLED_MAP_ID As Integer = 1
#ElseIf HANDLED_MAP_ID = 530 Then
        Public Const HANDLED_MAP_ID As Integer = 530
#ElseIf HANDLED_MAP_ID = -1 Then
        'TODO...
#End If

    Public Const CONNETION_SLEEP_TIME As Integer = 100
    Public Const CONNETION_TIMEOUT As Integer = 60000
    Public SERVER_CONFIG_DISABLED_CLASSES() As Boolean = {False, False, False, False, False, True, False, False, False, True, False}
    Public SERVER_CONFIG_DISABLED_RACES() As Boolean = {False, False, False, False, False, False, False, False, True, False, False}

    Public Const UNIT_NORMAL_WALK_SPEED As Single = 2.5F
    Public Const UNIT_NORMAL_RUN_SPEED As Single = 6.0F
    Public Const UNIT_NORMAL_SWIM_SPEED As Single = 4.722222F
    Public Const UNIT_NORMAL_SWIM_BACK_SPEED As Single = 4.5F
    Public Const UNIT_NORMAL_WALK_BACK_SPEED As Single = 2.5F
    Public Const UNIT_NORMAL_TURN_RATE As Single = Math.PI
    Public Const UNIT_NORMAL_FLY_SPEED As Single = 7.0F
    Public Const UNIT_NORMAL_FLY_BACK_SPEED As Single = 4.5F

    Public Const PLAYER_VISIBLE_ITEM_SIZE As Integer = 16
    Public Const PLAYER_SKILL_INFO_SIZE As Integer = 384 - 1
    Public Const PLAYER_EXPLORED_ZONES_SIZE As Integer = 64 - 1

    Public Const FIELD_MASK_SIZE_PLAYER As Integer = ((EPlayerFields.PLAYER_END + 32) \ 32) * 32
    Public Const FIELD_MASK_SIZE_UNIT As Integer = ((EUnitFields.UNIT_END + 32) \ 32) * 32
    Public Const FIELD_MASK_SIZE_GAMEOBJECT As Integer = FIELD_MASK_SIZE_CORPSE '((EGameObjectFields.GAMEOBJECT_END + 32) \ 32) * 32
    Public Const FIELD_MASK_SIZE_ITEM As Integer = ((EItemFields.ITEM_END + 32) \ 32) * 32
    Public Const FIELD_MASK_SIZE_CORPSE As Integer = ((ECorpseFields.CORPSE_END + 32) \ 32) * 32

    Public Const EQUIPMENT_SLOT_START As Byte = 0
    Public Const EQUIPMENT_SLOT_HEAD As Byte = 0
    Public Const EQUIPMENT_SLOT_NECK As Byte = 1
    Public Const EQUIPMENT_SLOT_SHOULDERS As Byte = 2
    Public Const EQUIPMENT_SLOT_BODY As Byte = 3
    Public Const EQUIPMENT_SLOT_CHEST As Byte = 4
    Public Const EQUIPMENT_SLOT_WAIST As Byte = 5
    Public Const EQUIPMENT_SLOT_LEGS As Byte = 6
    Public Const EQUIPMENT_SLOT_FEET As Byte = 7
    Public Const EQUIPMENT_SLOT_WRISTS As Byte = 8
    Public Const EQUIPMENT_SLOT_HANDS As Byte = 9
    Public Const EQUIPMENT_SLOT_FINGER1 As Byte = 10
    Public Const EQUIPMENT_SLOT_FINGER2 As Byte = 11
    Public Const EQUIPMENT_SLOT_TRINKET1 As Byte = 12
    Public Const EQUIPMENT_SLOT_TRINKET2 As Byte = 13
    Public Const EQUIPMENT_SLOT_BACK As Byte = 14
    Public Const EQUIPMENT_SLOT_MAINHAND As Byte = 15
    Public Const EQUIPMENT_SLOT_OFFHAND As Byte = 16
    Public Const EQUIPMENT_SLOT_RANGED As Byte = 17
    Public Const EQUIPMENT_SLOT_TABARD As Byte = 18
    Public Const EQUIPMENT_SLOT_END As Byte = 19

    Public Const INVENTORY_SLOT_BAG_START As Byte = 19
    Public Const INVENTORY_SLOT_BAG_1 As Byte = 19
    Public Const INVENTORY_SLOT_BAG_2 As Byte = 20
    Public Const INVENTORY_SLOT_BAG_3 As Byte = 21
    Public Const INVENTORY_SLOT_BAG_4 As Byte = 22
    Public Const INVENTORY_SLOT_BAG_END As Byte = 23

    Public Const INVENTORY_SLOT_ITEM_START As Byte = 23
    Public Const INVENTORY_SLOT_ITEM_1 As Byte = 23
    Public Const INVENTORY_SLOT_ITEM_2 As Byte = 24
    Public Const INVENTORY_SLOT_ITEM_3 As Byte = 25
    Public Const INVENTORY_SLOT_ITEM_4 As Byte = 26
    Public Const INVENTORY_SLOT_ITEM_5 As Byte = 27
    Public Const INVENTORY_SLOT_ITEM_6 As Byte = 28
    Public Const INVENTORY_SLOT_ITEM_7 As Byte = 29
    Public Const INVENTORY_SLOT_ITEM_8 As Byte = 30
    Public Const INVENTORY_SLOT_ITEM_9 As Byte = 31
    Public Const INVENTORY_SLOT_ITEM_10 As Byte = 32
    Public Const INVENTORY_SLOT_ITEM_11 As Byte = 33
    Public Const INVENTORY_SLOT_ITEM_12 As Byte = 34
    Public Const INVENTORY_SLOT_ITEM_13 As Byte = 35
    Public Const INVENTORY_SLOT_ITEM_14 As Byte = 36
    Public Const INVENTORY_SLOT_ITEM_15 As Byte = 37
    Public Const INVENTORY_SLOT_ITEM_16 As Byte = 38
    Public Const INVENTORY_SLOT_ITEM_END As Byte = 39

    Public Const BANK_SLOT_ITEM_START As Byte = 39
    Public Const BANK_SLOT_ITEM_1 As Byte = 39
    Public Const BANK_SLOT_ITEM_2 As Byte = 40
    Public Const BANK_SLOT_ITEM_3 As Byte = 41
    Public Const BANK_SLOT_ITEM_4 As Byte = 42
    Public Const BANK_SLOT_ITEM_5 As Byte = 43
    Public Const BANK_SLOT_ITEM_6 As Byte = 44
    Public Const BANK_SLOT_ITEM_7 As Byte = 45
    Public Const BANK_SLOT_ITEM_8 As Byte = 46
    Public Const BANK_SLOT_ITEM_9 As Byte = 47
    Public Const BANK_SLOT_ITEM_10 As Byte = 48
    Public Const BANK_SLOT_ITEM_11 As Byte = 49
    Public Const BANK_SLOT_ITEM_12 As Byte = 50
    Public Const BANK_SLOT_ITEM_13 As Byte = 51
    Public Const BANK_SLOT_ITEM_14 As Byte = 52
    Public Const BANK_SLOT_ITEM_15 As Byte = 53
    Public Const BANK_SLOT_ITEM_16 As Byte = 54
    Public Const BANK_SLOT_ITEM_17 As Byte = 55
    Public Const BANK_SLOT_ITEM_18 As Byte = 56
    Public Const BANK_SLOT_ITEM_19 As Byte = 57
    Public Const BANK_SLOT_ITEM_20 As Byte = 58
    Public Const BANK_SLOT_ITEM_21 As Byte = 59
    Public Const BANK_SLOT_ITEM_22 As Byte = 60
    Public Const BANK_SLOT_ITEM_23 As Byte = 61
    Public Const BANK_SLOT_ITEM_24 As Byte = 62
    Public Const BANK_SLOT_ITEM_25 As Byte = 63
    Public Const BANK_SLOT_ITEM_26 As Byte = 64
    Public Const BANK_SLOT_ITEM_27 As Byte = 65
    Public Const BANK_SLOT_ITEM_28 As Byte = 66
    Public Const BANK_SLOT_ITEM_END As Byte = 67

    Public Const BANK_SLOT_BAG_START As Byte = 67
    Public Const BANK_SLOT_BAG_1 As Byte = 67
    Public Const BANK_SLOT_BAG_2 As Byte = 68
    Public Const BANK_SLOT_BAG_3 As Byte = 69
    Public Const BANK_SLOT_BAG_4 As Byte = 70
    Public Const BANK_SLOT_BAG_5 As Byte = 71
    Public Const BANK_SLOT_BAG_6 As Byte = 72
    Public Const BANK_SLOT_BAG_7 As Byte = 73
    Public Const BANK_SLOT_BAG_END As Byte = 74

    Public Const BUYBACK_SLOT_START As Byte = 74
    Public Const BUYBACK_SLOT_1 As Byte = 74
    Public Const BUYBACK_SLOT_2 As Byte = 75
    Public Const BUYBACK_SLOT_3 As Byte = 76
    Public Const BUYBACK_SLOT_4 As Byte = 77
    Public Const BUYBACK_SLOT_5 As Byte = 78
    Public Const BUYBACK_SLOT_6 As Byte = 79
    Public Const BUYBACK_SLOT_7 As Byte = 80
    Public Const BUYBACK_SLOT_8 As Byte = 81
    Public Const BUYBACK_SLOT_9 As Byte = 82
    Public Const BUYBACK_SLOT_10 As Byte = 83
    Public Const BUYBACK_SLOT_11 As Byte = 84
    Public Const BUYBACK_SLOT_12 As Byte = 85
    Public Const BUYBACK_SLOT_END As Byte = 86

    Public Const KEYRING_SLOT_START As Byte = 86
    Public Const KEYRING_SLOT_END As Byte = 118
End Module
Public Enum OPCODES18
    'Realm Login
    SMSG_AUTH_CHALLENGE = &H1EC         '492
    CMSG_AUTH_SESSION = &H1ED           '493
    SMSG_AUTH_RESPONSE = &H1EE          '494
    CMSG_PING = &H1DC                   '476
    SMSG_PONG = &H1DD                   '477

    'Char managment
    CMSG_CHAR_CREATE = &H36             '54
    CMSG_CHAR_ENUM = &H37               '55
    CMSG_CHAR_DELETE = &H38             '56
    SMSG_CHAR_CREATE = &H3A             '58
    SMSG_CHAR_ENUM = &H3B               '59
    SMSG_CHAR_DELETE = &H3C             '60

    'Game Login
    CMSG_PLAYER_LOGIN = &H3D                '61
    SMSG_CHARACTER_LOGIN_FAILED = &H41      '65
    SMSG_LOGIN_SETTIMESPEED = &H42          '66
    SMSG_TRIGGER_CINEMATIC = &HFA           '250
    SMSG_TUTORIAL_FLAGS = &HFD              '253
    SMSG_INITIALIZE_FACTIONS = &H122        '290
    SMSG_SET_PROFICIENCY = &H127            '295
    SMSG_ACTION_BUTTONS = &H129             '297
    SMSG_INITIAL_SPELLS = &H12A             '298
    SMSG_BINDPOINTUPDATE = &H155            '341
    SMSG_PLAYERBOUND = &H158                '344
    SMSG_ACCOUNT_DATA_MD5 = &H209           '521
    CMSG_REQUEST_ACCOUNT_DATA = &H20A       '522
    CMSG_UPDATE_ACCOUNT_DATA = &H20B        '523
    SMSG_UPDATE_ACCOUNT_DATA = &H20C        '524
    SMSG_SET_REST_START = &H21E             '542
    SMSG_SET_FLAT_SPELL_MODIFIER = &H266    '614
    SMSG_CORPSE_RECLAIM_DELAY = &H269       '617
    SMSG_ADDON_INFO = &H2EF                 '751    'SendEnableAddOns

    'Items
    CMSG_ITEM_QUERY_SINGLE = &H56               '86 
    CMSG_ITEM_QUERY_MULTIPLE = &H57             '87     'Unhandled
    SMSG_ITEM_QUERY_SINGLE_RESPONSE = &H58      '88
    SMSG_ITEM_QUERY_MULTIPLE_RESPONSE = &H59    '89     'Unhandled
    CMSG_SWAP_INV_ITEM = &H10D                  '269
    SMSG_INVENTORY_CHANGE_FAILURE = &H112       '274
    CMSG_AUTOEQUIP_ITEM = &H10A                 '266
    CMSG_DESTROYITEM = &H111                    '273
    CMSG_AUTOSTORE_BAG_ITEM = &H10B             '267
    CMSG_SWAP_ITEM = &H10C                      '268
    CMSG_SPLIT_ITEM = &H10E                     '270
    CMSG_READ_ITEM = &HAD                       '173
    SMSG_READ_ITEM_OK = &HAE                    '174
    SMSG_READ_ITEM_FAILED = &HAF                '175
    CMSG_PAGE_TEXT_QUERY = &H5A                 '90
    SMSG_PAGE_TEXT_QUERY_RESPONSE = &H5B        '91
    CMSG_SETSHEATHED = &H1E0                    '480

    'Creatures
    CMSG_CREATURE_QUERY = &H60                  '96
    SMSG_CREATURE_QUERY_RESPONSE = &H61         '97
    SMSG_MONSTER_MOVE = &HDD                    '221

    'GameObjects
    MSG_CORPSE_QUERY = &H216                    '534
    CMSG_GAMEOBJECT_QUERY = &H5E                '94
    SMSG_GAMEOBJECT_QUERY_RESPONSE = &H5F       '95

    'Creatures - Talking
    CMSG_GOSSIP_HELLO = &H17B                   '379
    CMSG_GOSSIP_SELECT_OPTION = &H17C           '380  
    SMSG_GOSSIP_MESSAGE = &H17D                 '381
    SMSG_GOSSIP_COMPLETE = &H17E                '382
    CMSG_NPC_TEXT_QUERY = &H17F                 '383
    SMSG_NPC_TEXT_UPDATE = &H180                '384
    SMSG_GOSSIP_POI = &H224                     '548
    SMSG_SPIRIT_HEALER_CONFIRM = &H222          '546  
    CMSG_SPIRIT_HEALER_ACTIVATE = &H21C         '540

    'Characters
    CMSG_REPOP_REQUEST = &H15A                  '346
    CMSG_RECLAIM_CORPSE = &H1D2                 '466  
    MSG_MINIMAP_PING = &H1D5                    '469
    CMSG_SET_SELECTION = &H13D                  '317

    'Tutorials and Misc
    CMSG_TUTORIAL_FLAG = &HFE               '254
    CMSG_TUTORIAL_CLEAR = &HFF              '255
    CMSG_TUTORIAL_RESET = &H100             '256
    CMSG_SET_ACTION_BUTTON = &H128          '296
    SMSG_EXPLORATION_EXPERIENCE = &H1F8     '504 

    'Game Logout
    CMSG_PLAYER_LOGOUT = &H4A               '74
    CMSG_LOGOUT_REQUEST = &H4B              '75
    SMSG_LOGOUT_RESPONSE = &H4C             '76
    SMSG_LOGOUT_COMPLETE = &H4D             '77
    CMSG_LOGOUT_CANCEL = &H4E               '78
    SMSG_LOGOUT_CANCEL_ACK = &H4F           '79
    SMSG_FORCE_MOVE_ROOT = &HE8             '232        'VERSION 1.9.X FIX
    SMSG_FORCE_MOVE_UNROOT = &HEA           '234        'VERSION 1.9.X FIX

    'Ingame
    SMSG_UPDATE_OBJECT = &HA9               '169        'VERSION 1.9.X FIX
    CMSG_STANDSTATECHANGE = &H101           '257
    SMSG_LEVELUP_INFO = &H1D4               '468
    SMSG_LOG_XPGAIN = &H1D0                 '464    'c.LogXPGain()
    SMSG_PVP_CREDIT = &H28C                 '652    'c.LogHonorGain()
    SMSG_REMOVED_SPELL = &H203              '515    'c.UnlearnSpell()
    SMSG_LEARNED_SPELL = &H12B              '299    'c.LearnSpell
    SMSG_ENVIRONMENTALDAMAGELOG = &H1FC     '508    'c.LogEnvironmentalDamage

    'Movement
    MSG_MOVE_START_FORWARD = 181
    MSG_MOVE_START_BACKWARD = 182
    MSG_MOVE_STOP = 183
    MSG_MOVE_START_STRAFE_LEFT = 184
    MSG_MOVE_START_STRAFE_RIGHT = 185
    MSG_MOVE_STOP_STRAFE = 186
    MSG_MOVE_JUMP = 187
    MSG_MOVE_START_TURN_LEFT = 188
    MSG_MOVE_START_TURN_RIGHT = 189
    MSG_MOVE_STOP_TURN = 190
    MSG_MOVE_START_PITCH_UP = 191
    MSG_MOVE_START_PITCH_DOWN = 192
    MSG_MOVE_STOP_PITCH = 193
    MSG_MOVE_SET_RUN_MODE = 194
    MSG_MOVE_SET_WALK_MODE = 195
    MSG_MOVE_START_SWIM = 202
    MSG_MOVE_STOP_SWIM = 203
    MSG_MOVE_SET_FACING = 218
    MSG_MOVE_SET_PITCH = 219
    MSG_MOVE_HEARTBEAT = &HEE               '238 
    MSG_MOVE_FALL_LAND = &HC9               '201  
    CMSG_AREATRIGGER = &HB4                 '180
    CMSG_ZONEUPDATE = &H1F4                 '500
    SMSG_FORCE_RUN_SPEED_CHANGE = &HE2                   '226   'c.SetRunSpeed
    CMSG_FORCE_RUN_SPEED_CHANGE_ACK = &HE3               '227
    SMSG_FORCE_RUN_BACK_SPEED_CHANGE = &HE4              '228   'c.SetRunBackSpeed
    CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK = &HE5          '229
    SMSG_FORCE_SWIM_SPEED_CHANGE = &HE6                  '230   'c.SetSwimSpeed
    CMSG_FORCE_SWIM_SPEED_CHANGE_ACK = &HE7              '231
    SMSG_MOVE_WATER_WALK = &HDE              '222   'c.SetWaterWalk
    SMSG_MOVE_LAND_WALK = &HDF               '223   'c.SetLandWalk
    SMSG_START_MIRROR_TIMER = 473           '473    'c.StartMirrorTimer
    SMSG_STOP_MIRROR_TIMER = 475            '475    'c.StopMirrorTimer

    MSG_MOVE_SET_RUN_SPEED = &HCD            '205
    MSG_MOVE_SET_RUN_BACK_SPEED = &HCF       '207 
    MSG_MOVE_SET_WALK_SPEED = &HD1           '209
    MSG_MOVE_SET_SWIM_SPEED = &HD3           '211
    MSG_MOVE_SET_SWIM_BACK_SPEED = &HD5      '213
    MSG_MOVE_SET_TURN_RATE = &HD8            '216

    'Queries
    CMSG_WHO = &H62                         '98
    SMSG_WHO = &H63                         '99

    'Friends
    CMSG_FRIEND_LIST = &H66                 '102
    SMSG_FRIEND_LIST = &H67                 '103
    SMSG_FRIEND_STATUS = &H68               '104
    CMSG_ADD_FRIEND = &H69                  '105
    CMSG_DEL_FRIEND = &H6A                  '106
    SMSG_IGNORE_LIST = &H6B                 '107
    CMSG_ADD_IGNORE = &H6C                  '108
    CMSG_DEL_IGNORE = &H6D                  '109
    SMSG_CHAT_PLAYER_NOT_FOUND = &H2A9      '681

    'Chat - General
    CMSG_NAME_QUERY = &H50                  '80
    SMSG_NAME_QUERY_RESPONSE = &H51         '81
    CMSG_MESSAGECHAT = &H95                 '149
    SMSG_MESSAGECHAT = &H96                 '150
    CMSG_EMOTE = &H102                      '258
    SMSG_EMOTE = &H103                      '259
    CMSG_TEXT_EMOTE = &H104                 '260
    SMSG_TEXT_EMOTE = &H105                 '261

    'Chat - Channels
    CMSG_JOIN_CHANNEL = &H97                '151
    CMSG_LEAVE_CHANNEL = &H98               '152
    SMSG_CHANNEL_NOTIFY = &H99              '153
    CMSG_CHANNEL_LIST = &H9A                '154
    SMSG_CHANNEL_LIST = &H9B                '155
    CMSG_CHANNEL_PASSWORD = &H9C            '156
    CMSG_CHANNEL_SET_OWNER = &H9D           '157
    CMSG_CHANNEL_OWNER = &H9E               '158
    CMSG_CHANNEL_MODERATOR = &H9F           '159
    CMSG_CHANNEL_UNMODERATOR = &HA0         '160
    CMSG_CHANNEL_MUTE = &HA1                '161
    CMSG_CHANNEL_UNMUTE = &HA2              '162
    CMSG_CHANNEL_INVITE = &HA3              '163
    CMSG_CHANNEL_KICK = &HA4                '164
    CMSG_CHANNEL_BAN = &HA5                 '165
    CMSG_CHANNEL_UNBAN = &HA6               '166
    CMSG_CHANNEL_ANNOUNCEMENTS = &HA7       '167
    CMSG_CHANNEL_MODERATE = &HA8            '168

    'Don't know what means
    CMSG_QUERY_TIME = &H1CE                 '462
    SMSG_QUERY_TIME_RESPONSE = &H1CF        '463

    'Unhandled
    CMSG_MOVE_TIME_SKIPPED = &H2CE          '718
    CMSG_NEXT_CINEMATIC_CAMERA = &HFB       '251   
    CMSG_COMPLETE_CINEMATIC = &HFC          '252
End Enum
Public Enum OPCODES
    MSG_NULL_ACTION = 0                                 '(0x000)
    CMSG_BOOTME = 1                                     '(0x001)
    CMSG_DBLOOKUP = 2                                   '(0x002)
    SMSG_DBLOOKUP = 3                                   '(0x003)
    CMSG_QUERY_OBJECT_POSITION = 4                      '(0x004)
    SMSG_QUERY_OBJECT_POSITION = 5                      '(0x005)
    CMSG_QUERY_OBJECT_ROTATION = 6                      '(0x006)
    SMSG_QUERY_OBJECT_ROTATION = 7                      '(0x007)
    CMSG_WORLD_TELEPORT = 8                             '(0x008)
    CMSG_TELEPORT_TO_UNIT = 9                           '(0x009)
    CMSG_ZONE_MAP = 10                                  '(0x00A)
    SMSG_ZONE_MAP = 11                                  '(0x00B)
    CMSG_DEBUG_CHANGECELLZONE = 12                      '(0x00C)
    CMSG_EMBLAZON_TABARD_OBSOLETE = 13                  '(0x00D)
    CMSG_UNEMBLAZON_TABARD_OBSOLETE = 14                '(0x00E)
    CMSG_RECHARGE = 15                                  '(0x00F)
    CMSG_LEARN_SPELL = 16                               '(0x010)
    CMSG_CREATEMONSTER = 17                             '(0x011)
    CMSG_DESTROYMONSTER = 18                            '(0x012)
    CMSG_CREATEITEM = 19                                '(0x013)
    CMSG_CREATEGAMEOBJECT = 20                          '(0x014)
    CMSG_MAKEMONSTERATTACKME_OBSOLETE = 21              '(0x015)
    CMSG_MAKEMONSTERATTACKGUID = 22                     '(0x016)
    CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE = 23         '(0x017)
    CMSG_FORCEACTION = 24                               '(0x018)
    CMSG_FORCEACTIONONOTHER = 25                        '(0x019)
    CMSG_FORCEACTIONSHOW = 26                           '(0x01A)
    SMSG_FORCEACTIONSHOW = 27                           '(0x01B)
    SMSG_ATTACKERSTATEUPDATEDEBUGINFO_OBSOLETE = 28     '(0x01C)
    SMSG_DEBUGINFOSPELL_OBSOLETE = 29                   '(0x01D)
    SMSG_DEBUGINFOSPELLMISS_OBSOLETE = 30               '(0x01E)
    SMSG_DEBUG_PLAYER_RANGE_OBSOLETE = 31               '(0x01F)
    CMSG_UNDRESSPLAYER = 32                             '(0x020)
    CMSG_BEASTMASTER = 33                               '(0x021)
    CMSG_GODMODE = 34                                   '(0x022)
    SMSG_GODMODE = 35                                   '(0x023)
    CMSG_CHEAT_SETMONEY = 36                            '(0x024)
    CMSG_LEVEL_CHEAT = 37                               '(0x025)
    CMSG_PET_LEVEL_CHEAT = 38                           '(0x026)
    CMSG_LEVELUP_CHEAT_OBSOLETE = 39                    '(0x027)
    CMSG_COOLDOWN_CHEAT = 40                            '(0x028)
    CMSG_USE_SKILL_CHEAT = 41                           '(0x029)
    CMSG_FLAG_QUEST = 42                                '(0x02A)
    CMSG_FLAG_QUEST_FINISH = 43                         '(0x02B)
    CMSG_CLEAR_QUEST = 44                               '(0x02C)
    CMSG_SEND_EVENT = 45                                '(0x02D)
    CMSG_DEBUG_AISTATE = 46                             '(0x02E)
    SMSG_DEBUG_AISTATE = 47                             '(0x02F)
    CMSG_DISABLE_PVP_CHEAT = 48                         '(0x030)
    CMSG_ADVANCE_SPAWN_TIME = 49                        '(0x031)
    CMSG_PVP_PORT_OBSOLETE = 50                         '(0x032)
    CMSG_AUTH_SRP6_BEGIN = 51                           '(0x033)
    CMSG_AUTH_SRP6_PROOF = 52                           '(0x034)
    CMSG_AUTH_SRP6_RECODE = 53                          '(0x035)
    CMSG_CHAR_CREATE = 54                               '(0x036)
    CMSG_CHAR_ENUM = 55                                 '(0x037)
    CMSG_CHAR_DELETE = 56                               '(0x038)
    SMSG_AUTH_SRP6_RESPONSE = 57                        '(0x039)
    SMSG_CHAR_CREATE = 58                               '(0x03A)
    SMSG_CHAR_ENUM = 59                                 '(0x03B)
    SMSG_CHAR_DELETE = 60                               '(0x03C)
    CMSG_PLAYER_LOGIN = 61                              '(0x03D)
    SMSG_NEW_WORLD = 62                                 '(0x03E)
    SMSG_TRANSFER_PENDING = 63                          '(0x03F)
    SMSG_TRANSFER_ABORTED = 64                          '(0x040)
    SMSG_CHARACTER_LOGIN_FAILED = 65                    '(0x041)
    SMSG_LOGIN_SETTIMESPEED = 66                        '(0x042)
    SMSG_GAMETIME_UPDATE = 67                           '(0x043)
    CMSG_GAMETIME_SET = 68                              '(0x044)
    SMSG_GAMETIME_SET = 69                              '(0x045)
    CMSG_GAMESPEED_SET = 70                             '(0x046)
    SMSG_GAMESPEED_SET = 71                             '(0x047)
    CMSG_SERVERTIME = 72                                '(0x048)
    SMSG_SERVERTIME = 73                                '(0x049)
    CMSG_PLAYER_LOGOUT = 74                             '(0x04A)
    CMSG_LOGOUT_REQUEST = 75                            '(0x04B)
    SMSG_LOGOUT_RESPONSE = 76                           '(0x04C)
    SMSG_LOGOUT_COMPLETE = 77                           '(0x04D)
    CMSG_LOGOUT_CANCEL = 78                             '(0x04E)
    SMSG_LOGOUT_CANCEL_ACK = 79                         '(0x04F)
    CMSG_NAME_QUERY = 80                                '(0x050)
    SMSG_NAME_QUERY_RESPONSE = 81                       '(0x051)
    CMSG_PET_NAME_QUERY = 82                            '(0x052)
    SMSG_PET_NAME_QUERY_RESPONSE = 83                   '(0x053)
    CMSG_GUILD_QUERY = 84                               '(0x054)
    SMSG_GUILD_QUERY_RESPONSE = 85                      '(0x055)
    CMSG_ITEM_QUERY_SINGLE = 86                         '(0x056)
    CMSG_ITEM_QUERY_MULTIPLE = 87                       '(0x057)
    SMSG_ITEM_QUERY_SINGLE_RESPONSE = 88                '(0x058)
    SMSG_ITEM_QUERY_MULTIPLE_RESPONSE = 89              '(0x059)
    CMSG_PAGE_TEXT_QUERY = 90                           '(0x05A)
    SMSG_PAGE_TEXT_QUERY_RESPONSE = 91                  '(0x05B)
    CMSG_QUEST_QUERY = 92                               '(0x05C)
    SMSG_QUEST_QUERY_RESPONSE = 93                      '(0x05D)
    CMSG_GAMEOBJECT_QUERY = 94                          '(0x05E)
    SMSG_GAMEOBJECT_QUERY_RESPONSE = 95                 '(0x05F)
    CMSG_CREATURE_QUERY = 96                            '(0x060)
    SMSG_CREATURE_QUERY_RESPONSE = 97                   '(0x061)
    CMSG_WHO = 98                                       '(0x062)
    SMSG_WHO = 99                                       '(0x063)
    CMSG_WHOIS = 100                                    '(0x064)
    SMSG_WHOIS = 101                                    '(0x065)
    CMSG_FRIEND_LIST = 102                              '(0x066)
    SMSG_FRIEND_LIST = 103                              '(0x067)
    SMSG_FRIEND_STATUS = 104                            '(0x068)
    CMSG_ADD_FRIEND = 105                               '(0x069)
    CMSG_DEL_FRIEND = 106                               '(0x06A)
    SMSG_IGNORE_LIST = 107                              '(0x06B)
    CMSG_ADD_IGNORE = 108                               '(0x06C)
    CMSG_DEL_IGNORE = 109                               '(0x06D)
    CMSG_GROUP_INVITE = 110                             '(0x06E)
    SMSG_GROUP_INVITE = 111                             '(0x06F)
    CMSG_GROUP_CANCEL = 112                             '(0x070)
    SMSG_GROUP_CANCEL = 113                             '(0x071)
    CMSG_GROUP_ACCEPT = 114                             '(0x072)
    CMSG_GROUP_DECLINE = 115                            '(0x073)
    SMSG_GROUP_DECLINE = 116                            '(0x074)
    CMSG_GROUP_UNINVITE = 117                           '(0x075)
    CMSG_GROUP_UNINVITE_GUID = 118                      '(0x076)
    SMSG_GROUP_UNINVITE = 119                           '(0x077)
    CMSG_GROUP_SET_LEADER = 120                         '(0x078)
    SMSG_GROUP_SET_LEADER = 121                         '(0x079)
    CMSG_LOOT_METHOD = 122                              '(0x07A)
    CMSG_GROUP_DISBAND = 123                            '(0x07B)
    SMSG_GROUP_DESTROYED = 124                          '(0x07C)
    SMSG_GROUP_LIST = 125                               '(0x07D)
    SMSG_PARTY_MEMBER_STATS = 126                       '(0x07E)
    SMSG_PARTY_COMMAND_RESULT = 127                     '(0x07F)
    UMSG_UPDATE_GROUP_MEMBERS = 128                     '(0x080)
    CMSG_GUILD_CREATE = 129                             '(0x081)
    CMSG_GUILD_INVITE = 130                             '(0x082)
    SMSG_GUILD_INVITE = 131                             '(0x083)
    CMSG_GUILD_ACCEPT = 132                             '(0x084)
    CMSG_GUILD_DECLINE = 133                            '(0x085)
    SMSG_GUILD_DECLINE = 134                            '(0x086)
    CMSG_GUILD_INFO = 135                               '(0x087)
    SMSG_GUILD_INFO = 136                               '(0x088)
    CMSG_GUILD_ROSTER = 137                             '(0x089)
    SMSG_GUILD_ROSTER = 138                             '(0x08A)
    CMSG_GUILD_PROMOTE = 139                            '(0x08B)
    CMSG_GUILD_DEMOTE = 140                             '(0x08C)
    CMSG_GUILD_LEAVE = 141                              '(0x08D)
    CMSG_GUILD_REMOVE = 142                             '(0x08E)
    CMSG_GUILD_DISBAND = 143                            '(0x08F)
    CMSG_GUILD_LEADER = 144                             '(0x090)
    CMSG_GUILD_MOTD = 145                               '(0x091)
    SMSG_GUILD_EVENT = 146                              '(0x092)
    SMSG_GUILD_COMMAND_RESULT = 147                     '(0x093)
    UMSG_UPDATE_GUILD = 148                             '(0x094)
    CMSG_MESSAGECHAT = 149                              '(0x095)
    SMSG_MESSAGECHAT = 150                              '(0x096)
    CMSG_JOIN_CHANNEL = 151                             '(0x097)
    CMSG_LEAVE_CHANNEL = 152                            '(0x098)
    SMSG_CHANNEL_NOTIFY = 153                           '(0x099)
    CMSG_CHANNEL_LIST = 154                             '(0x09A)
    SMSG_CHANNEL_LIST = 155                             '(0x09B)
    CMSG_CHANNEL_PASSWORD = 156                         '(0x09C)
    CMSG_CHANNEL_SET_OWNER = 157                        '(0x09D)
    CMSG_CHANNEL_OWNER = 158                            '(0x09E)
    CMSG_CHANNEL_MODERATOR = 159                        '(0x09F)
    CMSG_CHANNEL_UNMODERATOR = 160                      '(0x0A0)
    CMSG_CHANNEL_MUTE = 161                             '(0x0A1)
    CMSG_CHANNEL_UNMUTE = 162                           '(0x0A2)
    CMSG_CHANNEL_INVITE = 163                           '(0x0A3)
    CMSG_CHANNEL_KICK = 164                             '(0x0A4)
    CMSG_CHANNEL_BAN = 165                              '(0x0A5)
    CMSG_CHANNEL_UNBAN = 166                            '(0x0A6)
    CMSG_CHANNEL_ANNOUNCEMENTS = 167                    '(0x0A7)
    CMSG_CHANNEL_MODERATE = 168                         '(0x0A8)
    SMSG_UPDATE_OBJECT = 169                            '(0x0A9)
    SMSG_DESTROY_OBJECT = 170                           '(0x0AA)
    CMSG_USE_ITEM = 171                                 '(0x0AB)
    CMSG_OPEN_ITEM = 172                                '(0x0AC)
    CMSG_READ_ITEM = 173                                '(0x0AD)
    SMSG_READ_ITEM_OK = 174                             '(0x0AE)
    SMSG_READ_ITEM_FAILED = 175                         '(0x0AF)
    SMSG_ITEM_COOLDOWN = 176                            '(0x0B0)
    CMSG_GAMEOBJ_USE = 177                              '(0x0B1)
    CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE = 178               '(0x0B2)
    SMSG_GAMEOBJECT_CUSTOM_ANIM = 179                   '(0x0B3)
    CMSG_AREATRIGGER = 180                              '(0x0B4)
    MSG_MOVE_START_FORWARD = 181                        '(0x0B5)
    MSG_MOVE_START_BACKWARD = 182                       '(0x0B6)
    MSG_MOVE_STOP = 183                                 '(0x0B7)
    MSG_MOVE_START_STRAFE_LEFT = 184                    '(0x0B8)
    MSG_MOVE_START_STRAFE_RIGHT = 185                   '(0x0B9)
    MSG_MOVE_STOP_STRAFE = 186                          '(0x0BA)
    MSG_MOVE_JUMP = 187                                 '(0x0BB)
    MSG_MOVE_START_TURN_LEFT = 188                      '(0x0BC)
    MSG_MOVE_START_TURN_RIGHT = 189                     '(0x0BD)
    MSG_MOVE_STOP_TURN = 190                            '(0x0BE)
    MSG_MOVE_START_PITCH_UP = 191                       '(0x0BF)
    MSG_MOVE_START_PITCH_DOWN = 192                     '(0x0C0)
    MSG_MOVE_STOP_PITCH = 193                           '(0x0C1)
    MSG_MOVE_SET_RUN_MODE = 194                         '(0x0C2)
    MSG_MOVE_SET_WALK_MODE = 195                        '(0x0C3)
    MSG_MOVE_TOGGLE_LOGGING = 196                       '(0x0C4)
    MSG_MOVE_TELEPORT = 197                             '(0x0C5)
    MSG_MOVE_TELEPORT_CHEAT = 198                       '(0x0C6)
    MSG_MOVE_TELEPORT_ACK = 199                         '(0x0C7)
    MSG_MOVE_TOGGLE_FALL_LOGGING = 200                  '(0x0C8)
    MSG_MOVE_FALL_LAND = 201                            '(0x0C9)
    MSG_MOVE_START_SWIM = 202                           '(0x0CA)
    MSG_MOVE_STOP_SWIM = 203                            '(0x0CB)
    MSG_MOVE_SET_RUN_SPEED_CHEAT = 204                  '(0x0CC)
    MSG_MOVE_SET_RUN_SPEED = 205                        '(0x0CD)
    MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT = 206             '(0x0CE)
    MSG_MOVE_SET_RUN_BACK_SPEED = 207                   '(0x0CF)
    MSG_MOVE_SET_WALK_SPEED_CHEAT = 208                 '(0x0D0)
    MSG_MOVE_SET_WALK_SPEED = 209                       '(0x0D1)
    MSG_MOVE_SET_SWIM_SPEED_CHEAT = 210                 '(0x0D2)
    MSG_MOVE_SET_SWIM_SPEED = 211                       '(0x0D3)
    MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT = 212            '(0x0D4)
    MSG_MOVE_SET_SWIM_BACK_SPEED = 213                  '(0x0D5)
    MSG_MOVE_SET_ALL_SPEED_CHEAT = 214                  '(0x0D6)
    MSG_MOVE_SET_TURN_RATE_CHEAT = 215                  '(0x0D7)
    MSG_MOVE_SET_TURN_RATE = 216                        '(0x0D8)
    MSG_MOVE_TOGGLE_COLLISION_CHEAT = 217               '(0x0D9)
    MSG_MOVE_SET_FACING = 218                           '(0x0DA)
    MSG_MOVE_SET_PITCH = 219                            '(0x0DB)
    MSG_MOVE_WORLDPORT_ACK = 220                        '(0x0DC)
    SMSG_MONSTER_MOVE = 221                             '(0x0DD)
    SMSG_MOVE_WATER_WALK = 222                          '(0x0DE)
    SMSG_MOVE_LAND_WALK = 223                           '(0x0DF)
    MSG_MOVE_SET_RAW_POSITION_ACK = 224                 '(0x0E0)
    CMSG_MOVE_SET_RAW_POSITION = 225                    '(0x0E1)
    SMSG_FORCE_RUN_SPEED_CHANGE = 226                   '(0x0E2)
    CMSG_FORCE_RUN_SPEED_CHANGE_ACK = 227               '(0x0E3)
    SMSG_FORCE_RUN_BACK_SPEED_CHANGE = 228              '(0x0E4)
    CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK = 229          '(0x0E5)
    SMSG_FORCE_SWIM_SPEED_CHANGE = 230                  '(0x0E6)
    CMSG_FORCE_SWIM_SPEED_CHANGE_ACK = 231              '(0x0E7)
    SMSG_FORCE_MOVE_ROOT = 232                          '(0x0E8)
    CMSG_FORCE_MOVE_ROOT_ACK = 233                      '(0x0E9)
    SMSG_FORCE_MOVE_UNROOT = 234                        '(0x0EA)
    CMSG_FORCE_MOVE_UNROOT_ACK = 235                    '(0x0EB)
    MSG_MOVE_ROOT = 236                                 '(0x0EC)
    MSG_MOVE_UNROOT = 237                               '(0x0ED)
    MSG_MOVE_HEARTBEAT = 238                            '(0x0EE)
    SMSG_MOVE_KNOCK_BACK = 239                          '(0x0EF)
    CMSG_MOVE_KNOCK_BACK_ACK = 240                      '(0x0F0)
    MSG_MOVE_KNOCK_BACK = 241                           '(0x0F1)
    SMSG_MOVE_FEATHER_FALL = 242                        '(0x0F2)
    SMSG_MOVE_NORMAL_FALL = 243                         '(0x0F3)
    SMSG_MOVE_SET_HOVER = 244                           '(0x0F4)
    SMSG_MOVE_UNSET_HOVER = 245                         '(0x0F5)
    CMSG_MOVE_HOVER_ACK = 246                           '(0x0F6)
    MSG_MOVE_HOVER = 247                                '(0x0F7)
    CMSG_TRIGGER_CINEMATIC_CHEAT = 248                  '(0x0F8)
    CMSG_OPENING_CINEMATIC = 249                        '(0x0F9)
    SMSG_TRIGGER_CINEMATIC = 250                        '(0x0FA)
    CMSG_NEXT_CINEMATIC_CAMERA = 251                    '(0x0FB)
    CMSG_COMPLETE_CINEMATIC = 252                       '(0x0FC)
    SMSG_TUTORIAL_FLAGS = 253                           '(0x0FD)
    CMSG_TUTORIAL_FLAG = 254                            '(0x0FE)
    CMSG_TUTORIAL_CLEAR = 255                           '(0x0FF)
    CMSG_TUTORIAL_RESET = 256                           '(0x100)
    CMSG_STANDSTATECHANGE = 257                         '(0x101)
    CMSG_EMOTE = 258                                    '(0x102)
    SMSG_EMOTE = 259                                    '(0x103)
    CMSG_TEXT_EMOTE = 260                               '(0x104)
    SMSG_TEXT_EMOTE = 261                               '(0x105)
    CMSG_AUTOEQUIP_GROUND_ITEM = 262                    '(0x106)
    CMSG_AUTOSTORE_GROUND_ITEM = 263                    '(0x107)
    CMSG_AUTOSTORE_LOOT_ITEM = 264                      '(0x108)
    CMSG_STORE_LOOT_IN_SLOT = 265                       '(0x109)
    CMSG_AUTOEQUIP_ITEM = 266                           '(0x10A)
    CMSG_AUTOSTORE_BAG_ITEM = 267                       '(0x10B)
    CMSG_SWAP_ITEM = 268                                '(0x10C)
    CMSG_SWAP_INV_ITEM = 269                            '(0x10D)
    CMSG_SPLIT_ITEM = 270                               '(0x10E)
    CMSG_PICKUP_ITEM = 271                              '(0x10F)
    CMSG_DROP_ITEM = 272                                '(0x110)
    CMSG_DESTROYITEM = 273                              '(0x111)
    SMSG_INVENTORY_CHANGE_FAILURE = 274                 '(0x112)
    SMSG_OPEN_CONTAINER = 275                           '(0x113)
    CMSG_INSPECT = 276                                  '(0x114)
    SMSG_INSPECT = 277                                  '(0x115)
    CMSG_INITIATE_TRADE = 278                           '(0x116)
    CMSG_BEGIN_TRADE = 279                              '(0x117)
    CMSG_BUSY_TRADE = 280                               '(0x118)
    CMSG_IGNORE_TRADE = 281                             '(0x119)
    CMSG_ACCEPT_TRADE = 282                             '(0x11A)
    CMSG_UNACCEPT_TRADE = 283                           '(0x11B)
    CMSG_CANCEL_TRADE = 284                             '(0x11C)
    CMSG_SET_TRADE_ITEM = 285                           '(0x11D)
    CMSG_CLEAR_TRADE_ITEM = 286                         '(0x11E)
    CMSG_SET_TRADE_GOLD = 287                           '(0x11F)
    SMSG_TRADE_STATUS = 288                             '(0x120)
    SMSG_TRADE_STATUS_EXTENDED = 289                    '(0x121)
    SMSG_INITIALIZE_FACTIONS = 290                      '(0x122)
    SMSG_SET_FACTION_VISIBLE = 291                      '(0x123)
    SMSG_SET_FACTION_STANDING = 292                     '(0x124)
    CMSG_SET_FACTION_ATWAR = 293                        '(0x125)
    CMSG_SET_FACTION_CHEAT = 294                        '(0x126)
    SMSG_SET_PROFICIENCY = 295                          '(0x127)
    CMSG_SET_ACTION_BUTTON = 296                        '(0x128)
    SMSG_ACTION_BUTTONS = 297                           '(0x129)
    SMSG_INITIAL_SPELLS = 298                           '(0x12A)
    SMSG_LEARNED_SPELL = 299                            '(0x12B)
    SMSG_SUPERCEDED_SPELL = 300                         '(0x12C)
    CMSG_NEW_SPELL_SLOT = 301                           '(0x12D)
    CMSG_CAST_SPELL = 302                               '(0x12E)
    CMSG_CANCEL_CAST = 303                              '(0x12F)
    SMSG_CAST_RESULT = 304                              '(0x130)
    SMSG_SPELL_START = 305                              '(0x131)
    SMSG_SPELL_GO = 306                                 '(0x132)
    SMSG_SPELL_FAILURE = 307                            '(0x133)
    SMSG_SPELL_COOLDOWN = 308                           '(0x134)
    SMSG_COOLDOWN_EVENT = 309                           '(0x135)
    CMSG_CANCEL_AURA = 310                              '(0x136)
    SMSG_UPDATE_AURA_DURATION = 311                     '(0x137)
    SMSG_PET_CAST_FAILED = 312                          '(0x138)
    MSG_CHANNEL_START = 313                             '(0x139)
    MSG_CHANNEL_UPDATE = 314                            '(0x13A)
    CMSG_CANCEL_CHANNELLING = 315                       '(0x13B)
    SMSG_AI_REACTION = 316                              '(0x13C)
    CMSG_SET_SELECTION = 317                            '(0x13D)
    CMSG_SET_TARGET_OBSOLETE = 318                      '(0x13E)
    CMSG_UNUSED = 319                                   '(0x13F)
    CMSG_UNUSED2 = 320                                  '(0x140)
    CMSG_ATTACKSWING = 321                              '(0x141)
    CMSG_ATTACKSTOP = 322                               '(0x142)
    SMSG_ATTACKSTART = 323                              '(0x143)
    SMSG_ATTACKSTOP = 324                               '(0x144)
    SMSG_ATTACKSWING_NOTINRANGE = 325                   '(0x145)
    SMSG_ATTACKSWING_BADFACING = 326                    '(0x146)
    SMSG_ATTACKSWING_NOTSTANDING = 327                  '(0x147)
    SMSG_ATTACKSWING_DEADTARGET = 328                   '(0x148)
    SMSG_ATTACKSWING_CANT_ATTACK = 329                  '(0x149)
    SMSG_ATTACKERSTATEUPDATE = 330                      '(0x14A)
    SMSG_VICTIMSTATEUPDATE_OBSOLETE = 331               '(0x14B)
    SMSG_DAMAGE_DONE_OBSOLETE = 332                     '(0x14C)
    SMSG_DAMAGE_TAKEN_OBSOLETE = 333                    '(0x14D)
    SMSG_CANCEL_COMBAT = 334                            '(0x14E)
    SMSG_PLAYER_COMBAT_XP_GAIN_OBSOLETE = 335           '(0x14F)
    SMSG_HEALSPELL_ON_PLAYER_OBSOLETE = 336             '(0x150)
    SMSG_HEALSPELL_ON_PLAYERS_PET_OBSOLETE = 337        '(0x151)
    CMSG_SHEATHE_OBSOLETE = 338                         '(0x152)
    CMSG_SAVE_PLAYER = 339                              '(0x153)
    CMSG_SETDEATHBINDPOINT = 340                        '(0x154)
    SMSG_BINDPOINTUPDATE = 341                          '(0x155)
    CMSG_GETDEATHBINDZONE = 342                         '(0x156)
    SMSG_BINDZONEREPLY = 343                            '(0x157)
    SMSG_PLAYERBOUND = 344                              '(0x158)
    SMSG_DEATH_NOTIFY_OBSOLETE = 345                    '(0x159)
    CMSG_REPOP_REQUEST = 346                            '(0x15A)
    SMSG_RESURRECT_REQUEST = 347                        '(0x15B)
    CMSG_RESURRECT_RESPONSE = 348                       '(0x15C)
    CMSG_LOOT = 349                                     '(0x15D)
    CMSG_LOOT_MONEY = 350                               '(0x15E)
    CMSG_LOOT_RELEASE = 351                             '(0x15F)
    SMSG_LOOT_RESPONSE = 352                            '(0x160)
    SMSG_LOOT_RELEASE_RESPONSE = 353                    '(0x161)
    SMSG_LOOT_REMOVED = 354                             '(0x162)
    SMSG_LOOT_MONEY_NOTIFY = 355                        '(0x163)
    SMSG_LOOT_ITEM_NOTIFY = 356                         '(0x164)
    SMSG_LOOT_CLEAR_MONEY = 357                         '(0x165)
    SMSG_ITEM_PUSH_RESULT = 358                         '(0x166)
    SMSG_DUEL_REQUESTED = 359                           '(0x167)
    SMSG_DUEL_OUTOFBOUNDS = 360                         '(0x168)
    SMSG_DUEL_INBOUNDS = 361                            '(0x169)
    SMSG_DUEL_COMPLETE = 362                            '(0x16A)
    SMSG_DUEL_WINNER = 363                              '(0x16B)
    CMSG_DUEL_ACCEPTED = 364                            '(0x16C)
    CMSG_DUEL_CANCELLED = 365                           '(0x16D)
    SMSG_MOUNTRESULT = 366                              '(0x16E)
    SMSG_DISMOUNTRESULT = 367                           '(0x16F)
    SMSG_PUREMOUNT_CANCELLED_OBSOLETE = 368             '(0x170)
    CMSG_MOUNTSPECIAL_ANIM = 369                        '(0x171)
    SMSG_MOUNTSPECIAL_ANIM = 370                        '(0x172)
    SMSG_PET_TAME_FAILURE = 371                         '(0x173)
    CMSG_PET_SET_ACTION = 372                           '(0x174)
    CMSG_PET_ACTION = 373                               '(0x175)
    CMSG_PET_ABANDON = 374                              '(0x176)
    CMSG_PET_RENAME = 375                               '(0x177)
    SMSG_PET_NAME_INVALID = 376                         '(0x178)
    SMSG_PET_SPELLS = 377                               '(0x179)
    SMSG_PET_MODE = 378                                 '(0x17A)
    CMSG_GOSSIP_HELLO = 379                             '(0x17B)
    CMSG_GOSSIP_SELECT_OPTION = 380                     '(0x17C)
    SMSG_GOSSIP_MESSAGE = 381                           '(0x17D)
    SMSG_GOSSIP_COMPLETE = 382                          '(0x17E)
    CMSG_NPC_TEXT_QUERY = 383                           '(0x17F)
    SMSG_NPC_TEXT_UPDATE = 384                          '(0x180)
    SMSG_NPC_WONT_TALK = 385                            '(0x181)
    CMSG_QUESTGIVER_STATUS_QUERY = 386                  '(0x182)
    SMSG_QUESTGIVER_STATUS = 387                        '(0x183)
    CMSG_QUESTGIVER_HELLO = 388                         '(0x184)
    SMSG_QUESTGIVER_QUEST_LIST = 389                    '(0x185)
    CMSG_QUESTGIVER_QUERY_QUEST = 390                   '(0x186)
    CMSG_QUESTGIVER_QUEST_AUTOLAUNCH = 391              '(0x187)
    SMSG_QUESTGIVER_QUEST_DETAILS = 392                 '(0x188)
    CMSG_QUESTGIVER_ACCEPT_QUEST = 393                  '(0x189)
    CMSG_QUESTGIVER_COMPLETE_QUEST = 394                '(0x18A)
    SMSG_QUESTGIVER_REQUEST_ITEMS = 395                 '(0x18B)
    CMSG_QUESTGIVER_REQUEST_REWARD = 396                '(0x18C)
    SMSG_QUESTGIVER_OFFER_REWARD = 397                  '(0x18D)
    CMSG_QUESTGIVER_CHOOSE_REWARD = 398                 '(0x18E)
    SMSG_QUESTGIVER_QUEST_INVALID = 399                 '(0x18F)
    CMSG_QUESTGIVER_CANCEL = 400                        '(0x190)
    SMSG_QUESTGIVER_QUEST_COMPLETE = 401                '(0x191)
    SMSG_QUESTGIVER_QUEST_FAILED = 402                  '(0x192)
    CMSG_QUESTLOG_SWAP_QUEST = 403                      '(0x193)
    CMSG_QUESTLOG_REMOVE_QUEST = 404                    '(0x194)
    SMSG_QUESTLOG_FULL = 405                            '(0x195)
    SMSG_QUESTUPDATE_FAILED = 406                       '(0x196)
    SMSG_QUESTUPDATE_FAILEDTIMER = 407                  '(0x197)
    SMSG_QUESTUPDATE_COMPLETE = 408                     '(0x198)
    SMSG_QUESTUPDATE_ADD_KILL = 409                     '(0x199)
    SMSG_QUESTUPDATE_ADD_ITEM = 410                     '(0x19A)
    CMSG_QUEST_CONFIRM_ACCEPT = 411                     '(0x19B)
    SMSG_QUEST_CONFIRM_ACCEPT = 412                     '(0x19C)
    CMSG_PUSHQUESTTOPARTY = 413                         '(0x19D)
    CMSG_LIST_INVENTORY = 414                           '(0x19E)
    SMSG_LIST_INVENTORY = 415                           '(0x19F)
    CMSG_SELL_ITEM = 416                                '(0x1A0)
    SMSG_SELL_ITEM = 417                                '(0x1A1)
    CMSG_BUY_ITEM = 418                                 '(0x1A2)
    CMSG_BUY_ITEM_IN_SLOT = 419                         '(0x1A3)
    SMSG_BUY_ITEM = 420                                 '(0x1A4)
    SMSG_BUY_FAILED = 421                               '(0x1A5)
    CMSG_TAXICLEARALLNODES = 422                        '(0x1A6)
    CMSG_TAXIENABLEALLNODES = 423                       '(0x1A7)
    CMSG_TAXISHOWNODES = 424                            '(0x1A8)
    SMSG_SHOWTAXINODES = 425                            '(0x1A9)
    CMSG_TAXINODE_STATUS_QUERY = 426                    '(0x1AA)
    SMSG_TAXINODE_STATUS = 427                          '(0x1AB)
    CMSG_TAXIQUERYAVAILABLENODES = 428                  '(0x1AC)
    CMSG_ACTIVATETAXI = 429                             '(0x1AD)
    SMSG_ACTIVATETAXIREPLY = 430                        '(0x1AE)
    SMSG_NEW_TAXI_PATH = 431                            '(0x1AF)
    CMSG_TRAINER_LIST = 432                             '(0x1B0)
    SMSG_TRAINER_LIST = 433                             '(0x1B1)
    CMSG_TRAINER_BUY_SPELL = 434                        '(0x1B2)
    SMSG_TRAINER_BUY_SUCCEEDED = 435                    '(0x1B3)
    SMSG_TRAINER_BUY_FAILED = 436                       '(0x1B4)
    CMSG_BINDER_ACTIVATE = 437                          '(0x1B5)
    SMSG_PLAYERBINDERROR = 438                          '(0x1B6)
    CMSG_BANKER_ACTIVATE = 439                          '(0x1B7)
    SMSG_SHOW_BANK = 440                                '(0x1B8)
    CMSG_BUY_BANK_SLOT = 441                            '(0x1B9)
    SMSG_BUY_BANK_SLOT_RESULT = 442                     '(0x1BA)
    CMSG_PETITION_SHOWLIST = 443                        '(0x1BB)
    SMSG_PETITION_SHOWLIST = 444                        '(0x1BC)
    CMSG_PETITION_BUY = 445                             '(0x1BD)
    CMSG_PETITION_SHOW_SIGNATURES = 446                 '(0x1BE)
    SMSG_PETITION_SHOW_SIGNATURES = 447                 '(0x1BF)
    CMSG_PETITION_SIGN = 448                            '(0x1C0)
    SMSG_PETITION_SIGN_RESULTS = 449                    '(0x1C1)
    MSG_PETITION_DECLINE = 450                          '(0x1C2)
    CMSG_OFFER_PETITION = 451                           '(0x1C3)
    CMSG_TURN_IN_PETITION = 452                         '(0x1C4)
    SMSG_TURN_IN_PETITION_RESULTS = 453                 '(0x1C5)
    CMSG_PETITION_QUERY = 454                           '(0x1C6)
    SMSG_PETITION_QUERY_RESPONSE = 455                  '(0x1C7)
    SMSG_FISH_NOT_HOOKED = 456                          '(0x1C8)
    SMSG_FISH_ESCAPED = 457                             '(0x1C9)
    CMSG_BUG = 458                                      '(0x1CA)
    SMSG_NOTIFICATION = 459                             '(0x1CB)
    CMSG_PLAYED_TIME = 460                              '(0x1CC)
    SMSG_PLAYED_TIME = 461                              '(0x1CD)
    CMSG_QUERY_TIME = 462                               '(0x1CE)
    SMSG_QUERY_TIME_RESPONSE = 463                      '(0x1CF)
    SMSG_LOG_XPGAIN = 464                               '(0x1D0)
    MSG_SPLIT_MONEY = 465                               '(0x1D1)
    CMSG_RECLAIM_CORPSE = 466                           '(0x1D2)
    CMSG_WRAP_ITEM = 467                                '(0x1D3)
    SMSG_LEVELUP_INFO = 468                             '(0x1D4)
    MSG_MINIMAP_PING = 469                              '(0x1D5)
    SMSG_RESISTLOG = 470                                '(0x1D6)
    SMSG_ENCHANTMENTLOG = 471                           '(0x1D7)
    CMSG_SET_SKILL_CHEAT = 472                          '(0x1D8)
    SMSG_START_MIRROR_TIMER = 473                       '(0x1D9)
    SMSG_PAUSE_MIRROR_TIMER = 474                       '(0x1DA)
    SMSG_STOP_MIRROR_TIMER = 475                        '(0x1DB)
    CMSG_PING = 476                                     '(0x1DC)
    SMSG_PONG = 477                                     '(0x1DD)
    SMSG_CLEAR_COOLDOWN = 478                           '(0x1DE)
    SMSG_GAMEOBJECT_PAGETEXT = 479                      '(0x1DF)
    CMSG_SETSHEATHED = 480                              '(0x1E0)
    SMSG_COOLDOWN_CHEAT = 481                           '(0x1E1)
    SMSG_SPELL_DELAYED = 482                            '(0x1E2)
    CMSG_PLAYER_MACRO_OBSOLETE = 483                    '(0x1E3)
    SMSG_PLAYER_MACRO_OBSOLETE = 484                    '(0x1E4)
    CMSG_GHOST = 485                                    '(0x1E5)
    CMSG_GM_INVIS = 486                                 '(0x1E6)
    SMSG_INVALID_PROMOTION_CODE = 487                   '(0x1E7)
    MSG_GM_BIND_OTHER = 488                             '(0x1E8)
    MSG_GM_SUMMON = 489                                 '(0x1E9)
    SMSG_ITEM_TIME_UPDATE = 490                         '(0x1EA)
    SMSG_ITEM_ENCHANT_TIME_UPDATE = 491                 '(0x1EB)
    SMSG_AUTH_CHALLENGE = 492                           '(0x1EC)
    CMSG_AUTH_SESSION = 493                             '(0x1ED)
    SMSG_AUTH_RESPONSE = 494                            '(0x1EE)
    MSG_GM_SHOWLABEL = 495                              '(0x1EF)
    MSG_ADD_DYNAMIC_TARGET_OBSOLETE = 496               '(0x1F0)
    MSG_SAVE_GUILD_EMBLEM = 497                         '(0x1F1)
    MSG_TABARDVENDOR_ACTIVATE = 498                     '(0x1F2)
    SMSG_PLAY_SPELL_VISUAL = 499                        '(0x1F3)
    CMSG_ZONEUPDATE = 500                               '(0x1F4)
    SMSG_PARTYKILLLOG = 501                             '(0x1F5)
    SMSG_COMPRESSED_UPDATE_OBJECT = 502                 '(0x1F6)
    SMSG_OBSOLETE = 503                                 '(0x1F7)
    SMSG_EXPLORATION_EXPERIENCE = 504                   '(0x1F8)
    CMSG_GM_SET_SECURITY_GROUP = 505                    '(0x1F9)
    CMSG_GM_NUKE = 506                                  '(0x1FA)
    MSG_RANDOM_ROLL = 507                               '(0x1FB)
    SMSG_ENVIRONMENTALDAMAGELOG = 508                   '(0x1FC)
    CMSG_RWHOIS = 509                                   '(0x1FD)
    SMSG_RWHOIS = 510                                   '(0x1FE)
    MSG_LOOKING_FOR_GROUP = 511                         '(0x1FF)
    CMSG_SET_LOOKING_FOR_GROUP = 512                    '(0x200)
    CMSG_UNLEARN_SPELL = 513                            '(0x201)
    CMSG_UNLEARN_SKILL = 514                            '(0x202)
    SMSG_REMOVED_SPELL = 515                            '(0x203)
    CMSG_DECHARGE = 516                                 '(0x204)
    CMSG_GMTICKET_CREATE = 517                          '(0x205)
    SMSG_GMTICKET_CREATE = 518                          '(0x206)
    CMSG_GMTICKET_UPDATETEXT = 519                      '(0x207)
    SMSG_GMTICKET_UPDATETEXT = 520                      '(0x208)
    SMSG_ACCOUNT_DATA_MD5 = 521                         '(0x209)
    CMSG_REQUEST_ACCOUNT_DATA = 522                     '(0x20A)
    CMSG_UPDATE_ACCOUNT_DATA = 523                      '(0x20B)
    SMSG_UPDATE_ACCOUNT_DATA = 524                      '(0x20C)
    SMSG_CLEAR_FAR_SIGHT_IMMEDIATE = 525                '(0x20D)
    SMSG_POWERGAINLOG_OBSOLETE = 526                    '(0x20E)
    CMSG_GM_TEACH = 527                                 '(0x20F)
    CMSG_GM_CREATE_ITEM_TARGET = 528                    '(0x210)
    CMSG_GMTICKET_GETTICKET = 529                       '(0x211)
    SMSG_GMTICKET_GETTICKET = 530                       '(0x212)
    CMSG_UNLEARN_TALENTS = 531                          '(0x213)
    SMSG_GAMEOBJECT_SPAWN_ANIM = 532                    '(0x214)
    SMSG_GAMEOBJECT_DESPAWN_ANIM = 533                  '(0x215)
    MSG_CORPSE_QUERY = 534                              '(0x216)
    CMSG_GMTICKET_DELETETICKET = 535                    '(0x217)
    SMSG_GMTICKET_DELETETICKET = 536                    '(0x218)
    SMSG_CHAT_WRONG_FACTION = 537                       '(0x219)
    CMSG_GMTICKET_SYSTEMSTATUS = 538                    '(0x21A)
    SMSG_GMTICKET_SYSTEMSTATUS = 539                    '(0x21B)
    CMSG_SPIRIT_HEALER_ACTIVATE = 540                   '(0x21C)
    CMSG_SET_STAT_CHEAT = 541                           '(0x21D)
    SMSG_SET_REST_START = 542                           '(0x21E)
    CMSG_SKILL_BUY_STEP = 543                           '(0x21F)
    CMSG_SKILL_BUY_RANK = 544                           '(0x220)
    CMSG_XP_CHEAT = 545                                 '(0x221)
    SMSG_SPIRIT_HEALER_CONFIRM = 546                    '(0x222)
    CMSG_CHARACTER_POINT_CHEAT = 547                    '(0x223)
    SMSG_GOSSIP_POI = 548                               '(0x224)
    CMSG_CHAT_IGNORED = 549                             '(0x225)
    CMSG_GM_VISION = 550                                '(0x226)
    CMSG_SERVER_COMMAND = 551                           '(0x227)
    CMSG_GM_SILENCE = 552                               '(0x228)
    CMSG_GM_REVEALTO = 553                              '(0x229)
    CMSG_GM_RESURRECT = 554                             '(0x22A)
    CMSG_GM_SUMMONMOB = 555                             '(0x22B)
    CMSG_GM_MOVECORPSE = 556                            '(0x22C)
    CMSG_GM_FREEZE = 557                                '(0x22D)
    CMSG_GM_UBERINVIS = 558                             '(0x22E)
    CMSG_GM_REQUEST_PLAYER_INFO = 559                   '(0x22F)
    SMSG_GM_PLAYER_INFO = 560                           '(0x230)
    CMSG_GUILD_RANK = 561                               '(0x231)
    CMSG_GUILD_ADD_RANK = 562                           '(0x232)
    CMSG_GUILD_DEL_RANK = 563                           '(0x233)
    CMSG_GUILD_SET_PUBLIC_NOTE = 564                    '(0x234)
    CMSG_GUILD_SET_OFFICER_NOTE = 565                   '(0x235)
    SMSG_LOGIN_VERIFY_WORLD = 566                       '(0x236)
    CMSG_CLEAR_EXPLORATION = 567                        '(0x237)
    CMSG_SEND_MAIL = 568                                '(0x238)
    SMSG_SEND_MAIL_RESULT = 569                         '(0x239)
    CMSG_GET_MAIL_LIST = 570                            '(0x23A)
    SMSG_MAIL_LIST_RESULT = 571                         '(0x23B)
    CMSG_BATTLEFIELD_LIST = 572                         '(0x23C)
    SMSG_BATTLEFIELD_LIST = 573                         '(0x23D)
    CMSG_BATTLEFIELD_JOIN = 574                         '(0x23E)
    SMSG_BATTLEFIELD_WIN = 575                          '(0x23F)
    SMSG_BATTLEFIELD_LOSE = 576                         '(0x240)
    CMSG_TAXICLEARNODE = 577                            '(0x241)
    CMSG_TAXIENABLENODE = 578                           '(0x242)
    CMSG_ITEM_TEXT_QUERY = 579                          '(0x243)
    SMSG_ITEM_TEXT_QUERY_RESPONSE = 580                 '(0x244)
    CMSG_MAIL_TAKE_MONEY = 581                          '(0x245)
    CMSG_MAIL_TAKE_ITEM = 582                           '(0x246)
    CMSG_MAIL_MARK_AS_READ = 583                        '(0x247)
    CMSG_MAIL_RETURN_TO_SENDER = 584                    '(0x248)
    CMSG_MAIL_DELETE = 585                              '(0x249)
    CMSG_MAIL_CREATE_TEXT_ITEM = 586                    '(0x24A)
    SMSG_SPELLLOGMISS = 587                             '(0x24B)
    SMSG_SPELLLOGEXECUTE = 588                          '(0x24C)
    SMSG_DEBUGAURAPROC = 589                            '(0x24D)
    SMSG_PERIODICAURALOG = 590                          '(0x24E)
    SMSG_SPELLDAMAGESHIELD = 591                        '(0x24F)
    SMSG_SPELLNONMELEEDAMAGELOG = 592                   '(0x250)
    CMSG_LEARN_TALENT = 593                             '(0x251)
    SMSG_RESURRECT_FAILED = 594                         '(0x252)
    CMSG_TOGGLE_PVP = 595                               '(0x253)
    SMSG_ZONE_UNDER_ATTACK = 596                        '(0x254)
    MSG_AUCTION_HELLO = 597                             '(0x255)
    CMSG_AUCTION_SELL_ITEM = 598                        '(0x256)
    CMSG_AUCTION_REMOVE_ITEM = 599                      '(0x257)
    CMSG_AUCTION_LIST_ITEMS = 600                       '(0x258)
    CMSG_AUCTION_LIST_OWNER_ITEMS = 601                 '(0x259)
    CMSG_AUCTION_PLACE_BID = 602                        '(0x25A)
    SMSG_AUCTION_COMMAND_RESULT = 603                   '(0x25B)
    SMSG_AUCTION_LIST_RESULT = 604                      '(0x25C)
    SMSG_AUCTION_OWNER_LIST_RESULT = 605                '(0x25D)
    SMSG_AUCTION_BIDDER_NOTIFICATION = 606              '(0x25E)
    SMSG_AUCTION_OWNER_NOTIFICATION = 607               '(0x25F)
    SMSG_PROCRESIST = 608                               '(0x260)
    SMSG_STANDSTATE_CHANGE_FAILURE = 609                '(0x261)
    SMSG_DISPEL_FAILED = 610                            '(0x262)
    SMSG_SPELLORDAMAGE_IMMUNE = 611                     '(0x263)
    CMSG_AUCTION_LIST_BIDDER_ITEMS = 612                '(0x264)
    SMSG_AUCTION_BIDDER_LIST_RESULT = 613               '(0x265)
    SMSG_SET_FLAT_SPELL_MODIFIER = 614                  '(0x266)
    SMSG_SET_PCT_SPELL_MODIFIER = 615                   '(0x267)
    CMSG_SET_AMMO = 616                                 '(0x268)
    SMSG_CORPSE_RECLAIM_DELAY = 617                     '(0x269)
    CMSG_SET_ACTIVE_MOVER = 618                         '(0x26A)
    CMSG_PET_CANCEL_AURA = 619                          '(0x26B)
    CMSG_PLAYER_AI_CHEAT = 620                          '(0x26C)
    CMSG_CANCEL_AUTO_REPEAT_SPELL = 621                 '(0x26D)
    MSG_GM_ACCOUNT_ONLINE = 622                         '(0x26E)
    MSG_LIST_STABLED_PETS = 623                         '(0x26F)
    CMSG_STABLE_PET = 624                               '(0x270)
    CMSG_UNSTABLE_PET = 625                             '(0x271)
    CMSG_BUY_STABLE_SLOT = 626                          '(0x272)
    SMSG_STABLE_RESULT = 627                            '(0x273)
    CMSG_STABLE_REVIVE_PET = 628                        '(0x274)
    CMSG_STABLE_SWAP_PET = 629                          '(0x275)
    MSG_QUEST_PUSH_RESULT = 630                         '(0x276)
    SMSG_PLAY_MUSIC = 631                               '(0x277)
    SMSG_PLAY_OBJECT_SOUND = 632                        '(0x278)
    CMSG_REQUEST_PET_INFO = 633                         '(0x279)
    CMSG_FAR_SIGHT = 634                                '(0x27A)
    SMSG_SPELLDISPELLOG = 635                           '(0x27B)
    SMSG_DAMAGE_CALC_LOG = 636                          '(0x27C)
    CMSG_ENABLE_DAMAGE_LOG = 637                        '(0x27D)
    CMSG_GROUP_CHANGE_SUB_GROUP = 638                   '(0x27E)
    CMSG_REQUEST_PARTY_MEMBER_STATS = 639               '(0x27F)
    CMSG_GROUP_SWAP_SUB_GROUP = 640                     '(0x280)
    CMSG_RESET_FACTION_CHEAT = 641                      '(0x281)
    CMSG_AUTOSTORE_BANK_ITEM = 642                      '(0x282)
    CMSG_AUTOBANK_ITEM = 643                            '(0x283)
    MSG_QUERY_NEXT_MAIL_TIME = 644                      '(0x284)
    SMSG_RECEIVED_MAIL = 645                            '(0x285)
    SMSG_RAID_GROUP_ONLY = 646                          '(0x286)
    CMSG_SET_DURABILITY_CHEAT = 647                     '(0x287)
    CMSG_SET_PVP_RANK_CHEAT = 648                       '(0x288)
    CMSG_ADD_PVP_MEDAL_CHEAT = 649                      '(0x289)
    CMSG_DEL_PVP_MEDAL_CHEAT = 650                      '(0x28A)
    CMSG_SET_PVP_TITLE = 651                            '(0x28B)
    SMSG_PVP_CREDIT = 652                               '(0x28C)
    SMSG_AUCTION_REMOVED_NOTIFICATION = 653             '(0x28D)
    CMSG_GROUP_RAID_CONVERT = 654                       '(0x28E)
    CMSG_GROUP_ASSISTANT_LEADER = 655                   '(0x28F)
    CMSG_BUYBACK_ITEM = 656                             '(0x290)
    SMSG_SERVER_MESSAGE = 657                           '(0x291)
    CMSG_MEETINGSTONE_JOIN = 658                        '(0x292)
    CMSG_MEETINGSTONE_LEAVE = 659                       '(0x293)
    CMSG_MEETINGSTONE_CHEAT = 660                       '(0x294)
    SMSG_MEETINGSTONE_SETQUEUE = 661                    '(0x295)
    CMSG_MEETINGSTONE_INFO = 662                        '(0x296)
    SMSG_MEETINGSTONE_COMPLETE = 663                    '(0x297)
    SMSG_MEETINGSTONE_IN_PROGRESS = 664                 '(0x298)
    SMSG_MEETINGSTONE_MEMBER_ADDED = 665                '(0x299)
    CMSG_GMTICKETSYSTEM_TOGGLE = 666                    '(0x29A)
    CMSG_CANCEL_GROWTH_AURA = 667                       '(0x29B)
    SMSG_CANCEL_AUTO_REPEAT = 668                       '(0x29C)
    SMSG_STANDSTATE_CHANGE_ACK = 669                    '(0x29D)
    SMSG_LOOT_ALL_PASSED = 670                          '(0x29E)
    SMSG_LOOT_ROLL_WON = 671                            '(0x29F)
    CMSG_LOOT_ROLL = 672                                '(0x2A0)
    SMSG_LOOT_START_ROLL = 673                          '(0x2A1)
    SMSG_LOOT_ROLL = 674                                '(0x2A2)
    CMSG_LOOT_MASTER_GIVE = 675                         '(0x2A3)
    SMSG_LOOT_MASTER_LIST = 676                         '(0x2A4)
    SMSG_SET_FORCED_REACTIONS = 677                     '(0x2A5)
    SMSG_SPELL_FAILED_OTHER = 678                       '(0x2A6)
    SMSG_GAMEOBJECT_RESET_STATE = 679                   '(0x2A7)
    CMSG_REPAIR_ITEM = 680                              '(0x2A8)
    SMSG_CHAT_PLAYER_NOT_FOUND = 681                    '(0x2A9)
    MSG_TALENT_WIPE_CONFIRM = 682                       '(0x2AA)
    SMSG_SUMMON_REQUEST = 683                           '(0x2AB)
    CMSG_SUMMON_RESPONSE = 684                          '(0x2AC)
    MSG_MOVE_TOGGLE_GRAVITY_CHEAT = 685                 '(0x2AD)
    SMSG_MONSTER_MOVE_TRANSPORT = 686                   '(0x2AE)
    SMSG_PET_BROKEN = 687                               '(0x2AF)
    MSG_MOVE_FEATHER_FALL = 688                         '(0x2B0)
    MSG_MOVE_WATER_WALK = 689                           '(0x2B1)
    CMSG_SERVER_BROADCAST = 690                         '(0x2B2)
    CMSG_SELF_RES = 691                                 '(0x2B3)
    SMSG_FEIGN_DEATH_RESISTED = 692                     '(0x2B4)
    CMSG_RUN_SCRIPT = 693                               '(0x2B5)
    SMSG_SCRIPT_MESSAGE = 694                           '(0x2B6)
    SMSG_DUEL_COUNTDOWN = 695                           '(0x2B7)
    SMSG_AREA_TRIGGER_MESSAGE = 696                     '(0x2B8)
    CMSG_TOGGLE_HELM = 697                              '(0x2B9)
    CMSG_TOGGLE_CLOAK = 698                             '(0x2BA)
    SMSG_MEETINGSTONE_JOINFAILED = 699                  '(0x2BB)
    SMSG_PLAYER_SKINNED = 700                           '(0x2BC)
    SMSG_DURABILITY_DAMAGE_DEATH = 701                  '(0x2BD)
    CMSG_SET_EXPLORATION = 702                          '(0x2BE)
    CMSG_SET_ACTIONBAR_TOGGLES = 703                    '(0x2BF)
    UMSG_DELETE_GUILD_CHARTER = 704                     '(0x2C0)
    MSG_PETITION_RENAME = 705                           '(0x2C1)
    SMSG_INIT_WORLD_STATES = 706                        '(0x2C2)
    SMSG_UPDATE_WORLD_STATE = 707                       '(0x2C3)
    CMSG_ITEM_NAME_QUERY = 708                          '(0x2C4)
    SMSG_ITEM_NAME_QUERY_RESPONSE = 709                 '(0x2C5)
    SMSG_PET_ACTION_FEEDBACK = 710                      '(0x2C6)
    CMSG_CHAR_RENAME = 711                              '(0x2C7)
    SMSG_CHAR_RENAME = 712                              '(0x2C8)
    CMSG_MOVE_SPLINE_DONE = 713                         '(0x2C9)
    CMSG_MOVE_FALL_RESET = 714                          '(0x2CA)
    SMSG_INSTANCE_SAVE_CREATED = 715                    '(0x2CB)
    SMSG_RAID_INSTANCE_INFO = 716                       '(0x2CC)
    CMSG_REQUEST_RAID_INFO = 717                        '(0x2CD)
    CMSG_MOVE_TIME_SKIPPED = 718                        '(0x2CE)
    CMSG_MOVE_FEATHER_FALL_ACK = 719                    '(0x2CF)
    CMSG_MOVE_WATER_WALK_ACK = 720                      '(0x2D0)
    CMSG_MOVE_NOT_ACTIVE_MOVER = 721                    '(0x2D1)
    SMSG_PLAY_SOUND = 722                               '(0x2D2)
    CMSG_BATTLEFIELD_STATUS = 723                       '(0x2D3)
    SMSG_BATTLEFIELD_STATUS = 724                       '(0x2D4)
    CMSG_BATTLEFIELD_PORT = 725                         '(0x2D5)
    MSG_INSPECT_HONOR_STATS = 726                       '(0x2D6)
    CMSG_BATTLEMASTER_HELLO = 727                       '(0x2D7)
    CMSG_MOVE_START_SWIM_CHEAT = 728                    '(0x2D8)
    CMSG_MOVE_STOP_SWIM_CHEAT = 729                     '(0x2D9)
    SMSG_FORCE_WALK_SPEED_CHANGE = 730                  '(0x2DA)
    CMSG_FORCE_WALK_SPEED_CHANGE_ACK = 731              '(0x2DB)
    SMSG_FORCE_SWIM_BACK_SPEED_CHANGE = 732             '(0x2DC)
    CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK = 733         '(0x2DD)
    SMSG_FORCE_TURN_RATE_CHANGE = 734                   '(0x2DE)
    CMSG_FORCE_TURN_RATE_CHANGE_ACK = 735               '(0x2DF)
    MSG_PVP_LOG_DATA = 736                              '(0x2E0)
    CMSG_LEAVE_BATTLEFIELD = 737                        '(0x2E1)
    CMSG_AREA_SPIRIT_HEALER_QUERY = 738                 '(0x2E2)
    CMSG_AREA_SPIRIT_HEALER_QUEUE = 739                 '(0x2E3)
    SMSG_AREA_SPIRIT_HEALER_TIME = 740                  '(0x2E4)
    CMSG_GM_UNTEACH = 741                               '(0x2E5)
    SMSG_WARDEN_DATA = 742                              '(0x2E6)
    CMSG_WARDEN_DATA = 743                              '(0x2E7)
    SMSG_GROUP_JOINED_BATTLEGROUND = 744                '(0x2E8)
    MSG_BATTLEGROUND_PLAYER_POSITIONS = 745             '(0x2E9)
    CMSG_PET_STOP_ATTACK = 746                          '(0x2EA)
    SMSG_BINDER_CONFIRM = 747                           '(0x2EB)
    SMSG_BATTLEGROUND_PLAYER_JOINED = 748               '(0x2EC)
    SMSG_BATTLEGROUND_PLAYER_LEFT = 749                 '(0x2ED)
    CMSG_BATTLEMASTER_JOIN = 750                        '(0x2EF)
    SMSG_ADDON_INFO = 751                               '(0x2EF)
    CMSG_PET_UNLEARN = 754                              '(0x2F2)
    SMSG_PET_UNLEARN_CONFIRM = 755                      '(0x2F3)
    SMSG_WEATHER = 756                                  '(0x2F4)
    CMSG_PET_SPELL_AUTOCAST = 757                       '(0x2F5)
    SMSG_PARTY_MEMBER_STATS_FULL = 758                  '(0x2F6)
    SMSG_PLAY_TIME_WARNING = 759                        '(0x2F7)
    SMSG_MINIGAME_SETUP = 758                           '(0x2F6)
    SMSG_MINIGAME_STATE = 759                           '(0x2F7)
    CMSG_MINIGAME_MOVE = 760                            '(0x2F8)
    SMSG_MINIGAME_MOVE_FAILED = 761                     '(0x2F9)
    SMSG_PET_TAME_UNK = 763                             '(0x2FB)
    CMSG_SET_GUILD_INFORMATION = 764                    '(0x2FC)

    SMSG_ACTIVATETAXI_FAR = 768                         '(0x300)
    SMSG_UNKNOWN_PET = 772                              '(0x304)
    CMSG_SET_FACTION_INACTIVE = 791                     '(0x317)
    CMSG_SET_WATCHED_FACTION_INDEX = 792                '(0x318)
    CMSG_UNKNOWN_1 = 793                                '(0x319)
    SMSG_UNKNOWN_DEMON = 794                            '(0x31A)
    CMSG_RESET_INTANCES = 797                           '(0x31D)
    MSG_GROUP_SET_PLAYER_ICON = 801                     '(0x321)
    MSG_RAID_READYCHECK = 802                           '(0x322)

    MSG_GROUP_SET_DIFFICULTY = 809                      '(0x329)
    SMSG_GAMEOFTOWERS_CAPTURED = 826                    '(0x33A)
    SMSG_OUTDOOR_NOTIFY = 827                           '(0x33B)
    SMSG_SYSTEM_MESSAGE = 829                           '(0x33D)
    SMSG_FLYMOUNT_TAKEOFF = 835                         '(0x343)
    SMSG_FLYMOUNT_LAND = 836                            '(0x344)
    CMSG_FLYMOUNT_ACK = 837                             '(0x345)
    MSG_MOVE_FLY_MODE = 838                             '(0x346)
    MSG_MOVE_START_FLY = 857                            '(0x359)
    MSG_MOVE_STOP_FLY = 858                             '(0x35A)
    CMSG_SET_LOOKING_FOR_GROUP_AUTOJOIN = 860           '(0x35C)
    CMSG_UNSET_LOOKING_FOR_GROUP_AUTOJOIN = 861         '(0x35D)
    CMSG_SET_LOOKING_FOR_GROUP_AUTOADD = 862            '(0x35E)
    CMSG_UNSET_LOOKING_FOR_GROUP_AUTOADD = 863          '(0x35F)
    CMSG_LOOKING_FOR_GROUP_RESET = 867                  '(0x363)
    MSG_LOOKING_FOR_GROUP_COMMENT = 870                 '(0x366)
    CMSG_SET_PLAYER_TITLE = 884                         '(0x374)
    CMSG_CANCEL_TEMPORARY_ENCHANTMENT = 889             '(0x379)
    MSG_MOVE_SET_FLY_SPEED = 894                        '(0x37E)
    MSG_MOVE_SET_FLY_BACK_SPEED = 895                   '(0x37F)
    SMSG_FORCE_FLY_SPEED_CHANGE = 897                   '(0x381)
    CMSG_FORCE_FLY_SPEED_CHANGE_ACK = 898               '(0x382)
    SMSG_FORCE_FLY_BACK_SPEED_CHANGE = 899              '(0x383)
    CMSG_FORCE_FLY_BACK_SPEED_CHANGE_ACK = 900          '(0x384)

    SMSG_FLIGHT_SPLINE_SYNC = 904                       '(0x388) 
    SMSG_EXPANSION_INFO = 907                           '(0x38B)
    CMSG_EXPANSION_INFO = 908                           '(0x38C)
    CMSG_GROUP_SET_MAIN = 910                           '(0x38E)
    SMSG_MOVE_ENABLE = 912                              '(0x390)
    CMSG_MOVE_ENABLE_ACK = 913                          '(0x391)



End Enum
Enum AuthResponseCodes
    RESPONSE_SUCCESS = &H0                    'Success
    RESPONSE_FAILURE = &H1                    'Failure
    RESPONSE_CANCELLED = &H2                  'Cancelled
    RESPONSE_DISCONNECTED = &H3               'Disconnected from server
    RESPONSE_FAILED_TO_CONNECT = &H4          'Failed to connect
    RESPONSE_CONNECTED = &H5                  'Connected
    RESPONSE_VERSION_MISMATCH = &H6           'Wrong client version

    CSTATUS_CONNECTING = &H7                  'Connecting to server...
    CSTATUS_NEGOTIATING_SECURITY = &H8        'Negotiating Security
    CSTATUS_NEGOTIATION_COMPLETE = &H9        'Security negotiation complete
    CSTATUS_NEGOTIATION_FAILED = &HA          'Security negotiation failed
    CSTATUS_AUTHENTICATING = &HB              'Authenticating

    AUTH_OK = &HC                             'Authentication successful
    AUTH_FAILED = &HD                         'Authentication failed
    AUTH_REJECT = &HE                         'Rejected - please contact customer support
    AUTH_BAD_SERVER_PROOF = &HF               'Server is not valid
    AUTH_UNAVAILABLE = &H10                   'System unavailable - please try again later
    AUTH_SYSTEM_ERROR = &H11                  'System error
    AUTH_BILLING_ERROR = &H12                 'Billing system error
    AUTH_BILLING_EXPIRED = &H13               'Account billing has expired
    AUTH_VERSION_MISMATCH = &H14              'Wrong client version
    AUTH_UNKNOWN_ACCOUNT = &H15               'Unknown account
    AUTH_INCORRECT_PASSWORD = &H16            'Incorrect password
    AUTH_SESSION_EXPIRED = &H17               'Session expired
    AUTH_SERVER_SHUTTING_DOWN = &H18          'Server shutting down
    AUTH_ALREADY_LOGGING_IN = &H19            'Already logging in
    AUTH_LOGIN_SERVER_NOT_FOUND = &H1A        'Invalid login server
    AUTH_WAIT_QUEUE = &H1B                    'Position in queue -  (number)

    '&H1C, &H1D, &H1E, &H1F, &H20, &H21 - converted into nums &H1C -> "28"
    '	 AUTH_RETRIEVING_REALMLIST = 28		    'Retrieving realm list
    '	 AUTH_REALMLIST_RETRIEVED = 29			    'Realm list retrieved
    '	 AUTH_UNABLE_CONTACT_REALMLISTSERV = 30	'Unable to contact realm list server
    '	 AUTH_INVALID_REALMLIST = 31			    'Invalid realm list
    '	 AUTH_REALM_IS_DOWN = 32				    'Realm is down
    '	 AUTH_CREATING_ACCOUNT = 33			    'Creating account

    REALM_LIST_IN_PROGRESS = &H22             'Retrieving character list
    REALM_LIST_SUCCESS = &H23                 'Character list retrieved
    REALM_LIST_FAILED = &H24                  'Error retrieving character list
    REALM_LIST_INVALID = &H25                 'Invalid realm list
    REALM_LIST_REALM_NOT_FOUND = &H26         'Realm is down

    'Others are  converted into nums (&H27 -> "39")
    '	 AUTH_CREATING_CHAR = 39               'Creating character
    '	 AUTH_CHAR_CREATE_SUCCESS = 40         'Create success
    '	 AUTH_ERR_CREATING_CHAR = 41           'Error creating character
    '	 AUTH_CHAR_CREATION_FAILED = 42        'Character creation failed
    '	 AUTH_CHAR_NAME_IN_USE = 43            'Name already in use
    '	 AUTH_RACE_CLASS_DISABLED = 44         'Creation of that race and/or class is currently disabled
    '	 AUTH_DELETING_CHAR = 45               'Deleting character
    '	 AUTH_CHAR_DELETED = 46                'Character deleted
    '	 AUTH_CHAR_DELETION_FAILED = 47        'Character deletion failed
    '	 AUTH_ENTERING_THE_WOW = 48            'Entering the World of Warcraft
    '	 AUTH_LOGIN_SUCCESS = 49               'Login successful
    '	 AUTH_WORLD_SERVER_DOWN = 50           'World server is down
    '	 AUTH_CHAR_WITH_THAT_NAME_ALREADY = 51 'A character with that name already exists
    '	 AUTH_NO_INSTANCE_SERVERS = 52         'No instance servers are available
    '	 AUTH_LOGIN_FAILED = 53                'Login failed
    '	 AUTH_LOGIN_RACE_CLASS_DISABLED = 54   'Login for that race and/or class is currently disabled
    '	 AUTH_ENTER_CHAR_NAME = 55             'Enter a name for your character
    '	 AUTH_NAME_MUST_BE_AT_LEAST_3 = 56     'Name must be at least 3 characters
    '	 AUTH_NAMES_NO_MORE_THAN_12 = 57       'Names must be no more than 12 characters
    '	 AUTH_NAME_MUST_START_WITH_LETTER = 58 'Name must start with a letter
    '	 AUTH_CAN_HAVE_1_GRAVE = 59            'Names can only have one grave (`)
    '	 AUTH_NAMES_CONTAIN_ONLY_LETTERS = 60  'Names can only contain letters and one grave (`)
    '	 AUTH_NAMES_ONLY_IN_ONE_LANGUAGE = 61  'Names must contain only one language
    '	 AUTH_NAME_CONTAINS_PROFANITY = 62     'That name contains profanity
    '	 AUTH_NAME_RESERVED = 63               'That name is reserved
    '	 AUTH_INVALID_CHAR_NAME = 64			' Invalid character name
End Enum

#Region "Player.Enums"
Enum CharCreate As Byte
    CHAR_RENAME_OK = 0

    CHAR_CREATE_CREATING_CHARACTER = &H2D
    CHAR_CREATE_OK = &H2E
    CHAR_CREATE_ERROR = &H2F
    CHAR_CREATE_FAILED = &H30
    CHAR_CREATE_NAME_IN_USE = &H31
    CHAR_CREATE_RACE_CLASS_DISABLED = &H32
    CHAR_CREATE_BOTH_HORDE_ALIANCE = &H33
    CHAR_CREATE_MAX_CHARACTERS_ON_THIS_REALM = &H34
    CHAR_CREATE_MAX_CHARACTERS_ON_THIS_ACCOUNT = &H35
    CHAR_CREATE_CREATION_DISABLED = &H36
    CHAR_CREATE_ONLY_EXISTING_CHARACTERS = &H37
    CHAR_CREATE_EXPANSION_REQUIRED = &H38

    CHAR_DELETE_DELETING = &H39
    CHAR_DELETE_OK = &H3A
    CHAR_DELETE_FAIL = &H3B
    CHAR_DELETE_LOCKED_TRANSFERRING = &H3C
End Enum
Public Enum Classes As Byte
    CLASS_WARRIOR = 1
    CLASS_PALADIN = 2
    CLASS_HUNTER = 3
    CLASS_ROGUE = 4
    CLASS_PRIEST = 5
    CLASS_SHAMAN = 7
    CLASS_MAGE = 8
    CLASS_WARLOCK = 9
    CLASS_DRUID = 11
End Enum
Public Enum Races As Byte
    RACE_HUMAN = 1
    RACE_ORC = 2
    RACE_DWARF = 3
    RACE_NIGHT_ELF = 4
    RACE_UNDEAD = 5
    RACE_TAUREN = 6
    RACE_GNOME = 7
    RACE_TROLL = 8
    RACE_GOBLIN = 9
    RACE_BLOOD_ELF = 10
    RACE_DRAENEI = 11
End Enum
Enum FriendsResult As Byte
    FRIEND_DB_ERROR = &H0
    FRIEND_LIST_FULL = &H1
    FRIEND_ONLINE = &H2
    FRIEND_OFFLINE = &H3
    FRIEND_NOT_FOUND = &H4
    FRIEND_REMOVED = &H5
    FRIEND_ADDED_ONLINE = &H6
    FRIEND_ADDED_OFFLINE = &H7
    FRIEND_ALREADY = &H8
    FRIEND_SELF = &H9
    FRIEND_ENEMY = &HA
    FRIEND_IGNORE_FULL = &HB
    FRIEND_IGNORE_SELF = &HC
    FRIEND_IGNORE_NOT_FOUND = &HD
    FRIEND_IGNORE_ALREADY = &HE
    FRIEND_IGNORE_ADDED = &HF
    FRIEND_IGNORE_REMOVED = &H10
End Enum
Public Enum PlayerFlag As Byte
    'WARNING: For use with SetFlag
    PLAYER_FLAG_GROUP_LEADER = 0
    PLAYER_FLAG_AFK = 1
    PLAYER_FLAG_DND = 2
    PLAYER_FLAG_GM = 3
    PLAYER_FLAG_DEAD = 4
    PLAYER_FLAG_RESTING = 5
    'PLAYER_FLAG_UNK_2 = 6
    PLAYER_FLAG_DUEL = 7
    PLAYER_FLAG_IN_PVP = 8
    PLAYER_FLAG_HIDE_HELM = 9
    PLAYER_FLAG_HIDE_CLOAK = 10
    PLAYER_FLAG_LONG_TIME = 11                 'played long time
    PLAYER_FLAG_LONG_TIME2 = 12                'played too long time
End Enum
Public Enum PlayerFlags As Integer
    PLAYER_FLAG_GROUP_LEADER = &H1
    PLAYER_FLAG_AFK = &H2
    PLAYER_FLAG_DND = &H4
    PLAYER_FLAG_GM = &H8
    PLAYER_FLAG_DEAD = &H10
    PLAYER_FLAG_RESTING = &H20
    'PLAYER_FLAG_UNK_2 = &H40
    PLAYER_FLAG_DUEL = &H80
    PLAYER_FLAG_IN_PVP = &H200
    PLAYER_FLAG_HIDE_HELM = &H400
    PLAYER_FLAG_HIDE_CLOAK = &H800
    PLAYER_FLAG_LONG_TIME = &H1000                 'played long time
    PLAYER_FLAG_LONG_TIME2 = &H2000                'played too long time
End Enum
Public Enum PlayerHonorTitle As Byte
    'WARNING: For use with SetFlag
    RANK_NONE = 0
    RANK_A_RIVATE = 1
    RANK_H_SCOUT = 1
    RANK_A_CORPORAL = 2
    RANK_H_GRUNT = 2
    RANK_A_SERGEANT = 3
    RANK_H_SERGEANT = 3
    RANK_A_MASTER_SERGEANT = 4
    RANK_H_SENIOR_SERGEANT = 4
    RANK_A_SERGEANT_MAJOR = 5
    RANK_H_FIRST_SERGEANT = 5
    RANK_A_KNIGHT = 6
    RANK_H_STONE_GUARD = 6
    RANK_A_KNIGHT_LIEUTENANT = 7
    RANK_H_BLOOD_GUARD = 7
    RANK_A_KNIGHT_CAPTAIN = 8
    RANK_H_LEGIONNAIRE = 8
    RANK_A_KNIGHT_CHAMPION = 9
    RANK_H_CENTURION = 9
    RANK_A_LIEUTENANT = 10
    RANK_H_COMMANDER_CHAMPION = 10
    RANK_A_COMMANDER = 11
    RANK_H_LIEUTENANT_GENERAL = 11
    RANK_A_MARSHAL = 12
    RANK_H_GENERAL = 12
    RANK_A_FIELD_MARSHAL = 13
    RANK_H_WARLORD = 13
    RANK_A_GRAND_MARSHAL = 14
    RANK_H_HIGH_WARLORD = 14
End Enum
Public Enum PlayerHonorTitles As Integer
    'WARNING: For use as BitMask
    RANK_NONE = 1
    RANK_A_PRIVATE = 2
    RANK_H_SCOUT = 2
    RANK_A_CORPORAL = 4 + RANK_A_PRIVATE
    RANK_H_GRUNT = 4 + RANK_H_SCOUT
    RANK_A_SERGEANT = 8 + RANK_A_CORPORAL
    RANK_H_SERGEANT = 8 + RANK_H_GRUNT
    RANK_A_MASTER_SERGEANT = 16 + RANK_A_SERGEANT
    RANK_H_SENIOR_SERGEANT = 16 + RANK_H_SERGEANT
    RANK_A_SERGEANT_MAJOR = 32 + RANK_A_MASTER_SERGEANT
    RANK_H_FIRST_SERGEANT = 32 + RANK_H_SENIOR_SERGEANT
    RANK_A_KNIGHT = 64 + RANK_A_SERGEANT_MAJOR
    RANK_H_STONE_GUARD = 64 + RANK_H_FIRST_SERGEANT
    RANK_A_KNIGHT_LIEUTENANT = 128 + RANK_A_KNIGHT
    RANK_H_BLOOD_GUARD = 128 + RANK_H_STONE_GUARD
    RANK_A_KNIGHT_CAPTAIN = 256 + RANK_A_KNIGHT_LIEUTENANT
    RANK_H_LEGIONNAIRE = 256 + RANK_H_BLOOD_GUARD
    RANK_A_KNIGHT_CHAMPION = 512 + RANK_A_KNIGHT_CAPTAIN
    RANK_H_CENTURION = 512 + RANK_H_LEGIONNAIRE
    RANK_A_LIEUTENANT = 1024 + RANK_A_KNIGHT_CHAMPION
    RANK_H_COMMANDER_CHAMPION = 1024 + RANK_H_CENTURION
    RANK_A_COMMANDER = 2048 + RANK_A_LIEUTENANT
    RANK_H_LIEUTENANT_GENERAL = 2048 + RANK_H_COMMANDER_CHAMPION
    RANK_A_MARSHAL = 4096 + RANK_A_COMMANDER
    RANK_H_GENERAL = 4096 + RANK_H_LIEUTENANT_GENERAL
    RANK_A_FIELD_MARSHAL = 8192 + RANK_A_MARSHAL
    RANK_H_WARLORD = 8192 + RANK_H_GENERAL
    RANK_A_GRAND_MARSHAL = 16384 + RANK_A_FIELD_MARSHAL
    RANK_H_HIGH_WARLORD = 16384 + RANK_H_WARLORD
End Enum

Public Enum DamageType As Byte
    DMG_PHYSICAL = 0
    DMG_HOLY = 1
    DMG_FIRE = 2
    DMG_NATURE = 3
    DMG_FROST = 4
    DMG_SHADOW = 5
    DMG_ARCANE = 6
End Enum
Public Enum StandState As Byte
    STANDSTATE_STAND = 0
    STANDSTATE_SIT = 1
    STANDSTATE_SIT_CHAIR = 2
    STANDSTATE_SLEEP = 3
    STANDSTATE_SIT_LOW_CHAIR = 4
    STANDSTATE_SIT_MEDIUM_CHAIR = 5
    STANDSTATE_SIT_HIGH_CHAIR = 6
    STANDSTATE_DEAD = 7
    STANDSTATE_KNEEL = 8
End Enum
Public Enum HonorRank As Byte
    NoRank = 0
    Pariah = 1
    Outlaw = 2
    Exiled = 3
    Dishonored = 4
    Private_ = 5
    Corporal = 6
    Sergeant = 7
    MasterSergeant = 8
    SergeantMajor = 9
    Knight = 10
    KnightLieutenant = 11
    KnightCaptain = 12
    KnightChampion = 13
    LieutenantCommander = 14
    Commander = 15
    Marshal = 16
    FieldMarshal = 17
    GrandMarshal = 18
    Leader = 19
End Enum
Public Enum XPSTATE As Byte
    Normal = 2
    Rested = 1
End Enum
Public Enum ReputationRank As Byte
    Hated = 0
    Hostile = 1
    Unfriendly = 2
    Neutral = 3
    Friendly = 4
    Honored = 5
    Revered = 6
    Exalted = 7
End Enum
Public Enum ReputationPoints
    MIN = Integer.MinValue
    Hated = -42000
    Hostile = -6000
    Unfriendly = -3000
    Friendly = 3000
    Neutral = 0
    Honored = 9000
    Revered = 21000
    Exalted = 42000
    MAX = 43000
End Enum

Enum POI_ICON
    ICON_POI_0 = 0                                         ' Grey ?
    ICON_POI_1 = 1                                         ' Red ?
    ICON_POI_2 = 2                                         ' Blue ?
    ICON_POI_BWTOMB = 3                                    ' Blue and White Tomb Stone
    ICON_POI_HOUSE = 4                                     ' House
    ICON_POI_TOWER = 5                                     ' Tower
    ICON_POI_REDFLAG = 6                                   ' Red Flag with Yellow !
    ICON_POI_TOMB = 7                                      ' Tomb Stone
    ICON_POI_BWTOWER = 8                                   ' Blue and White Tower
    ICON_POI_REDTOWER = 9                                  ' Red Tower
    ICON_POI_BLUETOWER = 10                                ' Blue Tower
    ICON_POI_RWTOWER = 11                                  ' Red and White Tower
    ICON_POI_REDTOMB = 12                                  ' Red Tomb Stone
    ICON_POI_RWTOMB = 13                                   ' Red and White Tomb Stone
    ICON_POI_BLUETOMB = 14                                 ' Blue Tomb Stone
    ICON_POI_NOTHING = 15                                  ' NOTHING
    ICON_POI_16 = 16                                       ' Red ?
    ICON_POI_17 = 17                                       ' Grey ?
    ICON_POI_18 = 18                                       ' Blue ?
    ICON_POI_19 = 19                                       ' Red and White ?
    ICON_POI_20 = 20                                       ' Red ?
    ICON_POI_GREYLOGS = 21                                 ' Grey Wood Logs
    ICON_POI_BWLOGS = 22                                   ' Blue and White Wood Logs
    ICON_POI_BLUELOGS = 23                                 ' Blue Wood Logs
    ICON_POI_RWLOGS = 24                                   ' Red and White Wood Logs
    ICON_POI_REDLOGS = 25                                  ' Red Wood Logs
    ICON_POI_26 = 26                                       ' Grey ?
    ICON_POI_27 = 27                                       ' Blue and White ?
    ICON_POI_28 = 28                                       ' Blue ?
    ICON_POI_29 = 29                                       ' Red and White ?
    ICON_POI_30 = 30                                       ' Red ?
    ICON_POI_GREYHOUSE = 31                                ' Grey House
    ICON_POI_BWHOUSE = 32                                  ' Blue and White House
    ICON_POI_BLUEHOUSE = 33                                ' Blue House
    ICON_POI_RWHOUSE = 34                                  ' Red and White House
    ICON_POI_REDHOUSE = 35                                 ' Red House
    ICON_POI_GREYHORSE = 36                                ' Grey Horse
    ICON_POI_BWHORSE = 37                                  ' Blue and White Horse
    ICON_POI_BLUEHORSE = 38                                ' Blue Horse
    ICON_POI_RWHORSE = 39                                  ' Red and White Horse
    ICON_POI_REDHORSE = 40                                  ' Red Horse
End Enum



#End Region
#Region "Object.Flags"
Enum DynamicFlags   'Dynamic flags for units
    'Unit has blinking stars effect showing lootable
    UNIT_DYNFLAG_LOOTABLE = &H1
    'Shows marked unit as small red dot on radar
    UNIT_DYNFLAG_TRACK_UNIT = &H2
    'Gray mob title marks that mob is tagged by another player
    UNIT_DYNFLAG_OTHER_TAGGER = &H4
    'Blocks player character from moving
    UNIT_DYNFLAG_ROOTED = &H8
    'Shows infos like Damage and Health of the enemy
    UNIT_DYNFLAG_SPECIALINFO = &H10
    'Unit falls on the ground and shows like dead
    UNIT_DYNFLAG_DEAD = &H20
End Enum
Enum UnitFlags   'Flags for units
    UNIT_FLAG_NONE = &H0
    UNIT_FLAG_UNK1 = &H1
    UNIT_FLAG_NOT_ATTACKABLE = &H2                                                  'Unit is not attackable
    UNIT_FLAG_DISABLE_MOVE = &H4                                                    'Unit is frozen, rooted or stunned
    UNIT_FLAG_ATTACKABLE = &H8                                                      'Unit becomes temporarily hostile, shows in red, allows attack
    UNIT_FLAG_UNK3 = &H10
    UNIT_FLAG_RESTING = &H20
    UNIT_FLAG_UNK5 = &H40
    UNIT_FLAG_NOT_ATTACKABLE_1 = &H80                                               'Unit cannot be attacked by player, shows no attack cursor
    UNIT_FLAG_UNK6 = &H100
    UNIT_FLAG_UNK7 = &H200
    UNIT_FLAG_NON_PVP_PLAYER = UNIT_FLAG_ATTACKABLE + UNIT_FLAG_NOT_ATTACKABLE_1    'Unit cannot be attacked by player, shows in blue
    UNIT_FLAG_ANIMATION_FROZEN = &H400                                              'Doesn't play animation
    UNIT_FLAG_UNK8 = &H800
    UNIT_FLAG_WAR_PLAYER = &H1000                                                   'Show for Example "A proud Member of the Horde..." etc. when resurrecting a friend or fighting
    UNIT_FLAG_MOUNTED1 = &H2000
    UNIT_FLAG_MOUNTED = &H3000              'from WoWWoW
    UNIT_FLAG_DEAD = &H4000                 'from WoWWoW
    UNIT_FLAG_UNK11 = &H8000
    UNIT_FLAG_ROOTED = &H10000
    UNIT_FLAG_UNK14 = &H20000
    UNIT_FLAG_STUNTED = &H40000
    UNIT_FLAG_IN_COMBAT = &H80000
    UNIT_FLAG_UNK17 = &H100000
    UNIT_FLAG_UNK18 = &H200000
    UNIT_FLAG_UNK19 = &H400000
    UNIT_FLAG_UNK20 = &H800000
    UNIT_FLAG_UNK21 = &H1000000
    UNIT_FLAG_UNK22 = &H2000000
    UNIT_FLAG_SKINNABLE = &H4000000         'from WoWWoW
    UNIT_FLAG_UNK24 = &H8000000
    UNIT_FLAG_UNK25 = &H10000000
    UNIT_FLAG_UNK26 = &H20000000
    UNIT_FLAG_SKINNABLE_AND_DEAD = UNIT_FLAG_SKINNABLE + UNIT_FLAG_DEAD
    UNIT_FLAG_SPIRITHEALER = UNIT_FLAG_UNK19 + UNIT_FLAG_UNK21 + UNIT_FLAG_NOT_ATTACKABLE + UNIT_FLAG_DISABLE_MOVE + UNIT_FLAG_RESTING + UNIT_FLAG_UNK5
    UNIT_FLAG_SHEATHE = &H40000000
End Enum
Enum UnitFlag
    'WARNING: For use with SetFlag
    UNIT_FLAG_ENABLE_SWIM = 3           '0x8
    UNIT_FLAG_ROOTED = 16               '0x10000
    UNIT_FLAG_STUNTED = 18              '0x40000
    UNIT_FLAG_IN_COMBAT = 19            '0x80000
End Enum
#End Region
#Region "Object.Update"
Public Enum ObjectType
    TYPE_OBJECT = 1
    TYPE_ITEM = 2
    TYPE_CONTAINER = 6
    TYPE_UNIT = 8
    TYPE_PLAYER = 16
    TYPE_GAMEOBJECT = 32
    TYPE_DYNAMICOBJECT = 64
    TYPE_CORPSE = 128
    TYPE_AIGROUP = 256
    TYPE_AREATRIGGER = 512
End Enum
Public Enum ObjectTypeID
    TYPEID_OBJECT = 0
    TYPEID_ITEM = 1
    TYPEID_CONTAINER = 2
    TYPEID_UNIT = 3
    TYPEID_PLAYER = 4
    TYPEID_GAMEOBJECT = 5
    TYPEID_DYNAMICOBJECT = 6
    TYPEID_CORPSE = 7
    TYPEID_AIGROUP = 8
    TYPEID_AREATRIGGER = 9
End Enum
Public Enum ObjectUpdateType
    UPDATETYPE_VALUES = 0
    '  1 byte  - MASK
    '  8 bytes - GUID
    '  Goto Update Block
    UPDATETYPE_MOVEMENT = 1
    '  1 byte  - MASK
    '  8 bytes - GUID
    '  Goto Position Update
    UPDATETYPE_CREATE_OBJECT = 2
    UPDATETYPE_CREATE_OBJECT_SELF = 3
    '  1 byte  - MASK
    '  8 bytes - GUID
    '  1 byte - Object Type (*)
    '  Goto Position Update
    '  Goto Update Block
    UPDATETYPE_OUT_OF_RANGE_OBJECTS = 4
    '  4 bytes - Count
    '  Loop Count Times:
    '  1 byte  - MASK
    '  8 bytes - GUID
    UPDATETYPE_NEAR_OBJECTS = 5 'looks like 4 & 5 do the same thing
    '  4 bytes - Count
    '  Loop Count Times:
    '  1 byte  - MASK
    '  8 bytes - GUID
End Enum

Public Enum EObjectFields
    OBJECT_FIELD_GUID = 0       '  2  UINT64
    OBJECT_FIELD_TYPE = 2       '  1  UINT32
    OBJECT_FIELD_ENTRY = 3      '  1  UINT32
    OBJECT_FIELD_SCALE_X = 4    '  1  UINT32
    OBJECT_FIELD_PADDING = 5    '  1  UINT32
    OBJECT_END = 6              '  0  INTERNALMARKER
End Enum
Public Enum EItemFields
    ITEM_FIELD_OWNER = 6                    '  2  UINT64
    ITEM_FIELD_CONTAINED = 8                '  2  UINT64
    ITEM_FIELD_CREATOR = 10                 '  2  UINT64
    ITEM_FIELD_GIFTCREATOR = 12             '  2  UINT64
    ITEM_FIELD_STACK_COUNT = 14             '  1  UINT32
    ITEM_FIELD_DURATION = 15                '  1  UINT32
    ITEM_FIELD_SPELL_CHARGES = 16           '  5  SPELLCHARGES
    ITEM_FIELD_FLAGS = 21                   '  1  UINT32
    ITEM_FIELD_ENCHANTMENT = 22             '  33 ENCHANTMENT
    ITEM_FIELD_PROPERTY_SEED = 55           '  1  UINT32
    ITEM_FIELD_RANDOM_PROPERTIES_ID = 56    '  1  UINT32
    ITEM_FIELD_ITEM_TEXT_ID = 57            '  1  UINT32
    ITEM_FIELD_DURABILITY = 58              '  1  UINT32
    ITEM_FIELD_MAXDURABILITY = 59           '  1  UINT32
    ITEM_FIELD_SOCKET_CONTENT1 = 62         '
    ITEM_FIELD_SOCKET_CONTENT2 = 64         '
    ITEM_FIELD_SOCKET_CONTENT3 = 66         '
    ITEM_END = 200                          '  0  INTERNALMARKER
End Enum
Public Enum EContainerFields
    CONTAINER_FIELD_NUM_SLOTS = 60          '  1  UINT32
    CONTAINER_ALIGN_PAD = 61                '  1  UINT32
    CONTAINER_FIELD_SLOT_1 = 62             '  28 CONTAINERSLOTS (UINT64)
    CONTAINER_END = 118                     '  0  INTERNALMARKER
End Enum
Public Enum EUnitFields
    UNIT_FIELD_CHARM = 0 + EObjectFields.OBJECT_END                             '  2  UINT64
    UNIT_FIELD_SUMMON = 2 + EObjectFields.OBJECT_END                            '  2  UINT64
    UNIT_FIELD_CHARMEDBY = 4 + EObjectFields.OBJECT_END                         '  2  UINT64
    UNIT_FIELD_SUMMONEDBY = 6 + EObjectFields.OBJECT_END                        '  2  UINT64
    UNIT_FIELD_CREATEDBY = 8 + EObjectFields.OBJECT_END                         '  2  UINT64
    UNIT_FIELD_TARGET = 10 + EObjectFields.OBJECT_END                           '  2  UINT64
    UNIT_FIELD_PERSUADED = 12 + EObjectFields.OBJECT_END                        '  2  UINT64
    UNIT_FIELD_CHANNEL_OBJECT = 14 + EObjectFields.OBJECT_END                   '  2  UINT64
    UNIT_FIELD_HEALTH = 16 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POWER1 = 17 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POWER2 = 18 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POWER3 = 19 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POWER4 = 20 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POWER5 = 21 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_MAXHEALTH = 22 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_MAXPOWER1 = 23 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_MAXPOWER2 = 24 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_MAXPOWER3 = 25 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_MAXPOWER4 = 26 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_MAXPOWER5 = 27 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_LEVEL = 28 + EObjectFields.OBJECT_END                            '  1  UINT32
    UNIT_FIELD_FACTIONTEMPLATE = 29 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_BYTES_0 = 30 + EObjectFields.OBJECT_END                          '  1  UINT32
    UNIT_VIRTUAL_ITEM_SLOT_DISPLAY = 31 + EObjectFields.OBJECT_END              '  1  UINT32
    UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_01 = 32 + EObjectFields.OBJECT_END           '  1  UINT32
    UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_02 = 33 + EObjectFields.OBJECT_END           '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO = 34 + EObjectFields.OBJECT_END                      '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO_01 = 35 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO_02 = 36 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO_03 = 37 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO_04 = 38 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_VIRTUAL_ITEM_INFO_05 = 39 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_FIELD_FLAGS = 40 + EObjectFields.OBJECT_END                            '  1  UINT32
    UNIT_FIELD_FLAGS_2 = 41 + EObjectFields.OBJECT_END                          '  1  UINT32
    UNIT_FIELD_AURA = 42 + EObjectFields.OBJECT_END                             '  56 UINT32
    UNIT_FIELD_AURAFLAGS = 98 + EObjectFields.OBJECT_END                        '  7  UINT32    /56 BYTE/
    UNIT_FIELD_AURALEVELS = 105 + EObjectFields.OBJECT_END                      '  14 UINT32    /56 WORD/
    UNIT_FIELD_AURAAPPLICATIONS = 119 + EObjectFields.OBJECT_END                '  14 UINT32    /56 WORD/
    UNIT_FIELD_AURASTATE = 133 + EObjectFields.OBJECT_END                       '  1  UINT32
    UNIT_FIELD_BASEATTACKTIME = 134 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_OFFHANDATTACKTIME = 135 + EObjectFields.OBJECT_END               '  1  UINT32
    UNIT_FIELD_RANGEDATTACKTIME = 136 + EObjectFields.OBJECT_END                '  1  UINT32
    UNIT_FIELD_BOUNDINGRADIUS = 137 + EObjectFields.OBJECT_END                  '  1  FLOAT
    UNIT_FIELD_COMBATREACH = 138 + EObjectFields.OBJECT_END                     '  1  UINT32
    UNIT_FIELD_DISPLAYID = 139 + EObjectFields.OBJECT_END                       '  1  UINT32
    UNIT_FIELD_NATIVEDISPLAYID = 140 + EObjectFields.OBJECT_END                 '  1  UINT32
    UNIT_FIELD_MOUNTDISPLAYID = 141 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_MINDAMAGE = 142 + EObjectFields.OBJECT_END                       '  1  FLOAT
    UNIT_FIELD_MAXDAMAGE = 143 + EObjectFields.OBJECT_END                       '  1  FLOAT
    UNIT_FIELD_MINOFFHANDDAMAGE = 144 + EObjectFields.OBJECT_END                '  1  FLOAT
    UNIT_FIELD_MAXOFFHANDDAMAGE = 145 + EObjectFields.OBJECT_END                '  1  FLOAT
    UNIT_FIELD_BYTES_1 = 146 + EObjectFields.OBJECT_END                         '  1  UINT32
    UNIT_FIELD_PETNUMBER = 147 + EObjectFields.OBJECT_END                       '  1  UINT32
    UNIT_FIELD_PET_NAME_TIMESTAMP = 148 + EObjectFields.OBJECT_END              '  1  UINT32
    UNIT_FIELD_PETEXPERIENCE = 149 + EObjectFields.OBJECT_END                   '  1  UINT32
    UNIT_FIELD_PETNEXTLEVELEXP = 150 + EObjectFields.OBJECT_END                 '  1  UINT32
    UNIT_DYNAMIC_FLAGS = 151 + EObjectFields.OBJECT_END                         '  1  UINT32
    UNIT_CHANNEL_SPELL = 152 + EObjectFields.OBJECT_END                         '  1  UINT32
    UNIT_MOD_CAST_SPEED = 153 + EObjectFields.OBJECT_END                        '  1  FLOAT
    UNIT_CREATED_BY_SPELL = 154 + EObjectFields.OBJECT_END                      '  1  UINT32
    UNIT_NPC_FLAGS = 155 + EObjectFields.OBJECT_END                             '  1  UINT32
    UNIT_NPC_EMOTESTATE = 156 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_TRAINING_POINTS = 157 + EObjectFields.OBJECT_END                       '  1  UINT32
    UNIT_FIELD_STAT0 = 158 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_STAT1 = 159 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_STAT2 = 160 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_STAT3 = 161 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_STAT4 = 162 + EObjectFields.OBJECT_END                           '  1  UINT32
    UNIT_FIELD_POSSTAT0 = 163 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_POSSTAT1 = 164 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_POSSTAT2 = 165 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_POSSTAT3 = 166 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_POSSTAT4 = 167 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_NEGSTAT0 = 168 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_NEGSTAT1 = 169 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_NEGSTAT2 = 170 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_NEGSTAT3 = 171 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_NEGSTAT4 = 172 + EObjectFields.OBJECT_END                        '  1  UINT32
    UNIT_FIELD_RESISTANCES = 173 + EObjectFields.OBJECT_END                     '  1  UINT32
    UNIT_FIELD_RESISTANCES_01 = 174 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCES_02 = 175 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCES_03 = 176 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCES_04 = 177 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCES_05 = 178 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCES_06 = 179 + EObjectFields.OBJECT_END                  '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE = 180 + EObjectFields.OBJECT_END      '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_01 = 181 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_02 = 182 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_03 = 183 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_04 = 184 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_05 = 185 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE_06 = 186 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE = 187 + EObjectFields.OBJECT_END      '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_01 = 188 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_02 = 189 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_03 = 190 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_04 = 191 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_05 = 192 + EObjectFields.OBJECT_END   '  1  UINT32
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE_06 = 193 + EObjectFields.OBJECT_END   '  1  UINT32

    UNIT_FIELD_BASE_MANA = 194 + EObjectFields.OBJECT_END                       '  1  UINT32
    UNIT_FIELD_BASE_HEALTH = 195 + EObjectFields.OBJECT_END                     '  1  UINT32
    UNIT_FIELD_BYTES_2 = 196 + EObjectFields.OBJECT_END                         '  1  UINT32
    UNIT_FIELD_ATTACK_POWER = 197 + EObjectFields.OBJECT_END                    '  1  UINT32
    UNIT_FIELD_ATTACK_POWER_MODS = 198 + EObjectFields.OBJECT_END               '  1  UINT32
    UNIT_FIELD_ATTACK_POWER_MULTIPLIER = 199 + EObjectFields.OBJECT_END         '  1  FLOAT
    UNIT_FIELD_RANGED_ATTACK_POWER = 200 + EObjectFields.OBJECT_END             '  1  UINT32
    UNIT_FIELD_RANGED_ATTACK_POWER_MODS = 201 + EObjectFields.OBJECT_END        '  1  UINT32
    UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER = 202 + EObjectFields.OBJECT_END  '  1  FLOAT
    UNIT_FIELD_MINRANGEDDAMAGE = 203 + EObjectFields.OBJECT_END                 '  1  FLOAT
    UNIT_FIELD_MAXRANGEDDAMAGE = 204 + EObjectFields.OBJECT_END                 '  1  FLOAT
    UNIT_FIELD_POWER_COST_MODIFIER = 205 + EObjectFields.OBJECT_END             '  7  UINT32
    UNIT_FIELD_POWER_COST_MULTIPLIER = 212 + EObjectFields.OBJECT_END           '  7  FLOAT
    UNIT_FIELD_PADDING = 219 + EObjectFields.OBJECT_END
    UNIT_END = 220 + EObjectFields.OBJECT_END                                   '  0  INTERNALMARKER



    UNIT_FIELD_STRENGTH = UNIT_FIELD_STAT0
    UNIT_FIELD_AGILITY = UNIT_FIELD_STAT1
    UNIT_FIELD_STAMINA = UNIT_FIELD_STAT2
    UNIT_FIELD_SPIRIT = UNIT_FIELD_STAT4
    UNIT_FIELD_INTELLECT = UNIT_FIELD_STAT3
    UNIT_FIELD_ARMOR = UNIT_FIELD_RESISTANCES
End Enum
Public Enum EPlayerFields
    PLAYER_DUEL_ARBITER = 0 + EUnitFields.UNIT_END                                                          '  1  UINT64
    PLAYER_FLAGS = 2 + EUnitFields.UNIT_END                                                                 '  1  UINT32
    PLAYER_GUILDID = 3 + EUnitFields.UNIT_END                                                               '  1  UINT32
    PLAYER_GUILDRANK = 4 + EUnitFields.UNIT_END                                                             '  1  UINT32
    PLAYER_BYTES = 5 + EUnitFields.UNIT_END                                                                 '  1  UINT32
    PLAYER_BYTES_2 = 6 + EUnitFields.UNIT_END                                                               '  1  UINT32
    PLAYER_BYTES_3 = 7 + EUnitFields.UNIT_END                                                               '  1  UINT32
    PLAYER_DUEL_TEAM = 8 + EUnitFields.UNIT_END                                                             '  1  UINT32
    PLAYER_GUILD_TIMESTAMP = 9 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_1_1 = 10 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_1_2 = 11 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_1_3 = 12 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_2_1 = 13 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_2_2 = 14 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_2_3 = 15 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_3_1 = 16 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_3_2 = 17 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_3_3 = 18 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_4_1 = 19 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_4_2 = 20 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_4_3 = 21 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_5_1 = 22 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_5_2 = 23 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_5_3 = 24 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_6_1 = 25 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_6_2 = 26 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_6_3 = 27 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_7_1 = 28 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_7_2 = 29 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_7_3 = 30 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_8_1 = 31 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_8_2 = 32 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_8_3 = 33 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_9_1 = 34 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_9_2 = 35 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_9_3 = 36 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_QUEST_LOG_10_1 = 37 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_10_2 = 38 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_10_3 = 39 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_11_1 = 40 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_11_2 = 41 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_11_3 = 42 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_12_1 = 43 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_12_2 = 44 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_12_3 = 45 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_13_1 = 46 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_13_2 = 47 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_13_3 = 48 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_14_1 = 49 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_14_2 = 50 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_14_3 = 51 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_15_1 = 52 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_15_2 = 53 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_15_3 = 54 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_16_1 = 55 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_16_2 = 56 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_16_3 = 57 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_17_1 = 58 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_17_2 = 59 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_17_3 = 60 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_18_1 = 61 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_18_2 = 62 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_18_3 = 63 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_19_1 = 64 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_19_2 = 65 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_19_3 = 66 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_20_1 = 67 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_20_2 = 68 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_20_3 = 69 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_21_1 = 70 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_21_2 = 71 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_21_3 = 72 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_22_1 = 73 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_22_2 = 74 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_22_3 = 75 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_23_1 = 76 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_23_2 = 77 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_23_3 = 78 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_24_1 = 79 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_24_2 = 80 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_24_3 = 81 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_25_1 = 82 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_25_2 = 83 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_QUEST_LOG_25_3 = 84 + EUnitFields.UNIT_END                                                       '  1  UINT32

    PLAYER_VISIBLE_ITEM_1_CREATOR = 85 + EUnitFields.UNIT_END                                               '  1  UINT64
    PLAYER_VISIBLE_ITEM_1_0 = 87 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_1 = 88 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_2 = 89 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_3 = 90 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_4 = 91 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_5 = 92 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_6 = 93 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_7 = 94 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_8 = 95 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_9 = 96 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_10 = 97 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_11 = 98 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_PROPERTIES = 99 + EUnitFields.UNIT_END                                            '  1  UINT32
    PLAYER_VISIBLE_ITEM_1_PAD = 100 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_CREATOR = 101 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_2_0 = 103 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_1 = 104 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_2 = 105 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_3 = 106 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_4 = 107 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_5 = 108 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_6 = 109 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_7 = 110 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_8 = 111 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_9 = 112 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_10 = 113 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_11 = 114 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_PROPERTIES = 115 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_2_PAD = 116 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_CREATOR = 117 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_3_0 = 119 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_1 = 120 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_2 = 121 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_3 = 122 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_4 = 123 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_5 = 124 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_6 = 125 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_7 = 126 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_8 = 127 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_9 = 128 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_10 = 129 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_11 = 130 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_PROPERTIES = 131 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_3_PAD = 132 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_CREATOR = 133 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_4_0 = 135 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_1 = 136 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_2 = 137 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_3 = 138 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_4 = 139 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_5 = 140 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_6 = 141 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_7 = 142 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_8 = 143 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_9 = 144 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_10 = 145 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_11 = 146 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_PROPERTIES = 147 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_4_PAD = 148 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_CREATOR = 149 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_5_0 = 151 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_1 = 152 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_2 = 153 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_3 = 154 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_4 = 155 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_5 = 156 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_6 = 157 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_7 = 158 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_8 = 159 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_9 = 160 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_10 = 161 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_11 = 162 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_PROPERTIES = 163 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_5_PAD = 164 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_CREATOR = 165 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_6_0 = 167 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_1 = 168 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_2 = 169 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_3 = 170 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_4 = 171 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_5 = 172 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_6 = 173 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_7 = 174 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_8 = 175 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_9 = 176 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_10 = 177 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_11 = 178 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_PROPERTIES = 179 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_6_PAD = 180 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_CREATOR = 181 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_7_0 = 183 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_1 = 184 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_2 = 185 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_3 = 186 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_4 = 187 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_5 = 188 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_6 = 189 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_7 = 190 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_8 = 191 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_9 = 192 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_10 = 193 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_11 = 194 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_PROPERTIES = 195 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_7_PAD = 196 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_CREATOR = 197 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_8_0 = 199 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_1 = 200 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_2 = 201 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_3 = 202 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_4 = 203 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_5 = 204 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_6 = 205 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_7 = 206 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_8 = 207 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_9 = 208 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_10 = 209 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_11 = 210 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_PROPERTIES = 211 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_8_PAD = 212 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_CREATOR = 213 + EUnitFields.UNIT_END                                              '  1  UINT64
    PLAYER_VISIBLE_ITEM_9_0 = 215 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_1 = 216 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_2 = 217 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_3 = 218 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_4 = 219 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_5 = 220 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_6 = 221 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_7 = 222 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_8 = 223 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_9 = 224 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_10 = 225 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_11 = 226 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_PROPERTIES = 227 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_VISIBLE_ITEM_9_PAD = 228 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_CREATOR = 229 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_10_0 = 231 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_1 = 232 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_2 = 233 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_3 = 234 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_4 = 235 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_5 = 236 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_6 = 237 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_7 = 238 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_8 = 239 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_9 = 240 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_10 = 241 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_11 = 242 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_PROPERTIES = 243 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_10_PAD = 244 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_CREATOR = 245 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_11_0 = 247 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_1 = 248 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_2 = 249 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_3 = 250 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_4 = 251 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_5 = 252 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_6 = 253 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_7 = 254 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_8 = 255 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_9 = 256 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_10 = 257 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_11 = 258 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_PROPERTIES = 259 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_11_PAD = 260 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_CREATOR = 261 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_12_0 = 263 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_1 = 264 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_2 = 265 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_3 = 266 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_4 = 267 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_5 = 268 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_6 = 269 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_7 = 270 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_8 = 271 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_9 = 272 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_10 = 273 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_11 = 274 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_PROPERTIES = 275 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_12_PAD = 276 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_CREATOR = 277 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_13_0 = 279 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_1 = 280 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_2 = 281 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_3 = 282 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_4 = 283 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_5 = 284 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_6 = 285 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_7 = 286 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_8 = 287 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_9 = 288 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_10 = 289 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_11 = 290 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_PROPERTIES = 291 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_13_PAD = 292 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_CREATOR = 293 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_14_0 = 295 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_1 = 296 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_2 = 297 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_3 = 298 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_4 = 299 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_5 = 300 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_6 = 301 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_7 = 302 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_8 = 303 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_9 = 304 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_10 = 305 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_11 = 306 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_PROPERTIES = 307 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_14_PAD = 308 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_CREATOR = 309 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_15_0 = 311 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_1 = 312 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_2 = 313 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_3 = 314 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_4 = 315 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_5 = 316 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_6 = 317 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_7 = 318 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_8 = 319 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_9 = 320 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_10 = 321 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_11 = 322 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_PROPERTIES = 323 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_15_PAD = 324 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_CREATOR = 325 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_16_0 = 327 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_1 = 328 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_2 = 329 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_3 = 330 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_4 = 331 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_5 = 332 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_6 = 333 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_7 = 334 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_8 = 335 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_9 = 336 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_10 = 337 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_11 = 338 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_PROPERTIES = 339 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_16_PAD = 340 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_CREATOR = 341 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_17_0 = 343 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_1 = 344 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_2 = 345 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_3 = 346 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_4 = 347 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_5 = 348 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_6 = 349 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_7 = 350 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_8 = 351 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_9 = 352 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_10 = 353 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_11 = 354 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_PROPERTIES = 355 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_17_PAD = 356 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_CREATOR = 357 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_18_0 = 359 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_1 = 360 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_2 = 361 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_3 = 362 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_4 = 363 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_5 = 364 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_6 = 365 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_7 = 366 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_8 = 367 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_9 = 368 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_10 = 369 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_11 = 370 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_PROPERTIES = 371 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_18_PAD = 372 + EUnitFields.UNIT_END                                                 '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_CREATOR = 373 + EUnitFields.UNIT_END                                             '  1  UINT64
    PLAYER_VISIBLE_ITEM_19_0 = 375 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_1 = 376 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_2 = 377 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_3 = 378 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_4 = 379 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_5 = 380 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_6 = 381 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_7 = 382 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_8 = 383 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_9 = 384 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_10 = 385 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_11 = 386 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_PROPERTIES = 387 + EUnitFields.UNIT_END                                          '  1  UINT32
    PLAYER_VISIBLE_ITEM_19_PAD = 388 + EUnitFields.UNIT_END                                                 '  1  UINT32

    PLAYER_CHOSEN_TITLE = 389 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_FIELD_INV_SLOT_HEAD = 390 + EUnitFields.UNIT_END                                                 '  23 UINT64    /19 x EQUIPMENT SLOTS, 4 x BAG SLOTS/
    'PLAYER_FIELD_INV_SLOT_BAG_1 = PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_1 * 2 + EUnitFields.UNIT_END
    'PLAYER_FIELD_INV_SLOT_BAG_2 = PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_2 * 2 + EUnitFields.UNIT_END
    'PLAYER_FIELD_INV_SLOT_BAG_3 = PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_3 * 2 + EUnitFields.UNIT_END
    'PLAYER_FIELD_INV_SLOT_BAG_4 = PLAYER_FIELD_INV_SLOT_HEAD + INVENTORY_SLOT_BAG_4 * 2 + EUnitFields.UNIT_END
    PLAYER_FIELD_PACK_SLOT_1 = 436 + EUnitFields.UNIT_END                                                   '  16 UINT64    /INVENTORY BAG/
    PLAYER_FIELD_BANK_SLOT_1 = 468 + EUnitFields.UNIT_END                                                   '  28 UINT64    /BANK         /
    PLAYER_FIELD_BANKBAG_SLOT_1 = 524 + EUnitFields.UNIT_END                                                '  7  UINT64    /BANK BAGS    /
    PLAYER_FIELD_VENDORBUYBACK_SLOT_1 = 538 + EUnitFields.UNIT_END                                          '  12 UINT64    /BUYBACK SLOTS/
    PLAYER_FIELD_KEYRING_SLOT_1 = 562 + EUnitFields.UNIT_END                                                '  32 UINT64    /KEYRING SLOTS/

    PLAYER_FARSIGHT = 626 + EUnitFields.UNIT_END                                                            '  1  UINT64
    PLAYER_FIELD_COMBO_TARGET = 628 + EUnitFields.UNIT_END                                                  '  1  UINT64
    PLAYER_FIELD_KNOWN_TITLES = 630 + EUnitFields.UNIT_END                                                  '  1  UINT64
    PLAYER_XP = 632 + EUnitFields.UNIT_END                                                                  '  1  UINT32
    PLAYER_NEXT_LEVEL_XP = 633 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_SKILL_INFO_START = 634 + EUnitFields.UNIT_END                                                    ' 384 UINT32

    PLAYER_CHARACTER_POINTS1 = 1018 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_CHARACTER_POINTS2 = 1019 + EUnitFields.UNIT_END                                                  '  1  UINT32
    PLAYER_TRACK_CREATURES = 1020 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_TRACK_RESOURCES = 1021 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_BLOCK_PERCENTAGE = 1022 + EUnitFields.UNIT_END                                                   '  1  FLOAT
    PLAYER_DODGE_PERCENTAGE = 1023 + EUnitFields.UNIT_END                                                   '  1  FLOAT
    PLAYER_PARRY_PERCENTAGE = 1024 + EUnitFields.UNIT_END                                                   '  1  FLOAT
    PLAYER_CRIT_PERCENTAGE = 1025 + EUnitFields.UNIT_END                                                    '  1  FLOAT
    PLAYER_RANGED_CRIT_PERCENTAGE = 1026 + EUnitFields.UNIT_END                                             '  1  FLOAT
    PLAYER_OFFHAND_CRIT_PERCENTAGE = 1027 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE = 1028 + EUnitFields.UNIT_END                                              '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE01 = 1029 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE02 = 1030 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE03 = 1031 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE04 = 1032 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE05 = 1033 + EUnitFields.UNIT_END                                            '  1  FLOAT
    PLAYER_SPELL_CRIT_PERCENTAGE06 = 1034 + EUnitFields.UNIT_END                                            '  1  FLOAT

    PLAYER_EXPLORED_ZONES_1 = 1035 + EUnitFields.UNIT_END                                                   '  64 UINT32
    PLAYER_REST_STATE_EXPERIENCE = 1099 + EUnitFields.UNIT_END                                              '  1  UINT32
    PLAYER_FIELD_COINAGE = 1100 + EUnitFields.UNIT_END                                                      '  1  UINT32
    PLAYER_FIELD_MOD_DAMAGE_DONE_POS = 1101 + EUnitFields.UNIT_END                                          '  7  UINT32
    PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = 1108 + EUnitFields.UNIT_END                                          '  7  UINT32
    PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = 1115 + EUnitFields.UNIT_END                                          '  7  UINT32
    PLAYER_FIELD_MOD_HEALING_DONE_POS = 1122 + EUnitFields.UNIT_END                                         '  1  UINT32
    PLAYER_FIELD_MOD_TARGET_RESISTANCE = 1123 + EUnitFields.UNIT_END                                        '  1  UINT32

    PLAYER_FIELD_BYTES = 1124 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_AMMO_ID = 1125 + EUnitFields.UNIT_END                                                            '  1  UINT32
    PLAYER_SELF_RES_SPELL = 1126 + EUnitFields.UNIT_END                                                     '  1  UINT32
    PLAYER_FIELD_PVP_MEDALS = 1127 + EUnitFields.UNIT_END                                                   '  1  UINT32
    PLAYER_FIELD_BUYBACK_PRICE_1 = 1128 + EUnitFields.UNIT_END                                              '  12 UINT32
    PLAYER_FIELD_BUYBACK_TIMESTAMP_1 = 1140 + EUnitFields.UNIT_END                                          '  12 UINT32
    PLAYER_FIELD_KILLS = 1152 + EUnitFields.UNIT_END                                                        '  1  UINT32
    PLAYER_FIELD_TODAY_CONTRIBUTION = 1153 + EUnitFields.UNIT_END                                           '  1  UINT32
    PLAYER_FIELD_YESTERDAY_CONTRIBUTION = 1154 + EUnitFields.UNIT_END                                       '  1  UINT32
    PLAYER_FIELD_LIFETIME_HONORBALE_KILLS = 1155 + EUnitFields.UNIT_END                                     '  1  UINT32
    PLAYER_FIELD_BYTES2 = 1156 + EUnitFields.UNIT_END                                                       '  1  UINT32
    PLAYER_FIELD_WATCHED_FACTION_INDEX = 1157 + EUnitFields.UNIT_END                                        '  1  UINT32
    PLAYER_FIELD_COMBAT_RATING_1 = 1158 + EUnitFields.UNIT_END                                              '  23 UINT32
    PLAYER_FIELD_COMBAT_RATING_01 = 1159 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_02 = 1160 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_03 = 1161 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_04 = 1162 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_05 = 1163 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_06 = 1164 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_07 = 1165 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_08 = 1166 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_09 = 1167 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_10 = 1168 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_11 = 1169 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_12 = 1170 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_13 = 1171 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_14 = 1172 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_15 = 1173 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_16 = 1174 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_17 = 1175 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_18 = 1176 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_19 = 1177 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_20 = 1178 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_21 = 1179 + EUnitFields.UNIT_END
    PLAYER_FIELD_COMBAT_RATING_22 = 1180 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_1 = 1181 + EUnitFields.UNIT_END                                          '  9  UINT32
    PLAYER_FIELD_ARENA_TEAM_INFO_1_01 = 1182 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_02 = 1183 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_03 = 1184 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_04 = 1185 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_05 = 1186 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_06 = 1187 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_07 = 1188 + EUnitFields.UNIT_END
    PLAYER_FIELD_ARENA_TEAM_INFO_1_08 = 1189 + EUnitFields.UNIT_END
    PLAYER_FIELD_HONOR_CURRENCY = 1190 + EUnitFields.UNIT_END                                              '  1  UINT32
    PLAYER_FIELD_ARENA_CURRENCY = 1191 + EUnitFields.UNIT_END                                               '  1  UINT32
    PLAYER_FIELD_MOD_MANA_REGEN = 1192 + EUnitFields.UNIT_END                                               '  1  FLOAT
    PLAYER_FIELD_MOD_MANA_REGEN_INTERRUPT = 1193 + EUnitFields.UNIT_END                                     '  1  FLOAT
    PLAYER_FIELD_MAX_LEVEL = 1194 + EUnitFields.UNIT_END                                                    '  1  UINT32
    PLAYER_END = 1195 + EUnitFields.UNIT_END                                                                '  0  INTERNALMARKER
End Enum
Public Enum EGameObjectFields
    OBJECT_FIELD_CREATED_BY = 6         '  2  UINT64
    GAMEOBJECT_DISPLAYID = 8            '  1  UINT32
    GAMEOBJECT_FLAGS = 9                '  1  UINT32
    GAMEOBJECT_ROTATION = 10            '  4  ROTATION
    GAMEOBJECT_STATE = 14               '  1  UINT32
    GAMEOBJECT_POS_X = 15               '  1  FLOAT
    GAMEOBJECT_POS_Y = 16               '  1  FLOAT
    GAMEOBJECT_POS_Z = 17               '  1  FLOAT
    GAMEOBJECT_FACING = 18              '  1  FLOAT
    GAMEOBJECT_DYN_FLAGS = 19           '  1  UINT32
    GAMEOBJECT_FACTION = 20             '  1  UINT32
    GAMEOBJECT_TYPE_ID = 21             '  1  UINT32
    GAMEOBJECT_LEVEL = 22               '  1  UINT32
    GAMEOBJECT_ARTKIT = 23              '  1  UINT32
    GAMEOBJECT_ANIMPROGRESS = 24        '  1  UINT32
    GAMEOBJECT_END = 25                 '  0  INTERNALMARKER

    'NOTE: Removed in 1.12
    'GAMEOBJECT_TIMESTAMP = 15           '  1  UINT32
End Enum
Public Enum EDynamicObjectFields
    DYNAMICOBJECT_CASTER = 6        '  2  UINT64
    DYNAMICOBJECT_BYTES = 8         '  1  UINT32
    DYNAMICOBJECT_SPELLID = 9       '  1  UINT32
    DYNAMICOBJECT_RADIUS = 10       '  1  UINT32
    DYNAMICOBJECT_POS_X = 11        '  1  UINT32
    DYNAMICOBJECT_POS_Y = 12        '  1  UINT32
    DYNAMICOBJECT_POS_Z = 13        '  1  UINT32
    DYNAMICOBJECT_FACING = 14       '  1  UINT32
    DYNAMICOBJECT_PAD = 15          '  1  UINT32
    DYNAMICOBJECT_END = 16          '  0  INTERNALMARKER
End Enum
Public Enum ECorpseFields
    CORPSE_FIELD_OWNER = 6          '  2  UINT64
    CORPSE_FIELD_FACING = 8         '  1  FLOAT
    CORPSE_FIELD_POS_X = 9          '  1  FLOAT
    CORPSE_FIELD_POS_Y = 10         '  1  FLOAT
    CORPSE_FIELD_POS_Z = 11         '  1  FLOAT
    CORPSE_FIELD_DISPLAY_ID = 12    '  1  UINT32
    CORPSE_FIELD_ITEM = 13          '  19 CORPSEITEMS
    CORPSE_FIELD_BYTES_1 = 32       '  1  UINT32
    CORPSE_FIELD_BYTES_2 = 33       '  1  UINT32
    CORPSE_FIELD_GUILD = 34         '  1  UINT32
    CORPSE_FIELD_FLAGS = 35         '  1  UINT32
    CORPSE_FIELD_DYNAMIC_FLAGS = 36 '  1  UINT32
    CORPSE_FIELD_PAD = 37           '  1  UINT32
    CORPSE_END = 38                 '  0  INTERNALMARKER
End Enum

#End Region

#Region "Creatures"
Enum UNIT_TYPE
    NOUNITTYPE = 0
    BEAST = 1
    DRAGONKIN = 2
    DEMON = 3
    ELEMENTAL = 4
    GIANT = 5
    UNDEAD = 6
    HUMANOID = 7
    CRITTER = 8
    MECHANICAL = 9
    MOUNT = 10
End Enum
Enum NPCFlags
    UNIT_NPC_FLAG_NONE = 0                          ' None
    UNIT_NPC_FLAG_GOSSIP = 1                        ' Gossip/Talk (CMSG_GOSSIP_HELLO ?)
    UNIT_NPC_FLAG_QUESTGIVER = 2                    ' Questgiver
    UNIT_NPC_FLAG_VENDOR = 4                        ' Vendor (CMSG_LIST_INVENTORY SMSG_LIST_INVENTORY)
    UNIT_NPC_FLAG_TAXIVENDOR = 8                    ' Taxi Vendor (CMSG_TAXIQUERYAVAILABLENODES SMSG_SHOWTAXINODES)
    UNIT_NPC_FLAG_TRAINER = 16                      ' Trainer (CMSG_TRAINER_LIST SMSG_TRAINER_LIST)
    UNIT_NPC_FLAG_SPIRITHEALER = 32                 ' Spirithealer (CMSG_BINDER_ACTIVATE ?)
    UNIT_NPC_FLAG_GUARD = 64                        ' Battlefield Spirithealer
    UNIT_NPC_FLAG_INNKEEPER = 128                   ' Innkeeper
    UNIT_NPC_FLAG_BANKER = 256                      ' Banker (CMSG_BANKER_ACTIVATE SMSG_SHOW_BANK)
    UNIT_NPC_FLAG_PETITIONER = 512                  ' Petitioner/?Guild Charter? (CMSG_PETITION_SHOWLIST SMSG_PETITION_SHOWLIST)
    UNIT_NPC_FLAG_TABARDVENDOR = 1024               ' Tabard Vendor (MSG_TABARDVENDOR_ACTIVATE)
    UNIT_NPC_FLAG_BATTLEFIELDPERSON = 2048          ' Battlefield Person (CMSG_BATTLEFIELD_LIST SMSG_BATTLEFIELD_LIST)
    UNIT_NPC_FLAG_AUCTIONEER = 4096                 ' Auctioneer (MSG_AUCTION_HELLO)
    UNIT_NPC_FLAG_STABLE = 8192                     ' Stable Master
    UNIT_NPC_FLAG_ARMORER = 16384                   ' ARMORER ...
End Enum
Enum CREATURE_FAMILY As Integer
    NONE = 0
    WOLF = 1
    CAT = 2
    SPIDER = 3
    BEAR = 4
    BOAR = 5
    CROCILISK = 6
    CARRION_BIRD = 7
    CRAB = 8
    GORILLA = 9
    RAPTOR = 11
    TALLSTRIDER = 12
    FELHUNTER = 15
    VOIDWALKER = 16
    SUCCUBUS = 17
    DOOMGUARD = 19
    SCORPID = 20
    TURTLE = 21
    IMP = 23
    BAT = 24
    HYENA = 25
    OWL = 26
    WIND_SERPENT = 27
End Enum
Enum CREATURE_ELITE As Integer
    NORMAL = 0
    ELITE = 1
    RAREELITE = 2
    WORLDBOSS = 3
    RARE = 4
End Enum
#End Region


Public Enum ChatMsg
    CHAT_MSG_SAY = &H0
    CHAT_MSG_PARTY = &H1
    CHAT_MSG_RAID = &H2
    CHAT_MSG_GUILD = &H3
    CHAT_MSG_OFFICER = &H4
    CHAT_MSG_YELL = &H5
    CHAT_MSG_WHISPER = &H6
    CHAT_MSG_WHISPER_INFORM = &H7
    CHAT_MSG_EMOTE = &H8
    CHAT_MSG_TEXT_EMOTE = &H9
    CHAT_MSG_SYSTEM = &HA
    CHAT_MSG_MONSTER_SAY = &HB
    CHAT_MSG_MONSTER_YELL = &HC
    CHAT_MSG_MONSTER_EMOTE = &HD
    CHAT_MSG_CHANNEL = &HE
    CHAT_MSG_CHANNEL_JOIN = &HF
    CHAT_MSG_CHANNEL_LEAVE = &H10
    CHAT_MSG_CHANNEL_LIST = &H11
    CHAT_MSG_CHANNEL_NOTICE = &H12
    CHAT_MSG_CHANNEL_NOTICE_USER = &H13
    CHAT_MSG_AFK = &H14
    CHAT_MSG_DND = &H15
    CHAT_MSG_IGNORED = &H16
    CHAT_MSG_COMBAT_LOG = &H17
    CHAT_MSG_SKILL = &H18
    CHAT_MSG_LOOT = &H19

    CHAT_COMBAT_MISC_INFO = 25
    CHAT_MONSTER_WHISPER = 26
    CHAT_COMBAT_SELF_HITS = 27
    CHAT_COMBAT_SELF_MISSES = 28
    CHAT_COMBAT_PET_HITS = 29
    CHAT_COMBAT_PET_MISSES = 30
    CHAT_COMBAT_PARTY_HITS = 31
    CHAT_COMBAT_PARTY_MISSES = 32
    CHAT_COMBAT_FRIENDLYPLAYER_HITS = 33
    CHAT_COMBAT_FRIENDLYPLAYER_MISSES = 34
    CHAT_COMBAT_HOSTILEPLAYER_HITS = 35
    CHAT_COMBAT_HOSTILEPLAYER_MISSES = 36
    CHAT_COMBAT_CREATURE_VS_SELF_HITS = 37
    CHAT_COMBAT_CREATURE_VS_SELF_MISSES = 38
    CHAT_COMBAT_CREATURE_VS_PARTY_HITS = 39
    CHAT_COMBAT_CREATURE_VS_PARTY_MISSES = 40
    CHAT_COMBAT_CREATURE_VS_CREATURE_HITS = 41
    CHAT_COMBAT_CREATURE_VS_CREATURE_MISSES = 42
    CHAT_COMBAT_FRIENDLY_DEATH = 43
    CHAT_COMBAT_HOSTILE_DEATH = 44
    CHAT_COMBAT_XP_GAIN = 45
    CHAT_SPELL_SELF_DAMAGE = 46
    CHAT_SPELL_SELF_BUFF = 47
    CHAT_SPELL_PET_DAMAGE = 48
    CHAT_SPELL_PET_BUFF = 49
    CHAT_SPELL_PARTY_DAMAGE = 50
    CHAT_SPELL_PARTY_BUFF = 51
    CHAT_SPELL_FRIENDLYPLAYER_DAMAGE = 52
    CHAT_SPELL_FRIENDLYPLAYER_BUFF = 53
    CHAT_SPELL_HOSTILEPLAYER_DAMAGE = 54
    CHAT_SPELL_HOSTILEPLAYER_BUFF = 55
    CHAT_SPELL_CREATURE_VS_SELF_DAMAGE = 56
    CHAT_SPELL_CREATURE_VS_SELF_BUFF = 57
    CHAT_SPELL_CREATURE_VS_PARTY_DAMAGE = 58
    CHAT_SPELL_CREATURE_VS_PARTY_BUFF = 59
    CHAT_SPELL_CREATURE_VS_CREATURE_DAMAGE = 60
    CHAT_SPELL_CREATURE_VS_CREATURE_BUFF = 61
    CHAT_SPELL_TRADESKILLS = 62
    CHAT_SPELL_DAMAGESHIELDS_ON_SELF = 63
    CHAT_SPELL_DAMAGESHIELDS_ON_OTHERS = 64
    CHAT_SPELL_AURA_GONE_SELF = 65
    CHAT_SPELL_AURA_GONE_PARTY = 66
    CHAT_SPELL_AURA_GONE_OTHER = 67
    CHAT_SPELL_ITEM_ENCHANTMENTS = 68
    CHAT_SPELL_BREAK_AURA = 69
    CHAT_SPELL_PERIODIC_SELF_DAMAGE = 70
    CHAT_SPELL_PERIODIC_SELF_BUFFS = 71
    CHAT_SPELL_PERIODIC_PARTY_DAMAGE = 72
    CHAT_SPELL_PERIODIC_PARTY_BUFFS = 73
    CHAT_SPELL_PERIODIC_FRIENDLYPLAYER_DAMAGE = 74
    CHAT_SPELL_PERIODIC_FRIENDLYPLAYER_BUFFS = 75
    CHAT_SPELL_PERIODIC_HOSTILEPLAYER_DAMAGE = 76
    CHAT_SPELL_PERIODIC_HOSTILEPLAYER_BUFFS = 77
    CHAT_SPELL_PERIODIC_CREATURE_DAMAGE = 78
    CHAT_SPELL_PERIODIC_CREATURE_BUFFS = 79
    CHAT_SPELL_FAILED_LOCALPLAYER = 80
    CHAT_COMBAT_HONOR_GAIN = 81
    CHAT_BG_SYSTEM_NEUTRAL = 82
    CHAT_BG_SYSTEM_ALLIANCE = 83
    CHAT_BG_SYSTEM_HORDE = 84

    CHAT_MSG_RAID_LEADER = &H57
    CHAT_MSG_RAID_WARNING = &H58
End Enum
Enum InvalidReason
    DontHaveReq = 0
    DontHaveReqItems = 19
    DontHaveReqMoney = 21
    NotAvailableRace = 6
    NotEnoughLevel = 1
    ReadyHaveThatQuest = 13
    ReadyHaveTimedQuest = 12
End Enum
Enum Attributes
    Agility = 3
    Health = 1
    Iq = 5
    Mana = 0
    Spirit = 6
    Stamina = 7
    Strenght = 4
End Enum
Enum Slots
    ' Fields
    Back = 14
    BackpackEnd = 39
    BackpackStart = 23
    Bag1 = 19
    Bag2 = 20
    Bag3 = 21
    Bag4 = 22
    BagsEnd = 261
    BagsStart = 81
    BankBagsEnd = 70
    BankBagsStart = 63
    BankEnd = 67
    BankStart = 39
    BuybackEnd = 81
    BuybackStart = 69
    Chest = 4
    Feet = 7
    FingerLeft = 10
    FingerRight = 11
    Hands = 9
    Head = 0
    ItemsEnd = 261
    Legs = 6
    MainHand = 15
    Neck = 1
    None = -1
    OffHand = 16
    Ranged = 17
    Shirt = 3
    Shoulders = 2
    Tabard = 18
    TrinketLeft = 12
    TrinketRight = 13
    Waist = 5
    Wrists = 8
End Enum
Enum EnviromentalDamage
    DAMAGE_EXHAUSTED = 0
    DAMAGE_DROWNING = 1
    DAMAGE_FALL = 2
    DAMAGE_LAVA = 3
    DAMAGE_SLIME = 4
    DAMAGE_FIRE = 5
End Enum

