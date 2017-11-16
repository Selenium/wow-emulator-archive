using System;
using System.Collections.Generic;
using System.Text;

namespace eWoW
{
    public class UpdateMask
    {
        uint[] data;
        ushort count;

        public ushort Count
        {
            get
            {
                return count;
            }
        }

        public ushort Length
        {
            get
            {
                if (data == null)
                    return 0;
                return (ushort)(data.Length * 32);
            }
        }

        public uint[] Data
        {
            get
            {
                return data;
            }
        }

        public UpdateMask Clone()
        {
            return new UpdateMask(this);
        }

        public UpdateMask()
        {
            Clear();
        }

        public UpdateMask(UpdateMask u)
        {
            data = u.data.Clone() as uint[];
            count = u.count;
        }

        public void Clear()
        {
            data = null;
            count = 0;
        }

        public bool Get(ushort idx)
        {
            if (data == null || idx / 32 >= data.Length) return false;
            return (data[idx / 32] & (1 << idx % 32)) != 0;
        }

        public bool Set(ushort idx, bool b)
        {
            if (b && !Get(idx))
            {
                checkSize(idx);
                count++;
                data[idx / 32] |= (uint)(1 << idx % 32);
                return false;
            }
            if (!b && Get(idx))
            {
                checkSize(idx);
                count--;
                data[idx / 32] &= (uint)(~(1 << idx % 32));
                return true;
            }
            return b;
        }

        public void Touch(params UpdateFields[] update)
        {
            foreach (UpdateFields idx in update)
            {
                if (idx < UpdateFields.PLAYER_END)
                    Set((ushort)idx, true);
            }
        }


        void checkSize(ushort idx)
        {
            idx++;

            int mcnt = idx / 32;
            if (idx % 32 > 0) mcnt++;
            if (data != null && mcnt <= data.Length) return;

            uint[] o = data;

            data = new uint[mcnt];
            if (o != null) o.CopyTo(data, 0);
        }

        public bool this[ushort index]
        {
            get
            {
                return Get(index);
            }
            set
            {
                Set(index, value);
            }
        }

        public void BuildUpdate(ByteArrayBuilder pack)
        {
            if (data == null)
            {
                pack.Add((byte)0);
                return;
            }
            int zero = 0;
            for (int i = data.Length - 1; i > 0; i--)
            {
                if (data[i] == 0)
                    zero++;
                else
                    break;
            }
            pack.Add((byte)(data.Length - zero));
            for (int i = 0; i < data.Length - zero; i++)
            {
                pack.Add(data[i]);
            }
        }
    };

	
}
