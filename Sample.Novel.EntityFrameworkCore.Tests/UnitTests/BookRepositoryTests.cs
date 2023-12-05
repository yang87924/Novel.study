using Sample.Novel.Domain.BookAggregate;
using Shouldly;
using System.Threading.Tasks;
using Sample.Novel.Domain.BookAggregate.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Sample.Novel.EntityFrameworkCore.Tests.UnitTests
{
    public sealed class BookRepositoryTests : NovelEntityFrameworkCoreTestBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IBookRepository>();
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Book()
        {
            var testBook = new Book(
                _guidGenerator.Create(),
                "盗墓笔记",
                "挺好玩",
                _guidGenerator.Create(),
                "三叔",
                _guidGenerator.Create(),
                "奇幻");


            await WithUnitOfWorkAsync(async () =>
            {
                await _bookRepository.InsertAsync(testBook);
            });

            var result = await WithUnitOfWorkAsync(async () =>
            {
                return await _bookRepository.FirstOrDefaultAsync(book => book.Id == testBook.Id);
            });

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Volume()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "三体");
                book.AddVolume("三体2");
                return await _bookRepository.UpdateAsync(book);
            });

            result.Volumes.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Insert_A_Valid_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "三体");
                book.Volumes[0].AddChapter("第二章", "正文");
                return await _bookRepository.UpdateAsync(book);
            });

            result.Volumes[0].Chapters.Count.ShouldBe(2);
        }


        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            var result = await WithUnitOfWorkAsync(async () =>
                await _bookRepository.GetListAsync());

            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Book_Without_Catalog()
        {
            var result = await WithUnitOfWorkAsync(async () =>
                await _bookRepository.GetAsync(b => b.Name == "三体")
                );

            result.ShouldNotBeNull();
            result.Volumes.Count.ShouldBe(1);
            result.Volumes[0].Chapters.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_A_Chapter()
        {
            var result = await WithUnitOfWorkAsync(async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "三体");
                var chapterId = book.Volumes[0].Chapters[0].Id;
                return await _bookRepository.FindChapterByIdAsync(chapterId);
            });

            result.ShouldNotBeNull();
            result.WordsNumber.ShouldBeGreaterThan(0);
            result.ChapterText.ShouldNotBeNull();
            result.ChapterText.Content.ShouldNotBeNullOrEmpty();
        }
    }
}