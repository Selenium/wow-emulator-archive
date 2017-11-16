using System;
using System.Reflection;
using HelperTools;

namespace Server
{
	/// <summary>
	/// Summary description for Skill.
	/// </summary>
	public class Skill : BaseAbility
	{
		//ushort id;
		ushort current;
		ushort max;
		ushort index;
		//ushort spell;


		#region CONSTRUCTORS
		public Skill()
		{
		}
		public Skill( int min, int m )
		{
			current = (ushort)min;
			max = (ushort)m;
		}

		public Skill( ushort min, ushort ind )//	Pour les professions
		{
			current = min;
			index = ind;
		}
		#endregion

		#region SERIALISATION
		public static Skill Deserialize( GenericReader gr, int ind )
		{
			string cl = gr.ReadString();
			if ( cl == "TwoHandedSkill" )
				cl = "TwoHandedSwordSkill";
			ConstructorInfo ct = Utility.FindConstructor( cl );
			Skill s = (Skill)ct.Invoke( null );
			s.Deserialize( gr, ind, true );
			return s;
		}
		public virtual void Deserialize( GenericReader gr, int ind, bool fake )
		{
			int version = gr.ReadInt();
			index = (ushort)ind;
			current = (ushort)gr.ReadShort();
			max = (ushort)gr.ReadShort();
		}
		public virtual void Serialize( GenericWriter gw )
		{
			gw.Write( Utility.ClassName( this ) );
			gw.Write( (int)0 );
			gw.Write( (ushort)current );
			gw.Write( (ushort)max );
		}
		#endregion

		#region ACCESSORS
		public override ushort Id
		{
			get { return 0; }
		}
		public virtual ushort SpellId
		{
			get { return 0; }
		}
		public ushort Current
		{
			get { return current;}
			set { current = value; }
		}
		public ushort CurrentBonus(Mobile from)
		{
			int val = 0;
			foreach( Mobile.AuraReleaseTimer art in from.Auras )
			{
				if(art.aura.SkillId == this.Id)
					val += art.aura.SkillBonus - art.aura.SkillMalus;
			}
			foreach( PermanentAura art in from.PermanentAuras )
			{
				if(art.aura.SkillId == this.Id)
					val += art.aura.SkillBonus - art.aura.SkillMalus;
			}
			return (ushort)val;
		}
		public ushort CurrentVal(Mobile from)
		{
			int val = 0;
			foreach( Mobile.AuraReleaseTimer art in from.Auras )
			{
				if(art.aura.SkillId == this.Id)
					val += art.aura.SkillBonus - art.aura.SkillMalus;
			}
			foreach( PermanentAura art in from.PermanentAuras )
			{
				if(art.aura.SkillId == this.Id)
					val += art.aura.SkillBonus - art.aura.SkillMalus;
			}
			switch (from.Classe)
			{
				case Classes.Warrior:
					if (this.Id == DefenseSkill.SkillId)
					{
						if (from.HaveTalent(Talents.Anticipation))
						{
							AuraEffect af = (AuraEffect)from.GetTalentEffect(Talents.Anticipation);
							val +=af.S1;
						}
					}
					break;
			}
			if ((current + val)< 0) return 0;
			return (ushort)(current + val);
		}
		public ushort Cap(Mobile from)
		{
			if ( max == 0xffff )
				return (ushort)( from.Level * 5 );
			return max;
		}
		public ushort Max
		{
			set { max = value; }
		}
		public virtual ushort Index
		{
			get { return index; }
		}
		public override int CastingTime( Mobile from )
		{
			return 0;
		}

		#endregion

		public int StrSkillCheck( Mobile m, int diff )
		{
			if ( m.StatUp( m.Str, diff, 1 ) )
				m.Str++;			
			int roll = Utility.Random( 100 );
			if ( roll > 95 )
			{
				roll += Utility.Random( 100 );
				if ( roll > 95 )
					roll += Utility.Random( 100 );
			}
			else
				if ( roll < 5 )
					roll -= Utility.Random( 100 );

			roll += ( m.Str - 30 ) / 10;
			roll += diff;
			return roll;
		}

		public int IqSkillCheck( Mobile m, int diff )
		{
			if ( m.StatUp( m.Str, diff, 1 ) )
				m.Iq++;			
			int roll = Utility.Random( 100 );
			if ( roll > 95 )
			{
				roll += Utility.Random( 100 );
				if ( roll > 95 )
					roll += Utility.Random( 100 );
			}
			else
				if ( roll < 5 )
				roll -= Utility.Random( 100 );

			roll += ( m.Iq - 30 ) / 10;
			roll += diff;
			return roll;
		}

