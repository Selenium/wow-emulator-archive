//******************************************************************************
#include "StdAfx.h"
#include "WowCrypt.h"
//==============================================================================
// This is simple constructor. It does not set key. You can set
// key later with corresponding property. Or you can live key empty
// if you need not encryption/decription.
WowCrypt::WowCrypt()
{
	encKeyIndex = encPrevCT = decKeyIndex = decPrevCT = 0;
}
// Decrypts packet's data if key was seted, or returns same data.
void WowCrypt::DecryptRecv(uint8 *data)
{
	if (key.size() == 0) return;

	for(size_t i=0; i<CRYPTED_RECV_LEN; i++)
	{
		uint8 tmp = data[i];
		data[i] = key[decKeyIndex] ^ (data[i] - decPrevCT);
		decPrevCT = tmp;
		++decKeyIndex;
		decKeyIndex %= KEY_LEN;
	}
}
// Encrypts packet's data if key was set, or returns same data.
void WowCrypt::EncryptSend(uint8 *data)
{
	if (key.size() == 0) return;

	for(size_t i=0; i<CRYPTED_SEND_LEN; i++)
	{
		data[i] = encPrevCT + (key[encKeyIndex]^data[i]);
		encPrevCT = data[i];
		++encKeyIndex;
		encKeyIndex %= KEY_LEN;
	}
}
// Sets Key. When Key was set, it uses for packets encryption/decryption.
void WowCrypt::SetKey(uint8 *key, size_t len)
{
	ASSERT(KEY_LEN == len);
	this->key.resize(len);
	std::copy(key, key + len, this->key.begin());
}
//******************************************************************************
