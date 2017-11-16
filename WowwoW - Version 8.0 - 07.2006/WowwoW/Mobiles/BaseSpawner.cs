using System;
using System.Collections;
using System.Reflection;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for BaseSpawner.
	/// </summary>
	public class BaseSpawner : Object
	{		
		protected ConstructorInfo ci;		
		int frequency;
		//int currentAmount;
		int id;
		int model;
		ArrayList objects = new ArrayList();
		
		protected SpawnerTimer spawnerTimer;
		protected DateTime lastTime = DateTime.Now.Subtract( new TimeSpan( 1000000000 ) );
		DateTime lastSpawn = DateTime.Now.Subtract( new TimeSpan( 1000000000 ) );

		public BaseSpawner() : base( 0xF100000000000000 + Server.Object.GUID++ )
		{
			lastSpawn = DateTime.Now.Subtract( new TimeSpan( 0, 12, 0, 0, 0 ) );			
		}

		public BaseSpawner( GenericReader gr ) : this()
		{
			this.Deserialize( gr );
		}

		#region TIMER
		protected class SpawnerTimer : WowTimer
		{
			BaseSpawner from;
			public SpawnerTimer( BaseSpawner f ) : base( WowTimer.Priorities.Second , 10000, "SpawnerTimer" )
			{
				from = f;
				Start();
			}
			public override void OnTick()
			{
				from.OnTick();
				if ( !from.IsStillActive )
					Stop();				
				base.OnTick ();
			}

		}
		#endregion

		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			int currentAmount = gr.ReadInt();//	no longer used
			id = gr.ReadInt();
			model = gr.ReadInt();
			frequency = gr.ReadInt();
			DelayedRespawn();
			//currentAmount = 0;
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
			gw.Write( (int)2 );	
			gw.Write( 0 );
			gw.Write( id );	
			gw.Write( model );	
			gw.Write( frequency );	
		}
		#endregion

		#region UPDATE
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			PrepareUpdateData( data, ref offset, type, forOther, null );
		}
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther, Character f )
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
			Converter.ToBytes( 0f, data, ref offset );
			Converter.ToBytes( 4.5f, data, ref offset );
			Converter.ToBytes( 4.5f, data, ref offset );
			Converter.ToBytes( 4.5f, data, ref offset );
			Converter.ToBytes( 4.5f, data, ref offset );			
			Converter.ToBytes( 4.5f, data, ref offset );//	vitesse encore ?
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			Converter.ToBytes( (uint)0, data, ref offset );
			Converter.ToBytes( (uint)1, data, ref offset );

			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
			Converter.ToBytes( 0, data, ref offset );//	passe
		
			ResetBitmap();
			setUpdateValue( 0, Guid );
			setUpdateValue( 2, 9 );
			if ( id <= 0 )
				setUpdateValue( 3, 999999 );
			else
				setUpdateValue( 3, id );
			setUpdateValue( 4, (float)0.5 );

			setUpdateValue( (int)UpdateFields.UNIT_FIELD_HEALTH, 1000 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_POWER1, 0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXHEALTH, 1000 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXPOWER1, 0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_LEVEL, (int)1 );			

			setUpdateValue( (int)UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, (int)Factions.Friend );//	Faction template
			uint flags = (uint)( ( (uint)0 ) + ( (int)1  << 8 ) + 0 + ((uint)( 0 )<<24) );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_0, flags );
			
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_FLAGS, 0x0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME, 1000 );//	attackBoniiMin
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME + 1, 1000 );// attackBoniiMax
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BOUNDINGRADIUS, (float)1f );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_COMBATREACH, 1f );
			if ( id <= 0 )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_DISPLAYID, 356 );
			else
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_DISPLAYID, model );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_NATIVEDISPLAYID, model );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MOUNTDISPLAYID, 0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MINDAMAGE, 1f );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXDAMAGE, 1f );
			setUpdateValue( (int)UpdateFields.UNIT_CREATED_BY_SPELL, 1 );
			
		
			setUpdateValue( (int)UpdateFields.UNIT_NPC_FLAGS, 0 );//	NpcFlags
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_ATTACKPOWER, 0 );//	unknow		
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_2, 1 );//	unknow
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_RANGEDATTACKPOWER, 0 );//	unknow	
			FlushUpdateData( data, ref offset, 6 );
			return;
		}

		#endregion

		#region INIT
		/*
		public void Init( ConstructorInfo ct, int id, int freq, int how )
		{
			howMuch = how;
			frequency = freq;
			ci = ct;
			creature = ci.ReflectedType;
			iid = id;
		}
		public void Init( int _id, int freq, string cls )
		{
			if ( cls == null && World.GameObjectsAssociated.Exist( _id ) )
			{
				Init( _id, freq, Utility.ClassName( World.GameObjectsAssociated[ _id ].ToString() ) );
				return;
			}
			frequency = freq;
			howMuch = _id;			
			gameObjectHandler = cls;
		}
		public void Init( string cls, int freq )
		{
			frequency = freq;
			ConstructorInfo ct = Utility.FindConstructor( cls );
			GameObject go = (GameObject)ct.Invoke( null );
			if ( go.DefaultModel != 0 )
				howMuch = -go.DefaultModel;
			else
				howMuch = -go.Id;
			gameObjectHandler = cls;
		}
		public void Init( int _id, int freq )
		{
			howMuch = _id;
			frequency = freq;
		}*/
		#endregion

		#region FUNCTIONS
		public virtual void DisplayInfo( Character ch )
		{
		}
		public virtual string Name
		{
			get 
			{
				return "Generic spawner";
			}
		}
		public virtual void StillActive( Character ch )
		{
			StillActive( ch, false );
		}
		public virtual void StillActive( Character ch, bool noRespawn )
		{
			if ( !IsStillActive && !noRespawn )
			{
			//	ch.SendMessage( "Respawn " + this.Name );
				spawnerTimer = new SpawnerTimer( this );
				//	Make a tick when activate
				OnTick();
			}
			lastTime = DateTime.Now;
			//LastSeen = from;
		}
		public void ForceRespawn()
		{
			OnTick();
		}
		public void DelayedRespawn()
		{
		}

		public void Bind( Object m )
		{
			objects.Add( m );
			m.SpawnerLink = this;
	//		currentAmount++;
		}
		public void Release( Object m )
		{
			objects.Remove( m );
		//	currentAmount--;
		}
		
		public virtual void OnTick()
		{		
		}

		public override bool SeenBy( Character c )
		{
			if ( c.Player.AccessLevel == AccessLevels.PlayerLevel )
				return false;
			if ( Distance( c ) > 300 * 300 * 2 )
				return false;
			return true;
		}
		#endregion

		#region ACCESSORS
		public virtual Hashtable ZoneHash
		{
			get { return null; }
			set {}
		}
		public virtual UInt64 TrajetGuid
		{
			get { return 0; }
			set { UInt64 v = value; }
		}
		public ArrayList Objects
		{
			get { return objects; }
		}
		public bool IsStillActive
		{
			get 
			{
				TimeSpan ts = DateTime.Now.Subtract( lastTime );
				if ( ts.TotalSeconds > 30 )
					return false;
				return true;
			}
		}
		public virtual int Amount
		{
			get { return 0; }
			set { int fake = value; }
		}
		public int Frequency
		{
			get { return frequency; }
			set { frequency = value; }
		}
		public int CurrentAmount
		{
			get { return this.Objects.Count; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public int Model
		{
			get { return model; }
			set { model = value; }
		}		
		public DateTime LastSpawn
		{
			get { return lastSpawn; }
			set { lastSpawn = value; }
		}
		#endregion
/*
		#region TRAJET
		Trajets trajets;

		#endregion*/

	}

	
}
