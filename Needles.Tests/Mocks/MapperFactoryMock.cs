using Needles.Factories;
using Needles.Mappers;

namespace Needles.Tests.Mocks
{
    public class MapperFactoryMock : IMapperFactory
    {
        public object Mapper { get; private set; }

        public IMapper<T> Create<T>()
        {
            var m = new MapperMock<T>();
            Mapper = m;

            return m;
        }
    }
}