using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Responses
{
   public class PagedResponses<T>
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
