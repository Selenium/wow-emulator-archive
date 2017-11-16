namespace Server.Network
{
    using System;

    public sealed class LaunchBrowser : Packet
    {
        // Methods
        public LaunchBrowser(string url) : base(165)
        {
            if (url == null)
            {
                url = "";
            }
            base.EnsureCapacity((4 + url.Length));
            this.m_Stream.WriteAsciiNull(url);
        }

    }
}

