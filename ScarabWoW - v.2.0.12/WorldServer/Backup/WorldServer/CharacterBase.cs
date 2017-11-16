namespace WorldServer
{
    using System;
    using System.Collections;

    internal class CharacterBase
    {
        public ObjectBase BaseObject = new ObjectBase();
        public Classes class_ = ((Classes) 0);
        public uint displayid = 0;
        public byte face = 0;
        public byte facialhair = 0;
        public byte flags = 0;
        public Gender gender = Gender.MALE;
        public ulong guid = ((ulong) 0);
        public uint guildid = 0;
        public byte haircolor = 0;
        public byte hairstyle = 0;
        public byte level = 0;
        public uint map = 0;
        public string name = null;
        public float o = 0f;
        public Hashtable ObjectsInRange;
        public uint petfamilyid = 0;
        public uint petinfoid = 0;
        public uint petlevel = 0;
        public Powers PowerType;
        public Races race = ((Races) 0);
        public byte rest = 0;
        public byte skin = 0;
        public uint tutorialflags = 0;
        public float x = 0f;
        public float y = 0f;
        public float z = 0f;
        public uint zoneid = 0;

        public uint GetDisplayId()
        {
            uint num = 0;
            switch (this.race)
            {
                case Races.HUMAN:
                    num = 0x31;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.ORC:
                    num = 0x33;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.DWARF:
                    num = 0x35;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.NIGHTELF:
                    num = 0x37;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.UNDEAD:
                    num = 0x39;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.TAUREN:
                    num = 0x3b;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.GNOME:
                    num = 0x61b;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.TROLL:
                    num = 0x5c6;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;

                case Races.Blood_Elf:
                    num = 0x3c73;
                    if (this.gender == Gender.MALE)
                    {
                        num++;
                    }
                    return num;

                case Races.Draenei:
                    num = 0x3efd;
                    if (this.gender == Gender.FEMALE)
                    {
                        num++;
                    }
                    return num;
            }
            Console.WriteLine("Unkown race: " + this.race.ToString());
            return num;
        }

        public uint GetFactionTemplate()
        {
            switch (this.race)
            {
                case Races.HUMAN:
                    return 1;

                case Races.ORC:
                    return 2;

                case Races.DWARF:
                    return 3;

                case Races.NIGHTELF:
                    return 4;

                case Races.UNDEAD:
                    return 5;

                case Races.TAUREN:
                    return 6;

                case Races.GNOME:
                    return 8;

                case Races.TROLL:
                    return 9;

                case Races.Blood_Elf:
                    return 0x392;

                case Races.Draenei:
                    return 4;
            }
            return 0;
        }

        public Powers GetPowerType()
        {
            switch (this.class_)
            {
                case Classes.WARRIOR:
                    return Powers.RAGE;

                case Classes.PALADIN:
                case Classes.PRIEST:
                case Classes.SHAMAN:
                case Classes.MAGE:
                case Classes.WARLOCK:
                case Classes.DRUID:
                    return Powers.MANA;

                case Classes.HUNTER:
                    return Powers.FOCUS;

                case Classes.ROGUE:
                    return Powers.ENERGY;
            }
            return Powers.MANA;
        }

        public Side GetSide()
        {
            return this.GetSideByRAce(this.race);
        }

        public Side GetSideByRAce(Races r)
        {
            if ((((r == Races.DWARF) || (r == Races.GNOME)) || ((r == Races.HUMAN) || (r == Races.NIGHTELF))) || (r == Races.Draenei))
            {
                return Side.ALLIANCE;
            }
            return Side.HORDE;
        }
    }
}

