// Copyright (C) 2004 Team Python
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "DatabaseInterface.h"
#include "Sockets.h"
#include "mysql.h"
#include "Character.h"
#include "Log.h"
#include "Errors.h"
#include "Path.h"
#include "Quest.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "Item.h"
#include "Database.h"
#include "ChatHandler.h"
#include "../wowpython/version.h"
extern int dbfixe;
   

	SpellInformation DatabaseInterface::GetSpellInformation( uint32 spellid ) {
		SpellInformation spellinfo;
		Get_Spell_Information( spellid, spellinfo );
		return spellinfo;
	}

	void DatabaseInterface::Get_Spell_Information( uint32 spellid, SpellInformation &SpellInfo) {
		//let's go over how the method works:
		//	1) spellid is a numeric value of the spell the user wants
		//  2) SpellInfo is the info that is returned to the calling function
		//  3) We build up a SQL query:
		//		a) "SELECT * FROM spells s WHERE ´Spell Id´ = spellid;"
		//		b) run query
		//	4) Store the result in the data structure from (2)
		//	5) Clean up used database resources
		std::stringstream ss;
        ss << " select * from spells s where s.ID = "
            << spellid; 
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        uint16 numrows = (uint16)mysql_num_rows( res );
        MYSQL_ROW row;
		char *fCaller, *fInformation;
        for( uint32 a = 0; a < numrows; a++ ) {

			fCaller = "GetSpellInformation";
			fInformation = "fetching row";
			//OutputLog ( fCaller, fInformation );

            row = mysql_fetch_row( res );

			fInformation = "Storing data in struct (SpellInformation)";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.Id = NULLToNumeric( row[0] );
			SpellInfo.School = NULLToNumeric( row[1] );
			SpellInfo.C = NULLToNumeric( row[2] );
			SpellInfo.D = NULLToNumeric( row[3] );
			SpellInfo.E = NULLToNumeric( row[4] );
			SpellInfo.F = NULLToNumeric( row[5] );
			SpellInfo.G = NULLToNumeric( row[6] );
			SpellInfo.H = NULLToNumeric( row[7] );
			SpellInfo.I = NULLToNumeric( row[8] );
			SpellInfo.J = NULLToNumeric( row[9] );
			SpellInfo.K = NULLToNumeric( row[10] );

			fInformation = "row 0 - 10 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.L = NULLToNumeric( row[11] );
			SpellInfo.M = NULLToNumeric( row[12] );
			SpellInfo.N = NULLToNumeric( row[13] );
			SpellInfo.CastTime = NULLToNumeric( row[14] );
			SpellInfo.P = NULLToNumeric( row[15] );
			SpellInfo.CoolDown = NULLToNumeric( row[16] );
			SpellInfo.R = NULLToNumeric( row[17] );
			SpellInfo.S = NULLToNumeric( row[18] );
			SpellInfo.T = NULLToNumeric( row[19] );
			SpellInfo.U = NULLToNumeric( row[20] );

			fInformation = "row 11 - 20 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.V = NULLToNumeric( row[21] );
			SpellInfo.W = NULLToNumeric( row[22] );
			SpellInfo.X = NULLToNumeric( row[23] );
			SpellInfo.PlayerLevel = NULLToNumeric( row[24] );
			SpellInfo.MaxLevel = NULLToNumeric( row[25] );
			SpellInfo.Duration = NULLToNumeric( row[26] );
			SpellInfo.PowerType = NULLToNumeric( row[27] );
			SpellInfo.ManaCost = NULLToNumeric( row[28] );
			SpellInfo.ManaCostPerLevel = NULLToNumeric( row[29] );
			SpellInfo.AE = NULLToNumeric( row[30] );

			fInformation = "row 21 - 30 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.AF = NULLToNumeric( row[31] );
			SpellInfo.Range = NULLToNumeric( row[32] );
			SpellInfo.AH = NULLToNumeric( row[33] );
			SpellInfo.AI = NULLToNumeric( row[34] );
			SpellInfo.AJ = NULLToNumeric( row[35] );
			SpellInfo.AK = NULLToNumeric( row[36] );
			SpellInfo.AL = NULLToNumeric( row[37] );
			SpellInfo.AM = NULLToNumeric( row[38] );
			SpellInfo.AN = NULLToNumeric( row[39] );
			SpellInfo.AO = NULLToNumeric( row[40] );

			fInformation = "row 31 - 40 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.AP = NULLToNumeric( row[41] );
			SpellInfo.AQ = NULLToNumeric( row[42] );
			SpellInfo.AR = NULLToNumeric( row[43] );
			SpellInfo.AS = NULLToNumeric( row[44] );
			SpellInfo.AT = NULLToNumeric( row[45] );
			SpellInfo.AU = NULLToNumeric( row[46] );
			SpellInfo.AV = NULLToNumeric( row[47] );
			SpellInfo.AW = NULLToNumeric( row[48] );
			SpellInfo.AX = NULLToNumeric( row[49] );
			SpellInfo.AY = NULLToNumeric( row[50] );

			fInformation = "row 41 - 50 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.AZ = NULLToNumeric( row[51] );
			SpellInfo.BA = NULLToNumeric( row[52] );
			SpellInfo.BB = NULLToNumeric( row[53] );
			SpellInfo.BC = NULLToNumeric( row[54] );
			SpellInfo.BD = NULLToNumeric( row[55] );
			SpellInfo.BE = NULLToNumeric( row[56] );
			SpellInfo.BF = NULLToNumeric( row[57] );
			SpellInfo.BG = NULLToNumeric( row[58] );
			SpellInfo.RandomPercentDmg = NULLToNumeric( row[59] );
			SpellInfo.BI = NULLToNumeric( row[60] );

			fInformation = "row 51 - 60 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.BJ = NULLToNumeric( row[61] );
			SpellInfo.BK = NULLToNumeric( row[62] );
			SpellInfo.BL = NULLToNumeric( row[63] );
			SpellInfo.BM = NULLToNumeric( row[64] );
			SpellInfo.BN = NULLToNumeric( row[65] );
			SpellInfo.BO = NULLToNumeric( row[66] );
			SpellInfo.BP = NULLToNumeric( row[67] );
			SpellInfo.Speed = NULLToNumeric( row[68] );
			SpellInfo.BR = NULLToNumeric( row[69] );
			SpellInfo.BS = NULLToNumeric( row[70] );

			fInformation = "row 61 - 70 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.DmgPlus1 = NULLToNumeric( row[71] );
			SpellInfo.BU = NULLToNumeric( row[72] );
			SpellInfo.BV = NULLToNumeric( row[73] );
			SpellInfo.BW = NULLToNumeric( row[74] );
			SpellInfo.BX = NULLToNumeric( row[75] );
			SpellInfo.BY = NULLToNumeric( row[76] );
			SpellInfo.BZ = NULLToNumeric( row[77] );
			SpellInfo.CA = NULLToNumeric( row[78] );
			SpellInfo.CB = NULLToNumeric( row[79] );
			SpellInfo.CC = NULLToNumeric( row[80] );

			fInformation = "row 71 - 80 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.Radius = NULLToNumeric( row[81] );
			SpellInfo.CE = NULLToNumeric( row[82] );
			SpellInfo.CF = NULLToNumeric( row[83] );
			SpellInfo.CG = NULLToNumeric( row[84] );
			SpellInfo.CH = NULLToNumeric( row[85] );
			SpellInfo.CI = NULLToNumeric( row[86] );
			SpellInfo.CJ = NULLToNumeric( row[87] );
			SpellInfo.CK = NULLToNumeric( row[88] );
			SpellInfo.CL = NULLToNumeric( row[89] );
			SpellInfo.CM = NULLToNumeric( row[90] );

			fInformation = "row 81 - 90 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.CN = NULLToNumeric( row[91] );
			SpellInfo.CO = NULLToNumeric( row[92] );
			SpellInfo.CP = NULLToNumeric( row[93] );
			SpellInfo.CQ = NULLToNumeric( row[94] );
			SpellInfo.CR = NULLToNumeric( row[95] );
			SpellInfo.CS = NULLToNumeric( row[96] );
			SpellInfo.CT = NULLToNumeric( row[97] );
			SpellInfo.CU = NULLToNumeric( row[98] );
			SpellInfo.CV = NULLToNumeric( row[99] );
			SpellInfo.CW = NULLToNumeric( row[100] );

			fInformation = "row 91 - 100 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.CX = NULLToNumeric( row[101] );
			SpellInfo.CY = NULLToNumeric( row[102] );
			SpellInfo.CZ = NULLToNumeric( row[103] );
			SpellInfo.DA = NULLToNumeric( row[104] );
			SpellInfo.DB = NULLToNumeric( row[105] );
			SpellInfo.DC = NULLToNumeric( row[106] );
			SpellInfo.DD = NULLToNumeric( row[107] );
			SpellInfo.DE = NULLToNumeric( row[108] );
			SpellInfo.DF = NULLToNumeric( row[109] );
			SpellInfo.DG = NULLToNumeric( row[110] );

			fInformation = "row 101 - 110 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.Name = (char *)( row[111] );	//char *Name
			SpellInfo.DI = NULLToNumeric( row[112] );
			SpellInfo.DJ = NULLToNumeric( row[113] );
			SpellInfo.DK = NULLToNumeric( row[114] );
			SpellInfo.DL = NULLToNumeric( row[115] );
			SpellInfo.DM = NULLToNumeric( row[116] );
			SpellInfo.DN = NULLToNumeric( row[117] );
			SpellInfo.DO = NULLToNumeric( row[118] );
			SpellInfo.DP = NULLToNumeric( row[119] );
			SpellInfo.Rank = (char*)( row[120] );	//char *Rank

			fInformation = "row 111 - 120 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.DR = NULLToNumeric( row[121] );
			SpellInfo.DS = NULLToNumeric( row[122] );
			SpellInfo.DT = NULLToNumeric( row[123] );
			SpellInfo.DU = NULLToNumeric( row[124] );
			SpellInfo.DV = NULLToNumeric( row[125] );
			SpellInfo.DW = NULLToNumeric( row[126] );
			SpellInfo.DX = NULLToNumeric( row[127] );
			SpellInfo.DY = NULLToNumeric( row[128] );
			SpellInfo.Description = (char*)( row[129] );//char *Description
			SpellInfo.EA = NULLToNumeric( row[130] );

			fInformation = "row 121 - 130 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.EB = NULLToNumeric( row[131] );
			SpellInfo.EC = NULLToNumeric( row[132] );
			SpellInfo.ED = NULLToNumeric( row[133] );
			SpellInfo.EE = NULLToNumeric( row[134] );
			SpellInfo.EF = NULLToNumeric( row[135] );
			SpellInfo.EG = NULLToNumeric( row[136] );
			SpellInfo.EH = NULLToNumeric( row[137] );
			SpellInfo.EI = (char*)( row[138] );
			SpellInfo.EJ = NULLToNumeric( row[139] );
			SpellInfo.EK = NULLToNumeric( row[140] );

			fInformation = "row 131 - 140 stored";
			//OutputLog ( fCaller, fInformation );

			SpellInfo.EL = NULLToNumeric( row[141] );
			SpellInfo.EM = NULLToNumeric( row[142] );
			SpellInfo.EN = NULLToNumeric( row[143] );
			SpellInfo.EO = NULLToNumeric( row[144] );
			SpellInfo.EP = NULLToNumeric( row[145] );
			SpellInfo.EQ = NULLToNumeric( row[146] );
			SpellInfo.ER = NULLToNumeric( row[147] );
			SpellInfo.ES = NULLToNumeric( row[148] );
			SpellInfo.SpellId = NULLToNumeric( row[149] );
			SpellInfo.spell_type = NULLToNumeric( row[150] );
			SpellInfo.replenish_type = NULLToNumeric( row[151] );
			SpellInfo.addDuration = NULLToNumeric( row[152] ); 
			SpellInfo.addDmg = NULLToNumeric( row[153] ); 
			SpellInfo.race = NULLToNumeric( row[154] ); 


			fInformation = "row 141 - 151 stored";
			//OutputLog ( fCaller, fInformation );
			//SpellInfo. = uint32((uint32)atof( row[] )); //<struct>.<field> = <value>;
        }
        mysql_free_result( res );

		fInformation = "mysql_free_result( res ) : Cleared";
		//OutputLog ( fCaller, fInformation );
	}

	uint32 DatabaseInterface::NULLToNumeric ( const char *input ) 
	{
		uint32 result;
		result = uint32((uint32)atof( input ));
		//OutputLog( "NULLToNumeric", (char *)input );
		for (int i=0;i<(int)strlen(input);i++)
		{
			if(input[i] == 0) 
			{
				//OutputLog ( "NULLToNumeric", "An empty value was found!" );
				result = 0;
				break;
			}
		}
		return result;
	}

