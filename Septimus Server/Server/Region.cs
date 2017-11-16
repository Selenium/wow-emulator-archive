namespace Server
{
    using Server.Network;
    using Server.Targeting;
    using System;
    using System.Collections;
    using System.IO;
    using System.Xml;

    public class Region : IComparable
    {
        // Methods
        static Region()
        {
            Region.m_InnLogoutDelay = TimeSpan.Zero;
            Region.m_GMLogoutDelay = TimeSpan.FromSeconds(10);
            Region.m_DefaultLogoutDelay = TimeSpan.FromMinutes(5);
            Region.m_RegionUID = 1;
            Region.m_Regions = new ArrayList();
        }

        public Region(string prefix, string name, Map map)
        {
            this.m_Music = MusicName.Invalid;
            this.m_MinZ = -32768;
            this.m_MaxZ = 32767;
            this.m_Prefix = prefix;
            this.m_Name = name;
            this.m_Map = map;
            this.m_Priority = 0;
            this.m_GoLoc = Point3D.Zero;
            this.m_Players = new ArrayList();
            this.m_Mobiles = new ArrayList();
            this.m_Load = true;
            this.m_UId = Region.m_RegionUID++;
        }

        public Region(string prefix, string name, Map map, int uid) : this(prefix, name, map)
        {
            this.m_UId = (uid | 1073741824);
        }

        public static void AddRegion(Region region)
        {
            Region.m_Regions.Add(region);
            region.Register();
            region.Map.Regions.Add(region);
            region.Map.Regions.Sort();
        }

        public virtual bool AllowBenificial(Mobile from, Mobile target)
        {
            if (Mobile.AllowBeneficialHandler != null)
            {
                return Mobile.AllowBeneficialHandler(from, target);
            }
            return true;
        }

        public virtual bool AllowHarmful(Mobile from, Mobile target)
        {
            if (Mobile.AllowHarmfulHandler != null)
            {
                return Mobile.AllowHarmfulHandler(from, target);
            }
            return true;
        }

        public virtual bool AllowHousing(Mobile from, Point3D p)
        {
            return true;
        }

        public virtual bool AllowSpawn()
        {
            return true;
        }

        public virtual void AlterLightLevel(Mobile m, ref int global, ref int personal)
        {
        }

        public virtual bool CanUseStuckMenu(Mobile m)
        {
            return true;
        }

        public virtual bool CheckAccessibility(Item item, Mobile from)
        {
            return true;
        }

        public int CompareTo(object o)
        {
            if (!(o is Region))
            {
                return 0;
            }
            Region region1 = ((Region) o);
            int num1 = region1.m_Priority;
            int num2 = this.m_Priority;
            if (num1 < num2)
            {
                return -1;
            }
            if (num1 > num2)
            {
                return 1;
            }
            return 0;
        }

        public virtual bool Contains(Point3D p)
        {
            int num1;
            object obj1;
            Rectangle3D rectangled1;
            Rectangle2D rectangled2;
            if (this.m_Coords == null)
            {
                return false;
            }
            for (num1 = 0; (num1 < this.m_Coords.Count); ++num1)
            {
                obj1 = this.m_Coords[num1];
                if ((obj1 is Rectangle3D))
                {
                    rectangled1 = ((Rectangle3D) obj1);
                    if (rectangled1.Contains(p))
                    {
                        return true;
                    }
                }
                else if ((obj1 is Rectangle2D))
                {
                    rectangled2 = ((Rectangle2D) obj1);
                    if ((rectangled2.Contains(p) && (p.m_Z >= this.m_MinZ)) && (p.m_Z <= this.m_MaxZ))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual void Deserialize(GenericReader reader)
        {
            reader.ReadInt();
        }

        public override bool Equals(object o)
        {
            if (!(o is Region) || (o == null))
            {
                return false;
            }
            return (((Region) o) == this);
        }

        public static Region Find(Point3D p, Map map)
        {
            int num1;
            Region region1;
            if (map == null)
            {
                return Map.Internal.DefaultRegion;
            }
            Sector sector1 = map.GetSector(p);
            ArrayList list1 = sector1.Regions;
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                region1 = ((Region) list1[num1]);
                if (region1.Contains(p))
                {
                    return region1;
                }
            }
            return map.DefaultRegion;
        }

        public static Region FindByUId(int uid)
        {
            int num1;
            Region region1;
            for (num1 = 0; (num1 < Region.m_Regions.Count); ++num1)
            {
                region1 = ((Region) Region.m_Regions[num1]);
                if (region1.UId == uid)
                {
                    return region1;
                }
            }
            return null;
        }

        public static Region GetByName(string name, Map map)
        {
            int num1;
            Region region1;
            for (num1 = 0; (num1 < Region.m_Regions.Count); ++num1)
            {
                region1 = ((Region) Region.m_Regions[num1]);
                if ((region1.Map == map) && (region1.Name == name))
                {
                    return region1;
                }
            }
            return null;
        }

        public override int GetHashCode()
        {
            return this.m_UId;
        }

        public virtual TimeSpan GetLogoutDelay(Mobile m)
        {
            if (((m.Aggressors.Count == 0) && (m.Aggressed.Count == 0)) && this.IsInInn(m.Location))
            {
                return Region.m_InnLogoutDelay;
            }
            if (m.AccessLevel >= AccessLevel.GameMaster)
            {
                return Region.m_GMLogoutDelay;
            }
            return Region.m_DefaultLogoutDelay;
        }

        public virtual Type GetResource(Type type)
        {
            return type;
        }

        public void InternalEnter(Mobile m)
        {
            if (m.Player && !this.m_Players.Contains(m))
            {
                this.m_Players.Add(m);
                m.CheckLightLevels(false);
                this.OnPlayerAdd(m);
            }
            if (!this.m_Mobiles.Contains(m))
            {
                this.m_Mobiles.Add(m);
                this.OnMobileAdd(m);
            }
            this.OnEnter(m);
            this.PlayMusic(m);
        }

        public void InternalExit(Mobile m)
        {
            if (m.Player && this.m_Players.Contains(m))
            {
                this.m_Players.Remove(m);
                this.OnPlayerRemove(m);
            }
            if (this.m_Mobiles.Contains(m))
            {
                this.m_Mobiles.Remove(m);
                this.OnMobileRemove(m);
            }
            this.OnExit(m);
            this.StopMusic(m);
        }

        public virtual bool IsInInn(Point3D p)
        {
            int num1;
            Rectangle2D rectangled1;
            if (this.m_InnBounds == null)
            {
                return false;
            }
            for (num1 = 0; (num1 < this.m_InnBounds.Count); ++num1)
            {
                rectangled1 = ((Rectangle2D) this.m_InnBounds[num1]);
                if (rectangled1.Contains(p))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsNull(Region r)
        {
            return object.ReferenceEquals(r, null);
        }

        public static void Load()
        {
            string text1;
            Map map1;
            string text2;
            Region region1;
            XmlElement element4;
            string text3;
            Region region2;
            if (!File.Exists("Data/Regions.xml"))
            {
                Console.WriteLine("Error: Data/Regions.xml does not exist");
                return;
            }
            Console.Write("Regions: Loading...");
            XmlDocument document1 = new XmlDocument();
            document1.Load("Data/Regions.xml");
            XmlElement element1 = document1["ServerRegions"];
            foreach (XmlElement element2 in element1.GetElementsByTagName("Facet"))
            {
                text1 = element2.GetAttribute("name");
                map1 = null;
                try
                {
                    map1 = Map.Parse(text1);
                }
                catch
                {
                }
                if ((map1 == null) || (map1 == Map.Internal))
                {
                    if (Region.m_SupressXmlWarnings)
                    {
                        continue;
                    }
                    Console.WriteLine("Regions.xml: Invalid facet name \'{0}\'", text1);
                    continue;
                }
                foreach (XmlElement element3 in element2.GetElementsByTagName("region"))
                {
                    text2 = element3.GetAttribute("name");
                    if ((text2 != null) && (text2.Length > 0))
                    {
                        region1 = Region.GetByName(text2, map1);
                        if (region1 != null)
                        {
                            if (!region1.LoadFromXml)
                            {
                                if (Region.m_SupressXmlWarnings)
                                {
                                    continue;
                                }
                                Console.WriteLine("Regions.xml: Region \'{0}\' has an XML entry, but is set not to LoadFromXml.", text2);
                                continue;
                            }
                            try
                            {
                                region1.Priority = int.Parse(element3.GetAttribute("priority"));
                            }
                            catch
                            {
                                if (!Region.m_SupressXmlWarnings)
                                {
                                    Console.WriteLine("Regions.xml: Could not parse priority for region \'{0}\' (assuming TownPriority)", region1.Name);
                                }
                                region1.Priority = 50;
                            }
                            element4 = element3["go"];
                            if (element4 != null)
                            {
                                try
                                {
                                    region1.GoLocation = Point3D.Parse(element4.GetAttribute("location"));
                                }
                                catch
                                {
                                    if (!Region.m_SupressXmlWarnings)
                                    {
                                        Console.WriteLine("Regions.xml: Could not parse go location for region \'{0}\'", region1.Name);
                                    }
                                }
                            }
                            element4 = element3["music"];
                            if (element4 != null)
                            {
                                try
                                {
                                    region1.Music = ((MusicName) Enum.Parse(typeof(MusicName), element4.GetAttribute("name"), true));
                                }
                                catch
                                {
                                    if (!Region.m_SupressXmlWarnings)
                                    {
                                        Console.WriteLine("Regions.xml: Could not parse music for region \'{0}\'", region1.Name);
                                    }
                                }
                            }
                            element4 = element3["zrange"];
                            if (element4 != null)
                            {
                                text3 = element4.GetAttribute("min");
                                if ((text3 != null) && (text3 != ""))
                                {
                                    try
                                    {
                                        region1.MinZ = int.Parse(text3);
                                    }
                                    catch
                                    {
                                        if (!Region.m_SupressXmlWarnings)
                                        {
                                            Console.WriteLine("Regions.xml: Could not parse zrange:min for region \'{0}\'", region1.Name);
                                        }
                                    }
                                }
                                text3 = element4.GetAttribute("max");
                                if ((text3 != null) && (text3 != ""))
                                {
                                    try
                                    {
                                        region1.MaxZ = int.Parse(text3);
                                    }
                                    catch
                                    {
                                        if (!Region.m_SupressXmlWarnings)
                                        {
                                            Console.WriteLine("Regions.xml: Could not parse zrange:max for region \'{0}\'", region1.Name);
                                        }
                                    }
                                }
                            }
                            foreach (XmlElement element5 in element3.GetElementsByTagName("rect"))
                            {
                                try
                                {
                                    if (region1.m_LoadCoords == null)
                                    {
                                        region1.m_LoadCoords = new ArrayList(1);
                                    }
                                    region1.m_LoadCoords.Add(Region.ParseRectangle(element5, true));
                                    continue;
                                }
                                catch
                                {
                                    if (Region.m_SupressXmlWarnings)
                                    {
                                        continue;
                                    }
                                    Console.WriteLine("Regions.xml: Error parsing rect for region \'{0}\'", region1.Name);
                                    continue;
                                }
                            }
                            foreach (XmlElement element6 in element3.GetElementsByTagName("inn"))
                            {
                                try
                                {
                                    if (region1.InnBounds == null)
                                    {
                                        region1.InnBounds = new ArrayList(1);
                                    }
                                    region1.InnBounds.Add(Region.ParseRectangle(element6, false));
                                    continue;
                                }
                                catch
                                {
                                    if (Region.m_SupressXmlWarnings)
                                    {
                                        continue;
                                    }
                                    Console.WriteLine("Regions.xml: Error parsing inn for region \'{0}\'", region1.Name);
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                }
            }
            ArrayList list1 = new ArrayList(Region.m_Regions);
            int num1 = 0;
            while ((num1 < list1.Count))
            {
                region2 = ((Region) list1[num1]);
                if (!region2.LoadFromXml && (region2.m_Coords == null))
                {
                    region2.Coords = new ArrayList();
                }
                else if (region2.LoadFromXml)
                {
                    if (region2.m_LoadCoords == null)
                    {
                        region2.m_LoadCoords = new ArrayList();
                    }
                    region2.Coords = region2.m_LoadCoords;
                }
                ++num1;
            }
            for (num1 = 0; (num1 < Map.AllMaps.Count); ++num1)
            {
                ((Map) Map.AllMaps[num1]).Regions.Sort();
            }
            ArrayList list2 = new ArrayList(World.Mobiles.Values);
            foreach (Mobile mobile1 in list2)
            {
                mobile1.ForceRegionReEnter(true);
            }
            Console.WriteLine("done");
        }

        public virtual void MakeGuard(Mobile focus)
        {
        }

        public virtual void OnAggressed(Mobile aggressor, Mobile aggressed, bool criminal)
        {
        }

        public virtual bool OnBeginSpellCast(Mobile m, ISpell s)
        {
            return true;
        }

        public virtual void OnBenificialAction(Mobile helper, Mobile target)
        {
        }

        public virtual bool OnCombatantChange(Mobile m, Mobile Old, Mobile New)
        {
            return true;
        }

        public virtual void OnCriminalAction(Mobile m, bool message)
        {
            if (message)
            {
                m.SendLocalizedMessage(1005040);
            }
        }

        public virtual bool OnDamage(Mobile m, ref int Damage)
        {
            return true;
        }

        public virtual bool OnDeath(Mobile m)
        {
            return true;
        }

        public virtual bool OnDecay(Item item)
        {
            return true;
        }

        public virtual void OnDidHarmful(Mobile harmer, Mobile harmed)
        {
        }

        public virtual bool OnDoubleClick(Mobile m, object o)
        {
            return true;
        }

        public virtual void OnEnter(Mobile m)
        {
            object[] objArray1;
            string text1 = this.ToString();
            if (text1 != "")
            {
                objArray1 = new object[1];
                objArray1[0] = this;
                m.SendMessage("You have entered {0}", objArray1);
            }
        }

        public virtual void OnExit(Mobile m)
        {
            object[] objArray1;
            string text1 = this.ToString();
            if (text1 != "")
            {
                objArray1 = new object[1];
                objArray1[0] = this;
                m.SendMessage("You have left {0}", objArray1);
            }
        }

        public virtual void OnGotBenificialAction(Mobile helper, Mobile target)
        {
        }

        public virtual void OnGotHarmful(Mobile harmer, Mobile harmed)
        {
        }

        public virtual bool OnHeal(Mobile m, ref int Heal)
        {
            return true;
        }

        public virtual void OnLocationChanged(Mobile m, Point3D oldLocation)
        {
        }

        public virtual void OnMobileAdd(Mobile m)
        {
        }

        public virtual void OnMobileRemove(Mobile m)
        {
        }

        public virtual bool OnMoveInto(Mobile m, Direction d, Point3D newLocation, Point3D oldLocation)
        {
            return true;
        }

        public virtual void OnPlayerAdd(Mobile m)
        {
        }

        public virtual void OnPlayerRemove(Mobile m)
        {
        }

        public virtual bool OnResurrect(Mobile m)
        {
            return true;
        }

        public virtual bool OnSingleClick(Mobile m, object o)
        {
            return true;
        }

        public virtual bool OnSkillUse(Mobile m, int Skill)
        {
            return true;
        }

        public virtual void OnSpeech(SpeechEventArgs args)
        {
        }

        public virtual void OnSpellCast(Mobile m, ISpell s)
        {
        }

        public virtual bool OnTarget(Mobile m, Target t, object o)
        {
            return true;
        }

        public static bool operator ==(Region l, Region r)
        {
            if (Region.IsNull(l))
            {
                return Region.IsNull(r);
            }
            if (Region.IsNull(r))
            {
                return false;
            }
            return (l.UId == r.UId);
        }

        public static bool operator >(Region l, Region r)
        {
            if (Region.IsNull(l) && Region.IsNull(r))
            {
                return false;
            }
            if (Region.IsNull(l))
            {
                return false;
            }
            if (Region.IsNull(r))
            {
                return true;
            }
            return (l.Priority < r.Priority);
        }

        public static bool operator !=(Region l, Region r)
        {
            if (Region.IsNull(l))
            {
                return !Region.IsNull(r);
            }
            if (Region.IsNull(r))
            {
                return true;
            }
            return (l.UId != r.UId);
        }

        public static bool operator <(Region l, Region r)
        {
            if (Region.IsNull(l) && Region.IsNull(r))
            {
                return false;
            }
            if (Region.IsNull(l))
            {
                return true;
            }
            if (Region.IsNull(r))
            {
                return false;
            }
            return (l.Priority > r.Priority);
        }

        public static object ParseRectangle(XmlElement rect, bool supports3d)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            if ((rect.HasAttribute("x") && rect.HasAttribute("y")) && (rect.HasAttribute("width") && rect.HasAttribute("height")))
            {
                num1 = int.Parse(rect.GetAttribute("x"));
                num2 = int.Parse(rect.GetAttribute("y"));
                num3 = (num1 + int.Parse(rect.GetAttribute("width")));
                num4 = (num2 + int.Parse(rect.GetAttribute("height")));
            }
            else if ((rect.HasAttribute("x1") && rect.HasAttribute("y1")) && (rect.HasAttribute("x2") && rect.HasAttribute("y2")))
            {
                num1 = int.Parse(rect.GetAttribute("x1"));
                num2 = int.Parse(rect.GetAttribute("y1"));
                num3 = int.Parse(rect.GetAttribute("x2"));
                num4 = int.Parse(rect.GetAttribute("y2"));
            }
            else
            {
                throw new ArgumentException("Wrong attributes specified.");
            }
            if (supports3d && (rect.HasAttribute("zmin") || rect.HasAttribute("zmax")))
            {
                num5 = -32768;
                num6 = 32767;
                if (rect.HasAttribute("zmin"))
                {
                    num5 = int.Parse(rect.GetAttribute("zmin"));
                }
                if (rect.HasAttribute("zmax"))
                {
                    num6 = int.Parse(rect.GetAttribute("zmax"));
                }
                return new Rectangle3D(num1, num2, num5, (num3 - num1), (num4 - num2), ((num6 - num5) + 1));
            }
            return new Rectangle2D(num1, num2, (num3 - num1), (num4 - num2));
        }

        public virtual void PlayMusic(Mobile m)
        {
            if ((this.m_Music != MusicName.Invalid) && (m.NetState != null))
            {
                m.Send(PlayMusic.GetInstance(this.m_Music));
            }
        }

        public virtual void Register()
        {
            object obj1;
            Point2D pointd1;
            Point2D pointd2;
            Rectangle2D rectangled1;
            Rectangle3D rectangled2;
            Sector sector1;
            Sector sector2;
            int num2;
            int num3;
            if ((this.m_Coords == null) || (this.m_Map == null))
            {
                return;
            }
            int num1 = 0;
            while ((num1 < this.m_Coords.Count))
            {
                obj1 = this.m_Coords[num1];
                if ((obj1 is Rectangle2D))
                {
                    rectangled1 = ((Rectangle2D) obj1);
                    pointd1 = this.m_Map.Bound(rectangled1.Start);
                    pointd2 = this.m_Map.Bound(rectangled1.End);
                }
                else
                {
                    if (!(obj1 is Rectangle3D))
                    {
                        goto Label_011D;
                    }
                    rectangled2 = ((Rectangle3D) obj1);
                    pointd1 = this.m_Map.Bound(new Point2D(rectangled2.Start));
                    pointd2 = this.m_Map.Bound(new Point2D(rectangled2.End));
                }
                sector1 = this.m_Map.GetSector(pointd1);
                sector2 = this.m_Map.GetSector(pointd2);
                for (num2 = sector1.X; (num2 <= sector2.X); ++num2)
                {
                    for (num3 = sector1.Y; (num3 <= sector2.Y); ++num3)
                    {
                        this.m_Map.GetRealSector(num2, num3).OnEnter(this);
                    }
                }
            Label_011D:
                ++num1;
            }
        }

        public static void RemoveRegion(Region region)
        {
            int num1;
            Region.m_Regions.Remove(region);
            region.Unregister();
            region.Map.Regions.Remove(region);
            ArrayList list1 = new ArrayList(region.Mobiles);
            for (num1 = 0; (num1 < list1.Count); ++num1)
            {
                ((Mobile) list1[num1]).ForceRegionReEnter(false);
            }
        }

        public virtual bool SendInaccessibleMessage(Item item, Mobile from)
        {
            return false;
        }

        public virtual void Serialize(GenericWriter writer)
        {
            writer.Write(0);
        }

        public virtual void SpellDamageScalar(Mobile caster, Mobile target, ref double damage)
        {
        }

        public virtual void StopMusic(Mobile m)
        {
            if ((this.m_Music != MusicName.Invalid) && (m.NetState != null))
            {
                m.Send(PlayMusic.InvalidInstance);
            }
        }

        public override string ToString()
        {
            if (this.Prefix != "")
            {
                return string.Format("{0} {1}", this.Prefix, this.Name);
            }
            return this.Name;
        }

        public virtual void Unregister()
        {
            object obj1;
            Point2D pointd1;
            Point2D pointd2;
            Rectangle2D rectangled1;
            Rectangle3D rectangled2;
            Sector sector1;
            Sector sector2;
            int num2;
            int num3;
            if ((this.m_Coords == null) || (this.m_Map == null))
            {
                return;
            }
            int num1 = 0;
            while ((num1 < this.m_Coords.Count))
            {
                obj1 = this.m_Coords[num1];
                if ((obj1 is Rectangle2D))
                {
                    rectangled1 = ((Rectangle2D) obj1);
                    pointd1 = this.m_Map.Bound(rectangled1.Start);
                    pointd2 = this.m_Map.Bound(rectangled1.End);
                }
                else
                {
                    if (!(obj1 is Rectangle3D))
                    {
                        goto Label_011D;
                    }
                    rectangled2 = ((Rectangle3D) obj1);
                    pointd1 = this.m_Map.Bound(new Point2D(rectangled2.Start));
                    pointd2 = this.m_Map.Bound(new Point2D(rectangled2.End));
                }
                sector1 = this.m_Map.GetSector(pointd1);
                sector2 = this.m_Map.GetSector(pointd2);
                for (num2 = sector1.X; (num2 <= sector2.X); ++num2)
                {
                    for (num3 = sector1.Y; (num3 <= sector2.Y); ++num3)
                    {
                        this.m_Map.GetRealSector(num2, num3).OnLeave(this);
                    }
                }
            Label_011D:
                ++num1;
            }
        }


        // Properties
        public ArrayList Coords
        {
            get
            {
                return this.m_Coords;
            }
            set
            {
                if (this.m_Coords != value)
                {
                    Region.RemoveRegion(this);
                    this.m_Coords = value;
                    Region.AddRegion(this);
                }
            }
        }

        public static TimeSpan DefaultLogoutDelay
        {
            get
            {
                return Region.m_DefaultLogoutDelay;
            }
            set
            {
                Region.m_DefaultLogoutDelay = value;
            }
        }

        public static TimeSpan GMLogoutDelay
        {
            get
            {
                return Region.m_GMLogoutDelay;
            }
            set
            {
                Region.m_GMLogoutDelay = value;
            }
        }

        public Point3D GoLocation
        {
            get
            {
                return this.m_GoLoc;
            }
            set
            {
                this.m_GoLoc = value;
            }
        }

        public ArrayList InnBounds
        {
            get
            {
                return this.m_InnBounds;
            }
            set
            {
                this.m_InnBounds = value;
            }
        }

        public static TimeSpan InnLogoutDelay
        {
            get
            {
                return Region.m_InnLogoutDelay;
            }
            set
            {
                Region.m_InnLogoutDelay = value;
            }
        }

        public bool IsDefault
        {
            get
            {
                return (this == this.m_Map.DefaultRegion);
            }
        }

        public bool LoadFromXml
        {
            get
            {
                return this.m_Load;
            }
            set
            {
                this.m_Load = value;
            }
        }

        public Map Map
        {
            get
            {
                return this.m_Map;
            }
            set
            {
                Region.RemoveRegion(this);
                this.m_Map = value;
                Region.AddRegion(this);
            }
        }

        public int MaxZ
        {
            get
            {
                return this.m_MaxZ;
            }
            set
            {
                Region.RemoveRegion(this);
                this.m_MaxZ = value;
                Region.AddRegion(this);
            }
        }

        public int MinZ
        {
            get
            {
                return this.m_MinZ;
            }
            set
            {
                Region.RemoveRegion(this);
                this.m_MinZ = value;
                Region.AddRegion(this);
            }
        }

        public ArrayList Mobiles
        {
            get
            {
                return this.m_Mobiles;
            }
        }

        public MusicName Music
        {
            get
            {
                return this.m_Music;
            }
            set
            {
                this.m_Music = value;
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

        public ArrayList Players
        {
            get
            {
                return this.m_Players;
            }
        }

        public string Prefix
        {
            get
            {
                return this.m_Prefix;
            }
            set
            {
                this.m_Prefix = value;
            }
        }

        public int Priority
        {
            get
            {
                return this.m_Priority;
            }
            set
            {
                if (value == this.m_Priority)
                {
                    return;
                }
                this.m_Priority = value;
                if (this.m_Priority < 0)
                {
                    this.m_Priority = 0;
                }
                else if (this.m_Priority > 150)
                {
                    this.m_Priority = 150;
                }
                this.m_Map.Regions.Sort();
            }
        }

        public static ArrayList Regions
        {
            get
            {
                return Region.m_Regions;
            }
        }

        public virtual bool Saves
        {
            get
            {
                return false;
            }
        }

        public static bool SupressXmlWarnings
        {
            get
            {
                return Region.m_SupressXmlWarnings;
            }
            set
            {
                Region.m_SupressXmlWarnings = value;
            }
        }

        public int UId
        {
            get
            {
                return this.m_UId;
            }
        }


        // Fields
        public const int HighestPriority = 150;
        public const int HousePriority = 150;
        public const int InnPriority = 51;
        public const int LowestPriority = 0;
        private ArrayList m_Coords;
        private static TimeSpan m_DefaultLogoutDelay;
        private static TimeSpan m_GMLogoutDelay;
        private Point3D m_GoLoc;
        private ArrayList m_InnBounds;
        private static TimeSpan m_InnLogoutDelay;
        private bool m_Load;
        private ArrayList m_LoadCoords;
        private Map m_Map;
        private int m_MaxZ;
        private int m_MinZ;
        private ArrayList m_Mobiles;
        private MusicName m_Music;
        private string m_Name;
        private ArrayList m_Players;
        private string m_Prefix;
        private int m_Priority;
        private static ArrayList m_Regions;
        private static int m_RegionUID;
        private static bool m_SupressXmlWarnings;
        private int m_UId;
        public const int TownPriority = 50;
    }
}

