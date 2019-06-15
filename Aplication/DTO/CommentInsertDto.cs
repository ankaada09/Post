using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
    public class CommentInsertDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [MinLength(3, ErrorMessage = "Comment must have at least 3 characters.")]
        public string Comment { get; set; }
    }
}
