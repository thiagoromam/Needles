using Needles.Resolvers.LazyResolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class ParametrizedLazyResolverTest
    {
        [Test]
        public void ResolveTest()
        {
            var argumentsResolver = new ArgumentsResolverMock(new Connection());
            var resolver = new ParametrizedLazyResolver<Database>(argumentsResolver);

            var obj = resolver.Resolve(1, 2);

            Assert.IsNotNull(obj);
            Assert.AreEqual(argumentsResolver.Args[0], obj.Connection);
            Assert.AreEqual(new object[] { 1, 2 }, argumentsResolver.InformedArgs);
        }
    }
}