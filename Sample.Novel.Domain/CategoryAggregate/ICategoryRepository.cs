using Sample.Novel.Domain.CategoryAggregate.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.CategoryAggregate
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {

    }
}