using System;
using HelperTools;
using System.Collections;
using Server.Items;

namespace Server
{

	/// <summary>
	/// Description of Object.	
	/// </summary>
	public class Object
	{
		public static UInt64 GUID = 0x213632;//12345678;
		//	protected UInt16 objectType;		// Types.  Bitmasked together by subclasses
		//	protected byte objectTypeId;	// 4 = player
		UInt64 guid;
		int zoneId;
		UInt16 mapId;
		float positionX;
		float positionY;
		float positionZ;
		float orientation;
		BaseSpawner spawnerLink;
		/*	float lastUpdateTime;
			float minZ;*/
	
		public static byte []Blank = new byte[ 0x26 * 4 ];	  
		public static byte []Blank26 = new byte[ 26 ];
		static ArrayList updateValues = new ArrayList();	
		static BitArray updateMask;// = new BitArray( Const.PlayerMaxBits );
		Item []treasure = null;


		#region CONSTRUCTORS/DESTRUCTORS
		public Object()
		{
		}
		
		public Object( int type ) : this()
		{
			//objectTypeId = 0;
			//	objectType = (UInt16)( type | Const.ObjectType_OBJECT );			
			X = 0.0f;
			Y = 0.0f;
			Z = 0.0f;
			Orientation = 0.0f;		
			zoneId = 0;
			mapId = 0;		
			guid = 0;		
			//updateMaskBlockCount = 0;
			//updateMaskSum = 0;			
		}
		public Object( UInt64 _guid ) : this()
		{
			guid = _guid;
		}
		public Object( UInt64 _guid, float x, float y, float z, float orient ) : this()
		{		
			//objectTypeId = 0;
			X = x;
			Y = y;
			Z = z;
			Orientation = orient;		
			zoneId = 0;
			mapId = 0;		
			guid = _guid;					
		}		
		public Object( UInt64 _guid, float x, float y, float z, float orient, ushort mapid ) : this()
		{		
			//objectTypeId = 0;
			X = x;
			Y = y;
			Z = z;
			Orientation = orient;		
			zoneId = 0;
			mapId = mapid;		
			guid = _guid;					
		}
		public virtual void Delete()
		{
		}
		#endregion

		public float Distance( Object m )
		{
			if ( m.MapId != mapId )
				return float.MaxValue;
			float a = m.X - X;
			float b = m.Y - Y;
			float c = m.Z - Z;
			return a * a + b * b + c * c;
		}
		public float QuickDistance( Position p )
		{
			if ( p.MapId != mapId )
				return float.MaxValue;
			float a = p.X - X;
			float b = p.Y - Y;
			return a * a + b * b;
		}
		public int QuickDistance( int px, int py )
		{
			int a = px - (int)X;
			int b = py - (int)Y;
			return a * a + b * b;
		}
		public int QuickDistance( Object m )
		{
			if ( m.MapId != mapId )
				return int.MaxValue;
			int a = (int)m.X - (int)X;
			int b = (int)m.Y - (int)Y;
			return a * a + b * b;
		}
		public float Distance( float x, float y, float z )
		{
			float a = x - X;
			float b = y - Y;
			float c = z - Z;
			return a * a + b * b + c * c;
		}
		public void ResetBitmap()
		{
			updateMask = new BitArray( Const.PlayerMaxBits );			
			updateValues.Clear();
		}
		public virtual bool SeenBy( Character c )
		{
			return true;
		}

		#region SERIALISATION
		public virtual void Deserialize( GenericReader gr )
		{
			int version = gr.ReadInt();
			guid = gr.ReadInt64();
			X = gr.ReadFloat();
			Y = gr.ReadFloat();
			Z = gr.ReadFloat();
			Orientation = gr.ReadFloat();
			MapId = (UInt16)gr.ReadShort();
			ZoneId = (int)gr.ReadInt();
			/*	int dec = gr.ReadInt();
				if ( dec == 1 )
					decay = DateTime.Now;*/
		}		
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );
			gw.Write( guid );
			gw.Write( X );
			gw.Write( Y );
			gw.Write( Z );
			gw.Write( Orientation );
			gw.Write( MapId );
			gw.Write( ZoneId );
			/*if ( decay != null )
				gw.Write( 1 );
			else
				gw.Write( 0 );*/

		}

		#endregion

		#region ACCESSORS
		public virtual BaseSpawner SpawnerLink
		{
			get { return spawnerLink; }
			set { spawnerLink = value; }
		}
		public Item[] Treasure
		{
			get { return treasure; }
			set { treasure = value; }
		}
		public virtual byte[]tempBuff
		{
			get { return World.tempBuff; }
		}

		public UInt64 Guid
		{
			get { return guid; }
			set { guid = value; }
		}
		public virtual float X
		{
			get { return positionX; }
			set { positionX = value; }
		}
		
		public virtual float Y
		{
			get { return positionY; }
			set { positionY = value; }
		}
		
		public virtual float Z
		{
			get { return positionZ; }
			set { positionZ = value; }
		}		
		
		public float Orientation
		{
			get { return orientation; }
			set { orientation = value; }
		}

		public int ZoneId
		{
			get { return zoneId; }
			set { zoneId = value; }
		}

		public UInt16 MapId
		{
			get { return mapId; }
			set { mapId = value; }
		}
		#endregion

		#region UPDATE
		public virtual void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
		}
		public virtual void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther, Character f )
		{
		}
#if TESTCONSECUTIF
		public static int order = 0;
		public static bool activateorder = false;
