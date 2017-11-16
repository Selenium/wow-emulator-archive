namespace Server.Network
{
    using Server.Menus.ItemLists;
    using System;

    public sealed class DisplayItemListMenu : Packet
    {
        // Methods
        public DisplayItemListMenu(ItemListMenu menu) : base(124)
        {
            int num3;
            ItemListEntry entry1;
            string text2;
            int num4;
            base.EnsureCapacity(256);
            this.m_Stream.Write(menu.Serial);
            this.m_Stream.Write(((short) 0));
            string text1 = menu.Question;
            if (text1 == null)
            {
                text1 = "";
            }
            int num1 = ((byte) text1.Length);
            this.m_Stream.Write(((byte) num1));
            this.m_Stream.WriteAsciiFixed(text1, num1);
            ItemListEntry[] entryArray1 = menu.Entries;
            int num2 = ((byte) entryArray1.Length);
            this.m_Stream.Write(((byte) num2));
            for (num3 = 0; (num3 < num2); ++num3)
            {
                entry1 = entryArray1[num3];
                this.m_Stream.Write(((short) (entry1.ItemID & 16383)));
                this.m_Stream.Write(((short) entry1.Hue));
                text2 = entry1.Name;
                if (text2 == null)
                {
                    text2 = "";
                }
                num4 = ((byte) text2.Length);
                this.m_Stream.Write(((byte) num4));
                this.m_Stream.WriteAsciiFixed(text2, num4);
            }
        }

    }
}

