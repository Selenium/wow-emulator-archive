unit OpcodeHandler;

interface

uses
    Windows, SysUtils, OpConst, LbCipher, LbBigInt, Classes,
    ByteArrayHandler, CharHandler, DbcFieldsConst, DIalogs,
    WinSock, DateUtils, ZLib, Forms, StrUtils, ItemHandler, LbClass,
    Graphics, CHarConst, Formulas;

type
  TCryptKey = record
    key: array[0..3]of byte;
    initialized: boolean;
  end;

  TPlayer = class(TObject)
  private
    //FOwner: TThread;
    CharsGuidArr: array[0..19,0..2]of integer; //charID,loGUID,hiGUID
    CharsCount: integer; //0-19 max enough
  public
    ID: integer;
    acc_name,password,characters: string;
    rem_ip_addr: string;
    timezone_bias: dword;
    Sockt: integer;
    SS_Hash: array[0..39]of byte;
    salt: array[0..31]of byte;
    bi_B,bi_N,bi_v,bi_R : TLbBigInt;
    IsAuthed,LogoutCanceled: boolean;
    CrKey: TCryptKey;
    CurrChar: TCharacter;
    AccessLevel: Byte; //Уровень доступа
    SendBuff: TSendOpcodeArr;
    ReceiveBuff: TReceiveOpcodeArr;
    constructor Create(name: string);
    procedure Decode(var buff: array of byte);
    procedure Encode;
    procedure SendPacket; //Threaded send later
  end;

  OpCodeHandleProcs = procedure(Sender: TPlayer);

  function GetOnlinePlayerByGuid(Guid: Int64): TPlayer;
  function GetPlayerByName(name : string): TPlayer;
  function GetVendorItemsByVendorID(ID: Integer): String;
  procedure SaveCharToDBC(Sender: TPlayer);
  //procedure ExitChar(sock: TSocket);
  //procedure ExitPlayer(sock: TSocket);

  procedure ReadFromWorldSocket(Sock:TSocket);
  procedure SwapFailedResponce(Sender: TPlayer; errorId: TInventoryChangeFailure);overload;
  procedure SwapFailedResponce(Sender: TPlayer; errorId: TInventoryChangeFailure; item: TItem);overload;

	procedure MSG_NULL_ACTION_handler(Sender: TPlayer);
	procedure CMSG_BOOTME_handler(Sender: TPlayer);
	procedure CMSG_DBLOOKUP_handler(Sender: TPlayer);
	procedure CMSG_QUERY_OBJECT_POSITION_handler(Sender: TPlayer);
	procedure CMSG_QUERY_OBJECT_ROTATION_handler(Sender: TPlayer);
	procedure CMSG_WORLD_TELEPORT_handler(Sender: TPlayer);
	procedure CMSG_TELEPORT_TO_UNIT_handler(Sender: TPlayer);
	procedure CMSG_ZONE_MAP_handler(Sender: TPlayer);
	procedure CMSG_DEBUG_CHANGECELLZONE_handler(Sender: TPlayer);
	procedure CMSG_EMBLAZON_TABARD_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_UNEMBLAZON_TABARD_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_RECHARGE_handler(Sender: TPlayer);
	procedure CMSG_LEARN_SPELL_handler(Sender: TPlayer);
	procedure CMSG_CREATEMONSTER_handler(Sender: TPlayer);
	procedure CMSG_DESTROYMONSTER_handler(Sender: TPlayer);
	procedure CMSG_CREATEITEM_handler(Sender: TPlayer);
	procedure CMSG_CREATEGAMEOBJECT_handler(Sender: TPlayer);
	procedure CMSG_MAKEMONSTERATTACKME_handler(Sender: TPlayer);
	procedure CMSG_MAKEMONSTERATTACKGUID_handler(Sender: TPlayer);
	procedure CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_FORCEACTION_handler(Sender: TPlayer);
	procedure CMSG_FORCEACTIONONOTHER_handler(Sender: TPlayer);
	procedure CMSG_FORCEACTIONSHOW_handler(Sender: TPlayer);
	procedure CMSG_UNDRESSPLAYER_handler(Sender: TPlayer);
	procedure CMSG_BEASTMASTER_handler(Sender: TPlayer);
	procedure CMSG_GODMODE_handler(Sender: TPlayer);
	procedure CMSG_CHEAT_SETMONEY_handler(Sender: TPlayer);
	procedure CMSG_LEVEL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_PET_LEVEL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_LEVELUP_CHEAT_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_COOLDOWN_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_USE_SKILL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_FLAG_QUEST_handler(Sender: TPlayer);
	procedure CMSG_FLAG_QUEST_FINISH_handler(Sender: TPlayer);
	procedure CMSG_CLEAR_QUEST_handler(Sender: TPlayer);
	procedure CMSG_SEND_EVENT_handler(Sender: TPlayer);
	procedure CMSG_DEBUG_AISTATE_handler(Sender: TPlayer);
	procedure CMSG_DISABLE_PVP_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_ADVANCE_SPAWN_TIME_handler(Sender: TPlayer);
	procedure CMSG_PVP_PORT_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_AUTH_SRP6_BEGIN_handler(Sender: TPlayer);
	procedure CMSG_AUTH_SRP6_PROOF_handler(Sender: TPlayer);
	procedure CMSG_AUTH_SRP6_RECODE_handler(Sender: TPlayer);
	procedure CMSG_CHAR_CREATE_handler(Sender: TPlayer);
	procedure CMSG_CHAR_ENUM_handler(Sender: TPlayer);
	procedure CMSG_CHAR_DELETE_handler(Sender: TPlayer);
	procedure CMSG_PLAYER_LOGIN_handler(Sender: TPlayer);
	procedure CMSG_GAMETIME_SET_handler(Sender: TPlayer);
	procedure CMSG_GAMESPEED_SET_handler(Sender: TPlayer);
	procedure CMSG_SERVERTIME_handler(Sender: TPlayer);
	procedure CMSG_PLAYER_LOGOUT_handler(Sender: TPlayer);
	procedure CMSG_LOGOUT_REQUEST_handler(Sender: TPlayer);
	procedure CMSG_LOGOUT_CANCEL_handler(Sender: TPlayer);
	procedure CMSG_NAME_QUERY_handler(Sender: TPlayer);
	procedure CMSG_PET_NAME_QUERY_handler(Sender: TPlayer);
	procedure CMSG_GUILD_QUERY_handler(Sender: TPlayer);
	procedure CMSG_ITEM_QUERY_SINGLE_handler(Sender: TPlayer);
	procedure CMSG_ITEM_QUERY_MULTIPLE_handler(Sender: TPlayer);
	procedure CMSG_PAGE_TEXT_QUERY_handler(Sender: TPlayer);
	procedure CMSG_QUEST_QUERY_handler(Sender: TPlayer);
	procedure CMSG_GAMEOBJECT_QUERY_handler(Sender: TPlayer);
	procedure CMSG_CREATURE_QUERY_handler(Sender: TPlayer);
	procedure CMSG_WHO_handler(Sender: TPlayer);
	procedure CMSG_WHOIS_handler(Sender: TPlayer);
	procedure CMSG_FRIEND_LIST_handler(Sender: TPlayer);
	procedure CMSG_ADD_FRIEND_handler(Sender: TPlayer);
	procedure CMSG_DEL_FRIEND_handler(Sender: TPlayer);
	procedure CMSG_ADD_IGNORE_handler(Sender: TPlayer);
	procedure CMSG_DEL_IGNORE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_CREATE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_INVITE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_ACCEPT_handler(Sender: TPlayer);
	procedure CMSG_GUILD_DECLINE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_INFO_handler(Sender: TPlayer);
	procedure CMSG_GUILD_ROSTER_handler(Sender: TPlayer);
	procedure CMSG_GUILD_PROMOTE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_DEMOTE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_LEAVE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_REMOVE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_DISBAND_handler(Sender: TPlayer);
	procedure CMSG_GUILD_LEADER_handler(Sender: TPlayer);
	procedure CMSG_GUILD_MOTD_handler(Sender: TPlayer);
	procedure UMSG_UPDATE_GUILD_handler(Sender: TPlayer);
	procedure CMSG_USE_ITEM_handler(Sender: TPlayer);
	procedure CMSG_OPEN_ITEM_handler(Sender: TPlayer);
	procedure CMSG_READ_ITEM_handler(Sender: TPlayer);
	procedure CMSG_GAMEOBJ_USE_handler(Sender: TPlayer);
	procedure CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_AREATRIGGER_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_FORWARD_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_BACKWARD_handler(Sender: TPlayer);
	procedure MSG_MOVE_STOP_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_STRAFE_LEFT_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_STRAFE_RIGHT_handler(Sender: TPlayer);
	procedure MSG_MOVE_STOP_STRAFE_handler(Sender: TPlayer);
	procedure MSG_MOVE_JUMP_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_TURN_LEFT_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_TURN_RIGHT_handler(Sender: TPlayer);
	procedure MSG_MOVE_STOP_TURN_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_PITCH_UP_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_PITCH_DOWN_handler(Sender: TPlayer);
	procedure MSG_MOVE_STOP_PITCH_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RUN_MODE_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_WALK_MODE_handler(Sender: TPlayer);
	procedure MSG_MOVE_TOGGLE_LOGGING_handler(Sender: TPlayer);
	procedure MSG_MOVE_TELEPORT_handler(Sender: TPlayer);
	procedure MSG_MOVE_TELEPORT_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_TELEPORT_ACK_handler(Sender: TPlayer);
	procedure MSG_MOVE_TOGGLE_FALL_LOGGING_handler(Sender: TPlayer);
	procedure MSG_MOVE_FALL_LAND_handler(Sender: TPlayer);
	procedure MSG_MOVE_START_SWIM_handler(Sender: TPlayer);
	procedure MSG_MOVE_STOP_SWIM_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RUN_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RUN_SPEED_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RUN_BACK_SPEED_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_WALK_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_WALK_SPEED_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_SWIM_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_SWIM_SPEED_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_SWIM_BACK_SPEED_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_ALL_SPEED_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_TURN_RATE_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_TURN_RATE_handler(Sender: TPlayer);
	procedure MSG_MOVE_TOGGLE_COLLISION_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_FACING_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_PITCH_handler(Sender: TPlayer);
	procedure MSG_MOVE_WORLDPORT_ACK_handler(Sender: TPlayer);
	procedure MSG_MOVE_SET_RAW_POSITION_ACK_handler(Sender: TPlayer);
	procedure CMSG_MOVE_SET_RAW_POSITION_handler(Sender: TPlayer);
	procedure CMSG_FORCE_RUN_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
	procedure CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
	procedure CMSG_FORCE_SWIM_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
	procedure CMSG_FORCE_MOVE_ROOT_ACK_handler(Sender: TPlayer);
	procedure CMSG_FORCE_MOVE_UNROOT_ACK_handler(Sender: TPlayer);
	procedure MSG_MOVE_ROOT_handler(Sender: TPlayer);
	procedure MSG_MOVE_UNROOT_handler(Sender: TPlayer);
	procedure MSG_MOVE_HEARTBEAT_handler(Sender: TPlayer);
	procedure CMSG_MOVE_KNOCK_BACK_ACK_handler(Sender: TPlayer);
	procedure MSG_MOVE_KNOCK_BACK_handler(Sender: TPlayer);
	procedure CMSG_MOVE_HOVER_ACK_handler(Sender: TPlayer);
	procedure MSG_MOVE_HOVER_handler(Sender: TPlayer);
	procedure CMSG_TRIGGER_CINEMATIC_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_OPENING_CINEMATIC_handler(Sender: TPlayer);
	procedure CMSG_NEXT_CINEMATIC_CAMERA_handler(Sender: TPlayer);
	procedure CMSG_COMPLETE_CINEMATIC_handler(Sender: TPlayer);
	procedure CMSG_TUTORIAL_FLAG_handler(Sender: TPlayer);
	procedure CMSG_TUTORIAL_CLEAR_handler(Sender: TPlayer);
	procedure CMSG_TUTORIAL_RESET_handler(Sender: TPlayer);
	procedure CMSG_STANDSTATECHANGE_handler(Sender: TPlayer);
	procedure CMSG_AUTOEQUIP_GROUND_ITEM_handler(Sender: TPlayer);
	procedure CMSG_AUTOSTORE_GROUND_ITEM_handler(Sender: TPlayer);
	procedure CMSG_AUTOSTORE_LOOT_ITEM_handler(Sender: TPlayer);
	procedure CMSG_STORE_LOOT_IN_SLOT_handler(Sender: TPlayer);
	procedure CMSG_AUTOEQUIP_ITEM_handler(Sender: TPlayer);
	procedure CMSG_AUTOSTORE_BAG_ITEM_handler(Sender: TPlayer);
	procedure CMSG_SWAP_ITEM_handler(Sender: TPlayer);
	procedure CMSG_SWAP_INV_ITEM_handler(Sender: TPlayer);
	procedure CMSG_SPLIT_ITEM_handler(Sender: TPlayer);
	procedure CMSG_PICKUP_ITEM_handler(Sender: TPlayer);
	procedure CMSG_DROP_ITEM_handler(Sender: TPlayer);
	procedure CMSG_DESTROYITEM_handler(Sender: TPlayer);
	procedure CMSG_INSPECT_handler(Sender: TPlayer);
	procedure CMSG_INITIATE_TRADE_handler(Sender: TPlayer);
	procedure CMSG_BEGIN_TRADE_handler(Sender: TPlayer);
	procedure CMSG_BUSY_TRADE_handler(Sender: TPlayer);
	procedure CMSG_IGNORE_TRADE_handler(Sender: TPlayer);
	procedure CMSG_ACCEPT_TRADE_handler(Sender: TPlayer);
	procedure CMSG_UNACCEPT_TRADE_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_TRADE_handler(Sender: TPlayer);
	procedure CMSG_SET_TRADE_ITEM_handler(Sender: TPlayer);
	procedure CMSG_CLEAR_TRADE_ITEM_handler(Sender: TPlayer);
	procedure CMSG_SET_TRADE_GOLD_handler(Sender: TPlayer);
	procedure CMSG_SET_FACTION_ATWAR_handler(Sender: TPlayer);
	procedure CMSG_SET_FACTION_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_SET_ACTION_BUTTON_handler(Sender: TPlayer);
	procedure CMSG_NEW_SPELL_SLOT_handler(Sender: TPlayer);
	procedure CMSG_CAST_SPELL_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_CAST_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_AURA_handler(Sender: TPlayer);
	procedure MSG_CHANNEL_START_handler(Sender: TPlayer);
	procedure MSG_CHANNEL_UPDATE_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_CHANNELLING_handler(Sender: TPlayer);
	procedure CMSG_SET_SELECTION_handler(Sender: TPlayer);
	procedure CMSG_SET_TARGET_handler(Sender: TPlayer);
	procedure CMSG_UNUSED_handler(Sender: TPlayer);
	procedure CMSG_UNUSED2_handler(Sender: TPlayer);
	procedure CMSG_ATTACKSWING_handler(Sender: TPlayer);
	procedure CMSG_ATTACKSTOP_handler(Sender: TPlayer);
	procedure CMSG_SHEATHE_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_SAVE_PLAYER_handler(Sender: TPlayer);
	procedure CMSG_SETDEATHBINDPOINT_handler(Sender: TPlayer);
	procedure CMSG_GETDEATHBINDZONE_handler(Sender: TPlayer);
	procedure CMSG_REPOP_REQUEST_handler(Sender: TPlayer);
	procedure CMSG_RESURRECT_RESPONSE_handler(Sender: TPlayer);
	procedure CMSG_LOOT_handler(Sender: TPlayer);
	procedure CMSG_LOOT_MONEY_handler(Sender: TPlayer);
	procedure CMSG_LOOT_RELEASE_handler(Sender: TPlayer);
	procedure CMSG_DUEL_ACCEPTED_handler(Sender: TPlayer);
	procedure CMSG_DUEL_CANCELLED_handler(Sender: TPlayer);
	procedure CMSG_MOUNTSPECIAL_ANIM_handler(Sender: TPlayer);
	procedure CMSG_PET_SET_ACTION_handler(Sender: TPlayer);
	procedure CMSG_PET_ACTION_handler(Sender: TPlayer);
	procedure CMSG_PET_ABANDON_handler(Sender: TPlayer);
	procedure CMSG_PET_RENAME_handler(Sender: TPlayer);
	procedure CMSG_PET_CAST_SPELL_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_GOSSIP_HELLO_handler(Sender: TPlayer);
	procedure CMSG_GOSSIP_SELECT_OPTION_handler(Sender: TPlayer);
	procedure CMSG_NPC_TEXT_QUERY_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_STATUS_QUERY_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_HELLO_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_QUERY_QUEST_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_QUEST_AUTOLAUNCH_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_ACCEPT_QUEST_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_COMPLETE_QUEST_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_REQUEST_REWARD_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_CHOOSE_REWARD_handler(Sender: TPlayer);
	procedure CMSG_QUESTGIVER_CANCEL_handler(Sender: TPlayer);
	procedure CMSG_QUESTLOG_SWAP_QUEST_handler(Sender: TPlayer);
	procedure CMSG_QUESTLOG_REMOVE_QUEST_handler(Sender: TPlayer);
	procedure CMSG_QUEST_CONFIRM_ACCEPT_handler(Sender: TPlayer);
	procedure CMSG_PUSHQUESTTOPARTY_handler(Sender: TPlayer);
	procedure CMSG_LIST_INVENTORY_handler(Sender: TPlayer);
	procedure CMSG_SELL_ITEM_handler(Sender: TPlayer);
	procedure CMSG_BUY_ITEM_handler(Sender: TPlayer);
	procedure CMSG_BUY_ITEM_IN_SLOT_handler(Sender: TPlayer);
	procedure CMSG_TRAINER_LIST_handler(Sender: TPlayer);
	procedure CMSG_TRAINER_BUY_SPELL_handler(Sender: TPlayer);
	procedure CMSG_BINDER_ACTIVATE_handler(Sender: TPlayer);
	procedure CMSG_BANKER_ACTIVATE_handler(Sender: TPlayer);
	procedure CMSG_BUY_BANK_SLOT_handler(Sender: TPlayer);
	procedure CMSG_PETITION_SHOWLIST_handler(Sender: TPlayer);
	procedure CMSG_PETITION_BUY_handler(Sender: TPlayer);
	procedure CMSG_PETITION_SHOW_SIGNATURES_handler(Sender: TPlayer);
	procedure CMSG_PETITION_SIGN_handler(Sender: TPlayer);
	procedure MSG_PETITION_DECLINE_handler(Sender: TPlayer);
	procedure CMSG_OFFER_PETITION_handler(Sender: TPlayer);
	procedure CMSG_TURN_IN_PETITION_handler(Sender: TPlayer);
	procedure CMSG_PETITION_QUERY_handler(Sender: TPlayer);
	procedure CMSG_BUG_handler(Sender: TPlayer);
	procedure CMSG_PLAYED_TIME_handler(Sender: TPlayer);
	procedure CMSG_QUERY_TIME_handler(Sender: TPlayer);
	procedure MSG_SPLIT_MONEY_handler(Sender: TPlayer);
	procedure CMSG_RECLAIM_CORPSE_handler(Sender: TPlayer);
	procedure CMSG_WRAP_ITEM_handler(Sender: TPlayer);
	procedure MSG_MINIMAP_PING_handler(Sender: TPlayer);
	procedure CMSG_SET_SKILL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_PING_handler(Sender: TPlayer);
	procedure CMSG_SETSHEATHED_handler(Sender: TPlayer);
	procedure CMSG_PLAYER_MACRO_OBSOLETE_handler(Sender: TPlayer);
	procedure CMSG_GHOST_handler(Sender: TPlayer);
	procedure CMSG_GM_INVIS_handler(Sender: TPlayer);
	procedure CMSG_SCREENSHOT_handler(Sender: TPlayer);
	procedure MSG_GM_BIND_OTHER_handler(Sender: TPlayer);
	procedure MSG_GM_SUMMON_handler(Sender: TPlayer);
	procedure CMSG_AUTH_SESSION_handler(Sender: TPlayer);
	procedure MSG_GM_SHOWLABEL_handler(Sender: TPlayer);
	procedure MSG_ADD_DYNAMIC_TARGET_handler(Sender: TPlayer);
	procedure MSG_SAVE_GUILD_EMBLEM_handler(Sender: TPlayer);
	procedure MSG_TABARDVENDOR_ACTIVATE_handler(Sender: TPlayer);
	procedure CMSG_ZONEUPDATE_handler(Sender: TPlayer);
	procedure CMSG_GM_SET_SECURITY_GROUP_handler(Sender: TPlayer);
	procedure CMSG_GM_NUKE_handler(Sender: TPlayer);
	procedure MSG_RANDOM_ROLL_handler(Sender: TPlayer);
	procedure CMSG_RWHOIS_handler(Sender: TPlayer);
	procedure MSG_LOOKING_FOR_GROUP_handler(Sender: TPlayer);
	procedure CMSG_SET_LOOKING_FOR_GROUP_handler(Sender: TPlayer);
	procedure CMSG_UNLEARN_SPELL_handler(Sender: TPlayer);
	procedure CMSG_UNLEARN_SKILL_handler(Sender: TPlayer);
	procedure CMSG_DECHARGE_handler(Sender: TPlayer);
	procedure CMSG_GMTICKET_CREATE_handler(Sender: TPlayer);
	procedure CMSG_GMTICKET_UPDATETEXT_handler(Sender: TPlayer);
	procedure CMSG_REQUEST_ACCOUNT_DATA_handler(Sender: TPlayer);
	procedure CMSG_UPDATE_ACCOUNT_DATA_handler(Sender: TPlayer);
	procedure CMSG_GM_TEACH_handler(Sender: TPlayer);
	procedure CMSG_GM_CREATE_ITEM_TARGET_handler(Sender: TPlayer);
	procedure CMSG_GMTICKET_GETTICKET_handler(Sender: TPlayer);
	procedure CMSG_UNLEARN_TALENTS_handler(Sender: TPlayer);
	procedure MSG_CORPSE_QUERY_handler(Sender: TPlayer);
	procedure CMSG_GMTICKET_DELETETICKET_handler(Sender: TPlayer);
	procedure CMSG_GMTICKET_SYSTEMSTATUS_handler(Sender: TPlayer);
	procedure CMSG_SPIRIT_HEALER_ACTIVATE_handler(Sender: TPlayer);
	procedure CMSG_SET_STAT_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_SKILL_BUY_STEP_handler(Sender: TPlayer);
	procedure CMSG_SKILL_BUY_RANK_handler(Sender: TPlayer);
	procedure CMSG_XP_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_CHARACTER_POINT_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_CHAT_IGNORED_handler(Sender: TPlayer);
	procedure CMSG_GM_VISION_handler(Sender: TPlayer);
	procedure CMSG_SERVER_COMMAND_handler(Sender: TPlayer);
	procedure CMSG_GM_SILENCE_handler(Sender: TPlayer);
	procedure CMSG_GM_REVEALTO_handler(Sender: TPlayer);
	procedure CMSG_GM_RESURRECT_handler(Sender: TPlayer);
	procedure CMSG_GM_SUMMONMOB_handler(Sender: TPlayer);
	procedure CMSG_GM_MOVECORPSE_handler(Sender: TPlayer);
	procedure CMSG_GM_FREEZE_handler(Sender: TPlayer);
	procedure CMSG_GM_UBERINVIS_handler(Sender: TPlayer);
	procedure CMSG_GM_REQUEST_PLAYER_INFO_handler(Sender: TPlayer);
	procedure CMSG_GUILD_RANK_handler(Sender: TPlayer);
	procedure CMSG_GUILD_ADD_RANK_handler(Sender: TPlayer);
	procedure CMSG_GUILD_DEL_RANK_handler(Sender: TPlayer);
	procedure CMSG_GUILD_SET_PUBLIC_NOTE_handler(Sender: TPlayer);
	procedure CMSG_GUILD_SET_OFFICER_NOTE_handler(Sender: TPlayer);
	procedure CMSG_CLEAR_EXPLORATION_handler(Sender: TPlayer);
	procedure CMSG_BATTLEFIELD_LIST_handler(Sender: TPlayer);
	procedure CMSG_BATTLEFIELD_JOIN_handler(Sender: TPlayer);
	procedure CMSG_TAXICLEARNODE_handler(Sender: TPlayer);
	procedure CMSG_TAXIENABLENODE_handler(Sender: TPlayer);
	procedure CMSG_LEARN_TALENT_handler(Sender: TPlayer);
	procedure CMSG_ENABLE_PVP_handler(Sender: TPlayer);
	procedure CMSG_SET_AMMO_handler(Sender: TPlayer);
	procedure CMSG_SET_ACTIVE_MOVER_handler(Sender: TPlayer);
	procedure CMSG_PET_CANCEL_AURA_handler(Sender: TPlayer);
	procedure CMSG_PLAYER_AI_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_AUTO_REPEAT_SPELL_handler(Sender: TPlayer);
	procedure MSG_GM_ACCOUNT_ONLINE_handler(Sender: TPlayer);
	procedure MSG_LIST_STABLED_PETS_handler(Sender: TPlayer);
	procedure CMSG_STABLE_PET_handler(Sender: TPlayer);
	procedure CMSG_UNSTABLE_PET_handler(Sender: TPlayer);
	procedure CMSG_BUY_STABLE_SLOT_handler(Sender: TPlayer);
	procedure CMSG_STABLE_REVIVE_PET_handler(Sender: TPlayer);
	procedure CMSG_STABLE_SWAP_PET_handler(Sender: TPlayer);
	procedure MSG_QUEST_PUSH_RESULT_handler(Sender: TPlayer);
	procedure CMSG_REQUEST_PET_INFO_handler(Sender: TPlayer);
	procedure CMSG_FAR_SIGHT_handler(Sender: TPlayer);
	procedure CMSG_ENABLE_DAMAGE_LOG_handler(Sender: TPlayer);
	procedure CMSG_GROUP_CHANGE_SUB_GROUP_handler(Sender: TPlayer);
	procedure CMSG_GROUP_SWAP_SUB_GROUP_handler(Sender: TPlayer);
	procedure CMSG_RESET_FACTION_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_AUTOSTORE_BANK_ITEM_handler(Sender: TPlayer);
	procedure CMSG_AUTOBANK_ITEM_handler(Sender: TPlayer);
	procedure CMSG_SET_DURABILITY_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_SET_PVP_RANK_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_ADD_PVP_MEDAL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_DEL_PVP_MEDAL_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_SET_PVP_TITLE_handler(Sender: TPlayer);
	procedure CMSG_GROUP_RAID_CONVERT_handler(Sender: TPlayer);
	procedure CMSG_GROUP_ASSISTANT_LEADER_handler(Sender: TPlayer);
	procedure CMSG_BUYBACK_ITEM_handler(Sender: TPlayer);
	procedure CMSG_MEETING_STONE_JOIN_handler(Sender: TPlayer);
	procedure CMSG_MEETING_STONE_LEAVE_handler(Sender: TPlayer);
	procedure CMSG_MEETING_STONE_CHEAT_handler(Sender: TPlayer);
	procedure CMSG_MEETING_STONE_INFO_handler(Sender: TPlayer);
	procedure CMSG_GMTICKETSYSTEM_TOGGLE_handler(Sender: TPlayer);
	procedure CMSG_CANCEL_GROWTH_AURA_handler(Sender: TPlayer);
	procedure CMSG_LOOT_ROLL_handler(Sender: TPlayer);
	procedure CMSG_LOOT_MASTER_GIVE_handler(Sender: TPlayer);
	procedure CMSG_REPAIR_ITEM_handler(Sender: TPlayer);
	procedure MSG_TALENT_WIPE_CONFIRM_handler(Sender: TPlayer);
	procedure CMSG_SUMMON_RESPONSE_handler(Sender: TPlayer);
	procedure MSG_MOVE_TOGGLE_GRAVITY_CHEAT_handler(Sender: TPlayer);
	procedure MSG_MOVE_FEATHER_FALL_handler(Sender: TPlayer);
	procedure MSG_MOVE_WATER_WALK_handler(Sender: TPlayer);
	procedure CMSG_SERVER_BROADCAST_handler(Sender: TPlayer);
	procedure CMSG_SELF_RES_handler(Sender: TPlayer);
	procedure CMSG_RUN_SCRIPT_handler(Sender: TPlayer);
	procedure CMSG_TOGGLE_HELM_handler(Sender: TPlayer);
	procedure CMSG_TOGGLE_CLOAK_handler(Sender: TPlayer);
	procedure CMSG_SET_EXPLORATION_handler(Sender: TPlayer);
	procedure CMSG_SET_ACTIONBAR_TOGGLES_handler(Sender: TPlayer);
	procedure UMSG_DELETE_GUILD_CHARTER_handler(Sender: TPlayer);
	procedure MSG_PETITION_RENAME_handler(Sender: TPlayer);
	procedure CMSG_ITEM_NAME_QUERY_handler(Sender: TPlayer);
	procedure CMSG_MOVE_TIME_SKIPPED_handler(Sender: TPlayer);
	procedure CMSG_BATTLEFIELD_STATUS_handler(Sender: TPlayer);

var
  OpCodeHandleTable : Array [0..723] of OpCodeHandleProcs;
  msg_cntr: integer;
  CriticalSection: _RTL_CRITICAL_SECTION;

implementation

uses UnitMain, UpdateConst, WorldObject, CellManager, NpcQuestHandler,
  AcedContainers, ChatHandler, GroupHandler, DbcHandler, CommandHandler,
  SpellHandler, MailHandler, TaxiHandler, AuctionHandler;

