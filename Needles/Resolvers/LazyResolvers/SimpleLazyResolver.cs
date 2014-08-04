using System;

namespace Needles.Resolvers.LazyResolvers
{
    internal class SimpleLazyResolver<T> : IResolver<T>
    {
        public T Resolve(object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}