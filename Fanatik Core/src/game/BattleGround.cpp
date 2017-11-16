/* 
 * Copyright (C) 2005,2006,2007 MaNGOS <http://www.mangosproject.org/>
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

#include "Object.h"
#include "Player.h"
#include "BattleGround.h"
#include "Creature.h"
#include "Chat.h"
#include "Spell.h"
//ADD FROM CODEBREAKER -> Not sure that this is needed
#include "SpellAuras.h"
#include "GameObject.h"
#include "Map.h"
#include "MapManager.h"
//END ADD

// TODO: Make a warper for all this type of opcodes, and add this one to it
// becouse this is a relative universal opcode
void SendAreaTriggerMessage(Player* Target, const char* Text, ...)
{
    va_list ap;                                             //
    char str [1024];                                        //1024 seems to be rather large
    va_start(ap, Text);
    vsnprintf(str,1024,Text, ap );
    va_end(ap);

    WorldPacket data;
    data.Initialize(SMSG_AREA_TRIGGER_MESSAGE);
    data << uint32(0);
    data << str;
    data << uint8(0);
    Target->GetSession()->SendPacket(&data);
}

BattleGround::BattleGround()
{
    m_ID = 0;
    m_Name = "";
    m_LevelMin = 0;
    m_LevelMax = 0;

    m_TeamScores[0] = 0;
    m_TeamScores[1] = 0;
    m_PlayerScores.clear();

    m_Players.clear();
    m_QueuedPlayers.clear();
    m_MaxPlayersPerTeam = 0;
    m_MaxPlayers = 0;

    m_MapId = 0;
    m_TeamStartLocX[0] = 0;
    m_TeamStartLocX[1] = 0;

    m_TeamStartLocY[0] = 0;
    m_TeamStartLocY[1] = 0;

    m_TeamStartLocZ[0] = 0;
    m_TeamStartLocZ[1] = 0;

    m_TeamStartLocO[0] = 0;
    m_TeamStartLocO[1] = 0;
}

BattleGround::~BattleGround()
{

}

void BattleGround::SetTeamStartLoc(uint32 TeamID, float X, float Y, float Z, float O)
{
    uint8 idx = GetTeamIndexByTeamId(TeamID);
    m_TeamStartLocX[idx] = X;
    m_TeamStartLocY[idx] = Y;
    m_TeamStartLocZ[idx] = Z;
    m_TeamStartLocO[idx] = O;
}

void BattleGround::SendPacketToAll(WorldPacket *packet)
{
    for(std::list<Player*>::iterator itr=m_Players.begin();itr!=m_Players.end();++itr)
    {
        if((*itr)->GetSession())
            (*itr)->GetSession()->SendPacket(packet);
    }
}

void BattleGround::SendPacketToTeam(uint32 TeamID, WorldPacket *packet)
{
    for(std::list<Player*>::iterator itr=m_Players.begin();itr!=m_Players.end();++itr)
    {
        if((*itr)->GetSession() && (*itr)->GetTeam() == TeamID )
            (*itr)->GetSession()->SendPacket(packet);
    }
}

void BattleGround::RemovePlayer(Player *plr, bool Transport, bool SendPacket)
{
    std::map<uint64, BattleGroundScore>::iterator itr = m_PlayerScores.find(plr->GetGUID());
    // Remove from lists/maps
    if(itr != m_PlayerScores.end())
        m_PlayerScores.erase(itr);

    bool Removed = false;

    for(std::list<Player*>::iterator itr2=m_Players.begin();itr2!=m_Players.end();++itr2)
    {
        if((*itr2) == plr)
        {
            m_Players.erase(itr2);
            Removed = true;
            break;
        }
    }

    if(!Removed)
    {
        for(std::list<Player*>::iterator itr3 = m_QueuedPlayers.begin();itr3!=m_QueuedPlayers.end();++itr3)
        {
            if((*itr3) == plr)
            {
                m_QueuedPlayers.erase(itr3);
                Removed = true;
                break;
            }
        }
    }

    if(!Removed) sLog.outError("BATTLEGROUND: Player could not be removed from battleground completely!");

    // Let others know
    WorldPacket data;
    sBattleGroundMgr.BuildPlayerLeftBattleGroundPacket(&data,plr);
    SendPacketToAll(&data);

    // Log
    sLog.outDetail("BATTLEGROUND: Player %s left the battle.", plr->GetName());

    // We're not in BG.
    plr->SetBattleGroundId(0);

    // Packets/Movement
    //WorldPacket data;

    if(Transport)
    {
        // Needs vars added to player class and I'm too lazy to rebuild..

        plr->TeleportTo(plr->GetBattleGroundEntryPointMap(), plr->GetBattleGroundEntryPointX(), plr->GetBattleGroundEntryPointY(), plr->GetBattleGroundEntryPointZ(), plr->GetBattleGroundEntryPointO());
        plr->SendInitWorldStates(plr->GetBattleGroundEntryPointMap());
        //sLog.outDetail("BATTLEGROUND: Sending %s to %f,%f,%f,%f", pl->GetName(), x,y,z,O);
    }

    if(SendPacket)
        sBattleGroundMgr.SendBattleGroundStatusPacket(plr, m_MapId, m_ID, 0, 0);

    // Log
    sLog.outDetail("BATTLEGROUND: Removed %s from BattleGround.", plr->GetName());
}

void BattleGround::AddPlayer(Player *plr)
{
    // Create score struct
    BattleGroundScore sc;
    sc.BonusHonor = 0;
    sc.Deaths = 0;
    sc.DishonorableKills = 0;
    sc.HonorableKills = 0;
    sc.KillingBlows = 0;
    sc.Rank = 0;
    sc.Unk = 0;
    sc.Unk1 = 0;
    sc.Unk2 = 0;
    sc.Unk3 = 0;
    sc.Unk4 = 0;

    // Add to list/maps
    m_Players.push_back(plr);
    uint64 guid = plr->GetGUID();

    m_PlayerScores[guid] = sc;

    plr->SendInitWorldStates(plr->GetMapId());

    WorldPacket data;
    sBattleGroundMgr.BuildPlayerJoinedBattleGroundPacket(&data,plr);
	//CODEBREAKER : ADD PLAYER TO THE BATTLEGROUND
	plr->SetBattleGroundId(1);
	//FINISH:)
    // Let others from your team know //dono if correct if team1 only get team packages?
    SendPacketToTeam(plr->GetTeam(), &data);
    // Log
    sLog.outDetail("BATTLEGROUND: Player %s joined the battle.", plr->GetName());
}

void BattleGround::EventPlayerCaptureFlag(Player *Source)
{
    uint32 SpellId1 = 0,SpellId2 = 0,SpellId3 = 0;
	switch(Source->GetTeam()){
		case HORDE:
			{
				sLog.outError("WARNING: le joueur est de la horde");
				SpellId1 = 23384; //horde click the flag
				SpellId2 = 23648; //flag of alliance captured
				SpellId3 = 23896;
			}break;
		case ALLIANCE:
			{
				sLog.outError("WARNING: le joueur est de l'aliance");
				SpellId1 = 23383; //alliance click the flag
				SpellId2 = 23649; //flag of horde captured
				SpellId3 = 23897; //event taken from base	
			}break;
		default:
			{
				sLog.outError("WARNING: Unknown Team !!");
			}break;
	}
	SpellEntry const *Entry1 = sSpellStore.LookupEntry(SpellId1);
	SpellEntry const *Entry2 = sSpellStore.LookupEntry(SpellId2);
	SpellEntry const *Entry3 = sSpellStore.LookupEntry(SpellId3);
	Spell spell1(Source, Entry1, true,0);
	Spell spell2(Source, Entry2, true,0);
	Spell spell3(Source, Entry3, true,0);
    SpellCastTargets targets1;
	SpellCastTargets targets2;
	SpellCastTargets targets3;
    targets1.setUnitTarget(Source);
	targets2.setUnitTarget(Source);
	targets3.setUnitTarget(Source);
/*   
	targets1.m_targetMask = TARGET_FLAG_UNIT;
	targets2.m_targetMask = TARGET_FLAG_UNIT;
	targets3.m_targetMask = TARGET_FLAG_UNIT;
*/
	targets1.m_targetMask = TARGET_SELF;
	targets2.m_targetMask = TARGET_SELF;
	targets3.m_targetMask = TARGET_SELF;
    spell1.prepare(&targets1);
	spell2.prepare(&targets2);
	spell3.prepare(&targets3);
    WorldPacket data;
    char message[100];
    sprintf(message, "%s picked up the flag!", Source->GetName());
    sChatHandler.FillSystemMessageData(&data, NULL, message);
    Source->SendMessageToSet(&data, true);
}

