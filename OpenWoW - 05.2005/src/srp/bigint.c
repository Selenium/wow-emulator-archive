/*
 * Copyright (c) 1997-2004  The Stanford SRP Authentication Project
 * All Rights Reserved.
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS-IS" AND WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS, IMPLIED OR OTHERWISE, INCLUDING WITHOUT LIMITATION, ANY 
 * WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE.  
 *
 * IN NO EVENT SHALL STANFORD BE LIABLE FOR ANY SPECIAL, INCIDENTAL,
 * INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY KIND, OR ANY DAMAGES WHATSOEVER
 * RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER OR NOT ADVISED OF
 * THE POSSIBILITY OF DAMAGE, AND ON ANY THEORY OF LIABILITY, ARISING OUT
 * OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
 *
 * In addition, the following conditions apply:
 *
 * 1. Any software that incorporates the SRP authentication technology
 *    is requested to display the following acknowlegment:
 *    "This product uses the 'Secure Remote Password' cryptographic
 *     authentication system developed by Tom Wu (tjw@CS.Stanford.EDU)."
 *
 * 2. Any software that incorporates all or part of the SRP distribution
 *    itself must display the following acknowledgment:
 *    "This product includes software developed by Tom Wu and Eugene
 *     Jhong for the SRP Distribution (http://srp.stanford.edu/)."
 *
 * 3. Redistributions in source or binary form must retain an intact copy
 *    of this copyright notice and list of conditions.
 */

#include <stdio.h>
#include <string.h>
#include <sys/types.h>

#include "bigint.h"

/* Math library interface stubs */

#ifdef OPENSSL
# ifdef OPENSSL_ENGINE
static ENGINE * default_engine = NULL;
# endif /* OPENSSL_ENGINE */
static modexp_meth default_modexp = NULL;
#endif

BigInteger BigIntegerFromInt(unsigned int n)
{
#ifdef OPENSSL
  BIGNUM * a = BN_new();
  if(a)
    BN_set_word(a, n);
  return a;
#endif
}

BigInteger BigIntegerFromBytes(const unsigned char * bytes, int length)
{
#ifdef OPENSSL
  BIGNUM * a = BN_new();
  BN_bin2bn(bytes, length, a);
  return a;
#endif
}

int BigIntegerToBytes(BigInteger src, unsigned char * dest, int destlen)
{
#ifdef OPENSSL
  return BN_bn2bin(src, dest);
#endif
}

BigIntegerResult BigIntegerToHex(BigInteger src, char * dest, int destlen)
{
#ifdef OPENSSL
  strcpy(dest, BN_bn2hex(src));
#endif
  return BIG_INTEGER_SUCCESS;
}

static char b64table[] =
  "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./";

BigIntegerResult BigIntegerToString(BigInteger src, char * dest, int destlen, unsigned int radix)
{
  BigInteger t = BigIntegerFromInt(0);
  char * p = dest;
  char c;

  *p++ = b64table[BigIntegerModInt(src, radix, NULL)];
  BigIntegerDivInt(t, src, radix, NULL);
  while(BigIntegerCmpInt(t, 0) > 0) {
    *p++ = b64table[BigIntegerModInt(t, radix, NULL)];
    BigIntegerDivInt(t, t, radix, NULL);
  }
  BigIntegerFree(t);
  *p-- = '\0';
  /* reverse the string */
  while(p > dest) {
    c = *p;
    *p-- =  *dest;
    *dest++ = c;
  }
  return BIG_INTEGER_SUCCESS;
}

int BigIntegerBitLen(BigInteger b)
{
#ifdef OPENSSL
  return BN_num_bits(b);
#endif
}

int BigIntegerCmp(BigInteger c1, BigInteger c2)
{
#ifdef OPENSSL
  return BN_cmp(c1, c2);
#endif
}

int BigIntegerCmpInt(BigInteger c1, unsigned int c2)
{
#ifdef OPENSSL
  if(c1->top > 1)
    return 1;
  else if(c1->top < 1)
    return -c2;
  else
    return c1->d[0] - c2;
#endif
}

