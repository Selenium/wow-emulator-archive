using System;
using System.Collections;
using System.Reflection;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for GameObjectSpawner.
	/// </summary>
	public class GameObjectSpawner : BaseSpawner
	{
		float rotationX;
		float rotationY;
		float rotationZ;
		float facing;
		string gameObjectHandler;
		int defaultModel;
		GameObject go;

		public GameObjectSpawner() : base()
		{
		}
		public GameObjectSpawner( GenericReader gr ) : this()
		{
			this.Deserialize( gr );
		}
		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			defaultModel = gr.ReadInt();
			rotationX = gr.ReadFloat();
			rotationY = gr.ReadFloat();
			rotationZ = gr.ReadFloat();
			facing = gr.ReadFloat();
			int pres = gr.ReadInt();
			if ( pres == 1 )
			{
				gameObjectHandler = gr.ReadString();
			}	
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
			gw.Write( (int)0 );	
			gw.Write( defaultModel );
			gw.Write( rotationX );
			gw.Write( rotationY );
			gw.Write( rotationZ );
			gw.Write( facing );
			if ( gameObjectHandler == null )
				gw.Write( 0 );
			else
			{
				gw.Write( 1 );
				gw.Write( gameObjectHandler );
			}
		}
		#endregion

		#region INIT
		public void Init( int _id, int freq, string cls )
		{
			if ( cls == null && World.GameObjectsAssociated.Exist( _id ) )
			{
				Init( _id, freq, Utility.ClassName( World.GameObjectsAssociated[ _id ].ToString() ) );
				return;
			}
			Frequency = freq;
			gameObjectHandler = cls;
			defaultModel = _id;
		}
		public void Init( string cls, int freq )
		{
			Frequency = freq;
			ConstructorInfo ct = Utility.FindConstructor( cls );
			GameObject go = (GameObject)ct.Invoke( null );
			if ( go.DefaultModel != 0 )
				defaultModel = go.DefaultModel;
			else
				defaultModel = go.Id;
			gameObjectHandler = cls;
		}
		public void Init( int _id, int freq )
		{
			defaultModel = _id;
			Frequency = freq;
		}
		#endregion

		#region FUNCTIONS
		public override void StillActive( Character ch, bool noRespawn )
		{
			if ( CurrentAmount > 0 )
				return;
			if ( !IsStillActive && !noRespawn )
			{
				spawnerTimer = new SpawnerTimer( this );
				//	Make a tick when activate
				OnTick();
			}
			lastTime = DateTime.Now;
		}
		public override void DisplayInfo( Character ch )
		{
			ch.SendMessage( "Spawner for " + Name );
		}
		public override string Name
		{
			get 
			{
				return "Game object id = " + ( defaultModel ).ToString();
			}
		}
			
		public override void OnTick()
		{	
			if ( CurrentAmount > 0 )
				return;
			TimeSpan ts = DateTime.Now.Subtract( LastSpawn );			
			int compteur = (int)ts.TotalSeconds;
			if ( compteur > Frequency )
			{
				if ( CurrentAmount == 0 && gameObjectHandler != null )//	Game Object
				{
					go = World.Add( defaultModel, gameObjectHandler, X, Y, Z, Orientation, MapId );
					go.SpawnerLink = this;
					go.Id = defaultModel;
					go.ZoneId = ZoneId;
					go.Orientation = this.Orientation;					
					Bind( go );
					LastSpawn = DateTime.Now;
				}
				else
				{
					GameObject go = World.Add( defaultModel, X, Y, Z, Orientation, MapId );
					go.SpawnerLink = this;
					go.ZoneId = ZoneId;
					go.Orientation = this.Orientation;
					Bind( go );					
					LastSpawn = DateTime.Now;
				}
				return;
			}
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
		public override UInt64 TrajetGuid
		{
			get { return 0; }
			set { UInt64 v = value; }
		}
		public float RotationX
		{
			get { return rotationX; }
			set { rotationX = value; }
		}
		public float RotationY
		{
			get { return rotationY; }
			set { rotationY = value; }
		}
		public float RotationZ
		{
			get { return rotationZ; }
			set { rotationZ = value; }
		}
		public override int Amount
		{
			get { return 1; }
		}
		public float Facing
		{
			get { return facing; }
			set { facing = value; }
		}
		#endregion

	}
}
