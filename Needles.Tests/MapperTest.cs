using System;
using Needles.Mappers;
using Needles.Resolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests
{
    public class MapperTest
    {
        private ResolverFactoryMock _factory;
        private IMapper<IConnection> _mapper;

        [SetUp]
        public void Setup()
        {
            _factory = new ResolverFactoryMock();
            _mapper = new Mapper<IConnection>(_factory);
        }

        [Test]
        public void MapToInstanceTest()
        {
            var connection = new Connection();
            _mapper.To(connection);

            Assert.IsInstanceOf<ServiceResolverMock<IConnection>>(_factory.Resolver);
        }

        [Test]
        public void MapToFunctionTest()
        {
            _mapper.To((Func<IResolverContainer, IConnection>)null);

            Assert.IsInstanceOf<FuncResolverMock<IConnection>>(_factory.Resolver);
        }

        [Test]
        public void MapToTypeTest()
        {
            _mapper.To<Connection>();

            Assert.IsInstanceOf<LazyResolverMock<Connection>>(_factory.Resolver);
        }

        [Test]
        public void MapToSelfTest()
        {
            IMapper<Connection> mapper = new Mapper<Connection>(_factory);
            mapper.ToSelf();

            Assert.IsInstanceOf<LazyResolverMock<Connection>>(_factory.Resolver);
        }

        [Test]
        public void MapToAutoServiceTest()
        {
            IMapper<IConnection> mapper = new Mapper<IConnection>(_factory);
            mapper.ToService<Connection>();

            Assert.IsInstanceOf<IServiceResolver<Connection>>(_factory.Resolver);
        }

        [Test]
        public void MapServiceTest()
        {
            var result = _mapper.To<Connection>();

            Assert.IsInstanceOf<LazyResolverMock<Connection>>(_factory.Resolver);

            result.AsService();

            Assert.IsInstanceOf<ServiceResolverMock<IConnection>>(_factory.Resolver);
        }
        
        [Test]
        public void ResolveTest()
        {
            _mapper.To<Connection>().AsService();
            _factory.Resolver.Instance = new Connection();

            var instance = ((IMapping)_mapper).Resolve();

            Assert.AreEqual(instance, _factory.Resolver.Instance);
        }
    }
}