#include "Common.h"
#include "ScriptHandler.h"
#include "PacketHandler.h"

PacketHandler::PacketHandler(WorldThread *thread) :Parent(thread)
{
	LuaScriptHandler *temp = Parent->GetScriptHandler();
	wxString *command = new wxString("PacketHandlers = {}");
	temp->ParseCommand(command);
	delete command;
//	ScriptHandlers = temp->GetGlobals()["PacketHandlers"];
}

PacketHandler::~PacketHandler(void)
{
	HandlerMap::iterator it;
    for( it = Handlers.begin(); it != Handlers.end(); ++it )
        if(it->second) delete (it->second);
}
