namespace Server
{
    using Server.Guilds;
    using Server.Network;
    using System;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class World
    {
        // Methods
        static World()
        {
            World.SaveType = SaveOption.Normal;
            World.mobIdxPath = Path.Combine("Saves/Mobiles/", "Mobiles.idx");
            World.mobTdbPath = Path.Combine("Saves/Mobiles/", "Mobiles.tdb");
            World.mobBinPath = Path.Combine("Saves/Mobiles/", "Mobiles.bin");
            World.itemIdxPath = Path.Combine("Saves/Items/", "Items.idx");
            World.itemTdbPath = Path.Combine("Saves/Items/", "Items.tdb");
            World.itemBinPath = Path.Combine("Saves/Items/", "Items.bin");
            World.regionIdxPath = Path.Combine("Saves/Regions/", "Regions.idx");
            World.regionBinPath = Path.Combine("Saves/Regions/", "Regions.bin");
            World.guildIdxPath = Path.Combine("Saves/Guilds/", "Guilds.idx");
            World.guildBinPath = Path.Combine("Saves/Guilds/", "Guilds.bin");
        }

        public World()
        {
        }

        public static void AddItem(Item item)
        {
            World.m_Items[item.Serial] = item;
        }

        public static void AddMobile(Mobile m)
        {
            World.m_Mobiles[m.Serial] = m;
        }

        public static void Broadcast(int hue, bool ascii, string text)
        {
            Packet packet1;
            int num1;
            if (ascii)
            {
                packet1 = new AsciiMessage(Serial.MinusOne, -1, MessageType.Regular, hue, 3, "System", text);
            }
            else
            {
                packet1 = new UnicodeMessage(Serial.MinusOne, -1, MessageType.Regular, hue, 3, "ENU", "System", text);
            }
            ArrayList list1 = NetState.Instances;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                if (((NetState) list1[num1]).Mobile != null)
                {
                    ((NetState) list1[num1]).Send(packet1);
                }
            }
        }

        public static void Broadcast(int hue, bool ascii, string format, params object[] args)
        {
            World.Broadcast(hue, ascii, string.Format(format, args));
        }

        public static IEntity FindEntity(Serial serial)
        {
            if (serial.IsItem)
            {
                return ((Item) World.m_Items[serial]);
            }
            if (serial.IsMobile)
            {
                return ((Mobile) World.m_Mobiles[serial]);
            }
            return null;
        }

        public static Item FindItem(Serial serial)
        {
            return ((Item) World.m_Items[serial]);
        }

        public static Mobile FindMobile(Serial serial)
        {
            return ((Mobile) World.m_Mobiles[serial]);
        }

