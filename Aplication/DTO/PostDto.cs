using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTO
{
  public  class PostDto
    {
        public int Id { get; set; }
        public List<PictureDto> PictureDtos { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CategoryName { get; set; }
        public string UserId { get; set; }

       
    }
}
