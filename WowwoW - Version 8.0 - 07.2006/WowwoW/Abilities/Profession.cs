using System;
using System.Collections;
using HelperTools;
using Server.Items;

namespace Server
{
	#region ENUMS
	public enum Professions
	{
		NoProf,
		Alchemist,
		Miner,
		Herborist,
		Blacksmith,
		Tailor,
		Fishing,
		LeatherWorker,
		Skinning,
		Enchanter,
		Engineer,
		Cooking,
		FirstAid
	}
	public enum ProfessionLevels
	{
		Apprentice = 0,
		Journeyman = 1,
		Expert = 2,
		Artisan = 3
	}
	
	public enum SkillsIds
	{
		Mining = 186
	}
	#endregion
	/// <summary>
	/// Summary description for Profession.
	/// </summary>
	public class Profession : Skill
	{
		ProfessionLevels level;
		int id;
		int coolDown;
		int castingTime;

		#region CONSTRUCTORS
		public Profession( )
		{
		}

		public Profession( ProfessionLevels t, int i, int casttime, int cooldown )
		{
			level = t;
			if ( casttime == 0 )
				casttime = 2500;
			coolDown = cooldown;
			castingTime = casttime;
			id = i;
			switch( level )
			{
				case ProfessionLevels.Apprentice:
					Current = 15;
					Max = 75;
					break;
				case ProfessionLevels.Journeyman:
					Max = 150;
					break;
				case ProfessionLevels.Expert:
					Max = 225;
					break;
				case ProfessionLevels.Artisan:
					Max = 300;
					break;
			}
		}
		public Profession( ProfessionLevels t, int i, ushort cur, ushort ind ) : base( cur, ind )
		{
			level = t;
			id = i;
			switch( level )
			{
				case ProfessionLevels.Apprentice:
					Current = 15;
					Max = 75;
					break;
				case ProfessionLevels.Journeyman:
					Max = 150;
					break;
				case ProfessionLevels.Expert:
					Max = 225;
					break;
				case ProfessionLevels.Artisan:
					Max = 300;
					break;
			}
		}
		#endregion

		#region SERIALISATION
		public override void Deserialize( GenericReader gr, int ind, bool fake )
		{
			base.Deserialize( gr, ind, true );
			int version = gr.ReadInt();
			id = gr.ReadInt();
			level = (ProfessionLevels)gr.ReadShort();			
		//	castingTime = gr.ReadInt();	
		//	coolDown = gr.ReadInt();	
		}
		public override void Serialize( GenericWriter gw )
		{
			base.Serialize( gw );
		//	gw.Write( Utility.ClassName( this ) );
			gw.Write( (int)0 );
			gw.Write( (int)id );
			gw.Write( (short)level );
		//	gw.Write( castingTime );
		//	gw.Write( coolDown );
		}
		#endregion

		public Profession Clone( ushort cur, ushort ind )
		{
			Profession p = new Profession( level, id, cur, ind );
			return p;
		}

		//public static int []slots = { 386, 389, 393, 396, 400, 403, 406, 410, 413, 416, 420 };
	//	public static int []slots = { (int)UpdateFields.PLAYER_SKILL_INFO_1_1, 390, 393, 396, 399, 402, 405, 408, 411, 414, 417, 420 };
		public static int Slots( int p )
		{
			return (int)UpdateFields.PLAYER_SKILL_INFO_1_1 + ( p * 3 );
		}
		// 386, 389
		#region ACCESSORS
		public override int CastingTime( Mobile from )
		{
			return castingTime;
		}

		public int SpellId
		{
			get { return id; }
		}

