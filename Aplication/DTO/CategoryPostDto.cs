using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
   public class CategoryPostDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required ")]
        [MinLength(3, ErrorMessage = "Category name must have at least 3 characters.")]
        public string Name { get; set; }


       

    }
}
