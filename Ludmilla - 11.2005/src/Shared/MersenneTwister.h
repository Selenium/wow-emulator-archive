#pragma once
//
// uint32 must be an unsigned integer type capable of holding at least 32
// bits; exactly 32 should be fastest, but 64 is better on an Alpha with
// GCC at -O3 optimization so try your options and see what's best for you
//

class MT {
protected:

	enum {N = 624}; // length of state vector
	enum {M = 397}; // a period parameter
	enum {K = 0x9908B0DFU}; // a magic constant

	uint32   state[N];    // state vector + 1 extra to not violate ANSI C
	uint32   *next;       // next random value is computed from here
	int      mtleft;      // can *next++ this many times before reloading

	uint32 reload (void);

public:
	MT() { init(); }
	//~MT();
	void init();
	uint32 rand32 (void);
	void seed (uint32 _seed);
	float randf() {  return ((uint64)rand32() + ((uint64)rand32() << 32)) / (float)_MTRAND_;  };
};

extern MT	*g_mt_rand;

void initMT();
uint32 randomMT();
void seedMT (uint32 _seed);

//--- END ---