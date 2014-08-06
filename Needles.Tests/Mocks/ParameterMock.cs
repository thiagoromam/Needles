using System;
using Needles.Parameters;

namespace Needles.Tests.Mocks
{
    public class ParameterMock : IParameter
    {
        public ParameterMock(Type type, bool manual = false)
        {
            Type = type;
            Manual = manual;
        }

        public Type Type { get; set; }
        public bool Manual { get; set; }
    }
}