#ifndef PACKET_H
#define PACKET_H

#include "DataBuffer.h"

class IPacket
{
public:
	virtual char* GetData() = 0;
	virtual int GetLength() = 0;
};

class CPacket : public CDataBuffer, public IPacket
{
	bool m_finished;
public:
	CPacket()
	{
		m_finished = false;
	}

	CPacket(short msgID) // was unsigned int but this works !
	{
		m_finished = false;
		Write((short)0);
		Write(msgID);
	}

	CPacket(unsigned int msgID, int capacity) : CDataBuffer(capacity)
	{
		m_finished = false;
		Write((short)0);
		Write((unsigned short)msgID);
	}

	inline void Reset(int newMsgID)
	{
		m_position = 0;
		Write((short)0);
		Write((unsigned short)newMsgID);
		m_finished = false;
	}

	virtual char* GetData()
	{
		if(!m_finished)
		{
			unsigned short len = (unsigned short)(m_position-2);
			len = (len >> 8) | ((len & 0xFF) << 8);
			Set(0, len);
			m_finished = true;
		}
		return m_buffer;
	}

	inline virtual int GetLength()
	{
		return m_position;
	}
};

#endif // PACKET_H
