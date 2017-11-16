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

Public Module WS_Spells



#Region "WS.Skills.Constants"


    Public Enum SkillIDs As Integer
        SKILL_FROST = 6
        SKILL_FIRE = 8
        SKILL_ARMS = 26
        SKILL_COMBAT = 38
        SKILL_SUBTLETY = 39
        SKILL_POISONS = 40
        SKILL_SWORDS = 43
        SKILL_AXES = 44
        SKILL_BOWS = 45
        SKILL_GUNS = 46
        SKILL_BEAST_MASTERY = 50
        SKILL_SURVIVAL = 51
        SKILL_MACES = 54
        SKILL_HOLY = 56
        SKILL_2H_SWORDS = 55
        SKILL_SHADOW = 78
        SKILL_DEFENSE = 95
        SKILL_LANG_COMMON = 98
        SKILL_RACIAL_DWARVEN = 101
        SKILL_LANG_ORCISH = 109
        SKILL_LANG_DWARVEN = 111
        SKILL_LANG_DARNASSIAN = 113
        SKILL_LANG_TAURAHE = 115
        SKILL_DUAL_WIELD = 118
        SKILL_RACIAL_TAUREN = 124
        SKILL_ORC_RACIAL = 125
        SKILL_RACIAL_NIGHT_ELF = 126
        SKILL_FIRST_AID = 129
        SKILL_FERAL_COMBAT = 134
        SKILL_STAVES = 136
        SKILL_LANG_THALASSIAN = 137
        SKILL_LANG_DRACONIC = 138
        SKILL_LANG_DEMON_TONGUE = 139
        SKILL_LANG_TITAN = 140
        SKILL_LANG_OLD_TONGUE = 141
        SKILL_SURVIVAL2 = 142
        SKILL_RIDING_HORSE = 148
        SKILL_RIDING_WOLF = 149
        SKILL_RIDING_RAM = 152
        SKILL_RIDING_TIGER = 150
        SKILL_SWIMING = 155
        SKILL_2H_MACES = 160
        SKILL_UNARMED = 162
        SKILL_MARKSMANSHIP = 163
        SKILL_BLACKSMITHING = 164
        SKILL_LEATHERWORKING = 165
        SKILL_ALCHEMY = 171
        SKILL_2H_AXES = 172
        SKILL_DAGGERS = 173
        SKILL_THROWN = 176
        SKILL_HERBALISM = 182
        SKILL_GENERIC_DND = 183
        SKILL_RETRIBUTION = 184
        SKILL_COOKING = 185
        SKILL_MINING = 186
        SKILL_PET_IMP = 188
        SKILL_PET_FELHUNTER = 189
        SKILL_TAILORING = 197
        SKILL_ENGINERING = 202
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
        SKILL_PET_GORILLA = 215
        SKILL_PET_CRAB = 214
        SKILL_PET_RAPTOR = 217
        SKILL_PET_TALLSTRIDER = 218
        SKILL_RACIAL_UNDED = 220
        SKILL_WEAPON_TALENTS = 222
        SKILL_CROSSBOWS = 226
        SKILL_SPEARS = 227
        SKILL_WANDS = 228
        SKILL_POLEARMS = 229
        SKILL_ATTRIBUTE_ENCHANCEMENTS = 230
        SKILL_SLAYER_TALENTS = 231
        SKILL_MAGIC_TALENTS = 233
        SKILL_DEFENSIVE_TALENTS = 234
        SKILL_PET_SCORPID = 236
        SKILL_ARCANE = 237
        SKILL_OPEN_LOCK = 242
        SKILL_PET_TURTLE = 251
        SKILL_FURY = 256
        SKILL_PROTECTION = 257
        SKILL_BEAST_TRAINING = 261
        SKILL_PROTECTION2 = 267
        SKILL_PET_TALENTS = 270
        SKILL_PLATE_MAIL = 293
        SKILL_ASSASSINATION = 253
        SKILL_LANG_GNOMISH = 313
        SKILL_LANG_TROLL = 315
        SKILL_ENCHANTING = 333
        SKILL_DEMONOLOGY = 354
        SKILL_AFFLICTION = 355
        SKILL_FISHING = 356
        SKILL_ENHANCEMENT = 373
        SKILL_RESTORATION = 374
        SKILL_ELEMENTAL_COMBAT = 375
        SKILL_SKINNING = 393
        SKILL_LEATHER = 414
        SKILL_CLOTH = 415
        SKILL_MAIL = 413
        SKILL_SHIELD = 433
        SKILL_FIST_WEAPONS = 473
        SKILL_TRACKING_BEAST = 513
        SKILL_TRACKING_HUMANOID = 514
        SKILL_TRACKING_DEMON = 516
        SKILL_TRACKING_UNDEAD = 517
        SKILL_TRACKING_DRAGON = 518
        SKILL_TRACKING_ELEMENTAL = 519
        SKILL_RIDING_RAPTOR = 533
        SKILL_RIDING_MECHANOSTRIDER = 553
        SKILL_RIDING_UNDEAD_HORSE = 554
        SKILL_RESTORATION2 = 573
        SKILL_BALANCE = 574
        SKILL_DESTRUCTION = 593
        SKILL_HOLY2 = 594
        SKILL_DISCIPLINE = 613
        SKILL_LOCKPICKING = 633
        SKILL_PET_BAT = 653
        SKILL_PET_HYENA = 654
        SKILL_PET_OWL = 655
        SKILL_PET_WIND_SERPENT = 656
        SKILL_LANG_GUTTERSPEAK = 673
        SKILL_RIDING_KODO = 713
        SKILL_RACIAL_TROLL = 733
        SKILL_RACIAL_GNOME = 753
        SKILL_RACIAL_HUMAN = 754
        SKILL_JEWELCRAFTING = 755
        SKILL_RACIAL_BLOODELF = 756
        SKILL_LANG_DRAENEI = 759
        SKILL_RACIAL_DRAENEI = 760
        SKILL_PET_FELLGUARD = 761
        SKILL_RIDING = 762
        SKILL_PET_DRAGONHAWK = 763
        SKILL_PET_NETHERRAY = 764
        SKILL_PET_SPOREBAT = 765
        SKILL_PET_WARPSTALKER = 766
        SKILL_PET_RAVAGER = 767
        SKILL_PET_SERPENT = 768
        SKILL_INTERNAL = 769
    End Enum
    Public Enum TradeSkill As Integer
        TRADESKILL_ALCHEMY = 1
        TRADESKILL_BLACKSMITHING = 2
        TRADESKILL_COOKING = 3
        TRADESKILL_ENCHANTING = 4
        TRADESKILL_ENGINEERING = 5
        TRADESKILL_FIRSTAID = 6
        TRADESKILL_HERBALISM = 7
        TRADESKILL_LEATHERWORKING = 8
        TRADESKILL_POISONS = 9
        TRADESKILL_TAILORING = 10
        TRADESKILL_MINING = 11
        TRADESKILL_FISHING = 12
        TRADESKILL_SKINNING = 13
    End Enum
    Public Enum TradeSkillLevel As Integer
        TRADESKILL_LEVEL_NONE = 0
        TRADESKILL_LEVEL_APPRENTICE = 1
        TRADESKILL_LEVEL_JOURNEYMAN = 2
        TRADESKILL_LEVEL_EXPERT = 3
        TRADESKILL_LEVEL_ARTISAN = 4
        TRADESKILL_LEVEL_MASTER = 5
    End Enum



#End Region

#Region "WS.Spells.Constants"

    Public Const SPELL_DURATION_INFINITE As Integer = -1
    Public Const MAX_AURA_EFFECTs_VISIBLE = 56                  '56 AuraSlots
    Public Const MAX_AURA_EFFECTs_PASSIVE = 64                  '60 TalentPoints + 4 RacialPassives
    Public Const MAX_AURA_EFFECTs As Integer = MAX_AURA_EFFECTs_VISIBLE + MAX_AURA_EFFECTs_PASSIVE
    Public Const MAX_AURA_EFFECT_FLAGs As Integer = MAX_AURA_EFFECTs \ 8
    Public Const MAX_POSITIOVE_AURA_EFFECTs As Integer = 36
    Public Const MAX_NEGATIVE_AURA_EFFECTs As Integer = MAX_AURA_EFFECTs_VISIBLE - MAX_POSITIOVE_AURA_EFFECTs

    Public Enum TargetType
        AllCharacters = -2
        AllMobiles = -3
        Enemy = -1
        [Friend] = 1
        GameObj = 4
        Neutral = 0
        Party = 2
        Pet = 3
    End Enum
    Public Enum TrackableCreatures
        All = 128
        Beast = 1
        Critter = 8
        Demon = 3
        Dragonkin = 2
        Elemental = 4
        Giant = 5
        Humanoid = 7
        Mechanical = 9
        Undead = 6
    End Enum
    Public Enum TrackableResources
        ElvenGems = 7
        GahzRidian = 15
        Herbs = 2
        Minerals = 3
        Treasure = 6
    End Enum

    Public Enum SpellCastState As Byte
        SPELL_STATE_NULL = 0
        SPELL_STATE_PREPARING
        SPELL_STATE_CASTING
        SPELL_STATE_FINISHED
        SPELL_STATE_IDLE
    End Enum
    Public Enum SpellAuraInterruptFlags As Byte
        AURA_BREAK_ON_DAMAGE_RECEIVED = 1
        AURA_BREAK_MUST_STAY_SITTING = 18
    End Enum
    Public Enum SpellProcFlags As Byte
        PROC_ON_DAMAGE_RECEIVED = 3
    End Enum

    Public Enum SpellAttributesEx2 As Integer
        SPELL_BEHIND_TARGET = &H100000
    End Enum
    Public Enum SpellAttributesEx As Integer
        SPELL_BEHIND_TARGET = &H200
    End Enum
    Public Enum SpellAttributes As Integer
        SPELL_PASSIVE = &H40              'Flag 6
    End Enum


    Public Enum SpellCastTargetFlags As Integer
        TARGET_FLAG_SELF = &H0
        TARGET_FLAG_UNIT = &H2              'Swimmers
        TARGET_FLAG_ITEM = &H1010           'Item -&H10?
        TARGET_FLAG_SOURCE_LOCATION = &H20  'PBAE
        TARGET_FLAG_DEST_LOCATION = &H40    'Targeted AE
        TARGET_FLAG_OBJECT = &H800
        TARGET_FLAG_STRING = &H2000

        'TARGET_FLAG_PLAYER_CORPSE = &H200  'Player Corpse
        'TARGET_FLAG_SELF = &H100           'Self
        'TARGET_FLAG_UNK =&H400             'Mass Spirit Heal
        'TARGET_FLAG_OBJECT=&H4000          'World Object
        'TARGET_FLAG_RESS_CORPSE=&H8000     'Resurrectable Corpse
    End Enum
    Public Enum SpellFailedReason As Byte
        CAST_NO_ERROR = &HFF
        CAST_FAIL_ALREADY_FULL_MANA = CAST_FAIL_ALREADY_AT_FULL_POWER
        CAST_FAIL_ALREADY_FULL_RAGE = CAST_FAIL_ALREADY_AT_FULL_POWER

        CAST_FAIL_AFFECTING_COMBAT = 0
        CAST_FAIL_ALREADY_AT_FULL_HEALTH = 1
        CAST_FAIL_ALREADY_AT_FULL_POWER = 2
        CAST_FAIL_ALREADY_BEING_TAMED = 3
        CAST_FAIL_ALREADY_HAVE_CHARM = 4
        CAST_FAIL_ALREADY_HAVE_SUMMON = 5
        CAST_FAIL_ALREADY_OPEN = 6
        CAST_FAIL_AURA_BOUNCED = 7
        CAST_FAIL_AUTOTRACK_INTERRUPTED = 8
        CAST_FAIL_BAD_IMPLICIT_TARGETS = 9
        CAST_FAIL_BAD_TARGETS = 10
        CAST_FAIL_CANT_BE_CHARMED = 11
        CAST_FAIL_CANT_BE_DISENCHANTED = 12
        CAST_FAIL_CANT_BE_DISENCHANTED_SKILL = 13
        CAST_FAIL_CANT_BE_PROSPECTED = 14
        CAST_FAIL_CANT_CAST_ON_TAPPED = 15
        CAST_FAIL_CANT_DUEL_WHILE_INVISIBLE = 16
        CAST_FAIL_CANT_DUEL_WHILE_STEALTHED = 17
        CAST_FAIL_CANT_STEALTH = 18
        CAST_FAIL_CASTER_AURASTATE = 19
        CAST_FAIL_CASTER_DEAD = 20
        CAST_FAIL_CHARMED = 21
        CAST_FAIL_CHEST_IN_USE = 22
        CAST_FAIL_CONFUSED = 23
        CAST_FAIL_DONT_REPORT = 24
        CAST_FAIL_EQUIPPED_ITEM = 25
        CAST_FAIL_EQUIPPED_ITEM_CLASS = 26
        CAST_FAIL_EQUIPPED_ITEM_CLASS_MAINHAND = 27
        CAST_FAIL_EQUIPPED_ITEM_CLASS_OFFHAND = 28
        CAST_FAIL_ERROR = 29
        CAST_FAIL_FIZZLE = 30
        CAST_FAIL_FLEEING = 31
        CAST_FAIL_FOOD_LOWLEVEL = 32
        CAST_FAIL_HIGHLEVEL = 33
        CAST_FAIL_HUNGER_SATIATED = 34
        CAST_FAIL_IMMUNE = 35
        CAST_FAIL_INTERRUPTED = 36
        CAST_FAIL_INTERRUPTED_COMBAT = 37
        CAST_FAIL_ITEM_ALREADY_ENCHANTED = 38
        CAST_FAIL_ITEM_GONE = 39
        CAST_FAIL_ITEM_NOT_FOUND = 40
        CAST_FAIL_ITEM_NOT_READY = 41
        CAST_FAIL_LEVEL_REQUIREMENT = 42
        CAST_FAIL_LINE_OF_SIGHT = 43
        CAST_FAIL_LOWLEVEL = 44
        CAST_FAIL_LOW_CASTLEVEL = 45
        CAST_FAIL_MAINHAND_EMPTY = 46
        CAST_FAIL_MOVING = 47
        CAST_FAIL_NEED_AMMO = 48
        CAST_FAIL_NEED_AMMO_POUCH = 49
        CAST_FAIL_NEED_EXOTIC_AMMO = 50
        CAST_FAIL_NOPATH = 51
        CAST_FAIL_NOT_BEHIND = 52
        CAST_FAIL_NOT_FISHABLE = 53
        CAST_FAIL_NOT_HERE = 54
        CAST_FAIL_NOT_INFRONT = 55
        CAST_FAIL_NOT_IN_CONTROL = 56
        CAST_FAIL_NOT_KNOWN = 57
        CAST_FAIL_NOT_MOUNTED = 58
        CAST_FAIL_NOT_ON_TAXI = 59
        CAST_FAIL_NOT_ON_TRANSPORT = 60
        CAST_FAIL_NOT_READY = 61
        CAST_FAIL_NOT_SHAPESHIFT = 62
        CAST_FAIL_NOT_STANDING = 63
        CAST_FAIL_NOT_TRADEABLE = 64
        CAST_FAIL_NOT_TRADING = 65
        CAST_FAIL_NOT_UNSHEATHED = 66
        CAST_FAIL_NOT_WHILE_GHOST = 67
        CAST_FAIL_NO_AMMO = 68
        CAST_FAIL_NO_CHARGES_REMAIN = 69
        CAST_FAIL_NO_CHAMPION = 70
        CAST_FAIL_NO_COMBO_POINTS = 71
        CAST_FAIL_NO_DUELING = 72
        CAST_FAIL_NO_ENDURANCE = 73
        CAST_FAIL_NO_FISH = 74
        CAST_FAIL_NO_ITEMS_WHILE_SHAPESHIFTED = 75
        CAST_FAIL_NO_MOUNTS_ALLOWED = 76
        CAST_FAIL_NO_PET = 77
        CAST_FAIL_NO_POWER = 78
        CAST_FAIL_NOTHING_TO_DISPEL = 79
        CAST_FAIL_NOTHING_TO_STEAL = 80
        CAST_FAIL_ONLY_ABOVEWATER = 81
        CAST_FAIL_ONLY_DAYTIME = 82
        CAST_FAIL_ONLY_INDOORS = 83
        CAST_FAIL_ONLY_MOUNTED = 84
        CAST_FAIL_ONLY_NIGHTTIME = 85
        CAST_FAIL_ONLY_OUTDOORS = 86
        CAST_FAIL_ONLY_SHAPESHIFT = 87
        CAST_FAIL_ONLY_STEALTHED = 88
        CAST_FAIL_ONLY_UNDERWATER = 89
        CAST_FAIL_OUT_OF_RANGE = 90
        CAST_FAIL_PACIFIED = 91
        CAST_FAIL_POSSESSED = 92
        CAST_FAIL_REAGENTS = 93
        CAST_FAIL_REQUIRES_AREA = 94
        CAST_FAIL_REQUIRES_SPELL_FOCUS = 95
        CAST_FAIL_ROOTED = 96
        CAST_FAIL_SILENCED = 97
        CAST_FAIL_SPELL_IN_PROGRESS = 98
        CAST_FAIL_SPELL_LEARNED = 99
        CAST_FAIL_SPELL_UNAVAILABLE = 100
        CAST_FAIL_STUNNED = 101
        CAST_FAIL_TARGETS_DEAD = 102
        CAST_FAIL_TARGET_AFFECTING_COMBAT = 103
        CAST_FAIL_TARGET_AURASTATE = 104
        CAST_FAIL_TARGET_DUELING = 105
        CAST_FAIL_TARGET_ENEMY = 106
        CAST_FAIL_TARGET_ENRAGED = 107
        CAST_FAIL_TARGET_FRIENDLY = 108
        CAST_FAIL_TARGET_IN_COMBAT = 109
        CAST_FAIL_TARGET_IS_PLAYER = 110
        CAST_FAIL_TARGET_NOT_DEAD = 111
        CAST_FAIL_TARGET_NOT_IN_PARTY = 112
        CAST_FAIL_TARGET_NOT_LOOTED = 113
        CAST_FAIL_TARGET_NOT_PLAYER = 114
        CAST_FAIL_TARGET_NO_POCKETS = 115
        CAST_FAIL_TARGET_NO_WEAPONS = 116
        CAST_FAIL_TARGET_UNSKINNABLE = 117
        CAST_FAIL_THIRST_SATIATED = 118
        CAST_FAIL_TOO_CLOSE = 119
        CAST_FAIL_TOO_MANY_OF_ITEM = 120
        CAST_FAIL_TOTEM_CATEGORY = 121
        CAST_FAIL_TOTEMS = 122
        CAST_FAIL_TRAINING_POINTS = 123
        CAST_FAIL_TRY_AGAIN = 124
        CAST_FAIL_UNIT_NOT_BEHIND = 125
        CAST_FAIL_UNIT_NOT_INFRONT = 126
        CAST_FAIL_WRONG_PET_FOOD = 127
        CAST_FAIL_NOT_WHILE_FATIGUED = 128
        CAST_FAIL_TARGET_NOT_IN_INSTANCE = 129
        CAST_FAIL_NOT_WHILE_TRADING = 130
        CAST_FAIL_TARGET_NOT_IN_RAID = 131
        CAST_FAIL_DISENCHANT_WHILE_LOOTING = 132
        CAST_FAIL_PROSPECT_WHILE_LOOTING = 133
        CAST_FAIL_PROSPECT_NEED_MORE = 134
        CAST_FAIL_TARGET_FREEFORALL = 135
        CAST_FAIL_NO_EDIBLE_CORPSES = 136
        CAST_FAIL_ONLY_BATTLEGROUNDS = 137
        CAST_FAIL_TARGET_NOT_GHOST = 138
        CAST_FAIL_TOO_MANY_SKILLS = 139
        CAST_FAIL_TRANSFORM_UNUSABLE = 140
        CAST_FAIL_WRONG_WEATHER = 141
        CAST_FAIL_DAMAGE_IMMUNE = 142
        CAST_FAIL_PREVENTED_BY_MECHANIC = 143
        CAST_FAIL_PLAY_TIME = 144
        CAST_FAIL_REPUTATION = 145
        CAST_FAIL_MIN_SKILL = 146
        CAST_FAIL_NOT_IN_ARENA = 147
        CAST_FAIL_NOT_ON_SHAPESHIFT = 148
        CAST_FAIL_NOT_ON_STEALTHED = 149
        CAST_FAIL_NOT_ON_DAMAGE_IMMUNE = 150
        CAST_FAIL_NOT_ON_MOUNTED = 151
        CAST_FAIL_TOO_SHALLOW = 152
        CAST_FAIL_UNKNOWN = 153
    End Enum
    Public Enum SpellImplicitTargets As Byte
        TARGET_NOTHING = 0

        TARGET_SELF = 1
        TARGET_PET = 5
        TARGET_SELECTED_ENEMY = 6
        TARGET_AREA_EFFECT_ENEMY = 15
        TARGET_AREA_EFFECT_ENEMY_INSTANT = 16

        TARGET_AROUND_CASTER_PARTY = 20
        TARGET_SELECTED_FRIEND = 21
        TARGET_AROUND_CASTER_ENEMY = 22
        TARGET_SELECTED_GAMEOBJECT = 23
        TARGET_INFRONT = 24
        TARGET_DUEL_VS_PLAYER = 25                  'Used when part of spell is casted on another target
        TARGET_GAMEOBJECT_AND_ITEM = 26
        TARGET_MASTER = 27      'not tested
        TARGET_AREA_EFFECT_ENEMY_CHANNEL = 28

        TARGET_MINION = 32                          'Summons your pet to you.
        TARGET_SELECTED_PLAYER = 35                 'Surrounds the target in a shield of fire.
        TARGET_SELECTED_PLAYER_PARTY = 37           'Power infuses the target's party, increasing their Shadow resistance by $s1 for $d.
        TARGET_CASTER = 38                          'Enegy used returns to the caster.
        TARGET_SELF_FISHING = 39                    'Equip a fishing pole and find a body of water to fish.
        TARGET_TOTEM_EARTH = 41                     'Summons a Stoneclaw Totem.
        TARGET_TOTEM_WATER = 42                     'Summons a Healing Stream Totem.
        TARGET_TOTEM_AIR = 43                       'Summons a Windfury Totem.
        TARGET_TOTEM_FIRE = 44                      'Summons a Frost Resistance Totem.
        TARGET_CHAIN = 45                           'Heals the friendly target for $s1, then jumps to heal additional nearby targets.
        TARGET_DYNAMIC_OBJECT = 47
        TARGET_AREA_EFFECT_SELECTED = 53            'Inflicts $s1 Fire damage to all enemies in a selected area.
        TARGET_UNK54 = 54
        TARGET_SELECTED_PARTY_MEMBER = 57           'Puts a pirate costume on targeted party member.




    End Enum

    Public Enum ShapeshiftForm As Byte
        FORM_NORMAL = 0

        FORM_CAT = 1
        FORM_TREE = 2
        FORM_TRAVEL = 3
        FORM_AQUA = 4
        FORM_BEAR = 5
        FORM_AMBIENT = 6
        FORM_GHOUL = 7
        FORM_DIREBEAR = 8
        FORM_CREATUREBEAR = 14
        FORM_CREATURECAT = 15
        FORM_GHOSTWOLF = 16
        FORM_BATTLESTANCE = 17
        FORM_DEFENSIVESTANCE = 18
        FORM_BERSERKERSTANCE = 19
        FORM_SHADOW = 28
        FORM_FLIGHT = 29
        FORM_STEALTH = 30
        FORM_MOONKIN = 31
        FORM_SPIRITOFREDEMPTION = 32
    End Enum
    Public Function GetShapeshiftModel(ByVal form As ShapeshiftForm, ByVal race As Races, ByVal model As Integer) As Integer
        Select Case form
            Case ShapeshiftForm.FORM_CAT
                If race = Races.RACE_NIGHT_ELF Then Return 892
                If race = Races.RACE_TAUREN Then Return 8571
            Case ShapeshiftForm.FORM_BEAR, ShapeshiftForm.FORM_DIREBEAR
                If race = Races.RACE_NIGHT_ELF Then Return 2281
                If race = Races.RACE_TAUREN Then Return 2289
            Case ShapeshiftForm.FORM_MOONKIN
                If race = Races.RACE_NIGHT_ELF Then Return 15374
                If race = Races.RACE_TAUREN Then Return 15375
            Case ShapeshiftForm.FORM_TRAVEL
                Return 632
            Case ShapeshiftForm.FORM_AQUA
                Return 2428

            Case ShapeshiftForm.FORM_GHOUL
                If race = Races.RACE_NIGHT_ELF Then Return 10045 Else Return model
            Case ShapeshiftForm.FORM_CREATUREBEAR
                Return 902
            Case ShapeshiftForm.FORM_GHOSTWOLF
                Return 4613
            Case Else
                Return model
                'Case ShapeshiftForm.FORM_CREATURECAT
                'Case ShapeshiftForm.FORM_AMBIENT
                'Case ShapeshiftForm.FORM_SHADOW
                'Case ShapeshiftForm.FORM_FLIGHT
                'Case ShapeshiftForm.FORM_TREE
                'Case ShapeshiftForm.FORM_SPIRITOFREDEMPTION
        End Select
    End Function
    Public Function GetShapeshiftManaType(ByVal form As ShapeshiftForm, ByVal manaType As ManaTypes) As ManaTypes
        Select Case form
            Case ShapeshiftForm.FORM_CAT, ShapeshiftForm.FORM_STEALTH
                Return WS_CharManagment.ManaTypes.TYPE_ENERGY
            Case ShapeshiftForm.FORM_AQUA, ShapeshiftForm.FORM_TRAVEL, ShapeshiftForm.FORM_MOONKIN, ShapeshiftForm.FORM_TREE, _
                 ShapeshiftForm.FORM_MOONKIN, ShapeshiftForm.FORM_MOONKIN, ShapeshiftForm.FORM_SPIRITOFREDEMPTION, ShapeshiftForm.FORM_FLIGHT
                Return WS_CharManagment.ManaTypes.TYPE_MANA
            Case ShapeshiftForm.FORM_BEAR, ShapeshiftForm.FORM_DIREBEAR
                Return WS_CharManagment.ManaTypes.TYPE_RAGE
            Case Else
                Return manaType
        End Select
    End Function


