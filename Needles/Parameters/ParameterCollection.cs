using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Needles.Parameters
{
    public class ParameterCollection<T>
    {
        private readonly IContainer _container;
        private readonly Parameter[] _parameters;

        public ParameterCollection(IContainer container)
        {
            _container = container;
            _parameters = GetConstructorParameters();
        }

        public int Count
        {
            get { return _parameters.Length; }
        }
        public Parameter this[int index]
        {
            get { return _parameters[index]; }
        }

        private Parameter[] GetConstructorParameters()
        {
            IEnumerable<ParameterInfo> parameters = typeof(T).GetConstructors()[0].GetParameters();
            parameters = parameters.OrderBy(p => p.Position);

            return parameters.Select(p => new Parameter(p, _container)).ToArray();
        }
    }
}