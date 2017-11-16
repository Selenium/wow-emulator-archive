#ifndef _AUTH_SHA1_H
#define _AUTH_SHA1_H

//#include "../Common.h"
#include <openssl/sha.h>
#include "BigNumber.h"

class Sha1Hash
{
    public:
        Sha1Hash();
        ~Sha1Hash();

        void UpdateFinalizeBigNumbers(BigNumber *bn0, ...);
        void UpdateBigNumbers(BigNumber *bn0, ...);

        void UpdateData(const uint8 *dta, int len);
        void UpdateData(const std::string &str);

        void Initialize();
        void Finalize();

        uint8 *GetDigest(void) { return mDigest; };
        int GetLength(void) { return SHA_DIGEST_LENGTH; };

        BigNumber GetBigNumber();

    private:
        SHA_CTX mC;
        uint8 mDigest[SHA_DIGEST_LENGTH];
};

#endif
