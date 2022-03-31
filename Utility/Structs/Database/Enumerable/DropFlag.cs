using System;

namespace Structs.Database
{
    [Flags]
    public enum DropFlag : byte
    {
        /// <summary>
        /// Can't be dropped
        /// </summary>
        No = 0,

        /// <summary>
        /// Can drop upon death
        /// </summary>
        Death = 1,

        /// <summary>
        /// Can drop upon user request
        /// </summary>
        User = 2,
    }
}