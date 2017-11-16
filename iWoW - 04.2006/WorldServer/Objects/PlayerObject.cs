using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;
//using WorldScripts.Group;
using WoWDaemon.World;
//using WoWDaemon.World.GroupManager;

namespace WoWDaemon.World
{
	[UpdateObjectAttribute(MaxFields=(int)PLAYERFIELDS.MAX)]
	public class PlayerObject : LivingObject
	{
		protected bool inWorld = true;
		protected DBCharacter m_character;
		protected bool m_rezSickness;
		protected int m_nextLevelExp;
		protected float m_scale;
		protected int m_displayID;
		protected int m_nativedisplayID;
		protected ulong m_target;
		protected byte m_playerFlags;
		protected ACCESSLEVEL m_accessLevel;
		protected bool m_pvp=false;
		[UpdateValueAttribute(PLAYERFIELDS.FIELD_MOD_DAMAGE_DONE_POS)]
		protected int m_moddamagedone = 1;
		//		[UpdateValueAttribute(PLAYERFIELDS.GUILD_TIMESTAMP)]
		//		protected uint m_guildtimestamp=WorldClock.GetTimeStamp();
		protected bool m_hasshield = false;
		protected CombatEvent m_combatevent;
		//		[UpdateValueAttribute(PLAYERFIELDS.SKILL_INFO, ArraySize=384)]
		//		protected uint [] m_skill_info;

		public PlayerObject(DBCharacter c) : base()
		{
			m_character = c;			
			m_character.Health = c.Health;
			m_character.MaxHealth = c.MaxHealth;
			m_character.Power = c.Power;
			m_character.MaxPower = c.MaxPower;
			m_character.BaseStrength = c.BaseStrength;
			m_character.BaseStamina = c.BaseStamina;
			m_character.BaseAgility = c.BaseAgility;
			m_character.BaseIntellect = c.BaseIntellect;
			m_character.BaseSpirit = c.BaseSpirit;
			m_character.AttackPower = c.AttackPower;
			m_character.AttackPowerModifier = c.AttackPowerModifier;
			m_character.GuildID=c.GuildID;
			m_character.GuildRank=c.GuildRank;
			m_character.GuildTimeStamp=WorldClock.GetTimeStamp();

			
			m_scale = c.Scale;
			m_displayID = c.DisplayID;	
			m_nativedisplayID = c.DisplayID;
			m_playerFlags = 0;
			m_accessLevel = ACCESSLEVEL.NORMAL;
			m_baseattacktime = 2000;
			//			m_skill_info = new uint[384];
			//			m_skill_info[0] = 133;	//Just for a test, Mage spell fireball
			Inventory = new PlayerInventory(this);
			if(c.Items != null)
			{
				foreach(DBItem item in c.Items)
					Inventory.CreateItem(item);
			}
			StatManager.CalculateNextLevelExp(this);
			StatManager.CalculateNewStats(this);
		
			ObjectManager.AddWorldObject(this);
			EventManager.AddEvent(new AggrMonsterEvent(this));
			EventManager.AddEvent(new RoamingEvent(this));
		}

		public override void Save()
		{
			m_character.Items = new DBItem[Inventory.ItemCount];
			int n = 0;
			for(int i = 0;i < Inventory.NumSlots;i++)
			{
				if(Inventory[i] != null)
				{
					Inventory[i].Save();
					m_character.Items[n] = Inventory[i].DBItem;
					n++;
				}
			}
			DBManager.SaveDBObject(m_character);			
		}


		public override void SaveAndRemove()
		{
			if(this.MapTile != null)
				MapTile.Map.Leave(this);
			m_character.Items = new DBItem[Inventory.ItemCount];
			int n = 0;
			for(int i = 0;i < Inventory.NumSlots;i++)
			{
				if(Inventory[i] != null)
				{
					Inventory[i].SaveAndRemove();
					m_character.Items[n] = Inventory[i].DBItem;
					n++;
				}
			}
			DBManager.SaveDBObject(m_character);
			DBManager.RemoveDBObject(m_character);
			ObjectManager.RemoveWorldObject(this);
		}


