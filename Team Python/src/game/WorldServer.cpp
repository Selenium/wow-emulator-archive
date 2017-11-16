// Copyright (C) 2004 Team Python
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

// WorldServer.cpp: implementation of the WorldServer class.
//
//////////////////////////////////////////////////////////////////////

#include "WorldServer.h"
#include "Network.h"
#include "Log.h"
#include "Database.h"
#include "Opcodes.h"
#include "Character.h"
#include "UpdateMask.h"
//#if PLATFORM == PLATFORM_WIN32
//#include <winsock2.h>
//#else
//#include <sys/socket.h>
//#endif
#include "Sockets.h"
#include "math.h"

#define world WorldServer::getSingleton()

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////
createFileSingleton( WorldServer );

WorldServer::WorldServer()
{
	killingItem = false; dontkillItem = false;
	mClientsConnected=0;
	dbstate = 0;
	motd_size=sizeof("This Server not have a MOTD");
	motd = new uint8[motd_size];
	memcpy(motd,"This Server not have a MOTD",motd_size);

Talents = new TALENT[MAXTALENTID];
}

WorldServer::~WorldServer()
{
	mEmotes.clear();

    for( CreatureNameMap::iterator i = mCreatureNames.begin( ); i != mCreatureNames.end( ); ++ i ) 
	{
        delete i->second;
    }
	mCreatureNames.clear();

	for( CreatureMap::iterator i = mCreatures.begin( ); i != mCreatures.end( ); ++ i )
	{
		delete i->second;
	}
	mCreatures.clear( );

	delete [] motd;
}


void WorldServer::SetInitialWorldSettings()
{
	// clear logfile
	FILE *pFile = fopen("packetlog.txt", "w+");
	fclose(pFile);

	srand(time(NULL));

	m_hiCharGuid = 1;
	m_hiCreatureGuid = 1;
	m_hiItemGuid = 1;
	m_hiGoGuid = 1;

	m_lastTick = time(NULL);
	// <WoW Chile Dev Team> Start Change
	time_t tiempo;
	char hour[3];
	char minute[3];
	char second[3];
	struct tm *tmPtr;
	tiempo = time(NULL);
	tmPtr = localtime(&tiempo);
	strftime( hour, 3, "%H", tmPtr );
	strftime( minute, 3, "%M", tmPtr );
	strftime( second, 3, "%S", tmPtr );
	m_gameTime = (3600*atoi(hour))+(atoi(minute)*60)+(atoi(second)); // server starts at noon
	// <WoW Chile Dev Team> Stop Change
	//m_creatureEntries = 0; //NAME PATCH ignatich

	// fill in emotes table
	// it appears not every emote has an animation
	mEmotes[1] = 0;
	mEmotes[2] = 0;
	mEmotes[3] = 14;
	mEmotes[4] = 0;
	mEmotes[5] = 21;
	mEmotes[6] = 24;
	mEmotes[7] = 0;
	mEmotes[8] = 20;
	mEmotes[9] = 0;
	mEmotes[10] = 0;
	mEmotes[11] = 0;
	mEmotes[12] = 24;
	mEmotes[13] = 0;
	mEmotes[14] = 0;
	mEmotes[15] = 0;
	mEmotes[16] = 0;
	mEmotes[17] = 2;
	mEmotes[18] = 14;
	mEmotes[19] = 3;
	mEmotes[20] = 11;
	mEmotes[21] = 4;
	mEmotes[22] = 0;
	mEmotes[23] = 11;
	mEmotes[24] = 21; // clap
	mEmotes[25] = 6;
	mEmotes[26] = 21;
	mEmotes[27] = 14;
	mEmotes[28] = 0;
	mEmotes[29] = 21;
	mEmotes[30] = 24;
	mEmotes[31] = 18;
	mEmotes[32] = 6;
	mEmotes[33] = 2;
	mEmotes[34] = 10;
	mEmotes[35] = 0;
	mEmotes[36] = 0;
	mEmotes[37] = 0;
	mEmotes[38] = 0;
	mEmotes[39] = 0;
	mEmotes[40] = 0;
	mEmotes[41] = 23;
	mEmotes[42] = 0;
	mEmotes[43] = 5;
	mEmotes[44] = 0;
	mEmotes[45] = 11;
	mEmotes[46] = 0;
	mEmotes[47] = 11;
	mEmotes[48] = 3; 
	mEmotes[49] = 0; 
	mEmotes[50] = 0;
	mEmotes[51] = 20;
	mEmotes[52] = 11;
	mEmotes[53] = 3;
	mEmotes[54] = 0;
	mEmotes[55] = 3;
	mEmotes[56] = 0;
	mEmotes[57] = 0;
	mEmotes[58] = 17;
	mEmotes[59] = 68;
	mEmotes[60] = 11;
	mEmotes[61] = 12;
	mEmotes[62] = 0;
	mEmotes[63] = 0;
	mEmotes[64] = 0;
	mEmotes[65] = 18;
	mEmotes[66] = 0;
	mEmotes[67] = 0;
	mEmotes[68] = 0;
	mEmotes[69] = 0;
	mEmotes[70] = 0;
	mEmotes[71] = 20;
	mEmotes[72] = 25;
	mEmotes[73] = 0;
	mEmotes[74] = 16;
	mEmotes[75] = 15;
	mEmotes[76] = 11;
	mEmotes[77] = 14;
	mEmotes[78] = 66;
	mEmotes[79] = 0;
	mEmotes[70] = 0;
	mEmotes[81] = 0;
	mEmotes[82] = 22;
	mEmotes[83] = 6;
	mEmotes[84] = 24;
	mEmotes[85] = 0;
	mEmotes[86] = 0;
	mEmotes[87] = 12;
	mEmotes[88] = 0; 
	mEmotes[89] = 0; 
	mEmotes[90] = 0;
	mEmotes[91] = 0;
	mEmotes[92] = 20;
	mEmotes[93] = 0;
	mEmotes[94] = 5;
	mEmotes[95] = 5;
	mEmotes[96] = 0;
	mEmotes[97] = 0;
	mEmotes[98] = 0; 
	mEmotes[99] = 0; 
	mEmotes[100] = 4;
	mEmotes[101] = 3;
	mEmotes[102] = 3;
	mEmotes[103] = 0;
	mEmotes[104] = 0;
	mEmotes[105] = 0;
	mEmotes[106] = 0;
	mEmotes[107] = 6;
	mEmotes[108] = 0;
	mEmotes[109] = 0;
	mEmotes[110] = 0;
	mEmotes[111] = 0;
	mEmotes[112] = 0;
	mEmotes[113] = 14;
	mEmotes[114] = 0;
	mEmotes[115] = 0;
	mEmotes[116] = 0;
	mEmotes[117] = 0;
	mEmotes[118] = 6;
	mEmotes[119] = 0;
	mEmotes[120] = 6;
	mEmotes[121] = 0;
	mEmotes[122] = 0;
	mEmotes[123] = 0;
	mEmotes[124] = 6;
	mEmotes[125] = 0;
	mEmotes[126] = 0;
	mEmotes[127] = 0;
	mEmotes[128] = 0;
	mEmotes[129] = 0;
	mEmotes[120] = 0;
	mEmotes[131] = 0;
	mEmotes[132] = 0;
	mEmotes[133] = 0;
	mEmotes[134] = 0;
	mEmotes[135] = 0;
	mEmotes[136] = 0;
	mEmotes[137] = 0;
	mEmotes[138] = 0; 
	mEmotes[139] = 0; 
	mEmotes[140] = 0;
	mEmotes[141] = 26;
	mEmotes[142] = 0; 
	mEmotes[143] = 18; 
	mEmotes[163] = 0;

	WPAssert(dbi);
	// Load quests
	dbi->loadQuests();

	dbi->loadTalents();

	dbi->loadItems();

	// Load initial creatures
	dbi->setHighestGuids();

	dbi->loadCreatureNames(mCreatureNames);

	std::set< Unit * > creatureSet = dbi->loadCreatures();
	for( std::set< Unit *>::iterator itr = creatureSet.begin( ); itr != creatureSet.end( ); ++ itr ) 
	{
		WPAssert( (*itr)->getGUID() != 0 );
		mCreatures[(*itr)->getGUID()] = *itr;
	}

	initUpdates();
}

