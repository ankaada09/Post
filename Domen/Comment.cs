using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
   public class Comment:BaseEntity
    {
        public string Comments { get; set; }

        public Post Post { get; set; }
        public int PostId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
