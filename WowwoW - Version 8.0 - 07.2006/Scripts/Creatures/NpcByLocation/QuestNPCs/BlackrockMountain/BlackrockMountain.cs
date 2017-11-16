using System;
using Server;
using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class LothosRiftwaker : BaseNPC
	{
		public LothosRiftwaker() : base()
		{
			Id = 14387;
			Level = RandomLevel( 60 );
			Name = "Lothos Riftwaker";
			NpcText00 = "The fabric of which our world is woven is most delicate. It merely takes some knowledge and the application of said knowledge to tear the fabric. It is thusly that rifts are born.";
			Model = 7010;
			AttackSpeed = 2000;
			CombatReach = 1.5f;
			BoundingRadius = 0.214f;
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
			Flags1 = 0x066;
			NpcType = (int)NpcTypes.Humanoid;
			Faction = Factions.Friend;
			AIEngine = new StandingGuardAI( this ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(DropsME.MoneyElite1, 100f )
				, new BaseTreasure( WorldDrops.IncredibleDrops, 100f ) };
		}
	}
	
}