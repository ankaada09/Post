using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Search
{
   public class CommentSearch
    {
        public string Comment { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
    }
}
