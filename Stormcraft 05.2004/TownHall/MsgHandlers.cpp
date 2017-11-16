// TODO: split this file up into multiple files.  One for combat, one for login, one for
// movement, etc.  Make extern declarations in MsgHandlers.h and/or split the 
// InstallGameMessageHandlers up as well
#include <time.h>

#include "MsgHandlers.h"
#include "Defines.h"
#include "Globals.h"
#include "Client.h"
#include "CreatureTemplate.h"
#include "Creature.h"
#include "DBCHandler.h"
#include "EventManager.h"
#include "UpdateBlock.h"
#include "Guild.h"
#include "Party.h"
#include "ChatManager.h"

void MsgPing(CClient *pClient, _InData *pData)
{
	pClient->OutPacket(SMSG_PONG,pData->Data,4);
}

void MsgAuth(CClient *pClient, _InData *pData)
{
#ifdef ACCOUNTLESS
	pClient->SendAuthResponse(0xC);
	return;
#endif
	if (pClient->pAccount)
	{
		pClient->DestroyMe=true;
		return;
	}

	// server responses
	// response 1  = failure
	// response 2  = cancelled
	// response 3  = disconnect
	// response 4  = failed to connect
	// response 5  = (connect)
	// response 6  = wrong client version
	// response 7  = connecting to server...
	// response 8  = negotiating security
	// response 9  = security negotiation complete
	// response a  = security negotiation failed
	// response b  = authenticating
	// response c  = authentication successful  (login complete...)
	// response d  = authentication failed
	// response e  = Rejected - Please contact Customer Support
	// response f  = server is not valid
	// response 10 = System unavailable - Please try again later
	// response 11 = system error
	// response 12 = billing system error
	// response 13 = account billing has expired
	// response 14 = wrong client version
	// response 15 = unknown account
	// response 16 = incorrect password
	// response 17 = session expired
	// response 18 = server shutting down
	// response 19 = already logging in
	// response 1a = invalid login server
	// response 1b = 
	// response 1c = retrieving realm list
	// response 1d = realm list retrieved
	// response 1e = unable to connect to realm list server
	// response 1f = invalid realm list
	// response 20 = realm is down
	// response 21 = creating account
	// response 22 = account created
	// response 23 = account creation failed
	// response 24 = retrieving character list
	// response 25 = character list retrieved
	// response 26 = error retrieving character list
	// response 27 = creating character
	// response 28 = (character created)
	// response 29 = error creating character
	// response 2A = character creation failed
	// response 2B = name already in use
	// response 2C = creation of that race and/or class is currently disabled
	// response 2d = deleting character
	// response 2e = character deleted
	// response 2f = character deletion failed
	// response 30 = entering the world of warcraft
	// response 31 = login successful

/*
______________________________________________________________
Outgoing Data :8086 len=002D op=01DE int=0000 msglen=0029 -- cclientconnection::handleauthchallenge

0000:  28 0D 00 00-00 00 00 00-78 0D 0A 79-0D 0A 0D 0A  (.......x..y....
0010:  00 2B A1 7B-6C 17 A8 40-D9 B4 33 86-69 64 20 26  .+í{l.¿@+¦3åid &
0020:  23 FB 33 73-3A 87 E0 5A-D6         -             #v3s:çaZ+       
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/
/*	pData->Data[pData->Read-1]=0;

	// find CRLF
	bool ended=false;
	int i;
	for (i = 8 ; i < pData->Read ; i++)
	{
		switch(pData->Data[i])
		{
		case 0x0d:
		case 0x0a:
			ended=true;
			pData->Data[i]=0;
			break;
		case 0:
			{
				pClient->SendAuthResponse(0xD); // auth failed
				return;
			}
			break;
		default:
			if (ended)
			{
				goto gotpassword;
			}
			break;
		}
	}
gotpassword:
	*/
	string name=&pData->Data[8];
	unsigned long namelen=name.length();
	if (namelen<3 || namelen>31)
	{
		pClient->SendAuthResponse(0xD); // auth failed
		return;
	}
	/*unsigned long pwlen=strlen(&pData->Data[i]);
	if (pwlen<5 || pwlen>31)
	{
		pClient->SendAuthResponse(0xD); // auth failed
		return;
	}*/
	char *password = "tehpass";

	bool Admin=(stricmp(&pData->Data[8],"admin")==0);
	if (Admin)
	{
		/*if (stricmp(password,Settings.admin_password))
		{
			pClient->SendAuthResponse(0x23); // auth failed
			return;
		}*/
	}

	MakeLower(name);
	if (unsigned long AccountID=DataManager.AccountNames[name])
	{
		// check password
		CAccount *pAccount=0;
		if (DataManager.RetrieveObject((CWoWObject**)&pAccount,OBJ_ACCOUNT,AccountID))
		{
			//strtok(&pData->Data[i],"\r\n");
			if (Admin )//|| !stricmp(pAccount->Data.Password,password))
			{
				if (pAccount->Data.UserLevel>=USER_NORMAL)
				{
					if (pAccount->pClient)
					{
						pClient->SendAuthResponse(0x19);
						pClient->DestroyMe=true;
					}
					else
					{
						if (pAccount->Data.UserLevel<Settings.MinUserLevel)
						{
							pClient->SendAuthResponse(0x10);
							pClient->DestroyMe=true;
						}
						else
						{
							pClient->pAccount=pAccount;
							pAccount->pClient=pClient;
							// grab characters
							for (int i = 0 ; i < 10 ; i++)
							{
								if (unsigned long CharID=pAccount->Data.Characters[i])
								{
									CPlayer *pPlayer=0;
									if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,CharID))
									{
										pClient->Characters[i]=pPlayer;
										pClient->nCharacters++;
									}
								}
							}
							pClient->SendAuthResponse(0xC); // success
						}
					}
				}
				else
				{
					pClient->SendAuthResponse(0xE); // rejected
					pClient->DestroyMe=true;
				}
			}
			else
			{
				pClient->SendAuthResponse(0x16); // invalid password
				pClient->DestroyMe=true;
			}
		}
		else
		{
			pClient->SendAuthResponse(0xD); // failed
			pClient->DestroyMe=true;
		}
	}
	else
	{
		if (Settings.AllowNewAccounts)
		{
			// new account
			CAccount *pNewAccount = new CAccount;
			pNewAccount->New();
			strcpy(pNewAccount->Data.Name,&pData->Data[8]);
			pNewAccount->pClient=pClient;
			pClient->pAccount=pNewAccount;
			if (Admin)
			{
				pNewAccount->Data.UserLevel=USER_ADMIN;
			}
			else
			{
				strcpy(pNewAccount->Data.Password,password);
			}
			DataManager.AccountNames[name]=pNewAccount->guid;
			DataManager.NewObject(*pNewAccount);
			if (Settings.MinUserLevel>pNewAccount->Data.UserLevel)
			{
				pClient->SendAuthResponse(0x10);
				pClient->DestroyMe=true;
			}
			else
			{
				pClient->SendAuthResponse(0xC);
			}
		}
		else
		{
			pClient->SendAuthResponse(0x10);
			pClient->DestroyMe=true;	
		}
	}
}

void MsgCharList(CClient *pClient, _InData *pData)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	pClient->SendCharacterList();
}

void MsgCreateCharacter(CClient *pClient, _InData *pData)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	if (pData->Data[0]==0)
	{
		char c=0x2A;
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	if (pClient->nCharacters>=10 || strlen(&pData->Data[0])>12)
	{
		// send failure code
		char c=0x28;
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	string Name=&pData->Data[0];
	
	MakeLower(Name);
	if (DataManager.PlayerNames[Name])
	{
		char c=0x2B;
		pClient->OutPacket(SMSG_CHAR_CREATE,&c,1);
		return;
	}
	// create character
	for (unsigned long i = 0 ; i < 10 ; i++)
	{
		if (!pClient->Characters[i])
		{
			pClient->Characters[i]=new CPlayer;
			pClient->Characters[i]->New(&pData->Data[0],(unsigned char *)&pData->Data[strlen(&pData->Data[0])+1]);
			DataManager.NewObject(*pClient->Characters[i]);
			pClient->nCharacters++;
#ifndef ACCOUNTLESS
			pClient->pAccount->Data.Characters[i]=pClient->Characters[i]->guid;
			pClient->Characters[i]->AccountID = pClient->pAccount->guid;
#endif
			break;
		}
	}

	// send accept code
	unsigned long N=0x28;
	pClient->OutPacket(SMSG_CHAR_CREATE,&N,4);
}

void MsgDeleteCharacter(CClient *pClient, _InData *pData)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	unsigned long N=*(unsigned long*)&pData->Data[0];
	N--;
	if (pClient->Characters[N])
	{
		pClient->Characters[N]->Delete();
		DataManager.DeleteObject(*pClient->Characters[N]);
		pClient->Characters[N]=0;
		pClient->nCharacters--;
#ifndef ACCOUNTLESS
		pClient->pAccount->Data.Characters[N]=0;
#endif
		
		// actually we're supposed to notify of delete but this works for now
		pClient->SendCharacterList();
	}
}

