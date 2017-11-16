using System;

namespace HelperTools
{
	/// <summary>
	/// Summary description for Helper.
	/// </summary>
	public class Helper
	{
		public Helper()
		{
		}
		static double AR1 = 1345.0;
		static double AR2 = 12231;
		public static double ARandom()
		{

			long   i;
			double r, z;

			r = AR1 / 53668;
			i = (long)r;
			r = (double)i;
			AR1 = 40014 * (AR1 - r * 53668) - r * 12211;
			if (AR1 < 0)
				AR1 += 2147483563;
			r = AR2 / 52774;
			i = (long)r;
			r = (double)i;
			AR2 = 40692 * (AR2 - r * 52774) - r * 3791;
			if (AR2 < 0)
				AR2 += 2147483399;
			z = AR1 - AR2;
			if (z < 1)
				z += 2147483562;
			return z * 4.656613e-10;
		}
	}


}