		public int AgiSkillCheck( Mobile m, int diff )
		{
			if ( m.StatUp( m.Agility, diff, 1 ) )
				m.Agility++;			
			int roll = Utility.Random( 100 );
			if ( roll > 95 )
			{
				roll += Utility.Random( 100 );
				if ( roll > 95 )
					roll += Utility.Random( 100 );
			}
			else
				if ( roll < 5 )
				roll -= Utility.Random( 100 );

			roll += ( m.Agility - 30 ) / 10;
			roll += diff;
			return roll;
		}
		public int SpiritSkillCheck( Mobile m, int diff )
		{
			if ( m.StatUp( m.Spirit, diff, 1 ) )
				m.Spirit++;			
			int roll = Utility.Random( 100 );
			if ( roll > 95 )
			{
				roll += Utility.Random( 100 );
				if ( roll > 95 )
					roll += Utility.Random( 100 );
			}
			else
				if ( roll < 5 )
				roll -= Utility.Random( 100 );

			roll += ( m.Spirit - 30 ) / 10;
			roll += diff;
			return roll;
		}
		
	}
/*
	public class LeatherWorking : Skill
	{
		public LeatherWorking(){}
		public LeatherWorking( int current, int max ) : base ( current, max )	{}
		public override ushort Id
		{ get { return 0xA5; } }
		public override ushort SpellId
		{ get { return 196; } }
	}*/

	public class ShieldSkill : Skill
	{
		public ShieldSkill( )
		{
		}
		public ShieldSkill( int current, int max ) : base ( 1, 1 ) 
		{
		}
		public static int SkillId
		{
			get { return 433; }
		}
		public override ushort Id
		{ get { return 433; } }
		public override ushort SpellId
		{ get { return 9116; } }
	}
	public class ClothSkill : Skill
	{
		public ClothSkill()
		{
		}
		public ClothSkill( int current, int max ) : base ( 1, 1 ) 
		{
		}
		public static int SkillId
		{
			get { return 415; }
		}
		public override ushort Id
		{ get { return 415; } }
		public override ushort SpellId
		{ get { return 9078; } }
	}
	public class LeatherSkill : Skill
	{
		public LeatherSkill( )
		{
		}
		public LeatherSkill( int current, int max ) : base ( 1, 1 ) 
		{
		}
		public static int SkillId
		{
			get { return 414; }
		}
		public override ushort Id
		{ get { return 414; } }
		public override ushort SpellId
		{ get { return 9077; } }
	}
	public class MailSkill : Skill
	{
		public MailSkill() {}
		public MailSkill( int current, int max ) : base ( 1, 1 ) 
		{
		}
		public static int SkillId
		{
			get { return 413; }
		}
		public override ushort Id
		{ get { return 413; } }
		public override ushort SpellId
		{ get { return 8737; } }
	}
	public class PlateMailSkill : Skill
	{
		public PlateMailSkill() {}
		public PlateMailSkill( int current, int max ) : base ( 1, 1 ) 
		{
		}
		public static int SkillId
		{
			get { return 293; }
		}
		public override ushort Id
		{ get { return 293; } }
		public override ushort SpellId
		{ get { return 750; } }
	}
	public class DefenseSkill : Skill
	{
		public DefenseSkill() {}
		public DefenseSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 95; } }
		public static int SkillId
		{
			get { return 95; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#region LANGUAGES
	public class CommonSkill : Skill
	{
		public CommonSkill() {}
		public CommonSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 98; } }
		public static int SkillId
		{
			get { return 98; }
		}
		public override ushort SpellId
		{ get { return 668; } }
	}
	public class GnomishSkill : Skill
	{
		public GnomishSkill() {}
		public GnomishSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 313; } }
		public static int SkillId
		{
			get { return 313; }
		}
		public override ushort SpellId
		{ get { return 7340; } }
	}
	public class OrcishSkill : Skill
	{
		public OrcishSkill() {}
		public OrcishSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 109; } }
		public static int SkillId
		{
			get { return 109; }
		}
		public override ushort SpellId
		{ get { return 669; } }
	}
	public class DwarvenSkill : Skill
	{
		public DwarvenSkill() {}
		public DwarvenSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 111; } }
		public static int SkillId
		{
			get { return 111; }
		}
		public override ushort SpellId
		{ get { return 672; } }
	}
	public class GutterspeakSkill : Skill
	{
		public GutterspeakSkill() {}
		public GutterspeakSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 673; } }
		public static int SkillId
		{
			get { return 673; }
		}
		public override ushort SpellId
		{ get { return 17737; } }
	}
	public class DarnassianSkill : Skill
	{
		public DarnassianSkill() {}
		public DarnassianSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 113; } }
		public static int SkillId
		{
			get { return 113; }
		}
		public override ushort SpellId
		{ get { return 671; } }
	}
	public class TauraneSkill : Skill
	{
		public TauraneSkill() {}
		public TauraneSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 115; } }
		public static int SkillId
		{
			get { return 115; }
		}
		public override ushort SpellId
		{ get { return 670; } }
	}
	public class TrollishSkill : Skill
	{
		public TrollishSkill() {}
		public TrollishSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 315; } }
		public static int SkillId
		{
			get { return 315; }
		}
		public override ushort SpellId
		{ get { return 7341; } }
	}
