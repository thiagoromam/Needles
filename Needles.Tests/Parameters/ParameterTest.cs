using System;
using Needles.Parameters;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Parameters
{
    public class ParameterTest
    {

        [TestCase(0, typeof(int), true)]
        [TestCase(1, typeof(ProductData), false)]
        [TestCase(2, typeof(int), true)]
        [TestCase(3, typeof(string), true)]
        public void CreateTest(int parameterIndex, Type type, bool manual)
        {
            var info = typeof(Product).GetConstructors()[0].GetParameters()[parameterIndex];

            var parameter = new Parameter(info, new ContainerMock());

            Assert.AreEqual(parameter.Type, type);
            Assert.AreEqual(parameter.Manual, manual);
        }

        [Test]
        public void ResolveTest()
        {
            var info = typeof(Database).GetConstructors()[0].GetParameters()[0];

            var container = new ContainerMock(new Connection());
            var parameter = new Parameter(info, container);

            var instance = parameter.Resolve();

            Assert.AreEqual(instance, container.Instance);
        }
    }
}