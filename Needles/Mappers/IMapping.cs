namespace Needles.Mappers
{
    internal interface IMapping
    {
        object Resolve(object[] args);
    }

    internal interface IMapping<out T> : IMapping
    {
        new T Resolve(object[] args);
    }
}