void WorldServer::eventStart( ) 
{
	dbi = Database::getSingleton( ).createDatabaseInterface( );
	SetInitialWorldSettings();
}

void WorldServer::eventStop( ) 
{
	Database::getSingleton( ).removeDatabaseInterface( dbi );
	dbi = NULL;  
}

void WorldServer::updateRealm(char *realm) 
{
	int sb;
	char cTemp[256];
	for(sb = 0; sb < 256;sb++) cTemp[sb] = 0;
	int sockfd;
	struct hostent *he;
	struct sockaddr_in their_addr;
	he = gethostbyname("127.0.0.1");
	sockfd = socket(AF_INET, SOCK_STREAM, 0);
	their_addr.sin_family = AF_INET;
	their_addr.sin_port = htons(3724);
	their_addr.sin_addr = *((struct in_addr *)he->h_addr);
	memset(&(their_addr.sin_zero), '\0', 8);
	
	if (connect(sockfd, (struct sockaddr *)&their_addr, sizeof(struct sockaddr)) == -1) 
	{
        perror("connect");
        return;
    }

	sb = sprintf(cTemp,"%c%s%c%d",4,realm,';',WorldServer::getSingleton().GetClientsConnected());
	send(sockfd, cTemp, sb, 0);
	closesocket(sockfd);
}

void WorldServer::Update( uint32 fTime )
{
	updateGameTime();
	// Run AI, etc
	// ...
	updateTimes(fTime);
	if (updatePassed(UPDATE_LOGOUT)) {
		ClientSet::iterator itr;
		for (itr = mClients.begin(); itr != mClients.end(); itr++)
		{
			GameClient *pClient = static_cast < GameClient * >(*itr);

			// check this client's logout request progress
			uint32 currTime = time(NULL);
			if (pClient->ShouldLogOut(currTime))
			{
				wowWData data;
				data.Initialise(0, SMSG_LOGOUT_COMPLETE);
				pClient->SendMsg(&data);
				LogoutPlayer(pClient);
				Log::getSingleton( ).outString( "WORLD: sent SMSG_LOGOUT_COMPLETE Message" );
				pClient->LogoutRequest(0);
			}
		}
	}
	CharacterMap::iterator chriter;
	CreatureMap::iterator iter;
	if (updatePassed(UPDATE_SET)) {
		for( chriter = mCharacters.begin( ); chriter != mCharacters.end( ); ++ chriter ) 
		{
			chriter->second->UpdateInRangeSet();
			CheckForInRangeObjects(chriter->second);
		}

		for( iter = mCreatures.begin( ); iter != mCreatures.end( ); ++ iter )
		{
			iter->second->UpdateInRangeSet();
			CheckForInRangeObjects(iter->second);	
			// <WoW Chile Dev Team> Start Change
			// <WoW Chile Dev Team> Stop Change
		}
	}

	if (updatePassed(UPDATE_OBJECT)) {
		for( chriter = mCharacters.begin( ); chriter != mCharacters.end( ); ++ chriter ) 
		{
			chriter->second->Update( fTime );
		}

		for( iter = mCreatures.begin( ); iter != mCreatures.end( ); ++ iter ) 
		{
			iter->second->Update( fTime );
		}
	}

	updateReset();
}

