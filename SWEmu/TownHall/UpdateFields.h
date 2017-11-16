#ifndef UPDATEFIELDS_H
#define UPDATEFIELDS_H

// 1.12.x Update Fields as of build 5590 (PTR)

#if TBC
//OBJECT:
#define  OBJECT_FIELD_GUID                                          0x000   //  Size:2  Type:GUID   Flags:1
#define  OBJECT_FIELD_TYPE                                          0x002   //  Size:1  Type:Int32  Flags:1
#define  OBJECT_FIELD_ENTRY                                         0x003   //  Size:1  Type:Int32  Flags:1
#define  OBJECT_FIELD_SCALE_X                                       0x004   //  Size:1  Type:Float  Flags:1
#define  OBJECT_FIELD_PADDING                                       0x005   //  Size:1  Type:Int32  Flags:0
#define  OBJECT_END                                                 0x006

//ITEM:
#define  ITEM_FIELD_OWNER                                           OBJECT_END + 0x000  //  Size:2  Type:GUID   Flags:1
#define  ITEM_FIELD_CONTAINED                                       OBJECT_END + 0x002  //  Size:2  Type:GUID   Flags:1
#define  ITEM_FIELD_CREATOR                                         OBJECT_END + 0x004  //  Size:2  Type:GUID   Flags:1
#define  ITEM_FIELD_GIFTCREATOR                                     OBJECT_END + 0x006  //  Size:2  Type:GUID   Flags:1
#define  ITEM_FIELD_STACK_COUNT                                     OBJECT_END + 0x008  //  Size:1  Type:Int32  Flags:20
#define  ITEM_FIELD_DURATION                                        OBJECT_END + 0x009  //  Size:1  Type:Int32  Flags:20
#define  ITEM_FIELD_SPELL_CHARGES                                   OBJECT_END + 0x00A  //  Size:5  Type:Int32  Flags:20
#define  ITEM_FIELD_FLAGS                                           OBJECT_END + 0x00F  //  Size:1  Type:Int32  Flags:1
#define  ITEM_FIELD_ENCHANTMENT                                     OBJECT_END + 0x010  //  Size:33 Type:Int32  Flags:1
#define  ITEM_FIELD_PROPERTY_SEED                                   OBJECT_END + 0x031  //  Size:1  Type:Int32  Flags:1
#define  ITEM_FIELD_RANDOM_PROPERTIES_ID                            OBJECT_END + 0x032  //  Size:1  Type:Int32  Flags:1
#define  ITEM_FIELD_ITEM_TEXT_ID                                    OBJECT_END + 0x033  //  Size:1  Type:Int32  Flags:4
#define  ITEM_FIELD_DURABILITY                                      OBJECT_END + 0x034  //  Size:1  Type:Int32  Flags:20
#define  ITEM_FIELD_MAXDURABILITY                                   OBJECT_END + 0x035  //  Size:1  Type:Int32  Flags:20
#define  ITEM_END                                                   OBJECT_END + 0x036

//CONTAINER:
#define  CONTAINER_FIELD_NUM_SLOTS                                  ITEM_END + 0x000    //  Size:1  Type:Int32  Flags:1
#define  CONTAINER_ALIGN_PAD                                        ITEM_END + 0x001    //  Size:1  Type:Bytes  Flags:0
#define  CONTAINER_FIELD_SLOT_1                                     ITEM_END + 0x002    //  Size:72 Type:GUID   Flags:1
#define  CONTAINER_END                                              ITEM_END + 0x04A

//UNIT:
#define  UNIT_FIELD_CHARM                                           OBJECT_END + 0x000  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_SUMMON                                          OBJECT_END + 0x002  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_CHARMEDBY                                       OBJECT_END + 0x004  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_SUMMONEDBY                                      OBJECT_END + 0x006  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_CREATEDBY                                       OBJECT_END + 0x008  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_TARGET                                          OBJECT_END + 0x00A  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_PERSUADED                                       OBJECT_END + 0x00C  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_CHANNEL_OBJECT                                  OBJECT_END + 0x00E  //  Size:2  Type:GUID   Flags:1
#define  UNIT_FIELD_HEALTH                                          OBJECT_END + 0x010  //  Size:1  Type:Int32  Flags:256
#define  UNIT_FIELD_POWER1                                          OBJECT_END + 0x011  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_POWER2                                          OBJECT_END + 0x012  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_POWER3                                          OBJECT_END + 0x013  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_POWER4                                          OBJECT_END + 0x014  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_POWER5                                          OBJECT_END + 0x015  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MAXHEALTH                                       OBJECT_END + 0x016  //  Size:1  Type:Int32  Flags:256
#define  UNIT_FIELD_MAXPOWER1                                       OBJECT_END + 0x017  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MAXPOWER2                                       OBJECT_END + 0x018  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MAXPOWER3                                       OBJECT_END + 0x019  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MAXPOWER4                                       OBJECT_END + 0x01A  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MAXPOWER5                                       OBJECT_END + 0x01B  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_LEVEL                                           OBJECT_END + 0x01C  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_FACTIONTEMPLATE                                 OBJECT_END + 0x01D  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_BYTES_0                                         OBJECT_END + 0x01E  //  Size:1  Type:Bytes  Flags:1
#define  UNIT_VIRTUAL_ITEM_SLOT_DISPLAY                             OBJECT_END + 0x01F  //  Size:3  Type:Int32  Flags:1
#define  UNIT_VIRTUAL_ITEM_INFO                                     OBJECT_END + 0x022  //  Size:6  Type:Bytes  Flags:1
#define  UNIT_FIELD_FLAGS                                           OBJECT_END + 0x028  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_AURA                                            OBJECT_END + 0x029  //  Size:56 Type:Int32  Flags:1
#define  UNIT_FIELD_AURAFLAGS                                       OBJECT_END + 0x061  //  Size:7  Type:Bytes  Flags:1
#define  UNIT_FIELD_AURALEVELS                                      OBJECT_END + 0x068  //  Size:14 Type:Bytes  Flags:1
#define  UNIT_FIELD_AURAAPPLICATIONS                                OBJECT_END + 0x076  //  Size:14 Type:Bytes  Flags:1
#define  UNIT_FIELD_AURASTATE                                       OBJECT_END + 0x084  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_BASEATTACKTIME                                  OBJECT_END + 0x085  //  Size:2  Type:Int32  Flags:1
#define  UNIT_FIELD_RANGEDATTACKTIME                                OBJECT_END + 0x087  //  Size:1  Type:Int32  Flags:2
#define  UNIT_FIELD_BOUNDINGRADIUS                                  OBJECT_END + 0x088  //  Size:1  Type:Float  Flags:1
#define  UNIT_FIELD_COMBATREACH                                     OBJECT_END + 0x089  //  Size:1  Type:Float  Flags:1
#define  UNIT_FIELD_DISPLAYID                                       OBJECT_END + 0x08A  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_NATIVEDISPLAYID                                 OBJECT_END + 0x08B  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MOUNTDISPLAYID                                  OBJECT_END + 0x08C  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_MINDAMAGE                                       OBJECT_END + 0x08D  //  Size:1  Type:Float  Flags:38
#define  UNIT_FIELD_MAXDAMAGE                                       OBJECT_END + 0x08E  //  Size:1  Type:Float  Flags:38
#define  UNIT_FIELD_MINOFFHANDDAMAGE                                OBJECT_END + 0x08F  //  Size:1  Type:Float  Flags:38
#define  UNIT_FIELD_MAXOFFHANDDAMAGE                                OBJECT_END + 0x090  //  Size:1  Type:Float  Flags:38
#define  UNIT_FIELD_BYTES_1                                         OBJECT_END + 0x091  //  Size:1  Type:Bytes  Flags:1
#define  UNIT_FIELD_PETNUMBER                                       OBJECT_END + 0x092  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_PET_NAME_TIMESTAMP                              OBJECT_END + 0x093  //  Size:1  Type:Int32  Flags:1
#define  UNIT_FIELD_PETEXPERIENCE                                   OBJECT_END + 0x094  //  Size:1  Type:Int32  Flags:4
#define  UNIT_FIELD_PETNEXTLEVELEXP                                 OBJECT_END + 0x095  //  Size:1  Type:Int32  Flags:4
#define  UNIT_DYNAMIC_FLAGS                                         OBJECT_END + 0x096  //  Size:1  Type:Int32  Flags:256
#define  UNIT_CHANNEL_SPELL                                         OBJECT_END + 0x097  //  Size:1  Type:Int32  Flags:1
#define  UNIT_MOD_CAST_SPEED                                        OBJECT_END + 0x098  //  Size:1  Type:Float  Flags:1
#define  UNIT_CREATED_BY_SPELL                                      OBJECT_END + 0x099  //  Size:1  Type:Int32  Flags:1
#define  UNIT_NPC_FLAGS                                             OBJECT_END + 0x09A  //  Size:1  Type:Int32  Flags:1
#define  UNIT_NPC_EMOTESTATE                                        OBJECT_END + 0x09B  //  Size:1  Type:Int32  Flags:1
#define  UNIT_TRAINING_POINTS                                       OBJECT_END + 0x09C  //  Size:1  Type:Chars? Flags:4
#define  UNIT_FIELD_STAT0                                           OBJECT_END + 0x09D  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_STAT1                                           OBJECT_END + 0x09E  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_STAT2                                           OBJECT_END + 0x09F  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_STAT3                                           OBJECT_END + 0x0A0  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_STAT4                                           OBJECT_END + 0x0A1  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_RESISTANCES                                     OBJECT_END + 0x0A2  //  Size:7  Type:Int32  Flags:38
#define  UNIT_FIELD_BASE_MANA                                       OBJECT_END + 0x0A9  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_BASE_HEALTH                                     OBJECT_END + 0x0AA  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_BYTES_2                                         OBJECT_END + 0x0AB  //  Size:1  Type:Bytes  Flags:1
#define  UNIT_FIELD_ATTACK_POWER                                    OBJECT_END + 0x0AC  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_ATTACK_POWER_MODS                               OBJECT_END + 0x0AD  //  Size:1  Type:Chars? Flags:6
#define  UNIT_FIELD_ATTACK_POWER_MULTIPLIER                         OBJECT_END + 0x0AE  //  Size:1  Type:Float  Flags:6
#define  UNIT_FIELD_RANGED_ATTACK_POWER                             OBJECT_END + 0x0AF  //  Size:1  Type:Int32  Flags:6
#define  UNIT_FIELD_RANGED_ATTACK_POWER_MODS                        OBJECT_END + 0x0B0  //  Size:1  Type:Chars? Flags:6
#define  UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER                  OBJECT_END + 0x0B1  //  Size:1  Type:Float  Flags:6
#define  UNIT_FIELD_MINRANGEDDAMAGE                                 OBJECT_END + 0x0B2  //  Size:1  Type:Float  Flags:6
#define  UNIT_FIELD_MAXRANGEDDAMAGE                                 OBJECT_END + 0x0B3  //  Size:1  Type:Float  Flags:6
#define  UNIT_FIELD_POWER_COST_MODIFIER                             OBJECT_END + 0x0B4  //  Size:7  Type:Int32  Flags:6
#define  UNIT_FIELD_POWER_COST_MULTIPLIER                           OBJECT_END + 0x0BB  //  Size:7  Type:Float  Flags:6
#define  UNIT_END                                                   OBJECT_END + 0x0C2

