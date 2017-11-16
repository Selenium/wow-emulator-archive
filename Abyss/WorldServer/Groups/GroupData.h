// (c) AbyssX Group
#if !defined(GROUPDATA_H)
#define GROUPDATA_H

#ifdef GROUPS

#include "../WorldEnvironment.h"

class GroupsData
{
	public:
		GroupsData();
		~GroupsData();

		string mMemberName;
		QuadWord mMemberGuid;
		QuadWord mLeaderGuid;
		QuadWord mLootMasterGuid;
		DoubleWord mPartyid;
		DoubleWord mMemberCount;
		Byte mLootMethod;
		bool mIs_Leader;
		bool mUpdated;
};

#endif
#endif