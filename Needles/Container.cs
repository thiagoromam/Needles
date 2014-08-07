using System;
using System.Collections.Generic;
using Needles.Exceptions;
using Needles.Factories;
using Needles.Mappers;

namespace Needles
{
    public interface IResolverContainer
    {
        object Resolve(Type type, params object[] args);
        T Resolve<T>(params object[] args);
    }

    public interface IContainer : IResolverContainer
    {
        IMapper<T> Map<T>();
    }

    internal class Container : IContainer
    {
        private readonly IMapperFactory _mapperFactory;
        private readonly Dictionary<Type, IMapper> _mappers;

        internal Container(IMapperFactory mapperFactory, IResolverFactoryInitializer resolverFactory)
        {
            _mapperFactory = mapperFactory;
            _mappers = new Dictionary<Type, IMapper>();
            resolverFactory.Container = this;
        }

        public IMapper<T> Map<T>()
        {
            var type = typeof(T);

            if (!_mappers.ContainsKey(type))
                _mappers[type] = _mapperFactory.Create<T>();

            return (IMapper<T>)_mappers[type];
        }

        public T Resolve<T>(params object[] args)
        {
            return (T)Resolve(typeof(T), args);
        }

        public object Resolve(Type type, params object[] args)
        {
            if (!_mappers.ContainsKey(type))
                throw new TypeNotMappedException(type);

            return ((IMapping)_mappers[type]).Resolve(args);
        }
    }
}