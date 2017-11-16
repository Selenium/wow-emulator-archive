using System;
using Server.Items;
using HelperTools;




namespace Server.Creatures
{
	public class AgeronKargal : BaseCreature
	{
		public AgeronKargal() : base()
		{
			Name = "Ageron Kargal";
			Id = 5724;
			Model = 4107;
			Level = RandomLevel(15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Horde;
			AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 5010, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AgeronKargal, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class AlexiBarov: BaseCreature 
	 { 
		public  AlexiBarov() : base() 
		 { 
			Id = 11022 ; 
			Model = 10456;
			AttackSpeed= 1600;
			BoundingRadius = 0.5500000f ;
			Name = "Alexi Barov" ;
			Guild="House of Barov";
			Flags1 = 0x080000;			
			Size = 1.5f;
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

float step=1.2f; //step by incrase Heals in elite mobs first rang
if (Level==60)		
{
 BaseHitPoints = 5262;
} 
else
{
for (int i=1; i<=(Level-60); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(5262*(float)step);
} 
			NpcFlags = (int)NpcActions.Dialog;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Horde;
			Elite = 1;
			AIEngine = new StandingNpcAI( this );
			Equip( new Item( 6454, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AlexiBarov, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}	
}




namespace Server.Creatures
{
	public class AlyssaBlaye : BaseCreature
	{
		public AlyssaBlaye() : base()
		{
			Name = "Alyssa Blaye";
			Id = 5665;
			Model = 3883;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x010480006;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Horde;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AlyssaBlaye, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndrewBrownell : BaseCreature
	{
		public AndrewBrownell() : base()
		{
			Name = "Andrew Brownell";
			Id = 2308;
			Model = 1585;
			Level = RandomLevel(40);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x010480006;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 2469, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AndrewBrownell, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndrewHartwell : BaseCreature
	{
		public AndrewHartwell() : base()
		{
			Name = "Andrew Hartwell";
			Id = 5659;
			Model = 3859;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x010480006;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 7483, InventoryTypes.TwoHanded, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AndrewHartwell, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndronGant : BaseCreature
	{
		public AndronGant() : base()
		{
			Name = "Andron Gant";
			Id = 6522;
			Model = 3859;
			Level = RandomLevel(15);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x018480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.02f;
			WalkSpeed = 3.02f;
			RunSpeed = 6.02f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 6443, InventoryTypes.TwoHanded, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.AndronGant, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryFalthis: BaseCreature 
	 { 
		public  ApothecaryFalthis() : base() 
		 { 
			Id = 3735 ; 
			Model = 4156;
			AttackSpeed= 1500;
			BoundingRadius = 0.5500000f ;
			Name = "Apothecary Falthis" ;
			Flags1 = 0;			
			Size = 1.5f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 25 );
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Undead;
			Armor= Level*40;

float step=1.5f; //step by incrase Heals in elite mobs first rang
if (Level==25)		
{
 BaseHitPoints = 2262;
} 
else
{
for (int i=1; i<=(Level-25); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(2262*(float)step);
} 
			NpcFlags = 0;
			CombatReach = 16f ;
			SetDamage(1f+1.8f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 4;
			AIEngine = new StandingNpcAI( this );
			//Equip( new HandcraftedStaff());
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryFalthis, 100f ),
							new BaseTreasure(DropsME.MoneyRare, 100f )}; 
		}
	}	
}



namespace Server.Creatures
{
	public class ApothecaryHelbrim : BaseCreature
	{
		public ApothecaryHelbrim() : base()
		{
			Name = "Apothecary Helbrim";
			Id = 3390;
			Model = 1965;
			Level = RandomLevel(22);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.02f;
			WalkSpeed = 3.02f;
			RunSpeed = 6.02f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6533, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryHelbrim, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ApothecaryJohaan : BaseNPC
	{
		public ApothecaryJohaan() : base()
		{
			Name = "Apothecary Johaan";
			Guild="Royal Apothecary Society";
			Id = 1518;
			Model = 1965;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryJohaan, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ApothecaryJorell : BaseCreature
	{
		public ApothecaryJorell() : base()
		{
			Name = "Apothecary Jorell";
			Id = 2733;
			Model = 4040;
			Level = RandomLevel(36);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.19f;
			WalkSpeed = 3.19f;
			RunSpeed = 6.19f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Horde;
AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryJorell, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ApothecaryLydon : BaseCreature
	{
		public ApothecaryLydon() : base()
		{
			Name = "Apothecary Lydon";
			Guild="Royal Apothecary Society";
			Id = 2216;
			Model = 1660;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6535, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryLydon, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryBerard: BaseCreature 
	 { 
		public  ApothecaryBerard() : base() 
		 { 
			Id = 2106 ; 
			Model = 574;
			AttackSpeed= 2000;
			BoundingRadius = 0.90f ;
			Name = "Apothecary Berard" ;
			//Guild="Overseer of Sul";
			Flags1 = 0x080000;			
			Size = 1.15f;
			Speed = 3.54f ;
			WalkSpeed = 3.54f ;
			RunSpeed = 6.54f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 16 );
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Undead;
			Armor= Level*30;

float step=1.2f; //step by incrase Heals in elite mobs first rang
if (Level==16)		
{
 BaseHitPoints = 1167;
} 
else
{
for (int i=1; i<=(Level-16); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(1167*(float)step);
} 
			NpcFlags = 0;
			CombatReach = 1.75f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 1;
			AIEngine = new AgressiveAnimalAI( this );
			//Equip( new Item( 18583, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryBerard, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
	}	
}



namespace Server.Creatures
{
	public class ApothecaryKatrina : BaseCreature
	{
		public ApothecaryKatrina() : base()
		{
			Name = "Apothecary Katrina";
			Guild="Royal Apothecary Society";
			Id = 5732;
			Model = 4109;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x018480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 6454, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryKatrina, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryKeever : BaseCreature
	{
		public ApothecaryKeever() : base()
		{
			Name = "Apothecary Keever";
			Guild="Royal Apothecary Society";
			Id = 5734;
			Model = 4111;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x018480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 7465, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryKeever, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ApothecaryLycanus : BaseCreature
	{
		public ApothecaryLycanus() : base()
		{
			Name = "Apothecary Lycanus";
			Guild="Royal Apothecary Society";
			Id = 5733;
			Model = 4110;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x018480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 23321, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryLycanus, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryRenferrel : BaseCreature
	{
		public ApothecaryRenferrel() : base()
		{
			Name = "Apothecary Renferrel";
			Guild="Royal Apothecary Society";
			Id = 1937;
			Model = 1661;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7466, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryRenferrel, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryVallia : BaseCreature
	{
		public ApothecaryVallia() : base()
		{
			Name = "Apothecary Vallia";
			Guild="Royal Apothecary Society";
			Id = 5731;
			Model = 4108;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x018480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = 0;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ), new Item( 21095, InventoryTypes.RangeRight, 2, 19, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryVallia, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class ApothecaryZamah : BaseCreature
	{
		public ApothecaryZamah() : base()
		{
			Name = "Apothecary Zamah";
			Guild="Royal Apothecary Society";
			Id = 3419;
			Model = 1814;
			Level = RandomLevel(22);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
AIEngine = new PatrolAI( this ); 
else 
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7474, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryZamah, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ApothecaryZinge : BaseCreature
	{
		public ApothecaryZinge() : base()
		{
			Name = "Apothecary Zinge";
			Guild="Royal Apothecary Society";
			Id = 5204;
			Model = 4056;
			Level = RandomLevel(29);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.31000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.06f;
			WalkSpeed = 3.06f;
			RunSpeed = 6.06f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
AIEngine = new StandingNpcAI( this );
			NpcType = (int)NpcTypes.Undead;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 21251, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherUndeadDrops.ApothecaryZinge, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}

