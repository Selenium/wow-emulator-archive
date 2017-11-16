using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MasterMathiasShaw : BaseNPC
	{
		public MasterMathiasShaw() : base()
		{
			Id = 332;
			Level = RandomLevel( 60 );
			Name = "Master Mathias Shaw";
			Guild = "Leader of SI:7";
			NpcText00 = "Welcome to SI:7 headquarters, $N.";
			Model = 1736;
			AttackSpeed = 1000;
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
			Flags1 = 0x08480046;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Stormwind;
			AIEngine = new StandingGuardAI( this ); 
			Equip( new Item ( 7433, (InventoryTypes)13, 2, 15, 1, 3, 0, 0, 0) );
			Loots = new BaseTreasure[]{ new BaseTreasure( Drops.MoneyD , 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	
}