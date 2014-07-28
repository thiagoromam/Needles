using Needles.Resolvers;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class LazyResolverTest
    {
        private Container _container;
        private LazyResolver<Connection> _resolver;

        [SetUp]
        public void Setup()
        {
            _container = new Container();
            _resolver = new LazyResolver<Connection>(_container);
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
            var container = new Container();
            container.Map<IConnection>().To<Connection>();
            container.Map<IDatabase>().To<Database>();

            var instance = container.Resolve<IDatabase>();

            Assert.IsNotNull(instance);
        }
    }
}