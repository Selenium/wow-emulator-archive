// (c) AbyssX Group
#if !defined(LOGINENVIRONMENT_H)
#define LOGINENVIRONMENT_H

//! Other libs we depend on.
#include "../Common/Common.h"
#include "../ConfigLibrary/ConfigEnvironment.h"
#include "../LogLibrary/LogEnvironment.h"
#include "../DatabaseLibrary/DatabaseEnvironment.h"

class EventSystem;
class Timer;
class Account;
class AccountManager;

#define EVENTSYSTEM

#include "EventSystem/eventsystem.h"
#include "EventSystem/Timer.h"

#include "Accounts/Account.h"
#include "Accounts/AccountManager.h"

#include "../NetworkLibrary/NetworkEnvironment.h"

//! Our own includes.
#include "LoginServer.h"

#endif
