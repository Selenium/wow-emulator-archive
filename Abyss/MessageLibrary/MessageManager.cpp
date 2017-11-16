#include "MessageEnvironment.h"


void MessageManager::SendToAll(std::vector<Player *> *target, Packet *pack)
{
	std::vector<Player *>::iterator i;
	Player *player;

	for (i = target->begin(); i != target->end(); i++)
	{
		player = (*i);
		if (!player->GetClient())
			continue;
		WriteData(player->GetClient(), pack);
		LogManager::GetSingleton().Log("Debug.log", "<<< SMSG_MESSAGECHAT\n");
	}
}
