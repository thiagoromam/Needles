namespace Needles.Mappers
{
    internal interface IMapping
    {
        object Resolve(params object[] args);
    }
}