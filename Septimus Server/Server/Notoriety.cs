namespace Server
{
    using System;

    public class Notoriety
    {
        // Methods
        static Notoriety()
        {
            Notoriety.m_Hues = new int[8] { 0, 89, 63, 946, 946, 144, 34, 53 };
        }

        public Notoriety()
        {
        }

        public static int Compute(Mobile source, Mobile target)
        {
            if (Notoriety.m_Handler != null)
            {
                return Notoriety.m_Handler(source, target);
            }
            return 3;
        }

        public static int GetHue(int noto)
        {
            if ((noto < 0) || (noto >= Notoriety.m_Hues.Length))
            {
                return 0;
            }
            return Notoriety.m_Hues[noto];
        }


        // Properties
        public static NotorietyHandler Handler
        {
            get
            {
                return Notoriety.m_Handler;
            }
            set
            {
                Notoriety.m_Handler = value;
            }
        }

        public static int[] Hues
        {
            get
            {
                return Notoriety.m_Hues;
            }
            set
            {
                Notoriety.m_Hues = value;
            }
        }


        // Fields
        public const int Ally = 2;
        public const int CanBeAttacked = 3;
        public const int Criminal = 4;
        public const int Enemy = 5;
        public const int Innocent = 1;
        public const int Invulnerable = 7;
        private static NotorietyHandler m_Handler;
        private static int[] m_Hues;
        public const int Murderer = 6;
    }
}

