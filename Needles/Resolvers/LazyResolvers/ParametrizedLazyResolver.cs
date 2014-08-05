using System;
using Needles.Parameters;

namespace Needles.Resolvers.LazyResolvers
{
    internal class ParametrizedLazyResolver<T> : IResolver<T>
    {
        private readonly ParameterCollection<T> _parameters;

        public ParametrizedLazyResolver(ParameterCollection<T> parameters)
        {
            _parameters = parameters;
        }

        public T Resolve(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), ResolveArguments(args));
        }
        
        private object[] ResolveArguments(object[] informedArgs)
        {
            var informedArgsIndex = 0;
            var args = new object[_parameters.Count];

            for (var i = 0; i < _parameters.Count; i++)
            {
                var parameter = _parameters[i];

                args[i] = parameter.Manual
                    ? informedArgs[informedArgsIndex++]
                    : parameter.Resolve();
            }

            return args;
        }
    }
}