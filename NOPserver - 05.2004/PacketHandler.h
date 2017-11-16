#ifndef _PACKETHANDLER_H
#define _PACKETHANDLER_H

#include "WorldThread.h"
#include "NetCode/Packet.h"
#include "HandlerTemplates.h"


WX_DECLARE_HASH_MAP( wxUint32,HandlerFunctor*,wxIntegerHash,wxIntegerEqual,HandlerMap );
class PacketHandler
{
	HandlerMap Handlers;
	WorldThread *Parent;
//	LuaObject ScriptHandlers;
public:
	PacketHandler(WorldThread*);
	~PacketHandler(void);
	
	template<class T>
	void RegisterHandler(wxUint32 type, T* obj,void (T::*m)(wowPacket*))
	{
		HandlerFunctor *old= Handlers[type];
		if(old) delete old;
		Handlers[type] = new MemberHandlerFunctor<T>(obj,m);
	}
	template<class HANDLER,class ROUTER>
		void RegisterRoutedHandler(wxUint32 type, ROUTER* obj,HANDLER *(ROUTER::*r)(wowPacket *),void (HANDLER::*h)(wowPacket *))
	{
		HandlerFunctor *old= Handlers[type];
		if(old) delete old;
		Handlers[type] = new RoutedHandlerFunctor<HANDLER,ROUTER>(obj,r,h);
	}

	void RegisterHandler(wxUint32 type, void (*f)(wowPacket*))
	{
		HandlerFunctor *old= Handlers[type];
		if(old) delete old;
		Handlers[type] = new FunctionHandlerFunctor(f);
	}
	inline void HandlePacket(wowPacket *p)
	{
		wxUint32 type = p->GetPacketType();
		HandlerFunctor *h= Handlers[type];
		if(h) (*h)(p);
		else //try the script;
		{
			/*LuaObject funcObj = ScriptHandlers.GetByIndex(type);
			if (funcObj.IsFunction())
			{
				LuaFunction<> func = funcObj;
				//func(p); have to define the LCD types
			}else */
			//wasnt handled and funcobj is not a function log it
			LOG("[PacketHandler]: Unhandled packet: 0x%.4X",type);
		}
		delete p; // whatever happened here the packet's road ends;
	}
};

#endif 
