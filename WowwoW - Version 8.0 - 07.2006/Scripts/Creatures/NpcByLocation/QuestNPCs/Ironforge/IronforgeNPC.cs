using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class Monty : BaseNPC
	{
		public Monty() : base()
		{
			Id = 12997;
			Level = RandomLevel( 12 );
			Name = "Monty";
			Guild = "Rat Extermination Specialist";
			NpcText00 = "Greetings $N, I am Monty.";
			Model = 5485;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class GreatfatherWinter : BaseNPC
	{
		public GreatfatherWinter() : base()
		{
			Id = 13444;
			Level = RandomLevel( 30 );
			Name = "Greatfather Winter";
			NpcText00 = "Greetings $N, I am Greatfather Winter.";
			Model = 13369;
			AttackSpeed = 1693;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0810006E;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class IronusColdsteel : BaseNPC
	{
		public IronusColdsteel() : base()
		{
			Id = 11146;
			Level = RandomLevel( 54 );
			Name = "Ironus Coldsteel";
			Guild = "Special Weapon Crafter";
			NpcText00 = "Greetings $N, I am Ironus Coldsteel.";
			Model = 10694;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7438, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class JohnTurner : BaseNPC
	{
		public JohnTurner() : base()
		{
			Id = 6175;
			Level = RandomLevel( 8 );
			Name = "John Turner";
			NpcText00 = "Greetings $N, I am John Turner.";
			Model = 4889;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.306f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class RoyalHistorianArchesonus : BaseNPC
	{
		public RoyalHistorianArchesonus() : base()
		{
			Id = 8879;
			Level = RandomLevel( 50 );
			Name = "Royal Historian Archesonus";
			NpcText00 = "Greetings $N, I am Royal Historian Archesonus.";
			Model = 8171;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 23171, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class HighTinkerMekkatorque : BaseNPC
	{
		public HighTinkerMekkatorque() : base()
		{
			Id = 7937;
			Level = RandomLevel( 63 );
			Name = "High Tinker Mekkatorque";
			Guild = "King of Gnomes";
			NpcText00 = "Greetings $N, I am High Tinker Mekkatorque.";
			Model = 7006;
			AttackSpeed = 2000;
			CombatReach = 2.07f;
			BoundingRadius = 0.42228f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08491000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0), new Item ( 21541, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class PilotLongbeard : BaseNPC
	{
		public PilotLongbeard() : base()
		{
			Id = 2092;
			Level = RandomLevel( 23 );
			Name = "Pilot Longbeard";
			Guild = "Ironforge Siege Brigade";
			NpcText00 = "Greetings $N, I am Pilot Longbeard.";
			Model = 3600;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7494, (InventoryTypes)13, 2, 4, 2, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class KlockmortSpannerspan : BaseNPC
	{
		public KlockmortSpannerspan() : base()
		{
			Id = 6169;
			Level = RandomLevel( 45 );
			Name = "Klockmort Spannerspan";
			NpcText00 = "Greetings $N, I am Klockmort Spannerspan.";
			Model = 4999;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class GrumnusSteelshaper : BaseNPC
	{
		public GrumnusSteelshaper() : base()
		{
			Id = 5164;
			Level = RandomLevel( 60 );
			Name = "Grumnus Steelshaper";
			Guild = "Armor Crafter";
			NpcText00 = "Greetings $N, I am Grumnus Steelshaper.";
			Model = 3099;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.Vendor;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7426, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 1757, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Trains = new int[] { 9955
				, 9978
			};
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	} 
	public class GrandMasonMarblesten : BaseNPC
	{
		public GrandMasonMarblesten() : base()
		{
			Id = 2790;
			Level = RandomLevel( 44 );
			Name = "Grand Mason Marblesten";
			Guild = "Royal Stonecutters Union";
			NpcText00 = "Greetings $N, I am Grand Mason Marblesten.";
			Model = 5410;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class KingMagniBronzebeard : BaseNPC
	{
		public KingMagniBronzebeard() : base()
		{
			Id = 2784;
			Level = RandomLevel( 63 );
			Name = "King Magni Bronzebeard";

			Guild = "Lord of Ironforge";
			NpcText00 = "Greetings $N, I am King Magni Bronzebeard.";
			Model = 3597;
			AttackSpeed = 2000;
			CombatReach = 2.0f;
			BoundingRadius = 0.4164f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08C91000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 23357, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 23357, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class SaraBalloo : BaseNPC
	{
		public SaraBalloo() : base()
		{
			Id = 2695;
			Level = RandomLevel( 15 );
			Name = "Sara Balloo";
			NpcText00 = "Greetings $N, I am Sara Balloo.";
			Model = 1670;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7461, (InventoryTypes)13, 2, 14, 1, 7, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.LowDrops, 100f ) };
		}
	}
	public class Dink : BaseNPC
	{
		public Dink() : base()
		{
			Id = 7312;
			Level = RandomLevel( 40 );
			Name = "Dink";
			Guild = "Mage Trainer";
			NpcText00 = "Greetings $N, I am Dink.";
			Model = 6072;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Trainer;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 1599, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Trains = new int[] { 10055
				, 10056
				, 10141
				, 10142
				, 10146
				, 10147
				, 10152
				, 10153
				, 10154
				, 10155
				, 10162
				, 10163
				, 10164
				, 10171
				, 10172
				, 10175
				, 10176
				, 10178
				, 10182
				, 10183
				, 10184
				, 10188
				, 10189
				, 10190
				, 10194
				, 10195
				, 10196
				, 10198
				, 10200
				, 10203
				, 10204
				, 10208
				, 10209
				, 10210
				, 10213
				, 10214
				, 10217
				, 10218
				, 10221
				, 10222
				, 10224
				, 10226
				, 10231
				, 1035
				, 1142
				, 11421
				, 11423
				, 11425
				, 1168
				, 1173
				, 1174
				, 1176
				, 1191
				, 1194
				, 1196
				, 1198
				, 1200
				, 1210
				, 1211
				, 1214
				, 1225
				, 1228
				, 1241
				, 1249
				, 1250
				, 1251
				, 1266
				, 1267
				, 12827
				, 12828
				, 12829
				, 13011
				, 13012
				, 13023
				, 1424
				, 1467
				, 1472
				, 1473
				, 1474
				, 1475
				, 1481
				, 16876
				, 1811
				, 1830
				, 1851
				, 2124
				, 2125
				, 2141
				, 2142
				, 2143
				, 2858
				, 3128
				, 3142
				, 3553
				, 3576
				, 3577
				, 3578
				, 3579
				, 3580
				, 3581
				, 5146
				, 5147
				, 5148
				, 5499
				, 5507
				, 5565
				, 5566
				, 6128
				, 6130
				, 6132
				, 6142
				, 6144
				, 665
				, 7323
				, 8403
				, 8404
				, 8405
				, 8409
				, 8410
				, 8411
				, 8414
				, 8415
				, 8420
				, 8421
				, 8425
				, 8426
				, 8428
				, 8440
				, 8441
				, 8442
				, 8447
				, 8448
				, 8449
				, 8452
				, 8453
				, 8456
				, 8459
				, 8460
				, 8463
				, 8464
				, 8493
				, 8496
				, 8497
				, 8738
			};
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class RoettenStonehammer : BaseNPC
	{
		public RoettenStonehammer() : base()
		{
			Id = 5637;
			Level = RandomLevel( 40 );
			Name = "Roetten Stonehammer";
			Guild = "Reclaimers Inc.";
			NpcText00 = "Greetings $N, I am Roetten Stonehammer.";
			Model = 3756;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 3502, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class KromStoutarm : BaseNPC
	{
		public KromStoutarm() : base()
		{
			Id = 6294;
			Level = RandomLevel( 20 );
			Name = "Krom Stoutarm";
			NpcText00 = "Greetings $N, I am Krom Stoutarm.";
			Model = 4988;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class HighExplorerMagellas : BaseNPC
	{
		public HighExplorerMagellas() : base()
		{
			Id = 5387;
			Level = RandomLevel( 60 );
			Name = "High Explorer Magellas";
			Guild = "Explorers' League";
			NpcText00 = "Greetings $N, I am High Explorer Magellas.";
			Model = 3596;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 22367, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class PilotXiggsFuselighter : BaseNPC
	{
		public PilotXiggsFuselighter() : base()
		{
			Id = 8392;
			Level = RandomLevel( 45 );
			Name = "Pilot Xiggs Fuselighter";
			NpcText00 = "Greetings $N, I am Pilot Xiggs Fuselighter.";
			Model = 7598;
			AttackSpeed = 2100;
			CombatReach = 0.8f;
			BoundingRadius = 0.561f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x0480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC , 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	public class Tymor : BaseNPC
	{
		public Tymor() : base()
		{
			Id = 8507;
			Level = RandomLevel( 35 );
			Name = "Tymor";
			NpcText00 = "Greetings $N, I am Tymor.";
			Model = 7805;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class LibrarianMaePaledust : BaseNPC
	{
		public LibrarianMaePaledust() : base()
		{
			Id = 3979;
			Level = RandomLevel( 30 );
			Name = "Librarian Mae Paledust";
			Guild = "Explorers' League";
			NpcText00 = "Greetings $N, I am Librarian Mae Paledust.";
			Model = 2049;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 23321, (InventoryTypes)13, 2, 14, 1, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class GerrigBonegrip : BaseNPC
	{
		public GerrigBonegrip() : base()
		{
			Id = 2786;
			Level = RandomLevel( 30 );
			Name = "Gerrig Bonegrip";
			NpcText00 = "Greetings $N, I am Gerrig Bonegrip.";
			Model = 3599;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 6469, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class ProspectorStormpike : BaseNPC
	{
		public ProspectorStormpike() : base()
		{
			Id = 1356;
			Level = RandomLevel( 30 );
			Name = "Prospector Stormpike";
			NpcText00 = "Greetings $N, I am Prospector Stormpike.";
			Model = 3594;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7493, (InventoryTypes)13, 2, 0, 1, 3, 0, 0, 0), new Item ( 10968, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class TormusDeepforge : BaseNPC
	{
		public TormusDeepforge() : base()
		{
			Id = 6031;
			Level = RandomLevel( 30 );
			Name = "Tormus Deepforge";
			NpcText00 = "Greetings $N, I am Tormus Deepforge.";
			Model = 4950;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class LagoBlackwrench : BaseNPC
	{
		public LagoBlackwrench() : base()
		{
			Id = 6120;
			Level = RandomLevel( 30 );
			Name = "Lago Blackwrench";
			NpcText00 = "Greetings $N, I am Lago Blackwrench.";
			Model = 4865;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class Gnoarn : BaseNPC
	{
		public Gnoarn() : base()
		{
			Id = 6569;
			Level = RandomLevel( 20 );
			Name = "Gnoarn";
			NpcText00 = "Greetings $N, I am Gnoarn.";
			Model = 5377;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7439, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB , 100f )
				, new BaseTreasure( WorldDrops.MediumDrops, 100f ) };
		}
	}
	public class HighPriestRohan : BaseNPC
	{
		public HighPriestRohan() : base()
		{
			Id = 11406;
			Level = RandomLevel( 60 );
			Name = "High Priest Rohan";
			Guild = "Priest Trainer";
			NpcText00 = "Greetings $N, I am High Priest Rohan.";
			Model = 11053;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Trainer;
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Trains = new int[] { 10877
				, 10878
				, 10883
				, 10889
				, 10895
				, 10902
				, 10903
				, 10910
				, 10913
				, 10918
				, 10930
				, 10935
				, 10939
				, 10948
				, 1254
				, 1280
				, 1288
				, 1424
				, 15457
				, 15459
				, 17317
				, 19315
				, 19322
				, 19328
				, 19334
				, 19342
				, 19347
				, 19354
				, 19359
				, 2065
				, 2069
				, 3128
				, 6062
				, 6083
				, 6386
				, 8111
				, 8738
				, 9477
				, 9486
				, 9593
			};
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class LarisGeardawdle : BaseNPC
	{
		public LarisGeardawdle() : base()
		{
			Id = 9616;
			Level = RandomLevel( 50 );
			Name = "Laris Geardawdle";
			NpcText00 = "Greetings $N, I am Laris Geardawdle.";
			Model = 8829;
			AttackSpeed = 2000;
			CombatReach = 1.07f;
			BoundingRadius = 0.3519f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 21376, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class MistinaSteelshield : BaseNPC
	{
		public MistinaSteelshield() : base()
		{
			Id = 14723;
			Level = RandomLevel( 35 );
			Name = "Mistina Steelshield";
			Guild = "Ironforge Cloth Quartermaster";
			Model = 14754;
			AttackSpeed = 1623;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class BubuloAcerbus : BaseNPC
	{
		public BubuloAcerbus() : base()
		{
			Id = 14724;
			Level = RandomLevel( 35 );
			Name = "Bubulo Acerbus";
			Guild = "Ironforge Cloth Quartermaster";
			Model = 14752;
			AttackSpeed = 1623;
			CombatReach = 1.15f;
			BoundingRadius = 0.85f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 24483, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyB, 100f )
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
	public class CourierHammerfall : BaseNPC
	{
		public CourierHammerfall() : base()
		{
			Id = 10877;
			Level = RandomLevel( 3 );
			Name = "Courier Hammerfall";
			NpcText00 = "Greetings $N, I am Courier Hammerfall.";
			Model = 10184;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.347f;
			Armor = MobArmorHP.GetMobArmor( Level );
			Size = 1.0f;
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 5f;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level );
			SetDamage( (0.8f*AttackSpeed/1000f)*Level, (1.1f*AttackSpeed/1000f)*Level );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x080000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.IronForge;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyA , 100f )
				, new BaseTreasure( WorldDrops.BeginnerDrops, 100f ) };
		}
	}
	
	
}