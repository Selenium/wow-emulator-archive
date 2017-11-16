// (c) AbyssX Group
#if !defined(CHAMPIOSHIPHANDLER_H)
#define CHAMPIOSHIPHANDLER_H

#ifdef CHAMPIOSHIP

struct ALLIANCE_COORDINATES
{
	DoubleWord map;
	float x;
	float y;
	float z;
};

struct HORDE_COORDINATES
{
	DoubleWord map;
	float x;
	float y;
	float z;
};

class ChampioshipHandler : public Singleton<ChampioshipHandler>
{
	public:
		ChampioshipHandler();
		~ChampioshipHandler();
		
		void ParseChat(Player *, Client *, char *);

		void HordePoint(Player *player);
		void AlliancePoint(Player *player);
		void StopEvent();
		
		DoubleWord mHordePoints;
		DoubleWord mAlliancePoints;
		bool mChampioshipMode;
		
		HORDE_COORDINATES H_Coordinates;
		ALLIANCE_COORDINATES A_Coordinates;
};

#endif

#endif