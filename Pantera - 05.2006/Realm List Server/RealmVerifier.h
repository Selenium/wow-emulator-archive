#ifndef REALMVERIFIER_H
#define REALMVERIFIER_H

#include "stdafx.h"

class CRealmVerifier
{
public:
	CRealmVerifier(class CRealmListServer *pList);
	~CRealmVerifier(void);
	CThread VerifierThread;

	class CRealmListServer *pRealmList;
	void Go();
};

#endif // REALMVERIFIER_H