void WorldServer::server_sockevent(struct nlink_server *cptr, unsigned short revents, void * myNet)
{
	NetworkInterface * client;
	struct nlink_client *ncptr;
	if(revents & PF_READ)
	{
		client = ( ( NetworkInterface * ) myNet )->getConnection( );
		if (!client) 
			return;

		uint32 nonblockingstate = true;
		IOCTL_SOCKET( client->getSocketID(), IOCTL_NOBLOCK, &nonblockingstate );

		ncptr = new nlink_client;
		if(ncptr == NULL)
			return;

		memset(ncptr, 0, sizeof(*ncptr));
		ncptr->hdr.type = RCLIENT;
		ncptr->hdr.fd = client->getSocketID();

		nlink_insert((struct nlink *)ncptr);

		GameClient *pClient = new GameClient();
		pClient->SetNLink(reinterpret_cast < GameClient::nlink_client *> (ncptr)); //LINA ADD FOR KICK COMMAND
		pClient->BindNI(client);
		pClient->CreateDB();
		mClients.insert(pClient);
		//updateRealm( "LeMMiNGS.com.br test server" );
		wowWData data;
		ncptr->pClient = pClient;
		data.Initialise( 4, SMSG_AUTH_CHALLENGE );
		data << uint32( 0 );
		pClient->SendMsg( &data );
		Log::getSingleton( ).outString( "WORLD: connection! Sent Auth Challenge." );
	}
}


