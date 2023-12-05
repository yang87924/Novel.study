using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.CategoryAggregate.Entities
{
    public class Category : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        protected Category()
        {

        }

        public Category(
            Guid id,
            string name
        )
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}
