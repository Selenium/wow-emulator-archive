namespace Server.Items
{
    using Server;
    using System;

    public class BaseMulti : Item
    {
        // Methods
        public BaseMulti(Serial serial) : base(serial)
        {
        }

        [Constructable]
        public BaseMulti(int itemID) : base(itemID)
        {
            base.Movable = false;
        }

        public virtual bool Contains(IPoint3D p)
        {
            return this.Contains(p.X, p.Y);
        }

        public bool Contains(Item item)
        {
            if (item.Map == base.Map)
            {
                return this.Contains(item.X, item.Y);
            }
            return false;
        }

        public bool Contains(Mobile m)
        {
            if (m.Map == base.Map)
            {
                return this.Contains(m.X, m.Y);
            }
            return false;
        }

        public virtual bool Contains(Point2D p)
        {
            return this.Contains(p.m_X, p.m_Y);
        }

        public virtual bool Contains(Point3D p)
        {
            return this.Contains(p.m_X, p.m_Y);
        }

        public virtual bool Contains(int x, int y)
        {
            MultiComponentList list1 = this.Components;
            Point2D pointd1 = list1.Min;
            x -= (this.X + pointd1.m_X);
            pointd1 = list1.Min;
            y -= (this.Y + pointd1.m_Y);
            if (((x >= 0) && (x < list1.Width)) && ((y >= 0) && (y < list1.Height)))
            {
                return (list1.Tiles[x][y].Length > 0);
            }
            return false;
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }

        public override int GetMaxUpdateRange()
        {
            return 22;
        }

        public override int GetUpdateRange(Mobile m)
        {
            return 22;
        }

        public virtual void RefreshComponents()
        {
            if (this.Parent != null)
            {
                return;
            }
            Map map1 = base.Map;
            if (map1 != null)
            {
                map1.OnLeave(this);
                map1.OnEnter(this);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }


        // Properties
        public virtual MultiComponentList Components
        {
            get
            {
                return MultiData.GetComponents(this.ItemID);
            }
        }

        public override int LabelNumber
        {
            get
            {
                MultiComponentList list1 = this.Components;
                if (list1.List.Length > 0)
                {
                    return (1020000 + (list1.List[0].m_ItemID & 16383));
                }
                return base.LabelNumber;
            }
        }

    }
}

