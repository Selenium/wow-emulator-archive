/* Header file for AuctionHouse
-Dameon-
*/
#ifndef __AUCTIONHOUSE_H
#define __AUCTIONHOUSE_H
#include "stdafx.h"
#include "WoWObject.h"

struct AuctionData 
{
	unsigned long aid;
	unsigned long entry;
	unsigned long c;
	unsigned long t;
};
struct AuctionEntry
{
	unsigned long auctionhouse;
    unsigned long item;
    unsigned long owner;
    unsigned long bid;
    unsigned long buyout;
    time_t time;
    unsigned long bidder;
    unsigned long Id;
	unsigned long deposit;
};
struct BidEntry
{
	unsigned long AHid;
    unsigned long AuctionID;
    unsigned long amt;
};
class CAuction : public CWoWObject
{
public:
	CAuction(void);
	~CAuction(void);

	AuctionData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);

	void Clear();
	void New();
};

#endif