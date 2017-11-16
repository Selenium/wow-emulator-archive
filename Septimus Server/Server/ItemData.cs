namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ItemData
    {
        // Methods
        public ItemData(string name, TileFlag flags, int weight, int quality, int quantity, int value, int height)
        {
            this.m_Name = name;
            this.m_Flags = flags;
            this.m_Weight = ((byte) weight);
            this.m_Quality = ((byte) quality);
            this.m_Quantity = ((byte) quantity);
            this.m_Value = ((byte) value);
            this.m_Height = ((byte) height);
        }


        // Properties
        public bool Bridge
        {
            get
            {
                return ((this.m_Flags & TileFlag.Bridge) != TileFlag.None);
            }
            set
            {
                if (value)
                {
                    this.m_Flags |= TileFlag.Bridge;
                    return;
                }
                this.m_Flags &= (TileFlag.StairBack | (TileFlag.Door | (TileFlag.Roof | (TileFlag.Armor | (TileFlag.Unknown3 | (TileFlag.NoDiagonal | (TileFlag.Animation | (TileFlag.LightSource | (TileFlag.Wearable | (TileFlag.Container | (TileFlag.Map | (TileFlag.Unknown2 | (TileFlag.PartialHue | (TileFlag.Foliage | (TileFlag.Internal | (TileFlag.ArticleAn | (TileFlag.ArticleA | (TileFlag.NoShoot | (TileFlag.Window | (TileFlag.Generic | (TileFlag.Surface | (TileFlag.Unknown1 | (TileFlag.Wet | (TileFlag.Impassable | (TileFlag.Damaging | (TileFlag.Wall | (TileFlag.Translucent | (TileFlag.Transparent | (TileFlag.Weapon | (TileFlag.Background | TileFlag.StairRight))))))))))))))))))))))))))))));
            }
        }

        public int CalcHeight
        {
            get
            {
                if ((this.m_Flags & TileFlag.Bridge) != TileFlag.None)
                {
                    return (this.m_Height / 2);
                }
                return this.m_Height;
            }
        }

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

        public int Height
        {
            get
            {
                return this.m_Height;
            }
            set
            {
                this.m_Height = ((byte) value);
            }
        }

        public bool Impassable
        {
            get
            {
                return ((this.m_Flags & TileFlag.Impassable) != TileFlag.None);
            }
            set
            {
                if (value)
                {
                    this.m_Flags |= TileFlag.Impassable;
                    return;
                }
                this.m_Flags &= (TileFlag.StairBack | (TileFlag.Door | (TileFlag.Roof | (TileFlag.Armor | (TileFlag.Unknown3 | (TileFlag.NoDiagonal | (TileFlag.Animation | (TileFlag.LightSource | (TileFlag.Wearable | (TileFlag.Container | (TileFlag.Map | (TileFlag.Unknown2 | (TileFlag.PartialHue | (TileFlag.Foliage | (TileFlag.Internal | (TileFlag.ArticleAn | (TileFlag.ArticleA | (TileFlag.NoShoot | (TileFlag.Window | (TileFlag.Generic | (TileFlag.Bridge | (TileFlag.Surface | (TileFlag.Unknown1 | (TileFlag.Wet | (TileFlag.Damaging | (TileFlag.Wall | (TileFlag.Translucent | (TileFlag.Transparent | (TileFlag.Weapon | (TileFlag.Background | TileFlag.StairRight))))))))))))))))))))))))))))));
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

        public int Quality
        {
            get
            {
                return this.m_Quality;
            }
            set
            {
                this.m_Quality = ((byte) value);
            }
        }

        public int Quantity
        {
            get
            {
                return this.m_Quantity;
            }
            set
            {
                this.m_Quantity = ((byte) value);
            }
        }

        public bool Surface
        {
            get
            {
                return ((this.m_Flags & TileFlag.Surface) != TileFlag.None);
            }
            set
            {
                if (value)
                {
                    this.m_Flags |= TileFlag.Surface;
                    return;
                }
                this.m_Flags &= (TileFlag.StairBack | (TileFlag.Door | (TileFlag.Roof | (TileFlag.Armor | (TileFlag.Unknown3 | (TileFlag.NoDiagonal | (TileFlag.Animation | (TileFlag.LightSource | (TileFlag.Wearable | (TileFlag.Container | (TileFlag.Map | (TileFlag.Unknown2 | (TileFlag.PartialHue | (TileFlag.Foliage | (TileFlag.Internal | (TileFlag.ArticleAn | (TileFlag.ArticleA | (TileFlag.NoShoot | (TileFlag.Window | (TileFlag.Generic | (TileFlag.Bridge | (TileFlag.Unknown1 | (TileFlag.Wet | (TileFlag.Impassable | (TileFlag.Damaging | (TileFlag.Wall | (TileFlag.Translucent | (TileFlag.Transparent | (TileFlag.Weapon | (TileFlag.Background | TileFlag.StairRight))))))))))))))))))))))))))))));
            }
        }

        public int Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = ((byte) value);
            }
        }

        public int Weight
        {
            get
            {
                return this.m_Weight;
            }
            set
            {
                this.m_Weight = ((byte) value);
            }
        }


        // Fields
        private TileFlag m_Flags;
        private byte m_Height;
        private string m_Name;
        private byte m_Quality;
        private byte m_Quantity;
        private byte m_Value;
        private byte m_Weight;
    }
}

