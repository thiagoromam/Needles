using System;

namespace Needles.Tests.Mocks
{
    public class ContainerMock : IResolverContainer
    {
        public object Instance { get; set; }

        public ContainerMock(object instance = null)
        {
            Instance = instance;
        }

        public object Resolve(Type type, object[] args = null)
        {
            return Instance;
        }

        public T Resolve<T>(object[] args = null)
        {
            return (T)Instance;
        }
    }
}