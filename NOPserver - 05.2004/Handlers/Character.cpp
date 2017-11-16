#include "Character.h"
#include "UserManager.h"
#include "../WorldThread.h"
#include "../Common.h"

/* We need to send these when we send an Object Update 
   w/ type create about ourselves (Char) */
const wxUint32 CreateReqSize_CharSelf = 4;
const wxUint32 CreateReqItems_CharSelf[CreateReqSize_CharSelf] = {
        CHAR_FACE, CHAR_CURRENT_XP,
        CHAR_NEXTLEVEL_XP, CHAR_FACIALHAIR
};

Character::Character(Client *client, wxString name) : Unit(TYPE_CHAR, name) { CharConstructor(client, name); }
Character::Character(Client *client, wxString name, wxLongLong id) : Unit(id) {
    CharConstructor(client, name);
    LOG(_T("[Character] Adding to reverse db (%s -> %.4X %.4X)"), GetName(), id.GetLo(), id.GetHi());
    WorldThread::GetThread()->GetObjectManager()->ReverseObj[GetName()] = id;
}

Character::~Character (void) {
    WorldThread::GetThread()->GetObjectManager()->ReverseObj.erase(GetName());
}

void Character::CharConstructor (Client *c, wxString n) {
    memset(ActionButtons, 0, NumActionButtons * sizeof(wxUint32));
    HomeCity = 9; Realm = 0; Online = 0; SetName(n); SetType(GetType() + BMASK_CHAR);
    ControllingClient = c; ControllingClient->Characters[GetGUID()] = this;
}

wxInt32 Character::FindFriend (wxLongLong FID) {
    for (GUIDNode *node = Friends.GetFirst(); node; node = node->GetNext()) {
        if (*node->GetData() == FID)
            return node->GetIndex();
    } 
    return -1;
}

void Character::GetCharUpdate (wowPacket *packet, wxUint32 UpdateType, wxUint32 self) {
    GetUnitUpdate(packet, UpdateType, self);
    if (UpdateType == OBJUPD_CREATE) {
        if (self) {
            for (wxUint8 x = 0; x < CreateReqSize_CharSelf; x++) {
                if (!(ISSET(UpdateMasks, CreateReqItems_CharSelf[x])))
                    SETMASK(UpdateMasks, CreateReqItems_CharSelf[x]);
            }
        }
        LOG(_T("Update, %d nummasks"), NumMasks);

        packet->Putu8(NumMasks);
        packet->PutData(UpdateMasks, NumMasks * sizeof(wxUint32));
    } else if (UpdateType == OBJUPD_UPDATE) {
        packet->Putu8(NumMasks);
        packet->PutData(UpdateMasks, NumMasks*4);
    } else 
        LOG(_T("[Char] Got unsupported type %d in GetCharUpdate."), UpdateType);

}

void Character::GetCharProps (wowPacket *packet) {
    GetUnitProps(packet);
    for (wxUint32 x = CHAR_START; x <= CHAR_END; x++)
        if (ISSET(UpdateMasks, x))
            packet->Putu32(PropertyMap[x].uint32);
}

void Character::ListFriends (wowPacket *packet) {
    wowPacket *FList = new wowPacket(packet->GetSocket());
    FList->PutHeader(SMSG_FRIEND_LIST);
    FList->Putu8((wxUint8)Friends.GetCount());
    for (GUIDNode *node = Friends.GetFirst(); node; node = node->GetNext()) {
        ObjectManager *objm = WorldThread::GetThread()->GetObjectManager();
        if (!node->GetData())
            continue;
        wxLongLong id = *node->GetData();
        if (objm->Objects.find(id) == objm->Objects.end()) {
            wowPacket *FDeleted = new wowPacket(packet->GetSocket());
            FDeleted->PutHeader(SMSG_FRIEND_STATUS);
            FDeleted->Putu8(FRIEND_REMOVED);
            FDeleted->Putu32(id.GetLo());
            FDeleted->Putu32(id.GetHi());
            FDeleted->Finalize();
            WorldThread::GetThread()->PostPacket(FDeleted);
            Friends.DeleteNode(node);
        } else {
            Character *current = (Character *)objm->Objects[id];
            FList->Putu32(id.GetLo());
            FList->Putu32(id.GetHi());
            if (!current->Online)
                FList->Putu8(FRIENDLIST_OFFLINE);
            else {
                FList->Putu8(FRIENDLIST_ONLINE);
                FList->Putu32(1); /* area */
                FList->Putu32(current->GetClass());
                FList->Putu32(current->GetLevel());
            }
        }
        FList->Finalize();
        WorldThread::GetThread()->PostPacket(FList);
    }
}

