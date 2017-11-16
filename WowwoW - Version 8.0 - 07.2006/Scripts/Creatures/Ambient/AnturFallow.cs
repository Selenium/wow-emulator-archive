using System;
using Server.Items;
using System.Collections;
using Server;


////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class AnturFallow: BaseCreature
	{
		public AnturFallow() : base()
		{
			Name = "Antur Fallow";
			Id = 6775;
			Model = 5506;
			Level = RandomLevel(3,3);
			Flags1=0x08400066;
			SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			AttackSpeed = 2000;
			Armor = 0;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = 0;
			 BaseHitPoints = 110;
 			BaseMana = 0;
			BoundingRadius = 1.077550f;
			CombatReach = 0.400f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Size=1.250000f;
			Faction = Factions.Horde; 
			AIEngine = new DefensiveAnimalAI( this );
			Equip( new Item( 7428, InventoryTypes.OneHand, 0, 1, 13, 3, 0, 0, 0 ) );			
			NpcType = 7;
			Unk3=1;
		}
	}
}

