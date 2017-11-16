using HelperTools;
using System;
using System.Collections;
using Server.Creatures;
namespace Server.Quests
{
}
namespace Server
{
	#region ENUMS
	public enum CustomBehavioursTypes : int
	{
		None = 0,
		Stay = 1,
		KeepOrientation,
	}
	public enum AIStances : int
	{
		Passive = 0,
		Defensive,
		Agressive
	}
	public enum AIStates : int
	{
		DoingNothing = 0,
		Explore,
		MoveNear,
		MoveFar,
		LookingForPrey,
		Attack,
		BeingAttacked,
		Fighting,
		Flee,
		CallForHelp,
		MoveTo,
		MoveFarFrom,
		HealFriend,
		Pause1,
		Pause2,
		Pause3,
		Pause4,
		Pause5,
		Pause6,
		Pause7,
		Pause8,
		Pause9,
		Moving,
		Follow,
		ReturnHome,
		Speaking
	}
	public enum AITypes
	{
		NonAgressiveAnimalAI,
		Beast,
		Marchant,
		Berserk,
		Predator,
		Custom
	}
	public enum SpellsTypes
	{
		None,
		Offensive,
		Defensive,
		Healing,
		Curse
	}
	#endregion
	/// <summary>
	/// Description of BaseCreature.	
	/// </summary>
	public class BaseCreature : Mobile
	{
		#region Dispose
		public override void Delete()
		{
			if ( SpawnerLink != null )
			{
				SpawnerLink.Release( this );
				//SpawnerLink.CurrentAmount--;
			}
			World.Remove( this, this );
			base.Delete();
		}
		#endregion

		#region PROPERTIES
		
		DateTime speakingFrom;
		public float curr = 0;
		float baseX;
		float baseY;
		float baseZ;
		//	public bool active = true;
		BaseAIType aiEngine;
		Coord currentTrajet;
		Coord lastEtape = null;
		bool forward = true;
		float peaceSpeed;
		BaseQuest [] quests;
		string npcText00;
		string npcText01;
		int gender;
		DateTime lastTime;
		
		
		// dynamic
		public ArrayList HateList = new ArrayList();
		public AIStances AIStance;
		public Character DebugSniffer;
		public int npcMenuId;
		#endregion

		#region CONSTRUCTORS
		public BaseCreature()
		{
			HitPoints = BaseHitPoints = 1;
			if ( !World.Loading )
				InitObjectives();
			else
				base.Delete();
			//	InitStats();

			/*	this.Stamina = 15 + this.Level * 2;
				this.Str = 5 + Level * 2;
				this.Iq = 5 + Level * 2;
				this.Agility = 5 + Level * 2;
				this.Spirit = 5 + Level * 2;
				if ( Stamina > 20 )
					this.HitPoints = this.BaseHitPoints = 32 + ( Stamina - 20 ) * 10;
				else
					this.HitPoints = this.BaseHitPoints = 32 + Stamina;
				if ( Iq > 20 )
					this.BaseMana = this.Mana = 300 + ( Stamina - 20 ) * 150;
				else
					this.BaseMana = this.Mana = 300 + Stamina;
				this.manaType = 0;*/
			peaceSpeed = Speed;
			if ( RunSpeed == 0 )
				RunSpeed = 7f;
		}

		public BaseCreature( float x, float y, float z, float orient ) : base( x, y, z, orient )
		{
		}
		public BaseCreature( int model, float x, float y, float z, float orient ) : this( x, y, z, orient )
		{
			this.HitPoints = this.BaseHitPoints = 32;
			this.BaseMana = this.Mana = 100;
			this.manaType = 0;
			Level = 1;
			Str = 0;
			this.Agility = 0;
			this.Armor = 1;
			this.Iq = 0;
			this.Spirit = 0;
			this.Stamina = 0;
			this.Model = model;
		}

