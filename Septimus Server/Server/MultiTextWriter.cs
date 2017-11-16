namespace Server
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    public class MultiTextWriter : TextWriter
    {
        // Methods
        public MultiTextWriter(params TextWriter[] streams)
        {
            this.m_Streams = new ArrayList(streams);
            if (this.m_Streams.Count < 0)
            {
                throw new ArgumentException("You must specify at least one stream.");
            }
        }

        public void Add(TextWriter tw)
        {
            this.m_Streams.Add(tw);
        }

        public void Remove(TextWriter tw)
        {
            this.m_Streams.Remove(tw);
        }

        public override void Write(char ch)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_Streams.Count); ++num1)
            {
                ((TextWriter) this.m_Streams[num1]).Write(ch);
            }
        }

        public override void WriteLine(string line)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_Streams.Count); ++num1)
            {
                ((TextWriter) this.m_Streams[num1]).WriteLine(line);
            }
        }

        public override void WriteLine(string line, params object[] args)
        {
            this.WriteLine(string.Format(line, args));
        }


        // Properties
        public override Encoding Encoding
        {
            get
            {
                return Encoding.Default;
            }
        }


        // Fields
        private ArrayList m_Streams;
    }
}

