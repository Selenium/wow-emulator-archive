#include "Unit.h"


/* We NEED to send these when we send an Object Update 
   w/ type create about anyone (Unit) */
const wxUint8 CreateReqSize_Unit = 7;
const wxUint32 CreateReqItems_Unit[CreateReqSize_Unit] = {
        UNIT_FACTION_TEMPLATE, UNIT_BASE_ATTACKTIME,
        UNIT_BASE_ATTACKTIME+1, UNIT_BOUNDING_RADIUS,
        UNIT_COMBAT_REACH, UNIT_DAMAGE,
        UNIT_DISPLAYID
};

/* We need to send these when we send an Object Update 
   w/ type create about ourselves (Unit) */
const wxUint8 CreateReqSize_UnitSelf = 21;
const wxUint32 CreateReqItems_UnitSelf[CreateReqSize_UnitSelf] = { 
        UNIT_HEALTH, UNIT_MANA,
        UNIT_MAX_HEALTH, UNIT_MAX_MANA,
        UNIT_LEVEL, UNIT_FACTION_TEMPLATE,
        UNIT_CLASSINFO, UNIT_STRENGTH,
        UNIT_AGILITY, UNIT_STAMINA,
        UNIT_INTELLECT, UNIT_SPIRIT,
        UNIT_BASE_STRENGTH, UNIT_BASE_AGILITY,
        UNIT_BASE_STAMINA, UNIT_BASE_INTELLECT,
        UNIT_BASE_SPIRIT, UNIT_BASE_ATTACKTIME,
        UNIT_BOUNDING_RADIUS, UNIT_COMBAT_REACH,
        UNIT_DAMAGE
};

Unit::Unit(wxLongLong id) : Object(id) {
    SetType(GetType() + BMASK_UNIT);
    unk5 = unk6 = 1;
}
Unit::Unit(wxUint8 type = TYPE_UNIT, wxString name = "") : Object(type, name) {
    SetType(GetType() + BMASK_UNIT);
    unk5 = unk6 = 1;
}
Unit::~Unit (void) { }

void Unit::GetUnitUpdate (wowPacket *packet, wxUint32 UpdateType, wxUint32 Self) {
    GetObjectUpdate(packet, UpdateType, Self);
    if (UpdateType == OBJUPD_CREATE) {
        for (wxUint8 x = 0; x < CreateReqSize_Unit; x++) {
            if (!(ISSET(UpdateMasks, CreateReqItems_Unit[x])))
                SETMASK(UpdateMasks, CreateReqItems_Unit[x]);
        }
            
        // This needs to be fixed. We need to figure out WHAT we need to
        // send on Object Create about people who ARNT *you*
        // Obviously we shouldnt send UNIT_HP etc. :P 
        //if (self) {
            for (wxUint8 x = 0; x < CreateReqSize_UnitSelf; x++) {
                if (!(ISSET(UpdateMasks, CreateReqItems_UnitSelf[x])))
                    SETMASK(UpdateMasks, CreateReqItems_UnitSelf[x]);
            }
        //}
    } else if (UpdateType == OBJUPD_UPDATE) {
    } else 
        LOG(_T("[Unit] Got unsupported type %d in GetUnitUpdate."), UpdateType);
}

void Unit::GetUnitProps (wowPacket *packet) {
    GetObjectProps(packet);
    for (wxUint32 x = UNIT_START; x <= UNIT_END; x++)
        if (ISSET(UpdateMasks, x))
            packet->Putu32(PropertyMap[x].uint32);
}

/**************************************/
/* Here we set values in UpdateObject */
/**************************************/

void    Unit::SetName           (wxString in)   { Name = in; }
void    Unit::SetRace           (wxUint8 in)    { SetValueByte(UNIT_CLASSINFO, BYTE_ONE, in); }
void    Unit::SetClass          (wxUint8 in)    { SetValueByte(UNIT_CLASSINFO, BYTE_TWO, in); }
void    Unit::SetSex            (wxUint8 in)    { SetValueByte(UNIT_CLASSINFO, BYTE_THREE, in); }

void    Unit::SetStrength       (wxUint32 in)   { SetValue(UNIT_STRENGTH, in); }
void    Unit::SetAgility        (wxUint32 in)   { SetValue(UNIT_AGILITY, in); }
void    Unit::SetStamina        (wxUint32 in)   { SetValue(UNIT_STAMINA, in); }
void    Unit::SetIntellect      (wxUint32 in)   { SetValue(UNIT_INTELLECT, in); }
void    Unit::SetSpirit         (wxUint32 in)   { SetValue(UNIT_SPIRIT, in); }

void    Unit::SetBaseStrength   (wxUint32 in)   { SetValue(UNIT_BASE_STRENGTH, in); }
void    Unit::SetBaseAgility    (wxUint32 in)   { SetValue(UNIT_BASE_AGILITY, in); }
void    Unit::SetBaseStamina    (wxUint32 in)   { SetValue(UNIT_BASE_STAMINA, in); }
void    Unit::SetBaseIntellect  (wxUint32 in)   { SetValue(UNIT_BASE_INTELLECT, in); }
void    Unit::SetBaseSpirit     (wxUint32 in)   { SetValue(UNIT_BASE_SPIRIT, in); }

void    Unit::SetLevel          (wxUint32 in)   { SetValue(UNIT_LEVEL, in); }

