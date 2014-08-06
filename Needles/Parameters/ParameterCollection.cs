using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Needles.Factories;

namespace Needles.Parameters
{
    internal interface IParameterCollection : IEnumerable<IParameter>
    {
        int Count { get; }
        IParameter this[int index] { get; }
    }

    internal class ParameterCollection<T> : IParameterCollection
    {
        private readonly IParameterFactory _parameterFactory;
        private readonly List<IParameter> _parameters;

        public ParameterCollection(IParameterFactory parameterFactory)
        {
            _parameterFactory = parameterFactory;
            _parameters = GetConstructorParameters();
        }

        public int Count
        {
            get { return _parameters.Count; }
        }
        public IParameter this[int index]
        {
            get { return _parameters[index]; }
        }

        private List<IParameter> GetConstructorParameters()
        {
            IEnumerable<ParameterInfo> parameters = typeof(T).GetConstructors()[0].GetParameters();
            parameters = parameters.OrderBy(p => p.Position);

            return parameters.Select(p => _parameterFactory.Create(p)).ToList();
        }

        public IEnumerator<IParameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}