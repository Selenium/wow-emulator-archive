//originally Scripted By DiScS Converter
//changed by Volhv: 02.10.05
using System;
using Server.Items;

////////////////////
namespace Server.Creatures
{

	public class InnkeeperFarley : BaseNPC 
	{ 
		public  InnkeeperFarley() : base() 
		{ 
			Model = 1291;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Farley" ;
			Flags1 = 0x08480046 ;
			Id = 295 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 624 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
		}
	}

	public class InnkeeperBelm : BaseNPC 
	{ 
		public  InnkeeperBelm() : base() 
		{ 
			Model = 3434;
			AttackSpeed= 2000;
			BoundingRadius = 0.381700f ;
			Name = "Innkeeper Belm" ;
			Flags1 = 0x08480046 ;
			Id = 1247 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 344 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.65f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ThunderAle()
								   , new RhapsodyMalt()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
		}
	}

	public class InnkeeperHelbrek : BaseNPC
	{ 
		public  InnkeeperHelbrek() : base() 
		{ 
			Model = 3479;
			AttackSpeed= 1500;
			BoundingRadius = 0.347000f ;
			Name = "Innkeeper Helbrek" ;
			Flags1 = 0x0480046 ;
			Id = 1464 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1024 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 27, 35 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new FlagonOfMead()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperAnderson : BaseNPC 
	{ 
		public  InnkeeperAnderson() : base() 
		{ 
			Model = 3688;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Anderson" ;
			Flags1 = 0x08480046 ;
			Id = 2352 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperShay : BaseNPC 
	{ 
		public  InnkeeperShay() : base() 
		{ 
			Model = 3675;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Innkeeper Shay" ;
			Flags1 = 0x08400046 ;
			Id = 2388 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 6 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new SouthshoreStout()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Undercity;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );


		}
	}

	public class InnkeeperBoorandPlainswind : BaseNPC
	{ 
		public  InnkeeperBoorandPlainswind() : base() 
		{ 
			Model = 3881;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Innkeeper Boorand Plainswind" ;
			Flags1 = 0x08480046 ;
			Id = 3934 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 664 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 4.05f ;
			SetDamage ( 17, 22 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ShinyRedApple()
								   , new TelAbimBanana()
								   , new SnapvineWatermelon()
								   , new GoldenbarkApple()
								   , new MoonHarvestPumpkin()
								   , new MorningGloryDew()
								   , new DeepFriedPlantains()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );


		}
	}

	public class InnkeeperFirebrew : BaseNPC 
	{ 
		public  InnkeeperFirebrew() : base() 
		{ 
			Model = 3047;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Innkeeper Firebrew" ;
			Flags1 = 0x08480046 ;
			Id = 5111 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new FlaskOfPort()
								   , new FlagonOfMead()
								   , new JugOfBourbon()
								   , new SkinOfDwarvenStout()
								   , new BottleOfPinotNoir()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperRenee : BaseNPC 
	{ 
		public  InnkeeperRenee() : base() 
		{ 
			Model = 8190;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Innkeeper Renee" ;
			Flags1 = 0x08400046 ;
			Id = 5688 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 6 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new MorningGloryDew()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperJanene : BaseNPC 
	{ 
		public  InnkeeperJanene() : base() 
		{ 
			Model = 5429;
			AttackSpeed= 1000;
			BoundingRadius = 0.187200f ;
			Name = "Innkeeper Janene" ;
			Flags1 = 0x08480046 ;
			Id = 6272 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.35f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperBrianna : BaseNPC 
	{ 
		public  InnkeeperBrianna() : base() 
		{ 
			Model = 5407;
			AttackSpeed= 1000;
			BoundingRadius = 0.208000f ;
			Name = "Innkeeper Brianna" ;
			Flags1 = 0x08480046 ;
			Id = 6727 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 824 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 21, 28 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new MorningGloryDew()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperHearthstove : BaseNPC 
	{ 
		public  InnkeeperHearthstove() : base() 
		{ 
			Model = 5434;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Innkeeper Hearthstove" ;
			Flags1 = 0x08480046 ;
			Id = 6734 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 624 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 16, 21 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperSaelienne : BaseNPC 
	{ 
		public  InnkeeperSaelienne() : base() 
		{ 
			Model = 5439;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Saelienne" ;
			Flags1 = 0x08480046 ;
			Id = 6735 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ShinyRedApple()
								   , new TelAbimBanana()
								   , new SnapvineWatermelon()
								   , new GoldenbarkApple()
								   , new MoonHarvestPumpkin()
								   , new MorningGloryDew()
								   , new DeepFriedPlantains()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}


	public class InnkeeperKeldamyr : BaseNPC 
	{ 
		public  InnkeeperKeldamyr() : base() 
		{ 
			Model = 5440;
			AttackSpeed= 2000;
			BoundingRadius = 0.389000f ;
			Name = "Innkeeper Keldamyr" ;
			Flags1 = 0x08480046 ;
			Id = 6736 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
		}
	}

	public class InnkeeperShaussiy : BaseNPC 
	{ 
		public  InnkeeperShaussiy() : base() 
		{ 
			Model = 5441;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Shaussiy" ;
			Flags1 = 0x08480046 ;
			Id = 6737 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperKimlya : BaseNPC 
	{ 
		public  InnkeeperKimlya() : base() 
		{ 
			Model = 5442;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Kimlya" ;
			Flags1 = 0x08480046 ;
			Id = 6738 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperBates : BaseNPC 
	{ 
		public  InnkeeperBates() : base() 
		{ 
			Model = 7633;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Innkeeper Bates" ;
			Flags1 = 0x08400046 ;
			Id = 6739 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 6 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ForestMushroomCap()
								   , new RedSpeckledMushroom()
								   , new SpongyMorel()
								   , new DeliciousCaveMold()
								   , new RawBlackTruffle()
								   , new MorningGloryDew()
								   , new DriedKingBolete()
							   } ;
			Faction = Factions.Undercity;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };

			AIEngine = new StandingNpcAI( this );
		}
	}
	public class InnkeeperAllison : BaseNPC 
	{ 
		public  InnkeeperAllison() : base() 
		{ 
			Model = 5444;
			AttackSpeed= 1000;
			BoundingRadius = 0.208000f ;
			Name = "Innkeeper Allison" ;
			Flags1 = 0x08480046 ;
			Id = 6740 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperNorman : BaseNPC 
	{ 
		public  InnkeeperNorman() : base() 
		{ 
			Model = 5449;
			AttackSpeed= 2000;
			BoundingRadius = 0.383000f ;
			Name = "Innkeeper Norman" ;
			Flags1 = 0x018480046 ;
			Id = 6741 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Undercity;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperPala : BaseNPC 
	{ 
		public  InnkeeperPala() : base() 
		{ 
			Model = 5487;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Innkeeper Pala" ;
			Flags1 = 0x08480046 ;
			Id = 6746 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 3.75f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}
	public class InnkeeperKauth : BaseNPC 
	{ 
		public  InnkeeperKauth() : base() 
		{ 
			Model = 5486;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Innkeeper Kauth" ;
			Flags1 = 0x08480046 ;
			Id = 6747 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 4.05f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperTrelayne : BaseNPC 
	{ 
		public  InnkeeperTrelayne() : base() 
		{ 
			Model = 8191;
			AttackSpeed= 1000;
			BoundingRadius = 0.208000f ;
			Name = "Innkeeper Trelayne" ;
			Flags1 = 0x08480046 ;
			Id = 6790 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new IridescentPearl()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperWiley : BaseNPC 
	{ 
		public  InnkeeperWiley() : base() 
		{ 
			Model = 7153;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Wiley" ;
			Flags1 = 0x08080006 ;
			Id = 6791 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 35 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new MorningGloryDew()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Ratchet;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperSkindle : BaseNPC 
	{ 
		public  InnkeeperSkindle() : base() 
		{ 
			Model = 7105;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Skindle" ;
			Flags1 = 0x08080046 ;
			Id = 6807 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 46 );
			NpcType = 7 ;
			BaseHitPoints = 1865 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 50, 65 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new MorningGloryDew()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.BootyBay;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperGrosk : BaseNPC 
	{ 
		public  InnkeeperGrosk() : base() 
		{ 
			Model = 5705;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Innkeeper Grosk" ;
			Flags1 = 0x08480046 ;
			Id = 6928 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1064 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 28, 36 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}
	public class InnkeeperGryshka : BaseNPC 
	{ 
		public  InnkeeperGryshka() : base() 
		{ 
			Model = 5706;
			AttackSpeed= 1739;
			BoundingRadius = 0.236000f ;
			Name = "Innkeeper Gryshka" ;
			Flags1 = 0x08480046 ;
			Id = 6929 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}
	public class InnkeeperKarakul : BaseNPC 
	{ 
		public  InnkeeperKarakul() : base() 
		{ 
			Model = 5707;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Innkeeper Karakul" ;
			Flags1 = 0x08400046 ;
			Id = 6930 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Ogrimmar;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperByula : BaseNPC 
	{ 
		public  InnkeeperByula() : base() 
		{ 
			Model = 6550;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Innkeeper Byula" ;
			Flags1 = 0x08480046 ;
			Id = 7714 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 4.05f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ShinyRedApple()
								   , new TelAbimBanana()
								   , new SnapvineWatermelon()
								   , new GoldenbarkApple()
								   , new MoonHarvestPumpkin()
								   , new MorningGloryDew()
								   , new DeepFriedPlantains()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperJayka : BaseNPC 
	{ 
		public  InnkeeperJayka() : base() 
		{ 
			Model = 6551;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Innkeeper Jayka" ;
			Flags1 = 0x08480046 ;
			Id = 7731 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperFizzgrimble : BaseNPC 
	{ 
		public  InnkeeperFizzgrimble() : base() 
		{ 
			Model = 7346;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Fizzgrimble" ;
			Flags1 = 0x080006 ;
			Id = 7733 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Gadgetzan;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperShyria : BaseNPC 
	{ 
		public  InnkeeperShyria() : base() 
		{ 
			Model = 6553;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Shyria" ;
			Flags1 = 0x08480046 ;
			Id = 7736 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}
	public class InnkeeperGreul : BaseNPC 
	{ 
		public  InnkeeperGreul() : base() 
		{ 
			Model = 6554;
			AttackSpeed= 2000;
			BoundingRadius = 0.872500f ;
			Name = "Innkeeper Greul" ;
			Flags1 = 0x08480046 ;
			Id = 7737 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 3.75f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperThulfram : BaseNPC 
	{ 
		public  InnkeeperThulfram() : base() 
		{ 
			Model = 6568;
			AttackSpeed= 2000;
			BoundingRadius = 0.347000f ;
			Name = "Innkeeper Thulfram" ;
			Flags1 = 0x08480046 ;
			Id = 7744 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ThunderAle()
								   , new RhapsodyMalt()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.WildHammerClan;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperHeather : BaseNPC 
	{ 
		public  InnkeeperHeather() : base() 
		{ 
			Model = 8185;
			AttackSpeed= 1000;
			BoundingRadius = 0.208000f ;
			Name = "Innkeeper Heather" ;
			Flags1 = 0x08480046 ;
			Id = 8931 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new LongjawMudSnapper()
								   , new BristleWhiskerCatfish()
								   , new RockscaleCod()
								   , new SpottedYellowtail()
								   , new SlitherskinMackerel()
								   , new MorningGloryDew()
								   , new SpinefinHalibut()
							   } ;
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperSentinelHill : BaseNPC 
	{ 
		public  InnkeeperSentinelHill() : base() 
		{ 
			Model = 3434;
			AttackSpeed= 2001;
			BoundingRadius = 0.381700f ;
			Name = "Innkeeper SentinelHill" ;
			Flags1 = 0x08400046 ;
			Id = 8999 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 8 );
			NpcType = 10 ;
			BaseHitPoints = 344 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 0f ;
			SetDamage ( 8, 11 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 286 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ThunderAle()
								   , new RhapsodyMalt()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Beast;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperShulkar : BaseNPC 
	{ 
		public  InnkeeperShulkar() : base() 
		{ 
			Model = 8633;
			AttackSpeed= 2000;
			BoundingRadius = 0.372000f ;
			Name = "Innkeeper Shul'kar" ;
			Flags1 = 0x08480046 ;
			Id = 9356 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperAdegwa : BaseNPC 
	{ 
		public  InnkeeperAdegwa() : base() 
		{ 
			Model = 8634;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Innkeeper Adegwa" ;
			Flags1 = 0x08480046 ;
			Id = 9501 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 4.05f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperLyshaerya : BaseNPC 
	{ 
		public  InnkeeperLyshaerya() : base() 
		{ 
			Model = 10565;
			AttackSpeed= 1000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Lyshaerya" ;
			Flags1 = 0x08480046 ;
			Id = 11103 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new ToughHunkOfBread()
								   , new FreshlyBakedBread()
								   , new MoistCornbread()
								   , new MulgoreSpiceBread()
								   , new SoftBananaBread()
								   , new MorningGloryDew()
								   , new HomemadeCherryPie()
							   } ;
			Faction = Factions.Darnasus;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperSikewa : BaseNPC 
	{ 
		public  InnkeeperSikewa() : base() 
		{ 
			Model = 10564;
			AttackSpeed= 1693;
			BoundingRadius = 1.00f ;
			Name = "Innkeeper Sikewa" ;
			Flags1 = 0x08480046 ;
			Id = 11106 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 11.00f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 1503 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperAbeqwa : BaseNPC 
	{ 
		public  InnkeeperAbeqwa() : base() 
		{ 
			Model = 10653;
			AttackSpeed= 2000;
			BoundingRadius = 0.974700f ;
			Name = "Innkeeper Abeqwa" ;
			Flags1 = 0x08400046 ;
			Id = 11116 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 4.05f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new StormwindBrie()
								   , new SweetNectar()
								   , new DarnassianBleu()
								   , new FineAgedCheddar()
								   , new DalaranSharp()
								   , new DwarvenMild()
								   , new MorningGloryDew()
								   , new AlteracSwiss()
							   } ;
			Faction = Factions.ThunderBluff;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );

		}
	}

	public class InnkeeperVizzie : BaseNPC 
	{ 
		public  InnkeeperVizzie() : base() 
		{ 
			Model = 10654;
			AttackSpeed= 2000;
			BoundingRadius = 0.306000f ;
			Name = "Innkeeper Vizzie" ;
			Flags1 = 0x080006 ;
			Id = 11118 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1224 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 32, 42 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Everlook;
			Guild = "Innkeeper" ;
			AIEngine = new StandingNpcAI( this );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };


		}
	}

	public class InnkeeperKaylisk : BaseNPC 
	{ 
		public  InnkeeperKaylisk() : base() 
		{ 
			Model = 12392;
			AttackSpeed= 2000;
			BoundingRadius = 0.236000f ;
			Name = "Innkeeper Kaylisk" ;
			Flags1 = 0x08480046 ;
			Id = 12196 ; 
			Size = 1f;
			Speed = 5f ;
			WalkSpeed = 5f ;
			RunSpeed = 8f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Level = RandomLevel( 30 );
			NpcType = 7 ;
			BaseHitPoints = 1184 ;
			NpcFlags = (int)NpcActions.Dialog + (int)NpcActions.InKeeper;
			CombatReach = 1.5f ;
			SetDamage ( 31, 41 );
			NpcText00 = "Welcome to my Inn, weary traveler.What can I do for you ?" ;
			BaseMana = 0 ;
			Sells = new Item[] { new ToughJerky()
								   , new IceColdMilk()
								   , new MelonJuice()
								   , new RefreshingSpringWater()
								   , new MoonberryJuice()
								   , new SweetNectar()
								   , new HaunchOfMeat()
								   , new MuttonChop()
								   , new WildHogShank()
								   , new CuredHamSteak()
								   , new MorningGloryDew()
								   , new RoastedQuail()
							   } ;
			Faction = Factions.Ogrimmar;
			Guild = "Innkeeper" ;
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB, 100f )};//{ new BaseTreasure( LootTemplate.loottemplate100, 100f ) };
			AIEngine = new StandingNpcAI( this );
		}
	}

}