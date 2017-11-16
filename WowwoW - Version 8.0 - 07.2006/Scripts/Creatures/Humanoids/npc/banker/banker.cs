using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class OliviaBurnside : BaseCreature
	{
		public OliviaBurnside() : base()
		{
			Name = "Olivia Burnside";
			Guild="Banker";
			Id = 2455;
			Model = 1450;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1557;
			BaseMana = 0; //86			
			BoundingRadius = 1f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			//Faction = Factions.Friend;			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 




namespace Server.Creatures
{
	public class NewtonBurnside : BaseCreature
	{
		public NewtonBurnside() : base()
		{
			Name = "Newton Burnside";
			Guild="Banker";
			Id = 2456;
			Model = 1436;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 7428, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 



namespace Server.Creatures
{
	public class JohnBurnside : BaseCreature
	{
		public JohnBurnside() : base()
		{
			Name = "John Burnside";
			Guild="Banker";
			Id = 2457;
			Model = 1437;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			NpcText00="No one's ever stolen anything out of here. Not in the whole history of... the whole history!";
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 



namespace Server.Creatures
{
	public class RandolphMontague : BaseCreature
	{
		public RandolphMontague() : base()
		{
			Name = "Randolph Montague";
			Guild="Banker";
			Id = 2458;
			Model = 1437;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 6;
			Equip( new Item( 23319, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 



namespace Server.Creatures
{
	public class MortimerMontague : BaseCreature
	{
		public MortimerMontague() : base()
		{
			Name = "Mortimer Montague";
			Guild="Banker";
			Id = 2459;
			Model = 2641;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 6;
			Equip( new Item( 23317, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 



namespace Server.Creatures
{
	public class BarnumStonemantle : BaseCreature
	{
		public BarnumStonemantle() : base()
		{
			Name = "Barnum Stonemantle";
			Guild="Banker";
			Id = 2460;
			Model = 3037;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 7494, InventoryTypes.MainGauche, 2, 4, 2, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
} 



namespace Server.Creatures
{
	public class BaileyStonemantle : BaseCreature
	{
		public BaileyStonemantle() : base()
		{
			Name = "Bailey Stonemantle";
			Guild="Banker";
			Id = 2461;
			Model = 3038;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 7434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ViznikGoldgrubber : BaseCreature
	{
		public ViznikGoldgrubber() : base()
		{
			Name = "Viznik Goldgrubber";
			Guild="Banker";
			Id = 2625;
			Model = 7160;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.BootyBay; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Torn : BaseCreature
	{
		public Torn() : base()
		{
			Name = "Torn";
			Guild="Banker";
			Id = 2996;
			Model = 7160;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.906f;
			CombatReach = 1f;
			Size = 1.35f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThunderBluff; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23318, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Karus : BaseCreature
	{
		public Karus() : base()
		{
			Name = "Karus";
			Guild="Banker";
			Id = 3309;
			Model = 1310;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23317, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Koma : BaseCreature
	{
		public Koma() : base()
		{
			Name = "Koma";
			Guild="Banker";
			Id = 3318;
			Model = 1318;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Ogrimmar; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23319, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Soran : BaseCreature
	{
		public Soran() : base()
		{
			Name = "Soran";
			Guild="Banker";
			Id = 3320;
			Model = 1320;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23316, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23172, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Fuzruckle : BaseCreature
	{
		public Fuzruckle() : base()
		{
			Name = "Fuzruckle";
			Guild="Banker";
			Id = 3496;
			Model = 7068;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ratchet; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23316, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23320, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}


namespace Server.Creatures
{
	public class Idriana : BaseCreature
	{
		public Idriana() : base()
		{
			Name = "Idriana";
			Guild="Banker";
			Id = 4155;
			Model = 2210;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Lairn : BaseCreature
	{
		public Lairn() : base()
		{
			Name = "Lairn";
			Guild="Banker";
			Id = 4208;
			Model = 2259;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Garryeth : BaseCreature
	{
		public Garryeth() : base()
		{
			Name = "Garryeth";
			Guild="Banker";
			Id = 4209;
			Model = 2256;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class WilliamMontague : BaseCreature
	{
		public WilliamMontague() : base()
		{
			Name = "William Montague";
			Guild="Banker";
			Id = 4549;
			Model = 2655;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity; 			
			AIEngine = new StandingNpcAI( this ); 
			Equip( new Item( 23316, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Family = 6;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class OpheliaMontague : BaseCreature
	{
		public OpheliaMontague() : base()
		{
			Name = "Ophelia Montague";
			Guild="Banker";
			Id = 4550;
			Model = 3942;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0; //86			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 6;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class SoleilStonemantle : BaseCreature
	{
		public SoleilStonemantle() : base()
		{
			Name = "Soleil Stonemantle";
			Guild="Banker";
			Id = 5099;
			Model = 3039;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Gimblethorn : BaseCreature
	{
		public Gimblethorn() : base()
		{
			Name = "Gimblethorn";
			Guild="Banker";
			Id = 7799;
			Model = 6882;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Gadgetzan; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23320, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Zikkel : BaseCreature
	{
		public Zikkel() : base()
		{
			Name = "Zikkel";
			Guild="Banker";
			Id = 8119;
			Model = 7332;
			Flags1 = 0x08080006;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ratchet; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;
			Equip( new Item( 23172, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ), new Item( 23319, InventoryTypes.HeldInHand, 4, 0, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class RickleGoldgrubber : BaseCreature
	{
		public RickleGoldgrubber() : base()
		{
			Name = "Rickle Goldgrubber";
			Guild="Banker";
			Id = 8123;
			Model = 7337;
			Flags1 = 0x08080046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.BootyBay; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;	
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Qizzik : BaseCreature
	{
		public Qizzik() : base()
		{
			Name = "Qizzik";
			Guild="Banker";
			Id = 8124;
			Model = 7335;
			Flags1 = 0x08080006;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Gadgetzan; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;	
			Equip( new Item( 23316, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Chesmu : BaseCreature
	{
		public Chesmu() : base()
		{
			Name = "Chesmu";
			Guild="Banker";
			Id = 8356;
			Model = 7621;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.ThunderBluff; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;	
			Equip( new Item( 23172, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Atepa : BaseCreature
	{
		public Atepa() : base()
		{
			Name = "Atepa";
			Guild="Banker";
			Id = 8357;
			Model = 7620;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(45);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 3.6f;
			WalkSpeed = 3.6f;
			RunSpeed = 6.6f;
			Faction = Factions.ThunderBluff; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;	
			Equip( new Item( 23319, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class IzzyCoppergrab : BaseCreature
	{
		public IzzyCoppergrab() : base()
		{
			Name = "Izzy Coppergrab";
			Guild="Banker";
			Id = 13917;
			Model = 13969;
			Flags1 = 0x08080006;
			NpcFlags = (int)NpcActions.Banker;
			Level = RandomLevel(55);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 72+33*Level;
			BaseMana = 0;			
			BoundingRadius = 0.306f;
			CombatReach = 1f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Faction = Factions.Everlook; 			
			AIEngine = new StandingNpcAI( this ); 
			Family = 7;	
			Equip( new Item( 23316, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}


