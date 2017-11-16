Attribute VB_Name = "ObjectManagement_Variables"
Option Explicit
Option Base 1

Public Type tGUID
    low As Long
    high As Long
End Type

Public Type tObject_Base
    f000_GUID As tGUID                                     '64bit unique ID for the object.
    f002_TYPE  As Long                                     'Type of object; see below.
    f003_ENTRY  As Long                                    'Unknown.
    f004_SCALE_X  As Single                                '(Float) Scale of the object (1.0f = "normal")
    f005_PADDING  As Long                                  'Null?
End Type

Public Type tObject_Item
    f006_OWNER_GUID As tGUID                               'GUID of the owner
    f008_CONTAINER_GUID As tGUID                           'GUID of the container it's located in.
    f010_CREATOR_GUID As tGUID                             'GUID of the item creator.
    f012_STACK_COUNT As Long                               'How many instances of this item are there. (Say, 4 apples in one itemslot)
    f013_DURATION As Long                                  'How long till the item wears out.
    f014_SPELL_CHARGES_5(1 To 5) As Long                   'How many charges does the item have. (Say, a wand of fireball with 10 fireballs)
    f019_FLAGS As Long                                     'Unknown
    f020_ENCHANTMENT_14(1 To 21) As Long                   'Unknown, enchantment on the item, like +2 damage?
    f041_PROPERTY_SEED As Long
    f042_RANDOM_PROPERTIES_ID As Long
    f043_PAD As Long                                       'Null
End Type

Public Type tObject_Item_Container
    f044_NUM_SLOTS As Long                                 'Number of slots in the container.
    f045_ALIGN_PAD As Long                                 'Null?
    f046_SLOTS_20(1 To 20) As tGUID                        'items in this containers slots
End Type

