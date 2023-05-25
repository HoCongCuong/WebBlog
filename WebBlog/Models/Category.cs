using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public long CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
