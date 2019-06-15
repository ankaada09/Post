using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplication.DTO
{
   public class AddUserDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Username name must have at least 3 characters.")]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Password name must have at least 3 characters.")]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int userType { get; set; }
    }
}
