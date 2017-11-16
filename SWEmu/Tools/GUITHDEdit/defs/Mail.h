struct MailData
{
	guid_t Sender; // CPlayer "From"
	guid_t Recipient; // CPlayer "To"
	guid_t AttachmentGuid; // CItem
	unsigned long Money;
	unsigned long COD; //keeps things simple
	unsigned long Flags;
	unsigned long Unknown; //defaults to "0x29" or 41
	unsigned long TimeSent;
	unsigned long TimeExpire;
	char Subject[64];
	char Text[512];
};