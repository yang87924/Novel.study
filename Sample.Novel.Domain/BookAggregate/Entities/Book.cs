using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.BookAggregate.Entities
{
    public class Book : AggregateRoot<Guid>, IHasCreationTime
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Volume> Volumes { get; protected set; }

        public DateTime CreationTime { get; }


        protected Book()
        {

        }

        public Book(
            Guid id,
            string name,
            string description,
            Guid authorId,
            string authorName,
            Guid categoryId,
            string categoryName
        )
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
            AuthorId = authorId;
            AuthorName = Check.NotNullOrWhiteSpace(authorName, nameof(authorName));
            CategoryId = categoryId;
            CategoryName = Check.NotNullOrWhiteSpace(categoryName, nameof(categoryName));
            Volumes = new List<Volume>();
        }

        // 添加分卷
        public void AddVolume(
            string title,
            string description = null)
        {
            // 防止添加标题相同的分卷
            if (Volumes.Any(volume => volume.Title == title))
            {
                return;
            }

            Volumes.Add(new Volume(title, description));
        }

        // 删除指定分卷
        public void RemoveVolume(Guid volumeId)
        {
            Volumes.RemoveAll(volume => volume.Id == volumeId);
        }
    }
}
