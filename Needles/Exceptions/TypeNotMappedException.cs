using System;

namespace Needles.Exceptions
{
    public class TypeNotMappedException : Exception
    {
        internal TypeNotMappedException(Type type) : base(string.Format(
            "The type {0} is not mapped.",
            type.Name
        )) { }
    }
}