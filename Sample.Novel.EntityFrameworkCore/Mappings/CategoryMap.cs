using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Novel.Domain.CategoryAggregate.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Sample.Novel.EntityFrameworkCore.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.ConfigureByConvention();

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
