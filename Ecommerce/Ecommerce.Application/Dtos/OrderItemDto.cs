using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public ProductDto ProductDto { get; set; }
        public int Quantity { get; set; }
    }
}
