#pragma once

enum opcode {

	CMD_AUTH_LOGON_CHALLENGE     = 0x00,
	CMD_AUTH_LOGON_PROOF         = 0x01,
	CMD_AUTH_RECONNECT_CHALLENGE = 0x02,
	CMD_AUTH_RECONNECT_PROOF     = 0x03,
	CMD_REALM_LIST               = 0x10,
	CMD_TRANSFER_INITIATE        = 0x30,
	CMD_TRANSFER_DATA            = 0x31,
	CMD_TRANSFER_ACCEPT          = 0x32,
	CMD_TRANSFER_RESUME          = 0x33,
	CMD_TRANSFER_CANCEL          = 0x34,
};

enum Login_Error_Code
   // dumped from wow.exe 1.8.0
{
   // LOGIN_STATE_AUTHENTICATED:
   LOGIN_OK					= 0, // E
   LOGIN_FAILED				= 1, // 2, B, C, D // "Unable to connect"
   LOGIN_CLOSED				= 3, // "This World of Warcraft account has been closed and is no longer in service -- Please check the registered email address of this account for further information."; -- This is the error message players get when trying to log in with a banned account.
   LOGIN_UNKNOWN_ACCOUNT	= 4, // 5 // "The information you have entered is not valid.  Please check the spelling of the account name and password.  If you need help in retrieving a lost or stolen password and account, see www.worldofwarcraft.com for more information.";
   LOGIN_ALREADYONLINE		= 6, // "This account is already logged into World of Warcraft.  Please check the spelling and try again.";
   LOGIN_NOTIME				= 7, // "You have used up your prepaid time for this account. Please purchase more to continue playing";
   LOGIN_DBBUSY				= 8, // "Could not log in to World of Warcraft at this time.  Please try again later.";
   LOGIN_BADVERSION			= 9, // "Unable to validate game version.  This may be caused by file corruption or the interference of another program.  Please visit www.blizzard.com/support/wow/ for more information and possible solutions to this issue.";
   // LOGIN_STATE_DOWNLOADFILE, LOGIN_OK
   LOGIN_DOWNLOADFILE		= 0xA, // not official name
   LOGIN_ACCOUNT_FREEZED	= 0x0C,
   LOGIN_PARENTALCONTROL	= 0xF, // "17"="LOGIN_PARENTALCONTROL" // "Access to this account has been blocked by parental controls.  Your settings may be changed in your account preferences at http://www.worldofwarcraft.com.";
};

#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
#pragma pack(1)
#else
#pragma pack(push,1)
#endif 

struct sAuthLogonChallenge_C {
    uint8   cmd;
    uint8   error;          // 0x00
    uint16  size;           // 0x0026
    uint8   gamename[4];    // 'WoW'
    uint8   version[3];       // 0x00
    uint16  build;          // 3734
    uint8   platform[4];    // 'x86'
    uint8   os[4];          // 'Win'
    uint8   localization[4];     // 'enUS'
    uint32  timezone_bias;  // -419
    uint8   ip[4];             // client ip
    uint8   I_len;          // length of account name
    uint8   I[1];           // account name
};

typedef sAuthLogonChallenge_C sAuthReconnectChallenge_C;

struct sAuthLogonChallenge_S {
	sAuthLogonChallenge_S() { cmd = CMD_AUTH_LOGON_CHALLENGE; unk2 = 0; memset(unk3, 0, 16); }
    uint8   cmd;            // 0x00 CMD_AUTH_LOGON_CHALLENGE
    uint8   unk2;           // 0x00
    uint8   error;          // 0 - ok
	uint8   B[32];
    uint8   g_len;          // 0x01
    uint8   g[1];
    uint8   N_len;          // 0x20
    uint8   N[32];
    uint8   s[32];
    uint8   unk3[16];
	uint8	unk4;
};

struct sAuthLogonProof_C {
    //uint8   cmd; // CMD_AUTH_LOGON_PROOF
    uint8   A[32];
    uint8   M1[20];
    uint8   crc_hash[20];
    uint8   number_of_keys;
    //uint8   unk;
};

struct sAuthLogonProofKey_C {
    uint16  unk1;
    uint32  unk2;
    uint8   unk3[4];
    uint16  unk4[20];       // sha1(A,g,?)
};

struct sAuthLogonProof_S {
    uint8   cmd;            // 0x01 CMD_AUTH_LOGON_PROOF
    uint8   error;
    uint8   M2[20];
    uint32  unk2;
    uint16  unk3;
};

#if __GNUC__ && (GCC_MAJOR < 4 || GCC_MAJOR == 4 && GCC_MINOR < 1)
#pragma pack()
#else
#pragma pack(pop)
#endif
