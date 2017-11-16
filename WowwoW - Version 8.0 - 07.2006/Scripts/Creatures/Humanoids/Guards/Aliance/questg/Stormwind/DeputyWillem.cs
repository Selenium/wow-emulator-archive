using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class DeputyWillem : BaseNPC
	{
		public DeputyWillem() : base()
		{
			Name = "Deputy Willem";
			Id = 823;
			Model = 2072;
			Level = RandomLevel(18);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1500;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08080066;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 210;
			BaseMana = 0;
			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
			Equip( new Shortsword() );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.DeputyWillem, 100f ), new BaseTreasure(Drops.MoneyA, 100f )};
			//Quests = new BaseQuest[] { new A_Threat_Within(), new Bounty_on_Garrick_Padfoot(), new Brotherhood_of_Thieves(), new Eagan_Peltskinner(), new Milly_Osworth() };
		}
	}
}