//PLAYER:
#define  PLAYER_DUEL_ARBITER                                        UNIT_END + 0x000    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_FLAGS                                               UNIT_END + 0x002    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_GUILDID                                             UNIT_END + 0x003    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_GUILDRANK                                           UNIT_END + 0x004    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_BYTES                                               UNIT_END + 0x005    //  Size:1  Type:Bytes  Flags:1
#define  PLAYER_BYTES_2                                             UNIT_END + 0x006    //  Size:1  Type:Bytes  Flags:1
#define  PLAYER_BYTES_3                                             UNIT_END + 0x007    //  Size:1  Type:Bytes  Flags:1
#define  PLAYER_DUEL_TEAM                                           UNIT_END + 0x008    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_GUILD_TIMESTAMP                                     UNIT_END + 0x009    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_QUEST_LOG_1_1                                       UNIT_END + 0x00A    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_1_2                                       UNIT_END + 0x00B    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_2_1                                       UNIT_END + 0x00D    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_2_2                                       UNIT_END + 0x00E    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_3_1                                       UNIT_END + 0x010    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_3_2                                       UNIT_END + 0x011    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_4_1                                       UNIT_END + 0x013    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_4_2                                       UNIT_END + 0x014    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_5_1                                       UNIT_END + 0x016    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_5_2                                       UNIT_END + 0x017    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_6_1                                       UNIT_END + 0x019    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_6_2                                       UNIT_END + 0x01A    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_7_1                                       UNIT_END + 0x01C    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_7_2                                       UNIT_END + 0x01D    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_8_1                                       UNIT_END + 0x01F    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_8_2                                       UNIT_END + 0x020    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_9_1                                       UNIT_END + 0x022    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_9_2                                       UNIT_END + 0x023    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_10_1                                      UNIT_END + 0x025    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_10_2                                      UNIT_END + 0x026    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_11_1                                      UNIT_END + 0x028    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_11_2                                      UNIT_END + 0x029    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_12_1                                      UNIT_END + 0x02B    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_12_2                                      UNIT_END + 0x02C    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_13_1                                      UNIT_END + 0x02E    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_13_2                                      UNIT_END + 0x02F    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_14_1                                      UNIT_END + 0x031    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_14_2                                      UNIT_END + 0x032    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_15_1                                      UNIT_END + 0x034    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_15_2                                      UNIT_END + 0x035    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_16_1                                      UNIT_END + 0x037    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_16_2                                      UNIT_END + 0x038    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_17_1                                      UNIT_END + 0x03A    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_17_2                                      UNIT_END + 0x03B    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_18_1                                      UNIT_END + 0x03D    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_18_2                                      UNIT_END + 0x03E    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_19_1                                      UNIT_END + 0x040    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_19_2                                      UNIT_END + 0x041    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_20_1                                      UNIT_END + 0x043    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_20_2                                      UNIT_END + 0x044    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_21_1                                      UNIT_END + 0x046    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_21_2                                      UNIT_END + 0x047    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_22_1                                      UNIT_END + 0x049    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_22_2                                      UNIT_END + 0x04A    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_23_1                                      UNIT_END + 0x04C    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_23_2                                      UNIT_END + 0x04D    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_24_1                                      UNIT_END + 0x04F    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_24_2                                      UNIT_END + 0x050    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_QUEST_LOG_25_1                                      UNIT_END + 0x052    //  Size:1  Type:Int32  Flags:64
#define  PLAYER_QUEST_LOG_25_2                                      UNIT_END + 0x053    //  Size:2  Type:Int32  Flags:2
#define  PLAYER_VISIBLE_ITEM_1_CREATOR                              UNIT_END + 0x055    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_1_0                                    UNIT_END + 0x057    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_1_PROPERTIES                           UNIT_END + 0x063    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_1_PAD                                  UNIT_END + 0x064    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_2_CREATOR                              UNIT_END + 0x065    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_2_0                                    UNIT_END + 0x067    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_2_PROPERTIES                           UNIT_END + 0x073    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_2_PAD                                  UNIT_END + 0x074    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_3_CREATOR                              UNIT_END + 0x075    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_3_0                                    UNIT_END + 0x077    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_3_PROPERTIES                           UNIT_END + 0x083    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_3_PAD                                  UNIT_END + 0x084    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_4_CREATOR                              UNIT_END + 0x085    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_4_0                                    UNIT_END + 0x087    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_4_PROPERTIES                           UNIT_END + 0x093    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_4_PAD                                  UNIT_END + 0x094    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_5_CREATOR                              UNIT_END + 0x095    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_5_0                                    UNIT_END + 0x097    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_5_PROPERTIES                           UNIT_END + 0x0A3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_5_PAD                                  UNIT_END + 0x0A4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_6_CREATOR                              UNIT_END + 0x0A5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_6_0                                    UNIT_END + 0x0A7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_6_PROPERTIES                           UNIT_END + 0x0B3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_6_PAD                                  UNIT_END + 0x0B4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_7_CREATOR                              UNIT_END + 0x0B5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_7_0                                    UNIT_END + 0x0B7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_7_PROPERTIES                           UNIT_END + 0x0C3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_7_PAD                                  UNIT_END + 0x0C4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_8_CREATOR                              UNIT_END + 0x0C5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_8_0                                    UNIT_END + 0x0C7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_8_PROPERTIES                           UNIT_END + 0x0D3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_8_PAD                                  UNIT_END + 0x0D4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_9_CREATOR                              UNIT_END + 0x0D5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_9_0                                    UNIT_END + 0x0D7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_9_PROPERTIES                           UNIT_END + 0x0E3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_9_PAD                                  UNIT_END + 0x0E4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_10_CREATOR                             UNIT_END + 0x0E5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_10_0                                   UNIT_END + 0x0E7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_10_PROPERTIES                          UNIT_END + 0x0F3    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_10_PAD                                 UNIT_END + 0x0F4    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_11_CREATOR                             UNIT_END + 0x0F5    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_11_0                                   UNIT_END + 0x0F7    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_11_PROPERTIES                          UNIT_END + 0x103    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_11_PAD                                 UNIT_END + 0x104    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_12_CREATOR                             UNIT_END + 0x105    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_12_0                                   UNIT_END + 0x107    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_12_PROPERTIES                          UNIT_END + 0x113    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_12_PAD                                 UNIT_END + 0x114    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_13_CREATOR                             UNIT_END + 0x115    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_13_0                                   UNIT_END + 0x117    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_13_PROPERTIES                          UNIT_END + 0x123    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_13_PAD                                 UNIT_END + 0x124    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_14_CREATOR                             UNIT_END + 0x125    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_14_0                                   UNIT_END + 0x127    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_14_PROPERTIES                          UNIT_END + 0x133    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_14_PAD                                 UNIT_END + 0x134    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_15_CREATOR                             UNIT_END + 0x135    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_15_0                                   UNIT_END + 0x137    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_15_PROPERTIES                          UNIT_END + 0x143    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_15_PAD                                 UNIT_END + 0x144    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_16_CREATOR                             UNIT_END + 0x145    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_16_0                                   UNIT_END + 0x147    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_16_PROPERTIES                          UNIT_END + 0x153    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_16_PAD                                 UNIT_END + 0x154    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_17_CREATOR                             UNIT_END + 0x155    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_17_0                                   UNIT_END + 0x157    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_17_PROPERTIES                          UNIT_END + 0x163    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_17_PAD                                 UNIT_END + 0x164    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_18_CREATOR                             UNIT_END + 0x165    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_18_0                                   UNIT_END + 0x167    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_18_PROPERTIES                          UNIT_END + 0x173    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_18_PAD                                 UNIT_END + 0x174    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_19_CREATOR                             UNIT_END + 0x175    //  Size:2  Type:GUID   Flags:1
#define  PLAYER_VISIBLE_ITEM_19_0                                   UNIT_END + 0x177    //  Size:12 Type:Int32  Flags:1
#define  PLAYER_VISIBLE_ITEM_19_PROPERTIES                          UNIT_END + 0x183    //  Size:1  Type:Chars? Flags:1
#define  PLAYER_VISIBLE_ITEM_19_PAD                                 UNIT_END + 0x184    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_CHOSEN_TITLE                                        UNIT_END + 0x185    //  Size:1  Type:Int32  Flags:1
#define  PLAYER_FIELD_INV_SLOT_HEAD                                 UNIT_END + 0x186    //  Size:46 Type:GUID   Flags:2
#define  PLAYER_FIELD_PACK_SLOT_1                                   UNIT_END + 0x1B4    //  Size:32 Type:GUID   Flags:2
#define  PLAYER_FIELD_BANK_SLOT_1                                   UNIT_END + 0x1D4    //  Size:56 Type:GUID   Flags:2
#define  PLAYER_FIELD_BANKBAG_SLOT_1                                UNIT_END + 0x204    //  Size:14 Type:GUID   Flags:2
#define  PLAYER_FIELD_VENDORBUYBACK_SLOT_1                          UNIT_END + 0x21A    //  Size:24 Type:GUID   Flags:2
#define  PLAYER_FIELD_KEYRING_SLOT_1                                UNIT_END + 0x232    //  Size:64 Type:GUID   Flags:2
#define  PLAYER_FARSIGHT                                            UNIT_END + 0x272    //  Size:2  Type:GUID   Flags:2
#define  PLAYER__FIELD_COMBO_TARGET                                 UNIT_END + 0x274    //  Size:2  Type:GUID   Flags:2
#define  PLAYER__FIELD_KNOWN_TITLES                                 UNIT_END + 0x276    //  Size:2  Type:GUID   Flags:2
#define  PLAYER_XP                                                  UNIT_END + 0x278    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_NEXT_LEVEL_XP                                       UNIT_END + 0x279    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_SKILL_INFO_1_1                                      UNIT_END + 0x27A    //  Size:384    Type:Chars? Flags:2
#define  PLAYER_CHARACTER_POINTS1                                   UNIT_END + 0x3FA    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_CHARACTER_POINTS2                                   UNIT_END + 0x3FB    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_TRACK_CREATURES                                     UNIT_END + 0x3FC    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_TRACK_RESOURCES                                     UNIT_END + 0x3FD    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_BLOCK_PERCENTAGE                                    UNIT_END + 0x3FE    //  Size:1  Type:Float  Flags:2
#define  PLAYER_DODGE_PERCENTAGE                                    UNIT_END + 0x3FF    //  Size:1  Type:Float  Flags:2
#define  PLAYER_PARRY_PERCENTAGE                                    UNIT_END + 0x400    //  Size:1  Type:Float  Flags:2
#define  PLAYER_CRIT_PERCENTAGE                                     UNIT_END + 0x401    //  Size:1  Type:Float  Flags:2
#define  PLAYER_RANGED_CRIT_PERCENTAGE                              UNIT_END + 0x402    //  Size:1  Type:Float  Flags:2
#define  PLAYER_SPELL_CRIT_PERCENTAGE1                              UNIT_END + 0x403    //  Size:7  Type:Float  Flags:2
#define  PLAYER_EXPLORED_ZONES_1                                    UNIT_END + 0x40A    //  Size:64 Type:Bytes  Flags:2
#define  PLAYER_REST_STATE_EXPERIENCE                               UNIT_END + 0x44A    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_COINAGE                                       UNIT_END + 0x44B    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_POSSTAT0                                      UNIT_END + 0x44C    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_POSSTAT1                                      UNIT_END + 0x44D    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_POSSTAT2                                      UNIT_END + 0x44E    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_POSSTAT3                                      UNIT_END + 0x44F    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_POSSTAT4                                      UNIT_END + 0x450    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_NEGSTAT0                                      UNIT_END + 0x451    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_NEGSTAT1                                      UNIT_END + 0x452    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_NEGSTAT2                                      UNIT_END + 0x453    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_NEGSTAT3                                      UNIT_END + 0x454    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_NEGSTAT4                                      UNIT_END + 0x455    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE                    UNIT_END + 0x456    //  Size:7  Type:Int32  Flags:2
#define  PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE                    UNIT_END + 0x45D    //  Size:7  Type:Int32  Flags:2
#define  PLAYER_FIELD_MOD_DAMAGE_DONE_POS                           UNIT_END + 0x464    //  Size:7  Type:Int32  Flags:2
#define  PLAYER_FIELD_MOD_DAMAGE_DONE_NEG                           UNIT_END + 0x46B    //  Size:7  Type:Int32  Flags:2
#define  PLAYER_FIELD_MOD_DAMAGE_DONE_PCT                           UNIT_END + 0x472    //  Size:7  Type:Int32  Flags:2
#define  PLAYER_FIELD_MOD_HEALING_DONE_POS                          UNIT_END + 0x479    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_MOD_TARGET_RESISTANCE                         UNIT_END + 0x47A    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_BYTES                                         UNIT_END + 0x47B    //  Size:1  Type:Bytes  Flags:2
#define  PLAYER_AMMO_ID                                             UNIT_END + 0x47C    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_SELF_RES_SPELL                                      UNIT_END + 0x47D    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_PVP_MEDALS                                    UNIT_END + 0x47E    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_BUYBACK_PRICE_1                               UNIT_END + 0x47F    //  Size:12 Type:Int32  Flags:2
#define  PLAYER_FIELD_BUYBACK_TIMESTAMP_1                           UNIT_END + 0x48B    //  Size:12 Type:Int32  Flags:2
#define  PLAYER_FIELD_SESSION_KILLS                                 UNIT_END + 0x497    //  Size:1  Type:Chars? Flags:2
#define  PLAYER_FIELD_YESTERDAY_KILLS                               UNIT_END + 0x498    //  Size:1  Type:Chars? Flags:2
#define  PLAYER_FIELD_LAST_WEEK_KILLS                               UNIT_END + 0x499    //  Size:1  Type:Chars? Flags:2
#define  PLAYER_FIELD_THIS_WEEK_KILLS                               UNIT_END + 0x49A    //  Size:1  Type:Chars? Flags:2
#define  PLAYER_FIELD_THIS_WEEK_CONTRIBUTION                        UNIT_END + 0x49B    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_LIFETIME_HONORABLE_KILLS                      UNIT_END + 0x49C    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_LIFETIME_DISHONORABLE_KILLS                   UNIT_END + 0x49D    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_YESTERDAY_CONTRIBUTION                        UNIT_END + 0x49E    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_LAST_WEEK_CONTRIBUTION                        UNIT_END + 0x49F    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_LAST_WEEK_RANK                                UNIT_END + 0x4A0    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_BYTES2                                        UNIT_END + 0x4A1    //  Size:1  Type:Bytes  Flags:2
#define  PLAYER_FIELD_WATCHED_FACTION_INDEX                         UNIT_END + 0x4A2    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_COMBAT_RATING_1                               UNIT_END + 0x4A3    //  Size:20 Type:Int32  Flags:2
#define  PLAYER_FIELD_ARENA_TEAM_INFO_1_1                           UNIT_END + 0x4B7    //  Size:9  Type:Int32  Flags:2
#define  PLAYER_FIELD_HONOR_CURRENCY                                UNIT_END + 0x4C0    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_FIELD_ARENA_CURRENCY                                UNIT_END + 0x4C1    //  Size:1  Type:Int32  Flags:2
#define  PLAYER_END                                                 UNIT_END + 0x4C2

