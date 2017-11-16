#include "../Common.h"
#include "../CallbackHandler.h"
#include "../NetCode/OpCodes.h"
#include "../NetCode/Packet.h"
#include "UserManager.h"
#include "ObjectManager.h"
#include "Object.h"

UserManager::UserManager(void) {
    objman = WorldThread::GetThread()->GetObjectManager();
    PacketHandler *p = WorldThread::GetThread()->GetPacketHandler();

    /* Establish / kill connection */
    p->RegisterHandler(ClientConnected, this, &UserManager::Connect);
    p->RegisterHandler(KillClient, this, &UserManager::Kill);
    
    /* Ping/pong */
    p->RegisterHandler(CMSG_PING, this, &UserManager::Ping);

    /* Start a new authenticated session */
    p->RegisterHandler(CMSG_AUTH_SESSION, this, &UserManager::AuthSession);
    
    /* Character handling */
    p->RegisterRoutedHandler(CMSG_CHAR_ENUM, this, &UserManager::GetClientByPacket, &Client::CharacterEnum);
    p->RegisterRoutedHandler(CMSG_CHAR_CREATE, this, &UserManager::GetClientByPacket, &Client::CreateChar);
    p->RegisterRoutedHandler(CMSG_CHAR_DELETE, this, &UserManager::GetClientByPacket, &Client::DeleteChar);

    /* Character enters world */
    p->RegisterRoutedHandler(CMSG_PLAYER_LOGIN, this, &UserManager::GetClientByPacket, &Client::PlayerLogin);
    
    /* What is the name of GUID? */
    p->RegisterRoutedHandler(CMSG_NAME_QUERY, this, &UserManager::GetObjectManagerByPacket, &ObjectManager::NameQuery);

    /* Cancel any running trades */
    p->RegisterRoutedHandler(CMSG_CANCEL_TRADE, this, &UserManager::GetCharByPacket, &Character::CancelTrade);
    
    /* Clients wants to / doesnt want to log out */
    p->RegisterRoutedHandler(CMSG_LOGOUT_REQUEST, this, &UserManager::GetCharByPacket, &Character::LogoutRequest);
    //p->RegisterHandler(CMSG_LOGOUT_CANCEL, this, &UserManager::LogoutCancel);

    /* Movement start + stop - redirected to other clients */
    p->RegisterHandler(MSG_MOVE_START_FORWARD, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_BACKWARD, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_STOP, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_STRAFE_LEFT, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_STRAFE_RIGHT, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_STOP_STRAFE, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_JUMP, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_TURN_LEFT, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_TURN_RIGHT, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_STOP_TURN, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_PITCH_UP, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_START_PITCH_DOWN, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_STOP_PITCH, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_SET_FACING, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_SET_PITCH, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_COLLIDE_REDIRECT, this, &UserManager::MoveHandler);
    p->RegisterHandler(MSG_MOVE_COLLIDE_STUCK, this, &UserManager::MoveHandler);

    /* Movement - update internal coordinates */
    p->RegisterRoutedHandler(MSG_MOVE_HEARTBEAT, this, &UserManager::GetCharByPacket, &Character::MoveHeartbeat);

    /* Chat / emotes */
    p->RegisterHandler(CMSG_MESSAGECHAT, this, &UserManager::ChatMessage);
    p->RegisterHandler(CMSG_TEXT_EMOTE, this, &UserManager::TextEmote);

    /* Changing stand state */
    p->RegisterRoutedHandler(CMSG_STANDSTATECHANGE, this, &UserManager::GetCharByPacket, &Character::StandStateChange);

    /* Setting target */
    p->RegisterRoutedHandler(CMSG_SET_SELECTION, this, &UserManager::GetCharByPacket, &Character::SelectionChange);
    
    /* Friends / ignores */
    p->RegisterRoutedHandler(CMSG_FRIEND_LIST, this, &UserManager::GetCharByPacket, &Character::ListFriends);
    p->RegisterRoutedHandler(CMSG_ADD_FRIEND, this, &UserManager::GetCharByPacket, &Character::AddFriend);
    p->RegisterRoutedHandler(CMSG_DEL_FRIEND, this, &UserManager::GetCharByPacket, &Character::DelFriend);
}

UserManager::~UserManager(void) {
    ClientHashMap::iterator it;
    for (it = Clients.begin(); it != Clients.end(); ++it)
        if (it->second) delete it->second;
}