void BattleGround::EventPlayerDroppedFlag(Player *Source)
{
    // TODO Event handled, trough spell system
    // TODO Use packet instead
	uint32 SpellId = 0,SpellId2 = 0,SpellId1=23333;
	switch(Source->GetTeam()){
		case HORDE:
			{
				SpellId = 23334; //horde lost the flag
				SpellId2 = 23385; //flag return to alliance
			}break;
		case ALLIANCE:
			{
				SpellId = 23336; //alliance lost the flag
				SpellId2 = 23386; //flag return to horde	
			}break;
		default:
			{
				sLog.outError("WARNING: Unknown Team !!");
			}break;
	}
	SpellEntry const *Entry = sSpellStore.LookupEntry(SpellId);
	//use the 1st spellid
	SpellEntry const *Entry2 = sSpellStore.LookupEntry(SpellId2);
	//use the 2nd spellid
	Spell spell(Source, Entry, true,0);
	Spell spell2(Source, Entry2, true,0);
    SpellCastTargets targets;
	SpellCastTargets targets2;
    targets.setUnitTarget(Source);
	targets2.setUnitTarget(Source);
    targets.m_targetMask = TARGET_FLAG_UNIT;
	targets2.m_targetMask = TARGET_FLAG_UNIT;
    spell.prepare(&targets);
	spell2.prepare(&targets2);
//remove flag aura : 
	if(Source->GetTeam()==HORDE){
		SpellId1=23335;
	}
	Unit::AuraMap& auras = Source->GetAuras();
	for (Unit::AuraMap::iterator i = auras.begin(); i != auras.end(); i++){
		if (i->second->GetId()==SpellId1){
		Source->RemoveAura(SpellId1,i->second->Aura::GetEffIndex());
		}
	}
    WorldPacket data;
    char message[100];
    sprintf(message, "%s dropped the flag!", Source->GetName());
    sChatHandler.FillSystemMessageData(&data, NULL, message);
    Source->SendMessageToSet(&data, true);
}

