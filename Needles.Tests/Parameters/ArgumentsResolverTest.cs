using Needles.Parameters;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Parameters
{
    public class ArgumentsResolverTest
    {
        [Test]
        public void ValidationTest()
        {
            var validation = new ArgumentsValidationMock();
            var resolver = new ArgumentsResolver(new ParameterCollectionMock(), validation, new ContainerMock());

            resolver.Resolve();
            resolver.Resolve();

            Assert.AreEqual(validation.ValidateCallsCount, 2);
        }

        [Test]
        public void ResolveTest()
        {
            var container = new ContainerMock(new ProductData());

            var parameters = new ParameterCollectionMock(
                new ParameterMock(typeof(int), true),
                new ParameterMock(typeof(ProductData)),
                new ParameterMock(typeof(string), true)
            );

            var resolver = new ArgumentsResolver(parameters, new ArgumentsValidationMock(), container);

            var args = resolver.Resolve(1, "test");

            Assert.AreEqual(args.Length, 3);
            Assert.AreEqual(args[0], 1);
            Assert.AreEqual(args[1], container.Instance);
            Assert.AreEqual(args[2], "test");
        }
    }
}