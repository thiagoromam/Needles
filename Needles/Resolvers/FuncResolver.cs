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
        private readonly IContainer _container;
        private readonly Func<IContainer, T> _factory;

        public FuncResolver(IContainer container, Func<IContainer, T> factory)
        {
            _container = container;
            _factory = factory;
        }

        public T Resolve(params object[] args)
        {
            if (!args.IsNullOrEmpty())
                throw new ResolveWithParametersException();

            return _factory(_container);
        }
    }
}