using LiteDB;
namespace Projux.Backend.Core.Database
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
