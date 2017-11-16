namespace Server
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class CallPriorityComparer : IComparer
    {
        // Methods
        public CallPriorityComparer()
        {
        }

        public int Compare(object x, object y)
        {
            MethodInfo info1 = (x as MethodInfo);
            MethodInfo info2 = (y as MethodInfo);
            if ((info1 == null) && (info2 == null))
            {
                return 0;
            }
            if (info1 == null)
            {
                return 1;
            }
            if (info2 == null)
            {
                return -1;
            }
            return (this.GetPriority(info1) - this.GetPriority(info2));
        }

        private int GetPriority(MethodInfo mi)
        {
            object[] objArray1 = mi.GetCustomAttributes(typeof(CallPriorityAttribute), true);
            if (objArray1 == null)
            {
                return 0;
            }
            if (objArray1.Length == 0)
            {
                return 0;
            }
            CallPriorityAttribute attribute1 = (objArray1[0] as CallPriorityAttribute);
            if (attribute1 == null)
            {
                return 0;
            }
            return attribute1.Priority;
        }

    }
}

