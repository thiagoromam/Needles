namespace Needles.Tests.Types
{
    public interface IDatabase { }

    public class Database : IDatabase
    {
        public readonly IConnection Connection;
        public Database(IConnection connection)
        {
            Connection = connection;
        }
    }
}