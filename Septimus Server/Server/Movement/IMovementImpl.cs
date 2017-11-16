namespace Server.Movement
{
    using Server;
    using System;
    using System.Runtime.InteropServices;

    public interface IMovementImpl
    {
        // Methods
        bool CheckMovement(Mobile m, Direction d, out int newZ);

        bool CheckMovement(Mobile m, Map map, Point3D loc, Direction d, out int newZ);

    }
}

