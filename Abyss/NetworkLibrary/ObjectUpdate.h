// (c) AbyssX Group
#if !defined(OBJECTUPDATE_H)
#define OBJECTUPDATE_H

class ObjectUpdate
{
	public:
		enum UpdateType {
			UPDOBJECT, UPDITEM, UPDCONTAINER, UPDUNIT, UPDPLAYER, UPDGAMEOBJ,
			UPDDYNAMICOBJ, UPDCORPSE
		};

		ObjectUpdate();
		~ObjectUpdate();
		void Clear(void);

		void Touch(enum UpdateType t);
		void AddField(enum UpdateType t, unsigned short field, unsigned int value);
		void AddFieldFloat(enum UpdateType t, unsigned short field, float value);
		unsigned short WriteTo(unsigned char *buf);

	private:
		void WriteMask(enum UpdateType t, unsigned char *buf, unsigned short *place,
			unsigned char *sbyte, unsigned short *sbit);
		void WriteFields(enum UpdateType t, unsigned char *buf, unsigned short *place);

		map<unsigned short, unsigned int> mObjectUpdates;
		map<unsigned short, unsigned int> mItemUpdates;
		map<unsigned short, unsigned int> mContainerUpdates;
		map<unsigned short, unsigned int> mUnitUpdates;
		map<unsigned short, unsigned int> mPlayerUpdates;
		map<unsigned short, unsigned int> mGameObjectUpdates;
		map<unsigned short, unsigned int> mDynamicObjectUpdates;
		map<unsigned short, unsigned int> mCorpseUpdates;
		map<enum UpdateType, bool> mTouched;
};

#define OBJECT_FIELD_GUID0    0x0000 // int32(64) 
#define OBJECT_FIELD_GUID1    0x0001 // int32 
#define OBJECT_FIELD_TYPE     0x0002 // int32 
#define OBJECT_FIELD_ENTRY    0x0003 // int32 
#define OBJECT_FIELD_SCALE_X  0x0004 // int32 
#define OBJECT_FIELD_PADDING  0x0005 // int32 
#define OBJECT_END            0x0006 

#define ITEM_FIELD_OWNER0                0x0000 // int32(64) 
#define ITEM_FIELD_OWNER1                0x0001 // int32 
#define ITEM_FIELD_CONTAINED0            0x0002 // int32(64) 
#define ITEM_FIELD_CONTAINED1            0x0003 // int32 
#define ITEM_FIELD_CREATOR0              0x0004 // int32(64) 
#define ITEM_FIELD_CREATOR1              0x0005 // int32 
#define ITEM_FIELD_GIFTCREATOR0          0x0006 // int32(64)  (BETA3 ADD) 
#define ITEM_FIELD_GIFTCREATOR1          0x0007 // int32 
#define ITEM_FIELD_STACK_COUNT           0x0008 // int32 
#define ITEM_FIELD_DURATION              0x0009 // int32 
#define ITEM_FIELD_SPELL_CHARGES0        0x000A // int32 
#define ITEM_FIELD_SPELL_CHARGES1        0x000B // int32 
#define ITEM_FIELD_SPELL_CHARGES2        0x000C // int32 
#define ITEM_FIELD_SPELL_CHARGES3        0x000D // int32 
#define ITEM_FIELD_SPELL_CHARGES4        0x000E // int32 
#define ITEM_FIELD_FLAGS                 0x000F // int32 
#define ITEM_FIELD_ENCHANTMENT00         0x0010 // int32 
#define ITEM_FIELD_ENCHANTMENT01         0x0011 // int32 
#define ITEM_FIELD_ENCHANTMENT02         0x0012 // int32 
#define ITEM_FIELD_ENCHANTMENT03         0x0013 // int32 
#define ITEM_FIELD_ENCHANTMENT04         0x0014 // int32 
#define ITEM_FIELD_ENCHANTMENT05         0x0015 // int32 
#define ITEM_FIELD_ENCHANTMENT06         0x0016 // int32 
#define ITEM_FIELD_ENCHANTMENT07         0x0017 // int32 
#define ITEM_FIELD_ENCHANTMENT08         0x0018 // int32 
#define ITEM_FIELD_ENCHANTMENT09         0x0019 // int32 
#define ITEM_FIELD_ENCHANTMENT10         0x001A // int32 
#define ITEM_FIELD_ENCHANTMENT11         0x001B // int32 
#define ITEM_FIELD_ENCHANTMENT12         0x001C // int32 
#define ITEM_FIELD_ENCHANTMENT13         0x001D // int32 
#define ITEM_FIELD_ENCHANTMENT14         0x001E // int32 
#define ITEM_FIELD_ENCHANTMENT15         0x001F // int32 
#define ITEM_FIELD_ENCHANTMENT16         0x0020 // int32 
#define ITEM_FIELD_ENCHANTMENT17         0x0021 // int32 
#define ITEM_FIELD_ENCHANTMENT18         0x0022 // int32 
#define ITEM_FIELD_ENCHANTMENT19         0x0023 // int32 
#define ITEM_FIELD_ENCHANTMENT20         0x0024 // int32 
#define ITEM_FIELD_PROPERTY_SEED         0x0025 // int32 
#define ITEM_FIELD_RANDOM_PROPERTIES_ID  0x0026 // int32 
#define ITEM_FIELD_ITEM_TEXT_ID          0x0027 // int32 
#define ITEM_END                         0x0028 

