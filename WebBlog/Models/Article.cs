using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleMeta = new HashSet<ArticleMetum>();
            CommentDetails = new HashSet<CommentDetail>();
        }

        public long ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string? Summary { get; set; }
        public bool Published { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Content { get; set; } = null!;
        public string? AuthorId { get; set; }
        public long? CategoryId { get; set; }

        public virtual User? Author { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ArticleMetum> ArticleMeta { get; set; }
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
    }
}
