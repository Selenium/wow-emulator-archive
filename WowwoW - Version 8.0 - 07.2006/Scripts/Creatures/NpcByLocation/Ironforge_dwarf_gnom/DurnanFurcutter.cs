using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class DurnanFurcutter : BaseCreature
	{
		public DurnanFurcutter() : base()
		{
			Name = "Durnan Furcutter";
			Guild = "Cloth & Leather Armor Merchant";
			Id = 836;
			Model = 3406;
			Level = RandomLevel(5);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 1500;
			Armor = 200;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x08080066;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.IronForge;
			AIEngine = new StandingNpcAI( this );
			NpcType = 7;
			NpcFlags = (int)NpcActions.Vendor ; 
Sells = new Item[] {  new CrackedLeatherBelt()
 , new CrackedLeatherBoots()
 , new CrackedLeatherBracers()
 , new CrackedLeatherGloves()
 , new CrackedLeatherPants()
 , new CrackedLeatherVest()
 , new ThinClothArmor()
 , new ThinClothBelt()
 , new ThinClothBracers()
 , new ThinClothGloves()
 , new ThinClothPants()
 , new ThinClothShoes()

	};			 
			NpcText00 = "I sell the finest cloth and leather garb this side of the valley!";
			Equip( new Item( 7439, InventoryTypes.MainGauche, 2, 4, 2, 3, 0, 0, 0 ) );
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) };
			/*****************************/
			BCAddon.Hp( this, 60, 5 );
			/*****************************/
		}
	}
}