function GetOnlinePlayerByGuid(Guid: Int64): TPlayer;
var
  promChar: TCharacter;
begin
  result:=nil;
  promChar:=PlayerCharsHT_byGUID[Guid];
  if promChar<>nil then result:=TPlayer(promChar.owner);
end;

function GetPlayerNameByGuid(Guid: Int64): String;
var
  i: Integer;
  player_chars: PPackedPlayerCharsRecord ;
begin
  result := '';
  for i:=1 to PlayerCharDbcHandler.MaxID do
    try
      player_chars := PlayerCharDbcHandler.GetPointerPRValueByIntKey(i);
      if player_chars <> nil then
        Result := PlayerCharDbcHandler.GetStringByOffset(player_chars^.Name);
    except;
    end;
end;

function GetPlayerByName(name : string): TPlayer;
var
  i: integer;
  Player: TPlayer;
begin
  Result := nil;
  for i := 0 to LoggedPlayersHT.InnerCapacity - 1 do
    if LoggedPlayersHT.InnerKeyList[i] <> '' then begin
      Player := LoggedPlayersHT[LoggedPlayersHT.InnerKeyList[i]];
      if Player.CurrChar.name = name then begin
        Result := Player;
        Break;
      end;
    end;
end;

procedure ReadFromWorldSocket(Sock:TSocket);
var
   cmd: word;
   lmsg,lstr: string;
   i,received_len,packet_len,clear_packet_len: integer;
   CurrPlayer: TPlayer;
   ByteBuff: array of byte;
   just_created: boolean;
begin
     just_created:=false;
     CurrPlayer:=LoggedPlayersAccBySockHT[Sock];   //maxword size by sockets array can be used for fast search
     if (CurrPlayer = nil) then
     begin
          CurrPlayer:=TPlayer.Create('nil'); //just create, auth cmd only
          CurrPlayer.Sockt:=Sock;
          just_created:=true;
     end;
     while true do
     begin
       EnterCriticalSection(CriticalSection);
       try
          setlength(ByteBuff,6);
          received_len:=Recv(Sock,ByteBuff[0],6,0);
          if received_len = 6 then  //not less at least
          begin
               CurrPlayer.Decode(ByteBuff);
               packet_len:=(integer(ByteBuff[0]) shl 8)or ByteBuff[1];;
               cmd:=(integer(ByteBuff[3]) shl 8)or ByteBuff[2];
               if (packet_len <= 4) then
               begin
                    AddToLog('received World socket ='+IntToStr(Sock)+' Opcode='+OpCodesStr[cmd]+' pcktlen='+IntToStr(packet_len));
                    if (cmd < length(OpCodeHandleTable))then
                       OpCodeHandleTable[cmd](CurrPlayer);
               end
               else begin
                    clear_packet_len:=packet_len-4;
                    received_len:=Recv(Sock,CurrPlayer.ReceiveBuff.data,clear_packet_len,0);
                    if (cmd < length(OpCodeHandleTable))and(received_len=clear_packet_len)then begin
                     if (cmd <> MSG_MOVE_SET_FACING) and
                        (cmd <> CMSG_MOVE_TIME_SKIPPED) and
                        (cmd <> MSG_MOVE_HEARTBEAT) and
                        (cmd <> CMSG_PING)
                        then begin //Не показываем опкод перемещения
                      if LogLevel > 2 then begin
                        lmsg:='Opcode='+OpCodesStr[cmd]+' pcktlen='+IntToHex(packet_len,2)+' data=';lstr:=' str=';
                        for i:=0 to pred(received_len) do lmsg:=lmsg+IntToHex(CurrPlayer.ReceiveBuff.data[i],2)+' ';
                        for i:=0 to pred(received_len) do if CurrPlayer.ReceiveBuff.data[i]<>0 then lstr:=lstr+char(CurrPlayer.ReceiveBuff.data[i])+' ';
                        AddToLog('received World socket ='+IntToStr(Sock));  //+' addr='+inet_ntoa(From.sin_addr)+' port='+IntToStr(ntohs(From.sin_port)));
                        AddToLog(lmsg+' ('+lstr+')'+#$d#$a);
                      end else if LogLevel > 1 then begin
                        lmsg:='Opcode='+OpCodesStr[cmd]+' pcktlen='+IntToHex(packet_len,2);
                        AddToLog(lmsg);
                      end;
                     end;
                       {  lmsg:='Opcode='+OpCodesStr[cmd]+' pcktlen='+IntToHex(packet_len,2)+' data=';lstr:=' str=';
                         for i:=0 to pred(received_len) do lmsg:=lmsg+IntToHex(CurrPlayer.ReceiveBuff.data[i],2)+' ';
                         for i:=0 to pred(received_len) do if CurrPlayer.ReceiveBuff.data[i]<>0 then lstr:=lstr+char(CurrPlayer.ReceiveBuff.data[i])+' ';
                         AddToLog('received World socket ='+IntToStr(Sock));  //+' addr='+inet_ntoa(From.sin_addr)+' port='+IntToStr(ntohs(From.sin_port)));
                         AddToLog(lmsg+' ('+lstr+')'+#$d#$a);
                          }
                         if not(just_created)or((just_created)and(cmd=CMSG_AUTH_SESSION)) then
                         begin
                              CurrPlayer.ReceiveBuff.Init; //offset alread set to 0
                              OpCodeHandleTable[cmd](CurrPlayer);
                         end;
                    end
                    else begin
                         //read all socket buffer to clear, packet broken already
                         while (received_len > 0) do
                              received_len:=Recv(Sock,CurrPlayer.ReceiveBuff.data,maxword,0);
                         exit;
                    end;
               end;
          end
          else exit;
       finally LeaveCriticalSection(CriticalSection);
       end;
     end;
end;

{ TPlayer }
procedure TPlayer.Decode(var buff: array of byte); //(var buff: TInHeaderArray; len: integer);
var
   t: integer;
   a,b,d: byte;
const
     hsize: byte = 40;
begin
    //if Player = nil then exit;
    if not(CrKey.initialized) then exit;
    //if (len < CRYPTED_RECV_LEN) then exit;

    t := 0;
    while (t < CRYPTED_RECV_LEN) do
    begin
				a := CrKey.key[0];
				CrKey.key[0] := buff[t];
				b := buff[t];

				b := b - a;
				d := CrKey.key[1];
				a := SS_Hash[d];
				a := a xor b;
				buff[t] := a;
				a := CrKey.key[1];
				inc(a);
				CrKey.key[1] := a mod hsize;   //0x28
        inc(t);
    end;
end;

procedure TPlayer.Encode;
var
   t: integer;
   a,d: byte;
const
     hsize: byte = 40;
begin
    if not(CrKey.initialized) then exit;

    t := 0;
    while (t < CRYPTED_SEND_LEN) do
    begin
				a := CrKey.key[3];
				a := SS_hash[a] xor SendBuff.data[t];
				d := CrKey.key[2];
				a := a + d;
				SendBuff.data[t] := a;
				CrKey.key[2] := a;
				a := CrKey.key[3];
				inc(a);
				CrKey.key[3] := a mod hsize;   //0x28
        inc(t);
    end;
end;

procedure TPlayer.SendPacket;
var
   i,opcode: integer;
   lmsg: string;
begin
     SendBuff.data[0]:= byte((SendBuff.offs - 2) shr 8);
     SendBuff.data[1]:= byte(SendBuff.offs - 2);
		 opcode:=SendBuff.data[2] or (integer(SendBuff.data[3])shl 8);

     if (OpCode <> SMSG_COMPRESSED_UPDATE_OBJECT) and
        (OpCode <> SMSG_PONG) and
        (OpCode <> SMSG_DESTROY_OBJECT)
     then begin
       if LogLevel > 2 then begin
         for i:=0 to pred(SendBuff.offs) do lmsg:=lmsg+IntToHex(SendBuff.data[i],2)+' ';
         AddToLog('sent opcode='+OpCodesStr[OpCode]+' len='+IntToHex(SendBuff.offs,2)+' sock='+IntToStr(Sockt)+' msg='+lmsg+#$d#$a);
       end else if LogLevel > 1 then
         AddToLog('sent opcode='+OpCodesStr[OpCode]+' len='+IntToHex(SendBuff.offs,2)+' sock='+IntToStr(Sockt));
     end;

		 if (SendBuff.offs >= CRYPTED_SEND_LEN)then Encode;
		 Send(Sockt,SendBuff.data,SendBuff.offs,0);
end;

constructor TPlayer.Create(name: string);
var
  paccount: PPackedAccountRecord;
begin
  if name <> 'nil' then begin
    acc_name:=AnsiUpperCase(name);
    paccount := AccDbcHandler.GetPointerPRValueByStrKey(acc_name) ;
    if paccount <> nil then ID := paccount^.id;
  end;
  if AllGM then AccessLevel := 1;
  IsAuthed:=false;
  CrKey.initialized:=false;
  SendBuff:=TSendOpcodeArr.Create;
  ReceiveBuff:=TReceiveOpcodeArr.Create;
end;

procedure Movement_handler(Sender: TPlayer; OpCode: word);
var
   ltime: integer;
   Flags_tmp: Integer;
begin
     with Sender.CurrChar,Sender.ReceiveBuff do
     begin
	        Get(Flags_tmp);
          //AddToLog(IntToHex(Flags_tmp, 8));
	        Get(ltime);
	        Get(positionX);
	        Get(positionY);
	        Get(positionZ);
	        Get(positionR);
          MapCell.MoveObj(Sender.CurrChar,OpCode,ltime);
     end;
end;

procedure SwapFailedResponce(Sender: TPlayer; errorId: TInventoryChangeFailure);overload;
begin
			Sender.SendBuff.Init(SMSG_INVENTORY_CHANGE_FAILURE);
			Sender.SendBuff.Add(byte(errorId));
			Sender.SendPacket;
end;

procedure SwapFailedResponce(Sender: TPlayer; errorId: TInventoryChangeFailure; item: TItem);overload;
begin
			with Sender.SendBuff do
      begin
           Init(SMSG_INVENTORY_CHANGE_FAILURE);
			     Add(byte(errorId));
           if errorId=EQUIP_ERR_YOU_MUST_REACH_LEVEL_N then
              Add(item.PItemRecord^.RequiredLevel);
           Add(item.objGUID);
			     Add(byte(0)); //required?
			     Sender.SendPacket;
      end;
end;

procedure MSG_NULL_ACTION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BOOTME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DBLOOKUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUERY_OBJECT_POSITION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUERY_OBJECT_ROTATION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_WORLD_TELEPORT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TELEPORT_TO_UNIT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ZONE_MAP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DEBUG_CHANGECELLZONE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_EMBLAZON_TABARD_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNEMBLAZON_TABARD_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_RECHARGE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LEARN_SPELL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CREATEMONSTER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DESTROYMONSTER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CREATEITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CREATEGAMEOBJECT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MAKEMONSTERATTACKME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MAKEMONSTERATTACKGUID_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCEACTION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCEACTIONONOTHER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCEACTIONSHOW_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNDRESSPLAYER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BEASTMASTER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GODMODE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHEAT_SETMONEY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LEVEL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_LEVEL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LEVELUP_CHEAT_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_COOLDOWN_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_USE_SKILL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FLAG_QUEST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FLAG_QUEST_FINISH_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CLEAR_QUEST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SEND_EVENT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DEBUG_AISTATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DISABLE_PVP_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ADVANCE_SPAWN_TIME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PVP_PORT_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTH_SRP6_BEGIN_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTH_SRP6_PROOF_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTH_SRP6_RECODE_handler(Sender: TPlayer);
begin
	{}
end;

function CreateItemsStr(Char: TCharacter): String;
var
  i,j: Byte;
begin
   //Сохраняем инвентарь, то что на чаре и банк
   Result := '';
   for i:=0 to pred(length(Char.cItems))do
     if Char.cItems[i]<>nil then
       Result := Result + '255;'+IntToStr(Char.cItems[i].ID)+';'+IntToStr(i)+';'+IntToStr(Char.cItems[i].item_count)+';'+IntToStr(Char.cItems[i].durability)+';'+IntToStr(Char.cItems[i].random_prop)+';';

   //Сохраняем сумки на чаре
   for j := INVENTORY_SLOT_BAG_1 to INVENTORY_SLOT_BAG_4 do
     for i:=0 to 19 do
      if Char.cBagItems[j, i]<>nil then
        Result := Result +IntToStr(j)+';'+IntToStr(Char.cBagItems[j, i].ID)+';'+IntToStr(i)+';'+IntToStr(Char.cBagItems[j, i].item_count)+';'+IntToStr(Char.cBagItems[j, i].durability)+';'+IntToStr(Char.cBagItems[j, i].random_prop)+';';

   //Предметы в банковских сумках
   for j := BANK_SLOT_BAG_1 to BANK_SLOT_BAG_6 do
     for i:=0 to 19 do
      if Char.BankBagItems[j, i]<>nil then
        Result := Result +IntToStr(j)+';'+IntToStr(Char.BankBagItems[j, i].ID)+';'+IntToStr(i)+';'+IntToStr(Char.BankBagItems[j, i].item_count)+';'+IntToStr(Char.BankBagItems[j, i].durability)+';'+IntToStr(Char.BankBagItems[j, i].random_prop)+';';
end;

procedure CMSG_CHAR_CREATE_handler(Sender: TPlayer);
var
   CurrCharacter: TCharacter;
//   items_str: string;
   i,next_char_ID: integer;
   playerChar: TPackedPlayerCharsRecord;
   ActionBar: TPackedActionBar;   
   pActionBar: PPackedActionBar;
begin
     CurrCharacter:= TCharacter.Create(0,true);
     CurrCharacter.Owner:=Sender;
     CurrCharacter.InitWithCreatePacket;
  if not(PlayerCharNamesHT.Contains(CurrCharacter.name))then begin//already contains then error else add to HT, OK
          PlayerCharNamesHT.Add(CurrCharacter.name,nil);

          playerChar.Guid := CurrCharacter.objGUID ;
          playerChar.Name:=PlayerCharDbcHandler.AddString(CurrCharacter.name);
          playerChar.positionX:=CurrCharacter.positionX;
          playerChar.positionY:=CurrCharacter.positionY;
          playerChar.positionZ:=CurrCharacter.positionZ;
          playerChar.positionR:=CurrCharacter.positionR;
          playerChar.mapID_zoneID:=integer((integer(CurrCharacter.mapId) shl 16) or CurrCharacter.zoneId);
          playerChar.Flags:=CurrCharacter.Flags;
          playerChar.pgcr:=CurrCharacter.pgcr;
          playerChar.HairFaceSkin:=CurrCharacter.hairFaceSkin;
          playerChar.rest_state_f_hair:=CurrCharacter.rest_state_f_hair;
          playerChar.copper:=CurrCharacter.copper;
          playerChar.level:=CurrCharacter.Level;
          playerChar.xp:=CurrCharacter.cXp;
          playerChar.CurrHealth:=CurrCharacter.Health;
          playerChar.CurrRMEnergy:=CurrCharacter.powerCurrValue[longword(CurrCharacter.powerType)];
          playerChar.guild_ID:=0;
          playerChar.rest_xp:=0;
          playerChar.Ammo := CurrCharacter.AmmoId ;

          playerChar.atInn_AFK_DND_inFly:=integer((integer(CurrCharacter.atInn) shl 24) or (integer(CurrCharacter.AFK) shl 16) or (integer(CurrCharacter.DND) shl 8) or integer(CurrCharacter.inFly));
          playerChar.lastLogout:=double(CurrCharacter.LastLogout);
          playerChar.BindingPointX:=CurrCharacter.BindingPointX;
          playerChar.BindingPointY:=CurrCharacter.BindingPointY;
          playerChar.BindingPointZ:=CurrCharacter.BindingPointZ;
          playerChar.BindingPointR:=CurrCharacter.BindingPointR;
          playerChar.BindingPointMapID_ZoneID:=(integer(CurrCharacter.BindingPointMapID) shl 16)or CurrCharacter.BindingPointZoneID;

          //!!! items to str
{          items_str:='';
          for i:=0 to pred(length(CurrCharacter.cItems))do
              if CurrCharacter.cItems[i]<>nil then
                 items_str:=items_str+'255;'+IntToStr(CurrCharacter.cItems[i].ID)+';'+IntToStr(i)+';'+IntToStr(CurrCharacter.cItems[i].item_count)+';'+IntToStr(CurrCharacter.cItems[i].durability)+';'+IntToStr(CurrCharacter.cItems[i].random_prop)+';';}
          playerChar.Items:=PlayerCharDbcHandler.AddString(CreateItemsStr(CurrCharacter));

          playerChar.ActiveQuests:=0;
          playerChar.DoneQuests:=0;
          playerChar.TaxiMask := 0;
          playerChar.Tutorials := 0;
          playerChar.FriendList := 0;
          playerChar.IgnoreList := 0;
          playerChar.Honor := 0;
          playerChar.Talents := 0;
          playerChar.Reputation := 0;
          playerChar.Auras := 0;
          playerChar.Spells:=PlayerCharDbcHandler.AddString(CurrCharacter.cSpells);
          playerChar.Skills:=PlayerCharDbcHandler.AddString(CurrCharacter.cSkills);
          playerChar.Buttons := 0; //PlayerCharDbcHandler.AddString(CurrCharacter.cButtons);
          playerChar.ExploredZones:=PlayerCharDbcHandler.AddString(CurrCharacter.cExploredZones);
          next_char_ID:=PlayerCharDbcHandler.AddRecord(@playerChar);
          Sender.characters:=Sender.characters+IntToStr(next_char_ID)+';';
          PPackedAccountRecord(AccDbcHandler.GetPointerPRValueByStrKey(Sender.acc_name))^.Chars:=AccDbcHandler.AddString(Sender.characters);

          //Сохраняем кнопки в ActionBar
    if ActionBarDbcHandler.GetPointerPRValueByIntKey(next_char_ID) <> nil then
      ActionBarDbcHandler.RemoveRecordIntKey(next_char_ID);

    for i := 0 to 11 do ActionBar.ActionBar[i] := CurrCharacter.actionsButtons[i]; //дефолтные кнопки
    for i := 12 to 119 do ActionBar.ActionBar[i] := 0; //остальные забиваем нулями
    ActionBar.id := ActionBarDbcHandler.AddRecord(@ActionBar);
    pActionBar := ActionBarDbcHandler.GetPointerPRValueByIntKey(ActionBar.id) ;
    if pActionBar <> nil then pActionBar^.id := next_char_ID ;

          Sender.SendBuff.Init(SMSG_CHAR_CREATE);
		      Sender.SendBuff.Add(byte(CHAR_CREATE_OK));
          Sender.SendPacket;
  end else begin
          Sender.SendBuff.Init(SMSG_CHAR_CREATE);
		      Sender.SendBuff.Add(byte(CHAR_CREATE_NAME_IN_USE));
          Sender.SendPacket;
     end;
     CurrCharacter.Destroy;
end;

procedure CMSG_CHAR_ENUM_handler(Sender: TPlayer);
var
   i,j,cListLen,iListLen,pgcr,itemsCount: integer;
   charList,itemList: array of integer;
   itemsArr: array[EQUIPMENT_SLOT_HEAD..EQUIPMENT_SLOT_RANGED]of integer;
   tempGUID: int64;
   pplchar: PPackedPlayerCharsRecord;
   pitem: PPackedItemRecord;
begin
    Sender.characters:=AccDbcHandler.GetStringByOffset(PPackedAccountRecord(AccDbcHandler.GetPointerPRValueByStrKey(Sender.acc_name))^.Chars);
    if (Sender.characters<>'')then
    with Sender.SendBuff do
    begin
         Init(SMSG_CHAR_ENUM);
         setlength(charList,maxbyte);
         cListLen:=FillIntArrWithStrData(Sender.characters,';',charList);
         setlength(charList,cListLen);

         if cListLen > 20 then cListLen:=20; //limit for chars count
         Sender.CharsCount:=cListLen;
         Add(byte(cListLen));
         if (cListLen > 0) then
         begin
            for i:=0 to pred(cListLen) do
            begin
                 pplchar:=PPackedPlayerCharsRecord(PlayerCharDbcHandler.GetPointerPRValueByIntKey(charList[i]));
                 if pplchar = nil then continue;
                 if pplchar^.Guid <> 0 then
                   tempGUID := pplchar^.Guid
                 else
                   tempGUID:=GetCharsUniqGUID;

                 Sender.CharsGuidArr[i][0]:=charList[i];
                 Sender.CharsGuidArr[i][1]:=tempGUID;
                 Sender.CharsGuidArr[i][2]:=tempGUID shr 32;
                 Add(tempGUID);
                 Add(PlayerCharDbcHandler.GetStringByOffset(pplchar^.Name));

                 pgcr:=pplchar^.pgcr;
                 Add(byte(pgcr));
                 Add(byte(pgcr shr 8));
                 Add(byte(pgcr shr 16));
                 Add(pplchar^.HairFaceSkin);
                 Add(byte(pplchar^.rest_state_f_hair));

                 Add(byte(pplchar^.level));
                 Add(pplchar^.mapID_zoneID and $FFFF);
                 Add(pplchar^.mapID_zoneID shr 16);
                 Add(pplchar^.positionX);
                 Add(pplchar^.positionY);
                 Add(pplchar^.positionZ);
                 Add(integer(0));    //CurrCharacter.guildID
                 Add(integer(0));    //CurrCharacter.guildRank
                 Add(byte(0));    //CurrCharacter.restState
                 Add(integer(0));   //CurrCharacter.PetDisplayId
                 Add(integer(0));   //CurrCharacter.PetLevel
                 Add(integer(0));   //CurrCharacter.PetCreatureFamily

                 setlength(itemList,maxbyte);
                 iListLen:=FillIntArrWithStrData(PlayerCharDbcHandler.GetStringByOffset(pplchar^.Items),';',itemList);
                 itemsCount:=iListLen div 6;
                 FillChar(itemsArr,sizeof(itemsArr),0);
                 for j:=0 to pred(itemsCount) do
                     if itemList[j*6+2]<= EQUIPMENT_SLOT_RANGED then //slot
                        itemsArr[itemList[j*6+2]]:=itemList[j*6+1];

                 for j:=0 to 19 do
                 begin
                      pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(itemsArr[j]));
                      if (itemsArr[j]>0)and(pitem<>nil) then
                      begin
                           Add(pitem^.Model);
                           Add(byte(inventory_type2equip_slot[j]));
                      end
                      else begin
                           Add(integer(0));
                           Add(byte(0));
                      end;
                 end;
            end;
            Sender.SendPacket;
         end
         else begin
            Sender.CharsCount:=0;
            Add(byte(0));
            Sender.SendPacket;
         end;
    end
    else begin
       Sender.CharsCount:=0;
       Sender.SendBuff.Init(SMSG_CHAR_ENUM);
       Sender.SendBuff.Add(byte(0));
       Sender.SendPacket;
    end;
end;

procedure CMSG_CHAR_DELETE_handler(Sender: TPlayer);
var
   i,charID: integer;
   tempPlayerGUID: int64;
   found: boolean;
   plchar: PPackedPlayerCharsRecord;
begin
     Sender.ReceiveBuff.Get(tempPlayerGUID);
     found:=false;
     i:=0;charID:=0;
     while (i < Sender.CharsCount) do
     begin
          if (Sender.CharsGuidArr[i][1]=integer(tempPlayerGUID))and(Sender.CharsGuidArr[i][2]=integer(tempPlayerGUID shr 32))then
          begin
               found:=true;
               charID:=Sender.CharsGuidArr[i][0];
               break;
          end;
          inc(i);
     end;
     if found then
     begin
          Sender.characters:=AnsiReplaceStr(Sender.characters,IntToStr(charID)+';','');
          PPackedAccountRecord(AccDbcHandler.GetPointerPRValueByStrKey(Sender.acc_name))^.Chars:=AccDbcHandler.AddString(Sender.characters);

          plchar := PlayerCharDbcHandler.GetPointerPRValueByIntKey(charID);
          if plchar <> nil then
            PlayerCharNamesHT.Remove(PlayerCharDbcHandler.GetStringByOffset(plchar^.Name));

          //fill player char with 0-th for replacement
          PlayerCharDbcHandler.RemoveRecordIntKey(charID);
          //Удаляем экшен-кнопки для этого чара
          if ActionBarDbcHandler.GetPointerPRValueByIntKey(charID) <> nil then
            ActionBarDbcHandler.RemoveRecordIntKey(charID);

          Sender.SendBuff.Init(SMSG_CHAR_DELETE);
          Sender.SendBuff.Add(tempPlayerGUID);
          Sender.SendPacket;
     end;
end;

procedure InitRep(Sender: TPlayer);
begin
     with Sender.CurrChar do begin
	        FillChar(m_reputation,sizeof(m_reputation),0);
	        FillChar(m_reputationValues,sizeof(m_reputationValues),0);
	        m_reputation[0] := 2;
	        m_reputation[2] := 2;
	        m_reputation[3] := 2;
	        m_reputation[4] := 16;
	        m_reputation[6] := 2;
	        m_reputation[8] := 16;
	        m_reputation[10] := 8;
	        m_reputation[11] := 9;
	        m_reputation[12] := 14;
	        m_reputation[14] := 6;
	        m_reputation[15] := 6;
	        m_reputation[16] := 6;
	        m_reputation[17] := 6;
	        m_reputation[18] := 17;
	        m_reputationValues[18] := 0 ; //19 Gnomeregan Exiled
	        m_reputation[19] := 17;
	        m_reputationValues[19] := 1200 ; //20	Stormwind
	        m_reputation[20] := 17;
	        m_reputationValues[20] := 0 ; //21 Ironforge
	        m_reputation[21] := 17;
	        m_reputationValues[21] := 0 ; //22 Darnassus
	        m_reputation[22] := 4;
	        m_reputation[23] := 4;
	        m_reputation[24] := 4;
	        m_reputation[25] := 4;
	        m_reputation[26] := 4;
	        m_reputation[29] := 4;
	        m_reputation[30] := 4;
	        m_reputation[31] := 4;
	        m_reputation[32] := 4;
	        m_reputation[33] := 4;
	        m_reputation[34] := 4;
	        m_reputation[35] := 2;
	        m_reputation[38] := 2;
	        m_reputation[39] := 20;
	        m_reputation[40] := 16;
	        m_reputation[41] := 2;
	        m_reputation[43] := 16;
	        m_reputation[44] := 16;
	        m_reputation[45] := 16;
	        m_reputation[46] := 6;
	        m_reputation[47] := 24;
	        m_reputation[48] := 14;
	        m_reputation[49] := 6;
	        m_reputation[63] := 63;
	        m_reputationValues[63] := $1F003E ; //64
     end;
end;

procedure CMSG_PLAYER_LOGIN_handler(Sender: TPlayer);
var
   //packet: array of byte;
   temp_arr: array of integer;
   i,sCount,charID: integer;
   tempPlayerGUID: int64;
   year,month,day,hour,minute,sec,msec: word;
   compresseddtime: dword;
   found: boolean;
   pplcharbase: PPackedClassRaseStartInfoRecord;
   pCharRaces: PPackedCharRacesRecord ;
//   pActionBar: PPackedActionBar;
const
     normal_speed: single = 0.017;
     initf: array[0..323]of byte =    //$E4, $1A, $A7, $AC, 
($40, $00, $00, $00, $06, $00, $00, $00, $00, $04, $00, $00,
$00, $00, $04, $00, $00, $00, $00, $04, $00, $00, $00, $00, $10, $00, $00, $00, 
$00, $02, $00, $00, $00, $00, $06, $00, $00, $00, $00, $04, $00, $00, $00, $00, 
$10, $00, $00, $00, $00, $04, $00, $00, $00, $00, $08, $00, $00, $00, $00, $09, 
$00, $00, $00, $00, $0E, $00, $00, $00, $00, $00, $00, $00, $00, $00, $06, $00, 
$00, $00, $00, $06, $00, $00, $00, $00, $06, $00, $00, $00, $00, $06, $00, $00, 
$00, $00, $11, $00, $00, $00, $00, $11, $00, $00, $00, $00, $11, $00, $00, $00, 
$00, $11, $00, $00, $00, $00, $04, $00, $00, $00, $00, $04, $00, $00, $00, $00, 
$04, $00, $00, $00, $00, $04, $00, $00, $00, $00, $04, $00, $00, $00, $00, $04, 
$00, $00, $00, $00, $04, $00, $00, $00, $00, $04, $00, $00, $00, $00, $04, $00, 
$00, $00, $00, $04, $00, $00, $00, $00, $04, $00, $00, $00, $00, $04, $00, $00, 
$00, $00, $04, $00, $00, $00, $00, $06, $00, $00, $00, $00, $04, $00, $00, $00, 
$00, $00, $00, $00, $00, $00, $06, $00, $00, $00, $00, $14, $00, $00, $00, $00, 
$14, $00, $00, $00, $00, $06, $00, $00, $00, $00, $04, $00, $00, $00, $00, $10, 
$00, $00, $00, $00, $10, $00, $00, $00, $00, $14, $00, $00, $00, $00, $06, $00, 
$00, $00, $00, $18, $00, $00, $00, $00, $0E, $00, $00, $00, $00, $06, $00, $00, 
$00, $00, $10, $00, $00, $00, $00, $10, $00, $00, $00, $00, $06, $00, $00, $00, 
$00, $14, $00, $00, $00, $00, $06, $00, $00, $00, $00, $00, $00, $00, $00, $00, 
$00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, 
$00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, $00, 
$00, $00, $00, $00, $00, $00, $00, $00); 
    
begin
     FillChar(Sender.SendBuff.data,84,0);
     Sender.SendBuff.Init(SMSG_ACCOUNT_DATA_MD5);
     Sender.SendBuff.offs:=84;
     Sender.SendPacket;

     Sender.ReceiveBuff.Get(tempPlayerGUID);
     found:=false;
     i:=0;charID:=0;
     while (i < Sender.CharsCount) do
     begin
          if (Sender.CharsGuidArr[i][1]=integer(tempPlayerGUID))and(Sender.CharsGuidArr[i][2]=integer(tempPlayerGUID shr 32))then
          begin
               found:=true;
               charID:=Sender.CharsGuidArr[i][0];
               break;
          end;
          inc(i);
     end;
     if not(found) then exit;

     Sender.CurrChar:=TCharacter.Create(tempPlayerGUID,false);
     Sender.CurrChar.ID:=charID;
     Sender.CurrChar.Owner:=Sender;
     Sender.CurrChar.LoadItemsSpells;
     PlayerCharsHT_byGUID.Remove(integer(Sender.CurrChar.objGUID));
     PlayerCharsHT_byGUID.Add(integer(Sender.CurrChar.objGUID),Sender.CurrChar);
     with Sender.SendBuff do
     begin
          Init(SMSG_BINDPOINTUPDATE);
          Add(Sender.CurrChar.BindingPointX);
          Add(Sender.CurrChar.BindingPointY);
          Add(Sender.CurrChar.BindingPointZ);
          Add(integer(Sender.CurrChar.BindingPointMapId));
          Add(integer(Sender.CurrChar.BindingPointZoneId));
          Sender.SendPacket;
     end;

     //motd
     if motd <> '' then SendSystemChatMessage(Sender, motd);     
     SendSystemChatMessage(Sender, 'Server version: |c8f'+IntToHex(ColorToRGB(clLime),6)+ ServerVersion + '|r.');

     Sender.SendBuff.Init(SMSG_IGNORE_LIST);
     Sender.SendBuff.Add(word(0));
     Sender.SendPacket;

     Sender.SendBuff.Init(SMSG_FRIEND_LIST);
     Sender.SendBuff.Add(integer(0));
     Sender.SendPacket;

     Sender.SendBuff.Init(SMSG_SET_REST_START);
     Sender.SendBuff.Add(dword($1E));
     Sender.SendPacket;

     FillChar(Sender.SendBuff.data,10,$FF);
     Sender.SendBuff.Init(SMSG_SET_FLAT_SPELL_MODIFIER);
     Sender.SendBuff.Add(dword($FF380A06));
     Sender.SendPacket;

     //Подсказки
          Sender.SendBuff.Init(SMSG_TUTORIAL_FLAGS);
     for i:=0 to 7 do
       if ShowTutorial then
         Sender.SendBuff.Add(Sender.CurrChar.Tutorials[i])
       else
         Sender.SendBuff.Add(Integer($FFFFFFFF));
          Sender.SendPacket;

     setlength(temp_arr,500);
     sCount:=FillIntArrWithStrData(Sender.CurrChar.cSpells,';',temp_arr);
     Sender.SendBuff.Init(SMSG_INITIAL_SPELLS);
     Sender.SendBuff.Add(byte(0));
     Sender.SendBuff.Add(word(sCount));
     for i:=0 to pred(sCount) do Sender.SendBuff.Add(temp_arr[i]);
     Sender.SendPacket;

{     InitRep(Sender);
     Sender.SendBuff.Init(SMSG_INITIALIZE_FACTIONS);
     Sender.SendBuff.Add(Integer(64));
     for i := 0 to 63 do begin
      Sender.SendBuff.Add(Sender.CurrChar.m_reputation[i]);
      Sender.SendBuff.Add(Sender.CurrChar.m_reputationValues[i]);
     end;
     Sender.SendPacket;}
     Sender.SendBuff.Init(SMSG_INITIALIZE_FACTIONS);
     Sender.SendBuff.Add(@initf,sizeof(initf));
     Sender.SendPacket;

     //Экшен кнопки
     Sender.SendBuff.Init(SMSG_ACTION_BUTTONS);
     for  i:=0 to 119 do Sender.SendBuff.Add(Sender.CurrChar.actionsButtons[i]);
     Sender.SendPacket;

     //SendProficiency
     Sender.SendBuff.Init(SMSG_CORPSE_RECLAIM_DELAY);
     Sender.SendBuff.Add(integer(0));
     Sender.SendPacket;

     DecodeDateTime(Now,year,month,day,hour,minute,sec,msec);
     Sender.SendBuff.Init(SMSG_LOGIN_SETTIMESPEED);
     compresseddtime:= minute or (hour shl 6) or (DayOfWeek(Date) shl 11) or (dword(day) shl 14) or (dword(year) shl 18) or (dword(month) shl 20);
     Sender.SendBuff.Add(compresseddtime);
     Sender.SendBuff.Add(normal_speed);
     Sender.SendPacket;

     //Мультик (показывается когда чар находится на месте создания)
     //if just created char
     i:=(Integer(Sender.CurrChar.cCLass) shl 8) or Integer(Sender.CurrChar.cRace);
     pplcharbase:=PPackedClassRaseStartInfoRecord(CharCRStartInfoDbcHandler.GetPointerPRValueByIntKey(i));
     if ShowMovie and (Sender.CurrChar.positionX = pplcharbase^.posX) and (Sender.CurrChar.positionY = pplcharbase^.posY) and (Sender.CurrChar.positionZ = pplcharbase^.posZ) then begin
       pCharRaces := CharRacesDbcHandler.GetPointerPRValueByIntKey(Integer(Sender.CurrChar.cRace));
       if pCharRaces <> nil then begin
         Sender.SendBuff.Init(SMSG_TRIGGER_CINEMATIC);
         Sender.SendBuff.Add(pCharRaces^.movie);
         Sender.SendPacket;
       end;  
     end;

  //Открываем карту
  for i := 0 to 63 do
    SetUpdateBits(Sender.CurrChar, $FFFFFFFF, PLAYER_EXPLORED_ZONES_1+i);

  Sender.CurrChar.InitUpdateArray;
  Sender.CurrChar.SendFullCreateUpdateBlockForPlayer;
  MapCell.CreateObj(Sender.CurrChar);
end;

procedure CMSG_GAMETIME_SET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GAMESPEED_SET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SERVERTIME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PLAYER_LOGOUT_handler(Sender: TPlayer);
begin
	{}
end;

procedure SaveCharToDBC(Sender: TPlayer);
var
 i{, j}, ret_id: Integer;
 playerChar: PPackedPlayerCharsRecord;
 pActionBar: PPackedActionBar;
 ActionBar: TPackedActionBar;
 s: string;
begin
 if (Sender.CurrChar = nil) or (Sender.CurrChar.name = '') then Exit;                      
 playerChar := PlayerCharDbcHandler.GetPointerPRValueByIntKey(Sender.CurrChar.ID);
 if playerChar <> nil then begin
   playerChar^.Guid := Sender.CurrChar.objGUID ;
   playerChar^.positionX := Sender.CurrChar.positionX;
   playerChar^.positionY := Sender.CurrChar.positionY;
   playerChar^.positionZ := Sender.CurrChar.positionZ;
   playerChar^.positionR := Sender.CurrChar.positionR;
   playerChar^.mapID_zoneID := integer((integer(Sender.CurrChar.mapId) shl 16) or Sender.CurrChar.zoneId);
   playerChar^.copper := Sender.CurrChar.copper;
   playerChar^.level := Sender.CurrChar.Level;
   playerChar^.lastLogout := Now;
   playerChar^.xp := Sender.CurrChar.cXp;
   playerChar^.rest_xp := Sender.CurrChar.restState;
   playerChar^.Ammo := Sender.CurrChar.ammoId ;
   playerChar^.rest_state_f_hair := Sender.CurrChar.rest_state_f_hair ;
   playerChar^.Items := PlayerCharDbcHandler.AddString(CreateItemsStr(Sender.CurrChar));

   s:='';
   for i := 0 to 7 do s := s + IntToStr(Sender.CurrChar.Tutorials[i])+';';
   playerChar^.Tutorials:= PlayerCharDbcHandler.AddString(s);

   s:='';
   for i := 0 to 7 do s := s + IntToStr(Sender.CurrChar.TaxiMask[i])+';';
   playerChar^.TaxiMask:= PlayerCharDbcHandler.AddString(s);

   //Save ActionBar
   pActionBar := ActionBarDbcHandler.GetPointerPRValueByIntKey(Sender.CurrChar.id);
   if pActionBar = nil then begin
     ActionBar.id := Sender.CurrChar.id;
     for i := 0 to 119 do
       ActionBar.ActionBar[i] := Sender.CurrChar.actionsButtons[i];
     ret_id := ActionBarDbcHandler.AddRecord(@ActionBar);
     pActionBar := ActionBarDbcHandler.GetPointerPRValueByIntKey(ret_id);
   end;
   if pActionBar <> nil then begin
     pActionBar.id := Sender.CurrChar.id;
     for i := 0 to 119 do
       pActionBar^.ActionBar[i] := Sender.CurrChar.actionsButtons[i];
   end;
   playerChar^.Auras:=0;
   playerChar^.Reputation:=0;
   playerChar^.Talents:=0;
   playerChar^.Honor:=0;
   playerChar^.FriendList := PlayerCharDbcHandler.AddString(Sender.CurrChar.FriendList);
   playerChar^.IgnoreList := PlayerCharDbcHandler.AddString(Sender.CurrChar.IgnoreList);   
   AddToLog('Save Char: ' + Sender.CurrChar.name);
 end else AddToLog('!!! Error Save Char');
end;

procedure CMSG_LOGOUT_REQUEST_handler(Sender: TPlayer);
var
   EndTime,StartTime: dword;
begin
     Sender.LogoutCanceled:=false;
     Sender.SendBuff.Init(SMSG_LOGOUT_RESPONSE);
     Sender.SendBuff.Add(byte(0));
     Sender.SendBuff.Add(integer(0));
     Sender.SendPacket;

	   //Set the flag so player sits
	   SetUpdateBits(Sender.CurrChar, PLAYER_STATE_SIT, UNIT_FIELD_BYTES_1);
	   //Rotate disable
     SetUpdateBits(Sender.CurrChar, 8 or $40000, UNIT_FIELD_FLAGS);
     Sender.CurrChar.BuildSendCharUpdateBlock ;

	   // Can't move
     Sender.SendBuff.Init(SMSG_FORCE_MOVE_ROOT);
     Sender.SendBuff.Add($FF);
     Sender.SendBuff.Add(Sender.CurrChar.objGUID);
     Sender.SendPacket;

     StartTime:=GetTickCount;
     EndTime := StartTime + LogoutTime*1000;
     while ((GetTickCount < EndTime)or((StartTime > EndTime)and(GetTickCount > StartTime))) and not(Sender.LogoutCanceled) do
           Application.ProcessMessages;
     if not(Sender.LogoutCanceled) then
     begin //messages here
          SaveCharToDBC(Sender);
          MapCell.FindCellRemoveObject(Sender.CurrChar);
          PlayerCharsHT_byGUID.Remove(integer(Sender.CurrChar.objGUID));
          //LoggedPlayersHT.Remove(Sender.acc_name);
          UnitHT_byGUID.Remove(integer(Sender.CurrChar.objGUID));
          Sender.CurrChar.Destroy;
          Sender.SendBuff.Init(SMSG_LOGOUT_COMPLETE);
          Sender.SendPacket;
          //send remove msg to players near and remove from PlayerChars
     end;
end;

procedure CMSG_LOGOUT_CANCEL_handler(Sender: TPlayer);
begin
  try
   	if PlayerCharsHT_byGUID[Sender.CurrChar.objGUID] = nil then Exit;
    
    Sender.LogoutCanceled:=true;
    Sender.SendBuff.Init(SMSG_LOGOUT_CANCEL_ACK);
    Sender.SendPacket;

    //we can move again
    Sender.SendBuff.Init(SMSG_FORCE_MOVE_UNROOT);
    Sender.SendBuff.Add($FF);
    Sender.SendBuff.Add(Sender.CurrChar.objGUID);
    Sender.SendPacket;

    //Stand Up
    SetUpdateBits(Sender.CurrChar, 0, UNIT_FIELD_BYTES_1);
  	//Rotare enable
    SetUpdateBits(Sender.CurrChar, 8, UNIT_FIELD_FLAGS);
    Sender.CurrChar.BuildSendCharUpdateBlock ;
  except
  end;  
end;

procedure CMSG_NAME_QUERY_handler(Sender: TPlayer);
var
   tempPlayerGUID: int64;
   obj: TCharacter;
  char_name: PChar;
begin
     Sender.ReceiveBuff.Get(tempPlayerGUID);
  AddToLog('CMSG_NAME_QUERY ' + IntToStr(integer(tempPlayerGUID))) ;

     obj:=PlayerCharsHT_byGUID.Items[integer(tempPlayerGUID)];
  with Sender.SendBuff do
    if obj <> nil then begin
          Sender.SendBuff.Init(SMSG_NAME_QUERY_RESPONSE);
          Add(tempPlayerGUID);
          Add(obj.name);
          Add(integer(obj.cRace));
          Add(integer((obj.UpdateArray[integer(UNIT_FIELD_BYTES_0)] shr 16)and $FF)); //gender
          Add(integer(obj.cClass));
          Sender.SendPacket;
    end else begin
      char_name := PlayerCharsNames_byGUID[integer(tempPlayerGUID)];
      if char_name <> '' then begin
        Sender.SendBuff.Init(SMSG_NAME_QUERY_RESPONSE);
        Add(tempPlayerGUID);
        Add(char_name);
        Add(integer(0));
        Add(integer(0)); //gender
        Add(integer(0));
        Sender.SendPacket;
      end;
     end;
end;

procedure CMSG_PET_NAME_QUERY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_QUERY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ITEM_QUERY_SINGLE_handler(Sender: TPlayer);
var
   pitem: PPackedItemRecord;
   itemID: integer;
const
     single0: single=0;
begin
     itemID:=0;
     Sender.ReceiveBuff.Get(itemID);
     pitem:=ItemsDbcHandler.GetPointerPRValueByIntKey(itemID);
	   if (pitem <> nil) then
     begin
          //items.dbc 1:1 to those structure and move in 1 step
          Sender.SendBuff.Init(SMSG_ITEM_QUERY_SINGLE_RESPONSE);
          ItemsDbcHandler.Add2arrayWholeWithStrings(itemID,0,Sender.SendBuff.data,Sender.SendBuff.offs);
          Sender.SendPacket;
     end;
end;

procedure CMSG_ITEM_QUERY_MULTIPLE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PAGE_TEXT_QUERY_handler(Sender: TPlayer);
var
  pageID,nextPage: integer;
  pageText: string;
  more_pages: boolean;
  ppage: PPackedPageTxtRecord;
begin
  pageID:=0;
  Sender.ReceiveBuff.Get(pageID);     //2012

  more_pages:=true;
  nextPage:=pageID;
  while more_pages do
    with Sender.SendBuff do begin
      Init(SMSG_PAGE_TEXT_QUERY_RESPONSE);
      Add(nextPage);
      ppage:=PPackedPageTxtRecord(PageTextDbcHandler.GetPointerPRValueByIntKey(nextPage));
      if ppage = nil then begin
        pageText := 'Item page missing. PageID=' + IntToStr(nextPage);
        AddToLog('!!! ERROR: ' + pageText);
        nextPage := 0;
      end else begin
        pageText := PageTextDbcHandler.GetStringByOffset(ppage^.PageText);
        nextPage := ppage^.NextPage;
      end;
      Add(pageText);
      if nextPage<=0 then begin
        more_pages:=false;
        nextPage:=0;
      end;
      Add(nextPage);
      Sender.SendPacket;
    end;
end;

procedure CMSG_QUEST_QUERY_handler(Sender: TPlayer);
var
   i,questID: integer;
   pquest: PPackedQuestRecord;
begin
   Sender.ReceiveBuff.Get(questID);
   pquest:=QuestsDbcHandler.GetPointerPRValueByIntKey(questID);
   if pquest=nil then exit;

   with Sender.SendBuff do
   begin
     Sender.SendBuff.Init(SMSG_QUEST_QUERY_RESPONSE);
     Add(pquest^.id);
     Add(pquest^.RequiresLevel);
     Add(pquest^.QuestLevel);
     Add(pquest^.Category);
     Add(pquest^.Complexity);
     Add(pquest^.factions[0].Faction);
     Add(pquest^.factions[0].FactionMinReq);
     Add(pquest^.factions[1].Faction);
     Add(pquest^.factions[1].FactionMinReq);
     Add(pquest^.NextStoryQuest);
     Add(pquest^.MoneyReward);
     Add(pquest^.LearnSpell);
     Add(pquest^.ReceiveItem);
     Add(pquest^.DescriptiveFlags);
     for i:=0 to 3 do
     begin
          Add(pquest^.rewards[i].Item);
          Add(pquest^.rewards[i].Amount);
     end;
     for i:=0 to 5 do
     begin
          Add(pquest^.reward_choices[i].Item);
          Add(pquest^.reward_choices[i].Amount);
     end;
     Add(pquest^.ma);
     Add(pquest^.mx);
     Add(pquest^.my);
     Add(pquest^.mz);
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Objectives));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Details));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.EndText));
     for i:=0 to 3 do
     begin
          Add(pquest^.NpcObjectives[i].Item);
          Add(pquest^.NpcObjectives[i].Amount);
          Add(pquest^.NpcObjectives[i].Deliver);
          Add(pquest^.NpcObjectives[i].DeliverAmount);
     end;
     for i:=0 to 3 do
         Add(QuestsDbcHandler.GetStringByOffset(pquest^.ObjectivesArray[i]));
     Sender.SendPacket;
   end;
