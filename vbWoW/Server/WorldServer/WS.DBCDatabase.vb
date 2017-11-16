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

Public Module WS_DBCDatabase
    Public Regenerator As TRegenerator
    Public AIManager As TAIManager
    Public SpellManager As TSpellManager
    Public Spawner As TSpawner

    Public Const DurabilityCosts_MAX As Integer = 300
    Public DurabilityCosts(DurabilityCosts_MAX, 28) As Short

#Region "Emotes"
    Public EmotesText As New Hashtable
    Public Enum Emotes As Integer
        'Auto generated from Emotes.dbc
        STATE_WORK_NOSHEATHE_MINING = 233
        ONESHOT_READYRIFLE = 213
        STATE_READYRIFLE = 214
        STATE_WORK_NOSHEATHE_CHOPWOOD = 234
        STATE_READY1H = 333
        STATE_SUBMERGED = 373
        ONESHOT_NONE = 0
        ONESHOT_TALK = 1
        ONESHOT_BOW = 2
        ONESHOT_WAVE = 3
        ONESHOT_CHEER = 4
        ONESHOT_EXCLAMATION = 5
        ONESHOT_QUESTION = 6
        ONESHOT_EAT = 7
        STATE_SPELLPRECAST = 193
        ONESHOT_LAND = 293
        STATE_DANCE = 10
        ONESHOT_LAUGH = 11
        STATE_SLEEP = 12
        STATE_SIT = 13
        ONESHOT_RUDE = 14
        ONESHOT_ROAR = 15
        ONESHOT_KNEEL = 16
        ONESHOT_KISS = 17
        ONESHOT_CRY = 18
        ONESHOT_CHICKEN = 19
        ONESHOT_BEG = 20
        ONESHOT_APPLAUD = 21
        ONESHOT_SHOUT = 22
        ONESHOT_FLEX = 23
        ONESHOT_SHY = 24
        ONESHOT_POINT = 25
        STATE_STAND = 26
        STATE_READYUNARMED = 27
        STATE_WORK = 28
        STATE_POINT = 29
        STATE_NONE = 30
        ONESHOT_WOUND = 33
        ONESHOT_WOUNDCRITICAL = 34
        ONESHOT_ATTACKUNARMED = 35
        ONESHOT_ATTACK1H = 36
        ONESHOT_ATTACK2HTIGHT = 37
        ONESHOT_ATTACK2HLOOSE = 38
        ONESHOT_PARRYUNARMED = 39
        ONESHOT_PARRYSHIELD = 43
        ONESHOT_READYUNARMED = 44
        ONESHOT_READY1H = 45
        ONESHOT_READYBOW = 48
        ONESHOT_SPELLPRECAST = 50
        ONESHOT_SPELLCAST = 51
        ONESHOT_BATTLEROAR = 53
        ONESHOT_SPECIALATTACK1H = 54
        ONESHOT_KICK = 60
        ONESHOT_ATTACKTHROWN = 61
        STATE_STUN = 64
        STATE_DEAD = 65
        ONESHOT_SALUTE = 66
        STATE_KNEEL = 68
        STATE_USESTANDING = 69
        ONESHOT_WAVE_NOSHEATHE = 70
        ONESHOT_CHEER_NOSHEATHE = 71
        ONESHOT_EAT_NOSHEATHE = 92
        STATE_STUN_NOSHEATHE = 93
        ONESHOT_DANCE = 94
        ONESHOT_SALUTE_NOSHEATH = 113
        STATE_USESTANDING_NOSHEATHE = 133
        ONESHOT_LAUGH_NOSHEATHE = 153
        STATE_WORK_NOSHEATHE = 173
        zzOLDONESHOT_LIFTOFF = 253
        ONESHOT_LIFTOFF = 254
        ONESHOT_YES = 273
        ONESHOT_NO = 274
        ONESHOT_TRAIN = 275
        STATE_AT_EASE = 313
        STATE_SPELLKNEELSTART = 353
        ONESHOT_SUBMERGE = 374
    End Enum
    Public Enum EmoteStates As Integer
        ANIM_STAND = &H0
        ANIM_DEATH = &H1
        ANIM_SPELL = &H2
        ANIM_STOP = &H3
        ANIM_WALK = &H4
        ANIM_RUN = &H5
        ANIM_DEAD = &H6
        ANIM_RISE = &H7
        ANIM_STANDWOUND = &H8
        ANIM_COMBATWOUND = &H9
        ANIM_COMBATCRITICAL = &HA
        ANIM_SHUFFLE_LEFT = &HB
        ANIM_SHUFFLE_RIGHT = &HC
        ANIM_WALK_BACKWARDS = &HD
        ANIM_STUN = &HE
        ANIM_HANDS_CLOSED = &HF
        ANIM_ATTACKUNARMED = &H10
        ANIM_ATTACK1H = &H11
        ANIM_ATTACK2HTIGHT = &H12
        ANIM_ATTACK2HLOOSE = &H13
        ANIM_PARRYUNARMED = &H14
        ANIM_PARRY1H = &H15
        ANIM_PARRY2HTIGHT = &H16
        ANIM_PARRY2HLOOSE = &H17
        ANIM_PARRYSHIELD = &H18
        ANIM_READYUNARMED = &H19
        ANIM_READY1H = &H1A
        ANIM_READY2HTIGHT = &H1B
        ANIM_READY2HLOOSE = &H1C
        ANIM_READYBOW = &H1D
        ANIM_DODGE = &H1E
        ANIM_SPELLPRECAST = &H1F
        ANIM_SPELLCAST = &H20
        ANIM_SPELLCASTAREA = &H21
        ANIM_NPCWELCOME = &H22
        ANIM_NPCGOODBYE = &H23
        ANIM_BLOCK = &H24
        ANIM_JUMPSTART = &H25
        ANIM_JUMP = &H26
        ANIM_JUMPEND = &H27
        ANIM_FALL = &H28
        ANIM_SWIMIDLE = &H29
        ANIM_SWIM = &H2A
        ANIM_SWIM_LEFT = &H2B
        ANIM_SWIM_RIGHT = &H2C
        ANIM_SWIM_BACKWARDS = &H2D
        ANIM_ATTACKBOW = &H2E
        ANIM_FIREBOW = &H2F
        ANIM_READYRIFLE = &H30
        ANIM_ATTACKRIFLE = &H31
        ANIM_LOOT = &H32
        ANIM_SPELL_PRECAST_DIRECTED = &H33
        ANIM_SPELL_PRECAST_OMNI = &H34
        ANIM_SPELL_CAST_DIRECTED = &H35
        ANIM_SPELL_CAST_OMNI = &H36
        ANIM_SPELL_BATTLEROAR = &H37
        ANIM_SPELL_READYABILITY = &H38
        ANIM_SPELL_SPECIAL1H = &H39
        ANIM_SPELL_SPECIAL2H = &H3A
        ANIM_SPELL_SHIELDBASH = &H3B
        ANIM_EMOTE_TALK = &H3C
        ANIM_EMOTE_EAT = &H3D
        ANIM_EMOTE_WORK = &H3E
        ANIM_EMOTE_USE_STANDING = &H3F
        ANIM_EMOTE_EXCLAMATION = &H40
        ANIM_EMOTE_QUESTION = &H41
        ANIM_EMOTE_BOW = &H42
        ANIM_EMOTE_WAVE = &H43
        ANIM_EMOTE_CHEER = &H44
        ANIM_EMOTE_DANCE = &H45
        ANIM_EMOTE_LAUGH = &H46
        ANIM_EMOTE_SLEEP = &H47
        ANIM_EMOTE_SIT_GROUND = &H48
        ANIM_EMOTE_RUDE = &H49
        ANIM_EMOTE_ROAR = &H4A
        ANIM_EMOTE_KNEEL = &H4B
        ANIM_EMOTE_KISS = &H4C
        ANIM_EMOTE_CRY = &H4D
        ANIM_EMOTE_CHICKEN = &H4E
        ANIM_EMOTE_BEG = &H4F
        ANIM_EMOTE_APPLAUD = &H50
        ANIM_EMOTE_SHOUT = &H51
        ANIM_EMOTE_FLEX = &H52
        ANIM_EMOTE_SHY = &H53
        ANIM_EMOTE_POINT = &H54
        ANIM_ATTACK1HPIERCE = &H55
        ANIM_ATTACK2HLOOSEPIERCE = &H56
        ANIM_ATTACKOFF = &H57
        ANIM_ATTACKOFFPIERCE = &H58
        ANIM_SHEATHE = &H59
        ANIM_HIPSHEATHE = &H5A
        ANIM_MOUNT = &H5B
        ANIM_RUN_LEANRIGHT = &H5C
        ANIM_RUN_LEANLEFT = &H5D
        ANIM_MOUNT_SPECIAL = &H5E
        ANIM_KICK = &H5F
        ANIM_SITDOWN = &H60
        ANIM_SITTING = &H61
        ANIM_SITUP = &H62
        ANIM_SLEEPDOWN = &H63
        ANIM_SLEEPING = &H64
        ANIM_SLEEPUP = &H65
        ANIM_SITCHAIRLOW = &H66
        ANIM_SITCHAIRMEDIUM = &H67
        ANIM_SITCHAIRHIGH = &H68
        ANIM_LOADBOW = &H69
        ANIM_LOADRIFLE = &H6A
        ANIM_ATTACKTHROWN = &H6B
        ANIM_READYTHROWN = &H6C
        ANIM_HOLDBOW = &H6D
        ANIM_HOLDRIFLE = &H6E
        ANIM_HOLDTHROWN = &H6F
        ANIM_LOADTHROWN = &H70
        ANIM_EMOTE_SALUTE = &H71
        ANIM_KNEELDOWN = &H72
        ANIM_KNEELING = &H73
        ANIM_KNEELUP = &H74
        ANIM_ATTACKUNARMEDOFF = &H75
        ANIM_SPECIALUNARMED = &H76
        ANIM_STEALTHWALK = &H77
        ANIM_STEALTHSTAND = &H78
        ANIM_KNOCKDOWN = &H79
        ANIM_EATING = &H7A
        ANIM_USESTANDINGLOOP = &H7B
        ANIM_CHANNELCASTDIRECTED = &H7C
        ANIM_CHANNELCASTOMNI = &H7D
        ANIM_WHIRLWIND = &H7E
        ANIM_BIRTH = &H7F
        ANIM_USESTANDINGSTART = &H80
        ANIM_USESTANDINGEND = &H81
        ANIM_HOWL = &H82
        ANIM_DROWN = &H83
        ANIM_DROWNED = &H84
        ANIM_FISHINGCAST = &H85
        ANIM_FISHINGLOOP = &H86
    End Enum
