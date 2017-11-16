using System;
using Server.Items;
using System.Collections;
using Server;


////////////////////// Scarlet.cs
namespace Server.Creatures
{
	public class SquealerThornmantle: BaseCreature
	{
		public SquealerThornmantle() : base()
		{
			Name = "'Squealer' Thornmantle";
			Id = 3229;
			Model = 1254;
			Level = RandomLevel(5,5);
			SetDamage(1f+1.8f*Level,1f+2.66*Level);			
			AttackSpeed = 2000;
			Flags1=0x080000;
			Armor = 5*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level/2.5f);
/*****************************/
float step=1.1f; //step by incrase Heals in elite mobs first rang
if (Level==5)		
{
 BaseHitPoints = 210;
 BaseMana = 0;
} 
else
{
for (int i=1; i<=(Level-5); i++)
 {
  step=step*step;
 }	
 BaseHitPoints = (int)(180*(float)step);
 BaseMana = 0;
}
/*****************************/			
			BoundingRadius = 0.3077550f;
			CombatReach = 0.300f;
			Speed = 3.5f;
			WalkSpeed = 3.5f;
			RunSpeed = 6.5f;
			Faction = Factions.Monster;
			AIEngine = new BerserkerAI( this );
			NpcType = 7;
			Size=0.9f;
			Unk3=1;
			Loots = new BaseTreasure[]{  new BaseTreasure( SquealerThornmantleDrops.SquealerThornmantle, 100f )};
		}
	}
}

namespace Server
{
	public class SquealerThornmantleDrops
		{
		public static Loot[] SquealerThornmantle = new Loot[] {  new Loot( typeof( RefreshingSpringWater  ), 10.01f )
								, new Loot( typeof( SquealersBelt  ), 10.65f )
								, new Loot( typeof( FrayedRobe  ), 10.02f )
								, new Loot( typeof( RaggedLeatherBoots  ), 10.02f )
							};
		}							
}		