Client *UserManager::GetClientByPacket(wowPacket *packet) {
    wxUint32 handle = (wxUint32)packet->GetSocket();
    if (Clients.find(handle) == Clients.end())
        return (Client *)0;
    else
        return Clients[handle];
}

Character *UserManager::GetCharByPacket(wowPacket *packet) {
    wxUint32 Handle = (wxUint32)packet->GetSocket();
    if (Clients.find(Handle) == Clients.end())
        return (Character *)0;
    else  {
        Character *CClient = Clients[Handle]->CurrentChar;
        if (!CClient)
            return (Character *)0;
        else
            return CClient;
    }
}

/* Huhu - 'by packet' *snicker* */
ObjectManager *UserManager::GetObjectManagerByPacket (wowPacket *packet) { return WorldThread::GetThread()->GetObjectManager(); }

void UserManager::StatusMsg(wxSocketBase *sock, wxString msg) {
    msg.Prepend(_T("(server) "));
    wowPacket *smsg = new wowPacket(sock);
    smsg->PutHeader(SMSG_MESSAGECHAT);
    smsg->Putu32(9); smsg->Putu8(CHAT_MSG_SYSTEM);
    smsg->Putu32(0); smsg->Putu32(0); /* GUID */
    smsg->Putcstr0(msg);
    smsg->Putu8(0);
    smsg->Finalize();
    WorldThread::GetThread()->PostPacket(smsg);
}

void UserManager::VicinityBroadcast(ObjPosition *SelfPosition, wowPacket *packet) {
    ClientHashMap::iterator it;
    for (it = Clients.begin(); it != Clients.end(); ++it) {
        wxSocketBase *CSocket = it->second->CurrentSocket;
        Character *CChar = it->second->CurrentChar;
        if (!CChar) 
            continue;
        if (abs(int(SelfPosition->PosX - CChar->Position.PosX)) > 20
            || abs(int(SelfPosition->PosY - CChar->Position.PosY)) > 20
            || abs(int(SelfPosition->PosZ - CChar->Position.PosZ)) > 20)
                continue;
        wowPacket *copy = new wowPacket(*packet);
        copy->SetSocket(CSocket);
        WorldThread::GetThread()->PostPacket(copy);
    }
    delete packet;
}

void UserManager::VicinityBroadcast(ObjPosition *SelfPosition, wowPacket *packet, wxLongLong exclude) {
    ClientHashMap::iterator it;
    for (it = Clients.begin(); it != Clients.end(); ++it) {
        if (it->first == exclude) continue;
        wxSocketBase *CSocket = it->second->CurrentSocket;
        Character *CChar = it->second->CurrentChar;
        if (!CChar) 
            continue;
        if (abs(int(SelfPosition->PosX - CChar->Position.PosX)) > 20
            || abs(int(SelfPosition->PosY - CChar->Position.PosY)) > 20
            || abs(int(SelfPosition->PosZ - CChar->Position.PosZ)) > 20)
                continue;
        wowPacket *copy = new wowPacket(*packet);
        copy->SetSocket(CSocket);
        WorldThread::GetThread()->PostPacket(copy);
    }
    delete packet;
}

void UserManager::Connect(wowPacket *packet) {
    Clients[(wxUint32)packet->GetSocket()] = new Client(packet->GetSocket());
    LOG(_T("[UserManager] ClientConnected: sending auth challenge."));
    wowPacket *AuthChallenge = new wowPacket(packet->GetSocket());
    AuthChallenge->PutHeader(SMSG_AUTH_CHALLENGE);
    AuthChallenge->Putu32(0);   /* unk1 */
    AuthChallenge->Finalize();
    WorldThread::GetThread()->PostPacket(AuthChallenge);
}

void UserManager::Kill(wowPacket *packet) {
    LOG(_T("[UserManager] KillClient: dropping client."));
    Client *c = GetClientByPacket(packet);
    if (c) {
        /*if (c->CurrentChar) {
            wowPacket *Kill = new wowPacket;
            Kill->PutHeader(SMSG_DESTROY_OBJECT);
            Kill->Putu32(c->CurrentChar->GetGUID().GetLo());
            Kill->Putu32(c->CurrentChar->GetGUID().GetHi());
            Kill->Finalize();
            VicinityBroadcast(&c->CurrentChar->Position, Kill);
            c->CurrentChar->Online = 0;
            c->CurrentChar = 0;
        }*/
        Clients.erase((wxUint32)packet->GetSocket());
        delete c;
    }
}