void WorldServer::client_sockevent(struct nlink_client *cptr, unsigned short revents)
{	
	if(revents & PF_WRITE)
	{
		uint32 status;
		GameClient *pClient = static_cast < GameClient * > ( cptr->pClient );
		NetworkInterface *net = pClient->getNetwork();
		if (net->getSendqLen() == 0)
			return;
		status = net->sendPendingSendq();
		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}
		net->updateSendq(status);	
		return;
	}

	//All the World stuff here
	if(revents & PF_READ)
	{
		int j;

		int readsofar = 0;
		wowWData data;
		wowWData recv_data;
		wowWData *dataptr = &recv_data;
		GameClient *pClient = static_cast < GameClient * > ( cptr->pClient );
		NetworkInterface *net = pClient->getNetwork();
		DatabaseInterface *dbi = pClient->getDB();
		net->NullRecvq();

		if (!net->isConnected()) {
			disconnect_client(cptr);
			return;
		}

		net->fillRecvQ();

		if (net->getRecvqLen() <= 0)
			return;

		while(1)
		{
			if (!net->isConnected()) 
			{
				disconnect_client(cptr);
				return;
			}
			if (readsofar == net->getRecvqLen())
				return;
			recv_data.clear();

			recv_data.setLength( ((uint8)net->getRecvq()[readsofar]<<8) + (uint8)net->getRecvq()[readsofar + 1] - 4);
			readsofar += 2;
			recv_data.opcode = (net->getRecvq()[readsofar + 3]<<24)+(net->getRecvq()[readsofar + 2]<<16)+(net->getRecvq()[readsofar + 1]<<8)+net->getRecvq()[readsofar];
			readsofar += 4;

			for(j=0;j<recv_data.length;j++)
			{
				if (readsofar + j >= net->getRecvqLen())
					return;
                WPFatal( net->getRecvq(), "Recvq is NULL!" );
				recv_data.data[j] = (uint8)net->getRecvq()[readsofar + j];
			}
			readsofar += recv_data.length;



			if( !recv_data.length && recv_data.opcode == 0 ) 
			{
				printf("Nothing to read...Returning\n");
				return;
			}

			// World Logger
			if (Network::getSingleton().IsLoggingWorld())
			{
				FILE *pFile;
				pFile = fopen("packetlog.txt", "a");
				fprintf(pFile, "CLIENT:\nSOCKET: %d\nLENGTH: %d\nOPCODE: %.4X\nDATA:\n", ((GameClient *)(cptr->pClient))->getNetwork( )->getSocketID( ), recv_data.length+4, recv_data.opcode);
				int p=0;
				while (p < recv_data.length) {
					for (int j=0; j < 16 && p < recv_data.length; j++)
						fprintf(pFile, "%.2X ", recv_data.data[p++]);
					fprintf(pFile, "\n");
				}

				fprintf(pFile, "\n\n");
				fclose(pFile);
			}

			if (!pClient->isAuth() && (!pClient->isLogged())) 
			{
				if( recv_data.opcode == CMSG_PING ) {
					Log::getSingleton( ).outString( "WORLD: Recvd CMSG_PING Message" );

					uint32 ping;
					recv_data >> ping;

					data.Initialise( 4, SMSG_PONG );
					data << ping;
					net->sendWData( &data );

					Log::getSingleton( ).outString( "WORLD: sent SMSG_PONG Message" );

					data.Initialise( 4, SMSG_AUTH_CHALLENGE );
					data << uint32( 0 );
					net->sendWData( &data );
					Log::getSingleton( ).outString( "WORLD: Sent Auth Challenge." );
				} 
				else if( recv_data.opcode == CMSG_CHAR_ENUM ) 
				{
					// Send Bad Account
					data.Initialise( 1, SMSG_AUTH_RESPONSE );
					data << uint8( 21 );
					net->sendWData( &data );
					Log::getSingleton( ).outString( "WORLD: Sent Auth Response (unknown account)." );
					disconnect_client(cptr);
					return;
				}
				else if( recv_data.opcode == CMSG_AUTH_SESSION) 
				{
					Log::getSingleton( ).outString( "WORLD: Recvd Auth Challenge." );
					char loginname[255];
					char password[28];
					int alreadyconnected = 0;
					strcpy( loginname, (char *)recv_data.data+8 );
					//strcpy( password, (char *)recv_data.data+9 );
					strcpy( password, "BETA3" );

					int account_id = dbi->Login(loginname, password, net->getIP());					

					ClientSet::iterator itr;
					for (itr = mClients.begin(); itr != mClients.end(); itr++)
					{
						if (((GameClient*)(*itr))->getAccountID() == account_id) 
						{
							data.Initialise( 1, SMSG_AUTH_RESPONSE );
							data << uint8( 13 );
							net->sendWData( &data );
							Log::getSingleton( ).outString( "WORLD: Sent Auth Response (already connected)." );
							alreadyconnected = 1;	
							return;
						}
					}						
					if (!alreadyconnected) 
					{
						if( account_id < 0 ) 
						{
							// Send Bad Account
							data.Initialise( 1, SMSG_AUTH_RESPONSE );
							data << uint8( 21 );
							net->sendWData( &data );
							Log::getSingleton( ).outString( "WORLD: Sent Auth Response (unknown account)." );
							return;
						} 
						else {
							//assert(account_id >= 0);  // should be, since we verify in RealmServer first

							// Variables for Main loop that need to be different per client
							pClient->BindAcctID(account_id);
                            //int account_lvl = dbi->getAccountLvl(account_id);
							int account_lvl = 0;
							pClient->setAccountLvl(account_lvl);

							//LoadCharacters( );
							if( !pClient->numCharacters() ) 
							{
								std::set< Character * > characterSet = pClient->getDB( )->enumCharacters(account_id);
								for( std::set< Character *>::iterator itr = characterSet.begin( ); itr != characterSet.end( ) && pClient->numCharacters() < 10; ++ itr )
									pClient->addCharacter( *itr );
							}

							pClient->SetLastTarget(0);
							pClient->setAuth();

							// Send Auth Successful
							data.Initialise( 1, SMSG_AUTH_RESPONSE );
							data << uint8( 0x0C );
							net->sendWData( &data );
							Log::getSingleton( ).outString( "WORLD: Sent Auth Response." );
						}
					}
					else 
						disconnect_client(cptr);
					return;

				} 
				else {
					Log::getSingleton( ).outError( "WORLD: recieved unknown opcode 0x%.4X", recv_data.opcode );
				}
			}
			else if (pClient->isAuth() && !pClient->isLogged())
			{
				switch(recv_data.opcode)
				{
					
				case CMSG_PLAYER_LOGIN: 
					{
						mMiscHandler.HandleMsg( recv_data, pClient );
					}break;
					
				case CMSG_CHAR_ENUM: case CMSG_CHAR_CREATE: case CMSG_CHAR_DELETE:
					{
						mCharacterHandler.HandleMsg( recv_data, pClient );
					}break;

				default: 
					{
						Log::getSingleton( ).outError( "WORLD: recieved unknown opcode 0x%.4X", recv_data.opcode );
					}break;
				}
			}
			else if (pClient->isLogged() && pClient->isAuth())
			{
				switch (recv_data.opcode)
				{
				case CMSG_NAME_QUERY: case CMSG_QUERY_TIME: case CMSG_CREATURE_QUERY: case CMSG_GAMEOBJECT_QUERY:
					{
						mQueryHandler.HandleMsg(recv_data, pClient);
					}break;

				case CMSG_GROUP_INVITE: case CMSG_GROUP_ACCEPT: case CMSG_GROUP_DECLINE: case CMSG_GROUP_UNINVITE:
				case CMSG_GROUP_UNINVITE_GUID: case CMSG_GROUP_SET_LEADER: case CMSG_LOOT_METHOD: case CMSG_GROUP_DISBAND:
					{
						mGroupHandler.HandleMsg( recv_data, pClient );
					}break;
				case CMSG_MESSAGECHAT: case CMSG_TEXT_EMOTE:
					{
						mChatHandler.HandleMsg( recv_data, pClient );
					} break;

				case CMSG_QUESTGIVER_STATUS_QUERY: case CMSG_QUESTGIVER_HELLO:  case CMSG_QUESTGIVER_ACCEPT_QUEST: 
				case CMSG_QUEST_QUERY: case CMSG_QUESTGIVER_CHOOSE_REWARD: case CMSG_QUESTGIVER_QUERY_QUEST: 
				case CMSG_QUESTGIVER_QUEST_AUTOLAUNCH: case CMSG_QUESTGIVER_REQUEST_REWARD: case CMSG_QUESTGIVER_CANCEL:

					{
						mQuestHandler.HandleMsg(recv_data, pClient);
					}break;

				case CMSG_TAXIQUERYAVAILABLENODES: case CMSG_ACTIVATETAXI: case CMSG_TAXINODE_STATUS_QUERY:
					{
						mTaxiHandler.HandleMsg( recv_data, pClient );
					}break;
				case CMSG_ATTACKSWING: case CMSG_ATTACKSTOP: 
					{
						mCombatHandler.HandleMsg( recv_data, pClient );
					}break;
                //case CMSG_SKILL_LEVELUP:
				//	{
				//		mSkillHandler.HandleMsg( recv_data, pClient );
				//	}break;


				case MSG_MOVE_HEARTBEAT: case MSG_MOVE_JUMP: case MSG_MOVE_START_FORWARD : case MSG_MOVE_START_BACKWARD: case MSG_MOVE_SET_FACING: 
				case MSG_MOVE_STOP: case MSG_MOVE_START_STRAFE_LEFT: case MSG_MOVE_START_STRAFE_RIGHT: case MSG_MOVE_STOP_STRAFE: 
				case MSG_MOVE_START_TURN_LEFT: case MSG_MOVE_START_TURN_RIGHT:  case MSG_MOVE_STOP_TURN: case MSG_MOVE_START_PITCH_UP :
				case MSG_MOVE_START_PITCH_DOWN: case MSG_MOVE_STOP_PITCH : case MSG_MOVE_SET_RUN_MODE: case MSG_MOVE_SET_WALK_MODE:
				case MSG_MOVE_SET_PITCH: case MSG_MOVE_START_SWIM:
				case MSG_MOVE_STOP_SWIM: case MSG_MOVE_WORLDPORT_ACK:
					{
						mMovementHandler.HandleMsg( recv_data, pClient );
					}break;

				case CMSG_ITEM_QUERY_SINGLE: case CMSG_ITEM_QUERY_MULTIPLE: case CMSG_BUY_ITEM_IN_SLOT: case CMSG_LIST_INVENTORY:
				case CMSG_SWAP_INV_ITEM: case CMSG_AUTOEQUIP_ITEM: case CMSG_DESTROYITEM: case CMSG_BUY_ITEM: case CMSG_SELL_ITEM:
					{
						mItemHandler.HandleMsg( recv_data, pClient );
					}break;

				case CMSG_CAST_SPELL: case CMSG_USE_ITEM:
					{
						mSpellHandler.HandleMsg( recv_data, pClient );
					}break;
				case CMSG_PET_ACTION: 
				{ 
					mPetHandler.HandleMsg( recv_data, pClient ); 
				}break; 

				case CMSG_GOSSIP_HELLO: case MSG_TABARDVENDOR_ACTIVATE: case CMSG_BANKER_ACTIVATE: case CMSG_TRAINER_LIST: 
                case CMSG_NPC_TEXT_QUERY: case CMSG_TRAINER_BUY_SPELL: case CMSG_PETITION_SHOWLIST: case MSG_AUCTION_HELLO:
				case CMSG_GOSSIP_SELECT_OPTION: case CMSG_SPIRIT_HEALER_ACTIVATE:
					{
						mNPCHandler.HandleMsg( recv_data, pClient );
					}break;
				case CMSG_REPOP_REQUEST: case CMSG_LOOT: case CMSG_LOOT_RELEASE: case MSG_MINIMAP_PING: 
//				case CMSG_JOIN_CHANNEL:
				case CMSG_WHO: case CMSG_LOGOUT_REQUEST: case CMSG_PLAYER_LOGOUT: 
				case CMSG_LOGOUT_CANCEL: case CMSG_PING:  case CMSG_ZONEUPDATE: 
				case CMSG_SET_TARGET: case CMSG_SET_SELECTION : case CMSG_STANDSTATECHANGE: case CMSG_BUG:
				case CMSG_ADD_FRIEND: case CMSG_FRIEND_LIST: case CMSG_DEL_FRIEND: case CMSG_LOOT_MONEY:
                case CMSG_AUTOSTORE_LOOT_ITEM:
				case CMSG_SET_FACTION_ATWAR:
//				case CMSG_GMTICKET_GETTICKET: case CMSG_GMTICKET_CREATE:
//                case CMSG_GMTICKET_SYSTEMSTATUS:
				case CMSG_SET_ACTION_BUTTON: case CMSG_PET_SET_ACTION:
					{
						mMiscHandler.HandleMsg( recv_data, pClient );
					}break;
				case CMSG_LEARN_TALENT: 
				{ 
					mSkillHandler.HandleMsg(recv_data,pClient); 
				}
				default:
					{
						Log::getSingleton( ).outError( "WORLD: recieved unknown opcode 0x%.4X", recv_data.opcode  );
					}break;
				} 
			}
		}

	}

}

