#ifndef _PACKET_H_
#define _PACKET_H_


inline unsigned short Swap(unsigned short u)
{
 return ((u&0xff00)>> 8)+((u&0xff )<<8);
}
//HACK WORKAROUND HACK!!
struct LuaCharBinder
{
	char *val;
	LuaCharBinder(char *x) : val(x){}
	~LuaCharBinder()
	{
		delete[] val;
	}
};
//HACK WORKAROUND HACK!!



const wxUint16				wowSizeDummy		= 0xbeef;       // only a debug dummy for packet creation

// The header
#pragma pack(1)
	struct wowPacketHeader
	{	
		wxUint16            mSize;
		wxUint16            mType;
		wxUint16            mUnknown;       // maybe type extension in the case they have more then 2^15 elements
	};
#pragma pack()


#include "../Misc.h" // contains the SimplestItemList template

struct lua_State;
class wowPacket 
{
protected:
	char*					mData;
	unsigned int			mMemorySize;
	unsigned int			mSize;
	unsigned int			mGrowSize;
	unsigned int			mPosition;
	wxSocketBase		    *mSocket;
	
	friend class ServerCore;
	inline bool Send();

public:
	wowPacket(wxSocketBase *sock) :mData((char*)NULL),
								   mMemorySize(0),
								   mSize(0),
								   mGrowSize(256),
								   mPosition(0), 
								   mSocket(sock){}

	
	wowPacket(wowPacket *packet) 
	{
		mData = (char*)malloc(packet->mSize);
		memcpy(mData,packet->mData,packet->mSize);
		
		mMemorySize=packet->mSize;
		mSize =packet->mSize;
		
		mPosition = 0;
		mGrowSize = 256;
		mSocket =packet->mSocket;
	}
	wowPacket(wowPacket &packet) 
	{
		mData = (char*)malloc(packet.mSize);
		memcpy(mData,packet.mData,packet.mSize);
		
		mMemorySize=packet.mSize;
		mSize =packet.mSize;
		
		mPosition = 0;
		mGrowSize = 256;
		mSocket =packet.mSocket;
	}
	wowPacket():mData((char*)NULL),
				mMemorySize(0),
				mSize(0),
				mGrowSize(256),
				mPosition(0){}
	

	~wowPacket(void){	Reset();	}

	char*					GetData			(void)			{ return mData;	}
	unsigned int			GetSize			(void)			{ return mSize;	}

	void					Reset			(void)
	{
		if(mData) free(mData);
		mData		= (char*)NULL;
		mMemorySize = 0;
		mSize		= 0;
		mPosition	= 0;
	}

	// grow checks if 'needed' fits into mData, else it allocates more memory
	bool					Grow			(unsigned int needed)
	{
		if(!mData)
		{
			if(needed>mGrowSize) 	mMemorySize = needed;
			else					mMemorySize = mGrowSize;

			mData = (char*) malloc(mMemorySize);
			return true;
		}

		if(mSize+needed<mMemorySize)	return true;

		if(mSize+needed>mMemorySize+mGrowSize)	mMemorySize += needed;
		else								    mMemorySize += mGrowSize;

		char* newp = (char*)realloc((void*)mData,mMemorySize);

		if(newp)	mData = newp;
		else		return false;

		return true;
	}

	// appends data to the end of the packet
	void					AppendData		(void* data, unsigned int size)
	{
		if(data == (char*)NULL)	return;
		if(Grow(size) == false)	return;

		memcpy(mData+mSize,data,size);
		mSize += size;
	}

	void					SetPosition		(unsigned int position) { if(mSize>=position) mPosition = position; }
	unsigned int			GetPosition		(void)					{ return mPosition; }
	void					Skip			(unsigned int position) { if(mSize>=mPosition+position) mPosition += position; }

	// appends data at mPosition
	void					PutData			(void* data,unsigned int size)
	{
		if(data == (char*)NULL)					return;
		if((mPosition+size>mSize)
		&& (Grow(mSize-mPosition+size)==false))	return;

		memcpy(mData+mPosition,data,size);
		mPosition+=size;

		if(mSize < mPosition)	mSize=mPosition;
	}

	// appends data at mPosition
	void	GetData			(void* data,unsigned int size)
	{
		if((data == (char*)NULL)		// nullpointer
		|| (mPosition+size>mSize))		// out of bounds
		{
			// invalid the memory to indicate the failure for debugging
			memset(data,InvalidMemoryMarker,size);
			// add a log message
			//LOG(_T("read beyond packet bounds for packet of type (%d)"),GetPacketType());
			return; 
		}
		
		memcpy(data,mData+mPosition,size);
		mPosition+=size;
	}

