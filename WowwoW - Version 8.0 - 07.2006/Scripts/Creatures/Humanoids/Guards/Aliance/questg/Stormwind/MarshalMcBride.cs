using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MarshalMcBride : BaseNPC
	{
		public MarshalMcBride(): base()
		{
			Name = "Marshal McBride";
			Id = 197;
			Model = 1859;
			Level = RandomLevel(20);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 20*Level;
			Block = 2*Level;
			Flags1 = 0x08080066;			
			NpcFlags = (int)NpcActions.Dialog ;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 1250;
			BaseMana = 0;
			BoundingRadius = 1.7077550f;
			CombatReach = 1.500f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			//Elite=1;
			NpcText00="Hey citizen! You look like a stout one. We guards are spread a little thin out here, and I could use you help...";
			Equip( new Longsword(), new StormwindGuardShield() ); 
			Loots = new BaseTreasure[]{ new BaseTreasure(StormwindGuardsDrops.MarshalMcBride, 100f ), new BaseTreasure(Drops.MoneyB, 100f )};
			//Quests = new BaseQuest[] { new Kobold_Camp_Cleanup(), new Investigate_Echo_Ridge(), new Skirmish_at_Echo_Ridge(), new Report_to_Goldshire() };
		}
	}
}
