#ifndef DBCHANDLER_H
#define DBCHANDLER_H

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
	inline int rowcount()
	{
		if (!header.rows)
			return -1;
		else
			return header.rows;
	}

	bool prepPosition(unsigned long key, unsigned long col);
	int getValue(unsigned long key, unsigned long col);
	bool getValue(unsigned long key, unsigned long col, float &value);
	bool getValue(unsigned long key, unsigned long col, int &value);
	bool fetchRow(unsigned long key, int *buffer);
	bool fetchRow(unsigned long key, void *buffer);
	inline bool validRow(unsigned long key)
	{
		return (KeyMap[key]!=0);
	}
	void prepNoKeyPosition(unsigned long row, unsigned long col);
	int getIntValueNoKey(unsigned long row, unsigned long col);
	float getFloatValueNoKey(unsigned long row, unsigned long col);
	bool getString(unsigned long key, unsigned long col, char *buffer, unsigned long buffersize);
};

class CDBCManager
{
public:
	/*
	CDBCManager();
	~CDBCManager()
	*/

	bool Initialize();

	DBCFile Spell;
	DBCFile Emotes;
	DBCFile Faction;
	DBCFile FactionTemplate;
	DBCFile SpellItemEnchantment;
	DBCFile SpellEffectNames;
	DBCFile SpellAuraNames;
	DBCFile SpellDuration;
	DBCFile SpellRadius;
	DBCFile SkillLineAbility;
	DBCFile SpellCast;
	DBCFile TaxiNodes;
	DBCFile TaxiPath;
	DBCFile TaxiPathNodes;
	DBCFile WorldMapOverlay;
	DBCFile WorldMapArea;
	DBCFile AreaTable;
	DBCFile Talent;
};


// Defines for DBC cols
// Spell section

#define DBC_SPELL_COST			30
// effects start at column 53
// SpellEffectNames.dbc
#if TBC
#define DBC_EFFECT_COL 64
#else
#define DBC_EFFECT_COL 62
#endif
#define DBC_SPELL_EFFECT(_EFFECT_)				(_EFFECT_+DBC_EFFECT_COL)
#define DBC_SPELL_ATTRIBUTE(_EFFECT_,_ATTRIB_)	(_EFFECT_+DBC_EFFECT_COL+(_ATTRIB_*3))
#define	SPELL_ATTRIB_EFFECT		0
#define	SPELL_ATTRIB_RANDOMNESS	1
#define	SPELL_ATTRIB_2			2
#define	SPELL_ATTRIB_3			3
// 4 is a float
#define	SPELL_ATTRIB_4			4
#define	SPELL_ATTRIB_POWER		5
#define	SPELL_ATTRIB_TYPE		7
#define	SPELL_ATTRIB_7			8 // Often 15 when its AOE ?
//SpellRadius.dbc
#define	SPELL_ATTRIB_RADIUS		9
//SpellAuraNames.dbc
#define	SPELL_ATTRIB_AURA		10
#define	SPELL_ATTRIB_PERIODICITY	11
// 11 is a float
#define	SPELL_ATTRIB_11			12
#define	SPELL_ATTRIB_12			13
#define	SPELL_ATTRIB_ITEMLINK	14
// 14 is misc.. sometimes used for:
// SpellItemEnchantment.dbc
#define	SPELL_ATTRIB_MISC			15
#define SPELL_ATTRIB_SPELLLINK	16
#define SPELL_ATTRIBS			17

#define DBC_SPELL_MINDMG 		62//71
#define DBC_SPELL_MAXDMG 		74//59

#define DBC_SPELL_DURATION_ID	28
//SpellDuration.dbc
#define DBC_SPELLDURATION_MINTIME     1
#define DBC_SPELLDURATION_PERLEVEL    2
#define DBC_SPELLDURATION_MAXTIME     3
// or 24 or 25
//TaxiNodes
#define DBC_TAXINODE_MAPID			  1
#define DBC_TAXINODE_X				  2
#define DBC_TAXINODE_Y				  3
#define DBC_TAXINODE_Z				  4
#define DBC_TAXINODE_Name			  5
#define DBC_TAXINODE_Flag			  13
//TaxiPath
#define DBC_TAXIPATH_FromTaxiNode	  1
#define DBC_TAXIPATH_ToTaxiNode		  2
#define DBC_TAXIPATH_Cost			  3
//TaxiPathNode
#define DBC_TAXIPNODE_PathID			  1
#define DBC_TAXIPNODE_NodeID			  2
#define DBC_TAXIPNODE_MapID			  3
#define DBC_TAXIPNODE_X				  4
#define DBC_TAXIPNODE_Y				  5
#define DBC_TAXIPNODE_Z				  6
#define DBC_TAXIPNODE_FLAGS			  7
#define DBC_SPELL_CAST_TIME		17
//WorldMapOverlay
#define DBC_WORLDMAPOVERLAY_ID 1
#define DBC_WORLDMAPOVERLAY_WORLDMAPAREAID 2
#define DBC_WORLDMAPOVERLAY_AREATABLEID 3
#define DBC_WORLDMAPOVERLAY_NAME 9
#define DBC_WORLDMAPOVERLAY_AREAW 10
#define DBC_WORLDMAPOVERLAY_AREAH 11
#define DBC_WORLDMAPOVERLAY_DRAWX 16
#define DBC_WORLDMAPOVERLAY_DRAWY 17

#define DBC_AREATEABLE_ID 1
#define DBC_AREATEABLE_MAP 2
#define DBC_AREATEABLE_ZONE 3
#define DBC_AREATEABLE_EXPLOREFLAG 4

#define DBC_WORLDMAPAREA_ID 1
#define DBC_WORLDMAPAREA_MAP 2
#define DBC_WORLDMAPAREA_AREATABLEID 3
#define DBC_WORLDMAPAREA_NAME 4
#define DBC_WORLDMAPAREA_AREAVERTEXY1 5
#define DBC_WORLDMAPAREA_AREAVERTEXY2 6
#define DBC_WORLDMAPAREA_AREAVERTEXX1 7
#define DBC_WORLDMAPAREA_AREAVERTEXX2 8

// 0 STR 1 AGI 2 STA 3 INT 4 SPIRIT
// 1 HOLY 2 FIRE 3 NATURE 4 COLD 5 SHADOW

// Emotes section
#define DBC_EMOTES_ANIM		2

#endif // DBCHANDLER_H