void BattleGround::EventPlayerPassFlag(Player *Source, Player *Target)
{
    // TODO Event handled, trough spell system
    // TODO Use packet instead

	//delete aura from source
	uint32 SpellId = 23333;
	if(Source->GetTeam()==HORDE){
	SpellId = 23335;
	}
	Unit::AuraMap& auras = Source->GetAuras();
	for (Unit::AuraMap::iterator i = auras.begin(); i != auras.end(); i++){
		if (i->second->GetId()==SpellId){
		Source->RemoveAura(SpellId,i->second->Aura::GetEffIndex());
		}
	}
	//and execute spell for the target
	SpellEntry const *Entry1 = sSpellStore.LookupEntry(SpellId);
	Spell spell1(Source, Entry1, true,0);
    SpellCastTargets targets1;
    targets1.setUnitTarget(Target);
    targets1.m_targetMask = TARGET_FLAG_UNIT;
    spell1.prepare(&targets1);


    WorldPacket data;
    char message[100];
    sprintf(message, "%s passed the flag to %s!", Source->GetName(), Target->GetName());
    sChatHandler.FillSystemMessageData(&data, NULL, message);
    SendPacketToTeam(Source->GetTeam(), &data);
}

void BattleGround::EventFlagTaken(uint32 Team,Player const *p){
	uint64 flag_guid=2657;
/*	
ID Warsong flag : (guid)2657 - (id)179831
ID Silverwing :  (guid)14315 - (id)179830
*/
	if(Team==ALLIANCE){
		//destroy the alliance flag
		flag_guid=14315;
	}	//else the guid used is 2657 => the horde flag
	GameObject *obj = new GameObject();
	obj = ObjectAccessor::Instance().GetGameObject(*p,MAKE_GUID(flag_guid, HIGHGUID_GAMEOBJECT));
	if(obj){
		MapManager::Instance().GetMap(obj->GetMapId())->Remove(obj,false);
		obj->Delete();
	}
	else{
		delete obj;
	}
}