//OBJECT:
#define  OBJECT_FIELD_CREATED_BY                                    OBJECT_END + 0x000  //  Size:2  Type:GUID   Flags:1

//GAMEOBJECT:
#define  GAMEOBJECT_DISPLAYID                                       OBJECT_END + 0x002  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_FLAGS                                           OBJECT_END + 0x003  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_ROTATION                                        OBJECT_END + 0x004  //  Size:4  Type:Float  Flags:1
#define  GAMEOBJECT_STATE                                           OBJECT_END + 0x008  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_POS_X                                           OBJECT_END + 0x009  //  Size:1  Type:Float  Flags:1
#define  GAMEOBJECT_POS_Y                                           OBJECT_END + 0x00A  //  Size:1  Type:Float  Flags:1
#define  GAMEOBJECT_POS_Z                                           OBJECT_END + 0x00B  //  Size:1  Type:Float  Flags:1
#define  GAMEOBJECT_FACING                                          OBJECT_END + 0x00C  //  Size:1  Type:Float  Flags:1
#define  GAMEOBJECT_DYN_FLAGS                                       OBJECT_END + 0x00D  //  Size:1  Type:Int32  Flags:256
#define  GAMEOBJECT_FACTION                                         OBJECT_END + 0x00E  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_TYPE_ID                                         OBJECT_END + 0x00F  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_LEVEL                                           OBJECT_END + 0x010  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_ARTKIT                                          OBJECT_END + 0x011  //  Size:1  Type:Int32  Flags:1
#define  GAMEOBJECT_ANIMPROGRESS                                    OBJECT_END + 0x012  //  Size:1  Type:Int32  Flags:256
#define  GAMEOBJECT_PADDING                                         OBJECT_END + 0x013  //  Size:1  Type:Int32  Flags:0
#define  GAMEOBJECT_END                                             OBJECT_END + 0x014