void WorldServer::LogoutPlayer(GameClient *pClient)
{
	wowWData data;
	uint32 guid,guid2;

    if(pClient->getCurrentChar() ) 
    {
		//LINA remove summoned creature at logout because they don't stop attack
		//and so i can add my test to stop NPC to attack unlogged Char and stop crash when user with or
		// w/o summoned creature disconnect in fight
		if(pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_SUMMON) != 0)
		{ 
			guid = pClient->getCurrentChar()->getUpdateValue(UNIT_FIELD_SUMMON); 
            Unit* old_summon = world.GetCreature(guid); 
            if( old_summon )
			{ 
				guid2 = old_summon->getUpdateValue(OBJECT_FIELD_GUID+1); 
				data.clear(); 
				data.Initialise(8, SMSG_DESTROY_OBJECT); 
				data << (uint32)guid << uint32(guid2); 
				pClient->getCurrentChar()->SendMessageToSet(&data, true); 
    
				std::map<uint32, Unit*>::iterator itr = world.mCreatures.find(guid); 
				for( WorldServer::CharacterMap::iterator iter = world.mCharacters.begin( ); iter != world.mCharacters.end( ); ++ iter ) 
					iter->second->RemoveInRangeObject( itr->second ); 
    
                delete itr->second; 
   				world.mCreatures.erase(itr); 
    
				DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( ); 
				char sql[512]; 
				sprintf(sql, "DELETE FROM creatures WHERE id=%u", guid); 
				dbi->doQuery(sql); 
				Database::getSingleton( ).removeDatabaseInterface(dbi); 
			}
			else 
				pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_SUMMON, 0); 
		}

		pClient->unSetLogged();
        /*/ Issue a message saying we left the world
	    std::string outstring = pClient->getCharacterName( );
	    outstring.append( " has left the world." );
	    SendWorldText( (uint8*)outstring.c_str( ) );*/
	    wowWData data;
		uint8 buf[256];
		sprintf((char*)buf,"%s left the world.", pClient->getCharacterName( ));
		mChatHandler.FillMessageData(&data, 0x09, pClient, buf);
		SendZoneMessage(&data, pClient, 0);
        data.clear();
	    
        // Destroy ourselves from other clients
        guid = pClient->getCurrentChar()->getGUID();
	    data.Initialise(8, SMSG_DESTROY_OBJECT);
	    data << (uint32)guid << (uint8)0x00 << (uint8)0x00 << (uint8)0x00 << (uint8)0x00;
        pClient->getCurrentChar()->SendMessageToSet(&data, false);

        // delete player items!!
        for(int invcount = 0; invcount < 23; invcount++)
	    {
            guid2 = pClient->getCurrentChar()->getGuidBySlot(invcount);
            data.Initialise(8, SMSG_DESTROY_OBJECT);
	        data << (uint32)guid2 << uint32(0x00000040);
            pClient->getCurrentChar()->SendMessageToSet(&data, false);
        }

        // Remove ourself from a group
        if (pClient->getCurrentChar()->IsInGroup()) 
		{
		    pClient->getCurrentChar()->UnSetInGroup();
		    Group *tmpGroup;
		    tmpGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
		    if (tmpGroup->DelMember((char *)pClient->getCharacterName()) > 1)
			{
			    tmpGroup->SendUpdate();
		    }
		    else {
			    tmpGroup->Disband();
			    WorldServer::getSingleton().DelGroup(tmpGroup);
		    }	
	    }
		
        for( CharacterMap::iterator iter = mCharacters.begin( ); iter != mCharacters.end( ); ++ iter )
            iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

        for( CreatureMap::iterator iter = mCreatures.begin( ); iter != mCreatures.end( ); ++ iter )
            iter->second->RemoveInRangeObject( pClient->getCurrentChar() );

        // Save Char to the DB and Remove from the ingame character list
        pClient->getDB( )->setCharacter( pClient->getCurrentChar( ) );
        pClient->getCurrentChar()->ClearInRangeSet();
	    CharacterMap::iterator charitr = mCharacters.find(guid);
	    mCharacters.erase(charitr);
    }

    // tell the client're no longer in the world, and clear the current character
    pClient->LogoutRequest(0);
    pClient->InWorld(false);
    pClient->setCurrentChar(NULL);
}

