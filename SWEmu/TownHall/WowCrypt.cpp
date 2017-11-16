#include "WowCrypt.h"

#include <algorithm>

WowCrypt::WowCrypt()
{
	_initialized = false;
}

void WowCrypt::Init()
{
	_send_i = _send_j = _recv_i = _recv_j = 0;
	_initialized = true;
}

void WowCrypt::DecryptRecv(uint8 *data, size_t len)
{
	if (!_initialized) return;
	if (len < CRYPTED_RECV_LEN) return;

	for (size_t t = 0; t < CRYPTED_RECV_LEN; t++) {
		_recv_i %= _key.size();
		uint8 x = (data[t] - _recv_j) ^ _key[_recv_i];
		++_recv_i;
		_recv_j = data[t];
		data[t] = x;
	}
}

void WowCrypt::EncryptSend(uint8 *data, size_t len)
{
	if (!_initialized) return;
	if (len < CRYPTED_SEND_LEN) return;

	for (size_t t = 0; t < CRYPTED_SEND_LEN; t++) {
		_send_i %= _key.size();
		uint8 x = (data[t] ^ _key[_send_i]) + _send_j;
		++_send_i;
		data[t] = _send_j = x;
	}
}

void WowCrypt::SetKey(uint8 *key, size_t len)
{
	_key.resize(len);
	std::copy(key, key + len, _key.begin());
}

WowCrypt::~WowCrypt()
{
}
