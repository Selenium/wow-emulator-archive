#include "../Common.h"
#include "Packet.h"

/////////////////////////////////////////////////////
//SendCue
// tries to send the accumulated packet cue for the given packet
// if the OutputScratchPacket is NULL there is no need to chec further - no packets are stored
// the OutputScratchPacket is a packet in "mid-send" the write operation could not complete
// and would otherwise block the system
// after successfuly sending the OutputScratchPacket the code proceeds to send the contents
// of the packet cue storing the temporary packet in OutputScratchPacket if the operation
// could not complete(an wxOUTPUT_EVENT will be generated for that)
// returning true on empty cue, and false on send failure;

bool wowPacket::SendCue(wxSocketBase *socket)
{
	ScratchPackets *Spackets = (ScratchPackets*)socket->GetClientData();
	wowPacket *packet = Spackets->OutputScratchPacket;
	
	if (packet == NULL) // nothing left to send;
		return true;
	socket->Write(packet->mData + packet->mPosition,packet->mSize-packet->mPosition);
	packet->mPosition+=socket->LastCount();// move the position by the ammount sent
	if (packet->mPosition < packet->mSize) return false; // still not all is written
	delete packet; // we don't need it anymore;
	packet = Spackets->PendingPackets.Get();
	while(packet)
	{
		socket->Write(packet->mData ,packet->mSize);
		packet->mPosition = socket->LastCount();
		if (packet->mPosition < packet->mSize) 
		{
			Spackets->OutputScratchPacket = packet; // not all was sent
			return false;
		}
		delete packet;
		packet = Spackets->PendingPackets.Get();
	}
	Spackets->OutputScratchPacket=NULL; // signal there's nothing left pending
	return true; // all packets from the pending cue have been sent - we can safely return
 
}

/////////////////////////////////////////////////////
//ReceivePacketFromSocket
// tests first if the ScratchPacket is empty -> mPosition == 0
// if not it's a signal the last operation did not complete fully, 
// the socket not having all the data ready (we're not using blocking sockets)
// The code then tries to receive the rest of the data - comparing the result with the 
// packet size stored in first 2 bytes of the packet and stored in mSize
// if there's no packet in the InputScratchPacket (a static packet used as a Scratch buffer)
// the code tries to read the packet header (using peek which doesn't delete the data)
// if there's not enough data to initialise the packet ( the first 2 bytes)
// the code returns waiting for new wxINPUT_EVENT. It's only a precaution in case only one byte
// is available (highly unlikely)
// if the packet wouldn't fit the scratchpacket's buffer the buffer is increased with Grow
// and finally the data is read.
// the final check is to ensure that the read operation got the whole packet
// if so the code returns a copy of the scratch buffer (only mSize bytes)
	
wowPacket*		wowPacket::ReceivePacketFromSocket(wxSocketBase *socket)
	{
		wowPacket *packet = ((ScratchPackets*)socket->GetClientData())->InputScratchPacket;
		
		 
		// previous operation did not read the whole packet
		if (packet->mPosition) 
		{
			char* data = packet->mData;
			data += packet->mPosition;							// end of the last read
			wxUint16 toRead = packet->mSize - packet->mPosition;// the ammount left toRead 
			socket->Read(data,toRead);
			packet->mPosition+= socket->LastCount();			// add what we already have;
		}
		else
		{
			wowPacketHeader header;
			socket->Peek(&header,sizeof(wowPacketHeader));
			if (socket->LastCount() < 2 ) // we didn't even get the data size - skippage
				return NULL;
			wxUint16 packetsize = Swap(header.mSize)+2;//reverse the byte order
			if (packetsize > packet->mMemorySize)
				packet->Grow(packetsize - packet->mMemorySize); // stretch to fit the whole packet
			socket->Read(packet->mData,packetsize);
			packet->mSize = packetsize;				// the desired size
			packet->mPosition = socket->LastCount(); // the actual data amount
		}
		if (packet->mPosition == packet->mSize) // have we arrived got the whole packet?
		{
			wowPacket *temp = new wowPacket(*packet);
			packet->mSize = packet->mPosition = 0; // we don't need the data anymore in the scratch packet
			return temp;
		}
		else return NULL; // we haven't received the whole packet, skip till next Input event
	}
	
void wowPacket::Cue()
{
	ScratchPackets *Spackets = (ScratchPackets*)mSocket->GetClientData();
	if (Spackets->OutputScratchPacket)
		Spackets->PendingPackets.Attach(this);
	else
		Spackets->OutputScratchPacket = this;
}

extern "C" 
{
#include <lua.h>
}
#define oldnew new
#undef new
#include <luabind/luabind.hpp>
#include <luabind/adopt_policy.hpp>
#define new oldnew

using namespace luabind;

std::ostream& operator<<(std::ostream& os, LuaCharBinder& s)
{
	os<< s.val;
	return os;
}

void wowPacket::LuaBind(lua_State *L)
{
	typedef void (wowPacket::*t1)(const char*);
	typedef LuaCharBinder*(wowPacket::*t2)();
	module(L)
		[
			class_<LuaCharBinder>("__LuaCharBinder")
				.def(tostring(self))
				,
			class_<wowPacket>("wowPacket")
				.def(constructor<>()													)
				.def("Getu8"			,	&wowPacket::Getu8							)
				.def("Gets8"			,	&wowPacket::Gets8							)
				.def("Getu16"			,	&wowPacket::Getu16							)
				.def("Gets16"			,	&wowPacket::Gets16							)
				.def("Getu32"			,	&wowPacket::Getu32							)
				.def("Gets32"			,	&wowPacket::Gets32							)
				.def("Getf32"			,	&wowPacket::Getf32							)
				.def("Getf64"			,	&wowPacket::Getf64							)
				.def("Putu8"			,	&wowPacket::Putu8							)
				.def("Puts8"			,	&wowPacket::Puts8							)
				.def("Putu16"			,	&wowPacket::Putu16							)
				.def("Puts16"			,	&wowPacket::Puts16							)
				.def("Putu32"			,	&wowPacket::Putu32							)
				.def("Puts32"			,	&wowPacket::Puts32							)
				.def("Putf32"			,	&wowPacket::Putf32							)
				.def("Putf64"			,	&wowPacket::Putf64							)
				.def("Putcstr"			,	(t1)&wowPacket::Putcstr						)
				.def("Putcstr0"			,	(t1)&wowPacket::Putcstr0					)
				.def("Getcstr"			,	(t2)&wowPacket::Getcstr,adopt(return_value)	)
				.def("Skip"				,	&wowPacket::Skip							)
				.def("Grow"				,	&wowPacket::Grow							)
				.def("SetPosition"		,	&wowPacket::SetPosition						)
				.def("GetPosition"		,	&wowPacket::GetPosition						)
				.def("PutHeader"		,	&wowPacket::PutHeader						)
				.def("Finalize"			,	&wowPacket::Finalize						)
				.def("GetPacketSize"	,	&wowPacket::GetPacketSize					)
				.def("GetPacketType"	,	&wowPacket::GetPacketType					)
				.def("SkipHeader"		,	&wowPacket::SkipHeader						)


		];
		
	
}

