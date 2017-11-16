namespace Server.Items
{
    using Server;
    using Server.Network;
    using System;

    public class BankBox : Container
    {
        // Methods
        public BankBox(Mobile owner) : base(3649)
        {
            this.Layer = Layer.Bank;
            base.Movable = false;
            this.m_Owner = owner;
        }

        public BankBox(Serial serial) : base(serial)
        {
        }

        public void Close()
        {
            this.m_Open = false;
            if ((this.m_Owner != null) && BankBox.m_SendRemovePacket)
            {
                this.m_Owner.Send(base.RemovePacket);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int num2 = reader.ReadInt();
            if (num2 != 0)
            {
                return;
            }
            this.m_Owner = reader.ReadMobile();
            this.m_Open = reader.ReadBool();
            if (this.m_Owner == null)
            {
                this.Delete();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if ((from != this.m_Owner) || !this.m_Open)
            {
                return false;
            }
            return base.OnDragDrop(from, dropped);
        }

        public override DeathMoveResult OnParentDeath(Mobile parent)
        {
            return DeathMoveResult.RemainEquiped;
        }

        public override void OnSingleClick(Mobile from)
        {
        }

        public void Open()
        {
            this.m_Open = true;
            if (this.m_Owner != null)
            {
                this.m_Owner.PrivateOverheadMessage(MessageType.Regular, 946, true, string.Format("Bank container has {0} items, {1} stones", base.TotalItems, base.TotalWeight), this.m_Owner.NetState);
                this.m_Owner.Send(new EquipUpdate(this));
                this.DisplayTo(this.m_Owner);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
            writer.Write(this.m_Owner);
            writer.Write(this.m_Open);
        }


        // Properties
        public override Rectangle2D Bounds
        {
            get
            {
                return new Rectangle2D(18, 105, 144, 73);
            }
        }

        public override int DefaultDropSound
        {
            get
            {
                return 66;
            }
        }

        public override int DefaultGumpID
        {
            get
            {
                return 74;
            }
        }

        public override int MaxWeight
        {
            get
            {
                return 0;
            }
        }

        public bool Opened
        {
            get
            {
                return this.m_Open;
            }
        }

        public Mobile Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        public static bool SendDeleteOnClose
        {
            get
            {
                return BankBox.m_SendRemovePacket;
            }
            set
            {
                BankBox.m_SendRemovePacket = value;
            }
        }


        // Fields
        private bool m_Open;
        private Mobile m_Owner;
        private static bool m_SendRemovePacket;
    }
}

