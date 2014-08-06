﻿//using System;
//using Needles.Exceptions;
//using Needles.Tests.Types;
//using NUnit.Framework;

//namespace Needles.Tests
//{
//    public class ContainerTest
//    {
//        [Test]
//        public void MapTest()
//        {
//            var connection = new Connection();

//            var container = new Container();
//            container.Map<IConnection>().To(connection);

//            var instance = container.Resolve<IConnection>();

//            Assert.AreEqual(instance, connection);
//        }

//        [Test]
//        public void MapTwoTimesTest()
//        {
//            var container = new Container();
//            container.Map<IConnection>().To<Connection>().AsService();

//            var instance1 = container.Resolve<IConnection>();

//            container.Map<IConnection>().To<Connection>().AsService();

//            var instance2 = container.Resolve<IConnection>();

//            Assert.AreNotEqual(instance1, instance2);
//        }

//        [TestCase(typeof(IConnection))]
//        [TestCase(typeof(IDatabase), ExpectedException = typeof(TypeNotMappedException))]
//        public void ResolveByTypeTest(Type type)
//        {
//            var container = new Container();
//            container.Map<IConnection>().To<Connection>().AsService();

//            var instance = container.Resolve(type);

//            Assert.IsInstanceOf(type, instance);
//        }
//    }
//}