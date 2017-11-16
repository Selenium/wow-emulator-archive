using System;
using System.Collections;
using HelperTools;
using System.Reflection;

namespace Server.Items
{
	#region ENUMS
	public enum Attributes
	{
		Strenght = 4,
		Agility = 3,
		Iq = 6,
		Spirit = 5,
		Stamina = 7,
		Mana = 0,
		Health = 1
	}
	public enum InventoryTypes : int 
	{
		None			= 0,
		Head			= 1,
		Neck			= 2,
		Shoulder		= 3,
		Shirt			= 4,
		Chest			= 5,
		Waist			= 6,
		Legs			= 7,
		Feet			= 8,
		Wrist			= 9,
		Hands			= 10,
		Finger			= 11,
		Trinket1		= 12,
		MainGauche		= 13,
		Shield			= 14,
		Ranged			= 15,
		Back			= 16,
		TwoHanded		= 17,
		Junk			= 18,
		Bag				= 18,
		Tabard			= 19,
		Robe			= 20,
		OneHand			= 21,
		OffHand			= 22,
		HeldInHand		= 23,
		Projectile		= 24,
		Thrown			= 25,
		RangeRight		= 26
	};
	public enum Slots : int
	{
		None		= -1,
		Head		=	0,
		Neck		=	1,
		Shoulders	=	2,
		Shirt		=	3,
		Chest		=	4,
		Waist		=	5,
		Legs		=	6,
		Feet		=	7,
		Wrists		=	8,
		Hands		=	9,
		FingerLeft	=	10,
		FingerRight	=	11,
		TrinketLeft	=	12,
		TrinketRight=	13,
		Back		=	14,
		MainHand	=	15,
		OffHand		=	16,
		Ranged		=	17,
		Tabard		=	18,
		Bag1		=	19,
		Bag2		=	20,
		Bag3		=	21,
		Bag4		=	22,
		Bag5		=	23
	}

	#endregion
	/// <summary>
	/// Description of Item.	
	/// </summary>
	public class Item : Object
	{
		string name;
		string name2;
		int id;
	//	Slots canBeEquipedIn;
		//	Slots equipedIn;
		int buyPrice;
		int sellPrice;
		int containerSlots;
		InventoryTypes inventoryType;
		int availableClasses;
		int availableRaces;
		int objectClass;
		int level;
		int quality;
		int model;
		int subClass;
		int reqLevel;
		int stackable;		
		int material;
		int []resistance = new int[ 7 ];
		int bonding;
		int flags;
		//int bonus;
		int maxCount;
		int skillRank;
		int pageText;
		int extra;
		int ammoType;
		int startQuest;
		int pageMaterial;
		int lockId = 0x700;
		int sets;
		int spellreq;
		string questName;
		int skill;
		int durability;
		string description;
		int language;
		float minDamage;
		float maxDamage;
		int delay;
		int sheath;
		int unk1;
		int block;
		int minBonus;
		int maxBonus;
		int nSpellAbility = 0;
		SpecialAbility []spells = new SpecialAbility[ 5 ];
		//Slots toRemoveFrom = Slots.None;
		int strBonus = 0;
		int iqBonus = 0;
		int spiritBonus = 0;
		int agilityBonus = 0;
		int staminaBonus = 0;
		int manaBonus = 0;
		int healthBonus = 0;

		ItemDamage []itemDamages = new ItemDamage[ 7 ];


		//	Partie dynamique
		ConstructorInfo quickConstructor;

		public class ItemDamage
		{
			float minDamage;
			float maxDamage;

			public ItemDamage()
			{
			}
			public ItemDamage( float min, float max )
			{
				minDamage = min;
				maxDamage = max;
			}
			public float MinDamage
			{
				get { return minDamage; }
			}
			public float MaxDamage
			{
				get { return maxDamage; }
			}
		}
		public class SpecialAbility
		{
			int id;
			int trigger;
			int charges;
			int cooldown;
			int category;
			int categoryCooldown;
			Aura aura;
			float proba;

			public SpecialAbility( int p1, int p2, int p3, int p4, int p5, int p6, float prob )
			{
				id = p1;
				trigger = p2;
				charges = p3;
				cooldown = p4;
				category = p5;
				categoryCooldown = p6;
				proba = prob;
			}
			public SpecialAbility( int p1, int p2, int p3, int p4, int p5, int p6 )
			{
				id = p1;
				trigger = p2;
				charges = p3;
				cooldown = p4;
				category = p5;
				categoryCooldown = p6;
				proba = 1f;
			}
			public void PrepareData( byte []data, ref int offset )
			{
				Converter.ToBytes( id, data, ref offset );
				Converter.ToBytes( trigger, data, ref offset );
				Converter.ToBytes( charges, data, ref offset );
				Converter.ToBytes( cooldown, data, ref offset );
				Converter.ToBytes( category, data, ref offset );
				Converter.ToBytes( categoryCooldown, data, ref offset );
			}
			public float Proba
			{
				get { return proba; }
			}
			public int Trigger
			{
				get { return trigger; }
			}
			public BaseAbility Spell
			{
				get { return Abilities.abilities[ id ]; }
			}
			public Aura ActiveAura
			{
				get { return aura; }
				set { aura = value; }
			}

		}


