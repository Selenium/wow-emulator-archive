//******************************************************************************
// Implements connection to Logon Server
// Receives, processes, and makes, sends all packets from and to client
// Also holds auto patch downloading system inside
//==============================================================================
#ifndef _LOGONSOCKET_H
#define _LOGONSOCKET_H
//==============================================================================
#include "../Shared/Auth/Sha1.h"
#include "LogonPackets.h"
#include "LogonCodes.h"
//==============================================================================
class LogonSocket: public TcpSocket
	// Implements connection to Logon Server
	// Receives, processes, and makes, sends all packets from and to client
	// Also holds auto patch downloading system inside
{
protected:
	// Reads data from CircularBuffer but does nott remove it from that buf
	void PeekFromCircularBuffer(CircularBuffer *buf, char *dst, int size);

public:
    LogonSocket(SocketHandler& h);
    ~LogonSocket();

	// fair methods:

	// Process all queued packets from network
	// true if input queue is empty
	bool ProcessInput(uint32 count = 1);

	// Send all queued outgoing packets to network
	// true if output queue is empty
	bool SendOutput(time_t diff, uint32 count = 1);

protected:
	// LogonSocket is in LogonSocketMgr's list for procession
	bool amprocessing; // for optimization
	// Add LogonSocket to LogonSocketMgr's list for procession
	void AddToMgrProcessList();

	// LogonSocket is in LogonSocketMgr's list for sending data
	bool amsending; // for optimization
	// Add LogonSocket to LogonSocketMgr's list for sending data
	void AddToMgrSendList();

	// connection must be closed, we will not process anything
	// except data already in process
	bool mustdie;
	// Called when Socket lib deleting this object
	void OnDelete();
	// Close connection and mark this for deletion - last action
	void DeleteThis();

	// When transfering file it is true, else it is false
	bool transfering; // must check writability of network when sending file
	// we will not send data until it is 0
	time_t pauseoutput; // wow.exe can't accept error too quick

	// Called when Socket lib accepting new connection
    void OnAccept();
	// Called when Socket lib has data for us
    void OnRead();
	// Called when Socket lib let write to network
	void OnWrite();

	// packets:
	std::queue< std::vector<uint8> * > input; // data from client
	std::queue< std::vector<uint8> * > output; // data to client

	enum EServerAnswer // our internal
	{
		SA_QUEUED,			// Packet accepted
		SA_ERROR,			// Need to reject connection
		SA_WAITING,			// Packet incomplete, need rest
	};

	
	// LogonChallenge: first packets
	EServerAnswer QueueLogonChallenge(); // Adds new LogonChallenge packet to input queue
	void ParseLogonChallenge(SClientLogonChallenge *cpkt); // help func: checks for errors, fill account name and paassword field
	void ProcessLogonChallenge(); // Makes and queues server's LogonChallenge packet

	// LogonProof: client second packets he proof, we proof
	EServerAnswer QueueLogonProof(); // Adds new LogonProof packet to input queue
	void ErrorLogonProof(); // help func: queues server's error packet
	void ProcessLogonProof(); // Makes and queues server's LogonProof packet

	// ReconnectChallenge: not discovered. we need info about reconnection.
	EServerAnswer QueueReconnectChallenge(); // Just recalls QueueLogonChallenge()
	void ProcessReconnectChallenge(); // Just recalls ProcessLogonChallenge()

	// ReconnectProof: not discovered. we need info about reconnection.
	EServerAnswer QueueReconnectProof(); // Just recalls QueueLogonProof()
	void ProcessReconnectProof(); // Just recalls ProcessLogonProof()

	// RealmList: Called everytime when clien looks on realm list
	EServerAnswer QueueRealmList(); // Adds new RealmList packet to input queue
	void ProcessRealmList(); // Makes and queues server's RealmList packet

	// XferAccept: Client agreed to receive new patch
	EServerAnswer QueueXferAccept(); // Adds new XferAccept packet to input queue
	void ProcessXferAccept(); // Makes and queues next patch part, Does not remove input packet until end.

	// XferAccept: Client want to continue receiving of patch from specified position
	EServerAnswer QueueXferResume(); // Adds new XferResume packet to input queue
	void ProcessXferResume(); // Makes and queues next patch part, Does not remove input packet until end.

	// XferCancel: Client want to abort receiving of the patch
	EServerAnswer QueueXferCancel(); // Deletes previous packet and adds XferCancel packet to input queue
	void ProcessXferCancel(); // Clears output queue, mark as dieing connection

// object state:
	bool _authed; // Successfully authorized
	bool _challenged; // Identified, need to be verified
	std::string _login; // Account name
	std::string _password; // Account password
	ELoginErrorCode _pending_error; // This error will be reported soon (bliz holds some errors)

// SRP6 variables:
    const static int N_BYTE_SIZE = 32;
    const static int s_BYTE_SIZE = 32;
	BigNumber N, s, g, v;
	BigNumber b, B;
	BigNumber rs;

// session key:
	// mighty session key.
	// one should keep this in some other place,
	// we will use it from other LogonSocket object (upon reconnect)
	BigNumber K;

// auto update system:
	class CPatcher
		// Implements all global logic about patching
		// Decide questions about patching
		// Holds patch class for packet building inside
	{
	public:
		struct PatchID // info about target client of a patch
		{
			uint16	build;				// client's build
			uint8	localization[4];	// client's language
		};
		class CPatch // The patch for the client
			// Builds specified packets for the client
		{
		public:
			CPatch(uint16 build, uint8 localization[4]);
			~CPatch();

			// Builds packet:
			std::vector<uint8>* CreateInfo(); // Creates packet with info about patch
			std::vector<uint8>* CreateNextPart(); // Create packet with next portion of data

			// Sets needed position for resuming
			void SetPos(uint32 pos);

			// Returns size of the patch
			uint32 GetSize() const { return size; }
			// Returns true, if position was set by SetPos call
			bool AmResuming() const { return resuming; }
			// Check if all patch file was returned
			bool Done() { return feof(file) != 0; }

		protected:
			bool resuming; // position already was set by SetPos call
			uint32 size; // for checks
			uint8 md5[MD5_DIGEST_LENGTH]; // md5 checksum of patch file
			const static int BlockSize = 1500; // from bliz
			FILE * file; // handle for file with patch
		};

		CPatcher();
		~CPatcher();

		// Decide is client ok, must we patch him, or reject
		ELoginErrorCode CheckClientVersion(uint16 build, uint8 localization[4]);

		// Must be called at program startup before any other use of class
		// Scan for patches in /patches/ dir
		void LoadPatcheIDs();

	protected:
		// Check for patch in internal list, loaded at startup
		bool HavePatch(uint16 build, uint8 localization[4]);
		// List of patches we have
		PatchID* patches;
		// Count of patches we have
		int patches_count;
	};

	// This is patch for this connection, or NULL
	CPatcher::CPatch* patch;

public:
	// Shared object of autoupdate system
	static CPatcher Patcher; // needs external LoadPatcheIDs() call
};
//==============================================================================
#endif // _LOGONSOCKET_H
//******************************************************************************
