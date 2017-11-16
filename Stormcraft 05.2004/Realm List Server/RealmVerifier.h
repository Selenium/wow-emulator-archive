#pragma once
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