		public void updateTime() 
		{
			BinWriter w = new BinWriter();
			w.Write(WorldClock.GetTimeStamp());
			WorldServer.GetClientByCharacterID((uint)this.GUID).Send(SMSG.GAMETIME_UPDATE,w);

			/*		//BinWriter w = LoginClient.NewPacket(SMSG.LOGIN_SETTIMESPEED);
						/*w.Write((float)0);
						w.Write((int)0);*/
			/*w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			w.Write((byte)1);
			Send(w);

			DateTime time = WorldServer.m_clock.time;	//Moved this code to WorldClock, so I could use the timestamp in other places.
			uint timeSeq = 0;
			
			// 4 bytes of packed time data.  the bits are:
			// high 2 bits - unknown
			timeSeq|=(uint)0;
			// next 5 bits - year
			timeSeq<<=5;
			timeSeq|=(uint)1;
			// next 4 bits - month
			timeSeq<<=4;
			timeSeq|=(uint)time.Month;
			// next 7 bits - day of month
			timeSeq<<=7;
			timeSeq|=(uint)time.Day;
			// next 3 bits - day of week
			timeSeq<<=3;
			timeSeq|=(uint)time.DayOfWeek;
			// next 5 bits - hours
			timeSeq<<=5;
			timeSeq|=(uint)((time.Hour==0) ? 24 : time.Hour );
			// low 6 bits  - minutes
			timeSeq<<=6;
			timeSeq|=(uint)time.Minute;

			BinWriter w = new BinWriter();
			w.Write(timeSeq);
			WorldServer.GetClientByCharacterID((uint)this.GUID).Send(SMSG.GAMETIME_UPDATE,w);
*/
		}


		/// <summary>
		/// This Region stocks all the PlayerProperties that aren't directly linked to an updatevalue. ( Aka serverside data )
		/// </summary>

		#region PlayerProperties
		public uint CharacterID
		{
			get {return m_character.ObjectId;}
		}

		public bool InWorld
		{
			get {return inWorld;}
			set {inWorld = value;}
		}

		public bool RezSickness
		{
			get {return m_rezSickness;}
			set {m_rezSickness = value;}
		}
		public uint WorldMapID
		{
			get {return m_character.WorldMapID;}
			set {m_character.WorldMapID = value;}
		}

		public uint Continent
		{
			get { return m_character.Continent;}
			set { m_character.Continent = value;}
		}
		
		public uint Zone
		{
			get { return m_character.Zone;}
			set { m_character.Zone = value;}
		}

		public GroupObject Group;

		public bool IsLeader=false;

		public Vector LastPosition;

		public ACCESSLEVEL AccessLvl
		{
			get { return m_accessLevel;}
			set { m_accessLevel = value;}
		}

		public bool PvP
		{
			get { return m_pvp;}
			set { m_pvp = value;}
		}

		public bool HasShield 
		{
			get { return m_hasshield;}
			set { m_hasshield = value;}
		}

		public CombatEvent PlayerCombatEvent
		{
			get {return m_combatevent;}
			set {m_combatevent = value;}
		}


		public override string Name
		{
			get
			{
				return m_character.Name;
			}
		}
		#endregion


		/// <summary>
		/// This Region stocks all the ObjectProperties that aren't directly linked to an updatevalue. ( Aka serverside data )
		/// </summary>
		/// 
		#region Object Properties
		public override Vector Position
		{
			get {return m_character.Position;}
			set {m_character.Position = value;}
		}

		public override float Facing
		{
			get {return m_character.Facing;}
			set {m_character.Facing = value;}
		}


		public override uint MovementFlags
		{
			get {return 0;}
			set {}
		}

		public override OBJECTTYPE ObjectType
		{
			get { return OBJECTTYPE.PLAYER;}
		}
		#endregion

		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject (isClient);
			UpdateValue(PLAYERFIELDS.BYTES);
			UpdateValue(PLAYERFIELDS.BYTES_2);
            UpdateValue(PLAYERFIELDS.BYTES_3);
			UpdateValue(PLAYERFIELDS.GUILDID);
			UpdateValue(PLAYERFIELDS.GUILDRANK);
			UpdateValue(PLAYERFIELDS.GUILD_TIMESTAMP);
			Inventory.PreCreateOwner(isClient);
			if(isClient)
			{
				UpdateValue(UNITFIELDS.TARGET);
				UpdateValue(PLAYERFIELDS.SELECTION);
                UpdateValue(PLAYERFIELDS.SELECTION_HIGH);
				UpdateValue(PLAYERFIELDS.XP);
				UpdateValue(PLAYERFIELDS.NEXT_LEVEL_XP);
				UpdateValue(UNITFIELDS.BYTES_1);
				//UpdateValue(PLAYERFIELDS.MOD_DAMAGE_DONE_pos);
                UpdateValue(PLAYERFIELDS.CHARACTER_POINTS1);
                UpdateValue(PLAYERFIELDS.CHARACTER_POINTS2);
				UpdateValue(UNITFIELDS.STR);
				UpdateValue(UNITFIELDS.AGILITY);
				UpdateValue(UNITFIELDS.STAMINA);
				UpdateValue(UNITFIELDS.IQ);
				UpdateValue(UNITFIELDS.SPIRIT);
                UpdateValue(UNITFIELDS.RESISTANCES_01);
                UpdateValue(UNITFIELDS.RESISTANCES_02);
                UpdateValue(UNITFIELDS.RESISTANCES_03);
                UpdateValue(UNITFIELDS.RESISTANCES_04);
                UpdateValue(UNITFIELDS.RESISTANCES_05);
                UpdateValue(UNITFIELDS.RESISTANCES_06);
				//UpdateValue(UNITFIELDS.RESIST_ARCANE);
				UpdateValue(UNITFIELDS.ATTACKPOWER);
				//UpdateValue(UNITFIELDS.ATTACKPOWERMODIFIER);
				UpdateValue(PLAYERFIELDS.FIELD_COINAGE);
				//				UpdateValue(PLAYERFIELDS.SKILL_INFO);  // Dont add this yet - Phaze
			}
		}

