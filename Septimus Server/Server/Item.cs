namespace Server
{
    using Server.Items;
    using Server.Network;
    using Server.Targeting;
    using System;
    using System.Collections;
    using System.Diagnostics;

    public class Item : IEntity, IPoint3D, IPoint2D, IHued
    {
        // Methods
        static Item()
        {
            Item.m_DDT = TimeSpan.FromHours(1);
            Item.m_DeltaQueue = new ArrayList();
        }

        public Item()
        {
            this.m_Serial = Serial.NewItem;
            this.m_Items = new ArrayList(1);
            this.Visible = true;
            this.Movable = true;
            this.Amount = 1;
            this.m_Map = Map.Internal;
            this.SetLastMoved();
            World.AddItem(this);
        }

        public Item(Serial serial)
        {
            this.m_Serial = serial;
        }

        [Constructable]
        public Item(int itemID)
        {
            this.m_ItemID = itemID;
        }

        public virtual void AddBlessedForProperty(ObjectPropertyList list, Mobile m)
        {
            list.Add(1062203, "{0}", m.Name);
        }

        public virtual void AddItem(Item item)
        {
            object[] objArray1;
            Serial serial1;
            if (((item == null) || item.Deleted) || (item.m_Parent == this))
            {
                return;
            }
            if (item == this)
            {
                objArray1 = new object[4];
                serial1 = this.Serial;
                objArray1[0] = serial1.Value;
                objArray1[1] = base.GetType().Name;
                serial1 = item.Serial;
                objArray1[2] = serial1.Value;
                objArray1[3] = item.GetType().Name;
                Console.WriteLine("Warning: Adding item to itself: [0x{0:X} {1}].AddItem( [0x{2:X} {3}] )", objArray1);
                Console.WriteLine(new StackTrace());
                return;
            }
            if (this.IsChildOf(item))
            {
                objArray1 = new object[4];
                serial1 = this.Serial;
                objArray1[0] = serial1.Value;
                objArray1[1] = base.GetType().Name;
                serial1 = item.Serial;
                objArray1[2] = serial1.Value;
                objArray1[3] = item.GetType().Name;
                Console.WriteLine("Warning: Adding parent item to child: [0x{0:X} {1}].AddItem( [0x{2:X} {3}] )", objArray1);
                Console.WriteLine(new StackTrace());
                return;
            }
            if ((item.m_Parent is Mobile))
            {
                ((Mobile) item.m_Parent).RemoveItem(item);
            }
            else if ((item.m_Parent is Item))
            {
                ((Item) item.m_Parent).RemoveItem(item);
            }
            else
            {
                item.SendRemovePacket();
            }
            item.Parent = this;
            item.Map = this.m_Map;
            int num1 = this.m_Items.Count;
            this.m_Items.Add(item);
            this.TotalItems = ((((this.TotalItems - num1) + this.m_Items.Count) + item.TotalItems) - (item.IsVirtualItem ? 1 : 0));
            this.TotalWeight += (item.TotalWeight + item.PileWeight);
            this.TotalGold += item.TotalGold;
            item.Delta(ItemDelta.Update);
            item.OnAdded(this);
            this.OnItemAdded(item);
        }

        public virtual void AddLockedDownProperty(ObjectPropertyList list)
        {
            list.Add(501643);
        }

        public virtual void AddLootTypeProperty(ObjectPropertyList list)
        {
            if (this.m_LootType == LootType.Blessed)
            {
                list.Add(1038021);
                return;
            }
            if (this.m_LootType == LootType.Cursed)
            {
                list.Add(1049643);
                return;
            }
            if (this.Insured)
            {
                list.Add(1061682);
            }
        }

        public virtual void AddNameProperties(ObjectPropertyList list)
        {
            this.AddNameProperty(list);
            if (this.IsSecure)
            {
                this.AddSecureProperty(list);
            }
            else if (this.IsLockedDown)
            {
                this.AddLockedDownProperty(list);
            }
            if ((this.m_BlessedFor != null) && !this.m_BlessedFor.Deleted)
            {
                this.AddBlessedForProperty(list, this.m_BlessedFor);
            }
            if (this.DisplayLootType)
            {
                this.AddLootTypeProperty(list);
            }
        }

        public virtual void AddNameProperty(ObjectPropertyList list)
        {
            if (this.m_Name == null)
            {
                if (this.m_Amount <= 1)
                {
                    list.Add(this.LabelNumber);
                    return;
                }
                list.Add(1050039, "{0}\t#{1}", this.m_Amount, this.LabelNumber);
                return;
            }
            if (this.m_Amount <= 1)
            {
                list.Add(this.m_Name);
                return;
            }
            list.Add(1050039, "{0}\t{1}", this.m_Amount, this.Name);
        }

        public virtual void AddResistanceProperties(ObjectPropertyList list)
        {
            int num1 = this.PhysicalResistance;
            if (num1 != 0)
            {
                list.Add(1060448, num1.ToString());
            }
            num1 = this.FireResistance;
            if (num1 != 0)
            {
                list.Add(1060447, num1.ToString());
            }
            num1 = this.ColdResistance;
            if (num1 != 0)
            {
                list.Add(1060445, num1.ToString());
            }
            num1 = this.PoisonResistance;
            if (num1 != 0)
            {
                list.Add(1060449, num1.ToString());
            }
            num1 = this.EnergyResistance;
            if (num1 != 0)
            {
                list.Add(1060446, num1.ToString());
            }
        }

        public virtual void AddSecureProperty(ObjectPropertyList list)
        {
            list.Add(501644);
        }

        public virtual bool AllowEquipedCast(Mobile from)
        {
            return false;
        }

        public virtual bool AllowSecureTrade(Mobile from, Mobile to, Mobile newOwner, bool accepted)
        {
            return true;
        }

        public bool AtPoint(int x, int y)
        {
            if (this.m_Location.m_X == x)
            {
                return (this.m_Location.m_Y == y);
            }
            return false;
        }

        public bool AtWorldPoint(int x, int y)
        {
            if ((this.m_Parent == null) && (this.m_Location.m_X == x))
            {
                return (this.m_Location.m_Y == y);
            }
            return false;
        }

        public void Bounce(Mobile from)
        {
            object obj1;
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).RemoveItem(this);
            }
            else if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).RemoveItem(this);
            }
            this.m_Parent = null;
            if (this.m_Bounce != null)
            {
                obj1 = this.m_Bounce.m_Parent;
                if ((obj1 is Item) && !((Item) obj1).Deleted)
                {
                    this.Location = this.m_Bounce.m_Location;
                    ((Item) obj1).AddItem(this);
                }
                else if ((obj1 is Mobile) && !((Mobile) obj1).Deleted)
                {
                    if (!((Mobile) obj1).EquipItem(this))
                    {
                        this.MoveToWorld(this.m_Bounce.m_WorldLoc, this.m_Bounce.m_Map);
                    }
                }
                else
                {
                    this.MoveToWorld(this.m_Bounce.m_WorldLoc, this.m_Bounce.m_Map);
                }
            }
            else
            {
                this.MoveToWorld(from.Location, from.Map);
            }
            this.m_Bounce = null;
        }

        public virtual bool CanEquip(Mobile m)
        {
            if (this.m_Layer != Layer.Invalid)
            {
                return (m.FindItemOnLayer(this.m_Layer) == null);
            }
            return false;
        }

        public virtual bool CheckBlessed(Mobile m)
        {
            if ((this.m_LootType == LootType.Blessed) || (Mobile.InsuranceEnabled && this.Insured))
            {
                return true;
            }
            if (m != null)
            {
                return (m == this.m_BlessedFor);
            }
            return false;
        }

        public virtual bool CheckBlessed(object obj)
        {
            return this.CheckBlessed((obj as Mobile));
        }

        public virtual bool CheckConflictingLayer(Mobile m, Item item, Layer layer)
        {
            return (this.m_Layer == layer);
        }

        public virtual bool CheckItemUse(Mobile from, Item item)
        {
            if ((this.m_Parent is Item))
            {
                return ((Item) this.m_Parent).CheckItemUse(from, item);
            }
            if ((this.m_Parent is Mobile))
            {
                return ((Mobile) this.m_Parent).CheckItemUse(from, item);
            }
            return true;
        }

        public virtual bool CheckLift(Mobile from, Item item)
        {
            if ((this.m_Parent is Item))
            {
                return ((Item) this.m_Parent).CheckLift(from, item);
            }
            if ((this.m_Parent is Mobile))
            {
                return ((Mobile) this.m_Parent).CheckLift(from, item);
            }
            return true;
        }

        public virtual bool CheckNewbied()
        {
            return (this.m_LootType == LootType.Newbied);
        }

        public virtual bool CheckPropertyConfliction(Mobile m)
        {
            return false;
        }

        public virtual bool CheckTarget(Mobile from, Target targ, object targeted)
        {
            if ((this.m_Parent is Item))
            {
                return ((Item) this.m_Parent).CheckTarget(from, targ, targeted);
            }
            if ((this.m_Parent is Mobile))
            {
                return ((Mobile) this.m_Parent).CheckTarget(from, targ, targeted);
            }
            return true;
        }

        public void ClearBounce()
        {
            this.m_Bounce = null;
        }

        public virtual void Consume()
        {
            this.Consume(1);
        }

        public virtual void Consume(int amount)
        {
            this.Amount -= amount;
            if (this.Amount <= 0)
            {
                this.Delete();
            }
        }

        public virtual void Delete()
        {
            int num1;
            if (this.Deleted)
            {
                return;
            }
            if (!World.OnDelete(this))
            {
                return;
            }
            this.OnDelete();
            for (num1 = (this.m_Items.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Items.Count)
                {
                    ((Item) this.m_Items[num1]).OnParentDeleted(this);
                }
            }
            this.SendRemovePacket();
            this.SetFlag(4, true);
            if ((this.Parent is Mobile))
            {
                ((Mobile) this.Parent).RemoveItem(this);
            }
            else if ((this.Parent is Item))
            {
                ((Item) this.Parent).RemoveItem(this);
            }
            if (this.m_Map != null)
            {
                this.m_Map.OnLeave(this);
                this.m_Map = null;
            }
            World.RemoveItem(this);
            this.OnAfterDelete();
            this.m_RemovePacket = null;
            this.m_WorldPacket = null;
            this.m_OPLPacket = null;
            this.m_PropertyList = null;
        }

        public void Delta(ItemDelta flags)
        {
            if ((this.m_Map == null) || (this.m_Map == Map.Internal))
            {
                return;
            }
            this.m_DeltaFlags |= flags;
            if (!this.GetFlag(16))
            {
                this.SetFlag(16, true);
                Item.m_DeltaQueue.Add(this);
            }
        }

        public virtual void Deserialize(GenericReader reader)
        {
            Server.Item.SaveFlag flag1;
            int num2;
            Serial serial1;
            Server.Item.SaveFlag flag2;
            Serial serial2;
            int num7;
            Item item1;
            int num1 = reader.ReadInt();
            this.SetLastMoved();
            switch (num1)
            {
                case 0:
                {
                    goto Label_06B3;
                }
                case 1:
                {
                    goto Label_06A7;
                }
                case 2:
                {
                    goto Label_068F;
                }
                case 3:
                case 4:
                {
                    goto Label_0682;
                }
                case 5:
                {
                    flag2 = ((Server.Item.SaveFlag) reader.ReadInt());
                    this.LastMoved = reader.ReadDeltaTime();
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Direction))
                    {
                        this.m_Direction = ((Direction) reader.ReadByte());
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Bounce))
                    {
                        this.m_Bounce = BounceInfo.Deserialize(reader);
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.LootType))
                    {
                        this.m_LootType = ((LootType) reader.ReadByte());
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.LocationFull))
                    {
                        this.m_Location = reader.ReadPoint3D();
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.ItemID))
                    {
                        this.m_ItemID = reader.ReadInt();
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Hue))
                    {
                        this.m_Hue = reader.ReadInt();
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Amount))
                    {
                        this.m_Amount = reader.ReadInt();
                    }
                    else
                    {
                        this.m_Amount = 1;
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Layer))
                    {
                        this.m_Layer = ((Layer) reader.ReadByte());
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Name))
                    {
                        this.m_Name = reader.ReadString();
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Parent))
                    {
                        serial2 = Serial.op_Implicit(reader.ReadInt());
                        if (serial2.IsMobile)
                        {
                            this.m_Parent = World.FindMobile(serial2);
                        }
                        else if (serial2.IsItem)
                        {
                            this.m_Parent = World.FindItem(serial2);
                        }
                        else
                        {
                            this.m_Parent = null;
                        }
                        if ((this.m_Parent == null) && (serial2.IsMobile || serial2.IsItem))
                        {
                            this.Delete();
                        }
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Items))
                    {
                        this.m_Items = reader.ReadItemList();
                    }
                    else
                    {
                        this.m_Items = new ArrayList(1);
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.IntWeight))
                    {
                        this.m_Weight = reader.ReadEncodedInt();
                    }
                    else if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.WeightNot1or0))
                    {
                        this.m_Weight = reader.ReadDouble();
                    }
                    else if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.WeightIs0))
                    {
                        this.m_Weight = 0;
                    }
                    else
                    {
                        this.m_Weight = 1;
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Map))
                    {
                        this.m_Map = reader.ReadMap();
                    }
                    else
                    {
                        this.m_Map = Map.Internal;
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Visible))
                    {
                        this.SetFlag(1, reader.ReadBool());
                    }
                    else
                    {
                        this.SetFlag(1, true);
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Movable))
                    {
                        this.SetFlag(2, reader.ReadBool());
                    }
                    else
                    {
                        this.SetFlag(2, true);
                    }
                    if (Item.GetSaveFlag(flag2, Server.Item.SaveFlag.Stackable))
                    {
                        this.SetFlag(8, reader.ReadBool());
                    }
                    if ((this.m_Map == null) || (this.m_Parent != null))
                    {
                        return;
                    }
                    this.m_Map.OnEnter(this);
                    return;
                }
                case 6:
                case 7:
                {
                    flag1 = ((Server.Item.SaveFlag) reader.ReadInt());
                    if (num1 >= 7)
                    {
                        goto Label_0051;
                    }
                    this.LastMoved = reader.ReadDeltaTime();
                    goto Label_007F;
                }
            }
            return;
        Label_0051:
            num2 = reader.ReadEncodedInt();
            try
            {
                this.LastMoved = (DateTime.Now - TimeSpan.FromMinutes(num2));
            }
            catch
            {
                this.LastMoved = DateTime.Now;
            }
        Label_007F:
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Direction))
            {
                this.m_Direction = ((Direction) reader.ReadByte());
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Bounce))
            {
                this.m_Bounce = BounceInfo.Deserialize(reader);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LootType))
            {
                this.m_LootType = ((LootType) reader.ReadByte());
            }
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationFull))
            {
                num3 = reader.ReadEncodedInt();
                num4 = reader.ReadEncodedInt();
                num5 = reader.ReadEncodedInt();
            }
            else
            {
                if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationByteXY))
                {
                    num3 = reader.ReadByte();
                    num4 = reader.ReadByte();
                }
                else if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationShortXY))
                {
                    num3 = reader.ReadShort();
                    num4 = reader.ReadShort();
                }
                if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationSByteZ))
                {
                    num5 = reader.ReadSByte();
                }
            }
            this.m_Location = new Point3D(num3, num4, num5);
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.ItemID))
            {
                this.m_ItemID = reader.ReadEncodedInt();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Hue))
            {
                this.m_Hue = reader.ReadEncodedInt();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Amount))
            {
                this.m_Amount = reader.ReadEncodedInt();
            }
            else
            {
                this.m_Amount = 1;
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Layer))
            {
                this.m_Layer = ((Layer) reader.ReadByte());
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Name))
            {
                this.m_Name = reader.ReadString();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Parent))
            {
                serial1 = Serial.op_Implicit(reader.ReadInt());
                if (serial1.IsMobile)
                {
                    this.m_Parent = World.FindMobile(serial1);
                }
                else if (serial1.IsItem)
                {
                    this.m_Parent = World.FindItem(serial1);
                }
                else
                {
                    this.m_Parent = null;
                }
                if ((this.m_Parent == null) && (serial1.IsMobile || serial1.IsItem))
                {
                    this.Delete();
                }
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Items))
            {
                this.m_Items = reader.ReadItemList();
            }
            else
            {
                this.m_Items = new ArrayList(1);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.IntWeight))
            {
                this.m_Weight = reader.ReadEncodedInt();
            }
            else if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.WeightNot1or0))
            {
                this.m_Weight = reader.ReadDouble();
            }
            else if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.WeightIs0))
            {
                this.m_Weight = 0;
            }
            else
            {
                this.m_Weight = 1;
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Map))
            {
                this.m_Map = reader.ReadMap();
            }
            else
            {
                this.m_Map = Map.Internal;
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Visible))
            {
                this.SetFlag(1, reader.ReadBool());
            }
            else
            {
                this.SetFlag(1, true);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Movable))
            {
                this.SetFlag(2, reader.ReadBool());
            }
            else
            {
                this.SetFlag(2, true);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Stackable))
            {
                this.SetFlag(8, reader.ReadBool());
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.ImplFlags))
            {
                this.m_Flags = ((ImplFlag) ((byte) reader.ReadEncodedInt()));
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.InsuredFor))
            {
                reader.ReadMobile();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.BlessedFor))
            {
                this.m_BlessedFor = reader.ReadMobile();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.HeldBy))
            {
                this.m_HeldBy = reader.ReadMobile();
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.SavedFlags))
            {
                this.m_SavedFlags = reader.ReadEncodedInt();
            }
            if ((this.m_Map == null) || (this.m_Parent != null))
            {
                return;
            }
            this.m_Map.OnEnter(this);
            return;
        Label_0682:
            this.m_Direction = ((Direction) ((byte) reader.ReadInt()));
        Label_068F:
            this.m_Bounce = BounceInfo.Deserialize(reader);
            this.LastMoved = reader.ReadDeltaTime();
        Label_06A7:
            this.m_LootType = ((LootType) reader.ReadByte());
        Label_06B3:
            this.m_Location = reader.ReadPoint3D();
            this.m_ItemID = reader.ReadInt();
            this.m_Hue = reader.ReadInt();
            this.m_Amount = reader.ReadInt();
            this.m_Layer = ((Layer) reader.ReadByte());
            this.m_Name = reader.ReadString();
            Serial serial3 = Serial.op_Implicit(reader.ReadInt());
            if (serial3.IsMobile)
            {
                this.m_Parent = World.FindMobile(serial3);
            }
            else if (serial3.IsItem)
            {
                this.m_Parent = World.FindItem(serial3);
            }
            else
            {
                this.m_Parent = null;
            }
            if ((this.m_Parent == null) && (serial3.IsMobile || serial3.IsItem))
            {
                this.Delete();
            }
            int num6 = reader.ReadInt();
            this.m_Items = new ArrayList(num6);
            for (num7 = 0; (num7 < num6); ++num7)
            {
                item1 = reader.ReadItem();
                if (item1 != null)
                {
                    this.m_Items.Add(item1);
                }
            }
            this.m_Weight = reader.ReadDouble();
            if (num1 <= 3)
            {
                reader.ReadInt();
                reader.ReadInt();
                reader.ReadInt();
            }
            this.m_Map = reader.ReadMap();
            this.SetFlag(1, reader.ReadBool());
            this.SetFlag(2, reader.ReadBool());
            if (num1 <= 3)
            {
                reader.ReadBool();
            }
            this.Stackable = reader.ReadBool();
            if ((this.m_Map != null) && (this.m_Parent == null))
            {
                this.m_Map.OnEnter(this);
            }
        }

        public virtual bool DropToItem(Mobile from, Item target, Point3D p)
        {
            if (((this.Deleted || from.Deleted) || (target.Deleted || (from.Map != target.Map))) || ((from.Map == null) || (target.Map == null)))
            {
                return false;
            }
            object obj1 = target.RootParent;
            if ((from.AccessLevel < AccessLevel.GameMaster) && !from.InRange(target.GetWorldLocation(), 2))
            {
                return false;
            }
            if (!from.CanSee(target) || !from.InLOS(target))
            {
                return false;
            }
            if (!target.IsAccessibleTo(from))
            {
                return false;
            }
            if ((obj1 is Mobile) && !((Mobile) obj1).CheckNonlocalDrop(from, this, target))
            {
                return false;
            }
            if (!from.OnDroppedItemToItem(this, target, p))
            {
                return false;
            }
            if (((target is Container) && (p.m_X != -1)) && (p.m_Y != -1))
            {
                return this.OnDroppedInto(from, ((Container) target), p);
            }
            return this.OnDroppedOnto(from, target);
        }

        public virtual bool DropToMobile(Mobile from, Mobile target, Point3D p)
        {
            if (((this.Deleted || from.Deleted) || (target.Deleted || (from.Map != target.Map))) || ((from.Map == null) || (target.Map == null)))
            {
                return false;
            }
            if ((from.AccessLevel < AccessLevel.GameMaster) && !from.InRange(target.Location, 2))
            {
                return false;
            }
            if (!from.CanSee(target) || !from.InLOS(target))
            {
                return false;
            }
            if (!from.OnDroppedItemToMobile(this, target))
            {
                return false;
            }
            if (!this.OnDroppedToMobile(from, target))
            {
                return false;
            }
            if (!target.OnDragDrop(from, this))
            {
                return false;
            }
            return true;
        }

        public virtual bool DropToWorld(Mobile from, Point3D p)
        {
            int num8;
            Tile tile2;
            ItemData data1;
            int num9;
            ItemData data2;
            int num10;
            int num12;
            Tile tile3;
            ItemData data3;
            int num13;
            int num14;
            int num15;
            int num16;
            int num17;
            int num18;
            Item item2;
            ItemData data4;
            int num19;
            int num20;
            int num21;
            int num22;
            int num23;
            int num26;
            int num27;
            Tile tile4;
            ItemData data5;
            int num28;
            int num29;
            int num30;
            Item item3;
            ItemData data6;
            int num31;
            if ((this.Deleted || from.Deleted) || (from.Map == null))
            {
                return false;
            }
            if (!from.InRange(p, 2))
            {
                return false;
            }
            Map map1 = from.Map;
            if (map1 == null)
            {
                return false;
            }
            int num1 = p.m_X;
            int num2 = p.m_Y;
            int num3 = -2147483648;
            int num4 = (from.Z + 16);
            Tile tile1 = map1.Tiles.GetLandTile(num1, num2);
            TileFlag flag1 = TileData.LandTable[(tile1.ID & 16383)].Flags;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            map1.GetAverageZ(num1, num2, ref num5, ref num6, ref num7);
            if ((!tile1.Ignored && ((flag1 & TileFlag.Impassable) == TileFlag.None)) && (num6 <= num4))
            {
                num3 = num6;
            }
            Tile[] tileArray1 = map1.Tiles.GetStaticTiles(num1, num2, true);
            for (num8 = 0; (num8 < tileArray1.Length); ++num8)
            {
                tile2 = tileArray1[num8];
                data1 = TileData.ItemTable[(tile2.ID & 16383)];
                if (data1.Surface)
                {
                    num9 = (tile2.Z + data1.CalcHeight);
                    if ((num9 <= num4) && (num9 >= num3))
                    {
                        num3 = num9;
                    }
                }
            }
            ArrayList list1 = new ArrayList();
            IPooledEnumerable enumerable1 = map1.GetItemsInRange(p, 0);
            foreach (Item item1 in enumerable1)
            {
                if (item1.ItemID >= 16384)
                {
                    continue;
                }
                list1.Add(item1);
                data2 = item1.ItemData;
                if (data2.Surface)
                {
                    num10 = (item1.Z + data2.CalcHeight);
                    if ((num10 <= num4) && (num10 >= num3))
                    {
                        num3 = num10;
                    }
                }
            }
            enumerable1.Free();
            if (num3 == -2147483648)
            {
                return false;
            }
            if (num3 > num4)
            {
                return false;
            }
            Item.m_OpenSlots = 1048575;
            int num11 = num3;
            for (num12 = 0; (num12 < tileArray1.Length); ++num12)
            {
                tile3 = tileArray1[num12];
                data3 = TileData.ItemTable[(tile3.ID & 16383)];
                num13 = tile3.Z;
                num14 = (num13 + data3.CalcHeight);
                if ((num14 == num13) && !data3.Surface)
                {
                    ++num14;
                }
                num15 = (num13 - num3);
                num16 = (num14 - num3);
                if ((num15 < 20) && (num16 >= 0))
                {
                    if (num15 < 0)
                    {
                        num15 = 0;
                    }
                    if (num16 > 19)
                    {
                        num16 = 19;
                    }
                    num17 = (num16 - num15);
                    Item.m_OpenSlots &= ~(((1 << (num17 & 31)) - 1) << (num15 & 31));
                }
            }
            for (num18 = 0; (num18 < list1.Count); ++num18)
            {
                item2 = ((Item) list1[num18]);
                data4 = item2.ItemData;
                num19 = item2.Z;
                num20 = (num19 + data4.CalcHeight);
                if ((num20 == num19) && !data4.Surface)
                {
                    ++num20;
                }
                num21 = (num19 - num3);
                num22 = (num20 - num3);
                if ((num21 < 20) && (num22 >= 0))
                {
                    if (num21 < 0)
                    {
                        num21 = 0;
                    }
                    if (num22 > 19)
                    {
                        num22 = 19;
                    }
                    num23 = (num22 - num21);
                    Item.m_OpenSlots &= ~(((1 << (num23 & 31)) - 1) << (num21 & 31));
                }
            }
            ItemData data7 = this.ItemData;
            int num24 = data7.Height;
            if (num24 == 0)
            {
                ++num24;
            }
            if (num24 > 30)
            {
                num24 = 30;
            }
            int num25 = ((1 << (num24 & 31)) - 1);
            bool flag2 = false;
            for (num26 = 0; (num26 < 20); ++num26)
            {
                if ((num26 + num24) > 20)
                {
                    num25 = (num25 >> 1);
                }
                flag2 = (((Item.m_OpenSlots >> (num26 & 31)) & num25) == num25);
                if (flag2)
                {
                    num3 += num26;
                    break;
                }
            }
            if (!flag2)
            {
                return false;
            }
            data7 = this.ItemData;
            num24 = data7.Height;
            if (num24 == 0)
            {
                ++num24;
            }
            if ((num6 > num3) && ((num3 + num24) > num5))
            {
                return false;
            }
            if ((((flag1 & TileFlag.Impassable) != TileFlag.None) && (num6 > num11)) && ((num3 + num24) > num5))
            {
                return false;
            }
            for (num27 = 0; (num27 < tileArray1.Length); ++num27)
            {
                tile4 = tileArray1[num27];
                data5 = TileData.ItemTable[(tile4.ID & 16383)];
                num28 = tile4.Z;
                num29 = (num28 + data5.CalcHeight);
                if ((num29 > num3) && ((num3 + num24) > num28))
                {
                    return false;
                }
                if ((data5.Surface || data5.Impassable) && ((num29 > num11) && ((num3 + num24) > num28)))
                {
                    return false;
                }
            }
            for (num30 = 0; (num30 < list1.Count); ++num30)
            {
                item3 = ((Item) list1[num30]);
                data6 = item3.ItemData;
                num31 = item3.Z;
                data6.CalcHeight;
                if (((item3.Z + data6.CalcHeight) > num3) && ((num3 + num24) > item3.Z))
                {
                    return false;
                }
            }
            p = new Point3D(num1, num2, num3);
            if (!from.InLOS(new Point3D(num1, num2, (num3 + 1))))
            {
                return false;
            }
            if (!from.OnDroppedItemToWorld(this, p))
            {
                return false;
            }
            if (!this.OnDroppedToWorld(from, p))
            {
                return false;
            }
            int num32 = this.GetDropSound();
            this.MoveToWorld(p, from.Map);
            from.SendSound(((num32 == -1) ? 66 : num32), this.GetWorldLocation());
            return true;
        }

        public virtual Item Dupe(int amount)
        {
            return this.Dupe(new Item(), amount);
        }

        public virtual Item Dupe(Item item, int amount)
        {
            item.Visible = this.Visible;
            item.Movable = this.Movable;
            item.LootType = this.LootType;
            item.Direction = this.Direction;
            item.Hue = this.Hue;
            item.ItemID = this.ItemID;
            item.Location = this.Location;
            item.Layer = this.Layer;
            item.Name = this.Name;
            item.Weight = this.Weight;
            item.Amount = amount;
            item.Map = this.Map;
            if ((this.Parent is Mobile))
            {
                ((Mobile) this.Parent).AddItem(item);
            }
            else if ((this.Parent is Item))
            {
                ((Item) this.Parent).AddItem(item);
            }
            item.Delta(ItemDelta.Update);
            return item;
        }

        public virtual void FreeCache()
        {
            this.m_RemovePacket = null;
            this.m_WorldPacket = null;
            this.m_OPLPacket = null;
            this.m_PropertyList = null;
        }

        public BounceInfo GetBounce()
        {
            return this.m_Bounce;
        }

        public virtual void GetChildProperties(ObjectPropertyList list, Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).GetChildProperties(list, item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).GetChildProperties(list, item);
            }
        }

        public IPooledEnumerable GetClientsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            if (this.m_Parent == null)
            {
                return map1.GetClientsInRange(this.m_Location, range);
            }
            return map1.GetClientsInRange(this.GetWorldLocation(), range);
        }

        public virtual void GetContextMenuEntries(Mobile from, ArrayList list)
        {
        }

        public virtual int GetDropSound()
        {
            return -1;
        }

        private bool GetFlag(ImplFlag flag)
        {
            return ((this.m_Flags & flag) != ((byte) 0));
        }

        public Rectangle2D GetGraphicBounds()
        {
            int num2;
            int num1 = this.m_ItemID;
            bool flag1 = (this.m_Amount > 1);
            if ((num1 >= 3818) && (num1 <= 3826))
            {
                num2 = ((num1 - 3818) / 3);
                num2 *= 3;
                num2 += 3818;
                flag1 = false;
                if (this.m_Amount <= 1)
                {
                    num1 = num2;
                }
                else if (this.m_Amount <= 5)
                {
                    num1 = (num2 + 1);
                }
                else
                {
                    num1 = (num2 + 2);
                }
            }
            Rectangle2D rectangled1 = ItemBounds.Table[(num1 & 16383)];
            if (flag1)
            {
                rectangled1.Set(rectangled1.X, rectangled1.Y, (rectangled1.Width + 5), (rectangled1.Height + 5));
            }
            return rectangled1;
        }

        public IPooledEnumerable GetItemsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            if (this.m_Parent == null)
            {
                return map1.GetItemsInRange(this.m_Location, range);
            }
            return map1.GetItemsInRange(this.GetWorldLocation(), range);
        }

        public virtual int GetLiftSound(Mobile from)
        {
            return 87;
        }

        public virtual int GetMaxUpdateRange()
        {
            return 18;
        }

        public IPooledEnumerable GetMobilesInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            if (this.m_Parent == null)
            {
                return map1.GetMobilesInRange(this.m_Location, range);
            }
            return map1.GetMobilesInRange(this.GetWorldLocation(), range);
        }

        public IPooledEnumerable GetObjectsInRange(int range)
        {
            Map map1 = this.m_Map;
            if (map1 == null)
            {
                return Map.NullEnumerable.Instance;
            }
            if (this.m_Parent == null)
            {
                return map1.GetObjectsInRange(this.m_Location, range);
            }
            return map1.GetObjectsInRange(this.GetWorldLocation(), range);
        }

        public virtual int GetPacketFlags()
        {
            int num1 = 0;
            if (!this.Visible)
            {
                num1 |= 128;
            }
            if (!this.Movable && !this.ForceShowProperties)
            {
                return num1;
            }
            return (num1 | 32);
        }

        public virtual void GetProperties(ObjectPropertyList list)
        {
            this.AddNameProperties(list);
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).GetChildProperties(list, this);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).GetChildProperties(list, this);
            }
        }

        public bool GetSavedFlag(int flag)
        {
            return ((this.m_SavedFlags & flag) != 0);
        }

        private static bool GetSaveFlag(Server.Item.SaveFlag flags, Server.Item.SaveFlag toGet)
        {
            return ((flags & toGet) != Server.Item.SaveFlag.None);
        }

        public SecureTradeContainer GetSecureTradeCont()
        {
            object obj1;
            for (obj1 = this; (obj1 is Item); obj1 = ((Item) obj1).m_Parent)
            {
                if ((obj1 is SecureTradeContainer))
                {
                    return ((SecureTradeContainer) obj1);
                }
            }
            return null;
        }

        public Point3D GetSurfaceTop()
        {
            ItemData data1;
            object obj1 = this.RootParent;
            if (obj1 == null)
            {
                data1 = this.ItemData;
                return new Point3D(this.m_Location.m_X, this.m_Location.m_Y, (this.m_Location.m_Z + (data1.Surface ? (data1 = this.ItemData).CalcHeight : 0)));
            }
            return ((IEntity) obj1).Location;
        }

        public bool GetTempFlag(int flag)
        {
            return ((this.m_TempFlags & flag) != 0);
        }

        public virtual int GetUpdateRange(Mobile m)
        {
            return 18;
        }

        public Point3D GetWorldLocation()
        {
            object obj1 = this.RootParent;
            if (obj1 == null)
            {
                return this.m_Location;
            }
            return ((IEntity) obj1).Location;
        }

        public Point3D GetWorldTop()
        {
            ItemData data1;
            object obj1 = this.RootParent;
            if (obj1 == null)
            {
                data1 = this.ItemData;
                return new Point3D(this.m_Location.m_X, this.m_Location.m_Y, (this.m_Location.m_Z + data1.CalcHeight));
            }
            return ((IEntity) obj1).Location;
        }

        public void Internalize()
        {
            this.MoveToWorld(Point3D.Zero, Map.Internal);
        }

        public void InvalidateProperties()
        {
            ObjectPropertyList list1;
            ObjectPropertyList list2;
            if (!Core.AOS)
            {
                return;
            }
            if ((this.m_Map != null) && (this.m_Map != Map.Internal))
            {
                list1 = this.m_PropertyList;
                this.m_PropertyList = null;
                list2 = this.PropertyList;
                if ((list1 != null) && (list1.Hash == list2.Hash))
                {
                    return;
                }
                this.m_OPLPacket = null;
                this.Delta(ItemDelta.Properties);
                return;
            }
            this.m_PropertyList = null;
            this.m_OPLPacket = null;
        }

        public virtual bool IsAccessibleTo(Mobile check)
        {
            if ((this.m_Parent is Item))
            {
                return ((Item) this.m_Parent).IsAccessibleTo(check);
            }
            Region region1 = Region.Find(this.GetWorldLocation(), this.m_Map);
            return region1.CheckAccessibility(this, check);
        }

        public bool IsChildOf(object o)
        {
            return this.IsChildOf(o, false);
        }

        public bool IsChildOf(object o, bool allowNull)
        {
            Item item1;
            object obj1 = this.m_Parent;
            if (((obj1 == null) || (o == null)) && !allowNull)
            {
                return false;
            }
            if (obj1 != o)
            {
                goto Label_0034;
            }
            return true;
        Label_0018:
            item1 = ((Item) obj1);
            if (item1.m_Parent == null)
            {
                goto Label_003C;
            }
            obj1 = item1.m_Parent;
            if (obj1 == o)
            {
                return true;
            }
        Label_0034:
            if ((obj1 is Item))
            {
                goto Label_0018;
            }
        Label_003C:
            return false;
        }

        public virtual bool IsStandardLoot()
        {
            if (Mobile.InsuranceEnabled && this.Insured)
            {
                return false;
            }
            if (this.m_BlessedFor != null)
            {
                return false;
            }
            return (this.m_LootType == LootType.Regular);
        }

        public virtual void LabelLootTypeTo(Mobile to)
        {
            if (this.m_LootType == LootType.Blessed)
            {
                this.LabelTo(to, 1041362);
                return;
            }
            if (this.m_LootType == LootType.Cursed)
            {
                this.LabelTo(to, "(cursed)");
            }
        }

        public void LabelTo(Mobile to, int number)
        {
            to.Send(new MessageLocalized(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, number, "", ""));
        }

        public void LabelTo(Mobile to, string text)
        {
            to.Send(new UnicodeMessage(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, "ENU", "", text));
        }

        public void LabelTo(Mobile to, int number, string args)
        {
            to.Send(new MessageLocalized(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, number, "", args));
        }

        public void LabelTo(Mobile to, string format, params object[] args)
        {
            this.LabelTo(to, string.Format(format, args));
        }

        public void LabelToAffix(Mobile to, int number, AffixType type, string affix)
        {
            to.Send(new MessageLocalizedAffix(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, number, "", type, affix, ""));
        }

        public void LabelToAffix(Mobile to, int number, AffixType type, string affix, string args)
        {
            to.Send(new MessageLocalizedAffix(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, number, "", type, affix, args));
        }

        public virtual void MoveToWorld(Point3D location)
        {
            this.MoveToWorld(location, this.m_Map);
        }

        public void MoveToWorld(Point3D location, Map map)
        {
            Map map1;
            Packet packet1;
            IPooledEnumerable enumerable1;
            Mobile mobile1;
            int num1;
            IPooledEnumerable enumerable2;
            Mobile mobile2;
            IPooledEnumerable enumerable3;
            Packet packet2;
            Mobile mobile3;
            Point3D pointd3;
            Mobile mobile4;
            if (this.Deleted)
            {
                return;
            }
            Point3D pointd1 = this.GetWorldLocation();
            Point3D pointd2 = this.m_Location;
            this.SetLastMoved();
            if ((this.Parent is Mobile))
            {
                ((Mobile) this.Parent).RemoveItem(this);
            }
            else if ((this.Parent is Item))
            {
                ((Item) this.Parent).RemoveItem(this);
            }
            if (this.m_Map != map)
            {
                map1 = this.m_Map;
                if (this.m_Map != null)
                {
                    this.m_Map.OnLeave(this);
                    if (pointd1.m_X != 0)
                    {
                        packet1 = null;
                        enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
                        foreach (NetState state1 in enumerable1)
                        {
                            mobile1 = state1.Mobile;
                            if (mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                            {
                                if (packet1 == null)
                                {
                                    packet1 = this.RemovePacket;
                                }
                                state1.Send(packet1);
                            }
                        }
                        enumerable1.Free();
                    }
                }
                for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
                {
                    ((Item) this.m_Items[num1]).Map = map;
                }
                this.m_Location = location;
                this.OnLocationChange(pointd2);
                this.m_WorldPacket = null;
                this.m_Map = map;
                if (this.m_Map != null)
                {
                    this.m_Map.OnEnter(this);
                }
                this.OnMapChange();
                if (this.m_Map != null)
                {
                    enumerable2 = this.m_Map.GetClientsInRange(this.m_Location, this.GetMaxUpdateRange());
                    foreach (NetState state2 in enumerable2)
                    {
                        mobile2 = state2.Mobile;
                        if (mobile2.CanSee(this) && mobile2.InRange(this.m_Location, this.GetUpdateRange(mobile2)))
                        {
                            this.SendInfoTo(state2);
                        }
                    }
                    enumerable2.Free();
                }
                this.RemDelta(ItemDelta.Update);
                if ((map1 != null) && (map1 != Map.Internal))
                {
                    return;
                }
                this.InvalidateProperties();
                return;
            }
            if (this.m_Map != null)
            {
                if (pointd1.m_X != 0)
                {
                    packet2 = null;
                    enumerable3 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
                    foreach (NetState state3 in enumerable3)
                    {
                        mobile3 = state3.Mobile;
                        if (!mobile3.InRange(location, this.GetUpdateRange(mobile3)))
                        {
                            if (packet2 == null)
                            {
                                packet2 = this.RemovePacket;
                            }
                            state3.Send(packet2);
                        }
                    }
                    enumerable3.Free();
                }
                pointd3 = this.m_Location;
                this.m_Location = location;
                this.OnLocationChange(pointd2);
                this.m_WorldPacket = null;
                enumerable3 = this.m_Map.GetClientsInRange(this.m_Location, this.GetMaxUpdateRange());
                foreach (NetState state4 in enumerable3)
                {
                    mobile4 = state4.Mobile;
                    if (mobile4.CanSee(this) && mobile4.InRange(this.m_Location, this.GetUpdateRange(mobile4)))
                    {
                        this.SendInfoTo(state4);
                    }
                }
                enumerable3.Free();
                this.m_Map.OnMove(pointd3, this);
                this.RemDelta(ItemDelta.Update);
                return;
            }
            this.Map = map;
            this.Location = location;
        }

        public virtual void OnAdded(object parent)
        {
        }

        public virtual void OnAfterDelete()
        {
        }

        protected virtual void OnAmountChange(int oldValue)
        {
        }

        public virtual void OnAosSingleClick(Mobile from)
        {
            ObjectPropertyList list1 = this.PropertyList;
            if (list1.Header > 0)
            {
                from.Send(new MessageLocalized(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, list1.Header, this.m_Name, list1.HeaderArgs));
            }
        }

        public virtual bool OnDecay()
        {
            if ((this.Decays && (this.Parent == null)) && (this.Map != Map.Internal))
            {
                return Region.Find(this.Location, this.Map).OnDecay(this);
            }
            return false;
        }

        public virtual void OnDelete()
        {
        }

        public virtual void OnDoubleClick(Mobile from)
        {
        }

        public virtual void OnDoubleClickCantSee(Mobile from)
        {
        }

        public virtual void OnDoubleClickDead(Mobile from)
        {
            from.LocalOverheadMessage(MessageType.Regular, 946, 1019048);
        }

        public virtual void OnDoubleClickNotAccessible(Mobile from)
        {
            from.SendLocalizedMessage(500447);
        }

        public virtual void OnDoubleClickOutOfRange(Mobile from)
        {
        }

        public virtual void OnDoubleClickSecureTrade(Mobile from)
        {
            from.SendLocalizedMessage(500447);
        }

        public virtual bool OnDragDrop(Mobile from, Item dropped)
        {
            if ((this.Parent is Container))
            {
                return ((Container) this.Parent).OnStackAttempt(from, this, dropped);
            }
            return this.StackWith(from, dropped);
        }

        public virtual bool OnDragLift(Mobile from)
        {
            return true;
        }

        public virtual bool OnDroppedInto(Mobile from, Container target, Point3D p)
        {
            if (!from.OnDroppedItemInto(this, target, p))
            {
                return false;
            }
            return target.OnDragDropInto(from, this, p);
        }

        public virtual bool OnDroppedOnto(Mobile from, Item target)
        {
            if (((this.Deleted || from.Deleted) || (target.Deleted || (from.Map != target.Map))) || ((from.Map == null) || (target.Map == null)))
            {
                return false;
            }
            if ((from.AccessLevel < AccessLevel.GameMaster) && !from.InRange(target.GetWorldLocation(), 2))
            {
                return false;
            }
            if (!from.CanSee(target) || !from.InLOS(target))
            {
                return false;
            }
            if (!target.IsAccessibleTo(from))
            {
                return false;
            }
            if (!from.OnDroppedItemOnto(this, target))
            {
                return false;
            }
            return target.OnDragDrop(from, this);
        }

        public virtual bool OnDroppedToMobile(Mobile from, Mobile target)
        {
            return true;
        }

        public virtual bool OnDroppedToWorld(Mobile from, Point3D p)
        {
            return true;
        }

        public virtual bool OnEquip(Mobile from)
        {
            return true;
        }

        public virtual void OnHelpRequest(Mobile from)
        {
        }

        public virtual DeathMoveResult OnInventoryDeath(Mobile parent)
        {
            if (!this.Movable)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            if (parent.KeepsItemsOnDeath)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            if (this.CheckBlessed(parent))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            if (this.CheckNewbied() && (parent.Kills < 5))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            return DeathMoveResult.MoveToCorpse;
        }

        public virtual void OnItemAdded(Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnSubItemAdded(item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnSubItemAdded(item);
            }
        }

        public virtual void OnItemLifted(Mobile from, Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnItemLifted(from, item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnItemLifted(from, item);
            }
        }

        public virtual void OnItemRemoved(Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnSubItemRemoved(item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnSubItemRemoved(item);
            }
        }

        public virtual void OnItemUsed(Mobile from, Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnItemUsed(from, item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnItemUsed(from, item);
            }
        }

        public virtual void OnLocationChange(Point3D oldLocation)
        {
        }

        public virtual void OnMapChange()
        {
        }

        public virtual void OnMovement(Mobile m, Point3D oldLocation)
        {
        }

        public virtual bool OnMoveOff(Mobile m)
        {
            return true;
        }

        public virtual bool OnMoveOver(Mobile m)
        {
            return true;
        }

        public virtual DeathMoveResult OnParentDeath(Mobile parent)
        {
            if (!this.Movable)
            {
                return DeathMoveResult.RemainEquiped;
            }
            if (parent.KeepsItemsOnDeath)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            if (this.CheckBlessed(parent))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            if (this.CheckNewbied() && (parent.Kills < 5))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            return DeathMoveResult.MoveToCorpse;
        }

        public virtual void OnParentDeleted(object parent)
        {
            this.Delete();
        }

        public virtual void OnRemoved(object parent)
        {
        }

        public virtual void OnSectorActivate()
        {
        }

        public virtual void OnSectorDeactivate()
        {
        }

        public virtual void OnSecureTrade(Mobile from, Mobile to, Mobile newOwner, bool accepted)
        {
        }

        public virtual void OnSingleClick(Mobile from)
        {
            if (this.Deleted || !from.CanSee(this))
            {
                return;
            }
            if (this.DisplayLootType)
            {
                this.LabelLootTypeTo(from);
            }
            NetState state1 = from.NetState;
            if (state1 == null)
            {
                return;
            }
            if (this.m_Name == null)
            {
                if (this.m_Amount <= 1)
                {
                    state1.Send(new MessageLocalized(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, this.LabelNumber, "", ""));
                    return;
                }
                state1.Send(new MessageLocalizedAffix(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, this.LabelNumber, "", AffixType.Append, string.Format(" : {0}", this.m_Amount), ""));
                return;
            }
            state1.Send(new UnicodeMessage(this.m_Serial, this.m_ItemID, MessageType.Label, 946, 3, "ENU", "", this.m_Name + ((this.m_Amount > 1) ? " : " + this.m_Amount : "")));
        }

        public virtual void OnSingleClickContained(Mobile from, Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnSingleClickContained(from, item);
            }
        }

        public virtual void OnSnoop(Mobile from)
        {
        }

        public virtual void OnSpeech(SpeechEventArgs e)
        {
        }

        public virtual void OnSubItemAdded(Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnSubItemAdded(item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnSubItemAdded(item);
            }
        }

        public virtual void OnSubItemRemoved(Item item)
        {
            if ((this.m_Parent is Item))
            {
                ((Item) this.m_Parent).OnSubItemRemoved(item);
                return;
            }
            if ((this.m_Parent is Mobile))
            {
                ((Mobile) this.m_Parent).OnSubItemRemoved(item);
            }
        }

        public void ProcessDelta()
        {
            Packet packet1;
            Point3D pointd1;
            Mobile mobile1;
            Mobile mobile2;
            NetState state1;
            SecureTradeContainer container2;
            SecureTrade trade1;
            Mobile mobile3;
            NetState state2;
            ArrayList list1;
            int num1;
            Mobile mobile4;
            int num2;
            NetState state3;
            Packet packet2;
            Point3D pointd2;
            IPooledEnumerable enumerable1;
            Mobile mobile5;
            Packet packet3;
            Point3D pointd3;
            IPooledEnumerable enumerable2;
            Mobile mobile6;
            Mobile mobile7;
            ItemDelta delta1 = this.m_DeltaFlags;
            this.SetFlag(16, false);
            this.m_DeltaFlags = ItemDelta.None;
            Map map1 = this.m_Map;
            if ((map1 == null) || this.Deleted)
            {
                return;
            }
            bool flag1 = (!ObjectPropertyList.Enabled ? false : ((delta1 & ItemDelta.Properties) != ItemDelta.None));
            Container container1 = (this.m_Parent as Container);
            if (((container1 != null) && !container1.IsPublicContainer) && ((delta1 & ItemDelta.Update) != ItemDelta.None))
            {
                packet1 = null;
                pointd1 = this.GetWorldLocation();
                mobile1 = (container1.RootParent as Mobile);
                mobile2 = null;
                if (mobile1 != null)
                {
                    state1 = mobile1.NetState;
                    if (((state1 != null) && mobile1.CanSee(this)) && mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                    {
                        if (packet1 == null)
                        {
                            packet1 = new ContainerContentUpdate(this);
                        }
                        state1.Send(packet1);
                        if (ObjectPropertyList.Enabled)
                        {
                            state1.Send(this.OPLPacket);
                        }
                    }
                }
                container2 = this.GetSecureTradeCont();
                if (container2 != null)
                {
                    trade1 = container2.Trade;
                    if (trade1 != null)
                    {
                        mobile3 = trade1.From.Mobile;
                        if ((mobile3 != null) && (mobile3 != mobile1))
                        {
                            mobile2 = mobile3;
                        }
                        mobile3 = trade1.To.Mobile;
                        if ((mobile3 != null) && (mobile3 != mobile1))
                        {
                            mobile2 = mobile3;
                        }
                        if (mobile2 != null)
                        {
                            state2 = mobile2.NetState;
                            if (((state2 != null) && mobile2.CanSee(this)) && mobile2.InRange(pointd1, this.GetUpdateRange(mobile2)))
                            {
                                if (packet1 == null)
                                {
                                    packet1 = new ContainerContentUpdate(this);
                                }
                                state2.Send(packet1);
                                if (ObjectPropertyList.Enabled)
                                {
                                    state2.Send(this.OPLPacket);
                                }
                            }
                        }
                    }
                }
                list1 = container1.Openers;
                if (list1 == null)
                {
                    return;
                }
                for (num1 = 0; (num1 < list1.Count); ++num1)
                {
                    mobile4 = ((Mobile) list1[num1]);
                    num2 = this.GetUpdateRange(mobile4);
                    if ((mobile4.Map != map1) || !mobile4.InRange(pointd1, num2))
                    {
                        list1.RemoveAt(num1--);
                    }
                    else if ((mobile4 != mobile1) && (mobile4 != mobile2))
                    {
                        state3 = mobile4.NetState;
                        if ((state3 != null) && mobile4.CanSee(this))
                        {
                            if (packet1 == null)
                            {
                                packet1 = new ContainerContentUpdate(this);
                            }
                            state3.Send(packet1);
                            if (ObjectPropertyList.Enabled)
                            {
                                state3.Send(this.OPLPacket);
                            }
                        }
                    }
                }
                if (list1.Count == 0)
                {
                    container1.Openers = null;
                }
                return;
            }
            if ((delta1 & ItemDelta.Update) != ItemDelta.None)
            {
                packet2 = null;
                pointd2 = this.GetWorldLocation();
                enumerable1 = map1.GetClientsInRange(pointd2, this.GetMaxUpdateRange());
                foreach (NetState state4 in enumerable1)
                {
                    mobile5 = state4.Mobile;
                    if (mobile5.CanSee(this) && mobile5.InRange(pointd2, this.GetUpdateRange(mobile5)))
                    {
                        if (this.m_Parent == null)
                        {
                            this.SendInfoTo(state4);
                            continue;
                        }
                        if (packet2 == null)
                        {
                            if ((this.m_Parent is Item))
                            {
                                packet2 = new ContainerContentUpdate(this);
                            }
                            else if ((this.m_Parent is Mobile))
                            {
                                packet2 = new EquipUpdate(this);
                            }
                        }
                        state4.Send(packet2);
                        if (ObjectPropertyList.Enabled)
                        {
                            state4.Send(this.OPLPacket);
                        }
                    }
                }
                enumerable1.Free();
                flag1 = false;
            }
            else if (((delta1 & ItemDelta.EquipOnly) != ItemDelta.None) && (this.m_Parent is Mobile))
            {
                packet3 = null;
                pointd3 = this.GetWorldLocation();
                enumerable2 = map1.GetClientsInRange(pointd3, this.GetMaxUpdateRange());
                foreach (NetState state5 in enumerable2)
                {
                    mobile6 = state5.Mobile;
                    if (mobile6.CanSee(this) && mobile6.InRange(pointd3, this.GetUpdateRange(mobile6)))
                    {
                        if (packet3 == null)
                        {
                            packet3 = new EquipUpdate(this);
                        }
                        state5.Send(packet3);
                        if (ObjectPropertyList.Enabled)
                        {
                            state5.Send(this.OPLPacket);
                        }
                    }
                }
                enumerable2.Free();
                flag1 = false;
            }
            if (!flag1)
            {
                return;
            }
            Point3D pointd4 = this.GetWorldLocation();
            IPooledEnumerable enumerable3 = map1.GetClientsInRange(pointd4, this.GetMaxUpdateRange());
            foreach (NetState state6 in enumerable3)
            {
                mobile7 = state6.Mobile;
                if (mobile7.CanSee(this) && mobile7.InRange(pointd4, this.GetUpdateRange(mobile7)))
                {
                    state6.Send(this.OPLPacket);
                }
            }
            enumerable3.Free();
        }

        public static void ProcessDeltaQueue()
        {
            int num2;
            int num1 = Item.m_DeltaQueue.Count;
            for (num2 = 0; (num2 < Item.m_DeltaQueue.Count); ++num2)
            {
                ((Item) Item.m_DeltaQueue[num2]).ProcessDelta();
                if (num2 >= num1)
                {
                    break;
                }
            }
            if (Item.m_DeltaQueue.Count > 0)
            {
                Item.m_DeltaQueue.Clear();
            }
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number)
        {
            this.PublicOverheadMessage(type, hue, number, "");
        }

        public void PublicOverheadMessage(MessageType type, int hue, bool ascii, string text)
        {
            Mobile mobile1;
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            Point3D pointd1 = this.GetWorldLocation();
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
            foreach (NetState state1 in enumerable1)
            {
                mobile1 = state1.Mobile;
                if (mobile1.CanSee(this) && mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                {
                    if (packet1 == null)
                    {
                        if (ascii)
                        {
                            packet1 = new AsciiMessage(this.m_Serial, this.m_ItemID, type, hue, 3, this.m_Name, text);
                        }
                        else
                        {
                            packet1 = new UnicodeMessage(this.m_Serial, this.m_ItemID, type, hue, 3, "ENU", this.m_Name, text);
                        }
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void PublicOverheadMessage(MessageType type, int hue, int number, string args)
        {
            Mobile mobile1;
            if (this.m_Map == null)
            {
                return;
            }
            Packet packet1 = null;
            Point3D pointd1 = this.GetWorldLocation();
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
            foreach (NetState state1 in enumerable1)
            {
                mobile1 = state1.Mobile;
                if (mobile1.CanSee(this) && mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                {
                    if (packet1 == null)
                    {
                        packet1 = new MessageLocalized(this.m_Serial, this.m_ItemID, type, hue, 3, number, this.m_Name, args);
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public void RecordBounce()
        {
            this.m_Bounce = new BounceInfo(this);
        }

        public void RemDelta(ItemDelta flags)
        {
            this.m_DeltaFlags &= ~flags;
            if (this.GetFlag(16) && (this.m_DeltaFlags == ItemDelta.None))
            {
                this.SetFlag(16, false);
                Item.m_DeltaQueue.Remove(this);
            }
        }

        public virtual void RemoveItem(Item item)
        {
            if (!this.m_Items.Contains(item))
            {
                return;
            }
            item.SendRemovePacket();
            int num1 = this.m_Items.Count;
            this.m_Items.Remove(item);
            this.TotalItems = ((((this.TotalItems - num1) + this.m_Items.Count) - item.TotalItems) + (item.IsVirtualItem ? 1 : 0));
            this.TotalWeight -= (item.TotalWeight + item.PileWeight);
            this.TotalGold -= item.TotalGold;
            item.Parent = null;
            item.OnRemoved(this);
            this.OnItemRemoved(item);
        }

        public virtual void ScissorHelper(Mobile from, Item newItem, int amountPerOldItem)
        {
            this.ScissorHelper(from, newItem, amountPerOldItem, true);
        }

        public virtual void ScissorHelper(Mobile from, Item newItem, int amountPerOldItem, bool carryHue)
        {
            int num1 = this.Amount;
            if (num1 > (60000 / amountPerOldItem))
            {
                num1 = (60000 / amountPerOldItem);
            }
            this.Amount -= num1;
            int num2 = this.Hue;
            Map map1 = this.Map;
            object obj1 = this.m_Parent;
            Point3D pointd1 = this.GetWorldLocation();
            LootType type1 = this.LootType;
            if (this.Amount == 0)
            {
                this.Delete();
            }
            newItem.Amount = (num1 * amountPerOldItem);
            if (carryHue)
            {
                newItem.Hue = num2;
            }
            if (Item.m_ScissorCopyLootType)
            {
                newItem.LootType = type1;
            }
            if (!(obj1 is Container) || !((Container) obj1).TryDropItem(from, newItem, false))
            {
                newItem.MoveToWorld(pointd1, map1);
            }
        }

        public virtual void SendInfoTo(NetState state)
        {
            state.Send(this.WorldPacket);
            if (ObjectPropertyList.Enabled)
            {
                state.Send(this.OPLPacket);
            }
        }

        public void SendLocalizedMessageTo(Mobile to, int number)
        {
            if (!this.Deleted && to.CanSee(this))
            {
                to.Send(new MessageLocalized(this.Serial, this.ItemID, MessageType.Regular, 946, 3, number, "", ""));
            }
        }

        public void SendLocalizedMessageTo(Mobile to, int number, string args)
        {
            if (!this.Deleted && to.CanSee(this))
            {
                to.Send(new MessageLocalized(this.Serial, this.ItemID, MessageType.Regular, 946, 3, number, "", args));
            }
        }

        public void SendLocalizedMessageTo(Mobile to, int number, AffixType affixType, string affix, string args)
        {
            if (!this.Deleted && to.CanSee(this))
            {
                to.Send(new MessageLocalizedAffix(this.Serial, this.ItemID, MessageType.Regular, 946, 3, number, "", affixType, affix, args));
            }
        }

        public virtual void SendPropertiesTo(Mobile from)
        {
            from.Send(this.PropertyList);
        }

        public void SendRemovePacket()
        {
            Mobile mobile1;
            if (this.Deleted || (this.m_Map == null))
            {
                return;
            }
            Packet packet1 = null;
            Point3D pointd1 = this.GetWorldLocation();
            IPooledEnumerable enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
            foreach (NetState state1 in enumerable1)
            {
                mobile1 = state1.Mobile;
                if (mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                {
                    if (packet1 == null)
                    {
                        packet1 = this.RemovePacket;
                    }
                    state1.Send(packet1);
                }
            }
            enumerable1.Free();
        }

        public virtual void Serialize(GenericWriter writer)
        {
            TimeSpan span1;
            double num6;
            writer.Write(7);
            Server.Item.SaveFlag flag1 = Server.Item.SaveFlag.None;
            int num1 = this.m_Location.m_X;
            int num2 = this.m_Location.m_Y;
            int num3 = this.m_Location.m_Z;
            if (((num1 != 0) || (num2 != 0)) || (num3 != 0))
            {
                if ((((num1 >= -32768) && (num1 <= 32767)) && ((num2 >= -32768) && (num2 <= 32767))) && ((num3 >= -128) && (num3 <= 127)))
                {
                    if ((num1 != 0) || (num2 != 0))
                    {
                        if (((num1 >= 0) && (num1 <= 255)) && ((num2 >= 0) && (num2 <= 255)))
                        {
                            flag1 |= Server.Item.SaveFlag.LocationByteXY;
                        }
                        else
                        {
                            flag1 |= Server.Item.SaveFlag.LocationShortXY;
                        }
                    }
                    if (num3 != 0)
                    {
                        flag1 |= Server.Item.SaveFlag.LocationSByteZ;
                    }
                }
                else
                {
                    flag1 |= Server.Item.SaveFlag.LocationFull;
                }
            }
            if (this.m_Direction != Direction.North)
            {
                flag1 |= Server.Item.SaveFlag.Direction;
            }
            if (this.m_Bounce != null)
            {
                flag1 |= Server.Item.SaveFlag.Bounce;
            }
            if (this.m_LootType != LootType.Regular)
            {
                flag1 |= Server.Item.SaveFlag.LootType;
            }
            if (this.m_ItemID != 0)
            {
                flag1 |= Server.Item.SaveFlag.ItemID;
            }
            if (this.m_Hue != 0)
            {
                flag1 |= Server.Item.SaveFlag.Hue;
            }
            if (this.m_Amount != 1)
            {
                flag1 |= Server.Item.SaveFlag.Amount;
            }
            if (this.m_Layer != Layer.Invalid)
            {
                flag1 |= Server.Item.SaveFlag.Layer;
            }
            if (this.m_Name != null)
            {
                flag1 |= Server.Item.SaveFlag.Name;
            }
            if (this.m_Parent != null)
            {
                flag1 |= Server.Item.SaveFlag.Parent;
            }
            if ((this.m_Items != null) && (this.m_Items.Count > 0))
            {
                flag1 |= Server.Item.SaveFlag.Items;
            }
            if (this.m_Map != Map.Internal)
            {
                flag1 |= Server.Item.SaveFlag.Map;
            }
            if ((this.m_BlessedFor != null) && !this.m_BlessedFor.Deleted)
            {
                flag1 |= Server.Item.SaveFlag.BlessedFor;
            }
            if ((this.m_HeldBy != null) && !this.m_HeldBy.Deleted)
            {
                flag1 |= Server.Item.SaveFlag.HeldBy;
            }
            if (this.m_SavedFlags != 0)
            {
                flag1 |= Server.Item.SaveFlag.SavedFlags;
            }
            if (this.m_Weight == 0)
            {
                flag1 |= Server.Item.SaveFlag.WeightIs0;
            }
            else if (this.m_Weight != 1)
            {
                if (this.m_Weight == ((int) this.m_Weight))
                {
                    flag1 |= Server.Item.SaveFlag.IntWeight;
                }
                else
                {
                    flag1 |= Server.Item.SaveFlag.WeightNot1or0;
                }
            }
            ImplFlag flag2 = (this.m_Flags & 107);
            if (flag2 != 3)
            {
                flag1 |= Server.Item.SaveFlag.ImplFlags;
            }
            writer.Write(((int) flag1));
            long num4 = this.m_LastMovedTime.Ticks;
            DateTime time1 = DateTime.Now;
            long num5 = time1.Ticks;
            try
            {
                span1 = new TimeSpan((num4 - num5));
            }
            catch
            {
                if (num4 < num5)
                {
                    span1 = TimeSpan.MaxValue;
                    goto Label_024B;
                }
                span1 = TimeSpan.MaxValue;
            }
        Label_024B:
            num6 = -span1.TotalMinutes;
            if (num6 < -2147483648)
            {
                num6 = -2147483648;
            }
            else if (num6 > 2147483647)
            {
                num6 = 2147483647;
            }
            writer.WriteEncodedInt(((int) num6));
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Direction))
            {
                writer.Write(((byte) this.m_Direction));
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Bounce))
            {
                BounceInfo.Serialize(this.m_Bounce, writer);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LootType))
            {
                writer.Write(((byte) this.m_LootType));
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationFull))
            {
                writer.WriteEncodedInt(num1);
                writer.WriteEncodedInt(num2);
                writer.WriteEncodedInt(num3);
            }
            else
            {
                if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationByteXY))
                {
                    writer.Write(((byte) num1));
                    writer.Write(((byte) num2));
                }
                else if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationShortXY))
                {
                    writer.Write(((short) num1));
                    writer.Write(((short) num2));
                }
                if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.LocationSByteZ))
                {
                    writer.Write(((sbyte) num3));
                }
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.ItemID))
            {
                writer.WriteEncodedInt(this.m_ItemID);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Hue))
            {
                writer.WriteEncodedInt(this.m_Hue);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Amount))
            {
                writer.WriteEncodedInt(this.m_Amount);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Layer))
            {
                writer.Write(((byte) this.m_Layer));
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Name))
            {
                writer.Write(this.m_Name);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Parent))
            {
                if ((this.m_Parent is Mobile) && !((Mobile) this.m_Parent).Deleted)
                {
                    writer.Write(Serial.op_Implicit(((Mobile) this.m_Parent).Serial));
                }
                else if ((this.m_Parent is Item) && !((Item) this.m_Parent).Deleted)
                {
                    writer.Write(Serial.op_Implicit(((Item) this.m_Parent).Serial));
                }
                else
                {
                    writer.Write(Serial.op_Implicit(Serial.MinusOne));
                }
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Items))
            {
                writer.WriteItemList(this.m_Items, false);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.IntWeight))
            {
                writer.WriteEncodedInt(((int) this.m_Weight));
            }
            else if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.WeightNot1or0))
            {
                writer.Write(this.m_Weight);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.Map))
            {
                writer.Write(this.m_Map);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.ImplFlags))
            {
                writer.WriteEncodedInt(((int) flag2));
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.InsuredFor))
            {
                writer.Write(null);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.BlessedFor))
            {
                writer.Write(this.m_BlessedFor);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.HeldBy))
            {
                writer.Write(this.m_HeldBy);
            }
            if (Item.GetSaveFlag(flag1, Server.Item.SaveFlag.SavedFlags))
            {
                writer.WriteEncodedInt(this.m_SavedFlags);
            }
        }

        private void SetFlag(ImplFlag flag, bool value)
        {
            if (value)
            {
                this.m_Flags |= flag;
                return;
            }
            this.m_Flags &= ~flag;
        }

        public void SetLastMoved()
        {
            this.m_LastMovedTime = DateTime.Now;
        }

        public void SetSavedFlag(int flag, bool value)
        {
            if (value)
            {
                this.m_SavedFlags |= flag;
                return;
            }
            this.m_SavedFlags &= ~flag;
        }

        private static void SetSaveFlag(ref Server.Item.SaveFlag flags, Server.Item.SaveFlag toSet, bool setIf)
        {
            if (setIf)
            {
                flags |= toSet;
            }
        }

        public void SetTempFlag(int flag, bool value)
        {
            if (value)
            {
                this.m_TempFlags |= flag;
                return;
            }
            this.m_TempFlags &= ~flag;
        }

        public void SetTotalGold(int value)
        {
            this.m_TotalGold = value;
        }

        public void SetTotalItems(int value)
        {
            this.m_TotalItems = value;
        }

        public void SetTotalWeight(int value)
        {
            this.m_TotalWeight = value;
        }

        public virtual bool StackWith(Mobile from, Item dropped)
        {
            return this.StackWith(from, dropped, true);
        }

        public virtual bool StackWith(Mobile from, Item dropped, bool playSound)
        {
            int num1;
            if (((this.Stackable && dropped.Stackable) && ((dropped.GetType() == base.GetType()) && (dropped.ItemID == this.ItemID))) && ((dropped.Hue == this.Hue) && ((dropped.Amount + this.Amount) <= 60000)))
            {
                if (this.m_LootType != dropped.m_LootType)
                {
                    this.m_LootType = LootType.Regular;
                }
                this.Amount += dropped.Amount;
                dropped.Delete();
                if (playSound)
                {
                    num1 = this.GetDropSound();
                    if (num1 == -1)
                    {
                        num1 = 66;
                    }
                    from.SendSound(num1, this.GetWorldLocation());
                }
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("0x{0:X} \"{1}\"", this.m_Serial.Value, base.GetType().Name);
        }

        public virtual void UpdateTotals()
        {
            int num1;
            Item item1;
            if (this.m_Items == null)
            {
                return;
            }
            this.m_TotalGold = 0;
            this.m_TotalItems = 0;
            this.m_TotalWeight = 0;
            for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
            {
                item1 = ((Item) this.m_Items[num1]);
                item1.UpdateTotals();
                this.m_TotalGold += item1.TotalGold;
                this.m_TotalItems += item1.TotalItems;
                this.m_TotalWeight += (item1.TotalWeight + item1.PileWeight);
                if (item1.IsVirtualItem)
                {
                    --this.m_TotalItems;
                }
            }
            this.m_TotalItems += this.m_Items.Count;
        }

        public virtual bool VerifyMove(Mobile from)
        {
            return this.Movable;
        }


        // Properties
        [CommandProperty(AccessLevel.GameMaster)]
        public int Amount
        {
            get
            {
                return this.m_Amount;
            }
            set
            {
                Item item1;
                Mobile mobile1;
                int num1 = this.m_Amount;
                if (num1 == value)
                {
                    return;
                }
                int num2 = this.PileWeight;
                this.m_Amount = value;
                this.m_WorldPacket = null;
                if ((this.m_Parent is Item))
                {
                    item1 = ((Item) this.m_Parent);
                    item1.TotalWeight = ((item1.TotalWeight - num2) + this.PileWeight);
                }
                else if ((this.m_Parent is Mobile) && !(this is BankBox))
                {
                    mobile1 = ((Mobile) this.m_Parent);
                    mobile1.TotalWeight = ((mobile1.TotalWeight - num2) + this.PileWeight);
                }
                this.OnAmountChange(num1);
                this.Delta(ItemDelta.Update);
                if ((num1 > 1) || (value > 1))
                {
                    this.InvalidateProperties();
                }
                if (!this.Stackable && (this.m_Amount > 1))
                {
                    Console.WriteLine("Warning: 0x{0:X}: Amount changed for non-stackable item \'{2}\'. ({1})", this.m_Serial.Value, this.m_Amount, base.GetType().Name);
                }
            }
        }

        public Mobile BlessedFor
        {
            get
            {
                return this.m_BlessedFor;
            }
            set
            {
                this.m_BlessedFor = value;
                this.InvalidateProperties();
            }
        }

        public virtual bool BlocksFit
        {
            get
            {
                return false;
            }
        }

        public virtual bool CanTarget
        {
            get
            {
                return true;
            }
        }

        public virtual int ColdResistance
        {
            get
            {
                return 0;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual bool Decays
        {
            get
            {
                if (this.Movable)
                {
                    return this.Visible;
                }
                return false;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual TimeSpan DecayTime
        {
            get
            {
                return Item.m_DDT;
            }
        }

        public static TimeSpan DefaultDecayTime
        {
            get
            {
                return Item.m_DDT;
            }
            set
            {
                Item.m_DDT = value;
            }
        }

        public bool Deleted
        {
            get
            {
                return this.GetFlag(4);
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Direction Direction
        {
            get
            {
                return this.m_Direction;
            }
            set
            {
                if (this.m_Direction != value)
                {
                    this.m_Direction = value;
                    this.m_WorldPacket = null;
                    this.Delta(ItemDelta.Update);
                }
            }
        }

        public virtual bool DisplayLootType
        {
            get
            {
                return true;
            }
        }

        public virtual int EnergyResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual int FireResistance
        {
            get
            {
                return 0;
            }
        }

        public virtual bool ForceShowProperties
        {
            get
            {
                return false;
            }
        }

        public virtual bool HandlesOnMovement
        {
            get
            {
                return false;
            }
        }

        public virtual bool HandlesOnSpeech
        {
            get
            {
                return false;
            }
        }

        public Mobile HeldBy
        {
            get
            {
                return this.m_HeldBy;
            }
            set
            {
                this.m_HeldBy = value;
            }
        }

        [Hue, CommandProperty(AccessLevel.GameMaster)]
        public virtual int Hue
        {
            get
            {
                return this.m_Hue;
            }
            set
            {
                if (this.m_Hue != value)
                {
                    this.m_Hue = value;
                    this.m_WorldPacket = null;
                    this.Delta(ItemDelta.Update);
                }
            }
        }

        public virtual int HuedItemID
        {
            get
            {
                return (this.m_ItemID & 16383);
            }
        }

        public bool InSecureTrade
        {
            get
            {
                return (this.GetSecureTradeCont() != null);
            }
        }

        public bool Insured
        {
            get
            {
                return this.GetFlag(32);
            }
            set
            {
                this.SetFlag(32, value);
                this.InvalidateProperties();
            }
        }

        public bool IsLockedDown
        {
            get
            {
                return this.GetTempFlag(Item.m_LockedDownFlag);
            }
            set
            {
                this.SetTempFlag(Item.m_LockedDownFlag, value);
                this.InvalidateProperties();
            }
        }

        public bool IsSecure
        {
            get
            {
                return this.GetTempFlag(Item.m_SecureFlag);
            }
            set
            {
                this.SetTempFlag(Item.m_SecureFlag, value);
                this.InvalidateProperties();
            }
        }

        public virtual bool IsVirtualItem
        {
            get
            {
                return false;
            }
        }

        public ItemData ItemData
        {
            get
            {
                return TileData.ItemTable[(this.m_ItemID & 16383)];
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual int ItemID
        {
            get
            {
                return this.m_ItemID;
            }
            set
            {
                if (this.m_ItemID != value)
                {
                    this.m_ItemID = value;
                    this.m_WorldPacket = null;
                    this.InvalidateProperties();
                    this.Delta(ItemDelta.Update);
                }
            }
        }

        public ArrayList Items
        {
            get
            {
                return this.m_Items;
            }
        }

        public virtual int LabelNumber
        {
            get
            {
                return (1020000 + (this.m_ItemID & 16383));
            }
        }

        public DateTime LastMoved
        {
            get
            {
                return this.m_LastMovedTime;
            }
            set
            {
                this.m_LastMovedTime = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual Layer Layer
        {
            get
            {
                return this.m_Layer;
            }
            set
            {
                if (this.m_Layer != value)
                {
                    this.m_Layer = value;
                    this.Delta(ItemDelta.EquipOnly);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public LightType Light
        {
            get
            {
                return ((LightType) this.m_Direction);
            }
            set
            {
                if (this.m_Direction != value)
                {
                    this.m_Direction = ((Direction) ((byte) value));
                    this.m_WorldPacket = null;
                    this.Delta(ItemDelta.Update);
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public virtual Point3D Location
        {
            get
            {
                return this.m_Location;
            }
            set
            {
                IPooledEnumerable enumerable1;
                Packet packet1;
                Mobile mobile1;
                Mobile mobile2;
                Point3D pointd1 = this.m_Location;
                if (pointd1 == value)
                {
                    return;
                }
                if (this.m_Map != null)
                {
                    if (this.m_Parent == null)
                    {
                        if (this.m_Location.m_X != 0)
                        {
                            packet1 = null;
                            enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
                            foreach (NetState state1 in enumerable1)
                            {
                                mobile1 = state1.Mobile;
                                if (!mobile1.InRange(value, this.GetUpdateRange(mobile1)))
                                {
                                    if (packet1 == null)
                                    {
                                        packet1 = this.RemovePacket;
                                    }
                                    state1.Send(packet1);
                                }
                            }
                            enumerable1.Free();
                        }
                        this.m_Location = value;
                        this.m_WorldPacket = null;
                        this.SetLastMoved();
                        enumerable1 = this.m_Map.GetClientsInRange(this.m_Location, this.GetMaxUpdateRange());
                        foreach (NetState state2 in enumerable1)
                        {
                            mobile2 = state2.Mobile;
                            if (mobile2.CanSee(this) && mobile2.InRange(this.m_Location, this.GetUpdateRange(mobile2)))
                            {
                                this.SendInfoTo(state2);
                            }
                        }
                        enumerable1.Free();
                        this.RemDelta(ItemDelta.Update);
                    }
                    else if ((this.m_Parent is Item))
                    {
                        this.m_Location = value;
                        this.m_WorldPacket = null;
                        this.Delta(ItemDelta.Update);
                    }
                    else
                    {
                        this.m_Location = value;
                        this.m_WorldPacket = null;
                    }
                    if (this.m_Parent == null)
                    {
                        this.m_Map.OnMove(pointd1, this);
                    }
                }
                else
                {
                    this.m_Location = value;
                    this.m_WorldPacket = null;
                }
                this.OnLocationChange(pointd1);
            }
        }

        public static int LockedDownFlag
        {
            get
            {
                return Item.m_LockedDownFlag;
            }
            set
            {
                Item.m_LockedDownFlag = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public LootType LootType
        {
            get
            {
                return this.m_LootType;
            }
            set
            {
                if (this.m_LootType != value)
                {
                    this.m_LootType = value;
                    if (this.DisplayLootType)
                    {
                        this.InvalidateProperties();
                    }
                }
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public Map Map
        {
            get
            {
                return this.m_Map;
            }
            set
            {
                int num1;
                if (this.m_Map == value)
                {
                    return;
                }
                Map map1 = this.m_Map;
                if (this.m_Map != null)
                {
                    this.m_Map.OnLeave(this);
                    if (this.m_Parent == null)
                    {
                        this.SendRemovePacket();
                    }
                }
                if (this.m_Items == null)
                {
                    throw new Exception(string.Format("Items array is null--are you calling the serialization constructor? Type={0}", base.GetType()));
                }
                for (num1 = 0; (num1 < this.m_Items.Count); ++num1)
                {
                    ((Item) this.m_Items[num1]).Map = value;
                }
                this.m_Map = value;
                if ((this.m_Map != null) && (this.m_Parent == null))
                {
                    this.m_Map.OnEnter(this);
                }
                this.Delta(ItemDelta.Update);
                this.OnMapChange();
                if ((map1 == null) || (map1 == Map.Internal))
                {
                    this.InvalidateProperties();
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Movable
        {
            get
            {
                return this.GetFlag(2);
            }
            set
            {
                if (this.GetFlag(2) != value)
                {
                    this.SetFlag(2, value);
                    this.m_WorldPacket = null;
                    this.Delta(ItemDelta.Update);
                }
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public virtual string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
                this.InvalidateProperties();
            }
        }

        [Obsolete("Use LootType instead", true)]
        public bool Newbied
        {
            get
            {
                return (this.m_LootType == LootType.Newbied);
            }
            set
            {
                this.m_LootType = (value ? LootType.Newbied : LootType.Regular);
            }
        }

        public Packet OPLPacket
        {
            get
            {
                if (this.m_OPLPacket == null)
                {
                    this.m_OPLPacket = new OPLInfo(this.PropertyList);
                }
                return this.m_OPLPacket;
            }
        }

        public virtual object Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                if (this.m_Parent == value)
                {
                    return;
                }
                object obj1 = this.m_Parent;
                this.m_Parent = value;
                if (this.m_Map == null)
                {
                    return;
                }
                if ((obj1 != null) && (this.m_Parent == null))
                {
                    this.m_Map.OnEnter(this);
                    return;
                }
                if (this.m_Parent != null)
                {
                    this.m_Map.OnLeave(this);
                }
            }
        }

        public bool PayedInsurance
        {
            get
            {
                return this.GetFlag(64);
            }
            set
            {
                this.SetFlag(64, value);
            }
        }

        public virtual int PhysicalResistance
        {
            get
            {
                return 0;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public int PileWeight
        {
            get
            {
                return ((int) Math.Ceiling((this.m_Weight * this.m_Amount)));
            }
        }

        public virtual int PoisonResistance
        {
            get
            {
                return 0;
            }
        }

        public ObjectPropertyList PropertyList
        {
            get
            {
                if (this.m_PropertyList == null)
                {
                    this.m_PropertyList = new ObjectPropertyList(this);
                    this.GetProperties(this.m_PropertyList);
                    this.m_PropertyList.Terminate();
                }
                return this.m_PropertyList;
            }
        }

        public Packet RemovePacket
        {
            get
            {
                if (this.m_RemovePacket == null)
                {
                    this.m_RemovePacket = new RemoveItem(this);
                }
                return this.m_RemovePacket;
            }
        }

        public object RootParent
        {
            get
            {
                Item item1;
                object obj1 = this.m_Parent;
                while ((obj1 is Item))
                {
                    item1 = ((Item) obj1);
                    if (item1.m_Parent == null)
                    {
                        return obj1;
                    }
                    obj1 = item1.m_Parent;
                }
                return obj1;
            }
        }

        public int SavedFlags
        {
            get
            {
                return this.m_SavedFlags;
            }
            set
            {
                this.m_SavedFlags = value;
            }
        }

        public static bool ScissorCopyLootType
        {
            get
            {
                return Item.m_ScissorCopyLootType;
            }
            set
            {
                Item.m_ScissorCopyLootType = value;
            }
        }

        public static int SecureFlag
        {
            get
            {
                return Item.m_SecureFlag;
            }
            set
            {
                Item.m_SecureFlag = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Serial Serial
        {
            get
            {
                return this.m_Serial;
            }
        }

        Point3D Server.IEntity.Location
        {
            get
            {
                return this.m_Location;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Stackable
        {
            get
            {
                return this.GetFlag(8);
            }
            set
            {
                this.SetFlag(8, value);
            }
        }

        public int TempFlags
        {
            get
            {
                return this.m_TempFlags;
            }
            set
            {
                this.m_TempFlags = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalGold
        {
            get
            {
                return this.m_TotalGold;
            }
            set
            {
                Item item1;
                Mobile mobile1;
                if (this.m_TotalGold == value)
                {
                    return;
                }
                if ((this.m_Parent is Item))
                {
                    item1 = ((Item) this.m_Parent);
                    item1.TotalGold = ((item1.TotalGold - this.m_TotalGold) + value);
                }
                else if ((this.m_Parent is Mobile) && !(this is BankBox))
                {
                    mobile1 = ((Mobile) this.m_Parent);
                    mobile1.TotalGold = ((mobile1.TotalGold - this.m_TotalGold) + value);
                }
                this.m_TotalGold = value;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalItems
        {
            get
            {
                return this.m_TotalItems;
            }
            set
            {
                Item item1;
                if (this.m_TotalItems == value)
                {
                    return;
                }
                if ((this.m_Parent is Item))
                {
                    item1 = ((Item) this.m_Parent);
                    item1.TotalItems = ((item1.TotalItems - this.m_TotalItems) + value);
                    item1.InvalidateProperties();
                }
                this.m_TotalItems = value;
                this.InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int TotalWeight
        {
            get
            {
                return this.m_TotalWeight;
            }
            set
            {
                Item item1;
                Mobile mobile1;
                if (this.m_TotalWeight == value)
                {
                    return;
                }
                if ((this.m_Parent is Item))
                {
                    item1 = ((Item) this.m_Parent);
                    item1.TotalWeight = ((item1.TotalWeight - this.m_TotalWeight) + value);
                    item1.InvalidateProperties();
                }
                else if ((this.m_Parent is Mobile) && !(this is BankBox))
                {
                    mobile1 = ((Mobile) this.m_Parent);
                    mobile1.TotalWeight = ((mobile1.TotalWeight - this.m_TotalWeight) + value);
                }
                this.m_TotalWeight = value;
                this.InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Visible
        {
            get
            {
                return this.GetFlag(1);
            }
            set
            {
                Packet packet1;
                Point3D pointd1;
                IPooledEnumerable enumerable1;
                Mobile mobile1;
                if (this.GetFlag(1) == value)
                {
                    return;
                }
                this.SetFlag(1, value);
                this.m_WorldPacket = null;
                if (this.m_Map != null)
                {
                    packet1 = null;
                    pointd1 = this.GetWorldLocation();
                    enumerable1 = this.m_Map.GetClientsInRange(pointd1, this.GetMaxUpdateRange());
                    foreach (NetState state1 in enumerable1)
                    {
                        mobile1 = state1.Mobile;
                        if (!mobile1.CanSee(this) && mobile1.InRange(pointd1, this.GetUpdateRange(mobile1)))
                        {
                            if (packet1 == null)
                            {
                                packet1 = this.RemovePacket;
                            }
                            state1.Send(packet1);
                        }
                    }
                    enumerable1.Free();
                }
                this.Delta(ItemDelta.Update);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public double Weight
        {
            get
            {
                return this.m_Weight;
            }
            set
            {
                Item item1;
                Mobile mobile1;
                if (this.m_Weight == value)
                {
                    return;
                }
                int num1 = this.PileWeight;
                this.m_Weight = value;
                if ((this.m_Parent is Item))
                {
                    item1 = ((Item) this.m_Parent);
                    item1.TotalWeight = ((item1.TotalWeight - num1) + this.PileWeight);
                    item1.InvalidateProperties();
                }
                else if ((this.m_Parent is Mobile) && !(this is BankBox))
                {
                    mobile1 = ((Mobile) this.m_Parent);
                    mobile1.TotalWeight = ((mobile1.TotalWeight - num1) + this.PileWeight);
                }
                this.InvalidateProperties();
            }
        }

        public Packet WorldPacket
        {
            get
            {
                if (this.m_WorldPacket == null)
                {
                    this.m_WorldPacket = new WorldItem(this);
                }
                return this.m_WorldPacket;
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public virtual int X
        {
            get
            {
                return this.m_Location.m_X;
            }
            set
            {
                this.Location = new Point3D(value, this.m_Location.m_Y, this.m_Location.m_Z);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public virtual int Y
        {
            get
            {
                return this.m_Location.m_Y;
            }
            set
            {
                this.Location = new Point3D(this.m_Location.m_X, value, this.m_Location.m_Z);
            }
        }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public virtual int Z
        {
            get
            {
                return this.m_Location.m_Z;
            }
            set
            {
                this.Location = new Point3D(this.m_Location.m_X, this.m_Location.m_Y, value);
            }
        }


        // Fields
        private int m_Amount;
        private Mobile m_BlessedFor;
        private BounceInfo m_Bounce;
        private static TimeSpan m_DDT;
        private ItemDelta m_DeltaFlags;
        private static ArrayList m_DeltaQueue;
        private Direction m_Direction;
        private ImplFlag m_Flags;
        private Mobile m_HeldBy;
        private int m_Hue;
        private int m_ItemID;
        private ArrayList m_Items;
        private DateTime m_LastMovedTime;
        private Layer m_Layer;
        private Point3D m_Location;
        private static int m_LockedDownFlag;
        private LootType m_LootType;
        private Map m_Map;
        private string m_Name;
        private static int m_OpenSlots;
        private Packet m_OPLPacket;
        private object m_Parent;
        private ObjectPropertyList m_PropertyList;
        private Packet m_RemovePacket;
        private int m_SavedFlags;
        private static bool m_ScissorCopyLootType;
        private static int m_SecureFlag;
        private Serial m_Serial;
        private int m_TempFlags;
        private int m_TotalGold;
        private int m_TotalItems;
        private int m_TotalWeight;
        private double m_Weight;
        private Packet m_WorldPacket;

        // Nested Types
        [Flags]
        private enum ImplFlag
        {
            // Fields
            Deleted = 4,
            InQueue = 16,
            Insured = 32,
            Movable = 2,
            None = 0,
            PayedInsurance = 64,
            Stackable = 8,
            Visible = 1
        }

        [Flags]
        private enum SaveFlag
        {
            // Fields
            Amount = 64,
            BlessedFor = 4194304,
            Bounce = 2,
            Direction = 1,
            HeldBy = 8388608,
            Hue = 32,
            ImplFlags = 1048576,
            InsuredFor = 2097152,
            IntWeight = 16777216,
            ItemID = 16,
            Items = 1024,
            Layer = 128,
            LocationByteXY = 524288,
            LocationFull = 8,
            LocationSByteZ = 131072,
            LocationShortXY = 262144,
            LootType = 4,
            Map = 4096,
            Movable = 16384,
            Name = 256,
            None = 0,
            Parent = 512,
            SavedFlags = 33554432,
            Stackable = 32768,
            Visible = 8192,
            WeightIs0 = 65536,
            WeightNot1or0 = 2048
        }
    }
}

