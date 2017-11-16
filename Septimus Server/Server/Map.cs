namespace Server
{
    using Server.Items;
    using Server.Network;
    using Server.Targeting;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    [Parsable]
    public sealed class Map
    {
        // Methods
        static Map()
        {
            Map.SectorActiveRange = 2;
            Map.m_Maps = new Map[256];
            Map.m_AllMaps = new ArrayList();
            int[] numArray1 = new int[1];
            numArray1[0] = 580;
            Map.m_InvalidLandTiles = numArray1;
            Map.m_PathList = new Point3DList();
            Map.m_MaxLOSDistance = 25;
        }

        public Map(int mapID, int mapIndex, int fileIndex, int width, int height, int season, string name, MapRules rules)
        {
            this.m_MapID = mapID;
            this.m_MapIndex = mapIndex;
            this.m_FileIndex = fileIndex;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Season = season;
            this.m_Name = name;
            this.m_Rules = rules;
            this.m_Regions = new ArrayList();
            this.m_InvalidSector = new Sector(0, 0, this);
            this.m_SectorsWidth = (width >> 4);
            this.m_SectorsHeight = (height >> 4);
            this.m_Sectors = new Sector[this.m_SectorsWidth][];
        }

        public void ActivateSectors(int cx, int cy)
        {
            int num1;
            int num2;
            Sector sector1;
            for (num1 = (cx - Map.SectorActiveRange); (num1 <= (cx + Map.SectorActiveRange)); ++num1)
            {
                for (num2 = (cy - Map.SectorActiveRange); (num2 <= (cy + Map.SectorActiveRange)); ++num2)
                {
                    sector1 = this.GetRealSector(num1, num2);
                    if (sector1 != this.m_InvalidSector)
                    {
                        sector1.Activate();
                    }
                }
            }
        }

        public void AddMulti(Item item, Sector start, Sector end)
        {
            int num1;
            int num2;
            if (this != Map.Internal)
            {
                for (num1 = start.X; (num1 <= end.X); ++num1)
                {
                    for (num2 = start.Y; (num2 <= end.Y); ++num2)
                    {
                        this.InternalGetSector(num1, num2).OnMultiEnter(item);
                    }
                }
            }
            return;
        }

        public Point2D Bound(Point2D p)
        {
            int num1 = p.m_X;
            int num2 = p.m_Y;
            if (num1 < 0)
            {
                num1 = 0;
            }
            else if (num1 >= this.m_Width)
            {
                num1 = (this.m_Width - 1);
            }
            if (num2 < 0)
            {
                num2 = 0;
            }
            else if (num2 >= this.m_Height)
            {
                num2 = (this.m_Height - 1);
            }
            return new Point2D(num1, num2);
        }

        public void Bound(int x, int y, out int newX, out int newY)
        {
            if (x < 0)
            {
                newX = 0;
            }
            else if (x >= this.m_Width)
            {
                newX = (this.m_Width - 1);
            }
            else
            {
                newX = x;
            }
            if (y < 0)
            {
                newY = 0;
                return;
            }
            if (y >= this.m_Height)
            {
                newY = (this.m_Height - 1);
                return;
            }
            newY = y;
        }

        public bool CanFit(Point3D p, int height)
        {
            return this.CanFit(p.m_X, p.m_Y, p.m_Z, height, false, true, true);
        }

        public bool CanFit(Point2D p, int z, int height)
        {
            return this.CanFit(p.m_X, p.m_Y, z, height, false, true, true);
        }

        public bool CanFit(Point3D p, int height, bool checkBlocksFit)
        {
            return this.CanFit(p.m_X, p.m_Y, p.m_Z, height, checkBlocksFit, true, true);
        }

        public bool CanFit(Point2D p, int z, int height, bool checkBlocksFit)
        {
            return this.CanFit(p.m_X, p.m_Y, z, height, checkBlocksFit, true, true);
        }

        public bool CanFit(Point3D p, int height, bool checkBlocksFit, bool checkMobiles)
        {
            return this.CanFit(p.m_X, p.m_Y, p.m_Z, height, checkBlocksFit, checkMobiles, true);
        }

        public bool CanFit(int x, int y, int z, int height)
        {
            return this.CanFit(x, y, z, height, false, true, true);
        }

        public bool CanFit(int x, int y, int z, int height, bool checksBlocksFit)
        {
            return this.CanFit(x, y, z, height, false, true, true);
        }

        public bool CanFit(int x, int y, int z, int height, bool checkBlocksFit, bool checkMobiles)
        {
            return this.CanFit(x, y, z, height, checkBlocksFit, checkMobiles, true);
        }

        public bool CanFit(int x, int y, int z, int height, bool checkBlocksFit, bool checkMobiles, bool requireSurface)
        {
            bool flag3;
            bool flag4;
            int num4;
            ItemData data1;
            int num5;
            Item item1;
            ItemData data2;
            int num6;
            Mobile mobile1;
            Point3D pointd1;
            if (this == Map.Internal)
            {
                return false;
            }
            if (((x < 0) || (y < 0)) || ((x >= this.m_Width) || (y >= this.m_Height)))
            {
                return false;
            }
            bool flag1 = false;
            Tile tile1 = this.Tiles.GetLandTile(x, y);
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            this.GetAverageZ(x, y, ref num1, ref num2, ref num3);
            TileFlag flag2 = TileData.LandTable[(tile1.ID & 16383)].Flags;
            if ((((flag2 & TileFlag.Impassable) != TileFlag.None) && (num2 > z)) && ((z + height) > num1))
            {
                return false;
            }
            if ((((flag2 & TileFlag.Impassable) == TileFlag.None) && (z == num2)) && !tile1.Ignored)
            {
                flag1 = true;
            }
            Tile[] tileArray1 = this.Tiles.GetStaticTiles(x, y, true);
            for (num4 = 0; (num4 < tileArray1.Length); ++num4)
            {
                data1 = TileData.ItemTable[(tileArray1[num4].ID & 16383)];
                flag3 = data1.Surface;
                flag4 = data1.Impassable;
                if ((flag3 || flag4) && (((tileArray1[num4].Z + data1.CalcHeight) > z) && ((z + height) > tileArray1[num4].Z)))
                {
                    return false;
                }
                if ((flag3 && !flag4) && (z == (tileArray1[num4].Z + data1.CalcHeight)))
                {
                    flag1 = true;
                }
            }
            Sector sector1 = this.GetSector(x, y);
            ArrayList list1 = sector1.Items;
            ArrayList list2 = sector1.Mobiles;
            for (num5 = 0; (num5 < list1.Count); ++num5)
            {
                item1 = ((Item) list1[num5]);
                if ((item1.ItemID < 16384) && item1.AtWorldPoint(x, y))
                {
                    data2 = item1.ItemData;
                    flag3 = data2.Surface;
                    flag4 = data2.Impassable;
                    if (((flag3 || flag4) || (checkBlocksFit && item1.BlocksFit)) && (((item1.Z + data2.CalcHeight) > z) && ((z + height) > item1.Z)))
                    {
                        return false;
                    }
                    if ((flag3 && !flag4) && (z == (item1.Z + data2.CalcHeight)))
                    {
                        flag1 = true;
                    }
                }
            }
            if (checkMobiles)
            {
                for (num6 = 0; (num6 < list2.Count); ++num6)
                {
                    mobile1 = ((Mobile) list2[num6]);
                    pointd1 = mobile1.Location;
                    if (pointd1.m_X == x)
                    {
                        pointd1 = mobile1.Location;
                        if (((pointd1.m_Y == y) && ((mobile1.Z + 16) > z)) && ((z + height) > mobile1.Z))
                        {
                            return false;
                        }
                    }
                }
            }
            if (requireSurface)
            {
                return flag1;
            }
            return true;
        }

        public bool CanSpawnMobile(Point3D p)
        {
            return this.CanSpawnMobile(p.m_X, p.m_Y, p.m_Z);
        }

        public bool CanSpawnMobile(Point2D p, int z)
        {
            return this.CanSpawnMobile(p.m_X, p.m_Y, z);
        }

        public bool CanSpawnMobile(int x, int y, int z)
        {
            if (!Region.Find(new Point3D(x, y, z), this).AllowSpawn())
            {
                return false;
            }
            return this.CanFit(x, y, z, 16);
        }

        private static void CheckNamesAndValues()
        {
            int num1;
            Map map1;
            if ((Map.m_MapNames != null) && (Map.m_MapNames.Length == Map.m_AllMaps.Count))
            {
                return;
            }
            Map.m_MapNames = new string[Map.m_AllMaps.Count];
            Map.m_MapValues = new Map[Map.m_AllMaps.Count];
            for (num1 = 0; (num1 < Map.m_AllMaps.Count); ++num1)
            {
                map1 = ((Map) Map.m_AllMaps[num1]);
                Map.m_MapNames[num1] = map1.Name;
                Map.m_MapValues[num1] = map1;
            }
        }

        public void DeactivateSectors(int cx, int cy)
        {
            int num1;
            int num2;
            Sector sector1;
            for (num1 = (cx - Map.SectorActiveRange); (num1 <= (cx + Map.SectorActiveRange)); ++num1)
            {
                for (num2 = (cy - Map.SectorActiveRange); (num2 <= (cy + Map.SectorActiveRange)); ++num2)
                {
                    sector1 = this.GetRealSector(num1, num2);
                    if ((sector1 != this.m_InvalidSector) && !this.PlayersInRange(sector1, Map.SectorActiveRange))
                    {
                        sector1.Deactivate();
                    }
                }
            }
        }

        public void FixColumn(int x, int y)
        {
            int num4;
            Item item2;
            int num5;
            int num6;
            int num7;
            Tile tile2;
            ItemData data1;
            int num8;
            int num9;
            int num10;
            Item item3;
            ItemData data2;
            int num11;
            int num12;
            Tile tile1 = this.Tiles.GetLandTile(x, y);
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            this.GetAverageZ(x, y, ref num1, ref num2, ref num3);
            Tile[] tileArray1 = this.Tiles.GetStaticTiles(x, y, true);
            ArrayList list1 = new ArrayList();
            IPooledEnumerable enumerable1 = this.GetItemsInRange(new Point3D(x, y, 0), 0);
            foreach (Item item1 in enumerable1)
            {
                if (item1.ItemID < 16384)
                {
                    list1.Add(item1);
                    if (list1.Count > 100)
                    {
                        break;
                    }
                }
            }
        Label_00A6:
            enumerable1.Free();
            if (list1.Count > 100)
            {
                return;
            }
            list1.Sort(ZComparer.Default);
            for (num4 = 0; (num4 < list1.Count); ++num4)
            {
                item2 = ((Item) list1[num4]);
                if (item2.Movable)
                {
                    num5 = -2147483648;
                    num6 = item2.Z;
                    if (!tile1.Ignored && (num2 <= num6))
                    {
                        num5 = num2;
                    }
                    for (num7 = 0; (num7 < tileArray1.Length); ++num7)
                    {
                        tile2 = tileArray1[num7];
                        data1 = TileData.ItemTable[(tile2.ID & 16383)];
                        num8 = tile2.Z;
                        num9 = (num8 + data1.CalcHeight);
                        if ((num9 == num8) && !data1.Surface)
                        {
                            ++num9;
                        }
                        if ((num9 > num5) && (num9 <= num6))
                        {
                            num5 = num9;
                        }
                    }
                    for (num10 = 0; (num10 < list1.Count); ++num10)
                    {
                        if (num10 != num4)
                        {
                            item3 = ((Item) list1[num10]);
                            data2 = item3.ItemData;
                            num11 = item3.Z;
                            num12 = (num11 + data2.CalcHeight);
                            if ((num12 == num11) && !data2.Surface)
                            {
                                ++num12;
                            }
                            if ((num12 > num5) && (num12 <= num6))
                            {
                                num5 = num12;
                            }
                        }
                    }
                    if (num5 != -2147483648)
                    {
                        item2.Location = new Point3D(item2.X, item2.Y, num5);
                    }
                }
            }
        }

        public int GetAverageZ(int x, int y)
        {
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            this.GetAverageZ(x, y, ref num1, ref num2, ref num3);
            return num2;
        }

        public void GetAverageZ(int x, int y, ref int z, ref int avg, ref int top)
        {
            Tile tile1 = this.Tiles.GetLandTile(x, y);
            int num1 = tile1.Z;
            tile1 = this.Tiles.GetLandTile(x, (y + 1));
            int num2 = tile1.Z;
            tile1 = this.Tiles.GetLandTile((x + 1), y);
            int num3 = tile1.Z;
            tile1 = this.Tiles.GetLandTile((x + 1), (y + 1));
            int num4 = tile1.Z;
            z = num1;
            if (num2 < z)
            {
                z = num2;
            }
            if (num3 < z)
            {
                z = num3;
            }
            if (num4 < z)
            {
                z = num4;
            }
            top = num1;
            if (num2 > top)
            {
                top = num2;
            }
            if (num3 > top)
            {
                top = num3;
            }
            if (num4 > top)
            {
                top = num4;
            }
            if (Math.Abs(((int) (num1 - num4))) > Math.Abs(((int) (num2 - num3))))
            {
                avg = ((int) Math.Floor(((num2 + num3) / 2)));
                return;
            }
            avg = ((int) Math.Floor(((num1 + num4) / 2)));
        }

        public IPooledEnumerable GetClientsInBounds(Rectangle2D bounds)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, bounds, SectorEnumeratorType.Clients));
        }

        public IPooledEnumerable GetClientsInRange(Point3D p)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - 18), (p.m_Y - 18), 37, 37), SectorEnumeratorType.Clients));
        }

        public IPooledEnumerable GetClientsInRange(Point3D p, int range)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - range), (p.m_Y - range), ((range * 2) + 1), ((range * 2) + 1)), SectorEnumeratorType.Clients));
        }

        public IPooledEnumerable GetItemsInBounds(Rectangle2D bounds)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, bounds, SectorEnumeratorType.Items));
        }

        public IPooledEnumerable GetItemsInRange(Point3D p)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - 18), (p.m_Y - 18), 37, 37), SectorEnumeratorType.Items));
        }

        public IPooledEnumerable GetItemsInRange(Point3D p, int range)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - range), (p.m_Y - range), ((range * 2) + 1), ((range * 2) + 1)), SectorEnumeratorType.Items));
        }

        public static string[] GetMapNames()
        {
            Map.CheckNamesAndValues();
            return Map.m_MapNames;
        }

        public static Map[] GetMapValues()
        {
            Map.CheckNamesAndValues();
            return Map.m_MapValues;
        }

        public IPooledEnumerable GetMobilesInBounds(Rectangle2D bounds)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, bounds, SectorEnumeratorType.Mobiles));
        }

        public IPooledEnumerable GetMobilesInRange(Point3D p)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - 18), (p.m_Y - 18), 37, 37), SectorEnumeratorType.Mobiles));
        }

        public IPooledEnumerable GetMobilesInRange(Point3D p, int range)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(TypedEnumerator.Instantiate(this, new Rectangle2D((p.m_X - range), (p.m_Y - range), ((range * 2) + 1), ((range * 2) + 1)), SectorEnumeratorType.Mobiles));
        }

        public Sector GetMultiMaxSector(Point3D loc, MultiComponentList mcl)
        {
            Point2D pointd1 = mcl.Max;
            pointd1 = mcl.Max;
            return this.GetSector(this.Bound(new Point2D((loc.m_X + pointd1.m_X), (loc.m_Y + pointd1.m_Y))));
        }

        public Sector GetMultiMinSector(Point3D loc, MultiComponentList mcl)
        {
            Point2D pointd1 = mcl.Min;
            pointd1 = mcl.Min;
            return this.GetSector(this.Bound(new Point2D((loc.m_X + pointd1.m_X), (loc.m_Y + pointd1.m_Y))));
        }

        public IPooledEnumerable GetMultiTilesAt(int x, int y)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            Sector sector1 = this.GetSector(x, y);
            if (sector1.Multis.Count == 0)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(MultiTileEnumerator.Instantiate(sector1, new Point2D(x, y)));
        }

        public IPooledEnumerable GetObjectsInBounds(Rectangle2D bounds)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(ObjectEnumerator.Instantiate(this, bounds));
        }

        public IPooledEnumerable GetObjectsInRange(Point3D p)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(ObjectEnumerator.Instantiate(this, new Rectangle2D((p.m_X - 18), (p.m_Y - 18), 37, 37)));
        }

        public IPooledEnumerable GetObjectsInRange(Point3D p, int range)
        {
            if (this == Map.Internal)
            {
                return NullEnumerable.Instance;
            }
            return PooledEnumerable.Instantiate(ObjectEnumerator.Instantiate(this, new Rectangle2D((p.m_X - range), (p.m_Y - range), ((range * 2) + 1), ((range * 2) + 1))));
        }

        public Point3D GetPoint(object o, bool eye)
        {
            Point3D pointd1;
            int num1;
            int num2;
            int num3;
            StaticTarget target1;
            ItemData data1;
            ItemData data2;
            if ((o is Mobile))
            {
                pointd1 = ((Mobile) o).Location;
                pointd1.Z += (eye ? 15 : 10);
                return pointd1;
            }
            if ((o is Item))
            {
                pointd1 = ((Item) o).GetWorldLocation();
                data2 = ((Item) o).ItemData;
                pointd1.Z += ((data2.Height / 2) + 1);
                return pointd1;
            }
            if ((o is Point3D))
            {
                return ((Point3D) o);
            }
            if ((o is LandTarget))
            {
                pointd1 = ((LandTarget) o).Location;
                num1 = 0;
                num2 = 0;
                num3 = 0;
                this.GetAverageZ(pointd1.X, pointd1.Y, ref num1, ref num2, ref num3);
                pointd1.Z = (num3 + 1);
                return pointd1;
            }
            if ((o is StaticTarget))
            {
                target1 = ((StaticTarget) o);
                data1 = TileData.ItemTable[(target1.ItemID & 16383)];
                pointd1 = new Point3D(target1.X, target1.Y, (((target1.Z - data1.CalcHeight) + (data1.Height / 2)) + 1));
                return pointd1;
            }
            if ((o is IPoint3D))
            {
                pointd1 = new Point3D(((IPoint3D) o));
                return pointd1;
            }
            Console.WriteLine("Warning: Invalid object ({0}) in line of sight", o);
            return Point3D.Zero;
        }

        public Sector GetRealSector(int x, int y)
        {
            return this.InternalGetSector(x, y);
        }

        public Sector GetSector(IPoint2D p)
        {
            return this.InternalGetSector((p.X >> 4), (p.Y >> 4));
        }

        public Sector GetSector(Point2D p)
        {
            return this.InternalGetSector((p.m_X >> 4), (p.m_Y >> 4));
        }

        public Sector GetSector(Point3D p)
        {
            return this.InternalGetSector((p.m_X >> 4), (p.m_Y >> 4));
        }

        public Sector GetSector(int x, int y)
        {
            return this.InternalGetSector((x >> 4), (y >> 4));
        }

        public ArrayList GetTilesAt(Point2D p, bool items, bool land, bool statics)
        {
            ArrayList list1 = new ArrayList();
            if (this == Map.Internal)
            {
                return list1;
            }
            if (land)
            {
                list1.Add(this.Tiles.GetLandTile(p.m_X, p.m_Y));
            }
            if (statics)
            {
                list1.AddRange(this.Tiles.GetStaticTiles(p.m_X, p.m_Y, true));
            }
            if (!items)
            {
                return list1;
            }
            Sector sector1 = this.GetSector(p);
            foreach (Item item1 in sector1.Items)
            {
                if (item1.AtWorldPoint(p.m_X, p.m_Y))
                {
                    list1.Add(new Tile(((short) ((item1.ItemID & 16383) + 16384)), ((sbyte) item1.Z)));
                }
            }
            return list1;
        }

        private Sector InternalGetSector(int x, int y)
        {
            Sector[] sectorArray1;
            Sector sector1;
            if (((x >= 0) && (x < this.m_SectorsWidth)) && ((y >= 0) && (y < this.m_SectorsHeight)))
            {
                sectorArray1 = this.m_Sectors[x];
                if (sectorArray1 == null)
                {
                    this.m_Sectors[x] = (sectorArray1 = new Sector[this.m_SectorsHeight]);
                }
                sector1 = sectorArray1[y];
                if (sector1 == null)
                {
                    sectorArray1[y] = (sector1 = new Sector(x, y, this));
                }
                return sector1;
            }
            return this.m_InvalidSector;
        }

        public bool LineOfSight(Mobile from, Mobile to)
        {
            if ((from == to) || (from.AccessLevel > AccessLevel.Player))
            {
                return true;
            }
            Point3D pointd1 = from.Location;
            Point3D pointd2 = to.Location;
            pointd1.Z += 14;
            pointd2.Z += 10;
            return this.LineOfSight(pointd1, pointd2);
        }

        public bool LineOfSight(Mobile from, Point3D target)
        {
            if (from.AccessLevel > AccessLevel.Player)
            {
                return true;
            }
            Point3D pointd1 = from.Location;
            pointd1.Z += 14;
            return this.LineOfSight(pointd1, target);
        }

        public bool LineOfSight(Point3D org, Point3D dest)
        {
            double num4;
            int num11;
            int num12;
            int num13;
            int num14;
            bool flag1;
            Point3D pointd1;
            TileFlag flag2;
            int num16;
            Point3D pointd4;
            Tile tile1;
            int num17;
            int num18;
            int num19;
            Tile[] tileArray1;
            bool flag3;
            int num20;
            int num21;
            IPooledEnumerable enumerable1;
            int num22;
            Tile tile2;
            ItemData data1;
            Rectangle2D rectangled1;
            ItemData data2;
            int num23;
            int num24;
            Point3D pointd5;
            Point3D pointd6;
            if (this == Map.Internal)
            {
                return false;
            }
            if (!Utility.InRange(org, dest, Map.m_MaxLOSDistance))
            {
                return false;
            }
            Point3DList list1 = Map.m_PathList;
            if (org == dest)
            {
                return true;
            }
            if (list1.Count > 0)
            {
                list1.Clear();
            }
            int num8 = (dest.m_X - org.m_X);
            int num9 = (dest.m_Y - org.m_Y);
            int num10 = (dest.m_Z - org.m_Z);
            double num3 = Math.Sqrt(((num8 * num8) + (num9 * num9)));
            if (num10 != 0)
            {
                num4 = Math.Sqrt(((num3 * num3) + (num10 * num10)));
            }
            else
            {
                num4 = num3;
            }
            double num1 = (num9 / num4);
            double num2 = (num8 / num4);
            num3 = (num10 / num4);
            double num6 = org.m_Y;
            double num7 = org.m_Z;
            double num5 = org.m_X;
            while (((Utility.NumberBetween(num5, dest.m_X, org.m_X, 0.5) && Utility.NumberBetween(num6, dest.m_Y, org.m_Y, 0.5)) && Utility.NumberBetween(num7, dest.m_Z, org.m_Z, 0.5)))
            {
                num11 = ((int) Math.Round(num5));
                num12 = ((int) Math.Round(num6));
                num13 = ((int) Math.Round(num7));
                if (list1.Count > 0)
                {
                    pointd1 = list1.Last;
                    if (((pointd1.m_X != num11) || (pointd1.m_Y != num12)) || (pointd1.m_Z != num13))
                    {
                        list1.Add(num11, num12, num13);
                    }
                }
                else
                {
                    list1.Add(num11, num12, num13);
                }
                num5 += num2;
                num6 += num1;
                num7 += num3;
            }
            if (list1.Count == 0)
            {
                return true;
            }
            pointd1 = list1.Last;
            if (pointd1 != dest)
            {
                list1.Add(dest);
            }
            Point3D pointd2 = org;
            Point3D pointd3 = dest;
            Utility.FixPoints(ref pointd2, ref pointd3);
            int num15 = list1.Count;
            for (num16 = 0; (num16 < num15); ++num16)
            {
                pointd4 = list1[num16];
                tile1 = this.Tiles.GetLandTile(pointd4.X, pointd4.Y);
                num17 = 0;
                num18 = 0;
                num19 = 0;
                this.GetAverageZ(pointd4.m_X, pointd4.m_Y, ref num17, ref num18, ref num19);
                if ((((num17 <= pointd4.m_Z) && (num19 >= pointd4.m_Z)) && (((pointd4.m_X != dest.m_X) || (pointd4.m_Y != dest.m_Y)) || ((num17 > dest.m_Z) || (num19 < dest.m_Z)))) && !tile1.Ignored)
                {
                    return false;
                }
                tileArray1 = this.Tiles.GetStaticTiles(pointd4.m_X, pointd4.m_Y, true);
                flag3 = false;
                num20 = tile1.ID;
                for (num21 = 0; (!flag3 && (num21 < Map.m_InvalidLandTiles.Length)); ++num21)
                {
                    flag3 = (num20 == Map.m_InvalidLandTiles[num21]);
                }
                if (flag3 && (tileArray1.Length == 0))
                {
                    enumerable1 = this.GetItemsInRange(pointd4, 0);
                    foreach (Item item1 in enumerable1)
                    {
                        if (item1.Visible)
                        {
                            flag3 = false;
                        }
                        if (!flag3)
                        {
                            break;
                        }
                    }
                    enumerable1.Free();
                    if (flag3)
                    {
                        return false;
                    }
                }
                for (num22 = 0; (num22 < tileArray1.Length); ++num22)
                {
                    tile2 = tileArray1[num22];
                    data1 = TileData.ItemTable[(tile2.ID & 16383)];
                    flag2 = data1.Flags;
                    num14 = data1.CalcHeight;
                    if ((((tile2.Z <= pointd4.Z) && ((tile2.Z + num14) >= pointd4.Z)) && ((flag2 & (TileFlag.NoShoot | TileFlag.Window)) != TileFlag.None)) && (((pointd4.m_X != dest.m_X) || (pointd4.m_Y != dest.m_Y)) || ((tile2.Z > dest.m_Z) || ((tile2.Z + num14) < dest.m_Z))))
                    {
                        return false;
                    }
                }
            }
            rectangled1 = new Rectangle2D(pointd2.m_X, pointd2.m_Y, ((pointd3.m_X - pointd2.m_X) + 1), ((pointd3.m_Y - pointd2.m_Y) + 1));
            IPooledEnumerable enumerable2 = this.GetItemsInBounds(rectangled1);
            foreach (Item item2 in enumerable2)
            {
                if (!item2.Visible || (item2.ItemID >= 16384))
                {
                    continue;
                }
                data2 = item2.ItemData;
                flag2 = data2.Flags;
                if ((flag2 & (TileFlag.NoShoot | TileFlag.Window)) != TileFlag.None)
                {
                    num14 = data2.CalcHeight;
                    flag1 = false;
                    num23 = list1.Count;
                    for (num24 = 0; (num24 < num23); ++num24)
                    {
                        pointd5 = list1[num24];
                        pointd6 = item2.Location;
                        if ((((pointd6.m_X == pointd5.m_X) && (pointd6.m_Y == pointd5.m_Y)) && ((pointd6.m_Z <= pointd5.m_Z) && ((pointd6.m_Z + num14) >= pointd5.m_Z))) && (((pointd6.m_X != dest.m_X) || (pointd6.m_Y != dest.m_Y)) || ((pointd6.m_Z > dest.m_Z) || ((pointd6.m_Z + num14) < dest.m_Z))))
                        {
                            flag1 = true;
                            break;
                        }
                    }
                    if (flag1)
                    {
                        enumerable2.Free();
                        return false;
                    }
                }
            }
            enumerable2.Free();
            return true;
        }

        public bool LineOfSight(object from, object dest)
        {
            if ((from == dest) || ((from is Mobile) && (((Mobile) from).AccessLevel > AccessLevel.Player)))
            {
                return true;
            }
            if (((dest is Item) && (from is Mobile)) && (((Item) dest).RootParent == from))
            {
                return true;
            }
            return this.LineOfSight(this.GetPoint(from, true), this.GetPoint(dest, false));
        }

        public void OnClientChange(NetState oldState, NetState newState, Mobile m)
        {
            if (this != Map.Internal)
            {
                this.GetSector(m).OnClientChange(oldState, newState);
            }
        }

        public void OnEnter(Item item)
        {
            MultiComponentList list1;
            Sector sector1;
            Sector sector2;
            if (this == Map.Internal)
            {
                return;
            }
            this.GetSector(item).OnEnter(item);
            if ((item is BaseMulti))
            {
                list1 = ((BaseMulti) item).Components;
                sector1 = this.GetMultiMinSector(item.Location, list1);
                sector2 = this.GetMultiMaxSector(item.Location, list1);
                this.AddMulti(item, sector1, sector2);
            }
        }

        public void OnEnter(Mobile m)
        {
            if (this != Map.Internal)
            {
                this.GetSector(m).OnEnter(m);
            }
        }

        public void OnLeave(Item item)
        {
            MultiComponentList list1;
            Sector sector1;
            Sector sector2;
            if (this == Map.Internal)
            {
                return;
            }
            this.GetSector(item).OnLeave(item);
            if ((item is BaseMulti))
            {
                list1 = ((BaseMulti) item).Components;
                sector1 = this.GetMultiMinSector(item.Location, list1);
                sector2 = this.GetMultiMaxSector(item.Location, list1);
                this.RemoveMulti(item, sector1, sector2);
            }
        }

        public void OnLeave(Mobile m)
        {
            if (this != Map.Internal)
            {
                this.GetSector(m).OnLeave(m);
            }
        }

        public void OnMove(Point3D oldLocation, Item item)
        {
            if (this == Map.Internal)
            {
                return;
            }
            Sector sector1 = this.GetSector(oldLocation);
            Sector sector2 = this.GetSector(item.Location);
            if (sector1 != sector2)
            {
                sector1.OnLeave(item);
                sector2.OnEnter(item);
            }
            if (!(item is BaseMulti))
            {
                return;
            }
            MultiComponentList list1 = ((BaseMulti) item).Components;
            Sector sector3 = this.GetMultiMinSector(item.Location, list1);
            Sector sector4 = this.GetMultiMaxSector(item.Location, list1);
            Sector sector5 = this.GetMultiMinSector(oldLocation, list1);
            Sector sector6 = this.GetMultiMaxSector(oldLocation, list1);
            if ((sector5 == sector3) && (sector6 == sector4))
            {
                return;
            }
            this.RemoveMulti(item, sector5, sector6);
            this.AddMulti(item, sector3, sector4);
        }

        public void OnMove(Point3D oldLocation, Mobile m)
        {
            if (this == Map.Internal)
            {
                return;
            }
            Sector sector1 = this.GetSector(oldLocation);
            Sector sector2 = this.GetSector(m.Location);
            if (sector1 != sector2)
            {
                sector1.OnLeave(m);
                sector2.OnEnter(m);
            }
        }

        public static Map Parse(string value)
        {
            int num1;
            int num2;
            Map.CheckNamesAndValues();
            for (num1 = 0; (num1 < Map.m_MapNames.Length); ++num1)
            {
                if (Insensitive.Equals(Map.m_MapNames[num1], value))
                {
                    return Map.m_MapValues[num1];
                }
            }
            try
            {
                num2 = int.Parse(value);
                if (((num2 >= 0) && (num2 < Map.m_Maps.Length)) && (Map.m_Maps[num2] != null))
                {
                    return Map.m_Maps[num2];
                }
            }
            catch
            {
            }
            throw new Exception("Invalid map name");
        }

        private bool PlayersInRange(Sector sect, int range)
        {
            int num1;
            int num2;
            Sector sector1;
            for (num1 = (sect.X - range); (num1 <= (sect.X + range)); ++num1)
            {
                for (num2 = (sect.Y - range); (num2 <= (sect.Y + range)); ++num2)
                {
                    sector1 = this.GetRealSector(num1, num2);
                    if ((sector1 != this.m_InvalidSector) && (sector1.Players.Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RemoveMulti(Item item, Sector start, Sector end)
        {
            int num1;
            int num2;
            if (this != Map.Internal)
            {
                for (num1 = start.X; (num1 <= end.X); ++num1)
                {
                    for (num2 = start.Y; (num2 <= end.Y); ++num2)
                    {
                        this.InternalGetSector(num1, num2).OnMultiLeave(item);
                    }
                }
            }
            return;
        }

        public override string ToString()
        {
            return this.m_Name;
        }


        // Properties
        public static ArrayList AllMaps
        {
            get
            {
                return Map.m_AllMaps;
            }
        }

        public Region DefaultRegion
        {
            get
            {
                if (this.m_DefaultRegion == null)
                {
                    this.m_DefaultRegion = new Region("", "", this);
                }
                return this.m_DefaultRegion;
            }
            set
            {
                this.m_DefaultRegion = value;
            }
        }

        public static Map Felucca
        {
            get
            {
                return Map.m_Maps[0];
            }
        }

        public int Height
        {
            get
            {
                return this.m_Height;
            }
        }

        public static Map Ilshenar
        {
            get
            {
                return Map.m_Maps[2];
            }
        }

        public static Map Internal
        {
            get
            {
                return Map.m_Maps[127];
            }
        }

        public static int[] InvalidLandTiles
        {
            get
            {
                return Map.m_InvalidLandTiles;
            }
            set
            {
                Map.m_InvalidLandTiles = value;
            }
        }

        public Sector InvalidSector
        {
            get
            {
                return this.m_InvalidSector;
            }
        }

        public static Map Malas
        {
            get
            {
                return Map.m_Maps[3];
            }
        }

        public int MapID
        {
            get
            {
                return this.m_MapID;
            }
        }

        public int MapIndex
        {
            get
            {
                return this.m_MapIndex;
            }
        }

        public static Map[] Maps
        {
            get
            {
                return Map.m_Maps;
            }
        }

        public static int MaxLOSDistance
        {
            get
            {
                return Map.m_MaxLOSDistance;
            }
            set
            {
                Map.m_MaxLOSDistance = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public ArrayList Regions
        {
            get
            {
                return this.m_Regions;
            }
        }

        public MapRules Rules
        {
            get
            {
                return this.m_Rules;
            }
            set
            {
                this.m_Rules = value;
            }
        }

        public int Season
        {
            get
            {
                return this.m_Season;
            }
            set
            {
                this.m_Season = value;
            }
        }

        public TileMatrix Tiles
        {
            get
            {
                if (this.m_Tiles == null)
                {
                    this.m_Tiles = new TileMatrix(this, this.m_FileIndex, this.m_MapID, this.m_Width, this.m_Height);
                }
                return this.m_Tiles;
            }
        }

        public static Map Trammel
        {
            get
            {
                return Map.m_Maps[1];
            }
        }

        public int Width
        {
            get
            {
                return this.m_Width;
            }
        }


        // Fields
        private static ArrayList m_AllMaps;
        private Region m_DefaultRegion;
        private int m_FileIndex;
        private int m_Height;
        private static int[] m_InvalidLandTiles;
        private Sector m_InvalidSector;
        private int m_MapID;
        private int m_MapIndex;
        private static string[] m_MapNames;
        private static Map[] m_Maps;
        private static Map[] m_MapValues;
        private static int m_MaxLOSDistance;
        private string m_Name;
        private static Point3DList m_PathList;
        private ArrayList m_Regions;
        private MapRules m_Rules;
        private int m_Season;
        private Sector[][] m_Sectors;
        private int m_SectorsHeight;
        private int m_SectorsWidth;
        private TileMatrix m_Tiles;
        private int m_Width;
        public static int SectorActiveRange;
        public const int SectorShift = 4;
        public const int SectorSize = 16;

        // Nested Types
        private class MultiTileEnumerator : IPooledEnumerator, IEnumerator, IDisposable
        {
            // Methods
            static MultiTileEnumerator()
            {
                Map.MultiTileEnumerator.m_InstancePool = new Queue();
            }

            private MultiTileEnumerator(Sector sector, Point2D loc)
            {
                this.m_List = sector.Multis;
                this.m_Location = loc;
                this.Reset();
            }

            public void Dispose()
            {
                this.Free();
            }

            public void Free()
            {
                if (this.m_List == null)
                {
                    return;
                }
                Map.MultiTileEnumerator.m_InstancePool.Enqueue(this);
                this.m_List = null;
                if (this.m_Enumerable != null)
                {
                    this.m_Enumerable.Free();
                }
            }

            public static Map.MultiTileEnumerator Instantiate(Sector sector, Point2D loc)
            {
                Map.MultiTileEnumerator enumerator1;
                if (Map.MultiTileEnumerator.m_InstancePool.Count > 0)
                {
                    enumerator1 = ((Map.MultiTileEnumerator) Map.MultiTileEnumerator.m_InstancePool.Dequeue());
                    enumerator1.m_List = sector.Multis;
                    enumerator1.m_Location = loc;
                    enumerator1.Reset();
                    return enumerator1;
                }
                return new Map.MultiTileEnumerator(sector, loc);
            }

            public bool MoveNext()
            {
                BaseMulti multi1;
                MultiComponentList list1;
                int num1;
                int num2;
                Tile[] tileArray1;
                Tile[] tileArray2;
                int num3;
                Point3D pointd1;
                Point2D pointd2;
                int num4;
                goto Label_011B;
            Label_0005:
                multi1 = (this.m_List[this.m_Index] as BaseMulti);
                if ((multi1 != null) && !multi1.Deleted)
                {
                    list1 = multi1.Components;
                    pointd1 = multi1.Location;
                    pointd2 = list1.Min;
                    num1 = (this.m_Location.m_X - (pointd1.m_X + pointd2.m_X));
                    pointd1 = multi1.Location;
                    pointd2 = list1.Min;
                    num2 = (this.m_Location.m_Y - (pointd1.m_Y + pointd2.m_Y));
                    if (((num1 >= 0) && (num1 < list1.Width)) && ((num2 >= 0) && (num2 < list1.Height)))
                    {
                        tileArray1 = list1.Tiles[num1][num2];
                        if (tileArray1.Length > 0)
                        {
                            tileArray2 = new Tile[tileArray1.Length];
                            for (num3 = 0; (num3 < tileArray2.Length); ++num3)
                            {
                                tileArray2[num3] = tileArray1[num3];
                                tileArray2[num3].Z += multi1.Z;
                            }
                            this.m_Current = tileArray2;
                            return true;
                        }
                    }
                }
            Label_011B:
                this.m_Index = (num4 = (this.m_Index + 1));
                if (num4 >= this.m_List.Count)
                {
                    return false;
                }
                goto Label_0005;
            }

            public void Reset()
            {
                this.m_Current = null;
                this.m_Index = -1;
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.m_Current;
                }
            }

            public IPooledEnumerable Enumerable
            {
                get
                {
                    return this.m_Enumerable;
                }
                set
                {
                    this.m_Enumerable = value;
                }
            }


            // Fields
            private object m_Current;
            private IPooledEnumerable m_Enumerable;
            private int m_Index;
            private static Queue m_InstancePool;
            private ArrayList m_List;
            private Point2D m_Location;
        }

        public class NullEnumerable : IPooledEnumerable, IEnumerable
        {
            // Methods
            static NullEnumerable()
            {
                Map.NullEnumerable.Instance = new Map.NullEnumerable();
            }

            private NullEnumerable()
            {
                this.m_Enumerator = new InternalEnumerator();
            }

            public void Free()
            {
            }

            public IEnumerator GetEnumerator()
            {
                return this.m_Enumerator;
            }


            // Fields
            public static readonly Map.NullEnumerable Instance;
            private InternalEnumerator m_Enumerator;

            // Nested Types
            private class InternalEnumerator : IEnumerator
            {
                // Methods
                public InternalEnumerator()
                {
                }

                public bool MoveNext()
                {
                    return false;
                }

                public void Reset()
                {
                }


                // Properties
                public object Current
                {
                    get
                    {
                        return null;
                    }
                }

            }
        }

        private class ObjectEnumerator : IPooledEnumerator, IEnumerator, IDisposable
        {
            // Methods
            static ObjectEnumerator()
            {
                Map.ObjectEnumerator.m_InstancePool = new Queue();
            }

            private ObjectEnumerator(Map map, Rectangle2D bounds)
            {
                this.m_Map = map;
                this.m_Bounds = bounds;
                this.Reset();
            }

            public void Dispose()
            {
                this.Free();
            }

            public void Free()
            {
                if (this.m_Map == null)
                {
                    return;
                }
                Map.ObjectEnumerator.m_InstancePool.Enqueue(this);
                this.m_Map = null;
                if (this.m_Enumerator != null)
                {
                    this.m_Enumerator.Free();
                    this.m_Enumerator = null;
                }
                if (this.m_Enumerable != null)
                {
                    this.m_Enumerable.Free();
                }
            }

            public static Map.ObjectEnumerator Instantiate(Map map, Rectangle2D bounds)
            {
                Map.ObjectEnumerator enumerator1;
                if (Map.ObjectEnumerator.m_InstancePool.Count > 0)
                {
                    enumerator1 = ((Map.ObjectEnumerator) Map.ObjectEnumerator.m_InstancePool.Dequeue());
                    enumerator1.m_Map = map;
                    enumerator1.m_Bounds = bounds;
                    enumerator1.Reset();
                    return enumerator1;
                }
                return new Map.ObjectEnumerator(map, bounds);
            }

            public bool MoveNext()
            {
                object obj1;
                Mobile mobile1;
                Item item1;
            Label_0000:
                if (this.m_Enumerator.MoveNext())
                {
                    obj1 = this.m_Enumerator.Current;
                    if ((obj1 is Mobile))
                    {
                        mobile1 = ((Mobile) obj1);
                        if (!this.m_Bounds.Contains(mobile1.Location))
                        {
                            goto Label_0000;
                        }
                        this.m_Current = obj1;
                        return true;
                    }
                    if (!(obj1 is Item))
                    {
                        goto Label_0000;
                    }
                    item1 = ((Item) obj1);
                    if ((item1.Parent != null) || !this.m_Bounds.Contains(item1.Location))
                    {
                        goto Label_0000;
                    }
                    this.m_Current = obj1;
                    return true;
                }
                if (this.m_Stage == 0)
                {
                    this.m_Enumerator.Free();
                    this.m_Enumerator = Map.SectorEnumerator.Instantiate(this.m_Map, this.m_Bounds, Map.SectorEnumeratorType.Mobiles);
                    this.m_Current = null;
                    this.m_Stage = 1;
                    goto Label_0000;
                }
                this.m_Enumerator.Free();
                this.m_Enumerator = null;
                this.m_Current = null;
                this.m_Stage = -1;
                return false;
            }

            public void Reset()
            {
                this.m_Stage = 0;
                this.m_Current = null;
                if (this.m_Enumerator != null)
                {
                    this.m_Enumerator.Free();
                }
                this.m_Enumerator = Map.SectorEnumerator.Instantiate(this.m_Map, this.m_Bounds, Map.SectorEnumeratorType.Items);
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.m_Current;
                }
            }

            public IPooledEnumerable Enumerable
            {
                get
                {
                    return this.m_Enumerable;
                }
                set
                {
                    this.m_Enumerable = value;
                }
            }


            // Fields
            private Rectangle2D m_Bounds;
            private object m_Current;
            private IPooledEnumerable m_Enumerable;
            private Map.SectorEnumerator m_Enumerator;
            private static Queue m_InstancePool;
            private Map m_Map;
            private int m_Stage;
        }

        private class PooledEnumerable : IPooledEnumerable, IEnumerable, IDisposable
        {
            // Methods
            static PooledEnumerable()
            {
                Map.PooledEnumerable.m_InstancePool = new Queue();
                Map.PooledEnumerable.m_Depth = 0;
            }

            private PooledEnumerable(IPooledEnumerator etor)
            {
                this.m_Enumerator = etor;
            }

            public void Dispose()
            {
                this.Free();
            }

            public void Free()
            {
                if (this.m_Enumerator != null)
                {
                    Map.PooledEnumerable.m_InstancePool.Enqueue(this);
                    this.m_Enumerator.Free();
                    this.m_Enumerator = null;
                    --Map.PooledEnumerable.m_Depth;
                }
            }

            public IEnumerator GetEnumerator()
            {
                if (this.m_Enumerator == null)
                {
                    throw new ObjectDisposedException("PooledEnumerable", "GetEnumerator() called after Free()");
                }
                return this.m_Enumerator;
            }

            public static Map.PooledEnumerable Instantiate(IPooledEnumerator etor)
            {
                Map.PooledEnumerable enumerable1;
                ++Map.PooledEnumerable.m_Depth;
                if (Map.PooledEnumerable.m_Depth >= 5)
                {
                    Console.WriteLine("Warning: Make sure to call .Free() on pooled enumerables.");
                }
                if (Map.PooledEnumerable.m_InstancePool.Count > 0)
                {
                    enumerable1 = ((Map.PooledEnumerable) Map.PooledEnumerable.m_InstancePool.Dequeue());
                    enumerable1.m_Enumerator = etor;
                }
                else
                {
                    enumerable1 = new Map.PooledEnumerable(etor);
                }
                etor.Enumerable = enumerable1;
                return enumerable1;
            }


            // Fields
            private static int m_Depth;
            private IPooledEnumerator m_Enumerator;
            private static Queue m_InstancePool;
        }

        private class SectorEnumerator : IPooledEnumerator, IEnumerator, IDisposable
        {
            // Methods
            static SectorEnumerator()
            {
                Map.SectorEnumerator.m_InstancePool = new Queue();
            }

            private SectorEnumerator(Map map, Rectangle2D bounds, Map.SectorEnumeratorType type)
            {
                this.m_Map = map;
                this.m_Bounds = bounds;
                this.m_Type = type;
                this.Reset();
            }

            public void Dispose()
            {
                this.Free();
            }

            public void Free()
            {
                if (this.m_Map == null)
                {
                    return;
                }
                Map.SectorEnumerator.m_InstancePool.Enqueue(this);
                this.m_Map = null;
                if (this.m_Enumerable != null)
                {
                    this.m_Enumerable.Free();
                }
            }

            private ArrayList GetListForSector(Sector sector)
            {
                switch (this.m_Type)
                {
                    case Map.SectorEnumeratorType.Mobiles:
                    {
                        goto Label_0022;
                    }
                    case Map.SectorEnumeratorType.Items:
                    {
                        goto Label_0029;
                    }
                    case Map.SectorEnumeratorType.Clients:
                    {
                        goto Label_001B;
                    }
                }
                goto Label_0030;
            Label_001B:
                return sector.Clients;
            Label_0022:
                return sector.Mobiles;
            Label_0029:
                return sector.Items;
            Label_0030:
                throw new Exception("Invalid SectorEnumeratorType");
            }

            public static Map.SectorEnumerator Instantiate(Map map, Rectangle2D bounds, Map.SectorEnumeratorType type)
            {
                Map.SectorEnumerator enumerator1;
                if (Map.SectorEnumerator.m_InstancePool.Count > 0)
                {
                    enumerator1 = ((Map.SectorEnumerator) Map.SectorEnumerator.m_InstancePool.Dequeue());
                    enumerator1.m_Map = map;
                    enumerator1.m_Bounds = bounds;
                    enumerator1.m_Type = type;
                    enumerator1.Reset();
                    return enumerator1;
                }
                return new Map.SectorEnumerator(map, bounds, type);
            }

            public bool MoveNext()
            {
            Label_0000:
                ++this.m_CurrentIndex;
                if (this.m_CurrentIndex == this.m_CurrentList.Count)
                {
                    ++this.m_ySector;
                    if (this.m_ySector > this.m_ySectorEnd)
                    {
                        this.m_ySector = this.m_ySectorStart;
                        ++this.m_xSector;
                        if (this.m_xSector > this.m_xSectorEnd)
                        {
                            this.m_CurrentIndex = -1;
                            this.m_CurrentList = null;
                            return false;
                        }
                    }
                    this.m_CurrentIndex = -1;
                    this.m_CurrentList = this.GetListForSector(this.m_Map.InternalGetSector(this.m_xSector, this.m_ySector));
                    goto Label_0000;
                }
                return true;
            }

            public void Reset()
            {
                int num1;
                Point2D pointd1 = this.m_Bounds.Start;
                pointd1 = this.m_Bounds.Start;
                this.m_Map.Bound(pointd1.m_X, pointd1.m_Y, out this.m_xSectorStart, out this.m_ySectorStart);
                pointd1 = this.m_Bounds.End;
                pointd1 = this.m_Bounds.End;
                this.m_Map.Bound((pointd1.m_X - 1), (pointd1.m_Y - 1), out this.m_xSectorEnd, out this.m_ySectorEnd);
                this.m_xSectorStart = (num1 = (this.m_xSectorStart >> 4));
                this.m_xSector = num1;
                this.m_ySectorStart = (num1 = (this.m_ySectorStart >> 4));
                this.m_ySector = num1;
                this.m_xSectorEnd = (this.m_xSectorEnd >> 4);
                this.m_ySectorEnd = (this.m_ySectorEnd >> 4);
                this.m_CurrentIndex = -1;
                this.m_CurrentList = this.GetListForSector(this.m_Map.InternalGetSector(this.m_xSector, this.m_ySector));
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.m_CurrentList[this.m_CurrentIndex];
                }
            }

            public IPooledEnumerable Enumerable
            {
                get
                {
                    return this.m_Enumerable;
                }
                set
                {
                    this.m_Enumerable = value;
                }
            }


            // Fields
            private Rectangle2D m_Bounds;
            private int m_CurrentIndex;
            private ArrayList m_CurrentList;
            private IPooledEnumerable m_Enumerable;
            private static Queue m_InstancePool;
            private Map m_Map;
            private Map.SectorEnumeratorType m_Type;
            private int m_xSector;
            private int m_xSectorEnd;
            private int m_xSectorStart;
            private int m_ySector;
            private int m_ySectorEnd;
            private int m_ySectorStart;
        }

        private enum SectorEnumeratorType
        {
            // Fields
            Clients = 2,
            Items = 1,
            Mobiles = 0
        }

        private class TypedEnumerator : IPooledEnumerator, IEnumerator, IDisposable
        {
            // Methods
            static TypedEnumerator()
            {
                Map.TypedEnumerator.m_InstancePool = new Queue();
            }

            public TypedEnumerator(Map map, Rectangle2D bounds, Map.SectorEnumeratorType type)
            {
                this.m_Map = map;
                this.m_Bounds = bounds;
                this.m_Type = type;
                this.Reset();
            }

            public void Dispose()
            {
                this.Free();
            }

            public void Free()
            {
                if (this.m_Map == null)
                {
                    return;
                }
                Map.TypedEnumerator.m_InstancePool.Enqueue(this);
                this.m_Map = null;
                if (this.m_Enumerator != null)
                {
                    this.m_Enumerator.Free();
                    this.m_Enumerator = null;
                }
                if (this.m_Enumerable != null)
                {
                    this.m_Enumerable.Free();
                }
            }

            public static Map.TypedEnumerator Instantiate(Map map, Rectangle2D bounds, Map.SectorEnumeratorType type)
            {
                Map.TypedEnumerator enumerator1;
                if (Map.TypedEnumerator.m_InstancePool.Count > 0)
                {
                    enumerator1 = ((Map.TypedEnumerator) Map.TypedEnumerator.m_InstancePool.Dequeue());
                    enumerator1.m_Map = map;
                    enumerator1.m_Bounds = bounds;
                    enumerator1.m_Type = type;
                    enumerator1.Reset();
                    return enumerator1;
                }
                return new Map.TypedEnumerator(map, bounds, type);
            }

            public bool MoveNext()
            {
                object obj1;
                Mobile mobile1;
                Item item1;
                Mobile mobile2;
            Label_0000:
                if (this.m_Enumerator.MoveNext())
                {
                    obj1 = this.m_Enumerator.Current;
                    if ((obj1 is Mobile))
                    {
                        mobile1 = ((Mobile) obj1);
                        if (mobile1.Deleted || !this.m_Bounds.Contains(mobile1.Location))
                        {
                            goto Label_0000;
                        }
                        this.m_Current = obj1;
                        return true;
                    }
                    if ((obj1 is Item))
                    {
                        item1 = ((Item) obj1);
                        if ((item1.Deleted || (item1.Parent != null)) || !this.m_Bounds.Contains(item1.Location))
                        {
                            goto Label_0000;
                        }
                        this.m_Current = obj1;
                        return true;
                    }
                    if (!(obj1 is NetState))
                    {
                        goto Label_0000;
                    }
                    mobile2 = ((NetState) obj1).Mobile;
                    if (((mobile2 == null) || mobile2.Deleted) || !this.m_Bounds.Contains(mobile2.Location))
                    {
                        goto Label_0000;
                    }
                    this.m_Current = obj1;
                    return true;
                }
                this.m_Current = null;
                this.m_Enumerator.Free();
                this.m_Enumerator = null;
                return false;
            }

            public void Reset()
            {
                this.m_Current = null;
                if (this.m_Enumerator != null)
                {
                    this.m_Enumerator.Free();
                }
                this.m_Enumerator = Map.SectorEnumerator.Instantiate(this.m_Map, this.m_Bounds, this.m_Type);
            }


            // Properties
            public object Current
            {
                get
                {
                    return this.m_Current;
                }
            }

            public IPooledEnumerable Enumerable
            {
                get
                {
                    return this.m_Enumerable;
                }
                set
                {
                    this.m_Enumerable = value;
                }
            }


            // Fields
            private Rectangle2D m_Bounds;
            private object m_Current;
            private IPooledEnumerable m_Enumerable;
            private Map.SectorEnumerator m_Enumerator;
            private static Queue m_InstancePool;
            private Map m_Map;
            private Map.SectorEnumeratorType m_Type;
        }

        private class ZComparer : IComparer
        {
            // Methods
            static ZComparer()
            {
                Map.ZComparer.Default = new Map.ZComparer();
            }

            public ZComparer()
            {
            }

            public int Compare(object x, object y)
            {
                Item item1 = ((Item) x);
                Item item2 = ((Item) y);
                int num1 = item1.Z;
                return num1.CompareTo(item2.Z);
            }


            // Fields
            public static readonly IComparer Default;
        }
    }
}