		public BaseCreature( float x, float y, float z, float bx, float by, float bz, float orient ) : this( x, y, z, orient )
		{
			baseX = bx;
			baseY = by;
			baseZ = bz;
			X = baseX + (float)Math.Sin( curr ) * 2f;
			Y = baseY + (float)Math.Cos( curr ) * 2f;
		}
		public BaseCreature( GenericReader gr )
		{
			Deserialize( gr );
		}

		public virtual void InitObjectives()
		{
		}

		public virtual void OnAddToWorld()
		{
		}

		public void InitStats()
		{
			if ( Stamina == 0 )
				this.Stamina = 20 + this.Level;
			if ( Str == 0 )
				this.Str = 5 + Level * 2;
			if ( Iq == 0 )
				this.Iq = 5 + Level;
			if ( Agility == 0 )
				this.Agility = 5 + Level;
			if ( Spirit == 0 )
				this.Spirit = 5 + Level;
			if ( BaseHitPoints < 2 )
			{
				if ( Stamina > 20 )
					this.BaseHitPoints = 32 + ( Stamina - 20 ) * 10;
				else
					this.BaseHitPoints = 32 + Stamina;
			}
			HitPoints = BaseHitPoints;
	/*		if ( BaseMana < 2 )
			{
				if ( Iq > 20 )
					this.BaseMana = ( 300 + ( Stamina - 20 ) * 150 ) / 10;
				else
					this.BaseMana = ( 300 + Stamina ) / 10;
			}*/
			if ( ManaType != 1 )
				Mana = BaseMana;
			else
				Mana = 0;
			if ( (NpcTypes)this.NpcType == NpcTypes.Critter )
			{
				HitPoints = BaseHitPoints = 1;
			}
			//this.manaType = 0;
			//AdjustDamage();
		}
		#endregion

		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();			
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
			gw.Write( (int)0 );			
		}
		#endregion

		#region ACCESSORS
		public DateTime SpeakingFrom
		{
			get { return speakingFrom; }
			set { speakingFrom = value; }
		}
		public int Gender
		{
			set { gender = value; }
			get { return gender; }
		}		
		public string NpcText00
		{
			set { npcText00 = value; }
			get { return npcText00; }
		}
		public string NpcText01
		{
			set { npcText01 = value; }
			get { return npcText01; }
		}
		public Coord CurrentTrajet
		{
			get { return currentTrajet; }
		}
		public BaseAIType AIEngine
		{
			set { aiEngine = value; }
			get { return aiEngine; }
		}
		public AITypes AIType
		{
			get { return aiEngine.AIType; }
		}
		public virtual BaseQuest [] Quests
		{
			get { return quests; }
			set { quests = value; }
		}

		#endregion

		#region AI
		DateTime debugLast = DateTime.Now;
		/*
		public override bool SeenBy( Character c )
		{
			return true;
		}*/
		static ArrayList fakeList = new ArrayList();
		public ArrayList KnownObjects()
		{
			if ( LastSeen == null )
				return fakeList;
			return LastSeen.Player.KnownObjects;
		}
		
		public bool IsHostile( Mobile m )
		{
			if ( Reputation( m ) <= 0.334975f )
				return true;
			return false;
		}

		public bool IsFriend( Mobile m )
		{
			if ( Reputation( m ) > 0.334975f )
				return true;
			return false;
		}

