#pragma once

class WorldPacket;
class Item;
class Unit;

void Make_INVENTORY_CHANGE_FAILURE (WorldPacket *pkt, uint8 errcode, Item * item1=0, Item * item2=0);
void Make_SMSG_SPELL_GO (WorldPacket *pkt, uint32 spellId, Unit *caster, Unit *target);
void Make_CHAR_CREATION_ERROR_CODE (WorldPacket *pkt, uint8 errcode);

//--- END ---