using System;
using System.Collections;
using System.Collections.Generic;

namespace Ecommerce.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public bool IsFinal { get; set; } = false;
        public virtual double TotalPrice
        {
            get => CalculatePrice();
        }

        public double CalculatePrice()
        {
            double totalPrice = 0;
            foreach (OrderItem item in Items)
            {
                totalPrice += item.Quantity * item.Product.Price;
            }
            return totalPrice;
        }
    }
}