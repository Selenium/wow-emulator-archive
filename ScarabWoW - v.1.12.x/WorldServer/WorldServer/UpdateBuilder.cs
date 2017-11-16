namespace WorldServer
{
    using System;
    using System.Collections;

    internal class UpdateBuilder
    {
        private ArrayList Objects = new ArrayList();
        public ByteArrayBuilderV2 update = new ByteArrayBuilderV2();

        public void AddObject(ObjectBase o)
        {
            this.Objects.Add(o);
        }

        private void BuildMovementUpdate(ObjectBase o, byte flags, uint flags2, ByteArrayBuilderV2 update)
        {
            update.Add(flags);
            if (o.ObjectTypeID == TYPEID.PLAYER)
            {
                update.Add(flags2);
                update.Add((uint) 0xb74d85d1);
                update.Add(o.x);
                update.Add(o.y);
                update.Add(o.z);
                update.Add(o.o);
                update.Add((float) 0f);
                if (flags2 == 0x2000)
                {
                    update.Add((float) 0f);
                    update.Add((float) 1f);
                    update.Add((float) 0f);
                    update.Add((float) 0f);
                }
                update.Add(Speeds.walkspeed);
                update.Add(Speeds.runspeed);
                update.Add(Speeds.backwardspeed);
                update.Add(Speeds.sweemspeed);
                update.Add(Speeds.sweembackspeed);
                update.Add(Speeds.turn);
                update.Add((uint) 1);
            }
            else
            {
                update.Add((uint) 1);
            }
        }

        public void Clear()
        {
            this.Objects.Clear();
        }

        public void CreateUpdate(ulong guid)
        {
            this.update.Clear();
            this.update.Add((uint) this.Objects.Count);
            this.update.Add((byte) 0);
            foreach (ObjectBase base2 in this.Objects)
            {
                switch (base2.ObjectTypeID)
                {
                    case TYPEID.ITEM:
                    case TYPEID.CONTAINER:
                        this.update.Add((byte) 2);
                        this.update.Add((byte) 0xff);
                        this.update.Add(base2.guid);
                        this.update.Add((byte) base2.ObjectTypeID);
                        this.BuildMovementUpdate(base2, 0x10, 0, this.update);
                        base2.mask.BuildUpdate(this.update);
                        goto Label_01C4;

                    case TYPEID.PLAYER:
                        if (base2.guid != guid)
                        {
                            break;
                        }
                        this.update.Add((byte) 3);
                        this.update.Add((byte) 0xff);
                        this.update.Add(base2.guid);
                        this.update.Add((byte) base2.ObjectTypeID);
                        this.BuildMovementUpdate(base2, 0x71, 0x2000, this.update);
                        base2.mask.BuildUpdate(this.update);
                        goto Label_01C4;

                    default:
                        goto Label_01C4;
                }
                this.update.Add((byte) 2);
                this.update.Add((byte) 0xff);
                this.update.Add(base2.guid);
                this.update.Add((byte) base2.ObjectTypeID);
                this.BuildMovementUpdate(base2, 0x70, 0, this.update);
                base2.mask.BuildUpdate(this.update);
            Label_01C4:;
            }
        }

        public ByteArrayBuilderV2 GetUpdate()
        {
            return this.update;
        }
    }
}