		public Professions ProfessionType
		{
			get
			{
				switch( id )
				{
					case 2108:
					case 3104:
					case 3811:
					case 10662:
						return Professions.LeatherWorker;
					case 2259:
					case 0xC1D:
					case 0xD88:
					case 0x2D5B:
						return Professions.Alchemist;
					case 2366:
					case 2368:
					case 3570:
					case 11993:
						return Professions.Herborist;
					case 2575:
					case 2576:
					case 3564:
					case 10248:
						return Professions.Miner;
					case 2550:
					case 3102:
					case 3413:
					case 18260:
						return Professions.Cooking;
					case 2018:
					case 3100:
					case 3538:
					case 9785:
						return Professions.Blacksmith;
					case 7620:
					case 7731:
					case 7732:
					case 18248:
						return Professions.Fishing;
					case 10846:
					case 7924:
					case 3273:
					case 3274:
						return Professions.FirstAid;
					case 7411:
					case 7412:
					case 7413:
					case 13920:
						return Professions.Enchanter;
					case 4036:
					case 4037:
					case 4038:
					case 12656:
						return Professions.Engineer;
					case 3908:
					case 3909:
					case 3910:
					case 12180:
						return Professions.Tailor;
					case 8613:
					case 8617:
					case 8618:
					case 10768:
						return Professions.Skinning;
				}
				return Professions.NoProf;
			}
		}/*
		public override ushort Index
		{
			get
			{
				switch( id )
				{
					case 2108:
					case 3104:
					case 3811:
					case 10662:
						return 403;//	LeatherWorking
					case 2259:
					case 0xC1D:
					case 0xD88:
					case 0x2D5B:
						return 400;//	Alchemy
					case 2366:
					case 2368:
					case 3570:
					case 11993:
						return 396;//	Herbalism
					case 2575:
					case 2576:
					case 3564:
					case 10248:
						return 386;//	Mining
					case 2550:
					case 3102:
					case 3413:
					case 18260:
						return 389;//	Cooking
					case 2018:
					case 3100:
					case 3538:
					case 9785:
						return 406;//	Blacksmithing, 393
					case 7620:
					case 7731:
					case 7732:
					case 18248:
						return 396;//	Fishing
					case 10846:
					case 7924:
					case 3273:
					case 3274:
						return 400;//	First Aid
					case 7411:
					case 7412:
					case 7413:
					case 13920:
						return 410;//	Enchanting
					case 4036:
					case 4037:
					case 4038:
					case 12656:
						return 416;//	Engienering
					case 3908:
					case 3909:
					case 3910:
					case 12180:
						return 420;//	Tailoring
					case 8613:
					case 8617:
					case 8618:
					case 10768:
						return 413;//	Skinning
				}
				return 0;
			}
		}*/
		public override ushort Id
		{
			get
			{
				switch( id )
				{
					case 2108:
					case 3104:
					case 3811:
					case 10662:
						return 0xA5;//	LeatherWorking
					case 2259:
					case 0xC1D:
					case 0xD88:
					case 0x2D5B:
						return 0xAB;//	Alchemy
					case 2366:
					case 2368:
					case 3570:
					case 11993:
						return 0xB6;//	Herborist
					case 2575:
					case 2576:
					case 3564:
					case 10248:
						return 186;//	Mining
					case 2550:
					case 3102:
					case 3413:
					case 18260:
						return 185;//	Cooking
					case 2018:
					case 3100:
					case 3538:
					case 9785:
						return 164;//	Blacksmithing
					case 7620:
					case 7731:
					case 7732:
					case 18248:
						return 356;//	Fishing
					case 10846:
					case 7924:
					case 3273:
					case 3274:
						return 129;//	First Aid
					case 7411:
					case 7412:
					case 7413:
					case 13920:
						return 333;//	Enchanting
					case 4036:
					case 4037:
					case 4038:
					case 12656:
						return 202;//	Engienering
					case 3908:
					case 3909:
					case 3910:
					case 12180:
						return 197;//	Tailoring
					case 8613:
					case 8617:
					case 8618:
					case 10768:
						return 393;//	Skinning
				}
				return 0;
			}
		}
		public ProfessionLevels Level
		{
			get { return level; }
		}
		#endregion

