namespace WorldServer
{
    using System;
    using System.Collections;

    public class UpdateMask
    {
        private object[] data = new object[0x502];
        private uint[] mask = new uint[0x29];
        private ArrayList setbits = new ArrayList();

        public void BuildUpdate(ByteArrayBuilderV2 pack)
        {
            pack.Add((byte) this.mask.Length);
            pack.Add(this.mask);
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    pack.Add((byte[]) this.data[i]);
                }
            }
        }

        public void GetMask(ByteArrayBuilderV2 pack)
        {
            pack.Add(this.mask);
        }

        public void SetBit(ushort field)
        {
            this.mask[field / 0x20] |= ((uint) 1) << (field % 0x20);
        }

        public void SetBit(ushort field, byte[] value)
        {
            this.SetBit(field);
            this.data[field] = value;
        }

        public void SetBit(ushort field, float value)
        {
            this.SetBit(field);
            this.data[field] = BitConverter.GetBytes(value);
        }

        public void SetBit(ushort field, uint value)
        {
            this.SetBit(field);
            this.data[field] = BitConverter.GetBytes(value);
        }

        public void SetBit(ushort field, ulong value)
        {
            this.SetBit(field);
            this.data[field] = BitConverter.GetBytes(value);
        }
    }
}