	// put functions :
	//   Putu8  = unsigned 8 bit
	//   Puts8  = signed 8 bit
	//   Putu16 = unsigned 16 bit
	//   Puts16 = signed 16 bit
	//   Putu32 = unsigned 32 bit
	//   Puts32 = signed 32 bit
	//	 Putf32 = float 32 bit
	//	 Putf64 = float 64 bit
	//	 Putcstr = wxString (ascii)		(NOT 0-terminated)
	//	 Putcstr0= wxString (ascii)		(0-terminated)
	//	 Putwstr = wxString (unicode)	(NOT 0-terminated)
	//	 Putwstr0= wxString (unicode)	(0-terminated)
	inline void				Putu8			(unsigned char val)			{ PutData(&val,1); }
	inline void				Puts8			(char val)					{ PutData(&val,1); }
	inline void				Putu16			(unsigned short val)		{ PutData(&val,2); }
	inline void				Puts16			(short val)					{ PutData(&val,2); }
	inline void				Putu32			(unsigned int val)			{ PutData(&val,4); }
	inline void				Puts32			(int val)					{ PutData(&val,4); }
	inline void				Putf32			(float val)					{ PutData(&val,4); }
	inline void				Putf64			(double val)				{ PutData(&val,8); }
	inline void				Putcstr			(const char *str)			{ PutData((void*)str,strlen(str)); }
	inline void				Putcstr0		(const char *str)			{ PutData((void*)str,strlen(str)); Putu8(0);}
	inline void				Putcstr			(wxString &str)				{ PutData((void*)str.c_str(),str.Len()); }
	inline void				Putcstr0		(wxString &str)				{ PutData((void*)str.c_str(),str.Len()); Putu8(0);}
	
	inline char *			Getcstr			(int size )
	{
		char *out;
		if (size)
		{
			out = new char[size+1];
			memcpy(out,mData+mPosition,size);
			out[size] = '\0';
		}
		else
		{	
			size = strlen(mData+mPosition);
			out = new char[size+1];
			memcpy(out,mData+mPosition,size);
			out[size] = '\0';
		}
		mPosition +=size;
		if (mPosition >mSize) mPosition = mSize;
		return out;	
	}

	inline void				Getcstr			(wxString& str)				
	{ 
		size_t sl = strlen(mData+mPosition)+1;

		if(sl+mPosition > mSize)		return;	// out of bounds
        
		str = mData+mPosition;
		mPosition += sl;
	}

	inline LuaCharBinder*			Getcstr			()
	{
		return new LuaCharBinder(Getcstr(0));
	}

	inline char				Gets8			()		{ wxInt8   val; GetData(&val,1); return val; }
	inline unsigned char	Getu8			()		{ wxUint8  val; GetData(&val,1); return val; }
	inline short			Gets16			()		{ wxInt16  val; GetData(&val,2); return val; }
	inline unsigned short	Getu16			()		{ wxUint16 val; GetData(&val,2); return val; }
	inline int				Gets32			()		{ wxInt32  val; GetData(&val,4); return val; }
	inline unsigned int		Getu32			()		{ wxUint32 val; GetData(&val,4); return val; }
    inline float			Getf32			()		{ wxFloat32 val; GetData(&val,4); return val; }
    inline double			Getf64			()		{ wxFloat64 val; GetData(&val,8); return val; }

	//helpful wrapper as the socket is passed along with the packet
	
	static bool SendCue(wxSocketBase *socket);
	
	static wowPacket*		ReceivePacketFromSocket(wxSocketBase *socket);
	void Cue();
	
	
	void			PutSize			(void)		{ Putu16(/*placeholder*/wowSizeDummy);	}
	void			PutHeader		(wxUint32 type)
	{
		PutSize();
		Putu16(type);
		Putu16(0x0000);
	}

	void			Finalize		(void)
	{
		if(!mData || mSize<GetHeaderSize()) return;

		wowPacketHeader&	header = *((wowPacketHeader*)mData);

        header.mSize	= Swap(mSize-2);
	}


	bool			CheckHeader		(void)		{ return true; } /* nothing to verify */

	unsigned int 	GetPacketSize	(void)		{ return Swap(((wowPacketHeader*)mData)->mSize)+2; }
	unsigned int 	GetPacketType	(void)		{ return ((wowPacketHeader*)mData)->mType; }

	unsigned int	GetHeaderSize	(void)		{ return sizeof(wowPacketHeader); }

	
	void					SkipHeader		(void) { SetPosition(GetHeaderSize()); }
	wxSocketBase *GetSocket() {return mSocket;}
	wxSocketBase *SetSocket(wxSocketBase *nSocket)
	{
		wxSocketBase *temp = mSocket;
		mSocket = nSocket;
		return temp;
	}
	//function to bind the class to Lua
	static void LuaBind(lua_State *);
};

struct ScratchPackets
{
	SimplestItemList<wowPacket> PendingPackets; // in case output blocks too long
	wowPacket *InputScratchPacket;				// 
	wowPacket *OutputScratchPacket;				// 
	ScratchPackets(wxSocketBase *sock) :InputScratchPacket(new wowPacket(sock)),OutputScratchPacket(NULL) {}
	~ScratchPackets()
	{
		if (InputScratchPacket) delete InputScratchPacket;
		if (OutputScratchPacket) delete OutputScratchPacket;
	}
};

inline bool wowPacket::Send()
{
	
	if (SendCue(mSocket))
	{
		mPosition = 0;
		mSocket->Write(mData,mSize);
		if (mSocket->LastCount() < mSize) //did we write the whole lot
		{
			mPosition = mSocket->LastCount();
			return false;
		}
		delete this;
		return true;
		
	} 
	return false; //unable to send
	
}
#endif//_PACKET_H_
