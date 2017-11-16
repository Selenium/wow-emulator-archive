namespace Server.Items
{
    using Server;
    using System;

    public class SecureTradeContainer : Container
    {
        // Methods
        public SecureTradeContainer(SecureTrade trade) : base(7774)
        {
            this.m_Trade = trade;
            base.Movable = false;
        }

        public SecureTradeContainer(Serial serial) : base(serial)
        {
        }

        public override bool CheckLift(Mobile from, Item item)
        {
            return false;
        }

        public void ClearChecks()
        {
            if (this.m_Trade != null)
            {
                this.m_Trade.From.Accepted = false;
                this.m_Trade.To.Accepted = false;
                this.m_Trade.Update();
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }

        public override bool IsAccessibleTo(Mobile check)
        {
            if (!base.IsChildOf(check))
            {
                return false;
            }
            return base.IsAccessibleTo(check);
        }

        public override void OnItemAdded(Item item)
        {
            this.ClearChecks();
        }

        public override void OnItemRemoved(Item item)
        {
            this.ClearChecks();
        }

        public override void OnSubItemAdded(Item item)
        {
            this.ClearChecks();
        }

        public override void OnSubItemRemoved(Item item)
        {
            this.ClearChecks();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }


        // Properties
        public override Rectangle2D Bounds
        {
            get
            {
                return new Rectangle2D(0, 0, 110, 62);
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
                return 82;
            }
        }

        public SecureTrade Trade
        {
            get
            {
                return this.m_Trade;
            }
        }


        // Fields
        private SecureTrade m_Trade;
    }
}

