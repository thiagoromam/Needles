namespace Needles.Resolvers
{
    internal interface IResolver<out T>
    {
        T Resolve(object[] args);
    }
}