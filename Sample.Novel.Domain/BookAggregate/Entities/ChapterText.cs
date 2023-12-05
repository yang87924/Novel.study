using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.BookAggregate.Entities
{
    public class ChapterText : Entity<Guid>, IHasModificationTime
    {
        public Chapter Chapter { get; set; }

        public string Content { get; set; }
        public string AuthorMessage { get; set; }
        public DateTime? LastModificationTime { get; set; }

        protected ChapterText()
        {

        }

        public ChapterText(
            string content,
            string authorMessage = null)
        {
            Content = Check.NotNullOrWhiteSpace(content, nameof(content));
            AuthorMessage = authorMessage;
        }
    }
}