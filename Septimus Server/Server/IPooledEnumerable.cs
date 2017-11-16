namespace Server
{
    using System;
    using System.Collections;

    public interface IPooledEnumerable : IEnumerable
    {
        // Methods
        void Free();

    }
}

