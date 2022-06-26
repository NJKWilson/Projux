using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projux.Backend.Core.Database
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(LiteDbOptions options)
        {
            Database = new LiteDatabase(options.DatabaseLocation);
        }
    }
}