		public override void OnGetHit( Mobile by, bool sp, int damageAmount )
		{
			Running = true;
			base.OnGetHit( by, sp, damageAmount );
			if ( aiEngine != null )
			{
				AIState = aiEngine.OnGetHit( by, AIState, damageAmount );
				if ( AttackTarget == null )
					AttackTarget = by;
				OnTick();				
				return;
			}
			Running = true;
			if ( AttackTarget == null )
				AttackTarget = by;
			switch( AIState )
			{
				case AIStates.BeingAttacked:
				case AIStates.Fighting:
				case AIStates.Attack:						
					break;
				default:
					AIState = AIStates.BeingAttacked;
					break;
			}
		}
		/*
		public override int Hit( Mobile target )
		{
			return base.Hit( target );
		}*/
		public bool IsStillActive()
		{
			if ( this.SummonedBy != null )
			{
				if ( SummonedBy is Character )
					if ( ( SummonedBy as Character ).Player != null &&
						( SummonedBy as Character ).Player.SelectedChar != null &&
						( SummonedBy as Character ).Player.SelectedChar == SummonedBy as Character )
						return true;
				if ( SummonedBy is BaseCreature )
					(SummonedBy as BaseCreature ).IsStillActive();	
				return false;
			}

			TimeSpan ts = DateTime.Now.Subtract( lastTime );
			//		Console.WriteLine("{0} {1} {2}", this.GetType().ToString(), Guid.ToString( "X16" ), ts.TotalSeconds );
			if ( ts.TotalSeconds > 30 )
				return false;
			return true;
		}
		public override void OnTick()
		{
		/*	if ( World.allConnectedChars.Count > 0 && this.Distance( World.allConnectedChars[ 0 ] as Object ) > 200 * 200 )
			{
				( World.allConnectedChars[ 0 ] as Character ).SendMessage( this.GetType().ToString() + " dist = " + this.Distance( World.allConnectedChars[ 0 ]  as Object ).ToString() );
			}*/
			if ( !IsStillActive() )
			{
				HitPoints = BaseHitPoints;
				Mana = BaseMana;
				//	active = false;
				LastSeen = null;
				Delete();
				return;
			}
			if ( DebugSniffer != null )
			{
				TimeSpan ts = DateTime.Now.Subtract( debugLast );
				DebugSniffer.SendMessage( "BaseCreature::OnTick " + ts.TotalMilliseconds.ToString() );
				debugLast = DateTime.Now;
			}
			if ( Deleted )
				return;
			if ( Dead )
				return;
			if ( Freeze )
				return;
						   
			this.UpdateXYZ();

			if ( !( ForceFlee || ForceStun || ForceRoot ) && aiEngine != null )
			{
				if ( SpawnerLink != null && aiEngine.CustomBehaviours.Contains( CustomBehavioursTypes.Stay ) )
				{
					switch( AIState )
					{
						case AIStates.Fighting:
						case AIStates.Flee:
						case AIStates.Explore:
						case AIStates.Attack:
						case AIStates.BeingAttacked:
							break;
						default:
							//UpdateXYZ();
							if ( Distance( SpawnerLink ) > 5 )
							{
								AIState = AIStates.ReturnHome;
								if ( Math.Abs( Z - SpawnerLink.Z ) > 3 )
									MoveTo( X + ( SpawnerLink.X - X ) / 2, Y + ( SpawnerLink.Y - Y ) / 2, Z + ( SpawnerLink.Z - Z ) / 2 );
								else
									MoveTo( SpawnerLink.X, SpawnerLink.Y, SpawnerLink.Z );
							}
							else
							{
								if ( Math.Abs( Z -  SpawnerLink.Z ) > 1 )
									InstantMoveTo( SpawnerLink.X, SpawnerLink.Y, SpawnerLink.Z );
								AIState = AIStates.Pause1;						
							}
							break;

					}
				}
				if ( SpawnerLink != null && aiEngine.CustomBehaviours.Contains( CustomBehavioursTypes.KeepOrientation ) )
				{
					switch( AIState )
					{
						case AIStates.Fighting:
						case AIStates.Flee:
						case AIStates.Explore:
						case AIStates.Attack:
						case AIStates.BeingAttacked:
						case AIStates.ReturnHome:
							break;
						default:
							if ( Math.Abs( Orientation - SpawnerLink.Orientation ) > 0.1 )
							{
								UpdateXYZ();
								float x = X + (float)Math.Cos( SpawnerLink.Orientation ) / 2;
								float y = Y + (float)Math.Sin( SpawnerLink.Orientation ) / 2;
								MoveTo( x, y, Z );
								Orientation = SpawnerLink.Orientation;
							}
							break;
					}
				}			
				aiEngine.OnTick();
			}


			Regeneration();
			if ( this.ForceFlee )
				AIState = AIStates.Flee;
			if ( this.ForceStun )
				AIState = AIStates.Pause1;

			//if ( this.GetType().ToString().EndsWith( "DarkeyeBonecaster" ) )
			//	World.allConnectedAccounts.BroadCastMessage( "blabla " + AIState.ToString() );

			switch( AIState )
			{
				case AIStates.BeingAttacked:
					if ( AttackTarget != null && AttackTarget.HitPoints > 0 )
					{
						AIState = AIStates.Fighting;
						BeginCombatWith( AttackTarget );
					}
					else
						AIState = AIStates.DoingNothing;
					break;
				case AIStates.Flee:
					if ( !ForceFlee && Distance( AttackTarget ) > 40 * 40 )
					{
						Running = false;
						AIState = AIStates.Explore;
						AttackTarget = null;
					}
					else
					{
						Running = true;
						Flee( AttackTarget );
					}
					break;
				case AIStates.Explore:
				case AIStates.LookingForPrey:
					OnMovementHeartBeat();
					break;
				case AIStates.Fighting:
				case AIStates.Attack:	
					break;
				default:
					break;
			}
			if ( DebugSniffer != null )
				DebugSniffer.SendMessage( "BaseCreature::OnTick::FinalAIState = " + AIState );
		}

