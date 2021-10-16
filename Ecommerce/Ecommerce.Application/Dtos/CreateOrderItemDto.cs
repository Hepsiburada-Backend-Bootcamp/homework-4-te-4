using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Dtos
{
    public class CreateOrderItemDto
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
