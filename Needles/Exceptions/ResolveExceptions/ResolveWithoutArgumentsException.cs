using System;

namespace Needles.Exceptions.ResolveExceptions
{
    public class ResolveWithoutArgumentsException : Exception
    {
        internal ResolveWithoutArgumentsException(Type type, int total) : base(string.Format(
            "You specified 0 of {0} argument{1} needed to instantiate a new {2}.",
            total,
            total > 1 ? "s" : string.Empty,
            type.Name
        )) { }
    }
}