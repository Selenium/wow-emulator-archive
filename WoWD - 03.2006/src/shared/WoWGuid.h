// Copyright (C) 2004 WoWD Team

#ifndef _WOWGUID_H
#define _WOWGUID_H

#include "Common.h"

#define BitCount1(x) ((x) & 1)
#define BitCount2(x) ( BitCount1(x) + BitCount1((x)>>1) )
#define BitCount4(x) ( BitCount2(x) + BitCount2((x)>>2) )
#define BitCount8(x) ( BitCount4(x) + BitCount4((x)>>4) )

class WoWGuid {
public:
    
    WoWGuid() 
    {
        Clear();
    }

    WoWGuid(uint64 guid) 
    {
        Clear();
        Init((uint64)guid);
    }

   WoWGuid(uint8 mask) 
    {
        Clear();
        Init((uint8)mask);
    }

    WoWGuid(uint8 mask, uint8 *fields) 
    {
        Clear();
        Init(mask, fields);
    }

    ~WoWGuid() 
    {
        Free();
    }

    void Free()
    {
        if (BitCount8(guidmask))
            delete [] guidfields;

        Clear();
    }

    void Clear()
    {
        oldguid = 0;
        guidmask = 0;
        guidfields = NULL;
        compiled = false;
        fieldcount = 0;
    }

    void Init(uint64 guid)
    {
        Free();

        oldguid = guid;

        _CompileByOld();
    }

    void Init(uint8 mask)
    {
        Free();

        guidmask = mask;

        if (!guidmask)
            _CompileByNew();
        else
            _AllocateFields();
    }

    void Init(uint8 mask, uint8 *fields)
    {
        Free();

        guidmask = mask;

        if (!BitCount8(guidmask))
            return;

        _AllocateFields();
        
        for(int i = 0; i < BitCount8(guidmask); i++)     
            guidfields[i] = fields[i];
        
        fieldcount = BitCount8(guidmask);

        _CompileByNew();
    }

    const uint64 GetOldGuid() const { return oldguid; }
    const uint8* GetNewGuid() const { return guidfields; }
    const uint8 GetNewGuidLen() const { return BitCount8(guidmask); }
    const uint8 GetNewGuidMask() const { return guidmask; }

    void AppendField(uint8 field)
    {
        ASSERT(!compiled);
        ASSERT(fieldcount < BitCount8(guidmask));

        guidfields[fieldcount] = field;
        fieldcount++;

        if (fieldcount == BitCount8(guidmask))
            _CompileByNew();
    }

private:

    uint64 oldguid;
    uint8 guidmask;
    uint8 *guidfields;
    uint8 fieldcount;
    bool compiled;

    void _AllocateFields()
    {
        guidfields = new uint8[BitCount8(guidmask)];
    }

    void _CompileByOld()
    {
        ASSERT(!compiled);

        for(int i = 0; i < 8; i++)
        {
            if ((char)(oldguid >> (56 - i*8)) != 0)
            {
                guidmask |= 1 << (7 - i);
            }
        }
        
        if (!BitCount8(guidmask))
            return;

        guidfields = new uint8[BitCount8(guidmask)];

        int j = 0;
        for(int i = 0; i < 8; i++)
        {
            if ((char)(oldguid >> (i*8)) != 0)
            {
                guidfields[j] = uint8( (char)(oldguid >> (i*8)) );
                j++;
            }
        }

        compiled = true;
        fieldcount = BitCount8(guidmask);
    }

    void _CompileByNew()
    {
        ASSERT(!compiled);
        ASSERT(fieldcount == BitCount8(guidmask));

        int j = 0;
        for(int i = 0; i < 8; i++)
        {
            if (guidmask & (1 << i))
            {
                uint64 gfield = guidfields[j];
                oldguid |= (gfield << (8*i));
                j++;
            }
        }
        compiled = true;
    }
};


#endif