		public void StillActive( Character from )
		{
			lastTime = DateTime.Now;
			//active = true;
		//	if ( SpawnerLink != null )
//				this.SpawnerLink.StillActive( from, true );//	Because it may crash while mofiying the list of mob while it is refreshing for the player
			LastSeen = from;
		}
		//bool FreeMovement = true;
		bool FreeMovement
		{
			get { if ( this.SpawnerLink != null && ( SpawnerLink as MobileSpawner ).TrajetGuid > 0 ) return false; return true; }
		}
		int lastDir = 0;
		static int [,]probDir = { 
				{ 5, 0, 1 }, 
				{ 0, 1, 2 }, 
				{ 1, 2, 3 }, 
				{ 2, 3, 4 }, 
				{ 3, 4, 5 }, 
				{ 4, 5, 0 } };
		DateTime ntest = DateTime.Now;
		public MapPoint ChooseDestinationPoint()
		{
			int t = 0;
			while( t < 64 )
			{
				int ax = Utility.Random( 64 );
				int ay = Utility.Random( 64 );
				float z = ( SpawnerLink as MobileSpawner ).ZoneZ[ ay, ax ];
				if ( z > -10000 && Math.Abs( z - Z ) < 1 )
				{
					float x = ( ax - 32 ) * MapZones.UNITSIZE + SpawnerLink.X;
					if ( Math.Abs( x - X ) < 11 )
					{
						float y = ( ay - 32 ) * ( MapZones.UNITSIZE * 0.5f ) + SpawnerLink.Y;
						if ( Math.Abs( y - Y ) < 11 )
							return new MapPoint( x, y, z );
					}
				}
				t++;
			}
			return null;
		}
		public MapPoint ChooseDestinationPoint2()
		{
			int dir = 0;
		/*	TimeSpan ts = DateTime.Now.Subtract( ntest );
			dir = (int)ts.TotalSeconds / 6;
			dir = dir % 6;
			if ( this.GetType().ToString().EndsWith( "Rabbit" ) )
				( World.allConnectedChars[ 0 ] as Character ).SendMessage( "move to " + dir.ToString() );
*/
			if ( Utility.Random4() == 0 )
				dir = Utility.Random( 6 );			
			else
				dir = probDir[ lastDir, Utility.Random( 3 ) ];
			MapPoint mp = World.mapZones.Get( dir, ZoneId, MapId, this, true );
			if ( mp == null )
			{
				/*if ( SpawnerLink.ZoneHash == null )
					mp = new MapPoint( ( this.SpawnerLink as MobileSpawner ).RealX, ( this.SpawnerLink as MobileSpawner ).RealY, ( this.SpawnerLink as MobileSpawner ).RealZ );
				else
				{
					mp = new MapPoint( ( this.SpawnerLink as MobileSpawner ).RealX, ( this.SpawnerLink as MobileSpawner ).RealY, ( this.SpawnerLink as MobileSpawner ).RealZ );*/
					mp = World.mapZones.NearestPoint( SpawnerLink.ZoneHash, MapId, ZoneId, X, Y );
				//}
			}
			float xx = 10f;
			if ( mp != null )
			{
				xx = mp.x - X;
				float yy = mp.y - Y;
				xx *= xx;
				yy *= yy;
				xx += yy;
			}
			if ( mp == null || xx < 3 )
			{
				dir = Utility.Random( 6 );
				mp = World.mapZones.Get( dir, ZoneId, MapId, this, true );
			}
			lastDir = dir;
			return mp;
		}
		public Coord ChooseTrajet()
		{			
			if ( FreeMovement )
			{
				return null;
			}
			else
			{
				float mindist = float.MaxValue;
				Coord t = null;	
			//	int i;
				Trajet ts = World.trajets.Find( ( SpawnerLink as MobileSpawner ).TrajetGuid );
				return ts[ 0 ];
			}
			/*
			if ( SpawnerLink == null )
			{
				float dist = float.MaxValue;
				foreach( BaseSpawner bs in World.allSpawners )
				{
					float xx = X - bs.X;
					float yy = Y - bs.Y;
					xx *= xx;
					yy *= yy;
					xx += yy;
					if ( xx < dist && bs.MapId == MapId )
					{
						dist = xx;
						SpawnerLink = bs;
					}
				}
			}
			return this.SpawnerLink.ChooseTrajet();*/
		}

