namespace Server.Network
{
    using Server.Menus.Questions;
    using System;

    public sealed class DisplayQuestionMenu : Packet
    {
        // Methods
        public DisplayQuestionMenu(QuestionMenu menu) : base(124)
        {
            int num3;
            string text2;
            int num4;
            base.EnsureCapacity(256);
            this.m_Stream.Write(menu.Serial);
            this.m_Stream.Write(((short) 0));
            string text1 = menu.Question;
            if (text1 == null)
            {
                text1 = "";
            }
            int num1 = ((byte) text1.Length);
            this.m_Stream.Write(((byte) num1));
            this.m_Stream.WriteAsciiFixed(text1, num1);
            string[] textArray1 = menu.Answers;
            int num2 = ((byte) textArray1.Length);
            this.m_Stream.Write(((byte) num2));
            for (num3 = 0; (num3 < num2); ++num3)
            {
                this.m_Stream.Write(0);
                text2 = textArray1[num3];
                if (text2 == null)
                {
                    text2 = "";
                }
                num4 = ((byte) text2.Length);
                this.m_Stream.Write(((byte) num4));
                this.m_Stream.WriteAsciiFixed(text2, num4);
            }
        }

    }
}

