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
// WorldSession.h
//

#ifndef __WORLDSESSION_H
#define __WORLDSESSION_H

class Player;
class WorldPacket;
class WorldSocket;
class WorldSession;

struct OpcodeHandler
{
    uint16 opcode;
    uint16 status;
    void (WorldSession::*handler)(WorldPacket& recvPacket);
};

enum SessionStatus
{
    STATUS_AUTHED = 0,
    STATUS_LOGGEDIN
};

typedef struct Cords {
        float x,y,z;
}Cords;

class WorldSession
{
public:
    WorldSession(uint32 id, WorldSocket *sock);
    ~WorldSession();

    void SendPacket(WorldPacket* packet);

    uint32 GetSecurity() const { return _security; }
    uint32 GetAccountId() const { return _accountId; }
    Player* GetPlayer() { return _player; }
    void SetSecurity(uint32 security) { _security = security; }
    void SetSocket(WorldSocket *sock);
    void SetPlayer(Player *plr) { _player = plr; }

    void LogoutRequest(time_t requestTime)
    {
        _logoutTime = requestTime;
    }

    bool ShouldLogOut(time_t currTime) const
    {
        return (_logoutTime > 0 && currTime >= _logoutTime + 20);
    }

    void LogoutPlayer(bool Save);

    void QueuePacket(WorldPacket& packet);
    bool Update(uint32 diff);

protected:

    /// Login screen opcodes (PlayerHandler.cpp):
    void HandleCharEnumOpcode(WorldPacket& recvPacket);
    void HandleCharDeleteOpcode(WorldPacket& recvPacket);
    void HandleCharCreateOpcode(WorldPacket& recvPacket);
    void HandlePlayerLoginOpcode(WorldPacket& recvPacket);

    /// Authentification and misc opcodes (MiscHandler.cpp):
    void HandlePingOpcode(WorldPacket& recvPacket);
    void HandleAuthSessionOpcode(WorldPacket& recvPacket);
    void HandleRepopRequestOpcode(WorldPacket& recvPacket);
    void HandleAutostoreLootItemOpcode(WorldPacket& recvPacket);
    void HandleLootMoneyOpcode(WorldPacket& recvPacket);
    void HandleLootOpcode(WorldPacket& recvPacket);
    void HandleLootReleaseOpcode(WorldPacket& recvPacket);
    void HandleWhoOpcode(WorldPacket& recvPacket);
    void HandleLogoutRequestOpcode(WorldPacket& recvPacket);
    void HandlePlayerLogoutOpcode(WorldPacket& recvPacket);
    void HandleLogoutCancelOpcode(WorldPacket& recvPacket);
    void HandleZoneUpdateOpcode(WorldPacket& recvPacket);
    void HandleSetTargetOpcode(WorldPacket& recvPacket);
    void HandleSetSelectionOpcode(WorldPacket& recvPacket);
    void HandleStandStateChangeOpcode(WorldPacket& recvPacket);
    void HandleFriendListOpcode(WorldPacket& recvPacket);
    void HandleAddFriendOpcode(WorldPacket& recvPacket);
    void HandleDelFriendOpcode(WorldPacket& recvPacket);
    void HandleBugOpcode(WorldPacket& recvPacket);
    void HandleSetAmmoOpcode(WorldPacket& recvPacket);
	void HandleAreaTriggerOpcode(WorldPacket& recvPacket);
	void HandleUpdateAccountData(WorldPacket& recvPacket);
	void HandleRequestAccountData(WorldPacket& recvPacket);
	void HandleSetActionButtonOpcode(WorldPacket& recvPacket);
    void HandleSetAtWarOpcode(WorldPacket& recvPacket);
	void HandleTogglePVPOpcode(WorldPacket& recvPacket);
    void HandleAmmoSetOpcode(WorldPacket& recvPacket);
    void HandleGameObjectUse(WorldPacket& recvPacket);
    //void HandleJoinChannelOpcode(WorldPacket& recvPacket);
    //void HandleLeaveChannelOpcode(WorldPacket& recvPacket);
	void HandlePageTextQueryOpcode( WorldPacket & recv_data );

