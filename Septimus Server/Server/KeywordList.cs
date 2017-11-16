namespace Server
{
    using System;

    public class KeywordList
    {
        // Methods
        static KeywordList()
        {
            KeywordList.m_EmptyInts = new int[0];
        }

        public KeywordList()
        {
            this.m_Keywords = new int[8];
            this.m_Count = 0;
        }

        public void Add(int keyword)
        {
            int[] numArray1;
            int num1;
            if ((this.m_Count + 1) > this.m_Keywords.Length)
            {
                numArray1 = this.m_Keywords;
                this.m_Keywords = new int[(numArray1.Length * 2)];
                for (num1 = 0; (num1 < numArray1.Length); ++num1)
                {
                    this.m_Keywords[num1] = numArray1[num1];
                }
            }
            this.m_Keywords[this.m_Count++] = keyword;
        }

        public bool Contains(int keyword)
        {
            int num1;
            bool flag1 = false;
            for (num1 = 0; (!flag1 && (num1 < this.m_Count)); ++num1)
            {
                flag1 = (keyword == this.m_Keywords[num1]);
            }
            return flag1;
        }

        public int[] ToArray()
        {
            int num1;
            if (this.m_Count == 0)
            {
                return KeywordList.m_EmptyInts;
            }
            int[] numArray1 = new int[this.m_Count];
            for (num1 = 0; (num1 < this.m_Count); ++num1)
            {
                numArray1[num1] = this.m_Keywords[num1];
            }
            this.m_Count = 0;
            return numArray1;
        }


        // Properties
        public int Count
        {
            get
            {
                return this.m_Count;
            }
        }


        // Fields
        private int m_Count;
        private static int[] m_EmptyInts;
        private int[] m_Keywords;
    }
}

