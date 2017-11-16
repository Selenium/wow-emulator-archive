namespace Server
{
    using System;
    using System.Reflection;

    public class TypeCache
    {
        // Methods
        public TypeCache(Assembly asm)
        {
            int num1;
            Type type2;
            object[] objArray1;
            TypeAliasAttribute attribute1;
            int num2;
            if (asm == null)
            {
                this.m_Types = Type.EmptyTypes;
            }
            else
            {
                this.m_Types = asm.GetTypes();
            }
            this.m_Names = new TypeTable(this.m_Types.Length);
            this.m_FullNames = new TypeTable(this.m_Types.Length);
            Type type1 = typeof(TypeAliasAttribute);
            for (num1 = 0; (num1 < this.m_Types.Length); ++num1)
            {
                type2 = this.m_Types[num1];
                this.m_Names.Add(type2.Name, type2);
                this.m_FullNames.Add(type2.FullName, type2);
                if (type2.IsDefined(type1, false))
                {
                    objArray1 = type2.GetCustomAttributes(type1, false);
                    if ((objArray1 != null) && (objArray1.Length > 0))
                    {
                        attribute1 = (objArray1[0] as TypeAliasAttribute);
                        if (attribute1 != null)
                        {
                            for (num2 = 0; (num2 < attribute1.Aliases.Length); ++num2)
                            {
                                this.m_FullNames.Add(attribute1.Aliases[num2], type2);
                            }
                        }
                    }
                }
            }
        }

        public Type GetTypeByFullName(string fullName, bool ignoreCase)
        {
            return this.m_FullNames.Get(fullName, ignoreCase);
        }

        public Type GetTypeByName(string name, bool ignoreCase)
        {
            return this.m_Names.Get(name, ignoreCase);
        }


        // Properties
        public TypeTable FullNames
        {
            get
            {
                return this.m_FullNames;
            }
        }

        public TypeTable Names
        {
            get
            {
                return this.m_Names;
            }
        }

        public Type[] Types
        {
            get
            {
                return this.m_Types;
            }
        }


        // Fields
        private TypeTable m_FullNames;
        private TypeTable m_Names;
        private Type[] m_Types;
    }
}