#End Region
#Region "WS.Spells.Framework"

    'WARNING: Use only with SPELLs()
    Public Class SpellInfo
        Public ID As Integer = 0
        Public School As Integer = 0
        Public Category As Integer = 0
        Public DispellType As Integer = 0

        Public Attributes As Integer = 0
        Public AttributesEx As Integer = 0
        Public RequredCasterStance As Integer = 0
        Public Target As Integer = 0
        Public TargetCreatureType As Integer = 0
        Public FocusObjectIndex As Integer = 0

        Public SpellCastTimeIndex As Integer = 0
        Public CategoryCooldown As Integer = 0
        Public SpellCooldown As Integer = 0

        Public interruptFlags As Integer = 0
        Public auraInterruptFlags As Integer = 0
        Public channelInterruptFlags As Integer = 0
        Public procFlags As Integer = 0
        Public procChance As Integer = 0
        Public procCharges As Integer = 0
        Public maxLevel As Integer = 0
        Public baseLevel As Integer = 0
        Public spellLevel As Integer = 0

        Public DurationIndex As Integer = 0

        Public powerType As Integer = 0
        Public manaCost As Integer = 0
        Public manaCostPerlevel As Integer = 0
        Public manaPerSecond As Integer = 0
        Public manaPerSecondPerLevel As Integer = 0

        Public rangeIndex As Integer = 0
        Public Speed As Single = 0
        Public modalNextSpell As Integer = 0

        Public Totem() As Integer = {0, 0}
        Public Reagents() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}
        Public ReagentsCount() As Integer = {0, 0, 0, 0, 0, 0, 0, 0}

        Public EquippedItemClass As Integer = 0
        Public EquippedItemSubClass As Integer = 0

        Public SpellEffects() As SpellEffect = {Nothing, Nothing, Nothing}


        Public SpellVisual As Integer = 0
        'Public Name As String = ""

        Public ReadOnly Property GetDuration() As Integer
            Get
                Return SpellDuration(DurationIndex)
            End Get
        End Property
        Public ReadOnly Property GetRange() As Integer
            Get
                Return SpellRange.Item(rangeIndex)
            End Get
        End Property
        Public ReadOnly Property GetFocusObject() As String
            Get
                Return SpellFocusObject(FocusObjectIndex)
            End Get
        End Property
        Public ReadOnly Property GetCastTime() As Integer
            Get
                Return SpellCastTime(SpellCastTimeIndex)
            End Get
        End Property
        Public ReadOnly Property GetManaCost(ByVal level As Integer) As Integer
            Get
                Return manaCost + manaCostPerlevel * level
            End Get
        End Property
        Public ReadOnly Property IsAura() As Boolean
            Get
                If Not SpellEffects(0) Is Nothing AndAlso SpellEffects(0).ApplyAuraIndex <> 0 Then Return True
                If Not SpellEffects(1) Is Nothing AndAlso SpellEffects(1).ApplyAuraIndex <> 0 Then Return True
                If Not SpellEffects(2) Is Nothing AndAlso SpellEffects(2).ApplyAuraIndex <> 0 Then Return True
                Return False
            End Get
        End Property
        Public ReadOnly Property IsPassive() As Boolean
            Get
                Return (Me.Attributes And SpellAttributes.SPELL_PASSIVE) > 0
            End Get
        End Property

        Public Sub Cast(ByRef caster As BaseObject, ByVal Targets As SpellTargets)
            Dim spellStart As New PacketClass(OPCODES.SMSG_SPELL_START)
            spellStart.AddPackGUID(Targets.unitTarget.GUID)                             'SpellTarget
            spellStart.AddPackGUID(caster.GUID)                                         'SpellCaster
            spellStart.AddInt32(ID)
            spellStart.AddInt16(2)
            spellStart.AddInt32(GetCastTime)
            Targets.WriteTargets(spellStart)
            If TypeOf caster Is CharacterObject Then CType(caster, CharacterObject).Client.SendMultiplyPackets(spellStart)
            caster.SendToNearPlayers(spellStart)
            spellStart.Dispose()

            'TODO: If ChannelInterruptFlags <>0 then START_CHANNEL


            'PREPEARING SPELL
            If TypeOf caster Is CharacterObject Then
                CType(caster, CharacterObject).spellCastState = SpellCastState.SPELL_STATE_PREPARING
            ElseIf TypeOf caster Is CreatureObject Then
                CType(caster, CreatureObject).TurnTo(Targets.unitTarget)
            End If
            Thread.Sleep(GetCastTime)



            'CASTING SPELL
            If TypeOf caster Is CharacterObject Then
                If CType(caster, CharacterObject).spellCastState <> SpellCastState.SPELL_STATE_PREPARING Then
                    SendInterrupted(0, caster)
                    SendCastResult(SpellFailedReason.CAST_FAIL_INTERRUPTED, CType(caster, CharacterObject).Client, ID)
                    Exit Sub
                End If
                CType(caster, CharacterObject).spellCastState = SpellCastState.SPELL_STATE_CASTING
            End If



            'APPLYING EFFECTS
            Dim SpellCastError As SpellFailedReason = SpellFailedReason.CAST_NO_ERROR
            Dim TargetsInfected As New ArrayList
            If SpellCastError = SpellFailedReason.CAST_NO_ERROR AndAlso Not SpellEffects(0) Is Nothing Then
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: Casting effect: {0}", CType(SPELL_EFFECTs(SpellEffects(0).ID), SpellEffectHandler).Method.Name)
#End If
                SpellCastError = SPELL_EFFECTs(SpellEffects(0).ID).Invoke(Targets, caster, SpellEffects(0), ID, TargetsInfected)
            End If
            If SpellCastError = SpellFailedReason.CAST_NO_ERROR AndAlso Not SpellEffects(1) Is Nothing Then
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: Casting effect: {0}", CType(SPELL_EFFECTs(SpellEffects(1).ID), SpellEffectHandler).Method.Name)
#End If
                SpellCastError = SPELL_EFFECTs(SpellEffects(1).ID).Invoke(Targets, caster, SpellEffects(1), ID, TargetsInfected)
            End If
            If SpellCastError = SpellFailedReason.CAST_NO_ERROR AndAlso Not SpellEffects(2) Is Nothing Then
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: Casting effect: {0}", CType(SPELL_EFFECTs(SpellEffects(2).ID), SpellEffectHandler).Method.Name)
#End If
                SpellCastError = SPELL_EFFECTs(SpellEffects(2).ID).Invoke(Targets, caster, SpellEffects(2), ID, TargetsInfected)
            End If
            If SpellCastError <> SpellFailedReason.CAST_NO_ERROR Then
                If TypeOf caster Is CharacterObject Then
                    SendCastResult(SpellCastError, CType(caster, CharacterObject).Client, ID)
                    SendInterrupted(SpellCastError, caster)
                    CType(caster, CharacterObject).spellCastState = SpellCastState.SPELL_STATE_IDLE
                    Exit Sub
                Else
                    SendInterrupted(SpellCastError, caster)
                    Exit Sub
                End If
            End If


            'FINISHED SPELL
            If TypeOf caster Is CharacterObject Then
                SendCastResult(SpellFailedReason.CAST_NO_ERROR, CType(caster, CharacterObject).Client, ID)

                'DONE: Get mana
                Select Case powerType
                    Case ManaTypes.TYPE_MANA
                        Dim manaCost As Integer = GetManaCost(CType(caster, CharacterObject).Level)
                        CType(caster, CharacterObject).Mana.Current -= manaCost
                        'DONE: 5 second rule
                        If manaCost > 0 Then
                            CType(caster, CharacterObject).spellCastManaRegeneration = 5
                            CType(caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1, CType(CType(caster, CharacterObject).Mana.Current, Integer))
                        End If
                    Case ManaTypes.TYPE_RAGE
                        CType(caster, CharacterObject).Rage.Current -= GetManaCost(CType(caster, CharacterObject).Level)
                        CType(caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER2, CType(CType(caster, CharacterObject).Rage.Current, Integer))
                    Case -1
                        CType(caster, CharacterObject).Life.Current -= GetManaCost(CType(caster, CharacterObject).Level)
                        CType(caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, CType(CType(caster, CharacterObject).Life.Current, Integer))
                    Case ManaTypes.TYPE_ENERGY
                        CType(caster, CharacterObject).Energy.Current -= GetManaCost(CType(caster, CharacterObject).Level)
                        CType(caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER4, CType(CType(caster, CharacterObject).Energy.Current, Integer))
                End Select
                CType(caster, CharacterObject).spellCastState = SpellCastState.SPELL_STATE_IDLE
                CType(caster, CharacterObject).SendCharacterUpdate(True)
            End If


            SendSpellGO(caster, Targets, TargetsInfected)

            'DONE: Log spell
            SendSpellLog(caster, Targets)

            If TypeOf caster Is CharacterObject Then
                'DONE: Send cooldown
                SendSpellCooldown(CType(caster, CharacterObject))
            End If
        End Sub
        Public Sub Apply(ByRef caster As BaseObject, ByVal Targets As SpellTargets)
            Log.WriteLine(LogType.DEBUG, "DEBUG: Applying spell: {0}", ID)

            Dim TargetsInfected As New ArrayList
            If Not SpellEffects(0) Is Nothing Then SPELL_EFFECTs(SpellEffects(0).ID).Invoke(Targets, caster, SpellEffects(0), ID, TargetsInfected)
            If Not SpellEffects(1) Is Nothing Then SPELL_EFFECTs(SpellEffects(1).ID).Invoke(Targets, caster, SpellEffects(1), ID, TargetsInfected)
            If Not SpellEffects(2) Is Nothing Then SPELL_EFFECTs(SpellEffects(2).ID).Invoke(Targets, caster, SpellEffects(2), ID, TargetsInfected)
        End Sub

        Public Function CanCast(ByRef Character As CharacterObject, ByVal Targets As SpellTargets) As SpellFailedReason
            'If Targets.unitTarget Is Nothing Then Return SpellFailedReason.CAST_FAIL_NO_TARGET
            If Not Targets.unitTarget Is Character Then
                If IsLookingTo(Character, Targets.unitTarget) = False Then Return SpellFailedReason.CAST_FAIL_LINE_OF_SIGHT
                If IsInFrontOf(Character, Targets.unitTarget) = False Then Return SpellFailedReason.CAST_FAIL_NOT_INFRONT
                'If GetDistance(Character, Targets.unitTarget) > GetRange Then Return SpellFailedReason.CAST_FAIL_OUT_OF_RANGE

                Select Case powerType
                    Case ManaTypes.TYPE_MANA
                        If GetManaCost(Character.Level) > Character.Mana.Current Then Return SpellFailedReason.CAST_FAIL_NO_POWER
                    Case ManaTypes.TYPE_RAGE
                        If GetManaCost(Character.Level) > Character.Rage.Current Then Return SpellFailedReason.CAST_FAIL_NO_POWER
                    Case -1
                        If GetManaCost(Character.Level) > Character.Life.Current Then Return SpellFailedReason.CAST_FAIL_NO_POWER
                    Case ManaTypes.TYPE_ENERGY
                        If GetManaCost(Character.Level) > Character.Energy.Current Then Return SpellFailedReason.CAST_FAIL_NO_POWER
                    Case Else
                        Return SpellFailedReason.CAST_FAIL_UNKNOWN
                End Select
            End If

            If Character.Spell_Silenced Then Return SpellFailedReason.CAST_FAIL_SILENCED
            'CAST_FAIL_CANT_DO_WHILE_CONFUSED


            'DONE: Check for same category - more powerful spell
            For i As Integer = 0 To Targets.unitTarget.ActiveSpells.Length - 1
                If Not Targets.unitTarget.ActiveSpells(i) Is Nothing Then
                    If Targets.unitTarget.ActiveSpells(i).SpellID <> 0 AndAlso _
                        CType(SPELLs(Targets.unitTarget.ActiveSpells(i).SpellID), SpellInfo).Category = Category AndAlso _
                        CType(SPELLs(Targets.unitTarget.ActiveSpells(i).SpellID), SpellInfo).spellLevel >= spellLevel Then
                        Return SpellFailedReason.CAST_FAIL_AURA_BOUNCED
                    End If
                End If
            Next

            Return SpellFailedReason.CAST_NO_ERROR
        End Function
        Public Sub SendInterrupted(ByVal result As Byte, ByRef Caster As BaseUnit)
            If TypeOf Caster Is CharacterObject Then
                Dim packet As New PacketClass(OPCODES.SMSG_SPELL_FAILURE)
                packet.AddInt64(Caster.GUID)
                packet.AddInt32(ID)
                packet.AddInt8(result)
                CType(Caster, CharacterObject).Client.Send(packet)
                packet.Dispose()
            End If

            Dim packet2 As New PacketClass(OPCODES.SMSG_SPELL_FAILED_OTHER)
            packet2.AddInt64(Caster.GUID)
            packet2.AddInt32(ID)
            Caster.SendToNearPlayers(packet2)
            packet2.Dispose()
        End Sub
        Public Sub SendSpellGO(ByRef Caster As BaseObject, ByRef Targets As SpellTargets, ByRef InfectedTargets As ArrayList)
            Dim packet As New PacketClass(OPCODES.SMSG_SPELL_GO)
            packet.AddPackGUID(Targets.unitTarget.GUID)                     'SpellTarget
            packet.AddPackGUID(Caster.GUID)                                 'SpellCaster
            packet.AddInt32(ID)
            packet.AddInt16(4)                                              'Unk1
            packet.AddInt8(InfectedTargets.Count)                           'Targets Count
            For Each Target As Long In InfectedTargets
                packet.AddInt64(Target)                                     'GUID1...
            Next
            packet.AddInt8(0)                                               'Misses Count
            Targets.WriteTargets(packet)
            If TypeOf Caster Is CharacterObject Then CType(Caster, CharacterObject).Client.SendMultiplyPackets(packet)
            Caster.SendToNearPlayers(packet)
            packet.Dispose()
        End Sub
        Public Sub SendSpellLog(ByRef Caster As BaseObject, ByRef Targets As SpellTargets)
            If SpellEffects(0) Is Nothing Then Exit Sub


            Dim packet As New PacketClass(OPCODES.SMSG_SPELLLOGEXECUTE)

            packet.AddPackGUID(Caster.GUID)
            packet.AddInt32(ID)
            packet.AddInt32(1)                                              'uint numOfSpellEffects

            'for(numOfSpellEffects)
            packet.AddInt32(SpellEffects(0).ID)                             'EffID
            packet.AddInt32(1)                                              'EffTargets
            Select Case SpellEffects(0).ID
                Case SpellEffects_Names.SPELL_EFFECT_INSTAKILL
                    packet.AddInt64(Targets.unitTarget.GUID)
                Case SpellEffects_Names.SPELL_EFFECT_DUMMY
                Case SpellEffects_Names.SPELL_EFFECT_MANA_DRAIN
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)
                    packet.AddInt32(SpellEffects(0).MiscValue)              'uint(manaType)
                    packet.AddInt32(1.0F)                                   'float(ratio)

                Case SpellEffects_Names.SPELL_EFFECT_HEALTH_LEECH
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)
                    packet.AddInt32(1.0F)                                   'float(ratio)

                Case SpellEffects_Names.SPELL_EFFECT_HEAL
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)

                Case SpellEffects_Names.SPELL_EFFECT_RESURRECT
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_ADD_EXTRA_ATTACKS
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)

                Case SpellEffects_Names.SPELL_EFFECT_CREATE_ITEM
                    packet.AddInt32(SpellEffects(0).ItemType)               'uint otherId - id of item

                Case SpellEffects_Names.SPELL_EFFECT_ENERGIZE
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)
                    packet.AddInt32(powerType)                              'uint(manaType)

                Case SpellEffects_Names.SPELL_EFFECT_OPEN_LOCK
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_DISPEL
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_THREAT
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_INTERRUPT_CAST
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).ItemType)               'uint(otherId)

                Case SpellEffects_Names.SPELL_EFFECT_FEED_PET
                    packet.AddInt32(0)              'uint(otherId)

                Case SpellEffects_Names.SPELL_EFFECT_DISMISS_PET
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_DISPEL_MECHANIC
                    packet.AddInt64(Targets.unitTarget.GUID)

                Case SpellEffects_Names.SPELL_EFFECT_DURABILITY_DAMAGE
                    packet.AddInt64(Targets.unitTarget.GUID)
                    packet.AddInt32(SpellEffects(0).MiscValue)              'uint(otherId)
                    packet.AddInt32(SpellEffects(0).valueBase)              'uint(amount)

                Case SpellEffects_Names.SPELL_EFFECT_ATTACK_ME 'UNKNOWN 114  TAUNT 
                    packet.AddInt64(Targets.unitTarget.GUID)
                Case Else
                    packet.Dispose()
                    Exit Sub
            End Select



            If TypeOf Caster Is CharacterObject Then CType(Caster, CharacterObject).Client.SendMultiplyPackets(packet)
            Caster.SendToNearPlayers(packet)
            packet.Dispose()
        End Sub
        Public Sub SendSpellCooldown(ByRef c As CharacterObject)
            'NOTE: Since 2.0.1 this opcode is used instead of SMSG_SPELL_COOLDOWN
            If CategoryCooldown > 0 OrElse SpellCooldown > 0 Then
                Dim packet As New PacketClass(OPCODES.SMSG_COOLDOWN_EVENT)
                packet.AddInt32(ID)                 'SpellID
                packet.AddInt64(c.GUID)
                c.Client.Send(packet)
                packet.Dispose()
            End If

            'NOTE: Since 2.0.1 this opcode is not used anymore for spell cooldown
            'If CategoryCooldown > 0 Then
            '    Dim packet As New PacketClass(OPCODES.SMSG_SPELL_COOLDOWN)
            '    packet.AddInt64(c.GUID)
            '    packet.AddInt32(ID)                 'SpellID
            '    packet.AddInt32(CategoryCooldown)   'RecoveryTime
            '    c.Client.Send(packet)
            '    packet.Dispose()
            'ElseIf SpellCooldown > 0 Then
            '    Dim packet As New PacketClass(OPCODES.SMSG_SPELL_COOLDOWN)
            '    packet.AddInt64(c.GUID)
            '    packet.AddInt32(ID)                 'SpellID
            '    packet.AddInt32(SpellCooldown)      'RecoveryTime
            '    c.Client.Send(packet)
            '    packet.Dispose()
            'End If

        End Sub
    End Class
    Public Class SpellEffect
        Public ID As SpellEffects_Names = SpellEffects_Names.SPELL_EFFECT_NOTHING

        Public diceBase As Integer = 0
        Public dicePerLevel As Integer = 0
        Public valueBase As Integer = 0
        Public valueDie As Integer = 0
        Public valuePerLevel As Integer = 0
        Public valuePerComboPoint As Integer = 0
        Public implicitTargetA As Integer = 0
        Public implicitTargetB As Integer = 0

        Public RadiusIndex As Integer = 0
        Public ApplyAuraIndex As Integer = 0

        Public Amplitude As Integer = 0
        Public ChainTarget As Integer = 0
        Public ItemType As Integer = 0
        Public MiscValue As Integer = 0
        Public TriggerSpell As Integer = 0

        Public ReadOnly Property GetRadius() As Integer
            Get
                Return SpellRadius(RadiusIndex)
            End Get
        End Property
        Public ReadOnly Property GetValue(ByVal Level As Integer, Optional ByVal ComboPoints As Integer = 0) As Integer
            Get
                'Dim baseDamage As Integer = valueBase + (Level * valuePerLevel)
                'Dim randomDamage As Integer = valueDie + (Level * dicePerLevel)
                'Dim comboDamage As Integer = ComboPoints * valuePerComboPoint
                'Return baseDamage + Rnd.Next(1, randomDamage) + comboDamage
                Return valueBase + (Level * valuePerLevel) + ComboPoints * valuePerComboPoint + Rnd.Next(1, valueDie + (Level * dicePerLevel))
            End Get
        End Property
    End Class
    Public Class SpellTargets
        Public unitTarget As BaseUnit = Nothing
        Public goTarget As BaseObject = Nothing
        Public itemTarget As ItemObject = Nothing
        Public srcX As Single = 0
        Public srcY As Single = 0
        Public srcZ As Single = 0
        Public dstX As Single = 0
        Public dstY As Single = 0
        Public dstZ As Single = 0
        Public stringTarget As String = ""

        Public targetMask As Integer = 0

        Public Sub ReadTargets(ByRef packet As PacketClass, ByRef Caster As BaseObject)
            targetMask = packet.GetInt16

            If targetMask = SpellCastTargetFlags.TARGET_FLAG_SELF Then
                unitTarget = Caster
                Exit Sub
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_UNIT) = SpellCastTargetFlags.TARGET_FLAG_UNIT Then
                Dim GUID As Long = packet.GetPackGUID
                If GuidIsCreature(GUID) Then
                    unitTarget = WORLD_CREATUREs(GUID)
                ElseIf GuidIsPlayer(GUID) Then
                    unitTarget = CHARACTERS(GUID)
                    'ElseIf GuidIsGameObject(GUID) Or GuidIsCorpse(GUID) Then
                    '    unitTarget = WORLD_GAMEOBJECTs(GUID)
                End If
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: TARGET_FLAG_UNIT " & GUID)
#End If
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_OBJECT) = SpellCastTargetFlags.TARGET_FLAG_OBJECT Then
                Dim GUID As Long = packet.GetPackGUID
                If GuidIsGameObject(GUID) Or GuidIsCorpse(GUID) Then
                    goTarget = WORLD_GAMEOBJECTs(GUID)
                End If
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: TARGET_FLAG_OBJECT " & GUID)
#End If
            End If

            If packet.Data.Length >= packet.Offset Then Exit Sub
            Log.WriteLine(LogType.WARNING, "Unhandled spell targets.")
            DumpPacket(packet.Data, Nothing)

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_ITEM) = SpellCastTargetFlags.TARGET_FLAG_ITEM Then
                Dim GUID As Long = packet.GetInt64
                itemTarget = WORLD_ITEMs(GUID)
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: TARGET_FLAG_ITEM " & GUID)
#End If
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_SOURCE_LOCATION) = SpellCastTargetFlags.TARGET_FLAG_SOURCE_LOCATION Then
                srcX = packet.GetFloat
                srcY = packet.GetFloat
                srcZ = packet.GetFloat
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: TARGET_FLAG_SOURCE_LOCATION {0} {1} {2}", srcX, srcY, srcZ)
#End If
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_DEST_LOCATION) = SpellCastTargetFlags.TARGET_FLAG_DEST_LOCATION Then
                dstX = packet.GetFloat
                dstY = packet.GetFloat
                dstZ = packet.GetFloat
