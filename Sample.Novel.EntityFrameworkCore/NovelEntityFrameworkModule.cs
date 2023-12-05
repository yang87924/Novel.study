using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Sample.Novel.Domain.BookAggregate.Entities;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace Sample.Novel.EntityFrameworkCore
{

    [DependsOn(
        typeof(NovelDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule))]
    public class NovelEntityFrameworkModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<NovelDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpEntityOptions>(options =>
            {
                options.Entity<Book>(entityOptions =>
                {
                    entityOptions.DefaultWithDetailsFunc =
                        query =>
                        query.Include(book => book.Volumes)
                        .ThenInclude(volume => volume.Chapters);
                });
            });
        }
    }
}