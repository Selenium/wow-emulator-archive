namespace Server
{
    using System;
    using System.Collections;

    public class TypeTable
    {
        // Methods
        public TypeTable(int capacity)
        {
            this.m_Sensitive = new Hashtable(capacity);
            this.m_Insensitive = new Hashtable(capacity, CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
        }

        public void Add(string key, Type type)
        {
            this.m_Sensitive[key] = type;
            this.m_Insensitive[key] = type;
        }

        public Type Get(string key, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return ((Type) this.m_Insensitive[key]);
            }
            return ((Type) this.m_Sensitive[key]);
        }


        // Fields
        private Hashtable m_Insensitive;
        private Hashtable m_Sensitive;
    }
}

