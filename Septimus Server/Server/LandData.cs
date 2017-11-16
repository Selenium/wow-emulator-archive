namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LandData
    {
        // Methods
        public LandData(string name, TileFlag flags)
        {
            this.m_Name = name;
            this.m_Flags = flags;
        }


        // Properties
        public TileFlag Flags
        {
            get
            {
                return this.m_Flags;
            }
            set
            {
                this.m_Flags = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }


        // Fields
        private TileFlag m_Flags;
        private string m_Name;
    }
}

