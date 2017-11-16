#ifndef _WOWCRYPT_H
#define _WOWCRYPT_H

#include <Common.h>
#include <vector>

class WowCrypt {
public:
    WowCrypt();
    ~WowCrypt();

    const static int CRYPTED_SEND_LEN = 4;
    const static int CRYPTED_RECV_LEN = 6;

    void Init();

    void SetKey(uint8 *, size_t);

    void DecryptRecv(uint8 *, size_t);
    void EncryptSend(uint8 *, size_t);

    bool IsInitialized() { return _initialized; }

private:
    std::vector<uint8> _key;
    uint8 _send_i, _send_j, _recv_i, _recv_j;
    bool _initialized;
};

#endif
