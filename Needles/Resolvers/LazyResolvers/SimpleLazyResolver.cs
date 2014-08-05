using System;

namespace Needles.Resolvers.LazyResolvers
{
    internal class SimpleLazyResolver<T> : IResolver<T>
    {
        public T Resolve(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}