using Needles.Parameters;

namespace Needles.Factories
{
    internal interface IParameterCollectionFactory
    {
        IParameterCollection Create<T>();
    }

    internal class ParameterCollectionFactory : IParameterCollectionFactory
    {
        private readonly IParameterFactory _parameterFactory;

        public ParameterCollectionFactory(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
        }

        public IParameterCollection Create<T>()
        {
            return new ParameterCollection<T>(_parameterFactory);
        }
    }
}