    /// Gm Ticket System in GMTicket.cpp:
    void HandleGMTicketCreateOpcode(WorldPacket& recvPacket);
    void HandleGMTicketUpdateOpcode(WorldPacket& recvPacket);
    void HandleGMTicketDeleteOpcode(WorldPacket& recvPacket);
    void HandleGMTicketGetTicketOpcode(WorldPacket& recvPacket);
    void HandleGMTicketSystemStatusOpcode(WorldPacket& recvPacket);
    void HandleGMTicketToggleSystemStatusOpcode(WorldPacket& recvPacket);

    /// Opcodes implemented in QueryHandler.cpp:
    void HandleNameQueryOpcode(WorldPacket& recvPacket);
    void HandleQueryTimeOpcode(WorldPacket& recvPacket);
    void HandleCreatureQueryOpcode(WorldPacket& recvPacket);
    void HandleGameObjectQueryOpcode(WorldPacket& recvPacket);

    /// Opcodes implemented in MovementHandler.cpp
    void HandleMoveHeartbeatOpcode(WorldPacket& recvPacket);
    void HandleMoveWorldportAckOpcode(WorldPacket& recvPacket);
    void HandleMovementOpcodes(WorldPacket& recvPacket);
	void HandleFallOpcode( WorldPacket & recv_data );
    void HandleMoveTimeSkippedOpcode( WorldPacket & recv_data );
    void HandleMoveNotActiveMoverOpcode( WorldPacket & recv_data );
    void HandleSetActiveMoverOpcode( WorldPacket & recv_data );

    /// Opcodes implemented in GroupHandler.cpp:
    void HandleGroupInviteOpcode(WorldPacket& recvPacket);
    void HandleGroupCancelOpcode(WorldPacket& recvPacket);
    void HandleGroupAcceptOpcode(WorldPacket& recvPacket);
    void HandleGroupDeclineOpcode(WorldPacket& recvPacket);
    void HandleGroupUninviteOpcode(WorldPacket& recvPacket);
    void HandleGroupUninviteGuildOpcode(WorldPacket& recvPacket);
    void HandleGroupSetLeaderOpcode(WorldPacket& recvPacket);
    void HandleGroupDisbandOpcode(WorldPacket& recvPacket);
    void HandleLootMethodOpcode(WorldPacket& recvPacket);

    // Raid
    void HandleConvertGroupToRaidOpcode(WorldPacket& recvPacket);
    void HandleGroupChangeSubGroup(WorldPacket& recvPacket);
    void HandleGroupAssistantLeader(WorldPacket& recvPacket);
    void HandleRequestRaidInfoOpcode(WorldPacket& recvPacket);

    /// Taxi opcodes (TaxiHandler.cpp)
    void HandleTaxiNodeStatusQueryOpcode(WorldPacket& recvPacket);
    void HandleTaxiQueryAviableNodesOpcode(WorldPacket& recvPacket);
    void HandleActivateTaxiOpcode(WorldPacket& recvPacket);

    /// NPC opcodes (NPCHandler.cpp)
    void HandleTabardVendorActivateOpcode(WorldPacket& recvPacket);
    void HandleBankerActivateOpcode(WorldPacket& recvPacket);
    void HandleTrainerListOpcode(WorldPacket& recvPacket);
    void HandleTrainerBuySpellOpcode(WorldPacket& recvPacket);
    void HandlePetitionShowListOpcode(WorldPacket& recvPacket);
    void HandleGossipHelloOpcode(WorldPacket& recvPacket);
    void HandleGossipSelectOptionOpcode(WorldPacket& recvPacket);
    void HandleSpiritHealerActivateOpcode(WorldPacket& recvPacket);
    void HandleNpcTextQueryOpcode(WorldPacket& recvPacket);
    void HandleBinderActivateOpcode(WorldPacket& recvPacket);

	// Auction House opcodes
	void HandleAuctionHelloOpcode(WorldPacket& recvPacket);
	void HandleAuctionListItems( WorldPacket & recv_data );
	void HandleAuctionListBidderItems( WorldPacket & recv_data );
	void HandleAuctionSellItem( WorldPacket & recv_data );
	void HandleAuctionListOwnerItems( WorldPacket & recv_data );
	void HandleAuctionPlaceBid( WorldPacket & recv_data );

