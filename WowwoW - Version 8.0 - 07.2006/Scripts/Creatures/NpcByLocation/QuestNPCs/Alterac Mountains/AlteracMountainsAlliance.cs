using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class ProspectorStonehewer : BaseNPC
	{
		public ProspectorStonehewer() : base()
		{
			Id = 13816;
			Level = RandomLevel( 61 );
			Name = "Prospector Stonehewer";
			Model = 13794;
			AttackSpeed = 1260;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 23969, (InventoryTypes)17, 2, 8, 1, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( StormpikeSoldiersBlood ), 5.00f )
					}, 100f ) };
		}
	}
	public class SergeantDurgenStormpike : BaseNPC
	{
		public SergeantDurgenStormpike() : base()
		{
			Id = 13777;
			Level = RandomLevel( 58 ,59 );
			Name = "Sergeant Durgen Stormpike";
			NpcText00 = "Greetings $N, I am Sergeant Durgen Stormpike.";
			Model = 13383;
			AttackSpeed = 1084;
			CombatReach = 1.39f;
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
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 23948, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 23575, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( StormpikeSoldiersBlood ), 5.00f )
					}, 100f ) };
		}
	}
	public class LieutenantHaggerdin : BaseNPC
	{
		public LieutenantHaggerdin() : base()
		{
			Id = 13841;
			Level = RandomLevel( 61 );
			Name = "Lieutenant Haggerdin";
			Model = 13841;
			AttackSpeed = 1050;
			CombatReach = 6.25f;
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
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 23948, (InventoryTypes)13, 2, 4, 2, 3, 0, 0, 0), new Item ( 10968, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0), new Item ( 6231, (InventoryTypes)15, 2, 2, 2, 0, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( Runecloth ), 33.3f )
					, new Loot( typeof( StormpikeSoldiersBlood ), 33.3f )
					, new Loot( typeof( StormpikeLieutenantsFlesh ), 44.4f )
					, new Loot( typeof( StormpikeCommandersFlesh ), 11.1f )
					, new Loot( typeof( ArmorScraps ), 66.6f )
					}, 100f ) };
		}
	}
	public class CommanderAshlamValorfist : BaseNPC
	{
		public CommanderAshlamValorfist() : base()
		{
			Id = 10838;
			Level = RandomLevel( 61 );
			Name = "Commander Ashlam Valorfist";
			NpcText00 = "Welcome to the front lines, $c.  The Kingdom of Stormwind, with the aid of its allies, has sent me here to counter the growing threat of the Scourge.  Here at Chillwind Point, we fight for our continued survival on a daily basis.$B$BIf you've come here looking for a chance to prove yourself as a hero, then you'll find plenty of opportunities to do so... especially as we push towards Andorhal and whatever malign force that controls the Scourge there.";
			Model = 10151;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Alliance;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2466, (InventoryTypes)17, 2, 5, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class NathanielDumah : BaseNPC
	{
		public NathanielDumah() : base()
		{
			Id = 11616;
			Level = RandomLevel( 55 );
			Name = "Nathaniel Dumah";
			NpcText00 = "Greetings $N, I am Nathaniel Dumah.";
			Model = 4931;
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
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x0480006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 2469, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.AmazingDrops, 100f ) };
		}
	}
	public class WeldonBarov : BaseNPC
	{
		public WeldonBarov() : base()
		{
			Id = 11023;
			Level = RandomLevel( 60 );
			Name = "Weldon Barov";
			Guild = "House of Barov";
			NpcText00 = "Greetings $N, I am Weldon Barov.";
			Model = 10457;
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
			Elite = 1;
			BaseHitPoints = MobArmorHP.GetMobHP ( Level ) * 2;
			SetDamage( (0.8f*AttackSpeed/1000f)*(Level*(Elite+1f)), (1.2f*AttackSpeed/1000f)*(Level*(Elite+1f)) );
			BaseMana = Level * 70;
			NpcFlags = (int)NpcActions.Dialog | (int)NpcActions.SpiritHealer;
			Flags1 = 0x0480000;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Horde;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 7486, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f )
				, new BaseTreasure( new Loot[] {
					new Loot( typeof( HeadOfWeldonBarov ), 94.6f )
					}, 100f ) };
		}
	}
	
}