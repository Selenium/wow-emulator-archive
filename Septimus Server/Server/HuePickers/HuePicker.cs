namespace Server.HuePickers
{
    using Server.Network;
    using System;

    public class HuePicker
    {
        // Methods
        static HuePicker()
        {
            HuePicker.m_NextSerial = 1;
        }

        public HuePicker(int itemID)
        {
            do
            {
                this.m_Serial = HuePicker.m_NextSerial++;
            }
            while ((this.m_Serial == 0));
            this.m_ItemID = itemID;
        }

        public virtual void OnResponse(int hue)
        {
        }

        public void SendTo(NetState state)
        {
            state.Send(new DisplayHuePicker(this));
            state.AddHuePicker(this);
        }


        // Properties
        public int ItemID
        {
            get
            {
                return this.m_ItemID;
            }
        }

        public int Serial
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private int m_ItemID;
        private static int m_NextSerial;
        private int m_Serial;
    }
}

