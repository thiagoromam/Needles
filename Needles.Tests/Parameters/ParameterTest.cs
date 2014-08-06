using System;
using Needles.Parameters;
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

            var parameter = new Parameter(info);

            Assert.AreEqual(parameter.Type, type);
            Assert.AreEqual(parameter.Manual, manual);
        }
    }
}