using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.World
{
	public enum UNITSTANDSTATE : byte
	{
		STANDING = 0,
		SITTING = 1,
		SITTINGCHAIR = 2,
		SLEEPING = 3,
		SITTINGCHAIRLOW = 4,
		SITTINGCHAIRMEDIUM = 5,
		SITTINGCHAIRHIGH = 6,
		DEAD = 7,
		KNEEL = 8
	};

	public abstract class LivingObject : WorldObject
	{

		[UpdateValueAttribute(UNITFIELDS.FLAGS)]
		protected uint m_flags = 0;
		[UpdateValueAttribute(UNITFIELDS.NPC_FLAGS)]
		protected uint m_npcflags = 0;
		[UpdateValueAttribute(UNITFIELDS.MIN_DAMAGE)]
		protected float m_mindamage = 5f; //testdmgfloat
		[UpdateValueAttribute(UNITFIELDS.MAX_DAMAGE)]
		protected float m_maxdamage = 15f; //testdmgfloat
		[UpdateValueAttribute(UNITFIELDS.COMBATREACH)]
		protected float m_combatreach = 1.25f;

		// taken out since 0.11 Might cause the attack distance bug
		/*[UpdateValueAttribute(UNITFIELDS.WEAPONREACH)]
		protected float m_weaponreach = 1.25f;*/

		[UpdateValueAttribute(UNITFIELDS.AURASTATE)]
		protected int m_aurastate = 1800; //changed to milliseconds
		[UpdateValueAttribute(UNITFIELDS.BASEATTACKTIME)]
		protected int m_baseattacktime = 2000; //changed to milliseconds
		[UpdateValueAttribute(UNITFIELDS.BASEATTACKTIME1)]
		protected int m_baseattacktime1 = 2000;
		[UpdateValueAttribute(UNITFIELDS.BOUNDINGRADIUS)]
		protected float m_boundingradius = 0.7f;
		[UpdateValueAttribute(UNITFIELDS.MOUNT_DISPLAYID)]
		protected int m_mountDisplayID = 0;
		//[UpdateValueAttribute(UNITFIELDS.NATIVE_DISPLAYID)] // tester
		//protected int m_nativeDisplayID = 54; // test data
		[UpdateValueAttribute(UNITFIELDS.BYTES_1, BytesIndex=0)]
		protected UNITSTANDSTATE m_standState = 0;
		[UpdateValueAttribute(UNITFIELDS.DYNAMIC_FLAGS)]
		protected uint m_dynamic_flags = 0;
		protected int m_spawnID = 0;
		protected bool m_roaming = false;
		protected bool m_attacking = false;
		protected bool m_dead = false;
		protected bool m_inRound = false;

		public bool Attacking
		{
			get {return m_attacking;}
			set {m_attacking = value;}
		}

		public bool Dead
		{
			get {return m_dead;}
			set {m_dead = value;}
		}
		
		public bool Roaming
		{
			get {return m_roaming;}
			set {m_roaming = value;}
		}

		public bool InRound
		{
			get {return m_inRound;}
			set {m_inRound = value;}
		}

		public LivingObject() : base()
		{

		}

		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject(isClient);

			UpdateValue(UNITFIELDS.HEALTH);
			UpdateValue(UNITFIELDS.MAX_HEALTH);
			UpdateValue((UNITFIELDS)((int)(UNITFIELDS.POWER0))+(int)PowerType);
			UpdateValue((UNITFIELDS)((int)(UNITFIELDS.MAX_POWER0))+(int)PowerType);
			UpdateValue(UNITFIELDS.LEVEL);
			UpdateValue(UNITFIELDS.FACTION);
			UpdateValue(UNITFIELDS.DISPLAYID);
			UpdateValue(UNITFIELDS.NATIVE_DISPLAYID);
			UpdateValue(UNITFIELDS.MOUNT_DISPLAYID);
			UpdateValue(UNITFIELDS.BYTES_0);
			UpdateValue(UNITFIELDS.BYTES_1);
			UpdateValue(UNITFIELDS.FLAGS);
			UpdateValue(UNITFIELDS.NPC_FLAGS);
			UpdateValue(UNITFIELDS.BASEATTACKTIME);
			UpdateValue(UNITFIELDS.BASEATTACKTIME1);
			UpdateValue(UNITFIELDS.MAX_DAMAGE);
			UpdateValue(UNITFIELDS.MIN_DAMAGE);
			UpdateValue(UNITFIELDS.COMBATREACH);
			//UpdateValue(UNITFIELDS.WEAPONREACH); // removed for 0.11
			UpdateValue(UNITFIELDS.BOUNDINGRADIUS);
			//UpdateValue(UNITFIELDS.MOUNT_DISPLAYID);

			if(isClient)
			{
			}
		}

		public abstract string Name
		{
			get;
		}

		#region UNITFIELDS
		[UpdateValueAttribute(UNITFIELDS.HEALTH)]
		public abstract int Health
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.MAX_HEALTH)]
		public abstract int MaxHealth
		{
			get;
			set;
		}
		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=3)]
		public abstract POWERTYPE PowerType
		{
			get;
			set;
		}
		
		[UpdateValueAttribute(UNITFIELDS.POWER0)] //TESTER
		[UpdateValueAttribute(UNITFIELDS.MANA)]
		[UpdateValueAttribute(UNITFIELDS.RAGE)]
		[UpdateValueAttribute(UNITFIELDS.FOCUS)]
		[UpdateValueAttribute(UNITFIELDS.ENERGY)]
		public abstract int Power
		{
			get;
			set;
		}
        
		[UpdateValueAttribute(UNITFIELDS.MAX_POWER0)] //TESTER
		[UpdateValueAttribute(UNITFIELDS.MAX_MANA)]
		[UpdateValueAttribute(UNITFIELDS.MAX_RAGE)]
		[UpdateValueAttribute(UNITFIELDS.MAX_FOCUS)]
		[UpdateValueAttribute(UNITFIELDS.MAX_ENERGY)]
		public abstract int MaxPower
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.LEVEL)]
		public abstract int Level
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.FACTION)]
		public abstract int Faction
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.DISPLAYID)]
		public abstract int DisplayID
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.NATIVE_DISPLAYID)]
		public abstract int nativeDisplayID
		{
			get;
			set;
		}

		[UpdateValueAttribute(UNITFIELDS.TARGET)]
		public abstract ulong Target
		{
			get;
			set;
		}

		public int Spawn_ID
		{
			get { return m_spawnID;}
			set {m_spawnID = value;}
		}

		public int MountDisplayID
		{
			get { return m_mountDisplayID;}
			set { m_mountDisplayID = value; UpdateValue(UNITFIELDS.MOUNT_DISPLAYID);}
		}

		/*public int NativeDisplayID
		{
			get { return m_nativeDisplayID;}
			set { m_nativeDisplayID = value; UpdateValue(UNITFIELDS.NATIVE_DISPLAYID);}
		}*/

		public uint Flags
		{
			get { return m_flags;}
			set { m_flags = value; UpdateValue(UNITFIELDS.FLAGS);}
		}

		public uint NPC_Flags
		{
			get { return m_npcflags;}
			set { m_npcflags = value; UpdateValue(UNITFIELDS.NPC_FLAGS);}
		}

		public float MinDamage
		{
			get { return m_mindamage;}
			set { m_mindamage = value; UpdateValue(UNITFIELDS.MIN_DAMAGE);}
		}

		public float MaxDamage
		{
			get { return m_maxdamage;}
			set { m_maxdamage = value; UpdateValue(UNITFIELDS.MAX_DAMAGE);}
		}

		public float CombatReach
		{
			get { return m_combatreach;}
			set { m_combatreach = value; UpdateValue(UNITFIELDS.COMBATREACH);}
		}
		/* Taken out for 0.11
		public float WeaponReach
		{
			get { return m_weaponreach;}
			set { m_weaponreach = value; UpdateValue(UNITFIELDS.WEAPONREACH);}
		}*/

		public int AuraState
		{
			get { return m_aurastate;}
			set { m_aurastate = value; UpdateValue(UNITFIELDS.AURASTATE);}
		}

		public int BaseAttackTime
		{
			get { return m_baseattacktime;}
			set { m_baseattacktime = value; UpdateValue(UNITFIELDS.BASEATTACKTIME);}
		}

		public int BaseAttackTime1
		{
			get { return m_baseattacktime1;}
			set { m_baseattacktime1= value; UpdateValue(UNITFIELDS.BASEATTACKTIME1);}
		}

		public float BoundingRadius
		{
			get { return m_boundingradius;}
			set { m_boundingradius= value; UpdateValue(UNITFIELDS.BOUNDINGRADIUS);}
		}

		public UNITSTANDSTATE StandState
		{
			get { return m_standState;}
			set { m_standState = value; UpdateValue(UNITFIELDS.BYTES_1);}
		}

		public uint DynamicFlags
		{
			get { return m_dynamic_flags; }
			set { m_dynamic_flags = value; UpdateValue(UNITFIELDS.DYNAMIC_FLAGS);}
		}

		#endregion


		#region PLAYERFIELDS

		public abstract int Resist_Physical
		{
			get;
			set;
		}

		public abstract int Resist_Holy
		{
			get;
			set;
		}

		public abstract int Resist_Fire
		{
			get;
			set;
		}

		public abstract int Resist_Nature
		{
			get;
			set;
		}

		public abstract int Resist_Frost
		{
			get;
			set;
		}

		public abstract int Resist_Shadow
		{
			get;
			set;
		}

		public abstract int BaseStrength
		{
			get;
			set;
		}

		public abstract int BaseAgility
		{
			get;
			set;
		}

		public abstract int BaseStamina
		{
			get;
			set;
		}

		public abstract int BaseIntellect
		{
			get;
			set;
		}

		public abstract int BaseSpirit
		{
			get;
			set;
		}


		public abstract int Strength
		{
			get;
			set;
		}

		public abstract int Agility
		{
			get;
			set;
		}

		public abstract int Stamina
		{
			get;
			set;
		}

		public abstract int Intellect
		{
			get;
			set;
		}

		public abstract int Spirit
		{
			get;
			set;
		}

		public abstract int AttackPower
		{
			get;
			set;
		}

		public abstract int AttackPowerModifier
		{
			get;
			set;
		}

		public abstract int Money
		{
			get;
			set;
		}

		public abstract int SkillPoints
		{
			get;
			set;
		}

		public abstract int TalentPoints
		{
			get;
			set;
		}

		public abstract uint GuildID
		{
			get;
			set;
		}

		public abstract uint GuildRank
		{
			get;
			set;
		}

		public abstract uint GuildTimeStamp
		{
			get;
			set;
		}

		#endregion
	}
}
