using System;
using System.Collections.Generic;
using System.Linq;

namespace Needles.Resolvers
{
    internal class LazyResolver<T> : IResolver<T>
    {
        private readonly IContainer _container;
        private readonly Type[] _parameterTypes;

        public LazyResolver(IContainer container)
        {
            _container = container;
            _parameterTypes = GetConstructorParameters().ToArray();
        }

        private static IEnumerable<Type> GetConstructorParameters()
        {
            var constructor = typeof(T).GetConstructors()[0];
            return constructor.GetParameters().Select(p => p.ParameterType);
        }

        public T Resolve()
        {
            if (_parameterTypes.Length == 0)
                return (T)Activator.CreateInstance(typeof(T));

            var parameters = _parameterTypes.Select(p => _container.Resolve(p)).ToArray();
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }
    }
}