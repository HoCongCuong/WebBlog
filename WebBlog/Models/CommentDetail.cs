using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class CommentDetail
    {
        public long ArticleId { get; set; }
        public string UserId { get; set; } = null!;
        public long CommentId { get; set; }

        public virtual Article Article { get; set; } = null!;
        public virtual Comment Comment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
