using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
  public  class UpdatePostDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name name must have at least 3 characters.")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Text name must have at least 3 characters.")]
        [MaxLength(20)]

        public string Text { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Picture name must have at least 3 characters.")]
        [MaxLength(20)]
        //public List<PictureDto> pictureDtos { get; set; }
        public string Pictures { get; set; } 
        //public int PictureId { get; set; }
        

    }
}
