namespace Server.Network
{
    using System;

    public sealed class SeasonChange : Packet
    {
        // Methods
        static SeasonChange()
        {
            SeasonChange[][] changeArrayArray1 = new SeasonChange[5][];
            changeArrayArray1[0] = new SeasonChange[2];
            changeArrayArray1[1] = new SeasonChange[2];
            changeArrayArray1[2] = new SeasonChange[2];
            changeArrayArray1[3] = new SeasonChange[2];
            changeArrayArray1[4] = new SeasonChange[2];
            SeasonChange.m_Cache = changeArrayArray1;
        }

        public SeasonChange(int season) : this(season, true)
        {
        }

        public SeasonChange(int season, bool playSound) : base(188, 3)
        {
            this.m_Stream.Write(((byte) season));
            this.m_Stream.Write(playSound);
        }

        public static SeasonChange Instantiate(int season)
        {
            return SeasonChange.Instantiate(season, true);
        }

        public static SeasonChange Instantiate(int season, bool playSound)
        {
            int num1;
            SeasonChange change1;
            if ((season >= 0) && (season < SeasonChange.m_Cache.Length))
            {
                num1 = (playSound ? 1 : 0);
                change1 = SeasonChange.m_Cache[season][num1];
                if (change1 == null)
                {
                    SeasonChange.m_Cache[season][num1] = (change1 = new SeasonChange(season, playSound));
                }
                return change1;
            }
            return new SeasonChange(season, playSound);
        }


        // Fields
        private static SeasonChange[][] m_Cache;
    }
}