void MsgEnterGame(CClient *pClient, _InData *pData)
{
#ifndef ACCOUNTLESS
	if (!pClient->pAccount)
		return;
#endif
	InstallGameMessageHandlers(pClient);
	pClient->EnterGame(pData->Data[0]);
}

void MsgQuit(CClient *pClient, _InData *pData)
{
	pClient->OutPacket(SMSG_LOGOUT_COMPLETE,0,0);
	if (pClient->pPlayer)
	{
		pClient->pPlayer->EventsEligible=false;
		CParty *pParty = CParty::GetParty(pClient,false);
		if (pParty != NULL)
		{
			pParty->Leave(pClient->pPlayer->Data.Name);
			pClient->pPlayer->Data.PartyID = 0;
		}
		pClient->pPlayer->ClearEvents();
		RegionManager.ObjectRemove(*pClient->pPlayer);
		pClient->pPlayer->pClient=0;
		pClient->pPlayer=0;
	}
	RemoveGameMessageHandlers(pClient);

}


void MsgWorldPort(CClient *pClient, _InData *pData)
{
	if (pClient->pPlayer->Data.bSummoned) {
		pClient->Echo("Cant worldport when you've been summoned");
		return;
	}
	char buf[0x11];
	memset(buf,0,0x11);
	pClient->pPlayer->Data.Continent=buf[0]=pData->Data[4];
	memcpy(&buf[1],&pData->Data[5],0x10);
	pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
	memcpy(&pClient->pPlayer->Data.Loc,&buf[1],sizeof(_Location));
	pClient->pPlayer->Data.Facing=*(float*)&buf[0x0d];
	RegionManager.ObjectRemove(*pClient->pPlayer);
}

void MsgLoadNewWorld(CClient *pClient, _InData *pData)
{
	pClient->SendPlayerData(true);
	RegionManager.ObjectNew(*pClient->pPlayer,pClient->pPlayer->Data.Continent,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
}

void MsgPlayerName(CClient *pClient, _InData *pData)
{
	char buf[512];
	unsigned long ID=*(unsigned long*)&pData->Data[0];
	CPlayer *pPlayer=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,ID))
		return;

	*(unsigned long*)&buf[0]=ID;
	*(unsigned long*)&buf[4]=0;
	int c=8;
	strcpy(&buf[c],pPlayer->Data.Name);
	c+=strlen(&buf[c])+1;
	*(unsigned long*)&buf[c]=pPlayer->Data.Race;
	c+=4;
	*(unsigned long*)&buf[c]=pPlayer->Data.Female;
	c+=4;
	*(unsigned long*)&buf[c]=pPlayer->Data.Class;
	c+=4;
	pClient->OutPacket(SMSG_NAME_QUERY_RESPONSE,&buf[0],c);
}

void MsgNPCName(CClient *pClient, _InData *pData)
{
	unsigned long ID=*(unsigned long*)&pData->Data[0];
	CCreatureTemplate *pCreatureTemplate=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate,OBJ_CREATURETEMPLATE,ID))
		return;

	char buf[512];
	memcpy(&buf[0],&pData->Data[0],4);
	int c=4;
	strcpy(&buf[c],pCreatureTemplate->Data.Name);
	c+=strlen(&buf[c])+1;
	strcpy(&buf[c],pCreatureTemplate->Data.Name1);
	c+=strlen(&buf[c])+1;
	strcpy(&buf[c],pCreatureTemplate->Data.Name2);
	c+=strlen(&buf[c])+1;
	strcpy(&buf[c],pCreatureTemplate->Data.Name3);
	c+=strlen(&buf[c])+1;
	strcpy(&buf[c],pCreatureTemplate->Data.Guild);
	c+=strlen(&buf[c])+1;
	*(unsigned long*)&buf[c]=pCreatureTemplate->Data.Something1;// dunno
	c+=4;
	*(unsigned long*)&buf[c]=pCreatureTemplate->Data.Something2;// dunno
	c+=4;
	*(unsigned long*)&buf[c]=pCreatureTemplate->Data.Something3;// dunno
	c+=4;
	pClient->OutPacket(SMSG_CREATURE_QUERY_RESPONSE,&buf[0],c);
}

void MsgItem(CClient *pClient, _InData *pData)
{
	CItemTemplate *pItemTemplate=0;
	if (!DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,OBJ_ITEMTEMPLATE,*(unsigned long*)&pData->Data[0]))
		return;
	char buffer[sizeof(ItemTemplateData)];
	memset(&buffer[0],0,sizeof(ItemTemplateData));
	unsigned long nSize=pItemTemplate->GetItemTemplateInfoData(&buffer[0]);
	pClient->OutPacket(SMSG_ITEM_QUERY_SINGLE_RESPONSE,&buffer[0],(unsigned short)nSize);
}

void MsgSetGameUiTarget(CClient *pClient, _InData *pData)
{
	pClient->pPlayer->TargetID=*(unsigned long*)&pData->Data[0];
}

void MsgSetTarget(CClient *pClient, _InData *pData)
{
	//pClient->pPlayer->TargetID=*(unsigned long*)&pData->Data[0];
}


void MsgMove(CClient *pClient, _InData *pData)
{
	char Buffer[28];
	if (pClient->pPlayer->Data.bSummoned) {
/*
DIRECTION UNKNOWN Data len=001D op=00DA int=0000 msglen=0019 -- MonsterMoveEvent
0000:  B8 6A 00 00-00 10 00 F0-B4 A1 0B 45-CF FD F3 43  +j.....=¦í.E-²=C
0010:  EE 3A 1F 42-C0 BC 06 00-01         -             e:.B++...       
*/
		memset(&Buffer[0],0,0x19);
		*(unsigned long*)&Buffer[0]=pClient->pPlayer->guid;
		*(unsigned long*)&Buffer[4]=0;
		memcpy(&Buffer[0x8],&pClient->pPlayer->Data.Loc,0x0C);
		*(unsigned long*)&Buffer[0x14]=0x06BCC0;
		*(unsigned char*)&Buffer[0x18]=0x01;
		pClient->OutPacket(SMSG_MONSTER_MOVE,Buffer,0x19);
		pClient->Echo("You cant move when Summoned");
		return;
	}
	pClient->pPlayer->Data.Loc=*(_Location*)&pData->Data[4];//[8];
	pClient->pPlayer->Data.Facing=*(float*)&pData->Data[0x10];//[0x14];
	if (pClient->LastMoveFlags==0x00000200 && pClient->LastMoveFlags==*(unsigned long*)&pData->Data[0x0]) //[0x2C])
		return; // standing still...still.

	// tell others we're moving
	RegionManager.ObjectMovement(*pClient->pPlayer,pClient->pPlayer->Data.Loc.X,pClient->pPlayer->Data.Loc.Y);
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pClient->pPlayer->guid];
	if (!pPlayerRegion)
		return;
	*(unsigned long*)&Buffer[0]=pClient->pPlayer->guid;
	*(unsigned long*)&Buffer[4]=0;
	memcpy(&Buffer[0x8],&pData->Data[0],20);
	pClient->RegionOutPacketNotMe(pData->OpCode,Buffer, 28);
	//pClient->Echo("Move Facing %f.",pClient->pPlayer->Data.Facing);
	/*
	for (int i = 0 ; i < 3 ; i++)
	for (int j = 0 ; j < 3 ; j++)
	{
		if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
		{
			RegionObjectNode *pNode=pRegion->pList;
			while(pNode)
			{
				if (pNode->pObject->type==OBJ_PLAYER)
				{
					((CPlayer*)pNode->pObject)->pClient->OutPacket(pData->OpCode,Buffer,0x38);
				}
				pNode=pNode->pNext;
			}
		}
	}
	/**/
}

void MsgLearnSpell(CClient *pClient, _InData *pData)
{
	pClient->LearnedSpell(*(unsigned long*)&pData->Data[0]);
}

