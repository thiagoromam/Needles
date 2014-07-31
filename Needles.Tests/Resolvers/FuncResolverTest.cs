using Needles.Resolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class FuncResolverTest
    {
        [Test]
        public void ResolveInstanceTest()
        {
            var resolver = new FuncResolver<Connection>(new ContainerMock(), c => new Connection());

            var instance = resolver.Resolve();

            Assert.IsNotNull(instance);
        }
    }
}