using Server.Items;
using Server.Quests;

namespace Server.Creatures
{
	public class EaganPeltskinner : BaseNPC
	{
		public EaganPeltskinner() : base()
		{
			AttackSpeed = 1800;
			AttackBonii( 1501, 1501 );
			BaseMana = 20;
			BoundingRadius = 0.306000f;
			SetDamage( 2.071429, 2.471429 );
			BaseHitPoints = 65;
			NpcType = 7;
			Model = 3251;
			NpcFlags = 2;
			Level = RandomLevel( 3, 3 );
			Name = "Eagan Peltskinner";
			CombatReach = 1.500000f;
			Unk3 = 7;
			Flags1 = 0x08400066;
			Faction = Factions.Alliance;
			Id = 196;
			AIEngine = new StandingNpcAI( this ); 
			//Quests = new BaseQuest[] { new Wolves_Across_the_Border() };
		}
	}
} 