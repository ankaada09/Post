
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO
{
   public class InsertPostDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
