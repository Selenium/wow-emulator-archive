#ifndef __MAIL_H
#define __MAIL_H

struct Mail
{
	uint32 messageID;
	uint32 sender;
	uint32 reciever;
	std::string subject;
	std::string body;
	uint32 item;
	time_t time;
	uint32 money;
	uint32 COD;
	uint32 checked;
};

#endif
