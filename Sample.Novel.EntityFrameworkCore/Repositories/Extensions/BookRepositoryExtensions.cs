using System;
using Sample.Novel.Domain.BookAggregate;
using Sample.Novel.Domain.BookAggregate.Entities;
using Volo.Abp.Threading;

namespace Sample.Novel.EntityFrameworkCore.Repositories.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static Chapter FindChapterById(this IBookRepository repository, Guid id, bool include = true)
        {
            return AsyncHelper.RunSync(
                () => repository.FindChapterByIdAsync(id, include)
            );
        }
    }
}