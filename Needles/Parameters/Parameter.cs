using System;
using System.Reflection;
using Needles.Attributes;

namespace Needles.Parameters
{
    internal class Parameter
    {
        private readonly IContainer _container;
        public readonly Type Type;
        public readonly bool Manual;

        public Parameter(ParameterInfo info, IContainer container)
        {
            _container = container;
            Type = info.ParameterType;
            Manual = info.IsDefined(typeof(ManualAttribute), false);
        }

        public object Resolve()
        {
            return _container.Resolve(Type);
        } 
    }
}