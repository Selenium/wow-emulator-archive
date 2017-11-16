#ifndef WOWPYTHONSERVER_SPELL_H
#define WOWPYTHONSERVER_SPELL_H

#include "UpdateMask.h"
#include "Character.h" 

struct SpellInformation {
	uint32 Id;			//index 0
	uint32 School;		// fire, arcane, etc.
	uint32 C;			//
	uint32 D;			//
	uint32 E;			//
	uint32 F;			//index 5
	uint32 G;			//
	uint32 H;			//
	uint32 I;			//
	uint32 J;			//
	uint32 K;			//index 10
	uint32 L;			//
	uint32 M;			//
	uint32 N;			//
	uint32 CastTime;	//
	uint32 P;			//index 15
	uint16 CoolDown;	//
	uint32 R;			//
	uint32 S;			//
	uint32 T;			//
	uint32 U;			//index 20
	uint32 V;			//
	uint32 W;			//
	uint32 X;			//
	uint32 PlayerLevel;//
	uint32 MaxLevel;	//index 25
	uint32 Duration;	//
	uint32 PowerType;	//
	uint32 ManaCost;	//Should prob. be named PowerCost, but ManaCost will do for now
	uint32 ManaCostPerLevel;//Should prob. be named PowerCostPerLevel, but ManaCostPerLevel will do for now
	uint32 AE;			//index 30
	uint32 AF;			//
	uint32 Range;		//
	uint32 AH;			//
	uint32 AI;			//
	uint32 AJ;			//index 35
	uint32 AK;			//
	uint32 AL;			//
	uint32 AM;			//
	uint32 AN;			//
	uint32 AO;			//index 40
	uint32 AP;			//
	uint32 AQ;			//
	uint32 AR;			//
	uint32 AS;			//
	uint32 AT;			//index 45
	uint32 AU;			//
	uint32 AV;			//
	uint32 AW;			//
	uint32 AX;			//
	uint32 AY;			//index 50
	uint32 AZ;			//
	uint32 BA;			//
	uint32 BB;			//
	uint32 BC;			//
	uint32 BD;			//index 55
	uint32 BE;			//
	uint32 BF;			//
	uint32 BG;			//
	uint32 RandomPercentDmg;//
	uint32 BI;			//index 60
	uint32 BJ;			//
	uint32 BK;			//
	uint32 BL;			//
	uint32 BM;			//
	uint32 BN;			//index 65
	uint32 BO;			//
	uint32 BP;			//
	uint32 Speed;		//
	uint32 BR;			//
	uint32 BS;			//index 70
	uint32 DmgPlus1;	//
	uint32 BU;			//
	uint32 BV;			//
	uint32 BW;			//
	uint32 BX;			//index 75
	uint32 BY;			//
	uint32 BZ;			//
	uint32 CA;			//
	uint32 CB;			//
	uint32 CC;			//index 80
	uint32 Radius;		//
	uint32 CE;			//
	uint32 CF;			//
	uint32 CG;			//
	uint32 CH;			//index 85
	uint32 CI;			//
	uint32 CJ;			//
	uint32 CK;			//
	uint32 CL;			//
	uint32 CM;			//index 90
	uint32 CN;			//
	uint32 CO;			//
	uint32 CP;			//
	uint32 CQ;			//
	uint32 CR;			//index 95
	uint32 CS;			//
	uint32 CT;			//
	uint32 CU;			//
	uint32 CV;			//
	uint32 CW;			//index 100
	uint32 CX;			//
	uint32 CY;			//
	uint32 CZ;			//
	uint32 DA;			//
	uint32 DB;			//index 105
	uint32 DC;			//
	uint32 DD;			//
	uint32 DE;			//
	uint32 DF;			//
	uint32 DG;			//index 110
	char *Name;			//
	uint32 DI;			//
	uint32 DJ;			//
	uint32 DK;			//
	uint32 DL;			//index 115
	uint32 DM;			//
	uint32 DN;			//
	uint32 DO;			//
	uint32 DP;			//
	char *Rank;			//index 120
	uint32 DR;			//
	uint32 DS;			//
	uint32 DT;			//
	uint32 DU;			//
	uint32 DV;			//index 125
	uint32 DW;			//
	uint32 DX;			//
	uint32 DY;			//
	char *Description;	//
	uint32 EA;			//index 130
	uint32 EB;			//
	uint32 EC;			//
	uint32 ED;			//
	uint32 EE;			//
	uint32 EF;			//index 135
	uint32 EG;			//
	uint32 EH;			//
	char *EI;			//Some short damage description (Ex: $s1 damage every $t1 seconds.)
	uint32 EJ;			//
	uint32 EK;			//index 140
	uint32 EL;			//
	uint32 EM;			//
	uint32 EN;			//
	uint32 EO;			//
	uint32 EP;			//index 145
	uint32 EQ;			//
	uint32 ER;			//
	uint32 ES;			//
	uint32 SpellId;		//
	uint32 spell_type;	//index 150 - spell_type: self-, multi-, single-target, etc. ( 1 is single target / 2 is multi target / 3 is self healing / and 4 should be damage absorb)
	uint32 replenish_type;	//mana_type: heal life - 1 - or mana - 2 - ? used by potions and eating/drinking
	uint32 addDuration; 
	uint32 addDmg; 
	uint32 race; 

};

struct UnitPowerType {
	UnitUpdateFields UNIT_FIELD_POWER;
	UnitUpdateFields UNIT_FIELD_MAXPOWER;
};

enum SpellType {
	TARGET_UNDEFINED = 0,
	SINGLE_TARGET = 1,
	MULTI_TARGET = 2,
	SELF_HEAL = 3,
	DAMAGE_ABSORB = 4,
	POTIONS = 5,
	TARGET_HEAL = 6,
	MANA_SHIELD = 7, 
	AURA = 8, 
	SEAL = 9, 
	SUMMON = 10 
};

#endif