void Character::AddFriend (wowPacket *packet) {
    packet->SkipHeader(); 
    wxString f; packet->Getcstr(f);
    ObjectManager *objm = WorldThread::GetThread()->GetObjectManager();
    wowPacket *FStatus = new wowPacket(packet->GetSocket());
    FStatus->PutHeader(SMSG_FRIEND_STATUS);
    if (objm->ReverseObj.find(f) == objm->ReverseObj.end())
        FStatus->Putu8(FRIEND_NOT_FOUND);
    else {
        wxLongLong *id = &(objm->ReverseObj[f]);
        if (*id == GetGUID()) {
            FStatus->Putu8(FRIEND_SELF);
            FStatus->Putu32(id->GetLo());
            FStatus->Putu32(id->GetHi());
        } else if (FindFriend(*id) != wxNOT_FOUND) { 
            FStatus->Putu8(FRIEND_ALREADY);
            FStatus->Putu32(id->GetLo());
            FStatus->Putu32(id->GetHi());
        } else if (Friends.GetCount() > 32) {
            FStatus->Putu8(FRIEND_LIST_FULL);
            FStatus->Putu32(id->GetLo());
            FStatus->Putu32(id->GetHi());
        } else {
            Friends.Append(id);
            Character *Friend = (Character *)objm->Objects[*id];
            if (Friend->Online)
                FStatus->Putu8(FRIEND_ADDED_ONLINE);
            else
                FStatus->Putu8(FRIEND_ADDED_OFFLINE);
            
            FStatus->Putu32(id->GetLo());
            FStatus->Putu32(id->GetHi());

            if (Friend->Online) {
                FStatus->Putu32(Friend->GetLevel());
                FStatus->Putu32(Friend->GetClass());
                FStatus->Putu32(1); /* area */
            }
        }
    }
    FStatus->Finalize();
    WorldThread::GetThread()->PostPacket(FStatus);
}

void Character::DelFriend (wowPacket *packet) {   
    packet->SkipHeader();
    wxUint32 lo = packet->Getu32(), hi = packet->Getu32();
    wxLongLong id = wxLongLong(hi, lo);
    wxUint32 index = FindFriend(id);

    wowPacket *FStatus = new wowPacket(packet->GetSocket());
    FStatus->PutHeader(SMSG_FRIEND_STATUS);
    if (index == wxNOT_FOUND)
        FStatus->Putu8(FRIEND_NOT_FOUND);
    else {
        GUIDNode *node = Friends.FindByIndex(index);
        if (node)
            Friends.DeleteNode(node);
        FStatus->Putu8(FRIEND_REMOVED);
    }
    FStatus->Putu32(id.GetLo());
    FStatus->Putu32(id.GetHi());
    FStatus->Finalize();
    WorldThread::GetThread()->PostPacket(FStatus);
}

void Character::MoveHeartbeat (wowPacket *packet) {
    packet->SkipHeader();
    wxUint32    pUnk1   = packet->Getu32();
    wxUint32    pUnk2   = packet->Getu32();
    wxFloat32   x1      = packet->Getf32();
    wxFloat32   y1      = packet->Getf32();
    wxFloat32   z1      = packet->Getf32();
    wxUint32    pUnk3   = packet->Getu32();

    if (   x1 == Position.PosX
        && y1 == Position.PosY
        && z1 == Position.PosZ) 
        return;

    wxFloat32   x2      = packet->Getf32();
    wxFloat32   y2      = packet->Getf32();
    wxFloat32   z2      = packet->Getf32();
    wxUint32    pUnk4   = packet->Getu32(); 

    wxUint32    pUnk5   = packet->Getu32();
    wxUint32    pUnk6   = packet->Getu32();


    SetPosition(x1, y1, z1);
}