end;

procedure CMSG_GAMEOBJECT_QUERY_handler(Sender: TPlayer);
var
   i,goID: integer;
   pgo: PPackedGameObjectRecord;
begin
     Sender.ReceiveBuff.Get(goID); //entry
     //Sender.ReceiveBuff.Get(guid);
     pgo:=GameObjectsDbcHandler.GetPointerPRValueByIntKey(goID);
     if pgo=nil then AddToLog('Check your tables integrity!!! goID='+IntToStr(goID))
     else with Sender.SendBuff do
     begin
          Init(SMSG_GAMEOBJECT_QUERY_RESPONSE);
          Add(goID); //entry
          Add(pgo^.goType);
          Add(pgo^.Model);
          for i:=0 to 3 do
              Add(GameObjectsDbcHandler.GetStringByOffset(pgo^.names[i]));
          for i:=0 to 11 do
              Add(pgo^.SoundEffects[i]);
          for i:=0 to 4 do //unk
              Add(integer(0));
          Sender.SendPacket;
     end;
end;

procedure CMSG_CREATURE_QUERY_handler(Sender: TPlayer);
var
   i,creatureID: integer;
   pcreature: PPackedCreatureRecord;
   name: string;
begin
   Sender.ReceiveBuff.Get(creatureID); //entry
   //Sender.ReceiveBuff.Get(guid);
   pcreature:=CreaturesDbcHandler.GetPointerPRValueByIntKey(creatureID);
   if pcreature=nil then AddToLog('Check your tables integrity!!! creatureID='+IntToStr(creatureID))
   else with Sender.SendBuff do begin
      Init(SMSG_CREATURE_QUERY_RESPONSE);
      Add(pcreature^.ID);
      name:=CreaturesDbcHandler.GetStringByOffset(pcreature^.name);
      Add(name);
      for i:=0 to 2 do Add(Byte(0));
      Add(CreaturesDbcHandler.GetStringByOffset(pcreature^.guild));
      Add(pcreature^.flags1);                             //flag1          wdbFeild7=wad flags1
      Add(pcreature^.cType);                       //creatureType   wdbFeild8
      Add(pcreature^.family);                      //family         wdbFeild9
      Add(pcreature^.elite);                       //rank           wdbFeild10
      Add(integer(0));                             //unknow         wdbFeild11
      Add(integer(0));                             //unknow         wdbFeild12
      Add(pcreature^.model);                       //DisplayID      wdbFeild13
      Add(Word(0));       //civilian;              //wdbFeild14
      Sender.SendPacket;
   end;
end;

procedure CMSG_WHO_handler(Sender: TPlayer);
//by saddy 16/03/05, works, need optimization
var
   i,ccount,nonrace,packet_len: integer;
   CurrChar:TCharacter;
begin
  //should be SQL based!!! by partial search
  nonrace:=0;

  Sender.SendBuff.Init(SMSG_WHO);
  Sender.SendBuff.Add(integer(PlayerCharsHT_byGUID.Count));
  Sender.SendBuff.Add(integer(PlayerCharsHT_byGUID.Count));

  ccount:=0;
  for i:=0 to PlayerCharsHT_byGUID.InnerCapacity-1 do begin
   CurrChar:=PlayerCharsHT_byGUID.Items[PlayerCharsHT_byGUID.InnerKeyList[i]];
    if CurrChar<>nil then
    with Sender.SendBuff do
    begin
      inc(ccount);

      if IsAlliance(CurrChar.cRace)<>IsAlliance(Sender.CurrChar.cRace) then begin
        inc(nonrace);
        continue;
      end;

      Add(trim(CurrChar.Name));

      Add(byte(0)); //name already with 0???

      Add(integer(CurrChar.Level));
      Add(integer(Ord(CurrChar.cClass)));
      Add(integer(Ord(CurrChar.cRace)));
      Add(integer(CurrChar.ZoneId));
      Add(integer(0)); //guild
      //AddToLog('Found '+trim(CurrChar.Name));
      if ccount=PlayerCharsHT_byGUID.Count then break;
    end;
  end;
  packet_len:=Sender.SendBuff.offs;
  Sender.SendBuff.offs:=4;
  Sender.SendBuff.Add(integer(PlayerCharsHT_byGUID.Count-nonrace));
  Sender.SendBuff.Add(integer(PlayerCharsHT_byGUID.Count-nonrace));
  Sender.SendBuff.offs:=packet_len;

  Sender.SendPacket;
end;

procedure CMSG_WHOIS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FRIEND_LIST_handler(Sender: TPlayer);
var
  i, sCount: Integer;
  sList: array of Integer;
  Player: TPlayer;
begin
  SetLength(sList, MaxByte);
  sCount := FillIntArrWithStrData(Sender.CurrChar.FriendList, ';', sList);
  if sCount > 255 then sCount := 255;

	Sender.SendBuff.Init(SMSG_FRIEND_LIST);
  Sender.SendBuff.Add(Byte(sCount));

  for i := 0 to Pred(sCount) do begin
    Sender.SendBuff.Add(Int64(sList[i]));

    Player := GetOnlinePlayerByGuid(sList[i]);
    if Player = nil then
      Sender.SendBuff.Add(Byte(0))
    else begin
      Sender.SendBuff.Add(Byte(1)) ;
      Sender.SendBuff.Add(Integer(Player.CurrChar.zoneId));
      Sender.SendBuff.Add(Integer(Player.CurrChar.Level));
      Sender.SendBuff.Add(Integer(Player.CurrChar.cClass));
    end;
  end; 
  Sender.SendPacket ;

  SetLength(sList, MaxByte);
  sCount := FillIntArrWithStrData(Sender.CurrChar.IgnoreList, ';', sList);
  if sCount > 255 then sCount := 255;

	Sender.SendBuff.Init(SMSG_IGNORE_LIST);
  Sender.SendBuff.Add(Byte(sCount));

  for i := 0 to Pred(sCount) do
    Sender.SendBuff.Add(Int64(sList[i]));

  Sender.SendPacket ;
end;

procedure SendFriendStatus(Sender: TPlayer; Guid: Int64; Status: Byte);
begin
  Sender.SendBuff.Init(SMSG_FRIEND_STATUS);
  Sender.SendBuff.Add(Status) ;
  Sender.SendBuff.Add(Guid) ;
  Sender.SendPacket ;
end;

procedure CMSG_ADD_FRIEND_handler(Sender: TPlayer);
var
  FriendName: String;
  Friend_guid, i, sCount: Integer;
  FriendStatus: Byte;
  sList: array of Integer;
  player_chars: PPackedPlayerCharsRecord ;
  Player: TPlayer;
begin
	Sender.ReceiveBuff.Get(FriendName);
  AddToLog('CMSG_ADD_FRIEND ' + FriendName);

  FriendStatus := FRIEND_NOT_FOUND ;
  Friend_guid := 0 ;
  //Ищем в базе GUID друга
  for i := 1 to PlayerCharDbcHandler.MaxID do begin
    player_chars := PlayerCharDbcHandler.GetPointerPRValueByIntKey(i);
    if player_chars <> nil then
      if PlayerCharDbcHandler.GetStringByOffset(player_chars^.Name) = FriendName then begin
        Friend_guid := player_chars^.Guid;
        Break;
      end;
  end;

  SetLength(sList, MaxByte);
  sCount := FillIntArrWithStrData(Sender.CurrChar.FriendList, ';', sList);
  if sCount > 255 then sCount := 255;
  for i := 0 to Pred(sCount) do
    if sList[i] = Friend_guid then begin
      FriendStatus := FRIEND_ALREADY ;
      Break;
    end;

  if Sender.CurrChar.Name = FriendName then
    FriendStatus := FRIEND_SELF ;

  if (Friend_guid > 0) and (FriendStatus <> FRIEND_ALREADY) and (FriendStatus <> FRIEND_SELF) then begin
    Sender.CurrChar.FriendList := Sender.CurrChar.FriendList + IntToStr(Friend_guid) + ';' ;

    Player := GetOnlinePlayerByGuid(Friend_guid);
    if Player = nil then begin
      FriendStatus := FRIEND_ADDED_OFFLINE ;
    end else begin
      Sender.SendBuff.Init(SMSG_FRIEND_STATUS);
      Sender.SendBuff.Add(FRIEND_ADDED_ONLINE) ;
      Sender.SendBuff.Add(Int64(Friend_guid));
      Sender.SendBuff.Add(Byte(0)) ;
      Sender.SendBuff.Add(Integer(Player.CurrChar.zoneId));
      Sender.SendBuff.Add(Integer(Player.CurrChar.Level));
      Sender.SendBuff.Add(Integer(Player.CurrChar.cClass));
      Sender.SendPacket ;
      Exit;
    end;
  end;
  SendFriendStatus(Sender, Friend_guid, FriendStatus);
end;

procedure CMSG_DEL_FRIEND_handler(Sender: TPlayer);
var
  guid: Int64;
begin
	Sender.ReceiveBuff.Get(guid);
  Sender.CurrChar.FriendList := AnsiReplaceStr(Sender.CurrChar.FriendList, IntToStr(Integer(guid))+';','');
  SendFriendStatus(Sender, Guid, FRIEND_REMOVED);
end;

procedure CMSG_ADD_IGNORE_handler(Sender: TPlayer);
var
  IgnoreName: String;
  Ignore_guid, i, sCount: Integer;
  IgnoreStatus: Byte;
  sList: array of Integer;
  player_chars: PPackedPlayerCharsRecord ;
begin
	Sender.ReceiveBuff.Get(IgnoreName);
  AddToLog('CMSG_ADD_IGNORE ' + IgnoreName);

  IgnoreStatus := FRIEND_IGNORE_NOT_FOUND ;
  Ignore_guid := 0 ;
  //Ищем в базе GUID друга
  for i := 1 to PlayerCharDbcHandler.MaxID do begin
    player_chars := PlayerCharDbcHandler.GetPointerPRValueByIntKey(i);
    if player_chars <> nil then
      if PlayerCharDbcHandler.GetStringByOffset(player_chars^.Name) = IgnoreName then begin
        Ignore_guid := player_chars^.Guid;
        Break;
      end;
  end;

  SetLength(sList, MaxByte);
  sCount := FillIntArrWithStrData(Sender.CurrChar.IgnoreList, ';', sList);
  if sCount > 255 then sCount := 255;
  for i := 0 to Pred(sCount) do
    if sList[i] = Ignore_guid then begin
      IgnoreStatus := FRIEND_IGNORE_ALREADY ;
      Break;
    end;

  if Sender.CurrChar.Name = IgnoreName then
    IgnoreStatus := FRIEND_IGNORE_SELF ;

  if (Ignore_guid > 0) and (IgnoreStatus <> FRIEND_IGNORE_ALREADY) and (IgnoreStatus <> FRIEND_IGNORE_SELF) then begin
    Sender.CurrChar.IgnoreList := Sender.CurrChar.IgnoreList + IntToStr(Ignore_guid) + ';' ;
    IgnoreStatus := FRIEND_IGNORE_ADDED ;
  end;
  SendFriendStatus(Sender, Ignore_guid, IgnoreStatus);
end;

procedure CMSG_DEL_IGNORE_handler(Sender: TPlayer);
var
  guid: Int64;
begin
	Sender.ReceiveBuff.Get(guid);
  Sender.CurrChar.IgnoreList := AnsiReplaceStr(Sender.CurrChar.IgnoreList, IntToStr(Integer(guid))+';','');
  SendFriendStatus(Sender, Guid, FRIEND_IGNORE_REMOVED);
end;

procedure CMSG_GUILD_CREATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_INVITE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_ACCEPT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_DECLINE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_INFO_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_ROSTER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_PROMOTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_DEMOTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_LEAVE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_REMOVE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_DISBAND_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_LEADER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_MOTD_handler(Sender: TPlayer);
begin
	{}
end;

procedure UMSG_UPDATE_GUILD_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_USE_ITEM_handler(Sender: TPlayer);
var
  srcbag, srcslot: Byte;
  Item: TItem;
