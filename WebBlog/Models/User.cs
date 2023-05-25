using System;
using System.Collections.Generic;

namespace WebBlog.Models
{
    public partial class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            CommentDetails = new HashSet<CommentDetail>();
        }

        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Intro { get; set; }
        public string? Profile { get; set; }
        public string UserAuthority { get; set; } = null!;

        public virtual Aspnetuser UserNavigation { get; set; } = null!;
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
    }
}
