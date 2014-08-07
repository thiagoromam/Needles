using System;
using System.Text;

namespace Needles.Exceptions.ResolveExceptions
{
    public class ResolveWithArgumentsException : Exception
    {
        internal ResolveWithArgumentsException(Type type, ResolveWithArgumentsExceptionType exceptionType) : 
            base(GenerateMessage(type, exceptionType)) { }

        private static string GenerateMessage(Type type, ResolveWithArgumentsExceptionType exceptionType)
        {
            var message = new StringBuilder();

            message.AppendFormat("You tried to resolve an instance of {0} with arguments", type.Name);

            switch (exceptionType)
            {
                case ResolveWithArgumentsExceptionType.TypeDoesNotHasParameters:
                    message.Append(", but it does not has any parameters.");
                    break;
                case ResolveWithArgumentsExceptionType.TypeDoesNotHasManualParameters:
                    message.Append(", but it does not has any manual parameters.");
                    break;
                case ResolveWithArgumentsExceptionType.ResolveDoesNotAcceptArguments:
                    message.Append(", but the resolution method does not accept parameters.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("exceptionType");
            }

            return message.ToString();
        }
    }

    internal enum ResolveWithArgumentsExceptionType
    {
        TypeDoesNotHasParameters,
        TypeDoesNotHasManualParameters,
        ResolveDoesNotAcceptArguments
    }
}