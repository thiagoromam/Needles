using Needles.Resolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class LazyResolverTest
    {
        private LazyResolver<Connection> _resolver;

        [SetUp]
        public void Setup()
        {
            _resolver = new LazyResolver<Connection>(new ContainerMock());
        }

        [Test]
        public void ResolveInstanceTest()
        {
            var instance = _resolver.Resolve();

            Assert.AreEqual(instance.GetType(), typeof(Connection));
        }

        [Test]
        public void ResolveMoreThanOneInstanceTest()
        {
            var instance1 = _resolver.Resolve();
            var instance2 = _resolver.Resolve();

            Assert.AreNotEqual(instance1, instance2);
        }

        [Test]
        public void ResolveLoopTest()
        {
            var container = new ContainerMock(new Connection());
            var resolver = new LazyResolver<Database>(container);

            var instance = resolver.Resolve();

            Assert.IsNotNull(instance);
        }

        [Test]
        public void ResolveWithArgsTest()
        {
            var container = new ContainerMock(new ProductData());
            var resolver = new LazyResolver<Product>(container);

            var product = resolver.Resolve(new object[] { 1, 2, "test" });

            Assert.AreEqual(product.Number, 1);
            Assert.AreEqual(product.Data, container.Instance);
            Assert.AreEqual(product.Number2, 2);
            Assert.AreEqual(product.Name, "test");
        }
    }
}