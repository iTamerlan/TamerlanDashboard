using Dashboard.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Dashboards.Hosts.DbMigrator
{
    public class MigrationDbContext : BaseDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options) { }
    }
}