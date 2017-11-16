// Copyright (C) 2006 Team Evolution
#ifndef PACKETHANDLER_CHAR_H
#define PACKETHANDLER_CHAR_H
#include "GameClient.h"
#include "globals.h"

void handle_CMSG_SET_ACTIVE_MOVER(GameClient *pClient);
void handle_MSG_LOOKING_FOR_GROUP(GameClient *pClient);
void handle_SMSG_LOOT_ALL_PASSED(GameClient *pClient);
void handle_CMSG_FORCE_RUN_SPEED_CHANGE_ACK(GameClient *pClient);
void handle_CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK(GameClient *pClient);
void handle_CMSG_FORCE_SWIM_SPEED_CHANGE_ACK(GameClient *pClient);
void handle_CMSG_FORCE_MOVE_ROOT_ACK(GameClient *pClient);
void handle_CMSG_FORCE_MOVE_UNROOT_ACK(GameClient *pClient);
void handle_MSG_MOVE_TELEPORT_ACK(GameClient *pClient);
void handle_CMSG_MOVE_TIME_SKIPPED(GameClient *pClient);
void handle_CMSG_MOVE_FALL_RESET(GameClient *pClient);
void handle_CMSG_MOVE_WATER_WALK_ACK(GameClient *pClient);
void handle_CMSG_LOOT_RELEASE(GameClient *pClient);
void handle_CMSG_NAME_QUERY(GameClient *pClient);
void handle_move(GameClient *pClient);
void handle_MSG_MOVE_FALL_LAND(GameClient *pClient);
void handle_MSG_MOVE_START_SWIM(GameClient *pClient);
void handle_CMSG_GMTICKET_GETTICKET(GameClient *pClient);
void handle_CMSG_LOGOUT_REQUEST(GameClient *pClient);
void handle_CMSG_LOGOUT_CANCEL(GameClient *pClient);
void handle_CMSG_SET_SELECTION(GameClient *pClient);
void handle_CMSG_MESSAGECHAT(GameClient *pClient);
void handle_CMSG_GAMEOBJ_USE(GameClient *pClient);
void handle_CMSG_TEXT_EMOTE(GameClient *pClient);
void handle_CMSG_STANDSTATECHANGE(GameClient *pClient);
void handle_CMSG_SET_ACTION_BUTTON(GameClient *pClient);
void handle_CMSG_CAST_SPELL(GameClient *pClient);
void handle_CMSG_SETSHEATHED(GameClient *pClient);
void handle_CMSG_GROUP_INVITE(GameClient *pClient);
void handle_CMSG_GROUP_ACCEPT(GameClient *pClient);
void handle_CMSG_GROUP_DECLINE(GameClient *pClient);
void handle_CMSG_GROUP_UNINVITE(GameClient *pClient);
void handle_CMSG_GROUP_SET_LEADER(GameClient *pClient);
void handle_CMSG_GROUP_DISBAND(GameClient *pClient);
void handle_CMSG_LOOT_METHOD(GameClient *pClient);
void handle_CMSG_ATTACKSWING(GameClient *pClient);
void handle_CMSG_ATTACKSTOP(GameClient *pClient);
void handle_CMSG_REPOP_REQUEST(GameClient *pClient);
void handle_CMSG_REQUEST_PARTY_MEMBER_STATS(GameClient *pClient);
void handle_CMSG_DUEL_ACCEPTED(GameClient *pClient);
void handle_CMSG_DUEL_CANCELLED(GameClient *pClient);

#endif