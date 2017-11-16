namespace Server.Mobiles
{
    using Server;
    using System;
    using System.Collections;

    public class BuyItemStateComparer : IComparer
    {
        // Methods
        public BuyItemStateComparer()
        {
        }

        public int Compare(object l, object r)
        {
            if ((l == null) && (r == null))
            {
                return 0;
            }
            if (l == null)
            {
                return -1;
            }
            if (r == null)
            {
                return 1;
            }
            Serial serial1 = ((BuyItemState) l).MySerial;
            return serial1.CompareTo(((BuyItemState) r).MySerial);
        }

    }
}