#End Region
#Region "Skills"
    Public Enum SKILL_LineCategory
        ATTRIBUTES = 5
        WEAPON_SKILLS = 6
        CLASS_SKILLS = 7
        ARMOR_PROFICIENCES = 8
        SECONDARY_SKILLS = 9
        LANGUAGES = 10
        PROFESSIONS = 11
        NOT_DISPLAYED = 12
    End Enum
    Public Enum SKILL_IDs As Integer
        SKILL_FROST = 6
        SKILL_FIRE = 8
        SKILL_ARMS = 26
        SKILL_COMBAT = 38
        SKILL_SUBTLETY = 39
        SKILL_POISONS = 40
        SKILL_SWORDS = 43                  ' Higher weapon skill increases your chance to hit.
        SKILL_AXES = 44                    ' Higher weapon skill increases your chance to hit.
        SKILL_BOWS = 45                    ' Higher weapon skill increases your chance to hit.
        SKILL_GUNS = 46                    ' Higher weapon skill increases your chance to hit.
        SKILL_BEAST_MASTERY = 50
        SKILL_SURVIVAL = 51
        SKILL_MACES = 54                   ' Higher weapon skill increases your chance to hit.
        SKILL_TWO_HANDED_SWORDS = 55       ' Higher weapon skill increases your chance to hit.
        SKILL_HOLY = 56
        SKILL_SHADOW_MAGIC = 78
        SKILL_DEFENSE = 95                 ' Higher defense makes you harder to hit and makes monsters less likely to land a crushing blow.
        SKILL_LANGUAGE_COMMON = 98
        SKILL_DWARVEN_RACIAL = 101
        SKILL_LANGUAGE_ORCISH = 109
        SKILL_LANGUAGE_DWARVEN = 111
        SKILL_LANGUAGE_DARNASSIAN = 113
        SKILL_LANGUAGE_TAURAHE = 115
        SKILL_DUAL_WIELD = 118
        SKILL_TAUREN_RACIAL = 124
        SKILL_ORC_RACIAL = 125
        SKILL_NIGHT_ELF_RACIAL = 126
        SKILL_FIRST_AID = 129               ' Higher first aid skill allows you to learn higher level first aid abilities.  First aid abilities can be found on trainers around the world as well as from quests and as drops from monsters.
        SKILL_FERAL_COMBAT = 134
        SKILL_STAVES = 136                  ' Higher weapon skill increases your chance to hit.
        SKILL_LANGUAGE_THALASSIAN = 137
        SKILL_LANGUAGE_DRACONIC = 138
        SKILL_LANGUAGE_DEMON_TONGUE = 139
        SKILL_LANGUAGE_TITAN = 140
        SKILL_LANGUAGE_OLD_TONGUE = 141
        SKILL_SURVIVAL_1 = 142
        SKILL_HORSE_RIDING = 148
        SKILL_WOLF_RIDING = 149
        SKILL_TIGER_RIDING = 150
        SKILL_RAM_RIDING = 152
        SKILL_SWIMMING = 155
        SKILL_TWO_HANDED_MACES = 160        ' Higher weapon skill increases your chance to hit.
        SKILL_UNARMED = 162                 ' Higher skill increases your chance to hit.
        SKILL_MARKSMANSHIP = 163
        SKILL_BLACKSMITHING = 164           ' Higher smithing skill allows you to learn higher level smithing plans.  Blacksmithing plans can be found on trainers around the world as well as from quests and monsters.
        SKILL_LEATHERWORKING = 165          ' Higher leatherworking skill allows you to learn higher level leatherworking patterns.  Leatherworking patterns can be found on trainers around the world as well as from quests and monsters.
        SKILL_ALCHEMY = 171                 ' Higher alchemy skill allows you to learn higher level alchemy recipes.  Alchemy recipes can be found on trainers around the world as well as from quests and monsters.
        SKILL_TWO_HANDED_AXES = 172         ' Higher weapon skill increases your chance to hit.
        SKILL_DAGGERS = 173                 ' Higher weapon skill increases your chance to hit.
        SKILL_THROWN = 176                  ' Higher weapon skill increases your chance to hit.
        SKILL_HERBALISM = 182               ' Higher herbalism skill allows you to harvest more difficult herbs around the world.  If you cannot harvest a specific herb
        SKILL_GENERIC_DND = 183
        SKILL_RETRIBUTION = 184
        SKILL_COOKING = 185                 ' Higher cooking skill allows you to learn higher level cooking recipes.  Recipes can be found on trainers around the world as well as from quests and as drops from monsters.
        SKILL_MINING = 186                  ' Higher mining skill allows you to harvest more difficult minerals nodes around the world.  If you cannot harvest a specific mineral
        SKILL_PET_IMP = 188
        SKILL_PET_FELHUNTER = 189
        SKILL_TAILORING = 197               ' Higher tailoring skill allows you to learn higher level tailoring patterns.  Tailoring patterns can be found on trainers around the world as well as from quests and monsters.
        SKILL_ENGINEERING = 202             ' Higher engineering skill allows you to learn higher level engineering schematics.  Schematics can be found on trainers around the world as well as from quests and monsters.
        SKILL_PET_SPIDER = 203
        SKILL_PET_VOIDWALKER = 204
        SKILL_PET_SUCCUBUS = 205
        SKILL_PET_INFERNAL = 206
        SKILL_PET_DOOMGUARD = 207
        SKILL_PET_WOLF = 208
        SKILL_PET_CAT = 209
        SKILL_PET_BEAR = 210
        SKILL_PET_BOAR = 211
        SKILL_PET_CROCILISK = 212
        SKILL_PET_CARRION_BIRD = 213
        SKILL_PET_CRAB = 214
        SKILL_PET_GORILLA = 215
        SKILL_PET_RAPTOR = 217
        SKILL_PET_TALLSTRIDER = 218
        SKILL_RACIAL_UNDEAD = 220
        SKILL_WEAPON_TALENTS = 222
        SKILL_CROSSBOWS = 226               ' Higher weapon skill increases your chance to hit.
        SKILL_SPEARS = 227
        SKILL_WANDS = 228
        SKILL_POLEARMS = 229                ' Higher weapon skill increases your chance to hit.
        SKILL_PET_SCORPID = 236
        SKILL_ARCANE = 237
        SKILL_PET_TURTLE = 251
        SKILL_ASSASSINATION = 253
        SKILL_FURY = 256
        SKILL_PROTECTION = 257
        SKILL_BEAST_TRAINING = 261
        SKILL_PROTECTION_1 = 267
        SKILL_PET_TALENTS = 270
        SKILL_PLATE_MAIL = 293              ' Allows the wearing of plate armor.
        SKILL_LANGUAGE_GNOMISH = 313
        SKILL_LANGUAGE_TROLL = 315
        SKILL_ENCHANTING = 333              ' Higher enchanting skill allows you to learn more powerful forumulas.  Formulas can be found on trainers around the world as well as from quests and monsters.
        SKILL_DEMONOLOGY = 354
        SKILL_AFFLICTION = 355
        SKILL_FISHING = 356                 ' Higher fishing skill increases your chance of catching fish in bodies of water around the world.  If you are having trouble catching fish in a given area
        SKILL_ENHANCEMENT = 373
        SKILL_RESTORATION = 374
        SKILL_ELEMENTAL_COMBAT = 375
        SKILL_SKINNING = 393                ' Higher skinning skill allows you to skin hides from higher level monsters around the world.    Once your skill is above 100
        SKILL_MAIL = 413                    ' Allows the wearing of mail armor.
        SKILL_LEATHER = 414                 ' Allows the wearing of leather armor.
        SKILL_CLOTH = 415                   ' Allows the wearing of cloth armor.
        SKILL_SHIELD = 433                  ' Allows the use of shields.
        SKILL_FIST_WEAPONS = 473            ' Allows for the use of fist weapons.  Chance to hit is determined by the Unarmed skill.
        SKILL_RAPTOR_RIDING = 533
        SKILL_MECHANOSTRIDER_PILOTING = 553
        SKILL_UNDEAD_HORSEMANSHIP = 554
        SKILL_RESTORATION_1 = 573
        SKILL_BALANCE = 574
        SKILL_DESTRUCTION = 593
        SKILL_HOLY_1 = 594
        SKILL_DISCIPLINE = 613
        SKILL_LOCKPICKING = 633
        SKILL_PET_BAT = 653
        SKILL_PET_HYENA = 654
        SKILL_PET_OWL = 655
        SKILL_PET_WIND_SERPENT = 656
        SKILL_LANGUAGE_GUTTERSPEAK = 673
        SKILL_KODO_RIDING = 713
        SKILL_RACIAL_TROLL = 733
        SKILL_RACIAL_GNOME = 753
        SKILL_RACIAL_HUMAN = 754
        SKILL_JEWELCRAFTING = 755
        SKILL_RACIAL_BLOODELF = 756
        SKILL_PET_EVENT_REMOTE_CONTROL = 758
        SKILL_LANGUAGE_DRAENEI = 759
        SKILL_RACIAL_DRAENEI = 760
        SKILL_PET_FELGUARD = 761
        SKILL_RIDING = 762
        SKILL_PET_DRAGONHAWK = 763
        SKILL_PET_NETHER_RAY = 764
        SKILL_PET_SPOREBAT = 765
        SKILL_PET_WARP_STALKER = 766
        SKILL_PET_RAVAGER = 767
        SKILL_PET_SERPENT = 768
        SKILL_INTERNAL = 769
    End Enum
    Public SkillLines As New Hashtable
