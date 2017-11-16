//////////////////////////////////////////////////////////////////////
//  Normal User Chat Commands
//
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "ChatHandler.h"
#include "NetworkInterface.h"
#include "GameClient.h"
#include "WorldServer.h"
#include "Character.h"
#include "Opcodes.h"
#include "Database.h"

bool ChatHandler::ShowHelpForCommand(ChatCommand *table, const char* cmd)
{
        uint32 AcctLvl = m_pClient->getAccountLvl();

        for(uint32 i = 0; table[i].Name != NULL; i++)
        {
                if(!hasStringAbbr(table[i].Name, cmd))
                        continue;

                if( AcctLvl < table[i].SecurityLevel)
                        continue;

                if(table[i].ChildCommands != NULL)
                {
                        cmd = strtok(NULL, " ");
                        if(cmd && ShowHelpForCommand(table[i].ChildCommands, cmd))
                                return true;
                }

                if(table[i].Help == "")
                {
                        NetworkPacket data;
                        FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no help for that command");
                        m_pClient->SendMsg(&data);
                        return true;
                }

                SendMultilineMessage(table[i].Help.c_str());

                return true;
        }

        return false;
}

bool ChatHandler::HandleHelpCommand(uint8* args)
{
        NetworkPacket data;

        if(!*args)
                return false;

        char* cmd = strtok((char*)args, " ");
        if(!cmd)
                return false;

        if(!ShowHelpForCommand(LoadHelp(false), cmd))
        {
                FillMessageData(&data, 0x09, m_pClient, (uint8*)"There is no such command");
                m_pClient->SendMsg( &data );
        }

        return true;
}

bool ChatHandler::HandleCommandsCommand(uint8* args)
{
        ChatCommand *table = LoadHelp(false);
        NetworkPacket data;
        char buf[256];
        bool first=true;
        uint32 AcctLvl = m_pClient->getAccountLvl();


        for(uint32 i = 0; table[i].Name != NULL; i++)
        {
                if( AcctLvl < table[i].SecurityLevel)
                        continue;

                if(*args)
                {
                        if(*args && !hasStringAbbr(table[i].Name, (char*)args))
                                continue;

                        if(table[i].ChildCommands != NULL)
                        {
                                FillMessageData(&data, 0x09, m_pClient, (uint8*)"Subcommands available to you");
                                m_pClient->SendMsg(&data);

                                ChatCommand *ptable = table[i].ChildCommands;
                                for(uint32 j = 0; ptable[j].Name != NULL; j++)
                                {
                                        if( AcctLvl < ptable[j].SecurityLevel)
                                                continue;

                                        sprintf(buf,"%s %s",table[i].Name, ptable[j].Name);
                                        FillMessageData(&data, 0x09, m_pClient,(uint8*) buf);
                                        m_pClient->SendMsg(&data);
                                }
                                return true;
                        }
                }

                if(first)
                {
                        first=false;
                        FillMessageData(&data, 0x09, m_pClient, (uint8*)"Commands available to you:");
                        m_pClient->SendMsg(&data);
                }
                if(table[i].ChildCommands != NULL)
                {
                        sprintf(buf,"%s (there are sub command)",table[i].Name);
                }
                else  sprintf(buf,"%s",table[i].Name);

                FillMessageData(&data, 0x09, m_pClient, (uint8*)buf);
                m_pClient->SendMsg(&data);
        }

        return true;
}



bool ChatHandler::HandleAcctCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;

        uint8 gmNum0 = m_pClient->getAccountLvl(); // get account level
        uint8 gmNum1[256];
        sprintf((char*)gmNum1,"Your account level is: %i", (int) gmNum0);
        FillMessageData(&data, 0x09, m_pClient, gmNum1);
        m_pClient->SendMsg( &data ); // send message

        return true;
}


bool ChatHandler::HandleGMLoginCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;

        if (!*args)
                return false;

        int gm = WorldServer::getSingletonPtr( )->dbi->getAccountLvl(m_pClient->getAccountID()); //fetches gm level
        char * pass = WorldServer::getSingletonPtr( )->dbi->getAccountPass(m_pClient->getAccountID()); //fetches pass
        if(!pass)
        {
                FillMessageData(&data, 0x09, m_pClient, (uint8*)"No password assigned.");
                m_pClient->SendMsg( &data );
                return true;
        }

        if (strcmp(pass, (char*)args) != 0)
        {
                FillMessageData(&data, 0x09, m_pClient, (uint8*)"Password do not match.");
                m_pClient->SendMsg( &data );
                return true;
        }

        m_pClient->setAccountLvl(gm);

        uint8 buf[256];
        sprintf((char*)buf,"You are now logined in as GM account with level : %i", (int) gm);
        FillMessageData(&data, 0x09, m_pClient, buf);
        m_pClient->SendMsg( &data ); // send message

        return true;
}