		public override void UpdateData()
		{
			ServerPacket pkg = new ServerPacket(SMSG.UPDATE_OBJECT);
			pkg.Write(1);
			pkg.Write((uint)0);  
            pkg.Write((byte)0);  
			UpdateData(pkg, false, false);
			pkg.Finish();
			if(MapTile != null)
				MapTile.SendSurrounding(pkg, this);
			ServerPacket pkg2 = new ServerPacket(SMSG.UPDATE_OBJECT);
			pkg2.Write(1);
            //pkg2.Write((char)0xFF);
			//pkg2.Write((byte)0);  // A9 Fix by Phaze
			UpdateData(pkg2, true, true);
			pkg2.Finish();
			pkg2.AddDestination(this.CharacterID);
			WorldServer.Send(pkg2);
		}

		#region OBJECTFIELDS
		public override ulong GUID
		{
			get { return m_character.ObjectId;}
		}

		public override float Scale
		{
			get {return m_scale;}
			set
			{
				m_scale = value;
				UpdateValue(OBJECTFIELDS.SCALE);
			}
		}

		public override HIER_OBJECTTYPE HierType
		{
			get {return HIER_OBJECTTYPE.PLAYER;}
		}
		#endregion

		#region UNITFIELDS
		public override int Health
		{
			get {return m_character.Health;}
			set {m_character.Health = value;UpdateValue(UNITFIELDS.HEALTH);}
		}

		public override int MaxHealth
		{
			get {return m_character.MaxHealth;}
			set {m_character.MaxHealth = value;UpdateValue(UNITFIELDS.MAXHEALTH);}
		}

		public override POWERTYPE PowerType
		{
			get {return m_character.PowerType;}
			set {m_character.PowerType = value;UpdateValue(UNITFIELDS.BYTES_0);}
		}

		public override int Power
		{
			get {return m_character.Power;}
			set {m_character.Power = value; UpdateValue(UNITFIELDS.POWER1+(int)m_character.PowerType);}
		}

