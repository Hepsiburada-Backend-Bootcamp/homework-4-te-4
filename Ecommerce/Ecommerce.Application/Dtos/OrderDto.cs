using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderItemDto> Items{ get; set; }
        public bool IsFinal { get; set; }
        public double TotalPrice { get; set; }
    }
}
