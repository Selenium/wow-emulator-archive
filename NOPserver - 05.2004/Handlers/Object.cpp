#include "Object.h"

/* We NEED to send these when we send an Object Update 
   w/ type create about anyone (Object) */
const wxUint8 CreateReqSize_Object = 6;
const wxUint32 CreateReqItems_Object[CreateReqSize_Object] = { 
        OBJECT_OBJECTID, OBJECT_OBJECTID+1,
        OBJECT_TYPE, OBJECT_ENTRYNUM,
        OBJECT_SCALE, OBJECT_PADDING
};

/* We NEED to send these when we send an Object Update
   w/ type update about anyone (Object) */
const wxUint8 UpdateReqSize_Object = 3;
const wxUint32 UpdateReqItems_Object[UpdateReqSize_Object] = { 
        OBJECT_OBJECTID, OBJECT_OBJECTID+1,
        OBJECT_TYPE
};

/* Last GUID (Lower 32 bits) (increments) */
wxUint32 Object::LastLow;


Object::Object (wxLongLong id) { ObjConstructor(id); }

Object::Object (wxUint8 type = TYPE_OBJ, wxString name = "") {
    wxLongLong id = CreateID(type, ++Object::LastLow);
    if (type == TYPE_CHAR) {
        LOG(_T("[Object] Adding to reverse db (%s -> %.4X %.4X)"), name.c_str(), id.GetLo(), id.GetHi());
        WorldThread::GetThread()->GetObjectManager()->ReverseObj[name] = id;
    }
    ObjConstructor(id);
}

Object::~Object() {
    WorldThread::GetThread()->GetObjectManager()->Objects.erase(GetGUID());
    free(PropertyMap); free(UpdateMasks);
}

void Object::ObjConstructor(wxLongLong id)  {
    Type = id.GetHi() & 0x3F;
    switch (Type) {
        case TYPE_OBJ:
            NumProperties = OBJECT_START+OBJECT_SIZE;
            NumMasks = (NumProperties + (sizeof(UpdateData) * 8) - 1)/32;
            break;
        case TYPE_UNIT:
            NumProperties = UNIT_START+UNIT_SIZE;
            NumMasks = (NumProperties + (sizeof(UpdateData) * 8) - 1)/32;
            break;
        case TYPE_CHAR:
            NumProperties = CHAR_START+CHAR_SIZE;
            NumMasks = (NumProperties + (sizeof(UpdateData) * 8) - 1)/32;
            break;
    }

    /* Allocate and NULL the Property-map and the Updatemasks */
    PropertyMap = (UpdateData *)malloc(NumProperties * sizeof(UpdateData));
    memset(PropertyMap, 0, NumProperties * sizeof(UpdateData));
    UpdateMasks = (wxUint32 *)malloc(NumMasks * sizeof(wxUint32));
    memset(UpdateMasks, 0, NumMasks * sizeof(wxUint32));

    SetGUID(id); SetScale(1.0f); 
    SetValue(OBJECT_ENTRYNUM, 0x00002790); SetValue(OBJECT_PADDING, 0);
    WorldThread::GetThread()->GetObjectManager()->Objects[id] = (Object *)this;
    SetType(GetType() + BMASK_OBJ);
    unk5 = unk6 = unk7 = 0;
    unk8 = wxLongLong(0, 0);
}

void Object::GetObjectUpdate (wowPacket *packet, wxUint32 UpdateType, wxUint32 Self) {
    if (UpdateType == OBJUPD_CREATE) {
        packet->Putu8(OBJUPD_CREATE);
        packet->Putu32(GetGUID().GetLo());
        packet->Putu32(GetGUID().GetHi());
        packet->Putu8(Type);
        Position.ObjPositionUpdate(packet, UpdateType, Self);
        packet->Putu32(Self); /* 'self' / isClientObject ? */
        packet->Putu32(unk6);
        packet->Putu32(unk7);
        packet->Putu32(unk8.GetLo());
        packet->Putu32(unk8.GetHi());
        if (Self & 0x2)
            packet->Putu32(0); /* Unknown */

        // Should be removed when the if (self)-thing in Unit/Char works ;)
        ClearUpdateMasks();

        for (wxUint8 x = 0; x < CreateReqSize_Object; x++) {
            if (!(ISSET(UpdateMasks, CreateReqItems_Object[x])))
                SETMASK(UpdateMasks, CreateReqItems_Object[x]);
        }
    } else if (UpdateType == OBJUPD_UPDATE) {
        packet->Putu8(OBJUPD_UPDATE);
        packet->Putu32(GetGUID().GetLo());
        packet->Putu32(GetGUID().GetHi());

        for (wxUint8 x = 0; x < UpdateReqSize_Object; x++) {
            if (!(ISSET(UpdateMasks, UpdateReqItems_Object[x]))) {
                LOG(_T("[Object] Required UPDATE field %d was unset; setting."), UpdateReqItems_Object[x]);
                SETMASK(UpdateMasks, UpdateReqItems_Object[x]);
            }
        }
    } else
        LOG(_T("[Object] Got unsupported type %d in GetObjectUpdate."), UpdateType);
}

void Object::ClearUpdateMasks (void) { 
    memset(UpdateMasks, 0, NumMasks * sizeof(wxUint32));
    LOG(_T("[Object] Cleared UpdateMasks (%d) - %d bytes replaced with null"), sizeof(UpdateMasks), NumMasks * sizeof(wxUint32));
}

void Object::GetObjectProps (wowPacket *packet) {
    wxUint32 y = 0;
    for (wxUint32 x = OBJECT_START; x <= OBJECT_END; x++)
        if (ISSET(UpdateMasks, x))
            packet->Putu32(PropertyMap[x].uint32); 
}

