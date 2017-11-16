// (c) AbyssX Group
#include "NetworkEnvironment.h"

Client::~Client()
{
}

SOCKET Client::GetSock(void)
{
	return mSock;
}

void Client::SetTimeout(unsigned int secs)
{
	mTimeout = secs;
}

bool Client::IsTimedOut(void)
{
	if (!mTimeout)
		return false;

	if ((time(NULL) - mIdleStart) > mTimeout)
		return true;
	return false;
}

void Client::Touch(void)
{
	mIdleStart = time(NULL);
}

void Client::RecvData(const unsigned char *data, int len)
{
	// I really wish I could use an append or insert with a length,
	// but I cannot since I'm using a string, and the string class
	// will stop appending a chunk of data as soon as it hits a NULL,
	// which it perceived as End Of String. So, to optimize this
	// we will need to change how we are doing this queue. Perhaps
	// a circular buffer of bytes with startplace and endplace indices,
	// but, I'm just too lazy to do that right now, so we have a string
	// class and this looping shit. :)
	int i;

	for (i = 0; i < len; i++)
		mInBuffer += data[i];
}

void Client::SendData(const unsigned char *data, int len)
{
	int i;

	for (i = 0; i < len; i++)
		mOutBuffer += data[i];
}

string &Client::GetInBuffer(void)
{
	return mInBuffer;
}

string &Client::GetOutBuffer(void)
{
	return mOutBuffer;
}

string &Client::GetHost(void)
{
	return mHost;
}
