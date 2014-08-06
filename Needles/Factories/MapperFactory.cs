using Needles.Mappers;

namespace Needles.Factories
{
    internal interface IMapperFactory
    {
        IMapper<T> Create<T>();
    }

    internal class MapperFactory : IMapperFactory
    {
        private readonly IResolverFactory _resolverFactory;

        public MapperFactory(IResolverFactory resolverFactory)
        {
            _resolverFactory = resolverFactory;
        }

        public IMapper<T> Create<T>()
        {
            return new Mapper<T>(_resolverFactory);
        }
    }
}