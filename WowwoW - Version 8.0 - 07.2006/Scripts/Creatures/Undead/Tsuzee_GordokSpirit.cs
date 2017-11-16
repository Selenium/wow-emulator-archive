using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class Tsuzee: BaseCreature 
	 { 
		public  Tsuzee() : base() 
		 { 
			Id = 11467 ; 
			Model = 11250;
			AttackSpeed= 1600;
			BoundingRadius = 0.5500000f ;
			Name = "Tsu'zee" ;
			Size = 1.0f;
			Speed = 4.05f ;
			WalkSpeed = 4.05f ;
			RunSpeed = 7.05f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 59 );
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Undead;
			Armor= Level*30;
			NpcFlags = 0;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 1;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 5262, 59 );
			Loots = new BaseTreasure[]{  new BaseTreasure( HighNoCategoryDrops.HighNoCategory, 100f ),
							new BaseTreasure( HighClothsDrops.HighCloths, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}	
}




namespace Server.Creatures
{
	public class GordokSpirit: BaseCreature 
	 { 
		public  GordokSpirit() : base() 
		 { 
			Id = 11446 ; 
			Model = 13093;
			AttackSpeed= 1600;
			BoundingRadius = 0.5500000f ;
			Name = "Gordok Spirit" ;
			Size = 1.0f;
			Speed = 4.05f ;
			WalkSpeed = 4.05f ;
			RunSpeed = 7.05f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 60 );
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Undead;
			Armor= Level*30;
			NpcFlags = 0;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Visible = InvisibilityLevel.Lesser;
			Faction = Factions.Alliance;
			Elite = 1;
			AIEngine = new AgressiveAnimalAI( this );
			BCAddon.Hp( this, 6262, 60 );
			Loots = new BaseTreasure[]{  new BaseTreasure( HighNoCategoryDrops.HighNoCategory, 100f ),
							new BaseTreasure( HighClothsDrops.HighCloths, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}	
}