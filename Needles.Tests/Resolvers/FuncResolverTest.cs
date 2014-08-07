using Needles.Exceptions.ResolveExceptions;
using Needles.Resolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class FuncResolverTest
    {
        [TestCase]
        [TestCase(1, 2, ExpectedException = typeof(ResolveWithArgumentsException))]
        public void ResolveInstanceTest(params object[] args)
        {
            var resolver = new FuncResolver<Connection>(new ContainerMock(), c => new Connection());

            var instance = resolver.Resolve(args);

            Assert.IsNotNull(instance);
        }
    }
}