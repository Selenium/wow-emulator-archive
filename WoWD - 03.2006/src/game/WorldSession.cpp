// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

//
// WorldSession.cpp
//

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "Log.h"
#include "Opcodes.h"
#include "WorldSocket.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Player.h"
#include "ObjectMgr.h"
#include "Group.h"
#include "World.h"
#include "NameTables.h"
#include "Duel.h"

WorldSession::WorldSession(uint32 id, WorldSocket *sock) : _accountId(id), _socket(sock),
    _security(0), _player(0), _logoutTime(0)
{

}

WorldSession::~WorldSession()
{
    WorldPacket *packet;

    while(!_recvQueue.empty())
    {
        packet = _recvQueue.next();
        delete packet;
    }
}


void WorldSession::SetSocket(WorldSocket *sock)
{
    _socket = sock;
}


void WorldSession::SendPacket(WorldPacket* packet)
{
    if (_socket)
        _socket->SendPacket(packet);
}


void WorldSession::QueuePacket(WorldPacket& packet)
{
    WorldPacket *pck = new WorldPacket(packet);
    ASSERT(pck);

    _recvQueue.add(pck);
}


bool WorldSession::Update(uint32 diff)
{
    WorldPacket *packet;
    OpcodeHandler *table = _GetOpcodeHandlerTable();
    uint32 i;


    while (!_recvQueue.empty())
    {
        packet = _recvQueue.next();

        if(packet==NULL)
           continue;
	   
        for (i = 0; table[i].handler != NULL; i++)
        {
            if (table[i].opcode == packet->GetOpcode())
            {
                if (table[i].status == STATUS_AUTHED ||
                    (table[i].status == STATUS_LOGGEDIN && _player))
                {
                    (this->*table[i].handler)(*packet);
                }
                else
                {
                    Log::getSingleton( ).outError( "SESSION: recieved unexpected opcode %s (0x%.4X)",
                        LookupName(packet->GetOpcode(), g_worldOpcodeNames),
                        packet->GetOpcode());
                }

                break;
            }
        }

        if (table[i].handler == NULL)
            Log::getSingleton().outError( "SESSION: recieved unhandled opcode %s (0x%.4X)",
                LookupName(packet->GetOpcode(), g_worldOpcodeNames),
                packet->GetOpcode());

        delete packet;
    }

    time_t currTime = time(NULL); // FIXME: use timediff
    if (!_socket || ShouldLogOut(currTime))
        LogoutPlayer(true);

    if (!_socket)
        return false;

    return true;
}


void WorldSession::LogoutPlayer(bool Save)
{
    if (_player)
    {
		if(!_player->IsInWorld()) //hovering in char selection
			return;

		//Duel Cancel on Leave
		sDuelHandler.EndDuel(_player,DUEL_WINNER_RETREAT);

		//Remove Pet(Summon Pet)
		//TODO: Save Hunter Pet
		if(_player->GetUInt64Value(UNIT_FIELD_SUMMON) > 0)
		{
			Creature *pet = objmgr.GetCreature(_player->GetUInt64Value(UNIT_FIELD_SUMMON));
			if(pet)
			{
				_player->SetPet(NULL);
				_player->SetPetName("");
				pet->RemoveFromWorld();
				objmgr.RemoveObject(((Creature *)pet));
				delete pet;
			}
			_player->SetUInt64Value(UNIT_FIELD_SUMMON, 0);
		}

		// Issue a message saying we left the world
		std::string outstring = _player->GetName( );
		outstring.append( " has left the world." );
		sWorld.SendWorldText( outstring.c_str( ) );

		//Issue a message telling all guild members that this player signed off
		if(_player->IsInGuild())
		{
			Guild *pGuild = objmgr.GetGuild( _player->GetGuildId() );
			if(pGuild)
			{
				//Update Offline info
				pGuild->GuildMemberLogoff(_player);

				WorldPacket data;
				data.Initialize(SMSG_GUILD_EVENT);
				data << uint8(GUILD_EVENT_HASGONEOFFLINE);
				data << uint8(0x01);
				data << _player->GetName();
				data << _player->GetGUID();
				pGuild->SendMessageToGuild(NULL,&data,G_MSGTYPE_ALL);
			}
		}

		_player->EmptyBuyBack();
        // Remove ourself from a group
        if (_player->IsInGroup())
        {
            _player->UnSetInGroup();
            Group *group;
            group = objmgr.GetGroupByLeader(_player->GetGroupLeader());
	        if(group)
	        {
                if (group->RemoveMember(_player->GetGUID()) > 1)
                    group->SendUpdate();
                else
                {
                    group->Disband();
                    objmgr.RemoveGroup(group);

                    delete group;
                }
            }
            else
            {
                Raid *raid = objmgr.GetRaidByLeader(_player->GetGroupLeader());
                if(raid)
                {
                    if(raid->RemoveMember(_player->GetGUID()) > 1)
                        raid->SendUpdate();
                    else
                    {
                        raid->Disband();
                        objmgr.RemoveRaid(raid);

                        delete raid;
                    }
                }
            }
        }

        // Remove us from world
        if (_player->IsInWorld())
        {
            sLog.outDebug( "SESSION: removing player from world" );
            _player->RemoveFromWorld();
        }

        objmgr.RemoveObject(_player);

		// Remove the "player locked" flag, to allow movement on next login
		if ( GetPlayer( )->GetUInt32Value(UNIT_FIELD_FLAGS) & U_FIELD_FLAG_LOCK_PLAYER )
			GetPlayer( )->RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_LOCK_PLAYER );

		if(Save)
		{
		// Save the player
		/*	Removed this to help prevent Character coruption while the server
			still dies alot. ReEnable when fixed */
        _player->SaveToDB();
		}

        //Update Time Stamp for rest state 
		std::stringstream ss;
		ss << "UPDATE characters SET timestamp = " << (uint32)time(NULL) << ", online = 0 WHERE guid = " << _player->GetGUID();
		sDatabase.Execute (ss.str().c_str());

        delete _player;
        _player = 0;

        WorldPacket packet;

        packet.Initialize( SMSG_LOGOUT_COMPLETE );
        SendPacket( &packet );

        sLog.outDebug( "SESSION: Sent SMSG_LOGOUT_COMPLETE Message" );
    }

    LogoutRequest(0);
}


