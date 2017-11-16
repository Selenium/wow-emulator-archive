namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileStatus : Packet
    {
        // Methods
        public MobileStatus(Mobile beholder, Mobile beheld) : base(17)
        {
            IWeapon weapon1;
            int num1;
            int num2;
            string text1 = beheld.Name;
            if (text1 == null)
            {
                text1 = "";
            }
            base.EnsureCapacity((43 + ((beholder == beheld) ? 45 : 0)));
            this.m_Stream.Write(Serial.op_Implicit(beheld.Serial));
            this.m_Stream.WriteAsciiFixed(text1, 30);
            if (beholder == beheld)
            {
                this.WriteAttr(beheld.Hits, beheld.HitsMax);
            }
            else
            {
                this.WriteAttrNorm(beheld.Hits, beheld.HitsMax);
            }
            this.m_Stream.Write(beheld.CanBeRenamedBy(beholder));
            if (beholder == beheld)
            {
                this.m_Stream.Write(((byte) (MobileStatus.m_SendAosInfo ? 4 : 3)));
                this.m_Stream.Write(beheld.Female);
                this.m_Stream.Write(((short) beheld.Str));
                this.m_Stream.Write(((short) beheld.Dex));
                this.m_Stream.Write(((short) beheld.Int));
                this.WriteAttr(beheld.Stam, beheld.StamMax);
                this.WriteAttr(beheld.Mana, beheld.ManaMax);
                this.m_Stream.Write(beheld.TotalGold);
                this.m_Stream.Write(((short) (Core.AOS ? beheld.PhysicalResistance : ((int) (beheld.ArmorRating + 0.5)))));
                this.m_Stream.Write(((short) (Mobile.BodyWeight + beheld.TotalWeight)));
                this.m_Stream.Write(((short) beheld.StatCap));
                this.m_Stream.Write(((byte) beheld.Followers));
                this.m_Stream.Write(((byte) beheld.FollowersMax));
                if (!MobileStatus.m_SendAosInfo)
                {
                    return;
                }
                this.m_Stream.Write(((short) beheld.FireResistance));
                this.m_Stream.Write(((short) beheld.ColdResistance));
                this.m_Stream.Write(((short) beheld.PoisonResistance));
                this.m_Stream.Write(((short) beheld.EnergyResistance));
                this.m_Stream.Write(((short) beheld.Luck));
                weapon1 = beheld.Weapon;
                num1 = 0;
                num2 = 0;
                if (weapon1 != null)
                {
                    weapon1.GetStatusDamage(beheld, out num1, out num2);
                }
                this.m_Stream.Write(((short) num1));
                this.m_Stream.Write(((short) num2));
                this.m_Stream.Write(beheld.TithingPoints);
                return;
            }
            this.m_Stream.Write(((byte) 0));
        }

        private void WriteAttr(int current, int maximum)
        {
            this.m_Stream.Write(((short) current));
            this.m_Stream.Write(((short) maximum));
        }

        private void WriteAttrNorm(int current, int maximum)
        {
            AttributeNormalizer.WriteReverse(this.m_Stream, current, maximum);
        }


        // Properties
        public static bool SendAosInfo
        {
            get
            {
                return MobileStatus.m_SendAosInfo;
            }
            set
            {
                MobileStatus.m_SendAosInfo = value;
            }
        }


        // Fields
        private static bool m_SendAosInfo;
    }
}

