// Copyright (C) 2004 Team Python
//  
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software 
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "GameObject.h"

#include "UpdateMask.h"

GameObject::GameObject() : Object()
{
    m_objectType |= TYPE_GAMEOBJECT;
    m_objectTypeId = 5;
}

void GameObject::Create( uint32 guidlow, uint32 display_id, uint8 state, float scale, uint16 type, uint16 faction,  float x, float y, float z, float ang ) {
    setUpdateValue( GAMEOBJECT_DISPLAYID, display_id );
    setUpdateFloatValue( GAMEOBJECT_POS_X, 100 ); // This shouldnt work...
    setUpdateFloatValue( GAMEOBJECT_POS_Y, 100 ); // This shouldnt work...
    setUpdateFloatValue( GAMEOBJECT_POS_Z, 100 ); // This shouldnt work...
    setUpdateFloatValue( GAMEOBJECT_FACING, 1 ); // This shouldnt work...
    setUpdateValue( GAMEOBJECT_STATE, 1  );
    setUpdateValue( OBJECT_FIELD_TYPE, 0x21000000 );
    setUpdateFloatValue( OBJECT_FIELD_SCALE_X, 0x0000803f );
    setUpdateValue( OBJECT_FIELD_PADDING, 0xeeeeeeee );
    setUpdateValue( OBJECT_FIELD_ENTRY, 0x00000787 );
    setUpdateValue( OBJECT_FIELD_GUID+1, 0xf0001000 );
    Object::Create(guidlow, x,y,z,ang);
}
