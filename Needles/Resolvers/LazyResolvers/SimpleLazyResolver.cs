using System;
using Needles.Exceptions.ResolveExceptions;
using Needles.Helpers;

namespace Needles.Resolvers.LazyResolvers
{
    internal class SimpleLazyResolver<T> : ILazyResolver<T>
    {
        public T Resolve(params object[] args)
        {
            if (!args.IsNullOrEmpty())
                throw new ResolveWithParametersException();

            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}