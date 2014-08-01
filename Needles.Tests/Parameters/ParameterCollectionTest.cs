using Needles.Parameters;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Parameters
{
    public class ParameterCollectionTest
    {
        [Test]
        public void CreateTest()
        {
            var parameters = new ParameterCollection<Product>(new ContainerMock());

            Assert.AreEqual(parameters.Count, 4);
            Assert.AreEqual(parameters[0].Type, typeof(int));
            Assert.AreEqual(parameters[1].Type, typeof(ProductData));
            Assert.AreEqual(parameters[2].Type, typeof(int));
            Assert.AreEqual(parameters[3].Type, typeof(string));
        }
    }
}