#define CONTAINER_FIELD_NUM_SLOTS      0x0000 // int32 
#define CONTAINER_ALIGN_PAD            0x0001 // int32 
#define CONTAINER_FIELD_SLOT00         0x0002 // int32(64) 
#define CONTAINER_FIELD_SLOT01         0x0003 // int32 
// and so on with CONTAINER_FIELD_SLOT 
#define CONTAINER_FIELD_SLOT38         0x0028 // int32(64) 
#define CONTAINER_FIELD_SLOT39         0x0029 // int32 
#define CONTAINER_END                  0x002A 


#define UNIT_FIELD_CHARM0                         0x0000 // int32(64) 
#define UNIT_FIELD_CHARM1                         0x0001 // int32 
#define UNIT_FIELD_SUMMON0                        0x0002 // int32(64) 
#define UNIT_FIELD_SUMMON1                        0x0003 // int32 
#define UNIT_FIELD_CHARMEDBY0                     0x0004 // int32(64) 
#define UNIT_FIELD_CHARMEDBY1                     0x0005 // int32 
#define UNIT_FIELD_SUMMONEDBY0                    0x0006 // int32(64) 
#define UNIT_FIELD_SUMMONEDBY1                    0x0007 // int32 
#define UNIT_FIELD_CREATEDBY0                     0x0008 // int32(64) 
#define UNIT_FIELD_CREATEDBY1                     0x0009 // int32 
#define UNIT_FIELD_TARGET0                        0x000A // int32(64) 
#define UNIT_FIELD_TARGET1                        0x000B // int32 
#define UNIT_FIELD_CHANNEL_OBJECT0                0x000C // int32(64) 
#define UNIT_FIELD_CHANNEL_OBJECT1                0x000D // int32 
#define UNIT_FIELD_HEALTH                         0x000E // int32 
#define UNIT_FIELD_POWER1                         0x000F // int32 
#define UNIT_FIELD_POWER2                         0x0010 // int32 
#define UNIT_FIELD_POWER3                         0x0011 // int32 
#define UNIT_FIELD_POWER4                         0x0012 // int32 
#define UNIT_FIELD_POWER5                         0x0013 // int32  (BETA3 ADD) 
#define UNIT_FIELD_MAXHEALTH                      0x0014 // int32 
#define UNIT_FIELD_MAXPOWER1                      0x0015 // int32 
#define UNIT_FIELD_MAXPOWER2                      0x0016 // int32 
#define UNIT_FIELD_MAXPOWER3                      0x0017 // int32 
#define UNIT_FIELD_MAXPOWER4                      0x0018 // int32 
#define UNIT_FIELD_MAXPOWER5                      0x0019 // int32  (BETA3 ADD) 
#define UNIT_FIELD_LEVEL                          0x001A // int32 
#define UNIT_FIELD_FACTIONTEMPLATE                0x001B // int32 
#define UNIT_FIELD_BYTES_0                        0x001C // int32 
#define UNIT_VIRTUAL_ITEM_SLOT_DISPLAY0           0x001D // int32 
#define UNIT_VIRTUAL_ITEM_SLOT_DISPLAY1           0x001E // int32 
#define UNIT_VIRTUAL_ITEM_SLOT_DISPLAY2           0x001F // int32 
#define UNIT_VIRTUAL_ITEM_INFO                    0x0020 // int32 
//#define UNIT_VIRTUAL_ITEM_INFO5                 0x0025 // int32 
#define UNIT_FIELD_FLAGS                          0x0026 // int32 
#define UNIT_FIELD_AURA		                      0x0027 // int32 
//#define UNIT_FIELD_AURA55                       0x005E // int32 
#define UNIT_FIELD_AURALEVELS                     0x005F // int32 
//#define UNIT_FIELD_AURALEVELS9                  0x0068 // int32 
#define UNIT_FIELD_AURAAPPLICATIONS	              0x0069 // int32 
//#define UNIT_FIELD_AURAAPPLICATIONS9            0x0072 // int32 
#define UNIT_FIELD_AURAFLAGS                      0x0073 // int32 
//#define UNIT_FIELD_AURAFLAGS6                   0x0079 // int32 
#define UNIT_FIELD_AURASTATE                      0x007A // int32 
#define UNIT_FIELD_BASEATTACKTIME0                0x007B // int32 
#define UNIT_FIELD_BASEATTACKTIME1                0x007C // int32 
#define UNIT_FIELD_BOUNDINGRADIUS                 0x007D // float 
#define UNIT_FIELD_COMBATREACH                    0x007E // float 
#define UNIT_FIELD_WEAPONREACH                    0x007F // float 
#define UNIT_FIELD_DISPLAYID                      0x0080 // int32 
#define UNIT_FIELD_MOUNTDISPLAYID                 0x0081 // int32 
#define UNIT_FIELD_MINDAMAGE                      0x0082 // float 
#define UNIT_FIELD_MAXDAMAGE                      0x0083 // float 
#define UNIT_FIELD_BYTES_1                        0x0084 // int32 
#define UNIT_FIELD_PETNUMBER                      0x0085 // int32 
#define UNIT_FIELD_PET_NAME_TIMESTAMP             0x0086 // int32 
#define UNIT_FIELD_PETEXPERIENCE                  0x0087 // int32 
#define UNIT_FIELD_PETNEXTLEVELEXP                0x0088 // int32 
#define UNIT_DYNAMIC_FLAGS                        0x0089 // int32 
#define UNIT_CHANNEL_SPELL                        0x008A // int32 
#define UNIT_MOD_CAST_SPEED                       0x008B // int32 
#define UNIT_CREATED_BY_SPELL                     0x008C // int32 
#define UNIT_NPC_FLAGS                            0x008D // int32 
#define UNIT_NPC_EMOTE_STATE                      0x008E // int32
#define UNIT_FIELD_PADDING                        0x008F // int32 
#define UNIT_END                                  0x0090 

