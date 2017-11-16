namespace Server
{
    using System;

    public interface ISpell
    {
        // Methods
        bool OnCasterEquiping(Item item);

        void OnCasterHurt();

        void OnCasterKilled();

        bool OnCasterMoving(Direction d);

        bool OnCasterUsingObject(object o);

        bool OnCastInTown(Region r);

        void OnConnectionChanged();


        // Properties
        bool IsCasting { get; }

    }
}

