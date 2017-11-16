namespace Server.Network
{
    using Server;
    using Server.ContextMenus;
    using System;

    public sealed class DisplayContextMenu : Packet
    {
        // Methods
        public DisplayContextMenu(ContextMenu menu) : base(191)
        {
            Point3D pointd1;
            int num2;
            ContextMenuEntry entry1;
            int num3;
            CMEFlags flags1;
            int num4;
            ContextMenuEntry[] entryArray1 = menu.Entries;
            int num1 = ((byte) entryArray1.Length);
            base.EnsureCapacity((12 + (num1 * 8)));
            this.m_Stream.Write(((short) 20));
            this.m_Stream.Write(((short) 1));
            IEntity entity1 = (menu.Target as IEntity);
            this.m_Stream.Write(Serial.op_Implicit(((entity1 == null) ? Serial.MinusOne : entity1.Serial)));
            this.m_Stream.Write(((byte) num1));
            if ((entity1 is Mobile))
            {
                pointd1 = entity1.Location;
            }
            else if ((entity1 is Item))
            {
                pointd1 = ((Item) entity1).GetWorldLocation();
            }
            else
            {
                pointd1 = Point3D.Zero;
            }
            for (num2 = 0; (num2 < num1); ++num2)
            {
                entry1 = entryArray1[num2];
                this.m_Stream.Write(((short) num2));
                this.m_Stream.Write(((ushort) entry1.Number));
                num3 = entry1.Range;
                if (num3 == -1)
                {
                    num3 = 18;
                }
                flags1 = ((entry1.Enabled && menu.From.InRange(pointd1, num3)) ? CMEFlags.None : CMEFlags.Disabled);
                num4 = (entry1.Color & 65535);
                if (num4 != 65535)
                {
                    flags1 |= CMEFlags.Colored;
                }
                flags1 |= entry1.Flags;
                this.m_Stream.Write(((short) flags1));
                if ((flags1 & CMEFlags.Colored) != CMEFlags.None)
                {
                    this.m_Stream.Write(((short) num4));
                }
            }
        }

    }
}

