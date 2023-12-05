using System;
using Sample.Novel.Domain.CategoryAggregate;
using Sample.Novel.Domain.CategoryAggregate.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class CategoryRepository : EfCoreRepository<NovelDbContext, Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