void WorldServer::disconnect_client( struct nlink_client *cptr )
{
	GameClient * pClient = static_cast < GameClient * > ( cptr->pClient );
	wowWData data;
	if (pClient->isAuth() && pClient->isLogged()) {
        LogoutPlayer(pClient);
	}
	//Setting the account to -1 in order to solve the "a client can login once" bug 
	pClient->BindAcctID(-1);

	mClients.erase( pClient );
    
	delete pClient;

	//updateRealm( "LeMMiNGS.com.br test server" );
	
	Log::getSingleton( ).outString( "WORLD: Client Quit!" );

	Server::disconnect_client( cptr );
}

void WorldServer::SetMotd(char *newMotd)
{
	motd_size=0;
	for(;newMotd[motd_size]!=0;motd_size++)
	{}
	motd_size++;

	if(motd!=NULL)
		delete [] motd;

	motd = new uint8[motd_size];
	memcpy(motd,newMotd,motd_size);
}


//////////////////////////////////////////////////////////////////////
//  Sends a packet to every client connected to the world server
//  Except the Client specified as pSelf
//////////////////////////////////////////////////////////////////////
void WorldServer::SendGlobalMessage(wowWData *data, GameClient *pSelf)
{
	//dontkillItem ++;
	//while( killingItem > 0 );
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
	{
		if (((GameClient*)(*itr))->IsInWorld() && (*itr) != pSelf)  // dont send to self!
			((GameClient*)(*itr))->SendMsg(data);
	}
	//dontkillItem --;
}
//Overloaded function, not second arguments so it truly send to -everyone-
void WorldServer::SendGlobalMessage(wowWData *data)
{
	//dontkillItem ++;
	//while( killingItem > 0 );
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
	{
		if (((GameClient*)(*itr))->IsInWorld())
			((GameClient*)(*itr))->SendMsg(data);
	}
	//dontkillItem --;
}

void WorldServer::SendUnitZoneMessage(wowWData* data, int zoneid, int mapid)
{


	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++){
		if (((GameClient*)(*itr))->IsInWorld())
		{
			if ((((GameClient*)(*itr))->getCurrentChar()->getZone() == zoneid) && (mapid == ((GameClient*)(*itr))->getCurrentChar()->getMapId()  ))
			{
				((GameClient*)(*itr))->SendMsg(data);
			}
		}
	}
}

void WorldServer::SendUnitAreaMessage(wowWData* data, Unit *pUnit)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++){
		if (((GameClient*)(*itr))->IsInWorld())
		{
			if ((CalcDistance(pUnit, (Unit *)((GameClient*)(*itr))->getCurrentChar() ) < UPDATE_DISTANCE) && 
                (pUnit->getMapId() == ((GameClient*)(*itr))->getCurrentChar()->getMapId()  ))
			{
				if (((GameClient*)(*itr))->getCurrentChar()->getZone() == pUnit->getZone()) {
					((GameClient*)(*itr))->SendMsg(data);
				}
			}
		}
	}
}