#endregion
	#region WEAPON SKILLS
	public class UnarmedSkill : Skill
	{
		public UnarmedSkill() {}
		public UnarmedSkill( int current, int max ) : base ( current, 0xffff ) 
		{
		}
		public static int SkillId
		{
			get { return 162; }
		}
		public override ushort Id
		{ get { return 162; } }
		public override ushort SpellId
		{ get { return 203; } }
	}
	public class AxeSkill : Skill
	{
		public AxeSkill(){}
		public AxeSkill( int current, int max ) : base ( current, 0xffff )	{}
		public override ushort Id
		{ get { return 44; } }
		public static int SkillId
		{
			get { return 44; }
		}
		public override ushort SpellId
		{ get { return 196; } }
	}
	public class SwordSkill : Skill
	{
		public SwordSkill()
		{
		}
		public SwordSkill( int current, int max ) : base ( current, 0xffff ) 
		{
		}
		public override ushort Id
		{ get { return 43; } }
		public static int SkillId
		{
			get { return 43; }
		}
		public override ushort SpellId
		{ get { return 201; } }
	}
	public class DaggerSkill : Skill
	{
		public DaggerSkill( ){}
		public DaggerSkill( int current, int max ) : base ( current, 0xffff ) 	{		}
		public override ushort Id
		{ get { return 173; } }
		public static int SkillId
		{
			get { return 173; }
		}
		public override ushort SpellId
		{ get { return 1180; } }
	}
	public class GunSkill : Skill
	{
		public GunSkill( ){}
		public GunSkill( int current, int max ) : base ( current, 0xffff ) 	{		}
		public override ushort Id
		{ get { return 46; } }
		public static int SkillId
		{
			get { return 46; }
		}
		public override ushort SpellId
		{ get { return 266; } }
	}
	public class MacesSkill : Skill
	{
		public MacesSkill() {}
		public MacesSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 54; } }
		public static int SkillId
		{
			get { return 54; }
		}
		public override ushort SpellId
		{ get { return 198; } }
	}

	public class WandsSkill : Skill
	{
		public WandsSkill() {}
		public WandsSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 228; } }
		public static int SkillId
		{
			get { return 228; }
		}
		public override ushort SpellId
		{ get { return 5009; } }
	}
	public class TwoHandedSwordSkill : Skill
	{
		public TwoHandedSwordSkill() {}
		public TwoHandedSwordSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 55; } }
		public static int SkillId
		{
			get { return 55; }
		}
		public override ushort SpellId
		{ get { return 202; } }
	}
	public class TwoHandedMaceSkill : Skill
	{
		public TwoHandedMaceSkill() {}
		public TwoHandedMaceSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 160; } }
		public static int SkillId
		{
			get { return 160; }
		}
		public override ushort SpellId
		{ get { return 199; } }
	}
	public class TwoHandedAxeSkill : Skill
	{
		public TwoHandedAxeSkill() {}
		public TwoHandedAxeSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 172; } }
		public static int SkillId
		{
			get { return 172; }
		}
		public override ushort SpellId
		{ get { return 197; } }
	}
	public class ThrowsSkill : Skill
	{
		public ThrowsSkill() {}
		public ThrowsSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 176; } }
		public static int SkillId
		{
			get { return 176; }
		}
		public override ushort SpellId
		{ get { return 2567; } }
	}
	public class BowsSkill : Skill
	{
		public BowsSkill() {}
		public BowsSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 45; } }
		public static int SkillId
		{
			get { return 45; }
		}
		public override ushort SpellId
		{ get { return 264; } }
	}
	public class StavesSkill : Skill
	{
		public StavesSkill() {}
		public StavesSkill( int current, int max ) : base ( current, 0xffff ) {}
		public override ushort Id
		{ get { return 136; } }
		public static int SkillId
		{
			get { return 136; }
		}
		public override ushort SpellId
		{ get { return 227; } }
	}
	
