   
//#define TESTCONSECUTIF
using System;
using HelperTools;
using System.Collections;
using Server.Items;
using System.Reflection;

namespace Server
{
	#region ENUMS

	public enum AttackStatus : byte
	{
		None = 0,
		NormalHit,
		Loose,
		Absorb,
		Critical,
		Dodge,
		Parry,
		Block,
		Immune
	}
	public enum InvisibilityLevel : int
	{
		Visible = 0,
		Lesser = 1,
		Medium = 2,
		Greater = 3,
		GM = 4,
		True = 5
	}
	public enum StandStates : int
	{
		Standing			= 0,
		Sitting			    = 1,
		SittingChair		= 2,
		Sleeping			= 3,
		SittingChairLow	    = 4,
		SittingChairMedium  = 5,
		SittingChairHigh	= 6,
		Dead				= 7,
		Kneel				= 8,
		CatForm				= 1 << 16,
		TreeFrom			= 2 << 16,
		TravelForm			= 3 << 16,
		AquaticForm			= 4 << 16,
		BearForm			= 5 << 16,
		Ambient				= 6 << 16,
		Goul				= 7 << 16,
		FireBearForm		= 8 << 16,
		GhostWolf			= 16 << 16,
		BattleStance		= 17 << 16,
		DefensiveStance		= 18 << 16,
		BerserkerStance		= 19 << 16,
		ShadowForm			= 28 << 16,
		Stealth				= 30 << 16
	};
	public enum NpcTypes : int
	{
		Beast = 1,
		Dragonkin = 2,
		Demon = 3,
		Elemental = 4,
		Giant = 5,
		Undead = 6,
		Humanoid = 7,
		Critter = 8,
		Mechanical = 9
	}
	public enum NpcActions : uint
	{
		SpiritHealer = 1,
		Dialog = 2,
		Vendor = 4,
		Taxi = 8,
		Trainer = 16,
		Healer = 32,
		BattleFieldSpiritHealer = 0x40,
		InKeeper = 0x80,
		Banker = 0x100,		
		Petition = 0x200,
		Tabard = 0x400,
		BattleMaster = 0x800,
		Auctionner = 0x1000,
		StableMaster = 0x2000
	}
	#endregion


	/// <summary>
	/// Description of Mobile.	
	/// </summary>
	public class Mobile : Object
	{		
		#region TAXI
		private class OnTaxiEndTimer : WowTimer
		{
			Character ch;
			Trajet t;
			public OnTaxiEndTimer( int delay,Character _ch,Trajet _t ) : base( WowTimer.Priorities.Milisec100 , delay, "OnTaxiEndTimer" )
			{
				ch = _ch;
				Start();
				t = _t;
			}
			public override void OnTick()
			{
				Taxi.OnUnmountTaxi(ch,t);
				Stop();
				base.OnTick ();
			}

		}
		
		public void MoveTaxiTo( Trajet t,PathForTaxi.MapIds[] mapIds, int mapChange)
		{
			if (t.Count != 0)
			{
				if (mapChange == 0)
				{
					int offset = 4;
					float x = X - t[0].x;
					float y = Y - t[0].y;
					float z = Z - t[0].z;
					x *= x;
					y *= y;
					z *= z;
					x = (float)Math.Sqrt( x + y + z );
					float distTotale = x;
					for (int j = 0; j < t.Count - 1;j++)
					{
						x = t[j].x - t[j + 1].x;
						y = t[j].y - t[j + 1].y;
						z = t[j].z - t[j + 1].z;
						x *= x;
						y *= y;
						z *= z;
						distTotale += (float)Math.Sqrt( x + y + z );
					}
				
					float xd = (float)( distTotale / ( 37f / 1000 ) );
					int instantSpeed = (int)xd;
					byte []movePacket = new byte[ 60 + t.Count * 3 * 4 ];
					uint time = (uint)( DateTime.Now.Ticks - localTime );
					Converter.ToBytes( Guid, movePacket, ref offset );	
					Converter.ToBytes( (float)X, movePacket, ref offset );//	X
					Converter.ToBytes( (float)Y, movePacket, ref offset );//	Y
					Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
					Converter.ToBytes( (float)this.Orientation, movePacket, ref offset );//	Z	
					Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z	
			
					Converter.ToBytes( (uint)0x00000300, movePacket, ref offset );//	pas d'animation de mouvement, taxi node ?		
							
					Converter.ToBytes( (uint)instantSpeed, movePacket, ref offset );//	Z	
					Converter.ToBytes( (uint)distTotale, movePacket, ref offset );//	Z	
					foreach( Coord c in t )
					{
						Converter.ToBytes( (float)c.x, movePacket, ref offset );//	X
						Converter.ToBytes( (float)c.y, movePacket, ref offset );//	Y
						Converter.ToBytes( (float)c.z, movePacket, ref offset );//	Z
					}
					(this as Character).ToAllPlayerNear(  (OpCodes)0xDD, movePacket, offset );
					OnTaxiEndTimer onTaxiEndTimer = new OnTaxiEndTimer( instantSpeed,this as Character,t );
				}
				else
				{
					if (mapChange == 1 && mapIds[0].index == 0)
					{
						Coord cord = new Coord(this.X,this.Y,this.Z,null,null);
						Coord [] coords= new Coord[1];
						coords[0] = cord;
						Trajet t1 = new Trajet(coords);
						(this as Character).SendMessage("Not supported now");
						OnTaxiEndTimer onTaxiEndTimer1 = new OnTaxiEndTimer(0,this as Character,t1 );
						return;
						//(this as Character).Teleport(t[0].x,t[0].y,t[0].z,30);
						//t.RemoveAt(0);
						//this.MoveTaxiTo( t,mapIds, 0);	
					
					}
					int offset = 4;
					float x = X - t[0].x;
					float y = Y - t[0].y;
					float z = Z - t[0].z;
					x *= x;
					y *= y;
					z *= z;
					x = (float)Math.Sqrt( x + y + z );
					float distTotale = x;
					for (int j = 0; j < t.Count - 1;j++)
					{
						x = t[j].x - t[j + 1].x;
						y = t[j].y - t[j + 1].y;
						z = t[j].z - t[j + 1].z;
						x *= x;
						y *= y;
						z *= z;
						distTotale += (float)Math.Sqrt( x + y + z );
					}
				
					float xd = (float)( distTotale / ( 37f / 1000 ) );
					int instantSpeed = (int)xd;
					byte []movePacket = new byte[ 60 + t.Count * 3 * 4 ];
					uint time = (uint)( DateTime.Now.Ticks - localTime );
					Converter.ToBytes( Guid, movePacket, ref offset );	
					Converter.ToBytes( (float)X, movePacket, ref offset );//	X
					Converter.ToBytes( (float)Y, movePacket, ref offset );//	Y
					Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
					Converter.ToBytes( (float)this.Orientation, movePacket, ref offset );//	Z	
					Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z	
			
					Converter.ToBytes( (uint)0x00000300, movePacket, ref offset );//	pas d'animation de mouvement, taxi node ?		
							
					Converter.ToBytes( (uint)instantSpeed, movePacket, ref offset );//	Z	
					Converter.ToBytes( (uint)distTotale, movePacket, ref offset );//	Z	
					foreach( Coord c in t )
					{
						Converter.ToBytes( (float)c.x, movePacket, ref offset );//	X
						Converter.ToBytes( (float)c.y, movePacket, ref offset );//	Y
						Converter.ToBytes( (float)c.z, movePacket, ref offset );//	Z
					}
					(this as Character).ToAllPlayerNear(  (OpCodes)0xDD, movePacket, offset );
					OnTaxiEndTimer onTaxiEndTimer = new OnTaxiEndTimer( instantSpeed,this as Character,t );
				}
			}
			else
			{}
			
			//	Console.WriteLine( "Je vais mettre {0}", instantSpeed );
		}
		#endregion

		#region PROPERTIES
		object values;
		Hashtable knownAbilities = new Hashtable();
		Hashtable talentList = new Hashtable();
		AttackStatus lastSpellStatus;
		public MoveVector moveVector;
		public Hashtable TalentList
		{
			get
			{
				return talentList;
			}
		}
		int model;
		string name;
		string name2;
		int level;
		UInt32 guildId;
		UInt32 petLevel;
		UInt32 petCreatureFamily;
		UInt32 petDisplayId;
		Classes classe;

		#region bovie test
		ArrayList nextAttackEffects = new ArrayList();
		bool unInteractible;
		#endregion

		#region added properities
		int armorFromItems;
		#endregion
		
		uint npcFlags;
		uint flags1;
		int unk3;
		int unk4;
		int npcType;
		string guild;
		string npcText;
		float size = 1f;
		Item []sells;
		int id;
		Factions faction;
		int str = 20;
		int agility = 20;
		int stamina = 20;
		int iq = 20;
		int spirit = 20;
		float baseStr = 0;
		float baseAgility = 0;
		float baseStamina = 0;
		float baseIq = 0;
		float baseSpirit = 0;
		float speed = 8f;//4.2f;
		float walkSpeed = 2.5f;
		float runSpeed = 7f;
		float swimSpeed = 7f;
		float swimBackSpeed = 4.722222f;
		public float attackSpeed;
		public float castingSpeed = 1f;
		public float rangedAttackSpeed;
		int hitPoints;
		int mana;
		int energy;
		int rage;
		int focus;
		int baseHitPoints;
		int baseMana;
		int baseEnergy;
		int baseRage;
		int baseFocus;
		int armor;
		uint exp;
		byte professions;
		StandStates standState;
		int talent;
		int block;
		int resistArcane;
		int resistHoly;
		int resistFire;
		int resistNature;
		int resistFrost;
		int resistShadow;
		Skills allSkills = new Skills();
		float minDamage = 1;
		float maxDamage = 1;
		int attackBoniiMin = 0;
		int attackBoniiMax = 0;

		BaseTreasure []loots;
		int []trains;
		float boundingRadius = 1.5f;
		float combatReach = 1.5f;
		int quest;
		//	BaseSpawner spawnerLink;
		
		bool freeze;
		Item[] items;

		//WayPointList wayPoints = new WayPointList();
		bool movementChange;
		protected int manaType = 0;
		public ushort viewRange = 20;
		InvisibilityLevel visible = InvisibilityLevel.Visible;

		/// <summary>
		/// 
		/// 
		/// 
		/// </summary>
		protected int itemManaBonus = 0;
		protected int itemHealthBonus = 0;
		protected Item activeWeapon;
		protected Item activeShield;
		int attackPower;
		int rangedAttackPower;
		Mobile summonedBy;
		Mobile summon;
		Mobile charmedBy;
		Mobile charm;		
		protected OnCreatureTick onCreatureTick;
		MovementTimer movementTimer;
		AIStates aiState;
		protected AITypes aiType;
		bool deleted = false;
		long localTime;
		//ArrayList tresure;
		int lootMoney;
		DateTime lastHit = DateTime.Now;
		ArrayList aura = new ArrayList();
		public ArrayList permanentAura = new ArrayList();
		
		SpellCastTimer spellCastTimer;
		bool running;
		DecayTimer decay;
		Loot []skinLoot;
		public Hashtable SpecialForAuras = new Hashtable();
		Hashtable cumulativeAuraEffects = new Hashtable();
		public static Hashtable onInitialiseTalent = new Hashtable();
		int mountModel;
		public Hashtable Triggers = new Hashtable();
		Character lastSeen = null;
		ArrayList additionnalStates = new ArrayList();
		bool godMode;
		int comboPoints;
		AttackStatus lastAttack;
		AttackStatus lastAttackToMe;
		Mobile mounting;
		#endregion

		#region EXTERNAL HANDLERS
		public static SpellHandler onSpellCasted;
		#endregion

		#region ACCESSORS	
		#region AURA EFFECTS
				
		//done

