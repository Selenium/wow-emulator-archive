using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for UnitBase.
	/// </summary>
	[UpdateObject(MaxFields=(int)UNITFIELDS.MAX)]
	public class UnitBase : LivingObject
	{
		private string m_name;
		private int m_creatureFlags;
		private int m_creatureType;
		private int m_creatureFamily;

		private ulong m_guid;
		private uint m_entry;
		private float m_scale = 1.0f;

		private uint m_movementFlags = 0;
		private Vector m_position = new Vector(0,0,0);
		private float m_facing = 0.0f;

		private int m_health;
		private int m_maxHealth;
		private int m_power;
		private int m_maxPower;
		private POWERTYPE m_powerType;
		private int m_level;
		private int m_faction;
		private int m_displayID;
		private int m_nativedisplayID;
		private int m_money;
		private ulong m_lootowner;
		private int m_respawntime;
		private MobsRegenEvent m_mobsregenevent;
		private CombatEvent m_combatevent;
		private AgroManagementEvent m_agromanagementevent;
		private Hashtable m_agrotable;

		private ArrayList m_nodes;
		private bool m_isroaming = false;
		bool DidAttack=false;
		
		public UnitBase(DBSpawn spawn) : this(spawn.Creature)
		{
			//m_mindamage = (float)spawn.Min_Damage;
			//m_maxdamage = (float)spawn.Max_Damage;
		}

		public UnitBase(DBCreature creature)
		{
			m_name = creature.Name;
			m_creatureFlags = creature.Flags;
			m_npcflags = creature.NPCFlags;
			m_creatureType = creature.CreatureType;
			m_creatureFamily = creature.CreatureFamily;
			

			m_guid = ObjectManager.NextGUID();
			m_entry = creature.ObjectId;
		
			InitializeUnit();

			m_respawntime = 10; // Default respawn time
		}
		
		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject (isClient);
		}

		public override void SaveAndRemove()
		{
			if(MapTile != null)
				MapTile.Map.Leave(this);
			ObjectManager.RemoveWorldObject(this);
		}

		public void InitializeUnit() 
		{
			m_agrotable = new Hashtable();
			m_mobsregenevent = null;
			ObjectManager.AddWorldObject(this);
		}

		#region Creature Properties
		public override string Name
		{
			get {return m_name;}
		}

		public int CreatureFlags
		{
			get { return m_creatureFlags;}
		}

		public int CreatureType
		{
			get { return m_creatureType;}
		}

		public int CreatureFamily
		{
			get { return m_creatureFamily;}
		}

		public override int AttackPower
		{
			get	{return 0;}
			set {}
		}

		public override int AttackPowerModifier
		{
			get	{return 0;}
			set {}
		}

		public override int Money
		{
			get {return m_money;}
			set {m_money = value;}
		}

		public int RespawnTime
		{
			get {return m_respawntime;}
			set {m_respawntime = value;}
		}

		public ulong LootOwner
		{
			get {return m_lootowner;}
			set {m_lootowner = value;}
		}

		public Hashtable AgroTable
		{
			get {return m_agrotable;}
		}

		public MobsRegenEvent MobsRegenEvent
		{
			get {return m_mobsregenevent;}
			set {m_mobsregenevent = value;}
		}

		public CombatEvent UnitCombatEvent
		{
			get {return m_combatevent;}
			set {m_combatevent = value;}
		}

		public AgroManagementEvent AgroManagementEvent
		{
			get {return m_agromanagementevent;}
			set {m_agromanagementevent = value;}
		}

		public ArrayList RoamingNodes
		{
			get {return m_nodes;}
			set {m_nodes = value;}
		}
		public bool IsRoaming
		{
			get {return m_isroaming;}
			set {m_isroaming = value;}
		}
		#endregion

		#region Object Properties
			public override OBJECTTYPE ObjectType
		{
			get {return OBJECTTYPE.UNIT;}
		}

		public override uint MovementFlags
		{
			get {return m_movementFlags;}
			set { m_movementFlags = value;}
		}

		public override Vector Position
		{
			get { return m_position;}
			set {m_position = value;}
		}

		public override float Facing
		{
			get { return m_facing;}
			set { m_facing = value;}
		}
		#endregion

		#region OBJECTFIELDS
		public override ulong GUID
		{
			get { return m_guid;}
		}

		public override uint Entry
		{
			get {return m_entry;}
			set {}
		}

		public override HIER_OBJECTTYPE HierType
		{
			get {return HIER_OBJECTTYPE.UNIT;}
		}

		public override float Scale
		{
			get { return m_scale;}
			set { m_scale = value; UpdateValue(OBJECTFIELDS.SCALE);}
		}
		#endregion

		#region UNITFIELDS
		public override int Health
		{
			get {return m_health;}
			set {m_health = value;UpdateValue(UNITFIELDS.HEALTH);}
		}

		public override int MaxHealth
		{
			get {return m_maxHealth;}
			set {m_maxHealth = value;UpdateValue(UNITFIELDS.MAX_HEALTH);}
		}

		public override int Power
		{
			get {return m_power;}
			set {m_power = value;UpdateValue(((int)UNITFIELDS.POWER0) + (int)m_powerType);}
		}

		public override int MaxPower
		{
			get {return m_maxPower;}
			set {m_maxPower = value;UpdateValue(((int)UNITFIELDS.MAX_POWER0) + (int)m_powerType);}
		}

		public override POWERTYPE PowerType
		{
			get {return m_powerType;}
			set {m_powerType = value;UpdateValue(UNITFIELDS.BYTES_0);}
		}

		public override int Level
		{
			get {return m_level;}
			set {m_level = value;UpdateValue(UNITFIELDS.LEVEL);}
		}

		public override int Faction
		{
			get {return m_faction;}
			set {m_faction = value;UpdateValue(UNITFIELDS.FACTION);}
		}

		public override int DisplayID
		{
			get {return m_displayID;}
			set {m_displayID = value;UpdateValue(UNITFIELDS.DISPLAYID);}
		}

		public override int nativeDisplayID
		{
			get {return m_nativedisplayID;}
			set {m_nativedisplayID = value;UpdateValue(UNITFIELDS.NATIVE_DISPLAYID);}
		}

	//	[UpdateValueAttribute(UNITFIELDS.TARGET)]
		protected ulong m_target;
		public override ulong Target
		{
			get {return m_target;}
			set {m_target = value; UpdateValue(UNITFIELDS.TARGET);}
		}
		#endregion

		#region UnusedStats
		public override int Agility
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int BaseAgility
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int BaseIntellect
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int BaseSpirit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int BaseStamina
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int BaseStrength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int Intellect
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int Spirit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int Stamina
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override int Strength
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		#endregion

		#region Resistances
		public override int Resist_Physical
		{
			get	{return 0;}
			set {}
		}

		public override int Resist_Holy
		{
			get	{return 0;}
			set {}
		}

		public override int Resist_Fire
		{
			get	{return 0;}
			set {}
		}

		public override int Resist_Nature
		{
			get	{return 0;}
			set {}
		}

		public override int Resist_Frost
		{
			get	{return 0;}
			set {}
		}

		public override int Resist_Shadow
		{
			get	{return 0;}
			set {}
		}
		#endregion

		#region PLAYERFIELDS
		public override int SkillPoints
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		public override int TalentPoints
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		public override uint GuildID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		public override uint GuildRank
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		public override uint GuildTimeStamp
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		#endregion

