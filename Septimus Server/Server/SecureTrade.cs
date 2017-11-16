namespace Server
{
    using Server.Items;
    using Server.Network;
    using System;
    using System.Collections;

    public class SecureTrade
    {
        // Methods
        public SecureTrade(Mobile from, Mobile to)
        {
            this.m_Valid = true;
            this.m_From = new SecureTradeInfo(this, from, new SecureTradeContainer(this));
            this.m_To = new SecureTradeInfo(this, to, new SecureTradeContainer(this));
            from.Send(new MobileStatus(from, to));
            from.Send(new UpdateSecureTrade(this.m_From.Container, false, false));
            from.Send(new SecureTradeEquip(this.m_To.Container, to));
            from.Send(new UpdateSecureTrade(this.m_From.Container, false, false));
            from.Send(new SecureTradeEquip(this.m_From.Container, from));
            from.Send(new DisplaySecureTrade(to, this.m_From.Container, this.m_To.Container, to.Name));
            from.Send(new UpdateSecureTrade(this.m_From.Container, false, false));
            to.Send(new MobileStatus(to, from));
            to.Send(new UpdateSecureTrade(this.m_To.Container, false, false));
            to.Send(new SecureTradeEquip(this.m_From.Container, from));
            to.Send(new UpdateSecureTrade(this.m_To.Container, false, false));
            to.Send(new SecureTradeEquip(this.m_To.Container, to));
            to.Send(new DisplaySecureTrade(from, this.m_To.Container, this.m_From.Container, from.Name));
            to.Send(new UpdateSecureTrade(this.m_To.Container, false, false));
        }

        public void Cancel()
        {
            int num1;
            Item item1;
            int num2;
            Item item2;
            if (!this.m_Valid)
            {
                return;
            }
            ArrayList list1 = this.m_From.Container.Items;
            for (num1 = (list1.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < list1.Count)
                {
                    item1 = ((Item) list1[num1]);
                    item1.OnSecureTrade(this.m_From.Mobile, this.m_To.Mobile, this.m_From.Mobile, false);
                    if (!item1.Deleted)
                    {
                        this.m_From.Mobile.AddToBackpack(item1);
                    }
                }
            }
            list1 = this.m_To.Container.Items;
            for (num2 = (list1.Count - 1); (num2 >= 0); --num2)
            {
                if (num2 < list1.Count)
                {
                    item2 = ((Item) list1[num2]);
                    item2.OnSecureTrade(this.m_To.Mobile, this.m_From.Mobile, this.m_To.Mobile, false);
                    if (!item2.Deleted)
                    {
                        this.m_To.Mobile.AddToBackpack(item2);
                    }
                }
            }
            this.Close();
        }

        public void Close()
        {
            if (!this.m_Valid)
            {
                return;
            }
            this.m_From.Mobile.Send(new CloseSecureTrade(this.m_From.Container));
            this.m_To.Mobile.Send(new CloseSecureTrade(this.m_To.Container));
            this.m_Valid = false;
            NetState state1 = this.m_From.Mobile.NetState;
            if (state1 != null)
            {
                state1.RemoveTrade(this);
            }
            state1 = this.m_To.Mobile.NetState;
            if (state1 != null)
            {
                state1.RemoveTrade(this);
            }
            this.m_From.Container.Delete();
            this.m_To.Container.Delete();
        }

        public void Update()
        {
            ArrayList list1;
            bool flag1;
            int num1;
            Item item1;
            int num2;
            Item item2;
            int num3;
            Item item3;
            int num4;
            Item item4;
            if (!this.m_Valid)
            {
                return;
            }
            if (this.m_From.Accepted && this.m_To.Accepted)
            {
                list1 = this.m_From.Container.Items;
                flag1 = true;
                for (num1 = (list1.Count - 1); (flag1 && (num1 >= 0)); --num1)
                {
                    if (num1 < list1.Count)
                    {
                        item1 = ((Item) list1[num1]);
                        if (!item1.AllowSecureTrade(this.m_From.Mobile, this.m_To.Mobile, this.m_To.Mobile, true))
                        {
                            flag1 = false;
                        }
                    }
                }
                list1 = this.m_To.Container.Items;
                for (num2 = (list1.Count - 1); (flag1 && (num2 >= 0)); --num2)
                {
                    if (num2 < list1.Count)
                    {
                        item2 = ((Item) list1[num2]);
                        if (!item2.AllowSecureTrade(this.m_To.Mobile, this.m_From.Mobile, this.m_From.Mobile, true))
                        {
                            flag1 = false;
                        }
                    }
                }
                if (!flag1)
                {
                    this.m_From.Accepted = false;
                    this.m_To.Accepted = false;
                    this.m_From.Mobile.Send(new UpdateSecureTrade(this.m_From.Container, this.m_From.Accepted, this.m_To.Accepted));
                    this.m_To.Mobile.Send(new UpdateSecureTrade(this.m_To.Container, this.m_To.Accepted, this.m_From.Accepted));
                    return;
                }
                list1 = this.m_From.Container.Items;
                for (num3 = (list1.Count - 1); (num3 >= 0); --num3)
                {
                    if (num3 < list1.Count)
                    {
                        item3 = ((Item) list1[num3]);
                        item3.OnSecureTrade(this.m_From.Mobile, this.m_To.Mobile, this.m_To.Mobile, true);
                        if (!item3.Deleted)
                        {
                            this.m_To.Mobile.AddToBackpack(item3);
                        }
                    }
                }
                list1 = this.m_To.Container.Items;
                for (num4 = (list1.Count - 1); (num4 >= 0); --num4)
                {
                    if (num4 < list1.Count)
                    {
                        item4 = ((Item) list1[num4]);
                        item4.OnSecureTrade(this.m_To.Mobile, this.m_From.Mobile, this.m_From.Mobile, true);
                        if (!item4.Deleted)
                        {
                            this.m_From.Mobile.AddToBackpack(item4);
                        }
                    }
                }
                this.Close();
                return;
            }
            this.m_From.Mobile.Send(new UpdateSecureTrade(this.m_From.Container, this.m_From.Accepted, this.m_To.Accepted));
            this.m_To.Mobile.Send(new UpdateSecureTrade(this.m_To.Container, this.m_To.Accepted, this.m_From.Accepted));
        }


        // Properties
        public SecureTradeInfo From
        {
            get
            {
                return this.m_From;
            }
        }

        public SecureTradeInfo To
        {
            get
            {
                return this.m_To;
            }
        }

        public bool Valid
        {
            get
            {
                return this.m_Valid;
            }
        }


        // Fields
        private SecureTradeInfo m_From;
        private SecureTradeInfo m_To;
        private bool m_Valid;
    }
}