void WorldServer::SendZoneMessage(wowWData* data, GameClient *pSelf, int flag)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++){
		if (((GameClient*)(*itr))->IsInWorld())
		{
			if ((*itr) != pSelf)
			{
				if ((((GameClient*)(*itr))->getCurrentChar()->getZone() == pSelf->getCurrentChar()->getZone()) && (pSelf->getCurrentChar()->getMapId() == ((GameClient*)(*itr))->getCurrentChar()->getMapId()  ))
				{
					((GameClient*)(*itr))->SendMsg(data);
				}
			}
			else if (flag == 1){
				((GameClient*)(*itr))->SendMsg(data);
			}
		}
	}
}
//flag == 1 <-- sends to self
void WorldServer::SendAreaMessage(wowWData* data, GameClient *pSelf, int flag)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++){
		if (((GameClient*)(*itr))->IsInWorld())
		{
			if ((*itr) != pSelf)
			{
				if ( (CalcDistance( (Unit *)pSelf->getCurrentChar() , (Unit *)((GameClient*)(*itr))->getCurrentChar()) < UPDATE_DISTANCE) && 
                     (pSelf->getCurrentChar()->getMapId() == ((GameClient*)(*itr))->getCurrentChar()->getMapId()  ))
				{
					if (((GameClient*)(*itr))->getCurrentChar()->getZone() == pSelf->getCurrentChar()->getZone()) {
						((GameClient*)(*itr))->SendMsg(data);
					}
				}
			}
			else if (flag == 1){
				((GameClient*)(*itr))->SendMsg(data);
			}
		}
	}
}

float WorldServer::CalcDistance(Unit *pCa, Unit *pCb)
{
	float xdest = pCa->getPositionX() - pCb->getPositionX();
	float ydest = pCa->getPositionY() - pCb->getPositionY();
	float zdest = pCa->getPositionZ() - pCb->getPositionZ();
	return sqrt(zdest*zdest + ydest*ydest + xdest*xdest);
}

float WorldServer::CalcDistanceByPosition(Unit *pCa, float x, float y, float z)
{
	float xdest = pCa->getPositionX() - x;
	float ydest = pCa->getPositionY() - y;
	float zdest = pCa->getPositionZ() - z;
	return sqrt(zdest*zdest + ydest*ydest + xdest*xdest);
}

void WorldServer::SendWorldText(uint8 *text)
{
	wowWData data;
	mChatHandler.FillMessageData(&data, 0x09, 0, text);
	SendGlobalMessage(&data);
	return;
}

void WorldServer::SendWorldText(uint8 *text, GameClient *pSelf)
{
	wowWData data;
	mChatHandler.FillMessageData(&data, 0x09, 0, text);
	SendGlobalMessage(&data, pSelf);
	return;
}

int WorldServer::SendMessageToPlayer(wowWData *data, char* name)
{
	dontkillItem ++;
	while( killingItem > 0 );
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
	{
		if ( ((GameClient*)(*itr))->getCharacterName() ) {
			if (strcmp(((GameClient*)(*itr))->getCharacterName(), name)==0)
			{
				((GameClient*)(*itr))->SendMsg(data);
				dontkillItem --;
				return 1;
			}
		}
	}
	dontkillItem --;
	return 0;
}

int WorldServer::SendMessageToPlayer(wowWData *data, uint32 guid)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
	{
		if ( ((GameClient*)(*itr))->getCurrentChar() && ((GameClient*)(*itr))->getCurrentChar()->getGUID() == guid) 
		{
			((GameClient*)(*itr))->SendMsg(data);
			return 1;
		}
	}

	return 0;
}

uint32 WorldServer::addCreatureName(uint8* name)
{
	for( CreatureNameMap::iterator i = mCreatureNames.begin( ); i != mCreatureNames.end( ); ++ i ) 
	{
		if (i->second != NULL) {
			if (strcmp((char*)i->second, (char*)name) == 0)
				return (uint16)i->first;
		}
	}
    
    DatabaseInterface *dbi = Database::getSingleton( ).createDatabaseInterface( );

    char sql[512];
    sprintf(sql, "INSERT INTO creature_names (creature_name) VALUES ('%s')", name);
    uint32 returnvalue = dbi->doQueryId(sql);  
    Database::getSingleton( ).removeDatabaseInterface(dbi);

	char *new_name = new char[strlen((char*)name)+1];	//NAME PATCH ignatich
    strcpy(new_name, (char*)name);						//NAME PATCH ignatich
	mCreatureNames[returnvalue] = (uint8*)new_name;		//NAME PATCH ignatich

    return returnvalue;
}

GameClient * WorldServer::GetClientByName(char* name)
{
	ClientSet::iterator itr;
	for (itr = mClients.begin(); itr != mClients.end(); itr++)
	{
		if ( ((GameClient*)(*itr))->getCharacterName() )
		{
			if (strcmp(((GameClient*)(*itr))->getCharacterName(), name)==0)
			{
				dontkillItem --;
				return ((GameClient*)*itr);

			}
		}
	}
	return NULL;
}

Group * WorldServer::GetGroupByLeader(char* name)
{
	dontkillItem ++;
	while( killingItem > 0 );
	std::list< Group * >::iterator itr;
	for (itr = mGroupList.begin(); itr != mGroupList.end(); itr++)
	{
		if ( (*itr)->leadername ) 
		{
			if (strcmp((*itr)->leadername, name)==0)
			{
				dontkillItem --;
				return ((Group*)*itr);	
			}
		}
	}
	dontkillItem --;
	return NULL;
}


void WorldServer::AddGroup(Group* pGroup)
{
	mGroupList.push_back(pGroup);
}

void WorldServer::DelGroup(Group* pGroup)
{
	mGroupList.remove(pGroup);
}


void WorldServer::AddItem(Item* pItem)
{
	mItems[pItem->getUpdateValue(OBJECT_FIELD_ENTRY)] = pItem;
}

Item * WorldServer::GetItem(uint32 itemid)
{
	return mItems[itemid];
}

