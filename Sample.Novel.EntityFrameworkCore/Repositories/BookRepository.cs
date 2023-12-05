using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Sample.Novel.Domain.BookAggregate;
using Sample.Novel.Domain.BookAggregate.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore.Repositories
{
    public class BookRepository : EfCoreRepository<NovelDbContext, Book, Guid>, IBookRepository
    {
        public BookRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
        {
            var chapters = (await GetDbContextAsync()).Chapters;
            var result = await chapters.IncludeIf(include, chapter => chapter.ChapterText)
                .FirstOrDefaultAsync(
                    chapter => chapter.Id == id,
                    GetCancellationToken(cancellationToken)
                );
            return result;
        }
    }
}