Public Type tObject_Unit
    f006_CHARM_GUID As tGUID                               'Unknown.
    f008_SUMMON As tGUID                                   'Unknown.
    f010_CHARMEDBY As tGUID                                'GUID of the person who Charmed this Unit.
    f012_SUMMONEDBY As tGUID                               'GUID of the person who Summoned this Unit.
    f014_CREATEDBY As tGUID                                'GUID of the person who Created this Unit.
    f016_TARGET As tGUID                                   'The current Target of the Unit. (Different from Selection; most likely only for attacking purposes)
    f018_COMBO_TARGET As tGUID                             'The current ComboTarget. 'Unknown.
    f020_CHANNEL_OBJECT As tGUID                           'Unknown.
    f022_HEALTH As Long                                    'The current HP of the Unit.
    f023_MANA As Long                                      'The current Mana of the Unit.
    f024_RAGE As Long                                      'The current Rage of the Unit.
    f025_FOCUS As Long                                     'The current Focus (?) of the Unit.
    f026_POWER4 As Long                                    'Unknown.
    f027_MAX_HEALTH As Long                                'The maximum HP of the Unit.
    f028_MAX_MANA As Long                                  'The maximum Mana of the Unit.
    f029_MAX_RAGE As Long                                  'The maximum Rage of the Unit.
    f030_MAX_FOCUS As Long                                 'The maximum Focus (?) of the Unit.
    f031_MAX_POWER4 As Long                                'Unknown.
    f032_LEVEL As Long                                     'The current Level of the Unit
    f033_FACTIONTEMPLATE As Long                           'Unknown.
    f034_CLASSINFO(1 To 4) As Byte                         '(Byte Race, byte Class, byte Gender, byte Unknown) 'see valid values below.
    f035_STAT_STRENGTH As Long                             'Strength.
    f036_STAT_AGILITY As Long                              'Agility.
    f037_STAT_STAMINA As Long                              'Stamina.
    f038_STAT_INTELLECT As Long                            'Intellect.
    f039_STAT_SPIRIT As Long                               'Spirit.
    f040_BASE_STAT_STRENGTH As Long                        'Base Strength.
    f041_BASE_STAT_AGILITY As Long                         'Base Agility.
    f042_BASE_STAT_STAMINA As Long                         'Base Stamina.
    f043_BASE_STAT_INTELLECT As Long                       'Base Intellect.
    f044_BASE_STAT_SPIRIT As Long                          'Base Spirit.
    f045_VIRTUAL_ITEM_SLOT_DISPLAY_3(1 To 3) As Long       'Unknown.
    f048_VIRTUAL_ITEM_INFO_3(1 To 3) As tGUID              'Unknown.
    f054_FLAGS As Long                                     'Unknown.
    f055_COINAGE As Long                                   'How much $$$ / Dineros / Cash / Steel / etc the Unit has.
    f056_AURA_56(1 To 56) As Long                          'Unknown (What aura(s) the char has?).
    f112_AURA_LEVELS_10(1 To 10) As Long
    f122_AURA_APPLICATIONS_10(1 To 10) As Long
    f132_AURA_FLAGS(1 To 7) As Long                        'Unknown.
    f139_AURA_STATE As Long                                'Unknown. 'originally 119
    f140_BASEATTACKTIME_2(1 To 2) As Long                  '(right & left hand weapon?) 'Unknown.
    f142_RESISTANCES(1 To 6) As Long                       '(physical, holy, fire, nature, frost & shadow) 'Resistances against the various types.
    f148_BOUNDING_RADIUS As Single                         '(Float) Unknown.
    f149_COMBAT_REACH As Single                            '(Float) (difference between this and the one below?)
    f150_WEAPON_REACH As Single                            '(Float) Range of the current weaon
    f151_DISPLAYID As Long                                 'ID for the model of the Unit
    f152_MOUNT_DISPLAYID As Long                           'ID for his mount.
    f153_DAMAGE(1 To 2) As Integer                         'Current damage: Low 16 bits = min damage, high 16 bits = max damage.
    f154_MOD_DAMAGE_DONE_6(1 To 6) As Long                 '(physical, holy, fire, nature, frost & shadow) - What damage the Unit just did (?). (Or a modifier to the persons damage of this type)
    f160_RESISTANCE_BUFF_POSITIVE_6(1 To 6) As Long        'Positive modifiers to the Units resistance via buffs (spells).
    f166_RESISTANCE_BUFF_NEGATIVE_6(1 To 6) As Long        'Negative modifiers to the Units resistance via buffs.
    f172_RESISTANCE_ITEM_MODS_6(1 To 6) As Long            'Modifiers to the Units resistance via Items.
    f178_ANIMSTATE As Long                                 '(animState: 1 'sit ground, 2 'standing/stunned, 3 'sleeping, 4 'sit bench, 5 sit small chair, 6 sit normal chair, 7 death, 8 kneel)
    f179_PET_NUMBER As Long                                'Unknown. (Perhaps a part of the GUID of the pet: I've heard they share 32 of the bits with their master?)
    f180_PET_NAME_TIMESTAMP As Long                        'Unknown.
    f181_PET_EXPERIENCE As Long                            'Current amount of experience the Pet has.
    f182_PET_NEXT_LEVEL_EXP As Long                        'Experience left to the Pets next level.
    f183_DYNAMIC_FLAGS As Long                             'Unknown. (1 'makes it glitter around the unit)
    f184_EMOTE_STATE As Long                               'State of PERMANENT emotes.
    f185_CHANNEL_SPELL As Long                             'Unknown.
    f186_MOD_CAST_SPEED As Long                            'Unknown.
    f187_CREATED_BY_SPELL As Long                          'Unknown.
    f188_NPC_FLAGS As Long                                 'Unknown.
    f189_BYTES_2 As Long                                   'Unknown.
    f190_ATTACKPOWER As Long
    f191_PADDING As Long                                   'Null?
End Type

