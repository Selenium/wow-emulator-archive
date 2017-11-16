using System;
using System.Collections;
using Server;
using Server.Items;


namespace Server.Creatures
{
	public class AllianceSpiritGuide: BaseCreature 
	 { 
		public  AllianceSpiritGuide() : base() 
		{ 
			Id = 13116; 
			Model = 13336;
			Level = RandomLevel( 60 );
			AttackSpeed= 2000;
			BoundingRadius = 0.5500000f ;
			Name = "Alliance Spirit Guide" ;
			//Guild="House of Barov";
			Flags1 = 0x080000;			
			Size = 1.0f;
			Speed = 4.05f ;
			WalkSpeed = 4.05f ;
			RunSpeed = 7.05f ;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			ResistShadow = 0;
			Str = (int)(Level*2.5f);
			NpcType = (int)NpcTypes.Humanoid;
			Armor= Level*30;
			BaseHitPoints = 5760;
			NpcFlags = (int)NpcActions.BattleFieldSpiritHealer;
			CombatReach = 2.5f ;
			SetDamage(1f+3f*Level,1f+3.5*Level);			
			ManaType=0; BaseMana = 0;
			Faction = Factions.Alliance;
			if ( this.SpawnerLink != null && SpawnerLink.TrajetGuid > 0 ) 
				AIEngine = new PatrolAI( this ); 
			else 
				AIEngine = new StandingGuardAI( this );
			Elite = 1;
			Equip( new Item( 6454, InventoryTypes.MainGauche, 2, 15, 1, 3, 0, 0, 0 ));
			Loots = new BaseTreasure[]{new BaseTreasure(DropsME.MoneyElite1, 100f )}; 
		}
		public override string QueryNpcText( int id )
		{
			return NpcText00;
		}
		public override void OnHello( Character c )
		{
			NpcMenu nm = new NpcMenu();
			nm.AddMenu( 4, "Return me to life" );
			c.ResponseMessage( this, 1, nm );				
		}
		public override void DialogCharacterSelection( Character c, int id, int resp )
		{
			if ( id == 1 )
			{
				if ( resp == 0 )
				{
					c.SpiritHealerResurect( Guid );
				}
			}
		}


	}	
}