uint32 DatabaseInterface::getNextTextID( uint32 tType , uint32 guid ) 
{
		std::stringstream P,Q,R;
		uint32 t;
		MYSQL_RES *res;
		MYSQL_ROW row;
		
		P << "SELECT npc_text.id FROM npc_text WHERE npc_text.guid =" << guid;
		doQuery( P.str( ).c_str( ) );
		res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
		printf("query done\n");
		
		if ( mysql_num_rows( res )  == 0)
		{
			printf("0 results\n");
			mysql_free_result( res );
			Q << "SELECT MAX(npc_text.id) FROM npc_text";
			doQuery( Q.str( ).c_str( ) );
			res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
			row = mysql_fetch_row( res );
			//maybe an assert to check if t == 0?
			t = atoi(row[0]) + 1;
			mysql_free_result( res );
			R << "INSERT INTO npc_text VALUES (" << t << "," << tType << "," << guid << ")";
			doQuery( R.str( ).c_str( ) );
			res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
		}
		else
		{
			printf("result\n");
			row = mysql_fetch_row( res );
			t = atoi(row[0]);
		}
		mysql_free_result( res );
		return t;

}
    
uint32 DatabaseInterface::getNPC_TEXT_TYPE( uint32 textID ) {
		std::stringstream Q;
		uint32 t = 0;
		Q << "SELECT npc_text.type FROM npc_text WHERE npc_text.id = " << textID;
		doQuery( Q.str( ).c_str( ) );
		MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
		t = atoi(mysql_fetch_row( res )[0]);
		mysql_free_result( res );
		//maybe an assert to check if t == 0?
		return t;
}
	
void DatabaseInterface::spawnSpiritHealers( ) {
/*		std::stringstream Q;
		Unit* pUnit;
		UpdateMask unitMask;
		wowWData data;
		
		Q << "select X,Y,Z,F,name_id,mapId,zoneId,faction_id from spirithealers";
		doQuery( Q.str( ).c_str( ) );
		MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
		MYSQL_ROW row;
		uint32 id = 0;
		uint32 name;
		while( row = mysql_fetch_row( res ) )
		{
			pUnit = new Unit();
			WorldServer::getSingletonPtr()->mObjectMgr.SetCreateUnitBits(unitMask);
			name = atoi(row[4]);
			printf("%s name is %d\n",row[4],name);
			pUnit->setMapId(atoi(row[5]));
			pUnit->setZone(atoi(row[6]));	
			data.clear();
			pUnit->setUpdateValue(OBJECT_FIELD_ENTRY, name);
			pUnit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.0f);    
    		pUnit->setUpdateValue(UNIT_FIELD_DISPLAYID, 5233);
    		pUnit->setUpdateValue(UNIT_NPC_FLAGS , 1);
    		pUnit->setUpdateValue(UNIT_FIELD_FACTIONTEMPLATE , atoi(row[7]));
    		pUnit->setUpdateValue(UNIT_FIELD_HEALTH, 100 + 30*(60));
    		pUnit->setUpdateValue(UNIT_FIELD_MAXHEALTH, 100 + 30*(60));
    		pUnit->setUpdateValue(UNIT_FIELD_LEVEL , 60);
    		pUnit->setUpdateFloatValue(UNIT_FIELD_COMBATREACH , 1.5f);
    		pUnit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE ,  5.0f);
    		pUnit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE , 8.0f);
    		pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME, 1900);
    		pUnit->setUpdateValue(UNIT_FIELD_BASEATTACKTIME+1, 2000);
    		pUnit->setUpdateFloatValue(UNIT_FIELD_BOUNDINGRADIUS, 2.0f);

        uint8 *sname = WorldServer::getSingleton().getCreatureName(name);
        if( !sname ) sname = (uint8 *)"ERROR_NO_CREATURENAME_FOR_ENTRY";

        pUnit->Create(WorldServer::getSingletonPtr()->m_hiCreatureGuid++, sname,
            atof(row[0]), atof(row[1]), atof(row[2]), atof(row[3]));

    		pUnit->CreateObject(&unitMask, &data, 0);

    		// add to the world list of creatures
    		WPAssert( pUnit->getGUID() != 0 );
    		WorldServer::getSingletonPtr()->addCreature(pUnit);
			
    		// send create message to everyone
    		WorldServer::getSingletonPtr()->SendGlobalMessage(&data);
    		saveCreature(pUnit);                   
		}
		mysql_free_result( res ); */
}
		
