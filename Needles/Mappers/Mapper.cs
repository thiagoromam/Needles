using System;
using Needles.Factories;
using Needles.Resolvers;

namespace Needles.Mappers
{
    internal class Mapper<T> : IMapper<T>, IMapping, IMappingResult
    {
        private readonly IResolverFactory _resolverFactory;
        private IResolver<T> _resolver;

        public Mapper(IResolverFactory resolverFactory)
        {
            _resolverFactory = resolverFactory;
        }

        void IMapper<T>.To(T instance)
        {
            _resolver = _resolverFactory.CreateServiceResolver(instance);
        }
        IMappingResult IMapper<T>.To<TInstance>()
        {
            _resolver = (IResolver<T>)_resolverFactory.CreateLazyResolver<TInstance>();
            return this;
        }
        IMappingResult IMapper<T>.ToSelf()
        {
            return ((IMapper<T>)this).To<T>();
        }
        IMappingResult IMapper<T>.To(Func<IResolverContainer, T> factory)
        {
            _resolver = _resolverFactory.CreateFuncResolver(factory);
            return this;
        }

        object IMapping.Resolve(object[] args)
        {
            return _resolver.Resolve(args);
        }

        void IMappingResult.AsService()
        {
            _resolver = _resolverFactory.CreateServiceResolver(_resolver);
        }
    }
}