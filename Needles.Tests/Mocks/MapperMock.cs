using System;
using Needles.Mappers;

namespace Needles.Tests.Mocks
{
    public class MapperMock<T> : IMapper<T>, IMapping, IMappingResult
    {
        public object Instance { get; set; }
        public bool AsService { get; set; }
        public bool MappedToSelf { get; set; }

        void IMapper<T>.To(T instance)
        {
        }
        IMappingResult IMapper<T>.To<TInstance>()
        {
            return this;
        }
        IMappingResult IMapper<T>.ToSelf()
        {
            MappedToSelf = true;
            return this;
        }

        IMappingResult IMapper<T>.To(Func<IResolverContainer, T> factory)
        {
            return this;
        }
        void IMapper<T>.ToService<TService>()
        {
        }

        object IMapping.Resolve(params object[] args)
        {
            return Instance;
        }

        void IMappingResult.AsService()
        {
            AsService = true;
        }
    }
}