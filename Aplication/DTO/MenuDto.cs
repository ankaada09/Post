using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
   public class MenuDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required ")]
        [MinLength(3, ErrorMessage = "Menu name must have at least 3 characters.")]
        public string MenuName { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [MinLength(3, ErrorMessage = "Link name must have at least 3 characters.")]
        public string Link { get; set; }
    }
}