		public float Distance( Coord c )
		{
			float x;
			float y;
			float z;
			moveVector.Get( out x, out y, out z );			
			float xx = x - c.x;
			float yy = y - c.y;
			float zz = z - c.z;
			xx *= xx;
			yy *= yy;
			zz *= zz;
			xx += yy;
			xx += zz;
			return xx;
		}
		/*
		 86 29 28 00 00 A0 00 F0 0E 65 E6 C3 45 55 26 C5  .)(......e..EU&.
AC 1A BF 42 45 51 9B 0B 00 00 00 00 00 6D 12 00  ...BEQ.......m..
00 03 00 00 00 E0 00 E7 C3 00 0A 27 C5 D6 BD BE  ...........'....
42 FB A7 BE FF F7 1F BF FF 

B1 30 25 00 00 A0 00 F0 28 FB B0 C3 30 9C 27 C5  .0%.....(...0.'.
E0 B0 BF 42 55 B1 9E 0B 00 00 00 00 00 42 18 00  ...BU........B..
00 02 00 00 00 3A 91 B8 C3 8D CF 27 C5 03 82 BF  .....:.....'....
42 D6 AF FF FF 		

		
		
D1 1C 25 00 00 A0 00 F0 
50 45 D4 C3 26 DE 21 C5 79 CF BF 42 
A3 44 9E 0B 
03 23 D6 76 
00 
00 00 00 00 
00 01 00 00 
00 00 00 00 
01 00 00 00 
50 45 D4 C3 26 DE 21 C5 79 CF BF 42 

D1 1C 25 00 00 A0 00 F0 
50 45 D4 C3 26 DE 21 C5 79 CF BF 42 
E9 45 9E 0B 
04 EC 62 C7 
40 
00 01 00 00 
00 00 00 00 
01 00 00 00 50 45 D4 C3 26 DE 21 
C5 79 CF BF 42 		
		
		
D2 3F 83 00 00 00 00 00 
30 6A DB C3 A4 5A 22 C5 36 93 BF 42 
5F 5C 9B 0B 
00 00 03 00 
00 
7E 08 02 00 
12 00 00 00 
CB 9B DB C3 C7 41 22 C5 AF 5D C2 42 
85 BB DE C3 F9 5E 23 C5 BD 1A CA 42 
34 DA F5 C3 C2 44 2A C5 4A 77 EE 42 
E7 02 39 C4 1C D6 3F C5 7E 55 EF 42 
DD DD 44 C4 3D 39 4B C5 B3 2D ED 42 
EE 11 31 C4 15 A1 58 C5 F9 53 F7 42 
3D F4 AC C3 79 F8 60 C5 BD 4B F8 42 
0E 94 AF 42 9D 8A 66 C5 8E B6 69 42 
57 BA B8 43 3D 96 68 C5 F9 59 4C 42 
E5 A2 72 44 72 A2 6A C5 1E 0C 3F 42 
54 1C 96 44 3D B2 6F C5 C3 7C 54 42 
31 18 CB 44 D9 68 70 C5 9B CA C3 42 
04 76 D4 44 6D 1A 77 C5 E8 2D BF 42 
BA 9F D7 44 39 3D 7D C5 6B 6D A4 42 
7B D7 C6 44 92 F6 80 C5 42 3D 9A 42 
E9 6A C4 44 75 FF 82 C5 E5 28 96 42 
BA 3A CA 44 86 86 85 C5 D9 54 82 42 
1C B2 D1 44 D5 E2 86 C5 B8 54 82 42
*/

