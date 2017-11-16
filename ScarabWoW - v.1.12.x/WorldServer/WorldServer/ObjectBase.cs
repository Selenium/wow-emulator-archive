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
            byte[] bytes = BitConverter.GetBytes(i.guid);
            this.mask.SetBit(0, BitConverter.ToUInt32(bytes, 0));
            this.mask.SetBit(1, BitConverter.ToUInt32(bytes, 4));
            this.mask.SetBit(2, (uint) this.ObjectTypeID);
            this.mask.SetBit(4, (float) 1f);
            this.mask.SetBit(3, (uint) 120);
            this.mask.SetBit(14, (uint) 1);
            this.mask.SetBit(0x15, (uint) 0);
            this.mask.SetBit(0x2e, (uint) 90);
            this.mask.SetBit(0x2f, (uint) 100);
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
            byte[] bytes = BitConverter.GetBytes(c.guid);
            this.mask.SetBit(0, BitConverter.ToUInt32(bytes, 0));
            this.mask.SetBit(1, BitConverter.ToUInt32(bytes, 4));
            if (c.race == Races.TAUREN)
            {
                this.mask.SetBit(4, (float) 1.35f);
            }
            else
            {
                this.mask.SetBit(4, (float) 1f);
            }
            this.mask.SetBit(0x81, (float) 0.389f);
            this.mask.SetBit(130, (float) 1.5f);
            this.mask.SetBit(0x83, c.displayid);
            this.mask.SetBit(0x84, c.displayid);
            this.mask.SetBit(0x24, new byte[] { (byte) c.race, (byte) c.class_, (byte) c.gender, (byte) c.PowerType });
            this.mask.SetBit(0x8a, num);
            this.mask.SetBit(0xa4, (uint) 0xeeeeee00);
            this.mask.SetBit(0x2e, (uint) 0);
            this.mask.SetBit(0x8f, (uint) 0x10);
            this.mask.SetBit(0xc1, new byte[] { c.skin, c.face, c.hairstyle, c.haircolor });
            byte[] buffer3 = new byte[4];
            buffer3[0] = c.facialhair;
            buffer3[1] = 0xee;
            buffer3[3] = 2;
            this.mask.SetBit(0xc2, buffer3);
            this.mask.SetBit(0xc3, (uint) c.gender);
            this.mask.SetBit(0x4c6, (uint) 0xeee00000);
            this.mask.SetBit(0x22, (uint) c.level);
            this.mask.SetBit(0x23, c.GetFactionTemplate());
            this.mask.SetBit(0x1c, (uint) 0x3e8);
            this.mask.SetBit(0x16, (uint) 200);
            if (Client.User.GMLevel > 0)
            {
                this.mask.SetBit(190, (uint) 8);
            }
            byte[] buffer2 = BitConverter.GetBytes((ulong) 100);
        }
    }
}