bool BattleGround::TeamHasFlag(uint32 Team){
	//check if a member of the team has currently the flag
	bool res=false;
	uint32 SpellId=23333;
	if(Team==HORDE){
		SpellId=23335;
	}
	for(std::list<Player*>::iterator i=m_Players.begin();i!=m_Players.end();++i){
		if((*i)->GetTeam()==Team){
				Unit::AuraMap& auras = (*i)->GetAuras();
				for (Unit::AuraMap::iterator j = auras.begin(); j != auras.end()&&!res; j++){
					if (j->second->GetId()==SpellId){
						res=true;
					}
				}
		}
	}
	return res;
}

bool BattleGround::HasFreeSlots(uint32 Team)
{
    //check if the current BG had free slots
    uint32 TeamCounts = 0;
    for(std::list<Player*>::iterator i=m_Players.begin();i!=m_Players.end();++i)
        if((*i)->GetTeam() == Team)
            ++TeamCounts;

    return (TeamCounts < m_MaxPlayersPerTeam);
}

bool BattleGround::AddFlag(uint32 Team)
{

sLog.outError("spawning the flag");
uint32 guid=2657; //guid horde's flag
bool res;
uint32 id=179831;
uint32 mapid=489;
float x=915.809;
float y=1433.73; 
float z=346.172;
float ang=3.244;
float rotation0=0;
float rotation1=0;
float rotation2=0.998701;
float rotation3=-0.050945;
uint32 animprogress=0;
uint32 dynflags=0;

if(Team==ALLIANCE)
{
	guid=14315; //guid ally's flag
	id=179830;
	x=1540.35;
	y=1481.31;
	z=352.635;
	ang=6.24;
	rotation0=0;
	rotation1=0;
	rotation2=0.021682;
	rotation3=-0.999765;
}
GameObject* obj=new GameObject();
	if(obj){
		//res = obj->Create(MAKE_GUID(guid, HIGHGUID_GAMEOBJECT),id,mapid,x,y,z,ang,rotation0,rotation1,rotation2,rotation3,animprogress,dynflags);
		res = obj->Create(guid,id,mapid,x,y,z,ang,rotation0,rotation1,rotation2,rotation3,animprogress,dynflags);
		MapManager::Instance().GetMap(obj->GetMapId())->Add(obj);
	}
sLog.outError("flag spawned");
return res;
}

bool BattleGround::SpawnFlagOnPlayerDeath(uint32 Team,float x,float y,float z)
{
uint32 guid=2657; //guid horde's flag
bool res;
uint32 id=179831;
uint32 mapid=489;
float ang=3.244;
float rotation0=0;
float rotation1=0;
float rotation2=0.998701;
float rotation3=-0.050945;
uint32 animprogress=0;
uint32 dynflags=0;

if(Team==ALLIANCE)
{
	guid=14315; //guid ally's flag
	id=179830;
	ang=6.24;
	rotation0=0;
	rotation1=0;
	rotation2=0.021682;
	rotation3=-0.999765;
}
GameObject* obj=new GameObject();

	if(obj){
		sLog.outError("go ok");
		res = obj->Create(guid,id,489,x,y,z,ang,rotation0,rotation1,rotation2,rotation3,animprogress,dynflags);
		MapManager::Instance().GetMap(489)->Add(obj);
		sLog.outError("Spawned flag here : x:%f y:%f z:%f on map : %i",x,y,z,mapid);
	}

return res;
}


