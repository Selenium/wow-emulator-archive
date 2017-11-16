using System;

public class BigInteger
{
    private uint[] data;
    public int dataLength;
    private const int maxLength = 70;
    public static readonly int[] primesBelow2000 = new int[] { 
        2, 3, 5, 7, 11, 13, 0x11, 0x13, 0x17, 0x1d, 0x1f, 0x25, 0x29, 0x2b, 0x2f, 0x35, 
        0x3b, 0x3d, 0x43, 0x47, 0x49, 0x4f, 0x53, 0x59, 0x61, 0x65, 0x67, 0x6b, 0x6d, 0x71, 0x7f, 0x83, 
        0x89, 0x8b, 0x95, 0x97, 0x9d, 0xa3, 0xa7, 0xad, 0xb3, 0xb5, 0xbf, 0xc1, 0xc5, 0xc7, 0xd3, 0xdf, 
        0xe3, 0xe5, 0xe9, 0xef, 0xf1, 0xfb, 0x101, 0x107, 0x10d, 0x10f, 0x115, 0x119, 0x11b, 0x125, 0x133, 0x137, 
        0x139, 0x13d, 0x14b, 0x151, 0x15b, 0x15d, 0x161, 0x167, 0x16f, 0x175, 0x17b, 0x17f, 0x185, 0x18d, 0x191, 0x199, 
        0x1a3, 0x1a5, 0x1af, 0x1b1, 0x1b7, 0x1bb, 0x1c1, 0x1c9, 0x1cd, 0x1cf, 0x1d3, 0x1df, 0x1e7, 0x1eb, 0x1f3, 0x1f7, 
        0x1fd, 0x209, 0x20b, 0x21d, 0x223, 0x22d, 0x233, 0x239, 0x23b, 0x241, 0x24b, 0x251, 0x257, 0x259, 0x25f, 0x265, 
        0x269, 0x26b, 0x277, 0x281, 0x283, 0x287, 0x28d, 0x293, 0x295, 0x2a1, 0x2a5, 0x2ab, 0x2b3, 0x2bd, 0x2c5, 0x2cf, 
        0x2d7, 0x2dd, 0x2e3, 0x2e7, 0x2ef, 0x2f5, 0x2f9, 0x301, 0x305, 0x313, 0x31d, 0x329, 0x32b, 0x335, 0x337, 0x33b, 
        0x33d, 0x347, 0x355, 0x359, 0x35b, 0x35f, 0x36d, 0x371, 0x373, 0x377, 0x38b, 0x38f, 0x397, 0x3a1, 0x3a9, 0x3ad, 
        0x3b3, 0x3b9, 0x3c7, 0x3cb, 0x3d1, 0x3d7, 0x3df, 0x3e5, 0x3f1, 0x3f5, 0x3fb, 0x3fd, 0x407, 0x409, 0x40f, 0x419, 
        0x41b, 0x425, 0x427, 0x42d, 0x43f, 0x443, 0x445, 0x449, 0x44f, 0x455, 0x45d, 0x463, 0x469, 0x47f, 0x481, 0x48b, 
        0x493, 0x49d, 0x4a3, 0x4a9, 0x4b1, 0x4bd, 0x4c1, 0x4c7, 0x4cd, 0x4cf, 0x4d5, 0x4e1, 0x4eb, 0x4fd, 0x4ff, 0x503, 
        0x509, 0x50b, 0x511, 0x515, 0x517, 0x51b, 0x527, 0x529, 0x52f, 0x551, 0x557, 0x55d, 0x565, 0x577, 0x581, 0x58f, 
        0x593, 0x595, 0x599, 0x59f, 0x5a7, 0x5ab, 0x5ad, 0x5b3, 0x5bf, 0x5c9, 0x5cb, 0x5cf, 0x5d1, 0x5d5, 0x5db, 0x5e7, 
        0x5f3, 0x5fb, 0x607, 0x60d, 0x611, 0x617, 0x61f, 0x623, 0x62b, 0x62f, 0x63d, 0x641, 0x647, 0x649, 0x64d, 0x653, 
        0x655, 0x65b, 0x665, 0x679, 0x67f, 0x683, 0x685, 0x69d, 0x6a1, 0x6a3, 0x6ad, 0x6b9, 0x6bb, 0x6c5, 0x6cd, 0x6d3, 
        0x6d9, 0x6df, 0x6f1, 0x6f7, 0x6fb, 0x6fd, 0x709, 0x713, 0x71f, 0x727, 0x737, 0x745, 0x74b, 0x74f, 0x751, 0x755, 
        0x757, 0x761, 0x76d, 0x773, 0x779, 0x78b, 0x78d, 0x79d, 0x79f, 0x7b5, 0x7bb, 0x7c3, 0x7c9, 0x7cd, 0x7cf
     };

    public BigInteger()
    {
        this.data = null;
        this.data = new uint[70];
        this.dataLength = 1;
    }

    public BigInteger(BigInteger bi)
    {
        this.data = null;
        this.data = new uint[70];
        this.dataLength = bi.dataLength;
        for (int i = 0; i < this.dataLength; i++)
        {
            this.data[i] = bi.data[i];
        }
    }

    public BigInteger(long value)
    {
        this.data = null;
        this.data = new uint[70];
        long num = value;
        this.dataLength = 0;
        while ((value != 0) && (this.dataLength < 70))
        {
            this.data[this.dataLength] = (uint) (((ulong) value) & 0xffffffff);
            value = value >> 0x20;
            this.dataLength++;
        }
        if (num > 0)
        {
            if ((value != 0) || ((this.data[0x45] & 0x80000000) != 0))
            {
                throw new ArithmeticException("Positive overflow in constructor.");
            }
        }
        else if ((num < 0) && ((value != -1) || ((this.data[this.dataLength - 1] & 0x80000000) == 0)))
        {
            throw new ArithmeticException("Negative underflow in constructor.");
        }
        if (this.dataLength == 0)
        {
            this.dataLength = 1;
        }
    }

    public BigInteger(ulong value)
    {
        this.data = null;
        this.data = new uint[70];
        this.dataLength = 0;
        while ((value != 0) && (this.dataLength < 70))
        {
            this.data[this.dataLength] = (uint) (value & 0xffffffff);
            value = value >> 0x20;
            this.dataLength++;
        }
        if ((value != 0) || ((this.data[0x45] & 0x80000000) != 0))
        {
            throw new ArithmeticException("Positive overflow in constructor.");
        }
        if (this.dataLength == 0)
        {
            this.dataLength = 1;
        }
    }

    public BigInteger(byte[] inData)
    {
        this.data = null;
        this.dataLength = inData.Length >> 2;
        int num = inData.Length & 3;
        if (num != 0)
        {
            this.dataLength++;
        }
        if (this.dataLength > 70)
        {
            throw new ArithmeticException("Byte overflow in constructor.");
        }
        this.data = new uint[70];
        int index = inData.Length - 1;
        for (int i = 0; index >= 3; i++)
        {
            this.data[i] = (uint) ((((inData[index - 3] << 0x18) + (inData[index - 2] << 0x10)) + (inData[index - 1] << 8)) + inData[index]);
            index -= 4;
        }
        switch (num)
        {
            case 1:
                this.data[this.dataLength - 1] = inData[0];
                break;

            case 2:
                this.data[this.dataLength - 1] = (uint) ((inData[0] << 8) + inData[1]);
                break;

            case 3:
                this.data[this.dataLength - 1] = (uint) (((inData[0] << 0x10) + (inData[1] << 8)) + inData[2]);
                break;
        }
        while ((this.dataLength > 1) && (this.data[this.dataLength - 1] == 0))
        {
            this.dataLength--;
        }
    }

