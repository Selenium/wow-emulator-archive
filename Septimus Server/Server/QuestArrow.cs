namespace Server
{
    using Server.Network;
    using System;

    public class QuestArrow
    {
        // Methods
        public QuestArrow(Mobile m)
        {
            this.m_Running = true;
            this.m_Mobile = m;
        }

        public QuestArrow(Mobile m, int x, int y) : this(m)
        {
            this.Update(x, y);
        }

        public virtual void OnClick(bool rightClick)
        {
        }

        public virtual void OnStop()
        {
        }

        public void Stop()
        {
            if (!this.m_Running)
            {
                return;
            }
            this.m_Mobile.ClearQuestArrow();
            this.m_Mobile.Send(new CancelArrow());
            this.m_Running = false;
            this.OnStop();
        }

        public void Update(int x, int y)
        {
            if (this.m_Running)
            {
                this.m_Mobile.Send(new SetArrow(x, y));
            }
        }


        // Properties
        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public bool Running
        {
            get
            {
                return this.m_Running;
            }
        }


        // Fields
        private Mobile m_Mobile;
        private bool m_Running;
    }
}

