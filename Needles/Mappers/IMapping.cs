namespace Needles.Mappers
{
    internal interface IMapping
    {
        object Resolve();
    }

    internal interface IMapping<out T> : IMapping
    {
        new T Resolve();
    }
}