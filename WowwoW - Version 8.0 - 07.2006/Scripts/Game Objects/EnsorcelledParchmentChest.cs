
// DrNexus notes :
//			- I changed the class name to something more quest related
//			- I'd add a treasure list just for the parchment
//			- add "using Server.Items;"
//			- % is not correct, I change it to 82.98%
//			- I add the DefaultModel for this chest
//	Script modified by kolkoo - 06/05/05 11:52:18
//	Script made by kolkoo - 06/05/05 11:49:40
//      For  Quest: The Ensorcelled Parchment
//      http://wow.allakhazam.com/db/quest.html?wquest=551
using System;
using Server.Items;
using HelperTools;

namespace Server
{

	//	Object: Worn Wooden Chest	
	//Found in Zones:
	//# Alterac Mountains
	//Known Drops:
	//Ensorcelled Parchment	82.98%	(580 in 699)
	//Used in Quests:
	//The Ensorcelled Parchment
	//Taken from wow.allakhazam.com
	public class EnsorcelledParchmentChest : BaseChest
	{
		public EnsorcelledParchmentChest()
		{
			DefaultModel = 33;
			BaseTreasure tempTreasure = new BaseTreasure( new Loot[] { new Loot( typeof( EnsorcelledParchment ), 82.98f ) }, 100.0f );
			Loots = new BaseTreasure[] { tempTreasure };
			Charge = 1;//	one use before vanishing
		}
		public override bool OnUse( Mobile from )
		{
			return base.OnUse( from );
		}

		public override bool OnRelease( Mobile from )
		{
			return base.OnRelease( from );
		}
	}
} 

