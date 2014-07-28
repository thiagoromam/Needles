using System;
using System.Collections.Generic;
using Needles.Mappers;

namespace Needles
{
    public interface IContainer
    {
        object Resolve(Type type);
        T Resolve<T>();
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

        public T Resolve<T>()
        {
            return ((IMapping<T>)_mappers[typeof(T)]).Resolve();
        }

        public object Resolve(Type type)
        {
            return ((IMapping)_mappers[type]).Resolve();
        }
    }
}