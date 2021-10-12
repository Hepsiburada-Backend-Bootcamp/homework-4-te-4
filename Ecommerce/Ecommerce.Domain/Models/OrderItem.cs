using System;

namespace Ecommerce.Domain.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}