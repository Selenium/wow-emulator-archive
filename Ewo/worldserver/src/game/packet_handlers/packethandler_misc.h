// Copyright (C) 2006 Team Evolution
#ifndef PACKETHANDLER_MISC_H
#define PACKETHANDLER_MISC_H
#include "GameClient.h"
#include "globals.h"

void unhandled_opcode(GameClient *pClient);
void handle_CMSG_CANCEL_TRADE(GameClient *pClient);
void handle_CMSG_PING(GameClient *pClient);
void handle_MSG_QUERY_NEXT_MAIL_TIME(GameClient *pClient);
void handle_MSG_MOVE_WORLDPORT_ACK(GameClient *pClient);
void handle_CMSG_NEXT_CINEMATIC_CAMERA(GameClient *pClient);
void handle_CMSG_COMPLETE_CINEMATIC(GameClient *pClient);
void handle_CMSG_CREATURE_QUERY(GameClient *pClient);
void handle_CMSG_GAMEOBJECT_QUERY(GameClient *pClient);
void handle_CMSG_QUERY_TIME(GameClient *pClient);
void handle_CMSG_ITEM_QUERY_SINGLE(GameClient *pClient);
void handle_CMSG_ZONEUPDATE(GameClient *pClient);
void handle_MSG_CORPSE_QUERY(GameClient *pClient);
void handle_CMSG_SWAP_INV_ITEM(GameClient *pClient);
void handle_CMSG_SWAP_ITEM(GameClient *pClient);
void handle_CMSG_SPLIT_ITEM(GameClient *pClient);
void handle_CMSG_RECLAIM_CORPSE(GameClient *pClient);
void handle_CMSG_USE_ITEM(GameClient *pClient);
void handle_CMSG_DESTROYITEM(GameClient *pClient);
void handle_CMSG_LOOT(GameClient *pClient);
void handle_CMSG_LOOT_MONEY(GameClient *pClient);
void handle_CMSG_AUTOSTORE_LOOT_ITEM(GameClient *pClient);
void handle_CMSG_AUTOSTORE_BAG_ITEM(GameClient *pClient);
void handle_CMSG_SPIRIT_HEALER_ACTIVATE(GameClient *pClient);
void handle_CMSG_SPIRIT_HEALER_ACTIVATE(GameClient *pClient);
void handle_CMSG_AUTOEQUIP_ITEM(GameClient *pClient);
void handle_CMSG_FORCE_WALK_SPEED_CHANGE_ACK(GameClient *pClient);
void handle_CMSG_LIST_INVENTORY(GameClient *pClient);
void handle_CMSG_BUY_ITEM(GameClient *pClient);
void handle_CMSG_BUY_ITEM_IN_SLOT(GameClient *pClient);
void handle_CMSG_SELL_ITEM(GameClient *pClient);
void handle_CMSG_BUYBACK_ITEM(GameClient *pClient);
void handle_CMSG_TRAINER_LIST(GameClient *pClient);
void handle_CMSG_TRAINER_BUY_SPELL(GameClient *pClient);
void handle_CMSG_NPC_TEXT_QUERY(GameClient *pClient);
void handle_CMSG_REPAIR_ITEM(GameClient *pClient);
void handle_CMSG_QUESTGIVER_STATUS_QUERY(GameClient *pClient);
void handle_CMSG_QUESTGIVER_HELLO(GameClient *pClient);
void handle_CMSG_QUESTGIVER_QUERY_QUEST(GameClient *pClient);
void handle_CMSG_QUESTGIVER_ACCEPT_QUEST(GameClient *pClient);
void handle_CMSG_QUEST_QUERY(GameClient *pClient);
void handle_CMSG_QUESTGIVER_COMPLETE_QUEST(GameClient *pClient);
void handle_CMSG_QUESTLOG_REMOVE_QUEST(GameClient *pClient);
void handle_CMSG_QUESTGIVER_CHOOSE_REWARD(GameClient *pClient);
void handle_CMSG_CANCEL_CAST(GameClient *pClient);
void handle_CMSG_MOVE_UNLOCK_MOVEMENT_ACK(GameClient *pClient);
void handle_CMSG_CANCEL_AURA(GameClient *pClient);

#endif
