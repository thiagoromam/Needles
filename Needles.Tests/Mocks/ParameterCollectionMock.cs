using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Needles.Parameters;

namespace Needles.Tests.Mocks
{
    internal class ParameterCollectionMock : IParameterCollection
    {
        public ParameterCollectionMock(params IParameter[] parameter)
        {
            if (parameter != null)
                Parameters = parameter.ToList();
        }

        public List<IParameter> Parameters { get; set; }
        int IParameterCollection.Count
        {
            get { return Parameters.Count; }
        }
        IParameter IParameterCollection.this[int index]
        {
            get { return Parameters[index]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IParameter>)this).GetEnumerator();
        }
        IEnumerator<IParameter> IEnumerable<IParameter>.GetEnumerator()
        {
            return Parameters.GetEnumerator();
        }
    }
}