		public void Flee( Mobile m )
		{
			if ( this.FreeMovement )
			{
				if ( ReachDestination() )
				{
					float dist = float.MinValue;
					int bestDir = 0;
					MapPoint bestPoint = null;
					for(int dir = 0;dir < 6;dir++ )
					{
						MapPoint mp = World.mapZones.Get( dir, ZoneId, MapId, this, true );
						if ( mp != null )
						{
							float dx = m.X - mp.x;
							float dy = m.Y - mp.y;
							dx *= dx;
							dy *= dy;
							dx += dy;
							if ( dx > dist )
							{
								bestDir = dir;
								dist = dx;
								bestPoint = mp;
							}
						}						
					}
					lastDir = bestDir;
					if ( bestPoint == null )
					{
						//	bestPoint = World.mapZones.NearestPoint( MapId, ZoneId, X, Y );
						Console.WriteLine("Missing points at {0} {1}", X, Y );
						return;
					}
					MoveTo( bestPoint.x, bestPoint.y, bestPoint.z, new OnReachDelegate( OnTick ) );
				}
			}
			else
				if ( currentTrajet == null )
			{
				currentTrajet = ChooseTrajet();	
				if ( currentTrajet == null )
					return;
				FleeToEtape( currentTrajet );
			}
			else
			{	
				if ( ReachDestination() )
				{
					float x1 = currentTrajet.previous.x - m.X;
					float y1 = currentTrajet.previous.y - m.Y;
					float z1 = currentTrajet.previous.z - m.Z;
					x1 *= x1;
					y1 *= y1;
					z1 *= z1;
					float x2 = currentTrajet.next.x - m.X;
					float y2 = currentTrajet.next.y - m.Y;
					float z2 = currentTrajet.next.z - m.Z;
					x2 *= x2;
					y2 *= y2;
					z2 *= z2;
					float x3 = 0f;
					float y3 = 0f;
					float z3 = 0f;
					float x4 = 0f;
					float y4 = 0f;
					float z4 = 0f;
					if ( currentTrajet is Intersection )
					{
						Intersection ii = (Intersection)currentTrajet;
						x3 = ii.left.x - m.X;
						y3 = ii.left.y - m.Y;
						z3 = ii.left.z - m.Z;
						x4 = ii.right.x - m.X;
						y4 = ii.right.y - m.Y;
						z4 = ii.right.z - m.Z;
						x3 *= x3;
						x4 *= x4;
						y3 *= y3;
						y4 *= y4;
						z3 *= z3;
						z4 *= z4;
						x3 += y3 + z3;
						x4 += y4 + z4;
					}
					x1 += y1 + z1;
					x2 += y2 + z2;
					if ( x1 >= x2 && x1 >= x3 && x1 >= x4 )
						currentTrajet = currentTrajet.previous;
					else
						if ( x2 >= x1 && x2 >= x3 && x1 >= x4 )
						currentTrajet = currentTrajet.next;
					else
						if ( x3 >= x1 && x1 >= x2 && x1 >= x4 )
						currentTrajet = ( currentTrajet as Intersection ).left;
					else
						currentTrajet = ( currentTrajet as Intersection ).right;

					FleeToEtape( currentTrajet );
				}
			}
		}

