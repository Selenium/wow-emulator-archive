#ifndef __NPCHANDLER_H
#define __NPCHANDLER_H

struct QEmote {
	uint32 iEmote;
	uint32 iDelay;
};

struct GossipTextPart
{
	std::string Text0;
	std::string Text1;
	uint32 lang;
	float prob;

	QEmote em[3];
};

struct GossipText
{
	uint32 ID;
	GossipTextPart parts[8];
};


struct ItemPageText
{
	uint32 ID;
	std::string Text;
	uint32 NextPage;
};


struct AreaTriggerQuestPoint
{
	uint32 ID;
	uint32 QuestId;
};


#endif
