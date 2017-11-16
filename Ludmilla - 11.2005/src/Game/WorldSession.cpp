#include "StdAfx.h"

#include "Server/WS/WorldSocket.h"
#include "Server/WS/WorldSocketMgr.h"

//
// WorldSession.cpp
//

#include <stdarg.h>

//-----------------------------------------------------------------------------
WorldSession::WorldSession(uint32 id, WorldSocket *sock) : _accountId(id), _socket(sock),
    _security(0), _player(0), _logoutTime(0)
{
}

//-----------------------------------------------------------------------------
WorldSession::~WorldSession()
{
    WorldPacket *packet;

    while(!_recvQueue.empty())
    {
        packet = _recvQueue.next();
        delete packet;
    }
}

//-----------------------------------------------------------------------------
void WorldSession::SetSocket(WorldSocket *sock)
{
    _socket = sock;
}

//-----------------------------------------------------------------------------
void WorldSession::SendPacket(WorldPacket* packet)
{
    if (_socket)
        _socket->SendPacket(packet);
}

//-----------------------------------------------------------------------------
void WorldSession::QueuePacket(WorldPacket& packet)
{
    WorldPacket *pck = new WorldPacket(packet);
    ASSERT(pck);

    _recvQueue.add(pck);
}

//-----------------------------------------------------------------------------
bool WorldSession::Update(uint32 diff)
{
    WorldPacket *packet;
    OpcodeHandler *table = _GetOpcodeHandlerTable();
    uint32 i;

    while (!_recvQueue.empty())
    {
        packet = _recvQueue.next();

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
        LogoutPlayer();

    if (!_socket)
        return false;

    return true;
}

//-----------------------------------------------------------------------------
void WorldSession::LogoutPlayer()
{
    if (_player)
    {
        // Issue a message saying we left the world
        std::string outstring = _player->GetName( );
        outstring.append( " has left the world." );
        sWorld.SendWorldText( outstring.c_str( ) );

		_player->ClearHate();

        // Remove ourself from a group
        if (_player->IsInGroup())
        {
            _player->UnSetInGroup();
            Group *group;
            group = objmgr.GetGroupByLeader(_player->GetGroupLeader());
            if (group->RemoveMember(_player->GetGUID()) > 1)
                group->SendUpdate();
            else
            {
                group->Disband();
                objmgr.RemoveGroup(group);

                delete group;
            }
        }

        // Remove us from world
        if (_player->IsInWorld())
        {
            sLog.outDebug( "SESSION: removing player from world" );
            _player->RemoveFromMap();
        }

        objmgr.RemoveObject_Free (_player);

        // Save the player
        _player->SaveToDB();

		//////////////////////////////////////////////////
		// Set Time of Logout for Player, will be used for RESTSTATE calculation
		std::stringstream ss;
		ss << "UPDATE characters SET timestamp = " << (uint32)time(NULL) << ", online = 0 WHERE guid = " << _player->GetGUID();
		sDatabase.Execute (ss.str().c_str());
		//////////////////////////////////////////////////
		
		// delete _player;
        _player = 0;

		

        WorldPacket packet;

        packet.Initialize( SMSG_LOGOUT_COMPLETE );
        SendPacket( &packet );

        sLog.outDebug( "SESSION: Sent SMSG_LOGOUT_COMPLETE Message" );
    }

    LogoutRequest(0);
}

//-----------------------------------------------------------------------------
OpcodeHandler* WorldSession::_GetOpcodeHandlerTable() const
{
    static OpcodeHandler table[] =
    {
        /// Character screen
        { CMSG_CHAR_ENUM,                STATUS_AUTHED,   &WorldSession::HandleCharEnumOpcode                },
        { CMSG_CHAR_CREATE,              STATUS_AUTHED,   &WorldSession::HandleCharCreateOpcode              },
        { CMSG_CHAR_DELETE,              STATUS_AUTHED,   &WorldSession::HandleCharDeleteOpcode              },
        { CMSG_PLAYER_LOGIN,             STATUS_AUTHED,   &WorldSession::HandlePlayerLoginOpcode             },        

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
        { CMSG_SET_TARGET,               STATUS_LOGGEDIN, &WorldSession::HandleSetTargetOpcode               },
        { CMSG_SET_SELECTION,            STATUS_LOGGEDIN, &WorldSession::HandleSetSelectionOpcode            },
        { CMSG_STANDSTATECHANGE,         STATUS_LOGGEDIN, &WorldSession::HandleStandStateChangeOpcode        },
        { CMSG_BUG,                      STATUS_LOGGEDIN, &WorldSession::HandleBugOpcode                     },
		{ CMSG_UPDATE_ACCOUNT_DATA,      STATUS_LOGGEDIN, &WorldSession::HandleUpdateAccountDataOpcode       },
		{ CMSG_SET_ACTION_BUTTON,        STATUS_LOGGEDIN, &WorldSession::HandleSetActionButton               },
		{ CMSG_ENABLE_PVP,				 STATUS_LOGGEDIN, &WorldSession::HandleEnablePVPOpcode               },
		
		// Friend List Opcodes
		{ CMSG_FRIEND_LIST,              STATUS_LOGGEDIN, &WorldSession::HandleFriendListOpcode              },
		{ CMSG_ADD_FRIEND,               STATUS_LOGGEDIN, &WorldSession::HandleAddFriendOpcode               },
		{ CMSG_DEL_FRIEND,               STATUS_LOGGEDIN, &WorldSession::HandleDelFriendOpcode               },
		{ CMSG_ADD_IGNORE,               STATUS_LOGGEDIN, &WorldSession::HandleAddIgnoreOpcode               },
        { CMSG_DEL_IGNORE,               STATUS_LOGGEDIN, &WorldSession::HandleDelIgnoreOpcode               },	

		// GM Tickets Opcodes
        { CMSG_GMTICKET_GETTICKET,       STATUS_LOGGEDIN, &WorldSession::HandleGMTicketGetTicketOpcode       },
        { CMSG_GMTICKET_CREATE,          STATUS_LOGGEDIN, &WorldSession::HandleGMTicketCreateOpcode          },
        { CMSG_GMTICKET_SYSTEMSTATUS,    STATUS_LOGGEDIN, &WorldSession::HandleGMTicketSystemStatusOpcode    },
  	    { CMSG_GMTICKET_DELETETICKET,    STATUS_LOGGEDIN, &WorldSession::HandleGMTicketDeleteOpcode			 },  
	    { CMSG_GMTICKET_UPDATETEXT,      STATUS_LOGGEDIN, &WorldSession::HandleGMTicketTextUpdateOpcode		 }, 

       // { CMSG_JOIN_CHANNEL,             STATUS_LOGGEDIN, &WorldSession::HandleJoinChannelOpcode             },
        //{ CMSG_LEAVE_CHANNEL,            STATUS_LOGGEDIN, &WorldSession::HandleLeaveChannelOpcode            },
		{ CMSG_MEETING_STONE_INFO,       STATUS_LOGGEDIN, &WorldSession::HandleMeetingStoneInfo              },

		/// Queries
        { MSG_CORPSE_QUERY,              STATUS_LOGGEDIN, &WorldSession::HandleCorpseQueryOpcode             },
        { CMSG_NAME_QUERY,               STATUS_LOGGEDIN, &WorldSession::HandleNameQueryOpcode               },
        { CMSG_QUERY_TIME,               STATUS_LOGGEDIN, &WorldSession::HandleQueryTimeOpcode               },
        { CMSG_CREATURE_QUERY,           STATUS_LOGGEDIN, &WorldSession::HandleCreatureQueryOpcode           },
        { CMSG_GAMEOBJECT_QUERY,         STATUS_LOGGEDIN, &WorldSession::HandleGameObjectQueryOpcode         },
        { CMSG_GAMEOBJ_USE,              STATUS_LOGGEDIN, &WorldSession::HandleGameObjectUseOpcode           },

		{ CMSG_PET_ACTION,				 STATUS_LOGGEDIN, &WorldSession::HandlePetActionOpcode			     },

		/// Movement opcodes
        { MSG_MOVE_HEARTBEAT,            STATUS_LOGGEDIN, &WorldSession::HandleMoveHeartbeatOpcode           },
        { MSG_MOVE_WORLDPORT_ACK,        STATUS_LOGGEDIN, &WorldSession::HandleMoveWorldportAckOpcode        },
        { MSG_MOVE_JUMP,                 STATUS_LOGGEDIN, &WorldSession::HandleMovementOpcodes               },
		{ MSG_MOVE_FALL_LAND,			 STATUS_LOGGEDIN, &WorldSession::HandleMovementFall                  },
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
        { CMSG_LEARN_TALENT,             STATUS_LOGGEDIN, &WorldSession::HandleLearnTalentOpcode             },

		/// Item opcodes
        { CMSG_SWAP_INV_ITEM,            STATUS_LOGGEDIN, &WorldSession::HandleSwapInvItemOpcode             },
        { CMSG_DESTROYITEM,              STATUS_LOGGEDIN, &WorldSession::HandleDestroyItemOpcode             },
        { CMSG_AUTOEQUIP_ITEM,           STATUS_LOGGEDIN, &WorldSession::HandleAutoEquipItemOpcode           },
        { CMSG_ITEM_QUERY_SINGLE,        STATUS_LOGGEDIN, &WorldSession::HandleItemQuerySingleOpcode         },
        { CMSG_SELL_ITEM,                STATUS_LOGGEDIN, &WorldSession::HandleSellItemOpcode                },
        { CMSG_BUY_ITEM_IN_SLOT,         STATUS_LOGGEDIN, &WorldSession::HandleBuyItemInSlotOpcode           },
        { CMSG_BUY_ITEM,                 STATUS_LOGGEDIN, &WorldSession::HandleBuyItemOpcode                 },
        { CMSG_LIST_INVENTORY,           STATUS_LOGGEDIN, &WorldSession::HandleListInventoryOpcode           },
		{ CMSG_BUYBACK_ITEM,             STATUS_LOGGEDIN, &WorldSession::HandleBuybackItemOpcode             },
        { CMSG_SET_AMMO,                 STATUS_LOGGEDIN, &WorldSession::HandleSetAmmoOpcode                 },
	    { CMSG_SETSHEATHED,              STATUS_LOGGEDIN, &WorldSession::HandleSetSheathed	                 },
	    { CMSG_READ_ITEM,                STATUS_LOGGEDIN, &WorldSession::HandleReadItem  	                 },
		{ CMSG_SWAP_ITEM,                STATUS_LOGGEDIN, &WorldSession::HandleSwapItem  	                 },
		{ CMSG_AUTOSTORE_BAG_ITEM,       STATUS_LOGGEDIN, &WorldSession::HandleAutostoreBagItem  	                 },


		/// Combat opcodes
        { CMSG_ATTACKSWING,              STATUS_LOGGEDIN, &WorldSession::HandleAttackSwingOpcode             },
        { CMSG_ATTACKSTOP,               STATUS_LOGGEDIN, &WorldSession::HandleAttackStopOpcode              },
        
		/// Spell opcodes
        { CMSG_USE_ITEM,                 STATUS_LOGGEDIN, &WorldSession::HandleUseItemOpcode                 },
        { CMSG_CAST_SPELL,               STATUS_LOGGEDIN, &WorldSession::HandleCastSpellOpcode               },
        { CMSG_CANCEL_CAST,              STATUS_LOGGEDIN, &WorldSession::HandleCancelCastOpcode              },
        { CMSG_CANCEL_AURA,              STATUS_LOGGEDIN, &WorldSession::HandleCancelAuraOpcode              },
	    { CMSG_CANCEL_CHANNELLING,       STATUS_LOGGEDIN, &WorldSession::HandleCancelChannellingOpcode       },
        { CMSG_CANCEL_AUTO_REPEAT_SPELL, STATUS_LOGGEDIN, &WorldSession::HandleCancelAutorepeatSpellOpcode   },

		/// Skill opcodes
        //{ CMSG_SKILL_LEVELUP,          STATUS_LOGGEDIN, &WorldSession::HandleSkillLevelUpOpcode            },
        
		/// Quest opcodes
        { CMSG_QUESTGIVER_STATUS_QUERY,  STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverStatusQueryOpcode   },
        { CMSG_QUESTGIVER_HELLO,         STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverHelloOpcode         },
        { CMSG_QUESTGIVER_ACCEPT_QUEST,  STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverAcceptQuestOpcode   },
        { CMSG_QUESTGIVER_CHOOSE_REWARD, STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverChooseRewardOpcode  },
        { CMSG_QUESTGIVER_REQUEST_REWARD,STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverRequestRewardOpcode },
        { CMSG_QUESTGIVER_QUERY_QUEST,   STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverQuestQueryOpcode    },
        { CMSG_QUEST_QUERY,              STATUS_LOGGEDIN, &WorldSession::HandleQuestQueryOpcode              },

        { CMSG_QUEST_CONFIRM_ACCEPT,            STATUS_LOGGEDIN, &WorldSession::HandleQuestConfirmAccept     },
        { CMSG_QUESTLOG_REMOVE_QUEST,           STATUS_LOGGEDIN, &WorldSession::HandleQuestLogRemoveQuest    },
        { CMSG_QUESTLOG_SWAP_QUEST,             STATUS_LOGGEDIN, &WorldSession::HandleQuestLogSwapQuest      },
        { CMSG_QUESTGIVER_CANCEL,               STATUS_LOGGEDIN, &WorldSession::HandleQuestgiverCancel       },
        { CMSG_QUESTGIVER_COMPLETE_QUEST,       STATUS_LOGGEDIN, &WorldSession::HandleQuestComplete          },
        { CMSG_QUESTGIVER_QUEST_AUTOLAUNCH,     STATUS_LOGGEDIN, &WorldSession::HandleQuestAutoLaunch        },

        /// Chat opcodes
        { CMSG_MESSAGECHAT,              STATUS_LOGGEDIN, &WorldSession::HandleMessagechatOpcode             },
        { CMSG_TEXT_EMOTE,               STATUS_LOGGEDIN, &WorldSession::HandleTextEmoteOpcode               },
        { CMSG_AREATRIGGER,              STATUS_LOGGEDIN, &WorldSession::HandleAreatriggerOpcode             },
        
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
		
		{ CMSG_TUTORIAL_FLAG,            STATUS_LOGGEDIN, &WorldSession::HandleTutorialFlag                  },
		{ CMSG_TUTORIAL_CLEAR,           STATUS_LOGGEDIN, &WorldSession::HandleTutorialClear                 },
		{ CMSG_TUTORIAL_RESET,           STATUS_LOGGEDIN, &WorldSession::HandleTutorialReset                 },
	
		/// Mail Packets
		{ CMSG_GET_MAIL_LIST,			 STATUS_LOGGEDIN, &WorldSession::HandleGetMail						 },
		{ CMSG_SEND_MAIL,				 STATUS_LOGGEDIN, &WorldSession::HandleSendMail						 },
		{ CMSG_MAIL_TAKE_MONEY,			 STATUS_LOGGEDIN, &WorldSession::HandleTakeMoney					 },
		{ CMSG_MAIL_TAKE_ITEM,			 STATUS_LOGGEDIN, &WorldSession::HandleTakeItem						 },
		{ CMSG_MAIL_MARK_AS_READ,		 STATUS_LOGGEDIN, &WorldSession::HandleMarkAsRead					 },
		{ CMSG_MAIL_RETURN_TO_SENDER,	 STATUS_LOGGEDIN, &WorldSession::HandleReturnToSender				 },
		{ CMSG_MAIL_DELETE,				 STATUS_LOGGEDIN, &WorldSession::HandleMailDelete					 },
		{ CMSG_ITEM_TEXT_QUERY,			 STATUS_LOGGEDIN, &WorldSession::HandleItemTextQuery				 },
		{ CMSG_MAIL_CREATE_TEXT_ITEM,    STATUS_LOGGEDIN, &WorldSession::HandleMailCreateTextItem            },

		/// Cinematic
		{ CMSG_COMPLETE_CINEMATIC,		 STATUS_LOGGEDIN, &WorldSession::HandleCompleteCinema				 },
        { CMSG_NEXT_CINEMATIC_CAMERA,	 STATUS_LOGGEDIN, &WorldSession::HandleNextCinematicCamera           },

		// Battlefield
		{ CMSG_BATTLEFIELD_STATUS,		 STATUS_LOGGEDIN, &WorldSession::HandleBattlefieldStatusOpcode		 },
		
		// Misc
		{ CMSG_MOVE_TIME_SKIPPED,		 STATUS_LOGGEDIN, &WorldSession::HandleMoveTimeSkippedOpcode	  	 },
		{ CMSG_PAGE_TEXT_QUERY,			 STATUS_LOGGEDIN, &WorldSession::HandlePageQueryOpcode			  	 },
	    { CMSG_ENABLE_PVP,               STATUS_LOGGEDIN, &WorldSession::HandleEnablePvP                     },

		{ CMSG_FORCE_MOVE_ROOT_ACK,      STATUS_LOGGEDIN, &WorldSession::HandleMooveRootAck                  },
		{ CMSG_FORCE_MOVE_UNROOT_ACK,      STATUS_LOGGEDIN, &WorldSession::HandleMooveUnRootAck                  },


		


		/// End of table
        { 0,                             0,               NULL                                               }
    };

    return table;
}

//-----------------------------------------------------------------------------
void WorldSession::SystemMessage (char *format, ...) {
	va_list params;
	va_start (params, format);

	char buf[512];
	WorldPacket data;

	vsprintf (buf, format, params);
	sChatHandler.FillSystemMessageData(&data, this, buf);
	SendPacket (&data);

	va_end (params);
}

//-----------------------------------------------------------------------------
void WorldSession::SendProficiency (uint8 b1, uint8 b2, uint8 b3, uint8 b4, uint8 b5)
{
	WorldPacket data;
	data.Initialize (SMSG_SET_PROFICIENCY);
	data << b1 << b2 << b3 << b4 << b5;
	SendPacket (&data);
}

//--- END ---