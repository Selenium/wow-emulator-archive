namespace Server.Accounting
{
    using Server;
    using System;
    using System.Reflection;

    public interface IAccount
    {
        // Properties
        Mobile this[int index] { get; set; }

    }
}

