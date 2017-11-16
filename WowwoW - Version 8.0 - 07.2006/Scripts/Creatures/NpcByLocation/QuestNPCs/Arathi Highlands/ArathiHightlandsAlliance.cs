using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class CaptainNials : BaseNPC
	{
		public CaptainNials() : base()
		{
			Id = 2700;
			Level = RandomLevel( 41 );
			Name = "Captain Nials";
			NpcText00 = "Greetings $N, I am Captain Nials.";
			Model = 4147;
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
			NpcFlags = (int)NpcActions.Dialog;
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item ( 7483, (InventoryTypes)13, 2, 7, 1, 3, 0, 0, 0), new Item ( 18690, (InventoryTypes)14, 4, 6, 1, 4, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyC, 100f )
				, new BaseTreasure( WorldDrops.HighDrops, 100f ) };
		}
	}
	
}