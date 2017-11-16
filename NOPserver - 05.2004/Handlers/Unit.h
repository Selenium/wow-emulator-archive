#ifndef _UNIT_H_
#define _UNIT_H_

#include "../Common.h"
#include "../IDList.h"
#include "../NetCode/Packet.h"
#include "Object.h"

class Unit : public Object {
    wxString            Name;
    public:

                        Unit            (wxLongLong);
                        Unit            (wxUint8, wxString name);
virtual                ~Unit            (void);

        void            GetUnitUpdate   (wowPacket *, wxUint32, wxUint32);
        void            GetUnitProps    (wowPacket *);


        /* Below are UpdateObject setters/getters */

virtual void            SetName         (wxString);
        void            SetRace         (wxUint8);
        void            SetClass        (wxUint8);
        void            SetSex          (wxUint8);

        void            SetStrength     (wxUint32);
        void            SetAgility      (wxUint32);
        void            SetStamina      (wxUint32);
        void            SetIntellect    (wxUint32);
        void            SetSpirit       (wxUint32);

        void            SetBaseStrength (wxUint32);
        void            SetBaseAgility  (wxUint32);
        void            SetBaseStamina  (wxUint32);
        void            SetBaseIntellect(wxUint32);
        void            SetBaseSpirit   (wxUint32);

        void            SetLevel        (wxUint32);

        void            SetMaxHealth    (wxUint32);
        void            SetHealth       (wxUint32);
        void            SetMaxMana      (wxUint32);
        void            SetMana         (wxUint32);
        
        void            SetTarget       (wxLongLong);

        void            SetLoDmg        (wxUint16);
        void            SetHiDmg        (wxUint16);

        void            SetCoinage      (wxUint32);

        void            SetDisplayID    (wxUint32);
        void            SetMount        (wxUint32);
        
        void            SetAnimState    (wxUint32);
        void            SetEmote        (wxUint32);

        void            SetFactionTemp  (wxUint32);

        void            SetAttackTimeL  (wxUint32);
        void            SetAttackTimeR  (wxUint32);
        
        void            SetWeaponReach  (wxFloat32);
        void            SetBoundingRadi (wxFloat32);

virtual const wxChar   *GetName         (void);
        wxUint8         GetRace         (void);
        wxUint8         GetClass        (void);
        wxUint8         GetSex          (void);

        wxUint32        GetStrength     (void);
        wxUint32        GetAgility      (void);
        wxUint32        GetStamina      (void);
        wxUint32        GetIntellect    (void);
        wxUint32        GetSpirit       (void);

        wxUint32        GetBaseStrength (void);
        wxUint32        GetBaseAgility  (void);
        wxUint32        GetBaseStamina  (void);
        wxUint32        GetBaseIntellect(void);
        wxUint32        GetBaseSpirit   (void);

        wxUint32        GetLevel        (void);

        wxUint32        GetMaxHealth    (void);
        wxUint32        GetHealth       (void);
        wxUint32        GetMaxMana      (void);
        wxUint32        GetMana         (void);
        
        wxLongLong      GetTarget       (void);

        wxUint16        GetLoDmg        (void);
        wxUint16        GetHiDmg        (void);

        wxUint32        GetCoinage      (void);

        wxUint32        GetDisplayID    (void);
        wxUint32        GetMount        (void);
        
        wxUint32        GetAnimState    (void);
        wxUint32        GetEmote        (void);

};

#endif