void MsgCastSpell(CClient *pClient, _InData *pData)
{
	/*
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-02 00 00 00-00 00 02 00-B8 6A 00 00  X...........+j..
0020:  00 10 00 F0-           -           -             ...=            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0009 op=0123 int=0000 msglen=0005 -- CastResultHandler

0000:  58 08 00 00-00         -           -             X....           
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=003A op=0125 int=0000 msglen=0036 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-82 00 01 B8-6A 00 00 00-10 00 F0 00  X...é..+j.....=.
0020:  42 00 B8 6A-00 00 00 10-00 F0 D4 9A-0B 45 09 F5  B.+j.....=+Ü.E.)
0030:  F4 43 9F F8-1C 42      -           -             (Cƒ°.B          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  B8 6A 00 00-00 10 00 F0-B8 6A 00 00-00 10 00 F0  +j.....=+j.....=
0010:  AA 0C 00 00-02 00 00 00-00 00 02 00-F5 45 01 00  ¬...........)E..
0020:  00 00 00 00-           -           -             ....            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=003A op=0125 int=0000 msglen=0036 -- SpellStartHandler

0000:  B8 6A 00 00-00 10 00 F0-B8 6A 00 00-00 10 00 F0  +j.....=+j.....=
0010:  AA 0C 00 00-80 00 01 F5-45 01 00 00-00 00 00 00  ¬...Ç..)E.......
0020:  42 00 F5 45-01 00 00 00-00 00 B1 AA-0B 45 CB BA  B.)E......¦¬.E-¦
0030:  F2 43 48 67-1C 42      -           -             =CHg.B          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  74 00 00 00-02 00 98 08-00 00 02 00-B8 6A 00 00  t.....ÿ.....+j..
0020:  00 10 00 F0-           -           -             ...=            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-02 00 00 00-00 00 02 00-B8 6A 00 00  X...........+j..
0020:  00 10 00 F0-           -           -             ...=            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

______________________________________________________________
DIRECTION UNKNOWN Data len=003A op=0125 int=0000 msglen=0036 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-82 00 01 B8-6A 00 00 00-10 00 F0 00  X...é..+j.....=.
0020:  42 00 B8 6A-00 00 00 10-00 F0 D4 9A-0B 45 09 F5  B.+j.....=+Ü.E.)
0030:  F4 43 9F F8-1C 42      -           -             (Cƒ°.B          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  B8 6A 00 00-00 10 00 F0-B8 6A 00 00-00 10 00 F0  +j.....=+j.....=
0010:  AA 0C 00 00-02 00 00 00-00 00 02 00-F5 45 01 00  ¬...........)E..
0020:  00 00 00 00-           -           -             ....            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=000A op=0123 int=0000 msglen=0006 -- CastResultHandler

0000:  85 00 00 00-02 25      -           -             à....%          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

______________________________________________________________
DIRECTION UNKNOWN Data len=0011 op=0126 int=0000 msglen=000D -- SpellFailedHandler

0000:  F5 45 01 00-00 00 00 00-74 00 00 00-11           )E......t....   
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=000A op=0123 int=0000 msglen=0006 -- CastResultHandler

0000:  74 00 00 00-02 11      -           -             t.....          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/
	// not yet recovered:
	/*
	char buffer[0x06];
	memcpy(&buffer[0],&pData->Data[0],4);
	buffer[4]=2;
	buffer[5]=0x11;
	pClient->OutPacket(SMSG_SPELL_FAILURE,buffer,0x06);
/**/

/*
______________________________________________________________
Outgoing Data :8086 len=0012 op=0121 int=0000 msglen=000E -- sendcast

0000:  58 08 00 00-02 00 02 00-00 00 00 10-00 F0        X............=  
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/

	unsigned short spell = *(unsigned short*)&pData->Data[0];
	unsigned long target = *(unsigned long*)&pData->Data[6];
	unsigned char buffer[0x90];
	CWoWObject *pTarget = NULL;

	if (pClient->pPlayer->Data.ResurrectionSickness)
	{
		pClient->InterruptCast(spell);
		pClient->Echo("You cant attack while you have resurrection sickness...please wait");
		return;
	}

	if (!pClient->pPlayer->ValidateSpell(target,spell)) {
		pClient->InterruptCast(spell);
		pClient->Echo("You do not have the knowledge to cast this spell or use this ability");
		return;
	}
		
	time_t now=time(0);

	if ((difftime(now,pClient->LastCast)<0.1)) // Since spell are now limited this should not be an issue ?
	{
		pClient->InterruptCast(spell);
		pClient->Echo("Slow down there, killer!");
		return;
	}

	memset(buffer,0,0x24);
	*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
	*(unsigned long*)&buffer[8]=pClient->pPlayer->guid;
	*(unsigned long*)&buffer[0x10]=spell;
	buffer[0x14]=2;
	buffer[0x1A]=2;
	
	
	if (pData->Data[4]==2)
	{
	// target monster
		memcpy(&buffer[0x1C],&pData->Data[6],8);
	}
	else
		*(unsigned long*)&buffer[0x1C]=pClient->pPlayer->guid;

	pClient->OutPacket(SMSG_SPELL_START,buffer,0x24);

	memset(buffer,0,5);
	*(unsigned long*)&buffer[0x0]=spell;
	pClient->OutPacket(SMSG_CAST_RESULT,buffer,5);

	pClient->LastCast=now;
	pClient->pPlayer->UseMana(DMGTYPE_SPELL,spell);
	if (DataManager.RetrieveObject((CWoWObject**)&pTarget,target))
	{
		pTarget->ApplySpell(*pClient->pPlayer, spell, *(unsigned long*)&pData->Data[10]);
	}	

	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_MANA, pClient->pPlayer->Data.CurrentStats.Mana);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
/*
______________________________________________________________
DIRECTION UNKNOWN Data len=003A op=0125 int=0000 msglen=0036 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-82 00 01 B8-6A 00 00 00-10 00 F0 00  X...é..+j.....=.
0020:  42 00 B8 6A-00 00 00 10-00 F0 D4 9A-0B 45 09 F5  B.+j.....=+Ü.E.)
0030:  F4 43 9F F8-1C 42      -           -             (Cƒ°.B          
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/

/*
______________________________________________________________
DIRECTION UNKNOWN Data len=0009 op=0123 int=0000 msglen=0005 -- CastResultHandler

0000:  58 08 00 00-00         -           -             X....           
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/
/*
______________________________________________________________
DIRECTION UNKNOWN Data len=0028 op=0124 int=0000 msglen=0024 -- SpellStartHandler

0000:  F5 45 01 00-00 00 00 00-F5 45 01 00-00 00 00 00  )E......)E......
0010:  58 08 00 00-02 00 00 00-00 00 02 00-B8 6A 00 00  X...........+j..
0020:  00 10 00 F0-           -           -             ...=            
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**/
}

void MsgEmote(CClient *pClient, _InData *pData)
{
	unsigned long emote_code = *(unsigned long*) &pData->Data[0];
	unsigned long emote_target = *(unsigned long*) &pData->Data[4];
	unsigned long emote_targettype = *(unsigned long*) &pData->Data[8];
	unsigned long animation = DBCManager.EmotesText.getValue(emote_code, DBC_EMOTESTEXT_ANIM);
	
	// PERMANENT EMOTES (= emotes you need to turn off)
	//              sit             stand             sleep (doesn't work)
	if (emote_code == 0x56 || emote_code == 0x8D || emote_code == 0x57)
	{
		//sit
		//01|00|00|00|00|7C|7F|01|00|00|00|00|00|14|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|10|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|01|00|00|01|
		//stand
		//01|00|00|00|00|7C|7F|01|00|00|00|00|00|14|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|10|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|01|
		//dance
		//   | emote    | guid      |           |  ???      |           |           |           |           |   ???     |           |           |           |           |           |           |           |           |           |           |           |           |           |              |anim |state?|              
		//01|00|00|00|00|7C|7F|01|00|00|00|00|00|14|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|04|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|00|0A|00|00|00|

		char buffer[0x90];
		int endAnim = 0;

		if(emote_code == 0x8D || (emote_code == 0x56 && pClient->pPlayer->Data.StandState == 1))
		{
			pClient->pPlayer->Data.StandState = 0;
		}
		else if(emote_code == 0x56)
		{
			pClient->pPlayer->Data.StandState = 1;
		}
		else if(emote_code == 0x57)
		{
			pClient->pPlayer->Data.StandState = 3;
		}
		CUpdateBlock block;
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(UNIT_BYTES_1, pClient->pPlayer->Data.WeaponMode << 24 | (pClient->pPlayer->Data.StandState & 0xF));
		int outSize;
		char *ptr = block.GetCompressedData(outSize);
		if(outSize)
			pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, outSize);

		if (!endAnim)
		{
			char buffer2[13];
			memset(buffer2, 0x0, 13);
			*(unsigned long*)&buffer2[0] = emote_target;
			*(unsigned long*)&buffer2[4] = emote_targettype;
			*(unsigned long*)&buffer2[8] = emote_code;
			pClient->OutPacket(SMSG_TEXT_EMOTE, &buffer2, 13);
		}
	
	} else
	{
/*
		char buffer[13];
		memset(buffer, 0x0, 13);
		//buffer[0] = getAnimation(emote_code);
		*(unsigned long*)&buffer[0] = animation;
		*(unsigned long*)&buffer[4] = emote_target;
		*(unsigned long*)&buffer[8] = emote_targettype;
		pClient->OutPacket(SOP_EMOTE_PLAY, buffer, 12);
	
		memset(buffer, 0x0, 13);
		*(unsigned long*)&buffer[0] = emote_target;
		*(unsigned long*)&buffer[4] = emote_targettype;
		*(unsigned long*)&buffer[8] = emote_code;
		pClient->OutPacket(SMSG_TEXT_EMOTE, &buffer, 13);
		*/
		
		
// Animation packet
		char buffer[76];
		memset(buffer, 0x00, 76);
		*(unsigned long*)&buffer[0] = animation;
//		*(unsigned long*)&buffer[4] = emote_targettype;
		*(unsigned long*)&buffer[4] = pClient->pPlayer->guid;
		pClient->OutPacket(SMSG_EMOTE, buffer, 12);
		

// Text packet
		int plen = 13;
		char target_name[64];
		memset(buffer, 0x00, 76);
		if (emote_target && emote_target != pClient->pPlayer->guid)
		{
			CCreature *pCreature = 0;
			if (DataManager.RetrieveObject((CWoWObject**)&pCreature, OBJ_CREATURE, emote_target))
			{
				CCreatureTemplate *pCreatureTemplate=0;
				if (DataManager.RetrieveObject((CWoWObject**)&pCreatureTemplate, OBJ_CREATURETEMPLATE, pCreature->Data.Template))
				{
					strcpy(&target_name[0], pCreatureTemplate->Data.Name);
					if (strlen(target_name) > 0)
						plen += strlen(target_name);
				}
			}
			else
			{
				CPlayer *pPlayer = 0;
				if (DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, emote_target))
				{
						strcpy(&target_name[0], pPlayer->Data.Name);
						if (strlen(target_name) > 0)
							plen += strlen(target_name);
				}
			}
		}
		
		*(unsigned long*)&buffer[0] = pClient->pPlayer->guid;
