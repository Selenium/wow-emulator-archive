/* Auction house handler source file. 
This file will outlay the functions for the Auction house.
-Dameon-
*/
#include "AuctionHouse.h"

CAuction::CAuction(void):CWoWObject(OBJ_AUCTION)
{
	Clear();
}
CAuction::~CAuction(void)
{
}
void CAuction::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(AuctionData));
}
void CAuction::New()
{
	Clear();
	CWoWObject::New();
}

bool CAuction::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(AuctionData));
	memcpy(Storage.Data,&Data,sizeof(AuctionData));
	return true;
}

bool CAuction::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(AuctionData));
	return true;
}
