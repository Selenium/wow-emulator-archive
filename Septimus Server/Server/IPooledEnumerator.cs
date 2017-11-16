namespace Server
{
    using System;
    using System.Collections;

    public interface IPooledEnumerator : IEnumerator
    {
        // Methods
        void Free();


        // Properties
        IPooledEnumerable Enumerable { get; set; }

    }
}

