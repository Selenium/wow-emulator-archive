namespace WorldServer
{
    using System;

    internal class ObjectBase
    {
        public ulong guid;
        public UpdateMask mask = new UpdateMask();
        private UpdateMask Mask = new UpdateMask();
        public float o;
        public TYPE ObjectType;
        public TYPEID ObjectTypeID;
        public float x;
        public float y;
        public float z;

        public void Create(Item i)
        {
            this.ObjectType = TYPE.ITEM;
            this.ObjectTypeID = TYPEID.ITEM;
            this.guid = i.guid;
            this.mask.Length = 2;
            this.mask.SetBit(UpdateFields.OBJECT_FIELD_GUID, i.guid);
            this.mask.SetBit(UpdateFields.OBJECT_FIELD_TYPE, (uint) this.ObjectType);
            this.mask.SetBit(UpdateFields.OBJECT_FIELD_SCALE_X, (float) 1f);
            this.mask.SetBit(UpdateFields.OBJECT_FIELD_ENTRY, i.entry);
            this.mask.SetBit(UpdateFields.OBJECT_END, (ulong) 6);
            this.mask.SetBit(UpdateFields.ITEM_FIELD_CONTAINED, (ulong) 6);
            this.mask.SetBit(UpdateFields.ITEM_FIELD_STACK_COUNT, (uint) 2);
            this.mask.SetBit(UpdateFields.ITEM_FIELD_DURABILITY, (uint) 90);
            this.mask.SetBit(UpdateFields.ITEM_FIELD_MAXDURABILITY, (uint) 100);
        }

        public void Create(CharacterBase c, ClientConnection Client)
        {
            uint num;
            this.ObjectType = TYPE.PLAYER;
            this.ObjectTypeID = TYPEID.PLAYER;
            this.x = c.x;
            this.y = c.y;
            this.z = c.z;
            this.o = c.o;
            this.guid = c.guid;
            switch (c.PowerType)
            {
                case Powers.MANA:
                    num = 0xee00;
                    break;

                case Powers.RAGE:
                    num = 0x1100ee00;
                    break;

                case Powers.ENERGY:
                    num = 0;
                    break;

                default:
                    num = 0;
                    Console.WriteLine("Unknown PowerType");
                    break;
            }
            this.mask.SetBit(UpdateFields.OBJECT_FIELD_GUID, c.guid);
            if (c.race == Races.TAUREN)
            {
                this.mask.SetBit(UpdateFields.OBJECT_FIELD_SCALE_X, (float) 1.35f);
            }
            else
            {
                this.mask.SetBit(UpdateFields.OBJECT_FIELD_SCALE_X, (float) 1f);
            }
            this.mask.SetBit(UpdateFields.UNIT_FIELD_BOUNDINGRADIUS, (float) 0.389f);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_COMBATREACH, (float) 1.5f);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_DISPLAYID, c.displayid);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_NATIVEDISPLAYID, c.displayid);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_BYTES_0, new byte[] { (byte) c.race, (byte) c.class_, (byte) c.gender, (byte) c.PowerType });
            this.mask.SetBit(UpdateFields.UNIT_FIELD_BYTES_1, num);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_BYTES_2, (uint) 0xeeeeee00);
            this.mask.SetBit(UpdateFields.PLAYER_BYTES, new byte[] { c.skin, c.face, c.hairstyle, c.haircolor });
            byte[] buffer = new byte[4];
            buffer[0] = c.facialhair;
            buffer[1] = 0xee;
            buffer[3] = 2;
            this.mask.SetBit(UpdateFields.PLAYER_BYTES_2, buffer);
            this.mask.SetBit(UpdateFields.PLAYER_BYTES_3, (uint) c.gender);
            this.mask.SetBit(UpdateFields.PLAYER_FIELD_BYTES, (uint) 0xeee00000);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_LEVEL, (uint) c.level);
            this.mask.SetBit(UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, c.GetFactionTemplate());
            this.mask.SetBit(UpdateFields.UNIT_FIELD_MAXHEALTH, (uint) 0x3e8);
            this.mask.SetBit(UpdateFields.ITEM_FIELD_ENCHANTMENT, (uint) 0x3e8);
            if (Client.User.GMLevel > 0)
            {
                this.mask.SetBit(UpdateFields.PLAYER_FLAGS, (uint) 8);
            }
        }
    }
}