void Character::LogoutRequest(wowPacket *packet) {
    /* TODO: add code that checks if the player is in a valid state to logout */
    /*if (GetAnimState() != UNIT_SITTING) {
        LOG(_T("[Character] Disallowing CMSG_LOGOUT_REQUEST for %s; not sitting"), GetName());
        wowPacket *LogFailed = new wowPacket(packet->GetSocket());
        LogFailed->PutHeader(SMSG_LOGOUT_RESPONSE);
        LogFailed->Putu8(LOGOUT_FAILURE);
        LogFailed->Finalize();
        WorldThread::GetThread()->PostPacket(LogFailed);
    } else {*/
        LOG(_T("[Character] CMSG_LOGOUT_REQUEST: logging out."));

        wowPacket *LogComplete = new wowPacket(packet->GetSocket());
        LogComplete->PutHeader(SMSG_LOGOUT_COMPLETE);
        LogComplete->Finalize();
        WorldThread::GetThread()->PostPacket(LogComplete);

        wowPacket *Kill = new wowPacket;
        Kill->PutHeader(SMSG_DESTROY_OBJECT);
        Kill->Putu32(GetGUID().GetLo());
        Kill->Putu32(GetGUID().GetHi());
        Kill->Finalize();

        WorldThread::GetThread()->GetUserManager()->VicinityBroadcast(&Position, Kill);

        Online = 0; ControllingClient->CurrentChar = 0;
    //}
}

void Character::CancelTrade(wowPacket *packet) {    
    wowPacket *Canceled = new wowPacket(packet->GetSocket());
    Canceled->PutHeader(SMSG_TRADE_STATUS);
    Canceled->Putu32(TRADE_STATUS_CANCELLED);
    Canceled->Finalize();
    WorldThread::GetThread()->PostPacket(Canceled);
}


