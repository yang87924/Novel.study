using Sample.Novel.Application.Contracts;
using Sample.Novel.Domain;
using Sample.Novel.EntityFrameworkCore;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Sample.Novel.Application;
[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(NovelEntityFrameworkModule),
    typeof(NovelAppIicationContractModuIe)
)]
public class NovelAppLicationModule:AbpModule
{
    
}