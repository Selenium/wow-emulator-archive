namespace Server
{
    using System;

    public interface IParty
    {
        // Methods
        void OnManaChanged(Mobile m);

        void OnStamChanged(Mobile m);

        void OnStatsQuery(Mobile beholder, Mobile beheld);

    }
}

