namespace Server
{
    using Server.Network;
    using System;
    using System.Collections;

    public class Sector
    {
        // Methods
        static Sector()
        {
            Sector.m_DefaultList = new ArrayList();
        }

        public Sector(int x, int y, Map owner)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Owner = owner;
            this.m_Active = false;
        }

        public void Activate()
        {
            int num1;
            int num2;
            Mobile mobile1;
            if (this.Active || (this.m_Owner == Map.Internal))
            {
                return;
            }
            for (num1 = 0; ((this.m_Items != null) && (num1 < this.m_Items.Count)); ++num1)
            {
                ((Item) this.m_Items[num1]).OnSectorActivate();
            }
            for (num2 = 0; ((this.m_Mobiles != null) && (num2 < this.m_Mobiles.Count)); ++num2)
            {
                mobile1 = ((Mobile) this.m_Mobiles[num2]);
                if (!mobile1.Player)
                {
                    mobile1.OnSectorActivate();
                }
            }
            this.m_Active = true;
        }

        public void Deactivate()
        {
            int num1;
            int num2;
            if (!this.Active || ((this.m_Players != null) && (this.m_Players.Count != 0)))
            {
                return;
            }
            for (num1 = 0; ((this.m_Items != null) && (num1 < this.m_Items.Count)); ++num1)
            {
                ((Item) this.m_Items[num1]).OnSectorDeactivate();
            }
            for (num2 = 0; ((this.m_Mobiles != null) && (num2 < this.m_Mobiles.Count)); ++num2)
            {
                ((Mobile) this.m_Mobiles[num2]).OnSectorDeactivate();
            }
            this.m_Active = false;
        }

        public void OnClientChange(NetState oldState, NetState newState)
        {
            if (this.m_Clients != null)
            {
                this.m_Clients.Remove(oldState);
            }
            if (newState == null)
            {
                return;
            }
            if (this.m_Clients == null)
            {
                this.m_Clients = new ArrayList(4);
            }
            this.m_Clients.Add(newState);
        }

        public void OnEnter(Item item)
        {
            if (this.m_Items == null)
            {
                this.m_Items = new ArrayList();
            }
            this.m_Items.Add(item);
        }

        public void OnEnter(Mobile m)
        {
            if (this.m_Mobiles == null)
            {
                this.m_Mobiles = new ArrayList(4);
            }
            this.m_Mobiles.Add(m);
            if (m.NetState != null)
            {
                if (this.m_Clients == null)
                {
                    this.m_Clients = new ArrayList(4);
                }
                this.m_Clients.Add(m.NetState);
            }
            if (!m.Player)
            {
                return;
            }
            if (this.m_Players == null)
            {
                this.m_Players = new ArrayList(4);
            }
            this.m_Players.Add(m);
            if (this.m_Players.Count == 1)
            {
                this.Owner.ActivateSectors(this.m_X, this.m_Y);
            }
        }

        public void OnEnter(Region r)
        {
            int num1;
            if ((this.m_Regions != null) && this.m_Regions.Contains(r))
            {
                return;
            }
            if (this.m_Regions == null)
            {
                this.m_Regions = new ArrayList();
            }
            this.m_Regions.Add(r);
            this.m_Regions.Sort();
            if ((this.m_Mobiles == null) || (this.m_Mobiles.Count <= 0))
            {
                return;
            }
            ArrayList list1 = new ArrayList(this.m_Mobiles);
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                ((Mobile) list1[num1]).ForceRegionReEnter(true);
            }
        }

        public void OnLeave(Item item)
        {
            if (this.m_Items != null)
            {
                this.m_Items.Remove(item);
            }
        }

        public void OnLeave(Mobile m)
        {
            if (this.m_Mobiles != null)
            {
                this.m_Mobiles.Remove(m);
            }
            if ((this.m_Clients != null) && (m.NetState != null))
            {
                this.m_Clients.Remove(m.NetState);
            }
            if (!m.Player)
            {
                return;
            }
            if (this.m_Players != null)
            {
                this.m_Players.Remove(m);
            }
            if ((this.m_Players == null) || (this.m_Players.Count == 0))
            {
                this.Owner.DeactivateSectors(this.m_X, this.m_Y);
            }
        }

        public void OnLeave(Region r)
        {
            if (this.m_Regions != null)
            {
                this.m_Regions.Remove(r);
            }
        }

        public void OnMultiEnter(Item item)
        {
            if (this.m_Multis == null)
            {
                this.m_Multis = new ArrayList(4);
            }
            this.m_Multis.Add(item);
        }

        public void OnMultiLeave(Item item)
        {
            if (this.m_Multis != null)
            {
                this.m_Multis.Remove(item);
            }
        }


        // Properties
        public bool Active
        {
            get
            {
                if (this.m_Active)
                {
                    return (this.m_Owner != Map.Internal);
                }
                return false;
            }
        }

        public ArrayList Clients
        {
            get
            {
                if (this.m_Clients == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Clients;
            }
        }

        public static ArrayList EmptyList
        {
            get
            {
                return Sector.m_DefaultList;
            }
        }

        public ArrayList Items
        {
            get
            {
                if (this.m_Items == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Items;
            }
        }

        public ArrayList Mobiles
        {
            get
            {
                if (this.m_Mobiles == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Mobiles;
            }
        }

        public ArrayList Multis
        {
            get
            {
                if (this.m_Multis == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Multis;
            }
        }

        public Map Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        public ArrayList Players
        {
            get
            {
                if (this.m_Players == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Players;
            }
        }

        public ArrayList Regions
        {
            get
            {
                if (this.m_Regions == null)
                {
                    return Sector.m_DefaultList;
                }
                return this.m_Regions;
            }
        }

        public int X
        {
            get
            {
                return this.m_X;
            }
        }

        public int Y
        {
            get
            {
                return this.m_Y;
            }
        }


        // Fields
        private bool m_Active;
        private ArrayList m_Clients;
        private static ArrayList m_DefaultList;
        private ArrayList m_Items;
        private ArrayList m_Mobiles;
        private ArrayList m_Multis;
        private Map m_Owner;
        private ArrayList m_Players;
        private ArrayList m_Regions;
        private int m_X;
        private int m_Y;
    }
}

