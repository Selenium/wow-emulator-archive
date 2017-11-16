//originally Scripted By mmcs
using System;
using Server.Items;
using Server;

////////////////////
namespace Server.Creatures
{
	public class Axtroz : BaseCreature
	{
		public Axtroz() : base()
		{
			Id = 12899 ;
			Name = "Axtroz" ;
			Model = 12821;
			Level = RandomLevel( 62 );
			AttackSpeed= 1050;
			BoundingRadius = 1.0f ;
			CombatReach = 5.5f ;
			BaseHitPoints = 7568 ;
			BaseMana = 9315 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4.09f ;
			WalkSpeed = 4.09f ;
			RunSpeed = 7.09f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Axtroz, 100f ) };
		}
	}
	public class Azuregos : BaseCreature
	{
		public Azuregos() : base()
		{
			Id = 6109 ;
			Name = "Azuregos" ;
			Model = 11460;
			Level = RandomLevel( 63 );
			AttackSpeed= 1400;
			BoundingRadius = 1.0f ;
			CombatReach = 17.0f ;
			BaseHitPoints = 98370 ;
			BaseMana = 45693 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(4f+3.8f*Level,4f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.68f ;
			WalkSpeed = 3.68f ;
			RunSpeed = 6.68f ;
			Elite = 3 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0C0811000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Azuregos, 100f ) };
		}
	}
	public class Azurous : BaseCreature
	{
		public Azurous() : base()
		{
			Id = 10202 ;
			Name = "Azurous" ;
			Model = 6373;
			Level = RandomLevel( 59 );
			AttackSpeed= 1400;
			BoundingRadius = 1.0f ;
			CombatReach = 2.5f ;
			BaseHitPoints = 9544 ;
			BaseMana = 11820 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);	
			Size = 1.0f;
			Speed = 4.20f ;
			WalkSpeed = 4.20f ;
			RunSpeed = 7.20f ;
			Elite = 2 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Azurous, 100f ) };
		}
	}
	public class BlackDrake : BaseCreature
	{
		public BlackDrake() : base()
		{
			Id = 7044 ;
			Name = "Black Drake" ;
			Model = 6374;
			Level = RandomLevel( 50, 52 );
			AttackSpeed= 2000;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = (int)(6075*Math.Pow(1.2f,Level-50)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.95f ;
			WalkSpeed = 3.95f ;
			RunSpeed = 6.95f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.BlackDrake, 100f ) };
		}
	}
	public class Blacklash : BaseCreature
	{
		public Blacklash() : base()
		{
			Id = 2757 ;
			Name = "Blacklash" ;
			Model = 6369;
			Level = RandomLevel( 50, 57 );
			AttackSpeed= 2000;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = (int)(6435*Math.Pow(1.2f,Level-50)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Blacklash, 100f ) };
		}
	}
	public class BlackrockDrake : BaseCreature
	{
		public BlackrockDrake() : base()
		{
			Id = 8964 ;
			Name = "Blackrock Drake" ;
			Model = 6374;
			Level = RandomLevel( 51 );
			AttackSpeed= 2000;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 6230 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0266 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.BlackrockDrake, 100f ) };
		}
	}			
	public class Brimgore : BaseCreature
	{
		public Brimgore() : base()
		{
			Id = 4339 ;
			Name = "Brimgore" ;
			Model = 6374;
			Level = RandomLevel( 45 );
			AttackSpeed= 2000;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 8435 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);	  
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			Elite = 2 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Brimgore, 100f ) };
		}
	}		
	public class DeathTalonFlamescale : BaseCreature 
	{ 
		public  DeathTalonFlamescale() : base() 
		{ 
			Id = 12463 ;
			Name = "Death Talon Flamescale" ;
			Model = 8310;
			Level = RandomLevel( 61 );
			AttackSpeed= 2000;
			BoundingRadius = 1.0f ;
			CombatReach = 3.5f ;
			BaseHitPoints = 7200 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = 5*Level ;
			Elite = 1 ;
			NpcFlags = 0 ; Flags1 = 0x000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.DeathTalonFlamescale, 100f ) };
		}
	}
	public class DeathTalonSeether : BaseCreature 
	{ 
		public  DeathTalonSeether() : base() 
		{ 
			Id = 12464 ;
			Name = "Death Talon Seether" ;
			Model = 12893;
			Level = RandomLevel( 61 );
			AttackSpeed= 2000;
			BoundingRadius = 1.0f ;
			CombatReach = 3.5f ;
			BaseHitPoints = 7200 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			ResistFire = 5*Level ;
			Elite = 1 ;
			NpcFlags = 0 ; Flags1 = 0x000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.DeathTalonSeether, 100f ) };
		}
	}		
	public class Dreamscythe : BaseCreature 
	{ 
		public  Dreamscythe() : base() 
		{ 
			Id = 5721 ;
			Name = "Dreamscythe" ;
			Model = 7553;
			Level = RandomLevel( 53 );
			AttackSpeed= 1143;
			BoundingRadius = 1.0f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 6435 ; 
			BaseMana = 7962 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;
			ResistFire = 5*Level ;
			Elite = 1 ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Dreamscythe, 100f ) };
		}
	}
	public class Dreamstalker : BaseCreature 
	{ 
		public  Dreamstalker() : base() 
		{ 
			Id = 12498 ;
			Name = "Dreamstalker" ;
			Model = 6375;
			Level = RandomLevel( 62 );
			AttackSpeed= 2000;
			BoundingRadius = 0.51f ;
			CombatReach = 1.5f ;
			BaseHitPoints = 8000 ; 
			BaseMana = 8000 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 2.95f ;
			WalkSpeed = 2.95f ;
			RunSpeed = 5.95f ;
			ResistFire = 5*Level ;
			Elite = 1 ;
			NpcFlags = 0 ; Flags1 = 0x0800000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 18435, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Dreamstalker, 100f ) };
		}
	}	
	public class Dreamtracker : BaseCreature 
	{ 
		public  Dreamtracker() : base() 
		{ 
			Id = 12496 ;
			Name = "Dreamtracker" ;
			Model = 7553;
			Level = RandomLevel( 62 );
			AttackSpeed= 2000;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 7518 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 4.09f ;
			WalkSpeed = 4.09f ;
			RunSpeed = 7.09f ;
			ResistFire = 5*Level ;
			Elite = 1 ;
			NpcFlags = 0 ; Flags1 = 0x0800000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Dreamtracker, 100f ) };
		}
	}	
	public class Ebonroc : BaseCreature 
	{ 
		public  Ebonroc() : base() 
		{ 
			Id = 14601 ;
			Name = "Ebonroc" ;
			Model = 6377;
			Level = RandomLevel( 63 );
			AttackSpeed= 2000;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 15000 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(5f+3.8f*Level,5f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistFire = 5*Level ;
			Elite = 3 ;
			NpcFlags = 0 ; Flags1 = 0x0000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Ebonroc, 100f ) };
		}
	}			
	public class Emberstrife : BaseCreature
	{
		public Emberstrife() : base()
		{
			Id = 10321 ;
			Name = "Emberstrife" ;
			Model = 6374;
			Level = RandomLevel( 61 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 7000 ;
			BaseMana = 3580 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(10f+3.8f*Level,10f+4.5*Level); 
			Size = 1.3f;
			Speed = 4.08f ;
			WalkSpeed = 4.08f ;
			RunSpeed = 4.08f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = (int)NpcActions.Dialog ; Flags1 = 0x06 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Horde;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Emberstrife, 100f ) };
		} // need make quests -> nf*
	}
	public class Firemaw : BaseCreature 
	{ 
		public  Firemaw() : base() 
		{ 
			Id = 11983 ;
			Name = "Firemaw" ;
			Model = 6377;
			Level = RandomLevel( 63 );
			AttackSpeed= 2000;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 15000 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(5f+3.8f*Level,5f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistFire = 5*Level ;
			Elite = 3 ;
			NpcFlags = 0 ; Flags1 = 0x0000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Firemaw, 100f ) };
		}
	}
	public class Flamegor : BaseCreature 
	{ 
		public  Flamegor() : base() 
		{ 
			Id = 11981 ;
			Name = "Flamegor" ;
			Model = 6377;
			Level = RandomLevel( 63 );
			AttackSpeed= 2000;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 15000 ; 
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(5f+3.8f*Level,5f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			ResistFire = 5*Level ;
			Elite = 3 ;
			NpcFlags = 0 ; Flags1 = 0x0000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Flamegor, 100f ) };
		}
	}					
	public class FrenziedBlackDrake : BaseCreature
	{
		public FrenziedBlackDrake() : base()
		{
			Id = 9461 ;
			Name = "Frenzied Black Drake" ;
			Guild = "Cyrus's Minion" ;
			Model = 6374;
			Level = RandomLevel( 52, 54 );
			AttackSpeed= 1143 ;
			BoundingRadius = 1.0f ;
			CombatReach = 3.0f ;
			BaseHitPoints = (int)(6435*Math.Pow(1.2f,Level-52)) ;
			BaseMana = (int)(7962*Math.Pow(1.2f,Level-52)) ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x02 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.FrenziedBlackDrake, 100f ) };
		}
	}
	public class Gyth : BaseCreature
	{
		public Gyth() : base()
		{
			Id = 10339 ;
			Name = "Gyth" ;
			Guild = "Rend Blackhand's Mount" ;
			Model = 9806;
			Level = RandomLevel( 63 );
			AttackSpeed= 840 ;
			BoundingRadius = 1.0f ;
			CombatReach = 2.0f ;
			BaseHitPoints = 120702 ;
			BaseMana = 1000 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(4f+3.8f*Level,4f+4.5*Level); 
			Size = 1.0f;
			Speed = 2.97f ;
			WalkSpeed = 2.97f ;
			RunSpeed = 5.97f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0801000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Gyth, 100f ) };
		}
	}
	public class Hazzas : BaseCreature
	{
		public Hazzas() : base()
		{
			Id = 5722 ;
			Name = "Hazzas" ;
			Model = 9584;
			Level = RandomLevel( 53 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.95f ;
			CombatReach = 3.9f ;
			BaseHitPoints = 6315 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.3f;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Hazzas, 100f ) };
		}
	}
	public class Hematos : BaseCreature
	{
		public Hematos() : base()
		{
			Id = 8976 ;
			Name = "Hematos" ;
			Model = 6369;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 12315 ;
			BaseMana = 9704 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);	
			Size = 1.5f;
			Speed = 4.21f ;
			WalkSpeed = 4.21f ;
			RunSpeed = 7.21f ;
			Elite = 2 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Hematos, 100f ) };
		}
	}
	public class Hematus : BaseCreature
	{
		public Hematus() : base()
		{
			Id = 2759 ;
			Name = "Hematus" ;
			Model = 6377;
			Level = RandomLevel( 50, 57 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.95f ;
			CombatReach = 3.9f ;
			BaseHitPoints = (int)(6315*Math.Pow(1.2f,Level-50)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.3f;
			Speed = 3.97f ;
			WalkSpeed = 3.97f ;
			RunSpeed = 6.97f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Hematus, 100f ) };
		}
	}
	public class Jade : BaseCreature
	{
		public Jade() : base()
		{
			Id = 1063 ;
			Name = "Jade" ;
			Model = 7975 ;
			Level = RandomLevel( 47 );
			AttackSpeed= 1213 ;
			BoundingRadius = 0.51f ;
			CombatReach = 5.91f ;
			BaseHitPoints = 8715 ;
			BaseMana = 4761 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);	
			Size = 1.0f;
			Speed = 3.54f ;
			WalkSpeed = 3.54f ;
			RunSpeed = 6.54f ;
			Elite = 2 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Jade, 100f ) };
		}
	}
	public class Lethlas : BaseCreature
	{
		public Lethlas() : base()
		{
			Id = 5312 ;
			Name = "Lethlas" ;
			Model = 7553;
			Level = RandomLevel( 62 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 7568 ;
			BaseMana = 9315 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(2f+3.8f*Level,2f+4.5*Level); 
			Size = 1.5f;
			Speed = 3f ;
			WalkSpeed = 3f ;
			RunSpeed = 6f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0800000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Lethlas, 100f ) };
		}
	}
	public class Manaclaw : BaseCreature
	{
		public Manaclaw() : base()
		{
			Id = 10663 ;
			Name = "Manaclaw" ;
			Model = 9996;
			Level = RandomLevel( 58 );
			AttackSpeed= 1085 ;
			BoundingRadius = 1.0f ;
			CombatReach = 2.0f ;
			BaseHitPoints = 7038 ;
			BaseMana = 8715 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4.05f ;
			WalkSpeed = 4.05f ;
			RunSpeed = 7.05f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x010024 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Manaclaw, 100f ) };
		}
	}
	public class Morphaz : BaseCreature
	{
		public Morphaz() : base()
		{
			Id = 5719 ;
			Name = "Morphaz" ;
			Model = 7975;
			Level = RandomLevel( 52 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 6195 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.96f ;
			WalkSpeed = 3.96f ;
			RunSpeed = 6.96f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Morphaz, 100f ) };
		}
	}
	public class Narillasanz : BaseCreature
	{
		public Narillasanz() : base()
		{
			Id = 2447 ;
			Name = "Narillasanz" ;
			Model = 6371;
			Level = RandomLevel( 44 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 8000 ;
			BaseMana = 2966 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(60.2f*Level);
			Block=Level+40;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);	
			Size = 1.0f;
			Speed = 3.87f ;
			WalkSpeed = 3.87f ;
			RunSpeed = 6.87f ;
			Elite = 2 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 18435, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Narillasanz, 100f ) };
		}
	}
	public class Occulus : BaseCreature
	{
		public Occulus() : base()
		{
			Id = 8196 ;
			Name = "Occulus" ;
			Model = 8317;
			Level = RandomLevel( 50 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 5955 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 2.97f ;
			WalkSpeed = 2.97f ;
			RunSpeed = 5.97f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Occulus, 100f ) };
		}
	}
	public class Onyxia : BaseCreature
	{
		public Onyxia() : base()
		{
			Id = 10184 ;
			Name = "Onyxia" ;
			Model = 8570;
			Level = RandomLevel( 63 );
			AttackSpeed= 2000 ;
			BoundingRadius = 5.372000f ;
			CombatReach = 23.0f ;
			BaseHitPoints = 35000 ;
			BaseMana = 3580 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(21.2f+3.8f*Level,21.2f+4.5*Level); 
			Size = 2.0f;
			Speed = 3.5f ;
			WalkSpeed = 3.5f ;
			RunSpeed = 6.5f ;
			Elite = 3 ;
			ResistFire = 8*Level ;
			NpcFlags = 0 ; Flags1 = 0x0C0811000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Onyxia, 100f ) };
		}
	}
	public class Phantim : BaseCreature
	{
		public Phantim() : base()
		{
			Id = 5314 ;
			Name = "Phantim" ;
			Model = 7553;
			Level = RandomLevel( 62 );
			AttackSpeed= 1050 ;
			BoundingRadius = 1.00f ;
			CombatReach = 2.0f ;
			BaseHitPoints = 7518 ;
			BaseMana = 9315 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1.0f+3.8f*Level,1.0f+4.5*Level); 
			Size = 2.0f;
			Speed = 4.0f ;
			WalkSpeed = 4.0f ;
			RunSpeed = 7.0f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0800000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Phantim, 100f ) };
		}
	}
	public class RogueBlackDrake : BaseCreature
	{
		public RogueBlackDrake() : base()
		{
			Id = 14388 ;
			Name = "Rogue Black Drake" ;
			Model = 6374;
			Level = RandomLevel( 50, 52 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = (int)(6315*Math.Pow(1.2f,Level-50)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 3.36f ;
			WalkSpeed = 3.36f ;
			RunSpeed = 6.36f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.RogueBlackDrake, 100f ) };
		}
	}
	public class Rothos : BaseCreature
	{
		public Rothos() : base()
		{
			Id = 5718 ;
			Name = "Rothos" ;
			Model = 7553;
			Level = RandomLevel( 62 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 7518 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.5f;
			Speed = 4.09f ;
			WalkSpeed = 4.09f ;
			RunSpeed = 7.09f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0800000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Rothos, 100f ) };
		}
	}
	public class ScaldingDrake : BaseCreature
	{
		public ScaldingDrake() : base()
		{
			Id = 7045 ;
			Name = "Scalding Drake" ;
			Model = 9585;
			Level = RandomLevel( 53, 55 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.725f ;
			CombatReach = 3.45f ;
			BaseHitPoints = (int)(6395*Math.Pow(1.2f,Level-53)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.15f;
			Speed = 3.99f ;
			WalkSpeed = 3.99f ;
			RunSpeed = 6.99f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.ScaldingDrake, 100f ) };
		}
	}
	public class ScorchedGuardian : BaseCreature
	{
		public ScorchedGuardian() : base()
		{
			Id = 2726 ;
			Name = "Scorched Guardian" ;
			Model = 9586;
			Level = RandomLevel( 43, 45 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.275f ;
			CombatReach = 2.55f ;
			BaseHitPoints = (int)(5049*Math.Pow(1.2f,Level-43)) ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 0.85f;
			Speed = 3.87f ;
			WalkSpeed = 3.87f ;
			RunSpeed = 6.87f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x04004 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.ScorchedGuardian, 100f ) };
		}
	}
	public class Scryer : BaseCreature
	{
		public Scryer() : base()
		{
			Id = 10664 ;
			Name = "Scryer" ;
			Model = 6373;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.0f ;
			CombatReach = 0.8f ;
			BaseHitPoints = 7158 ;
			BaseMana = 8865 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4.06f ;
			WalkSpeed = 4.06f ;
			RunSpeed = 7.06f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = (int)NpcActions.Dialog ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Friend;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Scryer, 100f ) };	 
		} // need make quest -> nf*
	}
	public class SearscaleDrake : BaseCreature
	{
		public SearscaleDrake() : base()
		{
			Id = 7046 ;
			Name = "Searscale Drake" ;
			Model = 6377;
			Level = RandomLevel( 57 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.95f ;
			CombatReach = 3.9f ;
			BaseHitPoints = 6678 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.3f;
			Speed = 4.01f ;
			WalkSpeed =  4.01f ;
			RunSpeed =  7.01f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.SearscaleDrake, 100f ) };
		}
	}
	public class ShadeofEranikus : BaseCreature
	{
		public ShadeofEranikus() : base()
		{
			Id = 5709 ;
			Name = "Shade of Eranikus" ;
			Model = 7806;
			Level = RandomLevel( 55 );
			AttackSpeed= 2000 ;
			BoundingRadius = 0.8f ;
			CombatReach = 8.0f ;
			BaseHitPoints = 7435 ;
			BaseMana = 7962 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(2f+3.8f*Level,2f+4.5*Level); 
			Size = 0.8f;
			Speed = 3.99f ;
			WalkSpeed =  3.99f ;
			RunSpeed =  6.99f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			//LearnSpell( 1090, SpellsTypes.Offensive );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.ShadeofEranikus, 100f ) };
		}
	}
	public class Somnus : BaseCreature
	{
		public Somnus() : base()
		{
			Id = 12900 ;
			Name = "Somnus" ;
			Model = 7553;
			Level = RandomLevel( 62 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2.25f ;
			CombatReach = 4.5f ;
			BaseHitPoints = 14904 ;
			BaseMana = 8540 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(2f+3.8f*Level,2f+4.5*Level); 
			Size = 1.5f;
			Speed = 4.09f ;
			WalkSpeed =  4.09f ;
			RunSpeed =  7.09f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
/*		LearnSpell( 12533, SpellsTypes.Offensive );
			LearnSpell( 12884, SpellsTypes.Offensive );
			LearnSpell( 12891, SpellsTypes.Offensive );
			LearnSpell( 16359, SpellsTypes.Offensive );
			LearnSpell( 20667, SpellsTypes.Offensive );*/
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Somnus, 100f ) };
		}
	}
	public class Spellmaw : BaseCreature
	{
		public Spellmaw() : base()
		{
			Id = 10662 ;
			Name = "Spellmaw" ;
			Model = 9995;
			Level = RandomLevel( 56 );
			AttackSpeed= 2000 ;
			BoundingRadius = 1.5f ;
			CombatReach = 3.0f ;
			BaseHitPoints = 6798 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.0f;
			Speed = 4.02f ;
			WalkSpeed =  4.02f ;
			RunSpeed =  7.02f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Spellmaw, 100f ) };
		}
	}
	public class TeremustheDevourer : BaseCreature
	{
		public TeremustheDevourer() : base()
		{
			Id = 7846 ;
			Name = "Teremus the Devourer" ;
			Model = 6378;
			Level = RandomLevel( 56 );
			AttackSpeed= 2000 ;
			BoundingRadius = 2.625f ;
			CombatReach = 5.25f ;
			BaseHitPoints = 271062 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(5f+3.8f*Level,5f+4.5*Level); 
			Size = 1.75f;
			Speed = 2.97f ;
			WalkSpeed =  2.97f ;
			RunSpeed =  5.97f ;
			Elite = 3 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x080000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.TeremustheDevourer, 100f ) };
		}
	}
	public class Tick : BaseCreature 
	{ 
		public  Tick() : base() 
		{ 
			Id = 8198 ;
			Name = "Tick" ;
			Model = 8318;
			Level = RandomLevel( 52 );
			AttackSpeed= 2000;
			BoundingRadius = 1.725f ;
			CombatReach = 3.45f ;
			BaseHitPoints = 6315 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level);  
			Size = 1.15f;
			Speed = 2.97f ;
			WalkSpeed = 2.97f ;
			RunSpeed = 5.97f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x00000000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Tick, 100f ) };
		}// flying dragon
	}	
	public class VaelastrasztheCorrupt : BaseCreature
	{
		public VaelastrasztheCorrupt() : base()
		{
			Id = 13020 ;
			Name = "Vaelastrasz the Corrupt" ;
			Model = 13992;
			Level = RandomLevel( 63 );
			AttackSpeed= 2000;
			BoundingRadius = 1.0f ;
			CombatReach = 17.0f ;
			BaseHitPoints = 20000 ;
			BaseMana = 0 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(80.2f*Level);
			Block=Level+50;
			SetDamage(4f+3.8f*Level,4f+4.5*Level); 
			Size = 1.0f;
			Speed = 4f ;
			WalkSpeed = 4f ;
			RunSpeed = 7f ;
			Elite = 3 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x0C0811000 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.NoFaction;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.VaelastrasztheCorrupt, 100f ) };
		}
	}	
	public class Weaver : BaseCreature
	{
		public Weaver() : base()
		{
			Id = 5720 ;
			Name = "Weaver" ;
			Model = 6375;
			Level = RandomLevel( 51 );
			AttackSpeed= 1178 ;
			BoundingRadius = 1.725f ;
			CombatReach = 3.5f ;
			BaseHitPoints = 6075 ;
			BaseMana = 7512 ;
			Str = (int)(Level*2.75f);
			Armor = (int)(42.2f*Level);
			Block=Level+30;
			SetDamage(1f+3.8f*Level,1f+4.5*Level); 
			Size = 1.15f;
			Speed = 3.95f ;
			WalkSpeed =  3.95f ;
			RunSpeed =  6.95f ;
			Elite = 1 ;
			ResistFire = 5*Level ;
			NpcFlags = 0 ; Flags1 = 0x020 ;
			NpcType = (int)NpcTypes.Dragonkin ;
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( FlyingDragonsDrops.Weaver, 100f ) };
		}
	}	
}	