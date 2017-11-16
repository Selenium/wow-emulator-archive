namespace WorldServer
{
    using System;

    internal enum UnitState
    {
        UNIT_STAT_ALL_STATE = 0xffff,
        UNIT_STAT_ATTACK_BY = 4,
        UNIT_STAT_ATTACKING = 2,
        UNIT_STAT_CHASE = 0x20,
        UNIT_STAT_CONFUSED = 0x800,
        UNIT_STAT_DIED = 1,
        UNIT_STAT_FLEEING = 0x80,
        UNIT_STAT_FOLLOW = 0x200,
        UNIT_STAT_IN_COMBAT = 6,
        UNIT_STAT_IN_FLIGHT = 0x100,
        UNIT_STAT_MOVING = 240,
        UNIT_STAT_ROAMING = 0x10,
        UNIT_STAT_ROOT = 0x400,
        UNIT_STAT_SEARCHING = 0x40,
        UNIT_STAT_STOPPED = 0,
        UNIT_STAT_STUNDED = 8
    }
}

