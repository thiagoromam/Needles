using Needles.Parameters;

namespace Needles.Tests.Mocks
{
    public class ArgumentsResolverMock : IArgumentsResolver
    {
        public ArgumentsResolverMock(params object[] args)
        {
            Args = args;
        }

        public object[] Args { get; set; }
        public object[] InformedArgs { get; set; }

        object[] IArgumentsResolver.Resolve(params object[] args)
        {
            InformedArgs = args;
            return Args;
        }
    }
}