bool ChatHandler::HandleStartCommand(uint8* args)
{
	(void)args;
        uint8 theRace = m_pClient->getCurrentChar()->getRace();
        switch(theRace)
        {
        case 1: //HUMAN
                smsg_NewWorld(m_pClient, 0, -8949.95f, -132.493f, 83.5312f);
                break;
        case 2: //ORC
        case 8: //TROLL
                smsg_NewWorld(m_pClient, 1, -618.518f, -4251.67f, 38.718f);
                break;
        case 3: //DWARF
                smsg_NewWorld(m_pClient, 0, -6240.32f, 331.033f, 382.758f);
                break;
        case 4: //NIGHT ELF
                smsg_NewWorld(m_pClient, 1, 10311.3f, 832.463f, 1326.41f);
                break;
        case 5: //UNDEAD
                smsg_NewWorld(m_pClient, 0, 1676.35f, 1677.45f, 121.67f);
                break;
        case 6: //TAUREN
                smsg_NewWorld(m_pClient, 1, -2917.58f, -257.98f, 52.9968f);
                break;
        case 7: //GNOME
                smsg_NewWorld(m_pClient, 0, -10996.9f, -3427.67f, 61.996f);
                break;
        }
        return true;
}


bool ChatHandler::HandleInfoCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;

        uint32 clientsNum = WORLDSERVER.GetClientsConnected();
        uint8 buf[256];

        //more info come.. right now only display users connected
        sprintf((char*)buf,"Number of users connected: %i", (int) clientsNum);
        FillMessageData(&data, 0x09, m_pClient, buf);
        m_pClient->SendMsg( &data );

        return true;
}

bool ChatHandler::HandleMountCommand(uint8* args)
{
        NetworkPacket data;

        uint32 theLevel = m_pClient->getCurrentChar( )->getUpdateValue( UNIT_FIELD_LEVEL ); // get level
        uint16 mId=1147;
        float speed = (float)8;
        float wspeed = (float)4;

        uint8 theRace = m_pClient->getCurrentChar()->getRace();
        uint32 num=0;

        if (theLevel < 10 )
        {
                // If not level 10, then this text will be displayed
                uint8 helpMessage1[] = "You have to be atleast level 10 to use this command.";
                FillMessageData(&data, 0x09, m_pClient, helpMessage1);
                m_pClient->SendMsg( &data );
                return true;
        }
        else
        {
                char* pMount = strtok((char*)args, " ");

                if( pMount )
                {
                        num = atoi(pMount);
                        switch(num)
                        {
                        case 1: //nothing to do, min lvl mount lvl 10, lol
                                break;
                        case 2:
                                if(theLevel<15) num=1;
                                break;
                        case 3:
                                if(theLevel<20)
                                        if(theLevel<15) num=1;
                                        else
                                                num=2;
                                break;
                        default:
                                return true;
                        }
                }
                else
                {
                        if(theLevel>19) num=3;
                        else
                                if(theLevel>14) num=2;
                                else			num=1;
                }
                if (num > 2 )
                {
                        switch(theRace)
                        {
                        case 1: //HUMAN
                                mId=1147;
                                break;
                        case 2: //ORC
                                mId=295;
                                break;
                        case 3: //DWARF
                                mId=1147;
                                break;
                        case 4: //NIGHT ELF
                                mId=479;
                                break;
                        case 5: //UNDEAD
                                mId=1566;
                                break;
                        case 6: //TAUREN
                                mId=295;
                                break;
                        case 7: //GNOME
                                mId=1566;
                                break;
                        case 8: //TROLL
                                mId=479;
                                break;
                        }

                        speed=theLevel;
                        if(speed>25) speed=25;
                        wspeed=speed;
                }
                else if (num > 1 )
                {
                        switch(theRace)
                        {
                        case 1: //HUMAN
                                mId=1531;
                                break;
                        case 2: //ORC
                                mId=207; //need to change
                                break;
                        case 3: //DWARF
                                mId=2786;
                                break;
                        case 4: //NIGHT ELF
                                mId=720;
                                break;
                        case 5: //UNDEAD
                                mId=2346;
                                break;
                        case 6: //TAUREN
                                mId=180;
                                break;
                        case 7: //GNOME
                                mId=6569;
                                break;
                        case 8: //TROLL
                                mId=1340;
                                break;
                        }
                        speed=theLevel;
                        wspeed=speed/2;
                }
                else
                {
                        switch(theRace)
                        {
                        case 1: //HUMAN
                                mId=236;
                                break;
                        case 2: //ORC
                                mId=207;
                                break;
                        case 3: //DWARF
                                mId=2186;
                                break;
                        case 4: //NIGHT ELF
                                mId=632;
                                break;
                        case 5: //UNDEAD
                                mId=5050;
                                break;
                        case 6: //TAUREN
                                mId=1220;
                                break;
                        case 7: //GNOME
                                mId=6544;
                                break;
                        case 8: //TROLL
                                mId=3029;
                                break;
                        }
                        speed=theLevel;
                        wspeed=speed/2;
                }
        }

        m_pClient->getCurrentChar()->setUpdateValue( UNIT_FIELD_FLAGS , 0x001000 );
        m_pClient->getCurrentChar()->setUpdateValue( UNIT_FIELD_MOUNTDISPLAYID , mId);
        m_pClient->getCurrentChar()->setUpdateValue( UNIT_FIELD_FLAGS , 0x003000 );

        if(speed > 25) speed = 25;
        if(wspeed > 25/2) wspeed = 25/2;

        data.Initialize( 12, SMSG_FORCE_RUN_SPEED_CHANGE );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID + 1 );
        data << speed;
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );

        data.Initialize( 12, SMSG_FORCE_SWIM_SPEED_CHANGE );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID + 1 );
        data << wspeed;
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );

        uint8 cmount[256];
        sprintf((char*)cmount,"You have a level %i mount at %2.2f speed and %2.2f water speed.", num, speed, wspeed);
        FillMessageData(&data, 0x09, m_pClient, cmount);
        m_pClient->SendMsg( &data ); // send message

        return true;
}


