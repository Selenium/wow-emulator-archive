//////////////////////////////////////////////////////////////////////////////
// 
// 			 Boar Drops
// Made by Phantom			2005.06.15.
//////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server
{
	public class BoarDrops
	{
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

		public static Loot[] AshmaneBoar = new Loot[] {  new Loot( typeof( BlastedBoarLung ), 32f )
								, new Loot( typeof( IvoryBoarTusk ), 25f )
								, new Loot( typeof( LargeBoarTusk ), 17f )
		};

		public static Loot[] Bellygrub = new Loot[] {  new Loot( typeof( BellygrubsTusk ), 68f )
								, new Loot( typeof( BoarIntestines ), 32f )
								, new Loot( typeof( BoarRibs ), 26f )
								, new Loot( typeof( GoretuskLiver ), 30f )
								, new Loot( typeof( GreatGoretuskSnout ), 30f )
								, new Loot( typeof( IvoryBoarTusk ), 14f )
								, new Loot( typeof( LargeBoarTusk ), 9f )
		};

		public static Loot[] Agamar = new Loot[] {  new Loot( typeof( BoarIntestines ), 30f )
								, new Loot( typeof( BoarRibs ), 43f )
								, new Loot( typeof( IvoryBoarTusk ), 30f )
								, new Loot( typeof( LargeBoarTusk ), 16f )
		};

		public static Loot[] Goretusk = new Loot[] {  new Loot( typeof( BoarIntestines ), 29f )
								, new Loot( typeof( BoarRibs ), 25f )
								, new Loot( typeof( ChunkOfBoarMeat ), 34f )
								, new Loot( typeof( GoretuskLiver ), 29f )
								, new Loot( typeof( GoretuskSnout ), 35f )
								, new Loot( typeof( BrokenBoarTusk ), 15f )
								, new Loot( typeof( ChippedBoarTusk ), 21f )
		};

		public static Loot[] GreatGoretusk = new Loot[] {  new Loot( typeof( BoarIntestines ), 30f )
								, new Loot( typeof( BoarRibs ), 26f )
								, new Loot( typeof( ChunkOfBoarMeat ), 35f )
								, new Loot( typeof( GoretuskLiver ), 30f )
								, new Loot( typeof( GreatGoretuskSnout ), 30f )
								, new Loot( typeof( ChippedBoarTusk ), 6f )
		};

		public static Loot[] Grunter = new Loot[] {  new Loot( typeof( BlastedBoarLung ), 30f )
								, new Loot( typeof( BoarRibs ), 15f )
								, new Loot( typeof( ChunkOfBoarMeat ), 10f )
								, new Loot( typeof( IvoryBoarTusk ), 31f )
								, new Loot( typeof( LargeBoarTusk ), 9f )
		};

		public static Loot[] Princess = new Loot[] {  new Loot( typeof( BrassCollar ), 63f )
								, new Loot( typeof( ChunkOfBoarMeat ), 25f )
								, new Loot( typeof( BrokenBoarTusk ), 24f )
								, new Loot( typeof( ChippedBoarTusk ), 19f )
		};

		public static Loot[] PorcineEntourage = new Loot[] {  new Loot( typeof( ChunkOfBoarMeat ), 32f )
								, new Loot( typeof( BrokenBoarTusk ), 23f )
								, new Loot( typeof( ChippedBoarTusk ), 15f )
		};

		public static Loot[] TamedBattleboar = new Loot[] {  new Loot( typeof( BoarIntestines ), 30f )
								, new Loot( typeof( BoarRibs ), 43f )
								, new Loot( typeof( IvoryBoarTusk ), 30f )
								, new Loot( typeof( LargeBoarTusk ), 16f )
		};



	}
}