begin
  Sender.ReceiveBuff.Get(srcbag);
  Sender.ReceiveBuff.Get(srcslot);

  Item := Sender.CurrChar.GetBagItem(srcbag,srcslot);
  if Item.PItemRecord <> nil then begin
    with Sender.ReceiveBuff do begin
      Init ;
      Add2DbyteArr(Item.PItemRecord^.ItemSpells[0].SpellId, data, offs);
      Add2DbyteArr(word(0), data, offs);
      Init ;
    end;
    SS.CMSG_CAST_SPELL_handler(Sender);
  end;
end;

procedure CMSG_OPEN_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_READ_ITEM_handler(Sender: TPlayer);
var
  bagIndex, slot: Byte;
  Item: TItem;
begin
  Sender.ReceiveBuff.Get(bagIndex);
  Sender.ReceiveBuff.Get(slot);

  if bagIndex = SLOT_CHARACTER then //В инвентаре
    Item := Sender.CurrChar.cItems[slot]
  else
    Item := Sender.CurrChar.cBagItems[bagIndex, slot];

	if Item.PItemRecord <> nil then begin
  {if ((!pItem->GetProto()->PageText) || (GetPlayer()->inCombat) || (GetPlayer()->isDead())) begin
			data.Initialize( SMSG_READ_ITEM_FAILED );
			sLog.outDetail("ITEM: Unable to read item");
      Exit;
		end; }
    Sender.SendBuff.Init(SMSG_READ_ITEM_OK);
    Sender.SendBuff.Add(Item.objGUID);
		Sender.SendPacket;
	end;
end;

procedure CMSG_GAMEOBJ_USE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AREATRIGGER_handler(Sender: TPlayer);
var
  Trigger_ID: Integer;
  RestTrigger: PPackedRestTrigger;
begin
  Sender.ReceiveBuff.Get(Trigger_ID);
  AddToLog('CMSG_AREATRIGGER [' + IntToStr(Trigger_ID) + ']');

  RestTrigger := RestTriggerDbcHandler.GetPointerPRValueByIntKey(Trigger_ID);
  //если не в гостиннице, то выходим
  if RestTrigger = nil then Exit;

  if (Sender.CurrChar.Flags and PLAYER_FLAGS_RESTING) <> PLAYER_FLAGS_RESTING then begin
    Sender.CurrChar.Flags := Sender.CurrChar.Flags or PLAYER_FLAGS_RESTING;
    Sender.CurrChar.InitUpdateArray ;
    Sender.CurrChar.BuildSendCharUpdateBlock ;
  end;
end;

procedure MSG_MOVE_START_FORWARD_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_FORWARD);
end;

procedure MSG_MOVE_START_BACKWARD_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_BACKWARD);
end;

procedure MSG_MOVE_STOP_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_STOP);
end;

procedure MSG_MOVE_START_STRAFE_LEFT_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_STRAFE_LEFT);
end;

procedure MSG_MOVE_START_STRAFE_RIGHT_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_STRAFE_RIGHT);
end;

procedure MSG_MOVE_STOP_STRAFE_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_STOP_STRAFE);
end;

procedure MSG_MOVE_JUMP_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_JUMP);
end;

procedure MSG_MOVE_START_TURN_LEFT_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_TURN_LEFT);
end;

procedure MSG_MOVE_START_TURN_RIGHT_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_TURN_RIGHT);
end;

procedure MSG_MOVE_STOP_TURN_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_STOP_TURN);
end;

procedure MSG_MOVE_START_PITCH_UP_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_PITCH_UP);
end;

procedure MSG_MOVE_START_PITCH_DOWN_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_START_PITCH_DOWN);
end;

procedure MSG_MOVE_STOP_PITCH_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_STOP_PITCH);
end;

procedure MSG_MOVE_SET_RUN_MODE_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_SET_RUN_MODE);
end;

procedure MSG_MOVE_SET_WALK_MODE_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_SET_WALK_MODE);
end;

procedure MSG_MOVE_TOGGLE_LOGGING_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TELEPORT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TELEPORT_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TELEPORT_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TOGGLE_FALL_LOGGING_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_FALL_LAND_handler(Sender: TPlayer);
var
  FallTime, Damage: Integer;
begin
  move(Sender.ReceiveBuff.data[24], FallTime, 4);
  //SendSystemChatMessage(Sender, 'FallTime=' + IntToStr(FallTime));
  if Sender.CurrChar.state = DEATH_STATE_ALIVE then begin
		Damage := CalcFallDamage(FallTime);
    if Damage > 0 then
      Sender.CurrChar.EnvironmentalDamage(Sender.CurrChar.objGUID, byte(EDAMAGE_FALL), Damage);
  end;
  Movement_handler(Sender, MSG_MOVE_FALL_LAND);
  if Sender.CurrChar.Swim then begin
    Sender.CurrChar.StopMirrorTimer(1);
    Movement_handler(Sender, MSG_MOVE_STOP_SWIM);
  end;
end;

procedure MSG_MOVE_START_SWIM_handler(Sender: TPlayer);
begin
  if not Sender.CurrChar.Swim then begin
    Sender.CurrChar.Swim := True;
    Sender.CurrChar.StartMirrorTimer(1, 60000);
  end;
	Movement_handler(Sender,MSG_MOVE_START_SWIM);
end;

procedure MSG_MOVE_STOP_SWIM_handler(Sender: TPlayer);
begin
  if Sender.CurrChar.Swim then begin
    Sender.CurrChar.Swim := False; 
    Sender.CurrChar.StopMirrorTimer(1);
  end;
  Movement_handler(Sender,MSG_MOVE_STOP_SWIM);
end;

procedure MSG_MOVE_SET_RUN_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_RUN_SPEED_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_RUN_BACK_SPEED_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_WALK_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_WALK_SPEED_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_SWIM_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_SWIM_SPEED_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_SWIM_BACK_SPEED_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_ALL_SPEED_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_TURN_RATE_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_TURN_RATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TOGGLE_COLLISION_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_SET_FACING_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_SET_FACING);
end;

procedure MSG_MOVE_SET_PITCH_handler(Sender: TPlayer);
begin
  if not Sender.CurrChar.Swim then begin
    Sender.CurrChar.Swim := True;
    Sender.CurrChar.StartMirrorTimer(1, 60000);
  end;
  Movement_handler(Sender,MSG_MOVE_SET_PITCH);
end;

procedure MSG_MOVE_WORLDPORT_ACK_handler(Sender: TPlayer);
begin
  Sender.SendBuff.Init(SMSG_SET_REST_START);
  Sender.SendBuff.Add(Integer(8129));
  Sender.SendPacket;
end;

procedure MSG_MOVE_SET_RAW_POSITION_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MOVE_SET_RAW_POSITION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCE_RUN_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCE_SWIM_SPEED_CHANGE_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCE_MOVE_ROOT_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FORCE_MOVE_UNROOT_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_ROOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_UNROOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_HEARTBEAT_handler(Sender: TPlayer);
begin
	   Movement_handler(Sender,MSG_MOVE_HEARTBEAT);
end;

procedure CMSG_MOVE_KNOCK_BACK_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_KNOCK_BACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MOVE_HOVER_ACK_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_HOVER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TRIGGER_CINEMATIC_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_OPENING_CINEMATIC_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_NEXT_CINEMATIC_CAMERA_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_COMPLETE_CINEMATIC_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TUTORIAL_FLAG_handler(Sender: TPlayer);
var
  iFlag, wInt, rInt: Integer;
begin
  Sender.ReceiveBuff.Get(iFlag);;

	wInt := iFlag shr 5;
	rInt := iFlag and $1F;

  Sender.CurrChar.Tutorials[wInt]:=Sender.CurrChar.Tutorials[wInt] or (1 shl rInt);
end;

procedure CMSG_TUTORIAL_CLEAR_handler(Sender: TPlayer);
begin
     FillChar(Sender.CurrChar.Tutorials,sizeof(Sender.CurrChar.Tutorials),$FF);
end;

procedure CMSG_TUTORIAL_RESET_handler(Sender: TPlayer);
begin
     FillChar(Sender.CurrChar.Tutorials,sizeof(Sender.CurrChar.Tutorials),0);
end;

procedure CMSG_STANDSTATECHANGE_handler(Sender: TPlayer);
begin
  AddToLog('CMSG_STANDSTATECHANGE ' + IntToStr(Sender.ReceiveBuff.data[0]));
  
  Sender.SendBuff.Init(SMSG_STANDSTATE_CHANGE_ACK);
	Sender.SendBuff.Add(Sender.ReceiveBuff.data[0]);  //  state
  Sender.SendPacket;

  move(Sender.ReceiveBuff.data[0],Sender.CurrChar.UpdateArray[UNIT_FIELD_BYTES_1],1);
  Sender.CurrChar.RaiseBits(UNIT_FIELD_BYTES_1);
  Sender.CurrChar.BuildSendCharUpdateBlock;
end;

procedure CMSG_AUTOEQUIP_GROUND_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTOSTORE_GROUND_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTOSTORE_LOOT_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_STORE_LOOT_IN_SLOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTOEQUIP_ITEM_handler(Sender: TPlayer);
var
   srcslot,dstslot,srcbag: byte;
   empty_bag_slot: integer;
   srcitem: TItem;
   empty_bag_slot_found: boolean;
begin
	   Sender.ReceiveBuff.Get(srcbag);
	   Sender.ReceiveBuff.Get(srcslot);
     srcitem:=Sender.CurrChar.GetBagItem(srcbag,srcslot);
     dstslot:=inventory_type2equip_slot[srcitem.PItemRecord^.InventoryType];
     if dstslot=INVENTORY_SLOT_BAG_START then
     begin
          empty_bag_slot_found:=false;
          empty_bag_slot:=INVENTORY_SLOT_BAG_1;
          while not(empty_bag_slot_found)and(empty_bag_slot<=INVENTORY_SLOT_BAG_4)do
                if Sender.CurrChar.cItems[empty_bag_slot]=nil then empty_bag_slot_found:=true
                else inc(empty_bag_slot);
          if empty_bag_slot_found then dstslot:=empty_bag_slot
          else exit;
     end;
     if dstslot=EQUIPMENT_SLOT_NONE then begin
       SwapFailedResponce(Sender, EQUIP_ERR_NOT_A_BAG, srcitem);
       exit;
     end;
     if Sender.CurrChar.SwapBagItems(srcbag,srcslot,SLOT_CHARACTER,dstslot) then
        Sender.CurrChar.BuildSendCharUpdateBlock;
end;

procedure CMSG_AUTOSTORE_BAG_ITEM_handler(Sender: TPlayer);
var
  srcBag, srcSlot, dstBag, dstSlot: Byte;
  Item: TItem;
begin
	Sender.ReceiveBuff.Get(srcbag);
	Sender.ReceiveBuff.Get(srcslot);
	Sender.ReceiveBuff.Get(dstbag);

  Item := Sender.CurrChar.GetBagItem(srcbag, srcslot);
  if Item <> nil then begin
    dstSlot := Sender.CurrChar.GetBagFreeSlot(dstbag) ;
    if dstSlot = 255 then
      SwapFailedResponce(Sender, EQUIP_ERR_BAG_FULL, Item)
    else if Sender.CurrChar.SwapBagItems(srcbag,srcslot,dstbag,dstslot) then
      Sender.CurrChar.BuildSendCharUpdateBlock
  end;
end;

procedure CMSG_SWAP_ITEM_handler(Sender: TPlayer);
var
  srcslot,dstslot,srcbag,dstbag: byte;
//  Item: TItem;
begin
	Sender.ReceiveBuff.Get(dstbag);
	Sender.ReceiveBuff.Get(dstslot);
	Sender.ReceiveBuff.Get(srcbag);                     
	Sender.ReceiveBuff.Get(srcslot);
  AddToLog('CMSG_SWAP_ITEM ' + IntToStr(srcbag) + ' ' + IntToStr(srcslot) + ' ' + IntToStr(dstbag) + ' ' + IntToStr(dstslot));
  if Sender.CurrChar.SwapBagItems(srcbag,srcslot,dstbag,dstslot) then
    Sender.CurrChar.BuildSendCharUpdateBlock
{  else begin
    Item := Sender.CurrChar.GetBagItem(srcbag, srcslot);
    SwapFailedResponce(Sender, EQUIP_ERR_ITEMS_CANT_BE_SWAPPED, Item);
  end;  }
end;

procedure CMSG_SWAP_INV_ITEM_handler(Sender: TPlayer);
var
  srcslot,dstslot: byte;
//  Item: TItem;
begin
	Sender.ReceiveBuff.Get(srcslot);
	Sender.ReceiveBuff.Get(dstslot);
  AddToLog('CMSG_SWAP_INV_ITEM ' + IntToStr(srcslot) + ' ' + IntToStr(dstslot));
  if Sender.CurrChar.SwapBagItems(SLOT_CHARACTER,srcslot,SLOT_CHARACTER,dstslot)then
    Sender.CurrChar.BuildSendCharUpdateBlock
  {else begin
    Item := Sender.CurrChar.GetBagItem(SLOT_CHARACTER, srcslot);
    SwapFailedResponce(Sender, EQUIP_ERR_ITEMS_CANT_BE_SWAPPED, Item);
  end;     }
end;

procedure CMSG_SPLIT_ITEM_handler(Sender: TPlayer);
var
   srcslot,dstslot,srcbag,dstbag,count: byte;
   srcitem,dstitem: TItem;
begin
	   Sender.ReceiveBuff.Get(srcbag);
	   Sender.ReceiveBuff.Get(srcslot);
	   Sender.ReceiveBuff.Get(dstbag);
	   Sender.ReceiveBuff.Get(dstslot);
	   Sender.ReceiveBuff.Get(count);
     srcitem:=Sender.CurrChar.GetBagItem(srcbag,srcslot);
     dstitem:=Sender.CurrChar.GetBagItem(dstbag,dstslot);
     if (dstitem<>nil) then
     begin
          if(dstitem.ID<>srcitem.ID) then
          begin
               SwapFailedResponce(Sender,EQUIP_ERR_ITEM_CANT_STACK,srcitem);
               exit;
          end
          else if Sender.CurrChar.AddItemCount2Bag(srcitem,dstbag,dstslot,count)then
          begin
               Sender.CurrChar.RemoveItemCountFromBag(srcbag,srcslot,count);
               Sender.CurrChar.BuildSendCharUpdateBlock;
          end;
     end
     else begin
          dstitem:=TItem.Create(Sender.CurrChar.objGUID,srcitem.ID);
          dstitem.item_count:=count;
          if Sender.CurrChar.AddItem2Bag(dstitem,dstbag,dstslot) then
          begin
               Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(dstitem);
               Sender.CurrChar.RemoveItemCountFromBag(srcbag,srcslot,count);
               Sender.CurrChar.BuildSendCharUpdateBlock;
          end;
     end;
end;

procedure CMSG_PICKUP_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DROP_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DESTROYITEM_handler(Sender: TPlayer); //created by Aven 29.03.06
var
  bagIndex, slot, count, data1, data2, data3: Byte;
  Item: TItem;
begin
  Sender.ReceiveBuff.Get(bagIndex);
  Sender.ReceiveBuff.Get(slot);
  Sender.ReceiveBuff.Get(count);
  Sender.ReceiveBuff.Get(data1);
  Sender.ReceiveBuff.Get(data2);
  Sender.ReceiveBuff.Get(data3);

	AddToLog('ITEM: Destroy, bagIndex = '+IntToStr(bagIndex)+', slot = '+IntToStr(slot)+', count = '+IntToStr(count));

  Item := Sender.CurrChar.GetBagItem(bagIndex,slot);

	if item = nil then begin
		AddToLog('ITEM: Tried to destroy a non-existant item');
		Exit;
	end;

	if (count<1) or (count >= Item.item_count) then
		Sender.CurrChar.RemoveItemFromBag(bagIndex,slot)
	else
    Sender.CurrChar.RemoveItemCountFromBag(bagIndex,slot,Item.item_count - count);

	Sender.CurrChar.BuildSendCharUpdateBlock;
end;

procedure CMSG_INSPECT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_INITIATE_TRADE_handler(Sender: TPlayer);
{const
  TRADE_BUSY = 0;
  TRADE_YOU_DEAD = 17;
  TRADE_YOU_LOGGING_OUT = 19; }
var
  trader: TCharacter ;
begin
  Sender.SendBuff.Init(SMSG_TRADE_STATUS);
  Sender.SendBuff.Add(Integer(1));
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);

  Trader := PlayerCharsHT_byGUID[Sender.CurrChar.Selected_guid];
  TPlayer(Trader.Owner).SendPacket;
end;

procedure CMSG_BEGIN_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BUSY_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_IGNORE_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ACCEPT_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNACCEPT_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CANCEL_TRADE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_TRADE_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CLEAR_TRADE_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_TRADE_GOLD_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_FACTION_ATWAR_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_FACTION_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_ACTION_BUTTON_handler(Sender: TPlayer);
var
  button, misc, types: Byte;
  action: word;
begin
 try
  Sender.ReceiveBuff.Get(button);
  Sender.ReceiveBuff.Get(action);
  Sender.ReceiveBuff.Get(misc);
  Sender.ReceiveBuff.Get(types);

  if action = 0 then begin
    //AddToLog('MISC: Remove action from button '+IntToStr(button));
    Sender.CurrChar.actionsButtons[button] := 0;
  end else begin
    if types = 64 then begin //macro
      //AddToLog('MISC: Added Macro '+IntToStr(action)+' into button '+IntToStr(button));
      Sender.CurrChar.actionsButtons[button] := $40000000 + action;
    end else
    if types = 0 then begin  //action
      //AddToLog('MISC: Added Action '+IntToStr(action)+' into button '+IntToStr(button));
      Sender.CurrChar.actionsButtons[button] := action ;
    end else
    if types = 128 then begin //item
      //AddToLog('MISC: Added Item '+IntToStr(action)+' into button '+IntToStr(button));
      Sender.CurrChar.actionsButtons[button] := $80000000 + action ;
    end
  end;
 except
  AddToLog('!!! CMSG_SET_ACTION_BUTTON Error');
 end;
end;

procedure CMSG_NEW_SPELL_SLOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CAST_SPELL_handler(Sender: TPlayer);
begin
	SS.CMSG_CAST_SPELL_handler(Sender);
end;

procedure CMSG_CANCEL_CAST_handler(Sender: TPlayer);
begin
	SS.CMSG_CANCEL_CAST_handler(Sender);
end;

procedure CMSG_CANCEL_AURA_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_CHANNEL_START_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_CHANNEL_UPDATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CANCEL_CHANNELLING_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_SELECTION_handler(Sender: TPlayer); //created by Aven 29.03.06
var
  guid: Int64;
begin
  Sender.ReceiveBuff.Get(guid);
  Sender.CurrChar.Selected_guid := guid;
end;

procedure CMSG_SET_TARGET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNUSED_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNUSED2_handler(Sender: TPlayer);
begin
	{}
end;

procedure AttackStateUpdate(Sender: TPlayer);
var
  hitInfo, damageType, blocked_amount, victimState,
  AbsorbDamage, damage, Turn: Integer;
begin
  hitInfo := $22 ;
  damageType := 1;
  blocked_amount := 0;
  victimState := 1;
  AbsorbDamage := 0;
  Turn := 0;

  damage := 15;
  
  with Sender.SendBuff do
  begin
       Init(SMSG_ATTACKERSTATEUPDATE);
       Add(Integer(hitInfo));
       Add(Byte($FF));
       Add(Sender.CurrChar.objGUID);
       Add(Byte($FF));
       Add(Sender.CurrChar.Selected_guid);
       Add(Integer({damage-}AbsorbDamage));
       Add(Byte(1)); // SubBlocks
       Add(damageType);
       Add(StrToFloat(IntToStr(Damage)));
       Add(Damage);
       Add(AbsorbDamage);
       Add(Turn);
       Add(victimState);

       if AbsorbDamage = 0 then
          Add(Integer(0))
       else
           Add(Integer(-1));

       Add(Integer(0));
       Add(Integer(blocked_amount));
       Sender.SendPacket;
  end;
end;

procedure CMSG_ATTACKSWING_handler(Sender: TPlayer);
var
  guid: Int64;
begin
  Sender.ReceiveBuff.Get(guid);

  Sender.SendBuff.Init(SMSG_ATTACKSTART);
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);
  Sender.SendBuff.Add(guid);
  Sender.SendPacket;

  AttackStateUpdate(Sender);
end;

{
SMSG_ATTACKSTOP
uint8 unk1
uin64 AttackerGUID
uint8 unk2
uin64 TargetGUID
uin32 unk3
uin32 unk4
}
procedure CMSG_ATTACKSTOP_handler(Sender: TPlayer);
begin
  with Sender.SendBuff do begin
          Init(SMSG_ATTACKSTOP);
          Add(Sender.CurrChar.objGUID);
          Add(Integer(0));
          Add(Integer(0));
{          Add(Byte($FF));
          Add(Sender.CurrChar.objGUID);
          Add(Byte($FF));
          Add(Sender.CurrChar.Selected_guid);   }
          Add(Integer(0));
          Add(Integer(0));
          Sender.SendPacket;
     end;
end;

procedure CMSG_SHEATHE_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SAVE_PLAYER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SETDEATHBINDPOINT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GETDEATHBINDZONE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_REPOP_REQUEST_handler(Sender: TPlayer);
var
  pWorldSafeLocs: PPackedWorldSafeLocs;
  Distance, Distance_min: Single; 
  i, SafeLocs{,
  _uf, _pb, _pb2, _cfb1, _cfb2}: Integer;
  //race, skin, face, hairstyle, haircolor, facialhair: Byte;
begin
  //Включаем бег по воде
  Sender.SendBuff.Init(SMSG_MOVE_WATER_WALK);
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);
  Sender.SendPacket;

  //Разрешаем вращение
  Sender.SendBuff.Init(SMSG_FORCE_MOVE_UNROOT);
  Sender.SendBuff.Add($FF);
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);
  Sender.SendPacket;

  //Изменяем скорости
	if Sender.CurrChar.cRace = crnNightElf then begin
    Sender.CurrChar.SetRunSpeed(12.75);
    Sender.CurrChar.SetSwimSpeed(8.85);
	end else begin
    Sender.CurrChar.SetRunSpeed(10.625);
    Sender.CurrChar.SetSwimSpeed(7.375);
	end;

	//! corpse reclaim delay 30 * 1000ms
{  Sender.SendBuff.Init(SMSG_CORPSE_RECLAIM_DELAY);
  Sender.SendBuff.Add(Integer(30000));
  Sender.SendBuff.Add(Byte(0)));
  Sender.SendPacket;

  Sender.SendBuff.Init(SMSG_UPDATE_AURA_DURATION);
  Sender.SendBuff.Add(Integer($20));
  Sender.SendBuff.Add(Byte(0)));
  Sender.SendPacket;  }

  with Sender.ReceiveBuff do begin
    Init ;
    Add2DbyteArr(Integer(8326), data, offs);
    Add2DbyteArr(word(0), data, offs);
    Init ;
  end;
  SS.CMSG_CAST_SPELL_handler(Sender);

  //Останавливаем все таймеры (панели)
  Sender.CurrChar.StopMirrorTimer(0);
	Sender.CurrChar.StopMirrorTimer(1);
	Sender.CurrChar.StopMirrorTimer(2);

  //становимся духом
  Sender.CurrChar.Health := 1;
  Sender.CurrChar.state := DEATH_STATE_GHOST;
  Sender.CurrChar.Flags := PLAYER_FLAGS_DEAD ;

  SetUpdateBits(Sender.CurrChar, 8, UNIT_FIELD_FLAGS);

  if Sender.CurrChar.cRace <> crnNightElf then
    SetUpdateBits(Sender.CurrChar, 8326, UNIT_FIELD_AURA);

  SetUpdateBits(Sender.CurrChar, $5068, UNIT_FIELD_AURA + 33);
	SetUpdateBits(Sender.CurrChar, $EE, UNIT_FIELD_AURAFLAGS + 4);
	SetUpdateBits(Sender.CurrChar, 2, UNIT_FIELD_AURASTATE);
	SetUpdateBits(Sender.CurrChar, 1.0, UNIT_FIELD_BOUNDINGRADIUS); //see radius of death player?
	SetUpdateBits(Sender.CurrChar, $1000000, UNIT_FIELD_BYTES_1);		//Set standing so always be standing
  SetUpdateBits(Sender.CurrChar, PLAYER_FLAGS_DEAD, PLAYER_FLAGS);

  Sender.CurrChar.BuildSendCharUpdateBlock ;

  //создаем труп
{  _uf := Sender.CurrChar.UpdateArray[Integer(UNIT_FIELD_BYTES_0)];
  _pb := Sender.CurrChar.UpdateArray[Integer(PLAYER_BYTES)];
  _pb2 := Sender.CurrChar.UpdateArray[Integer(PLAYER_BYTES_2)];

  race       := _uf;
  skin       := _pb;
  face       := _pb shr 8;
  hairstyle  := _pb shr 16;
  haircolor  := _pb shr 24;
  facialhair := _pb2;

  _cfb1 := 0 or (race shl 8) or (0 shl 16) or (skin shl 24);
  _cfb2 := face or (hairstyle shl 8) or (haircolor shl 16) or (facialhair shl 24);
}
  Sender.CurrChar.Corpse.positionX := Sender.CurrChar.positionX;
  Sender.CurrChar.Corpse.positionY := Sender.CurrChar.positionY;
  Sender.CurrChar.Corpse.positionZ := Sender.CurrChar.positionZ;

  //находим ближайшее кладбище
  Distance_min := -1;
  SafeLocs := 0;
  for i := 1 to WorldSafeLocsDbcHandler.MaxID do begin
    pWorldSafeLocs := WorldSafeLocsDbcHandler.GetPointerPRValueByIntKey(i);
    if pWorldSafeLocs <> nil then
      if pWorldSafeLocs^.MapID = Sender.CurrChar.mapid then begin
        Distance := GetQDistance(pWorldSafeLocs^.PositionX,Sender.CurrChar.PositionX,
                                 pWorldSafeLocs^.PositionY,Sender.CurrChar.PositionY,
                                 pWorldSafeLocs^.PositionZ,Sender.CurrChar.PositionZ);
        if (Distance_min = -1) or (Distance < Distance_min) then begin
          Distance_min := Distance;
          SafeLocs := pWorldSafeLocs^.ID ;
        end;
      end;
  end;

  //телепортимся духом на кладбище
  pWorldSafeLocs := WorldSafeLocsDbcHandler.GetPointerPRValueByIntKey(SafeLocs);
  if pWorldSafeLocs <> nil then
    Sender.CurrChar.Teleport(pWorldSafeLocs^.PositionX, pWorldSafeLocs^.PositionY, pWorldSafeLocs^.PositionZ, 0, pWorldSafeLocs^.MapID);
end;

procedure CMSG_RESURRECT_RESPONSE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LOOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LOOT_MONEY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LOOT_RELEASE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DUEL_ACCEPTED_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DUEL_CANCELLED_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MOUNTSPECIAL_ANIM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_SET_ACTION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_ACTION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_ABANDON_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_RENAME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_CAST_SPELL_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CreateSendQuestResponseQuestItems(Sender: TPlayer; guid: int64; lquestID: integer);
var
   j,delivery: integer;
   pquest: PPackedQuestRecord;
   pitem: PPackedItemRecord;
begin
     with Sender.SendBuff do
     begin
          Init(SMSG_QUESTGIVER_REQUEST_ITEMS);
          Add(guid);
          Add(lquestID);

          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(lquestID));
          if pquest=nil then exit;
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Objectives));
          //Add(QuestsDbcHandler.GetStringByOffset(pquest^.Details));
          Add(integer(0)); //emote delay
          Add(integer(0)); //emote emote
          Add(integer(1));
          Add(integer(0)); //require gold
          //delivery
          delivery:=0;
          for j:=0 to 3 do if pquest^.NpcObjectives[j].Deliver > 0 then inc(delivery);
          Add(delivery);
          for j:=0 to 3 do
              if pquest^.NpcObjectives[j].Deliver > 0 then
              begin
                   Add(pquest^.NpcObjectives[j].Deliver);
                   Add(pquest^.NpcObjectives[j].DeliverAmount);
                   pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(pquest^.NpcObjectives[j].Deliver));
                   Add(pitem^.Model);
              end;

          Add(integer(0)); //??
          Add(integer(0)); //??
          Add(integer(0)); //??
          Add(integer(0)); //??
          Sender.SendPacket;
     end;
end;

procedure OfferReward(Sender: TPlayer; npcTextID: integer; guid: int64; lquestID: integer);
var
   j,rewards: integer;
   pquest: PPackedQuestRecord;
   pitem: PPackedItemRecord;
   pnpctext: PPackedNpcTextRecord;
begin
  with Sender.SendBuff do
  begin
     Init(SMSG_QUESTGIVER_OFFER_REWARD);
     Add(guid);
     Add(lquestID);

     pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(lquestID));
     if pquest=nil then exit;
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.CompleteText));
     Add(integer(1));
     pnpctext:=PPackedNpcTextRecord(NpcTextDbcHandler.GetPointerPRValueByIntKey(npcTextID));
     if pnpctext<>nil then
     begin
          Add(integer(8));
          for j:=0 to 7 do
          begin
               Add(pnpctext^.NpcText_Emotes[j].Emote_Emote_Delay0);
               Add(pnpctext^.NpcText_Emotes[j].Emote_Emote_Emote0);
          end;
     end 
     else Add(integer(0));

     //reward choice
     rewards:=0;
     for j:=0 to 5 do
         if pquest^.reward_choices[j].Item > 0 then inc(rewards);
     Add(rewards);
     for j:=0 to 5 do
         if pquest^.reward_choices[j].Item > 0 then
         begin
              Add(pquest^.reward_choices[j].Item);
              Add(pquest^.reward_choices[j].Amount);
              pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(pquest^.reward_choices[j].Item));
              try
                 Add(pitem^.Model);
              except
                 Add(integer(0));
                 AddToLog('Item '+IntToStr(pquest^.reward_choices[j].Item)+' not exists');
              end;
         end;

     //rewards
     rewards:=0;
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then inc(rewards);
     Add(rewards);
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then
         begin
              Add(pquest^.rewards[j].Item);
              Add(pquest^.rewards[j].Amount);
              pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(pquest^.rewards[j].Item));
              try
                 Add(pitem^.Model);
              except
                 Add(integer(0));
                 AddToLog('Item '+IntToStr(pquest^.rewards[j].Item)+' not exists');
              end;
         end;

     Add(pquest^.MoneyReward);
     Add(integer(0)); //??
     Add(pquest^.LearnSpell); //??
     Sender.SendPacket;
  end;
