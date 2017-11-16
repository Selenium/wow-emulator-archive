using System;
using System.Collections;
using System.Reflection;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for MobileSpawner.
	/// </summary>
	public class MobileSpawner : BaseSpawner
	{
		Type creature;
		float realx;
		float realy;
		float realz;
		int howMuch;
		UInt64 trajetGuid;
		int iid;
		Hashtable zoneHash;
		float [,]zone;
		

		public MobileSpawner()
		{
		}
		public MobileSpawner( GenericReader gr ) : this()
		{
			this.Deserialize( gr );
		}
		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			trajetGuid = (UInt64)gr.ReadInt64();
			realx = gr.ReadFloat();
			realy = gr.ReadFloat();
			realz = gr.ReadFloat();			
			howMuch = gr.ReadInt();
			iid = gr.ReadInt();
			ci = World.MobilePool( iid );
			if ( ci != null )
				creature = ci.ReflectedType;
			else
				Console.WriteLine("SpawnPoint file contain a invalid mob id: {0}", iid );
			DelayedRespawn();
			//CurrentAmount = 0;
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
			gw.Write( (int)2 );	
			gw.Write( trajetGuid );
			gw.Write( realx );
			gw.Write( realy );
			gw.Write( realz );
			gw.Write( howMuch );
			gw.Write( iid );
		}
		#endregion

		#region ACCESSORS
		
		public override Hashtable ZoneHash
		{
			get 
			{ 
				if ( zoneHash == null )
				{
					zoneHash = World.mapZones.GetZoneHash( MapId, ZoneId, X, Y );
					if ( zoneHash != null )
					{
						zone = new float[ 64, 64 ];
						World.mapZones.FillZValues( zoneHash, zone, this );
					}
				}
				return zoneHash; 
			}
			set { zoneHash = value; }
		}
		public float [,]ZoneZ
		{
			get 
			{
				if ( zone == null && ZoneHash == null )
				{
				}
				return zone;		
			}
		}
		public override UInt64 TrajetGuid
		{
			get { return trajetGuid; }
			set { trajetGuid = value; }
		}
		public float RealX
		{
			get { return realx; }
			set { realx = value; }
		}
		public float RealY
		{
			get { return realy; }
			set { realy = value; }
		}
		public float RealZ
		{
			get { return realz; }
			set { realz = value; }
		}

		public override int Amount
		{
			get { return howMuch; }
			set { howMuch = value; }
		}
		#endregion

		#region INIT
		public void Init( ConstructorInfo ct, int id, int freq, int how )
		{
			howMuch = how;
			Frequency = freq;
			ci = ct;
			creature = ci.ReflectedType;
			iid = id;
			if ( this.ZoneHash != null )
				return;
		}
		#endregion

		#region FUNCTIONS
		public override void StillActive( Character ch, bool noRespawn )
		{
			if ( CurrentAmount >= this.Amount )
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
			ch.SendMessage( "Amount " + CurrentAmount.ToString() + "/"+ this.howMuch.ToString() );
		}
		public override string Name
		{
			get 
			{
				BaseCreature bc = (BaseCreature)ci.Invoke( null );					
				return bc.Name + ", " + this.ZoneId;
			}
		}
		
		public override void OnTick()
		{
			TimeSpan ts = DateTime.Now.Subtract( LastSpawn );
			int compteur = (int)ts.TotalSeconds;		
			if ( Frequency == 0 )
			{
				Console.WriteLine("BaseSpawner frequency = 0, {0},{1},{2},{3},{4}", ci.ToString(), X, Y, Z, MapId );
				return;
			}
			if ( compteur / Frequency > howMuch )
			{
				compteur = howMuch * Frequency;
			}
			while( compteur > 0 )
			{

				if ( CurrentAmount < howMuch )
				{
					BaseCreature bc = (BaseCreature)ci.Invoke( null );					
					bc.InitStats();
					bc.SpawnerLink = this;
					bc.Orientation = this.Orientation;
				//	if ( bc.AIEngine != null && bc.AIEngine.CustomBehaviours != null && bc.AIEngine.CustomBehaviours.Contains( CustomBehavioursTypes.Stay ) )
						World.Add( bc, X, Y, Z, MapId );
					/*else*/
					//	World.Add( bc, realx, realy, realz, MapId );
					Bind( bc );
					bc.ZoneId = ZoneId;
					LastSpawn = DateTime.Now;
					compteur -= Frequency;
					bc.OnAddToWorld();
				}
				else
					break;
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
	}
}
