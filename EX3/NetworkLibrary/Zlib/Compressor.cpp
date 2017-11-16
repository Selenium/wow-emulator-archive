// (c) AbyssX Group
#include "CompressionEnvironment.h"

Compressor::Compressor()
{
	mData = NULL;
	mDataLen = 0;
	mLastErr = Z_OK;
}

Compressor::~Compressor()
{
	if (mData)
		delete [] mData;
}

bool Compressor::Compress(Byte *data, long datalen)
{
	// Delete and previously compressed data.
	if (mData)
		delete [] mData;

	// Find the size of buffer we will need to store the compressed data.
	mDataLen = compressBound(datalen);
	mData = new Byte[mDataLen];

	// Call zlib to do our compression.
	mLastErr = compress(mData, &mDataLen, data, datalen);
	if (mLastErr != Z_OK)
	{
		// If we failed, re-int the class for a fresh compress, and return false.
		mDataLen = 0;
		delete [] mData;
		mData = NULL;
		return false;
	}
	
	// Return success.
	return true;
}

bool Compressor::Uncompress(Byte *data, long datalen, long destlen)
{
	// Delete any previous data.
	if (mData)
		delete [] mData;

	// Set up our buffer.
	mDataLen = destlen;
	mData = new Byte[mDataLen];

	// Call zlib to uncompress.
	mLastErr = uncompress(mData, &mDataLen, data, datalen);
	if (mLastErr != Z_OK)
	{
		// If there is an error, clean up and return false.
		mDataLen = 0;
		delete [] mData;
		mData = NULL;
		return false;
	}

	// Return success.
	return true;
}

const char *Compressor::ErrorString(void)
{
	// Just wrap zlib's function for this.
	return zError(mLastErr);
}

pair<Byte *, long> Compressor::GetOutput(void)
{
	return pair<Byte *, long>(mData, mDataLen);
}
