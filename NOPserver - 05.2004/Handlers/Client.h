#ifndef _CLIENT_H_
#define _CLIENT_H_

#include "../Common.h"
#include "../NetCode/ServerCore.h"
#include "../WorldThread.h"
#include "ObjectManager.h"
#include "Character.h"

class Client {
    public:
                Client          (wxSocketBase *s);
               ~Client          (void);

        void    CharacterEnum   (wowPacket *);        
        void    CreateChar      (wowPacket *);
        void    DeleteChar      (wowPacket *);
        void    PlayerLogin     (wowPacket *);

        wxSocketBase    *CurrentSocket;
        Character       *CurrentChar;
        CharHashMap     Characters;
        wxUint8         Admin;
        /* LogoutStatus:
           0 = not logging out, 1 = logging out - first callbackhandler, 2 = log me out!
        wxUint8         LogoutStatus;*/
};

/*#include "..\Common.h"
#include "servercore.h"

void Client::SendLearnedSpell(wxUint32 spell)
{
    wowPacket       learnedspell;
    learnedspell.PutHeader(svWOW_LEARNED_SPELL);
    learnedspell.Putu32(spell);
    learnedspell.Finalize();
    mSocket->Write(learnedspell.GetData(),learnedspell.GetSize());
}

void Client::SendProficiency(wxUint32 value)
{
    wowPacket       prof;
    prof.PutHeader(svlWOW_PROFICIENCY);
    prof.Putu32(value);
    prof.Putu8(0);
    prof.Finalize();
    mSocket->Write(prof.GetData(),prof.GetSize());


}

 void Client::SendBindPoint()
{
   wowPacket       bindpoint;
    bindpoint.PutHeader(svWOW_SAVEBINDPOINT);
    bindpoint.Putf32(mCharacter->mPosition.mPosX);
    bindpoint.Putf32(mCharacter->mPosition.mPosY);
    bindpoint.Putf32(mCharacter->mPosition.mPosZ);
    bindpoint.Putu32(0);
    bindpoint.Finalize();
    mSocket->Write(bindpoint.GetData(),bindpoint.GetSize());
}

void    Client::EnterWorld                  ()
{

    // send svWOW_FRIENDLIST
    wowPacket       flist;
    flist.PutHeader(svWOW_FRIENDLIST);
    flist.Putu8(0);
    flist.Finalize();
    mSocket->Write(flist.GetData(),flist.GetSize());

    // send svWOW_IGNORELIST
    wowPacket       ilist;
    ilist.PutHeader(svWOW_IGNORELIST);
    ilist.Putu8(0);
    ilist.Finalize();
    mSocket->Write(ilist.GetData(),ilist.GetSize());

    SendBindPoint();

    // send svWOW_CGTUTORIAL_ON_FLAG
    wowPacket       tutorial;
    tutorial.PutHeader(svWOW_CGTUTORIAL_ON_FLAG);
    char voiddata[1024];
    memset(voiddata,0,1024);
    tutorial.PutData(voiddata,32);
    tutorial.Finalize();
    mSocket->Write(tutorial.GetData(),tutorial.GetSize());

    SendLearnedSpell(7355);
    SendLearnedSpell(7267);
    SendLearnedSpell(7266);
    SendLearnedSpell(6603);
    SendLearnedSpell(6478);
    SendLearnedSpell(6477);
    SendLearnedSpell(6246);
    SendLearnedSpell(6233);
    SendLearnedSpell(2382);
    SendLearnedSpell(3050);
    SendLearnedSpell(3365);
    SendLearnedSpell(7744);
    SendLearnedSpell(5227);
    SendLearnedSpell(4084);
    SendLearnedSpell(5019);
    SendLearnedSpell(5009);
    SendLearnedSpell(198);
    SendLearnedSpell(585);
    SendLearnedSpell(2050);
    SendLearnedSpell(522);
    SendLearnedSpell(81);
    SendLearnedSpell(204);
    SendLearnedSpell(668);
    SendLearnedSpell(669);
    SendLearnedSpell(227);
    SendLearnedSpell(203);

    SendProficiency(0x08000002);        // wands
    SendProficiency(0x08001002);
    SendProficiency(0x08441002);
    SendProficiency(0x00000304);

    unsigned char rawData_initialspells[113] = {
            0x00, 0x1B, 0x00, 0x25, 0x0D, 0x00, 0x00, 0xEA, 0x0B, 0x00, 0x00, 0x4E, 0x09, 0x00, 0x00, 0x59, 
            0x18, 0x00, 0x00, 0x66, 0x18, 0x00, 0x00, 0x67, 0x18, 0x00, 0x00, 0x4D, 0x19, 0x00, 0x00, 0x4E, 
            0x19, 0x00, 0x00, 0xCB, 0x19, 0xFF, 0xFF, 0x62, 0x1C, 0x00, 0x00, 0x63, 0x1C, 0x00, 0x00, 0xBB, 
            0x1C, 0x00, 0x00, 0xF4, 0x0F, 0xFE, 0xFF, 0x6B, 0x14, 0xFD, 0xFF, 0x40, 0x1E, 0xFC, 0xFF, 0x91, 
            0x13, 0x00, 0x00, 0x9B, 0x13, 0xFB, 0xFF, 0xC6, 0x00, 0x00, 0x00, 0x02, 0x08, 0x01, 0x00, 0x49, 
            0x02, 0x02, 0x00, 0xCC, 0x00, 0x00, 0x00, 0x51, 0x00, 0xFA, 0xFF, 0x0A, 0x02, 0x00, 0x00, 0x9C, 
            0x02, 0x00, 0x00, 0x9D, 0x02, 0x00, 0x00, 0xE3, 0x00, 0x00, 0x00, 0xCB, 0x00, 0x00, 0x00, 0x00, 
            0x00, 
    } ;

    // send svWOW_INITIAL_SPELLS
    wowPacket       spells;
    spells.PutHeader(svWOW_INITIAL_SPELLS);
    spells.PutData(rawData_initialspells,113);
    spells.Finalize();
    mSocket->Write(spells.GetData(),spells.GetSize());

    // send svWOW_ACTION_BUTTONS
    wowPacket       buttons;
    buttons.PutHeader(svWOW_ACTION_BUTTONS);
    buttons.PutData(mCharacter->mActionButtons,sizeof(wxUint32)*cNumActionButtons);
    buttons.Finalize();
    mSocket->Write(buttons.GetData(),buttons.GetSize());    

    // send svWOW_INITIALIZE_FACTIONS
    wowPacket       factions;
    factions.PutHeader(svWOW_INITIALIZE_FACTIONS);
    factions.Putu32(0x00000040);
    factions.Putu8(2); factions.Putu32(0);
    factions.Putu8(0); factions.Putu32(0);
    factions.Putu8(2); factions.Putu32(0);
    factions.Putu8(2); factions.Putu32(0);
    factions.PutData(voiddata,300);
    factions.Finalize();
    mSocket->Write(factions.GetData(),factions.GetSize());
    
    // send svWOW_NEW_TIME_SPEED
    wowPacket       timespeed;
    timespeed.PutHeader(svWOW_NEW_TIME_SPEED);
    timespeed.Putu32(0x04010d35);
    timespeed.Putu32(0x3c888889);
    timespeed.Finalize();
    mSocket->Write(timespeed.GetData(),timespeed.GetSize());


    wowPacket       obj;
    obj.PutHeader(svWOW_OBJECTUPDATE);
    obj.Putu32(1);      // numobjects
    mCharacter->BuildObjectUpdate(obj,1);
    obj.Finalize();
    mSocket->Write(obj.GetData(),obj.GetSize());
}*/

#endif