		public override void OnMovementHeartBeat()
		{
			if ( LastSeen == null )
				return;
			if ( AIState == AIStates.Fighting || ( (int)AIState >= (int)AIStates.Pause1 && 
				(int)AIState <= (int)AIStates.Pause9 ) )
				return;
			/*	if ( FreeMovement )
				{
					if ( !ReachDestination() )
						FreeMove();
					else

				}
				else*/
		{
			if ( this.FreeMovement )
			{
				if ( ReachDestination() )
				{
					MapPoint mp = ChooseDestinationPoint();
					if ( mp != null )
						MoveTo( mp.x, mp.y, mp.z, new OnReachDelegate( OnTick ) );
				}
			}
			else
			{
				if ( currentTrajet == null )
				{
					currentTrajet = ChooseTrajet();	
					if ( currentTrajet == null )
						return;		
					MoveToEtape( currentTrajet );
				}
				else
				{			
					if ( ReachDestination() )
					{					
						if ( currentTrajet is Intersection )
						{
							Intersection tempT = currentTrajet as Intersection;
							switch( Utility.Random4() )
							{
								case 0:
									currentTrajet = tempT.right;
									forward = true;
									break;
								case 1:
									currentTrajet = tempT.left;
									forward = false;
									break;
								case 2:
									currentTrajet = tempT.next;
									forward = true;
									break;
								case 3:
									currentTrajet = tempT.previous;
									forward = false;
									break;
							}
						}
						else
						{
							if ( forward )
							{						
								if ( currentTrajet.next == null )
									forward = false;
								else
									currentTrajet = currentTrajet.next;
							}
							else
							{
								if (  currentTrajet.previous == null )
									forward = true;
								else
									currentTrajet = currentTrajet.previous;
							}
						}
						MoveToEtape( currentTrajet );
					}				
				}
			}
		}
			//	base.OnMovementHeartBeat();
		}
		public void FleeToEtape( Coord c )
		{
			if ( c.occ == this )
				c.occ = null;
			MoveTo( c.x, c.y, c.z, new OnReachDelegate( OnTick ) );
		}
		public void MoveToEtape( Coord c )
		{
			if ( c.occ != null )
			{
				if ( c.occ.CurrentTrajet == c )
				{
					forward = !forward;
					if ( lastEtape != null )
						currentTrajet = lastEtape;
					return;
				}
			}
			c.occ = this;
			if ( lastEtape != null )
				lastEtape.occ = null;
			MoveTo( c.x, c.y, c.z, new OnReachDelegate( OnTick ) );
			lastEtape = currentTrajet;
		}
		public void FreeMove()
		{
		}
		#region AISTATES
		public bool NearDeath()
		{
			if ( this.HitPoints < this.BaseHitPoints / 10 )
				return true;
			return false;
		}
		public bool SeriouslyDeath()
		{
			if ( this.HitPoints < this.BaseHitPoints / 5 && !NearDeath() )
				return true;
			return false;
		}
		public bool Wounded()
		{
			if ( this.HitPoints < this.BaseHitPoints / 2 && !SeriouslyDeath() )
				return true;
			return false;
		}
		public bool LightWound()
		{
			if ( this.HitPoints * 10 < this.BaseHitPoints * 9 && !Wounded() )
				return true;
			return false;
		}
		public bool NoWound()
		{
			if ( this.HitPoints * 10 > this.BaseHitPoints * 9 )
				return true;
			return false;
		}
		#endregion
		#endregion

