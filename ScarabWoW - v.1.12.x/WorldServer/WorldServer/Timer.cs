namespace WorldServer
{
    using System;

    internal class Timer
    {
        public DateTime CreateTime = DateTime.Now;
        public DateTime LastTime = DateTime.Now;
        public int TimeOut;

        public bool IsExpired()
        {
            TimeSpan span = (TimeSpan) (DateTime.Now - this.CreateTime);
            return (span.TotalMilliseconds >= this.TimeOut);
        }

        public void SetTimeOut(int Milisecs)
        {
            this.TimeOut = Milisecs;
        }
    }
}