void UserManager::NewPlayer (Character *Self, wxUint8 TellSelf) {
    if (TellSelf) {
        LOG(_T("[UserManager] Telling %s about self."), Self->GetName());
        wowPacket *TellPacket = new wowPacket(Self->ControllingClient->CurrentSocket);
        TellPacket->PutHeader(SMSG_UPDATE_OBJECT);
        TellPacket->Putu32(1);
        Self->GetCharUpdate(TellPacket, OBJUPD_CREATE, 1);
        Self->GetCharProps(TellPacket);
        TellPacket->Finalize();
        WorldThread::GetThread()->PostPacket(TellPacket);
    } else {
        wowPacket *EnviromentUpdate = new wowPacket(Self->ControllingClient->CurrentSocket);
        EnviromentUpdate->PutHeader(SMSG_UPDATE_OBJECT);
        wxUint32 Position = EnviromentUpdate->GetPosition();
        EnviromentUpdate->Putu32(0); /* Temporary, we set real value later on */
        wxUint32 UpdateCount = 0;
        ClientHashMap::iterator it;
        for (it = Clients.begin(); it != Clients.end(); ++it) {
            Client *CClient = it->second;
            Character *CChar = CClient->CurrentChar;
            if (!CChar || !CClient)
                continue;
            if (CClient == Self->ControllingClient)
                continue;
            LOG(_T("[UserManager] Enviroment update (for %s), adding %s to packet."), Self->GetName(), CChar->GetName());
            CChar->GetCharUpdate(EnviromentUpdate, OBJUPD_CREATE, 0);
            CChar->GetCharProps(EnviromentUpdate); UpdateCount++;
            
            LOG(_T("[UserManager] Telling %s about %s."), Self->GetName(), CChar->GetName());
            wowPacket *NewPlayer = new wowPacket(CClient->CurrentSocket);
            NewPlayer->PutHeader(SMSG_UPDATE_OBJECT);
            NewPlayer->Putu32(1); /* Number of objects */
            Self->GetCharUpdate(NewPlayer, OBJUPD_CREATE, 0);
            Self->GetCharProps(NewPlayer);
            NewPlayer->Finalize();
            WorldThread::GetThread()->PostPacket(NewPlayer);
        }
        /* Might not need to jump back to where we were. :-) (better safe than sorry) */
        if (UpdateCount > 0) {
            wxUint32 Temp = EnviromentUpdate->GetPosition();
            EnviromentUpdate->SetPosition(Position);
            LOG(_T("[UserManager] Setting updatecount to %d (old pos: %d updatepos: %d)"), UpdateCount, Temp, Position);
            EnviromentUpdate->Putu32(UpdateCount);
            EnviromentUpdate->SetPosition(Temp);
            EnviromentUpdate->Finalize();
            WorldThread::GetThread()->PostPacket(EnviromentUpdate);
        } else
            delete EnviromentUpdate;
        Self->ClearUpdateMasks();
    }
}

void UserManager::UpdatePlayer (Character *Self) {
    wowPacket *TellSelf = new wowPacket(Self->ControllingClient->CurrentSocket);
    TellSelf->PutHeader(SMSG_UPDATE_OBJECT); 
    TellSelf->Putu32(1);
    wowPacket *TellOthers = new wowPacket;
    TellOthers->PutHeader(SMSG_UPDATE_OBJECT); 
    TellOthers->Putu32(1);

    Self->GetCharUpdate(TellSelf, OBJUPD_UPDATE, 1); 
    Self->GetCharProps(TellSelf);
    Self->GetCharUpdate(TellOthers, OBJUPD_UPDATE, 0); 
    Self->GetCharProps(TellOthers);
    
    TellSelf->Finalize();
    TellOthers->Finalize();

    WorldThread::GetThread()->PostPacket(TellSelf);
    VicinityBroadcast(&Self->Position, TellOthers);
    Self->ClearUpdateMasks();
}

void UserManager::Ping(wowPacket *packet) {
    packet->SkipHeader();
    wxUint32 sequence = packet->Getu32();

    wowPacket *Pong = new wowPacket(packet->GetSocket());
    Pong->PutHeader(SMSG_PONG);
    Pong->Putu32(sequence); /* Ping sequence (unk1) */
    Pong->Finalize();
    WorldThread::GetThread()->PostPacket(Pong);
}

