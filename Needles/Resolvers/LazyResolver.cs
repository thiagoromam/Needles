using System;
using Needles.Parameters;

namespace Needles.Resolvers
{
    internal class LazyResolver<T> : IResolver<T>
    {
        private readonly ParameterCollection<T> _parameters;

        public LazyResolver(IContainer container)
        {
            _parameters = new ParameterCollection<T>(container);
        }

        public T Resolve()
        {
            if (_parameters.Count == 0)
                return (T)Activator.CreateInstance(typeof(T));

            return Resolve(null);
        }

        public T Resolve(object[] args)
        {
            var informedArgsIndex = 0;
            var informedArgs = args ?? new object[0];
            args = new object[_parameters.Count];

            for (var i = 0; i < _parameters.Count; i++)
            {
                var parameter = _parameters[i];

                args[i] = parameter.Manual
                    ? informedArgs[informedArgsIndex++]
                    : parameter.Resolve();
            }

            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}