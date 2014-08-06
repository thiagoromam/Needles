using System.Reflection;
using Needles.Parameters;

namespace Needles.Factories
{
    internal interface IParameterFactory
    {
        IParameter Create(ParameterInfo info);
    }

    internal class ParameterFactory : IParameterFactory
    {
        public IParameter Create(ParameterInfo info)
        {
            return new Parameter(info);
        }
    }
}