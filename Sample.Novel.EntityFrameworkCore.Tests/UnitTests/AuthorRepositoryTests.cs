using Sample.Novel.Domain.AuthorAggregate.Entities;
using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Tests.UnitTests
{
    public sealed class AuthorRepositoryTests : NovelEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IGuidGenerator _guidGenerator;

        public AuthorRepositoryTests()
        {
            _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Author()
        {
            var testAuthor = new Author(
                _guidGenerator.Create(),
                "张家老三",
                "中国内地不知名网络小说作家");

            await WithUnitOfWorkAsync(async () =>
            {
                await _authorRepository.InsertAsync(testAuthor);

            });

            var result = await WithUnitOfWorkAsync(async () =>
            {
                return await _authorRepository.FirstOrDefaultAsync(author => author.Id == testAuthor.Id);
            });

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Get_List_Of_Authors()
        {
            var result = await WithUnitOfWorkAsync(async () => await _authorRepository.GetListAsync());

            result.Count.ShouldBeGreaterThan(0);
        }
    }
}
