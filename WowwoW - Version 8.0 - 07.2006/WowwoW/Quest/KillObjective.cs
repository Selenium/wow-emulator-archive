using System;
using System.Reflection;


namespace Server
{
	/// <summary>
	/// Summary description for KillObjective.
	/// </summary>
	public class KillObjective
	{
		int amount;
		Type type;

		public KillObjective( Type t, int a )
		{
			type = t;
			amount = a;
		}
		public KillObjective GetKillObjective( int id, int a ) 
		{ 
			return new KillObjective( World.MobileTypeById( id ), a ); 
		} 

		public int Id
		{
			get 
			{
				ConstructorInfo []cts = type.GetConstructors();
				Mobile i = (Mobile)cts[ 0 ].Invoke( null );
				return i.Id;
			}
		}
		#region ACCESSORS
		public int Amount
		{
			get { return amount; }
		}
		#endregion

	}
}
