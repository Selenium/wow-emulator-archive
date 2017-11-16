using System;
using System.Collections;
using System.Reflection;
using HelperTools;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for BaseTresure.
	/// </summary>
	public class BaseTreasure
	{
		Loot []loots;
		float probability;
		public BaseTreasure( Loot []l, float prob )
		{			
			loots = l;
			probability = prob;
		}
		public bool IsDrop()
		{
			if ( Utility.RandomDouble() * 100 < probability * World.DropMultiplier )
				return true;
			return false;
		}
		public ArrayList RandomDrop( ref int lootMoney )
		{
			ArrayList tresure = new ArrayList();
			if ( loots == null )
				return null;
			foreach( Loot l in loots )
			{
				if ( Utility.RandomDouble() * 100 < l.Probability * World.DropMultiplier )
				{		
					int n = Utility.Random( l.MinAmount, l.MaxAmount );
					Item it = l.Create( n );
					if ( it is Money )//	money
						lootMoney += n * World.DropGoldMultiplier;
					tresure.Add( it );
				}
			}
			return tresure;
		}
	}
}
