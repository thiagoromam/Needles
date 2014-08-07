using System;
using Needles.Mappers;

namespace Needles.Tests.Mocks
{
    public class MapperMock<T> : IMapper<T>, IMapping, IMappingResult
    {
        public object Instance { get; set; }

        void IMapper<T>.To(T instance)
        {
        }

        IMappingResult IMapper<T>.To<TInstance>()
        {
            return this;
        }

        IMappingResult IMapper<T>.ToSelf()
        {
            return this;
        }

        IMappingResult IMapper<T>.To(Func<IResolverContainer, T> factory)
        {
            return this;
        }

        object IMapping.Resolve(params object[] args)
        {
            return Instance;
        }

        void IMappingResult.AsService()
        {
        }
    }
}