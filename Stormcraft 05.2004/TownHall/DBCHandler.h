#ifndef _DBCHANDLER_H
#define _DBCHANDLER_H
#include <stdio.h>

struct dbc_header
{
	int ftype;
	int rows;
	int cols;
	int row_len;
	int str_len;
};

class DBCFile
{
	private:
		dbc_header header;
		unsigned long StringPos;
		FILE *fp;
		map<unsigned long,unsigned long> KeyMap;
	
	public:
		DBCFile(void);
		~DBCFile(void);

		bool init(char *fname);
		inline int rowLen()
		{
			if (!header.cols)
				return -1;
			else
				return header.cols;
		}

		int getValue(unsigned long key, unsigned long col);
		bool getValue(unsigned long key, unsigned long col, float &value);
		bool getValue(unsigned long key, unsigned long col, int &value);
		bool fetchRow(unsigned long key, int *buffer);
		inline bool validRow(unsigned long key)
		{
			return (KeyMap[key]!=0);
		}
		bool getString(unsigned long key, unsigned long col, char *buffer, unsigned long buffersize);
};

class CDBCManager
{
	public:
		/*
		CDBCManager();
		~CDBCManager()
		/**/

	bool Initialize();

	DBCFile Spell;
	DBCFile EmotesText;
	DBCFile SpellItemEnchantment;
	DBCFile SpellEffectNames;
	DBCFile SpellAuraNames;
	DBCFile SpellDuration;
	DBCFile SpellRadius;
};


// Defines for DBC cols
// Spell section

#define DBC_SPELL_COSTTYPE		26
#define DBC_SPELL_COST			27
// effects start at column 53
// SpellEffectNames.dbc
#define DBC_SPELL_EFFECT(_EFFECT_)				(_EFFECT_+53)
#define DBC_SPELL_ATTRIBUTE(_EFFECT_,_ATTRIB_)	(_EFFECT_+53+(_ATTRIB_*3))
#define	SPELL_ATTRIB_EFFECT		0
#define	SPELL_ATTRIB_RANDOMNESS	1
#define	SPELL_ATTRIB_2			2
#define	SPELL_ATTRIB_3			3
// 4 is a float
#define	SPELL_ATTRIB_4			4
#define	SPELL_ATTRIB_POWER		5
#define	SPELL_ATTRIB_TYPE		6
#define	SPELL_ATTRIB_7			7 // Often 15 when its AOE ?
//SpellRadius.dbc
#define	SPELL_ATTRIB_RADIUS		8
//SpellAuraNames.dbc
#define	SPELL_ATTRIB_AURA		9
#define	SPELL_ATTRIB_PERIODICITY	10
// 11 is a float
#define	SPELL_ATTRIB_11			11
#define	SPELL_ATTRIB_12			12
#define	SPELL_ATTRIB_ITEMLINK	13
// 14 is misc.. sometimes used for:
// SpellItemEnchantment.dbc
#define	SPELL_ATTRIB_14			14
#define SPELL_ATTRIB_SPELLLINK	15
#define SPELL_ATTRIBS			15
#define DBC_SPELL_NAME			106
#define DBC_SPELL_RANK			115
#define DBC_SPELL_DESCRIPTION	124
#define DBC_SPELL_ELEMENT		1

// SpellCastTimes.dbc
#define DBC_SPELL_CASTTIME_ID		13 // psycho: was 12,13,14 not sure if its spell.dbc or spellcasttime.dbc
#define DBC_SPELL_ABILITYREUSETIME	14
#define DBC_SPELL_RECASTTIME		15

#define DBC_SPELL_REAGENT(_REAGENT_)		(_REAGENT_+34)
#define DBC_SPELL_REAGENTCOUNT(_REAGENT_)	(_REAGENT_+42)
#define DBC_SPELL_ITEM1			34
#define DBC_SPELL_ITEM2			35
#define DBC_SPELL_PROFICIENCY	53

#define DBC_SPELL_MINDMG 		69
#define DBC_SPELL_MAXDMG 		57
#define DBC_SPELL_HEAL_HP		(DBC_SPELL_MINDMG)
#define DBC_SPELL_HEAL_MANA		70
#define DBC_SPELL_MOVEMENT		71

#define DBC_SPELL_DURATION_ID	25 
//SpellDuration.dbc
#define DBC_SPELLDURATION_MINTIME     1
#define DBC_SPELLDURATION_PERLEVEL    2 
#define DBC_SPELLDURATION_MAXTIME     3
// or 24 or 25

//SpellRadius.dbc
#define DBC_SPELLRADIUS_MINRANGE	  1
#define DBC_SPELLRADIUS_MAXRANGE	  3

// 0 STR 1 AGI 2 STA 3 INT 4 SPIRIT
// 1 HOLY 2 FIRE 3 NATURE 4 COLD 5 SHADOW

// Emotes section
#define DBC_EMOTESTEXT_ANIM		2

#endif
