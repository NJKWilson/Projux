namespace Projux.Backend.Core.Database;

using LiteDB;

public class LiteDbContext : ILiteDbContext
{
    public LiteDatabase Database { get; }

    public LiteDbContext(LiteDbOptions options)
    {
        Database = new LiteDatabase(options.DatabaseLocation);
    }
}