//PLAYER DATA
#define PLAYER_SELECTION0                          0x0000 // int32(64) 
#define PLAYER_SELECTION1                          0x0001 // int32 
#define PLAYER_DUEL_ARBITER0                       0x0002 // int32(64) 
#define PLAYER_DUEL_ARBITER1                       0x0003 // int32 
#define PLAYER_GUILDID                             0x0004 // int32 
#define PLAYER_GUILDRANK                           0x0005 // int32 
#define PLAYER_BYTES                               0x0006 // int32 
#define PLAYER_BYTES_2                             0x0007 // int32 
#define PLAYER_BYTES_3                             0x0008 // int32
#define PLAYER_DUEL_TEAM                           0x0009 // int32 
#define PLAYER_GUILD_TIMESTAMP                     0x000A // int32 
#define PLAYER_FIELD_PAD0                          0x000B // int32

//PLAYER INVENTORY SLOTS
#define PLAYER_FIELD_INV_SLOT                      0x000C // int32(64) 
//#define PLAYER_FIELD_INV_SLOT45                  0x0039 // int32 

//PLAYER BACKPACK SLOTS
#define PLAYER_FIELD_PACK_SLOT                     0x003A // int32(64) 
//#define PLAYER_FIELD_PACK_SLOT31                 0x0059 // int32 