BigIntegerResult BigIntegerLShift(BigInteger result, BigInteger x, unsigned int bits)
{
#ifdef OPENSSL
  BN_lshift(result, x, bits);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerAdd(BigInteger result, BigInteger a1, BigInteger a2)
{
#ifdef OPENSSL
  BN_add(result, a1, a2);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerAddInt(BigInteger result, BigInteger a1, unsigned int a2)
{
#ifdef OPENSSL
  if(result != a1)
    BN_copy(result, a1);
  BN_add_word(result, a2);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerSub(BigInteger result, BigInteger s1, BigInteger s2)
{
#ifdef OPENSSL
  BN_sub(result, s1, s2);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerSubInt(BigInteger result, BigInteger s1, unsigned int s2)
{
#ifdef OPENSSL
  if(result != s1)
    BN_copy(result, s1);
  BN_sub_word(result, s2);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerMul(BigInteger result, BigInteger m1, BigInteger m2, BigIntegerCtx c)
{
#ifdef OPENSSL
  BN_CTX * ctx = NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  BN_mul(result, m1, m2, c);
  if(ctx)
    BN_CTX_free(ctx);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerMulInt(BigInteger result, BigInteger m1, unsigned int m2, BigIntegerCtx c)
{
#ifdef OPENSSL
  if(result != m1)
    BN_copy(result, m1);
  BN_mul_word(result, m2);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerDivInt(BigInteger result, BigInteger d, unsigned int m, BigIntegerCtx c)
{
#ifdef OPENSSL
  if(result != d)
    BN_copy(result, d);
  BN_div_word(result, m);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerMod(BigInteger result, BigInteger d, BigInteger m, BigIntegerCtx c)
{
#ifdef OPENSSL
  BN_CTX * ctx = NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  BN_mod(result, d, m, c);
  if(ctx)
    BN_CTX_free(ctx);
#endif
  return BIG_INTEGER_SUCCESS;
}

unsigned int BigIntegerModInt(BigInteger d, unsigned int m, BigIntegerCtx c)
{
#ifdef OPENSSL
  return BN_mod_word(d, m);
#endif
}

BigIntegerResult BigIntegerModMul(BigInteger r, BigInteger m1, BigInteger m2, BigInteger modulus, BigIntegerCtx c)
{
#ifdef OPENSSL
  BN_CTX * ctx = NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  BN_mod_mul(r, m1, m2, modulus, c);
  if(ctx)
    BN_CTX_free(ctx);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerModExp(BigInteger r, BigInteger b, BigInteger e, BigInteger m, BigIntegerCtx c, BigIntegerModAccel a)
{
#ifdef OPENSSL
  BN_CTX * ctx = NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  if(default_modexp) {
    (*default_modexp)(r, b, e, m, c, a);
  }
  else if(a == NULL) {
    BN_mod_exp(r, b, e, m, c);
  }
# if OPENSSL_VERSION_NUMBER >= 0x00906000
  else if(b->top == 1) {  /* 0.9.6 and above has mont_word optimization */
    BN_ULONG B = b->d[0];
    BN_mod_exp_mont_word(r, B, e, m, c, a);
  }
# endif
  else
    BN_mod_exp_mont(r, b, e, m, c, a);
  if(ctx)
    BN_CTX_free(ctx);
#endif
  return BIG_INTEGER_SUCCESS;
}

int BigIntegerCheckPrime(BigInteger n, BigIntegerCtx c)
{
#ifdef OPENSSL
  int rv;
  BN_CTX * ctx = NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  rv = BN_is_prime(n, 25, NULL, c, NULL);
  if(ctx)
    BN_CTX_free(ctx);
  return rv;
#endif
}

BigIntegerResult BigIntegerFree(BigInteger b)
{
#ifdef OPENSSL
  BN_free(b);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerClearFree(BigInteger b)
{
#ifdef OPENSSL
  BN_clear_free(b);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerCtx BigIntegerCtxNew()
{
#ifdef OPENSSL
  return BN_CTX_new();
#else
  return NULL;
#endif
}

BigIntegerResult BigIntegerCtxFree(BigIntegerCtx ctx)
{
#ifdef OPENSSL
  if(ctx)
    BN_CTX_free(ctx);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerModAccel BigIntegerModAccelNew(BigInteger m, BigIntegerCtx c)
{
#ifdef OPENSSL
  BN_CTX * ctx = NULL;
  BN_MONT_CTX * mctx;
  if(default_modexp)
    return NULL;
  if(c == NULL)
    c = ctx = BN_CTX_new();
  mctx = BN_MONT_CTX_new();
  BN_MONT_CTX_set(mctx, m, c);
  if(ctx)
    BN_CTX_free(ctx);
  return mctx;
#else
  return NULL;
#endif
}

BigIntegerResult BigIntegerModAccelFree(BigIntegerModAccel accel)
{
#ifdef OPENSSL
  if(accel)
    BN_MONT_CTX_free(accel);
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerInitialize()
{
#if OPENSSL_VERSION_NUMBER >= 0x00907000
  ENGINE_load_builtin_engines();
#endif
  return BIG_INTEGER_SUCCESS;
}

BigIntegerResult BigIntegerFinalize()
{
  return BigIntegerReleaseEngine();
}

BigIntegerResult BigIntegerUseEngine(const char * engine)
{
#if defined(OPENSSL) && defined(OPENSSL_ENGINE)
  ENGINE * e = ENGINE_by_id(engine);
  if(e) {
    if(ENGINE_init(e) > 0) {
# if OPENSSL_VERSION_NUMBER >= 0x00907000
      /* 0.9.7 loses the BN_mod_exp method.  Pity. */
      const RSA_METHOD * rsa = ENGINE_get_RSA(e);
      if(rsa)
	default_modexp = (modexp_meth)rsa->bn_mod_exp;
# else
      default_modexp = (modexp_meth)ENGINE_get_BN_mod_exp(e);
# endif
      BigIntegerReleaseEngine();
      default_engine = e;
      return BIG_INTEGER_SUCCESS;
    }
    else
      ENGINE_free(e);
  }
#endif
  return BIG_INTEGER_ERROR;
}

BigIntegerResult BigIntegerReleaseEngine()
{
#if defined(OPENSSL) && defined(OPENSSL_ENGINE)
  if(default_engine) {
    ENGINE_finish(default_engine);
    ENGINE_free(default_engine);
    default_engine = NULL;
    default_modexp = NULL;
  }
#endif
  return BIG_INTEGER_SUCCESS;
}