//		*(unsigned long*)&buffer[4] = emote_targettype;
		*(unsigned long*)&buffer[8] = emote_code;
		if (plen > 13)
			strcpy(&buffer[12], target_name);
		
//		pClient->OutPacket(SMSG_TEXT_EMOTE, &buffer, plen);
		pClient->Emote((unsigned long)pClient->pPlayer->guid, (unsigned long)animation, (unsigned long)emote_code, (unsigned long)emote_target, (char *)&target_name, plen, (unsigned long) emote_targettype);
	}
}

void MsgAttackOn(CClient *pClient, _InData *pData);

void MsgAttackOn(CClient *pClient, _InData *pData)
{
	unsigned char buffer[0x3D];

	_timeb now;
	_ftime(&now);
	unsigned long diff = (unsigned long)EventManager.DiffTime(now, pClient->pPlayer->LastAttack);
	unsigned long delay = pClient->pPlayer->Data.AttackSpeed;
	if (delay > diff) {
		return;
	}

	if (pClient->pPlayer->Data.ResurrectionSickness) {
		memset(buffer,0,0x14);
		*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
		*(unsigned long*)&buffer[0x08]=*(unsigned long*)&pData->Data[0];
		*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[4];
		*(unsigned long*)&buffer[0x10]=0x00;
		pClient->OutPacket(SMSG_ATTACKSTOP,buffer,0x14);
		pClient->Echo("You cant attack while you have resurrection sickness...please wait");
		return;
	}

	CPlayer *pPlayer=NULL;
	CCreature *pCreature=NULL;
  unsigned long CreatureGuid;
	*(unsigned long*)&CreatureGuid=*(unsigned long*)&pData->Data[0];  // to whom
	DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,CreatureGuid);
	if (pPlayer != NULL) {
		if (!(pClient->pPlayer->Data.PvP)) {
			pClient->Echo("You cant attack others unless you set PvP (type 'pvp' in the SAY box) and they are also PvP");
			return;
		}
	}
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if (pCreature == NULL && pPlayer == NULL)
	{
		memset(buffer,0,0x14);
		*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
		*(unsigned long*)&buffer[0x08]=*(unsigned long*)&pData->Data[0];
		*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[4];
		*(unsigned long*)&buffer[0x10]=0x00;
		pClient->RegionOutPacket(SMSG_ATTACKSTOP,buffer,0x14);
		return;
	}
	_ftime(&pClient->pPlayer->LastAttack); // set last attack before it's too late!

	// start attack
	memset(buffer,0,0x10);
	*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
	*(unsigned long*)&buffer[0x08]=*(unsigned long*)&pData->Data[0];
	*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[4];
	pClient->RegionOutPacket(SMSG_ATTACKSTART,buffer,0x10);
	
	// Temporary way to check if player has a ranged weapon equipped
	// and attack with a ranged weapon
	CItem *pItem = NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,pClient->pPlayer->Data.Items[SLOT_RANGED]))
	{
		CItemTemplate *pTemplate = NULL;
		if (pItem && DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_ITEMTEMPLATE,pItem->Data.nItemTemplate))
		{
			CWoWObject *pTarget = NULL;
			if (!pCreature)
				DataManager.RetrieveObject((CWoWObject**)&pTarget,OBJ_PLAYER,CreatureGuid);
			else
				pTarget = pCreature;

			if (pTarget && pTemplate &&
				(pTemplate->Data.Subtype ==  2 ||  // bow
				 pTemplate->Data.Subtype ==  3 ||  // gun 
				 pTemplate->Data.Subtype == 16 ||  // throwing
				 pTemplate->Data.Subtype == 19))   // wand
			{
				unsigned long abilityID;

				switch (pTemplate->Data.Subtype)
				{
				case 2:
					abilityID = 0x003B;
					break;
				case 3:
					abilityID = 0x07A7;
					break;
				case 16:
					abilityID = 0x0ACC;
					break;
				case 19:
					abilityID = 0x139B;
					break;
				}

				pTarget->ApplySpell(*pClient->pPlayer,abilityID,*(unsigned long*)&pData->Data[4]);

				return;
			}
		}
	}

	int flag=0;
	long dmg = pClient->pPlayer->CalculateDmg(DMGTYPE_WEAPON,0, flag);
	//static unsigned char code = 0x00;
	/// first byte is a bit flag 
	//bit 0: 0 = hit, 1 = miss
	//bit 4: 1 = crit
	//NOTE: 	memset(buffer,0,0x39);
	*(int*)&buffer[0x00]=flag; //0xE2;  // bit flag
	*(unsigned long*)&buffer[0x04]=pClient->pPlayer->guid;  // who is dishing out dmg
	*(unsigned long*)&buffer[0x08]=0;
	*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[0];  // to whom
	*(unsigned long*)&buffer[0x10]=*(unsigned long*)&pData->Data[4];
	*(unsigned long*)&buffer[0x14]=dmg;  // dmg shown in main window

	*(unsigned char*)&buffer[0x18]=0x01;  // DamageCount
	*(unsigned long*)&buffer[0x19]=0x00; // DamageType
	*(unsigned long*)&buffer[0x1D]=0x00; // damageFloat
	*(unsigned long*)&buffer[0x21]=dmg;  // dmg shown in rt window
	*(unsigned long*)&buffer[0x25]=0x00; // DamageAbsorbed

	*(unsigned long*)&buffer[0x29]=VS_WOUND;  // if not 1 - doesnt show up
	*(unsigned long*)&buffer[0x2D]=0x3E8;  // victimRoundDuration

	*(unsigned long*)&buffer[0x31]=0x00;
	*(unsigned long*)&buffer[0x35]=0x00;  // if not 0 (then spell dmg) and dont show - assumes 1D will show
	//code++;

	pClient->RegionOutPacket(SMSG_ATTACKERSTATEUPDATE,buffer,0x39, ATTACKDIST);

