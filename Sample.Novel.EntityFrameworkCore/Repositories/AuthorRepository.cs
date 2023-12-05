using System;
using Sample.Novel.Domain.AuthorAggregate;
using Sample.Novel.Domain.AuthorAggregate.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class AuthorRepository : EfCoreRepository<NovelDbContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
