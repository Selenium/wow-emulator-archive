namespace Server.Menus.Questions
{
    using Server.Menus;
    using Server.Network;
    using System;

    public class QuestionMenu : IMenu
    {
        // Methods
        public QuestionMenu(string question, string[] answers)
        {
            this.m_Question = question;
            this.m_Answers = answers;
            do
            {
                this.m_Serial = (++QuestionMenu.m_NextSerial);
                this.m_Serial &= 2147483647;
            }
            while ((this.m_Serial == 0));
        }

        public virtual void OnCancel(NetState state)
        {
        }

        public virtual void OnResponse(NetState state, int index)
        {
        }

        public void SendTo(NetState state)
        {
            state.AddMenu(this);
            state.Send(new DisplayQuestionMenu(this));
        }


        // Properties
        public string[] Answers
        {
            get
            {
                return this.m_Answers;
            }
        }

        public string Question
        {
            get
            {
                return this.m_Question;
            }
            set
            {
                this.m_Question = value;
            }
        }

        int Server.Menus.IMenu.EntryLength
        {
            get
            {
                return this.m_Answers.Length;
            }
        }

        int Server.Menus.IMenu.Serial
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private string[] m_Answers;
        private static int m_NextSerial;
        private string m_Question;
        private int m_Serial;
    }
}

