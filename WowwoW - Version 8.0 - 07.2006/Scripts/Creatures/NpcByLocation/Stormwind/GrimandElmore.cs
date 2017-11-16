using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class GrimandElmore : BaseNPC
	{
		public GrimandElmore() : base()
		{
			Name = "Grimand Elmore";
			Id = 1416;
			Model = 4998;
			Level = RandomLevel(50);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 3*Level;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08480046;
			BaseMana = 0;
			BoundingRadius = 0.561000f;
			CombatReach = 0.12f;
			Size = 1f;
			Speed = 3.3f;
			WalkSpeed = 3.3f;
			RunSpeed = 6.3f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcText00="If you've come looking for the finest craftsmanship on this or any other continent in the world, then you've come to the right place!$B$BGrimand Elmore, at your service!";
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) ); 
			BCAddon.Hp( this, 750, 50 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyD , 100f )};
		}
	}
}