//PLAYER BANK SLOTS
#define PLAYER_FIELD_BANK_SLOT                     0x005A // int32(64) 
//#define PLAYER_FIELD_BANK_SLOT47                 0x0089 // int32 

//PLAYER BANKBAG SLOTS
#define PLAYER_FIELD_BANKBAG_SLOT                  0x008A // int32(64) 
#define PLAYER_FIELD_BANKBAG_SLOT11                0x0095 // int32 

#define PLAYER_FARSIGHT0                           0x0096 // int32(64) 
#define PLAYER_FARSIGHT1                           0x0097 // int32 
#define PLAYER_FIELD_COMBO_TARGET0                 0x0098 // int32(64) 
#define PLAYER_FIELD_COMBO_TARGET1                 0x0099 // int32 
#define PLAYER_XP                                  0x009A // int32 
#define PLAYER_NEXT_LEVEL_XP                       0x009B // int32 

//PLAYER SKILL INFORMATION
#define PLAYER_SKILL_INFO                          0x009C // int32 
//#define PLAYER_SKILL_INFO383                     0x021B // int32 

//PLAYER QUEST LOG
#define PLAYER_QUEST_LOG                           0x021C // int32 
//#define PLAYER_QUEST_LOG79                       0x026B // int32 

#define PLAYER_CHARACTER_POINTS1                   0x026C // int32 
#define PLAYER_CHARACTER_POINTS2                   0x026D // int32 
#define PLAYER_TRACK_CREATURES                     0x026E // int32 
#define PLAYER_TRACK_RESOURCES                     0x026F // int32 
#define PLAYER_CHAT_FILTERS                        0x0270 // int32 
#define PLAYER_BLOCK_PERCENTAGE                    0x0271 // float 
#define PLAYER_DODGE_PERCENTAGE                    0x0272 // float 
#define PLAYER_PARRY_PERCENTAGE                    0x0273 // float 
#define PLAYER_BASE_MANA                           0x0274 // int32 

//PLAYER EXPLORED ZONES
#define PLAYER_EXPLORED_ZONES                      0x0275 // int32 
#define PLAYER_EXPLORED_ZONES31                    0x0294 // int32 

#define PLAYER_REST_STATE_EXPERIENCE               0x0295 // int32 
#define PLAYER_FIELD_COINAGE                       0x0296 // int32 

//PLAYER BASE STATS
#define PLAYER_FIELD_BASESTAT                      0x0297 // int32 
//#define PLAYER_FIELD_BASESTAT4                   0x029B // int32 

//PLAYER POSITIVE STATS
#define PLAYER_FIELD_POSSTAT                       0x029C // int32 
//#define PLAYER_FIELD_POSSTAT4                    0x02A0 // int32 

//PLAYER NEGATIVE STATS
#define PLAYER_FIELD_NEGSTAT                       0x02A1// int32 
//#define PLAYER_FIELD_NEGSTAT4                    0x02A5 // int32 


//PLAYER BASE RESISTANCES
#define PLAYER_FIELD_RESISTANCES                   0x02A6 // int32 
//#define PLAYER_FIELD_RESISTANCES5                0x02AB // int32 

//PLAYER POSITIVE RESISTANCES
#define PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE    0x02AC // int32 
//#define PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE5 0x02B1 // int32

//PLAYER NEGATIVE RESISTANCES
#define PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE    0x02B2 // int32 
//#define PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE5   0x02B7 // int32 

