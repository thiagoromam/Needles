using System;

namespace Needles.Mappers
{
    public interface IMapper { }

    public interface IMapper<in T> : IMapper
    {
        void To(T instance);
        IMappingResult To<TInstance>() where TInstance : T;
        IMappingResult ToSelf();
        IMappingResult To(Func<IResolverContainer, T> factory);
        void ToService<TService>() where TService : T;
    }
}