		#region speed
		public float SpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.SpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.SpeedModifier;
				return val;
			}
		}
		public float RunSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.RunSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.RunSpeedModifier;
				return val;
			}
		}
		public float RunSpeedBonus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RunSpeedBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RunSpeedBonus;
				return val;
			}
		}		
		
		public float RunSpeedMalus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RunSpeedMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RunSpeedMalus;
				return val;
			}
		}		
		
		public float SpeedBonus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpeedBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpeedBonus;
				return val;
			}
		}		
		
		public float SpeedMalus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpeedMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpeedMalus;
				return val;
			}
		}		
		
		public float AttackSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.AttackSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.AttackSpeedModifier;
				return val;
			}
		}	
		
		public float RangedAttackSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.RangedAttackSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.RangedAttackSpeedModifier;
				return val;
			}
		}	
		public float CastingSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.CastingSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.CastingSpeedModifier;
				return val;
			}
		}	
		public float AttackPowerModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.AttackPowerModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.AttackPowerModifier;
				return val;
			}
		}	
		public float MountSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.MountSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.MountSpeedModifier;
				return val;
			}
		}	
		public float SwimSpeedModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.SwimSpeedModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.SwimSpeedModifier;
				return val;
			}
		}	
		public float MountSpeedBonus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MountSpeedBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MountSpeedBonus;
				return val;
			}
		}		
		
		public float MountSpeedMalus
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MountSpeedMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MountSpeedMalus;
				return val;
			}
		}		
		
		#endregion

		#region resistance
		public int ArmorBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArmorBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArmorBonus;
				return val;
			}
		}
		public int ArmorMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArmorMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArmorMalus;
				return val;
			}
		}
				
		public float ArmorPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArmorPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArmorPercentBonus;
				return val;
			}
		}
		public float ArmorPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArmorPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArmorPercentMalus;
				return val;
			}
		}
		
		public float ArmorFromItemsPercentIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArmorFromItemsPercentIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArmorFromItemsPercentIncrease;
				return val;
			}
		}
		public int FireResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireResistanceMalus;
				return val;
			}
		}
		public int ArcaneResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneResistanceMalus;
				return val;
			}
		}
		public int FrostResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostResistanceMalus;
				return val;
			}
		}
		public int HolyResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyResistanceMalus;
				return val;
			}
		}
		public int ShadowResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowResistanceMalus;
				return val;
			}
		}
		public int NatureResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureResistanceMalus;
				return val;
			}
		}
		public int FireResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireResistanceBonus;
				return val;
			}
		}
		public int ArcaneResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneResistanceBonus;
				return val;
			}
		}
		public int FrostResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostResistanceBonus;
				return val;
			}
		}
		public int HolyResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyResistanceBonus;
				return val;
			}
		}
		public int ShadowResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowResistanceBonus;
				return val;
			}
		}
		public int NatureResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureResistanceBonus;
				return val;
			}
		}
		public int AllResistanceBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllResistanceBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllResistanceBonus;
				return val;
			}
		}
		public int AllResistanceMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllResistanceMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllResistanceMalus;
				return val;
			}
		}
		public float AllResistancePercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllResistancePercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllResistancePercentBonus;
				return val;
			}
		}
		public float AllResistancePercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllResistancePercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllResistancePercentMalus;
				return val;
			}
		}
		#endregion		

		#region damage taken
		public int DamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.DamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.DamageTakenBonus;
				return val;
			}
		}
		public int DamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.DamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.DamageTakenMalus;
				return val;
			}
		}
		public float DamageTakenModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.DamageTakenModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.DamageTakenModifier;
				return val;
			}
		}
		public int MeleeDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageTakenBonus;
				return val;
			}
		}
		public int MeleeDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageTakenMalus;
				return val;
			}
		}
		public float MeleePercentDamageTakenReduction
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleePercentDamageTakenReduction;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleePercentDamageTakenReduction;
				return val;
			}
		}	
		public float MeleePercentDamageTakenIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleePercentDamageTakenIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleePercentDamageTakenIncrease;
				return val;
			}
		}	
				
		public int RangedDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedDamageTakenBonus;
				return val;
			}
		}
		public int RangedDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedDamageTakenMalus;
				return val;
			}
		}
		public float RangedDamageTakenModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.RangedDamageTakenModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.RangedDamageTakenModifier;
				return val;
			}
		}
		public int FireDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireDamageTakenBonus;
				return val;
			}
		}
		public int FireDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireDamageTakenMalus;
				return val;
			}
		}
		public float FireDamageTakenModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.FireDamageTakenModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.FireDamageTakenModifier;
				return val;
			}
		}
		public float ShadowDamageTakenModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.ShadowDamageTakenModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.ShadowDamageTakenModifier;
				return val;
			}
		}
		public int FrostDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostDamageTakenBonus;
				return val;
			}
		}
		public int FrostDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostDamageTakenMalus;
				return val;
			}
		}
		public int ArcaneDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneDamageTakenBonus;
				return val;
			}
		}
		public int ArcaneDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneDamageTakenMalus;
				return val;
			}
		}
		public int ShadowDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowDamageTakenBonus;
				return val;
			}
		}
		public int ShadowDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowDamageTakenMalus;
				return val;
			}
		}
		public int PhysicalDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalDamageTakenBonus;
				return val;
			}
		}
		public int PhysicalDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalDamageTakenMalus;
				return val;
			}
		}
		public int NatureDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureDamageTakenBonus;
				return val;
			}
		}
		public int NatureDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureDamageTakenMalus;
				return val;
			}
		}
		public int HolyDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyDamageTakenBonus;
				return val;
			}
		}
		public int HolyDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyDamageTakenMalus;
				return val;
			}
		}

		public int SpellDamageTakenBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellDamageTakenBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellDamageTakenBonus;
				return val;
			}
		}
		public int SpellDamageTakenMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellDamageTakenMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellDamageTakenMalus;
				return val;
			}
		}

		#endregion

		#region absorb
		public int FireAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireAbsorb;
				return val;
			}
		}

		public int ArcaneAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneAbsorb;
				return val;
			}
		}
		public int FrostAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostAbsorb;
				return val;
			}
		}
		public int HolyAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyAbsorb;
				return val;
			}
		}
		public int ShadowAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowAbsorb;
				return val;
			}
		}
		public int NatureAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureAbsorb;
				return val;
			}
		}
		public int PhysicalAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalAbsorb;
				return val;
			}
		}
		public int AllDamageAbsorb
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllDamageAbsorb;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllDamageAbsorb;
				return val;
			}
		}
		public int AbsorbAllMagic
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AbsorbAllMagic;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AbsorbAllMagic;
				return val;
			}
		}
		#endregion

		#region shields
		public int ShieldBlockBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShieldBlockBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShieldBlockBonus;
				return val;
			}
		}
		public float ShieldBlockModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.ShieldBlockModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.ShieldBlockModifier;
				return val;
			}
		}
		#endregion

		#region block, dodge, parry, hit
		public int HitBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HitBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HitBonus;
				return val;
			}
		}
		public int HitMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HitMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HitMalus;
				return val;
			}
		}
		public int SpellHitBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellHitBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellHitBonus;
				return val;
			}
		}
		public int SpellHitMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellHitMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellHitMalus;
				return val;
			}
		}
		public int MeleeHitBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeHitBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeHitBonus;
				return val;
			}
		}
		public int RangedHitBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedHitBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedHitBonus;
				return val;
			}
		}
		public int MeleeHitMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeHitMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeHitMalus;
				return val;
			}
		}
		public int RangedHitMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedHitMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedHitMalus;
				return val;
			}
		}

		public int BlockBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.BlockBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.BlockBonus;
				return val;
			}
		}
		public int BlockMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.BlockMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.BlockMalus;
				return val;
			}
		}
		public int ParryBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ParryBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ParryBonus;
				return val;
			}
		}
		public int ParryMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ParryMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ParryMalus;
				return val;
			}
		}
		public int DodgeBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.DodgeBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.DodgeBonus;
				return val;
			}
		}
		public int DodgeMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.DodgeMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.DodgeMalus;
				return val;
			}
		}

		#endregion

		#region critical modificators
		public int PhysicalCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalCriticalBonus;
				return val;
			}
		}
		public int MagicalCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MagicalCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MagicalCriticalBonus;
				return val;
			}
		}
		public int FireCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireCriticalBonus;
				return val;
			}
		}
		public int FrostCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostCriticalBonus;
				return val;
			}
		}
		public int ArcaneCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneCriticalBonus;
				return val;
			}
		}
		public int ShadowCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowCriticalBonus;
				return val;
			}
		}
		public int HolyCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyCriticalBonus;
				return val;
			}
		}
		public int NatureCriticalBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureCriticalBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureCriticalBonus;
				return val;
			}
		}
		#endregion
		
		#region damage done
		public int MeleeDamageBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageBonus;
				return val;
			}
		}
		public int MeleeDamageMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageMalus;
				return val;
			}
		}
		public int RangedDamageBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedDamageBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedDamageBonus;
				return val;
			}
		}
		public int RangedDamageMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedDamageMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedDamageMalus;
				return val;
			}
		}

		public int ManaShield
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaShield;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaShield;
				return val;
			}
		}
		public int AllDamageDoneMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllDamageDoneMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllDamageDoneMalus;
				return val;
			}
		}
		public int AllDamageDoneBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllDamageDoneBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllDamageDoneBonus;
				return val;
			}
		}
		public float AllDamageDoneModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.AllDamageDoneModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.AllDamageDoneModifier;
				return val;
			}
		}
		public float MeleePercentDamageMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleePercentDamageMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleePercentDamageMalus;
				return val;
			}
		}
		public float MeleePercentDamageBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleePercentDamageBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleePercentDamageBonus;
				return val;
			}
		}

		public int MeleeDamageDoneAgainsDemonsBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsDemonsBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsDemonsBonus;
				return val;
			}
		}
		public int MeleeDamageDoneAgainsUndeadBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsUndeadBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsUndeadBonus;
				return val;
			}
		}
		public int MeleeDamageDoneAgainsBeastBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsBeastBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsBeastBonus;
				return val;
			}
		}
		public int MeleeDamageDoneAgainsDragonsBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsDragonsBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsDragonsBonus;
				return val;
			}
		}
		public int MeleeDamageDoneAgainsElementalsBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsElementalsBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsElementalsBonus;
				return val;
			}
		}
		public int MeleeDamageDoneAgainsGiantsBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.MeleeDamageDoneAgainsGiantsBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.MeleeDamageDoneAgainsGiantsBonus;
				return val;
			}
		}
				
		public float FirePercentDamageIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FirePercentDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FirePercentDamageIncrease;
				return val;
			}
		}
		public float ShadowPercentDamageIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowPercentDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowPercentDamageIncrease;
				return val;
			}
		}
		public float NaturePercentDamageIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NaturePercentDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NaturePercentDamageIncrease;
				return val;
			}
		}
		public float FrostPercentDamageIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostPercentDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostPercentDamageIncrease;
				return val;
			}
		}
		public float PhysicalPercentDamageIncrease
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalPercentDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalPercentDamageIncrease;
				return val;
			}
		}

		public int FireDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireDamageIncrease;
				return val;
			}
		}
		public int ShadowDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowDamageIncrease;
				return val;
			}
		}
		public int NatureDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureDamageIncrease;
				return val;
			}
		}
		public int FrostDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostDamageIncrease;
				return val;
			}
		}
		public int ArcaneDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneDamageIncrease;
				return val;
			}
		}
		public int HolyDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyDamageIncrease;
				return val;
			}
		}
		public int PhysicalDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PhysicalDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PhysicalDamageIncrease;
				return val;
			}
		}
		public int AllMagicDamageIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllMagicDamageIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllMagicDamageIncrease;
				return val;
			}
		}
		public int SpellDamageDoneAgainsDemonsBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellDamageDoneAgainsDemonsBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellDamageDoneAgainsDemonsBonus;
				return val;
			}
		}
		public int SpellDamageDoneAgainsUndeadBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpellDamageDoneAgainsUndeadBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpellDamageDoneAgainsUndeadBonus;
				return val;
			}
		}
		public int PetDamageMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PetDamageMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PetDamageMalus;
				return val;
			}
		}
		public int PetDamageBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.PetDamageBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.PetDamageBonus;
				return val;
			}
		}
		#endregion

		#region Healing
		public int HealGiveIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealGiveIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealGiveIncrease;
				return val;
			}
		}
		public int HealGiveDecrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealGiveDecrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealGiveDecrease;
				return val;
			}
		}
		public float HealGiveModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.HealGiveModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.HealGiveModifier;
				return val;
			}
		}		
		public int HealTakeIncrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealTakeIncrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealTakeIncrease;
				return val;
			}
		}
		public int HealTakeDecrease
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealTakeDecrease;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealTakeDecrease;
				return val;
			}
		}
		public float HealTakeModifier
		{
			get
			{
				float val = 1;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.HealTakeModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.HealTakeModifier;
				return val;
			}
		}		
		#endregion

		#region attack power
		public int AttackPowerBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerBonus;
				return val;
			}
		}
		public int AttackPowerMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerMalus;
				return val;
			}
		}
		public int AttackPowerBonusAgainsDemons
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerBonusAgainsDemons;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerBonusAgainsDemons;
				return val;
			}
		}
		public int AttackPowerMalusAgainsDemons
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerMalusAgainsDemons;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerMalusAgainsDemons;
				return val;
			}
		}
		public int AttackPowerBonusAgainsBeast
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerBonusAgainsBeast;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerBonusAgainsBeast;
				return val;
			}
		}
		public int AttackPowerMalusAgainsBeast
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerMalusAgainsBeast;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerMalusAgainsBeast;
				return val;
			}
		}
		public int AttackPowerBonusAgainsGiants
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerBonusAgainsGiants;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerBonusAgainsGiants;
				return val;
			}
		}
		public int AttackPowerMalusAgainsGiants
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerMalusAgainsGiants;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerMalusAgainsGiants;
				return val;
			}
		}
		public int AttackPowerBonusAgainsUndead
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerBonusAgainsUndead;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerBonusAgainsUndead;
				return val;
			}
		}
		public int AttackPowerMalusAgainsUndead
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AttackPowerMalusAgainsUndead;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AttackPowerMalusAgainsUndead;
				return val;
			}
		}
		public int RangedAttackPowerBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedAttackPowerBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedAttackPowerBonus;
				return val;
			}
		}
		public int RangedAttackPowerMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RangedAttackPowerMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RangedAttackPowerMalus;
				return val;
			}
		}
		#endregion

		#region avoid cast
		public int[] AvoidCast
		{
			get
			{
				int[] val = {0,0,0,0,0};
				int i = 0;
				foreach( AuraReleaseTimer art in aura )
				{
					if (val[i] == art.aura.AvoidCastMagicClass)
					{
						i++;
						if (i > 4) return val;
						val[i] = art.aura.AvoidCastMagicClass;
					}

				}	
				foreach( PermanentAura art in permanentAura )
				{
					if (val[i] == art.aura.AvoidCastMagicClass)
					{
						i++;
						if (i > 4) return val;
						val[i] = art.aura.AvoidCastMagicClass;
					}

				}	
				return val;
			}
		}
		#endregion

		#region stats
		public bool SwitchToRage
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.SwitchToRage )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.SwitchToRage )
						return true;
				return false;
			}
		}
		public int StrBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StrBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StrBonus;
				return val;
			}
		}
		public int AgBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AgBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AgBonus;
				return val;
			}
		}
		public int IQBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.IQBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.IQBonus;
				return val;
			}
		}
		public int SpiritBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpiritBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpiritBonus;
				return val;
			}
		}
		public int StaminaBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StaminaBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StaminaBonus;
				return val;
			}
		}	
		public int StrMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StrMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StrMalus;
				return val;
			}
		}
		public int AgMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AgMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AgMalus;
				return val;
			}
		}
		public int IQMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.IQMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.IQMalus;
				return val;
			}
		}
		public int SpiritMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpiritMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpiritMalus;
				return val;
			}
		}
		public int StaminaMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StaminaMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StaminaMalus;
				return val;
			}
		}	
		public int AllAtributesBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllAtributesBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllAtributesBonus;
				return val;
			}
		}
		public int AllAtributesMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllAtributesMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllAtributesMalus;
				return val;
			}
		}	
		public float StrPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StrPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StrPercentBonus;
				return val;
			}
		}	
		public float StrPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StrPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StrPercentMalus;
				return val;
			}
		}	
				
		public float SpiritPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpiritPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpiritPercentBonus;
				return val;
			}
		}	
		public float SpiritPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.SpiritPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.SpiritPercentMalus;
				return val;
			}
		}	
		public float IQPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.IQPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.IQPercentBonus;
				return val;
			}
		}	
		public float IQPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.IQPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.IQPercentMalus;
				return val;
			}
		}	
				
		public float AgPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AgPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AgPercentBonus;
				return val;
			}
		}	
		public float AgPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AgPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AgPercentMalus;
				return val;
			}
		}	
		public float StaminaPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StaminaPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StaminaPercentBonus;
				return val;
			}
		}	
		public float StaminaPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.StaminaPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.StaminaPercentMalus;
				return val;
			}
		}	
		public float AllAtributesPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllAtributesPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllAtributesPercentBonus;
				return val;
			}
		}	
		public float AllAtributesPercentMalus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllAtributesPercentMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllAtributesPercentMalus;
				return val;
			}
		}	
		public int ManaBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaBonus;
				return val;
			}
		}	
		public int HealthBonus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealthBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealthBonus;
				return val;
			}
		}
		public float ManaPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaPercentBonus;
				return val;
			}
		}	
		public float HealthPercentBonus
		{
			get
			{
				float val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealthPercentBonus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealthPercentBonus;
				return val;
			}
		}
		public int ManaMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaMalus;
				return val;
			}
		}	
		public int HealthMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealthMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealthMalus;
				return val;
			}
		}
		#endregion
		
		#region immune
		public bool ImmuneToFear
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneToFear )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneToFear )
						return true;
				return false;
			}
		}	
		public bool ImmuneToKnockBack
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneToKnockBack )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneToKnockBack )
						return true;
				return false;
			}
		}	
		public bool ImmuneToDisarm
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneToDisarm )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneToDisarm )
						return true;
				return false;
			}
		}	
		public bool ImmuneToImmobilization
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneToImmobilization )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneToImmobilization )
						return true;
				return false;
			}
		}	
				
		public bool ImmunePoison
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmunePoison )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmunePoison )
						return true;
				return false;
			}
		}	
		public bool ImmuneDisease
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneDisease)
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneDisease )
						return true;
				return false;
			}
		}	
		public bool ImmuneMagic
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneMagic )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneMagic )
						return true;
				return false;
			}
		}	
		public bool ImmuneAttack
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneAttack )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneAttack )
						return true;
				return false;
			}
		}	
		public bool ImmunePhysicalDamage
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmunePhysicalDamage )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmunePhysicalDamage )
						return true;
				return false;
			}
		}	
		public bool ImmuneFireSpell
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneFireSpell )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneFireSpell )
						return true;
				return false;
			}
		}	
		public bool ImmuneFrostSpell
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneFrostSpell )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneFrostSpell )
						return true;
				return false;
			}
		}	
		public bool ImmuneAllSpellsAndAbilites
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ImmuneAllSpellsAndAbilites )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ImmuneAllSpellsAndAbilites )
						return true;
				return false;
			}
		}	
		#endregion

		#region regeneration
		public float HealthRegenerationModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealthRegenerationModifier;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealthRegenerationModifier;
				return val;
			}
		}
		public float ManaRegenerationModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaRegenerationModifier;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaRegenerationModifier;
				return val;
			}
		}
		public float HealthRegenWhileFightingPercent
		{
			get
			{
				float val = 0f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HealthRegenWhileFightingPercent;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HealthRegenWhileFightingPercent;
				return val;
			}
		}
		public float ManaRegenWhileCastingPercent
		{
			get
			{
				float val = 0f;
				if ( this.HaveTalent( Talents.ArcaneMeditation) )
				{
					AuraEffect ae = (AuraEffect)this.GetTalentEffect( Talents.ArcaneMeditation );
					val += ae.S1;
				}
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ManaRegenWhileCastingPercent;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ManaRegenWhileCastingPercent;
				return val;
			}
		}
		public bool InteruptRegeneration
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.InteruptRegeneration )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.InteruptRegeneration )
						return true;
				return false;
			}
		}	
		public float RageGenerationModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.RageGenerationModifier;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.RageGenerationModifier;
				return val;
			}
		}
		#endregion

		#region power cost
		public int ArcaneCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ArcaneCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ArcaneCostMalus;
				return val;
			}
		}
		public int FireCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FireCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FireCostMalus;
				return val;
			}
		}
		public int FrostCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.FrostCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.FrostCostMalus;
				return val;
			}
		}
		public int HolyCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.HolyCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.HolyCostMalus;
				return val;
			}
		}
		public int ShadowCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ShadowCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ShadowCostMalus;
				return val;
			}
		}
		public int NatureCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.NatureCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.NatureCostMalus;
				return val;
			}
		}
		public int AllCostMalus
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.AllCostMalus;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.AllCostMalus;
				return val;
			}
		}

		public float PowerCostModifier
		{
			get
			{
				float val = 1f;
				foreach( AuraReleaseTimer art in aura )
					val *= art.aura.PowerCostModifier;
				foreach( PermanentAura art in permanentAura )
					val *= art.aura.PowerCostModifier;
				return val;
			}
		}
		#endregion

		#region reflection
		public int ReflectFireChance
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ReflectFireChance;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ReflectFireChance;
				return val;
			}
		}
		public int ReflectFrostChance
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ReflectFrostChance;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ReflectFrostChance;
				return val;
			}
		}
		public int ReflectShadowChance
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ReflectShadowChance;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ReflectShadowChance;
				return val;
			}
		}
		public int ReflectMagicChance
		{
			get
			{
				int val = 0;
				foreach( AuraReleaseTimer art in aura )
					val += art.aura.ReflectMagicChance;
				foreach( PermanentAura art in permanentAura )
					val += art.aura.ReflectMagicChance;
				return val;
			}
		}
		#endregion

		//working on
		public bool UnInteractible
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ForceUnInteractible )
						return true;
				foreach( PermanentAura art in permanentAura )
					if ( art.aura.ForceUnInteractible )
						return true;
				return unInteractible;
			}
			set
			{
				unInteractible = value;
			}
		}
		

		public Mobile AttackTarget
		{
			get
			{
				if (attackTarget is Character)
					if ((attackTarget as Character).taxiOn) attackTarget = null;
				Mobile target = attackTarget;
				foreach(AuraReleaseTimer art in this.Auras)
				{
					if(art.aura.ForceAttackTo != null)
					{
						target = art.aura.ForceAttackTo;
					}
				}
				
				return target;
			}
			set
			{
				if (value is Character)
					if ((value as Character).taxiOn) attackTarget = null;
					else attackTarget = value;
				else attackTarget = value;
			}
		}
		// not done
												
		#region OTHER EFFECTS
		public bool WaterWalking
		{
			get
			{				
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.WaterWalking )
						return true;
				return false;
			}
		}	
		public bool FeatherFall
		{
			get
			{				
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.FeatherFall )
						return true;
				return false;
			}
		}	

		public bool ShadowTrance
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ShadowTrance )
						return true;
				return false;
			}
		}
		
		public bool ForceFlee
		{
			get
			{				
				if ( ImmuneToFear )
					return false;
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ForceFlee )
						return true;
				return false;
			}
		}	
		public bool ForceStun
		{
			get
			{				
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ForceStun )
						return true;
				return false;
			}
		}	
		public bool ForceRoot
		{
			get
			{				
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ForceRoot )
						return true;
				return false;
			}
		}
		public bool ForceSilence
		{
			get
			{				
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ForceSilence )
						return true;
				return false;
			}
		}

		#endregion

		#region MELEE EFFECTS
		public bool ShareDamageWithPet
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.ShareDamageWithPet )
						return true;
				return false;
			}
		}	
				
		#endregion

		#region DETECTIONS
		public bool DetectBeast
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.DetectBeast )
						return true;
				return false;
			}
		}	
		public bool DetectUndead
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.DetectUndead )
						return true;
				return false;
			}
		}
		public bool DetectHumanoid
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.DetectHumanoid )
						return true;
				return false;
			}
		}
		public bool CanSeeLesserInvisibility
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.CanSeeLesserInvisibility )
						return true;
				return false;
			}
		}	
		public bool CanSeeMediumInvisibility
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.CanSeeMediumInvisibility )
						return true;
				return false;
			}
		}
		public bool CanSeeGreaterInvisibility
		{
			get
			{
				foreach( AuraReleaseTimer art in aura )
					if ( art.aura.CanSeeGreaterInvisibility )
						return true;
				return false;
			}
		}
		#endregion
		#endregion	
		
		#region bovie test
		public ArrayList NextAttackEffects
		{
			get { return nextAttackEffects; }
		}
		#endregion

		#region  updated and added accesors other aura whole remaked
		public Item ActiveShield
		{
			get { return activeShield; }
		}
		public Item ActiveWeapon
		{
			get { return activeWeapon; }
		}
		public int AttackPower
		{
			get 
			{ 
				int attpower = 0;
				if (this is Character)
				{
					switch(this.Classe)
					{
						case Classes.Warrior: attpower = attackPower + this.Level*3 + 2*this.Str -20 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Warlock: attpower = attackPower + this.Str - 10 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Shaman: attpower = attackPower + this.Level*2 + 2*this.Str -20 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Rogue: attpower = attackPower + this.Level*2 + this.Str + this.Agility - 20  + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Priest: attpower = attackPower + this.Str - 10 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Paladin: attpower = attackPower + this.Level*3 + 2*this.Str -20 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Mage: attpower = attackPower + this.Str - 10 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Hunter: attpower = attackPower + this.Level*2 + this.Str + this.Agility -20 + AttackPowerBonus - AttackPowerMalus;break;
						case Classes.Druid: attpower = attackPower + 2*this.Str - 20 + AttackPowerBonus - AttackPowerMalus;break;
					}
					return (int)(attpower*AttackPowerModifier);
				}
				else return (int)((attackPower + AttackPowerBonus - AttackPowerMalus)*AttackPowerModifier);

			}
			set { attackPower = value; }
		}
		public int RangedAttackPower
		{
			get 
			{ 
				if (this is Character)
					return rangedAttackPower + this.Level*2 + this.Agility*2 -20 + RangedAttackPowerBonus - RangedAttackPowerMalus; 
				else return rangedAttackPower + RangedAttackPowerBonus - RangedAttackPowerMalus; 
			}
			set { rangedAttackPower = value; }
		}
		public float MinDamage
		{
			get { return minDamage; }
			set { minDamage = value; }
		}
		public float MaxDamage
		{
			get { return maxDamage; }
			set { maxDamage = value; }
		}
		public int Block
		{
			get { return (int)((block + ShieldBlockBonus)*ShieldBlockModifier); }
			set { block = value; }
		}
		public int ResistHoly
		{
			get { return (int)((resistHoly + HolyResistanceBonus - HolyResistanceMalus+ AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistHoly = value; }
		}
		public int ResistArcane
		{
			get { return (int)((resistArcane + ArcaneResistanceBonus - ArcaneResistanceMalus+ AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistArcane = value; }
		}
		public int ResistFire
		{
			get { return (int)((resistFire + FireResistanceBonus - FireResistanceMalus + AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistFire = value; }
		}
		public int ResistNature
		{
			get { return (int)((resistNature + NatureResistanceBonus - NatureResistanceMalus+ AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistNature = value; }
		}
		public int ResistFrost
		{
			get { return (int)((resistFrost + FrostResistanceBonus - FrostResistanceMalus+ AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistFrost = value; }
		}
		public int ResistShadow
		{
			get { return (int)((resistShadow + ShadowResistanceBonus - ShadowResistanceMalus+ AllResistanceBonus - AllResistanceMalus)*(1+(float)AllResistancePercentBonus/100 - (float)AllResistancePercentMalus/100)); }
			set { resistShadow = value; }
		}
		public int Armor
		{
			get 
			{ 
				float itemModif = 1f;
				/*if (this.HaveTalent(Talents.Toughness))
				{
					AuraEffect af = (AuraEffect)m.GetTalentEffect(Talents.Toughness);
					itemModif = 1 + (float)af.S1/100;
				}*/
				return (int)((armor + 2*Agility + (int)(ArmorFromItems*itemModif*(1+(float)ArmorFromItemsPercentIncrease/100)) + ArmorBonus - ArmorMalus)*(1+(float)ArmorPercentBonus/100 - (float)ArmorPercentMalus/100)); 
			}
			set{armor = value;}
		}
		public int ArmorFromItems
		{
			get{return armorFromItems;}
			set{armorFromItems = value;}
		}
		#endregion
	
		#region Accessors for update
		public int ArmorMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Armor - this.armor - this.Agility*2 - this.ArmorFromItems);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int HolyResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistHoly - this.resistHoly) ;
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int FireResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistFire - this.resistFire);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int NatureResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistNature - this.resistNature);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int FrostResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistFrost - this.resistFrost);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int ShadowResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistShadow - this.resistShadow);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int ArcaneResistanceMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistArcane - this.resistArcane);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int ArmorBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Armor - this.armor - this.Agility*2 - this.ArmorFromItems);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int HolyResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistHoly - this.resistHoly) ;
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int FireResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistFire - this.resistFire);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int NatureResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistNature - this.resistNature);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int FrostResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistFrost - this.resistFrost);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int ShadowResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistShadow - this.resistShadow);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int ArcaneResistanceBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.ResistArcane - this.resistArcane);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		#endregion
		
		#region OTHER ACCESSORS
		public AttackStatus LastSpellStatus
		{
			get { return lastSpellStatus; }
			set { lastSpellStatus = value; }
		}
		public object Value
		{
			get { return values; }
			set { values = value; }
		}
		public virtual uint DynFlags( Mobile m )
		{
			uint flags = 0;
		//	if ( this.Dead )
		//		flags |= 0x4000;
			if ( this.Freeze || this.ForceRoot || this.ForceStun )
				flags |= 0x4;
			//if ( !currentObjectLooted.IsEmpty )
			//	flags |= 1;
			if ( this.SkinLoot != null && this.Dead )
				flags |= 0x4000000;
			if ( m is Character )
			{
				Character c = ( m as Character );
				if ( c.Player.AccessLevel != AccessLevels.PlayerLevel )
					flags |= 0x10;
				object tc = c.CumulativeAuraEffects[ EffectTypes.FindCreature ];
				if ( tc != null && (int)((TrackableCreatures)tc) == (int)NpcType )
					flags |= 0x2;
			}
			
			return flags;
		}
		public virtual uint Flags
		{
			get
			{
				uint flags = 0;
				if ( MountModel != 0 )
					flags |= 0x3000;
				if ( this.Dead )
					flags |= 0x4000;
				if ( this.Freeze || this.ForceRoot || this.ForceStun )
					flags |= 0x4;
				if ( this.SkinLoot != null && this.Dead )
					flags |= 0x4000000;
				if ( this is Character )
				{
					if ( !( this as Character ).PvpActive )
						flags += 0x1000;
					else
						flags += 0x8;
				}
				return flags;
			}
		}
		public AttackStatus LastAttackStatus
		{
			get { return lastAttack; }
		}
		public AttackStatus LastAttackToMe
		{
			get { return lastAttackToMe; }
		}
		public int ComboPoints
		{
			get 
			{
				return comboPoints;
			}
		}
		public virtual ArrayList KnownObjects
		{
			get 
			{ 
				if ( lastSeen != null )
					return lastSeen.KnownObjects; 
				return null;
			}
		}
		public bool GodMode
		{
			get { return godMode; }
			set { godMode = value; }
		}
		public ArrayList AdditionnalStates
		{
			get { return additionnalStates; }
		}
		public Classes Classe
		{
			get { return classe; }
			set { classe = value; }
		}
		public Character LastSeen
		{
			get { return lastSeen; }
			set { lastSeen = value; }
		}
		
		public int MountModel
		{
			get { return mountModel; }			
			set { mountModel = value; }			
		}
		public Hashtable CumulativeAuraEffects
		{
			get { return cumulativeAuraEffects; }
		}

		public Hashtable KnownAbilities
		{
			get { return knownAbilities; }
		}
		public ArrayList PermanentAuras
		{
			get { return permanentAura; }
		}		
		public ArrayList Auras
		{
			get { return aura; }
		}
		public Mobile CharmedBy
		{
			get { return charmedBy; }
			set { charmedBy = value; }
		}
		public Mobile Charm
		{
			get { return charm; }
			set { charm = value; }
		}
		public Mobile SummonedBy
		{
			get { return summonedBy; }
			set { summonedBy = value; }
		}
		public Mobile Summon
		{
			get { return summon; }
			set { summon = value; }
		}
		public bool Skinned
		{
			get { if( SkinLoot != null ) return false; else return true; }
			set { if ( value ) SkinLoot = null; }
		}
		public Loot[] SkinLoot
		{
			get { return skinLoot; }
			set { skinLoot = value; }
		}

		public InvisibilityLevel Visible
		{
			get { return visible; }
			set { visible = value; }
		}
		public bool Running
		{
			get { return running; }
			set { running = value; }
		}

		protected SpellCastTimer SpellTimer
		{
			get { return spellCastTimer; }
		}
		public bool InCombat
		{
			get 
			{
				if ( this.AIState == AIStates.BeingAttacked	||
					this.AIState == AIStates.Fighting ||
					this.AIState == AIStates.Attack )
					return true;
				TimeSpan ts = DateTime.Now.Subtract( lastHit ); 
				if ( ts.TotalSeconds < 10 ) 
					return true; 
				return false; 
			}
		}
		public int Talent
		{
			get { return talent; }
			set { talent = value; }
		}
		public int LootMoney
		{
			get { return lootMoney; }
			set { lootMoney = value; }
		}
		public StandStates StandState
		{
			get { return standState; }
			set { standState = value; }
		}
		public bool Dead
		{
			get { if ( this.hitPoints <= 0 ) return true; else return false; }
		}
		public bool Deleted
		{
			get { return deleted; }
		}
		public byte nProfessions
		{
			get { return professions; }
			set { professions = value; }
		}
		public AIStates AIState
		{
			get { return aiState; }
			set { aiState = value; }
		}
		public uint Exp
		{
			get { return exp; }
			set { exp = value; }
		}
		public bool Freeze
		{
			get { return freeze; }
			set { freeze = value; }
		}
		/*	public WayPointList WayPoints
			{
				get { return wayPoints; }
				set { movementChange = true; wayPoints = value; }
			}*/
		public Mobile Mounting
		{
			get { return mounting; }
			set { mounting = value; }
		}
		public float Speed
		{
			get { return (speed + SpeedBonus - SpeedMalus)*SpeedModifier; }
			set { speed = value; }
		}
		public string NpcText
		{
			get { return npcText; }
			set { npcText = value; }
		}
		public float Size
		{
			get { return size; }
			set { size = value; }
		}
		public Item []Sells
		{
			get { return sells; }
			set { sells = value; }
		}

		public BaseTreasure []Loots
		{
			get { return loots; }
			set { loots = value; }
		}

		public int []Trains
		{
			get { return trains; }
			set { trains = value; }
		}
		public float BoundingRadius
		{
			get { return boundingRadius; }
			set { boundingRadius = value; }
		}

		public float CombatReach
		{
			get { return combatReach; }
			set { combatReach = value; }
		}
		public string Guild
		{
			get { return guild; }
			set { guild = value; }
		}	
		public int Family
		{
			get { return unk3; }
			set { unk3 = value; }
		}
		public int Elite
		{
			get { return unk4; }
			set { unk4 = value; }
		}
		public int Unk3
		{
			get { return unk3; }
			set { unk3 = value; }
		}
		public int Unk4
		{
			get { return unk4; }
			set { unk4 = value; }
		}
		public int Quest
		{
			get { return quest; }
			set { quest = value; }
		}

		public virtual void SetDamage( double min, double max )
		{
			minDamage = (float)min;
			maxDamage = (float)max;
		}
		public void AdjustDamage()
		{
			if ( minDamage > 0 )
			{
				float strBonus = (float)( str * str ) / 25f;
				if ( minDamage < strBonus )
				{
					str = (int)Math.Sqrt( minDamage * 25 );
				}
				minDamage -= (float)( str * str ) / 25f;
				minDamage += 10f;
				maxDamage -= (float)( str * str ) / 25f;
				maxDamage += 10f;
				if ( minDamage < 0f )
					minDamage = 0f;
				if ( maxDamage < 0f )
					maxDamage = 0.1f;
			}
		}
		public void AttackBonii( int min, int max )
		{
			attackBoniiMin = min;
			attackBoniiMax = max;
		}

		public int RandomLevel( int min, int max )
		{
			if ( min == max )
				return min;
			int lev = Utility.Random( max - min ) + min;
			return lev;
		}
		public int RandomLevel( int max )
		{
			return max;
		}

		public uint NpcFlags
		{
			get { return npcFlags; }
			set { npcFlags = value; }
		}
		public uint Flags1
		{
			get { return flags1; }
			set { flags1 = value; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public int NpcType
		{
			get { return npcType; }
			set { npcType = value; }
		}
		public Factions Faction
		{
			get { return faction; }
			set { faction = value; }
		}
		public int Model
		{
			get { return model; }
			set { model = value; }
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public string Name2
		{
			get { return name2; }
			set { name2 = value; }
		}		
		public int Level
		{
			get { return level; }
			set { level = value; }
		}
		public UInt32 GuildId
		{
			get { return guildId; }
			set { guildId = value; }
		}
		public UInt32 PetLevel
		{
			get { return petLevel; }
			set { petLevel = value; }
		}
		public UInt32 PetCreatureFamily
		{
			get { return petCreatureFamily; }
			set { petCreatureFamily = value; }
		}
		public UInt32 PetDisplayId
		{
			get { return petDisplayId; }
			set { petDisplayId = value; }
		}
		public Item[] Items
		{
			get { return items; }
			set { items = value; }
		}
		public int Str
		{
			get { return (int)((str + StrBonus + (int)baseStr - StrMalus+ this.AllAtributesBonus - this.AllAtributesMalus)*(1 + this.StrPercentBonus/100 - this.StrPercentMalus/100)*(1 + this.AllAtributesPercentBonus/100 - this.AllAtributesPercentMalus/100));} 
			set { str = value; }
		}
	
		public int Agility
		{
			
			get { return (int)((agility + AgBonus + (int)baseAgility - AgMalus + this.AllAtributesBonus - this.AllAtributesMalus)*(1 + this.AgPercentBonus/100 - this.AgPercentMalus/100)*(1 + this.AllAtributesPercentBonus/100 - this.AllAtributesPercentMalus/100)); }
			set { agility = value; }
		}
		
		public int Stamina
		{
			get 
			{ 
				float stamModif = 1f;
				if ( Classe == Classes.Warlock && HaveTalent( Talents.DemonicEmbrace ) )
				{
					AuraEffect ae = (AuraEffect)GetTalentEffect( Talents.DemonicEmbrace );
					stamModif *= 1 + (float)( ae.S1 ) / 100f;	
				}
				return  (int)((stamina + StaminaBonus + (int)baseStamina - StaminaMalus + this.AllAtributesBonus - this.AllAtributesMalus)*(1 + this.StaminaPercentBonus/100 - this.StaminaPercentMalus/100)*(1 + this.AllAtributesPercentBonus/100 - this.AllAtributesPercentMalus/100)*stamModif); 
			}
			set { stamina = value; }
		}
	
		public int Iq
		{
			get { return (int)((iq + IQBonus + (int)baseIq - this.IQMalus+ this.AllAtributesBonus - this.AllAtributesMalus)*(1 + this.IQPercentBonus/100 - this.IQPercentMalus/100)*(1 + this.AllAtributesPercentBonus/100 - this.AllAtributesPercentMalus/100)); }
			set { iq = value; }
		}

		public int Spirit
		{
			get 
			{ 
				float spiritModifier = 1f;
				if ( Classe == Classes.Warlock && HaveTalent( Talents.DemonicEmbrace ) )
				{
					AuraEffect ae = (AuraEffect)GetTalentEffect( Talents.DemonicEmbrace );
					spiritModifier *= 1 + (float)( ae.S1 ) / 100f;
					
				}
				return (int)((spirit + SpiritBonus + (int)baseSpirit - SpiritMalus + this.AllAtributesBonus - this.AllAtributesMalus)*(1 + this.SpiritPercentBonus/100 - this.SpiritPercentMalus/100)*(1 + this.AllAtributesPercentBonus/100 - this.AllAtributesPercentMalus/100)*spiritModifier);  
			}
			set { spirit = value; }
		}

		public float BaseStr
		{
			get { return baseStr; }
			set { baseStr = value; }
		}
		public float BaseAgility
		{
			get { return baseAgility; }
			set { baseAgility = value; }
		}
		public float BaseStamina
		{
			get { return baseStamina; }
			set { baseStamina = value; }
		}
		public float BaseIq
		{
			get { return baseIq; }
			set { baseIq = value; }
		}
		public float BaseSpirit
		{
			get { return baseSpirit; }
			set { baseSpirit = value; }
		}
		public float WalkSpeed
		{
			get { return walkSpeed * this.SpeedModifier; }
			set { walkSpeed = value; }
		}
		public float RunSpeed
		{
			get { return ( runSpeed + RunSpeedBonus - RunSpeedMalus ) * this.SpeedModifier* this.RunSpeedModifier; }
			set { runSpeed = value; }
		}
		public float SwimSpeed
		{
			get { return swimSpeed * this.SpeedModifier*this.SwimSpeedModifier; }
			set { swimSpeed = value; }
		}	
		public float SwimBackSpeed
		{
			get { return swimBackSpeed * this.SpeedModifier*this.SwimSpeedModifier; }
			set { swimBackSpeed = value; }
		}
		public int HitPoints
		{
			get { return hitPoints; }
			set { hitPoints = value; }
		}
		public int BaseHitPoints
		{
			get { return (int)((itemHealthBonus + baseHitPoints + HealthBonus - HealthMalus)*(1 + (float)this.HealthPercentBonus/100)); }
			set { baseHitPoints = value; }
		}
		public int ManaType
		{
			get 
			{ 
			//	if ( ( this.StandState & StandStates.BearForm ) != 0 )
			//		return 1;// rage
				return manaType; 
			}
			set { manaType = value; }
		}
		public int Mana
		{
			get 
			{ 
				switch( ManaType )
				{
					case 0:
						return mana;
					case 1:
						return rage;
					case 3:
						return energy;
				}		
				return 0; 
			}
			set 
			{ 
				switch( ManaType )
				{
					case 0:
						mana = value;
						break;
					case 1:
						rage = value;
						break;
					case 3:
						energy = value;
						break;
				}	
			}
		}
		public int BaseMana
		{
			get 
			{ 
				switch( ManaType )
				{
					case 0:
						int mana = (int)((itemManaBonus + baseMana + ManaBonus - ManaMalus)*(1 + (float)this.ManaPercentBonus/100) );
						if(this.HaveTalent(Talents.ArcaneMind))
						{
							AuraEffect af = (AuraEffect)this.GetTalentEffect(Talents.ArcaneMind);
							mana = (int)(mana*(1+(float)af.S1/100));							
						}
						return mana;
						
					case 1:
						return (int)((itemManaBonus + baseRage + ManaBonus - ManaMalus)*(1 + (float)this.ManaPercentBonus/100));
					case 3:
						return (int)((itemManaBonus + baseEnergy + ManaBonus - ManaMalus)*(1 + (float)this.ManaPercentBonus/100));
				}		
				return 0; 
			}
			set 
			{ 
				switch( ManaType )
				{
					case 0:
						baseMana = value;
						break;
					case 1:
						baseRage = value;
						break;
					case 3:
						baseEnergy = value;
						break;
				}	
			}
		}
		public int Rage
		{
			get { return rage; }
			set { rage = value; }
		}
		public int BaseRage
		{
			get { return baseRage; }
			set { baseRage = value; }
		}
		public int Energy
		{
			get { return energy; }
			set { energy = value; }
		}
		public int BaseEnergy
		{
			get { return baseEnergy; }
			set { baseEnergy = value; }
		}
		public int Focus
		{
			get { return focus; }
			set { focus = value; }
		}
		public int BaseFocus
		{
			get { return baseFocus; }
			set { baseFocus = value; }
		}
		public int AttackSpeed
		{
			get 
			{
				if(this is Character)
					return (int)( (float)this.ActiveWeapon.Delay * this.AttackSpeedModifier ); 
				else
					return (int)( (float)attackSpeed * this.AttackSpeedModifier ); }
			set { attackSpeed = value; }
		}

		public int CastingSpeed
		{
			get { return (int)( (float)castingSpeed * this.CastingSpeedModifier ); }
			set { castingSpeed = value; }
		}
		
		
		public Skills AllSkills
		{
			get { return allSkills; }
		}
		#endregion
		#endregion

		#region ENUMS
		public enum Familys 
		{ 
			Wolf = 1, 
			Cat = 2, 
			Spider = 3, 
			Bear = 4, 
			Boar = 5, 
			Crocilisk = 6, 
			CarrionBird = 7, 
			Crab = 8, 
			Gorilla = 9, 
			//unknowen = 10, 
			Raptor = 11, 
			Tallstrider = 12, 
			//unknowen = 13, 
			//unknowen = 14, 
			Felhunter = 15, 
			Voidwalker = 16, 
			Succubus = 17, 
			//unknowen = 18, 
			Doomguard = 19, 
			Scorpid = 20, 
			Turtle = 21, 
			//unknowen = 22, 
			Imp = 23, 
			Bat = 24, 
			Hyena = 25, 
			Owl = 26, 
			WindSerpent = 27 
		} 

		#endregion

		#region DELEGATES
		//public delegate bool AITick();
		public delegate bool OnCreatureTick();		
		#endregion

		#region CONSTRUCTORS
		public override void Delete()
		{
			deleted = true;
			if ( decay != null )
				decay.Stop();
			if ( movementTimer != null )
				movementTimer.Stop();
			if ( spellCastTimer != null )
				spellCastTimer.Stop();
			if ( onReachTimer != null )
				onReachTimer.Stop();
			
			if ( combatTimer != null )
				combatTimer.Stop();
		}
		public Mobile() : base( Server.Object.GUID++ )
		{
			if ( this is Corps )
				this.Guid += 0xE000A00000000000;
			if ( this is BaseCreature )
			{				
				localTime = DateTime.Now.Ticks;
				moveVector = new MoveVector( this, X, Y, Z );
				aiType = AITypes.Beast;
				this.Guid += 0xF000A00000000000;
				movementTimer = new MovementTimer( this );
			}
			else
				items = new Item[ 104 ];
		}

		public Mobile( float x, float y, float z, float orient ) : base( Server.Object.GUID++, x, y, z, orient )
		{
			//objectTypeId = 3;
			if ( !( this is Character ) )
			{
				this.Guid += 0xF000A00000000000;
				localTime = DateTime.Now.Ticks;
				movementTimer = new MovementTimer( this );
			}		
			else				
				items = new Item[ 104 ];
		}

		public Mobile( GenericReader gr )
		{
			Deserialize( gr );
		}
		#endregion

		#region SERIALISATION
		public static Mobile Load( GenericReader gr )
		{
			Mobile m = null;
			int id = gr.ReadInt();
			//string cl = gr.ReadString();
			if ( id == 0x7ffffffe )//cl == "Corps" )
				m = new Corps();
			else
				if ( id == 0x7fffffff )//	character
				m = (Mobile)new Character();
			else
			{
				if ( id > 99000000 )
				{
					ConstructorInfo ct = (ConstructorInfo)World.MobilePool( 99999999 );//Utility.FindConstructor( cl, Utility.externAsm );
					m = (Mobile)ct.Invoke( null );
					
				}
				else
					if ( id < 0 )
				{
					ConstructorInfo ct = (ConstructorInfo)World.MobilePool( 999999 );//Utility.FindConstructor( cl, Utility.externAsm );
					m = (Mobile)ct.Invoke( null );
				}
				else
				{
					ConstructorInfo ct = (ConstructorInfo)World.MobilePool( id );//Utility.FindConstructor( cl, Utility.externAsm );
					//if ( ct == null )
					//	ct = Utility.FindConstructor( cl );
					m = (Mobile)ct.Invoke( null );
				}
			}
			m.Deserialize( gr );
			

			/*
						if ( m.Dead && !( m is Character ) )
						{
							m.decay = new DecayTimer( m, 10 * 1000 );
						}			*/
			return m;
		}

		public override void Deserialize( GenericReader gr )
		{
			int version = gr.ReadInt();
			//	id = gr.ReadInt();
			UInt64 g = gr.ReadInt64();				
			SpawnerLink = null;//(BaseSpawner)MobileList.TempSpawner[ g ];

			int esu = 0;
			int ech = 0;
			
			esu = gr.ReadInt();
			ech = gr.ReadInt();
			name = gr.ReadString();
			if ( version > 0 )
				classe = (Classes)gr.ReadInt();
			talent = gr.ReadInt();
			Level = gr.ReadInt();
			model = gr.ReadInt();
			exp = (uint)gr.ReadInt();
			guildId = (uint)gr.ReadInt();
			petLevel = (uint)gr.ReadInt();
			petCreatureFamily = (uint)gr.ReadInt();
			petDisplayId = (uint)gr.ReadInt();
			speed  = gr.ReadFloat();
			size = gr.ReadFloat();					
			faction = (Factions)gr.ReadInt();
			str = gr.ReadInt();
			agility = gr.ReadInt();
			stamina = gr.ReadInt();
			iq = gr.ReadInt();
			spirit = gr.ReadInt();
			baseStr = gr.ReadFloat();
			baseAgility = gr.ReadFloat();
			baseStamina = gr.ReadFloat();
			baseIq = gr.ReadFloat();
			baseSpirit = gr.ReadFloat();
			walkSpeed = gr.ReadFloat();
			if ( walkSpeed == 0 )
				walkSpeed = 4.7777f;
			runSpeed = gr.ReadFloat();
			if ( runSpeed == 0 )
				runSpeed = 7f;
			swimSpeed = gr.ReadFloat();
			if ( swimSpeed == 0 )
				swimSpeed = 4.72f;
			swimBackSpeed = gr.ReadFloat();
			if ( swimBackSpeed == 0 )
				swimBackSpeed = 2.5f;
			hitPoints = gr.ReadInt();
			mana = gr.ReadInt();
			energy = gr.ReadInt();
			rage = gr.ReadInt();
			focus = gr.ReadInt();
			baseHitPoints = gr.ReadInt();
			baseMana = gr.ReadInt();
			baseEnergy = gr.ReadInt();
			baseRage = gr.ReadInt();
			baseFocus = gr.ReadInt();

			block = gr.ReadInt();
			armor = gr.ReadInt();
			resistHoly = gr.ReadInt();
			resistFire = gr.ReadInt();
			resistNature = gr.ReadInt();
			resistFrost = gr.ReadInt();
			resistShadow = gr.ReadInt();
			resistArcane = gr.ReadInt();

			int nSkills = gr.ReadInt();
			for(int t = 0;t < nSkills;t++ )
			{
				ushort skill = (ushort)gr.ReadShort();
				allSkills[ skill ] = Skill.Deserialize( gr, t );
			}

			int nSpells = gr.ReadInt();
			for(int t = 0;t < nSpells;t++ )
			{
				ushort spell = (ushort)gr.ReadShort();
				byte place = gr.ReadByte();
				knownAbilities[ (int)spell ] = (int)place;
				/*	if ( TalentDescription.IsTalent( (int)spell ) )
					{
						if ( onInitialiseTalent[ (int)spell ] != null )
						{
							( onInitialiseTalent[ (int)spell ] as TalentHandlers.TalentHandler )( Abilities.abilities[ (int)spell ], this );
						}
					//	this.AddPermanentAura( Abilities.abilities[ (int)spell ], new Aura() );
					//	permanentAura.Add( spell );
					}*/
			}

			int nTalentList = gr.ReadInt();
			for(int t = 0;t < nTalentList;t++ )
			{
				int spell = gr.ReadInt();
				int lev = gr.ReadInt();
				talentList[ spell ] = (int)lev;
			}
			
			if ( gr.ReadInt() != 0 )
				freeze = true;
			int nit = gr.ReadInt();
			for(int t = 0;t < nit;t++ )
			{
				int n = gr.ReadInt();
				if ( n == 1 )
					items[ t ] = Item.Load( gr );
				else
					items[ t ] = null;
			}
			if ( gr.ReadInt() != 0 )
				movementChange = true;

			manaType = gr.ReadInt();
			professions = gr.ReadByte();
			standState = (StandStates)gr.ReadInt();
			base.Deserialize( gr );
			moveVector = new MoveVector( this, X, Y, Z );
			//	if ( this is BaseSpawner )
			//		MobileList.TempSpawner[ Guid ] = this;
			if ( esu != 0 )
				MobileList.TempSummon[ Guid ] = this;
			if ( ech != 0 )
				MobileList.TempSummon[ Guid ] = this;
			//movementTimer = new MovementTimer( this );
		}
		public override void Serialize( GenericWriter gw )
		{
			if ( this is Character )
				gw.Write( 0x7fffffff );
			else
				if ( this is Corps )
				gw.Write( 0x7ffffffe );
			else
				gw.Write( id );
			//gw.Write( Utility.ClassName( this ) );
			gw.Write( (int)1 );
			
			if ( SpawnerLink != null )
				gw.Write( SpawnerLink.Guid );
			else
				gw.Write( (UInt64)0 );
			if ( summonedBy != null )
				gw.Write( 1 );
			else
				gw.Write( 0 );
			if ( charmedBy != null )
				gw.Write( 1 );
			else
				gw.Write( 0 );
			gw.Write( name );
			gw.Write( (int)classe );
			gw.Write( talent );
			gw.Write( level );
			gw.Write( model );
			gw.Write( exp );
			gw.Write( guildId );
			gw.Write( petLevel );
			gw.Write( petCreatureFamily );
			gw.Write( petDisplayId );
			gw.Write( speed  );
			gw.Write( size );			
			
			gw.Write( (int)faction );
			gw.Write( str );
			gw.Write( agility );
			gw.Write( stamina );
			gw.Write( iq );
			gw.Write( spirit );
			gw.Write( baseStr );
			gw.Write( baseAgility );
			gw.Write( baseStamina );
			gw.Write( baseIq );
			gw.Write( baseSpirit );
			gw.Write( walkSpeed );
			gw.Write( runSpeed );
			gw.Write( swimSpeed );
			gw.Write( swimBackSpeed );
			gw.Write( hitPoints );
			gw.Write( mana );
			gw.Write( energy );
			gw.Write( rage );
			gw.Write( focus );
			gw.Write( baseHitPoints );
			gw.Write( baseMana );
			gw.Write( baseEnergy );
			gw.Write( baseRage );
			gw.Write( baseFocus );

			gw.Write( block );
			gw.Write( armor );
			gw.Write( resistHoly );
			gw.Write( resistFire );
			gw.Write( resistNature );
			gw.Write( resistFrost );
			gw.Write( resistShadow );
			gw.Write( resistArcane );
			

			gw.Write( (int)allSkills.Count );
			IDictionaryEnumerator Enumerator = allSkills.GetEnumerator();
			while( Enumerator.MoveNext() )
			{
				ushort sid = (ushort)Enumerator.Key;
				Skill val = (Skill)Enumerator.Value;				
				gw.Write( (ushort)sid );
				val.Serialize( gw );
			}
			gw.Write( (int)knownAbilities.Count );
			Enumerator = knownAbilities.GetEnumerator();
			while (Enumerator.MoveNext())
			{
				int spell = (int)Enumerator.Key;
				int place = (int)Enumerator.Value;
				gw.Write( (short)spell );
				gw.Write( (byte)place );
			}

			gw.Write( (int)talentList.Count );
			Enumerator = talentList.GetEnumerator();
			while( Enumerator.MoveNext() )
			{
				int spell = (int)Enumerator.Key;
				int place = (int)Enumerator.Value;
				gw.Write( (int)spell );
				gw.Write( (int)place );
			}

			if ( freeze )
				gw.Write( 1 );
			else
				gw.Write( 0 );

			if ( this is Character )
			{
				gw.Write( 104 );
				for(int t = 0;t < 104;t++ )
				{
					if ( items[ t ] == null )
						gw.Write( 0 );
					else
					{
						gw.Write( 1 );
						items[ t ].Serialize( gw );
					}
				}
			}
			else
				gw.Write( 0 );

			if ( movementChange )
				gw.Write( 1 );
			else
				gw.Write( 0 );
			gw.Write( manaType );
			gw.Write( professions );
			gw.Write( (int)standState );
			base.Serialize( gw );
		}
		#endregion

		#region ABILITY
		public virtual void UnLearnSpell( int id )
		{
			knownAbilities.Remove( id );
			if (Abilities.abilities[id] is AuraEffect)
				this.RemovePermanentAura((AuraEffect)Abilities.abilities[id]);
		}
		public virtual void LearnSpell( int id )
		{
			knownAbilities[ id ] = -1;
			if ( SpellTemplate.SpellEffects[ id ] != null)
			{
				if ( SpellTemplate.SpellEffects[id] is PermanentSpellEffect)
				{
					PermanentSpellEffect pse = (PermanentSpellEffect)SpellTemplate.SpellEffects[ id ];
					pse( (BaseAbility)Abilities.abilities[id], this );
				}
			}
		}
		public virtual void LearnSpell( int id, SpellsTypes st )
		{
			knownAbilities[ id ] = st;
			if ( SpellTemplate.SpellEffects[ id ] != null)
			{
				if ( SpellTemplate.SpellEffects[id] is PermanentSpellEffect)
				{
					PermanentSpellEffect pse = (PermanentSpellEffect)SpellTemplate.SpellEffects[ id ];
					pse( (BaseAbility)Abilities.abilities[id], this );
				}
			}
		}
		public virtual bool HaveSpell( int id )
		{
			if ( id == 0 )
				return false;
			if ( knownAbilities[ id ] != null )
				return true;
			return false;
		}
		public virtual bool HaveSpell( BaseAbility ba )
		{
			if ( ba == null )
				return false;
			if ( knownAbilities[ ba.Id ] != null )
				return true;
			return false;
		}

		public void TrainAbility( int []abs )
		{
			foreach( int i in abs )
				this.knownAbilities[ i ] = -1;
		}

		#endregion

		#region TIMERS
		private class DecayTimer : WowTimer
		{
			Mobile from;
			public DecayTimer( Mobile f, int delay ) : base( delay, "DecayTimer" )
			{
				from = f;
				Start();
			}
			public override void OnTick()
			{
				if ( from.SpawnerLink != null )
				{
					from.SpawnerLink.Release( from );
					from.SpawnerLink = null;
				}
				if ( World.allMobiles.Contains( from ) )
					World.Remove( from, from );
				Stop();
				base.OnTick ();
			}
		}
		
		private class MovementTimer : WowTimer
		{
			Mobile from;
			int iteration = 0;

			public MovementTimer( Mobile f ) : base( WowTimer.Priorities.Second , 1000, "MovementTimer" )
			{
				from = f;
				Start();
			}
			public override void OnTick()
			{
				iteration++;
				if ( iteration > 32 )
				{
					iteration = 0;
					bool b = ( from as BaseCreature ).IsStillActive();
					if ( !b )
					{
						Stop();
						base.OnTick ();
						return;
					}
				}
		/*		if ( World.allConnectedChars.Count > 0 && from.Distance( World.allConnectedChars[ 0 ] as Object ) > 200 * 200 )
				{
					bool b = ( from as BaseCreature ).IsStillActive();
					
					( World.allConnectedChars[ 0 ] as Character ).SendMessage( this.GetType().ToString() + " dist = " + from.Distance( World.allConnectedChars[ 0 ]  as Object ).ToString() );
				}*/
				if ( !from.Dead )
				{
					if ( !from.Freeze )
					{
						//	if ( from.CharacterNear() )
						from.OnTick();//OnMovementHeartBeat();
					}
				}
				if ( from.deleted )
					Stop();
				
				base.OnTick ();
			}

		}
		private class CombatTimer : WowTimer
		{
			Mobile from;
			public CombatTimer( Mobile f, int delay ) : base( delay, "CombatTimer" )
			{
				from = f;
				Start();
			}
			public override void OnTick()
			{
				from.MeleeCombatSlice();
				Stop();
				base.OnTick ();
			}
		}
		public delegate void OnReachDelegate();
		private class OnReachTimer : WowTimer
		{
			OnReachDelegate onReach;
			public OnReachTimer( int delay, OnReachDelegate _onReach ) : base( WowTimer.Priorities.Milisec100 , delay, "OnReachTimer" )
			{
				onReach = _onReach;
				Start();
			}
			public override void OnTick()
			{
				onReach();
				Stop();
				base.OnTick ();
			}

		}
		#endregion

		#region MOVEMENT 

		public virtual void FaitFace( Mobile from )
		{
			// 56 00 00 00 00 00 00 00 
			// 85 DE 0B C6 
			// 48 55 14 C3 
			// CB 22 A5 42 
			// 00 00 00 00 
			// 00 00 00 00 
			// 00 02 14 00 00 
			// 01 00 00 00 
			// AB C9 0B C6 
			// 62 D4 09 C3 
			// 52 69 A7 42

			UpdateXYZ();
			Orientation = (float)Math.Atan2( from.Y - Y, from.X - X );
			Orientation += (float)Math.PI;
			float ax = (float)( Math.Cos( Orientation ) / 5 );
			float ay = (float)( Math.Sin( Orientation ) / 5 );
			float x = X - ax;
			float y = Y - ay;

			byte []movePacket = new byte[ 1 * 3 * 4 + 41 ];
			ax *= ax;
			ay *= ay;
			ax = (float)Math.Sqrt( ax + ay );
			int instantSpeed=(int)( ax / ( Speed / 1000f ) );
			int offset = 4;
			uint time = (uint)( DateTime.Now.Ticks - localTime );

			Converter.ToBytes( Guid, movePacket, ref offset );	
			Converter.ToBytes( (float)X, movePacket, ref offset );//	X
			Converter.ToBytes( (float)Y, movePacket, ref offset );//	Y
			Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
			//Converter.ToBytes( (float)Orientation, movePacket, ref offset );//	Z
			Converter.ToBytes( time, movePacket, ref offset );//	Z		
			Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z				
			
			Converter.ToBytes( (int)0x0, movePacket, ref offset );//	Z		
				
			Converter.ToBytes( (int)instantSpeed, movePacket, ref offset );//	Z			
			Converter.ToBytes( (int)1, movePacket, ref offset );//	Z		
			Converter.ToBytes( (float)x, movePacket, ref offset );//	X
			Converter.ToBytes( (float)y, movePacket, ref offset );//	Y
			Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
			ToAllPlayerNear( Server.OpCodes.SMSG_MONSTER_MOVE, movePacket, offset );		
		}

		public class MoveVector
		{
			float destX;
			float destY;
			float destZ;
			float fromX;
			float fromY;
			float fromZ;
			float speed;
			DateTime timestamp;
			float reach;

			public MoveVector( Mobile m, float x, float y, float z )
			{
				timestamp = DateTime.Now;
				destX = x;
				destY = y;
				destZ = z;
				fromX = m.X;
				fromY = m.Y;
				fromZ = m.Z;
				speed = m.Speed;
				float ax = ( x - m.X );
				float ay = ( y - m.Y );
				//	float az = ( z - m.Z );
				float dist = (float) Math.Sqrt( ax * ax + ay * ay/* + az * az */);
				reach = dist / ( m.Speed / 1000 );
			}
			public MoveVector( Mobile m, float x, float y, float z,float fromx, float fromy, float fromz )
			{
				timestamp = DateTime.Now;
				destX = x;
				destY = y;
				destZ = z;
				fromX = fromx;
				fromY = fromy;
				fromZ = fromz;
				speed = m.Speed;
				float ax = ( x - m.X );
				float ay = ( y - m.Y );
				//	float az = ( z - m.Z );
				float dist = (float) Math.Sqrt( ax * ax + ay * ay/* + az * az */);
				reach = dist / ( m.Speed / 1000 );
			}
			public bool ReachDestination()
			{
				TimeSpan ts = DateTime.Now.Subtract( timestamp );
				float sp = ( (float)ts.TotalMilliseconds ) / reach;
				if ( sp > 1 || reach == 0 )
					return true;
				return false;
			}
			public bool NearDestination()
			{
				TimeSpan ts = DateTime.Now.Subtract( timestamp );
				float sp = (float)ts.TotalMilliseconds - reach;
				if ( sp < 1000 )
					return true;
				return false;
			}
			public void Get( out float x, out float y, out float z )
			{			
				TimeSpan ts = DateTime.Now.Subtract( timestamp );
				float sp = ( (float)ts.TotalMilliseconds ) / reach;
				if ( reach == 0 || sp > 1 )
				{
					x = destX;
					y = destY;
					z = destZ;
					return;
				}
				float dx = destX - fromX;
				float dy = destY - fromY;
				float dz = destZ - fromZ;	
				//	Console.WriteLine(" time {0}", sp );
				dx *= sp;
				dy *= sp;
				dz *= sp;
				x = fromX + dx;
				y = fromY + dy;
				z = fromZ + dz;
			}
			public void Update( float x, float y, float z, float speed )
			{
				Get( out fromX, out fromY, out fromZ );
				timestamp = DateTime.Now;	
				float ax = ( x - fromX );
				float ay = ( y - fromY );
				float az = ( z - fromZ );
				destX = x;
				destY = y;
				destZ = z;
				float dist = (float)Math.Sqrt( ax * ax + ay * ay );
				reach = dist / ( speed / 1000 );			
			}
		}
		public void UpdateXYZ()
		{
			float dx;
			float dy;
			float dz;
			moveVector.Get( out dx, out dy, out dz );
			X = dx;
			Y = dy;
			Z = dz;
		}
		OnReachTimer onReachTimer;
		public float MoveTo( float x, float y, float z, OnReachDelegate onReach )
		{
			//return 1;
			float temps = MoveTo( x, y, z );
			onReachTimer = new OnReachTimer( (int)temps, onReach );
			return temps;
		}

		//public static uint aa = 1;//0xFFBEA7FB;
		public bool ReachDestination()
		{
			return moveVector.ReachDestination();
		}
		/*
		public void MoveTo( Trajet t, OnReachDelegate onReach )
		{
			int offset = 4;
			UpdateXYZ();
			float x = X - t[ 0 ].x;
			float y = Y - t[ 0 ].y;
			float z = Z - t[ 0 ].z;
			x *= x;
			y *= y;
			z *= z;
			x = (float)Math.Sqrt( x + y + z );
			float distTotale = t.longueur + x;
			float xd = (float)( distTotale / ( Speed / 1000 ) );
			int instantSpeed = (int)xd;
			byte []movePacket = new byte[ 41 + t.Count * 3 * 4 ];
			uint time = (uint)( DateTime.Now.Ticks - localTime );
			Converter.ToBytes( Guid, movePacket, ref offset );	
			Converter.ToBytes( (float)X, movePacket, ref offset );//	X
			Converter.ToBytes( (float)Y, movePacket, ref offset );//	Y
			Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
			Converter.ToBytes( time, movePacket, ref offset );//	Z	
			Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z	
			
		//	Converter.ToBytes( (int)0x00000300, movePacket, ref offset );//	pas d'animation de mouvement, taxi node ?		
			//aa = 0x4000000 + 0x300 + 0x1;
			aa = 0x4000000 + 0x2F0;
			//Console.WriteLine("AA= {0}", aa );
			Converter.ToBytes( (int)( aa ), movePacket, ref offset );//	Z		
		//	aa = aa << 1;
				
			Converter.ToBytes( (int)instantSpeed, movePacket, ref offset );//	Z			
			Converter.ToBytes( (int)t.Count, movePacket, ref offset );//	Z	
			foreach( Coord c in t )
			{
				Converter.ToBytes( (float)c.x, movePacket, ref offset );//	X
				Converter.ToBytes( (float)c.y, movePacket, ref offset );//	Y
				Converter.ToBytes( (float)c.z, movePacket, ref offset );//	Z
			}
			World.ToNearestPlayer( this, 0xDD, movePacket, offset );
			onReachTimer = new OnReachTimer( instantSpeed, onReach );
		//	Console.WriteLine( "Je vais mettre {0}", instantSpeed );
		}*/
		public void InstantMoveTo( float x, float y, float z )
		{
			X = x;
			Y = y;
			Z = z;
			int offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PreparePartialUpdateData( tempBuff, ref offset );
			this.ToAllPlayerNearExceptMe( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public float MoveTo( float x, float y, float z )
		{			
			if ( ForceRoot || ForceStun )
				return 1;
			byte []movePacket = new byte[ 1 * 3 * 4 + 41 ];
			int instantSpeed;
			int offset = 4;
			if ( Running  )
				Speed = RunSpeed;
			else
				Speed = WalkSpeed;
			moveVector.Update( x, y, z, Speed );
			if ( Math.Abs( z - Z ) > 2f )
			{
				float rap = Math.Abs( z - Z ) / 2;
				x = X + ( ( x - X ) / rap );
				y = Y + ( ( y - Y ) / rap );
				z = Z + ( ( z - Z ) / rap );
			}
			float dx;
			float dy;
			float dz;
			moveVector.Get( out dx, out dy, out dz );
			X = dx;
			Y = dy;
			Z = dz;
			float xd = x - X;
			float yd = y - Y;
			float zd = z - Z;
			Orientation = (float)Math.Atan2( yd, xd );
			xd *= xd;
			yd *= yd;
			zd *= zd;
			xd += ( yd + zd );
			if ( Running  )
				xd = (float)( Math.Sqrt( xd ) / ( Speed / 1000 ) );
			else
				xd = (float)( Math.Sqrt( xd ) / ( Speed / 1000 ) );
			instantSpeed = (int)xd;
			uint time = (uint)( DateTime.Now.Ticks - localTime );
			Converter.ToBytes( Guid, movePacket, ref offset );	
			Converter.ToBytes( (float)X, movePacket, ref offset );//	X
			Converter.ToBytes( (float)Y, movePacket, ref offset );//	Y
			Converter.ToBytes( (float)Z, movePacket, ref offset );//	Z			
			Converter.ToBytes( time, movePacket, ref offset );//	Z		
			Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z	
			if ( !Running  )
				Converter.ToBytes( (int)0, movePacket, ref offset );//	Z		
			else
				Converter.ToBytes( (int)0x100, movePacket, ref offset );//	Z		
				
			Converter.ToBytes( (int)instantSpeed, movePacket, ref offset );//	Z			
			Converter.ToBytes( (int)1, movePacket, ref offset );//	Z		
			Converter.ToBytes( (float)x, movePacket, ref offset );//	X
			Converter.ToBytes( (float)y, movePacket, ref offset );//	Y
			Converter.ToBytes( (float)z, movePacket, ref offset );//	Z
			ToAllPlayerNear( Server.OpCodes.SMSG_MONSTER_MOVE, movePacket, offset );
			//	movementTimer = new MovementTimer( this );
			return xd;
		}
		public int currs = 0;
		public void MovementHeartBeat( PlayerHandler ph, Character from )
		{
			if ( true )
			{/*
				byte []movePacket = { 0x00, 0x33, 0xDD, 0x00, 
										0x52, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
										0x6A, 0xFC, 0x3A, 0xC4, 
										0x7C, 0xBD, 0x96, 0xC5, 
										0x8B, 0x9D, 0xA0, 0x41, 

										0x00, 0x00, 0x00, 0x00, 
										0x00, 0x00, 0x00, 0x00, 
										0x00, 0xF6, 0x06, 0x00, 
										0x00, 
										0x01, 0x00, 0x00, 0x00, 
										0x16, 0xE4, 0x39, 0xC4, 
										0x71, 0xBB, 0x96, 0xC5, 
										0xD2, 0xE5, 0xA6, 0x41};

*/
				byte []movePacket = { 	0,0,0,0,
										0xD1, 0x1C, 0x25, 0x00, 
										0x00, 0xA0, 0x00, 0xF0, 

										0x50, 0x45, 0xD4, 0xC3, 
										0x26, 0xDE, 0x21, 0xC5, 
										0x79, 0xCF, 0xBF, 0x42, 
										0x00, 0x00, 0x00, 0x00, 
										0x00, 0x00, 0x00, 0x00, 
										0x00, 
										0x00, 0x00, 0x00, 0x00, 
										0x01, 0x00, 0x00, 0x00, 
										
										0x50, 0x45, 0xD4, 0xC3, 
										0x26, 0xDE, 0x21, 0xC5, 
										0x79, 0xCF, 0xBF, 0x42
									};
				int offset = 4;
				Converter.ToBytes( Guid, movePacket, ref offset );	
				Converter.ToBytes( (float)from.X, movePacket, ref offset );//	X
				Converter.ToBytes( (float)from.Y, movePacket, ref offset );//	Y
				Converter.ToBytes( (float)from.Z, movePacket, ref offset );//	Z			
				Converter.ToBytes( (int)0, movePacket, ref offset );//	Z		
				Converter.ToBytes( (int)0, movePacket, ref offset );//	Z		
				Converter.ToBytes( (byte)0, movePacket, ref offset );//	Z		
				Converter.ToBytes( (int)0x23F, movePacket, ref offset );//	Z			
				Converter.ToBytes( (int)1, movePacket, ref offset );//	Z		
				Converter.ToBytes( (float)from.X + 20, movePacket, ref offset );//	X
				Converter.ToBytes( (float)from.Y, movePacket, ref offset );//	Y
				Converter.ToBytes( (float)from.Z, movePacket, ref offset );//	Z
				ph.Send( 0xDD, movePacket, offset );
			}
		}

		public virtual void OnMovementHeartBeat()
		{
		}

		public void SetPosition( float x, float y, float z, float orientation )
		{
			X = x;
			Y = y;
			Z = z;
			Orientation = orientation;
			
		}

		public void ForcePosition( float x, float y, float z, float orientation )
		{
			X = x;
			Y = y;
			Z = z;
			Orientation = orientation;
			this.moveVector = new Server.Mobile.MoveVector(this,x,y,z,x-1,y-1,z-1);
			this.UpdateXYZ();
			
		}


		

		public void ToPlayerInRange( OpCodes op, byte []buffer, int len )
		{
			foreach( Character ch in World.allConnectedChars )
				if ( Distance( ch ) < 300 * 300 * 2 )
					ch.Send( op, buffer, len );
		}
		#endregion

		#region ITEMS
		/*	public void AddNewItem( Item []it )
			{
				foreach( Item i in it )
				{
					Equip( i );
				}
			}*/

		void ApplyItemModifier( Item i )
		{
			if ( i.ObjectClass == 2 )
			{
				activeWeapon = i;
				this.attackSpeed = i.Delay;
				if ( attackSpeed == 0 )
					attackSpeed = 2000;
			}
			else
				if ( i.ObjectClass == 4 && i.SubClass == 6 )
			{
				activeShield = i;
				block = i.Block;
			}
		}
		#region Equip item for mob
		public void Equip( Item i )
		{
			items = new Item[ 1 ];
			items[ 0 ] = i;
			ApplyItemModifier( i );
		}
		public void Equip( Item i, Item j )
		{
			items = new Item[ 2 ];
			items[ 0 ] = i;
			items[ 1 ] = j;
			ApplyItemModifier( i );
			ApplyItemModifier( j );
		}
		public void Equip( Item i, Item j, Item k )
		{
			items = new Item[ 3 ];
			items[ 0 ] = i;
			items[ 1 ] = j;
			items[ 2 ] = k;
			ApplyItemModifier( i );
			ApplyItemModifier( j );
			ApplyItemModifier( k );
		}
		#endregion
		public Item FindItemById( int id )
		{//	cherche l'objet dans le loot ou les objets a vendre
			if ( sells != null )
				foreach( Item item in sells )
					if ( item != null && item.Id == id )
						return item;
			if ( Treasure != null && Treasure.Length > 0 )
				foreach( Item item in Treasure )
				{
					if ( item != null && item.Id == id )
						return item;
				}
			return null;
		}

		public int ShowInventory( byte []tempBuff, Character c )
		{
			byte nObj = 0;
			foreach( Item item in Sells )
				if ( item != null )
					nObj++;
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( (byte)nObj, tempBuff, ref offset );
			for(int t = 0;t < nObj;t++ )
			{
				Item it = Sells[ t ];				
				Converter.ToBytes( (int)( t + 1 ), tempBuff, ref offset );
				Converter.ToBytes( (int)it.Id, tempBuff, ref offset );
				Converter.ToBytes( (int)it.Model, tempBuff, ref offset );
				Converter.ToBytes( (int)it.Stackable, tempBuff, ref offset );
				Converter.ToBytes( (int)it.BuyPrice, tempBuff, ref offset );
				Converter.ToBytes( (int)0, tempBuff, ref offset );
				Converter.ToBytes( (int)0, tempBuff, ref offset );
			}
			return offset;
		}

		#endregion

		#region MOUNT

		protected AuraEffect mountedIdAuraEffect;
		public virtual void Mount( Mobile m )
		{
			this.MountModel = m.Model;

			int offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, true );
			this.ToAllPlayerNearExceptMe( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			
			Aura aura = new Aura();
			aura.OnRelease = new Aura.AuraReleaseDelegate( this.OnUnMount );
			AddAura( mountedIdAuraEffect = (AuraEffect)World.MountsList[ m.Id ], aura );
		}

		public virtual void OnUnMount( Mobile c )
		{
			int offset = 4;

			this.MountModel = 0;
			
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, true );
			this.ToAllPlayerNearExceptMe( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			
		}


		public void SetMountModel( int id )
		{
			mountModel = id;		
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_MOUNTDISPLAYID }, new object[] { id } );
		}
		public virtual void ChangeRunSpeed( float newspeed )
		{
			//	RunSpeed = newspeed;
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( RunSpeed, tempBuff, ref offset );
			//	if ( lastSeen != null && lastSeen.Player != null )
			ToAllPlayerNear( OpCodes.SMSG_FORCE_RUN_SPEED_CHANGE, tempBuff, offset );
			/*	else
					ToAllPlayerNear( OpCodes.SMSG_FORCE_RUN_SPEED_CHANGE, tempBuff, offset );*/
		}
		#endregion

		#region UPDATES
		public byte []hitsUpdate = { 00, 0x2D, 0xA9, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x94, 0x14, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x23, 0x00, 0x00, 0x00 };
		public void ManaUpdate( Mobile from )
		{			
			SendSmallUpdateToPlayerNearMe( this.Guid, new int[] { (int)UpdateFields.UNIT_FIELD_POWER1 + manaType }, new object[] { Mana } );			
		}

		public class DelayHitLoosed : WowTimer
		{
			Mobile from;
			Mobile attacker;
			public DelayHitLoosed( Mobile _from, Mobile _attacker ) : base( 500, "DelayHitLoosed" )
			{
				from = _from;
				attacker = _attacker;
				Start();
			}
			public override void OnTick()
			{
				if ( from.HitPoints > 0 )
					from.SendSmallUpdateToPlayerNearMe( from.Guid, new int[] { 22 }, new object[] { from.HitPoints } );
				else
				{		
					from.HitPoints = 0;					
					if ( from is Character && ( from as Character ).Duel != 0 )
						return;
					from.SendSmallUpdateToPlayerNearMe( from.Guid, new int[] { 22 }, new object[] { from.HitPoints } );
				}
				Stop();
				base.OnTick();
			}
		}
		public void HitPointsUpdate( Mobile from )
		{			
			new DelayHitLoosed( this, from );

			/*	}
				else
				{
					int offset = 10;
					Converter.ToBytes( Guid, hitsUpdate, ref offset );
					offset += 25;
					Converter.ToBytes( hitPoints, hitsUpdate, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_UPDATE_OBJECT, hitsUpdate, offset );
				}*/
		}/*
		public void FullUpdateMobile2( byte[] tempBuff, ref int offset, UInt64 from )
		{
			Converter.ToBytes( (byte)UpdateType.UpdateFull, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );

			Converter.ToBytes( (byte)1, tempBuff, ref offset );//	A9 type 1
			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Unknown 0
			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Movement mask

			Converter.ToBytes( (float)X, tempBuff, ref offset );//	X
			Converter.ToBytes( (float)Y, tempBuff, ref offset );//	Y
			Converter.ToBytes( (float)Z, tempBuff, ref offset );//	Z
			Converter.ToBytes( (float)Orientation, tempBuff, ref offset );//	Orientation

			Converter.ToBytes( (float)RunSpeed, tempBuff, ref offset );//	RunSpeed
			Converter.ToBytes( (float)WalkSpeed, tempBuff, ref offset );//	WalkSpeed
			Converter.ToBytes( (float)SwimSpeed, tempBuff, ref offset );//	SwimSpeed
			Converter.ToBytes( (float)SwimBackSpeed, tempBuff, ref offset );//	SwimBackSpeed
			Converter.ToBytes( (float)4.5, tempBuff, ref offset );//	Vitesse
			Converter.ToBytes( (float)4.5, tempBuff, ref offset );//	Vitesse
			Converter.ToBytes( (float)Math.PI, tempBuff, ref offset );//	PI

			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Unknown 2
			Converter.ToBytes( (int)1, tempBuff, ref offset );//	Unknown 3

			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0x2043DF01, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (byte)0, tempBuff, ref offset );//	A9 type 1

			Converter.ToBytes( Guid, tempBuff, ref offset );//	GUID
			Converter.ToBytes( (int)3, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0x839, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0x3F800000, tempBuff, ref offset );//	Unknown 3

			Converter.ToBytes( from, tempBuff, ref offset );//	GUID
			Converter.ToBytes( from, tempBuff, ref offset );//	GUID
			Converter.ToBytes( (int)1, tempBuff, ref offset );//	Unknown 3
			Converter.ToBytes( (int)0, tempBuff, ref offset );
		}
*/
		public void PreparePartialUpdateData( byte []data, ref int offset )
		{
			int start = offset;
			data[ offset++ ] = (byte)UpdateType.UpdatePartial;			
			Converter.ToBytes( Guid, data, ref offset );
			Converter.ToBytes( (byte)3, data, ref offset );//	type A9 = 3
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			UpdateXYZ();
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			Converter.ToBytes( 0f, data, ref offset );
			if ( WalkSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( WalkSpeed, data, ref offset );
			if ( RunSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( RunSpeed, data, ref offset );
			if ( SwimSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( SwimSpeed, data, ref offset );
			if ( SwimBackSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( SwimBackSpeed, data, ref offset );			
			Converter.ToBytes( (float)Speed, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );
			Converter.ToBytes( (uint)1, data, ref offset );

			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
		
			ResetBitmap();
			setUpdateValue( 0, Guid );
			setUpdateValue( 2, 9 );
			setUpdateValue( 3, Id );//0xE0FF );
			setUpdateValue( 4, (float)size );//0.5 );
			FlushUpdateData( data, ref offset, 1 );
			return;
		}

		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			PrepareUpdateData( data, ref offset, type, forOther, null );
		}
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther, Character f )
		{			
#if TESTCONSECUTIF
			activateorder = true;
			Object.order = 0;
#endif
			
			int start = offset;
			data[ offset++ ] = (byte)UpdateType.UpdateFull;			
			Converter.ToBytes( Guid, data, ref offset );

			Converter.ToBytes( (byte)3, data, ref offset );//	type A9 = 3
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			UpdateXYZ();
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			Converter.ToBytes( 0f, data, ref offset );
			if ( WalkSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( WalkSpeed, data, ref offset );
			if ( RunSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( RunSpeed, data, ref offset );
			if ( SwimSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( SwimSpeed, data, ref offset );
			if ( SwimBackSpeed == 0 )
				Converter.ToBytes( 0.01, data, ref offset );
			else
				Converter.ToBytes( SwimBackSpeed, data, ref offset );			
			Converter.ToBytes( (float)Speed, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );
			Converter.ToBytes( (uint)1, data, ref offset );

			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
		
			ResetBitmap();
			setUpdateValue( 0, Guid );
			setUpdateValue( 2, 9 );
			setUpdateValue( 3, Id );//0xE0FF );
			setUpdateValue( 4, (float)size );//0.5 );
			if ( SummonedBy != null )
			{
				//	setUpdateValue( (int)UpdateFields.UNIT_FIELD_CHARMEDBY, SummonedBy.Guid );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_SUMMONEDBY, SummonedBy.Guid );
				//	setUpdateValue( (int)UpdateFields.UNIT_FIELD_CREATEDBY, SummonedBy.Guid );
			}
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_HEALTH, HitPoints );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, Mana );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXHEALTH, BaseHitPoints);
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType, BaseMana );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_LEVEL, (int)Level );			


			setUpdateValue( (int)UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, (int)Faction );//	Faction template
			uint flags = (uint)( ( (uint)0 ) + ( (int)Classe  << 8 ) + 0 + ((uint)( manaType )<<24) );
			
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_0, flags );

			if ( items != null && items.Length < 4 )
			{
				int t = 0;
				foreach( Item item in items )
				{
					setUpdateValue( (int)UpdateFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY + t, (int)item.Model );
					t++;
				}
				t = 0;
				foreach( Item item in items )
				{
					uint low = ( (uint)item.InventoryType << 24 ) + ( (uint)item.Quality << 16 ) + 
						( (uint)item.SubClass << 8 ) + ( (uint)item.ObjectClass );
					uint high = (uint)item.Sheath;
					setUpdateValue( (int)UpdateFields.UNIT_VIRTUAL_ITEM_INFO + t, low );
					t++;
					setUpdateValue( (int)UpdateFields.UNIT_VIRTUAL_ITEM_INFO + t, high );
					t++;
				}
			}
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_FLAGS, Flags );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME, this.AttackSpeed );//	attackBoniiMin
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME + 1, this.AttackSpeed );// attackBoniiMax
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BOUNDINGRADIUS, (float)boundingRadius );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_COMBATREACH, combatReach );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_DISPLAYID, model );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_NATIVEDISPLAYID, model );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MOUNTDISPLAYID, mountModel );
			if (this is Character)
			{
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MINDAMAGE, (this as Character).BaseMinDamage );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXDAMAGE, (this as Character).BaseMaxDamage );
			}
			else
			{
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MINDAMAGE, minDamage );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXDAMAGE, maxDamage );
			}

			if ( f != null )
				setUpdateValue( (int)UpdateFields.UNIT_DYNAMIC_FLAGS, DynFlags( f ) );


			
			setUpdateValue( (int)UpdateFields.UNIT_CREATED_BY_SPELL, 1 );
			
			setUpdateValue( (int)UpdateFields.UNIT_NPC_FLAGS, NpcFlags );//	NpcFlags
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR, (uint)Armor );//	armor
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_ATTACKPOWER, this.AttackPower );//	unknow		
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_2, 1 );//	unknow
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_RANGEDATTACKPOWER, this.RangedAttackPower );//	unknow	
			FlushUpdateData( data, ref offset, 6 );
			/*
						g = 0x6c;
						Converter.ToBytes( Guid, data, ref g );*/
			/*	HexViewer.View( data, 0, offset, false );

			Console.WriteLine("mobile");
				for(int i = start;i < offset;i++ )
					Console.Write( "{0} ", data[ i ].ToString( "X2" ) );
				Console.WriteLine("");*/
