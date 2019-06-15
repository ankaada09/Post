using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
   public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public string Email { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