//DYNAMICOBJECT:
#define  DYNAMICOBJECT_CASTER                                       OBJECT_END + 0x000  //  Size:2  Type:GUID   Flags:1
#define  DYNAMICOBJECT_BYTES                                        OBJECT_END + 0x002  //  Size:1  Type:Bytes  Flags:1
#define  DYNAMICOBJECT_SPELLID                                      OBJECT_END + 0x003  //  Size:1  Type:Int32  Flags:1
#define  DYNAMICOBJECT_RADIUS                                       OBJECT_END + 0x004  //  Size:1  Type:Float  Flags:1
#define  DYNAMICOBJECT_POS_X                                        OBJECT_END + 0x005  //  Size:1  Type:Float  Flags:1
#define  DYNAMICOBJECT_POS_Y                                        OBJECT_END + 0x006  //  Size:1  Type:Float  Flags:1
#define  DYNAMICOBJECT_POS_Z                                        OBJECT_END + 0x007  //  Size:1  Type:Float  Flags:1
#define  DYNAMICOBJECT_FACING                                       OBJECT_END + 0x008  //  Size:1  Type:Float  Flags:1
#define  DYNAMICOBJECT_PAD                                          OBJECT_END + 0x009  //  Size:1  Type:Bytes  Flags:1
#define  DYNAMICOBJECT_END                                          OBJECT_END + 0x00A

//CORPSE:
#define  CORPSE_FIELD_OWNER                                         OBJECT_END + 0x000  //  Size:2  Type:GUID   Flags:1
#define  CORPSE_FIELD_FACING                                        OBJECT_END + 0x002  //  Size:1  Type:Float  Flags:1
#define  CORPSE_FIELD_POS_X                                         OBJECT_END + 0x003  //  Size:1  Type:Float  Flags:1
#define  CORPSE_FIELD_POS_Y                                         OBJECT_END + 0x004  //  Size:1  Type:Float  Flags:1
#define  CORPSE_FIELD_POS_Z                                         OBJECT_END + 0x005  //  Size:1  Type:Float  Flags:1
#define  CORPSE_FIELD_DISPLAY_ID                                    OBJECT_END + 0x006  //  Size:1  Type:Int32  Flags:1
#define  CORPSE_FIELD_ITEM                                          OBJECT_END + 0x007  //  Size:19 Type:Int32  Flags:1
#define  CORPSE_FIELD_BYTES_1                                       OBJECT_END + 0x01A  //  Size:1  Type:Bytes  Flags:1
#define  CORPSE_FIELD_BYTES_2                                       OBJECT_END + 0x01B  //  Size:1  Type:Bytes  Flags:1
#define  CORPSE_FIELD_GUILD                                         OBJECT_END + 0x01C  //  Size:1  Type:Int32  Flags:1
#define  CORPSE_FIELD_FLAGS                                         OBJECT_END + 0x01D  //  Size:1  Type:Int32  Flags:1
#define  CORPSE_FIELD_DYNAMIC_FLAGS                                 OBJECT_END + 0x01E  //  Size:1  Type:Int32  Flags:256
#define  CORPSE_FIELD_PAD                                           OBJECT_END + 0x01F  //  Size:1  Type:Int32  Flags:0
#define  CORPSE_END                                                 OBJECT_END + 0x020


#else



// 'OBJECT' object type update fields
#define   OBJECT_FIELD_GUID                             0x0000 // Size: 2, Type: guid
#define   OBJECT_FIELD_TYPE                             0x0002 // Size: 1, Type: uint32
#define   OBJECT_FIELD_ENTRY                            0x0003 // Size: 1, Type: uint32
#define   OBJECT_FIELD_SCALE_X                          0x0004 // Size: 1, Type: float
#define   OBJECT_FIELD_PADDING                          0x0005 // Size: 1, Type: uint32
#define   OBJECT_END                                    OBJECT_FIELD_PADDING + 1


