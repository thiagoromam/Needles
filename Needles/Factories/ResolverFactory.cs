using System;
using System.Linq;
using Needles.Parameters;
using Needles.Resolvers;
using Needles.Resolvers.LazyResolvers;

namespace Needles.Factories
{
    internal interface IResolverFactory
    {
        IContainer Container { set; }

        ILazyResolver<T> CreateLazyResolver<T>();
        IFuncResolver<T> CreateFuncResolver<T>(Func<IContainer, T> factory);
        IServiceResolver<T> CreateServiceResolver<T>(T instance);
        IServiceResolver<T> CreateServiceResolver<T>(IResolver<T> resolver); 
    }

    internal class ResolverFactory : IResolverFactory
    {
        private readonly IParameterCollectionFactory _parameterCollectionFactory;

        public ResolverFactory(IParameterCollectionFactory parameterCollectionFactory)
        {
            _parameterCollectionFactory = parameterCollectionFactory;
        }

        public IContainer Container { set; private get; }

        public ILazyResolver<T> CreateLazyResolver<T>()
        {
            var parameters = _parameterCollectionFactory.Create<T>();

            if (parameters.Any())
                return new ParametrizedLazyResolver<T>(new ArgumentsResolver(parameters, new ArgumentsValidation(parameters), Container));

            return new SimpleLazyResolver<T>();
        }

        public IFuncResolver<T> CreateFuncResolver<T>(Func<IContainer, T> factory)
        {
            return new FuncResolver<T>(Container, factory);
        }

        public IServiceResolver<T> CreateServiceResolver<T>(T instance)
        {
            return new ServiceResolver<T>(instance);
        }
        public IServiceResolver<T> CreateServiceResolver<T>(IResolver<T> resolver)
        {
            return new ServiceResolver<T>(resolver);
        }

    }
}