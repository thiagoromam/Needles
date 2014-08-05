using System;
using Needles.Resolvers;
using Needles.Resolvers.LazyResolvers;

namespace Needles.Mappers
{
    internal class Mapper<T> : IMapper<T>, IMapping, IMappingResult
    {
        private readonly IContainer _container;
        private IResolver<T> _resolver;

        public Mapper(IContainer container)
        {
            _container = container;
        }

        void IMapper<T>.To(T instance)
        {
            _resolver = new ServiceResolver<T>(instance);
        }
        IMappingResult IMapper<T>.To<TInstance>()
        {
            _resolver = (IResolver<T>)new LazyResolver<TInstance>(_container);
            return this;
        }
        IMappingResult IMapper<T>.ToSelf()
        {
            return ((IMapper<T>)this).To<T>();
        }
        IMappingResult IMapper<T>.To(Func<IContainer, T> factory)
        {
            _resolver = new FuncResolver<T>(_container, factory);
            return this;
        }

        object IMapping.Resolve(object[] args)
        {
            return _resolver.Resolve(args);
        }

        void IMappingResult.AsService()
        {
            _resolver = new ServiceResolver<T>(_resolver);
        }
    }
}