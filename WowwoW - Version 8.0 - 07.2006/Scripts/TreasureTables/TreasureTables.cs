//////////////////////////////////////////////////////////////////////////////
// 
// 			 Drops
// Made by Dr Nexus
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

///////////////////////////////////////////
namespace Server
{
	public class Drops
	{
		// And the TreasureTables.cs

		public static Loot[] BattleBoar = new Loot[] {  new Loot( typeof( BattleboarFlank ), 16f )
														 , new Loot( typeof( BattleboarSnout ), 16f )
														 , new Loot( typeof( ToughJerky ), 17f )
														 , new Loot( typeof( RuinedPelt ), 53f )
														 , new Loot( typeof( SplinteredTusk ), 53f )
													 };
		public static Loot[] MottledBoar = new Loot[] {  new Loot( typeof( SplinteredTusk ), 53f )
														  , new Loot( typeof( RuinedPelt ), 53f )
														  , new Loot( typeof( ChippedBoarTusk ), 19f )
														  , new Loot( typeof( BrokenBoarTusk ), 27f )
														  , new Loot( typeof( ChunkOfBoarMeat ), 33f )
														  , new Loot( typeof( ToughJerky ), 18f )
													  };
		public static Loot[] CragBoar = new Loot[] {  new Loot( typeof( ChunkOfBoarMeat ), 31f )
													   , new Loot( typeof( CragBoarRib ), 37f )
													   , new Loot( typeof( BrokenBoarTusk ), 15f )
													   , new Loot( typeof( ChippedBoarTusk ), 10f )
													   , new Loot( typeof( RuinedPelt ), 53f )
													   , new Loot( typeof( SplinteredTusk ), 53f )
												   };
		public static Loot[] MountainBoar = new Loot[] {  new Loot( typeof( BoarRibs ), 33f )
														   , new Loot( typeof( BoarIntestines ), 33f )
														   , new Loot( typeof( ChunkOfBoarMeat ), 37f )
														   , new Loot( typeof( ChippedBoarTusk ), 22f )
														   , new Loot( typeof( LargeBoarTusk ), 15f )
													   };
		public static Loot[] StoneTuskBoar = new Loot[] {  new Loot( typeof( ChunkOfBoarMeat ), 30f )
															, new Loot( typeof( BrokenBoarTusk ), 18f )
															, new Loot( typeof( ChippedBoarTusk ), 18f )
														};
		public static Loot[] ThistleBoar = new Loot[] {  new Loot( typeof( ToughJerky ), 20f )
														  , new Loot( typeof( RuinedPelt ), 54f )
														  , new Loot( typeof( SplinteredTusk ), 54f )
													  };

		public static Loot[] MineralA = new Loot[]  
						{
							new Loot( typeof( CopperOre ), 12.0000f )
							, new Loot( typeof( RoughStone ), 15.0000f ) };


		public static Loot[] Pouch = new Loot[] 
						{		
							new Loot( typeof( SmallBlackPouch ), 10.100000f )
							, new Loot( typeof( SmallBluePouch ), 10.110000f )
							, new Loot( typeof( SmallBrownPouch ), 10.080000f )
							, new Loot( typeof( SmallGreenPouch ), 10.090000f )
							, new Loot( typeof( SmallRedPouch ), 10.110000f )
							, new Loot( typeof( BatteredBuckler ), 11.350000f )
							, new Loot( typeof( BentLargeShield ), 11.280000f ) 
						};
		public static Loot[] ChainArmor = new Loot[] 
						{		
							new Loot( typeof( FlimsyChainBelt ), 15.040000f )
							, new Loot( typeof( FlimsyChainBoots ), 12.010000f )
							, new Loot( typeof( FlimsyChainBracers ), 13.070000f )
							, new Loot( typeof( FlimsyChainCloak ), 11.140000f )
							, new Loot( typeof( FlimsyChainGloves ), 11.100000f )
							, new Loot( typeof( FlimsyChainPants ), 10.980000f )
							, new Loot( typeof( FlimsyChainVest ), 9.970000f )
						};
		public static Loot[] FrayedArmor = new Loot[] 
						{		
							new Loot( typeof( FrayedBelt ), 15.460000f )
							, new Loot( typeof( FrayedBracers ), 12.370000f )
							, new Loot( typeof( FrayedCloak ), 13.490000f )
							, new Loot( typeof( FrayedGloves ), 11.600000f )
							, new Loot( typeof( FrayedPants ), 11.380000f )
							, new Loot( typeof( FrayedRobe ), 9.620000f )
							, new Loot( typeof( FrayedShoes ), 11.300000f )
						};

		public static Loot[] RaggedLeatherArmor = new Loot[] 
						{
							new Loot( typeof( RaggedCloak ), 11.180000f )
							, new Loot( typeof( RaggedLeatherBelt ), 13.240000f )
							, new Loot( typeof( RaggedLeatherBoots ), 11.180000f )
							, new Loot( typeof( RaggedLeatherBracers ), 11.290000f )
							, new Loot( typeof( RaggedLeatherGloves ), 12.320000f )
							, new Loot( typeof( RaggedLeatherPants ), 9.320000f )
							, new Loot( typeof( RaggedLeatherVest ), 8.460000f )
						};

		public static Loot[] ConsummableA = new Loot[] 
						{
							new Loot( typeof( RefreshingSpringWater ), 6.480000f )
							, new Loot( typeof( ShinyRedApple ), 13.570000f ) 
						};

		public static Loot[] MoneyA = new Loot[] 
						{
							new Loot( typeof( Money ), 2, 10, 60.480000f )							
							,new Loot( typeof( Money ), 2, 10, 20.480000f )
						};
		public static Loot[] MoneyB = new Loot[] 
						{
							new Loot( typeof( Money ), 9, 20, 60.480000f )	
							,new Loot( typeof( Money ), 2, 10, 20.480000f )
						};
		public static Loot[] MoneyC = new Loot[] 
						{
							new Loot( typeof( Money ), 17, 30, 60.480000f )	
							,new Loot( typeof( Money ), 2, 10, 20.480000f )
						};
		public static Loot[] MoneyD = new Loot[] 
						{
							new Loot( typeof( Money ), 26, 40, 60.480000f )	
							,new Loot( typeof( Money ), 2, 10, 20.480000f )
						};

		public static Loot[] WolfLootsA = new Loot[]
					{
						new Loot( typeof( BrokenFang ), 39.849998f )
						, new Loot( typeof( ChippedClaw ), 42.000000f )						
						, new Loot( typeof( ToughWolfMeat ), 86.549999f ) };	
		// TreasureTables.cs

		public static Loot[] StrigidOwls = new Loot[] {  new Loot( typeof( LegMeat ), 10f )
														  , new Loot( typeof( SmallEgg ), 55f )
														  , new Loot( typeof( CrackedBill ), 31f )
														  , new Loot( typeof( CrackedEggShells ), 22f )
														  , new Loot( typeof( PluckedFeather ), 22f )
														  , new Loot( typeof( RuffledFeather ), 10f )
													  };
		public static Loot[] StrigidOwl = new Loot[] {  new Loot( typeof( FelCone ), 30f )
														 , new Loot( typeof( StrigidOwlFeather ), 30f )
													 };
	
		public Drops()
		{
		}
	}
}

