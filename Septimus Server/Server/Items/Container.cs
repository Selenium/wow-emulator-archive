namespace Server.Items
{
    using Server;
    using Server.Network;
    using System;
    using System.Collections;

    public class Container : Item
    {
        // Methods
        static Container()
        {
            Container.m_FindItemsList = new ArrayList();
            Container.m_GlobalMaxItems = 125;
            Container.m_GlobalMaxWeight = 400;
        }

        public Container(Serial serial) : base(serial)
        {
        }

        public Container(int itemID) : base(itemID)
        {
            this.m_GumpID = -1;
            this.m_DropSound = -1;
            this.m_MaxItems = -1;
        }

        public virtual bool CheckContentDisplay(Mobile from)
        {
            if (!this.DisplaysContent)
            {
                return false;
            }
            object obj1 = base.RootParent;
            if (((obj1 == null) || (obj1 is Item)) || ((obj1 == from) || (from.AccessLevel > AccessLevel.Player)))
            {
                return true;
            }
            return false;
        }

        public virtual bool CheckHold(Mobile m, Item item, bool message)
        {
            return this.CheckHold(m, item, message, true);
        }

        public virtual bool CheckHold(Mobile m, Item item, bool message, bool checkItems)
        {
            object obj1;
            Container container1;
            int num1;
            int num2;
            if (m.AccessLevel >= AccessLevel.GameMaster)
            {
                return true;
            }
            for (obj1 = this; (obj1 != null); obj1 = ((Item) obj1).Parent)
            {
                if ((obj1 is Container))
                {
                    container1 = (obj1 as Container);
                    num1 = container1.MaxItems;
                    if ((checkItems && (num1 != 0)) && (((container1.TotalItems + item.TotalItems) + (item.IsVirtualItem ? 0 : 1)) > num1))
                    {
                        if (message)
                        {
                            this.SendFullItemsMessage(m, item);
                        }
                        return false;
                    }
                    num2 = container1.MaxWeight;
                    if ((num2 != 0) && (((container1.TotalWeight + item.TotalWeight) + item.PileWeight) > num2))
                    {
                        if (message)
                        {
                            this.SendFullWeightMessage(m, item);
                        }
                        return false;
                    }
                    obj1 = container1.Parent;
                    continue;
                }
                if (!(obj1 is Item))
                {
                    break;
                }
            }
            return true;
        }

        public int ConsumeTotal(Type[] types, int[] amounts)
        {
            return this.ConsumeTotal(types, amounts, true, null);
        }

        public int ConsumeTotal(Type[][] types, int[] amounts)
        {
            return this.ConsumeTotal(types, amounts, true, null);
        }

        public bool ConsumeTotal(Type type, int amount)
        {
            return this.ConsumeTotal(type, amount, true, null);
        }

        public int ConsumeTotal(Type[][] types, int[] amounts, bool recurse)
        {
            return this.ConsumeTotal(types, amounts, recurse, null);
        }

        public bool ConsumeTotal(Type type, int amount, bool recurse)
        {
            return this.ConsumeTotal(type, amount, recurse, null);
        }

        public int ConsumeTotal(Type[] types, int[] amounts, bool recurse)
        {
            return this.ConsumeTotal(types, amounts, recurse, null);
        }

        public int ConsumeTotal(Type[] types, int[] amounts, bool recurse, OnItemConsumed callback)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            Item item1;
            int num6;
            int[] numArray2;
            IntPtr ptr1;
            if (types.Length != amounts.Length)
            {
                throw new ArgumentException();
            }
            Item[][] itemArrayArray1 = new Item[types.Length][];
            int[] numArray1 = new int[types.Length];
            for (num1 = 0; (num1 < types.Length); ++num1)
            {
                itemArrayArray1[num1] = this.FindItemsByType(types[num1], recurse);
                for (num2 = 0; (num2 < itemArrayArray1[num1].Length); ++num2)
                {
                    numArray2 = numArray1;
                    ptr1 = ((IntPtr) num1);
                    numArray1[num1] = (numArray2[ptr1] + itemArrayArray1[num1][num2].Amount);
                }
                if (numArray1[num1] < amounts[num1])
                {
                    return num1;
                }
            }
            for (num3 = 0; (num3 < types.Length); ++num3)
            {
                num4 = amounts[num3];
                for (num5 = 0; (num5 < itemArrayArray1[num3].Length); ++num5)
                {
                    item1 = itemArrayArray1[num3][num5];
                    num6 = item1.Amount;
                    if (num6 < num4)
                    {
                        if (callback != null)
                        {
                            callback(item1, num6);
                        }
                        item1.Delete();
                        num4 -= num6;
                    }
                    else
                    {
                        if (callback != null)
                        {
                            callback(item1, num4);
                        }
                        item1.Consume(num4);
                        break;
                    }
                }
            }
            return -1;
        }

        public int ConsumeTotal(Type[][] types, int[] amounts, bool recurse, OnItemConsumed callback)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            Item item1;
            int num6;
            int[] numArray2;
            IntPtr ptr1;
            if (types.Length != amounts.Length)
            {
                throw new ArgumentException();
            }
            Item[][] itemArrayArray1 = new Item[types.Length][];
            int[] numArray1 = new int[types.Length];
            for (num1 = 0; (num1 < types.Length); ++num1)
            {
                itemArrayArray1[num1] = this.FindItemsByType(types[num1], recurse);
                for (num2 = 0; (num2 < itemArrayArray1[num1].Length); ++num2)
                {
                    numArray2 = numArray1;
                    ptr1 = ((IntPtr) num1);
                    numArray1[num1] = (numArray2[ptr1] + itemArrayArray1[num1][num2].Amount);
                }
                if (numArray1[num1] < amounts[num1])
                {
                    return num1;
                }
            }
            for (num3 = 0; (num3 < types.Length); ++num3)
            {
                num4 = amounts[num3];
                for (num5 = 0; (num5 < itemArrayArray1[num3].Length); ++num5)
                {
                    item1 = itemArrayArray1[num3][num5];
                    num6 = item1.Amount;
                    if (num6 < num4)
                    {
                        if (callback != null)
                        {
                            callback(item1, num6);
                        }
                        item1.Delete();
                        num4 -= num6;
                    }
                    else
                    {
                        if (callback != null)
                        {
                            callback(item1, num4);
                        }
                        item1.Consume(num4);
                        break;
                    }
                }
            }
            return -1;
        }

        public bool ConsumeTotal(Type type, int amount, bool recurse, OnItemConsumed callback)
        {
            int num2;
            int num3;
            int num4;
            Item item1;
            int num5;
            Item[] itemArray1 = this.FindItemsByType(type, recurse);
            int num1 = 0;
            for (num2 = 0; (num2 < itemArray1.Length); ++num2)
            {
                num1 += itemArray1[num2].Amount;
            }
            if (num1 >= amount)
            {
                num3 = amount;
                for (num4 = 0; (num4 < itemArray1.Length); ++num4)
                {
                    item1 = itemArray1[num4];
                    num5 = item1.Amount;
                    if (num5 < num3)
                    {
                        if (callback != null)
                        {
                            callback(item1, num5);
                        }
                        item1.Delete();
                        num3 -= num5;
                    }
                    else
                    {
                        if (callback != null)
                        {
                            callback(item1, num3);
                        }
                        item1.Consume(num3);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ConsumeTotalGrouped(Type type, int amount, bool recurse, OnItemConsumed callback, CheckItemGroup grouper)
        {
            Item item1;
            ArrayList list2;
            Item item2;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            Item item3;
            int num8;
            int[] numArray2;
            IntPtr ptr1;
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            Item[] itemArray1 = this.FindItemsByType(type, recurse);
            ArrayList list1 = new ArrayList();
            int num1 = 0;
            while ((num1 < itemArray1.Length))
            {
                item1 = itemArray1[num1++];
                list2 = new ArrayList();
                list2.Add(item1);
                while ((num1 < itemArray1.Length))
                {
                    item2 = itemArray1[num1];
                    num2 = grouper(item1, item2);
                    if (num2 != 0)
                    {
                        break;
                    }
                    list2.Add(item2);
                    ++num1;
                }
                list1.Add(list2);
            }
            Item[][] itemArrayArray1 = new Item[list1.Count][];
            int[] numArray1 = new int[list1.Count];
            bool flag1 = false;
            for (num3 = 0; (num3 < list1.Count); ++num3)
            {
                itemArrayArray1[num3] = ((Item[]) ((ArrayList) list1[num3]).ToArray(typeof(Item)));
                for (num4 = 0; (num4 < itemArrayArray1[num3].Length); ++num4)
                {
                    numArray2 = numArray1;
                    ptr1 = ((IntPtr) num3);
                    numArray1[num3] = (numArray2[ptr1] + itemArrayArray1[num3][num4].Amount);
                }
                if (numArray1[num3] >= amount)
                {
                    flag1 = true;
                }
            }
            if (!flag1)
            {
                return false;
            }
            for (num5 = 0; (num5 < itemArrayArray1.Length); ++num5)
            {
                if (numArray1[num5] >= amount)
                {
                    num6 = amount;
                    for (num7 = 0; (num7 < itemArrayArray1[num5].Length); ++num7)
                    {
                        item3 = itemArrayArray1[num5][num7];
                        num8 = item3.Amount;
                        if (num8 < num6)
                        {
                            if (callback != null)
                            {
                                callback(item3, num8);
                            }
                            item3.Delete();
                            num6 -= num8;
                        }
                        else
                        {
                            if (callback != null)
                            {
                                callback(item3, num6);
                            }
                            item3.Consume(num6);
                            break;
                        }
                    }
                    break;
                }
            }
            return true;
        }

        public int ConsumeTotalGrouped(Type[] types, int[] amounts, bool recurse, OnItemConsumed callback, CheckItemGroup grouper)
        {
            int num1;
            Item[] itemArray1;
            ArrayList list1;
            int num2;
            Item item1;
            ArrayList list2;
            Item item2;
            int num3;
            bool flag1;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            Item item3;
            int num10;
            int[] numArray1;
            IntPtr ptr1;
            if (types.Length != amounts.Length)
            {
                throw new ArgumentException();
            }
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            Item[][][] itemArrayArrayArray1 = new Item[types.Length][][];
            int[][] numArrayArray1 = new int[types.Length][];
            for (num1 = 0; (num1 < types.Length); ++num1)
            {
                itemArray1 = this.FindItemsByType(types[num1], recurse);
                list1 = new ArrayList();
                num2 = 0;
                while ((num2 < itemArray1.Length))
                {
                    item1 = itemArray1[num2++];
                    list2 = new ArrayList();
                    list2.Add(item1);
                    while ((num2 < itemArray1.Length))
                    {
                        item2 = itemArray1[num2];
                        num3 = grouper(item1, item2);
                        if (num3 != 0)
                        {
                            break;
                        }
                        list2.Add(item2);
                        ++num2;
                    }
                    list1.Add(list2);
                }
                itemArrayArrayArray1[num1] = new Item[list1.Count][];
                numArrayArray1[num1] = new int[list1.Count];
                flag1 = false;
                for (num4 = 0; (num4 < list1.Count); ++num4)
                {
                    itemArrayArrayArray1[num1][num4] = ((Item[]) ((ArrayList) list1[num4]).ToArray(typeof(Item)));
                    for (num5 = 0; (num5 < itemArrayArrayArray1[num1][num4].Length); ++num5)
                    {
                        ptr1 = ((IntPtr) num4);
                        (numArray1 = numArrayArray1[num1])[num4] = (numArray1[ptr1] + itemArrayArrayArray1[num1][num4][num5].Amount);
                    }
                    if (numArrayArray1[num1][num4] >= amounts[num1])
                    {
                        flag1 = true;
                    }
                }
                if (!flag1)
                {
                    return num1;
                }
            }
            for (num6 = 0; (num6 < itemArrayArrayArray1.Length); ++num6)
            {
                for (num7 = 0; (num7 < itemArrayArrayArray1[num6].Length); ++num7)
                {
                    if (numArrayArray1[num6][num7] >= amounts[num6])
                    {
                        num8 = amounts[num6];
                        for (num9 = 0; (num9 < itemArrayArrayArray1[num6][num7].Length); ++num9)
                        {
                            item3 = itemArrayArrayArray1[num6][num7][num9];
                            num10 = item3.Amount;
                            if (num10 < num8)
                            {
                                if (callback != null)
                                {
                                    callback(item3, num10);
                                }
                                item3.Delete();
                                num8 -= num10;
                            }
                            else
                            {
                                if (callback != null)
                                {
                                    callback(item3, num8);
                                }
                                item3.Consume(num8);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return -1;
        }

        public int ConsumeTotalGrouped(Type[][] types, int[] amounts, bool recurse, OnItemConsumed callback, CheckItemGroup grouper)
        {
            int num1;
            Item[] itemArray1;
            ArrayList list1;
            int num2;
            Item item1;
            ArrayList list2;
            Item item2;
            int num3;
            bool flag1;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            Item item3;
            int num10;
            int[] numArray1;
            IntPtr ptr1;
            if (types.Length != amounts.Length)
            {
                throw new ArgumentException();
            }
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            Item[][][] itemArrayArrayArray1 = new Item[types.Length][][];
            int[][] numArrayArray1 = new int[types.Length][];
            for (num1 = 0; (num1 < types.Length); ++num1)
            {
                itemArray1 = this.FindItemsByType(types[num1], recurse);
                list1 = new ArrayList();
                num2 = 0;
                while ((num2 < itemArray1.Length))
                {
                    item1 = itemArray1[num2++];
                    list2 = new ArrayList();
                    list2.Add(item1);
                    while ((num2 < itemArray1.Length))
                    {
                        item2 = itemArray1[num2];
                        num3 = grouper(item1, item2);
                        if (num3 != 0)
                        {
                            break;
                        }
                        list2.Add(item2);
                        ++num2;
                    }
                    list1.Add(list2);
                }
                itemArrayArrayArray1[num1] = new Item[list1.Count][];
                numArrayArray1[num1] = new int[list1.Count];
                flag1 = false;
                for (num4 = 0; (num4 < list1.Count); ++num4)
                {
                    itemArrayArrayArray1[num1][num4] = ((Item[]) ((ArrayList) list1[num4]).ToArray(typeof(Item)));
                    for (num5 = 0; (num5 < itemArrayArrayArray1[num1][num4].Length); ++num5)
                    {
                        ptr1 = ((IntPtr) num4);
                        (numArray1 = numArrayArray1[num1])[num4] = (numArray1[ptr1] + itemArrayArrayArray1[num1][num4][num5].Amount);
                    }
                    if (numArrayArray1[num1][num4] >= amounts[num1])
                    {
                        flag1 = true;
                    }
                }
                if (!flag1)
                {
                    return num1;
                }
            }
            for (num6 = 0; (num6 < itemArrayArrayArray1.Length); ++num6)
            {
                for (num7 = 0; (num7 < itemArrayArrayArray1[num6].Length); ++num7)
                {
                    if (numArrayArray1[num6][num7] >= amounts[num6])
                    {
                        num8 = amounts[num6];
                        for (num9 = 0; (num9 < itemArrayArrayArray1[num6][num7].Length); ++num9)
                        {
                            item3 = itemArrayArrayArray1[num6][num7][num9];
                            num10 = item3.Amount;
                            if (num10 < num8)
                            {
                                if (callback != null)
                                {
                                    callback(item3, num10);
                                }
                                item3.Delete();
                                num8 -= num10;
                            }
                            else
                            {
                                if (callback != null)
                                {
                                    callback(item3, num8);
                                }
                                item3.Consume(num8);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return -1;
        }

        public int ConsumeUpTo(Type type, int amount)
        {
            return this.ConsumeUpTo(type, amount, true);
        }

        public int ConsumeUpTo(Type type, int amount, bool recurse)
        {
            int num1 = 0;
            Queue queue1 = new Queue();
            Container.RecurseConsumeUpTo(this, type, amount, recurse, ref num1, queue1);
            while ((queue1.Count > 0))
            {
                ((Item) queue1.Dequeue()).Delete();
            }
            return num1;
        }

        public override void Deserialize(GenericReader reader)
        {
            Server.Items.Container.SaveFlag flag1;
            base.Deserialize(reader);
            int num1 = reader.ReadInt();
            switch (num1)
            {
                case 0:
                {
                    goto Label_0090;
                }
                case 1:
                {
                    goto Label_0084;
                }
                case 2:
                {
                    flag1 = ((Server.Items.Container.SaveFlag) reader.ReadByte());
                    if (!Container.GetSaveFlag(flag1, 1))
                    {
                        goto Label_0041;
                    }
                    this.m_MaxItems = reader.ReadEncodedInt();
                    goto Label_0048;
                }
            }
            return;
        Label_0041:
            this.m_MaxItems = -1;
        Label_0048:
            if (Container.GetSaveFlag(flag1, 2))
            {
                this.m_GumpID = reader.ReadEncodedInt();
            }
            else
            {
                this.m_GumpID = -1;
            }
            if (Container.GetSaveFlag(flag1, 4))
            {
                this.m_DropSound = reader.ReadEncodedInt();
                return;
            }
            this.m_DropSound = -1;
            return;
        Label_0084:
            this.m_MaxItems = reader.ReadInt();
        Label_0090:
            if (num1 < 1)
            {
                this.m_MaxItems = Container.m_GlobalMaxItems;
            }
            this.m_GumpID = reader.ReadInt();
            this.m_DropSound = reader.ReadInt();
            if (this.m_GumpID == this.DefaultGumpID)
            {
                this.m_GumpID = -1;
            }
            if (this.m_DropSound == this.DefaultDropSound)
            {
                this.m_DropSound = -1;
            }
            if (this.m_MaxItems == this.DefaultMaxItems)
            {
                this.m_MaxItems = -1;
            }
            reader.ReadPoint2D();
            reader.ReadPoint2D();
        }

        public virtual void Destroy()
        {
            int num1;
            Point3D pointd1 = base.GetWorldLocation();
            Map map1 = base.Map;
            for (num1 = (base.Items.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < base.Items.Count)
                {
                    ((Item) base.Items[num1]).SetLastMoved();
                    ((Item) base.Items[num1]).MoveToWorld(pointd1, map1);
                }
            }
            this.Delete();
        }

        public virtual void DisplayTo(Mobile to)
        {
            bool flag1;
            Point3D pointd1;
            Map map1;
            int num1;
            Mobile mobile1;
            int num2;
            int num3;
            if (!this.IsPublicContainer)
            {
                flag1 = false;
                if (this.m_Openers != null)
                {
                    pointd1 = base.GetWorldLocation();
                    map1 = base.Map;
                    for (num1 = 0; (num1 < this.m_Openers.Count); ++num1)
                    {
                        mobile1 = ((Mobile) this.m_Openers[num1]);
                        if (mobile1 == to)
                        {
                            flag1 = true;
                        }
                        else
                        {
                            num2 = this.GetUpdateRange(mobile1);
                            if ((mobile1.Map != map1) || !mobile1.InRange(pointd1, num2))
                            {
                                this.m_Openers.RemoveAt(num1--);
                            }
                        }
                    }
                }
                if (!flag1)
                {
                    if (this.m_Openers == null)
                    {
                        this.m_Openers = new ArrayList(4);
                    }
                    this.m_Openers.Add(to);
                }
                else if ((this.m_Openers != null) && (this.m_Openers.Count == 0))
                {
                    this.m_Openers = null;
                }
            }
            to.Send(new ContainerDisplay(this));
            to.Send(new ContainerContent(to, this));
            if (!ObjectPropertyList.Enabled)
            {
                return;
            }
            ArrayList list1 = base.Items;
            for (num3 = 0; (num3 < list1.Count); ++num3)
            {
                to.Send(((Item) list1[num3]).OPLPacket);
            }
        }

        public virtual void DropItem(Item dropped)
        {
            int num1;
            int num2;
            this.AddItem(dropped);
            Rectangle2D rectangled1 = dropped.GetGraphicBounds();
            Rectangle2D rectangled2 = this.Bounds;
            if (rectangled1.Width >= rectangled2.Width)
            {
                num1 = ((rectangled2.Width - rectangled1.Width) / 2);
            }
            else
            {
                num1 = Utility.Random((rectangled2.Width - rectangled1.Width));
            }
            if (rectangled1.Height >= rectangled2.Height)
            {
                num2 = ((rectangled2.Height - rectangled1.Height) / 2);
            }
            else
            {
                num2 = Utility.Random((rectangled2.Height - rectangled1.Height));
            }
            num1 += rectangled2.X;
            num1 -= rectangled1.X;
            num2 += rectangled2.Y;
            num2 -= rectangled1.Y;
            dropped.Location = new Point3D(num1, num2, 0);
        }

        public Item FindItemByType(Type type)
        {
            return this.FindItemByType(type, true);
        }

        public Item FindItemByType(Type[] types)
        {
            return this.FindItemByType(types, true);
        }

        public Item FindItemByType(Type type, bool recurse)
        {
            return Container.RecurseFindItemByType(this, type, recurse);
        }

        public Item FindItemByType(Type[] types, bool recurse)
        {
            return Container.RecurseFindItemByType(this, types, recurse);
        }

        public Item[] FindItemsByType(Type[] types)
        {
            return this.FindItemsByType(types, true);
        }

        public Item[] FindItemsByType(Type type)
        {
            return this.FindItemsByType(type, true);
        }

        public Item[] FindItemsByType(Type type, bool recurse)
        {
            if (Container.m_FindItemsList.Count > 0)
            {
                Container.m_FindItemsList.Clear();
            }
            Container.RecurseFindItemsByType(this, type, recurse, Container.m_FindItemsList);
            return ((Item[]) Container.m_FindItemsList.ToArray(typeof(Item)));
        }

        public Item[] FindItemsByType(Type[] types, bool recurse)
        {
            if (Container.m_FindItemsList.Count > 0)
            {
                Container.m_FindItemsList.Clear();
            }
            Container.RecurseFindItemsByType(this, types, recurse, Container.m_FindItemsList);
            return ((Item[]) Container.m_FindItemsList.ToArray(typeof(Item)));
        }

        public int GetAmount(Type type)
        {
            return this.GetAmount(type, true);
        }

        public int GetAmount(Type[] types)
        {
            return this.GetAmount(types, true);
        }

        public int GetAmount(Type type, bool recurse)
        {
            int num2;
            Item[] itemArray1 = this.FindItemsByType(type, recurse);
            int num1 = 0;
            for (num2 = 0; (num2 < itemArray1.Length); ++num2)
            {
                num1 += itemArray1[num2].Amount;
            }
            return num1;
        }

        public int GetAmount(Type[] types, bool recurse)
        {
            int num2;
            Item[] itemArray1 = this.FindItemsByType(types, recurse);
            int num1 = 0;
            for (num2 = 0; (num2 < itemArray1.Length); ++num2)
            {
                num1 += itemArray1[num2].Amount;
            }
            return num1;
        }

        public int GetBestGroupAmount(Type[][] types, bool recurse, CheckItemGroup grouper)
        {
            int num2;
            Item[] itemArray1;
            ArrayList list1;
            int num3;
            Item item1;
            ArrayList list2;
            Item item2;
            int num4;
            int num5;
            Item[] itemArray2;
            int num6;
            int num7;
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            int num1 = 0;
            for (num2 = 0; (num2 < types.Length); ++num2)
            {
                itemArray1 = this.FindItemsByType(types[num2], recurse);
                list1 = new ArrayList();
                num3 = 0;
                while ((num3 < itemArray1.Length))
                {
                    item1 = itemArray1[num3++];
                    list2 = new ArrayList();
                    list2.Add(item1);
                    while ((num3 < itemArray1.Length))
                    {
                        item2 = itemArray1[num3];
                        num4 = grouper(item1, item2);
                        if (num4 != 0)
                        {
                            break;
                        }
                        list2.Add(item2);
                        ++num3;
                    }
                    list1.Add(list2);
                }
                for (num5 = 0; (num5 < list1.Count); ++num5)
                {
                    itemArray2 = ((Item[]) ((ArrayList) list1[num5]).ToArray(typeof(Item)));
                    num6 = 0;
                    for (num7 = 0; (num7 < itemArray2.Length); ++num7)
                    {
                        num6 += itemArray2[num7].Amount;
                    }
                    if (num6 >= num1)
                    {
                        num1 = num6;
                    }
                }
            }
            return num1;
        }

        public int GetBestGroupAmount(Type type, bool recurse, CheckItemGroup grouper)
        {
            Item item1;
            ArrayList list2;
            Item item2;
            int num3;
            int num4;
            Item[] itemArray2;
            int num5;
            int num6;
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            int num1 = 0;
            Item[] itemArray1 = this.FindItemsByType(type, recurse);
            ArrayList list1 = new ArrayList();
            int num2 = 0;
            while ((num2 < itemArray1.Length))
            {
                item1 = itemArray1[num2++];
                list2 = new ArrayList();
                list2.Add(item1);
                while ((num2 < itemArray1.Length))
                {
                    item2 = itemArray1[num2];
                    num3 = grouper(item1, item2);
                    if (num3 != 0)
                    {
                        break;
                    }
                    list2.Add(item2);
                    ++num2;
                }
                list1.Add(list2);
            }
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                itemArray2 = ((Item[]) ((ArrayList) list1[num4]).ToArray(typeof(Item)));
                num5 = 0;
                for (num6 = 0; (num6 < itemArray2.Length); ++num6)
                {
                    num5 += itemArray2[num6].Amount;
                }
                if (num5 >= num1)
                {
                    num1 = num5;
                }
            }
            return num1;
        }

        public int GetBestGroupAmount(Type[] types, bool recurse, CheckItemGroup grouper)
        {
            Item item1;
            ArrayList list2;
            Item item2;
            int num3;
            int num4;
            Item[] itemArray2;
            int num5;
            int num6;
            if (grouper == null)
            {
                throw new ArgumentNullException();
            }
            int num1 = 0;
            Item[] itemArray1 = this.FindItemsByType(types, recurse);
            ArrayList list1 = new ArrayList();
            int num2 = 0;
            while ((num2 < itemArray1.Length))
            {
                item1 = itemArray1[num2++];
                list2 = new ArrayList();
                list2.Add(item1);
                while ((num2 < itemArray1.Length))
                {
                    item2 = itemArray1[num2];
                    num3 = grouper(item1, item2);
                    if (num3 != 0)
                    {
                        break;
                    }
                    list2.Add(item2);
                    ++num2;
                }
                list1.Add(list2);
            }
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                itemArray2 = ((Item[]) ((ArrayList) list1[num4]).ToArray(typeof(Item)));
                num5 = 0;
                for (num6 = 0; (num6 < itemArray2.Length); ++num6)
                {
                    num5 += itemArray2[num6].Amount;
                }
                if (num5 >= num1)
                {
                    num1 = num5;
                }
            }
            return num1;
        }

        public virtual int GetDroppedSound(Item item)
        {
            int num1 = item.GetDropSound();
            if (num1 == -1)
            {
                return this.DropSound;
            }
            return num1;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            if (this.DisplaysContent)
            {
                list.Add(1050044, "{0}\t{1}", base.TotalItems, base.TotalWeight);
            }
        }

        private static bool GetSaveFlag(Server.Items.Container.SaveFlag flags, Server.Items.Container.SaveFlag toGet)
        {
            return ((flags & toGet) != ((byte) 0));
        }

        private static bool InTypeList(Item item, Type[] types)
        {
            int num1;
            Type type1 = item.GetType();
            for (num1 = 0; (num1 < types.Length); ++num1)
            {
                if (types[num1].IsAssignableFrom(type1))
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnDelete()
        {
            base.OnDelete();
            this.m_Openers = null;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if ((from.AccessLevel > AccessLevel.Player) || from.InRange(base.GetWorldLocation(), 2))
            {
                this.DisplayTo(from);
                return;
            }
            from.SendLocalizedMessage(500446);
        }

        public override void OnDoubleClickSecureTrade(Mobile from)
        {
            SecureTradeContainer container1;
            SecureTrade trade1;
            if (from.InRange(base.GetWorldLocation(), 2))
            {
                this.DisplayTo(from);
                container1 = base.GetSecureTradeCont();
                if (container1 == null)
                {
                    return;
                }
                trade1 = container1.Trade;
                if ((trade1 != null) && (trade1.From.Mobile == from))
                {
                    this.DisplayTo(trade1.To.Mobile);
                    return;
                }
                if ((trade1 == null) || (trade1.To.Mobile != from))
                {
                    return;
                }
                this.DisplayTo(trade1.From.Mobile);
                return;
            }
            from.SendLocalizedMessage(500446);
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (this.TryDropItem(from, dropped, true))
            {
                from.SendSound(this.GetDroppedSound(dropped), base.GetWorldLocation());
                return true;
            }
            return false;
        }

        public virtual bool OnDragDropInto(Mobile from, Item item, Point3D p)
        {
            if (!this.CheckHold(from, item, true, true))
            {
                return false;
            }
            item.Location = new Point3D(p.m_X, p.m_Y, 0);
            this.AddItem(item);
            from.SendSound(this.GetDroppedSound(item), base.GetWorldLocation());
            return true;
        }

        public override void OnSingleClick(Mobile from)
        {
            object[] objArray1;
            base.OnSingleClick(from);
            if (this.CheckContentDisplay(from))
            {
                objArray1 = new object[2];
                objArray1[0] = base.TotalItems;
                objArray1[1] = base.TotalWeight;
                base.LabelTo(from, "({0} items, {1} stones)", objArray1);
            }
        }

        public override void OnSnoop(Mobile from)
        {
            if (Container.m_SnoopHandler != null)
            {
                Container.m_SnoopHandler(this, from);
            }
        }

        public virtual bool OnStackAttempt(Mobile from, Item stack, Item dropped)
        {
            if (!this.CheckHold(from, dropped, true, false))
            {
                return false;
            }
            return stack.StackWith(from, dropped);
        }

        private static void RecurseConsumeUpTo(Item current, Type type, int amount, bool recurse, ref int consumed, Queue toDelete)
        {
            Item item1;
            int num2;
            int num3;
            if ((current == null) || (current.Items.Count <= 0))
            {
                return;
            }
            ArrayList list1 = current.Items;
            int num1 = 0;
            while ((num1 < list1.Count))
            {
                item1 = ((Item) list1[num1]);
                if (type.IsAssignableFrom(item1.GetType()))
                {
                    num2 = (amount - consumed);
                    num3 = item1.Amount;
                    if (num3 <= num2)
                    {
                        toDelete.Enqueue(item1);
                        consumed += num3;
                        goto Label_0090;
                    }
                    item1.Amount -= num2;
                    consumed += num2;
                    return;
                }
                if (recurse && (item1 is Container))
                {
                    Container.RecurseConsumeUpTo(item1, type, amount, recurse, ref consumed, toDelete);
                }
            Label_0090:
                ++num1;
            }
        }

        private static Item RecurseFindItemByType(Item current, Type type, bool recurse)
        {
            ArrayList list1;
            int num1;
            Item item1;
            Item item2;
            if ((current != null) && (current.Items.Count > 0))
            {
                list1 = current.Items;
                for (num1 = 0; (num1 < list1.Count); ++num1)
                {
                    item1 = ((Item) list1[num1]);
                    if (type.IsAssignableFrom(item1.GetType()))
                    {
                        return item1;
                    }
                    if (recurse && (item1 is Container))
                    {
                        item2 = Container.RecurseFindItemByType(item1, type, recurse);
                        if (item2 != null)
                        {
                            return item2;
                        }
                    }
                }
            }
            return null;
        }

        private static Item RecurseFindItemByType(Item current, Type[] types, bool recurse)
        {
            ArrayList list1;
            int num1;
            Item item1;
            Item item2;
            if ((current != null) && (current.Items.Count > 0))
            {
                list1 = current.Items;
                for (num1 = 0; (num1 < list1.Count); ++num1)
                {
                    item1 = ((Item) list1[num1]);
                    if (Container.InTypeList(item1, types))
                    {
                        return item1;
                    }
                    if (recurse && (item1 is Container))
                    {
                        item2 = Container.RecurseFindItemByType(item1, types, recurse);
                        if (item2 != null)
                        {
                            return item2;
                        }
                    }
                }
            }
            return null;
        }

        private static void RecurseFindItemsByType(Item current, Type[] types, bool recurse, ArrayList list)
        {
            int num1;
            Item item1;
            if ((current == null) || (current.Items.Count <= 0))
            {
                return;
            }
            ArrayList list1 = current.Items;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                item1 = ((Item) list1[num1]);
                if (Container.InTypeList(item1, types))
                {
                    list.Add(item1);
                }
                if (recurse && (item1 is Container))
                {
                    Container.RecurseFindItemsByType(item1, types, recurse, list);
                }
            }
        }

        private static void RecurseFindItemsByType(Item current, Type type, bool recurse, ArrayList list)
        {
            int num1;
            Item item1;
            if ((current == null) || (current.Items.Count <= 0))
            {
                return;
            }
            ArrayList list1 = current.Items;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                item1 = ((Item) list1[num1]);
                if (type.IsAssignableFrom(item1.GetType()))
                {
                    list.Add(item1);
                }
                if (recurse && (item1 is Container))
                {
                    Container.RecurseFindItemsByType(item1, type, recurse, list);
                }
            }
        }

        public virtual void SendFullItemsMessage(Mobile to, Item item)
        {
            to.SendMessage("That container cannot hold more items.");
        }

        public virtual void SendFullWeightMessage(Mobile to, Item item)
        {
            to.SendMessage("That container cannot hold more weight.");
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(2);
            Server.Items.Container.SaveFlag flag1 = 0;
            Container.SetSaveFlag(ref flag1, 1, (this.m_MaxItems != -1));
            Container.SetSaveFlag(ref flag1, 2, (this.m_GumpID != -1));
            Container.SetSaveFlag(ref flag1, 4, (this.m_DropSound != -1));
            writer.Write(((byte) flag1));
            if (Container.GetSaveFlag(flag1, 1))
            {
                writer.WriteEncodedInt(this.m_MaxItems);
            }
            if (Container.GetSaveFlag(flag1, 2))
            {
                writer.WriteEncodedInt(this.m_GumpID);
            }
            if (Container.GetSaveFlag(flag1, 4))
            {
                writer.WriteEncodedInt(this.m_DropSound);
            }
        }

        private static void SetSaveFlag(ref Server.Items.Container.SaveFlag flags, Server.Items.Container.SaveFlag toSet, bool setIf)
        {
            if (setIf)
            {
                flags |= toSet;
            }
        }

        public virtual bool TryDropItem(Mobile from, Item dropped, bool sendFullMessage)
        {
            int num1;
            Item item1;
            if (!this.CheckHold(from, dropped, sendFullMessage, true))
            {
                return false;
            }
            ArrayList list1 = base.Items;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                item1 = ((Item) list1[num1]);
                if (!(item1 is Container) && item1.StackWith(from, dropped, false))
                {
                    return true;
                }
            }
            this.DropItem(dropped);
            return true;
        }


        // Properties
        public virtual Rectangle2D Bounds
        {
            get
            {
                return new Rectangle2D(44, 65, 142, 94);
            }
        }

        public virtual int DefaultDropSound
        {
            get
            {
                return 72;
            }
        }

        public virtual int DefaultGumpID
        {
            get
            {
                return 60;
            }
        }

        public virtual int DefaultMaxItems
        {
            get
            {
                return Container.m_GlobalMaxItems;
            }
        }

        public virtual int DefaultMaxWeight
        {
            get
            {
                return Container.m_GlobalMaxWeight;
            }
        }

        public virtual bool DisplaysContent
        {
            get
            {
                return true;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int DropSound
        {
            get
            {
                if (this.m_DropSound != -1)
                {
                    return this.m_DropSound;
                }
                return this.DefaultDropSound;
            }
            set
            {
                this.m_DropSound = value;
            }
        }

        public static int GlobalMaxItems
        {
            get
            {
                return Container.m_GlobalMaxItems;
            }
            set
            {
                Container.m_GlobalMaxItems = value;
            }
        }

        public static int GlobalMaxWeight
        {
            get
            {
                return Container.m_GlobalMaxWeight;
            }
            set
            {
                Container.m_GlobalMaxWeight = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int GumpID
        {
            get
            {
                if (this.m_GumpID != -1)
                {
                    return this.m_GumpID;
                }
                return this.DefaultGumpID;
            }
            set
            {
                this.m_GumpID = value;
            }
        }

        public virtual bool IsPublicContainer
        {
            get
            {
                return false;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxItems
        {
            get
            {
                if (this.m_MaxItems != -1)
                {
                    return this.m_MaxItems;
                }
                return this.DefaultMaxItems;
            }
            set
            {
                this.m_MaxItems = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int MaxWeight
        {
            get
            {
                if ((this.Parent is Container) && (((Container) this.Parent).MaxWeight == 0))
                {
                    return 0;
                }
                if (base.Movable || ((this.Parent is Mobile) && ((Mobile) this.Parent).Player))
                {
                    return this.DefaultMaxWeight;
                }
                return 0;
            }
        }

        public ArrayList Openers
        {
            get
            {
                return this.m_Openers;
            }
            set
            {
                this.m_Openers = value;
            }
        }

        public static ContainerSnoopHandler SnoopHandler
        {
            get
            {
                return Container.m_SnoopHandler;
            }
            set
            {
                Container.m_SnoopHandler = value;
            }
        }


        // Fields
        private int m_DropSound;
        private static ArrayList m_FindItemsList;
        private static int m_GlobalMaxItems;
        private static int m_GlobalMaxWeight;
        private int m_GumpID;
        private int m_MaxItems;
        private ArrayList m_Openers;
        private static ContainerSnoopHandler m_SnoopHandler;

        // Nested Types
        private class GroupComparer : IComparer
        {
            // Methods
            public GroupComparer(CheckItemGroup grouper)
            {
                this.m_Grouper = grouper;
            }

            public int Compare(object x, object y)
            {
                Item item1 = ((Item) x);
                Item item2 = ((Item) y);
                return this.m_Grouper(item1, item2);
            }


            // Fields
            private CheckItemGroup m_Grouper;
        }

        [Flags]
        private enum SaveFlag
        {
            // Fields
            DropSound = 4,
            GumpID = 2,
            MaxItems = 1,
            None = 0
        }
    }
}