Public Type tObject_Unit_Player
    f192_INV_SLOTS_GUID_23(1 To 23) As tGUID               'Content of the chars inventory slots.
    f238_PACK_SLOTS_GUID_16(1 To 16) As tGUID              'Content of the chars backpack slots.
    f270_BANK_SLOTS_GUID_24(1 To 24) As tGUID              'Contents of the chars bank-box.
    f318_BANKBAG_SLOTS_Unknown_12(1 To 12) As Long         'Unknown.
    f330_SELECTION_GUID As tGUID                           'What the char has currently selected.
    f332_FARSIGHT_GUID As tGUID                            'Unknown.
    f334_DUEL_ARBITER_GUID As tGUID                        'Unknown.
    f336_NUM_INV_SLOTS As Long                             'Unknown. (How many slots he has in his inv?)
    f337_GUILD_ID  As Long                                 'ID of his guild.
    f338_GUILD_RANK  As Long                               'Rank in his guild.
    f339_SKIN_FACE_HAIRSTYLE_HAIRCOLOR(1 To 4) As Byte     '(byte skin, byte face, byte hairstyle, byte haircolor)
    f340_XP As Long                                        'Current amount of XP the Char has.
    f341_NEXT_LEVEL_XP As Long                             'At what XP does the char level up.
    f342_SKILL_INFO_192(1 To 192) As Long                  'The characters skills.
    f534_FACIALHAIR(1 To 4) As Byte                        '(more?)
    f535_QUEST_LOG_80(1 To 80) As Long                     'Obviously the quests he has done, unknown. (IDs?)
    f615_TALENTPOINTS As Long                              'How many points for learning of talents does the char have remaining.
    f616_SKILLPOINTS As Long                               'How many points for learning of skills does the char have remaining.
    f617_TRACK_CREATURES As Long                           'Unknown.
    f618_TRACK_RESOURCES As Long                           'Unknown.
    f619_CHAT_FILTERS As Long                              'Unknown.
    f620_DUEL_TEAM As Long                                 'Unknown.
    f621_BLOCK_PERCENTAGE As Single                        '(Float) How many percent of incoming attacks does the char block.
    f622_DODGE_PERCENTAGE As Single                        '(Float) How many percent of incoming attacks does the char dodge. (Ranged?)
    f623_PARRY_PERCENTAGE As Single                        '(Float) How many percent of incoming attacks does the char parry.
    f624_BASE_MANA As Long                                 'Unknown.
    f625_GUILD_TIMESTAMP As Long                           'Unknown.
    f626_EXPLORED_ZONES_32(1 To 32) As Long
End Type

Public Type tObject_Game_Object
    f006_DISPLAYID As Long                                 'ID of the model of the object.
    f007_FLAGS As Long                                     'Unknown.
    f008_ROTATION_4(1 To 4) As Single                      '(Float)
    f012_STATE As Long                                     'Unknown.
    f013_TIMESTAMP As Long                                 'Unknown.
    f014_POS_X As Single                                   '(Float) Position, X value.
    f015_POS_Y As Single                                   '(Float) Position, Y value.
    f016_POS_Z As Single                                   '(Float) Position, Z value.
    f017_FACING As Single                                  '(Float) In what direction is the char facing.
    f018_DYN_FLAGS As Long                                 'Unknown.
    f019_FACTION As Long                                   'What faction is this GO on (?).
End Type

Public Type tObject_Dynamic_Object
    f006_CASTER_GUID As tGUID                              'Who cast this spell/object (?).
    f008_BYTES As Long                                     'Unknown.
    f009_SPELLID As Long                                   'ID of the spell that created this spell/object (?).
    f010_RADIUS As Single                                  'In what area does this DO affect things (?).
    f011_POS_X  As Single                                  '(Float) Position, X value.
    f012_POS_Y  As Single                                  '(Float) Position, Y value.
    f013_POS_Z As Single                                   '(Float) Position, Z value.
    f014_FACING  As Single                                 '(Float) In what direction is the char facing.
    f015_PAD As Long                                       'Null?
End Type

