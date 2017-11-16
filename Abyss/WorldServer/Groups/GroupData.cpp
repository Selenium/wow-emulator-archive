// (c) AbyssX Group
#include "../WorldEnvironment.h"
#ifdef GROUPS

GroupsData::GroupsData()
{
		mMemberGuid = 0;
		mLeaderGuid = 0;
		mLootMasterGuid = 0;
		mLootMethod = 0;
		mIs_Leader = false;
		mUpdated = false;
		mPartyid = 0;
		mMemberCount = 0;
}

GroupsData::~GroupsData()
{
}

#endif