namespace Server
{
    using System;
    using System.Collections;

    public interface IVendor
    {
        // Methods
        bool OnBuyItems(Mobile from, ArrayList list);

        bool OnSellItems(Mobile from, ArrayList list);

        void Restock();


        // Properties
        DateTime LastRestock { get; set; }

        TimeSpan RestockDelay { get; }

    }
}

