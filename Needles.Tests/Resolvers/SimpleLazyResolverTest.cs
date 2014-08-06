using Needles.Exceptions.ResolveExceptions;
using Needles.Resolvers.LazyResolvers;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class SimpleLazyResolverTest
    {
        private SimpleLazyResolver<Connection> _resolver;
        
        [SetUp]
        public void Setup()
        {
            _resolver = new SimpleLazyResolver<Connection>();
        }

        [TestCase]
        [TestCase(1, 2, ExpectedException = typeof(ResolveWithParametersException))]
        public void ResolveTest(params object[] args)
        {
            Assert.IsNotNull(_resolver.Resolve(args));
        }

        [Test]
        public void ResolveTwoTimesTest()
        {
            var obj1 = _resolver.Resolve();
            var obj2 = _resolver.Resolve();

            Assert.AreNotEqual(obj1, obj2);
        }
    }
}