		#region QUEST AND DIALOG
		public delegate DialogStatus OnDialogStatusHandler( Mobile from, Character c );
		public delegate void OnHelloHandler( Mobile from, Character c );
		public delegate void OnDialogCharacterSelectionHandler( Mobile from, Character c, int id, int num );
		public delegate void OnChooseQuestHandler( Mobile from, Character c, int id );
		public delegate void OnAcceptQuestHandler( Mobile from, Character c, int id );
		
		static public Hashtable NpcsCustomOnDialogStatus = new Hashtable();
		static public Hashtable NpcsCustomOnHello = new Hashtable();
		static public Hashtable NpcsCustomOnChooseQuest = new Hashtable();
		static public Hashtable NpcsCustomOnDialogCharacterSelection = new Hashtable();
		static public Hashtable NpcsCustomOnAcceptQuest = new Hashtable();

		public virtual DialogStatus OnDialogStatus( Character c )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			if ( NpcsCustomOnDialogStatus[ Id ] != null )
				return ( NpcsCustomOnDialogStatus[ Id ] as OnDialogStatusHandler )( this, c );
			return DialogStatus.None;
		}

		public virtual void OnChooseQuest( Character c, int id )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			if ( NpcsCustomOnChooseQuest[ id ] != null )
				( NpcsCustomOnChooseQuest[ id ] as OnChooseQuestHandler )( this, c, id );
		}
		public virtual void OnGossipHello( Character c )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
		}
		public virtual void OnHello( Character c )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			if ( NpcsCustomOnHello[ Id ] != null )
				( NpcsCustomOnHello[ Id ] as OnHelloHandler )( this, c );
			/*	else
				{
					BaseQuest bq = Quests[ 0 ];// This npc have only one quest
					if ( !c.QuestCompleted( bq ) && !c.QuestDone( Quests[ 0 ] ) )
					{//	The quest is not completed and not running so present it to the player
						if ( !c.HaveQuest( bq ) )
							c.ResponseQuestDetails( this, bq.Id, bq.Name, bq.Desc, bq.Details  );
					}
					else
						if ( c.QuestCompleted( Quests[ 0 ] ) )//	The quest is complete, ask for the reward
						c.OfferReward( this, bq.Id, "Great !", bq.OfferRewardText  );
					else
						if ( c.QuestDone( bq ) )//	the quest is already done
						c.ResponseMessage( this, 1, "Greetings " + c.Name );				
				}*/
		}
		public virtual string QueryNpcText( int id )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			return " ";
		}
		public virtual void DialogCharacterSelection( Character c, int id, int num )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			if ( NpcsCustomOnDialogCharacterSelection[ Id ] != null )
				( NpcsCustomOnDialogCharacterSelection[ Id ] as OnDialogCharacterSelectionHandler )( this, c, id, num );
		}
		public virtual void OnAcceptQuest( Character c, int id )
		{
			SpeakingFrom = DateTime.Now;
			this.AIState = AIStates.Speaking;
			if ( NpcsCustomOnAcceptQuest[ Id ] != null )
				( NpcsCustomOnAcceptQuest[ Id ] as OnAcceptQuestHandler )( this, c, id );
		}
		#endregion

	}
}
