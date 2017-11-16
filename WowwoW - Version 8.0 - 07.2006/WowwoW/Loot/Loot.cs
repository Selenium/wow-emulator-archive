using System;
using System.Reflection;
using Server.Items;

namespace Server
{
	/// <summary>
	/// Summary description for Loot.
	/// </summary>
	public class Loot
	{
		ConstructorInfo constructor;
		float probability;
		int minAmount;
		int maxAmount;

		public Loot( Type type, float proba )
		{
			try
			{
			//	if ( !World.Loading )
				{
					minAmount = maxAmount = 1;
					ConstructorInfo []m = type.GetConstructors();
			
					foreach( ConstructorInfo method in m )
					{
						ParameterInfo []param = method.GetParameters();
						if ( param.Length == 0 )
							constructor = method;
					}
					probability = proba;
				}
			}
			catch( Exception )
			{
				Console.WriteLine( "Error while constructing {0}", type.ToString() );
			}
		}
		public Loot( Type type, int minamount, int maxamount, float proba )
		{
			try
			{
		//		if ( !World.Loading )
				{
					minAmount = minamount;
					maxAmount = maxamount;
					ConstructorInfo []m = type.GetConstructors();			
					foreach( ConstructorInfo method in m )
					{
						ParameterInfo []param = method.GetParameters();
						if ( param.Length == 0 )
							constructor = method;
					}
					probability = proba;
				}
			}
			catch( Exception )
			{
				Console.WriteLine( "Error while constructing {0}", type.ToString() );
			}
		}
		
		public ConstructorInfo Constructor
		{
			get { return constructor; }
		}
		public float Probability
		{
			get { return probability; }
		}
		public int MinAmount
		{
			get { return minAmount; }
		}
		public int MaxAmount
		{
			get { return maxAmount; }
		}
		public Item Create()
		{
			return (Item)constructor.Invoke( null );
		}
		public Item Create( int n )
		{
			Item i = (Item)constructor.Invoke( null );
			i.MaxCount = n;
			return i;
		}
	}
}