end;

procedure SendQuestDetails(Sender: TPlayer; guid: int64; questID: integer);
var
   j,rewards: integer;
   pitem: PPackedItemRecord;
   pquest: PPackedQuestRecord;
begin
  pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(questID));
  if pquest=nil then exit;
  with Sender.SendBuff do
  begin
     Init(SMSG_QUESTGIVER_QUEST_DETAILS);
     Add(guid);
     Add(pquest^.id);
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Objectives));
     Add(QuestsDbcHandler.GetStringByOffset(pquest^.Details));
     Add(integer(1));
     //reward choices
     rewards:=0;
     for j:=0 to 5 do
         if pquest^.reward_choices[j].Item > 0 then inc(rewards);
     Add(rewards);
     for j:=0 to 3 do
         if pquest^.reward_choices[j].Item > 0 then
         begin
              Add(pquest^.reward_choices[j].Item);
              Add(pquest^.reward_choices[j].Amount);
              pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(pquest^.reward_choices[j].Item));
              if pitem=nil then begin AddToLog('Item '+IntToStr(pquest^.reward_choices[j].Item)+' not exist in Items.dbc');exit;end;
              Add(pitem^.Model);
         end;
     //rewards
     rewards:=0;
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then inc(rewards);
     Add(rewards);
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then
         begin
              Add(pquest^.rewards[j].Item);
              Add(pquest^.rewards[j].Amount);
              pitem:=PPackedItemRecord(ItemsDbcHandler.GetPointerPRValueByIntKey(pquest^.rewards[j].Item));
              if pitem=nil then begin AddToLog('Item '+IntToStr(pquest^.reward_choices[j].Item)+' not exist in Items.dbc');exit;end;
              Add(pitem^.Model);
         end;
     Add(pquest^.MoneyReward);
     Add(pquest^.LearnSpell);
     //Add(integer(1)); //emotes count
     //Add(integer(0)); //emotes
     Add(integer(0)); //emotes
     Sender.SendPacket;
  end;
end;

procedure SetTrackMinimapState(Sender: TPlayer; guid: int64; track_it: boolean);
var
   obj: TMobile;
   buff: TSendOpcodeArr;
begin
     obj:=TMobile(UnitHT_byGUID[guid]);
     if obj <> nil then
     begin
          if track_it then
             SetUpdateBits(obj,obj.UpdateArray[UNIT_DYNAMIC_FLAGS] or UNIT_DYNFLAG_TRACK_UNIT,UNIT_DYNAMIC_FLAGS)
          else SetUpdateBits(obj,obj.UpdateArray[UNIT_DYNAMIC_FLAGS] and not(UNIT_DYNFLAG_TRACK_UNIT),UNIT_DYNAMIC_FLAGS);
          buff:=TSendOpcodeArr.Create;
          try
             obj.CreateUpdateValuesBlockForOthers(buff);
             obj.FinaliseSendUpdateBlock(Sender,buff);
          finally
            buff.Free;
          end;
     end;
end;

procedure AddMenu(Sender: TPlayer; submenu: integer; menuIcon, inputBox: byte; text: string; var offs: integer);
begin
  with Sender.SendBuff do
  begin
     Add(submenu);
     Add(menuIcon);
     Add(inputBox); //input code box
     Add(text); //menu text
  end;
end;

procedure CMSG_GOSSIP_HELLO_handler(Sender: TPlayer);
var
   i,QuestLevel: integer;
   guid: int64;
   obj: TActiveWorldObject;
   quests,ableQuestsArr,undoneQuestsArr: TIntegerList;
   pcreature: PPackedCreatureRecord;
   quest: TActiveQuest;
procedure CreateSendGossip;
var
   j,temp_flag,flags_count: integer;
   pquest: PPackedQuestRecord;
begin
  with Sender.SendBuff do
  begin
     Init(SMSG_GOSSIP_MESSAGE);
     Add(guid);
     if pcreature^.npctextID <> 0 then
       Add(pcreature^.npctextID)
     else begin
       AddToLog('!!! NPCText for creature=' + IntToStr(pcreature^.id) + ' not found!');     
       Add(Integer(1))  ;
     end;
     //"browse goods" etc first
     temp_flag:=pcreature^.npcflags and $3F9C; //без spiritheaker etc
     asm
        mov eax,temp_flag
        xor ecx,ecx
       @@scanloop:
        bsr dx,eax
        jz  @@lquit
        inc ecx
        btr eax,dx
        //сначала надо было проверить условия типа тренер класс=чар класс и т.п.
        //вообще-то отсюда надо бы и вызывать AddMenu, только надо тексты и меню куда-то засунуть
        jmp @@scanloop
       @@lquit:
        mov flags_count,ecx
     end;

     //menu should be here
     if temp_flag = 0 then begin

       //flags_count := 1;
       //AddMenu(Sender,0,MENUICON_VENDOR,0,'text',offs);
       //AddMenu(Sender,10,MENUICON_VENDOR,0,'text2',offs);
     end ;
     Add(flags_count);
		 if (temp_flag and NPC_KIND_STABLEMASTER)<>0 then AddMenu(Sender,SUBMENU_BANKER,MENUICON_BANKER,0,'Let me check my pet %)',offs);
		 if (temp_flag and NPC_KIND_AUCTIONER)<>0 then AddMenu(Sender,SUBMENU_VENDOR,MENUICON_AUCTIONER,0,'Let me browse those lagging thing',offs);
		 if (temp_flag and NPC_KIND_BATTLEMASTER)<>0 then AddMenu(Sender,SUBMENU_VENDOR,MENUICON_BATTLEMASTER,0,'Battlemaster text',offs);
		 if (temp_flag and NPC_KIND_TABARD)<>0 then AddMenu(Sender,SUBMENU_TABARD,MENUICON_TABARD,0,'Tabard text',offs);
		 if (temp_flag and NPC_KIND_PETITION)<>0 then AddMenu(Sender,SUBMENU_PETITION,MENUICON_PETITION,0,'Petition text',offs);
		 if (temp_flag and NPC_KIND_BANKER)<>0 then AddMenu(Sender,SUBMENU_BANKER,MENUICON_BANKER,0,'Let me browse my deposite box',offs);
		 if (temp_flag and NPC_KIND_INKEEPER)<>0 then AddMenu(Sender,SUBMENU_INKEEPER_BIND,MENUICON_BINDER,0,'Make this inn my home',offs);
		 if (temp_flag and NPC_KIND_TRAINER)<>0 then AddMenu(Sender,SUBMENU_TRAINER,MENUICON_TRAINER,0,'I want some training',offs);
		 if (temp_flag and NPC_KIND_TAXI)<>0 then AddMenu(Sender,SUBMENU_TAXI,MENUICON_TAXI,0,'You sure those things flying?',offs);
		 if (temp_flag and NPC_KIND_VENDOR)<>0 then AddMenu(Sender,SUBMENU_VENDOR,MENUICON_VENDOR,0,'Let me browse your goods',offs);
     {NPC_KIND_BF_SPIRITHEALER     = $40;
     NPC_KIND_HEALER              = $20;
		 NPC_KIND_DIALOG              = 2;
		 NPC_KIND_SPIRITHEALER        = 1;
     }
     Add(undoneQuestsArr.Count+ableQuestsArr.Count);
     for j:=0 to pred(undoneQuestsArr.Count) do
     begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(undoneQuestsArr.ItemList[j]));
          Add(pquest^.id);
          Add(integer(DIALOG_STATUS_INCOMPLETE));
          Add(integer(0)); //padding
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     end;
     //Add(ableQuestsArr.Count);
     for j:=0 to pred(ableQuestsArr.Count) do
     begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(ableQuestsArr.ItemList[j]));
          Add(pquest^.id);
          Add(integer(DIALOG_STATUS_AVAILABLE));
          Add(integer(0)); //padding
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     end;

     Add(integer(0));
     Sender.SendPacket;
  end;
end;
begin
	   //get avail and active quests
     //fill menu
     //if only 1 and active then queststatus else .. CMSG_QUESTGIVER_QUERY_QUEST_handler for that
     //get npctext ID, only NpcText still in creatures
	   Sender.ReceiveBuff.Get(guid);
     obj:=TActiveWorldObject(UnitHT_byGUID.Items[guid]); //GO to UnitsHT?
     if obj<>nil then
     begin
          ableQuestsArr:=TIntegerList.Create(0);
          undoneQuestsArr:=TIntegerList.Create(0);
          try
             pcreature:=PPackedCreatureRecord(CreaturesDbcHandler.GetPointerPRValueByIntKey(obj.ID));
             if obj.objType=TYPEID_UNIT then
             begin
               quests:=TIntegerList(UnitFinishQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    for i:=0 to pred(quests.Count) do
                    begin
                         quest:=TActiveQuest.Create;
                         quest.questID:=quests.ItemList[i];
                         if (Sender.CurrChar.ActiveQuests.IndexOf(quest,MatchQuestID,false) >= 0) and not(QuestDone(Sender.CurrChar,quests.ItemList[i])) then
                         begin
                             //if done then reward
                             //exit
                             //else add undone
                             try
                                undoneQuestsArr.Add(quests.ItemList[i]);
                             except;
                             end;
                         end;
                    end;
               end;
               quests:=TIntegerList(UnitStartQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    //create able quests list
                    for i:=0 to pred(quests.Count) do
                        if QuestAble(Sender.CurrChar,quests.ItemList[i],QuestLevel) then
                        begin
                             try
                                ableQuestsArr.Add(quests.ItemList[i]);
                             except;
                             end;
                        end;
               end;
               if ableQuestsArr.Count>0 then CreateSendGossip
               else if undoneQuestsArr.Count=1 then CreateSendQuestResponseQuestItems(Sender, guid, undoneQuestsArr.ItemList[0])
               else CreateSendGossip; //create list
             end;
          finally ableQuestsArr.Free;
                  undoneQuestsArr.Free;
          end;
     end;
end;

procedure CMSG_GOSSIP_SELECT_OPTION_handler(Sender: TPlayer);
var
  guid: Int64;
  option: Integer;
begin
  Sender.ReceiveBuff.Get(guid);
  Sender.ReceiveBuff.Get(option);

  AddToLog('CMSG_GOSSIP_SELECT_OPTION ' + IntToStr(option));

  //Смещение на ноль, т.к. в дальнейшем снова читаем данные...
  Sender.ReceiveBuff.Init;

  if option = SUBMENU_TAXI then
    CMSG_TAXIQUERYAVAILABLENODES_handler(Sender);

  if option = SUBMENU_VENDOR then
    CMSG_LIST_INVENTORY_handler(Sender);

  if option = SUBMENU_TRAINER then
    CMSG_TRAINER_LIST_handler(Sender);

  if option = SUBMENU_BANKER then
    with Sender.SendBuff do begin
      Init(SMSG_SHOW_BANK);
      Add(guid);
      Sender.SendPacket;
      Exit;
    end;

  if option = SUBMENU_INKEEPER_BIND then
  with Sender.SendBuff do begin
   { with Sender.ReceiveBuff do begin
      Init ;
      Add2DbyteArr(Integer($0CD6), data, offs);
      Add2DbyteArr(word(0), data, offs);
      Init ;
    end;
    SS.CMSG_CAST_SPELL_handler(Sender); }

    Sender.CurrChar.BindingPointX := Sender.CurrChar.positionX ;
    Sender.CurrChar.BindingPointY := Sender.CurrChar.positionY ;
    Sender.CurrChar.BindingPointZ := Sender.CurrChar.positionZ ;
    Sender.CurrChar.BindingPointR := Sender.CurrChar.positionR ;
    Sender.CurrChar.BindingPointMapId := Sender.CurrChar.mapId ;

    Init(SMSG_BINDPOINTUPDATE);
    Add(Sender.CurrChar.BindingPointX);
    Add(Sender.CurrChar.BindingPointY);
    Add(Sender.CurrChar.BindingPointZ);
    Add(Sender.CurrChar.BindingPointMapId);
    Add(Sender.CurrChar.BindingPointZoneId);
    Sender.SendPacket;

    Init(SMSG_PLAYERBOUND);
    Add(Sender.CurrChar.objGUID);
    Add(Sender.CurrChar.BindingPointZoneId);
    Sender.SendPacket;
  end;

  if (option = SUBMENU_TABARD) or (option = SUBMENU_PETITION) then
    with Sender.SendBuff do begin
      Init(MSG_TABARDVENDOR_ACTIVATE);
      Add(guid);
      Sender.SendPacket;
    end;
end;

procedure CMSG_NPC_TEXT_QUERY_handler(Sender: TPlayer);
var
   i,npcTextId: integer;
   pnpctext: PPackedNpcTextRecord;
begin
	Sender.ReceiveBuff.Get(npcTextId);
  //recv_data >> uField0 >> uField1;
  //GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET, uField0);
  //GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET + 1, uField1);
  with Sender.SendBuff do
  begin
     Init(SMSG_NPC_TEXT_UPDATE);
     Add(npcTextId);
     pnpctext:=PPackedNpcTextRecord(NpcTextDbcHandler.GetPointerPRValueByIntKey(npcTextID));
     if pnpctext=nil then
     begin
          Add(integer(0));
          Add('Greetings $N');
          Add('Greetings $N');
     end
     else for i:=0 to 7 do
     begin
          Add(pnpctext^.NpcText_Emotes[i].Emote_Probability);
          Add(NpcTextDbcHandler.GetStringByOffset(pnpctext^.NpcText_Emotes[i].Emote_Text0));
          Add(NpcTextDbcHandler.GetStringByOffset(pnpctext^.NpcText_Emotes[i].Emote_Text1));
          Add(pnpctext^.NpcText_Emotes[i].Emote_Language);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Delay0);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Emote0);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Delay1);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Emote1);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Delay2);
          Add(pnpctext^.NpcText_Emotes[i].Emote_Emote_Emote2);
     end;
     Sender.SendPacket;
  end;
end;

procedure CMSG_QUESTGIVER_STATUS_QUERY_handler(Sender: TPlayer);
var
   i,QuestLevel,CharLevel,dialogResult: integer;
   guid: int64;
   obj: TActiveWorldObject;
   quests: TIntegerList;
   ableAny: boolean;
   quest: TActiveQuest;
begin
     dialogResult:=DIALOG_STATUS_NONE;
	   Sender.ReceiveBuff.Get(guid);
     obj:=TActiveWorldObject(UnitHT_byGUID.Items[guid]); //GO to UnitsHT?
     if obj<>nil then
     begin
          CharLevel:=Sender.CurrChar.Level;
          if obj.objType=TYPEID_UNIT then
          begin
               quests:=TIntegerList(UnitFinishQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    for i:=0 to pred(quests.Count) do
                    begin
                         quest:=TActiveQuest.Create;
                         quest.questID:=quests.ItemList[i];
                         if (Sender.CurrChar.ActiveQuests.IndexOf(quest,MatchQuestID,false) >= 0) then
                         begin
                             if (QuestDone(Sender.CurrChar,quests.ItemList[i])) then
                             begin
                                  dialogResult:=DIALOG_STATUS_REWARD;
                                  //minimappos
                             end
                             else dialogResult:=DIALOG_STATUS_INCOMPLETE;
                         end;
                    end;
               end;
               quests:=TIntegerList(UnitStartQuestsHT.Items[obj.ID]);
               if (dialogResult<>DIALOG_STATUS_REWARD)and(quests<>nil) then
               begin
                    ableAny:=false;
                    for i:=0 to pred(quests.Count) do
                        if QuestAble(Sender.CurrChar,quests.ItemList[i],QuestLevel) then
                        begin
                             ableAny:=true;
                             if (dialogResult<>DIALOG_STATUS_AVAILABLE)and(CharLevel > (QuestLevel-10))and(CharLevel < (QuestLevel+10))then
                                dialogResult:=DIALOG_STATUS_AVAILABLE;
                        end;
                    if (ableAny) then dialogResult:=DIALOG_STATUS_AVAILABLE;
               end;
               SetTrackMinimapState(Sender,guid,(dialogResult=DIALOG_STATUS_REWARD)or(dialogResult=DIALOG_STATUS_REWARD_REP));
               Sender.SendBuff.Init(SMSG_QUESTGIVER_STATUS);
               Sender.SendBuff.Add(guid);
               Sender.SendBuff.Add(dialogResult);
               Sender.SendPacket;
          end
          else if obj.objType=TYPEID_GAMEOBJECT then
          begin
               quests:=TIntegerList(ObjectFinishQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    {for i:=0 to pred(quests.Count) do
                        if QuestDone(Sender.CurrChar,quests[i]) then
                        begin
                             //reward
                             //exit
                        end;}
               end;
               quests:=TIntegerList(ObjectStartQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    {for i:=0 to pred(quests.Count) do
                        if QuestAble(Sender.CurrChar,quests[i]) then
                        begin
                             //store quest level
                             //>/< 10 levels set
                             //exit
                        end;}
                    //if able and in 10 levels yellow !, else dialog
               end;
          end;
     end;
end;

procedure CMSG_QUESTGIVER_HELLO_handler(Sender: TPlayer);
var
   i,QuestLevel: integer;
   guid: int64;
   obj: TActiveWorldObject;
   quests,ableQuestsArr,undoneQuestsArr,finishedQuestsArr: TIntegerList;
   pcreature: PPackedCreatureRecord;
   quest: TActiveQuest;
procedure CreateSendQuestList;
var
   j: integer;
   pquest: PPackedQuestRecord;
begin
  with Sender.SendBuff do
  begin
     Init(SMSG_QUESTGIVER_QUEST_LIST);
     Add(guid);
     Add('Greetings, $c.'); //Menu title  Greetings $N
     Add(integer(0)); //delay
     Add(integer(0)); //emote
     //browse goods etc first
     Add(byte(undoneQuestsArr.Count+ableQuestsArr.Count));
     for j:=0 to pred(finishedQuestsArr.Count) do
     begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(finishedQuestsArr.ItemList[j]));
          Add(pquest^.id);
          Add(integer(DIALOG_STATUS_REWARD));
          Add(integer(0)); //padding
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     end;
     for j:=0 to pred(undoneQuestsArr.Count) do
     begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(undoneQuestsArr.ItemList[j]));
          Add(pquest^.id);
          Add(integer(DIALOG_STATUS_INCOMPLETE));
          Add(integer(0)); //padding
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     end;
     for j:=0 to pred(ableQuestsArr.Count) do
     begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(ableQuestsArr.ItemList[j]));
          Add(pquest^.id);
          Add(integer(DIALOG_STATUS_AVAILABLE));
          Add(integer(0)); //padding
          Add(QuestsDbcHandler.GetStringByOffset(pquest^.Name));
     end;

     Sender.SendPacket;
  end;
end;
begin
     //get done quests
	   //get avail and active quests
     //fill menu
     //if only 1 and active then queststatus else .. CMSG_QUESTGIVER_QUERY_QUEST_handler for that
     //get npctext ID, only NpcText still in creatures
	   Sender.ReceiveBuff.Get(guid);
     obj:=TActiveWorldObject(UnitHT_byGUID.Items[guid]); //GO to UnitsHT?
     if obj<>nil then
     begin
          ableQuestsArr:=TIntegerList.Create(0);
          undoneQuestsArr:=TIntegerList.Create(0);
          finishedQuestsArr:=TIntegerList.Create(0);
          try
             pcreature:=PPackedCreatureRecord(CreaturesDbcHandler.GetPointerPRValueByIntKey(obj.ID));
             if obj.objType=TYPEID_UNIT then
             begin
               quests:=TIntegerList(UnitFinishQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    for i:=0 to pred(quests.Count) do
                    begin
                         quest:=TActiveQuest.Create;
                         quest.questID:=quests.ItemList[i];
                         if (Sender.CurrChar.ActiveQuests.IndexOf(quest,MatchQuestID,false) >= 0)then
                         begin
                             //if done then reward
                             if QuestDone(Sender.CurrChar,quests.ItemList[i])then
                             try
                                  finishedQuestsArr.Add(quests.ItemList[i]);
                             except
                             end
                             //else add undone
                             else try
                                  undoneQuestsArr.Add(quests.ItemList[i]);
                             except;
                             end;
                         end;
                    end;
               end;
               quests:=TIntegerList(UnitStartQuestsHT.Items[obj.ID]);
               if quests<>nil then
               begin
                    //create able quests list
                    for i:=0 to pred(quests.Count) do
                        if QuestAble(Sender.CurrChar,quests.ItemList[i],QuestLevel) then
                        begin
                             try
                                ableQuestsArr.Add(quests.ItemList[i]);
                             except;
                             end;
                        end;
               end;
               if finishedQuestsArr.Count=1 then OfferReward(Sender, pcreature.npctextID, guid, finishedQuestsArr.ItemList[0])
               else if undoneQuestsArr.Count=1 then CreateSendQuestResponseQuestItems(Sender, guid, undoneQuestsArr.ItemList[0])
               else if ableQuestsArr.Count=1 then SendQuestDetails(Sender,guid,ableQuestsArr.ItemList[0])
               else CreateSendQuestList; //create list
             end;
          finally ableQuestsArr.Free;
                  undoneQuestsArr.Free;
          end;
     end;
end;

procedure CMSG_QUESTGIVER_QUERY_QUEST_handler(Sender: TPlayer);
var
   guid: int64;
   questID: integer;
begin
	   Sender.ReceiveBuff.Get(guid);
	   Sender.ReceiveBuff.Get(questID);

     SendQuestDetails(Sender,guid,questID);
end;

procedure CMSG_QUESTGIVER_QUEST_AUTOLAUNCH_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUESTGIVER_ACCEPT_QUEST_handler(Sender: TPlayer);
var
   guid: int64;
   i,questID,emptyIndex: integer;
   pquest: PPackedQuestRecord;
   quest: TActiveQuest;
begin
	   Sender.ReceiveBuff.Get(guid);
	   Sender.ReceiveBuff.Get(questID);

     pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(questID));
     if pquest=nil then exit;
     emptyIndex:=0;
     while (emptyIndex < 20)and(emptyIndex < Sender.CurrChar.ActiveQuests.Count) do
     begin
          if (Sender.CurrChar.ActiveQuests.ItemList[emptyIndex]=nil) then break;
          inc(emptyIndex);
     end;
     if emptyIndex = 20 then exit; //fail, quest log full, TODO send msg
     quest:=TActiveQuest.Create;
     quest.questID:=questID;
     for i:=0 to 3 do
         quest.objectives[i]:=pquest^.NpcObjectives[i];
     for i:=0 to 3 do
     begin
          quest.objectives[i].Amount:=0;
          quest.objectives[i].DeliverAmount:=0;
     end;
     Sender.CurrChar.ActiveQuests.Insert(emptyIndex,quest);
     //if pquest^.ReceiveItem > 0 then //check bags, fail if empty FAILEDREASON_INV_FULL, else add 2 bags
     //check quest status

     AddToLog('add '+QuestsDbcHandler.GetStringByOffset(pquest^.Name)+' idx '+IntToStr(emptyIndex));
     SetUpdateBits(Sender.CurrChar,questID,PLAYER_QUEST_LOG_1_1+emptyIndex*3);
     //if QuestDone(Sender.CurrChar,questID) then
     //   SetUpdateBits(Sender.CurrChar,$01000000,PLAYER_QUEST_LOG_1_1+Sender.CurrChar.ActiveQuests.IndexOf(questID)*3+1);
     //else
     SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+emptyIndex*3+1); //6 bits per objectives count, bit 25 mean failed
     SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+emptyIndex*3+2); //failed reason?
     Sender.CurrChar.BuildSendCharUpdateBlock;

     {offs:=4;
     Add(questID);
     Sender.SendPacket(SMSG_QUESTUPDATE_COMPLETE,offs);}
     //CommandGo(Sender);
end;

procedure CMSG_QUESTGIVER_COMPLETE_QUEST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUESTGIVER_REQUEST_REWARD_handler(Sender: TPlayer);
begin
	{}
end;

procedure SendQuestCompleteToPlayer(Sender: TPlayer; pquest: PPackedQuestRecord);
const
   Full_Quest_XP = 100;
var
   j, rewards, Quest_XP: integer;
begin
  with Sender.SendBuff do
  begin
     Init(SMSG_QUESTGIVER_QUEST_COMPLETE);
     Add(pquest^.id);
     Add(integer(3));

     Quest_XP := 0 ;
     if Sender.CurrChar.Level <= pquest^.QuestLevel +  5 then Quest_XP := Full_Quest_XP;
     if Sender.CurrChar.Level  = pquest^.QuestLevel +  6 then Quest_XP := ROUND(Full_Quest_XP * 0.8 / 5) * 5  ;
     if Sender.CurrChar.Level  = pquest^.QuestLevel +  7 then Quest_XP := ROUND(Full_Quest_XP * 0.6 / 5) * 5  ;
     if Sender.CurrChar.Level  = pquest^.QuestLevel +  8 then Quest_XP := ROUND(Full_Quest_XP * 0.4 / 5) * 5  ;
     if Sender.CurrChar.Level  = pquest^.QuestLevel +  9 then Quest_XP := ROUND(Full_Quest_XP * 0.2 / 5) * 5 ;
     if Sender.CurrChar.Level >= pquest^.QuestLevel + 10 then Quest_XP := ROUND(Full_Quest_XP * 0.1 / 5) * 5 ;

     Sender.CurrChar.GiveXP(Quest_XP);
     if pquest^.MoneyReward <> 0 then begin
       Sender.CurrChar.copper := Sender.CurrChar.copper + pquest^.MoneyReward ;
       SetUpdateBits(Sender.CurrChar, Sender.CurrChar.copper, PLAYER_FIELD_COINAGE);
     end;
     
     Add(Quest_XP);
     Add(pquest^.MoneyReward);

     rewards:=0;
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then inc(rewards);
     Add(rewards);
     for j:=0 to 3 do
         if pquest^.rewards[j].Item > 0 then
         begin
              Add(pquest^.rewards[j].Item);
              Add(pquest^.rewards[j].Amount);
         end;
     Sender.SendPacket;
  end;
end;

procedure CMSG_QUESTGIVER_CHOOSE_REWARD_handler(Sender: TPlayer);
var
   guid: int64;
   questID,rewardID,questIndex: integer;
   pquest: PPackedQuestRecord;
   quest: TActiveQuest;
   //rewardFound: boolean;
begin
	   Sender.ReceiveBuff.Get(guid);
	   Sender.ReceiveBuff.Get(questID);
	   Sender.ReceiveBuff.Get(rewardID);
     pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(questID));
     if pquest=nil then exit;
     {rewardFound:=false;
     for i:=0 to 5 do
         if pquest^.reward_choices[i].Item = rewardID then
            rewardFound:=true;
     if not(rewardFound) then ban this palyer!!!}
	   //add items/spells here
     //remove objectives
     quest:=TActiveQuest.Create;
     quest.questID:=questID;
     questIndex:=Sender.CurrChar.ActiveQuests.IndexOf(quest,MatchQuestID,false);
     Sender.CurrChar.ActiveQuests.ItemList[questIndex]:=nil;

     Sender.SendBuff.Init(SMSG_QUESTUPDATE_COMPLETE);
     Sender.SendPacket;

     SendQuestCompleteToPlayer(Sender,pquest);
     //free quest slot
     AddToLog('remove '+QuestsDbcHandler.GetStringByOffset(pquest^.Name)+' idx '+IntToStr(questIndex));
     SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3);
     SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3+1); //6 bits per objectives count, bit 25 mean failed
     SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3+2); //failed reason?
     Sender.CurrChar.BuildSendCharUpdateBlock;
     Sender.CurrChar.DoneQuests.AddIfNotExists(questID);
     //Sender.SendPacket(SMSG_GOSSIP_COMPLETE,4);
     //open next quest if exists
     if pquest^.NextStoryQuest > 0 then SendQuestDetails(Sender,guid,pquest^.NextStoryQuest);
     {begin
          pquest:=PPackedQuestRecord(QuestsDbcHandler.GetPointerPRValueByIntKey(pquest^.NextStoryQuest));
          if pquest=nil then exit;
          
     end;}
end;

procedure CMSG_QUESTGIVER_CANCEL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUESTLOG_SWAP_QUEST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUESTLOG_REMOVE_QUEST_handler(Sender: TPlayer);
var
  questIndex: Byte;
begin
  Sender.ReceiveBuff.Get(questIndex);
  AddToLog('CMSG_QUESTLOG_REMOVE_QUEST ' + IntToStr(questIndex));
  Sender.CurrChar.ActiveQuests.ItemList[questIndex]:=nil;
  //free quest slot
  SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3);
  SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3+1); //6 bits per objectives count, bit 25 mean failed
  SetUpdateBits(Sender.CurrChar,integer(0),PLAYER_QUEST_LOG_1_1+questIndex*3+2); //failed reason?
  Sender.CurrChar.BuildSendCharUpdateBlock;
