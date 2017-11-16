using System;
using HelperTools;
using System.Collections;
using Server.Items;
using System.Reflection;


namespace Server
{
	public class RangedCreature : BaseCreature 
	{ 
		public Item rangedWeapon;
		public Item rangedAmmo;
		public  RangedCreature() : base() 
		{
		}
	}
}