uint32 DatabaseInterface::getGlobalTaxiNodeMask( uint32 curloc ) {
		std::stringstream TaxiMask;
			TaxiMask << "SELECT taxipath.destination FROM taxipath WHERE ( ( taxipath.source =" << curloc << " ) )";
		doQuery( TaxiMask.str( ).c_str( ) );
	    MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        uint32 mask = 0;
        while( row = mysql_fetch_row( res ) ) {
            mask |= 1 << ( atoi(row[0]) - 1 );
        }
        mysql_free_result( res );
        return mask;
}
    
uint32 DatabaseInterface::getNearestTaxiNode( float x, float y, float z, uint16 continent ) {
        std::stringstream Q;
         Q << " SELECT DISTINCT taxinodes.id, taxinodes.x, taxinodes.y, taxinodes.z FROM taxipath "
              " INNER JOIN taxinodes ON (taxipath.source = taxinodes.ID),  taxipathnodes "
              " WHERE    (    (taxipathnodes.continent = "
              << continent << " )    and    (taxipathnodes.index = 0)    and     (taxipathnodes.path = taxipath.id)   ) ";
        doQuery( Q.str( ).c_str( ) );
        uint32 nearest = 0;
        float distance = -1;
        float nx, ny, nz, nd;
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        while( row = mysql_fetch_row( res ) ) {
            nx = float( atof(row[1]) ) - x;
            ny = float( atof(row[2]) ) - y;
            nz = float( atof(row[3]) ) - z;
            nd = nx * nx + ny * ny + nz * nz;
            if( nd < distance || distance < 0 ) {
                distance = nd;
                nearest = atoi(row[0]);
            }
        }
        mysql_free_result( res );
        return nearest;
}
    
uint32 DatabaseInterface::getPath( uint32 source, uint32 destination ) {
        std::stringstream ss;
        ss << " select ID from taxipath "
            << " where source = " << source
            << " and destination = " << destination;
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        uint32 path = atoi(mysql_fetch_row( res )[0]);
        mysql_free_result( res );
        return path;
}

uint32 DatabaseInterface::getTaxiPrice( uint32 source, uint32 destination ) {
    std::stringstream ss;
    ss << " select price from taxipath "
       << " where source = " << source
       << " and destination = " << destination;
    doQuery( ss.str( ).c_str( ) );
    MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
    uint32 price = atoi(mysql_fetch_row( res )[0]);
    mysql_free_result( res );
    return price;
}

void DatabaseInterface::getTaxiDest( uint32 node, float &x, float &y, float &z ) {
    std::stringstream ss;
    ss << " select x,y,z from taxinodes "
       << " where id = " << node;
    doQuery( ss.str( ).c_str( ) );
    MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
    MYSQL_ROW row;
	if ( row = mysql_fetch_row( res ) )
	{
		x = (float)atof(row[0]); 
		y = (float)atof(row[1]); 
		z = (float)atof(row[2]);
	}
    mysql_free_result( res );
}
    
void DatabaseInterface::getPathNodes( uint32 path, Path *pathnodes ) {
        std::stringstream ss;
        ss << " SELECT X,Y,Z FROM taxipathnodes where path = "
            << path << " order by 'index' ";
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res = mysql_store_result( (MYSQL *)mDatabaseConnection );
        uint16 numrows = (uint16)mysql_num_rows( res );
        pathnodes->setLength( numrows );
        MYSQL_ROW row;
        for( uint32 a = 0; a < numrows; a++ ) {
            row = mysql_fetch_row( res );
            pathnodes->getNodes( )[ a ].x = (float)atof( row[ 0 ] );
            pathnodes->getNodes( )[ a ].y = (float)atof( row[ 1 ] );
            pathnodes->getNodes( )[ a ].z = (float)atof( row[ 2 ] );
        }
        mysql_free_result( res );
}
    
int DatabaseInterface::getTrainerSpellsCount( const uint32 *trainer ) {
        int answer;
		std::stringstream ss;
		const uint32 *guid = trainer; //pClient->getCurrentChar()->getSelectionPtr();
        ss << " select COUNT(*) as spellcount from trainers t INNER JOIN spells s ON t.spellGuid = s.ID where t.trainerGuid = "
            << guid[0] << " order by t.spellGuid "; 
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        row = mysql_fetch_row( res );
        if (row == NULL) {
            answer = 0;
        }
        else {
			answer = (int)atof ( row[0] );
            //answer = 1;
        }
        mysql_free_result( res );
        return answer;
}

int DatabaseInterface::getTrainerSpellsPrice( uint32 spellGuid, uint32 trainerGuid ) {
        int answer;
		std::stringstream ss;
        ss << " select t.price from trainers t where t.trainerGuid = "
            << trainerGuid << " and t.spellGuid = "
			<< spellGuid << " order by t.spellGuid "; 
		// select t.price from trainers where t.trainerGuid = <trainerGuid> and t.spellGuid = <spellGuid>
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        uint16 numrows = (uint16)mysql_num_rows( res );
        MYSQL_ROW row;
        for( uint32 a = 0; a < numrows; a++ ) {
            row = mysql_fetch_row( res );
			answer = int((uint32((uint32)atof ( row[ 0 ] )))); //set price
        }
        mysql_free_result( res );
        return answer;
}

int DatabaseInterface::addTrainerSpell ( const uint32 *trainer, uint32 iSpellGuid, uint32 iSpellPrice ) {
		const uint32 *guid = trainer; //pClient->getCurrentChar()->getSelectionPtr();
		char sql[512];
		sprintf(sql, "INSERT INTO trainers (`trainerGuid`, `spellGuid`, `price`) VALUES ('%u', '%i', '%i');", guid[0], (int)iSpellGuid, (int)iSpellPrice);
        doQuery( sql );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        /*MYSQL_ROW row;
        row = mysql_fetch_row( res );
        if (row == NULL) {
            answer = 0;
        }
        else {
            answer = 1;
        }*/
        mysql_free_result( res );
        return 0; //answer;
}

void DatabaseInterface::getTrainerSpells( Character * pChar, const uint32 *trainer, wowWData & data ) {
		/*
			sql: select * from trainers t INNER JOIN spells s ON t.spellGuid = s.ID where t.trainerGuid = <trainerGuid>;
			^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
			spell id:		2 (base-1 array) / 1 (base-0 array)
			level req.:		28 (base-1 array) / 27 (base-0 array)
			price:			3 (base-1 array) / 2 (base-0 array)
		*/
        std::stringstream ss;
		const uint32 *guid = trainer; //pClient->getCurrentChar()->getSelectionPtr();
		uint32 player_level, player_gold;
		player_level = pChar->getUpdateValue( UNIT_FIELD_LEVEL );
        player_gold = pChar->getUpdateValue( PLAYER_FIELD_COINAGE );
        ss << " select * from trainers t INNER JOIN spells s ON t.spellGuid = s.ID where t.trainerGuid = "
            << guid[0] << " order by t.spellGuid ";
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res = mysql_store_result( (MYSQL *)mDatabaseConnection );
        uint16 numrows = (uint16)mysql_num_rows( res );
        MYSQL_ROW row;
        for( uint32 a = 0; a < numrows; a++ ) {
            row = mysql_fetch_row( res );
			data << uint32((uint32)atof ( row[ 1 ] )); //spell id
			std::stringstream usedsql;
			usedsql << "SELECT COUNT(*) FROM char_spells WHERE spellId = " << row[ 1 ] << " AND charId = " << pChar->getGUID();
			doQuery( usedsql.str( ).c_str( ) );
			MYSQL_RES *resused = mysql_store_result( (MYSQL *)mDatabaseConnection );
			MYSQL_ROW rowused;
			rowused = mysql_fetch_row( resused );
			if((uint32)atof (rowused [ 0 ]) == 0) {
		    if(player_level>=uint32((uint32)atof ( row[ 27 ] ))) { //check if player is right level
				if(player_gold>=uint32((uint32)atof ( row[ 2 ] ))) { //check if player has money enough
					data << uint8(0); //ok (non zero = not ok)
				} else {
					data << uint8(1); //not ok
				}
			    } else {
				data << uint8(1); //not ok
			    }
			} else {
			    data << uint8(2); //used by character
			}
    			mysql_free_result( resused );
			data << uint32((uint32((uint32)atof ( row[ 2 ] )))); //set price
			data << uint32(0) << uint32(0);
			data << uint32((uint32((uint32)atof ( row[ 27 ] )))); //set required level
			data << uint32(0) << uint32(0) << uint32(0) << uint32(0) << uint8(0);
        }
        mysql_free_result( res );

		data << uint32(0x6c6c6548) << uint32(0x5220216f) << uint32(0x79646165);
        data << uint32(0x726f6620) << uint32(0x6d6f7320) << uint32(0x72742065);
        data << uint32(0x696e6961) << uint32(0x003f676e);
}
    