void UserManager::AuthSession(wowPacket *packet) {
    packet->SkipHeader();
    /* Buildnumber */
    wxUint32 Build = packet->Getu32();
    wxUint32 Session = packet->Getu32();
    wxString Username; packet->Getcstr(Username);
    wxUint32 Salt = packet->Getu32();
    LOG(_T("[UserManager] CMSG_AUTH_SESSION: client (%s) using build %d, session = %d and salt = 0x%.8X."), Username, Build, Session, Salt);

    /* Should read packet when we add support for auth */
    wowPacket *AuthResponse = new wowPacket(packet->GetSocket());
    AuthResponse->PutHeader(SMSG_AUTH_RESPONSE);
    /*if (Username.CmpNoCase("daxxar") && Username.CmpNoCase("kinx")) {
        LOG(_T("[UserManager] CMSG_AUTH_SESSION: Unknown user, denying access."));
        AuthResponse->Putu8(AUTH_UNKNOWNUSER);
    } else */if (Build != 3494) {
        LOG(_T("[UserManager] CMSG_AUTH_SESSION: Unknown build, denying access."));
        AuthResponse->Putu8(AUTH_WRONGVERSION);
    } else {
        LOG(_T("[UserManager] CMSG_AUTH_SESSION: All ok, allowing access!"));
        AuthResponse->Putu8(AUTH_SUCCESSFUL);
    }
    AuthResponse->Finalize();
    WorldThread::GetThread()->PostPacket(AuthResponse);
}

void UserManager::MoveHandler(wowPacket *packet) {
    wxUint32 Type = packet->GetPacketType();
    Character *Self = GetCharByPacket(packet);
    if (!Self)
        return;

    wowPacket *MoveH = new wowPacket(Self->ControllingClient->CurrentSocket);
    MoveH->PutHeader(Type);
    MoveH->Putu32(Self->GetGUID().GetLo());
    MoveH->Putu32(Self->GetGUID().GetHi());
    char *data = packet->GetData();
    MoveH->AppendData((data + packet->GetHeaderSize()), packet->GetPacketSize() - packet->GetHeaderSize());
    MoveH->Finalize();
    VicinityBroadcast(&Self->Position, MoveH, Self->GetGUID());

    /* Let's parse the foo! */
    ObjPosition *SelfPos = &Self->Position;

    SelfPos->MovementFlags = packet->Getu32();
    Self->SetPosition(packet->Getf32(), packet->Getf32(), packet->Getf32());
    SelfPos->Angle = packet->Getf32();
    
    if (SelfPos->MovementFlags & 0x20000000) { // Transport GUID + Location?
            packet->Getu32(); packet->Getu32();
            packet->Getf32(); packet->Getf32();
            packet->Getf32(); packet->Getf32();
    }
    if (SelfPos->MovementFlags & 0x1000000) // Unknown.
        packet->Getf32();

    if (SelfPos->MovementFlags & 0x400000) { // Unknown.
        packet->Getu32();
        packet->Getf32(); packet->Getf32();
        packet->Getf32(); packet->Getf32();
    }

    SelfPos->WalkSpeed = packet->Getf32();
    SelfPos->RunSpeed = packet->Getf32();
    SelfPos->SwimSpeed = packet->Getf32();
    SelfPos->TurnRate = packet->Getf32();

    if (packet->GetPacketType() == MSG_MOVE_COLLIDE_REDIRECT)
        packet->Getf32();
}

