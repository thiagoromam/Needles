using System;
using System.Reflection;
using Needles.Attributes;

namespace Needles.Parameters
{
    internal interface IParameter
    {
        Type Type { get; }
        bool Manual { get; }
    }

    internal class Parameter : IParameter
    {
        public Parameter(ParameterInfo info)
        {
            Type = info.ParameterType;
            Manual = info.IsDefined(typeof(ManualAttribute), false);
        }

        public Type Type { get; private set; }
        public bool Manual { get; private set; }
    }
}