//	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	// note: the "correct" way would be to do if (DataManager.RetrieveObject(xxxx)) {}
	// :)
	int hitlist=0;
	int i;
	bool StopAttack = false;
	if (pCreature != NULL) 
	{
		pCreature->Data.CurrentStats.HitPoints -= dmg;
		for (i = 0 ; i < 50 ; i++)
		{
			if (pCreature->XP[i].hitguid == pClient->pPlayer->Data.PartyID || pCreature->XP[i].hitguid == pClient->pPlayer->guid)
			{
				if (pClient->pPlayer->Data.PartyID != 0 || pCreature->XP[i].hitguid == pClient->pPlayer->guid)
				{
					hitlist = i;
				}
			}
		}
		pCreature->XP[hitlist].dmg += dmg;
		if (pClient->pPlayer->Data.PartyID != 0)
		{
			pCreature->XP[hitlist].hitguid = pClient->pPlayer->Data.PartyID;
		}
		else
		{
			pCreature->XP[hitlist].hitguid = pClient->pPlayer->guid;
		}

		if ((long)(pCreature->Data.CurrentStats.HitPoints) <= 0 && !pCreature->dead) 
		{
			pCreature->ClearEvents();
			pCreature->bAttacking = false;
			pCreature->bMoving = false;
			pCreature->dead = true;
			EventManager.AddEvent(*pCreature,30000,EVENT_CREATURE_DESPAWN,0,0);

			// check who got the xp
			hitlist = 0;
			for (i = 0 ; i < 49 ; i++)
			{
				if (pCreature->XP[hitlist].dmg < pCreature->XP[i + 1].dmg)
				{
					hitlist = i + 1;
				}
			}
			CParty *pParty = NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pParty, OBJ_PARTY, pCreature->XP[hitlist].hitguid))
			{
				CPlayer *pKiller=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pKiller,OBJ_PLAYER, pParty->Data.Members[0]))
				{
					EventManager.AddEvent(*pKiller, 0, EVENT_PLAYER_GAINEXP, &pCreature->Data.Exp, sizeof(pCreature->Data.Exp));
					pCreature->SendLootablePacket(pKiller);
					StopAttack = true;
				}
			}
			else
			{
				CPlayer *pKiller=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pKiller,OBJ_PLAYER, pCreature->XP[hitlist].hitguid))
				{
					EventManager.AddEvent(*pKiller, 0, EVENT_PLAYER_GAINEXP, &pCreature->Data.Exp, sizeof(pCreature->Data.Exp));
					pCreature->SendLootablePacket(pKiller);
					StopAttack = true;
				}
			}
			memset(&pCreature->XP,0,sizeof(pCreature->XP));
		}
		else 
		{
			pCreature->FacePlayer(pClient->pPlayer);
			pCreature->TargetID = pClient->pPlayer->guid;
			if (!pCreature->bAttacking)
				pCreature->Attack();
		}
		if ((!pCreature->bMoving) && (pCreature->Data.CurrentStats.HitPoints > 0))
		{
			RegionManager.ObjectResend(*pCreature);
		}
	}
	else 
	{  // Try PvP
		CPlayer *pPlayer=NULL;
		DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,CreatureGuid);
		if (pPlayer && pPlayer->pClient) 
		{
			if (pClient->pPlayer->Data.PvP) 
			{
				pPlayer->Data.CurrentStats.HitPoints -= dmg;
				if(pPlayer->Data.CurrentStats.HitPoints < 0)
					pPlayer->Data.CurrentStats.HitPoints = 0;
				if ((long)(pPlayer->Data.CurrentStats.HitPoints) <= 0 && !pPlayer->dead) 
				{
					pPlayer->dead = true;
					pPlayer->ClearEvents();
					unsigned long AddExp=150;
					EventManager.AddEvent(*pClient->pPlayer, 0, EVENT_PLAYER_GAINEXP, &AddExp, sizeof(AddExp));
					char killer[50];
					sprintf(killer, "You have been slain by %s", pClient->pPlayer->Data.Name);
					pPlayer->pClient->Echo(killer);
					StopAttack = true;
				}
				CUpdateBlock block;
				char buffer[0x90];
				block.ResetBlock(buffer, 0x90);
				block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
				block.Add(UNIT_HEALTH, pPlayer->Data.CurrentStats.HitPoints);
				int size;
				char *ptr = block.GetCompressedData(size);
				if(size)
					pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
			}
			else 
				pClient->Echo("You cant attack others unless you set PvP");
		}
	}

	if(StopAttack)
	{
		memset(buffer,0,0x14);
		*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
		*(unsigned long*)&buffer[0x08]=*(unsigned long*)&pData->Data[0];
		*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[4];
		*(unsigned long*)&buffer[0x10]=0x01;
		pClient->RegionOutPacket(SMSG_ATTACKSTOP,buffer,0x14);
	}
	else
	{
		_timeb now;
		_ftime(&now);
		unsigned long diff = (unsigned long)EventManager.DiffTime(now, pClient->pPlayer->LastAttack);
		unsigned long delay = pClient->pPlayer->Data.AttackSpeed;
		EventManager.AddEvent(*(pClient->pPlayer),delay - diff,EVENT_PLAYER_END_ATTACK,pData->Data,8);
	}
}

void MsgAttackOff(CClient *pClient, _InData *pData)
{
	unsigned char buffer[0x3D];

/*  Seems to end combat turn
<Lax> DIRECTION UNKNOWN Data len=0018 op=0137 int=0000 msglen=0014 -- OnUnitCombatEvent
<Lax> 0000:  F5 45 01 00-00 00 00 00-B8 6A 00 00-00 10 00 F0  )E......+j.....=
<Lax> 0010:  00 00 00 00-           -           -             ....            
*/
	memset(buffer,0,0x14);
	*(unsigned long*)&buffer[0]=pClient->pPlayer->guid;
//	*(unsigned long*)&buffer[0x08]=*(unsigned long*)&pData->Data[0];
//	*(unsigned long*)&buffer[0x0C]=*(unsigned long*)&pData->Data[4];
	pClient->RegionOutPacket(SMSG_ATTACKSTOP,buffer,0x14);
	pClient->pPlayer->ClearEvents(EVENT_PLAYER_END_ATTACK);
}

void MsgRepop(CClient *pClient, _InData *pData)
{
	// This happens when you die... so lets some some death flags
	pClient->pPlayer->Data.CurrentStats.HitPoints=1;
	pClient->pPlayer->Data.CurrentStats.Mana=1;
	pClient->pPlayer->Data.ResurrectionSickness = true;
	pClient->pPlayer->dead = false;

	char buf[0x11];
	memset(buf,0,0x11);
	buf[0]=(char)pClient->pPlayer->Data.Continent;
	memcpy(&buf[1],&pClient->pPlayer->Data.Loc,sizeof(_Location));
	memcpy(&buf[0x0d],&pClient->pPlayer->Data.Facing,sizeof(float));
	pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
	RegionManager.ObjectRemove(*pClient->pPlayer);
	pClient->Echo("You have died, and need time to rest before fighting again...");
	EventManager.AddEvent(*(pClient->pPlayer),10000,EVENT_PLAYER_REGENERATE,0,0);
	EventManager.AddEvent(*(pClient->pPlayer),60000,EVENT_PLAYER_REZSICKNESS,0,0);
}

void MsgLootUnit(CClient *pClient, _InData *pData)
{
/*
DIRECTION UNKNOWN Data len=001F op=0153 int=0000 msglen=001B -- OnLootEvent
0000:  B8 6A 00 00-00 10 00 F0-01 00 00 00-00 01 00 3C  +j.....=.......<
0010:  0B 00 00 01-00 00 00 04-1A 00 00   -             ...........     
*/
	unsigned char buffer[0x1B];

	memset(buffer,0,0x1B);
	*(unsigned long*)&buffer[0x00]=*(unsigned long*)&pData->Data[0];
	*(unsigned long*)&buffer[0x04]=*(unsigned long*)&pData->Data[4];
	*(unsigned char*)&buffer[0x08]=0x01;
	*(unsigned short*)&buffer[0x0D]=0x01;
	*(unsigned short*)&buffer[0x0F]=0x0A;   // item id
	*(unsigned long*)&buffer[0x13]=0x01;
	*(unsigned short*)&buffer[0x17]=0x1A04;     // model id
	pClient->OutPacket(SMSG_LOOT_RESPONSE,buffer,0x1B);
}

void MsgSetWeaponMode(CClient *pClient, _InData *pData)
{
	pClient->pPlayer->Data.WeaponMode=pData->Data[0];
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_BYTES_1,pClient->pPlayer->Data.WeaponMode << 24 | (pClient->pPlayer->Data.StandState & 0xF));
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	pClient->Echo("Changing weapon mode...");
}

