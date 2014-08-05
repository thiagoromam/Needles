using System.Linq;
using Needles.Exceptions.ResolveExceptions;
using Needles.Helpers;

namespace Needles.Parameters
{
    internal class ManualParametersValidation<T>
    {
        private readonly Parameter[] _parameters;

        // ReSharper disable once ParameterTypeCanBeEnumerable.Local
        public ManualParametersValidation(ParameterCollection<T> parameters)
        {
            _parameters = parameters.Where(p => p.Manual).ToArray();
        }

        public void Validate(object[] args)
        {
            var hasArgs = !args.IsNullOrEmpty();

            if (_parameters.Length == 0)
            {
                if (hasArgs)
                    throw new ResolveWithParametersException();
            }
            else
            {
                if (!hasArgs)
                    throw new ResolveWithoutParametersException();

                if (args.Length < _parameters.Length)
                    throw new ResolveWithLessParametersException();

                if (args.Length > _parameters.Length)
                    throw new ResolveWithMoreParametersException();

                if (!IsSequenceValid(args))
                    throw new ResolveWithInvalidParametersSequenceException();
            }
        }

        private bool IsSequenceValid(object[] args)
        {
            for (var i = 0; i < _parameters.Length; i++)
            {
                var parameter = _parameters[i];
                var arg = args[i];

                if (arg.GetType() != parameter.Type)
                    return false;
            }

            return true;
        }
    }
}