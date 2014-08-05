using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Needles.Parameters
{
    internal class ParameterCollection<T> : IEnumerable<Parameter>
    {
        private readonly IContainer _container;
        private readonly List<Parameter> _parameters;

        public ParameterCollection(IContainer container)
        {
            _container = container;
            _parameters = GetConstructorParameters();
        }

        public int Count
        {
            get { return _parameters.Count; }
        }
        public Parameter this[int index]
        {
            get { return _parameters[index]; }
        }

        private List<Parameter> GetConstructorParameters()
        {
            IEnumerable<ParameterInfo> parameters = typeof(T).GetConstructors()[0].GetParameters();
            parameters = parameters.OrderBy(p => p.Position);

            return parameters.Select(p => new Parameter(p, _container)).ToList();
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}