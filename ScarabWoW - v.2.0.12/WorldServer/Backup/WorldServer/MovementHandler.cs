namespace WorldServer
{
    using System;

    internal class MovementHandler
    {
        public void Move(ClientConnection Client, ByteArrayBuilderV2 Data)
        {
            uint num;
            uint num2;
            float num3;
            float num4;
            float num5;
            float num6;
            Data.Get(out num);
            Data.Get(out num2);
            Data.Get(out num3);
            Data.Get(out num4);
            Data.Get(out num5);
            Data.Get(out num6);
            Console.WriteLine("X:{0} Y:{1} Z:{2} O:{3}", new object[] { num3, num4, num5, num6 });
        }
    }
}

