using System;
using System.Collections.Generic;
using Needles.Mappers;

namespace Needles
{
    public interface IContainer
    {
        object Resolve(Type type, params object[] args);
        T Resolve<T>(params object[] args);
    }

    public class Container : IContainer
    {
        private readonly Dictionary<Type, IMapper> _mappers;

        public Container()
        {
            _mappers = new Dictionary<Type, IMapper>();
        }

        public IMapper<T> Map<T>()
        {
            var type = typeof(T);

            if (!_mappers.ContainsKey(type))
                _mappers[type] = new Mapper<T>(this);

            return (IMapper<T>)_mappers[type];
        }

        public T Resolve<T>(params object[] args)
        {
            return ((IMapping<T>)_mappers[typeof(T)]).Resolve(args);
        }

        public object Resolve(Type type, params object[] args)
        {
            return ((IMapping)_mappers[type]).Resolve(args);
        }
    }
}