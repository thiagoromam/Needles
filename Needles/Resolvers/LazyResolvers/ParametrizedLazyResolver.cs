using System;
using Needles.Parameters;

namespace Needles.Resolvers.LazyResolvers
{
    internal class ParametrizedLazyResolver<T> : ILazyResolver<T>
    {
        private readonly IArgumentsResolver _argumentsResolver;

        public ParametrizedLazyResolver(IArgumentsResolver argumentsResolver)
        {
            _argumentsResolver = argumentsResolver;
        }

        public T Resolve(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), _argumentsResolver.Resolve(args));
        }
    }
}