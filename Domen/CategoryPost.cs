using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
   public class CategoryPost:BaseEntity
    {
        public string NameCat { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