// 'ITEM' object type update fields
#define   ITEM_FIELD_OWNER                              OBJECT_END + 0x0000 // Size: 2, Type: guid
#define   ITEM_FIELD_CONTAINED                          OBJECT_END + 0x0002 // Size: 2, Type: guid
#define   ITEM_FIELD_CREATOR                            OBJECT_END + 0x0004 // Size: 2, Type: guid
#define   ITEM_FIELD_GIFTCREATOR                        OBJECT_END + 0x0006 // Size: 2, Type: guid
#define   ITEM_FIELD_STACK_COUNT                        OBJECT_END + 0x0008 // Size: 1, Type: uint32
#define   ITEM_FIELD_DURATION                           OBJECT_END + 0x0009 // Size: 1, Type: uint32
#define   ITEM_FIELD_SPELL_CHARGES                      OBJECT_END + 0x000A // Size: 5, Type: uint32
#define   ITEM_FIELD_FLAGS                              OBJECT_END + 0x000F // Size: 1, Type: uint32
#define   ITEM_FIELD_ENCHANTMENT                        OBJECT_END + 0x0010 // Size: 33, Type: uint32
#define   ITEM_FIELD_PROPERTY_SEED                      OBJECT_END + 0x0031 // Size: 1, Type: uint32
#define   ITEM_FIELD_RANDOM_PROPERTIES_ID               OBJECT_END + 0x0032 // Size: 1, Type: uint32
#define   ITEM_FIELD_ITEM_TEXT_ID                       OBJECT_END + 0x0033 // Size: 1, Type: uint32
#define   ITEM_FIELD_DURABILITY                         OBJECT_END + 0x0034 // Size: 1, Type: uint32
#define   ITEM_FIELD_MAXDURABILITY                      OBJECT_END + 0x0035 // Size: 1, Type: uint32
#define   ITEM_END                                      ITEM_FIELD_MAXDURABILITY + 1


// 'CONTAINER' object type update fields
#define   CONTAINER_FIELD_NUM_SLOTS                     ITEM_END + 0x0000 // Size: 1, Type: uint32
#define   CONTAINER_ALIGN_PAD                           ITEM_END + 0x0001 // Size: 1, Type: bytes
#define   CONTAINER_FIELD_SLOT_1                        ITEM_END + 0x0002 // Size: 72, Type: guid
#define   CONTAINER_END                                 CONTAINER_FIELD_SLOT_1 + 72


// 'UNIT' object type update fields
#define   UNIT_FIELD_CHARM                              OBJECT_END + 0x0000 // Size: 2, Type: guid
#define   UNIT_FIELD_SUMMON                             OBJECT_END + 0x0002 // Size: 2, Type: guid
#define   UNIT_FIELD_CHARMEDBY                          OBJECT_END + 0x0004 // Size: 2, Type: guid
#define   UNIT_FIELD_SUMMONEDBY                         OBJECT_END + 0x0006 // Size: 2, Type: guid
#define   UNIT_FIELD_CREATEDBY                          OBJECT_END + 0x0008 // Size: 2, Type: guid
#define   UNIT_FIELD_TARGET                             OBJECT_END + 0x000A // Size: 2, Type: guid
#define   UNIT_FIELD_PERSUADED                          OBJECT_END + 0x000C // Size: 2, Type: guid
#define   UNIT_FIELD_CHANNEL_OBJECT                     OBJECT_END + 0x000E // Size: 2, Type: guid
#define   UNIT_FIELD_HEALTH                             OBJECT_END + 0x0010 // Size: 1, Type: uint32
#define   UNIT_FIELD_POWER1                             OBJECT_END + 0x0011 // Size: 1, Type: uint32
#define   UNIT_FIELD_POWER2                             OBJECT_END + 0x0012 // Size: 1, Type: uint32
#define   UNIT_FIELD_POWER3                             OBJECT_END + 0x0013 // Size: 1, Type: uint32
#define   UNIT_FIELD_POWER4                             OBJECT_END + 0x0014 // Size: 1, Type: uint32
#define   UNIT_FIELD_POWER5                             OBJECT_END + 0x0015 // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXHEALTH                          OBJECT_END + 0x0016 // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXPOWER1                          OBJECT_END + 0x0017 // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXPOWER2                          OBJECT_END + 0x0018 // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXPOWER3                          OBJECT_END + 0x0019 // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXPOWER4                          OBJECT_END + 0x001A // Size: 1, Type: uint32
#define   UNIT_FIELD_MAXPOWER5                          OBJECT_END + 0x001B // Size: 1, Type: uint32
#define   UNIT_FIELD_LEVEL                              OBJECT_END + 0x001C // Size: 1, Type: uint32
#define   UNIT_FIELD_FACTIONTEMPLATE                    OBJECT_END + 0x001D // Size: 1, Type: uint32
#define   UNIT_FIELD_BYTES_0                            OBJECT_END + 0x001E // Size: 1, Type: bytes
#define   UNIT_VIRTUAL_ITEM_SLOT_DISPLAY                OBJECT_END + 0x001F // Size: 3, Type: uint32
#define   UNIT_VIRTUAL_ITEM_INFO                        OBJECT_END + 0x0022 // Size: 6, Type: bytes
#define   UNIT_FIELD_FLAGS                              OBJECT_END + 0x0028 // Size: 1, Type: uint32
#define   UNIT_FIELD_AURA                               OBJECT_END + 0x0029 // Size: 56, Type: uint32
#define   UNIT_FIELD_AURAFLAGS                          OBJECT_END + 0x0061 // Size: 7, Type: bytes
#define   UNIT_FIELD_AURALEVELS                         OBJECT_END + 0x0068 // Size: 14, Type: bytes
#define   UNIT_FIELD_AURAAPPLICATIONS                   OBJECT_END + 0x0076 // Size: 14, Type: bytes
#define   UNIT_FIELD_AURASTATE                          OBJECT_END + 0x0084 // Size: 1, Type: uint32
#define   UNIT_FIELD_BASEATTACKTIME                     OBJECT_END + 0x0085 // Size: 2, Type: uint32
#define   UNIT_FIELD_RANGEDATTACKTIME                   OBJECT_END + 0x0087 // Size: 1, Type: uint32
#define   UNIT_FIELD_BOUNDINGRADIUS                     OBJECT_END + 0x0088 // Size: 1, Type: float
#define   UNIT_FIELD_COMBATREACH                        OBJECT_END + 0x0089 // Size: 1, Type: float
#define   UNIT_FIELD_DISPLAYID                          OBJECT_END + 0x008A // Size: 1, Type: uint32
#define   UNIT_FIELD_NATIVEDISPLAYID                    OBJECT_END + 0x008B // Size: 1, Type: uint32
#define   UNIT_FIELD_MOUNTDISPLAYID                     OBJECT_END + 0x008C // Size: 1, Type: uint32
#define   UNIT_FIELD_MINDAMAGE                          OBJECT_END + 0x008D // Size: 1, Type: float
#define   UNIT_FIELD_MAXDAMAGE                          OBJECT_END + 0x008E // Size: 1, Type: float
#define   UNIT_FIELD_MINOFFHANDDAMAGE                   OBJECT_END + 0x008F // Size: 1, Type: float
#define   UNIT_FIELD_MAXOFFHANDDAMAGE                   OBJECT_END + 0x0090 // Size: 1, Type: float
#define   UNIT_FIELD_BYTES_1                            OBJECT_END + 0x0091 // Size: 1, Type: bytes
#define   UNIT_FIELD_PETNUMBER                          OBJECT_END + 0x0092 // Size: 1, Type: uint32
#define   UNIT_FIELD_PET_NAME_TIMESTAMP                 OBJECT_END + 0x0093 // Size: 1, Type: uint32
#define   UNIT_FIELD_PETEXPERIENCE                      OBJECT_END + 0x0094 // Size: 1, Type: uint32
#define   UNIT_FIELD_PETNEXTLEVELEXP                    OBJECT_END + 0x0095 // Size: 1, Type: uint32
#define   UNIT_DYNAMIC_FLAGS                            OBJECT_END + 0x0096 // Size: 1, Type: uint32
#define   UNIT_CHANNEL_SPELL                            OBJECT_END + 0x0097 // Size: 1, Type: uint32
#define   UNIT_MOD_CAST_SPEED                           OBJECT_END + 0x0098 // Size: 1, Type: float
#define   UNIT_CREATED_BY_SPELL                         OBJECT_END + 0x0099 // Size: 1, Type: uint32
#define   UNIT_NPC_FLAGS                                OBJECT_END + 0x009A // Size: 1, Type: uint32
#define   UNIT_NPC_EMOTESTATE                           OBJECT_END + 0x009B // Size: 1, Type: uint32
#define   UNIT_TRAINING_POINTS                          OBJECT_END + 0x009C // Size: 1, Type: bytes
#define   UNIT_FIELD_STAT0                              OBJECT_END + 0x009D // Size: 1, Type: uint32
#define   UNIT_FIELD_STAT1                              OBJECT_END + 0x009E // Size: 1, Type: uint32
#define   UNIT_FIELD_STAT2                              OBJECT_END + 0x009F // Size: 1, Type: uint32
#define   UNIT_FIELD_STAT3                              OBJECT_END + 0x00A0 // Size: 1, Type: uint32
#define   UNIT_FIELD_STAT4                              OBJECT_END + 0x00A1 // Size: 1, Type: uint32
#define   UNIT_FIELD_RESISTANCES                        OBJECT_END + 0x00A2 // Size: 7, Type: uint32
#define   UNIT_FIELD_BASE_MANA                          OBJECT_END + 0x00A9 // Size: 1, Type: uint32
#define   UNIT_FIELD_BASE_HEALTH                        OBJECT_END + 0x00AA // Size: 1, Type: uint32
#define   UNIT_FIELD_BYTES_2                            OBJECT_END + 0x00AB // Size: 1, Type: bytes
#define   UNIT_FIELD_ATTACK_POWER                       OBJECT_END + 0x00AC // Size: 1, Type: uint32
#define   UNIT_FIELD_ATTACK_POWER_MODS                  OBJECT_END + 0x00AD // Size: 1, Type: bytes
#define   UNIT_FIELD_ATTACK_POWER_MULTIPLIER            OBJECT_END + 0x00AE // Size: 1, Type: float
#define   UNIT_FIELD_RANGED_ATTACK_POWER                OBJECT_END + 0x00AF // Size: 1, Type: uint32
#define   UNIT_FIELD_RANGED_ATTACK_POWER_MODS           OBJECT_END + 0x00B0 // Size: 1, Type: bytes
#define   UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER     OBJECT_END + 0x00B1 // Size: 1, Type: float
#define   UNIT_FIELD_MINRANGEDDAMAGE                    OBJECT_END + 0x00B2 // Size: 1, Type: float
#define   UNIT_FIELD_MAXRANGEDDAMAGE                    OBJECT_END + 0x00B3 // Size: 1, Type: float
#define   UNIT_FIELD_POWER_COST_MODIFIER                OBJECT_END + 0x00B4 // Size: 7, Type: uint32
#define   UNIT_FIELD_POWER_COST_MULTIPLIER              OBJECT_END + 0x00BB // Size: 7, Type: float
#define   UNIT_END                                      UNIT_FIELD_POWER_COST_MULTIPLIER + 7