void DatabaseInterface::setCharacter( Character * diffChar ) 
{
	int i;
	char invtemp[30];
	WPAssert( diffChar );
	
	/*/LINA STAT
	diffChar->setUpdateValue(UNIT_FIELD_STAT0, diffChar->m_stat0);
	diffChar->setUpdateValue(UNIT_FIELD_STAT1, diffChar->m_stat1);
	diffChar->setUpdateValue(UNIT_FIELD_STAT2, diffChar->m_stat2);
	diffChar->setUpdateValue(UNIT_FIELD_STAT3, diffChar->m_stat3);
	diffChar->setUpdateValue(UNIT_FIELD_STAT4, diffChar->m_stat4);
	diffChar->setUpdateValue(UNIT_FIELD_HEALTH, diffChar->m_health);
	diffChar->setUpdateValue(UNIT_FIELD_MAXHEALTH, diffChar->m_health);
	diffChar->setUpdateValue(UNIT_FIELD_POWER1, diffChar->m_mana);
	diffChar->setUpdateValue(UNIT_FIELD_MAXPOWER1, diffChar->m_mana);
	//LINA STAT*/

        std::stringstream ss;
		std::string invstr;
        ss << "update characters set"
            " positionX = " << diffChar->m_positionX << ", "
            " positionY = " << diffChar->m_positionY << ", "
            " positionZ = " << diffChar->m_positionZ << ", "
            " orientation= " << diffChar->m_orientation << ", "
            " data = '";
            for( uint16 index = 0; index < UPDATE_BLOCKS; index ++ )
            {
                ss << diffChar->getUpdateValue(index) << " ";
            }
            ss << "', " << 
            " zoneId= " << diffChar->m_zoneId << ", "
            " mapId= " << diffChar->m_mapId  
            << " where guid = " << diffChar->m_guid[ 0 ];
        doQuery( ss.str( ).c_str( ) );
		invstr.empty();
		invstr = "delete from inventory where charGuid = ";
		sprintf(invtemp, "%d", diffChar->getGUID());
		invstr += invtemp;
        doQuery( invstr.c_str( ) );
		
		for(i = 0; i<39; i++)
		{
			if (diffChar->m_items[i].guid != 0)
			{
				invstr.empty();
				invstr = "INSERT INTO inventory (charGuid,inventorySlot,itemGuid,itemId) VALUES (";
				sprintf(invtemp, "%d", diffChar->getGUID());
				invstr += invtemp;
				invstr += ", ";
				sprintf(invtemp, "%d", i);
				invstr += invtemp;
				invstr += ", ";
				sprintf(invtemp, "%d", diffChar->m_items[i].guid);
				invstr += invtemp;
				invstr += ", ";
				sprintf(invtemp, "%d", diffChar->m_items[i].itemid);
				invstr += invtemp;
				invstr += " )";
				doQuery( invstr.c_str( ) );
			}
		}
        // save quest progress
        saveQuestStatus(diffChar);

        // Spells
        std::stringstream spellstr;
        spellstr << "DELETE FROM char_spells where charId=" << diffChar->getGUID();
        doQuery(spellstr.str().c_str());

        std::list<struct spells> spells = diffChar->getSpellList();
        std::list<struct spells>::iterator itr;
        for (itr = spells.begin(); itr != spells.end(); ++itr)
        {
            std::stringstream spellstr2;
            spellstr2 << "INSERT INTO char_spells (charId,spellId,slotId) VALUES "
                      << "(" << diffChar->getGUID() << ", " << itr->spellId << ", " << itr->slotId << ")";
            doQuery(spellstr2.str().c_str());
        }

		//START OF LINA ACTION BAR
        std::stringstream actionstr;
        actionstr << "DELETE FROM char_actions where charId=" << diffChar->getGUID();
        doQuery(actionstr.str().c_str());

        std::list<struct actions> actions = diffChar->getActionList();
        std::list<struct actions>::iterator itr2;
        for (itr2 = actions.begin(); itr2 != actions.end(); ++itr2)
        {
            char sql[256];
            sprintf(sql,"INSERT INTO char_actions (charId, button, action, type, misc) VALUES ('%u', '%u', '%u', '%u', '%u')\n", diffChar->getGUID(), itr2->button, itr2->action, itr2->type, itr2->misc);
            doQuery(sql);
        }
		//END OF LINA ACTION BAR
}
    
void DatabaseInterface::removeCharacter( Character * newChar ) 
{
        if( strcmp( (char * ) newChar->m_name, "RandomGuy" ) ) 
		{
            std::stringstream a; a << "delete from characters where guid = " << newChar->m_guid[ 0 ];
            doQuery( a.str( ).c_str( ) );

            std::stringstream b; b << "delete from char_spells where charid = " << newChar->m_guid[ 0 ];
            doQuery( b.str( ).c_str( ) );

            std::stringstream c; c << "delete from inventory where charGuid = " << newChar->m_guid[ 0 ];
            doQuery( c.str( ).c_str( ) );

            std::stringstream d; d << "delete from queststatus where playerId = " << newChar->m_guid[ 0 ];
            doQuery( d.str( ).c_str( ) );

			std::stringstream actions;
			actions << "delete from char_actions where charid = " << newChar->m_guid[ 0 ];
            doQuery( actions.str( ).c_str( ) );
        }
}
    
std::set< Character *> DatabaseInterface::enumCharacters( int account_id) 
{
		std::string invstr;
  		char invtemp[20];

        std::set< Character *> temp;
        std::stringstream ss;
        ss << "select * from characters where acct=" << (int)account_id << "";
	   	doQuery( ss.str( ).c_str( ) );

        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        if (!res) return temp;
        MYSQL_ROW row;
    	MYSQL_RES *invres;
        MYSQL_ROW invrow;
        Character * tempchar;

        while( row = mysql_fetch_row( res ) ) 
		{
            tempchar = new Character( );
            strcpy( (char *)tempchar->m_name, row[ 3 ] );
            
            uint16 length = strlen(row[2])+1;
            uint8 *data = new uint8[length];
            memcpy(data, row[2], length);
    
            tempchar->LoadUpdateValues(data);
            tempchar->m_zoneId = atoi( row[ 8 ] );
            tempchar->m_mapId = atoi( row[ 7 ] );
            tempchar->m_positionX = (float)atof( row[ 4 ] );
            tempchar->m_positionY = (float)atof( row[ 5 ] );
            tempchar->m_positionZ = (float)atof( row[ 6 ] );
            tempchar->m_orientation = (float)atof( row[9] );
    
    /*
            tempchar->m_outfitId = atoi( row[ 11 ] );
            tempchar->m_guildId = atoi( row[ 17 ] );
            tempchar->m_petInfoId = atoi( row[ 18 ] );
            tempchar->m_petLevel = atoi( row[ 19 ] );
            tempchar->m_petFamilyId = atoi( row[ 20 ] );
  */
 

            // Inventory
  		    invstr = "select * from inventory where charGuid=";
  		    sprintf(invtemp, "%d", (int)tempchar->m_guid[ 0 ]);
  		    invstr += invtemp;
  		    invstr += "";
  		    doQuery( invstr.c_str( ) );
  		    invres = mysql_store_result( (MYSQL *)mDatabaseConnection );
  		    while( invrow = mysql_fetch_row( invres ) ) {
			    if (atol(invrow[2]) == 0 || atol(invrow[3]) == 0) {
				    continue;
			    }
  			    tempchar->m_items[(int)atoi(invrow[1])].guid = (uint32)atol(invrow[2]);
  			    tempchar->m_items[(int)atoi(invrow[1])].itemid = (uint32)atol(invrow[3]);
  		    }

            // Spells
            std::stringstream spellstr;
            spellstr << "SELECT * FROM char_spells WHERE charId=" << tempchar->m_guid[0];
            doQuery(spellstr.str().c_str());
  		    MYSQL_RES *spellres = mysql_store_result( (MYSQL *)mDatabaseConnection );
            MYSQL_ROW spellrow;
  		    while( spellrow = mysql_fetch_row( spellres ) ) {
			    tempchar->addSpell(atoi(spellrow[2]), atoi(spellrow[3]));
  		    }

			//START OF LINA ACTION BAR
            std::stringstream actionstr;

            actionstr << "SELECT * FROM char_actions WHERE charId=" << tempchar->m_guid[0] << " ORDER BY button";
            doQuery(actionstr.str().c_str());
  		    MYSQL_RES *actionres = mysql_store_result( (MYSQL *)mDatabaseConnection );
            MYSQL_ROW actionrow;
  		    while( actionrow = mysql_fetch_row( actionres ) ) 
			{
			    tempchar->addAction(atoi(actionrow[1]), atoi(actionrow[2]), atoi(actionrow[3]), atoi(actionrow[4]));
  		    }
			mysql_free_result( actionres );
			//END OF LINA ACTION BAR

            mysql_free_result( spellres );
  		    mysql_free_result( invres );

            temp.insert( tempchar );
        }
        mysql_free_result( res );
        return temp;
}

