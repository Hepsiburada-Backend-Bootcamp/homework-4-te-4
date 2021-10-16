using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    public class CreateOrderDto
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
