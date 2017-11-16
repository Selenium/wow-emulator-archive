using System;
using System.Collections;
using Server;
using Server.Items; 


namespace Server.Creatures
{
	public class ElderMistvaleGorilla : BaseCreature
	{
		public ElderMistvaleGorilla() : base()
		{
			Name = "Elder Mistvale Gorilla";
			Id = 1557;
			Model = 838;
			Level = RandomLevel(40,41);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.1570f;
			CombatReach = 0.8f;
			Size = 1.33f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1419, 40 );

			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 6.83088f ) 
,new Loot( typeof( HeavyHide), 1.02349f ) 
,new Loot( typeof( HeavyLeather), 27.0072f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.ElderMistvaleGorilla , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class EnragedSilverbackGorilla : BaseCreature
	{
		public EnragedSilverbackGorilla() : base()
		{
			Name = "Enraged Silverback Gorilla";
			Id = 1511;
			Model = 837;
			Level = RandomLevel(41,42);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0570f;
			CombatReach = 1.25f;
			Size = 1.33f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x012;
			BCAddon.Hp( this, 1112, 41 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 1.25796f ) 
,new Loot( typeof( HeavyLeather), 20.2654f ) 
,new Loot( typeof( ThickHide), 2.10938f ) 
,new Loot( typeof( ThickLeather), 24.3768f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.EnragedSilverbackGorilla , 100f )
										};
		}
	}
} 



namespace Server.Creatures
{
	public class GroddocApe : BaseCreature
	{
		public GroddocApe() : base()
		{
			Name = "Groddoc Ape";
			Id = 5260;
			Model = 3186;
			Level = RandomLevel(42,43);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0570f;
			CombatReach = 1.25f;
			Size = 1.33f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1896, 42 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.863983f ) 
,new Loot( typeof( ThickLeather), 11.5618f ) 
,new Loot( typeof( HeavyHide), 0.689986f ) 
,new Loot( typeof( HeavyLeather), 10.1458f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.GroddocApe , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class GroddocThunderer : BaseCreature
	{
		public GroddocThunderer() : base()
		{
			Name = "Groddoc Thunderer";
			Id = 5262;
			Model = 3188;
			Level = RandomLevel(49,50);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.3570f;
			CombatReach = 1.625f;
			Size = 1.3f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2476, 49 );
			SkinLoot = new Loot[] {new Loot( typeof( RuggedLeather), 4.7746f ) 
,new Loot( typeof( ThickHide), 0.716607f ) 
,new Loot( typeof( ThickLeather), 18.2235f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.GroddocThunderer , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class JungleThunderer : BaseCreature
	{
		public JungleThunderer() : base()
		{
			Name = "Jungle Thunderer";
			Id = 1114;
			Model = 845;
			Level = RandomLevel(37,38);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.920f;
			CombatReach = 1.1f;
			Size = 0.88f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1619, 37 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickLeather), 5.88018f ) 
,new Loot( typeof( HeavyHide), 0.934881f ) 
,new Loot( typeof( HeavyLeather), 22.8441f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.JungleThunderer , 100f )
										};
		}
	}
}




namespace Server.Creatures
{
	public class Konda : BaseCreature
	{
		public Konda() : base()
		{
			Name = "Konda";
			Id = 1516;
			Model = 839;
			Level = RandomLevel(43);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.0520f;
			CombatReach = 1.25f;
			Size = 0.88f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2731, 43 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 2.6178f ) 
,new Loot( typeof( HeavyLeather), 44.6771f ) 
,new Loot( typeof( ThickHide), 4.01396f ) 
,new Loot( typeof( ThickLeather), 48.5166f ) 
			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.Konda , 100f )
										};
		}
	}
}


