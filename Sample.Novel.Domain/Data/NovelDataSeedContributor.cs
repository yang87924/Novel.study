using Sample.Novel.Domain.AuthorAggregate.Entities;
using Sample.Novel.Domain.BookAggregate.Entities;
using Sample.Novel.Domain.CategoryAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Sample.Novel.Domain.Data
{
    public class NovelDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly List<Guid> _guids;

        public NovelDataSeedContributor(
            IGuidGenerator guidGenerator,
            IRepository<Author, Guid> authorRepository,
            IRepository<Book, Guid> bookRepository,
            IRepository<Category, Guid> categoryRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _guids = new List<Guid>();

            for (int i = 0; i < 3; i++)
            {
                _guids.Add(guidGenerator.Create());
            }
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateAuthorAsync();
            await CreateCategoryAsync();
            await CreateBookAsync();
        }

        public async Task CreateAuthorAsync()
        {
            var book = new Author(
                _guids[0],
                "刘慈欣",
                "著名科幻小说作者"
            );

            await _authorRepository.InsertAsync(book);
        }

        public async Task CreateCategoryAsync()
        {
            var category = new Category(
                _guids[1],
                "科幻"
            );

            await _categoryRepository.InsertAsync(category);
        }


        public async Task CreateBookAsync()
        {

            var book = new Book(
                _guids[2],
                "三体",
                "科幻小说史诗巨著",
                _guids[0],
                "刘慈欣",
                _guids[1],
                "科幻"
            );

            book.AddVolume("三体1");
            book.Volumes[0].AddChapter("第一章", "正文1");

            await _bookRepository.InsertAsync(book);
        }
    }
}
