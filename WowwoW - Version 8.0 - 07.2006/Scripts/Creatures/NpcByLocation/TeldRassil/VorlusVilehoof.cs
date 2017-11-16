using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class VorlusVilehoof : BaseCreature
	{
		public VorlusVilehoof() : base()
		{
			Name = "Vorlus Vilehoof";
			Id = 6128;
			Model = 2015;
			Level = RandomLevel(10);
			SetDamage(1f+1.8f*Level,1f+2.5*Level);			
			AttackSpeed = 2000;
			Armor = 4526;
			Block = 0;
			ResistArcane = 0;
			ResistFire = 0;
			ResistFrost = 0;
			ResistHoly = 0;
			ResistNature = 0;
			Flags1=0x080000;
			BaseMana = 0;
			BoundingRadius = 0.3f;
			CombatReach = 1.0f;
			Size = 1.15f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level/2.5f);
			Faction = Factions.Monster;
			AIEngine = new AgressiveAnimalAI( this );
			NpcType = (int)NpcTypes.Demon;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			//Equip( new Item( 24930, InventoryTypes.Ranged, 2, 2, 2, 0, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( VorlusVilehoofDrops.VorlusVilehoof , 100f ) }; 
			/*****************************/
			BCAddon.Hp( this, 189, 10 );
			/*****************************/
		}
	}
}


