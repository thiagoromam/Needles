using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Needles.Parameters;

namespace Needles.Exceptions.ResolveExceptions
{
    public class ResolveWithInvalidParametersSequenceException : Exception
    {
        internal ResolveWithInvalidParametersSequenceException(Type type, IEnumerable<IParameter> parameters, IEnumerable<object> args)
            : base(GenerateMessage(type, parameters, args)) { }

        private static string GenerateMessage(Type type, IEnumerable<IParameter> parameters, IEnumerable<object> args)
        {
            var message = new StringBuilder();

            message.AppendFormat("You specified an invalid sequence of arguments to resolve an instance of {0}:", type.Name);
            message.AppendLine();
            message.AppendFormat("The Correct sequence is ({0})", string.Join(", ", parameters.Select(p => p.Type.Name)));
            message.AppendLine(string.Format(", but you specified ({0})", string.Join(", ", args.Select(a => a.GetType().Name))));

            return message.ToString();
        }
    }
}