	// Mail opcodes
	void HandleGetMail( WorldPacket & recv_data );
	void HandleSendMail( WorldPacket & recv_data );
	void HandleTakeMoney( WorldPacket & recv_data );
	void HandleTakeItem( WorldPacket & recv_data );
	void HandleMarkAsRead( WorldPacket & recv_data );
	void HandleReturnToSender( WorldPacket & recv_data );
	void HandleMailDelete( WorldPacket & recv_data );
	void HandleItemTextQuery( WorldPacket & recv_data);
	void HandleMailTime(WorldPacket & recv_data);

    /// Item opcodes (ItemHandler.cpp)
    void HandleSwapInvItemOpcode(WorldPacket& recvPacket);
	void HandleSwapItemOpcode(WorldPacket& recvPacket);
    void HandleDestroyItemOpcode(WorldPacket& recvPacket);
    void HandleAutoEquipItemOpcode(WorldPacket& recvPacket);
    void HandleItemQuerySingleOpcode(WorldPacket& recvPacket);
    void HandleSellItemOpcode(WorldPacket& recvPacket);
    void HandleBuyItemInSlotOpcode(WorldPacket& recvPacket);
    void HandleBuyItemOpcode(WorldPacket& recvPacket);
    void HandleListInventoryOpcode(WorldPacket& recvPacket);
	void HandleAutoStoreBagItemOpcode(WorldPacket& recvPacket);
	void HandleBuyBackOpcode(WorldPacket& recvPacket);
	void HandleSplitOpcode(WorldPacket& recvPacket);
	
    /// Combat opcodes (CombatHandler.cpp)
    void HandleAttackSwingOpcode(WorldPacket& recvPacket);
    void HandleAttackStopOpcode(WorldPacket& recvPacket);

    /// Spell opcodes (SpellHandler.cpp)
    void HandleUseItemOpcode(WorldPacket& recvPacket);
    void HandleCastSpellOpcode(WorldPacket& recvPacket);
    void HandleCancelCastOpcode(WorldPacket& recvPacket);
    void HandleCancelAuraOpcode(WorldPacket& recvPacket);
    void HandleCancelChannellingOpcode(WorldPacket& recvPacket);

    /// Skill opcodes (SkillHandler.spp)
    //void HandleSkillLevelUpOpcode(WorldPacket& recvPacket);
	void HandleLearnTalentOpcode(WorldPacket& recvPacket);

    /// Quest opcodes (QuestHandler.cpp)
    void HandleQuestgiverStatusQueryOpcode(WorldPacket& recvPacket);
    void HandleQuestgiverHelloOpcode(WorldPacket& recvPacket);
    void HandleQuestgiverAcceptQuestOpcode(WorldPacket& recvPacket);
	void HandleQuestgiverCancelOpcode(WorldPacket& recvPacket);
    void HandleQuestgiverChooseRewardOpcode(WorldPacket& recvPacket);
    void HandleQuestgiverRequestRewardOpcode(WorldPacket& recvPacket);
	void HandleQuestGiverQueryQuestOpcode( WorldPacket& recvPacket );
    void HandleQuestQueryOpcode(WorldPacket& recvPacket);
    void HandleQuestgiverCompleteQuestOpcode( WorldPacket & recvPacket );
    void HandleQuestlogRemoveQuestOpcode(WorldPacket& recvPacket);

    /// Chat opcodes (Chat.cpp)
    void HandleMessagechatOpcode(WorldPacket& recvPacket);
    void HandleTextEmoteOpcode(WorldPacket& recvPacket);

    /// Corpse opcodes (Corpse.cpp)
    void HandleCorpseReclaimOpcode( WorldPacket& recvPacket );
    void HandleCorpseQueryOpcode( WorldPacket& recvPacket );
    void HandleResurrectResponseOpcode(WorldPacket& recvPacket);

	/// Channel Opcodes (ChannelHandler.cpp)
	void HandleChannelJoin(WorldPacket& recvPacket);
	void HandleChannelLeave(WorldPacket& recvPacket);
	void HandleChannelList(WorldPacket& recvPacket);
	void HandleChannelPassword(WorldPacket& recvPacket);
	void HandleChannelSetOwner(WorldPacket& recvPacket);
	void HandleChannelOwner(WorldPacket& recvPacket);
	void HandleChannelModerator(WorldPacket& recvPacket);
	void HandleChannelUnmoderator(WorldPacket& recvPacket);
	void HandleChannelMute(WorldPacket& recvPacket);
	void HandleChannelUnmute(WorldPacket& recvPacket);
	void HandleChannelInvite(WorldPacket& recvPacket);
	void HandleChannelKick(WorldPacket& recvPacket);
	void HandleChannelBan(WorldPacket& recvPacket);
	void HandleChannelUnban(WorldPacket& recvPacket);
	void HandleChannelAnnounce(WorldPacket& recvPacket);
	void HandleChannelModerate(WorldPacket& recvPacket);

