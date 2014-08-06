namespace Needles.Parameters
{
    internal interface IArgumentsResolver
    {
        object[] Resolve(params object[] args);
    }

    internal class ArgumentsResolver : IArgumentsResolver
    {
        private readonly IParameterCollection _parameters;
        private readonly IArgumentsValidation _argumentsvalidation;
        private readonly IContainer _container;

        public ArgumentsResolver(IParameterCollection parameters, IArgumentsValidation argumentsvalidation, IContainer container)
        {
            _parameters = parameters;
            _argumentsvalidation = argumentsvalidation;
            _container = container;
        }

        public object[] Resolve(params object[] args)
        {
            _argumentsvalidation.Validate(args);

            var informedArgsIndex = 0;
            var finalArgs = new object[_parameters.Count];

            for (var i = 0; i < _parameters.Count; i++)
            {
                var parameter = _parameters[i];

                finalArgs[i] = parameter.Manual
                    ? args[informedArgsIndex++]
                    : _container.Resolve(parameter.Type);
            }

            return finalArgs;
        }
    }
}