// <WoW Chile Dev Team> Start Change
int DatabaseInterface::IsCharMoveExist(uint32 guid) {
        char query[300];
        strcpy(query,"");
        sprintf(query, "SELECT COUNT(*) FROM creatures_mov WHERE creatureId = '%u'", guid); 
        doQuery(query);
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        row = mysql_fetch_row( res );
		if( atoi(row[0]) > 0 ) //if not cero then mob can move
			return atoi(row[0]);
		else
			return 0;
	    mysql_free_result( res );
}
// <WoW Chile Dev Team> Stop Change

int DatabaseInterface::IsNameTaken(char * charname) {
        int answer;
        char query[300];
        strcpy(query,"");
    sprintf(query, "SELECT guid FROM characters WHERE name = '%s'", charname);
        doQuery(query);
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        row = mysql_fetch_row( res );
        if (row == NULL) {
            answer = 0;
        }
        else {
            answer = 1;
        }
        mysql_free_result( res );
        return answer;
}
    
int DatabaseInterface::GetNameGUID(char * charname) {
        int Guid=-1;
        char query[300];
        strcpy(query,"");
    sprintf(query, "SELECT guid FROM characters WHERE name = '%s'", charname);
        doQuery(query);
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        row = mysql_fetch_row( res );
        if (row != NULL) {
            Guid = atoi(row[0]);
        }
        mysql_free_result( res );
        return Guid;
}
    
// NOTE: not used anymore, but may be useful later
bool DatabaseInterface::GetPlayerNameFromGUID(uint32 guid, uint8 *name)
{
        std::stringstream ss;
    ss << "SELECT name FROM characters WHERE guid=" << guid;
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
    if (!res)
        return false;

    MYSQL_ROW row = mysql_fetch_row( res );
    if(!row)
        return false;
    
    strcpy((char*)name, row[0]);

    return true;
}

void DatabaseInterface::addCharacter( Character *newChar ) {
        std::stringstream ss;
        ss << "INSERT INTO characters "
           << "(data,name,acct,positionX,positionY,positionZ,orientation, zoneId, mapId,guid) "
           << "VALUES ('"; 
        
        for( uint16 index = 0; index < UPDATE_BLOCKS; index ++ )
        {
            ss << newChar->getUpdateValue(index) << " ";
        }
    
        ss << "', " 
           << "'" << newChar->m_name << "', "
           << newChar->m_accountId << ", "
           << (float)newChar->m_positionX << ", "
           << (float)newChar->m_positionY << ", "
           << (float)newChar->m_positionZ << ", "
           << (float)newChar->m_orientation << ", "
           << newChar->m_zoneId << ", "
           << newChar->m_mapId << ", "
           << newChar->getGUID() << " "
           << ")";
        
        doQuery( ss.str( ).c_str( ) );
}
    
    
int DatabaseInterface::doQuery( const char * query ) {
        Log::getSingleton( ).outString( (std::string("SQL: ") + query).c_str( ) );
        mysql_query( (MYSQL *)mDatabaseConnection, query );
        printf("%s", mysql_error((MYSQL*)mDatabaseConnection));
        return mysql_field_count( (MYSQL *)mDatabaseConnection );
}
    
    
// Logs in a client with username and password, or creates new account is username doesnt exist
int DatabaseInterface::Login(char* username, char* password, char* ip)
{
        Log::getSingleton( ).outString( "DB: Checking username..." );        
        char query[300];        
        strcpy(query, "");        
        sprintf(query, "SELECT * FROM accounts WHERE login='%s'", username);        
		//sprintf(query, "SELECT * FROM accounts WHERE login='%s' and password='%s'", username, password);
		//sprintf(query, "SELECT acct, gm FROM accounts WHERE login='%s' ", username);
		doQuery(query);        
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );        
        MYSQL_ROW row;            
            
    if (!res)
        return -2;

    if (res->row_count == 1)
	{ // Match!  
		row = mysql_fetch_row( res );
		int ret = atoi(row[0]);

			if(row[5]) //if ip, check to be sure
			{
				if(strcmp(ip,row[5]))
					ret = -2; //not set return to 2
				std::cout << "DBI: Login " << username << ", Connect IP: " << ip <<
					", DB IP: " << row[5] << std::endl;
			}
			else //else no ip found
			{
				std::cout << "DBI: Login " << username << ", Connect IP: " << ip <<
					", No DB IP" << std::endl;
				ret = -1; //set return to 1
			}
			if (!Database::getSingleton().isTestIP()) //if test ip/login off
			{
				std::cout << "DBI: WARNING *** TestIP OFF *** WARNING" << std::endl;
				ret = atoi(row[0]); //force return to row
			}

			// Server Full ? (Not For GM's)
			if (WorldServer::getSingleton().GetClientsConnected() >
				static_cast<uint32>(playerlimit) && !atoi(row[3]))
			{
				std::cout << "REFUSED CONNECTION (SERVER FULL): Login " << username <<
					std::endl;
				return -2;
			}
		return ret;       
		}     
	else 
	{
		// Check the config if we should auto create accounts
		if (!Database::getSingleton().isAutoCreateAccts()) return -3;

		// create new account withusername and password            
		sprintf(query, "INSERT INTO accounts (login, password, realpassword) VALUES ('%s', '%s', '%s')", username, password, "none");            
		doQuery(query);                

		// select the new account to get its ID #            
		sprintf(query, "SELECT * FROM accounts WHERE login='%s' AND password='%s'", username, password);            
		doQuery(query);            

		MYSQL_RES *login_res = mysql_store_result( (MYSQL *)mDatabaseConnection );            
		row = mysql_fetch_row( login_res );            

		return atoi(row[0]);        
	}            
	return -1;    
}

uint64 DatabaseInterface::doQueryId( const char * query ) {
        Log::getSingleton( ).outString( (std::string("SQL: ") + query).c_str( ) );
        mysql_query( (MYSQL *)mDatabaseConnection, query );
        printf("%s", mysql_error((MYSQL*)mDatabaseConnection));
        return mysql_insert_id( (MYSQL *)mDatabaseConnection );
}


int DatabaseInterface::getAccountLvl(int account_id)
{
        std::stringstream ss;
        ss << "SELECT gm FROM accounts WHERE acct=" << account_id;
        doQuery(ss.str().c_str());
        MYSQL_RES *res = mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        if (res->row_count >= 1){
            row = mysql_fetch_row(res);
            return atoi(row[0]);
        }

        // account id not found, default to 0
        return 0;
}

    
DatabaseInterface::DatabaseInterface( void * db ) : mDatabaseConnection( (MYSQL *)db ) { }
    
DatabaseInterface::~DatabaseInterface( ) {
        mysql_close( (MYSQL *)mDatabaseConnection );
}

void DatabaseInterface::updateCreature(Unit *pUnit)
{
		 std::stringstream ss;
         ss << "UPDATE creatures SET" << ""
            << " name_id=" << pUnit->getUpdateValue(OBJECT_FIELD_ENTRY) << ","
			<< " positionX=" << pUnit->m_positionX << ","
			<< " positionY=" << pUnit->m_positionY << ","
			<< " positionZ=" << pUnit->m_positionZ << ","
			<< " orientation=" << pUnit->m_orientation << ","
			<< " mapId=" << pUnit->m_mapId << ","
			<< " zoneId=" << pUnit->m_zoneId << ","
			<< " data='";

            for( uint16 index = 0; index < UNIT_END; index++ )
            {
                ss << pUnit->getUpdateValue(index) << " ";
            }
			ss <<"' WHERE id=" << pUnit->m_guid[0] << "";
			
			doQuery( ss.str( ).c_str( ) );
    
       printf("%s", mysql_error((MYSQL*)mDatabaseConnection));


}

void DatabaseInterface::saveCreature(Unit *pUnit)
{
        // then save all creatures
        std::stringstream ss;
        ss << "INSERT INTO creatures "
            "(name_id,positionX,positionY,positionZ,orientation,id,mapId,zoneId,data) "
            "VALUES ("
            "" << pUnit->getUpdateValue(OBJECT_FIELD_ENTRY) << ", "
            << pUnit->m_positionX << ", "
            << pUnit->m_positionY << ", "
            << pUnit->m_positionZ << ", "
            << pUnit->m_orientation << ", "
            << pUnit->m_guid[0] << ", "
            << pUnit->m_mapId << ", "
			<< pUnit->m_zoneId << ", "
            << "'";

            for( uint16 index = 0; index < UNIT_END; index ++ )
            {
                ss << pUnit->getUpdateValue(index) << " ";
            }

            ss << "') ";

        doQuery( ss.str( ).c_str( ) );
    
        printf("%s", mysql_error((MYSQL*)mDatabaseConnection));
}
    
