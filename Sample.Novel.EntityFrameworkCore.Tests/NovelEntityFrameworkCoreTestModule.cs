using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.TestBase;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore.Tests
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreSqliteModule),
        typeof(NovelTestBaseModule),
        typeof(NovelEntityFrameworkModule)
    )]
    public class NovelEntityFrameworkCoreTestModule : AbpModule
    {
        private SqliteConnection _sqliteConnection;

        private static SqliteConnection CreateDatabaseAndGetConnection()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<NovelDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new NovelDbContext(options);
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
            return connection;
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            _sqliteConnection = CreateDatabaseAndGetConnection();
            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure(config =>
                    config.DbContextOptions.UseSqlite(_sqliteConnection));
            });
        }

        public override void OnApplicationShutdown(ApplicationShutdownContext context)
        {
            _sqliteConnection.Dispose();
        }
    }
}