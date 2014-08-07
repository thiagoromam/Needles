using System.Collections;
using Needles.Factories;
using Needles.Parameters;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Parameters
{
    public class ParameterCollectionTest
    {
        [Test]
        public void CreateTest()
        {
            var parameters = new ParameterCollection<Product>(new ParameterFactory());

            Assert.AreEqual(parameters.Count, 4);

            foreach (var parameter in (IEnumerable)parameters)
                Assert.IsNotNull(parameter);

            Assert.AreEqual(parameters[0].Type, typeof(int));
            Assert.AreEqual(parameters[1].Type, typeof(ProductData));
            Assert.AreEqual(parameters[2].Type, typeof(int));
            Assert.AreEqual(parameters[3].Type, typeof(string));

            Assert.IsTrue(parameters[0].Manual);
            Assert.IsFalse(parameters[1].Manual);
            Assert.IsTrue(parameters[2].Manual);
            Assert.IsTrue(parameters[3].Manual);
        }
    }
}