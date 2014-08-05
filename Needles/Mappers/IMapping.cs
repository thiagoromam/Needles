namespace Needles.Mappers
{
    internal interface IMapping
    {
        object Resolve(params object[] args);
    }

    internal interface IMapping<out T> : IMapping
    {
        new T Resolve(params object[] args);
    }
}