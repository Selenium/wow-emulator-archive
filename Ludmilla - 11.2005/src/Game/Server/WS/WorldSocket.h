//******************************************************************************
#ifndef __WORLDSOCKET_H
#define __WORLDSOCKET_H
//==============================================================================
#include "WowCrypt.h"
#include "InterThreadPair.h"
#include "InterThreadQueue.h"
//==============================================================================
enum EClientAction
	// dumped from 1.8.0
	// dump loop:
	// start: 00589ACB  mov eax,dword ptr [ebp+8]
	// ecx = [ebp+0Ch] -> errcode
	// edx = [esi+1918h] -> COP code
	// end: 00589AF6: don't do pop esi, do jmp 00589ACB [EB D3]
	// result in esp-50h, esp-30
	// looks like it is client side only constants...
{
	COP_NONE				= 0x00,
	COP_INIT				= 0x01,
	COP_CONNECT				= 0x02,
	COP_AUTHENTICATE		= 0x03,
	COP_CREATE_ACCOUNT		= 0x04,
	COP_CREATE_CHARACTER	= 0x05,
	COP_GET_CHARACTERS		= 0x06,
	COP_DELETE_CHARACTER	= 0x07,
	COP_LOGIN_CHARACTER		= 0x08,
	COP_GET_REALMS			= 0x09,
	COP_WAIT_QUEUE			= 0x0A,
};
enum AuthResponseCodes
	// dumped from 1.8.0
	// dump loop:
	// start: 00589ACB  mov eax,dword ptr [ebp+8]
	// set SMSG_AUTH_RESPONSE.ErrCode -> ecx = [ebp+0Ch]
	// end: 00589AF6: don't do pop esi, do jmp 00589ACB [EB D3]
	// result in esp-50h, esp-30
{
	// COP_AUTHENTICATE:

	RESPONSE_SUCCESS				= 0x00, // Success
	RESPONSE_FAILURE				= 0x01, // Failure
	RESPONSE_CANCELLED				= 0x02, // Cancelled
	RESPONSE_DISCONNECTED			= 0x03, // Disconnected from server
	RESPONSE_FAILED_TO_CONNECT		= 0x04, // Failed to connect
	RESPONSE_CONNECTED				= 0x05, // Connected
	RESPONSE_VERSION_MISMATCH		= 0x06, // Wrong client version

	CSTATUS_CONNECTING				= 0x07, // Connecting to server...
	CSTATUS_NEGOTIATING_SECURITY	= 0x08, // Negotiating Security
	CSTATUS_NEGOTIATION_COMPLETE	= 0x09, // Security negotiation complete
	CSTATUS_NEGOTIATION_FAILED		= 0x0A, // Security negotiation failed
	CSTATUS_AUTHENTICATING			= 0x0B, // Authenticating

	AUTH_OK							= 0x0C, // Authentication successful
	AUTH_FAILED						= 0x0D, // Authentication failed
	AUTH_REJECT						= 0x0E, // Rejected - please contact customer support
	AUTH_BAD_SERVER_PROOF			= 0x0F, // Server is not valid
	AUTH_UNAVAILABLE				= 0x10, // System unavailable - please try again later
	AUTH_SYSTEM_ERROR				= 0x11, // System error
	AUTH_BILLING_ERROR				= 0x12, // Billing system error
	AUTH_BILLING_EXPIRED			= 0x13, // Account billing has expired
	AUTH_VERSION_MISMATCH			= 0x14, // Wrong client version
	AUTH_UNKNOWN_ACCOUNT			= 0x15, // Unknown account
	AUTH_INCORRECT_PASSWORD			= 0x16, // Incorrect password
	AUTH_SESSION_EXPIRED			= 0x17, // Session expired
	AUTH_SERVER_SHUTTING_DOWN		= 0x18, // Server shutting down
	AUTH_ALREADY_LOGGING_IN			= 0x19, // Already logging in
	AUTH_LOGIN_SERVER_NOT_FOUND		= 0x1a, // Invalid login server
	AUTH_WAIT_QUEUE					= 0x1b, // Position in queue -  (number)
	
	// 0x1C, 0x1D, 0x1E, 0x1F, 0x20, 0x21 - converted into nums 0x1C -> "28"
		//	AUTH_RETRIEVING_REALMLIST = 28,			// Retrieving realm list
		//	AUTH_REALMLIST_RETRIEVED = 29,			// Realm list retrieved
		//	AUTH_UNABLE_CONTACT_REALMLISTSERV = 30,	// Unable to contact realm list server
		//	AUTH_INVALID_REALMLIST = 31,			// Invalid realm list
		//	AUTH_REALM_IS_DOWN = 32,				// Realm is down
		//	AUTH_CREATING_ACCOUNT = 33,				// Creating account
	
	REALM_LIST_IN_PROGRESS			= 0x22, // Retrieving character list
	REALM_LIST_SUCCESS				= 0x23, // Character list retrieved
	REALM_LIST_FAILED				= 0x24, // Error retrieving character list
	REALM_LIST_INVALID				= 0x25, // Invalid realm list
	REALM_LIST_REALM_NOT_FOUND		= 0x26, // Realm is down

	// Others are  converted into nums (0x27 -> "39")
		//	AUTH_CREATING_CHAR = 39,			// Creating character
		//	AUTH_CHAR_CREATE_SUCCESS = 40,		// Create success
		//	AUTH_ERR_CREATING_CHAR = 41,		// Error creating character
		//	AUTH_CHAR_CREATION_FAILED = 42,		// Character creation failed
		//	AUTH_CHAR_NAME_IN_USE = 43,			// Name already in use
		//	AUTH_RACE_CLASS_DISABLED = 44,		// Creation of that race and/or class is currently disabled
		//	AUTH_DELETING_CHAR = 45,			// Deleting character
		//	AUTH_CHAR_DELETED = 46,				// Character deleted
		//	AUTH_CHAR_DELETION_FAILED = 47,		// Character deletion failed
		//	AUTH_ENTERING_THE_WOW = 48,			// Entering the World of Warcraft
		//	AUTH_LOGIN_SUCCESS = 49,			// Login successful
		//	AUTH_WORLD_SERVER_DOWN = 50,			// World server is down
		//	AUTH_CHAR_WITH_THAT_NAME_ALREADY = 51,	// A character with that name already exists
		//	AUTH_NO_INSTANCE_SERVERS = 52,			// No instance servers are available
		//	AUTH_LOGIN_FAILED = 53,					// Login failed
		//	AUTH_LOGIN_RACE_CLASS_DISABLED = 54,	// Login for that race and/or class is currently disabled
		//	AUTH_ENTER_CHAR_NAME = 55,				// Enter a name for your character
		//	AUTH_NAME_MUST_BE_AT_LEAST_3 = 56,		// Name must be at least 3 characters
		//	AUTH_NAMES_NO_MORE_THAN_12 = 57,		// Names must be no more than 12 characters
		//	AUTH_NAME_MUST_START_WITH_LETTER = 58,	// Name must start with a letter
		//	AUTH_CAN_HAVE_1_GRAVE = 59,				// Names can only have one grave (`)
		//	AUTH_NAMES_CONTAIN_ONLY_LETTERS = 60,	// Names can only contain letters and one grave (`)
		//	AUTH_NAMES_ONLY_IN_ONE_LANGUAGE = 61,	// Names must contain only one language
		//	AUTH_NAME_CONTAINS_PROFANITY = 62,		// That name contains profanity
		//	AUTH_NAME_RESERVED = 63,			// That name is reserved
		//	AUTH_INVALID_CHAR_NAME = 64			// Invalid character name
};
//==============================================================================
class WorldPacket;
class SocketHandler;
class WorldSession;
//------------------------------------------------------------------------------
class WorldSocket : public TcpSocket
{
public:
    WorldSocket(SocketHandler&);
    ~WorldSocket();

    void SendPacket(WorldPacket* packet);

    void OnAccept();
    void OnRead();
    void OnDelete();

    void Update(time_t diff);

	CInterThreadQueue<WorldPacket*> input;
	CInterThreadPair<WorldSocket, WorldSession> session;

protected:
    void _HandleAuthSession(WorldPacket& recvPacket);
    void _HandlePing(WorldPacket& recvPacket);

    static uint32 _GetSeed();

    WowCrypt crypt;
    uint32 _seed;
    uint32 _cmd;
    uint16 _remaining;
    WorldSession* _session;

    ZThread::LockedQueue<WorldPacket*,ZThread::FastMutex> _sendQueue;
};
//==============================================================================
#endif // __WORLDSOCKET_H
//******************************************************************************