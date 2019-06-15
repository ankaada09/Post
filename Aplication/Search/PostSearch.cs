using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Search
{
  public  class PostSearch
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;

        public bool? OnlyActive { get; set; }

       
       public string searchString { get; set; }

    }
}
