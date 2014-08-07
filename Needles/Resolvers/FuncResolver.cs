using System;
using Needles.Exceptions.ResolveExceptions;
using Needles.Helpers;

namespace Needles.Resolvers
{
    internal interface IFuncResolver<out T> : IResolver<T>
    {
    }

    internal class FuncResolver<T> : IFuncResolver<T>
    {
        private readonly IResolverContainer _container;
        private readonly Func<IResolverContainer, T> _factory;

        public FuncResolver(IResolverContainer container, Func<IResolverContainer, T> factory)
        {
            _container = container;
            _factory = factory;
        }

        public T Resolve(params object[] args)
        {
            if (!args.IsNullOrEmpty())
                throw new ResolveWithArgumentsException(typeof(T), ResolveWithArgumentsExceptionType.ResolveDoesNotAcceptArguments);

            return _factory(_container);
        }
    }
}