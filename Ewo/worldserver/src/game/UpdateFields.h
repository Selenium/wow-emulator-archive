/*
 * Copyright (C) 2006 Team Evolution
 * Client data information:
 *   - Size:          5104 KBytes
 *   - Update Fileds: 342
 *   - Build:         6337
 *   - Version:       2.0.6
 *
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

#include "Common.h"

#ifndef _UPDATEFIELDS_AUTO_H
#define _UPDATEFIELDS_AUTO_H

enum EObjectFields
{
    OBJECT_FIELD_GUID                             = 0x0000,     // guid<2>
    OBJECT_FIELD_TYPE                             = 0x0002,     // uint32<1>
    OBJECT_FIELD_ENTRY                            = 0x0003,     // uint32<1>
    OBJECT_FIELD_SCALE_X                          = 0x0004,     // float<1>
    OBJECT_FIELD_PADDING                          = 0x0005,     // uint32<1>
    OBJECT_END                                    = OBJECT_FIELD_PADDING + 1,
};

enum EItemFields
{
    ITEM_FIELD_OWNER                              = OBJECT_END + 0x0000,     // guid<2>
    ITEM_FIELD_CONTAINED                          = OBJECT_END + 0x0002,     // guid<2>
    ITEM_FIELD_CREATOR                            = OBJECT_END + 0x0004,     // guid<2>
    ITEM_FIELD_GIFTCREATOR                        = OBJECT_END + 0x0006,     // guid<2>
    ITEM_FIELD_STACK_COUNT                        = OBJECT_END + 0x0008,     // uint32<1>
    ITEM_FIELD_DURATION                           = OBJECT_END + 0x0009,     // uint32<1>
    ITEM_FIELD_SPELL_CHARGES                      = OBJECT_END + 0x000A,     // uint32<5>
    ITEM_FIELD_FLAGS                              = OBJECT_END + 0x000F,     // uint32<1>
    ITEM_FIELD_ENCHANTMENT                        = OBJECT_END + 0x0010,     // uint32<33>
    ITEM_FIELD_PROPERTY_SEED                      = OBJECT_END + 0x0031,     // uint32<1>
    ITEM_FIELD_RANDOM_PROPERTIES_ID               = OBJECT_END + 0x0032,     // uint32<1>
    ITEM_FIELD_ITEM_TEXT_ID                       = OBJECT_END + 0x0033,     // uint32<1>
    ITEM_FIELD_DURABILITY                         = OBJECT_END + 0x0034,     // uint32<1>
    ITEM_FIELD_MAXDURABILITY                      = OBJECT_END + 0x0035,     // uint32<1>
    ITEM_END                                      = ITEM_FIELD_MAXDURABILITY + 1,
};

enum EContainerFields
{
    CONTAINER_FIELD_NUM_SLOTS                     = ITEM_END + 0x0000,     // uint32<1>
    CONTAINER_ALIGN_PAD                           = ITEM_END + 0x0001,     // bytes<1>
    CONTAINER_FIELD_SLOT_1                        = ITEM_END + 0x0002,     // guid<72>
    CONTAINER_END                                 = CONTAINER_FIELD_SLOT_1 + 72,
};

enum EUnitFields
{
    UNIT_FIELD_CHARM                              = OBJECT_END + 0x0000,     // guid<2>
    UNIT_FIELD_SUMMON                             = OBJECT_END + 0x0002,     // guid<2>
    UNIT_FIELD_CHARMEDBY                          = OBJECT_END + 0x0004,     // guid<2>
    UNIT_FIELD_SUMMONEDBY                         = OBJECT_END + 0x0006,     // guid<2>
    UNIT_FIELD_CREATEDBY                          = OBJECT_END + 0x0008,     // guid<2>
    UNIT_FIELD_TARGET                             = OBJECT_END + 0x000A,     // guid<2>
    UNIT_FIELD_PERSUADED                          = OBJECT_END + 0x000C,     // guid<2>
    UNIT_FIELD_CHANNEL_OBJECT                     = OBJECT_END + 0x000E,     // guid<2>
    UNIT_FIELD_HEALTH                             = OBJECT_END + 0x0010,     // uint32<1>
    UNIT_FIELD_POWER1                             = OBJECT_END + 0x0011,     // uint32<1>
    UNIT_FIELD_POWER2                             = OBJECT_END + 0x0012,     // uint32<1>
    UNIT_FIELD_POWER3                             = OBJECT_END + 0x0013,     // uint32<1>
    UNIT_FIELD_POWER4                             = OBJECT_END + 0x0014,     // uint32<1>
    UNIT_FIELD_POWER5                             = OBJECT_END + 0x0015,     // uint32<1>
    UNIT_FIELD_MAXHEALTH                          = OBJECT_END + 0x0016,     // uint32<1>
    UNIT_FIELD_MAXPOWER1                          = OBJECT_END + 0x0017,     // uint32<1>
    UNIT_FIELD_MAXPOWER2                          = OBJECT_END + 0x0018,     // uint32<1>
    UNIT_FIELD_MAXPOWER3                          = OBJECT_END + 0x0019,     // uint32<1>
    UNIT_FIELD_MAXPOWER4                          = OBJECT_END + 0x001A,     // uint32<1>
    UNIT_FIELD_MAXPOWER5                          = OBJECT_END + 0x001B,     // uint32<1>
    UNIT_FIELD_LEVEL                              = OBJECT_END + 0x001C,     // uint32<1>
    UNIT_FIELD_FACTIONTEMPLATE                    = OBJECT_END + 0x001D,     // uint32<1>
    UNIT_FIELD_BYTES_0                            = OBJECT_END + 0x001E,     // bytes<1>
    UNIT_VIRTUAL_ITEM_SLOT_DISPLAY                = OBJECT_END + 0x001F,     // uint32<3>
    UNIT_VIRTUAL_ITEM_INFO                        = OBJECT_END + 0x0022,     // bytes<6>
    UNIT_FIELD_FLAGS                              = OBJECT_END + 0x0028,     // uint32<1>
    UNIT_FIELD_FLAGS_2                            = OBJECT_END + 0x0029,     // uint32<1>
    UNIT_FIELD_AURA                               = OBJECT_END + 0x002A,     // uint32<56>
    UNIT_FIELD_AURAFLAGS                          = OBJECT_END + 0x0062,     // bytes<7>
    UNIT_FIELD_AURALEVELS                         = OBJECT_END + 0x0069,     // bytes<14>
    UNIT_FIELD_AURAAPPLICATIONS                   = OBJECT_END + 0x0077,     // bytes<14>
    UNIT_FIELD_AURASTATE                          = OBJECT_END + 0x0085,     // uint32<1>
    UNIT_FIELD_BASEATTACKTIME                     = OBJECT_END + 0x0086,     // uint32<2>
    UNIT_FIELD_RANGEDATTACKTIME                   = OBJECT_END + 0x0088,     // uint32<1>
    UNIT_FIELD_BOUNDINGRADIUS                     = OBJECT_END + 0x0089,     // float<1>
    UNIT_FIELD_COMBATREACH                        = OBJECT_END + 0x008A,     // float<1>
    UNIT_FIELD_DISPLAYID                          = OBJECT_END + 0x008B,     // uint32<1>
    UNIT_FIELD_NATIVEDISPLAYID                    = OBJECT_END + 0x008C,     // uint32<1>
    UNIT_FIELD_MOUNTDISPLAYID                     = OBJECT_END + 0x008D,     // uint32<1>
    UNIT_FIELD_MINDAMAGE                          = OBJECT_END + 0x008E,     // float<1>
    UNIT_FIELD_MAXDAMAGE                          = OBJECT_END + 0x008F,     // float<1>
    UNIT_FIELD_MINOFFHANDDAMAGE                   = OBJECT_END + 0x0090,     // float<1>
    UNIT_FIELD_MAXOFFHANDDAMAGE                   = OBJECT_END + 0x0091,     // float<1>
    UNIT_FIELD_BYTES_1                            = OBJECT_END + 0x0092,     // bytes<1>
    UNIT_FIELD_PETNUMBER                          = OBJECT_END + 0x0093,     // uint32<1>
    UNIT_FIELD_PET_NAME_TIMESTAMP                 = OBJECT_END + 0x0094,     // uint32<1>
    UNIT_FIELD_PETEXPERIENCE                      = OBJECT_END + 0x0095,     // uint32<1>
    UNIT_FIELD_PETNEXTLEVELEXP                    = OBJECT_END + 0x0096,     // uint32<1>
    UNIT_DYNAMIC_FLAGS                            = OBJECT_END + 0x0097,     // uint32<1>
    UNIT_CHANNEL_SPELL                            = OBJECT_END + 0x0098,     // uint32<1>
    UNIT_MOD_CAST_SPEED                           = OBJECT_END + 0x0099,     // float<1>
    UNIT_CREATED_BY_SPELL                         = OBJECT_END + 0x009A,     // uint32<1>
    UNIT_NPC_FLAGS                                = OBJECT_END + 0x009B,     // uint32<1>
    UNIT_NPC_EMOTESTATE                           = OBJECT_END + 0x009C,     // uint32<1>
    UNIT_TRAINING_POINTS                          = OBJECT_END + 0x009D,     // bytes<1>
    UNIT_FIELD_STAT0                              = OBJECT_END + 0x009E,     // uint32<1>
    UNIT_FIELD_STAT1                              = OBJECT_END + 0x009F,     // uint32<1>
    UNIT_FIELD_STAT2                              = OBJECT_END + 0x00A0,     // uint32<1>
    UNIT_FIELD_STAT3                              = OBJECT_END + 0x00A1,     // uint32<1>
    UNIT_FIELD_STAT4                              = OBJECT_END + 0x00A2,     // uint32<1>
    UNIT_FIELD_POSSTAT0                           = OBJECT_END + 0x00A3,     // uint32<1>
    UNIT_FIELD_POSSTAT1                           = OBJECT_END + 0x00A4,     // uint32<1>
    UNIT_FIELD_POSSTAT2                           = OBJECT_END + 0x00A5,     // uint32<1>
    UNIT_FIELD_POSSTAT3                           = OBJECT_END + 0x00A6,     // uint32<1>
    UNIT_FIELD_POSSTAT4                           = OBJECT_END + 0x00A7,     // uint32<1>
    UNIT_FIELD_NEGSTAT0                           = OBJECT_END + 0x00A8,     // uint32<1>
    UNIT_FIELD_NEGSTAT1                           = OBJECT_END + 0x00A9,     // uint32<1>
    UNIT_FIELD_NEGSTAT2                           = OBJECT_END + 0x00AA,     // uint32<1>
    UNIT_FIELD_NEGSTAT3                           = OBJECT_END + 0x00AB,     // uint32<1>
    UNIT_FIELD_NEGSTAT4                           = OBJECT_END + 0x00AC,     // uint32<1>
    UNIT_FIELD_RESISTANCES                        = OBJECT_END + 0x00AD,     // uint32<7>
    UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE         = OBJECT_END + 0x00B4,     // uint32<7>
    UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE         = OBJECT_END + 0x00BB,     // uint32<7>
    UNIT_FIELD_BASE_MANA                          = OBJECT_END + 0x00C2,     // uint32<1>
    UNIT_FIELD_BASE_HEALTH                        = OBJECT_END + 0x00C3,     // uint32<1>
    UNIT_FIELD_BYTES_2                            = OBJECT_END + 0x00C4,     // bytes<1>
    UNIT_FIELD_ATTACK_POWER                       = OBJECT_END + 0x00C5,     // uint32<1>
    UNIT_FIELD_ATTACK_POWER_MODS                  = OBJECT_END + 0x00C6,     // bytes<1>
    UNIT_FIELD_ATTACK_POWER_MULTIPLIER            = OBJECT_END + 0x00C7,     // float<1>
    UNIT_FIELD_RANGED_ATTACK_POWER                = OBJECT_END + 0x00C8,     // uint32<1>
    UNIT_FIELD_RANGED_ATTACK_POWER_MODS           = OBJECT_END + 0x00C9,     // bytes<1>
    UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER     = OBJECT_END + 0x00CA,     // float<1>
    UNIT_FIELD_MINRANGEDDAMAGE                    = OBJECT_END + 0x00CB,     // float<1>
    UNIT_FIELD_MAXRANGEDDAMAGE                    = OBJECT_END + 0x00CC,     // float<1>
    UNIT_FIELD_POWER_COST_MODIFIER                = OBJECT_END + 0x00CD,     // uint32<7>
    UNIT_FIELD_POWER_COST_MULTIPLIER              = OBJECT_END + 0x00D4,     // float<7>
    UNIT_FIELD_PADDING                            = OBJECT_END + 0x00DB,     // uint32<1>
    UNIT_END                                      = UNIT_FIELD_PADDING + 1,
};

enum EPlayerFields
{
    PLAYER_DUEL_ARBITER                           = UNIT_END + 0x0000,     // guid<2>
    PLAYER_FLAGS                                  = UNIT_END + 0x0002,     // uint32<1>
    PLAYER_GUILDID                                = UNIT_END + 0x0003,     // uint32<1>
    PLAYER_GUILDRANK                              = UNIT_END + 0x0004,     // uint32<1>
    PLAYER_BYTES                                  = UNIT_END + 0x0005,     // bytes<1>
    PLAYER_BYTES_2                                = UNIT_END + 0x0006,     // bytes<1>
    PLAYER_BYTES_3                                = UNIT_END + 0x0007,     // bytes<1>
    PLAYER_DUEL_TEAM                              = UNIT_END + 0x0008,     // uint32<1>
    PLAYER_GUILD_TIMESTAMP                        = UNIT_END + 0x0009,     // uint32<1>
    PLAYER_QUEST_LOG_1_1                          = UNIT_END + 0x000A,     // uint32<1>
    PLAYER_QUEST_LOG_1_2                          = UNIT_END + 0x000B,     // uint32<2>
    PLAYER_QUEST_LOG_2_1                          = UNIT_END + 0x000D,     // uint32<1>
    PLAYER_QUEST_LOG_2_2                          = UNIT_END + 0x000E,     // uint32<2>
    PLAYER_QUEST_LOG_3_1                          = UNIT_END + 0x0010,     // uint32<1>
    PLAYER_QUEST_LOG_3_2                          = UNIT_END + 0x0011,     // uint32<2>
    PLAYER_QUEST_LOG_4_1                          = UNIT_END + 0x0013,     // uint32<1>
    PLAYER_QUEST_LOG_4_2                          = UNIT_END + 0x0014,     // uint32<2>
    PLAYER_QUEST_LOG_5_1                          = UNIT_END + 0x0016,     // uint32<1>
    PLAYER_QUEST_LOG_5_2                          = UNIT_END + 0x0017,     // uint32<2>
    PLAYER_QUEST_LOG_6_1                          = UNIT_END + 0x0019,     // uint32<1>
    PLAYER_QUEST_LOG_6_2                          = UNIT_END + 0x001A,     // uint32<2>
    PLAYER_QUEST_LOG_7_1                          = UNIT_END + 0x001C,     // uint32<1>
    PLAYER_QUEST_LOG_7_2                          = UNIT_END + 0x001D,     // uint32<2>
    PLAYER_QUEST_LOG_8_1                          = UNIT_END + 0x001F,     // uint32<1>
    PLAYER_QUEST_LOG_8_2                          = UNIT_END + 0x0020,     // uint32<2>
    PLAYER_QUEST_LOG_9_1                          = UNIT_END + 0x0022,     // uint32<1>
    PLAYER_QUEST_LOG_9_2                          = UNIT_END + 0x0023,     // uint32<2>
    PLAYER_QUEST_LOG_10_1                         = UNIT_END + 0x0025,     // uint32<1>
    PLAYER_QUEST_LOG_10_2                         = UNIT_END + 0x0026,     // uint32<2>
    PLAYER_QUEST_LOG_11_1                         = UNIT_END + 0x0028,     // uint32<1>
    PLAYER_QUEST_LOG_11_2                         = UNIT_END + 0x0029,     // uint32<2>
    PLAYER_QUEST_LOG_12_1                         = UNIT_END + 0x002B,     // uint32<1>
    PLAYER_QUEST_LOG_12_2                         = UNIT_END + 0x002C,     // uint32<2>
    PLAYER_QUEST_LOG_13_1                         = UNIT_END + 0x002E,     // uint32<1>
    PLAYER_QUEST_LOG_13_2                         = UNIT_END + 0x002F,     // uint32<2>
    PLAYER_QUEST_LOG_14_1                         = UNIT_END + 0x0031,     // uint32<1>
    PLAYER_QUEST_LOG_14_2                         = UNIT_END + 0x0032,     // uint32<2>
    PLAYER_QUEST_LOG_15_1                         = UNIT_END + 0x0034,     // uint32<1>
    PLAYER_QUEST_LOG_15_2                         = UNIT_END + 0x0035,     // uint32<2>
    PLAYER_QUEST_LOG_16_1                         = UNIT_END + 0x0037,     // uint32<1>
    PLAYER_QUEST_LOG_16_2                         = UNIT_END + 0x0038,     // uint32<2>
    PLAYER_QUEST_LOG_17_1                         = UNIT_END + 0x003A,     // uint32<1>
    PLAYER_QUEST_LOG_17_2                         = UNIT_END + 0x003B,     // uint32<2>
    PLAYER_QUEST_LOG_18_1                         = UNIT_END + 0x003D,     // uint32<1>
    PLAYER_QUEST_LOG_18_2                         = UNIT_END + 0x003E,     // uint32<2>
    PLAYER_QUEST_LOG_19_1                         = UNIT_END + 0x0040,     // uint32<1>
    PLAYER_QUEST_LOG_19_2                         = UNIT_END + 0x0041,     // uint32<2>
    PLAYER_QUEST_LOG_20_1                         = UNIT_END + 0x0043,     // uint32<1>
    PLAYER_QUEST_LOG_20_2                         = UNIT_END + 0x0044,     // uint32<2>
    PLAYER_QUEST_LOG_21_1                         = UNIT_END + 0x0046,     // uint32<1>
    PLAYER_QUEST_LOG_21_2                         = UNIT_END + 0x0047,     // uint32<2>
    PLAYER_QUEST_LOG_22_1                         = UNIT_END + 0x0049,     // uint32<1>
    PLAYER_QUEST_LOG_22_2                         = UNIT_END + 0x004A,     // uint32<2>
    PLAYER_QUEST_LOG_23_1                         = UNIT_END + 0x004C,     // uint32<1>
    PLAYER_QUEST_LOG_23_2                         = UNIT_END + 0x004D,     // uint32<2>
    PLAYER_QUEST_LOG_24_1                         = UNIT_END + 0x004F,     // uint32<1>
    PLAYER_QUEST_LOG_24_2                         = UNIT_END + 0x0050,     // uint32<2>
    PLAYER_QUEST_LOG_25_1                         = UNIT_END + 0x0052,     // uint32<1>
    PLAYER_QUEST_LOG_25_2                         = UNIT_END + 0x0053,     // uint32<2>
    PLAYER_VISIBLE_ITEM_1_CREATOR                 = UNIT_END + 0x0055,     // guid<2>
    PLAYER_VISIBLE_ITEM_1_0                       = UNIT_END + 0x0057,     // uint32<12>
    PLAYER_VISIBLE_ITEM_1_PROPERTIES              = UNIT_END + 0x0063,     // bytes<1>
    PLAYER_VISIBLE_ITEM_1_PAD                     = UNIT_END + 0x0064,     // uint32<1>
    PLAYER_VISIBLE_ITEM_2_CREATOR                 = UNIT_END + 0x0065,     // guid<2>
    PLAYER_VISIBLE_ITEM_2_0                       = UNIT_END + 0x0067,     // uint32<12>
    PLAYER_VISIBLE_ITEM_2_PROPERTIES              = UNIT_END + 0x0073,     // bytes<1>
    PLAYER_VISIBLE_ITEM_2_PAD                     = UNIT_END + 0x0074,     // uint32<1>
    PLAYER_VISIBLE_ITEM_3_CREATOR                 = UNIT_END + 0x0075,     // guid<2>
    PLAYER_VISIBLE_ITEM_3_0                       = UNIT_END + 0x0077,     // uint32<12>
    PLAYER_VISIBLE_ITEM_3_PROPERTIES              = UNIT_END + 0x0083,     // bytes<1>
    PLAYER_VISIBLE_ITEM_3_PAD                     = UNIT_END + 0x0084,     // uint32<1>
    PLAYER_VISIBLE_ITEM_4_CREATOR                 = UNIT_END + 0x0085,     // guid<2>
    PLAYER_VISIBLE_ITEM_4_0                       = UNIT_END + 0x0087,     // uint32<12>
    PLAYER_VISIBLE_ITEM_4_PROPERTIES              = UNIT_END + 0x0093,     // bytes<1>
    PLAYER_VISIBLE_ITEM_4_PAD                     = UNIT_END + 0x0094,     // uint32<1>
    PLAYER_VISIBLE_ITEM_5_CREATOR                 = UNIT_END + 0x0095,     // guid<2>
    PLAYER_VISIBLE_ITEM_5_0                       = UNIT_END + 0x0097,     // uint32<12>
    PLAYER_VISIBLE_ITEM_5_PROPERTIES              = UNIT_END + 0x00A3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_5_PAD                     = UNIT_END + 0x00A4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_6_CREATOR                 = UNIT_END + 0x00A5,     // guid<2>
    PLAYER_VISIBLE_ITEM_6_0                       = UNIT_END + 0x00A7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_6_PROPERTIES              = UNIT_END + 0x00B3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_6_PAD                     = UNIT_END + 0x00B4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_7_CREATOR                 = UNIT_END + 0x00B5,     // guid<2>
    PLAYER_VISIBLE_ITEM_7_0                       = UNIT_END + 0x00B7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_7_PROPERTIES              = UNIT_END + 0x00C3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_7_PAD                     = UNIT_END + 0x00C4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_8_CREATOR                 = UNIT_END + 0x00C5,     // guid<2>
    PLAYER_VISIBLE_ITEM_8_0                       = UNIT_END + 0x00C7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_8_PROPERTIES              = UNIT_END + 0x00D3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_8_PAD                     = UNIT_END + 0x00D4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_9_CREATOR                 = UNIT_END + 0x00D5,     // guid<2>
    PLAYER_VISIBLE_ITEM_9_0                       = UNIT_END + 0x00D7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_9_PROPERTIES              = UNIT_END + 0x00E3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_9_PAD                     = UNIT_END + 0x00E4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_10_CREATOR                = UNIT_END + 0x00E5,     // guid<2>
    PLAYER_VISIBLE_ITEM_10_0                      = UNIT_END + 0x00E7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_10_PROPERTIES             = UNIT_END + 0x00F3,     // bytes<1>
    PLAYER_VISIBLE_ITEM_10_PAD                    = UNIT_END + 0x00F4,     // uint32<1>
    PLAYER_VISIBLE_ITEM_11_CREATOR                = UNIT_END + 0x00F5,     // guid<2>
    PLAYER_VISIBLE_ITEM_11_0                      = UNIT_END + 0x00F7,     // uint32<12>
    PLAYER_VISIBLE_ITEM_11_PROPERTIES             = UNIT_END + 0x0103,     // bytes<1>
    PLAYER_VISIBLE_ITEM_11_PAD                    = UNIT_END + 0x0104,     // uint32<1>
    PLAYER_VISIBLE_ITEM_12_CREATOR                = UNIT_END + 0x0105,     // guid<2>
    PLAYER_VISIBLE_ITEM_12_0                      = UNIT_END + 0x0107,     // uint32<12>
    PLAYER_VISIBLE_ITEM_12_PROPERTIES             = UNIT_END + 0x0113,     // bytes<1>
    PLAYER_VISIBLE_ITEM_12_PAD                    = UNIT_END + 0x0114,     // uint32<1>
    PLAYER_VISIBLE_ITEM_13_CREATOR                = UNIT_END + 0x0115,     // guid<2>
    PLAYER_VISIBLE_ITEM_13_0                      = UNIT_END + 0x0117,     // uint32<12>
    PLAYER_VISIBLE_ITEM_13_PROPERTIES             = UNIT_END + 0x0123,     // bytes<1>
    PLAYER_VISIBLE_ITEM_13_PAD                    = UNIT_END + 0x0124,     // uint32<1>
    PLAYER_VISIBLE_ITEM_14_CREATOR                = UNIT_END + 0x0125,     // guid<2>
    PLAYER_VISIBLE_ITEM_14_0                      = UNIT_END + 0x0127,     // uint32<12>
    PLAYER_VISIBLE_ITEM_14_PROPERTIES             = UNIT_END + 0x0133,     // bytes<1>
    PLAYER_VISIBLE_ITEM_14_PAD                    = UNIT_END + 0x0134,     // uint32<1>
    PLAYER_VISIBLE_ITEM_15_CREATOR                = UNIT_END + 0x0135,     // guid<2>
    PLAYER_VISIBLE_ITEM_15_0                      = UNIT_END + 0x0137,     // uint32<12>
    PLAYER_VISIBLE_ITEM_15_PROPERTIES             = UNIT_END + 0x0143,     // bytes<1>
    PLAYER_VISIBLE_ITEM_15_PAD                    = UNIT_END + 0x0144,     // uint32<1>
    PLAYER_VISIBLE_ITEM_16_CREATOR                = UNIT_END + 0x0145,     // guid<2>
    PLAYER_VISIBLE_ITEM_16_0                      = UNIT_END + 0x0147,     // uint32<12>
    PLAYER_VISIBLE_ITEM_16_PROPERTIES             = UNIT_END + 0x0153,     // bytes<1>
    PLAYER_VISIBLE_ITEM_16_PAD                    = UNIT_END + 0x0154,     // uint32<1>
    PLAYER_VISIBLE_ITEM_17_CREATOR                = UNIT_END + 0x0155,     // guid<2>
    PLAYER_VISIBLE_ITEM_17_0                      = UNIT_END + 0x0157,     // uint32<12>
    PLAYER_VISIBLE_ITEM_17_PROPERTIES             = UNIT_END + 0x0163,     // bytes<1>
    PLAYER_VISIBLE_ITEM_17_PAD                    = UNIT_END + 0x0164,     // uint32<1>
    PLAYER_VISIBLE_ITEM_18_CREATOR                = UNIT_END + 0x0165,     // guid<2>
    PLAYER_VISIBLE_ITEM_18_0                      = UNIT_END + 0x0167,     // uint32<12>
    PLAYER_VISIBLE_ITEM_18_PROPERTIES             = UNIT_END + 0x0173,     // bytes<1>
    PLAYER_VISIBLE_ITEM_18_PAD                    = UNIT_END + 0x0174,     // uint32<1>
    PLAYER_VISIBLE_ITEM_19_CREATOR                = UNIT_END + 0x0175,     // guid<2>
    PLAYER_VISIBLE_ITEM_19_0                      = UNIT_END + 0x0177,     // uint32<12>
    PLAYER_VISIBLE_ITEM_19_PROPERTIES             = UNIT_END + 0x0183,     // bytes<1>
    PLAYER_VISIBLE_ITEM_19_PAD                    = UNIT_END + 0x0184,     // uint32<1>
    PLAYER_CHOSEN_TITLE                           = UNIT_END + 0x0185,     // uint32<1>
    PLAYER_FIELD_INV_SLOT_HEAD                    = UNIT_END + 0x0186,     // guid<46>
    PLAYER_FIELD_PACK_SLOT_1                      = UNIT_END + 0x01B4,     // guid<32>
    PLAYER_FIELD_BANK_SLOT_1                      = UNIT_END + 0x01D4,     // guid<56>
    PLAYER_FIELD_BANKBAG_SLOT_1                   = UNIT_END + 0x020C,     // guid<14>
    PLAYER_FIELD_VENDORBUYBACK_SLOT_1             = UNIT_END + 0x021A,     // guid<24>
    PLAYER_FIELD_KEYRING_SLOT_1                   = UNIT_END + 0x0232,     // guid<64>
    PLAYER_FARSIGHT                               = UNIT_END + 0x0272,     // guid<2>
    PLAYER__FIELD_COMBO_TARGET                    = UNIT_END + 0x0274,     // guid<2>
    PLAYER__FIELD_KNOWN_TITLES                    = UNIT_END + 0x0276,     // guid<2>
    PLAYER_XP                                     = UNIT_END + 0x0278,     // uint32<1>
    PLAYER_NEXT_LEVEL_XP                          = UNIT_END + 0x0279,     // uint32<1>
    PLAYER_SKILL_INFO_1_1                         = UNIT_END + 0x027A,     // bytes<384>
    PLAYER_CHARACTER_POINTS1                      = UNIT_END + 0x03FA,     // uint32<1>
    PLAYER_CHARACTER_POINTS2                      = UNIT_END + 0x03FB,     // uint32<1>
    PLAYER_TRACK_CREATURES                        = UNIT_END + 0x03FC,     // uint32<1>
    PLAYER_TRACK_RESOURCES                        = UNIT_END + 0x03FD,     // uint32<1>
    PLAYER_BLOCK_PERCENTAGE                       = UNIT_END + 0x03FE,     // float<1>
    PLAYER_DODGE_PERCENTAGE                       = UNIT_END + 0x03FF,     // float<1>
    PLAYER_PARRY_PERCENTAGE                       = UNIT_END + 0x0400,     // float<1>
    PLAYER_CRIT_PERCENTAGE                        = UNIT_END + 0x0401,     // float<1>
    PLAYER_RANGED_CRIT_PERCENTAGE                 = UNIT_END + 0x0402,     // float<1>
    PLAYER_OFFHAND_CRIT_PERCENTAGE                = UNIT_END + 0x0403,     // float<1>
    PLAYER_SPELL_CRIT_PERCENTAGE1                 = UNIT_END + 0x0404,     // float<7>
    PLAYER_EXPLORED_ZONES_1                       = UNIT_END + 0x040B,     // bytes<64>
    PLAYER_REST_STATE_EXPERIENCE                  = UNIT_END + 0x044B,     // uint32<1>
    PLAYER_FIELD_COINAGE                          = UNIT_END + 0x044C,     // uint32<1>
    PLAYER_FIELD_MOD_DAMAGE_DONE_POS              = UNIT_END + 0x044D,     // uint32<7>
    PLAYER_FIELD_MOD_DAMAGE_DONE_NEG              = UNIT_END + 0x0454,     // uint32<7>
    PLAYER_FIELD_MOD_DAMAGE_DONE_PCT              = UNIT_END + 0x045B,     // uint32<7>
    PLAYER_FIELD_MOD_HEALING_DONE_POS             = UNIT_END + 0x0462,     // uint32<1>
    PLAYER_FIELD_MOD_TARGET_RESISTANCE            = UNIT_END + 0x0463,     // uint32<1>
    PLAYER_FIELD_BYTES                            = UNIT_END + 0x0464,     // bytes<1>
    PLAYER_AMMO_ID                                = UNIT_END + 0x0465,     // uint32<1>
    PLAYER_SELF_RES_SPELL                         = UNIT_END + 0x0466,     // uint32<1>
    PLAYER_FIELD_PVP_MEDALS                       = UNIT_END + 0x0467,     // uint32<1>
    PLAYER_FIELD_BUYBACK_PRICE_1                  = UNIT_END + 0x0468,     // uint32<12>
    PLAYER_FIELD_BUYBACK_TIMESTAMP_1              = UNIT_END + 0x0474,     // uint32<12>
    PLAYER_FIELD_KILLS                            = UNIT_END + 0x0480,     // bytes<1>
    PLAYER_FIELD_TODAY_CONTRIBUTION               = UNIT_END + 0x0481,     // uint32<1>
    PLAYER_FIELD_YESTERDAY_CONTRIBUTION           = UNIT_END + 0x0482,     // uint32<1>
    PLAYER_FIELD_LIFETIME_HONORBALE_KILLS         = UNIT_END + 0x0483,     // uint32<1>
    PLAYER_FIELD_BYTES2                           = UNIT_END + 0x0484,     // bytes<1>
    PLAYER_FIELD_WATCHED_FACTION_INDEX            = UNIT_END + 0x0485,     // uint32<1>
    PLAYER_FIELD_COMBAT_RATING_1                  = UNIT_END + 0x0486,     // uint32<23>
    PLAYER_FIELD_ARENA_TEAM_INFO_1_1              = UNIT_END + 0x049D,     // uint32<9>
    PLAYER_FIELD_HONOR_CURRENCY                   = UNIT_END + 0x04A6,     // uint32<1>
    PLAYER_FIELD_ARENA_CURRENCY                   = UNIT_END + 0x04A7,     // uint32<1>
    PLAYER_FIELD_MOD_MANA_REGEN                   = UNIT_END + 0x04A8,     // float<1>
    PLAYER_FIELD_MOD_MANA_REGEN_INTERRUPT         = UNIT_END + 0x04A9,     // float<1>
    PLAYER_FIELD_MAX_LEVEL                        = UNIT_END + 0x04AA,     // uint32<1>
    PLAYER_FIELD_PADDING                          = UNIT_END + 0x04AB,     // uint32<1>
    PLAYER_END                                    = PLAYER_FIELD_PADDING + 1,
};

enum EGameObjectFields
{
    OBJECT_FIELD_CREATED_BY                       = OBJECT_END + 0x0000,     // guid<2>
    GAMEOBJECT_DISPLAYID                          = OBJECT_END + 0x0002,     // uint32<1>
    GAMEOBJECT_FLAGS                              = OBJECT_END + 0x0003,     // uint32<1>
    GAMEOBJECT_ROTATION                           = OBJECT_END + 0x0004,     // float<4>
    GAMEOBJECT_STATE                              = OBJECT_END + 0x0008,     // uint32<1>
    GAMEOBJECT_POS_X                              = OBJECT_END + 0x0009,     // float<1>
    GAMEOBJECT_POS_Y                              = OBJECT_END + 0x000A,     // float<1>
    GAMEOBJECT_POS_Z                              = OBJECT_END + 0x000B,     // float<1>
    GAMEOBJECT_FACING                             = OBJECT_END + 0x000C,     // float<1>
    GAMEOBJECT_DYN_FLAGS                          = OBJECT_END + 0x000D,     // uint32<1>
    GAMEOBJECT_FACTION                            = OBJECT_END + 0x000E,     // uint32<1>
    GAMEOBJECT_TYPE_ID                            = OBJECT_END + 0x000F,     // uint32<1>
    GAMEOBJECT_LEVEL                              = OBJECT_END + 0x0010,     // uint32<1>
    GAMEOBJECT_ARTKIT                             = OBJECT_END + 0x0011,     // uint32<1>
    GAMEOBJECT_ANIMPROGRESS                       = OBJECT_END + 0x0012,     // uint32<1>
    GAMEOBJECT_PADDING                            = OBJECT_END + 0x0013,     // uint32<1>
    GAMEOBJECT_END                                = GAMEOBJECT_PADDING + 1,
};

enum EDynamicObjectFields
{
    DYNAMICOBJECT_CASTER                          = OBJECT_END + 0x0000,     // guid<2>
    DYNAMICOBJECT_BYTES                           = OBJECT_END + 0x0002,     // bytes<1>
    DYNAMICOBJECT_SPELLID                         = OBJECT_END + 0x0003,     // uint32<1>
    DYNAMICOBJECT_RADIUS                          = OBJECT_END + 0x0004,     // float<1>
    DYNAMICOBJECT_POS_X                           = OBJECT_END + 0x0005,     // float<1>
    DYNAMICOBJECT_POS_Y                           = OBJECT_END + 0x0006,     // float<1>
    DYNAMICOBJECT_POS_Z                           = OBJECT_END + 0x0007,     // float<1>
    DYNAMICOBJECT_FACING                          = OBJECT_END + 0x0008,     // float<1>
    DYNAMICOBJECT_PAD                             = OBJECT_END + 0x0009,     // bytes<1>
    DYNAMICOBJECT_END                             = DYNAMICOBJECT_PAD + 1,
};

enum ECorpseFields
{
    CORPSE_FIELD_OWNER                            = OBJECT_END + 0x0000,     // guid<2>
    CORPSE_FIELD_FACING                           = OBJECT_END + 0x0002,     // float<1>
    CORPSE_FIELD_POS_X                            = OBJECT_END + 0x0003,     // float<1>
    CORPSE_FIELD_POS_Y                            = OBJECT_END + 0x0004,     // float<1>
    CORPSE_FIELD_POS_Z                            = OBJECT_END + 0x0005,     // float<1>
    CORPSE_FIELD_DISPLAY_ID                       = OBJECT_END + 0x0006,     // uint32<1>
    CORPSE_FIELD_ITEM                             = OBJECT_END + 0x0007,     // uint32<19>
    CORPSE_FIELD_BYTES_1                          = OBJECT_END + 0x001A,     // bytes<1>
    CORPSE_FIELD_BYTES_2                          = OBJECT_END + 0x001B,     // bytes<1>
    CORPSE_FIELD_GUILD                            = OBJECT_END + 0x001C,     // uint32<1>
    CORPSE_FIELD_FLAGS                            = OBJECT_END + 0x001D,     // uint32<1>
    CORPSE_FIELD_DYNAMIC_FLAGS                    = OBJECT_END + 0x001E,     // uint32<1>
    CORPSE_FIELD_PAD                              = OBJECT_END + 0x001F,     // uint32<1>
    CORPSE_END                                    = CORPSE_FIELD_PAD + 1,
};

#endif