    public BigInteger(uint[] inData)
    {
        this.data = null;
        this.dataLength = inData.Length;
        if (this.dataLength > 70)
        {
            throw new ArithmeticException("Byte overflow in constructor.");
        }
        this.data = new uint[70];
        int index = this.dataLength - 1;
        for (int i = 0; index >= 0; i++)
        {
            this.data[i] = inData[index];
            index--;
        }
        while ((this.dataLength > 1) && (this.data[this.dataLength - 1] == 0))
        {
            this.dataLength--;
        }
    }

    public BigInteger(byte[] inData, int inLen)
    {
        this.data = null;
        this.dataLength = inLen >> 2;
        int num = inLen & 3;
        if (num != 0)
        {
            this.dataLength++;
        }
        if ((this.dataLength > 70) || (inLen > inData.Length))
        {
            throw new ArithmeticException("Byte overflow in constructor.");
        }
        this.data = new uint[70];
        int index = inLen - 1;
        for (int i = 0; index >= 3; i++)
        {
            this.data[i] = (uint) ((((inData[index - 3] << 0x18) + (inData[index - 2] << 0x10)) + (inData[index - 1] << 8)) + inData[index]);
            index -= 4;
        }
        switch (num)
        {
            case 1:
                this.data[this.dataLength - 1] = inData[0];
                break;

            case 2:
                this.data[this.dataLength - 1] = (uint) ((inData[0] << 8) + inData[1]);
                break;

            case 3:
                this.data[this.dataLength - 1] = (uint) (((inData[0] << 0x10) + (inData[1] << 8)) + inData[2]);
                break;
        }
        if (this.dataLength == 0)
        {
            this.dataLength = 1;
        }
        while ((this.dataLength > 1) && (this.data[this.dataLength - 1] == 0))
        {
            this.dataLength--;
        }
    }

    public BigInteger(string value, int radix)
    {
        int num2;
        this.data = null;
        BigInteger integer = new BigInteger((long) 1);
        BigInteger integer2 = new BigInteger();
        value = value.ToUpper().Trim();
        int num = 0;
        if (value[0] == '-')
        {
            num = 1;
        }
        for (num2 = value.Length - 1; num2 >= num; num2--)
        {
            int num3 = value[num2];
            if ((num3 >= 0x30) && (num3 <= 0x39))
            {
                num3 -= 0x30;
            }
            else if ((num3 >= 0x41) && (num3 <= 90))
            {
                num3 = (num3 - 0x41) + 10;
            }
            else
            {
                num3 = 0x98967f;
            }
            if (num3 >= radix)
            {
                throw new ArithmeticException("Invalid string in constructor.");
            }
            if (value[0] == '-')
            {
                num3 = -num3;
            }
            integer2 += integer * num3;
            if ((num2 - 1) >= num)
            {
                integer *= radix;
            }
        }
        if (value[0] == '-')
        {
            if ((integer2.data[0x45] & 0x80000000) == 0)
            {
                throw new ArithmeticException("Negative underflow in constructor.");
            }
        }
        else if ((integer2.data[0x45] & 0x80000000) != 0)
        {
            throw new ArithmeticException("Positive overflow in constructor.");
        }
        this.data = new uint[70];
        for (num2 = 0; num2 < integer2.dataLength; num2++)
        {
            this.data[num2] = integer2.data[num2];
        }
        this.dataLength = integer2.dataLength;
    }