//
void BattleGround::HandleAreaTrigger(Player* Source, uint32 Trigger)
{
    //I thank a neutral friend for the SpellID's
    uint32 SpellId = 0;
	uint32 WarsongSpell=23333;
	uint32 SilverWingSpell=23335;
    switch(Trigger)
    {
        case 3686:                                          // Speed
        case 3687:                                          // Speed (Horde)
            SpellId=23451;
            break;
        case 3706:                                          // Restoration
        case 3708:                                          // Restoration (Horde)
            SpellId=23493;
            break;
        case 3707:                                          // Berserking
        case 3709:                                          // Berserking (Horde)
            SpellId=23505;
            break;
        case 3669:
        case 3671:
        {
            // Exit BG*/
            if(Source->InBattleGround())
            {
                BattleGround* TempBattlegrounds = sBattleGroundMgr.GetBattleGround(Source->GetBattleGroundId());
                if(TempBattlegrounds)
                    TempBattlegrounds->RemovePlayer(Source,true,true);
                return;
            }
            RemovePlayer(Source, true, true);
            return;
        }break;
        case 3646:                 //alliance flag
		    {
				if(Source->GetTeam()==HORDE&&!TeamHasFlag(HORDE)){
				//horde has taken the flag
				//EventPlayerCaptureFlag(Source);
					sLog.outError("simple test");
				}
				else if(Source->GetTeam()==ALLIANCE){
				//alliance has taken the horde flag and bring it to the ally base
				Unit::AuraMap& auras = Source->GetAuras();
				uint32 currentSpell;
				for (Unit::AuraMap::iterator i = auras.begin(); i != auras.end(); i++){
					currentSpell=i->second->GetId();
					switch(currentSpell)
					{
					case 23333:
						{
							if(!TeamHasFlag(HORDE)){
							Source->RemoveAura(WarsongSpell,i->second->Aura::GetEffIndex());
							AddPoint(Source->GetTeam(),1);
							if(!AddFlag(HORDE))
							{
								sLog.outError("ERROR: object not created");
							}
							}
						return;
						}break;
					case 23335:
						{
							sLog.outError("player returned the flag at home");
							//Ally return the flag
							sLog.outError("del aura from player : %d",currentSpell);
							Source->RemoveAura(SilverWingSpell,i->second->Aura::GetEffIndex());
							if(!AddFlag(ALLIANCE))
							{
								sLog.outError("ERROR: object not created");
							}
						return;
						}break;
					default :
						{
							//sLog.outError("no problem just another spell on the player");
						}break;

					}
				}
				}
			return;
			}break;
        case 3647:                 //horde flag
        {
			if(Source->GetTeam()==ALLIANCE&&!TeamHasFlag(ALLIANCE)){
				//ally has stolen the horde flag
				//EventPlayerCaptureFlag(Source);
				sLog.outError("simple test");
			}
			else if(Source->GetTeam()==HORDE){
			//horde bring to home the ally's flag
				Unit::AuraMap& auras = Source->GetAuras();
				uint32 currentSpell;
				for (Unit::AuraMap::iterator i = auras.begin(); i != auras.end(); i++){
					currentSpell=i->second->GetId();
					switch(currentSpell)
					{
					case 23335:
						{
							if (!TeamHasFlag(ALLIANCE)){
								Source->RemoveAura(SilverWingSpell,i->second->Aura::GetEffIndex());
								AddPoint(Source->GetTeam(),1);
								if(!AddFlag(ALLIANCE))
								{
									sLog.outError("ERROR: object not created");
								}
							}
						return;
						}break;
					case 23333:
						{
							sLog.outError("player returned the flag at home");
							//horde return their flag
							sLog.outError("del aura from player : %d",currentSpell);
							Source->RemoveAura(WarsongSpell,i->second->Aura::GetEffIndex());
							if(!AddFlag(HORDE))
							{
								sLog.outError("ERROR: object not created");
							}
						return;
						}break;
					default:
						{
							//sLog.outError("Don't care about this aura");
						}
					}
		
				}

			}
			return;
        }break;
        default:
        {
            sLog.outError("WARNING: Unhandled AreaTrigger in Battleground: %d", Trigger);
            SendAreaTriggerMessage(Source, "Warning: Unhandled AreaTrigger in Battleground: %d", Trigger);
        }break;
    }

    if(SpellId)
    {
        SpellEntry const *Entry = sSpellStore.LookupEntry(SpellId);

        if(!Entry)
            sLog.outError("WARNING: Tried to add unknown spell id %d to plr.", SpellId);

        Spell spell(Source, Entry, true,0);
        SpellCastTargets targets;
        targets.setUnitTarget(Source);
        targets.m_targetMask = TARGET_FLAG_UNIT;
        spell.prepare(&targets);
    }
}
