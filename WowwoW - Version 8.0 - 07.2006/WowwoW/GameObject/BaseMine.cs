using System;
using HelperTools;
using System.Collections;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for BaseChest.
	/// </summary>
	public class BaseMine : GameObject
	{
		int lootMoney;
		bool locked = false;
		public BaseMine()
		{
			DefaultModel = 32;
			Charge = 1 + Utility.Random4();
		}
		public int LootMoney
		{
			get { return 0; }
			set { lootMoney = value; }
		}
		public override bool OnUse( Mobile from )
		{
			if ( !( from is Character ) )
				return false;
			lootMoney = 0;
			( from as Character ).LootOwner = Guid;
			ArrayList loot = new ArrayList();
			foreach( BaseTreasure l in Loots )
			{
				if ( l.IsDrop() )
					loot.AddRange( l.RandomDrop( ref lootMoney ) );
			}
			Treasure = (Item[])loot.ToArray( typeof( Item ) );
			( from as Character ).SendLootDetails( Guid, this, lootMoney  );
			return true;
		}

		public override bool OnRelease( Mobile from )
		{
			Charge--;
			if ( Charge <= 0 )
			{
				if ( SpawnerLink != null )
					SpawnerLink.LastSpawn = DateTime.Now;
				return base.OnRelease( from );
			}
			return false;			
		}
		public bool Locked
		{
			get { return locked; }
			set { locked = value; }
		}
	}
}
