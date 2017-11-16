using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class FleetMasterSeahorn : BaseNPC
	{
		public FleetMasterSeahorn() : base()
		{
			Id = 2487;
			Level = RandomLevel( 60 );
			Name = "Fleet Master Seahorn";
			Guild = "Blackwater Raiders";
			NpcText00 = "Greetings $N, I am Fleet Master Seahorn.";
			Model = 1667;
			AttackSpeed = 2000;
			CombatReach = 4.05f;
			BoundingRadius = 0.54f;
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
			Flags1 = 0x08080006;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new DefensiveAnimalAI( this );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD, 100f )				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}

}