// 'PLAYER' object type update fields
#define   PLAYER_DUEL_ARBITER                           UNIT_END + 0x0000 // Size: 2, Type: guid
#define   PLAYER_FLAGS                                  UNIT_END + 0x0002 // Size: 1, Type: uint32
#define   PLAYER_GUILDID                                UNIT_END + 0x0003 // Size: 1, Type: uint32
#define   PLAYER_GUILDRANK                              UNIT_END + 0x0004 // Size: 1, Type: uint32
#define   PLAYER_BYTES                                  UNIT_END + 0x0005 // Size: 1, Type: bytes
#define   PLAYER_BYTES_2                                UNIT_END + 0x0006 // Size: 1, Type: bytes
#define   PLAYER_BYTES_3                                UNIT_END + 0x0007 // Size: 1, Type: bytes
#define   PLAYER_DUEL_TEAM                              UNIT_END + 0x0008 // Size: 1, Type: uint32
#define   PLAYER_GUILD_TIMESTAMP                        UNIT_END + 0x0009 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_1_1                          UNIT_END + 0x000A // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_1_2                          UNIT_END + 0x000B // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_2_1                          UNIT_END + 0x000D // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_2_2                          UNIT_END + 0x000E // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_3_1                          UNIT_END + 0x0010 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_3_2                          UNIT_END + 0x0011 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_4_1                          UNIT_END + 0x0013 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_4_2                          UNIT_END + 0x0014 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_5_1                          UNIT_END + 0x0016 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_5_2                          UNIT_END + 0x0017 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_6_1                          UNIT_END + 0x0019 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_6_2                          UNIT_END + 0x001A // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_7_1                          UNIT_END + 0x001C // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_7_2                          UNIT_END + 0x001D // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_8_1                          UNIT_END + 0x001F // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_8_2                          UNIT_END + 0x0020 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_9_1                          UNIT_END + 0x0022 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_9_2                          UNIT_END + 0x0023 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_10_1                         UNIT_END + 0x0025 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_10_2                         UNIT_END + 0x0026 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_11_1                         UNIT_END + 0x0028 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_11_2                         UNIT_END + 0x0029 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_12_1                         UNIT_END + 0x002B // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_12_2                         UNIT_END + 0x002C // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_13_1                         UNIT_END + 0x002E // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_13_2                         UNIT_END + 0x002F // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_14_1                         UNIT_END + 0x0031 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_14_2                         UNIT_END + 0x0032 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_15_1                         UNIT_END + 0x0034 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_15_2                         UNIT_END + 0x0035 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_16_1                         UNIT_END + 0x0037 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_16_2                         UNIT_END + 0x0038 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_17_1                         UNIT_END + 0x003A // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_17_2                         UNIT_END + 0x003B // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_18_1                         UNIT_END + 0x003D // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_18_2                         UNIT_END + 0x003E // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_19_1                         UNIT_END + 0x0040 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_19_2                         UNIT_END + 0x0041 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_20_1                         UNIT_END + 0x0043 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_20_2                         UNIT_END + 0x0044 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_21_1                         UNIT_END + 0x0046 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_21_2                         UNIT_END + 0x0047 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_22_1                         UNIT_END + 0x0049 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_22_2                         UNIT_END + 0x004A // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_23_1                         UNIT_END + 0x004C // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_23_2                         UNIT_END + 0x004D // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_24_1                         UNIT_END + 0x004F // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_24_2                         UNIT_END + 0x0050 // Size: 2, Type: uint32
#define   PLAYER_QUEST_LOG_25_1                         UNIT_END + 0x0052 // Size: 1, Type: uint32
#define   PLAYER_QUEST_LOG_25_2                         UNIT_END + 0x0053 // Size: 2, Type: uint32
#define   PLAYER_VISIBLE_ITEM_1_CREATOR                 UNIT_END + 0x0055 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_1_0                       UNIT_END + 0x0057 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_1_PROPERTIES              UNIT_END + 0x0063 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_1_PAD                     UNIT_END + 0x0064 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_2_CREATOR                 UNIT_END + 0x0065 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_2_0                       UNIT_END + 0x0067 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_2_PROPERTIES              UNIT_END + 0x0073 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_2_PAD                     UNIT_END + 0x0074 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_3_CREATOR                 UNIT_END + 0x0075 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_3_0                       UNIT_END + 0x0077 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_3_PROPERTIES              UNIT_END + 0x0083 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_3_PAD                     UNIT_END + 0x0084 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_4_CREATOR                 UNIT_END + 0x0085 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_4_0                       UNIT_END + 0x0087 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_4_PROPERTIES              UNIT_END + 0x0093 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_4_PAD                     UNIT_END + 0x0094 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_5_CREATOR                 UNIT_END + 0x0095 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_5_0                       UNIT_END + 0x0097 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_5_PROPERTIES              UNIT_END + 0x00A3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_5_PAD                     UNIT_END + 0x00A4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_6_CREATOR                 UNIT_END + 0x00A5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_6_0                       UNIT_END + 0x00A7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_6_PROPERTIES              UNIT_END + 0x00B3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_6_PAD                     UNIT_END + 0x00B4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_7_CREATOR                 UNIT_END + 0x00B5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_7_0                       UNIT_END + 0x00B7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_7_PROPERTIES              UNIT_END + 0x00C3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_7_PAD                     UNIT_END + 0x00C4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_8_CREATOR                 UNIT_END + 0x00C5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_8_0                       UNIT_END + 0x00C7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_8_PROPERTIES              UNIT_END + 0x00D3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_8_PAD                     UNIT_END + 0x00D4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_9_CREATOR                 UNIT_END + 0x00D5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_9_0                       UNIT_END + 0x00D7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_9_PROPERTIES              UNIT_END + 0x00E3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_9_PAD                     UNIT_END + 0x00E4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_10_CREATOR                UNIT_END + 0x00E5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_10_0                      UNIT_END + 0x00E7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_10_PROPERTIES             UNIT_END + 0x00F3 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_10_PAD                    UNIT_END + 0x00F4 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_11_CREATOR                UNIT_END + 0x00F5 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_11_0                      UNIT_END + 0x00F7 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_11_PROPERTIES             UNIT_END + 0x0103 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_11_PAD                    UNIT_END + 0x0104 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_12_CREATOR                UNIT_END + 0x0105 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_12_0                      UNIT_END + 0x0107 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_12_PROPERTIES             UNIT_END + 0x0113 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_12_PAD                    UNIT_END + 0x0114 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_13_CREATOR                UNIT_END + 0x0115 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_13_0                      UNIT_END + 0x0117 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_13_PROPERTIES             UNIT_END + 0x0123 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_13_PAD                    UNIT_END + 0x0124 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_14_CREATOR                UNIT_END + 0x0125 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_14_0                      UNIT_END + 0x0127 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_14_PROPERTIES             UNIT_END + 0x0133 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_14_PAD                    UNIT_END + 0x0134 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_15_CREATOR                UNIT_END + 0x0135 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_15_0                      UNIT_END + 0x0137 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_15_PROPERTIES             UNIT_END + 0x0143 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_15_PAD                    UNIT_END + 0x0144 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_16_CREATOR                UNIT_END + 0x0145 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_16_0                      UNIT_END + 0x0147 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_16_PROPERTIES             UNIT_END + 0x0153 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_16_PAD                    UNIT_END + 0x0154 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_17_CREATOR                UNIT_END + 0x0155 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_17_0                      UNIT_END + 0x0157 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_17_PROPERTIES             UNIT_END + 0x0163 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_17_PAD                    UNIT_END + 0x0164 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_18_CREATOR                UNIT_END + 0x0165 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_18_0                      UNIT_END + 0x0167 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_18_PROPERTIES             UNIT_END + 0x0173 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_18_PAD                    UNIT_END + 0x0174 // Size: 1, Type: uint32
#define   PLAYER_VISIBLE_ITEM_19_CREATOR                UNIT_END + 0x0175 // Size: 2, Type: guid
#define   PLAYER_VISIBLE_ITEM_19_0                      UNIT_END + 0x0177 // Size: 12, Type: uint32
#define   PLAYER_VISIBLE_ITEM_19_PROPERTIES             UNIT_END + 0x0183 // Size: 1, Type: bytes
#define   PLAYER_VISIBLE_ITEM_19_PAD                    UNIT_END + 0x0184 // Size: 1, Type: uint32
#define   PLAYER_CHOSEN_TITLE                           UNIT_END + 0x0185 // Size: 1, Type: uint32
#define   PLAYER_FIELD_INV_SLOT_HEAD                    UNIT_END + 0x0186 // Size: 46, Type: guid
#define   PLAYER_FIELD_PACK_SLOT_1                      UNIT_END + 0x01B4 // Size: 32, Type: guid
#define   PLAYER_FIELD_BANK_SLOT_1                      UNIT_END + 0x01D4 // Size: 56, Type: guid
#define   PLAYER_FIELD_BANKBAG_SLOT_1                   UNIT_END + 0x020C // Size: 14, Type: guid
#define   PLAYER_FIELD_VENDORBUYBACK_SLOT_1             UNIT_END + 0x021A // Size: 24, Type: guid
#define   PLAYER_FIELD_KEYRING_SLOT_1                   UNIT_END + 0x0232 // Size: 64, Type: guid
#define   PLAYER_FARSIGHT                               UNIT_END + 0x0272 // Size: 2, Type: guid
#define   PLAYER__FIELD_COMBO_TARGET                    UNIT_END + 0x0274 // Size: 2, Type: guid
#define   PLAYER__FIELD_KNOWN_TITLES                    UNIT_END + 0x0276 // Size: 2, Type: guid
#define   PLAYER_XP                                     UNIT_END + 0x0278 // Size: 1, Type: uint32
#define   PLAYER_NEXT_LEVEL_XP                          UNIT_END + 0x0279 // Size: 1, Type: uint32
#define   PLAYER_SKILL_INFO_1_1                         UNIT_END + 0x027A // Size: 384, Type: bytes
#define   PLAYER_CHARACTER_POINTS1                      UNIT_END + 0x03FA // Size: 1, Type: uint32
#define   PLAYER_CHARACTER_POINTS2                      UNIT_END + 0x03FB // Size: 1, Type: uint32
#define   PLAYER_TRACK_CREATURES                        UNIT_END + 0x03FC // Size: 1, Type: uint32
#define   PLAYER_TRACK_RESOURCES                        UNIT_END + 0x03FD // Size: 1, Type: uint32
#define   PLAYER_BLOCK_PERCENTAGE                       UNIT_END + 0x03FE // Size: 1, Type: float
#define   PLAYER_DODGE_PERCENTAGE                       UNIT_END + 0x03FF // Size: 1, Type: float
#define   PLAYER_PARRY_PERCENTAGE                       UNIT_END + 0x0400 // Size: 1, Type: float
#define   PLAYER_CRIT_PERCENTAGE                        UNIT_END + 0x0401 // Size: 1, Type: float
#define   PLAYER_RANGED_CRIT_PERCENTAGE                 UNIT_END + 0x0402 // Size: 1, Type: float
#define   PLAYER_OFFHAND_CRIT_PERCENTAGE                UNIT_END + 0x0403 // Size: 1, Type: float
#define   PLAYER_SPELL_CRIT_PERCENTAGE1                 UNIT_END + 0x0404 // Size: 7, Type: float
#define   PLAYER_EXPLORED_ZONES_1                       UNIT_END + 0x040B // Size: 64, Type: bytes
#define   PLAYER_REST_STATE_EXPERIENCE                  UNIT_END + 0x044B // Size: 1, Type: uint32
#define   PLAYER_FIELD_COINAGE                          UNIT_END + 0x044C // Size: 1, Type: uint32
#define   PLAYER_FIELD_POSSTAT0                         UNIT_END + 0x044D // Size: 1, Type: uint32
#define   PLAYER_FIELD_POSSTAT1                         UNIT_END + 0x044E // Size: 1, Type: uint32
#define   PLAYER_FIELD_POSSTAT2                         UNIT_END + 0x044F // Size: 1, Type: uint32
#define   PLAYER_FIELD_POSSTAT3                         UNIT_END + 0x0450 // Size: 1, Type: uint32
#define   PLAYER_FIELD_POSSTAT4                         UNIT_END + 0x0451 // Size: 1, Type: uint32
#define   PLAYER_FIELD_NEGSTAT0                         UNIT_END + 0x0452 // Size: 1, Type: uint32
#define   PLAYER_FIELD_NEGSTAT1                         UNIT_END + 0x0453 // Size: 1, Type: uint32
#define   PLAYER_FIELD_NEGSTAT2                         UNIT_END + 0x0454 // Size: 1, Type: uint32
#define   PLAYER_FIELD_NEGSTAT3                         UNIT_END + 0x0455 // Size: 1, Type: uint32
#define   PLAYER_FIELD_NEGSTAT4                         UNIT_END + 0x0456 // Size: 1, Type: uint32
#define   PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE       UNIT_END + 0x0457 // Size: 7, Type: uint32
#define   PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE       UNIT_END + 0x045E // Size: 7, Type: uint32
#define   PLAYER_FIELD_MOD_DAMAGE_DONE_POS              UNIT_END + 0x0465 // Size: 7, Type: uint32
#define   PLAYER_FIELD_MOD_DAMAGE_DONE_NEG              UNIT_END + 0x046C // Size: 7, Type: uint32
#define   PLAYER_FIELD_MOD_DAMAGE_DONE_PCT              UNIT_END + 0x0473 // Size: 7, Type: uint32
#define   PLAYER_FIELD_MOD_HEALING_DONE_POS             UNIT_END + 0x047A // Size: 1, Type: uint32
#define   PLAYER_FIELD_MOD_TARGET_RESISTANCE            UNIT_END + 0x047B // Size: 1, Type: uint32
#define   PLAYER_FIELD_BYTES                            UNIT_END + 0x047C // Size: 1, Type: bytes
#define   PLAYER_AMMO_ID                                UNIT_END + 0x047D // Size: 1, Type: uint32
#define   PLAYER_SELF_RES_SPELL                         UNIT_END + 0x047E // Size: 1, Type: uint32
#define   PLAYER_FIELD_PVP_MEDALS                       UNIT_END + 0x047F // Size: 1, Type: uint32
#define   PLAYER_FIELD_BUYBACK_PRICE_1                  UNIT_END + 0x0480 // Size: 12, Type: uint32
#define   PLAYER_FIELD_BUYBACK_TIMESTAMP_1              UNIT_END + 0x048C // Size: 12, Type: uint32
#define   PLAYER_FIELD_TODAY_KILLS                      UNIT_END + 0x0498 // Size: 1, Type: bytes
#define   PLAYER_FIELD_YESTERDAY_KILLS                  UNIT_END + 0x0499 // Size: 1, Type: bytes
#define   PLAYER_FIELD_LIFETIME_HONORBALE_KILLS         UNIT_END + 0x049A // Size: 1, Type: uint32
#define   PLAYER_FIELD_BYTES2                           UNIT_END + 0x049B // Size: 1, Type: bytes
#define   PLAYER_FIELD_WATCHED_FACTION_INDEX            UNIT_END + 0x049C // Size: 1, Type: uint32
#define   PLAYER_FIELD_COMBAT_RATING_1                  UNIT_END + 0x049D // Size: 23, Type: uint32
#define   PLAYER_FIELD_ARENA_TEAM_INFO_1_1              UNIT_END + 0x04B4 // Size: 9, Type: uint32
#define   PLAYER_FIELD_HONOR_CURRENCY                   UNIT_END + 0x04BD // Size: 1, Type: uint32
#define   PLAYER_FIELD_ARENA_CURRENCY                   UNIT_END + 0x04BE // Size: 1, Type: uint32
#define   PLAYER_FIELD_PADDING                          UNIT_END + 0x04BF // Size: 1, Type: uint32
#define   PLAYER_END                                    PLAYER_FIELD_PADDING + 1


