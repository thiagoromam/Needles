using System.Collections.Generic;
using Needles.Helpers;
using NUnit.Framework;

namespace Needles.Tests.Helpers
{
    public class EnumerableHelperTest
    {
        [Test]
        public void NullTest()
        {
            IEnumerable<int> source = null;

            Assert.IsTrue(source.IsNullOrEmpty());
        }

        [Test]
        public void EmptyTest()
        {
            IEnumerable<int> source = new int[0];

            Assert.IsTrue(source.IsNullOrEmpty());
        }

        [Test]
        public void NotNullOrEmptyTest()
        {
            IEnumerable<int> source = new[] {1};

            Assert.IsFalse(source.IsNullOrEmpty());
        }
    }
}