using Needles.Parameters;

namespace Needles.Resolvers.LazyResolvers
{
    internal class LazyResolver<T> : IResolver<T>
    {
        private readonly IResolver<T> _resovler;

        public LazyResolver(IContainer container)
        {
            var parameters = new ParameterCollection<T>(container);

            if (parameters.Count > 0)
                _resovler = new ParametrizedLazyResolver<T>(parameters);
            else
                _resovler = new SimpleLazyResolver<T>();
        }

        public T Resolve(object[] args)
        {
            return _resovler.Resolve(args);
        }
    }
}