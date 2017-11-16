namespace Server.Guilds
{
    using Server;
    using System;
    using System.Collections;

    public abstract class BaseGuild
    {
        // Methods
        static BaseGuild()
        {
            BaseGuild.m_GuildList = new Hashtable();
            BaseGuild.m_NextID = 1;
        }

        public BaseGuild()
        {
            this.m_Id = BaseGuild.m_NextID++;
            BaseGuild.m_GuildList.Add(this.m_Id, this);
        }

        public BaseGuild(int Id)
        {
            this.m_Id = Id;
            BaseGuild.m_GuildList.Add(this.m_Id, this);
            if ((this.m_Id + 1) > BaseGuild.m_NextID)
            {
                BaseGuild.m_NextID = (this.m_Id + 1);
            }
        }

        public abstract void Deserialize(GenericReader reader);

        public static BaseGuild Find(int id)
        {
            return ((BaseGuild) BaseGuild.m_GuildList[id]);
        }

        public static BaseGuild FindByAbbrev(string abbr)
        {
            foreach (BaseGuild guild1 in BaseGuild.m_GuildList.Values)
            {
                if (guild1.Abbreviation == abbr)
                {
                    return guild1;
                }
            }
            return null;
        }

        public static BaseGuild FindByName(string name)
        {
            foreach (BaseGuild guild1 in BaseGuild.m_GuildList.Values)
            {
                if (guild1.Name == name)
                {
                    return guild1;
                }
            }
            return null;
        }

        public abstract void OnDelete(Mobile mob);

        public static BaseGuild[] Search(string find)
        {
            bool flag1;
            string text1;
            int num1;
            char[] chArray1 = new char[1];
            chArray1[0] = ' ';
            string[] textArray1 = find.ToLower().Split(chArray1);
            ArrayList list1 = new ArrayList();
            foreach (BaseGuild guild1 in BaseGuild.m_GuildList.Values)
            {
                flag1 = true;
                text1 = guild1.Name.ToLower();
                for (num1 = 0; (num1 < textArray1.Length); ++num1)
                {
                    if (text1.IndexOf(textArray1[num1]) == -1)
                    {
                        flag1 = false;
                        break;
                    }
                }
                if (flag1)
                {
                    list1.Add(guild1);
                }
            }
            return ((BaseGuild[]) list1.ToArray(typeof(BaseGuild)));
        }

        public abstract void Serialize(GenericWriter writer);


        // Properties
        public abstract string Abbreviation { get; set; }

        public abstract bool Disbanded { get; }

        public int Id
        {
            get
            {
                return this.m_Id;
            }
        }

        public static Hashtable List
        {
            get
            {
                return BaseGuild.m_GuildList;
            }
        }

        public abstract string Name { get; set; }

        public abstract GuildType Type { get; set; }


        // Fields
        private static Hashtable m_GuildList;
        private int m_Id;
        private static int m_NextID;
    }
}