		#region ACCESSORS
		public bool IsWeapon
		{
			get 
			{
				if ( ( objectClass == 2 ) )
					return true;
				return false;
			}
		}
		public bool IsQuestItem
		{
			get 
			{
				if ( ( objectClass == 7 || objectClass == 12 || objectClass == 15 ) && subClass == 0 )
					return true;
				return false;
			}
		}
		public bool IsContainer
		{
			get { if ( containerSlots > 0 ) return true;return false; }
		}
		public Slots CanBeEquipedIn
		{
			get 
			{ 
				if ( inventoryType > 0 )
				{
					switch( (InventoryTypes)InventoryType )
					{
						case InventoryTypes.Head: return Slots.Head; 
						case InventoryTypes.Neck: return Slots.Neck;  
						case InventoryTypes.Shoulder: return Slots.Shoulders;  
						case InventoryTypes.Shirt: return Slots.Shirt;  
						case InventoryTypes.Chest: return Slots.Chest; 
						case InventoryTypes.Waist: return Slots.Waist; 
						case InventoryTypes.Legs: return Slots.Legs;  
						case InventoryTypes.Feet: return Slots.Feet;  
						case InventoryTypes.Wrist: return Slots.Wrists; 
						case InventoryTypes.Hands: return Slots.Hands;  
						case InventoryTypes.Finger: return Slots.FingerLeft;  
						case InventoryTypes.Trinket1: return Slots.TrinketLeft;  
						case InventoryTypes.Robe:return Slots.Chest;  
						case InventoryTypes.Back: 
							return Slots.Back;  

						case InventoryTypes.OneHand:
						case InventoryTypes.TwoHanded:
							return Slots.MainHand;  

						case InventoryTypes.OffHand:
						case InventoryTypes.MainGauche:
						case InventoryTypes.Shield:
							return Slots.OffHand; 

						case InventoryTypes.Ranged: 
						case InventoryTypes.RangeRight: 
						case InventoryTypes.Thrown:
							return Slots.Ranged;  

						case InventoryTypes.Tabard: return Slots.Tabard;  
					}
				}
				return Slots.None;
			}
		}
		/*public Slots ToRemoveFrom
		{
			get { return toRemoveFrom; }
			set { toRemoveFrom = value; }
		}*/
		public bool IsShield
			{
				get 
				{ 
					if ( ObjectClass == 4 && SubClass == 6 ) 
						  return true;
				return false;
				}
			}
		public int StrBonus
		{
			get { return strBonus; }
			set { strBonus = value; }
		}
		public int IqBonus
		{
			get { return iqBonus; }
			set { iqBonus = value; }
		}
		public int SpiritBonus
		{
			get { return spiritBonus; }
			set { spiritBonus = value; }
		}
		public int AgilityBonus
		{
			get { return agilityBonus; }
			set { agilityBonus = value; }
		}
		public int StaminaBonus
		{
			get { return staminaBonus; }
			set { staminaBonus = value; }
		}
		public int ManaBonus
		{
			get { return manaBonus; }
			set { manaBonus = value; }
		}
		public int HealthBonus
		{
			get { return healthBonus; }
			set { healthBonus = value; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public void SetDamage( float min, float max, Resistances res )
		{
			itemDamages[ (int)res ] = new ItemDamage( min, max );
		}
		public float PhysicalMinDamage
		{
			get 
			{ 
				if ( itemDamages[ (int)Resistances.Armor ] == null )
				{
					Console.WriteLine("The object {0} do not have physical damage, please contact DrNexus !!!!!", this.ToString() );
					return 1;
				}
				return itemDamages[ (int)Resistances.Armor ].MinDamage; 
			}
		}
		public float PhysicalMaxDamage
		{
			get 
			{ 
				if ( itemDamages[ (int)Resistances.Armor ] == null )
				{
					Console.WriteLine("The object {0} do not have physical damage, please contact DrNexus !!!!!", this.ToString() );
					return 1;
				}
				return itemDamages[ (int)Resistances.Armor ].MaxDamage; 
			}
		}
		public void SetBonus( int min, int max )
		{
			minBonus = min;
			maxBonus = max;
		}
		public SpecialAbility Spells( int n )
		{
			return spells[ n ];
		}
		public void SetSpell( int p1, int p2, int p3, int p4, int p5, int p6  )
		{
			spells[ nSpellAbility++ ] = new SpecialAbility( p1, p2, p3, p4, p5, p6, 1f );
		}
		public void SetSpell( int p1, int p2, int p3, int p4, int p5, int p6, float prob  )
		{
			spells[ nSpellAbility++ ] = new SpecialAbility( p1, p2, p3, p4, p5, p6, prob );
		}
		public int Block 
		{
			get { return block; }
			set { block = value; }
		}
		public int Unk1 
		{
			get { return unk1; }
			set { unk1 = value; }
		}
		public int Delay 
		{
			get { return delay; }
			set { delay = value; }
		}
		public int Sheath 
		{
			get { return sheath; }
			set { sheath = value; }
		}
		public int Language 
		{
			get { return language; }
			set { language = value; }
		}
		public int Durability 
		{
			get { return durability; }
			set { durability = value; }
		}
		public int Skill 
		{
			get { return skill; }
			set { skill = value; }
		}
		public string Description 
		{
			get { return description; }
			set { description = value; }
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
		public int SpellReq 
		{
			get { return spellreq; }
			set { spellreq = value; }
		}
		public string QuestName 
		{
			get { return questName; }
			set { questName = value; }
		}
		public int PageMaterial 
		{
			get { return pageMaterial; }
			set { pageMaterial = value; }
		}
		public int LockId 
		{
			get { return lockId; }
			set { lockId = value; }
		}
		public int Sets 
		{
			get { return sets; }
			set { sets = value; }
		}

		public int PageText 
		{
			get { return pageText; }
			set { pageText = value; }
		}
		public int AmmoType 
		{
			get { return ammoType; }
			set { ammoType = value; }
		}
		public int StartQuest 
		{
			get { return startQuest; }
			set { startQuest = value; }
		}

		public int MaxCount 
		{
			get { return maxCount; }
			set { maxCount = value; }
		}
		public int SkillRank 
		{
			get { return skillRank; }
			set { skillRank = value; }
		}
		public int Extra 
		{
			get { return extra; }
			set { extra = value; }
		}

		public InventoryTypes InventoryType 
		{
			get { return inventoryType; }
			set { inventoryType = value; }
		}
		public int Bonding 
		{
			get { return bonding; }
			set { bonding = value; }
		}
		public int Flags 
		{
			get { return flags; }
			set { flags = value; }
		}
	/*	public int Bonus 
		{
			get { return bonus; }
			set { bonus = value; }
		}*/

		public int []Resistance 
		{
			get { return resistance; }
			set { resistance = value; }
		}
		public int BuyPrice 
		{
			get { return buyPrice; }
			set { buyPrice = value; }
		}
		public int SellPrice 
		{
			get { return sellPrice; }
			set { sellPrice = value; }
		}
		public int ContainerSlots 
		{
			get { return containerSlots; }
			set { containerSlots = value; }
		}
	/*	public int Inventorytype 
		{
			get { return Inventorytype; }
			set { Inventorytype = value; }
		}*/
		public int AvailableClasses 
		{
			get { return availableClasses; }
			set { availableClasses = value; }
		}
		public int AvailableRaces 
		{
			get { return availableRaces; }
			set { availableRaces = value; }
		}
		public int ObjectClass 
		{
			get { return objectClass; }
			set { objectClass = value; }
		}
		public int Level 
		{
			get { return level; }
			set { level = value; }
		}
		public int Quality 
		{
			get { return quality; }
			set { quality = value; }
		}
		public int Model 
		{
			get { return model; }
			set { model = value; }
		}
		public int SubClass 
		{
			get { return subClass; }
			set { subClass = value; }
		}
		public int ReqLevel 
		{
			get { return reqLevel; }
			set { reqLevel = value; }
		}
		public int Stackable 
		{
			get { return stackable; }
			set { stackable = value; }
		}
		public int Material 
		{
			get { return material; }
			set { material = value; }
		}	

		#endregion

		#region SERIALISATION
		public static Item Load( GenericReader gr )
		{
			string cl = gr.ReadString();
			ConstructorInfo ct = Utility.FindConstructor( cl, Utility.externAsm[ "Items" ] );
			if ( ct == null )
			{
				Console.WriteLine( "Invalid item : {0}", cl );
				return null;
			}
			object o = ct.Invoke( null );
			if ( !( o is Item ) )
			{
				Console.WriteLine( "Invalid item : {0}", cl );
				return null;
			}
			Item s = (Item)o;
			s.Deserialize( gr, true );
			return s;
		}
		void Deserialize( GenericReader gr, bool fake )
		{
			int version = gr.ReadInt();
			Guid = (UInt64)gr.ReadInt64();
			maxCount = gr.ReadInt();
		}
		public override void Serialize( GenericWriter gw )
		{
			gw.Write( Utility.ClassName( this ) );
			gw.Write( (int)0 );
			gw.Write( Guid );
			gw.Write( maxCount );
		}
		#endregion

		public static Hashtable skillIdAssoc = new Hashtable();
		public int GetSkillId()
		{
			object o = skillIdAssoc[ objectClass * 100 + subClass ];
			if ( o == null )
				return 0;
			return (int)o;
		}

		public static Slots SlotNum( byte a, byte b )
		{
			int pl = 0;
			if ( a == (byte)0xff )
				pl = b;
			else
			{
				pl = b + 24 + 16 + ( ( a - 19 ) * 16 );
			}
			return (Slots)pl;
		}

		#region CONSTRUCTORS
		public Item()
		{			
			Type type =  this.GetType();
			ConstructorInfo[] quickConstructors = type.GetConstructors();
			quickConstructor = quickConstructors[ 0 ];
			Guid = Object.GUID++ + 0x4000000000000000;
		}

		public Item( int _model, InventoryTypes _inventoryType, int _objectclass, int _subclass, int _quality, int _sheath, int param1, int param2, int param3 )
		//public Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 )
		{
			model = _model;
			inventoryType = _inventoryType;
			quality = _quality;
			subClass = _subclass;
			objectClass = _objectclass;
			sheath = _sheath;
		}

		public Item( Type type, int pos )
		{
			
		}

		public Item Clone()
		{
			return (Item)quickConstructor.Invoke( null );
		}

		
		/*

				public bool Equip( Mobile m, Slots s )
				{
					equipedIn = s;
					return true;
				}

				public bool UnEquip( Mobile m )
				{
					equipedIn = Slots.Bag1;
					return true;
				}*/

		#endregion

		#region UPDATE
//01 00 00 00 00 00 1F 37 21 00 00 00 00 00 06 
	//	00 00 40 00 00 40 00 00 00 00 00 00 00 00 00 00 00 00 10 00 00 00 00 00 00 00 00 00 00 40 00 00 01 00 00 00
		public void SendTinyUpdate( int []pos, object []val, Character c )
		{
			int offset = 4;
			byte []tempBuff = new byte[ 128 ];
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)0x2;
		//	Buffer.BlockCopy( Object.Blank8, 0, tempBuff, offset, Object.Blank26.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += 8;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			//	for(int t = 0;t < offset;t++ )
			//		Console.Write("{0} ", tempBuff[ t ].ToString( "X2" ) );

			c.Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public void SendSmallUpdate( int []pos, object []val, Character c )
		{
			int offset = 4;
			byte []tempBuff = c.tempBuff;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x24 )
				max = 0x24;
			tempBuff[ offset++ ] = (byte)max;
			Buffer.BlockCopy( Object.Blank26, 0, tempBuff, offset, Object.Blank26.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
		//	for(int t = 0;t < offset;t++ )
		//		Console.Write("{0} ", tempBuff[ t ].ToString( "X2" ) );

			c.Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}

		public void PrepareUpdateData( byte []data, ref int offset, UpdateType type, Character owner )
		{
			
#if TESTCONSECUTIF
			Object.order = 0;
#endif
			
			int start = offset;
			data[ offset++ ] = (byte)UpdateType.UpdateFull;			
			Converter.ToBytes( Guid, data, ref offset );

			if ( IsContainer )
				Converter.ToBytes( (byte)2, data, ref offset );//	type A9 = 1
			else
				Converter.ToBytes( (byte)1, data, ref offset );//	type A9 = 1
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			Converter.ToBytes( 0f, data, ref offset );
			Converter.ToBytes( 0f, data, ref offset );
			Converter.ToBytes( 0f, data, ref offset );
			Converter.ToBytes( 0f, data, ref offset );//	Orientation
			Converter.ToBytes( 0f, data, ref offset );
			//Converter.ToBytes( 0f, data, ref offset );
			Converter.ToBytes( 2.5f, data, ref offset );
			Converter.ToBytes( 7.0f, data, ref offset );
			Converter.ToBytes( 2.5f, data, ref offset );
			Converter.ToBytes( 4.7222f, data, ref offset );
			Converter.ToBytes( (float)4.5f, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );//	NPC type
			Converter.ToBytes( (uint)1, data, ref offset );//	NPC type			

			Converter.ToBytes( (uint)0, data, ref offset );//	vide	
			Converter.ToBytes( (uint)0, data, ref offset );//	vide	
			Converter.ToBytes( (uint)0, data, ref offset );//	vide	
			//offset += 0xc;

			int last = 0;
			ResetBitmap();
			setUpdateValue( (int)UpdateFields.OBJECT_FIELD_GUID, Guid );

			if ( IsContainer )
			{
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_TYPE, 7 );
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_ENTRY, (int)Id );
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_SCALE_X, 1f );
				setUpdateValue( (int)UpdateFields.ITEM_FIELD_OWNER, owner.Guid );
				setUpdateValue( (int)UpdateFields.ITEM_FIELD_CONTAINED, owner.Guid );
				setUpdateValue( (int)UpdateFields.ITEM_FIELD_STACK_COUNT, MaxCount );
				//setUpdateValue( (int)UpdateFields.ITEM_FIELD_FLAGS, flags );
				setUpdateValue( last = (int)UpdateFields.CONTAINER_FIELD_NUM_SLOTS, containerSlots );
				for(int t = 19;t < 23;t++ )
					if ( owner.Items[ t ] == this )
					{
						int st = ( ( t - 19 ) * 16 ) + 40;
						for(int i = 0; i < 16;i++ )
							if ( owner.Items[ st + i ] != null )
								setUpdateValue( last = (int)UpdateFields.CONTAINER_FIELD_SLOT_1 + i * 2, owner.Items[ i + st ].Guid );
					}
			}
			else
			{
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_TYPE, 3 );
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_ENTRY, (int)Id );
				setUpdateValue( (int)UpdateFields.OBJECT_FIELD_SCALE_X, 1f );
				setUpdateValue( (int)UpdateFields.ITEM_FIELD_OWNER, owner.Guid );
				setUpdateValue( (int)UpdateFields.ITEM_FIELD_CONTAINED, owner.Guid );
				setUpdateValue( last = (int)UpdateFields.ITEM_FIELD_STACK_COUNT, MaxCount );
			//	setUpdateValue( last = (int)UpdateFields.ITEM_FIELD_FLAGS, flags );
			}
			FlushUpdateData( data, ref offset, ( last / 32 ) + 2 );
			
		}
	
