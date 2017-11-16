using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class SergeantBrashclaw : BaseCreature
	{
		public SergeantBrashclaw() : base()
		{
			Name = "Sergeant Brashclaw";
			Id = 506;
			Model = 383;
			Level = RandomLevel(18);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 1*Level;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 0.85f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level*2.5f);
			Faction = Factions.Monster;
			AIEngine = new GroupInteligentAI( this );
			NpcType = 7;
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 7427, InventoryTypes.MainGauche, 2, 0, 1, 3, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure( SergeantBrashclawDrops.SergeantBrashclaw , 100f )
						     ,new BaseTreasure(DropsME.MoneyRare, 100f )};
			/*****************************/
			BCAddon.Hp( this, 2397, 18 );
			/*****************************/
		}
	}
}



namespace Server.Items
{
public class SergeantBrashclawDrops
	{
		public static Loot[] SergeantBrashclaw = new Loot[] {new Loot( typeof( BanditBoots), 0.325733f ) 
,new Loot( typeof( BrashclawsChopper), 22.4756f ) 
,new Loot( typeof( BrashclawsSkewer), 69.0554f ) 
,new Loot( typeof( BuccaneersBracers), 0.325733f ) 
,new Loot( typeof( BurnishedGloves), 0.325733f ) 
,new Loot( typeof( FormulaEnchantBracerMinorSpirit), 0.325733f ) 
,new Loot( typeof( GruntAxe), 0.325733f ) 
,new Loot( typeof( HuntingTunic), 0.325733f ) 
,new Loot( typeof( NorthernShortsword), 0.325733f ) 
,new Loot( typeof( SeersBelt), 0.651466f ) 
,new Loot( typeof( SergeantsWarhammer), 0.325733f ) 
,new Loot( typeof( BlueLeatherBag), 0.325733f ) 
,new Loot( typeof( GnollPaw), 27.6873f ) 
,new Loot( typeof( HaunchOfMeat), 4.56026f ) 
,new Loot( typeof( IceColdMilk), 3.58306f ) 
,new Loot( typeof( LesserHealingPotion), 1.30293f ) 
,new Loot( typeof( LinenCloth), 10.4235f ) 
,new Loot( typeof( MinorManaPotion), 0.977199f ) 
,new Loot( typeof( ScrollOfAgility), 0.325733f ) 
,new Loot( typeof( ScrollOfIntellect), 0.651466f ) 
,new Loot( typeof( ScrollOfStrength), 0.325733f ) 
,new Loot( typeof( TelAbimBanana), 0.325733f ) 
,new Loot( typeof( WoolCloth), 14.658f ) 
,new Loot( typeof( BatteredMallet), 0.325733f ) 
,new Loot( typeof( CanvasBelt), 0.325733f ) 
,new Loot( typeof( CanvasCloak), 0.325733f ) 
,new Loot( typeof( CanvasGloves), 0.651466f ) 
,new Loot( typeof( CanvasPants), 0.325733f ) 
,new Loot( typeof( CanvasVest), 0.977199f ) 
,new Loot( typeof( DirtyBlunderbuss), 0.977199f ) 
,new Loot( typeof( LacedCloak), 0.325733f ) 
,new Loot( typeof( LacedMailPants), 0.651466f ) 
,new Loot( typeof( OrnamentalMace), 0.977199f ) 
,new Loot( typeof( PatchedCloak), 0.325733f ) 
,new Loot( typeof( ShortHandledBattleAxe), 0.651466f ) 
,new Loot( typeof( SmallDagger), 0.651466f ) 
,new Loot( typeof( UnbalancedAxe), 0.325733f ) 

			};
	}
}