	// Duel
	void HandleDuelAccepted(WorldPacket & recv_data);
	void HandleDuelCancelled(WorldPacket & recv_data);

	// Trade
	void HandleInitiateTrade(WorldPacket & recv_data);
	void HandleBeginTrade(WorldPacket & recv_data);
	void HandleBusyTrade(WorldPacket & recv_data);
	void HandleIgnoreTrade(WorldPacket & recv_data);
	void HandleAcceptTrade(WorldPacket & recv_data);
	void HandleUnacceptTrade(WorldPacket & recv_data);
	void HandleCancelTrade(WorldPacket & recv_data);
	void HandleSetTradeItem(WorldPacket & recv_data);
	void HandleClearTradeItem(WorldPacket & recv_data);
	void HandleSetTradeGold(WorldPacket & recv_data);

    // Guild
    void HandleGuildQuery(WorldPacket & recv_data);
    void HandleCreateGuild(WorldPacket & recv_data);                   
    void HandleInviteToGuild(WorldPacket & recv_data);              
    void HandleGuildAccept(WorldPacket & recv_data);             
    void HandleGuildDecline(WorldPacket & recv_data);
    void HandleGuildInfo(WorldPacket & recv_data);
    void HandleGuildRoster(WorldPacket & recv_data);
    void HandleGuildPromote(WorldPacket & recv_data);
    void HandleGuildDemote(WorldPacket & recv_data);
    void HandleGuildLeave(WorldPacket & recv_data);
    void HandleGuildRemove(WorldPacket & recv_data);
    void HandleGuildDisband(WorldPacket & recv_data);
    void HandleGuildLeader(WorldPacket & recv_data);
    void HandleGuildMotd(WorldPacket & recv_data);
    void HandleGuildRank(WorldPacket & recv_data);
    void HandleGuildAddRank(WorldPacket & recv_data);
    void HandleGuildDelRank(WorldPacket & recv_data);
    void HandleGuildSetPublicNote(WorldPacket & recv_data);
    void HandleGuildSetOfficerNote(WorldPacket & recv_data);
    void HandleSaveGuildEmblem(WorldPacket & recv_data);
    void HandlePetitionBuy(WorldPacket & recv_data);
    void HandlePetitionShowSignatures(WorldPacket & recv_data);
    void HandlePetitionTurnInPetition(WorldPacket & recv_data);
    void HandlePetitionQuery(WorldPacket & recv_data);
    void HandlePetitionOffer(WorldPacket & recv_data);
    void HandlePetitionSign(WorldPacket &recv_data);
    void HandlePetitionRename(WorldPacket & recv_data);
	void HandleSetGuildInformation(WorldPacket & recv_data);
	
    // Pet
    void HandlePetAction(WorldPacket & recv_data);
	void HandlePetInfo(WorldPacket & recv_data);
    void HandlePetNameQuery(WorldPacket & recv_data);
	void HandleStablePet(WorldPacket & recv_data);
	void HandleUnstablePet(WorldPacket & recv_data);
	void HandleStabledPetList(WorldPacket & recv_data);
	
    /// Helper functions
    void SetNpcFlagsForTalkToQuest(const uint64& guid, const uint64& targetGuid);

    //! Returns handlers table
    OpcodeHandler* _GetOpcodeHandlerTable() const;

	//Tutorials
	void HandleTutorialFlag ( WorldPacket & recv_data );
	void HandleTutorialClear( WorldPacket & recv_data );
	void HandleTutorialReset( WorldPacket & recv_data );

private:
    Player *_player;
    WorldSocket *_socket;

    uint32 _security; // 0 - normal, >= 1 - GM
    uint32 _accountId;

    time_t _logoutTime; // time we received a logout request -- wait 20 seconds, and quit

    ZThread::LockedQueue<WorldPacket*,ZThread::FastMutex> _recvQueue;
};

#endif