#End Region
#Region "Graveyards"
    Public Graveyards As New ArrayList
    Public Class TGraveyard
        Public x As Single
        Public y As Single
        Public z As Single

#If HANDLED_MAP_ID = -1 Then
            Public Sub New(ByVal px As Single, ByVal py As Single, ByVal pz As Single,ByVal pMapID as Integer)
                x = px
                y = py
                z = pz
                MapID = pMapID
            End Sub
            Public MapID As Single
#Else
        Public Sub New(ByVal px As Single, ByVal py As Single, ByVal pz As Single, ByVal pMapID As Integer)
            x = px
            y = py
            z = pz
        End Sub
#End If
    End Class
    Public Sub GoToNearestGraveyard(ByVal Character As CharacterObject)
        Dim minDistance As Single = 9999999.0F
        Dim tmp As Single
        Dim selectedGraveyard As TGraveyard = Nothing

        For Each Graveyard As TGraveyard In Graveyards
            tmp = (Character.positionX - Graveyard.x) ^ 2 + (Character.positionY - Graveyard.y) ^ 2
            If tmp < minDistance Then
                minDistance = tmp
                selectedGraveyard = Graveyard
            End If
        Next
        Character.Teleport(selectedGraveyard.x, selectedGraveyard.y, selectedGraveyard.z, 0)
    End Sub
