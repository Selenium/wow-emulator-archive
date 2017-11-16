using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Creatures
{
	public class BaronSilverlaine : BaseCreature
	{
		public BaronSilverlaine() : base()
		{
			Name = "Baron Silverlaine";
			Id = 3887;
			Model = 3222;
			Level = RandomLevel(22,24);
			SetDamage(16f,89f);
			AttackSpeed = 1000;
			Armor = 145;
			Block = 14;
			ResistArcane = 25;
			ResistFire = 25;
			ResistFrost = 25;
			ResistHoly = 25;
			ResistNature = 25;
			ResistShadow = 25;
			BaseHitPoints = 1324;
			Size = 1f;
			Speed = 1f;
			WalkSpeed = 2f;
			RunSpeed = 3f;
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 6;
		}
	}
}
