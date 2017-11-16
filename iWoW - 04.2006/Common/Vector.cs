using System;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Common
{
	public class Vector
	{
		[DataElement(Name="X")]
		public float X;
		[DataElement(Name="Y")]
		public float Y;
		[DataElement(Name="Z")]
		public float Z;

		public Vector()
		{
			X = 0.0f;
			Y = 0.0f;
			Z = 0.0f;
		}

		/*public Vector(string s)
		{
			string[] split = s.Split(' ');
			if(split.Length != 3)
				throw new FormatException("Format should be in \"<x> <y> <z>\"");
			X = float.Parse(split[0]);
			Y = float.Parse(split[1]);
			Z = float.Parse(split[2]);
		}*/

		public Vector(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public float Distance(Vector v)
		{
			return (float)Math.Sqrt(DistanceSqrd(v));
		}

		public double DistanceSqrd(Vector v)
		{
			float dX = X-v.X;
			float dY = Y-v.Y;
			float dZ = Z-v.Z;
			return (dX*dX + dY*dY + dZ*dZ);
		}

		public static Vector operator-(Vector v1, Vector v2)
		{
			return new Vector(v1.X-v2.X, v1.Y-v2.Y, v1.Z-v2.Z);
		}

		public static Vector operator+(Vector v1, Vector v2)
		{
			return new Vector(v1.X+v2.X, v1.Y+v2.Y, v1.Z+v2.Z);
		}

		public float Angle(Vector v)
		{
			return (float)Math.Atan2(v.Y-Y, v.X-X);
		}

		public float Angle(float x, float y)
		{
			return (float)Math.Atan2(y-Y, x-X);
		}
		/// <summary>
		/// Vector Translation
		/// </summary>
		public void Translate(Vector VDest,float range)
		{
			float totalDist = this.Distance(VDest);
			float Rapport = (totalDist-range)/totalDist;
			X+=(VDest.X-X)*Rapport;
			Y+=(VDest.Y-Y)*Rapport;
			Z+=(VDest.Z-Z)*Rapport;			
		}

		/// <summary>
		/// Operator overload to allow loading/saving vectors into db
		/// </summary>
		/*		public static implicit operator Vector(string s)
				{
					return new Vector(s);
				}
		*/
		public override string ToString()
		{
			return "[" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + "]";
		}

	}
}
