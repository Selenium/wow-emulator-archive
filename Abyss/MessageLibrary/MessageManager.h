#if !defined(MESSAGEMANAGER_H)
#define MESSAGEMANAGER_H

//! Used to perform different types of packet sending.
/*! The class wraps around the network library and provides a simple interface for sending messages
to common targets. */
class MessageManager
{
public:
	// Constructor: MessageManager.
	MessageManager();

	// Destructor: ~MessageManager.
	~MessageManager();

	//! Sends a packet to all players in the game.
	void SendToAll(std::vector<Player *> *target);

private:
};

#endif
