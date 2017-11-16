namespace Server.Network
{
    using Server.Prompts;
    using System;

    public sealed class UnicodePrompt : Packet
    {
        // Methods
        public UnicodePrompt(Prompt prompt) : base(194)
        {
            base.EnsureCapacity(21);
            this.m_Stream.Write(prompt.Serial);
            this.m_Stream.Write(prompt.Serial);
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
            this.m_Stream.Write(((short) 0));
        }

    }
}

