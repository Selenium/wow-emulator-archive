namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileStatusExtended : Packet
    {
        // Methods
        public MobileStatusExtended(Mobile m) : base(17)
        {
            string text1 = m.Name;
            if (text1 == null)
            {
                text1 = "";
            }
            base.EnsureCapacity(88);
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.WriteAsciiFixed(text1, 30);
            this.m_Stream.Write(((short) m.Hits));
            this.m_Stream.Write(((short) m.HitsMax));
            this.m_Stream.Write(m.CanBeRenamedBy(m));
            this.m_Stream.Write(((byte) (MobileStatus.SendAosInfo ? 4 : 3)));
            this.m_Stream.Write(m.Female);
            this.m_Stream.Write(((short) m.Str));
            this.m_Stream.Write(((short) m.Dex));
            this.m_Stream.Write(((short) m.Int));
            this.m_Stream.Write(((short) m.Stam));
            this.m_Stream.Write(((short) m.StamMax));
            this.m_Stream.Write(((short) m.Mana));
            this.m_Stream.Write(((short) m.ManaMax));
            this.m_Stream.Write(m.TotalGold);
            this.m_Stream.Write(((short) (Core.AOS ? m.PhysicalResistance : ((int) (m.ArmorRating + 0.5)))));
            this.m_Stream.Write(((short) (Mobile.BodyWeight + m.TotalWeight)));
            this.m_Stream.Write(((short) m.StatCap));
            this.m_Stream.Write(((byte) m.Followers));
            this.m_Stream.Write(((byte) m.FollowersMax));
            if (!MobileStatus.SendAosInfo)
            {
                return;
            }
            this.m_Stream.Write(((short) m.FireResistance));
            this.m_Stream.Write(((short) m.ColdResistance));
            this.m_Stream.Write(((short) m.PoisonResistance));
            this.m_Stream.Write(((short) m.EnergyResistance));
            this.m_Stream.Write(((short) m.Luck));
            IWeapon weapon1 = m.Weapon;
            int num1 = 0;
            int num2 = 0;
            if (weapon1 != null)
            {
                weapon1.GetStatusDamage(m, out num1, out num2);
            }
            this.m_Stream.Write(((short) num1));
            this.m_Stream.Write(((short) num2));
            this.m_Stream.Write(m.TithingPoints);
        }

    }
}

