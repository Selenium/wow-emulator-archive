// (c) AbyssX Group
#if !defined (COMPRESSOR_H)
#define COMPRESSOR_H

//! General purpose Compressor class
class Compressor
{
	public:
		//! Constructor: Inits data to ready.
		Compressor();
		//! Destructor: Destroys any data created by this class.
		~Compressor();

		//! Compress(): Compresses arbitrary data.
		//! Takes input 'data' of length 'datalen' and compresses it. The success or
		//! failure boolean is returned. You can get the specific problem by calling
		//! ErrorString().
		bool Compress(Byte *data, long datalen);

		//! Uncompress(): Uncompresses arbitrary data.
		//! Takes input of 'data' of length 'datalen' which will be uncompressed into
		//! a buffer of size 'destlen'. Uncompression itself is not responsible for
		//! knowing how much buffer is needed for uncompression. This is outside the
		//! scope of a compression library itself.
		bool Uncompress(Byte *data, long datalen, long destlen);

		//! GetOutput(): returns the result of the compress/uncompress
		//! Returns a pair<Byte *, long). retval.first will be the byte buffer,
		//! and retval.second will be the length of said buffer.
		pair<Byte *, long> GetOutput(void);
		
		//! ErrorString(): returns a const string explaining the last error.
		const char *ErrorString(void);

	private:
		//! Internal buffer
		Byte *mData;

		//! Length of internal buffer
		unsigned long mDataLen;

		//! Last error code
		int mLastErr;
};

#endif