#End Region
#Region "Taxi"
    Public TaxiNodes As New ArrayList
    Public Class TTaxiNode
        Public x As Single
        Public y As Single
        Public z As Single
        Public ID As Short = 0

#If HANDLED_MAP_ID = -1 Then
            Public Sub New(ByVal px As Single, ByVal py As Single, ByVal pz As Single,ByVal pID as Short,ByVal pMapID as Integer)
                x = px
                y = py
                z = pz
                ID = pid
                MapID = pMapID
            End Sub
            Public MapID As Integer
#Else
        Public Sub New(ByVal px As Single, ByVal py As Single, ByVal pz As Single, ByVal pID As Short, ByVal pMapID As Integer)
            x = px
            y = py
            z = pz
            ID = pID
        End Sub
#End If
    End Class
    Public Function GetNearestTaxi(ByVal x As Single, ByVal y As Single) As Integer
        Dim minDistance As Single = 9999999.0F
        Dim selectedTaxiNode As Integer = 0
        Dim tmp As Single

        For Each TaxiNode As TTaxiNode In TaxiNodes
            tmp = (x - TaxiNode.x) + (y - TaxiNode.y)
            If tmp < minDistance Then
                minDistance = tmp
                selectedTaxiNode = TaxiNode.ID
            End If
        Next
        Return selectedTaxiNode
    End Function
#End Region
#Region "Talents"
    Public TalentsTab As New Hashtable(30)
    Public Talents As New Hashtable(500)
    Public Class TalentInfo
        Public TalentID As Integer
        Public TalentTab As Integer
        Public Row As Integer
        Public Col As Integer
        Public RankID(4) As Integer
        Public RequiredTalent(2) As Integer
        Public RequiredPoints(2) As Integer
    End Class
