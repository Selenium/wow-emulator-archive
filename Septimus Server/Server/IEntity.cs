namespace Server
{
    public interface IEntity : IPoint3D, IPoint2D
    {
        // Properties
        Point3D Location { get; }

        Map Map { get; }

        Serial Serial { get; }

    }
}

