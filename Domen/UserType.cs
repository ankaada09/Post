using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
   public class UserType:BaseEntity
    {
        public string Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