#End Region
#Region "Factions"
    Public Const FACTION_TEMPLATES_COUNT As Integer = 1852
    Enum FactionTemplates
        ' Fields
        Alliance = 115
        AllianceForces = 210
        Ambient = 188
        ArgentDawn = 794
        BattlegroundNeutral = 27
        Beast = 32
        BlacksmithingArmorSmithing = 46
        BlacksmithingAxeSmithing = 570
        BlacksmithingHammerSmithing = 569
        BlacksmithingSwordSmithing = 571
        BlacksmithingWeaponSmithing = 289
        BloodsailBuccaneers = 119
        BootyBay = 121
        BroodOfNozdormu = 1601
        CaerDarrow = 25
        CenarionCircle = 1254
        DarkmoonFairy = 1555
        DarkspearTrolls = 126
        Darnasus = 124
        DefiasBrotherhood = 27
        EngineeringGnome = 551
        EngineeringGoblin = 550
        Everlook = 63
        EvilBeast = 44
        [Friend] = 35
        FrostwolfClan = 26
        Gadgetzan = 61
        GelkisClanCentaur = 132
        GellisClanCentaur = 132
        GnomereganExiles = 23
        Horde = 6
        HordeForces = 106
        HydraxianWaterlords = 42
        IronForge = 57
        LeatherworkingDragonScale = 86
        LeatherworkingElemental = 83
        LeatherworkingTribal = 549
        MagranClanCentaure = 133
        Monster = 60
        MoroGai = 62
        NoFaction = 188
        Ogrimmar = 85
        Player_Dwarf = 3
        Player_Elf = 4
        Player_Gnome = 115
        Player_Human = 1
        Player_Orc = 2
        Player_Tauren = 6
        Player_Troll = 116
        Player_Undead = 5
        Prey = 31
        Ratchet = 69
        RavasaurTrainers = 36
        Ravenholdt = 43
        RevantuskTrolls = 1494
        ScarletCrusade = 89
        ShatterspearTrolls = 33
        Shendralar = 34
        SilverwingSentinels = 1514
        SteamWheedleCartel = 64
        StormpikeGuard = 41
        Stormwind = 12
        Syndicate = 108
        TheDefilers = 1598
        TheLeagueOfArathor = 1577
        ThoriumBrotherhood = 37
        ThunderBluff = 105
        ThundermawFurbolgs = 38
        TimbermawFurbolgs = 38
        UndeadScourge = 233
        Undercity = 98
        WarsongOutriders = 1515
        WildHammerClan = 39
        WinterSaberTrainers = 40
        ZandalarTribe = 1574
    End Enum                    'factionTemplates.dbc       'Used in CREATUREs Database as Faction
    Public FactionTemplatesInfo(FACTION_TEMPLATES_COUNT) As Integer
    Public ReactionTable(FACTION_TEMPLATES_COUNT, FACTION_TEMPLATES_COUNT) As TReaction
    Public Enum TReaction As Byte
        HOSTILE = 0
        NEUTRAL = 1
        FRIENDLY = 2
        FIGHT_SUPPORT = 3
    End Enum

    Enum Factions
        PLAYER_Human = 1
        PLAYER_Orc = 2
        PLAYER_Dwarf = 3
        PLAYER_NightElf = 4
        PLAYER_Undead = 5
        PLAYER_Tauren = 6
        Creature = 7
        PLAYER_Gnome = 8
        PLAYER_Troll = 9
        Monster = 14
        DefiasBrotherhood = 15
        Gnoll_Riverpaw = 16
        Gnoll_Redridge = 17
        Gnoll_Shadowhide = 18
        Murloc = 19
        Undead_Scourge = 20
        BootyBay = 21
        Beast_Spider = 22
        Beast_Boar = 23
        Worgen = 24
        Kobold = 25
        Troll_Bloodscalp = 26
        Troll_Skullsplitter = 27
        Prey = 28
        Beast_Wolf = 29
        DefiasBrotherhoodTraitor = 30
        Friendly = 31
        Trogg = 32
        Troll_Frostmane = 33
        Orc_Blackrock = 34
        Villian = 35
        Victim = 36
        Beast_Bear = 37
        Ogre = 38
        Kurzen_sMercenaries = 39
        Escortee = 40
        VentureCompany = 41
        Beast_Raptor = 42
        Basilisk = 43
        Dragonflight_Green = 44
        LostOnes = 45
        Blacksmithing_Armorsmithing = 46
        Ironforge = 47
        DarkIronDwarves = 48
        Human_NightWatch = 49
        Dragonflight_Red = 50
        Gnoll_Mosshide = 51
        Orc_Dragonmaw = 52
        Gnome_Leper = 53
        GnomereganExiles = 54
        Leopard = 55
        ScarletCrusade = 56
        Gnoll_Rothide = 57
        Beast_Gorilla = 58
        ThoriumBrotherhood = 59
        Naga = 60
        Dalaran = 61
        ForlornSpirit = 62
        Darkhowl = 63
        Grell = 64
        Furbolg = 65
        HordeGeneric = 66
        Horde = 67
        Undercity = 68
        Darnassus = 69
        Syndicate = 70
        HillsbradMilitia = 71
        Stormwind = 72
        Demon = 73
        Elemental = 74
        Spirit = 75
        Orgrimmar = 76
        Treasure = 77
        Gnoll_Mudsnout = 78
        HIllsbrad_SouthshoreMayor = 79
        Dragonflight_Black = 80
        ThunderBluff = 81
        Troll_Witherbark = 82
        Leatherworking_Elemental = 83
        Quilboar_Razormane = 84
        Quilboar_Bristleback = 85
        Leatherworking_Dragonscale = 86
        BloodsailBuccaneers = 87
        Blackfathom = 88
        Makrura = 89
        Centaur_Kolkar = 90
        Centaur_Galak = 91
        GelkisClanCentaur = 92
        MagramClanCentaur = 93
        Maraudine = 94
        Theramore = 108
        Quilboar_Razorfen = 109
        Quilboar_Razormane2 = 110
        Quilboar_Deathshead = 111
        Enemy = 128
        Ambient = 148
        NethergardeCaravan = 168
        SteamwheedleCartel = 169
        AllianceGeneric = 189
        Nethergarde = 209
        WailingCaverns = 229
        Silithid = 249
        SilvermoonRemnant = 269
        ZandalarTribe = 270
        Blacksmithing_Weaponsmithing = 289
        Scorpid = 309
        Beast_Bat = 310
        Titan = 311
        TaskmasterFizzule = 329
        Ravenholdt = 349
        Gadgetzan = 369
        GnomereganBug = 389
        Harpy = 409
        BurningBlade = 429
        ShadowsilkPoacher = 449
        SearingSpider = 450
        Alliance = 469
        Ratchet = 470
        WildhammerClan = 471
        Goblin_DarkIronBarPatron = 489
        TheLeagueofArathor = 509
        TheDefilers = 510
        Giant = 511
        ArgentDawn = 529
        DarkspearTrolls = 530
        Dragonflight_Bronze = 531
        Dragonflight_Blue = 532
        Leatherworking_Tribal = 549
        Engineering_Goblin = 550
        Engineering_Gnome = 551
        Blacksmithing_Hammersmithing = 569
        Blacksmithing_Axesmithing = 570
        Blacksmithing_Swordsmithing = 571
        Troll_Vilebranch = 572
        SouthseaFreebooters = 573
        CaerDarrow = 574
        Furbolg_Uncorrupted = 575
        TimbermawHold = 576
        Everlook = 577
        WintersaberTrainers = 589
        CenarionCircle = 609
        ShatterspearTrolls = 629
        RavasaurTrainers = 630
        MajordomoExecutus = 649
        Beast_CarrionBird = 669
        Beast_Cat = 670
        Beast_Crab = 671
        Beast_Crocilisk = 672
        Beast_Hyena = 673
        Beast_Owl = 674
        Beast_Scorpid = 675
        Beast_Tallstrider = 676
        Beast_Turtle = 677
        Beast_WindSerpent = 678
        TrainingDummy = 679
        Dragonflight_Black_Bait = 689
        BattlegroundNeutral = 709
        FrostwolfClan = 729
        StormpikeGuard = 730
        HydraxianWaterlords = 749
        SulfuronFirelords = 750
        Gizlock_sDummy = 769
        Gizlock_sCharm = 770
        Gizlock = 771
        Moro_gai = 789
        SpiritGuide_Alliance = 790
        Shen_dralar = 809
        OgreCaptainKromcrush = 829
        SpiritGuide_Horde = 849
        Jaedenar = 869
        WarsongOutriders = 889
        SilverwingSentinels = 890
        AllianceForces = 891
        HordeForces = 892
        RevantuskTrolls = 893
        DarkmoonFaire = 909
        BroodofNozdormu = 910
        SilvermoonCity = 911
        MightofKalimdor = 912
        PLAYER_BloodElf = 914
        ArmiesofC_Thun = 915
        SilithidAttackers = 916
        TheIronforgeBrigade = 917
        RCEnemies = 918
        RCObjects = 919
        Red = 920
        Blue = 921
        Tranquillien = 922
        Farstriders = 923
        DEPRECATED = 924
        Sunstriders = 925
        Magister_sGuild = 926
        PLAYER_Draenei = 927
        ScourgeInvaders = 928
        BloodmaulClan = 929
        Exodar = 930
        TestFactionnotarealfaction = 931
        TheAldor = 932
        TheConsortium = 933
        TheScryers = 934
        TheSha_tar = 935
        ShattrathCity = 936
        Troll_Forest = 937
        TheOmenai = 938
        'DEPRECATED = 939
        TheSonsofLothar = 940
        TheMag_har = 941
        CenarionExpedition = 942
        FelOrc = 943
        FelOrcGhost = 944
        SonsofLotharGhosts = 945
        HonorHold = 946
        Thrallmar = 947
        TestFaction2 = 948
        TestFaction1 = 949
        ToWoW_Flag = 950
        ToWoW_FlagTriggerAllianceDND = 951
        TestFaction3 = 952
        TestFaction4 = 953
        ToWoW_FlagTriggerHordeDND = 954
        Broken = 955
        Ethereum = 956
        EarthElemental = 957
        FightingRobots = 958
        ActorGood = 959
        ActorEvil = 960
        StillpineFurbolg = 961
        CrazedOwlkin = 962
        ChessAlliance = 963
        ChessHorde = 964
        MonsterSpar = 965
        MonsterSparBuddy = 966
        TheVioletEye = 967
        Sunhawks = 968
        HandofArgus = 969
        Sporeggar = 970
        FungalGiant = 971
        SporeBat = 972
        Monster_Predator = 973
        Monster_Prey = 974
        VoidAnomaly = 975
        HyjalDefenders = 976
        HyjalInvaders = 977
        Kurenai = 978
        EarthenRing = 979
        Outland = 980
        Arakkoa = 981
        ZangarmarshBannerAlliance = 982
        ZangarmarshBannerHorde = 983
        ZangarmarshBannerNeutral = 984
        CavernsofTime_Thrall = 985
        CavernsofTime_Durnholde = 986
        CavernsofTime_SouthshoreGuards = 987
        ShadowCouncilCovert = 988
        KeepersofTime = 989
        TheScaleoftheSands = 990
        DarkPortalDefender_Alliance = 991
        DarkPortalDefender_Horde = 992
        DarkPortalAttacker_Legion = 993
        InciterTrigger = 994
        InciterTrigger2 = 995
        InciterTrigger3 = 996
        InciterTrigger4 = 997
        InciterTrigger5 = 998
        ManaCreature = 999
        Khadgar_sServant = 1000
        BladespireClan = 1001
        EthereumSparbuddy = 1002
        Protectorate = 1003
        ArcaneAnnihilatorDNR = 1004
        Friendly_Hidden = 1005
        Kirin_Var_Dathric = 1006
        Kirin_Var_Belmara = 1007
        Kirin_Var_Luminrath = 1008
        Kirin_Var_Cohlien = 1009
        ServantofIllidan = 1010
        LowerCity = 1011
        AshtongueDeathsworn = 1012
        SpiritsofShadowmoon1 = 1013
        SpiritsofShadowmoon2 = 1014
        Netherwing = 1015
        Wyrmcult = 1016
        Treant = 1017
        LeotherasDemonI = 1018
        LeotherasDemonII = 1019
        LeotherasDemonIII = 1020
        LeotherasDemonIV = 1021
        LeotherasDemonV = 1022
        Azaloth = 1023
        RockFlayer = 1024
        FlayerHunter = 1025
        ShadowmoonShade = 1026
        LegionCommunicator = 1027
        RavenswoodAncients = 1028
        Chess_FriendlytoAllChess = 1029

    End Enum                            'factions.dbc
    Public FactionInfo As New Hashtable
    Public Class TFaction
        Public ID As Short
        Public VisibleID As Short
        Public flags(3) As Short
        Public rep_stats(3) As Integer
        Public rep_flags(3) As Byte

        Public Sub New(ByVal Id_ As Short, ByVal VisibleID_ As Short, ByVal flags1 As Integer, ByVal flags2 As Integer, ByVal flags3 As Integer, ByVal flags4 As Integer, ByVal rep_stats1 As Integer, ByVal rep_stats2 As Integer, ByVal rep_stats3 As Integer, ByVal rep_stats4 As Integer, ByVal rep_flags1 As Integer, ByVal rep_flags2 As Integer, ByVal rep_flags3 As Integer, ByVal rep_flags4 As Integer)
            ID = Id_
            VisibleID = VisibleID_
            flags(0) = flags1
            flags(1) = flags2
            flags(2) = flags3
            flags(3) = flags4
            rep_stats(0) = rep_stats1
            rep_stats(1) = rep_stats2
            rep_stats(2) = rep_stats3
            rep_stats(3) = rep_stats4
            rep_flags(0) = rep_flags1
            rep_flags(1) = rep_flags2
            rep_flags(2) = rep_flags3
            rep_flags(3) = rep_flags4
        End Sub
    End Class
