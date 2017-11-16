namespace Server.Targeting
{
    using Server;
    using Server.Network;
    using System;

    public abstract class Target
    {
        // Methods
        public Target(int range, bool allowGround, TargetFlags flags)
        {
            this.m_TargetID = (++Target.m_NextTargetID);
            this.m_Range = range;
            this.m_AllowGround = allowGround;
            this.m_Flags = flags;
            this.m_CheckLOS = true;
        }

        public void BeginTimeout(Mobile from, TimeSpan delay)
        {
            this.m_TimeoutTime = (DateTime.Now + delay);
            if (this.m_TimeoutTimer != null)
            {
                this.m_TimeoutTimer.Stop();
            }
            this.m_TimeoutTimer = new TimeoutTimer(this, from, delay);
            this.m_TimeoutTimer.Start();
        }

        public static void Cancel(Mobile m)
        {
            NetState state1 = m.NetState;
            if (state1 != null)
            {
                state1.Send(CancelTarget.Instance);
            }
            Target target1 = m.Target;
            if (target1 != null)
            {
                target1.OnTargetCancel(m, TargetCancelType.Canceled);
            }
        }

        public void Cancel(Mobile from, TargetCancelType type)
        {
            this.CancelTimeout();
            from.ClearTarget();
            this.OnTargetCancel(from, type);
            this.OnTargetFinish(from);
        }

        public void CancelTimeout()
        {
            if (this.m_TimeoutTimer != null)
            {
                this.m_TimeoutTimer.Stop();
            }
            this.m_TimeoutTimer = null;
        }

        public virtual Packet GetPacket()
        {
            return new TargetReq(this);
        }

        public void Invoke(Mobile from, object targeted)
        {
            Point3D pointd1;
            Map map1;
            Item item1;
            object obj1;
            this.CancelTimeout();
            from.ClearTarget();
            if (from.Deleted)
            {
                this.OnTargetCancel(from, TargetCancelType.Canceled);
                this.OnTargetFinish(from);
                return;
            }
            if ((targeted is LandTarget))
            {
                pointd1 = ((LandTarget) targeted).Location;
                map1 = from.Map;
            }
            else if ((targeted is StaticTarget))
            {
                pointd1 = ((StaticTarget) targeted).Location;
                map1 = from.Map;
            }
            else if ((targeted is Mobile))
            {
                if (((Mobile) targeted).Deleted)
                {
                    this.OnTargetDeleted(from, targeted);
                    this.OnTargetFinish(from);
                    return;
                }
                if (!((Mobile) targeted).CanTarget)
                {
                    this.OnTargetUntargetable(from, targeted);
                    this.OnTargetFinish(from);
                    return;
                }
                pointd1 = ((Mobile) targeted).Location;
                map1 = ((Mobile) targeted).Map;
            }
            else if ((targeted is Item))
            {
                item1 = ((Item) targeted);
                if (item1.Deleted)
                {
                    this.OnTargetDeleted(from, targeted);
                    this.OnTargetFinish(from);
                    return;
                }
                if (!item1.CanTarget)
                {
                    this.OnTargetUntargetable(from, targeted);
                    this.OnTargetFinish(from);
                    return;
                }
                obj1 = item1.RootParent;
                if ((!this.m_AllowNonlocal && (obj1 is Mobile)) && ((obj1 != from) && (from.AccessLevel == AccessLevel.Player)))
                {
                    this.OnNonlocalTarget(from, targeted);
                    this.OnTargetFinish(from);
                    return;
                }
                pointd1 = item1.GetWorldLocation();
                map1 = item1.Map;
            }
            else
            {
                this.OnTargetCancel(from, TargetCancelType.Canceled);
                this.OnTargetFinish(from);
                return;
            }
            if (((map1 == null) || (map1 != from.Map)) || ((this.m_Range != -1) && !from.InRange(pointd1, this.m_Range)))
            {
                this.OnTargetOutOfRange(from, targeted);
            }
            else if (!from.CanSee(targeted))
            {
                this.OnCantSeeTarget(from, targeted);
            }
            else if (this.m_CheckLOS && !from.InLOS(targeted))
            {
                this.OnTargetOutOfLOS(from, targeted);
            }
            else if ((targeted is Item) && ((Item) targeted).InSecureTrade)
            {
                this.OnTargetInSecureTrade(from, targeted);
            }
            else if ((targeted is Item) && !((Item) targeted).IsAccessibleTo(from))
            {
                this.OnTargetNotAccessible(from, targeted);
            }
            else if ((targeted is Item) && !((Item) targeted).CheckTarget(from, this, targeted))
            {
                this.OnTargetUntargetable(from, targeted);
            }
            else if ((targeted is Mobile) && !((Mobile) targeted).CheckTarget(from, this, targeted))
            {
                this.OnTargetUntargetable(from, targeted);
            }
            else if (from.Region.OnTarget(from, this, targeted))
            {
                this.OnTarget(from, targeted);
            }
            this.OnTargetFinish(from);
        }

        protected virtual void OnCantSeeTarget(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500237);
        }

        protected virtual void OnNonlocalTarget(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500447);
        }

        protected virtual void OnTarget(Mobile from, object targeted)
        {
        }

        protected virtual void OnTargetCancel(Mobile from, TargetCancelType cancelType)
        {
        }

        protected virtual void OnTargetDeleted(Mobile from, object targeted)
        {
        }

        protected virtual void OnTargetFinish(Mobile from)
        {
        }

        protected virtual void OnTargetInSecureTrade(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500447);
        }

        protected virtual void OnTargetNotAccessible(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500447);
        }

        protected virtual void OnTargetOutOfLOS(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500237);
        }

        protected virtual void OnTargetOutOfRange(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500446);
        }

        protected virtual void OnTargetUntargetable(Mobile from, object targeted)
        {
            from.SendLocalizedMessage(500447);
        }

        public void Timeout(Mobile from)
        {
            this.CancelTimeout();
            from.ClearTarget();
            Target.Cancel(from);
            this.OnTargetCancel(from, TargetCancelType.Timeout);
            this.OnTargetFinish(from);
        }


        // Properties
        public bool AllowGround
        {
            get
            {
                return this.m_AllowGround;
            }
            set
            {
                this.m_AllowGround = value;
            }
        }

        public bool AllowNonlocal
        {
            get
            {
                return this.m_AllowNonlocal;
            }
            set
            {
                this.m_AllowNonlocal = value;
            }
        }

        public bool CheckLOS
        {
            get
            {
                return this.m_CheckLOS;
            }
            set
            {
                this.m_CheckLOS = value;
            }
        }

        public bool DisallowMultis
        {
            get
            {
                return this.m_DisallowMultis;
            }
            set
            {
                this.m_DisallowMultis = value;
            }
        }

        public TargetFlags Flags
        {
            get
            {
                return this.m_Flags;
            }
            set
            {
                this.m_Flags = value;
            }
        }

        public int Range
        {
            get
            {
                return this.m_Range;
            }
            set
            {
                this.m_Range = value;
            }
        }

        public int TargetID
        {
            get
            {
                return this.m_TargetID;
            }
        }

        public DateTime TimeoutTime
        {
            get
            {
                return this.m_TimeoutTime;
            }
        }


        // Fields
        private bool m_AllowGround;
        private bool m_AllowNonlocal;
        private bool m_CheckLOS;
        private bool m_DisallowMultis;
        private TargetFlags m_Flags;
        private static int m_NextTargetID;
        private int m_Range;
        private int m_TargetID;
        private DateTime m_TimeoutTime;
        private Timer m_TimeoutTimer;

        // Nested Types
        private class TimeoutTimer : Timer
        {
            // Methods
            static TimeoutTimer()
            {
                Target.TimeoutTimer.ThirtySeconds = TimeSpan.FromSeconds(30);
                Target.TimeoutTimer.TenSeconds = TimeSpan.FromSeconds(10);
                Target.TimeoutTimer.OneSecond = TimeSpan.FromSeconds(1);
            }

            public TimeoutTimer(Target target, Mobile m, TimeSpan delay) : base(delay)
            {
                this.m_Target = target;
                this.m_Mobile = m;
                if (delay >= Target.TimeoutTimer.ThirtySeconds)
                {
                    base.Priority = TimerPriority.FiveSeconds;
                    return;
                }
                if (delay >= Target.TimeoutTimer.TenSeconds)
                {
                    base.Priority = TimerPriority.OneSecond;
                    return;
                }
                if (delay >= Target.TimeoutTimer.OneSecond)
                {
                    base.Priority = TimerPriority.TwoFiftyMS;
                    return;
                }
                base.Priority = TimerPriority.TwentyFiveMS;
            }

            protected override void OnTick()
            {
                if (this.m_Mobile.Target == this.m_Target)
                {
                    this.m_Target.Timeout(this.m_Mobile);
                }
            }


            // Fields
            private Mobile m_Mobile;
            private Target m_Target;
            private static TimeSpan OneSecond;
            private static TimeSpan TenSeconds;
            private static TimeSpan ThirtySeconds;
        }
    }
}

