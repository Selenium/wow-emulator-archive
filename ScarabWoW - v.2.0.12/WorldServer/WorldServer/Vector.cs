namespace WorldServer
{
    using System;

    public class Vector
    {
        public ulong PlayerGuid;
        public float X;
        public float Y;
        public float Z;

        public Vector()
        {
            this.PlayerGuid = (ulong) 0;
            this.X = 0f;
            this.Y = 0f;
            this.Z = 0f;
        }

        public Vector(float x, float y, float z)
        {
            this.PlayerGuid = (ulong) 0;
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public float Angle(Vector v)
        {
            return (float) Math.Atan2((double) (v.Y - this.Y), (double) (v.X - this.X));
        }

        public float Angle(float x, float y)
        {
            return (float) Math.Atan2((double) (y - this.Y), (double) (x - this.X));
        }

        public float Distance(Vector v)
        {
            return (float) Math.Sqrt(this.DistanceSqrd(v));
        }

        public double DistanceSqrd(Vector v)
        {
            float num = this.X - v.X;
            float num2 = this.Y - v.Y;
            float num3 = this.Z - v.Z;
            return (double) (((num * num) + (num2 * num2)) + (num3 * num3));
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public void Translate(Vector VDest, float range)
        {
            float num = this.Distance(VDest);
            float num2 = (num - range) / num;
            this.X += (VDest.X - this.X) * num2;
            this.Y += (VDest.Y - this.Y) * num2;
            this.Z += (VDest.Z - this.Z) * num2;
        }
    }
}

