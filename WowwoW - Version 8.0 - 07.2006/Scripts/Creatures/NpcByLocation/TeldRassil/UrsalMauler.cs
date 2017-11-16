using System;
using Server.Items;
using HelperTools;


namespace Server.Creatures
{
	public class UrsaltheMauler : BaseCreature
	{
		public UrsaltheMauler() : base()
		{
			Name = "Ursal the Mauler";
			Id = 2039;
			Model = 6818;
			Level = RandomLevel(12);
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
			BoundingRadius = 0.420f;
			CombatReach = 1.2f;
			Size = 1.3f;
			Speed = 2.9f;
			WalkSpeed = 2.9f;
			RunSpeed = 5.9f;
			Str = (int)(Level*2.5f);
			Faction = Factions.Monster;
			BaseMana = 300;
			AIEngine = new SpellCasterAI( this );
			LearnSpell( 6807, SpellsTypes.Offensive ); 
			NpcType = 7;
			NpcFlags = 0; 
			//Item( int _model, InventoryTypes _inventoryType, int _quality, int _subclass, int _objectclass, int _sheath, int param1, int param2, int param3 ) 
			Equip( new Item( 2840, InventoryTypes.TwoHanded, 2, 10, 2, 2, 0, 0, 0 ) ); 
			Loots = new BaseTreasure[]{  new BaseTreasure(Drops.MoneyA , 100f ) 
			,new BaseTreasure( UrsaltheMaulerDrops.UrsaltheMauler , 100f ) }; 
			/*****************************/
			BCAddon.Hp( this, 275, 12 );
			/*****************************/
		}
	}
}
namespace Server.Items
{
public class UrsaltheMaulerDrops
	{
		public static Loot[] UrsaltheMauler = new Loot[] {new Loot( typeof( AncestralWoollies), 0.0532198f ) 
,new Loot( typeof( BarbaricClothGloves), 0.0532198f ) 
,new Loot( typeof( BattleChainPants), 0.0532198f ) 
,new Loot( typeof( BeadedBritches), 0.159659f ) 
,new Loot( typeof( BeadedOrb), 0.0798297f ) 
,new Loot( typeof( BeadedWraps), 0.0266099f ) 
,new Loot( typeof( BirchwoodMaul), 0.0532198f ) 
,new Loot( typeof( BloodspatteredWristbands), 0.0266099f ) 
,new Loot( typeof( BrackwaterBoots), 0.0266099f ) 
,new Loot( typeof( CarvingKnife), 0.186269f ) 
,new Loot( typeof( CeremonialBuckler), 0.0266099f ) 
,new Loot( typeof( ChargersArmor), 0.0266099f ) 
,new Loot( typeof( CompactShotgun), 0.0798297f ) 
,new Loot( typeof( FireWand), 0.319319f ) 
,new Loot( typeof( FormulaEnchantChestMinorMana), 0.0266099f ) 
,new Loot( typeof( GrizzlyBuckler), 0.0532198f ) 
,new Loot( typeof( GrizzlyPants), 0.0532198f ) 
,new Loot( typeof( HuntingBow), 0.186269f ) 
,new Loot( typeof( Malachite), 0.0532198f ) 
,new Loot( typeof( NativeBranch), 0.0266099f ) 
,new Loot( typeof( NativePants), 0.0266099f ) 
,new Loot( typeof( PatternFineLeatherGloves), 0.0532198f ) 
,new Loot( typeof( PatternHeavyWoolenCloak), 0.0266099f ) 
,new Loot( typeof( PatternHillmansLeatherVest), 0.0266099f ) 
,new Loot( typeof( PatternWhiteLeatherJerkin), 0.0266099f ) 
,new Loot( typeof( PlansCopperChainVest), 0.0798297f ) 
,new Loot( typeof( PriestsMace), 0.0798297f ) 
,new Loot( typeof( PrimalLeggings), 0.0798297f ) 
,new Loot( typeof( PrimalWraps), 0.0798297f ) 
,new Loot( typeof( ScalpingTomahawk), 0.10644f ) 
,new Loot( typeof( ShadowWand), 0.0266099f ) 
,new Loot( typeof( Shadowgem), 0.0266099f ) 
,new Loot( typeof( ShortBastardSword), 0.159659f ) 
,new Loot( typeof( SpikedClub), 0.0266099f ) 
,new Loot( typeof( StaunchHammer), 0.0266099f ) 
,new Loot( typeof( SturdyQuarterstaff), 0.0532198f ) 
,new Loot( typeof( Tigerseye), 0.425758f ) 
,new Loot( typeof( TribalPants), 0.0798297f ) 
,new Loot( typeof( TribalVest), 0.0266099f ) 
,new Loot( typeof( WarTornPants), 0.0266099f ) 
,new Loot( typeof( WarTornShield), 0.0266099f ) 
,new Loot( typeof( AncestralBoots), 0.0532198f ) 
,new Loot( typeof( AncestralGloves), 0.0798297f ) 
,new Loot( typeof( BarbaricClothBelt), 0.0798297f ) 
,new Loot( typeof( BarbaricClothBracers), 0.10644f ) 
,new Loot( typeof( BarbaricClothCloak), 0.0798297f ) 
,new Loot( typeof( BattleChainBoots), 0.133049f ) 
,new Loot( typeof( BattleChainGloves), 0.10644f ) 
,new Loot( typeof( BloodspatteredCloak), 0.0266099f ) 
,new Loot( typeof( BrackwaterBracers), 0.133049f ) 
,new Loot( typeof( BrackwaterGauntlets), 0.0532198f ) 
,new Loot( typeof( CeremonialCloak), 0.10644f ) 
,new Loot( typeof( CeremonialLeatherBelt), 0.0798297f ) 
,new Loot( typeof( CeremonialLeatherBracers), 0.133049f ) 
,new Loot( typeof( Earthroot), 0.0266099f ) 
,new Loot( typeof( GreenLeatherBag), 0.0266099f ) 
,new Loot( typeof( GrizzlyBelt), 0.133049f ) 
,new Loot( typeof( GrizzlyBracers), 0.0798297f ) 
,new Loot( typeof( LinenCloth), 29.3241f ) 
,new Loot( typeof( LupineCloak), 0.0532198f ) 
,new Loot( typeof( LupineCuffs), 0.0266099f ) 
,new Loot( typeof( MinorHealingPotion), 2.4215f ) 
,new Loot( typeof( NativeBands), 0.159659f ) 
,new Loot( typeof( NativeHandwraps), 0.0266099f ) 
,new Loot( typeof( NativeSandals), 0.0266099f ) 
,new Loot( typeof( NativeSash), 0.133049f ) 
,new Loot( typeof( RedLeatherBag), 0.159659f ) 
,new Loot( typeof( RefreshingSpringWater), 4.07131f ) 
,new Loot( typeof( ScrollOfProtection), 0.691857f ) 
,new Loot( typeof( ScrollOfSpirit), 0.878127f ) 
,new Loot( typeof( ShinyRedApple), 7.61043f ) 
,new Loot( typeof( Silverleaf), 0.0532198f ) 
,new Loot( typeof( TribalBoots), 0.0532198f ) 
,new Loot( typeof( TribalBuckler), 0.133049f ) 
,new Loot( typeof( TribalGloves), 0.0266099f ) 
,new Loot( typeof( WarTornBands), 0.0266099f ) 
,new Loot( typeof( WarTornGirdle), 0.0266099f ) 
,new Loot( typeof( WarTornGreaves), 0.0266099f ) 
,new Loot( typeof( WarTornHandgrips), 0.133049f ) 
,new Loot( typeof( CalicoBelt), 0.133049f ) 
,new Loot( typeof( CalicoBracers), 0.345929f ) 
,new Loot( typeof( CalicoCloak), 0.399148f ) 
,new Loot( typeof( CalicoGloves), 0.212879f ) 
,new Loot( typeof( CalicoPants), 0.133049f ) 
,new Loot( typeof( CalicoShoes), 0.266099f ) 
,new Loot( typeof( CalicoTunic), 0.133049f ) 
,new Loot( typeof( CheapBlunderbuss), 0.319319f ) 
,new Loot( typeof( CommonersSword), 0.292709f ) 
,new Loot( typeof( CrudeBattleAxe), 0.292709f ) 
,new Loot( typeof( FeebleShortbow), 0.345929f ) 
,new Loot( typeof( FishermanKnife), 0.319319f ) 
,new Loot( typeof( HeavyHammer), 0.505588f ) 
,new Loot( typeof( OldGreatsword), 0.292709f ) 
,new Loot( typeof( RoughWoodenStaff), 0.239489f ) 
,new Loot( typeof( RustyWarhammer), 0.585418f ) 
,new Loot( typeof( WarpedCloak), 0.399148f ) 
,new Loot( typeof( WarpedLeatherBelt), 0.133049f ) 
,new Loot( typeof( WarpedLeatherBoots), 0.159659f ) 
,new Loot( typeof( WarpedLeatherBracers), 0.159659f ) 
,new Loot( typeof( WarpedLeatherGloves), 0.345929f ) 
,new Loot( typeof( WarpedLeatherPants), 0.186269f ) 
,new Loot( typeof( WarpedLeatherVest), 0.239489f ) 
,new Loot( typeof( WoodenBuckler), 0.345929f ) 
,new Loot( typeof( WoodenShield), 0.399148f ) 
,new Loot( typeof( WornCloak), 0.212879f ) 
,new Loot( typeof( WornHatchet), 0.505588f ) 
,new Loot( typeof( WornMailBelt), 0.186269f ) 
,new Loot( typeof( WornMailBoots), 0.10644f ) 
,new Loot( typeof( WornMailBracers), 0.159659f ) 
,new Loot( typeof( WornMailGloves), 0.345929f ) 
,new Loot( typeof( WornMailPants), 0.266099f ) 
,new Loot( typeof( WornMailVest), 0.266099f ) 
};
	}
}

