using Needles.Resolvers;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class ServiceResolverTest
    {
        [Test]
        public void ResolveInstanceTest()
        {
            var connection = new Connection();

            var resolver = new ServiceResolver<Connection>(connection);

            var instance = resolver.Resolve();

            Assert.AreEqual(instance, connection);
        }

        [Test]
        public void ResolveInstanceTwoTimesTest()
        {
            var resolver = new ServiceResolver<Connection>(new Connection());

            var instance1 = resolver.Resolve();
            var instance2 = resolver.Resolve();

            Assert.AreEqual(instance1, instance2);
        }

        [Test]
        public void ResolveLazyInstanceTwoTimesTest()
        {
            var resolver = new ServiceResolver<Connection>(new ServiceResolver<Connection>(new Connection()));

            var instance1 = resolver.Resolve();
            var instance2 = resolver.Resolve();

            Assert.AreEqual(instance1, instance2);
        }
    }
}