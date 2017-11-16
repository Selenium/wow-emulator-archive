namespace Server.Gumps
{
    using Server.Network;
    using System;
    using System.Collections;
    using System.Text;

    public class Gump
    {
        // Methods
        static Gump()
        {
            Gump.m_NextSerial = 1;
            Gump.m_BeginLayout = Gump.StringToBuffer("{ ");
            Gump.m_EndLayout = Gump.StringToBuffer(" }");
            Gump.m_NoMove = Gump.StringToBuffer("{ nomove }");
            Gump.m_NoClose = Gump.StringToBuffer("{ noclose }");
            Gump.m_NoDispose = Gump.StringToBuffer("{ nodispose }");
            Gump.m_NoResize = Gump.StringToBuffer("{ noresize }");
        }

        public Gump(int x, int y)
        {
            this.m_Dragable = true;
            this.m_Closable = true;
            this.m_Resizable = true;
            this.m_Disposable = true;
            do
            {
                this.m_Serial = Gump.m_NextSerial++;
            }
            while ((this.m_Serial == 0));
            this.m_X = x;
            this.m_Y = y;
            this.m_TypeID = Gump.GetTypeID(base.GetType());
            this.m_Entries = new ArrayList();
            this.m_Strings = new ArrayList();
        }

        public void Add(GumpEntry g)
        {
            if (g.Parent != this)
            {
                g.Parent = this;
                return;
            }
            if (!this.m_Entries.Contains(g))
            {
                this.Invalidate();
                this.m_Entries.Add(g);
            }
        }

        public void AddAlphaRegion(int x, int y, int width, int height)
        {
            this.Add(new GumpAlphaRegion(x, y, width, height));
        }

        public void AddBackground(int x, int y, int width, int height, int gumpID)
        {
            this.Add(new GumpBackground(x, y, width, height, gumpID));
        }

        public void AddButton(int x, int y, int normalID, int pressedID, int buttonID, GumpButtonType type, int param)
        {
            this.Add(new GumpButton(x, y, normalID, pressedID, buttonID, type, param));
        }

        public void AddCheck(int x, int y, int inactiveID, int activeID, bool initialState, int switchID)
        {
            this.Add(new GumpCheck(x, y, inactiveID, activeID, initialState, switchID));
        }

        public void AddGroup(int group)
        {
            this.Add(new GumpGroup(group));
        }

        public void AddHtml(int x, int y, int width, int height, string text, bool background, bool scrollbar)
        {
            this.Add(new GumpHtml(x, y, width, height, text, background, scrollbar));
        }

        public void AddHtmlLocalized(int x, int y, int width, int height, int number, bool background, bool scrollbar)
        {
            this.Add(new GumpHtmlLocalized(x, y, width, height, number, background, scrollbar));
        }

        public void AddHtmlLocalized(int x, int y, int width, int height, int number, int color, bool background, bool scrollbar)
        {
            this.Add(new GumpHtmlLocalized(x, y, width, height, number, color, background, scrollbar));
        }

        public void AddImage(int x, int y, int gumpID)
        {
            this.Add(new GumpImage(x, y, gumpID));
        }

        public void AddImage(int x, int y, int gumpID, int hue)
        {
            this.Add(new GumpImage(x, y, gumpID, hue));
        }

        public void AddImageTiled(int x, int y, int width, int height, int gumpID)
        {
            this.Add(new GumpImageTiled(x, y, width, height, gumpID));
        }

        public void AddItem(int x, int y, int itemID)
        {
            this.Add(new GumpItem(x, y, itemID));
        }

        public void AddItem(int x, int y, int itemID, int hue)
        {
            this.Add(new GumpItem(x, y, itemID, hue));
        }

        public void AddLabel(int x, int y, int hue, string text)
        {
            this.Add(new GumpLabel(x, y, hue, text));
        }

        public void AddLabelCropped(int x, int y, int width, int height, int hue, string text)
        {
            this.Add(new GumpLabelCropped(x, y, width, height, hue, text));
        }

        public void AddPage(int page)
        {
            this.Add(new GumpPage(page));
        }

        public void AddRadio(int x, int y, int inactiveID, int activeID, bool initialState, int switchID)
        {
            this.Add(new GumpRadio(x, y, inactiveID, activeID, initialState, switchID));
        }

        public void AddTextEntry(int x, int y, int width, int height, int hue, int entryID, string initialText)
        {
            this.Add(new GumpTextEntry(x, y, width, height, hue, entryID, initialText));
        }

        private Packet Compile()
        {
            DisplayGumpFast fast1;
            int num1;
            GumpEntry entry1;
            int num2;
            if (this.m_Packet == null)
            {
                fast1 = new DisplayGumpFast(this);
                if (!this.m_Dragable)
                {
                    fast1.AppendLayout(Gump.m_NoMove);
                }
                if (!this.m_Closable)
                {
                    fast1.AppendLayout(Gump.m_NoClose);
                }
                if (!this.m_Disposable)
                {
                    fast1.AppendLayout(Gump.m_NoDispose);
                }
                if (!this.m_Resizable)
                {
                    fast1.AppendLayout(Gump.m_NoResize);
                }
                num1 = this.m_Entries.Count;
                for (num2 = 0; (num2 < num1); ++num2)
                {
                    entry1 = ((GumpEntry) this.m_Entries[num2]);
                    fast1.AppendLayout(Gump.m_BeginLayout);
                    entry1.AppendTo(fast1);
                    fast1.AppendLayout(Gump.m_EndLayout);
                }
                fast1.WriteText(this.m_Strings);
                this.m_Packet = fast1;
            }
            return this.m_Packet;
        }

        public static int GetTypeID(Type type)
        {
            RuntimeTypeHandle handle1 = type.TypeHandle;
            IntPtr ptr1 = handle1.Value;
            return ((type.GetHashCode() ^ type.FullName.GetHashCode()) ^ ptr1.ToInt32());
        }

        public int Intern(string value)
        {
            int num1 = this.m_Strings.IndexOf(value);
            if (num1 >= 0)
            {
                return num1;
            }
            this.Invalidate();
            return this.m_Strings.Add(value);
        }

        public void Invalidate()
        {
            if (this.m_Packet != null)
            {
                this.m_Packet = null;
                if (this.m_Strings.Count > 0)
                {
                    this.m_Strings.Clear();
                }
            }
        }

        public virtual void OnResponse(NetState sender, RelayInfo info)
        {
        }

        public void Remove(GumpEntry g)
        {
            this.Invalidate();
            this.m_Entries.Remove(g);
            g.Parent = null;
        }

        public void SendTo(NetState state)
        {
            state.AddGump(this);
            state.Send(this.Compile());
        }

        public static byte[] StringToBuffer(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }


        // Properties
        public bool Closable
        {
            get
            {
                return this.m_Closable;
            }
            set
            {
                if (this.m_Closable != value)
                {
                    this.m_Closable = value;
                    this.Invalidate();
                }
            }
        }

        public bool Disposable
        {
            get
            {
                return this.m_Disposable;
            }
            set
            {
                if (this.m_Disposable != value)
                {
                    this.m_Disposable = value;
                    this.Invalidate();
                }
            }
        }

        public bool Dragable
        {
            get
            {
                return this.m_Dragable;
            }
            set
            {
                if (this.m_Dragable != value)
                {
                    this.m_Dragable = value;
                    this.Invalidate();
                }
            }
        }

        public ArrayList Entries
        {
            get
            {
                return this.m_Entries;
            }
        }

        public bool Resizable
        {
            get
            {
                return this.m_Resizable;
            }
            set
            {
                if (this.m_Resizable != value)
                {
                    this.m_Resizable = value;
                    this.Invalidate();
                }
            }
        }

        public int Serial
        {
            get
            {
                return this.m_Serial;
            }
            set
            {
                if (this.m_Serial != value)
                {
                    this.m_Serial = value;
                    this.Invalidate();
                }
            }
        }

        public int TypeID
        {
            get
            {
                return this.m_TypeID;
            }
        }

        public int X
        {
            get
            {
                return this.m_X;
            }
            set
            {
                if (this.m_X != value)
                {
                    this.m_X = value;
                    this.Invalidate();
                }
            }
        }

        public int Y
        {
            get
            {
                return this.m_Y;
            }
            set
            {
                if (this.m_Y != value)
                {
                    this.m_Y = value;
                    this.Invalidate();
                }
            }
        }


        // Fields
        private static byte[] m_BeginLayout;
        private bool m_Closable;
        private bool m_Disposable;
        private bool m_Dragable;
        private static byte[] m_EndLayout;
        private ArrayList m_Entries;
        private static int m_NextSerial;
        private static byte[] m_NoClose;
        private static byte[] m_NoDispose;
        private static byte[] m_NoMove;
        private static byte[] m_NoResize;
        private DisplayGumpFast m_Packet;
        private bool m_Resizable;
        private int m_Serial;
        private ArrayList m_Strings;
        private int m_TypeID;
        private int m_X;
        private int m_Y;
    }
}

