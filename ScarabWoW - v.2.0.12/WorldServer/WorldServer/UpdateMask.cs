namespace WorldServer
{
    using System;
    using System.Collections.Generic;

    public class UpdateMask
    {
        private uint[] mask = new uint[0x2d];
        private SortedDictionary<ushort, uint> updateValues = new SortedDictionary<ushort, uint>();

        public void BuildUpdate(ByteArrayBuilderV2 pack)
        {
            pack.Add((byte) this.mask.Length);
            pack.Add(this.mask);
            foreach (uint num in this.updateValues.Values)
            {
                pack.Add(num);
            }
        }

        public bool GetBit(UpdateFields index)
        {
            return ((this.mask[((ushort) index) / 0x20] & (((int) 1) << (((ushort) index) % 0x20))) != 0);
        }

        public void GetMask(ByteArrayBuilderV2 pack)
        {
            pack.Add(this.mask);
        }

        public uint GetValue(UpdateFields index)
        {
            if (!this.updateValues.ContainsKey((ushort) index))
            {
                return 0;
            }
            return this.updateValues[(ushort) index];
        }

        public void SetBit(ushort field)
        {
            this.mask[field / 0x20] |= ((uint) 1) << (field % 0x20);
        }

        public void SetBit(UpdateFields field)
        {
            this.mask[((ushort) field) / 0x20] |= ((uint) 1) << (((ushort) field) % 0x20);
        }

        public void SetBit(ushort field, uint value)
        {
            this.SetBit(field);
            this.updateValues[field] = value;
        }

        public void SetBit(UpdateFields field, float value)
        {
            this.SetBit(field, BitConverter.ToUInt32(BitConverter.GetBytes(value), 0));
        }

        public void SetBit(UpdateFields field, uint value)
        {
            this.SetBit(field);
            this.updateValues[(ushort) field] = value;
        }

        public void SetBit(UpdateFields field, ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            this.SetBit(field, BitConverter.ToUInt32(BitConverter.GetBytes(value), 0));
            this.SetBit(field + 1, BitConverter.ToUInt32(BitConverter.GetBytes(value), 4));
        }

        public void SetBit(UpdateFields field, byte[] value)
        {
            this.SetBit(field, BitConverter.ToUInt32(value, 0));
        }

        public int Length
        {
            get
            {
                return this.mask.Length;
            }
            set
            {
                this.mask = new uint[value];
            }
        }
    }
}

