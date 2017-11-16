using System;
using System.Collections;
using Server;
using Server.Items;

///////////////////////////////////////////
namespace Server
{
	public class DropsME
	{
		public static Loot[] MoneyElite1 = new Loot[] 
						{
							new Loot( typeof( Money ), 2060, 3050, 60.480000f )	
							,new Loot( typeof( Money ), 206, 306, 20.480000f )
						};
		public static Loot[] MoneyElite2 = new Loot[] 
						{
							new Loot( typeof( Money ), 3050, 4050, 60.480000f )	
							,new Loot( typeof( Money ), 306, 405, 20.480000f )
						};
		public static Loot[] MoneyBoss = new Loot[] 
						{
							new Loot( typeof( Money ), 4050, 5050, 60.480000f )	
							,new Loot( typeof( Money ), 405, 505, 20.480000f )
						};
		public static Loot[] MoneyRare = new Loot[] 
						{
							new Loot( typeof( Money ), 10000, 15000,60.480000f )	
							,new Loot( typeof( Money ), 1000, 1500, 20.480000f )
						};																							

	}
}