// 'GAMEOBJECT' object type update fields
#define   OBJECT_FIELD_CREATED_BY                       OBJECT_END + 0x0000 // Size: 2, Type: guid
#define   GAMEOBJECT_DISPLAYID                          OBJECT_END + 0x0002 // Size: 1, Type: uint32
#define   GAMEOBJECT_FLAGS                              OBJECT_END + 0x0003 // Size: 1, Type: uint32
#define   GAMEOBJECT_ROTATION                           OBJECT_END + 0x0004 // Size: 4, Type: float
#define   GAMEOBJECT_STATE                              OBJECT_END + 0x0008 // Size: 1, Type: uint32
#define   GAMEOBJECT_POS_X                              OBJECT_END + 0x0009 // Size: 1, Type: float
#define   GAMEOBJECT_POS_Y                              OBJECT_END + 0x000A // Size: 1, Type: float
#define   GAMEOBJECT_POS_Z                              OBJECT_END + 0x000B // Size: 1, Type: float
#define   GAMEOBJECT_FACING                             OBJECT_END + 0x000C // Size: 1, Type: float
#define   GAMEOBJECT_DYN_FLAGS                          OBJECT_END + 0x000D // Size: 1, Type: uint32
#define   GAMEOBJECT_FACTION                            OBJECT_END + 0x000E // Size: 1, Type: uint32
#define   GAMEOBJECT_TYPE_ID                            OBJECT_END + 0x000F // Size: 1, Type: uint32
#define   GAMEOBJECT_LEVEL                              OBJECT_END + 0x0010 // Size: 1, Type: uint32
#define   GAMEOBJECT_ARTKIT                             OBJECT_END + 0x0011 // Size: 1, Type: uint32
#define   GAMEOBJECT_ANIMPROGRESS                       OBJECT_END + 0x0012 // Size: 1, Type: uint32
#define   GAMEOBJECT_PADDING                            OBJECT_END + 0x0013 // Size: 1, Type: uint32
#define   GAMEOBJECT_END                                GAMEOBJECT_PADDING + 1