/*
		public static void ViewItem( string a )
		{
			string []spl = a.Split( new char[]{ ' ' } );
			byte []b = new byte[ spl.Length ];
			int t = 0;
			
			foreach( string s in spl )
			{
				if ( s.Length == 0 )
					continue;
				b[ t++ ] = Convert.ToByte( s, 16 );				
			}
			ViewItem( b );
		}
		public static void ViewItem( byte []b )
		{
			//string a = "4D 03 00 00 04 00 00 00 02 00 00 00 54 61 6E 6E 65 64 20 4C 65 61 74 68 65 72 20 50 61 6E 74 73 00 00 00 00 A8 25 00 00 01 00 00 00 00 00 00 00 A7 05 00 00 21 01 00 00 07 00 00 00 FF 7F 00 00 FF 01 00 00 11 00 00 00 0C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 3C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 08 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 32 00 00 00";
			//string a = "1D 0B 00 00 02 00 00 00 00 00 00 00 43 6F 70 70 65 72 20 41 78 65 00 00 00 00 D3 36 00 00 01 00 00 00 00 00 00 00 22 02 00 00 6D 00 00 00 15 00 00 00 FF 7F 00 00 FF 01 00 00 09 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 A0 40 00 00 20 41 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 6C 07 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 23 00 00 00";
			
			//	string a = "9A 09 00 00 00 00 00 00 00 00 00 00 45 6C 69 78 69 72 20 6F 66 20 4D 69 6E 6F 72 20 46 6F 72 74 69 74 75 64 65 00 00 00 00 B0 3D 00 00 01 00 00 00 00 00 00 00 3C 00 00 00 0F 00 00 00 00 00 00 00 FF 7F 00 00 FF 01 00 00 0C 00 00 00 02 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 05 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 4A 09 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 4F 00 00 00 B8 0B 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00";			
		
		
			//string a = "DC 14 00 00 02 00 00 00 0A 00 00 00 43 61 75 6C 64 72 6F 6E 20 53 74 69 72 72 65 72 00 00 00 00 C1 4F 00 00 02 00 00 00 00 00 00 00 F4 11 00 00 97 03 00 00 11 00 00 00 FF 7F 00 00 FF 01 00 00  0F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  01 00 00 00 00 00 00 00 07 00 00 00 04 00 00 00  FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00  FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00  FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00  FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00  FF FF FF FF 00 00 00 00 00 00 C8 41 00 00 18 42 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  1C 0C 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00  00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF  00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF  00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF FF  01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 02 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 37 00 00 00";

			//string a = "A1 29 00 00 04 00 00 00 01 00 00 00 54 61 6C 62  61 72 20 4D 61 6E 74 6C 65 00 00 00 00 17 4E 00  00 02 00 00 00 00 00 00 00 3D 12 00 00 A5 03 00  00 03 00 00 00 FF 7F 00 00 FF 01 00 00 1A 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00  00 00 00 00 00 05 00 00 00 06 00 00 00 07 00 00  00 03 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF  FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF  FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF  FF 00 00 00 00 FF FF FF FF 00 00 00 00 FF FF FF  FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 1E 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00  00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00  00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00  00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00  00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00  00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00  00 FF FF FF FF 00 00 00 00 FF FF FF FF 01 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 07 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 28 00 00 00"; 

			//string a = "9B 04 00 00 00 00 00 00 00 00 00 00 49 63 65 20 43 6F 6C 64 20 4D 69 6C 6B 00 00 00 00 AA 46 00 00 01 00 00 00 00 00 00 00 7D 00 00 00 06 00 00 00 00 00 00 00 FF 7F 00 00 FF 01 00 00 0F 00 00  00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 14 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 AF 01 00 00 00 00 00 00 FF FF FF  FF 00 00 00 00 3B 00 00 00 E8 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00  00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00  00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00  00 00 00 00 00 00 00 00 00 FF FF FF FF 00 00 00  00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00  00 FF FF FF FF 00 00 00 00 FF FF FF FF 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 07 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00";

			int offset = 0;
			Console.WriteLine( "id = {0}", BitConverter.ToInt32( b, offset ) );offset+=4;
			Console.WriteLine( "Classe = {0}",  BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "subClass = {0}",  BitConverter.ToInt32( b, offset ));offset+=4;
			string name1 = "";
			for(int k = offset;b[ k ] != 0;k++, offset++ )
				name1 += "" + (char)b[ k ];
			offset++;		
			string name2 = "";
			for(int k = offset;b[ k ] != 0;k++, offset++ )
				name2 += "" + (char)b[ k ];
			offset++;		
			string name3 = "";
			for(int k = offset;b[ k ] != 0;k++, offset++ )
				name3 += "" + (char)b[ k ];
			offset++;		
			string name4 = "";
			for(int k = offset;b[ k ] != 0;k++, offset++ )
				name4 += "" + (char)b[ k ];
			offset++;		
			Console.WriteLine("{0},{1},{2},{3}", name1, name2, name3, name4 );
			Console.WriteLine( "displayInfoID =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "OverallQualityID =  {0}", BitConverter.ToInt32( b, offset) );offset+=4;
			Console.WriteLine( "Flags =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Buyprice =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Sellprice =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
		

			//Console.WriteLine( "displayInfoID =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Inventorytype =  {0}", BitConverter.ToInt32( b, offset) );offset+=4;
			Console.WriteLine( "AllowableClass =  {0}", BitConverter.ToInt32( b, offset ).ToString( "X8" ));offset+=4;
			Console.WriteLine( "AllowableRace =  {0}", BitConverter.ToInt32( b, offset ).ToString( "X8" ));offset+=4;
			Console.WriteLine( "ItemLevel =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			
			Console.WriteLine( "RequiredLevel =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "RequiredSkill =  {0}", BitConverter.ToInt32( b, offset) );offset+=4;
			Console.WriteLine( "RequiredSkillRank =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Unk0 =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Unk1 =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;			
			Console.WriteLine( "Unk2 =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "MaxCount =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Stackable =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;			
			Console.WriteLine( "ContainerSlots =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;			
		  
			
			for(int i = 0; i<10; i++)
			{
				Console.WriteLine( "BonusStat{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
				Console.WriteLine( "BonusAmount{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
			}
			for(int i = 0; i<5; i++) 
			{
				Console.WriteLine( "MinimumDamage{0} =  {1}", i,  BitConverter.ToSingle( b, offset ));offset+=4;
				Console.WriteLine( "MaximumDamage{0} =  {1}", i,  BitConverter.ToSingle( b, offset ));offset+=4;				
				Console.WriteLine( "DamageType{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
			}
			Console.WriteLine( "Armor =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;						
			Console.WriteLine( "UnknResistance =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Resistance Fire =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Resistance nature =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Resistance frost =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Resistance shadow =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Resistance arcane =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Delay =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "AmmunitionType =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;			
			for(int i = 0; i<5; i++) 
			{
				Console.WriteLine( "SpellID{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
				Console.WriteLine( "SpellTrigger{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;				
				Console.WriteLine( "SpellCharges{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
				Console.WriteLine( "SpellCooldown{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;
				Console.WriteLine( "SpellCategory{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;				
				Console.WriteLine( "SpellCategoryCooldown{0} =  {1}", i,  BitConverter.ToInt32( b, offset ));offset+=4;				
			}
			Console.WriteLine( "Bonding =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;		
			if ( b[ offset ] != 0 )
			{
				string desc = "";
				for(int k = offset;b[ k ] != 0;k++, offset++ )
					desc += "" + (char)b[ k ];
				offset++;					
			}
			else
				offset+=4;
			Console.WriteLine( "Pagetext =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "LanguageID =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "PageMaterial =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "StartQuestID =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "LockID =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Material =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Sheathetype = {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "AmmunitionType =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;			
			Console.WriteLine( "Unk0 =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;
			Console.WriteLine( "Unk1 =  {0}", BitConverter.ToInt32( b, offset ));offset+=4;	

                			  
		}
*/

		public void PrepareData( byte []data, ref int offset )
		{
			Converter.ToBytes( id, data, ref offset );
			Converter.ToBytes( objectClass, data, ref offset );
			Converter.ToBytes( subClass, data, ref offset );
			Converter.ToBytes( name, data, ref offset );
			Converter.ToBytes( (byte)0, data, ref offset );
			if ( name2 != null )
				Converter.ToBytes( name2, data, ref offset );
			else
				Converter.ToBytes( "", data, ref offset );
			Converter.ToBytes( (byte)0, data, ref offset );
			Converter.ToBytes( "", data, ref offset );
			Converter.ToBytes( (byte)0, data, ref offset );
			Converter.ToBytes( "", data, ref offset );
			Converter.ToBytes( (byte)0, data, ref offset );
			Converter.ToBytes( model, data, ref offset );// displayInfoID
			Converter.ToBytes( quality, data, ref offset );
			Converter.ToBytes( flags, data, ref offset );
			Converter.ToBytes( buyPrice, data, ref offset );
			//Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( sellPrice, data, ref offset );
		
			//Converter.ToBytes( objectClass, data, ref offset );//	displayinfoid
			Converter.ToBytes( (int)this.inventoryType, data, ref offset );
			Converter.ToBytes( this.availableClasses, data, ref offset );
			Converter.ToBytes( this.availableRaces, data, ref offset );
			Converter.ToBytes( this.level, data, ref offset );

			Converter.ToBytes( this.reqLevel, data, ref offset );
			Converter.ToBytes( this.skill, data, ref offset );
			Converter.ToBytes( this.skillRank, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
Converter.ToBytes( 0, data, ref offset );
			//Converter.ToBytes( this.maxCount, data, ref offset );
			Converter.ToBytes( this.stackable, data, ref offset );
			Converter.ToBytes( this.containerSlots, data, ref offset );

			#region Attribute bonii
			int nb = 0;
			if ( strBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Strenght, data, ref offset );//	bonus stat
				Converter.ToBytes( strBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( iqBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Iq, data, ref offset );//	bonus stat
				Converter.ToBytes( iqBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( staminaBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Stamina, data, ref offset );//	bonus stat
				Converter.ToBytes( staminaBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( spiritBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Spirit, data, ref offset );//	bonus stat
				Converter.ToBytes( spiritBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( agilityBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Agility, data, ref offset );//	bonus stat
				Converter.ToBytes( agilityBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( manaBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Mana, data, ref offset );//	bonus stat
				Converter.ToBytes( manaBonus, data, ref offset );//	bonus amount
				nb++;
			}
			if ( healthBonus != 0 )
			{
				Converter.ToBytes( (int)Attributes.Health, data, ref offset );//	bonus stat
				Converter.ToBytes( healthBonus, data, ref offset );//	bonus amount
				nb++;
			}
			for(int i = nb; i<10; i++)
			{
				Converter.ToBytes( 0, data, ref offset );//	bonus stat
				Converter.ToBytes( 0, data, ref offset );//	bonus amount
			}
			#endregion
			
			int fill = 0;
			for(int i = 0; i < 7; i++) 
			{
				if ( itemDamages[ i ] != null )
				{
					Converter.ToBytes( (float)itemDamages[ i ].MinDamage, data, ref offset );
					Converter.ToBytes( (float)itemDamages[ i ].MaxDamage, data, ref offset );
					Converter.ToBytes( i, data, ref offset );//	damage type
					fill++;
				}
			}
			for(int i = fill;i < 5;i++)
			{
				Converter.ToBytes( 0, data, ref offset );
				Converter.ToBytes( 0, data, ref offset );
				Converter.ToBytes( 0, data, ref offset );
			}
			Converter.ToBytes( this.resistance[ 0 ], data, ref offset );//	armor
			Converter.ToBytes( this.resistance[ 1 ], data, ref offset );//	light
			Converter.ToBytes( this.resistance[ 2 ], data, ref offset );//	fire
			Converter.ToBytes( this.resistance[ 3 ], data, ref offset );//	nature
			Converter.ToBytes( this.resistance[ 4 ], data, ref offset );//	frost
			Converter.ToBytes( this.resistance[ 5 ], data, ref offset );//	shadow
			Converter.ToBytes( this.resistance[ 6 ], data, ref offset );// arcane
			Converter.ToBytes( this.delay, data, ref offset );
			Converter.ToBytes( this.ammoType, data, ref offset );

			for(int i = 0; i<5; i++) 
			{
				if ( spells[ i ] == null )
				{
					Converter.ToBytes( -1, data, ref offset );
					Converter.ToBytes( 0, data, ref offset );
					Converter.ToBytes( 0, data, ref offset );
					Converter.ToBytes( 0, data, ref offset );
					Converter.ToBytes( -1, data, ref offset );
					Converter.ToBytes( 0, data, ref offset );
				}
				else
					spells[ i ].PrepareData( data, ref offset );
			}
			Converter.ToBytes( this.bonding, data, ref offset );
			if ( this.description != null )
			{
				Converter.ToBytes( this.description, data, ref offset );
				Converter.ToBytes( (byte)0, data, ref offset );
			}
			else
			{
			//	Converter.ToBytes( (byte)'.', data, ref offset );
				Converter.ToBytes( (byte)0, data, ref offset );
			}

			Converter.ToBytes( this.pageText, data, ref offset );
			Converter.ToBytes( this.language, data, ref offset );
			Converter.ToBytes( this.PageMaterial, data, ref offset );
			Converter.ToBytes( this.startQuest, data, ref offset );
			Converter.ToBytes( this.lockId, data, ref offset );
			Converter.ToBytes( this.material, data, ref offset );
			Converter.ToBytes( this.sheath, data, ref offset );
			Converter.ToBytes( this.ammoType, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );

			//	Item.ViewItem( data );
		}
		#endregion

		#region Special abilities
		public void TriggerOnHit( Mobile from, Mobile target )
		{
			foreach( SpecialAbility sa in spells )
			{
				if ( sa != null && sa.Trigger == 2 && sa.Proba > (float)Utility.RandomDouble() )
				{
					BaseAbility ba = (BaseAbility)sa.Spell;
					if ( SpellTemplate.SpellEffects[ (int)ba.Id ] is OnSelfItemSpellEffect )
					{
						( SpellTemplate.SpellEffects[ (int)ba.Id ] as OnSelfItemSpellEffect )( ba, from, sa, this );
					}								
					else
						if ( SpellTemplate.SpellEffects[ (int)ba.Id ] is OnSingleTargetItemSpellEffect )
					{
						( SpellTemplate.SpellEffects[ (int)ba.Id ] as OnSingleTargetItemSpellEffect )( ba, from, target, sa, this );
					}								
				}
			}
		}
		public void SetSpecialEffect( Mobile m )
		{
			foreach( SpecialAbility sa in spells )
			{
				if ( sa != null && sa.Trigger == 1 )
				{
					BaseAbility ba = (BaseAbility)sa.Spell;
					if ( SpellTemplate.SpellEffects[ (int)ba.Id ] is OnSelfItemSpellEffect )
					{
						( SpellTemplate.SpellEffects[ (int)ba.Id ] as OnSelfItemSpellEffect )( ba, m, sa, this );
					}								
					else
					if ( SpellTemplate.SpellEffects[ (int)ba.Id ] is SingleTargetSpellEffect )
					{
						( SpellTemplate.SpellEffects[ (int)ba.Id ] as SingleTargetSpellEffect )( ba, m, m );
					}								
				}
			}
		}
		#endregion
	}

	public class Money : Item
	{
		public Money() : base()
		{
		}
	}

	public class TestStationeryFake : Item
	{
		public TestStationeryFake() : base()
		{
			BuyPrice = 10;
			SubClass = 0;
			Material = -1;
			Stackable = 10;
			Model = 1069;
			ObjectClass = 0;
			Name = "Test Stationery";
			AvailableClasses = 0x07FFF;
			Quality = 1;
			SellPrice = 2;
			AvailableRaces = 0x01FF;
			Id = 8164;
		}
	}

	public class BlizzardStationeryFake : Item
	{
		public BlizzardStationeryFake() : base()
		{
			AvailableRaces = 0x07FFF;
			SubClass = 0;
			Material = -1;
			PageMaterial = 1;
			Stackable = 1;
			Model = 30658;
			ObjectClass = 0;
			Name = "Blizzard Stationery";
			AvailableClasses = 0x07FFF;
			Quality = 1;
			Id = 18154;
		}
	}
	public class DefaultStationeryFake : Item
	{
		public DefaultStationeryFake() : base()
		{
			AvailableRaces = 0x01FF;
			SubClass = 0;
			Material = -1;
			PageMaterial = 1;
			Stackable = 1;
			Model = 7798;
			ObjectClass = 0;
			Name = "Default Stationery";
			AvailableClasses = 0x07FFF;
			Quality = 1;
			Id = 9311;
		}
	}
}
