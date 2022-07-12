namespace Projux.Backend.Core.Database;

using LiteDB;

public interface ILiteDbContext
{
    LiteDatabase Database { get; }
}
