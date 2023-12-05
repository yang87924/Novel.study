using Sample.Novel.Domain;
using Volo.Abp.Auditing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Novel.Application.Contracts
{
    [DependsOn(typeof(AbpAutoMapperModule),
        typeof(NovelDomainModule))]
    public class NovelAppIicationContractModuIe:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AuthorProfile>();
            });
        }
    }
}
