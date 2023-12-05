using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Sample.Novel.Domain.AuthorAggregate.Entities;
using Sample.Novel.Domain.BookAggregate.Entities;
using Sample.Novel.Domain.CategoryAggregate.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore
{
    [ConnectionStringName("Novel")]
    public class NovelDbContext : AbpDbContext<NovelDbContext>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<ChapterText> ChapterTexts { get; set; }

        public NovelDbContext(DbContextOptions<NovelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