    public BigInteger abs()
    {
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            return op_UnaryNegation(this);
        }
        return new BigInteger(this);
    }

    private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
    {
        int num5;
        int dataLength = n.dataLength;
        int index = dataLength + 1;
        int num3 = dataLength - 1;
        BigInteger integer = new BigInteger();
        int num4 = num3;
        for (num5 = 0; num4 < x.dataLength; num5++)
        {
            integer.data[num5] = x.data[num4];
            num4++;
        }
        integer.dataLength = x.dataLength - num3;
        if (integer.dataLength <= 0)
        {
            integer.dataLength = 1;
        }
        BigInteger integer2 = integer * constant;
        BigInteger integer3 = new BigInteger();
        num4 = index;
        for (num5 = 0; num4 < integer2.dataLength; num5++)
        {
            integer3.data[num5] = integer2.data[num4];
            num4++;
        }
        integer3.dataLength = integer2.dataLength - index;
        if (integer3.dataLength <= 0)
        {
            integer3.dataLength = 1;
        }
        BigInteger integer4 = new BigInteger();
        int num6 = (x.dataLength > index) ? index : x.dataLength;
        for (num4 = 0; num4 < num6; num4++)
        {
            integer4.data[num4] = x.data[num4];
        }
        integer4.dataLength = num6;
        BigInteger integer5 = new BigInteger();
        for (num4 = 0; num4 < integer3.dataLength; num4++)
        {
            if (integer3.data[num4] != 0)
            {
                ulong num7 = (ulong) 0;
                int num8 = num4;
                num5 = 0;
                while ((num5 < n.dataLength) && (num8 < index))
                {
                    ulong num9 = ((integer3.data[num4] * n.data[num5]) + integer5.data[num8]) + num7;
                    integer5.data[num8] = (uint) (num9 & 0xffffffff);
                    num7 = num9 >> 0x20;
                    num5++;
                    num8++;
                }
                if (num8 < index)
                {
                    integer5.data[num8] = (uint) num7;
                }
            }
        }
        integer5.dataLength = index;
        while ((integer5.dataLength > 1) && (integer5.data[integer5.dataLength - 1] == 0))
        {
            integer5.dataLength--;
        }
        integer4 -= integer5;
        if ((integer4.data[0x45] & 0x80000000) != 0)
        {
            BigInteger integer6 = new BigInteger();
            integer6.data[index] = 1;
            integer6.dataLength = index + 1;
            integer4 += integer6;
        }
        while (integer4 >= n)
        {
            integer4 -= n;
        }
        return integer4;
    }

    public int bitCount()
    {
        while ((this.dataLength > 1) && (this.data[this.dataLength - 1] == 0))
        {
            this.dataLength--;
        }
        uint num = this.data[this.dataLength - 1];
        uint num2 = 0x80000000;
        int num3 = 0x20;
        while ((num3 > 0) && ((num & num2) == 0))
        {
            num3--;
            num2 = num2 >> 1;
        }
        return (num3 + ((this.dataLength - 1) << 5));
    }

    public override bool Equals(object o)
    {
        BigInteger integer = (BigInteger) o;
        if (this.dataLength != integer.dataLength)
        {
            return false;
        }
        for (int i = 0; i < this.dataLength; i++)
        {
            if (this.data[i] != integer.data[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool FermatLittleTest(int confidence)
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if (integer.dataLength == 1)
        {
            if ((integer.data[0] == 0) || (integer.data[0] == 1))
            {
                return false;
            }
            if ((integer.data[0] == 2) || (integer.data[0] == 3))
            {
                return true;
            }
        }
        if ((integer.data[0] & 1) == 0)
        {
            return false;
        }
        int num = integer.bitCount();
        BigInteger integer2 = new BigInteger();
        BigInteger exp = integer - new BigInteger((long) 1);
        Random rand = new Random();
        for (int i = 0; i < confidence; i++)
        {
            bool flag = false;
            while (!flag)
            {
                int bits = 0;
                while (bits < 2)
                {
                    bits = (int) (rand.NextDouble() * num);
                }
                integer2.genRandomBits(bits, rand);
                int num4 = integer2.dataLength;
                if ((num4 > 1) || ((num4 == 1) && (integer2.data[0] != 1)))
                {
                    flag = true;
                }
            }
            BigInteger integer4 = integer2.gcd(integer);
            if ((integer4.dataLength == 1) && (integer4.data[0] != 1))
            {
                return false;
            }
            BigInteger integer5 = integer2.modPow(exp, integer);
            int dataLength = integer5.dataLength;
            if ((dataLength > 1) || ((dataLength == 1) && (integer5.data[0] != 1)))
            {
                return false;
            }
        }
        return true;
    }

    public BigInteger gcd(BigInteger bi)
    {
        BigInteger integer;
        BigInteger integer2;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if ((bi.data[0x45] & 0x80000000) != 0)
        {
            integer2 = op_UnaryNegation(bi);
        }
        else
        {
            integer2 = bi;
        }
        BigInteger integer3 = integer2;
        while ((integer.dataLength > 1) || ((integer.dataLength == 1) && (integer.data[0] != 0)))
        {
            integer3 = integer;
            integer = op_Modulus(integer2, integer);
            integer2 = integer3;
        }
        return integer3;
    }

    public BigInteger genCoPrime(int bits, Random rand)
    {
        bool flag = false;
        BigInteger integer = new BigInteger();
        while (!flag)
        {
            integer.genRandomBits(bits, rand);
            BigInteger integer2 = integer.gcd(this);
            if ((integer2.dataLength == 1) && (integer2.data[0] == 1))
            {
                flag = true;
            }
        }
        return integer;
    }

    public static BigInteger genPseudoPrime(int bits, int confidence, Random rand)
    {
        BigInteger integer = new BigInteger();
        for (bool flag = false; !flag; flag = integer.isProbablePrime(confidence))
        {
            integer.genRandomBits(bits, rand);
            integer.data[0] |= 1;
        }
        return integer;
    }

    public void genRandomBits(int bits, Random rand)
    {
        int num3;
        int num = bits >> 5;
        int num2 = bits & 0x1f;
        if (num2 != 0)
        {
            num++;
        }
        if (num > 70)
        {
            throw new ArithmeticException("Number of required bits > maxLength.");
        }
        for (num3 = 0; num3 < num; num3++)
        {
            this.data[num3] = (uint) (rand.NextDouble() * 4294967296);
        }
        for (num3 = num; num3 < 70; num3++)
        {
            this.data[num3] = 0;
        }
        if (num2 != 0)
        {
            uint num4 = ((uint) 1) << (num2 - 1);
            this.data[num - 1] |= num4;
            num4 = ((uint) (-1)) >> (0x20 - num2);
            this.data[num - 1] &= num4;
        }
        else
        {
            this.data[num - 1] |= 0x80000000;
        }
        this.dataLength = num;
        if (this.dataLength == 0)
        {
            this.dataLength = 1;
        }
    }

    public byte[] getBytes()
    {
        return this.getBytes(0);
    }

    public byte[] getBytes(int numBytes)
    {
        int num = this.bitCount();
        int num2 = num >> 3;
        if ((num & 7) != 0)
        {
            num2++;
        }
        if (numBytes < num2)
        {
            numBytes = num2;
        }
        byte[] buffer = new byte[numBytes];
        int index = 0;
        uint num5 = this.data[this.dataLength - 1];
        uint num4 = (num5 >> 0x18) & 0xff;
        if (num4 != 0)
        {
            buffer[index++] = (byte) num4;
        }
        num4 = (num5 >> 0x10) & 0xff;
        if (num4 != 0)
        {
            buffer[index++] = (byte) num4;
        }
        num4 = (num5 >> 8) & 0xff;
        if (num4 != 0)
        {
            buffer[index++] = (byte) num4;
        }
        num4 = num5 & 0xff;
        if (num4 != 0)
        {
            buffer[index++] = (byte) num4;
        }
        int num6 = this.dataLength - 2;
        while (num6 >= 0)
        {
            num5 = this.data[num6];
            buffer[index + 3] = (byte) (num5 & 0xff);
            num5 = num5 >> 8;
            buffer[index + 2] = (byte) (num5 & 0xff);
            num5 = num5 >> 8;
            buffer[index + 1] = (byte) (num5 & 0xff);
            num5 = num5 >> 8;
            buffer[index] = (byte) (num5 & 0xff);
            num6--;
            index += 4;
        }
        return buffer;
    }

    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }

    public int IntValue()
    {
        return (int) this.data[0];
    }

    public bool isProbablePrime()
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if (integer.dataLength == 1)
        {
            if ((integer.data[0] == 0) || (integer.data[0] == 1))
            {
                return false;
            }
            if ((integer.data[0] == 2) || (integer.data[0] == 3))
            {
                return true;
            }
        }
        if ((integer.data[0] & 1) == 0)
        {
            return false;
        }
        for (int i = 0; i < primesBelow2000.Length; i++)
        {
            BigInteger integer2 = primesBelow2000[i];
            if (integer2 >= integer)
            {
                break;
            }
            if (op_Modulus(integer, integer2).IntValue() == 0)
            {
                return false;
            }
        }
        BigInteger integer4 = integer - new BigInteger((long) 1);
        int shiftVal = 0;
        for (int j = 0; j < integer4.dataLength; j++)
        {
            uint num4 = 1;
            for (int m = 0; m < 0x20; m++)
            {
                if ((integer4.data[j] & num4) != 0)
                {
                    j = integer4.dataLength;
                    break;
                }
                num4 = num4 << 1;
                shiftVal++;
            }
        }
        BigInteger exp = op_RightShift(integer4, shiftVal);
        int num6 = integer.bitCount();
        BigInteger integer7 = 2.modPow(exp, integer);
        bool flag = false;
        if ((integer7.dataLength == 1) && (integer7.data[0] == 1))
        {
            flag = true;
        }
        for (int k = 0; !flag && (k < shiftVal); k++)
        {
            if (integer7 == integer4)
            {
                flag = true;
                break;
            }
            integer7 = op_Modulus(integer7 * integer7, integer);
        }
        if (flag)
        {
            flag = this.LucasStrongTestHelper(integer);
        }
        return flag;
    }

    public bool isProbablePrime(int confidence)
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        for (int i = 0; i < primesBelow2000.Length; i++)
        {
            BigInteger integer2 = primesBelow2000[i];
            if (integer2 >= integer)
            {
                break;
            }
            if (op_Modulus(integer, integer2).IntValue() == 0)
            {
                return false;
            }
        }
        return integer.RabinMillerTest(confidence);
    }

    public static int Jacobi(BigInteger a, BigInteger b)
    {
        if ((b.data[0] & 1) == 0)
        {
            throw new ArgumentException("Jacobi defined only for odd integers.");
        }
        if (a >= b)
        {
            a = op_Modulus(a, b);
        }
        if ((a.dataLength == 1) && (a.data[0] == 0))
        {
            return 0;
        }
        if ((a.dataLength == 1) && (a.data[0] == 1))
        {
            return 1;
        }
        if (a < 0)
        {
            if (((b - 1).data[0] & 2) == 0)
            {
                return Jacobi(op_UnaryNegation(a), b);
            }
            return -Jacobi(op_UnaryNegation(a), b);
        }
        int shiftVal = 0;
        for (int i = 0; i < a.dataLength; i++)
        {
            uint num3 = 1;
            for (int j = 0; j < 0x20; j++)
            {
                if ((a.data[i] & num3) != 0)
                {
                    i = a.dataLength;
                    break;
                }
                num3 = num3 << 1;
                shiftVal++;
            }
        }
        BigInteger integer = op_RightShift(a, shiftVal);
        int num5 = 1;
        if (((shiftVal & 1) != 0) && (((b.data[0] & 7) == 3) || ((b.data[0] & 7) == 5)))
        {
            num5 = -1;
        }
        if (((b.data[0] & 3) == 3) && ((integer.data[0] & 3) == 3))
        {
            num5 = -num5;
        }
        if ((integer.dataLength == 1) && (integer.data[0] == 1))
        {
            return num5;
        }
        return (num5 * Jacobi(op_Modulus(b, integer), integer));
    }

    public long LongValue()
    {
        long num = 0;
        num = this.data[0];
        try
        {
            num |= this.data[1] << 0x20;
        }
        catch (Exception)
        {
            if ((this.data[0] & 0x80000000) != 0)
            {
                num = this.data[0];
            }
        }
        return num;
    }

    public static BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k, BigInteger n)
    {
        if ((k.dataLength == 1) && (k.data[0] == 0))
        {
            return new BigInteger[] { 0, op_Modulus(2, n), op_Modulus(1, n) };
        }
        BigInteger constant = new BigInteger();
        int index = n.dataLength << 1;
        constant.data[index] = 1;
        constant.dataLength = index + 1;
        constant /= n;
        int shiftVal = 0;
        for (int i = 0; i < k.dataLength; i++)
        {
            uint num4 = 1;
            for (int j = 0; j < 0x20; j++)
            {
                if ((k.data[i] & num4) != 0)
                {
                    i = k.dataLength;
                    break;
                }
                num4 = num4 << 1;
                shiftVal++;
            }
        }
        BigInteger integer2 = op_RightShift(k, shiftVal);
        return LucasSequenceHelper(P, Q, integer2, n, constant, shiftVal);
    }

    private static BigInteger[] LucasSequenceHelper(BigInteger P, BigInteger Q, BigInteger k, BigInteger n, BigInteger constant, int s)
    {
        int num3;
        BigInteger[] integerArray = new BigInteger[3];
        if ((k.data[0] & 1) == 0)
        {
            throw new ArgumentException("Argument k must be odd.");
        }
        int num = k.bitCount();
        uint num2 = ((uint) 1) << ((num & 0x1f) - 1);
        BigInteger integer = op_Modulus(2, n);
        BigInteger integer2 = op_Modulus(1, n);
        BigInteger integer3 = op_Modulus(P, n);
        BigInteger integer4 = integer2;
        bool flag = true;
        for (num3 = k.dataLength - 1; num3 >= 0; num3--)
        {
            while (num2 != 0)
            {
                if ((num3 == 0) && (num2 == 1))
                {
                    break;
                }
                if ((k.data[num3] & num2) != 0)
                {
                    integer4 = op_Modulus(integer4 * integer3, n);
                    integer = op_Modulus((integer * integer3) - (P * integer2), n);
                    integer3 = op_Modulus(n.BarrettReduction(integer3 * integer3, n, constant) - op_LeftShift(integer2 * Q, 1), n);
                    if (flag)
                    {
                        flag = false;
                    }
                    else
                    {
                        integer2 = n.BarrettReduction(integer2 * integer2, n, constant);
                    }
                    integer2 = op_Modulus(integer2 * Q, n);
                }
                else
                {
                    integer4 = op_Modulus((integer4 * integer) - integer2, n);
                    integer3 = op_Modulus((integer * integer3) - (P * integer2), n);
                    integer = op_Modulus(n.BarrettReduction(integer * integer, n, constant) - op_LeftShift(integer2, 1), n);
                    if (flag)
                    {
                        integer2 = op_Modulus(Q, n);
                        flag = false;
                    }
                    else
                    {
                        integer2 = n.BarrettReduction(integer2 * integer2, n, constant);
                    }
                }
                num2 = num2 >> 1;
            }
            num2 = 0x80000000;
        }
        integer4 = op_Modulus((integer4 * integer) - integer2, n);
        integer = op_Modulus((integer * integer3) - (P * integer2), n);
        if (flag)
        {
            flag = false;
        }
        else
        {
            integer2 = n.BarrettReduction(integer2 * integer2, n, constant);
        }
        integer2 = op_Modulus(integer2 * Q, n);
        for (num3 = 0; num3 < s; num3++)
        {
            integer4 = op_Modulus(integer4 * integer, n);
            integer = op_Modulus((integer * integer) - op_LeftShift(integer2, 1), n);
            if (flag)
            {
                integer2 = op_Modulus(Q, n);
                flag = false;
            }
            else
            {
                integer2 = n.BarrettReduction(integer2 * integer2, n, constant);
            }
        }
        integerArray[0] = integer4;
        integerArray[1] = integer;
        integerArray[2] = integer2;
        return integerArray;
    }

    public bool LucasStrongTest()
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if (integer.dataLength == 1)
        {
            if ((integer.data[0] == 0) || (integer.data[0] == 1))
            {
                return false;
            }
            if ((integer.data[0] == 2) || (integer.data[0] == 3))
            {
                return true;
            }
        }
        if ((integer.data[0] & 1) == 0)
        {
            return false;
        }
        return this.LucasStrongTestHelper(integer);
    }

    private bool LucasStrongTestHelper(BigInteger thisVal)
    {
        int num9;
        long a = 5;
        long num2 = -1;
        long num3 = 0;
        bool flag = false;
        while (!flag)
        {
            int num4 = Jacobi(a, thisVal);
            if (num4 == -1)
            {
                flag = true;
            }
            else
            {
                if ((num4 == 0) && (Math.Abs(a) < thisVal))
                {
                    return false;
                }
                if (num3 == 20)
                {
                    BigInteger integer = thisVal.sqrt();
                    if ((integer * integer) == thisVal)
                    {
                        return false;
                    }
                }
                a = (Math.Abs(a) + 2) * num2;
                num2 = -num2;
            }
            num3++;
        }
        long q = (1 - a) >> 2;
        BigInteger integer2 = thisVal + 1;
        int shiftVal = 0;
        for (int i = 0; i < integer2.dataLength; i++)
        {
            uint num8 = 1;
            for (num9 = 0; num9 < 0x20; num9++)
            {
                if ((integer2.data[i] & num8) != 0)
                {
                    i = integer2.dataLength;
                    break;
                }
                num8 = num8 << 1;
                shiftVal++;
            }
        }
        BigInteger k = op_RightShift(integer2, shiftVal);
        BigInteger constant = new BigInteger();
        int index = thisVal.dataLength << 1;
        constant.data[index] = 1;
        constant.dataLength = index + 1;
        constant /= thisVal;
        BigInteger[] integerArray = LucasSequenceHelper(1, q, k, thisVal, constant, 0);
        bool flag2 = false;
        if (((integerArray[0].dataLength == 1) && (integerArray[0].data[0] == 0)) || ((integerArray[1].dataLength == 1) && (integerArray[1].data[0] == 0)))
        {
            flag2 = true;
        }
        for (num9 = 1; num9 < shiftVal; num9++)
        {
            if (!flag2)
            {
                integerArray[1] = thisVal.BarrettReduction(integerArray[1] * integerArray[1], thisVal, constant);
                integerArray[1] = op_Modulus(integerArray[1] - op_LeftShift(integerArray[2], 1), thisVal);
                if ((integerArray[1].dataLength == 1) && (integerArray[1].data[0] == 0))
                {
                    flag2 = true;
                }
            }
            integerArray[2] = thisVal.BarrettReduction(integerArray[2] * integerArray[2], thisVal, constant);
        }
        if (flag2)
        {
            BigInteger integer5 = thisVal.gcd(q);
            if ((integer5.dataLength == 1) && (integer5.data[0] == 1))
            {
                if ((integerArray[2].data[0x45] & 0x80000000) != 0)
                {
                    integerArray[2] += thisVal;
                }
                BigInteger integer6 = op_Modulus(q * Jacobi(q, thisVal), thisVal);
                if ((integer6.data[0x45] & 0x80000000) != 0)
                {
                    integer6 += thisVal;
                }
                if (integerArray[2] != integer6)
                {
                    flag2 = false;
                }
            }
        }
        return flag2;
    }

    public BigInteger max(BigInteger bi)
    {
        if (this > bi)
        {
            return new BigInteger(this);
        }
        return new BigInteger(bi);
    }

    public BigInteger min(BigInteger bi)
    {
        if (this < bi)
        {
            return new BigInteger(this);
        }
        return new BigInteger(bi);
    }

    public BigInteger modInverse(BigInteger modulus)
    {
        BigInteger[] integerArray = new BigInteger[] { 0, 1 };
        BigInteger[] integerArray2 = new BigInteger[2];
        BigInteger[] integerArray3 = new BigInteger[] { 0, 0 };
        int num = 0;
        BigInteger integer = modulus;
        BigInteger integer2 = this;
        while ((integer2.dataLength > 1) || ((integer2.dataLength == 1) && (integer2.data[0] != 0)))
        {
            BigInteger outQuotient = new BigInteger();
            BigInteger outRemainder = new BigInteger();
            if (num > 1)
            {
                BigInteger integer5 = op_Modulus(integerArray[0] - (integerArray[1] * integerArray2[0]), modulus);
                integerArray[0] = integerArray[1];
                integerArray[1] = integer5;
            }
            if (integer2.dataLength == 1)
            {
                singleByteDivide(integer, integer2, outQuotient, outRemainder);
            }
            else
            {
                multiByteDivide(integer, integer2, outQuotient, outRemainder);
            }
            integerArray2[0] = integerArray2[1];
            integerArray3[0] = integerArray3[1];
            integerArray2[1] = outQuotient;
            integerArray3[1] = outRemainder;
            integer = integer2;
            integer2 = outRemainder;
            num++;
        }
        if ((integerArray3[0].dataLength > 1) || ((integerArray3[0].dataLength == 1) && (integerArray3[0].data[0] != 1)))
        {
            throw new ArithmeticException("No inverse!");
        }
        BigInteger integer6 = op_Modulus(integerArray[0] - (integerArray[1] * integerArray2[0]), modulus);
        if ((integer6.data[0x45] & 0x80000000) != 0)
        {
            integer6 += modulus;
        }
        return integer6;
    }

    public BigInteger modPow(BigInteger exp, BigInteger n)
    {
        BigInteger integer2;
        if ((exp.data[0x45] & 0x80000000) != 0)
        {
            throw new ArithmeticException("Positive exponents only.");
        }
        BigInteger integer = 1;
        bool flag = false;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer2 = op_Modulus(op_UnaryNegation(this), n);
            flag = true;
        }
        else
        {
            integer2 = op_Modulus(this, n);
        }
        if ((n.data[0x45] & 0x80000000) != 0)
        {
            n = op_UnaryNegation(n);
        }
        BigInteger constant = new BigInteger();
        int index = n.dataLength << 1;
        constant.data[index] = 1;
        constant.dataLength = index + 1;
        constant /= n;
        int num2 = exp.bitCount();
        int num3 = 0;
        for (int i = 0; i < exp.dataLength; i++)
        {
            uint num5 = 1;
            for (int j = 0; j < 0x20; j++)
            {
                if ((exp.data[i] & num5) != 0)
                {
                    integer = this.BarrettReduction(integer * integer2, n, constant);
                }
                num5 = num5 << 1;
                integer2 = this.BarrettReduction(integer2 * integer2, n, constant);
                if ((integer2.dataLength == 1) && (integer2.data[0] == 1))
                {
                    if (flag && ((exp.data[0] & 1) != 0))
                    {
                        return op_UnaryNegation(integer);
                    }
                    return integer;
                }
                num3++;
                if (num3 == num2)
                {
                    break;
                }
            }
        }
        if (flag && ((exp.data[0] & 1) != 0))
        {
            return op_UnaryNegation(integer);
        }
        return integer;
    }

    private static void multiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
    {
        uint[] numArray = new uint[70];
        int num = bi1.dataLength + 1;
        uint[] buffer = new uint[num];
        uint num2 = 0x80000000;
        uint num3 = bi2.data[bi2.dataLength - 1];
        int shiftVal = 0;
        int num5 = 0;
        while ((num2 != 0) && ((num3 & num2) == 0))
        {
            shiftVal++;
            num2 = num2 >> 1;
        }
        for (int i = 0; i < bi1.dataLength; i++)
        {
            buffer[i] = bi1.data[i];
        }
        shiftLeft(buffer, shiftVal);
        bi2 = op_LeftShift(bi2, shiftVal);
        int num7 = num - bi2.dataLength;
        int index = num - 1;
        ulong num9 = bi2.data[bi2.dataLength - 1];
        ulong num10 = bi2.data[bi2.dataLength - 2];
        int num11 = bi2.dataLength + 1;
        uint[] inData = new uint[num11];
        while (num7 > 0)
        {
            int num15;
            ulong num12 = (buffer[index] << 0x20) + buffer[index - 1];
            ulong num13 = num12 / num9;
            ulong num14 = num12 % num9;
            bool flag = false;
            while (!flag)
            {
                flag = true;
                if ((num13 == 0x100000000) || ((num13 * num10) > ((num14 << 0x20) + buffer[index - 2])))
                {
                    num13--;
                    num14 += num9;
                    if (num14 < 0x100000000)
                    {
                        flag = false;
                    }
                }
            }
            for (num15 = 0; num15 < num11; num15++)
            {
                inData[num15] = buffer[index - num15];
            }
            BigInteger integer = new BigInteger(inData);
            BigInteger integer2 = bi2 * num13;
            while (integer2 > integer)
            {
                num13--;
                integer2 -= bi2;
            }
            BigInteger integer3 = integer - integer2;
            for (num15 = 0; num15 < num11; num15++)
            {
                buffer[index - num15] = integer3.data[bi2.dataLength - num15];
            }
            numArray[num5++] = (uint) num13;
            index--;
            num7--;
        }
        outQuotient.dataLength = num5;
        int num16 = 0;
        int num17 = outQuotient.dataLength - 1;
        while (num17 >= 0)
        {
            outQuotient.data[num16] = numArray[num17];
            num17--;
            num16++;
        }
        while (num16 < 70)
        {
            outQuotient.data[num16] = 0;
            num16++;
        }
        while ((outQuotient.dataLength > 1) && (outQuotient.data[outQuotient.dataLength - 1] == 0))
        {
            outQuotient.dataLength--;
        }
        if (outQuotient.dataLength == 0)
        {
            outQuotient.dataLength = 1;
        }
        outRemainder.dataLength = shiftRight(buffer, shiftVal);
        num16 = 0;
        while (num16 < outRemainder.dataLength)
        {
            outRemainder.data[num16] = buffer[num16];
            num16++;
        }
        while (num16 < 70)
        {
            outRemainder.data[num16] = 0;
            num16++;
        }
    }

    public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
    {
        BigInteger integer = new BigInteger();
        integer.dataLength = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
        long num = 0;
        for (int i = 0; i < integer.dataLength; i++)
        {
            long num3 = (bi1.data[i] + bi2.data[i]) + num;
            num = num3 >> 0x20;
            integer.data[i] = (uint) (((ulong) num3) & 0xffffffff);
        }
        if ((num != 0) && (integer.dataLength < 70))
        {
            integer.data[integer.dataLength] = (uint) num;
            integer.dataLength++;
        }
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        int index = 0x45;
        if (((bi1.data[index] & 0x80000000) == (bi2.data[index] & 0x80000000)) && ((integer.data[index] & 0x80000000) != (bi1.data[index] & 0x80000000)))
        {
            throw new ArithmeticException();
        }
        return integer;
    }

    public static BigInteger operator &(BigInteger bi1, BigInteger bi2)
    {
        BigInteger integer = new BigInteger();
        int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
        for (int i = 0; i < num; i++)
        {
            integer.data[i] = bi1.data[i] & bi2.data[i];
        }
        integer.dataLength = 70;
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        return integer;
    }

    public static BigInteger operator |(BigInteger bi1, BigInteger bi2)
    {
        BigInteger integer = new BigInteger();
        int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
        for (int i = 0; i < num; i++)
        {
            integer.data[i] = bi1.data[i] | bi2.data[i];
        }
        integer.dataLength = 70;
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        return integer;
    }

    public static BigInteger operator --(BigInteger bi1)
    {
        BigInteger integer = new BigInteger(bi1);
        bool flag = true;
        int index = 0;
        while (flag && (index < 70))
        {
            long num = integer.data[index];
            num--;
            integer.data[index] = (uint) (((ulong) num) & 0xffffffff);
            if (num >= 0)
            {
                flag = false;
            }
            index++;
        }
        if (index > integer.dataLength)
        {
            integer.dataLength = index;
        }
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        int num3 = 0x45;
        if (((bi1.data[num3] & 0x80000000) != 0) && ((integer.data[num3] & 0x80000000) != (bi1.data[num3] & 0x80000000)))
        {
            throw new ArithmeticException("Underflow in --.");
        }
        return integer;
    }

    public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
    {
        BigInteger outQuotient = new BigInteger();
        BigInteger outRemainder = new BigInteger();
        int index = 0x45;
        bool flag = false;
        bool flag2 = false;
        if ((bi1.data[index] & 0x80000000) != 0)
        {
            bi1 = op_UnaryNegation(bi1);
            flag2 = true;
        }
        if ((bi2.data[index] & 0x80000000) != 0)
        {
            bi2 = op_UnaryNegation(bi2);
            flag = true;
        }
        if (bi1 >= bi2)
        {
            if (bi2.dataLength == 1)
            {
                singleByteDivide(bi1, bi2, outQuotient, outRemainder);
            }
            else
            {
                multiByteDivide(bi1, bi2, outQuotient, outRemainder);
            }
            if (flag2 != flag)
            {
                return op_UnaryNegation(outQuotient);
            }
        }
        return outQuotient;
    }

    public static bool operator ==(BigInteger bi1, BigInteger bi2)
    {
        return bi1.Equals(bi2);
    }

    public static BigInteger operator ^(BigInteger bi1, BigInteger bi2)
    {
        BigInteger integer = new BigInteger();
        int num = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
        for (int i = 0; i < num; i++)
        {
            integer.data[i] = bi1.data[i] ^ bi2.data[i];
        }
        integer.dataLength = 70;
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        return integer;
    }

    public static bool operator >(BigInteger bi1, BigInteger bi2)
    {
        int index = 0x45;
        if (((bi1.data[index] & 0x80000000) == 0) || ((bi2.data[index] & 0x80000000) != 0))
        {
            if (((bi1.data[index] & 0x80000000) == 0) && ((bi2.data[index] & 0x80000000) != 0))
            {
                return true;
            }
            int num2 = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
            index = num2 - 1;
            while ((index >= 0) && (bi1.data[index] == bi2.data[index]))
            {
                index--;
            }
            if (index >= 0)
            {
                return (bi1.data[index] > bi2.data[index]);
            }
        }
        return false;
    }

    public static bool operator >=(BigInteger bi1, BigInteger bi2)
    {
        return ((bi1 == bi2) || (bi1 > bi2));
    }

    public static implicit operator BigInteger(int value)
    {
        return new BigInteger((long) value);
    }

    public static implicit operator BigInteger(long value)
    {
        return new BigInteger(value);
    }

    public static implicit operator BigInteger(uint value)
    {
        return new BigInteger((ulong) value);
    }

    public static implicit operator BigInteger(ulong value)
    {
        return new BigInteger(value);
    }

    public static BigInteger operator ++(BigInteger bi1)
    {
        BigInteger integer = new BigInteger(bi1);
        long num2 = 1;
        int index = 0;
        while ((num2 != 0) && (index < 70))
        {
            long num = integer.data[index];
            num++;
            integer.data[index] = (uint) (((ulong) num) & 0xffffffff);
            num2 = num >> 0x20;
            index++;
        }
        if (index > integer.dataLength)
        {
            integer.dataLength = index;
        }
        else
        {
            while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
            {
                integer.dataLength--;
            }
        }
        int num4 = 0x45;
        if (((bi1.data[num4] & 0x80000000) == 0) && ((integer.data[num4] & 0x80000000) != (bi1.data[num4] & 0x80000000)))
        {
            throw new ArithmeticException("Overflow in ++.");
        }
        return integer;
    }

    public static bool operator !=(BigInteger bi1, BigInteger bi2)
    {
        return !bi1.Equals(bi2);
    }

    public static BigInteger operator <<(BigInteger bi1, int shiftVal)
    {
        BigInteger integer = new BigInteger(bi1);
        integer.dataLength = shiftLeft(integer.data, shiftVal);
        return integer;
    }

    public static bool operator <(BigInteger bi1, BigInteger bi2)
    {
        int index = 0x45;
        if (((bi1.data[index] & 0x80000000) != 0) && ((bi2.data[index] & 0x80000000) == 0))
        {
            return true;
        }
        if (((bi1.data[index] & 0x80000000) != 0) || ((bi2.data[index] & 0x80000000) == 0))
        {
            int num2 = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
            index = num2 - 1;
            while ((index >= 0) && (bi1.data[index] == bi2.data[index]))
            {
                index--;
            }
            if (index >= 0)
            {
                return (bi1.data[index] < bi2.data[index]);
            }
        }
        return false;
    }

    public static bool operator <=(BigInteger bi1, BigInteger bi2)
    {
        return ((bi1 == bi2) || (bi1 < bi2));
    }

    public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
    {
        BigInteger outQuotient = new BigInteger();
        BigInteger outRemainder = new BigInteger(bi1);
        int index = 0x45;
        bool flag = false;
        if ((bi1.data[index] & 0x80000000) != 0)
        {
            bi1 = op_UnaryNegation(bi1);
            flag = true;
        }
        if ((bi2.data[index] & 0x80000000) != 0)
        {
            bi2 = op_UnaryNegation(bi2);
        }
        if (bi1 >= bi2)
        {
            if (bi2.dataLength == 1)
            {
                singleByteDivide(bi1, bi2, outQuotient, outRemainder);
            }
            else
            {
                multiByteDivide(bi1, bi2, outQuotient, outRemainder);
            }
            if (flag)
            {
                return op_UnaryNegation(outRemainder);
            }
        }
        return outRemainder;
    }

    public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
    {
        int num2;
        int index = 0x45;
        bool flag = false;
        bool flag2 = false;
        try
        {
            if ((bi1.data[index] & 0x80000000) != 0)
            {
                flag = true;
                bi1 = op_UnaryNegation(bi1);
            }
            if ((bi2.data[index] & 0x80000000) != 0)
            {
                flag2 = true;
                bi2 = op_UnaryNegation(bi2);
            }
        }
        catch (Exception)
        {
        }
        BigInteger integer = new BigInteger();
        try
        {
            for (num2 = 0; num2 < bi1.dataLength; num2++)
            {
                if (bi1.data[num2] != 0)
                {
                    ulong num3 = (ulong) 0;
                    int num4 = 0;
                    for (int i = num2; num4 < bi2.dataLength; i++)
                    {
                        ulong num6 = ((bi1.data[num2] * bi2.data[num4]) + integer.data[i]) + num3;
                        integer.data[i] = (uint) (num6 & 0xffffffff);
                        num3 = num6 >> 0x20;
                        num4++;
                    }
                    if (num3 != 0)
                    {
                        integer.data[num2 + bi2.dataLength] = (uint) num3;
                    }
                }
            }
        }
        catch (Exception)
        {
            throw new ArithmeticException("Multiplication overflow.");
        }
        integer.dataLength = bi1.dataLength + bi2.dataLength;
        if (integer.dataLength > 70)
        {
            integer.dataLength = 70;
        }
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        if ((integer.data[index] & 0x80000000) != 0)
        {
            if ((flag != flag2) && (integer.data[index] == 0x80000000))
            {
                if (integer.dataLength == 1)
                {
                    return integer;
                }
                bool flag3 = true;
                for (num2 = 0; (num2 < (integer.dataLength - 1)) && flag3; num2++)
                {
                    if (integer.data[num2] != 0)
                    {
                        flag3 = false;
                    }
                }
                if (flag3)
                {
                    return integer;
                }
            }
            throw new ArithmeticException("Multiplication overflow.");
        }
        if (flag != flag2)
        {
            return op_UnaryNegation(integer);
        }
        return integer;
    }

    public static BigInteger operator ~(BigInteger bi1)
    {
        BigInteger integer = new BigInteger(bi1);
        for (int i = 0; i < 70; i++)
        {
            integer.data[i] = ~bi1.data[i];
        }
        integer.dataLength = 70;
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        return integer;
    }

    public static BigInteger operator >>(BigInteger bi1, int shiftVal)
    {
        BigInteger integer = new BigInteger(bi1);
        integer.dataLength = shiftRight(integer.data, shiftVal);
        if ((bi1.data[0x45] & 0x80000000) != 0)
        {
            int num;
            for (num = 0x45; num >= integer.dataLength; num--)
            {
                integer.data[num] = uint.MaxValue;
            }
            uint num2 = 0x80000000;
            for (num = 0; num < 0x20; num++)
            {
                if ((integer.data[integer.dataLength - 1] & num2) != 0)
                {
                    break;
                }
                integer.data[integer.dataLength - 1] |= num2;
                num2 = num2 >> 1;
            }
            integer.dataLength = 70;
        }
        return integer;
    }

    public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
    {
        int num2;
        BigInteger integer = new BigInteger();
        integer.dataLength = (bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength;
        long num = 0;
        for (num2 = 0; num2 < integer.dataLength; num2++)
        {
            long num3 = (bi1.data[num2] - bi2.data[num2]) - num;
            integer.data[num2] = (uint) (((ulong) num3) & 0xffffffff);
            if (num3 < 0)
            {
                num = 1;
            }
            else
            {
                num = 0;
            }
        }
        if (num != 0)
        {
            for (num2 = integer.dataLength; num2 < 70; num2++)
            {
                integer.data[num2] = uint.MaxValue;
            }
            integer.dataLength = 70;
        }
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        int index = 0x45;
        if (((bi1.data[index] & 0x80000000) != (bi2.data[index] & 0x80000000)) && ((integer.data[index] & 0x80000000) != (bi1.data[index] & 0x80000000)))
        {
            throw new ArithmeticException();
        }
        return integer;
    }

    public static BigInteger operator -(BigInteger bi1)
    {
        if ((bi1.dataLength == 1) && (bi1.data[0] == 0))
        {
            return new BigInteger();
        }
        BigInteger integer = new BigInteger(bi1);
        for (int i = 0; i < 70; i++)
        {
            integer.data[i] = ~bi1.data[i];
        }
        long num3 = 1;
        for (int j = 0; (num3 != 0) && (j < 70); j++)
        {
            long num2 = integer.data[j];
            num2++;
            integer.data[j] = (uint) (((ulong) num2) & 0xffffffff);
            num3 = num2 >> 0x20;
        }
        if ((bi1.data[0x45] & 0x80000000) == (integer.data[0x45] & 0x80000000))
        {
            throw new ArithmeticException("Overflow in negation.\n");
        }
        integer.dataLength = 70;
        while ((integer.dataLength > 1) && (integer.data[integer.dataLength - 1] == 0))
        {
            integer.dataLength--;
        }
        return integer;
    }

    public bool RabinMillerTest(int confidence)
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if (integer.dataLength == 1)
        {
            if ((integer.data[0] == 0) || (integer.data[0] == 1))
            {
                return false;
            }
            if ((integer.data[0] == 2) || (integer.data[0] == 3))
            {
                return true;
            }
        }
        if ((integer.data[0] & 1) == 0)
        {
            return false;
        }
        BigInteger integer2 = integer - new BigInteger((long) 1);
        int shiftVal = 0;
        for (int i = 0; i < integer2.dataLength; i++)
        {
            uint num3 = 1;
            for (int k = 0; k < 0x20; k++)
            {
                if ((integer2.data[i] & num3) != 0)
                {
                    i = integer2.dataLength;
                    break;
                }
                num3 = num3 << 1;
                shiftVal++;
            }
        }
        BigInteger exp = op_RightShift(integer2, shiftVal);
        int num5 = integer.bitCount();
        BigInteger integer4 = new BigInteger();
        Random rand = new Random();
        for (int j = 0; j < confidence; j++)
        {
            bool flag = false;
            while (!flag)
            {
                int bits = 0;
                while (bits < 2)
                {
                    bits = (int) (rand.NextDouble() * num5);
                }
                integer4.genRandomBits(bits, rand);
                int dataLength = integer4.dataLength;
                if ((dataLength > 1) || ((dataLength == 1) && (integer4.data[0] != 1)))
                {
                    flag = true;
                }
            }
            BigInteger integer5 = integer4.gcd(integer);
            if ((integer5.dataLength == 1) && (integer5.data[0] != 1))
            {
                return false;
            }
            BigInteger integer6 = integer4.modPow(exp, integer);
            bool flag2 = false;
            if ((integer6.dataLength == 1) && (integer6.data[0] == 1))
            {
                flag2 = true;
            }
            for (int m = 0; !flag2 && (m < shiftVal); m++)
            {
                if (integer6 == integer2)
                {
                    flag2 = true;
                    break;
                }
                integer6 = op_Modulus(integer6 * integer6, integer);
            }
            if (!flag2)
            {
                return false;
            }
        }
        return true;
    }

    public void setBit(uint bitNum)
    {
        uint index = bitNum >> 5;
        byte num2 = (byte) (bitNum & 0x1f);
        uint num3 = ((uint) 1) << num2;
        this.data[index] |= num3;
        if (index >= this.dataLength)
        {
            this.dataLength = ((int) index) + 1;
        }
    }

    private static int shiftLeft(uint[] buffer, int shiftVal)
    {
        int num = 0x20;
        int length = buffer.Length;
        while ((length > 1) && (buffer[length - 1] == 0))
        {
            length--;
        }
        for (int i = shiftVal; i > 0; i -= num)
        {
            if (i < num)
            {
                num = i;
            }
            ulong num4 = (ulong) 0;
            for (int j = 0; j < length; j++)
            {
                ulong num6 = buffer[j] << num;
                num6 |= num4;
                buffer[j] = (uint) (num6 & 0xffffffff);
                num4 = num6 >> 0x20;
            }
            if ((num4 != 0) && ((length + 1) <= buffer.Length))
            {
                buffer[length] = (uint) num4;
                length++;
            }
        }
        return length;
    }

    private static int shiftRight(uint[] buffer, int shiftVal)
    {
        int num = 0x20;
        int num2 = 0;
        int length = buffer.Length;
        while ((length > 1) && (buffer[length - 1] == 0))
        {
            length--;
        }
        for (int i = shiftVal; i > 0; i -= num)
        {
            if (i < num)
            {
                num = i;
                num2 = 0x20 - num;
            }
            ulong num5 = (ulong) 0;
            for (int j = length - 1; j >= 0; j--)
            {
                ulong num7 = buffer[j] >> num;
                num7 |= num5;
                num5 = buffer[j] << num2;
                buffer[j] = (uint) num7;
            }
        }
        while ((length > 1) && (buffer[length - 1] == 0))
        {
            length--;
        }
        return length;
    }

    private static void singleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
    {
        int num2;
        ulong num6;
        uint[] numArray = new uint[70];
        int num = 0;
        for (num2 = 0; num2 < 70; num2++)
        {
            outRemainder.data[num2] = bi1.data[num2];
        }
        outRemainder.dataLength = bi1.dataLength;
        while ((outRemainder.dataLength > 1) && (outRemainder.data[outRemainder.dataLength - 1] == 0))
        {
            outRemainder.dataLength--;
        }
        ulong num3 = bi2.data[0];
        int index = outRemainder.dataLength - 1;
        ulong num5 = outRemainder.data[index];
        if (num5 >= num3)
        {
            num6 = num5 / num3;
            numArray[num++] = (uint) num6;
            outRemainder.data[index] = (uint) (num5 % num3);
        }
        index--;
        while (index >= 0)
        {
            num5 = (outRemainder.data[index + 1] << 0x20) + outRemainder.data[index];
            num6 = num5 / num3;
            numArray[num++] = (uint) num6;
            outRemainder.data[index + 1] = 0;
            outRemainder.data[index--] = (uint) (num5 % num3);
        }
        outQuotient.dataLength = num;
        int num7 = 0;
        num2 = outQuotient.dataLength - 1;
        while (num2 >= 0)
        {
            outQuotient.data[num7] = numArray[num2];
            num2--;
            num7++;
        }
        while (num7 < 70)
        {
            outQuotient.data[num7] = 0;
            num7++;
        }
        while ((outQuotient.dataLength > 1) && (outQuotient.data[outQuotient.dataLength - 1] == 0))
        {
            outQuotient.dataLength--;
        }
        if (outQuotient.dataLength == 0)
        {
            outQuotient.dataLength = 1;
        }
        while ((outRemainder.dataLength > 1) && (outRemainder.data[outRemainder.dataLength - 1] == 0))
        {
            outRemainder.dataLength--;
        }
    }

    public bool SolovayStrassenTest(int confidence)
    {
        BigInteger integer;
        if ((this.data[0x45] & 0x80000000) != 0)
        {
            integer = op_UnaryNegation(this);
        }
        else
        {
            integer = this;
        }
        if (integer.dataLength == 1)
        {
            if ((integer.data[0] == 0) || (integer.data[0] == 1))
            {
                return false;
            }
            if ((integer.data[0] == 2) || (integer.data[0] == 3))
            {
                return true;
            }
        }
        if ((integer.data[0] & 1) == 0)
        {
            return false;
        }
        int num = integer.bitCount();
        BigInteger a = new BigInteger();
        BigInteger integer3 = integer - 1;
        BigInteger exp = op_RightShift(integer3, 1);
        Random rand = new Random();
        for (int i = 0; i < confidence; i++)
        {
            bool flag = false;
            while (!flag)
            {
                int bits = 0;
                while (bits < 2)
                {
                    bits = (int) (rand.NextDouble() * num);
                }
                a.genRandomBits(bits, rand);
                int dataLength = a.dataLength;
                if ((dataLength > 1) || ((dataLength == 1) && (a.data[0] != 1)))
                {
                    flag = true;
                }
            }
            BigInteger integer5 = a.gcd(integer);
            if ((integer5.dataLength == 1) && (integer5.data[0] != 1))
            {
                return false;
            }
            BigInteger integer6 = a.modPow(exp, integer);
            if (integer6 == integer3)
            {
                integer6 = -1;
            }
            BigInteger integer7 = Jacobi(a, integer);
            if (integer6 != integer7)
            {
                return false;
            }
        }
        return true;
    }

    public BigInteger sqrt()
    {
        uint num4;
        uint num = (uint) this.bitCount();
        if ((num & 1) != 0)
        {
            num = (num >> 1) + 1;
        }
        else
        {
            num = num >> 1;
        }
        uint num2 = num >> 5;
        byte num3 = (byte) (num & 0x1f);
        BigInteger integer = new BigInteger();
        if (num3 == 0)
        {
            num4 = 0x80000000;
        }
        else
        {
            num4 = ((uint) 1) << num3;
            num2++;
        }
        integer.dataLength = (int) num2;
        for (int i = ((int) num2) - 1; i >= 0; i--)
        {
            while (num4 != 0)
            {
                integer.data[i] ^= num4;
                if ((integer * integer) > this)
                {
                    integer.data[i] ^= num4;
                }
                num4 = num4 >> 1;
            }
            num4 = 0x80000000;
        }
        return integer;
    }

    public string ToHexString()
    {
        string str = this.data[this.dataLength - 1].ToString("X");
        for (int i = this.dataLength - 2; i >= 0; i--)
        {
            str = str + this.data[i].ToString("X8");
        }
        return str;
    }

    public override string ToString()
    {
        return this.ToString(10);
    }

    public string ToString(int radix)
    {
        if ((radix < 2) || (radix > 0x24))
        {
            throw new ArgumentException("Radix must be >= 2 and <= 36");
        }
        string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string str2 = "";
        BigInteger integer = this;
        bool flag = false;
        if ((integer.data[0x45] & 0x80000000) != 0)
        {
            flag = true;
            try
            {
                integer = op_UnaryNegation(integer);
            }
            catch (Exception)
            {
            }
        }
        BigInteger outQuotient = new BigInteger();
        BigInteger outRemainder = new BigInteger();
        BigInteger integer4 = new BigInteger((long) radix);
        if ((integer.dataLength == 1) && (integer.data[0] == 0))
        {
            return "0";
        }
        while ((integer.dataLength > 1) || ((integer.dataLength == 1) && (integer.data[0] != 0)))
        {
            singleByteDivide(integer, integer4, outQuotient, outRemainder);
            if (outRemainder.data[0] < 10)
            {
                str2 = outRemainder.data[0] + str2;
            }
            else
            {
                str2 = str[((int) outRemainder.data[0]) - 10] + str2;
            }
            integer = outQuotient;
        }
        if (flag)
        {
            str2 = "-" + str2;
        }
        return str2;
    }

    public void unsetBit(uint bitNum)
    {
        uint index = bitNum >> 5;
        if (index < this.dataLength)
        {
            byte num2 = (byte) (bitNum & 0x1f);
            uint num3 = ((uint) 1) << num2;
            uint num4 = uint.MaxValue ^ num3;
            this.data[index] &= num4;
            if ((this.dataLength > 1) && (this.data[this.dataLength - 1] == 0))
            {
                this.dataLength--;
            }
        }
    }
}

