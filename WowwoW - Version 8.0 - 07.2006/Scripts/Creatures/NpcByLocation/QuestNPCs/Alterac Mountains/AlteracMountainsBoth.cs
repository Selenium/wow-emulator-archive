using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	
	public class HighPriestessMacDonnell : BaseNPC
	{
		public HighPriestessMacDonnell() : base()
		{
			Id = 11053;
			Level = RandomLevel( 60 );
			Name = "High Priestess MacDonnell";
			NpcText00 = "The Scourge's plague still dominates the zone, and we have a long way to go before the plague will be altered enough to affect them.  Collect the necessary resources and help out the war effort!";
			Model = 10549;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.208f;
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
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 22802, (InventoryTypes)17, 2, 10, 2, 2, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	public class BathrahTheWindwatcher : BaseNPC
	{
		public BathrahTheWindwatcher() : base()
		{
			Id = 6176;
			Level = RandomLevel( 35 );
			Name = "Bath'rah the Windwatcher";
			NpcText00 = "Greetings $N, I am Bath'rah the Windwatcher.";
			Model = 4954;
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
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 24016, (InventoryTypes)17, 2, 10, 2, 1, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f ) 
				, new BaseTreasure( WorldDrops.AdvancedDrops, 100f ) };
		}
	}
}