void    Unit::SetMaxHealth      (wxUint32 in)   { SetValue(UNIT_MAX_HEALTH, in); }
void    Unit::SetHealth         (wxUint32 in)   { SetValue(UNIT_HEALTH, in); }
void    Unit::SetMaxMana        (wxUint32 in)   { SetValue(UNIT_MAX_MANA, in); }
void    Unit::SetMana           (wxUint32 in)   { SetValue(UNIT_MANA, in); }

void    Unit::SetTarget         (wxLongLong in) { SetValueInt64(UNIT_TARGET, in); }

void    Unit::SetLoDmg          (wxUint16 in)   { SetValueShort(UNIT_DAMAGE, SHORT_ONE, in); }
void    Unit::SetHiDmg          (wxUint16 in)   { SetValueShort(UNIT_DAMAGE, SHORT_TWO, in); }

void    Unit::SetCoinage        (wxUint32 in)   { SetValue(UNIT_COINAGE, in); }

void    Unit::SetDisplayID      (wxUint32 in)   { SetValue(UNIT_DISPLAYID, in); }
void    Unit::SetMount          (wxUint32 in)   { SetValue(UNIT_MOUNTDISPLAYID, in); }
        
void    Unit::SetAnimState      (wxUint32 in)   { SetValue(UNIT_ANIMSTATE, in); }
void    Unit::SetEmote          (wxUint32 in)   { SetValue(UNIT_EMOTESTATE, in); }

/* Uh? */
void    Unit::SetFactionTemp    (wxUint32 in)   { SetValue(UNIT_FACTION_TEMPLATE, in); }

/* CHANGE TO GET FROM CURRENT WEAPONS */
void    Unit::SetAttackTimeL    (wxUint32 in)   { SetValue(UNIT_BASE_ATTACKTIME, in); }
void    Unit::SetAttackTimeR    (wxUint32 in)   { SetValue(UNIT_BASE_ATTACKTIME+1, in); }
void    Unit::SetWeaponReach    (wxFloat32 in)  { SetValueFloat(UNIT_COMBAT_REACH, in); }

/* FIGURE OUT WTF IT IS */
void    Unit::SetBoundingRadi   (wxFloat32 in)  { SetValueFloat(UNIT_BOUNDING_RADIUS, in); }

/****************************************/
/* Here we get values from UpdateObject */
/****************************************/

const wxChar *Unit::GetName         (void)  { return Name.c_str(); }
wxUint8		Unit::GetRace           (void)  { return GetValueByte(UNIT_CLASSINFO, BYTE_ONE); }
wxUint8		Unit::GetClass          (void)  { return GetValueByte(UNIT_CLASSINFO, BYTE_TWO); }
wxUint8		Unit::GetSex            (void)  { return GetValueByte(UNIT_CLASSINFO, BYTE_THREE); }

wxUint32	Unit::GetStrength       (void)  { return GetValue(UNIT_STRENGTH); }
wxUint32	Unit::GetAgility        (void)  { return GetValue(UNIT_AGILITY); }
wxUint32	Unit::GetStamina        (void)  { return GetValue(UNIT_STAMINA); }
wxUint32	Unit::GetIntellect      (void)  { return GetValue(UNIT_INTELLECT); }
wxUint32	Unit::GetSpirit         (void)  { return GetValue(UNIT_SPIRIT); }

wxUint32	Unit::GetBaseStrength   (void)  { return GetValue(UNIT_BASE_STRENGTH); }
wxUint32	Unit::GetBaseAgility    (void)  { return GetValue(UNIT_BASE_AGILITY); }
wxUint32	Unit::GetBaseStamina    (void)  { return GetValue(UNIT_BASE_STAMINA); }
wxUint32	Unit::GetBaseIntellect  (void)  { return GetValue(UNIT_BASE_INTELLECT); }
wxUint32	Unit::GetBaseSpirit     (void)  { return GetValue(UNIT_BASE_SPIRIT); }

wxUint32	Unit::GetLevel          (void)  { return GetValue(UNIT_LEVEL); }

wxUint32	Unit::GetMaxHealth      (void)  { return GetValue(UNIT_MAX_HEALTH); }
wxUint32	Unit::GetHealth         (void)  { return GetValue(UNIT_HEALTH); }
wxUint32	Unit::GetMaxMana        (void)  { return GetValue(UNIT_MAX_MANA); }
wxUint32	Unit::GetMana           (void)  { return GetValue(UNIT_MANA); }
        
wxLongLong  Unit::GetTarget         (void)  { return GetValueInt64(UNIT_TARGET); }

wxUint16    Unit::GetLoDmg          (void)  { return GetValueShort(UNIT_DAMAGE, SHORT_ONE); }
wxUint16    Unit::GetHiDmg          (void)  { return GetValueShort(UNIT_DAMAGE, SHORT_TWO); }

wxUint32    Unit::GetCoinage        (void)  { return GetValue(UNIT_COINAGE); }

wxUint32    Unit::GetDisplayID      (void)  { return GetValue(UNIT_DISPLAYID); }
wxUint32    Unit::GetMount          (void)  { return GetValue(UNIT_MOUNTDISPLAYID); }
        
wxUint32    Unit::GetAnimState      (void)  { return GetValue(UNIT_ANIMSTATE); }
wxUint32    Unit::GetEmote          (void)  { return GetValue(UNIT_EMOTESTATE); }
