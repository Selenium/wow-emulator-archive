using System;

namespace Server
{
	/// <summary>
	/// Summary description for Class3.
	/// </summary>
	public class TaxiPath
	{
		int id;
		int from;
		int to;
		int price;

		public int From
		{
			get{return from;}
		}
		public int To
		{
			get{return to;}
		}
		public int Price
		{
			get{return price;}
		}
		public int Id
		{
			get{return id;}
		}

		public TaxiPath(int _id,int _from,int _to,int _price)
		{
			id = _id;
			from = _from;
			to = _to;
			price = _price;
		}
	}
}
