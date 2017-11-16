namespace Server.Network
{
    using System;

    public sealed class SetWarMode : Packet
    {
        // Methods
        static SetWarMode()
        {
            SetWarMode.InWarMode = new SetWarMode(true);
            SetWarMode.InPeaceMode = new SetWarMode(false);
        }

        public SetWarMode(bool mode) : base(114, 5)
        {
            this.m_Stream.Write(mode);
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) 50));
            this.m_Stream.Write(((byte) 0));
        }

        public static SetWarMode Instantiate(bool mode)
        {
            if (!mode)
            {
                return SetWarMode.InPeaceMode;
            }
            return SetWarMode.InWarMode;
        }


        // Fields
        public static readonly SetWarMode InPeaceMode;
        public static readonly SetWarMode InWarMode;
    }
}

