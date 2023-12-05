using Sample.Novel.Domain.BookAggregate.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sample.Novel.Domain.BookAggregate
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default);
    }
}