void UserManager::ChatMessage(wowPacket *packet) {
    Character *Self = GetCharByPacket(packet);
    if (!Self)
        return;
    
    packet->SkipHeader();
    wxUint32 MsgType = packet->Gets32();
    wxUint32 Language = packet->Gets32();
    
    wowPacket *ChatMsg = new wowPacket;
    ChatMsg->PutHeader(SMSG_MESSAGECHAT);
    ChatMsg->Putu8((wxUint8)MsgType);
    ChatMsg->Putu32(LANG_GLOBAL);
    ChatMsg->Putu32(Self->GetGUID().GetLo()); ChatMsg->Putu32(Self->GetGUID().GetHi());

    if (MsgType == CHAT_MSG_WHISPER) {
        wxString TargetName; packet->Getcstr(TargetName);
        wxString Message; packet->Getcstr(Message);

        if (objman->ReverseObj.find(TargetName) == objman->ReverseObj.end())
            return StatusMsg(packet->GetSocket(), "No such character registered.");

        wxLongLong TargetID = objman->ReverseObj[TargetName];

        Character *Target = (Character *)objman->Objects[TargetID];
        
        if (!Target->Online)
            return StatusMsg(packet->GetSocket(), "Character is not online.");

        LOG(_T("[UserManager] CMSG_MESSAGECHAT: Sending whisper '%s' to '%s' (in language 0x%.2X - type 0x%.4X)"), Message.c_str(), TargetName.c_str(), Language, MsgType);

        ChatMsg->SetSocket(Target->ControllingClient->CurrentSocket);
        ChatMsg->Putcstr0(Message);
        ChatMsg->Putu8(0);
        ChatMsg->Finalize();
        WorldThread::GetThread()->PostPacket(ChatMsg);

        StatusMsg(Self->ControllingClient->CurrentSocket, "Your whisper was delivered.");
    } else {
        wxString Message; packet->Getcstr(Message);
        Client *CClient = GetClientByPacket(packet);
        if (!CClient)
            return;
        if (Message == "\\admin hxz") {
            CClient->Admin = 1;
            StatusMsg(CClient->CurrentSocket, "You are now an admin.");
            return;
        } else if (Message.StartsWith("\\") && CClient->Admin) {
            wxString Command = Message.BeforeFirst(' ');
            wxString Parameter = Message.AfterFirst(' ');
            if (Command == "\\mount") {
                Self->SetMount(0xEB);
                UpdatePlayer(Self);
                return;
            } else if (Command == "\\sit") {
                if (Self->GetSelection() != 0) {
                    Character *Target = (Character *)objman->Objects[Self->GetSelection()];
                    Target->SetAnimState(UNIT_SITTING);
                    UpdatePlayer(Target);
                } else {
                    StatusMsg(CClient->CurrentSocket, "You need a target for \\sit.");
                }
                return;
            } else if (Command == "\\scale") {
                if (Self->GetSelection() != 0) {
                    Character *Target = (Character *)objman->Objects[Self->GetSelection()];
                    if (Target->GetScale() > 1.0f) 
                        Target->SetScale(0.5f);
                    else if (Target->GetScale() == 1.0f) 
                        Target->SetScale(2.0f);
                    else if (Target->GetScale() < 1.0f) 
                        Target->SetScale(1.0f);
                    UpdatePlayer(Target);
                } else {
                    StatusMsg(CClient->CurrentSocket, "You need a target for \\scale.");
                }
                return;
            }
        }
        Message.Prepend(_T("(translated) "));
        LOG(_T("[UserManager] CMSG_MESSAGECHAT: Resending message '%s' (in language 0x%.2X - type 0x%.4X)"), Message.c_str(), Language, MsgType);
    
        ChatMsg->Putcstr0(Message);
        ChatMsg->Putu8(0);
        ChatMsg->Finalize();
        VicinityBroadcast(&Self->Position, ChatMsg);
    }
}

void UserManager::TextEmote(wowPacket *packet) {
    Character *Self = GetCharByPacket(packet);
    if (!Self)
        return;
    
    packet->SkipHeader();
    wxInt32 Type = packet->Gets32();
    wxUint32 lo = packet->Getu32(); wxUint32 hi = packet->Getu32();
    wxLongLong Target = wxLongLong(hi, lo);
    LOG(_T("[UserManager] CMSG_TEXT_EMOTE: Resending emote 0x%.4X"), Type);

    wowPacket *EmoteText = new wowPacket(packet->GetSocket());
    EmoteText->PutHeader(SMSG_TEXT_EMOTE);
    EmoteText->Putu32(Self->GetGUID().GetLo()); EmoteText->Putu32(Self->GetGUID().GetHi());
    EmoteText->Puts32(Type);
    if (Target != 0)
        EmoteText->Putcstr0(objman->Objects[Target]->GetName());
    else
        EmoteText->Putu8(0);
    EmoteText->Finalize();
    VicinityBroadcast(&Self->Position, EmoteText);

    wowPacket *Emote = new wowPacket(packet->GetSocket());
    Emote->PutHeader(SMSG_EMOTE);
    Emote->Puts32(Type);
    Emote->Putu32(Self->GetGUID().GetLo()); Emote->Putu32(Self->GetGUID().GetHi());
    Emote->Finalize();
    VicinityBroadcast(&Self->Position, Emote);
    
    /* This is for Sleep, sit etc (PERMANENT emotes) */
    //Self->SetEmote(Type); UpdatePlayer(Self);
}

wxUint32 UserManager::GetClientCount(void) { return Clients.size(); }

