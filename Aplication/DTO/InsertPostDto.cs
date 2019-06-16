
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
   public class InsertPostDto
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name name must have at least 3 characters.")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Text must have at least 3 characters.")]
        [MaxLength(1000)]
        public string Text { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