#If DEBUG Then
                Log.WriteLine(LogType.DEBUG, "DEBUG: TARGET_FLAG_DEST_LOCATION {0} {1} {2}", dstX, dstY, dstZ)
#End If
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_STRING) = SpellCastTargetFlags.TARGET_FLAG_STRING Then stringTarget = packet.GetString
        End Sub
        Public Sub WriteTargets(ByRef packet As PacketClass)
            'NOTE: Packed GUIDs are used only on server packets ?

            packet.AddInt16(targetMask)

            If targetMask = SpellCastTargetFlags.TARGET_FLAG_SELF Then
                packet.AddInt64(unitTarget.GUID)
                'WritePacketGUID(packet, unitTarget.GUID)
                Exit Sub
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_UNIT) = SpellCastTargetFlags.TARGET_FLAG_UNIT Then packet.AddInt64(unitTarget.GUID) 'WritePacketGUID(packet, unitTarget.GUID)
            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_OBJECT) = SpellCastTargetFlags.TARGET_FLAG_OBJECT Then packet.AddInt64(unitTarget.GUID) 'WritePacketGUID(packet, goTarget.GUID)
            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_ITEM) = SpellCastTargetFlags.TARGET_FLAG_ITEM Then packet.AddInt64(itemTarget.GUID) 'WritePacketGUID(packet, unitTarget.GUID)

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_SOURCE_LOCATION) = SpellCastTargetFlags.TARGET_FLAG_SOURCE_LOCATION Then
                packet.AddSingle(srcX)
                packet.AddSingle(srcY)
                packet.AddSingle(srcZ)
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_DEST_LOCATION) = SpellCastTargetFlags.TARGET_FLAG_DEST_LOCATION Then
                packet.AddSingle(dstX)
                packet.AddSingle(dstY)
                packet.AddSingle(dstZ)
            End If

            If (targetMask And SpellCastTargetFlags.TARGET_FLAG_STRING) = SpellCastTargetFlags.TARGET_FLAG_STRING Then packet.AddString(stringTarget)
        End Sub

        Public Sub SetTarget_SELF(ByRef c As BaseUnit)
            unitTarget = c
            targetMask += SpellCastTargetFlags.TARGET_FLAG_SELF
        End Sub
        Public Sub SetTarget_UNIT(ByRef c As BaseUnit)
            unitTarget = c
            targetMask += SpellCastTargetFlags.TARGET_FLAG_UNIT
        End Sub
        Public Sub SetTarget_OBJECT(ByRef o As BaseObject)
            Me.goTarget = o
            targetMask += SpellCastTargetFlags.TARGET_FLAG_OBJECT
        End Sub
        Public Sub SetTarget_ITEM(ByRef i As ItemObject)
            Me.itemTarget = i
            targetMask += SpellCastTargetFlags.TARGET_FLAG_ITEM
        End Sub
        Public Sub SetTarget_SOURCELOCATION(ByVal x As Single, ByVal y As Single, ByVal z As Single)
            Me.srcX = x
            Me.srcY = y
            Me.srcZ = z
            targetMask += SpellCastTargetFlags.TARGET_FLAG_SOURCE_LOCATION
        End Sub
        Public Sub SetTarget_DESTINATIONLOCATION(ByVal x As Single, ByVal y As Single, ByVal z As Single)
            Me.dstX = x
            Me.dstY = y
            Me.dstZ = z
            targetMask += SpellCastTargetFlags.TARGET_FLAG_DEST_LOCATION
        End Sub
        Public Sub SetTarget_STRING(ByVal str As String)
            Me.stringTarget = str
            targetMask += SpellCastTargetFlags.TARGET_FLAG_STRING
        End Sub
    End Class


    Public Class CastSpellParameters
        Public tmpTargets As SpellTargets
        Public tmpCaster As BaseObject
        Public tmpSpellID As Integer

        Public Sub Cast(ByVal status As Object)
            CType(SPELLs(tmpSpellID), SpellInfo).Cast(tmpCaster, tmpTargets)
        End Sub
    End Class

    Public Sub SendCastResult(ByVal result As SpellFailedReason, ByRef Client As ClientClass, ByVal id As Integer)
        Dim packet As New PacketClass(OPCODES.SMSG_CAST_RESULT)
        packet.AddInt32(id)
        If result <> SpellFailedReason.CAST_NO_ERROR Then packet.AddInt8(2)
        packet.AddInt8(result)
        Client.Send(packet)
        packet.Dispose()
    End Sub
    Public Sub SendNonMeleeDamageLog(ByRef Caster As BaseUnit, ByRef Target As BaseUnit, ByVal SpellID As Integer, ByVal Damage As Integer, ByVal Resist As Integer, ByVal Absorbed As Integer, ByVal HitFlags As Byte)
        Dim packet As New PacketClass(OPCODES.SMSG_SPELLNONMELEEDAMAGELOG)
        packet.AddPackGUID(Target.GUID)
        packet.AddPackGUID(Caster.GUID)
        packet.AddInt32(SpellID)
        packet.AddInt32(Damage)
        packet.AddInt8(CType(SPELLs(SpellID), SpellInfo).School)
        packet.AddInt32(Resist)         'Resist
        packet.AddInt32(Absorbed)       'AbsorbedDamage
        packet.AddInt8(0)               '1=Suffers/0=Hit
        packet.AddInt8(0)
        packet.AddInt32(0)
        packet.AddInt8(HitFlags)        '5=Hit 7=Crit
        packet.AddInt32(0)              '?Blocked
        If TypeOf Caster Is CharacterObject Then CType(Caster, CharacterObject).Client.SendMultiplyPackets(packet)
        Caster.SendToNearPlayers(packet)
    End Sub
    Public Sub SendPeriodicAuraLog(ByRef Caster As BaseUnit, ByRef Target As BaseUnit, ByVal SpellID As Integer, ByVal Damage As Integer, ByVal AuraIndex As Integer)
        Dim packet As New PacketClass(OPCODES.SMSG_PERIODICAURALOG)
        packet.AddPackGUID(Target.GUID)
        packet.AddPackGUID(Caster.GUID)
        packet.AddInt32(SpellID)
        packet.AddInt32(1)              'Count?

        packet.AddInt32(AuraIndex)
        packet.AddInt32(Damage)
        packet.AddInt8(CType(SPELLs(SpellID), SpellInfo).School)
        packet.AddInt32(0)              'Resist?

        If TypeOf Caster Is CharacterObject Then CType(Caster, CharacterObject).Client.SendMultiplyPackets(packet)
        Caster.SendToNearPlayers(packet)
    End Sub
    Public Sub SendPlaySpellVisual(ByRef Caster As BaseUnit, ByVal SpellId As Integer)
        Dim packet As New PacketClass(OPCODES.SMSG_PLAY_SPELL_VISUAL)
        packet.AddInt64(Caster.GUID)
        packet.AddInt32(SpellId)
        Caster.SendToNearPlayers(packet)
        packet.Dispose()
    End Sub



