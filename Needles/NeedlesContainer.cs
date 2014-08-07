using Needles.Factories;

namespace Needles
{
    public static class NeedlesContainer
    {
        public static IContainer Create()
        {
            var resolverFactory = new ResolverFactory(new ParameterCollectionFactory(new ParameterFactory()));
            var mapperFactory = new MapperFactory(resolverFactory);

            var container = new Container(mapperFactory, resolverFactory);
            container.Map<IResolverContainer>().To(container);
            container.Map<IContainer>().To(container);

            return container;
        }
    }
}