using System;
using System.Collections;
using HelperTools;
using Server.Items;
namespace Server
{
	/// <summary>
	/// Summary description for PermanentAura class
	/// </summary>
	public class PermanentAura
	{
		public int Id
		{
			get
			{
				return id;
			}
		}
		
		int id;
		public Aura aura;
		public PermanentAura(Aura _aura, int _id)
		{
			aura = _aura;
			id = _id;
		}
	}
}