#End Region
#Region "MapAreas"
    Public AreaTable As New Hashtable
    Public Class TArea
        Public ID As Integer
        Public Level As Byte
        Public Zone As Integer

        Public ZoneType As Integer
        Public Team As AreaTeam

        Public Enum AreaTeam As Integer
            AREATEAM_NONE = 0
            AREATEAM_ALLY = 2
            AREATEAM_HORDE = 4
        End Enum
        Public Function IsMyLand(ByRef c As CharacterObject) As Boolean
            If Team = AreaTeam.AREATEAM_NONE Then Return False
            If c.Side = False Then Return Team = AreaTeam.AREATEAM_ALLY
            If c.Side = True Then Return Team = AreaTeam.AREATEAM_HORDE
        End Function
        Public Function IsCity()
            Return ZoneType = 312
        End Function
    End Class



    Public Class TMapTile
        Implements IDisposable

        Public Const SIZE As Single = 533.3333F
        Public Const RESOLUTION_ZMAP As Integer = 64 - 1
        Public Const RESOLUTION_WATER As Integer = 128 - 1
        Public Const RESOLUTION_FLAGS As Integer = 16 - 1
        Public Const RESOLUTION_TERRAIN As Integer = 16 - 1

        'TWorld contains 64x64 TMapTile(s)
        Public AreaFlag(RESOLUTION_FLAGS, RESOLUTION_FLAGS) As Short
        Public AreaTerrain(RESOLUTION_TERRAIN, RESOLUTION_TERRAIN) As Byte
        Public WaterLevel(RESOLUTION_WATER, RESOLUTION_WATER) As Single
        Public ZCoord(RESOLUTION_ZMAP, RESOLUTION_ZMAP) As Single
        Public PlayersHere As New ArrayList
        Public CreaturesHere As New ArrayList
        Public GameObjectsHere As New ArrayList

        Public Sub New(ByVal fileName As String)
            If Dir("maps\" & fileName) = "" Then
                Me.Dispose()
                Exit Sub
            End If

            Log.WriteLine(LogType.INFORMATION, "Loading map file [{0}]...", fileName)

            Dim fileNum As Integer = FreeFile()
            FileOpen(fileNum, "maps\" & fileName, OpenMode.Binary, OpenAccess.Read)

            Dim fileVersion As Long
            FileGet(fileNum, fileVersion)

            'Dim x As Integer
            'Dim y As Integer

            'NOTE:  Reading all the array is faster but system is reading arrays inverted like:
            '       They must be read:  [0,0] [0,1] [0,2] [0,3] ...
            '       They are  read:     [0,0] [1,0] [2,0] [3,0] ...


            'For x = 0 To 15
            '    For y = 0 To 15
            '        FileGet(fileNum, AreaFlag(x, y))
            '    Next y
            'Next x
            FileGet(fileNum, AreaFlag)

            'For x = 0 To 15
            '    For y = 0 To 15
            '        FileGet(fileNum, AreaTerrain(x, y))
            '    Next y
            'Next x
            FileGet(fileNum, AreaTerrain)

            'For x = 0 To 15
            '    For y = 0 To 15
            '        FileGet(fileNum, WaterLevel(x, y))
            '    Next y
            'Next x
            FileGet(fileNum, WaterLevel)

            'For x = 0 To TMapTile_Resolution
            '    For y = 0 To TMapTile_Resolution
            '        FileGet(fileNum, ZCoord(x, y))
            '    Next y
            'Next x
            FileGet(fileNum, ZCoord)

            FileClose(fileNum)
        End Sub
        Public Sub Dispose() Implements System.IDisposable.Dispose

        End Sub


        Public Shared Sub AddPlayer(ByRef packet As PacketClass, ByVal CellX As Byte, ByVal CellY As Byte, ByVal PosX As Single, ByVal PosY As Single)
            'TODO: Loop this, +-1 cells, check dist
            Dim index As Integer = -1
            While index < MapTiles(CellX, CellY).PlayersHere.Count
                Try
                    Dim cGUID As Long = MapTiles(CellX, CellY).PlayersHere.Item(index)


                Finally
                    index += 1
                End Try
            End While

        End Sub
    End Class

    Public MapTiles(63, 63) As TMapTile

    Public Sub GetMapTile(ByVal x As Single, ByVal y As Single, ByRef MapTileX As Byte, ByRef MapTileY As Byte)
        'How to calculate where is X,Y:
        MapTileX = Fix(32 - (x / TMapTile.SIZE))
        MapTileY = Fix(32 - (y / TMapTile.SIZE))
    End Sub
    Public Function GetMapTileX(ByVal x As Single) As Byte
        Return Fix(32 - (x / TMapTile.SIZE))
    End Function
    Public Function GetMapTileY(ByVal y As Single) As Byte
        Return Fix(32 - (y / TMapTile.SIZE))
    End Function
    Public Function GetSubMapTileX(ByVal x As Single) As Byte
        Return Fix(TMapTile.RESOLUTION_ZMAP * (32 - (x / TMapTile.SIZE) - Fix(32 - (x / TMapTile.SIZE))))
    End Function
    Public Function GetSubMapTileY(ByVal y As Single) As Byte
        Return Fix(TMapTile.RESOLUTION_ZMAP * (32 - (y / TMapTile.SIZE) - Fix(32 - (y / TMapTile.SIZE))))
    End Function
    Public Function GetZCoord(ByVal x As Single, ByVal y As Single) As Single
        Dim MapTileX As Byte = Fix(32 - (x / TMapTile.SIZE))
        Dim MapTileY As Byte = Fix(32 - (y / TMapTile.SIZE))
        Dim MapTile_LocalX As Byte = CType(TMapTile.RESOLUTION_ZMAP * (32 - (x / TMapTile.SIZE) - MapTileX), Byte)
        Dim MapTile_LocalY As Byte = CType(TMapTile.RESOLUTION_ZMAP * (32 - (y / TMapTile.SIZE) - MapTileY), Byte)

        If MapTiles(MapTileX, MapTileY) Is Nothing Then Return 0
        'Return MapTiles(MapTileX, MapTileY).ZCoord(MapTile_LocalX, MapTile_LocalY)

        'NOTE: Using inverted arrays
        Return MapTiles(MapTileX, MapTileY).ZCoord(MapTile_LocalY, MapTile_LocalX)
    End Function
    Public Function GetWaterLevel(ByVal x As Single, ByVal y As Single) As Single
        Dim MapTileX As Byte = Fix(32 - (x / TMapTile.SIZE))
        Dim MapTileY As Byte = Fix(32 - (y / TMapTile.SIZE))
        Dim MapTile_LocalX As Byte = CType(TMapTile.RESOLUTION_WATER * (32 - (x / TMapTile.SIZE) - MapTileX), Byte)
        Dim MapTile_LocalY As Byte = CType(TMapTile.RESOLUTION_WATER * (32 - (y / TMapTile.SIZE) - MapTileY), Byte)

        If MapTiles(MapTileX, MapTileY) Is Nothing Then Return 0
        'Return MapTiles(MapTileX, MapTileY).WaterLevel(MapTile_LocalX, MapTile_LocalY)

        'NOTE: Using inverted arrays
        Return MapTiles(MapTileX, MapTileY).WaterLevel(MapTile_LocalY, MapTile_LocalX)
    End Function
    Public Function GetTerrainType(ByVal x As Single, ByVal y As Single) As Byte
        Dim MapTileX As Byte = Fix(32 - (x / TMapTile.SIZE))
        Dim MapTileY As Byte = Fix(32 - (y / TMapTile.SIZE))
        Dim MapTile_LocalX As Byte = CType(TMapTile.RESOLUTION_TERRAIN * (32 - (x / TMapTile.SIZE) - MapTileX), Byte)
        Dim MapTile_LocalY As Byte = CType(TMapTile.RESOLUTION_TERRAIN * (32 - (y / TMapTile.SIZE) - MapTileY), Byte)

        If MapTiles(MapTileX, MapTileY) Is Nothing Then Return 0
        'Return MapTiles(MapTileX, MapTileY).AreaTerrain(MapTile_LocalX, MapTile_LocalY)

        'NOTE: Using inverted arrays
        Return MapTiles(MapTileX, MapTileY).AreaTerrain(MapTile_LocalY, MapTile_LocalX)
    End Function
    Public Function GetAreaFlag(ByVal x As Single, ByVal y As Single) As Integer
        Dim MapTileX As Byte = Fix(32 - (x / TMapTile.SIZE))
        Dim MapTileY As Byte = Fix(32 - (y / TMapTile.SIZE))
        Dim MapTile_LocalX As Byte = CType(TMapTile.RESOLUTION_FLAGS * (32 - (x / TMapTile.SIZE) - MapTileX), Byte)
        Dim MapTile_LocalY As Byte = CType(TMapTile.RESOLUTION_FLAGS * (32 - (y / TMapTile.SIZE) - MapTileY), Byte)

        If MapTiles(MapTileX, MapTileY) Is Nothing Then Return 0
        'Return MapTiles(MapTileX, MapTileY).AreaFlag(MapTile_LocalX, MapTile_LocalY)

        'NOTE: Using inverted arrays
        Return MapTiles(MapTileX, MapTileY).AreaFlag(MapTile_LocalY, MapTile_LocalX)
    End Function

#End Region



    Public Sub InitializeInternalDatabase()
        Dim InitializeDB As New ScriptedObject("scripts\InitializeDB.vb", "InitializeDB.dll", True)
        InitializeDB.Invoke("Initializators", "Initialize")
        InitializeDB.Dispose()
        Dim InitializeTalentInfo As New ScriptedObject("scripts\InitializeTalentInfo.vb", "InitializeTalentInfo.dll", True)
        InitializeTalentInfo.Invoke("Initializators", "Initialize")
        InitializeTalentInfo.Dispose()

        InitializeSpellDB()

        RegisterChatCommands()

        Try
            Regenerator = New TRegenerator
            AIManager = New TAIManager
            SpellManager = New TSpellManager
            Spawner = New TSpawner

            'DONE: Initializing Counters
            Dim MySQLQuery As New DataTable
            Database.Query(String.Format("SELECT MAX(item_guid) FROM adb_characters_inventory;"), MySQLQuery)
            If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                ItemGUIDCounter = MySQLQuery.Rows(0).Item(0) + GUID_ITEM
            Else
                ItemGUIDCounter = 0 + GUID_ITEM
            End If

            MySQLQuery = New DataTable
            Database.Query(String.Format("SELECT MAX(spawned_guid) FROM tmpspawnedcreatures;"), MySQLQuery)
            If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                CreatureGUIDCounter = MySQLQuery.Rows(0).Item(0) + GUID_UNIT
            Else
                CreatureGUIDCounter = 0 + GUID_UNIT
            End If

            MySQLQuery = New DataTable
            Database.Query(String.Format("SELECT MAX(gameObject_guid) FROM tmpspawnedgameobjects;"), MySQLQuery)
            If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                GameObjectsGUIDCounter = MySQLQuery.Rows(0).Item(0) + GUID_GAMEOBJECT
            Else
                GameObjectsGUIDCounter = 0 + GUID_GAMEOBJECT
            End If

            MySQLQuery = New DataTable
            Database.Query(String.Format("SELECT MAX(corpse_guid) FROM tmpspawnedcorpses"), MySQLQuery)
            If Not MySQLQuery.Rows(0).Item(0) Is DBNull.Value Then
                CorpseGUIDCounter = MySQLQuery.Rows(0).Item(0) + GUID_CORPSE
            Else
                CorpseGUIDCounter = 0 + GUID_CORPSE
            End If

            'DONE: Initializing Maps
            'Dim x As Byte
            'Dim y As Byte
            'For x = 0 To 63
            '    For y = 0 To 63
            '        MapTiles(x, y) = New TMapTile(String.Format("{0}{1}{2}.map", Format(HANDLED_MAP_ID, "000"), Format(x, "00"), Format(y, "00")))
            '    Next
            'Next

            'DONE: Loading creatures
            MySQLQuery.Clear()
            Database.Query(String.Format("SELECT * FROM tmpspawnedcreatures WHERE spawned_map = {0};", HANDLED_MAP_ID), MySQLQuery)
            If MySQLQuery.Rows.Count > 0 Then
                Dim creaturesCounter As Integer = 0
                For Each Row As DataRow In MySQLQuery.Rows
                    Try
                        Dim tmpCr As New CreatureObject(CType(Row.Item("spawned_guid"), Long), Row)
                        tmpCr.AddToWorld()
                        creaturesCounter += 1
                    Catch e As Exception
                        Log.WriteLine(LogType.FAILED, "World: Unable to spawn creature [CreatureGUID={0}]", Row.Item("spawned_guid"))
                    End Try
                Next
                Log.WriteLine(LogType.INFORMATION, "World: Loading spawned creatures....[{0}]", creaturesCounter)
            End If

            'DONE: Loading corpses
            MySQLQuery.Clear()
            Database.Query(String.Format("SELECT * FROM tmpspawnedcorpses WHERE corpse_mapId = {0};", HANDLED_MAP_ID), MySQLQuery)
            If MySQLQuery.Rows.Count > 0 Then
                Dim coprsesCounter As Integer = 0
                For Each Row As DataRow In MySQLQuery.Rows
                    Dim tmpCopr As New CorpseObject(CType(Row.Item("corpse_guid"), Long), Row)
                    tmpCopr.AddToWorld()
                    coprsesCounter += 1
                Next
                Log.WriteLine(LogType.INFORMATION, "World: Loading spawned corpses....[{0}]", coprsesCounter)
            End If

            'DONE: Loading gameObjects
            MySQLQuery.Clear()
            Database.Query(String.Format("SELECT * FROM tmpspawnedgameobjects WHERE gameobject_map = {0};", HANDLED_MAP_ID), MySQLQuery)
            If MySQLQuery.Rows.Count > 0 Then
                Dim gameObjCounter As Integer = 0
                For Each Row As DataRow In MySQLQuery.Rows
                    Dim tmpGameObj As New GameObjectObject(CType(Row.Item("gameobject_guid"), Long), Row)
                    tmpGameObj.AddToWorld()
                    gameObjCounter += 1
                Next
                Log.WriteLine(LogType.INFORMATION, "World: Loading spawned gameObjects....[{0}]", gameObjCounter)
            End If

        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Internal database initialization failed! [{0}]{1}{2}", e.Message, vbNewLine, e.ToString)
        End Try
    End Sub


    Public Const HUMAN_START_POSITIONX As Single = -8949.95F
    Public Const HUMAN_START_POSITIONY As Single = -132.493F
    Public Const HUMAN_START_POSITIONZ As Single = 83.5312F
    Public Const DWARF_START_POSITIONX As Single = -6240.32F
    Public Const DWARF_START_POSITIONY As Single = 331.033F
    Public Const DWARF_START_POSITIONZ As Single = 382.758F
    Public Const NIGHTELF_START_POSITIONX As Single = 10311.3F
    Public Const NIGHTELF_START_POSITIONY As Single = 832.463F
    Public Const NIGHTELF_START_POSITIONZ As Single = 1326.41F
    Public Const GNOME_START_POSITIONX As Single = -6240.32F
    Public Const GNOME_START_POSITIONY As Single = 331.033F
    Public Const GNOME_START_POSITIONZ As Single = 382.758F
    Public Const UNDEAD_START_POSITIONX As Single = 1676.35F
    Public Const UNDEAD_START_POSITIONY As Single = 1677.45F
    Public Const UNDEAD_START_POSITIONZ As Single = 121.67F
    Public Const TROLL_START_POSITIONX As Single = -618.518F
    Public Const TROLL_START_POSITIONY As Single = -4251.67F
    Public Const TROLL_START_POSITIONZ As Single = 38.718F
    Public Const ORC_START_POSITIONX As Single = -618.518F
    Public Const ORC_START_POSITIONY As Single = -4251.67F
    Public Const ORC_START_POSITIONZ As Single = 38.718F
    Public Const TAUREN_START_POSITIONX As Single = -2917.58F
    Public Const TAUREN_START_POSITIONY As Single = -257.98F
    Public Const TAUREN_START_POSITIONZ As Single = 52.9968F
    Public Const BLOODELF_START_POSITIONX As Single = 10349.85F
    Public Const BLOODELF_START_POSITIONY As Single = -6357.63F
    Public Const BLOODELF_START_POSITIONZ As Single = 33.48F
    Public Const DRAENEI_START_POSITIONX As Single = -3961.86F
    Public Const DRAENEI_START_POSITIONY As Single = -13931.27F
    Public Const DRAENEI_START_POSITIONZ As Single = 100.58F
End Module
