namespace Needles.Resolvers
{
    internal class ServiceResolver<T> : IResolver<T>
    {
        private T _instance;
        private bool _instanceCreated;
        private readonly IResolver<T> _resolver;

        public ServiceResolver(T instance)
        {
            _instance = instance;
            _instanceCreated = true;
        }
        public ServiceResolver(IResolver<T> resolver)
        {
            _resolver = resolver;
        }

        public T Resolve(params object[] args)
        {
            if (!_instanceCreated)
            {
                _instance = _resolver.Resolve(args);
                _instanceCreated = true;
            }

            return _instance;
        }
    }
}