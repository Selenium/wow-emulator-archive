

#ifndef __NPCHANDLER_H
#define __NPCHANDLER_H

enum GOSSIP_SPECIAL
{
	GOSSIP_NO_SPECIAL           = 0x00,
	GOSSIP_POI                  = 0x01,
	GOSSIP_SPIRIT_HEALER_ACTIVE = 0x02,
	GOSSIP_VENDOR               = 0x03,
	GOSSIP_TRAINER              = 0x04,
	GOSSIP_TABARD_VENDOR        = 0x05,
	GOSSIP_INNKEEPER            = 0x06,
};


struct GossipText
{
	uint32 ID;
	std::string Text;
};

struct GossipOptions
{
	uint32 ID;
	uint32 GossipID;
	uint32 Icon;
	std::string OptionText;
	uint32 NextTextID;
	uint32 Special;
	float PoiX;
	float PoiY;
	float PoiZ;
};

struct GossipNpc
{
	uint32 ID;
	uint32 Guid;
	uint32 TextID;
	uint32 OptionCount;
	GossipOptions *pOptions;
};

#endif
