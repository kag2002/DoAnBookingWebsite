using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BookingWebsite.EntityFrameworkCore
{
    public static class BookingWebsiteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BookingWebsiteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BookingWebsiteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