bool ChatHandler::HandleDismountCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;

        m_pClient->getCurrentChar( )->setUpdateValue(UNIT_FIELD_MOUNTDISPLAYID , 0);
        m_pClient->getCurrentChar( )->removeUnitFlag( 0x003000 );

        // Remove the "player locked" flag, to allow movement
        if (m_pClient->getCurrentChar( )->getUpdateValue(UNIT_FIELD_FLAGS) & 0x000004 )
                m_pClient->getCurrentChar( )->removeUnitFlag( 0x000004 );

        float dspeed = 7.5; // Exact value of normal player speed
        float dwspeed = 3.25;

        data.Initialize( 12, SMSG_FORCE_RUN_SPEED_CHANGE );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID + 1 );
        data << dspeed;
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );

        data.Initialize( 12, SMSG_FORCE_SWIM_SPEED_CHANGE );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID );
        data << m_pClient->getCurrentChar( )->getUpdateValue( OBJECT_FIELD_GUID + 1 );
        data << dwspeed;
        m_pClient->getCurrentChar( )->SendMessageToSet( &data, true );

        return true;
}


bool ChatHandler::HandleSaveCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;

        uint8 Message[] ="Character saved.";
        m_pClient->getDB()->setCharacter( m_pClient->getCurrentChar( ) );
        FillMessageData(&data, 0x09, m_pClient,Message);
        m_pClient->SendMsg( &data );
        return true;
}


bool ChatHandler::HandleGMListCommand(uint8* args)
{
	(void)args;
        NetworkPacket data;
        bool first = true;

        WorldServer *world = WorldServer::getSingletonPtr();
        WorldServer::CharacterMap::iterator itr;
        for (itr = world->mCharacters.begin(); itr != world->mCharacters.end(); itr++)
        {
                if(itr->second->pClient->getAccountLvl())
                {
                        if(first)
                        {
                                FillMessageData(&data, 0x09, m_pClient, (uint8*)"There are following active GMs on this server:");
                                m_pClient->SendMsg( &data );
                        }

                        FillMessageData(&data, 0x09, m_pClient, (uint8*)itr->second->getName());
                        m_pClient->SendMsg( &data );

                        first = false;
                }
        }

        if(first)
        {
                FillMessageData(&data, 0x09, m_pClient, (uint8*)"There are no GMs currently logged in on this server.");
                m_pClient->SendMsg( &data );
        }

        return true;
}

bool ChatHandler::HandleGMPassCommand(uint8* args)
{
        NetworkPacket data;
        char* pOldPass = strtok((char*)args, " ");
        if (!pOldPass)
                return false;

        char* pNewPass = strtok(NULL, " ");
        if (!pNewPass)
                return false;

        uint8 buf[256];


        char * pass = WorldServer::getSingletonPtr( )->dbi->getAccountPass(m_pClient->getAccountID()); //fetches pass
        if (strcmp(pass,pOldPass) != 0)
        {
                if(strcmp(pass,"none") !=0)	sprintf((char*)buf,"Old Password do not match.");
                else sprintf((char*)buf,"Default pass: none.");
                FillMessageData(&data, 0x09, m_pClient, buf);
                m_pClient->SendMsg( &data );
                return true;
        }

        DatabaseInterface *dbi = DATABASE.createDatabaseInterface( );
        char sql[512];
        sprintf(sql, "UPDATE accounts SET realpassword = '%s' WHERE acct = '%u'", pNewPass, m_pClient->getAccountID());
        dbi->doQuery(sql);
        DATABASE.removeDatabaseInterface(dbi);

        sprintf((char*)buf,"You set you gm pass to %s", pNewPass);
        FillMessageData(&data, 0x09, m_pClient, buf);
        m_pClient->SendMsg( &data ); // send message

        return true;
}