#endif
		
		protected void setUpdateValue( int index, uint val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add(  val );
			updateMask.Set( index, true );
		}
		protected void setUpdateValue( int index, float val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			byte []b = BitConverter.GetBytes( val );
			int i = BitConverter.ToInt32( b, 0 );
			setUpdateValue( index, i );
		}

		protected void setUpdateValue( int index, int val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( (UInt32)val );
			updateMask.Set( index, true );
		}
		protected void setUpdateValue( int index, short val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( val );
			updateMask.Set( index, true );
		}
		protected void setUpdateValue( int index, ushort val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( val );
			updateMask.Set( index, true );
		}
		protected void setUpdateValue( int index, byte val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( val );
			updateMask.Set( index, true );
		}
		protected void setUpdateValue( int index, UInt64 val ) 
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( (UInt32)( val & 0xffffffff ) );
			updateValues.Add( (UInt32)( ( val >> 32 ) & 0xffffffff ) );
			updateMask.Set( index, true );
			updateMask.Set( index + 1, true );
		}
		void setUpdateFloatValue( int index, float val )
		{
#if TESTCONSECUTIF
			if ( activateorder )
			{
				if ( index < order )
				{
					Console.WriteLine("precedence error {0}", (UpdateFields)index );
				}
				else
					order = index;
			}
#endif
			updateValues.Add( val );
			updateMask.Set( index, true );
		}
		/*
		public void FlushUpdateDataForMobile( byte []data, ref int offset, int decal )
		{			
			Converter.ToBytes( updateMask, data, ref offset, 0x19 );
			Converter.ToBytes( Guid, data, ref offset );
			Converter.ToBytes( 9, data, ref offset );
			//offset += decal;
			foreach( object i in updateValues )
			{
				if ( i is byte )
					Converter.ToBytes( (byte)i, data, ref offset );
				else
					if ( i is Int16 )
					Converter.ToBytes( (Int16)i, data, ref offset );
				else
					if ( i is UInt32 )
					Converter.ToBytes( (UInt32)i, data, ref offset );
				else
					Converter.ToBytes( (Int32)i, data, ref offset );
			}
			updateValues.Clear();
		}
		public void FlushPartialUpdateDataForMobile( byte []data, ref int offset, int decal, int type2, int type3, int typeA9 )
		{			
			int len = 109;
			if ( type2 == 0 && type3 == 1 && typeA9 == 1 )
			{
				len = 4;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 2 )
			{
				len = 8;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 3 )
			{
				len = 24;
			}
			Converter.ToBytes( updateMask, data, ref offset, len );
			offset += decal;
			foreach( object i in updateValues )
			{
				if ( i is int )
					Converter.ToBytes( (Int32)i, data, ref offset );					
				else
					if ( i is Int16 )
					Converter.ToBytes( (Int16)i, data, ref offset );
				else
					if ( i is UInt32 )
					Converter.ToBytes( (UInt32)i, data, ref offset );
				else
					if ( i is float )
					Converter.ToBytes( (float)i, data, ref offset );
				else
					Converter.ToBytes( (byte)i, data, ref offset );
					
			}
			updateValues.Clear();
		}*/
		
		public void FlushUpdateData( byte []data, ref int offset, int s )
		{
			int len = s * 4;
			Converter.ToBytes( (byte)s, data, ref offset );
			Converter.ToBytes( updateMask, data, ref offset, len );
			foreach( object i in updateValues )
			{
				if ( i is int )
					Converter.ToBytes( (Int32)i, data, ref offset );
				else
					if ( i is byte )
					Converter.ToBytes( (byte)i, data, ref offset );
				else
					if ( i is short )
					Converter.ToBytes( (short)i, data, ref offset );
				else
					if ( i is ushort )
					Converter.ToBytes( (ushort)i, data, ref offset );
				else
					if ( i is UInt32 )
					Converter.ToBytes( (UInt32)i, data, ref offset );
				else
					if ( i is float )
					Converter.ToBytes( (float)i, data, ref offset );
				else
					Converter.ToBytes( (Int32)i, data, ref offset );

			}
			updateValues.Clear();		
		}
		public void FlushUpdateData( byte []data, ref int offset, int type2, int type3, int typeA9 )
		{			
			int len = 109;
			if ( type2 == 0 && type3 == 1 && typeA9 == 1 )
			{
				len = 5;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 2 )
			{
				len = 8;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 3 )
			{
				len = 24;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 4 )
			{
				len = 24;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 5 )
			{
				len = 4;
			}
			if ( type2 == 0 && type3 == 0 && typeA9 == 0 )
			{
				len = 112;				
			}

			Converter.ToBytes( (byte)( len / 4 ), data, ref offset );
			Converter.ToBytes( updateMask, data, ref offset, len - 1 );
			//offset += decal;
			foreach( object i in updateValues )
			{
				if ( i is int )
					Converter.ToBytes( (Int32)i, data, ref offset );
				else
					if ( i is byte )
					Converter.ToBytes( (byte)i, data, ref offset );
				else
					if ( i is short )
					Converter.ToBytes( (short)i, data, ref offset );
				else
					if ( i is ushort )
					Converter.ToBytes( (ushort)i, data, ref offset );
				else
					if ( i is UInt32 )
					Converter.ToBytes( (UInt32)i, data, ref offset );
				else
					if ( i is float )
					Converter.ToBytes( (float)i, data, ref offset );
				else
					Converter.ToBytes( (Int32)i, data, ref offset );

			}
			updateValues.Clear();
		}
		#endregion
	}


	public enum UpdateFields : int 
	{
		/*
				// OBJECT
				OBJECT_FIELD_GUID              = 0x0, // pos=0
				OBJECT_FIELD_TYPE              = 0x2 + OBJECT_FIELD_GUID, // size=1, pos=2
				OBJECT_FIELD_ENTRY             = 0x3 + OBJECT_FIELD_GUID, // size=1, pos=3
				OBJECT_FIELD_SCALE_X           = 0x4 + OBJECT_FIELD_GUID, // size=1, pos=4
				OBJECT_FIELD_PADDING           = 0x5 + OBJECT_FIELD_GUID, // size=1, pos=5
				OBJECT_END                     = 0x6 + OBJECT_FIELD_GUID, // pos=6

				// ITEM
				ITEM_START                     = 0x6, // pos=6
				ITEM_FIELD_OWNER               = 0x0 + ITEM_START, // size=2, pos=6
				ITEM_FIELD_CONTAINED           = 0x2 + ITEM_START, // size=2, pos=8
				ITEM_FIELD_CREATOR             = 0x4 + ITEM_START, // size=2, pos=10
				ITEM_FIELD_GIFTCREATOR         = 0x6 + ITEM_START, // size=2, pos=12
				ITEM_FIELD_STACK_COUNT         = 0x8 + ITEM_START, // size=1, pos=14
				ITEM_FIELD_DURATION            = 0x9 + ITEM_START, // size=1, pos=15
				ITEM_FIELD_SPELL_CHARGES       = 0xA + ITEM_START, // size=5, pos=16
				ITEM_FIELD_FLAGS               = 0xF + ITEM_START, // size=1, pos=21
				ITEM_FIELD_ENCHANTMENT         = 0x10 + ITEM_START, // size=21, pos=22
				ITEM_FIELD_PROPERTY_SEED       = 0x25 + ITEM_START, // size=1, pos=43
				ITEM_FIELD_RANDOM_PROPERTIES_ID = 0x26 + ITEM_START, // size=1, pos=44
				ITEM_FIELD_ITEM_TEXT_ID        = 0x27 + ITEM_START, // size=1, pos=45
				ITEM_DURABILITY                = 0x28 + ITEM_START, // size=1, pos=46
				ITEM_MAXDURABILITY             = 0x29 + ITEM_START, // size=1, pos=47
				ITEM_END                       = 0x2A + ITEM_START, // pos=48

				// CONTAINER
				CONTAINER_START                = 0x30, // pos=48
				CONTAINER_FIELD_NUM_SLOTS      = 0x0 + CONTAINER_START, // size=1, pos=48
				CONTAINER_ALIGN_PAD            = 0x1 + CONTAINER_START, // size=1, pos=49
				CONTAINER_FIELD_SLOT_1         = 0x2 + CONTAINER_START, // size=40, pos=50
				CONTAINER_END                  = 0x2A + CONTAINER_START, // pos=90

				// UNIT
				UNIT_START                     = 0x6, // pos=6
				UNIT_FIELD_CHARM               = 0x0 + UNIT_START, // size=2, pos=6
				UNIT_FIELD_SUMMON              = 0x2 + UNIT_START, // size=2, pos=8
				UNIT_FIELD_CHARMEDBY           = 0x4 + UNIT_START, // size=2, pos=10
				UNIT_FIELD_SUMMONEDBY          = 0x6 + UNIT_START, // size=2, pos=12
				UNIT_FIELD_CREATEDBY           = 0x8 + UNIT_START, // size=2, pos=14
				UNIT_FIELD_TARGET              = 0xA + UNIT_START, // size=2, pos=16
				UNIT_FIELD_PERSUADED           = 0xC + UNIT_START, // size=2, pos=18
				UNIT_FIELD_CHANNEL_OBJECT      = 0xE + UNIT_START, // size=2, pos=20
				UNIT_FIELD_HEALTH              = 0x10 + UNIT_START, // size=1, pos=22
				UNIT_FIELD_POWER1              = 0x11 + UNIT_START, // size=1, pos=23
				UNIT_FIELD_POWER2              = 0x12 + UNIT_START, // size=1, pos=24
				UNIT_FIELD_POWER3              = 0x13 + UNIT_START, // size=1, pos=25
				UNIT_FIELD_POWER4              = 0x14 + UNIT_START, // size=1, pos=26
				UNIT_FIELD_POWER5              = 0x15 + UNIT_START, // size=1, pos=27
				UNIT_FIELD_MAXHEALTH           = 0x16 + UNIT_START, // size=1, pos=28
				UNIT_FIELD_MAXPOWER1           = 0x17 + UNIT_START, // size=1, pos=29
				UNIT_FIELD_MAXPOWER2           = 0x18 + UNIT_START, // size=1, pos=30
				UNIT_FIELD_MAXPOWER3           = 0x19 + UNIT_START, // size=1, pos=31
				UNIT_FIELD_MAXPOWER4           = 0x1A + UNIT_START, // size=1, pos=32
				UNIT_FIELD_MAXPOWER5           = 0x1B + UNIT_START, // size=1, pos=33
				UNIT_FIELD_LEVEL               = 0x1C + UNIT_START, // size=1, pos=34
				UNIT_FIELD_FACTIONTEMPLATE     = 0x1D + UNIT_START, // size=1, pos=35
				UNIT_FIELD_BYTES_0             = 0x1E + UNIT_START, // size=1, pos=36
				UNIT_VIRTUAL_ITEM_SLOT_DISPLAY = 0x1F + UNIT_START, // size=3, pos=37
				UNIT_VIRTUAL_ITEM_INFO         = 0x22 + UNIT_START, // size=6, pos=40
				UNIT_FIELD_FLAGS               = 0x28 + UNIT_START, // size=1, pos=46
				UNIT_FIELD_AURA                = 0x29 + UNIT_START, // size=56, pos=47
				UNIT_FIELD_AURALEVELS          = 0x61 + UNIT_START, // size=10, pos=103
				UNIT_FIELD_AURAAPPLICATIONS    = 0x6B + UNIT_START, // size=10, pos=113
				UNIT_FIELD_AURAFLAGS           = 0x75 + UNIT_START, // size=7, pos=123
				UNIT_FIELD_AURASTATE           = 0x7C + UNIT_START, // size=1, pos=130
				UNIT_FIELD_BASEATTACKTIME1      = 0x7D + UNIT_START, // size=1, pos=131
				UNIT_FIELD_BASEATTACKTIME2      = 0x7E + UNIT_START, // size=1, pos=132
				UNIT_FIELD_BYTES_1             = 0x7F + UNIT_START, // size=1, pos=133
				UNIT_FIELD_BOUNDINGRADIUS      = 0x80 + UNIT_START, // size=1, pos=134
				UNIT_FIELD_COMBATREACH         = 0x81 + UNIT_START, // size=1, pos=135
				UNIT_FIELD_DISPLAYID           = 0x82 + UNIT_START, // size=1, pos=136
				UNIT_FIELD_NATIVEDISPLAYID     = 0x83 + UNIT_START, // size=1, pos=137
				UNIT_FIELD_MOUNTDISPLAYID      = 0x84 + UNIT_START, // size=1, pos=138
				UNIT_FIELD_MINDAMAGE           = 0x85 + UNIT_START, // size=1, pos=139
				UNIT_FIELD_MAXDAMAGE           = 0x86 + UNIT_START, // size=1, pos=140
				UNIT_FIELD_PETNUMBER           = 0x87 + UNIT_START, // size=1, pos=141
				UNIT_FIELD_PET_NAME_TIMESTAMP  = 0x88 + UNIT_START, // size=1, pos=142
				UNIT_FIELD_STANDSTATE          = 0x89 + UNIT_START, // size=1, pos=143
				UNIT_FIELD_PETNEXTLEVELEXP     = 0x8A + UNIT_START, // size=1, pos=144
				UNIT_DYNAMIC_FLAGS             = 0x8B + UNIT_START, // size=1, pos=145
				UNIT_CHANNEL_SPELL             = 0x8C + UNIT_START, // size=1, pos=146
				UNIT_MOD_CAST_SPEED            = 0x8D + UNIT_START, // size=1, pos=147
				UNIT_CREATED_BY_SPELL          = 0x8E + UNIT_START, // size=1, pos=148
				UNIT_NPC_FLAGS_FAKE                 = 0x8F + UNIT_START, // size=1, pos=149
				UNIT_NPC_EMOTESTATE            = 0x90 + UNIT_START, // size=1, pos=150
				UNIT_TRAINING_POINTS           = 0x91 + UNIT_START, // size=1, pos=151
				UNIT_NPC_FLAGS		           = 0x92 + UNIT_START, // size=1, pos=152
				UNIT_ATTACK_POWER_MODS         = 0x93 + UNIT_START, // size=1, pos=153
				UNIT_FIELD_PADDING             = 0x94 + UNIT_START, // size=1, pos=154
				UNIT_FIELD_STR               = 0x95 + UNIT_START, // size=1, pos=155
				UNIT_FIELD_AGILITY               = 0x96 + UNIT_START, // size=1, pos=156
				UNIT_FIELD_STAMINA               = 0x97 + UNIT_START, // size=1, pos=157
				UNIT_FIELD_IQ               = 0x98 + UNIT_START, // size=1, pos=158
				UNIT_FIELD_SPIRIT               = 0x99 + UNIT_START, // size=1, pos=159
				UNIT_FIELD_ARMOR         = 0x9A + UNIT_START, // size=7, pos=160
				UNIT_FIELD_ATTACKPOWER         = 0xA1 + UNIT_START, // size=1, pos=167

				UNIT_FIELD_PADDING1            = 0xA2 + UNIT_START, // size=1, pos=168
				UNIT_FIELD_PADDING2            = 0xA3 + UNIT_START, // size=1, pos=169
				UNIT_FIELD_BYTES_2             = 0xA4 + UNIT_START, // size=1, pos=170
				UNIT_FIELD_RANGEDATTACKPOWER   = 0xA5 + UNIT_START, // size=1, pos=171
				UNIT_FIELD_RANGED_ATTACK_POWER_MODS = 0xA6 + UNIT_START, // size=1, pos=172
				UNIT_FIELD_MINRANGEDDAMAGE     = 0xA7 + UNIT_START, // size=1, pos=173
				UNIT_FIELD_MAXRANGEDDAMAGE     = 0xA8 + UNIT_START, // size=1, pos=174
				UNIT_FIELD_PADDING3            = 0xA9 + UNIT_START, // size=1, pos=175

				UNIT_END                       = 0xAA + UNIT_START, // pos=176

				// PLAYER
				PLAYER_START                   = 0xB0, // pos=176
				PLAYER_SELECTION               = 0x0 + PLAYER_START, // size=2, pos=176
				PLAYER_DUEL_ARBITER            = 0x2 + PLAYER_START, // size=2, pos=178
				PLAYER_STATUS                  = 0x4 + PLAYER_START, // size=1, pos=180
				PLAYER_GUILDRANK               = 0x5 + PLAYER_START, // size=1, pos=181
				PLAYER_BYTES                   = 0x6 + PLAYER_START, // size=1, pos=182
				PLAYER_BYTES_2                 = 0x7 + PLAYER_START, // size=1, pos=183
				PLAYER_BYTES_3                 = 0x8 + PLAYER_START, // size=1, pos=184

				PLAYER_QUEST_LOG_1_1           = 188, // size=60, pos=188
				PLAYER_START2                  = 232 + PLAYER_START, // pos=176

				PLAYER_DUEL_TEAM               = 0x9 + PLAYER_START2, // size=1, pos=185
				PLAYER_GUILD_TIMESTAMP         = 0xA + PLAYER_START2, // size=1, pos=186
				PLAYER_FIELD_PAD_0             = 0xB + PLAYER_START2, // size=1, pos=187
				PLAYER_FIELD_INV_SLOT_HEAD     = 0xC + PLAYER_START2, // size=46, pos=188
				PLAYER_FIELD_PACK_SLOT_1       = 0x3A + PLAYER_START2, // size=32, pos=234

				PLAYER_FIELD_ITEM				= 248,

				PLAYER_FIELD_BANK_SLOT_1       = 0x5A + PLAYER_START2, // size=48, pos=266
				PLAYER_FIELD_BANKBAG_SLOT_1    = 0x8A + PLAYER_START2, // size=12, pos=314
				PLAYER_FIELD_VENDORBUYBACK_SLOT = 0x96 + PLAYER_START2, // size=2, pos=326
				PLAYER_FARSIGHT                = 0x98 + PLAYER_START2, // size=2, pos=328
				PLAYER_FIELD_COMBO_TARGET      = 0x9A + PLAYER_START2, // size=2, pos=330
				PLAYER_FIELD_BUYBACK_NPC       = 0x9C + PLAYER_START2, // size=2, pos=332
				PLAYER_XP                      = 0x9E + PLAYER_START2, // size=1, pos=334
				PLAYER_NEXT_LEVEL_XP           = 0x9F + PLAYER_START2, // size=1, pos=335
				PLAYER_SKILL_INFO_1_1          = 0xA0 + PLAYER_START2, // size=384, pos=336
		
				PLAYER_CHARACTER_POINTS1       = 0x25C + PLAYER_START2, // size=1, pos=780
				PLAYER_CHARACTER_POINTS2       = 0x25D + PLAYER_START2, // size=1, pos=781
				PLAYER_TRACK_CREATURES         = 954,
				PLAYER_TRACK_RESOURCES         = 955,
				PLAYER_CHAT_FILTERS            = 956,
				PLAYER_BLOCK_PERCENTAGE        = 957,
				PLAYER_DODGE_PERCENTAGE        = 958,
				PLAYER_PARRY_PERCENTAGE        = 959,



				PLAYER_CRIT_PERCENTAGE         = 960, // size=1, pos=788
				PLAYER_EXPLORED_ZONES_1        = 961, // size=32, pos=789
				PLAYER_PART3				   = PLAYER_START2 + 105,
				PLAYER_REST_STATE_EXPERIENCE   = 993, // size=1, pos=821
				PLAYER_FIELD_COINAGE           = 994,//0x286 + PLAYER_PART3, // size=1, pos=822
				PLAYER_FIELD_POSSTAT0          = 1 + PLAYER_FIELD_COINAGE, // size=1, pos=823
				PLAYER_FIELD_POSSTAT1          = 2 + PLAYER_FIELD_COINAGE, // size=1, pos=824
				PLAYER_FIELD_POSSTAT2          = 3 + PLAYER_FIELD_COINAGE, // size=1, pos=825
				PLAYER_FIELD_POSSTAT3          = 4 + PLAYER_FIELD_COINAGE, // size=1, pos=826
				PLAYER_FIELD_POSSTAT4          = 5 + PLAYER_FIELD_COINAGE, // size=1, pos=827
				PLAYER_FIELD_NEGSTAT0          = 6 + PLAYER_FIELD_COINAGE, // size=1, pos=828
				PLAYER_FIELD_NEGSTAT1          = 7 + PLAYER_FIELD_COINAGE, // size=1, pos=829
				PLAYER_FIELD_NEGSTAT2          = 8 + PLAYER_FIELD_COINAGE, // size=1, pos=830
				PLAYER_FIELD_NEGSTAT3          = 9 + PLAYER_FIELD_COINAGE, // size=1, pos=831
				PLAYER_FIELD_NEGSTAT4          = 10 + PLAYER_FIELD_COINAGE, // size=1, pos=832
				PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE = 11 + PLAYER_FIELD_COINAGE, // size=7, pos=833
				PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE = 18 + PLAYER_FIELD_COINAGE, // size=7, pos=840
				PLAYER_FIELD_MOD_DAMAGE_DONE_POS = 1019, // size=7, pos=847
				PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = 1026, // size=1, pos=854
				PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = 1033, // size=5, pos=855
				PLAYER_FIELD_BYTES             = 1040, // size=1, pos=860
				PLAYER_AMMO_ID                 = 1041,//17 + PLAYER_FIELD_COINAGE, // size=1, pos=861
				PLAYER_FIELD_PVP_MEDALS        = 1 + PLAYER_AMMO_ID, // size=1, pos=862
				PLAYER_FIELD_BUYBACK_ITEM_ID   = 2 + PLAYER_AMMO_ID, // size=1, pos=863
				PLAYER_FIELD_BUYBACK_RANDOM_PROPERTIES_ID = 3 + PLAYER_AMMO_ID, // size=1, pos=864
				PLAYER_FIELD_BUYBACK_SEED      = 4 + PLAYER_AMMO_ID, // size=1, pos=865
				PLAYER_FIELD_BUYBACK_PRICE     = 5 + PLAYER_AMMO_ID, // size=1, pos=866
				PLAYER_FIELD_BUYBACK_DURABILITY = 6 + PLAYER_AMMO_ID, // size=1, pos=867
				PLAYER_FIELD_BUYBACK_COUNT     = 7 + PLAYER_AMMO_ID, // size=1, pos=868
				PLAYER_FIELD_PADDING           = 8 + PLAYER_AMMO_ID, // size=1, pos=869
				PLAYER_END                     = 9 + PLAYER_AMMO_ID, // pos=870

				// GAMEOBJECT
				GAMEOBJECT_START               = 0x6, // pos=6
				GAMEOBJECT_DISPLAYID           = 0x0 + GAMEOBJECT_START, // size=1, pos=6
				GAMEOBJECT_FLAGS               = 0x1 + GAMEOBJECT_START, // size=1, pos=7
				GAMEOBJECT_ROTATION            = 0x2 + GAMEOBJECT_START, // size=4, pos=8
				GAMEOBJECT_STATE               = 0x6 + GAMEOBJECT_START, // size=1, pos=12
				GAMEOBJECT_TIMESTAMP           = 0x7 + GAMEOBJECT_START, // size=1, pos=13
				GAMEOBJECT_POS_X               = 0x8 + GAMEOBJECT_START, // size=1, pos=14
				GAMEOBJECT_POS_Y               = 0x9 + GAMEOBJECT_START, // size=1, pos=15
				GAMEOBJECT_POS_Z               = 0xA + GAMEOBJECT_START, // size=1, pos=16
				GAMEOBJECT_FACING              = 0xB + GAMEOBJECT_START, // size=1, pos=17
				GAMEOBJECT_DYN_FLAGS           = 0xC + GAMEOBJECT_START, // size=1, pos=18
				GAMEOBJECT_FACTION             = 0xD + GAMEOBJECT_START, // size=1, pos=19
				GAMEOBJECT_TYPE_ID             = 0xE + GAMEOBJECT_START, // size=1, pos=20
				GAMEOBJECT_LEVEL               = 0xF + GAMEOBJECT_START, // size=1, pos=21
				GAMEOBJECT_END                 = 0x10 + GAMEOBJECT_START, // pos=22

				// DYNAMICOBJECT
				DYNAMICOBJECT_START            = 0x16, // pos=22
				DYNAMICOBJECT_CASTER           = 0x0 + DYNAMICOBJECT_START, // size=2, pos=22
				DYNAMICOBJECT_BYTES            = 0x2 + DYNAMICOBJECT_START, // size=1, pos=24
				DYNAMICOBJECT_SPELLID          = 0x3 + DYNAMICOBJECT_START, // size=1, pos=25
				DYNAMICOBJECT_RADIUS           = 0x4 + DYNAMICOBJECT_START, // size=1, pos=26
				DYNAMICOBJECT_POS_X            = 0x5 + DYNAMICOBJECT_START, // size=1, pos=27
				DYNAMICOBJECT_POS_Y            = 0x6 + DYNAMICOBJECT_START, // size=1, pos=28
				DYNAMICOBJECT_POS_Z            = 0x7 + DYNAMICOBJECT_START, // size=1, pos=29
				DYNAMICOBJECT_FACING           = 0x8 + DYNAMICOBJECT_START, // size=1, pos=30
				DYNAMICOBJECT_PAD              = 0x9 + DYNAMICOBJECT_START, // size=1, pos=31
				DYNAMICOBJECT_END              = 0xA + DYNAMICOBJECT_START, // pos=32
				*/
		/*
				// CORPSE
				CORPSE_START                   = 0x16, // pos=22
				CORPSE_FIELD_OWNER             = 0x0 + CORPSE_START, // size=2, pos=22
				CORPSE_FIELD_FACING            = 0x2 + CORPSE_START, // size=1, pos=24
				CORPSE_FIELD_POS_X             = 0x3 + CORPSE_START, // size=1, pos=25
				CORPSE_FIELD_POS_Y             = 0x4 + CORPSE_START, // size=1, pos=26
				CORPSE_FIELD_POS_Z             = 0x5 + CORPSE_START, // size=1, pos=27
				CORPSE_FIELD_DISPLAY_ID        = 0x6 + CORPSE_START, // size=1, pos=28
				CORPSE_FIELD_ITEM0             = 0x7 + CORPSE_START, // size=1, pos=29
				CORPSE_FIELD_ITEM1             = 0x8 + CORPSE_START, // size=1, pos=30
				CORPSE_FIELD_ITEM2             = 0x9 + CORPSE_START, // size=1, pos=31
				CORPSE_FIELD_ITEM3             = 0xA + CORPSE_START, // size=1, pos=32
				CORPSE_FIELD_ITEM4             = 0xB + CORPSE_START, // size=1, pos=33
				CORPSE_FIELD_ITEM5             = 0xC + CORPSE_START, // size=14, pos=34
				CORPSE_FIELD_BYTES_1           = 0x1A + CORPSE_START, // size=1, pos=48
				CORPSE_FIELD_BYTES_2           = 0x1B + CORPSE_START, // size=1, pos=49
				CORPSE_FIELD_GUILD             = 0x1C + CORPSE_START, // size=1, pos=50
				CORPSE_FIELD_FLAGS             = 0x1D + CORPSE_START, // pos=51*/


		/*  1.6 mais pas bon

			// Object
			OBJECT_FIELD_GUID 				= 0x000, // GUID
			OBJECT_FIELD_GUID_01 				= 0x001, // GUID
			OBJECT_FIELD_TYPE                       	= 0x002, // Int32
			OBJECT_FIELD_ENTRY                      	= 0x003, // Int32
			OBJECT_FIELD_SCALE_X                    	= 0x004, // Float
			OBJECT_FIELD_PADDING                    	= 0x005, // Int32
			OBJECT_END					= 0x006,

			// Item
			ITEM_FIELD_OWNER 				= OBJECT_END + 0x000, // GUID
			ITEM_FIELD_OWNER_01 				= OBJECT_END + 0x001, // GUID
			ITEM_FIELD_CONTAINED 				= OBJECT_END + 0x002, // GUID
			ITEM_FIELD_CONTAINED_01 			= OBJECT_END + 0x003, // GUID
			ITEM_FIELD_CREATOR 				= OBJECT_END + 0x004, // GUID
			ITEM_FIELD_CREATOR_01 			      	= OBJECT_END + 0x005, // GUID
			ITEM_FIELD_GIFTCREATOR 				= OBJECT_END + 0x006, // GUID
			ITEM_FIELD_GIFTCREATOR_01 			= OBJECT_END + 0x007, // GUID
			ITEM_FIELD_STACK_COUNT              		= OBJECT_END + 0x008, // Int32
			ITEM_FIELD_DURATION                	        = OBJECT_END + 0x009, // Int32
			ITEM_FIELD_SPELL_CHARGES 			= OBJECT_END + 0x00A, // Int32
			ITEM_FIELD_SPELL_CHARGES_01 			= OBJECT_END + 0x00B, // Int32
			ITEM_FIELD_SPELL_CHARGES_02 			= OBJECT_END + 0x00C, // Int32
			ITEM_FIELD_SPELL_CHARGES_03 			= OBJECT_END + 0x00D, // Int32
			ITEM_FIELD_SPELL_CHARGES_04 			= OBJECT_END + 0x00E, // Int32
			ITEM_FIELD_FLAGS                    		= OBJECT_END + 0x00F, // Chars?
			ITEM_FIELD_ENCHANTMENT 				= OBJECT_END + 0x010, // Int32
			ITEM_FIELD_ENCHANTMENT_01 			= OBJECT_END + 0x011, // Int32
			ITEM_FIELD_ENCHANTMENT_02 			= OBJECT_END + 0x012, // Int32
			ITEM_FIELD_ENCHANTMENT_03 			= OBJECT_END + 0x013, // Int32
			ITEM_FIELD_ENCHANTMENT_04 			= OBJECT_END + 0x014, // Int32
			ITEM_FIELD_ENCHANTMENT_05 			= OBJECT_END + 0x015, // Int32
			ITEM_FIELD_ENCHANTMENT_06 			= OBJECT_END + 0x016, // Int32
			ITEM_FIELD_ENCHANTMENT_07 			= OBJECT_END + 0x017, // Int32
			ITEM_FIELD_ENCHANTMENT_08 			= OBJECT_END + 0x018, // Int32
			ITEM_FIELD_ENCHANTMENT_09 			= OBJECT_END + 0x019, // Int32
			ITEM_FIELD_ENCHANTMENT_10 			= OBJECT_END + 0x01A, // Int32
			ITEM_FIELD_ENCHANTMENT_11 			= OBJECT_END + 0x01B, // Int32
			ITEM_FIELD_ENCHANTMENT_12 			= OBJECT_END + 0x01C, // Int32
			ITEM_FIELD_ENCHANTMENT_13 			= OBJECT_END + 0x01D, // Int32
			ITEM_FIELD_ENCHANTMENT_14 			= OBJECT_END + 0x01E, // Int32
			ITEM_FIELD_ENCHANTMENT_15 			= OBJECT_END + 0x01F, // Int32
			ITEM_FIELD_ENCHANTMENT_16 			= OBJECT_END + 0x020, // Int32
			ITEM_FIELD_ENCHANTMENT_17 			= OBJECT_END + 0x021, // Int32
			ITEM_FIELD_ENCHANTMENT_18 			= OBJECT_END + 0x022, // Int32
			ITEM_FIELD_ENCHANTMENT_19 			= OBJECT_END + 0x023, // Int32
			ITEM_FIELD_ENCHANTMENT_20 			= OBJECT_END + 0x024, // Int32
			ITEM_FIELD_PROPERTY_SEED            		= OBJECT_END + 0x025, // Int32
			ITEM_FIELD_RANDOM_PROPERTIES_ID     		= OBJECT_END + 0x026, // Int32
			ITEM_FIELD_ITEM_TEXT_ID             		= OBJECT_END + 0x027, // Int32
			ITEM_FIELD_DURABILITY               		= OBJECT_END + 0x028, // Int32
			ITEM_FIELD_MAXDURABILITY            		= OBJECT_END + 0x029, // Int32
			ITEM_END					= OBJECT_END + 0x02A,


			// Container 
			CONTAINER_FIELD_NUM_SLOTS           		= ITEM_END + 0x000, // Int32
			CONTAINER_ALIGN_PAD                 		= ITEM_END + 0x001, // Bytes
			CONTAINER_FIELD_SLOT_1 				= ITEM_END + 0x002, // GUID
			CONTAINER_FIELD_SLOT_1_01 			= ITEM_END + 0x003, // GUID
			CONTAINER_FIELD_SLOT_1_02 			= ITEM_END + 0x004, // GUID
			CONTAINER_FIELD_SLOT_1_03 			= ITEM_END + 0x005, // GUID
			CONTAINER_FIELD_SLOT_1_04 			= ITEM_END + 0x006, // GUID
			CONTAINER_FIELD_SLOT_1_05 			= ITEM_END + 0x007, // GUID
			CONTAINER_FIELD_SLOT_1_06 			= ITEM_END + 0x008, // GUID
			CONTAINER_FIELD_SLOT_1_07 			= ITEM_END + 0x009, // GUID
			CONTAINER_FIELD_SLOT_1_08 			= ITEM_END + 0x00A, // GUID
			CONTAINER_FIELD_SLOT_1_09 			= ITEM_END + 0x00B, // GUID
			CONTAINER_FIELD_SLOT_1_10 			= ITEM_END + 0x00C, // GUID
			CONTAINER_FIELD_SLOT_1_11 			= ITEM_END + 0x00D, // GUID
			CONTAINER_FIELD_SLOT_1_12 			= ITEM_END + 0x00E, // GUID
			CONTAINER_FIELD_SLOT_1_13 			= ITEM_END + 0x00F, // GUID
			CONTAINER_FIELD_SLOT_1_14 			= ITEM_END + 0x010, // GUID
			CONTAINER_FIELD_SLOT_1_15 			= ITEM_END + 0x011, // GUID
			CONTAINER_FIELD_SLOT_1_16 			= ITEM_END + 0x012, // GUID
			CONTAINER_FIELD_SLOT_1_17 			= ITEM_END + 0x013, // GUID
			CONTAINER_FIELD_SLOT_1_18 			= ITEM_END + 0x014, // GUID
			CONTAINER_FIELD_SLOT_1_19 			= ITEM_END + 0x015, // GUID
			CONTAINER_FIELD_SLOT_1_20 			= ITEM_END + 0x016, // GUID
			CONTAINER_FIELD_SLOT_1_21 			= ITEM_END + 0x017, // GUID
			CONTAINER_FIELD_SLOT_1_22 			= ITEM_END + 0x018, // GUID
			CONTAINER_FIELD_SLOT_1_23 			= ITEM_END + 0x019, // GUID
			CONTAINER_FIELD_SLOT_1_24 			= ITEM_END + 0x01A, // GUID
			CONTAINER_FIELD_SLOT_1_25 			= ITEM_END + 0x01B, // GUID
			CONTAINER_FIELD_SLOT_1_26 			= ITEM_END + 0x01C, // GUID
			CONTAINER_FIELD_SLOT_1_27 			= ITEM_END + 0x01D, // GUID
			CONTAINER_FIELD_SLOT_1_28 			= ITEM_END + 0x01E, // GUID
			CONTAINER_FIELD_SLOT_1_29 			= ITEM_END + 0x01F, // GUID
			CONTAINER_FIELD_SLOT_1_30 			= ITEM_END + 0x020, // GUID
			CONTAINER_FIELD_SLOT_1_31 			= ITEM_END + 0x021, // GUID
			CONTAINER_FIELD_SLOT_1_32 			= ITEM_END + 0x022, // GUID
			CONTAINER_FIELD_SLOT_1_33 			= ITEM_END + 0x023, // GUID
			CONTAINER_FIELD_SLOT_1_34 			= ITEM_END + 0x024, // GUID
			CONTAINER_FIELD_SLOT_1_35 			= ITEM_END + 0x025, // GUID
			CONTAINER_FIELD_SLOT_1_36 			= ITEM_END + 0x026, // GUID
			CONTAINER_FIELD_SLOT_1_37 			= ITEM_END + 0x027, // GUID
			CONTAINER_FIELD_SLOT_1_38 			= ITEM_END + 0x028, // GUID
			CONTAINER_FIELD_SLOT_1_39 			= ITEM_END + 0x029, // GUID
			CONTAINER_END					= ITEM_END + 0x02A,

			// Unit
			UNIT_FIELD_CHARM 				= CONTAINER_END + 0x000, // GUID
			UNIT_FIELD_CHARM_01 				= CONTAINER_END + 0x001, // GUID
			UNIT_FIELD_SUMMON 				= CONTAINER_END + 0x002, // GUID
			UNIT_FIELD_SUMMON_01 				= CONTAINER_END + 0x003, // GUID
			UNIT_FIELD_CHARMEDBY 				= CONTAINER_END + 0x004, // GUID
			UNIT_FIELD_CHARMEDBY_01 			= CONTAINER_END + 0x005, // GUID
			UNIT_FIELD_SUMMONEDBY 				= CONTAINER_END + 0x006, // GUID
			UNIT_FIELD_SUMMONEDBY_01 			= CONTAINER_END + 0x007, // GUID
			UNIT_FIELD_CREATEDBY 				= CONTAINER_END + 0x008, // GUID
			UNIT_FIELD_CREATEDBY_01 			= CONTAINER_END + 0x009, // GUID
			UNIT_FIELD_TARGET 				= CONTAINER_END + 0x00A, // GUID
			UNIT_FIELD_TARGET_01 				= CONTAINER_END + 0x00B, // GUID
			UNIT_FIELD_PERSUADED 				= CONTAINER_END + 0x00C, // GUID
			UNIT_FIELD_PERSUADED_01 			= CONTAINER_END + 0x00D, // GUID
			UNIT_FIELD_CHANNEL_OBJECT 			= CONTAINER_END + 0x00E, // GUID
			UNIT_FIELD_CHANNEL_OBJECT_01 			= CONTAINER_END + 0x00F, // GUID
			UNIT_FIELD_HEALTH                   		= CONTAINER_END + 0x010, // Int32
			UNIT_FIELD_POWER1                   		= CONTAINER_END + 0x011, // Int32
			UNIT_FIELD_POWER2                   		= CONTAINER_END + 0x012, // Int32
			UNIT_FIELD_POWER3                   		= CONTAINER_END + 0x013, // Int32
			UNIT_FIELD_POWER4                   		= CONTAINER_END + 0x014, // Int32
			UNIT_FIELD_POWER5                   		= CONTAINER_END + 0x015, // Int32
			UNIT_FIELD_MAXHEALTH                		= CONTAINER_END + 0x016, // Int32
			UNIT_FIELD_MAXPOWER1                		= CONTAINER_END + 0x017, // Int32
			UNIT_FIELD_MAXPOWER2                		= CONTAINER_END + 0x018, // Int32
			UNIT_FIELD_MAXPOWER3                		= CONTAINER_END + 0x019, // Int32
			UNIT_FIELD_MAXPOWER4                		= CONTAINER_END + 0x01A, // Int32
			UNIT_FIELD_MAXPOWER5                		= CONTAINER_END + 0x01B, // Int32
			UNIT_FIELD_LEVEL                    		= CONTAINER_END + 0x01C, // Int32
			UNIT_FIELD_FACTIONTEMPLATE          		= CONTAINER_END + 0x01D, // Int32
			UNIT_FIELD_BYTES_0                  		= CONTAINER_END + 0x01E, // Bytes
			UNIT_VIRTUAL_ITEM_SLOT_DISPLAY 			= CONTAINER_END + 0x01F, // Int32
			UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_01 		= CONTAINER_END + 0x020, // Int32
			UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_02 		= CONTAINER_END + 0x021, // Int32
			UNIT_VIRTUAL_ITEM_INFO 				= CONTAINER_END + 0x022, // Bytes
			UNIT_VIRTUAL_ITEM_INFO_01 			= CONTAINER_END + 0x023, // Bytes
			UNIT_VIRTUAL_ITEM_INFO_02 			= CONTAINER_END + 0x024, // Bytes
			UNIT_VIRTUAL_ITEM_INFO_03 			= CONTAINER_END + 0x025, // Bytes
			UNIT_VIRTUAL_ITEM_INFO_04 			= CONTAINER_END + 0x026, // Bytes
			UNIT_VIRTUAL_ITEM_INFO_05 			= CONTAINER_END + 0x027, // Bytes
			UNIT_FIELD_FLAGS                    		= CONTAINER_END + 0x028, // Int32
			UNIT_FIELD_AURA 				= CONTAINER_END + 0x029, // Int32
			UNIT_FIELD_AURA_01 				= CONTAINER_END + 0x02A, // Int32
			UNIT_FIELD_AURA_02 				= CONTAINER_END + 0x02B, // Int32
			UNIT_FIELD_AURA_03 				= CONTAINER_END + 0x02C, // Int32
			UNIT_FIELD_AURA_04 				= CONTAINER_END + 0x02D, // Int32
			UNIT_FIELD_AURA_05 				= CONTAINER_END + 0x02E, // Int32
			UNIT_FIELD_AURA_06 				= CONTAINER_END + 0x02F, // Int32
			UNIT_FIELD_AURA_07 				= CONTAINER_END + 0x030, // Int32
			UNIT_FIELD_AURA_08 				= CONTAINER_END + 0x031, // Int32
			UNIT_FIELD_AURA_09 				= CONTAINER_END + 0x032, // Int32
			UNIT_FIELD_AURA_10 				= CONTAINER_END + 0x033, // Int32
			UNIT_FIELD_AURA_11 				= CONTAINER_END + 0x034, // Int32
			UNIT_FIELD_AURA_12 				= CONTAINER_END + 0x035, // Int32
			UNIT_FIELD_AURA_13 				= CONTAINER_END + 0x036, // Int32
			UNIT_FIELD_AURA_14 				= CONTAINER_END + 0x037, // Int32
			UNIT_FIELD_AURA_15 				= CONTAINER_END + 0x038, // Int32
			UNIT_FIELD_AURA_16 				= CONTAINER_END + 0x039, // Int32
			UNIT_FIELD_AURA_17 				= CONTAINER_END + 0x03A, // Int32
			UNIT_FIELD_AURA_18 				= CONTAINER_END + 0x03B, // Int32
			UNIT_FIELD_AURA_19 				= CONTAINER_END + 0x03C, // Int32
			UNIT_FIELD_AURA_20 				= CONTAINER_END + 0x03D, // Int32
			UNIT_FIELD_AURA_21 				= CONTAINER_END + 0x03E, // Int32
			UNIT_FIELD_AURA_22 				= CONTAINER_END + 0x03F, // Int32
			UNIT_FIELD_AURA_23 				= CONTAINER_END + 0x040, // Int32
			UNIT_FIELD_AURA_24 				= CONTAINER_END + 0x041, // Int32
			UNIT_FIELD_AURA_25 				= CONTAINER_END + 0x042, // Int32
			UNIT_FIELD_AURA_26 				= CONTAINER_END + 0x043, // Int32
			UNIT_FIELD_AURA_27 				= CONTAINER_END + 0x044, // Int32
			UNIT_FIELD_AURA_28 				= CONTAINER_END + 0x045, // Int32
			UNIT_FIELD_AURA_29 				= CONTAINER_END + 0x046, // Int32
			UNIT_FIELD_AURA_30 				= CONTAINER_END + 0x047, // Int32
			UNIT_FIELD_AURA_31 				= CONTAINER_END + 0x048, // Int32
			UNIT_FIELD_AURA_32 				= CONTAINER_END + 0x049, // Int32
			UNIT_FIELD_AURA_33 				= CONTAINER_END + 0x04A, // Int32
			UNIT_FIELD_AURA_34 				= CONTAINER_END + 0x04B, // Int32
			UNIT_FIELD_AURA_35 				= CONTAINER_END + 0x04C, // Int32
			UNIT_FIELD_AURA_36 				= CONTAINER_END + 0x04D, // Int32
			UNIT_FIELD_AURA_37 				= CONTAINER_END + 0x04E, // Int32
			UNIT_FIELD_AURA_38 				= CONTAINER_END + 0x04F, // Int32
			UNIT_FIELD_AURA_39 				= CONTAINER_END + 0x050, // Int32
			UNIT_FIELD_AURA_40 				= CONTAINER_END + 0x051, // Int32
			UNIT_FIELD_AURA_41 				= CONTAINER_END + 0x052, // Int32
			UNIT_FIELD_AURA_42 				= CONTAINER_END + 0x053, // Int32
			UNIT_FIELD_AURA_43 				= CONTAINER_END + 0x054, // Int32
			UNIT_FIELD_AURA_44 				= CONTAINER_END + 0x055, // Int32
			UNIT_FIELD_AURA_45 				= CONTAINER_END + 0x056, // Int32
			UNIT_FIELD_AURA_46 				= CONTAINER_END + 0x057, // Int32
			UNIT_FIELD_AURA_47 				= CONTAINER_END + 0x058, // Int32
			UNIT_FIELD_AURA_48 				= CONTAINER_END + 0x059, // Int32
			UNIT_FIELD_AURA_49 				= CONTAINER_END + 0x05A, // Int32
			UNIT_FIELD_AURA_50 				= CONTAINER_END + 0x05B, // Int32
			UNIT_FIELD_AURA_51 				= CONTAINER_END + 0x05C, // Int32
			UNIT_FIELD_AURA_52 				= CONTAINER_END + 0x05D, // Int32
			UNIT_FIELD_AURA_53 				= CONTAINER_END + 0x05E, // Int32
			UNIT_FIELD_AURA_54 				= CONTAINER_END + 0x05F, // Int32
			UNIT_FIELD_AURA_55 				= CONTAINER_END + 0x060, // Int32
			UNIT_FIELD_AURALEVELS 				= CONTAINER_END + 0x061, // Bytes
			UNIT_FIELD_AURALEVELS_01 			= CONTAINER_END + 0x062, // Bytes
			UNIT_FIELD_AURALEVELS_02 			= CONTAINER_END + 0x063, // Bytes
			UNIT_FIELD_AURALEVELS_03 			= CONTAINER_END + 0x064, // Bytes
			UNIT_FIELD_AURALEVELS_04 			= CONTAINER_END + 0x065, // Bytes
			UNIT_FIELD_AURALEVELS_05 			= CONTAINER_END + 0x066, // Bytes
			UNIT_FIELD_AURALEVELS_06 			= CONTAINER_END + 0x067, // Bytes
			UNIT_FIELD_AURALEVELS_07 			= CONTAINER_END + 0x068, // Bytes
			UNIT_FIELD_AURALEVELS_08 			= CONTAINER_END + 0x069, // Bytes
			UNIT_FIELD_AURALEVELS_09 			= CONTAINER_END + 0x06A, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS 			= CONTAINER_END + 0x06B, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_01 			= CONTAINER_END + 0x06C, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_02 			= CONTAINER_END + 0x06D, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_03 			= CONTAINER_END + 0x06E, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_04 			= CONTAINER_END + 0x06F, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_05 			= CONTAINER_END + 0x070, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_06 			= CONTAINER_END + 0x071, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_07 			= CONTAINER_END + 0x072, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_08 			= CONTAINER_END + 0x073, // Bytes
			UNIT_FIELD_AURAAPPLICATIONS_09 			= CONTAINER_END + 0x074, // Bytes
			UNIT_FIELD_AURAFLAGS	 			= CONTAINER_END + 0x075, // Bytes
			UNIT_FIELD_AURAFLAGS_01 			= CONTAINER_END + 0x076, // Bytes
			UNIT_FIELD_AURAFLAGS_02 			= CONTAINER_END + 0x077, // Bytes
			UNIT_FIELD_AURAFLAGS_03 			= CONTAINER_END + 0x078, // Bytes
			UNIT_FIELD_AURAFLAGS_04 			= CONTAINER_END + 0x079, // Bytes
			UNIT_FIELD_AURAFLAGS_05 			= CONTAINER_END + 0x07A, // Bytes
			UNIT_FIELD_AURAFLAGS_06 			= CONTAINER_END + 0x07B, // Bytes
			UNIT_FIELD_AURASTATE                		= CONTAINER_END + 0x07C, // Int32
			UNIT_FIELD_BASEATTACKTIME1 			= CONTAINER_END + 0x07D, // Int32
			UNIT_FIELD_BASEATTACKTIME2 			= CONTAINER_END + 0x07E, // Int32
			UNIT_FIELD_RANGEDATTACKTIME         		= CONTAINER_END + 0x07F, // Int32
			UNIT_FIELD_BOUNDINGRADIUS           		= CONTAINER_END + 0x080, // Float
			UNIT_FIELD_COMBATREACH              		= CONTAINER_END + 0x081, // Float
			UNIT_FIELD_DISPLAYID                		= CONTAINER_END + 0x082, // Int32
			UNIT_FIELD_NATIVEDISPLAYID          		= CONTAINER_END + 0x083, // Int32
			UNIT_FIELD_MOUNTDISPLAYID           		= CONTAINER_END + 0x084, // Int32
			UNIT_FIELD_MINDAMAGE                		= CONTAINER_END + 0x085, // Float
			UNIT_FIELD_MAXDAMAGE                		= CONTAINER_END + 0x086, // Float
			UNIT_FIELD_MINOFFHANDDAMAGE         		= CONTAINER_END + 0x087, // Float
			UNIT_FIELD_MAXOFFHANDDAMAGE         		= CONTAINER_END + 0x088, // Float
			UNIT_FIELD_BYTES_1                  		= CONTAINER_END + 0x089, // Bytes
			UNIT_FIELD_PETNUMBER                		= CONTAINER_END + 0x08A, // Int32
			UNIT_FIELD_PET_NAME_TIMESTAMP       		= CONTAINER_END + 0x08B, // Int32
			UNIT_FIELD_PETEXPERIENCE            		= CONTAINER_END + 0x08C, // Int32
			UNIT_FIELD_PETNEXTLEVELEXP          		= CONTAINER_END + 0x08D, // Int32
			UNIT_DYNAMIC_FLAGS                  		= CONTAINER_END + 0x08E, // Int32
			UNIT_CHANNEL_SPELL                  		= CONTAINER_END + 0x08F, // Int32
			UNIT_MOD_CAST_SPEED                 		= CONTAINER_END + 0x090, // Int32
			UNIT_CREATED_BY_SPELL               		= CONTAINER_END + 0x091, // Int32
			UNIT_NPC_FLAGS                      		= CONTAINER_END + 0x092, // Int32
			UNIT_NPC_EMOTESTATE                 		= CONTAINER_END + 0x093, // Int32
			UNIT_TRAINING_POINTS                		= CONTAINER_END + 0x094, // Chars?
			UNIT_FIELD_STR							     = 0x95 + CONTAINER_END, // size=1, pos=155
			UNIT_FIELD_AGILITY					         = 0x96 + CONTAINER_END, // size=1, pos=156
			UNIT_FIELD_STAMINA					          = 0x97 + CONTAINER_END, // size=1, pos=157
			UNIT_FIELD_IQ						     = 0x98 + CONTAINER_END, // size=1, pos=158
			UNIT_FIELD_SPIRIT					     = 0x99 + CONTAINER_END, // size=1, pos=159
			UNIT_FIELD_ARMOR 						= CONTAINER_END + 0x09A, // Int32
			UNIT_FIELD_RESISTANCES_01 			= CONTAINER_END + 0x09B, // Int32
			UNIT_FIELD_RESISTANCES_02 			= CONTAINER_END + 0x09C, // Int32
			UNIT_FIELD_RESISTANCES_03 			= CONTAINER_END + 0x09D, // Int32
			UNIT_FIELD_RESISTANCES_04 			= CONTAINER_END + 0x09E, // Int32
			UNIT_FIELD_RESISTANCES_05 			= CONTAINER_END + 0x09F, // Int32
			UNIT_FIELD_RESISTANCES_06 			= CONTAINER_END + 0x0A0, // Int32
			UNIT_FIELD_ATTACKPOWER              		= CONTAINER_END + 0x0A1, // Int32
			UNIT_FIELD_BASE_MANA                		= CONTAINER_END + 0x0A2, // Int32
			UNIT_ATTACK_POWER_MODS        		= CONTAINER_END + 0x0A3, // Chars?
			UNIT_FIELD_BYTES_2                  		= CONTAINER_END + 0x0A4, // Bytes
			UNIT_FIELD_RANGEDATTACKPOWER        		= CONTAINER_END + 0x0A5, // Int32
			UNIT_FIELD_RANGED_ATTACK_POWER_MODS 		= CONTAINER_END + 0x0A6, // Chars?
			UNIT_FIELD_MINRANGEDDAMAGE          		= CONTAINER_END + 0x0A7, // Float
			UNIT_FIELD_MAXRANGEDDAMAGE          		= CONTAINER_END + 0x0A8, // Float
			UNIT_FIELD_PADDING                  		= CONTAINER_END + 0x0A9, // Int32
			UNIT_END					= CONTAINER_END + 0x0AA,

			// Player
			PLAYER_SELECTION 				= UNIT_END + 0x000, // GUID
			PLAYER_SELECTION_01 				= UNIT_END + 0x001, // GUID
			PLAYER_DUEL_ARBITER 				= UNIT_END + 0x002, // GUID
			PLAYER_DUEL_ARBITER_01 				= UNIT_END + 0x003, // GUID
			PLAYER_STATUS                        		= UNIT_END + 0x004, // Int32
			PLAYER_GUILDID                      		= UNIT_END + 0x005, // Int32
			PLAYER_GUILDRANK                    		= UNIT_END + 0x006, // Int32
			PLAYER_BYTES                        		= UNIT_END + 0x007, // Bytes
			PLAYER_BYTES_2                      		= UNIT_END + 0x008, // Bytes
			PLAYER_BYTES_3                      		= UNIT_END + 0x009, // Bytes
			PLAYER_DUEL_TEAM                    		= UNIT_END + 0x00A, // Int32
			PLAYER_GUILD_TIMESTAMP              		= UNIT_END + 0x00B, // Int32
			PLAYER_QUEST_LOG_1_1                		= UNIT_END + 0x00C, // Int32
			PLAYER_QUEST_LOG_1_2 				= UNIT_END + 0x00D, // Int32
			PLAYER_QUEST_LOG_1_2_01 			= UNIT_END + 0x00E, // Int32
			PLAYER_QUEST_LOG_2_1               		= UNIT_END + 0x00F, // Int32
			PLAYER_QUEST_LOG_2_2 				= UNIT_END + 0x010, // Int32
			PLAYER_QUEST_LOG_2_2_01 			= UNIT_END + 0x011, // Int32
			PLAYER_QUEST_LOG_3_1                		= UNIT_END + 0x012, // Int32
			PLAYER_QUEST_LOG_3_2 				= UNIT_END + 0x013, // Int32
			PLAYER_QUEST_LOG_3_2_01 			= UNIT_END + 0x014, // Int32
			PLAYER_QUEST_LOG_4_1                		= UNIT_END + 0x015, // Int32
			PLAYER_QUEST_LOG_4_2 				= UNIT_END + 0x016, // Int32
			PLAYER_QUEST_LOG_4_2_01 			= UNIT_END + 0x017, // Int32
			PLAYER_QUEST_LOG_5_1                		= UNIT_END + 0x018, // Int32
			PLAYER_QUEST_LOG_5_2 				= UNIT_END + 0x019, // Int32
			PLAYER_QUEST_LOG_5_2_01 			= UNIT_END + 0x01A, // Int32
			PLAYER_QUEST_LOG_6_1                		= UNIT_END + 0x01B, // Int32
			PLAYER_QUEST_LOG_6_2 				= UNIT_END + 0x01C, // Int32
			PLAYER_QUEST_LOG_6_2_01 			= UNIT_END + 0x01D, // Int32
			PLAYER_QUEST_LOG_7_1                		= UNIT_END + 0x01E, // Int32
			PLAYER_QUEST_LOG_7_2 				= UNIT_END + 0x01F, // Int32
			PLAYER_QUEST_LOG_7_2_01 			= UNIT_END + 0x020, // Int32
			PLAYER_QUEST_LOG_8_1                		= UNIT_END + 0x021, // Int32
			PLAYER_QUEST_LOG_8_2 				= UNIT_END + 0x022, // Int32
			PLAYER_QUEST_LOG_8_2_01 			= UNIT_END + 0x023, // Int32
			PLAYER_QUEST_LOG_9_1                		= UNIT_END + 0x024, // Int32
			PLAYER_QUEST_LOG_9_2 				= UNIT_END + 0x025, // Int32
			PLAYER_QUEST_LOG_9_2_01 			= UNIT_END + 0x026, // Int32
			PLAYER_QUEST_LOG_10_1               		= UNIT_END + 0x027, // Int32
			PLAYER_QUEST_LOG_10_2 				= UNIT_END + 0x028, // Int32
			PLAYER_QUEST_LOG_10_2_01 			= UNIT_END + 0x029, // Int32
			PLAYER_QUEST_LOG_11_1              		= UNIT_END + 0x02A, // Int32
			PLAYER_QUEST_LOG_11_2 				= UNIT_END + 0x02B, // Int32
			PLAYER_QUEST_LOG_11_2_01 			= UNIT_END + 0x02C, // Int32
			PLAYER_QUEST_LOG_12_1               		= UNIT_END + 0x02D, // Int32
			PLAYER_QUEST_LOG_12_2 				= UNIT_END + 0x02E, // Int32
			PLAYER_QUEST_LOG_12_2_01 			= UNIT_END + 0x02F, // Int32
			PLAYER_QUEST_LOG_13_1               		= UNIT_END + 0x030, // Int32
			PLAYER_QUEST_LOG_13_2 				= UNIT_END + 0x031, // Int32
			PLAYER_QUEST_LOG_13_2_01 			= UNIT_END + 0x032, // Int32
			PLAYER_QUEST_LOG_14_1              		= UNIT_END + 0x033, // Int32
			PLAYER_QUEST_LOG_14_2 				= UNIT_END + 0x034, // Int32
			PLAYER_QUEST_LOG_14_2_01 			= UNIT_END + 0x035, // Int32
			PLAYER_QUEST_LOG_15_1               		= UNIT_END + 0x036, // Int32
			PLAYER_QUEST_LOG_15_2 				= UNIT_END + 0x037, // Int32
			PLAYER_QUEST_LOG_15_2_01 			= UNIT_END + 0x038, // Int32
			PLAYER_QUEST_LOG_16_1               		= UNIT_END + 0x039, // Int32
			PLAYER_QUEST_LOG_16_2 				= UNIT_END + 0x03A, // Int32
			PLAYER_QUEST_LOG_16_2_01 			= UNIT_END + 0x03B, // Int32
			PLAYER_QUEST_LOG_17_1               		= UNIT_END + 0x03C, // Int32
			PLAYER_QUEST_LOG_17_2 				= UNIT_END + 0x03D, // Int32
			PLAYER_QUEST_LOG_17_2_01 			= UNIT_END + 0x03E, // Int32
			PLAYER_QUEST_LOG_18_1               		= UNIT_END + 0x03F, // Int32
			PLAYER_QUEST_LOG_18_2 				= UNIT_END + 0x040, // Int32
			PLAYER_QUEST_LOG_18_2_01 			= UNIT_END + 0x041, // Int32
			PLAYER_QUEST_LOG_19_1               		= UNIT_END + 0x042, // Int32
			PLAYER_QUEST_LOG_19_2 				= UNIT_END + 0x043, // Int32
			PLAYER_QUEST_LOG_19_2_01 			= UNIT_END + 0x044, // Int32
			PLAYER_QUEST_LOG_20_1               		= UNIT_END + 0x045, // Int32
			PLAYER_QUEST_LOG_20_2 				= UNIT_END + 0x046, // Int32
			PLAYER_QUEST_LOG_20_2_01 			= UNIT_END + 0x047, // Int32
			PLAYER_VISIBLE_ITEM_1_0 			= UNIT_END + 0x048, // Int32
			PLAYER_VISIBLE_ITEM_1_0_01 			= UNIT_END + 0x049, // Int32
			PLAYER_VISIBLE_ITEM_1_0_02 			= UNIT_END + 0x04A, // Int32
			PLAYER_VISIBLE_ITEM_1_0_03 			= UNIT_END + 0x04B, // Int32
			PLAYER_VISIBLE_ITEM_1_0_04 			= UNIT_END + 0x04C, // Int32
			PLAYER_VISIBLE_ITEM_1_0_05 			= UNIT_END + 0x04D, // Int32
			PLAYER_VISIBLE_ITEM_1_0_06 			= UNIT_END + 0x04E, // Int32
			PLAYER_VISIBLE_ITEM_1_0_07 			= UNIT_END + 0x04F, // Int32
			PLAYER_VISIBLE_ITEM_1_PROPERTIES    		= UNIT_END + 0x050, // Chars?
			PLAYER_VISIBLE_ITEM_1_CREATOR 			= UNIT_END + 0x051, // GUID
			PLAYER_VISIBLE_ITEM_1_CREATOR_01 		= UNIT_END + 0x052, // GUID
			PLAYER_VISIBLE_ITEM_2_0 			= UNIT_END + 0x053, // Int32
			PLAYER_VISIBLE_ITEM_2_0_01 			= UNIT_END + 0x054, // Int32
			PLAYER_VISIBLE_ITEM_2_0_02 			= UNIT_END + 0x055, // Int32
			PLAYER_VISIBLE_ITEM_2_0_03 			= UNIT_END + 0x056, // Int32
			PLAYER_VISIBLE_ITEM_2_0_04 			= UNIT_END + 0x057, // Int32
			PLAYER_VISIBLE_ITEM_2_0_05 			= UNIT_END + 0x058, // Int32
			PLAYER_VISIBLE_ITEM_2_0_06 			= UNIT_END + 0x059, // Int32
			PLAYER_VISIBLE_ITEM_2_0_07 			= UNIT_END + 0x05A, // Int32
			PLAYER_VISIBLE_ITEM_2_PROPERTIES    		= UNIT_END + 0x05B, // Chars?
			PLAYER_VISIBLE_ITEM_2_CREATOR 			= UNIT_END + 0x05C, // GUID
			PLAYER_VISIBLE_ITEM_2_CREATOR_01 		= UNIT_END + 0x05D, // GUID
			PLAYER_VISIBLE_ITEM_3_0 			= UNIT_END + 0x05E, // Int32
			PLAYER_VISIBLE_ITEM_3_0_01 			= UNIT_END + 0x05F, // Int32
			PLAYER_VISIBLE_ITEM_3_0_02 			= UNIT_END + 0x060, // Int32
			PLAYER_VISIBLE_ITEM_3_0_03 			= UNIT_END + 0x061, // Int32
			PLAYER_VISIBLE_ITEM_3_0_04 			= UNIT_END + 0x062, // Int32
			PLAYER_VISIBLE_ITEM_3_0_05 			= UNIT_END + 0x063, // Int32
			PLAYER_VISIBLE_ITEM_3_0_06 			= UNIT_END + 0x064, // Int32
			PLAYER_VISIBLE_ITEM_3_0_07 			= UNIT_END + 0x065, // Int32
			PLAYER_VISIBLE_ITEM_3_PROPERTIES    		= UNIT_END + 0x066, // Chars?
			PLAYER_VISIBLE_ITEM_3_CREATOR 			= UNIT_END + 0x067, // GUID
			PLAYER_VISIBLE_ITEM_3_CREATOR_01 		= UNIT_END + 0x068, // GUID
			PLAYER_VISIBLE_ITEM_4_0 			= UNIT_END + 0x069, // Int32
			PLAYER_VISIBLE_ITEM_4_0_01 			= UNIT_END + 0x06A, // Int32
			PLAYER_VISIBLE_ITEM_4_0_02 			= UNIT_END + 0x06B, // Int32
			PLAYER_VISIBLE_ITEM_4_0_03 			= UNIT_END + 0x06C, // Int32
			PLAYER_VISIBLE_ITEM_4_0_04 			= UNIT_END + 0x06D, // Int32
			PLAYER_VISIBLE_ITEM_4_0_05 			= UNIT_END + 0x06E, // Int32
			PLAYER_VISIBLE_ITEM_4_0_06 			= UNIT_END + 0x06F, // Int32
			PLAYER_VISIBLE_ITEM_4_0_07 			= UNIT_END + 0x070, // Int32
			PLAYER_VISIBLE_ITEM_4_PROPERTIES    		= UNIT_END + 0x071, // Chars?
			PLAYER_VISIBLE_ITEM_4_CREATOR 			= UNIT_END + 0x072, // GUID
			PLAYER_VISIBLE_ITEM_4_CREATOR_01 		= UNIT_END + 0x073, // GUID
			PLAYER_VISIBLE_ITEM_5_0 			= UNIT_END + 0x074, // Int32
			PLAYER_VISIBLE_ITEM_5_0_01 			= UNIT_END + 0x075, // Int32
			PLAYER_VISIBLE_ITEM_5_0_02 			= UNIT_END + 0x076, // Int32
			PLAYER_VISIBLE_ITEM_5_0_03 			= UNIT_END + 0x077, // Int32
			PLAYER_VISIBLE_ITEM_5_0_04 			= UNIT_END + 0x078, // Int32
			PLAYER_VISIBLE_ITEM_5_0_05 			= UNIT_END + 0x079, // Int32
			PLAYER_VISIBLE_ITEM_5_0_06 			= UNIT_END + 0x07A, // Int32
			PLAYER_VISIBLE_ITEM_5_0_07 			= UNIT_END + 0x07B, // Int32
			PLAYER_VISIBLE_ITEM_5_PROPERTIES    		= UNIT_END + 0x07C, // Chars?
			PLAYER_VISIBLE_ITEM_5_CREATOR 			= UNIT_END + 0x07D, // GUID
			PLAYER_VISIBLE_ITEM_5_CREATOR_01 		= UNIT_END + 0x07E, // GUID
			PLAYER_VISIBLE_ITEM_6_0 			= UNIT_END + 0x07F, // Int32
			PLAYER_VISIBLE_ITEM_6_0_01 			= UNIT_END + 0x080, // Int32
			PLAYER_VISIBLE_ITEM_6_0_02 			= UNIT_END + 0x081, // Int32
			PLAYER_VISIBLE_ITEM_6_0_03 			= UNIT_END + 0x082, // Int32
			PLAYER_VISIBLE_ITEM_6_0_04 			= UNIT_END + 0x083, // Int32
			PLAYER_VISIBLE_ITEM_6_0_05 			= UNIT_END + 0x084, // Int32
			PLAYER_VISIBLE_ITEM_6_0_06 			= UNIT_END + 0x085, // Int32
			PLAYER_VISIBLE_ITEM_6_0_07 			= UNIT_END + 0x086, // Int32
			PLAYER_VISIBLE_ITEM_6_PROPERTIES    		= UNIT_END + 0x087, // Chars?
			PLAYER_VISIBLE_ITEM_6_CREATOR 			= UNIT_END + 0x088, // GUID
			PLAYER_VISIBLE_ITEM_6_CREATOR_01 		= UNIT_END + 0x089, // GUID
			PLAYER_VISIBLE_ITEM_7_0 			= UNIT_END + 0x08A, // Int32
			PLAYER_VISIBLE_ITEM_7_0_01 			= UNIT_END + 0x08B, // Int32
			PLAYER_VISIBLE_ITEM_7_0_02 			= UNIT_END + 0x08C, // Int32
			PLAYER_VISIBLE_ITEM_7_0_03 			= UNIT_END + 0x08D, // Int32
			PLAYER_VISIBLE_ITEM_7_0_04 			= UNIT_END + 0x08E, // Int32
			PLAYER_VISIBLE_ITEM_7_0_05 			= UNIT_END + 0x08F, // Int32
			PLAYER_VISIBLE_ITEM_7_0_06 			= UNIT_END + 0x090, // Int32
			PLAYER_VISIBLE_ITEM_7_0_07 			= UNIT_END + 0x091, // Int32
			PLAYER_VISIBLE_ITEM_7_PROPERTIES    		= UNIT_END + 0x092, // Chars?
			PLAYER_VISIBLE_ITEM_7_CREATOR 			= UNIT_END + 0x093, // GUID
			PLAYER_VISIBLE_ITEM_7_CREATOR_01 		= UNIT_END + 0x094, // GUID
			PLAYER_VISIBLE_ITEM_8_0 			= UNIT_END + 0x095, // Int32
			PLAYER_VISIBLE_ITEM_8_0_01 			= UNIT_END + 0x096, // Int32
			PLAYER_VISIBLE_ITEM_8_0_02 			= UNIT_END + 0x097, // Int32
			PLAYER_VISIBLE_ITEM_8_0_03 			= UNIT_END + 0x098, // Int32
			PLAYER_VISIBLE_ITEM_8_0_04 			= UNIT_END + 0x099, // Int32
			PLAYER_VISIBLE_ITEM_8_0_05 			= UNIT_END + 0x09A, // Int32
			PLAYER_VISIBLE_ITEM_8_0_06 			= UNIT_END + 0x09B, // Int32
			PLAYER_VISIBLE_ITEM_8_0_07 			= UNIT_END + 0x09C, // Int32
			PLAYER_VISIBLE_ITEM_8_PROPERTIES    		= UNIT_END + 0x09D, // Chars?
			PLAYER_VISIBLE_ITEM_8_CREATOR 			= UNIT_END + 0x09E, // GUID
			PLAYER_VISIBLE_ITEM_8_CREATOR_01 		= UNIT_END + 0x09F, // GUID
			PLAYER_VISIBLE_ITEM_9_0 			= UNIT_END + 0x0A0, // Int32
			PLAYER_VISIBLE_ITEM_9_0_01 			= UNIT_END + 0x0A1, // Int32
			PLAYER_VISIBLE_ITEM_9_0_02 			= UNIT_END + 0x0A2, // Int32
			PLAYER_VISIBLE_ITEM_9_0_03 			= UNIT_END + 0x0A3, // Int32
			PLAYER_VISIBLE_ITEM_9_0_04 			= UNIT_END + 0x0A4, // Int32
			PLAYER_VISIBLE_ITEM_9_0_05 			= UNIT_END + 0x0A5, // Int32
			PLAYER_VISIBLE_ITEM_9_0_06 			= UNIT_END + 0x0A6, // Int32
			PLAYER_VISIBLE_ITEM_9_0_07 			= UNIT_END + 0x0A7, // Int32
			PLAYER_VISIBLE_ITEM_9_PROPERTIES    		= UNIT_END + 0x0A8, // Chars?
			PLAYER_VISIBLE_ITEM_9_CREATOR 			= UNIT_END + 0x0A9, // GUID
			PLAYER_VISIBLE_ITEM_9_CREATOR_01 		= UNIT_END + 0x0AA, // GUID
			PLAYER_VISIBLE_ITEM_10_0 			= UNIT_END + 0x0AB, // Int32
			PLAYER_VISIBLE_ITEM_10_0_01 			= UNIT_END + 0x0AC, // Int32
			PLAYER_VISIBLE_ITEM_10_0_02 			= UNIT_END + 0x0AD, // Int32
			PLAYER_VISIBLE_ITEM_10_0_03 			= UNIT_END + 0x0AE, // Int32
			PLAYER_VISIBLE_ITEM_10_0_04 			= UNIT_END + 0x0AF, // Int32
			PLAYER_VISIBLE_ITEM_10_0_05 			= UNIT_END + 0x0B0, // Int32
			PLAYER_VISIBLE_ITEM_10_0_06 			= UNIT_END + 0x0B1, // Int32
			PLAYER_VISIBLE_ITEM_10_0_07 			= UNIT_END + 0x0B2, // Int32
			PLAYER_VISIBLE_ITEM_10_PROPERTIES   		= UNIT_END + 0x0B3, // Chars?
			PLAYER_VISIBLE_ITEM_10_CREATOR 			= UNIT_END + 0x0B4, // GUID
			PLAYER_VISIBLE_ITEM_10_CREATOR_01 		= UNIT_END + 0x0B5, // GUID
			PLAYER_VISIBLE_ITEM_11_0 			= UNIT_END + 0x0B6, // Int32
			PLAYER_VISIBLE_ITEM_11_0_01 			= UNIT_END + 0x0B7, // Int32
			PLAYER_VISIBLE_ITEM_11_0_02 			= UNIT_END + 0x0B8, // Int32
			PLAYER_VISIBLE_ITEM_11_0_03 			= UNIT_END + 0x0B9, // Int32
			PLAYER_VISIBLE_ITEM_11_0_04 			= UNIT_END + 0x0BA, // Int32
			PLAYER_VISIBLE_ITEM_11_0_05 			= UNIT_END + 0x0BB, // Int32
			PLAYER_VISIBLE_ITEM_11_0_06 			= UNIT_END + 0x0BC, // Int32
			PLAYER_VISIBLE_ITEM_11_0_07 			= UNIT_END + 0x0BD, // Int32
			PLAYER_VISIBLE_ITEM_11_PROPERTIES   		= UNIT_END + 0x0BE, // Chars?
			PLAYER_VISIBLE_ITEM_11_CREATOR 			= UNIT_END + 0x0BF, // GUID
			PLAYER_VISIBLE_ITEM_11_CREATOR_01 		= UNIT_END + 0x0C0, // GUID
			PLAYER_VISIBLE_ITEM_12_0 			= UNIT_END + 0x0C1, // Int32
			PLAYER_VISIBLE_ITEM_12_0_01 			= UNIT_END + 0x0C2, // Int32
			PLAYER_VISIBLE_ITEM_12_0_02 			= UNIT_END + 0x0C3, // Int32
			PLAYER_VISIBLE_ITEM_12_0_03 			= UNIT_END + 0x0C4, // Int32
			PLAYER_VISIBLE_ITEM_12_0_04 			= UNIT_END + 0x0C5, // Int32
			PLAYER_VISIBLE_ITEM_12_0_05 			= UNIT_END + 0x0C6, // Int32
			PLAYER_VISIBLE_ITEM_12_0_06 			= UNIT_END + 0x0C7, // Int32
			PLAYER_VISIBLE_ITEM_12_0_07 			= UNIT_END + 0x0C8, // Int32
			PLAYER_VISIBLE_ITEM_12_PROPERTIES   		= UNIT_END + 0x0C9, // Chars?
			PLAYER_VISIBLE_ITEM_12_CREATOR 			= UNIT_END + 0x0CA, // GUID
			PLAYER_VISIBLE_ITEM_12_CREATOR_01 		= UNIT_END + 0x0CB, // GUID
			PLAYER_VISIBLE_ITEM_13_0 			= UNIT_END + 0x0CC, // Int32
			PLAYER_VISIBLE_ITEM_13_0_01 			= UNIT_END + 0x0CD, // Int32
			PLAYER_VISIBLE_ITEM_13_0_02 			= UNIT_END + 0x0CE, // Int32
			PLAYER_VISIBLE_ITEM_13_0_03 			= UNIT_END + 0x0CF, // Int32
			PLAYER_VISIBLE_ITEM_13_0_04 			= UNIT_END + 0x0D0, // Int32
			PLAYER_VISIBLE_ITEM_13_0_05 			= UNIT_END + 0x0D1, // Int32
			PLAYER_VISIBLE_ITEM_13_0_06 			= UNIT_END + 0x0D2, // Int32
			PLAYER_VISIBLE_ITEM_13_0_07 			= UNIT_END + 0x0D3, // Int32
			PLAYER_VISIBLE_ITEM_13_PROPERTIES   		= UNIT_END + 0x0D4, // Chars?
			PLAYER_VISIBLE_ITEM_13_CREATOR 			= UNIT_END + 0x0D5, // GUID
			PLAYER_VISIBLE_ITEM_13_CREATOR_01 		= UNIT_END + 0x0D6, // GUID
			PLAYER_VISIBLE_ITEM_14_0 			= UNIT_END + 0x0D7, // Int32
			PLAYER_VISIBLE_ITEM_14_0_01 			= UNIT_END + 0x0D8, // Int32
			PLAYER_VISIBLE_ITEM_14_0_02 			= UNIT_END + 0x0D9, // Int32
			PLAYER_VISIBLE_ITEM_14_0_03 			= UNIT_END + 0x0DA, // Int32
			PLAYER_VISIBLE_ITEM_14_0_04 			= UNIT_END + 0x0DB, // Int32
			PLAYER_VISIBLE_ITEM_14_0_05 			= UNIT_END + 0x0DC, // Int32
			PLAYER_VISIBLE_ITEM_14_0_06 			= UNIT_END + 0x0DD, // Int32
			PLAYER_VISIBLE_ITEM_14_0_07 			= UNIT_END + 0x0DE, // Int32
			PLAYER_VISIBLE_ITEM_14_PROPERTIES   		= UNIT_END + 0x0DF, // Chars?
			PLAYER_VISIBLE_ITEM_14_CREATOR 			= UNIT_END + 0x0E0, // GUID
			PLAYER_VISIBLE_ITEM_14_CREATOR_01 		= UNIT_END + 0x0E1, // GUID
			PLAYER_VISIBLE_ITEM_15_0 			= UNIT_END + 0x0E2, // Int32
			PLAYER_VISIBLE_ITEM_15_0_01 			= UNIT_END + 0x0E3, // Int32
			PLAYER_VISIBLE_ITEM_15_0_02 			= UNIT_END + 0x0E4, // Int32
			PLAYER_VISIBLE_ITEM_15_0_03 			= UNIT_END + 0x0E5, // Int32
			PLAYER_VISIBLE_ITEM_15_0_04 			= UNIT_END + 0x0E6, // Int32
			PLAYER_VISIBLE_ITEM_15_0_05 			= UNIT_END + 0x0E7, // Int32
			PLAYER_VISIBLE_ITEM_15_0_06 			= UNIT_END + 0x0E8, // Int32
			PLAYER_VISIBLE_ITEM_15_0_07 			= UNIT_END + 0x0E9, // Int32
			PLAYER_VISIBLE_ITEM_15_PROPERTIES   		= UNIT_END + 0x0EA, // Chars?
			PLAYER_VISIBLE_ITEM_15_CREATOR 			= UNIT_END + 0x0EB, // GUID
			PLAYER_VISIBLE_ITEM_15_CREATOR_01 		= UNIT_END + 0x0EC, // GUID
			PLAYER_VISIBLE_ITEM_16_0 			= UNIT_END + 0x0ED, // Int32
			PLAYER_VISIBLE_ITEM_16_0_01 			= UNIT_END + 0x0EE, // Int32
			PLAYER_VISIBLE_ITEM_16_0_02 			= UNIT_END + 0x0EF, // Int32
			PLAYER_VISIBLE_ITEM_16_0_03 			= UNIT_END + 0x0F0, // Int32
			PLAYER_VISIBLE_ITEM_16_0_04 			= UNIT_END + 0x0F1, // Int32
			PLAYER_VISIBLE_ITEM_16_0_05 			= UNIT_END + 0x0F2, // Int32
			PLAYER_VISIBLE_ITEM_16_0_06 			= UNIT_END + 0x0F3, // Int32
			PLAYER_VISIBLE_ITEM_16_0_07 			= UNIT_END + 0x0F4, // Int32
			PLAYER_VISIBLE_ITEM_16_PROPERTIES   		= UNIT_END + 0x0F5, // Chars?
			PLAYER_VISIBLE_ITEM_16_CREATOR 			= UNIT_END + 0x0F6, // GUID
			PLAYER_VISIBLE_ITEM_16_CREATOR_01 		= UNIT_END + 0x0F7, // GUID
			PLAYER_VISIBLE_ITEM_17_0 			= UNIT_END + 0x0F8, // Int32
			PLAYER_VISIBLE_ITEM_17_0_01 			= UNIT_END + 0x0F9, // Int32
			PLAYER_VISIBLE_ITEM_17_0_02 			= UNIT_END + 0x0FA, // Int32
			PLAYER_VISIBLE_ITEM_17_0_03 			= UNIT_END + 0x0FB, // Int32
			PLAYER_VISIBLE_ITEM_17_0_04 			= UNIT_END + 0x0FC, // Int32
			PLAYER_VISIBLE_ITEM_17_0_05 			= UNIT_END + 0x0FD, // Int32
			PLAYER_VISIBLE_ITEM_17_0_06 			= UNIT_END + 0x0FE, // Int32
			PLAYER_VISIBLE_ITEM_17_0_07 			= UNIT_END + 0x0FF, // Int32
			PLAYER_VISIBLE_ITEM_17_PROPERTIES   		= UNIT_END + 0x100, // Chars?
			PLAYER_VISIBLE_ITEM_17_CREATOR 			= UNIT_END + 0x101, // GUID
			PLAYER_VISIBLE_ITEM_17_CREATOR_01 		= UNIT_END + 0x102, // GUID
			PLAYER_VISIBLE_ITEM_18_0 			= UNIT_END + 0x103, // Int32
			PLAYER_VISIBLE_ITEM_18_0_01 			= UNIT_END + 0x104, // Int32
			PLAYER_VISIBLE_ITEM_18_0_02 			= UNIT_END + 0x105, // Int32
			PLAYER_VISIBLE_ITEM_18_0_03 			= UNIT_END + 0x106, // Int32
			PLAYER_VISIBLE_ITEM_18_0_04 			= UNIT_END + 0x107, // Int32
			PLAYER_VISIBLE_ITEM_18_0_05 			= UNIT_END + 0x108, // Int32
			PLAYER_VISIBLE_ITEM_18_0_06 			= UNIT_END + 0x109, // Int32
			PLAYER_VISIBLE_ITEM_18_0_07 			= UNIT_END + 0x10A, // Int32
			PLAYER_VISIBLE_ITEM_18_PROPERTIES   		= UNIT_END + 0x10B, // Chars?
			PLAYER_VISIBLE_ITEM_18_CREATOR 			= UNIT_END + 0x10C, // GUID
			PLAYER_VISIBLE_ITEM_18_CREATOR_01 		= UNIT_END + 0x10D, // GUID
			PLAYER_VISIBLE_ITEM_19_0 			= UNIT_END + 0x10E, // Int32
			PLAYER_VISIBLE_ITEM_19_0_01 			= UNIT_END + 0x10F, // Int32
			PLAYER_VISIBLE_ITEM_19_0_02 			= UNIT_END + 0x110, // Int32
			PLAYER_VISIBLE_ITEM_19_0_03 			= UNIT_END + 0x111, // Int32
			PLAYER_VISIBLE_ITEM_19_0_04 			= UNIT_END + 0x112, // Int32
			PLAYER_VISIBLE_ITEM_19_0_05 			= UNIT_END + 0x113, // Int32
			PLAYER_VISIBLE_ITEM_19_0_06 			= UNIT_END + 0x114, // Int32
			PLAYER_VISIBLE_ITEM_19_0_07 			= UNIT_END + 0x115, // Int32
			PLAYER_VISIBLE_ITEM_19_PROPERTIES   		= UNIT_END + 0x116, // Chars?
			PLAYER_VISIBLE_ITEM_19_CREATOR 			= UNIT_END + 0x117, // GUID
			PLAYER_VISIBLE_ITEM_19_CREATOR_01 		= UNIT_END + 0x118, // GUID
			PLAYER_FIELD_PAD_0                  		= UNIT_END + 0x119, // Int32
			PLAYER_FIELD_INV_SLOT_HEAD 			= UNIT_END + 0x11A, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_01 			= UNIT_END + 0x11B, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_02 			= UNIT_END + 0x11C, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_03 			= UNIT_END + 0x11D, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_04 			= UNIT_END + 0x11E, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_05 			= UNIT_END + 0x11F, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_06 			= UNIT_END + 0x120, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_07 			= UNIT_END + 0x121, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_08 			= UNIT_END + 0x122, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_09 			= UNIT_END + 0x123, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_10 			= UNIT_END + 0x124, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_11 			= UNIT_END + 0x125, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_12 			= UNIT_END + 0x126, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_13 			= UNIT_END + 0x127, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_14 			= UNIT_END + 0x128, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_15 			= UNIT_END + 0x129, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_16 			= UNIT_END + 0x12A, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_17 			= UNIT_END + 0x12B, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_18 			= UNIT_END + 0x12C, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_19 			= UNIT_END + 0x12D, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_20 			= UNIT_END + 0x12E, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_21 			= UNIT_END + 0x12F, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_22 			= UNIT_END + 0x130, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_23 			= UNIT_END + 0x131, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_24 			= UNIT_END + 0x132, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_25 			= UNIT_END + 0x133, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_26 			= UNIT_END + 0x134, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_27 			= UNIT_END + 0x135, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_28 			= UNIT_END + 0x136, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_29 			= UNIT_END + 0x137, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_30 			= UNIT_END + 0x138, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_31 			= UNIT_END + 0x139, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_32 			= UNIT_END + 0x13A, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_33 			= UNIT_END + 0x13B, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_34 			= UNIT_END + 0x13C, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_35 			= UNIT_END + 0x13D, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_36 			= UNIT_END + 0x13E, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_37 			= UNIT_END + 0x13F, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_38 			= UNIT_END + 0x140, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_39 			= UNIT_END + 0x141, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_40 			= UNIT_END + 0x142, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_41 			= UNIT_END + 0x143, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_42 			= UNIT_END + 0x144, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_43 			= UNIT_END + 0x145, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_44 			= UNIT_END + 0x146, // GUID
			PLAYER_FIELD_INV_SLOT_HEAD_45 			= UNIT_END + 0x147, // GUID
			PLAYER_FIELD_PACK_SLOT_1 			= UNIT_END + 0x148, // GUID
			PLAYER_FIELD_PACK_SLOT_1_01 			= UNIT_END + 0x149, // GUID
			PLAYER_FIELD_PACK_SLOT_1_02 			= UNIT_END + 0x14A, // GUID
			PLAYER_FIELD_PACK_SLOT_1_03 			= UNIT_END + 0x14B, // GUID
			PLAYER_FIELD_PACK_SLOT_1_04 			= UNIT_END + 0x14C, // GUID
			PLAYER_FIELD_PACK_SLOT_1_05 			= UNIT_END + 0x14D, // GUID
			PLAYER_FIELD_PACK_SLOT_1_06 			= UNIT_END + 0x14E, // GUID
			PLAYER_FIELD_PACK_SLOT_1_07 			= UNIT_END + 0x14F, // GUID
			PLAYER_FIELD_PACK_SLOT_1_08 			= UNIT_END + 0x150, // GUID
			PLAYER_FIELD_PACK_SLOT_1_09 			= UNIT_END + 0x151, // GUID
			PLAYER_FIELD_PACK_SLOT_1_10 			= UNIT_END + 0x152, // GUID
			PLAYER_FIELD_PACK_SLOT_1_11 			= UNIT_END + 0x153, // GUID
			PLAYER_FIELD_PACK_SLOT_1_12 			= UNIT_END + 0x154, // GUID
			PLAYER_FIELD_PACK_SLOT_1_13 			= UNIT_END + 0x155, // GUID
			PLAYER_FIELD_PACK_SLOT_1_14 			= UNIT_END + 0x156, // GUID
			PLAYER_FIELD_PACK_SLOT_1_15 			= UNIT_END + 0x157, // GUID
			PLAYER_FIELD_PACK_SLOT_1_16 			= UNIT_END + 0x158, // GUID
			PLAYER_FIELD_PACK_SLOT_1_17 			= UNIT_END + 0x159, // GUID
			PLAYER_FIELD_PACK_SLOT_1_18 			= UNIT_END + 0x15A, // GUID
			PLAYER_FIELD_PACK_SLOT_1_19 			= UNIT_END + 0x15B, // GUID
			PLAYER_FIELD_PACK_SLOT_1_20 			= UNIT_END + 0x15C, // GUID
			PLAYER_FIELD_PACK_SLOT_1_21 			= UNIT_END + 0x15D, // GUID
			PLAYER_FIELD_PACK_SLOT_1_22 			= UNIT_END + 0x15E, // GUID
			PLAYER_FIELD_PACK_SLOT_1_23 			= UNIT_END + 0x15F, // GUID
			PLAYER_FIELD_PACK_SLOT_1_24 			= UNIT_END + 0x160, // GUID
			PLAYER_FIELD_PACK_SLOT_1_25 			= UNIT_END + 0x161, // GUID
			PLAYER_FIELD_PACK_SLOT_1_26 			= UNIT_END + 0x162, // GUID
			PLAYER_FIELD_PACK_SLOT_1_27 			= UNIT_END + 0x163, // GUID
			PLAYER_FIELD_PACK_SLOT_1_28 			= UNIT_END + 0x164, // GUID
			PLAYER_FIELD_PACK_SLOT_1_29 			= UNIT_END + 0x165, // GUID
			PLAYER_FIELD_PACK_SLOT_1_30 			= UNIT_END + 0x166, // GUID
			PLAYER_FIELD_PACK_SLOT_1_31 			= UNIT_END + 0x167, // GUID
			PLAYER_FIELD_BANK_SLOT_1 			= UNIT_END + 0x168, // GUID
			PLAYER_FIELD_BANK_SLOT_1_01 			= UNIT_END + 0x169, // GUID
			PLAYER_FIELD_BANK_SLOT_1_02 			= UNIT_END + 0x16A, // GUID
			PLAYER_FIELD_BANK_SLOT_1_03 			= UNIT_END + 0x16B, // GUID
			PLAYER_FIELD_BANK_SLOT_1_04 			= UNIT_END + 0x16C, // GUID
			PLAYER_FIELD_BANK_SLOT_1_05 			= UNIT_END + 0x16D, // GUID
			PLAYER_FIELD_BANK_SLOT_1_06 			= UNIT_END + 0x16E, // GUID
			PLAYER_FIELD_BANK_SLOT_1_07 			= UNIT_END + 0x16F, // GUID
			PLAYER_FIELD_BANK_SLOT_1_08 			= UNIT_END + 0x170, // GUID
			PLAYER_FIELD_BANK_SLOT_1_09 			= UNIT_END + 0x171, // GUID
			PLAYER_FIELD_BANK_SLOT_1_10 			= UNIT_END + 0x172, // GUID
			PLAYER_FIELD_BANK_SLOT_1_11 			= UNIT_END + 0x173, // GUID
			PLAYER_FIELD_BANK_SLOT_1_12 			= UNIT_END + 0x174, // GUID
			PLAYER_FIELD_BANK_SLOT_1_13 			= UNIT_END + 0x175, // GUID
			PLAYER_FIELD_BANK_SLOT_1_14 			= UNIT_END + 0x176, // GUID
			PLAYER_FIELD_BANK_SLOT_1_15 			= UNIT_END + 0x177, // GUID
			PLAYER_FIELD_BANK_SLOT_1_16 			= UNIT_END + 0x178, // GUID
			PLAYER_FIELD_BANK_SLOT_1_17 			= UNIT_END + 0x179, // GUID
			PLAYER_FIELD_BANK_SLOT_1_18 			= UNIT_END + 0x17A, // GUID
			PLAYER_FIELD_BANK_SLOT_1_19 			= UNIT_END + 0x17B, // GUID
			PLAYER_FIELD_BANK_SLOT_1_20 			= UNIT_END + 0x17C, // GUID
			PLAYER_FIELD_BANK_SLOT_1_21 			= UNIT_END + 0x17D, // GUID
			PLAYER_FIELD_BANK_SLOT_1_22 			= UNIT_END + 0x17E, // GUID
			PLAYER_FIELD_BANK_SLOT_1_23 			= UNIT_END + 0x17F, // GUID
			PLAYER_FIELD_BANK_SLOT_1_24 			= UNIT_END + 0x180, // GUID
			PLAYER_FIELD_BANK_SLOT_1_25 			= UNIT_END + 0x181, // GUID
			PLAYER_FIELD_BANK_SLOT_1_26 			= UNIT_END + 0x182, // GUID
			PLAYER_FIELD_BANK_SLOT_1_27 			= UNIT_END + 0x183, // GUID
			PLAYER_FIELD_BANK_SLOT_1_28 			= UNIT_END + 0x184, // GUID
			PLAYER_FIELD_BANK_SLOT_1_29 			= UNIT_END + 0x185, // GUID
			PLAYER_FIELD_BANK_SLOT_1_30 			= UNIT_END + 0x186, // GUID
			PLAYER_FIELD_BANK_SLOT_1_31 			= UNIT_END + 0x187, // GUID
			PLAYER_FIELD_BANK_SLOT_1_32 			= UNIT_END + 0x188, // GUID
			PLAYER_FIELD_BANK_SLOT_1_33 			= UNIT_END + 0x189, // GUID
			PLAYER_FIELD_BANK_SLOT_1_34 			= UNIT_END + 0x18A, // GUID
			PLAYER_FIELD_BANK_SLOT_1_35 			= UNIT_END + 0x18B, // GUID
			PLAYER_FIELD_BANK_SLOT_1_36 			= UNIT_END + 0x18C, // GUID
			PLAYER_FIELD_BANK_SLOT_1_37 			= UNIT_END + 0x18D, // GUID
			PLAYER_FIELD_BANK_SLOT_1_38 			= UNIT_END + 0x18E, // GUID
			PLAYER_FIELD_BANK_SLOT_1_39 			= UNIT_END + 0x18F, // GUID
			PLAYER_FIELD_BANK_SLOT_1_40 			= UNIT_END + 0x190, // GUID
			PLAYER_FIELD_BANK_SLOT_1_41 			= UNIT_END + 0x191, // GUID
			PLAYER_FIELD_BANK_SLOT_1_42 			= UNIT_END + 0x192, // GUID
			PLAYER_FIELD_BANK_SLOT_1_43 			= UNIT_END + 0x193, // GUID
			PLAYER_FIELD_BANK_SLOT_1_44 			= UNIT_END + 0x194, // GUID
			PLAYER_FIELD_BANK_SLOT_1_45 			= UNIT_END + 0x195, // GUID
			PLAYER_FIELD_BANK_SLOT_1_46 			= UNIT_END + 0x196, // GUID
			PLAYER_FIELD_BANK_SLOT_1_47 			= UNIT_END + 0x197, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1 			= UNIT_END + 0x198, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_01 			= UNIT_END + 0x199, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_02 			= UNIT_END + 0x19A, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_03 			= UNIT_END + 0x19B, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_04 			= UNIT_END + 0x19C, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_05 			= UNIT_END + 0x19D, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_06 			= UNIT_END + 0x19E, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_07 			= UNIT_END + 0x19F, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_08 			= UNIT_END + 0x1A0, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_09 			= UNIT_END + 0x1A1, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_10 			= UNIT_END + 0x1A2, // GUID
			PLAYER_FIELD_BANKBAG_SLOT_1_11 			= UNIT_END + 0x1A3, // GUID
			PLAYER_FIELD_VENDORBUYBACK_SLOT 		= UNIT_END + 0x1A4, // GUID
			PLAYER_FIELD_VENDORBUYBACK_SLOT_01 		= UNIT_END + 0x1A5, // GUID
			PLAYER_FARSIGHT 				= UNIT_END + 0x1A6, // GUID
			PLAYER_FARSIGHT_01 				= UNIT_END + 0x1A7, // GUID
			PLAYER__FIELD_COMBO_TARGET 			= UNIT_END + 0x1A8, // GUID
			PLAYER__FIELD_COMBO_TARGET_01 			= UNIT_END + 0x1A9, // GUID
			PLAYER_FIELD_BUYBACK_NPC 			= UNIT_END + 0x1AA, // GUID
			PLAYER_FIELD_BUYBACK_NPC_01 			= UNIT_END + 0x1AB, // GUID
			PLAYER_XP                          	 	= UNIT_END + 0x1AC, // Int32
			PLAYER_NEXT_LEVEL_XP                		= UNIT_END + 0x1AD, // Int32
			PLAYER_SKILL_INFO_1_1 				= UNIT_END + 0x1AE, // Chars?
			PLAYER_SKILL_INFO_1_1_01 			= UNIT_END + 0x1AF, // Chars?
			PLAYER_SKILL_INFO_1_1_02 			= UNIT_END + 0x1B0, // Chars?
			PLAYER_SKILL_INFO_1_1_03 			= UNIT_END + 0x1B1, // Chars?
			PLAYER_SKILL_INFO_1_1_04 			= UNIT_END + 0x1B2, // Chars?
			PLAYER_SKILL_INFO_1_1_05 			= UNIT_END + 0x1B3, // Chars?
			PLAYER_SKILL_INFO_1_1_06 			= UNIT_END + 0x1B4, // Chars?
			PLAYER_SKILL_INFO_1_1_07 			= UNIT_END + 0x1B5, // Chars?
			PLAYER_SKILL_INFO_1_1_08 			= UNIT_END + 0x1B6, // Chars?
			PLAYER_SKILL_INFO_1_1_09 			= UNIT_END + 0x1B7, // Chars?
			PLAYER_SKILL_INFO_1_1_10 			= UNIT_END + 0x1B8, // Chars?
			PLAYER_SKILL_INFO_1_1_11 			= UNIT_END + 0x1B9, // Chars?
			PLAYER_SKILL_INFO_1_1_12 			= UNIT_END + 0x1BA, // Chars?
			PLAYER_SKILL_INFO_1_1_13 			= UNIT_END + 0x1BB, // Chars?
			PLAYER_SKILL_INFO_1_1_14 			= UNIT_END + 0x1BC, // Chars?
			PLAYER_SKILL_INFO_1_1_15 			= UNIT_END + 0x1BD, // Chars?
			PLAYER_SKILL_INFO_1_1_16 			= UNIT_END + 0x1BE, // Chars?
			PLAYER_SKILL_INFO_1_1_17 			= UNIT_END + 0x1BF, // Chars?
			PLAYER_SKILL_INFO_1_1_18 			= UNIT_END + 0x1C0, // Chars?
			PLAYER_SKILL_INFO_1_1_19 			= UNIT_END + 0x1C1, // Chars?
			PLAYER_SKILL_INFO_1_1_20 			= UNIT_END + 0x1C2, // Chars?
			PLAYER_SKILL_INFO_1_1_21 			= UNIT_END + 0x1C3, // Chars?
			PLAYER_SKILL_INFO_1_1_22 			= UNIT_END + 0x1C4, // Chars?
			PLAYER_SKILL_INFO_1_1_23 			= UNIT_END + 0x1C5, // Chars?
			PLAYER_SKILL_INFO_1_1_24 			= UNIT_END + 0x1C6, // Chars?
			PLAYER_SKILL_INFO_1_1_25 			= UNIT_END + 0x1C7, // Chars?
			PLAYER_SKILL_INFO_1_1_26 			= UNIT_END + 0x1C8, // Chars?
			PLAYER_SKILL_INFO_1_1_27 			= UNIT_END + 0x1C9, // Chars?
			PLAYER_SKILL_INFO_1_1_28 			= UNIT_END + 0x1CA, // Chars?
			PLAYER_SKILL_INFO_1_1_29 			= UNIT_END + 0x1CB, // Chars?
			PLAYER_SKILL_INFO_1_1_30 			= UNIT_END + 0x1CC, // Chars?
			PLAYER_SKILL_INFO_1_1_31 			= UNIT_END + 0x1CD, // Chars?
			PLAYER_SKILL_INFO_1_1_32 			= UNIT_END + 0x1CE, // Chars?
			PLAYER_SKILL_INFO_1_1_33 			= UNIT_END + 0x1CF, // Chars?
			PLAYER_SKILL_INFO_1_1_34 			= UNIT_END + 0x1D0, // Chars?
			PLAYER_SKILL_INFO_1_1_35 			= UNIT_END + 0x1D1, // Chars?
			PLAYER_SKILL_INFO_1_1_36 			= UNIT_END + 0x1D2, // Chars?
			PLAYER_SKILL_INFO_1_1_37 			= UNIT_END + 0x1D3, // Chars?
			PLAYER_SKILL_INFO_1_1_38 			= UNIT_END + 0x1D4, // Chars?
			PLAYER_SKILL_INFO_1_1_39 			= UNIT_END + 0x1D5, // Chars?
			PLAYER_SKILL_INFO_1_1_40 			= UNIT_END + 0x1D6, // Chars?
			PLAYER_SKILL_INFO_1_1_41 			= UNIT_END + 0x1D7, // Chars?
			PLAYER_SKILL_INFO_1_1_42 			= UNIT_END + 0x1D8, // Chars?
			PLAYER_SKILL_INFO_1_1_43 			= UNIT_END + 0x1D9, // Chars?
			PLAYER_SKILL_INFO_1_1_44 			= UNIT_END + 0x1DA, // Chars?
			PLAYER_SKILL_INFO_1_1_45 			= UNIT_END + 0x1DB, // Chars?
			PLAYER_SKILL_INFO_1_1_46 			= UNIT_END + 0x1DC, // Chars?
			PLAYER_SKILL_INFO_1_1_47 			= UNIT_END + 0x1DD, // Chars?
			PLAYER_SKILL_INFO_1_1_48 			= UNIT_END + 0x1DE, // Chars?
			PLAYER_SKILL_INFO_1_1_49 			= UNIT_END + 0x1DF, // Chars?
			PLAYER_SKILL_INFO_1_1_50 			= UNIT_END + 0x1E0, // Chars?
			PLAYER_SKILL_INFO_1_1_51 			= UNIT_END + 0x1E1, // Chars?
			PLAYER_SKILL_INFO_1_1_52 			= UNIT_END + 0x1E2, // Chars?
			PLAYER_SKILL_INFO_1_1_53 			= UNIT_END + 0x1E3, // Chars?
			PLAYER_SKILL_INFO_1_1_54 			= UNIT_END + 0x1E4, // Chars?
			PLAYER_SKILL_INFO_1_1_55 			= UNIT_END + 0x1E5, // Chars?
			PLAYER_SKILL_INFO_1_1_56 			= UNIT_END + 0x1E6, // Chars?
			PLAYER_SKILL_INFO_1_1_57 			= UNIT_END + 0x1E7, // Chars?
			PLAYER_SKILL_INFO_1_1_58 			= UNIT_END + 0x1E8, // Chars?
			PLAYER_SKILL_INFO_1_1_59 			= UNIT_END + 0x1E9, // Chars?
			PLAYER_SKILL_INFO_1_1_60 			= UNIT_END + 0x1EA, // Chars?
			PLAYER_SKILL_INFO_1_1_61 			= UNIT_END + 0x1EB, // Chars?
			PLAYER_SKILL_INFO_1_1_62 			= UNIT_END + 0x1EC, // Chars?
			PLAYER_SKILL_INFO_1_1_63 			= UNIT_END + 0x1ED, // Chars?
			PLAYER_SKILL_INFO_1_1_64 			= UNIT_END + 0x1EE, // Chars?
			PLAYER_SKILL_INFO_1_1_65 			= UNIT_END + 0x1EF, // Chars?
			PLAYER_SKILL_INFO_1_1_66 			= UNIT_END + 0x1F0, // Chars?
			PLAYER_SKILL_INFO_1_1_67 			= UNIT_END + 0x1F1, // Chars?
			PLAYER_SKILL_INFO_1_1_68 			= UNIT_END + 0x1F2, // Chars?
			PLAYER_SKILL_INFO_1_1_69 			= UNIT_END + 0x1F3, // Chars?
			PLAYER_SKILL_INFO_1_1_70 			= UNIT_END + 0x1F4, // Chars?
			PLAYER_SKILL_INFO_1_1_71 			= UNIT_END + 0x1F5, // Chars?
			PLAYER_SKILL_INFO_1_1_72 			= UNIT_END + 0x1F6, // Chars?
			PLAYER_SKILL_INFO_1_1_73 			= UNIT_END + 0x1F7, // Chars?
			PLAYER_SKILL_INFO_1_1_74 			= UNIT_END + 0x1F8, // Chars?
			PLAYER_SKILL_INFO_1_1_75 			= UNIT_END + 0x1F9, // Chars?
			PLAYER_SKILL_INFO_1_1_76 			= UNIT_END + 0x1FA, // Chars?
			PLAYER_SKILL_INFO_1_1_77 			= UNIT_END + 0x1FB, // Chars?
			PLAYER_SKILL_INFO_1_1_78 			= UNIT_END + 0x1FC, // Chars?
			PLAYER_SKILL_INFO_1_1_79 			= UNIT_END + 0x1FD, // Chars?
			PLAYER_SKILL_INFO_1_1_80 			= UNIT_END + 0x1FE, // Chars?
			PLAYER_SKILL_INFO_1_1_81 			= UNIT_END + 0x1FF, // Chars?
			PLAYER_SKILL_INFO_1_1_82 			= UNIT_END + 0x200, // Chars?
			PLAYER_SKILL_INFO_1_1_83 			= UNIT_END + 0x201, // Chars?
			PLAYER_SKILL_INFO_1_1_84 			= UNIT_END + 0x202, // Chars?
			PLAYER_SKILL_INFO_1_1_85 			= UNIT_END + 0x203, // Chars?
			PLAYER_SKILL_INFO_1_1_86 			= UNIT_END + 0x204, // Chars?
			PLAYER_SKILL_INFO_1_1_87 			= UNIT_END + 0x205, // Chars?
			PLAYER_SKILL_INFO_1_1_88 			= UNIT_END + 0x206, // Chars?
			PLAYER_SKILL_INFO_1_1_89 			= UNIT_END + 0x207, // Chars?
			PLAYER_SKILL_INFO_1_1_90 			= UNIT_END + 0x208, // Chars?
			PLAYER_SKILL_INFO_1_1_91 			= UNIT_END + 0x209, // Chars?
			PLAYER_SKILL_INFO_1_1_92 			= UNIT_END + 0x20A, // Chars?
			PLAYER_SKILL_INFO_1_1_93 			= UNIT_END + 0x20B, // Chars?
			PLAYER_SKILL_INFO_1_1_94 			= UNIT_END + 0x20C, // Chars?
			PLAYER_SKILL_INFO_1_1_95 			= UNIT_END + 0x20D, // Chars?
			PLAYER_SKILL_INFO_1_1_96 			= UNIT_END + 0x20E, // Chars?
			PLAYER_SKILL_INFO_1_1_97 			= UNIT_END + 0x20F, // Chars?
			PLAYER_SKILL_INFO_1_1_98 			= UNIT_END + 0x210, // Chars?
			PLAYER_SKILL_INFO_1_1_99 			= UNIT_END + 0x211, // Chars?
			PLAYER_SKILL_INFO_1_1_100 			= UNIT_END + 0x212, // Chars?
			PLAYER_SKILL_INFO_1_1_101 			= UNIT_END + 0x213, // Chars?
			PLAYER_SKILL_INFO_1_1_102 			= UNIT_END + 0x214, // Chars?
			PLAYER_SKILL_INFO_1_1_103 			= UNIT_END + 0x215, // Chars?
			PLAYER_SKILL_INFO_1_1_104 			= UNIT_END + 0x216, // Chars?
			PLAYER_SKILL_INFO_1_1_105 			= UNIT_END + 0x217, // Chars?
			PLAYER_SKILL_INFO_1_1_106 			= UNIT_END + 0x218, // Chars?
			PLAYER_SKILL_INFO_1_1_107 			= UNIT_END + 0x219, // Chars?
			PLAYER_SKILL_INFO_1_1_108 			= UNIT_END + 0x21A, // Chars?
			PLAYER_SKILL_INFO_1_1_109 			= UNIT_END + 0x21B, // Chars?
			PLAYER_SKILL_INFO_1_1_110 			= UNIT_END + 0x21C, // Chars?
			PLAYER_SKILL_INFO_1_1_111 			= UNIT_END + 0x21D, // Chars?
			PLAYER_SKILL_INFO_1_1_112 			= UNIT_END + 0x21E, // Chars?
			PLAYER_SKILL_INFO_1_1_113 			= UNIT_END + 0x21F, // Chars?
			PLAYER_SKILL_INFO_1_1_114 			= UNIT_END + 0x220, // Chars?
			PLAYER_SKILL_INFO_1_1_115 			= UNIT_END + 0x221, // Chars?
			PLAYER_SKILL_INFO_1_1_116 			= UNIT_END + 0x222, // Chars?
			PLAYER_SKILL_INFO_1_1_117 			= UNIT_END + 0x223, // Chars?
			PLAYER_SKILL_INFO_1_1_118 			= UNIT_END + 0x224, // Chars?
			PLAYER_SKILL_INFO_1_1_119 			= UNIT_END + 0x225, // Chars?
			PLAYER_SKILL_INFO_1_1_120 			= UNIT_END + 0x226, // Chars?
			PLAYER_SKILL_INFO_1_1_121 			= UNIT_END + 0x227, // Chars?
			PLAYER_SKILL_INFO_1_1_122 			= UNIT_END + 0x228, // Chars?
			PLAYER_SKILL_INFO_1_1_123 			= UNIT_END + 0x229, // Chars?
			PLAYER_SKILL_INFO_1_1_124 			= UNIT_END + 0x22A, // Chars?
			PLAYER_SKILL_INFO_1_1_125 			= UNIT_END + 0x22B, // Chars?
			PLAYER_SKILL_INFO_1_1_126 			= UNIT_END + 0x22C, // Chars?
			PLAYER_SKILL_INFO_1_1_127 			= UNIT_END + 0x22D, // Chars?
			PLAYER_SKILL_INFO_1_1_128 			= UNIT_END + 0x22E, // Chars?
			PLAYER_SKILL_INFO_1_1_129 			= UNIT_END + 0x22F, // Chars?
			PLAYER_SKILL_INFO_1_1_130 			= UNIT_END + 0x230, // Chars?
			PLAYER_SKILL_INFO_1_1_131 			= UNIT_END + 0x231, // Chars?
			PLAYER_SKILL_INFO_1_1_132 			= UNIT_END + 0x232, // Chars?
			PLAYER_SKILL_INFO_1_1_133 			= UNIT_END + 0x233, // Chars?
			PLAYER_SKILL_INFO_1_1_134 			= UNIT_END + 0x234, // Chars?
			PLAYER_SKILL_INFO_1_1_135 			= UNIT_END + 0x235, // Chars?
			PLAYER_SKILL_INFO_1_1_136 			= UNIT_END + 0x236, // Chars?
			PLAYER_SKILL_INFO_1_1_137 			= UNIT_END + 0x237, // Chars?
			PLAYER_SKILL_INFO_1_1_138 			= UNIT_END + 0x238, // Chars?
			PLAYER_SKILL_INFO_1_1_139 			= UNIT_END + 0x239, // Chars?
			PLAYER_SKILL_INFO_1_1_140 			= UNIT_END + 0x23A, // Chars?
			PLAYER_SKILL_INFO_1_1_141 			= UNIT_END + 0x23B, // Chars?
			PLAYER_SKILL_INFO_1_1_142 			= UNIT_END + 0x23C, // Chars?
			PLAYER_SKILL_INFO_1_1_143 			= UNIT_END + 0x23D, // Chars?
			PLAYER_SKILL_INFO_1_1_144 			= UNIT_END + 0x23E, // Chars?
			PLAYER_SKILL_INFO_1_1_145 			= UNIT_END + 0x23F, // Chars?
			PLAYER_SKILL_INFO_1_1_146 			= UNIT_END + 0x240, // Chars?
			PLAYER_SKILL_INFO_1_1_147 			= UNIT_END + 0x241, // Chars?
			PLAYER_SKILL_INFO_1_1_148 			= UNIT_END + 0x242, // Chars?
			PLAYER_SKILL_INFO_1_1_149 			= UNIT_END + 0x243, // Chars?
			PLAYER_SKILL_INFO_1_1_150 			= UNIT_END + 0x244, // Chars?
			PLAYER_SKILL_INFO_1_1_151 			= UNIT_END + 0x245, // Chars?
			PLAYER_SKILL_INFO_1_1_152 			= UNIT_END + 0x246, // Chars?
			PLAYER_SKILL_INFO_1_1_153 			= UNIT_END + 0x247, // Chars?
			PLAYER_SKILL_INFO_1_1_154 			= UNIT_END + 0x248, // Chars?
			PLAYER_SKILL_INFO_1_1_155 			= UNIT_END + 0x249, // Chars?
			PLAYER_SKILL_INFO_1_1_156 			= UNIT_END + 0x24A, // Chars?
			PLAYER_SKILL_INFO_1_1_157 			= UNIT_END + 0x24B, // Chars?
			PLAYER_SKILL_INFO_1_1_158 			= UNIT_END + 0x24C, // Chars?
			PLAYER_SKILL_INFO_1_1_159 			= UNIT_END + 0x24D, // Chars?
			PLAYER_SKILL_INFO_1_1_160 			= UNIT_END + 0x24E, // Chars?
			PLAYER_SKILL_INFO_1_1_161 			= UNIT_END + 0x24F, // Chars?
			PLAYER_SKILL_INFO_1_1_162 			= UNIT_END + 0x250, // Chars?
			PLAYER_SKILL_INFO_1_1_163 			= UNIT_END + 0x251, // Chars?
			PLAYER_SKILL_INFO_1_1_164 			= UNIT_END + 0x252, // Chars?
			PLAYER_SKILL_INFO_1_1_165 			= UNIT_END + 0x253, // Chars?
			PLAYER_SKILL_INFO_1_1_166 			= UNIT_END + 0x254, // Chars?
			PLAYER_SKILL_INFO_1_1_167 			= UNIT_END + 0x255, // Chars?
			PLAYER_SKILL_INFO_1_1_168 			= UNIT_END + 0x256, // Chars?
			PLAYER_SKILL_INFO_1_1_169 			= UNIT_END + 0x257, // Chars?
			PLAYER_SKILL_INFO_1_1_170 			= UNIT_END + 0x258, // Chars?
			PLAYER_SKILL_INFO_1_1_171 			= UNIT_END + 0x259, // Chars?
			PLAYER_SKILL_INFO_1_1_172 			= UNIT_END + 0x25A, // Chars?
			PLAYER_SKILL_INFO_1_1_173 			= UNIT_END + 0x25B, // Chars?
			PLAYER_SKILL_INFO_1_1_174 			= UNIT_END + 0x25C, // Chars?
			PLAYER_SKILL_INFO_1_1_175 			= UNIT_END + 0x25D, // Chars?
			PLAYER_SKILL_INFO_1_1_176 			= UNIT_END + 0x25E, // Chars?
			PLAYER_SKILL_INFO_1_1_177 			= UNIT_END + 0x25F, // Chars?
			PLAYER_SKILL_INFO_1_1_178 			= UNIT_END + 0x260, // Chars?
			PLAYER_SKILL_INFO_1_1_179 			= UNIT_END + 0x261, // Chars?
			PLAYER_SKILL_INFO_1_1_180 			= UNIT_END + 0x262, // Chars?
			PLAYER_SKILL_INFO_1_1_181 			= UNIT_END + 0x263, // Chars?
			PLAYER_SKILL_INFO_1_1_182 			= UNIT_END + 0x264, // Chars?
			PLAYER_SKILL_INFO_1_1_183 			= UNIT_END + 0x265, // Chars?
			PLAYER_SKILL_INFO_1_1_184 			= UNIT_END + 0x266, // Chars?
			PLAYER_SKILL_INFO_1_1_185 			= UNIT_END + 0x267, // Chars?
			PLAYER_SKILL_INFO_1_1_186 			= UNIT_END + 0x268, // Chars?
			PLAYER_SKILL_INFO_1_1_187 			= UNIT_END + 0x269, // Chars?
			PLAYER_SKILL_INFO_1_1_188 			= UNIT_END + 0x26A, // Chars?
			PLAYER_SKILL_INFO_1_1_189 			= UNIT_END + 0x26B, // Chars?
			PLAYER_SKILL_INFO_1_1_190 			= UNIT_END + 0x26C, // Chars?
			PLAYER_SKILL_INFO_1_1_191 			= UNIT_END + 0x26D, // Chars?
			PLAYER_SKILL_INFO_1_1_192 			= UNIT_END + 0x26E, // Chars?
			PLAYER_SKILL_INFO_1_1_193 			= UNIT_END + 0x26F, // Chars?
			PLAYER_SKILL_INFO_1_1_194 			= UNIT_END + 0x270, // Chars?
			PLAYER_SKILL_INFO_1_1_195 			= UNIT_END + 0x271, // Chars?
			PLAYER_SKILL_INFO_1_1_196 			= UNIT_END + 0x272, // Chars?
			PLAYER_SKILL_INFO_1_1_197 			= UNIT_END + 0x273, // Chars?
			PLAYER_SKILL_INFO_1_1_198 			= UNIT_END + 0x274, // Chars?
			PLAYER_SKILL_INFO_1_1_199 			= UNIT_END + 0x275, // Chars?
			PLAYER_SKILL_INFO_1_1_200 			= UNIT_END + 0x276, // Chars?
			PLAYER_SKILL_INFO_1_1_201 			= UNIT_END + 0x277, // Chars?
			PLAYER_SKILL_INFO_1_1_202 			= UNIT_END + 0x278, // Chars?
			PLAYER_SKILL_INFO_1_1_203 			= UNIT_END + 0x279, // Chars?
			PLAYER_SKILL_INFO_1_1_204 			= UNIT_END + 0x27A, // Chars?
			PLAYER_SKILL_INFO_1_1_205 			= UNIT_END + 0x27B, // Chars?
			PLAYER_SKILL_INFO_1_1_206 			= UNIT_END + 0x27C, // Chars?
			PLAYER_SKILL_INFO_1_1_207 			= UNIT_END + 0x27D, // Chars?
			PLAYER_SKILL_INFO_1_1_208 			= UNIT_END + 0x27E, // Chars?
			PLAYER_SKILL_INFO_1_1_209 			= UNIT_END + 0x27F, // Chars?
			PLAYER_SKILL_INFO_1_1_210 			= UNIT_END + 0x280, // Chars?
			PLAYER_SKILL_INFO_1_1_211 			= UNIT_END + 0x281, // Chars?
			PLAYER_SKILL_INFO_1_1_212 			= UNIT_END + 0x282, // Chars?
			PLAYER_SKILL_INFO_1_1_213 			= UNIT_END + 0x283, // Chars?
			PLAYER_SKILL_INFO_1_1_214 			= UNIT_END + 0x284, // Chars?
			PLAYER_SKILL_INFO_1_1_215 			= UNIT_END + 0x285, // Chars?
			PLAYER_SKILL_INFO_1_1_216 			= UNIT_END + 0x286, // Chars?
			PLAYER_SKILL_INFO_1_1_217 			= UNIT_END + 0x287, // Chars?
			PLAYER_SKILL_INFO_1_1_218 			= UNIT_END + 0x288, // Chars?
			PLAYER_SKILL_INFO_1_1_219 			= UNIT_END + 0x289, // Chars?
			PLAYER_SKILL_INFO_1_1_220 			= UNIT_END + 0x28A, // Chars?
			PLAYER_SKILL_INFO_1_1_221 			= UNIT_END + 0x28B, // Chars?
			PLAYER_SKILL_INFO_1_1_222 			= UNIT_END + 0x28C, // Chars?
			PLAYER_SKILL_INFO_1_1_223 			= UNIT_END + 0x28D, // Chars?
			PLAYER_SKILL_INFO_1_1_224 			= UNIT_END + 0x28E, // Chars?
			PLAYER_SKILL_INFO_1_1_225 			= UNIT_END + 0x28F, // Chars?
			PLAYER_SKILL_INFO_1_1_226 			= UNIT_END + 0x290, // Chars?
			PLAYER_SKILL_INFO_1_1_227 			= UNIT_END + 0x291, // Chars?
			PLAYER_SKILL_INFO_1_1_228 			= UNIT_END + 0x292, // Chars?
			PLAYER_SKILL_INFO_1_1_229 			= UNIT_END + 0x293, // Chars?
			PLAYER_SKILL_INFO_1_1_230 			= UNIT_END + 0x294, // Chars?
			PLAYER_SKILL_INFO_1_1_231 			= UNIT_END + 0x295, // Chars?
			PLAYER_SKILL_INFO_1_1_232 			= UNIT_END + 0x296, // Chars?
			PLAYER_SKILL_INFO_1_1_233 			= UNIT_END + 0x297, // Chars?
			PLAYER_SKILL_INFO_1_1_234 			= UNIT_END + 0x298, // Chars?
			PLAYER_SKILL_INFO_1_1_235 			= UNIT_END + 0x299, // Chars?
			PLAYER_SKILL_INFO_1_1_236 			= UNIT_END + 0x29A, // Chars?
			PLAYER_SKILL_INFO_1_1_237 			= UNIT_END + 0x29B, // Chars?
			PLAYER_SKILL_INFO_1_1_238 			= UNIT_END + 0x29C, // Chars?
			PLAYER_SKILL_INFO_1_1_239 			= UNIT_END + 0x29D, // Chars?
			PLAYER_SKILL_INFO_1_1_240 			= UNIT_END + 0x29E, // Chars?
			PLAYER_SKILL_INFO_1_1_241 			= UNIT_END + 0x29F, // Chars?
			PLAYER_SKILL_INFO_1_1_242 			= UNIT_END + 0x2A0, // Chars?
			PLAYER_SKILL_INFO_1_1_243 			= UNIT_END + 0x2A1, // Chars?
			PLAYER_SKILL_INFO_1_1_244 			= UNIT_END + 0x2A2, // Chars?
			PLAYER_SKILL_INFO_1_1_245 			= UNIT_END + 0x2A3, // Chars?
			PLAYER_SKILL_INFO_1_1_246 			= UNIT_END + 0x2A4, // Chars?
			PLAYER_SKILL_INFO_1_1_247 			= UNIT_END + 0x2A5, // Chars?
			PLAYER_SKILL_INFO_1_1_248 			= UNIT_END + 0x2A6, // Chars?
			PLAYER_SKILL_INFO_1_1_249 			= UNIT_END + 0x2A7, // Chars?
			PLAYER_SKILL_INFO_1_1_250 			= UNIT_END + 0x2A8, // Chars?
			PLAYER_SKILL_INFO_1_1_251 			= UNIT_END + 0x2A9, // Chars?
			PLAYER_SKILL_INFO_1_1_252 			= UNIT_END + 0x2AA, // Chars?
			PLAYER_SKILL_INFO_1_1_253 			= UNIT_END + 0x2AB, // Chars?
			PLAYER_SKILL_INFO_1_1_254 			= UNIT_END + 0x2AC, // Chars?
			PLAYER_SKILL_INFO_1_1_255 			= UNIT_END + 0x2AD, // Chars?
			PLAYER_SKILL_INFO_1_1_256 			= UNIT_END + 0x2AE, // Chars?
			PLAYER_SKILL_INFO_1_1_257 			= UNIT_END + 0x2AF, // Chars?
			PLAYER_SKILL_INFO_1_1_258 			= UNIT_END + 0x2B0, // Chars?
			PLAYER_SKILL_INFO_1_1_259 			= UNIT_END + 0x2B1, // Chars?
			PLAYER_SKILL_INFO_1_1_260 			= UNIT_END + 0x2B2, // Chars?
			PLAYER_SKILL_INFO_1_1_261 			= UNIT_END + 0x2B3, // Chars?
			PLAYER_SKILL_INFO_1_1_262 			= UNIT_END + 0x2B4, // Chars?
			PLAYER_SKILL_INFO_1_1_263 			= UNIT_END + 0x2B5, // Chars?
			PLAYER_SKILL_INFO_1_1_264 			= UNIT_END + 0x2B6, // Chars?
			PLAYER_SKILL_INFO_1_1_265 			= UNIT_END + 0x2B7, // Chars?
			PLAYER_SKILL_INFO_1_1_266 			= UNIT_END + 0x2B8, // Chars?
			PLAYER_SKILL_INFO_1_1_267 			= UNIT_END + 0x2B9, // Chars?
			PLAYER_SKILL_INFO_1_1_268 			= UNIT_END + 0x2BA, // Chars?
			PLAYER_SKILL_INFO_1_1_269 			= UNIT_END + 0x2BB, // Chars?
			PLAYER_SKILL_INFO_1_1_270 			= UNIT_END + 0x2BC, // Chars?
			PLAYER_SKILL_INFO_1_1_271 			= UNIT_END + 0x2BD, // Chars?
			PLAYER_SKILL_INFO_1_1_272 			= UNIT_END + 0x2BE, // Chars?
			PLAYER_SKILL_INFO_1_1_273 			= UNIT_END + 0x2BF, // Chars?
			PLAYER_SKILL_INFO_1_1_274 			= UNIT_END + 0x2C0, // Chars?
			PLAYER_SKILL_INFO_1_1_275 			= UNIT_END + 0x2C1, // Chars?
			PLAYER_SKILL_INFO_1_1_276 			= UNIT_END + 0x2C2, // Chars?
			PLAYER_SKILL_INFO_1_1_277 			= UNIT_END + 0x2C3, // Chars?
			PLAYER_SKILL_INFO_1_1_278 			= UNIT_END + 0x2C4, // Chars?
			PLAYER_SKILL_INFO_1_1_279 			= UNIT_END + 0x2C5, // Chars?
			PLAYER_SKILL_INFO_1_1_280 			= UNIT_END + 0x2C6, // Chars?
			PLAYER_SKILL_INFO_1_1_281 			= UNIT_END + 0x2C7, // Chars?
			PLAYER_SKILL_INFO_1_1_282 			= UNIT_END + 0x2C8, // Chars?
			PLAYER_SKILL_INFO_1_1_283 			= UNIT_END + 0x2C9, // Chars?
			PLAYER_SKILL_INFO_1_1_284 			= UNIT_END + 0x2CA, // Chars?
			PLAYER_SKILL_INFO_1_1_285 			= UNIT_END + 0x2CB, // Chars?
			PLAYER_SKILL_INFO_1_1_286 			= UNIT_END + 0x2CC, // Chars?
			PLAYER_SKILL_INFO_1_1_287 			= UNIT_END + 0x2CD, // Chars?
			PLAYER_SKILL_INFO_1_1_288 			= UNIT_END + 0x2CE, // Chars?
			PLAYER_SKILL_INFO_1_1_289 			= UNIT_END + 0x2CF, // Chars?
			PLAYER_SKILL_INFO_1_1_290 			= UNIT_END + 0x2D0, // Chars?
			PLAYER_SKILL_INFO_1_1_291 			= UNIT_END + 0x2D1, // Chars?
			PLAYER_SKILL_INFO_1_1_292 			= UNIT_END + 0x2D2, // Chars?
			PLAYER_SKILL_INFO_1_1_293 			= UNIT_END + 0x2D3, // Chars?
			PLAYER_SKILL_INFO_1_1_294 			= UNIT_END + 0x2D4, // Chars?
			PLAYER_SKILL_INFO_1_1_295 			= UNIT_END + 0x2D5, // Chars?
			PLAYER_SKILL_INFO_1_1_296 			= UNIT_END + 0x2D6, // Chars?
			PLAYER_SKILL_INFO_1_1_297 			= UNIT_END + 0x2D7, // Chars?
			PLAYER_SKILL_INFO_1_1_298 			= UNIT_END + 0x2D8, // Chars?
			PLAYER_SKILL_INFO_1_1_299 			= UNIT_END + 0x2D9, // Chars?
			PLAYER_SKILL_INFO_1_1_300 			= UNIT_END + 0x2DA, // Chars?
			PLAYER_SKILL_INFO_1_1_301 			= UNIT_END + 0x2DB, // Chars?
			PLAYER_SKILL_INFO_1_1_302 			= UNIT_END + 0x2DC, // Chars?
			PLAYER_SKILL_INFO_1_1_303 			= UNIT_END + 0x2DD, // Chars?
			PLAYER_SKILL_INFO_1_1_304 			= UNIT_END + 0x2DE, // Chars?
			PLAYER_SKILL_INFO_1_1_305 			= UNIT_END + 0x2DF, // Chars?
			PLAYER_SKILL_INFO_1_1_306 			= UNIT_END + 0x2E0, // Chars?
			PLAYER_SKILL_INFO_1_1_307 			= UNIT_END + 0x2E1, // Chars?
			PLAYER_SKILL_INFO_1_1_308 			= UNIT_END + 0x2E2, // Chars?
			PLAYER_SKILL_INFO_1_1_309 			= UNIT_END + 0x2E3, // Chars?
			PLAYER_SKILL_INFO_1_1_310 			= UNIT_END + 0x2E4, // Chars?
			PLAYER_SKILL_INFO_1_1_311 			= UNIT_END + 0x2E5, // Chars?
			PLAYER_SKILL_INFO_1_1_312 			= UNIT_END + 0x2E6, // Chars?
			PLAYER_SKILL_INFO_1_1_313 			= UNIT_END + 0x2E7, // Chars?
			PLAYER_SKILL_INFO_1_1_314 			= UNIT_END + 0x2E8, // Chars?
			PLAYER_SKILL_INFO_1_1_315 			= UNIT_END + 0x2E9, // Chars?
			PLAYER_SKILL_INFO_1_1_316 			= UNIT_END + 0x2EA, // Chars?
			PLAYER_SKILL_INFO_1_1_317 			= UNIT_END + 0x2EB, // Chars?
			PLAYER_SKILL_INFO_1_1_318 			= UNIT_END + 0x2EC, // Chars?
			PLAYER_SKILL_INFO_1_1_319 			= UNIT_END + 0x2ED, // Chars?
			PLAYER_SKILL_INFO_1_1_320 			= UNIT_END + 0x2EE, // Chars?
			PLAYER_SKILL_INFO_1_1_321 			= UNIT_END + 0x2EF, // Chars?
			PLAYER_SKILL_INFO_1_1_322 			= UNIT_END + 0x2F0, // Chars?
			PLAYER_SKILL_INFO_1_1_323 			= UNIT_END + 0x2F1, // Chars?
			PLAYER_SKILL_INFO_1_1_324 			= UNIT_END + 0x2F2, // Chars?
			PLAYER_SKILL_INFO_1_1_325 			= UNIT_END + 0x2F3, // Chars?
			PLAYER_SKILL_INFO_1_1_326 			= UNIT_END + 0x2F4, // Chars?
			PLAYER_SKILL_INFO_1_1_327 			= UNIT_END + 0x2F5, // Chars?
			PLAYER_SKILL_INFO_1_1_328 			= UNIT_END + 0x2F6, // Chars?
			PLAYER_SKILL_INFO_1_1_329 			= UNIT_END + 0x2F7, // Chars?
			PLAYER_SKILL_INFO_1_1_330 			= UNIT_END + 0x2F8, // Chars?
			PLAYER_SKILL_INFO_1_1_331 			= UNIT_END + 0x2F9, // Chars?
			PLAYER_SKILL_INFO_1_1_332 			= UNIT_END + 0x2FA, // Chars?
			PLAYER_SKILL_INFO_1_1_333 			= UNIT_END + 0x2FB, // Chars?
			PLAYER_SKILL_INFO_1_1_334 			= UNIT_END + 0x2FC, // Chars?
			PLAYER_SKILL_INFO_1_1_335 			= UNIT_END + 0x2FD, // Chars?
			PLAYER_SKILL_INFO_1_1_336 			= UNIT_END + 0x2FE, // Chars?
			PLAYER_SKILL_INFO_1_1_337 			= UNIT_END + 0x2FF, // Chars?
			PLAYER_SKILL_INFO_1_1_338 			= UNIT_END + 0x300, // Chars?
			PLAYER_SKILL_INFO_1_1_339 			= UNIT_END + 0x301, // Chars?
			PLAYER_SKILL_INFO_1_1_340 			= UNIT_END + 0x302, // Chars?
			PLAYER_SKILL_INFO_1_1_341 			= UNIT_END + 0x303, // Chars?
			PLAYER_SKILL_INFO_1_1_342 			= UNIT_END + 0x304, // Chars?
			PLAYER_SKILL_INFO_1_1_343 			= UNIT_END + 0x305, // Chars?
			PLAYER_SKILL_INFO_1_1_344 			= UNIT_END + 0x306, // Chars?
			PLAYER_SKILL_INFO_1_1_345 			= UNIT_END + 0x307, // Chars?
			PLAYER_SKILL_INFO_1_1_346 			= UNIT_END + 0x308, // Chars?
			PLAYER_SKILL_INFO_1_1_347 			= UNIT_END + 0x309, // Chars?
			PLAYER_SKILL_INFO_1_1_348 			= UNIT_END + 0x30A, // Chars?
			PLAYER_SKILL_INFO_1_1_349 			= UNIT_END + 0x30B, // Chars?
			PLAYER_SKILL_INFO_1_1_350 			= UNIT_END + 0x30C, // Chars?
			PLAYER_SKILL_INFO_1_1_351 			= UNIT_END + 0x30D, // Chars?
			PLAYER_SKILL_INFO_1_1_352 			= UNIT_END + 0x30E, // Chars?
			PLAYER_SKILL_INFO_1_1_353 			= UNIT_END + 0x30F, // Chars?
			PLAYER_SKILL_INFO_1_1_354 			= UNIT_END + 0x310, // Chars?
			PLAYER_SKILL_INFO_1_1_355 			= UNIT_END + 0x311, // Chars?
			PLAYER_SKILL_INFO_1_1_356 			= UNIT_END + 0x312, // Chars?
			PLAYER_SKILL_INFO_1_1_357 			= UNIT_END + 0x313, // Chars?
			PLAYER_SKILL_INFO_1_1_358 			= UNIT_END + 0x314, // Chars?
			PLAYER_SKILL_INFO_1_1_359 			= UNIT_END + 0x315, // Chars?
			PLAYER_SKILL_INFO_1_1_360 			= UNIT_END + 0x316, // Chars?
			PLAYER_SKILL_INFO_1_1_361 			= UNIT_END + 0x317, // Chars?
			PLAYER_SKILL_INFO_1_1_362 			= UNIT_END + 0x318, // Chars?
			PLAYER_SKILL_INFO_1_1_363 			= UNIT_END + 0x319, // Chars?
			PLAYER_SKILL_INFO_1_1_364 			= UNIT_END + 0x31A, // Chars?
			PLAYER_SKILL_INFO_1_1_365 			= UNIT_END + 0x31B, // Chars?
			PLAYER_SKILL_INFO_1_1_366 			= UNIT_END + 0x31C, // Chars?
			PLAYER_SKILL_INFO_1_1_367 			= UNIT_END + 0x31D, // Chars?
			PLAYER_SKILL_INFO_1_1_368 			= UNIT_END + 0x31E, // Chars?
			PLAYER_SKILL_INFO_1_1_369 			= UNIT_END + 0x31F, // Chars?
			PLAYER_SKILL_INFO_1_1_370 			= UNIT_END + 0x320, // Chars?
			PLAYER_SKILL_INFO_1_1_371 			= UNIT_END + 0x321, // Chars?
			PLAYER_SKILL_INFO_1_1_372 			= UNIT_END + 0x322, // Chars?
			PLAYER_SKILL_INFO_1_1_373 			= UNIT_END + 0x323, // Chars?
			PLAYER_SKILL_INFO_1_1_374 			= UNIT_END + 0x324, // Chars?
			PLAYER_SKILL_INFO_1_1_375 			= UNIT_END + 0x325, // Chars?
			PLAYER_SKILL_INFO_1_1_376 			= UNIT_END + 0x326, // Chars?
			PLAYER_SKILL_INFO_1_1_377 			= UNIT_END + 0x327, // Chars?
			PLAYER_SKILL_INFO_1_1_378 			= UNIT_END + 0x328, // Chars?
			PLAYER_SKILL_INFO_1_1_379 			= UNIT_END + 0x329, // Chars?
			PLAYER_SKILL_INFO_1_1_380 			= UNIT_END + 0x32A, // Chars?
			PLAYER_SKILL_INFO_1_1_381 			= UNIT_END + 0x32B, // Chars?
			PLAYER_SKILL_INFO_1_1_382 			= UNIT_END + 0x32C, // Chars?
			PLAYER_SKILL_INFO_1_1_383 			= UNIT_END + 0x32D, // Chars?
			PLAYER_CHARACTER_POINTS1            		= UNIT_END + 0x32E, // Int32
			PLAYER_CHARACTER_POINTS2            		= UNIT_END + 0x32F, // Int32
			PLAYER_TRACK_CREATURES              		= UNIT_END + 0x330, // Int32
			PLAYER_TRACK_RESOURCES              		= UNIT_END + 0x331, // Int32
			PLAYER_BLOCK_PERCENTAGE             		= UNIT_END + 0x332, // Float
			PLAYER_DODGE_PERCENTAGE             		= UNIT_END + 0x333, // Float
			PLAYER_PARRY_PERCENTAGE             		= UNIT_END + 0x334, // Float
			PLAYER_CRIT_PERCENTAGE              		= UNIT_END + 0x335, // Float
			PLAYER_RANGED_CRIT_PERCENTAGE       		= UNIT_END + 0x336, // Float
			PLAYER_EXPLORED_ZONES_1 			= UNIT_END + 0x337, // Bytes
			PLAYER_EXPLORED_ZONES_1_01 			= UNIT_END + 0x338, // Bytes
			PLAYER_EXPLORED_ZONES_1_02 			= UNIT_END + 0x339, // Bytes
			PLAYER_EXPLORED_ZONES_1_03 			= UNIT_END + 0x33A, // Bytes
			PLAYER_EXPLORED_ZONES_1_04 			= UNIT_END + 0x33B, // Bytes
			PLAYER_EXPLORED_ZONES_1_05 			= UNIT_END + 0x33C, // Bytes
			PLAYER_EXPLORED_ZONES_1_06 			= UNIT_END + 0x33D, // Bytes
			PLAYER_EXPLORED_ZONES_1_07 			= UNIT_END + 0x33E, // Bytes
			PLAYER_EXPLORED_ZONES_1_08 			= UNIT_END + 0x33F, // Bytes
			PLAYER_EXPLORED_ZONES_1_09 			= UNIT_END + 0x340, // Bytes
			PLAYER_EXPLORED_ZONES_1_10 			= UNIT_END + 0x341, // Bytes
			PLAYER_EXPLORED_ZONES_1_11 			= UNIT_END + 0x342, // Bytes
			PLAYER_EXPLORED_ZONES_1_12 			= UNIT_END + 0x343, // Bytes
			PLAYER_EXPLORED_ZONES_1_13 			= UNIT_END + 0x344, // Bytes
			PLAYER_EXPLORED_ZONES_1_14 			= UNIT_END + 0x345, // Bytes
			PLAYER_EXPLORED_ZONES_1_15 			= UNIT_END + 0x346, // Bytes
			PLAYER_EXPLORED_ZONES_1_16 			= UNIT_END + 0x347, // Bytes
			PLAYER_EXPLORED_ZONES_1_17 			= UNIT_END + 0x348, // Bytes
			PLAYER_EXPLORED_ZONES_1_18 			= UNIT_END + 0x349, // Bytes
			PLAYER_EXPLORED_ZONES_1_19 			= UNIT_END + 0x34A, // Bytes
			PLAYER_EXPLORED_ZONES_1_20 			= UNIT_END + 0x34B, // Bytes
			PLAYER_EXPLORED_ZONES_1_21 			= UNIT_END + 0x34C, // Bytes
			PLAYER_EXPLORED_ZONES_1_22 			= UNIT_END + 0x34D, // Bytes
			PLAYER_EXPLORED_ZONES_1_23 			= UNIT_END + 0x34E, // Bytes
			PLAYER_EXPLORED_ZONES_1_24 			= UNIT_END + 0x34F, // Bytes
			PLAYER_EXPLORED_ZONES_1_25 			= UNIT_END + 0x350, // Bytes
			PLAYER_EXPLORED_ZONES_1_26 			= UNIT_END + 0x351, // Bytes
			PLAYER_EXPLORED_ZONES_1_27 			= UNIT_END + 0x352, // Bytes
			PLAYER_EXPLORED_ZONES_1_28 			= UNIT_END + 0x353, // Bytes
			PLAYER_EXPLORED_ZONES_1_29 			= UNIT_END + 0x354, // Bytes
			PLAYER_EXPLORED_ZONES_1_30 			= UNIT_END + 0x355, // Bytes
			PLAYER_EXPLORED_ZONES_1_31 			= UNIT_END + 0x356, // Bytes
			PLAYER_EXPLORED_ZONES_1_32 			= UNIT_END + 0x357, // Bytes
			PLAYER_EXPLORED_ZONES_1_33 			= UNIT_END + 0x358, // Bytes
			PLAYER_EXPLORED_ZONES_1_34 			= UNIT_END + 0x359, // Bytes
			PLAYER_EXPLORED_ZONES_1_35 			= UNIT_END + 0x35A, // Bytes
			PLAYER_EXPLORED_ZONES_1_36 			= UNIT_END + 0x35B, // Bytes
			PLAYER_EXPLORED_ZONES_1_37 			= UNIT_END + 0x35C, // Bytes
			PLAYER_EXPLORED_ZONES_1_38 			= UNIT_END + 0x35D, // Bytes
			PLAYER_EXPLORED_ZONES_1_39 			= UNIT_END + 0x35E, // Bytes
			PLAYER_EXPLORED_ZONES_1_40 			= UNIT_END + 0x35F, // Bytes
			PLAYER_EXPLORED_ZONES_1_41 			= UNIT_END + 0x360, // Bytes
			PLAYER_EXPLORED_ZONES_1_42 			= UNIT_END + 0x361, // Bytes
			PLAYER_EXPLORED_ZONES_1_43 			= UNIT_END + 0x362, // Bytes
			PLAYER_EXPLORED_ZONES_1_44 			= UNIT_END + 0x363, // Bytes
			PLAYER_EXPLORED_ZONES_1_45 			= UNIT_END + 0x364, // Bytes
			PLAYER_EXPLORED_ZONES_1_46 			= UNIT_END + 0x365, // Bytes
			PLAYER_EXPLORED_ZONES_1_47 			= UNIT_END + 0x366, // Bytes
			PLAYER_EXPLORED_ZONES_1_48 			= UNIT_END + 0x367, // Bytes
			PLAYER_EXPLORED_ZONES_1_49 			= UNIT_END + 0x368, // Bytes
			PLAYER_EXPLORED_ZONES_1_50 			= UNIT_END + 0x369, // Bytes
			PLAYER_EXPLORED_ZONES_1_51 			= UNIT_END + 0x36A, // Bytes
			PLAYER_EXPLORED_ZONES_1_52 			= UNIT_END + 0x36B, // Bytes
			PLAYER_EXPLORED_ZONES_1_53 			= UNIT_END + 0x36C, // Bytes
			PLAYER_EXPLORED_ZONES_1_54 			= UNIT_END + 0x36D, // Bytes
			PLAYER_EXPLORED_ZONES_1_55 			= UNIT_END + 0x36E, // Bytes
			PLAYER_EXPLORED_ZONES_1_56 			= UNIT_END + 0x36F, // Bytes
			PLAYER_EXPLORED_ZONES_1_57 			= UNIT_END + 0x370, // Bytes
			PLAYER_EXPLORED_ZONES_1_58 			= UNIT_END + 0x371, // Bytes
			PLAYER_EXPLORED_ZONES_1_59 			= UNIT_END + 0x372, // Bytes
			PLAYER_EXPLORED_ZONES_1_60 			= UNIT_END + 0x373, // Bytes
			PLAYER_EXPLORED_ZONES_1_61 			= UNIT_END + 0x374, // Bytes
			PLAYER_EXPLORED_ZONES_1_62 			= UNIT_END + 0x375, // Bytes
			PLAYER_EXPLORED_ZONES_1_63 			= UNIT_END + 0x376, // Bytes
			PLAYER_REST_STATE_EXPERIENCE        		= UNIT_END + 0x377, // Int32
			PLAYER_FIELD_COINAGE                		= UNIT_END + 0x378, // Int32
			PLAYER_FIELD_POSSTAT0               		= UNIT_END + 0x379, // Int32
			PLAYER_FIELD_POSSTAT1               		= UNIT_END + 0x37A, // Int32
			PLAYER_FIELD_POSSTAT2               		= UNIT_END + 0x37B, // Int32
			PLAYER_FIELD_POSSTAT3               		= UNIT_END + 0x37C, // Int32
			PLAYER_FIELD_POSSTAT4               		= UNIT_END + 0x37D, // Int32
			PLAYER_FIELD_NEGSTAT0               		= UNIT_END + 0x37E, // Int32
			PLAYER_FIELD_NEGSTAT1               		= UNIT_END + 0x37F, // Int32
			PLAYER_FIELD_NEGSTAT2               		= UNIT_END + 0x380, // Int32
			PLAYER_FIELD_NEGSTAT3               		= UNIT_END + 0x381, // Int32
			PLAYER_FIELD_NEGSTAT4               		= UNIT_END + 0x382, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE 	= UNIT_END + 0x383, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_01 	= UNIT_END + 0x384, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_02 	= UNIT_END + 0x385, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_03 	= UNIT_END + 0x386, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_04 	= UNIT_END + 0x387, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_05 	= UNIT_END + 0x388, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_06 	= UNIT_END + 0x389, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE 	= UNIT_END + 0x38A, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_01 	= UNIT_END + 0x38B, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_02 	= UNIT_END + 0x38C, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_03 	= UNIT_END + 0x38D, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_04 	= UNIT_END + 0x38E, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_05 	= UNIT_END + 0x38F, // Int32
			PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_06 	= UNIT_END + 0x390, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS 		= UNIT_END + 0x391, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_01 		= UNIT_END + 0x392, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_02 		= UNIT_END + 0x393, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_03 		= UNIT_END + 0x394, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_04 		= UNIT_END + 0x395, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_05 		= UNIT_END + 0x396, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_POS_06 		= UNIT_END + 0x397, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG 		= UNIT_END + 0x398, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_01 		= UNIT_END + 0x399, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_02 		= UNIT_END + 0x39A, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_03 		= UNIT_END + 0x39B, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_04 		= UNIT_END + 0x39C, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_05 		= UNIT_END + 0x39D, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_06 		= UNIT_END + 0x39E, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT 		= UNIT_END + 0x39F, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_01 		= UNIT_END + 0x3A0, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_02 		= UNIT_END + 0x3A1, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_03 		= UNIT_END + 0x3A2, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_04 		= UNIT_END + 0x3A3, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_05 		= UNIT_END + 0x3A4, // Int32
			PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_06 		= UNIT_END + 0x3A5, // Int32
			PLAYER_FIELD_BYTES                  		= UNIT_END + 0x3A6, // Bytes
			PLAYER_AMMO_ID                      		= UNIT_END + 0x3A7, // Int32
			PLAYER_FIELD_PVP_MEDALS             		= UNIT_END + 0x3A8, // Int32
			PLAYER_FIELD_BUYBACK_ITEM_ID        		= UNIT_END + 0x3A9, // Int32
			PLAYER_FIELD_BUYBACK_RANDOM_PROPERTIES_ID 	= UNIT_END + 0x3AA, // Int32
			PLAYER_FIELD_BUYBACK_SEED           		= UNIT_END + 0x3AB, // Int32
			PLAYER_FIELD_BUYBACK_PRICE          		= UNIT_END + 0x3AC, // Int32
			PLAYER_FIELD_BUYBACK_DURABILITY     		= UNIT_END + 0x3AD, // Int32
			PLAYER_FIELD_BUYBACK_COUNT          		= UNIT_END + 0x3AE, // Int32
			PLAYER_FIELD_SESSION_KILLS          		= UNIT_END + 0x3AF, // Chars?
			PLAYER_FIELD_YESTERDAY_KILLS        		= UNIT_END + 0x3B0, // Chars?
			PLAYER_FIELD_LAST_WEEK_KILLS        		= UNIT_END + 0x3B1, // Chars?
			PLAYER_FIELD_LIFETIME_HONORBALE_KILLS 		= UNIT_END + 0x3B2, // Int32
			PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS 	= UNIT_END + 0x3B3, // Int32
			PLAYER_FIELD_YESTERDAY_CONTRIBUTION 		= UNIT_END + 0x3B4, // Int32
			PLAYER_FIELD_LAST_WEEK_CONTRIBUTION 		= UNIT_END + 0x3B5, // Int32
			PLAYER_FIELD_LAST_WEEK_RANK         		= UNIT_END + 0x3B6, // Int32
			PLAYER_FIELD_PADDING                		= UNIT_END + 0x3B7, // Int32
			PLAYER_END					= UNIT_END + 0x3B8,


			// Gameobject
			GAMEOBJECT_DISPLAYID                		= PLAYER_END + 0x000, // Int32
			GAMEOBJECT_FLAGS                    		= PLAYER_END + 0x001, // Int32
			GAMEOBJECT_ROTATION 				= PLAYER_END + 0x002, // Float
			GAMEOBJECT_ROTATION_01 				= PLAYER_END + 0x003, // Float
			GAMEOBJECT_ROTATION_02 				= PLAYER_END + 0x004, // Float
			GAMEOBJECT_ROTATION_03 				= PLAYER_END + 0x005, // Float
			GAMEOBJECT_STATE                    		= PLAYER_END + 0x006, // Int32
			GAMEOBJECT_TIMESTAMP                		= PLAYER_END + 0x007, // Int32
			GAMEOBJECT_POS_X                    		= PLAYER_END + 0x008, // Float
			GAMEOBJECT_POS_Y                    		= PLAYER_END + 0x009, // Float
			GAMEOBJECT_POS_Z                    		= PLAYER_END + 0x00A, // Float
			GAMEOBJECT_FACING                   		= PLAYER_END + 0x00B, // Float
			GAMEOBJECT_DYN_FLAGS                		= PLAYER_END + 0x00C, // Int32
			GAMEOBJECT_FACTION                  		= PLAYER_END + 0x00D, // Int32
			GAMEOBJECT_TYPE_ID                  		= PLAYER_END + 0x00E, // Int32
			GAMEOBJECT_LEVEL                    		= PLAYER_END + 0x00F, // Int32
			GAMEOBJECT_END					= PLAYER_END + 0x010,

			// Dynamicobject
			DYNAMICOBJECT_CASTER 				= GAMEOBJECT_END + 0x000, // GUID
			DYNAMICOBJECT_CASTER_01 			= GAMEOBJECT_END + 0x001, // GUID
			DYNAMICOBJECT_BYTES                 		= GAMEOBJECT_END + 0x002, // Bytes
			DYNAMICOBJECT_SPELLID               		= GAMEOBJECT_END + 0x003, // Int32
			DYNAMICOBJECT_RADIUS                		= GAMEOBJECT_END + 0x004, // Float
			DYNAMICOBJECT_POS_X                 		= GAMEOBJECT_END + 0x005, // Float
			DYNAMICOBJECT_POS_Y                 		= GAMEOBJECT_END + 0x006, // Float
			DYNAMICOBJECT_POS_Z                 		= GAMEOBJECT_END + 0x007, // Float
			DYNAMICOBJECT_FACING                		= GAMEOBJECT_END + 0x008, // Float
			DYNAMICOBJECT_PAD                   		= GAMEOBJECT_END + 0x009, // Bytes
			DYNAMICOBJECT_END				= GAMEOBJECT_END + 0x00A,

			// Corpse
			CORPSE_FIELD_OWNER 				= DYNAMICOBJECT_END + 0x000, // GUID
			CORPSE_FIELD_OWNER_01 				= DYNAMICOBJECT_END + 0x001, // GUID
			CORPSE_FIELD_FACING                 		= DYNAMICOBJECT_END + 0x002, // Float
			CORPSE_FIELD_POS_X                  		= DYNAMICOBJECT_END + 0x003, // Float
			CORPSE_FIELD_POS_Y                  		= DYNAMICOBJECT_END + 0x004, // Float
			CORPSE_FIELD_POS_Z                  		= DYNAMICOBJECT_END + 0x005, // Float
			CORPSE_FIELD_DISPLAY_ID             		= DYNAMICOBJECT_END + 0x006, // Int32
			CORPSE_FIELD_ITEM 				= DYNAMICOBJECT_END + 0x007, // Int32
			CORPSE_FIELD_ITEM_01 				= DYNAMICOBJECT_END + 0x008, // Int32
			CORPSE_FIELD_ITEM_02 				= DYNAMICOBJECT_END + 0x009, // Int32
			CORPSE_FIELD_ITEM_03 				= DYNAMICOBJECT_END + 0x00A, // Int32
			CORPSE_FIELD_ITEM_04 				= DYNAMICOBJECT_END + 0x00B, // Int32
			CORPSE_FIELD_ITEM_05 				= DYNAMICOBJECT_END + 0x00C, // Int32
			CORPSE_FIELD_ITEM_06 				= DYNAMICOBJECT_END + 0x00D, // Int32
			CORPSE_FIELD_ITEM_07 				= DYNAMICOBJECT_END + 0x00E, // Int32
			CORPSE_FIELD_ITEM_08 				= DYNAMICOBJECT_END + 0x00F, // Int32
			CORPSE_FIELD_ITEM_09 				= DYNAMICOBJECT_END + 0x010, // Int32
			CORPSE_FIELD_ITEM_10 				= DYNAMICOBJECT_END + 0x011, // Int32
			CORPSE_FIELD_ITEM_11 				= DYNAMICOBJECT_END + 0x012, // Int32
			CORPSE_FIELD_ITEM_12 				= DYNAMICOBJECT_END + 0x013, // Int32
			CORPSE_FIELD_ITEM_13 				= DYNAMICOBJECT_END + 0x014, // Int32
			CORPSE_FIELD_ITEM_14 				= DYNAMICOBJECT_END + 0x015, // Int32
			CORPSE_FIELD_ITEM_15 				= DYNAMICOBJECT_END + 0x016, // Int32
			CORPSE_FIELD_ITEM_16 				= DYNAMICOBJECT_END + 0x017, // Int32
			CORPSE_FIELD_ITEM_17 				= DYNAMICOBJECT_END + 0x018, // Int32
			CORPSE_FIELD_ITEM_18 				= DYNAMICOBJECT_END + 0x019, // Int32
			CORPSE_FIELD_BYTES_1                		= DYNAMICOBJECT_END + 0x01A, // Bytes
			CORPSE_FIELD_BYTES_2                		= DYNAMICOBJECT_END + 0x01B, // Bytes
			CORPSE_FIELD_GUILD                  		= DYNAMICOBJECT_END + 0x01C, // Int32
			CORPSE_FIELD_FLAGS                  		= DYNAMICOBJECT_END + 0x01D, // Int32
			CORPSE_END					= DYNAMICOBJECT_END + 0x01E,
		*/



		OBJECT_FIELD_GUID    		=	0x000 , // GUID
		OBJECT_FIELD_GUID_01 		=	0x001 , // GUID
		OBJECT_FIELD_TYPE           =        0x002 , // Int32
		OBJECT_FIELD_ENTRY          =        0x003 , // Int32
		OBJECT_FIELD_SCALE_X        =        0x004 , // Float
		OBJECT_FIELD_PADDING        =        0x005 , // Int32
		OBJECT_END                  =        0x006,


		ITEM_FIELD_OWNER    		=	OBJECT_END + 0x000 , // GUID
		ITEM_FIELD_OWNER_01 		=	OBJECT_END + 0x001 , // GUID
		ITEM_FIELD_CONTAINED    =			OBJECT_END + 0x002 , // GUID
		ITEM_FIELD_CONTAINED_01= 			OBJECT_END + 0x003 , // GUID
		ITEM_FIELD_CREATOR    =			OBJECT_END + 0x004 , // GUID
		ITEM_FIELD_CREATOR_01 	=		OBJECT_END + 0x005 , // GUID
		ITEM_FIELD_GIFTCREATOR    	=		OBJECT_END + 0x006 , // GUID
		ITEM_FIELD_GIFTCREATOR_01 		=	OBJECT_END + 0x007 , // GUID
		ITEM_FIELD_STACK_COUNT          =    OBJECT_END + 0x008 , // Int32
		ITEM_FIELD_DURATION             =    OBJECT_END + 0x009 , // Int32
		ITEM_FIELD_SPELL_CHARGES    	=		OBJECT_END + 0x00A , // Int32
		ITEM_FIELD_SPELL_CHARGES_01 	=		OBJECT_END + 0x00B , // Int32
		ITEM_FIELD_SPELL_CHARGES_02 	=		OBJECT_END + 0x00C , // Int32
		ITEM_FIELD_SPELL_CHARGES_03 	=		OBJECT_END + 0x00D , // Int32
		ITEM_FIELD_SPELL_CHARGES_04 	=		OBJECT_END + 0x00E , // Int32
		ITEM_FIELD_FLAGS                 =   OBJECT_END + 0x00F , // Chars?
		ITEM_FIELD_ENCHANTMENT    		=	OBJECT_END + 0x010 , // Int32
		ITEM_FIELD_ENCHANTMENT_01 		=	OBJECT_END + 0x011 , // Int32
		ITEM_FIELD_ENCHANTMENT_02 		=	OBJECT_END + 0x012 , // Int32
		ITEM_FIELD_ENCHANTMENT_03 		=	OBJECT_END + 0x013 , // Int32
		ITEM_FIELD_ENCHANTMENT_04 		=	OBJECT_END + 0x014 , // Int32
		ITEM_FIELD_ENCHANTMENT_05 		=	OBJECT_END + 0x015 , // Int32
		ITEM_FIELD_ENCHANTMENT_06 		=	OBJECT_END + 0x016 , // Int32
		ITEM_FIELD_ENCHANTMENT_07 		=	OBJECT_END + 0x017 , // Int32
		ITEM_FIELD_ENCHANTMENT_08 		=	OBJECT_END + 0x018 , // Int32
		ITEM_FIELD_ENCHANTMENT_09 		=	OBJECT_END + 0x019 , // Int32
		ITEM_FIELD_ENCHANTMENT_10 		=	OBJECT_END + 0x01A , // Int32
		ITEM_FIELD_ENCHANTMENT_11 		=	OBJECT_END + 0x01B , // Int32
		ITEM_FIELD_ENCHANTMENT_12 		=	OBJECT_END + 0x01C , // Int32
		ITEM_FIELD_ENCHANTMENT_13 		=	OBJECT_END + 0x01D , // Int32
		ITEM_FIELD_ENCHANTMENT_14 		=	OBJECT_END + 0x01E , // Int32
		ITEM_FIELD_ENCHANTMENT_15 		=	OBJECT_END + 0x01F , // Int32
		ITEM_FIELD_ENCHANTMENT_16 		=	OBJECT_END + 0x020 , // Int32
		ITEM_FIELD_ENCHANTMENT_17 		=	OBJECT_END + 0x021 , // Int32
		ITEM_FIELD_ENCHANTMENT_18 		=	OBJECT_END + 0x022 , // Int32
		ITEM_FIELD_ENCHANTMENT_19 		=	OBJECT_END + 0x023 , // Int32
		ITEM_FIELD_ENCHANTMENT_20 		=	OBJECT_END + 0x024 , // Int32
		ITEM_FIELD_PROPERTY_SEED         =   OBJECT_END + 0x025 , // Int32
		ITEM_FIELD_RANDOM_PROPERTIES_ID   =  OBJECT_END + 0x026 , // Int32
		ITEM_FIELD_ITEM_TEXT_ID            = OBJECT_END + 0x027 , // Int32
		ITEM_FIELD_DURABILITY         =      OBJECT_END + 0x028 , // Int32
		ITEM_FIELD_MAXDURABILITY       =     OBJECT_END + 0x029 , // Int32
		ITEM_END						=	OBJECT_END + 0x02A,


		CONTAINER_FIELD_NUM_SLOTS           = ITEM_END + 0x000 , // Int32
		CONTAINER_ALIGN_PAD                 = ITEM_END + 0x001 , // Bytes
		CONTAINER_FIELD_SLOT_1  			= ITEM_END + 0x002 , // GUID
		CONTAINER_FIELD_SLOT_1_01 			= ITEM_END + 0x003 , // GUID
		CONTAINER_FIELD_SLOT_1_02 			= ITEM_END + 0x004 , // GUID
		CONTAINER_FIELD_SLOT_1_03 			= ITEM_END + 0x005 , // GUID
		CONTAINER_FIELD_SLOT_1_04 			= ITEM_END + 0x006 , // GUID
		CONTAINER_FIELD_SLOT_1_05 			= ITEM_END + 0x007 , // GUID
		CONTAINER_FIELD_SLOT_1_06 			= ITEM_END + 0x008 , // GUID
		CONTAINER_FIELD_SLOT_1_07 			= ITEM_END + 0x009 , // GUID
		CONTAINER_FIELD_SLOT_1_08 			= ITEM_END + 0x00A , // GUID
		CONTAINER_FIELD_SLOT_1_09 			= ITEM_END + 0x00B , // GUID
		CONTAINER_FIELD_SLOT_1_10 			= ITEM_END + 0x00C , // GUID
		CONTAINER_FIELD_SLOT_1_11 			= ITEM_END + 0x00D , // GUID
		CONTAINER_FIELD_SLOT_1_12 			= ITEM_END + 0x00E , // GUID
		CONTAINER_FIELD_SLOT_1_13 			= ITEM_END + 0x00F , // GUID
		CONTAINER_FIELD_SLOT_1_14 			= ITEM_END + 0x010 , // GUID
		CONTAINER_FIELD_SLOT_1_15 			= ITEM_END + 0x011 , // GUID
		CONTAINER_FIELD_SLOT_1_16 			= ITEM_END + 0x012 , // GUID
		CONTAINER_FIELD_SLOT_1_17 			= ITEM_END + 0x013 , // GUID
		CONTAINER_FIELD_SLOT_1_18 			= ITEM_END + 0x014 , // GUID
		CONTAINER_FIELD_SLOT_1_19 			= ITEM_END + 0x015 , // GUID
		CONTAINER_FIELD_SLOT_1_20 			= ITEM_END + 0x016 , // GUID
		CONTAINER_FIELD_SLOT_1_21 			= ITEM_END + 0x017 , // GUID
		CONTAINER_FIELD_SLOT_1_22 			= ITEM_END + 0x018 , // GUID
		CONTAINER_FIELD_SLOT_1_23 			= ITEM_END + 0x019 , // GUID
		CONTAINER_FIELD_SLOT_1_24 			= ITEM_END + 0x01A , // GUID
		CONTAINER_FIELD_SLOT_1_25 			= ITEM_END + 0x01B , // GUID
		CONTAINER_FIELD_SLOT_1_26 			= ITEM_END + 0x01C , // GUID
		CONTAINER_FIELD_SLOT_1_27 			= ITEM_END + 0x01D , // GUID
		CONTAINER_FIELD_SLOT_1_28 			= ITEM_END + 0x01E , // GUID
		CONTAINER_FIELD_SLOT_1_29 			= ITEM_END + 0x01F , // GUID
		CONTAINER_FIELD_SLOT_1_30 			= ITEM_END + 0x020 , // GUID
		CONTAINER_FIELD_SLOT_1_31 			= ITEM_END + 0x021 , // GUID
		CONTAINER_FIELD_SLOT_1_32 			= ITEM_END + 0x022 , // GUID
		CONTAINER_FIELD_SLOT_1_33 			= ITEM_END + 0x023 , // GUID
		CONTAINER_FIELD_SLOT_1_34 			= ITEM_END + 0x024 , // GUID
		CONTAINER_FIELD_SLOT_1_35 			= ITEM_END + 0x025 , // GUID
		CONTAINER_FIELD_SLOT_1_36 			= ITEM_END + 0x026 , // GUID
		CONTAINER_FIELD_SLOT_1_37 			= ITEM_END + 0x027 , // GUID
		CONTAINER_FIELD_SLOT_1_38 			= ITEM_END + 0x028 , // GUID
		CONTAINER_FIELD_SLOT_1_39 			= ITEM_END + 0x029 , // GUID
		CONTAINER_END						= ITEM_END + 0x02A,


		UNIT_FIELD_CHARM    			= OBJECT_END + 0x000 , // GUID
		UNIT_FIELD_CHARM_01 			= OBJECT_END + 0x001 , // GUID
		UNIT_FIELD_SUMMON    			= OBJECT_END + 0x002 , // GUID
		UNIT_FIELD_SUMMON_01 			= OBJECT_END + 0x003 , // GUID
		UNIT_FIELD_CHARMEDBY   			= OBJECT_END + 0x004 , // GUID
		UNIT_FIELD_CHARMEDBY_01 			= OBJECT_END + 0x005 , // GUID
		UNIT_FIELD_SUMMONEDBY    			= OBJECT_END + 0x006 , // GUID
		UNIT_FIELD_SUMMONEDBY_01 			= OBJECT_END + 0x007 , // GUID
		UNIT_FIELD_CREATEDBY    			= OBJECT_END + 0x008 , // GUID
		UNIT_FIELD_CREATEDBY_01 			= OBJECT_END + 0x009 , // GUID
		UNIT_FIELD_TARGET    			= OBJECT_END + 0x00A , // GUID
		UNIT_FIELD_TARGET_01 			= OBJECT_END + 0x00B , // GUID
		UNIT_FIELD_PERSUADED    			= OBJECT_END + 0x00C , // GUID
		UNIT_FIELD_PERSUADED_01 			= OBJECT_END + 0x00D , // GUID
		UNIT_FIELD_CHANNEL_OBJECT    			= OBJECT_END + 0x00E , // GUID
		UNIT_FIELD_CHANNEL_OBJECT_01 			= OBJECT_END + 0x00F , // GUID
		UNIT_FIELD_HEALTH                   = OBJECT_END + 0x010 , // Int32
		UNIT_FIELD_POWER1                   = OBJECT_END + 0x011 , // Int32
		UNIT_FIELD_POWER2                   = OBJECT_END + 0x012 , // Int32
		UNIT_FIELD_POWER3                   = OBJECT_END + 0x013 , // Int32
		UNIT_FIELD_POWER4                   = OBJECT_END + 0x014 , // Int32
		UNIT_FIELD_POWER5                   = OBJECT_END + 0x015 , // Int32
		UNIT_FIELD_MAXHEALTH                = OBJECT_END + 0x016 , // Int32
		UNIT_FIELD_MAXPOWER1                = OBJECT_END + 0x017 , // Int32
		UNIT_FIELD_MAXPOWER2                = OBJECT_END + 0x018 , // Int32
		UNIT_FIELD_MAXPOWER3                = OBJECT_END + 0x019 , // Int32
		UNIT_FIELD_MAXPOWER4                = OBJECT_END + 0x01A , // Int32
		UNIT_FIELD_MAXPOWER5                = OBJECT_END + 0x01B , // Int32
		UNIT_FIELD_LEVEL                    = OBJECT_END + 0x01C , // Int32
		UNIT_FIELD_FACTIONTEMPLATE          = OBJECT_END + 0x01D , // Int32
		UNIT_FIELD_BYTES_0                  = OBJECT_END + 0x01E , // Bytes
		UNIT_VIRTUAL_ITEM_SLOT_DISPLAY    			= OBJECT_END + 0x01F , // Int32
		UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_01 			= OBJECT_END + 0x020 , // Int32
		UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_02 			= OBJECT_END + 0x021 , // Int32
		UNIT_VIRTUAL_ITEM_INFO    			= OBJECT_END + 0x022 , // Bytes
		UNIT_VIRTUAL_ITEM_INFO_01 			= OBJECT_END + 0x023 , // Bytes
		UNIT_VIRTUAL_ITEM_INFO_02 			= OBJECT_END + 0x024 , // Bytes
		UNIT_VIRTUAL_ITEM_INFO_03 			= OBJECT_END + 0x025 , // Bytes
		UNIT_VIRTUAL_ITEM_INFO_04 			= OBJECT_END + 0x026 , // Bytes
		UNIT_VIRTUAL_ITEM_INFO_05 			= OBJECT_END + 0x027 , // Bytes
		UNIT_FIELD_FLAGS                    = OBJECT_END + 0x028 , // Int32
		UNIT_FIELD_AURA    			= OBJECT_END + 0x029 , // Int32
		UNIT_FIELD_AURA_01 			= OBJECT_END + 0x02A , // Int32
		UNIT_FIELD_AURA_02 			= OBJECT_END + 0x02B , // Int32
		UNIT_FIELD_AURA_03 			= OBJECT_END + 0x02C , // Int32
		UNIT_FIELD_AURA_04 			= OBJECT_END + 0x02D , // Int32
		UNIT_FIELD_AURA_05 			= OBJECT_END + 0x02E , // Int32
		UNIT_FIELD_AURA_06 			= OBJECT_END + 0x02F , // Int32
		UNIT_FIELD_AURA_07 			= OBJECT_END + 0x030 , // Int32
		UNIT_FIELD_AURA_08 			= OBJECT_END + 0x031 , // Int32
		UNIT_FIELD_AURA_09 			= OBJECT_END + 0x032 , // Int32
		UNIT_FIELD_AURA_10 			= OBJECT_END + 0x033 , // Int32
		UNIT_FIELD_AURA_11 			= OBJECT_END + 0x034 , // Int32
		UNIT_FIELD_AURA_12 			= OBJECT_END + 0x035 , // Int32
		UNIT_FIELD_AURA_13 			= OBJECT_END + 0x036 , // Int32
		UNIT_FIELD_AURA_14 			= OBJECT_END + 0x037 , // Int32
		UNIT_FIELD_AURA_15 			= OBJECT_END + 0x038 , // Int32
		UNIT_FIELD_AURA_16 			= OBJECT_END + 0x039 , // Int32
		UNIT_FIELD_AURA_17 			= OBJECT_END + 0x03A , // Int32
		UNIT_FIELD_AURA_18 			= OBJECT_END + 0x03B , // Int32
		UNIT_FIELD_AURA_19 			= OBJECT_END + 0x03C , // Int32
		UNIT_FIELD_AURA_20 			= OBJECT_END + 0x03D , // Int32
		UNIT_FIELD_AURA_21 			= OBJECT_END + 0x03E , // Int32
		UNIT_FIELD_AURA_22 			= OBJECT_END + 0x03F , // Int32
		UNIT_FIELD_AURA_23 			= OBJECT_END + 0x040 , // Int32
		UNIT_FIELD_AURA_24 			= OBJECT_END + 0x041 , // Int32
		UNIT_FIELD_AURA_25 			= OBJECT_END + 0x042 , // Int32
		UNIT_FIELD_AURA_26 			= OBJECT_END + 0x043 , // Int32
		UNIT_FIELD_AURA_27 			= OBJECT_END + 0x044 , // Int32
		UNIT_FIELD_AURA_28 			= OBJECT_END + 0x045 , // Int32
		UNIT_FIELD_AURA_29 			= OBJECT_END + 0x046 , // Int32
		UNIT_FIELD_AURA_30 			= OBJECT_END + 0x047 , // Int32
		UNIT_FIELD_AURA_31 			= OBJECT_END + 0x048 , // Int32
		UNIT_FIELD_AURA_32 			= OBJECT_END + 0x049 , // Int32
		UNIT_FIELD_AURA_33 			= OBJECT_END + 0x04A , // Int32
		UNIT_FIELD_AURA_34 			= OBJECT_END + 0x04B , // Int32
		UNIT_FIELD_AURA_35 			= OBJECT_END + 0x04C , // Int32
		UNIT_FIELD_AURA_36 			= OBJECT_END + 0x04D , // Int32
		UNIT_FIELD_AURA_37 			= OBJECT_END + 0x04E , // Int32
		UNIT_FIELD_AURA_38 			= OBJECT_END + 0x04F , // Int32
		UNIT_FIELD_AURA_39 			= OBJECT_END + 0x050 , // Int32
		UNIT_FIELD_AURA_40 			= OBJECT_END + 0x051 , // Int32
		UNIT_FIELD_AURA_41 			= OBJECT_END + 0x052 , // Int32
		UNIT_FIELD_AURA_42 			= OBJECT_END + 0x053 , // Int32
		UNIT_FIELD_AURA_43 			= OBJECT_END + 0x054 , // Int32
		UNIT_FIELD_AURA_44 			= OBJECT_END + 0x055 , // Int32
		UNIT_FIELD_AURA_45 			= OBJECT_END + 0x056 , // Int32
		UNIT_FIELD_AURA_46 			= OBJECT_END + 0x057 , // Int32
		UNIT_FIELD_AURA_47 			= OBJECT_END + 0x058 , // Int32
		UNIT_FIELD_AURA_48 			= OBJECT_END + 0x059 , // Int32
		UNIT_FIELD_AURA_49 			= OBJECT_END + 0x05A , // Int32
		UNIT_FIELD_AURA_50 			= OBJECT_END + 0x05B , // Int32
		UNIT_FIELD_AURA_51 			= OBJECT_END + 0x05C , // Int32
		UNIT_FIELD_AURA_52 			= OBJECT_END + 0x05D , // Int32
		UNIT_FIELD_AURA_53 			= OBJECT_END + 0x05E , // Int32
		UNIT_FIELD_AURA_54 			= OBJECT_END + 0x05F , // Int32
		UNIT_FIELD_AURA_55 			= OBJECT_END + 0x060 , // Int32
		UNIT_FIELD_AURALEVELS    			= OBJECT_END + 0x061 , // Bytes
		UNIT_FIELD_AURALEVELS_01 			= OBJECT_END + 0x062 , // Bytes
		UNIT_FIELD_AURALEVELS_02 			= OBJECT_END + 0x063 , // Bytes
		UNIT_FIELD_AURALEVELS_03 			= OBJECT_END + 0x064 , // Bytes
		UNIT_FIELD_AURALEVELS_04 			= OBJECT_END + 0x065 , // Bytes
		UNIT_FIELD_AURALEVELS_05 			= OBJECT_END + 0x066 , // Bytes
		UNIT_FIELD_AURALEVELS_06 			= OBJECT_END + 0x067 , // Bytes
		UNIT_FIELD_AURALEVELS_07 			= OBJECT_END + 0x068 , // Bytes
		UNIT_FIELD_AURALEVELS_08 			= OBJECT_END + 0x069 , // Bytes
		UNIT_FIELD_AURALEVELS_09 			= OBJECT_END + 0x06A , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS    			= OBJECT_END + 0x06B , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_01 			= OBJECT_END + 0x06C , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_02 			= OBJECT_END + 0x06D , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_03 			= OBJECT_END + 0x06E , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_04 			= OBJECT_END + 0x06F , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_05 			= OBJECT_END + 0x070 , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_06 			= OBJECT_END + 0x071 , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_07 			= OBJECT_END + 0x072 , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_08 			= OBJECT_END + 0x073 , // Bytes
		UNIT_FIELD_AURAAPPLICATIONS_09 			= OBJECT_END + 0x074 , // Bytes
		UNIT_FIELD_AURAFLAGS    			= OBJECT_END + 0x075 , // Bytes
		UNIT_FIELD_AURAFLAGS_01 			= OBJECT_END + 0x076 , // Bytes
		UNIT_FIELD_AURAFLAGS_02 			= OBJECT_END + 0x077 , // Bytes
		UNIT_FIELD_AURAFLAGS_03 			= OBJECT_END + 0x078 , // Bytes
		UNIT_FIELD_AURAFLAGS_04 			= OBJECT_END + 0x079 , // Bytes
		UNIT_FIELD_AURAFLAGS_05 			= OBJECT_END + 0x07A , // Bytes
		UNIT_FIELD_AURAFLAGS_06 			= OBJECT_END + 0x07B , // Bytes
		UNIT_FIELD_AURASTATE               = OBJECT_END +  0x07C , // Int32
		UNIT_FIELD_BASEATTACKTIME    			= OBJECT_END + 0x07D , // Int32
		UNIT_FIELD_BASEATTACKTIME_01 			= OBJECT_END + 0x07E , // Int32
		UNIT_FIELD_RANGEDATTACKTIME         = OBJECT_END + 0x07F , // Int32
		UNIT_FIELD_BOUNDINGRADIUS          = OBJECT_END +  0x080 , // Float
		UNIT_FIELD_COMBATREACH              = OBJECT_END + 0x081 , // Float
		UNIT_FIELD_DISPLAYID                = OBJECT_END + 0x082 , // Int32
		UNIT_FIELD_NATIVEDISPLAYID          = OBJECT_END + 0x083 , // Int32
		UNIT_FIELD_MOUNTDISPLAYID           = OBJECT_END + 0x084 , // Int32
		UNIT_FIELD_MINDAMAGE                = OBJECT_END + 0x085 , // Float
		UNIT_FIELD_MAXDAMAGE                = OBJECT_END + 0x086 , // Float
		UNIT_FIELD_MINOFFHANDDAMAGE         = OBJECT_END + 0x087 , // Float
		UNIT_FIELD_MAXOFFHANDDAMAGE         = OBJECT_END + 0x088 , // Float
		UNIT_FIELD_BYTES_1                  = OBJECT_END + 0x089 , // Bytes
		UNIT_FIELD_PETNUMBER                = OBJECT_END + 0x08A , // Int32
		UNIT_FIELD_PET_NAME_TIMESTAMP       = OBJECT_END + 0x08B , // Int32
		UNIT_FIELD_PETEXPERIENCE            = OBJECT_END + 0x08C , // Int32
		UNIT_FIELD_PETNEXTLEVELEXP          = OBJECT_END + 0x08D , // Int32
		UNIT_DYNAMIC_FLAGS                  = OBJECT_END + 0x08E , // Int32
		UNIT_CHANNEL_SPELL                  = OBJECT_END + 0x08F , // Int32
		UNIT_MOD_CAST_SPEED                 = OBJECT_END + 0x090 , // Int32
		UNIT_CREATED_BY_SPELL               = OBJECT_END + 0x091 , // Int32
		UNIT_NPC_FLAGS                      = OBJECT_END + 0x092 , // Int32
		UNIT_NPC_EMOTESTATE                 = OBJECT_END + 0x093 , // Int32
		UNIT_TRAINING_POINTS                = OBJECT_END + 0x094 , // Chars?
		UNIT_FIELD_STR                    = OBJECT_END + 0x095 , // Int32
		UNIT_FIELD_AGILITY                    = OBJECT_END + 0x096 , // Int32
		UNIT_FIELD_STAMINA                    = OBJECT_END + 0x097 , // Int32
		UNIT_FIELD_IQ                    = OBJECT_END + 0x098 , // Int32
		UNIT_FIELD_SPIRIT                    = OBJECT_END + 0x099 , // Int32
		UNIT_FIELD_ARMOR    			= OBJECT_END + 0x09A , // Int32
		UNIT_FIELD_RESISTANCES_01 			= OBJECT_END + 0x09B , // Int32
		UNIT_FIELD_RESISTANCES_02 			= OBJECT_END + 0x09C , // Int32
		UNIT_FIELD_RESISTANCES_03 			= OBJECT_END + 0x09D , // Int32
		UNIT_FIELD_RESISTANCES_04 			= OBJECT_END + 0x09E , // Int32
		UNIT_FIELD_RESISTANCES_05 			= OBJECT_END + 0x09F , // Int32
		UNIT_FIELD_RESISTANCES_06 		=	OBJECT_END + 0x0A0 , // Int32
		UNIT_FIELD_ATTACKPOWER             = OBJECT_END + 0x0A1 , // Int32
		UNIT_FIELD_BASE_MANA               = OBJECT_END + 0x0A2 , // Int32
		UNIT_FIELD_ATTACK_POWER_MODS       = OBJECT_END + 0x0A3 , // Chars?
		UNIT_FIELD_BYTES_2                 = OBJECT_END + 0x0A4 , // Bytes
		UNIT_FIELD_RANGEDATTACKPOWER       = OBJECT_END + 0x0A5 , // Int32
		UNIT_FIELD_RANGED_ATTACK_POWER_MODS= OBJECT_END + 0x0A6 , // Chars?
		UNIT_FIELD_MINRANGEDDAMAGE        =  OBJECT_END + 0x0A7 , // Float
		UNIT_FIELD_MAXRANGEDDAMAGE       =   OBJECT_END + 0x0A8 , // Float
		UNIT_FIELD_PADDING              =    OBJECT_END + 0x0A9 , // Int32
		UNIT_END						=	OBJECT_END + 0x0AA,


		PLAYER_SELECTION    			= UNIT_END + 0x000 , // GUID
		PLAYER_SELECTION_01 			= UNIT_END + 0x001 , // GUID
		PLAYER_DUEL_ARBITER    			= UNIT_END + 0x002 , // GUID
		PLAYER_DUEL_ARBITER_01 			= UNIT_END + 0x003 , // GUID
		PLAYER_FLAGS                        = UNIT_END + 0x004 , // Int32
		PLAYER_GUILDID                      = UNIT_END + 0x005 , // Int32
		PLAYER_GUILDRANK                    = UNIT_END + 0x006 , // Int32
		PLAYER_BYTES                        = UNIT_END + 0x007 , // Bytes
		PLAYER_BYTES_2                      = UNIT_END + 0x008 , // Bytes
		PLAYER_BYTES_3                      = UNIT_END + 0x009 , // Bytes
		PLAYER_DUEL_TEAM                    = UNIT_END + 0x00A , // Int32
		PLAYER_GUILD_TIMESTAMP              = UNIT_END + 0x00B , // Int32
		PLAYER_QUEST_LOG_1_1                = UNIT_END + 0x00C , // Int32
		PLAYER_QUEST_LOG_1_2    			= UNIT_END + 0x00D , // Int32
		PLAYER_QUEST_LOG_1_2_01 			= UNIT_END + 0x00E , // Int32
		PLAYER_QUEST_LOG_2_1                = UNIT_END + 0x00F , // Int32
		PLAYER_QUEST_LOG_2_2    			= UNIT_END + 0x010 , // Int32
		PLAYER_QUEST_LOG_2_2_01 			= UNIT_END + 0x011 , // Int32
		PLAYER_QUEST_LOG_3_1                = UNIT_END + 0x012 , // Int32
		PLAYER_QUEST_LOG_3_2    			= UNIT_END + 0x013 , // Int32
		PLAYER_QUEST_LOG_3_2_01 			= UNIT_END + 0x014 , // Int32
		PLAYER_QUEST_LOG_4_1                = UNIT_END + 0x015 , // Int32
		PLAYER_QUEST_LOG_4_2    			= UNIT_END + 0x016 , // Int32
		PLAYER_QUEST_LOG_4_2_01 			= UNIT_END + 0x017 , // Int32
		PLAYER_QUEST_LOG_5_1               = UNIT_END +  0x018 , // Int32
		PLAYER_QUEST_LOG_5_2    			= UNIT_END + 0x019 , // Int32
		PLAYER_QUEST_LOG_5_2_01 			= UNIT_END + 0x01A , // Int32
		PLAYER_QUEST_LOG_6_1                = UNIT_END + 0x01B , // Int32
		PLAYER_QUEST_LOG_6_2    			= UNIT_END + 0x01C , // Int32
		PLAYER_QUEST_LOG_6_2_01 			= UNIT_END + 0x01D , // Int32
		PLAYER_QUEST_LOG_7_1                = UNIT_END + 0x01E , // Int32
		PLAYER_QUEST_LOG_7_2    			= UNIT_END + 0x01F , // Int32
		PLAYER_QUEST_LOG_7_2_01 			= UNIT_END + 0x020 , // Int32
		PLAYER_QUEST_LOG_8_1                = UNIT_END + 0x021 , // Int32
		PLAYER_QUEST_LOG_8_2    			= UNIT_END + 0x022 , // Int32
		PLAYER_QUEST_LOG_8_2_01 			= UNIT_END + 0x023 , // Int32
		PLAYER_QUEST_LOG_9_1                = UNIT_END + 0x024 , // Int32
		PLAYER_QUEST_LOG_9_2    			= UNIT_END + 0x025 , // Int32
		PLAYER_QUEST_LOG_9_2_01 			= UNIT_END + 0x026 , // Int32
		PLAYER_QUEST_LOG_10_1               = UNIT_END + 0x027 , // Int32
		PLAYER_QUEST_LOG_10_2    			= UNIT_END + 0x028 , // Int32
		PLAYER_QUEST_LOG_10_2_01 			= UNIT_END + 0x029 , // Int32
		PLAYER_QUEST_LOG_11_1               = UNIT_END + 0x02A , // Int32
		PLAYER_QUEST_LOG_11_2    			= UNIT_END + 0x02B , // Int32
		PLAYER_QUEST_LOG_11_2_01 			= UNIT_END + 0x02C , // Int32
		PLAYER_QUEST_LOG_12_1               = UNIT_END + 0x02D , // Int32
		PLAYER_QUEST_LOG_12_2    			= UNIT_END + 0x02E , // Int32
		PLAYER_QUEST_LOG_12_2_01 			= UNIT_END + 0x02F , // Int32
		PLAYER_QUEST_LOG_13_1               = UNIT_END + 0x030 , // Int32
		PLAYER_QUEST_LOG_13_2    			= UNIT_END + 0x031 , // Int32
		PLAYER_QUEST_LOG_13_2_01 			= UNIT_END + 0x032 , // Int32
		PLAYER_QUEST_LOG_14_1               = UNIT_END + 0x033 , // Int32
		PLAYER_QUEST_LOG_14_2    			= UNIT_END + 0x034 , // Int32
		PLAYER_QUEST_LOG_14_2_01 			= UNIT_END + 0x035 , // Int32
		PLAYER_QUEST_LOG_15_1              = UNIT_END + 0x036 , // Int32
		PLAYER_QUEST_LOG_15_2    			= UNIT_END + 0x037 , // Int32
		PLAYER_QUEST_LOG_15_2_01 			= UNIT_END + 0x038 , // Int32
		PLAYER_QUEST_LOG_16_1               = UNIT_END + 0x039 , // Int32
		PLAYER_QUEST_LOG_16_2    			= UNIT_END + 0x03A , // Int32
		PLAYER_QUEST_LOG_16_2_01 			= UNIT_END + 0x03B , // Int32
		PLAYER_QUEST_LOG_17_1               = UNIT_END + 0x03C , // Int32
		PLAYER_QUEST_LOG_17_2    			= UNIT_END + 0x03D , // Int32
		PLAYER_QUEST_LOG_17_2_01 			= UNIT_END + 0x03E , // Int32
		PLAYER_QUEST_LOG_18_1               = UNIT_END + 0x03F , // Int32
		PLAYER_QUEST_LOG_18_2    			= UNIT_END + 0x040 , // Int32
		PLAYER_QUEST_LOG_18_2_01 			= UNIT_END + 0x041 , // Int32
		PLAYER_QUEST_LOG_19_1               = UNIT_END + 0x042 , // Int32
		PLAYER_QUEST_LOG_19_2    			= UNIT_END + 0x043 , // Int32
		PLAYER_QUEST_LOG_19_2_01 			= UNIT_END + 0x044 , // Int32
		PLAYER_QUEST_LOG_20_1               = UNIT_END + 0x045 , // Int32
		PLAYER_QUEST_LOG_20_2    			= UNIT_END + 0x046 , // Int32
		PLAYER_QUEST_LOG_20_2_01 			= UNIT_END + 0x047 , // Int32
		PLAYER_VISIBLE_ITEM_1_CREATOR    			= UNIT_END + 0x048 , // GUID
		PLAYER_VISIBLE_ITEM_1_CREATOR_01 			= UNIT_END + 0x049 , // GUID
		PLAYER_VISIBLE_ITEM_1_0    			= UNIT_END + 0x04A , // Int32
		PLAYER_VISIBLE_ITEM_1_0_01 			= UNIT_END + 0x04B , // Int32
		PLAYER_VISIBLE_ITEM_1_0_02 			= UNIT_END + 0x04C , // Int32
		PLAYER_VISIBLE_ITEM_1_0_03 			= UNIT_END + 0x04D , // Int32
		PLAYER_VISIBLE_ITEM_1_0_04 			= UNIT_END + 0x04E , // Int32
		PLAYER_VISIBLE_ITEM_1_0_05 			= UNIT_END + 0x04F , // Int32
		PLAYER_VISIBLE_ITEM_1_0_06 			= UNIT_END + 0x050 , // Int32
		PLAYER_VISIBLE_ITEM_1_0_07 			= UNIT_END + 0x051 , // Int32
		PLAYER_VISIBLE_ITEM_1_PROPERTIES    = UNIT_END + 0x052 , // Chars?
		PLAYER_VISIBLE_ITEM_1_PAD          = UNIT_END +  0x053 , // Int32
		PLAYER_VISIBLE_ITEM_2_CREATOR    			= UNIT_END + 0x054 , // GUID
		PLAYER_VISIBLE_ITEM_2_CREATOR_01 			= UNIT_END + 0x055 , // GUID
		PLAYER_VISIBLE_ITEM_2_0    			= UNIT_END + 0x056 , // Int32
		PLAYER_VISIBLE_ITEM_2_0_01 			= UNIT_END + 0x057 , // Int32
		PLAYER_VISIBLE_ITEM_2_0_02 			= UNIT_END + 0x058 , // Int32
		PLAYER_VISIBLE_ITEM_2_0_03 			= UNIT_END + 0x059 , // Int32
		PLAYER_VISIBLE_ITEM_2_0_04 			= UNIT_END + 0x05A , // Int32
		PLAYER_VISIBLE_ITEM_2_0_05 			= UNIT_END + 0x05B , // Int32
		PLAYER_VISIBLE_ITEM_2_0_06 			= UNIT_END + 0x05C , // Int32
		PLAYER_VISIBLE_ITEM_2_0_07 			= UNIT_END + 0x05D , // Int32
		PLAYER_VISIBLE_ITEM_2_PROPERTIES    = UNIT_END + 0x05E , // Chars?
		PLAYER_VISIBLE_ITEM_2_PAD           = UNIT_END + 0x05F , // Int32
		PLAYER_VISIBLE_ITEM_3_CREATOR    			= UNIT_END + 0x060 , // GUID
		PLAYER_VISIBLE_ITEM_3_CREATOR_01 			= UNIT_END + 0x061 , // GUID
		PLAYER_VISIBLE_ITEM_3_0    			= UNIT_END + 0x062 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_01 			= UNIT_END + 0x063 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_02 			= UNIT_END + 0x064 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_03 			= UNIT_END + 0x065 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_04 			= UNIT_END + 0x066 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_05 			= UNIT_END + 0x067 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_06 			= UNIT_END + 0x068 , // Int32
		PLAYER_VISIBLE_ITEM_3_0_07 			= UNIT_END + 0x069 , // Int32
		PLAYER_VISIBLE_ITEM_3_PROPERTIES    = UNIT_END + 0x06A , // Chars?
		PLAYER_VISIBLE_ITEM_3_PAD           = UNIT_END + 0x06B , // Int32
		PLAYER_VISIBLE_ITEM_4_CREATOR    			= UNIT_END + 0x06C , // GUID
		PLAYER_VISIBLE_ITEM_4_CREATOR_01 			= UNIT_END + 0x06D , // GUID
		PLAYER_VISIBLE_ITEM_4_0    			= UNIT_END + 0x06E , // Int32
		PLAYER_VISIBLE_ITEM_4_0_01 			= UNIT_END + 0x06F , // Int32
		PLAYER_VISIBLE_ITEM_4_0_02 			= UNIT_END + 0x070 , // Int32
		PLAYER_VISIBLE_ITEM_4_0_03 			= UNIT_END + 0x071 , // Int32
		PLAYER_VISIBLE_ITEM_4_0_04 			= UNIT_END + 0x072 , // Int32
		PLAYER_VISIBLE_ITEM_4_0_05 			= UNIT_END + 0x073 , // Int32
		PLAYER_VISIBLE_ITEM_4_0_06 			= UNIT_END + 0x074 , // Int32
		PLAYER_VISIBLE_ITEM_4_0_07 			= UNIT_END + 0x075 , // Int32
		PLAYER_VISIBLE_ITEM_4_PROPERTIES   = UNIT_END +  0x076 , // Chars?
		PLAYER_VISIBLE_ITEM_4_PAD           = UNIT_END + 0x077 , // Int32
		PLAYER_VISIBLE_ITEM_5_CREATOR    			= UNIT_END + 0x078 , // GUID
		PLAYER_VISIBLE_ITEM_5_CREATOR_01 		= UNIT_END + 	0x079 , // GUID
		PLAYER_VISIBLE_ITEM_5_0    			= UNIT_END + 0x07A , // Int32
		PLAYER_VISIBLE_ITEM_5_0_01 			= UNIT_END + 0x07B , // Int32
		PLAYER_VISIBLE_ITEM_5_0_02 			= UNIT_END + 0x07C , // Int32
		PLAYER_VISIBLE_ITEM_5_0_03 			= UNIT_END + 0x07D , // Int32
		PLAYER_VISIBLE_ITEM_5_0_04 			= UNIT_END + 0x07E , // Int32
		PLAYER_VISIBLE_ITEM_5_0_05 			= UNIT_END + 0x07F , // Int32
		PLAYER_VISIBLE_ITEM_5_0_06 			= UNIT_END + 0x080 , // Int32
		PLAYER_VISIBLE_ITEM_5_0_07 			= UNIT_END + 0x081 , // Int32
		PLAYER_VISIBLE_ITEM_5_PROPERTIES    = UNIT_END + 0x082 , // Chars?
		PLAYER_VISIBLE_ITEM_5_PAD           = UNIT_END + 0x083 , // Int32
		PLAYER_VISIBLE_ITEM_6_CREATOR    			= UNIT_END + 0x084 , // GUID
		PLAYER_VISIBLE_ITEM_6_CREATOR_01 			= UNIT_END + 0x085 , // GUID
		PLAYER_VISIBLE_ITEM_6_0    			= UNIT_END + 0x086 , // Int32
		PLAYER_VISIBLE_ITEM_6_0_01 			= UNIT_END + 0x087 , // Int32
		PLAYER_VISIBLE_ITEM_6_0_02 			= UNIT_END + 0x088 , // Int32
		PLAYER_VISIBLE_ITEM_6_0_03 			= UNIT_END + 0x089 , // Int32
		PLAYER_VISIBLE_ITEM_6_0_04 			= UNIT_END + 0x08A , // Int32
		PLAYER_VISIBLE_ITEM_6_0_05 			= UNIT_END + 0x08B , // Int32
		PLAYER_VISIBLE_ITEM_6_0_06 			= UNIT_END + 0x08C , // Int32
		PLAYER_VISIBLE_ITEM_6_0_07 			= UNIT_END + 0x08D , // Int32
		PLAYER_VISIBLE_ITEM_6_PROPERTIES    = UNIT_END + 0x08E , // Chars?
		PLAYER_VISIBLE_ITEM_6_PAD           = UNIT_END + 0x08F , // Int32
		PLAYER_VISIBLE_ITEM_7_CREATOR    			= UNIT_END + 0x090 , // GUID
		PLAYER_VISIBLE_ITEM_7_CREATOR_01 			= UNIT_END + 0x091 , // GUID
		PLAYER_VISIBLE_ITEM_7_0    			= UNIT_END + 0x092 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_01 			= UNIT_END + 0x093 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_02 			= UNIT_END + 0x094 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_03 			= UNIT_END + 0x095 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_04 			= UNIT_END + 0x096 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_05 			= UNIT_END + 0x097 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_06 			= UNIT_END + 0x098 , // Int32
		PLAYER_VISIBLE_ITEM_7_0_07 			= UNIT_END + 0x099 , // Int32
		PLAYER_VISIBLE_ITEM_7_PROPERTIES    = UNIT_END + 0x09A , // Chars?
		PLAYER_VISIBLE_ITEM_7_PAD           = UNIT_END + 0x09B , // Int32
		PLAYER_VISIBLE_ITEM_8_CREATOR    			= UNIT_END + 0x09C , // GUID
		PLAYER_VISIBLE_ITEM_8_CREATOR_01 			= UNIT_END + 0x09D , // GUID
		PLAYER_VISIBLE_ITEM_8_0    			= UNIT_END + 0x09E , // Int32
		PLAYER_VISIBLE_ITEM_8_0_01 			= UNIT_END + 0x09F , // Int32
		PLAYER_VISIBLE_ITEM_8_0_02 			= UNIT_END + 0x0A0 , // Int32
		PLAYER_VISIBLE_ITEM_8_0_03 			= UNIT_END + 0x0A1 , // Int32
		PLAYER_VISIBLE_ITEM_8_0_04 			= UNIT_END + 0x0A2 , // Int32
		PLAYER_VISIBLE_ITEM_8_0_05 			= UNIT_END + 0x0A3 , // Int32
		PLAYER_VISIBLE_ITEM_8_0_06 			= UNIT_END + 0x0A4 , // Int32
		PLAYER_VISIBLE_ITEM_8_0_07 			= UNIT_END + 0x0A5 , // Int32
		PLAYER_VISIBLE_ITEM_8_PROPERTIES    = UNIT_END + 0x0A6 , // Chars?
		PLAYER_VISIBLE_ITEM_8_PAD           = UNIT_END + 0x0A7 , // Int32
		PLAYER_VISIBLE_ITEM_9_CREATOR    			= UNIT_END + 0x0A8 , // GUID
		PLAYER_VISIBLE_ITEM_9_CREATOR_01 			= UNIT_END + 0x0A9 , // GUID
		PLAYER_VISIBLE_ITEM_9_0    			= UNIT_END + 0x0AA , // Int32
		PLAYER_VISIBLE_ITEM_9_0_01 			= UNIT_END + 0x0AB , // Int32
		PLAYER_VISIBLE_ITEM_9_0_02 			= UNIT_END + 0x0AC , // Int32
		PLAYER_VISIBLE_ITEM_9_0_03 			= UNIT_END + 0x0AD , // Int32
		PLAYER_VISIBLE_ITEM_9_0_04 			= UNIT_END + 0x0AE , // Int32
		PLAYER_VISIBLE_ITEM_9_0_05 			= UNIT_END + 0x0AF , // Int32
		PLAYER_VISIBLE_ITEM_9_0_06 			= UNIT_END + 0x0B0 , // Int32
		PLAYER_VISIBLE_ITEM_9_0_07 			= UNIT_END + 0x0B1 , // Int32
		PLAYER_VISIBLE_ITEM_9_PROPERTIES    = UNIT_END + 0x0B2 , // Chars?
		PLAYER_VISIBLE_ITEM_9_PAD           = UNIT_END + 0x0B3 , // Int32
		PLAYER_VISIBLE_ITEM_10_CREATOR    			= UNIT_END + 0x0B4 , // GUID
		PLAYER_VISIBLE_ITEM_10_CREATOR_01 			= UNIT_END + 0x0B5 , // GUID
		PLAYER_VISIBLE_ITEM_10_0    			= UNIT_END + 0x0B6 , // Int32
		PLAYER_VISIBLE_ITEM_10_0_01 			= UNIT_END + 0x0B7 , // Int32
		PLAYER_VISIBLE_ITEM_10_0_02 			= UNIT_END + 0x0B8 , // Int32
		PLAYER_VISIBLE_ITEM_10_0_03 			= UNIT_END + 0x0B9 , // Int32
		PLAYER_VISIBLE_ITEM_10_0_04 			= UNIT_END + 0x0BA , // Int32
		PLAYER_VISIBLE_ITEM_10_0_05 			= UNIT_END + 0x0BB , // Int32
		PLAYER_VISIBLE_ITEM_10_0_06 			= UNIT_END + 0x0BC , // Int32
		PLAYER_VISIBLE_ITEM_10_0_07 			= UNIT_END + 0x0BD , // Int32
		PLAYER_VISIBLE_ITEM_10_PROPERTIES   = UNIT_END + 0x0BE , // Chars?
		PLAYER_VISIBLE_ITEM_10_PAD          = UNIT_END + 0x0BF , // Int32
		PLAYER_VISIBLE_ITEM_11_CREATOR    			= UNIT_END + 0x0C0 , // GUID
		PLAYER_VISIBLE_ITEM_11_CREATOR_01 			= UNIT_END + 0x0C1 , // GUID
		PLAYER_VISIBLE_ITEM_11_0    			= UNIT_END + 0x0C2 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_01 			= UNIT_END + 0x0C3 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_02 			= UNIT_END + 0x0C4 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_03 			= UNIT_END + 0x0C5 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_04 			= UNIT_END + 0x0C6 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_05 			= UNIT_END + 0x0C7 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_06 			= UNIT_END + 0x0C8 , // Int32
		PLAYER_VISIBLE_ITEM_11_0_07 			= UNIT_END + 0x0C9 , // Int32
		PLAYER_VISIBLE_ITEM_11_PROPERTIES   = UNIT_END + 0x0CA , // Chars?
		PLAYER_VISIBLE_ITEM_11_PAD          = UNIT_END + 0x0CB , // Int32
		PLAYER_VISIBLE_ITEM_12_CREATOR    			= UNIT_END + 0x0CC , // GUID
		PLAYER_VISIBLE_ITEM_12_CREATOR_01 			= UNIT_END + 0x0CD , // GUID
		PLAYER_VISIBLE_ITEM_12_0    			= UNIT_END + 0x0CE , // Int32
		PLAYER_VISIBLE_ITEM_12_0_01 			= UNIT_END + 0x0CF , // Int32
		PLAYER_VISIBLE_ITEM_12_0_02 			= UNIT_END + 0x0D0 , // Int32
		PLAYER_VISIBLE_ITEM_12_0_03 			= UNIT_END + 0x0D1 , // Int32
		PLAYER_VISIBLE_ITEM_12_0_04 			= UNIT_END + 0x0D2 , // Int32
		PLAYER_VISIBLE_ITEM_12_0_05 			= UNIT_END + 0x0D3 , // Int32
		PLAYER_VISIBLE_ITEM_12_0_06 			= UNIT_END + 0x0D4 , // Int32
		PLAYER_VISIBLE_ITEM_12_0_07 			= UNIT_END + 0x0D5 , // Int32
		PLAYER_VISIBLE_ITEM_12_PROPERTIES   = UNIT_END + 0x0D6 , // Chars?
		PLAYER_VISIBLE_ITEM_12_PAD          = UNIT_END + 0x0D7 , // Int32
		PLAYER_VISIBLE_ITEM_13_CREATOR    			= UNIT_END + 0x0D8 , // GUID
		PLAYER_VISIBLE_ITEM_13_CREATOR_01 			= UNIT_END + 0x0D9 , // GUID
		PLAYER_VISIBLE_ITEM_13_0    			= UNIT_END + 0x0DA , // Int32
		PLAYER_VISIBLE_ITEM_13_0_01 			= UNIT_END + 0x0DB , // Int32
		PLAYER_VISIBLE_ITEM_13_0_02 			= UNIT_END + 0x0DC , // Int32
		PLAYER_VISIBLE_ITEM_13_0_03 			= UNIT_END + 0x0DD , // Int32
		PLAYER_VISIBLE_ITEM_13_0_04 			= UNIT_END + 0x0DE , // Int32
		PLAYER_VISIBLE_ITEM_13_0_05 			= UNIT_END + 0x0DF , // Int32
		PLAYER_VISIBLE_ITEM_13_0_06 			= UNIT_END + 0x0E0 , // Int32
		PLAYER_VISIBLE_ITEM_13_0_07 			= UNIT_END + 0x0E1 , // Int32
		PLAYER_VISIBLE_ITEM_13_PROPERTIES   = UNIT_END + 0x0E2 , // Chars?
		PLAYER_VISIBLE_ITEM_13_PAD          = UNIT_END + 0x0E3 , // Int32
		PLAYER_VISIBLE_ITEM_14_CREATOR    			= UNIT_END + 0x0E4 , // GUID
		PLAYER_VISIBLE_ITEM_14_CREATOR_01 			= UNIT_END + 0x0E5 , // GUID
		PLAYER_VISIBLE_ITEM_14_0    			= UNIT_END + 0x0E6 , // Int32
		PLAYER_VISIBLE_ITEM_14_0_01 			= UNIT_END + 0x0E7 , // Int32
		PLAYER_VISIBLE_ITEM_14_0_02 			= UNIT_END + 0x0E8 , // Int32
		PLAYER_VISIBLE_ITEM_14_0_03 			= UNIT_END + 0x0E9 , // Int32
		PLAYER_VISIBLE_ITEM_14_0_04 			= UNIT_END + 0x0EA , // Int32
		PLAYER_VISIBLE_ITEM_14_0_05 			= UNIT_END + 0x0EB , // Int32
		PLAYER_VISIBLE_ITEM_14_0_06 			= UNIT_END + 0x0EC , // Int32
		PLAYER_VISIBLE_ITEM_14_0_07 			= UNIT_END + 0x0ED , // Int32
		PLAYER_VISIBLE_ITEM_14_PROPERTIES   = UNIT_END + 0x0EE , // Chars?
		PLAYER_VISIBLE_ITEM_14_PAD          = UNIT_END + 0x0EF , // Int32
		PLAYER_VISIBLE_ITEM_15_CREATOR    			= UNIT_END + 0x0F0 , // GUID
		PLAYER_VISIBLE_ITEM_15_CREATOR_01 			= UNIT_END + 0x0F1 , // GUID
		PLAYER_VISIBLE_ITEM_15_0    			= UNIT_END + 0x0F2 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_01 			= UNIT_END + 0x0F3 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_02 			= UNIT_END + 0x0F4 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_03 			= UNIT_END + 0x0F5 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_04 			= UNIT_END + 0x0F6 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_05 			= UNIT_END + 0x0F7 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_06 			= UNIT_END + 0x0F8 , // Int32
		PLAYER_VISIBLE_ITEM_15_0_07 			= UNIT_END + 0x0F9 , // Int32
		PLAYER_VISIBLE_ITEM_15_PROPERTIES   = UNIT_END + 0x0FA , // Chars?
		PLAYER_VISIBLE_ITEM_15_PAD          = UNIT_END + 0x0FB , // Int32
		PLAYER_VISIBLE_ITEM_16_CREATOR    			= UNIT_END + 0x0FC , // GUID
		PLAYER_VISIBLE_ITEM_16_CREATOR_01 			= UNIT_END + 0x0FD , // GUID
		PLAYER_VISIBLE_ITEM_16_0    			= UNIT_END + 0x0FE , // Int32
		PLAYER_VISIBLE_ITEM_16_0_01 			= UNIT_END + 0x0FF , // Int32
		PLAYER_VISIBLE_ITEM_16_0_02 			= UNIT_END + 0x100 , // Int32
		PLAYER_VISIBLE_ITEM_16_0_03 			= UNIT_END + 0x101 , // Int32
		PLAYER_VISIBLE_ITEM_16_0_04 			= UNIT_END + 0x102 , // Int32
		PLAYER_VISIBLE_ITEM_16_0_05 			= UNIT_END + 0x103 , // Int32
		PLAYER_VISIBLE_ITEM_16_0_06 			= UNIT_END + 0x104 , // Int32
		PLAYER_VISIBLE_ITEM_16_0_07 			= UNIT_END + 0x105 , // Int32
		PLAYER_VISIBLE_ITEM_16_PROPERTIES   = UNIT_END + 0x106 , // Chars?
		PLAYER_VISIBLE_ITEM_16_PAD          = UNIT_END + 0x107 , // Int32
		PLAYER_VISIBLE_ITEM_17_CREATOR    			= UNIT_END + 0x108 , // GUID
		PLAYER_VISIBLE_ITEM_17_CREATOR_01 			= UNIT_END + 0x109 , // GUID
		PLAYER_VISIBLE_ITEM_17_0    			= UNIT_END + 0x10A , // Int32
		PLAYER_VISIBLE_ITEM_17_0_01 			= UNIT_END + 0x10B , // Int32
		PLAYER_VISIBLE_ITEM_17_0_02 			= UNIT_END + 0x10C , // Int32
		PLAYER_VISIBLE_ITEM_17_0_03 			= UNIT_END + 0x10D , // Int32
		PLAYER_VISIBLE_ITEM_17_0_04 			= UNIT_END + 0x10E , // Int32
		PLAYER_VISIBLE_ITEM_17_0_05 			= UNIT_END + 0x10F , // Int32
		PLAYER_VISIBLE_ITEM_17_0_06 			= UNIT_END + 0x110 , // Int32
		PLAYER_VISIBLE_ITEM_17_0_07 			= UNIT_END + 0x111 , // Int32
		PLAYER_VISIBLE_ITEM_17_PROPERTIES   = UNIT_END + 0x112 , // Chars?
		PLAYER_VISIBLE_ITEM_17_PAD          = UNIT_END + 0x113 , // Int32
		PLAYER_VISIBLE_ITEM_18_CREATOR    			= UNIT_END + 0x114 , // GUID
		PLAYER_VISIBLE_ITEM_18_CREATOR_01 			= UNIT_END + 0x115 , // GUID
		PLAYER_VISIBLE_ITEM_18_0    			= UNIT_END + 0x116 , // Int32
		PLAYER_VISIBLE_ITEM_18_0_01 			= UNIT_END + 0x117 , // Int32
		PLAYER_VISIBLE_ITEM_18_0_02 			= UNIT_END + 0x118 , // Int32
		PLAYER_VISIBLE_ITEM_18_0_03 			= UNIT_END + 0x119 , // Int32
		PLAYER_VISIBLE_ITEM_18_0_04 			= UNIT_END + 0x11A , // Int32
		PLAYER_VISIBLE_ITEM_18_0_05 			= UNIT_END + 0x11B , // Int32
		PLAYER_VISIBLE_ITEM_18_0_06 			= UNIT_END + 0x11C , // Int32
		PLAYER_VISIBLE_ITEM_18_0_07 			= UNIT_END + 0x11D , // Int32
		PLAYER_VISIBLE_ITEM_18_PROPERTIES   = UNIT_END + 0x11E , // Chars?
		PLAYER_VISIBLE_ITEM_18_PAD          = UNIT_END + 0x11F , // Int32
		PLAYER_VISIBLE_ITEM_19_CREATOR    			= UNIT_END + 0x120 , // GUID
		PLAYER_VISIBLE_ITEM_19_CREATOR_01 			= UNIT_END + 0x121 , // GUID
		PLAYER_VISIBLE_ITEM_19_0    			= UNIT_END + 0x122 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_01 			= UNIT_END + 0x123 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_02 			= UNIT_END + 0x124 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_03 			= UNIT_END + 0x125 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_04 			= UNIT_END + 0x126 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_05 			= UNIT_END + 0x127 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_06 			= UNIT_END + 0x128 , // Int32
		PLAYER_VISIBLE_ITEM_19_0_07 			= UNIT_END + 0x129 , // Int32
		PLAYER_VISIBLE_ITEM_19_PROPERTIES   = UNIT_END + 0x12A , // Chars?
		PLAYER_VISIBLE_ITEM_19_PAD         = UNIT_END +  0x12B , // Int32
		PLAYER_FIELD_INV_SLOT_HEAD    			= UNIT_END + 0x12C , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_01 			= UNIT_END + 0x12D , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_02 			= UNIT_END + 0x12E , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_03 			= UNIT_END + 0x12F , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_04 			= UNIT_END + 0x130 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_05 			= UNIT_END + 0x131 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_06 			= UNIT_END + 0x132 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_07 			= UNIT_END + 0x133 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_08 			= UNIT_END + 0x134 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_09 			= UNIT_END + 0x135 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_10 			= UNIT_END + 0x136 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_11 			= UNIT_END + 0x137 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_12 			= UNIT_END + 0x138 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_13 			= UNIT_END + 0x139 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_14 			= UNIT_END + 0x13A , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_15 			= UNIT_END + 0x13B , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_16 			= UNIT_END + 0x13C , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_17 			= UNIT_END + 0x13D , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_18 			= UNIT_END + 0x13E , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_19 			= UNIT_END + 0x13F , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_20 			= UNIT_END + 0x140 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_21 			= UNIT_END + 0x141 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_22 			= UNIT_END + 0x142 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_23 			= UNIT_END + 0x143 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_24 			= UNIT_END + 0x144 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_25 			= UNIT_END + 0x145 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_26 			= UNIT_END + 0x146 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_27 			= UNIT_END + 0x147 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_28 			= UNIT_END + 0x148 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_29 			= UNIT_END + 0x149 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_30 			= UNIT_END + 0x14A , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_31 			= UNIT_END + 0x14B , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_32 			= UNIT_END + 0x14C , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_33 			= UNIT_END + 0x14D , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_34 			= UNIT_END + 0x14E , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_35 			= UNIT_END + 0x14F , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_36 			= UNIT_END + 0x150 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_37 			= UNIT_END + 0x151 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_38 			= UNIT_END + 0x152 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_39 			= UNIT_END + 0x153 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_40 			= UNIT_END + 0x154 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_41 			= UNIT_END + 0x155 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_42 			= UNIT_END + 0x156 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_43 			= UNIT_END + 0x157 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_44 			= UNIT_END + 0x158 , // GUID
		PLAYER_FIELD_INV_SLOT_HEAD_45 			= UNIT_END + 0x159 , // GUID
		PLAYER_FIELD_PACK_SLOT_1    			= UNIT_END + 0x15A , // GUID
		PLAYER_FIELD_PACK_SLOT_1_01 			= UNIT_END + 0x15B , // GUID
		PLAYER_FIELD_PACK_SLOT_1_02 			= UNIT_END + 0x15C , // GUID
		PLAYER_FIELD_PACK_SLOT_1_03 			= UNIT_END + 0x15D , // GUID
		PLAYER_FIELD_PACK_SLOT_1_04 			= UNIT_END + 0x15E , // GUID
		PLAYER_FIELD_PACK_SLOT_1_05 			= UNIT_END + 0x15F , // GUID
		PLAYER_FIELD_PACK_SLOT_1_06 			= UNIT_END + 0x160 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_07 			= UNIT_END + 0x161 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_08 			= UNIT_END + 0x162 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_09 			= UNIT_END + 0x163 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_10 			= UNIT_END + 0x164 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_11 			= UNIT_END + 0x165 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_12 			= UNIT_END + 0x166 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_13 			= UNIT_END + 0x167 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_14 			= UNIT_END + 0x168 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_15 			= UNIT_END + 0x169 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_16 			= UNIT_END + 0x16A , // GUID
		PLAYER_FIELD_PACK_SLOT_1_17 			= UNIT_END + 0x16B , // GUID
		PLAYER_FIELD_PACK_SLOT_1_18 			= UNIT_END + 0x16C , // GUID
		PLAYER_FIELD_PACK_SLOT_1_19 			= UNIT_END + 0x16D , // GUID
		PLAYER_FIELD_PACK_SLOT_1_20 			= UNIT_END + 0x16E , // GUID
		PLAYER_FIELD_PACK_SLOT_1_21 			= UNIT_END + 0x16F , // GUID
		PLAYER_FIELD_PACK_SLOT_1_22 			= UNIT_END + 0x170 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_23 			= UNIT_END + 0x171 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_24 			= UNIT_END + 0x172 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_25 			= UNIT_END + 0x173 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_26 			= UNIT_END + 0x174 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_27 			= UNIT_END + 0x175 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_28 			= UNIT_END + 0x176 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_29 			= UNIT_END + 0x177 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_30 			= UNIT_END + 0x178 , // GUID
		PLAYER_FIELD_PACK_SLOT_1_31 			= UNIT_END + 0x179 , // GUID
		PLAYER_FIELD_BANK_SLOT_1    			= UNIT_END + 0x17A , // GUID
		PLAYER_FIELD_BANK_SLOT_1_01 			= UNIT_END + 0x17B , // GUID
		PLAYER_FIELD_BANK_SLOT_1_02 			= UNIT_END + 0x17C , // GUID
		PLAYER_FIELD_BANK_SLOT_1_03 			= UNIT_END + 0x17D , // GUID
		PLAYER_FIELD_BANK_SLOT_1_04 			= UNIT_END + 0x17E , // GUID
		PLAYER_FIELD_BANK_SLOT_1_05 			= UNIT_END + 0x17F , // GUID
		PLAYER_FIELD_BANK_SLOT_1_06 			= UNIT_END + 0x180 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_07 			= UNIT_END + 0x181 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_08 			= UNIT_END + 0x182 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_09 			= UNIT_END + 0x183 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_10 			= UNIT_END + 0x184 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_11 			= UNIT_END + 0x185 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_12 			= UNIT_END + 0x186 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_13 			= UNIT_END + 0x187 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_14 			= UNIT_END + 0x188 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_15 			= UNIT_END + 0x189 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_16 			= UNIT_END + 0x18A , // GUID
		PLAYER_FIELD_BANK_SLOT_1_17 			= UNIT_END + 0x18B , // GUID
		PLAYER_FIELD_BANK_SLOT_1_18 			= UNIT_END + 0x18C , // GUID
		PLAYER_FIELD_BANK_SLOT_1_19 			= UNIT_END + 0x18D , // GUID
		PLAYER_FIELD_BANK_SLOT_1_20 			= UNIT_END + 0x18E , // GUID
		PLAYER_FIELD_BANK_SLOT_1_21 			= UNIT_END + 0x18F , // GUID
		PLAYER_FIELD_BANK_SLOT_1_22 			= UNIT_END + 0x190 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_23 			= UNIT_END + 0x191 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_24 			= UNIT_END + 0x192 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_25 			= UNIT_END + 0x193 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_26 			= UNIT_END + 0x194 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_27 			= UNIT_END + 0x195 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_28 			= UNIT_END + 0x196 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_29 			= UNIT_END + 0x197 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_30 			= UNIT_END + 0x198 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_31 			= UNIT_END + 0x199 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_32 			= UNIT_END + 0x19A , // GUID
		PLAYER_FIELD_BANK_SLOT_1_33 			= UNIT_END + 0x19B , // GUID
		PLAYER_FIELD_BANK_SLOT_1_34 			= UNIT_END + 0x19C , // GUID
		PLAYER_FIELD_BANK_SLOT_1_35 			= UNIT_END + 0x19D , // GUID
		PLAYER_FIELD_BANK_SLOT_1_36 			= UNIT_END + 0x19E , // GUID
		PLAYER_FIELD_BANK_SLOT_1_37 			= UNIT_END + 0x19F , // GUID
		PLAYER_FIELD_BANK_SLOT_1_38 			= UNIT_END + 0x1A0 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_39 			= UNIT_END + 0x1A1 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_40 			= UNIT_END + 0x1A2 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_41 			= UNIT_END + 0x1A3 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_42 			= UNIT_END + 0x1A4 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_43 			= UNIT_END + 0x1A5 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_44 			= UNIT_END + 0x1A6 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_45 			= UNIT_END + 0x1A7 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_46 			= UNIT_END + 0x1A8 , // GUID
		PLAYER_FIELD_BANK_SLOT_1_47 			= UNIT_END + 0x1A9 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1    			= UNIT_END + 0x1AA , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_01 			= UNIT_END + 0x1AB , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_02 			= UNIT_END + 0x1AC , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_03 			= UNIT_END + 0x1AD , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_04 			= UNIT_END + 0x1AE , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_05 			= UNIT_END + 0x1AF , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_06 			= UNIT_END + 0x1B0 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_07 			= UNIT_END + 0x1B1 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_08 			= UNIT_END + 0x1B2 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_09 			= UNIT_END + 0x1B3 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_10 			= UNIT_END + 0x1B4 , // GUID
		PLAYER_FIELD_BANKBAG_SLOT_1_11 			= UNIT_END + 0x1B5 , // GUID
		PLAYER_FIELD_VENDORBUYBACK_SLOT    			= UNIT_END + 0x1B6 , // GUID
		PLAYER_FIELD_VENDORBUYBACK_SLOT_01 			= UNIT_END + 0x1B7 , // GUID
		PLAYER_FARSIGHT    			= UNIT_END + 0x1B8 , // GUID
		PLAYER_FARSIGHT_01 			= UNIT_END + 0x1B9 , // GUID
		PLAYER__FIELD_COMBO_TARGET    			= UNIT_END + 0x1BA , // GUID
		PLAYER__FIELD_COMBO_TARGET_01 			= UNIT_END + 0x1BB , // GUID
		PLAYER_FIELD_BUYBACK_NPC    			= UNIT_END + 0x1BC , // GUID
		PLAYER_FIELD_BUYBACK_NPC_01 			= UNIT_END + 0x1BD , // GUID
		PLAYER_XP                           = UNIT_END + 0x1BE , // Int32
		PLAYER_NEXT_LEVEL_XP                = UNIT_END + 0x1BF , // Int32
		PLAYER_SKILL_INFO_1_1    			= UNIT_END + 0x1C0 , // Chars?
		PLAYER_SKILL_INFO_1_1_01 			= UNIT_END + 0x1C1 , // Chars?
		PLAYER_SKILL_INFO_1_1_02 			= UNIT_END + 0x1C2 , // Chars?
		PLAYER_SKILL_INFO_1_1_03 			= UNIT_END + 0x1C3 , // Chars?
		PLAYER_SKILL_INFO_1_1_04 			= UNIT_END + 0x1C4 , // Chars?
		PLAYER_SKILL_INFO_1_1_05 			= UNIT_END + 0x1C5 , // Chars?
		PLAYER_SKILL_INFO_1_1_06 			= UNIT_END + 0x1C6 , // Chars?
		PLAYER_SKILL_INFO_1_1_07 			= UNIT_END + 0x1C7 , // Chars?
		PLAYER_SKILL_INFO_1_1_08 			= UNIT_END + 0x1C8 , // Chars?
		PLAYER_SKILL_INFO_1_1_09 			= UNIT_END + 0x1C9 , // Chars?
		PLAYER_SKILL_INFO_1_1_10 			= UNIT_END + 0x1CA , // Chars?
		PLAYER_SKILL_INFO_1_1_11 			= UNIT_END + 0x1CB , // Chars?
		PLAYER_SKILL_INFO_1_1_12 			= UNIT_END + 0x1CC , // Chars?
		PLAYER_SKILL_INFO_1_1_13 			= UNIT_END + 0x1CD , // Chars?
		PLAYER_SKILL_INFO_1_1_14 			= UNIT_END + 0x1CE , // Chars?
		PLAYER_SKILL_INFO_1_1_15 			= UNIT_END + 0x1CF , // Chars?
		PLAYER_SKILL_INFO_1_1_16 			= UNIT_END + 0x1D0 , // Chars?
		PLAYER_SKILL_INFO_1_1_17 			= UNIT_END + 0x1D1 , // Chars?
		PLAYER_SKILL_INFO_1_1_18 			= UNIT_END + 0x1D2 , // Chars?
		PLAYER_SKILL_INFO_1_1_19 			= UNIT_END + 0x1D3 , // Chars?
		PLAYER_SKILL_INFO_1_1_20 			= UNIT_END + 0x1D4 , // Chars?
		PLAYER_SKILL_INFO_1_1_21 			= UNIT_END + 0x1D5 , // Chars?
		PLAYER_SKILL_INFO_1_1_22 			= UNIT_END + 0x1D6 , // Chars?
		PLAYER_SKILL_INFO_1_1_23 			= UNIT_END + 0x1D7 , // Chars?
		PLAYER_SKILL_INFO_1_1_24 			= UNIT_END + 0x1D8 , // Chars?
		PLAYER_SKILL_INFO_1_1_25 			= UNIT_END + 0x1D9 , // Chars?
		PLAYER_SKILL_INFO_1_1_26 			= UNIT_END + 0x1DA , // Chars?
		PLAYER_SKILL_INFO_1_1_27 			= UNIT_END + 0x1DB , // Chars?
		PLAYER_SKILL_INFO_1_1_28 			= UNIT_END + 0x1DC , // Chars?
		PLAYER_SKILL_INFO_1_1_29 			= UNIT_END + 0x1DD , // Chars?
		PLAYER_SKILL_INFO_1_1_30 			= UNIT_END + 0x1DE , // Chars?
		PLAYER_SKILL_INFO_1_1_31 			= UNIT_END + 0x1DF , // Chars?
		PLAYER_SKILL_INFO_1_1_32 			= UNIT_END + 0x1E0 , // Chars?
		PLAYER_SKILL_INFO_1_1_33 			= UNIT_END + 0x1E1 , // Chars?
		PLAYER_SKILL_INFO_1_1_34 			= UNIT_END + 0x1E2 , // Chars?
		PLAYER_SKILL_INFO_1_1_35 			= UNIT_END + 0x1E3 , // Chars?
		PLAYER_SKILL_INFO_1_1_36 			= UNIT_END + 0x1E4 , // Chars?
		PLAYER_SKILL_INFO_1_1_37 			= UNIT_END + 0x1E5 , // Chars?
		PLAYER_SKILL_INFO_1_1_38 			= UNIT_END + 0x1E6 , // Chars?
		PLAYER_SKILL_INFO_1_1_39 			= UNIT_END + 0x1E7 , // Chars?
		PLAYER_SKILL_INFO_1_1_40 			= UNIT_END + 0x1E8 , // Chars?
		PLAYER_SKILL_INFO_1_1_41 			= UNIT_END + 0x1E9 , // Chars?
		PLAYER_SKILL_INFO_1_1_42 			= UNIT_END + 0x1EA , // Chars?
		PLAYER_SKILL_INFO_1_1_43 			= UNIT_END + 0x1EB , // Chars?
		PLAYER_SKILL_INFO_1_1_44 			= UNIT_END + 0x1EC , // Chars?
		PLAYER_SKILL_INFO_1_1_45 			= UNIT_END + 0x1ED , // Chars?
		PLAYER_SKILL_INFO_1_1_46 			= UNIT_END + 0x1EE , // Chars?
		PLAYER_SKILL_INFO_1_1_47 			= UNIT_END + 0x1EF , // Chars?
		PLAYER_SKILL_INFO_1_1_48 			= UNIT_END + 0x1F0 , // Chars?
		PLAYER_SKILL_INFO_1_1_49 			= UNIT_END + 0x1F1 , // Chars?
		PLAYER_SKILL_INFO_1_1_50 			= UNIT_END + 0x1F2 , // Chars?
		PLAYER_SKILL_INFO_1_1_51 			= UNIT_END + 0x1F3 , // Chars?
		PLAYER_SKILL_INFO_1_1_52 			= UNIT_END + 0x1F4 , // Chars?
		PLAYER_SKILL_INFO_1_1_53 			= UNIT_END + 0x1F5 , // Chars?
		PLAYER_SKILL_INFO_1_1_54 			= UNIT_END + 0x1F6 , // Chars?
		PLAYER_SKILL_INFO_1_1_55 			= UNIT_END + 0x1F7 , // Chars?
		PLAYER_SKILL_INFO_1_1_56 			= UNIT_END + 0x1F8 , // Chars?
		PLAYER_SKILL_INFO_1_1_57 			= UNIT_END + 0x1F9 , // Chars?
		PLAYER_SKILL_INFO_1_1_58 			= UNIT_END + 0x1FA , // Chars?
		PLAYER_SKILL_INFO_1_1_59 			= UNIT_END + 0x1FB , // Chars?
		PLAYER_SKILL_INFO_1_1_60 			= UNIT_END + 0x1FC , // Chars?
		PLAYER_SKILL_INFO_1_1_61 			= UNIT_END + 0x1FD , // Chars?
		PLAYER_SKILL_INFO_1_1_62 			= UNIT_END + 0x1FE , // Chars?
		PLAYER_SKILL_INFO_1_1_63 			= UNIT_END + 0x1FF , // Chars?
		PLAYER_SKILL_INFO_1_1_64 			= UNIT_END + 0x200 , // Chars?
		PLAYER_SKILL_INFO_1_1_65 			= UNIT_END + 0x201 , // Chars?
		PLAYER_SKILL_INFO_1_1_66 			= UNIT_END + 0x202 , // Chars?
		PLAYER_SKILL_INFO_1_1_67 			= UNIT_END + 0x203 , // Chars?
		PLAYER_SKILL_INFO_1_1_68 			= UNIT_END + 0x204 , // Chars?
		PLAYER_SKILL_INFO_1_1_69 			= UNIT_END + 0x205 , // Chars?
		PLAYER_SKILL_INFO_1_1_70 			= UNIT_END + 0x206 , // Chars?
		PLAYER_SKILL_INFO_1_1_71 			= UNIT_END + 0x207 , // Chars?
		PLAYER_SKILL_INFO_1_1_72 			= UNIT_END + 0x208 , // Chars?
		PLAYER_SKILL_INFO_1_1_73 			= UNIT_END + 0x209 , // Chars?
		PLAYER_SKILL_INFO_1_1_74 			= UNIT_END + 0x20A , // Chars?
		PLAYER_SKILL_INFO_1_1_75 			= UNIT_END + 0x20B , // Chars?
		PLAYER_SKILL_INFO_1_1_76 			= UNIT_END + 0x20C , // Chars?
		PLAYER_SKILL_INFO_1_1_77 			= UNIT_END + 0x20D , // Chars?
		PLAYER_SKILL_INFO_1_1_78 			= UNIT_END + 0x20E , // Chars?
		PLAYER_SKILL_INFO_1_1_79 			= UNIT_END + 0x20F , // Chars?
		PLAYER_SKILL_INFO_1_1_80 			= UNIT_END + 0x210 , // Chars?
		PLAYER_SKILL_INFO_1_1_81 			= UNIT_END + 0x211 , // Chars?
		PLAYER_SKILL_INFO_1_1_82 			= UNIT_END + 0x212 , // Chars?
		PLAYER_SKILL_INFO_1_1_83 			= UNIT_END + 0x213 , // Chars?
		PLAYER_SKILL_INFO_1_1_84 			= UNIT_END + 0x214 , // Chars?
		PLAYER_SKILL_INFO_1_1_85 			= UNIT_END + 0x215 , // Chars?
		PLAYER_SKILL_INFO_1_1_86 			= UNIT_END + 0x216 , // Chars?
		PLAYER_SKILL_INFO_1_1_87 			= UNIT_END + 0x217 , // Chars?
		PLAYER_SKILL_INFO_1_1_88 			= UNIT_END + 0x218 , // Chars?
		PLAYER_SKILL_INFO_1_1_89 			= UNIT_END + 0x219 , // Chars?
		PLAYER_SKILL_INFO_1_1_90 			= UNIT_END + 0x21A , // Chars?
		PLAYER_SKILL_INFO_1_1_91 			= UNIT_END + 0x21B , // Chars?
		PLAYER_SKILL_INFO_1_1_92 			= UNIT_END + 0x21C , // Chars?
		PLAYER_SKILL_INFO_1_1_93 			= UNIT_END + 0x21D , // Chars?
		PLAYER_SKILL_INFO_1_1_94 			= UNIT_END + 0x21E , // Chars?
		PLAYER_SKILL_INFO_1_1_95 			= UNIT_END + 0x21F , // Chars?
		PLAYER_SKILL_INFO_1_1_96 			= UNIT_END + 0x220 , // Chars?
		PLAYER_SKILL_INFO_1_1_97 			= UNIT_END + 0x221 , // Chars?
		PLAYER_SKILL_INFO_1_1_98 			= UNIT_END + 0x222 , // Chars?
		PLAYER_SKILL_INFO_1_1_99 			= UNIT_END + 0x223 , // Chars?
		PLAYER_SKILL_INFO_1_1_100 			= UNIT_END + 0x224 , // Chars?
		PLAYER_SKILL_INFO_1_1_101 			= UNIT_END + 0x225 , // Chars?
		PLAYER_SKILL_INFO_1_1_102 			= UNIT_END + 0x226 , // Chars?
		PLAYER_SKILL_INFO_1_1_103 			= UNIT_END + 0x227 , // Chars?
		PLAYER_SKILL_INFO_1_1_104 			= UNIT_END + 0x228 , // Chars?
		PLAYER_SKILL_INFO_1_1_105 			= UNIT_END + 0x229 , // Chars?
		PLAYER_SKILL_INFO_1_1_106 			= UNIT_END + 0x22A , // Chars?
		PLAYER_SKILL_INFO_1_1_107 			= UNIT_END + 0x22B , // Chars?
		PLAYER_SKILL_INFO_1_1_108 			= UNIT_END + 0x22C , // Chars?
		PLAYER_SKILL_INFO_1_1_109 			= UNIT_END + 0x22D , // Chars?
		PLAYER_SKILL_INFO_1_1_110 			= UNIT_END + 0x22E , // Chars?
		PLAYER_SKILL_INFO_1_1_111 			= UNIT_END + 0x22F , // Chars?
		PLAYER_SKILL_INFO_1_1_112 			= UNIT_END + 0x230 , // Chars?
		PLAYER_SKILL_INFO_1_1_113 			= UNIT_END + 0x231 , // Chars?
		PLAYER_SKILL_INFO_1_1_114 			= UNIT_END + 0x232 , // Chars?
		PLAYER_SKILL_INFO_1_1_115 			= UNIT_END + 0x233 , // Chars?
		PLAYER_SKILL_INFO_1_1_116 			= UNIT_END + 0x234 , // Chars?
		PLAYER_SKILL_INFO_1_1_117 			= UNIT_END + 0x235 , // Chars?
		PLAYER_SKILL_INFO_1_1_118 			= UNIT_END + 0x236 , // Chars?
		PLAYER_SKILL_INFO_1_1_119 			= UNIT_END + 0x237 , // Chars?
		PLAYER_SKILL_INFO_1_1_120 			= UNIT_END + 0x238 , // Chars?
		PLAYER_SKILL_INFO_1_1_121 			= UNIT_END + 0x239 , // Chars?
		PLAYER_SKILL_INFO_1_1_122 			= UNIT_END + 0x23A , // Chars?
		PLAYER_SKILL_INFO_1_1_123 			= UNIT_END + 0x23B , // Chars?
		PLAYER_SKILL_INFO_1_1_124 			= UNIT_END + 0x23C , // Chars?
		PLAYER_SKILL_INFO_1_1_125 			= UNIT_END + 0x23D , // Chars?
		PLAYER_SKILL_INFO_1_1_126 			= UNIT_END + 0x23E , // Chars?
		PLAYER_SKILL_INFO_1_1_127 			= UNIT_END + 0x23F , // Chars?
		PLAYER_SKILL_INFO_1_1_128 			= UNIT_END + 0x240 , // Chars?
		PLAYER_SKILL_INFO_1_1_129 			= UNIT_END + 0x241 , // Chars?
		PLAYER_SKILL_INFO_1_1_130 			= UNIT_END + 0x242 , // Chars?
		PLAYER_SKILL_INFO_1_1_131 			= UNIT_END + 0x243 , // Chars?
		PLAYER_SKILL_INFO_1_1_132 			= UNIT_END + 0x244 , // Chars?
		PLAYER_SKILL_INFO_1_1_133 			= UNIT_END + 0x245 , // Chars?
		PLAYER_SKILL_INFO_1_1_134 			= UNIT_END + 0x246 , // Chars?
		PLAYER_SKILL_INFO_1_1_135 			= UNIT_END + 0x247 , // Chars?
		PLAYER_SKILL_INFO_1_1_136 			= UNIT_END + 0x248 , // Chars?
		PLAYER_SKILL_INFO_1_1_137 			= UNIT_END + 0x249 , // Chars?
		PLAYER_SKILL_INFO_1_1_138 			= UNIT_END + 0x24A , // Chars?
		PLAYER_SKILL_INFO_1_1_139 			= UNIT_END + 0x24B , // Chars?
		PLAYER_SKILL_INFO_1_1_140 			= UNIT_END + 0x24C , // Chars?
		PLAYER_SKILL_INFO_1_1_141 			= UNIT_END + 0x24D , // Chars?
		PLAYER_SKILL_INFO_1_1_142 			= UNIT_END + 0x24E , // Chars?
		PLAYER_SKILL_INFO_1_1_143 			= UNIT_END + 0x24F , // Chars?
		PLAYER_SKILL_INFO_1_1_144 			= UNIT_END + 0x250 , // Chars?
		PLAYER_SKILL_INFO_1_1_145 			= UNIT_END + 0x251 , // Chars?
		PLAYER_SKILL_INFO_1_1_146 			= UNIT_END + 0x252 , // Chars?
		PLAYER_SKILL_INFO_1_1_147 			= UNIT_END + 0x253 , // Chars?
		PLAYER_SKILL_INFO_1_1_148 			= UNIT_END + 0x254 , // Chars?
		PLAYER_SKILL_INFO_1_1_149 			= UNIT_END + 0x255 , // Chars?
		PLAYER_SKILL_INFO_1_1_150 			= UNIT_END + 0x256 , // Chars?
		PLAYER_SKILL_INFO_1_1_151 			= UNIT_END + 0x257 , // Chars?
		PLAYER_SKILL_INFO_1_1_152 			= UNIT_END + 0x258 , // Chars?
		PLAYER_SKILL_INFO_1_1_153 			= UNIT_END + 0x259 , // Chars?
		PLAYER_SKILL_INFO_1_1_154 			= UNIT_END + 0x25A , // Chars?
		PLAYER_SKILL_INFO_1_1_155 			= UNIT_END + 0x25B , // Chars?
		PLAYER_SKILL_INFO_1_1_156 			= UNIT_END + 0x25C , // Chars?
		PLAYER_SKILL_INFO_1_1_157 			= UNIT_END + 0x25D , // Chars?
		PLAYER_SKILL_INFO_1_1_158 			= UNIT_END + 0x25E , // Chars?
		PLAYER_SKILL_INFO_1_1_159 			= UNIT_END + 0x25F , // Chars?
		PLAYER_SKILL_INFO_1_1_160 			= UNIT_END + 0x260 , // Chars?
		PLAYER_SKILL_INFO_1_1_161 			= UNIT_END + 0x261 , // Chars?
		PLAYER_SKILL_INFO_1_1_162 			= UNIT_END + 0x262 , // Chars?
		PLAYER_SKILL_INFO_1_1_163 			= UNIT_END + 0x263 , // Chars?
		PLAYER_SKILL_INFO_1_1_164 			= UNIT_END + 0x264 , // Chars?
		PLAYER_SKILL_INFO_1_1_165 			= UNIT_END + 0x265 , // Chars?
		PLAYER_SKILL_INFO_1_1_166 			= UNIT_END + 0x266 , // Chars?
		PLAYER_SKILL_INFO_1_1_167 			= UNIT_END + 0x267 , // Chars?
		PLAYER_SKILL_INFO_1_1_168 			= UNIT_END + 0x268 , // Chars?
		PLAYER_SKILL_INFO_1_1_169 			= UNIT_END + 0x269 , // Chars?
		PLAYER_SKILL_INFO_1_1_170 			= UNIT_END + 0x26A , // Chars?
		PLAYER_SKILL_INFO_1_1_171 			= UNIT_END + 0x26B , // Chars?
		PLAYER_SKILL_INFO_1_1_172 			= UNIT_END + 0x26C , // Chars?
		PLAYER_SKILL_INFO_1_1_173 			= UNIT_END + 0x26D , // Chars?
		PLAYER_SKILL_INFO_1_1_174 			= UNIT_END + 0x26E , // Chars?
		PLAYER_SKILL_INFO_1_1_175 			= UNIT_END + 0x26F , // Chars?
		PLAYER_SKILL_INFO_1_1_176 			= UNIT_END + 0x270 , // Chars?
		PLAYER_SKILL_INFO_1_1_177 			= UNIT_END + 0x271 , // Chars?
		PLAYER_SKILL_INFO_1_1_178 			= UNIT_END + 0x272 , // Chars?
		PLAYER_SKILL_INFO_1_1_179 			= UNIT_END + 0x273 , // Chars?
		PLAYER_SKILL_INFO_1_1_180 		  = UNIT_END + 0x274 , // Chars?
		PLAYER_SKILL_INFO_1_1_181 			= UNIT_END + 0x275 , // Chars?
		PLAYER_SKILL_INFO_1_1_182 			= UNIT_END + 0x276 , // Chars?
		PLAYER_SKILL_INFO_1_1_183 			= UNIT_END + 0x277 , // Chars?
		PLAYER_SKILL_INFO_1_1_184 			= UNIT_END + 0x278 , // Chars?
		PLAYER_SKILL_INFO_1_1_185 			= UNIT_END + 0x279 , // Chars?
		PLAYER_SKILL_INFO_1_1_186 			= UNIT_END + 0x27A , // Chars?
		PLAYER_SKILL_INFO_1_1_187 			= UNIT_END + 0x27B , // Chars?
		PLAYER_SKILL_INFO_1_1_188 			= UNIT_END + 0x27C , // Chars?
		PLAYER_SKILL_INFO_1_1_189 			= UNIT_END + 0x27D , // Chars?
		PLAYER_SKILL_INFO_1_1_190 			= UNIT_END + 0x27E , // Chars?
		PLAYER_SKILL_INFO_1_1_191 			= UNIT_END + 0x27F , // Chars?
		PLAYER_SKILL_INFO_1_1_192 			= UNIT_END + 0x280 , // Chars?
		PLAYER_SKILL_INFO_1_1_193 			= UNIT_END + 0x281 , // Chars?
		PLAYER_SKILL_INFO_1_1_194 			= UNIT_END + 0x282 , // Chars?
		PLAYER_SKILL_INFO_1_1_195 			= UNIT_END + 0x283 , // Chars?
		PLAYER_SKILL_INFO_1_1_196 			= UNIT_END + 0x284 , // Chars?
		PLAYER_SKILL_INFO_1_1_197 			= UNIT_END + 0x285 , // Chars?
		PLAYER_SKILL_INFO_1_1_198 			= UNIT_END + 0x286 , // Chars?
		PLAYER_SKILL_INFO_1_1_199 			= UNIT_END + 0x287 , // Chars?
		PLAYER_SKILL_INFO_1_1_200 			= UNIT_END + 0x288 , // Chars?
		PLAYER_SKILL_INFO_1_1_201 			= UNIT_END + 0x289 , // Chars?
		PLAYER_SKILL_INFO_1_1_202 			= UNIT_END + 0x28A , // Chars?
		PLAYER_SKILL_INFO_1_1_203 			= UNIT_END + 0x28B , // Chars?
		PLAYER_SKILL_INFO_1_1_204 			= UNIT_END + 0x28C , // Chars?
		PLAYER_SKILL_INFO_1_1_205 			= UNIT_END + 0x28D , // Chars?
		PLAYER_SKILL_INFO_1_1_206 			= UNIT_END + 0x28E , // Chars?
		PLAYER_SKILL_INFO_1_1_207 			= UNIT_END + 0x28F , // Chars?
		PLAYER_SKILL_INFO_1_1_208 			= UNIT_END + 0x290 , // Chars?
		PLAYER_SKILL_INFO_1_1_209 			= UNIT_END + 0x291 , // Chars?
		PLAYER_SKILL_INFO_1_1_210 			= UNIT_END + 0x292 , // Chars?
		PLAYER_SKILL_INFO_1_1_211 			= UNIT_END + 0x293 , // Chars?
		PLAYER_SKILL_INFO_1_1_212 			= UNIT_END + 0x294 , // Chars?
		PLAYER_SKILL_INFO_1_1_213 			= UNIT_END + 0x295 , // Chars?
		PLAYER_SKILL_INFO_1_1_214 			= UNIT_END + 0x296 , // Chars?
		PLAYER_SKILL_INFO_1_1_215 			= UNIT_END + 0x297 , // Chars?
		PLAYER_SKILL_INFO_1_1_216 			= UNIT_END + 0x298 , // Chars?
		PLAYER_SKILL_INFO_1_1_217 			= UNIT_END + 0x299 , // Chars?
		PLAYER_SKILL_INFO_1_1_218 			= UNIT_END + 0x29A , // Chars?
		PLAYER_SKILL_INFO_1_1_219 			= UNIT_END + 0x29B , // Chars?
		PLAYER_SKILL_INFO_1_1_220 			= UNIT_END + 0x29C , // Chars?
		PLAYER_SKILL_INFO_1_1_221 			= UNIT_END + 0x29D , // Chars?
		PLAYER_SKILL_INFO_1_1_222 			= UNIT_END + 0x29E , // Chars?
		PLAYER_SKILL_INFO_1_1_223 			= UNIT_END + 0x29F , // Chars?
		PLAYER_SKILL_INFO_1_1_224 			= UNIT_END + 0x2A0 , // Chars?
		PLAYER_SKILL_INFO_1_1_225 			= UNIT_END + 0x2A1 , // Chars?
		PLAYER_SKILL_INFO_1_1_226 			= UNIT_END + 0x2A2 , // Chars?
		PLAYER_SKILL_INFO_1_1_227 			= UNIT_END + 0x2A3 , // Chars?
		PLAYER_SKILL_INFO_1_1_228 			= UNIT_END + 0x2A4 , // Chars?
		PLAYER_SKILL_INFO_1_1_229 			= UNIT_END + 0x2A5 , // Chars?
		PLAYER_SKILL_INFO_1_1_230 			= UNIT_END + 0x2A6 , // Chars?
		PLAYER_SKILL_INFO_1_1_231 			= UNIT_END + 0x2A7 , // Chars?
		PLAYER_SKILL_INFO_1_1_232 			= UNIT_END + 0x2A8 , // Chars?
		PLAYER_SKILL_INFO_1_1_233 			= UNIT_END + 0x2A9 , // Chars?
		PLAYER_SKILL_INFO_1_1_234 			= UNIT_END + 0x2AA , // Chars?
		PLAYER_SKILL_INFO_1_1_235 			= UNIT_END + 0x2AB , // Chars?
		PLAYER_SKILL_INFO_1_1_236 			= UNIT_END + 0x2AC , // Chars?
		PLAYER_SKILL_INFO_1_1_237 			= UNIT_END + 0x2AD , // Chars?
		PLAYER_SKILL_INFO_1_1_238 			= UNIT_END + 0x2AE , // Chars?
		PLAYER_SKILL_INFO_1_1_239 			= UNIT_END + 0x2AF , // Chars?
		PLAYER_SKILL_INFO_1_1_240 			= UNIT_END + 0x2B0 , // Chars?
		PLAYER_SKILL_INFO_1_1_241 			= UNIT_END + 0x2B1 , // Chars?
		PLAYER_SKILL_INFO_1_1_242 			= UNIT_END + 0x2B2 , // Chars?
		PLAYER_SKILL_INFO_1_1_243 			= UNIT_END + 0x2B3 , // Chars?
		PLAYER_SKILL_INFO_1_1_244 			= UNIT_END + 0x2B4 , // Chars?
		PLAYER_SKILL_INFO_1_1_245 			= UNIT_END + 0x2B5 , // Chars?
		PLAYER_SKILL_INFO_1_1_246 			= UNIT_END + 0x2B6 , // Chars?
		PLAYER_SKILL_INFO_1_1_247 			= UNIT_END + 0x2B7 , // Chars?
		PLAYER_SKILL_INFO_1_1_248 			= UNIT_END + 0x2B8 , // Chars?
		PLAYER_SKILL_INFO_1_1_249 			= UNIT_END + 0x2B9 , // Chars?
		PLAYER_SKILL_INFO_1_1_250 			= UNIT_END + 0x2BA , // Chars?
		PLAYER_SKILL_INFO_1_1_251 			= UNIT_END + 0x2BB , // Chars?
		PLAYER_SKILL_INFO_1_1_252 			= UNIT_END + 0x2BC , // Chars?
		PLAYER_SKILL_INFO_1_1_253 			= UNIT_END + 0x2BD , // Chars?
		PLAYER_SKILL_INFO_1_1_254 			= UNIT_END + 0x2BE , // Chars?
		PLAYER_SKILL_INFO_1_1_255 			= UNIT_END + 0x2BF , // Chars?
		PLAYER_SKILL_INFO_1_1_256 			= UNIT_END + 0x2C0 , // Chars?
		PLAYER_SKILL_INFO_1_1_257 			= UNIT_END + 0x2C1 , // Chars?
		PLAYER_SKILL_INFO_1_1_258 			= UNIT_END + 0x2C2 , // Chars?
		PLAYER_SKILL_INFO_1_1_259 			= UNIT_END + 0x2C3 , // Chars?
		PLAYER_SKILL_INFO_1_1_260 			= UNIT_END + 0x2C4 , // Chars?
		PLAYER_SKILL_INFO_1_1_261 			= UNIT_END + 0x2C5 , // Chars?
		PLAYER_SKILL_INFO_1_1_262 			= UNIT_END + 0x2C6 , // Chars?
		PLAYER_SKILL_INFO_1_1_263 			= UNIT_END + 0x2C7 , // Chars?
		PLAYER_SKILL_INFO_1_1_264 			= UNIT_END + 0x2C8 , // Chars?
		PLAYER_SKILL_INFO_1_1_265 			= UNIT_END + 0x2C9 , // Chars?
		PLAYER_SKILL_INFO_1_1_266 			= UNIT_END + 0x2CA , // Chars?
		PLAYER_SKILL_INFO_1_1_267 			= UNIT_END + 0x2CB , // Chars?
		PLAYER_SKILL_INFO_1_1_268 			= UNIT_END + 0x2CC , // Chars?
		PLAYER_SKILL_INFO_1_1_269 			= UNIT_END + 0x2CD , // Chars?
		PLAYER_SKILL_INFO_1_1_270 			= UNIT_END + 0x2CE , // Chars?
		PLAYER_SKILL_INFO_1_1_271 			= UNIT_END + 0x2CF , // Chars?
		PLAYER_SKILL_INFO_1_1_272 			= UNIT_END + 0x2D0 , // Chars?
		PLAYER_SKILL_INFO_1_1_273 			= UNIT_END + 0x2D1 , // Chars?
		PLAYER_SKILL_INFO_1_1_274 			= UNIT_END + 0x2D2 , // Chars?
		PLAYER_SKILL_INFO_1_1_275 			= UNIT_END + 0x2D3 , // Chars?
		PLAYER_SKILL_INFO_1_1_276 			= UNIT_END + 0x2D4 , // Chars?
		PLAYER_SKILL_INFO_1_1_277 			= UNIT_END + 0x2D5 , // Chars?
		PLAYER_SKILL_INFO_1_1_278 			= UNIT_END + 0x2D6 , // Chars?
		PLAYER_SKILL_INFO_1_1_279 			= UNIT_END + 0x2D7 , // Chars?
		PLAYER_SKILL_INFO_1_1_280 			= UNIT_END + 0x2D8 , // Chars?
		PLAYER_SKILL_INFO_1_1_281 			= UNIT_END + 0x2D9 , // Chars?
		PLAYER_SKILL_INFO_1_1_282 			= UNIT_END + 0x2DA , // Chars?
		PLAYER_SKILL_INFO_1_1_283 			= UNIT_END + 0x2DB , // Chars?
		PLAYER_SKILL_INFO_1_1_284 			= UNIT_END + 0x2DC , // Chars?
		PLAYER_SKILL_INFO_1_1_285 			= UNIT_END + 0x2DD , // Chars?
		PLAYER_SKILL_INFO_1_1_286 			= UNIT_END + 0x2DE , // Chars?
		PLAYER_SKILL_INFO_1_1_287 			= UNIT_END + 0x2DF , // Chars?
		PLAYER_SKILL_INFO_1_1_288 			= UNIT_END + 0x2E0 , // Chars?
		PLAYER_SKILL_INFO_1_1_289 			= UNIT_END + 0x2E1 , // Chars?
		PLAYER_SKILL_INFO_1_1_290 			= UNIT_END + 0x2E2 , // Chars?
		PLAYER_SKILL_INFO_1_1_291 			= UNIT_END + 0x2E3 , // Chars?
		PLAYER_SKILL_INFO_1_1_292 			= UNIT_END + 0x2E4 , // Chars?
		PLAYER_SKILL_INFO_1_1_293 			= UNIT_END + 0x2E5 , // Chars?
		PLAYER_SKILL_INFO_1_1_294 			= UNIT_END + 0x2E6 , // Chars?
		PLAYER_SKILL_INFO_1_1_295 			= UNIT_END + 0x2E7 , // Chars?
		PLAYER_SKILL_INFO_1_1_296 			= UNIT_END + 0x2E8 , // Chars?
		PLAYER_SKILL_INFO_1_1_297 			= UNIT_END + 0x2E9 , // Chars?
		PLAYER_SKILL_INFO_1_1_298 			= UNIT_END + 0x2EA , // Chars?
		PLAYER_SKILL_INFO_1_1_299 			= UNIT_END + 0x2EB , // Chars?
		PLAYER_SKILL_INFO_1_1_300 			= UNIT_END + 0x2EC , // Chars?
		PLAYER_SKILL_INFO_1_1_301 			= UNIT_END + 0x2ED , // Chars?
		PLAYER_SKILL_INFO_1_1_302 			= UNIT_END + 0x2EE , // Chars?
		PLAYER_SKILL_INFO_1_1_303 			= UNIT_END + 0x2EF , // Chars?
		PLAYER_SKILL_INFO_1_1_304 			= UNIT_END + 0x2F0 , // Chars?
		PLAYER_SKILL_INFO_1_1_305 			= UNIT_END + 0x2F1 , // Chars?
		PLAYER_SKILL_INFO_1_1_306 			= UNIT_END + 0x2F2 , // Chars?
		PLAYER_SKILL_INFO_1_1_307 			= UNIT_END + 0x2F3 , // Chars?
		PLAYER_SKILL_INFO_1_1_308 			= UNIT_END + 0x2F4 , // Chars?
		PLAYER_SKILL_INFO_1_1_309 			= UNIT_END + 0x2F5 , // Chars?
		PLAYER_SKILL_INFO_1_1_310 			= UNIT_END + 0x2F6 , // Chars?
		PLAYER_SKILL_INFO_1_1_311 			= UNIT_END + 0x2F7 , // Chars?
		PLAYER_SKILL_INFO_1_1_312 			= UNIT_END + 0x2F8 , // Chars?
		PLAYER_SKILL_INFO_1_1_313 			= UNIT_END + 0x2F9 , // Chars?
		PLAYER_SKILL_INFO_1_1_314 			= UNIT_END + 0x2FA , // Chars?
		PLAYER_SKILL_INFO_1_1_315 			= UNIT_END + 0x2FB , // Chars?
		PLAYER_SKILL_INFO_1_1_316 			= UNIT_END + 0x2FC , // Chars?
		PLAYER_SKILL_INFO_1_1_317 			= UNIT_END + 0x2FD , // Chars?
		PLAYER_SKILL_INFO_1_1_318 			= UNIT_END + 0x2FE , // Chars?
		PLAYER_SKILL_INFO_1_1_319 			= UNIT_END + 0x2FF , // Chars?
		PLAYER_SKILL_INFO_1_1_320 			= UNIT_END + 0x300 , // Chars?
		PLAYER_SKILL_INFO_1_1_321 			= UNIT_END + 0x301 , // Chars?
		PLAYER_SKILL_INFO_1_1_322 			= UNIT_END + 0x302 , // Chars?
		PLAYER_SKILL_INFO_1_1_323 			= UNIT_END + 0x303 , // Chars?
		PLAYER_SKILL_INFO_1_1_324 			= UNIT_END + 0x304 , // Chars?
		PLAYER_SKILL_INFO_1_1_325 			= UNIT_END + 0x305 , // Chars?
		PLAYER_SKILL_INFO_1_1_326 			= UNIT_END + 0x306 , // Chars?
		PLAYER_SKILL_INFO_1_1_327 			= UNIT_END + 0x307 , // Chars?
		PLAYER_SKILL_INFO_1_1_328 			= UNIT_END + 0x308 , // Chars?
		PLAYER_SKILL_INFO_1_1_329 			= UNIT_END + 0x309 , // Chars?
		PLAYER_SKILL_INFO_1_1_330 			= UNIT_END + 0x30A , // Chars?
		PLAYER_SKILL_INFO_1_1_331 			= UNIT_END + 0x30B , // Chars?
		PLAYER_SKILL_INFO_1_1_332 			= UNIT_END + 0x30C , // Chars?
		PLAYER_SKILL_INFO_1_1_333 			= UNIT_END + 0x30D , // Chars?
		PLAYER_SKILL_INFO_1_1_334 			= UNIT_END + 0x30E , // Chars?
		PLAYER_SKILL_INFO_1_1_335 			= UNIT_END + 0x30F , // Chars?
		PLAYER_SKILL_INFO_1_1_336 			= UNIT_END + 0x310 , // Chars?
		PLAYER_SKILL_INFO_1_1_337 			= UNIT_END + 0x311 , // Chars?
		PLAYER_SKILL_INFO_1_1_338 			= UNIT_END + 0x312 , // Chars?
		PLAYER_SKILL_INFO_1_1_339 			= UNIT_END + 0x313 , // Chars?
		PLAYER_SKILL_INFO_1_1_340 			= UNIT_END + 0x314 , // Chars?
		PLAYER_SKILL_INFO_1_1_341 			= UNIT_END + 0x315 , // Chars?
		PLAYER_SKILL_INFO_1_1_342 			= UNIT_END + 0x316 , // Chars?
		PLAYER_SKILL_INFO_1_1_343 			= UNIT_END + 0x317 , // Chars?
		PLAYER_SKILL_INFO_1_1_344 			= UNIT_END + 0x318 , // Chars?
		PLAYER_SKILL_INFO_1_1_345 			= UNIT_END + 0x319 , // Chars?
		PLAYER_SKILL_INFO_1_1_346 			= UNIT_END + 0x31A , // Chars?
		PLAYER_SKILL_INFO_1_1_347 			= UNIT_END + 0x31B , // Chars?
		PLAYER_SKILL_INFO_1_1_348 			= UNIT_END + 0x31C , // Chars?
		PLAYER_SKILL_INFO_1_1_349 			= UNIT_END + 0x31D , // Chars?
		PLAYER_SKILL_INFO_1_1_350 			= UNIT_END + 0x31E , // Chars?
		PLAYER_SKILL_INFO_1_1_351 			= UNIT_END + 0x31F , // Chars?
		PLAYER_SKILL_INFO_1_1_352 			= UNIT_END + 0x320 , // Chars?
		PLAYER_SKILL_INFO_1_1_353 			= UNIT_END + 0x321 , // Chars?
		PLAYER_SKILL_INFO_1_1_354 			= UNIT_END + 0x322 , // Chars?
		PLAYER_SKILL_INFO_1_1_355 			= UNIT_END + 0x323 , // Chars?
		PLAYER_SKILL_INFO_1_1_356 			= UNIT_END + 0x324 , // Chars?
		PLAYER_SKILL_INFO_1_1_357 			= UNIT_END + 0x325 , // Chars?
		PLAYER_SKILL_INFO_1_1_358 			= UNIT_END + 0x326 , // Chars?
		PLAYER_SKILL_INFO_1_1_359 			= UNIT_END + 0x327 , // Chars?
		PLAYER_SKILL_INFO_1_1_360 			= UNIT_END + 0x328 , // Chars?
		PLAYER_SKILL_INFO_1_1_361 			= UNIT_END + 0x329 , // Chars?
		PLAYER_SKILL_INFO_1_1_362 			= UNIT_END + 0x32A , // Chars?
		PLAYER_SKILL_INFO_1_1_363 			= UNIT_END + 0x32B , // Chars?
		PLAYER_SKILL_INFO_1_1_364 			= UNIT_END + 0x32C , // Chars?
		PLAYER_SKILL_INFO_1_1_365 			= UNIT_END + 0x32D , // Chars?
		PLAYER_SKILL_INFO_1_1_366 			= UNIT_END + 0x32E , // Chars?
		PLAYER_SKILL_INFO_1_1_367 			= UNIT_END + 0x32F , // Chars?
		PLAYER_SKILL_INFO_1_1_368 			= UNIT_END + 0x330 , // Chars?
		PLAYER_SKILL_INFO_1_1_369 			= UNIT_END + 0x331 , // Chars?
		PLAYER_SKILL_INFO_1_1_370 			= UNIT_END + 0x332 , // Chars?
		PLAYER_SKILL_INFO_1_1_371 			= UNIT_END + 0x333 , // Chars?
		PLAYER_SKILL_INFO_1_1_372 			= UNIT_END + 0x334 , // Chars?
		PLAYER_SKILL_INFO_1_1_373 			= UNIT_END + 0x335 , // Chars?
		PLAYER_SKILL_INFO_1_1_374 			= UNIT_END + 0x336 , // Chars?
		PLAYER_SKILL_INFO_1_1_375 			= UNIT_END + 0x337 , // Chars?
		PLAYER_SKILL_INFO_1_1_376 			= UNIT_END + 0x338 , // Chars?
		PLAYER_SKILL_INFO_1_1_377 			= UNIT_END + 0x339 , // Chars?
		PLAYER_SKILL_INFO_1_1_378 			= UNIT_END + 0x33A , // Chars?
		PLAYER_SKILL_INFO_1_1_379 			= UNIT_END + 0x33B , // Chars?
		PLAYER_SKILL_INFO_1_1_380 			= UNIT_END + 0x33C , // Chars?
		PLAYER_SKILL_INFO_1_1_381 			= UNIT_END + 0x33D , // Chars?
		PLAYER_SKILL_INFO_1_1_382 			= UNIT_END + 0x33E , // Chars?
		PLAYER_SKILL_INFO_1_1_383 			= UNIT_END + 0x33F , // Chars?
		PLAYER_CHARACTER_POINTS1            = UNIT_END + 0x340 , // Int32
		PLAYER_CHARACTER_POINTS2            = UNIT_END + 0x341 , // Int32
		PLAYER_TRACK_CREATURES              = UNIT_END + 0x342 , // Int32
		PLAYER_TRACK_RESOURCES              = UNIT_END + 0x343 , // Int32
		PLAYER_BLOCK_PERCENTAGE             = UNIT_END + 0x344 , // Float
		PLAYER_DODGE_PERCENTAGE             = UNIT_END + 0x345 , // Float
		PLAYER_PARRY_PERCENTAGE             = UNIT_END + 0x346 , // Float
		PLAYER_CRIT_PERCENTAGE              = UNIT_END + 0x347 , // Float
		PLAYER_RANGED_CRIT_PERCENTAGE       = UNIT_END + 0x348 , // Float
		PLAYER_EXPLORED_ZONES_1    			= UNIT_END + 0x349 , // Bytes
		PLAYER_EXPLORED_ZONES_1_01 			= UNIT_END + 0x34A , // Bytes
		PLAYER_EXPLORED_ZONES_1_02 			= UNIT_END + 0x34B , // Bytes
		PLAYER_EXPLORED_ZONES_1_03 			= UNIT_END + 0x34C , // Bytes
		PLAYER_EXPLORED_ZONES_1_04 			= UNIT_END + 0x34D , // Bytes
		PLAYER_EXPLORED_ZONES_1_05 			= UNIT_END + 0x34E , // Bytes
		PLAYER_EXPLORED_ZONES_1_06 			= UNIT_END + 0x34F , // Bytes
		PLAYER_EXPLORED_ZONES_1_07 			= UNIT_END + 0x350 , // Bytes
		PLAYER_EXPLORED_ZONES_1_08 			= UNIT_END + 0x351 , // Bytes
		PLAYER_EXPLORED_ZONES_1_09 			= UNIT_END + 0x352 , // Bytes
		PLAYER_EXPLORED_ZONES_1_10 			= UNIT_END + 0x353 , // Bytes
		PLAYER_EXPLORED_ZONES_1_11 			= UNIT_END + 0x354 , // Bytes
		PLAYER_EXPLORED_ZONES_1_12 			= UNIT_END + 0x355 , // Bytes
		PLAYER_EXPLORED_ZONES_1_13 			= UNIT_END + 0x356 , // Bytes
		PLAYER_EXPLORED_ZONES_1_14 			= UNIT_END + 0x357 , // Bytes
		PLAYER_EXPLORED_ZONES_1_15 			= UNIT_END + 0x358 , // Bytes
		PLAYER_EXPLORED_ZONES_1_16 			= UNIT_END + 0x359 , // Bytes
		PLAYER_EXPLORED_ZONES_1_17 			= UNIT_END + 0x35A , // Bytes
		PLAYER_EXPLORED_ZONES_1_18 			= UNIT_END + 0x35B , // Bytes
		PLAYER_EXPLORED_ZONES_1_19 			= UNIT_END + 0x35C , // Bytes
		PLAYER_EXPLORED_ZONES_1_20 			= UNIT_END + 0x35D , // Bytes
		PLAYER_EXPLORED_ZONES_1_21 			= UNIT_END + 0x35E , // Bytes
		PLAYER_EXPLORED_ZONES_1_22 			= UNIT_END + 0x35F , // Bytes
		PLAYER_EXPLORED_ZONES_1_23 			= UNIT_END + 0x360 , // Bytes
		PLAYER_EXPLORED_ZONES_1_24 			= UNIT_END + 0x361 , // Bytes
		PLAYER_EXPLORED_ZONES_1_25 			= UNIT_END + 0x362 , // Bytes
		PLAYER_EXPLORED_ZONES_1_26 			= UNIT_END + 0x363 , // Bytes
		PLAYER_EXPLORED_ZONES_1_27 			= UNIT_END + 0x364 , // Bytes
		PLAYER_EXPLORED_ZONES_1_28 			= UNIT_END + 0x365 , // Bytes
		PLAYER_EXPLORED_ZONES_1_29 			= UNIT_END + 0x366 , // Bytes
		PLAYER_EXPLORED_ZONES_1_30 			= UNIT_END + 0x367 , // Bytes
		PLAYER_EXPLORED_ZONES_1_31 			= UNIT_END + 0x368 , // Bytes
		PLAYER_EXPLORED_ZONES_1_32 			= UNIT_END + 0x369 , // Bytes
		PLAYER_EXPLORED_ZONES_1_33 			= UNIT_END + 0x36A , // Bytes
		PLAYER_EXPLORED_ZONES_1_34 			= UNIT_END + 0x36B , // Bytes
		PLAYER_EXPLORED_ZONES_1_35 			= UNIT_END + 0x36C , // Bytes
		PLAYER_EXPLORED_ZONES_1_36 			= UNIT_END + 0x36D , // Bytes
		PLAYER_EXPLORED_ZONES_1_37 			= UNIT_END + 0x36E , // Bytes
		PLAYER_EXPLORED_ZONES_1_38 			= UNIT_END + 0x36F , // Bytes
		PLAYER_EXPLORED_ZONES_1_39 			= UNIT_END + 0x370 , // Bytes
		PLAYER_EXPLORED_ZONES_1_40 			= UNIT_END + 0x371 , // Bytes
		PLAYER_EXPLORED_ZONES_1_41 			= UNIT_END + 0x372 , // Bytes
		PLAYER_EXPLORED_ZONES_1_42 			= UNIT_END + 0x373 , // Bytes
		PLAYER_EXPLORED_ZONES_1_43 			= UNIT_END + 0x374 , // Bytes
		PLAYER_EXPLORED_ZONES_1_44 			= UNIT_END + 0x375 , // Bytes
		PLAYER_EXPLORED_ZONES_1_45 			= UNIT_END + 0x376 , // Bytes
		PLAYER_EXPLORED_ZONES_1_46 			= UNIT_END + 0x377 , // Bytes
		PLAYER_EXPLORED_ZONES_1_47 			= UNIT_END + 0x378 , // Bytes
		PLAYER_EXPLORED_ZONES_1_48 			= UNIT_END + 0x379 , // Bytes
		PLAYER_EXPLORED_ZONES_1_49 			= UNIT_END + 0x37A , // Bytes
		PLAYER_EXPLORED_ZONES_1_50 			= UNIT_END + 0x37B , // Bytes
		PLAYER_EXPLORED_ZONES_1_51 			= UNIT_END + 0x37C , // Bytes
		PLAYER_EXPLORED_ZONES_1_52 			= UNIT_END + 0x37D , // Bytes
		PLAYER_EXPLORED_ZONES_1_53 			= UNIT_END + 0x37E , // Bytes
		PLAYER_EXPLORED_ZONES_1_54 			= UNIT_END + 0x37F , // Bytes
		PLAYER_EXPLORED_ZONES_1_55 			= UNIT_END + 0x380 , // Bytes
		PLAYER_EXPLORED_ZONES_1_56 			= UNIT_END + 0x381 , // Bytes
		PLAYER_EXPLORED_ZONES_1_57 			= UNIT_END + 0x382 , // Bytes
		PLAYER_EXPLORED_ZONES_1_58 			= UNIT_END + 0x383 , // Bytes
		PLAYER_EXPLORED_ZONES_1_59 			= UNIT_END + 0x384 , // Bytes
		PLAYER_EXPLORED_ZONES_1_60 			= UNIT_END + 0x385 , // Bytes
		PLAYER_EXPLORED_ZONES_1_61 			= UNIT_END + 0x386 , // Bytes
		PLAYER_EXPLORED_ZONES_1_62 			= UNIT_END + 0x387 , // Bytes
		PLAYER_EXPLORED_ZONES_1_63 			= UNIT_END + 0x388 , // Bytes
		PLAYER_REST_STATE_EXPERIENCE        = UNIT_END + 0x389 , // Int32
		PLAYER_FIELD_COINAGE               = UNIT_END +  0x38A , // Int32
		PLAYER_FIELD_POSSTAT0               = UNIT_END + 0x38B , // Int32
		PLAYER_FIELD_POSSTAT1               = UNIT_END + 0x38C , // Int32
		PLAYER_FIELD_POSSTAT2               = UNIT_END + 0x38D , // Int32
		PLAYER_FIELD_POSSTAT3               = UNIT_END + 0x38E , // Int32
		PLAYER_FIELD_POSSTAT4               = UNIT_END + 0x38F , // Int32
		PLAYER_FIELD_NEGSTAT0               = UNIT_END + 0x390 , // Int32
		PLAYER_FIELD_NEGSTAT1               = UNIT_END + 0x391 , // Int32
		PLAYER_FIELD_NEGSTAT2               = UNIT_END + 0x392 , // Int32
		PLAYER_FIELD_NEGSTAT3               = UNIT_END + 0x393 , // Int32
		PLAYER_FIELD_NEGSTAT4               = UNIT_END + 0x394 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE    			= UNIT_END + 0x395 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_01 			= UNIT_END + 0x396 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_02 			= UNIT_END + 0x397 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_03 			= UNIT_END + 0x398 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_04 			= UNIT_END + 0x399 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_05 			= UNIT_END + 0x39A , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE_06 			= UNIT_END + 0x39B , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE    			= UNIT_END + 0x39C , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_01 			= UNIT_END + 0x39D , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_02 			= UNIT_END + 0x39E , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_03 			= UNIT_END + 0x39F , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_04 			= UNIT_END + 0x3A0 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_05 			= UNIT_END + 0x3A1 , // Int32
		PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE_06 			= UNIT_END + 0x3A2 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS    			= UNIT_END + 0x3A3 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_01 			= UNIT_END + 0x3A4 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_02 			= UNIT_END + 0x3A5 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_03 			= UNIT_END + 0x3A6 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_04 			= UNIT_END + 0x3A7 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_05 			= UNIT_END + 0x3A8 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_POS_06 			= UNIT_END + 0x3A9 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG    			= UNIT_END + 0x3AA , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_01 			= UNIT_END + 0x3AB , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_02 			= UNIT_END + 0x3AC , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_03 			= UNIT_END + 0x3AD , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_04 			= UNIT_END + 0x3AE , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_05 			= UNIT_END + 0x3AF , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_NEG_06 			= UNIT_END + 0x3B0 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT    			= UNIT_END + 0x3B1 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_01 			= UNIT_END + 0x3B2 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_02 			= UNIT_END + 0x3B3 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_03 			= UNIT_END + 0x3B4 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_04 			= UNIT_END + 0x3B5 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_05 			= UNIT_END + 0x3B6 , // Int32
		PLAYER_FIELD_MOD_DAMAGE_DONE_PCT_06 			= UNIT_END + 0x3B7 , // Int32
		PLAYER_FIELD_BYTES                  = UNIT_END + 0x3B8 , // Bytes
		PLAYER_AMMO_ID                      = UNIT_END + 0x3B9 , // Int32
		PLAYER_SELF_RES_SPELL               = UNIT_END + 0x3BA , // Int32
		PLAYER_FIELD_PVP_MEDALS             = UNIT_END + 0x3BB , // Int32
		PLAYER_FIELD_BUYBACK_ITEM_ID        = UNIT_END + 0x3BC , // Int32
		PLAYER_FIELD_BUYBACK_RANDOM_PROPERTIES_ID = UNIT_END + 0x3BD , // Int32
		PLAYER_FIELD_BUYBACK_SEED           = UNIT_END + 0x3BE , // Int32
		PLAYER_FIELD_BUYBACK_PRICE          = UNIT_END + 0x3BF , // Int32
		PLAYER_FIELD_BUYBACK_DURABILITY     = UNIT_END + 0x3C0 , // Int32
		PLAYER_FIELD_BUYBACK_COUNT          = UNIT_END + 0x3C1 , // Int32
		PLAYER_FIELD_SESSION_KILLS          = UNIT_END + 0x3C2 , // Chars?
		PLAYER_FIELD_YESTERDAY_KILLS        = UNIT_END + 0x3C3 , // Chars?
		PLAYER_FIELD_LAST_WEEK_KILLS        = UNIT_END + 0x3C4 , // Chars?
		PLAYER_FIELD_THIS_WEEK_KILLS        = UNIT_END + 0x3C5 , // Chars?
		PLAYER_FIELD_THIS_WEEK_CONTRIBUTION = UNIT_END + 0x3C6 , // Int32
		PLAYER_FIELD_LIFETIME_HONORBALE_KILLS = UNIT_END + 0x3C7 , // Int32
		PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS = UNIT_END + 0x3C8 , // Int32
		PLAYER_FIELD_YESTERDAY_CONTRIBUTION = UNIT_END + 0x3C9 , // Int32
		PLAYER_FIELD_LAST_WEEK_CONTRIBUTION = UNIT_END + 0x3CA , // Int32
		PLAYER_FIELD_LAST_WEEK_RANK         = UNIT_END + 0x3CB , // Int32
		PLAYER_FIELD_BYTES2                 = UNIT_END + 0x3CC , // Bytes
		PLAYER_FIELD_PADDING                = UNIT_END + 0x3CD , // Int32
		PLAYER_END									        = UNIT_END + 0x3CE,


		OBJECT_FIELD_CREATED_BY    	=		OBJECT_END + 0x000 , // GUID
		OBJECT_FIELD_CREATED_BY_01 		=	OBJECT_END + 0x001 , // GUID


		GAMEOBJECT_DISPLAYID      =          OBJECT_END + 0x002 , // Int32
		GAMEOBJECT_FLAGS          =          OBJECT_END + 0x003 , // Int32
		GAMEOBJECT_ROTATION    =			OBJECT_END + 0x004 , // Float
		GAMEOBJECT_ROTATION_01 =			OBJECT_END + 0x005 , // Float
		GAMEOBJECT_ROTATION_02 	=		OBJECT_END + 0x006 , // Float
		GAMEOBJECT_ROTATION_03 		=	OBJECT_END + 0x007 , // Float
		GAMEOBJECT_STATE            =        OBJECT_END + 0x008 , // Int32
		GAMEOBJECT_TIMESTAMP        =        OBJECT_END + 0x009 , // Int32
		GAMEOBJECT_POS_X            =        OBJECT_END + 0x00A , // Float
		GAMEOBJECT_POS_Y            =        OBJECT_END + 0x00B , // Float
		GAMEOBJECT_POS_Z            =        OBJECT_END + 0x00C , // Float
		GAMEOBJECT_FACING           =        OBJECT_END + 0x00D , // Float
		GAMEOBJECT_DYN_FLAGS        =        OBJECT_END + 0x00E , // Int32
		GAMEOBJECT_FACTION          =        OBJECT_END + 0x00F , // Int32
		GAMEOBJECT_TYPE_ID          =        OBJECT_END + 0x010 , // Int32
		GAMEOBJECT_LEVEL            =        OBJECT_END + 0x011 , // Int32
		GAMEOBJECT_END				=		          OBJECT_END + 0x012,


		DYNAMICOBJECT_CASTER    =			OBJECT_END + 0x000 , // GUID
		DYNAMICOBJECT_CASTER_01 	=		OBJECT_END + 0x001 , // GUID
		DYNAMICOBJECT_BYTES             =    OBJECT_END + 0x002 , // Bytes
		DYNAMICOBJECT_SPELLID           =    OBJECT_END + 0x003 , // Int32
		DYNAMICOBJECT_RADIUS            =    OBJECT_END + 0x004 , // Float
		DYNAMICOBJECT_POS_X             =    OBJECT_END + 0x005 , // Float
		DYNAMICOBJECT_POS_Y             =    OBJECT_END + 0x006 , // Float
		DYNAMICOBJECT_POS_Z             =    OBJECT_END + 0x007 , // Float
		DYNAMICOBJECT_FACING            =    OBJECT_END + 0x008 , // Float
		DYNAMICOBJECT_PAD               =    OBJECT_END + 0x009 , // Bytes
		DYNAMICOBJECT_END				=	          OBJECT_END + 0x00A,


		
		CORPSE_FIELD_OWNER    =			OBJECT_END + 0x000 , // GUID
		CORPSE_FIELD_OWNER_01 	=		OBJECT_END + 0x001 , // GUID
		CORPSE_FIELD_FACING              =   OBJECT_END + 0x002 , // Float
		CORPSE_FIELD_POS_X               =   OBJECT_END + 0x003 , // Float
		CORPSE_FIELD_POS_Y             =     OBJECT_END + 0x004 , // Float
		CORPSE_FIELD_POS_Z           =       OBJECT_END + 0x005 , // Float
		CORPSE_FIELD_DISPLAY_ID     =        OBJECT_END + 0x006 , // Int32
		CORPSE_FIELD_ITEM    	=		OBJECT_END + 0x007 , // Int32
		CORPSE_FIELD_ITEM_01 =			OBJECT_END + 0x008 , // Int32
		CORPSE_FIELD_ITEM_02 	=		OBJECT_END + 0x009 , // Int32
		CORPSE_FIELD_ITEM_03 		=	OBJECT_END + 0x00A , // Int32
		CORPSE_FIELD_ITEM_04 		=	OBJECT_END + 0x00B , // Int32
		CORPSE_FIELD_ITEM_05 	=		OBJECT_END + 0x00C , // Int32
		CORPSE_FIELD_ITEM_06 =			OBJECT_END + 0x00D , // Int32
		CORPSE_FIELD_ITEM_07 	=		OBJECT_END + 0x00E , // Int32
		CORPSE_FIELD_ITEM_08 		=	OBJECT_END + 0x00F , // Int32
		CORPSE_FIELD_ITEM_09 		=	OBJECT_END + 0x010 , // Int32
		CORPSE_FIELD_ITEM_10 	=		OBJECT_END + 0x011 , // Int32
		CORPSE_FIELD_ITEM_11 =			OBJECT_END + 0x012 , // Int32
		CORPSE_FIELD_ITEM_12 	=		OBJECT_END + 0x013 , // Int32
		CORPSE_FIELD_ITEM_13 		=	OBJECT_END + 0x014 , // Int32
		CORPSE_FIELD_ITEM_14 	=		OBJECT_END + 0x015 , // Int32
		CORPSE_FIELD_ITEM_15 =			OBJECT_END + 0x016 , // Int32
		CORPSE_FIELD_ITEM_16= 			OBJECT_END + 0x017 , // Int32
		CORPSE_FIELD_ITEM_17 =			OBJECT_END + 0x018 , // Int32
		CORPSE_FIELD_ITEM_18 	=		OBJECT_END + 0x019 , // Int32
		CORPSE_FIELD_BYTES_1            =    OBJECT_END + 0x01A , // Bytes
		CORPSE_FIELD_BYTES_2            =    OBJECT_END + 0x01B , // Bytes
		CORPSE_FIELD_GUILD              =    OBJECT_END + 0x01C , // Int32
		CORPSE_FIELD_FLAGS              =    OBJECT_END + 0x01D , // Int32
		CORPSE_FIELD_DYNAMIC_FLAGS      =    OBJECT_END + 0x01E , // Int32
		CORPSE_FIELD_PAD                =    OBJECT_END + 0x01F , // Int32
		CORPSE_END					    =   OBJECT_END + 0x020














	};

}