#if TESTCONSECUTIF
			activateorder = false;
#endif
			return;
		}

		// 00 31 96 00 0A 00 00 00 00 F9 2F 15 00 00 00 00 00 1D 00 00 00 57 65 6C 63 6F 6D 65 20 74 6F 20 57 6F 72 6C 64 20 6F 66 20 57 61 72 63 72 61 66 74 00 00 
		// 00 31 96 00 0A 00 00 00 00 2C 30 15 00 00 00 00 00 1D 00 00 00 57 65 6C 63 6F 6D 65 20 74 6F 20 57 6F 72 6C 64 20 6F 66 20 57 61 72 63 72 61 66 74 00 00 
		
		public void PrepareUpdateDataOld( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			int start = offset;
			data[ offset++ ] = (byte)UpdateType.UpdateFull;			
			Converter.ToBytes( Guid, data, ref offset );

			Converter.ToBytes( (byte)3, data, ref offset );//	type A9 = 3
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			Converter.ToBytes( RunSpeed, data, ref offset );
			Converter.ToBytes( WalkSpeed, data, ref offset );
			Converter.ToBytes( SwimSpeed, data, ref offset );
			Converter.ToBytes( SwimBackSpeed, data, ref offset );
			Converter.ToBytes( (float)4.7222f, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Speed, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );
			Converter.ToBytes( (uint)1, data, ref offset );

			offset += 0xc;
			//	Converter.ToBytes( (byte)6, data, ref offset );//	passe
			ResetBitmap();
			setUpdateValue( 0, Guid );
			setUpdateValue( 1, 9 );
			setUpdateValue( 2, (ushort)Id );//0xE0FF );
			setUpdateValue( 3, (short)0 );//0x5F5 );
			setUpdateValue( 4, (float)size );//0.5 );
			setUpdateValue( 30-8, HitPoints );
			setUpdateValue( 31-8, Mana );
			setUpdateValue( 36-8, BaseHitPoints);
			setUpdateValue( 37-8, BaseMana );
			setUpdateValue( 42-8, (int)Level );			
			
			setUpdateValue( 43-8, (int)Faction );//	Faction template, 0x19
			setUpdateValue( 44-8, 0 );
			setUpdateValue( 54-8, 0x1000 );
			setUpdateValue( 139-8, attackBoniiMin );
			setUpdateValue( 140-8, attackBoniiMax );
			setUpdateValue( 142-8, (float)0.389 );
			setUpdateValue( 143-8, 0x40400000 );
			setUpdateValue( 144-8, model );
			setUpdateValue( 145-8, model );
			setUpdateValue( 146-8, 0 );
			setUpdateValue( 148-8, minDamage );
			setUpdateValue( 156-8, maxDamage );

			setUpdateValue( 160-8, NpcFlags );//	NpcFlags	
			setUpdateValue( 163-8, 0 );//	unknow		
			setUpdateValue( 164-8, 0 );//	unknow
			setUpdateValue( 165-8, 0 );//	unknow		
			setUpdateValue( 166-8, 0 ); //	classe
			setUpdateValue( 167-8, 0 ); //	gender
			setUpdateValue( 168-8, 0 );//	manatype
			setUpdateValue( 169-8, 0 ); 
			setUpdateValue( 170-8, 0 );
			setUpdateValue( 171-8, (uint)0);//Str ); //	Str
			setUpdateValue( 172-8, (uint)0);//Agility ); //	Ag
			setUpdateValue( 173-8, (uint)0);//Stamina );//	Stam
			//setUpdateValue( 166, (uint)0);//Iq ); //	IQ
			setUpdateValue( 174-8, (uint)0);//Spirit ); //	Spirit
			/*	setUpdateValue( 168, (uint)0);//Armor );//	armor

				setUpdateValue( 169, (UInt64)0x00000000 );//	semble etre resistance
				setUpdateValue( 171, (UInt64)0x00000000 );
				setUpdateValue( 173, 0x00000000 );
				setUpdateValue( 175, 0x00000000 );
	*/

			//FlushUpdateDataForMobile( data, ref offset, 0x4 );
			FlushUpdateData( data, ref offset, 6 );
			/*
						g = 0x6c;
						Converter.ToBytes( Guid, data, ref g );*/
			/*	HexViewer.View( data, 0, offset, false );
*/
			/*		Console.WriteLine("mobile");
					for(int i = start;i < offset;i++ )
						Console.Write( "{0} ", data[ i ].ToString( "X2" ) );
					Console.WriteLine("");*/
			return;
		}		
		
		/*

		public virtual void PrepareUpdateDataOld( byte []data, ref int offset, UpdateType type )
		{
			data[ offset++ ] = (byte)UpdateType.UpdateFull;			
			Converter.ToBytes( Guid, data, ref offset );

			Converter.ToBytes( (byte)3, data, ref offset );//	type A9 = 3
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			Converter.ToBytes( RunSpeed, data, ref offset );
			Converter.ToBytes( WalkSpeed, data, ref offset );
			Converter.ToBytes( SwimSpeed, data, ref offset );
			Converter.ToBytes( SwimBackSpeed, data, ref offset );
			Converter.ToBytes( (float)4.5f, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)1, data, ref offset );//	NPC type
			Converter.ToBytes( (uint)1, data, ref offset );//	NPC type			
			offset += 0xc;
			Converter.ToBytes( (byte)6, data, ref offset );//	NPC type
			ResetBitmap();
			setUpdateValue( 1, 4191 );
			setUpdateValue( 2, (float)1 );
			setUpdateValue( 8, HitPoints );
			setUpdateValue( 9, Mana);			
			setUpdateValue( 10, BaseHitPoints);
			setUpdateValue( 11, BaseMana);
			setUpdateValue( 12,(short)Level );//	Level

			setUpdateValue( 30,(byte)0 );//	unknow	
			setUpdateValue( 31, (short)0x1900 );//	unknow		
			setUpdateValue( 36, (short)0x0000 );//	unknow
			setUpdateValue( 37, (short)0x00 );//	unknow		
			setUpdateValue( 42, (byte)0 ); //	classe
			setUpdateValue( 43, (byte)0 ); //	gender
			setUpdateValue( 44, (byte)0 );//	manatype
			setUpdateValue( 54, 0x1000 ); 
			setUpdateValue( 139, 0x07D0 );
			setUpdateValue( 140, 0x07D0 );
			setUpdateValue( 142, (float)0.389f );
			setUpdateValue( 143, 0x40400000 );
			setUpdateValue( 144, model );//	model, 0x61C
			setUpdateValue( 145, model );
			//setUpdateValue( 144, 0x011C );
			//setUpdateValue( 145, 0x061C );
			setUpdateValue( 146, 0x00000000 );
			setUpdateValue( 147, (float)1.542857 );
			setUpdateValue( 148, (float)1.542857 );
			setUpdateValue( 160, (int)0x4 );
			setUpdateValue( 163, (uint)0);//Str ); //	Str
			setUpdateValue( 164, (uint)0);//Agility ); //	Ag
			setUpdateValue( 165, (uint)0);//Stamina );//	Stam
			setUpdateValue( 166, (uint)0);//Iq ); //	IQ
			setUpdateValue( 167, (uint)0);//Spirit ); //	Spirit
			setUpdateValue( 168, (uint)0);//Armor );//	armor

			setUpdateValue( 169, (UInt64)0x00000000 );//	semble etre resistance
			setUpdateValue( 171, (UInt64)0x00000000 );
			setUpdateValue( 173, 0x00000000 );
			setUpdateValue( 175, 0x00000000 );



			//FlushUpdateDataForMobile( data, ref offset, 0x4 );
			FlushUpdateData( data, ref offset, 1, 1, 4 );
			return;
		}
*/
		public virtual void PreparePartielUpdateData( byte []data, ref int offset )
		{//	pas fini
			data[ offset++ ] = (byte)UpdateType.UpdatePartial;		
			Converter.ToBytes( Guid, data, ref offset );

			ResetBitmap();
			setUpdateValue( 2, (byte)0 );
			setUpdateValue( 3, (byte)0 );
			setUpdateValue( 4, (short)0 );
			setUpdateValue( 31, (short)0 );
			setUpdateValue( 36, (int)Mana );
			setUpdateValue( 37, (int)BaseHitPoints );
			setUpdateValue( 139, (int)BaseMana );
			setUpdateValue( 140, (int)0xB54 );
			setUpdateValue( 141, (int)0xB54 );
			setUpdateValue( 147, (int)0 );//	don't know why
			setUpdateValue( 147, (float)0 );
			setUpdateValue( 148, (float)9.0 );

			setUpdateValue( 163, (int)Str );
			setUpdateValue( 164, (int)Agility );
			setUpdateValue( 165, (int)Stamina );
			setUpdateValue( 166, (int)Iq );
			setUpdateValue( 167, (int)Spirit );
			setUpdateValue( 168, (int)Armor );

			setUpdateValue( 169, (int)1 );
			setUpdateValue( 170, (int)2 );//	FIre resist
			setUpdateValue( 171, (int)3 );//	Nature resist
			setUpdateValue( 172, (int)4 );//	Frost resist
			setUpdateValue( 173, (int)5 );//	Shadow resist
			setUpdateValue( 174, (int)6 );//	Arcane resist

			setUpdateValue( 182, (int)0 );
			setUpdateValue( 183, (int)0 );


			setUpdateValue( 831, (int)0 );
			setUpdateValue( 832, (int)0 );
			setUpdateValue( 833, (int)0 );
			setUpdateValue( 834, (int)0 );
			setUpdateValue( 835, (short)0 );

			//	FlushPartialUpdateDataForMobile( data, ref offset, 0 );
			FlushUpdateData( data, ref offset, 1, 1, 2 );
			/*	for(int i = 0;i < offset;i++ )
					Console.Write( "{0} ", data[ i ].ToString( "X2" ) );
				Console.WriteLine("");*/
			return;
		}

		#endregion

		#region SPELLTIMERS
		public delegate void SpellStartRun();
		public class SpellCastTimer : WowTimer
		{
			SpellStartRun whenReady;
			public SpellCastTimer( SpellStartRun st, int mili ) : base( WowTimer.Priorities.Milisec100 , mili, "SpellCastTimer" )
			{				
				whenReady = st;
				Start();
			}
			public override void OnTick()
			{
				Console.WriteLine("Id = {0}/{1}", whenReady.Target.GetType().ToString(), whenReady.Method.Name );
				whenReady();
				Stop();
				base.OnTick();
			}

		}
		private delegate void SpellEndCoolDown();
		private class SpellCoolDownTimer : WowTimer
		{
			SpellEndCoolDown whenReady;
			public SpellCoolDownTimer( SpellEndCoolDown st, int mili ) : base( WowTimer.Priorities.Milisec100 , mili, "SpellCoolDownTimer" )
			{
				whenReady = st;
				Start();
			}
			public override void OnTick()
			{
				whenReady();
				Stop();
				base.OnTick();
			}

		}
		#endregion

		#region SPELLS
	
		#region CHANNELING

		public struct Channeling
		{
			public int channeling;
			public ChannelReleaseTimer crt;
			public long duration;
			public Object channelingTarget;
		}
		private Channeling chan;
		public Channeling Chan
		{
			get{return chan;}
		}
		public void ChannelStart(Object _target, int _spell, long _duration)
		{	
			if (_spell != 0)
			{
				chan.channeling = _spell;
				chan.duration = _duration;
				chan.channelingTarget = _target;
			}
			if(this is Character)
			{
				byte[] buff = new byte[16];
				int i = 4;

				Converter.ToBytes((uint)_spell, buff, ref i);
				Converter.ToBytes((ulong)_duration, buff, ref i);

				(this as Character).Send(OpCodes.MSG_CHANNEL_START, buff, i);
			}
			if (_target is Mobile)	(_target as Mobile).channelTarget = true;

			this.ChannelObject(_target, _spell);

			ChannelReleaseTimer crtimer = new ChannelReleaseTimer(this, _duration);
			crtimer.Start();
			chan.crt =  crtimer;
		}
		public bool ChannelEnd(int spell)
		{
			if (this.chan.channeling != 0)
			{
				if (spell == this.chan.channeling)
				{
					this.ChannelEnd();
					if (chan.channelingTarget is Mobile)
						(chan.channelingTarget as Mobile).channelTarget = false;
					return true;
				}
			}
			return false;
		}
		public void CooldownReset(int spell)
		{
			byte []buff = new byte[24];
			int offset = 4;
			Converter.ToBytes(spell, buff, ref offset);
			Converter.ToBytes(this.Guid, buff, ref offset);
			(this as Character).Send(OpCodes.SMSG_CLEAR_COOLDOWN,buff,offset);
		}
		public void CooldownReset(ClassesOfSpells spellClass)
		{
			
			for(int j = 0;j<30000;j++)
			{
				if( AbilityClasses.abilityClasses[j] == (int)spellClass)
				{
					byte []buff = new byte[24];
					int offset = 4;
					Converter.ToBytes(j, buff, ref offset);
					Converter.ToBytes(this.Guid, buff, ref offset);
					(this as Character).Send(OpCodes.SMSG_CLEAR_COOLDOWN,buff,offset);
				}
			}
		}
		public void ChannelEnd()
		{
			if (this.chan.channeling != 0)
			{
				AuraEffect af = (AuraEffect)Abilities.abilities[chan.channeling];
				if (chan.channelingTarget is Mobile)
					(chan.channelingTarget as Mobile).ReleaseAura(af);
				if(this is Character)
				{
					byte[] buff = new byte[16];
					int i = 4;

					//Converter.ToBytes((uint)chan.channeling, buff, ref i);
					Converter.ToBytes((ulong)1, buff, ref i);

					(this as Character).Send(OpCodes.MSG_CHANNEL_UPDATE, buff, i);
					this.SpellFaillure(SpellFailedReason.Interrupted);
				}
				chan.crt.OnTick();
				chan.channeling = 0;
				chan.duration = 0;
				if (chan.channelingTarget is Mobile)
					(chan.channelingTarget as Mobile).channelTarget = false;
				chan.channelingTarget = null;
			}
		}
		#endregion

		#region FAKE SPELLS
		public class CastFakeSpellTimerSpe : WowTimer
		{
			Mobile.WhenDone	trigerWhenDone;	
			int spell;
			Mobile from;
			Mobile target;
			public CastFakeSpellTimerSpe( Mobile src, Mobile to, int sp, int castingtime, Mobile.WhenDone triger ) :  base( castingtime, "CastFakeSpellTimerSpe" )
			{
				target = to;
				from = src;
				spell = sp;
				trigerWhenDone = triger;
				Start();
			}
			public CastFakeSpellTimerSpe( Mobile src, Mobile to, int sp, int castingtime ) :  base( castingtime, "CastFakeSpellTimerSpe" )
			{
				target = to;
				from = src;
				spell = sp;
				Start();
			}
			public override void OnTick()
			{
				Stop();
				//	Release
				byte []releaseEffect = { 0, 0, 0, 0, 0xED, 0x0E, 0x00, 0x00, 0x00 };
				int offset = 4;
				Converter.ToBytes( spell, releaseEffect, ref offset );
				if (from is Character)
				( from as Character ).Send( OpCodes.SMSG_CAST_RESULT, from.tempBuff, offset );


				/*
				  65 77 E4 00 00 00 00 00 
				  65 77 E4 00 00 00 00 00 
				  62 1C 00 00 
				  00 01 01 
				  36 B7 E3 00 00 00 00 00
				  00 42 00 
				  36 B7 E3 00 00 00 00 00 
				  3E 54 0B C6 
				  04 71 DE C2 
				  1D 3D A5 42 */
				offset = 4;
				Converter.ToBytes( target.Guid, from.tempBuff, ref offset );
				Converter.ToBytes( target.Guid, from.tempBuff, ref offset );					
				Converter.ToBytes( spell, from.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, from.tempBuff, ref offset );
				Converter.ToBytes( (short)0x0101, from.tempBuff, ref offset );
				Converter.ToBytes( from.Guid, from.tempBuff, ref offset );
				Converter.ToBytes( (byte)0, from.tempBuff, ref offset );
				Converter.ToBytes( (short)0x0042, from.tempBuff, ref offset );
				Converter.ToBytes( from.Guid, from.tempBuff, ref offset );
				Converter.ToBytes( from.X, from.tempBuff, ref offset );
				Converter.ToBytes( from.Y, from.tempBuff, ref offset );
				Converter.ToBytes( from.Z, from.tempBuff, ref offset );
				from.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, from.tempBuff, offset );
				
				if ( trigerWhenDone != null )
					trigerWhenDone();
				from.cast.castingtime = 0;
				from.cast.cool = 0;
				from.cast.radius = 0;
				from.cast.duration = 0;
				from.cast.id = 0;
				from.cast.manacost = 0;
				from.cast.type = 0;
				from.cast.baseability = null;
				base.OnTick();

			}
		}
		public class CastFakeSpellTimer : WowTimer
		{
			Mobile.WhenDone	trigerWhenDone;	
			int spell;
			Mobile from;
			Mobile target;
			public CastFakeSpellTimer( Mobile src, Mobile to, int sp, int castingtime, Mobile.WhenDone triger ) :  base( castingtime, "CastFakeSpellTimer" )
			{
				target = to;
				from = src;
				spell = sp;
				trigerWhenDone = triger;
				Start();
			}
			public CastFakeSpellTimer( Mobile src, Mobile to, int sp, int castingtime ) :  base( castingtime, "CastFakeSpellTimer" )
			{
				target = to;
				from = src;
				spell = sp;
				Start();
			}
			public override void OnTick()
			{
				Stop();
				//	Release
				byte []releaseEffect = { 0, 0, 0, 0, 0xED, 0x0E, 0x00, 0x00, 0x00 };
				int offset = 4;
				Converter.ToBytes( spell, releaseEffect, ref offset );
				if (from is Character)
					(from as Character).Send( OpCodes.SMSG_CAST_RESULT, releaseEffect, releaseEffect.Length );


				//	Instant effet
				if ( from.cast.type == 0x40 )
				{
					offset = 4;
					Converter.ToBytes( (UInt64)0, from.tempBuff, ref offset );
					Converter.ToBytes( from.Guid, from.tempBuff, ref offset );
					Converter.ToBytes( spell, from.tempBuff, ref offset );
					Converter.ToBytes( (byte)0, from.tempBuff, ref offset );
					Converter.ToBytes( (short)0x0201, from.tempBuff, ref offset );
					Converter.ToBytes( (UInt64)0x32, from.tempBuff, ref offset );
					Converter.ToBytes( (byte)0, from.tempBuff, ref offset );
					Converter.ToBytes( (UInt64)1, from.tempBuff, ref offset );
					Converter.ToBytes( from.cast.type, from.tempBuff, ref offset );
					Converter.ToBytes( from.spellTargetX, from.tempBuff, ref offset );
					Converter.ToBytes( from.spellTargetY, from.tempBuff, ref offset );
					Converter.ToBytes( from.spellTargetZ, from.tempBuff, ref offset );
					from.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, from.tempBuff, offset );
				}
				else
				{
					byte []effect = { 0, 0, 0, 0, 
										0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF7, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xED, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x01, 0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
					offset = 4;
					Converter.ToBytes( target.Guid, effect, ref offset );
					Converter.ToBytes( from.Guid, effect, ref offset );
					Converter.ToBytes( (int)spell, effect, ref offset );
					offset+=4;
					//		if ( lastSeen != null && lastSeen.Player != null )
					from.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, effect, effect.Length );
				}


				if ( trigerWhenDone != null )
					trigerWhenDone();
				from.cast.castingtime = 0;
				from.cast.cool = 0;
				from.cast.id = 0;
				from.cast.manacost = 0;
				from.cast.radius = 0;
				from.cast.duration = 0;
				from.cast.type = 0;
				from.cast.baseability = null;
				base.OnTick();

			}
		}
		/*
				65 77 E4 00 00 00 00 00 
				65 77 E4 00 00 00 00 00 
				62 1C 00 00 
				02 00 00 00 
				00 00 02 00 
				36 B7 E3 00 00 00 00 00*/
		public void FakeCastSpe( int spell, Mobile target, WhenDone trigger )
		{
			
			int offset = 4;
			
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( spell, tempBuff, ref offset );
			Converter.ToBytes( 2, tempBuff, ref offset );
			Converter.ToBytes( 0x20000, tempBuff, ref offset );
			Converter.ToBytes( target.Guid, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );
			CastFakeSpellTimerSpe cfst = new CastFakeSpellTimerSpe( this, target, spell, (int)Abilities.abilities[ spell ].CastingTime( this ), trigger );
		}
		public void FakeCast( int spell, Mobile target, WhenDone trigger )
		{
			byte []buff = { 0,0, 0,0, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x03, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
			int offset = 4;
			
			Converter.ToBytes( target.Guid, buff, ref offset );
			Converter.ToBytes( Guid, buff, ref offset );
			Converter.ToBytes( spell, buff, ref offset );
			Converter.ToBytes( 0x100, buff, ref offset );
			Converter.ToBytes( 0, buff, ref offset );
			//if ( lastSeen != null && lastSeen.Player != null )
			ToAllPlayerNear( OpCodes.SMSG_SPELL_START, buff, buff.Length );
			/*else
					if ( this is Character )
					( this as Character ).Player.ToAllPlayerNear( OpCodes.SMSG_SPELL_START, buff, buff.Length );
				else
					if ( SummonedBy != null )
					( SummonedBy as Character ).Player.ToAllPlayerNear( OpCodes.SMSG_SPELL_START, buff, buff.Length );
				else
					if ( target.SummonedBy != null )
					( target.SummonedBy as Character ).Player.ToAllPlayerNear( OpCodes.SMSG_SPELL_START, buff, buff.Length );
					*/
			CastFakeSpellTimer cfst = new CastFakeSpellTimer( this, target, spell, (int)Abilities.abilities[ spell ].CastingTime( this ), trigger );
			//Console.WriteLine( "Begin cast at {0}", DateTime.Now.Ticks );
		}

		public void FakeCast( int spell, Mobile target, float x, float y, float z )
		{
			FakeCast( spell, target, x, y, z, null );
		}
		public void FakeCast( int spell, Mobile target, float x, float y, float z, WhenDone trigger )
		{
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( spell, tempBuff, ref offset );
			BaseAbility ba = (BaseAbility)Abilities.abilities[ spell ];
			Converter.ToBytes( (ushort)0x100, tempBuff, ref offset );
			Converter.ToBytes( cast.castingtime, tempBuff, ref offset );
			Converter.ToBytes( cast.type = (ushort)0x40, tempBuff, ref offset );					
			Converter.ToBytes( spellTargetX = x, tempBuff, ref offset );
			Converter.ToBytes( spellTargetY = y, tempBuff, ref offset );
			Converter.ToBytes( spellTargetZ = z, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	

			CastFakeSpellTimer cfst = new CastFakeSpellTimer( this, target, spell, cast.castingtime, trigger );
		}

		public void FakeCast( int spell, Mobile target )
		{
			FakeCast( spell, target, null );
		}
		#endregion

				
	
		#region SPELL MANAGEMENT

		//  structures and variables
	
		public struct SpellXYZtarget
		{
			public float X;
			public float Y;
			public float Z;			
		}

		public struct Casting
		{
			public int cool;
			public int manacost;
			public int id;
			public int castingtime;
			public BaseAbility baseability;
			public ushort type;
			public short radius;
			public int duration;
		}
		
		
		public Casting cast;

		Object spellTarget;
		Item targetedItem;
		float spellTargetX;
		float spellTargetY;
		float spellTargetZ;

		object primarySpellTarget;

		// CMSG getting
		
		public virtual bool OnCastSpellCMSG(byte[] data,int after,ushort type)
		{
			#region cast creation
		{
			BaseAbility ba;
				
			ba = (BaseAbility)Abilities.abilities[BitConverter.ToInt32( data, after + 6 )];
				
			if (ba is SpellTemplate)
			{
				SpellTemplate st;
					
				st = (SpellTemplate)ba;
					
						
				this.cast.castingtime = st.CastingTime(this);
				this.cast.cool = st.CoolDown(this);
				this.cast.id = st.Id;
				this.cast.manacost = st.GetManaCost(this);
				this.cast.type = type;
				this.cast.baseability = st;
				int radius = st.Radius1;
				if(st.Radius2 > radius) radius = st.Radius2;
				if(st.Radius3 > radius) radius = st.Radius3;
				if(ba is AuraEffect)
					this.cast.duration = (ba as AuraEffect).Duration(this);
				else cast.duration = 0;
				this.cast.radius = (short)radius;
					
						
			}
			else
				if ( ba is Profession )
			{
				this.cast.castingtime = ba.CastingTime(this);
				this.cast.cool = ba.CoolDown(this);
				this.cast.id = ( ba as Profession ).SpellId;
				this.cast.manacost = 0;
				this.cast.type = type;
				this.cast.baseability = ba;	
				this.cast.duration = 0;
				this.cast.radius = (short)0;
			}
			else
			{					
				this.cast.castingtime = ba.CastingTime(this);
				this.cast.cool = ba.CoolDown(this);
				this.cast.id = ba.Id;
				this.cast.manacost = 0;
				this.cast.type = type;
				this.cast.duration = 0;
				this.cast.baseability = ba;	
				this.cast.radius = (short)0;
						
			}
		}
			#endregion
			
			cast.baseability.SendCooldown(cast, this );

			if(this.AutoShot != null)
			{this.AutoShot.Restart();}
		
			if ( type == 0 )
			{
				spellTarget = this;
				targetedItem = null;
			
				SpellExecutionStart(cast,this,false);
			}
			else
				if( ( type & 0x2 ) != 0 || ( type & 0x800 ) != 0 || ( type & 0x8000 ) != 0 )
			{
				Object target = null;
				if ( this is Character )
					target = ( this as Character ).Player.FindObjectByGuid( BitConverter.ToUInt64( data, after + 12 ) );
				else
				{
					UInt64 g = BitConverter.ToUInt64( data, after + 12 );
					foreach( Object m in this.KnownObjects )
						if ( m is Mobile )
						{
							Mobile mob = m as Mobile;
							if ( mob.Guid == g )
							{
								target = mob;
								break;
							}
						}
				}
				if ( target == null )
				{
					this.SpellFaillure(SpellFailedReason.InvalidTarget);
					return false;
				}
				else
				{
					targetedItem = null;				
					spellTarget = target;
					
					SpellExecutionStart(cast,target,false);
				}
			}	
			else
				if( ( type & 0x10 ) != 0 || ( type & 0x1000 ) != 0 ) 
			{
				Item target = null;
				if ( this is Character )( this as Character ).FindItemByGuid( BitConverter.ToUInt64( data, after + 12 ) );
				if ( target == null )
				{
					this.SpellFaillure(SpellFailedReason.InvalidTarget);
					return false;
				}
				else SpellExecutionStart(cast,target,false);
			}
			else
				if( ( type & 0x20 ) != 0 || ( type & 0x40 ) != 0 ) 
			{
				spellTargetX = BitConverter.ToSingle( data, after + 12 );
				spellTargetY = BitConverter.ToSingle( data, after + 16 );
				spellTargetZ = BitConverter.ToSingle( data, after + 20 );
				targetedItem = null;
				spellTarget = null;
				
				SpellXYZtarget xyztarget = new SpellXYZtarget();
				xyztarget.X = BitConverter.ToSingle( data, after + 12 );
				xyztarget.Y = BitConverter.ToSingle( data, after + 16 );
				xyztarget.Z = BitConverter.ToSingle( data, after + 20 );
				if(this.cast.baseability is SpellTemplate)
				{
					if(this.Distance(spellTargetX,spellTargetY,spellTargetZ) > Math.Pow((this.cast.baseability as SpellTemplate).Range(this),2))
					{
						this.SpellFaillure(SpellFailedReason.OutOfRange);
						return false;
					}
							
				}
				SpellExecutionStart(cast,xyztarget,false);
			}
			else
				Console.WriteLine("Sort bizaroide {0},{1}", type, BitConverter.ToInt32( data, after + 6 ) );

			#region no used
			/*if ( type == 0 )
				this.CastOnSelf( false, BitConverter.ToInt32( data, after + 6 ), type );
			else
				if( ( type & 0x2 ) != 0 || ( type & 0x800 ) != 0 || ( type & 0x8000 ) != 0 )
			{
				this.SingleTargetCastSpell(BitConverter.ToUInt64( data, after + 12 ), BitConverter.ToInt32( data, after + 6 ), type );
			}	
			else
				if( ( type & 0x10 ) != 0 || ( type & 0x1000 ) != 0 ) 
				this.ItemTargetCastSpell( BitConverter.ToUInt64( data, after + 12 ), BitConverter.ToInt32( data, after + 6 ), type );
			else
				if( ( type & 0x20 ) != 0 || ( type & 0x40 ) != 0 ) 
				this.ZoneCastSpell( BitConverter.ToInt32( data, after + 6 ), type, BitConverter.ToSingle( data, after + 12 ), BitConverter.ToSingle( data, after + 16 ), BitConverter.ToSingle( data, after + 20 ) );
			else
				Console.WriteLine("Sort bizaroide {0},{1}", type, BitConverter.ToInt32( data, after + 6 ) );
			*/
			#endregion

			return true;
		}
		public static int StrToInt(string str)
		{
			int num = 0;
			int g = str.Length;
			bool negative = false;
			
			for(int j = 0;j < g;j++)
				
			{
				if(str[j] == '-') negative = true;
				else
				{
					int nas = 1;
					for (int k = 1; k<=(g - (j+1));k++)
						nas *=10; 
					num += ((int)str[j]-48)*nas;
				}
			}
			if(negative) num *=-1;
			
			return num;
		}
		public static int BinaryNumInStrToInt(string str)
		{
			int num = 0;
			int g = str.Length;
			bool negative = false;
			
			for(int j = 0;j < g;j++)
				
			{
				if(str[j] == '-') negative = true;
				else
				{
					int nas = 1;
					for (int k = 1; k<=(g - (j+1));k++)
						nas *=2; 
					num += ((int)str[j]-48)*nas;
				}
			}
			if(negative) num *=-1;
			
			return num;
		}
		public void SendSpellFlatModifier(int spell)
		{
			if (this is Character)
			{
				if(Abilities.abilities[spell] != null)
					if(Abilities.abilities[spell] is SpellTemplate)
					{
						SpellTemplate st = (SpellTemplate)Abilities.abilities[spell];
						if(ModifierSpells.modifierSpells[spell] != null)
						{
							string mask = (string)ModifierSpells.modifierSpells[spell];
							string[] maskArray = mask.Split('|');
							for (int i =0; i<3; i++)
							{
								if((byte)BinaryNumInStrToInt(maskArray[i]) != 0)
								{
									Console.WriteLine((byte)BinaryNumInStrToInt(maskArray[i]));
									Console.WriteLine((byte)StrToInt(maskArray[i+3]));
									int offset = 4;
									Converter.ToBytes( (byte)BinaryNumInStrToInt(maskArray[i]), tempBuff, ref offset );
									Converter.ToBytes( (byte)StrToInt(maskArray[i+3]), tempBuff, ref offset );
									switch(i)
									{
										case 0: Converter.ToBytes( (int)((float)st.S1/1000), tempBuff, ref offset );break;
										case 1: Converter.ToBytes(  (int)((float)st.S2/1000), tempBuff, ref offset );break;
										case 2: Converter.ToBytes(  (int)((float)st.S3/1000), tempBuff, ref offset );break;
									}
									(this as Character).Send(Server.OpCodes.SMSG_SET_FLAT_SPELL_MODIFIER,tempBuff,offset);
								}
							}
						}
					}
			}
		
		}
		public class RangedUseTimer : WowTimer
		{
			Mobile caster;
			public Mobile.Casting cast;

			public RangedUseTimer( Mobile.Casting _cast,Mobile _caster, long _duration )
				: base(Priorities.Milisec100, _duration, "RangedUseTimer" )
			{
				this.caster = _caster;
				this.cast = _cast;
				caster.AdditionnalStates.Add(this);
				this.Start();			
			}

			public override void OnTick()
			{
				if(caster.AdditionnalStates.Contains(this))
					caster.AdditionnalStates.Remove(this);
				this.Stop();
			}
		}

		public virtual bool SpellExecutionStart(Casting cast,object target,bool fromObject)
		{			
			
			this.primarySpellTarget = target;
			if(this.spellTarget == null && target is Object ) this.spellTarget = target as Object;
			if (!fromObject)
			{
				if(!cast.baseability.CheckSpellCaster(this)) return false;
				if(!(primarySpellTarget is SpellXYZtarget) || !(primarySpellTarget is Item))
					if(!cast.baseability.CheckSpellTarget(this,primarySpellTarget as Object)) return false;
			}
			
			if(cast.id == 75)
			{	
				if(this.combatTimer != null) this.combatTimer.Stop();
				if(this.combatTimer != null) Console.WriteLine("stop1" + this.combatTimer.Delay);
				if(this is Character)
				{
					if((this as Character).SecondCombatTimer != null) (this as Character).SecondCombatTimer.Stop();
					if((this as Character).SecondCombatTimer != null) Console.WriteLine("stop1");
					if((this as Character).FirstCombatTimer != null) (this as Character).FirstCombatTimer.Stop();
					if((this as Character).FirstCombatTimer != null) Console.WriteLine("stop2" );
				}
				#region AutoShot
				if (target is Mobile)
				{
					SpellTemplate st = (SpellTemplate)cast.baseability;
					SingleTargetSpellEffect stse =( SingleTargetSpellEffect)SpellTemplate.SpellEffects[cast.id];
					stse(st,this,target as Mobile);
				}
				#endregion
			}
			else if(SpellTemplate.SpellEffects[cast.id] != null)
			{
				#region attack speed spells with projectile
				if((SpellTemplate.SpellEffects[cast.id] is SingleTargetSpellEffectAttackSpeedRanged) || (SpellTemplate.SpellEffects[cast.id] is SingleTargetSpellEffectAttackSpeedRangedMultiple))
				{	
					if(this.combatTimer != null) this.combatTimer.Stop();
					if(this.combatTimer != null) Console.WriteLine("stop1" + this.combatTimer.Delay);
					if(this is Character)
					{
						if((this as Character).SecondCombatTimer != null) (this as Character).SecondCombatTimer.Stop();
						if((this as Character).SecondCombatTimer != null) Console.WriteLine("stop1");
						if((this as Character).FirstCombatTimer != null) (this as Character).FirstCombatTimer.Stop();
						if((this as Character).FirstCombatTimer != null) Console.WriteLine("stop2" );
					}
				{
						
					Mobile mob = (Mobile)target;
					if(mob != null)
					{
							
						this.OnSpellTemplateResults(cast.baseability,mob);
						Item weapon = this.RangedWeapon;
						Item ammo = this.RangedAmmo;
							
						if (weapon == null)
						{
								
							this.SpellFaillure(SpellFailedReason.YourWeaponHandIsEmpty);
							return false;
						}
													
						if((weapon.InventoryType == InventoryTypes.Thrown))
							ammo = weapon;
						bool skip = false;
						foreach(object obj in this.AdditionnalStates)
						{
							if(obj is RangedUseTimer)
							{
								RangedUseTimer rut = (RangedUseTimer)obj;
								if(rut.cast.id == this.cast.id)
								{
									Console.WriteLine("UHHUHHUHHHUHHU");
									#region Cast Result send
									this.SpellFaillure(SpellFailedReason.AbilityIsntReadyYet);
									#endregion
									skip = true;
								}

							}
						}
						if(!skip)
						{
							if(cast.castingtime > 0)
							{
								RangedUseTimer rut1 = new RangedUseTimer(this.cast,this,(int)(this.RangedAttackSpeed*1000) + cast.castingtime);
							}
							else
							{
								RangedUseTimer rut1 = new RangedUseTimer(this.cast,this,(int)(this.RangedAttackSpeed*1000));
							}
							int offset = 4;
							Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
							Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
							Converter.ToBytes( cast.id, this.tempBuff, ref offset );
							Converter.ToBytes( (short)0x22, this.tempBuff, ref offset );
							Converter.ToBytes( (uint)0x000001c7, this.tempBuff, ref offset );
							Converter.ToBytes( (ushort)0x2, this.tempBuff, ref offset );
							Converter.ToBytes( mob.Guid, this.tempBuff, ref offset );
							if(ammo != null)
							{
								Console.WriteLine("ommo ok");
								Converter.ToBytes( (uint)ammo.Model, this.tempBuff, ref offset );
								Converter.ToBytes( (uint)ammo.InventoryType, this.tempBuff, ref offset );
							}
							this.ToAllPlayerNear( OpCodes.SMSG_SPELL_START, this.tempBuff, offset );
							
							spellCastTimer = new SpellCastTimer( new SpellStartRun( this.SpellStart ), (int)500 );

							
						}

					}
				}
			
				}
					#endregion 
					#region NextAttackEffectDelegate + multiple one
				else if(SpellTemplate.SpellEffects[cast.id] is NextAttackEffectDelegate )
				{
					if (target is Mobile)
					{
						Mobile mob = (Mobile)target;
						if(mob != null)
						{
							this.OnSpellTemplateResults(cast.baseability,mob);
						
							NextAttackEffect nae = new NextAttackEffect(cast.baseability,(NextAttackEffectDelegate)SpellTemplate.SpellEffects[cast.id]);
							this.nextAttackEffects.Add(nae);
					
							int offset = 4;
					
							Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
							Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
							Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
							Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
							Converter.ToBytes( (uint)cast.castingtime, tempBuff, ref offset );
							Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );				
							Converter.ToBytes( (ulong)mob.Guid, tempBuff, ref offset );
					
							ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	
						}
						else
							this.SpellFaillure(SpellFailedReason.InvalidTarget);
					}
					else
						this.SpellFaillure(SpellFailedReason.InvalidTarget);
				}
				else if(SpellTemplate.SpellEffects[cast.id] is NextAttackEffectDelegateMultiple )
				{
					if (target is Mobile)
					{
						Mobile mob = (Mobile)target;
						if(mob != null)
						{
							this.OnSpellTemplateResults(cast.baseability,mob);
						
							NextAttackEffect nae = new NextAttackEffect(cast.baseability,(NextAttackEffectDelegateMultiple)SpellTemplate.SpellEffects[cast.id]);
							this.nextAttackEffects.Add(nae);
					
							int offset = 4;
					
							Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
							Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
							Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
							Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
							Converter.ToBytes( (uint)cast.castingtime, tempBuff, ref offset );
							Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );				
							Converter.ToBytes( (ulong)mob.Guid, tempBuff, ref offset );
					
							ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	
						}
						else
							this.SpellFaillure(SpellFailedReason.InvalidTarget);
					}
					else
						this.SpellFaillure(SpellFailedReason.InvalidTarget);
				}
					#endregion
					#region base
				else
				{
					if(this.combatTimer != null) this.combatTimer.Stop();
					if(this.combatTimer != null) Console.WriteLine("stop1" + this.combatTimer.Delay);
					if(this is Character)
					{
						if((this as Character).SecondCombatTimer != null) (this as Character).SecondCombatTimer.Stop();
						if((this as Character).SecondCombatTimer != null) Console.WriteLine("stop1");
						if((this as Character).FirstCombatTimer != null) (this as Character).FirstCombatTimer.Stop();
						if((this as Character).FirstCombatTimer != null) Console.WriteLine("stop2" );
					}
					this.SendSMSGSpellStart(cast,this,this.primarySpellTarget);
					if(cast.castingtime <=0)
					{
						SpellStart();
					}
					else
					{
						
						spellCastTimer = new SpellCastTimer( new SpellStartRun( this.SpellStart ), (int)cast.castingtime );

					}
				}
				#endregion
			}
			return true;
		
		}

		#region spell starts by type
		public virtual void ZoneCastSpell( int spell, ushort type, float x, float y, float z )
		{
			float[] zone = {x,y,z};
			if (this is Character)
			{
				if(!cast.baseability.CheckSpell(this,null)) return;
			}
			if ( HaveSpell( spell ) )
			{
				spellTargetX = x;
				spellTargetY = y;
				spellTargetZ = z;
				targetedItem = null;
				spellTarget = null;
				/*
				F6 00 00 00 00 00 00 00 
				F6 00 00 00 00 00 00 00 
				48 08 00 00 
				00 01 B8 0B 00 00 40 00 06 BF CF 44 FB C3 D1 44 6F 0F F1 42 
				*/
				if ( cast.castingtime <= 0 )
				{
					SpellStart();
				}
				else
				{
					int offset = 4;
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( cast.id, tempBuff, ref offset );
					Converter.ToBytes( (ushort)0x100, tempBuff, ref offset );
					Converter.ToBytes( cast.castingtime, tempBuff, ref offset );
					Converter.ToBytes( cast.type, tempBuff, ref offset );					
					Converter.ToBytes( spellTargetX, tempBuff, ref offset );
					Converter.ToBytes( spellTargetY, tempBuff, ref offset );
					Converter.ToBytes( spellTargetZ, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	

					spellCastTimer = new SpellCastTimer( new SpellStartRun( this.SpellStart ), (int)cast.castingtime );
				}
			}
		}
	
		public virtual void ItemTargetCastSpell(UInt64 targetGuid, int spell, ushort type )
		{
		}
		
		public virtual void SingleTargetCastSpell( UInt64 targetGuid, int spell, ushort type )
		{
			Object target = null;
			if ( this is Character )
				target = ( this as Character ).Player.FindObjectByGuid( targetGuid );
			else
				target = FindObjectByGuid( targetGuid );
			if ( target == null )
				return;
			SingleTargetCastSpell( target, spell, type );
		}

		public Object FindObjectByGuid( UInt64 g )
		{
			foreach( Object m in this.KnownObjects )
				if ( m.Guid == g )
					return m;
			return null;	
		}
		
		public virtual void SingleTargetCastSpell( Object target, int spell, ushort type )
		{
			if ( this is Character )
			{
				//( this as Character ).StopAttacking();
				if(!cast.baseability.CheckSpell(this,target)) return;
			}
			if(SpellTemplate.SpellEffects[cast.id] is NextAttackEffectDelegate && ( type & 0x2 ) != 0 )
			{
				Mobile mob = (Mobile)target;
				if(mob != null)
				{
					NextAttackEffect nae = new NextAttackEffect(cast.baseability,(NextAttackEffectDelegate)SpellTemplate.SpellEffects[cast.id]);
					this.nextAttackEffects.Add(nae);
					
					int offset = 4;
					
					Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
					Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
					Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
					Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
					Converter.ToBytes( (uint)cast.castingtime, tempBuff, ref offset );
					Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );				
					Converter.ToBytes( (ulong)target.Guid, tempBuff, ref offset );
					
					ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	
				}
				else
					this.SpellFaillure(SpellFailedReason.InvalidTarget);
			}
			else
			{
				if (this.combatTimer != null) this.combatTimer.Stop();
				if ( HaveSpell( spell ) )
				{
					cast.type = type;
					targetedItem = null;				
					spellTarget = target;
					if ( cast.castingtime == 0 )
					{
					
						SpellStart();
					
					}
					else					
					{
					
				
						int offset = 4;
						// 00 26 31 01 
						//EA 01 00 00 00 00 00 00 
						//31 02 00 00 00 00 00 00 
						//85 00 00 00 
						//00 01 
						//DC 05 00 00 
						//02 00 
						//EA 01 00 00 00 00 00 00
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
						Converter.ToBytes( (ushort)0x100, tempBuff, ref offset );
						Converter.ToBytes( (uint)cast.castingtime, tempBuff, ref offset );
						Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );				
						Converter.ToBytes( (ulong)target.Guid, tempBuff, ref offset );

						ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	
					
						spellCastTimer = new SpellCastTimer( new SpellStartRun( this.SpellStart ), (int)cast.castingtime);
					
					}
				}
			}
		}
		
		public virtual void CastOnSelf(bool fromObject, int spell, ushort type )
		{
			if ( this is Character )
			{
				( this as Character ).StopAttacking();
			
				if(!fromObject) if(!cast.baseability.CheckSpell(this,this)) return;
			}
			if ( fromObject || HaveSpell( spell ) )
			{
				spellTarget = this;
				targetedItem = null;

				if ( cast.castingtime == 0 )
				{
					SpellStart();
				}
				else
				{
					//spellTarget = null;
					//01 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00  61 0A 00 00 00 01 B8 0B 00 00 00 00
					int offset = 4;
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( cast.id, tempBuff, ref offset );
					Converter.ToBytes( (ushort)0x100, tempBuff, ref offset );
					Converter.ToBytes( (ushort)cast.castingtime, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );	
						
					spellCastTimer = new SpellCastTimer( new SpellStartRun( this.SpellStart ), cast.castingtime );
				}		
			}
		}

		#endregion

		public virtual void SpellStart()
		{
			if ( cast.id == 0 )
			{
				if ( this is Character )
				{
					SpellFaillure( SpellFailedReason.Fizzled );
					return;
				}
			}
			OnSpellCasted(spellTarget );			
		}

		
		public virtual void OnSpellCasted( Object target )
		{
			
			if ( cast.baseability is CraftTemplate )
				( cast.baseability as CraftTemplate ).Create(cast, this );
			else
				if ( cast.baseability is SpellTemplate )
			{
				OnSpellTemplateResults( cast.baseability, target );
			}
			else Console.WriteLine("Strange spell casted id: " + cast.id);
			
			SpellSuccess();
		}

		

		public void OnSpellTemplateResults( BaseAbility ba, Object target )
		{
			SpellTemplate st = (SpellTemplate)ba;
			if( ( cast.type & 0x2 ) != 0 || ( cast.type & 0x800 ) != 0 || ( cast.type & 0x8000 ) != 0 ) //	single target
				st.SpellResult(cast.manacost,cast.id, this, target as Mobile );
			else
				if( ( cast.type & 0x10 ) != 0 || (cast.type & 0x1000 ) != 0 ) //	Item target
				st.SpellResult(cast.manacost,cast.id, this, target as Item );
			else
			{
				st.SpellResult(cast.manacost,cast.id, this );
			}
			SendSmallUpdateToPlayerNearMe( new int[]{ (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType }, new object[] { Mana } );
		}


		public virtual void SpellSuccess()
		{
			if ( spellTarget is BaseSpawner )
				return;
		
			bool miss = false;
			ArrayList hittedSecTargs = new ArrayList();
			ArrayList exeSecTargs = new ArrayList();
			ArrayList secondarySpellTargets = new ArrayList();
			int offset = 4;
			
			#region Cast Result send
			if ( this is Character )
			{
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				(this as Character).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
			}
			#endregion
			
			offset = 4;

			if ( SpellTemplate.SpellEffects[ cast.id ] != null )
			{
				#region OnSelfSpell
				if ( cast.type == 0 )
				{
					if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect)
					{
						#region OnSelfSpellEffect
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
						Converter.ToBytes( (short)0, tempBuff, ref offset );
						Converter.ToBytes( (byte)1, tempBuff, ref offset );
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
						Converter.ToBytes( (ushort)0, tempBuff, ref offset );
						Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
						ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
						if ( SpellTemplate.SpellEffects[ cast.id ] != null )
						{
							OnSelfSpellEffect ose = (OnSelfSpellEffect)SpellTemplate.SpellEffects[ cast.id ];
							ose( cast.baseability, this );
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffectMultipleParty)
					{	
						#region OnSelfSpellEffectMultipleParty



						secondarySpellTargets = SpellTargets.targetsAround(this,10f,TargetType.Party);
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							if(check ) {hittedSecTargs.Add(mob); }
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							OnSelfSpellEffectMultipleParty osem = (OnSelfSpellEffectMultipleParty)SpellTemplate.SpellEffects[ cast.id ];
							osem(cast.baseability,this,hittedSecTargs);
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffectConeEnemy)
					{
						#region OnSelfSpellEffectConeEnemy
						secondarySpellTargets = SpellTargets.targetsInConeFront(this,cast.radius,TargetType.Enemy,3);
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							OnSelfSpellEffectConeEnemy osem = (OnSelfSpellEffectConeEnemy)SpellTemplate.SpellEffects[ cast.id ];
							osem(cast.baseability,this,hittedSecTargs);
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffectMultipleEnemy)
					{
						#region OnSelfSpellEffectMultipleEnemy
						secondarySpellTargets = SpellTargets.targetsAround(this,cast.radius,TargetType.Enemy);
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							OnSelfSpellEffectMultipleEnemy osem = (OnSelfSpellEffectMultipleEnemy)SpellTemplate.SpellEffects[ cast.id ];
							osem(cast.baseability,this,hittedSecTargs);
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffectMultipleFriend)
					{
						#region OnSelfSpellEffectMultipleFriend
						secondarySpellTargets = SpellTargets.targetsAround(this,10f,TargetType.Friend);
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							if(check ) {hittedSecTargs.Add(mob); }
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							OnSelfSpellEffectMultipleFriend osem = (OnSelfSpellEffectMultipleFriend)SpellTemplate.SpellEffects[ cast.id ];
							osem(cast.baseability,this,hittedSecTargs);
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffectMultiple)
					{
						#region OnSelfSpellEffectMultiple
						secondarySpellTargets = SpellTargets.targetsAround(this,cast.radius,TargetType.Enemy);
						ArrayList friends = SpellTargets.targetsAround(this,cast.radius,TargetType.Friend);
						foreach(Mobile mob in secondarySpellTargets)
						{

							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						foreach(Mobile mob in friends)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							if(check ) {hittedSecTargs.Add(mob); }
							if(check) exeSecTargs.Add(mob);
						}
						foreach(Object obj in friends)
						{
							secondarySpellTargets.Add(obj);
						}















						if(!miss)
						{
							OnSelfSpellEffectMultiple osem = (OnSelfSpellEffectMultiple)SpellTemplate.SpellEffects[ cast.id ];
							osem(cast.baseability,this,hittedSecTargs);
						}
						#endregion	
					}		
								
					Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
					Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
					Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
					Converter.ToBytes( (short)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)exeSecTargs.Count, tempBuff, ref offset );
					foreach(Mobile mob in exeSecTargs)
					{
						Converter.ToBytes( mob.Guid, tempBuff, ref offset );
					}
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (ushort)0, tempBuff, ref offset );
					Converter.ToBytes( (ulong)Guid, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
				}
					#endregion
				else
					#region GameObject target spell
					if ( ( cast.type & 0x800 ) != 0 )
				{
					Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( cast.id, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (short)0x0101, tempBuff, ref offset );
					Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( cast.type, tempBuff, ref offset );
					Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
					if ( SpellTemplate.SpellEffects[ cast.id ] != null )
					{
						if (SpellTemplate.SpellEffects[ cast.id ] is GameObjectTargetSpellEffect)
						{
							GameObjectTargetSpellEffect stse = (GameObjectTargetSpellEffect)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, spellTarget as GameObject );
						}
					}
				}
					#endregion
				else
					#region Single target Spell Effects spells
					if( ( cast.type & 0x2 ) != 0 || ( cast.type & 0x8000 ) != 0 ) 
				{				
					if(SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectAttackSpeedRanged)
					{
						#region attack speed spells with projectile
						if(!(cast.id == 7919 ||cast.id == 7918 ||cast.id == 0x9B0 || cast.id == 0xACC))


							miss = (cast.baseability as SpellTemplate).MissAndRessistTest(spellTarget,this);							

						
						(spellTarget as Mobile ).LastOffender = this;
						
						Item weapon = this.RangedWeapon;
						Item ammo = this.RangedAmmo;
							
						if (weapon == null)
						{
							this.SpellFaillure(SpellFailedReason.YourWeaponHandIsEmpty);
							return ;
						}
						if(cast.id == 0xACC)
							ammo = weapon;
												
						Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
						Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
						Converter.ToBytes( cast.id, this.tempBuff, ref offset );
						Converter.ToBytes( (short)0x0120, this.tempBuff, ref offset );
						Converter.ToBytes( (byte)1, this.tempBuff, ref offset );
						Converter.ToBytes( spellTarget.Guid, this.tempBuff, ref offset );
						Converter.ToBytes( (byte)0, this.tempBuff, ref offset );
						Converter.ToBytes( (ushort)2, this.tempBuff, ref offset );
						Converter.ToBytes( spellTarget.Guid, this.tempBuff, ref offset );
						if(ammo != null)
						{
							Converter.ToBytes( (uint)ammo.Model, this.tempBuff, ref offset );
							Converter.ToBytes( (uint)ammo.InventoryType, this.tempBuff, ref offset );
						}
						this.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, this.tempBuff, offset );
						
						if(!miss)
						{
							SingleTargetSpellEffectAttackSpeedRanged stse = (SingleTargetSpellEffectAttackSpeedRanged)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, spellTarget as Mobile );
						}
						#endregion
					}
					else if( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectAttackSpeedRangedMultiple)
					{
						#region attack speed spells with projectile Multiple
						(primarySpellTarget as Mobile).LastOffender = this;
						miss = (cast.baseability as SpellTemplate).MissAndRessistTest(primarySpellTarget as Object,this);	
						if (MultipleTargets.multipleTargets[cast.id] != null)
						{
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id],TargetType.Enemy);	
						}
						else
						{
							secondarySpellTargets = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Enemy);	
						}
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						Item weapon = this.RangedWeapon;
						Item ammo = this.RangedAmmo;
						
						if (weapon == null)
						{
							this.SpellFaillure(SpellFailedReason.YourWeaponHandIsEmpty);
							return ;
						}
						if(cast.id == 0xACC)
							ammo = weapon;
						Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
						Converter.ToBytes( this.Guid, this.tempBuff, ref offset );
						Converter.ToBytes( cast.id, this.tempBuff, ref offset );
						Converter.ToBytes( (short)0x0120, this.tempBuff, ref offset );
						Converter.ToBytes( (byte)exeSecTargs.Count, tempBuff, ref offset );
						foreach(Mobile mob in exeSecTargs)
						{
							Converter.ToBytes( mob.Guid, tempBuff, ref offset );
						}
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
						Converter.ToBytes( (ushort)2, this.tempBuff, ref offset );
						Converter.ToBytes( spellTarget.Guid, this.tempBuff, ref offset );
						if(ammo != null)
						{
							Converter.ToBytes( (uint)ammo.Model, this.tempBuff, ref offset );
							Converter.ToBytes( (uint)ammo.InventoryType, this.tempBuff, ref offset );
						}
						this.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, this.tempBuff, offset );
						SingleTargetSpellEffectAttackSpeedRangedMultiple stse = (SingleTargetSpellEffectAttackSpeedRangedMultiple)SpellTemplate.SpellEffects[ cast.id ];
						stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs );
						#endregion
					}				
					else  if( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect)
					{					
						#region SingleTargetSpellEffect
						miss = (cast.baseability as SpellTemplate).MissAndRessistTest(spellTarget,this);							
											
						(spellTarget as Mobile ).LastOffender = this;
						
						Converter.ToBytes( Guid, tempBuff, ref offset );
						Converter.ToBytes( Guid, tempBuff, ref offset );
						Converter.ToBytes( cast.id, tempBuff, ref offset );
						Converter.ToBytes( (short)0, tempBuff, ref offset );
						Converter.ToBytes( (byte)1, tempBuff, ref offset );
						Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
						Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
						Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
						ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
						if(!miss)
						{
							SingleTargetSpellEffect stse = (SingleTargetSpellEffect)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, spellTarget as Mobile );
						}
						#endregion
					}	
					else if( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectMultipleFriend)
					{
						#region SingleTargetSpellEffectMultipleFriend
						if(MultipleTargets.multipleTargets[cast.id] != null)
						{
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id],TargetType.Friend);	
						}
						else
						{
							secondarySpellTargets = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Friend);	
						}
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							if(check ) {hittedSecTargs.Add(mob); }
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							SingleTargetSpellEffectMultipleFriend stse = (SingleTargetSpellEffectMultipleFriend)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs );
						}
						#endregion
					}
					else if (SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectMultipleParty)
					{
						#region SingleTargetSpellEffectMultipleParty
						if(MultipleTargets.multipleTargets[cast.id] != null)
						{
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id],TargetType.Party);	
						}
						else
						{
							secondarySpellTargets = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Party);	
						}
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							if(check ) {hittedSecTargs.Add(mob); }
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							SingleTargetSpellEffectMultipleParty stse = (SingleTargetSpellEffectMultipleParty)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs );
						}
						#endregion
					}
					else if (SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectMultipleEnemy)
					{
						#region SingleTargetSpellEffectMultipleEnemy
						(primarySpellTarget as Mobile).LastOffender = this;
						miss = (cast.baseability as SpellTemplate).MissAndRessistTest(primarySpellTarget as Object,this);	
						if(MultipleTargets.multipleTargets[cast.id] != null)
						{
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id],TargetType.Enemy);	
						}
						else
						{
							secondarySpellTargets = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Enemy);	
						}
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							SingleTargetSpellEffectMultipleEnemy stse = (SingleTargetSpellEffectMultipleEnemy)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs );
						}
						#endregion
					}
					else if (SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffectMultiple)
					{
						#region SingleTargetSpellEffectMultiple
						ArrayList friend = new ArrayList();
						(primarySpellTarget as Mobile).LastOffender = this;
						miss = (cast.baseability as SpellTemplate).MissAndRessistTest(primarySpellTarget as Object,this);	
						if(MultipleTargets.multipleTargets[cast.id] != null)
						{
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id]/2,TargetType.Enemy);	
							friend = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id]/2,TargetType.Friend);	
						}
						else
						{
							secondarySpellTargets = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Enemy);
							friend = SpellTargets.targetsAround(primarySpellTarget as Mobile,cast.radius,TargetType.Friend);	
						}
						foreach(Mobile mob in friend)
						{
							secondarySpellTargets.Add(mob);
						}
						foreach(Mobile mob in secondarySpellTargets)
						{
							bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
							bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
							if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
							if(check) exeSecTargs.Add(mob);
						}
						if(!miss)
						{
							SingleTargetSpellEffectMultiple stse = (SingleTargetSpellEffectMultiple)SpellTemplate.SpellEffects[ cast.id ];
							stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs );
						}
						#endregion
					}

					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( cast.id, tempBuff, ref offset );
					Converter.ToBytes( (short)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)exeSecTargs.Count, tempBuff, ref offset );
					foreach(Mobile mob in exeSecTargs)
					{
						Converter.ToBytes( mob.Guid, tempBuff, ref offset );
					}
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
					Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
					
				}
					
			}		
				#endregion
			else
				#region item spell
				if( ( cast.type & 0x10 ) != 0 || ( cast.type & 0x1000 ) != 0 ) //	Item target
			{
				Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( (short)0x0101, tempBuff, ref offset );
				Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( cast.type, tempBuff, ref offset );
				Converter.ToBytes( spellTarget.Guid, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );

				//if ( SpellTemplate.SpellEffects[ casting ] != null )
				//	( SpellTemplate.SpellEffects[ casting ] as SingleTargetSpellEffect )( this, spellTarget );
			}
				#endregion
			else
				#region XYZ target spell
				if( ( cast.type & 0x20 ) != 0 || ( cast.type & 0x40 ) != 0 ) //	Item target
			{
				
				Converter.ToBytes( (UInt64)0, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( (short)0x0201, tempBuff, ref offset );
				Converter.ToBytes( (UInt64)0x32, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( (UInt64)1, tempBuff, ref offset );
				Converter.ToBytes( cast.type, tempBuff, ref offset );
				Converter.ToBytes( spellTargetX, tempBuff, ref offset );
				Converter.ToBytes( spellTargetY, tempBuff, ref offset );
				Converter.ToBytes( spellTargetZ, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
				if ( SpellTemplate.SpellEffects[ cast.id ] != null )
				{
					TargetXYZSpellEffect stse = (TargetXYZSpellEffect)SpellTemplate.SpellEffects[ cast.id];
					stse( cast.baseability, this, spellTargetX, spellTargetY, spellTargetZ );
				}
			}	
			#endregion


			if(this.combatTimer != null) this.combatTimer.Start();
			if(this.combatTimer != null) Console.WriteLine("start1");
			if(this is Character)
			{
				if((this as Character).SecondCombatTimer != null) (this as Character).SecondCombatTimer.Start();
				if((this as Character).SecondCombatTimer != null) Console.WriteLine("start1");
				if((this as Character).FirstCombatTimer != null) (this as Character).FirstCombatTimer.Start();
				if((this as Character).FirstCombatTimer != null) Console.WriteLine("start2");
			}
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.id = 0;
			cast.manacost = 0;
			cast.type = 0;
			cast.duration =0;
			cast.radius = 0;
		}
	
		#region Help functions
		public void SendSpellLogExecute(BaseAbility ba)
		{
			int offset = 4;
			Converter.ToBytes( (ulong)this.Guid, tempBuff, ref offset );
			Converter.ToBytes( (ushort)ba.Id, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			Converter.ToBytes( (ushort)1, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			Converter.ToBytes( (ushort)30, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			Converter.ToBytes( (ushort)1, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			Converter.ToBytes( (ulong)this.Guid, tempBuff, ref offset );
			Converter.ToBytes( (ushort)90, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			Converter.ToBytes( (ushort)1, tempBuff, ref offset );
			Converter.ToBytes( (ushort)0, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELLLOGEXECUTE, tempBuff, offset );
		//	Console.WriteLine("SMSG_SPELLLOGEXECUTE");
		//	HexViewer.View( tempBuff, 0, offset );

		}
		public void SendCastResult(int Id, int type)
		{
			if(this is Character)
			{
				int offset = 4;
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)type, tempBuff, ref offset );
				( this as Character ).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
				//Console.WriteLine("SMSG_CAST_RESULT");
				//HexViewer.View( tempBuff, 0, offset );
			}
		}
		public void SendSMSGSpellGo(Casting cast, Mobile Caster,Object target,ArrayList all, ArrayList executed)
		{
			int offset = 4;
			uint flags = 0;
			
			if ( cast.type == 0 )
				flags = 0;
			else if ( ( cast.type & 0x800 ) != 0 )
				flags = 0x0101;
			else if( ( cast.type & 0x2 ) != 0 || ( cast.type & 0x8000 ) != 0 ) 
				flags = 0x100;
			else if( ( cast.type & 0x10 ) != 0 || ( cast.type & 0x1000 ) != 0 ) 
				flags = 0x1010;
			else if( ( cast.type & 0x20 ) != 0 || ( cast.type & 0x40 ) != 0 ) 
			{
				offset = 4;
				Converter.ToBytes( (UInt64)0, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( (short)0x0201, tempBuff, ref offset );
				Converter.ToBytes( (UInt64)0x32, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( (UInt64)1, tempBuff, ref offset );
				Converter.ToBytes( cast.type, tempBuff, ref offset );
				Converter.ToBytes(  ((SpellXYZtarget)primarySpellTarget).X, tempBuff, ref offset );
				Converter.ToBytes(  ((SpellXYZtarget)primarySpellTarget).Y, tempBuff, ref offset );
				Converter.ToBytes(  ((SpellXYZtarget)primarySpellTarget).Z, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
				return;
			}	
			
			
			Converter.ToBytes( (ulong)Caster.Guid, tempBuff, ref offset );
			Converter.ToBytes( (ulong)Caster.Guid, tempBuff, ref offset );
			Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
			Converter.ToBytes( (ushort)flags, tempBuff, ref offset );
			if(executed != null)
			{
				Converter.ToBytes( (byte)executed.Count, tempBuff, ref offset );
				foreach(Mobile mob in executed)
				{
					Converter.ToBytes( (ulong)mob.Guid, tempBuff, ref offset );
				}
			}
			else
			{
				Converter.ToBytes( (byte)1, tempBuff, ref offset );
				Converter.ToBytes( (ulong)target.Guid, tempBuff, ref offset );
			}
			if(all != null && executed !=null)
			{
				Converter.ToBytes( (byte)all.Count - executed.Count , tempBuff, ref offset );
				foreach(Mobile mob in all)
				{
					if(!executed.Contains(mob))
						Converter.ToBytes( (ulong)mob.Guid, tempBuff, ref offset );
				}
			}
			else
			{
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			}
			Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
			Converter.ToBytes( (ulong)target.Guid, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, tempBuff, offset );
			//Console.WriteLine("SMSG_SPELL_GO");
			//HexViewer.View( tempBuff, 0, offset );
		}

		public void SendSMSGSpellStart(Casting cast, Mobile Caster,object target)
		{
			int offset = 4;
							
			Converter.ToBytes( (ulong)Caster.Guid, tempBuff, ref offset );
			Converter.ToBytes( (ulong)Caster.Guid, tempBuff, ref offset );
			Converter.ToBytes( (uint)cast.id, tempBuff, ref offset );
			Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );
			Converter.ToBytes( (uint)cast.castingtime, tempBuff, ref offset );
			Converter.ToBytes( (ushort)cast.type, tempBuff, ref offset );	
			if( (cast.type & 0x8000) != 0 || (cast.type & 0x0800) != 0 || (cast.type & 0x0002) != 0 ) 
			{
				Converter.ToBytes( (ulong)(target as Object).Guid, tempBuff, ref offset );	
			}
			else if( (cast.type & 0x1000) != 0|| (cast.type & 0x0010) != 0 ) 
			{
				Converter.ToBytes( (ulong)(target as Item).Guid, tempBuff, ref offset );
			}
			else if( (cast.type & 0x0020) != 0 ) 
			{  
				Converter.ToBytes( (float)this.X, tempBuff, ref offset );
				Converter.ToBytes( (float)this.Y, tempBuff, ref offset );
				Converter.ToBytes( (float)this.Z, tempBuff, ref offset );
			}
			else if( (cast.type & 0x0040) != 0 ) 
			{  
				Converter.ToBytes( (float)((SpellXYZtarget)target).X, tempBuff, ref offset );
				Converter.ToBytes( (float)((SpellXYZtarget)target).Y, tempBuff, ref offset );
				Converter.ToBytes( (float)((SpellXYZtarget)target).Z, tempBuff, ref offset );
			}
			else if( (cast.type & 0x2000) != 0 ) 
			{
			}
			else if( (cast.type & 0x20) != 0  ) 
			{
				if (this is Character)
				{
					Item ammo = World.CreateItemInPoolById( (this as Character).AmmoType );
					if (ammo != null)
					{
						Converter.ToBytes( (uint)ammo.Model, tempBuff, ref offset );
						Converter.ToBytes( (uint)ammo.InventoryType, tempBuff, ref offset );
					}
				}
			}

			ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );
			//Console.WriteLine("SMSG_SPELL_START");
			//HexViewer.View( tempBuff, 0, offset );
		}
	
		public virtual void NextAttackSpellGo(NextAttackEffect nae)
		{
			if ( cast.id == 0 )
			{
				SpellFaillure( SpellFailedReason.Fizzled );
				return;
			}

			if ( primarySpellTarget is BaseSpawner )
				return;
			
			bool miss = false;
			ArrayList hittedSecTargs = new ArrayList();
			ArrayList exeSecTargs = new ArrayList();
			ArrayList secondarySpellTargets = new ArrayList();
			if ( SpellTemplate.SpellEffects[ cast.id ] != null )
			{
				int off = 4;
				Converter.ToBytes( cast.id, tempBuff, ref off );
				Converter.ToBytes( (byte)0, tempBuff, ref off );
				if (this is Character)
				(this as Character ).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, off );


				bool cut = true;
				if(SpellTemplate.SpellEffects[ cast.id ] is NextAttackEffectDelegate)
				{
					if(SpellTargeting.spellTargets[cast.id] != null)
						if((SpellTargeting.spellTargets[cast.id] as String).Split('|')[0] == "6" && MultipleTargets.multipleTargets[cast.id] == null)
						{
							miss = (cast.baseability as SpellTemplate).MissAndRessistTest(primarySpellTarget as Object,this);							
						
							(primarySpellTarget as Mobile ).LastOffender = this;
							SendSMSGSpellGo(cast, this, primarySpellTarget as Mobile,null, null);
							NextAttackEffectDelegate stse = (NextAttackEffectDelegate)SpellTemplate.SpellEffects[ cast.id ];
							cut = stse( cast.baseability, this, primarySpellTarget as Mobile,nae.number );

						}
						
						else if ((SpellTargeting.spellTargets[cast.id] as String).Split('|')[0] == "6" && MultipleTargets.multipleTargets[cast.id] != null)
						{
							(primarySpellTarget as Mobile).LastOffender = this;
							miss = (cast.baseability as SpellTemplate).MissAndRessistTest(primarySpellTarget as Object,this);	
							secondarySpellTargets = SpellTargets.closeTargets(primarySpellTarget as Mobile,cast.radius,(int)MultipleTargets.multipleTargets[cast.id],TargetType.Enemy);	
							foreach(Mobile mob in secondarySpellTargets)
							{
								bool check = cast.baseability.CheckSpellTargetMultiple(this,mob);
								bool m = (cast.baseability as SpellTemplate).MissAndRessistTest(mob,this);	
								if(check && !m) {hittedSecTargs.Add(mob); miss = false;}
								if(check) exeSecTargs.Add(mob);
							}
						
							SendSMSGSpellGo(cast, this, primarySpellTarget as Mobile,secondarySpellTargets, exeSecTargs);
						
							NextAttackEffectDelegateMultiple stse = (NextAttackEffectDelegateMultiple)SpellTemplate.SpellEffects[ cast.id ];
							cut = stse( cast.baseability, this, primarySpellTarget as Mobile,hittedSecTargs,nae.number );
						}
				}
					
	
				if(cut) 
				{
					this.NextAttackEffects.Remove(nae);
					
				}	
				else nae.number++;

							
				this.primarySpellTarget = null;
				cast.baseability = null;
				cast.castingtime = 0;
				cast.cool = 0;
				cast.id = 0;
				cast.manacost = 0;
				cast.type = 0;
				cast.duration = 0;
				cast.radius = 0;
			}
		}

		public void AttackeStateMSG(int degats,Mobile src, Mobile target,int amountBlocked)
		{
			int offset = 4;
			if ( degats <= 0 )
				Converter.ToBytes( 0x22, tempBuff, ref offset );
			else
				Converter.ToBytes( 0x22, tempBuff, ref offset );
	
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( target.Guid, tempBuff, ref offset );
			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			Converter.ToBytes( (byte)1, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			if ( degats > 0 )
				Converter.ToBytes( (float)degats/*DamageType*/, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );

			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
			Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
			#region Degats types
			if ( degats >= 0 )
				Converter.ToBytes( 1, tempBuff, ref offset );
			else
				if ( degats == -1 )
				Converter.ToBytes( 2, tempBuff, ref offset );// dodge
			else
				if ( degats == - 2 )
				Converter.ToBytes( 9, tempBuff, ref offset );// parry
			else
				if ( degats == - 3 )
				Converter.ToBytes( 4, tempBuff, ref offset );// interrupted
			else
				if ( degats == - 4 || amountBlocked > 0 )
				Converter.ToBytes( 5, tempBuff, ref offset );// block
			else
				if ( degats == - 5 )
				Converter.ToBytes( 6, tempBuff, ref offset );// evade
			else
				if ( degats == - 6 )
				Converter.ToBytes( 7, tempBuff, ref offset );// immune
			else
				if ( degats == - 7 )
				Converter.ToBytes( 8, tempBuff, ref offset );// deflect

			#endregion
		
			if ( degats == 0 )
				Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			//HexViewer.View( tempBuff, 0, offset );
			ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					

		}
		public void SpellStateMSG(int degats, int SpellId, Mobile src, Mobile target,int type)
		{
			int offset = 4;
			Converter.ToBytes( target.Guid, target.tempBuff, ref offset );
			Converter.ToBytes( src.Guid, target.tempBuff, ref offset );
			Converter.ToBytes( (int)SpellId, target.tempBuff, ref offset );
			Converter.ToBytes( degats, target.tempBuff, ref offset );
			Converter.ToBytes( type, target.tempBuff, ref offset );
			Converter.ToBytes( (ushort)0x0100, target.tempBuff, ref offset );
			Converter.ToBytes( target.Guid, target.tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELLNONMELEEDAMAGELOG, target.tempBuff, offset );
		}
		
		#endregion
		
		public virtual bool HaveSkill( int id )
		{
			return true;
		}
	
		public bool CanCast()
		{
			int st = (int)standState;
			st = st & 0xffff;
			StandStates s = (StandStates)st;
			if ( s != StandStates.Standing )
			{
				this.SpellFaillure(SpellFailedReason.YouHaveToStandingToDoThat);
				return false;
			}
			return true;
		}
		public virtual void BeginCast( int spell, Object target )
		{
			if ( target is Mobile )
				if ( ( target as Mobile ).ForceSilence )
				{
					SpellFaillure( SpellFailedReason.CanDoWhileSilenced );
					return;
				}

			if ( this is Character && CanCast() )
			{
				SpellFaillure( SpellFailedReason.YouHaveToStandingToDoThat );
				return;
			}
			//	byte []buff = null;
			int offset = 4;
			if ( target is GameObject )
			{
				//buff = new byte[] { 0,0, 0,0, 0xB2, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xEE, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4E, 0x19, 0x00, 0x00, 0x00, 0x01, 0x88, 0x13, 0x00, 0x00, 0x00, 0x08, 0xB2, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( target.Guid, tempBuff, ref offset );
				Converter.ToBytes( spell, tempBuff, ref offset );
				Converter.ToBytes( 0x13880100, tempBuff, ref offset );				
				Converter.ToBytes( 0x08000000, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );
			}
			else
			{
				//buff = new byte[] { 0,0, 0,0, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x03, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( target.Guid, tempBuff, ref offset );
				Converter.ToBytes( spell, tempBuff, ref offset );
				Converter.ToBytes( 0x100, tempBuff, ref offset );				
				Converter.ToBytes( 0, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_SPELL_START, tempBuff, offset );
			}

				
			//	Instant effet
			byte []effect = { 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x03, 0x00, 0x00, 0x00, 0x01, 0x01, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
			offset = 4;
			Converter.ToBytes( Guid, effect, ref offset );
			Converter.ToBytes( target.Guid, effect, ref offset );
			Converter.ToBytes( spell, effect, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, effect );
		}
		public bool IsCasting
		{
			get 
			{
				if ( cast.id != 0 )
					return true;
				return false;
			}
		}
		public virtual void MoveInterruptCast()
		{

			this.SpellFaillure(SpellFailedReason.CantDoWhileMoving );
			cast.id = 0;
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.manacost = 0;
			cast.type = 0;
			if ( spellCastTimer == null )
				return;
			spellCastTimer.Stop();
		}
		public virtual void CancelCast()
		{

			this.SpellFaillure(SpellFailedReason.Interrupted);
			cast.id = 0;
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.manacost = 0;
			cast.type = 0;
			if ( spellCastTimer == null )
				return;
			spellCastTimer.Stop();
		}

		
		public void SetTarget( ushort type, int spell, Item targ )
		{
			cast.type = type;
			cast.id = spell;
			targetedItem = targ;
		}

	
		#region SPELL FAILURE MSG
		protected virtual void SpellFaillure()
		{
			if ( this is Character )
			{
			/*	int offset = 4;
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)1, tempBuff, ref offset );
				( this as Character ).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
*/
				int offset = 4;
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)2, tempBuff, ref offset );
				Converter.ToBytes( (byte)26, tempBuff, ref offset );
				(this as Character).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
			}
			this.primarySpellTarget = null;
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.id = 0;
			cast.duration =0;
			cast.radius =0;
			cast.manacost = 0;
			cast.type = 0;
		}
		public virtual void SpellFaillure( SpellFailedReason b )
		{
			if ( cast.id == 0 || b == 0 )
				return;
			if ( this is Character )
			{
/*				foreach( Object o in this.KnownObjects )
					if ( o is Character )
						( o as Character ).SendMessage( "Spell faillure send from " + this.Name + " spell = " + cast.id.ToString() + " b = " + b.ToString() );*/
				int offset = 4;

				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)2, tempBuff, ref offset );
				Converter.ToBytes( (byte)b, tempBuff, ref offset );
				( this as Character ).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
				offset = 4;
			}

			this.primarySpellTarget = null;
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.id = 0;
			cast.duration = 0;
			cast.radius =0;
			cast.manacost = 0;
			cast.type = 0;
		}
		
		public virtual void SpellFaillure( SpellFailedReason b, string msg )
		{
			if ( cast.id == 0 || b == 0 )
				return;
			if ( this is Character )
			{
				int offset = 4;/*
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)1, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
				offset = 4;*/
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)2, tempBuff, ref offset );
				Converter.ToBytes( (byte)b, tempBuff, ref offset );
				Converter.ToBytes( msg, tempBuff, ref offset );
				( this as Character ).Send( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
			}
			this.primarySpellTarget = null;
			cast.baseability = null;
			cast.castingtime = 0;
			cast.cool = 0;
			cast.id = 0;
			cast.manacost = 0;
			cast.type = 0;
			cast.duration =0;
			cast.radius =0;
		}
		#endregion

		#region COOLDOWN
		public void MobileCoolDownEnded()
		{
			ChooseAttackMode();
		}
		public virtual void CoolDownEnded()
		{
			
		}

		#endregion

		#endregion

		#region AURA		
		public class AuraReleaseTimer : WowTimer
		{
			Mobile from;
			public Aura aura;
			public AuraEffect ae;
			public int num;

			public AuraReleaseTimer( Mobile st, Aura ar, AuraEffect a, int n, int duration ) : base( duration, "AuraReleaseTimer" )
			{
				aura = ar;
				num = n;
				from = st;
				ae = a;
				Start();
			}
			public override void OnTick()
			{
				from.ReleaseAura( this );
				base.OnTick();
			}
		}

		public void ReleaseAllItemAura()
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura is ItemAura )
				{
				}
				else
				{
					al.Add( art );
				}
			}
			aura = al;
		}

		public void ReleaseAllAura()
		{
			foreach( AuraReleaseTimer art in aura )
			{
				art.Stop();								
				art.aura.Release( this );
				SendSmallUpdateToPlayerNearMe( 
					new int[] { 
					 (int)UpdateFields.UNIT_FIELD_AURA + art.num, 
								  (int)UpdateFields.UNIT_FIELD_AURAFLAGS + ( art.num >> 3 ), 
					 (int)UpdateFields.UNIT_FIELD_AURALEVELS + ( art.num >> 2 ), 
					 (int)UpdateFields.UNIT_FIELD_AURAAPPLICATIONS + ( art.num >> 2 ), 					 
					 (int)UpdateFields.UNIT_FIELD_AURASTATE }, 
					new object[] { 0, 0xdddddddd, 0x01010101, 0,  0x2 } );
			}
			if ( this is Character )
				( this as Character ).AdjustBonii();

			aura.Clear();
		}

		public bool AlreadyHaveAura( AuraEffect ae )
		{
			foreach( AuraReleaseTimer art in aura )
				if ( art.ae == ae )
					return true;
			return false;
		}

		public Aura AddAura( Mobile from, AuraEffect ae, Aura a )
		{
			if ( this != from )
				this.OnGetHit( from, false, 1 );
			return AddAura( ae, a, false );
			
		}
		public Aura AddAura( Mobile from, AuraEffect ae, Aura a, bool offensive )
		{
			return AddAura( ae, a, offensive );
		}
		public Aura AddAura( AuraEffect ae, Aura a )
		{
			
			
			return AddAura( ae, a, false );
		}
		
		public Aura AddAura( AuraEffect ae, Aura a, bool offensive )
		{
			if ( Dead )
				return null;	
	
			if ( offensive )
				this.OnGetHit( this, false, 1 );

			if ( aura.Count < 50 )
			{	
				int num = -1;
				int n = 0;
				ArrayList free = new ArrayList();
				if ( offensive || a is DotAura )
					free.AddRange( new int[] { 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45
												 , 46, 47, 48, 49 } );
				else
					free.AddRange( new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
												 , 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 } );

				foreach( AuraReleaseTimer arts in aura )
				{
					if ( arts.ae == ae )
					{
						num = n;
						break;
					}
					else
					{
						free.Remove( arts.num );
						n++;
					}
				}
				if ( free.Count == 0 )
					return null;//	Too much aura !!!!!
				if ( num == -1 )
					num = (int)free[ 0 ];
				else
				{//	l'aura a deja ete lanc?, remise a zero de son compteur
					int ne = num;
					num = ( aura[ ne ] as AuraReleaseTimer ).num;
					ReleaseAura( ( aura[ ne ] as AuraReleaseTimer ) );
				}
					
				if (ae != null)
				{
					AuraReleaseTimer art = null;
					if ( ae.Duration( this ) == 0x100 )
						art = new AuraReleaseTimer( this, a, ae, num, 0xfffffff );
					else
						art = new AuraReleaseTimer( this, a, ae, num, ae.Duration( this ) );
					aura.Add( art );
					SendSmallUpdateToPlayerNearMe( 
						new int[] { 
						(int)UpdateFields.UNIT_FIELD_AURA + num, 
						(int)UpdateFields.UNIT_FIELD_AURAFLAGS + ( num >> 3 ), 
						(int)UpdateFields.UNIT_FIELD_AURALEVELS + ( num >> 2 ),
						(int)UpdateFields.UNIT_FIELD_AURAAPPLICATIONS + ( num >> 2 ), 
						
						(int)UpdateFields.UNIT_FIELD_AURASTATE }, 
					new object[] { (int)ae.Id, 0xdddddddd, 0x01010101, 0, 0x2 } );

					int offset = 4;
					Converter.ToBytes( (byte)num, tempBuff, ref offset );
					if ( ae.Duration( this ) == 0x100 )
						Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
					else
						Converter.ToBytes( ae.Duration( this ), tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_UPDATE_AURA_DURATION, tempBuff, 9 );
					if ( this is Character )
						( this as Character ).AdjustBonii();
				}
				return a;
			}
			return null;
		}
		public void ReleaseAura( AuraReleaseTimer art )
		{
			art.Stop();
			aura.Remove( art );
			if ( this is Character )
				( this as Character ).AdjustBonii();
			art.aura.Release( this );
			SendSmallUpdateToPlayerNearMe( 
		new int[] { (int)UpdateFields.UNIT_FIELD_AURA + art.num, 
					  (int)UpdateFields.UNIT_FIELD_AURALEVELS + ( art.num >> 2 ), 
					  (int)UpdateFields.UNIT_FIELD_AURAAPPLICATIONS + ( art.num >> 2 ), 
					  (int)UpdateFields.UNIT_FIELD_AURAFLAGS + ( art.num >> 3 ), 
					  (int)UpdateFields.UNIT_FIELD_AURASTATE }, 
				new object[] { 0, 0xdddddddd, 0x01010101, 0, 0x2 } );
		}
		public void ReleaseAura( AuraEffect ae )
		{
			AuraReleaseTimer toRemove = null;
			foreach( AuraReleaseTimer art in aura )
				if ( art.ae == ae )
				{
					toRemove = art;
					break;
				}
			if ( toRemove != null )
				ReleaseAura( toRemove );

		}
		#endregion

		#region PERMANENT AURA
		public virtual PermanentAura AddPermanentAura( AuraEffect ae, Aura a )
		{
			PermanentAura paura = new PermanentAura(a,ae.Id);
			permanentAura.Add(paura);
			if (this is Character) (this as Character).AdjustBonii();
			return paura;
		}
		public void RemovePermanentAura(AuraEffect ae)
		{
			PermanentAura paura1 = null;
			foreach(PermanentAura paura in permanentAura)
			{
				if(paura.Id == ae.Id) 
				{
					paura1 = paura;
					break;
				}

			}
			if (paura1 != null)
				permanentAura.Remove(paura1);
		}
		#endregion

		#region ABSORBS
		public int DiminishAbsorbAllDamage( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.AllDamageAbsorb > 0 )
				{
					if ( art.aura.AllDamageAbsorb > amount )
					{
						art.aura.AllDamageAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.AllDamageAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishAbsordbAll( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.AbsorbAllMagic > 0 )
				{
					if ( art.aura.AbsorbAllMagic > amount )
					{
						art.aura.AbsorbAllMagic -= amount;
						return 0;
					}
					amount -= art.aura.AbsorbAllMagic;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishFireAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.FireAbsorb > 0 )
				{
					if ( art.aura.FireAbsorb > amount )
					{
						art.aura.FireAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.FireAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishFrostAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.FrostAbsorb > 0 )
				{
					if ( art.aura.FrostAbsorb > amount )
					{
						art.aura.FrostAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.FrostAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishArcaneAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.ArcaneAbsorb > 0 )
				{
					if ( art.aura.ArcaneAbsorb > amount )
					{
						art.aura.ArcaneAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.ArcaneAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishNatureAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.NatureAbsorb > 0 )
				{
					if ( art.aura.NatureAbsorb > amount )
					{
						art.aura.NatureAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.NatureAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishShadowAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.ShadowAbsorb > 0 )
				{
					if ( art.aura.ShadowAbsorb > amount )
					{
						art.aura.ShadowAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.ShadowAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishHolyAbsordb( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.HolyAbsorb > 0 )
				{
					if ( art.aura.HolyAbsorb > amount )
					{
						art.aura.HolyAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.HolyAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		public int DiminishAbsorbPhysical( int amount )
		{
			ArrayList al = new ArrayList();
			foreach( AuraReleaseTimer art in aura )
			{
				if ( art.aura.PhysicalAbsorb > 0 )
				{
					if ( art.aura.PhysicalAbsorb > amount )
					{
						art.aura.PhysicalAbsorb -= amount;
						return 0;
					}
					amount -= art.aura.PhysicalAbsorb;
					al.Add( art );
				}
			}
			foreach( AuraReleaseTimer art in al )
				this.ReleaseAura( art );
			return amount;
		}
		#endregion

		#region POLYMORPH
		
		public void Polymorph( int modelId )
		{
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_DISPLAYID }, new object[]{ modelId } );
		}
		public void CancelPolymorph()
		{
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_DISPLAYID }, new object[]{ this.model } );
		}
		#endregion
		#endregion

		#region PACKET MANAGER
		public virtual void SendSmallUpdateToPlayer( Character ch, int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x21 )
				max = 0x21;
			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, Object.Blank.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );	
					
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			
			ch.Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public virtual void SendSmallUpdate( int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x21 )
				max = 0x21;
			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, Object.Blank.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );	
					
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			
			ToAllPlayerNear( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public virtual void SendSmallUpdateToPlayerNearMe( int []pos, object []val )
		{
			SendSmallUpdateToPlayerNearMe( Guid, pos, val );
		}
		public virtual void SendSmallUpdateToPlayerNearMe( UInt64 guid, int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( guid, tempBuff, ref offset );
			int max = 2 + ( pos[ pos.Length - 1 ] / 32 );
			if ( max > 0x21 )
				max = 0x21;
			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, max * 4 );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			ToAllPlayerNear( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public virtual void ToAllPlayerNear( OpCodes code, byte []data )
		{

			if ( lastSeen != null && lastSeen.Player != null )
				//	if ( lastSeen.Player.KnownObjects.Contains( this ) )
			{
				//		foreach( Object o in lastSeen.Player.KnownObjects )
				//			Console.WriteLine("Know {0}", o.Guid.ToString( "X16" ) );
				lastSeen.Player.ToAllPlayerNear( this, code, data, data.Length );
			}
		}
		public virtual void ToAllPlayerNear( OpCodes code, byte []data, int len )
		{
			if ( this.SummonedBy != null && ( SummonedBy is Character ) )
			{
				if ( ( SummonedBy as Character ).Player != null )
					( SummonedBy as Character ).Player.ToAllPlayerNear( this, code, data, len );
			}
			if ( lastSeen != null && lastSeen.Player != null )
				//	if ( lastSeen.Player.KnownObjects.Contains( this ) )
			{
				//		foreach( Object o in lastSeen.Player.KnownObjects )
				//			Console.WriteLine("Know {0}", o.Guid.ToString( "X16" ) );
				lastSeen.Player.ToAllPlayerNear( this, code, data, len );
			}
		}
		public virtual void ToAllPlayerNear( OpCodes code, byte []data, int after, int len )
		{
			byte []ret = new byte[ len ];
			Buffer.BlockCopy( data, after, ret, 0, len );
			if ( lastSeen != null && lastSeen.Player != null )
				//	if ( lastSeen.Player.KnownObjects.Contains( this ) )
			{
				//		foreach( Object o in lastSeen.Player.KnownObjects )
				//			Console.WriteLine("Know {0}", o.Guid.ToString( "X16" ) );
				lastSeen.Player.ToAllPlayerNear( this, code, ret, len );
			}
		}
		public virtual void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int after, int len )
		{
			byte []ret = new byte[ len ];
			Buffer.BlockCopy( data, after, ret, 0, len );
			if ( lastSeen != null && lastSeen.Player != null )
				//	if ( lastSeen.Player.KnownObjects.Contains( this ) )
			{
				//		foreach( Object o in lastSeen.Player.KnownObjects )
				//			Console.WriteLine("Know {0}", o.Guid.ToString( "X16" ) );
				lastSeen.Player.ToAllPlayerNear( this, code, ret, len );
			}
		}
		public virtual void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int len )
		{
			if ( lastSeen != null && lastSeen.Player != null )
				//	if ( lastSeen.Player.KnownObjects.Contains( this ) )
			{
				//	foreach( Object o in lastSeen.Player.KnownObjects )
				//		Console.WriteLine("Know {0}", o.Guid.ToString( "X16" ) );
				lastSeen.Player.ToAllPlayerNear( this, code, data, len );
			}
		}
		#endregion

		#region COMBAT

		public void ResetCombo( Mobile target )
		{
			comboPoints = 0;
			uint lowGuid = (uint)( target.Guid & 0xffffffff );
			uint highGuid = (uint)( ( target.Guid >> 32 ) & 0xffffffff );
			this.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER__FIELD_COMBO_TARGET, (int)UpdateFields.PLAYER__FIELD_COMBO_TARGET + 1, (int)UpdateFields.PLAYER_FIELD_BYTES }, new object[]{ lowGuid , highGuid, 0 } );			
		}

		public void AddComboPoint( Mobile target )
		{
			comboPoints++;
			uint lowGuid = (uint)( target.Guid & 0xffffffff );
			uint highGuid = (uint)( ( target.Guid >> 32 ) & 0xffffffff );
			this.SendSmallUpdate( new int[] { 618, 619, (int)UpdateFields.PLAYER_FIELD_BYTES }, new object[]{ lowGuid , highGuid, comboPoints << 8 } );
		}
		Mobile lastOffender = null;
		public Mobile LastOffender
		{
			get { return lastOffender; }
			set { lastOffender = value; }
		}

		public void OnGetHit( Mobile by )
		{
			if ( by != this )
				lastOffender = by;
			OnGetHit( by, true, 1 );
		}
		public delegate void OnSpellHitTrigger( Mobile from, Mobile target, AuraEffect ae );
		public delegate void OnMeleeHitTrigger( Mobile from, Mobile target, AuraEffect ae );
		public delegate void OnCriticalHitTrigger( Mobile from, Mobile target, BaseAbility ae);
		public delegate void OnSpellHitDoneTrigger( Mobile who, Mobile target, AuraEffect ae );
		public delegate void OnMeleeHitDoneTrigger( Mobile who, Mobile target, AuraEffect ae );
		public delegate void OnCriticalHitDoneTrigger( Mobile who, Mobile target, BaseAbility ae);
		public virtual void OnGetHit( Mobile by, bool f, int damageAmount )
		{
			try
			{
				if ( by != this )
					lastOffender = by;
				if ( this.summon != null && ( summon.AIState == AIStates.Follow ) )
				{
					if ( by != this )
						summon.OnGetHit( by );
					else
						summon.OnGetHit( lastOffender );
				}
			}
			catch( Exception )
			{
				Console.WriteLine( "Crash OnGetHit 1" );
			}
			lastHit = DateTime.Now;
			if ( f )
			{
				try
				{

					#region Melee trigger taken
					ArrayList al = new ArrayList();
					foreach( AuraReleaseTimer art in aura )
					{
						int a = art.aura.OnMeleeHit;
						if ( a != -1 )
							al.Add( art );
					}
					foreach( AuraReleaseTimer art in al )
					{
						int a = art.aura.OnMeleeHit;
						if ( a != -1 && Triggers[ a ] != null )
							( Triggers[ a ] as OnMeleeHitTrigger )( this, by, art.ae );
					}
					#endregion
				}
				catch( Exception )
				{
					Console.WriteLine( "Crash OnGetHit 2" );
				}
				try
				{
					#region Melee trigger done 
					ArrayList al2 = new ArrayList(); 
					foreach( AuraReleaseTimer art in by.Auras ) 
					{ 
						int a = art.aura.OnMeleeHitDone; 
						if ( a != -1 ) 
							al2.Add( art ); 
					} 
					foreach( AuraReleaseTimer art in al2 ) 
					{ 
						int a = art.aura.OnMeleeHitDone; 
						if ( a != -1 && by.Triggers[ a ] != null ) 
							( by.Triggers[ a ] as OnMeleeHitDoneTrigger )( by, this, art.ae ); 
					} 
					#endregion 
				}
				catch( Exception )
				{
					Console.WriteLine( "Crash OnGetHit 3" );
				}
			}
			else
			{
				try
				{
					#region Spell Triggers
					ArrayList al = new ArrayList();
					if ( aura != null )
					{
						foreach( AuraReleaseTimer art in aura )
						{
							if ( art.aura == null )
							{
								Console.WriteLine("Trigger error for Aura = null ask DrNexus" );
							}
							int a = art.aura.OnSpellHit;
							if ( a != -1 )
								al.Add( art );
						}
						foreach( AuraReleaseTimer art in al )
						{
							int a = art.aura.OnSpellHit;
							if ( a != -1 && Triggers[ a ] != null )
							{
								try
								{
									if ( !( Triggers[ a ] is OnSpellHitTrigger ) )
										Console.WriteLine("Trigger error for {0} ask DrNexus", Triggers[ a ].GetType().ToString() );
									if ( art == null )
										Console.WriteLine("Trigger error art = null ask DrNexus" );
									( Triggers[ a ] as OnSpellHitTrigger )( this, by, art.ae );
								}
								catch( Exception )
								{
Console.WriteLine("Crash OnGetHit 4 in {0}.{1}", ( Triggers[ a ] as OnSpellHitTrigger ).Target, ( Triggers[ a ] as OnSpellHitTrigger ).Method );
								}
							}
						}
					}
					#endregion
				}
				catch( Exception )
				{
					Console.WriteLine( "Crash OnGetHit 4" );
				}
				try
				{
					#region Spell Triggers
					ArrayList al2 = new ArrayList();
					foreach( AuraReleaseTimer art in aura )
					{
						int a = art.aura.OnSpellHitDone;
						if ( a != -1 )
							al2.Add( art );
					}
					foreach( AuraReleaseTimer art in al2 )
					{
						int a = art.aura.OnSpellHitDone;
						if ( a != -1 && Triggers[ a ] != null )
							( Triggers[ a ] as OnSpellHitDoneTrigger )( this, by, art.ae );
					}
					#endregion
				}
				catch( Exception )
				{
					Console.WriteLine( "Crash OnGetHit 5" );
				}
			}			
		}
		
		public void GenerateLoot()
		{
			if ( loots != null )
			{
				ArrayList tresor = new ArrayList();
				foreach( BaseTreasure l in loots )
				{
					if ( l.IsDrop() )
					{
						ArrayList ret = l.RandomDrop( ref lootMoney );
						if ( ret != null )
							tresor.AddRange( ret );
					}
				}
				Treasure = (Item[])tresor.ToArray( typeof( Item ) );
				//if ( Treasure.Count == 0 )
				//	tresure = null;
			}
			Console.WriteLine("");
			
		}


		public bool channelTarget;
		public static int fa = 1;
		public virtual void OnDeath( Mobile by )
		{
			this.NextAttackEffects.Clear();
			by.NextAttackEffects.Clear();
			if( this.channelTarget )
				by.ChannelEnd();
			this.ChannelEnd();
			if ( MountModel != 0 )
			{
				if ( Mounting == null )
					Console.WriteLine("Npc {0} have an incorrect 'Mounting' value", this.Name );
				else
					World.Add( (BaseCreature)Mounting, X, Y, Z, MapId );
			}
			ReleaseAllAura();
			UpdateXYZ();
			if ( Faction == Factions.Darnasus || Faction == Factions.DarkspearTrolls ||
				Faction == Factions.GnomereganExiles || Faction == Factions.IronForge ||
				Faction == Factions.Ogrimmar || Faction ==  Factions.Stormwind ||
				Faction == Factions.ThunderBluff || Faction == Factions.Undercity || 
				(int)Faction < 12 )
			{
				if ( by is Character && by.Faction != this.Faction )
				{
					if( this.Level > by.Level + 8 )	
					{
						(by as Character).Honor.DishonorableKillsToday += 1;
						(by as Character).Honor.HonorToday -= 1;//(ushort)((by.Level-this.Level)/5);
					}
					else 
					{
						(by as Character).Honor.HonorableKillsToday += 1;
						(by as Character).Honor.HonorToday += 1;//(ushort)((by.Level-this.Level)/5);
					}				
				}
			}
			if ( !moveVector.NearDestination() )
				this.MoveTo( X, Y, Z );
			this.ReleaseAllAura();
			if ( by is Character )
				( by as Character ).CheckKills( this );
			else
				if ( by.summonedBy != null )
				( by.summonedBy as Character ).CheckKills( this );


			by.XpEarn( this );
			if ( SummonedBy != null )
			{
				SummonedBy.Summon = null;
				decay = new DecayTimer( this, 1 );
			}
			else
			{
				GenerateLoot();
				if ( Treasure != null && Treasure.Length > 0 && KnownObjects != null )//&& by is Character )
				{
					foreach( Object obj in this.KnownObjects )
					{
						if ( obj is Character )
						{
							if ( ( obj as Character ).SeeAnyLoot( by, Treasure ) )
								SendSmallUpdateToPlayer( obj as Character, new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS, (int)UpdateFields.UNIT_DYNAMIC_FLAGS }, new object[] { (int)Flags, DynFlags( by ) + 1 } );
							else
								SendSmallUpdateToPlayer( obj as Character, new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS, (int)UpdateFields.UNIT_DYNAMIC_FLAGS }, new object[] { Flags, DynFlags( by ) } );

						}
					}
				}
				else
					SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS, (int)UpdateFields.UNIT_DYNAMIC_FLAGS }, new object[] { Flags, DynFlags( by ) } );
				decay = new DecayTimer( this, World.DecayTime );
			}
		}
		public virtual int Hit( Mobile m )
		{
			int block = 0, absorb = 0;
			return Hit( m, 0f,false, ref block, ref absorb );
		}
		public virtual int Hit( Mobile m,bool pass )
		{
			int block = 0, absorb = 0;
			return Hit( m, 0f,pass, ref block, ref absorb );
		}
		public virtual Item ChooseWeapon()
		{
			return Character.handToHand;
		}

		#region old hit
		/*
		public virtual int Hit( Mobile m, float dmgBonus )
		{
			int prob = Level * 5;
			Item weapon = activeWeapon;
			if ( weapon == null )
			{				
				weapon = activeWeapon = ChooseWeapon();
				if ( weapon == null )
				{
					Console.WriteLine("Warning null weapon detected on {0}", m.Name );
					return 0;
				}
			}
			if ( this is Character )
			{
				int skid = weapon.GetSkillId();
				if ( skid != 0 )
				{
					Skill sk = allSkills[ (ushort)skid ];
					if ( sk == null )
					{
						Console.WriteLine("Uknown skill id for weapon {0} = id = {1}. Please send that to DrNexus !!!!!!!!", weapon.Name, skid );
						return 0;
					}
					//	int dodge = 0;
					//	int parry = 0;
					prob = sk.Current;
					Console.WriteLine("Hit 7" );
					if ( SkillUp( sk.Current, prob, Character.onSkillProgressFactor( this, sk.Current, skid ) ) )
					{
						Console.WriteLine("Hit 8" );
						sk.Current++;
						if ( sk.Current > sk.Cap( this ) )
							sk.Current = sk.Cap( this );
						if ( this is Character )
							( this as Character ).SendSkillUpdate(); 
						Console.WriteLine("Hit 9" );
					}
				}
				Console.WriteLine("Hit 10" );
				if ( StatUp( str, prob, 1 ) )
					str++;
				Console.WriteLine("Hit 11" );
			}
			Console.WriteLine("Hit 12" );
			if ( m == null )
				Console.WriteLine("m=null !!! send a pm to drnexus" );
			if ( m.block > 0 )
			{
				if ( Utility.Random( 100 ) <= block )
				{				
					lastAttack = AttackStatus.Block;
					return 0;
				}
			}
			Console.WriteLine("Hit 13" );
			
			if ( m.HaveSkill( ) > 0 )
			{
				if ( Utility.Random( 100 ) <= block )
				{				
					lastAttack = AttackStatus.Block;
					return 0;
				}
			}		
			int roll = Utility.Random( 100 );
			bool critic = false;
			roll += (int)this.PhysicalCriticalBonus;
			lastAttack = AttackStatus.NormalHit;
			Console.WriteLine("Hit 14" );
			if ( roll > 95 )
			{
				critic = true;	
				lastAttack = AttackStatus.Critical;
			}
			Console.WriteLine("Hit 15" );
			float dam = 0;
				
			 
	Mob level|1		|2		|3		|4		|5		|6		|7		|8		|
	Character
	Level

	1		|90%	|75%	|50%	|10%	|5%		|0		|0		|0		|
	2		|95%	|90%	|75%	|50%	|10%	|5%		|0		|0		|
	3		|99%	|95%	|90%	|75%	|50%	|10%	|5%		|0		|
	4		|100%	|99%	|95%	|90%	|75%	|50%	|10%	|5%		|
	5		|100%	|100%	|99%	|95%	|90%	|75%	|50%	|10%	|
	6		|100%	|100%	|100%	|99%	|95%	|90%	|75%	|50%	|
	7		|100%	|100%	|100%	|100%	|99%	|95%	|90%	|75%	|
	8		|100%	|100%	|100%	|100%	|100%	|99%	|95%	|90%	|
	9		|100%	|100%	|100%	|100%	|100%	|100%	|99%	|95%	|
	10		|100%	|100%	|100%	|100%	|100%	|100%	|100%	|99%	|
	11		|100%	|100%	|100%	|100%	|100%	|100%	|100%	|100%	|

	
	
			if ( prob + roll > 50 )
				dam = 1f;
			
			if ( dam == 0 )
			{
				lastAttack = AttackStatus.Loose;
				return 0;
			}
			Console.WriteLine("Hit 16" );
		

			float deg = ( maxDamage - minDamage ) * (float)Utility.RandomDouble();
			dam += AttackPower / 20;
			//Console.WriteLine( "Dammage {0} {1} = {2}", minDamage, maxDamage, deg );
			deg *= dam;
			deg += (float)( (float)( Str * Str ) / 25f );
			deg += minDamage;

			deg += MeleeDamageBonus;
			deg -= MeleeDamageMalus;
			deg -= deg * MeleePercentDamageMalus;
			Console.WriteLine("Hit 17" );

			deg -= 10f;
			if ( SummonedBy != null )
			{
				if ( Id == 1863 || Id == 1860 || Id == 417 )
				{
					if ( SummonedBy.HaveTalent( Talents.UnholyPower ) )
					{
						AuraEffect ae = (AuraEffect)SummonedBy.GetTalentEffect( Talents.UnholyPower );
						float s1 = (float)ae.S1;
						deg += deg * s1 / 100f;
					}
				}
			}
			Console.WriteLine("Hit 18" );
			if ( critic )
				deg *= 2;	

			deg += dmgBonus;

			float ar = m.Armor / ( m.Armor + 400 + 85 * level );
			deg += deg * -ar;
			deg = (int)DiminishAbsorbPhysical( (int)deg );
			if ( deg < 0 )
			{
				lastAttack = AttackStatus.Absorb;
				return 0;	
			}
			else
				activeWeapon.TriggerOnHit( this, m );
			Console.WriteLine("Hit 19" );
			return (int)deg;
		}*/
		#endregion

		public void EndCombat(Mobile m)
		{
			this.NextAttackEffects.Clear();
			if ( this.AttackTarget != null )
				this.AttackTarget = null;
			if ( this.combatTimer != null )
			{
				this.combatTimer.Stop();
				this.combatTimer = null;}
			this.Running = false;
			if (!(this is Character)) this.AIState = AIStates.ReturnHome;
			if ( m.AttackTarget != null )
				m.AttackTarget = null;
			if ( m.combatTimer != null )
			{
				m.combatTimer.Stop();
				m.combatTimer = null;}
			m.Running = false;
			if (!(m is Character)) m.AIState = AIStates.ReturnHome;

		}

		#region new hit function construction
		/*
		public bool SkillUpShield()
		{
			int prob = Level * 5;
			if ( this is Character )
			{
				int skid = ShieldSkill.SkillId;
				Skill sk = allSkills[ (ushort)skid ];

				prob = sk.CurrentVal(this);
				if ( SkillUp( sk.Current, prob, Character.onSkillProgressFactor( this, sk.Current, skid ) ) )
				{
					sk.Current++;
					if ( sk.Current > sk.Cap( this ) )
						sk.Current = sk.Cap( this );
					if ( this is Character )
						( this as Character ).SendSkillUpdate(); 
				}				
			}
			return true;
		}*/
		public int Difficulty( int sk, int vs )
		{
			int d = vs - sk;
			if ( d > 15 )
				d = 15;
			if ( d < -35 )
				return -1;
			return 51 - ( 35 + d );
		}

		public bool SkillUpDefense()
		{
			int prob = Level * 5;
			if ( attackTarget == null )
				return false;
			if ( this is Character )
			{
				int skid = DefenseSkill.SkillId;
				Skill sk = allSkills[ (ushort)skid ];
				if ( sk.Current >= sk.Cap( this ) )
					return false;
				prob = sk.CurrentVal(this);
				int diff = Difficulty( prob, attackTarget.Level * 5 );
				if ( SkillUp( sk.Current, diff, 0.01 ) )
				{
					sk.Current++;
					if ( this is Character )
						( this as Character ).SendSkillUpdate(); 
				}				
			}
			return true;
		}
		public bool SkillUpWeapon(Item weapon)
		{
			if ( attackTarget == null )
				return false;
			int prob = Level * 5;
			if ( weapon == null )
			{				
				weapon = activeWeapon = ChooseWeapon();
			}
			if ( this is Character )
			{
				int skid = weapon.GetSkillId();
				if ( skid != 0 )
				{
					Skill sk = allSkills[ (ushort)skid ];
					if ( sk == null )
					{
						Console.WriteLine("Unknown skill id for weapon {0} = id = {1} class {2}. Please send that to DrNexus !!!!!!!!", weapon.Name, skid, this.Classe );
						return false;
					} 
					if ( sk.Current >= sk.Cap( this ) )
						return false;
					prob = sk.CurrentVal(this);
					int diff = Difficulty( prob, attackTarget.Level * 5 );
					if ( SkillUp( sk.Current, diff, 0.01 ) )
					{
						sk.Current++;
						if ( this is Character )
							( this as Character ).SendSkillUpdate(); 
					}
				}
				if ( StatUp( str, prob, 1 ) )
					str++;
			}
			return true;
		}

		public float SkillDifCalculation(Item weapon, Mobile m)
		{
			float dif = 0f; // i must find some formula for this
			if(this is Character)
			{
				int skid = weapon.GetSkillId();
				if ( skid != 0 )
				{
					Skill sk3 = this.AllSkills[(ushort)skid];
					if (sk3 != null)
					{
						if (m is Character)
						{	/* not sure by this formula*/
							Skill sk4 = m.AllSkills[(ushort)DefenseSkill.SkillId];	
							dif = (float)(sk3.CurrentVal(this) - sk4.CurrentVal(m))/5;
						}
						else
							dif = (float)(sk3.CurrentVal(this) - m.Level*5)/5;				
					}
				}
			}
			else 
			{

				if (m is Character)
				{	/* not sure by this formula*/
					Skill sk5 = m.AllSkills[(ushort)DefenseSkill.SkillId];
					dif = (float)(5*this.Level - sk5.CurrentVal(m))/5;
				}
				else
					dif = (float)(5*this.Level - m.Level*5)/5;
			}
			return dif;
		}
		public float CriticalChanceCalculation(Item weapon,Mobile m)
		{
			float critChance = 5f; // for creatures base is 5%
			if(this is Character)
			{
				int skid = weapon.GetSkillId();
				critChance = (this as Character).BaseCritChance;
				if ( skid != 0 )
				{
					Skill sk2 = this.AllSkills[(ushort)skid];
					if (sk2 != null)
					{
						if (m is Character)
						{	/* not sure by this formula*/	
							Skill sk1 = m.AllSkills[(ushort)DefenseSkill.SkillId];	
							critChance += (float)(sk2.CurrentVal(this) - sk1.CurrentVal(m))/5;
						}

						else
							critChance += (float)(sk2.CurrentVal(this) - m.Level*5)/5;	
					}
				}
			}
			else 
			{
				switch (this.Classe)
				{
					case Classes.Rogue : break;
					case Classes.Hunter : break;
					case Classes.Druid : break;
					case Classes.Warrior : 
						if (this.HaveTalent(Talents.AxeSpecialization) && weapon.SubClass == 0 )
						{
							AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.AxeSpecialization);
							critChance +=effect1.S1;
						}
					if (this.HaveTalent(Talents.PolearmSpecialization) && weapon.SubClass == 6 )
						{
							AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.PolearmSpecialization);
							critChance +=effect1.S1;
						}
						if (this.HaveTalent(Talents.Cruelty) && weapon.ObjectClass == 2)
						{
							AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.Cruelty);
							critChance +=effect1.S1;
						}
						
						break;
				}
				if (m is Character)
				{	/* not sure by this formula*/
					Skill sk1 = m.AllSkills[(ushort)DefenseSkill.SkillId];
					critChance += (float)(5*this.Level - sk1.CurrentVal(m))/5;
				}
				else
					critChance += (float)(5*this.Level - m.Level*5)/5;
			}
			critChance +=(float)this.PhysicalCriticalBonus;
			return critChance;
		}
		public float HitChanceCalculation(Item weapon,Mobile m, float dif)
		{			
			float hitChance = 0;
			if (dif < 0 ) hitChance = 35 + (int)dif;
			else if (m.Level < this.Level + 4) hitChance = 35 - (int)dif * 15;
			else hitChance = 35 - (int)dif * 10;
			hitChance += (float)this.HitBonus + (float)this.MeleeHitBonus - (float)this.HitMalus - (float)this.MeleeHitMalus; 
			if(hitChance >= 99) hitChance = 99;
			if(hitChance <= 1) hitChance = 1; 
			return hitChance;
		}
		public float ParryChanceCalculation(Mobile m,float dif)
		{
			float chance = 0f;
			if(m.HaveSpell(3127))
			{			
				if (m is Character) chance = (int)((m as Character).BaseParryChance + ParryBonus - ParryMalus - dif/2);
				else chance = 5 + ParryBonus - ParryMalus - (int)dif/2;
#if TRACES_COMBAT
				Console.WriteLine("Parry result: parryChance: " +  chance + " roll");  
#endif
				if ( m.HaveTalent( Talents.Deflection) )
				{
					AuraEffect ae = (AuraEffect)m.GetTalentEffect( Talents.Deflection );
					chance = (chance * 1 + (float)ae.S1/100); 
				}
				
			}
			return chance;
		}
		public float DodgeChanceCalculation(Mobile m,float dif)
		{
			float chance = 0f;
			if (m is Character) 
			{
				m.SkillUpDefense();
				chance = (int)((m as Character).BaseDodgeChance + DodgeBonus - DodgeMalus- (int)dif/2);
			}
			else 
				chance = 5 + DodgeBonus - DodgeMalus- (int)dif/2;
			return chance;
		}
		public float BlockChanceCalculation(Mobile m,float dif)
		{
			float chance = 0f;
			if (m.activeShield != null)
			{
				if (m is Character) 
				{
					chance = (int)((m as Character).BaseBlockChance + BlockBonus - BlockMalus - (int)dif/2);					
				}
				else chance = 5 + BlockBonus - BlockMalus - (int)dif/2;
#if TRACES_COMBAT
				Console.WriteLine("Block result: chance: " +  chance + " roll"); 
#endif		
			}
			// shield specialization
			if (m.HaveTalent(Talents.ShieldSpecialization))
			{
				AuraEffect af = (AuraEffect)m.GetTalentEffect(Talents.ShieldSpecialization);
				chance +=af.S1;
			}
			return chance;
		}

		public float ArmorReductionCalculation(Mobile m)
		{
			return (float)m.Armor / ( m.Armor + 400 + 85 * level );
		}
		
		public float DamageDoneCalculation(Mobile m,float dmgBonus, bool critical,Item weapon)
		{
			float deg;
			if (weapon != null)
			{
				deg = ( ( weapon.PhysicalMaxDamage - weapon.PhysicalMinDamage ) ) * (float)Utility.RandomDouble();
			}
			else
			{
				deg = ( ( maxDamage - minDamage ) ) * (float)Utility.RandomDouble();
			
			}
			int AP = 0;
			AP +=AttackPower;
			switch (m.NpcType)
			{
				case (int)NpcTypes.Undead : AP +=AttackPowerBonusAgainsUndead - AttackPowerMalusAgainsUndead;break;
				case (int)NpcTypes.Giant : AP +=AttackPowerBonusAgainsGiants - AttackPowerMalusAgainsGiants;break;
				case (int)NpcTypes.Demon : AP +=AttackPowerBonusAgainsDemons - AttackPowerMalusAgainsDemons;break;
				case (int)NpcTypes.Beast : AP +=AttackPowerBonusAgainsBeast- AttackPowerMalusAgainsBeast;break;
			}
			
			deg += (float)AP / 14;
			deg += (float)( (float)( Str * Str ) / 100f );
			deg += minDamage;
			deg += MeleeDamageBonus;
			deg -= MeleeDamageMalus;
			deg += AllDamageDoneBonus;
			deg -= AllDamageDoneMalus;
			deg = deg * (1-MeleePercentDamageMalus);
			deg = deg * (1+MeleePercentDamageBonus);
			#region damage bonus from talents handling here
			int damagePercentBonusFromTalents = 0;
			switch (this.Classe)
			{
					#region warrior
				case Classes.Warrior:
					// two-handed weapon specialization
					if (this.HaveTalent(Talents.TwoHandedWeaponSpecialization) && weapon.InventoryType	== InventoryTypes.TwoHanded )
					{
						AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.TwoHandedWeaponSpecialization);
						damagePercentBonusFromTalents +=effect1.S1;
					}
					// two-handed weapon specialization
					if (this.HaveTalent(Talents.OneHandedWeaponSpecialization) && weapon.InventoryType	== InventoryTypes.OneHand)
					{
						AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.OneHandedWeaponSpecialization);
						damagePercentBonusFromTalents +=effect1.S1;
					}
					/*if( c.HaveTalent(Talents.Bloodthirst))
					{
						bool bonus = false;
						ArrayList al1 = new ArrayList();
						AuraEffect af = (AuraEffect)c.GetTalentEffect( Talents.Bloodthirst );
						foreach( Mobile.AuraReleaseTimer art in c.Auras )
							if(art.aura.SpecialState == SpecialStates.Bloodthirst)
							{
								bonus = true;
								al1.Add(art);
							}

						if (bonus) 
						{
							damagePercentBonusFromTalents +=100;
						}
					}*/
					break;
					#endregion
			}
			if ( SummonedBy != null )
			{
				if ( Id == 1863 || Id == 1860 || Id == 417 )
				{
					if ( SummonedBy.HaveTalent( Talents.UnholyPower ) )
					{
						AuraEffect ae = (AuraEffect)SummonedBy.GetTalentEffect( Talents.UnholyPower );
						damagePercentBonusFromTalents = ae.S1;
					}
				}
			}
			#endregion
			deg = deg * (1+(float)damagePercentBonusFromTalents/100);
			deg = deg * (AllDamageDoneModifier);
			if (this.SummonedBy !=null)
			{
				deg+= this.SummonedBy.PetDamageBonus - this.SummonedBy.PetDamageMalus;
			}
			switch (m.NpcType)
			{
				case (int)NpcTypes.Beast : deg += this.MeleeDamageDoneAgainsBeastBonus; break;
				case (int)NpcTypes.Demon : deg += this.MeleeDamageDoneAgainsDemonsBonus; break;
				case (int)NpcTypes.Elemental : deg += this.MeleeDamageDoneAgainsElementalsBonus; break;
				case (int)NpcTypes.Undead : deg += this.MeleeDamageDoneAgainsUndeadBonus; break;
				case (int)NpcTypes.Dragonkin : deg += this.MeleeDamageDoneAgainsDragonsBonus; break;
				case (int)NpcTypes.Giant : deg += this.MeleeDamageDoneAgainsGiantsBonus; break;
			}
			/*bovie*/
			if(critical == true)
			{
				float criticDMG = 0;
				#region critic damage talents handling
				int criticDamageBonus = 0; 
				#endregion
				criticDMG = (float)(criticDamageBonus + 100)/100;
				deg *= 1+ criticDMG;	
			}
			/*bovie*/
			deg += dmgBonus;
			return deg;
			
		}
		

		public float DamageAbsorbCombat(float deg)
		{
			deg = (int)DiminishAbsorbPhysical( (int)deg );
			deg = (int)DiminishAbsorbAllDamage( (int)deg );
			return deg;
		}
		public float DamageTakenCalculation(Mobile m, float deg)
		{
			deg += (m.DamageTakenBonus - m.DamageTakenMalus + m.MeleeDamageTakenBonus - m.MeleeDamageTakenMalus);
			deg += (m.PhysicalDamageTakenBonus - m.PhysicalDamageTakenMalus);
			deg *= m.DamageTakenModifier;
			deg *= (1 + (float)m.MeleePercentDamageTakenIncrease/100 - (float)m.MeleePercentDamageTakenReduction/100);
			return deg;
		}
		public void OnMeleeTrigersCalling(Mobile m)
		{
			
			
			activeWeapon.TriggerOnHit( this, m );
		}

		public virtual int Hit( Mobile m, float dmgBonus)
		{
			int amountBlocked = 0, amountAbsorbed = 0;
			return Hit(m,dmgBonus,false, ref amountBlocked, ref amountAbsorbed);
		}
		public virtual int Hit( Mobile m, ref int amountBlocked, ref int amountAbsorbed )
		{
			return Hit(m, 0f, false, ref amountBlocked, ref amountAbsorbed );
		}
		public virtual int Hit( Mobile m, float dmgBonus,bool pass, ref int amountBlocked, ref int amountAbsorbed )
		{			
			Item weapon = activeWeapon;
			if ( Level < m.Level - 7 )
			{
				lastAttack = AttackStatus.Dodge;
				m.lastAttackToMe = AttackStatus.Dodge;
				return -1;	
			}			
			float critChance = CriticalChanceCalculation(weapon,m);
			float dif = SkillDifCalculation(weapon,m);
			float hitChance = HitChanceCalculation(weapon,m,dif);
		
			bool criticalStrike = false;
			
			#region critical and hit test
			int roll =Utility.Random( 100 );	

			if ((int)critChance >= roll )
			{
				#region Critical hit trigger done
				ArrayList al = new ArrayList();
				ArrayList pal = new ArrayList();
				foreach( AuraReleaseTimer art in aura )
				{
					int a = art.aura.OnCriticalHit;
					if ( a != -1 )
						al.Add( art );
				}
				foreach( PermanentAura art in permanentAura )
				{
					int a = art.aura.OnCriticalHit;
					if ( a != -1 )
						al.Add( art );
				}
				foreach( object obj in al )
				{
					if(obj is AuraReleaseTimer)
					{ 
						AuraReleaseTimer art = (AuraReleaseTimer)obj;
						int a = art.aura.OnCriticalHit;
						if ( a != -1 )
							if(Triggers[ a ] != null)
								( Triggers[ a ] as OnCriticalHitTrigger )( this, m, art.ae );
					}
					if(obj is PermanentAura)
					{ 
						PermanentAura art = (PermanentAura)obj;
						int a = art.aura.OnCriticalHit;
						if ( a != -1 )
							if(Triggers[ a ] != null)
								( Triggers[ a ] as OnCriticalHitTrigger )( this, m, Abilities.abilities[(int)art.Id] );
					}
				}
				#endregion
				
				#region Critical hit done Triggers
				ArrayList al2 = new ArrayList();
				ArrayList pal2 = new ArrayList();
				foreach( AuraReleaseTimer art in aura )
				{
					int a = art.aura.OnCriticalHitDone;
					if ( a != -1 )
						al2.Add( art );
				}
				foreach( PermanentAura art in permanentAura)
				{
					int a = art.aura.OnCriticalHitDone;
					if ( a != -1 )
						pal2.Add( art );
				}
				foreach( object obj in al2 )
				{
					if(obj is AuraReleaseTimer)
					{ 
						AuraReleaseTimer art = (AuraReleaseTimer)obj;
					
						int a = art.aura.OnCriticalHitDone;
						if ( a != -1 )
							if(Triggers[ a ] != null) 
								( Triggers[ a ] as OnCriticalHitDoneTrigger )(this, m, art.ae );
					}
					if(obj is PermanentAura)
					{ 
						PermanentAura art = (PermanentAura)obj;
						int a = art.aura.OnCriticalHitDone;
						if ( a != -1 )
							if(Triggers[ a ] != null)
								( Triggers[ a ] as OnCriticalHitDoneTrigger )(this, m, Abilities.abilities[(int)art.Id] );
					}
				}
				#endregion
				
					
				/*bovie*/
					
				/*bovie*/	
				lastAttack = AttackStatus.Critical;
				m.lastAttackToMe = AttackStatus.Critical;
				criticalStrike = true;
			}
			else if((int)hitChance <= roll)
			{
				lastAttack = AttackStatus.NormalHit;
				m.lastAttackToMe = AttackStatus.NormalHit;
			}
			else 
			{
				lastAttack = AttackStatus.Loose;
				m.lastAttackToMe = AttackStatus.Loose;
				return 0;
			}
			#endregion

			if (!pass)
			{
				float parryChance = ParryChanceCalculation(m,dif);

				#region Parry test
				roll = Utility.Random( 100 );
				if (parryChance >= roll)
				{
					lastAttack = AttackStatus.Parry;
					m.lastAttackToMe = AttackStatus.Parry;
					return -2;	
				}
				#endregion			

				float dodgeChance = DodgeChanceCalculation(m,dif);

				#region Dodge test
				roll = Utility.Random( 100 );
				if (dodgeChance >= roll)
				{
					lastAttack = AttackStatus.Dodge;
					m.lastAttackToMe = AttackStatus.Dodge;
					return -1;	
				}
				#endregion
			}


			float damage = DamageDoneCalculation(m,dmgBonus,criticalStrike,weapon);
			float blockChance = BlockChanceCalculation(m,dif);
			if (!pass)
			{
				#region Block test + block reduction	
				roll = Utility.Random( 100 );
				// shield specialization
				if (blockChance >= roll)
				{
					lastAttack = AttackStatus.Block;
					m.lastAttackToMe = AttackStatus.Block;
					amountBlocked = m.Block + m.Str/30;
					damage -= amountBlocked;
					#region talents
					// shield specialization
					if ( m.HaveTalent(Talents.ShieldSpecialization) )
					{
						AuraEffect af = (AuraEffect)m.GetTalentEffect(Talents.ShieldSpecialization);
						roll = Utility.Random( 100 );
						if ( roll < af.H )
						{
							m.GainMana(m,(Abilities.abilities[af.AdditionalSpell] as SpellTemplate).S1);
						}
					}
					#endregion
				}
		
				#endregion
			}
			#region Armor reduction
			float armor = ArmorReductionCalculation(m); 
			damage = damage * (1 - armor);
			#endregion

			#region immune
			if (m.ImmunePhysicalDamage)
			{
				lastAttack = AttackStatus.Immune;
				m.lastAttackToMe = AttackStatus.Immune;
				return 0;
			}
			#endregion
			
			#region absorb
			amountAbsorbed = (int)damage;
			damage =(int)m.DamageAbsorbCombat(damage);
			amountAbsorbed -= (int)damage;
			if ( damage < 0 )
			{
				this.lastAttack = AttackStatus.Absorb;
				m.lastAttackToMe = AttackStatus.Absorb;	
				return 0;
			}
			#endregion

			#region Targets modificators 
			damage = DamageTakenCalculation(m,damage);
			#endregion
			damage = m.ManaShieldLost(this,(int)damage);
			#region other effects
			
			switch (this.Classe)
			{
					#region warrior
				case Classes.Warrior:
					// deep wounds 
					if (this.lastAttack == AttackStatus.Critical)
					{
						/*if ( src.HaveTalent( Talents.DeepWounds) )
						{
							AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.DeepWounds );
								
								AuraEffect af = (AuraEffect)Abilities.abilities[ae.AdditionalSpell];
								float modif = (float)ae.S1/100;
								af.ApplyDot(this, m, (int)(damage*modif), af.T1, af.Duration(this));
							
						}*/
						if ( m.HaveTalent( Talents.BloodCraze) )
						{
							AuraEffect ae = (AuraEffect)m.GetTalentEffect( Talents.BloodCraze );
							SpellTemplate st = (SpellTemplate)Abilities.abilities[ae.AdditionalSpell];
							HotAura aura = new HotAura(st,m,m,(int)(m.BaseHitPoints*((float)st.S1/100)/(st.Duration(m)/st.T1)),st.Duration(m),st.T1);
							
						}

					}
					//Mace specialization
					/*if ( src.HaveTalent( Talents.MaceSpecialization) && weapon.SubClass == 4 )
					{
						AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.MaceSpecialization );
						roll = Utility.Random( 100 );
						if(roll < ae.H)
						{
							AuraEffect af = (AuraEffect)Abilities.abilities[ae.AdditionalSpell];
							Aura aura = new Aura();
							aura.ForceStun = true;
							m.AddAura(this, af,aura,true);
						}
					}*/
					int SwordSpecializationEffect = 0x14af5e;
					/*if ( src.HaveTalent( Talents.SwordSpecialization) && weapon.SubClass == 15 )
					{
						AuraEffect ae = (AuraEffect)src.GetTalentEffect( Talents.SwordSpecialization );
					roll = Utility.Random( 100 );	
					if(roll < ae.H)
						{
							this.AdditionnalStates.Add(SwordSpecializationEffect);
						}
					}*/
					if ( this.HaveTalent( Talents.UnbridledWrath) )
					{
						AuraEffect ae = (AuraEffect)this.GetTalentEffect( Talents.UnbridledWrath );
						roll = Utility.Random( 100 );
						if(roll < ae.H)
						{
							this.GainMana(this,1);
						}
					}
					
					break;
					#endregion
			}
			#endregion
			if ( damage > 0 )
				this.SkillUpWeapon(weapon);
			return (int)damage;
		}
		#endregion

		#region new RangedHit
		public float RangedCriticalChanceCalculation(Item weapon,Mobile m)
		{
			float critChance = 5f; // for creatures base is 5%
			if(this is Character)
			{
				int skid = weapon.GetSkillId();
				critChance = (this as Character).BaseCritChance;
				if ( skid != 0 )
				{
					Skill sk2 = this.AllSkills[(ushort)skid];
					if (sk2 != null)
					{
						if (m is Character)
						{	/* not sure by this formula*/	
							Skill sk1 = m.AllSkills[(ushort)DefenseSkill.SkillId];	
							critChance += (float)(sk2.CurrentVal(this) - sk1.CurrentVal(m))/5;
						}

						else
							critChance += (float)(sk2.CurrentVal(this) - m.Level*5)/5;	
					}
				}
			}
			else
			{
				if (m is Character)
				{	/* not sure by this formula*/
					Skill sk1 = m.AllSkills[(ushort)DefenseSkill.SkillId];
					critChance += (float)(5*this.Level - sk1.CurrentVal(m))/5;
				}
				else
					critChance += (float)(5*this.Level - m.Level*5)/5;
			}

			switch (this.Classe)
			{
				case Classes.Rogue : break;
				case Classes.Hunter : break;
				case Classes.Druid : break;
				case Classes.Warrior : 
					if (this.HaveTalent(Talents.AxeSpecialization) && weapon.SubClass == 0 )
					{
						AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.AxeSpecialization);
						critChance +=effect1.S1;
					}
					if (this.HaveTalent(Talents.PolearmSpecialization) && weapon.SubClass == 6 )
					{
						AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.PolearmSpecialization);
						critChance +=effect1.S1;
					}
					if (this.HaveTalent(Talents.Cruelty) && weapon.ObjectClass == 2)
					{
						AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.Cruelty);
						critChance +=effect1.S1;
					}
						
					break;
			}
				
			critChance +=(float)this.PhysicalCriticalBonus;
			return critChance;
		}
		public float RangedHitChanceCalculation(Item weapon,Mobile m, float dif)
		{
			
			float hitChance = 0;
			if (dif < 0 ) hitChance = 95 + (int)dif;
			else if (m.Level < this.Level + 4) hitChance = 95 - (int)dif * 15;
			else hitChance = 95 - (int)dif * 10;
			hitChance += (float)this.HitBonus + (float)this.RangedHitBonus - (float)this.HitMalus - (float)this.RangedHitMalus; 
			if(hitChance >= 99) hitChance = 99;
			if(hitChance <= 1) hitChance = 1; 
			return hitChance;
		}
		public float RangedDodgeChanceCalculation(Mobile m,float dif)
		{
			float chance = 0f;
			if (m is Character) 
			{
				m.SkillUpDefense();
				chance = (int)((m as Character).BaseDodgeChance + DodgeBonus - DodgeMalus- (int)dif/2);
			}
			else 
				chance = 5 + DodgeBonus - DodgeMalus- (int)dif/2;
			return chance;
		}
		public float RangedBlockChanceCalculation(Mobile m,float dif)
		{
			float chance = 0f;
			if (m.activeShield != null)
			{
				if (m is Character) 
				{
					chance = (int)((m as Character).BaseBlockChance + BlockBonus - BlockMalus - (int)dif/2);					
				}
				else chance = 5 + BlockBonus - BlockMalus - (int)dif/2;
#if TRACES_COMBAT
				Console.WriteLine("Block result: chance: " +  chance + " roll"); 
#endif		
			}
			// shield specialization
			if (m.HaveTalent(Talents.ShieldSpecialization))
			{
				AuraEffect af = (AuraEffect)m.GetTalentEffect(Talents.ShieldSpecialization);
				chance +=af.S1;
			}
			return chance;
		}

		public float RangedArmorReductionCalculation(Mobile m)
		{
			return (float)m.Armor / ( m.Armor + 400 + 85 * level );
		}

		public Item RangedWeapon
		{
			get
			{
				Item weapon = null;
				if (this is Character)
				{
					weapon = this.Items[(int)Slots.Ranged ];
					return weapon;
				}
				else if(this is RangedCreature)
				{
					return (this as RangedCreature).rangedWeapon;
				}
				return null;
			}
		}
		public Item RangedAmmo
		{
			get
			{
				Item ammo = null;
				if(this is Character)
				{
					ammo = World.CreateItemInPoolById( (this as Character).AmmoType );
					return ammo;
				}
				else if(this is RangedCreature)
				{
					return (this as RangedCreature).rangedAmmo;
				}
				return null;
			}
		}

		public float RangedAttackSpeed
		{
			get
			{
				Item weapon = RangedWeapon;
				if( weapon != null)
					return ((float)weapon.Delay*this.RangedAttackSpeedModifier/1000);
				else return 0;
			}
		}

		public int RangedMinDamage
		{
			get 
			{
				if(RangedWeapon == null) return 0;
				float deg = 0;
				Item weapon = RangedWeapon;
				Item ammo = RangedAmmo;
								
				deg += weapon.PhysicalMinDamage;
				if(!(weapon.InventoryType == InventoryTypes.Thrown && ammo != null))
				{
					deg +=ammo.PhysicalMinDamage*this.RangedAttackSpeed;
				}
				
				int AP = 0;
				AP +=this.RangedAttackPower;
				deg += ((float)AP / 14)*this.RangedAttackSpeed;
				deg += RangedDamageBonus;
				deg -= RangedDamageMalus;
				deg += AllDamageDoneBonus;
				deg -= AllDamageDoneMalus;

				#region damage bonus from talents handling here
				int damagePercentBonusFromTalents = 0;
				switch (this.Classe)
				{
						#region warrior
					case Classes.Warrior:
						break;
						#endregion
				}
				if ( SummonedBy != null )
				{
					if ( Id == 1863 || Id == 1860 || Id == 417 )
					{
						if ( SummonedBy.HaveTalent( Talents.UnholyPower ) )
						{
							AuraEffect ae = (AuraEffect)SummonedBy.GetTalentEffect( Talents.UnholyPower );
							damagePercentBonusFromTalents = ae.S1;
						}
					}
				}
				#endregion

				deg = deg * (1+(float)damagePercentBonusFromTalents/100);
				deg = deg * (AllDamageDoneModifier);
				return (int)deg;
			}
			
		}
		public int RangedMaxDamage
		{
			get 
			{
				if(RangedWeapon == null) return 0;
				float deg = 0;
				Item weapon = RangedWeapon;
				Item ammo = RangedAmmo;
								
				deg += weapon.PhysicalMaxDamage;
				if(!(weapon.InventoryType == InventoryTypes.Thrown && ammo != null))
				{
					deg +=ammo.PhysicalMaxDamage*this.RangedAttackSpeed;
				}
				
				int AP = 0;
				AP +=this.RangedAttackPower;
				deg += ((float)AP / 14)*this.RangedAttackSpeed;
				deg += RangedDamageBonus;
				deg -= RangedDamageMalus;
				deg += AllDamageDoneBonus;
				deg -= AllDamageDoneMalus;

				#region damage bonus from talents handling here
				int damagePercentBonusFromTalents = 0;
				switch (this.Classe)
				{
						#region warrior
					case Classes.Warrior:
						break;
						#endregion
				}
				if ( SummonedBy != null )
				{
					if ( Id == 1863 || Id == 1860 || Id == 417 )
					{
						if ( SummonedBy.HaveTalent( Talents.UnholyPower ) )
						{
							AuraEffect ae = (AuraEffect)SummonedBy.GetTalentEffect( Talents.UnholyPower );
							damagePercentBonusFromTalents = ae.S1;
						}
					}
				}
				#endregion

				deg = deg * (1+(float)damagePercentBonusFromTalents/100);
				deg = deg * (AllDamageDoneModifier);
				return (int)deg;
			}
			
		}

		public float RangedDamageDoneCalculation(Mobile m,float dmgBonus, bool critical,Item _weapon)
		{	
			float deg = 0;
			int min = 0;
			min = RangedMinDamage;
			deg += min + Utility.Random( 1, RangedMaxDamage - min );
			int AP = 0;
			switch (m.NpcType)
			{
				case (int)NpcTypes.Undead : AP +=AttackPowerBonusAgainsUndead - AttackPowerMalusAgainsUndead;break;
				case (int)NpcTypes.Giant : AP +=AttackPowerBonusAgainsGiants - AttackPowerMalusAgainsGiants;break;
				case (int)NpcTypes.Demon : AP +=AttackPowerBonusAgainsDemons - AttackPowerMalusAgainsDemons;break;
				case (int)NpcTypes.Beast : AP +=AttackPowerBonusAgainsBeast- AttackPowerMalusAgainsBeast;break;
			}
			deg +=AP/14*this.RangedAttackSpeed;
			
					
			if (this.SummonedBy !=null)
			{
				deg+= this.SummonedBy.PetDamageBonus - this.SummonedBy.PetDamageMalus;
			}
			
			/*bovie*/
			if(critical == true)
			{
				float criticDMG = 0;
				#region critic damage talents handling
				int criticDamageBonus = 0; 
				#endregion
				criticDMG = (float)(criticDamageBonus + 100)/100;
				deg *= 1+ criticDMG;	
			}
			/*bovie*/
			deg += dmgBonus;
			return deg;
			
		}
		
		public float RangedDamageTakenCalculation(Mobile m, float deg)
		{
			deg += (m.DamageTakenBonus - m.DamageTakenMalus + m.RangedDamageTakenBonus - m.RangedDamageTakenMalus);
			deg += (m.PhysicalDamageTakenBonus - m.PhysicalDamageTakenMalus);
			deg *= m.DamageTakenModifier;
			return deg;
		}
	
		
		public void AttackerStateUpdateForSpell(Mobile src, Mobile target,SpellTemplate st, int degats)
		{
			int offset = 4;
			if ( degats <= 0 )
				Converter.ToBytes( 0x22, tempBuff, ref offset );
			else
				Converter.ToBytes( 0x22, tempBuff, ref offset );
	
			Converter.ToBytes( src.Guid, tempBuff, ref offset );
			Converter.ToBytes( target.Guid, tempBuff, ref offset );
			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			Converter.ToBytes( (byte)1, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			if ( degats > 0 )
				Converter.ToBytes( (float)degats/*DamageType*/, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );
			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			
			Converter.ToBytes( st.Id, tempBuff, ref offset ); // additional spell damage id
			Converter.ToBytes( st.Id, tempBuff, ref offset ); // additional spell damage id
			if ( degats >= 0 )
				Converter.ToBytes( 1, tempBuff, ref offset );
			else
				if ( degats == -1 )
				Converter.ToBytes( 2, tempBuff, ref offset );// dodge
			else
				if ( degats == - 2 )
				Converter.ToBytes( 9, tempBuff, ref offset );// parry
			else
				if ( degats == - 3 )
				Converter.ToBytes( 4, tempBuff, ref offset );// interrupted
			else
				if ( degats == - 4  )
				Converter.ToBytes( 5, tempBuff, ref offset );// block
			else
				if ( degats == - 5 )
				Converter.ToBytes( 6, tempBuff, ref offset );// evade
			else
				if ( degats == - 6 )
				Converter.ToBytes( 7, tempBuff, ref offset );// immune
			else
				if ( degats == - 7 )
				Converter.ToBytes( 8, tempBuff, ref offset );// deflect

			
			if ( degats == 0 )
				Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					

		}
		

		public AutoShotEffect AutoShot;
		public class AutoShotEffect : WowTimer
		{
			Mobile target;
			Mobile caster;
			SpellTemplate st;
			Item ammo;
			public bool move;

			public AutoShotEffect(Mobile _target,Mobile _caster,int tick,SpellTemplate _st,Item _ammo):base(WowTimer.Priorities.Milisec100,tick)
			{
				target = _target;
				caster = _caster;
				st = _st;
				ammo = _ammo;
				move = false;
			}
			public override void OnTick()
			{
				if (target.Dead)
				{
					caster.OnCancelAutoCastSpell();
					caster.SpellFaillure(SpellFailedReason.TheTargetIsDead);
					return;
				}
				else
				{					
					target.UpdateXYZ();
				
					float dist = caster.Distance( target );
					if ( dist > 64 && dist < 1225  )
					{
						
						if (move)
						{
							move = false;
						}
						else
						{
							
							int offset = 4;
							Converter.ToBytes( caster.Guid, caster.tempBuff, ref offset );
							Converter.ToBytes( caster.Guid, caster.tempBuff, ref offset );
							Converter.ToBytes( 75, caster.tempBuff, ref offset );
							Converter.ToBytes( (short)0x22, caster.tempBuff, ref offset );
							Converter.ToBytes( (uint)0x000001c7, caster.tempBuff, ref offset );
							Converter.ToBytes( (ushort)0x2, caster.tempBuff, ref offset );
							Converter.ToBytes( target.Guid, caster.tempBuff, ref offset );
							if(ammo != null)
							{
								Converter.ToBytes( (uint)ammo.Model, caster.tempBuff, ref offset );
								Converter.ToBytes( (uint)ammo.InventoryType, caster.tempBuff, ref offset );
							}
							caster.ToAllPlayerNear( OpCodes.SMSG_SPELL_START, caster.tempBuff, offset );
							

							offset = 4;
							Converter.ToBytes( (uint)75, caster.tempBuff, ref offset );
							Converter.ToBytes( (byte)0, caster.tempBuff, ref offset );
							caster.ToAllPlayerNear( OpCodes.SMSG_CAST_RESULT, caster.tempBuff, offset );
						
							
							offset = 4;
							Converter.ToBytes( caster.Guid, caster.tempBuff, ref offset );
							Converter.ToBytes( caster.Guid, caster.tempBuff, ref offset );
							Converter.ToBytes( 75, caster.tempBuff, ref offset );
							Converter.ToBytes( (short)0x0120, caster.tempBuff, ref offset );
							Converter.ToBytes( (byte)1, caster.tempBuff, ref offset );
							Converter.ToBytes( target.Guid, caster.tempBuff, ref offset );
							Converter.ToBytes( (byte)0, caster.tempBuff, ref offset );
							Converter.ToBytes( (ushort)2, caster.tempBuff, ref offset );
							Converter.ToBytes( target.Guid, caster.tempBuff, ref offset );
							if(ammo != null)
							{
								Converter.ToBytes( (uint)ammo.Model, caster.tempBuff, ref offset );
								Converter.ToBytes( (uint)ammo.InventoryType, caster.tempBuff, ref offset );
							}
							caster.ToAllPlayerNear( OpCodes.SMSG_SPELL_GO, caster.tempBuff, offset );
							
							if(SpellTemplate.SpellEffects[(int)st.Id] != null)
							{
								SingleTargetSpellEffectAttackSpeedRanged stse = (SingleTargetSpellEffectAttackSpeedRanged)SpellTemplate.SpellEffects[(int)st.Id];
								stse( st, caster, target );
							}
						}
					}
					else
					{
						caster.cast.id = 75;
						if(dist > 1225) caster.SpellFaillure(SpellFailedReason.OutOfRange);
						if(dist < 64) caster.SpellFaillure(SpellFailedReason.TargetTooClose);
						caster.OnCancelAutoCastSpell();
					}
					
				}
			}
		}
		public void OnCancelAutoCastSpell()
		{			
			if(this.AutoShot != null)
				this.AutoShot.Stop();
			this.AutoShot = null;
		
		}
		public virtual int RangedHit( Mobile m, float dmgBonus,bool pass, ref int amountBlocked, ref int amountAbsorbed )
		{
			Item weapon = this.RangedWeapon;
			Item ammo = this.RangedAmmo;
			if(weapon != null)
			{
				if (this is Character)
					if(weapon.InventoryType == InventoryTypes.Thrown)
					{
						(this as Character).ConsumeItemByIdUpTo(weapon.Id,1);
					}
					else
					{
						(this as Character).ConsumeItemByIdUpTo(ammo.Id,1);
					}
					
			
				float critChance = RangedCriticalChanceCalculation(weapon,m);
				float dif = SkillDifCalculation(weapon,m);
				float hitChance = RangedHitChanceCalculation(weapon,m,dif);
		
				bool criticalStrike = false;
			
				#region critical and hit test
				int roll =Utility.Random( 100 );	
				bool test = false;

				if ((int)critChance >= roll || test)
				{
					#region Critical hit trigger done
					ArrayList al = new ArrayList();
					ArrayList pal = new ArrayList();
					foreach( AuraReleaseTimer art in aura )
					{
						int a = art.aura.OnCriticalHit;
						if ( a != -1 )
							al.Add( art );
					}
					foreach( PermanentAura art in permanentAura )
					{
						int a = art.aura.OnCriticalHit;
						if ( a != -1 )
							al.Add( art );
					}
					foreach( object obj in al )
					{
						if(obj is AuraReleaseTimer)
						{ 
							AuraReleaseTimer art = (AuraReleaseTimer)obj;
							int a = art.aura.OnCriticalHit;
							if ( a != -1 )
								if(Triggers[ a ] != null)
									( Triggers[ a ] as OnCriticalHitTrigger )( this, m, art.ae );
						}
						if(obj is PermanentAura)
						{ 
							PermanentAura art = (PermanentAura)obj;
							int a = art.aura.OnCriticalHit;
							if ( a != -1 )
								if(Triggers[ a ] != null)
									( Triggers[ a ] as OnCriticalHitTrigger )( this, m, Abilities.abilities[(int)art.Id] );
						}
					}
					#endregion
				
					#region Critical hit done Triggers
					ArrayList al2 = new ArrayList();
					ArrayList pal2 = new ArrayList();
					foreach( AuraReleaseTimer art in aura )
					{
						int a = art.aura.OnCriticalHitDone;
						if ( a != -1 )
							al2.Add( art );
					}
					foreach( PermanentAura art in permanentAura)
					{
						int a = art.aura.OnCriticalHitDone;
						if ( a != -1 )
							pal2.Add( art );
					}
					foreach( object obj in al2 )
					{
						if(obj is AuraReleaseTimer)
						{ 
							AuraReleaseTimer art = (AuraReleaseTimer)obj;
					
							int a = art.aura.OnCriticalHitDone;
							if ( a != -1 )
								if(Triggers[ a ] != null) 
									( Triggers[ a ] as OnCriticalHitDoneTrigger )(this, m, art.ae );
						}
						if(obj is PermanentAura)
						{ 
							PermanentAura art = (PermanentAura)obj;
							int a = art.aura.OnCriticalHitDone;
							if ( a != -1 )
								if(Triggers[ a ] != null)
									( Triggers[ a ] as OnCriticalHitDoneTrigger )(this, m, Abilities.abilities[(int)art.Id] );
						}
					}
					#endregion
			
					/*bovie*/
					
					/*bovie*/	
					lastAttack = AttackStatus.Critical;
					m.lastAttackToMe = AttackStatus.Critical;
					criticalStrike = true;
				}
				else if((int)hitChance >= roll)
				{
					lastAttack = AttackStatus.NormalHit;
					m.lastAttackToMe = AttackStatus.NormalHit;
				}
				else 
				{
					lastAttack = AttackStatus.Loose;
					m.lastAttackToMe = AttackStatus.Loose;
					return 0;
				}
				#endregion

				if (!pass)
				{
					float dodgeChance = RangedDodgeChanceCalculation(m,dif);
	
					#region Dodge test
					roll = Utility.Random( 100 );
					if (dodgeChance >= roll)
					{
						lastAttack = AttackStatus.Dodge;
						m.lastAttackToMe = AttackStatus.Dodge;
						return 0;	
					}
					#endregion
				}


				float damage = RangedDamageDoneCalculation(m,dmgBonus,criticalStrike,weapon);
				float blockChance = RangedBlockChanceCalculation(m,dif);
				if (!pass)
				{
					#region Block test + block reduction	
					roll = Utility.Random( 100 );
				
					if (blockChance >= roll)
					{
						lastAttack = AttackStatus.Block;
						m.lastAttackToMe = AttackStatus.Block;
						amountBlocked = m.Block + m.Str/30;
						damage -= amountBlocked;
						#region talents
						// shield specialization
						if ( m.HaveTalent(Talents.ShieldSpecialization) )
						{
							AuraEffect af = (AuraEffect)m.GetTalentEffect(Talents.ShieldSpecialization);
							roll = Utility.Random( 100 );
							if ( roll < af.H )
							{
								m.GainMana(m,(Abilities.abilities[af.AdditionalSpell] as SpellTemplate).S1);
							}
						}
						#endregion
					}
		
					#endregion
				}
				#region Armor reduction
				float armor = ArmorReductionCalculation(m); 
				damage = damage * (1 - armor);
				#endregion

				#region immune
				if (m.ImmunePhysicalDamage)
				{
					lastAttack = AttackStatus.Immune;
					m.lastAttackToMe = AttackStatus.Immune;
					return 0;
				}
				#endregion
			
				#region absorb
				damage =(int)m.DamageAbsorbCombat(damage);
				if ( damage < 0 )
				{
					this.lastAttack = AttackStatus.Absorb;
					m.lastAttackToMe = AttackStatus.Absorb;	
					return 0;
				}
				#endregion

				#region Targets modificators 
				damage = RangedDamageTakenCalculation(m,damage);
				#endregion
				damage = m.ManaShieldLost(this,(int)damage);
				#region other effects
			
				switch (this.Classe)
				{
						#region warrior
					case Classes.Warrior:
					
						if ( this.HaveTalent( Talents.UnbridledWrath) )
						{
							AuraEffect ae = (AuraEffect)this.GetTalentEffect( Talents.UnbridledWrath );
							roll = Utility.Random( 100 );
							if(roll < ae.H)
							{
								this.GainMana(this,1);
							}
						}
					
						break;
						#endregion
				}
				#endregion

				if ( damage > 0 && this is Character)
					this.SkillUpWeapon(weapon);
				return (int)damage;
			}
			else 
				return 0;
		}
		
		#endregion
		

		private Mobile attackTarget;
		CombatTimer combatTimer;
		int attackMode;
		public delegate void WhenDone( );
		public SpellTemplate beingCasting;


		public void AISpellAttack( int forceCastSpell )
		{
			if ( this.knownAbilities.Count > 0 )//	spell caster
			{				
				SpellsTypes choosed = SpellsTypes.None;
				int spellChoosed = 0;

				#region Choice
				IDictionaryEnumerator Enumerator = knownAbilities.GetEnumerator();
				while (Enumerator.MoveNext())
				{
					cast.baseability = null;
					cast.castingtime = 0;
					cast.cool = 0;
					cast.id = 0;
					cast.manacost = 0;
					cast.type = 0;
					cast.duration =0;
					cast.radius = 0;

					int spell = (int)Enumerator.Key;
					SpellsTypes type = (SpellsTypes)Enumerator.Value;
					#region cast creation
				{
					BaseAbility ba;
					
					ba = (BaseAbility)Abilities.abilities[spell];
					
					if (ba is SpellTemplate)
					{
						SpellTemplate st;
						
						st = (SpellTemplate)ba;
						
						this.cast.castingtime = st.CastingTime(this);
						this.cast.cool = st.CoolDown(this);
						this.cast.id = st.Id;
						this.cast.manacost = st.GetManaCost(this);
						this.cast.type = (ushort)type;
						this.cast.baseability = st;
						int radius = st.Radius1;
						if(st.Radius2 > radius) radius = st.Radius2;
						if(st.Radius3 > radius) radius = st.Radius3;
						if(ba is AuraEffect)
							this.cast.duration = (ba as AuraEffect).Duration(this);
						else cast.duration = 0;
						this.cast.radius = (short)radius;
						
						
					}
					else
					{
						
						this.cast.castingtime = ba.CastingTime(this);
						this.cast.cool = ba.CoolDown(this);
						this.cast.id = ba.Id;
						this.cast.manacost = 0;
						this.cast.type = (ushort)type;
						this.cast.baseability = ba;
						
						this.cast.duration = 0;
						this.cast.radius = 0;
						
					}
				}
					#endregion

					if ( type == SpellsTypes.Healing && this.HitPoints < this.BaseHitPoints / 2 )
					{
						if ( cast.baseability is SpellTemplate )
						{
							SpellTemplate st = (SpellTemplate)cast.baseability;
							if ( cast.manacost <= Mana )
							{
								if ( forceCastSpell > 0 && spell == forceCastSpell )
								{
									choosed = type;
									spellChoosed = spell;
									forceCastSpell = 0;
									break;
								}
							}
						}
					}
					else
						if ( type == SpellsTypes.Curse )
					{
					}
					else
						if ( type == SpellsTypes.Defensive )
					{
						BaseAbility ba = Abilities.abilities[ spell ];
						if ( ba is AuraEffect )
						{
							AuraEffect ae = (AuraEffect)ba;
							bool alreadyCasted = false;
							foreach( AuraReleaseTimer art in aura )
								if ( art.ae == ae )
								{
									alreadyCasted = true;
									break;
								}
							if ( !alreadyCasted && cast.manacost <= Mana )
							{								
								if ( forceCastSpell > 0 && spell == forceCastSpell )
								{
									choosed = type;
									spellChoosed = spell;
									forceCastSpell = 0;
									break;
								}
							}
						}
					}
					else
						if ( type == SpellsTypes.Offensive && AttackTarget != null && !AttackTarget.Dead )
					{
						BaseAbility ba = Abilities.abilities[ spell ];
						if ( ba is SpellTemplate )
						{
							SpellTemplate st = (SpellTemplate)ba;
							if ( cast.manacost <= Mana )
							{
								if ( spellChoosed == 0 )
								{
									if ( forceCastSpell > 0 && spell == forceCastSpell )
									{
										choosed = type;
										spellChoosed = spell;
										forceCastSpell = 0;
										break;
									}
								}
							}
						}
					}
				}
				#endregion

				#region Apply decision
				if ( spellChoosed != 0 )
				{
					SpellTemplate st = (SpellTemplate)Abilities.abilities[ spellChoosed ];
					switch( choosed )
					{
						case SpellsTypes.Healing:
							beingCasting = st;
							if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
								SingleTargetCastSpell( this, cast.id, 0x8000 );
							else
								if ( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect )
							{									
								CastOnSelf( false, cast.id, 0 );
							}
							break;
						case SpellsTypes.Defensive:
							beingCasting = st;
							if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
								SingleTargetCastSpell( this, cast.id, 0x8000 );
							else
								if ( SpellTemplate.SpellEffects[ cast.id] is OnSelfSpellEffect )
							{									
								CastOnSelf( false, cast.id, 0 );
							}
							break;
						case SpellsTypes.Offensive:
							if ( AttackTarget == null )
								break;
							MoveTo( (float)( X + ( AttackTarget.X - X ) * 0.02f ), (float)( Y + ( AttackTarget.Y - Y ) * 0.02f ), (float)( AttackTarget.Z ) );
							beingCasting = st;
							if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
								SingleTargetCastSpell( AttackTarget, cast.id, 2 );//0x8000 );
							else
								if ( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect )
							{									
								CastOnSelf( false, cast.id, 0 );
							}
							else
								FakeCast( cast.id, AttackTarget, new WhenDone( this.SpellTakeEffect ) );
							break;
					}
				}
				#endregion
			}
		}


		public void ChooseAttackMode()
		{
			if ( this.ForceFlee )
				return;
			if ( this.ForceStun )
				return;
			if ( Dead || AttackTarget == null || AttackTarget.HitPoints <= 0 )
			{
				AttackTarget = null;
				AIState = AIStates.DoingNothing;
				if ( combatTimer != null )
				{
					combatTimer.Stop();
					combatTimer = null;
				}
				return;
			}
			/*
			if ( this.knownAbilities.Count > 0 )//	spell caster
			{				
				SpellsTypes choosed = SpellsTypes.None;
				int spellChoosed = 0;

				#region Choice
				IDictionaryEnumerator Enumerator = knownAbilities.GetEnumerator();
				while (Enumerator.MoveNext())
				{
					cast.baseability = null;
					cast.castingtime = 0;
					cast.cool = 0;
					cast.id = 0;
					cast.manacost = 0;
					cast.type = 0;
					cast.duration =0;
					cast.radius =0;

					int spell = (int)Enumerator.Key;
					SpellsTypes type = (SpellsTypes)Enumerator.Value;
					#region cast creation
				{
					BaseAbility ba;
					
					ba = (BaseAbility)Abilities.abilities[spell];
					
					if (ba is SpellTemplate)
					{
						
						SpellTemplate st;
						
						st = (SpellTemplate)ba;
						
						this.cast.castingtime = st.CastingTime(this);
						this.cast.cool = st.CoolDown(this);
						this.cast.id = st.Id;
						this.cast.manacost = st.GetManaCost(this);
						this.cast.type = (ushort)type;
						this.cast.baseability = st;
						int radius = st.Radius1;
						if(st.Radius2 > radius) radius = st.Radius2;
						if(st.Radius3 > radius) radius = st.Radius3;
						if(ba is AuraEffect)
							this.cast.duration = (ba as AuraEffect).Duration(this);
						else cast.duration = 0;
						this.cast.radius = (short)radius;
						
					}
					else
					{
						
						this.cast.castingtime = ba.CastingTime(this);
						this.cast.cool = ba.CoolDown(this);
						this.cast.id = ba.Id;
						this.cast.manacost = 0;
						this.cast.type = (ushort)type;
						this.cast.baseability = ba;
						this.cast.radius =0;
						this.cast.duration =0;
						
					}
				}
					#endregion

					if ( type == SpellsTypes.Healing && this.HitPoints < this.BaseHitPoints / 2 )
					{
						if ( cast.baseability is SpellTemplate )
						{
							SpellTemplate st = (SpellTemplate)cast.baseability;
							if ( cast.manacost <= Mana )
							{
								choosed = type;
								spellChoosed = spell;
								
								break;
							
							}
						}
					}
					else
						if ( type == SpellsTypes.Curse )
					{
					}
					else
						if ( type == SpellsTypes.Defensive )
					{
						BaseAbility ba = Abilities.abilities[ spell ];
						if ( ba is AuraEffect )
						{
							AuraEffect ae = (AuraEffect)ba;
							bool alreadyCasted = false;
							foreach( AuraReleaseTimer art in aura )
								if ( art.ae == ae )
								{
									alreadyCasted = true;
									break;
								}
							if ( !alreadyCasted && cast.manacost <= Mana )
							{								
								
								choosed = type;
								spellChoosed = spell;
								break;
							
							}
						}
					}
					else
						if ( type == SpellsTypes.Offensive && AttackTarget != null && !AttackTarget.Dead )
					{
						BaseAbility ba = Abilities.abilities[ spell ];
						if ( ba is SpellTemplate )
						{
							SpellTemplate st = (SpellTemplate)ba;
							if ( cast.manacost <= Mana )
							{
								if ( spellChoosed == 0 )
								{
									choosed = type;
									spellChoosed = spell;
									break;
									
								}
							}
						}
					}
				}
				#endregion

				#region Apply decision
				if ( spellChoosed != 0 )
				{
					if (cast.baseability is SpellTemplate)
					{
						SpellTemplate st = (SpellTemplate)Abilities.abilities[ spellChoosed ];
						switch( choosed )
						{
							case SpellsTypes.Healing:
								beingCasting = st;
								if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
									SingleTargetCastSpell( this, cast.id, 0x8000 );
								else
									if ( SpellTemplate.SpellEffects[ cast.id] is OnSelfSpellEffect )
								{									
									CastOnSelf( false, cast.id, 0 );
								}
								else
									FakeCast( cast.id, AttackTarget, new WhenDone( this.SpellTakeEffect ) );
								beingCasting = null;
								spellChoosed = 0;
								break;
							case SpellsTypes.Defensive:
								beingCasting = st;
								if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
									SingleTargetCastSpell( this, cast.id, 0x8000 );
								else
									if ( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect )
								{									
									CastOnSelf( false, cast.id, 0 );
								}
								beingCasting = null;
								spellChoosed = 0;
								break;
							case SpellsTypes.Offensive:
								if ( AttackTarget == null )
									break;
								MoveTo( (float)( X + ( AttackTarget.X - X ) * 0.02f ), (float)( Y + ( AttackTarget.Y - Y ) * 0.02f ), (float)( AttackTarget.Z ) );
								beingCasting = st;
								if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
									SingleTargetCastSpell( AttackTarget, cast.id, 2 );//0x8000 );
								else
									if ( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect )
								{									
									CastOnSelf( false, cast.id, 0 );
								}
								else
									FakeCast( cast.id, AttackTarget, new WhenDone( this.SpellTakeEffect ) );
								beingCasting = null;
								spellChoosed = 0;
								break;
						}
					}
				}
				#endregion
			}*/
			attackMode = 0;//	melee
			combatTimer = new CombatTimer( this, this.AttackSpeed );
			
			//	MeleeCombatSlice();
		}

		void SpellTakeEffect()
		{
			//int t = 0;
			if ( SpellTemplate.SpellEffects[ cast.id ] == null )
			{
				Console.WriteLine( "{0} try to cast an invalid spell !! id={1}", this.Name, cast.id );
				return;
			}
			if ( SpellTemplate.SpellEffects[ cast.id ] is SingleTargetSpellEffect )
			{
				SingleTargetSpellEffect stse = (SingleTargetSpellEffect)SpellTemplate.SpellEffects[ cast.id ];
				stse( Abilities.abilities[ cast.id ], this, AttackTarget as Mobile );
			}
			else
				if ( SpellTemplate.SpellEffects[ cast.id ] is OnSelfSpellEffect )
			{
				OnSelfSpellEffect ose = (OnSelfSpellEffect)SpellTemplate.SpellEffects[ cast.id ];
				ose( Abilities.abilities[ cast.id ], this );
			}		

			ChooseAttackMode();
		}

		public void BeginCombatWith( Mobile target )
		{
			if ( combatTimer != null )
				return;
			AttackTarget = target;	
			Running = true;
			
			if ( attackMode == 0 )
			{
				//	combatTimer = new CombatTimer( this, 1000 );
			}
			else
			{
				double angle = (float)Math.Atan2( AttackTarget.Y - Y, AttackTarget.X - X );
				angle += Math.PI;			
				MoveTo( (float)( AttackTarget.X + Math.Cos( angle ) * ( combatReach + AttackTarget.CombatReach ) * 1.5 ), (float)( AttackTarget.Y + Math.Sin( angle ) * ( combatReach + AttackTarget.CombatReach ) * 1.5 ), (float)( AttackTarget.Z ) );	
				//	combatTimer = new CombatTimer( this, this.AttackSpeed );
			}
			ChooseAttackMode();
			combatTimer.OnTick();//	Force the first hit now
		}
		public virtual int AttackSwing( UInt64 target )
		{
			return 0;
		}

 
		
		public virtual int AttackSwing(Mobile target)
		{
			return AttackSwing(target,false);
		}
		public virtual int AttackSwing( Mobile target,bool pass )
		{
			#region immune test
			if (this.ImmuneAttack)
			{
				this.lastAttack = AttackStatus.Immune;
				return 0;
			}
			#endregion
			
			if(this.AttackTarget != null)
			{
										
				ArrayList NAEbuff = (ArrayList)NextAttackEffects.Clone();
				foreach(NextAttackEffect nae in NAEbuff)
				{
						
					this.OnSpellTemplateResults(nae.spell,this.AttackTarget);
					this.NextAttackSpellGo(nae);
						
				}
					
				NAEbuff.Clear();
			}

			int amountAbsorbed = 0;
			int amountBlocked = 0;
			int degats = Hit( target, 0f, pass, ref amountBlocked, ref amountAbsorbed );
			int offset = 4;
			if ( degats <= 0 )
				Converter.ToBytes( 0x22, tempBuff, ref offset );
			else
				Converter.ToBytes( 0x22, tempBuff, ref offset );
	
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( target.Guid, tempBuff, ref offset );
			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			Converter.ToBytes( (byte)1, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			if ( degats > 0 )
				Converter.ToBytes( (float)degats/*DamageType*/, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );

			//		Converter.ToBytes( 0/*DamageType*/, tempBuff, ref offset );
			//		float ang = (float)Math.Atan2( AttackTarget.Y - Y, AttackTarget.X - X );
			if ( degats < 0 )
				Converter.ToBytes( 0, tempBuff, ref offset );
			else
				Converter.ToBytes( degats, tempBuff, ref offset );
			//	Converter.ToBytes( amountAbsorbed, tempBuff, ref offset );// damage absorbed 
			//	Converter.ToBytes( 0, tempBuff, ref offset ); // new victim state
			Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
			Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
			#region Degats types
			if ( degats >= 0 )
				Converter.ToBytes( 1, tempBuff, ref offset );
			else
				if ( degats == -1 )
				Converter.ToBytes( 2, tempBuff, ref offset );// dodge
			else
				if ( degats == - 2 )
				Converter.ToBytes( 9, tempBuff, ref offset );// parry
			else
				if ( degats == - 3 )
				Converter.ToBytes( 4, tempBuff, ref offset );// interrupted
			else
				if ( degats == - 4 || amountBlocked > 0 )
				Converter.ToBytes( 5, tempBuff, ref offset );// block
			else
				if ( degats == - 5 )
				Converter.ToBytes( 6, tempBuff, ref offset );// evade
			else
				if ( degats == - 6 )
				Converter.ToBytes( 7, tempBuff, ref offset );// immune
			else
				if ( degats == - 7 )
				Converter.ToBytes( 8, tempBuff, ref offset );// deflect

			#endregion
		
			if ( degats == 0 )
				Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					

			target.LooseHits( this, degats, true );
			return degats;
		}

		static byte []hitBuffer = { 0x00, 0x3F, 0x4A, 0x01, 0x06, 0x00, 0x00, 0x00, 0x9B, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x91, 0x14, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0xE8, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		public void MeleeCombatSlice()
		{
			Running = true;
			if (AttackTarget != null && AttackTarget.ImmuneAttack)
			{
				if ( combatTimer != null )
					combatTimer.Stop();
				combatTimer = null;
				this.lastAttack = AttackStatus.Immune;
				return;
			}
			if ( AttackTarget == null )
			{
				if ( combatTimer != null )
					combatTimer.Stop();
				combatTimer = null;
				return;
			}
			if ( AttackTarget.HitPoints > 0 && HitPoints > 0 )
			{
				UpdateXYZ();
				if ( !( AttackTarget is Character ) )
					AttackTarget.UpdateXYZ();
				float dist = Distance( AttackTarget );
				//	Console.WriteLine("target {0},{1},{2} dist = {3}", AttackTarget.X, AttackTarget.Y, AttackTarget.Z, dist );
				//	Console.WriteLine("from   {0},{1},{2} dist = {3}", X, Y, Z, dist );
				if ( dist > combatReach && dist < 8 * ( combatReach + AttackTarget.CombatReach ) )
				{
					if(this.AttackTarget != null)
						{
										
							ArrayList NAEbuff = (ArrayList)NextAttackEffects.Clone();
							foreach(NextAttackEffect nae in NAEbuff)
							{
						
								this.OnSpellTemplateResults(nae.spell,this.AttackTarget);
								this.NextAttackSpellGo(nae);
						
							}
					
							NAEbuff.Clear();
						}

					//FaitFace( target );
					int amountAbsorbed = 0;
					int amountBlocked = 0;
					int degats = Hit( AttackTarget, ref amountAbsorbed, ref amountBlocked );

					AIState = AIStates.Fighting;
					MoveTo( (float)( X + ( AttackTarget.X - X ) * 0.02f ), (float)( Y + ( AttackTarget.Y - Y ) * 0.02f ), (float)( AttackTarget.Z ) );

					int offset = 4;
					if ( degats <= 0 )
						Converter.ToBytes( 0x22, tempBuff, ref offset );
					else
						Converter.ToBytes( 0x22, tempBuff, ref offset );
	
					Converter.ToBytes( Guid, tempBuff, ref offset );
					Converter.ToBytes( AttackTarget.Guid, tempBuff, ref offset );
					if ( degats < 0 )
						Converter.ToBytes( 0, tempBuff, ref offset );
					else
						Converter.ToBytes( degats, tempBuff, ref offset );
					Converter.ToBytes( (byte)1, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					if ( degats > 0 )
						Converter.ToBytes( (float)degats/*DamageType*/, tempBuff, ref offset );
					else
						Converter.ToBytes( 0, tempBuff, ref offset );

			//		Converter.ToBytes( 0/*DamageType*/, tempBuff, ref offset );
					//		float ang = (float)Math.Atan2( AttackTarget.Y - Y, AttackTarget.X - X );
					if ( degats < 0 )
						Converter.ToBytes( 0, tempBuff, ref offset );
					else
						Converter.ToBytes( degats, tempBuff, ref offset );
				//	Converter.ToBytes( amountAbsorbed, tempBuff, ref offset );// damage absorbed 
				//	Converter.ToBytes( 0, tempBuff, ref offset ); // new victim state
					Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
					Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
					#region Degats types
					if ( degats >= 0 )
						Converter.ToBytes( 1, tempBuff, ref offset );
					else
					if ( degats == -1 )
						Converter.ToBytes( 2, tempBuff, ref offset );// dodge
					else
						if ( degats == - 2 )
						Converter.ToBytes( 9, tempBuff, ref offset );// parry
					else
						if ( degats == - 3 )
						Converter.ToBytes( 4, tempBuff, ref offset );// interrupted
					else
						if ( degats == - 4 || amountBlocked > 0 )
						Converter.ToBytes( 5, tempBuff, ref offset );// block
					else
						if ( degats == - 5 )
						Converter.ToBytes( 6, tempBuff, ref offset );// evade
					else
						if ( degats == - 6 )
						Converter.ToBytes( 7, tempBuff, ref offset );// immune
					else
						if ( degats == - 7 )
						Converter.ToBytes( 8, tempBuff, ref offset );// deflect

					#endregion
		
					if ( degats == 0 )
						Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
					else
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					//HexViewer.View( tempBuff, 0, offset );
					ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					

					AttackTarget.LooseHits( this, degats, true );

					if ( AttackTarget.Dead )
					{
						int off = 4;
						Converter.ToBytes( Guid, tempBuff, ref off );
						Converter.ToBytes( AttackTarget.Guid, tempBuff, ref off );
						ToAllPlayerNear( OpCodes.SMSG_ATTACKSTOP, tempBuff, off );						
						if ( combatTimer != null )
							combatTimer.Stop();
						AttackTarget = null;
					}					
					
				}
				else
				{
					float less = 1.0f;
					if ( dist > 20 )
						less = 0.5f;
					double angle = (float)Math.Atan2( AttackTarget.Y - Y, AttackTarget.X - X );
					angle += Math.PI;
					MoveTo( (float)( AttackTarget.X + Math.Cos( angle ) * ( combatReach + AttackTarget.CombatReach ) * 1.5 * less ), (float)( AttackTarget.Y + Math.Sin( angle ) * ( combatReach + AttackTarget.CombatReach ) * 1.5 * less ), (float)( AttackTarget.Z ) );
					AIState = AIStates.Attack;
				}
			}
			if ( ( this as BaseCreature ).IsStillActive() )
				ChooseAttackMode();
		}
		public int ManaShieldLost(Mobile from, int hp)
		{
			if( this.ManaShield > 0)
			{
				// Improved ManaShield
				float modif = 1f;
				if ( this.HaveTalent( Talents.ImprovedManaShield ) )
				{
					AuraEffect af = (AuraEffect)this.GetTalentEffect( Talents.ImprovedManaShield );
					modif *=1 + (float)af.S1/100;
				}
				int manalost = 0;
				int canLost = (int)((float)this.Mana/(2*modif));
				if (this.ManaShield > hp)
				{
					foreach(AuraReleaseTimer art in aura)
					{
						if (art.aura.ManaShield > 0)
						{
							if ( art.aura.ManaShield > hp )
							{
								if (canLost > hp)
								{
									art.aura.ManaShield -= hp;
									manalost += hp;
									hp = 0;
									break;
								}
								else 
								{
									art.aura.ManaShield -=canLost;
									manalost +=canLost;
									hp -= canLost;
									break;
								}
								
							}
							else
							{
								if (canLost > art.aura.ManaShield)
								{
									
									manalost += art.aura.ManaShield;
									hp -= art.aura.ManaShield;
									art.aura.ManaShield = 0;
									break;
								}
								else 
								{
									art.aura.ManaShield -=canLost;
									manalost +=canLost;
									hp -= canLost;
									break;
								}
							}
						}
					}
					
				}
				this.LooseMana(from, (int)(2 *modif* manalost));
			
				
			
			}
			return hp;
		}
	

		public void LooseHits( Mobile from, int hp )
		{
			LooseHits( from, hp, false );
		}
		public void LooseHits( Mobile from, int hp, bool s )
		{// s = false for a spell
			if ( GodMode )
				return;
			
			if ( hp < 0 )
			{
				OnGetHit( from, s, 0 );
				return;
			}
			if ( s && Summon != null && ShareDamageWithPet )
			{
				int h = hp / 2;
				Summon.LooseHits( from, h, s );
				hp = h;
			}
			
			hitPoints -= hp;
			int rage = 0;
			if ( ManaType == 1 && BaseMana > 0 )
			{//	Rage
				rage = (int)( (float)( ( ( hp * 100 ) / this.BaseHitPoints ) ) * RageGenerationModifier );
				Mana += rage;
				if ( Mana > BaseMana )
					Mana = BaseMana;
				ManaUpdate( from );				
			}
			if ( from.ManaType == 1 && s && from.BaseMana > 0 )
			{//	Rage
				rage = (int)( (float)( ( ( hp * 50 ) / this.BaseHitPoints ) ) * from.RageGenerationModifier );
				from.Mana += rage;
				if ( from.Mana > from.BaseMana )
					from.Mana = from.BaseMana;
				from.ManaUpdate( this );				
			}
			HitPointsUpdate( this );
			int SwordSpecializationEffect = 0x14af5e;
			if (from.AdditionnalStates.Contains(SwordSpecializationEffect))
			{
				from.AttackSwing(this);
				from.AdditionnalStates.Remove(SwordSpecializationEffect);
			}
			OnGetHit( from, s, hp );
			if ( hitPoints <= 0 )
			{
				OnDeath( from );
				if(s)
				{
					/*if(from.HaveTalent(Talents.Bloodthirst))
					{
						AuraEffect af = (AuraEffect)from.GetTalentEffect(Talents.Bloodthirst);
						Aura aura = new Aura();
						aura.SpecialState = SpecialStates.Bloodthirst;
						from.AddAura(af,aura);
					}*/
				}
			}
			if (hp > 0 && this.chan.channeling > 0 && from != this)
			{
				this.ChannelEnd();
			}
			if ( hp > 0 && this.cast.id > 0 && from != this )
			{
				if (this is Character && this.spellCastTimer != null)
				{
					int offset = 4;
					Converter.ToBytes( (ulong)this.Guid, tempBuff, ref offset );
					Converter.ToBytes( (uint)((float)this.spellCastTimer.Delay * 0.2), tempBuff, ref offset );
					(this as Character).Send( OpCodes.SMSG_SPELL_DELAYED, tempBuff, offset );
				}
				if (this.spellCastTimer != null) this.spellCastTimer.Delay +=(int)((float)this.spellCastTimer.Delay * 0.2);
			}
		}
		
		

		public int InterruptCasting()
		{
			int id = 0;
			id = this.cast.id;
			if ( this is Character )
				SpellFaillure( SpellFailedReason.Interrupted );
			this.CancelCast();
			if ( this is BaseCreature )
			{
				ChooseAttackMode();
			}
			return id;
		}

		public void GainHealth( Mobile from, int hp )
		{
			if ( Dead )
				return;
			hitPoints += hp;
			if ( hitPoints > BaseHitPoints )
				hitPoints = BaseHitPoints;
			HitPointsUpdate( this );
		}

		public void GainMana( Mobile from, int a )
		{
			if ( Dead )
				return;
			Mana += a;
			if ( Mana > BaseMana )
				Mana = BaseMana;
			ManaUpdate( this );
		}	
	
		public void LooseMana( Mobile from, int a )
		{
			Mana -= a;
			if ( Mana <= 0 )
				Mana = 0;
			ManaUpdate( this );
		}
		#endregion

		#region AI
		protected DateTime lastHeartBeat = DateTime.Now;
		
		public virtual void Regeneration()
		{		
			//return;
			if (this.InteruptRegeneration == true) return;
			int dirtyMana = Mana;
			int dirtyHp = HitPoints;
			//Arcane Meditation
			
			if ( !InCombat || ManaType == 3 || this.ManaRegenWhileCastingPercent != 0)
			{
				if ( Dead )
					return;
				if ( BaseMana != 0 )
				{
					if ( ManaType == 1 && Mana > 0 )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						Mana -= (int)ts.TotalSeconds * 10;
						if ( Mana < 0 )
							Mana = 0;
					}
					else
						if ( Mana < BaseMana && ManaType != 1 )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						Mana += (int) ( ts.TotalSeconds * (double)BaseMana * ManaRegenerationModifier / 30 );
						if ( Mana > BaseMana )
							Mana = BaseMana;
					}
				}
				if ( HitPoints < BaseHitPoints && !InCombat )
				{
					TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
					HitPoints += (int)( ts.TotalSeconds * (double)BaseHitPoints * HealthRegenerationModifier / 40 );
					if ( HitPoints > BaseHitPoints )
						HitPoints = BaseHitPoints;
				}
				
				if ( dirtyMana != Mana && dirtyHp != HitPoints )
				{
					this.SendSmallUpdateToPlayerNearMe( new int[]{ 22, (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType }, new object[] { HitPoints, Mana } );
				}
				else
					if ( dirtyMana != Mana )
				{
					this.SendSmallUpdateToPlayerNearMe( new int[]{ (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType }, new object[] { Mana } );
				}
				else
					if ( dirtyHp != HitPoints )
				{
					this.SendSmallUpdateToPlayerNearMe( new int[]{ 22 }, new object[] { HitPoints } );
				}
				return;
			}
		}
		static float viewingCone = (float)( Math.PI * 3.0 / 4.0 );
		public virtual bool CanSee( Object obj )
		{		
			Mobile m = null;
			if ( obj is Mobile )
				m = (Mobile)obj;
			if ( m is Character && m.Dead )
				return false;
			if ( m is Character && !( m as Character ).Player.Realylogged )
				return false;																				
			#region Visibility spell and gm hide ability
			if ( m != this && m.Visible != InvisibilityLevel.Visible )
			{
				if ( m.Visible == InvisibilityLevel.GM )
					return false;
				if ( m.Visible == InvisibilityLevel.Lesser )
				{
					if ( !( this.CanSeeLesserInvisibility || 
						this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( m.Visible == InvisibilityLevel.Medium )
				{
					if ( !( this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( m.Visible == InvisibilityLevel.Greater )
				{
					if ( !this.CanSeeMediumInvisibility )
						return false;
				}
			}
			#endregion
			float angle = (float)( Orientation + Math.Atan2( m.Y - Y, m.X - X ) );			
			//( m as Character ).SendMessage( "Angle = " + angle.ToString() );
			if ( angle > Math.PI )
				angle -= (float)( 2 * Math.PI );
			else
				if ( angle < - Math.PI )
				angle += (float)( Math.PI * 2 );
			if ( angle < viewingCone && angle > -viewingCone )
				return true;
			return false;
		}
		public virtual void OnTick()
		{
			//aiTick();
			/*
			if ( aiType == AITypes.Custom )
			{
				if ( aiTick != null )
					aiTick();
			}
			else
			{
				switch( aiType )
				{
					default:
						break;
				}
			}
			if ( onCreatureTick != null )
				if ( !onCreatureTick() )
					return;*/
		}
		#endregion

		#region XP
		public static int []xpNeeded = new int[ 61 ];
		public static int []mobXp = new int[ 61 ];
		public int XpEarn( Mobile m )
		{		
			if ( (NpcTypes)m.NpcType == NpcTypes.Critter )
				return 0;
			float ratio = 0f;
			int lev1 = m.Level;
			int lev2 = level;
			if ( lev2 >= 60 || lev1 >= 60 )
				return 0;
			if ( lev1 < lev2 - 6 )
				return 0;
			if ( lev1 == lev2 - 6 )
				ratio = 0.1f;
			else
				if ( lev1 == lev2 - 5 )
				ratio = 0.25f;
			else
				if ( lev1 == lev2 - 4 )
				ratio = 0.3333f;
			else
				if ( lev1 == lev2 - 3 )
				ratio = 0.5f;
			else
				if ( lev1 == lev2 - 2 )
				ratio = 0.6666f;
			else
				if ( lev1 == lev2 - 1 )
				ratio = 0.75f;	
			else
				if ( lev1 == lev2 )
				ratio = 1f;		
			else
				ratio = 1.1f;
			
			int x = (int)( (float)mobXp[ lev1 ] * ratio );
			Character whoEarn = null;
			if ( this is Character )
				whoEarn = this as Character;
			else
				if ( summonedBy != null )
				whoEarn = summonedBy as Character;

			if ( whoEarn != null )
			{
				if ( whoEarn.GroupMembers != null && whoEarn.GroupMembers.Count > 1 )//	If grouped
				{
					int highest = 0;
					int lev = 0;
					foreach( Member member in whoEarn.GroupMembers.Members )
					{
						int l = member.Char.Level;
						if ( highest < l )
						{
							highest = l;
						}
						lev += l * l * l;
					}
					float rxp = (float)Mobile.mobXp[ highest ];
					float max = (float)lev;
					foreach( Member member in whoEarn.GroupMembers.Members )
					{
						float winxp = ( rxp * (float)( member.Char.Level * member.Char.Level * member.Char.Level ) ) / max;
						x = (int)winxp;
						int offset = 4;
						Converter.ToBytes( member.Char.Guid, tempBuff, ref offset );
						Converter.ToBytes( x, tempBuff, ref offset );
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
						Converter.ToBytes( 0x32, tempBuff, ref offset );
						Converter.ToBytes( (float)1.0f, tempBuff, ref offset );
						member.Char.Send( OpCodes.SMSG_LOG_XPGAIN, tempBuff, offset );
						member.Char.EarnXP( x );
					}
				}
				else
				{
					int offset = 4;
					Converter.ToBytes( m.Guid, tempBuff, ref offset );
					Converter.ToBytes( x, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( 0x32, tempBuff, ref offset );
					Converter.ToBytes( (float)1.0f, tempBuff, ref offset );
					whoEarn.Send( OpCodes.SMSG_LOG_XPGAIN, tempBuff, offset );
					whoEarn.EarnXP( x );
				}
			}
			else
				exp+=(uint)x;
			return x;
		}
		public bool SkillUp( int sk, int diff, double factor )
		{
			if ( diff > 50 )
				return false;
			diff *= diff;
			double proba = 600 / (float)diff;
			proba *= factor;
			if ( Utility.RandomDouble() < proba )
				return true;
			return false;
		}

		public bool SkillUpOld( int sk, int diff, double facteur )
		{
			if ( sk > 300 )
				return false;
			
			double s = (double)sk;		
			s = 300 - s;
			s /= 300;
			s = s * s * s;
			s /= 90;
			
			if ( sk > 270 )
				s *= 8;
			else			
				if ( sk > 250 )
				s *= 4;
			else			
				if ( sk > 225 )
				s *= 2;
			else
				if ( sk > 200 )
				s *= 1.3;	
			else
				if ( sk > 170 )
				s *= 1.1;
			else
				if ( sk > 140 )
				s *= 0.95;	
			else
				if ( sk > 110 )
				s *= 0.80;
			else
				if ( sk > 110 )
				s *= 0.6666;
			else
				if ( sk > 80 )
				s *= 0.5;
			else
				if ( sk > 50 )
				s *= 0.3333;
			else				
				s *= 0.25;
			
			
			if ( diff < -50 )
				s *= 2;
			else
				if ( diff < -25 )
				s *= 1.5;
			else
				if ( diff < 25 )
				s *= 1;
			else
				if ( diff < 50 )
				s *= 0.75;
			else
				if ( diff < 75 )
				s *= 0.5;
			else			
				s *= 0.1;
			
			s *= facteur;
				
			if ( s < 10e-5 )
				s = 10e-5;
#if DEBUG
			//Console.WriteLine("Chance to increase skill {0}", s );
#endif
			if ( Utility.RandomDouble() < s )
				return true;
			return false;
		}
		
		public bool StatUp( int sk, int diff, double facteur )
		{
			if ( sk > 130 )
				return false;
			double s = (double)sk;		
			s = 130 - s;
			s /= 130;
			s = s * s * s;
			s /= 220;
			
			if ( sk < 30 )
				s *= 0.200;
			else
				if ( sk < 50 )
				s *= 0.5;
			else
				if ( sk < 70 )
				s *= 1.5;
			else
				if ( sk < 90 )
				s *= 2;			
			else				
				if ( sk < 100 )
				s *= 5;			
			else
				s *= 0.2;
			
			if ( diff < -50 )
				s *= 2;
			else
				if ( diff < -25 )
				s *= 1.5;
			else
				if ( diff < 25 )
				s *= 1;
			else
				if ( diff < 50 )
				s *= 0.75;
			else
				if ( diff < 75 )
				s *= 0.5;
			else			
				s *= 0.1;	
			
			s *= facteur;
			
			if ( s < 10e-5 )
				s = 10e-5;			
			
			if ( Utility.RandomDouble() < s )
				return true;
			return false;
		}		
		

		#endregion

		#region HANDLER
		/// <summary>
		/// Created by Volhv
		/// </summary>
		public static bool FaceToBehind( Mobile _char, Mobile _creature )
		{
			float a45 = 0.78539816339744830961566084581988f; // .. = pi / 180 * 45 ( 45 grad in radian )
			float v1 = _char.Orientation; // orient vector of character
			float v2 = _creature.Orientation; // orient vector of creature
			float _l = v1 + a45; // -45
			float _r = v1 - a45; // +45
			return ( _l >= v2 && v2 >= _r ) && ( GetDirection( _char, _creature ) == Pos.Behind );
		}
		/// <summary>
		/// Created by Volhv
		/// </summary>
		public enum Pos { Front, Behind }
		/// <summary>
		/// Logic by Nerub
		/// </summary>
		public static Pos GetDirection( Mobile from, Mobile to )
		{
			if ( to == null || from == null )
				return Pos.Behind;
			float dx = to.X - from.X;
			float dy = to.Y - from.Y;
			float angle = (float)Math.Atan2( dy, dx );
			float angleChar = from.Orientation;
			double a1 = Math.Cos( angleChar ) - Math.Cos( angle );
			double a2 = Math.Sin( angleChar ) - Math.Sin( angle );
			a1 *= a1;
			a2 *= a2;
			a1 += a2;
			if ( a1 < 0.77 )
				return Pos.Front;
			return Pos.Behind;
		}
		public void Kill()
		{
			this.LooseHits( this, this.baseHitPoints );
		}
		public void ChannelObject( Object m, int spell )
		{
			uint low = (uint)( m.Guid & 0xffffffff );
			uint high = (uint)( ( m.Guid >> 32 ) & 0xffffffff );
			this.SendSmallUpdateToPlayerNearMe( new int[] {	(int)UpdateFields.UNIT_FIELD_CHANNEL_OBJECT, (int)UpdateFields.UNIT_FIELD_CHANNEL_OBJECT + 1, (int)UpdateFields.UNIT_CHANNEL_SPELL }, new object[] { low, high, spell } );
		}
		/*		public void WaterWalkOn()
				{
					int offset = 4;
					Converter.ToBytes( Guid, tempBuff, ref offset );
					this.ToAllPlayerNear( OpCodes.SMSG_MOVE_LAND_WALK, tempBuff, offset );
				}*/
		public void FeatherFallOn()
		{
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			this.ToAllPlayerNear( OpCodes.SMSG_MOVE_FEATHER_FALL, tempBuff, offset );
		}
		public override bool SeenBy( Character c )
		{	

			 if ( c.Dead )
			{
				if ( (uint)( NpcFlags & (uint)NpcActions.SpiritHealer ) > 0 )
					return true;
				return false;
			}
			if ( (uint)( NpcFlags & (uint)NpcActions.SpiritHealer ) > 0 )
				return false;
			if ( c.Player == null )//	not connected so not seen
				return false;
			#region Visibility spell and gm hide ability
			if ( Visible != InvisibilityLevel.Visible )
			{
				if ( Visible == InvisibilityLevel.True )
					return false;
				if ( Visible == InvisibilityLevel.GM && c.Player.AccessLevel == AccessLevels.PlayerLevel )
					return false;
				if ( Visible == InvisibilityLevel.Lesser )
				{
					if ( !( this.CanSeeLesserInvisibility || 
						this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( Visible == InvisibilityLevel.Medium )
				{
					if ( !( this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( Visible == InvisibilityLevel.Greater )
				{
					if ( !this.CanSeeMediumInvisibility )
						return false;
				}
			}
			#endregion
			if ( c == this )
				return true;	
			if ( MapId != c.MapId || Distance( c ) > 200 * 200 )
				return false;
			if ( Dead )
				return true;			

			return true;
		}
		public bool CharacterNear()
		{
			foreach( Character c in World.allConnectedChars )
			{
				if ( Distance( c ) < 150 * 150 )
				{
					return true;
				}
			}
			return false;
		}
		/*public virtual Object FindObjectByGuid( UInt64 guid )
		{
			return World.FindMobileByGUID( guid );
		}*/
		#endregion

		#region TALENTS
		public virtual void LearnTalent( int num, int lev )
		{
			this.talentList[ num ] = lev;
		}
		public bool HaveTalent( Talents t )
		{
			if ( talentList[ (int)t ] != null )
				return true;
			return false;
		}
		public int TalentLevel( Talents t )
		{
			if ( talentList[ (int)t ] != null )
				return (int)talentList[ (int)t ];
			return 0;
		}
		public BaseAbility GetTalentEffect( Talents t )
		{
			TalentDescription td = (TalentDescription)TalentDescription.all[ (int)t ];
			return (BaseAbility)Abilities.abilities[ td.AuraFXId( (int)talentList[ (int)t ] ) ];
		}
		#endregion

		#region REPUTATION
		static float [,]reactions = new float[ 134, 134 ];
		public static void SetReaction( Factions from, Factions to, float val )
		{
			reactions[ (int)from, (int)to ] = val;
			reactions[ (int)to, (int)from ] = val;
		}
		public static float GetReaction( Factions from, Factions to )
		{
			return reactions[ (int)from, (int)to ];
		}
		public virtual float Reputation( Mobile m )
		{
			if ( m is Character )
			{
				Character ch = (Character)m;
				if ( World.FactionAssociated[ Faction ] != null && ch.ReputationAdjustments[ World.FactionAssociated[ Faction ] ] != null )
				{
					
					int rep = (int)ch.ReputationAdjustments[ World.FactionAssociated[ Faction ] ];
					
					float res = reactions[ (int)m.Faction, (int)Faction ];
					if ( rep >= 0 )
						res += (float)( rep ) / 80000;
					else
						res += (float)( rep ) / 40000;
					if ( res > 1.0f )
						res = 1.0f;
					if ( res < 0f )
						res = 0f;
				//	ch.SendMessage( "Against " + this.Name + " " + rep.ToString() + " / " + res.ToString() );
					return res;
				}
			}
			return reactions[ (int)m.Faction, (int)Faction ];
		}
		public static float[,]Reactions
		{
			get { return reactions; }
		}
		#endregion

		#region DISPOSING SYSTEM
		/*public Object Dispose()
		{
			//Object obj = new Object( Guid, X, Y, Z, Orientation, MapId );
			return obj;
		}*/
		#endregion
	}
}

