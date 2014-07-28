namespace Needles.Tests.Types
{
    public interface IDatabase { }

    public class Database : IDatabase
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly IConnection _connection;
        public Database(IConnection connection)
        {
            _connection = connection;
        }
    }
}