#endregion
	#region WARRIOR SKILL
	public class Fury : Skill
	{
		public Fury() {}
		public Fury( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 256; } }
		public static int SkillId
		{
			get { return 256; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Protection : Skill
	{
		public Protection() {}
		public Protection( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 257; } }
		public static int SkillId
		{
			get { return 257; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Arms : Skill
	{
		public Arms() {}
		public Arms( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x1A; } }
		public static int SkillId
		{
			get { return 0x1A; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
#endregion
	#region WARLOCK SKILLS
	public class Destruction : Skill
	{
		public Destruction() {}
		public Destruction( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x251; } }
		public static int SkillId
		{
			get { return 0x251; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Demonology : Skill
	{
		public Demonology() {}
		public Demonology( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x162; } }
		public static int SkillId
		{
			get { return 0x162; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Affliction : Skill
	{
		public Affliction() {}
		public Affliction( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 355; } }
		public static int SkillId
		{
			get { return 355; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region PRIEST SKILLS
	public class Shadow : Skill
	{
		public Shadow() {}
		public Shadow( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x4E; } }
		public static int SkillId
		{
			get { return 0x4E; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	
	public class Holy : Skill
	{
		public Holy() {}
		public Holy( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x38; } }
		public static int SkillId
		{
			get { return 0x38; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Dicipline : Skill
	{
		public Dicipline() {}
		public Dicipline( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x265; } }
		public static int SkillId
		{
			get { return 0x265; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region MAGE SKILLS
	public class ArcaneSkill : Skill
	{
		public ArcaneSkill() {}
		public ArcaneSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 237; } }
		public static int SkillId
		{
			get { return 237; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class FireSkill : Skill
	{
		public FireSkill() {}
		public FireSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 8; } }
		public static int SkillId
		{
			get { return 8; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}	
	public class FrostSkill : Skill
	{
		public FrostSkill() {}
		public FrostSkill( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 6; } }
		public static int SkillId
		{
			get { return 6; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region DRUID SKILLS
	public class Restoration : Skill
	{
		public Restoration() {}
		public Restoration( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 573; } }
		public static int SkillId
		{
			get { return 573; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Balance : Skill
	{
		public Balance() {}
		public Balance( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 574; } }
		public static int SkillId
		{
			get { return 574; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}	
	public class FeralCombat : Skill
	{
		public FeralCombat() {}
		public FeralCombat( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 134; } }
		public static int SkillId
		{
			get { return 134; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region HUNTER SKILLS
	public class BeastMastery : Skill
	{
		public BeastMastery() {}
		public BeastMastery( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 50; } }
		public static int SkillId
		{
			get { return 50; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Marksmanship : Skill
	{
		public Marksmanship() {}
		public Marksmanship( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 163; } }
		public static int SkillId
		{
			get { return 163; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}	
	public class Survival : Skill
	{
		public Survival() {}
		public Survival( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 51; } }
		public static int SkillId
		{
			get { return 51; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region ROGUE SKILLS
	public class Assassination : Skill
	{
		public Assassination() {}
		public Assassination( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 253; } }
		public static int SkillId
		{
			get { return 253; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Poisons : Skill
	{
		public Poisons() {}
		public Poisons( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 163; } }
		public static int SkillId
		{
			get { return 163; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}	
	public class Subtlety : Skill
	{
		public Subtlety() {}
		public Subtlety( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 39; } }
		public static int SkillId
		{
			get { return 39; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Combat : Skill
	{
		public Combat() {}
		public Combat( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 38; } }
		public static int SkillId
		{
			get { return 38; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	
	#endregion
	#region PALADIN SKILLS
/*	public class Protection : Skill
	{
		public Protection() {}
		public Protection( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 257; } }
		public static int SkillId
		{
			get { return 257; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Holy : Skill
	{
		public Holy() {}
		public Holy( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 0x38; } }
		public static int SkillId
		{
			get { return 0x38; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}*/
	public class Retribution : Skill
	{
		public Retribution() {}
		public Retribution( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 184; } }
		public static int SkillId
		{
			get { return 184; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
	#region SHAMAN SKILLS
	public class ShamanRestoration : Skill
	{
		public ShamanRestoration() {}
		public ShamanRestoration( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 374; } }
		public static int SkillId
		{
			get { return 374; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	public class Enhancement : Skill
	{
		public Enhancement() {}
		public Enhancement( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 373; } }
		public static int SkillId
		{
			get { return 373; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}	
	public class ElementalCombat : Skill
	{
		public ElementalCombat() {}
		public ElementalCombat( int current, int max ) : base ( current, max ) {}
		public override ushort Id
		{ get { return 375; } }
		public static int SkillId
		{
			get { return 375; }
		}
		public override ushort SpellId
		{ get { return 0; } }
	}
	#endregion
}
