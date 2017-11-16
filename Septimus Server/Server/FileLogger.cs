namespace Server
{
    using System;
    using System.IO;
    using System.Text;

    public class FileLogger : TextWriter, IDisposable
    {
        // Methods
        public FileLogger(string file) : this(file, false)
        {
        }

        public FileLogger(string file, bool append)
        {
            DateTime time1;
            this.m_FileName = file;
            using (StreamWriter writer1 = new StreamWriter(new FileStream(this.m_FileName, (append ? FileMode.Append : FileMode.Create), FileAccess.Write, FileShare.Read)))
            {
                time1 = DateTime.Now;
                writer1.WriteLine(">>>Logging started on {0}.", time1.ToString("f"));
            }
            this.m_NewLine = true;
        }

        public override void Write(char ch)
        {
            DateTime time1;
            using (StreamWriter writer1 = new StreamWriter(new FileStream(this.m_FileName, FileMode.Append, FileAccess.Write, FileShare.Read)))
            {
                if (this.m_NewLine)
                {
                    time1 = DateTime.Now;
                    writer1.Write(time1.ToString("[MMMM dd hh:mm:ss.f tt]: "));
                    this.m_NewLine = false;
                }
                writer1.Write(ch);
                return;
            }
        }

        public override void Write(string str)
        {
            DateTime time1;
            using (StreamWriter writer1 = new StreamWriter(new FileStream(this.m_FileName, FileMode.Append, FileAccess.Write, FileShare.Read)))
            {
                if (this.m_NewLine)
                {
                    time1 = DateTime.Now;
                    writer1.Write(time1.ToString("[MMMM dd hh:mm:ss.f tt]: "));
                    this.m_NewLine = false;
                }
                writer1.Write(str);
                return;
            }
        }

        public override void WriteLine(string line)
        {
            DateTime time1;
            using (StreamWriter writer1 = new StreamWriter(new FileStream(this.m_FileName, FileMode.Append, FileAccess.Write, FileShare.Read)))
            {
                if (this.m_NewLine)
                {
                    time1 = DateTime.Now;
                    writer1.Write(time1.ToString("[MMMM dd hh:mm:ss.f tt]: "));
                }
                writer1.WriteLine(line);
                this.m_NewLine = true;
                return;
            }
        }


        // Properties
        public override Encoding Encoding
        {
            get
            {
                return Encoding.Default;
            }
        }

        public string FileName
        {
            get
            {
                return this.m_FileName;
            }
        }


        // Fields
        public const string DateFormat = "[MMMM dd hh:mm:ss.f tt]: ";
        private string m_FileName;
        private bool m_NewLine;
    }
}

