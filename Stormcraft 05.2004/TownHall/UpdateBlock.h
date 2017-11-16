#pragma once
#include "Globals.h"

class CUpdateBlock
{
public:
	inline CUpdateBlock(void *buffer, int maxBits)
	{
		char blocks = (char)(maxBits/32);
		if(maxBits % 32)
			blocks++;
		m_DataSize = 1+blocks*4;
		m_pData = (char*)buffer;
		*m_pData = blocks;
		m_pMask = &m_pData[1];
		m_pValues = &m_pData[1+blocks*4];
		m_ValPos = 0;
		m_pCompressed = NULL;
	}

	void AddDataUpdate(int maxBits, unsigned long guid, unsigned long guidHigh)
	{
		(*(unsigned long*)m_pBuffer)++;
		m_pData += m_ValPos;
		m_pData[0] = UPDATE_PARTIAL;
		m_pData++;
		*(unsigned long*)m_pData = guid;
		m_pData += 4;
		*(unsigned long*)m_pData = guidHigh;
		m_pData += 4;
		
		char blocks = (char)(maxBits/32);
		if(maxBits % 32)
			blocks++;
		*m_pData = blocks;
		m_pData++;

		m_DataSize += m_ValPos;
		m_DataSize += 1+blocks*4+9;
		
		m_pMask = m_pData;
		m_pData += blocks*4;
		m_pValues = m_pData;
		m_ValPos = 0;
	}

	// the allocated data here gets freed in the deconstructor
	char* GetCompressedData(int &size)
	{
		if(m_pCompressed == NULL)
		{
			int nSize = Compressor.Deflate(m_pBuffer, GetSize());
			if (!nSize)
			{
				size = 0;
				Debug.Log("CUpdateBlock::GetCompressedData(int&) - Deflate failed\n");
				return NULL;
			}
			size = nSize+4;
			m_CompressedSize = size;
			m_pCompressed = (char*)malloc(size);
			*(unsigned long*)m_pCompressed=GetSize();
			Compressor.GetBuffer(&m_pCompressed[4]);
		}
		else
		{
			size = m_CompressedSize;
		}
		return m_pCompressed;
	}

	char *GetCompressedData()
	{
		if(m_pCompressed == NULL)
		{
			unsigned long nSize = Compressor.Deflate(m_pBuffer, GetSize());
			if (!nSize)
			{
				Debug.Log("CUpdateBlock::GetCompressedData() - Deflate failed\n");
				return NULL;
			}
			m_CompressedSize = nSize+4;
			m_pCompressed = (char*)malloc(m_CompressedSize);
			*(unsigned long*)m_pCompressed=GetSize();
			Compressor.GetBuffer(&m_pCompressed[4]);
		}
		return m_pCompressed;
	}

	inline void ResetBlock(void *buffer, int bufsize)
	{
		m_pBuffer = buffer;
		memset(m_pBuffer, 0, bufsize);
		if(m_pCompressed != NULL)
		{
			free(m_pCompressed);
			m_pCompressed = NULL;
			m_CompressedSize = 0;
		}
		m_pData = (char*)buffer;
		*(unsigned long*)m_pData = 0;
		m_pData += 4;
		m_DataSize = 4;
		m_ValPos = 0;
	}

	// for data update
	inline CUpdateBlock(int bufsize, void *buffer)
	{
		m_pCompressed = NULL;
		m_CompressedSize = 0;
		ResetBlock(buffer, bufsize);
	}

	inline CUpdateBlock()
	{
		m_pCompressed = NULL;
		m_CompressedSize = 0;
	}

	inline ~CUpdateBlock(void)
	{
		if(m_pCompressed != NULL)
			free(m_pCompressed);
	}

	/*inline void SetCreateData(unsigned long MovementFlags, _Location &loc, float facing, 
		float walkSpeed, float runSpeed, float swimSpeed, float turnRate, unsigned long flags)
	{
		*(unsigned long*)m_pData = MovementFlags;
		m_pData += 0x04;
		*(_Location*)m_pData = loc;
		m_pData += 0x0C;//+0x10
		*(float*)m_pData = facing;
		m_pData += 0x04;//+0x14
		*(float*)m_pData = walkSpeed;
		m_pData += 0x04;//+0x18
		*(float*)m_pData = runSpeed;
		m_pData += 0x04;//+0x1C
		*(float*)m_pData = swimSpeed;
		m_pData += 0x04;//+0x20
		*(float*)m_pData = turnRate;
		m_pData += 0x04;//+0x24
		*(unsigned long*)m_pData = flags;
		m_pData += 0x04;//+0x28
	}*/


#define FAdd32(_DataType_) 	inline void Add(unsigned long nBit, _DataType_ Val)\
	{\
		SetBit(nBit);\
		*((_DataType_*)&m_pValues[m_ValPos]) = Val;\
		m_ValPos += 4;\
	}
	FAdd32(int);
	FAdd32(unsigned long);
	FAdd32(float);
	FAdd32(long);
	FAdd32(unsigned int);
#undef FAdd32
	inline void Add(unsigned long nBit, unsigned long ValLow, unsigned long ValHigh)
	{
		SetBit(nBit);
		SetBit(nBit+1);
		*((unsigned long*)&m_pValues[m_ValPos]) = ValLow;
		m_ValPos += 4;
		*((unsigned long*)&m_pValues[m_ValPos]) = ValHigh;
		m_ValPos += 4;
	}

	inline unsigned long GetSize() { return m_DataSize + m_ValPos; };
	inline int GetCompressedSize() { return m_CompressedSize;};
	//inline void* GetBuffer() { return m_pBuffer;};
private:
	void* m_pBuffer;
	char* m_pCompressed;
	int m_CompressedSize;
	int m_DataSize;
	char* m_pData;

	char* m_pMask;
	char* m_pValues;
	int m_ValPos;

	inline void SetBit(int n)
	{
		m_pMask[n/8] |= 1 << (n % 8);
	}
};
