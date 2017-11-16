using System;

namespace Server
{
	/// <summary>
	/// Summary description for Teach.
	/// </summary>
	public class Teach : BaseAbility
	{
		int teach;
		int buyPrice;

		public Teach( int _teach, ushort _id,  int _cost, int _classe ) : base( _id, 2000 )
		{
			teach = _teach;
			buyPrice = _cost;
		}
		public int TeachId
		{
			get { return teach; }
		}
		public int BuyPrice
		{
			get { return buyPrice; }
		}
	}
}
