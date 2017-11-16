using System;
using Server.Items;
using System.Collections;
using Server;


////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class AnconaChicken: BaseCreature
	{
		public AnconaChicken() : base()
		{
			Name = "Ancona Chicken";
			Id = 7394;
			Model = 5369;
			Level = RandomLevel(1,1);
			SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			AttackSpeed = 2000;
			Armor = 0;
			Block = 0;
			Flags1=0x066;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			 Str = 0;
			 BaseHitPoints = 60;
			ManaType = 1; 
			BoundingRadius = 0.1450f;
			CombatReach = 0.400f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Horde; 	
			AIEngine = new DefensiveAnimalAI( this );
			NpcType = 1;
			Unk3=1;
		}
	}
}

