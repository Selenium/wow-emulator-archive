namespace Server.Network
{
    using Server;
    using System;

    public sealed class MessageLocalized : Packet
    {
        // Methods
        static MessageLocalized()
        {
            MessageLocalized.m_Cache_IntLoc = new MessageLocalized[15000];
            MessageLocalized.m_Cache_CliLoc = new MessageLocalized[100000];
            MessageLocalized.m_Cache_CliLocCmp = new MessageLocalized[5000];
        }

        public MessageLocalized(Serial serial, int graphic, MessageType type, int hue, int font, int number, string name, string args) : base(193)
        {
            if (name == null)
            {
                name = "";
            }
            if (args == null)
            {
                args = "";
            }
            if (hue == 0)
            {
                hue = 946;
            }
            base.EnsureCapacity((50 + (args.Length * 2)));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((short) graphic));
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(((short) hue));
            this.m_Stream.Write(((short) font));
            this.m_Stream.Write(number);
            this.m_Stream.WriteAsciiFixed(name, 30);
            this.m_Stream.WriteLittleUniNull(args);
        }

        public static MessageLocalized InstantiateGeneric(int number)
        {
            MessageLocalized localized1;
            MessageLocalized[] localizedArray1 = null;
            int num1 = 0;
            if (number >= 3000000)
            {
                localizedArray1 = MessageLocalized.m_Cache_IntLoc;
                num1 = (number - 3000000);
            }
            else if (number >= 1000000)
            {
                localizedArray1 = MessageLocalized.m_Cache_CliLoc;
                num1 = (number - 1000000);
            }
            else if (number >= 500000)
            {
                localizedArray1 = MessageLocalized.m_Cache_CliLocCmp;
                num1 = (number - 500000);
            }
            if (((localizedArray1 != null) && (num1 >= 0)) && (num1 < localizedArray1.Length))
            {
                localized1 = localizedArray1[num1];
                if (localized1 != null)
                {
                    return localized1;
                }
                localizedArray1[num1] = (localized1 = new MessageLocalized(Serial.MinusOne, -1, MessageType.Regular, 946, 3, number, "System", ""));
                return localized1;
            }
            return new MessageLocalized(Serial.MinusOne, -1, MessageType.Regular, 946, 3, number, "System", "");
        }


        // Fields
        private static MessageLocalized[] m_Cache_CliLoc;
        private static MessageLocalized[] m_Cache_CliLocCmp;
        private static MessageLocalized[] m_Cache_IntLoc;
    }
}