/// <summary>
/// The Following methods are linked to combat
/// </summary>
		public void StartCombat(ulong targetID)
		{
			this.Target = targetID;
			this.Attacking = true;
			this.UpdateData();
			if (this.UnitCombatEvent == null) {
				this.UnitCombatEvent = new CombatEvent(this);
				EventManager.AddEvent(this.UnitCombatEvent);
			}
			if (this.AgroManagementEvent == null) {
				this.AgroTable.Clear();
				this.AgroManagementEvent = new AgroManagementEvent(this);
				EventManager.AddEvent(this.AgroManagementEvent);
			}
			/*
			if (!this.InRound)
			{
				this.AgroTable.Clear();
				EventManager.AddEvent(new CombatEvent(this));
//				EventManager.AddEvent(new ChasingEvent(this));
				EventManager.AddEvent(new AgroManagementEvent(this));
			}
			*/
			ServerPacket pkg4 = new ServerPacket(SMSG.ATTACKSTART);
			pkg4.Write(this.GUID);
			pkg4.Write(this.Target);
			pkg4.Finish();
			MapTile.Map.Send(pkg4, this.Position, 25.0f);
			this.Roaming = false;
			this.UpdateData();
		}

		public void StopCombat()
		{
			this.Target = 0;
			this.Attacking = false;
			this.UnitCombatEvent = null;
			this.AgroManagementEvent = null;
			ServerPacket pkg2 = new ServerPacket(SMSG.ATTACKSTOP);
			pkg2.Write(this.GUID);
			pkg2.Write(this.Target);
			pkg2.Write((uint)0);
			pkg2.Finish();
			this.Roaming = true;
			this.MapTile.Map.Send(pkg2, this.Position, 25.0f);
			if (!this.Dead)
				this.UpdateData();
		}

    public void DealDamage(PlayerObject pobj, int damage)
		{
			if (!this.Dead)
			{
				if (m_agrotable[pobj.CharacterID] == null) {
					m_agrotable.Add(pobj.CharacterID, damage);
				} else {
					int damagedealt = (int)m_agrotable[pobj.CharacterID];
					damagedealt += damage;
					m_agrotable[pobj.CharacterID] = damagedealt;
				}

				this.Health -= damage;
				if (this.Health < 1)
				{
					this.Roaming = false;
					EventManager.AddEvent(new CorpseDespawnEvent((UnitBase)this));
					this.Health=0;
					this.StandState=UNITSTANDSTATE.DEAD;
					this.Dead = true;
					this.DynamicFlags = 1; // If set to 1 there will be loot.
					this.LootOwner = pobj.GUID;
					this.UpdateData();
					
					try {
						// Give xp to the right people.
						int exp = StatManager.CalculateExp(this,pobj);
						int maxdamage = 0;
						Hashtable expdividergroup = new Hashtable();
						Hashtable expdividersolo = new Hashtable();
						foreach (DictionaryEntry de in m_agrotable) {
							maxdamage += (int)de.Value;
							WorldClient aclient = WorldServer.GetClientByCharacterID((uint)de.Key);
							if (aclient.Player.Group == null) {
								expdividersolo.Add(aclient.Player.CharacterID, (int)de.Value);
							} else {
								if (expdividergroup[aclient.Player.Group.LeaderGUID] == null) {
									expdividergroup.Add(aclient.Player.Group.LeaderGUID, (int)de.Value);
								} else {
									int damagedealt = (int)expdividergroup[aclient.Player.Group.LeaderGUID];
									damagedealt += (int)de.Value;
									expdividergroup[aclient.Player.Group.LeaderGUID] = damagedealt;
								}
							}
						}

						// Solo players
						foreach (DictionaryEntry de in expdividersolo) {
							float expbit = ((int)de.Value / (float)maxdamage);
							WorldClient aclient = WorldServer.GetClientByCharacterID((uint)de.Key);
							if (aclient != null) {
								aclient.Player.GainXp(Convert.ToInt32(exp * expbit), this.GUID) ;
							}
						}

						// Group players
						foreach (DictionaryEntry de in expdividergroup)	{
							WorldClient aclient = WorldServer.GetClientByCharacterID(Convert.ToUInt32((ulong)de.Key));
							if (aclient != null) {
								GroupObject gobj = aclient.Player.Group;
								float expbit = (((int)de.Value / (float)maxdamage) / (float)gobj.Size);
								for (int i = 0; i < gobj.Size; i++) {
									gobj.Members[i].GainXp(Convert.ToInt32(exp * expbit), this.GUID);
								}
							}
						}
					} catch (Exception exp) {
						DebugLogger.Log("", exp);
					}
				}
				else
				{
					this.UpdateData();
					if (this.MobsRegenEvent == null)
					{
						this.MobsRegenEvent = new MobsRegenEvent(this);
						EventManager.AddEvent(this.MobsRegenEvent);
					}
				}
			}
		}

		public class CombatEvent : WorldEvent
		{
			UnitBase attacker;
			PlayerObject target;
			WorldClient aclient;

			public CombatEvent(UnitBase monster) : base(TimeSpan.FromMilliseconds(1))
			{  
				attacker = monster; 
				aclient = (WorldClient)WorldServer.GetClientByCharacterID((uint)attacker.Target);
				//Console.WriteLine("New combat event attacker: " + attacker.Name + " -> " + aclient.Player.Name);
			}

			private void Kill()
			{
				attacker.StopCombat();
				attacker = null;
				target = null;
				EventManager.RemoveEvent(this);
				return;
			}

			public override void FireEvent()
			{
				try
				{ 
					attacker.InRound = false;
					attacker.DidAttack=false;
					if(aclient.Player==null) 
					{
						this.Kill();
						return;
					}
					//Console.WriteLine("CombatEvent.FireEvent (" + aclient.Player.Name + "): " + attacker.Name);

					aclient = WorldServer.GetClientByCharacterID((uint)attacker.Target);
					if(attacker.Dead) {this.Kill();return;}
					target = aclient.Player;
				}
				catch(Exception) {this.Kill();return;}

				if(aclient.Player.Position.Distance(attacker.Position) > 50)
				{
					Console.WriteLine("Ennemy out of range! Stopping attack");
					this.Kill();
					return;
				}

				if(aclient.Player.Dead || aclient.Player.RezSickness) {this.Kill();return;}				
				
				uint hitflag;
				uint victimstate;
				int damage;
				int blocked;
				attacker.InRound = true;
				StatManager.CalculateMeleeDamage(attacker, target, out hitflag, out victimstate, out damage, out blocked);
				if (aclient.Player.Position.Distance(attacker.Position) < 2.75f) //So they dont get free hits from 20 feet away
				{
					attacker.DidAttack=true;
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
					pkg2.Write((int)0);
					pkg2.Finish();
					attacker.MapTile.Map.Send(pkg2, attacker.Position, 25.0f);

					target.DealDamage(attacker, damage);
					if (target.Dead)
						attacker.StopCombat();
				}
				else 
				{
					ChasingEvent chase = new ChasingEvent(attacker);
					chase.FireEvent();
				}

				int nextEvent=(attacker.DidAttack?attacker.BaseAttackTime:1000);
				eventTime = DateTime.Now.Add(TimeSpan.FromMilliseconds(nextEvent));
				EventManager.AddEvent(this);
				return;
			}
		}
	}

	/// <summary>
	/// The Following events are linked to corpse despawn
	/// </summary>

	public class CorpseDespawnEvent : WorldEvent
	{
		UnitBase m_corpse;
		public CorpseDespawnEvent(UnitBase corpse) : base(TimeSpan.FromSeconds(30))
		{
			m_corpse = corpse;
		}
		public override void FireEvent()
		{
			m_corpse.SaveAndRemove();
			EventManager.AddEvent(new MobsRespawnEvent(m_corpse));
		}
	}

	/// <summary>
	/// The Following events are linked to mobs respawn
	/// </summary>

	public class MobsRespawnEvent : WorldEvent
	{
		UnitBase m_mobs;
		public MobsRespawnEvent(UnitBase mobs) : base(TimeSpan.FromSeconds(mobs.RespawnTime))
		{
			m_mobs = mobs;
		}
		public override void FireEvent()
		{
			// Here is the respawn code :)
			Console.WriteLine("Trying to respawn mobs: "+m_mobs.Name + " - ID: " + (uint)m_mobs.Spawn_ID + " - Time: "+m_mobs.RespawnTime);
			DBSpawn spawn = (DBSpawn)DBManager.GetDBObject(typeof(DBSpawn), (uint)m_mobs.Spawn_ID);
			if (spawn != null) {
				m_mobs.Position = spawn.Position;
				MapManager.GetMap(spawn.WorldMapID).CreateSpawn(spawn, m_mobs);
				m_mobs.InitializeUnit();
			}
		}
	}

	/// <summary>
	/// The Following events are linked to mobs regen
	/// </summary>
	public class MobsRegenEvent : WorldEvent
	{
		UnitBase m_mobs;

		public MobsRegenEvent(UnitBase mobs) : base(TimeSpan.FromSeconds(3))
		{
			m_mobs = mobs;
		}

		public override void FireEvent()
		{
			if(!m_mobs.Dead && m_mobs.Health < m_mobs.MaxHealth)
			{
				//Console.WriteLine("MobsRegenEvent.FireEvent: " + m_mobs.Name);

				StatManager.CalculateRegenTick(m_mobs);
				m_mobs.UpdateData();
				eventTime = DateTime.Now.Add(TimeSpan.FromSeconds(3));
				EventManager.AddEvent(this);
			}
			else
			{
				m_mobs.MobsRegenEvent = null;
			}
		}
	}

	/// <summary>
	/// The Following events are linked to mob chasing
	/// </summary>

	public class ChasingEvent : WorldEvent
	{
		UnitBase mob;
		WorldClient client;
		ulong currenttarget;
		public ChasingEvent(UnitBase mob) : base(TimeSpan.FromMilliseconds(0))
		{
			this.mob = mob;
			currenttarget = 0;
		}

		public override void FireEvent()
		{
			// Mob has changed target
			if (this.currenttarget != mob.Target)
			{
				client = (WorldClient)WorldServer.GetClientByCharacterID((uint)this.mob.Target);
				if (client == null)
					this.mob.StopCombat();
				else
					this.currenttarget = mob.Target;
			}
			//Console.WriteLine("ChasingEvent.FireEvent (" + (client != null ? client.Player.Name : "") + "): " + mob.Name);

			if(client!= null && client.Player.InWorld && !client.Player.Dead && !mob.Dead)
			{
				try
				{

					float distance = client.Player.Position.Distance(mob.Position);
					//				if(distance > 4)
					//				{
					int time = (int)((distance/mob.RunningSpeed)*1000);
					ServerPacket pkg = new ServerPacket(SMSG.MONSTER_MOVE);
					pkg.Write(mob.GUID);
					pkg.WriteVector(mob.Position);
					pkg.Write(mob.Facing);
					pkg.Write((byte)0);
					pkg.Write(0x100);
					pkg.Write(time);
					pkg.Write(1);
					if (client!=null && client.Player!=null)
						mob.Position.Translate(client.Player.Position,1.5f-(client.Player.Position.Distance(client.Player.LastPosition)*0.5f));
					
					pkg.Write(mob.Position.X);
					pkg.Write(mob.Position.Y);
					pkg.Write(mob.Position.Z);
					pkg.Finish();
					mob.MapTile.SendSurrounding(pkg);
					mob.UpdateData();
					client.Player.UpdateData();
				}
				catch (Exception exp) 
				{
					DebugLogger.Log("", exp);
				}
					//				eventTime = DateTime.Now.Add(TimeSpan.FromSeconds(1));
					//				EventManager.AddEvent(this);
			}
		}
	}

	/// <summary>
	/// The Following events are linked to AgroManagement
	/// </summary>

	public class AgroManagementEvent : WorldEvent
	{
		UnitBase m_mob;
		public AgroManagementEvent(UnitBase mob) : base(TimeSpan.FromSeconds(2))
		{
			m_mob = mob;
		}

		public override void FireEvent()
		{
			if(!m_mob.Dead && m_mob.Attacking)
			{
				int maxdamage = 0;
				int maxagro = 0;
				uint target = 0;
				foreach (DictionaryEntry de in m_mob.AgroTable)
					maxdamage += (int)de.Value;

				if (maxdamage > 0)
				{
					foreach (DictionaryEntry de in m_mob.AgroTable)
					{
						int agro = Convert.ToInt32((((int)de.Value / (float)maxdamage) * (float)100.0));
						if (agro > maxagro) {
							maxagro = agro;
							target = (uint)de.Key;
						}
					}

					if ((ulong)target != m_mob.Target) {
						m_mob.Target = (ulong)target;
						//Console.WriteLine("AgroManagementEvent: " + m_mob.Name + " switching target");
					}
				}

				eventTime = DateTime.Now.Add(TimeSpan.FromSeconds(2));
				EventManager.AddEvent(this);
			}
		}
	}

}

