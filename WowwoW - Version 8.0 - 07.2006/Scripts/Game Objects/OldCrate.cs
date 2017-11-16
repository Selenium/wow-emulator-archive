using System;
using System.Collections;
using HelperTools;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for OldCrate.
	/// </summary>
	public class OldCrate : GameObject
	{
		public OldCrate()
		{
			Id = 261;
			Charge = 1;
		}

		public override bool OnUse( Mobile by )
		{
			return base.OnUse( by );			
		}
	}
}