#ifndef MAIL_H
#define MAIL_H

#include "stdafx.h"
#include "WoWObject.h"

//flags are an internal concept. Eventually will need stuff for permanent copies & returned to sender.
#define MAIL_READ 0x01

struct MailData
{
	unsigned long Sender; // CPlayer "From"
	unsigned long Recipient; // CPlayer "To"
	unsigned long AttachmentGuid; // CItem
	unsigned long Money;
	unsigned long COD; //keeps things simple
	unsigned long Flags;
	unsigned long Unknown; //defaults to "0x29" or 41
	time_t TimeSent;
	time_t TimeExpire;
	char Subject[64];
	char Text[512];
};

class CMail : public CWoWObject
{
public:
	CMail(void);
	~CMail(void);

	MailData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(MailData);};
	void ProcessEvent(struct WoWEvent &Event);

	void Clear();
	void New();
};

#endif // MAIL_H
