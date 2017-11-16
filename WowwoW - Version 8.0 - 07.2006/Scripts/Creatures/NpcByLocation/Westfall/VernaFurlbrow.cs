using System;
using Server.Items;
using HelperTools;

namespace Server.Creatures
{
	public class VernaFurlbrow : BaseNPC
	{
		public VernaFurlbrow() : base()
		{
			Name = "Verna Furlbrow";
			Id = 238;
			Model = 1692;
			Level = RandomLevel(20);
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
			Speed = 3f;
			WalkSpeed = 3f;
			RunSpeed = 6f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Stormwind;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Dialog;
			Equip( new Item( 7483, InventoryTypes.MainGauche, 2, 7, 1, 3, 0, 0, 0 ), new Item( 1684, InventoryTypes.Shield, 4, 6, 1, 4, 0, 0, 0 ) ); 
			BCAddon.Hp( this, 410, 20 );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyB , 100f )};
		}
	}
}

