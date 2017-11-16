using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class MarshalDughan : BaseNPC
	{
		public MarshalDughan() : base()
		{
			Name = "Marshal Dughan";
			Id = 240;
			Model = 1985;
			Level = RandomLevel(25);
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			AttackSpeed = 1500;
			Armor = 40*Level;
			Block = 2*Level;
			Flags1 = 0x08480046;
			NpcFlags = (int)NpcActions.Dialog;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/1.5f);
			BaseHitPoints = 350;
			BaseMana = 0;
			BoundingRadius = 0.3077550f;
			CombatReach = 1.300f;
			Speed = 3.1f;
			WalkSpeed = 3.1f;
			RunSpeed = 6.1f;
			Faction = Factions.Stormwind;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) AIEngine = new PatrolAI( this ); else AIEngine = new StandingGuardAI( this );
			//Equip( new Shortsword() );
			Equip(new BarbedClub());
			NpcType = (int)NpcTypes.Humanoid;  
			Size = 1f;
			Loots = new BaseTreasure[]{  new BaseTreasure( StormwindGuardsDrops.MarshalDughan, 100f ), new BaseTreasure(Drops.MoneyA, 100f )};
			//Quests = new BaseQuest[] { new The_Fargodeep_Mine(), new The_Jasperlode_Mine(), new Further_Concerns(), new Cloth_and_Leather_Armor(), new Westbrook_Garrison_Needs_Help(), new Manhunt() };
		}
	}
}