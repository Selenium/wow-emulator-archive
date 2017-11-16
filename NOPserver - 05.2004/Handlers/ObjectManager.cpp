#include "ObjectManager.h"

ObjectManager::ObjectManager (void) { }

wxString ObjectManager::GetObjName (wxLongLong id) {
    if (Objects.find(id) == Objects.end())
        return _T("");
    else
        return Objects[id]->GetName();
}

void ObjectManager::NameQuery (wowPacket *packet) {
    LOG(_T("[ObjectManager] CMSG_NAME QUERY: resolving."));
    packet->SkipHeader();
    wxUint32 lo = packet->Getu32(); wxUint32 hi = packet->Getu32();
    wxLongLong id = wxLongLong(hi, lo);

    wowPacket *NameResponse = new wowPacket(packet->GetSocket());
    NameResponse->PutHeader(SMSG_NAME_QUERY_RESPONSE);
    NameResponse->Putu32(id.GetLo());
    NameResponse->Putu32(id.GetHi());

    wxString response = GetObjName(id);

    if (!response.IsEmpty()) {
        NameResponse->Putcstr0(response);
        NameResponse->Putu32(5); NameResponse->Putu32(0);
        NameResponse->Putu32(5);
    } else {
        NameResponse->Putcstr0(_T("<Invalid ID>"));
        NameResponse->Putu32(5); NameResponse->Putu32(1);
        NameResponse->Putu32(1);
    }

    NameResponse->Finalize();
    WorldThread::GetThread()->PostPacket(NameResponse);
}
