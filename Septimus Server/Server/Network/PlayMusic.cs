namespace Server.Network
{
    using Server;
    using System;

    public sealed class PlayMusic : Packet
    {
        // Methods
        static PlayMusic()
        {
            PlayMusic.InvalidInstance = new PlayMusic(MusicName.Invalid);
            PlayMusic.m_Instances = new Packet[60];
        }

        public PlayMusic(MusicName name) : base(109, 3)
        {
            this.m_Stream.Write(((short) name));
        }

        public static Packet GetInstance(MusicName name)
        {
            Packet packet1;
            if (name == MusicName.Invalid)
            {
                return PlayMusic.InvalidInstance;
            }
            int num1 = ((int) name);
            if ((num1 >= 0) && (num1 < PlayMusic.m_Instances.Length))
            {
                packet1 = PlayMusic.m_Instances[num1];
                if (packet1 != null)
                {
                    return packet1;
                }
                PlayMusic.m_Instances[num1] = (packet1 = new PlayMusic(name));
                return packet1;
            }
            return new PlayMusic(name);
        }


        // Fields
        public static readonly Packet InvalidInstance;
        private static Packet[] m_Instances;
    }
}

