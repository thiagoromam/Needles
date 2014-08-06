using Needles.Parameters;

namespace Needles.Tests.Mocks
{
    public class ArgumentsValidationMock : IArgumentsValidation
    {
        public int ValidateCallsCount { get; set; }

        void IArgumentsValidation.Validate(params object[] args)
        {
            ValidateCallsCount++;
        }
    }
}