//PLAYER DAMAGES
#define PLAYER_FIELD_MOD_DAMAGE_DONE_POS		   0x02B8 // int32
//#define PLAYER_FIELD_MOD_DAMAGE_DONE_POS5        0x02BD // int32
#define PLAYER_FIELD_MOD_DAMAGE_DONE_NEG           0x02BE // int32
//#define PLAYER_FIELD_MOD_DAMAGE_DONE_NEG5        0x02C3 // int32
#define PLAYER_FIELD_MOD_DAMAGE_DONE_PCT           0x02C4 // int32
//#define PLAYER_FIELD_MOD_DAMAGE_DONE_PCT5        0x02C9 // int32

#define PLAYER_FIELD_BYTES                         0x02CA // int32 
#define PLAYER_FIELD_ATTACKPOWER                   0x02CB // int32 
#define PLAYER_FIELD_ATTACKPOWERMODPOS             0x02CC // int32 
#define PLAYER_FIELD_ATTACKPOWERMODNEG             0x02CD // int32 
#define PLAYER_FIELD_AMMO_ID			           0x02CE // int32 
#define PLAYER_FIELD_PADDING					   0x02CF // int32
#define PLAYER_END								   0x02D0

#define GAMEOBJECT_DISPLAYID   0x0000 // int32 
#define GAMEOBJECT_FLAGS       0x0001 // int32 
#define GAMEOBJECT_ROTATION00  0x0002 // float 
#define GAMEOBJECT_ROTATION01  0x0003 // float 
#define GAMEOBJECT_ROTATION02  0x0004 // float 
#define GAMEOBJECT_ROTATION03  0x0005 // float 
#define GAMEOBJECT_STATE       0x0006 // int32 
#define GAMEOBJECT_TIMESTAMP   0x0007 // int32 
#define GAMEOBJECT_POS_X       0x0008 // float 
#define GAMEOBJECT_POS_Y       0x0009 // float 
#define GAMEOBJECT_POS_Z       0x000A // float 
#define GAMEOBJECT_FACING      0x000B // float 
#define GAMEOBJECT_DYN_FLAGS   0x000C // int32 
#define GAMEOBJECT_TYPE_ID     0x000D // int32  (BETA3 ADD) 
#define GAMEOBJECT_FACTION     0x000E // int32 
#define GAMEOBJECT_END         0x000F 

#define DYNAMICOBJECT_CASTER0  0x0000 // int32(64) 
#define DYNAMICOBJECT_CASTER1  0x0001 // int32 
#define DYNAMICOBJECT_BYTES    0x0002 // int32 
#define DYNAMICOBJECT_SPELLID  0x0003 // int32 
#define DYNAMICOBJECT_RADIUS   0x0004 // float 
#define DYNAMICOBJECT_POS_X    0x0005 // float 
#define DYNAMICOBJECT_POS_Y    0x0006 // float 
#define DYNAMICOBJECT_POS_Z    0x0007 // float 
#define DYNAMICOBJECT_FACING   0x0008 // float 
#define DYNAMICOBJECT_PAD      0x0009 // int32 
#define DYNAMICOBJECT_END      0x000A 

#define CORPSE_FIELD_OWNER0      0x0000 // int32(64) 
#define CORPSE_FIELD_OWNER1      0x0001 // int32 
#define CORPSE_FIELD_FACING      0x0002 // float 
#define CORPSE_FIELD_POS_X       0x0003 // float 
#define CORPSE_FIELD_POS_Y       0x0004 // float 
#define CORPSE_FIELD_POS_Z       0x0005 // float 
#define CORPSE_FIELD_DISPLAY_ID  0x0006 // int32 
#define CORPSE_FIELD_ITEM00      0x0007 // int32 
#define CORPSE_FIELD_ITEM18      0x0019 // int32 
#define CORPSE_FIELD_BYTES_1     0x001A // int32 
#define CORPSE_FIELD_BYTES_2     0x001B // int32 
#define CORPSE_FIELD_GUILD       0x001C // int32 
#define CORPSE_FIELD_FLAGS       0x001D // int32 
#define CORPSE_END               0x001E 

#endif