void MsgStandState(CClient *pClient, _InData *pData)
{
	pClient->pPlayer->Data.StandState = pData->Data[0];
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_BYTES_1,pClient->pPlayer->Data.WeaponMode << 24 | (pClient->pPlayer->Data.StandState & 0xF));
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void MsgStoreLoot(CClient *pClient, _InData *pData)
{
/*
______________________________________________________________
DIRECTION UNKNOWN Data len=000C op=0195 int=0000 msglen=0008 -- OnQuestUpdate

0000:  3C 0B 00 00-01 00 00 00-           -             <.......        
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
______________________________________________________________
DIRECTION UNKNOWN Data len=0005 op=0155 int=0000 msglen=0001 -- OnLootEvent

0000:  00         -           -           -             .               
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
	unsigned char buffer[0x01];

	memset(buffer,0,0x01);
	pClient->OutPacket(SMSG_LOOT_REMOVED,buffer,0x01);
}


void MsgLootResponse(CClient *pClient, _InData *pData)
{
/*
DIRECTION UNKNOWN Data len=0019 op=0159 int=0000 msglen=0015 -- OnPlayerEvent
0000:  F5 45 01 00-00 00 00 00-00 00 00 00-01 00 00 00  )E..............
0010:  FF 3C 0B 00-00         -           -              <...           

DIRECTION UNKNOWN Data len=000D op=0154 int=0000 msglen=0009 -- OnLootEvent
0000:  B8 6A 00 00-00 10 00 F0-01         -             +j.....=.       
*/
	unsigned char buffer1[0x15];
	unsigned char buffer2[0x09];

	// this one gives loot message
	memset(buffer1,0,0x15);
	*(unsigned long*)&buffer1[0x00]=pClient->pPlayer->guid;
	*(unsigned long*)&buffer1[0x0C]=0x01;
	*(unsigned char*)&buffer1[0x10]=0xFF;
	*(unsigned short*)&buffer1[0x11]=0x0A;  // which item
	pClient->OutPacket(SMSG_ITEM_PUSH_RESULT,buffer1,0x15);


	// This one terminates looting
	memset(buffer2,0,0x09);
	*(unsigned long*)&buffer2[0x00]=*(unsigned long*)&pData->Data[0];
	*(unsigned long*)&buffer2[0x04]=*(unsigned long*)&pData->Data[4];
	*(unsigned char*)&buffer2[0x08]=0x01;
	pClient->OutPacket(SMSG_LOOT_RELEASE_RESPONSE,buffer2,0x09);
}

void MsgListInventory(CClient *pClient, _InData *pData)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid=*(unsigned long*)&pData->Data[0];
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL)
		pCreature->ListInventory(pClient); // let it call the empty virtual function
											// incase it's not a merchant
}

