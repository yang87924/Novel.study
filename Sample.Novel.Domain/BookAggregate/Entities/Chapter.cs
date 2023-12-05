using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.BookAggregate.Entities
{
    public class Chapter : Entity<Guid>, IHasCreationTime
    {
        public Volume Volume { get; set; }
        public Guid VolumeId { get; set; }

        public string Title { get; set; }
        public ChapterText ChapterText { get; protected set; }
        public int WordsNumber { get; set; }
        public DateTime CreationTime { get; }

        protected Chapter()
        {
        }

        public Chapter(
            string title,
            string content,
            string authorMessage = null
        )
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            WordsNumber = content.Length;

            ChapterText = new ChapterText(content, authorMessage);
        }
    }
}