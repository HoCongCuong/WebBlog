using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class Comment
    {
        public Comment()
        {
            CommentDetails = new HashSet<CommentDetail>();
        }

        public long CommentId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; } = null!;

        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
    }
}
