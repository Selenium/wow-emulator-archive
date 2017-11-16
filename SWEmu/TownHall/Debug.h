#ifndef DEBUG_H
#define DEBUG_H

#include "stdafx.h"

class CDebug
{
public:
	CDebug(void);
	CDebug(const char *debugfile);
	~CDebug(void);

	void Initialize(const char *debugfile);
	void Log(const char *out);
	void Logf(const char *,...);

	void Error(const char *format,...);
	void Warning(const char *format,...);

	void LogBuffer(const char *out, long len, const char *Descriptor);



	char Outfile[256];
private:
	bool Initialized;
	//	CCriticalSection S;
	CSemaphore S;
};

#endif // DEBUG_H