void Character::EnterWorld (void) {
    Online = 1;
    wxSocketBase *CSocket = ControllingClient->CurrentSocket;

    /* send SMSG_INITCLIENT */
    wowPacket *InitClient = new wowPacket(CSocket);
    InitClient->PutHeader(SMSG_INITCLIENT);
    for (wxUint32 i = 0; i < 4; i++) {
        InitClient->Putu32(0); InitClient->Putu32(0);
        InitClient->Putu32(0); InitClient->Putu32(0);
    }
    InitClient->Finalize();
    WorldThread::GetThread()->PostPacket(InitClient);

    /* send SMSG_FRIEND_LIST */
    wowPacket *temp = new wowPacket(CSocket);
    ListFriends(temp);
    delete temp;

    /* send SMSG_IGNORE_LIST */
    wowPacket *IList = new wowPacket(CSocket);
    IList->PutHeader(SMSG_IGNORE_LIST);
    IList->Putu8(0);
    IList->Finalize();
    WorldThread::GetThread()->PostPacket(IList);

    /* send SMSG_BINDPOINTUPDATE */
    wowPacket *BPUpdate = new wowPacket(CSocket);
    BPUpdate->PutHeader(SMSG_BINDPOINTUPDATE);
    BPUpdate->Putf32(Position.PosX);
    BPUpdate->Putf32(Position.PosY);
    BPUpdate->Putf32(Position.PosZ);
    BPUpdate->Putu32(0);
    BPUpdate->Finalize();
    WorldThread::GetThread()->PostPacket(BPUpdate);

    /* send SMSG_TUTORIAL_FLAGS */
    wowPacket *TutorialFlags = new wowPacket(CSocket);
    TutorialFlags->PutHeader(SMSG_TUTORIAL_FLAGS);
    //char voiddata[1024];
    //memset(voiddata, 0, 1024);
    //TutorialFlags->PutData(voiddata,32);
    TutorialFlags->Puts32(-1);
    TutorialFlags->Finalize();
    WorldThread::GetThread()->PostPacket(TutorialFlags);

    /* send SMSG_INITIAL_SPELLS */
    /*unsigned char rawData_InitSpells[113] = {
        0x00, 0x1B, 0x00, 0x25, 0x0D, 0x00, 0x00, 0xEA, 0x0B, 0x00, 0x00, 0x4E, 0x09, 0x00, 0x00, 0x59, 
            0x18, 0x00, 0x00, 0x66, 0x18, 0x00, 0x00, 0x67, 0x18, 0x00, 0x00, 0x4D, 0x19, 0x00, 0x00, 0x4E, 
            0x19, 0x00, 0x00, 0xCB, 0x19, 0xFF, 0xFF, 0x62, 0x1C, 0x00, 0x00, 0x63, 0x1C, 0x00, 0x00, 0xBB, 
            0x1C, 0x00, 0x00, 0xF4, 0x0F, 0xFE, 0xFF, 0x6B, 0x14, 0xFD, 0xFF, 0x40, 0x1E, 0xFC, 0xFF, 0x91, 
            0x13, 0x00, 0x00, 0x9B, 0x13, 0xFB, 0xFF, 0xC6, 0x00, 0x00, 0x00, 0x02, 0x08, 0x01, 0x00, 0x49, 
            0x02, 0x02, 0x00, 0xCC, 0x00, 0x00, 0x00, 0x51, 0x00, 0xFA, 0xFF, 0x0A, 0x02, 0x00, 0x00, 0x9C, 
            0x02, 0x00, 0x00, 0x9D, 0x02, 0x00, 0x00, 0xE3, 0x00, 0x00, 0x00, 0xCB, 0x00, 0x00, 0x00, 0x00, 
            0x00, 
    };*/
    //unsigned char rawData_InitSpells[9] = { 0x00, 0x00, 0x00, 0x02, 0x08, 0x01, 0x00, 0x00, 0x00, };
    wowPacket *InitSpells = new wowPacket(CSocket);
    InitSpells->PutHeader(SMSG_INITIAL_SPELLS);
    //InitSpells->PutData(rawData_InitSpells, 113);// 9);// 113);
    InitSpells->Putu8(0);
    InitSpells->Putu16(2); // Spell count
    InitSpells->Putu16(0x74);// Language common
    InitSpells->Putu16(1);
    InitSpells->Putu16(0x29C); // Language common
    InitSpells->Putu16(0);
    InitSpells->Putu16(0);
    InitSpells->Finalize();
    WorldThread::GetThread()->PostPacket(InitSpells);

    /* send SMSG_ACTION_BUTTONS */
    wowPacket *AButtons = new wowPacket(CSocket);
    AButtons->PutHeader(SMSG_ACTION_BUTTONS);
    AButtons->PutData(ActionButtons, sizeof(wxUint32) * NumActionButtons);
    AButtons->Finalize();
    WorldThread::GetThread()->PostPacket(AButtons);

    /* send SMSG_INITIALIZE_FACTIONS */
    /*wowPacket *InitFactions = new wowPacket(CSocket);
    InitFactions->PutHeader(SMSG_INITIALIZE_FACTIONS);
    InitFactions->Putu32(0x00000040);
    InitFactions->Putu8(2); InitFactions->Putu32(0);
    InitFactions->Putu8(0); InitFactions->Putu32(0);
    InitFactions->Putu8(2); InitFactions->Putu32(0);
    InitFactions->Putu8(2); InitFactions->Putu32(0);
    InitFactions->PutData(voiddata, 300);
    InitFactions->Finalize();
    WorldThread::GetThread()->PostPacket(InitFactions);*/

    /* send SMSG_LOGIN_SETTIMESPEED */
    wowPacket *SetTS = new wowPacket(CSocket);
    SetTS->PutHeader(SMSG_LOGIN_SETTIMESPEED);
    SetTS->Putu32(0x04010d35);
    SetTS->Putu32(0x3c888889);
    SetTS->Finalize();
    WorldThread::GetThread()->PostPacket(SetTS);

    /* THATS YOU! YEAH! ITS YOU! */
    WorldThread::GetThread()->GetUserManager()->NewPlayer(this, 1);

    wowPacket *ChanNotify = new wowPacket(CSocket);
    ChanNotify->PutHeader(SMSG_CHANNEL_NOTIFY);
    ChanNotify->Putu8(2);
    ChanNotify->Putcstr0(_T("General"));
    ChanNotify->Finalize();
    WorldThread::GetThread()->PostPacket(ChanNotify);

    wowPacket *ChatNotify = new wowPacket(CSocket);
    ChatNotify->PutHeader(SMSG_MESSAGECHAT);
    ChatNotify->Putu32(9); ChatNotify->Putu8(0);
    ChatNotify->Putu32(0); ChatNotify->Putu32(0);
    ChatNotify->Putcstr0(_T("Welcome to NOPServer v0.1!\nPlease play with care ;)"));
    ChatNotify->Putu8(0);
    ChatNotify->Finalize();
    WorldThread::GetThread()->PostPacket(ChatNotify);

    /* Introduce the new player to the enviroment and vica versa */
    //WorldThread::GetThread()->GetUserManager()->NewPlayer(this, 0);
}