// 'DYNAMICOBJECT' object type update fields
#define   DYNAMICOBJECT_CASTER                          OBJECT_END + 0x0000 // Size: 2, Type: guid
#define   DYNAMICOBJECT_BYTES                           OBJECT_END + 0x0002 // Size: 1, Type: bytes
#define   DYNAMICOBJECT_SPELLID                         OBJECT_END + 0x0003 // Size: 1, Type: uint32
#define   DYNAMICOBJECT_RADIUS                          OBJECT_END + 0x0004 // Size: 1, Type: float
#define   DYNAMICOBJECT_POS_X                           OBJECT_END + 0x0005 // Size: 1, Type: float
#define   DYNAMICOBJECT_POS_Y                           OBJECT_END + 0x0006 // Size: 1, Type: float
#define   DYNAMICOBJECT_POS_Z                           OBJECT_END + 0x0007 // Size: 1, Type: float
#define   DYNAMICOBJECT_FACING                          OBJECT_END + 0x0008 // Size: 1, Type: float
#define   DYNAMICOBJECT_PAD                             OBJECT_END + 0x0009 // Size: 1, Type: bytes
#define   DYNAMICOBJECT_END                             DYNAMICOBJECT_PAD + 1


// 'CORPSE' object type update fields
#define   CORPSE_FIELD_OWNER                            OBJECT_END + 0x0000 // Size: 2, Type: guid
#define   CORPSE_FIELD_FACING                           OBJECT_END + 0x0002 // Size: 1, Type: float
#define   CORPSE_FIELD_POS_X                            OBJECT_END + 0x0003 // Size: 1, Type: float
#define   CORPSE_FIELD_POS_Y                            OBJECT_END + 0x0004 // Size: 1, Type: float
#define   CORPSE_FIELD_POS_Z                            OBJECT_END + 0x0005 // Size: 1, Type: float
#define   CORPSE_FIELD_DISPLAY_ID                       OBJECT_END + 0x0006 // Size: 1, Type: uint32
#define   CORPSE_FIELD_ITEM                             OBJECT_END + 0x0007 // Size: 19, Type: uint32
#define   CORPSE_FIELD_BYTES_1                          OBJECT_END + 0x001A // Size: 1, Type: bytes
#define   CORPSE_FIELD_BYTES_2                          OBJECT_END + 0x001B // Size: 1, Type: bytes
#define   CORPSE_FIELD_GUILD                            OBJECT_END + 0x001C // Size: 1, Type: uint32
#define   CORPSE_FIELD_FLAGS                            OBJECT_END + 0x001D // Size: 1, Type: uint32
#define   CORPSE_FIELD_DYNAMIC_FLAGS                    OBJECT_END + 0x001E // Size: 1, Type: uint32
#define   CORPSE_FIELD_PAD                              OBJECT_END + 0x001F // Size: 1, Type: uint32
#define   CORPSE_END                                    CORPSE_FIELD_PAD + 1

#endif
//Done
#endif // UPDATEFIELDS_H