end;

procedure CMSG_QUEST_CONFIRM_ACCEPT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PUSHQUESTTOPARTY_handler(Sender: TPlayer);
begin
	{}
end;

function GetVendorItemsByVendorID(ID: Integer): String;
var
  pcreature: PPackedCreatureRecord ;
  st: PPackedSellTemplateRecord;
begin
  Result := '';
  pcreature:=CreaturesDbcHandler.GetPointerPRValueByIntKey(ID); //Находим нужного кричерса
  if pcreature <> nil then begin
    st := SellTemplateDbcHandler.GetPointerPRValueByIntKey(pcreature^.selltemplate); //Находим нужный темплейт
    if st <> nil then Result := SellTemplateDbcHandler.GetStringByOffset(st^.sell);
  end;
end;

procedure CMSG_LIST_INVENTORY_handler(Sender: TPlayer); //changed by Aven 28.03.06
var
  guid: Int64;
  numitems, i, a: Byte;
  cItemsLen: Integer;

  Items: array of Integer;
  Item: TItem;
  mob: TMobile;
begin
  Sender.ReceiveBuff.Get(guid);
  //AddToLog('Recvd CMSG_LIST_INVENTORY '+IntToStr(guid));

  mob := UnitHT_byGUID[guid];
  if mob <> nil then begin
    setlength(Items, maxbyte);
    cItemsLen := FillIntArrWithStrData(GetVendorItemsByVendorID(mob.ID), ';', Items);
    setlength(Items,cItemsLen);

    numitems := cItemsLen;
    if numitems > 0 then
    with Sender.SendBuff do
    begin
      Init(SMSG_LIST_INVENTORY);
      Add(guid);
      Add(Byte(numitems));

      for i := 0 to numitems-1 do begin
        Item := TItem.Create(guid, items[i]);
        if (Item = nil) or (Item.PItemRecord = nil)  then begin
          AddToLog('!!! Unit '+IntToStr(guid)+' has nonexistant item '+IntToStr(Item.ID)+'!');
          for a := 0 to 6 do
            Add(Integer(0));
        end else begin
          //AddToLog('inv: '+ItemsDbcHandler.GetStringByOffset(Item.PItemRecord^.Name_Inv)+'('+IntToStr(items[i])+')');
          Add(Integer(i+1));
          Add(Integer(Item.ID)); //item id
          Add(Integer(Item.PItemRecord^.Model));//item model
          Add(Integer(-1)); //item Amount
          Add(Integer(Item.PItemRecord^.BuyPrice));//item BuyPrice
          Add(Integer(0));
          Add(Integer(0));
          Item.Free ;
        end;
      end;
      Sender.SendPacket;
    end else
      AddToLog('!!! SellTemplate not found, MobID=' + IntToStr(mob.id));
  end;  
end;

procedure CMSG_SELL_ITEM_handler(Sender: TPlayer);
var
  vendorguid, itemguid: Int64;
  amount, bag,slot: Byte;

  Vendor: TMobile;
  Item: TItem;
begin
	//AddToLog('Recieved CMSG_SELL_ITEM');

  Sender.ReceiveBuff.Get(vendorguid);
  Sender.ReceiveBuff.Get(itemguid);
  Sender.ReceiveBuff.Get(amount);

  //AddToLog('CMSG_SELL_ITEM: ' + IntToStr(vendorguid) + ' ' + IntToStr(itemguid)  + ' ' + IntToStr(amount));

  with Sender.SendBuff do
  begin
		if itemguid = 0 then begin
      Init(SMSG_SELL_ITEM);
      Add(vendorguid);
      Add(itemguid);
      Add(Byte(1));
			Sender.SendPacket;
      Exit;
		end;

    Vendor := UnitHT_byGUID[vendorguid];
		if Vendor = nil then begin
      Init(SMSG_SELL_ITEM);
      Add(vendorguid);
      Add(itemguid);
      Add(Byte(3));
			Sender.SendPacket;
      Exit;
		end;

		if (Sender.CurrChar.GetSlotByItemGUID(itemguid,bag,slot)) then begin
			Item := Sender.CurrChar.GetBagItem(bag,slot);
			if Item <> nil then begin
				if Item.PItemRecord^.BuyPrice <> 0 then begin
          Init(SMSG_SELL_ITEM);
          Add(vendorguid);
          Add(itemguid);
          Add(Byte(0));
			    Sender.SendPacket;

          Sender.CurrChar.SetCopper(Sender.CurrChar.copper + Item.PItemRecord^.SellPrice * Item.item_count);
          //AddToLog('Sell item: '+ItemsDbcHandler.GetStringByOffset(Item.PItemRecord^.Name_Inv));

          Sender.CurrChar.AddItemToBuyBackSlot(Item, Sender.CurrChar.CurrentBuybackSlot);
					Sender.CurrChar.SetCurrentBuybackSlot(Sender.CurrChar.CurrentBuybackSlot + 1);

					Sender.CurrChar.RemoveItemFromBag(bag,slot);
          Sender.CurrChar.BuildSendCharUpdateBlock ;
			  end else begin
          Init(SMSG_SELL_ITEM);
          Add(vendorguid);
          Add(itemguid);
          Add(Byte(2));
			    Sender.SendPacket;
			  end;
      end
      else begin
        Init(SMSG_SELL_ITEM);
        Add(vendorguid);
        Add(itemguid);
        Add(Byte(1));
        Sender.SendPacket;
			  Exit;
      end;
    end;
  end;
end;

procedure CMSG_BUY_ITEM_handler(Sender: TPlayer); //created by Aven 29.03.06
var
  srcguid: Int64;
  itemid, newmoney, cItemsLen: Integer;
  amount, slot, i: Byte;
  Item: TItem;
  mob: TMobile;
  BuyAccept: Boolean;
  Items: array of Integer;
begin
  //AddToLog('Recieved CMSG_BUY_ITEM');

  Sender.ReceiveBuff.Get(srcguid);
  Sender.ReceiveBuff.Get(itemid);
  Sender.ReceiveBuff.Get(amount);
  Sender.ReceiveBuff.Get(slot);

  with Sender.SendBuff do
  begin
    mob := UnitHT_byGUID[srcguid];
    if mob <> nil then begin
      //Проверка на наличие данного итема у вендора
      setlength(Items, maxbyte);
      cItemsLen := FillIntArrWithStrData(GetVendorItemsByVendorID(mob.ID), ';', Items);
      setlength(Items,cItemsLen);

      BuyAccept := False;
      for i := 0 to cItemsLen do
          if Items[i] = itemid then begin
             BuyAccept := True;
             Break;
          end;

      if not BuyAccept then begin
         Init(SMSG_BUY_FAILED);
         Add(srcguid);
         Add(itemid);
         Add(Byte(0));
         Sender.SendPacket;
         AddToLog('!!! Requested Buy Item not forund! ItemID = ' + IntToStr(itemid));
         Exit;
      end;

      Item := TItem.Create(Sender.CurrChar.objGUID, itemid);
      if Item <> nil then begin
        newmoney := Sender.CurrChar.copper - Item.PItemRecord^.BuyPrice ;
        if newmoney < 0 then begin //Если у чара нехватает денег
          Init(SMSG_BUY_FAILED);
          Add(srcguid);
          Add(itemid);
          Add(Byte(2));
          Sender.SendPacket;
          //AddToLog('Sent SMSG_BUY_FAILED 2');
          Exit;
        end;                                 
        if (Sender.CurrChar.GetInvFreeSlot <> 255) and
             Sender.CurrChar.AddItemCount2Bag(Item, SLOT_CHARACTER, Sender.CurrChar.GetInvFreeSlot, amount) then
        begin
          Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(Item);
          Sender.CurrChar.SetCopper(newmoney);

          //AddToLog('Buy item: '+ItemsDbcHandler.GetStringByOffset(Item.PItemRecord^.Name_Inv));
          Init(SMSG_BUY_ITEM);
          Add(srcguid);
          Add(itemid);
          Add(Byte(amount));
          Sender.SendPacket;
          //AddToLog('Sent SMSG_BUY_ITEM');
		    end
        else begin //Нет места для итема в инвентаре
          Init(SMSG_BUY_FAILED);
          Add(srcguid);
          Add(itemid);
          Add(Byte(8));
          Sender.SendPacket;
          //AddToLog('Sent SMSG_BUY_FAILED 8');
		    end;
      end
      else begin
        Init(SMSG_BUY_FAILED);
        Add(srcguid);
        Add(itemid);
        Add(Byte(0));
        Sender.SendPacket;
        //AddToLog('Sent SMSG_BUY_FAILED 0');
		  end;
    end;
  end;
end;

procedure CMSG_BUY_ITEM_IN_SLOT_handler(Sender: TPlayer);
var
  srcguid,dstguid: Int64;
  itemid, newmoney, cItemsLen: Integer;
  amount, slot, i: Byte;
  Item: TItem;
  mob: TMobile;
  BuyAccept: Boolean;
  Items: array of Integer;
begin
 try
  Sender.ReceiveBuff.Get(srcguid);
  Sender.ReceiveBuff.Get(itemid);
  Sender.ReceiveBuff.Get(dstguid);
  Sender.ReceiveBuff.Get(slot);
  Sender.ReceiveBuff.Get(amount);

  AddToLog('CMSG_BUY_ITEM_IN_SLOT ' + IntToStr(itemid) + ' ' + IntToStr(slot) + ' ' + IntToStr(amount));

  mob := UnitHT_byGUID[srcguid];
  if mob <> nil then
  with Sender.SendBuff do
  begin
    //Проверка на наличие данного итема у вендора
    setlength(Items, maxbyte);
    cItemsLen := FillIntArrWithStrData(GetVendorItemsByVendorID(mob.ID), ';', Items);
    setlength(Items,cItemsLen);

    BuyAccept := False;
    for i := 0 to cItemsLen do
      if Items[i] = itemid then begin
        BuyAccept := True;
        Break;
      end;

    if not BuyAccept then begin
      Init(SMSG_BUY_FAILED);
      Add(srcguid);
      Add(itemid);
      Add(Byte(0));
      Sender.SendPacket;
      AddToLog('!!! Requested Buy Item not forund! ItemID = ' + IntToStr(itemid));
      Exit;
    end;

    Item := TItem.Create(Sender.CurrChar.objGUID, itemid);
    if Item <> nil then begin
      newmoney := Sender.CurrChar.copper - Item.PItemRecord^.BuyPrice ;
      if newmoney < 0 then begin //Если у чара нехватает денег
        Init(SMSG_BUY_FAILED);
        Add(srcguid);
        Add(itemid);
        Add(Byte(2));
        Sender.SendPacket;
        //AddToLog('SMSG_BUY_FAILED 2');
        Exit;
      end;

      if (Sender.CurrChar.cItems[slot] = nil) and
       Sender.CurrChar.AddItemCount2Bag(Item, SLOT_CHARACTER, slot, amount) then begin
        Sender.CurrChar.SendPartialCreateItemUpdateBlockForPlayer(Item);
        Sender.CurrChar.SetCopper(newmoney);
                
        //AddToLog('Buy item: '+ItemsDbcHandler.GetStringByOffset(Item.PItemRecord^.Name_Inv));
        Init(SMSG_BUY_ITEM);
        Add(srcguid);
        Add(itemid);
        Add(Byte(amount));
        Sender.SendPacket;
        AddToLog('SMSG_BUY_ITEM');
	    end else begin //Нет места для итема в инвентаре
        Init(SMSG_BUY_FAILED);
        Add(srcguid);
        Add(itemid);
        Add(Byte(8));
        Sender.SendPacket; 
        //AddToLog('SMSG_BUY_FAILED 8');
	    end;
    end else begin
      Init(SMSG_BUY_FAILED);
      Add(srcguid);
      Add(itemid);
      Add(Byte(0));
      Sender.SendPacket;
      //AddToLog('SMSG_BUY_FAILED 0');
	  end;
  end;
 except
  AddToLog('!!! CMSG_BUY_ITEM ERROR');
 end;
end;

procedure CMSG_TRAINER_LIST_handler(Sender: TPlayer);
var
  req_level: Byte;
  no_money, low_level: Boolean;
  i,spellRecOffs, spellcost: integer;
   guid: int64;
   obj: TMobile;
   pcreature: PPackedCreatureRecord;
   obj_guild: string;
   spells_set: TSpellLearnClassTemplate;
