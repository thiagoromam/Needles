using Needles.Parameters;

namespace Needles.Resolvers.LazyResolvers
{
    internal class LazyResolver<T> : IResolver<T>
    {
        private readonly IResolver<T> _resovler;
        private readonly ManualParametersValidation<T> _argumentsValidation;

        public LazyResolver(IContainer container)
        {
            var parameters = new ParameterCollection<T>(container);
            _argumentsValidation = new ManualParametersValidation<T>(parameters);

            if (parameters.Count > 0)
                _resovler = new ParametrizedLazyResolver<T>(parameters);
            else
                _resovler = new SimpleLazyResolver<T>();
        }

        public T Resolve(params object[] args)
        {
            _argumentsValidation.Validate(args);

            return _resovler.Resolve(args);
        }
    }
}