namespace Server.Creatures
{
	public class Kurmokk : BaseCreature
	{
		public Kurmokk() : base()
		{
			Name = "Kurmokk";
			Id = 14491;
			Model = 3188;
			Level = RandomLevel(42);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.9f);
			NpcType = (int)NpcTypes.Beast ;
			Armor= 2262;
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.3570f;
			CombatReach = 1.625f;
			Size = 1.3f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			Elite=4;
			BCAddon.Hp( this, 1981, 42 );
			SkinLoot = new Loot[] {new Loot( typeof( HeavyHide), 2.6178f ) 
,new Loot( typeof( HeavyLeather), 44.6771f ) 
,new Loot( typeof( ThickHide), 4.01396f ) 
,new Loot( typeof( ThickLeather), 48.5166f ) 
			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.Kurmokk , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class MistvaleGorilla : BaseCreature
	{
		public MistvaleGorilla() : base()
		{
			Name = "Mistvale Gorilla";
			Id = 1108;
			Model = 843;
			Level = RandomLevel(32,33);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 0.90520f;
			CombatReach = 1.07f;
			Size = 0.86f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1483, 32 );
			SkinLoot = new Loot[] {new Loot( typeof( MediumHide), 1.01456f ) 
,new Loot( typeof( MediumLeather), 11.2243f ) 
,new Loot( typeof( HeavyHide), 0.713799f ) 
,new Loot( typeof( HeavyLeather), 12.4995f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.MistvaleGorilla , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SilverbackPatriarch : BaseCreature
	{
		public SilverbackPatriarch() : base()
		{
			Name = "Silverback Patriarch";
			Id = 1558;
			Model = 844;
			Level = RandomLevel(42,43);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 2000;			
			BoundingRadius = 1.20520f;
			CombatReach = 1.43f;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 1873, 42 );
			SkinLoot = new Loot[] {new Loot( typeof( ThickHide), 0.970969f ) 
,new Loot( typeof( ThickLeather), 14.6724f ) 
,new Loot( typeof( HeavyHide), 0.843468f ) 
,new Loot( typeof( HeavyLeather), 11.8184f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.SilverbackPatriarch , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class SkymaneGorilla : BaseCreature
	{
		public SkymaneGorilla() : base()
		{
			Name = "Skymane Gorilla";
			Id = 2521;
			Model = 809;
			Level = RandomLevel(50);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;

			BaseMana = 0;
			AttackSpeed = 1500;			
			BoundingRadius = 1.0f;
			CombatReach = 1.43f;
			Size = 1.15f;
			Speed = 3.2f;
			WalkSpeed = 3.2f;
			RunSpeed = 6.2f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2801, 50 );
			SkinLoot = new Loot[] {new Loot( typeof( RuggedLeather), 6.23104f ) 
,new Loot( typeof( ThickHide), 0.884732f ) 
,new Loot( typeof( ThickLeather), 24.3428f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.SkymaneGorilla , 100f )
										};
		}
	}
}



namespace Server.Creatures
{
	public class UnGoroGorilla : BaseCreature
	{
		public UnGoroGorilla() : base()
		{
			Name = "Un'Goro Gorilla";
			Id = 6514;
			Model = 844;
			Level = RandomLevel(50,51);
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*3.75f);
			NpcType = (int)NpcTypes.Beast ;
			Armor = (int)(Level*26.2);
			Block= Level;
			Family=9;
			SetDamage(1f+2.8f*Level,1f+3.5*Level);
			ManaType=1;
 
			BaseMana = 0;
			AttackSpeed = 1500;			
			BoundingRadius = 1.20f;
			CombatReach = 1.43f;
			Size = 1.15f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Faction = Factions.EvilBeast;
			AIEngine = new AgressiveAnimalAI( this );
			Flags1 = 0x010;
			BCAddon.Hp( this, 2517, 50 );
			SkinLoot = new Loot[] {new Loot( typeof( RuggedHide), 1.05271f ) 
,new Loot( typeof( RuggedLeather), 13.262f ) 
,new Loot( typeof( ThickHide), 0.826743f ) 
,new Loot( typeof( ThickLeather), 11.2355f ) 

			};			
			Loots = new BaseTreasure[]{  new BaseTreasure( GorillaDrops.UnGoroGorilla , 100f )
										};
		}
	}
}
