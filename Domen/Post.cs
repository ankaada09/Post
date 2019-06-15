using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
    public class Post:BaseEntity
    {
    
        public string Name { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public CategoryPost CategoryPost { get; set; }
        public int CategoryPostId { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