void DatabaseInterface::loadCreatureNames(std::map< uint32, uint8*> & m_names)
{
        std::stringstream ss;
        ss << "SELECT * FROM creature_names";
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        
    char *name;
        while( row = mysql_fetch_row( res ) ) {
        name = new char[strlen(row[1])+1];
        strcpy(name, row[1]);
        m_names[ atol(row[0]) ] = (uint8*)name;
    }
}
    
void DatabaseInterface::saveCreatureNames(std::map< uint32, uint8*> p_names)
{
        std::stringstream ss2;
        ss2 << "DELETE FROM creature_names";
        doQuery( ss2.str( ).c_str( ) );
        for( std::map< uint32, uint8*>::iterator itr = p_names.begin( ); itr != p_names.end( ); ++ itr )
        {
            std::stringstream ss;
            ss << "INSERT INTO creature_names (name_id,creature_name) VALUES (" << itr->first << ", '" << itr->second << "')";
            doQuery( ss.str( ).c_str( ) );
        }
}


std::set<Unit*> DatabaseInterface::loadCreatures()
{
        std::set< Unit *> temp;
    MYSQL_RES *res, *res2;
    MYSQL_ROW row, row2;
    Unit *tempunit;
	int32 maxhealth;

    doQuery( "SELECT * FROM creatures" );
    res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
    if(!res)
        return temp;
    
    while( row = mysql_fetch_row( res ) )
    {
            uint16 length = strlen(row[7])+1;
            uint8 *data = new uint8[length];
            memcpy(data, row[7], length);
    
            uint8 * name = WorldServer::getSingleton().getCreatureName(atol(row[8]));
        if( !name )
            name = (uint8 *)"ERROR_NO_CREATURENAME_FOR_ENTRY";

            tempunit = new Unit();
            tempunit->Create(atol(row[0]), name, (float)atof(row[1]), (float)atof(row[2]), (float)atof(row[3]), (float)atof(row[4]));
            tempunit->setZone((uint16)atol(row[5]));
            tempunit->setMapId((uint16)atol(row[6]));
			tempunit->m_moveRandom = atoi(row[9]) > 0;
			tempunit->m_moveRun = atoi(row[10]) > 0;
			tempunit->m_aggressive = (uint8)atoi(row[11]); //LINA
			tempunit->LoadUpdateValues(data);

	
	
			// BEGIN FIX MOBS STATS
			if (dbfixe == 1)
			{
			float fLevel = (float) tempunit->getUpdateValue(UNIT_FIELD_LEVEL);
			tempunit->setUpdateValue(UNIT_FIELD_HEALTH, (30 + 20*fLevel));
			tempunit->setUpdateValue(UNIT_FIELD_MAXHEALTH, (30 + 20*fLevel));
			float fflag = (float) tempunit->getUpdateValue(UNIT_NPC_FLAGS);
			if (fflag = 1)
			{
				if (fLevel <= 1)
				{
					tempunit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.75f);
				}
				else if (fLevel > 1 && fLevel <= 3)
				{
					tempunit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.85f);
				}
				else if (fLevel > 3 && fLevel <= 6)
				{
					tempunit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 0.95f);
				}
				else if (fLevel > 6 && fLevel <= 15)
				{
					tempunit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.1f);
				}
				else
				{
					tempunit->setUpdateFloatValue(OBJECT_FIELD_SCALE_X, 1.25f);
				}
			}
			updateCreature(tempunit);
			}
/*
			tempunit->setUpdateFloatValue(UNIT_FIELD_MINDAMAGE, 4.0f+fLevel);
			tempunit->setUpdateFloatValue(UNIT_FIELD_MAXDAMAGE, 4.0f+fLevel+fLevel);

			updateCreature(tempunit);
			// END FIX MONSTER STATS

	*/
			
			
		if (tempunit->getUpdateValue( UNIT_NPC_FLAGS ) & 4) // vendor
        {
            // load his goods

            std::stringstream query;
            query << "SELECT * FROM vendors WHERE vendorGuid=" << tempunit->getGUID();

            doQuery( query.str().c_str( ) );
            res2 = mysql_store_result( (MYSQL *)mDatabaseConnection );
            if(res2)
            {
                while( row2 = mysql_fetch_row( res2 ) )
                {
                    if (tempunit->getItemCount() >= 128)
                    {
                        // this should never happen unless someone has been fucking with the dbs
                        // complain and break :P
						Log::getSingleton( ).outString( "Vendor has too many items. Check the DB!" );
						break;
					}

                    tempunit->setItemId(tempunit->getItemCount() , (uint32)atol(row2[1]));
                    tempunit->setItemAmount(tempunit->getItemCount() , (uint32)atoi(row2[2]));
					tempunit->increaseItemCount();
				}

                mysql_free_result( res2 );
            }
			}

        if (tempunit->getUpdateValue( UNIT_NPC_FLAGS ) & 2)  // questmaster
        {
                // load assigned quests

            std::stringstream query;
            query << "SELECT * FROM creaturequestrelation WHERE creatureId=" << tempunit->getGUID() << " ORDER BY questId";
            doQuery( query.str( ).c_str( ) );

            res2 =  mysql_store_result( (MYSQL *)mDatabaseConnection );
            if(res2)
            {
                while( row2 = mysql_fetch_row( res2 ) )
                    tempunit->addQuest(atol(row2[1]));

                mysql_free_result( res2 );
                }
            }

        std::stringstream query;
        query << "SELECT X,Y,Z FROM creatures_mov WHERE creatureId=" << tempunit->getGUID();
        doQuery( query.str().c_str( ) );

        res2 = mysql_store_result( (MYSQL *)mDatabaseConnection );
        if(res2)
			{				
            while( row2 = mysql_fetch_row( res2 ) )
                tempunit->addWaypoint(atof(row2[0]), atof(row2[1]), atof(row2[2]));

            mysql_free_result( res2 );
			}

            temp.insert(tempunit);

		if((tempunit->getDeathState() == CORPSE) || tempunit->getUpdateValue(UNIT_FIELD_HEALTH) <= 0)
		{
			printf("Reviving NPC in dead state\n");
			maxhealth = tempunit->getUpdateValue(UNIT_FIELD_MAXHEALTH);
			tempunit->setDeathState(ALIVE);
			tempunit->setUpdateValue(UNIT_FIELD_HEALTH,maxhealth);
			updateCreature(tempunit);
		}
       }

        mysql_free_result( res );

		return temp;
}
    
    
void DatabaseInterface::setHighestGuids()
{
        uint32 max=0;
        uint32 maxchar=0,maxcreature=0;
        doQuery( "SELECT MAX(guid) FROM characters" );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        if( res ) {
            MYSQL_ROW row;
            row = mysql_fetch_row( res );
            if (row[0])
                WorldServer::getSingleton().m_hiCharGuid = atol(row[0])+1;
        }
    
        mysql_free_result( res );
    
        doQuery( "SELECT MAX(id) FROM creatures" );
        res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        if( res ) {
            MYSQL_ROW row;
            row = mysql_fetch_row( res );
            if (row[0])
                WorldServer::getSingleton().m_hiCreatureGuid = atol(row[0])+1;
        }
        mysql_free_result( res );
        doQuery( "SELECT MAX(itemGuid) FROM inventory" );
        res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
		if( res ) {
            MYSQL_ROW row1;
            row1 = mysql_fetch_row( res );
			if (row1[0]) {
                WorldServer::getSingleton().m_hiItemGuid = atol(row1[0])+1;
			}
		}   
        mysql_free_result( res );
}
    
