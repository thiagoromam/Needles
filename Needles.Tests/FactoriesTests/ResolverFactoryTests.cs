using System.Linq;
using Needles.Resolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.FactoriesTests
{
    public class ResolverFactoryTests
    {
        [Test]
        public void ResolverFactoryTest()
        {
            var container = new ContainerMock();
            var factory = NeedlesContainer.CreateResolverFactory();
            factory.Container = container;

            var resolver = factory.CreateAutoServiceResolver<Connection>();

            Assert.IsInstanceOf<ServiceResolver<Connection>>(resolver);
            Assert.AreEqual(container.Mappers.Count, 1);

            var mapper = container.Mappers.First().Value;
            Assert.IsInstanceOf<MapperMock<Connection>>(mapper);
            Assert.IsTrue(((MapperMock<Connection>)mapper).MappedToSelf);
            Assert.IsTrue(((MapperMock<Connection>)mapper).AsService);

            Assert.AreEqual(resolver.Resolve(null), resolver.Resolve(null));
        }
    }
}