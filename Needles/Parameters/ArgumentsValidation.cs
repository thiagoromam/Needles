using System;
using System.Linq;
using Needles.Exceptions.ResolveExceptions;
using Needles.Helpers;

namespace Needles.Parameters
{
    internal interface IArgumentsValidation
    {
        void Validate(params object[] args);
    }

    internal class ArgumentsValidation : IArgumentsValidation
    {
        private readonly IParameter[] _manualParameters;
        private readonly Type _instanceType;

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        public ArgumentsValidation(IParameterCollection parameters)
        {
            _instanceType = parameters.InstanceType;
            _manualParameters = parameters.Where(p => p.Manual).ToArray();
        }

        public void Validate(params object[] args)
        {
            var hasArgs = !args.IsNullOrEmpty();

            if (_manualParameters.Length == 0)
            {
                if (hasArgs)
                    throw new ResolveWithArgumentsException(_instanceType, ResolveWithArgumentsExceptionType.TypeDoesNotHasManualParameters);
            }
            else
            {
                if (!hasArgs)
                    throw new ResolveWithoutArgumentsException(_instanceType, _manualParameters.Length);

                if (args.Length < _manualParameters.Length)
                    throw new ResolveWithLessArgumentsException(_instanceType, _manualParameters.Length, args.Length);

                if (args.Length > _manualParameters.Length)
                    throw new ResolveWithMoreArgumentsException(_instanceType, _manualParameters.Length, args.Length);

                if (!IsSequenceValid(args))
                    throw new ResolveWithInvalidParametersSequenceException(_instanceType, _manualParameters, args);
            }
        }

        private bool IsSequenceValid(object[] args)
        {
            for (var i = 0; i < _manualParameters.Length; i++)
            {
                var parameterType = _manualParameters[i].Type;
                var argType = args[i].GetType();

                if (!parameterType.IsAssignableFrom(argType))
                    return false;
            }

            return true;
        }
    }
}