namespace WorldServer
{
    using System;

    internal class CHAR_DELETE_Handler
    {
        public byte[] DeleteCharacter(ByteArrayBuilderV2 data, ClientConnection Client, DatabaseManager DbManager)
        {
            ulong num;
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            data.Get(out num);
            if (DbManager.Write("DELETE FROM characters WHERE guid='" + num.ToString() + "'") < 1)
            {
                rv.Add((byte) 0x36);
                return (byte[]) rv;
            }
            rv.Add((byte) 0x39);
            return (byte[]) rv;
        }
    }
}

