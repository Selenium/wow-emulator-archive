// Copyright (C) 2004 WoWD Team

#ifndef __UNIT_H
#define __UNIT_H

#include "Object.h"

#define UF_TARGET_DIED  1
#define UF_ATTACKING    2 // this unit is attacking it's selection

class Affect;
class Modifier;
class Spell;

enum DeathState
{
    ALIVE = 0,  // Unit is alive and well
    JUST_DIED,  // Unit has JUST died
    CORPSE,     // Unit has died but remains in the world as a corpse
    DEAD        // Unit is dead and his corpse is gone from the world
};

//====================================================================
//  Unit
//  Base object for Players and Creatures
//====================================================================
class Unit : public Object
{
public:
    typedef std::set<Unit*> AttackerSet;

    virtual ~Unit ( );

    virtual void Update( uint32 time );

    void setAttackTimer();
    bool isAttackReady() const { return m_attackTimer == 0; }
    bool canReachWithAttack(Unit *pVictim) const;

    inline void removeAttacker(Unit *pAttacker)
    {
        AttackerSet::iterator itr = m_attackers.find(pAttacker);
        if(itr != m_attackers.end())
            m_attackers.erase(itr);
    }

    /// State flags are server-only flags to help me know when to do stuff, like die, or attack
    inline void addStateFlag(uint32 f) { m_state |= f; };
    inline void clearStateFlag(uint32 f) { m_state &= ~f; };

    /// Stats
    inline uint8 getLevel() { return (uint8)m_uint32Values[ UNIT_FIELD_LEVEL ]; };
    inline uint8 getRace() { return (uint8)m_uint32Values[ UNIT_FIELD_BYTES_0 ] & 0xFF; };
    inline uint8 getClass() { return (uint8)(m_uint32Values[ UNIT_FIELD_BYTES_0 ] >> 8) & 0xFF; };
    inline uint8 getGender() { return (uint8)(m_uint32Values[ UNIT_FIELD_BYTES_0 ] >> 16) & 0xFF; };

    //// Combat
    void DealDamage(Unit *pVictim, uint32 damage);
    void AttackerStateUpdate(Unit *pVictim, uint32 damage,bool DoT);
    void PeriodicAuraLog(Unit *pVictim, uint32 spellID, uint32 damage, uint32 damageType);
    void SpellNonMeleeDamageLog(Unit *pVictim, uint32 spellID, uint32 damage);

    void smsg_AttackStart(Unit* pVictim);
    void smsg_AttackStop(uint64 victimGuid);

    virtual void RemoveInRangeObject(Object* pObj)
    {
        if(pObj->GetTypeId() == TYPEID_PLAYER || pObj->GetTypeId() == TYPEID_UNIT)
        {
            AttackerSet::iterator i = m_attackers.find((Unit*)pObj);
            if(i != m_attackers.end())
                m_attackers.erase(i);
        }
        Object::RemoveInRangeObject(pObj);
    }

    /// Combat / Death Status
    bool isAlive() { return m_deathState == ALIVE; };
    bool isDead() { return ( m_deathState == DEAD || m_deathState == CORPSE ); };
    virtual void setDeathState(DeathState s) {
        m_deathState = s;
    };
    DeathState getDeathState() { return m_deathState; }

    //! Add affect to unit
    bool AddAffect(Affect *aff, bool uniq = false);
    //! Remove affect from unit
    void RemoveAffect(Affect *aff);
    //! Remove all affects with specified type
    bool RemoveAffect(uint32 type);
    void RemoveAffectById(uint32 spellId);
    //! Remove all affects
    void RemoveAllAffects();
    void SetAura(Affect* aff){ m_aura = aff; }
    bool SetAffDuration(uint32 spellId,Unit* caster,uint32 duration);
    Affect* tmpAffect;

    //! Player should override it to use POS/NEG fields
    virtual void ApplyModifier(const Modifier *mod, bool apply, Affect* parent);

    void castSpell(Spell * pSpell);
    void InterruptSpell();
    bool m_meleeSpell;
    uint32 m_addDmgOnce;
    uint64 m_TotemSlot1;
    uint64 m_TotemSlot2;
    uint64 m_TotemSlot3;
    uint64 m_TotemSlot4;
    uint32 m_triggerSpell;
    uint32 m_triggerDamage;

    // Use it to Check if a Unit is in front of another one
    bool isInFront(Unit* target,float distance);

    // Spell Effect Variables
    bool m_silenced;

protected:
    Unit ( );

    //! Temporary remove all affects
    void _RemoveAllAffectMods();
    //! Place all mods back
    void _ApplyAllAffectMods();

    void _AddAura(Affect *aff);
    void _RemoveAura(Affect *aff);
    Affect* FindAff(uint32 spellId);

    void _UpdateSpells(uint32 time);
    void _UpdateAura();

    Affect* m_aura;
    uint32 m_auraCheck;

    // FIXME: implement it
    bool _IsAffectPositive(Affect *aff) { return true; }

    uint32 m_state;         // flags for keeping track of some states
    uint32 m_attackTimer;   // timer for attack

    /// Combat
    AttackerSet m_attackers;
    DeathState m_deathState;

    typedef std::list<Affect*> AffectList;
    AffectList m_affects;

    // Spell currently casting
    Spell * m_currentSpell;

    // Some Functions for isInFront Calculation ( thanks to emperor and undefined for the formula )
    bool inarc( float radius,  float xM, float yM, float offnung, float orientation, float xP, float yP );  // Main Function called by isInFront();
    float geteasyangle( float angle );// converts to 360 > x > 0
    float getangle( float xe, float ye, float xz, float yz );
    float getdistance( float xe, float ye, float xz, float yz );
};

#endif
