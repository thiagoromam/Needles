using System;
using Needles.Exceptions;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests
{
    public class ContainerTest
    {
        private ResolverFactoryMock _resolverFactory;
        private MapperFactoryMock _mapperFactory;

        [SetUp]
        public void Setup()
        {
            _resolverFactory = new ResolverFactoryMock();
            _mapperFactory = new MapperFactoryMock();
        }

        [Test]
        public void CreateTest()
        {
            var container = new Container(_mapperFactory, _resolverFactory);

            Assert.AreEqual(_resolverFactory.Container, container);
        }

        [Test]
        public void MapTest()
        {
            var container = new Container(_mapperFactory, _resolverFactory);

            var mapper1 = container.Map<Connection>();
            var mapper2 = container.Map<Connection>();

            Assert.AreEqual(mapper1, _mapperFactory.Mapper);
            Assert.AreEqual(mapper1, mapper2);
        }

        [Test]
        public void ResolveTest()
        {
            var container = new Container(_mapperFactory, _resolverFactory);

            var mapper = (MapperMock<IConnection>)container.Map<IConnection>();
            mapper.Instance = new Connection();

            var instance = container.Resolve<IConnection>();

            Assert.AreEqual(instance, mapper.Instance);
        }

        [TestCase(typeof(IConnection))]
        [TestCase(typeof(Connection), ExpectedException = typeof(TypeNotMappedException))]
        public void ResolveByTypeTest(Type type)
        {
            var container = new Container(_mapperFactory, _resolverFactory);

            var mapper = (MapperMock<IConnection>)container.Map<IConnection>();
            mapper.Instance = new Connection();

            var instance = container.Resolve(type);

            Assert.AreEqual(instance, mapper.Instance);
        }
    }
}