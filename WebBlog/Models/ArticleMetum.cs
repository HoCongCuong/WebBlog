using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class ArticleMetum
    {
        public long ArticleMetaId { get; set; }
        public string MetaKey { get; set; } = null!;
        public string? MetaContent { get; set; }
        public long? ArticleId { get; set; }

        public virtual Article? Article { get; set; }
    }
}
