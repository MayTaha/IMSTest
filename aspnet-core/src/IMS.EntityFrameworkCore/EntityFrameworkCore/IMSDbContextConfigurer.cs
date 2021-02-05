using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IMS.EntityFrameworkCore
{
    public static class IMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<IMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<IMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
