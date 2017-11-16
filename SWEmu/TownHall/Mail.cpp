#include "Mail.h"
#include "EventManager.h"

CMail::CMail(void):CWoWObject(OBJ_MAIL)
{
	Clear();
}

CMail::~CMail(void)
{
}

void CMail::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(MailData));
}

void CMail::New()
{
	Clear();
	CWoWObject::New();
}

void CMail::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_MAIL_EXPIRE_CHECK:
		if(difftime(time(NULL),Data.TimeExpire)>=0) // positive *if* now >= Data.TimeExpire
		{
			CPlayer *pPlayer;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,Data.Recipient))
			{
				return;
			}
			pPlayer->Mails.remove(this);
			DataManager.DeleteObject(*this);
		}
		else EventManager.AddEvent(*this,3600000,EVENT_MAIL_EXPIRE_CHECK,0,0); // check every hour for expiry
		break;
	case EVENT_MAIL_DELIVER:
		{
			CPlayer *pPlayer;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,Data.Recipient))
			{
				return;
			}
			pPlayer->Mails.push_back(this);
			if(pPlayer->pClient) pPlayer->pClient->OutPacket(SMSG_RECEIVED_MAIL,"\x01",1);
		}
		break;
	}
}

bool CMail::StoringData(ObjectStorage &Storage)
{
	Storage.Allocate(sizeof(MailData));
	memcpy(Storage.Data,&Data,sizeof(MailData));
	return true;
}

bool CMail::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(MailData));
	return true;
}