void WorldServer::CheckForInRangeObjects(Object* pObj)
{
	CharacterMap::iterator chriter;
	for( chriter = mCharacters.begin( ); chriter != mCharacters.end( ); ++ chriter )
	{
        Character *pChr = chriter->second;
        if (((Object*)pChr) != pObj && !pObj->IsInRangeSet(pChr) &&
            pChr->getMapId() == pObj->getMapId() && 
            pObj->getDistanceSq(pChr) <= UPDATE_DISTANCE*UPDATE_DISTANCE)
        {
            if (pObj->getObjectTypeId() == 4)
            {
                // Send a Create message for the new char and his items
                std::list<wowWData*> msglist;
                mObjectMgr.BuildCreatePlayerMsg(pChr, &msglist);

                std::list<wowWData*>::iterator msgitr;
                for (msgitr = msglist.begin(); msgitr != msglist.end(); )
                {
                    wowWData *msg = (*msgitr);
                    SendMessageToPlayer(msg, pObj->getGUID());
                    delete msg;
                    msgitr = msglist.erase(msgitr);
                }
            }

            // Object in range, add to set
            Log::getSingleton( ).outString("Added %s to InRange Set.\n", pChr->getName());
            pObj->AddInRangeObject(pChr);
        }
	}

    if (pObj->getObjectTypeId() == 4)   // Only add monsters to the list if this is a player
    {
	    CreatureMap::iterator iter;
	    for( iter = mCreatures.begin( ); iter != mCreatures.end( ); ++ iter )
		{
            Unit *pNpc = iter->second;
            // For each Creature, if it does NOT equal this Object, and it is not already in the set,
            //  and it is on the same map, and it is within range
            if (((Object*)pNpc) != pObj &&  !pObj->IsInRangeSet(pNpc) &&
                pNpc->getMapId() == pObj->getMapId() && 
                pObj->getDistanceSq(pNpc) <= UPDATE_DISTANCE*UPDATE_DISTANCE)
            {
                if (pObj->getObjectTypeId() == 4)
                {
                    // Send a Create message for the new char and his items
                    // but only if the object doing the check is a player
                    wowWData msg;
                    mObjectMgr.BuildCreateUnitMsg(pNpc, &msg, (Character*)pObj);

                    // make sure some data was actually filled in
                    if (msg.pointer > 0)
                        SendMessageToPlayer(&msg, pObj->getGUID());
                }

                // Object in range, add to set
                Log::getSingleton( ).outString("Added %s to InRange Set.\n", pNpc->getCreatureName());
                pObj->AddInRangeObject(pNpc);
            }
	    }
    } // end if player
}

// Updater
void WorldServer::initUpdates()
{
	m_updateTimer[UPDATE_SET].interval = 10000;
	m_updateTimer[UPDATE_OBJECT].interval = 100;
	m_updateTimer[UPDATE_LOGOUT].interval = 1000; 
	int i;
	for(i=0; i < UPDATE_COUNT; i++)
		m_updateTimer[i].currTime = 0;
}

void WorldServer::updateTimes(uint32 uTime)
{
	int i;
	for(i=0; i < UPDATE_COUNT; i++)
		m_updateTimer[i].currTime += uTime;	
}

bool WorldServer::updatePassed(int updateType)
{
	return m_updateTimer[updateType].currTime >= m_updateTimer[updateType].interval ? true : false;
}

void WorldServer::updateReset()
{
	int i;
	for(i=0; i < UPDATE_COUNT; i++)
		if (m_updateTimer[i].currTime >= m_updateTimer[i].interval)
			m_updateTimer[i].currTime -= m_updateTimer[i].interval;
}

//START OF LINA SAVEALL COMMAND
uint32 WorldServer::Save(char* who)
{
	uint8 buf[256];
	wowWData data;	
	WorldServer::ClientSet::iterator itr;
	int32 nbsave=0;

	sprintf((char*)buf,"Global character save by %s.",who);
	for (itr = WorldServer::getSingleton().mClients.begin(); itr != WorldServer::getSingleton().mClients.end(); itr++, nbsave++)
	{
		Character * pChar=((GameClient*)(*itr))->getCurrentChar();
		if(pChar)
		{
			((GameClient*)(*itr))->getDB()->setCharacter(pChar);
			mChatHandler.FillMessageData(&data, 0x09, ((GameClient*)(*itr)),buf);
			((GameClient*)(*itr))->SendMsg( &data );
		}
		else nbsave--;
	}
	return nbsave;
}
//END OF LINA SAVEALL COMMAND

	//LINA
	void WorldServer::setAttackGroupUnit(Unit * pUnite, Unit * pVictim) 
	{
		uint32 unitguid = pUnite->getGUID();
		WorldServer::CreatureMap::iterator itr;
		for (itr = mCreatures.begin(); itr != mCreatures.end(); itr++)
		{
			//if same race
			if(itr->second->getUpdateValue(UNIT_FIELD_DISPLAYID) == pUnite->getUpdateValue(UNIT_FIELD_DISPLAYID))
			{
				//if free of attack
				if(itr->second->m_creatureState != ATTACKING)
				{
					//if alive
					if(itr->second->isAlive())
					{
						//if group help
						if(itr->second->m_aggressive==2 || itr->second->m_aggressive==3)
						{
							//if near
							if ( CalcDistance(pUnite, itr->second) < 15)
							{
								itr->second->AI_MoveTo(pVictim->getPositionX(),pVictim->getPositionY(),pVictim->getPositionZ(), true);
								itr->second->AI_AttackReaction(pVictim,1);
								itr->second->AI_Update();
							}
						}
					}
				}
			}
		}
	}
