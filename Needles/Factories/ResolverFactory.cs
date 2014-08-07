using System;
using System.Linq;
using Needles.Parameters;
using Needles.Resolvers;
using Needles.Resolvers.LazyResolvers;

namespace Needles.Factories
{
    internal interface IResolverFactory
    {
        ILazyResolver<T> CreateLazyResolver<T>();
        IFuncResolver<T> CreateFuncResolver<T>(Func<IResolverContainer, T> factory);
        IServiceResolver<T> CreateServiceResolver<T>(T instance);
        IServiceResolver<T> CreateServiceResolver<T>(IResolver<T> resolver); 
    }

    internal interface IResolverFactoryInitializer
    {
        IResolverContainer Container { set; }
    }
    
    internal class ResolverFactory : IResolverFactoryInitializer, IResolverFactory
    {
        private readonly IParameterCollectionFactory _parameterCollectionFactory;

        public ResolverFactory(IParameterCollectionFactory parameterCollectionFactory)
        {
            _parameterCollectionFactory = parameterCollectionFactory;
        }

        public IResolverContainer Container { set; private get; }

        public ILazyResolver<T> CreateLazyResolver<T>()
        {
            var parameters = _parameterCollectionFactory.Create<T>();

            if (parameters.Any())
                return new ParametrizedLazyResolver<T>(new ArgumentsResolver(parameters, new ArgumentsValidation(parameters), Container));

            return new SimpleLazyResolver<T>();
        }

        public IFuncResolver<T> CreateFuncResolver<T>(Func<IResolverContainer, T> factory)
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