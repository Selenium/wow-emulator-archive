///////////////////////////////////////////
namespace Server.Creatures
{
	public class VilePriestessHexx : BaseCreature
	{
		public VilePriestessHexx() : base()
		{
			Model = 7121;
			Id = 7995;
			NpcType = 7;
			Level = RandomLevel( 4, 5 );
			Faction = Factions.NoFaction;
			Name = "Vile Priestess Hexx";
			AttackSpeed = 1500;
			CombatReach = 1.475000f;
			NpcFlags = 0;
			AIEngine = new EvilInteligentMonsterAI( this );
			AttackBonii( 2000, 2000 );			
			BoundingRadius = 0.561000f;
			SetDamage( 1.542857, 1.542857 );
			NpcType = 7;
			Faction = Factions.Syndicate;
			LearnSpell( 143, SpellsTypes.Offensive );
			LearnSpell( 2050, SpellsTypes.Healing );
			//BCAddon.Hp( this, ?, 4 );
		}
	}
}