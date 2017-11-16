// (c) AbyssX Group
#include "NetworkEnvironment.h"

LPacket::LPacket()
{
}

LPacket::~LPacket()
{
}

bool LPacket::FromInput(Client *cli)
{
	if (cli->GetInBuffer().length() <  4)
		return false; // need at least 2 byte opcode and 2 byte len

	char *ptr = (char *)&mPacket.opcode;
	ptr[0] = (char)cli->GetInBuffer().at(0);
	ptr[1] = (char)0x00;

	bool special = false;

	switch (mPacket.opcode)
	{
		case CHALLENGE:

			mPacket.len = cli->GetInBuffer().at(2);
			special = true;
			break;

		case RECODE_CHALLENGE:

			mPacket.len = cli->GetInBuffer().at(2);
			special = true;
			break;

		case PROOF:

			mPacket.len = 0x68;
			break;

		case RECODE_PROOF:

			mPacket.len = 0x58;
			break;

		case REALMLIST_REQUEST:

			mPacket.len = 0x05;
			break;

		case PLAYERS_UPDATE:

			mPacket.len = 0x04;
			break;
	}

	if (cli->GetInBuffer().length() < mPacket.len)
		return false; // don't have the complete packet yet
	if ((mPacket.len - 2) > (Word) sizeof(mPacket.data))
		return false; // can't handle packets that large
	
	if (mPacket.len > 2)
	{
		if (special == false)
			memcpy(&mPacket.data, cli->GetInBuffer().substr(3).c_str(), mPacket.len); 
		else
			memcpy(&mPacket.data, cli->GetInBuffer().substr(4).c_str(), mPacket.len); 
	}

	cli->GetInBuffer().erase(0, mPacket.len);

	return true;
}

DoubleWord LPacket::GetOpCode(void)
{
	return mPacket.opcode;
}

Word LPacket::GetDataLength(void)
{
	return mPacket.len;
}

Word LPacket::GetByteAfterString(Word byte)
{
	while (mPacket.data[byte] != 0x00)
		byte++;
	return byte + 1;
}

Byte LPacket::GetByte(Word byte)
{
	return mPacket.data[byte];
}

Byte *LPacket::GetBytes(Word byte)
{
	return mPacket.data + byte;
}

Word LPacket::GetWord(Word byte)
{
	return *((Word *)(mPacket.data + byte));
}

DoubleWord LPacket::GetDoubleWord(Word byte)
{
	return *((DoubleWord *)(mPacket.data + byte));
}

QuadWord LPacket::GetQuadWord(Word byte)
{
	return *((QuadWord *)(mPacket.data + byte));
}

Float LPacket::GetFloat(Word byte)
{
	return *((Float *)(mPacket.data + byte));
}

void LPacket::QuickCopy(LPacket *pack)
{
	mPacket.opcode = pack->mPacket.opcode;
	mPacket.len = 0;
	while (mPacket.len < pack->mPacket.len)
	{
		mPacket.data[mPacket.len] = pack->mPacket.data[mPacket.len];
		mPacket.len++;
	}
}

