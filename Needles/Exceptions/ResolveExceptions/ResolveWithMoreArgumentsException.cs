using System;

namespace Needles.Exceptions.ResolveExceptions
{
    public class ResolveWithMoreArgumentsException : Exception
    {
        internal ResolveWithMoreArgumentsException(Type type, int total, int informed) : base(string.Format(
            "You specified {0} of {1} argument{2} needed to instantiate a new {3}.",
            informed,
            total,
            total > 1 ? "s" : string.Empty,
            type.Name
        )) { }
    }
}