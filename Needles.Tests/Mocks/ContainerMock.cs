using System;
using System.Collections.Generic;
using Needles.Mappers;

namespace Needles.Tests.Mocks
{
    public class ContainerMock : IContainer
    {
        public object Instance { get; set; }
        public readonly Dictionary<Type, IMapper> Mappers;

        public ContainerMock(object instance = null)
        {
            Instance = instance;
            Mappers = new Dictionary<Type, IMapper>();
        }

        public object Resolve(Type type, object[] args = null)
        {
            return Instance;
        }

        public T Resolve<T>(object[] args = null)
        {
            return (T)Instance;
        }

        public IMapper<T> Map<T>()
        {
            return (IMapper<T>)(Mappers[typeof(T)] = new MapperMock<T>());
        }

        public bool IsMapped<T>()
        {
            return Mappers.ContainsKey(typeof(T));
        }
    }
}