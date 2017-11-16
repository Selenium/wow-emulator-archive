namespace AuthServer
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    internal class Account
    {
        private byte[] b = new byte[20];
        private BigInteger B;
        private BigInteger G;
        public byte[] Hash;
        private BigInteger K;
        private static byte[] N = new byte[] { 
            0x89, 0x4b, 100, 0x5e, 0x89, 0xe1, 0x53, 0x5b, 0xbd, 0xad, 0x5b, 0x8b, 0x29, 6, 80, 0x53, 
            8, 1, 0xb1, 0x8e, 0xbf, 0xbf, 0x5e, 0x8f, 0xab, 60, 130, 0x87, 0x2a, 0x3e, 0x9b, 0xb7
         };
        public string Name;
        private ByteArrayBuilderV2 pack = new ByteArrayBuilderV2();
        public string Password;
        public static Random rand = new Random();
        private byte[] rb;
        private static byte[] rN = AuthServer.Utils.Reverse(N);
        private byte[] salt = new byte[0x20];
        private byte[] usernameUP;
        private BigInteger v;

        public byte[] ServerChallange(AuthOpCode op)
        {
            byte[] bytes = Encoding.ASCII.GetBytes((this.Name + ":" + this.Password).ToUpper().ToCharArray());
            this.usernameUP = Encoding.ASCII.GetBytes(this.Name.ToUpper().ToCharArray());
            this.G = new BigInteger(new byte[] { 7 });
            byte[] buffer2 = new byte[] { 1 };
            this.salt = new byte[0x20];
            this.b = new byte[20];
            rand.NextBytes(this.salt);
            rand.NextBytes(this.b);
            byte[] bs = new SHA1CryptoServiceProvider().ComputeHash(bytes, 0, bytes.Length);
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            rv.Add(this.salt);
            rv.Add(bs);
            SHA1 sha2 = new SHA1CryptoServiceProvider();
            BigInteger exp = new BigInteger(AuthServer.Utils.Reverse(sha2.ComputeHash((byte[]) rv, 0, rv.Length)));
            BigInteger n = new BigInteger(rN);
            this.v = this.G.modPow(exp, n);
            this.rb = AuthServer.Utils.Reverse(this.b);
            this.K = new BigInteger(new byte[] { 3 });
            BigInteger integer3 = this.K * this.v;
            BigInteger integer4 = this.G.modPow(new BigInteger(this.rb), new BigInteger(rN));
            BigInteger integer5 = integer3 + integer4;
            this.B = BigInteger.op_Modulus(integer5, new BigInteger(rN));
            this.pack.Clear();
            this.pack.Add((byte) op);
            this.pack.Add((byte) 0);
            this.pack.Add((byte) 0);
            this.pack.Add(AuthServer.Utils.Reverse(this.B.getBytes(0x20)));
            this.pack.Add(new byte[] { 1, 7, 0x20 });
            this.pack.Add(N);
            this.pack.Add(this.salt);
            this.pack.Add(new byte[0x10]);
            this.pack.Add((byte) 0);
            return (byte[]) this.pack;
        }

        public byte[] ServerProof(ByteArrayBuilderV2 data)
        {
            int num;
            this.pack.Clear();
            byte[] array = data.GetArray(1, 0x20);
            byte[] buffer2 = data.GetArray(0x21, 20);
            byte[] buffer = AuthServer.Utils.Concat(array, AuthServer.Utils.Reverse(this.B.getBytes(0x20)));
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] inData = AuthServer.Utils.Reverse(sha.ComputeHash(buffer));
            byte[] buffer6 = AuthServer.Utils.Reverse(array);
            BigInteger integer2 = this.v.modPow(new BigInteger(inData), new BigInteger(rN)) * new BigInteger(buffer6);
            byte[] buffer8 = AuthServer.Utils.Reverse(integer2.modPow(new BigInteger(this.rb), new BigInteger(rN)).getBytes(0x20));
            byte[] buffer9 = new byte[0x10];
            byte[] buffer10 = new byte[0x10];
            for (num = 0; num < 0x10; num++)
            {
                buffer9[num] = buffer8[num * 2];
                buffer10[num] = buffer8[(num * 2) + 1];
            }
            byte[] buffer11 = sha.ComputeHash(buffer9);
            byte[] buffer12 = sha.ComputeHash(buffer10);
            byte[] b = new byte[buffer11.Length + buffer12.Length];
            for (num = 0; num < buffer11.Length; num++)
            {
                b[num * 2] = buffer11[num];
                b[(num * 2) + 1] = buffer12[num];
            }
            byte[] buffer14 = sha.ComputeHash(N);
            byte[] buffer15 = sha.ComputeHash(this.G.getBytes());
            byte[] buffer16 = sha.ComputeHash(this.usernameUP);
            byte[] a = new byte[20];
            for (num = 0; num < 20; num++)
            {
                a[num] = (byte) (buffer14[num] ^ buffer15[num]);
            }
            byte[] buffer18 = AuthServer.Utils.Concat(AuthServer.Utils.Concat(AuthServer.Utils.Concat(AuthServer.Utils.Concat(AuthServer.Utils.Concat(a, buffer16), this.salt), array), AuthServer.Utils.Reverse(this.B.getBytes(0x20))), b);
            byte[] buffer19 = sha.ComputeHash(buffer18);
            if (!AuthServer.Utils.IsSameByteArray(buffer19, buffer2))
            {
                this.pack.Add((byte) 1);
                this.pack.Add((byte) 4);
                this.pack.Add(new byte[6]);
                return (byte[]) this.pack;
            }
            this.Hash = b;
            buffer18 = AuthServer.Utils.Concat(AuthServer.Utils.Concat(array, buffer19), b);
            byte[] bs = sha.ComputeHash(buffer18);
            this.pack.Add((byte) 1);
            this.pack.Add((byte) 0);
            this.pack.Add(bs);
            this.pack.Add(new byte[6]);
            return (byte[]) this.pack;
        }
    }
}