void DatabaseInterface::loadItems()
{
    	std::stringstream ss;
        ss << "SELECT * FROM items";
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        Item *pItem;
    	int i;
    	while( row = mysql_fetch_row( res ) ) {
            if( atol(row[0]) ) {
    		    pItem = new Item;
    		    pItem->Create(0, atol(row[0]));
    		    pItem->Class = atol(row[1]);
    		    pItem->SubClass = atol(row[2]);
    		    pItem->name1 = row[3];
    		    pItem->name2 = row[4];
    		    pItem->name3 = row[5];
    		    pItem->name4 = row[6];
    		    pItem->DisplayInfoID = atol(row[7]); 
    		    pItem->OverallQualityID = atol(row[8]); 
    		    pItem->Flags = atol(row[9]); 
    		    pItem->Buyprice = atol(row[10]); 
    		    pItem->Sellprice = atol(row[11]); 
    		    pItem->Inventorytype = atol(row[12]); 
    		    pItem->AllowableClass = atol(row[13]); 
    		    pItem->AllowableRace = atol(row[14]); 
    		    pItem->ItemLevel = atol(row[15]); 
    		    pItem->RequiredLevel = atol(row[16]); 
    		    pItem->RequiredSkill = atol(row[17]); 
    		    pItem->RequiredSkillRank = atol(row[18]); 
    		    pItem->MaxCount = atol(row[19]); 
    		    pItem->Stackable = atol(row[20]); 
    		    pItem->ContainerSlots = atol(row[21]);
    		    for(i = 0; i < 20; i+=2) {
    			    pItem->BonusStat[i/2] = atol(row[22 + i]);
    			    pItem->BonusAmount[i/2] = atol(row[23 + i]);
    		    }
    		    for(i = 0; i < 15; i+=3) {
    			    pItem->MinimumDamage[i/3] = atol(row[42 + +i]); 
    			    pItem->MaximumDamage[i/3] = atol(row[43 +i]);
    			    pItem->DamageType[i/3] = atol(row[44 + i]);
    		    }
    		    for(i = 0; i < 6; i++) {
    			    pItem->Resistances[i] = atol(row[57 + i]);
    		    }
    		    pItem->Delay = atol(row[63]); 
    		    pItem->AmmunitionType = atol(row[64]); 
    		    pItem->MaxDurability = atol(row[65]); 
    		    for(i = 0; i < 30; i+=6) {
    			    pItem->SpellID[i/6] = atol(row[66+i]);
    			    pItem->SpellTrigger[i/6] = atol(row[67+i]); 
    			    pItem->SpellCharges[i/6] = atol(row[68+i]);
    			    pItem->SpellCooldown[i/6] = atol(row[69+i]);
    			    pItem->SpellCategory[i/6] = atol(row[70+i]);
    			    pItem->SpellCategoryCooldown[i/6] = atol(row[71+i]); 
    		    }
    		    pItem->Bonding = atol(row[96]);  
    		    pItem->Description = row[97];  
    		    pItem->Pagetext = atol(row[98]);  
    		    pItem->LanguageID = atol(row[99]);  
    		    pItem->PageMaterial = atol(row[100]);  
    		    pItem->StartQuestID = atol(row[101]);  
    		    pItem->LockID = atol(row[102]);  
    		    pItem->Material = atol(row[103]);  
    		    pItem->Sheathetype = atol(row[104]);
    		    pItem->Unknown1 = atol(row[105]);
    		    pItem->Unknown2 = 0;
    		    WorldServer::getSingleton().AddItem(pItem);
            }
    	}
}
    
void DatabaseInterface::loadQuests()
{
        std::stringstream ss;
        ss << "SELECT * FROM quests";
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        while( row = mysql_fetch_row( res ) ) {
            Quest *pQuest = new Quest;
            pQuest->m_questId = atol(row[0]);
            pQuest->m_zone = atol(row[1]);
            pQuest->m_title = row[2];
            pQuest->m_details = row[3];
            pQuest->m_objectives = row[4];
            pQuest->m_completedText = row[5];
            pQuest->m_incompleteText = row[6];
            pQuest->m_targetGuid = atol(row[7]);
            pQuest->m_questItemId[0] = atol(row[8]);
            pQuest->m_questItemId[1] = atol(row[9]);
            pQuest->m_questItemId[2] = atol(row[10]);
            pQuest->m_questItemId[3] = atol(row[11]);
            pQuest->m_questItemCount[0] = atol(row[12]);
            pQuest->m_questItemCount[1] = atol(row[13]);
            pQuest->m_questItemCount[2] = atol(row[14]);
            pQuest->m_questItemCount[3] = atol(row[15]);
            pQuest->m_questMobId[0] = atol(row[16]);
            pQuest->m_questMobId[1] = atol(row[17]);
            pQuest->m_questMobId[2] = atol(row[18]);
            pQuest->m_questMobId[3] = atol(row[19]);
            pQuest->m_questMobCount[0] = atol(row[20]);
            pQuest->m_questMobCount[1] = atol(row[21]);
            pQuest->m_questMobCount[2] = atol(row[22]);
            pQuest->m_questMobCount[3] = atol(row[23]);
            pQuest->m_choiceRewards = atoi(row[24]);
            pQuest->m_choiceItemId[0] = atol(row[25]);
            pQuest->m_choiceItemId[1] = atol(row[26]);
            pQuest->m_choiceItemId[2] = atol(row[27]);
            pQuest->m_choiceItemId[3] = atol(row[28]);
            pQuest->m_choiceItemId[4] = atol(row[29]);
            pQuest->m_choiceItemCount[0] = atol(row[30]);
            pQuest->m_choiceItemCount[1] = atol(row[31]);
            pQuest->m_choiceItemCount[2] = atol(row[32]);
            pQuest->m_choiceItemCount[3] = atol(row[33]);
            pQuest->m_choiceItemCount[4] = atol(row[34]);
            pQuest->m_itemRewards = atoi(row[35]);
            pQuest->m_rewardItemId[0] = atol(row[36]);
            pQuest->m_rewardItemId[1] = atol(row[37]);
            pQuest->m_rewardItemId[2] = atol(row[38]);
            pQuest->m_rewardItemId[3] = atol(row[39]);
            pQuest->m_rewardItemId[4] = atol(row[40]);
            pQuest->m_rewardItemCount[0] = atol(row[41]);
            pQuest->m_rewardItemCount[1] = atol(row[42]);
            pQuest->m_rewardItemCount[2] = atol(row[43]);
            pQuest->m_rewardItemCount[3] = atol(row[44]);
            pQuest->m_rewardItemCount[4] = atol(row[45]);
            pQuest->m_rewardGold = atol(row[46]);
            pQuest->m_questXp = atol(row[47]);
            pQuest->m_originalGuid = atol(row[48]);
            pQuest->m_requiredLevel = atol(row[49]);
            pQuest->m_previousQuest = atol(row[50]);
            WorldServer::getSingleton().addQuest(pQuest);
        }
    
        mysql_free_result(res);
}
    
    
void DatabaseInterface::loadQuestStatus(Character *pChar)
{
        std::stringstream ss;
        ss << "SELECT * FROM queststatus WHERE playerId=" << pChar->getGUID();
        doQuery( ss.str( ).c_str( ) );
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
        while( row = mysql_fetch_row( res ) ) {
            uint32 status = atol(row[2]);
            quest_status qs;
            qs.status = status;
            qs.quest_id = atol(row[1]);
            qs.m_questMobCount[0] = atol(row[3]);
            qs.m_questMobCount[1] = atol(row[4]);
            qs.m_questMobCount[2] = atol(row[5]);
            qs.m_questMobCount[3] = atol(row[6]);
            qs.m_questItemCount[0] = atol(row[7]);
            qs.m_questItemCount[1] = atol(row[8]);
            qs.m_questItemCount[2] = atol(row[9]);
            qs.m_questItemCount[3] = atol(row[10]);
    
            pChar->loadExistingQuest(qs);
        }
    
        mysql_free_result( res );  
}
    
void DatabaseInterface::saveQuestStatus(Character *pChar)
{
        std::stringstream ss;
        ss << "DELETE FROM queststatus WHERE playerId=" << pChar->getGUID();
        doQuery( ss.str( ).c_str( ) );
    
        std::map<uint32, struct quest_status> temp = pChar->getQuestStatusMap();
        for( std::map<uint32, struct quest_status>::iterator i = temp.begin( ); i != temp.end( ); ++ i ) {
            std::stringstream ss2;
            ss2 << "INSERT INTO queststatus (playerId,questId,status,questMobCount1,questMobCount2,questMobCount3,questMobCount4,"
                << "questItemCount1,questItemCount2,questItemCount3,questItemCount4) VALUES "
                << "(" << pChar->getGUID() << ", " 
                << i->first << ", " 
                << i->second.status << ", "
                << i->second.m_questMobCount[0] << ", "
                << i->second.m_questMobCount[1] << ", "
                << i->second.m_questMobCount[2] << ", "
                << i->second.m_questMobCount[3] << ", "
                << i->second.m_questItemCount[0] << ", "
                << i->second.m_questItemCount[1] << ", "
                << i->second.m_questItemCount[2] << ", "
                << i->second.m_questItemCount[3]            
                << ")";
            doQuery(ss2.str( ).c_str( ) );
            printf("%s", mysql_error((MYSQL*)mDatabaseConnection));
        }
}
	
bool DatabaseInterface::isSpiritHealer(uint32 guid)
{
		std::stringstream Q;
		Q << "SELECT X,Y,Z FROM spirithealers";
		doQuery( Q.str( ).c_str( ) );
		MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
		
        while( row = mysql_fetch_row( res ) ) 
		{
            Unit* pCreature = WorldServer::getSingletonPtr()->GetCreature(guid);
			if(floorf(pCreature->getPositionX()) == floorf(atof(row[0])) && 
               floorf(pCreature->getPositionY()) == floorf(atof(row[1])) && 
               floorf(pCreature->getPositionZ()) == floorf(atof(row[2])) )
			{
				mysql_free_result( res );
				return true;
			}
			
		}		
		mysql_free_result( res );
		return false;
}
	
