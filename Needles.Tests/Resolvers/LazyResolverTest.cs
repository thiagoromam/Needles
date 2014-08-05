﻿using System;
using Needles.Exceptions.ResolveExceptions;
using Needles.Resolvers.LazyResolvers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests.Resolvers
{
    public class LazyResolverTest
    {
        private LazyResolver<Connection> _connectionResolver;
        private ContainerMock _container;

        [SetUp]
        public void Setup()
        {
            _container = new ContainerMock();
            _connectionResolver = new LazyResolver<Connection>(_container);
        }

        [TestCase(typeof(Connection), null)]
        [TestCase(typeof(Connection), 1, ExpectedException = typeof(ResolveWithParametersException))]
        public void ResolveInstanceTest(Type type, int? arg)
        {
            var instance = _connectionResolver.Resolve(arg.HasValue ? new object[] { arg.Value } : null);

            Assert.IsInstanceOf(type, instance);
        }

        [Test]
        public void ResolveMoreThanOneInstanceTest()
        {
            var instance1 = _connectionResolver.Resolve();
            var instance2 = _connectionResolver.Resolve();

            Assert.AreNotEqual(instance1, instance2);
        }

        [Test]
        public void ResolveLoopTest()
        {
            _container.Instance = new Connection();
            var resolver = new LazyResolver<Database>(_container);

            var instance = resolver.Resolve();

            Assert.IsNotNull(instance);
        }

        [TestCase(1, 2, "test")]
        [TestCase(1, 2, ExpectedException = typeof(ResolveWithLessParametersException))]
        [TestCase(1, 2, "test", 4, ExpectedException = typeof(ResolveWithMoreParametersException))]
        [TestCase(1, "test", 2, ExpectedException = typeof(ResolveWithInvalidParametersSequenceException))]
        [TestCase(ExpectedException = typeof(ResolveWithoutParametersException))]
        public void ResolveWithArgsTest(params object[] args)
        {
            _container.Instance = new ProductData();
            var resolver = new LazyResolver<Product>(_container);

            var product = resolver.Resolve(args);

            Assert.AreEqual(product.Number, 1);
            Assert.AreEqual(product.Data, _container.Instance);
            Assert.AreEqual(product.Number2, 2);
            Assert.AreEqual(product.Name, "test");
        }

        [TestCase(typeof(Geolocator), typeof(GlobalMap))]
        [TestCase(typeof(GeolocatorLocal), typeof(LocalMap))]
        [TestCase(typeof(GeolocatorLocal), typeof(Connection), ExpectedException = typeof(ResolveWithInvalidParametersSequenceException))]
        public void ResolveWithArgsTest2(Type type1, Type type2)
        {
            var resolver = new LazyResolver<Location>(new ContainerMock());
            
            var instance = resolver.Resolve(Activator.CreateInstance(type1), Activator.CreateInstance(type2));

            Assert.IsNotNull(instance);
        }
    }
}