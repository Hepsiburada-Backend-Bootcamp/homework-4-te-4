using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(56, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(56, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
