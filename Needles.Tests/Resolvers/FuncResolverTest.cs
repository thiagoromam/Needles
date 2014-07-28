using Needles.Resolvers;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class FuncResolverTest
    {
        [Test]
        public void ResolveInstanceTest()
        {
            var resolver = new FuncResolver<Connection>(new Container(), c => new Connection());

            var instance = resolver.Resolve();

            Assert.IsNotNull(instance);
        }
    }
}