		public void OnLearn( Character c )
		{
			/*
			if ( level == ProfessionLevels.Apprentice )
			{
				if ( ProfessionType == Professions.Miner )
				{
					c.LearnSpell( 2580 );
					c.LearnSpell( 2577 );
					c.LearnSpell( 2657 );				
					c.LearnSpell( 2656 );
				}
				if ( ProfessionType == Professions.Herborist )
				{
					c.LearnSpell( 3570 );			
				}
				if ( ProfessionType == Professions.Blacksmith )
				{
					c.LearnSpell( 2738 );	//	copper axe		
					c.LearnSpell( 2739 );	//	copper sword		
					c.LearnSpell( 2737 );	//	copper Mace		
					c.LearnSpell( 3293 );	//	copper battle axe		
					c.LearnSpell( 3292 );	//	copper heavy Broadsword		
				}
				if ( ProfessionType == Professions.LeatherWorker )
				{
					c.LearnSpell( 9060 );
					c.LearnSpell( 2168 );
					c.LearnSpell( 2166 );
					c.LearnSpell( 2167 );
					c.LearnSpell( 2153 );
					c.LearnSpell( 2160 );
					c.LearnSpell( 2159 );
					c.LearnSpell( 9065 );
					c.LearnSpell( 9068 );
					c.LearnSpell( 3753 );
					c.LearnSpell( 3816 );
					c.LearnSpell( 2161 );
				}
			}*/
		}
		public static void OnFindMineral( BaseAbility ba, Mobile c )
		{
			AuraEffect st = (AuraEffect)ba;
			Aura aura = new Aura( EffectTypes.FindMineral );
			c.CumulativeAuraEffects[ EffectTypes.FindMineral ] = true;
			c.AddAura( st, aura );	
			c.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_TRACK_RESOURCES }, new object[] { 4 } );		
		}	
		public void UseHerbalist(Mobile.Casting cast, Character c, GameObject go )
		{
			Hashtable diff = new Hashtable();
			diff[ 29 ] = 0;
			diff[ 8 ] = 20;
			diff[ 9 ] = 50;
			diff[ 10 ] = 75;
			diff[ 11 ] = 100;
			diff[ 26 ] = 125;
			diff[ 27 ] = 150;
			diff[ 35 ] = 140;
			diff[ 45 ] = 125;
			diff[ 47 ] = 160;
			diff[ 48 ] = 215;
			diff[ 49 ] = 185;
			diff[ 50 ] = 205;
			diff[ 51 ] = 195;
			int rdiff = CurrentVal(c) - (int)diff[ (int)go.Sound[ 0 ] ];
			int res = IqSkillCheck( c, rdiff );
			
			if ( res > 50 )
			{
				if ( Current < Cap( c ) && c.SkillUp( Current, rdiff, 1 ) )
				{
					Current++;
					c.SendSkillUpdate();
					//c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)CurrentVal(c), (short)Cap( c ), (int)0 } );
				}
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				string str = "Reussite : " + reussite.ToString();
				c.SendMessage( str );
				if ( !go.CheckLoot( c, reussite ) )
					c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
			else
			{
				//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}

		public void UseFishing(Mobile.Casting cast, Character c )
		{
			GameObject desc = c.InsideFishingZone();
			if ( desc == null )
			{
				c.SpellFaillure( SpellFailedReason.TheyArentAnyFishHere );
				return;				
			}
			int rdiff = CurrentVal(c);
			int res = AgiSkillCheck( c, rdiff );
			if ( res > 50 )
			{
				if ( Current < Cap( c ) && c.SkillUp( Current, rdiff, 1 ) )
				{
					Current++;
					c.SendSkillUpdate();
				}
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				string str = "Reussite : " + reussite.ToString();
				c.SendMessage( str );
				if(	!desc.CheckLoot( c, reussite ) )
					c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
			else
			{
				//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}

		public void UseMining(Mobile.Casting cast, Character c, GameObject go )
		{
			Hashtable diff = new Hashtable();
			diff[ 18 ] = 25;
			diff[ 19 ] = 50;
			diff[ 20 ] = 75;
			diff[ 21 ] = 100;
			diff[ 22 ] = 125;
			diff[ 25 ] = 150;
			diff[ 38 ] = 0;//	Copper
			diff[ 39 ] = 50;// Tin
			diff[ 40 ] = 100;//	Silver
			diff[ 41 ] = 150;// Iron
			diff[ 42 ] = 200;//	Gold
			int rdiff = CurrentVal(c) - (int)diff[ (int)go.Sound[ 0 ] ];
			int res = StrSkillCheck( c, rdiff );

			if ( res > 50 )
			{
				if ( Current < Cap( c ) && c.SkillUp( Current, rdiff, 1 ) )
				{
					Current++;
					c.SendSkillUpdate();
				}
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
			//	string str = "Reussite : " + reussite.ToString();
			//	c.SendMessage( str );
				if(	!go.CheckLoot( c, reussite ) )
					c.SpellFaillure( SpellFailedReason.FailedAttempt );
				
			}
			else
			{
			//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}
		public void UseSkinning( Mobile.Casting cast, Character c, Mobile go )
		{
			c.cast = cast;
			int rdiff = CurrentVal(c) - 1;
			int res = StrSkillCheck( c, rdiff );

			if ( res > 50 && !go.Skinned )
			{
				//c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				ArrayList loot = new ArrayList();
				c.LootOwner = go.Guid;				
				if ( go.SkinLoot != null )
				{					

					ArrayList sl = new ArrayList();
					foreach( Loot l in go.SkinLoot )
					{
						if ( Utility.RandomDouble() * 100 < l.Probability )
						{					
							int n = (int)( reussite * l.Probability );
							sl.Add( l.Create( 1 ) );
						}
					}
					if ( sl.Count == 0 )
					{
						c.SpellFaillure( SpellFailedReason.FailedAttempt );
						return;
					}
					go.Skinned = true;
					if ( Current < Cap( c ) && c.SkillUp( Current, rdiff, 1 ) )
					{
						Current++;
						c.SendSkillUpdate();
					}
					c.SpellSuccess();
					c.previousSpellCasted = cast.id;
					
					go.Treasure = (Item[])sl.ToArray( typeof( Item ) );
					c.SendLootDetails( go.Guid, go, 0 );
					go.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS, (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { go.DynFlags( c ), go.Flags } );
				}
				else
					c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
			else
			{
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
				go.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS, (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { go.DynFlags( c ), go.Flags } );
			}
		}
	/*	public void UseLeatherworking( Character c, GameObject go )
		{
			int rdiff = Current - 1;
			int res = StrSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				go.CheckLoot( c, reussite );
			}
			else
			{
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}
		public void UseTailoring( Character c, GameObject go )
		{
			Hashtable diff = new Hashtable();
			diff[ 29 ] = 0;
			diff[ 8 ] = 20;
			diff[ 9 ] = 50;
			diff[ 10 ] = 75;
			diff[ 11 ] = 100;
			diff[ 26 ] = 125;
			diff[ 27 ] = 150;
			diff[ 35 ] = 140;
			diff[ 45 ] = 125;
			diff[ 47 ] = 160;
			diff[ 48 ] = 215;
			diff[ 49 ] = 185;
			diff[ 50 ] = 205;
			diff[ 51 ] = 195;
			int rdiff = Current - (int)diff[ (int)go.Sound[ 0 ] ];
			int res = IqSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				string str = "Reussite : " + reussite.ToString();
				c.SendMessage( str );
				go.CheckLoot( c, reussite );
			}
			else
			{
				//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}

		public void UseFirstAid( Character c )
		{
			GameObject desc = c.InsideFishingZone();
			if ( desc == null )
			{
				c.SpellFaillure( SpellFailedReason.TheyArentAnyFishHere );
				return;				
			}

			int rdiff = Current;
			int res = AgiSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				string str = "Reussite : " + reussite.ToString();
				c.SendMessage( str );
				desc.CheckLoot( c, reussite );
			}
			else
			{
				//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}

		public void UseEnginering( Character c, GameObject go )
		{
			Hashtable diff = new Hashtable();
			diff[ 18 ] = 25;
			diff[ 19 ] = 50;
			diff[ 20 ] = 75;
			diff[ 21 ] = 100;
			diff[ 22 ] = 125;
			diff[ 25 ] = 150;
			diff[ 38 ] = 0;//	Copper
			diff[ 39 ] = 50;// Tin
			diff[ 40 ] = 100;//	Silver
			diff[ 41 ] = 150;// Iron
			diff[ 42 ] = 200;//	Gold
			int rdiff = Current - (int)diff[ (int)go.Sound[ 0 ] ];
			int res = StrSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				//	string str = "Reussite : " + reussite.ToString();
				//	c.SendMessage( str );

				go.CheckLoot( c, reussite );
			}
			else
			{
				//	Console.WriteLine("SPELL RESULT :{0}", result );
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}
		public void UseEnchanting( Character c, GameObject go )
		{
			int rdiff = Current - 1;
			int res = StrSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				go.CheckLoot( c, reussite );
			}
			else
			{
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}
		public void UseCooking( Character c, GameObject go )
		{
			int rdiff = Current - 1;
			int res = StrSkillCheck( c, rdiff );
			if ( Current < Max && c.SkillUp( Current, rdiff, 5 ) )
			{
				Current++;
				c.SendSmallUpdate( new int[]{ Index, Index + 1, Index + 2 }, new object[]{ (int)Id, (short)Current, (short)Max, (int)0 } );
			}
			if ( res > 50 )
			{
				c.SpellSuccess();
				float reussite = (float)res;

				reussite = reussite / 10f;
				go.CheckLoot( c, reussite );
			}
			else
			{
				c.SpellFaillure( SpellFailedReason.FailedAttempt );
			}
		}*/
	}
}
