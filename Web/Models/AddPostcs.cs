using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class AddPostcs
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