begin
     Sender.ReceiveBuff.Get(guid);
     obj:=TMobile(UnitHT_byGUID[guid]);
     if obj = nil then exit; //addToLog('Creature not exists');
     pcreature:=PPackedCreatureRecord(CreaturesDbcHandler.GetPointerPRValueByIntKey(obj.ID));
     if pcreature = nil then exit;
     obj_guild:=CreaturesDbcHandler.GetStringByOffset(pcreature.guild);
     //get skillline and spell arrays
     //пал : Holy56  Protection257  Retribution184
     //шам : Elemental375   Enhancement373  Restoration573-374
     //прист: Discipline613    Holy594   Shadow73
     //Hunter: Beast Mastery50 Marksmanship163 Survival51-142
     //Warlock : Affliction355 Demonology354 Destruction593
     //друид Balance574  FeralCombat134   Restoration374-573
     if      (Sender.CurrChar.cClass = ccnMage) and (obj_guild = 'Mage Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,6,8,237)
     else if (Sender.CurrChar.cClass = ccnWarrior) and (obj_guild = 'Warrior Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,26,256,267)
     else if (Sender.CurrChar.cClass = ccnRogue) and (obj_guild = 'Rogue Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,38,39,253)
     else if (Sender.CurrChar.cClass = ccnPaladin) and (obj_guild = 'Paladin Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,56,184,157)
     else if (Sender.CurrChar.cClass = ccnHunter) and (obj_guild = 'Hunter Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,50,51,163)
     else if (Sender.CurrChar.cClass = ccnPriest) and (obj_guild = 'Priest Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,73,594,613)
     else if (Sender.CurrChar.cClass = ccnShaman) and (obj_guild = 'Shaman Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,373,374,375)
     else if (Sender.CurrChar.cClass = ccnWarlock) and (obj_guild = 'Warlock Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,354,355,593)
     else if (Sender.CurrChar.cClass = ccnDruid) and (obj_guild = 'Druid Trainer') then spells_set:=TSpellLearnClassTemplate.Create(61,Sender.CurrChar.bRace,Sender.CurrChar.bClass,134,573,574)
     else exit;

     with Sender.SendBuff do
     begin
       Init(SMSG_TRAINER_LIST);
       Add(guid);
       Add(integer(0));
       Add(spells_set.spellCount);
       for i:=0 to pred(spells_set.spellCount) do
       begin
          spellRecOffs:=temp_spells_field_count*i;

          req_level := spells_set.learnTemplate[spellRecOffs+1] ;
          spellcost := spells_set.learnTemplate[spellRecOffs+5] ;

          low_level := (req_level > Sender.CurrChar.Level);
          no_money := (spellcost > Sender.CurrChar.copper);

          Add(spells_set.learnTemplate[spellRecOffs]);
          {if hasspell then Add(byte(2))
          else} if no_money or low_level then Add(byte(1))
          else Add(byte(0));
          Add(spellcost); //spellcost
          Add(integer(0));
          Add(integer(0));
          Add(req_level); //req_level
          Add(spells_set.learnTemplate[spellRecOffs+2]); //integer(req_skill)
          Add(spells_set.learnTemplate[spellRecOffs+3]); //integer(min_skill)
          Add(spells_set.learnTemplate[spellRecOffs+4]); //integer(req_spell)
          Add(integer(0));
          Add(integer(0));
       end;
       Sender.SendPacket;
     end;
end;

procedure CMSG_TRAINER_BUY_SPELL_handler(Sender: TPlayer);
var
  guid: Int64;
  spellId: Integer;
begin
  Sender.ReceiveBuff.Get(guid);
  Sender.ReceiveBuff.Get(spellId);

  Sender.CurrChar.AddSpell(spellId);

  Sender.SendBuff.Init(SMSG_LEARNED_SPELL);
  Sender.SendBuff.Add(spellId);
  Sender.SendPacket;

  Sender.SendBuff.Init(SMSG_TRAINER_BUY_SUCCEEDED);
  Sender.SendBuff.Add(guid);
  Sender.SendBuff.Add(spellId);
  Sender.SendPacket;
end;

procedure CMSG_BINDER_ACTIVATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BANKER_ACTIVATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BUY_BANK_SLOT_handler(Sender: TPlayer);
var
  bankslot, playerGold: Integer;
  BankBagSlotPrices: PPackedBankBagSlotPricesRecord;
begin
	//bank := Sender.CurrChar.UpdateArray[PLAYER_BYTES_2];
	//bankslot := (bank and $70000) shr 16;
  bankslot := (Sender.CurrChar.rest_state_f_hair and $70000) shr 16;

	if bankslot < 6 then Inc(bankslot) else Exit;

	AddToLog('CMSG_BUY_BANK_SLOT ' + IntToStr(bankslot));

	BankBagSlotPrices := BankBagSlotPricesDbcHandler.GetPointerPRValueByIntKey(bankslot) ;
  if BankBagSlotPrices <> nil then begin


  	Sender.CurrChar.rest_state_f_hair := (Sender.CurrChar.rest_state_f_hair and not $70000) + (bankslot shl 16);
  	playerGold := Sender.CurrChar.copper ;
	  if playerGold >= BankBagSlotPrices^.Price then begin
      SetUpdateBits(Sender.CurrChar, Sender.CurrChar.rest_state_f_hair, PLAYER_BYTES_2);
      Sender.CurrChar.SetCopper(playerGold - BankBagSlotPrices^.Price);
      //Sender.CurrChar.BuildSendCharUpdateBlock ;
	  end;
  end;  
end;

procedure CMSG_PETITION_SHOWLIST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PETITION_BUY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PETITION_SHOW_SIGNATURES_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PETITION_SIGN_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_PETITION_DECLINE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_OFFER_PETITION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TURN_IN_PETITION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PETITION_QUERY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BUG_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PLAYED_TIME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_QUERY_TIME_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_SPLIT_MONEY_handler(Sender: TPlayer);
begin
	{}
end;

//Оживаем :)
procedure CMSG_RECLAIM_CORPSE_handler(Sender: TPlayer);
{var
  guid: Int64;}
begin
  //Sender.ReceiveBuff.Get(guid);

  // resurrect
  // remove death flag + set aura
  Sender.CurrChar.Flags := Sender.CurrChar.Flags and not PLAYER_FLAGS_DEAD ;
  SetUpdateBits(Sender.CurrChar,Sender.CurrChar.Flags, PLAYER_FLAGS);

  // remove duel flags
  //if GetPvP() then RemoveFlag( UNIT_FIELD_FLAGS, 0x1000 );

  Sender.CurrChar.state := DEATH_STATE_ALIVE;

  Sender.SendBuff.Init(SMSG_MOVE_LAND_WALK);
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);
  Sender.SendPacket;

  Sender.SendBuff.Init(SMSG_FORCE_MOVE_UNROOT);
  Sender.SendBuff.Add($FF);
  Sender.SendBuff.Add(Sender.CurrChar.objGUID);
  Sender.SendPacket;

  Sender.CurrChar.SetRunSpeed(7.5);
  Sender.CurrChar.SetSwimSpeed(4.9);

  SetUpdateBits(Sender.CurrChar, 0, UNIT_FIELD_AURA);  

  SetUpdateBits(Sender.CurrChar, 0, CONTAINER_FIELD_SLOT_1+29);
  SetUpdateBits(Sender.CurrChar, 0, UNIT_FIELD_AURA+32);
  SetUpdateBits(Sender.CurrChar, $eeeeeeee, UNIT_FIELD_AURALEVELS+8);
  SetUpdateBits(Sender.CurrChar, $eeeeeeee, UNIT_FIELD_AURAAPPLICATIONS+8);
  SetUpdateBits(Sender.CurrChar, 0, UNIT_FIELD_AURAFLAGS+4);
  SetUpdateBits(Sender.CurrChar, 0, UNIT_FIELD_AURASTATE);

  if Sender.CurrChar.cRace = crnNightElf then begin
    //DeMorph;
    SetUpdateBits(Sender.CurrChar, Sender.CurrChar.UpdateArray[UNIT_FIELD_NATIVEDISPLAYID], UNIT_FIELD_DISPLAYID);
  end;

  // spawnbones
  //GetPlayer()->SpawnCorpseBones();

  // set health
  Sender.CurrChar.Health := Round(Sender.CurrChar.healthMaxValue * 0.5) ;
end;

procedure CMSG_WRAP_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MINIMAP_PING_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_SKILL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PING_handler(Sender: TPlayer);
var
   reply: integer;
begin
    Sender.ReceiveBuff.Get(reply);
    Sender.SendBuff.Init(SMSG_PONG);
    Sender.SendBuff.Add(reply);
    Sender.SendPacket;
end;

procedure CMSG_SETSHEATHED_handler(Sender: TPlayer);
var
  sheathed: Integer;
begin
  Sender.ReceiveBuff.Get(sheathed);

//	GetPlayer()->SetSheath(~sheathed);
end;

procedure CMSG_PLAYER_MACRO_OBSOLETE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GHOST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_INVIS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SCREENSHOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_GM_BIND_OTHER_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_GM_SUMMON_handler(Sender: TPlayer);
begin
	{}
end;

function GetRLHash(acc_name: String): boolean;
var
  buf: array of Byte;
  err_code: Integer;
begin
  try
    Result := True;
    setlength(buf, Length(acc_name)+2);
    buf[0] := $11;
    if acc_name<>'' then
       move((@acc_name[1])^,buf[1],length(acc_name)+1)
    else buf[1]:=0;
    //Add2DbyteArr(Byte(1), buf, offs);
    //Add2DbyteArr(acc_name, buf, offs);
    if Send(Sock, pchar(buf)^, length(acc_name)+2, 0) = SOCKET_ERROR then begin
      Result := False;
      err_code := WSAGetLastError ;
      if (err_code = WSAENOTCONN) or (err_code = WSAENOTSOCK) then begin
        AddToLog('!!! Not connected to LoginServ! Reconnecting...');
        ConnectToLogin;
      end;
    end;
  except
    AddToLog('!!! Error Send Hash request for ' + acc_name);
    Result := False;
  end
end;

procedure CMSG_AUTH_SESSION_handler(Sender: TPlayer);
var
   offs,i,clientSeed: integer;
   Digest,Digest2: TSHA1Digest;
   account: string;
   unk1, unk2: integer;       //, id, security
   //packet: array of byte;
   LocalPlayer: TPlayer;
   temp: array of byte;
   //same: boolean;
   LbSHA11: TLbSHA1;
begin
     Sender.ReceiveBuff.Get(unk1);
     Sender.ReceiveBuff.Get(unk2);
     Sender.ReceiveBuff.Get(account);
     Sender.ReceiveBuff.Get(clientSeed);
     Sender.ReceiveBuff.Get(@Digest,sizeof(Digest));

  i := 0;
  if not LogonEnable and GetRLHash(account) then begin //Отправляем запрос на hash-key для данного акка
    while True do begin
           if AuthPlayersHT.Contains(account) then Break;
           Application.ProcessMessages ;
      Inc(i);
      if i > 150 then begin
        AddToLog('GetRLHash timeout...') ;
        Exit;
      end;
           Sleep(20);
     end;
  end; 

     if AuthPlayersHT.Contains(account) then
     begin
          LbSHA11:=TLbSHA1.Create(Form1);
          LocalPlayer:=AuthPlayersHT[account];
          if LocalPlayer <> nil then
          begin
               //Sender.Sockt:=LocalPlayer.Sockt;
               Sender.acc_name:=LocalPlayer.acc_name;
               Sender.SS_Hash:=LocalPlayer.SS_Hash;
               if AllGM then Sender.AccessLevel := 1;

               if LoggedPlayersHT.Contains(Sender.acc_name)then LoggedPlayersHT.Remove(Sender.acc_name);
               LoggedPlayersHT.Add(Sender.acc_name,Sender);
               LoggedPlayersAccBySockHT.Remove(Sender.Sockt);
               LoggedPlayersAccBySockHT.Add(Sender.Sockt,Sender);
               setlength(temp,length(account)+length(Sender.SS_Hash)+12);
               offs:=0;
               Add2DbyteArr(account,temp,offs);
               dec(offs);
               Add2DbyteArr(integer(0),temp,offs);
               Add2DbyteArr(clientSeed,temp,offs);
               Add2DbyteArr(SEED,temp,offs);
               Add2DbyteArr(Sender.SS_Hash,temp,offs,length(Sender.SS_Hash));
               LbSHA11.HashBuffer(temp[0],length(temp));
               LbSHA11.GetDigest(Digest2);

               i:=0;//same:=true;
               while (i<length(Digest2)) do
               begin
                    if Digest[i]<>Digest2[i] then
                    with Sender.SendBuff do begin
                         //same:=false;
                         Init(SMSG_AUTH_RESPONSE);
                         Add(byte(21));
                         Sleep(50);
                         Sender.SendPacket;
                         exit;
                    end;
                    inc(i);
               end;

               {if same then
               begin
                    AddToLog('same');
               end;}
               FillChar(Sender.CrKey.key,4,0);
               Sender.CrKey.initialized:=true;

               //setlength(packet,10);
               with Sender.SendBuff do
               begin
                    Init(SMSG_AUTH_RESPONSE);
                    Add(byte($0C));   // auth succesfull, TODO: use enums
                    Add(byte($CF));   // sometime of counter.. increased by 1 at every auth
                    Add(byte($D2));
                    Add(byte($07));
                    Add(byte($00));
                    Add(byte($00));
                    Sleep(50);
                    Sender.SendPacket;
               end;
          end;
          LbSHA11.Free;
     end
     else with Sender.SendBuff do
     begin
          //setlength(packet,5);
          Init(SMSG_AUTH_RESPONSE);
          Add(byte(21));   // auth succesfull, TODO: use enums
          Sleep(50);
          Sender.SendPacket;
     end;
     temp:=nil;
end;

procedure MSG_GM_SHOWLABEL_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_ADD_DYNAMIC_TARGET_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_SAVE_GUILD_EMBLEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_TABARDVENDOR_ACTIVATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ZONEUPDATE_handler(Sender: TPlayer);
var
  NewZone, AreaFlag, XP: Integer;
  pAreaTable: PPackedAreaTable ;
begin
  Sender.ReceiveBuff.Get(NewZone);

  AddToLog('CMSG_ZONEUPDATE [' + IntToStr(NewZone) + ']');

  if SystemExploration then begin


    {if Sender.CurrChar.LastLogout <> 0 then} begin //Если мы создали чара не сейчас, получаем XP
      AreaFlag := 100 ;
      pAreaTable := AreaTableDbcHandler.GetPointerPRValueByIntKey(AreaFlag) ;
      if pAreaTable <> nil then begin
        XP := pAreaTable^.area_level * 10 ;
        Sender.CurrChar.GiveXP(XP); 

        //Пишем в лог опыт за территорию
        Sender.SendBuff.Init(SMSG_EXPLORATION_EXPERIENCE) ;
        Sender.SendBuff.Add(pAreaTable^.ID) ;
        Sender.SendBuff.Add(XP) ;
        Sender.SendPacket ;
      end;  
    end;  
  end;

//  if Sender.CurrChar.Resting then
  if (Sender.CurrChar.Flags and PLAYER_FLAGS_RESTING) = PLAYER_FLAGS_RESTING then begin
    Sender.CurrChar.Flags := Sender.CurrChar.Flags - PLAYER_FLAGS_RESTING;
    Sender.CurrChar.InitUpdateArray ;
    Sender.CurrChar.BuildSendCharUpdateBlock ;
  end;

  Sender.CurrChar.zoneId := NewZone;
end;

procedure CMSG_GM_SET_SECURITY_GROUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_NUKE_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_RANDOM_ROLL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_RWHOIS_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_LOOKING_FOR_GROUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_LOOKING_FOR_GROUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNLEARN_SPELL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNLEARN_SKILL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DECHARGE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GMTICKET_CREATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GMTICKET_UPDATETEXT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_REQUEST_ACCOUNT_DATA_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UPDATE_ACCOUNT_DATA_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_TEACH_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_CREATE_ITEM_TARGET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GMTICKET_GETTICKET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNLEARN_TALENTS_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_CORPSE_QUERY_handler(Sender: TPlayer);
begin
  with Sender.SendBuff do begin
    Init(MSG_CORPSE_QUERY);
    Add(Byte(1));
    Add(Integer(1));
    Add(Sender.CurrChar.Corpse.positionX);
    Add(Sender.CurrChar.Corpse.positionY);
    Add(Sender.CurrChar.Corpse.positionZ);
    Add(Integer(1));
    Sender.SendPacket;
  end;
end;

procedure CMSG_GMTICKET_DELETETICKET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GMTICKET_SYSTEMSTATUS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SPIRIT_HEALER_ACTIVATE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_STAT_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SKILL_BUY_STEP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SKILL_BUY_RANK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_XP_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHARACTER_POINT_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CHAT_IGNORED_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_VISION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SERVER_COMMAND_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_SILENCE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_REVEALTO_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_RESURRECT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_SUMMONMOB_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_MOVECORPSE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_FREEZE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_UBERINVIS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GM_REQUEST_PLAYER_INFO_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_RANK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_ADD_RANK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_DEL_RANK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_SET_PUBLIC_NOTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GUILD_SET_OFFICER_NOTE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CLEAR_EXPLORATION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BATTLEFIELD_LIST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BATTLEFIELD_JOIN_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXICLEARNODE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TAXIENABLENODE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LEARN_TALENT_handler(Sender: TPlayer);
var
  talent_id, requested_rank, CurTalentPoints, spellid: Integer;
  pTalent: PPackedTalent;
begin
  Sender.ReceiveBuff.Get(talent_id);
  Sender.ReceiveBuff.Get(requested_rank);

  //AddToLog('CMSG_LEARN_TALENT ' + IntToStr(talent_id) + ' ' + IntToStr(requested_rank));

  pTalent := TalentDbcHandler.GetPointerPRValueByIntKey(talent_id) ;
  if pTalent = nil then Exit;

  CurTalentPoints := Sender.CurrChar.UpdateArray[PLAYER_CHARACTER_POINTS1];
  if CurTalentPoints <> 0 then begin
    spellid := pTalent^.RankID[requested_rank];
    if spellid <> 0 then begin
//    if (!(GetPlayer( )->HasSpell(spellid)))  begin
        Sender.SendBuff.Init(SMSG_LEARNED_SPELL);
        Sender.SendBuff.Add(spellid);
        Sender.SendPacket;
        Sender.CurrChar.AddSpell(spellid);

        if requested_rank > 0 then begin
          spellid := pTalent^.RankID[requested_rank - 1];
          Sender.SendBuff.Init(SMSG_REMOVED_SPELL);
          Sender.SendBuff.Add(spellid);
          Sender.SendPacket;
//        GetPlayer( )->removeSpell((uint16)respellid);
        end;
//    end;
      SetUpdateBits(Sender.CurrChar, CurTalentPoints - 1, PLAYER_CHARACTER_POINTS1);
      Sender.CurrChar.BuildSendCharUpdateBlock ; 
    end;
  end;
end;

procedure CMSG_ENABLE_PVP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_AMMO_handler(Sender: TPlayer);
var
  ammo_id: integer;
begin
	Sender.ReceiveBuff.Get(ammo_id);
  AddToLog('CMSG_SET_AMMO ' + IntToStr(ammo_id));
  Sender.CurrChar.ammoId := ammo_id;
  SetUpdateBits(Sender.CurrChar,ammo_id,PLAYER_AMMO_ID);
  Sender.CurrChar.BuildSendCharUpdateBlock;
end;

procedure CMSG_SET_ACTIVE_MOVER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PET_CANCEL_AURA_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_PLAYER_AI_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CANCEL_AUTO_REPEAT_SPELL_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_GM_ACCOUNT_ONLINE_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_LIST_STABLED_PETS_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_STABLE_PET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_UNSTABLE_PET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BUY_STABLE_SLOT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_STABLE_REVIVE_PET_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_STABLE_SWAP_PET_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_QUEST_PUSH_RESULT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_REQUEST_PET_INFO_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_FAR_SIGHT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ENABLE_DAMAGE_LOG_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GROUP_CHANGE_SUB_GROUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GROUP_SWAP_SUB_GROUP_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_RESET_FACTION_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTOSTORE_BANK_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_AUTOBANK_ITEM_handler(Sender: TPlayer);
var
  Bag, Slot: Byte;
  Item: TItem;
begin
  Sender.ReceiveBuff.Get(Bag);
  Sender.ReceiveBuff.Get(Slot);

	Item := Sender.CurrChar.GetBagItem(Bag, Slot);  

	if Item <> nil then begin
    SwapFailedResponce(Sender, EQUIP_ERR_ITEMS_CANT_BE_SWAPPED, Item);
 	  //result = GetPlayer()->AddItemToBank(0, NULL_SLOT, pItem, true, true, true);
    //GetPlayer()->RemoveItemFromSlot(bagIndex, slot);
  	//GetPlayer()->AddItemToBank(0, NULL_SLOT, pItem, true, false, false);
  end;
end;

procedure CMSG_SET_DURABILITY_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_PVP_RANK_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ADD_PVP_MEDAL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_DEL_PVP_MEDAL_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_PVP_TITLE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GROUP_RAID_CONVERT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GROUP_ASSISTANT_LEADER_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BUYBACK_ITEM_handler(Sender: TPlayer);
var
  vendorguid: Int64;
  buybackslot, slot, newmoney: Integer;
  BuybackItem: TItem;
begin
  Sender.ReceiveBuff.Get(vendorguid);
  Sender.ReceiveBuff.Get(buybackslot); //start slot is (69 0x45) end slot is 0x45+12

	//AddToLog('CMSG_BUYBACK_ITEM [' + IntToStr(vendorguid) + '][' + IntToStr(buybackslot) + ']');

  slot := buybackslot - $45 ;

	BuybackItem := Sender.CurrChar.m_buybackitems[slot];                    
	if buybackItem <> nil then begin
    newmoney := Sender.CurrChar.copper - (BuybackItem.PItemRecord^.SellPrice) * BuybackItem.item_count ;
		if newmoney < 0 then
    with Sender.SendBuff do
    begin
      Init(SMSG_BUY_FAILED);
      Add(BuybackItem.objGUID);
      Add(BuybackItem.ID);
      Add(Byte(2));
      Sender.SendPacket;
	   	Exit;
    end;
    
  	if Sender.CurrChar.AddItem(buybackItem, Sender.CurrChar.GetInvFreeSlot) then begin
	  	Sender.CurrChar.SetCopper(newmoney);
	   	Sender.CurrChar.RemoveItemFromBuyBackSlot(slot);
    end;
	end;
end;

procedure CMSG_MEETING_STONE_JOIN_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MEETING_STONE_LEAVE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MEETING_STONE_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MEETING_STONE_INFO_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_GMTICKETSYSTEM_TOGGLE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_CANCEL_GROWTH_AURA_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LOOT_ROLL_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_LOOT_MASTER_GIVE_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_REPAIR_ITEM_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_TALENT_WIPE_CONFIRM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SUMMON_RESPONSE_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_TOGGLE_GRAVITY_CHEAT_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_FEATHER_FALL_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_MOVE_WATER_WALK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SERVER_BROADCAST_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SELF_RES_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_RUN_SCRIPT_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TOGGLE_HELM_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_TOGGLE_CLOAK_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_EXPLORATION_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_SET_ACTIONBAR_TOGGLES_handler(Sender: TPlayer);
begin
	{}
end;

procedure UMSG_DELETE_GUILD_CHARTER_handler(Sender: TPlayer);
begin
	{}
end;

procedure MSG_PETITION_RENAME_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_ITEM_NAME_QUERY_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_MOVE_TIME_SKIPPED_handler(Sender: TPlayer);
begin
	{}
end;

procedure CMSG_BATTLEFIELD_STATUS_handler(Sender: TPlayer);
begin
	{}
end;


initialization

  InitializeCriticalSection(CriticalSection);
  for msg_cntr:=0 to pred(length(OpCodeHandleTable))do
	     @OpCodeHandleTable[msg_cntr] := @MSG_NULL_ACTION_handler;

	@OpCodeHandleTable[MSG_NULL_ACTION] := @MSG_NULL_ACTION_handler;
	@OpCodeHandleTable[CMSG_BOOTME] := @CMSG_BOOTME_handler;
	@OpCodeHandleTable[CMSG_DBLOOKUP] := @CMSG_DBLOOKUP_handler;
	@OpCodeHandleTable[CMSG_QUERY_OBJECT_POSITION] := @CMSG_QUERY_OBJECT_POSITION_handler;
	@OpCodeHandleTable[CMSG_QUERY_OBJECT_ROTATION] := @CMSG_QUERY_OBJECT_ROTATION_handler;
	@OpCodeHandleTable[CMSG_WORLD_TELEPORT] := @CMSG_WORLD_TELEPORT_handler;
	@OpCodeHandleTable[CMSG_TELEPORT_TO_UNIT] := @CMSG_TELEPORT_TO_UNIT_handler;
	@OpCodeHandleTable[CMSG_ZONE_MAP] := @CMSG_ZONE_MAP_handler;
	@OpCodeHandleTable[CMSG_DEBUG_CHANGECELLZONE] := @CMSG_DEBUG_CHANGECELLZONE_handler;
	@OpCodeHandleTable[CMSG_EMBLAZON_TABARD_OBSOLETE] := @CMSG_EMBLAZON_TABARD_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_UNEMBLAZON_TABARD_OBSOLETE] := @CMSG_UNEMBLAZON_TABARD_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_RECHARGE] := @CMSG_RECHARGE_handler;
	@OpCodeHandleTable[CMSG_LEARN_SPELL] := @CMSG_LEARN_SPELL_handler;
	@OpCodeHandleTable[CMSG_CREATEMONSTER] := @CMSG_CREATEMONSTER_handler;
	@OpCodeHandleTable[CMSG_DESTROYMONSTER] := @CMSG_DESTROYMONSTER_handler;
	@OpCodeHandleTable[CMSG_CREATEITEM] := @CMSG_CREATEITEM_handler;
	@OpCodeHandleTable[CMSG_CREATEGAMEOBJECT] := @CMSG_CREATEGAMEOBJECT_handler;
	@OpCodeHandleTable[CMSG_MAKEMONSTERATTACKME] := @CMSG_MAKEMONSTERATTACKME_handler;
	@OpCodeHandleTable[CMSG_MAKEMONSTERATTACKGUID] := @CMSG_MAKEMONSTERATTACKGUID_handler;
	@OpCodeHandleTable[CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE] := @CMSG_ENABLEDEBUGCOMBATLOGGING_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_FORCEACTION] := @CMSG_FORCEACTION_handler;
	@OpCodeHandleTable[CMSG_FORCEACTIONONOTHER] := @CMSG_FORCEACTIONONOTHER_handler;
	@OpCodeHandleTable[CMSG_FORCEACTIONSHOW] := @CMSG_FORCEACTIONSHOW_handler;
	@OpCodeHandleTable[CMSG_UNDRESSPLAYER] := @CMSG_UNDRESSPLAYER_handler;
	@OpCodeHandleTable[CMSG_BEASTMASTER] := @CMSG_BEASTMASTER_handler;
	@OpCodeHandleTable[CMSG_GODMODE] := @CMSG_GODMODE_handler;
	@OpCodeHandleTable[CMSG_CHEAT_SETMONEY] := @CMSG_CHEAT_SETMONEY_handler;
	@OpCodeHandleTable[CMSG_LEVEL_CHEAT] := @CMSG_LEVEL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_PET_LEVEL_CHEAT] := @CMSG_PET_LEVEL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_LEVELUP_CHEAT_OBSOLETE] := @CMSG_LEVELUP_CHEAT_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_COOLDOWN_CHEAT] := @CMSG_COOLDOWN_CHEAT_handler;
	@OpCodeHandleTable[CMSG_USE_SKILL_CHEAT] := @CMSG_USE_SKILL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_FLAG_QUEST] := @CMSG_FLAG_QUEST_handler;
	@OpCodeHandleTable[CMSG_FLAG_QUEST_FINISH] := @CMSG_FLAG_QUEST_FINISH_handler;
	@OpCodeHandleTable[CMSG_CLEAR_QUEST] := @CMSG_CLEAR_QUEST_handler;
	@OpCodeHandleTable[CMSG_SEND_EVENT] := @CMSG_SEND_EVENT_handler;
	@OpCodeHandleTable[CMSG_DEBUG_AISTATE] := @CMSG_DEBUG_AISTATE_handler;
	@OpCodeHandleTable[CMSG_DISABLE_PVP_CHEAT] := @CMSG_DISABLE_PVP_CHEAT_handler;
	@OpCodeHandleTable[CMSG_ADVANCE_SPAWN_TIME] := @CMSG_ADVANCE_SPAWN_TIME_handler;
	@OpCodeHandleTable[CMSG_PVP_PORT_OBSOLETE] := @CMSG_PVP_PORT_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_AUTH_SRP6_BEGIN] := @CMSG_AUTH_SRP6_BEGIN_handler;
	@OpCodeHandleTable[CMSG_AUTH_SRP6_PROOF] := @CMSG_AUTH_SRP6_PROOF_handler;
	@OpCodeHandleTable[CMSG_AUTH_SRP6_RECODE] := @CMSG_AUTH_SRP6_RECODE_handler;
	@OpCodeHandleTable[CMSG_CHAR_CREATE] := @CMSG_CHAR_CREATE_handler;
	@OpCodeHandleTable[CMSG_CHAR_ENUM] := @CMSG_CHAR_ENUM_handler;
	@OpCodeHandleTable[CMSG_CHAR_DELETE] := @CMSG_CHAR_DELETE_handler;
	@OpCodeHandleTable[CMSG_PLAYER_LOGIN] := @CMSG_PLAYER_LOGIN_handler;
	@OpCodeHandleTable[CMSG_GAMETIME_SET] := @CMSG_GAMETIME_SET_handler;
	@OpCodeHandleTable[CMSG_GAMESPEED_SET] := @CMSG_GAMESPEED_SET_handler;
	@OpCodeHandleTable[CMSG_SERVERTIME] := @CMSG_SERVERTIME_handler;
	@OpCodeHandleTable[CMSG_PLAYER_LOGOUT] := @CMSG_PLAYER_LOGOUT_handler;
	@OpCodeHandleTable[CMSG_LOGOUT_REQUEST] := @CMSG_LOGOUT_REQUEST_handler;
	@OpCodeHandleTable[CMSG_LOGOUT_CANCEL] := @CMSG_LOGOUT_CANCEL_handler;
	@OpCodeHandleTable[CMSG_NAME_QUERY] := @CMSG_NAME_QUERY_handler;
	@OpCodeHandleTable[CMSG_PET_NAME_QUERY] := @CMSG_PET_NAME_QUERY_handler;
	@OpCodeHandleTable[CMSG_GUILD_QUERY] := @CMSG_GUILD_QUERY_handler;
	@OpCodeHandleTable[CMSG_ITEM_QUERY_SINGLE] := @CMSG_ITEM_QUERY_SINGLE_handler;
	@OpCodeHandleTable[CMSG_ITEM_QUERY_MULTIPLE] := @CMSG_ITEM_QUERY_MULTIPLE_handler;
	@OpCodeHandleTable[CMSG_PAGE_TEXT_QUERY] := @CMSG_PAGE_TEXT_QUERY_handler;
	@OpCodeHandleTable[CMSG_QUEST_QUERY] := @CMSG_QUEST_QUERY_handler;
	@OpCodeHandleTable[CMSG_GAMEOBJECT_QUERY] := @CMSG_GAMEOBJECT_QUERY_handler;
	@OpCodeHandleTable[CMSG_CREATURE_QUERY] := @CMSG_CREATURE_QUERY_handler;
	@OpCodeHandleTable[CMSG_WHO] := @CMSG_WHO_handler;
	@OpCodeHandleTable[CMSG_WHOIS] := @CMSG_WHOIS_handler;
	@OpCodeHandleTable[CMSG_FRIEND_LIST] := @CMSG_FRIEND_LIST_handler;
	@OpCodeHandleTable[CMSG_ADD_FRIEND] := @CMSG_ADD_FRIEND_handler;
	@OpCodeHandleTable[CMSG_DEL_FRIEND] := @CMSG_DEL_FRIEND_handler;
	@OpCodeHandleTable[CMSG_ADD_IGNORE] := @CMSG_ADD_IGNORE_handler;
	@OpCodeHandleTable[CMSG_DEL_IGNORE] := @CMSG_DEL_IGNORE_handler;
	@OpCodeHandleTable[CMSG_GROUP_INVITE] := @CMSG_GROUP_INVITE_handler;
	@OpCodeHandleTable[CMSG_GROUP_CANCEL] := @CMSG_GROUP_CANCEL_handler;
	@OpCodeHandleTable[CMSG_GROUP_ACCEPT] := @CMSG_GROUP_ACCEPT_handler;
	@OpCodeHandleTable[CMSG_GROUP_DECLINE] := @CMSG_GROUP_DECLINE_handler;
	@OpCodeHandleTable[CMSG_GROUP_UNINVITE] := @CMSG_GROUP_UNINVITE_handler;
	@OpCodeHandleTable[CMSG_GROUP_UNINVITE_GUID] := @CMSG_GROUP_UNINVITE_GUID_handler;
	@OpCodeHandleTable[CMSG_GROUP_SET_LEADER] := @CMSG_GROUP_SET_LEADER_handler;
	@OpCodeHandleTable[CMSG_LOOT_METHOD] := @CMSG_LOOT_METHOD_handler;
	@OpCodeHandleTable[CMSG_GROUP_DISBAND] := @CMSG_GROUP_DISBAND_handler;
	@OpCodeHandleTable[UMSG_UPDATE_GROUP_MEMBERS] := @UMSG_UPDATE_GROUP_MEMBERS_handler;
	@OpCodeHandleTable[CMSG_GUILD_CREATE] := @CMSG_GUILD_CREATE_handler;
	@OpCodeHandleTable[CMSG_GUILD_INVITE] := @CMSG_GUILD_INVITE_handler;
	@OpCodeHandleTable[CMSG_GUILD_ACCEPT] := @CMSG_GUILD_ACCEPT_handler;
	@OpCodeHandleTable[CMSG_GUILD_DECLINE] := @CMSG_GUILD_DECLINE_handler;
	@OpCodeHandleTable[CMSG_GUILD_INFO] := @CMSG_GUILD_INFO_handler;
	@OpCodeHandleTable[CMSG_GUILD_ROSTER] := @CMSG_GUILD_ROSTER_handler;
	@OpCodeHandleTable[CMSG_GUILD_PROMOTE] := @CMSG_GUILD_PROMOTE_handler;
	@OpCodeHandleTable[CMSG_GUILD_DEMOTE] := @CMSG_GUILD_DEMOTE_handler;
	@OpCodeHandleTable[CMSG_GUILD_LEAVE] := @CMSG_GUILD_LEAVE_handler;
	@OpCodeHandleTable[CMSG_GUILD_REMOVE] := @CMSG_GUILD_REMOVE_handler;
	@OpCodeHandleTable[CMSG_GUILD_DISBAND] := @CMSG_GUILD_DISBAND_handler;
	@OpCodeHandleTable[CMSG_GUILD_LEADER] := @CMSG_GUILD_LEADER_handler;
	@OpCodeHandleTable[CMSG_GUILD_MOTD] := @CMSG_GUILD_MOTD_handler;
	@OpCodeHandleTable[UMSG_UPDATE_GUILD] := @UMSG_UPDATE_GUILD_handler;
	@OpCodeHandleTable[CMSG_MESSAGECHAT] := @CMSG_MESSAGECHAT_handler;
	@OpCodeHandleTable[CMSG_JOIN_CHANNEL] := @CMSG_JOIN_CHANNEL_handler;
	@OpCodeHandleTable[CMSG_LEAVE_CHANNEL] := @CMSG_LEAVE_CHANNEL_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_LIST] := @CMSG_CHANNEL_LIST_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_PASSWORD] := @CMSG_CHANNEL_PASSWORD_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_SET_OWNER] := @CMSG_CHANNEL_SET_OWNER_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_OWNER] := @CMSG_CHANNEL_OWNER_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_MODERATOR] := @CMSG_CHANNEL_MODERATOR_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_UNMODERATOR] := @CMSG_CHANNEL_UNMODERATOR_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_MUTE] := @CMSG_CHANNEL_MUTE_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_UNMUTE] := @CMSG_CHANNEL_UNMUTE_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_INVITE] := @CMSG_CHANNEL_INVITE_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_KICK] := @CMSG_CHANNEL_KICK_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_BAN] := @CMSG_CHANNEL_BAN_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_UNBAN] := @CMSG_CHANNEL_UNBAN_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_ANNOUNCEMENTS] := @CMSG_CHANNEL_ANNOUNCEMENTS_handler;
	@OpCodeHandleTable[CMSG_CHANNEL_MODERATE] := @CMSG_CHANNEL_MODERATE_handler;
	@OpCodeHandleTable[CMSG_USE_ITEM] := @CMSG_USE_ITEM_handler;
	@OpCodeHandleTable[CMSG_OPEN_ITEM] := @CMSG_OPEN_ITEM_handler;
	@OpCodeHandleTable[CMSG_READ_ITEM] := @CMSG_READ_ITEM_handler;
	@OpCodeHandleTable[CMSG_GAMEOBJ_USE] := @CMSG_GAMEOBJ_USE_handler;
	@OpCodeHandleTable[CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE] := @CMSG_GAMEOBJ_CHAIR_USE_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_AREATRIGGER] := @CMSG_AREATRIGGER_handler;
	@OpCodeHandleTable[MSG_MOVE_START_FORWARD] := @MSG_MOVE_START_FORWARD_handler;
	@OpCodeHandleTable[MSG_MOVE_START_BACKWARD] := @MSG_MOVE_START_BACKWARD_handler;
	@OpCodeHandleTable[MSG_MOVE_STOP] := @MSG_MOVE_STOP_handler;
	@OpCodeHandleTable[MSG_MOVE_START_STRAFE_LEFT] := @MSG_MOVE_START_STRAFE_LEFT_handler;
	@OpCodeHandleTable[MSG_MOVE_START_STRAFE_RIGHT] := @MSG_MOVE_START_STRAFE_RIGHT_handler;
	@OpCodeHandleTable[MSG_MOVE_STOP_STRAFE] := @MSG_MOVE_STOP_STRAFE_handler;
	@OpCodeHandleTable[MSG_MOVE_JUMP] := @MSG_MOVE_JUMP_handler;
	@OpCodeHandleTable[MSG_MOVE_START_TURN_LEFT] := @MSG_MOVE_START_TURN_LEFT_handler;
	@OpCodeHandleTable[MSG_MOVE_START_TURN_RIGHT] := @MSG_MOVE_START_TURN_RIGHT_handler;
	@OpCodeHandleTable[MSG_MOVE_STOP_TURN] := @MSG_MOVE_STOP_TURN_handler;
	@OpCodeHandleTable[MSG_MOVE_START_PITCH_UP] := @MSG_MOVE_START_PITCH_UP_handler;
	@OpCodeHandleTable[MSG_MOVE_START_PITCH_DOWN] := @MSG_MOVE_START_PITCH_DOWN_handler;
	@OpCodeHandleTable[MSG_MOVE_STOP_PITCH] := @MSG_MOVE_STOP_PITCH_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RUN_MODE] := @MSG_MOVE_SET_RUN_MODE_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_WALK_MODE] := @MSG_MOVE_SET_WALK_MODE_handler;
	@OpCodeHandleTable[MSG_MOVE_TOGGLE_LOGGING] := @MSG_MOVE_TOGGLE_LOGGING_handler;
	@OpCodeHandleTable[MSG_MOVE_TELEPORT] := @MSG_MOVE_TELEPORT_handler;
	@OpCodeHandleTable[MSG_MOVE_TELEPORT_CHEAT] := @MSG_MOVE_TELEPORT_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_TELEPORT_ACK] := @MSG_MOVE_TELEPORT_ACK_handler;
	@OpCodeHandleTable[MSG_MOVE_TOGGLE_FALL_LOGGING] := @MSG_MOVE_TOGGLE_FALL_LOGGING_handler;
	@OpCodeHandleTable[MSG_MOVE_FALL_LAND] := @MSG_MOVE_FALL_LAND_handler;
	@OpCodeHandleTable[MSG_MOVE_START_SWIM] := @MSG_MOVE_START_SWIM_handler;
	@OpCodeHandleTable[MSG_MOVE_STOP_SWIM] := @MSG_MOVE_STOP_SWIM_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RUN_SPEED_CHEAT] := @MSG_MOVE_SET_RUN_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RUN_SPEED] := @MSG_MOVE_SET_RUN_SPEED_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT] := @MSG_MOVE_SET_RUN_BACK_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RUN_BACK_SPEED] := @MSG_MOVE_SET_RUN_BACK_SPEED_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_WALK_SPEED_CHEAT] := @MSG_MOVE_SET_WALK_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_WALK_SPEED] := @MSG_MOVE_SET_WALK_SPEED_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_SWIM_SPEED_CHEAT] := @MSG_MOVE_SET_SWIM_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_SWIM_SPEED] := @MSG_MOVE_SET_SWIM_SPEED_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT] := @MSG_MOVE_SET_SWIM_BACK_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_SWIM_BACK_SPEED] := @MSG_MOVE_SET_SWIM_BACK_SPEED_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_ALL_SPEED_CHEAT] := @MSG_MOVE_SET_ALL_SPEED_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_TURN_RATE_CHEAT] := @MSG_MOVE_SET_TURN_RATE_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_TURN_RATE] := @MSG_MOVE_SET_TURN_RATE_handler;
	@OpCodeHandleTable[MSG_MOVE_TOGGLE_COLLISION_CHEAT] := @MSG_MOVE_TOGGLE_COLLISION_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_FACING] := @MSG_MOVE_SET_FACING_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_PITCH] := @MSG_MOVE_SET_PITCH_handler;
	@OpCodeHandleTable[MSG_MOVE_WORLDPORT_ACK] := @MSG_MOVE_WORLDPORT_ACK_handler;
	@OpCodeHandleTable[MSG_MOVE_SET_RAW_POSITION_ACK] := @MSG_MOVE_SET_RAW_POSITION_ACK_handler;
	@OpCodeHandleTable[CMSG_MOVE_SET_RAW_POSITION] := @CMSG_MOVE_SET_RAW_POSITION_handler;
	@OpCodeHandleTable[CMSG_FORCE_RUN_SPEED_CHANGE_ACK] := @CMSG_FORCE_RUN_SPEED_CHANGE_ACK_handler;
	@OpCodeHandleTable[CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK] := @CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK_handler;
	@OpCodeHandleTable[CMSG_FORCE_SWIM_SPEED_CHANGE_ACK] := @CMSG_FORCE_SWIM_SPEED_CHANGE_ACK_handler;
	@OpCodeHandleTable[CMSG_FORCE_MOVE_ROOT_ACK] := @CMSG_FORCE_MOVE_ROOT_ACK_handler;
	@OpCodeHandleTable[CMSG_FORCE_MOVE_UNROOT_ACK] := @CMSG_FORCE_MOVE_UNROOT_ACK_handler;
	@OpCodeHandleTable[MSG_MOVE_ROOT] := @MSG_MOVE_ROOT_handler;
	@OpCodeHandleTable[MSG_MOVE_UNROOT] := @MSG_MOVE_UNROOT_handler;
	@OpCodeHandleTable[MSG_MOVE_HEARTBEAT] := @MSG_MOVE_HEARTBEAT_handler;
	@OpCodeHandleTable[CMSG_MOVE_KNOCK_BACK_ACK] := @CMSG_MOVE_KNOCK_BACK_ACK_handler;
	@OpCodeHandleTable[MSG_MOVE_KNOCK_BACK] := @MSG_MOVE_KNOCK_BACK_handler;
	@OpCodeHandleTable[CMSG_MOVE_HOVER_ACK] := @CMSG_MOVE_HOVER_ACK_handler;
	@OpCodeHandleTable[MSG_MOVE_HOVER] := @MSG_MOVE_HOVER_handler;
	@OpCodeHandleTable[CMSG_TRIGGER_CINEMATIC_CHEAT] := @CMSG_TRIGGER_CINEMATIC_CHEAT_handler;
	@OpCodeHandleTable[CMSG_OPENING_CINEMATIC] := @CMSG_OPENING_CINEMATIC_handler;
	@OpCodeHandleTable[CMSG_NEXT_CINEMATIC_CAMERA] := @CMSG_NEXT_CINEMATIC_CAMERA_handler;
	@OpCodeHandleTable[CMSG_COMPLETE_CINEMATIC] := @CMSG_COMPLETE_CINEMATIC_handler;
	@OpCodeHandleTable[CMSG_TUTORIAL_FLAG] := @CMSG_TUTORIAL_FLAG_handler;
	@OpCodeHandleTable[CMSG_TUTORIAL_CLEAR] := @CMSG_TUTORIAL_CLEAR_handler;
	@OpCodeHandleTable[CMSG_TUTORIAL_RESET] := @CMSG_TUTORIAL_RESET_handler;
	@OpCodeHandleTable[CMSG_STANDSTATECHANGE] := @CMSG_STANDSTATECHANGE_handler;
	@OpCodeHandleTable[CMSG_EMOTE] := @CMSG_EMOTE_handler;
	@OpCodeHandleTable[CMSG_TEXT_EMOTE] := @CMSG_TEXT_EMOTE_handler;
	@OpCodeHandleTable[CMSG_AUTOEQUIP_GROUND_ITEM] := @CMSG_AUTOEQUIP_GROUND_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUTOSTORE_GROUND_ITEM] := @CMSG_AUTOSTORE_GROUND_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUTOSTORE_LOOT_ITEM] := @CMSG_AUTOSTORE_LOOT_ITEM_handler;
	@OpCodeHandleTable[CMSG_STORE_LOOT_IN_SLOT] := @CMSG_STORE_LOOT_IN_SLOT_handler;
	@OpCodeHandleTable[CMSG_AUTOEQUIP_ITEM] := @CMSG_AUTOEQUIP_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUTOSTORE_BAG_ITEM] := @CMSG_AUTOSTORE_BAG_ITEM_handler;
	@OpCodeHandleTable[CMSG_SWAP_ITEM] := @CMSG_SWAP_ITEM_handler;
	@OpCodeHandleTable[CMSG_SWAP_INV_ITEM] := @CMSG_SWAP_INV_ITEM_handler;
	@OpCodeHandleTable[CMSG_SPLIT_ITEM] := @CMSG_SPLIT_ITEM_handler;
	@OpCodeHandleTable[CMSG_PICKUP_ITEM] := @CMSG_PICKUP_ITEM_handler;
	@OpCodeHandleTable[CMSG_DROP_ITEM] := @CMSG_DROP_ITEM_handler;
	@OpCodeHandleTable[CMSG_DESTROYITEM] := @CMSG_DESTROYITEM_handler;
	@OpCodeHandleTable[CMSG_INSPECT] := @CMSG_INSPECT_handler;
	@OpCodeHandleTable[CMSG_INITIATE_TRADE] := @CMSG_INITIATE_TRADE_handler;
	@OpCodeHandleTable[CMSG_BEGIN_TRADE] := @CMSG_BEGIN_TRADE_handler;
	@OpCodeHandleTable[CMSG_BUSY_TRADE] := @CMSG_BUSY_TRADE_handler;
	@OpCodeHandleTable[CMSG_IGNORE_TRADE] := @CMSG_IGNORE_TRADE_handler;
	@OpCodeHandleTable[CMSG_ACCEPT_TRADE] := @CMSG_ACCEPT_TRADE_handler;
	@OpCodeHandleTable[CMSG_UNACCEPT_TRADE] := @CMSG_UNACCEPT_TRADE_handler;
	@OpCodeHandleTable[CMSG_CANCEL_TRADE] := @CMSG_CANCEL_TRADE_handler;
	@OpCodeHandleTable[CMSG_SET_TRADE_ITEM] := @CMSG_SET_TRADE_ITEM_handler;
	@OpCodeHandleTable[CMSG_CLEAR_TRADE_ITEM] := @CMSG_CLEAR_TRADE_ITEM_handler;
	@OpCodeHandleTable[CMSG_SET_TRADE_GOLD] := @CMSG_SET_TRADE_GOLD_handler;
	@OpCodeHandleTable[CMSG_SET_FACTION_ATWAR] := @CMSG_SET_FACTION_ATWAR_handler;
	@OpCodeHandleTable[CMSG_SET_FACTION_CHEAT] := @CMSG_SET_FACTION_CHEAT_handler;
	@OpCodeHandleTable[CMSG_SET_ACTION_BUTTON] := @CMSG_SET_ACTION_BUTTON_handler;
	@OpCodeHandleTable[CMSG_NEW_SPELL_SLOT] := @CMSG_NEW_SPELL_SLOT_handler;
	@OpCodeHandleTable[CMSG_CAST_SPELL] := @CMSG_CAST_SPELL_handler;
	@OpCodeHandleTable[CMSG_CANCEL_CAST] := @CMSG_CANCEL_CAST_handler;
	@OpCodeHandleTable[CMSG_CANCEL_AURA] := @CMSG_CANCEL_AURA_handler;
	@OpCodeHandleTable[MSG_CHANNEL_START] := @MSG_CHANNEL_START_handler;
	@OpCodeHandleTable[MSG_CHANNEL_UPDATE] := @MSG_CHANNEL_UPDATE_handler;
	@OpCodeHandleTable[CMSG_CANCEL_CHANNELLING] := @CMSG_CANCEL_CHANNELLING_handler;
	@OpCodeHandleTable[CMSG_SET_SELECTION] := @CMSG_SET_SELECTION_handler;
	@OpCodeHandleTable[CMSG_SET_TARGET] := @CMSG_SET_TARGET_handler;
	@OpCodeHandleTable[CMSG_UNUSED] := @CMSG_UNUSED_handler;
	@OpCodeHandleTable[CMSG_UNUSED2] := @CMSG_UNUSED2_handler;
	@OpCodeHandleTable[CMSG_ATTACKSWING] := @CMSG_ATTACKSWING_handler;
	@OpCodeHandleTable[CMSG_ATTACKSTOP] := @CMSG_ATTACKSTOP_handler;
	@OpCodeHandleTable[CMSG_SHEATHE_OBSOLETE] := @CMSG_SHEATHE_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_SAVE_PLAYER] := @CMSG_SAVE_PLAYER_handler;
	@OpCodeHandleTable[CMSG_SETDEATHBINDPOINT] := @CMSG_SETDEATHBINDPOINT_handler;
	@OpCodeHandleTable[CMSG_GETDEATHBINDZONE] := @CMSG_GETDEATHBINDZONE_handler;
	@OpCodeHandleTable[CMSG_REPOP_REQUEST] := @CMSG_REPOP_REQUEST_handler;
	@OpCodeHandleTable[CMSG_RESURRECT_RESPONSE] := @CMSG_RESURRECT_RESPONSE_handler;
	@OpCodeHandleTable[CMSG_LOOT] := @CMSG_LOOT_handler;
	@OpCodeHandleTable[CMSG_LOOT_MONEY] := @CMSG_LOOT_MONEY_handler;
	@OpCodeHandleTable[CMSG_LOOT_RELEASE] := @CMSG_LOOT_RELEASE_handler;
	@OpCodeHandleTable[CMSG_DUEL_ACCEPTED] := @CMSG_DUEL_ACCEPTED_handler;
	@OpCodeHandleTable[CMSG_DUEL_CANCELLED] := @CMSG_DUEL_CANCELLED_handler;
	@OpCodeHandleTable[CMSG_MOUNTSPECIAL_ANIM] := @CMSG_MOUNTSPECIAL_ANIM_handler;
	@OpCodeHandleTable[CMSG_PET_SET_ACTION] := @CMSG_PET_SET_ACTION_handler;
	@OpCodeHandleTable[CMSG_PET_ACTION] := @CMSG_PET_ACTION_handler;
	@OpCodeHandleTable[CMSG_PET_ABANDON] := @CMSG_PET_ABANDON_handler;
	@OpCodeHandleTable[CMSG_PET_RENAME] := @CMSG_PET_RENAME_handler;
	@OpCodeHandleTable[CMSG_PET_CAST_SPELL_OBSOLETE] := @CMSG_PET_CAST_SPELL_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_GOSSIP_HELLO] := @CMSG_GOSSIP_HELLO_handler;
	@OpCodeHandleTable[CMSG_GOSSIP_SELECT_OPTION] := @CMSG_GOSSIP_SELECT_OPTION_handler;
	@OpCodeHandleTable[CMSG_NPC_TEXT_QUERY] := @CMSG_NPC_TEXT_QUERY_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_STATUS_QUERY] := @CMSG_QUESTGIVER_STATUS_QUERY_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_HELLO] := @CMSG_QUESTGIVER_HELLO_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_QUERY_QUEST] := @CMSG_QUESTGIVER_QUERY_QUEST_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_QUEST_AUTOLAUNCH] := @CMSG_QUESTGIVER_QUEST_AUTOLAUNCH_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_ACCEPT_QUEST] := @CMSG_QUESTGIVER_ACCEPT_QUEST_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_COMPLETE_QUEST] := @CMSG_QUESTGIVER_COMPLETE_QUEST_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_REQUEST_REWARD] := @CMSG_QUESTGIVER_REQUEST_REWARD_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_CHOOSE_REWARD] := @CMSG_QUESTGIVER_CHOOSE_REWARD_handler;
	@OpCodeHandleTable[CMSG_QUESTGIVER_CANCEL] := @CMSG_QUESTGIVER_CANCEL_handler;
	@OpCodeHandleTable[CMSG_QUESTLOG_SWAP_QUEST] := @CMSG_QUESTLOG_SWAP_QUEST_handler;
	@OpCodeHandleTable[CMSG_QUESTLOG_REMOVE_QUEST] := @CMSG_QUESTLOG_REMOVE_QUEST_handler;
	@OpCodeHandleTable[CMSG_QUEST_CONFIRM_ACCEPT] := @CMSG_QUEST_CONFIRM_ACCEPT_handler;
	@OpCodeHandleTable[CMSG_PUSHQUESTTOPARTY] := @CMSG_PUSHQUESTTOPARTY_handler;
	@OpCodeHandleTable[CMSG_LIST_INVENTORY] := @CMSG_LIST_INVENTORY_handler;
	@OpCodeHandleTable[CMSG_SELL_ITEM] := @CMSG_SELL_ITEM_handler;
	@OpCodeHandleTable[CMSG_BUY_ITEM] := @CMSG_BUY_ITEM_handler;
	@OpCodeHandleTable[CMSG_BUY_ITEM_IN_SLOT] := @CMSG_BUY_ITEM_IN_SLOT_handler;
	@OpCodeHandleTable[CMSG_TAXICLEARALLNODES] := @CMSG_TAXICLEARALLNODES_handler;
	@OpCodeHandleTable[CMSG_TAXIENABLEALLNODES] := @CMSG_TAXIENABLEALLNODES_handler;
	@OpCodeHandleTable[CMSG_TAXISHOWNODES] := @CMSG_TAXISHOWNODES_handler;
	@OpCodeHandleTable[CMSG_TAXINODE_STATUS_QUERY] := @CMSG_TAXINODE_STATUS_QUERY_handler;
	@OpCodeHandleTable[CMSG_TAXIQUERYAVAILABLENODES] := @CMSG_TAXIQUERYAVAILABLENODES_handler;
	@OpCodeHandleTable[CMSG_ACTIVATETAXI] := @CMSG_ACTIVATETAXI_handler;
	@OpCodeHandleTable[CMSG_TRAINER_LIST] := @CMSG_TRAINER_LIST_handler;
	@OpCodeHandleTable[CMSG_TRAINER_BUY_SPELL] := @CMSG_TRAINER_BUY_SPELL_handler;
	@OpCodeHandleTable[CMSG_BINDER_ACTIVATE] := @CMSG_BINDER_ACTIVATE_handler;
	@OpCodeHandleTable[CMSG_BANKER_ACTIVATE] := @CMSG_BANKER_ACTIVATE_handler;
	@OpCodeHandleTable[CMSG_BUY_BANK_SLOT] := @CMSG_BUY_BANK_SLOT_handler;
	@OpCodeHandleTable[CMSG_PETITION_SHOWLIST] := @CMSG_PETITION_SHOWLIST_handler;
	@OpCodeHandleTable[CMSG_PETITION_BUY] := @CMSG_PETITION_BUY_handler;
	@OpCodeHandleTable[CMSG_PETITION_SHOW_SIGNATURES] := @CMSG_PETITION_SHOW_SIGNATURES_handler;
	@OpCodeHandleTable[CMSG_PETITION_SIGN] := @CMSG_PETITION_SIGN_handler;
	@OpCodeHandleTable[MSG_PETITION_DECLINE] := @MSG_PETITION_DECLINE_handler;
	@OpCodeHandleTable[CMSG_OFFER_PETITION] := @CMSG_OFFER_PETITION_handler;
	@OpCodeHandleTable[CMSG_TURN_IN_PETITION] := @CMSG_TURN_IN_PETITION_handler;
	@OpCodeHandleTable[CMSG_PETITION_QUERY] := @CMSG_PETITION_QUERY_handler;
	@OpCodeHandleTable[CMSG_BUG] := @CMSG_BUG_handler;
	@OpCodeHandleTable[CMSG_PLAYED_TIME] := @CMSG_PLAYED_TIME_handler;
	@OpCodeHandleTable[CMSG_QUERY_TIME] := @CMSG_QUERY_TIME_handler;
	@OpCodeHandleTable[MSG_SPLIT_MONEY] := @MSG_SPLIT_MONEY_handler;
	@OpCodeHandleTable[CMSG_RECLAIM_CORPSE] := @CMSG_RECLAIM_CORPSE_handler;
	@OpCodeHandleTable[CMSG_WRAP_ITEM] := @CMSG_WRAP_ITEM_handler;
	@OpCodeHandleTable[MSG_MINIMAP_PING] := @MSG_MINIMAP_PING_handler;
	@OpCodeHandleTable[CMSG_SET_SKILL_CHEAT] := @CMSG_SET_SKILL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_PING] := @CMSG_PING_handler;
	@OpCodeHandleTable[CMSG_SETSHEATHED] := @CMSG_SETSHEATHED_handler;
	@OpCodeHandleTable[CMSG_PLAYER_MACRO_OBSOLETE] := @CMSG_PLAYER_MACRO_OBSOLETE_handler;
	@OpCodeHandleTable[CMSG_GHOST] := @CMSG_GHOST_handler;
	@OpCodeHandleTable[CMSG_GM_INVIS] := @CMSG_GM_INVIS_handler;
	@OpCodeHandleTable[CMSG_SCREENSHOT] := @CMSG_SCREENSHOT_handler;
	@OpCodeHandleTable[MSG_GM_BIND_OTHER] := @MSG_GM_BIND_OTHER_handler;
	@OpCodeHandleTable[MSG_GM_SUMMON] := @MSG_GM_SUMMON_handler;
	@OpCodeHandleTable[CMSG_AUTH_SESSION] := @CMSG_AUTH_SESSION_handler;
	@OpCodeHandleTable[MSG_GM_SHOWLABEL] := @MSG_GM_SHOWLABEL_handler;
	@OpCodeHandleTable[MSG_ADD_DYNAMIC_TARGET] := @MSG_ADD_DYNAMIC_TARGET_handler;
	@OpCodeHandleTable[MSG_SAVE_GUILD_EMBLEM] := @MSG_SAVE_GUILD_EMBLEM_handler;
	@OpCodeHandleTable[MSG_TABARDVENDOR_ACTIVATE] := @MSG_TABARDVENDOR_ACTIVATE_handler;
	@OpCodeHandleTable[CMSG_ZONEUPDATE] := @CMSG_ZONEUPDATE_handler;
	@OpCodeHandleTable[CMSG_GM_SET_SECURITY_GROUP] := @CMSG_GM_SET_SECURITY_GROUP_handler;
	@OpCodeHandleTable[CMSG_GM_NUKE] := @CMSG_GM_NUKE_handler;
	@OpCodeHandleTable[MSG_RANDOM_ROLL] := @MSG_RANDOM_ROLL_handler;
	@OpCodeHandleTable[CMSG_RWHOIS] := @CMSG_RWHOIS_handler;
	@OpCodeHandleTable[MSG_LOOKING_FOR_GROUP] := @MSG_LOOKING_FOR_GROUP_handler;
	@OpCodeHandleTable[CMSG_SET_LOOKING_FOR_GROUP] := @CMSG_SET_LOOKING_FOR_GROUP_handler;
	@OpCodeHandleTable[CMSG_UNLEARN_SPELL] := @CMSG_UNLEARN_SPELL_handler;
	@OpCodeHandleTable[CMSG_UNLEARN_SKILL] := @CMSG_UNLEARN_SKILL_handler;
	@OpCodeHandleTable[CMSG_DECHARGE] := @CMSG_DECHARGE_handler;
	@OpCodeHandleTable[CMSG_GMTICKET_CREATE] := @CMSG_GMTICKET_CREATE_handler;
	@OpCodeHandleTable[CMSG_GMTICKET_UPDATETEXT] := @CMSG_GMTICKET_UPDATETEXT_handler;
	@OpCodeHandleTable[CMSG_REQUEST_ACCOUNT_DATA] := @CMSG_REQUEST_ACCOUNT_DATA_handler;
	@OpCodeHandleTable[CMSG_UPDATE_ACCOUNT_DATA] := @CMSG_UPDATE_ACCOUNT_DATA_handler;
	@OpCodeHandleTable[CMSG_GM_TEACH] := @CMSG_GM_TEACH_handler;
	@OpCodeHandleTable[CMSG_GM_CREATE_ITEM_TARGET] := @CMSG_GM_CREATE_ITEM_TARGET_handler;
	@OpCodeHandleTable[CMSG_GMTICKET_GETTICKET] := @CMSG_GMTICKET_GETTICKET_handler;
	@OpCodeHandleTable[CMSG_UNLEARN_TALENTS] := @CMSG_UNLEARN_TALENTS_handler;
	@OpCodeHandleTable[MSG_CORPSE_QUERY] := @MSG_CORPSE_QUERY_handler;
	@OpCodeHandleTable[CMSG_GMTICKET_DELETETICKET] := @CMSG_GMTICKET_DELETETICKET_handler;
	@OpCodeHandleTable[CMSG_GMTICKET_SYSTEMSTATUS] := @CMSG_GMTICKET_SYSTEMSTATUS_handler;
	@OpCodeHandleTable[CMSG_SPIRIT_HEALER_ACTIVATE] := @CMSG_SPIRIT_HEALER_ACTIVATE_handler;
	@OpCodeHandleTable[CMSG_SET_STAT_CHEAT] := @CMSG_SET_STAT_CHEAT_handler;
	@OpCodeHandleTable[CMSG_SKILL_BUY_STEP] := @CMSG_SKILL_BUY_STEP_handler;
	@OpCodeHandleTable[CMSG_SKILL_BUY_RANK] := @CMSG_SKILL_BUY_RANK_handler;
	@OpCodeHandleTable[CMSG_XP_CHEAT] := @CMSG_XP_CHEAT_handler;
	@OpCodeHandleTable[CMSG_CHARACTER_POINT_CHEAT] := @CMSG_CHARACTER_POINT_CHEAT_handler;
	@OpCodeHandleTable[CMSG_CHAT_IGNORED] := @CMSG_CHAT_IGNORED_handler;
	@OpCodeHandleTable[CMSG_GM_VISION] := @CMSG_GM_VISION_handler;
	@OpCodeHandleTable[CMSG_SERVER_COMMAND] := @CMSG_SERVER_COMMAND_handler;
	@OpCodeHandleTable[CMSG_GM_SILENCE] := @CMSG_GM_SILENCE_handler;
	@OpCodeHandleTable[CMSG_GM_REVEALTO] := @CMSG_GM_REVEALTO_handler;
	@OpCodeHandleTable[CMSG_GM_RESURRECT] := @CMSG_GM_RESURRECT_handler;
	@OpCodeHandleTable[CMSG_GM_SUMMONMOB] := @CMSG_GM_SUMMONMOB_handler;
	@OpCodeHandleTable[CMSG_GM_MOVECORPSE] := @CMSG_GM_MOVECORPSE_handler;
	@OpCodeHandleTable[CMSG_GM_FREEZE] := @CMSG_GM_FREEZE_handler;
	@OpCodeHandleTable[CMSG_GM_UBERINVIS] := @CMSG_GM_UBERINVIS_handler;
	@OpCodeHandleTable[CMSG_GM_REQUEST_PLAYER_INFO] := @CMSG_GM_REQUEST_PLAYER_INFO_handler;
	@OpCodeHandleTable[CMSG_GUILD_RANK] := @CMSG_GUILD_RANK_handler;
	@OpCodeHandleTable[CMSG_GUILD_ADD_RANK] := @CMSG_GUILD_ADD_RANK_handler;
	@OpCodeHandleTable[CMSG_GUILD_DEL_RANK] := @CMSG_GUILD_DEL_RANK_handler;
	@OpCodeHandleTable[CMSG_GUILD_SET_PUBLIC_NOTE] := @CMSG_GUILD_SET_PUBLIC_NOTE_handler;
	@OpCodeHandleTable[CMSG_GUILD_SET_OFFICER_NOTE] := @CMSG_GUILD_SET_OFFICER_NOTE_handler;
	@OpCodeHandleTable[CMSG_CLEAR_EXPLORATION] := @CMSG_CLEAR_EXPLORATION_handler;
	@OpCodeHandleTable[CMSG_SEND_MAIL] := @CMSG_SEND_MAIL_handler;
	@OpCodeHandleTable[CMSG_GET_MAIL_LIST] := @CMSG_GET_MAIL_LIST_handler;
	@OpCodeHandleTable[CMSG_BATTLEFIELD_LIST] := @CMSG_BATTLEFIELD_LIST_handler;
	@OpCodeHandleTable[CMSG_BATTLEFIELD_JOIN] := @CMSG_BATTLEFIELD_JOIN_handler;
	@OpCodeHandleTable[CMSG_TAXICLEARNODE] := @CMSG_TAXICLEARNODE_handler;
	@OpCodeHandleTable[CMSG_TAXIENABLENODE] := @CMSG_TAXIENABLENODE_handler;
	@OpCodeHandleTable[CMSG_ITEM_TEXT_QUERY] := @CMSG_ITEM_TEXT_QUERY_handler;
	@OpCodeHandleTable[CMSG_MAIL_TAKE_MONEY] := @CMSG_MAIL_TAKE_MONEY_handler;
	@OpCodeHandleTable[CMSG_MAIL_TAKE_ITEM] := @CMSG_MAIL_TAKE_ITEM_handler;
	@OpCodeHandleTable[CMSG_MAIL_MARK_AS_READ] := @CMSG_MAIL_MARK_AS_READ_handler;
	@OpCodeHandleTable[CMSG_MAIL_RETURN_TO_SENDER] := @CMSG_MAIL_RETURN_TO_SENDER_handler;
	@OpCodeHandleTable[CMSG_MAIL_DELETE] := @CMSG_MAIL_DELETE_handler;
	@OpCodeHandleTable[CMSG_MAIL_CREATE_TEXT_ITEM] := @CMSG_MAIL_CREATE_TEXT_ITEM_handler;
	@OpCodeHandleTable[CMSG_LEARN_TALENT] := @CMSG_LEARN_TALENT_handler;
	@OpCodeHandleTable[CMSG_ENABLE_PVP] := @CMSG_ENABLE_PVP_handler;
	@OpCodeHandleTable[MSG_AUCTION_HELLO] := @MSG_AUCTION_HELLO_handler;
	@OpCodeHandleTable[CMSG_AUCTION_SELL_ITEM] := @CMSG_AUCTION_SELL_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUCTION_REMOVE_ITEM] := @CMSG_AUCTION_REMOVE_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUCTION_LIST_ITEMS] := @CMSG_AUCTION_LIST_ITEMS_handler;
	@OpCodeHandleTable[CMSG_AUCTION_LIST_OWNER_ITEMS] := @CMSG_AUCTION_LIST_OWNER_ITEMS_handler;
	@OpCodeHandleTable[CMSG_AUCTION_PLACE_BID] := @CMSG_AUCTION_PLACE_BID_handler;
	@OpCodeHandleTable[CMSG_AUCTION_LIST_BIDDER_ITEMS] := @CMSG_AUCTION_LIST_BIDDER_ITEMS_handler;
	@OpCodeHandleTable[CMSG_SET_AMMO] := @CMSG_SET_AMMO_handler;
	@OpCodeHandleTable[CMSG_SET_ACTIVE_MOVER] := @CMSG_SET_ACTIVE_MOVER_handler;
	@OpCodeHandleTable[CMSG_PET_CANCEL_AURA] := @CMSG_PET_CANCEL_AURA_handler;
	@OpCodeHandleTable[CMSG_PLAYER_AI_CHEAT] := @CMSG_PLAYER_AI_CHEAT_handler;
	@OpCodeHandleTable[CMSG_CANCEL_AUTO_REPEAT_SPELL] := @CMSG_CANCEL_AUTO_REPEAT_SPELL_handler;
	@OpCodeHandleTable[MSG_GM_ACCOUNT_ONLINE] := @MSG_GM_ACCOUNT_ONLINE_handler;
	@OpCodeHandleTable[MSG_LIST_STABLED_PETS] := @MSG_LIST_STABLED_PETS_handler;
	@OpCodeHandleTable[CMSG_STABLE_PET] := @CMSG_STABLE_PET_handler;
	@OpCodeHandleTable[CMSG_UNSTABLE_PET] := @CMSG_UNSTABLE_PET_handler;
	@OpCodeHandleTable[CMSG_BUY_STABLE_SLOT] := @CMSG_BUY_STABLE_SLOT_handler;
	@OpCodeHandleTable[CMSG_STABLE_REVIVE_PET] := @CMSG_STABLE_REVIVE_PET_handler;
	@OpCodeHandleTable[CMSG_STABLE_SWAP_PET] := @CMSG_STABLE_SWAP_PET_handler;
	@OpCodeHandleTable[MSG_QUEST_PUSH_RESULT] := @MSG_QUEST_PUSH_RESULT_handler;
	@OpCodeHandleTable[CMSG_REQUEST_PET_INFO] := @CMSG_REQUEST_PET_INFO_handler;
	@OpCodeHandleTable[CMSG_FAR_SIGHT] := @CMSG_FAR_SIGHT_handler;
	@OpCodeHandleTable[CMSG_ENABLE_DAMAGE_LOG] := @CMSG_ENABLE_DAMAGE_LOG_handler;
	@OpCodeHandleTable[CMSG_GROUP_CHANGE_SUB_GROUP] := @CMSG_GROUP_CHANGE_SUB_GROUP_handler;
	@OpCodeHandleTable[CMSG_GROUP_SWAP_SUB_GROUP] := @CMSG_GROUP_SWAP_SUB_GROUP_handler;
	@OpCodeHandleTable[CMSG_RESET_FACTION_CHEAT] := @CMSG_RESET_FACTION_CHEAT_handler;
	@OpCodeHandleTable[CMSG_AUTOSTORE_BANK_ITEM] := @CMSG_AUTOSTORE_BANK_ITEM_handler;
	@OpCodeHandleTable[CMSG_AUTOBANK_ITEM] := @CMSG_AUTOBANK_ITEM_handler;
	@OpCodeHandleTable[MSG_QUERY_NEXT_MAIL_TIME] := @MSG_QUERY_NEXT_MAIL_TIME_handler;
	@OpCodeHandleTable[CMSG_SET_DURABILITY_CHEAT] := @CMSG_SET_DURABILITY_CHEAT_handler;
	@OpCodeHandleTable[CMSG_SET_PVP_RANK_CHEAT] := @CMSG_SET_PVP_RANK_CHEAT_handler;
	@OpCodeHandleTable[CMSG_ADD_PVP_MEDAL_CHEAT] := @CMSG_ADD_PVP_MEDAL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_DEL_PVP_MEDAL_CHEAT] := @CMSG_DEL_PVP_MEDAL_CHEAT_handler;
	@OpCodeHandleTable[CMSG_SET_PVP_TITLE] := @CMSG_SET_PVP_TITLE_handler;
	@OpCodeHandleTable[CMSG_GROUP_RAID_CONVERT] := @CMSG_GROUP_RAID_CONVERT_handler;
	@OpCodeHandleTable[CMSG_GROUP_ASSISTANT_LEADER] := @CMSG_GROUP_ASSISTANT_LEADER_handler;
	@OpCodeHandleTable[CMSG_BUYBACK_ITEM] := @CMSG_BUYBACK_ITEM_handler;
	@OpCodeHandleTable[CMSG_MEETING_STONE_JOIN] := @CMSG_MEETING_STONE_JOIN_handler;
	@OpCodeHandleTable[CMSG_MEETING_STONE_LEAVE] := @CMSG_MEETING_STONE_LEAVE_handler;
	@OpCodeHandleTable[CMSG_MEETING_STONE_CHEAT] := @CMSG_MEETING_STONE_CHEAT_handler;
	@OpCodeHandleTable[CMSG_MEETING_STONE_INFO] := @CMSG_MEETING_STONE_INFO_handler;
	@OpCodeHandleTable[CMSG_GMTICKETSYSTEM_TOGGLE] := @CMSG_GMTICKETSYSTEM_TOGGLE_handler;
	@OpCodeHandleTable[CMSG_CANCEL_GROWTH_AURA] := @CMSG_CANCEL_GROWTH_AURA_handler;
	@OpCodeHandleTable[CMSG_LOOT_ROLL] := @CMSG_LOOT_ROLL_handler;
	@OpCodeHandleTable[CMSG_LOOT_MASTER_GIVE] := @CMSG_LOOT_MASTER_GIVE_handler;
	@OpCodeHandleTable[CMSG_REPAIR_ITEM] := @CMSG_REPAIR_ITEM_handler;
	@OpCodeHandleTable[MSG_TALENT_WIPE_CONFIRM] := @MSG_TALENT_WIPE_CONFIRM_handler;
	@OpCodeHandleTable[CMSG_SUMMON_RESPONSE] := @CMSG_SUMMON_RESPONSE_handler;
	@OpCodeHandleTable[MSG_MOVE_TOGGLE_GRAVITY_CHEAT] := @MSG_MOVE_TOGGLE_GRAVITY_CHEAT_handler;
	@OpCodeHandleTable[MSG_MOVE_FEATHER_FALL] := @MSG_MOVE_FEATHER_FALL_handler;
	@OpCodeHandleTable[MSG_MOVE_WATER_WALK] := @MSG_MOVE_WATER_WALK_handler;
	@OpCodeHandleTable[CMSG_SERVER_BROADCAST] := @CMSG_SERVER_BROADCAST_handler;
	@OpCodeHandleTable[CMSG_SELF_RES] := @CMSG_SELF_RES_handler;
	@OpCodeHandleTable[CMSG_RUN_SCRIPT] := @CMSG_RUN_SCRIPT_handler;
	@OpCodeHandleTable[CMSG_TOGGLE_HELM] := @CMSG_TOGGLE_HELM_handler;
	@OpCodeHandleTable[CMSG_TOGGLE_CLOAK] := @CMSG_TOGGLE_CLOAK_handler;
	@OpCodeHandleTable[CMSG_SET_EXPLORATION] := @CMSG_SET_EXPLORATION_handler;
	@OpCodeHandleTable[CMSG_SET_ACTIONBAR_TOGGLES] := @CMSG_SET_ACTIONBAR_TOGGLES_handler;
	@OpCodeHandleTable[UMSG_DELETE_GUILD_CHARTER] := @UMSG_DELETE_GUILD_CHARTER_handler;
	@OpCodeHandleTable[MSG_PETITION_RENAME] := @MSG_PETITION_RENAME_handler;
	@OpCodeHandleTable[CMSG_ITEM_NAME_QUERY] := @CMSG_ITEM_NAME_QUERY_handler;
	@OpCodeHandleTable[CMSG_MOVE_TIME_SKIPPED] := @CMSG_MOVE_TIME_SKIPPED_handler;
	@OpCodeHandleTable[CMSG_BATTLEFIELD_STATUS] := @CMSG_BATTLEFIELD_STATUS_handler;

finalization
    DeleteCriticalSection(CriticalSection);

end.