void MsgBuyItem(CClient *pClient, _InData *pData)
{
	CCreature* pCreature = NULL;
	unsigned long CreatureGuid=*(unsigned long*)&pData->Data[0];
	unsigned long nItem = *(unsigned long*)&pData->Data[8];
	DataManager.RetrieveObject((CWoWObject**)&pCreature,OBJ_CREATURE,CreatureGuid);
	if(pCreature != NULL)
		pCreature->BuyItem(pClient, nItem); // let it call the empty virtual function
											// incase it's not a merchant
}
void MsgWho(CClient *pClient, _InData *pData)
{
	char buffer[0x1024];
	memset(buffer,0,0x1024);
	long nplayer=0;
	int c=8;
	*(unsigned long*)&buffer[0x00]=nplayer; // number of ppl in the list
	*(unsigned long*)&buffer[0x04]=0x00; // sort type ?
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pClient->pPlayer->guid];
	if (!pPlayerRegion)
	{
		pClient->OutPacket(SMSG_WHO,buffer,0x04); //empty list if you alone
	}
	else {
		for (int i = 0 ; i < 3 ; i++) {
			for (int j = 0 ; j < 3 ; j++)
			{
				if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
				{
					RegionObjectNode *pNode=pRegion->pList;
					while(pNode)
					{
						if (pNode->pObject->type==OBJ_PLAYER)
						{
							if (pClient->pPlayer->Distance(*((CPlayer*)pNode->pObject))<WHODIST) {
									nplayer++;
									strcpy(&buffer[c],((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.Name);
									c+=strlen(&buffer[c])+2;
									*(unsigned long*)&buffer[c]=((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.Level;
									c+=4;
									*(unsigned long*)&buffer[c]=((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.Class;
									c+=4;
									*(unsigned long*)&buffer[c]=((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.Race;
									c+=4;
									*(unsigned long*)&buffer[c]=((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.Zone;
									c+=4;
									*(unsigned long*)&buffer[c]=((CPlayer*)pNode->pObject)->pClient->pPlayer->Data.LFG;
									c+=4;
							}
						}
						pNode=pNode->pNext;
					}
				}
			}
		}
	}
/*
	*(unsigned long*)&buffer[0x00]=nplayer; // number of ppl in the list
	*(unsigned long*)&buffer[0x04]=0x00; // sort type ?
	*(unsigned long*)&buffer[0x08]=0x656C7953; // name
	*(unsigned long*)&buffer[0x0C]=0x0000746E;
	*(unsigned long*)&buffer[0x10]=0x0D;  // level
	*(unsigned long*)&buffer[0x14]=0x04;  // class
	*(unsigned long*)&buffer[0x18]=0x03;  // race
	*(unsigned long*)&buffer[0x1C]=0x01;  // zone id
	*(unsigned long*)&buffer[0x20]=0x00;  // group
*/
	*(unsigned long*)&buffer[0x00]=nplayer; // number of ppl in the list
	*(unsigned long*)&buffer[0x04]=0x00; // sort type ?
	pClient->OutPacket(SMSG_WHO,buffer,c);

}

void MsgLFG(CClient *pClient, _InData *pData)
{
	char buf[0x04];
	memset(buf,0,0x04);
	if (pClient->pPlayer->Data.LFG == 0) {
		pClient->pPlayer->Data.LFG = (unsigned short)1;
	}
	else {
		pClient->pPlayer->Data.LFG = (unsigned short)0;
	}
	pClient->OutPacket(CMSG_SET_LOOKING_FOR_GROUP,buf,0x04);
}

void SendInventoryFailure(CClient *pClient, int result, unsigned long itemguid1, unsigned long itemguid2, int bagslot, int levelError)
{
	char buffer[0x16];
	
	buffer[0] = (char)result;
	unsigned short c = 1;
	if(result == BAG_LEVEL_MISMATCH)
	{
		*(unsigned long*)&buffer[c] = levelError;
		c += 4;
	}
	*(unsigned long*)&buffer[c] = itemguid1;
	c += 4;
	*(unsigned long*)&buffer[c] = itemguid1 ? 0x40000000 : 0;
	c += 4;

	*(unsigned long*)&buffer[c] = itemguid2;
	c += 4;
	*(unsigned long*)&buffer[c] = itemguid2 ? 0x40000000 : 0;
	c += 4;
	buffer[c] = (char)bagslot;
	c++;
	pClient->OutPacket(SMSG_INVENTORY_CHANGE_FAILURE, buffer, c);
}

void MsgDestroyItem(CClient *pClient, _InData *pData)
{
	int bag = pData->Data[0];
	int bagslot = pData->Data[1];
	char buffer[0x90];
	CUpdateBlock block;
	int size;
	char *ptr;
	if(bag == -1)
	{
		pClient->pPlayer->DestroyItem(bagslot);
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+bagslot*2, pClient->pPlayer->Data.Items[bagslot], ITEMGUID_HIGH);
		ptr = block.GetCompressedData(size);
		if(size)
			pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	}
	else
	{
		pClient->Echo("Destroying in bags not support yet. bag = %d slot = %d", bag, bagslot);
	}
}

void MsgSwapItem(CClient *pClient, _InData *pData)
{
	int bag1 = pData->Data[0];
	int bag1slot = pData->Data[1];
	int bag2 = pData->Data[2];
	int bag2slot = pData->Data[3];
	unsigned long *pItemslot1, *pItemslot2, temp;
	if(bag1 == -1)
	{
		pItemslot1 = &pClient->pPlayer->Data.Items[bag1slot];
	}
	else
	{
		// no bags yet
		return;
	}
	if(bag2 == -1)
	{
		pItemslot2 = &pClient->pPlayer->Data.Items[bag2slot];
	}
	else
	{
		// no bags yet
		return;
	}
	temp = *pItemslot1;
	*pItemslot1 = *pItemslot2;
	*pItemslot2 = temp;

	char buffer[0x90];
	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	if(bag1slot < bag2slot)
	{
		block.Add(PLAYER_INV_SLOTS+bag1slot*2, pClient->pPlayer->Data.Items[bag1slot], ITEMGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+bag2slot*2, pClient->pPlayer->Data.Items[bag2slot], ITEMGUID_HIGH);		
	}
	else
	{
		block.Add(PLAYER_INV_SLOTS+bag2slot*2, pClient->pPlayer->Data.Items[bag2slot], ITEMGUID_HIGH);		
		block.Add(PLAYER_INV_SLOTS+bag1slot*2, pClient->pPlayer->Data.Items[bag1slot], ITEMGUID_HIGH);
	}
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void MsgSwapInvItem(CClient *pClient, _InData *pData)
{
	int slot1 = pData->Data[0];
	int slot2 = pData->Data[1];
	unsigned long temp;
	temp = pClient->pPlayer->Data.Items[slot1];
	pClient->pPlayer->Data.Items[slot1] = pClient->pPlayer->Data.Items[slot2];
	pClient->pPlayer->Data.Items[slot2] = temp;
	char buffer[0x90];
	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	if(slot1 < slot2)
	{
		block.Add(PLAYER_INV_SLOTS+slot1*2, pClient->pPlayer->Data.Items[slot1], ITEMGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+slot2*2, pClient->pPlayer->Data.Items[slot2], ITEMGUID_HIGH);		
	}
	else
	{
		block.Add(PLAYER_INV_SLOTS+slot2*2, pClient->pPlayer->Data.Items[slot2], ITEMGUID_HIGH);		
		block.Add(PLAYER_INV_SLOTS+slot1*2, pClient->pPlayer->Data.Items[slot1], ITEMGUID_HIGH);
	}
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

int InvTypeToInvSlot[WORN_NUM_TYPES] = {
	SLOT_INBACKPACK, // NONE EQUIP
		SLOT_HEAD,
		SLOT_NECK,
		SLOT_SHOULDERS,
		SLOT_SHIRT,
		SLOT_CHEST,
		SLOT_WAIST,
		SLOT_LEGS,
		SLOT_FEET,
		SLOT_WRISTS,
		SLOT_HANDS,
		SLOT_FINGERL,
		SLOT_TRINKETL,
		SLOT_MAINHAND, // 1h
		SLOT_OFFHAND, // shield
		SLOT_RANGED,
		SLOT_BACK,
		SLOT_MAINHAND, // 2h
		SLOT_BAG1,
		SLOT_TABARD,
		SLOT_CHEST, // ROBE
		SLOT_MAINHAND, // mainhand
		SLOT_OFFHAND, // offhand
		SLOT_MAINHAND, // held
		SLOT_INBACKPACK, // ammo
		SLOT_RANGED, // thrown
		SLOT_RANGED // rangedright
};

void MsgAutoEquipItem(CClient *pClient, _InData *pData)
{
	int bag = pData->Data[0];
	int bagslot = pData->Data[1];
	if(bag != -1)
	{
		pClient->Echo("Moving from and to bags not supported yet.");
		return;
	}

	unsigned long *pItemSlot;
	if(bag == -1)
	{
		pItemSlot = &pClient->pPlayer->Data.Items[bagslot];
	}
	else
	{
		// no bags yet
		return;
	}
	CItem *pItem = NULL;
	if(!(*pItemSlot) || !DataManager.RetrieveObject((CWoWObject**)&pItem, *pItemSlot))
		return; // should be some error reporting
	CItemTemplate *pTemplate = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate, pItem->Data.nItemTemplate))
		return;
	unsigned long newSlot = InvTypeToInvSlot[pTemplate->Data.InvType];
	if(newSlot == SLOT_INBACKPACK || newSlot == SLOT_BAG1)
	{
		SendInventoryFailure(pClient, BAG_NOT_EQUIPPABLE, pItem->guid, 0, 0, 0);
		return;
	}
	if(pClient->pPlayer->Data.Items[newSlot] != 0)
	{
		if(newSlot == SLOT_MAINHAND)
		{
			if((pTemplate->Data.InvType == WORN_1H || pTemplate->Data.InvType == WORN_HELD)
				&& pClient->pPlayer->Data.Items[SLOT_OFFHAND] == 0)
			{
				newSlot = SLOT_OFFHAND;
			}
		}
		else if(newSlot == SLOT_FINGERL)
		{
			if(pClient->pPlayer->Data.Items[SLOT_FINGERR] == 0)
				newSlot = SLOT_FINGERR;
		}
		else if(newSlot == SLOT_TRINKETL)
		{
			if(pClient->pPlayer->Data.Items[SLOT_TRINKETR] == 0)
				newSlot = SLOT_TRINKETR;
		}
	}

	unsigned long temp = *pItemSlot;
	*pItemSlot = pClient->pPlayer->Data.Items[newSlot];
	pClient->pPlayer->Data.Items[newSlot] = temp;

	char buffer[0x90];
	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	if(bagslot < newSlot)
	{
		block.Add(PLAYER_INV_SLOTS+bagslot*2, pClient->pPlayer->Data.Items[bagslot], ITEMGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+newSlot*2, pClient->pPlayer->Data.Items[newSlot], ITEMGUID_HIGH);		
	}
	else
	{
		block.Add(PLAYER_INV_SLOTS+newSlot*2, pClient->pPlayer->Data.Items[newSlot], ITEMGUID_HIGH);		
		block.Add(PLAYER_INV_SLOTS+bagslot*2, pClient->pPlayer->Data.Items[bagslot], ITEMGUID_HIGH);
	}
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void MsgAutoStoreBagItem(CClient *pClient, _InData *pData)
{
	int bag1 = pData->Data[0];
	int bag1slot = pData->Data[1];
	int bag2 = pData->Data[2];
	if(bag1 != -1 || bag2 != -1)
		return;
	int newSlot = -1;
	for (int i = SLOT_INBACKPACK ; i < SLOT_INBACKPACK+16 ; i++)
	{
		if (pClient->pPlayer->Data.Items[i]==0)
		{
			newSlot = i;
			break;
		}
	}
	if(newSlot == -1)
	{
		SendInventoryFailure(pClient, BAG_FULL, pClient->pPlayer->Data.Items[bag1slot], 0, 0, 0);
		return;
	}
	unsigned long temp = pClient->pPlayer->Data.Items[bag1slot];
	pClient->pPlayer->Data.Items[bag1slot] = 0;
	pClient->pPlayer->Data.Items[newSlot] = temp;
	char buffer[0x90];
	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	if(bag1slot < newSlot)
	{
		block.Add(PLAYER_INV_SLOTS+bag1slot*2, pClient->pPlayer->Data.Items[bag1slot], ITEMGUID_HIGH);
		block.Add(PLAYER_INV_SLOTS+newSlot*2, pClient->pPlayer->Data.Items[newSlot], ITEMGUID_HIGH);		
	}
	else
	{
		block.Add(PLAYER_INV_SLOTS+newSlot*2, pClient->pPlayer->Data.Items[newSlot], ITEMGUID_HIGH);		
		block.Add(PLAYER_INV_SLOTS+bag1slot*2, pClient->pPlayer->Data.Items[bag1slot], ITEMGUID_HIGH);
	}
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}
// This either needs to be absolute last in this file, or the functions need to have
// forward declarations.  To keep it cleaner, leave it last ;)
#define AddMsgHandler(opcode,function) pClient->MessageHandlers[opcode]=function;
void InstallMessageHandlers(CClient *pClient)
{

	AddMsgHandler(CMSG_PING,MsgPing);
	AddMsgHandler(CMSG_AUTH_SESSION,MsgAuth);
	AddMsgHandler(CMSG_CHAR_ENUM,MsgCharList);
	AddMsgHandler(CMSG_CHAR_CREATE,MsgCreateCharacter);
	AddMsgHandler(CMSG_CHAR_DELETE,MsgDeleteCharacter);
	AddMsgHandler(CMSG_PLAYER_LOGIN,MsgEnterGame);
}
/**/

void InstallGameMessageHandlers(CClient *pClient)
{
	AddMsgHandler(CMSG_LOGOUT_REQUEST,MsgQuit);
	AddMsgHandler(CMSG_MESSAGECHAT,CChatManager::MsgChat);
	AddMsgHandler(CMSG_WORLD_TELEPORT,MsgWorldPort);
	AddMsgHandler(MSG_MOVE_WORLDPORT_ACK,MsgLoadNewWorld);
	AddMsgHandler(CMSG_NAME_QUERY,MsgPlayerName);
	AddMsgHandler(CMSG_CREATURE_QUERY,MsgNPCName);
	AddMsgHandler(CMSG_ITEM_QUERY_SINGLE,MsgItem);
	AddMsgHandler(CMSG_SET_SELECTION,MsgSetGameUiTarget);
	AddMsgHandler(CMSG_SET_TARGET,MsgSetTarget);
	AddMsgHandler(CMSG_CAST_SPELL,MsgCastSpell);
	AddMsgHandler(MSG_MOVE_HEARTBEAT,MsgMove);
	AddMsgHandler(MSG_MOVE_START_FORWARD,MsgMove);
	AddMsgHandler(MSG_MOVE_START_BACKWARD,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP,MsgMove);
	AddMsgHandler(MSG_MOVE_START_TURN_LEFT,MsgMove);
	AddMsgHandler(MSG_MOVE_START_TURN_RIGHT,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_TURN,MsgMove);
	AddMsgHandler(MSG_MOVE_SET_FACING,MsgMove);
	AddMsgHandler(MSG_MOVE_START_STRAFE_LEFT,MsgMove);
	AddMsgHandler(MSG_MOVE_START_STRAFE_RIGHT,MsgMove);
	AddMsgHandler(MSG_MOVE_STOP_STRAFE,MsgMove);
	AddMsgHandler(CMSG_LEARN_SPELL,MsgLearnSpell);
	AddMsgHandler(CMSG_TEXT_EMOTE,MsgEmote);
	AddMsgHandler(CMSG_ATTACKSWING,MsgAttackOn);
	AddMsgHandler(CMSG_ATTACKSTOP,MsgAttackOff);
	AddMsgHandler(CMSG_REPOP_REQUEST,MsgRepop);
	AddMsgHandler(CMSG_LOOT,MsgLootUnit);
	AddMsgHandler(CMSG_AUTOSTORE_LOOT_ITEM,MsgStoreLoot);
	AddMsgHandler(SMSG_LOOT_RESPONSE,MsgLootResponse);
	AddMsgHandler(CMSG_SETWEAPONMODE,MsgSetWeaponMode);
	AddMsgHandler(CMSG_STANDSTATECHANGE, MsgStandState);
//	AddMsgHandler(CMSG_LIST_INVENTORY, MsgListInventory);
//	AddMsgHandler(CMSG_BUY_ITEM, MsgBuyItem);
//	AddMsgHandler(CMSG_BUY_ITEM_IN_SLOT, MsgBuyItem);
	AddMsgHandler(CMSG_WHO, MsgWho);
	//AddMsgHandler(CMSG_GROUP_INVITE, CParty::MsgGroupInvite);
	AddMsgHandler(CMSG_GROUP_CANCEL, CParty::MsgGroupCancel);
	AddMsgHandler(CMSG_GROUP_ACCEPT, CParty::MsgGroupAccept);    
	AddMsgHandler(CMSG_GROUP_DECLINE, CParty::MsgGroupDecline);
	AddMsgHandler(CMSG_GROUP_UNINVITE, CParty::MsgGroupUninvite);
	AddMsgHandler(CMSG_GROUP_UNINVITE_GUID, CParty::MsgGroupUninviteGuid);
	AddMsgHandler(CMSG_GROUP_SET_LEADER, CParty::MsgGroupSetLeader);
	AddMsgHandler(CMSG_LOOT_METHOD, CParty::MsgLootMethod);
	AddMsgHandler(CMSG_SET_LOOKING_FOR_GROUP,MsgLFG);
	AddMsgHandler(CMSG_GUILD_INVITE, CGuild::MsgGuildInvite);
	AddMsgHandler(CMSG_GUILD_ACCEPT, CGuild::MsgGuildAccept);
	AddMsgHandler(CMSG_GUILD_DECLINE, CGuild::MsgGuildDecline);
	AddMsgHandler(CMSG_GUILD_INFO, CGuild::MsgGuildInfo);
	AddMsgHandler(CMSG_GUILD_ROSTER, CGuild::MsgGuildRoster);
	AddMsgHandler(CMSG_GUILD_PROMOTE, CGuild::MsgGuildPromote);
	AddMsgHandler(CMSG_GUILD_DEMOTE, CGuild::MsgGuildDemote);
	AddMsgHandler(CMSG_GUILD_LEAVE, CGuild::MsgGuildLeave);
	AddMsgHandler(CMSG_GUILD_REMOVE, CGuild::MsgGuildRemove);
	AddMsgHandler(CMSG_GUILD_DISBAND, CGuild::MsgGuildDisband);
	AddMsgHandler(CMSG_GUILD_LEADER, CGuild::MsgGuildLeader);
	AddMsgHandler(CMSG_GUILD_MOTD, CGuild::MsgGuildMotd);
	AddMsgHandler(CMSG_GUILD_QUERY, CGuild::MsgGuildQuery);
	AddMsgHandler(MSG_TABARDVENDOR_ACTIVATE, CGuild::MsgTabardVendorActivate);
	AddMsgHandler(MSG_SAVE_GUILD_EMBLEM, CGuild::MsgSaveGuildEmblem);
	AddMsgHandler(CMSG_DESTROY_ITEM, MsgDestroyItem);
	AddMsgHandler(CMSG_SWAP_ITEM, MsgSwapItem);
	AddMsgHandler(CMSG_SWAP_INV_ITEM, MsgSwapInvItem);
	AddMsgHandler(CMSG_AUTOEQUIP_ITEM, MsgAutoEquipItem);
	AddMsgHandler(CMSG_AUTOSTORE_BAG_ITEM, MsgAutoStoreBagItem);
}

void RemoveGameMessageHandlers(CClient *pClient)
{
	AddMsgHandler(CMSG_LOGOUT_REQUEST,0);
	AddMsgHandler(CMSG_MESSAGECHAT,0);
	AddMsgHandler(CMSG_WORLD_TELEPORT,0);
	AddMsgHandler(MSG_MOVE_WORLDPORT_ACK,0);
	AddMsgHandler(CMSG_NAME_QUERY,0);
	AddMsgHandler(CMSG_CREATURE_QUERY,0);
	AddMsgHandler(CMSG_ITEM_QUERY_SINGLE,0);
	AddMsgHandler(CMSG_SET_TARGET,0);
	AddMsgHandler(CMSG_CAST_SPELL,0);
	AddMsgHandler(MSG_MOVE_HEARTBEAT,0);
	AddMsgHandler(MSG_MOVE_START_FORWARD,0);
	AddMsgHandler(MSG_MOVE_START_BACKWARD,0);
	AddMsgHandler(MSG_MOVE_STOP,0);
	AddMsgHandler(MSG_MOVE_START_TURN_LEFT,0);
	AddMsgHandler(MSG_MOVE_START_TURN_RIGHT,0);
	AddMsgHandler(MSG_MOVE_STOP_TURN,0);
	AddMsgHandler(MSG_MOVE_SET_FACING,0);
	AddMsgHandler(MSG_MOVE_START_STRAFE_LEFT,0);
	AddMsgHandler(MSG_MOVE_START_STRAFE_RIGHT,0);
	AddMsgHandler(MSG_MOVE_STOP_STRAFE,0);
	AddMsgHandler(CMSG_LEARN_SPELL,0);
	AddMsgHandler(CMSG_TEXT_EMOTE,0);
	AddMsgHandler(CMSG_ATTACKSWING,0);
	AddMsgHandler(CMSG_ATTACKSTOP,0);
	AddMsgHandler(CMSG_REPOP_REQUEST,0);
	AddMsgHandler(CMSG_LOOT,0);
	AddMsgHandler(CMSG_AUTOSTORE_LOOT_ITEM,0);
	AddMsgHandler(SMSG_LOOT_RESPONSE,0);
	AddMsgHandler(CMSG_SET_SELECTION,0);
	AddMsgHandler(CMSG_SETWEAPONMODE,0);
	AddMsgHandler(CMSG_STANDSTATECHANGE,0);
//	AddMsgHandler(CMSG_LIST_INVENTORY,0);
//	AddMsgHandler(CMSG_BUY_ITEM, 0);
//	AddMsgHandler(CMSG_BUY_ITEM_IN_SLOT, 0);
	AddMsgHandler(CMSG_WHO, 0);
	//AddMsgHandler(CMSG_GROUP_INVITE,0);
	AddMsgHandler(CMSG_GROUP_CANCEL,0);
	AddMsgHandler(CMSG_GROUP_ACCEPT,0);
	AddMsgHandler(CMSG_GROUP_DECLINE,0);
	AddMsgHandler(CMSG_GROUP_UNINVITE,0);
	AddMsgHandler(CMSG_GROUP_UNINVITE_GUID,0);
	AddMsgHandler(CMSG_GROUP_SET_LEADER,0);
	AddMsgHandler(CMSG_LOOT_METHOD, 0);
	AddMsgHandler(CMSG_SET_LOOKING_FOR_GROUP,0);
	AddMsgHandler(CMSG_GUILD_INVITE, 0);
	AddMsgHandler(CMSG_GUILD_ACCEPT, 0);
	AddMsgHandler(CMSG_GUILD_DECLINE, 0);
	AddMsgHandler(CMSG_GUILD_INFO, 0);
	AddMsgHandler(CMSG_GUILD_PROMOTE, 0);
	AddMsgHandler(CMSG_GUILD_DEMOTE, 0);
	AddMsgHandler(CMSG_GUILD_LEAVE, 0);
	AddMsgHandler(CMSG_GUILD_REMOVE, 0);
	AddMsgHandler(CMSG_GUILD_DISBAND, 0);
	AddMsgHandler(CMSG_GUILD_LEADER, 0);
	AddMsgHandler(CMSG_GUILD_MOTD, 0);
	AddMsgHandler(CMSG_GUILD_QUERY, 0);
	AddMsgHandler(MSG_TABARDVENDOR_ACTIVATE, 0);
	AddMsgHandler(MSG_SAVE_GUILD_EMBLEM, 0);
	AddMsgHandler(CMSG_DESTROY_ITEM, 0);
	AddMsgHandler(CMSG_SWAP_ITEM, 0);
	AddMsgHandler(CMSG_SWAP_INV_ITEM, 0);
	AddMsgHandler(CMSG_AUTOEQUIP_ITEM, 0);
	AddMsgHandler(CMSG_AUTOSTORE_BAG_ITEM, 0);
}
#undef AddMsgHandler