namespace Server.Items
{
public class VorlusVilehoofDrops
	{
		public static Loot[] VorlusVilehoof = new Loot[] {new Loot( typeof( AncestralOrb), 0.141543f ) 
,new Loot( typeof( BattleChainPants), 0.283086f ) 
,new Loot( typeof( CarvingKnife), 0.212314f ) 
,new Loot( typeof( ChargersPants), 0.0707714f ) 
,new Loot( typeof( HuntingBow), 0.283086f ) 
,new Loot( typeof( Malachite), 0.4954f ) 
,new Loot( typeof( NotchedShortsword), 0.353857f ) 
,new Loot( typeof( PatternRedLinenRobe), 0.212314f ) 
,new Loot( typeof( PlansCopperChainVest), 0.283086f ) 
,new Loot( typeof( PrimalWraps), 0.141543f ) 
,new Loot( typeof( RecipeSwiftnessPotion), 0.0707714f ) 
,new Loot( typeof( ScalpingTomahawk), 0.212314f ) 
,new Loot( typeof( SeveringAxe), 0.212314f ) 
,new Loot( typeof( SpikedClub), 0.141543f ) 
,new Loot( typeof( SturdyQuarterstaff), 0.0707714f ) 
,new Loot( typeof( Tigerseye), 0.283086f ) 
,new Loot( typeof( TrainingSword), 0.0707714f ) 
,new Loot( typeof( WarTornShield), 0.0707714f ) 
,new Loot( typeof( AncestralBelt), 0.353857f ) 
,new Loot( typeof( AncestralBoots), 0.141543f ) 
,new Loot( typeof( AncestralCloak), 0.212314f ) 
,new Loot( typeof( AncestralGloves), 0.141543f ) 
,new Loot( typeof( BarbaricClothBracers), 0.141543f ) 
,new Loot( typeof( BarbaricClothCloak), 0.0707714f ) 
,new Loot( typeof( BattleChainBracers), 0.0707714f ) 
,new Loot( typeof( BattleChainCloak), 0.0707714f ) 
,new Loot( typeof( BattleChainGirdle), 0.141543f ) 
,new Loot( typeof( BeadedCord), 0.141543f ) 
,new Loot( typeof( BeadedGloves), 0.0707714f ) 
,new Loot( typeof( BeadedSandals), 0.424628f ) 
,new Loot( typeof( CeremonialLeatherBracers), 0.0707714f ) 
,new Loot( typeof( ChargersBelt), 0.424628f ) 
,new Loot( typeof( ChargersBoots), 0.141543f ) 
,new Loot( typeof( ChargersHandwraps), 0.212314f ) 
,new Loot( typeof( GrizzlyBelt), 0.141543f ) 
,new Loot( typeof( GrizzlyCape), 0.141543f ) 
,new Loot( typeof( HornOfVorlus), 29.2286f ) 
,new Loot( typeof( HuntingRifle), 0.141543f ) 
,new Loot( typeof( LinenCloth), 28.9455f ) 
,new Loot( typeof( LumberjackAxe), 0.0707714f ) 
,new Loot( typeof( MinorHealingPotion), 1.69851f ) 
,new Loot( typeof( NativeCloak), 0.212314f ) 
,new Loot( typeof( NativeSash), 0.0707714f ) 
,new Loot( typeof( PrimalBands), 0.283086f ) 
,new Loot( typeof( PrimalBoots), 0.212314f ) 
,new Loot( typeof( PrimalMitts), 0.283086f ) 
,new Loot( typeof( RefreshingSpringWater), 3.89243f ) 
,new Loot( typeof( ScrollOfProtection), 0.707714f ) 
,new Loot( typeof( ScrollOfSpirit), 0.4954f ) 
,new Loot( typeof( SmallGreenPouch), 0.0707714f ) 
,new Loot( typeof( SmallRedPouch), 0.141543f ) 
,new Loot( typeof( ToughJerky), 7.57254f ) 
,new Loot( typeof( TribalBelt), 0.212314f ) 
,new Loot( typeof( TribalBoots), 0.141543f ) 
,new Loot( typeof( TribalBracers), 0.424628f ) 
,new Loot( typeof( TribalBuckler), 0.0707714f ) 
,new Loot( typeof( WarTornCape), 0.283086f ) 
,new Loot( typeof( BeatenBattleAxe), 0.9908f ) 
,new Loot( typeof( CarpentersMallet), 0.4954f ) 
,new Loot( typeof( CrackedBuckler), 0.636943f ) 
,new Loot( typeof( CrackedShortbow), 0.353857f ) 
,new Loot( typeof( CrackedSledge), 0.424628f ) 
,new Loot( typeof( CrudeBastardSword), 0.566171f ) 
,new Loot( typeof( FeebleSword), 0.778485f ) 
,new Loot( typeof( LooseChainBelt), 0.212314f ) 
,new Loot( typeof( LooseChainBoots), 0.212314f ) 
,new Loot( typeof( LooseChainBracers), 0.283086f ) 
,new Loot( typeof( LooseChainCloak), 0.424628f ) 
,new Loot( typeof( LooseChainGloves), 0.353857f ) 
,new Loot( typeof( LooseChainPants), 0.0707714f ) 
,new Loot( typeof( LooseChainVest), 0.283086f ) 
,new Loot( typeof( PatchworkArmor), 0.353857f ) 
,new Loot( typeof( PatchworkBelt), 0.424628f ) 
,new Loot( typeof( PatchworkBracers), 0.424628f ) 
,new Loot( typeof( PatchworkCloak), 0.212314f ) 
,new Loot( typeof( PatchworkGloves), 0.424628f ) 
,new Loot( typeof( PatchworkPants), 0.636943f ) 
,new Loot( typeof( PatchworkShoes), 0.212314f ) 
,new Loot( typeof( RustCoveredBlunderbuss), 0.353857f ) 
,new Loot( typeof( RustyHatchet), 0.212314f ) 
,new Loot( typeof( SharpenedLetterOpener), 0.212314f ) 
,new Loot( typeof( WitheredStaff), 0.424628f ) 
,new Loot( typeof( WornHideCloak), 0.9908f ) 
,new Loot( typeof( WornLargeShield), 0.212314f ) 
,new Loot( typeof( WornLeatherBelt), 0.212314f ) 
,new Loot( typeof( WornLeatherBoots), 0.353857f ) 
,new Loot( typeof( WornLeatherBracers), 0.778485f ) 
,new Loot( typeof( WornLeatherGloves), 0.353857f ) 
,new Loot( typeof( WornLeatherPants), 0.424628f ) 
,new Loot( typeof( WornLeatherVest), 0.283086f ) 
};
}}