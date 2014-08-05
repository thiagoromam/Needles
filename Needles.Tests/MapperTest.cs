﻿using Needles.Mappers;
using Needles.Tests.Mocks;
using Needles.Tests.Types;
using NUnit.Framework;

namespace Needles.Tests
{
    public class MapperTest
    {
        [Test]
        public void MapToInstanceTest()
        {
            var connection = new Connection();

            IMapper<Connection> mapper = new Mapper<Connection>(new ContainerMock());
            mapper.To(connection);

            var instance = ((IMapping<Connection>)mapper).Resolve();

            Assert.AreEqual(instance, connection);
        }

        [Test]
        public void MapToFunctionTest()
        {
            IMapper<Connection> mapper = new Mapper<Connection>(new ContainerMock());
            mapper.To(c => new Connection());

            var instance = ((IMapping<Connection>)mapper).Resolve();

            Assert.IsNotNull(instance);
        }

        [Test]
        public void MapServiceTest()
        {
            IMapper<IConnection> mapper = new Mapper<IConnection>(new ContainerMock());
            mapper.To<Connection>().AsService();

            var instance1 = ((IMapping<IConnection>)mapper).Resolve();
            var instance2 = ((IMapping<IConnection>)mapper).Resolve();

            Assert.AreEqual(instance1, instance2);
        }

        [Test]
        public void MapToSelfTest()
        {
            IMapper<Connection> mapper = new Mapper<Connection>(new ContainerMock());
            mapper.ToSelf();

            var instance1 = ((IMapping<Connection>)mapper).Resolve();
            var instance2 = ((IMapping<Connection>)mapper).Resolve();

            Assert.AreNotEqual(instance1, instance2);
        }
    }
}