#End Region
#Region "WS.Spells.Database"


    Public SPELLs As New Hashtable(20000)

    Public SpellCastTime As New Hashtable
    Public SpellRadius As New Hashtable
    Public SpellRange As New Hashtable
    Public SpellDuration As New Hashtable
    Public SpellFocusObject As New Hashtable



    Public Sub InitializeSpellDB()
        Dim i As Integer
        For i = 0 To SPELL_EFFECT_COUNT
            SPELL_EFFECTs(i) = AddressOf SPELL_EFFECT_NOTHING
        Next

        SPELL_EFFECTs(0) = AddressOf SPELL_EFFECT_NOTHING                   'None		
        SPELL_EFFECTs(1) = AddressOf SPELL_EFFECT_INSTAKILL                 'Instakill		
        SPELL_EFFECTs(2) = AddressOf SPELL_EFFECT_SCHOOL_DAMAGE             'School Damage		
        SPELL_EFFECTs(3) = AddressOf SPELL_EFFECT_DUMMY                     'Dummy		
        'SPELL_EFFECTs(4) = AddressOf SPELL_EFFECT_PORTAL_TELEPORT           'Portal Teleport		
        SPELL_EFFECTs(5) = AddressOf SPELL_EFFECT_TELEPORT_UNITS            'Teleport Units		
        SPELL_EFFECTs(6) = AddressOf SPELL_EFFECT_APPLY_AURA                'Apply Aura		
        SPELL_EFFECTs(7) = AddressOf SPELL_EFFECT_ENVIRONMENTAL_DAMAGE      'Environmental Damage		
        SPELL_EFFECTs(8) = AddressOf SPELL_EFFECT_MANA_DRAIN                'Power Drain		
        'SPELL_EFFECTs(9) = AddressOf SPELL_EFFECT_HEALTH_LEECH              'Health Leech		
        SPELL_EFFECTs(10) = AddressOf SPELL_EFFECT_HEAL                     'Heal		
        SPELL_EFFECTs(11) = AddressOf SPELL_EFFECT_BIND                     'Bind		
        'SPELL_EFFECTs(12) = AddressOf SPELL_EFFECT_PORTAL                   'Portal		
        'SPELL_EFFECTs(13) = AddressOf SPELL_EFFECT_RITUAL_BASE              'Ritual Base		
        'SPELL_EFFECTs(14) = AddressOf SPELL_EFFECT_RITUAL_SPECIALIZE        'Ritual Specialize		
        'SPELL_EFFECTs(15) = AddressOf SPELL_EFFECT_RITUAL_ACTIVATE_PORTAL   'Ritual Activate Portal		
        SPELL_EFFECTs(16) = AddressOf SPELL_EFFECT_QUEST_COMPLETE           'Quest Complete		
        SPELL_EFFECTs(17) = AddressOf SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL   'Weapon Damage + (noschool)		
        SPELL_EFFECTs(18) = AddressOf SPELL_EFFECT_RESURRECT                'Resurrect		
        '!! SPELL_EFFECTs(19) = AddressOf SPELL_EFFECT_ADD_EXTRA_ATTACKS        'Extra Attacks		
        SPELL_EFFECTs(20) = AddressOf SPELL_EFFECT_DODGE                    'Dodge		
        SPELL_EFFECTs(21) = AddressOf SPELL_EFFECT_EVADE                    'Evade		
        SPELL_EFFECTs(22) = AddressOf SPELL_EFFECT_PARRY                    'Parry		
        SPELL_EFFECTs(23) = AddressOf SPELL_EFFECT_BLOCK                    'Block		
        SPELL_EFFECTs(24) = AddressOf SPELL_EFFECT_CREATE_ITEM              'Create Item		
        'SPELL_EFFECTs(25) = AddressOf SPELL_EFFECT_WEAPON                   'Weapon		
        'SPELL_EFFECTs(26) = AddressOf SPELL_EFFECT_DEFENSE                  'Defense		
        '!! SPELL_EFFECTs(27) = AddressOf SPELL_EFFECT_PERSISTENT_AREA_AURA     'Persistent Area Aura		
        '! SPELL_EFFECTs(28) = AddressOf SPELL_EFFECT_SUMMON                   'Summon		
        '!! SPELL_EFFECTs(29) = AddressOf SPELL_EFFECT_LEAP                     'Leap		
        SPELL_EFFECTs(30) = AddressOf SPELL_EFFECT_ENERGIZE                 'Energize		
        'SPELL_EFFECTs(31) = AddressOf SPELL_EFFECT_WEAPON_PERCENT_DAMAGE    'Weapon % Dmg		
        'SPELL_EFFECTs(32) = AddressOf SPELL_EFFECT_TRIGGER_MISSILE          'Trigger Missile		
        '!! SPELL_EFFECTs(33) = AddressOf SPELL_EFFECT_OPEN_LOCK                'Open Lock	
        'SPELL_EFFECTs(34) = AddressOf SPELL_EFFECT_SUMMON_MOUNT_OBSOLETE	
        '!! SPELL_EFFECTs(35) = AddressOf SPELL_EFFECT_APPLY_AREA_AURA          'Apply Area Aura		
        SPELL_EFFECTs(36) = AddressOf SPELL_EFFECT_LEARN_SPELL              'Learn Spell		
        'SPELL_EFFECTs(37) = AddressOf SPELL_EFFECT_SPELL_DEFENSE            'Spell Defense		
        '! SPELL_EFFECTs(38) = AddressOf SPELL_EFFECT_DISPEL                   'Dispel		
        'SPELL_EFFECTs(39) = AddressOf SPELL_EFFECT_LANGUAGE                 'Language		
        SPELL_EFFECTs(40) = AddressOf SPELL_EFFECT_DUAL_WIELD               'Dual Wield		
        '!! SPELL_EFFECTs(41) = AddressOf SPELL_EFFECT_SUMMON_WILD              'Summon Wild		
        '!! SPELL_EFFECTs(42) = AddressOf SPELL_EFFECT_SUMMON_GUARDIAN          'Summon Guardian		
        '! SPELL_EFFECTs(43) = AddressOf SPELL_EFFECT_TELEPORT_UNITS_FACE_CASTER
        SPELL_EFFECTs(44) = AddressOf SPELL_EFFECT_SCHOOL_DAMAGE            'Skill Step	
        SPELL_EFFECTs(45) = AddressOf SPELL_EFFECT_HONOR
        'SPELL_EFFECTs(46) = AddressOf SPELL_EFFECT_SPAWN                    'Spawn		
        'SPELL_EFFECTs(47) = AddressOf SPELL_EFFECT_TRADE_SKILL              'Spell Cast UI		
        SPELL_EFFECTs(48) = AddressOf SPELL_EFFECT_STEALTH                  'Stealth		
        SPELL_EFFECTs(49) = AddressOf SPELL_EFFECT_DETECT                   'Detect		
        'SPELL_EFFECTs(50) = AddressOf SPELL_EFFECT_TRANS_DOOR               'Summon Object		
        'SPELL_EFFECTs(51) = AddressOf SPELL_EFFECT_FORCE_CRITICAL_HIT       'Force Critical Hit		
        'SPELL_EFFECTs(52) = AddressOf SPELL_EFFECT_GUARANTEE_HIT            'Guarantee Hit		
        'SPELL_EFFECTs(53) = AddressOf SPELL_EFFECT_ENCHANT_ITEM             'Enchant Item Permanent		
        'SPELL_EFFECTs(54) = AddressOf SPELL_EFFECT_ENCHANT_ITEM_TEMPORARY   'Enchant Item Temporary		
        'SPELL_EFFECTs(55) = AddressOf SPELL_EFFECT_TAMECREATURE             'Tame Creature		
        'SPELL_EFFECTs(56) = AddressOf SPELL_EFFECT_SUMMON_PET               'Summon Pet		
        'SPELL_EFFECTs(57) = AddressOf SPELL_EFFECT_LEARN_PET_SPELL          'Learn Pet Spell		
        'SPELL_EFFECTs(58) = AddressOf SPELL_EFFECT_WEAPON_DAMAGE            'Weapon Damage +		
        'SPELL_EFFECTs(59) = AddressOf SPELL_EFFECT_OPEN_LOCK_ITEM           'Open Lock (Item)		
        'SPELL_EFFECTs(60) = AddressOf SPELL_EFFECT_PROFICIENCY              'Proficiency		
        'SPELL_EFFECTs(61) = AddressOf SPELL_EFFECT_SEND_EVENT               'Send Event		
        'SPELL_EFFECTs(62) = AddressOf SPELL_EFFECT_POWER_BURN               'Power Burn		
        'SPELL_EFFECTs(63) = AddressOf SPELL_EFFECT_THREAT                   'Threat		
        'SPELL_EFFECTs(64) = AddressOf SPELL_EFFECT_TRIGGER_SPELL            'Trigger Spell		
        'SPELL_EFFECTs(65) = AddressOf SPELL_EFFECT_HEALTH_FUNNEL            'Health Funnel		
        'SPELL_EFFECTs(66) = AddressOf SPELL_EFFECT_POWER_FUNNEL             'Power Funnel		
        'SPELL_EFFECTs(67) = AddressOf SPELL_EFFECT_HEAL_MAX_HEALTH          'Heal Max Health		
        'SPELL_EFFECTs(68) = AddressOf SPELL_EFFECT_INTERRUPT_CAST           'Interrupt Cast		
        'SPELL_EFFECTs(69) = AddressOf SPELL_EFFECT_DISTRACT                 'Distract		
        'SPELL_EFFECTs(70) = AddressOf SPELL_EFFECT_PULL                     'Pull		
        'SPELL_EFFECTs(71) = AddressOf SPELL_EFFECT_PICKPOCKET               'Pickpocket		
        'SPELL_EFFECTs(72) = AddressOf SPELL_EFFECT_ADD_FARSIGHT             'Add Farsight		
        'SPELL_EFFECTs(73) = AddressOf SPELL_EFFECT_SUMMON_POSSESSED         'Summon Possessed		
        'SPELL_EFFECTs(74) = AddressOf SPELL_EFFECT_SUMMON_TOTEM             'Summon Totem		
        'SPELL_EFFECTs(75) = AddressOf SPELL_EFFECT_HEAL_MECHANICAL          'Heal Mechanical		
        'SPELL_EFFECTs(76) = AddressOf SPELL_EFFECT_SUMMON_OBJECT_WILD       'Summon Object (Wild)		
        'SPELL_EFFECTs(77) = AddressOf SPELL_EFFECT_SCRIPT_EFFECT            'Script Effect		
        'SPELL_EFFECTs(78) = AddressOf SPELL_EFFECT_ATTACK                   'Attack		
        'SPELL_EFFECTs(79) = AddressOf SPELL_EFFECT_SANCTUARY                'Sanctuary		
        'SPELL_EFFECTs(80) = AddressOf SPELL_EFFECT_ADD_COMBO_POINTS         'Add Combo Points		
        'SPELL_EFFECTs(81) = AddressOf SPELL_EFFECT_CREATE_HOUSE             'Create House		
        'SPELL_EFFECTs(82) = AddressOf SPELL_EFFECT_BIND_SIGHT               'Bind Sight		
        SPELL_EFFECTs(83) = AddressOf SPELL_EFFECT_DUEL                     'Duel		
        'SPELL_EFFECTs(84) = AddressOf SPELL_EFFECT_STUCK                    'Stuck		
        'SPELL_EFFECTs(85) = AddressOf SPELL_EFFECT_SUMMON_PLAYER            'Summon Player		
        'SPELL_EFFECTs(86) = AddressOf SPELL_EFFECT_ACTIVATE_OBJECT          'Activate Object		
        'SPELL_EFFECTs(87) = AddressOf SPELL_EFFECT_SUMMON_TOTEM_SLOT1       'Summon Totem (slot 1)		
        'SPELL_EFFECTs(88) = AddressOf SPELL_EFFECT_SUMMON_TOTEM_SLOT2       'Summon Totem (slot 2)		
        'SPELL_EFFECTs(89) = AddressOf SPELL_EFFECT_SUMMON_TOTEM_SLOT3       'Summon Totem (slot 3)		
        'SPELL_EFFECTs(90) = AddressOf SPELL_EFFECT_SUMMON_TOTEM_SLOT4       'Summon Totem (slot 4)		
        'SPELL_EFFECTs(91) = AddressOf SPELL_EFFECT_THREAT_ALL               'Threat (All)		
        'SPELL_EFFECTs(92) = AddressOf SPELL_EFFECT_ENCHANT_HELD_ITEM        'Enchant Held Item		
        'SPELL_EFFECTs(93) = AddressOf SPELL_EFFECT_SUMMON_PHANTASM          'Summon Phantasm		
        'SPELL_EFFECTs(94) = AddressOf SPELL_EFFECT_SELF_RESURRECT           'Self Resurrect		
        'SPELL_EFFECTs(95) = AddressOf SPELL_EFFECT_SKINNING                 'Skinning		
        'SPELL_EFFECTs(96) = AddressOf SPELL_EFFECT_CHARGE                   'Charge		
        'SPELL_EFFECTs(97) = AddressOf SPELL_EFFECT_SUMMON_CRITTER           'Summon Critter		
        'SPELL_EFFECTs(98) = AddressOf SPELL_EFFECT_KNOCK_BACK               'Knock Back		
        'SPELL_EFFECTs(99) = AddressOf SPELL_EFFECT_DISENCHANT               'Disenchant		
        'SPELL_EFFECTs(100) = AddressOf SPELL_EFFECT_INEBRIATE               'Inebriate		
        'SPELL_EFFECTs(101) = AddressOf SPELL_EFFECT_FEED_PET                'Feed Pet		
        'SPELL_EFFECTs(102) = AddressOf SPELL_EFFECT_DISMISS_PET             'Dismiss Pet		
        'SPELL_EFFECTs(103) = AddressOf SPELL_EFFECT_REPUTATION              'Reputation		
        'SPELL_EFFECTs(104) = AddressOf SPELL_EFFECT_SUMMON_OBJECT_SLOT1     'Summon Object (slot 1)		
        'SPELL_EFFECTs(105) = AddressOf SPELL_EFFECT_SUMMON_OBJECT_SLOT2     'Summon Object (slot 2)		
        'SPELL_EFFECTs(106) = AddressOf SPELL_EFFECT_SUMMON_OBJECT_SLOT3     'Summon Object (slot 3)		
        'SPELL_EFFECTs(107) = AddressOf SPELL_EFFECT_SUMMON_OBJECT_SLOT4     'Summon Object (slot 4)		
        'SPELL_EFFECTs(108) = AddressOf SPELL_EFFECT_DISPEL_MECHANIC         'Dispel Mechanic		
        'SPELL_EFFECTs(109) = AddressOf SPELL_EFFECT_SUMMON_DEAD_PET         'Summon Dead Pet		
        'SPELL_EFFECTs(110) = AddressOf SPELL_EFFECT_DESTROY_ALL_TOTEMS      'Destroy All Totems		
        'SPELL_EFFECTs(111) = AddressOf SPELL_EFFECT_DURABILITY_DAMAGE       'Durability Damage		
        'SPELL_EFFECTs(112) = AddressOf SPELL_EFFECT_SUMMON_DEMON            'Summon Demon		
        'SPELL_EFFECTs(113) = AddressOf SPELL_EFFECT_RESURRECT_NEW           'Resurrect (Flat)		
        'SPELL_EFFECTs(114) = AddressOf SPELL_EFFECT_ATTACK_ME               'Attack Me	


        'SPELL_EFFECTs(115) = AddressOf SPELL_EFFECT_DURABILITY_DAMAGE_PCT
        'SPELL_EFFECTs(116) = AddressOf SPELL_EFFECT_SKIN_PLAYER_CORPSE
        'SPELL_EFFECTs(117) = AddressOf SPELL_EFFECT_SPIRIT_HEAL
        'SPELL_EFFECTs(118) = AddressOf SPELL_EFFECT_SKILL
        'SPELL_EFFECTs(119) = AddressOf SPELL_EFFECT_APPLY_AURA_NEW
        SPELL_EFFECTs(120) = AddressOf SPELL_EFFECT_TELEPORT_GRAVEYARD
        'SPELL_EFFECTs(121) = AddressOf SPELL_EFFECT_ADICIONAL_DMG

        'SPELL_EFFECTs(122) = AddressOf SPELL_EFFECT_?
        'SPELL_EFFECTs(123) = AddressOf SPELL_EFFECT_TAXI                   'Taxi Flight
        'SPELL_EFFECTs(124) = AddressOf SPELL_EFFECT_PULL_TOWARD            'Pull target towards you
        'SPELL_EFFECTs(125) = AddressOf SPELL_EFFECT_INVISIBILITY_NEW       '
        'SPELL_EFFECTs(126) = AddressOf SPELL_EFFECT_SPELL_STEAL            'Steal benefical effect
        'SPELL_EFFECTs(127) = AddressOf SPELL_EFFECT_PROSPECT               'Search ore for gems
        'SPELL_EFFECTs(128) = AddressOf SPELL_EFFECT_APPLY_AURA_NEW2
        'SPELL_EFFECTs(129) = AddressOf SPELL_EFFECT_APPLY_AURA_NEW3
        'SPELL_EFFECTs(130) = AddressOf SPELL_EFFECT_?
        'SPELL_EFFECTs(131) = AddressOf SPELL_EFFECT_?
        'SPELL_EFFECTs(132) = AddressOf SPELL_EFFECT_?
        'SPELL_EFFECTs(133) = AddressOf SPELL_EFFECT_FORGET
        'SPELL_EFFECTs(134) = AddressOf SPELL_EFFECT_KILL_CREDIT
        'SPELL_EFFECTs(135) = AddressOf SPELL_EFFECT_SUMMON_PET_NEW





        For i = 0 To AURAs_COUNT
            AURAs(i) = AddressOf SPELL_AURA_NONE
        Next

        AURAs(0) = AddressOf SPELL_AURA_NONE                                            'None
        AURAs(1) = AddressOf SPELL_AURA_BIND_SIGHT                                      'Bind Sight
        AURAs(2) = AddressOf SPELL_AURA_MOD_POSSESS                                     'Mod Possess
        AURAs(3) = AddressOf SPELL_AURA_PERIODIC_DAMAGE                                 'Periodic Damage
        AURAs(4) = AddressOf SPELL_AURA_NONE                                            'Dummy
        'AURAs(	5	) = AddressOf 	SPELL_AURA_MOD_CONFUSE				                'Mod Confuse
        'AURAs(	6	) = AddressOf 	SPELL_AURA_MOD_CHARM				                'Mod Charm
        'AURAs(	7	) = AddressOf 	SPELL_AURA_MOD_FEAR				                    'Mod Fear
        AURAs(8) = AddressOf SPELL_AURA_PERIODIC_HEAL                                   'Periodic Heal
        'AURAs(	9	) = AddressOf 	SPELL_AURA_MOD_ATTACKSPEED			                'Mod Attack Speed
        AURAs(10) = AddressOf SPELL_AURA_MOD_THREAT                                     'Mod Threat
        AURAs(11) = AddressOf SPELL_AURA_MOD_TAUNT                                      'Taunt
        AURAs(12) = AddressOf SPELL_AURA_MOD_STUN                                       'Stun
        'AURAs(	13	) = AddressOf 	SPELL_AURA_MOD_DAMAGE_DONE			                'Mod Damage Done
        'AURAs(	14	) = AddressOf 	SPELL_AURA_MOD_DAMAGE_TAKEN			                'Mod Damage Taken
        'AURAs(	15	) = AddressOf 	SPELL_AURA_DAMAGE_SHIELD			                'Damage Shield
        AURAs(16) = AddressOf SPELL_AURA_MOD_STEALTH                                    'Mod Stealth
        AURAs(17) = AddressOf SPELL_AURA_MOD_DETECT                                     'Mod Detect
        AURAs(18) = AddressOf SPELL_AURA_MOD_INVISIBILITY                               'Mod Invisibility
        AURAs(19) = AddressOf SPELL_AURA_MOD_INVISIBILITY_DETECTION                     'Mod Invisibility Detection
        AURAs(20) = AddressOf SPELL_AURA_PERIODIC_HEAL_PERCENT                          'Mod Health Regeneration %
        AURAs(21) = AddressOf SPELL_AURA_PERIODIC_ENERGIZE_PERCENT                      'Mod Mana Regeneration %
        AURAs(22) = AddressOf SPELL_AURA_MOD_RESISTANCE                                 'Mod Resistance
        AURAs(23) = AddressOf SPELL_AURA_PERIODIC_TRIGGER_SPELL                         'Periodic Trigger
        AURAs(24) = AddressOf SPELL_AURA_PERIODIC_ENERGIZE                              'Periodic Energize
        AURAs(25) = AddressOf SPELL_AURA_MOD_PACIFY                                     'Pacify
        AURAs(26) = AddressOf SPELL_AURA_MOD_ROOT                                       'Root
        AURAs(27) = AddressOf SPELL_AURA_MOD_SILENCE                                    'Silence
        'AURAs(	28	) = AddressOf 	SPELL_AURA_REFLECT_SPELLS			                'Reflect Spells %
        AURAs(29) = AddressOf SPELL_AURA_MOD_STAT                                       'Mod Stat
        AURAs(30) = AddressOf SPELL_AURA_MOD_SKILL                                      'Mod Skill
        AURAs(31) = AddressOf SPELL_AURA_MOD_INCREASE_SPEED                             'Mod Speed
        AURAs(32) = AddressOf SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED                     'Mod Speed Mounted
        AURAs(33) = AddressOf SPELL_AURA_MOD_DECREASE_SPEED                             'Mod Speed Slow
        AURAs(34) = AddressOf SPELL_AURA_MOD_INCREASE_HEALTH                            'Mod Increase Health
        AURAs(35) = AddressOf SPELL_AURA_MOD_INCREASE_ENERGY                            'Mod Increase Energy
        AURAs(36) = AddressOf SPELL_AURA_MOD_SHAPESHIFT                                 'Shapeshift
        'AURAs(	37	) = AddressOf 	SPELL_AURA_EFFECT_IMMUNITY			                'Immune Effect
        'AURAs(	38	) = AddressOf 	SPELL_AURA_STATE_IMMUNITY			                'Immune State
        'AURAs(	39	) = AddressOf 	SPELL_AURA_SCHOOL_IMMUNITY			                'Immune School
        'AURAs(	40	) = AddressOf 	SPELL_AURA_DAMAGE_IMMUNITY			                'Immune Damage
        'AURAs(	41	) = AddressOf 	SPELL_AURA_DISPEL_IMMUNITY			                'Immune Dispel Type
        'AURAs(	42	) = AddressOf 	SPELL_AURA_PROC_TRIGGER_SPELL		                'Proc Trigger Spell
        'AURAs(	43	) = AddressOf 	SPELL_AURA_PROC_TRIGGER_DAMAGE		                'Proc Trigger Damage
        AURAs(44) = AddressOf SPELL_AURA_TRACK_CREATURES                                'Track Creatures
        AURAs(45) = AddressOf SPELL_AURA_TRACK_RESOURCES                                'Track Resources
        'AURAs(	46	) = AddressOf 	SPELL_AURA_MOD_PARRY_SKILL			                'Mod Parry Skill
        'AURAs(	47	) = AddressOf 	SPELL_AURA_MOD_PARRY_PERCENT		                'Mod Parry Percent
        'AURAs(	48	) = AddressOf 	SPELL_AURA_MOD_DODGE_SKILL			                'Mod Dodge Skill
        'AURAs(	49	) = AddressOf 	SPELL_AURA_MOD_DODGE_PERCENT		                'Mod Dodge Percent
        'AURAs(	50	) = AddressOf 	SPELL_AURA_MOD_BLOCK_SKILL			                'Mod Block Skill
        'AURAs(	51	) = AddressOf 	SPELL_AURA_MOD_BLOCK_PERCENT		                'Mod Block Percent
        'AURAs(	52	) = AddressOf 	SPELL_AURA_MOD_CRIT_PERCENT			                'Mod Crit Percent
        'AURAs(	53	) = AddressOf 	SPELL_AURA_PERIODIC_LEECH			                'Periodic Leech
        'AURAs(	54	) = AddressOf 	SPELL_AURA_MOD_HIT_CHANCE			                'Mod Hit Chance
        'AURAs(	55	) = AddressOf 	SPELL_AURA_MOD_SPELL_HIT_CHANCE		                'Mod Spell Hit Chance
        AURAs(56) = AddressOf SPELL_AURA_TRANSFORM                                      'Transform
        'AURAs(	57	) = AddressOf 	SPELL_AURA_MOD_SPELL_CRIT_CHANCE	                'Mod Spell Crit Chance
        AURAs(58) = AddressOf SPELL_AURA_MOD_INCREASE_SWIM_SPEED                        'Mod Speed Swim
        'AURAs(	59	) = AddressOf 	SPELL_AURA_MOD_DAMAGE_DONE_CREATURE	                'Mod Creature Dmg Done
        'AURAs(	60	) = AddressOf 	SPELL_AURA_MOD_PACIFY_SILENCE		                'Pacify & Silence
        AURAs(61) = AddressOf SPELL_AURA_MOD_SCALE                                      'Mod Scale
        'AURAs(	62	) = AddressOf 	SPELL_AURA_PERIODIC_HEALTH_FUNNEL	                'Periodic Health Funnel
        'AURAs(	63	) = AddressOf 	SPELL_AURA_PERIODIC_MANA_FUNNEL		                'Periodic Mana Funnel
        'AURAs(	64	) = AddressOf 	SPELL_AURA_PERIODIC_MANA_LEECH		                'Periodic Mana Leech
        'AURAs(	65	) = AddressOf 	SPELL_AURA_MOD_CASTING_SPEED		                'Haste - Spells
        'AURAs(	66	) = AddressOf 	SPELL_AURA_FEIGN_DEATH				                'Feign Death
        'AURAs(	67	) = AddressOf 	SPELL_AURA_MOD_DISARM				                'Disarm
        'AURAs(	68	) = AddressOf 	SPELL_AURA_MOD_STALKED				                'Mod Stalked
        'AURAs(	69	) = AddressOf 	SPELL_AURA_SCHOOL_ABSORB			                'School Absorb
        'AURAs(	70	) = AddressOf 	SPELL_AURA_EXTRA_ATTACKS			                'Extra Attacks
        'AURAs(	71	) = AddressOf 	SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL				'Mod School Spell Crit Chance
        'AURAs(	72	) = AddressOf 	SPELL_AURA_MOD_POWER_COST			                'Mod Power Cost
        'AURAs(	73	) = AddressOf 	SPELL_AURA_MOD_POWER_COST_SCHOOL	                'Mod School Power Cost
        'AURAs(	74	) = AddressOf 	SPELL_AURA_REFLECT_SPELLS_SCHOOL	                'Reflect School Spells %
        AURAs(75) = AddressOf SPELL_AURA_MOD_LANGUAGE                                   'Mod Language
        AURAs(76) = AddressOf SPELL_AURA_FAR_SIGHT                                      'Far Sight
        'AURAs(	77	) = AddressOf 	SPELL_AURA_MECHANIC_IMMUNITY		                'Immune Mechanic
        AURAs(78) = AddressOf SPELL_AURA_MOUNTED                                        'Mounted
        'AURAs(	79	) = AddressOf 	SPELL_AURA_MOD_DAMAGE_DONE			                'Mod Dmg %
        AURAs(80) = AddressOf SPELL_AURA_MOD_STAT_PERCENT                               'Mod Stat %
        'AURAs(	81	) = AddressOf 	SPELL_AURA_SPLIT_DAMAGE				                'Split Damage
        AURAs(82) = AddressOf SPELL_AURA_WATER_BREATHING                                'Water Breathing
        AURAs(83) = AddressOf SPELL_AURA_MOD_BASE_RESISTANCE                            'Mod Base Resistance
        AURAs(84) = AddressOf SPELL_AURA_MOD_REGEN                                      'Mod Health Regen
        AURAs(85) = AddressOf SPELL_AURA_MOD_POWER_REGEN                                'Mod Power Regen
        'AURAs(	86	) = AddressOf 	SPELL_AURA_CHANNEL_DEATH_ITEM		                'Create Death Item
        'AURAs(	87	) = AddressOf 	SPELL_AURA_MOD_DAMAGE_TAKEN			                'Mod Dmg % Taken
        'AURAs(	88	) = AddressOf 	SPELL_AURA_MOD_REGEN				                'Mod Health Regen Percent
        'AURAs(	89	) = AddressOf 	SPELL_AURA_PERIODIC_DAMAGE_PERCENT	                'Periodic Damage Percent
        'AURAs(	90	) = AddressOf 	SPELL_AURA_MOD_RESIST_CHANCE		                'Mod Resist Chance
        'AURAs(	91	) = AddressOf 	SPELL_AURA_MOD_DETECT_RANGE			                'Mod Detect Range
        'AURAs(	92	) = AddressOf 	SPELL_AURA_PREVENTS_FLEEING			                'Prevent Fleeing
        'AURAs(	93	) = AddressOf 	SPELL_AURA_MOD_UNATTACKABLE			                'Mod Uninteractible
        'AURAs(	94	) = AddressOf 	SPELL_AURA_INTERRUPT_REGEN			                'Interrupt Regen
        AURAs(95) = AddressOf SPELL_AURA_GHOST                                          'Ghost
        'AURAs(	96	) = AddressOf 	SPELL_AURA_SPELL_MAGNET				                'Spell Magnet
        'AURAs(	97	) = AddressOf 	SPELL_AURA_MANA_SHIELD				                'Mana Shield
        'AURAs(	98	) = AddressOf 	SPELL_AURA_MOD_SKILL_TALENT			                'Mod Skill Talent
        AURAs(99) = AddressOf SPELL_AURA_MOD_ATTACK_POWER                               'Mod Attack Power
        'AURAs(	100	) = AddressOf 	SPELL_AURA_AURAS_VISIBLE			                'Auras Visible
        AURAs(101) = AddressOf SPELL_AURA_MOD_RESISTANCE_PCT                            'Mod Resistance %
        'AURAs(	102	) = AddressOf 	SPELL_AURA_MOD_CREATURE_ATTACK_POWER			    'Mod Creature Attack Power
        AURAs(103) = AddressOf SPELL_AURA_MOD_TOTAL_THREAT                              'Mod Total Threat (Fade)
        AURAs(104) = AddressOf SPELL_AURA_WATER_WALK                                    'Water Walk
        AURAs(105) = AddressOf SPELL_AURA_FEATHER_FALL                                  'Feather Fall
        AURAs(106) = AddressOf SPELL_AURA_HOVER                                         'Hover
        'AURAs(	107	) = AddressOf 	SPELL_AURA_ADD_FLAT_MODIFIER		                'Add Flat Modifier
        'AURAs(	108	) = AddressOf 	SPELL_AURA_ADD_PCT_MODIFIER			                'Add % Modifier
        'AURAs(	109	) = AddressOf 	SPELL_AURA_ADD_TARGET_TRIGGER		                'Add Class Target Trigger
        'AURAs(	110	) = AddressOf 	SPELL_AURA_MOD_POWER_REGEN_PERCENT	                'Mod Power Regen %
        'AURAs(	111	) = AddressOf 	SPELL_AURA_ADD_CASTER_HIT_TRIGGER	                'Add Class Caster Hit Trigger
        'AURAs(	112	) = AddressOf 	SPELL_AURA_OVERRIDE_CLASS_SCRIPTS	                'Override Class Scripts
        'AURAs(	113	) = AddressOf 	SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN	                'Mod Ranged Dmg Taken
        'AURAs(	114	) = AddressOf 	SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT			    'Mod Ranged % Dmg Taken
        'AURAs(	115	) = AddressOf 	SPELL_AURA_MOD_HEALING				                'Mod Healing
        'AURAs(	116	) = AddressOf 	SPELL_AURA_IGNORE_REGEN_INTERRUPT	                'Regen During Combat
        'AURAs(	117	) = AddressOf 	SPELL_AURA_MOD_MECHANIC_RESISTANCE	                'Mod Mechanic Resistance
        'AURAs(	118	) = AddressOf 	SPELL_AURA_MOD_HEALING_PCT			                'Mod Healing %
        'AURAs(	119	) = AddressOf 	SPELL_AURA_SHARE_PET_TRACKING		                'Share Pet Tracking
        'AURAs(	120	) = AddressOf 	SPELL_AURA_UNTRACKABLE				                'Untrackable
        AURAs(121) = AddressOf SPELL_AURA_EMPATHY                                       'Empathy (Lore, whatever)
        'AURAs(	122	) = AddressOf 	SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT	                'Mod Offhand Dmg %
        'AURAs(	123	) = AddressOf 	SPELL_AURA_MOD_POWER_COST_PCT		                'Mod Power Cost %
        AURAs(124) = AddressOf SPELL_AURA_MOD_RANGED_ATTACK_POWER                       'Mod Ranged Attack Power
        'AURAs(	125	) = AddressOf 	SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN	                'Mod Melee Dmg Taken
        'AURAs(	126	) = AddressOf 	SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT			    'Mod Melee % Dmg Taken
        'AURAs(	127	) = AddressOf 	SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS	    'Rngd Atk Pwr Attckr Bonus
        'AURAs(	128	) = AddressOf 	SPELL_AURA_MOD_POSSESS_PET			                'Mod Possess Pet
        AURAs(129) = AddressOf SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS                     'Mod Speed Always
        AURAs(130) = AddressOf SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED_ALWAYS             'Mod Mounted Speed Always
        'AURAs(	131	) = AddressOf 	SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER		    'Mod Creature Ranged Attack Power
        'AURAs(	132	) = AddressOf 	SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT			    'Mod Increase Energy %
        'AURAs(	133	) = AddressOf 	SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT			    'Mod Max Health %
        'AURAs(	134	) = AddressOf 	SPELL_AURA_MOD_MANA_REGEN_INTERRUPT				    'Mod Interrupted Mana Regen
        'AURAs(	135	) = AddressOf 	SPELL_AURA_MOD_HEALING_DONE			                'Mod Healing Done
        'AURAs(	136	) = AddressOf 	SPELL_AURA_MOD_HEALING_DONE_PERCENT	                'Mod Healing Done %
        'AURAs(	137	) = AddressOf 	SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE			    'Mod Total Stat %
        'AURAs(	138	) = AddressOf 	SPELL_AURA_MOD_HASTE				                'Haste - Melee
        'AURAs(	139	) = AddressOf 	SPELL_AURA_FORCE_REACTION			                'Force Reaction
        'AURAs(	140	) = AddressOf 	SPELL_AURA_MOD_RANGED_HASTE			                'Haste - Ranged
        'AURAs(	141	) = AddressOf 	SPELL_AURA_MOD_RANGED_AMMO_HASTE	                'Haste - Ranged (Ammo Only)
        AURAs(142) = AddressOf SPELL_AURA_MOD_BASE_RESISTANCE_PCT                       'Mod Base Resistance %
        AURAs(143) = AddressOf SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE                      'Mod Resistance Exclusive
        AURAs(144) = AddressOf SPELL_AURA_SAFE_FALL                                     'Safe Fall
        'AURAs(	145	) = AddressOf 	SPELL_AURA_CHARISMA				                    'Charisma
        'AURAs(	146	) = AddressOf 	SPELL_AURA_PERSUADED				                'Persuaded
        'AURAs(	147	) = AddressOf 	SPELL_AURA_ADD_CREATURE_IMMUNITY	                'Add Creature Immunity
        'AURAs(	148	) = AddressOf 	SPELL_AURA_RETAIN_COMBO_POINTS		                'Retain Combo Points
        'AURAs(	149	) = AddressOf 	SPELL_AURA_RESIST_PUSHBACK			                'Resist Pushback
        'AURAs(	150	) = AddressOf 	SPELL_AURA_MOD_SHIELD_BLOCK			                'Mod Shield Block %
        'AURAs(	151	) = AddressOf 	SPELL_AURA_TRACK_STEALTHED			                'Track Stealthed
        'AURAs(	152	) = AddressOf 	SPELL_AURA_MOD_DETECTED_RANGE		                'Mod Aggro Range
        'AURAs(	153	) = AddressOf 	SPELL_AURA_SPLIT_DAMAGE_FLAT		                'Split Damage Flat
        'AURAs(	154	) = AddressOf 	SPELL_AURA_MOD_STEALTH_LEVEL		                'Stealth Level Modifier
        'AURAs(	155	) = AddressOf 	SPELL_AURA_MOD_WATER_BREATHING		                'Mod Water Breathing
        'AURAs(	156	) = AddressOf 	SPELL_AURA_MOD_REPUTATION_ADJUST	                'Mod Reputation Gain
        'AURAs(	157	) = AddressOf 	SPELL_AURA_PET_DAMAGE_MULTI			                'Mod Pet Damage

        'AURAs(	158	) = AddressOf                                                       'Mod Shield Block
        'AURAs(	159	) = AddressOf                                                       'Honorless
        'AURAs(	160 ) = AddressOf 	                        			                'Mod Side/Rear PBAE Damage Taken %
        'AURAs(	161 ) = AddressOf 	                        			                'Mod Health Regen In Combat
        'AURAs(	162 ) = AddressOf 	                        			                'Power Burn (Mana)
        'AURAs(	163 ) = AddressOf 	                        			                'Mod Critical Damage 
        'AURAs(	164 ) = AddressOf  	                        			                'TEST
        'AURAs(	165 ) = AddressOf  	                        			                '
        'AURAs(	166 ) = AddressOf 	                        			                'Mod Attack Power %
        'AURAs(	168 ) = AddressOf 	                        			                'Increase Damage % (vs. %X)
        'AURAs(	169 ) = AddressOf 	                        			                'Increase Critical % (vs. %X)
        'AURAs(	170 ) = AddressOf  	                        			                '
        'AURAs(	171 ) = AddressOf  	                        			                '
        'AURAs(	172 ) = AddressOf  	                        			                '
        'AURAs(	173 ) = AddressOf  	                        			                '
        'AURAs(	174 ) = AddressOf 	                        			                'Increase Spell Damage by % Spirit (Spells)
        'AURAs(	175 ) = AddressOf 	                        			                'Increase Spell Healing by % Spirit
        'AURAs(	176 ) = AddressOf  	                        			                '
        'AURAs(	177 ) = AddressOf 	                        			                'Area Charm
        'AURAs(	178 ) = AddressOf  	                        			                '
        'AURAs(	179 ) = AddressOf  	                        			                '
        'AURAs(	180	) = AddressOf 	                        			                'Increase Spell Damage (vs. %X)
        'AURAs(	171 ) = AddressOf  	                        			                '
        'AURAs(	182	) = AddressOf 	                        			                'Increase Resist by % of Intellect (%X)
        'AURAs(	183	) = AddressOf 	                        			                'Decrease Critical Threat by % (Spells)
        'AURAs(	184	) = AddressOf                                                       'Mod Melee GetHit Chance
        'AURAs(	185	) = AddressOf                                                       'Mod Ranged GetHit Chance
        'AURAs(	186	) = AddressOf                                                       'Mod Spell GetHit Chance
        'AURAs(	187	) = AddressOf                                                       'Mod Melee Critical GetHit Chance
        'AURAs(	188	) = AddressOf                                                       'Mod Ranged Critical GetHit Chance
        'AURAs(	189	) = AddressOf                                                       'Mod Skill Rating
        'AURAs(	190	) = AddressOf                                                       'Mod Reputation Gain
        'AURAs(	191	) = AddressOf                                                       '
        'AURAs(	192	) = AddressOf                                                       '
        'AURAs(	193	) = AddressOf                                                       '
        'AURAs(	194	) = AddressOf                                                       'Mod Spell Damage by % of Intellect
        'AURAs(	195	) = AddressOf                                                       'Mod Spell Healing by % of Intellect
        'AURAs(	196	) = AddressOf                                                       'Mod Global Cooldowns
        'AURAs(	197	) = AddressOf                                                       'No Critical Damage Taken
        'AURAs(	198	) = AddressOf                                                       'Mod Weapon Skills
        'AURAs(	199	) = AddressOf                                                       'Mod Hit Chance
        'AURAs(	200	) = AddressOf                                                       'Mod Gained XP
        'AURAs(	201	) = AddressOf                                                       'Fly
        'AURAs(	202	) = AddressOf                                                       '
        'AURAs(	203	) = AddressOf                                                       'Mod Melee Critical Damage Taken
        'AURAs(	204	) = AddressOf                                                       'Mod Ranged Critical Damage Taken
        'AURAs(	205	) = AddressOf                                                       '
        'AURAs(	206	) = AddressOf 	                        			                'Mod Fly Speed Always
        AURAs(207) = AddressOf SPELL_AURA_MOD_INCREASE_MOUNTED_FLY_SPEED                'Mod Fly Speed Mounted
        AURAs(208) = AddressOf SPELL_AURA_MOD_INCREASE_FLY_SPEED                        'Mod Fly Speed
        AURAs(209) = AddressOf SPELL_AURA_MOD_INCREASE_MOUNTED_FLY_SPEED_ALWAYS         'Mod Fly Speed Mounted Always
        'AURAs(	210	) = AddressOf 	                                                    '
        'AURAs(	211	) = AddressOf 	                                                    '
        'AURAs(	212	) = AddressOf 	                                                    'Mod Ranged Attack Power by % of Intellect
        'AURAs(	213	) = AddressOf 	                                                    'Mod Rage From Damage
        'AURAs(	214	) = AddressOf 	                                                    '
        'AURAs(	215	) = AddressOf 	                                                    'TEST
        'AURAs(	216	) = AddressOf 	                                                    'Mod Casting Speed
        'AURAs(	217	) = AddressOf 	                                                    '
        'AURAs(	218	) = AddressOf 	                                                    '
        'AURAs(	219	) = AddressOf 	                                                    'Mod Regenerate by % of Intellect
        'AURAs(	220	) = AddressOf 	                                                    'Increase Spell Healing by % Strength



        Dim InitializeDB As New ScriptedObject("scripts\InitializeSpellDB.vb", "InitializeDB.dll", True)
        InitializeDB.Invoke("Initializators", "Initialize")
        InitializeDB.Dispose()
    End Sub


