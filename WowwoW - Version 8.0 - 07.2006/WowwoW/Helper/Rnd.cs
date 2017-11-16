// Created by Volhv
// Idea: RunUO team
// Last changes: 14.09.05
using System;

namespace Server
{
	public class Rnd
	{
		private static Random _random = new Random();

		#region Simple randoms
		public static int Random( int count )
		{
			return _random.Next( count );
		}
		public static int Random( int from, int count )
		{
			if ( count == 0 )
			{
				return from;
			}
			else if ( count > 0 )
			{
				return from + _random.Next( count );
			}
			else
			{
				return from - _random.Next( -count );
			}
		}
		public static int RandomMinMax( int min, int max )
		{
			if ( min > max )
			{
				int copy = min;
				min = max;
				max = copy;
			}
			else if ( min == max )
			{
				return min;
			}
			return min + _random.Next( (max - min) + 1 );
		}
		public static double RandomDouble()
		{
			return _random.NextDouble();
		}
		public static bool RandomBool()
		{
			return ( _random.Next( 2 ) == 0 );
		}
		#endregion

		#region Array randoms
		public static int RandomIntArr( params int[] arr )
		{
			return arr[_random.Next( arr.Length )];
		}
		public static double RandomDoubleArr( params double[] arr )
		{
			return arr[_random.Next( arr.Length )];
		}
		public static float RandomFloatArr( params float[] arr )
		{
			return arr[_random.Next( arr.Length )];
		}
		public static object RandomObjectArr( params object[] arr )
		{
			return arr[_random.Next( arr.Length )];
		}
		#endregion

		#region Dice AD&D
		/// <summary>
		/// for 8d6+5 must use Dice( 8, 6, 5 )
		/// </summary>
		public static int Dice( int numDice, int numSides, int bonus )
		{
			int total = 0;
			for (int i=0;i<numDice;++i)
				total += Random( numSides ) + 1;
			total += bonus;
			return total;
		}
		#endregion

	}
}
