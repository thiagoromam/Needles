using System;

namespace Needles.Tests.Mocks
{
    public class ContainerMock : IContainer
    {
        public object Instance { get; set; }

        public ContainerMock(object instance = null)
        {
            Instance = instance;
        }

        public object Resolve(Type type)
        {
            return Instance;
        }

        public T Resolve<T>()
        {
            return (T)Instance;
        }
    }
}