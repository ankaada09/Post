using Aplication.DTO;
using Aplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PostIndexViewModel
    {
        public IEnumerable<PostDto> Posts { get; set; }
        public IEnumerable<CategoryPostDto> CategoryPosts { get; set; }

        public IEnumerable<UpdatePostDto> UpdatePost { get; set; }

        public IEnumerable<PictureDto> PictureDtos { get; set; }
        

        
    }
}
