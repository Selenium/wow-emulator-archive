// Copyright (C) 2006 Team Evolution
#include "globals.h"
#include "areatrigger.h"

void	Area_trigger::on_enter_trigger(uint64	trigger)
{
	uint32 obj_type = (uint32)(trigger >> 32);
//printf("!!!!an areatrigger has been triggered type is %u and trigerer is char %u \n",at_type,obj_type & HIGHGUID_PLAYER);
	if(obj_type & HIGHGUID_PLAYER)
	{
		Character *cc_char=(Character *)trigger;
		switch(on_enter_type)
		{
		case AREATRIGGER_TYPE_ENTER_QUEST:
		case AREATRIGGER_TYPE_ENTER_QUEST_AND_MSG:
			{
				//check if he requires this trigger for any quest
				cc_char->quests_started.on_enter_custom_trigger(id);
				if(on_enter_type==AREATRIGGER_TYPE_ENTER_QUEST)
					break;
				if(msg_param1)
					msg_custom_areatrigger_msg(cc_char->pClient,msg_param1);
			}break;
		case AREATRIGGER_TYPE_ENTER_MSG:
			{
				if(msg_param1)
					msg_custom_areatrigger_msg(cc_char->pClient,msg_param1);
			}break;
		case AREATRIGGER_TYPE_ENTER_CAST_SPELL:
			{
				if(param[0])
					G_instant_spell_instance.WORLD_instant_cast(cc_char,(uint32)param[0]);
			}break;
		case AREATRIGGER_TYPE_ENTER_START_QUEST:
			{
				if(param[0])
				{
					G_recv_packet.data32[2] = (uint32)param[0];
					handle_CMSG_QUESTGIVER_ACCEPT_QUEST(cc_char->pClient);
				}
			}break;
		case AREATRIGGER_TYPE_EXIT_FAIL_QUEST:
			{
				cc_char->quests_started.fail_quest((uint32)param[0]);
			}break;
//		case AREATRIGGER_TYPE_ENTER_START_REST:
		}
	}
}

void	Area_trigger::on_left_trigger(uint64	trigger)
{
//printf("!!!!!!!trigger on left areatrigger\n");
}

void msg_custom_areatrigger_msg(GameClient *pClient,char *msg)
{
	WORLDSERVER.send_message(msg,SEND_MESSAGE_TO_ME,CHAT_MSG_SYSTEM,LANG_UNIVERSAL,NULL,pClient->mCurrentChar,NULL);
}

void msg_areatrigger_msg(GameClient *pClient,char *msg)
{
	G_send_packet.opcode = SMSG_AREA_TRIGGER_MESSAGE;
	G_send_packet.data32[0] = 0;
	strcpy((char*)&G_send_packet.data[4],msg);
	G_send_packet.length = 4 + strlen(msg)+1;
	G_send_packet.data[G_send_packet.length++] = 0;
	pClient->SendMsg(&G_send_packet);
}
