#ifndef GRAVEYARDS_H
#define GRAVEYARDS_H

#define NUM_GRAVEYARDS 120

// all graveyards as of 1.12 from the worldsafeloc dbc
// graveyards moved to RealmServer.cpp
extern _Graveyard Graveyards[NUM_GRAVEYARDS];

_Graveyard GetGraveyard(_Location Loc, unsigned long Continent);

/*proper use of this function:
CPlayer *pPlayer=NULL;
<load the player>
_Graveyard ClosestGraveyard={0,0,0};
//In order: Current Location, Bindpoint, and then Race Starting Point if desperate!
ClosestGraveyard = GetGraveyard(pPlayer->Loc,pPlayer->Continent);
if(ClosestGraveyard.Loc.X == 0.0) ClosestGraveyard = GetGraveyard(pPlayer->BindLoc,pPlayer->BindContinent);
if(ClosestGraveyard.Loc.X == 0.0) ClosestGraveyard = GetGraveyard(RaceStartingPoints[pPlayer->Race].Loc,RaceStartingPoints[pPlayer->Race].Continent);
if(ClosestGraveyard.Loc.X != 0.0 && pPlayer->pClient) Packets::TeleportOrNewWorld(pPlayer->pClient,ClosestGraveyard.Continent,ClosestGraveyard.Loc);
*/

#endif // GRAVEYARDS_H
