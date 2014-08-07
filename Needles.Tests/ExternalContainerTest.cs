using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests
{
    public class ExternalContainerTest
    {
        [Test]
        public void ResolveItSelfTest()
        {
            var container = NeedlesContainer.Create();

            var instance1 = container.Resolve<IResolverContainer>();
            var instance2 = container.Resolve<IContainer>();

            Assert.AreEqual(container, instance1);
            Assert.AreEqual(container, instance2);
        }

        [Test]
        public void MapTwoTimesTest()
        {
            var container = NeedlesContainer.Create();

            container.Map<IConnection>().To(c => new Connection()).AsService();
            var instance1 = container.Resolve<IConnection>();

            container.Map<IConnection>().To<Connection>().AsService();
            var instance2 = container.Resolve<IConnection>();

            Assert.AreNotEqual(instance1, instance2);
        }

        [Test]
        public void ResolveWithArgsTest()
        {
            var container = NeedlesContainer.Create();

            container.Map<Location>().ToSelf();
            var instance = container.Resolve<Location>(new GeolocatorLocal(), new GlobalMap());

            Assert.IsNotNull(instance);
        }
    }
}