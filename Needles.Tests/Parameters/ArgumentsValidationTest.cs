using System;
using Needles.Exceptions.ResolveExceptions;
using Needles.Parameters;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Parameters
{
    public class ArgumentsValidationTest
    {
        private ParameterCollectionMock _parameters;

        [SetUp]
        public void Setup()
        {
            _parameters = new ParameterCollectionMock();
        }

        [TestCase(false)]
        [TestCase(true, ExpectedException = typeof(ResolveWithoutParametersException))]
        public void ValidateWithoutParametersTest(bool manual)
        {
            _parameters.Parameters.Clear();
            _parameters.Parameters.Add(new ParameterMock(typeof(int), manual));

            ValidateTest();
        }

        [TestCase(true)]
        [TestCase(false, ExpectedException = typeof(ResolveWithParametersException))]
        public void ValidateWithParametersTest(bool manual)
        {
            _parameters.Parameters.Clear();
            _parameters.Parameters.Add(new ParameterMock(typeof(int), manual));

            ValidateTest(1);
        }

        [TestCase(1, 2, ExpectedException = typeof(ResolveWithLessParametersException))]
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, ExpectedException = typeof(ResolveWithMoreParametersException))]
        public void ValidateParametersCountTest(params object[] args)
        {
            _parameters.Parameters.Clear();
            _parameters.Parameters.Add(new ParameterMock(typeof(int), true));
            _parameters.Parameters.Add(new ParameterMock(typeof(int), true));
            _parameters.Parameters.Add(new ParameterMock(typeof(int), true));

            ValidateTest(args);
        }

        [TestCase(1, 2, 3, ExpectedException = typeof(ResolveWithInvalidParametersSequenceException))]
        [TestCase(1, "", 2)]
        public void ValidateParametersSequenceTest(params object[] args)
        {
            _parameters.Parameters.Clear();
            _parameters.Parameters.Add(new ParameterMock(typeof(int), true));
            _parameters.Parameters.Add(new ParameterMock(typeof(string), true));
            _parameters.Parameters.Add(new ParameterMock(typeof(ProductData)));
            _parameters.Parameters.Add(new ParameterMock(typeof(int), true));

            ValidateTest(args);
        }

        [TestCase(typeof(Geolocator), typeof(GlobalMap))]
        [TestCase(typeof(GeolocatorLocal), typeof(LocalMap))]
        [TestCase(typeof(GeolocatorLocal), typeof(Connection), ExpectedException = typeof(ResolveWithInvalidParametersSequenceException))]
        public void ValidateInheritanceParametersTest(Type type1, Type type2)
        {
            _parameters.Parameters.Clear();
            _parameters.Parameters.Add(new ParameterMock(type1, true));
            _parameters.Parameters.Add(new ParameterMock(type2, true));

            ValidateTest(Activator.CreateInstance(type1), Activator.CreateInstance(type2));
        }

        private void ValidateTest(params object[] args)
        {
            var validation = new ArgumentsValidation(_parameters);

            validation.Validate(args);

            Assert.Pass();
        }
    }
}