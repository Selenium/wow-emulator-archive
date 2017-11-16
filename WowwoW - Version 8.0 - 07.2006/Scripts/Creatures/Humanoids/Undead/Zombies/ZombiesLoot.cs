using System;
using Server.Items;
using System.Collections;
using Server;


///////////////////////////////////////////
namespace Server
{
	public class ZombiesLoot
	{
		public static Loot[] MindlessZombie = new Loot[] {  new Loot( typeof( ChewToy ), 0.01f )
															 , new Loot( typeof( ForestMushroomCap ), 16.1f )
															 , new Loot( typeof( MinorHealingPotion ), 0.00f )
															 , new Loot( typeof( RefreshingSpringWater ), 7.31f )
															 , new Loot( typeof( SmallBlackPouch ), 0.10f )
															 , new Loot( typeof( SmallBluePouch ), 0.10f )
															 , new Loot( typeof( SmallBrownPouch ), 0.10f )
															 , new Loot( typeof( SmallGreenPouch ), 0.00f )
															 , new Loot( typeof( SmallRedPouch ), 0.10f )
															 , new Loot( typeof( BatteredBuckler ), 1.29f )
															 , new Loot( typeof( BentLargeShield ), 1.65f )
															 , new Loot( typeof( FlimsyChainBelt ), 1.13f )
															 , new Loot( typeof( FlimsyChainBoots ), 1.19f )
															 , new Loot( typeof( FlimsyChainBracers ), 1.15f )
															 , new Loot( typeof( FlimsyChainCloak ), 1.26f )
															 , new Loot( typeof( FlimsyChainGloves ), 1.16f )
															 , new Loot( typeof( FlimsyChainPants ), 1.18f )
															 , new Loot( typeof( FlimsyChainVest ), 0.94f )
															 , new Loot( typeof( FrayedBelt ), 1.64f )
															 , new Loot( typeof( FrayedBracers ), 1.40f )
															 , new Loot( typeof( FrayedCloak ), 1.49f )
															 , new Loot( typeof( FrayedGloves ), 1.62f )
															 , new Loot( typeof( FrayedPants ), 1.46f )
															 , new Loot( typeof( FrayedRobe ), 1.55f )
															 , new Loot( typeof( FrayedShoes ), 1.39f )
															 , new Loot( typeof( RaggedCloak ), 1.27f )
															 , new Loot( typeof( RaggedLeatherBelt ), 1.25f )
															 , new Loot( typeof( RaggedLeatherBoots ), 1.27f )
															 , new Loot( typeof( RaggedLeatherBracers ), 1.26f )
															 , new Loot( typeof( RaggedLeatherGloves ), 1.33f )
															 , new Loot( typeof( RaggedLeatherPants ), 1.30f )
															 , new Loot( typeof( RaggedLeatherVest ), 1.40f )
															 , new Loot( typeof( ScavengedGoods ), 0.09f )
														 };

		public static Loot[] WretchedZombie = new Loot[] {  new Loot( typeof( ChewToy ), 0.01f )
															 , new Loot( typeof( ForestMushroomCap ), 16.1f )
															 , new Loot( typeof( MinorHealingPotion ), 0.00f )
															 , new Loot( typeof( RefreshingSpringWater ), 7.31f )
															 , new Loot( typeof( SmallBlackPouch ), 0.10f )
															 , new Loot( typeof( SmallBluePouch ), 0.10f )
															 , new Loot( typeof( SmallBrownPouch ), 0.10f )
															 , new Loot( typeof( SmallGreenPouch ), 0.00f )
															 , new Loot( typeof( SmallRedPouch ), 0.10f )
															 , new Loot( typeof( BatteredBuckler ), 1.29f )
															 , new Loot( typeof( BentLargeShield ), 1.65f )
															 , new Loot( typeof( FlimsyChainBelt ), 1.13f )
															 , new Loot( typeof( FlimsyChainBoots ), 1.19f )
															 , new Loot( typeof( FlimsyChainBracers ), 1.15f )
															 , new Loot( typeof( FlimsyChainCloak ), 1.26f )
															 , new Loot( typeof( FlimsyChainGloves ), 1.16f )
															 , new Loot( typeof( FlimsyChainPants ), 1.18f )
															 , new Loot( typeof( FlimsyChainVest ), 0.94f )
															 , new Loot( typeof( FrayedBelt ), 1.64f )
															 , new Loot( typeof( FrayedBracers ), 1.40f )
															 , new Loot( typeof( FrayedCloak ), 1.49f )
															 , new Loot( typeof( FrayedGloves ), 1.62f )
															 , new Loot( typeof( FrayedPants ), 1.46f )
															 , new Loot( typeof( FrayedRobe ), 1.55f )
															 , new Loot( typeof( FrayedShoes ), 1.39f )
															 , new Loot( typeof( RaggedCloak ), 1.27f )
															 , new Loot( typeof( RaggedLeatherBelt ), 1.25f )
															 , new Loot( typeof( RaggedLeatherBoots ), 1.27f )
															 , new Loot( typeof( RaggedLeatherBracers ), 1.26f )
															 , new Loot( typeof( RaggedLeatherGloves ), 1.33f )
															 , new Loot( typeof( RaggedLeatherPants ), 1.30f )
															 , new Loot( typeof( RaggedLeatherVest ), 1.40f )
															 , new Loot( typeof( ScavengedGoods ), 0.09f )
														 };


	}
}