		public override int MaxPower
		{
			get {return m_character.MaxPower;}
			set {m_character.MaxPower = value;UpdateValue(UNITFIELDS.MAXPOWER1+(int)m_character.PowerType);}
		}

		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=0)]
		public RACE Race
		{
			get {return m_character.Race;}
		}
		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=1)]
		public CLASS Class
		{
			get {return m_character.Class;}
		}
        
		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=2)]
		public byte Gender
		{
			get {return m_character.Gender;}
		}

		public override int Level
		{
			get {return m_character.Level;}
			set {m_character.Level = (byte)value;UpdateValue(UNITFIELDS.LEVEL);}
		}


		public override int DisplayID
		{
			get { return m_displayID;}
			set {m_displayID = value;UpdateValue(UNITFIELDS.DISPLAYID);}
		}

		public override int Faction
		{
			get {return m_character.Faction;}
			set {m_character.Faction = value;UpdateValue(UNITFIELDS.FACTIONTEMPLATE);}
		}

		public override ulong Target
		{
			get {return m_target;}
			set { m_target = value; UpdateValue(UNITFIELDS.TARGET);}
		}

		[UpdateValueAttribute(UNITFIELDS.AURA)]
		protected ulong m_aura00;
		public ulong Aura00
		{
			get {return m_aura00;}
			set { UpdateValue(UNITFIELDS.AURA); m_aura00 = value;}
		}

		[UpdateValueAttribute(UNITFIELDS.AURAAPPLICATIONS)]
		protected ulong m_auraApplications0;
		public ulong AuraApplications0
		{
			get {return m_auraApplications0;}
			set { UpdateValue(UNITFIELDS.AURAAPPLICATIONS); m_auraApplications0 = value;}
		}

		[UpdateValueAttribute(UNITFIELDS.AURALEVELS)]
		protected ulong m_auraLevels0;
		public ulong AuraLevels0
		{
			get {return m_auraLevels0;}
			set { UpdateValue(UNITFIELDS.AURALEVELS); m_auraLevels0 = value;}
		}
		#endregion

		#region PLAYERFIELDS
		[UpdateValueAttribute(PLAYERFIELDS.XP)]
		public int Exp
		{
			get { return m_character.Exp;}
			set
			{
				m_character.Exp = value;
				UpdateValue(PLAYERFIELDS.XP);
			}
		}

		[UpdateValueAttribute(PLAYERFIELDS.NEXT_LEVEL_XP)]
		public int NextLevelExp
		{
			get { return m_nextLevelExp;}
			set { m_nextLevelExp = value;UpdateValue(PLAYERFIELDS.NEXT_LEVEL_XP); }
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_1_0)]
		public uint VisibleItem1
		{
			get { return VisibleItems[0];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_2_0)]
		public uint VisibleItem2
		{
			get { return VisibleItems[1];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_3_0)]
		public uint VisibleItem3
		{
			get { return VisibleItems[2];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_4_0)]
		public uint VisibleItem4
		{
			get { return VisibleItems[3];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_5_0)]
		public uint VisibleItem5
		{
			get { return VisibleItems[4];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_6_0)]
		public uint VisibleItem6
		{
			get { return VisibleItems[5];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_7_0)]
		public uint VisibleItem7
		{
			get { return VisibleItems[6];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_8_0)]
		public uint VisibleItem8
		{
			get { return VisibleItems[7];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_9_0)]
		public uint VisibleItem9
		{
			get { return VisibleItems[8];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_10_0)]
		public uint VisibleItem10
		{
			get { return VisibleItems[9];}
		}

		/*[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_11_0)]
		public uint VisibleItem11
		{
			get { return VisibleItems[10];}
		}
        */

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_12_0)]
		public uint VisibleItem12
		{
			get { return VisibleItems[11];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_13_0)]
		public uint VisibleItem13
		{
			get { return VisibleItems[12];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_14_0)]
		public uint VisibleItem14
		{
			get { return VisibleItems[13];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_15_0)]
		public uint VisibleItem15
		{
			get { return VisibleItems[14];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_16_0)]
		public uint VisibleItem16
		{
			get { return VisibleItems[15];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_17_0)]
		public uint VisibleItem17
		{
			get { return VisibleItems[16];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_18_0)]
		public uint VisibleItem18
		{
			get { return VisibleItems[17];}
		}

		[UpdateValueAttribute(PLAYERFIELDS.VISIBLE_ITEM_19_0)]
		public uint VisibleItem19
		{
			get { return VisibleItems[18];}
		}

		//Was testing with the skill_info fields, but not much luck yet - Phaze
		/*		public uint SkillInfo
				{
					get { return m_skill_info[0];}
					set { m_skill_info[0] = value;UpdateValue(PLAYERFIELDS.SKILL_INFO); }
				}
		*/

        [UpdateValueAttribute(PLAYERFIELDS.CHARACTER_POINTS1)]
		public override int SkillPoints
		{
			get { return m_character.SkillPoints;}
            set { m_character.SkillPoints = value; UpdateValue(PLAYERFIELDS.CHARACTER_POINTS1); }
		}

        [UpdateValueAttribute(PLAYERFIELDS.CHARACTER_POINTS2)]
		public override int TalentPoints
		{
			get { return m_character.TalentPoints;}
            set { m_character.TalentPoints = value; UpdateValue(PLAYERFIELDS.CHARACTER_POINTS2); }
		}

		[UpdateValueAttribute(PLAYERFIELDS.GUILDID)]
		public override uint GuildID
		{
			get { return m_character.GuildID;}
			set { m_character.GuildID = value;UpdateValue(PLAYERFIELDS.GUILDID);}
		}

		[UpdateValueAttribute(PLAYERFIELDS.GUILDRANK)]
		public override uint GuildRank
		{
			get { return (uint)m_character.GuildRank;}
			set { m_character.GuildRank = (uint)value;UpdateValue(PLAYERFIELDS.GUILDRANK); }
		}

		[UpdateValueAttribute(PLAYERFIELDS.GUILD_TIMESTAMP)]
		public override uint GuildTimeStamp
		{
			get { return m_character.GuildTimeStamp;}
			set { m_character.GuildTimeStamp = value;UpdateValue(PLAYERFIELDS.GUILD_TIMESTAMP); }
		}

		public int ModDamageDone
		{
			get { return m_moddamagedone;}
			set { m_moddamagedone = value;UpdateValue(PLAYERFIELDS.FIELD_MOD_DAMAGE_DONE_POS); }
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES, BytesIndex=0)]
		public byte Skin
		{
			get { return m_character.Skin;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES, BytesIndex=1)]
		public byte Face
		{
			get { return m_character.Face;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES, BytesIndex=2)]
		public byte HairStyle
		{
			get { return m_character.HairStyle;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES, BytesIndex=3)]
		public byte HairColor
		{
			get { return m_character.HairColor;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=0)]
		public byte PlayerFlags
		{
			get { return m_playerFlags;}
			set { m_playerFlags = value;UpdateValue(PLAYERFIELDS.BYTES_2); }
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=1)]
		public byte FacialHairStyle
		{
			get { return m_character.FacialHairStyle;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=2)]
		public byte NumBankSlots
		{
			get { return 0;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=3)]
		public RESTEDSTATE RestedState
		{
			get { return m_character.RestedState;}
			set {  m_character.RestedState = value; UpdateValue(PLAYERFIELDS.BYTES_2);}
		}

		[UpdateValueAttribute(PLAYERFIELDS.SELECTION)]
		protected ulong m_selection;
		WorldObject m_SelectedObject = null;
		public WorldObject Selection
		{
			get { return m_SelectedObject;}
			set
			{
				m_SelectedObject = value;
				if(m_SelectedObject != null)
					m_selection = m_SelectedObject.GUID;
				UpdateValue(PLAYERFIELDS.SELECTION);
			}
		}

		[UpdateValueAttribute(UNITFIELDS.STR)]
		public override int BaseStrength
		{
			get { return m_character.BaseStrength;}
			set { m_character.BaseStrength = value;UpdateValue(UNITFIELDS.STR);}
		}

		[UpdateValueAttribute(UNITFIELDS.AGILITY)]
		public override int BaseAgility
		{
			get {return m_character.BaseAgility;}
			set {m_character.BaseAgility = value; UpdateValue(UNITFIELDS.AGILITY);}
		}

		[UpdateValueAttribute(UNITFIELDS.STAMINA)]
		public override int BaseStamina
		{
			get	{return m_character.BaseStamina;}
			set {m_character.BaseStamina = value;UpdateValue(UNITFIELDS.STAMINA);}
		}

		[UpdateValueAttribute(UNITFIELDS.IQ)]
		public override int BaseIntellect
		{
			get {return m_character.BaseIntellect;}
			set {m_character.BaseIntellect = value;UpdateValue(UNITFIELDS.IQ);}
		}

		[UpdateValueAttribute(UNITFIELDS.SPIRIT)]
		public override int BaseSpirit
		{
			get	{return m_character.BaseSpirit;}
			set {m_character.BaseSpirit = value;UpdateValue(UNITFIELDS.SPIRIT);}
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_01)]
		public override int Resist_Physical
		{
			get {return m_character.Resist_Physical;}
            set { m_character.Resist_Physical = value; UpdateValue(UNITFIELDS.RESISTANCES_01); }
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_02)]
		public override int Resist_Holy
		{
			get {return m_character.Resist_Holy;}
            set { m_character.Resist_Holy = value; UpdateValue(UNITFIELDS.RESISTANCES_02); }
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_03)]
		public override int Resist_Fire
		{
			get {return m_character.Resist_Fire;}
            set { m_character.Resist_Fire = value; UpdateValue(UNITFIELDS.RESISTANCES_03); }
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_04)]
		public override int Resist_Nature
		{
			get {return m_character.Resist_Nature;}
            set { m_character.Resist_Nature = value; UpdateValue(UNITFIELDS.RESISTANCES_04); }
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_05)]
		public override int Resist_Frost
		{
			get {return m_character.Resist_Frost;}
            set { m_character.Resist_Frost = value; UpdateValue(UNITFIELDS.RESISTANCES_05); }
		}

        [UpdateValueAttribute(UNITFIELDS.RESISTANCES_06)]
		public override int Resist_Shadow
		{
			get {return m_character.Resist_Shadow;}
            set { m_character.Resist_Shadow = value; UpdateValue(UNITFIELDS.RESISTANCES_06); }
		}

		[UpdateValueAttribute(UNITFIELDS.ATTACKPOWER)]
		public override int AttackPower
		{
			get {return m_character.AttackPower;}
			set {m_character.AttackPower = value;UpdateValue(UNITFIELDS.ATTACKPOWER);}
		}

        [UpdateValueAttribute(UNITFIELDS.ATTACK_POWER_MODS)]
		public override int AttackPowerModifier
		{
			get {return m_character.AttackPowerModifier;}
            set { m_character.AttackPowerModifier = value; UpdateValue(UNITFIELDS.ATTACK_POWER_MODS); }
		}
	
		[UpdateValueAttribute(PLAYERFIELDS.FIELD_COINAGE)]
		public override int Money
		{
			get {return m_character.Money;}
			set {m_character.Money = value;UpdateValue(PLAYERFIELDS.FIELD_COINAGE);}
		}


		[UpdateValueAttribute]
		public readonly PlayerInventory Inventory;
		#endregion


		public void StartCombat(ulong TargetID)
		{
			Target=TargetID;
			Attacking=true;
			UpdateData();
			if (this.PlayerCombatEvent == null) 
			{
				this.PlayerCombatEvent = new CombatEvent(this);
				EventManager.AddEvent(this.PlayerCombatEvent);
			}
			/*
			if (!InRound)				
				EventManager.AddEvent(new CombatEvent(this));
			else
				Console.WriteLine("Still in combat");
//			Combat.CombatStart((LivingObject)this);	
			*/
			this.LastPosition=this.Position;
			ServerPacket pkg4 = new ServerPacket(SMSG.ATTACKSTART);
            pkg4.Write((char)0xFF);
			pkg4.Write(GUID);
			pkg4.Write(Target);
			pkg4.Finish();
			MapTile.Map.Send(pkg4, Position, 25.0f);
		}

		public void StopCombat()
		{
			this.Attacking = false;
			ServerPacket pkg2 = new ServerPacket(SMSG.ATTACKSTOP);
            pkg2.Write((char)0xFF);
			pkg2.Write(this.GUID);
			pkg2.Write(this.Target);
			pkg2.Write((uint)0);
			pkg2.Finish();
			this.MapTile.Map.Send(pkg2, this.Position, 50f);
		}

		public void DealDamage(LivingObject lobj, int damage)
		{
			this.Health -= damage;
			if (this.Health < 1)
			{
				this.Health=0;
				this.StandState=UNITSTANDSTATE.DEAD;
				this.Dead = true;
				this.UpdateData();
			}
			else
			{
				this.UpdateData();
			}
		}

		public class CombatEvent : WorldEvent
		{
			PlayerObject attacker;
			LivingObject target;
			WorldClient aclient;
			//			Vector LastPosition;
			Random random =new Random();

			public CombatEvent(PlayerObject player) : base(TimeSpan.FromMilliseconds(1))
			{
				aclient = WorldServer.GetClientByCharacterID((uint)player.GUID);
				aclient.Player.LastPosition=aclient.Player.Position;

				//target = (LivingObject)ObjectManager.GetWorldObjectByGUID(aclient.Player.Target);
				//Console.WriteLine("New combat event attacker: " + player.Name + " -> " + target.Name);
			}

			private void Kill()
			{
				try
				{
					if(aclient.Player!=null)
					{
						aclient.Player.StopCombat();
						aclient.Player.PlayerCombatEvent = null;
						attacker=null;
						target=null;
					}
				}
				catch(Exception){}
				EventManager.RemoveEvent(this);
				return;
			}

			public override void FireEvent()
			{
				try
				{ 
					if(aclient.Player==null) 
					{
						this.Kill();
						return;
					}

					attacker = aclient.Player;
					attacker.InRound = false;
					target = (LivingObject)ObjectManager.GetWorldObjectByGUID(aclient.Player.Target);
					if(attacker.Dead) {this.Kill();return;}
	
					if ((!attacker.Attacking) || target.Dead)
					{
						this.Kill();
						return;
					}
					//Console.WriteLine("Fire combat event attacker: " + attacker.Name + " -> " + target.Name);

					float angle = (float)(aclient.Player.Position.Angle(target.Position) * 180/Math.PI);
					float facing = (float)(aclient.Player.Facing * 180/Math.PI) % 360;

					if (angle < 0) 
						angle += 360;
					
					// Try to normalize so that foc (field of combat)
					// is between 30 and -30 deg
					float dif = (angle - facing) % 360;
					if (dif > 180) 
						dif = 360 - dif;

					if (Math.Abs(dif) > 35) 
					{
						//Console.WriteLine("Look where you are fighting: " + attacker.Name + " -> " + target.Name);
					} 
					else 
					{
						uint hitflag;
						uint victimstate;
						int damage;
						int blocked;
						StatManager.CalculateMeleeDamage(attacker, target, out hitflag, out victimstate, out damage, out blocked);
						if (aclient.Player.Position.Distance(target.Position)+aclient.Player.Position.Distance(aclient.Player.LastPosition) <= 2.5) //So they dont get free hits from 20 feet away
						{
							attacker.InRound = true;

							ServerPacket pkg2 = new ServerPacket(SMSG.ATTACKERSTATEUPDATE);
							pkg2.Write((uint)hitflag);
							pkg2.Write(attacker.GUID);
							pkg2.Write(target.GUID);
							pkg2.Write((int)damage);
							pkg2.Write((byte)1);
							pkg2.Write((uint)0);
							pkg2.Write((float)damage);
							pkg2.Write((int)damage);
							pkg2.Write((int)0);
							pkg2.Write((uint)victimstate); 
							pkg2.Write((uint)0);
							pkg2.Write((uint)0);
							pkg2.Write((uint)0);
							pkg2.Write((int)blocked);
							pkg2.Finish();
							attacker.MapTile.Map.Send(pkg2, attacker.Position, 25.0f);
			
							if (target.ObjectType==OBJECTTYPE.UNIT)
							{
								UnitBase uobj = (UnitBase)target;
								uobj.DealDamage(attacker, damage);
								if (uobj.Dead)
									attacker.StopCombat();
							}
						} 
						else 
						{
							//Console.WriteLine("Your are to far away to hit mob: " + attacker.Name + " -> " + target.Name);
						}
					}
					aclient.Player.LastPosition=aclient.Player.Position;
					int nextEvent=(attacker.InRound?attacker.BaseAttackTime:1000);
					eventTime = DateTime.Now.Add(TimeSpan.FromMilliseconds(nextEvent));
					EventManager.AddEvent(this);
					return;
				}
				catch(Exception e) 
				{
					this.Kill();
					Console.WriteLine("This exception happened in Combat Event. Probably, someone just disconnected while in combat. It won't crash server though!");
					Console.WriteLine(e);
					return;
				}
			}
		}

		public void GainXp(int exp, ulong targetguid)
		{
			ServerPacket pkg = new ServerPacket(SMSG.LOG_XPGAIN);
			pkg.Write(targetguid);
			pkg.Write((uint)exp);
			pkg.Write((byte)0);
			pkg.Write((ushort)exp);
			pkg.Write((byte)0);
			pkg.Write((byte)0);
			pkg.Finish();
			pkg.AddDestination(this.CharacterID);
			WorldServer.Send(pkg);

			this.Exp+=exp;
			this.UpdateData();	

			if (this.Exp >= this.NextLevelExp)
				LevelUp();
		}

		public void LevelUp()
		{
			int maxhealth = this.MaxHealth;
			int maxpower = this.MaxPower;

			this.Level++;
			StatManager.CalculateNextLevelExp(this);
			this.Exp = 0;
			StatManager.CalculateNewStats(this);
			this.Health = this.MaxHealth;
			this.Power = this.MaxPower;
			UpdateData();
			Save();

			ServerPacket pkg = new ServerPacket(SMSG.LEVELUP_INFO);
			pkg.Write((uint)this.Level);
			pkg.Write((uint)(this.MaxHealth - maxhealth));
			pkg.Write((uint)(this.MaxPower - maxpower));
			pkg.Write((uint)0);
			pkg.Write((uint)0);
			pkg.Write((uint)0);

			pkg.Write((uint)0);
			pkg.Write((uint)0);
			pkg.Write((uint)0);
			pkg.Write((uint)0);
			pkg.Write((uint)0);
			pkg.Write((uint)0);

			pkg.Finish();
			pkg.AddDestination(this.CharacterID);
			WorldServer.Send(pkg);
		}
	}

	/// <summary>
	/// Following classes handle the player respawn!
	/// </summary>
	[WorldPacketHandler()]
	public class Respawn
	{
		[WorldPacketDelegate(CMSG.REPOP_REQUEST)]
		static void OnRespawn(WorldClient client, CMSG msgID, BinReader data)
		{
			client.Player.PlayerFlags |= (byte)0x10;
			client.Player.Flags |= 0x10000;
			client.Player.Health = 30;
			client.Player.Dead = true;
			client.Player.StandState = UNITSTANDSTATE.STANDING;
			client.Player.UpdateData();
			GhostEvent ghostevent = new GhostEvent(client.Player);
			Chat.System(client,"You have been resurrected. You will remain a ghost for one minute! Next time, do not die!");
		}
	}

	public class GhostEvent : WorldEvent
	{
		PlayerObject m_player;
		public GhostEvent(PlayerObject player) : base(TimeSpan.FromSeconds(60))
		{
			m_player = player;
			m_player.RezSickness = true;
			EventManager.AddEvent(this);
		}

		public override void FireEvent()
		{
			m_player.RezSickness = false;
			m_player.Health = m_player.MaxHealth;
			m_player.PlayerFlags ^= (byte)0x10;
			m_player.Flags ^= 0x10000;
			m_player.Dead = false;
			m_player.UpdateData();
		}
	}

	
	/// <summary>
	/// Following classes handle the aggro mobs!
	/// </summary>
	public class AggrMonsterEvent : WorldEvent
	{
		PlayerObject m_player;

		public AggrMonsterEvent(PlayerObject player) : base(TimeSpan.FromSeconds(1))
		{
			m_player = player;
		}
		public void AttackNearestPlayer() 
		{
			if ( m_player.MapTile != null && !m_player.Dead )
			{
				foreach(UnitBase monster in m_player.MapTile.Map.GetObjectsInRange(OBJECTTYPE.UNIT,m_player.Position,30f) )
				{
					// Monster attacks nearest player 
					float angle = m_player.Position.Angle(monster.Position);

					if ( monster.MapTile != null && angle <= 1.6f  && angle >= -0.5f 
						&& !monster.Dead && !monster.Attacking && monster.Level > 5 && monster.Faction == (int)FACTION.MONSTER
						&& m_player.Position.Distance(monster.Position) <= (float)(monster.Level) )
					{	
						monster.StartCombat(m_player.GUID);						
					}
				}
			}
		}
		
		public override void FireEvent()
		{
			// Deals with the Event
			if(m_player.MapTile == null)
				return;
			AttackNearestPlayer();
			eventTime = DateTime.Now.AddSeconds(2);
			EventManager.AddEvent(this);
		}
	}

	/// <summary>
	/// Following classes handle the Roaming mobs!
	/// </summary>
	public class RoamingEvent : WorldEvent
	{
		PlayerObject m_player;

		static Random random = new Random();

		public RoamingEvent(PlayerObject player) : base(TimeSpan.FromSeconds(1))
		{
			m_player = player;
		}	

		void AddNode(Vector position,UnitBase unit)
		{
			if(unit.RoamingNodes==null)
			{
				unit.RoamingNodes = new ArrayList(10);
			}
			for(int i = 0;i < unit.RoamingNodes.Count;i++)
			{
				Vector v = (Vector)(unit.RoamingNodes[i]);
				if(v.X == position.X &&
					v.Y == position.Y &&
					v.Z == position.Z)
					return;
			}
			unit.RoamingNodes.Add(new Vector(position.X, position.Y, position.Z));
		}

		void GetWalkNode(UnitBase unit,PlayerObject player)
		{ 
			AddNode(player.Position,unit);
		}

		public override void FireEvent()
		{
			try
			{
				if( !m_player.InWorld )
				{
					EventManager.RemoveEvent(this);
					return;
				}
				foreach(UnitBase unit in m_player.MapTile.Map.GetObjectsInRange(OBJECTTYPE.UNIT,m_player.Position,30f) )
				{
					if(unit.Roaming)
					{
						if(unit.RoamingNodes==null)
						{
							// Here we could have a connection to DBRoam ...
							unit.RoamingNodes = new ArrayList(10);
						}
						
						if(unit.RoamingNodes.Count < 10 )
						{
							GetWalkNode(unit,m_player);
						}
						else if(!unit.IsRoaming)
						{
							unit.IsRoaming = true;
							EventManager.AddEvent(new RandomWalkEvent(unit,m_player));
						}
					}
				}	
				eventTime = DateTime.Now.Add(TimeSpan.FromSeconds(2));
				EventManager.AddEvent(this);
			}
			catch(Exception e)
			{
				Console.WriteLine("RoamingEvent Exception: "+e.Message);
			}
		}
		

		protected class RandomWalkEvent : WorldEvent
		{
			UnitBase m_unit;
			PlayerObject m_player;

			public RandomWalkEvent(UnitBase unit,PlayerObject player) : base(TimeSpan.FromSeconds(1))
			{
				m_unit = unit;
				m_player = player;
			}

			void WalkToVector(Vector v, int time,UnitBase unit)
			{
				ServerPacket pkg = new ServerPacket(SMSG.MONSTER_MOVE);
                pkg.Write((char)0xFF);
				pkg.Write(unit.GUID);
				pkg.WriteVector(unit.Position);
				pkg.Write(unit.Facing);
				pkg.Write((byte)0);
				pkg.Write(0x000);
				pkg.Write(time);
				pkg.Write(1);
				pkg.WriteVector(v);
				pkg.Finish();
				unit.MapTile.SendSurrounding(pkg);
			}

			public override void FireEvent()
			{
				if(m_unit.StandState==UNITSTANDSTATE.DEAD 
					|| m_unit.MapTile == null 
					|| m_unit.RoamingNodes.Count != 10
					|| m_unit.Position.Distance(m_player.Position) > 40.0f)
				{
					m_unit.IsRoaming = false;
					EventManager.RemoveEvent(this);
					return;
				}
				Vector v = (Vector)m_unit.RoamingNodes[random.Next(m_unit.RoamingNodes.Count)];
				float distance = m_unit.Position.Distance(v);
				int time = (int)((distance/m_unit.WalkSpeed)*1000);
				if(m_unit.Target==0)
				{
					WalkToVector(v, time, m_unit);
					m_unit.Facing = m_unit.Position.Angle(v);
					m_unit.Position = v;
					MapManager.Move(m_unit);
				}
				eventTime = DateTime.Now.Add(TimeSpan.FromMilliseconds(time + 5000 + random.Next(6)*1000));
				EventManager.AddEvent(this);
			}
		}
			
	}

}
