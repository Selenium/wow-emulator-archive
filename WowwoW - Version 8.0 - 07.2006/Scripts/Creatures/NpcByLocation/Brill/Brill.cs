using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class SahvanBloodshadow : BaseCreature
	{
		public SahvanBloodshadow() : base()
		{
			Name = "Sahvan Bloodshadow";
			Id = 2314;
			Model = 3521;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 1*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x0400046;
			BaseHitPoints = 16+10*Level;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.5f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Undercity;
			AIEngine = new TravellerSalesmanAI( this );
			NpcType = 6;
			NpcFlags = 0;
			//Equip( new Item( 5010, InventoryTypes.TwoHanded, 10, 2, 17, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f )};
		}
	}
}
