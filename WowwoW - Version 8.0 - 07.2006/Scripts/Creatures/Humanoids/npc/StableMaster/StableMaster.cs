using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class AnyaMaulray : BaseCreature
	{
		public AnyaMaulray() : base()
		{
			Name = "Anya Maulray";
			Guild="Stable Master";
			Id = 10053;
			Model = 9273;
			Flags1 = 0x018480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Undead;
			Equip( new Item( 2388, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 )); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
} 





namespace Server.Creatures
{
	public class Antarius : BaseCreature
	{
		public Antarius() : base()
		{
			Name = "Antarius";
			Guild="Stable Master";
			Id = 10059;
			Model = 9282;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 6434, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Erma : BaseCreature
	{
		public Erma() : base()
		{
			Name = "Erma";
			Guild="Stable Master";
			Id = 6749;
			Model = 9257;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 6434, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Tharlidun : BaseCreature
	{
		public Tharlidun() : base()
		{
			Name = "Tharlidun";
			Guild="Stable Master";
			Id = 9976;
			Model = 9250;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 19549, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Sylista : BaseCreature
	{
		public Sylista() : base()
		{
			Name = "Sylista";
			Guild="Stable Master";
			Id = 9977;
			Model = 9249;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 1927, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ), new Item( 10968, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Wesley : BaseCreature
	{
		public Wesley() : base()
		{
			Name = "Wesley";
			Guild="Stable Master";
			Id = 9978;
			Model = 9252;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 7484, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class SarahGoode : BaseCreature
	{
		public SarahGoode() : base()
		{
			Name = "Sarah Goode";
			Guild="Stable Master";
			Id = 9979;
			Model = 9251;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Undead;
			Equip( new Item( 21376, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ), new Item( 1705, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ShelbyStoneflint : BaseCreature
	{
		public ShelbyStoneflint() : base()
		{
			Name = "Shelby Stoneflint";
			Guild="Stable Master";
			Id = 9980;
			Model = 9253;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 7461, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Sikwa : BaseCreature
	{
		public Sikwa() : base()
		{
			Name = "Sikwa";
			Guild="Stable Master";
			Id = 9981;
			Model = 9254;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.25f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 21376, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Penny : BaseCreature
	{
		public Penny() : base()
		{
			Name = "Penny";
			Guild="Stable Master";
			Id = 9982;
			Model = 9255;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 7461, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Kelsuwa : BaseCreature
	{
		public Kelsuwa() : base()
		{
			Name = "Kelsuwa";
			Guild="Stable Master";
			Id = 9983;
			Model = 9256;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.35f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.ThunderBluff;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class UlbrekFirehand : BaseCreature
	{
		public UlbrekFirehand() : base()
		{
			Name = "Ulbrek Firehand";
			Guild="Stable Master";
			Id = 9984;
			Model = 9258;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 7477, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ), new Item( 6534, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Laziphus : BaseCreature
	{
		public Laziphus() : base()
		{
			Name = "Laziphus";
			Guild="Stable Master";
			Id = 9985;
			Model = 9259;
			Flags1 = 0x080006;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Gadgetzan;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 2480, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class ShyrkaWolfrunner : BaseCreature
	{
		public ShyrkaWolfrunner() : base()
		{
			Name = "Shyrka Wolfrunner";
			Guild="Stable Master";
			Id = 9986;
			Model = 9260;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 2480, InventoryTypes.TwoHended, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Shojamy : BaseCreature
	{
		public Shojamy() : base()
		{
			Name = "Shoja'my";
			Guild="Stable Master";
			Id = 9987;
			Model = 9260;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.DarkspearTrolls;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22893, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Xoncha : BaseCreature
	{
		public Xoncha() : base()
		{
			Name = "Xon'cha";
			Guild="Stable Master";
			Id = 9988;
			Model = 9261;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 1600, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class LinaHearthstove : BaseCreature
	{
		public LinaHearthstove() : base()
		{
			Name = "Lina Hearthstove";
			Guild="Stable Master";
			Id = 9989;
			Model = 9263;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 1600, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class KirkMaxwell : BaseCreature
	{
		public KirkMaxwell() : base()
		{
			Name = "Kirk Maxwell";
			Guild="Stable Master";
			Id = 10045;
			Model = 9265;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 1600, InventoryTypes.MainGauche, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class BethaineFlinthammer : BaseCreature
	{
		public BethaineFlinthammer() : base()
		{
			Name = "Bethaine Flinthammer";
			Guild="Stable Master";
			Id = 10046;
			Model = 9264;
			Flags1 = 0x0480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.IronForge;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 7482, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Michael : BaseCreature
	{
		public Michael() : base()
		{
			Name = "Michael";
			Guild="Stable Master";
			Id = 10047;
			Model = 9266;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 24281, InventoryTypes.HeldInHand, 4, 0, 2, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Gereck : BaseCreature
	{
		public Gereck() : base()
		{
			Name = "Gereck";
			Guild="Stable Master";
			Id = 10048;
			Model = 9267;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Hekkru : BaseCreature
	{
		public Hekkru() : base()
		{
			Name = "Hekkru";
			Guild="Stable Master";
			Id = 10049;
			Model = 9268;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Seikwa : BaseCreature
	{
		public Seikwa() : base()
		{
			Name = "Seikwa";
			Guild="Stable Master";
			Id = 10050;
			Model = 9269;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.25f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Seriadne : BaseCreature
	{
		public Seriadne() : base()
		{
			Name = "Seriadne";
			Guild="Stable Master";
			Id = 10051;
			Model = 9270;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Maluressian : BaseCreature
	{
		public Maluressian() : base()
		{
			Name = "Maluressian";
			Guild="Stable Master";
			Id = 10052;
			Model = 9271;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Bulrug : BaseCreature
	{
		public Bulrug() : base()
		{
			Name = "Bulrug";
			Guild="Stable Master";
			Id = 10054;
			Model = 9272;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.4f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22394, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Morganus : BaseCreature
	{
		public Morganus() : base()
		{
			Name = "Morganus";
			Guild="Stable Master";
			Id = 10055;
			Model = 9274;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Undead;
			Equip( new Item( 23281, InventoryTypes.MainGauche, 2, 14, 2, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Alassin : BaseCreature
	{
		public Alassin() : base()
		{
			Name = "Alassin";
			Guild="Stable Master";
			Id = 10056;
			Model = 9275;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 23281, InventoryTypes.MainGauche, 2, 14, 2, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class TheodoreMontClaire : BaseCreature
	{
		public TheodoreMontClaire() : base()
		{
			Name = "Theodore Mont Claire";
			Guild="Stable Master";
			Id = 10057;
			Model = 9279;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Undercity;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Undead;
			Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Greth : BaseCreature
	{
		public Greth() : base()
		{
			Name = "Greth";
			Guild="Stable Master";
			Id = 10058;
			Model = 9281;
			Flags1 = 0x08400046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ogrimmar;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}





namespace Server.Creatures
{
	public class Grimestack : BaseCreature
	{
		public Grimestack() : base()
		{
			Name = "Grimestack";
			Guild="Stable Master";
			Id = 10060;
			Model = 9284;
			Flags1 = 0x08080006;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(46);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1590;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.BootyBay;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyC, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class KilliumBouldertoe : BaseCreature
	{
		public KilliumBouldertoe() : base()
		{
			Name = "Killium Bouldertoe";
			Guild="Stable Master";
			Id = 10061;
			Model = 9283;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.WildHammerClan;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 1600, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class StevenBlack : BaseCreature
	{
		public StevenBlack() : base()
		{
			Name = "Steven Black";
			Guild="Stable Master";
			Id = 10062;
			Model = 9285;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Reggifuz : BaseCreature
	{
		public Reggifuz() : base()
		{
			Name = "Reggifuz";
			Guild="Stable Master";
			Id = 10063;
			Model = 9286;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(35);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1227;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Ratchet;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Jaelysia : BaseCreature
	{
		public Jaelysia() : base()
		{
			Name = "Jaelysia";
			Guild="Stable Master";
			Id = 10085;
			Model = 9294;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			//Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class JenovaStoneshield : BaseCreature
	{
		public JenovaStoneshield() : base()
		{
			Name = "Jenova Stoneshield";
			Guild="Stable Master";
			Id = 11069;
			Model = 10477;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Stormwind;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 5569, InventoryTypes.OneHand, 2, 14, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}




namespace Server.Creatures
{
	public class Shelgrayn : BaseCreature
	{
		public Shelgrayn() : base()
		{
			Name = "Shelgrayn";
			Guild="Stable Master";
			Id = 11104;
			Model = 10567;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Darnasus;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 7460, InventoryTypes.MainGauche, 2, 14, 1, 7, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Aboda : BaseCreature
	{
		public Aboda() : base()
		{
			Name = "Aboda";
			Guild="Stable Master";
			Id = 11105;
			Model = 10566;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.35f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.ThunderBluff;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 6434, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ), new Item( 6593, InventoryTypes.RangeRight, 2, 3, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Awenasa : BaseCreature
	{
		public Awenasa() : base()
		{
			Name = "Awenasa";
			Guild="Stable Master";
			Id = 11117;
			Model = 10652;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.25f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.ThunderBluff;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 23172, InventoryTypes.MainGauche, 2, 14, 1, 0, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}



namespace Server.Creatures
{
	public class Azzleby : BaseCreature
	{
		public Azzleby() : base()
		{
			Name = "Azzleby";
			Guild="Stable Master";
			Id = 11119;
			Model = 10656;
			Flags1 = 0x080006;
			NpcFlags = (int)NpcActions.StableMaster;
			Level = RandomLevel(30);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);
			AttackSpeed = 2000;
			Armor = 40;
			Block = 0;
			ResistArcane = 10;
			BaseHitPoints = 1062;
			BaseMana = 0; //86			
			BoundingRadius = 0.383f;
			CombatReach = 1.5f;
			Size = 1.0f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.NoFaction;			
			AIEngine = new StandingNpcAI( this ); 
			NpcType = (int)NpcTypes.Humanoid;
			Equip( new Item( 22395, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ));
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};
		}
	}
}