OpcodeHandler* WorldSession::_GetOpcodeHandlerTable() const
{
    static OpcodeHandler table[] =
    {
        /// Character screen
        { CMSG_CHAR_ENUM,                STATUS_AUTHED,   &WorldSession::HandleCharEnumOpcode                },
        { CMSG_CHAR_CREATE,              STATUS_AUTHED,   &WorldSession::HandleCharCreateOpcode              },
        { CMSG_CHAR_DELETE,              STATUS_AUTHED,   &WorldSession::HandleCharDeleteOpcode              },
        { CMSG_PLAYER_LOGIN,             STATUS_AUTHED,   &WorldSession::HandlePlayerLoginOpcode             },
		
		/// Action Bar Opcodes
		{ CMSG_SET_ACTION_BUTTON,        STATUS_LOGGEDIN, &WorldSession::HandleSetActionButtonOpcode         },
		
		/// Misc opcodes
        { CMSG_REPOP_REQUEST,            STATUS_LOGGEDIN, &WorldSession::HandleRepopRequestOpcode            },
        { CMSG_AUTOSTORE_LOOT_ITEM,      STATUS_LOGGEDIN, &WorldSession::HandleAutostoreLootItemOpcode       },
        { CMSG_LOOT_MONEY,               STATUS_LOGGEDIN, &WorldSession::HandleLootMoneyOpcode               },
        { CMSG_LOOT,                     STATUS_LOGGEDIN, &WorldSession::HandleLootOpcode                    },
        { CMSG_LOOT_RELEASE,             STATUS_LOGGEDIN, &WorldSession::HandleLootReleaseOpcode             },
        { CMSG_WHO,                      STATUS_LOGGEDIN, &WorldSession::HandleWhoOpcode                     },
        { CMSG_LOGOUT_REQUEST,           STATUS_LOGGEDIN, &WorldSession::HandleLogoutRequestOpcode           },
        { CMSG_PLAYER_LOGOUT,            STATUS_LOGGEDIN, &WorldSession::HandlePlayerLogoutOpcode            },
        { CMSG_LOGOUT_CANCEL,            STATUS_LOGGEDIN, &WorldSession::HandleLogoutCancelOpcode            },
        { CMSG_ZONEUPDATE,               STATUS_LOGGEDIN, &WorldSession::HandleZoneUpdateOpcode              },
        { CMSG_SET_TARGET_OBSOLETE,      STATUS_LOGGEDIN, &WorldSession::HandleSetTargetOpcode               },
        { CMSG_SET_SELECTION,            STATUS_LOGGEDIN, &WorldSession::HandleSetSelectionOpcode            },
        { CMSG_STANDSTATECHANGE,         STATUS_LOGGEDIN, &WorldSession::HandleStandStateChangeOpcode        },
        { CMSG_FRIEND_LIST,              STATUS_LOGGEDIN, &WorldSession::HandleFriendListOpcode              },
        { CMSG_ADD_FRIEND,               STATUS_LOGGEDIN, &WorldSession::HandleAddFriendOpcode               },
        { CMSG_DEL_FRIEND,               STATUS_LOGGEDIN, &WorldSession::HandleDelFriendOpcode               },
        { CMSG_BUG,                      STATUS_LOGGEDIN, &WorldSession::HandleBugOpcode                     },
        { CMSG_SET_AMMO,                 STATUS_LOGGEDIN, &WorldSession::HandleSetAmmoOpcode                 },
		{ CMSG_AREATRIGGER,              STATUS_LOGGEDIN, &WorldSession::HandleAreaTriggerOpcode             },
        { CMSG_UPDATE_ACCOUNT_DATA,      STATUS_LOGGEDIN, &WorldSession::HandleUpdateAccountData             },
        { CMSG_REQUEST_ACCOUNT_DATA,     STATUS_LOGGEDIN, &WorldSession::HandleRequestAccountData            },
        { CMSG_SET_FACTION_ATWAR,        STATUS_LOGGEDIN, &WorldSession::HandleSetAtWarOpcode                },
		{ CMSG_TOGGLE_PVP,				 STATUS_LOGGEDIN, &WorldSession::HandleTogglePVPOpcode               },
        { CMSG_GAMEOBJ_USE,              STATUS_LOGGEDIN, &WorldSession::HandleGameObjectUse                 },
       // { CMSG_JOIN_CHANNEL,             STATUS_LOGGEDIN, &WorldSession::HandleJoinChannelOpcode             },
        //{ CMSG_LEAVE_CHANNEL,            STATUS_LOGGEDIN, &WorldSession::HandleLeaveChannelOpcode            },

        /// GmTicket opcodes
        { CMSG_GMTICKET_CREATE,          STATUS_LOGGEDIN, &WorldSession::HandleGMTicketCreateOpcode          },
        { CMSG_GMTICKET_UPDATETEXT,      STATUS_LOGGEDIN, &WorldSession::HandleGMTicketUpdateOpcode          },
        { CMSG_GMTICKET_DELETETICKET,    STATUS_LOGGEDIN, &WorldSession::HandleGMTicketDeleteOpcode          },
        { CMSG_GMTICKET_GETTICKET,       STATUS_LOGGEDIN, &WorldSession::HandleGMTicketGetTicketOpcode       },
        { CMSG_GMTICKET_SYSTEMSTATUS,    STATUS_LOGGEDIN, &WorldSession::HandleGMTicketSystemStatusOpcode    },
        { CMSG_GMTICKETSYSTEM_TOGGLE,    STATUS_LOGGEDIN, &WorldSession::HandleGMTicketToggleSystemStatusOpcode},


        /// Queries
        { MSG_CORPSE_QUERY,              STATUS_LOGGEDIN, &WorldSession::HandleCorpseQueryOpcode             },
        { CMSG_NAME_QUERY,               STATUS_LOGGEDIN, &WorldSession::HandleNameQueryOpcode               },
        { CMSG_QUERY_TIME,               STATUS_LOGGEDIN, &WorldSession::HandleQueryTimeOpcode               },
        { CMSG_CREATURE_QUERY,           STATUS_LOGGEDIN, &WorldSession::HandleCreatureQueryOpcode           },
        { CMSG_GAMEOBJECT_QUERY,         STATUS_LOGGEDIN, &WorldSession::HandleGameObjectQueryOpcode         },
		{ CMSG_PAGE_TEXT_QUERY,          STATUS_LOGGEDIN, &WorldSession::HandlePageTextQueryOpcode           },

        /// Movement opcodes
        { MSG_MOVE_HEARTBEAT,            STATUS_LOGGEDIN, &WorldSession::HandleMoveHeartbeatOpcode           },
        { MSG_MOVE_WORLDPORT_ACK,        STATUS_LOGGEDIN, &WorldSession::HandleMoveWorldportAckOpcode        },
        { MSG_MOVE_JUMP,                 STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_FORWARD,        STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_BACKWARD,       STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_SET_FACING,           STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_STOP,                 STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_STRAFE_LEFT,    STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_STRAFE_RIGHT,   STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_STOP_STRAFE,          STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_TURN_LEFT,      STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_TURN_RIGHT,     STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_STOP_TURN,            STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_PITCH_UP,       STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_PITCH_DOWN,     STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_STOP_PITCH,           STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_SET_RUN_MODE,         STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_SET_WALK_MODE,        STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_SET_PITCH,            STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_START_SWIM,           STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
        { MSG_MOVE_STOP_SWIM,            STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
		{ MSG_MOVE_FALL_LAND,            STATUS_LOGGEDIN, &WorldSession::HandleFallOpcode					 },
   		{ CMSG_MOVE_TIME_SKIPPED,		 STATUS_LOGGEDIN, &WorldSession::HandleMoveTimeSkippedOpcode	  	 },
        { CMSG_MOVE_NOT_ACTIVE_MOVER,    STATUS_LOGGEDIN, &WorldSession::HandleMoveNotActiveMoverOpcode      },
        { CMSG_SET_ACTIVE_MOVER,         STATUS_LOGGEDIN, &WorldSession::HandleSetActiveMoverOpcode          },

        /// Group Handler
        { CMSG_GROUP_INVITE,             STATUS_LOGGEDIN, &WorldSession::HandleGroupInviteOpcode             },
        { CMSG_GROUP_CANCEL,             STATUS_LOGGEDIN, &WorldSession::HandleGroupCancelOpcode             },
        { CMSG_GROUP_ACCEPT,             STATUS_LOGGEDIN, &WorldSession::HandleGroupAcceptOpcode             },
        { CMSG_GROUP_DECLINE,            STATUS_LOGGEDIN, &WorldSession::HandleGroupDeclineOpcode            },
        { CMSG_GROUP_UNINVITE,           STATUS_LOGGEDIN, &WorldSession::HandleGroupUninviteOpcode           },
        { CMSG_GROUP_UNINVITE_GUID,      STATUS_LOGGEDIN, &WorldSession::HandleGroupUninviteGuildOpcode      },
        { CMSG_GROUP_SET_LEADER,         STATUS_LOGGEDIN, &WorldSession::HandleGroupSetLeaderOpcode          },
        { CMSG_GROUP_DISBAND,            STATUS_LOGGEDIN, &WorldSession::HandleGroupDisbandOpcode            },
        { CMSG_LOOT_METHOD,              STATUS_LOGGEDIN, &WorldSession::HandleLootMethodOpcode              },

        /// Raid Handler
        { CMSG_GROUP_RAID_CONVERT,       STATUS_LOGGEDIN, &WorldSession::HandleConvertGroupToRaidOpcode      },
        { CMSG_GROUP_CHANGE_SUB_GROUP,   STATUS_LOGGEDIN, &WorldSession::HandleGroupChangeSubGroup           },
        { CMSG_GROUP_ASSISTANT_LEADER,   STATUS_LOGGEDIN, &WorldSession::HandleGroupAssistantLeader          },
        { CMSG_REQUEST_RAID_INFO,        STATUS_LOGGEDIN, &WorldSession::HandleRequestRaidInfoOpcode         },

        /// Taxi opcodes
        { CMSG_TAXINODE_STATUS_QUERY,    STATUS_LOGGEDIN, &WorldSession::HandleTaxiNodeStatusQueryOpcode     },
        { CMSG_TAXIQUERYAVAILABLENODES,  STATUS_LOGGEDIN, &WorldSession::HandleTaxiQueryAviableNodesOpcode   },
        { CMSG_ACTIVATETAXI,             STATUS_LOGGEDIN, &WorldSession::HandleActivateTaxiOpcode            },

        /// NPC related opcodes
        { MSG_TABARDVENDOR_ACTIVATE,     STATUS_LOGGEDIN, &WorldSession::HandleTabardVendorActivateOpcode    },
        { CMSG_BANKER_ACTIVATE,          STATUS_LOGGEDIN, &WorldSession::HandleBankerActivateOpcode          },
        { CMSG_TRAINER_LIST,             STATUS_LOGGEDIN, &WorldSession::HandleTrainerListOpcode             },
        { CMSG_TRAINER_BUY_SPELL,        STATUS_LOGGEDIN, &WorldSession::HandleTrainerBuySpellOpcode         },
        { CMSG_PETITION_SHOWLIST,        STATUS_LOGGEDIN, &WorldSession::HandlePetitionShowListOpcode        },
        { MSG_AUCTION_HELLO,             STATUS_LOGGEDIN, &WorldSession::HandleAuctionHelloOpcode            },
        { CMSG_GOSSIP_HELLO,             STATUS_LOGGEDIN, &WorldSession::HandleGossipHelloOpcode             },
        { CMSG_GOSSIP_SELECT_OPTION,     STATUS_LOGGEDIN, &WorldSession::HandleGossipSelectOptionOpcode      },
        { CMSG_SPIRIT_HEALER_ACTIVATE,   STATUS_LOGGEDIN, &WorldSession::HandleSpiritHealerActivateOpcode    },
        { CMSG_NPC_TEXT_QUERY,           STATUS_LOGGEDIN, &WorldSession::HandleNpcTextQueryOpcode            },
        { CMSG_BINDER_ACTIVATE,          STATUS_LOGGEDIN, &WorldSession::HandleBinderActivateOpcode          },

        /// Item opcodes
        { CMSG_SWAP_INV_ITEM,            STATUS_LOGGEDIN, &WorldSession::HandleSwapInvItemOpcode             },
        { CMSG_SWAP_ITEM,                STATUS_LOGGEDIN, &WorldSession::HandleSwapItemOpcode                },
		{ CMSG_DESTROYITEM,              STATUS_LOGGEDIN, &WorldSession::HandleDestroyItemOpcode             },
        { CMSG_AUTOEQUIP_ITEM,           STATUS_LOGGEDIN, &WorldSession::HandleAutoEquipItemOpcode           },
        { CMSG_ITEM_QUERY_SINGLE,        STATUS_LOGGEDIN, &WorldSession::HandleItemQuerySingleOpcode         },
        { CMSG_SELL_ITEM,                STATUS_LOGGEDIN, &WorldSession::HandleSellItemOpcode                },
        { CMSG_BUY_ITEM_IN_SLOT,         STATUS_LOGGEDIN, &WorldSession::HandleBuyItemInSlotOpcode           },
        { CMSG_BUY_ITEM,                 STATUS_LOGGEDIN, &WorldSession::HandleBuyItemOpcode                 },
        { CMSG_LIST_INVENTORY,           STATUS_LOGGEDIN, &WorldSession::HandleListInventoryOpcode           },
		{ CMSG_AUTOSTORE_BAG_ITEM,       STATUS_LOGGEDIN, &WorldSession::HandleAutoStoreBagItemOpcode        },
        { CMSG_SET_AMMO,                 STATUS_LOGGEDIN, &WorldSession::HandleAmmoSetOpcode                 },
		{ CMSG_BUYBACK_ITEM,			 STATUS_LOGGEDIN, &WorldSession::HandleBuyBackOpcode                 },
		{ CMSG_SPLIT_ITEM,				 STATUS_LOGGEDIN, &WorldSession::HandleSplitOpcode					 },

        /// Combat opcodes
        { CMSG_ATTACKSWING,              STATUS_LOGGEDIN, &WorldSession::HandleAttackSwingOpcode             },
        { CMSG_ATTACKSTOP,               STATUS_LOGGEDIN, &WorldSession::HandleAttackStopOpcode              },

        /// Spell opcodes
        { CMSG_USE_ITEM,                 STATUS_LOGGEDIN, &WorldSession::HandleUseItemOpcode                 },
        { CMSG_CAST_SPELL,               STATUS_LOGGEDIN, &WorldSession::HandleCastSpellOpcode               },
        { CMSG_CANCEL_CAST,              STATUS_LOGGEDIN, &WorldSession::HandleCancelCastOpcode              },
        { CMSG_CANCEL_AURA,              STATUS_LOGGEDIN, &WorldSession::HandleCancelAuraOpcode              },
        { CMSG_CANCEL_CHANNELLING,       STATUS_LOGGEDIN, &WorldSession::HandleCancelChannellingOpcode       },

        /// Skill opcodes
        //{ CMSG_SKILL_LEVELUP,          STATUS_LOGGEDIN, &WorldSession::HandleSkillLevelUpOpcode            },
		{ CMSG_LEARN_TALENT,			 STATUS_LOGGEDIN, &WorldSession::HandleLearnTalentOpcode	         },

        /// Quest opcodes
        { CMSG_QUESTGIVER_STATUS_QUERY,  STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverStatusQueryOpcode   },
        { CMSG_QUESTGIVER_HELLO,         STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverHelloOpcode         },
        { CMSG_QUESTGIVER_ACCEPT_QUEST,  STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverAcceptQuestOpcode   },
        { CMSG_QUESTGIVER_CANCEL,        STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverCancelOpcode   },
        { CMSG_QUESTGIVER_CHOOSE_REWARD, STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverChooseRewardOpcode  },
        { CMSG_QUESTGIVER_REQUEST_REWARD,STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverRequestRewardOpcode },
        { CMSG_QUEST_QUERY,              STATUS_LOGGEDIN, &WorldSession::HandleQuestQueryOpcode              },
		{ CMSG_QUESTGIVER_QUERY_QUEST,   STATUS_LOGGEDIN, &WorldSession::HandleQuestGiverQueryQuestOpcode    },
        { CMSG_QUESTGIVER_COMPLETE_QUEST,STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverCompleteQuestOpcode },
        { CMSG_QUESTLOG_REMOVE_QUEST    ,STATUS_LOGGEDIN, &WorldSession::HandleQuestlogRemoveQuestOpcode     },

        /// Chat opcodes
        { CMSG_MESSAGECHAT,              STATUS_LOGGEDIN, &WorldSession::HandleMessagechatOpcode             },
        { CMSG_TEXT_EMOTE,               STATUS_LOGGEDIN, &WorldSession::HandleTextEmoteOpcode               },
        { CMSG_AREATRIGGER,              STATUS_LOGGEDIN, &WorldSession::HandleAreaTriggerOpcode             },

        /// Corpse Opcodes
        { CMSG_RECLAIM_CORPSE,           STATUS_LOGGEDIN, &WorldSession::HandleCorpseReclaimOpcode           },
        { CMSG_RESURRECT_RESPONSE,       STATUS_LOGGEDIN, &WorldSession::HandleResurrectResponseOpcode       },
		{ CMSG_AUCTION_LIST_ITEMS,		 STATUS_LOGGEDIN, &WorldSession::HandleAuctionListItems				 },
		{ CMSG_AUCTION_LIST_BIDDER_ITEMS,STATUS_LOGGEDIN, &WorldSession::HandleAuctionListBidderItems		 },
		{ CMSG_AUCTION_SELL_ITEM,		 STATUS_LOGGEDIN, &WorldSession::HandleAuctionSellItem				 },
		{ CMSG_AUCTION_LIST_OWNER_ITEMS, STATUS_LOGGEDIN, &WorldSession::HandleAuctionListOwnerItems		 },
		{ CMSG_AUCTION_PLACE_BID,		 STATUS_LOGGEDIN, &WorldSession::HandleAuctionPlaceBid				 },

		/// Channel Opcodes
		{ CMSG_JOIN_CHANNEL,		     STATUS_LOGGEDIN, &WorldSession::HandleChannelJoin					 },
		{ CMSG_LEAVE_CHANNEL,            STATUS_LOGGEDIN, &WorldSession::HandleChannelLeave                  },
		{ CMSG_CHANNEL_LIST,             STATUS_LOGGEDIN, &WorldSession::HandleChannelList					 },
		{ CMSG_CHANNEL_PASSWORD,         STATUS_LOGGEDIN, &WorldSession::HandleChannelPassword               },
		{ CMSG_CHANNEL_SET_OWNER,        STATUS_LOGGEDIN, &WorldSession::HandleChannelSetOwner               },
		{ CMSG_CHANNEL_OWNER,            STATUS_LOGGEDIN, &WorldSession::HandleChannelOwner                  },
		{ CMSG_CHANNEL_MODERATOR,        STATUS_LOGGEDIN, &WorldSession::HandleChannelModerator              },
		{ CMSG_CHANNEL_UNMODERATOR,      STATUS_LOGGEDIN, &WorldSession::HandleChannelUnmoderator            },
		{ CMSG_CHANNEL_MUTE,             STATUS_LOGGEDIN, &WorldSession::HandleChannelMute                   },
		{ CMSG_CHANNEL_UNMUTE,           STATUS_LOGGEDIN, &WorldSession::HandleChannelUnmute                 },
		{ CMSG_CHANNEL_INVITE,           STATUS_LOGGEDIN, &WorldSession::HandleChannelInvite                 },
		{ CMSG_CHANNEL_KICK,             STATUS_LOGGEDIN, &WorldSession::HandleChannelKick                   },
		{ CMSG_CHANNEL_BAN,              STATUS_LOGGEDIN, &WorldSession::HandleChannelBan                    },
		{ CMSG_CHANNEL_UNBAN,            STATUS_LOGGEDIN, &WorldSession::HandleChannelUnban                  },
		{ CMSG_CHANNEL_ANNOUNCEMENTS,    STATUS_LOGGEDIN, &WorldSession::HandleChannelAnnounce               },
		{ CMSG_CHANNEL_MODERATE,         STATUS_LOGGEDIN, &WorldSession::HandleChannelModerate               },

		//Mail Packets
		{ CMSG_GET_MAIL_LIST,			 STATUS_LOGGEDIN, &WorldSession::HandleGetMail						 },
		{ CMSG_ITEM_TEXT_QUERY,			 STATUS_LOGGEDIN, &WorldSession::HandleItemTextQuery				 },
		{ CMSG_SEND_MAIL,				 STATUS_LOGGEDIN, &WorldSession::HandleSendMail						 },
		{ CMSG_MAIL_TAKE_MONEY,			 STATUS_LOGGEDIN, &WorldSession::HandleTakeMoney					 },
		{ CMSG_MAIL_TAKE_ITEM,			 STATUS_LOGGEDIN, &WorldSession::HandleTakeItem						 },
		{ CMSG_MAIL_MARK_AS_READ,		 STATUS_LOGGEDIN, &WorldSession::HandleMarkAsRead					 },
		{ CMSG_MAIL_RETURN_TO_SENDER,	 STATUS_LOGGEDIN, &WorldSession::HandleReturnToSender				 },
		{ CMSG_MAIL_DELETE,				 STATUS_LOGGEDIN, &WorldSession::HandleMailDelete					 },
		{ MSG_QUERY_NEXT_MAIL_TIME,		 STATUS_LOGGEDIN, &WorldSession::HandleMailTime						 },
		
		// Duel
		{ CMSG_DUEL_ACCEPTED,            STATUS_LOGGEDIN, &WorldSession::HandleDuelAccepted                  },
		{ CMSG_DUEL_CANCELLED,           STATUS_LOGGEDIN, &WorldSession::HandleDuelCancelled                 },

		// Trade
		{ CMSG_INITIATE_TRADE,           STATUS_LOGGEDIN, &WorldSession::HandleInitiateTrade                 },
		{ CMSG_BEGIN_TRADE,              STATUS_LOGGEDIN, &WorldSession::HandleBeginTrade                    },
		{ CMSG_BUSY_TRADE,               STATUS_LOGGEDIN, &WorldSession::HandleBusyTrade                     },
		{ CMSG_IGNORE_TRADE,             STATUS_LOGGEDIN, &WorldSession::HandleIgnoreTrade                   },
		{ CMSG_ACCEPT_TRADE,             STATUS_LOGGEDIN, &WorldSession::HandleAcceptTrade                   },
		{ CMSG_UNACCEPT_TRADE,           STATUS_LOGGEDIN, &WorldSession::HandleUnacceptTrade                 },
		{ CMSG_CANCEL_TRADE,             STATUS_LOGGEDIN, &WorldSession::HandleCancelTrade                   },
		{ CMSG_SET_TRADE_ITEM,           STATUS_LOGGEDIN, &WorldSession::HandleSetTradeItem                  },
		{ CMSG_CLEAR_TRADE_ITEM,         STATUS_LOGGEDIN, &WorldSession::HandleClearTradeItem                },
		{ CMSG_SET_TRADE_GOLD,           STATUS_LOGGEDIN, &WorldSession::HandleSetTradeGold                  },

        // Guild
        { CMSG_GUILD_QUERY,              STATUS_AUTHED,   &WorldSession::HandleGuildQuery                    },
        { CMSG_GUILD_CREATE,             STATUS_LOGGEDIN, &WorldSession::HandleCreateGuild                   },
        { CMSG_GUILD_INVITE,             STATUS_LOGGEDIN, &WorldSession::HandleInviteToGuild                 },
        { CMSG_GUILD_ACCEPT,             STATUS_LOGGEDIN, &WorldSession::HandleGuildAccept                   },
        { CMSG_GUILD_DECLINE,            STATUS_LOGGEDIN, &WorldSession::HandleGuildDecline                  },
        { CMSG_GUILD_INFO,               STATUS_LOGGEDIN, &WorldSession::HandleGuildInfo                     },
        { CMSG_GUILD_ROSTER,             STATUS_LOGGEDIN, &WorldSession::HandleGuildRoster                   },
        { CMSG_GUILD_PROMOTE,            STATUS_LOGGEDIN, &WorldSession::HandleGuildPromote                  },
        { CMSG_GUILD_DEMOTE,             STATUS_LOGGEDIN, &WorldSession::HandleGuildDemote                   },
        { CMSG_GUILD_LEAVE,              STATUS_LOGGEDIN, &WorldSession::HandleGuildLeave                    },
        { CMSG_GUILD_REMOVE,             STATUS_LOGGEDIN, &WorldSession::HandleGuildRemove                   },
        { CMSG_GUILD_DISBAND,            STATUS_LOGGEDIN, &WorldSession::HandleGuildDisband                  },
        { CMSG_GUILD_LEADER,             STATUS_LOGGEDIN, &WorldSession::HandleGuildLeader                   },
        { CMSG_GUILD_MOTD,               STATUS_LOGGEDIN, &WorldSession::HandleGuildMotd                     },
        { CMSG_GUILD_RANK,               STATUS_LOGGEDIN, &WorldSession::HandleGuildRank                     },
        { CMSG_GUILD_ADD_RANK,           STATUS_LOGGEDIN, &WorldSession::HandleGuildAddRank                  },
        { CMSG_GUILD_DEL_RANK,           STATUS_LOGGEDIN, &WorldSession::HandleGuildDelRank                  },
        { CMSG_GUILD_SET_PUBLIC_NOTE,    STATUS_LOGGEDIN, &WorldSession::HandleGuildSetPublicNote            },
        { CMSG_GUILD_SET_OFFICER_NOTE,   STATUS_LOGGEDIN, &WorldSession::HandleGuildSetOfficerNote           },
        { CMSG_PETITION_BUY,             STATUS_LOGGEDIN, &WorldSession::HandlePetitionBuy                   },
        { CMSG_PETITION_SHOW_SIGNATURES, STATUS_LOGGEDIN, &WorldSession::HandlePetitionShowSignatures        },
        { CMSG_TURN_IN_PETITION,         STATUS_LOGGEDIN, &WorldSession::HandlePetitionTurnInPetition        },
        { CMSG_PETITION_QUERY,           STATUS_LOGGEDIN, &WorldSession::HandlePetitionQuery                 },
        { CMSG_OFFER_PETITION,           STATUS_LOGGEDIN, &WorldSession::HandlePetitionOffer                 },
        { CMSG_PETITION_SIGN,            STATUS_LOGGEDIN, &WorldSession::HandlePetitionSign                  },
        { MSG_PETITION_RENAME,           STATUS_LOGGEDIN, &WorldSession::HandlePetitionRename                },
        { MSG_SAVE_GUILD_EMBLEM,         STATUS_LOGGEDIN, &WorldSession::HandleSaveGuildEmblem               },
		{ CMSG_SET_GUILD_INFORMATION,    STATUS_LOGGEDIN, &WorldSession::HandleSetGuildInformation           },
        
		//tutorials
		{ CMSG_TUTORIAL_FLAG,            STATUS_LOGGEDIN, &WorldSession::HandleTutorialFlag                  },
		{ CMSG_TUTORIAL_CLEAR,           STATUS_LOGGEDIN, &WorldSession::HandleTutorialClear                 },
		{ CMSG_TUTORIAL_RESET,           STATUS_LOGGEDIN, &WorldSession::HandleTutorialReset                 },

        // Pet
        { CMSG_PET_ACTION,               STATUS_LOGGEDIN, &WorldSession::HandlePetAction                     },
		{ CMSG_REQUEST_PET_INFO,		 STATUS_LOGGEDIN, &WorldSession::HandlePetInfo						 },
		{ CMSG_PET_NAME_QUERY,			 STATUS_LOGGEDIN, &WorldSession::HandlePetNameQuery					 },
		{ CMSG_STABLE_PET,				 STATUS_LOGGEDIN, &WorldSession::HandleStablePet					 },
		{ CMSG_UNSTABLE_PET,			 STATUS_LOGGEDIN, &WorldSession::HandleUnstablePet					 },
		{ MSG_LIST_STABLED_PETS,		 STATUS_LOGGEDIN, &WorldSession::HandleStabledPetList				 },

        /// End of table
        { 0,                             0,               NULL                                               }
    };

    return table;
}