void Character::StandStateChange (wowPacket *packet) {
    packet->SkipHeader();
    wxUint32 WantedState = packet->Getu32();
    if (GetAnimState() == WantedState) { return; }
    else {
        LOG(_T("[Character] Setting anim-state for %s to %d"), GetName(), WantedState);
        SetAnimState(WantedState);
        WorldThread::GetThread()->GetUserManager()->UpdatePlayer(this);
    }
}

void Character::SelectionChange (wowPacket *packet) {
    packet->SkipHeader();
    wxUint32 lo = packet->Getu32(), hi = packet->Getu32();
    wxLongLong Selection = wxLongLong(hi, lo);
    SetSelection(Selection);
}

/**************************************/
/* Here we set values in UpdateObject */
/**************************************/

void        Character::SetSkin          (wxUint8 in)    { SetValueByte(CHAR_FACE, BYTE_ONE, in); }
void        Character::SetFace          (wxUint8 in)    { SetValueByte(CHAR_FACE, BYTE_TWO, in); }
void        Character::SetHairStyle     (wxUint8 in)    { SetValueByte(CHAR_FACE, BYTE_THREE, in); }
void        Character::SetHairColor     (wxUint8 in)    { SetValueByte(CHAR_FACE, BYTE_FOUR, in); }
void        Character::SetFacialHair    (wxUint8 in)    { SetValueByte(CHAR_FACIALHAIR, BYTE_ONE, in); }

void        Character::SetNextXP        (wxUint32 in)   { SetValue(CHAR_NEXTLEVEL_XP, in); }
void        Character::SetXP            (wxUint32 in)   { SetValue(CHAR_CURRENT_XP, in); }

void        Character::SetSelection     (wxLongLong in) { return SetValueInt64(CHAR_SELECTION, in); }

/****************************************/
/* Here we get values from UpdateObject */
/****************************************/

wxUint8     Character::GetSkin          (void)  { return GetValueByte(CHAR_FACE, BYTE_ONE); }
wxUint8		Character::GetFace          (void)  { return GetValueByte(CHAR_FACE, BYTE_TWO); }
wxUint8		Character::GetHairStyle     (void)  { return GetValueByte(CHAR_FACE, BYTE_THREE); }
wxUint8		Character::GetHairColor     (void)  { return GetValueByte(CHAR_FACE, BYTE_FOUR); }
wxUint8		Character::GetFacialHair    (void)  { return GetValueByte(CHAR_FACIALHAIR, BYTE_ONE); }

wxUint32	Character::GetNextXP        (void)  { return GetValue(CHAR_NEXTLEVEL_XP); }
wxUint32	Character::GetXP            (void)  { return GetValue(CHAR_CURRENT_XP); }

wxLongLong  Character::GetSelection     (void)  { return GetValueInt64(CHAR_SELECTION); }
