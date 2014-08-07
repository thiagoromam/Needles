using System;
using Needles.Factories;
using Needles.Resolvers;
using Needles.Resolvers.LazyResolvers;

namespace Needles.Tests.Mocks
{
    internal class ResolverFactoryMock : IResolverFactory, IResolverFactoryInitializer
    {
        public IResolverMock Resolver { get; set; }
        public IResolverContainer Container { set; get; }

        ILazyResolver<T> IResolverFactory.CreateLazyResolver<T>()
        {
            var r = new LazyResolverMock<T>();
            Resolver = r;

            return r;
        }

        IFuncResolver<T> IResolverFactory.CreateFuncResolver<T>(Func<IResolverContainer, T> factory)
        {
            var r = new FuncResolverMock<T>();
            Resolver = r;

            return r;
        }

        IServiceResolver<T> IResolverFactory.CreateServiceResolver<T>(T instance)
        {
            var r = new ServiceResolverMock<T>();
            Resolver = r;

            return r;
        }

        IServiceResolver<T> IResolverFactory.CreateServiceResolver<T>(IResolver<T> resolver)
        {
            var r = new ServiceResolverMock<T>();
            Resolver = r;

            return r;
        }
    }
}