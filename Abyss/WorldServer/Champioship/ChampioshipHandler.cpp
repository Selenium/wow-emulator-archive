// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef CHAMPIOSHIP

#define TIME 30

template <class ChampioshipHandler> ChampioshipHandler *Singleton<ChampioshipHandler>::msSingleton = 0;

void Stop(void *Param)
{
	ChampioshipHandler::GetSingleton().StopEvent();
}

ChampioshipHandler::ChampioshipHandler()
{
	mHordePoints = 0;
	mAlliancePoints = 0;
	mChampioshipMode = false;
	
	//HORDE CHAMPIOSHIP SPAWN COORDINATES
	H_Coordinates.map = 44;
	H_Coordinates.x = (float)194.550461;
	H_Coordinates.y = (float)25.624971;
	H_Coordinates.z = (float)30.839046;

	//ALLIANCE CHAMPIOSHIP SPAWN COORDINATES
	A_Coordinates.map = 44;
	A_Coordinates.x = (float)64.147919;
	A_Coordinates.y = (float)11.096536;
	A_Coordinates.z = (float)18.677343;
}

ChampioshipHandler::~ChampioshipHandler()
{
}

void ChampioshipHandler::ParseChat(Player *ply, Client *cli, char *txt)
{
	DoubleWord EventTime = TIME*60*1000;

	if (strnicmp(txt, "start", 5) == 0 && ply->IsGM())
	{
		mChampioshipMode = true;
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - Faction vs Faction Battle is Starting !");
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - Worldporting all Players into the Battle Zone!");
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - The Event Will Stop in 30 Minutes!");
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - Event Started! Kill Enemy Faction Players to Give Points to your Faction!");

		WorldServer::GetSingleton().TeleportAllToBattleZone();

		EventSystem::GetSingleton().AddTimer(EventTime,Stop,NULL,CHAMPIOSHIPHANDLER,10);
	}

	else if (strnicmp(txt, "stop", 4) == 0 && ply->IsGM())
	{
		mChampioshipMode = false;
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - Faction vs Faction Battle is Ending!");
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - And the Major Winner is :");
		
		if (mHordePoints > mAlliancePoints)
			WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - Horde WINS!",mAlliancePoints,mHordePoints);
		if (mHordePoints < mAlliancePoints)
			WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - Alliance WINS!",mAlliancePoints,mHordePoints);
		if (mHordePoints == mAlliancePoints)
			WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - There are no Winners!",mAlliancePoints,mHordePoints);

		mHordePoints = 0;
		mAlliancePoints = 0;

		WorldServer::GetSingleton().TeleportAllPlayersToHome();
	}

} 

void ChampioshipHandler::HordePoint(Player *player)
{
	mHordePoints += 1;
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] - %s Made 1 Point to Horde Faction!",player->GetName().c_str());
}

void ChampioshipHandler::AlliancePoint(Player *player)
{
	mAlliancePoints += 1;
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] - %s Made 1 Point to Alliance Faction!",player->GetName().c_str());
}

void ChampioshipHandler::StopEvent()
{
	mChampioshipMode = false;
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] - Faction vs Faction Battle is Ending!");
	WorldServer::GetSingleton().AnnounceToAll("[World-Server] - And the Major Winner is :");
		
	if (mHordePoints > mAlliancePoints)
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - Horde WINS!",mAlliancePoints,mHordePoints);
	if (mHordePoints < mAlliancePoints)
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - Alliance WINS!",mAlliancePoints,mHordePoints);
	if (mHordePoints == mAlliancePoints)
		WorldServer::GetSingleton().AnnounceToAll("[World-Server] - [Alliance = %d | Horde = %d] - There are no Winners!",mAlliancePoints,mHordePoints);

	mHordePoints = 0;
	mAlliancePoints = 0;

	WorldServer::GetSingleton().TeleportAllPlayersToHome();
}

void WorldServer::TeleportAllToBattleZone()
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;

		Player *player = (*i).second;

		if (player->GetFaction() == ALLIANCE)
			PlayersHandler::GetSingleton().TeleportPlayer(player,ChampioshipHandler::GetSingleton().A_Coordinates.map,ChampioshipHandler::GetSingleton().A_Coordinates.x,ChampioshipHandler::GetSingleton().A_Coordinates.y,ChampioshipHandler::GetSingleton().A_Coordinates.z);

		if(player->GetFaction() == HORDE)
			PlayersHandler::GetSingleton().TeleportPlayer(player,ChampioshipHandler::GetSingleton().H_Coordinates.map,ChampioshipHandler::GetSingleton().H_Coordinates.x,ChampioshipHandler::GetSingleton().H_Coordinates.y,ChampioshipHandler::GetSingleton().H_Coordinates.z);
			
	}
}

void WorldServer::TeleportAllPlayersToHome()
{
	ObjectManager<Player *>::ObjectManagerIterator i;

	for (i = PlayersHandler::GetSingleton().mPlayers.Begin(); i != PlayersHandler::GetSingleton().mPlayers.End(); i++)
	{
		if (!(*i).second->GetClient())
			continue;

		Player *player = (*i).second;

		player->SetStartCoordinates();
		PlayersHandler::GetSingleton().TeleportPlayer(player, player->GetStartMap(),player->GetXCoordinate(),player->GetYCoordinate(),player->GetZCoordinate());
	}
}

#endif