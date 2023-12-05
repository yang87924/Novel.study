using Sample.Novel.Domain.AuthorAggregate.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.AuthorAggregate
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {

    }
}