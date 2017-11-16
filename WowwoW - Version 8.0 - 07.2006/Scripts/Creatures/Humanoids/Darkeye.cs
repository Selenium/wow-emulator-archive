///////////////////////////////////////////
namespace Server.Creatures
{
	public class DarkeyeBonecaster : BaseCreature
	{
		public DarkeyeBonecaster() : base()
		{
			AttackBonii( 2000, 2000 );
			Level = RandomLevel( 1, 2 );// to testing purpose, RandomLevel( 7, 9 );
			BoundingRadius = 1.000000f;
			SetDamage( 2.500000, 3.200000 );
			NpcType = 6;
			Model = 11398;
			AttackSpeed = 1600;
			Name = "Darkeye Bonecaster";
			CombatReach = 1.558700f;
			Faction = Factions.Monster;
			LearnSpell( 116, SpellsTypes.Offensive );			
			LearnSpell( 2052, SpellsTypes.Healing );	
			Id = 1522;
			AIEngine = new EvilInteligentMonsterAI( this );
			//BCAddon.Hp( this, ?, 1 );
		}
	}
}