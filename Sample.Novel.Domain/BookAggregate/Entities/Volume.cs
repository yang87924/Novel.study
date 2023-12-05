using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.BookAggregate.Entities
{
    public class Volume : Entity<Guid>, IHasCreationTime
    {
        public Book Book { get; set; }
        public Guid BookId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public List<Chapter> Chapters { get; protected set; }

        public DateTime CreationTime { get; }

        protected Volume()
        {

        }

        public Volume(
            string title,
            string description = null
        )
        {
            Title = title;
            Description = description;
            Chapters = new List<Chapter>();
        }

        public void AddChapter(
            string title,
            string content)
        {
            // 防止两次添加标题相同的章节
            if (Chapters.Any(chapter => chapter.Title == title))
            {
                return;
            }

            Chapters.Add(new Chapter(title, content));
        }

        // 删除指定章节
        public void RemoveChapter(Guid chapterId)
        {
            Chapters.RemoveAll(chapter => chapter.Id == chapterId);
        }
    }
}
