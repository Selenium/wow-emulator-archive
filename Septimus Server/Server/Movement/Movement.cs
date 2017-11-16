namespace Server.Movement
{
    using Server;
    using System;
    using System.Runtime.InteropServices;

    public class Movement
    {
        // Methods
        public Movement()
        {
        }

        public static bool CheckMovement(Mobile m, Direction d, out int newZ)
        {
            if (Movement.m_Impl != null)
            {
                return Movement.m_Impl.CheckMovement(m, d, out newZ);
            }
            newZ = m.Z;
            return false;
        }

        public static bool CheckMovement(Mobile m, Map map, Point3D loc, Direction d, out int newZ)
        {
            if (Movement.m_Impl != null)
            {
                return Movement.m_Impl.CheckMovement(m, map, loc, d, out newZ);
            }
            newZ = m.Z;
            return false;
        }

        public static void Offset(Direction d, ref int x, ref int y)
        {
            switch ((d & 7))
            {
                case Direction.North:
                {
                    --y;
                    return;
                }
                case Direction.Right:
                {
                    ++x;
                    --y;
                    return;
                }
                case Direction.East:
                {
                    ++x;
                    return;
                }
                case Direction.Down:
                {
                    ++x;
                    ++y;
                    return;
                }
                case Direction.South:
                {
                    ++y;
                    return;
                }
                case Direction.Left:
                {
                    --x;
                    ++y;
                    return;
                }
                case Direction.West:
                {
                    --x;
                    return;
                }
                case Direction.Up:
                {
                    --x;
                    --y;
                    return;
                }
            }
        }


        // Properties
        public static IMovementImpl Impl
        {
            get
            {
                return Movement.m_Impl;
            }
            set
            {
                Movement.m_Impl = value;
            }
        }


        // Fields
        private static IMovementImpl m_Impl;
    }
}