void DatabaseInterface::getClosestSpiritHealer(float &x, float &y, float &z, uint16 &mapID)
{
		std::stringstream Q;
		float cx,cy,cz;
		cx = x; cy = y; cz = z;
		mapID;
		Q << "SELECT positionX,positionY,positionZ FROM creatures WHERE name_id=6491";				//<- find Spirit Healer from name_id
//		Q << "SELECT positionX,positionY,positionZ FROM creatures WHERE data like '% 5233 0 0 %'";	//<- find Spirit Healer from skin_id
		doQuery( Q.str( ).c_str( ) );
		MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
        MYSQL_ROW row;
		if ( row = mysql_fetch_row( res ) )
		{
			x = (float)atof(row[0]); 
			y = (float)atof(row[1]); 
			z = (float)atof(row[2]);
		}
		while( row = mysql_fetch_row( res ) ) 
		{		
			if(sqrt( pow(cx-atof(row[0]),2) + pow(cy-atof(row[1]),2) )< sqrt( pow(cx-x,2) + pow(cy-y,2) ))
			{
				x = (float)atof(row[0]); 
				y = (float)atof(row[1]); 
				z = (float)atof(row[2]);
			}
				
		}	
		mysql_free_result( res );		
}

void DatabaseInterface::loadChatCommand(const char *name, ChatCommand * cmd)
{
    std::stringstream s;
    s << "SELECT security, help FROM commands WHERE name = '" << name  << "'";
    doQuery(s.str().c_str());
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );
    if(!res)
        return;

        MYSQL_ROW row;
        row = mysql_fetch_row( res );
		if (row != NULL) 
		{
        cmd->SecurityLevel = atoi(row[0]);
        cmd->Help = row[1];
        }
        mysql_free_result( res );
}

char * DatabaseInterface::getAccountPass(int account_id)
{
    std::stringstream ss;
    ss << "SELECT realpassword FROM accounts WHERE acct=" << account_id;
    doQuery(ss.str().c_str());
    MYSQL_RES *res = mysql_store_result( (MYSQL *)mDatabaseConnection );
    MYSQL_ROW row;
    if (res->row_count >= 1){
        row = mysql_fetch_row(res);
        return row[0];
	}

    // account id not found, default to 0
    return 0;
}

void DatabaseInterface::AddFriend(uint32 guid, uint32 friendid, char *charname)
{
	char query[300];  
	printf("Adding friend to database Guid %i Friend %i Char %s\n", guid, friendid, charname);
	sprintf(query, "INSERT INTO social (charname, guid, friendid, flags) VALUES('%s', '%i','%i', 'FRIEND')", charname, guid, friendid);        
    doQuery(query);      
    MYSQL_RES *res2 =  mysql_store_result( (MYSQL *)mDatabaseConnection );  
}

void DatabaseInterface::RemoveFriend(uint32 guid, uint32 friendid)
{
	char query[300];
	printf("Removing friend from database Guid %i Friend %i\n", guid, friendid);
	sprintf(query, "DELETE FROM social Where guid = '%i' AND friendid = '%i'", guid, friendid);        
    doQuery(query);        
    MYSQL_RES *res2 =  mysql_store_result( (MYSQL *)mDatabaseConnection );
}

SocialData* DatabaseInterface::getFriendList(uint32 guid)
{
	SocialData *pSdata;
	int tFriends=0;
    char query[300];  

    strcpy(query, "");        
    sprintf(query, "SELECT COUNT(*) FROM social where guid='%i'",guid );        
    doQuery(query);        
    MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection );        
    MYSQL_ROW row;
	row = mysql_fetch_row( res );
	int Counter = atoi(row[0]);

	strcpy(query, "");

	pSdata = new SocialData;
	pSdata->pSudata = new SocialUserData[Counter];
	pSdata->pArraySize = Counter;

	sprintf(query, "SELECT * FROM social where guid='%i'",guid );        
    doQuery(query);        
    MYSQL_RES *res2 =  mysql_store_result( (MYSQL *)mDatabaseConnection );        
	
	int i=0;
    while( row = mysql_fetch_row( res2 ) ) 
	{
		pSdata->pSudata[i].guid = atoi(row[2]);
		pSdata->pSudata[i].charname = row[0];
		printf("DEBUG: Added Guid %i Char %s to pSdata\n", pSdata->pSudata[i].guid, pSdata->pSudata[i].charname);
		i++;		
	}
    strcpy(query, "");
    return pSdata;
}

	//START OF LINA FW SERVER COMMAND PATCH
	void DatabaseInterface::BanIP(char* ip) 
    {
		Log::getSingleton( ).outString( "DB: Checking IP..." );        
        char query[300];        
        strcpy(query, "");        
        sprintf(query, "SELECT * FROM firewall WHERE ip='%s'", ip);        
        doQuery(query);        
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection ); 
        if (!res) return;

		if (res->row_count == 1)
		{
			strcpy(query, "");            
			sprintf(query, "UPDATE firewall SET allow='0' WHERE (ip='%s')", ip);            
			doQuery(query);
		}
		else
		{
			strcpy(query, "");            
			sprintf(query, "INSERT INTO firewall SET ip='%s',allow='0'", ip);            
			doQuery(query);
		}
    }

	void DatabaseInterface::AllowIP(char* ip) 
    {
		Log::getSingleton( ).outString( "DB: Checking IP..." );        
        char query[300];        
        strcpy(query, "");        
        sprintf(query, "SELECT * FROM firewall WHERE ip='%s'", ip);        
        doQuery(query);        
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection ); 
        if (!res) return;

		if (res->row_count == 1)
		{
			strcpy(query, "");            
			sprintf(query, "UPDATE firewall SET allow='1' WHERE (ip='%s')", ip);            
			doQuery(query);	
		}
		else
		{
			strcpy(query, "");            
			sprintf(query, "INSERT INTO firewall SET ip='%s',allow='1'", ip);            
			doQuery(query);
		}
    }
		
	void DatabaseInterface::RemoveIP(char* ip) 
    {
		Log::getSingleton( ).outString( "DB: Checking IP..." );        
        char query[300];        
        strcpy(query, "");        
        sprintf(query, "DELETE FROM firewall WHERE ip='%s'", ip);        
        doQuery(query);           
    }

	int DatabaseInterface::Firewall(char* ip)
	{
		Log::getSingleton( ).outString( "DB: Checking IP..." );        
        char query[300]; 
		int ret;

        strcpy(query, "");        
        sprintf(query, "SELECT * FROM firewall WHERE ip='%s'", ip);        
        doQuery(query);
		
        MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection ); 
		
		MYSQL_ROW row;
		row = mysql_fetch_row( res );

        if (!res) ret=-1;    
		
        if (res->row_count == 1)
		{
			if(atoi(row[1])==0) ret=2;
			else
			{
				if (!Database::getSingleton().isFirewall()) ret=3;		
				if(atoi(row[1])==1) ret=1;
				else ret=2;
			}
		}
        else 
		{
			if (!Database::getSingleton().isFirewall()) ret=3;
			else ret=0;
        } 
		mysql_free_result( res );
        return ret;   
	}
	//END OF LINA FW SERVER COMMAND PATCH

void DatabaseInterface::loadTalents() 
   { 
           char query[300]; 
           uint32 t_id; 
         TALENT *Talents = new TALENT[MAXTALENTID]; 

           strcpy(query, ""); 
           sprintf(query, "SELECT * FROM talent"); 
         doQuery(query); 
         MYSQL_RES *res =  mysql_store_result( (MYSQL *)mDatabaseConnection ); 
           MYSQL_ROW row; 
    
         while(row = mysql_fetch_row(res)) 
         { 
            t_id = atol(row[0]); 
            Talents[t_id].TalentId = t_id; 
            Talents[t_id].TalentTab = atol(row[1]); 
            Talents[t_id].TalentRow = atol(row[2]); 
            Talents[t_id].TalentCol = atol(row[3]); 
            Talents[t_id].Spell[0] = atol(row[4]); 
            Talents[t_id].Spell[1] = atol(row[5]); 
            Talents[t_id].Spell[2] = atol(row[6]); 
            Talents[t_id].Spell[3] = atol(row[7]); 
            Talents[t_id].Spell[4] = atol(row[8]); 
         } 
           strcpy(query, ""); 
           mysql_free_result( res ); 
           WorldServer::getSingleton().SetTalentDatabase(Talents); 
          
//           delete [] Talents; 

   } 
