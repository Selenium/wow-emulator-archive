using System;
using System.Collections;
using HelperTools;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for GameObject.
	/// </summary>
	public class GameObject : Object
	{
		int id;
		BaseTreasure[] loots;
		int charge;		
		int defaultModel;
	/*	float rotationX;
		float rotationY;
		float rotationZ;
		float facing;*/

		#region CONSTRUCTOR
		public GameObject() : base( Server.Object.GUID++ )
		{
			this.Guid += 0xA000000000000000;
			charge = Utility.Random4() + 1;
		}
		public GameObject( GenericReader gr )
		{
			Deserialize( gr );
			charge = Utility.Random4() + 1;
		}

		public GameObject( int gameObjectId, float X, float Y, float Z, ushort MapId ) : base( Server.Object.GUID++ , X, Y, Z, 0f, MapId )
		{
			id = gameObjectId;
			this.Guid += 0xA000000000000000;
			charge = Utility.Random4() + 1;
		}
		#endregion

		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			id = (int)gr.ReadInt();
			if ( version > 0 )
			{
				charge = (int)gr.ReadInt();
				int rp = gr.ReadInt();
				if ( rp == 1 )
				{
					UInt64 g = gr.ReadInt64();
					SpawnerLink = null;//(BaseSpawner)MobileList.TempSpawner[ g ];
				}
			}
			
		}
		public override void Serialize( GenericWriter gw )
		{
		//	gw.Write( Utility.ClassName( this ) );
			base.Serialize( gw );
			gw.Write( (int)1 );
			gw.Write( id );
			gw.Write( charge );
			if ( SpawnerLink != null )
			{
				gw.Write( 1 );
				gw.Write( SpawnerLink.Guid );
			}
			else
				gw.Write( 0 );
			
		}
		#endregion

		#region ACCESSORS
		public float RotationX
		{
			get 
			{
				if ( SpawnerLink is GameObjectSpawner )
					return ( SpawnerLink as GameObjectSpawner ).RotationX;
				return 0f;
			}
		}
		public float RotationY
		{
			get { 
				if ( SpawnerLink is GameObjectSpawner )
					return ( SpawnerLink as GameObjectSpawner ).RotationY;
				return 0f;
			}
		}
		public float RotationZ
		{
			get { 
				if ( SpawnerLink is GameObjectSpawner )
					return ( SpawnerLink as GameObjectSpawner ).RotationZ; 
				return 0f;
			}
		}
		public float Facing
		{
			get { 
				if ( SpawnerLink is GameObjectSpawner )
					return ( SpawnerLink as GameObjectSpawner ).Facing; 
				return 0;
			}
		}
		public int DefaultModel
		{
			get { return defaultModel; }
			set { defaultModel = value; }
		}

		public int Charge
		{
			get { return charge; }
			set { charge = value; }
		}
		public BaseTreasure[] Loots
		{
			get { return loots; }
			set { loots = value; }
		}
		public int Model
		{
			get { return ( GameObjectDescription.all[ id ] as GameObjectDescription ).Model; }
		}
		public int ObjectType
		{
			get { return ( GameObjectDescription.all[ id ] as GameObjectDescription ).ObjectType; }
		}
		public uint[] Sound
		{
			get { return ( GameObjectDescription.all[ id ] as GameObjectDescription ).Sound; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public string Name
		{
			get{ return ( GameObjectDescription.all[ id ] as GameObjectDescription ).Name; }
		}
		public float Size
		{
			get
			{
				try
				{
					return ( GameObjectDescription.all[ id ] as GameObjectDescription ).Size; 

				}
				catch( Exception)// e )
				{
					return 0f;
				}
			}
		}
		public int Flags
		{
			get{ return ( GameObjectDescription.all[ id ] as GameObjectDescription ).Flags; }
		}

		#endregion

		#region UPDATE
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			PrepareUpdateData( data, ref offset, type, forOther, null );
		}
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther, Character f )
		{
			if ( GameObjectDescription.all[ id ] == null )
			{
				Console.WriteLine("Gameobject id = {0} undifined !" , id );
				return;
			}
			int start = offset;
			data[ offset++ ] = (byte)UpdateType.UpdateFull;			
			Converter.ToBytes( Guid, data, ref offset );

			Converter.ToBytes( (byte)5, data, ref offset );//	type A9 = 5
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			Converter.ToBytes( (float)0f, data, ref offset );
			Converter.ToBytes( (float)2.5f, data, ref offset );
			Converter.ToBytes( (float)7.0f, data, ref offset );
			Converter.ToBytes( (float)2.5f, data, ref offset );
			Converter.ToBytes( (float)4.7222f, data, ref offset );
			Converter.ToBytes( (float)4.5f, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );
			Converter.ToBytes( (uint)1, data, ref offset );

			
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			ResetBitmap();
			setUpdateValue( 0, Guid );
			setUpdateValue( 2, 0x21 );
			setUpdateValue( (int)UpdateFields.OBJECT_FIELD_ENTRY, (uint)id );			
			setUpdateValue( (int)UpdateFields.OBJECT_FIELD_SCALE_X, (float)Size );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_DISPLAYID, (int)Model );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_FLAGS, Flags );			
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_ROTATION, RotationX );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_ROTATION + 1, RotationY );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_ROTATION + 2, RotationZ);
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_ROTATION + 3, Facing );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_STATE, (int)1 );//	2 = destroy
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_POS_X, X );
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_POS_Y, Y);
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_POS_Z, Z );
			//setUpdateValue( (int)UpdateFields.GAMEOBJECT_FACING, RotationZ );	
			setUpdateValue( (int)UpdateFields.GAMEOBJECT_TYPE_ID, ( GameObjectDescription.all[ id ] as GameObjectDescription ).Type );	
			
			FlushUpdateData( data, ref offset, 1 );
			return;
		}

		#endregion

		#region LOOTS
 
		public void ForceLoot( Character c )
		{
			int offset = 4;
			Converter.ToBytes( c.Guid, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			c.Send( OpCodes.CMSG_LOOT, tempBuff, offset );
		}

		public bool CheckLoot( Character c, float reussite )
		{
			GameObjectDescription god = (GameObjectDescription)GameObjectDescription.all[ id ];
			if ( god == null )
				return false;

			ArrayList loot = new ArrayList();
			c.LootOwner = Guid;
			if ( god.Loots != null )
			{/*
				foreach( Loot l in god.Loots )
				{
					if ( Utility.RandomDouble() * 100 < l.Probability )
					{					
						int n = (int)( reussite * l.Probability );
						if ( n < 1 )
							n = 1;
						if ( n > 10 )
							n = 6;
						loot.Add( l.Create( n ) );
					}
				}*/
				int lootMoney = 0;
				foreach( BaseTreasure l in god.Loots )
				{
					if ( l.IsDrop() )
					{
						ArrayList ret = l.RandomDrop( ref lootMoney );
						if ( ret != null )
							loot.AddRange( ret );
					}
				}
				Treasure = (Item[])loot.ToArray( typeof( Item ) );
				
				c.SendLootDetails( Guid, this, lootMoney  );
			}
			else
				return false;
			return true;
		}

		public virtual bool OnRelease( Mobile from )
		{
			int offset = 4;
			Converter.ToBytes( Guid, from.tempBuff, ref offset );
			from.ToAllPlayerNear( OpCodes.SMSG_GAMEOBJECT_DESPAWN_ANIM, tempBuff, offset );
			from.ToAllPlayerNear( OpCodes.SMSG_DESTROY_OBJECT, tempBuff, offset );
			return true;
		}
		#endregion

		#region HANDLERS
		public override bool SeenBy( Character c )
		{				
			if ( MapId != c.MapId || Distance( c ) > 300 * 300 )
				return false;

			return true;
		}
		public static void OnUseHandler( BaseAbility ba, Mobile c, GameObject go )
		{
			go.OnUse( c );
		}
		public virtual bool OnUse( Mobile from )
		{
			GameObjectDescription god = (GameObjectDescription)GameObjectDescription.all[ id ];
			if ( god.Loots != null )
			{
				if ( !( from is Character ) )
					return false;
				int lootMoney = 0;
				( from as Character ).LootOwner = Guid;
				ArrayList loot = new ArrayList();
				foreach( BaseTreasure l in god.Loots )
				{
					if ( l.IsDrop() )
						loot.AddRange( l.RandomDrop( ref lootMoney ) );
				}
				Treasure = (Item[])loot.ToArray( typeof( Item ) );
				( from as Character ).SendLootDetails( Guid, this, lootMoney  );
			}
			return true;
		}
		#endregion
	}
}
/* des loots
 
3E 36 21 00 00 00 00 A0 
01 02 00 00 00 03 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
01 D2 0A 00 00 09 00 00 00 49 12 00 00 00 00 00 00 00 00 00 00 00 
02 D3 0A 00 00 09 00 00 00 52 12 00 00 00 00 00 00 00 00 00 00 00 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
00 00 00 00 


/////
 97 1E 21 00 00 00 00 00 
01 05 00 00 00 02 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
01 5C 0A 00 00 01 00 00 00 3C 3B 00 00 00 00 00 00 00 00 00 00 00 

////////// Smallest
43 01 00 00 00 00 00 00 
01 03 00 00 
00 00 
///////////////

1C 32 21 00 00 00 00 00 
01 02 00 00 00 02 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
01 A2 1B 00 00 01 00 00 00 88 1B 00 00 00 00 00 00 00 00 00 00 00 

///////////////

12 36 21 00 00 00 00 00 
01 05 00 00 00 02 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
01 54 05 00 00 01 00 00 00 03 38 00 00 00 00 00 00 00 00 00 00 00 


///////////
13 36 21 00 00 00 00 00 
01 02 00 00 00 03 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
02 01 13 00 00 01 00 00 00 AE 1B 00 00 00 00 00 00 00 00 00 00 00 
01 56 05 00 00 01 00 00 00 02 38 00 00 00 00 00 00 00 00 00 00 00 

/////////
2B 37 21 00 00 00 00 00 
02 00 00 00 00 01 
00 D2 16 00 00 01 00 00 00 BB 46 00 00 00 00 00 00 00 00 00 00 00 



13 36 21 00 00 00 00 00 
01 
02 00 00 00 

03 
00 00 00 00
00 00 00 00 
00 00 00 00 
00 00 00 00 
00 00 00 00 
00  
00 

02 
01 13 00 00 
01 00 00 00 
AE 1B 00 00 
00 00 00 00 
00 00 00 00 
00 

01 
56 05 00 00 
01 00 00 00 
02 38 00 00 
00 00 00 00 
00 00 00 00 
00 
 


*/