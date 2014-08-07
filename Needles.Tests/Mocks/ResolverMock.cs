using Needles.Resolvers;
using Needles.Resolvers.LazyResolvers;

namespace Needles.Tests.Mocks
{
    public interface IResolverMock
    {
        object Instance { get; set; }
    }

    public class ResolverMock<T> : IResolver<T>, IResolverMock
    {
        public object Instance { get; set; }

        T IResolver<T>.Resolve(params object[] args)
        {
            return (T)Instance;
        }
    }

    public class FuncResolverMock<T> : ResolverMock<T>, IFuncResolver<T> { }
    public class LazyResolverMock<T> : ResolverMock<T>, ILazyResolver<T> { }
    internal class ServiceResolverMock<T> : ResolverMock<T>, IServiceResolver<T> { }
}