Public Type tObject_Corpse
    f006_OWNER As tGUID                                    'Who is this person!
    f008_FACING As Single                                  '(Float) Direction facing.
    f009_POS_X As Single                                   '(Float) Position, X value.
    f010_POS_Y As Single                                   '(Float) Position, Y value.
    f011_POS_Z As Single                                   '(Float) Position, Z value.
    f012_DISPLAYID As Long                                 'ID of the model of the object.
    f013_ITEM_19(1 To 19) As Long                          'Items on the corpse (LOOOOT).
    f032_BYTES_1 As Long                                   'Unknown.
    f033_BYTES_2 As Long                                   'Unknown.
    f034_GUILD As Long                                     'Unknown.
    f035_LEVEL As Long                                     'What level was the creep/char before it died.
End Type

Public Type tObject_Base_Complete
    Base As tObject_Base
End Type

Public Type tObject_Item_Complete
    Base As tObject_Base
    Item As tObject_Item
End Type

Public Type tObject_Item_Container_Complete
    Base As tObject_Base
    Item As tObject_Item
    Container As tObject_Item_Container
End Type

Public Type tObject_Unit_Complete
    Base As tObject_Base
    Unit As tObject_Unit
End Type

Public Type tObject_Unit_Player_Complete
    Base As tObject_Base
    Unit As tObject_Unit
    Player As tObject_Unit_Player
End Type

Public Type tObject_Game_Object_Complete
    Base As tObject_Base
    GameObject As tObject_Game_Object
End Type

Public Type tObject_Dynamic_Object_Complete
    Base As tObject_Base
    DynamicObject As tObject_Dynamic_Object
End Type

Public Type tObject_Corpse_Complete
    Base As tObject_Base
    Corpse As tObject_Corpse
End Type

Public Type tUpdateFields
    UpdateFields() As Integer
    UpdateFieldIsPrivate() As Boolean
    Count As Long
End Type

Public Type tUpdateMaskList
    Updates() As tUpdateFields
    GUIDs() As tGUID
    Count As Long
End Type

Public Type tObject_Base_Collection
    Objects() As tObject_Base_Complete
    Count As Long
End Type

Public Type tObject_Item_Collection
    Objects() As tObject_Item_Complete
    Count As Long
End Type

Public Type tObject_Item_Container_Collection
    Objects() As tObject_Item_Container_Complete
    Count As Long
End Type

Public Type tObject_Unit_Collection
    Objects() As tObject_Unit_Complete
    Count As Long
End Type

Public Type tObject_Unit_Player_Collection
    Objects() As tObject_Unit_Player_Complete
    Count As Long
End Type

Public Type tObject_Game_Object_Collection
    Objects() As tObject_Game_Object_Complete
    Count As Long
End Type

Public Type tObject_Dynamic_Object_Collection
    Objects() As tObject_Dynamic_Object_Complete
    Count As Long
End Type

Public Type tObject_Corpse_Collection
    Objects() As tObject_Corpse_Complete
    Count As Long
End Type

Public Enum enumObjectTypes
    Object_Base = 1
    Object_Item = 2 + 1
    Object_Item_Container = 4 + 2 + 1
    Object_Unit = 8 + 1
    Object_Unit_Player = 16 + 8 + 1
    Object_Game_Object = 32 + 1
    Object_Dynamic_Object = 64 + 1
    Object_Corpse = 128 + 1
End Enum

Public Type tObjectMovements
    Flags As Long
    X_Position As Single
    Y_Position As Single
    Z_Position As Single
    Facing As Single
    WalkSpeed As Single
    RunSpeed As Single
    SwimSpeed As Single
    TurnRate As Single
    'Flags2 As Long
    'Int_Unknown As Long
    'U64_Unknown As tGUID
    'UInt_SplineCount As Long
End Type

Public Type tObjectMovements_Collection
    Movements() As tObjectMovements
    GUIDs() As tGUID
    Count As Long
End Type

