using System;
using System.Collections.Generic;
using System.Text;

namespace Domen
{
   public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