        public static void Load()
        {
            BinaryReader reader1;
            BinaryReader reader2;
            int num5;
            ArrayList list5;
            int num6;
            string text1;
            Type type1;
            ConstructorInfo info1;
            int num7;
            int num8;
            int num9;
            long num10;
            int num11;
            object[] objArray2;
            Mobile mobile1;
            ConstructorInfo info2;
            string text2;
            BinaryReader reader3;
            BinaryReader reader4;
            int num12;
            ArrayList list6;
            int num13;
            string text3;
            Type type2;
            ConstructorInfo info3;
            int num14;
            int num15;
            int num16;
            long num17;
            int num18;
            object[] objArray3;
            Item item1;
            ConstructorInfo info4;
            string text4;
            BinaryReader reader5;
            CreateGuildEventArgs args1;
            int num19;
            int num20;
            long num21;
            int num22;
            BaseGuild guild1;
            BinaryReader reader6;
            int num23;
            int num24;
            long num25;
            int num26;
            Region region1;
            BinaryFileReader reader7;
            int num28;
            MobileEntry entry1;
            Mobile mobile2;
            BinaryFileReader reader8;
            int num29;
            ItemEntry entry2;
            Item item2;
            BinaryFileReader reader9;
            int num30;
            GuildEntry entry3;
            BaseGuild guild2;
            BinaryFileReader reader10;
            int num31;
            RegionEntry entry4;
            Region region2;
            int num32;
            int num33;
            int num34;
            object obj1;
            object[] objArray4;
            if (World.m_Loaded)
            {
                return;
            }
            World.m_Loaded = true;
            World.m_LoadingType = null;
            Console.Write("World: Loading...");
            DateTime time1 = DateTime.Now;
            World.m_Loading = true;
            World.m_DeleteList = new ArrayList();
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            object[] objArray1 = new object[1];
            Type[] typeArray2 = new Type[1];
            typeArray2[0] = typeof(Serial);
            Type[] typeArray1 = typeArray2;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            ArrayList list4 = new ArrayList();
            if (File.Exists(World.mobIdxPath) && File.Exists(World.mobTdbPath))
            {
                using (FileStream stream1 = new FileStream(World.mobIdxPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader1 = new BinaryReader(stream1);
                    using (FileStream stream2 = new FileStream(World.mobTdbPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        reader2 = new BinaryReader(stream2);
                        num5 = reader2.ReadInt32();
                        list5 = new ArrayList(num5);
                        num6 = 0;
                        while ((num6 < num5))
                        {
                            text1 = reader2.ReadString();
                            type1 = ScriptCompiler.FindTypeByFullName(text1);
                            if (type1 == null)
                            {
                                Console.WriteLine("failed");
                                Console.WriteLine("Error: Type \'{0}\' was not found. Delete all of those types? (y/n)", text1);
                                if (Console.ReadLine() == "y")
                                {
                                    list5.Add(null);
                                    Console.Write("World: Loading...");
                                    goto Label_018C;
                                }
                                Console.WriteLine("Types will not be deleted. An exception will be thrown when you press return");
                                throw new Exception(string.Format("Bad type \'{0}\'", text1));
                            }
                            info1 = type1.GetConstructor(typeArray1);
                            if (info1 != null)
                            {
                                objArray4 = new object[2];
                                objArray4[0] = info1;
                                list5.Add(objArray4);
                            }
                            else
                            {
                                throw new Exception(string.Format("Type \'{0}\' does not have a serialization constructor", type1));
                            }
                        Label_018C:
                            ++num6;
                        }
                        num1 = reader1.ReadInt32();
                        World.m_Mobiles = new Hashtable(num1);
                        for (num7 = 0; (num7 < num1); ++num7)
                        {
                            num8 = reader1.ReadInt32();
                            num9 = reader1.ReadInt32();
                            num10 = reader1.ReadInt64();
                            num11 = reader1.ReadInt32();
                            objArray2 = ((object[]) list5[num8]);
                            if (objArray2 != null)
                            {
                                mobile1 = null;
                                info2 = ((ConstructorInfo) objArray2[0]);
                                text2 = ((string) objArray2[1]);
                                try
                                {
                                    objArray1[0] = Serial.op_Implicit(num9);
                                    mobile1 = ((Mobile) info2.Invoke(objArray1));
                                }
                                catch
                                {
                                }
                                if (mobile1 != null)
                                {
                                    list2.Add(new MobileEntry(mobile1, num8, text2, num10, num11));
                                    World.AddMobile(mobile1);
                                }
                            }
                        }
                        goto Label_0282;
                    }
                    goto Label_0282;
                }
            }
            World.m_Mobiles = new Hashtable();
        Label_0282:
            if (File.Exists(World.itemIdxPath) && File.Exists(World.itemTdbPath))
            {
                using (FileStream stream3 = new FileStream(World.itemIdxPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader3 = new BinaryReader(stream3);
                    using (FileStream stream4 = new FileStream(World.itemTdbPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        reader4 = new BinaryReader(stream4);
                        num12 = reader4.ReadInt32();
                        list6 = new ArrayList(num12);
                        num13 = 0;
                        while ((num13 < num12))
                        {
                            text3 = reader4.ReadString();
                            type2 = ScriptCompiler.FindTypeByFullName(text3);
                            if (type2 == null)
                            {
                                Console.WriteLine("failed");
                                Console.WriteLine("Error: Type \'{0}\' was not found. Delete all of those types? (y/n)", text3);
                                if (Console.ReadLine() == "y")
                                {
                                    list6.Add(null);
                                    Console.Write("World: Loading...");
                                    goto Label_0399;
                                }
                                Console.WriteLine("Types will not be deleted. An exception will be thrown when you press return");
                                throw new Exception(string.Format("Bad type \'{0}\'", text3));
                            }
                            info3 = type2.GetConstructor(typeArray1);
                            if (info3 != null)
                            {
                                objArray4 = new object[2];
                                objArray4[0] = info3;
                                objArray4[1] = text3;
                                list6.Add(objArray4);
                            }
                            else
                            {
                                throw new Exception(string.Format("Type \'{0}\' does not have a serialization constructor", type2));
                            }
                        Label_0399:
                            ++num13;
                        }
                        num2 = reader3.ReadInt32();
                        World.m_Items = new Hashtable(num2);
                        for (num14 = 0; (num14 < num2); ++num14)
                        {
                            num15 = reader3.ReadInt32();
                            num16 = reader3.ReadInt32();
                            num17 = reader3.ReadInt64();
                            num18 = reader3.ReadInt32();
                            objArray3 = ((object[]) list6[num15]);
                            if (objArray3 != null)
                            {
                                item1 = null;
                                info4 = ((ConstructorInfo) objArray3[0]);
                                text4 = ((string) objArray3[1]);
                                try
                                {
                                    objArray1[0] = Serial.op_Implicit(num16);
                                    item1 = ((Item) info4.Invoke(objArray1));
                                }
                                catch
                                {
                                }
                                if (item1 != null)
                                {
                                    list1.Add(new ItemEntry(item1, num15, text4, num17, num18));
                                    World.AddItem(item1);
                                }
                            }
                        }
                        goto Label_048F;
                    }
                    goto Label_048F;
                }
            }
            World.m_Items = new Hashtable();
        Label_048F:
            if (File.Exists(World.guildIdxPath))
            {
                using (FileStream stream5 = new FileStream(World.guildIdxPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader5 = new BinaryReader(stream5);
                    num3 = reader5.ReadInt32();
                    args1 = new CreateGuildEventArgs(-1);
                    for (num19 = 0; (num19 < num3); ++num19)
                    {
                        reader5.ReadInt32();
                        num20 = reader5.ReadInt32();
                        num21 = reader5.ReadInt64();
                        num22 = reader5.ReadInt32();
                        args1.Id = num20;
                        guild1 = EventSink.InvokeCreateGuild(args1);
                        if (guild1 != null)
                        {
                            list3.Add(new GuildEntry(guild1, num21, num22));
                        }
                    }
                }
            }
            if (File.Exists(World.regionIdxPath))
            {
                using (FileStream stream6 = new FileStream(World.regionIdxPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader6 = new BinaryReader(stream6);
                    num4 = reader6.ReadInt32();
                    for (num23 = 0; (num23 < num4); ++num23)
                    {
                        reader6.ReadInt32();
                        num24 = reader6.ReadInt32();
                        num25 = reader6.ReadInt64();
                        num26 = reader6.ReadInt32();
                        region1 = Region.FindByUId(num24);
                        if (region1 != null)
                        {
                            list4.Add(new RegionEntry(region1, num25, num26));
                            Region.AddRegion(region1);
                            ++num4;
                        }
                    }
                }
            }
            bool flag1 = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            Type type3 = null;
            Serial serial1 = Serial.Zero;
            Exception exception1 = null;
            int num27 = 0;
            if (File.Exists(World.mobBinPath))
            {
                using (FileStream stream7 = new FileStream(World.mobBinPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader7 = new BinaryFileReader(new BinaryReader(stream7));
                    for (num28 = 0; (num28 < list2.Count); ++num28)
                    {
                        entry1 = ((MobileEntry) list2[num28]);
                        mobile2 = ((Mobile) entry1.Object);
                        if (mobile2 != null)
                        {
                            reader7.Seek(entry1.Position, SeekOrigin.Begin);
                            try
                            {
                                World.m_LoadingType = entry1.TypeName;
                                mobile2.Deserialize(reader7);
                                if (reader7.Position != (entry1.Position + entry1.Length))
                                {
                                    throw new Exception(string.Format("***** Bad serialize on {0} *****", mobile2.GetType()));
                                }
                            }
                            catch (Exception exception2)
                            {
                                list2.RemoveAt(num28);
                                exception1 = exception2;
                                flag1 = true;
                                type3 = mobile2.GetType();
                                num27 = entry1.TypeID;
                                serial1 = mobile2.Serial;
                                goto Label_06F2;
                            }
                        }
                    }
                }
            }
        Label_06F2:
            if (!flag1 && File.Exists(World.itemBinPath))
            {
                using (FileStream stream8 = new FileStream(World.itemBinPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader8 = new BinaryFileReader(new BinaryReader(stream8));
                    for (num29 = 0; (num29 < list1.Count); ++num29)
                    {
                        entry2 = ((ItemEntry) list1[num29]);
                        item2 = ((Item) entry2.Object);
                        if (item2 != null)
                        {
                            reader8.Seek(entry2.Position, SeekOrigin.Begin);
                            try
                            {
                                World.m_LoadingType = entry2.TypeName;
                                item2.Deserialize(reader8);
                                if (reader8.Position != (entry2.Position + entry2.Length))
                                {
                                    throw new Exception(string.Format("***** Bad serialize on {0} *****", item2.GetType()));
                                }
                            }
                            catch (Exception exception3)
                            {
                                list1.RemoveAt(num29);
                                exception1 = exception3;
                                flag2 = true;
                                type3 = item2.GetType();
                                num27 = entry2.TypeID;
                                serial1 = item2.Serial;
                                goto Label_07FA;
                            }
                        }
                    }
                }
            }
        Label_07FA:
            World.m_LoadingType = null;
            if ((!flag1 && !flag2) && File.Exists(World.guildBinPath))
            {
                using (FileStream stream9 = new FileStream(World.guildBinPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader9 = new BinaryFileReader(new BinaryReader(stream9));
                    for (num30 = 0; (num30 < list3.Count); ++num30)
                    {
                        entry3 = ((GuildEntry) list3[num30]);
                        guild2 = ((BaseGuild) entry3.Object);
                        if (guild2 != null)
                        {
                            reader9.Seek(entry3.Position, SeekOrigin.Begin);
                            try
                            {
                                guild2.Deserialize(reader9);
                                if (reader9.Position != (entry3.Position + entry3.Length))
                                {
                                    throw new Exception(string.Format("***** Bad serialize on Guild {0} *****", guild2.Id));
                                }
                            }
                            catch (Exception exception4)
                            {
                                list3.RemoveAt(num30);
                                exception1 = exception4;
                                flag3 = true;
                                type3 = typeof(BaseGuild);
                                num27 = guild2.Id;
                                serial1 = Serial.op_Implicit(guild2.Id);
                                goto Label_0910;
                            }
                        }
                    }
                }
            }
        Label_0910:
            if ((!flag1 && !flag2) && File.Exists(World.regionBinPath))
            {
                using (FileStream stream10 = new FileStream(World.regionBinPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader10 = new BinaryFileReader(new BinaryReader(stream10));
                    for (num31 = 0; (num31 < list4.Count); ++num31)
                    {
                        entry4 = ((RegionEntry) list4[num31]);
                        region2 = ((Region) entry4.Object);
                        if (region2 != null)
                        {
                            reader10.Seek(entry4.Position, SeekOrigin.Begin);
                            try
                            {
                                region2.Deserialize(reader10);
                                if (reader10.Position != (entry4.Position + entry4.Length))
                                {
                                    throw new Exception(string.Format("***** Bad serialize on {0} *****", region2.GetType()));
                                }
                            }
                            catch (Exception exception5)
                            {
                                list4.RemoveAt(num31);
                                exception1 = exception5;
                                flag4 = true;
                                type3 = region2.GetType();
                                num27 = entry4.TypeID;
                                serial1 = Serial.op_Implicit(region2.UId);
                                goto Label_0A1B;
                            }
                        }
                    }
                }
            }
        Label_0A1B:
            if ((flag2 || flag1) || (flag3 || flag4))
            {
                Console.WriteLine("An error was encountered while loading a saved object");
                Console.WriteLine(" - Type: {0}", type3);
                Console.WriteLine(" - Serial: {0}", serial1);
                Console.WriteLine("Delete the object? (y/n)");
                if (Console.ReadLine() == "y")
                {
                    if ((type3 != typeof(BaseGuild)) && !type3.IsSubclassOf(typeof(Region)))
                    {
                        Console.WriteLine("Delete all objects of that type? (y/n)");
                        if (Console.ReadLine() == "y")
                        {
                            if (flag1)
                            {
                                for (num32 = 0; (num32 < list2.Count); ++num32)
                                {
                                    if (((MobileEntry) list2[num32]).TypeID == num27)
                                    {
                                        list2.RemoveAt(num32);
                                        continue;
                                    }
                                }
                            }
                            else if (flag2)
                            {
                                for (num33 = 0; (num33 < list1.Count); ++num33)
                                {
                                    if (((ItemEntry) list1[num33]).TypeID == num27)
                                    {
                                        list1.RemoveAt(num33);
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    World.SaveIndex(list2, World.mobIdxPath);
                    World.SaveIndex(list1, World.itemIdxPath);
                    World.SaveIndex(list3, World.guildIdxPath);
                    World.SaveIndex(list4, World.regionIdxPath);
                }
                Console.WriteLine("After pressing return an exception will be thrown and the server will terminate");
                Console.ReadLine();
                objArray4 = new object[6];
                objArray4[0] = flag2;
                objArray4[1] = flag1;
                objArray4[2] = flag3;
                objArray4[3] = flag4;
                objArray4[4] = type3;
                objArray4[5] = serial1;
                throw new Exception(string.Format("Load failed (items={0}, mobiles={1}, guilds={2}, regions={3}, type={4}, serial={5})", objArray4), exception1);
            }
            EventSink.InvokeWorldLoad();
            World.m_Loading = false;
            for (num34 = 0; (num34 < World.m_DeleteList.Count); ++num34)
            {
                obj1 = World.m_DeleteList[num34];
                if ((obj1 is Item))
                {
                    ((Item) obj1).Delete();
                }
                else if ((obj1 is Mobile))
                {
                    ((Mobile) obj1).Delete();
                }
            }
            foreach (Item item3 in World.m_Items.Values)
            {
                if (item3.Parent == null)
                {
                    item3.UpdateTotals();
                }
            }
            ArrayList list7 = new ArrayList(World.m_Mobiles.Values);
            foreach (Mobile mobile3 in list7)
            {
                mobile3.ForceRegionReEnter(true);
                mobile3.UpdateTotals();
            }
            TimeSpan span1 = ((TimeSpan) (DateTime.Now - time1));
            Console.WriteLine("done ({1} items, {2} mobiles) ({0:F1} seconds)", span1.TotalSeconds, World.m_Items.Count, World.m_Mobiles.Count);
        }

        public static bool OnDelete(object o)
        {
            if (!World.m_Loading)
            {
                return true;
            }
            World.m_DeleteList.Add(o);
            return false;
        }

        public static void RemoveItem(Item item)
        {
            World.m_Items.Remove(item.Serial);
        }

        public static void RemoveMobile(Mobile m)
        {
            World.m_Mobiles.Remove(m.Serial);
        }

        public static void Save()
        {
            ++World.m_Saves;
            World.Save(true);
        }

        public static void Save(bool message)
        {
            object[] objArray1;
            if (World.m_Saving || (AsyncWriter.ThreadCount > 0))
            {
                return;
            }
            World.m_Saving = true;
            if (message)
            {
                World.Broadcast(53, true, "The world is saving, please wait.");
            }
            Console.Write("World: Saving...");
            DateTime time1 = DateTime.Now;
            if (!Directory.Exists("Saves/Mobiles/"))
            {
                Directory.CreateDirectory("Saves/Mobiles/");
            }
            if (!Directory.Exists("Saves/Items/"))
            {
                Directory.CreateDirectory("Saves/Items/");
            }
            if (!Directory.Exists("Saves/Guilds/"))
            {
                Directory.CreateDirectory("Saves/Guilds/");
            }
            if (!Directory.Exists("Saves/Regions/"))
            {
                Directory.CreateDirectory("Saves/Regions/");
            }
            World.SaveMobiles();
            World.SaveItems();
            World.SaveGuilds();
            World.SaveRegions();
            try
            {
                EventSink.InvokeWorldSave(new WorldSaveEventArgs(message));
            }
            catch (Exception exception1)
            {
                throw new Exception("World Save event threw an exception.  Save failed!", exception1);
            }
            GC.Collect();
            DateTime time2 = DateTime.Now;
            TimeSpan span1 = ((TimeSpan) (time2 - time1));
            Console.WriteLine("done in {0:F1} seconds.", span1.TotalSeconds);
            if (message)
            {
                objArray1 = new object[1];
                span1 = ((TimeSpan) (time2 - time1));
                objArray1[0] = span1.TotalSeconds;
                World.Broadcast(53, true, "World save complete. The entire process took {0:F1} seconds.", objArray1);
            }
            World.m_Saving = false;
        }

        private static void SaveGuilds()
        {
            GenericWriter writer1;
            GenericWriter writer2;
            long num1;
            if (World.SaveType == SaveOption.Normal)
            {
                writer1 = new BinaryFileWriter(World.guildIdxPath, false);
                writer2 = new BinaryFileWriter(World.guildBinPath, true);
            }
            else
            {
                writer1 = new AsyncWriter(World.guildIdxPath, false);
                writer2 = new AsyncWriter(World.guildBinPath, true);
            }
            writer1.Write(BaseGuild.List.Count);
            foreach (BaseGuild guild1 in BaseGuild.List.Values)
            {
                num1 = writer2.Position;
                writer1.Write(0);
                writer1.Write(guild1.Id);
                writer1.Write(num1);
                guild1.Serialize(writer2);
                writer1.Write(((int) (writer2.Position - num1)));
            }
            writer1.Close();
            writer2.Close();
        }

        public static void SaveIndex(ArrayList list, string path)
        {
            BinaryWriter writer1;
            int num1;
            IEntityEntry entry1;
            if (!Directory.Exists("Saves/Mobiles/"))
            {
                Directory.CreateDirectory("Saves/Mobiles/");
            }
            if (!Directory.Exists("Saves/Items/"))
            {
                Directory.CreateDirectory("Saves/Items/");
            }
            if (!Directory.Exists("Saves/Guilds/"))
            {
                Directory.CreateDirectory("Saves/Guilds/");
            }
            if (!Directory.Exists("Saves/Regions/"))
            {
                Directory.CreateDirectory("Saves/Regions/");
            }
            using (FileStream stream1 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                writer1 = new BinaryWriter(stream1);
                writer1.Write(list.Count);
                for (num1 = 0; (num1 < list.Count); ++num1)
                {
                    entry1 = ((IEntityEntry) list[num1]);
                    writer1.Write(entry1.TypeID);
                    writer1.Write(Serial.op_Implicit(entry1.Serial));
                    writer1.Write(entry1.Position);
                    writer1.Write(entry1.Length);
                }
                return;
            }
        }

        private static void SaveItems()
        {
            GenericWriter writer1;
            GenericWriter writer2;
            GenericWriter writer3;
            Type type1;
            int num1;
            long num2;
            int num3;
            int num4;
            Item item2;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList(Core.ScriptItems);
            if (World.SaveType == SaveOption.Normal)
            {
                writer1 = new BinaryFileWriter(World.itemIdxPath, false);
                writer2 = new BinaryFileWriter(World.itemTdbPath, false);
                writer3 = new BinaryFileWriter(World.itemBinPath, true);
            }
            else
            {
                writer1 = new AsyncWriter(World.itemIdxPath, false);
                writer2 = new AsyncWriter(World.itemTdbPath, false);
                writer3 = new AsyncWriter(World.itemBinPath, true);
            }
            writer1.Write(World.m_Items.Count);
            foreach (Item item1 in World.m_Items.Values)
            {
                if ((item1.Decays && (item1.Parent == null)) && ((item1.Map != Map.Internal) && ((item1.LastMoved + item1.DecayTime) <= DateTime.Now)))
                {
                    list1.Add(item1);
                }
                type1 = item1.GetType();
                num1 = list2.IndexOf(type1);
                if (num1 == -1)
                {
                    num1 = list2.Add(type1);
                }
                num2 = writer3.Position;
                writer1.Write(num1);
                writer1.Write(Serial.op_Implicit(item1.Serial));
                writer1.Write(num2);
                item1.Serialize(writer3);
                writer1.Write(((int) (writer3.Position - num2)));
                item1.FreeCache();
            }
            writer2.Write(list2.Count);
            for (num3 = 0; (num3 < list2.Count); ++num3)
            {
                writer2.Write(((Type) list2[num3]).FullName);
            }
            writer1.Close();
            writer2.Close();
            writer3.Close();
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                item2 = ((Item) list1[num4]);
                if (item2.OnDecay())
                {
                    item2.Delete();
                }
            }
        }

        private static void SaveMobiles()
        {
            GenericWriter writer1;
            GenericWriter writer2;
            GenericWriter writer3;
            Type type1;
            int num1;
            long num2;
            int num3;
            int num4;
            IVendor vendor1;
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList(Core.ScriptMobiles);
            if (World.SaveType == SaveOption.Normal)
            {
                writer1 = new BinaryFileWriter(World.mobIdxPath, false);
                writer2 = new BinaryFileWriter(World.mobTdbPath, false);
                writer3 = new BinaryFileWriter(World.mobBinPath, true);
            }
            else
            {
                writer1 = new AsyncWriter(World.mobIdxPath, false);
                writer2 = new AsyncWriter(World.mobTdbPath, false);
                writer3 = new AsyncWriter(World.mobBinPath, true);
            }
            writer1.Write(World.m_Mobiles.Count);
            foreach (Mobile mobile1 in World.m_Mobiles.Values)
            {
                type1 = mobile1.GetType();
                num1 = list2.IndexOf(type1);
                if (num1 == -1)
                {
                    num1 = list2.Add(type1);
                }
                num2 = writer3.Position;
                writer1.Write(num1);
                writer1.Write(Serial.op_Implicit(mobile1.Serial));
                writer1.Write(num2);
                mobile1.Serialize(writer3);
                writer1.Write(((int) (writer3.Position - num2)));
                if ((mobile1 is IVendor) && ((((IVendor) mobile1).LastRestock + ((IVendor) mobile1).RestockDelay) < DateTime.Now))
                {
                    list1.Add(mobile1);
                }
                mobile1.FreeCache();
            }
            writer2.Write(list2.Count);
            for (num3 = 0; (num3 < list2.Count); ++num3)
            {
                writer2.Write(((Type) list2[num3]).FullName);
            }
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                vendor1 = ((IVendor) list1[num4]);
                vendor1.Restock();
                vendor1.LastRestock = DateTime.Now;
            }
            writer1.Close();
            writer2.Close();
            writer3.Close();
        }

        private static void SaveRegions()
        {
            GenericWriter writer1;
            int num2;
            Region region1;
            long num3;
            AsyncWriter writer3;
            int num1 = 0;
            if (World.SaveType == SaveOption.Normal)
            {
                writer1 = new BinaryFileWriter(World.regionBinPath, true);
            }
            else
            {
                writer1 = new AsyncWriter(World.regionBinPath, true);
            }
            MemoryStream stream1 = new MemoryStream((4 + (20 * Region.Regions.Count)));
            BinaryWriter writer2 = new BinaryWriter(stream1);
            writer2.Write(0);
            for (num2 = 0; (num2 < Region.Regions.Count); ++num2)
            {
                region1 = ((Region) Region.Regions[num2]);
                if (region1.Saves)
                {
                    ++num1;
                    num3 = writer1.Position;
                    writer2.Write(0);
                    writer2.Write(region1.UId);
                    writer2.Write(num3);
                    region1.Serialize(writer1);
                    writer2.Write(((int) (writer1.Position - num3)));
                }
            }
            writer1.Close();
            writer2.Seek(0, SeekOrigin.Begin);
            writer2.Write(num1);
            if (World.SaveType == SaveOption.Threaded)
            {
                writer3 = new AsyncWriter(World.regionIdxPath, false);
                writer3.MemStream = stream1;
                writer3.Close();
                return;
            }
            FileStream stream2 = new FileStream(World.regionIdxPath, FileMode.Create, FileAccess.Write, FileShare.None);
            stream1.WriteTo(stream2);
            stream2.Close();
        }


        // Properties
        public static Hashtable Items
        {
            get
            {
                return World.m_Items;
            }
        }

        public static bool Loaded
        {
            get
            {
                return World.m_Loaded;
            }
        }

        public static string LoadingType
        {
            get
            {
                return World.m_LoadingType;
            }
        }

        public static Hashtable Mobiles
        {
            get
            {
                return World.m_Mobiles;
            }
        }

        public static bool Saving
        {
            get
            {
                return World.m_Saving;
            }
        }


        // Fields
        private static string guildBinPath;
        private static string guildIdxPath;
        private static string itemBinPath;
        private static string itemIdxPath;
        private static string itemTdbPath;
        private static ArrayList m_DeleteList;
        private static Hashtable m_Items;
        private static bool m_Loaded;
        private static bool m_Loading;
        private static string m_LoadingType;
        private static Hashtable m_Mobiles;
        internal static int m_Saves;
        private static bool m_Saving;
        private static string mobBinPath;
        private static string mobIdxPath;
        private static string mobTdbPath;
        private static string regionBinPath;
        private static string regionIdxPath;
        public static SaveOption SaveType;

        // Nested Types
        private sealed class GuildEntry : World.IEntityEntry
        {
            // Methods
            public GuildEntry(BaseGuild g, long pos, int length)
            {
                this.m_Guild = g;
                this.m_Position = pos;
                this.m_Length = length;
            }


            // Properties
            public int Length
            {
                get
                {
                    return this.m_Length;
                }
            }

            public object Object
            {
                get
                {
                    return this.m_Guild;
                }
            }

            public long Position
            {
                get
                {
                    return this.m_Position;
                }
            }

            public Serial Serial
            {
                get
                {
                    return Serial.op_Implicit(((this.m_Guild == null) ? 0 : this.m_Guild.Id));
                }
            }

            public int TypeID
            {
                get
                {
                    return 0;
                }
            }


            // Fields
            private BaseGuild m_Guild;
            private int m_Length;
            private long m_Position;
        }

        private interface IEntityEntry
        {
            // Properties
            int Length { get; }

            object Object { get; }

            long Position { get; }

            Serial Serial { get; }

            int TypeID { get; }

        }

        private sealed class ItemEntry : World.IEntityEntry
        {
            // Methods
            public ItemEntry(Item item, int typeID, string typeName, long pos, int length)
            {
                this.m_Item = item;
                this.m_TypeID = typeID;
                this.m_TypeName = typeName;
                this.m_Position = pos;
                this.m_Length = length;
            }


            // Properties
            public int Length
            {
                get
                {
                    return this.m_Length;
                }
            }

            public object Object
            {
                get
                {
                    return this.m_Item;
                }
            }

            public long Position
            {
                get
                {
                    return this.m_Position;
                }
            }

            public Serial Serial
            {
                get
                {
                    if (this.m_Item != null)
                    {
                        return this.m_Item.Serial;
                    }
                    return Serial.MinusOne;
                }
            }

            public int TypeID
            {
                get
                {
                    return this.m_TypeID;
                }
            }

            public string TypeName
            {
                get
                {
                    return this.m_TypeName;
                }
            }


            // Fields
            private Item m_Item;
            private int m_Length;
            private long m_Position;
            private int m_TypeID;
            private string m_TypeName;
        }

        private sealed class MobileEntry : World.IEntityEntry
        {
            // Methods
            public MobileEntry(Mobile mobile, int typeID, string typeName, long pos, int length)
            {
                this.m_Mobile = mobile;
                this.m_TypeID = typeID;
                this.m_TypeName = typeName;
                this.m_Position = pos;
                this.m_Length = length;
            }


            // Properties
            public int Length
            {
                get
                {
                    return this.m_Length;
                }
            }

            public object Object
            {
                get
                {
                    return this.m_Mobile;
                }
            }

            public long Position
            {
                get
                {
                    return this.m_Position;
                }
            }

            public Serial Serial
            {
                get
                {
                    if (this.m_Mobile != null)
                    {
                        return this.m_Mobile.Serial;
                    }
                    return Serial.MinusOne;
                }
            }

            public int TypeID
            {
                get
                {
                    return this.m_TypeID;
                }
            }

            public string TypeName
            {
                get
                {
                    return this.m_TypeName;
                }
            }


            // Fields
            private int m_Length;
            private Mobile m_Mobile;
            private long m_Position;
            private int m_TypeID;
            private string m_TypeName;
        }

        private sealed class RegionEntry : World.IEntityEntry
        {
            // Methods
            public RegionEntry(Region r, long pos, int length)
            {
                this.m_Region = r;
                this.m_Position = pos;
                this.m_Length = length;
            }


            // Properties
            public int Length
            {
                get
                {
                    return this.m_Length;
                }
            }

            public object Object
            {
                get
                {
                    return this.m_Region;
                }
            }

            public long Position
            {
                get
                {
                    return this.m_Position;
                }
            }

            public Serial Serial
            {
                get
                {
                    return Serial.op_Implicit(((this.m_Region == null) ? 0 : this.m_Region.UId));
                }
            }

            public int TypeID
            {
                get
                {
                    return 0;
                }
            }


            // Fields
            private int m_Length;
            private long m_Position;
            private Region m_Region;
        }

        public enum SaveOption
        {
            // Fields
            Normal = 0,
            Threaded = 1
        }
    }
}

