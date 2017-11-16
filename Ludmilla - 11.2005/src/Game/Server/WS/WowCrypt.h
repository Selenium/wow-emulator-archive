//******************************************************************************
#ifndef _WOWCRYPT_H
#define _WOWCRYPT_H
//==============================================================================
class WowCrypt
	// It holds secret key (SS_Hash) for connection
	// and provides encryption/decryption methods for packets.
{
public:
	// This is simple constructor. It does not set key. You can set
	// key later with corresponding property. Or you can live key empty
	// if you need not encryption/decription.
    WowCrypt();

	// Block size for encryption
    const static int CRYPTED_SEND_LEN = 4;

	// Block size for decription
    const static int CRYPTED_RECV_LEN = 6;

	// Size of a key
    const static int KEY_LEN = 0x28;

	// Sets Key. When Key was set, it uses for packets encryption/decryption.
    void SetKey(uint8 *key, size_t len);


	// Decrypts packet's data if key was seted, or returns same data.
    void DecryptRecv(uint8 *data);
	
	// Encrypts packet's data if key was set, or returns same data.
    void EncryptSend(uint8 *data);

protected:

	// Key data for encryption/decription.
    std::vector<uint8> key;

	// "local" variables for Encrypt method:
	// key index and previous closed text.
	uint8 encKeyIndex, encPrevCT;

	// "local" variables for Decrypt method:
	// key index and previous closed text.
	uint8 decKeyIndex, decPrevCT;
};
//==============================================================================
#endif // _WOWCRYPT_H
//******************************************************************************