void Object::SetValueInt64 (wxUint32 Property, wxLongLong Value) {
    if ((Type == TYPE_OBJ     && Property+1 > OBJECT_END)
        || (Type == TYPE_UNIT && Property+1 > UNIT_END)
        || (Type == TYPE_CHAR && Property+1 > CHAR_END)) {
        LOG(_T("[Object] SetValueInt64 property-field out-of-bounds (%d & %d) for type %d"), Property, Property + 1, Type);
        return;
    }

    PropertyMap[Property].uint32 = Value.GetLo();
    SETMASK(UpdateMasks, Property);
    PropertyMap[Property + 1].uint32 = Value.GetHi();
    SETMASK(UpdateMasks, Property + 1);
}

void Object::SetValue (wxUint32 Property, wxUint32 Value) {
    if((Type == TYPE_OBJ      && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValue property-field out-of-bounds (%d) for type %d"), Property, Type);
        return;
    }

    PropertyMap[Property].uint32 = Value;
    SETMASK(UpdateMasks, Property);
}

void Object::SetValueFloat (wxUint32 Property, wxFloat32 Value) {
    if((Type == TYPE_OBJ      && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValue(Float) property-field out-of-bounds (%d) for type %d"), Property, Type);
        return;
    }

    PropertyMap[Property].fpoint = Value;
    SETMASK(UpdateMasks, Property);
}

void Object::SetValueShort (wxUint32 Property, wxUint8 ShortIndex, wxUint16 Value) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValueShort property-field out-of-bounds (%d) for type %d"), Property, Type);
        return;
    }
    if (ShortIndex > SHORT_TWO) {
        LOG(_T("[Object] SetValueShort short-index out-of-bounds (%d)."), ShortIndex);
        return;
    }

    PropertyMap[Property].uint16[ShortIndex] = Value;
    SETMASK(UpdateMasks, Property); 
}

void Object::SetValueByte (wxUint32 Property, wxUint8 ByteIndex, wxUint8 Value) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValueByte property-field out-of-bounds (%d) for type %d"), Property, Type);
        return;
    }

    if (ByteIndex > BYTE_FOUR) {
        LOG(_T("[Object] SetValueByte byte-index out-of-bounds (%d)."), ByteIndex);
        return;
    }

    PropertyMap[Property].uint8[ByteIndex] = Value;
    SETMASK(UpdateMasks, Property); 
}

wxLongLong Object::GetValueInt64 (wxUint32 Property) {
    if ((Type == TYPE_OBJ     && Property+1 > OBJECT_END)
        || (Type == TYPE_UNIT && Property+1 > UNIT_END)
        || (Type == TYPE_CHAR && Property+1 > CHAR_END)) {
        LOG(_T("[Object] GetValueInt64 property-field out-of-bounds (%d & %d) for type %d"), Property, Property + 1, Type);
        return wxLongLong(0, 0);
    }

    return wxLongLong(PropertyMap[Property + 1].uint32, PropertyMap[Property].uint32);
}

wxUint32 Object::GetValue (wxUint32 Property) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValue property-field out-of-bounds (%d) for type %d"), Property, Type);
        return 0;
    }

    return PropertyMap[Property].uint32;
}

wxFloat32 Object::GetValueFloat (wxUint32 Property) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] GetValueFloat property-field out-of-bounds (%d) for type %d"), Property, Type);
        return 0.0f;
    }

    return PropertyMap[Property].fpoint;
}

wxUint16 Object::GetValueShort (wxUint32 Property, wxUint8 ShortIndex) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValueShort property-field out-of-bounds (%d) for type %d"), Property, Type);
        return 0;
    }
    if (ShortIndex > SHORT_TWO) {
        LOG(_T("[Object] SetValueShort byte-index out-of-bounds (%d)."), ShortIndex);
        return 0;
    }
    return PropertyMap[Property].uint16[ShortIndex];
}

wxUint8 Object::GetValueByte (wxUint32 Property, wxUint8 ByteIndex) {
    if ((Type == TYPE_OBJ     && Property > OBJECT_END)
        || (Type == TYPE_UNIT && Property > UNIT_END)
        || (Type == TYPE_CHAR && Property > CHAR_END)) {
        LOG(_T("[Object] SetValueByte property-field out-of-bounds (%d) for type %d"), Property, Type);
        return 0;
    }
    if (ByteIndex > BYTE_FOUR) {
        LOG(_T("[Object] SetValueByte byte-index out-of-bounds (%d)."), ByteIndex);
        return 0;
    }
    return PropertyMap[Property].uint8[ByteIndex];
}

/**************************************/
/* Here we set values in UpdateObject */
/**************************************/

void Object::SetName (wxString in)  { LOG(_T("[Object] Tried to SetName(%s)"), in.c_str()); }
void Object::SetScale(wxFloat32 in) { SetValueFloat(OBJECT_SCALE, in); }
void Object::SetType (wxUint32 in)  { SetValue(OBJECT_TYPE, in); }
void Object::SetGUID (wxLongLong in){ SetValueInt64(OBJECT_OBJECTID, in); }
void Object::SetPosition (wxFloat32 x, wxFloat32 y, wxFloat32 z) {
    Position.PosX = x;
    Position.PosY = y;
    Position.PosZ = z;
}

/****************************************/
/* Here we get values from UpdateObject */
/****************************************/

const wxChar   *Object::GetName (void)  { return _T("<Nameless BaseObject>"); }
wxLongLong      Object::GetGUID (void)  { return GetValueInt64(OBJECT_OBJECTID); }
wxUint32        Object::GetType (void)  { return GetValue(OBJECT_TYPE); }
wxFloat32       Object::GetScale(void)  { return GetValueFloat(OBJECT_SCALE); }
