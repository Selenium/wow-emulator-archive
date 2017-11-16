namespace Server
{
    using System;
    using System.Collections;

    public class MovementEventArgs : EventArgs
    {
        // Methods
        static MovementEventArgs()
        {
            MovementEventArgs.m_Pool = new Queue();
        }

        public MovementEventArgs(Mobile mobile, Direction dir)
        {
            this.m_Mobile = mobile;
            this.m_Direction = dir;
        }

        public static MovementEventArgs Create(Mobile mobile, Direction dir)
        {
            MovementEventArgs args1;
            if (MovementEventArgs.m_Pool.Count > 0)
            {
                args1 = ((MovementEventArgs) MovementEventArgs.m_Pool.Dequeue());
                args1.m_Mobile = mobile;
                args1.m_Direction = dir;
                args1.m_Blocked = false;
                return args1;
            }
            return new MovementEventArgs(mobile, dir);
        }

        public void Free()
        {
            MovementEventArgs.m_Pool.Enqueue(this);
        }


        // Properties
        public bool Blocked
        {
            get
            {
                return this.m_Blocked;
            }
            set
            {
                this.m_Blocked = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return this.m_Direction;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }


        // Fields
        private bool m_Blocked;
        private Direction m_Direction;
        private Mobile m_Mobile;
        private static Queue m_Pool;
    }
}

