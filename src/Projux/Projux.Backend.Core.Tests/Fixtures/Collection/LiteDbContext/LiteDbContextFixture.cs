namespace Projux.Backend.Core.Tests.Fixtures.Collection.LiteDbContext;

using Projux.Backend.Core.Database;

public class LiteDbContextFixture : IDisposable
{
    public LiteDbContextFixture()
    {
        Db = new Database.LiteDbContext(new LiteDbOptions { DatabaseLocation = @"LiteDbTest.db" });
    }

    public void Dispose()
    {
        Db.Database.Dispose();
        File.Delete(@"LiteDbTest.db");
    }

    public ILiteDbContext Db { get; private set; }
}
