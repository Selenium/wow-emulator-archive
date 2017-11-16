namespace WorldServer
{
    using System;

    internal enum UnitFlags
    {
        UNIT_FLAG_DISABLE_MOVE = 4,
        UNIT_FLAG_DISABLE_ROTATE = 0x40000,
        UNIT_FLAG_IN_COMBAT = 0x80000,
        UNIT_FLAG_MOUNT = 0x2000,
        UNIT_FLAG_NONE = 0,
        UNIT_FLAG_PVP = 0x1000,
        UNIT_FLAG_RENAME = 0x10,
        UNIT_FLAG_RESTING = 0x20,
        UNIT_FLAG_SHEATHE = 0x40000000,
        UNIT_FLAG_SKINNABLE = 0x4000000,
        UNIT_FLAG_UNKNOWN1 = 8
    }
}

