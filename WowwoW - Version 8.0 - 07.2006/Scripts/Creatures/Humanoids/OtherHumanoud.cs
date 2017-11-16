using System;
using Server.Items;
using HelperTools;
using Server.Quests;

namespace Server.Creatures
{
	public class AuntieBerniceStonefield : BaseNPC
	{
		public AuntieBerniceStonefield() : base()
		{
			Name = "\"Auntie\" Bernice Stonefield";
			Id = 246;
			Model = 3329;
			Level = RandomLevel(6);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseHitPoints = 76;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AuntieBerniceStonefield, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
			//Quests = new BaseQuest[] { new Lost_Necklace(), new Back_To_Billy() };
		}
	}
}




namespace Server.Creatures
{
	public class PrettyBoyDuncan : BaseCreature
	{
		public PrettyBoyDuncan() : base()
		{
			Name = "\"Pretty Boy\" Duncan";
			Id = 2545;
			Model = 4641;
			Level = RandomLevel(39);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseHitPoints = 1819;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.BloodsailBuccaneers;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.PrettyBoyDuncan, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class SeaWolfMacKinley : BaseCreature
	{
		public SeaWolfMacKinley() : base()
		{
			Name = "\"Sea Wolf\" MacKinley";
			Id = 2501;
			Model = 1925;
			Level = RandomLevel(44);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080046;
			BaseHitPoints = 1819;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7433, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.SeaWolfMacKinley, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class ShakyPhillipe : BaseCreature
	{
		public ShakyPhillipe() : base()
		{
			Name = "\"Shaky\" Phillipe";
			Id = 2502;
			Model = 1929;
			Level = RandomLevel(44);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080046;
			BaseHitPoints = 1819;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7459, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.ShakyPhillipe, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}






namespace Server.Creatures
{
	public class StinkyIgnatz : BaseCreature
	{
		public StinkyIgnatz() : base()
		{
			Name = "\"Stinky\" Ignatz";
			Id = 4880;
			Model = 4684;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x010080026;
			BaseHitPoints = 499;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = 0;
			Equip( new Item( 7459, InventoryTypes.MainGauche, 2, 14, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.StinkyIgnatz, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class SwampEyeJarl : BaseCreature
	{
		public SwampEyeJarl() : base()
		{
			Name = "\"Swamp Eye\" Jarl";
			Id = 4792;
			Model = 4686;
			Level = RandomLevel(42);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080066;
			BaseHitPoints = 699;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.SwampEyeJarl, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}


/*A tormented voice - 8887*/

/*ANNOUNCEMENTS - 6971
<Announcements Notification>*/



namespace Server.Creatures
{
	public class Abercrombie : BaseCreature
	{
		public Abercrombie() : base()
		{
			Name = "Abercrombie";
			Guild="The Hermit";
			Id = 289;
			Model = 4328;
			Level = RandomLevel(35);
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
			BaseHitPoints = 1240;
			ManaType=1;
			BaseMana = 100;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3.19f;
			WalkSpeed = 3.19f;
			RunSpeed = 6.19f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			//NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Abercrombie, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}
 
/*Accursed Slitherblade - 14229*/



namespace Server.Creatures
{
	public class AchelliostheBanished : BaseCreature
	{
		public AchelliostheBanished() : base()
		{
			Name = "Achellios the Banished";
			//Guild="The Hermit";
			Id = 5933;
			Model = 9418;
			Level = RandomLevel(31);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1400;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseHitPoints = 1240;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			//NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			NpcFlags = 0;
			Equip( new Item( 12236, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AchelliostheBanished, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class AcolyteDellis : BaseCreature
	{
		public AcolyteDellis() : base()
		{
			Name = "Acolyte Dellis";
			Guild="The Hermit";
			Id = 5386;
			Model = 4328;
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
			Flags1=0x08480046;
			BaseHitPoints = 240;
			ManaType=1;
			BaseMana = 100;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3.19f;
			WalkSpeed = 3.19f;
			RunSpeed = 6.19f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			//NpcText00="It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 23171, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AcolyteDellis, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AcolyteFenrick : BaseCreature
	{
		public AcolyteFenrick() : base()
		{
			Name = "Acolyte Fenrick";
			Id = 6253;
			Model = 4942;
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
			Flags1=0x080066;
			BaseHitPoints = 599;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = 0;
			Equip( new Item( 2388, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AcolyteFenrick, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AcolytePorena : BaseCreature
	{
		public AcolytePorena() : base()
		{
			Name = "Acolyte Porena";
			Id = 6267;
			Model = 4951;
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
			Flags1=0x08480006;
			BaseHitPoints = 599;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 2388, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ),new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AcolytePorena, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AcolyteWytula : BaseCreature
	{
		public AcolyteWytula() : base()
		{
			Name = "Acolyte Wytula";
			Id = 6254;
			Model = 4943;
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
			Flags1=0x080066;
			BaseHitPoints = 599;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcText00="Not all Forsaken are driven by Sylvanas' will, $N. Some of us are driven by true power--power we earn for ourselves.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 19557, InventoryTypes.TwoHanded, 2, 15, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AcolyteWytula, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AdamLind : BaseCreature
	{
		public AdamLind() : base()
		{
			Name = "Adam Lind";
			Id = 12658;
			Model = 12609;
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
			Flags1=0x0480002;
			BaseHitPoints = 599;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcText00="Not all Forsaken are driven by Sylvanas' will, $N. Some of us are driven by true power--power we earn for ourselves.";
			NpcFlags = (int)NpcActions.Dialog;
			//Equip( new Item( 19557, InventoryTypes.TwoHanded, 2, 15, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AdamLind, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}





namespace Server.Creatures
{
	public class AddledLeper: BaseCreature 
	 { 
		public  AddledLeper() : base() 
		 { 
			Model = 6920;
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Addled Leper" ;
			Flags1 = 0x080000;
			Id = 6221 ; 
			Size = 1.15f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 24,25 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*20;

BCAddon.Hp( this, 305, 24 );

			NpcFlags = 0;
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AddledLeper, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}	
}





namespace Server.Creatures
{
	public class Adon: BaseCreature 
	 { 
		public  Adon() : base() 
		 { 
			Model = 11671;
			AttackSpeed= 1200;
			BoundingRadius = 1.045500000f ;
			Name = "Adon" ;
			Flags1 = 0x06;
			Id = 11706; 
			Size = 1.15f;
			Speed = 3.3f ;
			WalkSpeed = 3.3f ;
			RunSpeed = 6.3f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 60 );
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*20;
BCAddon.Hp( this, 3305, 62 );
			NpcFlags = 0;
			CombatReach = 11f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Adon, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}	
}



namespace Server.Creatures
{
	public class AdvisorBelgrum : BaseCreature
	{
		public AdvisorBelgrum() : base()
		{
			Name = "Advisor Belgrum";
			Id = 2918;
			Model = 3598;
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
			Flags1=0x08480046;
			BaseHitPoints = 799;
			BaseMana = 0;
			BoundingRadius = 0.3060f;
			CombatReach = 1.352f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			//NpcText00="Not all Forsaken are driven by Sylvanas' will, $N. Some of us are driven by true power--power we earn for ourselves.";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 5098, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AdvisorBelgrum, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




/*Advisor Willington 12790*/

/*Affray Challenger - 6240*/



namespace Server.Creatures
{
	public class AffraySpectator: BaseCreature 
	{ 
		public  AffraySpectator() : base() 
		{ 
			Model = 4962;
			AttackSpeed= 1500;
			Level = RandomLevel( 23 );
			BoundingRadius = 1.045500000f ;
			Name = "Affray Spectator" ;
			Flags1 = 0x06;
			Id = 6249; 
			Size = 1.15f;
			Speed = 3.16f ;
			WalkSpeed = 3.16f ;
			RunSpeed = 6.16f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*20;
			NpcFlags = 0;
			CombatReach = 11f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			//Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AffraySpectator, 100f ),
										  new BaseTreasure(Drops.MoneyD, 100f )};
			BCAddon.Hp( this, 702, 23 );
		}
	}	
}





namespace Server.Creatures
{
	public class Agal: BaseCreature 
	 { 
		public  Agal() : base() 
		 { 
			Id = 2162 ; 
			Model = 936;
			Level = RandomLevel( 8 );
			AttackSpeed= 2000;
			BoundingRadius = 1.045500000f ;
			Name = "Agal" ;
			Flags1 = 0x080000;			
			Size = 1.2f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*20;
			NpcFlags = 0;
			CombatReach = 1.425f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Agal, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};
			BCAddon.Hp( this, 155, 8 );
		}
	}	
}



namespace Server.Creatures
{
	public class AgentKearnen : BaseCreature
	{
		public AgentKearnen() : base()
		{
			Name = "Agent Kearnen";
			Id = 7024;
			Model = 5783;
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
			BaseHitPoints = 236;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AgentKearnen, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AggemThorncurse: BaseCreature 
	 { 
		public  AggemThorncurse() : base() 
		 { 
			Id = 4424 ; 
			Model = 6097;
			Level = RandomLevel( 30 );
			AttackSpeed= 2000;
			BoundingRadius = 0.5500000f ;
			Name = "Aggem Thorncurse" ;
			Guild="Death's Head Prophet";
			Flags1 = 0x080000;			
			Size = 1.5f;
			Speed = 3.7f ;
			WalkSpeed = 3.7f ;
			RunSpeed = 6.7f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*30;
			NpcFlags = 0;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 1;
			AIEngine = new AgressiveAnimalAI( this );
			Equip( new Item( 6454, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AggemThorncurse, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
			BCAddon.Hp( this, 4262, 30 );
		}
	}	
}


/*Aggi Rumblestomp - 13086*/



namespace Server.Creatures
{
	public class AgnarBeastamer : BaseCreature
	{
		public AgnarBeastamer() : base()
		{
			Name = "Agnar Beastamer";
			Id = 9660;
			Model = 8929;
			Level = RandomLevel(47);
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
			BaseHitPoints = 486;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.WildHammerClan;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AgnarBeastamer, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AjeckRouack: BaseCreature 
	 { 
		public  AjeckRouack() : base() 
		 { 
			Model = 1658;
			AttackSpeed= 1500;
			Level = RandomLevel( 40 );
			BoundingRadius = 1.045500000f ;
			Name = "Ajeck Rouack" ;
			Flags1 = 0x08080046;
			Id = 717; 
			Size = 1.15f;
			Speed = 3.16f ;
			WalkSpeed = 3.16f ;
			RunSpeed = 6.16f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*20;
			NpcFlags = 0;
			CombatReach = 11f ;
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			//Equip( new Item( 7487, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ),new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 )  ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AjeckRouack, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};
			BCAddon.Hp( this, 902, 40 );
		}
	}	
}



namespace Server.Creatures
{
	public class AkZeloth : BaseCreature
	{
		public AkZeloth() : base()
		{
			Name = "Ak'Zeloth";
			Id = 3521;
			Model = 3887;
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
			BaseHitPoints = 236;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AkZeloth, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}


namespace Server.Creatures
{
	public class AkubartheSeer: BaseCreature 
	 { 
		public  AkubartheSeer() : base() 
		 { 
			Id = 8298 ; 
			Model = 10920;
			Level = RandomLevel( 54 );
			AttackSpeed= 1100;
			BoundingRadius = 0.5500000f ;
			Name = "Akubar the Seer" ;
			Flags1 = 0;			
			Size = 1.5f;
			Speed = 3.8f ;
			WalkSpeed = 3.8f ;
			RunSpeed = 6.8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*40;
			NpcFlags = 0;
			CombatReach = 2.5f ;
			SetDamage(1f+1.8f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 4;
			AIEngine = new PredatorAI( this );
			Equip( new HandcraftedStaff());
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AkubartheSeer, 100f ),
							new BaseTreasure(DropsME.MoneyRare, 100f )}; 
			BCAddon.Hp( this, 7262, 54 );
		}
	}	
}



/*Al'tabim the All-Seeing - 14903*/



namespace Server.Creatures
{
	public class AlanndarianNightsong : BaseCreature
	{
		public AlanndarianNightsong() : base()
		{
			Name = "Alanndarian Nightsong";
			Id = 3702;
			Model = 4487;
			Level = RandomLevel(18);
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
			BaseHitPoints = 196;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AlanndarianNightsong, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}






/*Alexandra Blazen  - 8378*/




namespace Server.Creatures
{
	public class AlexiaIronknife : BaseCreature
	{
		public AlexiaIronknife() : base()
		{
			Name = "Alexia Ironknife";
			Id = 11609;
			Model = 11457;
			Level = RandomLevel(51);
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
			BaseHitPoints = 526;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AlexiaIronknife, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class Alina : BaseCreature
	{
		public Alina() : base()
		{
			Name = "Alina";
			Id = 2412;
			Model = 1828;
			Level = RandomLevel(33);
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
			BaseHitPoints = 346;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.NoFaction;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Alina, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AllianceSentinel : BaseCreature
	{
		public AllianceSentinel() : base()
		{
			Name = "Alliance Sentinel";
			Id = 12048;
			Model = 12069;
			Level = RandomLevel(55);
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
			BaseHitPoints = 566;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
				AIEngine = new PatrolAI( this ); 
			else 
				AIEngine = new StandingGuardAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AllianceSentinel, 100f ),
										  new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




/*Alterac Yeti - 13959*/






namespace Server.Creatures
{
	public class AmbassadorArdalan : BaseCreature
	{
		public AmbassadorArdalan() : base()
		{
			Name = "Ambassador Ardalan";
			Id = 7826;
			Model = 7010;
			Level = RandomLevel(55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080066;
			BaseHitPoints = 566;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.BootyBay;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AmbassadorArdalan, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AmbassadorBerrybuck : BaseCreature
	{
		public AmbassadorBerrybuck() : base()
		{
			Name = "Ambassador Berrybuck";
			Guild="Council of Darkshire";
			Id = 271;
			Model = 1713;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseHitPoints = 316;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.13f;
			WalkSpeed = 3.13f;
			RunSpeed = 6.13f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AmbassadorBerrybuck, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class AmbassadorFlamelash: BaseCreature 
	 { 
		public  AmbassadorFlamelash() : base() 
		 { 
			Id = 9156 ; 
			Model = 8329;
			Level = RandomLevel( 57 );
			AttackSpeed= 2000;
			BoundingRadius = 0.5500000f ;
			Name = "Ambassador Flamelash" ;
			//Guild="House of Barov";
			Flags1 = 0x080000;			
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
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Undead;
			Armor= Level*30;
			NpcFlags = 0;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Monster;
			Elite = 1;
			AIEngine = new PredatorAI( this );
			Equip( new Item( 22031, InventoryTypes.TwoHanded, 2, 6, 1, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AmbassadorFlamelash, 100f ),
							new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
			BCAddon.Hp( this, 5262, 57 );
		}
	}	
}




namespace Server.Creatures
{
	public class AmiePierce : BaseCreature
	{
		public AmiePierce() : base()
		{
			Name = "Amie Pierce";
			Id = 6732;
			Model = 8632;
			Level = RandomLevel(30);
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
			BaseHitPoints = 316;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 0.9f;
			Speed = 3.13f;
			WalkSpeed = 3.13f;
			RunSpeed = 6.13f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AmiePierce, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class Anathera : BaseCreature
	{
		public Anathera() : base()
		{
			Name = "Anathera";
			Id = 6245;
			Model = 4929;
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
			Flags1=0x0A66;
			BaseHitPoints = 216;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Anathera, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class Anaya : BaseCreature
	{
		public Anaya() : base()
		{
			Name = "Anaya";
			Id = 3843;
			Model = 1937;
			Level = RandomLevel(14);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0;
			BaseHitPoints = 156;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Anaya, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AncestralSpirit : BaseCreature
	{
		public AncestralSpirit() : base()
		{
			Name = "Ancestral Spirit";
			Id = 2994;
			Model = 3824;
			Level = RandomLevel(9);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080066;
			BaseHitPoints = 106;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.ThunderBluff;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AncestralSpirit, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AncientofLore : BaseCreature
	{
		public AncientofLore() : base()
		{
			Name = "Ancient of Lore";
			Id = 3468;
			Model = 1460;
			Level = RandomLevel(62);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x0480006;
			BaseHitPoints = 636;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 3f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AncientofLore, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class Andi : BaseCreature
	{
		public Andi() : base()
		{
			Name = "Andi";
			Id = 3507;
			Model = 252;
			Level = RandomLevel(62);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08006E;
			BaseHitPoints = 636;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.52f;
			Size = 1f;
			Speed = 3.0f;
			WalkSpeed = 3.0f;
			RunSpeed = 6.0f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Andi, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndiLynn : BaseCreature
	{
		public AndiLynn() : base()
		{
			Name = "Andi Lynn";
			Id = 11758;
			Model = 11691;
			Level = RandomLevel(48);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080006;
			BaseHitPoints = 496;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AndiLynn, 100f ),
							new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndreFirebeard : BaseCreature
	{
		public AndreFirebeard() : base()
		{
			Name = "Andre Firebeard";
			Id = 7883;
			Model = 11691;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseHitPoints = 466;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
				AIEngine = new PatrolAI( this ); 
			else 
				AIEngine = new StandingGuardAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 7526, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1706, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AndreFirebeard, 100f ),
										  new BaseTreasure(Drops.MoneyC, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class AndreaHalloran : BaseCreature
	{
		public AndreaHalloran() : base()
		{
			Name = "Andrea Halloran";
			Id = 1482;
			Model = 3485;
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
			Flags1=0x0480002;
			BaseHitPoints = 216;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AndreaHalloran, 100f ),
							new BaseTreasure(Drops.MoneyB, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class AngelasMoonbreeze : BaseCreature
	{
		public AngelasMoonbreeze() : base()
		{
			Name = "Angelas Moonbreeze";
			Id = 7900;
			Model = 6987;
			Level = RandomLevel(50);
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
			BaseHitPoints = 516;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 8078, InventoryTypes.MainGauche, 2, 14, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AngelasMoonbreeze, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}



namespace Server.Creatures
{
	public class Angus : BaseCreature
	{
		public Angus() : base()
		{
			Name = "Angus";
			Guild="Dwarven Mortar Team";
			Id = 10610;
			Model = 9946;
			Level = RandomLevel(11);
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
			BaseHitPoints = 126;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = 0;
			//Visible = InvisibilityLevel.Medium;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 20504, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Angus, 100f ),
							new BaseTreasure(Drops.MoneyA, 100f )};	
		}
	}
}





namespace Server.Creatures
{
	public class AngusStern : BaseCreature
	{
		public AngusStern() : base()
		{
			Name = "Angus Stern";
			Guild="Head Chef";
			Id = 1141;
			Model = 5073;
			Level = RandomLevel(60);
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
			BaseHitPoints = 616;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 20504, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.AngusStern, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}




namespace Server.Creatures
{
	public class Anilia : BaseCreature
	{
		public Anilia() : base()
		{
			Name = "Anilia";
			//Guild="Head Chef";
			Id = 3920;
			Model = 12064;
			Level = RandomLevel(25);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x0480046;
			BaseHitPoints = 266;
			BaseMana = 0;
			BoundingRadius = 0.21000f;
			CombatReach = 1.72f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Darnasus;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			//Visible = InvisibilityLevel.Medium;
			//Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ), new Item( 20504, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( OtherHumanoudDrops.Anilia, 100f ),
							new BaseTreasure(Drops.MoneyD, 100f )};	
		}
	}
}