#End Region

#Region "WS.Spells.SpellEffects"
    Public Enum SpellEffects_Names As Integer
        SPELL_EFFECT_NOTHING = 0
        SPELL_EFFECT_INSTAKILL = 1
        SPELL_EFFECT_SCHOOL_DAMAGE = 2
        SPELL_EFFECT_DUMMY = 3
        SPELL_EFFECT_PORTAL_TELEPORT = 4
        SPELL_EFFECT_TELEPORT_UNITS = 5
        SPELL_EFFECT_APPLY_AURA = 6
        SPELL_EFFECT_ENVIRONMENTAL_DAMAGE = 7
        SPELL_EFFECT_MANA_DRAIN = 8
        SPELL_EFFECT_HEALTH_LEECH = 9
        SPELL_EFFECT_HEAL = 10
        SPELL_EFFECT_BIND = 11
        SPELL_EFFECT_PORTAL = 12
        SPELL_EFFECT_RITUAL_BASE = 13
        SPELL_EFFECT_RITUAL_SPECIALIZE = 14
        SPELL_EFFECT_RITUAL_ACTIVATE_PORTAL = 15
        SPELL_EFFECT_QUEST_COMPLETE = 16
        SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL = 17
        SPELL_EFFECT_RESURRECT = 18
        SPELL_EFFECT_ADD_EXTRA_ATTACKS = 19
        SPELL_EFFECT_DODGE = 20
        SPELL_EFFECT_EVADE = 21
        SPELL_EFFECT_PARRY = 22
        SPELL_EFFECT_BLOCK = 23
        SPELL_EFFECT_CREATE_ITEM = 24
        SPELL_EFFECT_WEAPON = 25
        SPELL_EFFECT_DEFENSE = 26
        SPELL_EFFECT_PERSISTENT_AREA_AURA = 27
        SPELL_EFFECT_SUMMON = 28
        SPELL_EFFECT_LEAP = 29
        SPELL_EFFECT_ENERGIZE = 30
        SPELL_EFFECT_WEAPON_PERCENT_DAMAGE = 31
        SPELL_EFFECT_TRIGGER_MISSILE = 32
        SPELL_EFFECT_OPEN_LOCK = 33
        SPELL_EFFECT_SUMMON_MOUNT_OBSOLETE = 34
        SPELL_EFFECT_APPLY_AREA_AURA = 35
        SPELL_EFFECT_LEARN_SPELL = 36
        SPELL_EFFECT_SPELL_DEFENSE = 37
        SPELL_EFFECT_DISPEL = 38
        SPELL_EFFECT_LANGUAGE = 39
        SPELL_EFFECT_DUAL_WIELD = 40
        SPELL_EFFECT_SUMMON_WILD = 41
        SPELL_EFFECT_SUMMON_GUARDIAN = 42
        SPELL_EFFECT_TELEPORT_UNITS_FACE_CASTER = 43
        SPELL_EFFECT_SKILL_STEP = 44
        SPELL_EFFECT_UNDEFINED_45 = 45
        SPELL_EFFECT_SPAWN = 46
        SPELL_EFFECT_TRADE_SKILL = 47
        SPELL_EFFECT_STEALTH = 48
        SPELL_EFFECT_DETECT = 49
        'SPELL_EFFECT_SUMMON_OBJECT = 50
        SPELL_EFFECT_TRANS_DOOR = 50
        SPELL_EFFECT_FORCE_CRITICAL_HIT = 51
        SPELL_EFFECT_GUARANTEE_HIT = 52
        SPELL_EFFECT_ENCHANT_ITEM = 53
        SPELL_EFFECT_ENCHANT_ITEM_TEMPORARY = 54
        SPELL_EFFECT_TAMECREATURE = 55
        SPELL_EFFECT_SUMMON_PET = 56
        SPELL_EFFECT_LEARN_PET_SPELL = 57
        SPELL_EFFECT_WEAPON_DAMAGE = 58
        SPELL_EFFECT_OPEN_LOCK_ITEM = 59
        SPELL_EFFECT_PROFICIENCY = 60
        SPELL_EFFECT_SEND_EVENT = 61
        SPELL_EFFECT_POWER_BURN = 62
        SPELL_EFFECT_THREAT = 63
        SPELL_EFFECT_TRIGGER_SPELL = 64
        SPELL_EFFECT_HEALTH_FUNNEL = 65
        SPELL_EFFECT_POWER_FUNNEL = 66
        SPELL_EFFECT_HEAL_MAX_HEALTH = 67
        SPELL_EFFECT_INTERRUPT_CAST = 68
        SPELL_EFFECT_DISTRACT = 69
        SPELL_EFFECT_PULL = 70
        SPELL_EFFECT_PICKPOCKET = 71
        SPELL_EFFECT_ADD_FARSIGHT = 72
        SPELL_EFFECT_SUMMON_POSSESSED = 73
        SPELL_EFFECT_SUMMON_TOTEM = 74
        SPELL_EFFECT_HEAL_MECHANICAL = 75
        SPELL_EFFECT_SUMMON_OBJECT_WILD = 76
        SPELL_EFFECT_SCRIPT_EFFECT = 77
        SPELL_EFFECT_ATTACK = 78
        SPELL_EFFECT_SANCTUARY = 79
        SPELL_EFFECT_ADD_COMBO_POINTS = 80
        SPELL_EFFECT_CREATE_HOUSE = 81
        SPELL_EFFECT_BIND_SIGHT = 82
        SPELL_EFFECT_DUEL = 83
        SPELL_EFFECT_STUCK = 84
        SPELL_EFFECT_SUMMON_PLAYER = 85
        SPELL_EFFECT_ACTIVATE_OBJECT = 86
        SPELL_EFFECT_SUMMON_TOTEM_SLOT1 = 87
        SPELL_EFFECT_SUMMON_TOTEM_SLOT2 = 88
        SPELL_EFFECT_SUMMON_TOTEM_SLOT3 = 89
        SPELL_EFFECT_SUMMON_TOTEM_SLOT4 = 90
        SPELL_EFFECT_THREAT_ALL = 91
        SPELL_EFFECT_ENCHANT_HELD_ITEM = 92
        SPELL_EFFECT_SUMMON_PHANTASM = 93
        SPELL_EFFECT_SELF_RESURRECT = 94
        SPELL_EFFECT_SKINNING = 95
        SPELL_EFFECT_CHARGE = 96
        SPELL_EFFECT_SUMMON_CRITTER = 97
        SPELL_EFFECT_KNOCK_BACK = 98
        SPELL_EFFECT_DISENCHANT = 99
        SPELL_EFFECT_INEBRIATE = 100
        SPELL_EFFECT_FEED_PET = 101
        SPELL_EFFECT_DISMISS_PET = 102
        SPELL_EFFECT_REPUTATION = 103
        SPELL_EFFECT_SUMMON_OBJECT_SLOT1 = 104
        SPELL_EFFECT_SUMMON_OBJECT_SLOT2 = 105
        SPELL_EFFECT_SUMMON_OBJECT_SLOT3 = 106
        SPELL_EFFECT_SUMMON_OBJECT_SLOT4 = 107
        SPELL_EFFECT_DISPEL_MECHANIC = 108
        SPELL_EFFECT_SUMMON_DEAD_PET = 109
        SPELL_EFFECT_DESTROY_ALL_TOTEMS = 110
        SPELL_EFFECT_DURABILITY_DAMAGE = 111
        SPELL_EFFECT_SUMMON_DEMON = 112
        SPELL_EFFECT_RESURRECT_NEW = 113
        SPELL_EFFECT_ATTACK_ME = 114
        SPELL_EFFECT_DURABILITY_DAMAGE_PCT = 115
        SPELL_EFFECT_SKIN_PLAYER_CORPSE = 116
        SPELL_EFFECT_SPIRIT_HEAL = 117
        SPELL_EFFECT_SKILL = 118
        SPELL_EFFECT_APPLY_AURA_NEW = 119
        SPELL_EFFECT_TELEPORT_GRAVEYARD = 120
        SPELL_EFFECT_ADICIONAL_DMG = 121
    End Enum

    Delegate Function SpellEffectHandler(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef value As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
    Public Class SpellEffectParameter
        Public Caster As BaseObject

        Public Target As BaseObject
        Public SourceX As Single = 0
        Public SourceY As Single = 0
        Public SourceZ As Single = 0
        Public DestinationX As Single = 0
        Public DestinationY As Single = 0
        Public DestinationZ As Single = 0
    End Class
    Public Const SPELL_EFFECT_COUNT As Integer = 135
    Public SPELL_EFFECTs(SPELL_EFFECT_COUNT) As SpellEffectHandler

    Public Function SPELL_EFFECT_NOTHING(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef value As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Infected.Add(Target.unitTarget.GUID)
        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_BIND(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef value As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Infected.Add(Target.unitTarget.GUID)
        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_DUMMY(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef value As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Infected.Add(Target.unitTarget.GUID)
        Return SpellFailedReason.CAST_NO_ERROR
    End Function

    Public Function SPELL_EFFECT_INSTAKILL(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef value As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Target.unitTarget.Die(Caster)
        Infected.Add(Target.unitTarget.GUID)
        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_SCHOOL_DAMAGE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Dim Damage As Integer = SpellInfo.GetValue(Caster.Level)
        Dim LogFlag As Byte = 5

        If TypeOf Caster Is CharacterObject Then
            If (CType(Caster, CharacterObject).GetCriticalWithSpells + 5) > Rnd.Next(0, 100) Then
                Damage = Fix(1.5F * Damage)
                LogFlag = 7
            End If
        End If

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELECTED_ENEMY
                Target.unitTarget.DealDamage(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)
            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.DealDamage(Damage, Caster)
                    Infected.Add(unit.GUID)
                    SendNonMeleeDamageLog(Caster, unit, SpellID, Damage, 0, 0, LogFlag)
                Next
            Case Else
                Target.unitTarget.DealDamage(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_ENVIRONMENTAL_DAMAGE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Dim Damage As Integer = SpellInfo.GetValue(Caster.Level)

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELECTED_ENEMY
                Target.unitTarget.DealDamage(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                If TypeOf Target.unitTarget Is CharacterObject Then CType(Target.unitTarget, CharacterObject).LogEnvironmentalDamage(SPELLs(SpellID).School, Damage)

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.DealDamage(Damage, Caster)
                    Infected.Add(unit.GUID)
                    If TypeOf unit Is CharacterObject Then CType(unit, CharacterObject).LogEnvironmentalDamage(SPELLs(SpellID).School, Damage)
                Next

            Case Else
                Target.unitTarget.DealDamage(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                If TypeOf Target.unitTarget Is CharacterObject Then CType(Target.unitTarget, CharacterObject).LogEnvironmentalDamage(SPELLs(SpellID).School, Damage)
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_TELEPORT_UNITS(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        '! No need this
        'Select Case SpellInfo.implicitTargetA
        '    Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_SELECTED_FRIEND, SpellImplicitTargets.TARGET_DUEL_VS_PLAYER
        '    Case SpellImplicitTargets.TARGET_SELECTED_ENEMY
        '    Case SpellImplicitTargets.TARGET_AROUND_CASTER_PARTY
        'End Select


        If GuidIsPlayer(Target.unitTarget.GUID) Then
            With CType(Target.unitTarget, CharacterObject)
                Select Case SpellID
                    Case 8690
                        .Teleport(.bindpoint_positionX, .bindpoint_positionY, .bindpoint_positionZ, .orientation)
                End Select
            End With
        Else
            Log.WriteLine(LogType.DEBUG, "DEBUG: Casting SPELL_EFFECT_TELEPORT_UNITS on unknown object.")
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_MANA_DRAIN(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        If SpellInfo.MiscValue <> 0 Then
            Log.WriteLine(LogType.DEBUG, "DEBUG: Unsupported powerType to drain.")
            Exit Function
        End If


        Dim Damage As Integer = SpellInfo.GetValue(Caster.Level)

        If TypeOf Caster Is CharacterObject Then
            Damage += SpellInfo.valuePerLevel * CType(Caster, CharacterObject).Level
        End If


        '! Only 1 target everytime, so no need to check
        'Select Case SpellInfo.implicitTargetA
        '    Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_NOTHING
        '    Case SpellImplicitTargets.TARGET_PET
        '    Case SpellImplicitTargets.TARGET_SELECTED_ENEMY
        'End Select









        'DONE: Get mana from victim
        Target.unitTarget.Mana.Current -= Damage
        'DONE: Give mana to caster
        Caster.Mana.Current += Damage


        'DONE: Send victim mana update, for near
        If GuidIsCreature(Target.unitTarget.GUID) Then
            Dim myTmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            Dim myPacket As New UpdatePacketClass
            myTmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + SpellInfo.MiscValue, CType(CType(Target.unitTarget, CreatureObject).Mana.Current, Integer))
            myTmpUpdate.AddToPacket(myPacket, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target.unitTarget, CreatureObject), 0)
            Target.unitTarget.SendToNearPlayers(myPacket)
            myPacket.Dispose()
            myTmpUpdate.Dispose()
        ElseIf GuidIsPlayer(Target.unitTarget.GUID) Then
            CType(Caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + SpellInfo.MiscValue, CType(CType(Target.unitTarget, CharacterObject).Mana.Current, Integer))
        End If

        'TODO: SpellFailedReason.CAST_FAIL_ALREADY_FULL_MANA
        'DONE: Send caster mana update, for near
        If TypeOf Caster Is CreatureObject Then
            Dim TmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            Dim Packet As New UpdatePacketClass
            TmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + SpellInfo.MiscValue, CType(CType(Caster, CreatureObject).Mana.Current, Integer))
            TmpUpdate.AddToPacket(Packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Caster, CreatureObject), 0)
            Target.unitTarget.SendToNearPlayers(Packet)
            Packet.Dispose()
            TmpUpdate.Dispose()
        ElseIf TypeOf Caster Is CharacterObject Then
            CType(Caster, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POWER1 + SpellInfo.MiscValue, CType(CType(Caster, CharacterObject).Mana.Current, Integer))
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_HEAL(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Dim Damage As Integer = SpellInfo.GetValue(Caster.Level)
        Dim LogFlag As Byte = 5

        If TypeOf Caster Is CharacterObject Then
            Damage += SpellInfo.valuePerLevel * CType(Caster, CharacterObject).Level
            If (CType(Caster, CharacterObject).GetCriticalWithSpells + 5) > Rnd.Next(0, 100) Then
                Damage = Fix(1.5F * Damage)
                LogFlag = 7
            End If
        End If



        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_CASTER, SpellImplicitTargets.TARGET_SELECTED_FRIEND, SpellImplicitTargets.TARGET_DUEL_VS_PLAYER, SpellImplicitTargets.TARGET_MASTER
                Caster.Heal(Damage, Caster)
                Infected.Add(Caster.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)

            Case SpellImplicitTargets.TARGET_PET, SpellImplicitTargets.TARGET_SELECTED_ENEMY
                Target.unitTarget.Heal(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_PARTY
                Dim Targets As ArrayList = GetPartyMembersAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.Heal(Damage, Caster)
                    Infected.Add(unit.GUID)
                    SendNonMeleeDamageLog(Caster, unit, SpellID, Damage, 0, 0, LogFlag)
                Next

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.Heal(Damage, Caster)
                    Infected.Add(unit.GUID)
                    SendNonMeleeDamageLog(Caster, unit, SpellID, Damage, 0, 0, LogFlag)
                Next

            Case SpellImplicitTargets.TARGET_CHAIN
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select


        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_ENERGIZE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Dim Damage As Integer = SpellInfo.GetValue(Caster.Level)
        Dim LogFlag As Byte = 5

        If TypeOf Caster Is CharacterObject Then
            Damage += SpellInfo.valuePerLevel * CType(Caster, CharacterObject).Level
            If (CType(Caster, CharacterObject).GetCriticalWithSpells + 5) > Rnd.Next(0, 100) Then
                Damage = Fix(1.5F * Damage)
                LogFlag = 7
            End If
        End If



        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_CASTER
                Caster.Energize(Damage, Caster)
                Infected.Add(Caster.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)

            Case SpellImplicitTargets.TARGET_PET, SpellImplicitTargets.TARGET_SELECTED_FRIEND
                Target.unitTarget.Energize(Damage, Caster)
                Infected.Add(Target.unitTarget.GUID)
                SendNonMeleeDamageLog(Caster, Target.unitTarget, SpellID, Damage, 0, 0, LogFlag)

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_PARTY
                Dim Targets As ArrayList = GetPartyMembersAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.Energize(Damage, Caster)
                    Infected.Add(unit.GUID)
                    SendNonMeleeDamageLog(Caster, unit, SpellID, Damage, 0, 0, LogFlag)
                Next

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    unit.Energize(Damage, Caster)
                    Infected.Add(unit.GUID)
                    SendNonMeleeDamageLog(Caster, unit, SpellID, Damage, 0, 0, LogFlag)
                Next

            Case SpellImplicitTargets.TARGET_DUEL_VS_PLAYER
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select


        Return SpellFailedReason.CAST_NO_ERROR
    End Function


    Public Function SPELL_EFFECT_LEARN_SPELL(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELF
                If SpellInfo.TriggerSpell <> 0 Then
                    CType(Caster, CharacterObject).LearnSpell(SpellInfo.TriggerSpell)
                    Infected.Add(Target.unitTarget.GUID)
                End If
            Case SpellImplicitTargets.TARGET_PET
                Return SpellFailedReason.CAST_FAIL_TOO_MANY_SKILLS
            Case Else
                If TypeOf Target.unitTarget Is CharacterObject Then
                    If SpellInfo.TriggerSpell <> 0 Then
                        CType(Target.unitTarget, CharacterObject).LearnSpell(SpellInfo.TriggerSpell)
                        Infected.Add(Target.unitTarget.GUID)
                    End If
                End If
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_SKILL_STEP(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            If SpellInfo.MiscValue <> 0 Then
                CType(Target.unitTarget, CharacterObject).LearnSkill(SpellInfo.MiscValue, , (SpellInfo.valueBase + 1) * 75)
                Infected.Add(Target.unitTarget.GUID)
            End If
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_EVADE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CreatureObject Then
            If Not CType(Target.unitTarget, CreatureObject).aiScript Is Nothing Then
                CType(Target.unitTarget, CreatureObject).aiScript.State = WS_Creatures_AI.TBaseAI.AIState.AI_EVADE
                Infected.Add(Target.unitTarget.GUID)
            End If
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_DODGE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            CType(Target.unitTarget, CharacterObject).combatDodge += SpellInfo.GetValue(Caster.Level)
            Infected.Add(Target.unitTarget.GUID)
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_PARRY(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            CType(Target.unitTarget, CharacterObject).combatParry += SpellInfo.GetValue(Caster.Level)
            Infected.Add(Target.unitTarget.GUID)
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_BLOCK(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            CType(Target.unitTarget, CharacterObject).combatBlock += SpellInfo.GetValue(Caster.Level)
            Infected.Add(Target.unitTarget.GUID)
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_DUAL_WIELD(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            CType(Target.unitTarget, CharacterObject).spellCanDualWeild = True
            Infected.Add(Target.unitTarget.GUID)
        End If

        Return SpellFailedReason.CAST_NO_ERROR
    End Function


    Public Function SPELL_EFFECT_WEAPON_DAMAGE_NOSCHOOL(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Caster Is CharacterObject Then
            If CType(Caster, CharacterObject).attackState.combatNextAttackSpell Then Return SpellFailedReason.CAST_FAIL_SPELL_IN_PROGRESS

            CType(Caster, CharacterObject).attackState.combatNextAttackSpell = True
            CType(Caster, CharacterObject).attackState.combatNextAttack.WaitOne()
        Else
            'TODO: Creatures still cant cast this spell
            Return SpellFailedReason.CAST_FAIL_NOT_READY
        End If


        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELECTED_ENEMY
                Dim damageInfo As DamageInfo = CalculateDamage(Caster, Target.unitTarget, False)
                CType(Caster, CharacterObject).attackState.DoMeleeDamageBySpell(Caster, Target.unitTarget, SpellInfo.GetValue(Caster.Level), SpellID)
                Infected.Add(Target.unitTarget.GUID)

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    CType(Caster, CharacterObject).attackState.DoMeleeDamageBySpell(Caster, unit, SpellInfo.GetValue(Caster.Level), SpellID)
                    Infected.Add(unit.GUID)
                Next

            Case SpellImplicitTargets.TARGET_UNK54
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select


        Return SpellFailedReason.CAST_NO_ERROR
    End Function


    Public Function SPELL_EFFECT_HONOR(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        If TypeOf Target.unitTarget Is CharacterObject Then
            CType(Target.unitTarget, CharacterObject).HonorCurrency += SpellInfo.GetValue(Caster.Level)
            CType(Target.unitTarget, CharacterObject).HonorSave()
        End If


        Return SpellFailedReason.CAST_NO_ERROR
    End Function





    Private Const SLOT_NOT_FOUND As Integer = -1
    Private Const SLOT_CREATE_NEW As Integer = -2
    Private Const SLOT_NO_SPACE As Integer = Integer.MaxValue
    Public Function ApplyAura(ByRef auraTarget As BaseUnit, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer) As SpellFailedReason
        Dim spellCasted As Integer = SLOT_NOT_FOUND
        Do
            'DONE: If active add to visible
            'TODO: If positive effect add to upper part spells
            Dim AuraStart As Integer = MAX_AURA_EFFECTs_VISIBLE - 1
            Dim AuraEnd As Integer = 0

            'DONE: Passives are not displayed
            If CType(SPELLs(SpellID), SpellInfo).IsPassive Then AuraEnd = MAX_AURA_EFFECTs_VISIBLE

            'DONE: Find spell aura slot
            For i As Integer = AuraStart To AuraEnd Step -1
                If (Not auraTarget.ActiveSpells(i) Is Nothing) AndAlso _
                   auraTarget.ActiveSpells(i).SpellID = SpellID Then

                    spellCasted = i
                    If auraTarget.ActiveSpells(i).Aura1 Is Nothing Then
                        auraTarget.ActiveSpells(i).Aura1 = AURAs(SpellInfo.ApplyAuraIndex)
                        auraTarget.ActiveSpells(i).Aura1_Info = SpellInfo
                        Exit For
                    ElseIf auraTarget.ActiveSpells(i).Aura2 Is Nothing Then
                        auraTarget.ActiveSpells(i).Aura2 = AURAs(SpellInfo.ApplyAuraIndex)
                        auraTarget.ActiveSpells(i).Aura2_Info = SpellInfo
                        Exit For
                    ElseIf auraTarget.ActiveSpells(i).Aura3 Is Nothing Then
                        auraTarget.ActiveSpells(i).Aura3 = AURAs(SpellInfo.ApplyAuraIndex)
                        auraTarget.ActiveSpells(i).Aura3_Info = SpellInfo
                        Exit For
                    Else
                        spellCasted = SLOT_NOT_FOUND
                    End If
                End If
            Next


            'DONE: Not found same active aura on that player, create new
            If spellCasted = SLOT_NOT_FOUND Then auraTarget.AddAura(SpellID, SPELLs(SpellID).GetDuration, Caster)
            If spellCasted = SLOT_CREATE_NEW Then spellCasted = SLOT_NO_SPACE
            If spellCasted < 0 Then spellCasted -= 1

        Loop While spellCasted < 0


        'DONE: No more space for auras
        If spellCasted = SLOT_NO_SPACE Then Return SpellFailedReason.CAST_FAIL_TRY_AGAIN

        'DONE: Cast the aura
        AURAs(SpellInfo.ApplyAuraIndex).Invoke(auraTarget, Caster, SpellInfo, SpellID, AuraAction.AURA_ADD)

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_APPLY_AURA(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        If Target.unitTarget Is Nothing Then Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS

        Dim result As SpellFailedReason = SpellFailedReason.CAST_NO_ERROR
        Dim auraTarget As BaseUnit = Target.unitTarget
        Dim auraTargets As New ArrayList

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELF
                'DONE: Spell cast to target, but aura to caster (Mind Vision)
                auraTarget = Caster
            Case SpellImplicitTargets.TARGET_DUEL_VS_PLAYER
                CType(Caster, CharacterObject).DuelArbiter = Target.unitTarget.GUID
            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                auraTargets = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
            Case SpellImplicitTargets.TARGET_AROUND_CASTER_PARTY
                auraTargets = GetPartyMembersAroundMe(Caster, SpellInfo.GetRadius)
        End Select

        If auraTargets.Count = 0 Then
            result = ApplyAura(auraTarget, Caster, SpellInfo, SpellID)
            Infected.Add(Target.unitTarget.GUID)
        Else
            For Each GUID As Long In auraTargets
                If GuidIsCreature(GUID) Then
                    ApplyAura(WORLD_CREATUREs(GUID), Caster, SpellInfo, SpellID)
                ElseIf GuidIsPlayer(GUID) Then
                    ApplyAura(CHARACTERS(GUID), Caster, SpellInfo, SpellID)
                End If
                Infected.Add(GUID)
            Next
        End If

        Return result
    End Function


    Public Function SPELL_EFFECT_CREATE_ITEM(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELECTED_PLAYER
                Dim tmpItem As New ItemObject(SpellInfo.ItemType, Target.unitTarget.GUID)
                If Not CType(Target.unitTarget, CharacterObject).ItemADD(tmpItem) Then
                    tmpItem.Delete()
                    'TODO: Send inventory full
                    Return SpellFailedReason.CAST_FAIL_TRY_AGAIN
                End If
                Infected.Add(Target.unitTarget.GUID)

            Case SpellImplicitTargets.TARGET_SELECTED_FRIEND, SpellImplicitTargets.TARGET_DUEL_VS_PLAYER
                Dim tmpItem As New ItemObject(SpellInfo.ItemType, Target.unitTarget.GUID)
                If Not CType(Target.unitTarget, CharacterObject).ItemADD(tmpItem) Then
                    tmpItem.Delete()
                End If
                Infected.Add(Target.unitTarget.GUID)

            Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_SELECTED_ENEMY
                Dim tmpItem As New ItemObject(SpellInfo.ItemType, Caster.GUID)
                If Not CType(Caster, CharacterObject).ItemADD(tmpItem) Then
                    tmpItem.Delete()
                    'TODO: Send inventory full
                    Return SpellFailedReason.CAST_FAIL_TRY_AGAIN
                End If
                Infected.Add(Caster.GUID)

            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetFriendPlayersAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    Infected.Add(unit.GUID)
                    Dim tmpItem As New ItemObject(SpellInfo.ItemType, unit.GUID)
                    If Not CType(unit, CharacterObject).ItemADD(tmpItem) Then
                        tmpItem.Delete()
                    End If
                Next

            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_RESURRECT(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_NOTHING
                Target.unitTarget.Life.Current = Target.unitTarget.Life.Maximum * SpellInfo.valueBase \ 100
                If TypeOf Target.unitTarget Is CharacterObject Then CharacterResurrect(CType(Target.unitTarget, CharacterObject))
                Infected.Add(Target.unitTarget.GUID)
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_TELEPORT_GRAVEYARD(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_NOTHING
                If TypeOf Target.unitTarget Is CharacterObject Then
                    GoToNearestGraveyard(CType(Target.unitTarget, CharacterObject))
                    Infected.Add(Target.unitTarget.GUID)
                End If
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function


    Public Function SPELL_EFFECT_STEALTH(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        SetFlag(Target.unitTarget.cBytes1, 25, True)
        Target.unitTarget.Invisibility = InvisibilityLevel.INIVISIBILITY
        Target.unitTarget.Invisibility_Value = SpellInfo.GetValue(Caster.Level)

        Infected.Add(Target.unitTarget.GUID)

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_DETECT(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason
        Target.unitTarget.CanSeeInvisibility = InvisibilityLevel.INIVISIBILITY
        Target.unitTarget.CanSeeInvisibility_Stealth = SpellInfo.GetValue(Caster.Level)

        Infected.Add(Target.unitTarget.GUID)

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_DUEL(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_DUEL_VS_PLAYER
                If Not TypeOf Target.unitTarget Is CharacterObject Then Return SpellFailedReason.CAST_FAIL_TARGET_NOT_PLAYER
                If Not TypeOf Caster Is CharacterObject Then Exit Function

                'TODO: Some more checks
                If CType(Caster, CharacterObject).DuelArbiter <> 0 Then Return SpellFailedReason.CAST_FAIL_SPELL_IN_PROGRESS
                If CType(Target.unitTarget, CharacterObject).IsInDuel Then Return SpellFailedReason.CAST_FAIL_TARGET_DUELING
                If Caster.Invisibility <> InvisibilityLevel.VISIBLE Then Return SpellFailedReason.CAST_FAIL_CANT_DUEL_WHILE_INVISIBLE
                'CAST_FAIL_CANT_START_DUEL_INVISIBLE
                'CAST_FAIL_CANT_START_DUEL_STEALTHED
                'CAST_FAIL_NO_DUELING_HERE


                'DONE: Get middle coordinate
                Dim flagX As Single = Caster.positionX + (Target.unitTarget.positionX - Caster.positionX) / 2
                Dim flagY As Single = Caster.positionY + (Target.unitTarget.positionY - Caster.positionY) / 2

                'DONE: Spawn duel flag (GO Entry in SpellInfo.MiscValue) in middle of the 2 players
                Dim tmpGO As GameObjectObject = Spawner.SpawnGameObject(SpellInfo.MiscValue, flagX, flagY, Caster.positionZ, 0)

                'DONE: Set duel arbiter and parner
                'CType(Caster, CharacterObject).DuelArbiter = tmpGO.GUID        Commented to fix 2 packets for duel accept
                CType(Target.unitTarget, CharacterObject).DuelArbiter = tmpGO.GUID
                CType(Caster, CharacterObject).DuelPartner = CType(Target.unitTarget, CharacterObject)
                CType(Target.unitTarget, CharacterObject).DuelPartner = CType(Caster, CharacterObject)

                'DONE: Send duel request packet
                Dim packet As New PacketClass(OPCODES.SMSG_DUEL_REQUESTED)
                packet.AddInt64(tmpGO.GUID)
                packet.AddInt64(Caster.GUID)
                CType(Target.unitTarget, CharacterObject).Client.SendMultiplyPackets(packet)
                CType(Caster, CharacterObject).Client.SendMultiplyPackets(packet)
                packet.Dispose()

                Infected.Add(Target.unitTarget.GUID)
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function
    Public Function SPELL_EFFECT_QUEST_COMPLETE(ByRef Target As SpellTargets, ByRef Caster As BaseUnit, ByRef SpellInfo As SpellEffect, ByVal SpellID As Integer, ByRef Infected As ArrayList) As SpellFailedReason

        Select Case SpellInfo.implicitTargetA
            Case SpellImplicitTargets.TARGET_SELF, SpellImplicitTargets.TARGET_SELECTED_FRIEND, SpellImplicitTargets.TARGET_SELECTED_ENEMY
                CompleteQuest(CType(Target.unitTarget, CharacterObject), SpellInfo.MiscValue, Caster.GUID)
                Infected.Add(Target.unitTarget.GUID)
            Case SpellImplicitTargets.TARGET_SELECTED_GAMEOBJECT
                CompleteQuest(CType(Caster, CharacterObject), SpellInfo.MiscValue, Target.unitTarget.GUID)
                Infected.Add(Caster.GUID)
            Case SpellImplicitTargets.TARGET_AROUND_CASTER_ENEMY
                Dim Targets As ArrayList = GetEnemyAroundMe(Caster, SpellInfo.GetRadius)
                For Each unit As BaseUnit In Targets
                    If TypeOf unit Is CharacterObject Then
                        CompleteQuest(CType(unit, CharacterObject), SpellInfo.MiscValue, Caster.GUID)
                        Infected.Add(unit.GUID)
                    End If
                Next
            Case Else
                Return SpellFailedReason.CAST_FAIL_BAD_IMPLICIT_TARGETS
        End Select

        Return SpellFailedReason.CAST_NO_ERROR
    End Function








    Public Function GetEnemyAroundMe(ByRef c As BaseUnit, ByVal Distance As Integer) As ArrayList
        Dim result As New ArrayList
        Dim index As Integer = 0

        If TypeOf c Is CharacterObject Then
            While index < CType(c, CharacterObject).playersNear.Count
                If CType(c, CharacterObject).Side <> CType(c, CharacterObject).Side Then
                    If GetDistance(c, CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long)))
                End If
                index += 1
            End While

            index = 0
            While index < CType(c, CharacterObject).creaturesNear.Count
                'If CType(c, CharacterObject).GetReputation(CType(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)), CreatureObject).Faction) <= ReputationRank.Neutral Then
                If ReactionTable(CType(c, CharacterObject).Faction, CType(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)), CreatureObject).CreatureInfo.Faction) <= TReaction.NEUTRAL Then
                    If GetDistance(c, WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long))) < Distance Then result.Add(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)))
                End If
                index += 1
            End While

        ElseIf TypeOf c Is CreatureObject Then
            While index < c.SeenBy.Count
                If GetDistance(c, CHARACTERS(CType(c.SeenBy.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(c.SeenBy.Item(index), Long)))
                index += 1
            End While
        End If

        Return result
    End Function
    Public Function GetFriendAroundMe(ByRef c As BaseUnit, ByVal Distance As Integer) As ArrayList
        Dim result As New ArrayList
        Dim index As Integer = 0

        If TypeOf c Is CharacterObject Then
            While index < CType(c, CharacterObject).playersNear.Count
                If CType(c, CharacterObject).Side = CType(c, CharacterObject).Side Then
                    If GetDistance(c, CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long)))
                End If
                index += 1
            End While

            index = 0
            While index < CType(c, CharacterObject).creaturesNear.Count
                'If CType(c, CharacterObject).GetReputation(CType(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)), CreatureObject).CreatureInfo.Faction) <= ReputationRank.Neutral Then
                If ReactionTable(CType(c, CharacterObject).Faction, CType(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)), CreatureObject).CreatureInfo.Faction) > TReaction.NEUTRAL Then
                    If GetDistance(c, WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long))) < Distance Then result.Add(WORLD_CREATUREs(CType(CType(c, CharacterObject).creaturesNear.Item(index), Long)))
                End If
                index += 1
            End While

        ElseIf TypeOf c Is CreatureObject Then
            While index < c.SeenBy.Count
                If GetDistance(c, CHARACTERS(CType(c.SeenBy.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(c.SeenBy.Item(index), Long)))
                index += 1
            End While
        End If

        Return result
    End Function
    Public Function GetFriendPlayersAroundMe(ByRef c As BaseUnit, ByVal Distance As Integer) As ArrayList
        Dim result As New ArrayList
        Dim index As Integer = 0

        If TypeOf c Is CharacterObject Then
            While index < CType(c, CharacterObject).playersNear.Count
                If CType(c, CharacterObject).Side = CType(c, CharacterObject).Side Then
                    If GetDistance(c, CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(CType(c, CharacterObject).playersNear.Item(index), Long)))
                End If
                index += 1
            End While

        ElseIf TypeOf c Is CreatureObject Then
            While index < c.SeenBy.Count
                If GetDistance(c, CHARACTERS(CType(c.SeenBy.Item(index), Long))) < Distance Then result.Add(CHARACTERS(CType(c.SeenBy.Item(index), Long)))
                index += 1
            End While
        End If

        Return result
    End Function
    Public Function GetPartyMembersAroundMe(ByRef c As CharacterObject, ByVal Distance As Integer) As ArrayList
        Dim result As New ArrayList
        Dim index As Integer = 0

        If Not c.IsInGroup Then Return result


        While index < c.Party.GroupMembers.Length
            If Not c.Party.GroupMembers(index) Is Nothing Then

                If c.playersNear.Contains(c.Party.GroupMembers(index).GUID) Then
                    If GetDistance(c, c.Party.GroupMembers(index)) < Distance Then result.Add(c.Party.GroupMembers(index))
                End If

            End If

            index += 1
        End While


        Return result
    End Function

    Public Function GetEnemyInFrontOfMe(ByRef c As BaseUnit, ByVal Distance As Integer) As ArrayList
        Dim result As New ArrayList

        Return result
    End Function

#End Region
#Region "WS.Spells.SpellAuraEffects"


    Public Enum AuraAction As Byte
        AURA_ADD
        AURA_UPDATE
        AURA_REMOVE
    End Enum

    Delegate Sub ApplyAuraHandler(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
    Public Const AURAs_COUNT As Integer = 220
    Public AURAs(AURAs_COUNT) As ApplyAuraHandler

    Public Sub SPELL_AURA_NONE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

    End Sub
    Public Sub SPELL_AURA_BIND_SIGHT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Caster Is CharacterObject Then
                    CType(Caster, CharacterObject).DuelArbiter = Target.GUID
                    CType(Caster, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_FARSIGHT, Target.GUID)
                    CType(Caster, CharacterObject).SendCharacterUpdate(True)
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Caster Is CharacterObject Then
                    CType(Caster, CharacterObject).DuelArbiter = 0
                    CType(Caster, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_FARSIGHT, CType(0, Long))
                    CType(Caster, CharacterObject).SendCharacterUpdate(True)
                End If
        End Select

    End Sub
    Public Sub SPELL_AURA_FAR_SIGHT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_FARSIGHT, EffectInfo.MiscValue)
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_FARSIGHT, 0)
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If
        End Select

    End Sub
    Public Sub SPELL_AURA_TRACK_CREATURES(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_TRACK_CREATURES, 1 << (EffectInfo.MiscValue - 1))
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_TRACK_CREATURES, 0)
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If
        End Select

    End Sub
    Public Sub SPELL_AURA_TRACK_RESOURCES(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_TRACK_RESOURCES, 1 << (EffectInfo.MiscValue - 1))
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetUpdateFlag(EPlayerFields.PLAYER_TRACK_RESOURCES, 0)
                    CType(Target, CharacterObject).SendCharacterUpdate(True)
                End If
        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_SCALE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return
            Case AuraAction.AURA_ADD
                Target.Size *= (EffectInfo.GetValue(Caster.Level) / 100)
            Case AuraAction.AURA_REMOVE
                Target.Size /= (EffectInfo.GetValue(Caster.Level) / 100)
        End Select

        'DONE: Send update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EObjectFields.OBJECT_FIELD_SCALE_X, Target.Size)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EObjectFields.OBJECT_END)
            tmpUpdate.SetUpdateFlag(EObjectFields.OBJECT_FIELD_SCALE_X, Target.Size)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_SKILL(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CharacterObject AndAlso CType(Target, CharacterObject).Skills.ContainsKey(EffectInfo.MiscValue) Then
                    With CType(Target, CharacterObject)
                        .Skills(EffectInfo).Bonus += EffectInfo.GetValue(Caster.Level)
                        .SetUpdateFlag(EPlayerFields.PLAYER_SKILL_INFO_START + .SkillsPositions(EffectInfo.MiscValue) * 3 + 2, CType(.Skills(EffectInfo.MiscValue), TSkill).Bonus)                      'skill1.Bonus
                        .SendCharacterUpdate(True)
                    End With
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject AndAlso CType(Target, CharacterObject).Skills.ContainsKey(EffectInfo.MiscValue) Then
                    With CType(Target, CharacterObject)
                        .Skills(EffectInfo).Bonus -= EffectInfo.GetValue(Caster.Level)
                        .SetUpdateFlag(EPlayerFields.PLAYER_SKILL_INFO_START + .SkillsPositions(EffectInfo.MiscValue) * 3 + 2, CType(.Skills(EffectInfo.MiscValue), TSkill).Bonus)                      'skill1.Bonus
                        .SendCharacterUpdate(True)
                    End With
                End If

        End Select
    End Sub

    Public Sub SPELL_AURA_PERIODIC_DAMAGE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = EffectInfo.GetValue(Caster.Level)
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                Target.DealDamage(Damage, Caster)
        End Select

    End Sub
    Public Sub SPELL_AURA_PERIODIC_HEAL(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = EffectInfo.GetValue(Caster.Level)
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                Target.Heal(Damage, Caster)
        End Select

    End Sub
    Public Sub SPELL_AURA_PERIODIC_ENERGIZE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = EffectInfo.GetValue(Caster.Level)
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                Target.Energize(Damage, Caster)
        End Select

    End Sub
    Public Sub SPELL_AURA_PERIODIC_TRIGGER_SPELL(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
            Case AuraAction.AURA_UPDATE
                Dim Targets As New SpellTargets
                Targets.SetTarget_UNIT(Target)
                CType(SPELLs(EffectInfo.TriggerSpell), SpellInfo).Cast(Caster, Targets)
        End Select

    End Sub
    Public Sub SPELL_AURA_PERIODIC_HEAL_PERCENT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = Target.Life.Maximum * EffectInfo.GetValue(Caster.Level) / 100
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                Target.Heal(Damage, Caster)

            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
        End Select

    End Sub
    Public Sub SPELL_AURA_PERIODIC_ENERGIZE_PERCENT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = Target.Mana.Maximum * EffectInfo.GetValue(Caster.Level) / 100
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                Target.Energize(Damage, Caster)

            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_REGEN(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = EffectInfo.GetValue(Caster.Level)
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                SendPlaySpellVisual(Caster, SpellID)
                Target.Heal(Damage, Caster)

            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_POWER_REGEN(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Dim Damage As Integer = EffectInfo.GetValue(Caster.Level)
                SendPeriodicAuraLog(Caster, Target, SpellID, Damage, EffectInfo.ApplyAuraIndex)
                SendPlaySpellVisual(Caster, SpellID)
                Target.Energize(Damage, Caster)

            Case AuraAction.AURA_ADD
                Return
            Case AuraAction.AURA_REMOVE
                Return
        End Select

    End Sub

    Public Sub SPELL_AURA_TRANSFORM(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                If Not CREATURESDatabase.Contains(EffectInfo.MiscValue) Then
                    Dim creature As New CreatureInfo(EffectInfo.MiscValue)
                End If
                Target.Model = CType(CREATURESDatabase(EffectInfo.MiscValue), CreatureInfo).Model

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject Then
                    Target.Model = GetRaceModel(CType(Target, CharacterObject).Race, CType(Target, CharacterObject).Gender)
                Else
                    Target.Model = CType(Target, CreatureObject).CreatureInfo.Model
                End If

            Case AuraAction.AURA_UPDATE
                Return
        End Select

        'DONE: Model update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, Target.Model)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, Target.Model)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub


    Public Sub SPELL_AURA_GHOST(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.Invisibility = InvisibilityLevel.DEAD
                Target.CanSeeInvisibility = InvisibilityLevel.DEAD
                UpdateCell(Target)

            Case AuraAction.AURA_REMOVE
                Target.Invisibility = InvisibilityLevel.VISIBLE
                Target.CanSeeInvisibility = InvisibilityLevel.INIVISIBILITY
                UpdateCell(Target)

        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_INVISIBILITY(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                SetFlag(Target.cBytes1, 25, True)
                Target.Invisibility = InvisibilityLevel.INIVISIBILITY
                Target.Invisibility_Value += EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                SetFlag(Target.cBytes1, 25, False)
                Target.Invisibility = InvisibilityLevel.VISIBLE
                Target.Invisibility_Value -= EffectInfo.GetValue(Caster.Level)

        End Select

        'DONE: Send update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, Target.cBytes1)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
            UpdateCell(CType(Target, CharacterObject))
        Else
            'TODO: Still not done for creatures (we can't get their stand state!
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_STEALTH(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                SetFlag(Target.cBytes1, 25, True)
                Target.Invisibility = InvisibilityLevel.STEALTH
                Target.Invisibility_Value += EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                SetFlag(Target.cBytes1, 25, False)
                Target.Invisibility = InvisibilityLevel.VISIBLE
                Target.Invisibility_Value -= EffectInfo.GetValue(Caster.Level)

        End Select

        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, Target.cBytes1)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
            UpdateCell(CType(Target, CharacterObject))
        Else
            'TODO: Still not done for creatures (we can't get their stand state!
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_INVISIBILITY_DETECTION(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.CanSeeInvisibility_Invisibility += EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                Target.CanSeeInvisibility_Invisibility -= EffectInfo.GetValue(Caster.Level)

        End Select

        If TypeOf Target Is CharacterObject Then
            UpdateCell(CType(Target, CharacterObject))
        End If
    End Sub
    Public Sub SPELL_AURA_MOD_DETECT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.CanSeeInvisibility_Stealth += EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                Target.CanSeeInvisibility_Stealth -= EffectInfo.GetValue(Caster.Level)

        End Select

        If TypeOf Target Is CharacterObject Then
            UpdateCell(CType(Target, CharacterObject))
        End If
    End Sub
    Public Sub SPELL_AURA_MOD_SHAPESHIFT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                Target.ShapeshiftForm = EffectInfo.MiscValue
                Target.ManaType = GetShapeshiftManaType(EffectInfo.MiscValue, Target.ManaType)
                If TypeOf Target Is CharacterObject Then
                    Target.Model = GetShapeshiftModel(EffectInfo.MiscValue, CType(Target, CharacterObject).Race, Target.Model)
                Else
                    Target.Model = GetShapeshiftModel(EffectInfo.MiscValue, 0, Target.Model)
                End If

            Case AuraAction.AURA_REMOVE
                Target.ShapeshiftForm = ShapeshiftForm.FORM_NORMAL
                If TypeOf Target Is CharacterObject Then
                    Target.ManaType = GetClassManaType(CType(Target, CharacterObject).Classe)
                    Target.Model = GetRaceModel(CType(Target, CharacterObject).Race, CType(Target, CharacterObject).Gender)
                Else
                    Target.ManaType = CType(Target, CreatureObject).CreatureInfo.ManaType
                    Target.Model = CType(Target, CreatureObject).CreatureInfo.Model
                End If

            Case AuraAction.AURA_UPDATE
                Return
        End Select

        'DONE: Send update
        If TypeOf Target Is CharacterObject Then
            With CType(Target, CharacterObject)
                .SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, .cBytes1)
                .SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, .Model)
                .SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_0, CType(CType(.Race, Integer) + (CType(.Classe, Integer) << 8) + (CType(.Gender, Integer) << 16) + (CType(.ManaType, Integer) << 24), Integer))
                .SendCharacterUpdate(True)
            End With
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_BYTES_1, Target.cBytes1)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_DISPLAYID, Target.Model)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub


    Public Sub SPELL_AURA_MOD_INCREASE_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_DECREASE_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        'NOTE: Some values of EffectInfo.GetValue are in old format, new format uses (-) values

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                If EffectInfo.GetValue(Caster.Level) < 0 Then
                    newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                Else
                    newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100)
                End If

                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                If EffectInfo.GetValue(Caster.Level) < 0 Then
                    newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                Else
                    newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100)
                End If
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED_ALWAYS(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).RunSpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.RUN, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_SWIM_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).SwimSpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, newSpeed)

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).SwimSpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.SWIM, newSpeed)

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_FLY_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyTakeOff()

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyLand()

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_MOUNTED_FLY_SPEED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyTakeOff()

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyLand()

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_MOUNTED_FLY_SPEED_ALWAYS(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_ADD
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed *= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyTakeOff()

            Case AuraAction.AURA_REMOVE
                Dim newSpeed As Single = CType(Target, CharacterObject).FlySpeed
                newSpeed /= (EffectInfo.GetValue(Caster.Level) / 100) + 1
                CType(Target, CharacterObject).ChangeSpeedForced(WS_CharManagment.CharacterObject.ChangeSpeedType.FLY, newSpeed)
                CType(Target, CharacterObject).SetFlyLand()

            Case AuraAction.AURA_UPDATE
                Return
        End Select
    End Sub


    Public Sub SPELL_AURA_MOUNTED(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                If Not CREATURESDatabase.ContainsKey(EffectInfo.MiscValue) Then
                    Dim creature As New CreatureInfo(EffectInfo.MiscValue)
                End If
                If CREATURESDatabase.ContainsKey(EffectInfo.MiscValue) Then
                    Target.Mount = CType(CREATURESDatabase(EffectInfo.MiscValue), CreatureInfo).Model
                Else
                    Target.Mount = 16314        'Nether Drake
                End If


            Case AuraAction.AURA_REMOVE
                Target.Mount = 0

            Case AuraAction.AURA_UPDATE
                Return
        End Select

        'DONE: Model update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, Target.Mount)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_MOUNTDISPLAYID, Target.Mount)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub

    Public Sub SPELL_AURA_MOD_ROOT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                SetFlag(Target.cUnitFlags, UnitFlag.UNIT_FLAG_ROOTED, True)
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetMoveRoot()
                    CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_TARGET, CType(0, Long))
                End If

            Case AuraAction.AURA_REMOVE
                SetFlag(Target.cUnitFlags, UnitFlag.UNIT_FLAG_ROOTED, False)
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetMoveUnroot()
                End If

            Case AuraAction.AURA_UPDATE
                Return
        End Select

        'DONE: Send update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Target.cUnitFlags)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Target.cUnitFlags)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_STUN(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_ADD
                SetFlag(Target.cUnitFlags, UnitFlag.UNIT_FLAG_STUNTED, True)
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetMoveRoot()
                    CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_TARGET, CType(0, Long))
                End If

            Case AuraAction.AURA_REMOVE
                SetFlag(Target.cUnitFlags, UnitFlag.UNIT_FLAG_STUNTED, False)
                If TypeOf Target Is CharacterObject Then
                    CType(Target, CharacterObject).SetMoveUnroot()
                End If

            Case AuraAction.AURA_UPDATE
                Return
        End Select

        'DONE: Send update
        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Target.cUnitFlags)
            CType(Target, CharacterObject).SendCharacterUpdate(True)
        Else
            Dim packet As New UpdatePacketClass
            Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
            tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_FLAGS, Target.cUnitFlags)
            tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
            Target.SendToNearPlayers(packet)
            tmpUpdate.Dispose()
            packet.Dispose()
        End If

    End Sub

    Public Sub SPELL_AURA_SAFE_FALL(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_FEATHER_FALL)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

            Case AuraAction.AURA_REMOVE
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_NORMAL_FALL)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

        End Select

    End Sub
    Public Sub SPELL_AURA_FEATHER_FALL(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_FEATHER_FALL)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

            Case AuraAction.AURA_REMOVE
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_NORMAL_FALL)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

        End Select

    End Sub
    Public Sub SPELL_AURA_WATER_WALK(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_SET_HOVER)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

            Case AuraAction.AURA_REMOVE
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_UNSET_HOVER)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

        End Select

    End Sub
    Public Sub SPELL_AURA_HOVER(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_WATER_WALK)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

            Case AuraAction.AURA_REMOVE
                Dim packet As New PacketClass(OPCODES.SMSG_MOVE_LAND_WALK)
                packet.AddPackGUID(Target.GUID)
                Target.SendToNearPlayers(packet)
                packet.Dispose()

        End Select

    End Sub
    Public Sub SPELL_AURA_WATER_BREATHING(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                CType(Target, CharacterObject).underWaterBreathing = True

            Case AuraAction.AURA_REMOVE
                CType(Target, CharacterObject).underWaterBreathing = False

        End Select

    End Sub

    'TODO: Update values based on stats
    Public Sub SPELL_AURA_MOD_STAT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Action = AuraAction.AURA_UPDATE Then Return
        If Not TypeOf Target Is CharacterObject Then Return

        Dim value As Integer = EffectInfo.GetValue(Caster.Level)
        Dim value_sign As Integer = value
        If Action = AuraAction.AURA_REMOVE Then value = -value

        Select Case EffectInfo.MiscValue
            Case -1
                If value_sign > 0 Then
                    CType(Target, CharacterObject).Strength.PositiveBonus += value
                    CType(Target, CharacterObject).Agility.PositiveBonus += value
                    CType(Target, CharacterObject).Stamina.PositiveBonus += value
                    CType(Target, CharacterObject).Spirit.PositiveBonus += value
                    CType(Target, CharacterObject).Intellect.PositiveBonus += value
                Else
                    CType(Target, CharacterObject).Strength.PositiveBonus -= value
                    CType(Target, CharacterObject).Agility.PositiveBonus -= value
                    CType(Target, CharacterObject).Stamina.PositiveBonus -= value
                    CType(Target, CharacterObject).Spirit.PositiveBonus -= value
                    CType(Target, CharacterObject).Intellect.PositiveBonus -= value
                End If
            Case 0
                If value_sign > 0 Then CType(Target, CharacterObject).Strength.PositiveBonus += value Else CType(Target, CharacterObject).Strength.NegativeBonus -= value
            Case 1
                If value_sign > 0 Then CType(Target, CharacterObject).Agility.PositiveBonus += value Else CType(Target, CharacterObject).Agility.NegativeBonus -= value
            Case 2
                If value_sign > 0 Then CType(Target, CharacterObject).Stamina.PositiveBonus += value Else CType(Target, CharacterObject).Stamina.NegativeBonus -= value
            Case 3
                If value_sign > 0 Then CType(Target, CharacterObject).Spirit.PositiveBonus += value Else CType(Target, CharacterObject).Spirit.NegativeBonus -= value
            Case 4
                If value_sign > 0 Then CType(Target, CharacterObject).Intellect.PositiveBonus += value Else CType(Target, CharacterObject).Intellect.NegativeBonus -= value
        End Select

        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_STRENGTH, CType(CType(Target, CharacterObject).Strength.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_AGILITY, CType(CType(Target, CharacterObject).Agility.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_STAMINA, CType(CType(Target, CharacterObject).Stamina.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_SPIRIT, CType(CType(Target, CharacterObject).Spirit.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_INTELLECT, CType(CType(Target, CharacterObject).Intellect.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT0, CType(CType(Target, CharacterObject).Strength.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT1, CType(CType(Target, CharacterObject).Agility.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT2, CType(CType(Target, CharacterObject).Stamina.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT3, CType(CType(Target, CharacterObject).Intellect.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT4, CType(CType(Target, CharacterObject).Spirit.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT0, CType(CType(Target, CharacterObject).Strength.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT1, CType(CType(Target, CharacterObject).Agility.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT2, CType(CType(Target, CharacterObject).Stamina.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT3, CType(CType(Target, CharacterObject).Intellect.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT4, CType(CType(Target, CharacterObject).Spirit.NegativeBonus, Integer))

    End Sub
    Public Sub SPELL_AURA_MOD_STAT_PERCENT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Action = AuraAction.AURA_UPDATE Then Return
        If Not TypeOf Target Is CharacterObject Then Return

        Dim value As Integer = (EffectInfo.GetValue(Caster.Level) / 100 + 1)
        Dim value_sign As Integer = EffectInfo.GetValue(Caster.Level)
        If Action = AuraAction.AURA_REMOVE Then value = -value

        Select Case EffectInfo.MiscValue
            Case -1
                If value_sign > 0 Then
                    CType(Target, CharacterObject).Strength.PositiveBonus += CType(Target, CharacterObject).Strength.Value * value
                    CType(Target, CharacterObject).Agility.PositiveBonus += CType(Target, CharacterObject).Agility.Value * value
                    CType(Target, CharacterObject).Stamina.PositiveBonus += CType(Target, CharacterObject).Stamina.Value * value
                    CType(Target, CharacterObject).Spirit.PositiveBonus += CType(Target, CharacterObject).Spirit.Value * value
                    CType(Target, CharacterObject).Intellect.PositiveBonus += CType(Target, CharacterObject).Intellect.Value * value
                Else
                    CType(Target, CharacterObject).Strength.PositiveBonus -= CType(Target, CharacterObject).Strength.Value * value
                    CType(Target, CharacterObject).Agility.PositiveBonus -= CType(Target, CharacterObject).Agility.Value * value
                    CType(Target, CharacterObject).Stamina.PositiveBonus -= CType(Target, CharacterObject).Stamina.Value * value
                    CType(Target, CharacterObject).Spirit.PositiveBonus -= CType(Target, CharacterObject).Spirit.Value * value
                    CType(Target, CharacterObject).Intellect.PositiveBonus -= CType(Target, CharacterObject).Intellect.Value * value
                End If
            Case 0
                If value_sign > 0 Then CType(Target, CharacterObject).Strength.PositiveBonus += CType(Target, CharacterObject).Strength.Value * value Else CType(Target, CharacterObject).Strength.NegativeBonus -= CType(Target, CharacterObject).Strength.Value * value
            Case 1
                If value_sign > 0 Then CType(Target, CharacterObject).Agility.PositiveBonus += CType(Target, CharacterObject).Agility.Value * value Else CType(Target, CharacterObject).Agility.NegativeBonus -= CType(Target, CharacterObject).Agility.Value * value
            Case 2
                If value_sign > 0 Then CType(Target, CharacterObject).Stamina.PositiveBonus += CType(Target, CharacterObject).Stamina.Value * value Else CType(Target, CharacterObject).Stamina.NegativeBonus -= CType(Target, CharacterObject).Stamina.Value * value
            Case 3
                If value_sign > 0 Then CType(Target, CharacterObject).Spirit.PositiveBonus += CType(Target, CharacterObject).Spirit.Value * value Else CType(Target, CharacterObject).Spirit.NegativeBonus -= CType(Target, CharacterObject).Spirit.Value * value
            Case 4
                If value_sign > 0 Then CType(Target, CharacterObject).Intellect.PositiveBonus += CType(Target, CharacterObject).Intellect.Value * value Else CType(Target, CharacterObject).Intellect.NegativeBonus -= CType(Target, CharacterObject).Intellect.Value * value
        End Select

        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_STRENGTH, CType(CType(Target, CharacterObject).Strength.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_AGILITY, CType(CType(Target, CharacterObject).Agility.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_STAMINA, CType(CType(Target, CharacterObject).Stamina.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_SPIRIT, CType(CType(Target, CharacterObject).Spirit.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_INTELLECT, CType(CType(Target, CharacterObject).Intellect.Base, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT0, CType(CType(Target, CharacterObject).Strength.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT1, CType(CType(Target, CharacterObject).Agility.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT2, CType(CType(Target, CharacterObject).Stamina.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT3, CType(CType(Target, CharacterObject).Intellect.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_POSSTAT4, CType(CType(Target, CharacterObject).Spirit.PositiveBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT0, CType(CType(Target, CharacterObject).Strength.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT1, CType(CType(Target, CharacterObject).Agility.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT2, CType(CType(Target, CharacterObject).Stamina.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT3, CType(CType(Target, CharacterObject).Intellect.NegativeBonus, Integer))
        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_NEGSTAT4, CType(CType(Target, CharacterObject).Spirit.NegativeBonus, Integer))

    End Sub

    Public Sub SPELL_AURA_MOD_INCREASE_HEALTH(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.Life.Bonus += EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                Target.Life.Bonus -= EffectInfo.GetValue(Caster.Level)

        End Select

        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXHEALTH, CType(Target.Life.Maximum, Integer))
        Else
            Dim packet As New UpdatePacketClass
            Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXHEALTH, CType(Target.Life.Maximum, Integer))
            UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject), 0)

            CType(Target, CreatureObject).SendToNearPlayers(packet)
            packet.Dispose()
            UpdateData.Dispose()
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_INCREASE_ENERGY(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If EffectInfo.MiscValue = Target.ManaType Then
                    If Not TypeOf Target Is CharacterObject Then
                        Target.Mana.Bonus += EffectInfo.GetValue(Caster.Level)
                    Else
                        Select Case Target.ManaType
                            Case WS_CharManagment.ManaTypes.TYPE_ENERGY
                                CType(Target, CharacterObject).Energy.Bonus += EffectInfo.GetValue(Caster.Level)
                            Case WS_CharManagment.ManaTypes.TYPE_MANA
                                CType(Target, CharacterObject).Mana.Bonus += EffectInfo.GetValue(Caster.Level)
                            Case WS_CharManagment.ManaTypes.TYPE_RAGE
                                CType(Target, CharacterObject).Rage.Bonus += EffectInfo.GetValue(Caster.Level)
                        End Select
                    End If
                End If

            Case AuraAction.AURA_REMOVE
                If EffectInfo.MiscValue = Target.ManaType Then
                    If Not TypeOf Target Is CharacterObject Then
                        Target.Mana.Bonus -= EffectInfo.GetValue(Caster.Level)
                    Else
                        Select Case Target.ManaType
                            Case WS_CharManagment.ManaTypes.TYPE_ENERGY
                                CType(Target, CharacterObject).Energy.Bonus -= EffectInfo.GetValue(Caster.Level)
                            Case WS_CharManagment.ManaTypes.TYPE_MANA
                                CType(Target, CharacterObject).Mana.Bonus -= EffectInfo.GetValue(Caster.Level)
                            Case WS_CharManagment.ManaTypes.TYPE_RAGE
                                CType(Target, CharacterObject).Rage.Bonus -= EffectInfo.GetValue(Caster.Level)
                        End Select
                    End If
                End If
        End Select

        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXPOWER1 + ManaTypes.TYPE_ENERGY, CType(CType(Target, CharacterObject).Energy.Maximum, Integer))
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXPOWER1 + ManaTypes.TYPE_MANA, CType(CType(Target, CharacterObject).Mana.Maximum, Integer))
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXPOWER1 + ManaTypes.TYPE_RAGE, CType(CType(Target, CharacterObject).Rage.Maximum, Integer))
        Else
            Dim packet As New UpdatePacketClass
            Dim UpdateData As New UpdateClass(EUnitFields.UNIT_END)
            UpdateData.SetUpdateFlag(EUnitFields.UNIT_FIELD_MAXPOWER1 + Target.ManaType, CType(Target.Mana.Maximum, Integer))
            UpdateData.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject), 0)

            CType(Target, CreatureObject).SendToNearPlayers(packet)
            packet.Dispose()
            UpdateData.Dispose()
        End If

    End Sub


    Public Sub SPELL_AURA_MOD_BASE_RESISTANCE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        CType(Target, CharacterObject).Resistances(i).Base += EffectInfo.GetValue(Target.Level)
                        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                    End If
                Next

            Case AuraAction.AURA_REMOVE
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        CType(Target, CharacterObject).Resistances(i).Base -= EffectInfo.GetValue(Target.Level)
                        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                    End If
                Next

        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_BASE_RESISTANCE_PCT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        CType(Target, CharacterObject).Resistances(i).Base *= EffectInfo.GetValue(Target.Level) + 1
                        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                    End If
                Next

            Case AuraAction.AURA_REMOVE
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        CType(Target, CharacterObject).Resistances(i).Base \= EffectInfo.GetValue(Target.Level) + 1
                        CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCES + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                    End If
                Next

        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_RESISTANCE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus += EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus -= EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

            Case AuraAction.AURA_REMOVE
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus -= EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus += EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_RESISTANCE_PCT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus += EffectInfo.GetValue(Target.Level) * CType(Target, CharacterObject).Resistances(i).Base / 100
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus -= EffectInfo.GetValue(Target.Level) * CType(Target, CharacterObject).Resistances(i).Base / 100
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

            Case AuraAction.AURA_REMOVE
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus -= EffectInfo.GetValue(Target.Level) * CType(Target, CharacterObject).Resistances(i).Base / 100
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus += EffectInfo.GetValue(Target.Level) * CType(Target, CharacterObject).Resistances(i).Base / 100
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus += EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus -= EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

            Case AuraAction.AURA_REMOVE
                For i As DamageType = DamageType.DMG_PHYSICAL To DamageType.DMG_ARCANE
                    If HaveFlag(EffectInfo.MiscValue, i) Then
                        If EffectInfo.GetValue(Target.Level) > 0 Then
                            CType(Target, CharacterObject).Resistances(i).PositiveBonus -= EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE + i, CType(Target, CharacterObject).Resistances(i).PositiveBonus)
                        Else
                            CType(Target, CharacterObject).Resistances(i).NegativeBonus += EffectInfo.GetValue(Target.Level)
                            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE + i, CType(Target, CharacterObject).Resistances(i).NegativeBonus)
                        End If
                    End If
                Next

        End Select
    End Sub
    Public Sub SPELL_AURA_MOD_ATTACK_POWER(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.AttackPowerMods += EffectInfo.GetValue(Caster.Level)


            Case AuraAction.AURA_REMOVE
                Target.AttackPowerMods -= EffectInfo.GetValue(Caster.Level)

        End Select


        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_ATTACK_POWER, CType(Target, CharacterObject).AttackPower)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_ATTACK_POWER_MODS, CType(Target, CharacterObject).AttackPowerMods)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER, CType(Target, CharacterObject).AttackPowerRanged)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER_MODS, CType(Target, CharacterObject).AttackPowerModsRanged)
        End If

    End Sub
    Public Sub SPELL_AURA_MOD_RANGED_ATTACK_POWER(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.AttackPowerModsRanged += EffectInfo.GetValue(Caster.Level)


            Case AuraAction.AURA_REMOVE
                Target.AttackPowerModsRanged -= EffectInfo.GetValue(Caster.Level)

        End Select


        If TypeOf Target Is CharacterObject Then
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_ATTACK_POWER, CType(Target, CharacterObject).AttackPower)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_ATTACK_POWER_MODS, CType(Target, CharacterObject).AttackPowerMods)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER, CType(Target, CharacterObject).AttackPowerRanged)
            CType(Target, CharacterObject).SetUpdateFlag(EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER_MODS, CType(Target, CharacterObject).AttackPowerModsRanged)
        End If

    End Sub

    Public Sub SPELL_AURA_EMPATHY(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CreatureObject AndAlso CType(Target, CreatureObject).CreatureInfo.CreatureType = UNIT_TYPE.BEAST Then
                    Dim packet As New UpdatePacketClass
                    Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
                    tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, Target.cDynamicFlags Or DynamicFlags.UNIT_DYNFLAG_SPECIALINFO)
                    tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
                    CType(Caster, CharacterObject).Client.Send(packet)
                    tmpUpdate.Dispose()
                    packet.Dispose()
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CreatureObject AndAlso CType(Target, CreatureObject).CreatureInfo.CreatureType = UNIT_TYPE.BEAST Then
                    Dim packet As New UpdatePacketClass
                    Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
                    tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_DYNAMIC_FLAGS, Target.cDynamicFlags)
                    tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
                    CType(Caster, CharacterObject).Client.Send(packet)
                    tmpUpdate.Dispose()
                    packet.Dispose()
                End If
        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_SILENCE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.Spell_Silenced = True

            Case AuraAction.AURA_REMOVE
                Target.Spell_Silenced = False

        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_PACIFY(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.Spell_Pacifyed = True

            Case AuraAction.AURA_REMOVE
                Target.Spell_Pacifyed = False

        End Select

    End Sub

    Public Sub SPELL_AURA_MOD_LANGUAGE(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                CType(Target, CharacterObject).Spell_Language = EffectInfo.MiscValue

            Case AuraAction.AURA_REMOVE
                CType(Target, CharacterObject).Spell_Language = -1

        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_POSSESS(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CreatureObject Then Return
        If Not TypeOf Caster Is CharacterObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If Target.Level > EffectInfo.GetValue(Caster.Level) Then Return

                Dim packet As New UpdatePacketClass
                Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
                tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_CHARMEDBY, Caster.GUID)
                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
                CType(Caster, CharacterObject).Client.Send(packet)
                packet.Dispose()
                tmpUpdate.Dispose()

                CType(Target, CreatureObject).aiScript.Reset()
                SendPetInitialize(Caster, Target.GUID)

            Case AuraAction.AURA_REMOVE
                Dim packet As New UpdatePacketClass
                Dim tmpUpdate As New UpdateClass(EUnitFields.UNIT_END)
                tmpUpdate.SetUpdateFlag(EUnitFields.UNIT_FIELD_CHARMEDBY, 0)
                tmpUpdate.AddToPacket(packet, ObjectUpdateType.UPDATETYPE_VALUES, CType(Target, CreatureObject))
                CType(Caster, CharacterObject).Client.Send(packet)
                packet.Dispose()
                tmpUpdate.Dispose()

                CType(Target, CreatureObject).aiScript.Reset()


        End Select

    End Sub



    Public Sub SPELL_AURA_MOD_THREAT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)

        'NOTE: EffectInfo.MiscValue => DamageType (not used for now, till new combat sytem)

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                Target.Spell_ThreatModifier *= EffectInfo.GetValue(Caster.Level)

            Case AuraAction.AURA_REMOVE
                Target.Spell_ThreatModifier /= EffectInfo.GetValue(Caster.Level)

        End Select

    End Sub
    Public Sub SPELL_AURA_MOD_TOTAL_THREAT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        Dim Value As Integer

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                If TypeOf Target Is CharacterObject Then
                    Value = EffectInfo.GetValue(Target.Level)
                Else
                    Value = EffectInfo.GetValue(Caster.Level)
                End If

            Case AuraAction.AURA_REMOVE
                If TypeOf Target Is CharacterObject Then
                    Value = -EffectInfo.GetValue(Target.Level)
                Else
                    Value = -EffectInfo.GetValue(Caster.Level)
                End If
        End Select


        If TypeOf Target Is CharacterObject Then
            For Each Creature As DictionaryEntry In CType(Target, CharacterObject).creaturesNear
                If Not CType(WORLD_CREATUREs(CType(Creature.Value, Long)), CreatureObject).aiScript Is Nothing AndAlso _
                CType(WORLD_CREATUREs(CType(Creature.Value, Long)), CreatureObject).aiScript.aiHateTable.ContainsKey(Target.GUID) Then
                    CType(WORLD_CREATUREs(CType(Creature.Value, Long)), CreatureObject).aiScript.OnGenerateHate(Target, Value)
                End If
            Next
        Else
            If Not CType(Target, CreatureObject).aiScript Is Nothing AndAlso _
            CType(Target, CreatureObject).aiScript.aiHateTable.ContainsKey(Caster.GUID) Then
                CType(Target, CreatureObject).aiScript.OnGenerateHate(Caster, Value)
            End If
        End If
    End Sub
    Public Sub SPELL_AURA_MOD_TAUNT(ByRef Target As BaseUnit, ByRef Caster As BaseUnit, ByRef EffectInfo As SpellEffect, ByVal SpellID As Integer, ByVal Action As AuraAction)
        If Not TypeOf Target Is CreatureObject Then Return

        Select Case Action
            Case AuraAction.AURA_UPDATE
                Return

            Case AuraAction.AURA_ADD
                CType(Target, CreatureObject).aiScript.OnGenerateHate(Caster, 9999999)

            Case AuraAction.AURA_REMOVE
                CType(Target, CreatureObject).aiScript.OnGenerateHate(Caster, -9999999)

        End Select

    End Sub




#End Region

#Region "WS.Spells.Handlers.Duel"

    Const DUEL_COUNTDOWN As Integer = 3000              'in miliseconds
    Const DUEL_OUTOFBOUNDS_DISTANCE As Single = 20

    Public Const DUEL_COUNTER_START As Byte = 10
    Public Const DUEL_COUNTER_DISABLED As Byte = 11

    Public Sub CheckDuelDistance(ByRef c As CharacterObject)
        If GetDistance(c, WORLD_GAMEOBJECTs(c.DuelArbiter)) > DUEL_OUTOFBOUNDS_DISTANCE Then
            If c.DuelOutOfBounds = DUEL_COUNTER_DISABLED Then
                'DONE: Notify for out of bounds of the duel flag and start counting
                Dim packet As New PacketClass(OPCODES.SMSG_DUEL_OUTOFBOUNDS)
                c.Client.Send(packet)
                packet.Dispose()

                c.DuelOutOfBounds = DUEL_COUNTER_START
            End If
        Else
            If c.DuelOutOfBounds <> DUEL_COUNTER_DISABLED Then
                c.DuelOutOfBounds = DUEL_COUNTER_DISABLED

                'DONE: Notify for in bounds of the duel flag
                Dim packet As New PacketClass(OPCODES.SMSG_DUEL_INBOUNDS)
                c.Client.Send(packet)
                packet.Dispose()
            End If
        End If
    End Sub
    Public Sub DuelComplete(ByRef Winner As CharacterObject, ByRef Loser As CharacterObject)
        If Winner Is Nothing Then Exit Sub
        If Loser Is Nothing Then Exit Sub

        'DONE: First stop the fight
        Dim response As New PacketClass(OPCODES.SMSG_DUEL_COMPLETE)
        response.AddInt8(1)
        Winner.Client.SendMultiplyPackets(response)
        Loser.Client.SendMultiplyPackets(response)
        response.Dispose()

        'DONE: Clear duel things
        CType(WORLD_GAMEOBJECTs(Winner.DuelArbiter), GameObjectObject).Despawn()

        Winner.DuelOutOfBounds = DUEL_COUNTER_DISABLED
        Winner.DuelArbiter = 0
        Winner.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_ARBITER, 0)
        Winner.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_TEAM, 0)

        Loser.DuelOutOfBounds = DUEL_COUNTER_DISABLED
        Loser.DuelArbiter = 0
        Loser.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_ARBITER, 0)
        Loser.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_TEAM, 0)


        'DONE: Update life
        If Loser.Life.Current = 0 Then
            Loser.Life.Current = 1
            Loser.SetUpdateFlag(EUnitFields.UNIT_FIELD_HEALTH, 1)
            Loser.SetUpdateFlag(EUnitFields.UNIT_NPC_EMOTESTATE, EmoteStates.ANIM_EMOTE_BEG)
        End If
        Loser.SendCharacterUpdate(True)
        Winner.SendCharacterUpdate(True)


        'DONE: Notify client
        Dim packet As New PacketClass(OPCODES.SMSG_DUEL_WINNER)
        packet.AddInt8(0)
        packet.AddString(Winner.Name)
        packet.AddInt8(1)
        packet.AddString(Loser.Name)
        Winner.Client.SendMultiplyPackets(packet)
        Winner.SendToNearPlayers(packet)
        packet.Dispose()



        'DONE: Final clearing (if we clear it before we can't get names)
        Dim tmpCharacter As CharacterObject
        tmpCharacter = Winner
        Loser.DuelPartner = Nothing
        tmpCharacter.DuelPartner = Nothing
        tmpCharacter = Nothing
    End Sub

    Public Sub On_CMSG_DUEL_ACCEPTED(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim guid As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_DUEL_ACCEPTED [{2:X}]", Client.IP, Client.Port, guid)

        'NOTE: Only invited player must have GUID set up
        If Client.Character.DuelArbiter <> guid Then Return

        Dim c1 As CharacterObject = Client.Character.DuelPartner
        Dim c2 As CharacterObject = Client.Character
        c1.DuelArbiter = guid
        c2.DuelArbiter = guid

        'DONE: Do updates
        c1.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_ARBITER, c1.DuelArbiter)
        c1.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_TEAM, 1)
        c2.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_ARBITER, c2.DuelArbiter)
        c2.SetUpdateFlag(EPlayerFields.PLAYER_DUEL_TEAM, 2)
        c2.SendCharacterUpdate(True)
        c1.SendCharacterUpdate(True)

        'DONE: Start the duel
        Dim response As New PacketClass(OPCODES.SMSG_DUEL_COUNTDOWN)
        response.AddInt32(DUEL_COUNTDOWN)
        c1.Client.SendMultiplyPackets(response)
        c2.Client.SendMultiplyPackets(response)
        response.Dispose()
    End Sub
    Public Sub On_CMSG_DUEL_CANCELLED(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim guid As Long = packet.GetInt64

        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_DUEL_CANCELLED [{2:X}]", Client.IP, Client.Port, guid)

        'DONE: Clear for client
        CType(WORLD_GAMEOBJECTs(Client.Character.DuelArbiter), GameObjectObject).Despawn()
        Client.Character.DuelArbiter = 0
        Client.Character.DuelPartner.DuelArbiter = 0

        Dim response As New PacketClass(OPCODES.SMSG_DUEL_COMPLETE)
        response.AddInt8(0)
        Client.Character.Client.SendMultiplyPackets(response)
        Client.Character.DuelPartner.Client.SendMultiplyPackets(response)
        response.Dispose()

        'DONE: Final clearing
        Client.Character.DuelPartner.DuelPartner = Nothing
        Client.Character.DuelPartner = Nothing
    End Sub


#End Region
#Region "WS.Spells.Handlers"


    Public Sub On_CMSG_CAST_SPELL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim spellID As Integer = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CAST_SPELL [spellID={2}]", Client.IP, Client.Port, spellID)

        If Not Client.Character.HaveSpell(spellID) Then
            Log.WriteLine(LogType.WARNING, "[{0}:{1}] CHEAT: Character {2} casting unlearned spell {3}!", Client.IP, Client.Port, Client.Character.Name, spellID)
        End If


        DumpPacket(packet.Data, Client)
        'TODO: In duel disable


        Dim Targets As New SpellTargets
        Targets.ReadTargets(packet, Client.Character)
        Dim castResult As SpellFailedReason = SpellFailedReason.CAST_FAIL_ERROR
        Try
            castResult = CType(SPELLs(spellID), SpellInfo).CanCast(Client.Character, Targets)

            'Only instant cast send ERR_OK for cast result?
            If castResult = SpellFailedReason.CAST_NO_ERROR Then
                'Removed direct invoking of .Cast becouse of blocking main socket tread with .Sleep
                'CType(SPELLs(spellID), SpellInfo).Cast(Client.Character, Targets)

                Dim tmpSpell As New CastSpellParameters
                tmpSpell.tmpTargets = Targets
                tmpSpell.tmpCaster = Client.Character
                tmpSpell.tmpSpellID = spellID
                PacketThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf tmpSpell.Cast))

            Else
                SendCastResult(castResult, Client, spellID)
            End If

        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Error casting spell {0}.{1}", spellID, vbNewLine & e.ToString)
            SendCastResult(castResult, Client, spellID)
        End Try
    End Sub
    Public Sub On_CMSG_CANCEL_CAST(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CANCEL_CAST", Client.IP, Client.Port)

        Client.Character.spellCastState = SpellCastState.SPELL_STATE_IDLE
    End Sub
    Public Sub On_CMSG_CANCEL_AUTO_REPEAT_SPELL(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CANCEL_AUTO_REPEAT_SPELL", Client.IP, Client.Port)

        Client.Character.spellCastState = SpellCastState.SPELL_STATE_IDLE
    End Sub

    Public Sub RemoveAuraBySpell(ByVal c As BaseUnit, ByVal SpellID As Integer)
        'DONE: Real aura removing
        For i As Integer = 0 To MAX_AURA_EFFECTs - 1
            If Not c.ActiveSpells(i) Is Nothing AndAlso _
            c.ActiveSpells(i).SpellID = SpellID Then
                c.RemoveAura(i, c.ActiveSpells(i).SpellCaster)

                'DONE: Removing additional spell auras (Mind Vision)
                If (TypeOf c Is CharacterObject) AndAlso _
                    (CType(c, CharacterObject).DuelArbiter <> 0) AndAlso (CType(c, CharacterObject).DuelPartner Is Nothing) Then
                    RemoveAuraBySpell(WORLD_CREATUREs(CType(c, CharacterObject).DuelArbiter), SpellID)
                    CType(c, CharacterObject).DuelArbiter = 0
                End If
                Exit For
            End If
        Next
    End Sub
    Public Sub On_CMSG_CANCEL_AURA(ByRef packet As PacketClass, ByRef Client As ClientClass)
        packet.GetInt16()
        Dim spellID As Integer = packet.GetInt32
        Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_CANCEL_AURA [spellID={2}]", Client.IP, Client.Port, spellID)

        RemoveAuraBySpell(Client.Character, spellID)
    End Sub

    Public Sub On_CMSG_LEARN_TALENT(ByRef packet As PacketClass, ByRef Client As ClientClass)
        Try
            packet.GetInt16()
            Dim TalentID As Integer = packet.GetInt32()
            Dim RequestedRank As Integer = packet.GetInt32()
            Dim CurrentTalentPoints As Byte = Client.Character.TalentPoints
            Dim SpellID As Integer
            Dim ReSpellID As Integer
            Dim i As Integer, j As Integer
            Dim HasEnoughRank As Boolean
            Dim DependsOn As Integer
            Dim SpentPoints As Integer

            Log.WriteLine(LogType.DEBUG, "[{0}:{1}] CMSG_LEARN_TALENT [{2}:{3}]", Client.IP, Client.Port, TalentID, RequestedRank)

            If CurrentTalentPoints = 0 Then Exit Sub
            If RequestedRank > 4 Then Exit Sub

            'DONE: Now the character can't cheat, he must have the earlier rank to get the new one
            If RequestedRank > 0 Then
                If Not Client.Character.HaveSpell(CType(Talents(TalentID), TalentInfo).RankID(RequestedRank - 1)) Then
                    Exit Sub
                End If
            End If

            'DONE: Now the character can't cheat, he must have the other talents that is needed to get this one
            For j = 0 To 2
                If CType(Talents(TalentID), TalentInfo).RequiredTalent(j) > 0 Then
                    HasEnoughRank = False
                    DependsOn = CType(Talents(TalentID), TalentInfo).RequiredTalent(j)
                    For i = CType(Talents(TalentID), TalentInfo).RequiredPoints(j) To 4
                        If CType(Talents(DependsOn), TalentInfo).RankID(i) <> 0 Then
                            If Client.Character.HaveSpell(CType(Talents(DependsOn), TalentInfo).RankID(i)) Then
                                HasEnoughRank = True
                            End If
                        End If
                    Next i

                    If HasEnoughRank = False Then Exit Sub
                End If
            Next j

            'DONE: Count spent talent points
            SpentPoints = 0
            If CType(Talents(TalentID), TalentInfo).Row > 0 Then
                For Each TalentInfo As DictionaryEntry In Talents
                    If CType(Talents(TalentID), TalentInfo).TalentTab = CType(TalentInfo.Value, TalentInfo).TalentTab Then
                        For i = 0 To 4
                            If CType(TalentInfo.Value, TalentInfo).RankID(i) <> 0 Then
                                If Client.Character.HaveSpell(CType(TalentInfo.Value, TalentInfo).RankID(i)) Then
                                    SpentPoints += i + 1
                                End If
                            End If
                        Next i
                    End If
                Next
            End If

#If DEBUG Then
            Log.WriteLine(LogType.INFORMATION, "Talents spent: {0}", SpentPoints)
#End If

            If SpentPoints < (CType(Talents(TalentID), TalentInfo).Row * 5) Then Exit Sub

            SpellID = CType(Talents(TalentID), TalentInfo).RankID(RequestedRank)

            If SpellID = 0 Then Exit Sub

            If Client.Character.HaveSpell(SpellID) Then Exit Sub

            Client.Character.LearnSpell(SpellID)

            'DONE: Unlearning the earlier rank of the talent
            If RequestedRank > 0 Then
                ReSpellID = CType(Talents(TalentID), TalentInfo).RankID(RequestedRank - 1)
                Client.Character.UnLearnSpell(ReSpellID)
                'Client.Character.RemoveAurasDueToSpell(0)   <-- RemoveAurasDueToSpell(SpellID) needs to be added
            End If

            'DONE: Remove 1 talentpoint from the character
            Client.Character.TalentPoints -= 1
            Client.Character.SetUpdateFlag(EPlayerFields.PLAYER_CHARACTER_POINTS1, CType(Client.Character.TalentPoints, Integer))
            Client.Character.SendCharacterUpdate(True)

            Client.Character.SaveCharacter()
        Catch e As Exception
            Log.WriteLine(LogType.FAILED, "Error learning talen: {0}{1}", vbNewLine, e.ToString)
        End Try
    End Sub


#End Region



End Module
